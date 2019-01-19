<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="GestionarUsuarioAdmin.aspx.cs" Inherits="CSI.Menu.GestionarUsuarioAdmin" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <link href="../../Estilos/styles.css" rel="stylesheet" />
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item active">Gestionar Usuario</li>
        </ul>
    </div>
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
                </from>
    </div>
</asp:Content>
