<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveTypesAdmin.aspx.cs"
    MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.Admin.Leave.LeaveTypesAdmin" %>

<%@ Register Src="~/UserControls/Lists/LeaveTypes.ascx" TagName="LeaveTypes" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:LeaveTypes runat="server">
    </uc1:LeaveTypes>
</asp:Content>
 