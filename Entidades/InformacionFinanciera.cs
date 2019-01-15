using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class InformacionFinanciera : BaseEntidades
    {
        [Display(Name = "Id")]
        public Int64 ID_FINANCIERA { get; set; }

        [Display(Name = "Total activos")]
        public decimal TOTAL_ACTIVOS { get; set; }

        [Display(Name = "Total pasivos")]
        public decimal TOTAL_PASIVOS { get; set; }

        [Display(Name = "Total patrimonio")]
        public decimal TOTAL_PATRIMONIO { get; set; }

        [Display(Name = "Ingresos mensuales")]
        public decimal INGRESOS_MENSUALES { get; set; }

        [Display(Name = "Egresos mensuales")]
        public decimal EGRESOS_MENSUALES { get; set; }

        [Display(Name = "Otros ingresos mensuales")]
        public decimal OTROS_INGRESOS_MENSUALES { get; set; }

        [Display(Name = "Otros conceptos")]
        public string OTROS_CONCEPTOS { get; set; }

    }
}
