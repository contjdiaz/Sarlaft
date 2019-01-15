
using Entidades;
using Logica;
using System;
using System.Collections.Generic;


namespace Servicios
{
	public class RelacionadoPepSRV
	{
		RelacionadoPepLN logica = new RelacionadoPepLN();
		public RelacionadoPep RelacionadoPepInsertar(RelacionadoPep P)
		{
			return logica.RelacionadoPepInsertar(P);
		}

        public RelacionadoPep AdministradorInsertar(RelacionadoPep P)
        {
            RelacionadoPep objeto = new RelacionadoPep();
            if (P.ID_RELACIONADO_PEP == 0)
                objeto = logica.AdministradorInsertar(P);
            else
                objeto= logica.RelacionadoPepActualizar(P);

            return objeto;
        }

        public RelacionadoPep RelacionadoPepPorId(Int64 Id_relacionado_PEP)
        {
            return logica.RelacionadoPepPorId(Id_relacionado_PEP);
        }

        public List<RelacionadoPep> RelacionadoPepPorPersonaConsultar(Int64 idPersona)
		{
			return logica.RelacionadoPepPorPersonaConsultar(idPersona);
		}

		public RelacionadoPep RelacionadoPepEliminar(RelacionadoPep Objeto)
		{
			return logica.RelacionadoPepEliminar(Objeto);
		}

        public RelacionadoPep RelacionadoPepActualizar(RelacionadoPep Objeto)
        {
            return logica.RelacionadoPepActualizar(Objeto);
        }
    }
}
