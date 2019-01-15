using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBackend.Models;

namespace WebBackend.Models
{
	public class PersonaNaturalViewModel: IValidatableObject
	{

		#region  Persona
		[Key]
		[Display(Name = "Id")]
		public Int64 ID_PERSONA { get; set; }

		[Display(Name = "Tipo persona")]
		public Int64 ID_TIPO_PERSONA { get; set; }

		[Display(Name = "Tipo documento")]
		[Required(ErrorMessage = "Tipo documento requerido")]
		public Int64 ID_TIPO_DOCUMENTO { get; set; }

		public string TipoDocumento { get; set; }

		[Display(Name = "Número de documento")]
		[Required(ErrorMessage = "Documento requerido")]
		[StringLength(20)]
		public string NUMERO_DOCUMENTO { get; set; }

		[Required(ErrorMessage = "Departamento requerido")]
		public Int64 ID_DEPARTMENTO { get; set; }

		public SelectList ListaMunicipio { get; set; }

		[Display(Name = "Municipio")]
		[Required(ErrorMessage = "Municio requerido")]
		public Int64 ID_MUNICIPIO { get; set; }
		#endregion


		#region PersonaNatural
		[Display(Name = "Id")]
		public Int64 ID_NATURAL { get; set; }

		[Display(Name = "Priemer nombre")]
		[Required(ErrorMessage = "Nombre requerido")]
		[MaxLength(20)]
		public string PRIMER_NOMBRE { get; set; }

		[Display(Name = "Segundo nombre")]
		[MaxLength(20)]
		public string SEGUNDO_NOMBRE { get; set; }

		[Display(Name = "Primer apellido")]
		[MaxLength(20)]
		[Required(ErrorMessage = "Primer apellido requerido")]
		public string PRIMER_APELLIDO { get; set; }

		[Display(Name = "Segundo apellido")]
		[MaxLength(20)]
		public string SEGUNDO_APELLIDO { get; set; }

		[Display(Name = "Sexo")]
		[Required(ErrorMessage = "Sexo requerido")]
		public Int64 ID_SEXO { get; set; }

		[Display(Name = "Fecha expedición")]
		[Required(ErrorMessage = "Fecha expedición requerido")]
	
		public string FEC_EXPEDICION { get; set; }

		[Display(Name = "Fecha nacimiento")]
		[Required(ErrorMessage = "Fecha nacimiento requerido")]
	
		public string FEC_NACIMIENTO { get; set; }

		[Display(Name = "Dirección de residencia")]
		[Required(ErrorMessage = "Dirección residencia requerido")]
		[MaxLength(100)]
		public string DIR_RESIDENCIA { get; set; }

