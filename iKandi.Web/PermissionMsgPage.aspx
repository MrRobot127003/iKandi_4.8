<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="PermissionMsgPage.aspx.cs" Inherits="iKandi.Web.PermissionMsgPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<div style="width:600px; margin:0px auto; border:2px dashed #9E9A9A">
<h1 style="color:red; text-align:center; font-family:arial;">
<div> <img src="App_Themes/ikandi/images/Key-Icon-250x250.jpg" align="center"> </div>
You Have Not a Permission To Access <asp:Label ID="lblpagename" runat="server"></asp:Label> Page.
</h1>

</div>
</asp:Content>
