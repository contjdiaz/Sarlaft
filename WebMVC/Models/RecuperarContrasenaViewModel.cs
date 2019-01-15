using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class RecuperarContrasenaViewModel
    {
        #region Properties

        [Required]
        [StringLength(512)]
        [EmailAddress(ErrorMessage = "Por favor ingrese un correo valido.")]
        [Display(Name = "Correo electrónico:")]
        public string CorreoElectronico { get; set; }

        #endregion
    }
}