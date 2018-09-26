<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="TeachersRegistration.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.TeachersRegistration" %>
    
<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">
</script>

    <div id="content">
        <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size: small; animation: ease-in;"><strong>Heads up!</strong> Please all Teacher's information should b carefully inserted for smooth registration,Thanks...<a href="#" class="alert-link"></a></span>
        </div>


        <asp:Label ID="CreateAccountResults" runat="server" Text=""></asp:Label>




        <div class="col-md-12 col-sm-12" style="margin-top: 15px;">

            <div class="panel-body">
                <div class="col-md-6">

                    <label><b>First Name:</b></label>
                    <asp:TextBox ID="FName" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FName" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Middle Name:</b></label>
                    <asp:TextBox ID="MName" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="MName" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Last Name:</b></label>
                    <asp:TextBox ID="LName" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="LName" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />


                    <label><b>Date of Brith:</b></label>
                    <asp:TextBox ID="DOB" type="date" runat="server" CssClass="form-control" ValidationGroup="aaaa" data-date-format="dd-mm-yyyy" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="DOB" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Residential Address:</b></label>
                    <asp:TextBox ID="Address" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Address" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />
                </div>

                <div class="col-md-6">

                    <label><b>Nationality:</b></label>
                <asp:DropDownList ID="Nationality" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="Nationality_SelectedIndexChanged" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Nationality" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                <label><b>State:</b></label>
                <asp:DropDownList ID="State" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="State_SelectedIndexChanged" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="State" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                <label><b>Local Government:</b></label>
                <asp:DropDownList ID="LGA" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="LGA" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />


                <label><b>Phone Number:</b></label>
                <asp:TextBox ID="MobilePIN" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="MobilePIN" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                </div>
               
                


            </div>

        </div>



        <div class="col-md-12 col-sm-12">

            <div class="panel-body">
                <div class="col-md-6">
                    <label><b>User Name:</b></label>
                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="UserName" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Password:</b></label>
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Password" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />


                    <label><b>Password Question:</b></label>
                    <asp:TextBox ID="Question" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Question" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Password Answer:</b></label>
                    <asp:TextBox ID="Answer" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Answer" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Teacher Email:</b></label>
                    <asp:TextBox ID="Email" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                </div>
                <div class="col-md-6">
                    <label><b>School ID:</b></label>
                    <asp:TextBox ID="SchoolId" runat="server" CssClass="form-control" ValidationGroup="aaaa" ReadOnly="true" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SchoolId" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Teacher Id:</b></label>
                    <asp:TextBox ID="TeacherId" runat="server" CssClass="form-control" ReadOnly="true" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TeacherId" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Class Teacher:</b></label>
                    <asp:TextBox ID="classTeacher" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ClassTeacher" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Registration Date:</b></label>
                    <asp:TextBox ID="RegDate" type="Date" runat="server" CssClass="form-control" placeHolder="DD/MM/YYYY" ReadOnly="false" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="RegDate" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                    <label><b>Subject:</b></label>
                    <asp:DropDownList ID="Subject" runat="server" CssClass="form-control" ValidationGroup="aaaa" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="Subject" Display="Dynamic" ErrorMessage="(required)" ForeColor="Red" SetFocusOnError="True" Text="(*)" ValidationGroup="aaaa" />

                </div>


            </div>

           
        </div>
         <div  style="margin-bottom:50px">
                <asp:Button ID="CreateStudent" runat="server" Text="CREATE TEACHER" CssClass="form-control btn btn-primary" OnClick="CreateStudent_Click" ValidationGroup="aaaa" />
            </div>
    </div>
        
</asp:Content>
