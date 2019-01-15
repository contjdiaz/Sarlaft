using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BaseEntidades
    {
        //Mensajes hacia el usuario que indican su importancia por el color muy parecido a un semaforo
        public string mensajeNotificacion { get; set; } //Mensaje hacia la capa de presentación
        public int tipoMensaje { get; set; } //1 = Verde (Mensaje de confirmación a transacción)   ; 2=Amarillo (Mensaje de advertencia) ; 3: Rojo(Mendaje de error)

        //Información hacia el log de la base de datos
        public string accionUsuario { get; set; } //Usuario que efectua la acción
        public DateTime accionActividad { get; set; } //Actividad que ejecuto la acción
        public string accionFecha { get; set; } //Fecha de la acción
        
        //Información de la transacción
        public int FilasAfectadas { get; set; }
    }
}
