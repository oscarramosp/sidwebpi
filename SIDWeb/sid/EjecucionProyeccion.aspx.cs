using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sid
{
    public partial class EjecucionProyeccion : System.Web.UI.Page
    {
        #region "EVENTOS---------------------"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                clnFecha.SelectionMode = CalendarSelectionMode.Day;
                clnFecha.SelectedDate = DateTime.Today;
            }
        }

        protected void clnFecha_SelectionChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region "METODOS---------------------"
        #endregion
    }
}
