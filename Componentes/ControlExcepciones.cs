using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componentes
{
    public class ControlExcepciones
    {
        public String Exepciones(Exception Inner)
        {

            if (Inner.GetBaseException() != null)
            {
                Inner = Inner.GetBaseException();
            }


            if (Inner is AplicationException)
            {
                return Inner.Message;
            }

            if (Inner is SqlException)
            {
                return ErroresSQL((SqlException)Inner);
            }

            if (Inner is OleDbException)
            {
                return ErroresOleDB((OleDbException)Inner);
            }

            if (Inner is DataException)
            {
                return ErroresEntity((DataException)Inner);
            }

            return "Error no identificado del tipo (" + Inner.GetType().ToString() + "): " + Inner.HResult + " / " + Inner.Message;

        }

        private String ErroresSQL(SqlException SqlException)
        {
            switch (SqlException.Number)
            {
                case -1: return "No se pudo conectar a la Base de Datos.";
                case 201: return "Falto un parametro.";
                case 515: return "Se esta intentando insertar un valor nulo en un campo obligatorio.";
                case 530: return "El registro tiene elementos que dependen de él, verifique por favor.";
                case 547: return "El registro tiene elementos que dependen de él, verifique por favor.";
                case 2601: return "Registro duplicado, verifique por favor.";
                case 2812: return "No se encontro el procedimiento solicitado para ejecutar.";
                case 8145: return "Parametro inexistente en el procedimiento.";
                case 8144: return "La función o el procedimiento tiene demasiados argumentos.";
                default: return "Error SQL número: " + SqlException.Number.ToString() + SqlException.Message;
            }
        }

        private String ErroresOleDB(OleDbException OleDbException)
        {
            switch (OleDbException.ErrorCode)
            {
                case -2147467259: return "Nombre de la Hoja de Excel no encontrada";
                default: return "Error OleDB número: " + OleDbException.ErrorCode.ToString() + OleDbException.Message;
                    
            }
        }

        private String ErroresEntity(DataException DataException)
        {
            String Respuesta = String.Empty; 
            switch (DataException.HResult)
            { 
                default:
                    Respuesta = DataException.Message;
                    break;
            }
            return Respuesta;
        }
    }
}
