using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Objeto:BaseEntidades
    {
        [Display(Name = "Id")]
        public decimal ID_OBJETO { get; set; }

        [Display(Name = "Tipo Objeto")]
        public decimal ID_TIPO_OBJETO { get; set; }

        [Display(Name = "Nombre")]
        public string NOMBRE_OBJETO { get; set; }

        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }

        [Display(Name = "Ubicación")]
        public string UBICACION { get; set; }

        [Display(Name = "Origen")]
        public string ORIGEN_OBJETO { get; set; }
    }
}
