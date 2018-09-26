<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="bankpayment.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.bankpayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

    <link href="../../js/datatables/datatables.css" rel="stylesheet" />


    <div class="m-b-md">
        <h3 class="m-b-none">Manage invoice/payment</h3>
        <small>Welcome back, User's name</small>
    </div>



    <!--Page Contents-->

    <div class="panel panel-default">
        <header class="panel-heading"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>invoice/payment list</header>
        <div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">
                <div class="row">
                    <div class="col-sm-6">
                        <div id="DataTables_Table_0_length" class="dataTables_length">
                            <label>
                                Show 
                                        <select class="" aria-controls="DataTables_Table_0" name="DataTables_Table_0_length">
                                            <option value="10">10</option>
                                            <option value="25">25</option>
                                            <option value="50">50</option>
                                            <option value="100">100</option>
                                        </select>
                                entries
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="dataTables_filter" id="DataTables_Table_0_filter">
                            <label>
                                Search:
                                        <input aria-controls="DataTables_Table_0" class="" type="search">
                            </label>
                        </div>
                    </div>
                    <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">
                        Processing...
                    </div>
                </div>
                <table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
                    <thead>
                        <tr role="row">
                            <th aria-label="Rendering engine: activate to sort column ascending" aria-sort="ascending" style="width: 224px;" colspan="1" rowspan="1" aria-controls="DataTables_Table_0" tabindex="0" class="sorting_asc" width="20%">Student</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>Amount</th>
                            <th>Status</th>
                            <th>Date</th>
                            <th>Option</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="odd">
                            <td class="dataTables_empty" colspan="7" style="padding: 11px 16px;" valign="top">No data available in table</td>
                        </tr>
                    </tbody>
                </table>
                <div class="row" style="margin-bottom: -25px;">
                    <div class="col-sm-6">
                        <div aria-live="polite" role="status" id="DataTables_Table_0_info" class="dataTables_info" style="margin-top: -1px;">
                            Showing 0 to 0 of 0 entries
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div id="DataTables_Table_0_paginate" class="dataTables_paginate paging_full_numbers">
                            <div class="text-right" style="margin-right: 4px; margin-top: -24px;">
                                <ul class="pagination pagination">
                                    <li><a href="#"><i class="fa fa-chevron-left"></i></a></li>
                                    <li><a href="#">1</a></li>
                                    <li><a href="#"><i class="fa fa-chevron-right"></i></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
