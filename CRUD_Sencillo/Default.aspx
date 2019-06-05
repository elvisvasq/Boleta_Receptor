<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD_Sencillo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingresa_Boletas</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <%--<link href="Assets/css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <link href="Assets/css/Micss.css" rel="stylesheet" />--%>
    <%--   <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />--%>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="Scripts/combobox.js"></script>

    <script src="Assets/js/jquery-ui.min.js"></script>
    <script src="Assets/js/bootstrap.min.js"></script>

    <style>
        .custom-combobox {
            position: relative;
            display: inline-block;
        }

        .custom-combobox-toggle {
            position: absolute;
            top: 0;
            bottom: 0;
            margin-left: -1px;
            padding: 0;
        }

        .custom-combobox-input {
            margin: 0;
            padding: 5px 5px;
        }
    </style>


</head>
<body>

    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">

                <a class="navbar-brand" href="#">
                    <img src="Logos/logonadal.png" height="50" width="50" />
                </a>
            </div>
            <ul class="nav navbar-nav">

                <li class="active"><a href="#">Home</a></li>

                <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Judicial<span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="http://192.168.0.100/roles/" id="ingrol">Ingreso de Roles</a></li>
                        <li><a href="#">Ingreso de Boletas</a></li>
                        <li><a href="#">Ingreso Encargo Receptor</a></li>
                    </ul>
                </li>
                <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Gestion<span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="http://192.168.0.100/reportes">Gestiones Diarias</a></li>
                        <li><a href="#">Gestiones, busqueda por telefonica</a></li>
                        <li><a href="#">Informe CMR Falabella</a></li>
                        <li><a href="#">Envio SMS</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav navbar-nav navbar-right">

                <%--      <li><a href="#"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>
      <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>--%>
            </ul>
        </div>
    </nav>


    <form id="form1" runat="server" style="text-decoration-color: black">
        <div class="container">
            <div class="row">
                <div class="col-md-12" style="background-color: #b3b3b3">
                    <div class="well">
                        <h2>Boletas Receptor</h2>
                        <hr />
                        <p>
                            <asp:Label ID="LblGuardar" runat="server"></asp:Label>
                            <asp:Label ID="Labelidm" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label0" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label7" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label8" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
                        </p>
                        <p>
                            <asp:Label class="glyphicon glyphicon-user" Text="Responsable" runat="server" />
                            <asp:DropDownList ID="cbxusuario" class="btn btn-primary" runat="server" Style="margin-right: 15px" Visible="True" Width="220px"></asp:DropDownList>
                            <asp:Label Text="Cargo" runat="server" />
                            <asp:DropDownList ID="cbxcargo" class="btn btn-primary" runat="server" Style="margin-left: 1px" Visible="True" Width="220px">
                                <asp:ListItem Value="Seleccione Cargo"> Seleccione Cargo </asp:ListItem>
                                <asp:ListItem Value="Abogada"> Abogada </asp:ListItem>
                                <asp:ListItem Value="Asistente Adm."> Asistente Adm. </asp:ListItem>
                                <asp:ListItem Value="Procurador Jud."> Procurador Jud. </asp:ListItem>
                                <asp:ListItem Value="Administrador Jud."> Administrador Jud. </asp:ListItem>
                            </asp:DropDownList>
                        </p>
                        <p>
                            <asp:Label Text="Mandante" runat="server" Style="margin-right: 20px" />
                            <asp:DropDownList ID="cbxmandante" class="btn btn-primary" runat="server" Style="margin-right: 20px" Visible="True" Width="220px" OnTextChanged="cbxmandante_TextChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:Label Text="Receptor" runat="server" />
                            <asp:TextBox ID="Textbox1" runat="server" class="btn btn-primary" Width="220px" AppendDataBoundItems="True" AutoPostBack="True" Style="margin-left: 25px"></asp:TextBox>

                        </p>
                        <h4>Digite Rut a buscar o importe excel con rut masivos a consultar</h4>
                        <asp:Label Text="Rut" runat="server" />
                        <asp:TextBox ID="TxtNombre" runat="server" class="btn btn-primary" Style="margin-left: 65px" Width="220px" OnTextChanged="TxtNombre_TextChanged"></asp:TextBox>
                        <hr />
                        <p>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="btncargarxls" runat="server" Text="Cargar" OnClick="btncargarxls_Click" class="btn btn-primary" Style="top: 100px" />
                        </p>
                        <hr />
                        <p>
                            <asp:GridView ID="GridView2" runat="server" Height="200px" Width="1081px" ConvertEmptyStringToNull="true" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" GridLines="None" Font-Size="XX-Small" ForeColor="Black" AutoGenerateColumns="false">

                                <Columns>
                                    <asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="true" SortExpression="Rut" />
                                    <asp:BoundField DataField="Nombremandante" HeaderText="Mandante" ReadOnly="true" />
                                    <asp:BoundField DataField="Pagare" HeaderText="Operacion" ReadOnly="true" />
                                    <asp:BoundField DataField="rol" HeaderText="Rol" ReadOnly="true" />
                                    <asp:BoundField DataField="Facultad" HeaderText="Oficina" ReadOnly="true" />
                                    <asp:BoundField DataField="Fecha_Ultimo_Pago" HeaderText="Ultimo Pago" ReadOnly="true" />
                                    <asp:BoundField DataField="Monto_ultimo_abono" HeaderText="Ultimo Abono" ReadOnly="true" />
                                    <asp:BoundField DataField="Saldo_Inicial" HeaderText="Saldo" ReadOnly="true" />
                                    <asp:BoundField DataField="Total_pagado" HeaderText="Total Cancelado" ReadOnly="true" />
                                    <asp:BoundField DataField="Total_adeudado" HeaderText="Total Adeudado" ReadOnly="true" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ReadOnly="true" />
                                    <asp:BoundField DataField="Tribunales" HeaderText="Tribunal" ReadOnly="true" />

                                </Columns>

                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                        </p>

                        <%--  <p>
                            <asp:Label ID="Label10" runat="server" Text="Marque los rut a ingresar" visible="false"></asp:Label>
                            <asp:CheckBoxList ID="chbxprocesar" runat="server" TextAlign="Left" CellPadding="2" CellSpacing="2" >
                            </asp:CheckBoxList>
                             
                        </p>--%>
                        <p>
                            <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-primary" Text="Buscar Registro" OnClick="BtnGuardar_Click" />
                            <asp:Button ID="BtnGrabar" runat="server" CssClass="btn btn-primary" Text="Grabar Gestion" OnClick="BtnGrabar_Click" />
                        </p>
                        <br />
                    </div>

                    <div class="col-sm-6">

                        <h4>Cruce De boleta</h4>
                        <hr />
                        <asp:GridView ID="GridView1" runat="server" Height="192px" Width="1026px" ConvertEmptyStringToNull="true" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" GridLines="None" PageSize="12" Font-Size="Smaller" AutoGenerateColumns="False" ForeColor="Black">
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <Columns>
                                <asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="true" SortExpression="Rut" />
                                <asp:BoundField DataField="nombre" HeaderText="Deudor" ReadOnly="true" />
                                <asp:BoundField DataField="Operacion" HeaderText="Operacion" ReadOnly="true" />
                                <asp:BoundField DataField="cuantia" HeaderText="Cuantia" ReadOnly="true" />
                                <asp:BoundField DataField="tribunal" HeaderText="Tribunal" ReadOnly="true" />
                                <asp:BoundField DataField="ROL" HeaderText="Rol" ReadOnly="true" />
                                <asp:BoundField DataField="diligencia" HeaderText="Diligencia" ReadOnly="true" />
                                <asp:BoundField DataField="Fecha_Dilig" HeaderText="Fecha Diligencia" ReadOnly="true" />
                                <asp:BoundField DataField="Monto_dilig" HeaderText="Monto Diligencia" ReadOnly="true" />
                                <asp:TemplateField HeaderText="Excluir">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblcheck" runat="server" Text="Excluir" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbxprocesar" runat="server" Checked="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                        </asp:GridView>
                    </div>












                </div>
            </div>
        </div>
    </form>
</body>
</html>
