using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class lista_de_actividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dr = dt.NewRow();
            dr["CODIGO"] = "AC-101";
            dr["Nombre"] = "Hiking";
            dt.Rows.Add(dr);

            listaDeActividadesGrid.DataSource = dt;
            listaDeActividadesGrid.DataBind();

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("actividades.aspx?id=0");
        }
    }
}