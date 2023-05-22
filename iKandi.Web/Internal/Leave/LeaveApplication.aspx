<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveApplication.aspx.cs" Inherits="iKandi.Web.LeaveApplication"  MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="../../UserControls/Forms/ApplyLeave.ascx" tagname="ApplyLeave" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <uc1:ApplyLeave ID="ApplyLeave1" runat="server" />

</asp:Content>