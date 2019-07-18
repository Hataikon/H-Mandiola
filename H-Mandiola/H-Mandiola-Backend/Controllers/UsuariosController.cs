﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace H_Mandiola_Backend.Controllers
{
    public class UsuariosController : ApiController
    {
        BLL_usuario objUsuario = new BLL_usuario();

        [Route("~/api/Usuarios/AgregarUsuario")]
        [HttpPost]
        public IHttpActionResult AgregarUsuario([FromBody]Usuarios value)
        {
            objUsuario.nombre_usuario = value.Username.ToString();
            objUsuario.password = value.Password.ToString();
            objUsuario.email = value.Email.ToString();
            objUsuario.pregunta = value.Pregunta.ToString();
            objUsuario.respuesta = value.Respuesta.ToString();
            objUsuario.agregar_usuario();
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully added " + value.Username.ToString() }); ;
        }

        [Route("~/api/Usuarios/BuscarUsuario")]
        [HttpGet]
        public Usuarios BuscarUsuario(string username, string password)
        {
            DataSet ds = objUsuario.carga_lista_usuarios();
            DataTable dt = ds.Tables[0];

            var retList = new List<Usuarios>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Usuarios()
                {
                    Username = Convert.ToString(row["NOMBRE_USUARIO"]).Trim(),
                    Password = Convert.ToString(row["PASSWORD"]),
                    Email = Convert.ToString(row["EMAIL"]),
                    Pregunta = Convert.ToString(row["PREGUNTA"]),
                    Respuesta = Convert.ToString(row["RESPUESTA"]),
                    isAdmin = Convert.ToString(row["isAdmin"]),
                    isSeguridad = Convert.ToString(row["isSeguridad"]),
                    isConsecutivo = Convert.ToString(row["isConsecutivo"]),
                    isMantenimiento = Convert.ToString(row["isMantenimiento"]),
                    isConsulta = Convert.ToString(row["isConsulta"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Username == username && p.Password == password);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }

        [Route("~/api/Usuarios/BuscarUsuario2")]
        [HttpGet]
        public Usuarios BuscarUsuario(string username)
        {
            DataSet ds = objUsuario.carga_lista_usuarios();
            DataTable dt = ds.Tables[0];

            var retList = new List<Usuarios>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Usuarios()
                {
                    Username = Convert.ToString(row["NOMBRE_USUARIO"]).Trim(),
                    Password = Convert.ToString(row["PASSWORD"]),
                    Email = Convert.ToString(row["EMAIL"]),
                    Pregunta = Convert.ToString(row["PREGUNTA"]),
                    Respuesta = Convert.ToString(row["RESPUESTA"]),
                    isAdmin = Convert.ToString(row["isAdmin"]),
                    isSeguridad = Convert.ToString(row["isSeguridad"]),
                    isConsecutivo = Convert.ToString(row["isConsecutivo"]),
                    isMantenimiento = Convert.ToString(row["isMantenimiento"]),
                    isConsulta = Convert.ToString(row["isConsulta"])
                };

                retList.Add(temp);
            }

            var result = retList.FirstOrDefault((p) => p.Username == username);
            /*if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/
            return result;
        }

        [Route("~/api/Usuarios/CambiarContraseña")]
        [HttpPost]
        public IHttpActionResult CambiarContraseña([FromBody]Usuarios value)
        {
            objUsuario.nombre_usuario = value.Username.ToString();
            objUsuario.password = value.Password.ToString();
            objUsuario.cambiar_contraseña();
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Successfully added " + value.Username.ToString() }); ;
        }

        [Route("~/api/Usuarios")]
        [HttpGet]
        public IEnumerable<Usuarios> GetAll()
        {
            DataSet ds = objUsuario.carga_lista_usuarios();
            DataTable dt = ds.Tables[0];

            var retList = new List<Usuarios>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];

                var temp = new Usuarios()
                {
                    Username = Convert.ToString(row["NOMBRE_USUARIO"]).Trim(),
                    Password = Convert.ToString(row["PASSWORD"]),
                    Email = Convert.ToString(row["EMAIL"]),
                    Pregunta = Convert.ToString(row["PREGUNTA"]),
                    Respuesta = Convert.ToString(row["RESPUESTA"]),
                    isAdmin = Convert.ToString(row["isAdmin"]),
                    isSeguridad = Convert.ToString(row["isSeguridad"]),
                    isConsecutivo = Convert.ToString(row["isConsecutivo"]),
                    isMantenimiento = Convert.ToString(row["isMantenimiento"]),
                    isConsulta = Convert.ToString(row["isConsulta"])
                };

                retList.Add(temp);
            }

            return retList;
        }

        [Route("~/api/Usuarios/ActualizarRoles")]
        [HttpPost]
        public IHttpActionResult ActualizarRoles([FromBody]Usuarios value)
        {
            objUsuario.nombre_usuario = value.Username.ToString();
            objUsuario.isAdmin = value.isAdmin.ToString();
            objUsuario.isSeguridad = value.isSeguridad.ToString();
            objUsuario.isConsecutivo = value.isConsecutivo.ToString();
            objUsuario.isMantenimiento = value.isMantenimiento.ToString();
            objUsuario.isConsulta = value.isConsulta.ToString();
            objUsuario.actualizar_roles();
            //String res = "Exito la wea wn qliao los valores son "+value.Prefijo+" "+value.CODIGO_CONSECUTIVO;
            return Json(new { msg = "Se han actualizado los roles "}); ;
        }
    }
}
