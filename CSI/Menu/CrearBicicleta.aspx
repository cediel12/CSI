<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="CrearBicicleta.aspx.cs" Inherits="CSI.Menu.CrearBicicleta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <link href="../../Estilos/styles.css" rel="stylesheet" />

    <div class="container" id="advanced-search-form">
        <h2>Crear Nueva Bicicleta</h2>
        <from>
            <div class="form-group">
                <label for="first-name">Nombre</label>
                <asp:TextBox ID="nombrebici" class="form-control" Height="46" autocomplete="off" runat="server" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="number">Valor</label>
                <asp:TextBox ID="valor" class="form-control" Height="46" autocomplete="off" runat="server" placeholder="Valor"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="number">Talla</label>
                <asp:TextBox ID="talla" class="form-control" Height="46" autocomplete="off" runat="server" placeholder="Tipo"></asp:TextBox>
            </div>
             <div class="form-group">
                <label for="number">Unidades</label>
                <asp:TextBox ID="unidades" class="form-control" Height="46" autocomplete="off" runat="server" placeholder="Tipo"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="first-name">Tipo de Bicicleta</label>
                <asp:DropDownList ID="eventos" class="form-control" Height="46" AppendDataBoundItems="true" DataTextField="media_name" DataValueField="media_id" runat="server">
            </asp:DropDownList>
        </div>
            <div class="form-group">
                <label for="number">Imagen</label>
                <asp:FileUpload ID="fileupload1" runat="server" class="btn btn-primary btn-responsive" Width="150"/>
            </div>
            <div class="clearfix"></div>
            <asp:Button ID="Button1" runat="server" EnableTheming="True" class="btn btn-info btn-lg btn-responsive" Text="Crear" OnClick="crear_bicicleta" />
                </from>
    </div>
</asp:Content>
