using Componentes;
using Dapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RolAD : Conexion
    {
        public Rol RolInsertar(Rol r)
        {
            param = new DynamicParameters();

            param.Add(name: "NOMBRE_ROL", value: r.NOMBRE_ROL, direction: ParameterDirection.Input);
            param.Add(name: "FECHA", value: r.FECHA, direction: ParameterDirection.Input);
            param.Add(name: "ID_USUARIO", value: r.ID_USUARIO, direction: ParameterDirection.Input);
            param.Add(name: "ID_ROL", value: r.ID_ROL, direction: ParameterDirection.Input);
          
            try
            {
                r.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO ROL(NOMBRE_ROL, FECHA,ID_USUARIO) VALUES ( :NOMBRE_ROL, :FECHA, :ID_USUARIO) RETURNING ID_ROL INTO :ID_ROL", param);
                if (r.FilasAfectadas > 0)
                {
                    r.ID_ROL = param.Get<Int64>("ID_ROL");
                }
            }
            catch (Exception Ex)
            {
                r.mensajeNotificacion = Exepciones.Exepciones(Ex);
                r.tipoMensaje = 3;
            }
            return r;
        }

        public Rol RolActualizar(Rol r)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_ROL", value: r.ID_ROL, direction: ParameterDirection.Input);
            param.Add(name: "NOMBRE_ROL", value: r.NOMBRE_ROL, direction: ParameterDirection.Input);
            param.Add(name: "FECHA", value: r.FECHA, direction: ParameterDirection.Input);
            param.Add(name: "ID_USUARIO", value:r.ID_USUARIO, direction: ParameterDirection.Input);
       
            try
            {
                r.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE ROL SET " +
                    " NOMBRE_ROL=: NOMBRE_ROL, FECHA =:FECHA, ID_USUARIO =:ID_USUARIO " +
                    " WHERE ID_ROL =:ID_ROL", param);

            }
            catch (Exception Ex)
            {
                r.mensajeNotificacion = Exepciones.Exepciones(Ex);
                r.tipoMensaje = 3;
            }

            return r;
        }

        public List<Rol> RolConsultar()
        {
            List<Rol> Lista;

            try
            {
                Lista = (List<Rol>)OracleConnection.Query<Rol>("SELECT * FROM ROL ");

            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }
            return Lista;
        }

        public Rol RolPorIdConsultar(Int64 idRol)
        {
            Rol rol = new Rol();
            param = new DynamicParameters();
            try
            {
                param = new DynamicParameters();
                param.Add(name: "ID_ROL", value: idRol, direction: ParameterDirection.Input);

                rol = (Rol)OracleConnection.Query<Rol>("SELECT * FROM ROL WHERE ID_ROL=:ID_ROL", param).FirstOrDefault();
            }
            catch (Exception Ex)
            {
                rol.mensajeNotificacion = Exepciones.Exepciones(Ex);
                rol.tipoMensaje = 3;
            }
            return rol;
        }

    }
}

