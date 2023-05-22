<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Popups.Master"
    CodeBehind="SendShipmentEmail.aspx.cs" Inherits="iKandi.Web.SendShipmentEmail" %>

<asp:Content runat="server" ContentPlaceHolderID="cph_main_content">
<script type="text/javascript">
    function windowClose(retVal) {
       
        window.returnValue = retVal;
        window.close();
        return false;
    }
</script>
    <div class="form_box">
        <asp:Panel runat="server" ID="pnlForm">
            <div class="print-box">
                <div class="form_heading">
                    <asp:Label runat="server" ID="lblHeading"></asp:Label>
                </div>
                <div>
                    <table cellspacing="15" width="100%">
                        <tr>
                            <td width="20%">
                                System Users:
                            </td>
                            <td width="30%">
                                <asp:ListBox SelectionMode="Multiple" ID="ddlUsers" runat="server"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%">
                                Additional Emails (seperated by comma):
                            </td>
                            <td width="30%">
                                <asp:TextBox ID="txtAdditionalEmails" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%">
                                Additional Comments/Remarks/Instructions:
                            </td>
                            <td width="30%">
                                <asp:TextBox TextMode="MultiLine" ID="txtRemarks" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <asp:Button runat="server" ID="btnSubmit" CssClass="submit" OnClick="btnSubmit_Click" />
         
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlMessage" Visible="false">
            <div class="text-content" style="text-align: center">
                Email has been sent successfully.
                <br />
                <br />
                <input type="button" id="btnClose" class="close" onclick="windowClose(true)" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
