<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipmentRegisterReport.aspx.cs"
 Inherits="iKandi.Web.ShipmentRegisterReport" MasterPageFile="~/layout/Secure.Master" %>
 
 <%@ Register src="../../UserControls/Reports/ShipmentRegister.ascx" tagname="ShipmentRegister" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
 

    <uc1:ShipmentRegister ID="ShipmentRegister1" runat="server" />

</asp:Content>
