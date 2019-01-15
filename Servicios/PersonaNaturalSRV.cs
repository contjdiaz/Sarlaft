using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
	public class PersonaNaturalSRV
	{
		PersonaNaturalLN PersonaNaturalLN = new PersonaNaturalLN();

		public PersonaNatural PersonaNaturalInsertar(PersonaNatural personaNatural, Persona persona, List<RelacionadoPep> listaRelacionadoPep)
		{
			return PersonaNaturalLN.PersonaNaturalInsertar(personaNatural,persona, listaRelacionadoPep);
		}

        public PersonaNatural RepresentanteLegalInsertar(Int64 IdPersosnaJuridica, PersonaNatural personaNatural, Persona persona, List<RelacionadoPep> listaRelacionadoPep)
        {
            return PersonaNaturalLN.RepresentanteLegalInsertar(IdPersosnaJuridica, personaNatural, persona, listaRelacionadoPep);
        }

        public List<PersonaNatural> PersonaNatrualConsultar()
		{
			return PersonaNaturalLN.PersonaNaturalConsultar();
		}

		public PersonaNatural PersonaNaturalConsultarPorID(Int64 id)
		{
			return PersonaNaturalLN.PersonaNaturalConsultarPorID(id);
		}

        public PersonaNatural PersonaNaturalConsultarPorIdPersona(Int64 idPersona)
        {
            return PersonaNaturalLN.PersonaNaturalConsultarPorIdPersona(idPersona);
        }

        public PersonaNatural PersonaNaturalPorIdentificacionConsultar(Int64 idTipoDocumento, string numeroDocumento)
		{
			return PersonaNaturalLN.PersonaNaturalPorIdentificacionConsultar(idTipoDocumento, numeroDocumento);
		}
	}
}
