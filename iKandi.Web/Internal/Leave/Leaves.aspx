<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leaves.aspx.cs" Inherits="iKandi.Web.Leaves"  MasterPageFile="~/layout/Secure.Master"%>



<%@ Register src="../../UserControls/Lists/SearchLeaves.ascx" tagname="SearchLeaves" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

     

    <uc1:SearchLeaves ID="SearchLeaves1" runat="server" />

     

</asp:Content>
