<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingSTCReport.aspx.cs" Inherits="iKandi.Web.PendingSTCReport"  MasterPageFile="~/layout/Secure.Master"%>

<%@ Register src="../../UserControls/Reports/SealerPendingReport.ascx" tagname="SealerPendingReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

   

    <uc1:SealerPendingReport ID="SealerPendingReport1" runat="server" />

   

</asp:Content>