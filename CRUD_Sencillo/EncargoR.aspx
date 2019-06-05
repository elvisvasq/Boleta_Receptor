<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargoR.aspx.cs" Inherits="CRUD_Sencillo.EncargoR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Consulta Encargo a Receptor</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous" />
    <%--estiloajax--%>
     <style type="text/css">

         .modalBackground {
             background-color: Black;
             filter: alpha(opacity=90);
             opacity: 0.8;
         }

         .modalPopup {
             background-color: #fff;
             border: 3px solid #ccc;
             padding: 10px;
             width: 1081px;
         }
     </style>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#">
            <%--<img src="\Assets\Img\logonadal.jpg" height="70" width="70" class="d-inline-block align-top"/>--%>
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="http://192.168.0.100/roles/">Ingreso de Roles <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Ingreso de Boletas</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="http://192.168.0.100/maestro_receptores/">Maestro de Receptores</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Gestion
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="http://192.168.0.100/reportes/Pages/Folder.aspx?ItemPath=%2fGestiones+Diarias&ViewMode=List">Gestiones Diarias</a>
                        <a class="dropdown-item" href="http://192.168.0.100/reportes/Pages/Report.aspx?ItemPath=%2fGestiones+Diarias%2fGestiones_Diarias_Detalle">Gestiones, busqueda por telefonica</a>
                        <a class="dropdown-item" href="http://192.168.0.100/reportes/Pages/Folder.aspx?ItemPath=%2fInforme+CMR+Falabella&ViewMode=List">Informe CMR Falabella</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="http://192.168.0.100/reportes/Pages/Folder.aspx?ItemPath=%2fComercial&ViewMode=List">Recaudo Falabella</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
    <hr />
    <form id="form1" runat="server" style="text-decoration-color: black">
        <div class="container" style="background-color: #b3b3b3">
            <h1 class="section__heading section_welcome__heading text-center">CONSULTA DEUDA
                <p><asp:Label ID="lblMandante" runat="server"></asp:Label></p>
                <i class="fas fa-balance-scale fa-2x"></i>
            </h1>
            <hr />
            <div class="row">
                <asp:Label ID="Label0" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Labelidm" runat="server" Visible="false"></asp:Label>
                <div class="col-xs-6 col-md-4">
                    <asp:DropDownList ID="cbxmandante" class="btn btn-primary" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cbxmandante_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-6 col-md-4">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="col-xs-6 col-md-4 col-sm-offset-4">
                    <div class="text-right">
                        <asp:Button ID="btncargarxls" runat="server" Text="Procesar" class="btn btn-danger" OnClick="btnCargaExcel_Click" />
                        <asp:Button ID="btnNewConsulta" runat="server" Text="Nueva Consulta" class="btn btn-info"  Visible="false" OnClick="btnNewConsulta_Click" />
                    </div>
                </div>
            </div>
            <br />
        </div>
        <div class="container">
            <div class="row align-items-center">
                <div class="col">
                    <br />
                    <%--<asp:Button ID="btncargamasiva" runat="server" Text="Carga Masiva" data-target="#myModal" data-toggle="modal" class="btn btn-info" OnClientClick="javascript:return false;" Visible="false" />--%>
                    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                    <br />
                    <asp:Button ID="btncargamasiva" runat="server" Text="Carga Masiva" class="btn btn-info" Visible="false"  />
                    <br />
                </div>
                <div class="col">
                    <div class="text-right">
                        <br />
                        <asp:Button ID="btnGuardarExcel" runat="server" Text="Guardar en Excel" class="btn btn-dark" OnClick="btnGuardarExcel_Click1" Visible="true" />
                        <br />
                    </div>
                </div>
            </div>
        </div>
        <cc1:ModalPopupExtender ID="btnPopUp_ModalPopupExtender" runat="server" TargetControlID="btncargamasiva" CancelControlID="btnVolver" BackgroundCssClass="modalBackground" PopupControlID="PanelModal">
        </cc1:ModalPopupExtender>
        <!-- Modal -->
        <asp:Panel ID="PanelModal" runat="server" Style="display: none">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>                    
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="block-heading align-content-center">
                                    <h1 class="section__heading section_welcome__heading text-center">CARGA MASIVA</h1>
                                    <asp:Label ID="LabelidR" runat="server" Visible="false" Text=""></asp:Label>
                                    <asp:Label ID="LabelIdEstadoJ" runat="server" Visible="false" Text=""></asp:Label>
                                    <asp:Label ID="LabelIdArbol" runat="server" Visible="false" Text=""></asp:Label>
                                    <hr />
                                </div>
                                <div class="card-details">
                                    <div class="row">
                                        <div class="form-group col-sm-7">
                                            <label for="card-holder">Responsable</label>
                                            <asp:DropDownList ID="cbxResponsable" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cbxResponsable_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-sm-5">
                                            <label for="">Modificar Estado Judicial</label>
                                            <div class="form-check">
                                                <asp:RadioButton ID="RBNo" runat="server" GroupName="EstadoJudicial" OnCheckedChanged="RBSi_CheckedChanged" AutoPostBack="true" />
                                                <label class="form-check-label" for="exampleRadios1">
                                                    No
                                                </label>
                                            </div>
                                            <div class="form-check">
                                                <asp:RadioButton ID="RBSi" runat="server" GroupName="EstadoJudicial" OnCheckedChanged="RBSi_CheckedChanged" AutoPostBack="true" />
                                                <label class="form-check-label" for="exampleRadios2">
                                                    Si
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group col-sm-7">
                                            <asp:Label ID="lblEstadoJ" runat="server" Text="Estado Judicial" Visible="false"></asp:Label>
                                            <asp:DropDownList ID="cbxEstadoJudicial" runat="server" CssClass="form-control" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="cbxEstadoJudicial_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-sm-7">
                                            <label for="card-holder">Arbol de Gestion</label>
                                            <asp:DropDownList ID="cbxArbolGes" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cbxArbolGes_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-12">
                                            <label for="cvc">Observacion</label>
                                            <asp:TextBox ID="TextareaObs" runat="server" CssClass="form-control input-lg" MaxLength="200" TextMode="MultiLine" Columns="40" Rows="4" placeholder="Introduce comentarios aquí"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-12">
                                            <asp:Label ID="lblError" runat="server" Visible="false" Class="control-label"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblError3" runat="server" Visible="false" Class="control-label"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblError4" runat="server" Visible="false" Class="control-label"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblError2" runat="server" Visible="false" Class="control-label"></asp:Label>
                                            <br />
                                            <asp:Button ID="btnGrabar" runat="server" Text="Grabar Masivo" CssClass="btn btn-primary btn-block" OnClick="btnGrabar_Click" />
                                        </div>
                                        <div class="form-group col-sm-12">
                                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-success btn-block" OnClick="btnVolver_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

    </form>
    <br />
    <div class="container-fluid justify-content-center">
        <div class="row justify-content-center">
            <br />
            <asp:GridView ID="GridView2" runat="server" ConvertEmptyStringToNull="true" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="auto-style1" Style="font-size: small">
                <Columns>
                    <asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="true" SortExpression="Rut" />
                    <asp:BoundField DataField="Pagare" HeaderText="Pagare" ReadOnly="true" />
                    <asp:BoundField DataField="Folio" HeaderText="Folio" ReadOnly="true" />
                    <asp:BoundField DataField="Estado Actual GNA" HeaderText="Estado Actual GNA" ReadOnly="true" />
                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha Vencimiento" ReadOnly="true" />
                    <asp:BoundField DataField="ÚltimoDeFechaPago" HeaderText="Último De FechaPago" ReadOnly="true" />
                    <asp:BoundField DataField="SaldoInicial" HeaderText="Saldo Inicial" ReadOnly="true" />
                    <asp:BoundField DataField="Pagos" HeaderText="Pagos" ReadOnly="true" />
                    <asp:BoundField DataField="SaldoDeuda" HeaderText="Saldo Deuda" ReadOnly="true" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" ReadOnly="true" />
                    <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" ReadOnly="true" />
                    <asp:BoundField DataField="tribunal Costas" HeaderText="Tribunal" ReadOnly="true" />
                    <asp:BoundField DataField="rol costas" HeaderText="Rol" ReadOnly="true" />
                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" ReadOnly="true" />
                    <asp:BoundField DataField="Acción" HeaderText="Acción" ReadOnly="true" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </div>


    <asp:GridView ID="GridView1" runat="server" Visible="false">
    </asp:GridView>
    <script src="Assets/js/CargaMasiva.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>
