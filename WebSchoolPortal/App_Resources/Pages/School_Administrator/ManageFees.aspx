<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="ManageFees.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.ManageFees" %>
<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <link href="../../js/datatables/datatables.css" rel="stylesheet" />
    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!</strong> Please insert 'New-St' for New Student, 'Bor-St' for boarding Students and 'S-New-St' for New Senior Students. This is not to add fresh fees for those categories, but to insert additional charges for the categories. <br /><b>example :</b> If a new student in JSS1 pays #50,000 for his/her fees, lets say #40,000 will be the actuall JSS1 fees and #10,000 will be the 'New-St' fees.  <a href="#" class="alert-link"></a></span>

        </div>
    <section class="panel panel-default">
        <header class="panel-heading">FEES REGULATION <i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>
            <label class="caption pull-right">other classes

            </label><asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged" />

        </header><div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">
                <div class="row">
                    <div class="col-md-3">

                        <div id="DataTables_Table_0_length" class="dataTables_length">
                            <asp:TextBox ID="SchoolId" runat="server" CssClass="input-control text form-control input-lg input-group" ReadOnly="true" />

                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="dataTables_length">
                            <asp:DropDownList ID="ClassList" runat="server"  CssClass="form-control m-b dropDown-menu" Width="100%">
                                
                                </asp:DropDownList>
                            <asp:Label ID="lblClass" runat="server" Text="" ></asp:Label>
                            <asp:HiddenField ID="HiddenClassId" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div id="DataTables_Table_0length" class="dataTables_length">

                            <asp:TextBox ID="InsertFees" placeholder="Enter Amount" runat="server" CssClass="input-control text form-control input-lg input-group" />

                        </div>
                    </div>

                    <div class="col-md-3">
                        <div id="DataTables_Table_ 0length" class="dataTables_length">
                            <asp:Button ID="Insert" runat="server" CausesValidation="true" Text="Add" OnClick="Insert_Click" CssClass="btn btn-success btn-block" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return confirm('Are you sure you want to save changes?');" OnClick="btnUpdate_Click" CssClass="btn btn-success btn-block" />

                        </div>
                    </div>

                    <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">Processing...</div></div><table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
                    <thead>
                    </thead>
                    <tbody>
                        <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="false" AutoGenerateEditButton="false" CssClass=" table table-responsive table-hover " GridLines="None" OnRowCommand="grid1_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Class" HeaderText="Class"  />
                                <asp:BoundField DataField="Amount" HeaderText="Amount"  />
                                <asp:TemplateField HeaderText="Action" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Edit" runat="server" Text="Edit" CommandName="Edt" class="btn btn-xs btn-primary" CommandArgument='<%# Bind("FeesId") %>' ><i class="fa fa-edit"></i>&nbsp;Edit</asp:LinkButton></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Action" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Delete" runat="server" Text="Delete" CommandName="Del" class="btn btn-xs btn-primary" CommandArgument='<%# Bind("FeesId") %>' OnClientClick="return confirm('Are you sure you want to delete the record?');" ><i class="fa fa-cut"></i>&nbsp;Delete</asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></tbody></table><div class="row">
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