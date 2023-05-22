<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHolidays.aspx.cs" MasterPageFile="~/layout/Secure.Master"  Inherits="iKandi.Web.Admin.UserHolidays" %>

 

<%@ Register src="../UserControls/Lists/UserHolidayEntitlement.ascx" tagname="UserHolidayEntitlement" tagprefix="uc1" %>

 

<asp:Content ID="Content1" runat=server ContentPlaceHolderID=cph_main_content>
<%-- <a href="#" onclick="javascript:window.open('../Internal/Client/clientedit.aspx','Client','width=1150,height=600')">Add New Client</a>--%>
    <uc1:UserHolidayEntitlement ID="UserHolidayEntitlement1" runat="server" />
</asp:Content>
