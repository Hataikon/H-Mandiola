using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            dt.Columns.Add(new DataColumn("Fecha y Hora", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dr = dt.NewRow();
            dr["CODIGO"] = "AC-101";
            dr["Fecha y Hora"] = "2019/05/21 22:00:00";
            dr["Descripcion"] = "Cambio a la actividad de Hiking";
            dt.Rows.Add(dr);

            bitacoraGridView.DataSource = dt;
            bitacoraGridView.DataBind();

        }

        protected void bitacoraGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void bitacoraGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void listAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        protected void personaTextbox_TextChanged(object sender, EventArgs e)
        {
        }

    }
}