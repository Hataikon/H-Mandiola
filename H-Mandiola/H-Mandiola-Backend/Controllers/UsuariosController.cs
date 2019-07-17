using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace H_Mandiola_Backend.Controllers
{
    public class UsuariosController : ApiController
    {
        BLL_usuario objUsuario = new BLL_usuario();

        [Route("~/api/Usuarios/AgregarUsuario")]
        [HttpPost]
        public IHttpActionResult AgregarConsecutivo([FromBody]Usuarios value)
        {
            objUsuario.nombre_usuario = value.Username.ToString();
            objUsuario.password = value.Password.ToString();
            objUsuario.email = value.Email.ToString();
            objUsuario.pregunta = value.Pregunta.ToString();
            objUsuario.respuesta = value.Respuesta.ToString();
            objUsuario.agregar_usuario();
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully added " + value.Username.ToString() }); ;
        }
    }
}
