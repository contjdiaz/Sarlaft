using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ObjetoLN
    {
        ObjetoAD Datos = new ObjetoAD();

        public Objeto ObjetoInsertar(Objeto P)
        {
            //llamado a ValidaObjeto
            P.mensajeNotificacion = ObjetoValida(P);
            if (!String.IsNullOrWhiteSpace(P.mensajeNotificacion))
            {
                P.tipoMensaje = 3;
                return P;
            }
            return Datos.ObjetoInsertar(P); 
        }

        public List<Objeto> ObjetoConsultar(Objeto P)
        {
            return Datos.ObjetoConsultar(P);
        }

        public Objeto ObjetoConsultarPorID(Int64 id)
        {
            return Datos.ObjetoConsultarPorID(id);
        }

        public Objeto ObjetoActualizar(Objeto Objeto)
        {
            return Datos.ObjetoActualizar(Objeto);
        }

        public Objeto ObjetoEliminar(Objeto Objeto)
        {
            return Datos.ObjetoEliminar(Objeto);
        }

        public string ObjetoValida(Objeto objeto)
        {
            List<string> ListaErrores = new List<string>();

            //Valida la existencia del Registro
            if (objeto == null)
            {
                ListaErrores.Add("El Objeto esta en blanco");
            }
            else
            {
                if (objeto.ID_TIPO_OBJETO == 0)
                {
                    ListaErrores.Add("El tipo de objeto no puede estar en blanco");
                }


                if (string.IsNullOrWhiteSpace(objeto.NOMBRE_OBJETO))
                {
                    ListaErrores.Add("El nombre del objeto esta en blanco");
                }

                if (string.IsNullOrWhiteSpace(objeto.DESCRIPCION))
                {
                    ListaErrores.Add("La descripción no puede estar en blanco");
                }

                if (string.IsNullOrWhiteSpace(objeto.UBICACION))
                {
                    ListaErrores.Add("La ubicación no puede estae en blanco");
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
