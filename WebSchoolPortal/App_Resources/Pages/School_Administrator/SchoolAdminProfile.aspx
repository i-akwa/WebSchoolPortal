<%@ Page Title="Automated Schools" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="SchoolAdminProfile.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.EmployeeProfile" %>
<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <asp:ScriptManager ID="Sc1" runat="server" />



            <div class="col-md-12">
                <asp:FormView ID="ProfilePixsFormView" runat="server" DataKeyNames="SchoolId" OnItemCommand="ProfilePixsFormView_ItemCommand" OnItemUpdating="ProfilePixsFormView_ItemUpdating1"
                     OnModeChanging="ProfilePixsFormView_ModeChanging" CssClass="col-xs-12">
                    <ItemTemplate>

                        <section class="panel panel-default">
                            <button class="btn btn-sm btn-success pull-right  hidden-print" onclick="window.print();"><i class="fa fa-print"></i>&nbsp;Print</button>

                            <header class="panel-heading bg-primary lt no-border">
                                <div class="clearfix">
                                    <a href="#" class="pull-left thumb "><i class="fa fa-tags"></i></a>
                                    <div class="clear">
                                        <div class="h3 m-t-xs m-b-xs text-white"><strong><%#Eval("SchoolName") %> <i class="fa fa-circle text-white pull-right text-xs m-t-sm"></i></strong></div>
                                        <small class="text-muted"><strong>School Profile</strong></small>
                                    </div>
                                </div>

                            </header>

                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <div class="form-group">
                                        <div class="col-md-5 col-sm-12">
                                            <div class="h" style="padding-top: 5px; padding-bottom: 5px; padding-left: 20px;">
                                                <asp:Image ID="ProfImage" runat="server" ImageAlign="middle" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/ProfilePicture.ashx?SchoolId={0}", Eval("SchoolId")) %>' Width="75%" Height="150px" CssClass="img-rounded img-responsive" />
                                            </div>
                                        </div>

                                        <div class="col-md-7 col-sm-12">
                                            <ul class="list-group no-radius">

                                                <li class="list-group-item"><span class="pull-right" stylE="word-wrap:break-word;"><%#Eval("SchoolName") %></span><strong> <i class="fa fa-home "></i>&nbsp;School Name </strong></li>
                                                <li class="list-group-item"><span class="pull-right">
                                                    <%#Eval("AdminSurName") %>, <%#Eval("AdminOtherNames") %>
                                                </span><strong><i class="fa fa-user "></i>&nbsp;Admin Name </strong></li>

                                                <li class="list-group-item"><span class="pull-right"><%#Eval("SchoolId") %></span>  <strong><i class="fa fa-hand-o-right  "></i>&nbsp;School Id </strong></li>
                                                <li class="list-group-item"><span class="pull-right"><%#Eval("AdminPhoneNumber") %></span>  <strong><i class="fa fa-phone  "></i>&nbsp;Contact No. </strong></li>
                                            </ul>
                                        </div>

                                    </div>

                                </div>
                            </div>
                            <header class="panel-heading font-bold">
                                &nbsp;
                                <ul class="nav nav-pills pull-right">
                                    <li>
                                        <asp:LinkButton ID="btnEditProfile" CssClass="btn btn-xs btn-success text-left  hidden-print" runat="server" Text="Change Logo" CommandName="Edit"><i class="fa fa-edit"></i>&nbsp;Change Logo</asp:LinkButton>
                                    </li>
                                </ul>
                            </header>

                        </section>

                    </ItemTemplate>

                    <EditItemTemplate>

                        <section class="panel panel-default">

                            <header class="panel-heading font-bold">Change Profile Logo</header>
                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <div class="form-group">
                                        <div class="col-sm-8 col-sm-offset-2">
                                        <div class="central" style=" padding: 5px;">
                                            <asp:Image ID="ProfImage" ImageAlign="Middle" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/ProfilePicture.ashx?SchoolId={0}", Eval("SchoolId")) %>'
                                                Width="100%" Height="300" runat="server" CssClass="img-rounded img-responsive" />
                                            <br class="clear" />
                                            <asp:HiddenField ID="hfUserID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"SchoolId") %>' />
                                        </div>

                                        </div>
                                        <asp:Label ID="lblUploadPicture" Text="" AssociatedControlID="fluImage" runat="server" /></b></span>

                                            <div class="line line-dashed line-lg pull-in"></div>
                                            <span>
                                                <asp:FileUpload ID="fluImage" CssClass="form-control" runat="server" />
                                            </span>

                                            <div>
                                                <br />
                                            </div>

                                            &nbsp;<asp:LinkButton ID="btnPicturePreview" CssClass="btn btn-xs btn-primary pull-right" ValidationGroup="aq" Text="Preview Image" runat="server" OnClick="btnPicturePreview_Click"><i class="fa fa-clipboard"></i>&nbsp;Preview</asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="lnkUpdateProfile" runat="server" Text="Change School Logo" OnClientClick="return confirm('Are you sure you want to save changes?');" CommandName="Update" CommandArgument='<%#Bind("SchoolId") %>' CssClass="btn btn-xs btn-primary pull-right" ValidationGroup="aaaa"><i class="fa fa-upload"></i>&nbsp;Update</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;..<asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel Update" CommandName="Cancel" CssClass="btn btn-xs btn-danger pull-right"><i class="fa fa-undo"></i>&nbsp;Cancel</asp:LinkButton>


                                    <div class="col-sm-10">
                                    </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>


                                </div>
                            </div>
                        </section>


                    </EditItemTemplate>

                </asp:FormView>
            </div>
            <div class="col-md-12">
                <asp:FormView ID="frmSchoolAdminDetails" DataKeyNames="SchoolId" runat="server" OnItemCommand="frmSchoolAdminDetails_ItemCommand" OnItemUpdating="frmSchoolAdminDetails_ItemUpdating"
                     OnModeChanging="frmSchoolAdminDetails_ModeChanging" OnPageIndexChanging="frmSchoolAdminDetails_PageIndexChanging" CssClass="col-xs-12">
                    <ItemTemplate>

                        <section class="panel panel-default">
                            <header class="panel-heading font-bold">
                                Profile Details
                                <ul class="nav nav-pills pull-right">
                                    <li>
                                        <asp:LinkButton ID="btnEditProfile" runat="server" Text="Edit Profile" CommandName="Edit" CssClass="btn btn-xs btn-success  hidden-print   btn-editProfile"><i class="fa fa-edit">&nbsp;Edit profile</i></asp:LinkButton>
                                        <%--&nbsp;&nbsp;|&nbsp;&nbsp;--%>
                                        <%--<asp:LinkButton ID="btnDeleteEmployee" runat="server" Text="Delete Employee" CommandName="Delete" CommandArgument='<%#Bind("UserID") %>' OnClientClick="return confirm('Are you sure you want to delete Employee?');" />--%>
                   
                                    </li>
                                </ul>
                            </header>
                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <ul class="list-group no-radius">
                                         <li class="list-group-item"><span class="pull-right">&nbsp;<%#Eval("SchoolEmail") %></span><strong><i class="fa fa-envelope "></i>&nbsp;School Email</strong></li>
                                        
                                        <li class="list-group-item"><span class="pull-right"><%#Eval("postalCode") %></span><strong><i class="fa fa-sort-alpha-desc "></i>&nbsp;Postal Code</strong></li>

                                        <div class="line line-dashed line-lg pull-in"></div>

                                        <li class="list-group-item"><span class="pull-right"><%#Eval("streetName") %></span><strong><i class="fa fa-phone"></i>&nbsp;School Address </strong></li>
                                        <li class="list-group-item"><span class="pull-right"><%#Eval("LGA") %></span><strong><i class="fa fa-map-marker"></i>&nbsp;L.G.A </strong></li>
                                       <!--s <li class="list-group-item"><span class="pull-right"></span><strong><i class="fa fa-location-arrow"></i>&nbsp;State </strong></li>-->
                                       
                                        <!--<li class="list-group-item"><span class="pull-right">15,000</span> <i class="fa fa-comment icon-muted"></i> Neosoft company </li>-->
                                    </ul>


                                    <div class="line line-dashed line-lg pull-in"></div>

                                </div>
                            </div>
                        </section>


                    </ItemTemplate>
                    <EditItemTemplate>

                        <section class="panel panel-default">
                            <header class="panel-heading font-bold">Edit Profile </header>
                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Name</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <%#Eval("AdminSurName") %> <%#Eval("AdminOtherNames") %>
                                            </span>
                                            <asp:HiddenField ID="hfUserID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"SchoolId") %>' />
                                            <%--<asp:HiddenField ID="hfUserName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"Username") %>' />--%>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>School Name</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <asp:TextBox runat="server" ID="SchoolName" Text='<%#Eval("SchoolName") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="SchoolName" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>

                                            </span>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Surname</strong></label>

                                        <div class="col-sm-10">
                                            <span>
                                                <asp:TextBox runat="server" ID="txtSurname" Text='<%#Eval("AdminSurName") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="reqSurname" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="txtSurname" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Other Names</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtOtherNames" Text='<%#Eval("AdminOtherNames") %>' CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="reqOtherNames" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="txtOtherNames" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                        
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Contact Address</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtContactAddress" Text='<%#Eval("StreetName") %>' TextMode="MultiLine" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="txtContactAddress" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                       
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Postal code</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="postCode" Text='<%#Eval("postalCode") %>' TextMode="SingleLine" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="postCode" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                        
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Phone NO.</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtMobilePhoneNumber" Text='<%#Eval("AdminPhoneNumber") %>' CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="reqMobilePhoneNumber" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="txtMobilePhoneNumber" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobilePhoneNumber" ValidationGroup="aaaa"
                                                Display="Dynamic" ErrorMessage="(Invalid data format)" Text="(*)" ForeColor="Red"
                                                SetFocusOnError="True" ValidationExpression="^(\+|0)\d(\d|-){7,20}$" /></span>
                        
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>School Email</strong></label>
                                        <div class="col-sm-10">

                                            <asp:TextBox runat="server" ID="txtEmail" Text='<%#Eval("SchoolEmail") %>' Visible="false" CssClass="form-control" /><h4><%#Eval("SchoolEmail") %></h4>

                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Nationality</strong></label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="Nationality" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Nationality_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="Nationality" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>State</strong></label>
                                        <div class="col-sm-10">

                                            <asp:DropDownList ID="State" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="State_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="State" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                        
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>L.G.A</strong></label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="lga" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="State_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="lga" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                       
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Gender</strong></label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="Male" Value="Male" />
                                                <asp:ListItem Text="Female" Value="Female" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">

                                        <label class="col-sm-2 control-label"></label>
                                        <div class="col-sm-10">
                                            <asp:LinkButton ID="lnkUpdateProfile" CssClass="btn btn-sm btn-success pull-right" runat="server" Text="Update Profile" OnClientClick="return confirm('Are you sure you want to save changes?');" CommandName="Update" CommandArgument='<%#Bind("SchoolId") %>' ValidationGroup="aaaa" ><i class="fa fa-upload"></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp; &nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkCancel" CssClass="btn btn-sm btn-danger pull-right" runat="server" Text="Cancel Update" CommandName="Cancel" ><i class="fa fa-undo"></i>&nbsp;Cancel</asp:LinkButton></span>
                  
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </section>


                    </EditItemTemplate>
                </asp:FormView>

            </div>
        </ContentTemplate>
        
    </asp:UpdatePanel>
</asp:Content>
