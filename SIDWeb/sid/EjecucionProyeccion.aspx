<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EjecucionProyeccion.aspx.cs" Inherits="sid.EjecucionProyeccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Proyección de pauta</h2>
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
                            Fecha a proyectar
                        </td>
                        <td>                            
                            <asp:Calendar ID="clnFecha" runat="server" 
                                onselectionchanged="clnFecha_SelectionChanged"></asp:Calendar>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
