using Dapper; //Micro ORM
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using Componentes;

namespace Datos
{
    public class UsuarioAD : Conexion
    {
        public Usuario UsuarioInsertar(Usuario P)
        {
            param = new DynamicParameters();
            param.Add(name: "NOMBRES_USUARIO", value: P.NOMBRES_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "APELLIDOS_USUARIO", value: P.APELLIDOS_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "EMAIL_USUARIO", value: P.EMAIL_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "FECHA", value: DateTime.Now, direction: ParameterDirection.Input);
            param.Add(name: "ID_USUARIO_ACCION", value: P.ID_USUARIO_ACCION, direction: ParameterDirection.Input);
            param.Add(name: "PASSWORD_USUARIO", value: P.PASSWORD_USUARIO, direction: ParameterDirection.Input);
          
            param.Add(name: "ID_USUARIO", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO	USUARIO(NOMBRES_USUARIO, APELLIDOS_USUARIO, EMAIL_USUARIO,FECHA, ID_USUARIO_ACCION, PASSWORD_USUARIO) " +
                    " VALUES (:NOMBRES_USUARIO, :APELLIDOS_USUARIO, :EMAIL_USUARIO, :FECHA, :ID_USUARIO_ACCION, :PASSWORD_USUARIO) RETURNING ID_USUARIO INTO :ID_USUARIO", param);
                if (P.FilasAfectadas > 0)
                {
                    P.ID_USUARIO = param.Get<Int64>("ID_USUARIO");
                }
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }



            return P;
        }


        public Usuario UsuarioActualizar(Usuario P)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_USUARIO", value: P.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "NOMBRES_USUARIO", value: P.NOMBRES_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "APELLIDOS_USUARIO", value: P.APELLIDOS_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "EMAIL_USUARIO", value: P.EMAIL_USUARIO, direction: ParameterDirection.Input);
          
            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE USUARIO SET NOMBRES_USUARIO=:NOMBRES_USUARIO, APELLIDOS_USUARIO=:APELLIDOS_USUARIO " +
                    " WHERE ID_USUARIO=:ID_USUARIO", param);

            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }
        public List<Usuario> UsuarioConsultar()
        {
            List<Usuario> Lista;
            param = new DynamicParameters();
            try
            {
                Lista = (List<Usuario>)OracleConnection.Query<Usuario>(" SELECT ID_USUARIO , NOMBRES_USUARIO , APELLIDOS_USUARIO , EMAIL_USUARIO , FECHA , ID_USUARIO_ACCION , PASSWORD_USUARIO  FROM USUARIO");
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }

            return Lista;
        }

        public Usuario UsuarioConsultarPorID(Int64 id)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_USUARIO", value: id, direction: ParameterDirection.Input);

            Usuario Lista = (Usuario)OracleConnection.Query<Usuario>(" SELECT ID_USUARIO , NOMBRES_USUARIO , APELLIDOS_USUARIO , EMAIL_USUARIO , FECHA , ID_USUARIO_ACCION , PASSWORD_USUARIO  FROM USUARIO WHERE ID_USUARIO=:ID_USUARIO", param).FirstOrDefault();
            return Lista;
        }

        public Usuario UsuarioConsultarPorUsuarioYContrsena(string Correo, string contrasena)
        {

            Usuario Lista = (Usuario)OracleConnection.Query<Usuario>(" SELECT ID_USUARIO , NOMBRES_USUARIO , APELLIDOS_USUARIO , EMAIL_USUARIO , FECHA , ID_USUARIO_ACCION , PASSWORD_USUARIO  FROM USUARIO WHERE EMAIL_USUARIO='" + Correo + "'" + " and PASSWORD_USUARIO = '" + contrasena + "'").FirstOrDefault();
            return Lista;
        }
    }
}
