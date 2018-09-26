<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="TeacherViewProfile.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Teachers.TeacherViewProfile" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <asp:ScriptManager ID="Script1" runat="server" />
    <asp:UpdatePanel ID="updatecontrol" runat="server" UpdateMode="Conditional">
        <ContentTemplate>


            <div class="col-md-12">

                <asp:FormView ID="ProfilePixsFormView" runat="server" DataKeyNames="SchoolId" OnItemCommand="ProfilePixsFormView_ItemCommand" OnItemUpdating="ProfilePixsFormView_ItemUpdating1" OnModeChanging="ProfilePixsFormView_ModeChanging" CssClass="col-xs-12 col-md-7 col-md-offset-3">
                    <ItemTemplate>

                        <button class="btn btn-sm btn-success pull-right  hidden-print" onclick="window.print();"><i class="fa fa-print"></i>&nbsp;Print</button>
                        <section class="panel panel-default">

                            <header class="panel-heading bg-primary lt no-border">
                                <div class="clearfix">
                                    <a href="#" class="pull-left thumb "><i class="fa fa-tags"></i></a>
                                    <div class="clear">
                                        <div class="h3 m-t-xs m-b-xs text-white">
                                            <strong>
                                                <asp:Label runat="server" ID="SName" Enabled="true" ></asp:Label>
                                                <i class="fa fa-circle text-white pull-right text-xs m-t-sm"></i></strong>
                                        </div>
                                        <small class="text-muted"><strong>Teacher</strong></small>
                                    </div>
                                </div>
                            </header>
                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <div class="form-group">

                                        <div class="col-md-5 col-sm-12">
                                            <div class="h" style="padding-top: 5px; padding-bottom: 5px; padding-left: 20px;">
                                                <asp:Image ID="ProfImage" runat="server" ImageAlign="Middle" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/Teacherpixs.ashx?TeacherId={0}", Eval("TeacherId")) %>' Width="75%" Height="150" CssClass="img-rounded img-responsive" />
                                            </div>
                                        </div>
                                        <div class=" col-md-7 col-sm-12">
                                            <ul class="list-group no-radius">
                                                <li class="list-group-item"><span class="pull-right">
                                                    <%#Eval("LastName") %> <%#Eval("FirstName") %>
                                                </span><strong><i class="fa fa-user "></i>Names </strong></li>

                                                <li class="list-group-item"><span class="pull-right"><%#Eval("schoolId") %></span> <strong><i class="fa fa-hand-o-right "></i>School Id </strong></li>
                                                <li class="list-group-item"><span class="pull-right"><%#Eval("TeacherId") %></span> <strong><i class="fa fa-hand-o-right "></i>Teacher Id</strong></li>
                                                <li class="list-group-item"><span class="pull-right"><%#Eval("ContactAdress") %></span> <strong><i class="fa fa-location-arrow  "></i>Contact Address </strong></li>
                                            </ul>
                                        </div>

                                    </div>



                                </div>
                            </div>
                            <header class="panel-heading font-bold">
                                &nbsp;
                            <ul class="nav nav-pills pull-right">
                                <li>

                                    <asp:LinkButton ID="btnEditProfile" CssClass="btn btn-xs btn-success text-left  hidden-print" runat="server" Text="Change Logo" CommandName="Edit"><i class="fa fa-edit"></i>&nbsp;Change Pic</asp:LinkButton>
                                </li>
                            </ul>
                            </header>
                        </section>



                    </ItemTemplate>


                    <EditItemTemplate>

                        <section class="panel panel-default">

                            <header class="panel-heading font-bold">Change Picture </header>
                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                         <div class="col-sm-8 col-sm-offset-2">
                                             <div class="central" style="padding: 5px;">

                                                 <asp:Image ID="Image2" ImageAlign="Middle" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/Teacherpixs.ashx?TeacherId={0}", Eval("TeacherId")) %>' Width="100%" Height="300" runat="server" CssClass="img-rounded img-responsive" />

                                                 <br class="clear" />

                                                 <asp:HiddenField ID="hfUserID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"TeacherId") %>' />

                                             </div>
                                             </div>

                                        <asp:Label ID="lblUploadPicture" Text="Change Picture:" AssociatedControlID="fluImage" runat="server" /></b></span>
                       
                                    <asp:UpdatePanel ID="update1" runat="server">
                                        <ContentTemplate>
                                            <div class="line line-dashed line-lg pull-in"></div>
                                            <span>
                                                <asp:FileUpload ID="fluImage" CssClass="form-control" runat="server" />
                                            </span>
                                            <div>
                                                <br />
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnPicturePreview" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                       

                                        &nbsp;<asp:linkbutton ID="btnPicturePreview" CssClass="btn btn-xs btn-primary pull-right" ValidationGroup="aq" Text="Preview Image" runat="server" OnClick="btnPicturePreview_Click" ><i class="fa fa-clipboard"></i>&nbsp;Preview</asp:linkbutton>&nbsp;
                                        <asp:LinkButton ID="lnkUpdateProfile" runat="server" Text="Change School pic" OnClientClick="return confirm('Are you sure you want to save changes?');" CommandName="Update" CommandArgument='<%#Bind("TeacherId") %>' CssClass="btn btn-xs btn-primary pull-right" ValidationGroup="aaaa" ><i class="fa fa-upload"></i>&nbsp;Update</asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel Update" CommandName="Cancel" CssClass="btn btn-xs btn-danger pull-right" ><i class="fa fa-undo"></i>&nbsp;Cancel</asp:LinkButton>
                  


                                        <div class="col-sm-10">
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>


                                </div>
                            </div>
                        </section>


                        </ContentTemplate>

                    </EditItemTemplate>

                </asp:FormView>
            </div>
            <div class="col-md-12">

                <asp:FormView ID="frmTeacherDetails" DataKeyNames="TeacherId" runat="server" OnItemCommand="frmTeacherDetails_ItemCommand" OnItemUpdating="frmTeacherDetails_ItemUpdating" OnModeChanging="frmTeacherDetails_ModeChanging" OnPageIndexChanging="frmTeacherDetails_PageIndexChanging" CssClass="col-xs-12 col-md-7 col-md-offset-3">
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

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <ul class="list-group no-radius">
                                        <li class="list-group-item"><span class="pull-right"><%#Eval("Email") %></span><strong> <i class="fa fa-envelope "></i> Email </strong></li>
                                        <li class="list-group-item"><span class="pull-right"><%#Eval("RegDate") %></span> <strong><i class="fa fa-sort-numeric-asc"></i> Registration Date</strong></li>
                                        <li class="list-group-item"><span class="pull-right"><%#Eval("LGA") %></span><strong> <i class="fa fa-map-marker"></i> L.G.A</strong></li>
                                    </ul>

                                    <div class="line line-dashed line-lg pull-in"></div>

                                </div>
                            </div>
                        </section>


                    </ItemTemplate>
                    <EditItemTemplate>

                        <section class="panel panel-default">
                            <header class="panel-heading font-bold">Profile Details</header>
                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Name</strong></label>
                                        <div class="col-sm-10">
                                            <span>

                                                <%#Eval("LastName") %>, <%#Eval("FirstName") %>
                                            </span>
                                            <asp:HiddenField ID="hfUserID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"TeacherId") %>' />
                                            <%--<asp:HiddenField ID="hfUserName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"Username") %>' />--%>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>School Id</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <asp:TextBox runat="server" ID="SchoolID" Text='<%#Eval("SchoolId") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="SchoolID" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />

                                            </span>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>FirstName</strong></label>

                                        <div class="col-sm-10">

                                            <span>
                                                <asp:TextBox runat="server" ID="FirstName" Text='<%#Eval("FirstName") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="reqSurname" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="FirstName" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                                            </span>

                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Middle Name</strong></label>
                                        <div class="col-sm-10">

                                            <span>
                                                <asp:TextBox runat="server" ID="MiddleName" Text='<%#Eval("MiddleName") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="reqOtherNames" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="MiddleName" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                                            </span>

                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Last Name</strong> </label>
                                        <div class="col-sm-10">


                                            <span>
                                                <asp:TextBox runat="server" ID="LastName" Text='<%#Eval("LastName") %>' TextMode="SingleLine" CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="LastName" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                                            </span>


                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Address </strong></label>
                                        <div class="col-sm-10">

                                            <span>
                                                <asp:TextBox runat="server" ID="ContactAdress" Text='<%#Eval("ContactAdress") %>' TextMode="MultiLine" CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="Required" Text="****" ForeColor="Red"
                                                    ControlToValidate="ContactAdress" runat="server" SetFocusOnError="true" Display="Dynamic" ValidationGroup="aaaa" />


                                            </span>


                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Phone NO.</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtMobilePhoneNumber" Text='<%#Eval("phoneNumber") %>' CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="reqMobilePhoneNumber" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="txtMobilePhoneNumber" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobilePhoneNumber" ValidationGroup="aaaa"
                                                Display="Dynamic" ErrorMessage="(Invalid data format)" Text="(*)" ForeColor="Red"
                                                SetFocusOnError="True" ValidationExpression="^(\+|0)\d(\d|-){7,20}$" /></span>
                        
                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong> Email</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <asp:TextBox runat="server" ID="txtEmail" Text='<%#Eval("Email") %>' Visible="false" /><h2><%#Eval("Email") %></h2>
                                            </span>
                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Nationality</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <asp:DropDownList ID="Nationality" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Nationality_SelectedIndexChanged" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="Nationality" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />

                                            </span>

                                        </div>
                                    </div>
                                    
                                    
                                     <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>State</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <asp:DropDownList ID="State" CssClass="form-control " runat="server" AutoPostBack="True" OnSelectedIndexChanged="State_SelectedIndexChanged" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="State" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" />

                                            </span>

                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>L.G.A</strong></label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="lga" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="State_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
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

                                             <asp:LinkButton ID="lnkUpdateProfile" CssClass="btn btn-sm btn-success pull-right" runat="server" Text="Update Profile" OnClientClick="return confirm('Are you sure you want to save changes?');" CommandName="Update" CommandArgument='<%#Bind("TeacherId") %>' ValidationGroup="aaaa" ><i class="fa fa-upload"></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp; &nbsp;&nbsp;
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
