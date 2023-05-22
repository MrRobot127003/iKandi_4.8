<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="frmMachineattchment.aspx.cs" Inherits="iKandi.Web.Admin.OBAdmin.frmMachineattchment" %>


<%@ Register src="../../UserControls/Forms/frmMachineattachment.ascx" tagname="frmMachineattachment" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

    <uc1:frmMachineattachment ID="frmMachineattachment1" runat="server" />

</asp:Content>
