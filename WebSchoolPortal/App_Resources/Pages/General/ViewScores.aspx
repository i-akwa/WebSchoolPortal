<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="ViewScores.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.General.ViewScores" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script src="../../../js/jquery.min.js" >
      
  </script>
    <script>
        
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <section class="panel panel-default">
        <div class="panel-heading">View Score<asp:Label ID="type" runat="server" Text="">
            <asp:CheckBox runat="server" ID="ClassCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClassCheck_CheckedChanged" /></asp:Label></div>
        <div class="panel-body">
            <div class="table-responsive">
                <asp:Panel ID="TablePanel" runat="server">

                    <table id="tab1" class="table table-responsive">
                        <tr>
                            <td>
                                <label>Year</label></td>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Term</label></td>
                            <td>
                                <asp:DropDownList ID="term" runat="server" CssClass="form-control">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Class</label></td>
                            <td>

                                <asp:DropDownList ID="cls" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cls_SelectedIndexChanged" CssClass="form-control">
                                    
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Arm</label></td>
                            <td>

                                <asp:DropDownList ID="arm" runat="server" DataSourceID="SqlDataSource1" DataTextField="Arm" DataValueField="ArmsId" OnSelectedIndexChanged="arm_SelectedIndexChanged" CssClass="form-control" />
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolPortalConnectionString %>" SelectCommand="SELECT [ArmsId], [Arm] FROM [armsTable] WHERE ([SchoolId] = @SchoolId)">
                                    <SelectParameters>
                                        <asp:CookieParameter CookieName="SchoolId" Name="SchoolId" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Cat Type</label></td>
                            <td>

                                <asp:DropDownList ID="cat" runat="server" CssClass="form-control">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <label>Subject</label></td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="subject" runat="server" DataTextField="SubjectName" DataValueField="SubjectID" CssClass="form-control" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>

                                <asp:RadioButton ID="Test" runat="server" GroupName="scores" Text="TEST" CssClass="radio" />

                                <asp:RadioButton ID="exams" runat="server" GroupName="scores" Text="Exams" CssClass="radio" />
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" CssClass="btn btn-success btn-sm" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                
                <asp:Panel ID="pan1" runat="server">
                    <div class="container-fluid" id="EditDiv" style="margin-bottom:20px;">
                        <asp:HiddenField ID="hidRollnum" runat="server" />
                        <asp:HiddenField ID="hidDate" runat="server" />
                        <asp:HiddenField ID="hidTerm" runat="server" />
                        <asp:HiddenField ID="hidSubjectName" runat="server" />
                        <asp:HiddenField ID="hidTestType" runat="server" />
                        <div class="row">
                            <div class="col-md-1">
                                <h5>Name:</h5>
                            </div>
                            <div class="col-md-11">
                                <h5>
                                    <asp:Label ID="lblNameofStud" runat="server" Text="" /></h5>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1 col-sm-12 col-xs-12">
                                <h5>Scores :</h5>
                            </div>
                            <div class="col-md-7 col-sm-12 col-xs-12">
                                <asp:TextBox type="number" ID="txtEditscores" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <asp:Button ID="btnEdit" runat="server" Text="UPDATE" OnClick="btnEdit_Click1" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>

            </div>
            <div class="table table-responsive">
                <asp:GridView ID="ViewScore" runat="server" AutoGenerateColumns="false" EmptyDataText="No record found for this class" EmptyDataRowStyle-CssClass="alert-danger"
                     EmptyDataRowStyle-ForeColor="Red" AllowPaging="true" CssClass="table table-responsove table-hover"
                     GridLines="None" Width="100%" OnPageIndexChanging="ViewScore_PageIndexChanging" OnRowCommand="ViewScore_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Name" DataField="name"   />
                        <asp:BoundField HeaderText="Roll Number" DataField="rollnum"   />
                        <asp:BoundField HeaderText="Subject Name" DataField="subName"   />
                        <asp:BoundField HeaderText="Date" DataField="Dat"  />
                        <asp:BoundField HeaderText="Class" DataField="Clas"   />
                        <asp:BoundField HeaderText="Scores" DataField="Scores"  />
                        <asp:TemplateField HeaderText="-">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit1" Font-Italic="true" Font-Size="Smaller" ForeColor="Red" runat="server" CssClass="touchEdit" Text="Change" CommandName="Edt" CommandArgument='<%#Bind("rollnum") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </section> 
</asp:Content>
