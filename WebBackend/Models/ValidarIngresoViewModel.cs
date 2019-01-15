using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBackend.Models
{
	public class ValidarIngresoViewModel: BaseEntidades
	{
		[Display(Name = "Tipo Documento")]
		public List<TipoDocumento> TipoDocumento { get; set; }	
		
		public string CodigoTipoDocumento { get; set; }	

		[Required(ErrorMessage = "Documento requerido")]
		
		//[MaxLength(10,ErrorMessage ="Solo 10 números")]

		public string Documento { get; set; }

		[Display(Name = "Tipo Persona")]
		public List<TipoPersona> TipoPersona { get; set; }	
		
		public string CodigoTipoPersona { get; set; }
	}
}