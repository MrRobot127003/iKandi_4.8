<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCMTAdmin.aspx.cs" Inherits="iKandi.Web.Admin.CMT_Admin.frmCMTAdmin"
    MasterPageFile="~/layout/Secure.Master" %>



<%@ Register src="../../UserControls/Forms/CMTAdminfrom.ascx" tagname="CMTAdminfrom" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">


</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="cph_main_content" runat="server">
 

 
 
    <uc1:CMTAdminfrom ID="CMTAdminfrom1" runat="server" />
 

 
 
</asp:Content>
