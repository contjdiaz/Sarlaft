using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Menu
    {
        public Int64 ID_MENU { get; set; }
        public Int64? ID_MENU_PADRE { get; set; }
        public string NOMBRE_MENU { get; set; }
        public string CONTROLADOR_MENU { get; set; }
        public string NOMBRE_ACCION_MENU { get; set; }
        public int ADICIONAR { get; set; }
        public int CONSULTAR { get; set; }
        public int EDITAR { get; set; }
        public int ELIMINAR { get; set; }
    }
}
