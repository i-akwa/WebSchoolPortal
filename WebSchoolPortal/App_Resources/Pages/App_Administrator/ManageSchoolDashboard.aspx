<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="ManageSchoolDashboard.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.App_Administrator.ManageSchoolDashboard" %>
<%@ Register Src="~/App_Resources/UserControl/Calender1.ascx" TagPrefix="uc1" TagName="Calender1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
        <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1><i class="fa fa-laptop"></i>Automated School Management System</h1>
                    <div class="alert alert-success alert-dismissable">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        <i class="fa fa-fw fa-gears"></i>  Welcome to the Automated School Admin Dashboard! Feel free to monitor all pages and applications  interfaces on one single  layout. 
                        <br />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="panel panel-default ">
                        <div class="panel-body alert-info">
                            <div class="col-xs-5">
                                <i class="fa fa-building fa-5x"></i>
                            </div>
                            <div class="col-xs-5 text-right">
                                <p class="alerts-heading"><asp:Label ID="TotalSchools" runat="server"/></p>
                                <p class="welcome_header"><asp:LinkButton ID="link2" runat="server">Total Registerd Schools</asp:LinkButton></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="panel panel-default ">
                        <div class="panel-body alert-info">
                            <div class="col-xs-5">
                                <i class="fa fa-users fa-5x"></i>
                            </div>
                            <div class="col-xs-5 text-right">
                                <p class="alerts-heading"><asp:Label ID="TotalStudents" runat="server"/></p>
                                <p class="welcome_header"><asp:LinkButton ID="Link3" runat="server">Total Registered Students</asp:LinkButton></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="panel panel-default ">
                        <div class="panel-body alert-info">
                            <div class="col-xs-5">
                                <i class="fa fa-male fa-2x fa fa-university fa-5x"></i>
                            </div>
                            <div class="col-xs-5 text-right">
                                <p class="alerts-heading"><asp:Label ID="ActiveSchools" runat="server"></asp:Label></p>
                                <p class="welcome_header"><asp:LinkButton ID="Link1" runat="server">Active Registered Schools</asp:LinkButton></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8 col-sm-12" >
                    <div class="panel b-light">
                        <div class="panel-heading bg-primary dker no-border">
                            <h3 class="panel-title"><i class="fa fa-fw fa-user"></i> Latest Student Registration</h3>
                        </div>
                        <div class="panel-body">
                            <div class="table table-responsive">
                                <asp:GridView ID="LatestStudent" runat="server" AutoGenerateColumns="False" CssClass="panel-body table table-responsive table-hover  " Width="100%" GridLines="None" >

                                    <Columns>
                                        <asp:BoundField HeaderText="Student Name" DataField="Name"  >
<ItemStyle></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Student ID" DataField="StudentRollNumber"  >
<ItemStyle></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="School Id" DataField="SchoolId"  >
<ItemStyle ></ItemStyle>
                                        </asp:BoundField>
                                        <%--<asp:BoundField HeaderText="Present Class" DataField="PresentClass" />--%>
                                        <asp:BoundField HeaderText="Registration Date" DataField="Date" >
<ItemStyle ></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="School Name" DataField="SchoolName"  >
<ItemStyle ></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                   <%-- <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                    <SortedDescendingHeaderStyle BackColor="#3E3277" />--%>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                     <section class="panel b-light">
                            <header class="panel-heading bg-primary dker no-border"><strong>Calendar</strong></header>
                            <div id="calendar" class="bg-primary m-l-n-xxs m-r-n-xxs"></div>
                            <div class="list-group">
                                <a href="#" class="list-group-item text-ellipsis">
                                    <span class="badge bg-danger">7:30</span>
                                    School Starts
                                </a>
                                
                            </div>
                        </section> 

                    
                </div>
            </div>

            <div class="row">
              
                <div class="col-lg-12 col-sm-12">
                    <div class="panel b-light">
                        <div class="panel-heading bg-primary dker ">
                            <h3 class="panel-tittle"><i class="fa fa-fw fa-gears"></i> Active Schoools</h3>
                        </div>
                        <div class="panel-body">
                            <div class="table table-responsive">
                                <asp:GridView ID="activeSchool" runat="server"  AutoGenerateColumns="False" OnRowCommand="activeSchool_RowCommand" CssClass="panel-body table table-responsive table-hover  " Width="100%" GridLines="None" PageSize="40" >
                                    
                                    <Columns>
                                        <asp:BoundField HeaderText="School Name" DataField="SchoolName" />
                                        <asp:BoundField HeaderText="School Id" DataField="SchoolId" />
                                        <asp:BoundField HeaderText="School Email" DataField="SchoolEmailAdress" />
                                        <asp:BoundField HeaderText="School Phone-Number" DataField="SchoolPhoneNumber" />
                                        <asp:BoundField HeaderText="Number Of Student" DataField="countStudentInSchool" />

                                        <asp:TemplateField HeaderText="Activate">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="isApproved" runat="server" AutoPostBack="true" Text='<%#(Eval("IsApproved")) %>' CommandName="act"
                                                     CommandArgument='<%#Bind("SchoolEmailAdress") %>' CssClass="btn btn-xs btn-success" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                   <%-- <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                    <SortedDescendingHeaderStyle BackColor="#3E3277" />--%>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-fw fa-gears"></i> Put things Here</h3>
                        </div>
                        <div class="panel-body">
                            <div id="Div4">
                                <p>
                                    <asp:Repeater ID="SortReapeater" runat="server" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Sort" runat="server" Text='<%# Container.DataItem %>' CommandName='<%# Container.DataItem %>'>></asp:LinkButton>
                                        </ItemTemplate>
                                        <SeparatorTemplate>|</SeparatorTemplate>
                                    </asp:Repeater>
                                </p>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Font-Underline="True"></asp:Label>
        </div>

</asp:Content>
