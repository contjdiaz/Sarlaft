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
    public class OperacionAD : Conexion
    {
        public Operacion OperacionInsertar(Operacion P)
        {
            param = new DynamicParameters();
          
            param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_OPERACIONES", value: P.ID_TIPO_OPERACIONES, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_MONEDA", value: P.ID_TIPO_MONEDA, direction: ParameterDirection.Input);
            param.Add(name: "ENTIDAD_FINANCIERA", value: P.ENTIDAD_FINANCIERA, direction: ParameterDirection.Input);
            param.Add(name: "NUMERO_PRODUCTO", value: P.NUMERO_PRODUCTO, direction: ParameterDirection.Input);
            param.Add(name: "CIUDAD", value: P.CIUDAD, direction: ParameterDirection.Input);
            param.Add(name: "MONTO", value: P.MONTO, direction: ParameterDirection.Input);
            param.Add(name: "TIPO_PRODUCTO", value: P.TIPO_PRODUCTO, direction: ParameterDirection.Input);
            param.Add(name: "PAIS", value: P.PAIS, direction: ParameterDirection.Input);
            param.Add(name: "ID_OPERACION", dbType: DbType.Int64, direction: ParameterDirection.Output);

            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO OPERACION(ID_PERSONA, ID_TIPO_OPERACIONES, ID_TIPO_MONEDA, ENTIDAD_FINANCIERA, " +
                    "NUMERO_PRODUCTO, CIUDAD, MONTO, TIPO_PRODUCTO, PAIS) " +
                    "VALUES (:ID_PERSONA, :ID_TIPO_OPERACIONES, :ID_TIPO_MONEDA, :ENTIDAD_FINANCIERA, :NUMERO_PRODUCTO, :CIUDAD, :MONTO, :TIPO_PRODUCTO, :PAIS) RETURNING ID_OPERACION INTO :ID_OPERACION", param);
                if (P.FilasAfectadas > 0)
                {
                    P.ID_OPERACION = param.Get<Int64>("ID_OPERACION");
                }
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }

        public List<Operacion> OperacionConsultar(Int64 Id_persona )
        {
            List<Operacion> Lista;
            param = new DynamicParameters();
            try
            {
           
                param.Add(name: "ID_PERSONA", value: Id_persona, direction: ParameterDirection.Input);

                Lista = (List<Operacion>)OracleConnection.Query<Operacion>("SELECT ID_OPERACION, ID_PERSONA, ID_TIPO_OPERACIONES, ID_TIPO_MONEDA, ENTIDAD_FINANCIERA, " +
                    "NUMERO_PRODUCTO, CIUDAD, MONTO, TIPO_PRODUCTO, PAIS FROM OPERACION WHERE ID_PERSONA=:ID_PERSONA ", param);
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }
            return Lista;
        }

        public Operacion OperacionConsultarPorID(Int64 id)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_OPERACION", value: id, direction: ParameterDirection.Input);

            Operacion Lista = (Operacion)OracleConnection.Query<Operacion>("SELECT ID_OPERACION, D_PERSONA, ID_TIPO_OPERACIONES, ID_TIPO_MONEDA, ENTIDAD_FINANCIERA, " +
                    "NUMERO_PRODUCTO, CIUDAD, MONTO, TIPO_PRODUCTO, PAIS FROM OPERACION WHERE ID_OPERACION=:ID_OPERACION", param).FirstOrDefault();
            return Lista;
        }

        public Operacion OperacionActualizar(Operacion Objeto)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_OPERACION", value: Objeto.ID_OPERACION, direction: ParameterDirection.Input);
            param.Add(name: "ID_PERSONA", value: Objeto.ID_PERSONA, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_OPERACIONES", value: Objeto.ID_TIPO_OPERACIONES, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_MONEDA", value: Objeto.ID_TIPO_MONEDA, direction: ParameterDirection.Input);
            param.Add(name: "ENTIDAD_FINANCIERA", value: Objeto.ENTIDAD_FINANCIERA, direction: ParameterDirection.Input);
            param.Add(name: "NUMERO_PRODUCTO", value: Objeto.NUMERO_PRODUCTO, direction: ParameterDirection.Input);
            param.Add(name: "CIUDAD", value: Objeto.CIUDAD, direction: ParameterDirection.Input);
            param.Add(name: "MONTO", value: Objeto.MONTO, direction: ParameterDirection.Input);
            param.Add(name: "TIPO_PRODUCTO", value: Objeto.TIPO_PRODUCTO, direction: ParameterDirection.Input);
            param.Add(name: "PAIS", value: Objeto.PAIS, direction: ParameterDirection.Input);

            try
            {
                Objeto.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE OPERACION SET ID_PERSONA=:ID_PERSONA, ID_TIPO_OPERACIONES=:ID_TIPO_OPERACIONES, ID_TIPO_MONEDA=:ID_TIPO_MONEDA, " +
                    " ENTIDAD_FINANCIERA=:ENTIDAD_FINANCIERA, NUMERO_PRODUCTO=:NUMERO_PRODUCTO, CIUDAD=:CIUDAD, MONTO=:MONTO, TIPO_PRODUCTO=:TIPO_PRODUCTO,  PAIS=:PAIS " +
                    "WHERE ID_OPERACION=:ID_OPERACION", param);
            }
            catch (Exception Ex)
            {
                Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
                Objeto.tipoMensaje = 3;
            }
            return Objeto;
        }

        public Operacion OperacionEliminar(Operacion Objeto)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_OPERACION", value: Objeto.ID_OPERACION, direction: ParameterDirection.Input);
            try
            {
                Objeto.FilasAfectadas = this.OracleConnection.Execute(@"DELETE FROM OPERACION WHERE ID_OPERACION=:ID_OPERACION", param);
            }
            catch (Exception Ex)
            {
                Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
                Objeto.tipoMensaje = 3;
            }
            return Objeto;
        }
    }
}
