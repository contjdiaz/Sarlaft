using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MenuPermisosLN
    {
        MenuPermisosAD Datos = new MenuPermisosAD();

        public List<Menu> MenuRolConsultar(Int64 idRol)
        {
            return Datos.MenuRolConsultar(idRol);
        }

        public List<UsuarioRol> UsuarioRolConsultar(Int64 idUsuario)
        {
            return Datos.UsuarioRolConsultar(idUsuario);
        }

        /// <summary>
        /// Consultar las opciones de menu según una lista de roles
        /// </summary>
        /// <param name="lsitaRol"></param>
        /// <returns></returns>
        public List<Menu> MenuRolesConsultar(List<UsuarioRol> listaRol)
        {
            List<Menu> listaMenu = new List<Menu>();
            if (listaRol != null && listaRol.Count > 0)
            {
                foreach(UsuarioRol item in listaRol)
                {
                    if (listaMenu.Count == 0)
                    {
                        listaMenu = (Datos.MenuRolConsultar(item.ID_ROL));
                    }
                    else
                    {
                        List<Menu> listaTemp = Datos.MenuRolConsultar(item.ID_ROL);
                        if (listaTemp != null)
                        {
                            listaMenu.AddRange(listaTemp);
                        }
                    }
                }

            }
            return listaMenu;
        }
    }
}
