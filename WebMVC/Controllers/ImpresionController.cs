using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using Servicios;
using Entidades;
using WebMVC.Models;
using System.Web.Hosting;
using Componentes;

namespace WebMVC.Controllers
{
    [HandleError()]
    public class ImpresionController : Controller
    {
		PersonaNaturalSRV srvPersonaNatural = new PersonaNaturalSRV();
        PersonaJuridicaSRV PersonaJuridicaSRV = new PersonaJuridicaSRV();
		ConvertirModelViewAModelBDController convertir = new ConvertirModelViewAModelBDController();
		RelacionadoPepSRV relPepSrv = new RelacionadoPepSRV();
		OperacionSRV operacionSRV = new OperacionSRV();
		[AllowAnonymous]
        public ActionResult Encabezado()
        {
            return View();
        }

        // GET: Impresion

        public ActionResult PersonaNatural(Int64 Id)
        {
			PersonaNatural p = srvPersonaNatural.PersonaNaturalConsultarPorIdPersona(Id);
			PersonaNaturalImprimirViewModel pImprimir = new PersonaNaturalImprimirViewModel();
			
			pImprimir = convertir.ConvertirPersonaNaturalImprimirBDModel(p);
			pImprimir.RelacionadosPep = convertir.ConvertirListaRelacionadoPepBDModel(relPepSrv.RelacionadoPepPorPersonaConsultar(Id));
			pImprimir.OperacionesInternacionales = convertir.ConvertirOperacionesBDViewModel(operacionSRV.PersonaConsultar(Id));
			string header = HostingEnvironment.MapPath("~/estatico/header.html");
            string footer = HostingEnvironment.MapPath("~/estatico/footer.html");


            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--footer-spacing \"10\" " +
                                   "--footer-font-size \"10\" " +
                                   "--header-font-size \"10\" ", header, footer);


            return new ViewAsPdf("PersonaNatural", pImprimir)
            {
                FileName = "FormularioPersonaNatural.pdf",
                CustomSwitches = customSwitches,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                PageSize = Rotativa.Options.Size.A4
            };
        }


        public ActionResult PersonaJuridica(Int64 Id)
        {
            string header = HostingEnvironment.MapPath("~/estatico/headerjuridica.html");
            string footer = HostingEnvironment.MapPath("~/estatico/footer.html");
            //string header = Server.MapPath("~/estatico/headerjuridica.html");
            //string footer = Server.MapPath("~/estatico/footer.html");
            PersonaJuridicaImpresionViewModel pImprimir = new PersonaJuridicaImpresionViewModel();

            pImprimir = convertir.ConvertirPersonaJuridicaModel(Id);
            pImprimir.RelacionadosPep = convertir.ConvertirListaRelacionadoPepBDModel(relPepSrv.RelacionadoPepPorPersonaConsultar(pImprimir.Id_Rep_Legal));
            pImprimir.Administradores = convertir.ConvertirListaAdministradorpModelBD(relPepSrv.RelacionadoPepPorPersonaConsultar(Id));
            pImprimir.OperacionesInternacionales = convertir.ConvertirOperacionesBDViewModel(operacionSRV.PersonaConsultar(Id));

            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--footer-spacing \"10\" " +
                                   "--footer-font-size \"10\" " +
                                   "--header-font-size \"10\" ", header, footer);


            return new ViewAsPdf("PersonaJuridica", pImprimir)
            {
                FileName = "FormularioPersonaJuridica.pdf",
                CustomSwitches = customSwitches,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                PageSize = Rotativa.Options.Size.A4
            };
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;

            var model = new HandleErrorInfo(filterContext.Exception, "Impresion", "Action");


            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}