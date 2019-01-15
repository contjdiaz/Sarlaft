using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PersonaJuridica : BaseEntidades
    {
        [Display(Name = "Id")]
        public Int64 ID_JURIDICA { get; set; }

        [Display(Name = "Id Persona")]
        public Int64 ID_PERSONA { get; set; }

        [Display(Name = "Id Tipo Empresa")]
        public Int64 ID_TIPO_EMPRESA { get; set; }

        [Display(Name = "Razon Social")]
        public string RAZON_SOCIAL { get; set; }

        [Display(Name = "Codigo CIU")]
        public Int64 ID_CODIGO_CIIU { get; set; }

        [Display(Name = "Dirección")]
        public string DIRECCION { get; set; }

        [Display(Name = "Municipio")]
        public Int64 ID_MUNICIPIO { get; set; }

        [Display(Name = "Teléfono")]
        public string TELEFONO { get; set; }

        [Display(Name = "Extensión")]
        public string EXTENSION { get; set; }

        [Display(Name = "Fax")]
        public string FAX { get; set; }

        [Display(Name = "Correo electrónico")]
        public string CORREO { get; set; }

        [Display(Name = "Dirección sucursal")]
        public string DIR_SUCURSAL { get; set; }

        [Display(Name = "Municipio Sucursal")]
        public Int64? ID_MCPO_SUCURSAL { get; set; }

        [Display(Name = "Teléfono sucursal")]
        public string TEL_SUCURSAL { get; set; }

        [Display(Name = "Extensión sucursal")]
        public string EXT_SUCURSAL { get; set; }

        [Display(Name = "Fax sucursal")]
        public string FAX_SUCURSAL { get; set; }

        [Display(Name = "Correo electrónico sucursal")]
        public string CORREO_SUCURSAL { get; set; }

        [Display(Name = "Representante legal")]
        public Int64 ID_REP_LEGAL { get; set; }
    }
}
