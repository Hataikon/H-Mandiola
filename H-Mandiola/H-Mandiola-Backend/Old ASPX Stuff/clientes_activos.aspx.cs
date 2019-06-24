using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class clientes_activos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("USUARIO", typeof(string)));
            dt.Columns.Add(new DataColumn("NOMBRE", typeof(string)));
            dt.Columns.Add(new DataColumn("HABITACION", typeof(string)));
            dr = dt.NewRow();
            dr["USUARIO"] = "Hamster04";
            dr["NOMBRE"] = "Michael Raymond";
            dr["HABITACION"] = "HA-048";
            dt.Rows.Add(dr);

            clientesActivosGrid.DataSource = dt;
            clientesActivosGrid.DataBind();

        }

        protected void filtrarButton_Click(object sender, EventArgs e)
        {
        }
    }
}