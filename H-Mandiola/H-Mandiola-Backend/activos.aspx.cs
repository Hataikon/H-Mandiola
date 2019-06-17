using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class activos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cerrarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("lista_de_activos.aspx");
        }

        protected void borrarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("activos.aspx?codigo=0");
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
        }

        protected void ConsecutivoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            codigoBox.Text = ConsecutivoList.SelectedValue.ToString();
        }
    }
}