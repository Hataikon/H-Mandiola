using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Web.Http;
using System.Data;
using H_Mandiola_Backend.Clases;

namespace H_Mandiola_Backend
{
    public class PreciosController : ApiController
    {
        BLL_precios objPrecios = new BLL_precios();

        [Route("~/api/Precios")]
        [HttpGet]
        public IEnumerable<Precios> GetAll()
        {
            DataSet ds = objPrecios.carga_lista_precios();
            DataTable dt = ds.Tables[0];

            var retList = new List<Precios>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Precios()
                {
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Tipo = Convert.ToString(row["TIPO"]),
                    Precio = Convert.ToString(row["PRECIO"])

                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Precios/BuscarPrecio")]
        [HttpGet]
        public Precios BuscarActivos(string codigo)
        {
            DataSet ds = objPrecios.carga_lista_precios();
            DataTable dt = ds.Tables[0];

            var retList = new List<Precios>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Precios()
                {
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Tipo = Convert.ToString(row["TIPO"]),
                    Precio = Convert.ToString(row["PRECIO"])

                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Codigo_Consecutivo == codigo);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }

        // POST api/<controller>
        [Route("~/api/Precios/AgregarPrecio")]
        [HttpPost]
        public IHttpActionResult AgregarActivo([FromBody]Precios value)
        {
            objPrecios.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objPrecios.prefijo = value.Prefijo.ToString();
            objPrecios.tipo = value.Tipo.ToString();
            objPrecios.precio = value.Precio.ToString();
            if (objPrecios.agregar_precio())
            {
                return Json(new { msg = "Successfully added " + value.Prefijo.ToString() });
            }
            else
            {
                return Json(new { msg = "Error " + value.Prefijo.ToString() });
            }
        }

        [Route("~/api/Precios/ModificarPrecio")]
        [HttpPost]
        public IHttpActionResult ModificarActivo([FromBody]Precios value)
        {
            objPrecios.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objPrecios.tipo = value.Tipo.ToString();
            objPrecios.precio = value.Precio.ToString();
            if (objPrecios.modificar_precio())
            {
                return Json(new { msg = "Successfully added " });
            }
            else
            {
                return Json(new { msg = "Error" });
            }
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