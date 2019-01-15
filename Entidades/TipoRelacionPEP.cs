using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
    public class TipoRelacionPEP: BaseEntidades
    {
        [Display(Name = "Id")]
        [Key]
        public Int64 ID_TIPO_REL_PEP { get; set; }


        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE_TIPO_REL_PEP { get; set; }

        [Required]
        [Display(Name = "ES_NATURAL")]
        public int ES_NATURAL { get; set; }

        [Required]
        [Display(Name = "ES_JURIDICA")]
        public int ES_JURIDICA { get; set; }
    }
}
