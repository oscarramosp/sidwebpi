using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sid
{
    public partial class SolicitudPautas : System.Web.UI.Page
    {
        #region "EVENTOS---------------------"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setControles();
            }
        }

        protected void txtCodigoCanilla_TextChanged(object sender, EventArgs e)
        {
            buscarSolicitudes();
        }

        protected void clnFecha_SelectionChanged(object sender, EventArgs e)
        {
            buscarSolicitudes();
        }

        protected void btnSolicitarPauta_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region "METODOS---------------------"
        protected void setControles()
        {
            clnFecha.SelectionMode = CalendarSelectionMode.Day;
            clnFecha.SelectedDate = DateTime.Today.AddDays(1);
        }

        protected void buscarSolicitudes()
        {
            spnMensaje.Attributes["class"] = string.Empty;
            spnMensaje.InnerText = string.Empty;
            spnMensaje.Visible = false;

            if (validarDatos())
            {
                
            }
        }

        protected Boolean validarDatos()
        {
            var resultado = false;

            if (String.IsNullOrEmpty(txtCodigoCanilla.Text) || String.IsNullOrEmpty(txtNombreCanilla.Text) || clnFecha.SelectedDate == DateTime.MinValue)
            {
                var strMensaje = string.Empty;
                var strClass = string.Empty;
                divResultado.Visible = false;
                strMensaje = "Se debe seleccionar un canilla y una fecha para la solicitud";
                strClass = "alert alert-warning";

                spnMensaje.Attributes["class"] = strClass;
                spnMensaje.InnerText = strMensaje;
                spnMensaje.Visible = true;
            }
            else
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion
    }
}