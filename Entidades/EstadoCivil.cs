using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class EstadoCivil : BaseEntidades
	{
		[Display(Name = "Id")]
		public decimal ID_ESTADO_CIVIL { get; set; }	

		[Display(Name = "Nombre")]
		public string NOMBRE_ESTADO_CIVIL { get; set; }
	}
}
