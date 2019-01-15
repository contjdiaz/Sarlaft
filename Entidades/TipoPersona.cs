using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class TipoPersona: BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_TIPO_PERSONA { get; set; }

		[Display(Name = "Código")]
		public string CODIGO_TIPO_PERSONA { get; set; }

		[Display(Name = "Nombre")]
		public string NOMBRE_TIPO_PERSONA { get; set; }
	}
}
