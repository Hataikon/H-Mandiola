using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H_Mandiola_Backend
{
    public partial class consulta_errores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void errorGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void txtStart_TextChanged(object sender, EventArgs e)
        {
            populate();
        }

        protected void txtEnd_TextChanged(object sender, EventArgs e)
        {
            populate();
        }

        void populate()
        {/*
            DataTable dt = new DataTable();

            dt.Columns.Add("Codigo", typeof(int));
            dt.Columns.Add("Numero", typeof(string));
            dt.Columns.Add("Hora", typeof(DateTime));
            dt.Columns.Add("Mensaje", typeof(string));

            foreach (DataRow r in obj_errores.carga_lista_errores().Tables[0].Rows)
            {
                DateTime timestamp = (DateTime)r["FECHA_HORA_ERROR"];
                if (filterDates(timestamp))
                {
                    dt.Rows.Add
                    (
                        r["CODIGO_ERROR"],
                        r["NUMERO_ERROR"],
                        r["FECHA_HORA_ERROR"],
                        r["MENSAJE_ERROR"]
                    );
                }
            }

            errorGridView.DataSource = dt;
            errorGridView.DataBind();
            */
        }

        bool filterDates(DateTime got)
        {
            DateTime A = calendarStart.SelectedDate != null ? (DateTime)calendarStart.SelectedDate : new DateTime(1900, 1, 1, 0, 0, 0);
            DateTime B = calendarEnd.SelectedDate != null ? (DateTime)calendarEnd.SelectedDate : DateTime.Now;

            return DateTime.Compare(got, A) >= 0 && DateTime.Compare(got, B) <= 0;
        }
    }
}