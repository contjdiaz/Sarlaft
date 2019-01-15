using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoDocumentoLN
    {
        TipoDocumentoAD Datos = new TipoDocumentoAD();

        public TipoDocumento TipoDocumentoInsertar(TipoDocumento P)
        {
            //llamado a ValidaObjeto
            //P.mensajeNotificacion = TipoDocumentoValida(P);
            //if (!String.IsNullOrWhiteSpace(P.mensajeNotificacion))
            //{
            //    P.tipoMensaje = 3;
            //    return P;
            //}
            return Datos.TipoDocumentoInsertar(P); 
        }

        public TipoDocumento TipoDocumentoActualizar(TipoDocumento P)
        {
            TipoDocumento tp = new TipoDocumento();
            if (P.ID_TIPO_DOCUMENTO == 0)
            {
                tp = TipoDocumentoInsertar(P);
            }
            else tp =Datos.TipoDocumentoActualizar(P);

            return tp;
        }

        public List<TipoDocumento> TipoDocumentoConsultar(string codigoTipoPersona)
        {
            return Datos.TipoDocumentoConsultar(codigoTipoPersona);
        }

        public List<TipoDocumento> TiposDocumentos()
        {
            return Datos.TiposDocumentos();
        }

        public TipoDocumento TipoDocumentoPorCodigoConsultar(string codigoTipoDocumento)
		{
			return Datos.TipoDocumentoPorCodigoConsultar(codigoTipoDocumento);
		}


		public TipoDocumento TipoDocumentoPorIdConsultar(Int64 idTipoDocumento)
		{
			return Datos.TipoDocumentoPorIdConsultar(idTipoDocumento);
		}
		//public Objeto ObjetoConsultarPorID(Int64 id)
		//{
		//    return Datos.ObjetoConsultarPorID(id);
		//}

		//public Objeto ObjetoActualizar(Objeto Objeto)
		//{
		//    return Datos.ObjetoActualizar(Objeto);
		//}

		//public Objeto ObjetoEliminar(Objeto Objeto)
		//{
		//    return Datos.ObjetoEliminar(Objeto);
		//}

		public string TipoDocumentoValida(TipoDocumento objeto)
        {
            List<string> ListaErrores = new List<string>();

            //Valida la existencia del Registro
            if (objeto == null)
            {
                ListaErrores.Add("El Objeto esta en blanco");
            }
            else
            {
                if (objeto.ID_TIPO_DOCUMENTO == 0)
                {
                    ListaErrores.Add("El tipo de objeto no puede estar en blanco");
                }


                if (string.IsNullOrWhiteSpace(objeto.NOMBRE_TIPO_DOCUMENTO))
                {
                    ListaErrores.Add("El nombre del tipo documento esta en blanco");
                }

                if (string.IsNullOrWhiteSpace(objeto.CODIGO))
                {
                    ListaErrores.Add("El código no puede estar en blanco");
                }
               
            }
            if (ListaErrores.Count > 0)
            {
                return String.Join(";", ListaErrores);
            }
            else
            {
                return String.Empty; 
            }
            
        }

    }
}
