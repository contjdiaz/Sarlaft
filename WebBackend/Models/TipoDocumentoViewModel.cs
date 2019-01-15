using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBackend.Models
{
    public class TipoDocumentoViewModel
    {
        
        [Display(Name = "Id")]
        [Key]
        public Int64 ID_TIPO_DOCUMENTO { get; set; }

        [Required]
        [Display(Name = "Código")]
        [StringLength(4, ErrorMessage = "Solo cuatro letras")]
        public string CODIGO { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE_TIPO_DOCUMENTO { get; set; }

        [Required]
        [Display(Name = "Tipo Persona")]
        public string CODIGO_TIPO_PERSONA { get; set; }

        //[Required]
        //[Display(Name = "Tipo Persona")]
        //public Int64 ID_TIPO_PERSONA { get; set; }

        //public SelectList ListaTipoPersona { get; set; }

        public int EsValido { get; set; }
    }
}