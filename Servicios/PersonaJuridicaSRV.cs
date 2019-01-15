using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PersonaJuridicaSRV
    {
        PersonaJuridicaLN PersonaJuridicaLN = new PersonaJuridicaLN();

        public PersonaJuridica PersonaJuridicaInsertar(PersonaJuridica personaJuridica, Persona persona)
        {
            return PersonaJuridicaLN.PersonaJuridicaInsertar(personaJuridica, persona);
        }

        public List<PersonaJuridica> PersonaJuridicaConsultar()
        {
            return PersonaJuridicaLN.PersonaJuridicaConsultar();
        }

        public PersonaJuridica PersonaJuridicaConsultarPorID(Int64 id)
        {
            return PersonaJuridicaLN.PersonaJuridicaConsultarPorID(id);
        }

        public PersonaJuridica PersonaJuridicaConsultarPorPersonaID(Int64 idpersona)
        {
            return PersonaJuridicaLN.PersonaJuridicaConsultarPorPersonaID(idpersona);
        }

        public PersonaJuridica PersonaJuridicaPorIdentificacionConsultar(Int64 idTipoDocumento, string numeroDocumento)
        {
            return PersonaJuridicaLN.PersonaJuridicaPorIdentificacionConsultar(idTipoDocumento, numeroDocumento);
        }
    }
}
