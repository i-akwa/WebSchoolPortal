<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="StudentRegistrationPage.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.StudentRegistrationPage" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/font.css" rel="stylesheet" />
    <link href="../../js/fuelux/fuelux.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">

    </script>

    <asp:ScriptManager ID="scriptManager1" runat="server" />
    <div id="content">
        <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size: small; color: red; animation: ease-in;"><strong>Heads up!</strong> all the student information should be filled in their respective fields for good student record keeping and profiling,Thanks<a href="#" class="alert-link"></a><asp:Label ID="GInfo" runat="server" Text="" /></span>
        </div>

        <div class="vbox ">
            <div class="scrollable padder">


                <div class="col-md-6 col-sm-12" style="height: 49%; margin-top: 15px;" id="Propix">
                    <section class="panel panel-default">
                        <div class="panel-heading">Capture Image</div>
                        <div class="panel-body">
                            <div style="width: 100%; border: 2px solid #808080; padding: 5px;">
                                <asp:Image ID="Picture" runat="server" Width="100%" Height="270" />
                            </div>
                            <div>
                                <asp:UpdatePanel ID="Update2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:FileUpload ID="Passport" runat="server" Height="22px" Width="217px" />
                                        <asp:Button ID="btnpass" Text="Preview" runat="server" OnClick="btnpass_Click" ValidationGroup="aq" CssClass="btn btn-xs btn-primary" />
                                        <asp:Button ID="sav" Text="Save" runat="server" OnClick="sav_Click" ValidationGroup="aq" CssClass="btn btn-xs btn-primary" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="sav" />
                                        <asp:PostBackTrigger ControlID="btnpass"></asp:PostBackTrigger>
                                        <asp:PostBackTrigger ControlID="btnpass"></asp:PostBackTrigger>
                                    </Triggers>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnpass" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </section>
                </div>


                <div class="col-md-6 col-sm-12" style="margin-top: 10px;">
                    <section class="panel panel-default">
                        <div class="panel-heading">
                            School Account Details 
                            <asp:Label ID="CreateAccountResults" runat="server" Text="" /><asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged" />
                        </div>
                        <div class="panel-body">

                            <label class="label-info"><b>School Id:</b></label>

                            <asp:TextBox ID="schoolid" runat="server" ReadOnly="True" CssClass="form-control" ValidationGroup="CreateUserWizard1" />
                            <asp:RequiredFieldValidator ID="schoolidred" runat="server" ControlToValidate="schoolid" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="CreateUserWizard1" ToolTip="" />

                            <label><b>Student Roll Number</b></label>

                            <asp:TextBox ID="RollNum" ReadOnly="True" runat="server" CssClass="form-control" ValidationGroup="CreateUserWizard1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RollNum" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="CreateUserWizard1" />


                            <label><b>Present Class</b></label>

                            <asp:DropDownList ID="AdmissionClass" runat="server" CssClass="form-control" ValidationGroup="CreateUserWizard1">
                            </asp:DropDownList>

                            <label><b>Arm</b></label>

                            <asp:DropDownList ID="ArmsId" runat="server" CssClass="form-control" ValidationGroup="CreateUserWizard1">
                                <asp:ListItem Selected="True">-Select Class-</asp:ListItem>

                            </asp:DropDownList>

                            <label><b>Admission Date:</b></label>

                            <asp:TextBox ID="AdminDate" type="date" runat="server" CssClass="form-control" required ValidationGroup="CreateUserWizard1" />

                            <label><b>Date Of Birth:</b></label>

                            <asp:TextBox ID="DateOfBirth" type="date" runat="server" CssClass="form-control" required ValidationGroup="CreateUserWizard1" />
                            <%--<ajx:CalendarExtender runat="server" Animated="true" TargetControlID="RegDate" />--%>


                            <label><b>User Name:</b></label>
                            <asp:TextBox ID="UserName" runat="server"  required CssClass="form-control" ValidationGroup="CreateUserWizard1" />

                            <label><b>Email</b></label>
                            <asp:TextBox ID="Email" type="email" required runat="server" placeholder="example@xmail.com" CssClass="form-control" ValidationGroup="CreateUserWizard1" />

                            <label><b>Password</b></label>
                            <asp:TextBox ID="Password" runat="server" required CssClass="form-control active" TextMode="Password" ViewStateMode="Disabled" placeholder="Password" ValidationGroup="CreateUserWizard1" />

                            <label><b>Password Question</b></label>
                            <asp:TextBox ID="Question" runat="server" CssClass="form-control" required ValidationGroup="CreateUserWizard1" />

                            <label><b>Password Answer</b></label>
                            <asp:TextBox ID="Answer" runat="server" required CssClass="form-control" ValidationGroup="CreateUserWizard1" />

                        </div>
                    </section>
                </div>
                <div class="col-md-6 col-sm-12" style="margin-top: 15px;">
                    <section class="panel panel-default" style="height: 49%;">
                        <div class="panel-heading">Personal Details</div>
                        <div class="panel-body">
                            <label><b>First Name</b></label>
                            <asp:TextBox ID="FName" runat="server" CssClass="form-control" ValidationGroup="CreateUserWizard1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="FName" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="CreateUserWizard1" />

                            <label><b>Middle Name</b></label>
                            <asp:TextBox ID="MName" runat="server" CssClass="form-control" required ValidationGroup="CreateUserWizard1" />

                            <label><b>Last Name</b></label>
                            <asp:TextBox ID="LName" runat="server" required CssClass="form-control" ValidationGroup="CreateUserWizard1" />

                            <label><b>Guardian Name:</b></label>
                            <asp:TextBox ID="GuidiantName" runat="server" required CssClass="form-control" ValidationGroup="CreateUserWizard1" />

                            <label><b>Sex</b></label>
                            <asp:DropDownList ID="Gender" runat="server" CssClass="form-control" ValidationGroup="CreateUserWizard1">
                                <asp:ListItem Selected="True">-SELECT GENDER-</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>

                            <label><b>Guardian Mobile Number</b></label>
                            <asp:TextBox ID="GMobNum" runat="server" required CssClass="form-control" ValidationGroup="CreateUserWizard1" />

                            <label><b>Residential Address</b></label>
                            <asp:TextBox ID="Address1" runat="server" CssClass="form-control" ValidationGroup="CreateUserWizard1" TextMode="MultiLine" required />


                            <asp:UpdatePanel ID="SupressdropPostback" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <label><b>Select Nationality</b></label>
                                    <asp:DropDownList ID="Nation" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="Nation_SelectedIndexChanged" ValidationGroup="CreateUserWizard1" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Nation" Display="Dynamic" ErrorMessage="Required" ForeColor="Red" Text="*" ToolTip="Nationality Required" ValidationGroup="CreateUserWizard1" />

                                    <label><b>Select State</b></label>
                                    <asp:DropDownList ID="State" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="State_SelectedIndexChanged" ValidationGroup="CreateUserWizard1" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="State" Display="Dynamic" ErrorMessage="Required" ForeColor="Red" Text="*" ToolTip="State Required" ValidationGroup="CreateUserWizard1" />

                                    <label><b>Select LGA</b></label>
                                    <asp:DropDownList ID="lga" runat="server" CssClass="form-control" ValidationGroup="CreateUserWizard1" />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="lga" Display="Dynamic" ErrorMessage="Required" ForeColor="Red" Text="*" ToolTip="Lga Required" ValidationGroup="CreateUserWizard1" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div style="height: 10px"></div>
                            <asp:Button ID="BtnCreateUser" CssClass="form-control btn btn-primary" ValidationGroup="CreateUserWizard1" runat="server" OnClick="BtnCreateUser_Click" Text="CREATE STUDENT" />



                        </div>
                    </section>
                </div>

            </div>
        </div>
        <div>
        </div>
        <span>&nbsp;</span>
    </div>
    <script src="../../js/jquery.min.js"></script>
    <script>
        var toHide = $('#Propix');
        toHide.hide();
    </script>

</asp:Content>

