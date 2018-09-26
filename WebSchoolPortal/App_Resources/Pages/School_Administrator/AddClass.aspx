<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.AddClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
   <section class="panel panel-default">
       <div class="panel-heading">Add Class</div>
       <div class="panel-body">
           <div class="col-md-6">
               <div class="table table-responsive">
                   
                   <table class="table table-responsive">
                       <tr><td><label>School ID</label></td><td><asp:TextBox ID="SchoolID" runat="server" ReadOnly="true" CssClass="form-control" /></td></tr>
                       <tr><td><label>Class</label></td><td><asp:TextBox ID="clas" runat="server" CssClass="form-control" /></td></tr>
                       <tr><td><label>Class Id</label></td><td><asp:label ID="clasID" readonly="true" runat="server" Text=""  CssClass="form-control" /></td></tr>
                       <tr><td></td><td>
                           
                            <asp:LinkButton ID="Update" runat="server" Text="Update" CssClass="btn btn-success pull-right" OnClick="Update_Click" > <i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
       
                           <asp:LinkButton ID="submit" runat="server" Text="Insert Class" CssClass="btn btn-success pull-right" OnClick="submit_Click" > <i class="fa fa-save"></i>&nbsp;Insert</asp:LinkButton>

                           </td></tr>
                   </table>
               </div>
           </div>
           <div class="col-md-6">
               <div class="table table-responsive"> 
               <asp:GridView ID="classGrid" runat="server" AutoGenerateColumns="false" AutoGenerateEditButton="false" AllowPaging="true" OnRowCommand="classGrid_RowCommand" OnPageIndexChanging="classGrid_PageIndexChanging" PageSize="10"  CssClass="table table-responsive table-bordered table-hover" GridLines="None"  >
                   <Columns>
                       <asp:BoundField HeaderText="class ID" DataField="ClassId" />
                       <asp:BoundField HeaderText="Class" DataField="class" />
                       <asp:TemplateField  HeaderText="Edit">
                           <ItemTemplate>
                               <asp:LinkButton ID="Update" CssClass="btn btn-sm btn-danger" runat="server" Text="Edit" CommandName="Upd" CommandArgument='<%#((GridViewRow)Container).RowIndex %>'>&nbsp;<i class="fa fa-edit danger"></i></asp:LinkButton>
                           </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
               </asp:GridView>
           </div>
               </div>
       </div>
   </section>
    
</asp:Content>
