﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="ParentInfo.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.ParentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">

    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!</strong>  You Can Search For Parents by Names,Address And Student's ID,etc...<a href="#" class="alert-link"></a></span>
        </div>

    <section class="panel panel-default">
        <header class="panel-heading">
            <div class="input-group text-sm">
                <asp:DropDownList ID="DDlSearch" CssClass="input-sm form-control" runat="server" />
                <div class="input-group-btn">
                    <asp:linkbutton ID="Button2" type="button" runat="server"  Text="Search" class="btn btn-sm btn-default" OnClick="Button1_Click"><i class="fa fa-search"></i>&nbsp;Search</asp:linkbutton>
                </div>
            </div>
        </header>
     <div class="table-responsive">
         <div class="dataTables_wrapper no-footer" id="DataTables_Table_0_wrapper">

             <div style="display: none;" class="dataTables_processing" id="DataTables_Table_0_processing">Processing...</div>
         </div>
         <table aria-describedby="DataTables_Table_0_info" role="grid" id="DataTables_Table_0" class="table table-striped m-b-none dataTable no-footer" data-ride="datatables">
             <thead>
             </thead>
             <tbody>
                 <asp:GridView ID="ParentGrid" runat="server" AutoGenerateColumns="false" AutoGenerateDeleteButton="false" EmptyDataText="No Records  Found" AutoGenerateEditButton="false" AllowPaging="True" PageSize="20" CssClass=" table table-responsive table-hover  " GridLines="None" Width="100%" OnRowCommand="ParentGrid_RowCommand" OnPageIndexChanging="ParentGrid_PageIndexChanging" >
                     <Columns>
                         <asp:BoundField HeaderText="Guardiance" DataField="GuidianceName"  />
                         <asp:BoundField HeaderText="Phone Number" DataField="GuidiancePhoneNo"  />
                         <asp:BoundField HeaderText="Student Name" DataField="Name"  />
                         <asp:BoundField HeaderText="Student Id" DataField="StudentRollNumber"  />

                         <asp:TemplateField HeaderText="Message">
                             <ItemTemplate>
                                 <asp:TextBox ID="Message" runat="server" TextMode="MultiLine" ></asp:TextBox>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField  HeaderText="">
                             <ItemTemplate >
                                 <asp:LinkButton Text="Send" ID="viewStudent" runat="server" CommandName="Send" CommandArgument='<%#Bind("StudentRollNumber") %>' class="btn btn-xs btn-primary" ><i class="fa fa-envelope"></i>&nbsp;Send</asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
             </tbody>
         </table>
     </div>

                         </section>
</asp:Content>
