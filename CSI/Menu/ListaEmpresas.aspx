<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Menu/Home.Master" AutoEventWireup="true" CodeBehind="ListaEmpresas.aspx.cs" Inherits="CSI.Menu.ListaEmpresas" %>

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
                                        <th class="th-lg"><a>Descripcion</a></th>
                                        <th class="th-lg"><a>Descripcion</a></th>
                                        <th class="th-lg"><a>Nit</a></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView runat="server" ID="lista">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("nombre_empresa") %></td>
                                                <td><%#Eval("dirrecion_empresa") %></td>
                                                <td><%#Eval("telefono_empresa") %></td>
                                                <td><%#Eval("nit") %></td>
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
    </div>
</asp:Content>
