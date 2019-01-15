using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class WSSarlaftSRV
    {
        WSSarlaftLN Request = new WSSarlaftLN();

        public WSSarlaft InsertarRespuesta(WSSarlaft RObject)
        {
            return Request.InsertarRespuesta(RObject);
        }
    }
}
