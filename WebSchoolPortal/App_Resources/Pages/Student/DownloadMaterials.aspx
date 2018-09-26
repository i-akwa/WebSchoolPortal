<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="DownloadMaterials.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.Student.DownloadMaterials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">


    <div class="alert alert-success">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <i class="fa fa-info-sign"></i><strong>Heads up!</strong> <a href="#" class="alert-link">View Students Result:</a> Fill in the required student information  to view the student's result...
    </div>

    <section class="panel panel-default">
        <header class="panel-heading">
            Download Assignment
        </header>
        <div class="panel-body">
            <div class="table table-responsive">

                <asp:GridView ID="DownloadGrid" runat="server" AllowPaging="true" AutoGenerateColumns="false" OnRowCommand="DownloadGrid_RowCommand" CssClass="table-responsive table-hover table-bordered" Width="100%" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="UploadId" />
                        <asp:BoundField HeaderText="Subject" DataField="SubjectName" />
                        <asp:BoundField HeaderText="File type" DataField="FileType" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Date" DataField="UploadDate" />

                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:LinkButton ID="Download" CssClass="btn btn-success" runat="server" CommandName="dwn" CommandArgument='<%#Bind("UploadId") %>'><i class="fa fa-download"></i> </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
            <%--<asp:Button ID="DeleteThem" runat="server" Text="Delete Sorted Names" OnClick="DeleteThem_Click" CssClass="btn btn-primary btn-lg" />--%>
        </div>
    </section>

</asp:Content>
