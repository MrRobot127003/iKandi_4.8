<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricApprovals.aspx.cs"
    Inherits="iKandi.Web.FabricApprovals" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="../../UserControls/Forms/FabricApprovalForm.ascx" TagName="FabricApprovalForm"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:FabricApprovalForm ID="FabricApprovalForm1" runat="server" />
</asp:Content>
