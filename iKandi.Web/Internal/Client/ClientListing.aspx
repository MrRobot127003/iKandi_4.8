<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientListing.aspx.cs" MasterPageFile="~/layout/Secure.Master"  Inherits="iKandi.Web.ClientListing" %>

 <%@ Register src="../../UserControls/Lists/Clients.ascx" tagname="Clients" tagprefix="uc1" %>

 <asp:Content ContentPlaceHolderID="cph_main_content" runat="server" >
 
     <uc1:Clients ID="Clients1" runat="server" />
 
 </asp:Content>