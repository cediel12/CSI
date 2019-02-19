<%@ Page Title="" Language="C#" validateRequest="false" enableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="CrearTipoBicicleta.aspx.cs" Inherits="CSI.Menu.CrearTipoBicicleta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <link href="../../Estilos/styles.css" rel="stylesheet" />

    <div class="container" id="advanced-search-form">
        <h2>Crear Nueva Tipo Bicicleta</h2>
        <from>
            <div class="form-group">
                <label for="first-name">Tipo</label>
                <asp:TextBox ID="tipo" class="form-control" Height="55" autocomplete="off" runat="server" required="required" placeholder="Tipo"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="number">Descripción</label>
                <asp:TextBox ID="descripcion" class="form-control" Height="55" Width="450" TextMode="MultiLine" required="required" autocomplete="off" runat="server" placeholder="Descripcion"></asp:TextBox>
            </div>
            <div class="clearfix"></div>
            <asp:Button ID="Button1" runat="server" EnableTheming="True" class="btn btn-info btn-lg btn-responsive" Text="Crear" OnClick="crear_tipo" />
        </from>
    </div>
</asp:Content>
