using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad : BaseEntidades
    {
        [Display(Name = "Id")]
        public Int64 ID_MUNICIPIO { get; set; }

        [Display(Name = "Departamento Id")]
        public Int64 ID_DEPARTAMENTO { get; set; }

        [Display(Name = "Código")]
        public string CODIGO_MUNICIPIO { get; set; }

        [Display(Name = "Nombre")]
        public string NOMBRE_MUNICIPIO { get; set; }
    }
}
