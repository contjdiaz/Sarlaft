using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class OperacionSRV
    {
        OperacionLN OperacionLN = new OperacionLN();

        public Operacion OperacionInsertar(Operacion persona)
        {
            return OperacionLN.OperacionInsertar(persona);
        }

        public List<Operacion> PersonaConsultar(Int64 Id_persona)
        {
            return OperacionLN.OperacionConsultar(Id_persona);
        }

        public Operacion OperacionConsultarPorID(Int64 id)
        {
            return OperacionLN.OperacionConsultarPorID(id);
        }

        public Operacion OperacionActualizar(Operacion Objeto)
        {
            return OperacionLN.OperacionActualizar(Objeto);
        }

        public Operacion OperacionEliminar(Operacion Objeto)
        {
            return OperacionLN.OperacionEliminar(Objeto);
        }
    }
}
