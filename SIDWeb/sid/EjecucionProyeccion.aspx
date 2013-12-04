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
        <tr>
            <td style="height:30px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="width:15px">
            </td>
            <td>
                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblSinResultados" CssClass="strong" runat="server" Visible="false"></asp:Label>
                            <asp:GridView id="dgvPauta" runat="server" AutoGenerateColumns="False" Width="670px"
                                BorderColor="#ECECEC" BorderStyle="Solid" ShowHeader="true">
                                <Columns>
                                    <asp:BoundField DataField="codigoProducto" HeaderText="Código del producto">
                                        <ItemStyle HorizontalAlign="Center" Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="descripcionProducto" HeaderText="Nombre del producto">
                                        <ItemStyle HorizontalAlign="Left" Width="220px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cantidadSolicitada" HeaderText="Cantidad solicitada">
                                        <ItemStyle HorizontalAlign="Center" Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cantidadProyectada" HeaderText="Cantidad proyectada">
                                        <ItemStyle HorizontalAlign="Center" Width="150px"/>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>            
        </tr>
        <tr>
            <td style="height:30px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="height:100px;" colspan="2">
                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%" style="height:100%">
                    <tr>
                        <td style="background-color:#F0C41B; height:100%;" align="center">
                            <asp:Button ID="btnProyectarPauta" runat="server" Text="Proyectar pauta" 
                                onclick="btnProyectarPauta_Click"/>
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
