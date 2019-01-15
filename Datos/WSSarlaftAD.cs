using Dapper; //Micro ORM
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Componentes;

namespace Datos
{
    public class WSSarlaftAD:Conexion
    {

        public WSSarlaft InsertarRespuesta(WSSarlaft Request)
        {
            param = new DynamicParameters();
            param.Add(name: "LISTA_CLINTON", value: Request.LISTA_CLINTON, direction: ParameterDirection.Input);
            param.Add(name: "OTROS_ORGANISMOS", value: Request.OTROS_ORGANISMOS, direction: ParameterDirection.Input);
            param.Add(name: "LINK_R", value: Request.LINK_R, direction: ParameterDirection.Input);
            param.Add(name: "DETALLE_OTROS", value: Request.DETALLE_OTROS, direction: ParameterDirection.Input);
            param.Add(name: "DETALLE_US", value: Request.DETALLE_US, direction: ParameterDirection.Input);
            param.Add(name: "IDENTIFICACION", value: Request.IDENTIFICACION, direction: ParameterDirection.Input);
            param.Add(name: "FECHA_CONSULTA", value: Request.FECHA_CONSULTA, direction: ParameterDirection.Input);
            param.Add(name: "IDREGISTRORESP", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {
                Request.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO RESPUESTAWSDUEDILIGENCE(LISTA_CLINTON, OTROS_ORGANISMOS, LINK_R,DETALLE_OTROS, DETALLE_US,IDENTIFICACION,FECHA_CONSULTA)" +
                    " VALUES (:LISTA_CLINTON, :OTROS_ORGANISMOS, :LINK_R, :DETALLE_OTROS, :DETALLE_US, :IDENTIFICACION,:FECHA_CONSULTA)" +
                    " RETURNING IDREGISTRORESP INTO :IDREGISTRORESP", param);
                if (Request.FilasAfectadas > 0)
                {
                    Request.IDREGISTRORESP = param.Get<Int64>("IDREGISTRORESP");
                }
            }
            catch (Exception Ex)
            {
                Request.mensajeNotificacion = Exepciones.Exepciones(Ex);
                Request.tipoMensaje = 3;
            }



            return Request;
        }
    }
}
