using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class OficinaIcetex
	{
		[Display(Name = "Id")]
		public decimal ID_OFICINA_ICETEX { get; set; }

		[Display(Name = "Nombre")]
		public string NOMBRE_OFICINA_ICETEX { get; set; }		
	}
}
