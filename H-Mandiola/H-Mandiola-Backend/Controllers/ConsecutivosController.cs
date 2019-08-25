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
                    Rango_Inicial = Convert.ToString(row["RANGO_INICIAL"]),
                    Rango_Final = Convert.ToString(row["RANGO_FINAL"])
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
                    Rango_Inicial = Convert.ToString(row["RANGO_INICIAL"]),
                    Rango_Final = Convert.ToString(row["RANGO_FINAL"])
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
            objConsecutivos.prefijo = value.Prefijo.ToString();
            objConsecutivos.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objConsecutivos.descripcion = value.Descripcion.ToString();
            objConsecutivos.rango_inicial = value.Rango_Inicial.ToString(); 
            objConsecutivos.rango_final = value.Rango_Final.ToString();
            if (objConsecutivos.agregar_consecutivo())
            {
                return Json(new { msg = "Successfully added " + value.Prefijo.ToString() });
            }
            else
            {
                return Json(new { msg = "Error " + value.Prefijo.ToString() });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

        }

        [Route("~/api/Consecutivos/ModificarConsecutivo")]
        [HttpPost]
        public IHttpActionResult ModificarConsecutivo([FromBody]Consecutivos value)
        {
            objConsecutivos.prefijo = value.Prefijo.ToString();
            objConsecutivos.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objConsecutivos.descripcion = value.Descripcion.ToString();
            objConsecutivos.rango_inicial = value.Rango_Inicial.ToString();
            objConsecutivos.rango_final = value.Rango_Final.ToString();
            if (objConsecutivos.modificar_consecutivo())
            {
                return Json(new { msg = "0" });
            }
            else
            {
                return Json(new { msg = "1", numero_error = objConsecutivos.num_error, mensaje_error = objConsecutivos.mensaje });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            
        }


        [Route("~/api/Consecutivos/MaxConsecutivo")]
        [HttpGet]
        public Consecutivos MaxConsecutivo()
        {
            objConsecutivos.maximo_consecutivo();

            Consecutivos result =  new Consecutivos();

            result.Row_Num = objConsecutivos.prefijo;

            return result;
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