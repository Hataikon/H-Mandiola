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
    public class ActividadesController : ApiController
    {
        BLL_actividades objActividades = new BLL_actividades();

        [Route("~/api/Actividades")]
        [HttpGet]
        public IEnumerable<Actividades> GetAll()
        {
            DataSet ds = objActividades.carga_lista_actividades();
            DataTable dt = ds.Tables[0];

            var retList = new List<Actividades>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Actividades()
                {
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Nombre = Convert.ToString(row["NOMBRE"]),
                    Descripcion = Convert.ToString(row["DESCRIPCION_CONSECUTIVO"]),
                    Imagen = Convert.ToString(row["IMAGEN_ACTIVIDAD"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Actividades/BuscarActividad")]
        [HttpGet]
        public Actividades BuscarConsecutivo(string codigo)
        {
            DataSet ds = objActividades.carga_lista_actividades();
            DataTable dt = ds.Tables[0];

            var retList = new List<Actividades>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Actividades()
                {
                    Codigo_Consecutivo = Convert.ToString(row["CODIGO_CONSECUTIVO"]),
                    Prefijo = Convert.ToString(row["PREFIJO"]),
                    Nombre = Convert.ToString(row["NOMBRE"]),
                    Descripcion = Convert.ToString(row["DESCRIPCION_CONSECUTIVO"]),
                    Imagen = Convert.ToString(row["IMAGEN_ACTIVIDAD"])
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

        [Route("~/api/Actividades/AgregarActividad")]
        [HttpPost]
        public IHttpActionResult AgregarHabitacion([FromBody]Actividades value)
        {
            objActividades.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objActividades.prefijo = value.Prefijo.ToString();
            objActividades.nombre = value.Nombre.ToString();
            objActividades.descripcion = value.Descripcion.ToString();
            objActividades.imagen_actividad = value.Imagen.ToString();
            if (objActividades.agregar_actividad())
            {
                return Json(new { msg = "Successfully added " + value.Prefijo.ToString() });
            }
            else
            {
                return Json(new { msg = "Error " + value.Prefijo.ToString() });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

        }

        [Route("~/api/Actividades/ModificarActividad")]
        [HttpPost]
        public IHttpActionResult ModificarConsecutivo([FromBody]Actividades value)
        {
            objActividades.codigo_consecutivo = value.Codigo_Consecutivo.ToString();
            objActividades.nombre = value.Nombre.ToString();
            objActividades.descripcion = value.Descripcion.ToString();
            objActividades.imagen_actividad = value.Imagen.ToString();
            if (objActividades.modificar_actividad())
            {
                return Json(new { msg = "Succesfully Modified" });
            }
            else
            {
                return Json(new { msg = "1", numero_error = objActividades.num_error, mensaje_error = objActividades.mensaje });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;

        }
    }
}