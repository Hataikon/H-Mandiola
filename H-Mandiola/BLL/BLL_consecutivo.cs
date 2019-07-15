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
        #region propiedades
        private int _id_consecutivo;

        public int id_consecutivo
        {
            get { return _id_consecutivo; }
            set { _id_consecutivo = value; }
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

        private string _prefijo;
        public string prefijo
        {
            get { return _prefijo; }
            set { _prefijo = value; }
        }

        private int _rango_inicial;
        public int rango_inicial
        {
            get { return _rango_inicial; }
            set { _rango_inicial = value; }
        }

        private int _rango_final;
        public int rango_final
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
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public DataSet carga_lista_consecutivos()
        {
            conexion = cls_DAL.trae_conexion(@"Data Source=.\SQLEXPRESS;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_CONSECUTIVOS";
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

        public void carga_datos_consecutivo(string prefijo)
        {
            conexion = cls_DAL.trae_conexion(@"Data Source=.\SQLEXPRESS;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            }
            else
            {
                sql = "sp_BUSCAR_CONSECUTIVO";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@id", SqlDbType.Char, prefijo);
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _codigo_consecutivo = ds.Tables[0].Rows[0]["CODIGO_CONSECUTIVO"].ToString();
                        _descripcion = ds.Tables[0].Rows[0]["DESCRIPCION_CONSECUTIVO"].ToString();
                        _prefijo = ds.Tables[0].Rows[0]["PREFIJO"].ToString();
                        _rango_inicial = Convert.ToInt32(ds.Tables[0].Rows[0]["RANGO_INICIAL"]);
                        _rango_final = Convert.ToInt32(ds.Tables[0].Rows[0]["RANGO_FINAL"]);
                    }
                    else
                    {
                        _prefijo = "Error";
                        _num_error = numero_error;
                        _mensaje = mensaje_error;
                        //objErrores.submitError(_num_error, _mensaje);
                    }
                }
            }
        }
        #endregion
    }
}
