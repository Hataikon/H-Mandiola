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
    public class ErrorController : ApiController
    {
        BLL_error objError = new BLL_error();

        [Route("~/api/Error")]
        [HttpGet]
        public IEnumerable<Errores> GetAll()
        {
            DataSet ds = objError.carga_lista_error();
            DataTable dt = ds.Tables[0];

            var retList = new List<Errores>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Errores()
                {
                    Numero_Error = Convert.ToString(row["NUMERO_ERROR"]),
                    Fecha_Error = Convert.ToString(row["FECHA_HORA_ERROR"]),
                    Mensaje_Error = Convert.ToString(row["MENSAJE_ERROR"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Error/AgregarError")]
        [HttpPost]
        public IHttpActionResult AgregarConsecutivo([FromBody]Errores value)
        {
            objError.numero_error_error = value.Numero_Error.ToString();
            objError.fecha_hora_error = value.Fecha_Error.ToString();
            objError.mensaje_error_error = value.Mensaje_Error.ToString();
            if (objError.agregar_error())
            {
                return Json(new { msg = "Record Agregado a la bitacora " });
            }
            else
            {
                return Json(new { msg = "Error al agregar records a la bitacora" });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

        }
    }
}