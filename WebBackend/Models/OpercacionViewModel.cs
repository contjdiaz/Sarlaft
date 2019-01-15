using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBackend.Models
{
    public class OpercacionViewModel : BaseEntidades
    {
        [Display(Name = "Id")]
        public Int64 ID_OPERACION { get; set; }

        [Display(Name = "Id persona")]
        public Int64 ID_PERSONA { get; set; }

        [Display(Name = "Tipo operación")]
        public string ID_TIPO_OPERACIONES { get; set; }

        [Display(Name = "Tipo moneda")]
        public string ID_TIPO_MONEDA { get; set; }

        [Display(Name = "Entidad financiera")]
        [StringLength(100, ErrorMessage = "La longitud de la entidad financiera debe ser mínimo de 3 caracteres y máximo de 100", MinimumLength = 3)]
        public string ENTIDAD_FINANCIERA { get; set; }

        [Display(Name = "Número producto")]
        [StringLength(40, ErrorMessage = "La longitud del número de prodcuto debe ser mínimo de 3 caracteres y máximo de 40", MinimumLength = 3)]
        public string NUMERO_PRODUCTO { get; set; }

        [Display(Name = "País")]
        [StringLength(40, ErrorMessage = "La longitud del país debe ser mínimo de 3 caracteres y máximo de 40", MinimumLength = 3)]
        public string PAIS { get; set; }

        [Display(Name = "Ciudad")]
        [StringLength(40, ErrorMessage = "La longitud de la ciudad debe ser mínimo de 3 caracteres y máximo de 40", MinimumLength = 3)]
        public string CIUDAD { get; set; }

        [Display(Name = "Monto")]
        public string MONTO { get; set; }

        [Display(Name = "Tipo producto")]
        [StringLength(40, ErrorMessage = "La longitud del tipo de prodcuto debe ser mínimo de 3 caracteres y máximo de 40", MinimumLength = 3)]
        public string TIPO_PRODUCTO { get; set; }
    }
}