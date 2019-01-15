using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class FuncionarioSRV
    {
        FuncionarioLN ObjetoLN = new FuncionarioLN();

        public Funcionario ObjetoConsultarPorID(string usuario, string contasena)
        {
            return ObjetoLN.FuncionarioValidacionAutenticacion(usuario, contasena);
        }
        public bool AutenticarUsuario(Funcionario usuario, out string nombreCompleto,  out int usuarioId, out string mensajeError)
        {
            nombreCompleto = string.Empty;
            usuarioId = -1;
            mensajeError = string.Empty;

            Funcionario entidadUsuario = ObjetoLN.FuncionarioValidacionAutenticacion(usuario.LOGUIN, usuario.PASSWORD);


            if (entidadUsuario == null)
            {
                mensajeError = "Funcionario no encontrado";
                return false;
            }

            // Válida que el Usuario no se encuentre Inactivo 

            //if (!entidadUsuario.Activo)
            //{
            //    mensajeError = ArchivoDeRecursos.Mensaje_ErrorUsuarioInactivo;
            //    return false;
            //}

            //// Válida que el Perfil del Usuario se encuentre activo 

            //if (!entidadUsuario.Perfil.Activo)
            //{
            //    mensajeError = ArchivoDeRecursos.Mensaje_ErrorPerfilInactivo;
            //    return false;
            //}

            // Carga la información del Usuario

            nombreCompleto = entidadUsuario.PRIMER_NOMBRE + " " + entidadUsuario.SEGUNDO_NOMBRE + " " + entidadUsuario.PRIMER_APELLIDO + " " + entidadUsuario.SEGUNDO_APELLIDO;
            usuarioId = entidadUsuario.ID_FUNCIONARIO;

            return true;
        }


    }
}
