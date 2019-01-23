<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="CSI.Home.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>CiclyCaq</title>
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="robots" content="all,follow" />
    <!-- Bootstrap CSS-->
    <link rel="stylesheet" href="../Estilos/Men/vendor/bootstrap/css/bootstrap.min.css" />
    <!-- Font Awesome CSS-->
    <link rel="stylesheet" href="../Estilos/Men/vendor/font-awesome/css/font-awesome.min.css" />
    <!-- Fontastic Custom icon font-->
    <link rel="stylesheet" href="../Estilos/Men/css/fontastic.css" />
    <!-- Google fonts - Poppins -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,700" />
    <!-- theme stylesheet-->
    <link href="../Estilos/Men/css/style.default.css" rel="stylesheet" />
    <!-- Custom stylesheet - for your changes-->
    <link href="../Estilos/Men/css/custom.css" rel="stylesheet" />
    <!-- Favicon-->
    <link rel="shortcut icon" href="../Estilos/Men/img/icono.ico" />
    <script src="../Estilos/Tabla/js/sweetalert2.js" type="text/javascript"></script>
    <link href="../Estilos/Tabla/css/lib/animatesweet.css" rel="stylesheet" />
    <script>
        function alertme(){
            Swal.fire({
                type: 'error',
                title: 'Usuario ya se encuentra registrado',
                animation: false,
                customClass: 'animated tada',
                showConfirmButton: false,
                timer: 1500
            })
        }
    </script>
</head>
<body>
    <div class="page login-page">
        <div class="container d-flex align-items-center">
            <div class="form-holder has-shadow">
                <div class="row">
                    <!-- Logo & Information Panel-->
                    <div class="col-lg-6">
                        <div class="info d-flex align-items-center">
                            <div class="content">
                                <div class="logo">
                                    <h1>CiclyCaq</h1>
                                </div>
                                <p>La mejor forma para alquilar bicicletas y participar en eventos ciclistas.</p>
                            </div>
                        </div>
                    </div>
                    <!-- Form Panel    -->
                    <div class="col-lg-6 bg-white">
                        <div class="form d-flex align-items-center">
                            <div class="content">
                                <form class="form-validate" runat="server">
                                    <div class="form-group">
                                        <input id="register-username" type="text" name="usuario" required data-msg="Ingrese un usuario valido" autocomplete="off" class="input-material">
                                        <label for="register-username" class="label-material">Usuario</label>
                                    </div>
                                    <div class="form-group">
                                        <input id="register-contraseña" type="password" name="contraseña" required data-msg="Ingrese una contraseña valida" class="input-material">
                                        <label for="register-contraseña" class="label-material">Contraseña</label>
                                    </div>
                                    <div class="form-group">
                                        <input id="register-nombre" type="text" name="nombre" required data-msg="Ingrese un nombre valido" autocomplete="off" class="input-material">
                                        <label for="register-nombre" class="label-material">Nombre</label>
                                    </div>
                                    <div class="form-group">
                                        <input id="register-apellido" type="text" name="apellido" required data-msg="Ingrese un apellido valido" autocomplete="off" class="input-material">
                                        <label for="register-apellido" class="label-material">Apellido</label>
                                    </div>
                                    <div class="form-group">
                                        <input id="register-edad" type="text" name="edad" required data-msg="Ingrese una edad" autocomplete="off" class="input-material">
                                        <label for="register-edad" class="label-material">Edad</label>
                                    </div>
                                    <div class="form-group">
                                        <button runat="server" id="Button1" onserverclick="registrar" class="btn btn-primary" title="Salir">Registrar</button>
                                    </div>
                                </form><small>Ya tienes una cuenta? </small><a href="Login.aspx" class="signup">Inciar Sesión</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="copyrights text-center">
            <p>&copy; Copyright <strong>CiclyCaq</strong>. All Rights Reserved</p>
        </div>
    </div>
    <!-- JavaScript files-->
    <script src="../Estilos/Men/vendor/jquery/jquery.min.js"></script>
    <script src="../Estilos/Men/vendor/popper.js/umd/popper.min.js"> </script>
    <script src="../Estilos/Men/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="../Estilos/Men/vendor/jquery.cookie/jquery.cookie.js"> </script>
    <script src="../Estilos/Men/vendor/chart.js/Chart.min.js"></script>
    <script src="../Estilos/Men/vendor/jquery-validation/jquery.validate.min.js"></script>
    <!-- Main File-->
    <script src="../Estilos/Men/js/front.js"></script>
</body>
</html>
