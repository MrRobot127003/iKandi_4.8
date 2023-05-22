<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HolidayList.ascx.cs"
    Inherits="iKandi.Web.HolidayList" %>
<div>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
        SelectionMode="None" Font-Size="9pt" ForeColor="Black" Height="100%" NextPrevFormat="ShortMonth"
        Width="100%" CellSpacing="0" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
        <SelectedDayStyle ForeColor="White" />
        <TodayDayStyle BackColor="#E91677" ForeColor="White" />
        <DayStyle BackColor="white" Height="100px" HorizontalAlign="Center" VerticalAlign="Middle"
            BorderColor="Black" BorderStyle="Inset" BorderWidth="1px" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <NextPrevStyle Font-Size="20px" ForeColor="#E91677" />
        <DayHeaderStyle Font-Size="18px" ForeColor="Black" BackColor="#F9DDF4" Height="20px"
            BorderColor="Black" BorderWidth="1px" />
        <TitleStyle Font-Size="20px" ForeColor="#E91677" BackColor="White" Height="20px" />
    </asp:Calendar>
    <asp:Calendar ID="smallCalendar" runat="server" BackColor="White" OnDayRender="Calendar1_DayRender"
        OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" TodayDayStyle-CssClass="column_color"
        BorderColor="Black" CellSpacing="0" NextPrevFormat="ShortMonth" SelectionMode="None"
        ForeColor="Black">
        <TodayDayStyle BackColor="#E91677" ForeColor="black" Font-Bold=true />
        <TitleStyle ForeColor="#E91677" BackColor="White" />
        <NextPrevStyle ForeColor="#E91677" />
        <DayHeaderStyle ForeColor="Black" BackColor="#F9DDF4" BorderColor="Black" BorderWidth="1px" />
        <SelectedDayStyle ForeColor="White" />
        <DayStyle BackColor="white" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black"
            BorderStyle="Inset" BorderWidth="1px" />
        <OtherMonthDayStyle ForeColor="#999999" />
    </asp:Calendar>
</div>
