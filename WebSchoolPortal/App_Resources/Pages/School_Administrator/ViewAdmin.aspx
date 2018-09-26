<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="ViewAdmin.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.ViewAdmin" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!</strong>Fill in the required date the attendance was taken to view recorded attendance <a href="#" class="alert-link"></a></span>

        </div>
    <section class="panel panel-default">
        <div class="panel-heading">View Attendance<label class="caption pull-right">other classes</label><asp:CheckBox runat="server" ID="ClasCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClasCheck_CheckedChanged"  /></div>
        <div class="panel-body">
            <div class="table table-responsive">
                <table class="table table-responsive">
                    <tr>
                        <td>
                            <label>School lD</label></td>
                        <td>
                            <asp:TextBox ID="schoolId" runat="server" CssClass="form-control" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label>Class</label></td>
                        <td>
                            <asp:DropDownList ID="clas" runat="server" CssClass="form-control">
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Arm</label></td>
                        <td>
                            <asp:DropDownList ID="arm" runat="server" DataSourceID="SqlDataSource1" DataTextField="Arm" DataValueField="ArmsId" CssClass="form-control" />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolPortalConnectionString %>" SelectCommand="SELECT [ArmsId], [Arm] FROM [armsTable] WHERE ([SchoolId] = @SchoolId)">
                                <SelectParameters>
                                    <asp:CookieParameter CookieName="SchoolId" Name="SchoolId" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Date</label></td>
                        <td>
                            <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Culture="en-GB" CssClass="form-control">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" CssClass="btn btn-success pull-right" /></td>
                    </tr>
                </table>
            </div>

            <div class="table table-responsive">
                <asp:GridView ID="viewAttaindance" CssClass="table table-responsive table-hover" EmptyDataText="No record found for this inserted date" EmptyDataRowStyle-CssClass="alert-danger" EmptyDataRowStyle-ForeColor="Red"  runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="30" OnPageIndexChanging="viewAttaindance_PageIndexChanging" Width="100%" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="Date" DataField="DaysDate" ItemStyle-ForeColor="DarkGreen"  />
                        <asp:BoundField HeaderText="Name" DataField="name"   />
                        <asp:BoundField HeaderText="Day" DataField="Day" />
                        <asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-ForeColor="#0000cc"  />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </section> 
  
</asp:Content>
