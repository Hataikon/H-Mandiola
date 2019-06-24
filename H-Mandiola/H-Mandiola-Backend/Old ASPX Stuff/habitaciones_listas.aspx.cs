using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class habitaciones_listas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            dt.Columns.Add(new DataColumn("NUMERO", typeof(string)));
            dt.Columns.Add(new DataColumn("DETALLE", typeof(string)));
            dr = dt.NewRow();
            dr["CODIGO"] = "HA-048";
            dr["NUMERO"] = "107";
            dr["DETALLE"] = "Lista";
            dt.Rows.Add(dr);

            habitacionesListasGrid.DataSource = dt;
            habitacionesListasGrid.DataBind();

        }
        protected void filtrarButton_Click(object sender, EventArgs e)
        {
        }
    }
}