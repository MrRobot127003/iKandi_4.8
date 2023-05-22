<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FITsMainForm.ascx.cs" Inherits="iKandi.Web.FITsMainForm" %>
<script type="text/javascript">
    $(function () {
        $("input.style-code", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestFitsStyleCodeVersion", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });
    });
</script>
<style type="text/css">
.form_box {
    text-transform: Capitalize;
}
</style>
<div class="print-box">
  <div class="form_box">
    <div class="form_heading">
      <strong style="color:#39589c;">FITs FORM</strong>
    </div>
   
 
            <table border="0" align="center" cellpadding="0" cellspacing="0" width="1100px" style="padding:10px 0px">
              <tr>
                <td style="width: 102px">Search Style No.</td>
                <td align="left" style="width: 120px">
                  <asp:TextBox runat="server" ID="txtStyleNo" Style="width: 110px" CssClass="do-not-disable style-code" MaxLength="16"></asp:TextBox>
                  <asp:HiddenField runat="server" Value="-1" ID="hdnStyleID" />
                </td>
                <td style="width: 75px">
                  <asp:Button ID="btnGo" runat="server" class="go do-not-disable" OnClick="btnGo_Click" Text="Search" />
                </td>
                <td Style="width: 80px">Client</td>
                <td style="width: 100px">
                  <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable"  Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlClients_SelectedIndexChanged">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                  </asp:DropDownList>
                  <asp:HiddenField runat="server" ID="hiddenClientId" />
                </td>
                <td style="width:50px;"></td>
                <td style="width:100px;">Department</td>
                <td style="width: 120px">
                  <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="do-not-disable" Width="200px">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                  </asp:DropDownList>
                  <asp:HiddenField runat="server" ID="hiddenDeptId" Value="-1" />
                </td>
                <td>
                  <asp:Label ID="lblProceedAs" runat="server" Text="Proceed As" CssClass="dependent-fits-code" Visible="false"></asp:Label>
                </td>
                <td>
                  <asp:DropDownList ID="ddlStyleVersion" runat="server" CssClass="do-not-disable dependent-fits-code"
                    Width="98px" Visible="false">
                  </asp:DropDownList>
                  <asp:HiddenField runat="server" ID="hiddenStyleVersion" Value="-1" />
                </td>
                 <td style="width: 100px">
                  <asp:CheckBox ID="chkFitCycle" Text="Pre Order Fits"  runat="server" Visible="false" Checked="true" />
                </td>
                <td style="width: 80px">
                  <asp:Button ID="btnSearch" Style="display: block !important;" runat="server" class="summary do-not-disable da_submit_button" Text="Show Summary" OnClick="btnSearch_Click" />
                </td>
              </tr>
              <tr>
                <td colspan="11" align="right"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
              </tr>
            </table>
         
   
  </div>
</div>
