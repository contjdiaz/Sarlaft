using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class PersonaViewModel : BaseEntidades
    {
		
		public Int64 IdPersonaViewModel { get; set; }
     
        [Display(Name = "Tipo persona")]
		public Int64 ID_TIPO_PERSONA { get; set; }

		[Display(Name = "Tipo documento")]
		public Int64 ID_TIPO_DOCUMENTO { get; set; }

		[Display(Name = "Número de documento")]
		[StringLength(20)]
		public string NUMERO_DOCUMENTO { get; set; }

		[Display(Name = "Fecha")]
		public DateTime FEC_DILIGENCIAMIENTO { get; set; }

		[Display(Name = "Declaración de bienes")]
		[Required(ErrorMessage = "Requerido")]
		public bool DECLARACION_BIENES { get; set; }

		[Display(Name = "Autoriación de datos")]
		[Required(ErrorMessage = "Requerido")]
		public bool AUTORIZACION_DATOS { get; set; }

		[Display(Name = "Oficina icetex")]
		public Int64 ID_MUNICIPIO { get; set; }

		[Display(Name = "Total activos")]      
		[Required(ErrorMessage = "Requerido")]
		public string TOTAL_ACTIVOS { get; set; }

        [Display(Name = "Total pasivos")]
		[Required(ErrorMessage = "Requerido")]
		public string TOTAL_PASIVOS { get; set; }

		public string TOTAL_PATRIMONIO { get; set; }

		[Display(Name = "Ingresos mensuales")]
		[Required(ErrorMessage = "Requerido")]
		public string INGRESOS_MENSUALES { get; set; }

        [Display(Name = "Egresos mensuales")]
		[Required(ErrorMessage = "Requerido")]
		public string EGRESOS_MENSUALES { get; set; }

        [Display(Name = "Otros ingresos mensuales")]
        public string OTROS_INGRESOS_MENSUALES { get; set; }

        [Display(Name = "Otros conceptos")]
		[MaxLength(200)]
        public string OTROS_CONCEPTOS { get; set; }

        public string ClausulaAutorizacion { get; set; }

        public string DeclaracionOrigen { get; set; }
    }
}