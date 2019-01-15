using Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBackend.Models
{
    public class PersonaJuridicaViewModel: BaseEntidades
    {
        #region  Persona
        [Key]
        [Display(Name = "Id")]
        public Int64 ID_PERSONA { get; set; }

        [Display(Name = "Tipo persona")]
        public Int64 ID_TIPO_PERSONA { get; set; }

        [Display(Name = "Tipo documento")]
        [Required(ErrorMessage = "Tipo documento requerido")]
        public Int64 ID_TIPO_DOCUMENTO { get; set; }

        public string TIPO_DOCUMENTO { get; set; }

        [Display(Name = "Número de documento")]
        [Required(ErrorMessage = "Documento requerido")]
        [StringLength(20)]
        public string NUMERO_DOCUMENTO { get; set; }

        [Required(ErrorMessage = "Departamento requerido")]
        public Int64 ID_DEPARTMENTO { get; set; }

        public SelectList ListaMunicipio { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "Municipio requerido")]

        public string ID_MUNICIPIO { get; set; }
        #endregion


        #region PersonaJuridica
        [Display(Name = "Id")]
        public Int64 ID_JURIDICA { get; set; }

        [Display(Name = "Id Tipo Empresa")]
        [Required(ErrorMessage = "Tipo empresa requerido")]
        public Int64 ID_TIPO_EMPRESA { get; set; }

        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "Razón social requerido")]
        public string RAZON_SOCIAL { get; set; }

        [Required(ErrorMessage = "Actividad económica requerida")]
        public Int64 ID_ACT_ECONOMICA { get; set; }

        [Display(Name = "Codigo CIU")]
        [Required(ErrorMessage = "Código CIUU requerido")]
        public Int64 ID_CODIGO_CIIU { get; set; }

        public SelectList ListaoCodigoCiiu { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Dirección requerido")]
        public string DIRECCION { get; set; }

        [Required(ErrorMessage = "Departamento requerido")]
        public Int64 ID_DEPTO_JURIDICA { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "Municipio requerido")]
        public Int64 ID_MUNICIPIO_JURIDICA { get; set; }

        public SelectList ListaMunicipioJuridica { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Teléfono requerido")]
        [StringLength(7, ErrorMessage = "La longitud del teléfono debe ser de 7 caracteres", MinimumLength = 7)]
        public string TELEFONO { get; set; }

        [Display(Name = "Extensión")]
        [StringLength(5, ErrorMessage = "La longitud de la extensión debe ser mínimo de 3 caracteres y máximo de 5", MinimumLength = 3)]
        public string EXTENSION { get; set; }

        [Display(Name = "Fax")]
        [StringLength(7, ErrorMessage = "La longitud del fax debe ser de 7 caracteres", MinimumLength = 7)]
        public string FAX { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string CORREO { get; set; }

        [Display(Name = "Dirección sucursal")]
        public string DIR_SUCURSAL { get; set; }

        public string ID_DEPTO_SUCURSAL { get; set; }

        [Display(Name = "Municipio Sucursal")]
        public string ID_MCPO_SUCURSAL { get; set; }

        public SelectList ListaMunicipioSucursal { get; set; }

        [Display(Name = "Teléfono sucursal")]
        [StringLength(7, ErrorMessage = "La longitud del teléfono de la sucursal debe ser de 7 caracteres", MinimumLength = 7)]
        public string TEL_SUCURSAL { get; set; }

        [Display(Name = "Extensión sucursal")]
        [StringLength(5, ErrorMessage = "La longitud de la extensión de la sucursal debe ser mínimo de 3 caracteres y máximo de 5", MinimumLength = 3)]
        public string EXT_SUCURSAL { get; set; }

        [Display(Name = "Fax sucursal")]
        [StringLength(7, ErrorMessage = "La longitud del fax de la sucursal debe ser de 7 caracteres", MinimumLength = 7)]
        public string FAX_SUCURSAL { get; set; }

        [Display(Name = "Correo electrónico sucursal")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string CORREO_SUCURSAL { get; set; }

        [Display(Name = "Representante legal")]
        public Int64 ID_REP_LEGAL { get; set; }
        #endregion
    }
}