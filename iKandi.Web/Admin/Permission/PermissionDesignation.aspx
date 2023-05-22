<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionDesignation.aspx.cs" Inherits="iKandi.Web.PermissionDesignation" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Forms/PermissionDesignationForm.ascx" TagName="PermissionDesignation" TagPrefix="uc1" %> 

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
      
      <uc1:PermissionDesignation ID="PermissionDesignation1" runat="server" />
 </asp:Content>

    