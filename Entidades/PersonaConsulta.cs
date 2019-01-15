using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Esta clase es para consultar las personas tanto naturales como  jurídicas
    /// </summary>
    public class PersonaConsulta: BaseEntidades
    {       
        public Int64 ID_PERSONA { get; set; }      
        public Int64 ID_TIPO_PERSONA { get; set; }       
        public Int64 ID_TIPO_DOCUMENTO { get; set; }      
        public string NUMERO_DOCUMENTO { get; set; }
        public string NOMBRE_TIPO_PERSONA { get; set; }
        public string NOMBRE_TIPO_DOCUMENTO { get; set; }
        public string LISTA_CLINTON { get; set; }
        public string CODIGO_TIPO_PERSONA { get; set; }
        /// <summary>
        /// Si es natural es el nombre completo de la persona, si es jurídica es la razón social
        /// </summary>
        public string NOMBRE { get; set; }

    }
}
