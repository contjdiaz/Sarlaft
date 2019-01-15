using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBackend.Models;

namespace WebBackend.Controllers
{
    [HandleError()]
  
    public class ConsultaPersonaController : BaseController
    {
        ListasSRV ListasSRV = new ListasSRV();
        PersonaSRV personaSRV = new PersonaSRV();
        MenuPermisosSRV menuPermisos = new MenuPermisosSRV();
        // GET: ConsultaPersona
        public ActionResult ConsultaPersona()
        {
            List<TipoPersona> ListaTipoPersona = ListasSRV.TipoPersonaConsultar();
            List<TipoDocumento> ListaTipoDocumento = new List<TipoDocumento>();
            ConsultaPersonaViewModel consulta = new ConsultaPersonaViewModel();
            ViewBag.ListaTipoPersona = new SelectList(ListaTipoPersona, "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
            List<PersonaConsulta> pc = personaSRV.PersonaConsultarParametros();           
            consulta.ListaTipoDocumento = new SelectList(ListaTipoDocumento, "CODIGO", "NOMBRE_TIPO_DOCUMENTO");
            consulta.ListaPersonas = pc;
            return View(consulta);
        }

        [HttpPost]
        public ActionResult ConsultaPersona(ConsultaPersonaViewModel consulta)
        {
            if(consulta.CODIGO_TIPO_DOCUMENTO != String.Empty && consulta.CODIGO_TIPO_DOCUMENTO != null)
            {
                TipoDocumento tipoDoc = ListasSRV.TipoDocumentoPorCodigoConsultar(consulta.CODIGO_TIPO_DOCUMENTO);
                consulta.ID_TIPO_DOCUMENTO = tipoDoc.ID_TIPO_DOCUMENTO;              
            }

            if (consulta.CODIGO_TIPO_PERSONA != String.Empty && consulta.CODIGO_TIPO_PERSONA != null )
            {
                TipoPersona tipoPersona = ListasSRV.TipoPersonaPorCodigoConsultar(consulta.CODIGO_TIPO_PERSONA);
                consulta.ID_TIPO_PERSONA = tipoPersona.ID_TIPO_PERSONA;
                consulta.ListaTipoDocumento = new SelectList(ListasSRV.TipoDocumentoConsultar(consulta.CODIGO_TIPO_PERSONA), "CODIGO", "NOMBRE_TIPO_DOCUMENTO");
            }

            List<TipoPersona> ListaTipoPersona = ListasSRV.TipoPersonaConsultar();
            List<TipoDocumento> ListaTipoDocumento = new List<TipoDocumento>();
            ViewBag.ListaTipoPersona = new SelectList(ListaTipoPersona, "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA", consulta.ID_TIPO_PERSONA);
            consulta.ListaTipoDocumento = new SelectList(ListaTipoDocumento, "CODIGO", "NOMBRE_TIPO_DOCUMENTO",consulta.ID_TIPO_DOCUMENTO);
            List<PersonaConsulta> pc = personaSRV.PersonaConsultarParametros(consulta.ID_TIPO_DOCUMENTO, consulta.ID_TIPO_PERSONA, consulta.NUMERO_DOCUMENTO);
            consulta.ListaPersonas = pc;
           
            return View(consulta);
        }

        public ActionResult Persona(Int64 idPersona)
        {
            PersonaNaturalController personaNaturalController = new PersonaNaturalController();
            return personaNaturalController.PersonaNatural(idPersona);
        }

        public ActionResult _Menu()
        {
            Int64 idUsuario = Convert.ToInt64(Session["UsuarioId"]);
            List<UsuarioRol> listaRoles = new List<UsuarioRol>();
            listaRoles = menuPermisos.UsuarioRolConsultar(idUsuario);
            List<Menu> opcioesMenu = new List<Menu>();

            opcioesMenu = menuPermisos.MenuRolesConsultar(listaRoles);
            
            return PartialView("_Menu", opcioesMenu);
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
                List<TipoDocumento> ListaTipoDocumento = new List<TipoDocumento>();
                if (codigoTipoPersona!= string.Empty)
                {
                   ListaTipoDocumento = ListasSRV.TipoDocumentoConsultar(codigoTipoPersona);
                }

                ListaTipoDocumento.Insert(0,new TipoDocumento { ID_TIPO_DOCUMENTO = 0, NOMBRE_TIPO_DOCUMENTO = "Seleccione un valor" });
                return Json(new SelectList(ListaTipoDocumento, "CODIGO", "NOMBRE_TIPO_DOCUMENTO"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
