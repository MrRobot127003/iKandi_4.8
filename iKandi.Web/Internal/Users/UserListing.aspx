<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserListing.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.UserListing" %>

 <%@ Register src="../../UserControls/Lists/Users.ascx" tagname="Users" tagprefix="uc1" %>

 <asp:Content ContentPlaceHolderID="cph_main_content" runat="server" >
 
     <uc1:Users ID="Users1" runat="server" />
 
 </asp:Content>