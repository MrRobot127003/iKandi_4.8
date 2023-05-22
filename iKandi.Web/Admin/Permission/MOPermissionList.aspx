<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOPermissionList.aspx.cs" Inherits="iKandi.Web.Admin.Permission.MOPermissionList"  MasterPageFile="~/layout/Secure.Master" %>



<%@ Register src="../../UserControls/Lists/MOPermissionList.ascx" tagname="MOPermissionList" tagprefix="uc1" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
 
    <uc1:MOPermissionList ID="MOPermissionList2" runat="server" />
      
 </asp:Content>
