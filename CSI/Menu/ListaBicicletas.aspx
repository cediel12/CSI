<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="ListaBicicletas.aspx.cs" Inherits="CSI.Menu.ListaBicicletas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/Tabla/css/lib/datatable/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
    <div class="page">
        <div class="page-content d-flex align-items-stretch">
            <div class="content-inner">
                <section class="client no-padding-top">
                    <div class="container-fluid">
                        <div class="row">
                            <!-- Client Profile -->
                            <asp:Repeater ID="rep" runat="server">
                                <ItemTemplate>
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
                                                    <img src='../../scr/<%#Eval("imagen")%>' class="img-fluid rounded-circle">
                                                    <div class="status bg-green"></div>
                                                </div>
                                                <div class="client-title">
                                                    <h3><%#Eval("nombre_bicicleta")%></h3>
                                                    <span>$ <%#Eval("valor_bicicleta")%> / Hora</span>
                                                    <% if (Session["rol"].ToString() == "Empresa")
                                                        {
                                                    %>
                                                    <asp:LinkButton runat="server" data-target="#myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta")%>' CommandName="registrar">
                                            Modificar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" data-target="#myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta")%>' CommandName="registrar">
                                            Eliminar
                                                    </asp:LinkButton>
                                                    <%}
                                                        else
                                                        {%>
                                                    <asp:LinkButton runat="server" data-target="#myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta")%>' CommandName="registrar">
                                            Reservar
                                                    </asp:LinkButton>
                                                    <%
                                                        } %>
                                                </div>
                                                <div class="client-info">
                                                    <div class="row">
                                                        <div class="col-4">
                                                            <strong>Tipo</strong><br>
                                                            <span><%#Eval("nombre_tipo_bicicleta") %></span>
                                                        </div>
                                                        <div class="col-4">
                                                            <strong>Talla</strong><br>
                                                            <span><%#Eval("talla") %></span>
                                                        </div>
                                                        <div class="col-4">
                                                            <strong>Cant</strong><br>
                                                            <span><%#Eval("cantidad") %></span>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <div id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" class="modal fade text-left">
        <div role="document" class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 id="exampleModalLabel" class="modal-title">Tiempo de alquiler</h4>
                    <button type="button" data-dismiss="modal" aria-label="Close" class="close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <p>Seleccione fecha de inicio y fin del alquiler.</p>
                    <form>
                        <div class="form-group">
                            <label for="number">Fecha Inicio</label>
                            <asp:TextBox ID="fechainicio" class="form-control" runat="server" Height="46" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="number">Cantidad de horas</label>
                            <asp:DropDownList ID="eventos" class="form-control" AppendDataBoundItems="true" DataTextField="media_name" DataValueField="media_id" runat="server">
                                <asp:ListItem Value="4">4 Horas</asp:ListItem>
                                <asp:ListItem Value="8">8 Horas</asp:ListItem>
                                <asp:ListItem Value="12">12 Horas</asp:ListItem>
                                <asp:ListItem Value="24">1 Dia</asp:ListItem>
                                <asp:ListItem Value="48">2 Dias</asp:ListItem>
                                <asp:ListItem Value="72">3 Dias</asp:ListItem>
                                <asp:ListItem Value="120">5 Dias</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="number">Cantidad de Bicicletas</label>
                            <asp:DropDownList ID="cantidadalqui" class="form-control" AppendDataBoundItems="true" DataTextField="media_name" DataValueField="media_id" runat="server">
                            </asp:DropDownList>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-secondary">Close</button>
                    <asp:Button ID="button4" Text="Realizar Alquiler" runat="server" OnClick="button4_Click" class="btn btn-primary" />
                </div>
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
