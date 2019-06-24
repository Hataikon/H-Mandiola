using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class consecutivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void prefijoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (prefijoCheckBox.Checked)
            {
                prefijoBox.ReadOnly = false;
            }
            else
            {
                prefijoBox.ReadOnly = true;
            }
        }

        protected void rangoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rangoCheckBox.Checked)
            {
                rangoInicialBox.ReadOnly = false;
                rangoFinalBox.ReadOnly = false;
            }
            else
            {
                rangoInicialBox.ReadOnly = true;
                rangoFinalBox.ReadOnly = true;
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("consecutivos.aspx?id=0");
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
        }
        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("lista_de_consecutivos.aspx");
        }
    }
}