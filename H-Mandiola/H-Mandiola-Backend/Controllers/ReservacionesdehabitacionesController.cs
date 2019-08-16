using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using H_Mandiola_Backend.Clases;
using System.Data;

namespace H_Mandiola_Backend.Controllers
{
    public class ReservacionesdehabitacionesController : ApiController
    {
        BLL_reservacionesdehabitaciones objReservacionesDeHabitaciones = new BLL_reservacionesdehabitaciones();

        [Route("~/api/ReservacionesDeHabitaciones")]
        [HttpGet]
        public IEnumerable<ReservacionesDeHabitaciones> GetAll()
        {
            DataSet ds = objReservacionesDeHabitaciones.carga_lista_reservacion();
            DataTable dt = ds.Tables[0];

            var retList = new List<ReservacionesDeHabitaciones>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new ReservacionesDeHabitaciones()
                {
                    Booking_ID = Convert.ToString(row["BOOKING_ID"]),
                    Numero_De_Reservacion = Convert.ToString(row["NUMERO_DE_RESERVACION"]),
                    Cliente = Convert.ToString(row["Cliente"]),
                    Itinerario = Convert.ToString(row["ITINERARIO"]),
                    Codigo_De_Habitacion = Convert.ToString(row["CODIGO_DE_HABITACION"]),
                    Codigo_De_Precio= Convert.ToString(row["CODIGO_DE_PRECIOL"]),
                    Cantidad_De_Personas = Convert.ToString(row["CANTIDAD_DE_PERSONAS"]),
                    Cantidad_De_Dias = Convert.ToString(row["CANTIDAD_DE_DIAS"]),
                    Cantidad_De_Habitaciones = Convert.ToString(row["CANTIDAD_DE_HABITACIONES"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/ReservacionesDeHabitaciones/BuscarReservacion")]
        [HttpGet]
        public ReservacionesDeHabitaciones BuscarReservacion(string codido_de_precio)
        {
            DataSet ds = objReservacionesDeHabitaciones.carga_lista_reservacion();
            DataTable dt = ds.Tables[0];

            var retList = new List<ReservacionesDeHabitaciones>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new ReservacionesDeHabitaciones()
                {
                    Booking_ID = Convert.ToString(row["BOOKING_ID"]).Trim(),
                    Numero_De_Reservacion = Convert.ToString(row["NUMERO_DE_RESERVACION"]),
                    Cliente = Convert.ToString(row["Cliente"]),
                    Itinerario = Convert.ToString(row["ITINERARIO"]),
                    Codigo_De_Habitacion = Convert.ToString(row["CODIGO_DE_HABITACION"]),
                    Codigo_De_Precio = Convert.ToString(row["CODIGO_DE_PRECIOL"]),
                    Cantidad_De_Personas = Convert.ToString(row["CANTIDAD_DE_PERSONAS"]),
                    Cantidad_De_Dias = Convert.ToString(row["CANTIDAD_DE_DIAS"]),
                    Cantidad_De_Habitaciones = Convert.ToString(row["CANTIDAD_DE_HABITACIONES"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Codigo_De_Precio == codido_de_precio);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }

        // POST api/<controller>
        [Route("~/api/ReservacionesDeHabitaciones/AgregarReservacion")]
        [HttpPost]
        public IHttpActionResult AgregarReservacion([FromBody]ReservacionesDeHabitaciones value)
        {
            objReservacionesDeHabitaciones.booking_id = value.Booking_ID.ToString();
            objReservacionesDeHabitaciones.numero_de_reservacion = value.Numero_De_Reservacion.ToString();
            objReservacionesDeHabitaciones.cliente = value.Cliente.ToString();
            objReservacionesDeHabitaciones.itinerario = value.Itinerario.ToString();
            objReservacionesDeHabitaciones.codigo_de_habitacion = value.Codigo_De_Habitacion.ToString();
            objReservacionesDeHabitaciones.codigo_de_precio = value.Codigo_De_Precio.ToString();
            objReservacionesDeHabitaciones.cantidad_de_personas = value.Cantidad_De_Personas.ToString();
            objReservacionesDeHabitaciones.cantidad_de_dias = value.Cantidad_De_Dias.ToString();
            objReservacionesDeHabitaciones.cantidad_de_habitaciones = value.Cantidad_De_Habitaciones.ToString();

            if (objReservacionesDeHabitaciones.agregar_reservacion())
            {
                return Json(new { msg = "Successfully added " + value.Codigo_De_Precio.ToString() });
            }
            else
            {
                return Json(new { msg = "Error " + value.Codigo_De_Precio.ToString() });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

        }

        

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
