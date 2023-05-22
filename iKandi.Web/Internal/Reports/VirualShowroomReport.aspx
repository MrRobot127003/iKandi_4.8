<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VirualShowroomReport.aspx.cs" MasterPageFile="~/layout/Secure.Master"  EnableEventValidation="false" Inherits="iKandi.Web.VirualShowroomReport" %>
<%@ Register src="../../UserControls/Reports/VirtualShowroom.ascx" tagname="VirtualShowroom" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:VirtualShowroom ID="VirtualShowroom1" runat="server" />
</asp:Content>