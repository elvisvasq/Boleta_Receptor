<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargaMasiva.aspx.cs" Inherits="CRUD_Sencillo.Vistas.CargaMasiva" %>

<!DOCTYPE html>
<html>
<head>
    <title>Cargar Gestiones Masivamente</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet">
</head>
<body>
    <main class="page payment-page">
        <section class="payment-form dark">
            <div class="container" style="background-color: #b3b3b3">
                <div class="block-heading align-content-center">
                    <h1 class="section__heading section_welcome__heading text-center">CARGA MASIVA</h1>
                    <asp:Label ID="LabelidR" runat="server" Visible="false" Text=""></asp:Label>
                </div>
                <form runat="server">
                    <div class="card-details">
                        <div class="row">
                            <div class="form-group col-sm-7">
                                <label for="card-holder">Responsable</label>
                                <asp:DropDownList ID="cbxResponsable" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cbxResponsable_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-5">
                                <label for="">Modificar Estado Judicial</label>
                                <div class="form-check">
                                    <asp:RadioButton ID="RBNo" runat="server" GroupName="EstadoJudicial" OnCheckedChanged="RBSi_CheckedChanged" AutoPostBack="True" />
                                    <label class="form-check-label" for="exampleRadios1">
                                        No
                                    </label>
                                </div>
                                <div class="form-check">
                                    <asp:RadioButton ID="RBSi" runat="server" GroupName="EstadoJudicial" OnCheckedChanged="RBSi_CheckedChanged" AutoPostBack="True" />
                                    <label class="form-check-label" for="exampleRadios2">
                                        Si
                                    </label>
                                </div>
                            </div>
                            <div class="form-group col-sm-7">
                                <asp:Label ID="lblEstadoJ" runat="server" Text="Estado Judicial" Visible="false"></asp:Label>
                                <asp:DropDownList ID="cbxEstadoJudicial" runat="server" CssClass="form-control" AutoPostBack="true" Visible="false"></asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-7">
                                <label for="card-holder">Arbol de Gestion</label>
                                <asp:DropDownList ID="cbxArbolGes" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cbxArbolGes_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                            <div class="form-group col-md-12">
                                <label for="cvc">Observacion</label>
                                <asp:TextBox ID="TextareaObs" runat="server" CssClass="form-control input-lg" MaxLength="200" TextMode="MultiLine" Columns="40" Rows="4" Text="Introduce comentarios aquí"></asp:TextBox>
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
                                <asp:Button ID="btnVolver" runat="server" Text="Volver" class="btn btn-danger btn-block" OnClick="btnVolver_Click" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </section>
    </main>
    <asp:GridView ID="GridVieworg" runat="server" Visible="false"></asp:GridView>
</body>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</html>
