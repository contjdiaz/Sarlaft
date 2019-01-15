using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicios
{
    public class UsuarioSRV
    {
        UsuarioLN usuarioLN = new UsuarioLN();

        public Usuario UsuarioInsertar(Usuario usuario)
        {
            return usuarioLN.UsuarioInsertar(usuario);
        }

        public Usuario UsuarioActualizar(Usuario p)
        {
            return usuarioLN.UsuarioActualizar(p);
        }

        public List<Usuario> UsuarioConsultar()
        {
            return usuarioLN.UsuarioConsultar();
        }

        public Usuario UsuarioConsultarPorID(Int64 id)
        {
            return usuarioLN.UsuarioConsultarPorID(id);
        }

        public Usuario UsuarioConsultarPorUsuarioYContrsena(string correo, string contrasena)
        {
            return usuarioLN.UsuarioConsultarPorUsuarioYContrsena(correo, contrasena);
        }      

    }
}
