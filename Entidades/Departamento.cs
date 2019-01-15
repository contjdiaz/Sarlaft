using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Departamento : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_DEPARTAMENTO { get; set; }	

		[Display(Name = "Codigo")]
		public string CODIGO_DEPARTAMENTO { get; set; }

		[Display(Name = "Nombre")]
		public string NOMBRE_DEPARTAMENTO { get; set; }
	}
}
