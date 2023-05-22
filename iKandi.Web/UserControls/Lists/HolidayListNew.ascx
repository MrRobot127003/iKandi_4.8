<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HolidayListNew.ascx.cs"
    Inherits="iKandi.Web.HolidayListNew" %>
<div>
<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upHoliday" runat="server">
        <ContentTemplate>
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
            <asp:Calendar Width="16.5em" ID="smallCalendar" runat="server" BackColor="White"
                OnDayRender="smallCalendar_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged"
                BorderColor="Black" CellSpacing="0" NextPrevFormat="ShortMonth"
                SelectionMode="None" ForeColor="Black">
                <TodayDayStyle BackColor="#0066ff" ForeColor="White" Font-Bold="true" />
                <TitleStyle ForeColor="#0066ff" BackColor="White" />
                <NextPrevStyle ForeColor="#0066ff" />
                <DayHeaderStyle ForeColor="White" BackColor="#0066ff" BorderColor="Black" BorderWidth="1px" />
                <SelectedDayStyle ForeColor="White" BackColor="#0066ff"/>
                <DayStyle BackColor="white" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black"
                    BorderStyle="Inset" BorderWidth="1px" />
                <OtherMonthDayStyle ForeColor="#999999" />
            </asp:Calendar>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
