<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IkandiOrderPrice.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.IkandiOrderPrice" %>
<script type="text/javascript">
    function UpdateIkandiPrice(checkbox) {
        debugger;
        var row = checkbox.parentNode.parentNode;
        var OrderId = row.cells[0].getElementsByTagName("input")[0].value;
        var AgreedPrice = row.cells[4].getElementsByTagName("span")[0].innerHTML;



        var url = "../../Webservices/iKandiService.asmx";
        $.ajax({
            type: "POST",
            url: url + "/UpdateIkandiPrice",
            data: "{ OrderId:'" + OrderId + "', AgreedPrice:'" + AgreedPrice + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall
        });


        function OnSuccess_Call(response) {
            alert("Save successfully.");
            document.getElementById(checkbox.id).checked = true;

        }
        function OnSuccessCall(response) {
            alert("Save successfully.");
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
            alert("Save successfully.");
            document.getElementById(checkbox.id).checked = true;

        }
        function OnErrorCall(response) {
            alert(response.status + " " + response.statusText);
        }
    }
</script>
<style>
    #dvBIPLOrderPrice th {
        font-size: 11px !important;
    }
    #dvBIPLOrderPrice tr:nth-last-child(1) {
        display: none;
    }
</style>
<div id="dvBIPLOrderPrice" style="width: 700px;">
    <table border="0" cellpadding="0" cellspacing="0" width="700px" align="center">
        <tr>
            <td align="center" style="height: 24px; background-color: #405D99; color: #FFFFFF; font-size: 13px; font-weight: 500; text-align: center; text-transform: uppercase; font-family: Lucida Sans Unicode;">
                Update Ikandi Order Price
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
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
                        <asp:TemplateField ItemStyle-Width="200px" HeaderText="OrderQty" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQty" runat="server" Font-Size="14px" Text='<%#Eval("OrderQty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="200px" HeaderText="Serial Number" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnOrderId" runat="server" Value='<%#Eval("OrderId") %>' />
                                <asp:Label ID="lblSerialNumber" runat="server" Font-Size="14px" Text='<%#Eval("SerialNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Order Ikandi Price">
                            <ItemTemplate>
                                <asp:Label ID="lblIkandiPrice" runat="server" Font-Size="14px" Text='<%#Eval("IkandiPrice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="250px" HeaderText="Costing Agreed Price">
                            <ItemTemplate>
                                <asp:Label ID="lblCostingAgreedPrice" runat="server" Font-Size="14px" Text='<%#Eval("AgreedPrice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Mode">
                            <ItemTemplate>
                                <asp:Label ID="lblMode" runat="server" Font-Size="14px" Text='<%#Eval("Mode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="New Agreed Price">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" onclick="UpdateIkandiPrice(this);" />
                            </ItemTemplate>
                            <ItemStyle CssClass="border_right_color" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <%--<asp:Button ID="btnSave" runat="server" CssClass="save do-not-print" OnClick="btnSave_Click" />--%>
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>
    </table>
</div>
