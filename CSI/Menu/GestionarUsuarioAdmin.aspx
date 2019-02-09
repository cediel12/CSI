<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="GestionarUsuarioAdmin.aspx.cs" Inherits="CSI.Menu.GestionarUsuarioAdmin" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <link href="../../Estilos/styles.css" rel="stylesheet" />
    
    <div class="container" id="advanced-search-form">
        <h2>Gestionar Usuario</h2>
        <from>
            <div class="form-group">
                <label for="first-name">Nombre</label>
                <asp:TextBox ID="nombre" class="form-control" autocomplete="off" runat="server" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="first-name">Telefono</label>
                <asp:TextBox ID="telefono" class="form-control" autocomplete="off" runat="server" placeholder="Valor"></asp:TextBox>
        </div>
            <div class="clearfix"></div>
            <asp:Button ID="Button1" runat="server" EnableTheming="True" class="btn btn-info btn-lg btn-responsive" Text="Actualizar Datos" OnClick="Button1_Click" />
            <button type="button" data-toggle="modal" data-target="#myModal" class="btn btn-primary">Cambiar Contraseña</button>
                </from>
    </div>
    <div id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" class="modal fade text-left">
        <div role="document" class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 id="exampleModalLabel" class="modal-title">Cambiar Contraseña</h4>
                    <button type="button" data-dismiss="modal" aria-label="Close" class="close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    
                        <div class="form-group">
                            <label for="number">Contraseña Actual</label>
                            <asp:TextBox TextMode="Password" ID="passold" class="form-control" autocomplete="off" runat="server" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="number">Nueva Contraseña</label>
                            <asp:TextBox TextMode="Password" ID="passnew" class="form-control" autocomplete="off" runat="server" ></asp:TextBox>
                        </div>
                    
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-secondary">Close</button>
                    <asp:Button ID="button4" Text="Cambiar Contraseña" OnClick="button4_Click" runat="server" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>