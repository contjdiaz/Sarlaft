using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ParametroSRV
    {
        ParametroLN parametroLN = new ParametroLN();
        public Parametro ParametroPorCodigoConsultar(string codigo)
        {
            return parametroLN.ParametroPorCodigoConsultar(codigo);
        }
    }
}
