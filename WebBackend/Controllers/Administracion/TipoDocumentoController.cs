using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBackend.Models;

namespace WebBackend.Controllers.Administracion
{
    public class TipoDocumentoController : BaseController
    {
        ListasSRV listasSRV = new ListasSRV();
        TipoDocumentoSRV tipoDocumentoSRV = new TipoDocumentoSRV();
        ConvertirModelViewAModelBDController convertir = new ConvertirModelViewAModelBDController();
        // GET: TipoDocumento
        public ActionResult Index()
        {
            List<TipoDocumento> tpSrv = new List<TipoDocumento>();
            tpSrv = listasSRV.TiposDocumentos();
            ViewBag.ListaTipoPersona = new SelectList(listasSRV.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
            return View(tpSrv);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.ListaTipoPersona = new SelectList(listasSRV.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
            return View("Crear");
            //return Json(tpVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Editar(Int64 idTipodocumento = 0)
        {
            TipoDocumentoViewModel tpVM = null;
            ViewBag.ListaTipoPersona = new SelectList(listasSRV.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
            if (idTipodocumento == 0)
            {
                tpVM = new TipoDocumentoViewModel();
            }
            else { 
                TipoDocumento tp = listasSRV.TipoDocumentoPorIdConsultar(idTipodocumento);
                tpVM = convertir.ConvertirTipoDocumentoBDToViewModel(tp);
            }

            return View("Editar", tpVM);
            //return Json(tpVM, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Crear(TipoDocumentoViewModel tipoDocumentoVm)
        {
            if (ModelState.IsValid)
            {
                TipoDocumento tp = convertir.ConvertirTipoDocumentoViewModelToBD(tipoDocumentoVm);
                tp = tipoDocumentoSRV.TipoDocumentoActualizar(tp);
                if (tp.tipoMensaje == 3)
                {
                    ViewBag.ListaTipoPersona = new SelectList(listasSRV.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
                    return View( tipoDocumentoVm);
                }
                else
                {
                    return RedirectToAction("Index", "TipoDocumento");
                }
            }
            else
            {
                ViewBag.ListaTipoPersona = new SelectList(listasSRV.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
                return View(tipoDocumentoVm);
            }
        }

        [HttpPost]
        public ActionResult Editar(TipoDocumentoViewModel tipoDocumentoVm)
        {            
            if (ModelState.IsValid)
            {
                TipoDocumento tp = convertir.ConvertirTipoDocumentoViewModelToBD(tipoDocumentoVm);
                tp = tipoDocumentoSRV.TipoDocumentoActualizar(tp);
                if( tp.tipoMensaje == 3)
                {
                    ViewBag.ListaTipoPersona = new SelectList(listasSRV.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");
                    return View(tipoDocumentoVm);
                }
                else
                { 
                    return RedirectToAction("Index", "TipoDocumento");
                }
            }else
            { 
                ViewBag.ListaTipoPersona = new SelectList(listasSRV.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA");              
                return View(tipoDocumentoVm);
            }
        }
              
    }
}