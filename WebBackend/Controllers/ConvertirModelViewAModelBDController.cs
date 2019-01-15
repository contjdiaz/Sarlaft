using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBackend.Models;
using WebBackend.Models;

namespace WebBackend.Controllers
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

        public TipoDocumentoViewModel ConvertirTipoDocumentoBDToViewModel(TipoDocumento tp)
        {
            TipoDocumentoViewModel tpVM = new TipoDocumentoViewModel();
            tpVM.CODIGO = tp.CODIGO;
            tpVM.ID_TIPO_DOCUMENTO = tp.ID_TIPO_DOCUMENTO;
            tpVM.NOMBRE_TIPO_DOCUMENTO = tp.NOMBRE_TIPO_DOCUMENTO;
            if (tp.ES_JURIDICA == 1)
            {
                tpVM.CODIGO_TIPO_PERSONA = "PJ";
            }

            if (tp.ES_NATURAL == 1)
            {
                tpVM.CODIGO_TIPO_PERSONA = "PN";
            }

            //tpVM.ListaTipoPersona = new SelectList(listaSrv.TipoPersonaConsultar(), "CODIGO_TIPO_PERSONA", "NOMBRE_TIPO_PERSONA",tpVM.CODIGO_TIPO_PERSONA);
          
            return tpVM;
        }

        public TipoDocumento ConvertirTipoDocumentoViewModelToBD(TipoDocumentoViewModel tpVM)
        {
            TipoDocumento tp = new TipoDocumento();
            tp.CODIGO = tpVM.CODIGO;
            tp.ID_TIPO_DOCUMENTO = tpVM.ID_TIPO_DOCUMENTO;
            tp.NOMBRE_TIPO_DOCUMENTO = tpVM.NOMBRE_TIPO_DOCUMENTO;


            if (tpVM.CODIGO_TIPO_PERSONA == "PN")
            {
                tp.ES_NATURAL = 1;
                tp.ES_JURIDICA = 0;
            }
            else if (tpVM.CODIGO_TIPO_PERSONA == "PJ")
            {
                tp.ES_NATURAL = 0;
                tp.ES_JURIDICA = 1;
            }

            return tp;
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

        public Usuario ConvertirUsuarioViewModelModelBD(UsuarioViewModel usuarioViewModel)
        {
            Usuario usuario = new Usuario();
            usuario.APELLIDOS_USUARIO = usuarioViewModel.APELLIDOS_USUARIO;
            usuario.EMAIL_USUARIO = usuarioViewModel.EMAIL_USUARIO;
            usuario.NOMBRES_USUARIO = usuarioViewModel.NOMBRES_USUARIO;
            usuario.PASSWORD_USUARIO = usuarioViewModel.PASSWORD_USUARIO;
            usuario.ID_USUARIO = usuarioViewModel.ID_USUARIO;
            usuario.ID_USUARIO_ACCION = usuarioViewModel.ID_USUARIO_ACCION;

            return usuario;
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
            if(pn.ID_MCPO_RESIDENCIA > 0)
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
            if(pn.ID_CODIGO_CIIU > 0)
                pnViewModel.ID_ACT_ECONOMICA = listaSrv.ActividadEconomicaPorCodigoCiiuConsultar(pn.ID_CODIGO_CIIU).ID_ACTIVIDAD_ECONOMICA;
            pnViewModel.ID_ESTADO_CIVIL = pn.ID_ESTADO_CIVIL;
            pnViewModel.ID_MCPO_EMPRESA = pn.ID_MCPO_EMPRESA;
            if(pn.ID_MCPO_EMPRESA>0)
                pnViewModel.ID_DEP_EMPRESA = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_EMPRESA).ID_DEPARTAMENTO;
            pnViewModel.ID_MCPO_EXPEDICION = pn.ID_MCPO_EXPEDICION;
            if(pn.ID_MCPO_EXPEDICION>0)
                pnViewModel.ID_DEP_EXPEDICION = listaSrv.DepartamentoPorIdMunicipioConsultar(pn.ID_MCPO_EXPEDICION).ID_DEPARTAMENTO;    
            pnViewModel.ID_MCPO_NACIMIENTO = pn.ID_MCPO_NACIMIENTO;
            if(pn.ID_MCPO_NACIMIENTO>0)
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
                    if (item.FEC_DESVINCULA != null)
                    {
                        relPepModel.FEC_DESVINCULA_RPEP = Convert.ToDateTime(item.FEC_DESVINCULA).ToShortDateString();
                    }
                    if (item.FEC_VINCULA != null)
                    {
                        relPepModel.FEC_VINCULA_RPEP = Convert.ToDateTime(item.FEC_VINCULA).ToShortDateString();
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

     

    }
}