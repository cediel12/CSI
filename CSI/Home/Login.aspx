<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSI.Home.Login" %>

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
    <!-- Tweaks for older IEs-->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script><![endif]-->
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
                                <form method="post" class="form-validate" runat="server">
                                    <div class="form-group">
                                        <input id="login-username" type="text" name="loginUsername" required data-msg="Por favor Ingresar un usuario" class="input-material">
                                        <label for="login-username" class="label-material">Usuario</label>
                                    </div>
                                    <div class="form-group">
                                        <input id="login-password" type="password" name="loginPassword" required data-msg="Por favor ingresar una contraseña" class="input-material">
                                        <label for="login-password" class="label-material">Contraseña</label>
                                    </div>
                                    <asp:Button ID="Button2" runat="server" EnableTheming="True" class="btn btn-primary" Text="Iniciar Sesion" OnClick="IniciarSesion" />
                                    <!-- This should be submit button but I replaced it with <a> for demo purposes-->
                                </form>
                                <a href="#" class="forgot-pass">Restablecer Contraseña?</a><br>
                                <small>No tiene una cuenta? </small><a href="Signup.aspx" class="signup">Registrar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="copyrights text-center">
            <p>
                &copy; Copyright <strong>CiclyCaq</strong>. All Rights Reserved
            </p>
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
