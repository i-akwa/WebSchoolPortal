﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.Teacher" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    
    <link href="../../js/datatables/datatables.css" rel="stylesheet" />
    


    <section class="panel panel-default">
        <header class="panel-heading">DataTables <i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>
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
                                entries</label>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="dataTables_filter" id="DataTables_Table_0_filter">
                            <label>Search:<input aria-controls="DataTables_Table_0" class="" type="search"></label>
                        </div>
                    </div>
                    <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">Processing...</div>
                </div>
                <asp:GridView ID="TeachersGrid" runat="server" AllowPaging="true" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" AutoGenerateEditButton="false">
                    <Columns>
                        <asp:BoundField HeaderText="Teacher Name" DataField="" />
                        <asp:BoundField HeaderText="Teacher Id" DataField="" />
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="EditTeachers" runat="server" CommandName="Edt" CommandArgument='<%#Bind("") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                              <asp:LinkButton ID="Deleteteachers" runat="server" CommandName="del" CommandArgument='<%#Bind("") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
<%--                <table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
                    <thead>
                        <tr role="row">
                            <th aria-label="Rendering engine: activate to sort column ascending" aria-sort="ascending" style="width: 192px;" colspan="1" rowspan="1" aria-controls="DataTables_Table_0" tabindex="0" class="sorting_asc" width="20%">Rendering engine</th>
                            <th aria-label="Browser: activate to sort column ascending" style="width: 248px;" colspan="1" rowspan="1" aria-controls="DataTables_Table_0" tabindex="0" class="sorting" width="25%">Browser</th>
                            <th aria-label="Platform(s): activate to sort column ascending" style="width: 248px;" colspan="1" rowspan="1" aria-controls="DataTables_Table_0" tabindex="0" class="sorting" width="25%">Platform(s)</th>
                            <th aria-label="Engine version: activate to sort column ascending" style="width: 136px;" colspan="1" rowspan="1" aria-controls="DataTables_Table_0" tabindex="0" class="sorting" width="15%">Engine version</th>
                            <th aria-label="CSS grade: activate to sort column ascending" style="width: 137px;" colspan="1" rowspan="1" aria-controls="DataTables_Table_0" tabindex="0" class="sorting" width="15%">CSS grade</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="odd">
                            <td class="dataTables_empty" colspan="5" valign="top">Loading...</td>
                        </tr>
                    </tbody>
                </table>--%>
                <div class="row">
                    <div class="col-sm-6">
                        <div aria-live="polite" role="status" id="DataTables_Table_0_info" class="dataTables_info">Showing 0 to 0 of 0 entries</div>
                    </div>
                    <div class="col-sm-6">
                        <div id="DataTables_Table_0_paginate" class="dataTables_paginate paging_full_numbers"><a id="DataTables_Table_0_first" tabindex="0" data-dt-idx="0" aria-controls="DataTables_Table_0" class="paginate_button first disabled">First</a><a id="DataTables_Table_0_previous" tabindex="0" data-dt-idx="1" aria-controls="DataTables_Table_0" class="paginate_button previous disabled">Previous</a><span></span><a id="DataTables_Table_0_next" tabindex="0" data-dt-idx="2" aria-controls="DataTables_Table_0" class="paginate_button next disabled">Next</a><a id="DataTables_Table_0_last" tabindex="0" data-dt-idx="3" aria-controls="DataTables_Table_0" class="paginate_button last disabled">Last</a></div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

