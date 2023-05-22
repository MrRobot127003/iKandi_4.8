<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InlinePPMEdit.aspx.cs" MasterPageFile="~/layout/Secure.Master"  Inherits="iKandi.Web.InlinePPMEdit" %>

 <%@ Register src="../../UserControls/Forms/InlinePPMForm.ascx" tagname="InlinePPMForm" tagprefix="uc1" %>

 <asp:Content ContentPlaceHolderID=cph_main_content runat=server >
 
      
 
     <uc1:InlinePPMForm ID="InlinePPMForm1" runat="server" />
 
     
 
 </asp:Content>