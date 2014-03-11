<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SolicitudPautas.aspx.cs" Inherits="sid.SolicitudPautas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function devolverCanilla(codigoCanilla, nombreCanilla) {
            document.getElementById("ctl00_ContentPlaceHolder2_txtCodigoCanilla").value = codigoCanilla;
            document.getElementById("ctl00_ContentPlaceHolder2_txtNombreCanilla").value = nombreCanilla;
            document.getElementById('ctl00_ContentPlaceHolder2_btnGenerarEvento').click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Solicitud de pautas</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="smFiltros" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upSolicitudPauta" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="form-group">
                <label for='<%=txtCodigoCanilla.ClientID%>' class="col-sm-2 control-label">Canilla</label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtCodigoCanilla" runat="server" Width="100px" 
                        CssClass="form-control" Enabled="false" ontextchanged="txtCodigoCanilla_TextChanged"></asp:TextBox>
                    <asp:Button CssClass="no-display" ID="btnGenerarEvento" runat="server" useSubmitBehavior="false"/>
                </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtNombreCanilla" runat="server" Width="350px" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <button id="btnBuscar" type="button" class="btn btn-default">
                        <span class="glyphicon glyphicon-search"></span>
                    </button>
		        </div>
            </div>
            <div class="form-group">
                <label for='<%=clnFecha.ClientID%>' class="col-sm-3 control-label">Fecha a de solicitud</label>
                <div class="col-sm-9">
                    <asp:Calendar ID="clnFecha" runat="server" 
                        onselectionchanged="clnFecha_SelectionChanged" ></asp:Calendar>
                    <!-- <asp:TextBox ID="txtFechaProyeccion" runat="server" Width="100" CssClass="classInput" MaxLength="10"></asp:TextBox> -->
                </div>
            </div>
            <div class="form-group">
                <div class=" col-sm-offset-1 col-sm-11">
                    <div id="divResultado" runat="server">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div id="spnMensaje" runat="server"></div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="clnFecha" EventName="SelectionChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnGenerarEvento" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnSolicitarPauta" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="form-group">
        <div class="col-sm-offset-5 col-sm-7">
            <asp:Button ID="btnSolicitarPauta" runat="server" Text="Solicitar pauta" 
                class="btn btn-default" onclick="btnSolicitarPauta_Click"/>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#btnBuscar").click(function() {
                return abrirBusqueda();
            });
            function abrirBusqueda() {
                window.open("../ConsultaCanillas.aspx", "_blank", "toolbar=no, scrollbars=yes, resizable=0, top=500, left=500, width=870, height=400");
            }
        });
    </script>
</asp:Content>
