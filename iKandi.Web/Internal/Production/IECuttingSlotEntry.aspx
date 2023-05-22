<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="IECuttingSlotEntry.aspx.cs" Inherits="iKandi.Web.Internal.Production.IECuttingSlotEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        table th
        {
            padding: 5px 0px;
            font-size: 11px;
            font-family: arial;
            background: #3a5695;
            color: #fff;
            text-transform: capitalize;
            font-weight: normal !important;
            border-color: #ffffff;
        }
        table.products td.price
        {
            text-align: right;
        }
        table
        {
            border-collapse: collapse;
            text-align: center;
            border-spacing: 0;
        }
        
        iframe
        {
            background: #fff !important;
            padding: 5px;
        }
        .secure_center_contentWrapper
        {
            font-family: Helvetica !important;
        }
        .item_list th
        {
            font-family: Helvetica !important;
        }
        .submit-hide
        {
            display: none;
        }
        .headerbackcolr
        {
           background-color:#3a5695;
           padding: 4px;
           color: #ffff !important;
           height: 19px;
           font-weight:bold !important;
        }
         input::-webkit-input-placeholder { /* WebKit browsers */
        color:    #ccc8c8;!important;
         font-size: 10px;
    }
    </style>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input').keypress(function (e) {
                //debugger;
                if (this.value.length == 0 && e.which == 48) {
                    return false;
                }
            });
            if (window.history.replaceState) {
                window.history.replaceState(null, null, window.location.href);
            }
        });
    </script>
    <script language="javascript" type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);


        function CalculateCutEntry(elem) {
            debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);
            var OrderDetailId = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderDetailId" + "']").val();
            var OrderQuantity = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderQuantity" + "']").val();
            var OrderBalance = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderBalance" + "']").val();

            var EntryCutQty = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val();
            var QntyTocut = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnQntyTocut" + "']").val();
            var CutQty = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnCutQty" + "']").val();
            var OrderTotalCutQty = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnOrderTotalCut" + "']").val();
            var BalanceRdyQty = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnQntyToCutReady" + "']").val();

            //-----------------prabhaker shukla changes 25 apr 17----------------//
            var CutReady = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutReady" + "']").val();
            if (EntryCutQty <= CutReady || CutReady <= EntryCutQty) {
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutReady" + "']").attr('value', '');
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtOrderBalance" + "']").val(OrderBalance);
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutQty" + "']").val(QntyTocut);
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutQty" + "']").val(CutQty);
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(BalanceRdyQty);
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnTotaltoCutReady" + "']").val(BalanceRdyQty);

            }
            //----------------- End prabhaker shukla changes 25 apr 17----------------//          
            var Type = 'CUTTING';
            if (EntryCutQty != '') {

                proxy.invoke("Check_CuttingAndIssued_Data", { OrderDetailId: OrderDetailId, Type: Type, PcsCut: EntryCutQty },
            function (result) {
                debugger;
                var InlineCutMsg = result;
                if (CutQty == '')
                    CutQty = 0;

                if ((InlineCutMsg == '') && (parseInt(OrderTotalCutQty) >= 0)) {

                    if (OrderBalance == '')
                        OrderBalance = 0;
                    if (QntyTocut == '')
                        QntyTocut = 0;
                    if (BalanceRdyQty == '')
                        BalanceRdyQty = 0;
                    debugger;
                    if (EntryCutQty != '') {
                        var OrderBalanceQty = (parseInt(OrderBalance) - parseInt(EntryCutQty));
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtOrderBalance" + "']").val(OrderBalanceQty);

                        var TotalToCut = (parseInt(QntyTocut) - parseInt(EntryCutQty));
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutQty" + "']").val(TotalToCut);

                        CutQty = (parseInt(CutQty) + parseInt(EntryCutQty));
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutQty" + "']").val(CutQty);

                        BalanceRdyQty = (parseInt(BalanceRdyQty) + parseInt(EntryCutQty));
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(BalanceRdyQty);
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnTotaltoCutReady" + "']").val(BalanceRdyQty);
                    }
                    else {
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtOrderBalance" + "']").val(OrderBalance);
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutQty" + "']").val(QntyTocut);
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutQty" + "']").val(CutQty);
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(BalanceRdyQty);
                        // $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnTotaltoCutReady" + "']").val(BalanceRdyQty);
                    }

                }
                else {
                    debugger;
                    //var CutMsg = result.substring(0, result.length - 1));
                    if (parseInt(EntryCutQty) < 20) {
                        if ((parseInt(OrderQuantity) - parseInt(OrderBalance)) + parseInt(EntryCutQty) < 20) {
                            if (OrderBalance == '')
                                OrderBalance = 0;
                            if (QntyTocut == '')
                                QntyTocut = 0;
                            if (CutQty == '')
                                CutQty = 0;
                            if (BalanceRdyQty == '')
                                BalanceRdyQty = 0;

                            if (EntryCutQty != '') {
                                var OrderBalanceQty = (parseInt(OrderBalance) - parseInt(EntryCutQty));
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtOrderBalance" + "']").val(OrderBalanceQty);

                                var TotalToCut = (parseInt(QntyTocut) - parseInt(EntryCutQty));
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutQty" + "']").val(TotalToCut);

                                CutQty = (parseInt(CutQty) + parseInt(EntryCutQty));
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutQty" + "']").val(CutQty);

                                BalanceRdyQty = (parseInt(BalanceRdyQty) + parseInt(EntryCutQty));
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(BalanceRdyQty);
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnTotaltoCutReady" + "']").val(BalanceRdyQty);
                            }
                            else {
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtOrderBalance" + "']").val(OrderBalance);
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutQty" + "']").val(QntyTocut);
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutQty" + "']").val(CutQty);
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(BalanceRdyQty);
                                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnTotaltoCutReady" + "']").val(BalanceRdyQty);
                            }
                        }
                        else {
                            var CutMsg = "" + result;
                            alert(CutMsg);
                            $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val('');
                            return false;
                        }
                    }
                    else {
                        var CutMsg = "" + result;
                        alert(CutMsg);
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val('');
                        return false;
                    }
                }
            });

            }

        }


        function CalculateCutReadyEntry(elem) {
            //debugger;
            var Ids = elem.id;
            var cId = Ids.split("_")[5].substr(3);

            var CutReady = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutReady" + "']").val();
            var hdnbalance = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnTotaltoCutReady" + "']").val();
            var EntryCutQty = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtSlotPass" + "']").val();
            if (EntryCutQty != '' && CutReady == '') {
                // var TotalToCutReadyNew = (parseInt(EntryCutQty) + parseInt(hdnbalance));
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(hdnbalance);
            }

            if (CutReady != '') {
                var QntyToCutReady = $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_hdnTotaltoCutReady" + "']").val();
                if (QntyToCutReady == '')
                    QntyToCutReady = 0;

                if (CutReady != '') {
                    if (parseInt(CutReady) > parseInt(QntyToCutReady)) {
                        alert('Cut Rdy Qnty can not be greater than Total To Cut Rdy');
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtCutReady" + "']").val('');
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(hdnbalance);
                        return false;

                    }
                    else {

                        var TotalToCutReady = (parseInt(QntyToCutReady) - parseInt(CutReady));
                        $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(TotalToCutReady);
                    }
                }
                else {
                    $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(QntyToCutReady);
                }
            }
            else {
                $("#<%= gvIECuttingSlot.ClientID %> input[id*='ctl" + cId + "_txtTotaltoCutReady" + "']").val(hdnbalance);
            }
        }

        function DisableSubmit() {
            //debugger;
            $(".submit").addClass("submit-hide");
        }
        //        //added by abhishek 22/11/2018
        //        function CheckFilter() {
        //            debugger;
        //            var ddlClient = $('#<%= ddlClient.ClientID %> option:selected').val();
        //            var ddlDept = $('#<%= ddlDepts.ClientID %> option:selected').val();
        //            var SearchText = $('#<%= txtsearch.ClientID %>').val();
        //            if (SearchText == undefined) {
        //                SearchText = "";
        //            }
        //            if (ddlClient != "-1") {
        //                if (ddlDept == "-1" && SearchText.trim() == "") {

        //                    $('#<%= txtsearch.ClientID %>').css('border-color', 'red');
        //                    $('#<%= ddlDepts.ClientID %>').css('border-color', 'red');
        //                    alert("Please select depratment or search keyword along with client !");
        //                    return false;
        //                }
        //            }
        //            else if (ddlClient == "-1") {
        //                alert("Please select client !");
        //                $('#<%= ddlClient.ClientID %>').css('border-color', 'red');
        //                return false;
        //            }
        //            else {
        //                return true;
        //            }
        //        }
      
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            ShowImagePreview();
            if (window.history.replaceState) {
                window.history.replaceState(null, null, window.location.href);
            }
        });
        // Configuration of the x and y offsets
        function ShowImagePreview() {
            xOffset = -20;
            yOffset = 40;
            $("a.preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:350px !important; width:320px !important;'/>" + c + "</p>");
                $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
            },

