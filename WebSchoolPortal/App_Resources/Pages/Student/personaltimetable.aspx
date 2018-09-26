<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="personaltimetable.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Student.personaltimetable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

    
    <div class="m-b-md">
        <h3 class="m-b-none">Manage class routine</h3>
        <small>Welcome back, User's name</small>
    </div>


    <!--Page Contents-->

    <div class="panel panel-default">
        <header class="panel-heading"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>Class routine list</header>
        <div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">
                <div class="row">




                    <div class="col-sm-6" style="height: 54px;">
                        <header class="panel-heading" style="margin-top: 1px; font-size: 24px;"><i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i>Class 1</header>
                    </div>
                    <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">
                        Processing...
                    </div>
                </div>
                <table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">

                    <tbody>
                        <tr class="odd">
                            <td style="padding: 9px 15px;" width="25%">Monday</td>
                            <td width="75%">Contents</td>
                        </tr>

                        <tr class="odd">
                            <td style="padding: 9px 15px;" width="25%">Tuesday</td>
                            <td width="75%">Contents</td>
                        </tr>

                        <tr class="odd">
                            <td style="padding: 9px 15px;" width="25%">Wednesday</td>
                            <td width="75%">Contents</td>
                        </tr>

                        <tr class="odd">
                            <td style="padding: 9px 15px;" width="25%">Thursday</td>
                            <td width="75%">Contents</td>
                        </tr>

                        <tr class="odd">
                            <td style="padding: 9px 15px;" width="25%">Friday</td>
                            <td width="75%">Contents</td>
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
