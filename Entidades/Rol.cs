using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol : BaseEntidades
    {
        public Int64 ID_ROL { get; set; }       
        public string NOMBRE_ROL { get; set; }
        public DateTime FECHA { get; set; }
        public Int64 ID_USUARIO { get; set; }
      
    }
}
