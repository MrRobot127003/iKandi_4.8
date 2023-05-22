<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispatchEntry.aspx.cs" Inherits="iKandi.Web.DispatchEntry"  MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="~/UserControls/Lists/DispatchEntryList.ascx" tagname="DispatchEntry" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >



    <uc1:DispatchEntry ID="DispatchEntry1" runat="server" />



</asp:Content>