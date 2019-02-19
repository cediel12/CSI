<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="CrearEvento.aspx.cs" Inherits="CSI.Menu.CrearEvento" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <link href="../../Estilos/styles.css" rel="stylesheet" />
    
    <div class="container" id="advanced-search-form">
        <h2>Crear Nueva Evento</h2>
        <from>
            <div class="form-group">
                <label for="first-name">Nombre Evento</label>
                <asp:TextBox ID="nombreevento" class="form-control" required="required" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="number">Fecha</label>
                <asp:TextBox ID="fechafin" class="form-control" required="required" runat="server" Height="46" TextMode="Date" ></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="number">Hora</label>
                <asp:TextBox ID="hora" class="form-control" required="required" runat="server" Height="46"  TextMode="Time"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="first-name">Lugar</label>
                <asp:TextBox ID="lugar" class="form-control" required="required" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="first-name">Descripción</label>
                <asp:TextBox ID="descripcion" class="form-control" required="required"  Height="46" autocomplete="off" runat="server" placeholder="Descripción" ></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" EnableTheming="True" class="btn btn-info btn-lg btn-responsive" Text="Crear" OnClick="crear_evento" />
                </from>
    </div>
</asp:Content>
