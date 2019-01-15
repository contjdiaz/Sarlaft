using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        [AllowAnonymous]
        public ActionResult RecuperarContrasena()
        {
 
            return View();
        }

        public ActionResult IniciarSesion()
        {
            AutenticacionViewModel inicioSesionModel = new AutenticacionViewModel();


            return View(inicioSesionModel);
        }

        //
        // POST: /Account/

        [HttpPost]
        public ActionResult IniciarSesion(AutenticacionViewModel inicioSesionModel)
        {
            if (ModelState.IsValid)
            {
                string nombreCompleto = String.Empty;
                string nombreCompletoOut;
                string nombrePerfil = String.Empty;
                int usuarioId = 0;
                int usuarioIdOut;

                Funcionario usuario = new Funcionario();
                string mensajeError;
                usuario.LOGUIN = inicioSesionModel.NombreUsuario;
                usuario.PASSWORD = inicioSesionModel.Contrasena;
                bool autenticado = false;
                FuncionarioSRV funcionarioServicio = new FuncionarioSRV();
                autenticado = funcionarioServicio.AutenticarUsuario(usuario, out nombreCompletoOut, out usuarioIdOut, out mensajeError);
                nombreCompleto = nombreCompletoOut;
                usuarioId = usuarioIdOut;

                Session["usuarioId"] = usuarioId;
                Session["nombrecompleto"] = nombreCompletoOut;
                Session["NombreUsuario"] = usuario.LOGUIN;


                if (!autenticado)
                {
                    ModelState.AddModelError("Contrasena", "El nombre de usuario o la contraseña introducidos no son correctos.");
                    return View(inicioSesionModel);
                }


                return RedirectToActionPermanent("ValidarIngreso", "ValidarIngresoUsuario");
            }

            return View(inicioSesionModel);
        }
    }
}