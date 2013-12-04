<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EjecucionProyeccion.aspx.cs" Inherits="sid.EjecucionProyeccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Proyección de pauta</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="smFiltros" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upCalendario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="form-group">
                <label for='<%=clnFecha.ClientID%>' class="col-sm-3 control-label">Código de fórmula</label>
                <div class="col-sm-9">
                    <asp:Calendar ID="clnFecha" runat="server" 
                        onselectionchanged="clnFecha_SelectionChanged"></asp:Calendar>
                </div>
            </div>
            <div class="form-group">
                <div id="spnMensaje" runat="server"></div>
            </div>
            <div class="form-group">
                <div class=" col-sm-offset-1 col-sm-11">
                    <div id="divResultado" runat="server">
                        <div style="overflow: auto; min-height:250px; max-height: 300px;">
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
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="clnFecha" EventName="SelectionChanged" />
            <asp:PostBackTrigger ControlID="btnProyectarPauta" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="form-group">
        <div class="col-sm-offset-5 col-sm-7">
            <asp:Button ID="btnProyectarPauta" runat="server" Text="Proyectar pauta" 
                onclick="btnProyectarPauta_Click" class="btn btn-default"/>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() {

        });
    </script>
</asp:Content>