<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplingDispatch.aspx.cs" Inherits="iKandi.Web.SamplingDispatch" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>


<%@ Register src="../../UserControls/Reports/SamplingDispatch.ascx" tagname="SamplingDispatch" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    <uc1:SamplingDispatch ID="SamplingDispatch1" runat="server" />
    

</asp:Content>
