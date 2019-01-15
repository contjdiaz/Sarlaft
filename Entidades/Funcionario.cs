using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Funcionario : BaseEntidades
    {
        [Display(Name = "Id")]
        public int ID_FUNCIONARIO { get; set; }

        [Display(Name = "Primer nombre")]
        [StringLength(200)]
        public string PRIMER_NOMBRE { get; set; }

        [Display(Name = "Segundo nombre")]
        [StringLength(200)]
        public string SEGUNDO_NOMBRE { get; set; }

        [Display(Name = "Primer apellido")]
        [StringLength(200)]
        public string PRIMER_APELLIDO { get; set; }

        [Display(Name = "Segundo apellido")]
        [StringLength(200)]
        public string SEGUNDO_APELLIDO { get; set; }

        [Display(Name = "Cargo")]
        [StringLength(200)]
        public string CARGO { get; set; }

        [Display(Name = "Area")]
        [StringLength(200)]
        public string AREA { get; set; }

        [Display(Name = "Usuario")]
        [StringLength(200)]
        public string LOGUIN { get; set; }

          [Display(Name = "Password")]
        [StringLength(200)]
        public string PASSWORD { get; set; }
    }
}



