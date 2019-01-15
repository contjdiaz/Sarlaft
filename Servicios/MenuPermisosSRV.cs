using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class MenuPermisosSRV
    {
        MenuPermisosLN Logica = new MenuPermisosLN();

        public List<Menu> MenuRolConsultar(Int64 idRol)
        {
            return Logica.MenuRolConsultar(idRol);
        }

        /// <summary>
        /// Retorna los roles asociados a un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public List<UsuarioRol> UsuarioRolConsultar(Int64 idUsuario)
        {
            return Logica.UsuarioRolConsultar(idUsuario);
        }

        /// <summary>
        /// Consultar las opciones de menu según una lista de roles
        /// </summary>
        /// <param name="lsitaRol"></param>
        /// <returns></returns>
        public List<Menu> MenuRolesConsultar(List<UsuarioRol> listaRol)
        {
            return Logica.MenuRolesConsultar(listaRol);
        }
    }
}
