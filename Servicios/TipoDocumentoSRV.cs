using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class TipoDocumentoSRV
    {
        TipoDocumentoLN tipoDocumentoLN = new TipoDocumentoLN();
        public TipoDocumento TipoDocumentoActualizar(TipoDocumento P)
        {
            return tipoDocumentoLN.TipoDocumentoActualizar(P);
        }

        public TipoDocumento TipoDocumentoInsertar(TipoDocumento P)
        {
            return tipoDocumentoLN.TipoDocumentoInsertar(P);
        }
    }
}
