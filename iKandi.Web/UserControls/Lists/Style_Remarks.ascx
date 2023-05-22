<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Style_Remarks.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.Style_Remarks" %>
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';

    var proxy = new ServiceProxy(serviceUrl);

    function checkText() {
        debugger;
        var txt = $("#<%= txtComment.ClientID %>").val();
        var styleid = $("#<%= hdnStyleId.ClientID %>").val();
        if (txt != "") {
            proxy.invoke("UpdateStyleRemarks", { styleid: styleid, Remarks: $.trim(txt) }, function (result) {

                alert('Data has been saved successfully!');
                //window.location.reload();
                javascript:window.close('', '_parent', '');
                return true;
            }, onPageError, false, false);
        }
        else {
            alert("Comment box not blank!");
            return false;
        }
    }

</script>
<style type="text/css">
    #ctl01_lblCommentShow br
    {
        border: 1px solid lightgray;
        content: "";
        display: block;
    }
</style>
<div class="show_div_Remrks">
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnStyleId" runat="server" />
                            <asp:TextBox ID="txtComment" Width="135px" Height="66px" TextMode="MultiLine" Style="height: 48px;
                                width: 540px; text-align: left !important; margin: 0px;" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Button ID="btnSaveComment" runat="server" CssClass="submit" Text="Submit" OnClientClick="return checkText();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlRemarks" runat="server" Style="min-height: 200px; width: 541px; overflow-y: scroll;text-align:left;">
                    <h3 style="text-align: center; color: Blue;">
                        <u><span >Remarks</span> </u>
                    </h3>
                    <asp:Label runat="server" ID="lblCommentShow" Text="" Style="text-align: left"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>
