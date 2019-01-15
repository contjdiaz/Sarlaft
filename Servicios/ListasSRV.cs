using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ListasSRV
	{
		TipoDocumentoLN ObjetoLN = new TipoDocumentoLN();
		ListasLN ListaLN = new ListasLN();

        public List<TipoDocumento> TipoDocumentoConsultar(string codigoTipoPersona)
        {
            return ObjetoLN.TipoDocumentoConsultar(codigoTipoPersona);
        }

        public List<TipoDocumento> TiposDocumentos()
        {
            return ObjetoLN.TiposDocumentos();
        }

        public List<TipoPersona> TipoPersonaConsultar()
		{
			return ListaLN.TipoPersonaConsultar();
		}

        public TipoPersona TipoPersonaPorCodigoConsultar(string codigo)
        {
            return ListaLN.TipoPersonaPorCodigoConsultar(codigo);
        }

        public List<Ciudad> CiudadConsultar(string departamentoId)
        {
            return ListaLN.CiudadConsultar(departamentoId);
        }


        public List<Sexo> SexoConsultar()
		{
			return ListaLN.SexoConsultar();
		}

		public List<EstadoCivil> EstadoCivilConsultar()
		{
			return ListaLN.EstadoCivilConsultar();
		}

		public List<Departamento> DepartamentoConsultar()
		{
			return ListaLN.DepartamentoConsultar();
		}

		public Departamento DepartamentoPorIdMunicipioConsultar(Int64 idMunicipio)
		{
			return ListaLN.DepartamentoPorIdMunicipioConsultar(idMunicipio);
		}

		public List<Municipo> MunicipioConsultar(int idDepartamento)
		{
			return ListaLN.MunicipioConsultar(idDepartamento);
		}

		public Municipo MunicipioPorIdConsultar(Int64 idMunicipio)
		{
			return ListaLN.MunicipioPorIdConsultar(idMunicipio);
		}

		public List<ActividadEconomica> ActividadEconomicaConsultar()
		{
			return ListaLN.ActividadEconomicaConsultar;
		}

		public ActividadEconomica ActividadEconomicaPorCodigoCiiuConsultar(Int64 idCodigoCiiu)
		{
			return ListaLN.ActividadEconomicaPorCodigoCiiuConsultar(idCodigoCiiu);
		}

		public ActividadEconomica ActividadEconomicaPorIdConsultar(Int64 idActEco)
		{
			return ListaLN.ActividadEconomicaPorIdConsultar(idActEco);
		}

		public List<TipoOperacion> TipoOperacionConsultar()
		{
			return ListaLN.TipoOperacionConsultar();
		}

		public TipoOperacion TipoOperacionPorIDConsultar(Int64 idOperacion)
		{
			return ListaLN.TipoOperacionPorIDConsultar(idOperacion);
		}

		public List<CodigoCiiu> CodigoCiiuConsultar()
		{
			return ListaLN.CodigoCiiuConsultar();
		}

		public List<CodigoCiiu> CodigoCiiuPorActividadConsultar(int idActividad)
		{
			return ListaLN.CodigoCiiuPorActividadConsultar(idActividad);
		}

		public List<Profesion> ProfesionConsultar()
		{
			return ListaLN.ProfesionConsultar();
		}

		public Profesion ProfesionPorIdConsultar(Int64 idProfesion)
		{
			return ListaLN.ProfesionPorIdConsultar(idProfesion);
		}

		public List<TipoEmpresa> TipoEmpresaConsultar()
		{
			return ListaLN.TipoEmpresaConsultar;
		}

		public List<TipoMoneda> TipoMonedaConsultar()
		{
			return ListaLN.TipoMonedaConsultar();
		}

		public TipoMoneda TipoMonedaPorIdConsultar(Int64 idMoneda)
		{
			return ListaLN.TipoMonedaPorIdConsultar(idMoneda);
		}

		public List<OficinaIcetex> OficinaConsultar()
		{
			return ListaLN.OficinaIcetexConsultar();
		}

        public List<TipoRelacionPEP> TipoRelacionPEPConsultar(string codigoTipoPersona)
        {
            return ListaLN.TipoRelacionPEPConsultar(codigoTipoPersona);
        }

        public List<CargoPEP> CargoConsultar()
        {
            return ListaLN.CargoConsultar();
        }

		public CargoPEP CargoPorIdConsultar(Int64 idCargo)
		{
			return ListaLN.CargoPorIdConsultar(idCargo);
		}

		public TipoDocumento TipoDocumentoPorCodigoConsultar(string codigoTipoDocumento)
		{
			return ObjetoLN.TipoDocumentoPorCodigoConsultar(codigoTipoDocumento);
		}

		public TipoDocumento TipoDocumentoPorIdConsultar(Int64 idTipoDocumento)
		{
			return ObjetoLN.TipoDocumentoPorIdConsultar(idTipoDocumento);
		}

		public EstadoCivil EstadoCivilPorIdConsultar(Int64 idEstadoCivil)
		{
			return ListaLN.EstadoCivilPorIdConsultar(idEstadoCivil);
		}

		public Sexo SexoPorIdConsultar(Int64 idSexo)
		{
			return ListaLN.SexoPorIdConsultar(idSexo);
		}

		public CodigoCiiu CodigoCiiuPorIdConsultar(Int64 idCodigo)
		{
			return ListaLN.CodigoCiiuPorIdConsultar(idCodigo);
		}

		public TipoEmpresa TipoEmpresaPorIdConsultar(Int64 idTipoEmpresa)
		{
			return ListaLN.TipoEmpresaPorIdConsultar(idTipoEmpresa);
		}
	}
}
