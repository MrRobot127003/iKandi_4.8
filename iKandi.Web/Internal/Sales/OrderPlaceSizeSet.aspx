<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPlaceSizeSet.aspx.cs" Inherits="iKandi.Web.Internal.Sales.OrderPlaceSizeSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Size_breackdown {
            width: 800px;
            margin: 0 auto;
        }
        .line_contact {
            width: 800px;
            margin: 0 auto;
            text-align: center;
        }
        .Size_breackdown .spacediv {
            width: 10px;
            float: left;
        }
        
        
        .clearboth {
            clear: both;
        }
        
        .radio_botton span input[type="radio"] {
            position: relative;
            top: 2px;
        }
        .radio_botton span {
            font-size: 11px;
            color: #403b3b;
        }
        .size_breack_table {
            width: 800px;
            border: 1px solid #999999;
            border-collapse: collapse;
            margin-top: 10px;
        }
        .size_breack_table thead th {
            color: Black;
            background-color: #F9DDF4;
            text-transform: uppercase;
            text-align: center;
            padding: 3px 0px;
            font-weight: normal;
            border: 1px solid #999999;
            font-size: 11px;
            max-width: 40px;
        }
        .size_breack_table tbody th {
            color: Black;
            background-color: #F9DDF4;
            text-transform: uppercase;
            text-align: center;
            padding: 2px;
            font-weight: normal;
            border: 1px solid #999999;
            font-size: 10px;
        }
        .size_breack_table tbody td {
            border: 1px solid #999999;
            text-align: center;
            font-size: 11px;
        }
        .size_breack_table tbody td input[type='text'] {
            width: 84%;
            text-align: center;
            font-size: 11px; /* padding: 3px 2px; */
            margin: 2px 0px;
        }
        
        .size_breack_table thead th input[type="text"] {
            width: 90%;
            background-color: #F9DDF4;
            border: 0px;
            font-size: 11px;
            text-align: center;
            color: Blue;
        }
        #rbtnOption {
            margin: 0 auto;
        }
        .radio_botton input[type="radio"] {
            position: relative;
            top: 2px;
        }
        .submit {
            cursor: pointer;
        }
    </style>
