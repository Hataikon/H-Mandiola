using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using System.Web.Http.Cors;
using H_Mandiola_Backend.Clases;

namespace H_Mandiola_Backend
{
    public class ClienteController : ApiController
    {
        BLL_cliente objCliente = new BLL_cliente();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("~/api/Cliente/AgregarCliente")]
        [HttpPost]
        public IHttpActionResult AgregarCliente([FromBody]Cliente value)
        {
            objCliente.nombre_usuario = value.Username.ToString();
            objCliente.contrasena = value.Password.ToString();
            objCliente.email = value.Email.ToString();
            objCliente.nombre = value.Nombre.ToString();
            objCliente.primer_apellido = value.Primer_Apellido.ToString();
            objCliente.segundo_apellido = value.Segundo_Apellido.ToString();
            objCliente.agregar_cliente();
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully added " + value.Username.ToString() }); ;
        }

        [Route("~/api/Cliente/BuscarCliente")]
        [HttpGet]
        public Cliente BuscarCliente(string username, string password)
        {
            DataSet ds = objCliente.carga_lista_clientes();
            DataTable dt = ds.Tables[0];

            var retList = new List<Cliente>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Cliente()
                {
                    Username = Convert.ToString(row["NOMBRE_USUARIO"]).Trim(),
                    Password = Convert.ToString(row["PASSWORD"]),
                    Email = Convert.ToString(row["EMAIL"]),
                    Nombre = Convert.ToString(row["NOMBRE"]),
                    Primer_Apellido = Convert.ToString(row["PRIMER_APELLIDO"]),
                    Segundo_Apellido = Convert.ToString(row["SEGUNDO_APELLIDO"])
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

        [Route("~/api/Cliente/BuscarCliente2")]
        [HttpGet]
        public Cliente BuscarUsuario(string username)
        {
            DataSet ds = objCliente.carga_lista_clientes();
            DataTable dt = ds.Tables[0];

            var retList = new List<Cliente>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Cliente()
                {
                    Username = Convert.ToString(row["NOMBRE_USUARIO"]).Trim(),
                    Password = Convert.ToString(row["PASSWORD"]),
                    Email = Convert.ToString(row["EMAIL"]),
                    Nombre = Convert.ToString(row["NOMBRE"]),
                    Primer_Apellido = Convert.ToString(row["PRIMER_APELLIDO"]),
                    Segundo_Apellido = Convert.ToString(row["SEGUNDO_APELLIDO"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Username == username);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("~/api/Cliente/CambiarContraseña")]
        [HttpPost]
        public IHttpActionResult CambiarContraseña([FromBody]Cliente value)
        {
            objCliente.nombre_usuario = value.Username.ToString();
            objCliente.contrasena = value.Password.ToString();
            if (objCliente.cambiar_contraseña())
            {
                return Json(new { msg = "Successfully changed password for user: " + value.Username.ToString() });
            }
            else
            {
                return Json(new { msg = "Error storing  " + value.Username.ToString() });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

        }

        [Route("~/api/Cliente")]
        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            DataSet ds = objCliente.carga_lista_clientes();
            DataTable dt = ds.Tables[0];

            var retList = new List<Cliente>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Cliente()
                {
                    Username = Convert.ToString(row["NOMBRE_USUARIO"]).Trim(),
                    Password = Convert.ToString(row["PASSWORD"]),
                    Email = Convert.ToString(row["EMAIL"]),
                    Nombre = Convert.ToString(row["NOMBRE"]),
                    Primer_Apellido = Convert.ToString(row["PRIMER_APELLIDO"]),
                    Segundo_Apellido = Convert.ToString(row["SEGUNDO_APELLIDO"])
                };

                retList.Add(temp);
            }

            return retList;
        }
    }
}