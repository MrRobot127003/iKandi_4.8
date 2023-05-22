<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricAccessoriesWorkSheet.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="iKandi.Web.FabricAccessoriesWorkSheet" MasterPageFile="~/layout/Secure.Master" Theme="ikandi" %>
<%--<%@ Register Src="~/UserControls/Forms/FabricAccessoriesForm.ascx" TagName="FabricAccessoriesForm" TagPrefix="iKandi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server"> 
    
    <iKandi:FabricAccessoriesForm ID="ucFabricAccessoriesForm" runat="server" />
                  
</asp:Content>--%>

<%@ Register Src="~/UserControls/Forms/FabricAccessoriesFormNew.ascx" TagName="FabricAccessoriesFormNew" TagPrefix="iKandi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server"> 
    
    <iKandi:FabricAccessoriesFormNew ID="ucFabricAccessoriesFormNew" runat="server" />
                  
</asp:Content>
