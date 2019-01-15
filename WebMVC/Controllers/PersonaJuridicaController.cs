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
    public class PersonaJuridicaController : Controller
    {
        ListasSRV ListasSRV = new ListasSRV();
        OperacionSRV OperacionSRV = new OperacionSRV();
        ControlExcepciones Exepciones = new ControlExcepciones();
        ConvertirModelViewAModelBDController convertir = new ConvertirModelViewAModelBDController();
        PersonaSRV pSrv = new PersonaSRV();
        PersonaNaturalSRV pnSrv = new PersonaNaturalSRV();
        PersonaJuridicaSRV PersonaJuridicaSRV = new PersonaJuridicaSRV();
        RelacionadoPepSRV relPepSrv = new RelacionadoPepSRV();

        public ActionResult _AgregarOperacion(int? IdPersona)
        {
            var model = new OpercacionViewModel();
            List<TipoOperacion> listTipoOperaciones = ListasSRV.TipoOperacionConsultar();
            List<TipoMoneda> lisTipoMoneda = ListasSRV.TipoMonedaConsultar();

            ViewBag.ListTipoOperaciones = new SelectList(listTipoOperaciones, "ID_TIPO_OPERACION", "NOMBRE_TIPO_OPERACION");
            ViewBag.LisTipoMoneda = new SelectList(lisTipoMoneda, "ID_TIPO_MONEDA", "NOMBRE_TIPO_MONEDA");
            return PartialView("_AdicionarDatosOperacionesInternacionales", model);
        }

        public ActionResult _DatosAccionista(int? IdPersona)
        {
            var model = new RelacionadoPepViewModel();
            model.ID_RELACIONADO_PEP = 0;
            List<TipoDocumento> listTipoIden = ListasSRV.TipoDocumentoConsultar("PN");
            List<TipoRelacionPEP> listadoTipoAdmin = ListasSRV.TipoRelacionPEPConsultar("PJ");
            List<CargoPEP> listadoCargos = ListasSRV.CargoConsultar();

            ViewBag.ListaTipoIden = new SelectList(listTipoIden, "ID_TIPO_DOCUMENTO", "NOMBRE_TIPO_DOCUMENTO");
            ViewBag.listadoTipoAdmin = new SelectList(listadoTipoAdmin, "ID_TIPO_REL_PEP", "NOMBRE_TIPO_REL_PEP");
            ViewBag.listadoCargos = new SelectList(listadoCargos, "ID_CARGO_PEP", "NOMBRE_CARGO_PEP");
            return PartialView("_DatosAccionista", model);
        }

        public JsonResult CantidadAdministradores(int IdPersona)
        {
            List<RelacionadoPepViewModel> ListaRelacionadosPEP = convertir.ConvertirListaAdministradorpModelBD(relPepSrv.RelacionadoPepPorPersonaConsultar(IdPersona));
            int cantidad = 0;
            if (ListaRelacionadosPEP != null)
            {
                cantidad = ListaRelacionadosPEP.Count;
            }

            return Json(cantidad, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CantidadOperacion(int IdPersona)
        {
            List<Operacion> listaOperacion = OperacionSRV.PersonaConsultar(Convert.ToInt64(IdPersona));
            int cantidad = 0;
            if (listaOperacion != null)
            {
                cantidad = listaOperacion.Count;
            }

            return Json(cantidad, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConsultarAccionista(int IdRelacionadoPEP)
        {

            RelacionadoPepViewModel relacionado = new RelacionadoPepViewModel();

            RelacionadoPep datos = relPepSrv.RelacionadoPepPorId(IdRelacionadoPEP);
            relacionado = convertir.ConvertirRelacionadoPePViewModel(datos);

            List<TipoRelacionPEP> listadoTipoAdmin = ListasSRV.TipoRelacionPEPConsultar("PJ");
            ViewBag.listadoTipoAdmin = new SelectList(listadoTipoAdmin, "ID_TIPO_REL_PEP", "NOMBRE_TIPO_REL_PEP");

            List<TipoDocumento> listTipoIden = ListasSRV.TipoDocumentoConsultar("PN");
            ViewBag.ListaTipoIden = new SelectList(listTipoIden, "ID_TIPO_DOCUMENTO", "NOMBRE_TIPO_DOCUMENTO");

            List<CargoPEP> listadoCargos = ListasSRV.CargoConsultar();

            ViewBag.listadoCargos = new SelectList(listadoCargos, "ID_CARGO_PEP", "NOMBRE_CARGO_PEP");
            return PartialView("_DatosAccionista", relacionado);
        }
        public JsonResult AgregarAccionista(int Id,
                                 int Id_persona,
                                 string Id_tipo_relacion,
                                 string codigo_documento,
                                 string documento,
                                 string primer_nombre,
                                 string segundo_nombre,
                                 string primer_apellido,
                                 string segundo_apellido,
                                 string entidad,
                                 string Id_cargo,
                                 string fecha_vinculacion,
                                 string fecha_desvinculacion)
        {
            bool isSuccess = true;
            DateTime? datFechaVinculacion = null;
            DateTime? datFechaDesvinculacion = null;

            if (Id_persona == 0)
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(Id_tipo_relacion))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(codigo_documento))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(documento))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(primer_nombre))
                return Json(new { Response = "Error" });


            if (string.IsNullOrEmpty(primer_apellido))
                return Json(new { Response = "Error" });


            if (string.IsNullOrEmpty(entidad))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(Id_cargo))
                return Json(new { Response = "Error" });

            if (fecha_desvinculacion != string.Empty)
            {
                datFechaDesvinculacion = Convert.ToDateTime(fecha_desvinculacion);
            }
            if (fecha_vinculacion != string.Empty)
            {
                datFechaVinculacion = Convert.ToDateTime(fecha_vinculacion);
            }


            var objeto = new RelacionadoPep
            {
                ID_RELACIONADO_PEP = Id,
                CARGO = "",
                DOCUMENTO = documento,
                FEC_DESVINCULA = datFechaDesvinculacion,
                FEC_VINCULA = datFechaVinculacion,
                ID_CARGO_PEP = Convert.ToInt64(Id_cargo),
                ID_PERSONA = Convert.ToInt64(Id_persona),
                ID_TIPO_DOCUMENTO = Convert.ToInt64(codigo_documento),
                ID_TIPO_REL_PEP = Convert.ToInt64(Id_tipo_relacion),
                NOMBRE_ENTIDAD = entidad,
                PRIMER_NOMBRE = primer_nombre,
                PRIMER_APELLIDO = primer_apellido,
                SEGUNDO_NOMBRE = segundo_nombre,
                SEGUNDO_APELLIDO = segundo_apellido
            };

            relPepSrv.AdministradorInsertar(objeto);

            return Json(isSuccess);

        }

        public JsonResult AgregarOperacionIntenacional(int Id,
                                   int Id_persona,
                                   string Id_tipo_Operacion,
                                   string entidad_financiera,
                                   string numero_producto,
                                   string pais,
                                   string ciudad,
                                   string Id_tipo_moneda,
                                   string monto,
                                   string tipo_producto)
        {
            bool isSuccess = true;


            if (Id_persona == 0)
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(Id_tipo_Operacion))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(entidad_financiera))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(numero_producto))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(pais))
                return Json(new { Response = "Error" });


            if (string.IsNullOrEmpty(ciudad))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(Id_tipo_moneda))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(monto))
                return Json(new { Response = "Error" });

            if (string.IsNullOrEmpty(tipo_producto))
                return Json(new { Response = "Error" });


            var objeto = new Operacion
            {
                CIUDAD = ciudad,
                ENTIDAD_FINANCIERA = entidad_financiera,
                ID_PERSONA = Id_persona,
                ID_TIPO_MONEDA = Convert.ToInt64(Id_tipo_moneda),
                ID_TIPO_OPERACIONES = Convert.ToInt64(Id_tipo_Operacion),
                MONTO = Convert.ToDecimal(monto),
                NUMERO_PRODUCTO = numero_producto,
                PAIS = pais,
                TIPO_PRODUCTO = tipo_producto
            };
            OperacionSRV.OperacionInsertar(objeto);

            return Json(isSuccess);

        }

        public ActionResult _TablaOperaciones(int Id, int Eliminar)
        {
            var modeltabla = new List<Operacion>();

            if (Eliminar > 0)
            {
                Operacion objeto = new Operacion();
                objeto.ID_OPERACION = Eliminar;
                OperacionSRV.OperacionEliminar(objeto);

            }

            modeltabla = OperacionSRV.PersonaConsultar(Convert.ToInt64(Id));


            return PartialView("_TablaOperaciones", modeltabla);
        }

        public ActionResult _TablaAccionista(int Id, int Eliminar)
        {
            var modeltabla = new List<RelacionadoPepViewModel>();

            if (Eliminar > 0)
            {
                RelacionadoPep objeto = new RelacionadoPep();
                objeto.ID_RELACIONADO_PEP = Eliminar;
                relPepSrv.RelacionadoPepEliminar(objeto);
            }

            modeltabla = convertir.ConvertirListaAdministradorpModelBD(relPepSrv.RelacionadoPepPorPersonaConsultar(Id));


            return PartialView("_TablaAccionista", modeltabla);
        }


        public ActionResult _TablaRelacionadosPEP(int Id, int Eliminar)
        {
            List<RelacionadoPepViewModel> ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
            if (Eliminar != 0)
            {
                RelacionadoPepViewModel eliminarPep = ListaRelacionadosPEP.Where(e => e.ID_RELACIONADO_PEP == Eliminar).FirstOrDefault();

                if (eliminarPep != null)
                {
                    if (eliminarPep.ID_RELACIONADO_PEP > 0)
                    {
                        RelacionadoPep relPepBD = new RelacionadoPep();
                        relPepBD.ID_RELACIONADO_PEP = eliminarPep.ID_RELACIONADO_PEP;
                        relPepSrv.RelacionadoPepEliminar(relPepBD);
                    }
                    ListaRelacionadosPEP.RemoveAll(rp => rp.ID_RELACIONADO_PEP == Eliminar);
                }
            }

            if (ListaRelacionadosPEP != null)
            {
                ListaRelacionadosPEP.Where(r => r.ID_PERSONA_RPEP == Id);
            }

            Session["RelacionadosPEP"] = ListaRelacionadosPEP;

            return PartialView("_TablaRelacionadosPEP", ListaRelacionadosPEP);
        }
        // GET: PersonaJuridica
        public ActionResult Index() => View();

        public void CargarListasJuridica()
        {
            List<TipoDocumento> listTipoIden = ListasSRV.TipoDocumentoConsultar("PJ");
            List<Departamento> listaDepartamento = ListasSRV.DepartamentoConsultar();
            List<ActividadEconomica> listActEconomica = ListasSRV.ActividadEconomicaConsultar();
            List<TipoEmpresa> ListaTipoEmpresa = ListasSRV.TipoEmpresaConsultar();
            List<CodigoCiiu> listCodCUII = ListasSRV.CodigoCiiuConsultar();

            ViewBag.Listaidentificacion = new SelectList(listTipoIden, "ID_TIPO_DOCUMENTO", "NOMBRE_TIPO_DOCUMENTO");
            ViewBag.ListaDepartamento = new SelectList(listaDepartamento, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO");
            ViewBag.ListaTipoEmpresa = new SelectList(ListaTipoEmpresa, "ID_TIPO_EMPRESA", "NOMBRE_TIPO_EMPRESA");
            ViewBag.ListaActividad = new SelectList(listActEconomica, "ID_ACTIVIDAD_ECONOMICA", "NOMBRE_ACTIVIDAD_ECONOMICA");
            ViewBag.ListCodCUII = new SelectList(listCodCUII, "ID_CODIGO_CIIU", "CIIU");

        }

        public void CargarDdlCascadas(PersonaJuridicaViewModel personaJuridica)
        {
            List<Municipo> listaMunicipio = new List<Municipo>();
            List<CodigoCiiu> listaCodCiuu = new List<CodigoCiiu>();

            if (!String.IsNullOrEmpty(personaJuridica.ID_MUNICIPIO))
            {

                personaJuridica.ListaMunicipio = new SelectList(ListasSRV.MunicipioConsultar((int)personaJuridica.ID_DEPARTMENTO), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaJuridica.ID_MUNICIPIO);
            }
            else personaJuridica.ListaMunicipio = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

            if (personaJuridica.ID_MUNICIPIO_JURIDICA > 0)
            {
                personaJuridica.ListaMunicipioJuridica = new SelectList(ListasSRV.MunicipioConsultar((int)personaJuridica.ID_DEPTO_JURIDICA), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaJuridica.ID_MUNICIPIO_JURIDICA);
            }
            else personaJuridica.ListaMunicipioJuridica = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

            if (!String.IsNullOrEmpty(personaJuridica.ID_MCPO_SUCURSAL))
            {
                personaJuridica.ListaMunicipioSucursal = new SelectList(ListasSRV.MunicipioConsultar(Convert.ToInt32(personaJuridica.ID_DEPTO_SUCURSAL)), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaJuridica.ID_MCPO_SUCURSAL);
            }
            else personaJuridica.ListaMunicipioSucursal = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

            if (personaJuridica.ID_CODIGO_CIIU > 0)
            {
                personaJuridica.ListaoCodigoCiiu = new SelectList(ListasSRV.CodigoCiiuPorActividadConsultar((int)personaJuridica.ID_ACT_ECONOMICA), "ID_CODIGO_CIIU", "CIIU", personaJuridica.ID_CODIGO_CIIU);
            }
            else personaJuridica.ListaoCodigoCiiu = new SelectList(listaCodCiuu, "ID_CODIGO_CIIU", "CIIU");
        }
        public ActionResult PersonaJuridica(string codigo = "", string documento = "", Int64 Id = 0)
        {
            Session["RelacionadosPEP"] = null;
            CargarListasJuridica();
            PersonaJuridicaViewModel p = new PersonaJuridicaViewModel();
            PersonaJuridica pBD = new PersonaJuridica();
            Persona personaDB = new Persona();

            if ((!String.IsNullOrEmpty(codigo)) && (!String.IsNullOrEmpty(documento)) && Id == 0)
            {
                Int64 idTipoDocumento = ListasSRV.TipoDocumentoPorCodigoConsultar(codigo).ID_TIPO_DOCUMENTO;
                pBD = PersonaJuridicaSRV.PersonaJuridicaPorIdentificacionConsultar(idTipoDocumento, documento);

                if (pBD != null && pBD.ID_JURIDICA > 0)
                {
                    p = convertir.ConvertirPersonaJuridicaBDModel(pBD);
                    personaDB = pSrv.PersonaConsultarPorID(pBD.ID_PERSONA);
                    p.ID_TIPO_DOCUMENTO = personaDB.ID_TIPO_DOCUMENTO;
                    p.NUMERO_DOCUMENTO = personaDB.NUMERO_DOCUMENTO;
                    p.ID_MUNICIPIO = personaDB.ID_MUNICIPIO.ToString();
                    p.ID_DEPARTMENTO = ListasSRV.DepartamentoPorIdMunicipioConsultar(personaDB.ID_MUNICIPIO).ID_DEPARTAMENTO;
                    p.TIPO_DOCUMENTO = ListasSRV.TipoDocumentoPorIdConsultar(idTipoDocumento).NOMBRE_TIPO_DOCUMENTO;
                }
                else
                {
                    p.ID_TIPO_DOCUMENTO = idTipoDocumento;
                    p.NUMERO_DOCUMENTO = documento;
                    p.TIPO_DOCUMENTO = ListasSRV.TipoDocumentoPorIdConsultar(idTipoDocumento).NOMBRE_TIPO_DOCUMENTO;
                }

            }
            else if ((String.IsNullOrEmpty(codigo)) && (String.IsNullOrEmpty(documento)) && Id > 0)
            {
                pBD = PersonaJuridicaSRV.PersonaJuridicaConsultarPorPersonaID(Id);
                if (pBD != null && pBD.ID_JURIDICA > 0)
                {
                    p = convertir.ConvertirPersonaJuridicaBDModel(pBD);
                    personaDB = pSrv.PersonaConsultarPorID(pBD.ID_PERSONA);
                    p.ID_TIPO_DOCUMENTO = personaDB.ID_TIPO_DOCUMENTO;
                    p.NUMERO_DOCUMENTO = personaDB.NUMERO_DOCUMENTO;
                    p.ID_MUNICIPIO = personaDB.ID_MUNICIPIO.ToString();
                    p.ID_DEPARTMENTO = ListasSRV.DepartamentoPorIdMunicipioConsultar(personaDB.ID_MUNICIPIO).ID_DEPARTAMENTO;
                }

            }


            CargarDdlCascadas(p);
            return View(p);

        }

        [HttpPost]
        public ActionResult PersonaJuridica(PersonaJuridicaViewModel personaJuridica, string btnSiguiente)
        {
            if (ModelState.IsValid)
            {

                PersonaJuridica pj = convertir.ConvertirPersonaJuridicaModelBD(personaJuridica);
                Persona persona = new Persona();
                if (pj.ID_PERSONA > 0)
                {
                    persona = pSrv.PersonaConsultarPorID(pj.ID_PERSONA);
                    persona.ID_MUNICIPIO = Convert.ToInt64(personaJuridica.ID_MUNICIPIO);
                }
                else
                {
                    persona.ID_TIPO_DOCUMENTO = personaJuridica.ID_TIPO_DOCUMENTO;
                    persona.NUMERO_DOCUMENTO = personaJuridica.NUMERO_DOCUMENTO;
                    persona.ID_MUNICIPIO = Convert.ToInt64(personaJuridica.ID_MUNICIPIO);
                    persona.ID_TIPO_PERSONA = personaJuridica.ID_TIPO_PERSONA;
                    persona.ID_PERSONA = personaJuridica.ID_PERSONA;
                }

                try
                {

                    PersonaJuridica personajuridicaNueva = PersonaJuridicaSRV.PersonaJuridicaInsertar(pj, persona);
                    if (personajuridicaNueva.tipoMensaje != 3)
                    { return RedirectToAction("RepresentanteLegal", "PersonaJuridica", new { Id = personajuridicaNueva.ID_PERSONA }); }
                }
                catch (Exception ex)
                {
                    personaJuridica.mensajeNotificacion = Exepciones.Exepciones(ex);
                }
            }


            CargarListasJuridica();
            CargarDdlCascadas(personaJuridica);
            return View(personaJuridica);

        }

        //Datos de información financiera
        public ActionResult InformacionFinanciera(Int64 Id)
        {
            PersonaViewModel financiera = new PersonaViewModel();
            Persona objetoPersona = new Persona();
            objetoPersona = pSrv.PersonaConsultarPorID(Id);
            financiera = convertir.ConvertirPersonaBDPersonaModel(objetoPersona);
            return View(financiera);
        }

        [HttpPost]
        public ActionResult InformacionFinanciera(PersonaViewModel financiera, string btnSiguiente)
        {
            PersonaJuridica objteto = new PersonaJuridica();
            objteto = PersonaJuridicaSRV.PersonaJuridicaConsultarPorPersonaID(financiera.IdPersonaViewModel);

            if (btnSiguiente != null)
            {
                if (ModelState.IsValid)
                {
                    if (financiera != null && financiera.IdPersonaViewModel > 0)
                    {
                        Persona persona = new Persona();
                        persona = convertir.ConvertirPersonaModelPersonaBD(financiera);

                        pSrv.PersonaActualizar(persona);
                        return RedirectToAction("Accionista", "PersonaJuridica", new { Id = objteto.ID_PERSONA });
                    }
                }
            }

            return View();
        }

        public void CargarViewBagOperacionesInternacionales()
        {
            List<SelectListItem> listSiNo = new List<SelectListItem>();
            listSiNo.Add(new SelectListItem { Text = "Seleccione", Value = "Seleccione", Selected = true });
            listSiNo.Add(new SelectListItem { Text = "1", Value = "Si" });
            listSiNo.Add(new SelectListItem { Text = "0", Value = "No" });
            List<TipoOperacion> listTipoOperaciones = ListasSRV.TipoOperacionConsultar();
            List<TipoMoneda> lisTipoMoneda = ListasSRV.TipoMonedaConsultar();

            ViewBag.ListTipoOperaciones = new SelectList(listTipoOperaciones, "ID_TIPO_OPERACION", "NOMBRE_TIPO_OPERACION");
            ViewBag.LisTipoMoneda = new SelectList(lisTipoMoneda, "ID_TIPO_MONEDA", "NOMBRE_TIPO_MONEDA");
            ViewBag.ListSiNo = new SelectList(listSiNo, "Text", "Value");
        }
        public ActionResult OperacionesInternacionales(int Id)
        {

            var model = new OperacionPadreViewModel();
            model.ID_PERSONA = Id;
            model.MonedaExtranjera = String.Empty;
            CargarViewBagOperacionesInternacionales();
            return View(model);
        }

        [HttpPost]
        public ActionResult OperacionesInternacionales(OperacionPadreViewModel model, string btnSiguiente = "", string btnAnterior = "")
        {
            CargarViewBagOperacionesInternacionales();
           
            if (!String.IsNullOrEmpty(btnSiguiente))
            {
                if (model.MonedaExtranjera == "1")
                {
                    List<Operacion> lista = OperacionSRV.PersonaConsultar(Convert.ToInt64(model.ID_PERSONA));
                    if (lista != null && lista.Count == 0)
                    {
                        ModelState.AddModelError("", "Debe agregar por lo menos una operación internacional");
                        return View(model);
                    }
                }
                return RedirectToAction("AceptacionTerminos", "PersonaJuridica", new { Id = model.ID_PERSONA });
            }
            else if (!String.IsNullOrEmpty(btnAnterior))
                return RedirectToAction("Accionista", "PersonaJuridica", new { Id = model.ID_PERSONA });

            return View();

        }


        public ActionResult AceptacionTerminos(Int64 Id)
        {
            PersonaViewModel aceptacion = new PersonaViewModel();
            Persona persona = new Persona();
            persona = pSrv.PersonaConsultarPorID(Id);
            aceptacion = convertir.ConvertirPersonaBDPersonaModel(persona);
            List<SelectListItem> listSiNo = new List<SelectListItem>();
            listSiNo.Add(new SelectListItem { Text = "Seleccione", Value = "Seleccione", Selected = true });
            listSiNo.Add(new SelectListItem { Text = "1", Value = "Si" });
            listSiNo.Add(new SelectListItem { Text = "0", Value = "No" });
            ViewBag.ListSiNo = new SelectList(listSiNo, "Text", "Value");

            return View(aceptacion);
        }

        [HttpPost]
        public ActionResult AceptacionTerminos(string btnImprimir, string btnAnterior, PersonaViewModel p)
        {

            if (btnImprimir == null && btnAnterior == null)
            {
                if (ModelState.IsValid)
                {
                    Persona persona = new Persona();
                    persona = convertir.ConvertirPersonaModelPersonaBD(p);
                    pSrv.PersonaActualizar(persona);
                    return View(p);
                }
                else
                {
                    return View(false);
                }
            }

            if (btnImprimir != null)
            {
                Persona persona = new Persona();
                persona = convertir.ConvertirPersonaModelPersonaBD(p);
                pSrv.PersonaActualizar(persona);
                return RedirectToAction("PersonaJuridica", "Impresion", new { Id = p.IdPersonaViewModel });
            }

            if (btnImprimir == null && btnAnterior == null)
            {
                if (ModelState.IsValid)
                {
                    Persona persona = new Persona();
                    persona = convertir.ConvertirPersonaModelPersonaBD(p);
                    pSrv.PersonaActualizar(persona);
                    return View(p);
                }
                else
                {
                    return View(false);
                }
            }

            if (btnAnterior != null)
            { return RedirectToAction("OperacionesInternacionales", "PersonaJuridica", new { Id = p.IdPersonaViewModel }); }

            return View();

        }

        public ActionResult Accionista(int Id)
        {
            var model = new OperacionPadreViewModel();
            model.ID_PERSONA = Id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Accionista(OperacionPadreViewModel model, string btnSiguiente = "", string btnAnterior = "")
        {
            if (!String.IsNullOrEmpty(btnSiguiente))
                return RedirectToAction("OperacionesInternacionales", "PersonaJuridica", new { Id = model.ID_PERSONA });
            else if (!String.IsNullOrEmpty(btnAnterior))
            { return RedirectToAction("InformacionFinanciera", "PersonaJuridica", new { Id = model.ID_PERSONA }); }

            return View();
        }

        public ActionResult AdicionarDatosPersonaPublica()
        {
            List<SelectListItem> listTipoIden = new List<SelectListItem>();
            listTipoIden.Add(new SelectListItem { Text = "Seleccione", Value = "Seleccione", Selected = true });
            listTipoIden.Add(new SelectListItem { Text = "Cédula de ciudadanía", Value = "CC" });
            listTipoIden.Add(new SelectListItem { Text = "Pasaporte", Value = "Pasaporte" });

            List<SelectListItem> listRelacionPEP = new List<SelectListItem>();
            listRelacionPEP.Add(new SelectListItem { Text = "Seleccione", Value = "Seleccione", Selected = true });
            listRelacionPEP.Add(new SelectListItem { Text = "Padre", Value = "CC" });
            listRelacionPEP.Add(new SelectListItem { Text = "Madre", Value = "NIT" });
            listRelacionPEP.Add(new SelectListItem { Text = "Hermano (a)", Value = "Pasaporte" });

            ViewBag.ListaTipoIden = new SelectList(listTipoIden, "Text", "Value");
            ViewBag.ListRelacionPEP = new SelectList(listRelacionPEP, "Text", "Value");
            return View();
        }

        public ActionResult DatosPersonaPublica()
        {
            List<SelectListItem> listTipoIden = new List<SelectListItem>();
            listTipoIden.Add(new SelectListItem { Text = "Seleccione", Value = "Seleccione", Selected = true });
            listTipoIden.Add(new SelectListItem { Text = "Cédula de ciudadanía", Value = "CC" });
            listTipoIden.Add(new SelectListItem { Text = "Pasaporte", Value = "Pasaporte" });

            List<SelectListItem> listRelacionPEP = new List<SelectListItem>();
            listRelacionPEP.Add(new SelectListItem { Text = "Seleccione", Value = "Seleccione", Selected = true });
            listRelacionPEP.Add(new SelectListItem { Text = "Padre", Value = "CC" });
            listRelacionPEP.Add(new SelectListItem { Text = "Madre", Value = "NIT" });
            listRelacionPEP.Add(new SelectListItem { Text = "Hermano (a)", Value = "Pasaporte" });

            ViewBag.ListaTipoIden = new SelectList(listTipoIden, "Text", "Value");
            ViewBag.ListRelacionPEP = new SelectList(listRelacionPEP, "Text", "Value");
            return View();
            //return PartialView("_InformacionFinanciera");
        }
        public ActionResult CargarRepresentante(string tipo, string documento, int IdPersona, int IdJuridica)
        {
            CargarListasViewDatoGenerales();
            RepresentanteLegalViewModel p = new RepresentanteLegalViewModel();
            PersonaNatural pBD = new PersonaNatural();
            Persona personaDB = new Persona();
      
            if (IdPersona > 0)
            {
                personaDB = pSrv.PersonaConsultarPorTipoDocumento(Convert.ToInt64(tipo), documento);
                if (personaDB != null)
                {
                    pBD = pnSrv.PersonaNaturalConsultarPorIdPersona(personaDB.ID_PERSONA);
                    if (pBD != null && pBD.ID_NATURAL > 0)
                    {
                        p = convertir.ConvertirRepresentanteLegalBDModel(pBD);

                        p.ID_TIPO_DOCUMENTO = personaDB.ID_TIPO_DOCUMENTO;
                        p.NUMERO_DOCUMENTO = personaDB.NUMERO_DOCUMENTO;
                        p.ID_MUNICIPIO = personaDB.ID_MUNICIPIO;
                        p.ID_DEPARTMENTO = ListasSRV.DepartamentoPorIdMunicipioConsultar(personaDB.ID_MUNICIPIO).ID_DEPARTAMENTO;
                    
                    }
                }
                else
                {
                    p.ID_TIPO_DOCUMENTO = Convert.ToInt64(tipo);
                    p.NUMERO_DOCUMENTO = documento;
                }
            }

            p.ID_JURIDICA = IdJuridica;
            p.ID_PERSONA_JURIDICA = IdPersona;
            CargarDdlCascadasRepresentante(p);
            return PartialView("_DatosRepresentante", p);

        }
        public ActionResult RepresentanteLegal(int Id)
        {
            CargarListasViewDatoGenerales();
            RepresentanteLegalViewModel p = new RepresentanteLegalViewModel();
            PersonaJuridica juridica = new PersonaJuridica();
            juridica = PersonaJuridicaSRV.PersonaJuridicaConsultarPorPersonaID(Id);
            Int64 Id_juridica = juridica.ID_JURIDICA;
            Int64 IdRepresentanteLegal = juridica.ID_REP_LEGAL;
            p.nuevo = 1;
            PersonaNatural pBD = new PersonaNatural();
            Persona personaDB = new Persona();
            Session["RelacionadosPEP"] = null;
            if (Id_juridica > 0 && IdRepresentanteLegal > 0)
            {
                p.nuevo = 0;
                pBD = pnSrv.PersonaNaturalConsultarPorIdPersona(IdRepresentanteLegal);
                if (pBD != null && pBD.ID_NATURAL > 0)
                {
                    p = convertir.ConvertirRepresentanteLegalBDModel(pBD);
                    personaDB = pSrv.PersonaConsultarPorID(pBD.ID_PERSONA);
                    p.ID_TIPO_DOCUMENTO = personaDB.ID_TIPO_DOCUMENTO;
                    p.NUMERO_DOCUMENTO = personaDB.NUMERO_DOCUMENTO;
                    p.ID_MUNICIPIO = personaDB.ID_MUNICIPIO;
                    p.ID_DEPARTMENTO = ListasSRV.DepartamentoPorIdMunicipioConsultar(personaDB.ID_MUNICIPIO).ID_DEPARTAMENTO;
                    Session["RelacionadosPEP"] = convertir.ConvertirListaRelacionadoPepBDModel(relPepSrv.RelacionadoPepPorPersonaConsultar(pBD.ID_PERSONA));
                }

            }
            p.ID_JURIDICA = Id_juridica;
            p.ID_PERSONA_JURIDICA = Id;
            CargarDdlCascadasRepresentante(p);
            return View(p);
        }

        [HttpPost]
        public ActionResult RepresentanteLegal(RepresentanteLegalViewModel personaNatural, string btnSiguiente)
        {
            List<RelacionadoPepViewModel> ListaRelacionadosPEP = new List<RelacionadoPepViewModel>();
            if (Session["RelacionadosPEP"] != null)
            {
                ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
            }


            if ((personaNatural.DECRETO_1674 == 1 || personaNatural.REP_ORG_INTERNACIONAL == 1
                || personaNatural.RECONOCIMIENTO_PUB == 1) &&
                (personaNatural.RelacionadosPep == null ||
                (personaNatural.RelacionadosPep != null && personaNatural.RelacionadosPep.Count == 0)))
            {
                ModelState.AddModelError("", "Debe agregar por lo menos un relacionado PEP");
            }

            if (ModelState.IsValid)
            {
                Int64 Id_persona_juridica = personaNatural.ID_PERSONA_JURIDICA;
                Int64 Id_juridica = personaNatural.ID_JURIDICA;
                PersonaNatural pn = convertir.ConvertirRepresentanteLegalModelBD(personaNatural);

                Persona persona = new Persona();
                if (pn.ID_PERSONA > 0)
                {
                    persona = pSrv.PersonaConsultarPorID(pn.ID_PERSONA); ;
                    persona.ID_TIPO_DOCUMENTO = personaNatural.ID_TIPO_DOCUMENTO;
                    persona.NUMERO_DOCUMENTO = personaNatural.NUMERO_DOCUMENTO;
                }
                else
                {
                    persona.ID_TIPO_DOCUMENTO = personaNatural.ID_TIPO_DOCUMENTO;
                    persona.NUMERO_DOCUMENTO = personaNatural.NUMERO_DOCUMENTO;
                    persona.ID_MUNICIPIO = personaNatural.ID_MUNICIPIO;
                    persona.ID_TIPO_PERSONA = personaNatural.ID_TIPO_PERSONA;
                    persona.ID_PERSONA = personaNatural.ID_PERSONA;
                }

                try
                {

                    List<RelacionadoPep> ListaRelacionadosPEPBD = convertir.ConvertirListaRelacionadoPepModelBD(ListaRelacionadosPEP);
                    PersonaNatural nuevaPersona = pnSrv.RepresentanteLegalInsertar(Id_juridica, pn, persona, ListaRelacionadosPEPBD);
                    if (nuevaPersona.tipoMensaje != 3)
                    {

                        if (btnSiguiente != null)
                        {
                            return RedirectToAction("InformacionFinanciera", "PersonaJuridica", new { Id = Id_persona_juridica });
                        }
                    }
                }
                catch (Exception ex)
                {
                    personaNatural.mensajeNotificacion = Exepciones.Exepciones(ex);
                }
            }

            CargarDdlCascadasRepresentante(personaNatural);
            CargarListasViewDatoGenerales();
            return View(personaNatural);
        }

        //Datos de persona expuesta
        public ActionResult _PersonaExpuestaPoliticamente()
        {
            return View();
        }
        /// <summary>
		/// Obtener un listado de tipo de documentos según el tipo de persona
		/// </summary>
		/// <param name="departamentoId"></param>
		/// <returns>Listdo de los documentos en formato JSON</returns>
		[HttpPost]
        public JsonResult ObtenerCiudades(string departamentoId)
        {
            try
            {
                List<Ciudad> ListaMunicipios = ListasSRV.CiudadConsultar(departamentoId);
                return Json(new SelectList(ListaMunicipios, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CargarListasViewDatoGenerales()
        {
            List<Sexo> listSexo = ListasSRV.SexoConsultar();
            List<TipoDocumento> listTipoIden = ListasSRV.TipoDocumentoConsultar("PN");
            List<EstadoCivil> listEstadoCivil = ListasSRV.EstadoCivilConsultar();
            List<Departamento> listaDepartamento = ListasSRV.DepartamentoConsultar();
            List<Profesion> listProfesion = ListasSRV.ProfesionConsultar();
            List<CargoPEP> listCargoPEP = ListasSRV.CargoConsultar();
            List<TipoEmpresa> listTipoEmpresa = ListasSRV.TipoEmpresaConsultar();
            List<TipoRelacionPEP> listRelacionPEP = ListasSRV.TipoRelacionPEPConsultar("PN");

            List<SelectListItem> listSiNo = new List<SelectListItem>();
            listSiNo.Add(new SelectListItem { Text = "Seleccione un valor", Value = "Seleccione", Selected = true });
            listSiNo.Add(new SelectListItem { Text = "1", Value = "Si" });
            listSiNo.Add(new SelectListItem { Text = "0", Value = "No" });

            ViewBag.ListRelacionPEP = new SelectList(listRelacionPEP, "ID_TIPO_REL_PEP", "NOMBRE_TIPO_REL_PEP");
            ViewBag.ListaSexo = new SelectList(listSexo, "ID_SEXO", "NOMBRE_SEXO");
            ViewBag.ListaTipoIden = new SelectList(listTipoIden, "ID_TIPO_DOCUMENTO", "NOMBRE_TIPO_DOCUMENTO");
            ViewBag.ListSiNo = new SelectList(listSiNo, "Text", "Value");
            ViewBag.ListTipoEmpresa = new SelectList(listTipoEmpresa, "ID_TIPO_EMPRESA", "NOMBRE_TIPO_EMPRESA");
            ViewBag.listCargoPEP = new SelectList(listCargoPEP, "ID_CARGO_PEP", "NOMBRE_CARGO_PEP");
            ViewBag.ListProfesion = new SelectList(listProfesion, "ID_PROFESION", "NOMBRE_PROFESION");
            ViewBag.ListEstadoCivil = new SelectList(listEstadoCivil, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL");
            ViewBag.ListaDepartamento = new SelectList(listaDepartamento, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO");
        }

        public void CargarDdlCascadasRepresentante(RepresentanteLegalViewModel personaNatural)
        {
            List<Municipo> listaMunicipio = new List<Municipo>();
            List<CodigoCiiu> listaCodCiuu = new List<CodigoCiiu>();

            if (personaNatural.ID_MCPO_NACIMIENTO > 0)
            {
                personaNatural.ListaMunicipioNac = new SelectList(ListasSRV.MunicipioConsultar((int)personaNatural.ID_DEP_NACIMIENTO), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaNatural.ID_MCPO_NACIMIENTO);
            }
            else personaNatural.ListaMunicipioNac = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

            if (personaNatural.ID_MUNICIPIO > 0)
            {
                personaNatural.ListaMunicipio = new SelectList(ListasSRV.MunicipioConsultar((int)personaNatural.ID_DEPARTMENTO), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaNatural.ID_MUNICIPIO);
            }
            else personaNatural.ListaMunicipio = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

            if (personaNatural.ID_MCPO_EXPEDICION > 0)
            {
                personaNatural.ListaMunicipioExp = new SelectList(ListasSRV.MunicipioConsultar((int)personaNatural.ID_DEP_EXPEDICION), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaNatural.ID_MCPO_EXPEDICION);
            }
            else personaNatural.ListaMunicipioExp = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

            if (personaNatural.ID_MCPO_RESIDENCIA > 0)
            {
                personaNatural.ListaMunicipioResidencia = new SelectList(ListasSRV.MunicipioConsultar((int)personaNatural.ID_DEP_RESIDENCIA), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaNatural.ID_MCPO_RESIDENCIA);
            }
            else personaNatural.ListaMunicipioResidencia = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");


        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;

            var model = new HandleErrorInfo(filterContext.Exception, "PersonaJuridica", "Action");


            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}