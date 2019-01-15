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
    public class ConvertirModelViewAModelBDController : Controller
    {
        ListasSRV listaSrv = new ListasSRV();
        PersonaSRV pSrv = new PersonaSRV();
        // GET: ConvertirModelViewAModelBD
        public ActionResult Index()
        {
            return View();
        }

        public RelacionadoPepViewModel ConvertirRelacionadoPePViewModel(RelacionadoPep relacionado)
        {
            RelacionadoPepViewModel relacionadoViewModel = new RelacionadoPepViewModel();
            relacionadoViewModel.CARGO_RPEP = relacionado.ID_CARGO_PEP.ToString();
            relacionadoViewModel.DOCUMENTO_RPEP = relacionado.DOCUMENTO;

            if (relacionado.FEC_VINCULA != null && relacionado.FEC_VINCULA.Value.ToShortDateString() != "1/01/0001")
            {
                relacionadoViewModel.FEC_VINCULA_RPEP = Convert.ToDateTime(relacionado.FEC_VINCULA.ToString()).ToShortDateString();

            }
            if (relacionado.FEC_DESVINCULA != null && relacionado.FEC_DESVINCULA.Value.ToShortDateString() != "1/01/0001")
            {
                relacionadoViewModel.FEC_DESVINCULA_RPEP = Convert.ToDateTime(relacionado.FEC_DESVINCULA.ToString()).ToShortDateString();
                DateTime fecha = Convert.ToDateTime(relacionado.FEC_DESVINCULA.ToString());
                fecha = fecha.AddYears(2);
                relacionadoViewModel.FEC_DESVINCULA_CARGO_RPEP = fecha.ToShortDateString();
            }
            relacionadoViewModel.ID_RELACIONADO_PEP = relacionado.ID_RELACIONADO_PEP;
            relacionadoViewModel.ID_PERSONA_RPEP = relacionado.ID_PERSONA;
            relacionadoViewModel.ID_TIPO_DOCUMENTO_RPEP = relacionado.ID_TIPO_DOCUMENTO;
            relacionadoViewModel.ID_TIPO_REL_RPEP = relacionado.ID_TIPO_REL_PEP;
            relacionadoViewModel.NOMBRE_ENTIDAD_RPEP = relacionado.NOMBRE_ENTIDAD;
            relacionadoViewModel.PRIMER_NOMBRE_RPEP = relacionado.PRIMER_NOMBRE;
            relacionadoViewModel.PRIMER_APELLIDO_RPEP = relacionado.PRIMER_APELLIDO;
            relacionadoViewModel.SEGUNDO_APELLIDO_RPEP = relacionado.SEGUNDO_APELLIDO;
            relacionadoViewModel.SEGUNDO_NOMBRE_RPEP = relacionado.SEGUNDO_NOMBRE;
            return relacionadoViewModel;
        }

        public PersonaNatural ConvertirRepresentanteLegalModelBD(RepresentanteLegalViewModel pnViewModel)
        {
            PersonaNatural pn = new PersonaNatural();
            Persona persona = new Persona();
            pn.ID_PERSONA = pnViewModel.ID_PERSONA;
            pn.ID_NATURAL = pnViewModel.ID_NATURAL;
            pn.CELULAR = pnViewModel.CELULAR;
            pn.CELULAR_EMPRESA = "";
            pn.CORREO = pnViewModel.CORREO;
            pn.DECRETO_1674 = pnViewModel.DECRETO_1674;
            pn.DEPENDENCIA = "";
            pn.DIRECCION_EMPRESA = "";
            pn.DIR_RESIDENCIA = pnViewModel.DIR_RESIDENCIA;
            pn.ID_MCPO_RESIDENCIA = pnViewModel.ID_MCPO_RESIDENCIA;
            pn.NOMBRE_EMPRESA = "";
            pn.ENTIDAD_PEP = pnViewModel.ENTIDAD_PEP;

            pn.EXTENSION_EMPRESA = pnViewModel.EXTENSION_EMPRESA;
            pn.FAX_EMPRESA = pnViewModel.FAX_EMPRESA;
            if (pnViewModel.FEC_DESVINCULA_PEP != string.Empty)
            {
                pn.FEC_DESVINCULA_PEP = Convert.ToDateTime(pnViewModel.FEC_DESVINCULA_PEP);
            }

            pn.FEC_EXPEDICION = Convert.ToDateTime(pnViewModel.FEC_EXPEDICION);
            pn.FEC_NACIMIENTO = Convert.ToDateTime(pnViewModel.FEC_NACIMIENTO);
            if (pnViewModel.FEC_VINCULA_PEP != string.Empty)
            {
                pn.FEC_VINCULA_PEP = Convert.ToDateTime(pnViewModel.FEC_VINCULA_PEP);
            }
            if (pnViewModel.ID_CARGO_PEP != null)
            {
                pn.ID_CARGO_PEP = (Int64)pnViewModel.ID_CARGO_PEP;
            }


            pn.ID_ESTADO_CIVIL = pnViewModel.ID_ESTADO_CIVIL;
            pn.ID_MCPO_EXPEDICION = pnViewModel.ID_MCPO_EXPEDICION;
            pn.ID_MCPO_NACIMIENTO = pnViewModel.ID_MCPO_NACIMIENTO;
            pn.ID_SEXO = pnViewModel.ID_SEXO;
            pn.PRIMER_APELLIDO = pnViewModel.PRIMER_APELLIDO;
            pn.PRIMER_NOMBRE = pnViewModel.PRIMER_NOMBRE;
            pn.RECONOCIMIENTO_PUB = pnViewModel.RECONOCIMIENTO_PUB;
            pn.REP_ORG_INTERNACIONAL = pnViewModel.REP_ORG_INTERNACIONAL;
            pn.SEGUNDO_APELLIDO = pnViewModel.SEGUNDO_APELLIDO;
            pn.SEGUNDO_NOMBRE = pnViewModel.SEGUNDO_NOMBRE;
            pn.TELEFONO = pnViewModel.TELEFONO;
            pn.TELEFONO_EMPRESA = pnViewModel.TELEFONO_EMPRESA;
            pn.TEL_RESIDENCIA = pnViewModel.TEL_RESIDENCIA;
            pn.VINCULO_PEP = pnViewModel.VINCULO_PEP;

            return pn;
        }

        public PersonaNatural ConvertirPersonaNaturalModelBD(PersonaNaturalViewModel pnViewModel)
        {
            PersonaNatural pn = new PersonaNatural();
            Persona persona = new Persona();
            pn.CARGO = pnViewModel.CARGO;
            pn.ID_PERSONA = pnViewModel.ID_PERSONA;
            pn.ID_NATURAL = pnViewModel.ID_NATURAL;
            pn.CELULAR = pnViewModel.CELULAR;
            pn.CELULAR_EMPRESA = pnViewModel.CELULAR_EMPRESA;
            pn.CORREO = pnViewModel.CORREO;
            pn.DECRETO_1674 = pnViewModel.DECRETO_1674;
            pn.DEPENDENCIA = pnViewModel.DEPENDENCIA;
            pn.DIRECCION_EMPRESA = pnViewModel.DIRECCION_EMPRESA;
            pn.DIR_RESIDENCIA = pnViewModel.DIR_RESIDENCIA;
            pn.ID_MCPO_RESIDENCIA = pnViewModel.ID_MCPO_RESIDENCIA;
            pn.NOMBRE_EMPRESA = pnViewModel.NOMBRE_EMPRESA;
            pn.ENTIDAD_PEP = pnViewModel.ENTIDAD_PEP;

            pn.EXTENSION_EMPRESA = pnViewModel.EXTENSION_EMPRESA;
            pn.FAX_EMPRESA = pnViewModel.FAX_EMPRESA;
            if (pnViewModel.FEC_DESVINCULA_PEP != string.Empty)
            {
                pn.FEC_DESVINCULA_PEP = Convert.ToDateTime(pnViewModel.FEC_DESVINCULA_PEP);
            }

            pn.FEC_EXPEDICION = Convert.ToDateTime(pnViewModel.FEC_EXPEDICION);
            pn.FEC_NACIMIENTO = Convert.ToDateTime(pnViewModel.FEC_NACIMIENTO);
            if (pnViewModel.FEC_VINCULA_PEP != string.Empty)
            {
                pn.FEC_VINCULA_PEP = Convert.ToDateTime(pnViewModel.FEC_VINCULA_PEP);
            }
            if (pnViewModel.ID_CARGO_PEP != null)
            {
                pn.ID_CARGO_PEP = (Int64)pnViewModel.ID_CARGO_PEP;
            }

            pn.ID_CODIGO_CIIU = pnViewModel.ID_CODIGO_CIIU;
            pn.ID_ESTADO_CIVIL = pnViewModel.ID_ESTADO_CIVIL;
            pn.ID_MCPO_EMPRESA = pnViewModel.ID_MCPO_EMPRESA;
            pn.ID_MCPO_EXPEDICION = pnViewModel.ID_MCPO_EXPEDICION;
            pn.ID_MCPO_NACIMIENTO = pnViewModel.ID_MCPO_NACIMIENTO;
            pn.ID_PROFESION = pnViewModel.ID_PROFESION;
            pn.ID_SEXO = pnViewModel.ID_SEXO;
            pn.ID_TIPO_EMPRESA = pnViewModel.ID_TIPO_EMPRESA;
            pn.NOMBRE_EMPRESA = pnViewModel.NOMBRE_EMPRESA;
            pn.PRIMER_APELLIDO = pnViewModel.PRIMER_APELLIDO;
            pn.PRIMER_NOMBRE = pnViewModel.PRIMER_NOMBRE;
            pn.RECONOCIMIENTO_PUB = pnViewModel.RECONOCIMIENTO_PUB;
            pn.REP_ORG_INTERNACIONAL = pnViewModel.REP_ORG_INTERNACIONAL;
            pn.SEGUNDO_APELLIDO = pnViewModel.SEGUNDO_APELLIDO;
            pn.SEGUNDO_NOMBRE = pnViewModel.SEGUNDO_NOMBRE;
            pn.TELEFONO = pnViewModel.TELEFONO;
            pn.TELEFONO_EMPRESA = pnViewModel.TELEFONO_EMPRESA;
            pn.TEL_RESIDENCIA = pnViewModel.TEL_RESIDENCIA;
            pn.VINCULO_PEP = pnViewModel.VINCULO_PEP;

            return pn;
        }



        public PersonaJuridica ConvertirPersonaJuridicaModelBD(PersonaJuridicaViewModel pjViewModel)
        {
            PersonaJuridica pj = new PersonaJuridica();

            pj.ID_PERSONA = pjViewModel.ID_PERSONA;
            pj.ID_JURIDICA = pjViewModel.ID_JURIDICA;
            pj.CORREO = pjViewModel.CORREO;
            pj.CORREO_SUCURSAL = pjViewModel.CORREO_SUCURSAL;
            pj.DIRECCION = pjViewModel.DIRECCION;
            pj.DIR_SUCURSAL = pjViewModel.DIR_SUCURSAL;
            pj.EXTENSION = pjViewModel.EXTENSION;
            pj.EXT_SUCURSAL = pjViewModel.EXT_SUCURSAL;
            pj.FAX = pjViewModel.FAX;
            pj.FAX_SUCURSAL = pjViewModel.FAX_SUCURSAL;
            pj.ID_CODIGO_CIIU = pjViewModel.ID_CODIGO_CIIU;
            if (!String.IsNullOrEmpty(pjViewModel.ID_MCPO_SUCURSAL))
                pj.ID_MCPO_SUCURSAL = Convert.ToInt64(pjViewModel.ID_MCPO_SUCURSAL);
            pj.ID_MUNICIPIO = pjViewModel.ID_MUNICIPIO_JURIDICA;
            pj.ID_REP_LEGAL = pjViewModel.ID_REP_LEGAL;
            pj.ID_TIPO_EMPRESA = pjViewModel.ID_TIPO_EMPRESA;
            pj.RAZON_SOCIAL = pjViewModel.RAZON_SOCIAL;
            pj.TELEFONO = pjViewModel.TELEFONO;
            pj.TEL_SUCURSAL = pjViewModel.TEL_SUCURSAL;
            return pj;
        }

        public PersonaNaturalViewModel ConvertirPersonaNaturalBDModel(PersonaNatural pn)
        {
            PersonaNaturalViewModel pnViewModel = new PersonaNaturalViewModel();
            pnViewModel.ID_NATURAL = pn.ID_NATURAL;
            pnViewModel.ID_PERSONA = pn.ID_PERSONA;
            pnViewModel.CARGO = pn.CARGO;
            pnViewModel.CELULAR = pn.CELULAR;
            pnViewModel.CELULAR_EMPRESA = pn.CELULAR_EMPRESA;
            pnViewModel.CORREO = pn.CORREO;
            pnViewModel.DECRETO_1674 = pn.DECRETO_1674;
            pnViewModel.DEPENDENCIA = pn.DEPENDENCIA;
            pnViewModel.DIRECCION_EMPRESA = pn.DIRECCION_EMPRESA;
            pnViewModel.DIR_RESIDENCIA = pn.DIR_RESIDENCIA;
            pnViewModel.ID_MCPO_RESIDENCIA = pn.ID_MCPO_RESIDENCIA;
            pnViewModel.ID_DEP_RESIDENCIA = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_RESIDENCIA).ID_DEPARTAMENTO;
            pnViewModel.NOMBRE_EMPRESA = pn.NOMBRE_EMPRESA;
            pnViewModel.ENTIDAD_PEP = pn.ENTIDAD_PEP;
            pnViewModel.EXTENSION_EMPRESA = pn.EXTENSION_EMPRESA;
            pnViewModel.FAX_EMPRESA = pn.FAX_EMPRESA;
            pnViewModel.FEC_EXPEDICION = pn.FEC_EXPEDICION.ToShortDateString();
            pnViewModel.FEC_NACIMIENTO = pn.FEC_NACIMIENTO.ToShortDateString();
            if (pn.FEC_VINCULA_PEP != null && pn.FEC_VINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
            {
                pnViewModel.FEC_VINCULA_PEP = Convert.ToDateTime(pn.FEC_VINCULA_PEP.ToString()).ToShortDateString();

            }
            if (pn.FEC_DESVINCULA_PEP != null && pn.FEC_DESVINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
            {
                pnViewModel.FEC_DESVINCULA_PEP = Convert.ToDateTime(pn.FEC_DESVINCULA_PEP.ToString()).ToShortDateString();
            }

            pnViewModel.ID_CARGO_PEP = pn.ID_CARGO_PEP;
            pnViewModel.ID_CODIGO_CIIU = pn.ID_CODIGO_CIIU;
            if (pn.ID_CODIGO_CIIU > 0)
                pnViewModel.ID_ACT_ECONOMICA = listaSrv.ActividadEconomicaPorCodigoCiiuConsultar(pn.ID_CODIGO_CIIU).ID_ACTIVIDAD_ECONOMICA;
            pnViewModel.ID_ESTADO_CIVIL = pn.ID_ESTADO_CIVIL;
            pnViewModel.ID_MCPO_EMPRESA = pn.ID_MCPO_EMPRESA;
            pnViewModel.ID_DEP_EMPRESA = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_EMPRESA).ID_DEPARTAMENTO;
            pnViewModel.ID_MCPO_EXPEDICION = pn.ID_MCPO_EXPEDICION;
            pnViewModel.ID_DEP_EXPEDICION = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_EXPEDICION).ID_DEPARTAMENTO;
            pnViewModel.ID_MCPO_NACIMIENTO = pn.ID_MCPO_NACIMIENTO;
            pnViewModel.ID_DEP_NACIMIENTO = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_NACIMIENTO).ID_DEPARTAMENTO;
            pnViewModel.ID_PROFESION = pn.ID_PROFESION;
            pnViewModel.ID_SEXO = pn.ID_SEXO;
            pnViewModel.ID_TIPO_EMPRESA = pn.ID_TIPO_EMPRESA;
            pnViewModel.NOMBRE_EMPRESA = pn.NOMBRE_EMPRESA;
            pnViewModel.PRIMER_APELLIDO = pn.PRIMER_APELLIDO;
            pnViewModel.PRIMER_NOMBRE = pn.PRIMER_NOMBRE;
            pnViewModel.RECONOCIMIENTO_PUB = pn.RECONOCIMIENTO_PUB;
            pnViewModel.REP_ORG_INTERNACIONAL = pn.REP_ORG_INTERNACIONAL;
            pnViewModel.SEGUNDO_APELLIDO = pn.SEGUNDO_APELLIDO;
            pnViewModel.SEGUNDO_NOMBRE = pn.SEGUNDO_NOMBRE;
            pnViewModel.TELEFONO = pn.TELEFONO;
            pnViewModel.TELEFONO_EMPRESA = pn.TELEFONO_EMPRESA;
            pnViewModel.TEL_RESIDENCIA = pn.TEL_RESIDENCIA;
            pnViewModel.VINCULO_PEP = pn.VINCULO_PEP;

            return pnViewModel;
        }

        public RepresentanteLegalViewModel ConvertirRepresentanteLegalBDModel(PersonaNatural pn)
        {
            RepresentanteLegalViewModel pnViewModel = new RepresentanteLegalViewModel();
            pnViewModel.ID_NATURAL = pn.ID_NATURAL;
            pnViewModel.ID_PERSONA = pn.ID_PERSONA;
            pnViewModel.CELULAR = pn.CELULAR;
            pnViewModel.CORREO = pn.CORREO;
            pnViewModel.DECRETO_1674 = pn.DECRETO_1674;
            pnViewModel.DIR_RESIDENCIA = pn.DIR_RESIDENCIA;
            pnViewModel.ID_MCPO_RESIDENCIA = pn.ID_MCPO_RESIDENCIA;
            pnViewModel.ID_DEP_RESIDENCIA = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_RESIDENCIA).ID_DEPARTAMENTO;
            pnViewModel.ENTIDAD_PEP = pn.ENTIDAD_PEP;
            pnViewModel.EXTENSION_EMPRESA = pn.EXTENSION_EMPRESA;
            pnViewModel.FAX_EMPRESA = pn.FAX_EMPRESA;
            pnViewModel.FEC_EXPEDICION = pn.FEC_EXPEDICION.ToShortDateString();
            pnViewModel.FEC_NACIMIENTO = pn.FEC_NACIMIENTO.ToShortDateString();
            if (pn.FEC_VINCULA_PEP != null && pn.FEC_VINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
            {
                pnViewModel.FEC_VINCULA_PEP = Convert.ToDateTime(pn.FEC_VINCULA_PEP.ToString()).ToShortDateString();
            }
            if (pn.FEC_DESVINCULA_PEP != null && pn.FEC_DESVINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
            {
                pnViewModel.FEC_DESVINCULA_PEP = Convert.ToDateTime(pn.FEC_DESVINCULA_PEP.ToString()).ToShortDateString();
            }

            pnViewModel.ID_CARGO_PEP = pn.ID_CARGO_PEP;
            pnViewModel.ID_ESTADO_CIVIL = pn.ID_ESTADO_CIVIL;
            pnViewModel.ID_MCPO_EXPEDICION = pn.ID_MCPO_EXPEDICION;
            pnViewModel.ID_DEP_EXPEDICION = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_EXPEDICION).ID_DEPARTAMENTO;
            pnViewModel.ID_MCPO_NACIMIENTO = pn.ID_MCPO_NACIMIENTO;
            pnViewModel.ID_DEP_NACIMIENTO = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_NACIMIENTO).ID_DEPARTAMENTO;
            pnViewModel.ID_SEXO = pn.ID_SEXO;
            pnViewModel.PRIMER_APELLIDO = pn.PRIMER_APELLIDO;
            pnViewModel.PRIMER_NOMBRE = pn.PRIMER_NOMBRE;
            pnViewModel.RECONOCIMIENTO_PUB = pn.RECONOCIMIENTO_PUB;
            pnViewModel.REP_ORG_INTERNACIONAL = pn.REP_ORG_INTERNACIONAL;
            pnViewModel.SEGUNDO_APELLIDO = pn.SEGUNDO_APELLIDO;
            pnViewModel.SEGUNDO_NOMBRE = pn.SEGUNDO_NOMBRE;
            pnViewModel.TELEFONO = pn.TELEFONO;
            pnViewModel.TELEFONO_EMPRESA = pn.TELEFONO_EMPRESA;
            pnViewModel.TEL_RESIDENCIA = pn.TEL_RESIDENCIA;
            pnViewModel.VINCULO_PEP = pn.VINCULO_PEP;

            return pnViewModel;
        }

        public PersonaJuridicaViewModel ConvertirPersonaJuridicaBDModel(PersonaJuridica pj)
        {
            PersonaJuridicaViewModel pjViewModel = new PersonaJuridicaViewModel();

            pjViewModel.CORREO = pj.CORREO;
            pjViewModel.CORREO_SUCURSAL = pj.CORREO_SUCURSAL;
            pjViewModel.DIRECCION = pj.DIRECCION;
            pjViewModel.DIR_SUCURSAL = pj.DIR_SUCURSAL;
            pjViewModel.EXTENSION = pj.EXTENSION;
            pjViewModel.EXT_SUCURSAL = pj.EXT_SUCURSAL;
            pjViewModel.FAX = pj.FAX;
            pjViewModel.FAX_SUCURSAL = pj.FAX_SUCURSAL;
            pjViewModel.ID_CODIGO_CIIU = pj.ID_CODIGO_CIIU;
            pjViewModel.ID_ACT_ECONOMICA = listaSrv.ActividadEconomicaPorCodigoCiiuConsultar(pj.ID_CODIGO_CIIU).ID_ACTIVIDAD_ECONOMICA;
            pjViewModel.ID_JURIDICA = pj.ID_JURIDICA;
            if (pj.ID_MCPO_SUCURSAL != null && pj.ID_MCPO_SUCURSAL > 0)
                pjViewModel.ID_DEPTO_SUCURSAL = listaSrv.DepartamentoPorIdMunicipioConsultar(Convert.ToInt64(pj.ID_MCPO_SUCURSAL)).ID_DEPARTAMENTO.ToString();
            pjViewModel.ID_MCPO_SUCURSAL = pj.ID_MCPO_SUCURSAL.HasValue ? pj.ID_MCPO_SUCURSAL.Value.ToString() : string.Empty;
            pjViewModel.ID_DEPTO_JURIDICA = listaSrv.DepartamentoPorIdMunicipioConsultar(pj.ID_MUNICIPIO).ID_DEPARTAMENTO;
            pjViewModel.ID_MUNICIPIO_JURIDICA = pj.ID_MUNICIPIO;
            pjViewModel.ID_PERSONA = pj.ID_PERSONA;
            pjViewModel.ID_REP_LEGAL = pj.ID_REP_LEGAL;
            pjViewModel.ID_TIPO_EMPRESA = pj.ID_TIPO_EMPRESA;
            pjViewModel.RAZON_SOCIAL = pj.RAZON_SOCIAL;
            pjViewModel.TELEFONO = pj.TELEFONO;
            pjViewModel.TEL_SUCURSAL = pj.TEL_SUCURSAL;
            return pjViewModel;
        }

        public List<RelacionadoPep> ConvertirListaRelacionadoPepModelBD(List<RelacionadoPepViewModel> listaModel)
        {
            List<RelacionadoPep> listaBD = new List<RelacionadoPep>();
            if (listaModel != null && listaModel.Count > 0)
            {
                foreach (RelacionadoPepViewModel item in listaModel)
                {
                    RelacionadoPep relPepBD = new RelacionadoPep();
                    relPepBD.CARGO = item.CARGO_RPEP;
                    relPepBD.DOCUMENTO = item.DOCUMENTO_RPEP;
                    if (item.FEC_DESVINCULA_RPEP != string.Empty)
                    {
                        relPepBD.FEC_DESVINCULA = Convert.ToDateTime(item.FEC_DESVINCULA_RPEP);
                    }
                    if (item.FEC_VINCULA_RPEP != string.Empty)
                    {
                        relPepBD.FEC_VINCULA = Convert.ToDateTime(item.FEC_VINCULA_RPEP);
                    }
                    relPepBD.ID_PERSONA = item.ID_PERSONA_RPEP;
                    relPepBD.ID_RELACIONADO_PEP = item.ID_RELACIONADO_PEP;
                    relPepBD.ID_TIPO_DOCUMENTO = item.ID_TIPO_DOCUMENTO_RPEP;
                    relPepBD.ID_TIPO_REL_PEP = item.ID_TIPO_REL_RPEP;
                    relPepBD.NOMBRE_ENTIDAD = item.NOMBRE_ENTIDAD_RPEP;
                    relPepBD.PRIMER_APELLIDO = item.PRIMER_APELLIDO_RPEP;
                    relPepBD.PRIMER_NOMBRE = item.PRIMER_NOMBRE_RPEP;
                    relPepBD.SEGUNDO_APELLIDO = item.SEGUNDO_APELLIDO_RPEP;
                    relPepBD.SEGUNDO_NOMBRE = item.SEGUNDO_NOMBRE_RPEP;
                    relPepBD.CARGO = item.CARGO_RPEP;
                    listaBD.Add(relPepBD);
                }
            }

            return listaBD;
        }


        public List<RelacionadoPepViewModel> ConvertirListaRelacionadoPepBDModel(List<RelacionadoPep> listaBD)
        {
            List<RelacionadoPepViewModel> listaModel = new List<RelacionadoPepViewModel>();
            if (listaBD != null && listaBD.Count > 0)
            {
                foreach (RelacionadoPep item in listaBD)
                {
                    RelacionadoPepViewModel relPepModel = new RelacionadoPepViewModel();
                    relPepModel.CARGO_RPEP = item.CARGO;
                    relPepModel.DOCUMENTO_RPEP = item.DOCUMENTO;
                    if (item.FEC_DESVINCULA != null && item.FEC_DESVINCULA != Convert.ToDateTime("1/01/0001 12:00:00 a. m."))
                    {
                        relPepModel.FEC_DESVINCULA_RPEP = Convert.ToDateTime(item.FEC_DESVINCULA).ToShortDateString();
                    }
                    else relPepModel.FEC_DESVINCULA_RPEP = string.Empty;

                    if (item.FEC_VINCULA != null && item.FEC_DESVINCULA != Convert.ToDateTime("1/01/0001 12:00:00 a. m."))
                    {
                        relPepModel.FEC_VINCULA_RPEP = Convert.ToDateTime(item.FEC_VINCULA).ToShortDateString();
                    }
                    else relPepModel.FEC_VINCULA_RPEP = string.Empty;

                    relPepModel.ID_PERSONA_RPEP = item.ID_PERSONA;
                    relPepModel.ID_RELACIONADO_PEP = item.ID_RELACIONADO_PEP;
                    relPepModel.ID_TIPO_DOCUMENTO_RPEP = item.ID_TIPO_DOCUMENTO;
                    relPepModel.ID_TIPO_REL_RPEP = item.ID_TIPO_REL_PEP;
                    relPepModel.NOMBRE_ENTIDAD_RPEP = item.NOMBRE_ENTIDAD;
                    relPepModel.PRIMER_APELLIDO_RPEP = item.PRIMER_APELLIDO;
                    relPepModel.PRIMER_NOMBRE_RPEP = item.PRIMER_NOMBRE;
                    relPepModel.SEGUNDO_APELLIDO_RPEP = item.SEGUNDO_APELLIDO;
                    relPepModel.SEGUNDO_NOMBRE_RPEP = item.SEGUNDO_NOMBRE;
                    relPepModel.CARGO_RPEP = item.CARGO;
                    relPepModel.Relacion_RPEP = listaSrv.TipoRelacionPEPConsultar("PN").Where(r => r.ID_TIPO_REL_PEP == item.ID_TIPO_REL_PEP).FirstOrDefault().NOMBRE_TIPO_REL_PEP;
                    relPepModel.TipoDocumento_RPEP = listaSrv.TipoDocumentoConsultar("PN").Where(r => r.ID_TIPO_DOCUMENTO == item.ID_TIPO_DOCUMENTO).FirstOrDefault().NOMBRE_TIPO_DOCUMENTO;
                    listaModel.Add(relPepModel);
                }
            }

            return listaModel;
        }

        public List<RelacionadoPepViewModel> ConvertirListaAdministradorpModelBD(List<RelacionadoPep> listaBD)
        {
            List<RelacionadoPepViewModel> listaModel = new List<RelacionadoPepViewModel>();
            if (listaBD != null && listaBD.Count > 0)
            {
                foreach (RelacionadoPep item in listaBD)
                {
                    RelacionadoPepViewModel relPepModel = new RelacionadoPepViewModel();
                    relPepModel.CARGO_RPEP = item.CARGO;
                    relPepModel.DOCUMENTO_RPEP = item.DOCUMENTO;
                    if (item.FEC_DESVINCULA != null)
                    {
                        relPepModel.FEC_DESVINCULA_RPEP = item.FEC_DESVINCULA.ToString();
                    }
                    if (item.FEC_VINCULA != null)
                    {
                        relPepModel.FEC_VINCULA_RPEP = item.FEC_VINCULA.ToString();
                    }
                    relPepModel.ID_PERSONA_RPEP = item.ID_PERSONA;
                    relPepModel.ID_RELACIONADO_PEP = item.ID_RELACIONADO_PEP;
                    relPepModel.ID_TIPO_DOCUMENTO_RPEP = item.ID_TIPO_DOCUMENTO;
                    relPepModel.ID_TIPO_REL_RPEP = item.ID_TIPO_REL_PEP;
                    relPepModel.NOMBRE_ENTIDAD_RPEP = item.NOMBRE_ENTIDAD;
                    relPepModel.PRIMER_APELLIDO_RPEP = item.PRIMER_APELLIDO;
                    relPepModel.PRIMER_NOMBRE_RPEP = item.PRIMER_NOMBRE;
                    relPepModel.SEGUNDO_APELLIDO_RPEP = item.SEGUNDO_APELLIDO;
                    relPepModel.SEGUNDO_NOMBRE_RPEP = item.SEGUNDO_NOMBRE;
                    relPepModel.CARGO_RPEP = listaSrv.CargoConsultar().Where(r => r.ID_CARGO_PEP == item.ID_CARGO_PEP).FirstOrDefault().NOMBRE_CARGO_PEP;
                    relPepModel.Relacion_RPEP = listaSrv.TipoRelacionPEPConsultar("PJ").Where(r => r.ID_TIPO_REL_PEP == item.ID_TIPO_REL_PEP).FirstOrDefault().NOMBRE_TIPO_REL_PEP;
                    relPepModel.TipoDocumento_RPEP = listaSrv.TipoDocumentoConsultar("PN").Where(r => r.ID_TIPO_DOCUMENTO == item.ID_TIPO_DOCUMENTO).FirstOrDefault().NOMBRE_TIPO_DOCUMENTO;
                    listaModel.Add(relPepModel);
                }
            }

            return listaModel;
        }

        public Persona ConvertirPersonaModelPersonaBD(PersonaViewModel personaModel)
        {
            Persona persona = new Persona();
            persona.ING_MENSUALES = personaModel.INGRESOS_MENSUALES != string.Empty ? Convert.ToDecimal(personaModel.INGRESOS_MENSUALES) : 0;
            persona.OTR_INGRESOS = personaModel.OTROS_INGRESOS_MENSUALES != string.Empty ? Convert.ToDecimal(personaModel.OTROS_INGRESOS_MENSUALES) : 0;
            persona.TOTAL_ACTIVOS = personaModel.TOTAL_ACTIVOS != string.Empty ? Convert.ToDecimal(personaModel.TOTAL_ACTIVOS) : 0;
            persona.TOTAL_PASIVOS = personaModel.TOTAL_PASIVOS != string.Empty ? Convert.ToDecimal(personaModel.TOTAL_PASIVOS) : 0;
            decimal patrimonio = persona.TOTAL_ACTIVOS - persona.TOTAL_PASIVOS;
            persona.TOTAL_PATRIMONIO = patrimonio;
            persona.EGR_MENSUALES = personaModel.EGRESOS_MENSUALES != string.Empty ? Convert.ToDecimal(personaModel.EGRESOS_MENSUALES) : 0;
            persona.ID_PERSONA = personaModel.IdPersonaViewModel;
            persona.CONCEPTO_OTR_ING = personaModel.OTROS_CONCEPTOS;
            persona.ID_TIPO_PERSONA = personaModel.ID_TIPO_PERSONA;
            persona.ID_TIPO_DOCUMENTO = personaModel.ID_TIPO_DOCUMENTO;
            persona.NUMERO_DOCUMENTO = personaModel.NUMERO_DOCUMENTO;
            persona.DECLARACION_BIENES = Convert.ToInt32(personaModel.DECLARACION_BIENES);
            persona.AUTORIZACION_DATOS = Convert.ToInt32(personaModel.AUTORIZACION_DATOS);
            persona.ID_MUNICIPIO = personaModel.ID_MUNICIPIO;

            return persona;
        }

        public PersonaViewModel ConvertirPersonaBDPersonaModel(Persona persona)
        {
            PersonaViewModel personaModel = new PersonaViewModel();
            personaModel.EGRESOS_MENSUALES = persona.EGR_MENSUALES == 0 ? string.Empty : persona.EGR_MENSUALES.ToString();
            personaModel.INGRESOS_MENSUALES = persona.ING_MENSUALES == 0 ? string.Empty : persona.ING_MENSUALES.ToString();
            personaModel.OTROS_CONCEPTOS = persona.CONCEPTO_OTR_ING;
            personaModel.OTROS_INGRESOS_MENSUALES = persona.OTR_INGRESOS == 0 ? string.Empty : persona.OTR_INGRESOS.ToString();
            personaModel.TOTAL_ACTIVOS = persona.TOTAL_ACTIVOS == 0 ? string.Empty : persona.TOTAL_ACTIVOS.ToString();
            personaModel.TOTAL_PASIVOS = persona.TOTAL_PASIVOS == 0 ? string.Empty : persona.TOTAL_PASIVOS.ToString();
            personaModel.IdPersonaViewModel = persona.ID_PERSONA;
            decimal patrimonio = persona.TOTAL_ACTIVOS - persona.TOTAL_PASIVOS;
            personaModel.TOTAL_PATRIMONIO = patrimonio == 0 ? string.Empty : patrimonio.ToString();
            personaModel.OTROS_CONCEPTOS = persona.CONCEPTO_OTR_ING;
            personaModel.ID_TIPO_PERSONA = persona.ID_TIPO_PERSONA;
            personaModel.ID_TIPO_DOCUMENTO = persona.ID_TIPO_DOCUMENTO;
            personaModel.NUMERO_DOCUMENTO = persona.NUMERO_DOCUMENTO;
            personaModel.DECLARACION_BIENES = Convert.ToBoolean(persona.DECLARACION_BIENES);
            personaModel.AUTORIZACION_DATOS = Convert.ToBoolean(persona.AUTORIZACION_DATOS);
            personaModel.ID_MUNICIPIO = persona.ID_MUNICIPIO;
            return personaModel;
        }

        public PersonaNaturalImprimirViewModel ConvertirPersonaNaturalImprimirBDModel(PersonaNatural pn)
        {
            PersonaNaturalImprimirViewModel pnViewModel = new PersonaNaturalImprimirViewModel();
            Persona persona = new Persona();
            if (pn.ID_PERSONA > 0)
            {
                persona = pSrv.PersonaConsultarPorID(pn.ID_PERSONA);
                if (persona != null)
                {
                    pnViewModel.TIPO_DOCUMENTO = listaSrv.TipoDocumentoPorIdConsultar(persona.ID_TIPO_DOCUMENTO).NOMBRE_TIPO_DOCUMENTO;
                    pnViewModel.NUMERO_DOCUMENTO = persona.NUMERO_DOCUMENTO;
                    pnViewModel.MUNICIPIO = listaSrv.MunicipioPorIdConsultar(persona.ID_MUNICIPIO).NOMBRE_MUNICIPIO;
                    pnViewModel.DEPARTAMENTO = listaSrv.DepartamentoPorIdMunicipioConsultar(persona.ID_MUNICIPIO).NOMBRE_DEPARTAMENTO;
                    pnViewModel.FEC_DILIGENCIAMIENTO = persona.FEC_DILIGENCIAMIENTO.ToShortDateString();
                    pnViewModel.TOTAL_ACTIVOS = persona.TOTAL_ACTIVOS != 0 ? persona.TOTAL_ACTIVOS.ToString() : string.Empty;
                    pnViewModel.TOTAL_PASIVOS = persona.TOTAL_PASIVOS != 0 ? persona.TOTAL_PASIVOS.ToString() : string.Empty;
                    decimal patrimonio = persona.TOTAL_ACTIVOS - persona.TOTAL_PASIVOS;
                    pnViewModel.TOTAL_PATRIMONIO = patrimonio != 0 ? patrimonio.ToString() : string.Empty;
                    pnViewModel.EGRESOS_MENSUALES = persona.EGR_MENSUALES != 0 ? persona.EGR_MENSUALES.ToString() : string.Empty;
                    pnViewModel.OTROS_INGRESOS_MENSUALES = persona.OTR_INGRESOS != 0 ? persona.OTR_INGRESOS.ToString() : string.Empty;
                    pnViewModel.INGRESOS_MENSUALES = persona.ING_MENSUALES != 0 ? persona.ING_MENSUALES.ToString() : string.Empty;
                    pnViewModel.OTROS_CONCEPTOS = persona.CONCEPTO_OTR_ING;

                }
            }


            pnViewModel.CARGO = pn.CARGO;
            pnViewModel.CELULAR = pn.CELULAR;
            pnViewModel.CELULAR_EMPRESA = pn.CELULAR_EMPRESA;
            pnViewModel.CORREO = pn.CORREO;
            pnViewModel.DECRETO_1674 = pn.DECRETO_1674 == 1 ? "Si" : "No";
            pnViewModel.DEPENDENCIA = pn.DEPENDENCIA;
            pnViewModel.DIRECCION_EMPRESA = pn.DIRECCION_EMPRESA;
            pnViewModel.DIR_RESIDENCIA = pn.DIR_RESIDENCIA;
            pnViewModel.MCPO_RESIDENCIA = listaSrv.MunicipioPorIdConsultar(pn.ID_MCPO_RESIDENCIA).NOMBRE_MUNICIPIO;
            pnViewModel.DEP_RESIDENCIA = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_RESIDENCIA).NOMBRE_DEPARTAMENTO;
            pnViewModel.NOMBRE_EMPRESA = pn.NOMBRE_EMPRESA;
            pnViewModel.ENTIDAD_PEP = pn.ENTIDAD_PEP;
            pnViewModel.EXTENSION_EMPRESA = pn.EXTENSION_EMPRESA;
            pnViewModel.FAX_EMPRESA = pn.FAX_EMPRESA;
            pnViewModel.FEC_EXPEDICION = pn.FEC_EXPEDICION.ToShortDateString();
            pnViewModel.FEC_NACIMIENTO = pn.FEC_NACIMIENTO.ToShortDateString();
            if (pn.FEC_VINCULA_PEP != null && pn.FEC_VINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
            {
                pnViewModel.FEC_VINCULA_PEP = Convert.ToDateTime(pn.FEC_VINCULA_PEP.ToString()).ToShortDateString();
            }
            if (pn.FEC_DESVINCULA_PEP != null && pn.FEC_DESVINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
            {
                pnViewModel.FEC_DESVINCULA_PEP = Convert.ToDateTime(pn.FEC_DESVINCULA_PEP.ToString()).ToShortDateString();
            }

            if (pn.ID_CARGO_PEP != null)
            { pnViewModel.CARGO_PEP = listaSrv.CargoPorIdConsultar((Int64)pn.ID_CARGO_PEP).NOMBRE_CARGO_PEP; }
            else { pnViewModel.CARGO_PEP = string.Empty; }
            CodigoCiiu codc = listaSrv.CodigoCiiuPorIdConsultar(pn.ID_CODIGO_CIIU);
            if (codc != null) pnViewModel.CODIGO_CIIU = codc.NOMBRE_CODIGO_CIIU;
            ActividadEconomica act = listaSrv.ActividadEconomicaPorCodigoCiiuConsultar(pn.ID_CODIGO_CIIU);
            if (act != null) pnViewModel.ACT_ECONOMICA = act.NOMBRE_ACTIVIDAD_ECONOMICA;
            pnViewModel.ESTADO_CIVIL = listaSrv.EstadoCivilPorIdConsultar(pn.ID_ESTADO_CIVIL).NOMBRE_ESTADO_CIVIL;
            pnViewModel.MCPO_EMPRESA = listaSrv.MunicipioPorIdConsultar(pn.ID_MCPO_EMPRESA).NOMBRE_MUNICIPIO;
            pnViewModel.DEP_EMPRESA = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_EMPRESA).NOMBRE_DEPARTAMENTO;
            pnViewModel.MCPO_EXPEDICION = listaSrv.MunicipioPorIdConsultar(pn.ID_MCPO_EXPEDICION).NOMBRE_MUNICIPIO;
            pnViewModel.DEP_EXPEDICION = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_EXPEDICION).NOMBRE_DEPARTAMENTO;
            pnViewModel.MCPO_NACIMIENTO = listaSrv.MunicipioPorIdConsultar(pn.ID_MCPO_NACIMIENTO).NOMBRE_MUNICIPIO;
            pnViewModel.DEP_NACIMIENTO = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_NACIMIENTO).NOMBRE_DEPARTAMENTO;
            if (pn.ID_PROFESION > 0)
            { pnViewModel.PROFESION = listaSrv.ProfesionPorIdConsultar(pn.ID_PROFESION).NOMBRE_PROFESION; }

            pnViewModel.SEXO = listaSrv.SexoPorIdConsultar(pn.ID_SEXO).NOMBRE_SEXO;
            if (pn.ID_TIPO_EMPRESA > 0)
            {
                pnViewModel.TIPO_EMPRESA = listaSrv.TipoEmpresaPorIdConsultar(pn.ID_TIPO_EMPRESA).NOMBRE_TIPO_EMPRESA;
            }
            else
            {
                pnViewModel.TIPO_EMPRESA = string.Empty;
            }
            pnViewModel.NOMBRE_EMPRESA = pn.NOMBRE_EMPRESA;
            pnViewModel.APELLIDOS = pn.PRIMER_APELLIDO + " " + pn.SEGUNDO_APELLIDO;
            pnViewModel.NOMBRES = pn.PRIMER_NOMBRE + " " + pn.SEGUNDO_NOMBRE;
            pnViewModel.RECONOCIMIENTO_PUB = pn.RECONOCIMIENTO_PUB == 1 ? "Si" : "No";
            pnViewModel.REP_ORG_INTERNACIONAL = pn.REP_ORG_INTERNACIONAL == 1 ? "Si" : "No";
            pnViewModel.TELEFONO = pn.TELEFONO == null ? string.Empty : pn.TELEFONO;
            pnViewModel.TELEFONO_EMPRESA = pn.TELEFONO_EMPRESA;
            pnViewModel.TEL_RESIDENCIA = pn.TEL_RESIDENCIA;
            pnViewModel.VINCULO_PEP = pn.VINCULO_PEP == 1 ? "Si" : "No";

            return pnViewModel;
        }

        public PersonaJuridicaImpresionViewModel ConvertirPersonaJuridicaModel(Int64 IdPersona)
        {
            PersonaNaturalSRV srvPersonaNatural = new PersonaNaturalSRV();
            PersonaJuridicaSRV PersonaJuridicaSRV = new PersonaJuridicaSRV();

            PersonaNatural Representante = new Entidades.PersonaNatural();
            PersonaJuridica pBD = new Entidades.PersonaJuridica();
            PersonaJuridicaImpresionViewModel pImprimir = new PersonaJuridicaImpresionViewModel();
            PersonaJuridicaViewModel pjViewModel = new PersonaJuridicaViewModel();
            RepresentanteLegalViewModel RepresentanteModel = new RepresentanteLegalViewModel();
            pBD = PersonaJuridicaSRV.PersonaJuridicaConsultarPorPersonaID(IdPersona);
            pImprimir.RAZON_SOCIAL = pBD.RAZON_SOCIAL;


            Persona personajuridica = new Persona();
            if (pBD.ID_PERSONA > 0)
            {
                personajuridica = pSrv.PersonaConsultarPorID(pBD.ID_PERSONA);
                if (personajuridica != null)
                {
                    pImprimir.TIPO_DOCUMENTO = listaSrv.TipoDocumentoPorIdConsultar(personajuridica.ID_TIPO_DOCUMENTO).NOMBRE_TIPO_DOCUMENTO;
                    pImprimir.NUMERO_DOCUMENTO = personajuridica.NUMERO_DOCUMENTO;
                    pImprimir.MUNICIPIO = listaSrv.MunicipioPorIdConsultar(personajuridica.ID_MUNICIPIO).NOMBRE_MUNICIPIO;
                    pImprimir.DEPARTAMENTO = listaSrv.DepartamentoPorIdMunicipioConsultar(personajuridica.ID_MUNICIPIO).NOMBRE_DEPARTAMENTO;
                    pImprimir.FEC_DILIGENCIAMIENTO = personajuridica.FEC_DILIGENCIAMIENTO.ToShortDateString();
                    pImprimir.TOTAL_ACTIVOS = personajuridica.TOTAL_ACTIVOS != 0 ? personajuridica.TOTAL_ACTIVOS.ToString() : string.Empty;
                    pImprimir.TOTAL_PASIVOS = personajuridica.TOTAL_PASIVOS != 0 ? personajuridica.TOTAL_PASIVOS.ToString() : string.Empty;
                    decimal patrimonio = personajuridica.TOTAL_ACTIVOS - personajuridica.TOTAL_PASIVOS;
                    pImprimir.TOTAL_PATRIMONIO = patrimonio != 0 ? patrimonio.ToString() : string.Empty;
                    pImprimir.EGRESOS_MENSUALES = personajuridica.EGR_MENSUALES != 0 ? personajuridica.EGR_MENSUALES.ToString() : string.Empty;
                    pImprimir.OTROS_INGRESOS_MENSUALES = personajuridica.OTR_INGRESOS != 0 ? personajuridica.OTR_INGRESOS.ToString() : string.Empty;
                    pImprimir.INGRESOS_MENSUALES = personajuridica.ING_MENSUALES != 0 ? personajuridica.ING_MENSUALES.ToString() : string.Empty;
                    pImprimir.OTROS_CONCEPTOS = personajuridica.CONCEPTO_OTR_ING;
                }
            }

            //Datos de actividad economica
            CodigoCiiu codc = listaSrv.CodigoCiiuPorIdConsultar(pBD.ID_CODIGO_CIIU);
            if (codc != null) pImprimir.CODIGO_CIIU = codc.NOMBRE_CODIGO_CIIU;
            ActividadEconomica act = listaSrv.ActividadEconomicaPorCodigoCiiuConsultar(pBD.ID_CODIGO_CIIU);
            if (act != null) pImprimir.ACTIVIDAD_ECONOMICA = act.NOMBRE_ACTIVIDAD_ECONOMICA;

            TipoEmpresa tipoempresa = listaSrv.TipoEmpresaPorIdConsultar(pBD.ID_TIPO_EMPRESA);
            if (tipoempresa != null) pImprimir.TIPO_EMPRESA = tipoempresa.NOMBRE_TIPO_EMPRESA;

            pImprimir.DIRECCION_JURIDICA = pBD.DIRECCION;
            pImprimir.MUNICIPIO_JURIDICA = listaSrv.MunicipioPorIdConsultar(pBD.ID_MUNICIPIO).NOMBRE_MUNICIPIO;
            pImprimir.DEPTO_JURIDICA = listaSrv.DepartamentoPorIdMunicipioConsultar(pBD.ID_MUNICIPIO).NOMBRE_DEPARTAMENTO;
            pImprimir.TELEFONO_JURIDICA = pBD.TELEFONO;
            pImprimir.EXTENSION_JURIDICA = pBD.EXTENSION;
            pImprimir.FAX_JURIDICA = pBD.FAX;
            pImprimir.CORREO_JURIDICA = pBD.CORREO;

            // datos sucursal
            if (pBD.ID_MCPO_SUCURSAL > 0 && pBD.ID_MCPO_SUCURSAL != null)
            {
                pImprimir.MCPO_SUCURSAL = listaSrv.MunicipioPorIdConsultar((long)pBD.ID_MCPO_SUCURSAL).NOMBRE_MUNICIPIO;
                pImprimir.DEPTO_SUCURSAL = listaSrv.DepartamentoPorIdMunicipioConsultar((long)pBD.ID_MCPO_SUCURSAL).NOMBRE_DEPARTAMENTO;
            }
            pImprimir.DIR_SUCURSAL = pBD.DIR_SUCURSAL == null ? string.Empty : pBD.DIR_SUCURSAL;
            pImprimir.TEL_SUCURSAL = pBD.TEL_SUCURSAL == null ? string.Empty : pBD.TEL_SUCURSAL;
            pImprimir.EXT_SUCURSAL = pBD.EXT_SUCURSAL == null ? string.Empty : pBD.EXT_SUCURSAL;
            pImprimir.FAX_SUCURSAL = pBD.FAX_SUCURSAL == null ? string.Empty : pBD.FAX_SUCURSAL;
            pImprimir.CORREO_SUCURSAL = pBD.CORREO_SUCURSAL == null ? string.Empty : pBD.CORREO_SUCURSAL;

            // Datos representante legal
            if (pBD.ID_REP_LEGAL > 0)
            {
                Representante = srvPersonaNatural.PersonaNaturalConsultarPorIdPersona(pBD.ID_REP_LEGAL);
                Persona personaRepresentante = new Persona();
                personaRepresentante = pSrv.PersonaConsultarPorID(Representante.ID_PERSONA);
                if (personaRepresentante != null)
                {
                    pImprimir.TIPO_DOCUMENTO_REP_LEGAL = listaSrv.TipoDocumentoPorIdConsultar(personaRepresentante.ID_TIPO_DOCUMENTO).NOMBRE_TIPO_DOCUMENTO;
                    pImprimir.NUMERO_DOCUMENTO_REP_LEGAL = personaRepresentante.NUMERO_DOCUMENTO;

                }
                pImprimir.Id_Rep_Legal = pBD.ID_REP_LEGAL;
                pImprimir.CELULAR = Representante.CELULAR;
                pImprimir.CELULAR_EMPRESA = Representante.CELULAR_EMPRESA;
                pImprimir.CORREO = Representante.CORREO;
                pImprimir.DECRETO_1674 = Representante.DECRETO_1674 == 1 ? "Si" : "No";
                pImprimir.DIR_RESIDENCIA = Representante.DIR_RESIDENCIA;
                pImprimir.MCPO_RESIDENCIA = listaSrv.MunicipioPorIdConsultar(Representante.ID_MCPO_RESIDENCIA).NOMBRE_MUNICIPIO;
                pImprimir.DEP_RESIDENCIA = listaSrv.DepartamentoPorIdMunicipioConsultar(Representante.ID_MCPO_RESIDENCIA).NOMBRE_DEPARTAMENTO;
                pImprimir.ENTIDAD_PEP = Representante.ENTIDAD_PEP;
                pImprimir.EXTENSION_EMPRESA = Representante.EXTENSION_EMPRESA;
                pImprimir.TELEFONO_EMPRESA = Representante.TELEFONO_EMPRESA; 
                pImprimir.FAX_EMPRESA = Representante.FAX_EMPRESA;
                pImprimir.FEC_EXPEDICION = Representante.FEC_EXPEDICION.ToShortDateString();
                pImprimir.FEC_NACIMIENTO = Representante.FEC_NACIMIENTO.ToShortDateString();
                if (Representante.FEC_VINCULA_PEP != null && Representante.FEC_VINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
                {
                    pImprimir.FEC_VINCULA_PEP = Convert.ToDateTime(Representante.FEC_VINCULA_PEP.ToString()).ToShortDateString();
                }
                if (Representante.FEC_DESVINCULA_PEP != null && Representante.FEC_DESVINCULA_PEP.Value.ToShortDateString() != "1/01/0001")
                {
                    pImprimir.FEC_DESVINCULA_PEP = Convert.ToDateTime(Representante.FEC_DESVINCULA_PEP.ToString()).ToShortDateString();
                }

                if (Representante.ID_CARGO_PEP != null)
                { pImprimir.CARGO_PEP = listaSrv.CargoPorIdConsultar((Int64)Representante.ID_CARGO_PEP).NOMBRE_CARGO_PEP; }

                pImprimir.ESTADO_CIVIL = listaSrv.EstadoCivilPorIdConsultar(Representante.ID_ESTADO_CIVIL).NOMBRE_ESTADO_CIVIL;
                pImprimir.MCPO_EXPEDICION = listaSrv.MunicipioPorIdConsultar(Representante.ID_MCPO_EXPEDICION).NOMBRE_MUNICIPIO;
                pImprimir.DEP_EXPEDICION = listaSrv.DepartamentoPorIdMunicipioConsultar(Representante.ID_MCPO_EXPEDICION).NOMBRE_DEPARTAMENTO;
                pImprimir.MCPO_NACIMIENTO = listaSrv.MunicipioPorIdConsultar(Representante.ID_MCPO_NACIMIENTO).NOMBRE_MUNICIPIO;
                pImprimir.DEP_NACIMIENTO = listaSrv.DepartamentoPorIdMunicipioConsultar(Representante.ID_MCPO_NACIMIENTO).NOMBRE_DEPARTAMENTO;
                pImprimir.SEXO = listaSrv.SexoPorIdConsultar(Representante.ID_SEXO).NOMBRE_SEXO;
                pImprimir.APELLIDOS = Representante.PRIMER_APELLIDO + " " + Representante.SEGUNDO_APELLIDO;
                pImprimir.NOMBRES = Representante.PRIMER_NOMBRE + " " + Representante.SEGUNDO_NOMBRE;
                pImprimir.RECONOCIMIENTO_PUB = Representante.RECONOCIMIENTO_PUB == 1 ? "Si" : "No";
                pImprimir.REP_ORG_INTERNACIONAL = Representante.REP_ORG_INTERNACIONAL == 1 ? "Si" : "No";
                pImprimir.TELEFONO = Representante.TELEFONO;
                pImprimir.TEL_RESIDENCIA = Representante.TEL_RESIDENCIA;
                pImprimir.VINCULO_PEP = Representante.VINCULO_PEP == 1 ? "Si" : "No";

            }




            return pImprimir;
        }

        public List<OperacionImprimirViewModel> ConvertirOperacionesBDViewModel(List<Operacion> operaciones)
        {
            List<OperacionImprimirViewModel> listaOperaciones = new List<OperacionImprimirViewModel>();
            if (operaciones != null && operaciones.Count > 0)
            {
                foreach (Operacion item in operaciones)
                {
                    OperacionImprimirViewModel opModel = new OperacionImprimirViewModel();
                    opModel.CIUDAD = item.CIUDAD;
                    opModel.ENTIDAD_FINANCIERA = item.ENTIDAD_FINANCIERA;
                    opModel.MONTO = item.MONTO != 0 ? item.MONTO.ToString() : string.Empty;
                    opModel.NUMERO_PRODUCTO = item.NUMERO_PRODUCTO;
                    opModel.PAIS = item.PAIS;
                    opModel.TIPO_MONEDA = item.ID_TIPO_MONEDA != 0 ? listaSrv.TipoMonedaPorIdConsultar(item.ID_TIPO_MONEDA).NOMBRE_TIPO_MONEDA : string.Empty;
                    opModel.TIPO_OPERACIONES = item.ID_TIPO_OPERACIONES != 0 ? listaSrv.TipoOperacionPorIDConsultar(item.ID_TIPO_OPERACIONES).NOMBRE_TIPO_OPERACION : string.Empty;
                    opModel.TIPO_PRODUCTO = item.TIPO_PRODUCTO;
                    listaOperaciones.Add(opModel);
                }

            }
            return listaOperaciones;
        }

    }
}