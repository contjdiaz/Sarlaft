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
    public class PersonaNaturalController : Controller
    {
		//Declaración a los llamados a servicios y componentes
		ListasSRV ListasSRV = new ListasSRV();
		ControlExcepciones Exepciones = new ControlExcepciones();
		ConvertirModelViewAModelBDController convertir = new ConvertirModelViewAModelBDController();
		PersonaNaturalSRV pnSrv = new PersonaNaturalSRV();
		PersonaSRV pSrv = new PersonaSRV();
		RelacionadoPepSRV relPepSrv = new RelacionadoPepSRV();
		OperacionSRV OperacionSRV = new OperacionSRV();
        ParametroSRV parametroSRV = new ParametroSRV();
		// GET: Persona
		public ActionResult Index()
        {
            return View();
        }

		// Datos generales de la persona natural		
		public ActionResult PersonaNatural(ValidarIngresoViewModel validar)
		{
			CargarListasViewDatoGenerales();
			PersonaNaturalViewModel p = new PersonaNaturalViewModel();
			PersonaNatural pBD = new PersonaNatural();
			Persona personaDB = new Persona();
	
			if (validar != null && validar.CodigoTipoDocumento != null)
			{
				TipoDocumento tipoDoc = ListasSRV.TipoDocumentoPorCodigoConsultar(validar.CodigoTipoDocumento);
				Int64 idTipoDocumento = tipoDoc.ID_TIPO_DOCUMENTO;			

				pBD = pnSrv.PersonaNaturalPorIdentificacionConsultar(idTipoDocumento, validar.Documento);
				if (pBD != null && pBD.ID_NATURAL > 0)
				{
					p = convertir.ConvertirPersonaNaturalBDModel(pBD);
					personaDB = pSrv.PersonaConsultarPorID(pBD.ID_PERSONA);
					p.ID_TIPO_DOCUMENTO = personaDB.ID_TIPO_DOCUMENTO;
					p.NUMERO_DOCUMENTO = personaDB.NUMERO_DOCUMENTO;
					p.TipoDocumento = tipoDoc.NOMBRE_TIPO_DOCUMENTO;
					p.ID_MUNICIPIO = personaDB.ID_MUNICIPIO;
					p.ID_PERSONA = personaDB.ID_PERSONA;
                    p.TipoDocumento = ListasSRV.TipoDocumentoPorIdConsultar(idTipoDocumento).NOMBRE_TIPO_DOCUMENTO;
                   
                    p.ID_DEPARTMENTO = ListasSRV.DepartamentoPorIdMunicipioConsultar(personaDB.ID_MUNICIPIO).ID_DEPARTAMENTO;
					Session["RelacionadosPEP"] =convertir.ConvertirListaRelacionadoPepBDModel(relPepSrv.RelacionadoPepPorPersonaConsultar(pBD.ID_PERSONA));
					p.RelacionadosPep = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
				}
				else
				{
					p.ID_TIPO_DOCUMENTO = idTipoDocumento;
					p.NUMERO_DOCUMENTO = validar.Documento;
                    p.TipoDocumento = ListasSRV.TipoDocumentoPorIdConsultar(idTipoDocumento).NOMBRE_TIPO_DOCUMENTO;
                }
			}

			CargarDdlCascadas(p);
			return View(p);		
		}

		[HttpPost]
		public ActionResult PersonaNatural(PersonaNaturalViewModel personaNatural, string btnSiguiente)
		{
            
            List<RelacionadoPepViewModel> ListaRelacionadosPEP = new List<RelacionadoPepViewModel>();
            if (Session["RelacionadosPEP"] != null)
            {
                ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
                personaNatural.RelacionadosPep = ListaRelacionadosPEP;
            }

            if ((personaNatural.DECRETO_1674 == 1 || personaNatural.REP_ORG_INTERNACIONAL == 1 || personaNatural.RECONOCIMIENTO_PUB == 1) &&  (personaNatural.RelacionadosPep == null || (personaNatural.RelacionadosPep != null && personaNatural.RelacionadosPep.Count == 0)))
            {              
                ModelState.AddModelError("", "Debe agregar por lo menos un relacionado PEP");
            }
            
            if (ModelState.IsValid)
			{            
                PersonaNatural pn = convertir.ConvertirPersonaNaturalModelBD(personaNatural);				
				Persona personaBD = new Persona();
				if (pn.ID_PERSONA > 0)
				{
					personaBD = pSrv.PersonaConsultarPorID(pn.ID_PERSONA);
				}
				else
				{
					personaBD.ID_TIPO_DOCUMENTO = personaNatural.ID_TIPO_DOCUMENTO;
					personaBD.NUMERO_DOCUMENTO = personaNatural.NUMERO_DOCUMENTO;
					personaBD.ID_MUNICIPIO = personaNatural.ID_MUNICIPIO;
					personaBD.ID_TIPO_PERSONA = personaNatural.ID_TIPO_PERSONA;
				}
				
				try
				{					
					List<RelacionadoPep> ListaRelacionadosPEPBD = convertir.ConvertirListaRelacionadoPepModelBD(ListaRelacionadosPEP);
                  
                    PersonaNatural nuevaPersona= pnSrv.PersonaNaturalInsertar(pn, personaBD, ListaRelacionadosPEPBD);
                    if (nuevaPersona.tipoMensaje != 3)
                    {                        
                        PersonaViewModel persona = new PersonaViewModel();
                        persona = convertir.ConvertirPersonaBDPersonaModel(personaBD);
                        return View("InformacionFinanciera", persona);
                    }
                    else throw new Exception(nuevaPersona.mensajeNotificacion);
				}
				catch (Exception ex)
				{
					//personaNatural.mensajeNotificacion= Exepciones.Exepciones( ex);
				}				
			}
		
			CargarDdlCascadas(personaNatural);
			CargarListasViewDatoGenerales();
			return View(personaNatural);			
		}

		//Datos de persona expuesta
		public ActionResult _PersonaExpuestaPoliticamente()
		{		
			return View();		
		}
	
		//Adicionar Datos de persona expuesta
		public ActionResult AdicionarRelacionadosPEP(RelacionadoPepViewModel relacionadoPEP)
		{
			List<RelacionadoPepViewModel> ListaRelacionadosPEP = new List<RelacionadoPepViewModel>();
			if (Session["RelacionadosPEP"] != null)
			{
				ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
			}
			if (relacionadoPEP != null)
			{
				if (relacionadoPEP.ID_RELACIONADO_PEP == 0)
				{
					Random rnd = new Random();
					relacionadoPEP.ID_RELACIONADO_PEP = rnd.Next(-500, -1);

					if (ListaRelacionadosPEP.Count < 15)
					{
						ListaRelacionadosPEP.Add(relacionadoPEP);
						Session["RelacionadosPEP"] = ListaRelacionadosPEP;
					}
				}
				else
				{
					foreach (RelacionadoPepViewModel relacionadoActualizar in ListaRelacionadosPEP)
					{
						if (relacionadoActualizar.ID_RELACIONADO_PEP == relacionadoPEP.ID_RELACIONADO_PEP)
						{
							relacionadoActualizar.ID_TIPO_DOCUMENTO_RPEP = relacionadoPEP.ID_TIPO_DOCUMENTO_RPEP;
							relacionadoActualizar.ID_TIPO_REL_RPEP = relacionadoPEP.ID_TIPO_REL_RPEP;
							relacionadoActualizar.NOMBRE_ENTIDAD_RPEP = relacionadoPEP.NOMBRE_ENTIDAD_RPEP;
                            relacionadoActualizar.Relacion_RPEP = ListasSRV.TipoRelacionPEPConsultar("PN").Where(r => r.ID_TIPO_REL_PEP == relacionadoPEP.ID_TIPO_REL_RPEP).FirstOrDefault().NOMBRE_TIPO_REL_PEP;
                            relacionadoActualizar.PRIMER_APELLIDO_RPEP = relacionadoPEP.PRIMER_APELLIDO_RPEP;
							relacionadoActualizar.PRIMER_NOMBRE_RPEP = relacionadoPEP.PRIMER_NOMBRE_RPEP;
							relacionadoActualizar.SEGUNDO_APELLIDO_RPEP = relacionadoPEP.SEGUNDO_APELLIDO_RPEP;
							relacionadoActualizar.SEGUNDO_NOMBRE_RPEP = relacionadoPEP.SEGUNDO_NOMBRE_RPEP;
							relacionadoActualizar.CARGO_RPEP = relacionadoPEP.CARGO_RPEP;
							relacionadoActualizar.DOCUMENTO_RPEP = relacionadoPEP.DOCUMENTO_RPEP;
							relacionadoActualizar.FEC_DESVINCULA_RPEP = relacionadoPEP.FEC_DESVINCULA_RPEP != string.Empty? relacionadoPEP.FEC_DESVINCULA_RPEP:string.Empty;
							relacionadoActualizar.FEC_VINCULA_RPEP = relacionadoPEP.FEC_VINCULA_RPEP != string.Empty? relacionadoPEP.FEC_VINCULA_RPEP:string.Empty;							
							break;
						}
					}
					
					Session["RelacionadosPEP"]= ListaRelacionadosPEP;
				}
			}
			return PartialView("_TablaRelacionadosPEP", ListaRelacionadosPEP);
		}

		public ActionResult _TablaRelacionadosPEP(int Id, int Eliminar)
		{
			List<RelacionadoPepViewModel> ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
			if (Eliminar != 0)
			{
				RelacionadoPepViewModel eliminarPep = ListaRelacionadosPEP.Where(e => e.ID_RELACIONADO_PEP == Eliminar).FirstOrDefault();

				if (eliminarPep != null) {
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


		public JsonResult CantidadRelacionadosPEP(int IdPersona)
		{
			List<RelacionadoPepViewModel> ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];		
			ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
			int cantidad = 0;
			if (ListaRelacionadosPEP != null)
			{
				cantidad = ListaRelacionadosPEP.Count;
			}
					
			return Json(cantidad, JsonRequestBehavior.AllowGet);
		}

		public JsonResult ConsultarRelacionadoPEP(int IdRelacionadoPEP)
		{
			List<RelacionadoPepViewModel> ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
			ListaRelacionadosPEP = (List<RelacionadoPepViewModel>)Session["RelacionadosPEP"];
			RelacionadoPepViewModel relacionado = new RelacionadoPepViewModel();
			if (ListaRelacionadosPEP != null)
			{
				relacionado = ListaRelacionadosPEP.Where(r => r.ID_RELACIONADO_PEP == IdRelacionadoPEP).FirstOrDefault();
			}

			List<TipoRelacionPEP> listRelacionPEP = ListasSRV.TipoRelacionPEPConsultar("PN");
			ViewBag.ListRelacionPEP = new SelectList(listRelacionPEP, "ID_TIPO_REL_PEP", "NOMBRE_TIPO_REL_PEP");

			List<TipoDocumento> listTipoIden = ListasSRV.TipoDocumentoConsultar("PN");
			ViewBag.ListaTipoIden = new SelectList(listTipoIden, "ID_TIPO_DOCUMENTO", "NOMBRE_TIPO_DOCUMENTO");

            return Json(relacionado, JsonRequestBehavior.AllowGet);
        }

		//Datos de información financiera
		public ActionResult InformacionFinanciera(PersonaViewModel financiera)
		{			
			return View(financiera);
		}


		//Datos de información financiera
		[HttpPost]
		public ActionResult InformacionFinanciera(PersonaViewModel persona, string btnSiguiente, string btnAnterior)
		{
			if (btnSiguiente != null)
			{
				if (ModelState.IsValid)
				{
					if (persona != null && persona.IdPersonaViewModel > 0)
					{
						Persona personaBD = new Persona();
						personaBD = convertir.ConvertirPersonaModelPersonaBD(persona);
					
						pSrv.PersonaActualizar(personaBD);
						return RedirectToAction("OperacionesInternacionales", "PersonaNatural", personaBD);
					}					
				}
			}
			else if (btnAnterior != null)
			{
				ValidarIngresoViewModel validar = new ValidarIngresoViewModel();
				if (persona != null && persona.ID_TIPO_DOCUMENTO > 0)
				{
					TipoDocumento tipoDoc = ListasSRV.TipoDocumentoConsultar("PN").Where(d => d.ID_TIPO_DOCUMENTO == persona.ID_TIPO_DOCUMENTO).FirstOrDefault();
					validar.Documento = persona.NUMERO_DOCUMENTO;
					validar.CodigoTipoDocumento = tipoDoc.CODIGO;
				}
				
				return RedirectToAction("PersonaNatural", "PersonaNatural", validar);
			}

			return View(persona);
		}

		public ActionResult OperacionesInternacionales(Persona p)
		{
			var model = new OperacionPadreViewModel();
            CargarViewBagOperacionesInternacionales();
            model.MonedaExtranjera = string.Empty;
            if (p != null && p.ID_PERSONA > 0)
			{                
                model.ID_PERSONA = p.ID_PERSONA;                
			}

			return View(model);
		}
		
		//Datos de operaciones internacionales
		[HttpPost]
		public ActionResult OperacionesInternacionales(string btnSiguiente, string btnAnterior, OperacionPadreViewModel	p)
		{
            CargarViewBagOperacionesInternacionales();

            if (btnSiguiente != null)
			{
				if (p.ID_PERSONA > 0)
				{
                    if (p.MonedaExtranjera == "1")
                    {
                        List<Operacion> lista =  OperacionSRV.PersonaConsultar(Convert.ToInt64(p.ID_PERSONA));
                        if (lista != null && lista.Count == 0)
                        {
                            ModelState.AddModelError("", "Debe agregar por lo menos una operación internacional");
                            p.mensajeNotificacion = "Debe agregar por lo menos una operación internacional";
                        }                        
                    }

                    if(ModelState.IsValid)
                    { 
					    Persona persona = new Persona();
					    persona = pSrv.PersonaConsultarPorID(p.ID_PERSONA);
					    return RedirectToAction("AceptacionTerminos", "PersonaNatural", convertir.ConvertirPersonaBDPersonaModel(persona));
                    }
                }
			}
			else if (btnAnterior != null)
			{		

				if (p != null && p.ID_PERSONA > 0)
				{
					Persona persona = pSrv.PersonaConsultarPorID(p.ID_PERSONA);
					if (persona != null && persona.ID_PERSONA > 0)
					{
						PersonaViewModel financiera = new PersonaViewModel();
						financiera = convertir.ConvertirPersonaBDPersonaModel(persona);
						return RedirectToAction("InformacionFinanciera", "PersonaNatural", financiera);
					}
				}
			}

			return View(p);
		}

		public ActionResult _AgregarOperacion(int? IdPersona)
		{
			var model = new OpercacionViewModel();
			List<TipoOperacion> listTipoOperaciones = ListasSRV.TipoOperacionConsultar();
			List<TipoMoneda> lisTipoMoneda = ListasSRV.TipoMonedaConsultar();

			ViewBag.ListTipoOperaciones = new SelectList(listTipoOperaciones, "ID_TIPO_OPERACION", "NOMBRE_TIPO_OPERACION");
			ViewBag.LisTipoMoneda = new SelectList(lisTipoMoneda, "ID_TIPO_MONEDA", "NOMBRE_TIPO_MONEDA");
			return PartialView("_AdicionarDatosOperacionesInternacionales", model);
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
		
		public ActionResult AceptacionTerminos(PersonaViewModel p)
		{
            p.ClausulaAutorizacion = parametroSRV.ParametroPorCodigoConsultar("ClausulaAutorizacion").DESCRIPCION_PARAMETRO;
            p.DeclaracionOrigen = parametroSRV.ParametroPorCodigoConsultar("DeclaracionOrigen").DESCRIPCION_PARAMETRO;
            return View(p);
		}

		[HttpPost]
		public ActionResult AceptacionTerminos(string btnImprimir, string btnAnterior, PersonaViewModel p)
		{
			Persona persona = new Persona();
			if (btnImprimir != null)
			{
				if (ModelState.IsValid)
				{
					persona = convertir.ConvertirPersonaModelPersonaBD(p);
					pSrv.PersonaActualizar(persona);
					return RedirectToAction("PersonaNatural", "Impresion", new { Id = p.IdPersonaViewModel });
				}
			}

			if (btnImprimir == null && btnAnterior == null)
			{
				if (ModelState.IsValid)
				{				
					persona = convertir.ConvertirPersonaModelPersonaBD(p);
					pSrv.PersonaActualizar(persona);
					return View(p);
				}				
			}

			if (btnAnterior != null)
			{
				Persona pBd = convertir.ConvertirPersonaModelPersonaBD(p);
				return RedirectToAction("OperacionesInternacionales", "PersonaNatural", pBd);
			}

			return View(p);
		}

		/// <summary>
		/// Obtener un listado de tipo de documentos según el tipo de persona
		/// </summary>
		/// <param name="departamentoId"></param>
		/// <returns>Listdo de los documentos en formato JSON</returns>
		[HttpPost]
		public JsonResult CodigoCiiuPorActividadConsultar(int actividadId)
		{
			try
			{
				List<CodigoCiiu> ListaCodigoCiiu = ListasSRV.CodigoCiiuPorActividadConsultar(actividadId);
				return Json(new SelectList(ListaCodigoCiiu, "ID_CODIGO_CIIU", "CIIU"), JsonRequestBehavior.AllowGet);
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
			List<ActividadEconomica> listActEconomica = ListasSRV.ActividadEconomicaConsultar();
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
			ViewBag.ListActEconomica = new SelectList(listActEconomica, "ID_ACTIVIDAD_ECONOMICA", "NOMBRE_ACTIVIDAD_ECONOMICA");
			ViewBag.ListProfesion = new SelectList(listProfesion, "ID_PROFESION", "NOMBRE_PROFESION");
			ViewBag.ListEstadoCivil = new SelectList(listEstadoCivil, "ID_ESTADO_CIVIL", "NOMBRE_ESTADO_CIVIL");
			ViewBag.ListaDepartamento = new SelectList(listaDepartamento, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO");				
		}

		public void CargarDdlCascadas(PersonaNaturalViewModel personaNatural)
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

			if (personaNatural.ID_MCPO_EMPRESA > 0)
			{
				personaNatural.ListaMunicipioEmpresa = new SelectList(ListasSRV.MunicipioConsultar((int)personaNatural.ID_DEP_EMPRESA), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO", personaNatural.ID_MCPO_EMPRESA);
			}
			else personaNatural.ListaMunicipioEmpresa = new SelectList(listaMunicipio, "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

			if (personaNatural.ID_CODIGO_CIIU > 0)
			{
				personaNatural.ListaoCodigoCiiu = new SelectList(ListasSRV.CodigoCiiuPorActividadConsultar((int)personaNatural.ID_ACT_ECONOMICA), "ID_CODIGO_CIIU", "CIIU", personaNatural.ID_CODIGO_CIIU);
			}
			else personaNatural.ListaoCodigoCiiu = new SelectList(listaCodCiuu, "ID_CODIGO_CIIU", "CIIU");
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;

            var model = new HandleErrorInfo(filterContext.Exception, "PersonaNatural", "Action");


            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}