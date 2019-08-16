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
   public class BLL_compras
    {
        private string _cliente;
        public string cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private string _estado;

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _codigo_de_activo;

        public string codigo_de_activo
        {
            get { return _codigo_de_activo; }
            set { _codigo_de_activo = value; }
        }

        private string _codigo_de_precio;

        public string codigo_de_precio
        {
            get { return _codigo_de_precio; }
            set { _codigo_de_precio = value; }
        }
        private string _cantidad;

        public string cantidad
        {
            get { return _cantidad; }
            set { _codigo_de_precio = value; }
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

        public DataSet carga_lista_compras()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("error.html?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return null;
            }
            else
            {
                sql = "sp_TRAE_LISTA_COMPRAS";
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

        public bool agregar_compra()
        {
            conexion = cls_DAL.trae_conexion(CS, ref _mensaje, ref _num_error);
            if (conexion == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + _num_error.ToString() + "&men=Error_Conectando_A_la_BD");
                return false;
            }
            else
            {
                agregar_compra_sub();

                if (_num_error != 0)
                {
                    HttpContext.Current.Response.Redirect("https://localhost:44331/error.html?error=" + _num_error.ToString() + "&men=Error_Agregando_Compra");
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

        private void agregar_compra_sub()
        {
            sql = "sp_AGREGAR_COMPRA";
            ParamStruct[] parametros = new ParamStruct[5];
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@cliente", SqlDbType.VarChar, _cliente);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@estado", SqlDbType.VarChar, _estado);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@cda", SqlDbType.VarChar, _codigo_de_activo);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@cdp", SqlDbType.VarChar, _codigo_de_precio);
            cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@cantidad", SqlDbType.NVarChar, _cantidad);
            cls_DAL.conectar(conexion, ref _mensaje, ref _num_error);
            cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref _mensaje, ref _num_error);
        }
    }
}
    

