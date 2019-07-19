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
    public class BLL_usuario
    {
        #region variables publicas

        private string _nombre_usuario;
        public string nombre_usuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _pregunta;

        public string pregunta
        {
            get { return _pregunta; }
            set { _pregunta = value; }
        }

        private string _respuesta;
        public string respuesta
        {
            get { return _respuesta; }
            set { _respuesta = value; }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _isAdmin;
        public string isAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        private string _isSeguridad;
        public string isSeguridad
        {
            get { return _isSeguridad; }
            set { _isSeguridad = value; }
        }

        private string _isConsecutivo;
        public string isConsecutivo
        {
            get { return _isConsecutivo; }
            set { _isConsecutivo = value; }
        }

        private string _isMantenimiento;
        public string isMantenimiento
        {
            get { return _isMantenimiento; }
            set { _isMantenimiento = value; }
        }

        private string _isConsulta;
        public string isConsulta
        {
            get { return _isConsulta; }
            set { _isConsulta = value; }
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
        public DataSet carga_lista_usuarios()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Conectando_a_la_BD");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_USUARIOS";
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



        public bool agregar_usuario()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Conectando_a_la_BD");
                return false;
            }
            else
            {
                agregar_usuario_sub();

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

        private void agregar_usuario_sub()
        {

            sql = "sp_AGREGAR_USUARIO";
            ParamStruct[] parametros = new ParamStruct[5];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@username", SqlDbType.VarChar, _nombre_usuario);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@password", SqlDbType.VarChar, _password);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@email", SqlDbType.VarChar, _email);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@pregunta", SqlDbType.VarChar, _pregunta);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@respuesta", SqlDbType.VarChar, _respuesta);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }

        public bool cambiar_contraseña ()
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

            sql = "sp_CAMBIAR_CONTRASEÑA";
            ParamStruct[] parametros = new ParamStruct[2];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@username", SqlDbType.VarChar, _nombre_usuario);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@password", SqlDbType.VarChar, _password);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }

        public bool actualizar_roles()
        {
            conexion = cls_DAL.trae_conexion(CS, ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=Error_Conectando_a_la_BD");
                return false;
            }
            else
            {
                actualizar_roles_sub();

                if (numero_error != 0)
                {
                    HttpContext.Current.Response.Redirect("error.html?error=" + numero_error.ToString() + "&men=error_actualizando_roles");
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

        private void actualizar_roles_sub()
        {

            sql = "sp_ACTUALIZAR_ROLES";
            ParamStruct[] parametros = new ParamStruct[6];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@username", SqlDbType.VarChar, _nombre_usuario);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@isAdmin", SqlDbType.Char, _isAdmin);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@isSeguridad", SqlDbType.Char, _isSeguridad);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@isConsecutivo", SqlDbType.Char, _isConsecutivo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@isMantenimiento", SqlDbType.Char, _isMantenimiento);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@isConsulta", SqlDbType.Char, _isConsulta);
            cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
        }
        #endregion
    }
}
