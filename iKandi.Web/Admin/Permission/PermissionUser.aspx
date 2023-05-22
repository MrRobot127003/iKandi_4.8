<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionUser.aspx.cs" Inherits="iKandi.Web.Permission" MasterPageFile="~/layout/Secure.Master"%>
<%@ Register Src="~/UserControls/Forms/PermissionUserForm.ascx" TagName="Permission" TagPrefix="uc1" %> 

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
      
      <uc1:Permission ID="PermissionUser" runat="server" />
 </asp:Content>

    
    
