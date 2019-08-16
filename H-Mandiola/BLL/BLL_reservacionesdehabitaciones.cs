using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using DAL;
using System.Web.Security;

namespace BLL
{
   public class BLL_reservacionesdehabitaciones
    {
        private string _booking_id;
        public string booking_id
        {
            get { return _booking_id; }
            set { _booking_id = value; }
        }

        private string _numero_de_reservacion;

        public string numero_de_reservacion
        {
            get { return _numero_de_reservacion; }
            set { _numero_de_reservacion = value; }
        }

        private string _cliente;

        public string cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private string _itinerario;

        public string itinerario
        {
            get { return _itinerario; }
            set { _itinerario = value; }
        }

        private string _codigo_de_habitacion;

        public string codigo_de_habitacion
        {
            get { return _codigo_de_habitacion; }
            set { _codigo_de_habitacion = value; }
        }

        private string _codigo_de_precio;

        public string codigo_de_precio
        {
            get { return _codigo_de_precio; }
            set { _codigo_de_precio = value; }
        }

        private string _cantidad_de_personas;

        public string cantidad_de_personas
        {
            get { return _cantidad_de_personas; }
            set { _cantidad_de_personas = value; }
        }

        private string _cantidad_de_dias;

        public string cantidad_de_dias
        {
            get { return _cantidad_de_dias; }
            set { _cantidad_de_dias = value; }
        }
        private string _cantidad_de_habitaciones;

        public string cantidad_de_habitaciones
        {
            get { return _cantidad_de_personas; }
            set { _cantidad_de_personas = value; }
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

        //Yuan Connection String = @"Data Source=.\SQLEXPRESS;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled";
        //Luis Connection Strring = @"Data Source=(localdb)\CGEL;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled";
        string CS = "ProyectoMandiolaConnectionString";
        SqlConnection conexion;
        string sql;
        DataSet ds;


        public DataSet carga_lista_reservacion()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_RESERVACION";
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

        public bool agregar_reservacion()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return false;
            }
            else
            {
                agregar_reservacion_sub();

                if (_num_error != 0)
                {
                    HttpContext.Current.Response.Redirect("https://localhost:44331/error.html?error=" + _num_error.ToString() + "&men=Error_Agregando_Reservacion");
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

        private void agregar_reservacion_sub()
        {
            sql = "sp_AGREGAR_COMPRA";
            ParamStruct[] parametros = new ParamStruct[5];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@booking_id", SqlDbType.VarChar, _booking_id);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@ndr", SqlDbType.NVarChar, _numero_de_reservacion);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@cliente", SqlDbType.VarChar, _cliente);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@itinerario", SqlDbType.VarChar, _itinerario);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@cdh", SqlDbType.VarChar, _codigo_de_habitacion);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@cdp", SqlDbType.VarChar, _codigo_de_precio);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@cantidad_de_personas", SqlDbType.NVarChar, _cantidad_de_personas);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@cdd", SqlDbType.NVarChar, _cantidad_de_dias);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@cantidad_de_habitaciones", SqlDbType.NVarChar, _cantidad_de_habitaciones);
            cls_DAL.conectar(conexion, ref _mensaje, ref _num_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref _mensaje, ref _num_error);
        }
    }
}