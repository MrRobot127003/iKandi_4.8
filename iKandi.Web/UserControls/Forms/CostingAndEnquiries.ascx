
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CostingAndEnquiries.ascx.cs"
    Inherits="iKandi.Web.CostingAndEnquiries" %>
    <style type="text/css">
        .GrdColor th
        {
        	background-color:#0066FF;
            color:White;
            font-family:Arial;
            font-size:12px;
            padding:5px 0px;
            font-weight:bold;
        	} 
       .UPC
       {
       	text-transform:uppercase;
       	font-size:12px;
       	} 	
       	.cen
       	{
       	text-align:center;
    </style>
<script type="text/javascript">
    $(function () {
        //debugger;
        $("input[type=text].costing-style").autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });

        $("input[type=text].costing-style", "#main_content").result(function () {

            var p = $(this).val().split('-');
            $(this).val(p[0]);

        });

    });

    function launchCosting(srcElem) {
        //debugger;
        var txtStyleNumber = $('input[type=text].costing-style');

        if (txtStyleNumber.val().length < 8) {
            return;
        }

        var sn = $.trim(txtStyleNumber.val());

        // if (sn.split(' ').length == 3)
        //     sn = $.trim(sn.substring(0, sn.lastIndexOf(' ')));

        $(srcElem).attr("href", "/Internal/Sales/CostingSheet.aspx?sn=" + sn);
    }
    function onPageError(error) {
        alert(error.Message + ' -- ' + error.detail);
    }

</script>

<div class="booking_calculator">
   
    <div class="booking_calculator">
        <table width="100%" style="border-collapse: collapse" cellspacing="0">
            <tr>
                <td class="form_small_heading_Blue" style="width: 10%; font-size: 12px; text-transform:none;text-align:center;">
                    Style No. 
                </td>
                <td class="blue_center_text" style="width: 50%">
                    <asp:TextBox runat="server" ID="txtStyleNumberSearch" CssClass="costing-style required do-not-disable"
                        title="Please enter Style Number" Style="width: 80%"></asp:TextBox>
                </td>
                <td width="25%">
                    <div>
                        <div style="float: left; padding: 2px">
                            <a style="" target="_blank" class="validate-form do-not-disable costing-style-go"
                                onclick="launchCosting( this)">
                                <div class="go_small">
                                Search
                                </div>
                            </a>
                        </div>
                        <div style="float: left; padding: 2px">
                            <asp:Button ID="btnEnquiry" runat="server" OnClick="btnEnquiry_Click" Visible="false"
                                CssClass="enquiry_small" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="Div1" class="booking_calculator" runat="server">
        <table width="100%" style="border-collapse: collapse" cellspacing="0">
            <tr>
                <td class="blue_center_text">
                    <asp:Label ForeColor="Red" ID="lblerror" Text="This Style has been Costed!!" runat="server"
                        Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="booking_calculator">
        <div style="min-height: 160px; overflow: auto; border:1px solid #f1f1f1">
            <asp:GridView ID="grdEnquiry" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="grdEnquiry_RowDataBound" HeaderStyle-CssClass="GrdColor">
                <Columns>
                    <asp:TemplateField HeaderText="Buyer" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White" SortExpression="">
                        <ItemTemplate>
                         <asp:Label ID="lblClient" Font-Size="12px" Font-Names="arial" CssClass="buyer" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                           <asp:Label ID="Label36" runat="server" Font-Size="12px" Font-Names="arial" Text='<%# Eval("DepartmentName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                
                    <asp:TemplateField HeaderText="Style No." HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White" SortExpression="">
                        <ItemTemplate>
                            <a style="font-size:12px; font-family:Arial;" target="_blank" href="/Internal/Sales/CostingSheet.aspx?sn=<%# Eval("StyleNumber") %>">
                                <%# Eval("StyleNumber") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" Font-Size="12px" ForeColor="#000000" Font-Names="Arial" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <label>No records Found</label></EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <br />
</div>
