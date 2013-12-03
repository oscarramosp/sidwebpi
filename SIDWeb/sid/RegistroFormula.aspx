<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroFormula.aspx.cs" Inherits="sid.RegistroFormula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Fórmula de proyección de pauta</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="smFiltros" runat="server">
    </asp:ScriptManager>
    <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
        <tr>
            <td style="width:15px">
            </td>
            <td>
                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                    <tr>
                        <td style="width:200px;">
                            Código de fórmula
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodigoFormula" runat="server" Width="402px" CssClass="textoTabulado"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width:15px">
            </td>
            <td style="height:250px; vertical-align:top;">
                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                    <tr>
                        <td style="height:20px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Definición de fórmula
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:textbox id="txtEditor" runat="server" Width="600px" BorderColor="#999999" CssClass="textoTabulado"
								BorderWidth="1px" TextMode="MultiLine" Height="160"></asp:textbox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width:15px">
            </td>
            <td style="height:350px; vertical-align:top;"">
                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                    <tr>
                        <td style="width:25%;">
                            Operadores
                        </td>
                        <td style="width:25%;">
                            Variables
                        </td>
                        <td style="width:50%;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width:25%;">
                            <asp:DropDownList ID="ddlOperadores" runat="server" AutoPostBack="True" Width="220px"
                                onselectedindexchanged="ddlOperadores_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td style="width:25%;">
                        </td>
                        <td style="width:50%;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width:25%;">
                            <asp:listbox id="lstOperadores" runat="server" Width="220px" CssClass="etiqueta" Height="130px"></asp:listbox>
                        </td>
                        <td style="width:25%;">
                            <asp:listbox id="lstVariables" runat="server" Width="220px" CssClass="etiqueta" Height="130px"></asp:listbox>
                        </td>
                        <td style="width:50%;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width:100%; height:30px; vertical-align:middle;" align="center">
                            <asp:Label id="lblMensaje" runat="server" CssClass="etiqueta" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height:100px;" colspan="2">
                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%" style="height:100%">
                    <tr>
                        <td style="background-color:#F0C41B; height:100%;" align="center">
                            <asp:Button ID="btnGrabarFx" runat="server" Text="Grabar" 
                                onclick="btnGrabarFx_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= btnGrabarFx.ClientID %>").click(function() {
                return validar();
            });
        });

        function validar() {
            var formula = $.trim($("#<%= txtEditor.ClientID %>").val());
            var mensaje = '';

            if (formula == '')
                mensaje += "<li>La fórmula no puede estar en blanco.</li>";

            if (mensaje != '') {
                mensaje = '<ul>' + mensaje + '</ul>';
                jcAlert('Datos Incompletos', mensaje, function(choice) { return choice });
                return false;
            }

            jcConfirm('Actualizar Formula', '¿Desea actualizar la fórmula?', function(choice) {

                if (choice) {
                    var event = "<%= btnGrabarFx.ClientID %>";
                    event = event.replace(/_/g, "$");
                    __doPostBack(event, '');
                }
            });

            return false;
        }   
    </script>
</asp:Content>