</head>
<body>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/fna.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var SizeLength = 0;
        $(function () { GetSizeSet(0); });


        function GetSizeSet(obj) {
            //debugger;
            var ClientId = '<%=this.ClientId %>';
            var DeptId = '<%=this.DeptId %>';
            var OrderDetailId = '<%=this.OrderDetailId %>';
            var TotalQty = $("#hdnTotalQuantity").val();

            var OptionId = 0;
            if (obj == 0) {
                var list = document.getElementById("rbtnOption"); //Client ID of the radiolist
                var radioOption = list.getElementsByTagName("input");

                for (var i = 0; i < radioOption.length; i++) {
                    if (radioOption[i].checked) {
                        OptionId = radioOption[i].value;
                    }
                }
            }
            else {
                OptionId = $(obj).val();
            }

            for (var Sno = 1; Sno <= 15; Sno++) {
                $("#txtsize_" + Sno).val('');
                $("#single_" + Sno).val('');
                $("#ratio_pack_" + Sno).val('');
                $("#ratio_" + Sno).val('');
                $("#quantity_" + Sno).val('');

                $("#single_" + Sno).attr('readonly', false);
                $("#ratio_" + Sno).attr('readonly', false);
            }
            $("#single_total").val('');
            $("#ratio_pack_total").val('');
            $("#ratio_total").val('');
            $("#quantity_total").val('');

            var QuantitySum = 0;
            var SingleSum = 0;
            var Ratio_packSum = 0;

            proxy.invoke("GetSizeSetDetails", { ClientId: ClientId, DeptId: DeptId, OptionId: OptionId, OrderDetailId: OrderDetailId },
            function (result) {
                //debugger;
                SizeLength = parseInt(result.length);
                $("#hdnSizeLength").val(SizeLength);
                var j = 1;
                //debugger;
                for (var Sno = 0; Sno < SizeLength; Sno++) {
                    //debugger;
                    var Size = result[Sno].Size.trim();
                    var Single = result[Sno].Singles;
                    var Ratio = result[Sno].Ratio;
                    var RatioPack = result[Sno].RatioPack;
                    var Quantity = result[Sno].Quantity;
                    $("#txtsize_" + j).val(Size);

                    if (Single > 0) {
                        $("#single_" + j).val(Single);
                        SingleSum = parseInt(SingleSum) + parseInt(Single)
                    }

                    if (Ratio > 0)
                        $("#ratio_" + j).val(Ratio);

                    if (RatioPack > 0) {
                        $("#ratio_pack_" + j).val(RatioPack);
                        Ratio_packSum = parseInt(Ratio_packSum) + parseInt(RatioPack)
                    }

                    if (Quantity > 0) {
                        $("#quantity_" + j).val(Quantity);
                        QuantitySum = parseInt(QuantitySum) + parseInt(Quantity);
                    }

                    j = j + 1;
                }
                //debugger;
                if (SingleSum > 0) {
                    $("#single_total").val(SingleSum);
                }
                if (Ratio_packSum > 0) {
                    $("#ratio_pack_total").val(Ratio_packSum);
                }
                if (QuantitySum > 0) {
                    $("#quantity_total").val(QuantitySum);
                }
                var RemainQty = parseInt(TotalQty) - parseInt(QuantitySum);
                //if (parseInt(RemainQty) > 0) {
                $("#lblRemainingQty").text(CommaSeprated(RemainQty));
                //} else { $("#lblRemainingQty").text(''); }
                //debugger;
                if (parseInt(SizeLength) < 15) {
                    var LastNo = parseInt(SizeLength) + 1;

                    while (LastNo <= 15) {
                        $("#single_" + LastNo).attr('readonly', true);
                        $("#ratio_" + LastNo).attr('readonly', true);

                        LastNo = parseInt(LastNo) + 1
                    }
                }
            });
        }

        function CalculateSingleValue(obj) {
            debugger;
            var id = obj.id.split("_")[1];
            var ThisQuantity = $("#quantity_" + id).val();

            var length = SizeLength;
            var TotalQty = $("#hdnTotalQuantity").val();
            var TotalSingleVal = 0;
            var TotalRatioPack = 0;
            var Quantity = 0;
            var QuantitySum = 0;

            for (var Sno = 1; Sno <= length; Sno++) {
                Quantity = 0;
                var Single = $("#single_" + Sno).val();

                if (Single != '') {
                    Quantity = parseInt(Single);
                    TotalSingleVal = parseInt(TotalSingleVal) + parseInt(Single);
                }
                var RatioPack = $("#ratio_pack_" + Sno).val();

                if (RatioPack != '') {
                    TotalRatioPack = parseInt(TotalRatioPack) + parseInt(RatioPack);
                    Quantity = parseInt(Quantity) + parseInt(RatioPack);
                }

                if (Quantity > 0) {
                    $("#quantity_" + Sno).val(Quantity);
                    QuantitySum = parseInt(QuantitySum) + parseInt(Quantity)
                }
                else
                    $("#quantity_" + Sno).val('');
            }
            //debugger;
            var TotalVal = parseInt(TotalRatioPack) + parseInt(TotalSingleVal);
            var Thisval = $(obj).val();

            if (TotalSingleVal == 0) {
                $(obj).val('');
                $("#quantity_" + id).val('');
            }
            if (parseInt(TotalQty) + 1 < TotalVal) {
                TotalSingleVal = parseInt(TotalSingleVal) - parseInt(Thisval);
                QuantitySum = parseInt(QuantitySum) - parseInt(Thisval)
                $(obj).val('');
                $("#quantity_" + id).val('');
            }
            // else {
            if (TotalSingleVal > 0) {
                $("#single_total").val(TotalSingleVal);
            }
            else if (TotalSingleVal <= 0) {
                $("#single_total").val('');
            }
            if (TotalRatioPack > 0) {
                $("#ratio_pack_total").val(TotalRatioPack);
            }
            else if (TotalRatioPack <= 0) {
                $("#ratio_pack_total").val('');
            }
            if (QuantitySum > 0) {
                $("#quantity_total").val(QuantitySum);
                var RemainQty = parseInt(TotalQty) - parseInt(QuantitySum);
                // if (parseInt(RemainQty) > 0) {
                $("#lblRemainingQty").text(CommaSeprated(RemainQty));
                // } else { $("#lblRemainingQty").text(''); }
            }
            else if (QuantitySum <= 0) {
                $("#quantity_total").val('');
                var RemainQty = parseInt(TotalQty) - parseInt(QuantitySum);
                // if (parseInt(RemainQty) > 0) {
                $("#lblRemainingQty").text(CommaSeprated(RemainQty));
                // } else { $("#lblRemainingQty").text(''); }
            }
            // }
        }

        function CalculateRatio(obj) {
            debugger;
            var id = obj.id.split("_")[1];
            var ThisQuantity = $("#quantity_" + id).val();

            var length = SizeLength;
            var TotalQty = $("#hdnTotalQuantity").val();

            var TotalSingleVal = $("#single_total").val();
            if (TotalSingleVal == '')
                TotalSingleVal = 0;

            var TotalRatioPack = TotalQty - TotalSingleVal;

            var TotalRatio = 0;
            for (var Sno = 1; Sno <= length; Sno++) {
                var Ratio = $("#ratio_" + Sno).val();
                if (Ratio != '') {
                    TotalRatio = parseInt(TotalRatio) + parseInt(Ratio);
                }
            }

            var QuantitySum = 0;
            var Quantity = 0;
            var RatioPackSum = 0;

            for (var Sno = 1; Sno <= length; Sno++) {
                Quantity = 0;
                var Single = $("#single_" + Sno).val();

                if (Single != '') {
                    Quantity = parseInt(Single);
                }

                var Ratio = $("#ratio_" + Sno).val();

                var RatioPack = '';

                if (Ratio != '') {
                    RatioPack = Math.round((parseFloat(Ratio) / parseFloat(TotalRatio)) * parseFloat(TotalRatioPack));
                    $("#ratio_pack_" + Sno).val(RatioPack);
                }
                else {
                    $("#ratio_pack_" + Sno).val('');
                }

                if (RatioPack != '') {
                    RatioPackSum = parseInt(RatioPackSum) + parseInt(RatioPack);
                    Quantity = parseInt(Quantity) + parseInt(RatioPack);
                }

                if (Quantity > 0) {
                    $("#quantity_" + Sno).val(Quantity);
                    QuantitySum = parseInt(QuantitySum) + parseInt(Quantity)
                }
                else
                    $("#quantity_" + Sno).val('');
            }
            //debugger;
            if (TotalRatio == 0) {
                $(obj).val('');
                $("#ratio_pack_" + id).val('');
                $("#ratio_pack_total").val('');
                $("#quantity_" + id).val('');

                if (QuantitySum > 0) {
                    $("#quantity_total").val(QuantitySum);
                    var RemainQty = parseInt(TotalQty) - parseInt(QuantitySum);
                    //  if (parseInt(RemainQty) > 0) {
                    $("#lblRemainingQty").text(CommaSeprated(RemainQty));
                    //  } else { $("#lblRemainingQty").text(''); }
                }
                else {
                    $("#quantity_total").val('');
                    var RemainQty = parseInt(TotalQty) - parseInt(QuantitySum);
                    //  if (parseInt(RemainQty) > 0) {
                    $("#lblRemainingQty").text(CommaSeprated(RemainQty));
                    // } else { $("#lblRemainingQty").text(''); }
                }
            }

            else {

                if (RatioPackSum > 0) {
                    $("#ratio_pack_total").val(RatioPackSum);
                }
                if (QuantitySum > 0) {
                    $("#quantity_total").val(QuantitySum);
                    var RemainQty = parseInt(TotalQty) - parseInt(QuantitySum);
                    // if (parseInt(RemainQty) > 0) {
                    $("#lblRemainingQty").text(CommaSeprated(RemainQty));
                    // } else { $("#lblRemainingQty").text(''); }
                }
            }
        }

        function Submit() {
            //debugger;
            var TotalQty = $("#hdnTotalQuantity").val();
            var QuantitySum = $("#quantity_total").val();

            if (QuantitySum == '')
                QuantitySum = 0;
            if (QuantitySum > 0) {
                if (parseInt(QuantitySum) + 1 < TotalQty) {
                    jQuery.facebox('Input Quantity Can Not Be Less than Total');
                    return false;
                }
                if (parseInt(QuantitySum) - 1 > TotalQty) {
                    jQuery.facebox('Input Quantity Can Not Be Greater than Total');
                    return false;
                }
            }
        }

        function closeSizeSet() {
            jQuery.facebox('Sizes Saved successfully!');
            self.parent.Shadowbox.close();
        }

        function CommaSeprated(num) {
            return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
        }

    </script>
    <form id="form1" runat="server">
    <div style="width: 100%; margin-bottom: 5px; color: #fff; line-height: 19px; height: 20px;" class="form_heading">
        Size Breakdown <span style="float: right; padding: 2px 4px; position: relative; cursor: pointer" onclick="closeSizeSet()">X</span>
    </div>
    <div class="Size_breackdown">
        <div class="line_contact">
            <table cellpadding="0px" width="100%;" cellspacing="0" border="0">
                <tr>
                    <td style="text-align: center; font-size: 11px; color: #403b3b">
                        Line Number:&nbsp;<asp:Label ID="lblLineNo" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;&nbsp; Contract Number:&nbsp;<asp:Label ID="lblContractNo" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;&nbsp; Quantity:&nbsp;<asp:Label ID="lblQuantity" Font-Bold="true" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnTotalQuantity" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnOrderDetailId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; width: 100%; font-size: 11px;" class="radio_botton">
                        <asp:RadioButtonList ID="rbtnOption" RepeatDirection="Horizontal" runat="server">
                        </asp:RadioButtonList>
                        <asp:HiddenField ID="hdnSizeLength" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnOption" Value="0" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; color: #403b3b; font-size: 11px;">
                        Remaining Qty:&nbsp;<asp:Label ID="lblRemainingQty" Font-Bold="true" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clearboth">
        </div>
        <table cellpadding="0" cellspacing="0" class="size_breack_table">
            <thead>
                <tr>
                    <th style="min-width: 75px;">
                        Size
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_1" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_2" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_3" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_4" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_5" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_6" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_7" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_8" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_9" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_10" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_11" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_12" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_13" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_14" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        <asp:TextBox ID="txtsize_15" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        Total
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th>
                        SINGLES
                    </th>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_1" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_2" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_3" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_4" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_5" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_6" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_7" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_8" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_9" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_10" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_11" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_12" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_13" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_14" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateSingleValue(this)" class="numeric-field-without-decimal-places" maxlength="5" id="single_15" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" name="single_total" id="single_total" value="" />
                    </td>
                </tr>
                <tr>
                    <th>
                        RATIO PACK
                    </th>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_1" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_2" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_3" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_4" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_5" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_6" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_7" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_8" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_9" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_10" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_11" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_12" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_13" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_14" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" id="ratio_pack_15" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" name="ratio_pack_total" id="ratio_pack_total" value="" />
                    </td>
                </tr>
                <tr>
                    <th>
                        RATIO
                    </th>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_1" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_2" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_3" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_4" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_5" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_6" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_7" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_8" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_9" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_10" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_11" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_12" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_13" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_14" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" onblur="CalculateRatio(this)" class="numeric-field-without-decimal-places" maxlength="3" id="ratio_15" value="" />
                    </td>
                    <td>
                        <input type="text" runat="server" class="do-not-allow-typing" name="ratio_total" id="ratio_total" value="" />
                        <input type="hidden" name="hdnRatioTotal" id="hdnRatioTotal" />
                    </td>
                </tr>
                <tr>
                    <th>
                        QUANTITY
                    </th>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_1" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_2" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_3" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_4" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_5" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_6" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_7" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_8" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_9" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_10" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_11" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_12" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_13" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_14" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" id="quantity_15" value="" />
                    </td>
                    <td>
                        <input type="text" class="do-not-allow-typing" name="quantity_total" id="quantity_total" value="" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div style="float: right; margin-top: 10px;">
            <asp:Button ID="btnSubmit" CssClass="submit" runat="server" OnClientClick="javascript:return Submit()" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </div>
    </form>
</body>
</html>
