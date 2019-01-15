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
    public class AuditoriaAD : Conexion
    {
        public Auditoria AuditoriaInsertar(Auditoria auditoria)
        {
            param = new DynamicParameters();            
            param.Add(name: "ID_TIPO_REGISTRO", value: auditoria.ID_TIPO_REGISTRO, direction: ParameterDirection.Input);
            param.Add(name: "REGISTRO_ORIGINAL", value: auditoria.REGISTRO_ORIGINAL, direction: ParameterDirection.Input);
            param.Add(name: "REGISTRO_MODIFICADO", value: auditoria.REGISTRO_MODIFICADO, direction: ParameterDirection.Input);
            param.Add(name: "FECHA", value: auditoria.FECHA, direction: ParameterDirection.Input);
            param.Add(name: "ID_USUARIO", value: auditoria.ID_USUARIO, direction: ParameterDirection.Input);         
            param.Add(name: "ID_AUDITORIA", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {
                auditoria.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO AUDITORIA (ID_TIPO_REGISTRO, REGISTRO_ORIGINAL" +
                    ", REGISTRO_MODIFICADO,FECHA, ID_USUARIO) " +
                    "VALUES (:ID_TIPO_REGISTRO, :REGISTRO_ORIGINAL, :REGISTRO_MODIFICADO, :FECHA, :ID_USUARIO" +
                    ") RETURNING ID_AUDITORIA INTO :ID_AUDITORIA", param);
                if (auditoria.FilasAfectadas > 0)
                {
                    auditoria.ID_AUDITORIA = param.Get<Int64>("ID_AUDITORIA");
                }
            }
            catch (Exception Ex)
            {
                auditoria.mensajeNotificacion = Exepciones.Exepciones(Ex);
                auditoria.tipoMensaje = 3;
            }
            return auditoria;
        }
    }
}
