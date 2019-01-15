using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class PersonaNatural : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_NATURAL { get; set; }

		[Display(Name = "Id")]
		public Int64 ID_PERSONA { get; set; }

		[Display(Name = "Priemer nombre")]
		public string PRIMER_NOMBRE { get; set; }

		[Display(Name = "Segundo nombre")]
		public string SEGUNDO_NOMBRE { get; set; }

		[Display(Name = "Primer apellido")]
		public string PRIMER_APELLIDO { get; set; }

		[Display(Name = "Segundo apellido")]
		public string SEGUNDO_APELLIDO { get; set; }

		[Display(Name = "Sexo")]
		public Int64 ID_SEXO { get; set; }

		[Display (Name = "Fecha expedición")]
		public DateTime FEC_EXPEDICION { get; set; }

		[Display(Name = "Fecha nacimiento")]
		public DateTime FEC_NACIMIENTO { get; set; }

		[Display(Name = "Dirección residencia")]
		public string DIR_RESIDENCIA { get; set; }

		[Display(Name = "Correo")]
		public string CORREO { get; set; }

		[Display(Name = "Teléfono")]
		public string TELEFONO { get; set; }

		[Display(Name = "Celular")]
		public string CELULAR { get; set; }

		[Display(Name = "Municipio expedición")]
		public Int64 ID_MCPO_EXPEDICION { get; set; }

		[Display(Name = "Municipio nacimiento")]
		public Int64 ID_MCPO_NACIMIENTO { get; set; }

		[Display(Name = "Estado civil")]
		public Int64 ID_ESTADO_CIVIL { get; set; }

		[Display(Name = "Profesión")]
		public Int64 ID_PROFESION { get; set; }

		//[Display(Name = "Empresa empleo")]
		//public string EMPRESA_EMPLEO { get; set; }

		//[Display(Name = "Dirección empresa")]
		//public string DIRECCION_EMPRESA { get; set; }

		[Display(Name = "Código CIUU")]
		public Int64 ID_CODIGO_CIIU { get; set; }

		[Display(Name = "Teléfono residencia")]
		public string TEL_RESIDENCIA { get; set; }

		[Display(Name = "Municipio residencia")]
		public Int64 ID_MCPO_RESIDENCIA { get; set; }

		[Display(Name = "Nombre empresa")]
		public string NOMBRE_EMPRESA { get; set; }

		[Display(Name = "Tipo empresa")]
		public Int64 ID_TIPO_EMPRESA { get; set; }

		[Display(Name = "Dependencia")]
		public string DEPENDENCIA { get; set; }

		[Display(Name = "Cargo")]
		public string CARGO { get; set; }

		[Display(Name = "Dirección empresa")]
		public string DIRECCION_EMPRESA { get; set; }

		[Display(Name = "Municipio empresa")]
		public Int64 ID_MCPO_EMPRESA { get; set; }

		[Display(Name = "Teléfono empresa")]
		public string TELEFONO_EMPRESA { get; set; }
		
		[Display(Name = "Exensión empresa")]
		public string EXTENSION_EMPRESA { get; set; }

		[Display(Name = "Celular empresa")]
		public string CELULAR_EMPRESA { get; set; }

		[Display(Name = "Fax empresa")]
		public string FAX_EMPRESA { get; set; }

		[Display(Name = "Persona expuesta politicamente")]
		public int DECRETO_1674 { get; set; }

		[Display(Name = "Representante organización internacional")]
		public int REP_ORG_INTERNACIONAL { get; set; }

		[Display(Name = "Reconocimiento público")]
		public int RECONOCIMIENTO_PUB { get; set; }

		[Display(Name = "Vínculo PEP")]
		public int VINCULO_PEP { get; set; }

		[Display(Name = "Entidad PEP")]
		public string ENTIDAD_PEP { get; set; }

		//[Display(Name = "Cargo PEP")]
		//public string CARGO_PEP { get; set; }

		[Display(Name = "Id Cargo PEP")]
		public Int64? ID_CARGO_PEP { get; set; }

		[Display(Name = "Fecha vinculación PEP")]
		public DateTime? FEC_VINCULA_PEP { get; set; }

		[Display(Name = "Fecha desvinculación PEP")]
		public DateTime? FEC_DESVINCULA_PEP { get; set; }
	}
}
