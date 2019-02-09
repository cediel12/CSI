<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="ListaEventos.aspx.cs" Inherits="CSI.Menu.ListaEventos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/Tabla/css/lib/datatable/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function openModal() {
            $('#mymmodalmodificar').modal('show');
        }
    </script>
    <div class="content mt-3">
        <div class="animated fadeIn">
            <div class="row">

                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Eventos</strong>
                        </div>
                        <div class="card-body">
                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th class="th-lg"><a>Nombre</a></th>
                                        <th class="th-lg"><a>Fecha</a></th>
                                        <th class="th-lg"><a>Hora</a></th>
                                        <th class="th-lg"><a>Lugar</a></th>
                                        <th class="th-lg"><a>Organizador</a></th>
                                        <% if (Session["rol"].ToString() == "Empresa")
                                            {
                                        %>
                                        <th class="th-lg"><a>Modificar</a></th>
                                        <th class="th-lg"><a>Eliminar</a></th>

                                        <%}
                                            else
                                            {
                                        %>
                                        <th class="th-lg"><a>Participar</a></th>
                                        <%} %>
                                    </tr>
                                </thead>
                                <!--Table head-->

                                <!--Table body-->
                                <tbody>
                                    <asp:ListView runat="server" ID="lista">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("nombre_evento") %></td>
                                                <td><%#Eval("fecha_evento") %></td>
                                                <td><%#Eval("hora") %></td>
                                                <td><%#Eval("lugar") %></td>
                                                <td><%#Eval("nombre_empresa") %></td>

                                                <% if (Session["rol"].ToString() == "Empresa")
                                                    {
                                                %>
                                                <td>

                                                    <asp:LinkButton runat="server" data-target="myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_evento") %>' CommandName="modificar">
                                            Modificar
                                                    </asp:LinkButton>
                                                </td>
                                                <td>

                                                    <asp:LinkButton runat="server" data-target="myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_evento") %>' CommandName="eliminar">
                                            Eliminar
                                                    </asp:LinkButton>
                                                </td>
                                                <%}
                                                    else
                                                    {
                                                %>
                                                <td>
                                                    <asp:LinkButton runat="server" data-target="myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_evento") %>' CommandName="registrar">
                                            Participar
                                                    </asp:LinkButton>
                                                    <%} %>
                                                </td>
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
    <div id="mymmodalmodificar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" class="modal fade text-left">
        <div role="document" class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 id="exampleModalLabel" class="modal-title">Modificar Evento</h4>
                    <button type="button" data-dismiss="modal" aria-label="Close" class="close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label>Nombre Evento</label>
                            <asp:TextBox ID="nombreevento" class="form-control" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Fecha</label>
                            <asp:TextBox ID="fecha" TextMode="Date" class="form-control" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Hora</label>
                            <asp:TextBox ID="hora" TextMode="Time" class="form-control" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Lugar</label>
                            <asp:TextBox ID="lugar" class="form-control" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Descripción</label>
                            <asp:TextBox ID="descripcion" class="form-control" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-secondary">Close</button>
                    <asp:Button ID="Button1" runat="server" EnableTheming="True" class="btn btn-primary" Text="Actualizar" />
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
