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
    public partial class RegistroFormula : System.Web.UI.Page
    {
        BLFormula oBLFormula = new BLFormula();

        #region "EVENTOS---------------------"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarOperadores();
                cargarVariables();
                asignarEventosJS();
            }
        }

        protected void ddlOperadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarOperadoresE();
        }

        protected void btnGrabarFx_Click(object sender, EventArgs e)
        {
            var objFormula = Util.SessionHelper.getFormulaEditar();

            objFormula.formula = txtEditor.Text.Trim();
            var oDTOResultado = oBLFormula.grabarFormula(objFormula);

            objFormula = (BEFormula)oDTOResultado.Objeto;

            if (oDTOResultado.Codigo != (int)Constantes.CodigoGrabarFormula.Ok)
            {
                if (oDTOResultado.Codigo == (int)Constantes.CodigoGrabarFormula.ErrorSintaxis)
                {
                    //error sintaxis
                }
                else
                {
                    //error general
                }
            }
            else
            {
                //mensaje grabar ok
                Util.SessionHelper.setFormulaEditar(objFormula);
            }
        }
        #endregion
        
        #region "METODOS---------------------"
        protected void cargarOperadores()
        {
            string[] strIdOperadores = ConfigurationManager.AppSettings["idOperadores"].Split(',');
            string[] strDesOperadores = ConfigurationManager.AppSettings["desOperadores"].Split(',');

            for (int i = 0; i < strIdOperadores.Length; i++)
            {
                ddlOperadores.Items.Add(new ListItem(strDesOperadores[i], strIdOperadores[i]));
            }

            var liSeleccione = new ListItem("Seleccione", "0");
            ddlOperadores.Items.Insert(0, liSeleccione);
            ddlOperadores.DataBind();
        }

        protected void cargarOperadoresE()
        {
            lstOperadores.Items.Clear();
            if(!ddlOperadores.SelectedValue.Equals("0"))
            {
                string[] operadoresEsp = ConfigurationManager.AppSettings["operadores" + ddlOperadores.SelectedValue.Trim()].Split(',');

                for (int i = 0; i < operadoresEsp.Length; i++)
                {
                    lstOperadores.Items.Add(new ListItem(operadoresEsp[i], operadoresEsp[i]));
                }
            }
        }

        protected void cargarVariables()
        {
            var general = new BEGeneral();
            general.nombreObjeto = "TB_PAUTA";
            general.tipoDato = string.Empty;
            var blGeneral = new BLGeneral();
            lstVariables.DataSource = blGeneral.listarColumnas(general);
            lstVariables.DataTextField = "NOMBRE";
            lstVariables.DataValueField = "NOMBRE";
            lstVariables.DataBind();
        }

        protected void asignarEventosJS()
        {
            lstOperadores.Attributes.Add("OndblClick", "GetValue('" + lstOperadores.ClientID + "','" + txtEditor.ClientID + "','','');");
            lstVariables.Attributes.Add("OndblClick", "GetValue('" + lstVariables.ClientID + "','" + txtEditor.ClientID + "','$','$');");
        }
        #endregion
    }
}
