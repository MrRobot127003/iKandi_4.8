<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FITsEdit.aspx.cs" Inherits="iKandi.Web.FITsEdit" MasterPageFile="~/layout/Secure.Master" MaintainScrollPositionOnPostback="true" EnableEventValidation="false"%>

<%@ Register src="../../UserControls/Forms/FITsMainForm.ascx" tagname="FITsMainForm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID=cph_main_content runat=server >
   
   <uc1:FITsMainForm ID="FITsMainForm1" runat="server" />
      
 </asp:Content>
