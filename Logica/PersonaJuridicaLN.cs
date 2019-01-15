using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonaJuridicaLN
    {
        PersonaJuridicaAD Datos = new PersonaJuridicaAD();
        PersonaAD DatosPersona = new PersonaAD();
        ListasAD DatosListas = new ListasAD();
        RelacionadoPepAD DatosRelPep = new RelacionadoPepAD();
        AuditoriaLN auditoriaLogica = new AuditoriaLN();
        WSSarlaftLN WSSarlaftLN = new WSSarlaftLN();
        public PersonaJuridica PersonaJuridicaInsertar(PersonaJuridica personaJuridica, Persona persona)
        {
            try
            {
                persona.ID_TIPO_PERSONA = DatosListas.TipoPersonaPorCodigoConsultar("PJ").ID_TIPO_PERSONA;
                if (personaJuridica.ID_JURIDICA == 0)
                {
                    persona.FEC_DILIGENCIAMIENTO = DateTime.Now;
                    Persona pExiste = DatosPersona.PersonaConsultarPorTipoDocumento(persona.ID_TIPO_DOCUMENTO, persona.NUMERO_DOCUMENTO);
                    if (pExiste != null && pExiste.ID_PERSONA > 0)
                    {
                        personaJuridica.ID_PERSONA = pExiste.ID_PERSONA;
                    }
                    else
                    {
                        persona = DatosPersona.PersonaInsertar(persona);
                        personaJuridica.ID_PERSONA = persona.ID_PERSONA;
                        auditoriaLogica.ObjetoAuditoriaInsertar(persona);
                    }

                    personaJuridica = Datos.PersonaJuridicaInsertar(personaJuridica);
                    WSSarlaftLN.ConsultarListaClinton(persona.NUMERO_DOCUMENTO, string.Empty);
                    auditoriaLogica.ObjetoAuditoriaInsertar(personaJuridica);
                }
                else
                {
                    auditoriaLogica.ObjetoAuditoriaEditar(persona, DatosPersona.PersonaConsultarPorID(persona.ID_PERSONA));
                    auditoriaLogica.ObjetoAuditoriaEditar(personaJuridica, DatosPersona.PersonaConsultarPorID(personaJuridica.ID_JURIDICA));

                    persona = DatosPersona.PersonaActualizar(persona);
                    personaJuridica = Datos.PersonaJuridicaActualizar(personaJuridica);
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return personaJuridica;
        }

        public List<PersonaJuridica> PersonaJuridicaConsultar()
        {
            return Datos.PersonaJuridicaConsultar();
        }

        public PersonaJuridica PersonaJuridicaConsultarPorID(Int64 id)
        {
            return Datos.PersonaJuridicaConsultarPorID(id);
        }

        public PersonaJuridica PersonaJuridicaConsultarPorPersonaID(Int64 idpersona)
        {
            return Datos.PersonaJuridicaConsultarPorPersonaID(idpersona);
        }

        public PersonaJuridica PersonaJuridicaPorIdentificacionConsultar(Int64 idTipoDocumento, string numeroDocumento)
        {
            return Datos.PersonaJuridicaPorIdentificacionConsultar(idTipoDocumento, numeroDocumento);
        }
    }
}
