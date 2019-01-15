using Dapper;
using Componentes;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class Tipo_ObjetoAD:Conexion
    {
        public List<Tipo_Objeto> TipoObjetoConsultar()
        {
            List<Tipo_Objeto> Lista;
            param = new DynamicParameters();
            try
            {
                Lista = (List<Tipo_Objeto>)OracleConnection.Query<Tipo_Objeto>("SELECT * FROM TIPO_OBJETO");
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }
            return Lista;
        }
    }
}
