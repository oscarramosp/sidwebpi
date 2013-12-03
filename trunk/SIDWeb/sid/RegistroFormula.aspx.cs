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
                setControles();
                cargarDatosFormula();
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
                if (oDTOResultado.Codigo == (int)Constantes.CodigoGrabarFormula.ErrorReferenciaCircular)
                {
                    lblMensaje.Text = "La formula de proyección no puede contener la cantidad de pautas proyectadas";
                }
                else if (oDTOResultado.Codigo == (int)Constantes.CodigoGrabarFormula.ErrorDivisionporCero)
                {
                    lblMensaje.Text = "La fórmula ingresada cuenta una divisón por cero (0). Por favor, validar";
                }
                else if (oDTOResultado.Codigo == (int)Constantes.CodigoGrabarFormula.ErrorSintaxis)
                {
                    lblMensaje.Text = "La fórmula ingresada cuenta con un error de sintaxis. Por favor, validar";
                }
                else
                {
                    oDTOResultado.Codigo = (int)Constantes.CodigoGrabarFormula.Error;
                }
            }
            else
            {
                lblMensaje.Text = "Fórmula actualizada exitosamente";
                Util.SessionHelper.setFormulaEditar(objFormula);
            }
        }
        #endregion
        
        #region "METODOS---------------------"
        protected void setControles()
        {
            cargarOperadores();
            cargarVariables();
            asignarEventosJS();
        }

        protected void cargarDatosFormula()
        {
            var formula = new BEFormula();
            formula.codigoFormula = ConfigurationManager.AppSettings["fx"].ToString();
            formula = oBLFormula.obtenerFormula(formula);

            Util.SessionHelper.setFormulaEditar(formula);

            txtCodigoFormula.Text = formula.codigoFormula;
            txtCodigoFormula.Enabled = false;
            txtEditor.Text = formula.formula;
        }

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
            lstVariables.Attributes.Add("OndblClick", "GetValue('" + lstVariables.ClientID + "','" + txtEditor.ClientID + "','','');");
        }
        #endregion
    }
}
