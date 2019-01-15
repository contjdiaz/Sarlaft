using Dapper; //Micro ORM
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using Componentes;

namespace Datos
{
    public class PersonaAD : Conexion
	{
        //Ejemplo de CRUD a la base de daros objeto
        // CRUD Create/(Insertar), Read(Consultar), Update(Actualizar), Delete(Eliminar)
       
        
		public Persona PersonaInsertar(Persona P)
		{
			param = new DynamicParameters();
			param.Add(name: "ID_TIPO_PERSONA", value: P.ID_TIPO_PERSONA, direction: ParameterDirection.Input);
			param.Add(name: "ID_TIPO_DOCUMENTO", value: P.ID_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
			param.Add(name: "NUMERO_DOCUMENTO", value: P.NUMERO_DOCUMENTO, direction: ParameterDirection.Input);
			param.Add(name: "FEC_DILIGENCIAMIENTO", value: DateTime.Now, direction: ParameterDirection.Input);
			param.Add(name: "DECLARACION_BIENES", value: P.DECLARACION_BIENES, direction: ParameterDirection.Input);
			param.Add(name: "AUTORIZACION_DATOS", value: P.AUTORIZACION_DATOS, direction: ParameterDirection.Input);
			param.Add(name: "ID_MUNICIPIO", value: P.ID_MUNICIPIO, direction: ParameterDirection.Input);
			param.Add(name: "TOTAL_ACTIVOS", value: P.TOTAL_ACTIVOS, direction: ParameterDirection.Input);
			param.Add(name: "TOTAL_PASIVOS", value: P.TOTAL_PASIVOS, direction: ParameterDirection.Input);
			param.Add(name: "TOTAL_PATRIMONIO", value: P.TOTAL_PATRIMONIO, direction: ParameterDirection.Input);
			param.Add(name: "ING_MENSUALES", value: P.ING_MENSUALES, direction: ParameterDirection.Input);
			param.Add(name: "EGR_MENSUALES", value: P.EGR_MENSUALES, direction: ParameterDirection.Input);
			param.Add(name: "OTR_INGRESOS", value: P.OTR_INGRESOS, direction: ParameterDirection.Input);
			param.Add(name: "CONCEPTO_OTR_ING", value: P.CONCEPTO_OTR_ING, direction: ParameterDirection.Input);
			param.Add(name: "ID_PERSONA", dbType: DbType.Int64, direction: ParameterDirection.Output);
			try
			{
				P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO	PERSONA(ID_TIPO_PERSONA, ID_TIPO_DOCUMENTO, NUMERO_DOCUMENTO,FEC_DILIGENCIAMIENTO, DECLARACION_BIENES,AUTORIZACION_DATOS,ID_MUNICIPIO," +
					"TOTAL_ACTIVOS,TOTAL_PASIVOS,TOTAL_PATRIMONIO,ING_MENSUALES,EGR_MENSUALES,OTR_INGRESOS,CONCEPTO_OTR_ING) VALUES (:ID_TIPO_PERSONA, :ID_TIPO_DOCUMENTO, :NUMERO_DOCUMENTO, :FEC_DILIGENCIAMIENTO, :DECLARACION_BIENES, :AUTORIZACION_DATOS, :ID_MUNICIPIO," +
					":TOTAL_ACTIVOS,:TOTAL_PASIVOS,:TOTAL_PATRIMONIO,:ING_MENSUALES,:EGR_MENSUALES,:OTR_INGRESOS,:CONCEPTO_OTR_ING) RETURNING ID_PERSONA INTO :ID_PERSONA", param);
				if (P.FilasAfectadas > 0)
				{
					P.ID_PERSONA = param.Get<Int64>("ID_PERSONA");                   
                }
			}
			catch (Exception Ex)
			{
				P.mensajeNotificacion = Exepciones.Exepciones(Ex);
				P.tipoMensaje = 3;
			}

           

            return P;
		}

		public List<Persona> PersonaConsultar()
		{
			List<Persona> Lista;
			param = new DynamicParameters();
			try
			{				
				Lista = (List<Persona>)OracleConnection.Query<Persona>("SELECT ID_PERSONA, ID_TIPO_PERSONA, ID_TIPO_DOCUMENTO, NUMERO_DOCUMENTO,FEC_DILIGENCIAMIENTO, DECLARACION_BIENES,AUTORIZACION_DATOS,ID_MUNICIPIO,TOTAL_ACTIVOS,TOTAL_PASIVOS,TOTAL_PATRIMONIO,ING_MENSUALES,EGR_MENSUALES,OTR_INGRESOS,CONCEPTO_OTR_ING FROM PERSONA");
			}
			catch (Exception Ex)
			{
				throw new AplicationException(Exepciones.Exepciones(Ex));
			}

			return Lista;
		}

		public Persona PersonaConsultarPorID(Int64 id)
		{
			param = new DynamicParameters();
			param.Add(name: "ID_PERSONA", value: id, direction: ParameterDirection.Input);

			Persona Lista = (Persona)OracleConnection.Query<Persona>(" SELECT ID_PERSONA, ID_TIPO_PERSONA, ID_TIPO_DOCUMENTO, NUMERO_DOCUMENTO,FEC_DILIGENCIAMIENTO, DECLARACION_BIENES,AUTORIZACION_DATOS,ID_MUNICIPIO,TOTAL_ACTIVOS,TOTAL_PASIVOS,TOTAL_PATRIMONIO,ING_MENSUALES,EGR_MENSUALES,OTR_INGRESOS,CONCEPTO_OTR_ING FROM PERSONA WHERE ID_PERSONA=:ID_PERSONA", param).FirstOrDefault();
			return Lista;
		}

		public Persona PersonaConsultarPorTipoDocumento(Int64 idTipoDocumento, string documento)
		{
			//param = new DynamicParameters();
			//param.Add(name: "ID_PERSONA", value: id, direction: ParameterDirection.Input);

			Persona Lista = (Persona)OracleConnection.Query<Persona>(" SELECT ID_PERSONA, ID_TIPO_PERSONA, ID_TIPO_DOCUMENTO, NUMERO_DOCUMENTO,FEC_DILIGENCIAMIENTO, DECLARACION_BIENES,AUTORIZACION_DATOS,ID_MUNICIPIO,TOTAL_ACTIVOS,TOTAL_PASIVOS,TOTAL_PATRIMONIO,ING_MENSUALES,EGR_MENSUALES,OTR_INGRESOS,CONCEPTO_OTR_ING FROM PERSONA WHERE ID_TIPO_DOCUMENTO=" +idTipoDocumento+ " and NUMERO_DOCUMENTO = '" + documento +"'").FirstOrDefault();
			return Lista;
		}

		public Persona PersonaActualizar(Persona P)
		{
			param = new DynamicParameters();
			param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
			param.Add(name: "ID_TIPO_PERSONA", value: P.ID_TIPO_PERSONA, direction: ParameterDirection.Input);
			param.Add(name: "ID_TIPO_DOCUMENTO", value: P.ID_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
			param.Add(name: "NUMERO_DOCUMENTO", value: P.NUMERO_DOCUMENTO, direction: ParameterDirection.Input);		
			param.Add(name: "DECLARACION_BIENES", value: P.DECLARACION_BIENES, direction: ParameterDirection.Input);
			param.Add(name: "AUTORIZACION_DATOS", value: P.AUTORIZACION_DATOS, direction: ParameterDirection.Input);
			param.Add(name: "ID_MUNICIPIO", value: P.ID_MUNICIPIO, direction: ParameterDirection.Input);
			param.Add(name: "TOTAL_ACTIVOS", value: P.TOTAL_ACTIVOS, direction: ParameterDirection.Input);
			param.Add(name: "TOTAL_PASIVOS", value: P.TOTAL_PASIVOS, direction: ParameterDirection.Input);
			param.Add(name: "TOTAL_PATRIMONIO", value: P.TOTAL_PATRIMONIO, direction: ParameterDirection.Input);
			param.Add(name: "ING_MENSUALES", value: P.ING_MENSUALES, direction: ParameterDirection.Input);
			param.Add(name: "EGR_MENSUALES", value: P.EGR_MENSUALES, direction: ParameterDirection.Input);
			param.Add(name: "OTR_INGRESOS", value: P.OTR_INGRESOS, direction: ParameterDirection.Input);
			param.Add(name: "CONCEPTO_OTR_ING", value: P.CONCEPTO_OTR_ING, direction: ParameterDirection.Input);

			try
			{
				P.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE PERSONA SET ID_TIPO_PERSONA=:ID_TIPO_PERSONA, ID_TIPO_DOCUMENTO=:ID_TIPO_DOCUMENTO, NUMERO_DOCUMENTO=:NUMERO_DOCUMENTO, DECLARACION_BIENES=:DECLARACION_BIENES, AUTORIZACION_DATOS=:AUTORIZACION_DATOS, ID_MUNICIPIO=:ID_MUNICIPIO, " +
					"TOTAL_ACTIVOS=:TOTAL_ACTIVOS,TOTAL_PASIVOS=:TOTAL_PASIVOS, TOTAL_PATRIMONIO=:TOTAL_PATRIMONIO, ING_MENSUALES=:ING_MENSUALES, EGR_MENSUALES=:EGR_MENSUALES,OTR_INGRESOS=:OTR_INGRESOS, CONCEPTO_OTR_ING=:CONCEPTO_OTR_ING WHERE ID_PERSONA=:ID_PERSONA", param);
                
			}
			catch (Exception Ex)
			{
				P.mensajeNotificacion = Exepciones.Exepciones(Ex);
				P.tipoMensaje = 3;
			}
			return P;
		}

        public List<PersonaConsulta> PersonaConsultarParametros(Int64 idtipoDocumento = 0, Int64 idtipoPersona = 0, string numeroDocumento = "")
        {
            List<PersonaConsulta> Lista = new List<PersonaConsulta>();
            try
            {
                param = new DynamicParameters();
                param.Add(name: "ID_TIPO_DOC", value: idtipoDocumento, direction: ParameterDirection.Input);
                param.Add(name: "NUMERO_DOC", value: numeroDocumento, direction: ParameterDirection.Input);
                param.Add(name: "IT_TIPO_PER", value: idtipoPersona, direction: ParameterDirection.Input);
                string consultaNumDoc = numeroDocumento == string.Empty ? " " : "  (p.numero_documento =:NUMERO_DOC) and";
                string consulta = " select p.ID_PERSONA,tp.CODIGO_TIPO_PERSONA, tp.nombre_tipo_persona,  p.id_tipo_documento,td.NOMBRE_TIPO_DOCUMENTO, p.numero_documento, "
                    + "case  when n.primer_nombre is null then  j.razon_social else "
                    + " n.primer_nombre || ' ' || n.segundo_nombre || ' ' || n.primer_apellido || ' ' || n.segundo_apellido  end as nombre,"
                    + " case  when r.LISTA_CLINTON is null then  'Sin datos' else r.LISTA_CLINTON  end as LISTA_CLINTON"
                    + " from persona p "
                    + " inner join tipo_documento td on td.ID_TIPO_DOCUMENTO = p.ID_TIPO_DOCUMENTO"
                    + " inner join tipo_persona tp on tp.id_tipo_persona = p.id_tipo_persona"
                    + " left join natural n on n.id_persona = p.id_persona"
                    + " left join juridica j on j.id_persona = p.id_persona"
                    + " left join RESPUESTAWSDUEDILIGENCE r on r.IDENTIFICACION = p.numero_documento"
                    + " where ( p.id_tipo_documento = :ID_TIPO_DOC OR 0 =:ID_TIPO_DOC ) and"
                    + consultaNumDoc
                    + "   (p.id_tipo_persona = :IT_TIPO_PER OR 0 = :IT_TIPO_PER )";
               Lista = (List<PersonaConsulta>)OracleConnection.Query<PersonaConsulta>(consulta, param: param);
                
            }
            catch (Exception ex)
            {
                PersonaConsulta p = new PersonaConsulta();
                p.mensajeNotificacion = Exepciones.Exepciones(ex);
                p.tipoMensaje = 3;
                Lista.Add(p);
               
            }

            return Lista;
        }
		//public Objeto ObjetoEliminar(Objeto Objeto)
		//{
		//    param = new DynamicParameters();
		//    param.Add(name: "ID_OBJETO", value: Objeto.ID_OBJETO, direction: ParameterDirection.Input);
		//    try
		//    {
		//        Objeto.FilasAfectadas = this.OracleConnection.Execute(@"DELETE FROM OBJETO WHERE ID_OBJETO=:ID_OBJETO", param);
		//    }
		//    catch (Exception Ex)
		//    {
		//        Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
		//        Objeto.tipoMensaje = 3;
		//    }
		//    return Objeto;
		//}
	}
}



