<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuttingSheet.aspx.cs" Inherits="iKandi.Web.CuttingSheet" MasterPageFile="~/layout/Secure.Master"%>

<%--<%@ Register src="../../UserControls/Forms/CuttingForm.ascx" tagname="CuttingForm" tagprefix="uc1" %>--%>

<%@ Register src="../../UserControls/Forms/CuttingFormNew.ascx" tagname="CuttingForm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
 
      
 
    <uc1:CuttingForm ID="CuttingForm1" runat="server" />
 
      
 
 </asp:Content>
