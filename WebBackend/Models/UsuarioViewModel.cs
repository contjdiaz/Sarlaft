using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBackend.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Id")]
        public Int64 ID_USUARIO { get; set; }

        [Display(Name = "Nombres")]
        [StringLength(40)]
        [Required(ErrorMessage = "Requerido")]
        public string NOMBRES_USUARIO { get; set; }

        [Display(Name = "Apellidos")]
        [StringLength(40)]
        [Required(ErrorMessage = "Requerido")]
        public string APELLIDOS_USUARIO { get; set; }

        [Display(Name = "Correo electrónico")]
        [StringLength(40)]
        [Required(ErrorMessage = "Requerido")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string EMAIL_USUARIO { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FECHA { get; set; }

        [Display(Name = "Usuario Acción")]
        public Int64 ID_USUARIO_ACCION { get; set; }

        [Display(Name = "Contraseña usuario")]
        [Required(ErrorMessage = "Requerido")]
        [StringLength(20, ErrorMessage = "La longitud de la contraseña debe ser mínimo de 4 carácteres y máximo de 20", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string PASSWORD_USUARIO { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Required(ErrorMessage = "Requerido")]
        [StringLength(20, ErrorMessage = "La longitud de la contraseña debe ser mínimo de 4 carácteres y máximo de 20", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare("PASSWORD_USUARIO", ErrorMessage = "El campo contraseña y confirmar contraseña no son iguales")]
        public string CONFIRMAR_CONTRASENA { get; set; }
    }
}