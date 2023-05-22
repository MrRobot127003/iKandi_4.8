<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="CMTAdmin.aspx.cs" Inherits="iKandi.Web.Admin.Costing.CMTAdmin" %>



<%@ Register Src="~/UserControls/Lists/GarmentTypeAdmin.ascx" TagName="GarmentTypeAdmin" TagPrefix="uc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

        <uc1:GarmentTypeAdmin ID="GarmentTypeAdmin1" runat="server" />

</asp:Content>
