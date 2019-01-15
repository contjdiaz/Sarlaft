using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class TipoEmpresa : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_TIPO_EMPRESA { get; set; }		

		[Display(Name = "Nombre")]
		public string NOMBRE_TIPO_EMPRESA { get; set; }
	}
}
