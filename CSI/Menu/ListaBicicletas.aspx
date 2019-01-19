﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="ListaBicicletas.aspx.cs" Inherits="CSI.Menu.ListaBicicletas" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/Tabla/css/lib/datatable/dataTables.bootstrap.min.css" rel="stylesheet" />
    <div class="breadcrumb-holder container-fluid">
        <ul class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item active">Lista de Bicicletas            </li>
        </ul>
    </div>
    <div class="content mt-3">
        <div class="animated fadeIn">
            <div class="row">

                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Bicicletas</strong>
                        </div>
                        <div class="card-body">
                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th class="th-lg"><a>Nombre</a></th>
                                        <th class="th-lg"><a>Estado</a></th>
                                        <th class="th-lg"><a>Tipo</a></th>
                                        <th class="th-lg"><a>Valor/Dia</a></th>
                                        <th class="th-lg"><a>Empresa</a></th>
                                        <%if (Session["rol"].ToString() == "Cliente")
                                            {
                                        %>
                                        <th class="th-lg"><a>Alquilar</a></th>
                                        <%
                                            }
                                        %>
                                        <%
                                            if (Session["rol"].ToString() == "Empresa")
                                            {
                                        %>
                                        <th class="th-lg"><a>Eliminar Bicicleta</a></th>
                                        <th class="th-lg"><a>Modificar Bicicleta</a></th>
                                        <%
                                            }
                                        %>
                                    </tr>
                                </thead>
                                <!--Table head-->

                                <!--Table body-->
                                <tbody>
                                    <asp:ListView runat="server" ID="lista">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("nombre_bicicleta") %></td>
                                                <td><%#Eval("estado_bicicleta") %></td>
                                                <td><%#Eval("nombre_tipo_bicicleta") %></td>
                                                <td>$ <%#Eval("valor_bicicleta") %></td>
                                                <td><%#Eval("nombre_empresa") %></td>

                                                <td>
                                                    <%if (Session["rol"].ToString() == "Cliente")
                                                        {
                                                    %>
                                                    <asp:LinkButton runat="server" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta") %>' CommandName="registrar">
                                            Alquilar
                                                    </asp:LinkButton>
                                                    <%
                                                        }
                                                    %>
                                                    <%
                                                        if (Session["rol"].ToString() == "Empresa")
                                                        {
                                                    %>
                                                    <asp:LinkButton runat="server" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta") %>' CommandName="eliminar">
                                            Eliminar
                                                    </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton runat="server" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta") %>' CommandName="modificar">
                                            Modificar
                                                    </asp:LinkButton>
                                                </td>
                                                <%
                                                    }
                                                %>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- .animated -->
    </div>
    <!-- .content -->
    <script src="../Estilos/Tabla/js/lib/data-table/datatables.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/dataTables.bootstrap.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/dataTables.buttons.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/buttons.bootstrap.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/jszip.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/pdfmake.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/vfs_fonts.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/buttons.html5.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/buttons.print.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/buttons.colVis.min.js"></script>
    <script src="../Estilos/Tabla/js/lib/data-table/datatables-init.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#bootstrap-data-table-export').DataTable();
        });
    </script>
</asp:Content>
