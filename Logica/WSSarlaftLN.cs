using System;
using System.Collections.Generic;
using Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class WSSarlaftLN
    {
        WSSarlaftAD Datos = new WSSarlaftAD();
        ParametroAD parametroAD = new ParametroAD();
        public WSSarlaft InsertarRespuesta(WSSarlaft Request)
        {
            return Datos.InsertarRespuesta(Request);
        }

        public string ConsultarListaClinton(string NroDocumento, string Division)
        {
            try
            {
                var cod_emp = parametroAD.ParametroPorCodigoConsultar("cod_emp").DESCRIPCION_PARAMETRO;
                var usuario = parametroAD.ParametroPorCodigoConsultar("usuario").DESCRIPCION_PARAMETRO; 
                var password = parametroAD.ParametroPorCodigoConsultar("password").DESCRIPCION_PARAMETRO;

                RWListaClinton.DatosWsDue data = new RWListaClinton.DatosWsDue();
                data.cod_emp = cod_emp;
                data.usuario = usuario;
                data.password = password;
                //data.nombres = nombres;
                //data.apellidos = apellidos;
                data.division = Division;
                data.identificacion = NroDocumento;

                RWListaClinton.addressbook1 servicio = new RWListaClinton.addressbook1();


                var respuesta = servicio.getDatosWsDue(data);
                WSSarlaft msarlaft = new WSSarlaft();

                msarlaft.LISTA_CLINTON = respuesta.lista_clinton.ToString();
                msarlaft.OTROS_ORGANISMOS = respuesta.otros_organismos.ToString();
                msarlaft.LINK_R = respuesta.link.ToString();
                msarlaft.DETALLE_OTROS = respuesta.detalle_otros.ToString();
                msarlaft.DETALLE_US = respuesta.detalle_us.ToString();
                msarlaft.IDENTIFICACION = data.identificacion;
                msarlaft.FECHA_CONSULTA = DateTime.Now;
                var idresp = InsertarRespuesta(msarlaft);
                var r = "RESPUESTA ALMACENADA!!: -- Lista Clinton: " + respuesta.lista_clinton.ToString() + " <br /> Otros Organismos: " + respuesta.otros_organismos.ToString() + " <br /> Link: " + respuesta.link.ToString() + " <br /> Detalle_otros: " + respuesta.detalle_otros.ToString() + " <br /> Detalle_us: " + respuesta.detalle_us.ToString() + " <br /> Respuesta Web Service";
                return r;
            }
            catch (Exception)
            {
                var r = "ERROR EN CONSULTA WEB SERVICE";
                return r;
                throw;
            }




        }
    }
}
