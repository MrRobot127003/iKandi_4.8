<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUserAttachment.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.Admin.OBAdmin.FrmUserAttachment" %>
<%@ Register src="~/UserControls/Forms/FrmUserAttachment.ascx" tagname="FrmUserAttachment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">


</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="cph_main_content" runat="server">

 
    <%--<uc1:FrmUserAttachment ID="frmFactorywiseworkforce1" runat="server" />--%>

    <uc1:FrmUserAttachment ID="FrmUserAttachment1" runat="server" />

</asp:Content>