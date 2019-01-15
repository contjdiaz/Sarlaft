using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
	public class ListasLN
	{
		ListasAD Datos = new ListasAD();

		public List<TipoPersona> TipoPersonaConsultar()
		{
			return Datos.TipoPersonaConsultar();
		}

        public TipoPersona TipoPersonaPorCodigoConsultar(string codigo)
        {
            return Datos.TipoPersonaPorCodigoConsultar(codigo);
        }

        public List<Sexo> SexoConsultar()
		{
			return Datos.SexoConsultar();
		}

		public List<EstadoCivil> EstadoCivilConsultar()
		{
			return Datos.EstadoCivilConsultar();
		}

		public List<Departamento> DepartamentoConsultar()
		{
			return Datos.DepartamentoConsultar();
		}

		public Departamento DepartamentoPorIdMunicipioConsultar(Int64 idMunicipio)
		{
			return Datos.DepartamentoPorIdMunicipioConsultar(idMunicipio);
		}

		public List<Municipo> MunicipioConsultar(int idDepartamento)
		{
			return Datos.MunicipioConsultar(idDepartamento);
		}

		public Municipo MunicipioPorIdConsultar(Int64 idMunicipio)
		{
			return Datos.MunicipioPorIdConsultar(idMunicipio);
		}

		public List<ActividadEconomica> ActividadEconomicaConsultar => Datos.ActividadEconomicaConsultar();

		public ActividadEconomica ActividadEconomicaPorCodigoCiiuConsultar(Int64 idCodigoCiiu)
		{
			return Datos.ActividadEconomicaPorCodigoCiiuConsultar(idCodigoCiiu);
		}
		public ActividadEconomica ActividadEconomicaPorIdConsultar(Int64 idActEco)
		{
			return Datos.ActividadEconomicaPorIdConsultar(idActEco);
		}

		public List<TipoOperacion> TipoOperacionConsultar()
		{
			return Datos.TipoOperacionConsultar();
		}

		public TipoOperacion TipoOperacionPorIDConsultar(Int64 idOperacion)
		{
			return Datos.TipoOperacionPorIDConsultar(idOperacion);
		}

			public List<CodigoCiiu> CodigoCiiuConsultar()
		{
			return Datos.CodigoCiiuConsultar();
		}

		public List<CodigoCiiu> CodigoCiiuPorActividadConsultar(int idActividad)
		{
			return Datos.CodigoCiiuPorActividadConsultar(idActividad);
		}

		public List<Profesion> ProfesionConsultar()
		{
			return Datos.ProfesionConsultar();
		}
		public Profesion ProfesionPorIdConsultar(Int64 idProfesion)
		{
			return Datos.ProfesionPorIdConsultar(idProfesion);
		}

		public List<TipoEmpresa> TipoEmpresaConsultar => Datos.TipoEmpresaConsultar();

		public List<TipoMoneda> TipoMonedaConsultar()
		{
			return Datos.TipoMonedaConsultar();
		}

		public TipoMoneda TipoMonedaPorIdConsultar(Int64 idMoneda)
		{
			return Datos.TipoMonedaPorIdConsultar(idMoneda);
		}

		public List<Ciudad> CiudadConsultar(string departamentoId)
		{
			return Datos.CiudadConsultar(departamentoId);
		}

		public List<OficinaIcetex> OficinaIcetexConsultar()
		{
			return Datos.OficinaIcetexConsultar();
		}

		public List<TipoRelacionPEP> TipoRelacionPEPConsultar(string codigoTipoPersona)
		{
			return Datos.TipoRelacionPEPConsultar(codigoTipoPersona);
		}
		public List<CargoPEP> CargoConsultar()
		{
			return Datos.CargoConsultar();
		}

		public CargoPEP CargoPorIdConsultar(Int64 idCargo)
		{
			return Datos.CargoPorIdConsultar(idCargo);
		}

		public EstadoCivil EstadoCivilPorIdConsultar(Int64 idEstadoCivil)
		{
			return Datos.EstadoCivilPorIdConsultar(idEstadoCivil);
		}

		public Sexo SexoPorIdConsultar(Int64 idSexo)
		{
			return Datos.SexoPorIdConsultar(idSexo);
		}
		public CodigoCiiu CodigoCiiuPorIdConsultar(Int64 idCodigo)
		{
			return Datos.CodigoCiiuPorIdConsultar(idCodigo);
		}
		public TipoEmpresa TipoEmpresaPorIdConsultar(Int64 idTipoEmpresa)
		{
			return Datos.TipoEmpresaPorIdConsultar(idTipoEmpresa);
		}
	}
}
