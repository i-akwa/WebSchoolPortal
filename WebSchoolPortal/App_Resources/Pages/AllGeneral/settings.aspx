<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.AllGeneral.settings" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   
    <!-- <style type="text/css">

	.flip3D{
		 height: 240px;  float: left;
	}
	.flip3D > .front{
		
		transform: perspective(600px) rotateY( 0deg);
		
		background: blue;  height: 120px; backface-visibility:hidden; transition:transform .5s linear 0s;
		-webkit-transition:transform .5s linear 0s; 
		-webkit-backface-visibility:hidden;
		-webkit-transform: perspective(600px) rotateY( 0deg);
	}
	.flip3D > .back{
		position: absolute;
		transform: perspective(600px) rotateY( 180deg);
		background: red; height: 120px; backface-visibility:hidden; transition:transform .5s linear 0s;
		-webkit-transition:transform .5s linear 0s; 
		-webkit-backface-visibility:hidden;
		-webkit-transform: perspective(600px) rotateY( 180deg); 
	}

	.flip3D:hover > .front{
		transform:perspective( 600px ) rotateY( -180deg );
		-webkit-transform:perspective( 600px ) rotateY( -180deg );
	}
	.flip3D:hover > .back{
		transform:perspective( 600px ) rotateY( 0deg );
		-webkit-transform:perspective( 600px ) rotateY( 0deg );
	}

	</style>-->
    
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/animate.css" rel="stylesheet" />
     <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../css/app.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />
    <link href="../../css/landing.css" rel="stylesheet" />
  <link href="../../css/app.v1.css" rel="stylesheet" />

 
</head>
<body>
    <form id="form1" runat="server">
        <section id="content ">
            <div class="row">
                <p>
                    <br />
                           
                          
                </p>
                <div class="col-sm-6">

                    <div class="col-sm-6 col-md-3 padder-v b-r b-light">
                        <span class="fa-stack fa-2x pull-left m-r-sm">
                            <i class="fa fa-circle fa-stack-2x text-success"></i>
                            <i class="fa fa-cogs fa-stack-1x text-white"></i>
                        </span>
                        <a class="clear" href="#">
                            <span class="h4 block m-t-xs"><strong>SETTINGS</strong></span>

                        </a>
                    </div>



                </div>

            <div class="col-md-6 col-sm-12">
                <div class="col-md-6 col-sm-12">
                </div>
                <div class="col-md-6 col-sm-12 animated fadeInRight">
                    <div class="form-group ">
                        <input class="form-control " type="text" placeholder="Find a setting"  />  
                    </div>
                </div>
            </div>
            </div>
        
            <div class="container">
                <div class="col-md-push-1 col-md-10 " style="margin-top: 40px;">
                  <!--  <div class="row">
                        <div class="col-md-2 col-sm-12 animated fadeInDown" style="border: dotted; height: 120px;">
                            <div class="col-md-6 ">
                                <span class="fa-stack fa-2x  ">
                                    <i class="fa fa-circle fa-stack-2x text-success"></i>
                                    <i class="fa fa-cogs fa-stack-1x text-white"></i>
                                </span>                           
                            </div>
                            <div class="col-sm-6 ">
                                <span class="h4 block m-t-xs "><strong>SETTINGS</strong></span>   
                            </div>
                        </div>


                        <div class="col-md-2 col-sm-12 animated fadeInDown" style="border: dotted; height: 120px;">
                            <p class="col-md-12 col-lg-12 col-sm-6 col-xs-6 " >
                                <a href="#" class="  btn btn-rounded btn-twitter btn-icon"><i class="fa fa-twitter"></i></a>
                            </p>
                             <p class="col-md-12 col-lg-12 col-sm-6 col-xs-6 ">
                                <a href="#" class="  btn btn-rounded btn-twitter btn-icon"><i class="fa fa-twitter"></i></a>
                            </p>
                        </div>
                        <div class="col-md-2 col-sm-12 animated fadeInRight" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12 animated fadeInDown" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12 animated fadeInRight" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12 animated fadeInDown" style="border: dotted; height: 120px;"></div>
                    </div>-->

                   

                    <div class="row m-l-none m-r-none bg-light lter animated fadeInDown" >
                        <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-plus fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-sun-o fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-money fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-gear fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                        
                          <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-globe fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-lock fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-compass fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-folder-open fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>

                          <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-key fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-qrcode fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-tachometer fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-sun-o fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                          <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-ticket fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-legal fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-gavel fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                       <div class="col-sm-6 col-md-3 padder-v b-r b-light" style="">
                            <span class="fa-stack fa-2x pull-left m-r-sm">
                                <i class="fa fa-circle fa-stack-2x text-success"></i>
                                <i class="fa fa-pencil fa-stack-1x text-white"></i>
                            </span>
                            <a class="clear" href="#">
                                <span class="h4 block m-t-xs"><strong>Settings</strong></span>
                                <small class="text-muted text-uc">Description Here</small>
                            </a>
                        </div>
                    </div>

                    <!--
                    <div class="flip3D col-md-2 col-sm-12 ">
                        <div class="back col-sm-12 col-sm-12">Box 1 - Back</div>
                        <div class="front col-sm-12">Box 1 - Front</div>
                    </div>

                    <div class="flip3D col-md-2 col-sm-12">
                        <div class="back col-md-12 col-sm-12">Box 2 - Back</div>
                        <div class="front col-md-12 col-sm-12">Box 2 - Front</div>
                    </div>

                    <div class="flip3D col-md-2 col-sm-12">
                        <div class="back col-md-12 col-sm-12">Box 3 - Back</div>
                        <div class="front col-md-12 col-sm-12">Box 3 - Front</div>
                    </div>

                    <div class="flip3D col-md-2 col-sm-12">
                        <div class="back col-md-12 col-sm-12">Box 3 - Back</div>
                        <div class="front col-md-12 col-sm-12">Box 3 - Front</div>
                    </div>

                    <div class="flip3D col-md-2 col-sm-12">
                        <div class="back col-md-12 col-sm-12">Box 3 - Back</div>
                        <div class="front col-md-12 col-sm-12">Box 3 - Front</div>
                    </div>

                    <div class="flip3D col-md-2 col-sm-12">
                        <div class="back col-md-12 col-sm-12">Box 3 - Back</div>
                        <div class="front col-md-12 col-sm-12">Box 3 - Front</div>
                    </div>-

                    
                    <div class="row">
                        <div class="col-md-2 col-sm-12 animated fadeInUp" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInLeft" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInUp" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInLeft" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInUp" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInLeft" style="border: dotted; height: 120px;"></div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-sm-12 animated fadeInUp" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInLeft" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInUp" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInLeft" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInUp" style="border: dotted; height: 120px;"></div>
                        <div class="col-md-2 col-sm-12  animated fadeInLeft" style="border: dotted; height: 120px;"></div>
                    </div>-->
                    


                </div>
            </div>
        </section>
    </form>


    
<!-- Notes -->
    <script src="../../js/apps/notes.js"></script>
    <script src="../../js/app.plugin.js"></script>
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
