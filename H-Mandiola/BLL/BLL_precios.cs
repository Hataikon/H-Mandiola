using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using DAL;

namespace BLL
{
  public class BLL_precios
    {
        #region Variables Publicas
        private string _prefijo;
        public string prefijo
        {
            get { return _prefijo; }
            set { _prefijo = value; }
        }

        private string _codigo_consecutivo;

        public string codigo_consecutivo
        {
            get { return _codigo_consecutivo; }
            set { _codigo_consecutivo = value; }
        }

        private string _tipo;

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _precio;

        public string precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        private int _num_error;

        public int num_error
        {
            get { return _num_error; }
            set { _num_error = value; }
        }
        #endregion

        string CS = "ProyectoMandiolaConnectionString";
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;

        public DataSet carga_lista_precios()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.html?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_PRECIOS";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    return null;
                }
                else
                {
                    return ds;
                }
            }

        }

        public bool agregar_precio()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                agregar_precio_sub();

                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return true;
                }
            }
        }

        private void agregar_precio_sub()
        {
            sql = "sp_INSERTAR_PRECIO";
            string consecutivo_str = _codigo_consecutivo.Substring(_codigo_consecutivo.LastIndexOf('-') + 1);
            int consecutivo = Convert.ToInt32(consecutivo_str) + 1;
            ParamStruct[] parametros = new ParamStruct[5];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@prefijo", SqlDbType.Char, _prefijo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@codigo", SqlDbType.VarChar, _codigo_consecutivo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@tipo", SqlDbType.VarChar, _tipo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@precio", SqlDbType.NVarChar, _precio);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@consecutivo", SqlDbType.NVarChar, consecutivo);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }

        public bool modificar_precio()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return false;
            }
            else
            {
                modificar_precio_sub();

                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    return true;
                }
            }
        }

        private void modificar_precio_sub()
        {
            sql = "sp_MODIFICAR_PRECIO";
            ParamStruct[] parametros = new ParamStruct[3];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@codigo", SqlDbType.VarChar, _codigo_consecutivo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@tipo", SqlDbType.VarChar, _tipo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@precio", SqlDbType.NVarChar, _precio);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }
    }

}
