using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class OperacionLN
    {
        OperacionAD Datos = new OperacionAD();
        AuditoriaLN auditoriaLogica = new AuditoriaLN();
        public Operacion OperacionInsertar(Operacion P)
        {
            //llamado a ValidaObjeto
            P.mensajeNotificacion = ObjetoValida(P);
            if (!String.IsNullOrWhiteSpace(P.mensajeNotificacion))
            {
                P.tipoMensaje = 3;
                return P;
            }

            auditoriaLogica.ObjetoAuditoriaInsertar(P);
            return Datos.OperacionInsertar(P);
        }

        public List<Operacion> OperacionConsultar(Int64 Id_persona)
        {
            return Datos.OperacionConsultar(Id_persona);
        }

        public Operacion OperacionConsultarPorID(Int64 id)
        {
            return Datos.OperacionConsultarPorID(id);
        }

        public Operacion OperacionActualizar(Operacion Objeto)
        {
            auditoriaLogica.ObjetoAuditoriaEditar(Objeto, OperacionConsultarPorID(Objeto.ID_OPERACION));
            return Datos.OperacionActualizar(Objeto);
        }

        public Operacion OperacionEliminar(Operacion Objeto)
        {
            auditoriaLogica.ObjetoAuditoriaEliminar(Objeto);
            return Datos.OperacionEliminar(Objeto);
        }

        public string ObjetoValida(Operacion objeto)
        {
            List<string> ListaErrores = new List<string>();

            //Valida la existencia del Registro
            if (objeto == null)
            {
                ListaErrores.Add("El Objeto esta en blanco");
            }
            else
            {
                if (objeto.ID_PERSONA == 0)
                {
                    ListaErrores.Add("El tipo de objeto no puede estar en blanco");
                }


                if (string.IsNullOrWhiteSpace(objeto.ENTIDAD_FINANCIERA))
                {
                    ListaErrores.Add("El nombre del objeto esta en blanco");
                }

                if (string.IsNullOrWhiteSpace(objeto.NUMERO_PRODUCTO))
                {
                    ListaErrores.Add("La descripción no puede estar en blanco");
                }

                if (string.IsNullOrWhiteSpace(objeto.TIPO_PRODUCTO))
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
