<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmProductionMatrix.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.frmProductionMatrix" %>
<style type="text/css">
.fitsstatus span
{
    font-size:7px !important;
}
</style>
<asp:GridView ID="grdProductionMatrix" runat="server" AutoGenerateColumns="false"
 ShowHeader="true" ShowFooter="false"
 onrowdatabound="grdProductionMatrix_RowDataBound" CssClass="item_list" style="width: auto !important;"></asp:GridView>