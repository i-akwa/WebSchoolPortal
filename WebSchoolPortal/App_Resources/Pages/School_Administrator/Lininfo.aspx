<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="Lininfo.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.Lininfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <div class="panel panel-body">

        <section class="panel panel-body">
            <div class="col-md-12 col-xs-12 row" style="margin: 5px">
                <div class="col-md-10 col-xs-10 row col-lg-10">
                    <asp:DropDownList ID="classes" runat="server" CssClass="dropdown form-control dropdown-menu-left "></asp:DropDownList>
                    <asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged" />
                    <hr />
                    <br />
                </div>
                <div class="col-md-2 col-xs-2 col-xs-2">
                    <asp:Button ID="search" CssClass="btn btn-success form-control" runat="server" Text="Search" OnClick="search_Click" />
                </div>
            </div>

            <div class="panel-body">
                <asp:GridView ID="grdView" Font-Size="Smaller" HeaderStyle-Font-Bold="false" OnRowCommand="grdView_RowCommand" AllowPaging="true" PageSize="100"
                    OnPageIndexChanging="grdView_PageIndexChanging" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-hover table-responsive">

                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="User Name"></asp:BoundField>
                        <asp:BoundField DataField="Password" HeaderText="Password"></asp:BoundField>
                        <asp:BoundField DataField="name" HeaderText="Student Name" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="IsApproved" HeaderText="Is Active"></asp:BoundField>

                        <asp:BoundField DataField="class" HeaderText="class" SortExpression="class"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="toggle" runat="server" Text="Toggle Enable" CssClass="btn btn-link btn-success" CommandArgument='<%#Bind("UserId") %>' CommandName="updateActive" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>


        </section>
    </div>
</asp:Content>
