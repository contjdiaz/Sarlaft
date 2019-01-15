using Componentes;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    [Authorize]
    public class DiccionarioController : Controller
    {
        //Declaración a los llamados a servicios y componentes
        DiccionarioSRV Diccionario = new DiccionarioSRV();
        ControlExcepciones Exepciones = new ControlExcepciones();

        // GET: Diccionario
        public ActionResult Index()
        {
            Objeto Parametros = new Objeto();
            List<Objeto> Lista = Diccionario.ObjetoConsultar(Parametros);
            return View(Lista);
        }

        // GET: Diccionario/Details/5
        public ActionResult Details(int id)
        {
            Objeto Objeto = new Objeto();

            Objeto = Diccionario.ObjetoConsultarPorID(id);
            return View(Objeto);
        }

        // GET: Diccionario/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_OBJETO = new SelectList(Diccionario.TipoObjetoConsultar(), "ID_TIPO_OBJETO", "NOMBRE_TIPO_OBJETO");
            return View();
        }

        // POST: Diccionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Objeto Objeto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Objeto = Diccionario.ObjetoInsertar(Objeto);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception Ex)
            {
                Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
            }
            
            //ViewBag solo se cargan si por un error hay que volver a la pantalla
            ViewBag.ID_TIPO_OBJETO = new SelectList(Diccionario.TipoObjetoConsultar(), "ID_TIPO_OBJETO", "NOMBRE_TIPO_OBJETO");
            return View(Objeto);
        }

        // GET: Diccionario/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Objeto Objeto = null;
            try
            {
                Objeto = Diccionario.ObjetoConsultarPorID(id);
                ViewBag.ID_TIPO_OBJETO = new SelectList(Diccionario.TipoObjetoConsultar(), "ID_TIPO_OBJETO", "NOMBRE_TIPO_OBJETO");

                if (Objeto == null)
                {
                    return HttpNotFound();
                }
                return View(Objeto);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Diccionario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Objeto Objeto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Objeto = Diccionario.ObjetoActualizar(Objeto);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception Ex)
            {
                //Para mostrar el error a la pantalla
                Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
            }
            //ViewBag solo se cargan si por un error hay que volver a la pantalla
            ViewBag.ID_TIPO_OBJETO = new SelectList(Diccionario.TipoObjetoConsultar(), "ID_TIPO_OBJETO", "NOMBRE_TIPO_OBJETO");
            return View(Objeto);
        }

        // GET: Diccionario/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Objeto Objeto = Diccionario.ObjetoConsultarPorID(id);
            if (Objeto == null)
            {
                return HttpNotFound();
            }

            Objeto = Diccionario.ObjetoEliminar(Objeto);
            return RedirectToAction("Index");
        }

        // POST: Diccionario/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    Objeto Objeto = new Objeto();
        //    try
        //    {
        //        Objeto = Diccionario.ObjetoConsultarPorID(id);
        //        Objeto = Diccionario.ObjetoEliminar(Objeto);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception Ex)
        //    {
        //        Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
        //        return View();
        //    }
        //}
    }
}
