using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace H_Mandiola_Backend
{
    public class HabitacionesController : ApiController
    {
        BLL_habitaciones objHabitaciones = new BLL_habitaciones();

        [Route("~/api/Habitaciones")]
        [HttpGet]
        public IEnumerable<Habitaciones> GetAll()
        {
            DataSet ds = objHabitaciones.carga_lista_habitaciones();
            DataTable dt = ds.Tables[0];

            var retList = new List<Habitaciones>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Habitaciones()
                {
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Numero = Convert.ToString(row["NUMERO"]),
                    Descripcion = Convert.ToString(row["DESCRIPCION CONSECUTIVO"]),
                    Imagen = Convert.ToString(row["IMAGEN_HABITACION"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Habitaciones/AgregarHabitacion")]
        [HttpPost]
        public IHttpActionResult AgregarHabitacion([FromBody]Habitaciones value)
        {
            objHabitaciones.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objHabitaciones.prefijo = value.Prefijo.ToString();
            objHabitaciones.numero = value.Numero.ToString();
            objHabitaciones.descripcion = value.Descripcion.ToString();
            objHabitaciones.imagen_habitacion = value.Imagen.ToString();
            if (objHabitaciones.agregar_habitacion())
            {
                return Json(new { msg = "Successfully added " + value.Prefijo.ToString() });
            }
            else
            {
                return Json(new { msg = "Error " + value.Prefijo.ToString() });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

        }
    }

}