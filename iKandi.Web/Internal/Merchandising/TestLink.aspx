<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="TestLink.aspx.cs" Inherits="iKandi.Web.Internal.Sales.TestLink" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<a href="../Sales/CostingSheetNew.aspx?sn=DR 17132596 a"> CST</a><br />
<a href="../Sales/CostingSheetNew.aspx?sn=DR 61935 a&IsUcknowledge=1"> CST</a> <br />
<a href="../Sales/CostingSheetNew.aspx?sn=DR 84978 b&IsUcknowledge=1"> CST</a> <br />
<a href="../Sales/CostingSheetNew.aspx?sn=SH 62015 fc&IsUcknowledge=1"> CST</a><br />
<a href="../Sales/CostingSheetNew.aspx?sn=SH 62015 fc&IsUcknowledge=1"> CST</a><br />

<script type="text/jscript">
    $(document).ready(function () {

        $("p").click(function () {
            var cellIndex = $("#txtindex").val()
            var color11 = $("#txtcolor").val()
            var rowcell = cellIndex.split(":");
            var rowIndex = rowcell[0];
            var columnIndex = rowcell[1];
            $('#table123 tr').eq(rowIndex).find('td').eq(columnIndex).css("background-color", color11);          
        });
    });


</script>
<table id="table123">
<tr>
<td> A </td>
<td> B </td>
<td> C </td>
<td> D </td>
<td> E </td>
<td> F </td>
</tr>
<tr>
<td> G </td>
<td> H </td>
<td> I </td>
<td> J </td>
<td> K </td>
<td> L </td>
</tr>


</table>
<div>
    <input id="txtindex" type="text" />&nbsp;&nbsp;&nbsp;&nbsp; <input id="txtcolor" type="text" />&nbsp;&nbsp;&nbsp;&nbsp; <p>Test</p>
</div>

</asp:Content>
