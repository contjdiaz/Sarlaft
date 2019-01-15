using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBackend.Models
{
	public class RelacionadoPepViewModel
	{
		[Display(Name = "Id")]
		public Int64 ID_RELACIONADO_PEP { get; set; }

		[Display(Name = "Id Persona")]
		public Int64 ID_PERSONA_RPEP { get; set; }

		[Display(Name = "Tipo Relación")]
		public Int64 ID_TIPO_REL_RPEP { get; set; }

		public string Relacion_RPEP { get; set; }

		[Display(Name = "Tipo documento")]
		public Int64 ID_TIPO_DOCUMENTO_RPEP { get; set; }

		public string TipoDocumento_RPEP { get; set; }

        [Display(Name = "Documento")]
        [StringLength(20, ErrorMessage = "La longitud del documento debe ser mínimo de 3 caracteres y máximo de 20", MinimumLength = 3)]
        public string DOCUMENTO_RPEP { get; set; }

        [Display(Name = "Priemer nombre")]
        [StringLength(20, ErrorMessage = "La longitud del primer nombre debe ser mínimo de 3 caracteres y máximo de 20", MinimumLength = 3)]
        public string PRIMER_NOMBRE_RPEP { get; set; }

        [StringLength(20, ErrorMessage = "La longitud del segundo nombre debe ser mínimo de 3 caracteres y máximo de 20", MinimumLength = 3)]
        [Display(Name = "Segundo nombre")]
        public string SEGUNDO_NOMBRE_RPEP { get; set; }

        [Display(Name = "Primer apellido")]
        [StringLength(20, ErrorMessage = "La longitud del primer apellido debe ser mínimo de 3 caracteres y máximo de 20", MinimumLength = 3)]
        public string PRIMER_APELLIDO_RPEP { get; set; }

        [Display(Name = "Segundo apellido")]
        [StringLength(20, ErrorMessage = "La longitud del segundo apellido debe ser mínimo de 3 caracteres y máximo de 20", MinimumLength = 3)]
        public string SEGUNDO_APELLIDO_RPEP { get; set; }

        [Display(Name = "Nombre entidad")]
        [StringLength(100, ErrorMessage = "La longitud del nombre entidad debe ser mínimo de 3 caracteres y máximo de 100", MinimumLength = 3)]
        public string NOMBRE_ENTIDAD_RPEP { get; set; }

        [Display(Name = "Cargo")]
		public string CARGO_RPEP { get; set; }

		[Display(Name = "Fecha vinculación")]
		public string FEC_VINCULA_RPEP { get; set; }

		[Display(Name = "Fecha desvinculación")]
		public string FEC_DESVINCULA_RPEP { get; set; }

		[Display(Name = "Fecha desvinculación cargo")]
		public string FEC_DESVINCULA_CARGO_RPEP { get; set; }

		public string Nombres_RPEP
		{
			get { return PRIMER_NOMBRE_RPEP + " " + SEGUNDO_NOMBRE_RPEP; }
		}

		public string Apellidos_RPEP
		{
			get { return PRIMER_APELLIDO_RPEP + " " + SEGUNDO_APELLIDO_RPEP; }
		}

		public bool Eliminar { get; set; }
	}
}