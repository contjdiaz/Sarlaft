using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Componentes;

namespace Datos
{
    public class Conexion
    {
        //Esta pendiente la declaración única de patrones de diseño


        //Variables de conexion a la base de datos
        public OracleConnection OracleConnection = new OracleConnection(ConfigurationManager.AppSettings["OracleConexion"].ToString());
        public DynamicParameters param;

        //Uso del componente de exepciones
        public ControlExcepciones Exepciones = new ControlExcepciones();

    }
}
