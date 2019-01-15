//using Dapper; //Micro ORM
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
using Dapper;

namespace Datos
{
    public class TipoDocumentoAD : Conexion
	{
        //Ejemplo de CRUD a la base de daros objeto
        // CRUD Create/(Insertar), Read(Consultar), Update(Actualizar), Delete(Eliminar)

        public TipoDocumento TipoDocumentoInsertar(TipoDocumento P)
        {
            param = new DynamicParameters();
           
            param.Add(name: "CODIGO", value: P.CODIGO, direction: ParameterDirection.Input);
            param.Add(name: "NOMBRE_TIPO_DOCUMENTO", value: P.NOMBRE_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
			param.Add(name: "ES_NATURAL", value: P.ES_NATURAL, direction: ParameterDirection.Input);
			param.Add(name: "ES_JURIDICA", value: P.ES_JURIDICA, direction: ParameterDirection.Input);
			param.Add(name: "ID_TIPO_DOCUMENTO", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO TIPO_DOCUMENTO(CODIGO, NOMBRE_TIPO_DOCUMENTO,ES_NATURAL, ES_JURIDICA) VALUES ( :CODIGO, :NOMBRE_TIPO_DOCUMENTO, :ES_NATURAL, :ES_JURIDICA) RETURNING ID_TIPO_DOCUMENTO INTO :ID_TIPO_DOCUMENTO", param);
                if (P.FilasAfectadas > 0)
                {
                    P.ID_TIPO_DOCUMENTO = param.Get<Int64>("ID_TIPO_DOCUMENTO");
                }
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }

        public TipoDocumento TipoDocumentoActualizar(TipoDocumento P)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_TIPO_DOCUMENTO", value: P.ID_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
            param.Add(name: "CODIGO", value: P.CODIGO, direction: ParameterDirection.Input);
            param.Add(name: "NOMBRE_TIPO_DOCUMENTO", value: P.NOMBRE_TIPO_DOCUMENTO, direction: ParameterDirection.Input);
            param.Add(name: "ES_NATURAL", value: P.ES_NATURAL, direction: ParameterDirection.Input);
            param.Add(name: "ES_JURIDICA", value: P.ES_JURIDICA, direction: ParameterDirection.Input);           
            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE TIPO_DOCUMENTO SET " +
                    " CODIGO=: CODIGO, NOMBRE_TIPO_DOCUMENTO =:NOMBRE_TIPO_DOCUMENTO, ES_NATURAL =:ES_NATURAL, ES_JURIDICA =:ES_JURIDICA " +
                    " WHERE ID_TIPO_DOCUMENTO =:ID_TIPO_DOCUMENTO", param);
               
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }

        public List<TipoDocumento> TipoDocumentoConsultar(string codigoTipoPersona)
        {
            List<TipoDocumento> Lista;
            param = new DynamicParameters();
            try
            {
				string where = string.Empty;
				if (codigoTipoPersona == "PJ")
				{ where = "ES_JURIDICA = 1 and ES_NATURAL = 0"; }


				if (codigoTipoPersona == "PN")
				{ where = "ES_NATURAL = 1 and ES_JURIDICA = 0"; }						

				Lista = (List<TipoDocumento>)OracleConnection.Query<TipoDocumento>("SELECT * FROM TIPO_DOCUMENTO WHERE " + where);
						

			}
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex)); 
            }
            return Lista;
        }

        public List<TipoDocumento> TiposDocumentos()
        {
            List<TipoDocumento> Lista;
           
            try
            {               
                Lista = (List<TipoDocumento>)OracleConnection.Query<TipoDocumento>("SELECT * FROM TIPO_DOCUMENTO ");

            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }
            return Lista;
        }

        public TipoDocumento TipoDocumentoPorCodigoConsultar(string codigoTipoDocumento)
		{
			TipoDocumento tpDocumento = new TipoDocumento(); 
			param = new DynamicParameters();
			try
			{
				param = new DynamicParameters();
				param.Add(name: "CODIGO", value: codigoTipoDocumento, direction: ParameterDirection.Input);

				tpDocumento = (TipoDocumento)OracleConnection.Query<TipoDocumento>("SELECT * FROM TIPO_DOCUMENTO WHERE CODIGO= '" + codigoTipoDocumento + "'").FirstOrDefault();


			}
			catch (Exception Ex)
			{
                tpDocumento.mensajeNotificacion = Exepciones.Exepciones(Ex);
                tpDocumento.tipoMensaje = 3;

            }
			return tpDocumento;
		}

		public TipoDocumento TipoDocumentoPorIdConsultar(Int64 idTipoDocumento)
		{
			TipoDocumento tpDocumento = new TipoDocumento();
			param = new DynamicParameters();
			try
			{
				param = new DynamicParameters();
				param.Add(name: "ID_TIPO_DOCUMENTO", value: idTipoDocumento, direction: ParameterDirection.Input);

				tpDocumento = (TipoDocumento)OracleConnection.Query<TipoDocumento>("SELECT * FROM TIPO_DOCUMENTO WHERE ID_TIPO_DOCUMENTO=:ID_TIPO_DOCUMENTO",param).FirstOrDefault();


			}
			catch (Exception Ex)
			{
                tpDocumento.mensajeNotificacion = Exepciones.Exepciones(Ex);
                tpDocumento.tipoMensaje = 3;
            }
			return tpDocumento;
		}
		//public Objeto ObjetoConsultarPorID(Int64 id)
		//{
		//    param = new DynamicParameters();
		//    param.Add(name: "ID_OBJETO", value: id, direction: ParameterDirection.Input);

		//    Objeto Lista = (Objeto) OracleConnection.Query<Objeto>("SELECT ID_OBJETO, ID_TIPO_OBJETO, NOMBRE_OBJETO, DESCRIPCION, UBICACION, ORIGEN_OBJETO FROM OBJETO WHERE ID_OBJETO=:ID_OBJETO", param).FirstOrDefault();
		//    return Lista;
		//}

		//public Objeto ObjetoActualizar(Objeto Objeto)
		//{
		//    param = new DynamicParameters();
		//    param.Add(name: "ID_OBJETO", value: Objeto.ID_OBJETO, direction: ParameterDirection.Input);
		//    param.Add(name: "ID_TIPO_OBJETO", value: Objeto.ID_TIPO_OBJETO, direction: ParameterDirection.Input);
		//    param.Add(name: "NOMBRE_OBJETO", value: Objeto.NOMBRE_OBJETO, direction: ParameterDirection.Input);
		//    param.Add(name: "DESCRIPCION", value: Objeto.DESCRIPCION, direction: ParameterDirection.Input);
		//    param.Add(name: "UBICACION", value: Objeto.UBICACION, direction: ParameterDirection.Input);
		//    param.Add(name: "ORIGEN_OBJETO", value: Objeto.ORIGEN_OBJETO, direction: ParameterDirection.Input);

		//    try
		//    {
		//        Objeto.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE OBJETO SET ID_TIPO_OBJETO=:ID_TIPO_OBJETO, NOMBRE_OBJETO=:NOMBRE_OBJETO, DESCRIPCION=:DESCRIPCION, ORIGEN_OBJETO=:ORIGEN_OBJETO, UBICACION=:UBICACION WHERE ID_OBJETO=:ID_OBJETO", param);
		//    }
		//    catch (Exception Ex)
		//    {
		//        Objeto.mensajeNotificacion = Exepciones.Exepciones(Ex);
		//        Objeto.tipoMensaje = 3;
		//    }
		//    return Objeto;
		//}

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



