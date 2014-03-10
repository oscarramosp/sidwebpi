﻿using System;
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
    public partial class ConsultaCanillas : System.Web.UI.Page
    {
        BLCanilla oBlCanilla = new BLCanilla();
        String txtD = String.Empty;
        String txtC = String.Empty;

        #region "EVENTOS-----------------------------------"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setControles();
                txtC = Request.QueryString["txtc"];
                txtD = Request.QueryString["txtd"];
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarCanillas();
        }

        protected void dgvCanillas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].Style.Add("cursor","hand");
                e.Row.Cells[0].Attributes.Add("ondblclick", "devolver('" + ((BECanilla)e.Row.DataItem).codigoCanilla.Trim() + "', '" + ((BECanilla)e.Row.DataItem).nombreCompletoCanilla + "');");
                //e.Row.Cells[0].Attributes.Add("ondblclick", "devolver2('" + ((BECanilla)e.Row.DataItem).codigoCanilla.Trim() + "', '" + ((BECanilla)e.Row.DataItem).nombreCompletoCanilla + "');");
                //devolver(codigoCanilla, nombreCanilla)
                //BoundColumn columnaCodigo = (BoundColumn)e.Row.Cells[0].;
            }
        }
        
        protected void dgvCanillas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "Seleccionar":
                    StringBuilder strJScript = new StringBuilder();
                    string strCodigoCanilla = e.CommandArgument.ToString();
                    string strNombreCanilla = "lala";// e.Item.Cells[2].Text;
                    strJScript.Append("<script>");
                    strJScript.Append("alert('test Js');");
                    strJScript.AppendFormat("window.opener.devolverCanilla('{0}','{1}');", strCodigoCanilla, strNombreCanilla);
                    strJScript.Append("window.close();");
                    strJScript.Append("</script>");
                    ClientScript.RegisterStartupScript(typeof(Page), "keyClientBlock2", strJScript.ToString());
                    break;
            }
        }
        #endregion
        #region "METODOS-----------------------------------"
        protected void setControles()
        {
            cargarTiposDocumento();
        }

        protected void cargarTiposDocumento()
        {
            string[] strTiposDocumento = ConfigurationManager.AppSettings["tiposDocumento"].Split(',');

            for (int i = 0; i < strTiposDocumento.Length; i++)
            {
                ddlTipoDocumento.Items.Add(new ListItem(strTiposDocumento[i], strTiposDocumento[i]));
            }

            var liSeleccione = new ListItem("Todos", "");
            ddlTipoDocumento.Items.Insert(0, liSeleccione);
            ddlTipoDocumento.DataBind();
        }

        protected void buscarCanillas()
        {
            spnMensaje.Attributes["class"] = string.Empty;
            spnMensaje.InnerText = string.Empty;
            spnMensaje.Visible = false;

            BECanilla canilla = new BECanilla();
            canilla.codigoCanilla = txtCodigoCanilla.Text;
            canilla.nombreCompletoCanilla = txtNombreCanilla.Text;
            canilla.tipoDocumento = ddlTipoDocumento.SelectedValue;
            canilla.numeroDocumento = txtNumeroDocumento.Text;
            List<BECanilla> listaCanillas = oBlCanilla.selectCanillas(canilla);

            var strMensaje = string.Empty;
            var strClass = string.Empty;

            if (listaCanillas.Count > 0)
            {
                dgvCanillas.DataSource = listaCanillas;
                dgvCanillas.DataBind();
                divResultado.Visible = true;
            }
            else
            {
                dgvCanillas.DataSource = null;
                dgvCanillas.DataBind();
                divResultado.Visible = false;
                strMensaje = "No se han encontrado canillas";
                strClass = "alert alert-warning";

                spnMensaje.Attributes["class"] = strClass;
                spnMensaje.InnerText = strMensaje;
                spnMensaje.Visible = true;
            }
        }
        #endregion
    }
}
