<%@ Page Title="" Language="C#" MasterPageFile="~/layout/SimpleSecure.Master" AutoEventWireup="true" CodeBehind="TabCostingSheetNew.aspx.cs" Inherits="iKandi.Web.Internal.Sales.TabCostingSheetNew"  EnableEventValidation="false"%>
<%@ Register Src="../../UserControls/Forms/CostingFormNew.ascx" TagName="CostingFormNew"
    TagPrefix="uc1" %>
<asp:Content ID="cph" runat="server" ContentPlaceHolderID="cph_main_content">
<script type="text/javascript">
    $(function () {
        $('.costing_form').show();
        $('.style-table').hide();
    });
</script>
    <uc1:CostingFormNew ID="CostingFormNew1" runat="server" />
</asp:Content>
