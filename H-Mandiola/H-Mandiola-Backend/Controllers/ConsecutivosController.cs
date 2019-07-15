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
    public class ConsecutivosController : ApiController
    {
        BLL_consecutivo objConsecutivos = new BLL_consecutivo();

        [Route("~/api/Consecutivos")]
        [HttpGet]
        public IEnumerable<Consecutivos> GetAll()
        {
            DataSet ds = objConsecutivos.carga_lista_consecutivos();
            DataTable dt = ds.Tables[0];

            var retList = new List<Consecutivos>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Consecutivos()
                {
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Rango_Inicial = Convert.ToInt32(row["RANGO_INICIAL"]),
                    Rango_Final = Convert.ToInt32(row["RANGO_FINAL"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Consecutivos/BuscarConsecutivo")]
        [HttpGet]
        public Consecutivos BuscarConsecutivo(string prefijo)
        {
            DataSet ds = objConsecutivos.carga_lista_consecutivos();
            DataTable dt = ds.Tables[0];

            var retList = new List<Consecutivos>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Consecutivos()
                {
                    Prefijo = Convert.ToString(row["PREFIJO"]).Trim(),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Rango_Inicial = Convert.ToInt32(row["RANGO_INICIAL"]),
                    Rango_Final = Convert.ToInt32(row["RANGO_FINAL"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Prefijo == prefijo);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }

        // POST api/<controller>
        [Route("~/api/Consecutivos/AgregarConsecutivo")]
        [HttpPost]
        public IHttpActionResult AgregarConsecutivo([FromBody]Consecutivos value)
        {
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully added " + value.Prefijo.ToString() }); ;
        }

        [Route("~/api/Consecutivos/ModificarConsecutivo")]
        [HttpPost]
        public IHttpActionResult ModificarConsecutivo([FromBody]Consecutivos value)
        {
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully modified " + value.Prefijo.ToString() }); ;
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