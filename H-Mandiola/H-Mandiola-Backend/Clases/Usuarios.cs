using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H_Mandiola_Backend
{
    public class Usuarios
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public string isAdmin { get; set; }
        public string isSeguridad { get; set; }
        public string isConsecutivo { get; set; }
        public string isMantenimiento { get; set; }
        public string isConsulta { get; set; }
    }
}