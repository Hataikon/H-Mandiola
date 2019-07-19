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
    public class ActivosController : ApiController
    {
        BLL_activos objActivos = new BLL_activos();

        [Route("~/api/Activos")]
        [HttpGet]
        public IEnumerable<Activos> GetAll()
        {
            DataSet ds = objActivos.carga_lista_activos();
            DataTable dt = ds.Tables[0];

            var retList = new List<Activos>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Activos()
                {
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Nombre = Convert.ToString(row["NOMBRE"]),
                    Descripcion = Convert.ToString(row["DESCRIPCION_CONSECUTIVO"])

                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Activos/BuscarActivo")]
        [HttpGet]
        public Activos BuscarActivos(string codigo)
        {
            DataSet ds = objActivos.carga_lista_activos();
            DataTable dt = ds.Tables[0];

            var retList = new List<Activos>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Activos()
                {
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Nombre = Convert.ToString(row["NOMBRE"]),
                    Descripcion = Convert.ToString(row["DESCRIPCION_CONSECUTIVO"])

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
        [Route("~/api/Activos/AgregarActivo")]
        [HttpPost]
        public IHttpActionResult AgregarActivo([FromBody]Activos value)
        {
            objActivos.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objActivos.prefijo = value.Prefijo.ToString();
            objActivos.nombre = value.Nombre.ToString();
            objActivos.descripcion = value.Descripcion.ToString();
            if (objActivos.agregar_activo())
            {
                return Json(new { msg = "Successfully added " + value.Prefijo.ToString() });
            }
            else
            {
                return Json(new { msg = "Error " + value.Prefijo.ToString() });
            }
        }

        [Route("~/api/Activos/ModificarActivo")]
        [HttpPost]
        public IHttpActionResult ModificarActivo([FromBody]Activos value)
        {
            objActivos.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objActivos.nombre = value.Nombre.ToString();
            objActivos.descripcion = value.Descripcion.ToString();
            if (objActivos.modificar_activo())
            {
                return Json(new { msg = "Successfully added "});
            }
            else
            {
                return Json(new { msg = "Error"});
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