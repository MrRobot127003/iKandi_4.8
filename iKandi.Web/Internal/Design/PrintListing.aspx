<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintListing.aspx.cs" Inherits="iKandi.Web.PrintListing"  MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>
 

 <%@ Register src="../../UserControls/Lists/Prints.ascx" tagname="Prints" tagprefix="uc1" %>
 

 <asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
 
 
     <uc1:Prints ID="Prints1" runat="server" />
 
 
 </asp:Content>
 