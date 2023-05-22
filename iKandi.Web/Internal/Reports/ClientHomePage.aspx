<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientHomePage.aspx.cs" 
Inherits="iKandi.Web.ClientHomePage" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/Forms/BookingCalculator.ascx" TagName="BookingCalculator"
    TagPrefix="uc1" %>

<%@ Register src="../../UserControls/Lists/clientHomePage.ascx" tagname="clientHomePage" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <script type="text/javascript">

        function ShowBookingCalculator() 
        {
            $("#bookingCalculatorContainer").show(); 
        }

    </script>
    <uc2:clientHomePage ID="clientHomePage1" runat="server" />
</asp:Content>
