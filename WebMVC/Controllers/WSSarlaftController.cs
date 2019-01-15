using Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using Entidades;

namespace WebMVC.Controllers
{
    public class WSSarlaftController : Controller
    {

        WSSarlaftSRV WSSarlaftSR = new WSSarlaftSRV();
        WSSarlaft msarlaft = new WSSarlaft();
        // GET: WSSarlaft
        public ActionResult WSrequest()
        {
            return View();
        }

        public ActionResult WSConsulta(WSSarlaftModel modl)
        {
            var RESP = ConsultarSarlaft((modl.identificacion == null ? 0 : Int32.Parse(modl.identificacion)), "");
            ViewBag.respuesta = RESP;

            return View("WSrequest");

        }
        public string ConsultarSarlaft(long NroDocumento, string Division)
        {
            try
            {
                serviceSarlaft.addressbook1 servicio = new serviceSarlaft.addressbook1();
                var cod_emp = ConfigurationManager.AppSettings.Get("cod_emp");
                var usuario = ConfigurationManager.AppSettings.Get("usuario");
                var password = ConfigurationManager.AppSettings.Get("password");

                serviceSarlaft.DatosWsDue data = new serviceSarlaft.DatosWsDue();
                data.cod_emp = cod_emp;
                data.usuario = usuario;
                data.password = password;
                //data.nombres = nombres;
                //data.apellidos = apellidos;
                data.division = Division;
                data.identificacion = NroDocumento.ToString();




                var respuesta = servicio.getDatosWsDue(data);


                msarlaft.LISTA_CLINTON = respuesta.lista_clinton.ToString();
                msarlaft.OTROS_ORGANISMOS = respuesta.otros_organismos.ToString();
                msarlaft.LINK_R = respuesta.link.ToString();
                msarlaft.DETALLE_OTROS = respuesta.detalle_otros.ToString();
                msarlaft.DETALLE_US = respuesta.detalle_us.ToString();
                msarlaft.IDENTIFICACION = data.identificacion;
                msarlaft.FECHA_CONSULTA = DateTime.Now;
                var idresp = WSSarlaftSR.InsertarRespuesta(msarlaft);
                var r = "RESPUESTA ALMACENADA!!: -- Lista Clinton: " + respuesta.lista_clinton.ToString() + " <br /> Otros Organismos: " + respuesta.otros_organismos.ToString() + " <br /> Link: " + respuesta.link.ToString() + " <br /> Detalle_otros: " + respuesta.detalle_otros.ToString() + " <br /> Detalle_us: " + respuesta.detalle_us.ToString() + " <br /> Respuesta Web Service";
                return r;
            }
            catch (Exception)
            {
                var r = "ERROR EN CONSULTA WEB SERVICE";
                return r;
                throw;
            }
            
            

            
        }

    }
}