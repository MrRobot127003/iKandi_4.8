<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PairingCosting.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.PairingCosting" Debug="true" %>
<style type="text/css">
    .Top-HeadCost
    {
        background: #39589c !important;
        border: 1px solid #b7b4b4;
        color: #fff !important;
        padding: 4px;
        font-size: 12px;
        margin: 0px;
        text-align: center;
        width: 97.9%;
        border-bottom: 0px;
        position: fixed;
        top: 0;
        font-weight: 500;
    }
    .item_list.HeadCost
    {
        margin-top: 24px;
        width: 100%;
    }
    .item_list.HeadCost td
    {
        border-color: #d2cdcd;
    }
    .item_list.HeadCost td:first-child
    {
        border-left-color: #999;
    }
    .item_list.HeadCost td:last-child
    {
        border-right-color: #999;
    }
    .item_list.HeadCost tr:last-child > td
    {
        border-bottom-color: #999;
    }
    .submit
    {
        font-size: 12px;
        height: 22px;
        cursor: pointer;
    }
    .submit:hover
    {
        font-size: 12px;
        height: 22px;
    }
    .close
    {
        top: -1px;
        position: relative;
    }
</style>
<h2 class="Top-HeadCost">
    Pair Costing
</h2>
<script type="text/javascript">
    function blockSpecialChar(e) {
        var k;
        document.all ? k = e.keyCode : k = e.which;
        return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
    }
   
</script>
<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function checktextbox() {
        // debugger;
        var AnswerInput = document.getElementsByClassName('txtvalblank');
        for (i = 0; i < AnswerInput.length; i++) {
            if (AnswerInput[i].value == "") {
                alert('fill the blank text feild.');
                return false;
            }
        }
    }
    //    function checktextbox() {
    //         var grid = document.getElementById("<%= GrdPairingCosting.ClientID%>");
    //         i = grid.rows.length;
    //             var txtAmountReceive = document.getElementById('PairingCosting1_GrdPairingCosting_ctl0' + i.toString() + '_txtPairingCosting');
    //             if (txtAmountReceive.value == '') {
    //                 alert("fill the text feild.");
    //                 document.getElementById('PairingCosting1_GrdPairingCosting_ctl0' + i.toString() + '_txtPairingCosting').focus();
    //                 return false;
    //             }
    //             else {
    //                 return true;
    //             }
    //    }

    function DeleteRow() {
        debugger

        if ($('#PairingCosting1_GrdPairingCosting_ctl02_txtPairingCosting').val() == "") {
            return false;
        }
        else {
            var result = confirm("Are you sure you want to delete?");
            if (result) return true;            
            else return false;
        }

    }


</script>
<asp:GridView ID="GrdPairingCosting" runat="server" ShowFooter="true" AutoGenerateColumns="false"
    ShowHeader="false" OnRowCommand="GrdPairingCosting_RowCommand" OnRowDeleting="GrdPairingCosting_RowDeleting"
    CssClass="item_list HeadCost">
    <Columns>
        <asp:TemplateField HeaderText="SNo">
            <ItemTemplate>
                <span style="color: Gray;">
                    <%#Container.DataItemIndex + 1%>
                </span>
            </ItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="ButtonAdd" runat="server" CommandName="addnew" class="buttonAdd"
                    OnClientClick="return checktextbox();"> <img src="../../images/add-butt.png" /></asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:TextBox ID="txtPairingCosting" runat="server" CssClass="txtvalblank" ForeColor="Black"
                    Style="text-transform: capitalize;" onkeypress="return blockSpecialChar(event)"
                    MaxLength="10" Text='<%# Eval("Id") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="delete">
            <ItemTemplate>
                <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete"
                 OnClientClick="return DeleteRow();">  <img src="../../images/del-butt.png" /> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<div style="width: 100%; text-align: center; margin-top: 20px;">
    <asp:Button ID="btnsubmit" CssClass="submit" Width="59px" Text="Submit" runat="server"
        OnClientClick="return checktextbox();" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
        Width="59px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
</div>
