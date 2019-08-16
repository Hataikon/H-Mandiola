using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H_Mandiola_Backend.Clases
{
    public class ReservacionesDeHabitaciones
    {
        public string Booking_ID { get; set; }
        public string Numero_De_Reservacion { get; set; }
        public string Cliente { get; set; }
        public string Itinerario { get; set; }
        public string Codigo_De_Habitacion { get; set; }
        public string Codigo_De_Precio { get; set; }
        public string Cantidad_De_Personas { get; set; }
        public string Cantidad_De_Dias { get; set; }
        public string Cantidad_De_Habitaciones { get; set; }


    }
}