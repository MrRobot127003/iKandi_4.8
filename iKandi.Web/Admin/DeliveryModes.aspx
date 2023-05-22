<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryModes.aspx.cs" Inherits="iKandi.Web.DeliveryModes" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Forms/DeliveryModesForm.ascx" TagName="DeliveryModesForm"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
 <uc1:DeliveryModesForm ID="mb" runat="server" />
</asp:Content>
