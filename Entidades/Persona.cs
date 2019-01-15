using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona : BaseEntidades
    {
        [Display(Name = "Id")]
        public Int64 ID_PERSONA { get; set; }

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
        public int DECLARACION_BIENES { get; set; }

        [Display(Name = "Autoriación de datos")]     
        public int AUTORIZACION_DATOS { get; set; }

        [Display(Name = "Oficina icetex")]    
        public Int64 ID_MUNICIPIO { get; set; }

		[Display(Name = "Total activos")]
		public Decimal TOTAL_ACTIVOS { get; set; }

		[Display(Name = "Total pasivos")]
		public Decimal TOTAL_PASIVOS { get; set; }

		[Display(Name = "Total patrimonio")]		
		public Decimal TOTAL_PATRIMONIO { get; set; }

		[Display(Name = "Ingresos")]
		public Decimal ING_MENSUALES { get; set; }

		[Display(Name = "Egresos")]
		public Decimal EGR_MENSUALES { get; set; }

		[Display(Name = "Otros ingresos")]
		public Decimal OTR_INGRESOS { get; set; }

		[Display(Name = "Concepto ingresos")]
		public string CONCEPTO_OTR_ING { get; set; }


	}
}



