<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailScheduler.aspx.cs" Inherits="iKandi.Web.Admin.EmailTemplate.EmailScheduler" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="~/UserControls/Forms/EmailSchedulerForm.ascx" tagname="EmailSchedulerForm" tagprefix="uc1" %>


<asp:Content ID="Content" ContentPlaceHolderID="cph_main_content" runat="server">
 
      
    <uc1:EmailSchedulerForm ID="EmailSchedulerForm1" runat="server" />
 
      
    </asp:Content>