using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class RelacionadoPep : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_RELACIONADO_PEP { get; set; }

		[Display(Name = "Id Persona")]
		public Int64 ID_PERSONA { get; set; }

		[Display(Name = "Tipo Relación")]
		public Int64 ID_TIPO_REL_PEP { get; set; }

		[Display(Name = "Tipo documento")]
		public Int64 ID_TIPO_DOCUMENTO { get; set; }

		[Display(Name = "Documento")]
		public string DOCUMENTO	{ get; set; }

		[Display(Name = "Priemer nombre")]
		public string PRIMER_NOMBRE { get; set; }

		[Display(Name = "Segundo nombre")]
		public string SEGUNDO_NOMBRE { get; set; }

		[Display(Name = "Primer apellido")]
		public string PRIMER_APELLIDO { get; set; }

		[Display(Name = "Segundo apellido")]
		public string SEGUNDO_APELLIDO { get; set; }

		[Display(Name = "Nombre entidad")]
		public string NOMBRE_ENTIDAD { get; set; }	

		[Display(Name = "Cargo")]
		public string CARGO { get; set; }

        [Display(Name = "ID_Cargo")]
        public Int64? ID_CARGO_PEP { get; set; }

        [Display(Name = "Fecha vinculación PEP")]
		public DateTime? FEC_VINCULA { get; set; }

		[Display(Name = "Fecha desvinculación PEP")]
		public DateTime? FEC_DESVINCULA { get; set; }
	}
}
