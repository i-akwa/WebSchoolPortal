<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="StudentArmPage.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.StudentArmPage" %>
<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

    <link href="../../js/datatables/datatables.css" rel="stylesheet" />

    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!</strong> Here You can change stundents class at the end of the term or academic year, by class, individually or arm...<a href="#" class="alert-link"></a></span>

        </div>

   
    <section class="panel panel-default">
        <header class="panel-heading">Edit Students Class And Arm <i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i><label class="caption pull-right">other classes</label>
            <asp:CheckBox runat="server" ID="ClasCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClasCheck_CheckedChanged"  /></header>
       
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">
                <div class="row">
                    <div class="col-sm-4">

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [ArmsId], [Arm] FROM [armsTable] WHERE ([SchoolId] = @SchoolId)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="SchoolId" Name="SchoolId" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <div id="DataTables_Table_0_length" class="dataTables_length">
                            <asp:TextBox ID="SchoolId" runat="server" Placeholder="Enter School ID" CssClass="form-control input-lg input-group" Enabled="false" ReadOnly="true" />

                        </div>
                    </div>
                    <div class="col-sm-4">


                        <div  class="dataTables_length" >
                            <asp:DropDownList ID="Class" runat="server" CssClass="form-control m-b dropDown-menu" Width="100%">
                                
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-sm-4">
                        <div id="DataTables_Table_0length" class="dataTables_length">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-block" OnClick="Button1_Click" Text="Search" />

                        </div>
                    </div>
                    <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">Processing...</div>
                </div>
                <div class="table-responsive">
                    <table class="table table-responsive" aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
                        <thead>
                        </thead>
                        <tbody>
                            <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound"  CssClass=" table table-responsive table-hover" runat="server"
                                 GridLines="None" EmptyDataText="No student in this class" EmptyDataRowStyle-CssClass="alert-danger" EmptyDataRowStyle-ForeColor="Red"
                                 AutoGenerateColumns="false" Width="100%" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:BoundField HeaderText="Roll Number" DataField="StudentRollNumber" />
                                    <asp:BoundField HeaderText="Student Name" DataField="name" />
                                    <asp:BoundField HeaderText="Present Class" DataField="class" />
                                    <asp:TemplateField HeaderText="NewClass">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlClasses" DataTextField="" runat="server" style="text-transform:uppercase" Width="90%"  >
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Arms">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="Arms" runat="server" Width="90%"
                                                DataSourceID="aarms" DataTextField="Arm" DataValueField="ArmsId">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="insert" runat="server" Text="insert" class="btn btn-xs btn-primary" CommandArgument='<%# Bind("StudentRollNumber") %>' CommandName="Ins" CausesValidation="false"><i class="fa fa-save"></i>&nbsp;update</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </tbody>
                    </table>

                </div>
            </div>
        <asp:Button ID="Insertall" runat="server" CssClass="btn btn-success btn-block pull-right" Text="Update All" OnClick="Insertall_Click" />

        <div class="clear clearfix">
        </div>
        <div style="margin-top:60px;"></div>
    
    </section>


   
   

    <table class="table table-responsive table-hover" style="display: none;">

        <asp:SqlDataSource ID="aarms" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [ArmsId], [Arm] FROM [armsTable] WHERE ([SchoolId] = @SchoolId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="SchoolId" Name="SchoolId" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <tr>
            <td></td>
            <td>
                <div>
                    <span><b>School ID</b></span>
                </div>
                <%--<asp:TextBox ID="SchoolId" runat="server" />--%>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <div>
                    <span><b>Select Class</b></span>
                </div>
               
            &nbsp;
                <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />--%>
            &nbsp;&nbsp;
                <%--<asp:Button ID="Insertall" runat="server" Text="Insert Multiple"  BackColor="#ff9900" ForeColor="White" OnClick="Insertall_Click"/>--%>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="padding-top: 10px">
               
            </td>
            <td></td>
        </tr>
    </table>

</asp:Content>

