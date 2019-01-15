using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBackend.Models;
using Servicios;
using Componentes;

namespace WebBackend.Controllers
{
    [HandleError()]
    public class CuentaController :  BaseController
    {
        ConvertirModelViewAModelBDController convertir = new ConvertirModelViewAModelBDController();
        UsuarioSRV usuSrv = new UsuarioSRV();
        // GET: Cuenta
        public ActionResult Registrarse()
        {
            var model = new UsuarioViewModel();
            model.ID_USUARIO_ACCION = 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult Registrarse(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario registro = new Usuario();
                registro = convertir.ConvertirUsuarioViewModelModelBD(model);
                registro = usuSrv.UsuarioInsertar(registro);
                if (registro.tipoMensaje == 3)
                {
                    ModelState.AddModelError("", registro.mensajeNotificacion);
                }
                else
                {
                    return RedirectToAction("IniciarSesion", "Cuenta");
                }
                
            }

             return View(model);
        }

        public ActionResult IniciarSesion()
        {
            AutenticacionViewModel inicioSesionModel = new AutenticacionViewModel();
            HttpCookie httpCookie = Request.Cookies["DatosUsuarioSarlaft"];
            if (httpCookie != null && httpCookie["NombreUsuario"] != null)
            {
                inicioSesionModel.NombreUsuario = httpCookie["NombreUsuario"];
                inicioSesionModel.Recordarme = true;
            }

            return View(inicioSesionModel);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult IniciarSesion(AutenticacionViewModel inicioSesionModel)
        {

            if (ModelState.IsValid)
            {
                string nombreCompleto = String.Empty;
                string nombrePerfil = String.Empty;
                long usuarioId = 0;
                string NombreUsuario = "";
                string Contrasena = "";
                string controlador = "ConsultaPersona";
                string accion = "ConsultaPersona";
                int usuarioInterno = 0;
                Usuario registro = new Usuario();
                NombreUsuario = inicioSesionModel.NombreUsuario;
                Contrasena = inicioSesionModel.Contrasena;
                registro = usuSrv.UsuarioConsultarPorUsuarioYContrsena(NombreUsuario, Contrasena);
                if (registro != null && registro.tipoMensaje == 3)
                {
                    ModelState.AddModelError("", registro.mensajeNotificacion);
                }

                if (registro != null)
                {
                    nombreCompleto = registro.NOMBRES_USUARIO + " " + registro.APELLIDOS_USUARIO;
                    usuarioId = registro.ID_USUARIO;
                }
                else
                {//Usuario incorrecto
                    String mensaje = "Usuario y/o contraseña invalida";
                    ModelState.AddModelError("", mensaje);
                    return View(new AutenticacionViewModel());                   
                }

                Session["UsuarioId"] = usuarioId;
                Session["NombreCompleto"] = nombreCompleto;
                var authTicket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, usuarioId.ToString() + "|" + inicioSesionModel.NombreUsuario + "|" + nombrePerfil + "|" + usuarioInterno.ToString());

                
                string cookieContents = FormsAuthentication.Encrypt(authTicket);
                
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                {
                    Expires = authTicket.Expiration,
                    Path = FormsAuthentication.FormsCookiePath,
                    Secure = false,
                     HttpOnly = true
                };

                Response.Cookies.Add(cookie);

                if (inicioSesionModel.Recordarme)
                {
                    HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSarlaft");
                    httpCookie["NombreUsuario"] = inicioSesionModel.NombreUsuario;
                    httpCookie.Expires = DateTime.Now.AddDays(30d);
                    httpCookie.HttpOnly = true;
                    Response.Cookies.Add(httpCookie);
                }
                else
                {
                    if (Request.Cookies["DatosRecordarmeSarlaft"] != null)
                    {
                        HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSarlaft")
                        {
                            Expires = DateTime.Now.AddDays(-1d)
                        };
                        Response.Cookies.Add(httpCookie);
                    }
                }

                return RedirectToActionPermanent(accion, controlador);
            }

            return View(inicioSesionModel);
        }       
    }
}