using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class TipoDocumento: BaseEntidades
	{
		[Display(Name = "Id")]
		[Key]
		public Int64 ID_TIPO_DOCUMENTO { get; set; }

		[Required]
		[Display(Name = "Código")]
		[StringLength(5, ErrorMessage ="Solo cinco letras")]
		public string CODIGO { get; set; }

		[Required]
		[Display(Name = "Nombre")]
		public string NOMBRE_TIPO_DOCUMENTO { get; set; }

		[Required]
		[Display(Name = "ES_NATURAL")]
		public int ES_NATURAL { get; set; }

		[Required]
		[Display(Name = "ES_JURIDICA")]
		public int ES_JURIDICA { get; set; }
	}
}
