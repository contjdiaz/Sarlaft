using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FuncionarioLN
    {
        FuncionarioAD Datos = new FuncionarioAD();
        public Funcionario FuncionarioValidacionAutenticacion(string usuario, string contasena)
        {
            return Datos.FuncionarioValidacionAutenticacion(usuario, contasena);
        }

    }
}
