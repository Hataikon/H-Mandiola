using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class lista_de_habitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            dt.Columns.Add(new DataColumn("Numero", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dr = dt.NewRow();
            dr["CODIGO"] = "HA-047";
            dr["Numero"] = "101";
            dr["Descripcion"] = "Deluxe";
            dt.Rows.Add(dr);

            listaDeHabitacionesGrid.DataSource = dt;
            listaDeHabitacionesGrid.DataBind();

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("habitaciones.aspx?id=0");
        }
    }
}