function () {
    this.title = this.t;
    $("#preview").remove();
});
            $("a.preview").mousemove(function (e) {
                $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
            });
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <%--  <div id="spinner">
    </div>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
   <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <table width="1010px" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
        <tr>
            <td>
                <div id='parent' style='background: white;'>
                    <div id='child' style='background: TRANSPARENT image no-repeat center center;'>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td colspan="6" align="center">
                                    <h2 class="headerbackcolr" >
                                        Daily Cutting Entry
                                        <span style="float:right"> <asp:Label ID="lblFactory" runat="server" Text="" Style="font-size: 16px;"></asp:Label></span>
                                    </h2>
                                    
                                </td>
                            </tr>
                            <tr>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <td style="height: 40px;" colspan="3">
                                          
                                                Client :
                                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                                </asp:DropDownList>
                                         
                                        </td>
                                        <td>
                                           Pare.Dept. <asp:DropDownList runat="server" ID="ddlDepts" CssClass="do-not-disable" Style="max-width: 140px;
                                                min-width: 120px;">
                                                <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="placehol">
                                            <asp:TextBox ID="txtsearch" runat="server" placeholder="Style/Serial Number" Style="text-align:center;"></asp:TextBox>
                                        </td>
                                        <td style="text-align:right">
                                            <asp:Button ID="btn_search" OnClientClick="javascript:return CheckFilter();" OnClick="btn_search_Click"
                                                runat="server" BorderWidth="0" CssClass="go submit" Text="Search" />
                                        </td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </tr>
                            <tr style="display:none;">
                                <td style="text-align: left">
                                    <b>Actual OB W/S :</b>
                                    <asp:Label ID="lblworkerCout" runat="server" Style="color: Blue; font-size: 14px;
                                        font-weight: bold;" Text=""></asp:Label>
                                </td>
                                <td class="price" style="text-align: left">
                                    <b>Targets : </b>
                                    <asp:Label ID="lblTrget" runat="server" Style="color: Blue; font-size: 14px; font-weight: bold;"
                                        Text=""></asp:Label>
                                </td>
                                <td align="right" style="padding-bottom: 5px;">
                                    <asp:Button ID="btnSubmit" runat="server" OnClientClick="DisableSubmit()" Text="Submit"
                                        CssClass="submit" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tblHeading" visible="false" runat="server" cellpadding="0" cellspacing="0"
                    border="1" width="100%">
                    <thead>
                        <tr>
                            <th colspan="3" style="font-weight:bold !important;">
                               
                                <asp:HiddenField ID="hdnProductionUnit" runat="server" />
                                <asp:HiddenField ID="hdnSlotId" runat="server" />
                                <asp:HiddenField ID="hdnStartDate" runat="server" />
                                <asp:HiddenField ID="hdnStatus" Value="" runat="server" />
                                <asp:HiddenField ID="hdnOrderDetailId" Value="-1" runat="server" />
                                <asp:HiddenField ID="hdnparmtotalentrySum" Value="0" runat="server" />
                                <asp:HiddenField ID="hdntotalAltpcs" Value="0" runat="server" />
                            </th>
                            <th colspan="6" style="font-size:12px !important; font-weight:bold !important;">
                                Cutting
                            </th>
                            <th colspan="2" style="font-size:12px !important; font-weight:bold !important;">
                                Cut Ready
                            </th>
                            <th rowspan="2" style="width: 60px;font-size:12px !important; font-weight:bold !important;">
                                Almost Complete
                            </th>
                            <th rowspan="2" style="width: 60px;font-size:12px !important; font-weight:bold !important;">
                                Cutting Complete
                            </th>
                        </tr>
                        <tr>
                            <th style="width: 75px">
                                Thumbnail
                            </th>
                            <th style="width: 180px">
                                Style No. (client)<br>
                                Serial No./ Contract No.
                                <br>
                                Print Color
                            </th>
                            <th style="width: 105px">
                                Pcd Date<br>
                                Ex. Fact. Date<br>
                                Delivery mode
                            </th>
                            <th style="width: 65px">
                                Order Qty
                            </th>
                            <th style="width: 65px">
                                Order Balance
                            </th>
                            <th style="width: 65px">
                                Factory Qty
                            </th>
                            <th style="width: 65px">
                                Factory Balance
                            </th>
                            <th style="width: 65px">
                                Cut Pcs
                            </th>
                            <th style="width: 65px">
                                Total Cut Qty
                            </th>
                            <th style="width: 65px">
                                Balance
                            </th>
                            <th style="width: 65px">
                                Cut Rdy Pcs
                            </th>
                        </tr>
                    </thead>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvIECuttingSlot" ShowHeader="false" AutoGenerateColumns="false"
                    runat="server" OnRowDataBound="gvIECuttingSlot_RowDataBound" Width="100%" CellPadding="0"
                    CellSpacing="0">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75px">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnClientid" Value='<%# Eval("ClientID") %>' runat="server" />
                                <asp:HyperLink ID="HyperLink1" Target="_blank" class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'
                                    runat="server">
                                    <img id="imgstyle" width="65" onclick="javascript:void(0)" height="65" runat="server"
                                        alt="Image not available" src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>' />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
                            <ItemTemplate>
                                <asp:Label ID="lblstyleNo" Style="font-weight: bold;" runat="server" Text='<%# Eval("StyleNumber") %>'></asp:Label>
                                (
                                <asp:Label ID="lblclientName" ToolTip="Client name" runat="server" Text='<%# Eval("clientname") %>'></asp:Label>)
                                <br />
                                <asp:Label ID="lblserialnumber" Style="color: Blue; font-size: 10px;" ToolTip="style serial number"
                                    runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label>
                                <asp:Label ID="lblContract" runat="server" Style="color: Gray; font-size: 10px;"
                                    ToolTip="Style contract no." Text='<%# Eval("ContractNumber") %>'></asp:Label><br />
                                <asp:Label ID="lblprintdetails" runat="server" Style="color: Gray; font-size: 9px;"
                                    ToolTip="Print color" Text='<%# Eval("PrintDeatis") %>'></asp:Label>
                                <asp:HiddenField ID="hdnStyleId" Value='<%# Eval("StyleID") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderId" Value='<%# Eval("id") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderDetailId" Value='<%# Eval("OrderDetailID") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="105px">
                            <ItemTemplate>
                                <asp:Label ID="lblpcddate" ToolTip="PCD date" runat="server" Style="color: Blue;
                                    font-size: 10px;" Text='<%# Eval("PCDDate") %>'></asp:Label><br />
                                <asp:Label ID="lblexfacdate" ToolTip="Ex-factory Date" Style="color: Blue; font-size: 10px;"
                                    runat="server" Text='<%# Eval("ExFactory") %>'></asp:Label><br />
                                <asp:Label ID="lbldeliveryModes" ToolTip="Delivery mode" Style="color: #808080; font-size: 10px;"
                                    runat="server" Text='<%# Eval("deliveryModes") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="65px">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQnty" runat="server" Width="80%" Text='<%# Eval("OrderQuantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="65px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOrderBalance" CssClass="do-not-allow-typing" BorderColor="White"
                                    Text='<%# Eval("OrderBalance") %>' TabIndex="-1" Width="80%" Style="text-align: center" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdnOrderBalance" Value='<%# Eval("OrderBalance") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="65px">
                            <ItemTemplate>
                                <asp:Label ID="lblcontractQnty" runat="server" Width="80%" Text='<%# Eval("Quantity") %>'></asp:Label>
                                <asp:HiddenField ID="hdnContactQnty" Value='<%# Eval("Quantity") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderQuantity" Value='<%# Eval("OrderQuantity") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderTotalCut" Value='<%# Eval("OrderTotalCut") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderStitchedQty" Value='<%# Eval("OrderStichedQty") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="65px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTotaltoCutQty" CssClass="do-not-allow-typing" BorderColor="White"
                                    Text='<%# Eval("TotaltoCut") %>' TabIndex="-1" Width="80%" Style="text-align: center" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdnQntyTocut" Value='<%# Eval("TotaltoCut") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox Width="40" ToolTip="Enter cut Pcs" ID="txtSlotPass" Text='<%# Eval("Slot1Pass") %>'
                                    MaxLength="4" onblur="javascript:return CalculateCutEntry(this);" CssClass="numeric-field-without-decimal-places"
                                    runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdnstyleNu" runat="server" Value='<%# Eval("StyleNumber") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="65px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCutQty" CssClass="do-not-allow-typing" BorderColor="White" Style="text-align: center;
                                    color: Black" runat="server" TabIndex="-1" readonly Width="80%" Text='<%# Eval("CuttingQty") %>'></asp:TextBox>
                                <asp:HiddenField ID="hdnCutQty" runat="server" Value='<%# Eval("CuttingQty") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="65px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTotaltoCutReady" CssClass="do-not-allow-typing" BorderColor="White"
                                    Text='<%# Eval("TotaltoCutReady") %>' readonly TabIndex="-1" Width="80%" Style="text-align: center"
                                    runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdnQntyToCutReady" Value='<%# Eval("TotaltoCutReady") %>' runat="server" />
                                <asp:HiddenField ID="hdnTotaltoCutReady" Value='<%# Eval("TotaltoCutReady") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox Width="40" ToolTip="Enter cut ready Pcs" ID="txtCutReady" onblur="javascript:return CalculateCutReadyEntry(this);"
                                    CssClass="numeric-field-without-decimal-places" Text='<%# Eval("CutReadyPcs") %>'
                                    MaxLength="4" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkalmostcomplete" Checked='<%# Eval("AlmostChk") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkMarkAsCut" Checked='<%# Eval("MarkasCut") %>' ToolTip="Check as cut complete"
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-bottom: 5px;">
                <asp:Button ID="btnSubmit2" runat="server" Text="Submit" OnClientClick="DisableSubmit()"
                    CssClass="submit" OnClick="btnSubmit2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
