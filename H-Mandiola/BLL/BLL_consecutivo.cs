using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using DAL;
using System.Web.Security;


namespace BLL
{
    public class BLL_consecutivo
    {
        #region variables publicas

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

        private string _rango_inicial;
        public string rango_inicial
        {
            get { return _rango_inicial; }
            set { _rango_inicial = value; }
        }

        private string _rango_final;
        public string rango_final
        {
            get { return _rango_final; }
            set { _rango_final = value; }
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
        public DataSet carga_lista_consecutivos()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_CONSECUTIVOS";
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

        public bool agregar_consecutivo()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return false;
            }
            else
            {
                agregar_consecutivo_sub();

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

        private void agregar_consecutivo_sub()
        {
            sql = "sp_AGREGAR_CONSECUTIVO";
            ParamStruct[] parametros = new ParamStruct[5];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@prefijo", SqlDbType.Char, _prefijo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@consecutivo", SqlDbType.NVarChar, _codigo_consecutivo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@descripcion", SqlDbType.VarChar, _descripcion);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@ri", SqlDbType.NVarChar, _rango_inicial);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@rf", SqlDbType.NVarChar, _rango_final);
            cls_DAL.conectar(conexion, ref _mensaje, ref _num_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref _mensaje, ref _num_error);
        }

        public bool modificar_consecutivo()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return false;
            }
            else
            {
                modificar_consecutivo_sub();

                if (_num_error != 0)
                {
                    HttpContext.Current.Response.Redirect("error.html?error=" + _num_error.ToString() + "&men=Error_Modificando_Consecutivos");
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

        private void modificar_consecutivo_sub()
        {
            sql = "sp_MODIFICAR_CONSECUTIVO";
            ParamStruct[] parametros = new ParamStruct[5];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@prefijo", SqlDbType.Char, _prefijo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@consecutivo", SqlDbType.NVarChar, _codigo_consecutivo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@descripcion", SqlDbType.VarChar, _descripcion);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@ri", SqlDbType.NVarChar, _rango_inicial);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@rf", SqlDbType.NVarChar, _rango_final);
            cls_DAL.conectar(conexion, ref _mensaje, ref _num_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref _mensaje, ref _num_error);
        }
        #endregion
    }
}
