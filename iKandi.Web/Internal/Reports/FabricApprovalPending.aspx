<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricApprovalPending.aspx.cs" Inherits="iKandi.Web.FabricApprovalPending" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>

<%@ Register src="~/UserControls/Reports/FabricApprovalPendingReport.ascx" tagname="FabricApprovalPendingReport" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:FabricApprovalPendingReport ID="FabricApprovalPendingReport1" runat="server" />
    

</asp:Content>
