using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ParametroLN
    {
        ParametroAD parametroDatos = new ParametroAD();
        public Parametro ParametroPorCodigoConsultar(string codigo)
        {
            return parametroDatos.ParametroPorCodigoConsultar(codigo);   
        }
    }
}
