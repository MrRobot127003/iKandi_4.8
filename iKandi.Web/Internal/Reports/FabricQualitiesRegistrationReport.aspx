<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricQualitiesRegistrationReport.aspx.cs" Inherits="iKandi.Web.FabricQualitiesRegistrationReport" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
<%@ Register src="~/UserControls/Reports/FabricQualities.ascx" tagname="FabricQualities" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:FabricQualities ID="FabricQualities1" runat="server" />
    

</asp:Content>