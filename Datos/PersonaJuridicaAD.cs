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
    public class PersonaJuridicaAD : Conexion
    {

        public PersonaJuridica PersonaJuridicaInsertar(PersonaJuridica P)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_PERSONA", value: P.ID_PERSONA, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_EMPRESA", value: P.ID_TIPO_EMPRESA, direction: ParameterDirection.Input);
            param.Add(name: "RAZON_SOCIAL", value: P.RAZON_SOCIAL, direction: ParameterDirection.Input);
            param.Add(name: "ID_CODIGO_CIIU", value: P.ID_CODIGO_CIIU, direction: ParameterDirection.Input);
            param.Add(name: "DIRECCION", value: P.DIRECCION, direction: ParameterDirection.Input);
            param.Add(name: "ID_MUNICIPIO", value: P.ID_MUNICIPIO, direction: ParameterDirection.Input);
            param.Add(name: "TELEFONO", value: P.TELEFONO, direction: ParameterDirection.Input);
            param.Add(name: "EXTENSION", value: P.EXTENSION, direction: ParameterDirection.Input);
            param.Add(name: "FAX", value: P.FAX, direction: ParameterDirection.Input);
            param.Add(name: "CORREO", value: P.CORREO, direction: ParameterDirection.Input);
            param.Add(name: "DIR_SUCURSAL", value: P.DIR_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "ID_MCPO_SUCURSAL", value: P.ID_MCPO_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "TEL_SUCURSAL", value: P.TEL_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "EXT_SUCURSAL", value: P.EXT_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "FAX_SUCURSAL", value: P.FAX_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "CORREO_SUCURSAL", value: P.CORREO_SUCURSAL, direction: ParameterDirection.Input);

            param.Add(name: "ID_JURIDICA", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {

                P.FilasAfectadas = this.OracleConnection.Execute(@"INSERT INTO JURIDICA(ID_PERSONA" +
                ",ID_TIPO_EMPRESA" +
                ",RAZON_SOCIAL" +
                ",ID_CODIGO_CIIU" +
                ",DIRECCION" +
                ",ID_MUNICIPIO" +
                ",TELEFONO" +
                ",EXTENSION" +
                ",FAX" +
                ",CORREO" +
                ",DIR_SUCURSAL" +
                ",ID_MCPO_SUCURSAL" +
                ",TEL_SUCURSAL" +
                ",EXT_SUCURSAL" +
                ",FAX_SUCURSAL" +
                ",CORREO_SUCURSAL)"
                + "VALUES (:ID_PERSONA" +
                ",:ID_TIPO_EMPRESA" +
                ",:RAZON_SOCIAL" +
                ",:ID_CODIGO_CIIU" +
                ",:DIRECCION" +
                ",:ID_MUNICIPIO" +
                ",:TELEFONO" +
                ",:EXTENSION" +
                ",:FAX" +
                ",:CORREO" +
                ",:DIR_SUCURSAL" +
                ",:ID_MCPO_SUCURSAL" +
                ",:TEL_SUCURSAL" +
                ",:EXT_SUCURSAL" +
                ",:FAX_SUCURSAL" +
                ",:CORREO_SUCURSAL" +
                ") RETURNING ID_JURIDICA INTO :ID_JURIDICA", param);
                if (P.FilasAfectadas > 0)
                {
                    P.ID_JURIDICA = param.Get<Int64>("ID_JURIDICA");
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

        public PersonaJuridica PersonaJuridicaActualizar(PersonaJuridica P)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_JURIDICA", value: P.ID_JURIDICA, direction: ParameterDirection.Input);
            param.Add(name: "ID_TIPO_EMPRESA", value: P.ID_TIPO_EMPRESA, direction: ParameterDirection.Input);
            param.Add(name: "RAZON_SOCIAL", value: P.RAZON_SOCIAL, direction: ParameterDirection.Input);
            param.Add(name: "ID_CODIGO_CIIU", value: P.ID_CODIGO_CIIU, direction: ParameterDirection.Input);
            param.Add(name: "DIRECCION", value: P.DIRECCION, direction: ParameterDirection.Input);
            param.Add(name: "ID_MUNICIPIO", value: P.ID_MUNICIPIO, direction: ParameterDirection.Input);
            param.Add(name: "TELEFONO", value: P.TELEFONO, direction: ParameterDirection.Input);
            param.Add(name: "EXTENSION", value: P.EXTENSION, direction: ParameterDirection.Input);
            param.Add(name: "FAX", value: P.FAX, direction: ParameterDirection.Input);
            param.Add(name: "CORREO", value: P.CORREO, direction: ParameterDirection.Input);
            param.Add(name: "DIR_SUCURSAL", value: P.DIR_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "ID_MCPO_SUCURSAL", value: P.ID_MCPO_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "TEL_SUCURSAL", value: P.TEL_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "EXT_SUCURSAL", value: P.EXT_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "FAX_SUCURSAL", value: P.FAX_SUCURSAL, direction: ParameterDirection.Input);
            param.Add(name: "CORREO_SUCURSAL", value: P.CORREO_SUCURSAL, direction: ParameterDirection.Input);


            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE JURIDICA SET " +
                "ID_TIPO_EMPRESA=:ID_TIPO_EMPRESA" +
                ",RAZON_SOCIAL=:RAZON_SOCIAL" +
                ",ID_CODIGO_CIIU=:ID_CODIGO_CIIU" +
                ",DIRECCION=:DIRECCION" +
                ",ID_MUNICIPIO=:ID_MUNICIPIO" +
                ",TELEFONO=:TELEFONO" +
                ",EXTENSION=:EXTENSION" +
                ",FAX=:FAX" +
                ",CORREO=:CORREO" +
                ",DIR_SUCURSAL=:DIR_SUCURSAL" +
                ",ID_MCPO_SUCURSAL=:ID_MCPO_SUCURSAL" +
                ",TEL_SUCURSAL=:TEL_SUCURSAL" +
                ",EXT_SUCURSAL=:EXT_SUCURSAL" +
                ",FAX_SUCURSAL=:FAX_SUCURSAL" +
                ",CORREO_SUCURSAL=:CORREO_SUCURSAL" +
                " WHERE ID_JURIDICA =:ID_JURIDICA"
                , param);
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }

        public PersonaJuridica RepresentanteLegalActualizar(PersonaJuridica P)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_JURIDICA", value: P.ID_JURIDICA, direction: ParameterDirection.Input);
            param.Add(name: "ID_REP_LEGAL", value: P.ID_REP_LEGAL, direction: ParameterDirection.Input);


            try
            {
                P.FilasAfectadas = this.OracleConnection.Execute(@"UPDATE JURIDICA SET " +
                "ID_REP_LEGAL=:ID_REP_LEGAL" +
               " WHERE ID_JURIDICA =:ID_JURIDICA"
                , param);
            }
            catch (Exception Ex)
            {
                P.mensajeNotificacion = Exepciones.Exepciones(Ex);
                P.tipoMensaje = 3;
            }
            return P;
        }

        public List<PersonaJuridica> PersonaJuridicaConsultar()
        {
            List<PersonaJuridica> Lista;
            param = new DynamicParameters();
            try
            {
                Lista = (List<PersonaJuridica>)OracleConnection.Query<PersonaJuridica>("SELECT ID_JURIDICA,  ID_PERSONA " +
                ",ID_TIPO_EMPRESA" +
                ",RAZON_SOCIAL" +
                ",ID_CODIGO_CIIU" +
                ",DIRECCION" +
                ",ID_MUNICIPIO" +
                ",TELEFONO" +
                ",EXTENSION" +
                ",FAX" +
                ",CORREO" +
                ",DIR_SUCURSAL" +
                ",ID_MCPO_SUCURSAL" +
                ",TEL_SUCURSAL" +
                ",EXT_SUCURSAL" +
                ",FAX_SUCURSAL" +
                ",CORREO_SUCURSAL" +
                ",ID_REP_LEGAL" +
                " FROM JURIDICA");
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }

            return Lista;
        }

        public PersonaJuridica PersonaJuridicaConsultarPorID(Int64 id)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_JURIDICA", value: id, direction: ParameterDirection.Input);

            PersonaJuridica pn = (PersonaJuridica)OracleConnection.Query<PersonaJuridica>("SELECT ID_JURIDICA,ID_PERSONA " +
                                ",ID_TIPO_EMPRESA" +
                                ",RAZON_SOCIAL" +
                                ",ID_CODIGO_CIIU" +
                                ",DIRECCION" +
                                ",ID_MUNICIPIO" +
                                ",TELEFONO" +
                                 ",EXTENSION" +
                                ",FAX" +
                                ",CORREO" +
                                ",DIR_SUCURSAL" +
                                ",ID_MCPO_SUCURSAL" +
                                ",TEL_SUCURSAL" +
                                ",EXT_SUCURSAL" +
                                ",FAX_SUCURSAL" +
                                ",CORREO_SUCURSAL" +
                                ",ID_REP_LEGAL" +
                    " FROM JURIDICA WHERE ID_JURIDICA=:ID_JURIDICA", param).FirstOrDefault();
            return pn;
        }

        public PersonaJuridica PersonaJuridicaConsultarPorPersonaID(Int64 idpersona)
        {
            param = new DynamicParameters();
            param.Add(name: "ID_PERSONA", value: idpersona, direction: ParameterDirection.Input);

            PersonaJuridica pn = (PersonaJuridica)OracleConnection.Query<PersonaJuridica>("SELECT ID_JURIDICA,ID_PERSONA " +
                                ",ID_TIPO_EMPRESA" +
                                ",RAZON_SOCIAL" +
                                ",ID_CODIGO_CIIU" +
                                ",DIRECCION" +
                                ",ID_MUNICIPIO" +
                                ",TELEFONO" +
                                 ",EXTENSION" +
                                ",FAX" +
                                ",CORREO" +
                                ",DIR_SUCURSAL" +
                                ",ID_MCPO_SUCURSAL" +
                                ",TEL_SUCURSAL" +
                                ",EXT_SUCURSAL" +
                                ",FAX_SUCURSAL" +
                                ",CORREO_SUCURSAL" +
                                ",ID_REP_LEGAL" +
                    " FROM JURIDICA WHERE ID_PERSONA=:ID_PERSONA", param).FirstOrDefault();
            return pn;
        }

        public PersonaJuridica PersonaJuridicaPorIdentificacionConsultar(Int64 idTipoDocumento, string numeroDocumento)
        {
          
            try
            {
                PersonaJuridica pn = (PersonaJuridica)OracleConnection.Query<PersonaJuridica>("SELECT j.ID_JURIDICA, j.ID_PERSONA " +
                                ",j.ID_TIPO_EMPRESA" +
                                ",j.RAZON_SOCIAL" +
                                ",j.ID_CODIGO_CIIU" +
                                ",j.DIRECCION" +
                                ",j.ID_MUNICIPIO" +
                                ",j.TELEFONO" +
                                 ",j.EXTENSION" +
                                ",j.FAX" +
                                ",j.CORREO" +
                                ",j.DIR_SUCURSAL" +
                                ",j.ID_MCPO_SUCURSAL" +
                                ",j.TEL_SUCURSAL" +
                                ",j.EXT_SUCURSAL" +
                                ",j.FAX_SUCURSAL" +
                                ",j.CORREO_SUCURSAL" +
                                ",j.ID_REP_LEGAL " +
                    " from JURIDICA j" +
                    " inner join persona p on p.id_persona = j.id_persona " +
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
