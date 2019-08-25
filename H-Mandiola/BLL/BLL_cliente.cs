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
    public class BLL_cliente
    {
        #region variables publicas

        private string _nombre_usuario;
        public string nombre_usuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _primer_apellido;

        public string primer_apellido
        {
            get { return _primer_apellido; }
            set { _primer_apellido = value; }
        }

        private string _segundo_apellido;
        public string segundo_apellido
        {
            get { return _segundo_apellido; }
            set { _segundo_apellido = value; }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _contrasena;

        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
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
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public DataSet carga_lista_clientes()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Conectando_a_la_BD");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_CLIENTES";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Consiguiendo_lista_usuarios");
                    return null;
                }
                else
                {
                    return ds;
                }
            }

        }



        public bool agregar_cliente()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Conectando_a_la_BD");
                return false;
            }
            else
            {
                agregar_cliente_sub();

                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=error_agregando_usuarios");
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

        private void agregar_cliente_sub()
        {

            sql = "sp_AGREGAR_CLIENTE";
            ParamStruct[] parametros = new ParamStruct[6];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@username", SqlDbType.VarChar, _nombre_usuario);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@password", SqlDbType.VarChar, _contrasena);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@email", SqlDbType.VarChar, _email);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@nombre", SqlDbType.VarChar, _nombre);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@primer_apellido", SqlDbType.VarChar, _primer_apellido);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@segundo_apellido", SqlDbType.VarChar, _segundo_apellido);

            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }

        public bool cambiar_contraseña()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Conectando_a_la_BD");
                return false;
            }
            else
            {
                cambiar_contraseña_sub();

                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=error_cambiando_contrasena");
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

        private void cambiar_contraseña_sub()
        {

            sql = "sp_CAMBIAR_CONTRASEÑA_CLIENTE";
            ParamStruct[] parametros = new ParamStruct[2];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@username", SqlDbType.VarChar, _nombre_usuario);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@password", SqlDbType.VarChar, _contrasena);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }
        #endregion
    }
}
