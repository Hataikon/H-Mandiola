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
    public class BitacoraController : ApiController
    {
        BLL_bitacora objBitacora = new BLL_bitacora();

        [Route("~/api/Bitacora")]
        [HttpGet]
        public List<Bitacora> GetAll()
        {
            DataSet ds = objBitacora.carga_lista_bitacora();
            DataTable dt = ds.Tables[0];

            var retList = new List<Bitacora>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Bitacora()
                {
                    Codigo_Registro = Convert.ToString(row["CODIGO_REGISTRO"]),
                    Usuario = Convert.ToString(row["USUARIO"]),
                    Fecha_Hora = DateTime.Parse(Convert.ToString(row["FECHA_HORA_BITACORA"])).ToString("MM/dd/yyyy"),
                    Tipo = Convert.ToString(row["TIPO"]),
                    Descripcion = Convert.ToString(row["DESCRIPCION"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Bitacora/AgregarRegistro")]
        [HttpPost]
        public IHttpActionResult AgregarConsecutivo([FromBody]Bitacora value)
        {
            objBitacora.usuario = value.Usuario.ToString();
            objBitacora.codigo_registro = value.Codigo_Registro.ToString();
            objBitacora.fecha_hora_bitacora = value.Fecha_Hora.ToString();
            objBitacora.tipo = value.Tipo.ToString();
            objBitacora.descripcion = value.Descripcion.ToString();
            objBitacora.registro_detalle = value.Detalle.ToString();
            if (objBitacora.agregar_bitacora())
            {
                return Json(new { msg = "Record Agregado a la bitacora "});
            }
            else
            {
                return Json(new { msg = "Error al agregar records a la bitacora" });
            }
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            
        }

    }
}