<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateHalfStitch.aspx.cs"
    Inherits="iKandi.Web.Admin.UpdateHalfStitch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<script type="text/javascript">
    function CallConfirmBox() {
      if (confirm("Confirm Proceed Further?")) {
        alert("You pressed OK!");
        document.getElementById("hdnConfirmation").value = "Yes";
      } else {
        alert("You pressed Cancel!");
        document.getElementById("hdnConfirmation").value = "No";
      }
    }
  </script>--%>
  <script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript">
        function SpinnShow() {
            var operation = $(".cssabc").val();
            if (operation == "") {
                alert('Please enter half stich nick name');
                return false;
            }
            else {
                $("#spinn1").css("display", "block");
                return true;

            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 66px;
        }
        .padding
        {
            padding-left: 5px;
            text-align: left;
        }
        #spinn1
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        .RowMerge
        {
            font-weight: bold;
            font-size:12px;
            padding-left: 10px;
            text-align:left;
        }
    </style>
</head>
<body bgcolor="#FFFFFF">
    <form id="form1" runat="server">
    <div id="spinn1" runat="server">
    </div>
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="98%" align="center">
            <tr>
                <td style="padding-top: 10px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td colspan="2" align="center" style="height: 25px; width: 55%; background-color: #405D99;
                                color: #FFFFFF; font-size: 12px; font-weight: bold; text-align: right; 
                                font-family:Verdana;">
                                Stitching/Manpower
                            </td>
                            <td align="right" style="height: 25px; background-color: #405D99; color: #FFFFFF;
                                font-size: 14px; font-weight: bold; text-align: right; text-transform: uppercase;
                                font-family:Verdana;">
                                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" style="padding-top: 5px; text-transform: none; font-family:Verdana;">                             
                                <asp:GridView ID="gvStitchingManpowerDetail" runat="server" AutoGenerateColumns="false"
                                    Width="100%" ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="10px"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF"
                                    HeaderStyle-BackColor="#405D99" RowStyle-Height="20px" RowStyle-HorizontalAlign="Center"
                                    RowStyle-ForeColor="#7E7E7E" FooterStyle-ForeColor="#7E7E7E" ShowFooter="false"
                                    FooterStyle-HorizontalAlign="Center" OnRowDataBound="gvStitchingManpowerDetail_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="8%" HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrNo" runat="server" Font-Size="11px" Text='<%#Eval("SrNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="48%" HeaderText="Stitching/Manpower">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnCompletelyCheckedStitched" runat="server" Value='<%#Eval("IsCompletelyCheckedStitched") %>' />
                                                <asp:HiddenField ID="hdnFactoryWorkForce" runat="server" Value='<%#Eval("FactoryWorkSpace") %>' />
                                                <asp:HiddenField ID="hdnWorkerType" runat="server" Value='<%#Eval("WorkerType") %>' />
                                                <asp:HiddenField ID="hdnOperationID" runat="server" Value='<%#Eval("OperationId") %>' />
                                                <asp:HiddenField ID="hdnOperationType" runat="server" Value='<%#Eval("OperationType") %>' />
                                                <asp:Label ID="lblStitchingManpower" runat="server" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="padding" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="14%" HeaderText="Machine SAM (Minute)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMachineSAM" runat="server" Font-Size="11px" Text='<%#Eval("StitchSam") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Machine Cost (₹)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMachineCost" runat="server" Font-Size="11px" Text='<%#Eval("MachineCalc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="8%" HeaderText="Nos.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNos" runat="server" Font-Size="11px" Text='<%#Eval("FinalOB") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="12%" HeaderText="Checked Operations">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkCheckedStitched" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 3px;">
                            </td>
                        </tr>
                        <tr>
                            <td id="tdFinish1" runat="server" colspan="2" align="center" style="height: 25px; display:none;
                                width: 55%; background-color: #405D99; color: #FFFFFF; font-size: 12px; font-weight: bold;
                                text-align: right; font-family:Verdana;">
                                Finishing/Manpower
                            </td>
                            <td id="tdFinish2" runat="server" align="right" style="height: 25px; background-color: #405D99; display:none;
                                color: #FFFFFF; font-size: 14px; font-weight: bold; text-align: right; text-transform: uppercase;
                                font-family:Verdana;">
                                <asp:Button ID="Button1" runat="server" CssClass="close da_submit_button" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" style="padding-top: 5px; text-transform: none; display:none; font-family:Verdana;">
                                <asp:GridView ID="gvFinishingManpowerDetail" runat="server" AutoGenerateColumns="false"
                                    Width="100%" HeaderStyle-Height="35px" HeaderStyle-Font-Size="10px" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                                    RowStyle-Height="20px" RowStyle-HorizontalAlign="Center" RowStyle-ForeColor="#7E7E7E"
                                    FooterStyle-ForeColor="#7E7E7E" ShowFooter="false" FooterStyle-HorizontalAlign="Center"
                                    CellPadding="0" ShowHeader="false" OnRowDataBound="gvFinishingManpowerDetail_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="8%" HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrNo" runat="server" Font-Size="11px" Text='<%#Eval("SrNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="48%" HeaderText="Stitching/Manpower">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnCompletelyCheckedFinished" runat="server" Value='<%#Eval("IsCompletelyCheckedFinished") %>' />
                                                <asp:HiddenField ID="hdnFactoryWorkForce" runat="server" Value='<%#Eval("FactoryWorkSpace") %>' />
                                                <asp:HiddenField ID="hdnWorkerType" runat="server" Value='<%#Eval("WorkerType") %>' />
                                                <asp:HiddenField ID="hdnOperationID" runat="server" Value='<%#Eval("OperationId") %>' />
                                                <asp:Label ID="lblFinishingManpower" runat="server" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="padding" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="14%" HeaderText="Machine SAM (Minute)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMachineSAM" runat="server" Font-Size="11px" Text='<%#Eval("FinishSam") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Machine Cost (₹)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMachineCost" runat="server" Font-Size="11px" Text='<%#Eval("MachineCalc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="8%" HeaderText="Nos.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNos" runat="server" Font-Size="11px" Text='<%#Eval("FinalOB") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="12%" HeaderText="Checked Finished">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkCheckedFinished" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" style="padding-top: 10px; padding-bottom: 10px;">
                                <asp:Label ID="lblMessage" runat="server" Visible="false" Text="There are no Sam available for now. So you cannot do HalfStich for this style. Thanks."
                                    Font-Size="18px" ForeColor="#7E7E7E" Font-Names="Arial"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="txtHSNickName" runat="server" Text="HS Nick Name" Style="font-size: 11px;
                                    font-family:Verdana; color: gray;"></asp:Label>&nbsp;
                                <asp:TextBox ID="txtOperationName" CssClass="cssabc" runat="server" Text="" MaxLength="6" Style="width: 55px"></asp:TextBox>
                                &nbsp;&nbsp;<asp:CheckBox ID="chkFinishing" Text="Finishing" runat="server" />
                            </td>
                            <td colspan="3" align="right" style="padding-top: 10px; padding-bottom: 10px;">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit" OnClientClick="javascript:return SpinnShow();"
                                    OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        $(window).load(function () { $("#spinn1").fadeOut("slow"); }); //Gajendra     
    </script>
</body>
</html>
