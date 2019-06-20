using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class lista_de_consecutivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("PREFIJO", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("CODIGO_CONSECUTIVO", typeof(string)));
            dr = dt.NewRow();
            dr["PREFIJO"] = "HA";
            dr["Descripcion"] = "Habitaciones";
            dr["CODIGO_CONSECUTIVO"] = "048";
            dt.Rows.Add(dr);

            listaDeConsecutivosGrid.DataSource = dt;
            listaDeConsecutivosGrid.DataBind();


        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("consecutivos.aspx?id=0");
        }
    }
}