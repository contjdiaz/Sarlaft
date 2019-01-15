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
    public class FuncionarioAD : Conexion
    {
        public Funcionario FuncionarioValidacionAutenticacion(string usuario, string contasena)
        {
            Funcionario lista = new Funcionario();
            param = new DynamicParameters();
            param.Add(name: "LOGUIN", value: usuario, direction: ParameterDirection.Input);
            param.Add(name: "PASSWORD", value: contasena, direction: ParameterDirection.Input);

            List<Funcionario> ListaFuncionario = new List<Funcionario>() { 
                new Funcionario(){ ID_FUNCIONARIO=1, PRIMER_NOMBRE= "Grey", SEGUNDO_NOMBRE = "Milena", PRIMER_APELLIDO ="Jiménez", SEGUNDO_APELLIDO= "Anaya", CARGO = "Contratista", AREA = "Fabrica", LOGUIN ="contgjimenez@icetex.gov.co", PASSWORD = "Grey2017"},
                new Funcionario(){ ID_FUNCIONARIO=2, PRIMER_NOMBRE= "Sandra", SEGUNDO_NOMBRE = "", PRIMER_APELLIDO ="Morón", SEGUNDO_APELLIDO= "", CARGO = "Contratista", AREA = "Fabrica", LOGUIN ="contsmoron@icetex.gov.co", PASSWORD = "12345"}
            };

             lista = ListaFuncionario.Where(x => x.LOGUIN == usuario && x.PASSWORD == contasena).FirstOrDefault(); 

            //Lista = (Funcionario)OracleConnection.Query<Funcionario>("SELECT ID_FUNCIONARIO, PRIMER_NOMBRE, SEGUNDO_NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, CARGO, AREA, LOGUIN, PASSWORD FROM SL_FUNCIONARIO WHERE LOGUIN=:LOGUIN AND PASSWORD=:PASSWORD", param).FirstOrDefault();
             return lista;
        }

    }
}