		[Display(Name = "Correo electrónico")]
		[Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        [MaxLength(40)]
		public string CORREO { get; set; }

		[Display(Name = "Teléfono residencia")]
		[MaxLength(40)]
        [StringLength(7, ErrorMessage = "La longitud del teléfono de la residencia debe ser de 7 caracteres", MinimumLength = 7)]
        public string TELEFONO { get; set; }

		[Display(Name = "Celular")]
		[MaxLength(40)]
		[Required(ErrorMessage = "Celular requerido")]
        [StringLength(10, ErrorMessage = "La longitud del celular debe ser de 10 caracteres", MinimumLength = 10)]
        public string CELULAR { get; set; }

		[Required(ErrorMessage = "Departamento expedición requerido")]
		public Int64 ID_DEP_EXPEDICION { get; set; }

		[Display(Name = "Ciudad expedición")]
		[Required(ErrorMessage = "Municipio expedición requerido")]
		public Int64 ID_MCPO_EXPEDICION { get; set; }

		public SelectList ListaMunicipioExp { get; set; }

		[Required(ErrorMessage = "Departamento nacimiento requerido")]
		public Int64 ID_DEP_NACIMIENTO { get; set; }

		[Display(Name = "Ciudad nacimiento")]
		[Required(ErrorMessage = "Municipio nacimiento requerido")]
		public Int64 ID_MCPO_NACIMIENTO { get; set; }

		public SelectList ListaMunicipioNac { get; set; }

		[Display(Name = "Estado civil")]
		[Required(ErrorMessage = "Estado civil requerido")]
		public Int64 ID_ESTADO_CIVIL { get; set; }

		[Display(Name = "Profesión u ocupación")]
		[Required(ErrorMessage = "Profesión requerido")]
		public Int64 ID_PROFESION { get; set; }

		[Display(Name = "Empresa donde trabaja")]
		[MaxLength(40)]
		[Required(ErrorMessage = "Empresa donde trabaja requerido")]
		public string NOMBRE_EMPRESA { get; set; }

		//[Display(Name = "Dirección empresa")]
		//public string DIRECCION_EMPRESA { get; set; }
		[Required(ErrorMessage = "Actividad económica requerida")]
		public Int64 ID_ACT_ECONOMICA { get; set; }

		[Display(Name = "Código CIIU")]
		[Required(ErrorMessage = "Código CIUU requerido")]
		public Int64 ID_CODIGO_CIIU { get; set; }

		public SelectList ListaoCodigoCiiu { get; set; }

		[Display(Name = "Teléfono residencia")]
		[MaxLength(20)]
        [StringLength(7, ErrorMessage = "La longitud del teléfono de la residencia debe ser de 7 caracteres", MinimumLength = 7)]
        public string TEL_RESIDENCIA { get; set; }

		[Required(ErrorMessage = "Departamento residencia requerido")]
		public Int64 ID_DEP_RESIDENCIA { get; set; }

		[Display(Name = "Ciudad residencia")]
		[Required(ErrorMessage = "Municipio residencia requerido")]
		public Int64 ID_MCPO_RESIDENCIA { get; set; }

		public SelectList ListaMunicipioResidencia { get; set; }

		[Display(Name = "Tipo empresa")]
		[Required(ErrorMessage = "Tipo empresa requerido")]
		public Int64 ID_TIPO_EMPRESA { get; set; }

		[Display(Name = "Dependencia")]
		[Required(ErrorMessage = "Dependencia requerido")]
		[MaxLength(100)]
		public string DEPENDENCIA { get; set; }

		[Display(Name = "Cargo")]
		[MaxLength(40)]
		[Required(ErrorMessage = "Cargo requerido")]
		public string CARGO { get; set; }

		[Display(Name = "Dirección empresa")]
		[Required(ErrorMessage = "Dirección requerido")]
		[MaxLength(100)]
		public string DIRECCION_EMPRESA { get; set; }

		[Required(ErrorMessage = "Departamento Emprea requerido")]
		public Int64 ID_DEP_EMPRESA { get; set; }

		[Display(Name = "Ciudad empresa")]
		[Required(ErrorMessage = "Municipio empresa requerido")]
		public Int64 ID_MCPO_EMPRESA { get; set; }

		public SelectList ListaMunicipioEmpresa { get; set; }

		[Display(Name = "Teléfono empresa")]
		[Required(ErrorMessage = "Teléfono empresa requerido")]
		[MaxLength(40)]
        [StringLength(7, ErrorMessage = "La longitud del teléfono de la empresa debe ser de 7 caracteres", MinimumLength = 7)]
        public string TELEFONO_EMPRESA { get; set; }

		[Display(Name = "Exensión empresa")]
		[MaxLength(40)]
        [StringLength(5, ErrorMessage = "La longitud de la extensión de la empresa debe ser mínimo de 3 caracteres y máximo de 5", MinimumLength = 3)]
        public string EXTENSION_EMPRESA { get; set; }

		[Display(Name = "Celular empresa")]
		[MaxLength(40)]
        [StringLength(10, ErrorMessage = "La longitud del celular de la empresa debe ser de 10 caracteres", MinimumLength = 10)]
        public string CELULAR_EMPRESA { get; set; }

		[Display(Name = "Fax empresa")]
		[MaxLength(40)]
        [StringLength(7, ErrorMessage = "La longitud del fax de la empresa debe ser de 7 caracteres", MinimumLength = 7)]
        public string FAX_EMPRESA { get; set; }

		[Display(Name = "¿Es usted una persona expuesta políticamente? (Decreto 1674 de 2016)")]
		[Required(ErrorMessage = "Requerido")]
		public int DECRETO_1674 { get; set; }

		[Display(Name = "¿Es usted representante legal de una organización internacional?")]
		[Required(ErrorMessage = "Requerido")]
		public int REP_ORG_INTERNACIONAL { get; set; }

		[Display(Name = "¿Es usted una persona que goza de reconocimiento público?")]
		[Required(ErrorMessage = "Requerido")]
		public int RECONOCIMIENTO_PUB { get; set; }

		[Display(Name = "¿Existe algún vínculo entre usted y una persona públicamente expuesta?")]
		[Required(ErrorMessage = "Requerido")]
		public int VINCULO_PEP { get; set; }

		[Display(Name = "Entidad")]
		[MaxLength(100)]
		public string ENTIDAD_PEP { get; set; }

		[Display(Name = "Id Cargo")]	
		public Int64? ID_CARGO_PEP { get; set; }

		[Display(Name = "Fecha vinculación")]
		public string FEC_VINCULA_PEP { get; set; }

		[Display(Name = "Fecha desvinculación")]
		public string FEC_DESVINCULA_PEP { get; set; }

		public List<RelacionadoPepViewModel> RelacionadosPep { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if ((DECRETO_1674 ==1 || REP_ORG_INTERNACIONAL == 1 || RECONOCIMIENTO_PUB == 1) && string.IsNullOrEmpty(ENTIDAD_PEP))
				yield return new ValidationResult("Entidad es requerida");

			if ((DECRETO_1674 == 1 || REP_ORG_INTERNACIONAL == 1 || RECONOCIMIENTO_PUB == 1) && (ID_CARGO_PEP == 0 || ID_CARGO_PEP == null) )
				yield return new ValidationResult("Cargo es requerido");

			if ((DECRETO_1674 == 1 || REP_ORG_INTERNACIONAL == 1 || RECONOCIMIENTO_PUB == 1) && string.IsNullOrEmpty(FEC_VINCULA_PEP))
				yield return new ValidationResult("Fecha vinculación es requerida");

            //if ((DECRETO_1674 == 1 || REP_ORG_INTERNACIONAL == 1 || RECONOCIMIENTO_PUB == 1) && (RelacionadosPep == null || (RelacionadosPep != null && RelacionadosPep.Count == 0)))
            //    yield return new ValidationResult("Debe agregar por lo menos un relacionado PEP");
        }
		#endregion
	}
}