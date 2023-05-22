<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricSamplingReport.aspx.cs" Inherits="iKandi.Web.FabricSamplingReport" EnableEventValidation="false" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="../../UserControls/Reports/FabricSampling.ascx" tagname="FabricSampling" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

   

    <uc1:FabricSampling ID="FabricSampling1" runat="server" />
    

   

</asp:Content>
