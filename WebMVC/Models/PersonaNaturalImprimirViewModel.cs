using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Models
{
	public class PersonaNaturalImprimirViewModel
	{

		#region  Persona	
		
		public string TIPO_DOCUMENTO { get; set; }

		public string NUMERO_DOCUMENTO { get; set; }

		public string MUNICIPIO { get; set; }
        public string DEPARTAMENTO { get; set; }

        public string FEC_DILIGENCIAMIENTO { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
		public string TOTAL_ACTIVOS { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public string TOTAL_PASIVOS { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public string TOTAL_PATRIMONIO { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public string INGRESOS_MENSUALES { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public string EGRESOS_MENSUALES { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public string OTROS_INGRESOS_MENSUALES { get; set; }

		public string OTROS_CONCEPTOS { get; set; }
		#endregion


		#region PersonaNatural


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

		public string PROFESION { get; set; }

		public string NOMBRE_EMPRESA { get; set; }

		public string ACT_ECONOMICA { get; set; }

		public string CODIGO_CIIU { get; set; }

		public string TEL_RESIDENCIA { get; set; }

		public string DEP_RESIDENCIA { get; set; }

		public string MCPO_RESIDENCIA { get; set; }

		public string TIPO_EMPRESA { get; set; }

		public string DEPENDENCIA { get; set; }

		public string CARGO { get; set; }

		public string DIRECCION_EMPRESA { get; set; }

		public string DEP_EMPRESA { get; set; }

		public string MCPO_EMPRESA { get; set; }

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

		public List<RelacionadoPepViewModel> RelacionadosPep { get; set; }

		public List<OperacionImprimirViewModel> OperacionesInternacionales { get; set; }
		#endregion
	}
}