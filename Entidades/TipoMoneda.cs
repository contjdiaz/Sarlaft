using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class TipoMoneda : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_TIPO_MONEDA { get; set; }

		[Display(Name = "Código")]
		public string CODIGO { get; set; }

		[Display(Name = "Nombre")]
		public string NOMBRE_TIPO_MONEDA { get; set; }
	}
}
