using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Web.Mvc;

namespace WebBackend.Models
{
    public class ConsultaPersonaViewModel
    {
        public List<PersonaConsulta> ListaPersonas { get; set; }
        public string CODIGO_TIPO_PERSONA { get; set; }
        public string CODIGO_TIPO_DOCUMENTO { get; set; }
        public Int64 ID_TIPO_PERSONA { get; set; }
        public Int64 ID_TIPO_DOCUMENTO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public SelectList ListaTipoDocumento { get; set; }
    }
}