<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="ListaBicicletas.aspx.cs" Inherits="CSI.Menu.ListaBicicletas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/Tabla/css/lib/datatable/dataTables.bootstrap.min.css" rel="stylesheet" />

    <%--<div class="content mt-3">
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
    </div>--%>
    <div class="page">
        <div class="page-content d-flex align-items-stretch">
            <div class="content-inner">
                <section class="client no-padding-top">
                    <div class="container-fluid">
                        <div class="row">
                            <!-- Client Profile -->
                            <%for (int a = 0; a < todo.Rows.Count; a++)
                                {
                                    drtodo = todo.Rows[a];
                                    Session["nombrebici"] = drtodo["nombre_bicicleta"].ToString();
                                    Session["talla"] = drtodo["talla"].ToString();
                                    Session["valor_bicicleta"] = drtodo["valor_bicicleta"].ToString();
                                    Session["nombre_tipo_bicicleta"] = drtodo["nombre_tipo_bicicleta"].ToString();
                                    Session["imagen"] = "../../scr/" + drtodo["imagen"].ToString();
                                    Session["id_bicicleta"] = drtodo["id_bicicleta"].ToString();
                                    
                            %>
                            <div class="col-lg-4">
                                <div class="client card">
                                    <div class="card-close">
                                        <div class="dropdown">
                                            <button type="button" id="closeCard2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-toggle"><i class="fa fa-ellipsis-v"></i></button>
                                            <div aria-labelledby="closeCard2" class="dropdown-menu dropdown-menu-right has-shadow"><a href="#" class="dropdown-item remove"><i class="fa fa-times"></i>Close</a><a href="#" class="dropdown-item edit"> <i class="fa fa-gear"></i>Edit</a></div>
                                        </div>
                                    </div>
                                    <div class="card-body text-center">
                                        <div class="client-avatar">
                                            <img src="<%=Session["imagen"].ToString() %>" class="img-fluid rounded-circle">
                                            <div class="status bg-green"></div>
                                        </div>
                                        <div class="client-title">
                                            <h3><%=Session["nombrebici"].ToString() %></h3>
                                            <span>$ <%=Session["valor_bicicleta"].ToString() %> / Dia</span>
                                            <% if (Session["rol"].ToString() == "Empresa")
                                                {
                                            %>
                                            <%--<button type="button" runat="server" id="modificar" class="btn btn-primary" title="Modificar">Alquilar</button>--%>
                                            <asp:Button ID="Button1" OnClientClick="postback false;" runat="server" EnableTheming="True" class="btn btn-info btn-lg btn-responsive" Text="Alquilar" OnClick="Button1_Click" />

                                            <%}
                                                else
                                                {%>
                                            <button type="button" runat="server" id="alquilar" class="btn btn-primary" onserverclick="Button1_Click" title="Alquilar">Alquilar</button>
                                            <asp:Button ID="Button2" runat="server" EnableTheming="True" class="btn btn-info btn-lg btn-responsive" Text="Reservar" OnClick="Button1_Click" />

                                            <%Button2.ID = Session["id_bicicleta"].ToString();
                                                } %>
                                        </div>
                                        <div class="client-info">
                                            <div class="row">
                                                <div class="col-4">
                                                    <strong>Tipo</strong><br>
                                                    <span><%=Session["nombre_tipo_bicicleta"].ToString() %></span>
                                                </div>
                                                <div class="col-4">
                                                    <strong>Talla</strong><br>
                                                    <span><%=Session["talla"].ToString() %></span>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <%
                                } %>
                        </div>
                    </div>
                </section>
            </div>
        </div>
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
