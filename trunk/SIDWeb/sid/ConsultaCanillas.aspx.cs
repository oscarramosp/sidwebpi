using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLayer;
using BELayer;
using System.Data;

namespace sid
{
    public partial class ConsultaCanillas : System.Web.UI.Page
    {

        #region "EVENTOS-----------------------------------"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setControles();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

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

            var liSeleccione = new ListItem("Todos", "0");
            ddlTipoDocumento.Items.Insert(0, liSeleccione);
            ddlTipoDocumento.DataBind();
        }
        #endregion
    }
}
