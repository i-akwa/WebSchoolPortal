<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="Class_ArmManagment.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.ClassA" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <link href="../../js/datatables/datatables.css" rel="stylesheet" />

     <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!</strong>  Please all  arms should be filled correctly to manage classes,Thanks...<a href="#" class="alert-link"></a></span>

        </div>

    <asp:Label runat="server" Visible="true" ID="NoticeInfo">
    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><strong>Heads up!</strong> <a href="#" class="alert-link"></a><b style="color:red; font-size:larger;">Note: If you are seeing this page when you never requested for it, it means you have not inserted your arms record. Please fill the arms in this page to continue in<a href="StudentRegistrationPage.aspx"> student Registration</a>.</b>
        </div>
   </asp:Label>
    <section class="panel panel-default">
        <header class="panel-heading">Class Arm Management<i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>
        <div class="table-responsive">
            <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">
                <div class="row">
                     <div class="col-sm-4">
                        <div class="dataTables_length" id="DataTables_Table_0_filter">
                            <asp:TextBox ID="SCHIILID" runat="server" ReadOnly="true" placeholder="SCHOOL ID" CssClass="input-control text form-control input-lg input-group"/>
                        </div>
                    </div>
                    <div class="col-sm-4">

                        <div id="DataTables_Table_0_length" class="dataTables_length">
                            <asp:TextBox ID="Arms" runat="server" placeholder="INPUT ARMS SEPERATED BY A COMMA" TextMode="singleLine" CssClass="form-control input-lg input-group" />
                            <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="Arms" ErrorMessage="Requred" ValidationGroup="er" Text="No arms inserted." ForeColor="Red" ></asp:RequiredFieldValidator>
                        </div>
                    </div>
                   
                    <div class="col-sm-4">
                        <div id="DataTables_Table_0length" class="dataTables_length">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-dark btn-block" ForeColor="White" OnClick="Button1_Click" ValidationGroup="er" />
                            <asp:Label ID="HiddenLabel" runat="server" Visible="False"></asp:Label>
                            <asp:Button ID="ADD" runat="server" Text="ADD" CssClass="btn btn-success btn-block" OnClick="ADD_Click" ValidationGroup="er" />

                        </div>
                    </div>
                    <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">Processing...</div>
                </div>
                <table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
                    <thead>
                    </thead>
                    <tbody>
                        <asp:GridView ID="grdArms" runat="server" AutoGenerateColumns="false" CssClass=" table table-responsive table-hover" GridLines="None" OnRowCommand="grdArms_RowCommand" Width="100%" EditRowStyle-CssClass="text-center">
                            <Columns>
                                <asp:BoundField HeaderText="All Available Arms" DataField="Arm"  />
                                <asp:TemplateField HeaderText="Edit" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Change" CommandName="change" CommandArgument='<%#Bind("ArmsId") %>' Text="Change" runat="server" CausesValidation="false" class="btn btn-xs btn-primary"><i class="fa fa-eraser"></i>&nbsp;Change</asp:LinkButton>
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

    
    <%--<table style="width:100%" >

        <tr>
            <td>&nbsp;</td>
            <td>
                <div>
                    <span><b>INPUT ARMS</b></span>
                </div>
                <asp:TextBox ID="Arms" runat="server" Width="50%" Height="50px" placeholder="INPUT ARMS SEPERATED BY A COMMA" TextMode="MultiLine" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="Button1_Click" />
                <asp:Label ID="HiddenLabel" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>--%>
        <%--<tr>
            <td>&nbsp;</td>
            <td>
                <div>
                    <span><b>SCHOOLID</b></span>
                </div>
                <asp:TextBox ID="SCHIILID" runat="server" Width="50%" Height="50px" placeholder="SCHOOL ID" /></td>
        </tr>
        <tr>
            <td></td><td><asp:Button ID="ADD" runat="server" Text="ADD" OnClick="ADD_Click" /></td>
        </tr>--%>
       <%-- <tr>
            <td></td><td style="padding-top:10px"><asp:GridView ID="grdArms" runat="server" AutoGenerateColumns="false" CssClass="table-bordered table table-responsive" width="50%" CellSpacing="6" CellPadding="6"  HeaderStyle-Font-Size="Medium" HeaderStyle-Font-Names="Comic sans ms" OnRowCommand="grdArms_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="All Available Arms" ControlStyle-ForeColor="Black" DataField="Arm" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Change" CommandName="change" CommandArgument='<%#Bind("ArmsId") %>' Text="Change" runat="server" CausesValidation="false"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                         </asp:GridView>
                     </td>
        </tr>
    </table>--%>
</asp:Content>