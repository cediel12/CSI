<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="ListaBicicletas.aspx.cs" Inherits="CSI.Menu.ListaBicicletas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/Tabla/css/lib/datatable/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
        function opendescripcionbici() {
            $('#descripcionbici').modal('show');
        }
        function modibici() {
            $('#modibicicleta').modal('show');
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
                                            <div class="card-body text-center">
                                                <div class="client-avatar">
                                                    <img src='../../scr/<%#Eval("imagen")%>' class="img-fluid rounded-circle">
                                                    <div class="status bg-green"></div>
                                                </div>
                                                <div class="client-title">
                                                    <h3><%#Eval("nombre_bicicleta")%></h3>
                                                    <span>$ <%#Eval("valor_bicicleta")%> / 4 Hora</span>
                                                    <span><%#Eval("nombre_empresa")%></span>
                                                    <% if (Session["rol"].ToString() == "Empresa")
                                                        {
                                                    %>
                                                    <asp:LinkButton runat="server" data-target="#myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta")%>' CommandName="modificar">
                                            Modificar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" data-target="#myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_bicicleta")%>' CommandName="Eliminar">
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
                                                            <asp:LinkButton runat="server" data-target="#myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("nombre_tipo_bicicleta") %>' CommandName="descripcion">
                                            <%#Eval("nombre_tipo_bicicleta") %>
                                                            </asp:LinkButton>
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

                    <div class="form-group">
                        <label for="number">Fecha Inicio</label>
                        <asp:TextBox TextMode="Date" ID="fechainicio" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
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
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-secondary">Close</button>
                    <asp:Button ID="button4" Text="Alquilar" OnClick="button4_Click" runat="server" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
    <div id="modibicicleta" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabe" aria-hidden="true" class="modal fade text-left">
        <div role="document" class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 id="exampleModalLabe" class="modal-title">Modificar Bicicleta</h4>
                    <button type="button" data-dismiss="modal" aria-label="Close" class="close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <label for="number">Nombre</label>
                        <asp:TextBox ID="nombremod" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="number">Talla</label>
                        <asp:TextBox ID="tallamod" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="number">Valor</label>
                        <asp:TextBox ID="valormod" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="number">Cantidad</label>
                        <asp:TextBox ID="cantidadmod" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="number">Tipo</label>
                        <asp:DropDownList ID="evento" class="form-control" Height="46" AppendDataBoundItems="true" DataTextField="media_name" DataValueField="media_id" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-secondary">Close</button>
                    <asp:Button ID="button1" Text="Modificar" OnClick="button1_Click" runat="server" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
    <div id="descripcionbici" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel1" aria-hidden="true" class="modal fade text-left">
        <div role="document" class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 id="exampleModalLabel1" class="modal-title">Descripcioón de Tipo de Bicicleta</h4>
                    <button type="button" data-dismiss="modal" aria-label="Close" class="close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:TextBox ID="TextBox1" Enabled="false" class="form-control" autocomplete="off" Width="450" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn btn-secondary">Close</button>
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
