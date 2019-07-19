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
    public class BLL_error
    {

        #region propiedades
        private string _numero_error;

        public string numero_error_error
        {
            get { return _numero_error; }
            set { _numero_error = value; }
        }

        private string _fecha_hora_error;
        public string fecha_hora_error
        {
            get { return _fecha_hora_error; }
            set { _fecha_hora_error = value; }
        }

        private string _mensaje_error;
        public string mensaje_error_error
        {
            get { return _mensaje_error; }
            set { _mensaje_error = value; }
        }
        #endregion

        #region variables privadas
        //Yuan Connection String = @"Data Source=.\SQLEXPRESS;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled";
        //Luis Connection Strring = @"Data Source=(localdb)\CGEL;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled";
        string CS = "ProyectoMandiolaConnectionString";
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public DataSet carga_lista_error()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la tabla de errores
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=error_conectando_a_la_bd");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_ERROR";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=error_recuperando_lista");
                    return null;
                }
                else
                {
                    return ds;
                }
            }
        }

        public bool agregar_error()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=error_conectando_a_la_bd");
                return false;
            }
            else
            {
                agregar_error_sub();

                if (numero_error != 0)
                {
                    //OwO
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=error_agregando_error");
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

        private void agregar_error_sub()
        {
            ParamStruct[] parametros = new ParamStruct[3];
            sql = "sp_INSERTAR_ERROR";
            parametros = new ParamStruct[3];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@numero", SqlDbType.VarChar, _numero_error);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@fecha_hora", SqlDbType.VarChar, _fecha_hora_error);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@mensaje", SqlDbType.VarChar, _mensaje_error);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }
        #endregion

    }
}
