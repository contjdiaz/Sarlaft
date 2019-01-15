using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Municipo : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_MUNICIPIO { get; set; }	

		[Display(Name = "IdDepartamento")]
		public Int64 ID_DEPARTAMENTO { get; set; }

		[Display(Name = "IdDistrito")]
		public Int64 ID_DISTRITO { get; set; }

		[Display(Name = "IdTipoMunicipio")]
		public Int64 ID_TIPO_MUNICIPIO { get; set; }

		[Display(Name = "Codido")]
		public string CODIGO_MUNICIPIO { get; set; }

		[Display(Name = "Nombre")]
		public string NOMBRE_MUNICIPIO { get; set; }

		[Display(Name = "AREA_M2")]
		public decimal AREA_M2 { get; set; }

		[Display(Name = "LATITUD")]
		public decimal LATITUD { get; set; }

		[Display(Name = "LONGITUD")]
		public decimal LONGITUD { get; set; }
	}
}
