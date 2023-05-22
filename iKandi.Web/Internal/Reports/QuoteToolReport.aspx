<%@ Page Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="QuoteToolReport.aspx.cs" Inherits="iKandi.Web.Internal.Reports.QuoteToolReport" %>

<%@ Register Src="../../UserControls/Reports/QuoteTool.ascx" TagName="QuoteTool"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <uc1:QuoteTool ID="QuoteTool1" runat="server" />
</asp:Content>
