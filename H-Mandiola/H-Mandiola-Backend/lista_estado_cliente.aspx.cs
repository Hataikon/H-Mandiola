using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class lista_estado_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("Booking ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Cancelado", typeof(string)));
            dr = dt.NewRow();
            dr["Cliente"] = 1;
            dr["Booking ID"] = "EA45AF32";
            dr["Cancelado"] = "Pagado";
            dt.Rows.Add(dr);

            listaDeEstadosGrid.DataSource = dt;
            listaDeEstadosGrid.DataBind();

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("estado_cliente.aspx?id=0");
        }
    }
}