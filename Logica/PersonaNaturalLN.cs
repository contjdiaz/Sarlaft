using Componentes;
using Datos;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
	public class PersonaNaturalLN
	{
		PersonaNaturalAD Datos = new PersonaNaturalAD();
        PersonaJuridicaAD  DatosJuridica = new PersonaJuridicaAD();
        PersonaAD DatosPersona = new PersonaAD();
		ListasAD DatosListas = new ListasAD();
        AuditoriaLN auditoriaLogica = new AuditoriaLN();        
        RelacionadoPepLN RelPepLogica = new RelacionadoPepLN();
        WSSarlaftLN WSSarlaftLN = new WSSarlaftLN();
        public PersonaNatural PersonaNaturalInsertar(PersonaNatural personaNatural, Persona persona, List<RelacionadoPep> listaRelacionadoPep)
		{
			try
			{
				persona.ID_TIPO_PERSONA = DatosListas.TipoPersonaPorCodigoConsultar("PN").ID_TIPO_PERSONA;
				if (personaNatural.ID_NATURAL == 0)
				{
					persona.FEC_DILIGENCIAMIENTO = DateTime.Now;
					Persona pExiste = DatosPersona.PersonaConsultarPorTipoDocumento(persona.ID_TIPO_DOCUMENTO, persona.NUMERO_DOCUMENTO);
					if (pExiste != null && pExiste.ID_PERSONA > 0)
					{
						personaNatural.ID_PERSONA = pExiste.ID_PERSONA;                       
                    }
					else
					{
						persona = DatosPersona.PersonaInsertar(persona);
						personaNatural.ID_PERSONA = persona.ID_PERSONA;                   
                        auditoriaLogica.ObjetoAuditoriaInsertar(persona);
                        WSSarlaftLN.ConsultarListaClinton(persona.NUMERO_DOCUMENTO, string.Empty);
                    }

					personaNatural = Datos.PersonaNaturalInsertar(personaNatural);                    
                    auditoriaLogica.ObjetoAuditoriaInsertar(personaNatural);
                }
				else
				{                   
                    auditoriaLogica.ObjetoAuditoriaEditar(persona, DatosPersona.PersonaConsultarPorID(persona.ID_PERSONA));
                    auditoriaLogica.ObjetoAuditoriaEditar(personaNatural, DatosPersona.PersonaConsultarPorID(personaNatural.ID_NATURAL));

                    persona = DatosPersona.PersonaActualizar(persona);
					personaNatural= Datos.PersonaNaturalActualizar(personaNatural);                    
                }

				if (persona.ID_PERSONA > 0)
				{                  

                    if (listaRelacionadoPep != null && listaRelacionadoPep.Count > 0)
					{
						foreach (RelacionadoPep item in listaRelacionadoPep)
						{
                            if (item.ID_RELACIONADO_PEP < 1)
                            {
                                item.ID_RELACIONADO_PEP = 0;
                                item.ID_PERSONA = persona.ID_PERSONA;
                                RelPepLogica.RelacionadoPepInsertar(item);
                                WSSarlaftLN.ConsultarListaClinton(item.DOCUMENTO, string.Empty);
                            }
                            else
                            {                                
                                RelPepLogica.RelacionadoPepActualizar(item);                               
                            }
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}		

			return personaNatural;
		}

        public PersonaNatural RepresentanteLegalInsertar(Int64 IdPersosnaJuridica, PersonaNatural personaNatural, Persona persona, List<RelacionadoPep> listaRelacionadoPep)
        {
            try
            {
                persona.ID_TIPO_PERSONA = DatosListas.TipoPersonaPorCodigoConsultar("PN").ID_TIPO_PERSONA;
                if (personaNatural.ID_NATURAL == 0)
                {
                    persona.FEC_DILIGENCIAMIENTO = DateTime.Now;
                    Persona pExiste = DatosPersona.PersonaConsultarPorTipoDocumento(persona.ID_TIPO_DOCUMENTO, persona.NUMERO_DOCUMENTO);
                    if (pExiste != null && pExiste.ID_PERSONA > 0)
                    {
                        personaNatural.ID_PERSONA = pExiste.ID_PERSONA;
                    }
                    else
                    {
                        persona.ID_MUNICIPIO = personaNatural.ID_MCPO_RESIDENCIA;
                        persona = DatosPersona.PersonaInsertar(persona);
                        personaNatural.ID_PERSONA = persona.ID_PERSONA;
                        WSSarlaftLN.ConsultarListaClinton(persona.NUMERO_DOCUMENTO, string.Empty);
                        auditoriaLogica.ObjetoAuditoriaInsertar(persona);
                    }

                    personaNatural = Datos.RepresentanteLegalInsertar(personaNatural);
                    auditoriaLogica.ObjetoAuditoriaInsertar(personaNatural);
                }
                else
                {
                    auditoriaLogica.ObjetoAuditoriaEditar(persona, DatosPersona.PersonaConsultarPorID(persona.ID_PERSONA));
                    auditoriaLogica.ObjetoAuditoriaEditar(personaNatural, DatosPersona.PersonaConsultarPorID(personaNatural.ID_NATURAL));

                    persona = DatosPersona.PersonaActualizar(persona);
                    personaNatural = Datos.PersonaNaturalActualizar(personaNatural);
                }

                PersonaJuridica objetoJuridica = new PersonaJuridica();
                objetoJuridica.ID_REP_LEGAL = persona.ID_PERSONA;
                objetoJuridica.ID_JURIDICA = IdPersosnaJuridica;
                auditoriaLogica.ObjetoAuditoriaEditar(objetoJuridica, DatosJuridica.PersonaJuridicaConsultarPorID(objetoJuridica.ID_JURIDICA));
                DatosJuridica.RepresentanteLegalActualizar(objetoJuridica);
                if (persona.ID_PERSONA > 0)
                {
                    if (listaRelacionadoPep != null && listaRelacionadoPep.Count > 0)
                    {
                        foreach (RelacionadoPep item in listaRelacionadoPep)
                        {
                            if (item.ID_RELACIONADO_PEP < 1)
                            {
                                item.ID_RELACIONADO_PEP = 0;
                                item.ID_PERSONA = persona.ID_PERSONA;
                                RelPepLogica.RelacionadoPepInsertar(item);
                                WSSarlaftLN.ConsultarListaClinton(item.DOCUMENTO, string.Empty);
                            }
                            else
                            {
                                RelPepLogica.RelacionadoPepActualizar(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return personaNatural;
        }

        public List<PersonaNatural> PersonaNaturalConsultar()
		{
			return Datos.PersonaNaturalConsultar();
		}

		public PersonaNatural PersonaNaturalConsultarPorID(Int64 id)
		{
			return Datos.PersonaNaturalConsultarPorID(id);
		}

        public PersonaNatural PersonaNaturalConsultarPorIdPersona(Int64 idPersona)
        {
            return Datos.PersonaNaturalConsultarPorIdPersona(idPersona);
        }

        public PersonaNatural PersonaNaturalPorIdentificacionConsultar(Int64 idTipoDocumento, string numeroDocumento)
		{
			return Datos.PersonaNaturalPorIdentificacionConsultar(idTipoDocumento, numeroDocumento);
		}
	}
}
