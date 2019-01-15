using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class OracleSrv 
    {
        ObjetoLN ObjetoLN = new ObjetoLN(); 

        public bool Insertar(Objeto Objeto)
        {
            //return ObjetoLN.Insertar(Objeto);
            return false;
        }

        public List<Objeto> Consulta()
        {
            //return ObjetoLN.Consulta();
            return null;
        }
    }
}
