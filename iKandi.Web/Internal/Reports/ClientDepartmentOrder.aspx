<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDepartmentOrder.aspx.cs"
    Inherits="iKandi.Web.ClientDepartmentOrder" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/Forms/BookingCalculator.ascx" TagName="BookingCalculator"
    TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/Reports/CriticalPathReports.ascx" TagName="CriticalPathReport"
    TagPrefix="cpr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <script type="text/javascript">

        function ShowBookingCalculator() 
        {
            $("#bookingCalculatorContainer").show(); 
        }

    </script>

    <div align="right">
        <a href="javascript:void(0)" onclick="ShowBookingCalculator()">Booking Calculator</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="ClientHomePage.aspx">Home</a>
    </div>
    <cpr:CriticalPathReport ID="CriticalPathReport1" runat="server" />
    <div class="divRemarks" id='bookingCalculatorContainer'>
        <div class="form_box">
            <uc1:BookingCalculator ID="BookingCalculator1" runat="server" />
            <div align=center>
                 <input type="button" class="close do-not-disable" onclick="closeRemarks()" />
            </div>
        </div>
    </div>
</asp:Content>
