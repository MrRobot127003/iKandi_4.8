<%@ Page Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="frmFactorywiseworkforceMMR.aspx.cs" Inherits="iKandi.Web.Admin.OBAdmin.frmFactorywiseworkforceMMR" %>

<%@ Register src="~/UserControls/Forms/frmFactorywiseforceMMR.ascx" tagname="frmFactorywiseworkforce" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">


</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="cph_main_content" runat="server">

 
    <uc1:frmFactorywiseworkforce ID="frmFactorywiseworkforce1" runat="server" />

</asp:Content>
