<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCuttingSheetPrint.aspx.cs"
    Inherits="iKandi.Web.Internal.OrderProcessing.FrmCuttingSheetPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .disabled-input
        {
            pointer-events: none;
        }
       table th
        {
            font-size: 9px !important;
            padding: 0px !important;
           
        }
        .item_list1 TH
        {
              border-left-color:#999 !important;
               border-right-color:#999 !important;
             border-bottom-color:#999 !important
         } 
        .item_list1 TD
        {
            border: 1px solid #dcdbdb !important;
            font-size: 9px !important;
            font-family: arial !important;
        }
         .item_list1 TD:first-child
        {
           border-left-color:#999 !important
           
        }
         .item_list1 TD:last-child
        {
           border-right-color:#999 !important
           
        }
          .item_list1 tr:last-child>td
        {
           border-bottom-color:#999 !important
           
        }
        #etaheader th span
        {
            margin: 2px 2px;
        }
        #etaheader th
        {
            line-height: 15px;
        }
        .tdheight td
        {
            height: 15px;
            border-left: 0px !important;
            border-right: 0px solid !important;
            border-top: 0px solid !important;
            border-bottom: 1px solid #f1e6e6 !important;
            padding: 0px 0px;
            line-height: 13px;
            font-size: 9px !important;
            font-family: arial !important;
            text-align: left;
            padding-left: 5px;
            text-transform: capitalize;
        }
        .radiotext label
        {
            position: relative;
            top: -3px;
        }
        #grdProfitOnMode td
        {
            line-height: 15px;
        }
        .textgray
        {
            color: Gray !important;
            font-weight: 600;
        }
        .textblue
        {
            color: #0000EE;
        }
        .da_submit_button
        {
            border-radius:2px;
        }
        /*update css by bharat 15-jan-19*/
        input[type=text]
        {
            font-size: 10px !important;
        }
       #sb-player{
          min-height:200px !important;
          max-height:400px !important;
        }
        .submit
        {
            border-radius:2px;
            cursor:pointer;
         }
        .MyPanelBackground td 
{ Background-color: #a1eca7 !important;}
 .MySelectBackground td 
{ Background-color: #e8e8e8 !important;}

    </style>
    <script type="text/javascript">
        function closeProfitOnMo() {

            var win = window.open("../Fabric/CuttingSheet.aspx", '_blank');
            this.parent.Shadowbox.close();
            //                   win.focus();
                   return true;

                  
        }
        function closeButton() {
//            this.parent.window.close();
            this.parent.Shadowbox.close();
            //return false;
        }
//        $(function () {
//        debugger
//        $('#sb-player').css({ 'height': "1000px" });
//        });
//        function resizeframe(heights) {
//            alert('hi i called');
//            $("#sb-player").css( "height", 500+'px' );
//        }
        
    </script>
    <script type="text/javascript">
        function UpdateMDAPenalty(elem) {
//            debugger;
            var Ids = elem.id;
            var CId = Ids.substr(19);
            var SplitId = CId.split('_');
            BiplShare = $("#grdProfitOnMode input[id*='grdProfitOnMode_ctl" + SplitId[0] + "_txtBiplShare" + "']").val();
            weight = $("#grdProfitOnMode_ctl" + SplitId[0] + "_lblweight").html();

            AirMode = $("#HdnAirMode").val();
            shipMode = $("#hdnSeaMode").val();

            if (AirMode == "1") {
                TotalPenalty = ((weight / 1000) * 1.15 * 110) * (BiplShare / 100); //updated by bharat 15-jan-19
                $("#grdProfitOnMode_ctl" + SplitId[0] + "_lblPenalty").val(TotalPenalty.toFixed(0));

            }
            if (AirMode == "2") {
                TotalPenalty = ((weight / 1000) * 1.15 * 110) * (BiplShare / 100) * (-1); //updated by bharat 15-jan-19
                $("#grdProfitOnMode_ctl" + SplitId[0] + "_lblPenalty").val(TotalPenalty.toFixed(0));
            }

        }
    </script>
    <script type="text/javascript">

        $(function () {
            // debugger;
            $('#grdProfitOnMode td input[type="checkbox"]').addClass("chkProfit");

            //PageLoad check all checkbox checked or not

            if ($(".chkProfit").length == $(".chkProfit:checked").length) {

                $("#chkcheckallfinalized").attr("checked", "checked");
            } else {
                $("#chkcheckallfinalized").removeAttr("checked");
            }

            if ($(".chkProfit").length == $(".chkProfit:disabled").length) {

                $("#chkcheckallfinalized").attr('disabled', 'disabled');
            }


            //End of Code

            $("#chkcheckallfinalized").click(function () {
                // debugger;
                $('.chkProfit:enabled').attr('checked', this.checked);
            });

            // if all checkbox are selected, check the selectall checkbox
            // and viceversa
            $(".chkProfit").click(function () {
                if ($(".chkProfit").length == $(".chkProfit:checked").length) {

                    $("#chkcheckallfinalized").attr("checked", "checked");
                } else {
                    $("#chkcheckallfinalized").removeAttr("checked");
                }

            });
        });

        $(document).ready(function () {
            $('.rowspantd2').find("tr:eq(1)").remove();
            $("#grdProfitOnMode .item_list1").removeAttr("border");
        });

        function pageLoad() {
            //debugger;
            //            alert("ss");

            $('.rowspantd2').find("tr:eq(1)").text("Totals");
            $('.rowspantd2').find("tr:eq(1)").remove();
            $("#grdProfitOnMode .item_list1").removeAttr("border");

            $(function () {

                // debugger;
                $('#grdProfitOnMode td input[type="checkbox"]').addClass("chkProfit");
                //PageLoad check all checkbox checked or not
                if ($(".chkProfit").length == $(".chkProfit:checked").length) {
                    $("#chkcheckallfinalized").attr("checked", "checked");
                } else {
                    $("#chkcheckallfinalized").removeAttr("checked");
                }
                if ($(".chkProfit").length == $(".chkProfit:disabled").length) {

                    $("#chkcheckallfinalized").attr('disabled', 'disabled');
                }
                //End of Code

                $("#chkcheckallfinalized").click(function () {
                    // debugger;
                  
                    $('.chkProfit:enabled').attr('checked', this.checked);
                });

                // if all checkbox are selected, check the selectall checkbox
                // and viceversa
                $(".chkProfit").click(function () {
                    if ($(".chkProfit").length == $(".chkProfit:checked").length) {

                        $("#chkcheckallfinalized").attr("checked", "checked");
                    } else {
                        $("#chkcheckallfinalized").removeAttr("checked");
                    }

                });
            });
        }
        function OpenCuttingFormPrint() {
//            var win = window.open("../Fabric/CuttingSheet.aspx", '_blank');
            //            win.focus();
//            this.parent.Shadowbox.close();
//            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ss" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="pannel" runat="server">
        <ContentTemplate>
            <h2 style="width: 100%; margin: 0px auto 0px; font-weight: 500; height: 14px; background: #3b5998;
                color: White; text-align: center; padding: 5px 0px;">
                <asp:Label runat="server" ID="lblHeaderModeText" Style="font-size: 12px;">
    
                </asp:Label>
                <div style="float: right; font-size: 12px; padding-right: 5px;" class="radiotext">
                    <asp:RadioButton runat="server" ID="rdindi" Text="Individual Exfact" OnCheckedChanged="RadioButton_CheckedChanged"
                        AutoPostBack="true" Checked="true" GroupName="CostConfirmation" />
                    <asp:RadioButton ID="rdgroup" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"
                        GroupName="CostConfirmation" runat="server" Text="Group Exfact" /></div>
            </h2>
            <asp:HiddenField runat="server" ID="HdnAirMode" Value="0" />
            <%--<asp:HiddenField runat="server" ID="hdnSeaMode" />--%>
            <asp:GridView runat="server" ID="grdProfitOnMode" Width="100%" CssClass="item_list1"
                CellPadding="0" CellSpacing="0" AutoGenerateColumns="false" OnRowDataBound="grdProfitOnMode_RowDataBound"
                HeaderStyle-Height="15px" Style="margin: 0px auto; font-size: 10px !important;
                border-color: Gray;">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="" id="etaheader" frame="void"
                                rules="all">
                                <tr>
                                    <th style="border-bottom: 1px solid #c2b9b9 !important; text-align: left;padding-left: 4px !important;">
                                        <span>Fabric Quality</span><span>InHouse (%)</span><br />
                                        <span>Print/Color</span> <span>St. ETA </span><span>End ETA</span>
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle Width="350px" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnorderdetailid" runat="server" Value='<%# Eval("id")%>' />
                            <asp:GridView runat="server" ID="grdifabric" ShowHeader="false" CssClass="item_list1"
                                CellPadding="0" CellSpacing="0" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" width="100%" class="tdheight" border="0"
                                                frame="void" rules="all">
                                                <tr>
                                                    <td style="border-top: 1px solid  #dbd8d8 !important;border-bottom: 1px solid  #dbd8d8 !important; width: 252px" colspan="2">
                                                        <asp:Label runat="server" ID="lblfabric1" Style="text-transform: capitalize;" Font-Bold="true"
                                                            ForeColor="blue" Text='<%# Eval("Fabric")%>' Width="82%"></asp:Label>
                                                        <asp:Label runat="server" ID="lblinhouse" Width="14%" Text='<%# Eval("InHousePerce")%>'> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblfaric1Detail" Font-Bold="true" ForeColor="#000"
                                                            Text='<%# Eval("FabricDetails")%>' Width="60%"></asp:Label>
                                                        <asp:Label runat="server" Width="18%" ID="lblFabricEndETA" Text='<%# Eval("FabricENDETA")%>'> </asp:Label>
                                                        <asp:Label runat="server" Width="18%" ID="lblstartETA" Text='<%# Eval("FabricStartETA")%>'> </asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                        Serial No.
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        Style No.
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle Width="130px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <td style="border: 1px solid lightgray !important;">
                                        <asp:Label runat="server" ID="lblSerialNo" CssClass="bottommargin textblue" Text='<%# Eval("SerialNumber")%>'> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblStyleNo" CssClass="topmargin" Font-Bold="true" Text='<%# Eval("StyleNumber")%>'
                                            ForeColor="black"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                        Line No.
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        Contract No.
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle Width="110px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <td style="border: 1px solid lightgray !important;">
                                        <asp:Label runat="server" ID="lblLineNo" Text='<%# Eval("LineItemNumber")%>' ForeColor="black"> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblContractNo" Text='<%# Eval("ContractNumber")%>'
                                            ForeColor="black"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                        ExFactory
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        DC
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle Width="150px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <td style="border: 1px solid lightgray !important;">
                                        <asp:Label runat="server" ID="lblExFactory" Font-Bold="true" Text='<%# Eval("ExFactory", "{0:dd MMM yy (ddd)}")%>'> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblDC" Text='<%# Eval("DC", "{0:dd MMM (ddd)}")%>'
                                            ForeColor="black"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                        Department
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle Width="120px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <td style="border: 1px solid lightgray !important;">
                                        <asp:Label runat="server" ID="lblDept" Text='<%# Eval("DepartmentName")%>'> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                        Mode
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle Width="120px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblMode" Text='<%# Eval("Code")%>' ForeColor="black"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Qty.
                        </HeaderTemplate>
                        <HeaderStyle Width="60px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblQty" ForeColor="#0000ee" Font-Bold="true" Text='<%# Eval("Quantity")%>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <th style="border-bottom: 1px solid #c2b9b9 !important;">
                                        Bipl Penalty<%-- <font style="font-size: 10px; font-weight: bold;" color="black">(&#8377;)--%>
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        Weight (gms)
                                    </th>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle Width="125px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="1" frame="void" rules="all">
                                <tr>
                                    <td style="border: 1px solid lightgray !important;">
                                        <asp:TextBox runat="server" ID="lblPenalty" Text='<%# Eval("Penalty")%>' Width="90%"
                                            CssClass="disabled-input"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblweight" Text='<%# Eval("Weight")%>'> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            Penalty
                        </HeaderTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPenaltyQty" Font-Bold="true" Text='<%# Eval("Quantity")%>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Select &nbsp;
                            <input type="checkbox" id="chkcheckallfinalized" onclick="CheckBox1_Click" />
                        </HeaderTemplate>
                        <HeaderStyle Width="60px" />
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkFinalised"  AutoPostBack="True" OnCheckedChanged="CheckBox1_Click" />
                            <asp:HiddenField runat="server" ID="hdnFinalised" Value='<%# Eval("FinalisedPenalty")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            Bipl Share %
                        </HeaderTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtBiplShare" Text='<%# Eval("SharePercent")%>' Style="width: 90%;"
                                onblur="javascript:return UpdateMDAPenalty(this);"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="Id" Value='<%# Eval("id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            Color/Print
                        </HeaderTemplate>
                        <HeaderStyle Width="125px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFabricDetails" Text='<%# Eval("Fabric1Details")%>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="width: 99.5%; margin: 10px auto;">
                <asp:Button ID="btnSubmit" runat="server" Text="Cutting Sheet" CssClass="submit"
                    OnClick="btnsubmit_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="da_submit_button"
                    OnClientClick="JavaScript:closeButton();" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
