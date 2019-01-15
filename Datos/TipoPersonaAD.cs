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
    public class TipoPersonaAD : Conexion
	{
        //Ejemplo de CRUD a la base de daros objeto
        // CRUD Create/(Insertar), Read(Consultar), Update(Actualizar), Delete(Eliminar)

    

   //     public List<TipoPersona> TipoPersonaConsultar()
   //     {
   //         List<TipoPersona> Lista;
   //         param = new DynamicParameters();
   //         try
   //         {
			//	GenericLists comp = new GenericLists();
			//	TipoPersona tp = new TipoPersona();
			//	Lista = comp. ObtenerListaTipoPersona();
			//}
   //         catch (Exception Ex)
   //         {
   //             throw new AplicationException(Exepciones.Exepciones(Ex)); 
   //         }

   //         return Lista;
   //     }

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



