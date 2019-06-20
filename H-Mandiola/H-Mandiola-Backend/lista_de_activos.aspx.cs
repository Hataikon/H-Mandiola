using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class lista_de_activos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dr = dt.NewRow();
            dr["CODIGO"] = "AK-047";
            dr["Nombre"] = "Flores";
            dt.Rows.Add(dr);

            listaDeActivosGrid.DataSource = dt;
            listaDeActivosGrid.DataBind();

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("activos.aspx?id=0");
        }
    }
}