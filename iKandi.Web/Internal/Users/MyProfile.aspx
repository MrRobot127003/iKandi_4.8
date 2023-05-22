<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="MyProfile.aspx.cs" Inherits="iKandi.Web.UserMyProfile" %>

<%@ Register src="../../UserControls/Forms/MyProfile.ascx" tagname="MyProfile" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
   


   

   
    <uc1:MyProfile ID="MyProfile1" runat="server" />
   


   

   
</asp:Content>