<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Teachers.Attendance" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <link href="../../js/datatables/datatables.css" rel="stylesheet" />

    <div class="alert alert-success">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><strong>Heads up!</strong> <a href="#" class="alert-link">View Students Result:</a> Fill in the required student information  to view the student's result... </div>
   
   
    <section class="panel panel-default">
        <header class="panel-heading">Attendance Management <label class="caption pull-right">other classes</label><asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged"/></header>
        <div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">
                <div class="row">
                    <div class="col-sm-4">
                        <div id="DataTables_Table_0_length" class="dataTables_length">
                            <span>Class</span><asp:DropDownList ID="ddlClass" Width="100%" runat="server" DataTextField="class" DataValueField="class" CssClass="form-control input-lg input-group">
                                <asp:ListItem Text="JSS1"></asp:ListItem>
                                <asp:ListItem Text="JSS2"></asp:ListItem>
                                <asp:ListItem Text="JSS3"></asp:ListItem>
                                <asp:ListItem Text="SSS1"></asp:ListItem>
                                <asp:ListItem Text="SSS2"></asp:ListItem>
                                <asp:ListItem Text="SSS3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="dataTables_length" >
 <span>Arm</span> <asp:DropDownList ID="ddlArm" runat="server" CssClass="form-control input-lg input-group" Width="100%" /><asp:Label ID="SchoolId" CssClass="label label-default" runat="server" /> &nbsp;
                    <asp:Label ID="lblDateSticker" CssClass="label label-default" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div id="DataTables_Table_0length" class="dataTables_length">
                            <span>&nbsp;</span>
                             <asp:Button ID="btnSearch" CssClass="btn btn-success btn-block" runat="server" Text="Search" OnClick="btnSearch_Click" />
        
                        </div>
                    </div>
                    <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">Processing...</div>
                </div>
                <table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
                    <thead>
                    </thead>
                    <tbody>
                        <asp:GridView ID="grvAtt"  EmptyDataText="No Records  Found" runat="server" AutoGenerateColumns="false" CssClass="table-bordered table table-responsive" Width="100%" AllowPaging="true" OnPageIndexChanging="grvAtt_PageIndexChanging">
                        
                            <Columns>
                        <asp:BoundField HeaderText="Roll Number" DataField="StudentRollNumber"  HeaderStyle-BackColor="#E8E8E8" />
                        <asp:BoundField HeaderText="Studnt Name" DataField="Name" HeaderStyle-BackColor="#E8E8E8" />
                        <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#E8E8E8">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkStatus" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                            
                        </asp:GridView>
                    </tbody>
                </table>
                <div class="col-sm-12 col-md-12">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-success btn-block" runat="server" Text="Insert" OnClick="btnSubmit_Click" />
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <div aria-live="polite" role="status" id="DataTables_Table_0_info" class="dataTables_info"></div>
                    </div>
                    <div class="col-sm-6">
                        <!-- <div id="DataTables_Table_0_paginate" class="dataTables_paginate paging_full_numbers"><a id="DataTables_Table_0_first" tabindex="0" data-dt-idx="0" aria-controls="DataTables_Table_0" class="paginate_button first disabled">First</a><a id="DataTables_Table_0_previous" tabindex="0" data-dt-idx="1" aria-controls="DataTables_Table_0" class="paginate_button previous disabled">Previous</a><span></span><a id="DataTables_Table_0_next" tabindex="0" data-dt-idx="2" aria-controls="DataTables_Table_0" class="paginate_button next disabled">Next</a><a id="DataTables_Table_0_last" tabindex="0" data-dt-idx="3" aria-controls="DataTables_Table_0" class="paginate_button last disabled">Last</a></div>
                    -->
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
 