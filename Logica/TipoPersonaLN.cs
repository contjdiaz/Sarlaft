using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoPersonaLN
    {
		TipoPersonaAD Datos = new TipoPersonaAD();
      
        //public List<TipoPersona> TipoPersonaConsultar()
        //{
        //    return Datos.TipoPersonaConsultar();
        //}

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

        public string TipoPersonaValida(TipoPersona objeto)
        {
            List<string> ListaErrores = new List<string>();

            //Valida la existencia del Registro
            if (objeto == null)
            {
                ListaErrores.Add("El Objeto esta en blanco");
            }
            else
            {
                if (objeto.ID_TIPO_PERSONA == 0)
                {
                    ListaErrores.Add("El tipo de objeto no puede estar en blanco");
                }

                if (string.IsNullOrWhiteSpace(objeto.NOMBRE_TIPO_PERSONA))
                {
                    ListaErrores.Add("El nombre no puede esta en blanco");
                }

                if (string.IsNullOrWhiteSpace(objeto.CODIGO_TIPO_PERSONA))
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
