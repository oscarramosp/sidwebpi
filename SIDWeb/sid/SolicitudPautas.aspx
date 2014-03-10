<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SolicitudPautas.aspx.cs" Inherits="sid.SolicitudPautas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function devolverCanilla(codigoCanilla, nombreCanilla) {
            document.getElementById("ctl00_ContentPlaceHolder2_txtCodigoCanilla").value = codigoCanilla;
            document.getElementById("ctl00_ContentPlaceHolder2_txtNombreCanilla").value = nombreCanilla;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Solicitud de pautas</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="smFiltros" runat="server">
    </asp:ScriptManager>
    <div class="form-group">
        <label for='<%=txtCodigoCanilla.ClientID%>' class="col-sm-2 control-label">Canilla</label>
        <div class="col-sm-3">
            <asp:TextBox ID="txtCodigoCanilla" runat="server" Width="100px" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-sm-5">
            <asp:TextBox ID="txtNombreCanilla" runat="server" Width="250px" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <button id="btnBuscar" type="button" class="btn btn-default"><i class="icon-ok"></i>Buscar</button>
		</div>
    </div>
    <asp:UpdatePanel ID="upSolicitudPauta" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#btnBuscar").click(function() {
                return abrirBusqueda();
            });
            function abrirBusqueda() {
                window.open("../ConsultaCanillas.aspx", "_blank", "toolbar=no, scrollbars=yes, resizable=1, top=500, left=500, width=870, height=400");
            }
            function devolverCanilla(codigoCanilla, nombreCanilla) {
                $("#<%= txtCodigoCanilla.ClientID %>").value = codigoCanilla;
                $("#<%= txtNombreCanilla.ClientID %>").value = nombreCanilla;
            }
        });
    </script>
</asp:Content>
