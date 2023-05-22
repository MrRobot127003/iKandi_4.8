<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmOutHouse_AuditEntry_Report.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.frmOutHouse_AuditEntry_Report" %>
<style type="text/css">
    body
    {
        font-size: 10px;
        font-family: verdana;
        text-transform: capitalize !important;
    }
    .FirstChild
    {
        background: #DDDFE4;
        font-weight: normal;
    }
    table.inputfixed th.HeaderStyle1
    {
        background-color: #bfbdbd;
    }
    .footerback td:nth-child(2)
    {
        font-weight: bold;
    }
    table tr td, table tr th
    {
        border-color: Gray;
    }
</style>
<body>
    <asp:GridView ID="grdOutHouseAuditReport" runat="server" CssClass="inputfixed"
        AutoGenerateColumns="false" OnRowDataBound="grdOutHouseAuditReport_RowDataBound">
    </asp:GridView>

</body>
