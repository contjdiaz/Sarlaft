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
    public class ParametroAD: Conexion
    {
        public Parametro ParametroPorCodigoConsultar(string codigo)
        {
            try
            {
                Parametro param = (Parametro)OracleConnection.Query<Parametro>(" SELECT ID_PARAMETRO, CODIGO_PARAMETRO, DESCRIPCION_PARAMETRO FROM PARAMETRO WHERE CODIGO_PARAMETRO = '" + codigo + "'").FirstOrDefault();
                return param;
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

    }
}
