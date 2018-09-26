<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Anonymous.PasswordRecovery" %>


<!DOCTYPE html>

<html class="bg-dark" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <link rel="icon" href="../../../images/icon.ico" />
    <title>Automated Schools</title>
     <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../css/app.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <link href="../../css/app.v1.css" rel="stylesheet" />
    <link href="../../js/select2/select2.css" rel="stylesheet" />
    <link href="../../js/select2/theme.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />
    <!--[if lt IE 9]>
    <script src="js/ie/html5shiv.js"></script>
    <script src="js/ie/respond.min.js"></script>
    <script src="js/ie/excanvas.js"></script>
  <![endif]-->

   




       
    
</head>
<body>
    <form id="form1"  runat="server">
        <section id="content" class="m-t-lg wrapper-md animated fadeInUp">
            <div class="container aside-xxl">
                <center>
                <a class=" block" href="../../../index.html"><img class="img img-responsive"  src="../../images/logotextbig.png"/></a>
                    </center>
                
                <section class="panel panel-default m-t-lg bg-white">
                    <header class="panel-heading text-center">
                        <strong>Password Recovery</strong>
                    </header>
                    
                        <asp:passwordrecovery id="Recover" runat="server" submitbuttonstyle-cssclass="btn btn-success btn-block btn-lg" instructiontextstyle-cssclass="form-control" textboxstyle-cssclass="form-control" successtext="Your Password has been changed and mailed to you" usernamefailuretext="Username not found"  Width="100%">
                            <UserNameTemplate>
                                <div class="panel-body wrapper-lg">                                  
                                    <div class="input-group m-b">
                                        <span class="input-group-addon" ><i class="fa fa-user"></i></span>
                                        <asp:TextBox AutoCompleteType="Disabled" autocomplete="off" style="margin-left:-10px;" data-required="true" ID="UserName" runat="server" Placeholder="Username" CssClass="form-control input-lg " data-toggle="tooltip" data-placement="top" title="" data-original-title="Username"  />     
                                    </div>
                                    <div class="form-group">
                                        <!--<h4><label class="control-label">Username</label></h4>-->
                                        
                                        <h6><asp:Label ID="FailureText" EnableViewState="false" runat="server" AssociatedControlID="UserName" ForeColor="Red" /></h6>


                                    </div>


                                    <asp:Button ID="btnSubmit" CommandName="Submit" runat="server" Text="Next" CssClass="btn btn-primary pull-right" />

                                     
                                <br />
                                <br />
                                <div class="line line-dashed"></div>

                                <div class="line line-dashed"></div>

                                <p class="text-muted text-center"><small>Do you remember your password?</small></p>
                                <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl="~/App_Resources/Pages/Anonymous/Login.aspx" class="btn btn-default btn-block">Signin</asp:HyperLink>

                                   </div>
                                    <p class="text-muted text-center"><small></small></p>
                                </div>



                            </UserNameTemplate>
       
                            <QuestionTemplate>
                                <div class="panel-body wrapper-lg">
                                    <div class="form-group">

                                        <h4><asp:Label ID="Question" Text="" runat="server" class="control-label" /></h4>
                                        
                                        <div class="panel-body wrapper-lg">                                  
                                    <div class="input-group m-b">
                                        <span class="input-group-addon" ><i class="fa fa-pencil"></i></span>
                                        <asp:TextBox ID="Answer" style="margin-left:-10px;" runat="server" Placeholder="Password Answer" CssClass="form-control input-lg " Width="100%" />
                                        </div>
                                        <h6><asp:Label ID="FailureText" EnableViewState="false" runat="server" ForeColor="red" /></h6>

                                    </div>


                                    <asp:Button ID="btnSubmit" CommandName="Submit" Text="Next" runat="server" CssClass="btn btn-primary pull-right" />

                                         <br />
                                <br />
                                <div class="line line-dashed"></div>

                                <div class="line line-dashed"></div>

                                <p class="text-muted text-center"><small>Do you remember your password?</small></p>
                                <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl="~/App_Resources/Pages/Anonymous/Login.aspx" class="btn btn-default btn-block">Signin</asp:HyperLink>

                                    </div>
                                    <p class="text-muted text-center"><small></small></p>
                                </div>


                            </QuestionTemplate>
        <SuccessTemplate>
            <h2>
                Your Password will Be sent to Your Mail. Thanks for Using Automated School Management System
            </h2>
        </SuccessTemplate>
        
                            <MailDefinition From="serviceinfo@smartschool.com" Subject="Recover Password" BodyFileName="~/App_Resources/Pages/TextFiles/PasswordRecovery.txt"></MailDefinition>
    </asp:passwordrecovery>
    
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
     
 <script src="../../js/jquery.min.js"></script>
        <!-- Bootstrap -->
        <script src="../../js/bootstrap.js"></script>

        <!-- App -->
        <script src="../../js/app.js"></script>
        <script src="../../js/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../../js/app.plugin.js"></script>
        <script src="../../js/select2/select2.min.js"></script>
        <script src="../../js/fuelux/fuelux.js"></script>


</body>
</html>


