<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alquilar.aspx.cs" Inherits="CSI.Menu.Alquilar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proceso de Alquiler</title>
    <!-- Bootstrap CSS-->
    <link href="../../Estilos/Men/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome CSS-->
    <link href="../../Estilos/Men/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Fontastic Custom icon font-->
    <link href="../../Estilos/Men/css/fontastic.css" rel="stylesheet" />
    <!-- Google fonts - Poppins -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700">
    <!-- theme stylesheet-->
    <link href="../../Estilos/Men/css/style.default.css" rel="stylesheet" />
    <!-- Custom stylesheet - for your changes-->
    <link href="../../Estilos/Men/css/custom.css" rel="stylesheet" />
    <script type="text/javascript">
        function Agregar() {
            var oContador = 1;
            var oElementos = document.getElementsByTagName("input");
            for (var i = 0; i < length; i++) {
                if (oElementos[i].type == "file") {
                    oContador++;
                }
            }
            var oTr = document.getElementById("trArchivos");
            var oBr = document.createElement("br");
            var oFU = document.createElement("input");
            oFU.type = "file";
            oFU.name = "Archivo" + oContador;
            oFU.id = "file" + oContador;
            oTr.appendChild(oBr);
            oTr.appendChild(oFU);

        }

    </script>
    <style type="text/css">
        #file1 {
            width: 390px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="panel-heading">
                <asp:Label ID="label1" Text="" runat="server" />
            </div>
            <div class="form-group">
                <label for="number">Fecha Inicio</label>
                <asp:TextBox ID="fechainicio" class="form-control" runat="server" Height="46" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="number">Fecha Fin</label>
                <asp:TextBox ID="fechafin" class="form-control"  runat="server" Height="46" TextMode="Date" ></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="button1" Text="Realizar Alquiler" runat="server" class="btn btn-default btn-responsive" OnClick="button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
