using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Componentes; 

namespace Logica
{
    public class UsuarioLN
    {
        UsuarioAD Datos = new UsuarioAD();

        public Usuario UsuarioInsertar(Usuario usuario)
        {
            string contrasena = usuario.PASSWORD_USUARIO;
            usuario.PASSWORD_USUARIO = Encriptar.encryptar(contrasena);
            usuario.ID_USUARIO_ACCION = 1;
            return Datos.UsuarioInsertar(usuario);
        }
        public Usuario UsuarioActualizar(Usuario usuario)
        {
            return Datos.UsuarioActualizar(usuario);
        }

        public Usuario UsuarioConsultarPorID(Int64 id)
        {
            return Datos.UsuarioConsultarPorID(id);
        }

        public Usuario UsuarioConsultarPorUsuarioYContrsena(string correo , string contrasena)
        {
            string contrasenaEncryptar = Encriptar.encryptar(contrasena);
            return Datos.UsuarioConsultarPorUsuarioYContrsena(correo, contrasenaEncryptar);
        }
       

        public List<Usuario> UsuarioConsultar()
        {
            return Datos.UsuarioConsultar();
        }
    }
}
