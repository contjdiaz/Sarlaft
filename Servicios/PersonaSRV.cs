using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
	public class PersonaSRV
	{
		PersonaLN PersonaLN = new PersonaLN();

		public Persona PersonaInsertar(Persona persona)
		{
			return PersonaLN.PersonaInsertar(persona);
		}

		public List<Persona> PersonaConsultar()
		{
			return PersonaLN.PersonaConsultar();
		}

		public Persona PersonaConsultarPorID(Int64 id)
		{
			return PersonaLN.PersonaConsultarPorID(id);
		}


        public Persona PersonaConsultarPorTipoDocumento(Int64 idTipoDocumento, string documento)
        {
            return PersonaLN.PersonaConsultarPorTipoDocumento(idTipoDocumento, documento);
        }
        public Persona PersonaActualizar(Persona p)
		{
			return PersonaLN.PersonaActualizar(p);
		}

        public List<PersonaConsulta> PersonaConsultarParametros(Int64 idtipoDocumento = 0, Int64 idtipoPersona = 0, string numeroDocumento = "")
        {
            return PersonaLN.PersonaConsultarParametros(idtipoDocumento, idtipoPersona, numeroDocumento);
        }
    }
}
