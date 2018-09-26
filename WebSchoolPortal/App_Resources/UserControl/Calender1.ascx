<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calender1.ascx.cs" Inherits="WebSchoolPortal.App_Resources.UserControl.Calender1" %>
                                <asp:DropDownList ID="Ddyear" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="DdyearSelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Ddmonth" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="DdmonthSelectedIndexChanged">
                                    <asp:ListItem Value="00">*Month*</asp:ListItem>
                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                    <asp:ListItem Value="03">March</asp:ListItem>
                                    <asp:ListItem Value="04">april</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                    <asp:ListItem Value="06">June</asp:ListItem>
                                    <asp:ListItem Value="07">July</asp:ListItem>
                                    <asp:ListItem Value="08">August</asp:ListItem>
                                    <asp:ListItem Value="09">Sept</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Calendar ID="cal1" runat="server" BackColor="White" BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="100%" CellPadding="4" DayNameFormat="Shortest" OnDayRender="cal1_DayRender">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>