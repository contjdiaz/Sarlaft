using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
	public class PersonaLN
	{
		PersonaAD Datos = new PersonaAD();

		public Persona PersonaInsertar(Persona persona)
		{
			return Datos.PersonaInsertar(persona);
		}

		public List<Persona> PersonaConsultar()
		{
			return Datos.PersonaConsultar();
		}

		public Persona PersonaConsultarPorID(Int64 id)
		{
			return Datos.PersonaConsultarPorID(id);
		}

        public Persona PersonaConsultarPorTipoDocumento(Int64 idTipoDocumento, string documento)
        {
            return Datos.PersonaConsultarPorTipoDocumento(idTipoDocumento, documento);
        }

        public Persona PersonaActualizar(Persona p)
		{
			return Datos.PersonaActualizar(p);
		}

        public List<PersonaConsulta> PersonaConsultarParametros(Int64 idtipoDocumento = 0, Int64 idtipoPersona = 0, string numeroDocumento = "")
        {
            List<PersonaConsulta> lista = new List<PersonaConsulta>();
            if (numeroDocumento == null) numeroDocumento = string.Empty;
            //lista.Add(new PersonaConsulta { ID_PERSONA = 1, ID_TIPO_DOCUMENTO = 1, NOMBRE_TIPO_DOCUMENTO = "cc",NOMBRE_TIPO_PERSONA="Natural", NUMERO_DOCUMENTO="123456",NOMBRE="Sandra" });
            return Datos.PersonaConsultarParametros(idtipoDocumento, idtipoPersona, numeroDocumento);
            //return lista;
        }

    }
}
