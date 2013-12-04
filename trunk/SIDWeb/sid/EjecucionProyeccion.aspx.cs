using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BELayer;
using BLLayer;

namespace sid
{
    public partial class EjecucionProyeccion : System.Web.UI.Page
    {
        BLPauta oBLPauta = new BLPauta();

        #region "EVENTOS---------------------"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                clnFecha.SelectionMode = CalendarSelectionMode.Day;
                clnFecha.SelectedDate = DateTime.Today;
                cargarPautasFecha();
            }
        }

        protected void clnFecha_SelectionChanged(object sender, EventArgs e)
        {
            cargarPautasFecha();
        }

        protected void btnProyectarPauta_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region "METODOS---------------------"
        protected void cargarPautasFecha()
        {
            lblSinResultados.Text = "";
            lblSinResultados.Visible = false;
            BEPauta pauta = new BEPauta();
            pauta.fechaPauta = clnFecha.SelectedDate;
            List<BEPauta> listaPautas = oBLPauta.selectPautaProducto(pauta);

            if (listaPautas.Count > 0)
            {
                dgvPauta.DataSource = listaPautas;
                dgvPauta.DataBind();
            }
            else
            {
                dgvPauta.DataSource = null;
                dgvPauta.DataBind();
                lblSinResultados.Text = "No se han solicitado pautas para la fecha seleccionada";
                lblSinResultados.Visible = true;
            }
        }
        #endregion
    }
}
