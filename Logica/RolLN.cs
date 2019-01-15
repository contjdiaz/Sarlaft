using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RolLN
    {
        RolAD rolDatos = new RolAD();
        public Rol RolInsertar(Rol r)
        {
            return rolDatos.RolInsertar(r);
        }

        public Rol RolActualizar(Rol r)
        {
            return rolDatos.RolActualizar(r);
        }

        public List<Rol> RolConsultar()
        {
            return rolDatos.RolConsultar();
        }
    }
}
