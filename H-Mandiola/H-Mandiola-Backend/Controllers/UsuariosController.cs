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

        [Route("~/api/Usuarios/BuscarUsuario")]
        [HttpGet]
        public Usuarios BuscarUsuario(string username, string password)
        {
            DataSet ds = objUsuario.carga_lista_usuarios();
            DataTable dt = ds.Tables[0];

            var retList = new List<Usuarios>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Usuarios()
                {
                    Username = Convert.ToString(row["NOMBRE_USUARIO"]).Trim(),
                    Password = Convert.ToString(row["PASSWORD"]),
                    Email = Convert.ToString(row["EMAIL"]),
                    Pregunta = Convert.ToString(row["PREGUNTA"]),
                    Respuesta = Convert.ToString(row["RESPUESTA"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Username == username && p.Password == password);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }
    }
}
