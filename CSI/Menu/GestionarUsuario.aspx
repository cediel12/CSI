﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="GestionarUsuario.aspx.cs" Inherits="CSI.Menu.GestionarUsuario" %>

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
                <label for="number">Apellido</label>
                <asp:TextBox ID="apellido" class="form-control" autocomplete="off" runat="server" placeholder="Valor"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="first-name">Edad</label>
                <asp:TextBox ID="edad" class="form-control" autocomplete="off" runat="server" placeholder="Valor"></asp:TextBox>
        </div>
            <div class="clearfix"></div>
            <asp:Button ID="Button1" runat="server" EnableTheming="True" class="btn btn-primary" Text="Actualizar Datos" OnClick="Button1_Click" />
            <button type="button" data-toggle="modal" data-target="#myModal" class="btn btn-primary">Cambiar Contraseña</button>
       </from>
    </div>
    <div id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" class="modal fade text-left">
        <div role="document" class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 id="exampleModalLabel" class="modal-title">Tiempo de alquiler</h4>
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
