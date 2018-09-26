<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="Teachersdashboard.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Teachers.Teacherdashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">


    <div class="m-b-md">

        <small>Welcome back</small>
    </div>
    <div class="panel panel-default">
                    <div class="row m-l-none m-r-none bg-light lter">
                        <div class="col-sm-6 col-md-3 padder-v b-r b-light">
                            <span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x text-info"></i><i class="fa fa-users fa-stack-1x text-white"></i></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong id="">

                                <asp:Label ID="regStaff" runat="server"></asp:Label></strong></span> <small class="text-muted text-uc">Registered Staff</small> </a>
                        </div>
                        <div class="col-sm-6 col-md-3 padder-v b-r b-light lt">
                            <span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x text-warning"></i><i class="fa fa-users fa-stack-1x text-white"></i><span style="width: 50px; height: 50px; line-height: 50px;" class="easypiechart pos-abt easyPieChart" data-percent="100" data-line-width="4" data-track-color="#fff" data-scale-color="false" data-size="50" data-line-cap="butt" data-animate="2000" data-target="#bugs" data-update="3000">
                                <canvas width="50" height="50"></canvas>
                            </span></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong id="Strong1">
                                <asp:Label ID="NumTeach" runat="server"></asp:Label></strong></span> <small class="text-muted text-uc">Registered&nbsp; Teachers</small> </a>
                        </div>
                        <div class="col-sm-6 col-md-3 padder-v b-r b-light">
                            <span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x text-info"></i><i class="fa fa-male fa-stack-1x text-white"></i><span style="width: 50px; height: 50px; line-height: 50px;" class="easypiechart pos-abt easyPieChart" data-percent="100" data-line-width="4" data-track-color="#fff" data-scale-color="false" data-size="50" data-line-cap="butt" data-animate="2000" data-target="#bugs" data-update="3000">
                                <canvas width="50" height="50"></canvas>
                            </span></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong id="Strong2">
                                <asp:Label ID="RegMale" runat="server"></asp:Label></strong></span> <small class="text-muted text-uc">Registered&nbsp; Male</small> </a>
                        </div>
                        <div class="col-sm-6 col-md-3 padder-v b-r b-light lt">
                            <span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x text-warning"></i><i class="fa fa-female fa-stack-1x text-white"></i><span style="width: 50px; height: 50px; line-height: 50px;" class="easypiechart pos-abt easyPieChart" data-percent="100" data-line-width="4" data-track-color="#fff" data-scale-color="false" data-size="50" data-line-cap="butt" data-animate="2000" data-target="#bugs" data-update="3000">
                                <canvas width="50" height="50"></canvas>
                            </span></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong id="Strong3">
                                <asp:Label ID="RegFemale" runat="server"></asp:Label></strong></span> <small class="text-muted text-uc">Registered&nbsp; Female</small> </a>
                        </div>
                    </div>
                </div>
    <div class="row">
                    <div class="col-md-8">
                        <section class="panel b-light">
                            <header class="panel-heading bg-primary dker no-border"><strong>Calendar</strong></header>
                            <div id="calendar" class="bg-primary m-l-n-xxs m-r-n-xxs"></div>
                            <div class="list-group">
                                <a href="#" class="list-group-item text-ellipsis">
                                    <span class="badge bg-danger">17th August</span>
                                    Teachers Day
                                </a>
                                <a href="#" class="list-group-item text-ellipsis">
                                    <span class="badge bg-success">1st October</span>
                                    Independents Day
                                </a>
                                 <a href="#" class="list-group-item text-ellipsis">
                                    <span class="badge bg-success">27th May</span>
                                    Childrens Day
                                </a>
                                <a href="#" class="list-group-item text-ellipsis">
                                    <span class="badge bg-light">3rd November</span>
                                   Public Holiday
                                </a>
                            </div>
                        </section> 

                    </div>
                    <div class="col-md-4">
                        <section class="panel panel-default">
                            <header class="panel-heading"> Teachers </header>
                            <header class="panel-heading">
                                <div class="input-group text-sm">
                                    <input class="input-sm form-control" placeholder="Search" type="text">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-default " data-toggle="dropdown">Search <span class="caret"></span></button>
                                        <!--<ul class="dropdown-menu pull-right">
                                            <li><a href="#">Action</a></li>
                                            <li><a href="#">Another action</a></li>
                                            <li><a href="#">Something else here</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#">Separated link</a></li>
                                        </ul>-->
                                    </div>
                                </div>
                            </header>
                            <ul class="list-group alt">
                                <li class="list-group-item">
                                    <div class="media">
                                        <span class="pull-left thumb-sm">
                                            <img src="../../../images/avatar_default.jpg" alt="John said" class="img-circle"></span>
                                        <div class="pull-right text-success m-t-sm"><i class="fa fa-circle"></i></div>
                                        <div class="media-body">
                                            <div><a href="#">Vincent OSim</a></div>
                                            
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="media">
                                        <span class="pull-left thumb-sm">
                                            <img src="../../../images/avatar_default.jpg" alt="John said" class="img-circle"></span>
                                        <div class="pull-right text-muted m-t-sm"><i class="fa fa-circle"></i></div>
                                        <div class="media-body">
                                            <div><a href="#">Enagu Osim</a></div>
                                            
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="media">
                                        <span class="pull-left thumb-sm">
                                            <img src="../../../images/avatar_default.jpg" alt="John said" class="img-circle"></span>
                                        <div class="pull-right text-warning m-t-sm"><i class="fa fa-circle"></i></div>
                                        <div class="media-body">
                                            <div><a href="#">Asen Osim</a></div>
                                            
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="media">
                                        <span class="pull-left thumb-sm">
                                            <img src="../../../images/avatar_default.jpg" alt="John said" class="img-circle"></span>
                                        <div class="pull-right text-danger m-t-sm"><i class="fa fa-circle"></i></div>
                                        <div class="media-body">
                                            <div><a href="#">Daniel Osim</a></div>
                                            
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="media">
                                        <span class="pull-left thumb-sm">
                                            <img src="../../../images/avatar_default.jpg" alt="John said" class="img-circle"></span>
                                        <div class="pull-right text-danger m-t-sm"><i class="fa fa-circle"></i></div>
                                        <div class="media-body">
                                            <div><a href="#">David Osim</a></div>
                                            
                                        </div>
                                    </div>
                                </li>
                                <li class="list-group-item">
                                    <div class="media">
                                        <span class="pull-left thumb-sm">
                                            <img src="../../../images/avatar_default.jpg" alt="John said" class="img-circle"></span>
                                        <div class="pull-right text-danger m-t-sm"><i class="fa fa-circle"></i></div>
                                        <div class="media-body">
                                            <div><a href="#">Deborah Osim</a></div>
                                           <!--<small class="text-muted">about 2 minutes ago</small>-->
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </section>

                    </div>
                </div>
    <!--
    <div class="row">
        <div class="row">
            <div class="col-md-8">

                <!------CONTROL TABS START------
                <ul class="nav nav-tabs bordered">
                    <li class="active">
                        <a href="#list" data-toggle="tab"><i class="entypo-menu"></i>
                            Class Routine List                    	</a></li>
                </ul>
                <!------CONTROL TABS END------


                <div class="tab-content">
                    <!----TABLE LISTING STARTS--
                    <div class="tab-pane active" id="list">
                        <div class="panel-group joined" id="accordion-test-2">


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion-test-2" href="#collapse1" class="collapsed">
                                            <i class="entypo-rss"></i>Class One                                    </a>
                                    </h4>
                                </div>

                                <div id="collapse1" class="panel-collapse collapse" style="height: 0px;">
                                    <div class="panel-body">
                                        <table cellpadding="0" cellspacing="0" border="0" class="table table-bordered">
                                            <tbody>
                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Subjects</td>
                                                    <td width="15%">First Test</td>
                                                    <td width="15%">Second Test</td>
                                                    <td width="15%">Third Test</td>
                                                    <td width="5%">Assignments</td>
                                                    <td width="15%">Exams</td>
                                                    <td width="15%">Total</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Monday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Tuesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Wednesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Thursday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Friday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>



                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion-test-2" href="#collapse2" class="collapsed">
                                            <i class="entypo-rss"></i>Class Two                                    </a>
                                    </h4>
                                </div>

                                <div id="collapse2" class="panel-collapse collapse" style="height: 0px;">
                                    <div class="panel-body">
                                        <table cellpadding="0" cellspacing="0" border="0" class="table table-bordered">
                                            <tbody>
                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Subjects</td>
                                                    <td width="15%">First Test</td>
                                                    <td width="15%">Second Test</td>
                                                    <td width="15%">Third Test</td>
                                                    <td width="5%">Assignments</td>
                                                    <td width="15%">Exams</td>
                                                    <td width="15%">Total</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Monday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Tuesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Wednesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Thursday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Friday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>



                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion-test-2" href="#collapse3" class="collapsed">
                                            <i class="entypo-rss"></i>Class Three                                    </a>
                                    </h4>
                                </div>

                                <div id="collapse3" class="panel-collapse collapse" style="height: 0px;">
                                    <div class="panel-body">
                                        <table cellpadding="0" cellspacing="0" border="0" class="table table-bordered">
                                            <tbody>
                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Subjects</td>
                                                    <td width="15%">First Test</td>
                                                    <td width="15%">Second Test</td>
                                                    <td width="15%">Third Test</td>
                                                    <td width="5%">Assignments</td>
                                                    <td width="15%">Exams</td>
                                                    <td width="15%">Total</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Monday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Tuesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Wednesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Thursday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Friday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>



                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion-test-2" href="#collapse4" class="collapsed">
                                            <i class="entypo-rss"></i>Class Four                                    </a>
                                    </h4>
                                </div>

                                <div id="collapse4" class="panel-collapse collapse" style="height: 0px;">
                                    <div class="panel-body">
                                        <table cellpadding="0" cellspacing="0" border="0" class="table table-bordered">
                                            <tbody>
                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Subjects</td>
                                                    <td width="15%">First Test</td>
                                                    <td width="15%">Second Test</td>
                                                    <td width="15%">Third Test</td>
                                                    <td width="5%">Assignments</td>
                                                    <td width="15%">Exams</td>
                                                    <td width="15%">Total</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Monday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Tuesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Wednesday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Thursday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>

                                                <tr class="odd">
                                                    <td style="padding: 9px 15px;" width="20%">Friday</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="5%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                    <td width="15%">Contents</td>
                                                </tr>



                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!----TABLE LISTING ENDS--




                </div>
            </div>
        </div>

        <div class="col-md-4">
        </div>
    </div>
    -->

    <a href="#" class="hide nav-off-screen-block" data-toggle="class:nav-off-screen, open" data-target="#nav,html"></a>


</asp:Content>
