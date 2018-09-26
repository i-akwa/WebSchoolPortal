<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="SubjectTeachers.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.SubjectTeachers" %>

<%@ MasterType VirtualPath="~/App_Resources/MasterPage/AppMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <section class="panel panel-default">
        <div class="panel-heading">Manage Teachers<asp:CheckBox runat="server" ID="ClasCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClasCheck_CheckedChanged"  /></div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-3 col-sm-12">
                    <div class="dataTables_length"  id="DataTables_Table_ 0length">
                        <asp:DropDownList CssClass="input-control text form-control " ID="TeacherId" runat="server" DataSourceID="TeachersId" DataTextField="TeacherRollId" DataValueField="TeacherRollId" AutoPostBack="True" OnSelectedIndexChanged="TeacherId_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                        <asp:TextBox ID="HiddenSubject" runat="server" />
                        <asp:SqlDataSource ID="TeachersId" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [TeacherRollId] FROM [TeacherTab] WHERE ([SchoolId] = @SchoolId)" OnSelecting="TeachersId_Selecting">
                            <SelectParameters>
                                <asp:SessionParameter Name="SchoolId" SessionField="SchoolId" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
                <div class="col-md-3 col-sm-12">
                    <div class="dataTables_length"  id="DataTables_Table0length">
                        <asp:DropDownList CssClass="input-control text form-control" ID="SubjectName" runat="server" DataSourceID="Subject" DataTextField="SubjectName" DataValueField="SubjectID" Width="100%"></asp:DropDownList>

                        <asp:SqlDataSource runat="server" ID="Subject" ConnectionString='<%$ ConnectionStrings:DBConnection %>' SelectCommand="SELECT [SubjectID], [SubjectName] FROM [subjectTable] WHERE ([SchoolID] = @SchoolID)">
                            <SelectParameters>
                                <asp:SessionParameter SessionField="SchoolId" Name="SchoolID" Type="String"></asp:SessionParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
                <div class="col-md-3 col-sm-12">
                    <div class="dataTables_length">
                        <asp:TextBox CssClass="input-control text form-control" ID="TeachersName" runat="server" placehoder="Teacher's Name" Width="100%"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2 col-sm-12">
                    <div class="dataTables_length">
                        <asp:DropDownList CssClass="input-control text form-control " ID="clas" runat="server" Width="100%">
                            
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-1 col-sm-12 ">

                    <asp:Button CssClass="btn btn-success btn-block pull-right" ID="Insert" Text="Insert" runat="server" OnClick="Insert_Click" />
                    <asp:Button runat="server" CssClass="btn btn-success btn-block pull-right" ID="update" Text="Update" OnClick="update_Click" Width="" />

                </div>
            </div>
            <div class="col-md-12 clear" style="height:50px;"></div>

          


                <div class="table table-responsive">
                    <asp:GridView ID="SubTeach" runat="server" AutoGenerateColumns="False" CssClass="table table-responsive table-hover table-bordered" OnPageIndexChanging="SubTeach_PageIndexChanging" AllowPaging="True" Width="100%" OnRowCommand="SubTeach_RowCommand" GridLines="None">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-ForeColor="Red" />
                            <asp:BoundField HeaderText="TeacherId" DataField="TeachId" />
                            <asp:BoundField HeaderText="TeacherName" DataField="Name" />
                            <asp:BoundField HeaderText="SubjectName" DataField="SubName" />
                            <asp:BoundField HeaderText="Subject ID" DataField="SubId" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="upd" CssClass="btn btn-sm btn-danger" CommandName="Edt" Text="Edit" runat="server" CommandArgument='<%#Bind("ID") %>' >&nbsp;<i class="fa fa-edit danger"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>

    </section>
</asp:Content>
