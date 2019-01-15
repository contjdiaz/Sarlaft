using Componentes;
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
    [HandleError()]
    public class ValidarIngresoUsuarioController : Controller
    {
		//Declaración a los llamados a servicios y componentes
		ListasSRV ListasSRV = new ListasSRV();
        PersonaSRV personaSRV = new PersonaSRV();
		ControlExcepciones Exepciones = new ControlExcepciones();

		// GET: Validar ingreso
		public ActionResult ValidarIngreso()
		{					
			List<TipoPersona> ListaTipoPersona = ListasSRV.TipoPersonaConsultar();			
			ViewBag.ListaTipoPersona = new SelectList(ListaTipoPersona, "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
            Session["RelacionadosPEP"] = null;

            return View();
		}

		[HttpPost]
		public ActionResult ValidarIngreso(ValidarIngresoViewModel validar)
		{
			try
			{
				if (ModelState.IsValid)
				{
					switch (validar.CodigoTipoPersona)
					{
						case "PJ":
                            {     
                                return RedirectToAction("PersonaJuridica", "PersonaJuridica", new { codigo = validar.CodigoTipoDocumento, documento = validar.Documento });
                            }//Ir a pagina juridica
							
						case "PN":
							return RedirectToAction("PersonaNatural", "PersonaNatural",validar); //Ir a pagina natural						
					}					
				}
			}
			catch (Exception Ex)
			{
				validar.mensajeNotificacion = Exepciones.Exepciones(Ex);
			}			

			return View();
		}

		/// <summary>
		/// Obtener un listado de tipo de documentos según el tipo de persona
		/// </summary>
		/// <param name="idTipoPersona"></param>
		/// <returns>Listdo de los documentos en formato JSON</returns>
		[HttpPost]
		public JsonResult ObtenerTipoDocPorTipoPersona(string codigoTipoPersona)
		{
			try
			{
				List<TipoDocumento> ListaTipoDocumento = ListasSRV.TipoDocumentoConsultar(codigoTipoPersona);				
				return Json(new SelectList(ListaTipoDocumento, "CODIGO", "NOMBRE_TIPO_DOCUMENTO"), JsonRequestBehavior.AllowGet);							
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;

            var model = new HandleErrorInfo(filterContext.Exception, "ValidarIngresoUsuario", "Action");


            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}