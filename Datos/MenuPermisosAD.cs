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
    public class MenuPermisosAD: Conexion
    {
        public List<Menu> MenuRolConsultar(Int64 idRol)
        {
            List<Menu> Lista;
            param = new DynamicParameters();
            param.Add("ID_ROL", value: idRol, direction: ParameterDirection.Input);
            try
            {
                Lista = (List<Menu>)OracleConnection.Query<Menu>("select M.ID_MENU,ID_MENU_PADRE, NOMBRE_MENU, CONTROLADOR_MENU, NOMBRE_ACCION_MENU, ADICIONAR, EDITAR,ELIMINAR,CONSULTAR" 
                    + " FROM MENU M INNER JOIN PERMISO_ROL PR on PR.ID_MENU = M.ID_MENU"
                    + " WHERE PR.ID_ROL =:ID_ROL", param);
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }

            return Lista;
        }

        public List<UsuarioRol> UsuarioRolConsultar(Int64 idUsuario)
        {
            List<UsuarioRol> Lista;
            param = new DynamicParameters();
            param.Add("ID_USUARIO", value: idUsuario, direction: ParameterDirection.Input);
            try
            {
                Lista = (List<UsuarioRol>)OracleConnection.Query<UsuarioRol>("select ID_USUARIO_ROL,ID_USUARIO, ID_ROL"
                    + " FROM USUARIO_ROL WHERE ID_USUARIO =:ID_USUARIO", param);
            }
            catch (Exception Ex)
            {
                throw new AplicationException(Exepciones.Exepciones(Ex));
            }

            return Lista;
        }

    }
}
