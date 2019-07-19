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
    public class BLL_bitacora
    {
        #region propiedades
        private string _codigo_registro;

        public string codigo_registro
        {
            get { return _codigo_registro; }
            set { _codigo_registro = value; }
        }

        private string _usuario;
        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _fecha_hora_bitacora;
        public string fecha_hora_bitacora
        {
            get { return _fecha_hora_bitacora; }
            set { _fecha_hora_bitacora = value; }
        }

        private string _tipo;
        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _registro_detalle;
        public string registro_detalle
        {
            get { return _registro_detalle; }
            set { _registro_detalle = value; }
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
        public DataSet carga_lista_bitacora()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la tabla de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_BITACORA";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Consiguiendo_Lista");
                    return null;
                }
                else
                {
                    return ds;
                }
            }
        }

        public bool agregar_bitacora()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return false;
            }
            else
            {
                agregar_bitacora_sub();

                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Agregando_Registro_Bitacora");
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

        private void agregar_bitacora_sub()
        {
            ParamStruct[] parametros = new ParamStruct[6];
            sql = "sp_INSERTAR_BITACORA";
            parametros = new ParamStruct[6];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@code", SqlDbType.VarChar, _codigo_registro);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@user", SqlDbType.VarChar, _usuario);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@time", SqlDbType.VarChar, _fecha_hora_bitacora);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@type", SqlDbType.VarChar, _tipo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@desc", SqlDbType.VarChar, _descripcion);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@detail", SqlDbType.VarChar, _registro_detalle);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }
        #endregion
    }
}
