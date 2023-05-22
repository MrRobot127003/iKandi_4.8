<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Holiday.aspx.cs" Inherits="iKandi.Web.Holiday"  MasterPageFile="~/layout/Secure.Master"%>


<%@ Register src="../../UserControls/Lists/HolidayList.ascx" tagname="HolidayList" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

     

    

    <uc1:HolidayList ID="HolidayList1" runat="server" />

     

    

</asp:Content>
