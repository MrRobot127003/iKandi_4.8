<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFactorywiseworkforce.aspx.cs" Inherits="iKandi.Web.Admin.OBAdmin.frmFactorywiseworkforce"  MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="~/UserControls/Forms/frmFacorywiseforce.ascx" tagname="frmFactorywiseworkforce" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">


</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="cph_main_content" runat="server">

 
    <uc1:frmFactorywiseworkforce ID="frmFactorywiseworkforce1" runat="server" />

</asp:Content>