using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
    public class CargoPEP : BaseEntidades
    {
        [Display(Name = "Id")]
        [Key]
        public Int64 ID_CARGO_PEP { get; set; }


        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE_CARGO_PEP { get; set; }
    }
}
