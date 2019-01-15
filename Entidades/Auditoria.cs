using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auditoria:BaseEntidades
    {
        public Int64 ID_AUDITORIA { get; set; }
        public Int64 ID_TIPO_REGISTRO { get; set; }
        public string REGISTRO_ORIGINAL { get; set; }
        public string REGISTRO_MODIFICADO { get; set; }
        public DateTime FECHA { get; set; }
        public Int64? ID_USUARIO { get; set; }
    }
}
