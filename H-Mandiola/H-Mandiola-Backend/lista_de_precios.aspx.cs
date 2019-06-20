using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class lista_de_precios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            dt.Columns.Add(new DataColumn("Tipo", typeof(string)));
            dt.Columns.Add(new DataColumn("Precio", typeof(string)));
            dr = dt.NewRow();
            dr["CODIGO"] = "PRE-101";
            dr["Tipo"] = "Habitacion Deluxe";
            dr["Precio"] = "500";
            dt.Rows.Add(dr);

            listaDePreciosGrid.DataSource = dt;
            listaDePreciosGrid.DataBind();

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("precios.aspx?id=0");
        }
    }
}