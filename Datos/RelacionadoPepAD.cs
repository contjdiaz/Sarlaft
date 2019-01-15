using Componentes;
using Dapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
	public class RelacionadoPepAD: Conexion
	{
		public RelacionadoPep RelacionadoPepInsertar(RelacionadoPep P)
		{
			param = new DynamicParameters();
			param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
			param.Add(name: "ID_TIPO_REL_PEP", value: P.ID_TIPO_REL_PEP, direction: ParameterDirection.Input);
			param.Add(name: "ID_TIPO_DOCUMENTO", value: P.ID_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
			param.Add(name: "DOCUMENTO", value: P.DOCUMENTO, direction: ParameterDirection.Input);
			param.Add(name: "PRIMER_NOMBRE", value: P.PRIMER_NOMBRE, direction: ParameterDirection.Input);
			param.Add(name: "SEGUNDO_NOMBRE", value: P.SEGUNDO_NOMBRE, direction: ParameterDirection.Input);
			param.Add(name: "PRIMER_APELLIDO", value: P.PRIMER_APELLIDO, direction: ParameterDirection.Input);
			param.Add(name: "SEGUNDO_APELLIDO", value: P.SEGUNDO_APELLIDO, direction: ParameterDirection.Input);
			param.Add(name: "NOMBRE_ENTIDAD", value: P.NOMBRE_ENTIDAD, direction: ParameterDirection.Input);
			param.Add(name: "CARGO", value: P.CARGO, direction: ParameterDirection.Input);
			param.Add(name: "FEC_VINCULA", value: P.FEC_VINCULA, direction: ParameterDirection.Input);
			param.Add(name: "FEC_DESVINCULA", value: P.FEC_DESVINCULA, direction: ParameterDirection.Input);
			param.Add(name: "ID_RELACIONADO_PEP", dbType: DbType.Int64, direction: ParameterDirection.Output);
			try
			{
				P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO RELACIONADO_PEP(ID_PERSONA, ID_TIPO_REL_PEP"+
					", ID_TIPO_DOCUMENTO,DOCUMENTO, PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO" +
					", NOMBRE_ENTIDAD,CARGO,FEC_VINCULA,FEC_DESVINCULA) " +
					"VALUES (:ID_PERSONA, :ID_TIPO_REL_PEP, :ID_TIPO_DOCUMENTO, :DOCUMENTO, :PRIMER_NOMBRE, :SEGUNDO_NOMBRE" +
					", :PRIMER_APELLIDO,:SEGUNDO_APELLIDO,:NOMBRE_ENTIDAD,:CARGO,:FEC_VINCULA,:FEC_DESVINCULA" +
					") RETURNING ID_RELACIONADO_PEP INTO :ID_RELACIONADO_PEP", param);
				if (P.FilasAfectadas > 0)
				{
					P.ID_RELACIONADO_PEP = param.Get<Int64>("ID_RELACIONADO_PEP");
				}
			}
			catch (Exception Ex)
			{
				P.mensajeNotificacion = Exepciones.Exepciones(Ex);
				P.tipoMensaje = 3;
			}
			return P;
		}

        public RelacionadoPep AdministradorInsertar(RelacionadoPep P)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_REL_PEP", value: P.ID_TIPO_REL_PEP, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_DOCUMENTO", value: P.ID_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
            param.Add(name: "DOCUMENTO", value: P.DOCUMENTO, direction: ParameterDirection.Input);
            param.Add(name: "PRIMER_NOMBRE", value: P.PRIMER_NOMBRE, direction: ParameterDirection.Input);
            param.Add(name: "SEGUNDO_NOMBRE", value: P.SEGUNDO_NOMBRE, direction: ParameterDirection.Input);
            param.Add(name: "PRIMER_APELLIDO", value: P.PRIMER_APELLIDO, direction: ParameterDirection.Input);
            param.Add(name: "SEGUNDO_APELLIDO", value: P.SEGUNDO_APELLIDO, direction: ParameterDirection.Input);
            param.Add(name: "NOMBRE_ENTIDAD", value: P.NOMBRE_ENTIDAD, direction: ParameterDirection.Input);
            param.Add(name: "ID_CARGO_PEP", value: P.ID_CARGO_PEP, direction: ParameterDirection.Input);
            param.Add(name: "FEC_VINCULA", value: P.FEC_VINCULA, direction: ParameterDirection.Input);
            param.Add(name: "FEC_DESVINCULA", value: P.FEC_DESVINCULA, direction: ParameterDirection.Input);
            param.Add(name: "ID_RELACIONADO_PEP", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO RELACIONADO_PEP(ID_PERSONA, ID_TIPO_REL_PEP" +
                    ", ID_TIPO_DOCUMENTO,DOCUMENTO, PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO" +
                    ", NOMBRE_ENTIDAD,ID_CARGO_PEP,FEC_VINCULA,FEC_DESVINCULA) " +
                    "VALUES (:ID_PERSONA, :ID_TIPO_REL_PEP, :ID_TIPO_DOCUMENTO, :DOCUMENTO, :PRIMER_NOMBRE, :SEGUNDO_NOMBRE" +
                    ", :PRIMER_APELLIDO,:SEGUNDO_APELLIDO,:NOMBRE_ENTIDAD,:ID_CARGO_PEP,:FEC_VINCULA,:FEC_DESVINCULA" +
                    ") RETURNING ID_RELACIONADO_PEP INTO :ID_RELACIONADO_PEP", param);
                if (P.FilasAfectadas > 0)
                {
                    P.ID_RELACIONADO_PEP = param.Get<Int64>("ID_RELACIONADO_PEP");
                }
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }

        public List<RelacionadoPep> RelacionadoPepPorPersonaConsultar(Int64 idPersona)
		{
			List<RelacionadoPep> Lista;
			param = new DynamicParameters();
			param.Add(name: "ID_PERSONA", value: idPersona, direction: ParameterDirection.Input);
			try
			{
				Lista = (List<RelacionadoPep>)OracleConnection.Query<RelacionadoPep>("SELECT * FROM RELACIONADO_PEP WHERE ID_PERSONA=:ID_PERSONA ", param);
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

        public RelacionadoPep RelacionadoPepPorId(Int64 Id_relacionado_PEP)
        {
            RelacionadoPep Lista;
            param = new DynamicParameters();
            param.Add(name: "ID_RELACIONADO_PEP", value: Id_relacionado_PEP, direction: ParameterDirection.Input);
            try
            {
                 Lista = (RelacionadoPep)OracleConnection.Query<RelacionadoPep>("SELECT * FROM RELACIONADO_PEP WHERE ID_RELACIONADO_PEP=:ID_RELACIONADO_PEP ", param).FirstOrDefault();
       
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }

            return Lista;
        }

        public RelacionadoPep RelacionadoPepActualizar(RelacionadoPep Objeto)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_RELACIONADO_PEP", value: Objeto.ID_RELACIONADO_PEP, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_REL_PEP", value: Objeto.ID_TIPO_REL_PEP, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_DOCUMENTO", value: Objeto.ID_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
            param.Add(name: "DOCUMENTO", value: Objeto.DOCUMENTO, direction: ParameterDirection.Input);
            param.Add(name: "PRIMER_NOMBRE", value: Objeto.PRIMER_NOMBRE, direction: ParameterDirection.Input);
            param.Add(name: "SEGUNDO_NOMBRE", value: Objeto.SEGUNDO_NOMBRE, direction: ParameterDirection.Input);
            param.Add(name: "PRIMER_APELLIDO", value: Objeto.PRIMER_APELLIDO, direction: ParameterDirection.Input);
            param.Add(name: "SEGUNDO_APELLIDO", value: Objeto.SEGUNDO_APELLIDO, direction: ParameterDirection.Input);
            param.Add(name: "NOMBRE_ENTIDAD", value: Objeto.NOMBRE_ENTIDAD, direction: ParameterDirection.Input);
            param.Add(name: "ID_CARGO_PEP", value: Objeto.ID_CARGO_PEP == 0 ? null : Objeto.ID_CARGO_PEP, direction: ParameterDirection.Input);
            param.Add(name: "FEC_VINCULA", value: Objeto.FEC_VINCULA, direction: ParameterDirection.Input);
            param.Add(name: "FEC_DESVINCULA", value: Objeto.FEC_DESVINCULA, direction: ParameterDirection.Input);
            param.Add(name: "CARGO", value: Objeto.CARGO, direction: ParameterDirection.Input);


            try
            {
                Objeto.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE RELACIONADO_PEP SET  ID_TIPO_REL_PEP=:ID_TIPO_REL_PEP, ID_TIPO_DOCUMENTO=:ID_TIPO_DOCUMENTO, " +
                    " DOCUMENTO=:DOCUMENTO, PRIMER_NOMBRE=:PRIMER_NOMBRE, SEGUNDO_NOMBRE=:SEGUNDO_NOMBRE, PRIMER_APELLIDO=:PRIMER_APELLIDO, SEGUNDO_APELLIDO=:SEGUNDO_APELLIDO,  NOMBRE_ENTIDAD=:NOMBRE_ENTIDAD, " +
                    " ID_CARGO_PEP=:ID_CARGO_PEP, FEC_VINCULA=:FEC_VINCULA, FEC_DESVINCULA=:FEC_DESVINCULA,CARGO=:CARGO " +
                    "WHERE ID_RELACIONADO_PEP=:ID_RELACIONADO_PEP ", param);
            }
            catch (Exception Ex)
            {
                Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
                Objeto.tipoMensaje = 3;
            }
            return Objeto;
        }

        public RelacionadoPep RelacionadoPepEliminar(RelacionadoPep Objeto)
		{
			param = new DynamicParameters();
			param.Add(name: "ID_RELACIONADO_PEP", value: Objeto.ID_RELACIONADO_PEP, direction: ParameterDirection.Input);
			try
			{
				Objeto.FilasAfectadas = this.OracleConnection.Execute(@"DELETE FROM RELACIONADO_PEP WHERE ID_RELACIONADO_PEP=:ID_RELACIONADO_PEP", param);
			}
			catch (Exception Ex)
			{
				Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
				Objeto.tipoMensaje = 3;
			}
			return Objeto;
		}
	}
}
