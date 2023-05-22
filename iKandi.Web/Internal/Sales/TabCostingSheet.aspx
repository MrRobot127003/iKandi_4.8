<%@ Page Language="C#" MasterPageFile="~/layout/SimpleSecure.Master" AutoEventWireup="true"
    CodeBehind="TabCostingSheet.aspx.cs" Inherits="iKandi.Web.TabCostingSheet" EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/Forms/CostingForm.ascx" TagName="CostingForm"
    TagPrefix="uc1" %>
<asp:Content ID="cph" runat="server" ContentPlaceHolderID="cph_main_content">
<script type="text/javascript">
$(function()
{
    $('.costing_form').show();
    $('.style-table').hide();
});
</script>
    <uc1:CostingForm ID="CostingForm1" runat="server" />
</asp:Content>
