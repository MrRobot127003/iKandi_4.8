<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryQualityListing.aspx.cs" Inherits="iKandi.Web.AccessoryQualityListing" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>


<%@ Register src="../../UserControls/Lists/AccessoryQualityList.ascx" tagname="AccessoryQualityList" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    
 
    
 
    
    <uc1:AccessoryQualityList ID="AccessoryQualityList1" runat="server" />
    
 
    
 
    
</asp:Content>
