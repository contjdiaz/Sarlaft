using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using Componentes;
namespace Logica
{
    public class Tipo_ObjetoLN
    {
        Datos.Tipo_ObjetoAD Datos = new Datos.Tipo_ObjetoAD();

        public List<Tipo_Objeto> TipoObjetoConsultar()
        {
            return Datos.TipoObjetoConsultar();
        }
    }
}
