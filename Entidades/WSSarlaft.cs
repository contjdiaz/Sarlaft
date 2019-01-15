using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class WSSarlaft : BaseEntidades
    {
        [Display(Name = "ID REGISTRO")]
        public long IDREGISTRORESP { get; set; }


        [Display(Name = "LISTA CLINTON")]
        public string LISTA_CLINTON { get; set; }


        [Display(Name = "OTROS ORGANISMOS")]
        public string OTROS_ORGANISMOS { get; set; }


        [Display(Name = "LINK")]
        public string LINK_R { get; set; }


        [Display(Name = "DETALLE OTROS")]
        public string DETALLE_OTROS { get; set; }


        [Display(Name = "DETALLE US")]
        public string DETALLE_US { get; set; }


        [Display(Name = "IDENTIFICACION")]
        public string IDENTIFICACION { get; set; }

        [Display(Name = "FECHA CONSULTA")]
        public DateTime FECHA_CONSULTA { get; set; }

    }
}
