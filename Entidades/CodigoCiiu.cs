using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class CodigoCiiu : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_CODIGO_CIIU { get; set; }

		[Display(Name = "Código")]
		public string CODIGO_CIIU { get; set; }

		[Display(Name = "Nombre")]
		public string NOMBRE_CODIGO_CIIU { get; set; }

		public string CIIU {
			get { return this.CODIGO_CIIU + " " + this.NOMBRE_CODIGO_CIIU; }
		}
	}
}
