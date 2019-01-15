using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DiccionarioSRV
    {
        ObjetoLN ObjetoLN = new ObjetoLN();
        Tipo_ObjetoLN TipoObjetoLN = new Tipo_ObjetoLN(); 

        public Objeto ObjetoInsertar(Objeto P)
        {
            return ObjetoLN.ObjetoInsertar(P);
        }

        public List<Objeto> ObjetoConsultar(Objeto P)
        {
            return ObjetoLN.ObjetoConsultar(P);
        }

        public Objeto ObjetoConsultarPorID(Int64 id)
        {
            return ObjetoLN.ObjetoConsultarPorID(id);
        }

        public Objeto ObjetoActualizar(Objeto Objeto)
        {
            return ObjetoLN.ObjetoActualizar(Objeto);
        }

        public Objeto ObjetoEliminar(Objeto Objeto)
        {
            return ObjetoLN.ObjetoEliminar(Objeto);
        }

        public string ObjetoValida(Objeto objeto)
        {
            return ObjetoLN.ObjetoValida(objeto); 
        }

        public List<Tipo_Objeto> TipoObjetoConsultar()
        {
            return TipoObjetoLN.TipoObjetoConsultar();
        }

    }
}
