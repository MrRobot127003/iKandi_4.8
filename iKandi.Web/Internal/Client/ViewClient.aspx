<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.ViewClient" %>
<%@ Register src="../../UserControls/View/ClientView.ascx" tagname="ClientView" tagprefix="uc1" %>


 <asp:Content ID="Content1" ContentPlaceHolderID=cph_main_content runat=server >
 
     
     <uc1:ClientView ID="ClientView1" runat="server" />
 
     
 </asp:Content>