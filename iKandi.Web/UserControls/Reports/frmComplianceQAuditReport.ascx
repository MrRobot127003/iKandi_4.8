<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmComplianceQAuditReport.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.frmComplianceQAuditReport" %>
<style type="text/css">
    body {
    font-size: 10px;
    font-family: arial;
    text-transform:capitalize !important;
 }
    .FirstChild
    {
        background:#DDDFE4;
        font-weight:normal;
    }
    table.inputfixed th.HeaderStyle1
    {
        background-color: #bfbdbd;
    }
    .footerback td:nth-child(2)
    {
        font-weight:bold;
    }
    table tr td,table tr th
    {
        border-color:Gray;
    }
    .GreenColor span
    {
        color:Green;
      }
    .RedColor span
    {
        color:red;
      }
    .BlackColor span
    {
        color:#000;
      }
       .headerColor
      {
          color:#6b6464 !important;
       }
</style>
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<script type="text/javascript">

    $(function () {
        //        function groupTable($rows, startIndex, total) {
        //            debugger;
        //            if (total === 0) {
        //                return;
        //            }
        //            var i, currentIndex = startIndex, count = 1, lst = [];
        //            var tds = $rows.find('td:eq(' + currentIndex + ')');
        //            var ctrl = $(tds[0]);
        //            lst.push($rows[0]);
        //            for (i = 1; i <= tds.length; i++) {
        //                if (ctrl.text() == $(tds[i]).text()) {
        //                    count++;
        //                    $(tds[i]).addClass('deleted');
        //                    lst.push($rows[i]);
        //                }
        //                else {
        //                    if (count > 1) {
        //                        ctrl.attr('rowspan', count);
        //                        groupTable($(lst), startIndex + 1, total - 1)
        //                    }
        //                    count = 1;
        //                    lst = [];
        //                    ctrl = $(tds[i]);
        //                    lst.push($rows[i]);
        //                }
        //            }
        //        }
        //        groupTable($('#frmComplianceQAuditReport1_grdComplianceQAuditReportC45 tr:has(td)'), 0, 1);
        //        $('#frmComplianceQAuditReport1_grdComplianceQAuditReportC45 .deleted').remove();

        //        groupTable($('#frmComplianceQAuditReport1_grdComplianceQAuditReportC47 tr:has(td)'), 0, 1);
        //        $('#frmComplianceQAuditReport1_grdComplianceQAuditReportC47 .deleted').remove();

       
    });  

</script>
<body>
    <asp:GridView ID="grdComplianceQAuditReportC47" runat="server" CssClass="inputfixed"
       AutoGenerateColumns="false" 
        OnRowDataBound="grdComplianceQAuditReportC47_RowDataBound" ondatabound="grdComplianceQAuditReportC47_DataBound" 
        >
    </asp:GridView>
    <br />
    <br />
   <%-- <asp:GridView ID="grdComplianceQAuditReportC45" runat="server" CssClass="inputfixed"
        AutoGenerateColumns="false" 
        OnRowDataBound="grdComplianceQAuditReportC45_RowDataBound" 
        >
    </asp:GridView>--%>
</body>
