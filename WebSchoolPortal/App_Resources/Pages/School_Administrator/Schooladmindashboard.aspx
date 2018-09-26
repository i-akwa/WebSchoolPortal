<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="Schooladmindashboard.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.Schooladmindashboard" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

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

                                <asp:Label ID="regStud" runat="server"></asp:Label></strong></span> <small class="text-muted text-uc">Registered Students</small> </a>
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
                        <asp:GridView ID="Teachers" CssClass="table table-responsive table-hover table-striped table-bordered" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                             PageSize="10" OnPageIndexChanging="Teachers_PageIndexChanging" >
                            <Columns>
                                <asp:BoundField HeaderText="Teacher Name" DataField="TeacherName" />
                                <asp:BoundField HeaderText="Subject" DataField="SubjectName" />
                                <asp:BoundField HeaderText="Class" DataField="class" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
        <a href="#" class="hide nav-off-screen-block" data-toggle="class:nav-off-screen, open" data-target="#nav,html"></a>

</asp:Content>
