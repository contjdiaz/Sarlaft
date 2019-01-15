using Componentes;
using Dapper;
using Entidades;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
	public class PersonaNaturalAD: Conexion
	{
		// CRUD Create/(Insertar), Read(Consultar), Update(Actualizar), Delete(Eliminar)

		public PersonaNatural PersonaNaturalInsertar(PersonaNatural P)
		{
			param = new DynamicParameters();
			param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
			param.Add(name: "PRIMER_NOMBRE", value: P.PRIMER_NOMBRE, direction: ParameterDirection.Input);
			param.Add(name: "SEGUNDO_NOMBRE", value: P.SEGUNDO_NOMBRE, direction: ParameterDirection.Input);
			param.Add(name: "PRIMER_APELLIDO", value: P.PRIMER_APELLIDO, direction: ParameterDirection.Input);
			param.Add(name: "SEGUNDO_APELLIDO", value: P.SEGUNDO_APELLIDO, direction: ParameterDirection.Input);
			param.Add(name: "ID_SEXO", value: P.ID_SEXO, direction: ParameterDirection.Input);
			param.Add(name: "FEC_EXPEDICION", value: P.FEC_EXPEDICION, direction: ParameterDirection.Input);
			param.Add(name: "FEC_NACIMIENTO", value: P.FEC_NACIMIENTO, direction: ParameterDirection.Input);
			param.Add(name: "DIR_RESIDENCIA", value: P.DIR_RESIDENCIA, direction: ParameterDirection.Input);
			param.Add(name: "CORREO", value: P.CORREO, direction: ParameterDirection.Input);
			param.Add(name: "TELEFONO", value: P.TELEFONO, direction: ParameterDirection.Input);
			param.Add(name: "CELULAR", value: P.CELULAR, direction: ParameterDirection.Input);
			param.Add(name: "ID_MCPO_EXPEDICION", value: P.ID_MCPO_EXPEDICION, direction: ParameterDirection.Input);
			param.Add(name: "ID_MCPO_NACIMIENTO", value: P.ID_MCPO_NACIMIENTO, direction: ParameterDirection.Input);
			param.Add(name: "ID_ESTADO_CIVIL", value: P.ID_ESTADO_CIVIL, direction: ParameterDirection.Input);
			param.Add(name: "ID_PROFESION", value: P.ID_PROFESION, direction: ParameterDirection.Input);		
			param.Add(name: "DIRECCION_EMPRESA", value: P.DIRECCION_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "ID_CODIGO_CIIU", value: P.ID_CODIGO_CIIU, direction: ParameterDirection.Input);
			param.Add(name: "TEL_RESIDENCIA", value: P.TEL_RESIDENCIA, direction: ParameterDirection.Input);
			param.Add(name: "ID_MCPO_RESIDENCIA", value: P.ID_MCPO_RESIDENCIA, direction: ParameterDirection.Input);
			param.Add(name: "NOMBRE_EMPRESA", value: P.NOMBRE_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "ID_TIPO_EMPRESA", value: P.ID_TIPO_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "DEPENDENCIA", value: P.DEPENDENCIA, direction: ParameterDirection.Input);
			param.Add(name: "CARGO", value: P.CARGO, direction: ParameterDirection.Input);
			param.Add(name: "ID_MCPO_EMPRESA", value: P.ID_MCPO_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "TELEFONO_EMPRESA", value: P.TELEFONO_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "EXTENSION_EMPRESA", value: P.EXTENSION_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "CELULAR_EMPRESA", value: P.CELULAR_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "FAX_EMPRESA", value: P.FAX_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "DECRETO_1674", value: P.DECRETO_1674, direction: ParameterDirection.Input);
			param.Add(name: "REP_ORG_INTERNACIONAL", value: P.REP_ORG_INTERNACIONAL, direction: ParameterDirection.Input);
			param.Add(name: "RECONOCIMIENTO_PUB", value: P.RECONOCIMIENTO_PUB, direction: ParameterDirection.Input);
			param.Add(name: "VINCULO_PEP", value: P.VINCULO_PEP, direction: ParameterDirection.Input);
			param.Add(name: "ENTIDAD_PEP", value: P.ENTIDAD_PEP, direction: ParameterDirection.Input);		
			param.Add(name: "ID_CARGO_PEP", value: P.ID_CARGO_PEP == 0? null: P.ID_CARGO_PEP, direction: ParameterDirection.Input);
			param.Add(name: "FEC_VINCULA_PEP", value: P.FEC_VINCULA_PEP, direction: ParameterDirection.Input);
			param.Add(name: "FEC_DESVINCULA_PEP", value: P.FEC_DESVINCULA_PEP, direction: ParameterDirection.Input);

			param.Add(name: "ID_NATURAL", dbType: DbType.Int64, direction: ParameterDirection.Output);
			try
			{
				//using (OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["OracleConexion"].ToString()))
				//{
				//	connection.Open();

				//	OracleCommand command = connection.CreateCommand();
				//	OracleTransaction transaction;
			
					P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO NATURAL(ID_PERSONA" +
					",PRIMER_NOMBRE" +
					",SEGUNDO_NOMBRE" +
					",PRIMER_APELLIDO" +
					",SEGUNDO_APELLIDO" +
					",ID_SEXO" +
					",FEC_EXPEDICION" +
					",FEC_NACIMIENTO" +
					",DIR_RESIDENCIA" +
					",CORREO" +
					",TELEFONO" +
					",CELULAR" +
					",ID_MCPO_EXPEDICION" +
					",ID_MCPO_NACIMIENTO" +
					",ID_ESTADO_CIVIL" +
					",ID_PROFESION" +
					",DIRECCION_EMPRESA" +
					",ID_CODIGO_CIIU" +
					",TEL_RESIDENCIA" +
					",ID_MCPO_RESIDENCIA" +
					",NOMBRE_EMPRESA" +
					",ID_TIPO_EMPRESA" +
					",DEPENDENCIA" +
					",CARGO" +
					",ID_MCPO_EMPRESA" +
					",TELEFONO_EMPRESA" +
					",EXTENSION_EMPRESA" +
					",CELULAR_EMPRESA" +
					",FAX_EMPRESA" +
					",DECRETO_1674" +
					",REP_ORG_INTERNACIONAL" +
					",RECONOCIMIENTO_PUB" +
					",VINCULO_PEP" +
					",ENTIDAD_PEP" +
					",FEC_VINCULA_PEP" +
					",FEC_DESVINCULA_PEP" +
					",ID_CARGO_PEP)"
					+ "VALUES (:ID_PERSONA" +
					",:PRIMER_NOMBRE" +
					",:SEGUNDO_NOMBRE" +
					",:PRIMER_APELLIDO" +
					",:SEGUNDO_APELLIDO" +
					",:ID_SEXO" +
					",:FEC_EXPEDICION" +
					",:FEC_NACIMIENTO" +
					",:DIR_RESIDENCIA" +
					",:CORREO" +
					",:TELEFONO" +
					",:CELULAR" +
					",:ID_MCPO_EXPEDICION" +
					",:ID_MCPO_NACIMIENTO" +
					",:ID_ESTADO_CIVIL" +
					",:ID_PROFESION" +
					",:DIRECCION_EMPRESA" +
					",:ID_CODIGO_CIIU" +
					",:TEL_RESIDENCIA" +
					",:ID_MCPO_RESIDENCIA" +
					",:NOMBRE_EMPRESA" +
					",:ID_TIPO_EMPRESA" +
					",:DEPENDENCIA" +
					",:CARGO" +
					",:ID_MCPO_EMPRESA" +
					",:TELEFONO_EMPRESA" +
					",:EXTENSION_EMPRESA" +
					",:CELULAR_EMPRESA" +
					",:FAX_EMPRESA" +
					",:DECRETO_1674" +
					",:REP_ORG_INTERNACIONAL" +
					",:RECONOCIMIENTO_PUB" +
					",:VINCULO_PEP" +
					",:ENTIDAD_PEP" +				
					",:FEC_VINCULA_PEP" +
					",:FEC_DESVINCULA_PEP" +
					",:ID_CARGO_PEP" +
				    ") RETURNING ID_NATURAL INTO :ID_NATURAL", param);
					if (P.FilasAfectadas > 0)
					{
						P.ID_NATURAL = param.Get<Int64>("ID_NATURAL");
					}
				//}
			}
			catch (Exception Ex)
			{
				P.mensajeNotificacion = Exepciones.Exepciones(Ex);
				P.tipoMensaje = 3;
			}
			return P;
		}

        public PersonaNatural RepresentanteLegalInsertar(PersonaNatural P)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
            param.Add(name: "PRIMER_NOMBRE", value: P.PRIMER_NOMBRE, direction: ParameterDirection.Input);
            param.Add(name: "SEGUNDO_NOMBRE", value: P.SEGUNDO_NOMBRE, direction: ParameterDirection.Input);
            param.Add(name: "PRIMER_APELLIDO", value: P.PRIMER_APELLIDO, direction: ParameterDirection.Input);
            param.Add(name: "SEGUNDO_APELLIDO", value: P.SEGUNDO_APELLIDO, direction: ParameterDirection.Input);
            param.Add(name: "ID_SEXO", value: P.ID_SEXO, direction: ParameterDirection.Input);
            param.Add(name: "FEC_EXPEDICION", value: P.FEC_EXPEDICION, direction: ParameterDirection.Input);
            param.Add(name: "FEC_NACIMIENTO", value: P.FEC_NACIMIENTO, direction: ParameterDirection.Input);
            param.Add(name: "DIR_RESIDENCIA", value: P.DIR_RESIDENCIA, direction: ParameterDirection.Input);
            param.Add(name: "CORREO", value: P.CORREO, direction: ParameterDirection.Input);
            param.Add(name: "TELEFONO", value: P.TELEFONO, direction: ParameterDirection.Input);
            param.Add(name: "CELULAR", value: P.CELULAR, direction: ParameterDirection.Input);
            param.Add(name: "ID_MCPO_EXPEDICION", value: P.ID_MCPO_EXPEDICION, direction: ParameterDirection.Input);
            param.Add(name: "ID_MCPO_NACIMIENTO", value: P.ID_MCPO_NACIMIENTO, direction: ParameterDirection.Input);
            param.Add(name: "ID_ESTADO_CIVIL", value: P.ID_ESTADO_CIVIL, direction: ParameterDirection.Input); 
            param.Add(name: "TEL_RESIDENCIA", value: P.TEL_RESIDENCIA, direction: ParameterDirection.Input);
            param.Add(name: "ID_MCPO_RESIDENCIA", value: P.ID_MCPO_RESIDENCIA, direction: ParameterDirection.Input);
            param.Add(name: "TELEFONO_EMPRESA", value: P.TELEFONO_EMPRESA, direction: ParameterDirection.Input);
            param.Add(name: "EXTENSION_EMPRESA", value: P.EXTENSION_EMPRESA, direction: ParameterDirection.Input);
            param.Add(name: "FAX_EMPRESA", value: P.FAX_EMPRESA, direction: ParameterDirection.Input);
            param.Add(name: "DECRETO_1674", value: P.DECRETO_1674, direction: ParameterDirection.Input);
            param.Add(name: "REP_ORG_INTERNACIONAL", value: P.REP_ORG_INTERNACIONAL, direction: ParameterDirection.Input);
            param.Add(name: "RECONOCIMIENTO_PUB", value: P.RECONOCIMIENTO_PUB, direction: ParameterDirection.Input);
            param.Add(name: "VINCULO_PEP", value: P.VINCULO_PEP, direction: ParameterDirection.Input);
            param.Add(name: "ENTIDAD_PEP", value: P.ENTIDAD_PEP, direction: ParameterDirection.Input);
            param.Add(name: "ID_CARGO_PEP", value: P.ID_CARGO_PEP == 0 ? null : P.ID_CARGO_PEP, direction: ParameterDirection.Input);
            param.Add(name: "FEC_VINCULA_PEP", value: P.FEC_VINCULA_PEP, direction: ParameterDirection.Input);
            param.Add(name: "FEC_DESVINCULA_PEP", value: P.FEC_DESVINCULA_PEP, direction: ParameterDirection.Input);

            param.Add(name: "ID_NATURAL", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {
                //using (OracleConnection connection = new OracleConnection(ConfigurationManager.AppSettings["OracleConexion"].ToString()))
                //{
                //	connection.Open();

                //	OracleCommand command = connection.CreateCommand();
                //	OracleTransaction transaction;

                P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO NATURAL(ID_PERSONA" +
                ",PRIMER_NOMBRE" +
                ",SEGUNDO_NOMBRE" +
                ",PRIMER_APELLIDO" +
                ",SEGUNDO_APELLIDO" +
                ",ID_SEXO" +
                ",FEC_EXPEDICION" +
                ",FEC_NACIMIENTO" +
                ",DIR_RESIDENCIA" +
                ",CORREO" +
                ",TELEFONO" +
                ",CELULAR" +
                ",ID_MCPO_EXPEDICION" +
                ",ID_MCPO_NACIMIENTO" +
                ",ID_ESTADO_CIVIL" +
                 ",TEL_RESIDENCIA" +
                ",ID_MCPO_RESIDENCIA" +
                 ",TELEFONO_EMPRESA" +
                ",EXTENSION_EMPRESA" +
                ",FAX_EMPRESA" +
                ",DECRETO_1674" +
                ",REP_ORG_INTERNACIONAL" +
                ",RECONOCIMIENTO_PUB" +
                ",VINCULO_PEP" +
                ",ENTIDAD_PEP" +
                ",FEC_VINCULA_PEP" +
                ",FEC_DESVINCULA_PEP" +
                ",ID_CARGO_PEP)"
                + "VALUES (:ID_PERSONA" +
                ",:PRIMER_NOMBRE" +
                ",:SEGUNDO_NOMBRE" +
                ",:PRIMER_APELLIDO" +
                ",:SEGUNDO_APELLIDO" +
                ",:ID_SEXO" +
                ",:FEC_EXPEDICION" +
                ",:FEC_NACIMIENTO" +
                ",:DIR_RESIDENCIA" +
                ",:CORREO" +
                ",:TELEFONO" +
                ",:CELULAR" +
                ",:ID_MCPO_EXPEDICION" +
                ",:ID_MCPO_NACIMIENTO" +
                ",:ID_ESTADO_CIVIL" +
                 ",:TEL_RESIDENCIA" +
                ",:ID_MCPO_RESIDENCIA" +
                ",:TELEFONO_EMPRESA" +
                ",:EXTENSION_EMPRESA" +
                ",:FAX_EMPRESA" +
                ",:DECRETO_1674" +
                ",:REP_ORG_INTERNACIONAL" +
                ",:RECONOCIMIENTO_PUB" +
                ",:VINCULO_PEP" +
                ",:ENTIDAD_PEP" +
                ",:FEC_VINCULA_PEP" +
                ",:FEC_DESVINCULA_PEP" +
                ",:ID_CARGO_PEP" +
                ") RETURNING ID_NATURAL INTO :ID_NATURAL", param);
                if (P.FilasAfectadas > 0)
                {
                    P.ID_NATURAL = param.Get<Int64>("ID_NATURAL");
                }
                //}
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }


        public PersonaNatural PersonaNaturalActualizar(PersonaNatural P)
		{
			param = new DynamicParameters(); 
			//param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
			param.Add(name: "ID_NATURAL", value: P.ID_NATURAL, dbType: DbType.Int64, direction: ParameterDirection.Input);			
			param.Add(name: "PRIMER_NOMBRE", value: P.PRIMER_NOMBRE, direction: ParameterDirection.Input);
			param.Add(name: "SEGUNDO_NOMBRE", value: P.SEGUNDO_NOMBRE, direction: ParameterDirection.Input);
			param.Add(name: "PRIMER_APELLIDO", value: P.PRIMER_APELLIDO, direction: ParameterDirection.Input);
			param.Add(name: "SEGUNDO_APELLIDO", value: P.SEGUNDO_APELLIDO, direction: ParameterDirection.Input);
			param.Add(name: "ID_SEXO", value: P.ID_SEXO, direction: ParameterDirection.Input);
			param.Add(name: "FEC_EXPEDICION", value: P.FEC_EXPEDICION, direction: ParameterDirection.Input);
			param.Add(name: "FEC_NACIMIENTO", value: P.FEC_NACIMIENTO, direction: ParameterDirection.Input);
			param.Add(name: "DIR_RESIDENCIA", value: P.DIR_RESIDENCIA, direction: ParameterDirection.Input);
			param.Add(name: "CORREO", value: P.CORREO, direction: ParameterDirection.Input);
			param.Add(name: "TELEFONO", value: P.TELEFONO, direction: ParameterDirection.Input);
			param.Add(name: "CELULAR", value: P.CELULAR, direction: ParameterDirection.Input);
			param.Add(name: "ID_MCPO_EXPEDICION", value: P.ID_MCPO_EXPEDICION, direction: ParameterDirection.Input);
			param.Add(name: "ID_MCPO_NACIMIENTO", value: P.ID_MCPO_NACIMIENTO, direction: ParameterDirection.Input);
			param.Add(name: "ID_ESTADO_CIVIL", value: P.ID_ESTADO_CIVIL, direction: ParameterDirection.Input);
			param.Add(name: "DIRECCION_EMPRESA", value: P.DIRECCION_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "TEL_RESIDENCIA", value: P.TEL_RESIDENCIA, direction: ParameterDirection.Input);
			param.Add(name: "ID_MCPO_RESIDENCIA", value: P.ID_MCPO_RESIDENCIA, direction: ParameterDirection.Input);

            param.Add(name: "NOMBRE_EMPRESA", value: P.NOMBRE_EMPRESA, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_EMPRESA", value: P.ID_TIPO_EMPRESA, direction: ParameterDirection.Input);
            param.Add(name: "DEPENDENCIA", value: P.DEPENDENCIA, direction: ParameterDirection.Input);
            param.Add(name: "CARGO", value: P.CARGO, direction: ParameterDirection.Input);          
            param.Add(name: "ID_MCPO_EMPRESA", value: P.ID_MCPO_EMPRESA, direction: ParameterDirection.Input);           

            param.Add(name: "TELEFONO_EMPRESA", value: P.TELEFONO_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "EXTENSION_EMPRESA", value: P.EXTENSION_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "CELULAR_EMPRESA", value: P.CELULAR_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "FAX_EMPRESA", value: P.FAX_EMPRESA, direction: ParameterDirection.Input);
			param.Add(name: "DECRETO_1674", value: P.DECRETO_1674, direction: ParameterDirection.Input);
			param.Add(name: "REP_ORG_INTERNACIONAL", value: P.REP_ORG_INTERNACIONAL, direction: ParameterDirection.Input);
			param.Add(name: "RECONOCIMIENTO_PUB", value: P.RECONOCIMIENTO_PUB, direction: ParameterDirection.Input);
			param.Add(name: "VINCULO_PEP", value: P.VINCULO_PEP, direction: ParameterDirection.Input);
			param.Add(name: "ENTIDAD_PEP", value: P.ENTIDAD_PEP, direction: ParameterDirection.Input);
			param.Add(name: "ID_CARGO_PEP", value: P.ID_CARGO_PEP, direction: ParameterDirection.Input);
			param.Add(name: "FEC_VINCULA_PEP", value: P.FEC_VINCULA_PEP, direction: ParameterDirection.Input);
			param.Add(name: "FEC_DESVINCULA_PEP", value: P.FEC_DESVINCULA_PEP, direction: ParameterDirection.Input);

			
			try
			{
				P.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE NATURAL SET " +
				"PRIMER_NOMBRE=:PRIMER_NOMBRE" +
				",SEGUNDO_NOMBRE=:SEGUNDO_NOMBRE" +
				",PRIMER_APELLIDO=:PRIMER_APELLIDO" +
				",SEGUNDO_APELLIDO=:SEGUNDO_APELLIDO" +
				",ID_SEXO=:ID_SEXO" +
				",FEC_EXPEDICION=:FEC_EXPEDICION" +
				",FEC_NACIMIENTO=:FEC_NACIMIENTO" +
				",DIR_RESIDENCIA=:DIR_RESIDENCIA" +
				",CORREO=:CORREO" +
				",TELEFONO=:TELEFONO" +
				",CELULAR=:CELULAR" +
				",ID_MCPO_EXPEDICION=:ID_MCPO_EXPEDICION" +
				",ID_MCPO_NACIMIENTO=:ID_MCPO_NACIMIENTO" +
				",ID_ESTADO_CIVIL=:ID_ESTADO_CIVIL" +
				",DIRECCION_EMPRESA=:DIRECCION_EMPRESA" +
                ",NOMBRE_EMPRESA=:NOMBRE_EMPRESA" +
                ",ID_TIPO_EMPRESA=:ID_TIPO_EMPRESA" +
                ",DEPENDENCIA=:DEPENDENCIA" +
                ",CARGO=:CARGO" +
                ",ID_MCPO_EMPRESA=:ID_MCPO_EMPRESA" +
                ",TEL_RESIDENCIA=:TEL_RESIDENCIA" +
				",ID_MCPO_RESIDENCIA=:ID_MCPO_RESIDENCIA" +
				",TELEFONO_EMPRESA=:TELEFONO_EMPRESA" +
				",EXTENSION_EMPRESA=:EXTENSION_EMPRESA" +
				",CELULAR_EMPRESA=:CELULAR_EMPRESA" +
				",FAX_EMPRESA=:FAX_EMPRESA" +
				",DECRETO_1674=:DECRETO_1674" +
				",REP_ORG_INTERNACIONAL=:REP_ORG_INTERNACIONAL" +
				",RECONOCIMIENTO_PUB=:RECONOCIMIENTO_PUB" +
				",VINCULO_PEP=:VINCULO_PEP" +
				",ENTIDAD_PEP=:ENTIDAD_PEP" +
				",FEC_VINCULA_PEP=:FEC_VINCULA_PEP" +
				",FEC_DESVINCULA_PEP=:FEC_DESVINCULA_PEP" +
				",ID_CARGO_PEP=:ID_CARGO_PEP WHERE ID_NATURAL =:ID_NATURAL"
				, param);				
			}
			catch (Exception Ex)
			{
				P.mensajeNotificacion = Exepciones.Exepciones(Ex);
				P.tipoMensaje = 3;
			}
			return P;
		}

		public List<PersonaNatural> PersonaNaturalConsultar()
		{
			List<PersonaNatural> Lista;
			param = new DynamicParameters();
			try
			{
				Lista = (List<PersonaNatural>)OracleConnection.Query<PersonaNatural>("SELECT ID_NATURAL,ID_PERSONA, PRIMER_NOMBRE, SEGUNDO_NOMBRE,PRIMER_APELLIDO, SEGUNDO_APELLIDO,ID_SEXO,FEC_EXPEDICION, " +
					"FEC_NACIMIENTO,DIR_RESIDENCIA,CORREO,TELEFONO,CELULAR,ID_MCPO_EXPEDICION,ID_MCPO_NACIMIENTO,ID_ESTADO_CIVIL,ID_PROFESION,DIRECCION_EMPRESA,ID_CODIGO_CIIU," +
					"TEL_RESIDENCIA,ID_MCPO_RESIDENCIA,NOMBRE_EMPRESA,ID_TIPO_EMPRESA,DEPENDENCIA,CARGO,ID_MCPO_EMPRESA,TELEFONO_EMPRESA,EXTENSION_EMPRESA,CELULAR_EMPRESA,FAX_EMPRESA,DECRETO_1674" +
					"REP_ORG_INTERNACIONAL,RECONOCIMIENTO_PUB,VINCULO_PEP,ENTIDAD_PEP,ID_CARGO_PEP,FEC_VINCULA_PEP,FEC_DESVINCULA_PEP" +
					" FROM NATURAL");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public PersonaNatural PersonaNaturalConsultarPorID(Int64 id)
		{
			param = new DynamicParameters();
			param.Add(name: "ID_NATURAL", value: id, direction: ParameterDirection.Input);

			PersonaNatural pn = (PersonaNatural)OracleConnection.Query<PersonaNatural>("SELECT ID_NATURAL,ID_PERSONA, PRIMER_NOMBRE, SEGUNDO_NOMBRE,PRIMER_APELLIDO, SEGUNDO_APELLIDO,ID_SEXO,FEC_EXPEDICION, " +
					"FEC_NACIMIENTO,DIR_RESIDENCIA,CORREO,TELEFONO,CELULAR,ID_MCPO_EXPEDICION,ID_MCPO_NACIMIENTO,ID_ESTADO_CIVIL,ID_PROFESION,DIRECCION_EMPRESA,ID_CODIGO_CIIU," +
					"TEL_RESIDENCIA,ID_MCPO_RESIDENCIA,NOMBRE_EMPRESA,ID_TIPO_EMPRESA,DEPENDENCIA,CARGO,ID_MCPO_EMPRESA,TELEFONO_EMPRESA,EXTENSION_EMPRESA,CELULAR_EMPRESA,FAX_EMPRESA,DECRETO_1674," +
					"REP_ORG_INTERNACIONAL,RECONOCIMIENTO_PUB,VINCULO_PEP,ENTIDAD_PEP,ID_CARGO_PEP,FEC_VINCULA_PEP,FEC_DESVINCULA_PEP" +
					" FROM NATURAL WHERE ID_NATURAL=:ID_NATURAL", param).FirstOrDefault();
			return pn;
		}

        public PersonaNatural PersonaNaturalConsultarPorIdPersona(Int64 idPersona)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_PERSONA", value: idPersona, direction: ParameterDirection.Input);

            PersonaNatural pn = (PersonaNatural)OracleConnection.Query<PersonaNatural>("SELECT ID_NATURAL,ID_PERSONA, PRIMER_NOMBRE, SEGUNDO_NOMBRE,PRIMER_APELLIDO, SEGUNDO_APELLIDO,ID_SEXO,FEC_EXPEDICION, " +
					"FEC_NACIMIENTO,DIR_RESIDENCIA,CORREO,TELEFONO,CELULAR,ID_MCPO_EXPEDICION,ID_MCPO_NACIMIENTO,ID_ESTADO_CIVIL,ID_PROFESION, DIRECCION_EMPRESA,ID_CODIGO_CIIU," +
                    "TEL_RESIDENCIA,ID_MCPO_RESIDENCIA,NOMBRE_EMPRESA,ID_TIPO_EMPRESA,DEPENDENCIA,CARGO,ID_MCPO_EMPRESA,TELEFONO_EMPRESA,EXTENSION_EMPRESA,CELULAR_EMPRESA,FAX_EMPRESA,DECRETO_1674," +
                    "REP_ORG_INTERNACIONAL,RECONOCIMIENTO_PUB,VINCULO_PEP,ENTIDAD_PEP,ID_CARGO_PEP,FEC_VINCULA_PEP,FEC_DESVINCULA_PEP" +
                    " FROM NATURAL WHERE ID_PERSONA=:ID_PERSONA", param).FirstOrDefault();
            return pn;
        }
        public PersonaNatural PersonaNaturalPorIdentificacionConsultar(Int64 idTipoDocumento, string numeroDocumento)
		{
			//param = new DynamicParameters();
			//param.Add(name: "ID_NATURAL", value: id, direction: ParameterDirection.Input);
			try
			{
				PersonaNatural pn = (PersonaNatural)OracleConnection.Query<PersonaNatural>("SELECT n.ID_NATURAL,n.ID_PERSONA, PRIMER_NOMBRE, SEGUNDO_NOMBRE,PRIMER_APELLIDO, SEGUNDO_APELLIDO,ID_SEXO,FEC_EXPEDICION," +
					" FEC_NACIMIENTO,DIR_RESIDENCIA,CORREO,TELEFONO,CELULAR,ID_MCPO_EXPEDICION,ID_MCPO_NACIMIENTO,ID_ESTADO_CIVIL," +
					" ID_PROFESION,DIRECCION_EMPRESA,ID_CODIGO_CIIU,TEL_RESIDENCIA,ID_MCPO_RESIDENCIA,NOMBRE_EMPRESA,ID_TIPO_EMPRESA," +
					" DEPENDENCIA,CARGO,ID_MCPO_EMPRESA,TELEFONO_EMPRESA,EXTENSION_EMPRESA,CELULAR_EMPRESA,FAX_EMPRESA,DECRETO_1674," +
					" REP_ORG_INTERNACIONAL,RECONOCIMIENTO_PUB,VINCULO_PEP,ENTIDAD_PEP,ID_CARGO_PEP,FEC_VINCULA_PEP,FEC_DESVINCULA_PEP" +
					" from natural n" +
					" inner join persona p on p.id_persona = n.id_persona " +
					" where p.id_tipo_documento = " + idTipoDocumento + " and p.numero_documento='" + numeroDocumento + "'").FirstOrDefault();

				return pn;
			}
			catch (Exception ex)
			{
				throw ex;
			}		
			
		}
	}
}
