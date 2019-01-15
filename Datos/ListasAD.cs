using Dapper; //Micro ORM
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using Componentes;

namespace Datos
{
    public class ListasAD : Conexion
	{
        //Ejemplo de CRUD a la base de daros objeto
        // CRUD Create/(Insertar), Read(Consultar), Update(Actualizar), Delete(Eliminar)

    

        public List<TipoPersona> TipoPersonaConsultar()
        {
            List<TipoPersona> Lista;          
            try
            {			
				Lista = (List<TipoPersona>)OracleConnection.Query<TipoPersona>("SELECT ID_TIPO_PERSONA, CODIGO_TIPO_PERSONA, NOMBRE_TIPO_PERSONA FROM TIPO_PERSONA");
			}
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex)); 
            }

            return Lista;
        }

		public TipoPersona TipoPersonaPorCodigoConsultar(string codigo)
		{
			TipoPersona tp;
			param = new DynamicParameters();
			param.Add(name: "CODIGO_TIPO_PERSONA", value: codigo, direction: ParameterDirection.Input);
			try
			{
				tp = (TipoPersona)OracleConnection.Query<TipoPersona>("SELECT ID_TIPO_PERSONA, CODIGO_TIPO_PERSONA, NOMBRE_TIPO_PERSONA FROM TIPO_PERSONA WHERE CODIGO_TIPO_PERSONA= '" +codigo +"'").FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}
			return tp;
		}

		public List<Sexo> SexoConsultar()
		{
			List<Sexo> Lista;
	
			try
			{
				Lista = (List<Sexo>)OracleConnection.Query<Sexo>("SELECT * FROM SEXO");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public Sexo SexoPorIdConsultar(Int64 idSexo)
		{
			Sexo sexo;
			param = new DynamicParameters();
			param.Add(name: "ID_SEXO", value: idSexo, direction: ParameterDirection.Input); 
			try
			{
				sexo = (Sexo)OracleConnection.Query<Sexo>("SELECT * FROM SEXO WHERE ID_SEXO=:ID_SEXO ", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return sexo;
		}

		public List<EstadoCivil> EstadoCivilConsultar()
		{
			List<EstadoCivil> Lista;

			try
			{
				Lista = (List<EstadoCivil>)OracleConnection.Query<EstadoCivil>("SELECT * FROM ESTADO_CIVIL");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public EstadoCivil EstadoCivilPorIdConsultar(Int64 idEstadoCivil)
		{
			EstadoCivil estadoCivil;
			param = new DynamicParameters();
			param.Add(name: "ID_ESTADO_CIVIL", value: idEstadoCivil, direction: ParameterDirection.Input);
			try
			{
				estadoCivil = (EstadoCivil)OracleConnection.Query<EstadoCivil>("SELECT * FROM ESTADO_CIVIL WHERE ID_ESTADO_CIVIL=:ID_ESTADO_CIVIL", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return estadoCivil;
		}

		public List<Departamento> DepartamentoConsultar()
		{
			List<Departamento> Lista;

			try
			{
				Lista = (List<Departamento>)OracleConnection.Query<Departamento>("SELECT ID_DEPARTAMENTO,CODIGO_DEPARTAMENTO,NOMBRE_DEPARTAMENTO FROM DEPARTAMENTO");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public Departamento DepartamentoPorIdMunicipioConsultar(Int64 idMunicipio)
		{
			Departamento dep;
			param = new DynamicParameters();
			param.Add(name: "ID_MUNICIPIO", value: idMunicipio, direction: ParameterDirection.Input);
			try
			{
				dep = (Departamento)OracleConnection.Query<Departamento>("SELECT D.ID_DEPARTAMENTO,D.CODIGO_DEPARTAMENTO,D.NOMBRE_DEPARTAMENTO FROM DEPARTAMENTO D INNER JOIN MUNICIPIO M on D.ID_DEPARTAMENTO= M.ID_DEPARTAMENTO where M.ID_MUNICIPIO =:ID_MUNICIPIO", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return dep;
		}

		public List<Municipo> MunicipioConsultar(int idDepartamento)
		{
			List<Municipo> Lista;
			param = new DynamicParameters();
			param.Add(name: "ID_DEPARTAMENTO", value: idDepartamento, direction: ParameterDirection.Input);
			try
			{
				Lista = (List<Municipo>)OracleConnection.Query<Municipo>("SELECT * FROM MUNICIPIO WHERE ID_DEPARTAMENTO = :ID_DEPARTAMENTO order by NOMBRE_MUNICIPIO", param);

            }
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public Municipo MunicipioPorIdConsultar(Int64 idMunicipio)
		{
			Municipo minucipio;
			param = new DynamicParameters();
			param.Add(name: "ID_MUNICIPIO", value: idMunicipio, direction: ParameterDirection.Input);
			try
			{
				minucipio = (Municipo)OracleConnection.Query<Municipo>("SELECT * FROM MUNICIPIO WHERE ID_MUNICIPIO = :ID_MUNICIPIO order by NOMBRE_MUNICIPIO", param).FirstOrDefault();

			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return minucipio;
		}
		public List<ActividadEconomica> ActividadEconomicaConsultar()
		{
			List<ActividadEconomica> Lista;

			try
			{
				Lista = (List<ActividadEconomica>)OracleConnection.Query<ActividadEconomica>("SELECT * FROM ACTIVIDAD_ECONOMICA");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public ActividadEconomica ActividadEconomicaPorCodigoCiiuConsultar(Int64 idCodigoCiiu)
		{
			ActividadEconomica act;
			param = new DynamicParameters();
			param.Add(name: "ID_CODIGO_CIIU", value: idCodigoCiiu, direction: ParameterDirection.Input);
			try
			{
				act = (ActividadEconomica)OracleConnection.Query<ActividadEconomica>("SELECT A.* FROM ACTIVIDAD_ECONOMICA A INNER JOIN CODIGOS_CIIU C ON a.ID_ACTIVIDAD_ECONOMICA= C.ID_ACTIVIDAD_ECONOMICA WHERE C.ID_CODIGO_CIIU=:ID_CODIGO_CIIU",param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return act;
		}

		public ActividadEconomica ActividadEconomicaPorIdConsultar(Int64 idActEco)
		{
			ActividadEconomica act;
			param = new DynamicParameters();
			param.Add(name: "ID_ACTIVIDAD_ECONOMICA", value: idActEco, direction: ParameterDirection.Input);
			try
			{
				act = (ActividadEconomica)OracleConnection.Query<ActividadEconomica>("SELECT * FROM ACTIVIDAD_ECONOMICA ID_ACTIVIDAD_ECONOMICA=:ID_ACTIVIDAD_ECONOMICA", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return act;
		}


		public List<TipoOperacion> TipoOperacionConsultar()
		{
			List<TipoOperacion> Lista;

			try
			{
				Lista = (List<TipoOperacion>)OracleConnection.Query<TipoOperacion>("SELECT * FROM TIPO_OPERACION");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}


		public TipoOperacion TipoOperacionPorIDConsultar(Int64 idTipoOperacion)
		{
			TipoOperacion operacion;
			param = new DynamicParameters();
			param.Add(name: "ID_TIPO_OPERACION", value: idTipoOperacion, direction: ParameterDirection.Input);
			try
			{
				operacion = (TipoOperacion)OracleConnection.Query<TipoOperacion>("SELECT * FROM TIPO_OPERACION WHERE ID_TIPO_OPERACION=:ID_TIPO_OPERACION ", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return operacion;
		}

		public List<CodigoCiiu> CodigoCiiuConsultar()
		{
			List<CodigoCiiu> Lista;

			try
			{
				Lista = (List<CodigoCiiu>)OracleConnection.Query<CodigoCiiu>("SELECT * FROM CODIGOS_CIIU");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public CodigoCiiu CodigoCiiuPorIdConsultar(Int64 idCodigo)
		{
			CodigoCiiu codigo;
			param = new DynamicParameters();
			param.Add(name: "ID_CODIGO_CIIU", value: idCodigo, direction: ParameterDirection.Input);
			try
			{
				codigo = (CodigoCiiu)OracleConnection.Query<CodigoCiiu>("SELECT * FROM CODIGOS_CIIU WHERE ID_CODIGO_CIIU=:ID_CODIGO_CIIU", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return codigo;
		}

		public List<CodigoCiiu> CodigoCiiuPorActividadConsultar(int idActividad)
		{
			List<CodigoCiiu> Lista;
			param = new DynamicParameters();
			param.Add(name: "ID_ACTIVIDAD_ECONOMICA", value: idActividad, direction: ParameterDirection.Input);

			try
			{
				Lista = (List<CodigoCiiu>)OracleConnection.Query<CodigoCiiu>("SELECT * FROM CODIGOS_CIIU WHERE ID_ACTIVIDAD_ECONOMICA =:ID_ACTIVIDAD_ECONOMICA ", param);
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}


		public List<Profesion> ProfesionConsultar()
		{
			List<Profesion> Lista;

			try
			{
				Lista = (List<Profesion>)OracleConnection.Query<Profesion>("SELECT * FROM PROFESION");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public Profesion ProfesionPorIdConsultar(Int64 idProfesion)
		{
			Profesion Lista;
			param = new DynamicParameters();
			param.Add(name: "ID_PROFESION", value: idProfesion, direction: ParameterDirection.Input);
			try
			{
				Lista = (Profesion)OracleConnection.Query<Profesion>("SELECT * FROM PROFESION WHERE ID_PROFESION=:ID_PROFESION", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public List<TipoEmpresa> TipoEmpresaConsultar()
		{
			List<TipoEmpresa> Lista;

			try
			{
				Lista = (List<TipoEmpresa>)OracleConnection.Query<TipoEmpresa>("SELECT * FROM TIPO_EMPRESA");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}


		public TipoEmpresa TipoEmpresaPorIdConsultar(Int64 idTipoEmpresa)
		{
			TipoEmpresa tipoEmp;
			param = new DynamicParameters();
			param.Add(name: "ID_TIPO_EMPRESA", value: idTipoEmpresa, direction: ParameterDirection.Input);
			try
			{
				tipoEmp = (TipoEmpresa)OracleConnection.Query<TipoEmpresa>("SELECT * FROM TIPO_EMPRESA WHERE ID_TIPO_EMPRESA=:ID_TIPO_EMPRESA", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return tipoEmp;
		}

		public List<Ciudad> CiudadConsultar(string departamentoId)
        {
            List<Ciudad> Lista;

			param = new DynamicParameters();
			param.Add(name: "ID_DEPARTAMENTO", value: departamentoId, direction: ParameterDirection.Input);

			try
            {
                Lista = (List<Ciudad>)OracleConnection.Query<Ciudad>("select ID_MUNICIPIO, ID_DEPARTAMENTO, CODIGO_MUNICIPIO, NOMBRE_MUNICIPIO from MUNICIPIO WHERE ID_DEPARTAMENTO =:ID_DEPARTAMENTO order by NOMBRE_MUNICIPIO", param);
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }

            return Lista;
        }

        public List<TipoMoneda> TipoMonedaConsultar()
		{
			List<TipoMoneda> Lista;

			try
			{
				Lista = (List<TipoMoneda>)OracleConnection.Query<TipoMoneda>("SELECT * FROM TIPO_MONEDA");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public TipoMoneda TipoMonedaPorIdConsultar(Int64 idMoneda)
		{
			TipoMoneda tipoMoneda;
			param = new DynamicParameters();
			param.Add(name: "ID_TIPO_MONEDA", value: idMoneda, direction: ParameterDirection.Input);

			try
			{
				tipoMoneda = (TipoMoneda)OracleConnection.Query<TipoMoneda>("SELECT * FROM TIPO_MONEDA WHERE ID_TIPO_MONEDA=:ID_TIPO_MONEDA", param).FirstOrDefault();
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return tipoMoneda;
		}

		public List<OficinaIcetex> OficinaIcetexConsultar()
		{
			List<OficinaIcetex> Lista;

			try
			{
				Lista = (List<OficinaIcetex>)OracleConnection.Query<OficinaIcetex>("SELECT ID_OFICINA_ICETEX,NOMBRE_OFICINA_ICETEX FROM OFICINA_ICETEX");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

        public List<TipoRelacionPEP> TipoRelacionPEPConsultar(string codigoTipoPersona)
        {
            List<TipoRelacionPEP> Lista;
            param = new DynamicParameters();
            try
            {
                string where = string.Empty;
                if (codigoTipoPersona == "PJ")
                { where = "ES_JURIDICA = 1 and ES_NATURAL = 0"; }


                if (codigoTipoPersona == "PN")
                { where = "ES_NATURAL = 1 and ES_JURIDICA = 0"; }

                Lista = (List<TipoRelacionPEP>)OracleConnection.Query<TipoRelacionPEP>("SELECT ID_TIPO_REL_PEP , NOMBRE_TIPO_REL_PEP , ES_NATURAL , ES_JURIDICA  FROM TIPO_REL_PEP WHERE " + where);
             
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }
            return Lista;
        }

        public List<CargoPEP> CargoConsultar()
        {
            List<CargoPEP> Lista;

            try
            {
                Lista = (List<CargoPEP>)OracleConnection.Query<CargoPEP>("SELECT ID_CARGO_PEP , NOMBRE_CARGO_PEP  FROM CARGO_PEP  ORDER BY NOMBRE_CARGO_PEP ");
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }

            return Lista;
        }

		public CargoPEP CargoPorIdConsultar(Int64 idCargo)
		{
			CargoPEP cargo;
			param = new DynamicParameters();
			param.Add(name: "ID_CARGO_PEP", value: idCargo, direction: ParameterDirection.Input);

			try
			{
				cargo = (CargoPEP)OracleConnection.Query<CargoPEP>("SELECT ID_CARGO_PEP , NOMBRE_CARGO_PEP  FROM CARGO_PEP where ID_CARGO_PEP=:ID_CARGO_PEP ", param).FirstOrDefault(); ;
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return cargo;
		}
	}
}



