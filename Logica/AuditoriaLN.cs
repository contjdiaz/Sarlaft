using Componentes;
using Datos;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{

    public class AuditoriaLN
    {
        AuditoriaAD auditoriaDatos = new AuditoriaAD();
        Auditoria auditoria;
               

        public void ObjetoAuditoriaInsertar(object objeto)
        {
            auditoria = new Auditoria();
            auditoria.REGISTRO_ORIGINAL = JsonConvert.SerializeObject(objeto);
            auditoria.ID_TIPO_REGISTRO = Convert.ToInt64(Enums.TipoRegistroAuditoria.Insertar);
            auditoria.REGISTRO_MODIFICADO = "NUEVO REGISTRO";
            auditoria.FECHA = DateTime.Now;
            auditoriaDatos.AuditoriaInsertar(auditoria);
        }


        public void ObjetoAuditoriaEditar(object modificado, object original)
        {
            auditoria = new Auditoria();
            auditoria.REGISTRO_ORIGINAL = JsonConvert.SerializeObject(original);
            auditoria.ID_TIPO_REGISTRO = Convert.ToInt64(Enums.TipoRegistroAuditoria.Modificar);
            auditoria.REGISTRO_MODIFICADO = JsonConvert.SerializeObject(modificado);
            auditoria.FECHA = DateTime.Now;
            auditoriaDatos.AuditoriaInsertar(auditoria);
        }

        public void ObjetoAuditoriaEliminar(object objeto)
        {
            auditoria = new Auditoria();
            auditoria.REGISTRO_ORIGINAL = JsonConvert.SerializeObject(objeto);
            auditoria.ID_TIPO_REGISTRO = Convert.ToInt64(Enums.TipoRegistroAuditoria.Eliminar);
            auditoria.REGISTRO_MODIFICADO = "ELIMINAR";
            auditoria.FECHA = DateTime.Now;
            auditoriaDatos.AuditoriaInsertar(auditoria);
        }
    }
}
