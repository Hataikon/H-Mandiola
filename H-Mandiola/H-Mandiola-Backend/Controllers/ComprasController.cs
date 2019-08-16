using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using H_Mandiola_Backend.Clases;
using System.Data;

namespace H_Mandiola_Backend.Controllers
{
    public class ComprasController : ApiController
    {
        BLL_compras objCompras = new BLL_compras();

        [Route("~/api/Compras")]
        [HttpGet]
        public IEnumerable<Compras> GetAll()
        {
            DataSet ds = objCompras.carga_lista_compras();
            DataTable dt = ds.Tables[0];

            var retList = new List<Compras>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Compras()
                {
                    Cliente = Convert.ToString(row["Cliente"]),
                    Estado = Convert.ToString(row["ESTADO"]),
                    Codigo_De_Activo = Convert.ToString(row["CODIGO_DE_ACTIVO"]),
                    Codigo_De_Precio = Convert.ToString(row["CODIGO_DE_PRECIO"]),
                    Cantidad = Convert.ToString(row["CANTIDAD"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Compras/BuscarCompras")]
        [HttpGet]
        public Compras BuscarCompras(string cliente)
        {
            DataSet ds = objCompras.carga_lista_compras();
            DataTable dt = ds.Tables[0];

            var retList = new List<Compras>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Compras()
                {
                    Cliente = Convert.ToString(row["Cliente"]).Trim(),
                    Estado = Convert.ToString(row["ESTADO"]),
                    Codigo_De_Activo = Convert.ToString(row["CODIGO_DE_ACTIVO"]),
                    Codigo_De_Precio = Convert.ToString(row["CODIGO_DE_PRECIO"]),
                    Cantidad = Convert.ToString(row["CANTIDAD"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Cliente == cliente);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }

        // POST api/<controller>
        [Route("~/api/Compras/AgregarCompra")]
        [HttpPost]
        public IHttpActionResult AgregarCompra([FromBody]Compras value)
        {
            objCompras.cliente = value.Cliente.ToString();
            objCompras.estado = value.Estado.ToString();
            objCompras.codigo_de_activo = value.Codigo_De_Activo.ToString();
            objCompras.codigo_de_precio = value.Codigo_De_Precio.ToString();
            objCompras.cantidad = value.Cantidad.ToString();
            if (objCompras.agregar_compra())
            {
                return Json(new { msg = "Successfully added " + value.Cliente.ToString() });
            }
            else
            {
                return Json(new { msg = "Error " + value.Cliente.ToString() });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

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
