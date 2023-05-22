<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="INDBlockListing.aspx.cs" Inherits="iKandi.Web.INDBlockListing"   MasterPageFile="~/layout/Secure.Master"%>


 <%@ Register src="../../UserControls/Lists/INDBlock.ascx" tagname="INDBlock" tagprefix="uc1" %>
 

 <asp:Content ID="Content1" ContentPlaceHolderID=cph_main_content runat=server >
 
 
     <uc1:INDBlock ID="INDBlock1" runat="server" />
 
 
 </asp:Content>
 
