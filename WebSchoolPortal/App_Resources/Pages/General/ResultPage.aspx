<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="ResultPage.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.ResultPage" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

      <link href="../../js/datatables/datatables.css" rel="stylesheet" />
    
    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!</strong>Fill in the required student information  to view the student's result... <a href="#" class="alert-link"></a></span>
        </div>

    <section class="panel panel-default">
        <header class="panel-heading font-bold">View Result And Assesment<asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged" />  </header>
        <div class="panel-body">
            <div class="form" role="form">
                <div class="col-md-2 col-sm-12">
                <div class="form-group">

                    <asp:TextBox runat="server" ReadOnly="true" ID="SchoolId" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                        ControlToValidate="SchoolId" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                </div>
                    </div>
                <div class="col-md-2 col-sm-12">
                    <div class="form-group">
                       <asp:DropDownList runat="server" ID="ddlClass"  CssClass="form-control" placeholder="Class" />

                    </div>
                </div>

                <div class="col-md-2 col-sm-12">
                    <div class="form-group">
                       <asp:DropDownList runat="server" CssClass="form-control" ID="Arms" Width="100%"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                            ControlToValidate="Arms" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                    </div>
                </div>

                <div class="col-md-2 col-sm-12">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="Term" TextMode="SingleLine" CssClass="form-control" placeholder="Term" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                            ControlToValidate="Term" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                    </div>
                </div>

                <div class="col-md-2 col-sm-12">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="Year" TextMode="SingleLine" CssClass="form-control" placeholder="Year" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                            ControlToValidate="Year" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />

                    </div>
                </div>
                <div class="col-md-2 col-sm-12">
                    <asp:Button ID="Viewresult" ValidationGroup="aaaa" CssClass="btn btn-success" runat="server" Text="Search" OnClick="Viewresult_Click" />
                </div>

            </div>
        </div>
    </section>

    <section class="panel panel-default">
        
        <div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">

               
                 <table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
                    <thead>
                    </thead>
                    <tbody>
                        <asp:GridView ID="ResultList" runat="server" AllowPaging="true" AllowSorting="true" PageSize="200" Width="100%" AutoGenerateColumns="false" 
                            OnPageIndexChanging="ResultList_PageIndexChanging" Caption="RESULTS" EmptyDataText="Please Enter Search Parameters" 
                            EmptyDataRowStyle-CssClass="alert-danger" EmptyDataRowStyle-ForeColor="red" GridLines="None" OnRowCommand="ResultList_RowCommand" CssClass=" table table-responsive table table-hover">
                            <Columns>
                                <asp:BoundField HeaderText="Roll Number" DataField="StudentRollNumber"  />
                                <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                                <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                                <asp:BoundField HeaderText="Test Scores" DataField="TestTotal" NullDisplayText="Not Inserted"  />
                                <asp:BoundField HeaderText="Exams Scores" DataField="ExamsTotal" NullDisplayText="Not Inserted"  />
                                <asp:BoundField HeaderText="Total" DataField="total" NullDisplayText="Not Inserted"  />
                                <asp:BoundField HeaderText="Taken Test" DataField="NumberOftest" NullDisplayText="Not Inserted" />
                                <asp:BoundField HeaderText="Taken Exams" DataField="NumberOfExams" NullDisplayText="Not Inserted"  />
                                <asp:TemplateField HeaderText="" HeaderStyle-BackColor="#E8E8E8">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="view" CssClass="btn btn-Link btn-success" Text="View" CommandName="view" CommandArgument='<%#Bind("StudentRollNumber") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                       
                    </tbody>
                </table>
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