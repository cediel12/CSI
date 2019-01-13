<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="CrearBicicleta.aspx.cs" Inherits="CSI.Menu.CrearBicicleta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <link href="../../Estilos/styles.css" rel="stylesheet" />
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item active">Lista de Bicicletas            </li>
        </ul>
    </div>
    <div class="container" id="advanced-search-form">
        <h2>Crear Nueva Bicicleta</h2>
        <from>
            <div class="form-group">
                <label for="first-name">Nombre</label>
                <asp:TextBox ID="nombrebici" class="form-control" autocomplete="off" runat="server" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="number">Valor</label>
                <asp:TextBox ID="valor" class="form-control" autocomplete="off" runat="server" placeholder="Valor"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="first-name">Tipo de Bicicleta</label>
            <asp:DropDownList ID="eventos" class="form-control" AppendDataBoundItems="true" DataTextField="media_name" DataValueField="media_id" runat="server">
                <asp:ListItem>Tipo de Bicicleta</asp:ListItem>
            </asp:DropDownList>
        </div>
            <div class="clearfix"></div>
            <asp:Button ID="Button1" runat="server" EnableTheming="True" class="btn btn-info btn-lg btn-responsive" Text="Crear" OnClick="crear_bicicleta" />
                </from>
    </div>
</asp:Content>
