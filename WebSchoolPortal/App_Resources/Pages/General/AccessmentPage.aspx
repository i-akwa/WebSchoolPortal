<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="AccessmentPage.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.AccessmentPage"  %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
     <asp:ScriptManager ID="Script1" runat="server"/>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

    <asp:SqlDataSource ID="GetArms" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolPortalConnectionString %>" SelectCommand="SELECT [ArmsId], [Arm] FROM [armsTable] WHERE ([SchoolId] = @SchoolId)">
        <SelectParameters>
            <asp:ControlParameter ControlID="SchoolId" Name="SchoolId" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="col-md-4 col-xs-12"> 
    <section class=" panel panel-default">
        <header class="panel-heading">INSERT SCORES(EXAMS/TEST)<i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i><label class="caption pull-right">other classes</label><asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged" /></header>
        <div class="panel-body">

            <div class="form-group">
                <label>Student RollNumber </label>
                <asp:TextBox ID="StudentId" runat="server" placeholder="Roll Number" CssClass="form-control"/>
                <asp:RequiredFieldValidator ID="studVal" runat="server" ForeColor="Red" ControlToValidate="StudentId" ValidationGroup="Sv" Text="Required" />

                <asp:Button ID="StudentSearch" runat="server" CssClass="btn btn-sm btn-primary pull-right" Text="Student Search" OnClick="StudentSearch_Click" ValidationGroup="Sv" />

            </div>
            <div class="line line-dashed line-lg pull-in"></div>

            <div class="form-group">
                <label>Class</label>
                 <asp:DropDownList runat="server" ID="Classselect" CssClass="form-control">
                </asp:DropDownList>

                <asp:Button ID="ClassSearch" runat="server" CssClass="btn btn-sm btn-primary pull-right"  Text="Class Search" OnClick="ClassSearch_Click" />

            </div>
            <div class="line line-dashed line-lg pull-in"></div>

            <div class="form-group">
                <label>Class Arm</label>
                 <asp:DropDownList runat="server" ID="arms" CssClass="form-control"  DataSourceID="GetArms" DataTextField="Arm" DataValueField="ArmsId"/>

            </div>

            <div class="form-group">
                <label>Choose Term</label>
                <asp:DropDownList ID="Term" runat="server"  CssClass="form-control" >
                    <asp:ListItem Text="--!--"></asp:ListItem>
                    <asp:ListItem Text="1"></asp:ListItem>
                    <asp:ListItem Text="2"></asp:ListItem>
                    <asp:ListItem Text="3"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label> Subject Name</label>
            <asp:DropDownList ID="Subject" runat="server" CssClass="form-control" AppendDataBoundItems="True"  DataTextField="SubjectName" DataValueField="SubjectName" >
                
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Entry Type</label>
           <asp:DropDownList ID="Entry" runat="server" CssClass="form-control">
                <asp:ListItem Text=""></asp:ListItem>
                <asp:ListItem Text="Test"></asp:ListItem>
                <asp:ListItem Text="Examination"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Test Type</label>
         <asp:TextBox ID="TestType" runat="server" MaxLength="3" PlaceHolder="CAT TYPE" CssClass="form-control" Type="number" />

               <!-- <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Do Loop" />-->
            
            </div>

        </div>
    </section>
        </div>

    <div class="col-md-8 col-xs-12"> 
    <section class=" panel panel-default">
        <header class="panel-heading"> <i title="" data-original-title="" class="fa fa-info-sign text-muted" data-toggle="tooltip" data-placement="bottom" data-title="ajax to load the data."></i></header>
        <div class="panel-body">

            <div class="col-sm-4 dataTables_length">
                
                    <label>School ID</label>
                    <asp:TextBox ID="SchoolId" runat="server" placeholder="School Id" CssClass="form-control" Enabled="False" ReadOnly="True">
                    </asp:TextBox>
                

            </div>
            <div class="col-sm-4 dataTables_length">
                <label>TeacherID</label>
                <asp:TextBox ID="FillersID" runat="server" placeholder="FillersID" CssClass="form-control" Enabled="False" ReadOnly="True" />
            </div>

            <div class="col-sm-4 dataTables_length">
                <label>Date</label>
                <asp:TextBox ID="Date" runat="server" type="date" CssClass="form-control" />
            </div>

            
                <div class="clearfix"><br /></div>
            
            <div class="table table-responsive" style="padding-top:20px;">
                <asp:GridView ID="FillScores" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-responsive" Width="100%"  EmptyDataText="No record found" EmptyDataRowStyle-CssClass="alert-danger" EmptyDataRowStyle-ForeColor="Red" DataKeyNames="StudentRollNumber">
                    <Columns>
                        <asp:BoundField HeaderText="Roll Number" DataField="StudentRollNumber" HeaderStyle-BackColor="#E8E8E8" />
                        <asp:BoundField HeaderText="First Name" DataField="FirstName" HeaderStyle-BackColor="#E8E8E8" />
                        <asp:BoundField HeaderText="Last Name" DataField="LastName" HeaderStyle-BackColor="#E8E8E8" />
                        <asp:TemplateField HeaderText="Scores" HeaderStyle-BackColor="#E8E8E8">
                            <ItemTemplate>
                                <asp:TextBox ID="Scores" CssClass="form-control" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>

            <div class="clearfix"></div>
            <asp:Button ID="Insert" runat="server" Text="Insert All Rows" OnClick="Insert_Click" OnClientClick="return confirm('Are you sure you want to insert this data?');" CssClass="btn btn-primary pull-right"  /></td>


        </div>
    </section>
      </div>         

   
            </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Insert" />
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
            </asp:UpdatePanel>
</asp:Content>
