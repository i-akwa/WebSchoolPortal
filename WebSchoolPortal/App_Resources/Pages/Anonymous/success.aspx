<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="success.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.AllGeneral.success" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta charset="utf-8" /> 
<title>Automated Schools</title> 
<meta name="description" content="Automated schools management system is a responsive web based application which will give you much power to take your school to greater height.It has admin dashboard, teacher dashboard, student dashboard" /> 
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../css/app.v1.css" rel="stylesheet" />
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />
    <link href="../../css/landing.css" rel="stylesheet" />

</head>
    <body>
        <form runat="server" id="form1">
            <header class="bg-dark dk header navbar navbar-fixed-top-xs">
                <div class="navbar-header aside-md">
                    <a class="btn btn-link visible-xs" data-toggle="class:nav-off-screen,open" data-target="#nav,html">
                        <i class="fa fa-bars"></i>
                    </a>
                    <a href="#" class="navbar-brand" data-toggle="fullscreen">
                        <asp:Image ID="img1" runat="server" ImageUrl="~/App_Resources/images/logo.png" CssClass="m-r-sm" />
                        Automated
                    </a>
                    <a class="btn btn-link visible-xs" data-toggle="dropdown" data-target=".nav-user">
                        <i class="fa fa-cog"></i>
                    </a>
                </div>
                  
            </header>
           
            
            <section class="container">
                     
                         <div class="col-md-12">
                             <div class="blog-post">
                                 <div class="post-item">
                                     <div class="post-media">
                                         <section class="panel bg-primary dk m-b-none">
                                             <div class="carousel auto slide panel-body" id="c-fade">
                                                 <ol class="carousel-indicators out">
                                                     <li data-target="#c-fade" data-slide-to="0" class="active"></li>
                                                     <li data-target="#c-fade" data-slide-to="1" class=""></li>
                                                     <li data-target="#c-fade" data-slide-to="2" class=""></li>
                                                 </ol>
                                                 <div class="carousel-inner">
                                                     <div class="item active text-center">
                                                         <span class="h2"><i class="fa fa-clock-o fa-5x m-t icon-muted"></i></span>
                                                         <p class="text-muted m-t m-b-lg">Time saving</p>
                                                     </div>
                                                     <div class="item text-center">
                                                         <span class="h2"><i class="fa fa-file-o fa-5x m-t icon-muted"></i></span>
                                                         <p class="text-muted m-t m-b-lg">Full documents</p>
                                                     </div>
                                                     <div class="item text-center">
                                                         <span class="h2"><i class="fa fa-mobile fa-5x m-t icon-muted"></i></span>
                                                         <p class="text-muted m-t m-b-lg">Mobile/Tablet/Desktop</p>
                                                     </div>
                                                 </div>
                                                 <a class="left carousel-control" href="#c-fade" data-slide="prev">
                                                     <i class="fa fa-angle-left"></i>
                                                 </a>
                                                 <a class="right carousel-control" href="#c-fade" data-slide="next">
                                                     <i class="fa fa-angle-right"></i>
                                                 </a>
                                             </div>
                                         </section>
                                        
                        
                                     </div>
                                     <div class="caption wrapper-lg">
                                         <h2 class="post-title"><a href="#">Registration Successful</a></h2>
                                         <div class="post-sum">
                                             <p>
                                                 Welcome To Automated School Management System
                  <br>
                                                 <br>
                                                 Your account will be activated in a while,you will recieve a message once you have been activated. Thanks
                                             </p>
                                             <p>
                                             <asp:HyperLink ID="Login" runat="server" Text="Click ToTake You Our HomePage" NavigateUrl="~/App_Resources/Pages/Anonymous/Login.aspx"></asp:HyperLink> </p>
                                         </div>
                                         <div class="line line-lg"></div>
                                         <div class="text-muted">
                                             <i class="fa fa-user icon-muted"></i>Manage by <a href="#" class="m-r-sm">ALBIZZIA</a>
                                             <i class="fa fa-clock-o icon-muted"></i> 2018
                  <!--<a href="#" class="m-l-sm"><i class="fa fa-comment-o icon-muted"></i>2 comments</a>-->
                                         </div>
                                     </div>
                                 </div>
                                
                             </div>
                            
                         </div>
                  
               
            </section>
        
            </form>
        <script src="../../js/jquery.min.js"></script>
        <script src="../../js/fuelux/fuelux.js"></script>
        
        
        <script src="../../js/bootstrap.js"></script>
        <script src="../../js/jquery.min.js"></script>
        <script src="../../js/app.js"></script>
        <script src="../../js/landing.js"></script>
        <script src="../../js/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../../js/appear/jquery.appear.js"></script>
        <script src="../../js/app.plugin.js"></script>
    </body>

    </html>
