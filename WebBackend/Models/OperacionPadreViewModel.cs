using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebBackend.Models
{
    public class OperacionPadreViewModel : BaseEntidades
    {
        [Display(Name = "Id persona")]
        public Int64 ID_PERSONA { get; set; }

        public string MonedaExtranjera { get; set; }
    }
}