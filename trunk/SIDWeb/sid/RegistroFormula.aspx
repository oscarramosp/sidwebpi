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
            <td style="height:350px;">
                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                    <tr>
                        <td style="width:25%;">
                            asd
                        </td>
                        <td style="width:25%;">
                            asd
                        </td>
                    </tr>
                    <tr>
                        <td style="width:25%;">
                            asd
                        </td>
                        <td style="width:25%;">
                            asd
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
                            <asp:Button ID="btnGrabarFx" runat="server" Text="Grabar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(document).ready(function() {

        });        
    </script>
</asp:Content>
