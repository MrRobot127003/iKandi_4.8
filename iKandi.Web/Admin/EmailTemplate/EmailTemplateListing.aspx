<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateListing.aspx.cs" Inherits="iKandi.Web.EmailTemplateListing" MasterPageFile="~/layout/Secure.Master" %>


<%@ Register src="~/UserControls/Lists/EmailTemplateList.ascx" tagname="EmailTemplateList" tagprefix="uc1" %>


<asp:Content ID="Content" ContentPlaceHolderID="cph_main_content" runat="server">
 
      
    <uc1:EmailTemplateList ID="EmailTemplateList1" runat="server" />
 
      
    </asp:Content>