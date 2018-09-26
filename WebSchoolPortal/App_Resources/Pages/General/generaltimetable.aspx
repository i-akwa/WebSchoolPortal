<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="generaltimetable.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.generaltimetable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

 
    <div class="alert alert-success">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><strong>Heads up!</strong> <a href="#" class="alert-link">Timetable  Management:</a> Ensure That All The Subjects Offered In Your School Is Carefully And Correctly Inserted With Thier Allocated Teaching Time,Thanks... </div>
            
    <div class="m-b-md">
        <small>Welcome back, </small>
    </div>
   <div class="col-md-12 col-xs-12">

            <!------CONTROL TABS START------>
            <ul class="nav nav-tabs bordered">
                <li class="active">
                    <a href="#list" data-toggle="tab"><i class="entypo-menu"></i>
                        Class Routine List                    	</a></li>
            </ul>
            <!------CONTROL TABS END------>


            <div class="tab-content">
                <!----TABLE LISTING STARTS-->
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
                                    <div class="table table-responsive">
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


                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion-test-2" href="#collapse2" class="collapsed">
                                        <i class="entypo-rss"></i>Class Two                                    </a>
                                </h4>
                            </div>

                            <div id="collapse2" class="panel-collapse collapse" style="height: 0px;">
                                <div class="panel-body">
                                    <div class="table table-responsive">
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


                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion-test-2" href="#collapse3" class="collapsed">
                                        <i class="entypo-rss"></i>Class Three                                    </a>
                                </h4>
                            </div>

                            <div id="collapse3" class="panel-collapse collapse" style="height: 0px;">
                                <div class="panel-body">
                                    <div class="table table-responsive">
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


                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion-test-2" href="#collapse4" class="collapsed">
                                        <i class="entypo-rss"></i>Class Four                                    </a>
                                </h4>
                            </div>

                            <div id="collapse4" class="panel-collapse collapse" style="height: 0px;">
                                <div class="panel-body">
                                    <div class="table table-responsive"></div>
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
                </div>
                <!----TABLE LISTING ENDS-->




            </div>
        </div>


</asp:Content>
