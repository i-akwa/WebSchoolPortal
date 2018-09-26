<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="WebSchoolPortal.ChangePassword" %>
<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
  
      <asp:ChangePassword ID="NewPass" runat="server" DisplayUserName="true" CssClass="col-xs-12 col-md-12">
        <changepasswordtemplate>
           
            <section class="panel panel-default">

                <header class="panel-heading font-bold">Change password </header>
                <div class="line line-dashed line-lg pull-in"></div>
                <div class="panel-body">
                    <div class="form-horizontal" ">


                        <div class="form-group">
                            <label class="col-sm-3 control-label">UserName</label>
                            <div class="col-sm-7">

                                <asp:TextBox ID="UserName" type="text" runat="server" CssClass="form-control input-lg input-group" />
                            </div>
                        </div>
                        <div class="line line-dashed line-lg pull-in"></div>
                        <div class="form-group">
                                            <label class="col-sm-3 control-label">Current password</label>
                        <div class="col-sm-7">

                            <asp:TextBox ID="CurrentPassword" runat="server" CssClass="form-control input-lg input-group" TextMode="Password" type="password" />


                        </div>
                    </div>
                    <div class="line line-dashed line-lg pull-in"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">New password</label>
                        <div class="col-sm-7">
                            

                            <asp:TextBox ID="NewPassword" runat="server" placeHolder="New Password" CssClass="form-control input-lg input-group" TextMode="Password" type="password" />
                            <asp:RequiredFieldValidator ID="newPas" runat="server" ControlToValidate="NewPassword" ToolTip="New Password is a required field" Text="*"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="line line-dashed line-lg pull-in"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label">Confirm password</label>
                        <div class="col-sm-7">

                            <asp:TextBox ID="ConfirmPassword" runat="server" type="password" placeholder="Comfirm Password" CssClass="form-control input-lg input-group" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="comPass" ControlToValidate="ConfirmPassword" Text="*" ToolTip="This is a required field" runat="server" />
                            <asp:CompareValidator ID="Compare" Text="password Must Match" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmPassword" />

                        </div>
                    </div>
                    <div class="line line-dashed line-lg pull-in"></div>
                    <div class="form-group">
                        <div class="col-sm-4 col-sm-offset-3">


                            <asp:Button ID="btnChangePassword" Text="Update Password" CommandName="ChangePassword" runat="server" CssClass="btn btn-info" />

                        </div>
                    </div>

                    </div>
                </div>
                

            </section>
             </ChangePasswordTemplate>
        <maildefinition
                    bodyfilename="~/App_Resources/Pages/TextFiles/ChangePassword.txt"
                    subject="Changed Password"
                    from="info@automated-schools.com">
                                </maildefinition>
                <successtemplate>
                <h3>Your Password Have Been Changed</h3>
            </successtemplate>
        </asp:ChangePassword>


</asp:Content>
