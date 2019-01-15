using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RolSRV
    {
        RolLN rolLogica = new RolLN();
        public Rol RolInsertar(Rol r)
        {
            return rolLogica.RolInsertar(r);
        }

        public Rol RolActualizar(Rol r)
        {
            return rolLogica.RolActualizar(r);
        }

        public List<Rol> RolConsultar()
        {
            return rolLogica.RolConsultar();
        }
    }
}
