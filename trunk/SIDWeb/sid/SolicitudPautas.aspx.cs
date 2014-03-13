using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BLLayer;
using BELayer;
using System.Data;

namespace sid
{
    public partial class SolicitudPautas : System.Web.UI.Page
    {
        BLPauta oBLPauta = new BLPauta();

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

        protected void dgvPautaCanilla_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtSolicitada = (TextBox)e.Row.FindControl("txtSolicitada");
                Label lblSolicitada = (Label)e.Row.FindControl("lblSolicitada");
                lblSolicitada.Visible = false;
            }
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
                BEPauta pauta = new BEPauta();
                pauta.codigoCanilla = txtCodigoCanilla.Text.Trim();
                pauta.fechaPauta = clnFecha.SelectedDate;
                List<BEPauta> listaPautas = oBLPauta.selectPautasCanillas(pauta);

                var strMensaje = string.Empty;
                var strClass = string.Empty;

                if (listaPautas.Count > 0)
                {
                    dgvPautaCanilla.DataSource = listaPautas;
                    dgvPautaCanilla.DataBind();
                    divResultado.Visible = true;
                }
                else
                {
                    dgvPautaCanilla.DataSource = null;
                    dgvPautaCanilla.DataBind();
                    divResultado.Visible = false;
                    strMensaje = "El canilla no tiene productos asignados";
                    strClass = "alert alert-warning";

                    spnMensaje.Attributes["class"] = strClass;
                    spnMensaje.InnerText = strMensaje;
                    spnMensaje.Visible = true;
                }
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