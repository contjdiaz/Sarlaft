
using Datos;
using Entidades;
using System;
using System.Collections.Generic;


namespace Logica
{
   
    public class RelacionadoPepLN
	{
        AuditoriaLN auditoriaLogica = new AuditoriaLN();
        RelacionadoPepAD datos = new RelacionadoPepAD();
        WSSarlaftLN WSSarlaftLN = new WSSarlaftLN();
        public RelacionadoPep RelacionadoPepInsertar(RelacionadoPep P)
		{
            auditoriaLogica.ObjetoAuditoriaInsertar(P);
            return datos.RelacionadoPepInsertar(P);
		}

        public RelacionadoPep AdministradorInsertar(RelacionadoPep P)
        {
            RelacionadoPep resultado = new RelacionadoPep();
            auditoriaLogica.ObjetoAuditoriaInsertar(P);
            resultado = datos.AdministradorInsertar(P);
            WSSarlaftLN.ConsultarListaClinton(P.DOCUMENTO, string.Empty);
            return resultado;
        }

        public RelacionadoPep RelacionadoPepPorId(Int64 Id_relacionado_PEP)
        {
            return datos.RelacionadoPepPorId(Id_relacionado_PEP);
        }

        public List<RelacionadoPep> RelacionadoPepPorPersonaConsultar(Int64 idPersona)
		{
			return datos.RelacionadoPepPorPersonaConsultar(idPersona);
		}

		public RelacionadoPep RelacionadoPepEliminar(RelacionadoPep Objeto)
		{
            auditoriaLogica.ObjetoAuditoriaEliminar(Objeto);
            return datos.RelacionadoPepEliminar(Objeto);
		}

        public RelacionadoPep RelacionadoPepActualizar(RelacionadoPep Objeto)
        {
            auditoriaLogica.ObjetoAuditoriaEditar(Objeto, RelacionadoPepPorId(Objeto.ID_RELACIONADO_PEP));
            return datos.RelacionadoPepActualizar(Objeto);
        }
    }
}
