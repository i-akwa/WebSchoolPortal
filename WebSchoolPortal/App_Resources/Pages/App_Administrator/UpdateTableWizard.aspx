<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="UpdateTableWizard.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.App_Administrator.UpdateTableWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <asp:ScriptManager ID=script1 runat="server"></asp:ScriptManager>
    <div class="col-md-12">
        <div class="col-md-6 form-group">
            <div class="col-md-12"><h5>Table Name:</h5></div>
            
                    <div class="col-md-12">
                        <asp:DropDownList ID="ddlTabName"
                            runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTabName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                
        </div>
        <div class="col-md-6 form-group">
            <div class="col-md-12"><h5>Column Name:</h5></div>
            <div class="col-md-12"><asp:DropDownList ID="ddlColumnName" runat="server" CssClass="form-control"></asp:DropDownList></div>
        </div>
        <div class="col-md-6 form-group">
            <div class="col-md-12"><h5>Fields Name:</h5></div>
            <div class="col-md-12"><asp:DropDownList ID="ddlCllasses" runat="server" CssClass="form-control"></asp:DropDownList></div>
        </div>
        <div class="col-md-6 form-group">
            <div class="col-md-12"><h5>school Name:</h5></div>
            <div class="col-md-12"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList></div>
        </div>
        <div class="col-md-6 form-group">
            
            <div class="col-md-12"><asp:Button ID="btnEdit" Text="Update" OnClick="btnEdit_Click" runat="server" CssClass="btn btn-success"></asp:Button></div>
        </div>
    </div>
</asp:Content>
