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
    <link rel="shortcut icon" href="../Estilos/Men/img/favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
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
                                    <form class="form-validate">
                                        <div class="form-group">
                                            <input id="register-username" type="text" name="registerUsername" required data-msg="Please enter your username" class="input-material">
                                            <label for="register-username" class="label-material">User Name</label>
                                        </div>
                                        <div class="form-group">
                                            <input id="register-email" type="email" name="registerEmail" required data-msg="Please enter a valid email address" class="input-material">
                                            <label for="register-email" class="label-material">Email Address      </label>
                                        </div>
                                        <div class="form-group">
                                            <input id="register-password" type="password" name="registerPassword" required data-msg="Please enter your password" class="input-material">
                                            <label for="register-password" class="label-material">password        </label>
                                        </div>
                                        <div class="form-group terms-conditions">
                                            <input id="register-agree" name="registerAgree" type="checkbox" required value="1" data-msg="Your agreement is required" class="checkbox-template">
                                            <label for="register-agree">Agree the terms and policy</label>
                                        </div>
                                        <div class="form-group">
                                            <button id="regidter" type="submit" name="registerSubmit" class="btn btn-primary">Register</button>
                                        </div>
                                    </form>
                                    <small>Ya tienes una cuenta? </small><a href="login.html" class="signup">Inciar Sesión</a>
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
    </form>
</body>
</html>
