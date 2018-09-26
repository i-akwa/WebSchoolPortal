<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="RegisterSchoolAdmin.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.App_Administrator.RegisterSchoolAdmin" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta charset="utf-8" /> 
<title>Automated Schools</title> 
<meta name="description" content="Automated schools management system is a responsive web based application which will give you much power to take your school to greater height.It has admin dashboard, teacher dashboard, student dashboard" /> 
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" /> 
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../css/app.v1.css" rel="stylesheet" />
</head>
    <body>
        <form runat="server" id="form1">
            <script type="text/javascript">
            function check1_ClientValidate(sender, e) {
                e.IsValid = jQuery(".AcceptedAgreement input:checkbox").is(':checked');
            }
        </script>
            <header class="bg-dark dk header navbar navbar-fixed-top-xs">
                <div class="navbar-header aside-md">
                    <a class="btn btn-link visible-xs" data-toggle="class:nav-off-screen,open" data-target="#nav,html">
                        <i class="fa fa-bars"></i>
                    </a>
                    <a href="#" class="navbar-brand" data-toggle="fullscreen">
                        <asp:Image ID="img1" runat="server" ImageUrl="~/App_Resources/images/logo.png" CssClass="m-r-sm" />
                        HEZDIKES
                    </a>
                    <a class="btn btn-link visible-xs" data-toggle="dropdown" data-target=".nav-user">
                        <i class="fa fa-cog"></i>
                    </a>
                </div>
                  
            </header>
           
            <section class="panel panel-default">
                <div class="panel-heading"><center><h3>Complete School Registration</h3></center></div>
                <div class="panel-body">

                    <div class="col-sm-6 col-md-6" >
                        <div class="col-md-6" style="margin-top:8px">
                            
                            <asp:TextBox required placeholder="Sur Name" ID="SurName" CssClass="form-control input-lg" runat="server" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="SurName" ErrorMessage="Required"
                                 ForeColor="Red" ToolTip="Surname Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />
                        </div>
                       
                        <div class="col-md-6" style="margin-top:8px">
                            <asp:TextBox placeholder="Other Names" required ID="OtherNames" CssClass="form-control input-lg" runat="server" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="OtherNames" ErrorMessage="Required"
                                 ForeColor="Red" ToolTip="OtherNames Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />
                        </div>

                        <div class="col-md-6" style="margin-top:30px">
                            <asp:TextBox ID="StreetName" required placeholder="Street Address" CssClass="form-control input-lg" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="StreetName" 
                                ErrorMessage="Required" ForeColor="Red" ToolTip="STREET NAME Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />
                        </div>

                        <div class="col-md-6" style="margin-top:30px">
                            <asp:DropDownList ID="Gender" CssClass="form-control input-lg" runat="server" TextMode="SingleLine">
                                <asp:ListItem Selected="True">-SELECCT GENDER-</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Gender" ErrorMessage="Required" ForeColor="Red"
                                 ToolTip="Gender Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />
                        </div>

                        <div class="col-md-6" style="margin-top:30px">
                            <asp:DropDownList ID="Nationality" CssClass="form-control input-lg "
                                 TextMode="SingleLine" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Nationality_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="State" ErrorMessage="Required"
                                 ForeColor="Red" ToolTip="Country Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />
                        </div>

                        <div class="col-md-6" style="margin-top:30px">
                            <asp:DropDownList ID="State" CssClass="form-control input-lg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="State_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="State" ErrorMessage="Required" ForeColor="Red" ToolTip="State Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />

                        </div>

                        <div class="col-md-6" style="margin-top:30px">
                            <asp:DropDownList ID="lga" CssClass="form-control input-lg" runat="server" TextMode="SingleLine" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="lga" ErrorMessage="Required" ForeColor="Red" ToolTip="Local government Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />
                        </div> 

                         <div class="col-md-6" style="margin-top:30px">
                            <asp:TextBox ID="Email" required type="mail"  runat="server" AutoCompleteType="Disabled" autocomplete="off" class="form-control input-lg"
                                data-required="true" placeholder="test@example.com" data-toggle="tooltip" data-placement="top" title="" data-original-title="Email" />
                            <asp:RequiredFieldValidator ID="mail" Text="Required" runat="server" ToolTip="Email required" ControlToValidate="Email" ValidationGroup="CreateUserWizard1"/>
                        </div>

                        <div class="col-md-6" style="margin-top:30px">
                            <asp:CheckBox ID="isGovSch" runat="server" AutoPostBack="True" OnCheckedChanged="isGovSch_CheckedChanged" CssClass="form-control" Text="Gov. Schools Only" /><span class="check"></span>
                        </div>
                        
                        <div class="col-md-6" style="margin-top:30px">
                            <asp:TextBox placeholder="Phone Number eg. 0801 234 1234" required ID="MobilePin" AutoCompleteType="Disabled" autocomplete="off" runat="server" data-required="true" type="text" MaxLength="11"
                                class="form-control input-lg "  data-toggle="tooltip" data-placement="top" title="" data-original-title="Phone Number" />
                        </div>
                        
                        <div class="col-md-6" style="margin-top:30px">
                            <asp:TextBox placeholder="" ID="SchoolId" required CssClass="form-control input-lg" runat="server" ReadOnly="True" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="SchoolId" ErrorMessage="Required"
                                 ForeColor="Red" ToolTip="School Id Requried" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />
                        </div>

                        <div class="col-md-6" style="margin-top:30px">
                            <asp:TextBox Type="date" ID="RegistrationDate" required CssClass="form-control input-lg" runat="server" placeholder="dd/mm/yyyy" />
                        </div>
                        <div class="col-md-6" style="margin-top:30px">
                            <asp:TextBox placeholder="School Name" ID="SchoolName" required CssClass="form-control input-lg" runat="server" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="SchoolName" ErrorMessage="Required"
                                ForeColor="Red" ToolTip="SchoolName Required" Display="Dynamic" Text="*" runat="server" ValidationGroup="CreateUserWizard1" />

                        </div>
                        <div class="col-md-6" style="margin-top:30px">
                            <asp:TextBox placeholder="Postal Code" ID="SchoolPostalCode" required CssClass="form-control input-lg" runat="server" TextMode="SingleLine" />

                        </div>                       
                    </div>
                    <div class="col-sm-6 col-md-6">


                        <div class="col-md-12" style="margin-top:8px">
                            <asp:TextBox ID="UserName" runat="server"  data-required="true" required class="form-control input-lg" placeholder="Username" type="text"
                                data-toggle="tooltip" data-placement="top" title="" data-original-title="Username" />
                            <asp:RequiredFieldValidator ID="userN" ValidationGroup="CreateUserWizard1" runat="server" ControlToValidate="UserName" ToolTip="Username required" Text="Required" ForeColor="Red" />

                        </div>
                       

                        <div class="col-md-12" style="margin-top:12px"> 
                            <asp:TextBox ID="Password"  AutoCompleteType="Disabled" required autocomplete="off" runat="server" type="password" class="form-control  input-lg"
                                 data-required="true" placeholder="Type Password" TextMode="Password" data-toggle="tooltip" data-placement="top" title="" data-original-title="Password" />
                        </div>

                        <div class="col-md-12" style="margin-top:30px">
                            <asp:TextBox ID="ConfirmPassword"  type="password" runat="server" required class="form-control input-lg" data-equalto="#Password"
                                 placeholder="Retype Password" data-required="true" TextMode="Password" data-toggle="tooltip" data-placement="top" title="" data-original-title="Retype Password" />
                            <asp:CompareValidator ID="com1" AutoCompleteType="Disabled" autocomplete="off" runat="server" ControlToCompare="Password" ErrorMessage="password mismatch"
                             ToolTip="password mismatch" Text="*" ValidationGroup="CreateUserWizard1" ControlToValidate="ConfirmPassword" />
                        </div>
                        
                        <div class="col-md-12" style="margin-top:12px">
                            <asp:TextBox ID="Question"  AutoCompleteType="Disabled" required autocomplete="off" runat="server" ReadOnly="true" class="form-control input-lg" data-equalto="#Password" 
                                placeholder="Password Question" data-required="true" type="text" data-toggle="tooltip" data-placement="top" title="" data-original-title="password Question" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Question" Text="Required" ToolTip="Password question required" ValidationGroup="CreateUserWizard1" />
                        </div>

                        <div class="col-md-12" style="margin-top: 12px">
                            <asp:TextBox ID="Answer" AutoCompleteType="Disabled" autocomplete="off" runat="server" class="form-control input-lg" data-equalto="#Password"
                                placeholder="password Answer" data-required="true" type="text" data-toggle="tooltip" data-placement="top" title="" data-original-title="Password Answer" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Answer" Text="Required" ToolTip="Password answer required" ValidationGroup="CreateUserWizard1" />
                        </div>

                        <div class="col-md-12" style="margin-top:12px">
                            <label>
                                <asp:CheckBox runat="server" ID="check1"/>
                                I Agree to the <a href="termsandpolicy.aspx" data-toggle="ajaxModal">terms and policy</a>
                            </label>

                        </div>
                        <div class="col-md-12" style="margin-top:12px">
                            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" ValidationGroup="CreateUserWizard1" CssClass="btn btn-dark form-control" />

                        </div>

                        <br />
                        <br />                        
                    </div>


                </div>
            </section>
        <script src="../../js/jquery.min.js"></script>
        <!-- Bootstrap -->
        <script src="../../js/bootstrap.js"></script>

        <!-- App -->
        <script src="../../js/app.js"></script>
        <script src="../../js/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="../../js/app.plugin.js"></script>
        <script src="../../js/select2/select2.min.js"></script>
        <script src="../../js/fuelux/fuelux.js"></script>        
            </form>

    </body>

    </html>

