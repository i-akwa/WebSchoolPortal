<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebSchoolPortal.search" %>

<!DOCTYPE html>

<html lang="en" class=" ">
<head runat="server">
  <meta charset="utf-8" />
   <title>Automated-schools management system | Home</title>
    <link rel="icon" href="images/icon.ico" />
  <meta name="description" content="Automated schools management system is a responsive web based application which will give you much power to take your school to greater height.It has admin dashboard, teacher dashboard, student dashboard" /> 
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/font.css" rel="stylesheet" />
    <link href="css/landing.css" rel="stylesheet" />
    <link href="css/app.css" rel="stylesheet" />

    <!--[if lt IE 9]>
    <script src="js/ie/html5shiv.js"></script>
    <script src="js/ie/respond.min.js"></script>
    <script src="js/ie/excanvas.js"></script>
  <![endif]-->
</head>
    <body>
    <form id="form1" runat="server">
    
         <!-- header -->
  <header id="header" class="navbar navbar-fixed-top bg-white box-shadow b-b b-light"  data-spy="affix" data-offset-top="1">
    <div class="container">
      <div class="navbar-header">
        <a href="index.html" class="navbar-brand"><img src="App_Resources/images/logo.png" class="m-r-sm"><span class="text-muted">Automated Schools</span></a>
        <button class="btn btn-link visible-xs" type="button" data-toggle="collapse" data-target=".navbar-collapse">
          <i class="fa fa-bars"></i>
        </button>
          <asp:LinkButton ID="createNew" runat="server" Text="CreateNewMember" OnClick="createNew_Click" ></asp:LinkButton>
      </div>
      <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right">
         <!--  <li class="active">
            <a href="index.html">Home</a>
          </li>
          <li>
            <a href="features.html">Features</a>
          </li>
             
         <li>
            <a href="price.html">Pricing</a>
          </li>-->
          <li>
            <div class="m-t-sm"><a href="App_Resources/Pages/Anonymous/Login.aspx" class="btn btn-sm btn-info m-l">Sign in</a> <a href="/App_Resources/Pages/AllGeneral/SignUp.aspx" class="btn btn-sm btn-success m-l"><strong>Sign up</strong></a></div>
          </li>
           <!-- <li>
              <a href="#contact" data-jump="true">Contact us</a>
          </li> -->
            
        </ul>
      </div>
    </div>
  </header>
  <!-- / header -->
        <!--- Container---->
        <section id="content">
        <div class="container-fluid">
            <section class="  col-md-8 col-md-offset-1 col-sm-12">
               <div class="clearfix" style="margin-top:100px;"></div>
                   
                <div class="form-group">
                    <label class="col-sm-2 control-label input-lg"></label>
                    <div class="col-sm-10">
                        <div class="input-group">
                            <asp:TextBox ID="SearchBox" runat="server" class="form-control input-lg" placeholder="Go on, Search!!! " />
                            <span class="input-group-btn">
                                <asp:LinkButton ID="SearchButton" runat="server" type="button" class="btn btn-default btn-lg" OnClick="SearchButton_Click" Text="Search"><i class="fa fa-search"></i></asp:LinkButton>

                            </span>
                        </div>
                    </div>
                </div>
                
                 
            </section>
            
        </div>
            <div class="bg-white b-t b-light" style="min-height:370px; border-top:none;">
                <div class="container m-t-xl">
                    
                </div>
            </div>
            
            <footer class="footer" >
               
                    <ul class="nav navbar-nav navbar-right ">
                        <li >
                            <a href="#">Home</a>
                        </li>
                        <li>
                            <a href="#">Features</a>
                        </li>

                        <li>
                            <a href="#">Search</a>
                        </li>
                        <li>
                            <a href="#">Search</a>
                        </li>

                        <li>
                            <a href="#" >Contact us</a>
                        </li>

                    </ul>
                
                     </footer>
        </section>
            <!--- /Container---->

    </form>

               <!-- / footer -->
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.js"></script>
<script src="js/app.js"></script>
<script src="js/slimscroll/jquery.slimscroll.min.js"></script>
<script src="js/appear/jquery.appear.js"></script>
<script src="js/scroll/smoothscroll.js"></script>
<script src="js/landing.js"></script>
 <script src="js/app.plugin.js"></script>   
</body>
</html>


 