<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionDepartment.aspx.cs" Inherits="iKandi.Web.PermissionDepartment" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Forms/PermissionDepartmentForm.ascx" TagName="PermissionDepartment" TagPrefix="uc1" %> 

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph_head">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
      
      <uc1:PermissionDepartment ID="PermissionDepartment1" runat="server" />
 </asp:Content>

    
