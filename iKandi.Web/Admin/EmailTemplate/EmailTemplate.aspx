<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplate.aspx.cs" Inherits="iKandi.Web.EmailTemplate" MasterPageFile="~/layout/Secure.Master" %>


<%@ Register src="~/UserControls/Forms/EmailTemplateForm.ascx" tagname="EmailTemplateForm" tagprefix="uc1" %>


<asp:Content ID="Content" ContentPlaceHolderID="cph_main_content" runat="server">
 
      
    <uc1:EmailTemplateForm ID="EmailTemplateForm1" runat="server" />
 
      
    </asp:Content>