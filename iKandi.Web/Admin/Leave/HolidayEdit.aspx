<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolidayEdit.aspx.cs" Inherits="iKandi.Web.HolidayEdit" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="../../UserControls/Lists/HolidayAdmin.ascx" tagname="HolidayAdmin" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:HolidayAdmin ID="HolidayAdmin1" runat="server" />
</asp:Content>
