<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="BulkSms.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.School_Administrator.BulkSms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function doTextPost() {
            _doPostBack('<%=txtMessage.ClientID%>',"");
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <asp:ScriptManager ID="script1" runat="server" />
    
    <div class="alert alert-info">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <i class="fa fa-info-sign"></i><span style="font-size:small; color:red; animation:ease-in;"><strong>Heads up!  </strong>After a class has been searched for, message should be typed in before the send bulk sms button will be activated,Thanks...  <a href="#" class="alert-link"></a></span>

        </div>     

    <section class="panel panel-default">
        <div class="panel-heading">Bulk SMS  <label class="caption pull-right">other classes</label><asp:CheckBox runat="server" ID="ClasCheck" AutoPostBack="true" CssClass="pull-right" Title="Classes" ToolTip="Classes other than secondary school" OnCheckedChanged="ClasCheck_CheckedChanged" /></div>
        <div class="panel-body">

            <div class="col-md-9 col-sm-12">
                <asp:DropDownList ID="Classes" runat="server" CssClass="form-control">
                    
                </asp:DropDownList>

            </div>
            <div class="col-md-3 col-sm-12">
                <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" CssClass="btn btn-success" />

            </div>

            <div class="line line-dashed line-lg pull-in"></div>
            <div class="line line-dashed line-lg pull-in"></div>
            <div class="col-md-9 col-sm-12">
                <asp:TextBox ID="txtMessage" runat="server" onkeyup="doTextPost()" TextMode="MultiLine" AutoPostBack="True" CausesValidation="True" OnTextChanged="txtMessage_TextChanged" AutoCompleteType="FirstName" CssClass="form-control" placeholder="Please Insert Messages Here" />

            </div>
            <div class="col-md-3 col-sm-12">
                <asp:UpdatePanel ID="sendSmsSupress" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:Button ID="Send" Text="Send Bulk SMS" runat="server" OnClick="Send_Click" CssClass="btn btn-success" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Send" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>

            <div class="col-md-12">
                <p>
                    <br />
                </p>
            </div>

            
            <div class="table table-responsive">
                <asp:GridView ID="Viewparent" AutoGenerateColumns="false" runat="server" Width="100%" GridLines="None" EmptyDataText="No Records for this class" EmptyDataRowStyle-CssClass="alert-danger" EmptyDataRowStyle-ForeColor="Red" CssClass="table table-responsive table-hover" >
                    <Columns>
                        <asp:BoundField HeaderText="Parent Name" DataField="GuidianceName" HeaderStyle-BackColor="#E8E8E8" />
                        <asp:BoundField HeaderText="Parent Phone Number" DataField="GuidiancePhoneNo" HeaderStyle-BackColor="#E8E8E8" />
                        <asp:BoundField HeaderText="Student Name" DataField="Name" HeaderStyle-BackColor="#E8E8E8" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </section>
</asp:Content>
