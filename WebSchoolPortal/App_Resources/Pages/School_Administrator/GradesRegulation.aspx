<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="GradesRegulation.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.Grades_Regulation" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <section class="panel panel-default">
        <div class="panel-heading">Grades Regulation</div>
        <div class="panel-body">
            <div class="col-md-6 col-sm-12">
            <div class="table table-responsive ">
                <table class="table table-responsive">
                    <tr>
                        <td>
                            <label>School ID:</label></td>
                        <td>
                            <asp:TextBox ID="SchoolId" runat="server" CssClass="form-control" ReadOnly="true" />
                            <asp:RequiredFieldValidator ControlToValidate="SchoolId" runat="server" ID="RfvSchool" ErrorMessage="Required" ValidationGroup="Grades" ToolTip="Required" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Upper Limits</label></td>
                        <td>
                            <asp:TextBox ID="UpperLimits" runat="server" CssClass="form-control" /><asp:RequiredFieldValidator ID="Uplim" runat="server" ErrorMessage="Required" Text="*" ForeColor="Red" ValidationGroup="Grades" ControlToValidate="UpperLimits" /> </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Lower Limits</label></td>
                        <td>
                            <asp:TextBox ID="LowerLimits" runat="server" CssClass="form-control" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label>Grades</label></td>
                        <td>
                            <asp:TextBox ID="Grades" runat="server" CssClass="form-control" Style="text-transform: uppercase" /></td>
                    </tr>
                     <tr>
                        <td>
                            <label>Remarks</label></td>
                        <td>
                            <asp:TextBox ID="Remark" runat="server" CssClass="form-control" Style="text-transform: uppercase" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                        <td>
                            <asp:LinkButton ID="Insert" runat="server" Text="Insert" CssClass="btn btn-success pull-right" OnClick="Insert_Click"> <i class="fa fa-save"></i>&nbsp;Insert</asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="Update" runat="server" Text="Insert" CssClass="btn btn-success pull-right" OnClick="Update_Click"> <i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                            <asp:Label ID="lblGradesId" runat="server" Visible="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            </div>
            <div class="col-md-6 col-sm1-2">

                <div class="table table-responsive">
                    <asp:GridView ID="viewGrades" runat="server" AllowPaging="false" AutoGenerateColumns="false" OnRowCommand="viewGrades_RowCommand" PageSize="10" CssClass="table table-responsive table-bordered table-hover" GridLines="None" OnSelectedIndexChanged="viewGrades_SelectedIndexChanged" >
                        <Columns>
                            <asp:BoundField HeaderText="S/N" DataField="GradesId" Visible="true" />
                            <asp:BoundField HeaderText="Grade" DataField="Grades"/>
                            <asp:BoundField HeaderText="Upper Limit" DataField="UpperLimit" />
                            <asp:BoundField HeaderText="Lower limit" DataField="LowerLimit" />
                            <asp:BoundField HeaderText="Remark" DataField="Remark" Visible="true" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="btn btn-sm btn-danger"  ID="change" runat="server" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="upd" Text="Update" >&nbsp;<i class="fa fa-edit danger"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div> 
        </div>
    </section>
  
</asp:Content>
