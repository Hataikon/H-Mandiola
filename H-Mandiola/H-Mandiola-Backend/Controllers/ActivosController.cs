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
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Nombre = Convert.ToString(row["NOMBRE"])
                    
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Activos/BuscarActivos")]
        [HttpGet]
        public Activos BuscarActivos(string prefijo)
        {
            DataSet ds = objActivos.carga_lista_activos();
            DataTable dt = ds.Tables[0];

            var retList = new List<Activos>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Activos()
                {
                    Prefijo = Convert.ToString(row["PREFIJO"]).Trim(),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Nombre = Convert.ToString(row["NOMBRE"])
                    
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
        [Route("~/api/Activos/AgregarActivo")]
        [HttpPost]
        public IHttpActionResult AgregarActivo([FromBody]Activos value)
        {
            objActivos.prefijo = value.Prefijo.ToString();
            objActivos.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objActivos.descripcion = value.Descripcion.ToString();
            objActivos.nombre = value.Nombre.ToString();
            objActivos.agregar_activos();
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully added " + value.Prefijo.ToString() }); ;
        }

        [Route("~/api/Activos/ModificarActivo")]
        [HttpPost]
        public IHttpActionResult ModificarActivo([FromBody]Activos value)
        {
            objActivos.prefijo = value.Prefijo.ToString();
            objActivos.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objActivos.descripcion = value.Descripcion.ToString();
            objActivos.nombre = value.Nombre.ToString();
            objActivos.modificar_activo();
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully modified " + value.Prefijo.ToString() + "Su activo es " + value.Nombre }); ;
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