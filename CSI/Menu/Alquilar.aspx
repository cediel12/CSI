<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alquilar.aspx.cs" Inherits="CSI.Menu.Alquilar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proceso de Alquiler</title>
    <!-- Bootstrap CSS-->
    <link href="../Estilos/Men/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Estilos/Men/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Estilos/Men/css/fontastic.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <link href="../Estilos/Men/css/style.default.css" rel="stylesheet" />
    <link href="../Estilos/Men/css/custom.css" rel="stylesheet" />
    <link href="../Estilos/Men/img/icono.ico" rel="icon" />
    <script src="../Estilos/Tabla/js/sweetalert2.js" type="text/javascript"></script>
    <link href="../Estilos/Tabla/css/lib/animatesweet.css" rel="stylesheet" />
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
</head>
<body>
    <form id="form1" runat="server">
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
                        <asp:Button ID="button4" Text="Realizar Alquiler" runat="server"  class="btn btn-primary" />
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
