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
        // GET api/<controller>
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
                    CODIGO_CONSECUTIVO = Convert.ToString(row["CODIGO_CONSECUTIVO"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        // GET api/<controller>/5
        public Consecutivos Get(string prefijo)
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
                    CODIGO_CONSECUTIVO = Convert.ToString(row["CODIGO_CONSECUTIVO"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Prefijo == prefijo);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return result;
        }

        // POST api/<controller>
        [Route("~/api/VerJSON")]
        [HttpPost]
        public String Post([FromBody]Consecutivos value)
        {
            String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return res;
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