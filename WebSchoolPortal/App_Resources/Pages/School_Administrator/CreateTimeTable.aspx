<%@ Page Title="" Language="C#" MasterPageFile="~/App_Resources/MasterPage/AppMaster.Master" AutoEventWireup="true" CodeBehind="CreateTimeTable.aspx.cs" Inherits="WebSchoolPortal.App_Resources.Pages.AllGeneral.CreateTimeTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../Scripts/moment.js"></script>
<script src="../../../js/jquery.min.js">

    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MidBodyPlacholder" runat="server">
    <section class="panel panel-default">
        <div class="panel-heading">Create Time Table</div>
        <div class="panel-body">
            <div class="col-md-6">
                <div class="table table-responsive">
                    <table class="table table-responsive">
                        <tr>
                            <td><label>School Id:</label></td><td><asp:Label ID="SchoolId" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <label>Day : </label>
                            </td>
                            <td>
                                <asp:DropDownList ID="day" runat="server" CssClass="form-control">
                                    <asp:ListItem>Monday</asp:ListItem>
                                    <asp:ListItem>Tuesday</asp:ListItem>
                                    <asp:ListItem>Wednesday</asp:ListItem>
                                    <asp:ListItem>Thursday</asp:ListItem>
                                    <asp:ListItem>Friday</asp:ListItem>
                                    <asp:ListItem>Saturday</asp:ListItem>
                                    <asp:ListItem>Sunday</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <label>Number Of Periods for Chossen day :</label></td>
                            <td>
                                <asp:TextBox ID="NumbersOfPeriods" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSchoolStart" runat="server">School Start :</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="FirstPeriodTime" type="time" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="nextTime" runat="server" CssClass="input-lg" BorderStyle="Groove"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="StartTime" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="HiddenValue" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="HowLongInMins" type="number" runat="server" placeholder="How long (in mins)" class="form-control" />

                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>

                                <asp:Button ID="addPeriods" class="btn btn-primary btn-rounded" OnClick="addPeriods_Click" runat="server" Text="Add Periods" />

                                <asp:Button ID="MakeDefault" runat="server" Text="Make setting default for selected day" OnClick="MakeDefault_Click" class="btn btn-primary btn-rounded" />
                            </td>
                        </tr>
                        <tfoot>
                            <asp:Label ID="Config" runat="server" CssClass="col-md-4"></asp:Label>

                        </tfoot>
                    </table>


                </div>



            </div>
            <div class="col-md-6"></div>
        </div>
    </section>

        
    <script>
        $("#<%=MakeDefault.ClientID%>").click(function () {
            
            
        });

        $("#<%=addPeriods.ClientID%>").click(function () {
            var duration = $("#<%=HowLongInMins.ClientID%>").val();
             var config = $("#<%=Config.ClientID%>").text();
            var hiddenPeriod = $("#<%=HiddenValue.ClientID%>").val();
            var nextPeriodStart = $("#<%=nextTime.ClientID%>").text();
            var startLabel = $("#<%=StartTime.ClientID%>").text();
            var InitialPeriodTime = $("#<%=FirstPeriodTime.ClientID%>").val();
            if (config == "")
            {
                $("#<%=HiddenValue.ClientID%>").val(moment(startLabel, "H:m").add(duration, 'm').format("H:m"));
            }
            else
            {
                $("#<%=HiddenValue.ClientID%>").val(moment(hiddenPeriod, "H:m").add(duration, 'm').format("H:m"));
            }
        });
        
        function BindGrid() {
            var schoolId=
            $.ajax({
                type: "Post",
                url: "GetDataForAjax.asmx/MakeTimeTable",
                contentType: "application/json;charset=utf-8",
                data:""
            })
        }
    </script>
</asp:Content>
