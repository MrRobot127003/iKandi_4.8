<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master"
    CodeBehind="ExportToExcel.aspx.cs" Inherits="iKandi.Web.ExportToExcel" EnableEventValidation="false"  %>
 
<%@ Register src="../UserControls/Forms/ExportToExcel.ascx" tagname="ExportToExcel" tagprefix="uc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
     
    <uc1:ExportToExcel ID="ExportToExcel1" runat="server" />
     
</asp:Content>
