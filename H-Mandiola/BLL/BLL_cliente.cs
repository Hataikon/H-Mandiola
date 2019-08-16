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
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos 

        public bool agregar_cliente()
        {
            conexion = cls_DAL.trae_conexion("ConexionUusario", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Server.Transfer("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                return false;
            }
            else
            {
                sql = "sp_AGREGAR_CLIENTE";
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Nombre", SqlDbType.NVarChar, _nombre);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Primerapellido", SqlDbType.NVarChar, _primer_apellido);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Segundoapellido", SqlDbType.NVarChar, _segundo_apellido);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Usuario", SqlDbType.NVarChar, _nombre_usuario);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Email", SqlDbType.NVarChar, _email );
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Password", SqlDbType.NVarChar, _contrasena);

                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);

                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Server.Transfer("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
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

        public bool actualizar_contrasena()
        {
            conexion = cls_DAL.trae_conexion("ConexionUusario", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Server.Transfer("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                return false;
            }
            else
            {
                sql = "sp_cambiocontra";
                ParamStruct[] parametros = new ParamStruct[2];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Nombre", SqlDbType.NVarChar, _nombre);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Contrasena", SqlDbType.NVarChar, _contrasena);

                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);

                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Server.Transfer("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
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


        public DataSet lista()
        {
            conexion = cls_DAL.trae_conexion("ConexionUusario", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Server.Transfer("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                return null;
            }
            else
            {
                sql = "sp_lista";
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Server.Transfer("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    return null;
                }
                else
                {
                    return ds;
                }
            }
        }


        #endregion
    }
}
