using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string CS = @"Data Source=.\SQLEXPRESS;Initial Catalog = ProyectoMandiola;Integrated Security = True; Column Encryption Setting = Enabled";
        SqlConnection Connection = new SqlConnection(CS);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String Prefijo = "HA2";
            int Consecutivo = 1;
            String Descripcion = "Habitacion";
            int ri = 1;
            int rf = 200;

            InsertData(Prefijo, Consecutivo, Descripcion, ri, rf);
        }

        private void InsertData(String Prefijo, int Consecutivo, String Descripcion, int ri, int rf)
        {
            Connection.Open();

            //Insertar en Consecutivo
            string executeCommand = "sp_AGREGAR_CONSECUTIVO";
            SqlCommand cmd = new SqlCommand(executeCommand, Connection);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@prefijo", System.Data.SqlDbType.Char);
            cmd.Parameters["@prefijo"].Value = Prefijo;

            cmd.Parameters.Add("@consecutivo", System.Data.SqlDbType.NVarChar);
            cmd.Parameters["@consecutivo"].Value = Consecutivo;

            cmd.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@descripcion"].Value = Descripcion;

            cmd.Parameters.Add("@ri", System.Data.SqlDbType.NVarChar);
            cmd.Parameters["@ri"].Value = ri;

            cmd.Parameters.Add("@rf", System.Data.SqlDbType.NVarChar);
            cmd.Parameters["@rf"].Value = rf;

            cmd.ExecuteNonQuery();

            //Insertar en Aerolinea

            /*
            String executeCommand = "sp_AGREGAR_AEROLINEA";
            SqlCommand cmd = new SqlCommand(executeCommand, Connection);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@consecutivo", System.Data.SqlDbType.NVarChar);
            cmd.Parameters["@consecutivo"].Value = Consecutivo;

            cmd.Parameters.Add("@prefijo", System.Data.SqlDbType.Char);
            cmd.Parameters["@prefijo"].Value = Prefijo;

            cmd.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@descripcion"].Value = Descripcion;

            cmd.ExecuteNonQuery();*/
        }
    }
}