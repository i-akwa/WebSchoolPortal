<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="osimlogin.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Anonymous.osimlogin" %>

<!DOCTYPE html>

<html lang="en" class="bg-dark">
<head>
  <meta charset="utf-8" />
  <title>Automated Schools</title>
  <meta name="description" content="" />
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" /> 
<link href="../../css/bootstrap.css" rel="stylesheet" />
<link href="../../css/animate.css" rel="stylesheet" />
<link href="../../css/font-awesome.min.css" rel="stylesheet" />
<link href="../../css/font.css" rel="stylesheet" />
<link href="../../css/app.css" rel="stylesheet" />
<link href="../../css/app.v1.css" rel="stylesheet" />
  <!--[if lt IE 9]>
    <script src="js/ie/html5shiv.js"></script>
    <script src="js/ie/respond.min.js"></script>
    <script src="js/ie/excanvas.js"></script>
  <![endif]-->
</head>
<body class="">
    <form id="Form1" runat="server">
        <section id="content" class="m-t-lg wrapper-md animated fadeInDown">
            <div class="container aside-xxl">
                <center>
                <a class=" block" href="index.html"><img src="../../images/logotextbig.png"></a>
                    </center>
                <section class="panel panel-default m-t-lg bg-white">
                    <header class="panel-heading text-center">
                        <strong>Sign up</strong>
                    </header>
                    <div class="panel-body wrapper-lg">
                        
                        <div class="input-group m-b">
                          <span class="input-group-addon"><i class="fa fa-user">&nbsp;</i></span>
                          <input type="text" class="form-control input-lg" data-required="true"  placeholder="Username">
                        </div>
                       
                        <div class="input-group m-b">
                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                            <input type="password" id="Password1" data-equalto="#pwd" data-required="true" placeholder="password" class="form-control input-lg">
                        </div>

                       <div class="checkbox">
            <label>
              <input type="checkbox"> Keep me logged in
            </label>
          </div>
                         <button type="submit" class="btn btn-primary pull-right">Sign in</button>
          <a href="#" class="pull-left m-t-xs"><small>Forgot password?</small></a>
         <br />
                        <br />
          <div class="line line-dashed"></div>
          
          <div class="line line-dashed"></div>
          <p class="text-muted text-center"><small>Do not have an account?</small></p>
          <a href="signup.html" class="btn btn-default btn-block">Create an account</a>

                    </div>
                </section>
            </div>
        </section>
        <!-- footer -->
        <footer id="footer">
            <div class="text-center padder clearfix">
                <p>
                    <small>Automated Schools Managed by <a href="#">ALBIZZIA</a><br>
                        &copy; 2016</small>
                </p>
            </div>
        </footer>
        <!-- / footer -->
        <script src="../../js/jquery.min.js"></script>
        <!-- Bootstrap -->
        <script src="../../js/bootstrap.js"></script>

        <!-- App -->
        <script src="../../js/app.js"></script>
        <script src="../../js/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../../js/app.plugin.js"></script>

    </form> 
</body>
</html>