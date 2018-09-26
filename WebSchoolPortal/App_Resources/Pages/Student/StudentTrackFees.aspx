<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="StudentTrackFees.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Student.StudentTrackFees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

    <section class="panel panel-default">
        <header class="panel-heading">Track Fees</header>
        <div class="panel-body">
            <p class="">
                <%--Put gridview down here--%>
            </p>
        </div>
    </section> 

    
    <div class="modal-dialog">
        <div class="modal-content">
            <header class="header b-b b-light hidden-print"> <button  class="btn btn-sm btn-info pull-right" onclick="window.print();">Print</button> <p>Invoice</p> </header>
            <div class="modal-header">
                <div class="modal-body" id="DataTables_Table_0_paginate">

                    <asp:DetailsView ID="TrackFees" AllowPaging="true" AutoGenerateRows="false" runat="server" OnPageIndexChanging="TrackFees_PageIndexChanging" class="table table-reponsive table-striped b-t b-light dataTables_paginate paging_full_numbers" GridLines="None">
                        <Fields>
                            <asp:BoundField HeaderText="Name" DataField="name" />
                            <asp:BoundField HeaderText="Roll Number" DataField="studentRollnum" />
                            <asp:BoundField HeaderText="Payment Date" DataField="paymentDate" />
                            <asp:BoundField HeaderText="Class" DataField="studentClass" />
                            <asp:BoundField HeaderText="Supposed Fees" DataField="Fees" />
                            <asp:BoundField HeaderText="Amount Paid" DataField="amountPaid" />
                            <asp:BoundField HeaderText="Term Paid For" DataField="Term" />
                            <asp:BoundField HeaderText="Status" DataField="Status" />
                        </Fields>
                    </asp:DetailsView>

                    <div class="modal-footer"></div>
                </div>
                <h4 class="modal-title"><center></center></h4>
            </div>
            
            <!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
        </div>
</asp:Content>


