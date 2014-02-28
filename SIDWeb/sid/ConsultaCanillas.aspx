<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaCanillas.aspx.cs" Inherits="sid.ConsultaCanillas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SID</title>
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/util.js"></script>
    <script type="text/javascript" src="js/moog.custom.alert.js"></script>
    <script type="text/javascript" src="js/sidd.js"></script>
    <link href="css/jquery-ui.css" rel="Stylesheet"/>
    <link href="css/custom.css" rel="Stylesheet"/>
    <link href="css/bootstrap.min.css" rel="Stylesheet"/>
    <link href="css/bootstrap-theme.min.css" rel="Stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" role="form">
    <div class="container bs-docs-container">
        <div class="row">
            <div class="col-md-12" role="main">
                <fieldset>
                    <legend>Conuslta de Canillas</legend>
                    <div class="form-group">
                        <label for='<%=txtCodigoCanilla.ClientID%>' class="col-sm-2 control-label">Código de Canilla</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtCodigoCanilla" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label for='<%=txtNombreCanilla.ClientID%>' class="col-sm-2 control-label">Nombre del Canilla</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtNombreCanilla" runat="server" Width="460px" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for='<%=ddlTipoDocumento.ClientID%>' class="col-sm-2 control-label">Tipo de documento</label>
                        <div class="col-sm-3">
							<asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="150px" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <label for='<%=txtNumeroDocumento.ClientID%>' class="col-sm-2 control-label">Número de documento</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                        </div>
						<div class="col-sm-1">
							<asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-default"/>
						</div>
                    </div>
                </fieldset>
                <div class="form-group">
                    <div class="col-sm-12">
                        <div id="divResultado" runat="server">
                            <div style="overflow: auto; min-height:185px; max-height: 250px;">
                                <asp:GridView id="dgvCanillas" runat="server" AutoGenerateColumns="False" Width="670px"
                                    BorderColor="#ECECEC" BorderStyle="Solid" ShowHeader="true">
                                    <Columns>
                                        <asp:BoundField DataField="codigoCanilla" HeaderText="Código del canilla">
                                            <ItemStyle HorizontalAlign="Center" Width="150px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nombreCompletoCanilla" HeaderText="Nombre del canilla">
                                            <ItemStyle HorizontalAlign="Left" Width="220px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="documento.tipoDocumento" HeaderText="Tipo documento">
                                            <ItemStyle HorizontalAlign="Left" Width="150px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="documento.numeroDocumento" HeaderText="Número documento">
                                            <ItemStyle HorizontalAlign="Left" Width="150px"/>
                                        </asp:BoundField>
									    <asp:BoundField DataField="agencia.nombreAgencia" HeaderText="Agencia">
                                            <ItemStyle HorizontalAlign="Left" Width="150px"/>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div id="spnMensaje" runat="server"></div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
