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
   public class BLL_actividades
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

        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _imagen_actividad;

        public string imagen_actividad
        {
            get { return _imagen_actividad; }
            set { _imagen_actividad = value; }
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

        #region variables privadas
        //Yuan Connection String = @"Data Source=.\SQLEXPRESS;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled";
        //Luis Connection Strring = @"Data Source=(localdb)\CGEL;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled";
        string CS = "ProyectoMandiolaConnectionString";
        SqlConnection conexion;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public DataSet carga_lista_actividades()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_ACTIVIDADES";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref _mensaje, ref _num_error);
                if (_num_error != 0)
                {
                    HttpContext.Current.Response.Redirect("error.html?error=" + _num_error.ToString() + "&men=Error_Consiguiendo_Lista");
                    return null;
                }
                else
                {
                    return ds;
                }
            }

        }

        public bool agregar_actividad()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return false;
            }
            else
            {
                agregar_actividad_sub();

                if (_num_error != 0)
                {
                    HttpContext.Current.Response.Redirect("https://localhost:44331/error.html?error=" + _num_error.ToString() + "&men=Error_Agregando_Consecutivos");
                    cls_DAL.desconectar(conexion, ref _mensaje, ref _num_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref _mensaje, ref _num_error);
                    return true;
                }
            }
        }

        private void agregar_actividad_sub()
        {
            sql = "sp_INSERTAR_ACTIVIDAD";
            ParamStruct[] parametros = new ParamStruct[6];
            string consecutivo_str = _codigo_consecutivo.Substring(_codigo_consecutivo.LastIndexOf('-') + 1);
            int consecutivo = Convert.ToInt32(consecutivo_str) + 1;
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@codigo", SqlDbType.VarChar, _codigo_consecutivo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@prefijo", SqlDbType.Char, _prefijo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@nombre", SqlDbType.VarChar, _nombre);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@descripcion", SqlDbType.VarChar, _descripcion);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@img", SqlDbType.VarChar, _imagen_actividad);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@consecutivo", SqlDbType.NVarChar, consecutivo);
            cls_DAL.conectar(conexion, ref _mensaje, ref _num_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref _mensaje, ref _num_error);
        }

        public bool modificar_actividad()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return false;
            }
            else
            {
                modificar_actividad_sub();

                if (_num_error != 0)
                {
                    HttpContext.Current.Response.Redirect("https://localhost:44331/error.html?error=" + _num_error.ToString() + "&men=Error_Agregando_Consecutivos");
                    cls_DAL.desconectar(conexion, ref _mensaje, ref _num_error);
                    return false;
                }
                else
                {
                    cls_DAL.desconectar(conexion, ref _mensaje, ref _num_error);
                    return true;
                }
            }
        }

        private void modificar_actividad_sub()
        {
            sql = "sp_MODIFICAR_ACTIVIDAD";
            ParamStruct[] parametros = new ParamStruct[4];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@codigo", SqlDbType.VarChar, _codigo_consecutivo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@numero", SqlDbType.VarChar, _nombre);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@descripcion", SqlDbType.VarChar, _descripcion);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@img", SqlDbType.VarChar, _imagen_actividad);
            cls_DAL.conectar(conexion, ref _mensaje, ref _num_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref _mensaje, ref _num_error);
        }
        #endregion

    }
}
