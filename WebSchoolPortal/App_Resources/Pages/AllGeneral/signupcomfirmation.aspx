<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signupcomfirmation.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.AllGeneral.signupcomfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/app.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1"  runat="server">
        <section id="content" class="m-t-lg wrapper-md animated fadeInUp">
            <div class="container aside-xxl">
                <a class="navbar-brand block" href="#">Automated Schools</a>
                <section class="panel panel-default bg-white m-t-lg">
                    <header class="panel-heading text-center">
                        <strong>Signup Comfirmation</strong>
                    </header>
                    <div class="panel-body wrapper-lg">
                        <div class="form-group">
                            <label class="control-label">Comfirmation Code</label>
                            <input type="email" class="form-control input-lg">
                        </div>
                       
                        <button type="submit" class="btn btn-primary pull-right">Next</button>
                        <div class="line line-dashed"></div>
                       
                        <p class="text-muted text-center"><small>Do not have an account?</small></p>
                        
                    </div>
                </section>
            </div>
        </section>
        <!-- footer -->
        <footer id="footer">
            <div class="text-center padder">
                <p>
                    <small>Managed By ALBIZZIA<br>
                        &copy; 2016</small>
                </p>
            </div>
        </footer>


    </form>

    <!-- Bootstrap -->
    <!-- App -->

    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/app.v1.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/charts/easypiechart/jquery.easy-pie-chart.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/charts/sparkline/jquery.sparkline.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/charts/flot/jquery.flot.min.js") %>"></script>


    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/app.plugin.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/fuelux/fuelux.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/parsley/parsley.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/app.plugin.js") %>"></script>

    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/calendar/bootstrap_calendar.js") %>"></script>

    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/calendar/demo.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Resources/js/slimscroll/jquery.slimscroll.min.js") %>"></script>

</body>
</html>
