<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="studentdashboard.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Student.studentdashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

    
    <div class="m-b-md">

        <small>Welcome back</small>
    </div>
    <div class="panel panel-default">



        <div class="row m-l-none m-r-none bg-light lter">
            <div class="col-sm-6 col-md-3 padder-v b-r b-light"><span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x text-info"></i><i class="fa fa-male fa-stack-1x text-white"></i></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong>52,000</strong></span> <small class="text-muted text-uc">New robots</small> </a></div>
            <div class="col-sm-6 col-md-3 padder-v b-r b-light lt">
                <span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x text-warning"></i><i class="fa fa-bug fa-stack-1x text-white"></i><span style="width: 50px; height: 50px; line-height: 50px;" class="easypiechart pos-abt easyPieChart" data-percent="100" data-line-width="4" data-track-color="#fff" data-scale-color="false" data-size="50" data-line-cap="butt" data-animate="2000" data-target="#bugs" data-update="3000">
                    <canvas width="50" height="50"></canvas>
                </span></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong id="bugs">2666</strong></span> <small class="text-muted text-uc">Bugs intruded</small> </a>
            </div>
            <div class="col-sm-6 col-md-3 padder-v b-r b-light">
                <span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x text-danger"></i><i class="fa fa-fire-extinguisher fa-stack-1x text-white"></i><span style="width: 50px; height: 50px; line-height: 50px;" class="easypiechart pos-abt easyPieChart" data-percent="100" data-line-width="4" data-track-color="#f5f5f5" data-scale-color="false" data-size="50" data-line-cap="butt" data-animate="3000" data-target="#firers" data-update="5000">
                    <canvas width="50" height="50"></canvas>
                </span></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong id="firers">1759</strong></span> <small class="text-muted text-uc">Extinguishers ready</small> </a>
            </div>
            <div class="col-sm-6 col-md-3 padder-v b-r b-light lt"><span class="fa-stack fa-2x pull-left m-r-sm"><i class="fa fa-circle fa-stack-2x icon-muted"></i><i class="fa fa-clock-o fa-stack-1x text-white"></i></span><a class="clear" href="#"><span class="h3 block m-t-xs"><strong>31:50</strong></span> <small class="text-muted text-uc">Left to exit</small> </a></div>
        </div>
    </div>
   
     <div class="row">

         <div class="col-md-8 ">

           
    <div class="panel panel-default">
        <header class="panel-heading"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>Class routine list</header>
        <div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">
                <div class="row">




                    <div class="col-sm-6" style="height: 54px;">
                        <header class="panel-heading" style="margin-top: 1px; font-size: 24px;"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>Class 1</header>
                    </div>
                  
                </div>
                <table class="table table-bordered table-responsive table-hover" aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">

                    <tbody>
                         <tr class="odd">
                            <td style="padding: 9px 15px;" width="20%">Days</td>
                            <td width="15%">Time</td>
                            <td width="15%">Time</td>
                            <td width="15%">Time</td>
                            <td width="5%">Time</td>
                            <td width="15%">Time</td>
                            <td width="15%">Time</td>
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
                <header class="panel-heading"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>
                <div class="row" style="margin-bottom: -25px;">
                    <div class="col-sm-6">
                        
                    </div>
                    <div class="col-sm-6">
                        <div id="DataTables_Table_0_paginate" class="dataTables_paginate paging_full_numbers">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            
               </div>
                        


        <div class="col-md-4 col-xs-12">
                        <section class="panel panel-default">
                            <header class="panel-heading"> Teachers </header>

                            <header class="panel-heading">
                              
                                  <div class="input-group text-sm">
                                    <input class="input-sm form-control" placeholder="Search" type="text">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-default dropdown-toggle" data-toggle="dropdown">Action <span class="caret"></span></button>
                                        <ul class="dropdown-menu pull-right">
                                            <li><a href="#">Action</a></li>
                                            <li><a href="#">Another action</a></li>
                                            <li><a href="#">Something else here</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#">Separated link</a></li>
                                        </ul>
                                    </div>
                                </div>

                            </header>
                            
                           
                                <asp:GridView ID="SSCT" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" AutoGenerateEditButton="false" AllowPaging="true" OnPageIndexChanging="SSCT_PageIndexChanging" CssClass="panel-body table table-responsive table-hover col-xs-12 " Width="100%" GridLines="None">
                                    <Columns>
                                        <asp:BoundField HeaderText="Teacher Name" DataField="TeacherName" HeaderStyle-BackColor="#E8E8E8" />
                                        <asp:BoundField HeaderText="Subject Handled" DataField="SubjectName" HeaderStyle-BackColor="#E8E8E8" />
                                    </Columns>
                                </asp:GridView>
                     
                        </section>

                    </div>

          </div>
   
     <div class="row">
        
        
         <div class="col-md-8 ">

           
    <div class="panel panel-default">
        <header class="panel-heading"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>Present Term Assesment Sheet</header>
        <div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="Div1">
                <div class="row">




                    <div class="col-sm-6" style="height: 54px;">
                        <header class="panel-heading" style="margin-top: 1px; font-size: 24px;"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>Class 1</header>
                    </div>
                  
                </div>
                <table class="table table-bordered table-responsive table-hover" aria-describedby="DataTables_Table_0_info" role="grid" id="Table1" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">

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
                <header class="panel-heading"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>
                <div class="row" style="margin-bottom: -25px;">
                    <div class="col-sm-6">
                        
                    </div>
                    <div class="col-sm-6">
                        <div id="Div2" class="dataTables_paginate paging_full_numbers">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            
               </div>
                        


        <div class="col-md-4 ">
            <section class="panel b-light">
                <header class="panel-heading bg-primary dker no-border"><strong>Calendar</strong></header>
                <div id="Div3" class="bg-primary m-l-n-xxs m-r-n-xxs">
                    <div class="calendar" id="Div4">
                        <table class="table header">
                            <tbody>
                                <tr></tr>
                            </tbody>
                            <tbody>
                                <tr>
                                    <td><i class="fa fa-arrow-left"></i></td>
                                    <td colspan="5" class="year span6">
                                        <div class="visualmonthyear">July 2016</div>
                                    </td>
                                    <td><i class="fa fa-arrow-right"></i></td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="daysmonth table table">
                            <tbody>
                                <tr class="week_days">
                                    <td class="first">S</td>
                                    <td>M</td>
                                    <td>T</td>
                                    <td>W</td>
                                    <td>T</td>
                                    <td>F</td>
                                    <td class="last">S</td>
                                </tr>
                                <tr>
                                    <td class="invalid first"></td>
                                    <td class="invalid"></td>
                                    <td class="invalid"></td>
                                    <td class="invalid"></td>
                                    <td class="invalid"></td>
                                    <td id="Td1"><a>1</a></td>
                                    <td id="Td2" class="last"><a>2</a></td>
                                </tr>
                                <tr>
                                    <td id="Td3" class="first"><a>3</a></td>
                                    <td id="Td4"><a>4</a></td>
                                    <td id="Td5"><a>5</a></td>
                                    <td id="Td6"><a>6</a></td>
                                    <td id="Td7"><a>7</a></td>
                                    <td id="Td8"><a>8</a></td>
                                    <td id="Td9" class="last"><a>9</a></td>
                                </tr>
                                <tr>
                                    <td id="Td10" class="first"><a>10</a></td>
                                    <td id="Td11"><a>11</a></td>
                                    <td id="Td12"><a>12</a></td>
                                    <td id="Td13"><a>13</a></td>
                                    <td id="Td14"><a>14</a></td>
                                    <td id="Td15"><a>15</a></td>
                                    <td id="Td16" class="last"><a>16</a></td>
                                </tr>
                                <tr>
                                    <td id="Td17" class="first"><a>17</a></td>
                                    <td id="Td18"><a>18</a></td>
                                    <td id="Td19"><a>19</a></td>
                                    <td id="Td20"><a>20</a></td>
                                    <td id="Td21"><a>21</a></td>
                                    <td id="Td22"><a>22</a></td>
                                    <td id="Td23" class="last"><a>23</a></td>
                                </tr>
                                <tr>
                                    <td id="Td24" class="first"><a>24</a></td>
                                    <td id="Td25"><a>25</a></td>
                                    <td id="Td26"><a>26</a></td>
                                    <td id="Td27"><a>27</a></td>
                                    <td id="Td28"><a>28</a></td>
                                    <td id="Td29"><a>29</a></td>
                                    <td id="Td30" class="last"><a>30</a></td>
                                </tr>
                                <tr>
                                    <td id="Td31" class="first"><a>31</a></td>
                                    <td class="invalid"></td>
                                    <td class="invalid"></td>
                                    <td class="invalid"></td>
                                    <td class="invalid"></td>
                                    <td class="invalid"></td>
                                    <td class="invalid last"></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="list-group"><a href="#" class="list-group-item text-ellipsis"><span class="badge bg-danger">7:30</span> Meet a friend </a><a href="#" class="list-group-item text-ellipsis"><span class="badge bg-success">9:30</span> Have a kick off meeting with .inc company </a><a href="#" class="list-group-item text-ellipsis"><span class="badge bg-light">19:30</span> Milestone release </a></div>
            </section>

        </div>
      
         
          </div>


    <a href="#" class="hide nav-off-screen-block" data-toggle="class:nav-off-screen, open" data-target="#nav,html"></a>



</asp:Content>
