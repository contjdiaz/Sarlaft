using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBackend.Models
{
    public class PersonaJuridicaImpresionViewModel
    {

        // se agregan campos para impresion
        public string RAZON_SOCIAL { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string MUNICIPIO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string FEC_DILIGENCIAMIENTO { get; set; }
        public string TIPO_EMPRESA { get; set; }
        public string ACTIVIDAD_ECONOMICA { get; set; }
        public string CODIGO_CIIU { get; set; }

        //Se agregan los datos de ubicación
        public string DIRECCION_JURIDICA { get; set; }

        public string DEPTO_JURIDICA { get; set; }

        public string MUNICIPIO_JURIDICA { get; set; }

        public string TELEFONO_JURIDICA { get; set; }

        public string EXTENSION_JURIDICA { get; set; }

        public string FAX_JURIDICA { get; set; }

        public string CORREO_JURIDICA { get; set; }

        public string DIR_SUCURSAL { get; set; }

        public string DEPTO_SUCURSAL { get; set; }

        public string MCPO_SUCURSAL { get; set; }

        public string TEL_SUCURSAL { get; set; }

        public string EXT_SUCURSAL { get; set; }
        public string FAX_SUCURSAL { get; set; }

        public string CORREO_SUCURSAL { get; set; }

        // Se agregan los campos adicionales de representante legal
        public string TIPO_DOCUMENTO_REP_LEGAL { get; set; }
        public string NUMERO_DOCUMENTO_REP_LEGAL { get; set; }

        #region InformacionFinanciera
        public string TOTAL_ACTIVOS { get; set; }

        public string TOTAL_PASIVOS { get; set; }

        public string TOTAL_PATRIMONIO { get; set; }

        public string INGRESOS_MENSUALES { get; set; }

        public string EGRESOS_MENSUALES { get; set; }

        public string OTROS_INGRESOS_MENSUALES { get; set; }

        public string OTROS_CONCEPTOS { get; set; }
        #endregion

        #region Representantelegal

        public long Id_Rep_Legal { get; set; }
        public string NOMBRES { get; set; }

        public string APELLIDOS { get; set; }

        public string SEXO { get; set; }

        public string FEC_EXPEDICION { get; set; }

        public string FEC_NACIMIENTO { get; set; }

        public string DIR_RESIDENCIA { get; set; }

        public string CORREO { get; set; }

        public string TELEFONO { get; set; }

        public string CELULAR { get; set; }

        public string DEP_EXPEDICION { get; set; }

        public string MCPO_EXPEDICION { get; set; }

        public string DEP_NACIMIENTO { get; set; }

        public string MCPO_NACIMIENTO { get; set; }

        public string ESTADO_CIVIL { get; set; }


        public string TEL_RESIDENCIA { get; set; }

        public string DEP_RESIDENCIA { get; set; }

        public string MCPO_RESIDENCIA { get; set; }




        public string TELEFONO_EMPRESA { get; set; }

        public string EXTENSION_EMPRESA { get; set; }

        public string CELULAR_EMPRESA { get; set; }

        public string FAX_EMPRESA { get; set; }

        public string DECRETO_1674 { get; set; }

        public string REP_ORG_INTERNACIONAL { get; set; }

        public string RECONOCIMIENTO_PUB { get; set; }

        public string VINCULO_PEP { get; set; }

        public string ENTIDAD_PEP { get; set; }

        public string CARGO_PEP { get; set; }

        public string FEC_VINCULA_PEP { get; set; }

        public string FEC_DESVINCULA_PEP { get; set; }
        #endregion


        public List<RelacionadoPepViewModel> RelacionadosPep { get; set; }
        public List<RelacionadoPepViewModel> Administradores { get; set; }
        public List<OperacionImprimirViewModel> OperacionesInternacionales { get; set; }
    }
}