<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Anonymous.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="bg-dark">
<head id="Head1" runat="server">
    <link rel="icon" href="../../../images/icon.ico" />
    

    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../css/app.css" rel="stylesheet" />
    <link href="../../css/app.v1.css" rel="stylesheet" />
    <link href="../../js/select2/select2.css" rel="stylesheet" />
    <link href="../../js/select2/theme.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />

    
</head>
<body>
       <form id="Form2" runat="server">
        <section id="content" class="m-t-lg wrapper-md animated fadeInDown">
            <div class="container aside-xxl">
                <center>
                <a class=" block" href="http://hez-dikeschools.com/"><img class="img img-responsive"  src="../../images/logotextbig.png"/></a>
                    </center>
                <section class="panel panel-default m-t-lg bg-white">
                    <header class="panel-heading text-center">
                        <strong>Welcome</strong>
                    </header>
                    <div class="panel-body wrapper-lg">

                        <h4>
                        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" CssClass=" alert " > 
                        </asp:Label>
                           </h4>

                        <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn" OnLoggingIn="Login1_LoggingIn" OnLoginError="Login1_LoginError" Width="100%">
                            <LayoutTemplate>

                                <div class="input-group m-b">
                                    <span class="input-group-addon"><i class="fa fa-user">&nbsp;</i></span>

                                    <asp:TextBox AutoCompleteType="Disabled" style="margin-left:-10px;" autocomplete="off" ID="UserName" runat="server" data-required="true" CssClass="form-control input-lg " placeholder="Username"  data-toggle="tooltip" data-placement="top" title="" data-original-title="Username"  />
                                </div>

                                <div class="input-group m-b">
                                    <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                    <asp:TextBox runat="server" style="margin-left:-10px;" type="password" ID="Password" placeholder="Type a password" CssClass="form-control input-lg "  data-toggle="tooltip" data-placement="top" title="" data-original-title="Password" />
                                </div>

                                <div class="checkbox">
                                    <label class="checkbox-custom">

                                        <input type="checkbox" name="checkboxB" id="2">
                                        <i class="fa fa-fw fa-square-o"></i>
                                         Keep me logged in
                                    </label>
                                </div>

                                <asp:Button ID="Button1" type="submit" CommandName="Login" Text="Sign In" runat="server" CssClass="btn btn-primary pull-right"></asp:Button>

                                <a href="PasswordRecovery.aspx" class="pull-left m-t-xs"><small>Forgot password?</small></a>
                                <br />
                                <br />
                                <div class="line line-dashed"></div>

                                <div class="line line-dashed"></div>

                                <p class="text-muted text-center"><small>Do not have an account?</small></p>
                                <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl="~/App_Resources/Pages/Anonymous/RegisterSchoolAdmin.aspx" class="btn btn-default btn-block">Create an account</asp:HyperLink>

                            </LayoutTemplate>
                        </asp:Login>


                    </div>
                </section>
            </div>
        </section>
        <!-- footer -->
        <footer id="footer">
            <div class="text-center padder clearfix">
                <p>
                    <small>Automated Schools Manage by <a href="#">ALBIZZIA</a><br>
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
           <script src="../../js/select2/select2.min.js"></script>
           <script src="../../js/fuelux/fuelux.js"></script>
    </form> 
   

                  
</body>
</html>
