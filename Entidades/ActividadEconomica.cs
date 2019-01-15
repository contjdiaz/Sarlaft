using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class ActividadEconomica : BaseEntidades
	{
		[Display(Name = "Id")]
		public Int64 ID_ACTIVIDAD_ECONOMICA { get; set; }	

		[Display(Name = "Nombre")]
		public string NOMBRE_ACTIVIDAD_ECONOMICA { get; set; }
	}
}
