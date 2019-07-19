using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H_Mandiola_Backend
{
    public class Bitacora
    {
        public string Codigo_Registro { get; set; }
        public string Usuario { get; set; }
        public string Fecha_Hora { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
    }
}