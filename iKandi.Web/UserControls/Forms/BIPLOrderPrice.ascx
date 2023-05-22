<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BIPLOrderPrice.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.BIPLOrderPrice" %>
<script type="text/javascript">

    function abc() {
        var rowCount = $("[id*=gvBIPLOrderPrice] td").closest("tr").length;
        var gvid = "";
        for (var i = 1; i <= rowCount; i++) {       
            if (i < 10) {
                gvid = "_ctl0";
            }
            else {
                var gvid = "_ctl";
            }
            if ($("#ctl01_gvBIPLOrderPrice_ctl01_ChkSelectAll").is(':checked')) {
                $("#<%=gvBIPLOrderPrice.ClientID %>" + gvid + i + "_chkSelect").attr("checked", true);            
                $("#<%=gvBIPLOrderPrice.ClientID %>" + gvid + i + "_chkSelect").click();      
            }
            else if (!$("#ctl01_gvBIPLOrderPrice_ctl01_ChkSelectAll").is(':checked')) {     
                $("#<%=gvBIPLOrderPrice.ClientID %>" + gvid + i + "_chkSelect").attr("checked", false);
                var il = 1;
            }
        }
        if (il != 1) {
            alert("Saved Successfully");
        }
    }

    function UpdateBIPLPrice(checkbox) {
        var row = checkbox.parentNode.parentNode;
        var OrderId = row.cells[0].getElementsByTagName("input")[0].value;
        var AgreedPrice = row.cells[4].getElementsByTagName("span")[0].innerHTML;


        var url = "../../Webservices/iKandiService.asmx";
        $.ajax({
            type: "POST",
            url: url + "/UpdateBIPLPrice",
            data: "{ OrderId:'" + OrderId + "', AgreedPrice:'" + AgreedPrice + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall
        });


        function OnSuccess_Call(response) {
            if (!$("#ctl01_gvBIPLOrderPrice_ctl01_ChkSelectAll").is(':checked')) {
                alert("Save sucessfully.");
            }
            document.getElementById(checkbox.id).checked = true;

        }
        function OnSuccessCall(response) {
            //  alert("Save sucessfully.");
            document.getElementById(checkbox.id).checked = true;
            row.cells[3].getElementsByTagName("span")[0].innerHTML = AgreedPrice;
        }

        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }
    function UpdateFabric_Color(checkbox) {
        var row = checkbox.parentNode.parentNode;
        var OrderId = row.cells[0].getElementsByTagName("input")[0].value;



        var url = "../../Webservices/iKandiService.asmx";
        $.ajax({
            type: "POST",
            url: url + "/UpdateFabric_Color_Print",
            data: "{ OrderId:'" + OrderId + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_Call,
            error: OnErrorCall
        });


        function OnSuccess_Call(response) {
            alert("Save sucessfully.");
            document.getElementById(checkbox.id).checked = true;

        }
        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }
</script>
<style type="text/css">
    #dvBIPLOrderPrice tr:nth-last-child(1) {
        display: none;
    }
    #dvBIPLOrderPrice th {
        font-size: 11px !important;
    }
</style>
<div id="dvBIPLOrderPrice" style="width: 700px;">
    <table border="0" cellpadding="0" cellspacing="0" width="700px" align="center">
        <tr>
            <td align="center" style="height: 25px !important; background-color: #405D99; color: #FFFFFF; font-size: 13px; font-weight: 500; text-align: center; text-transform: uppercase; font-family: Lucida Sans Unicode;">
                Update BIPL Order Price
            </td>
        </tr>
        <tr>
            <td style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvBIPLOrderPrice" runat="server" AutoGenerateColumns="false" Width="90%" ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="14px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#405D99" HeaderStyle-BackColor="#F0F3F2" RowStyle-Height="35px" RowStyle-HorizontalAlign="Center" RowStyle-ForeColor="#7E7E7E" FooterStyle-ForeColor="#7E7E7E" ShowFooter="true" FooterStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="200px" HeaderText="Contract No. (Line/Item No.)" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnOrderDetailID" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                <asp:Label ID="lblContractNumber" runat="server" Font-Size="14px" Text='<%#Eval("ContractNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="border_left_color" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="200px" HeaderText="Order Qty." HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQty" runat="server" Font-Size="14px" Text='<%#Eval("OrderQty","{0:#,0}")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="200px" HeaderText="Serial Number" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnOrderId" runat="server" Value='<%#Eval("OrderId") %>' />
                                <asp:Label ID="lblSerialNumber" runat="server" Font-Size="14px" Text='<%#Eval("SerialNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="BIPLPrice">
                            <ItemTemplate>
                                <asp:Label ID="lblBIPLPrice" runat="server" Font-Size="14px" Text='<%#Eval("BIPLPrice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="250px" HeaderText="Costing Agreed Price">
                            <ItemTemplate>
                                <asp:Label ID="lblCostingAgreedPrice" runat="server" Font-Size="14px" Text='<%#Eval("AgreedPrice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="New Agreed Price">
                            <HeaderTemplate>
                                <asp:CheckBox ID="ChkSelectAll" runat="server" Text="Select All" onclick="abc();" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" onclick="UpdateBIPLPrice(this);" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>
    </table>
</div>
