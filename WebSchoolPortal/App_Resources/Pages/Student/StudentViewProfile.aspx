<%@ Page Title="Automated Schools" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="StudentViewProfile.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Student.StudentViewProfile" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <asp:ScriptManager ID="ScripMg1" runat="server"/>
    <asp:UpdatePanel ID="updatecontrol" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
           <div class="col-md-12">
               <asp:FormView ID="ProfilePixsFormView" runat="server" DataKeyNames="StudentRollNumber" OnItemCommand="ProfilePixsFormView_ItemCommand" OnItemUpdating="ProfilePixsFormView_ItemUpdating1"
                    OnModeChanging="ProfilePixsFormView_ModeChanging" CssClass="col-xs-12">
                   <ItemTemplate>

                      <button   class="btn btn-sm btn-success pull-right  hidden-print" onclick="window.print();"><i class="fa fa-print"></i>&nbsp;Print</button>
                       <section class="panel panel-default">
                            <header class="panel-heading bg-primary lt no-border">
                                <div class="clearfix">
                                    <a href="#" class="pull-left thumb "><i class="fa fa-tags"></i> </a>
                                    <div class="clear">
                                        <div class="h3 m-t-xs m-b-xs text-white"><strong>
                                            <asp:Label runat="server" ID="SSName"></asp:Label>
                                            <i class="fa fa-circle text-white pull-right text-xs m-t-sm"></i></strong></div>
                                        <small class="text-muted"><strong>Student Profile</strong></small>
                                    </div>
                                </div>
                            </header>
                           <div class="panel-body">
                               <div class=" form form-horizontal">
                                   <div class="form-group">

                                        <div class="col-md-5 col-sm-12">
                                           <div class="h" style="padding-top: 5px; padding-bottom: 5px; padding-left: 10px;">
                                               <asp:Image ID="ProfImage" runat="server" ImageAlign="Middle" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/StudentProfilepixs.ashx?StudentRollNumber={0}", Eval("StudentRollNumber")) %>' Width="70%" Height="190" CssClass="img-rounded img-responsive" />
                                           </div>
                                       </div>

                                       <div class="col-md-7 col-sm-12">
                                           <ul class="list-group no-radius">
                                               <li class="list-group-item"><span class="pull-right">
                                                   <%#Eval("FirstName") %> <%#Eval("MiddleName") %> <%#Eval("LastName") %> 
                                               </span><strong><i class="fa fa-user "></i>&nbsp; Names </strong></li>
                                               <li class="list-group-item"><span class="pull-right"></b><%#Eval("Sex") %></span><strong> <i class="fa fa-hand-o-right"></i>&nbsp; Sex</strong></li>
                                               <li class="list-group-item"><span class="pull-right"></b><%#Eval("PresentClass") %></span><strong> <i class="fa fa-hand-o-right"></i>&nbsp; Present Class </strong></li>

                                               <li class="list-group-item"><span class="pull-right"><%#Eval("StudentRollNumber") %></span><strong> <i class="fa fa-hand-o-right  "></i>&nbsp; Student Id </strong></li>

                                           </ul>

                                       </div>
                                      
                                           </div>
                                                                                 
                                   </div>

                               </div>
                           </div>
                           <header class="panel-heading font-bold">
                               &nbsp;
                               <ul class="nav nav-pills pull-right">
                                   <li>
                                       <asp:LinkButton ID="btnEditProfile" CssClass="btn btn-xs btn-success text-left  hidden-print" runat="server" Text="Change pic" CommandName="Edit"><i class="fa fa-edit"></i>&nbsp;Change Pic</asp:LinkButton>
                                   </li>

                               </ul>
                           </header>
                       </section>

                   </ItemTemplate>

                   <EditItemTemplate>

                       <section class="panel panel-default">

                           <header class="panel-heading font-bold">Change Picture</header>
                           <div class="panel-body">
                               <div class=" form form-horizontal">

                                   <div class="form-group">
                                       <div class="col-sm-8 col-sm-offset-2">
                                           <div class="central" style="padding: 5px;">
                                               <asp:Image ID="Image2" ImageAlign="Middle" ImageUrl='<%# String.Format("~/App_Resources/FileHandlers/StudentProfilepixs.ashx?StudentRollNumber={0}", Eval("StudentRollNumber")) %>'
                                                   Width="100%" Height="300" runat="server" CssClass="img-rounded img-responsive" />
                                               <br class="clear" />
                                               <asp:HiddenField ID="hfUserID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"StudentRollNumber") %>' />

                                           </div>
                                           </div>
                                           <asp:Label ID="lblUploadPicture" Text="" AssociatedControlID="fluImage" runat="server" /></b>
                                       
                                       
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

                                           &nbsp;<asp:LinkButton ID="btnPicturePreview" CssClass="btn btn-xs btn-primary pull-right" ValidationGroup="aq" Text="Preview Image" runat="server" OnClick="btnPicturePreview_Click"><i class="fa fa-clipboard"></i>&nbsp;Preview</asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="lnkUpdateProfile" runat="server" Text="Change School Logo" OnClientClick="return confirm('Are you sure you want to save changes?');" CommandName="Update" CommandArgument='<%#Bind("StudentRollNumber") %>' CssClass="btn btn-xs btn-primary pull-right" ValidationGroup="aaaa"><i class="fa fa-upload"></i>&nbsp;Update</asp:LinkButton>
                                           &nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;..<asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel Update" CommandName="Cancel" CssClass="btn btn-xs btn-danger pull-right"><i class="fa fa-undo"></i>&nbsp;Cancel</asp:LinkButton>



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
               <asp:FormView ID="frmTeacherDetails" DataKeyNames="StudentRollNumber" runat="server" CssClass="col-xs-12" OnItemCommand="frmTeacherDetails_ItemCommand" 
                   OnModeChanging="frmTeacherDetails_ModeChanging" OnPageIndexChanging="frmTeacherDetails_PageIndexChanging" OnDataBound="frmTeacherDetails_DataBound"  OnItemUpdating="frmTeacherDetails_ItemUpdating" >
                   <ItemTemplate>


                       <section class="panel panel-default">
                           <header class="panel-heading font-bold">
                               Profile
                               <ul class="nav nav-pills pull-right">
                                   <li>
                                       <asp:LinkButton ID="btnEditProfile" runat="server" Text="Edit Profile" CommandName="Edit" CssClass="btn btn-xs btn-success  hidden-print   btn-editProfile"><i class="fa fa-edit">&nbsp;Edit profile</i></asp:LinkButton>

                                         
                        <%--<asp:LinkButton ID="btnDeleteEmployee" runat="server" Text="Delete Employee" CommandName="Delete" CommandArgument='<%#Bind("UserID") %>' OnClientClick="return confirm('Are you sure you want to delete Employee?');" />--%>
 

                                   </li>
                               </ul>
                           </header>
                           <div class="panel-body">
                               <div class=" form form-horizontal">

                                   <ul class="list-group no-radius">
                                       <li class="list-group-item"><span class="pull-right"><%#Eval("GuidiancePhoneNo") %></span> <strong><i class="fa fa-phone"></i>&nbsp; Parents No.</strong> </li>
                                       <li class="list-group-item"><span class="pull-right"><%#Eval("StudentEmail") %></span> <strong><i class="fa fa-envelope "></i>&nbsp;  Student Email</strong></li>
                                       <li class="list-group-item"><span class="pull-right"></b><%#Eval("DateOfBirth") %></span><strong> <i class="fa fa-map-marker"></i>&nbsp;    Date Of Birth</strong></li>
                                       <li class="list-group-item"><span class="pull-right"><%#Eval("AdmissionDate") %></span><strong><i class="fa fa-sort-numeric-asc"></i> &nbsp;  Admission Date</strong></li>
                                       
                                   </ul>


                                   <div class="line line-dashed line-lg pull-in"></div>

                                   <ul class="list-group no-radius">

                                       <li class="list-group-item"><span class="pull-right"><%#Eval("ResidentialAddress") %></span><strong> <i class="fa fa-location-arrow  "></i>&nbsp;  Contact Address </strong></li>
                                       <li class="list-group-item"><span class="pull-right"></b><%#Eval("LGA") %></span><strong> <i class="fa fa-map-marker"></i>&nbsp; L.G.A </strong></li>


                                       <!--<li class="list-group-item"><span class="pull-right">15,000</span> <span class="label bg-light">3</span> Neosoft company </li>DateOfBirth-->
                                   </ul>
                                   <div class="line line-dashed line-lg pull-in"></div>
                               </div>
                           </div>
                       </section>


                   </ItemTemplate>
                   <EditItemTemplate>

                        <section class="panel panel-default">
                            <header class="panel-heading font-bold">Edit Profile <asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged" /> </header>
                            <div class="panel-body">
                                <div class=" form form-horizontal">

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Name</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <%#Eval("FirstName") %> <%#Eval("LastName") %>
                                            </span>
                                            <asp:HiddenField ID="hfUserID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"StudentRollNumber") %>' />
                                            <%--<asp:HiddenField ID="hfUserName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"Username") %>' />--%>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>School Name</strong></label>
                                        <div class="col-sm-10">
                                            <span>
                                                <asp:TextBox runat="server" ID="SchoolID" Text='<%#Eval("SchoolId") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="SchoolID" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                            </span>
                                        </div>


                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>First Name</strong></label>

                                        <div class="col-sm-10">
                                            <span>
                                                <asp:TextBox runat="server" ID="FName" Text='<%#Eval("FirstName") %>' CssClass="form-control" />
                                                <asp:RequiredFieldValidator ID="reqSurname" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                    ControlToValidate="FName" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Middle Name</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="MiddleName" Text='<%#Eval("MiddleName") %>' CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="reqOtherNames" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="MiddleName" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                        
                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Last Name</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="LName" Text='<%#Eval("LastName") %>' CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="LName" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                        
                                        </div>
                                    </div> 

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Contact Address</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtContactAddress" Text='<%#Eval("ResidentialAddress") %>' TextMode="MultiLine" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidato1" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="txtContactAddress" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Guidiant Phone Number : </strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="PNumber" Text='<%#Eval("GuidiancePhoneNo") %>' TextMode="SingleLine" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="PNumber" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>

                                        </div>
                                    </div>
                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Date Of Birth :</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="DaOB" Text='<%#Eval("DateOfBirth") %>' TextMode="SingleLine" type="date" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValator1" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="DaOB" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                       
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Bording :</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtbor" Text='<%#Eval("isborder") %>' TextMode="MultiLine" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="txtbor" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Student Mobile Number</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="StudentNum" Text='<%#Eval("StudentPhoneNumber") %>' TextMode="MultiLine" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="StudentNum" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Student Mail</strong></label>
                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="Studmail" Text='<%#Eval("StudentEmail") %>' TextMode="MultiLine" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="(required)" Text="(*)" ForeColor="Red"
                                                ControlToValidate="Studmail" runat="server" SetFocusOnError="True" Display="Dynamic" ValidationGroup="aaaa" /></span>
                                        </div>
                                    </div>


                                    <div class="line line-dashed line-lg pull-in"></div>

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Nationality</strong></label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="Nationality" CssClass="form-control" runat="server" AutoPostBack="true" ViewStateMode="Enabled" OnSelectedIndexChanged="Nationality_SelectedIndexChanged" />
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
                                            <asp:DropDownList ID="lga" CssClass="form-control" runat="server"  />
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

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><strong>Class</strong></label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="clas" runat="server" CssClass="form-control">
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="line line-dashed line-lg pull-in"></div>
                                    <div class="form-group">

                                        <label class="col-sm-2 control-label"></label>
                                        <div class="col-sm-10">
                                           


                                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-sm btn-success pull-right" runat="server" Text="Update Profile" OnClientClick="return confirm('Are you sure you want to save changes?');" CommandName="Update" CommandArgument='<%#Bind("StudentRollNumber") %>' ValidationGroup="aaaa" ><i class="fa fa-upload"></i>&nbsp;Update</asp:LinkButton>&nbsp;&nbsp; &nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkCancelEdit" CssClass="btn btn-sm btn-danger pull-right" runat="server" Text="Cancel Update" CommandName="Cancel" ><i class="fa fa-undo"></i>&nbsp;Cancel</asp:LinkButton></span>

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
