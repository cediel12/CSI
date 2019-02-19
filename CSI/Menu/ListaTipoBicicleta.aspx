<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="ListaTipoBicicleta.aspx.cs" Inherits="CSI.Menu.ListaTipoBicicleta" %>
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
                                        <th class="th-lg"><a>Tipo</a></th>
                                        <th class="th-lg"><a>Descripcion</a></th>
                                        <th class="th-lg"><a>Modificar</a></th>
                                        <th class="th-lg"><a>Eliminar</a></th>
                                    </tr>
                                </thead>
                                <!--Table head-->

                                <!--Table body-->
                                <tbody>
                                    <asp:ListView runat="server" ID="lista">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("nombre_tipo_bicicleta") %></td>
                                                <td><%#Eval("descripcion_tipo_bicleta") %></td>
                                                <td>

                                                    <asp:LinkButton runat="server" data-target="myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_tipo_bicicleta") %>' CommandName="modificar">
                                            Modificar
                                                    </asp:LinkButton>
                                                </td>
                                                <td>

                                                    <asp:LinkButton runat="server" data-target="myModal" OnCommand="Unnamed_Command" CssClass="" CommandArgument='<%#Eval("id_tipo_bicicleta") %>' CommandName="eliminar">
                                            Eliminar
                                                    </asp:LinkButton>
                                               </td>
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
                    <h4 id="exampleModalLabel" class="modal-title">Tiempo de alquiler</h4>
                    <button type="button" data-dismiss="modal" aria-label="Close" class="close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                            <label>Tipo</label>
                            <asp:TextBox ID="tipo" class="form-control" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Descripcion</label>
                            <asp:TextBox ID="descripcion" class="form-control" autocomplete="off" Height="46" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>                        
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-secondary">Close</button>
                    <asp:Button ID="button4" Text="Actualizar" OnClick="button4_Click" runat="server" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
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
