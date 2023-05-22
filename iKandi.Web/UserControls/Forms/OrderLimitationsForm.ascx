<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderLimitationsForm.ascx.cs"
    Inherits="iKandi.Web.OrderLimitationsForm" %>
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    var grdOrderBreakdownClientID = '<%=grdOrderBreakdown.ClientID %>';
    var IsFirstTimeChange = 0;


    $(function () {
        //debugger;

        var orderDate = new Date(ParseDateToSimpleDate($(".order-date").text()));
        var estDate = orderDate.add(parseInt(21)).days();
        //Edited by abhishek on 13/1/2015
        //$(".LabDipTarget", "#main_content").text(ParseDateToDateWithDay(estDate));
        //end by abhishek on 13/1/2015

        FillBihValue();

    });

    function FillBihValue() {
        //debugger;
        var MinBihDate1 = '';
        var MinBihDate2 = '';
        var MinBihDate3 = '';
        var MinBihDate4 = '';
        var BihDate1 = '';
        var BihDate2 = '';
        var BihDate3 = '';
        var BihDate4 = '';

        var orderDate = new Date(ParseDateToSimpleDate($(".order-date").text()));
        var gridCount = $("#" + grdOrderBreakdownClientID).find("tr").length;


        for (var Row = 1; Row < gridCount - 2; Row++) {
            //debugger;

            var objRow = $("#" + grdOrderBreakdownClientID).find("tr").filter("tr:eq(" + Row + ")");

            // for Bih 1
            if (MinBihDate1 == '') {
                MinBihDate1 = objRow.find("input.BIH1").val();
                if (MinBihDate1 != '') {
                    MinBihDate1 = new Date(ParseDateToSimpleDate(MinBihDate1));
                    $(".hdnBIH1", "#main_content").val(MinBihDate1);
                }
            }
            else {
                BihDate1 = objRow.find("input.BIH1").val();
                if (BihDate1 != '') {
                    BihDate1 = new Date(ParseDateToSimpleDate(BihDate1));
                }

                if (MinBihDate1 > BihDate1) {
                    MinBihDate1 = BihDate1
                    $(".hdnBIH1", "#main_content").val(MinBihDate1);
                }
            }

            // for Bih 2
            if (MinBihDate2 == '') {
                MinBihDate2 = objRow.find("input.BIH2").val();
                if (MinBihDate2 != '') {
                    MinBihDate2 = new Date(ParseDateToSimpleDate(MinBihDate2));
                    $(".hdnBIH2", "#main_content").val(MinBihDate2);
                }
            }
            else {
                BihDate2 = objRow.find("input.BIH2").val();
                if (BihDate2 != '') {
                    BihDate2 = new Date(ParseDateToSimpleDate(BihDate2));
                }

                if (MinBihDate2 > BihDate2) {
                    MinBihDate2 = BihDate2
                    $(".hdnBIH2", "#main_content").val(MinBihDate2);
                }
            }

            // for Bih 3
            if (MinBihDate3 == '') {
                MinBihDate3 = objRow.find("input.BIH3").val();
                if (MinBihDate3 != '') {
                    MinBihDate3 = new Date(ParseDateToSimpleDate(MinBihDate3));
                    $(".hdnBIH3", "#main_content").val(MinBihDate3);
                }
            }
            else {
                BihDate3 = objRow.find("input.BIH3").val();
                if (BihDate3 != '') {
                    BihDate3 = new Date(ParseDateToSimpleDate(BihDate3));
                }

                if (MinBihDate3 > BihDate3) {
                    MinBihDate3 = BihDate3
                    $(".hdnBIH3", "#main_content").val(MinBihDate3);
                }
            }

            // for Bih 4
            if (MinBihDate4 == '') {
                MinBihDate4 = objRow.find("input.BIH4").val();
                if (MinBihDate4 != '') {
                    MinBihDate4 = new Date(ParseDateToSimpleDate(MinBihDate4));
                    $(".hdnBIH4", "#main_content").val(MinBihDate4);
                }
            }
            else {
                BihDate4 = objRow.find("input.BIH4").val();
                if (BihDate4 != '') {
                    BihDate4 = new Date(ParseDateToSimpleDate(BihDate4));
                }

                if (MinBihDate4 > BihDate4) {
                    MinBihDate4 = BihDate4
                    $(".hdnBIH4", "#main_content").val(MinBihDate4);
                }
            }
        }
        //debugger;
        if (MinBihDate1 != '') {
            var day1 = Math.floor((MinBihDate1 - orderDate) / 86400000);
            var calcFabric1 = $(".CaclFabric1", "#main_content").val();
            if (calcFabric1 == '') {
                $(".CaclFabric1", "#main_content").val(day1);
                $(".HdnCalc1", "#main_content").val(day1);

            }
        }

        if (MinBihDate2 != '') {
            var day2 = Math.floor((MinBihDate2 - orderDate) / 86400000);
            var calcFabric2 = $(".CaclFabric2", "#main_content").val();
            if (calcFabric2 == '') {
                $(".CaclFabric2", "#main_content").val(day2);
                $(".HdnCalc2", "#main_content").val(day2);

            }
        }

        if (MinBihDate3 != '') {
            var day3 = Math.floor((MinBihDate3 - orderDate) / 86400000);
            var calcFabric3 = $(".CaclFabric3", "#main_content").val();
            if (calcFabric3 == '') {
                $(".CaclFabric3", "#main_content").val(day3);
                $(".HdnCalc3", "#main_content").val(day3);

            }
        }

        if (MinBihDate4 != '') {
            var day4 = Math.floor((MinBihDate4 - orderDate) / 86400000);
            var calcFabric4 = $(".CaclFabric4", "#main_content").val();
            if (calcFabric4 == '') {
                $(".CaclFabric4", "#main_content").val(day4);
                $(".HdnCalc4", "#main_content").val(day4);

            }
        }

    }

    function CalcFabricChange(obj, seq) {
        //debugger;
        var CalcValue = obj.value;
        var MaxValueBasic = ''
        var MaxValueNew = ''
        var NewBihDate = '';

        if (CalcValue != "") {

            var CalcPrevValue1 = $(".HdnCalc1", "#main_content").val();
            var CalcPrevValue2 = $(".HdnCalc2", "#main_content").val();
            var CalcPrevValue3 = $(".HdnCalc3", "#main_content").val();
            var CalcPrevValue4 = $(".HdnCalc4", "#main_content").val();

            var CalcValue1 = $(".CaclFabric1", "#main_content").val();
            var CalcValue2 = $(".CaclFabric2", "#main_content").val();
            var CalcValue3 = $(".CaclFabric3", "#main_content").val();
            var CalcValue4 = $(".CaclFabric4", "#main_content").val();


            if (CalcPrevValue1 == '') {
                CalcPrevValue1 = 0;
            }
            if (CalcPrevValue2 == '') {
                CalcPrevValue2 = 0;
            }
            if (CalcPrevValue3 == '') {
                CalcPrevValue3 = 0;
            }
            if (CalcPrevValue4 == '') {
                CalcPrevValue4 = 0;
            }

            if (CalcValue1 == '') {
                CalcValue1 = 0;
            }
            if (CalcValue2 == '') {
                CalcValue2 = 0;
            }
            if (CalcValue3 == '') {
                CalcValue3 = 0;
            }
            if (CalcValue4 == '') {
                CalcValue4 = 0;
            }
            IsFirstTimeChange = 1;
            //debugger;
            MaxValueBasic = Math.max(parseInt(CalcPrevValue1), parseInt(CalcPrevValue2), parseInt(CalcPrevValue3), parseInt(CalcPrevValue4))

            MaxValueNew = Math.max(parseInt(CalcValue1), parseInt(CalcValue2), parseInt(CalcValue3), parseInt(CalcValue4))

            if (parseInt(MaxValueNew) > parseInt(MaxValueBasic)) {
                //debugger;
                var dayDiff = parseInt(MaxValueNew) - parseInt(MaxValueBasic);

                var BasicDays = $('.basicDays').html();
                

//                if ((parseInt(BasicDays) - parseInt(dayDiff)) <= 7) {

//                    debugger;
//                    if (seq == '1') {
//                        $(".CaclFabric1", "#main_content").val(CalcPrevValue1);
//                        NewBihDate = $(".hdnBIH1", "#main_content").val();
//                    }
//                    if (seq == '2') {
//                        $(".CaclFabric2", "#main_content").val(CalcPrevValue2);
//                        NewBihDate = $(".hdnBIH2", "#main_content").val();
//                    }
//                    if (seq == '3') {
//                        $(".CaclFabric3", "#main_content").val(CalcPrevValue3);
//                        NewBihDate = $(".hdnBIH3", "#main_content").val();
//                    }
//                    if (seq == '4') {
//                        $(".CaclFabric4", "#main_content").val(CalcPrevValue4);
//                        NewBihDate = $(".hdnBIH4", "#main_content").val();
//                    }
//                    NewBihDate = new Date(NewBihDate);
//                    NewBihDate = NewBihDate.addDays(dayDiff);
//                    var NewChangedBIHDate = ParseDateToDateWithDay(NewBihDate);
//                    var days;

//                    var gridCount = $("#" + grdOrderBreakdownClientID).find("tr").length;

//                    for (var Row = 1; Row < gridCount - 2; Row++) {
//                        //debugger;
//                        var objRow = $("#" + grdOrderBreakdownClientID).find("tr").filter("tr:eq(" + Row + ")");

//                        var PCDDate = objRow.find("input.PCDbase").val();
//                        PCDDate = new Date(ParseDateToSimpleDate(PCDDate));
//                        var newPCDdate;
//                        var BihDate1 = objRow.find("input.BihFabric1").val();
//                        if (BihDate1 != '') {

//                            BihDate1 = new Date(ParseDateToSimpleDate(BihDate1));
//                            if (NewBihDate > BihDate1) {

//                                var day1 = Math.floor((NewBihDate - BihDate1) / 86400000);
//                                PCDDate = PCDDate.addDays(day1);

//                                var ExFactoryDate = objRow.find("input.ExFactory").val();
//                                ExFactoryDate = new Date(ParseDateToSimpleDate(ExFactoryDate));

//                                days = Math.floor((ExFactoryDate - PCDDate) / 86400000);

//                                newPCDdate = ParseDateToDateWithDay(PCDDate);
//                            }
//                        }
//                    }

//                    alert('Request for BIH Target ' + NewChangedBIHDate + ' is not accepted due to short production time (' + days + 'days)  pushing PCD target to ' + newPCDdate + ' .Please contact Sales Director.');

//                    //                    alert('Not ample production time, hence request not accepted. Please contact Sales Director.');

//                    return false;
//                }
                //else {
                    //debugger;
                    if (seq == '1') {
                        NewBihDate = $(".hdnBIH1", "#main_content").val();
                    }
                    if (seq == '2') {
                        NewBihDate = $(".hdnBIH2", "#main_content").val();
                    }
                    if (seq == '3') {
                        NewBihDate = $(".hdnBIH3", "#main_content").val();
                    }
                    if (seq == '4') {
                        NewBihDate = $(".hdnBIH4", "#main_content").val();
                    }
                    NewBihDate = new Date(NewBihDate);
                    NewBihDate = NewBihDate.addDays(dayDiff);

                    var gridCount = $("#" + grdOrderBreakdownClientID).find("tr").length;

                    for (var Row = 1; Row < gridCount - 2; Row++) {
                        //debugger;
                        var objRow = $("#" + grdOrderBreakdownClientID).find("tr").filter("tr:eq(" + Row + ")");


                        var PCDDate = objRow.find("input.PCDbase").val();
                        PCDDate = new Date(ParseDateToSimpleDate(PCDDate));

                        var BihDate1 = objRow.find("input.BihFabric1").val();
                        if (BihDate1 != '') {

                            BihDate1 = new Date(ParseDateToSimpleDate(BihDate1));
                            if (NewBihDate > BihDate1) {

                                var day1 = Math.floor((NewBihDate - BihDate1) / 86400000);
                                PCDDate = PCDDate.addDays(day1);

                                objRow.find("input.BIH1").val(ParseDateToDateWithDay(NewBihDate));

                                objRow.find("input.PCDdate").val(ParseDateToDateWithDay(PCDDate));
                            }

                        }

                        var BihDate2 = objRow.find("input.BihFabric2").val();
                        if (BihDate2 != '') {
                            BihDate2 = new Date(ParseDateToSimpleDate(BihDate2));
                            if (NewBihDate > BihDate2) {
                                objRow.find("input.BIH2").val(ParseDateToDateWithDay(NewBihDate));
                            }
                        }

                        var BihDate3 = objRow.find("input.BihFabric3").val();
                        if (BihDate3 != '') {

                            BihDate3 = new Date(ParseDateToSimpleDate(BihDate3));
                            if (NewBihDate > BihDate3) {
                                objRow.find("input.BIH3").val(ParseDateToDateWithDay(NewBihDate));
                            }
                        }

                        var BihDate4 = objRow.find("input.BihFabric4").val();
                        if (BihDate4 != '') {

                            BihDate4 = new Date(ParseDateToSimpleDate(BihDate4));
                            if (NewBihDate > BihDate4) {
                                objRow.find("input.BIH4").val(ParseDateToDateWithDay(NewBihDate));
                            }
                        }
                    }

                    GetCMTByDays();
               // }
            }
            else {
                //debugger;

                if (parseInt(MaxValueNew) == parseInt(MaxValueBasic)) {
                    var gridCount = $("#" + grdOrderBreakdownClientID).find("tr").length;

                    for (var Row = 1; Row < gridCount - 2; Row++) {
                        //debugger;
                        var objRow = $("#" + grdOrderBreakdownClientID).find("tr").filter("tr:eq(" + Row + ")");

                        var PCDDate = objRow.find("input.PCDbase").val();
                        PCDDate = new Date(ParseDateToSimpleDate(PCDDate));
                        objRow.find("input.PCDdate").val(ParseDateToDateWithDay(PCDDate));

                        var BihDate1 = objRow.find("input.BihFabric1").val();

                        if (BihDate1 != '') {
                            BihDate1 = new Date(ParseDateToSimpleDate(BihDate1));
                            objRow.find("input.BIH1").val(ParseDateToDateWithDay(BihDate1));

                        }
                        var BihDate2 = objRow.find("input.BihFabric2").val();
                        if (BihDate2 != '') {
                            BihDate2 = new Date(ParseDateToSimpleDate(BihDate2));
                            objRow.find("input.BIH2").val(ParseDateToDateWithDay(BihDate2));

                        }

                        var BihDate3 = objRow.find("input.BihFabric3").val();
                        if (BihDate3 != '') {

                            BihDate3 = new Date(ParseDateToSimpleDate(BihDate3));
                            objRow.find("input.BIH3").val(ParseDateToDateWithDay(BihDate3));

                        }

                        var BihDate4 = objRow.find("input.BihFabric4").val();
                        if (BihDate4 != '') {
                            BihDate4 = new Date(ParseDateToSimpleDate(BihDate4));
                            objRow.find("input.BIH4").val(ParseDateToDateWithDay(BihDate4));
                        }
                    }
                    //debugger;
                    $('.lblLeadTimeMessage').html('');
                    $('.clsLeadTime').html('');
                    $('.lblCMTmessage').html('');
                    $('.clsCalcCMT').html('');
                    $('.lblLossMessage').html('');
                    $('.clsProdLoss').html('');

                }

            }

        }
    }

    function GetCMTByDays() {
        //debugger;
        var gridCount = $("#" + grdOrderBreakdownClientID).find("tr").length;
        var DaysDiff = 0;
        for (var Row = 1; Row < gridCount - 2; Row++) {
            //debugger;
            var objRow = $("#" + grdOrderBreakdownClientID).find("tr").filter("tr:eq(" + Row + ")");

            var PCDDate = objRow.find("input.PCDdate").val();
            PCDDate = new Date(ParseDateToSimpleDate(PCDDate));

            var ExFactoryDate = objRow.find("input.ExFactory").val();
            ExFactoryDate = new Date(ParseDateToSimpleDate(ExFactoryDate));

            var days = Math.floor((ExFactoryDate - PCDDate) / 86400000);

            if (DaysDiff == 0) {
                DaysDiff = days
            }
            if (parseInt(DaysDiff) > parseInt(days)) {
                DaysDiff = days
            }

        }
        $(".DaysDiff", "#main_content").val(DaysDiff);
        if (DaysDiff != 0) {
            $(".PCD_Change", "#main_content").val(1);
        }
        else {
            $(".PCD_Change", "#main_content").val(0);
        }
        //debugger;
//        var BarrierDays = 0;
//        BarrierDays = DaysDiff - 7;
//        if (BarrierDays > 0) {
//            var orderID = $('#<%= hdnOrderId.ClientID %>').val();
//            var profitloss = '';

//            $('#<%= hdnCalcBarrierDays.ClientID %>').val(BarrierDays);
//            var LeadTimeMsg = 'Prod Time After Lead Time Changes : ';
//            $('.lblLeadTimeMessage').html(LeadTimeMsg);
//            $('.clsLeadTime').html(BarrierDays.toString());

//            proxy.invoke("GetCMTbyOrderID", { OrderID: orderID, BarrierDay: BarrierDays }, function (result) {
//                //debugger;
//                if (parseInt(result[0]) != parseInt($('.basicCMT').html())) {

//                    $('#<%= hdnBarrierDaysCMT.ClientID %>').val(result[0]);
//                    var CMTmsg = 'CMT After Lead Time Changes : ';
//                    $('.lblCMTmessage').html(CMTmsg);
//                    $('.clsCalcCMT').html('Rs. ' + result[0].toString());


//                    var OldCMT = $('.basicCMT').html();
//                    var NewCMT = result[0];
//                    var OrderQty = $('.orderQty').html();
//                    if (OrderQty != '') {
//                        profitloss = (parseInt(OldCMT) - parseInt(NewCMT)) * parseFloat(OrderQty);
//                        if (parseInt(profitloss) < 0) {
//                            profitloss = profitloss.toString();
//                            profitloss = profitloss.substring(1, profitloss.length);
//                        }
//                    }
//                    var LossMsg = 'Loss : ';
//                    $('.lblLossMessage').html(LossMsg);
//                    $('.clsProdLoss').html('Rs. ' + profitloss);



//                }
//            }, onPageError, false, false);
//        }
//        else {
//            alert('This days is not valid for calculating CMT');
//            return false;
//        }

    }

    function ShowAlerMsg() {
        //debugger;
        alert('PCD Date can not be equal or greater than ExFactory date');
    }

</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
#secure_banner_cor
{
    background:#fff !important;
}
.print-box
{
    background:#fff !important;
}
.item_list td
{
    text-align:left !important;
}
</style>
<asp:Panel runat="server" ID="pnlForm">
    <div class="print-box">
        <div class="form_box">
            <div class="form_heading">
                <strong style="color:#000000;">LIMITATIONS FORM</strong>
                <asp:HiddenField ID="hdnOrderId" Value="-1" runat="server" />
            </div>
            <div style="width:100%;">
            <table class="item_list" bordercolor="#000000" border="1" width="100%">
                <tbody>
                    <tr>
                        <th style="width: 10%;" class="limit_heading">
                            Order Date:
                        </th>
                        <td style="width: 15%;">
                            <asp:Label runat="server" ID="lblIkandiOrderDate"  CssClass="blue-text order-date"></asp:Label>
                            <input id="hdnDaysDiff" runat="server" type="hidden" visible="true" class="DaysDiff" value="0" />  
                            <input id="hdnIsPCD_Change" runat="server" type="hidden" visible="true" class="PCD_Change" value="-1" />  
                           
                        </td>
                        <th style="width: 10%;" class="limit_heading">
                            Style Number:
                        </th>
                        <td style="text-align: left; background-color:White; width: 15%;">
                            <asp:HiddenField ID="hiddenStyleID" runat="server" Value="-1" />
                            <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%= hiddenStyleID.Value %>,-1,-1)'>
                                <asp:Label runat="server" ID="lblIkandiStyleNumber"></asp:Label>
                            </a>
                        </td>
                        <th style=" width: 10%;" class="limit_heading">
                            Serial No.:
                        </th>
                        <td style="width: 15%;">
                            <asp:Label runat="server" ID="lblIkandiSerial"  CssClass="blue-text"></asp:Label>
                        </td>
                        <th style="width: 10%;" class="limit_heading">
                           LAB/DIP TARGET :
                        </th>
                        <td>
                            <asp:Label runat="server" ID="lbLabDipTarget" CssClass="blue-text orderQty"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Description:
                        </th>
                        <td>
                            <asp:Label runat="server" ID="lblDescription" CssClass="blue-text"></asp:Label>
                        </td>
                        <th>
                            Buyer:
                        </th>
                        <td>
                        <asp:Label runat="server" ID="lblBuyer" CssClass="blue-text"></asp:Label>                            
                        </td>
                        <th>
                            Department:
                        </th>
                        <td>
                            <asp:Label runat="server" ID="lblDepartment" CssClass="blue-text"></asp:Label>
                        </td>
                        <th>
                        Total Quantity:
                        </th>
                        <td>
                       <asp:Label runat="server" ID="lblTotalQuantity" CssClass="blue-text orderQty"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            </div>
        </div>
        <div class="form_box">
            <asp:GridView runat="server" ID="grdOrderBreakdown" ShowFooter="true" CssClass=" item_list"  AutoGenerateColumns="false"  width="100%"
                OnRowDataBound="grdOrderBreakdown_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Contract No." ItemStyle-Width="7%" HeaderStyle-Width="7%">
                        <ItemTemplate>
                            <asp:HiddenField ID="hiddenOrderDetailID" runat="server" Value='<%# Eval("OrderDetailID") %>' />
                            <asp:Label ID="Label1" runat="server" Text='<%#  Eval("ContractNumber")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Line Item no." ItemStyle-Width="7%" HeaderStyle-Width="7%">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#  Eval("LineItemNumber")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToInt32( Eval("Quantity")).ToString("N0")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Fabric 1">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text='<%# Eval("Fabric1") %>'></asp:Label>
                            <asp:Label ID="lbl20" runat="server" Text='<%# Eval("Fabric1Details") %>'></asp:Label><br />
                            <asp:Label ID="LabelFabric1" ForeColor="Black" Font-Size="Smaller" runat="server"
                                Text='<%# Eval("CCGSM1") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                             <table class=""><tr>
                        <td>
                        <asp:Label ID="lblCalcDays1" runat="server" Text="BULK LEAD TIME" style="font-weight:bold;"></asp:Label>
                        </td>
                        </tr></table>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BIH FABRIC 1" ItemStyle-CssClass="">
                        <ItemTemplate>
                            <asp:TextBox Width="100px" ID="txtBihFabric1" style="color:Black; background-color: #F2F2F2;" runat="server"  Text='<%# (Convert.ToDateTime(Eval("BIHFabric1")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric1"))).ToString("dd MMM yy (ddd)" )%>'
                                CssClass="date_style do-not-allow-typing BIH1" ></asp:TextBox>
                                <input id="hdnBihFabric1" runat="server" type="hidden" visible="true" class="BihFabric1" value='<%# (Convert.ToDateTime(Eval("BIHFabric1")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric1"))).ToString("dd MMM yy (ddd)" )%>' />   
                         
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCalcFabric1"  Width="100px" style="border:1px solid #000000; text-align:center;" MaxLength="3" CssClass="numeric-field-without-decimal-places CaclFabric1"  onchange="javascript:CalcFabricChange(this,'1')" runat="server"></asp:TextBox>
                             <input id="hdnCalcFabric1" runat="server" type="hidden" visible="true" class="HdnCalc1" value="" /> 
                           <input id="hdnBIHcalc1" runat="server" type="hidden" visible="true" class="hdnBIH1" value="" />                     
                        </FooterTemplate>
                    </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Fabric 2">
                        <ItemTemplate>
                            <asp:Label ID="Label13" ForeColor="Blue" runat="server" Text='<%# Eval("Fabric2") %>'></asp:Label>
                            <asp:Label ID="lbl120" runat="server" Text='<%# Eval("Fabric2Details") %>'></asp:Label><br />
                            <asp:Label ID="LabelFabric2" ForeColor="Black" Font-Size="Smaller" runat="server"
                                Text='<%# Eval("CCGSM2") %>'></asp:Label>
                        </ItemTemplate>                          
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BIH FABRIC 2" ItemStyle-CssClass="">
                        <ItemTemplate>
                            <asp:TextBox Width="100px" ID="txtBihFabric2" style="color:Black; background-color: #F2F2F2;" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIHFabric2")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric2"))).ToString("dd MMM yy (ddd)" )%>'
                                CssClass="date_style do-not-allow-typing BIH2"></asp:TextBox>
                                 <input id="hdnBihFabric2" runat="server" type="hidden" visible="true" class="BihFabric2" value='<%# (Convert.ToDateTime(Eval("BIHFabric2")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric2"))).ToString("dd MMM yy (ddd)" )%>' /> 
                         
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCalcFabric2" style="border:1px solid #000000; text-align:center;" Width="100px" MaxLength="3" CssClass="numeric-field-without-decimal-places CaclFabric2" onchange="javascript:CalcFabricChange(this,'2')" runat="server"></asp:TextBox>
                            <input id="hdnCalcFabric2" runat="server" type="hidden" visible="true" class="HdnCalc2" value="" />
                            <input id="hdnBIHcalc2" runat="server" type="hidden" visible="true" class="hdnBIH2" value="" />       
                        </FooterTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Fabric 3">
                        <ItemTemplate>
                            <asp:Label ID="Label31" ForeColor="Blue" runat="server" Text='<%# Eval("Fabric3") %>'></asp:Label>
                            <asp:Label ID="lbl201" runat="server" Text='<%# Eval("Fabric3Details") %>'></asp:Label><br />
                            <asp:Label ID="LabelFabric3" ForeColor="Black" Font-Size="Smaller" runat="server"
                                Text='<%# Eval("CCGSM3") %>'></asp:Label>
                        </ItemTemplate>
                    
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BIH FABRIC 3" ItemStyle-CssClass="">
                        <ItemTemplate>
                            <asp:TextBox Width="100px" ID="txtBihFabric3" style="color:Black; background-color: #F2F2F2;" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIHFabric3")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric3"))).ToString("dd MMM yy (ddd)" )%>'
                                CssClass="date_style do-not-allow-typing BIH3"></asp:TextBox>
                         <input id="hdnBihFabric3" runat="server" type="hidden" visible="true" class="BihFabric3" value='<%# (Convert.ToDateTime(Eval("BIHFabric3")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric3"))).ToString("dd MMM yy (ddd)" )%>' />   
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCalcFabric3" style="border:1px solid #000000; text-align:center;"  Width="100px" MaxLength="3" CssClass="numeric-field-without-decimal-places CaclFabric3" onchange="javascript:CalcFabricChange(this,'3')" runat="server"></asp:TextBox>
                            <input id="hdnCalcFabric3" runat="server" type="hidden" visible="true" class="HdnCalc3" value="" />    
                             <input id="hdnBIHcalc3" runat="server" type="hidden" visible="true" class="hdnBIH3" value="" />     
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Fabric 4">
                        <ItemTemplate>
                            <asp:Label ID="Label23" ForeColor="Blue" runat="server" Text='<%# Eval("Fabric4") %>'></asp:Label>
                            <asp:Label ID="lbl202" runat="server" Text='<%# Eval("Fabric4Details") %>'></asp:Label><br />
                            <asp:Label ID="LabelFabric4" ForeColor="Black" Font-Size="Smaller" runat="server"
                                Text='<%# Eval("CCGSM4") %>'></asp:Label>
                        </ItemTemplate>
                      
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="BIH FABRIC 4" ItemStyle-CssClass="">
                        <ItemTemplate>
                            <asp:TextBox Width="100px" ID="txtBihFabric4" style="color:Black; background-color: #F2F2F2;" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIHFabric4")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric4"))).ToString("dd MMM yy (ddd)" )%>'
                                CssClass="date_style do-not-allow-typing BIH4"></asp:TextBox>
                          <input id="hdnBihFabric4" runat="server" type="hidden" visible="true" class="BihFabric4" value='<%# (Convert.ToDateTime(Eval("BIHFabric4")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("BIHFabric4"))).ToString("dd MMM yy (ddd)" )%>' />   
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCalcFabric4" style="border:1px solid #000000; text-align:center;" Width="100px" MaxLength="3" CssClass="numeric-field-without-decimal-places CaclFabric4" onchange="javascript:CalcFabricChange(this,'4')" runat="server"></asp:TextBox>
                            <input id="hdnCalcFabric4" runat="server" type="hidden" visible="true" class="HdnCalc4" value="" />   
                             <input id="hdnBIHcalc4" runat="server" type="hidden" visible="true" class="hdnBIH4" value="" />      
                        </FooterTemplate>
                    </asp:TemplateField>
                                        
                    <asp:TemplateField HeaderText="PCD" ItemStyle-CssClass="date_style">
                        <ItemTemplate>                           
                            <asp:TextBox Width="100px" ID="txtPCD" style="color:Black; background-color: #F2F2F2; pointer-events: none;" runat="server" Text='<%# (Convert.ToDateTime(Eval("PCDDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("PCDDate"))).ToString("dd MMM yy (ddd)" )%>' CssClass="PCDdate"></asp:TextBox>       
                            <input id="hdnPCD" runat="server" type="hidden" visible="true" class="PCDbase" value='<%# (Convert.ToDateTime(Eval("PCDDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("PCDDate"))).ToString("dd MMM yy (ddd)" )%>' />                         
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ex Factory" ItemStyle-CssClass="date_style">
                        <ItemTemplate>
                            <asp:Label Width="100px" ID="Label9" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
                            <input id="hdnExFactory" runat="server" type="hidden" visible="true" class="ExFactory" value='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("ExFactory"))).ToString("dd MMM yy (ddd)" )%>' />                         
                        </ItemTemplate>
                    </asp:TemplateField>              
                   
                  
                   
                </Columns>
                
            </asp:GridView>
        </div>
        <div style="width:100%; padding-bottom:15px;">
            <table class="item_list_ravi" style="border:1px solid #000000; text-transform:capitalize !important;" width="100%" cellpadding="3" cellspacing="0">
                <tbody>
                    <tr>                      
                        <td style="text-align: left; background-color:White;">
                        <strong>Optimum Prod Time : &nbsp;</strong>
                        <asp:Label ID="lblBasicBarrierDays" Font-Bold="true" Font-Size="11px" CssClass="blue-text basicDays" runat="server" Text=""></asp:Label>
                        &nbsp; &nbsp;
                        <strong> Optimum CMT : </strong> <font 'color:blue'> Rs. </font>                           
                            <asp:Label ID="lblBasicCMT" Font-Bold="true" Font-Size="11px" CssClass="blue-text basicCMT" runat="server" Text=""></asp:Label>                           
                           
                            &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblLeadTimeMsg"  Font-Size="11px" CssClass="lblLeadTimeMessage" runat="server" Text=""></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblLeadTime" Font-Bold="true"  Font-Size="11px" CssClass="blue-text clsLeadTime" runat="server" Text=""></asp:Label>
                             &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblCMTmsg" Font-Size="11px" CssClass="lblCMTmessage" runat="server" Text=""></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblCalcCMT" Font-Size="11px" Font-Bold="true" CssClass="blue-text clsCalcCMT" runat="server" Text=""></asp:Label>
                            &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblProdLossMsg"  Font-Size="11px" CssClass="lblLossMessage" runat="server" Text=""></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblProdLoss"  Font-Size="11px" Font-Bold="true" ForeColor="Red" CssClass="clsProdLoss" runat="server" Text=""></asp:Label>

                             <asp:HiddenField ID="hdnBarrierDaysCMT" Value="0" runat="server" />                           
                            <asp:HiddenField ID="hdnCalcBarrierDays" Value="0" runat="server" />

                        </td>
                        
                    </tr>
                </tbody>
            </table>
            </div>
        <div class="form_box">
            <table class=" item_list" border="1" width="100%">
                <tbody>
                    <tr>
                        <th class="form_small_heading" width="50%">
                           <strong>Fabric</strong>                         
                           
                        </th>
                        <th class="form_small_heading" width="50%">
                            <strong>Accessories</strong>
                        </th>                     
                       <%-- <td class="form_small_heading" width="28%">
                            <strong style="color:Black;">Merchandising</strong>
                        </td>--%>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtFabric" TextMode="MultiLine" Width="99%" Height="100px"
                                BorderStyle="None"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAccessories" TextMode="MultiLine" Width="99%"
                                Height="100px" BorderStyle="None"></asp:TextBox>
                        </td>
                   
                        <%--<td>
                            <asp:TextBox runat="server" ID="txtMerchandising" TextMode="MultiLine" Width="99%"
                                Height="100px" BorderStyle="None"></asp:TextBox>
                        </td>--%>
                    </tr>
                    <tr>
                        <th
                            <asp:Label runat="server" ID="lblFabricSignature">Signature</asp:Label>
                        </th>
                        <th>
                            <asp:Label runat="server" ID="lblAccessoriesSignature">Signature</asp:Label>
                        </th>
                       
                       <%-- <td>
                            <asp:Label runat="server" ID="lblMerchandisingSignature">Signature</asp:Label>
                        </td>--%>
                    </tr>
                    <tr>
                        <td> 
                        <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                        <td align="left">
                        <asp:Label ID="lblFabricMsg" ForeColor="Black" Font-Bold="true" Text="We have noted the above loss and regret fully accept."  runat="server" ></asp:Label>
                        </td>
                        <td align="right">
                         APPROVED BY FABRIC MGR
                            <asp:CheckBox ID="chkboxFabricMgr" runat="server" />
                            <asp:HiddenField ID="hiddenFab" runat="server" />    
                        </td></tr></table>         
                        </td>
                        <td>
                            APPROVED BY ACCESSORIES MGR
                            <asp:CheckBox ID="chkboxAccessoriesMgr" runat="server" />
                            <asp:HiddenField ID="hiddenAcc" runat="server" />
                        </td>                      
                       <%-- <td>
                            APPROVED BY MERCHANDISING MGR
                            <asp:CheckBox ID="chkboxMerchandisingMgr" runat="server" />
                            <asp:HiddenField ID="hiddenMerch" runat="server" />
                        </td>--%>
                    </tr>
                    <tr>
                        <th colspan="2" align="center" class="form_small_heading">
                            <strong>Comments</strong>
                        </th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox runat="server" ID="txtIkandiComments" Width="99%" TextMode="MultiLine"
                                Height="100px" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.LIMITATIONS_FORM_IKANDI_COMMENTS)? "":"do-not-allow-typing" %>'></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div style="padding-bottom:10px;">
        <asp:Label ID="lblOB_RiskNotDone" ForeColor="Red" runat="server" Text=""></asp:Label>
    </div>
    <div class="form_buttom">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit"  OnClick="btnSubmit_Click" CssClass="submit" />
        <input type="button" id="btnPrint" class="print da_submit_button" value="Print" onclick="return PrintPDF();" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Order Limitation information have been saved into the system successfully!
            <br />
            <a id="A1" href="~\Internal\OrderProcessing\ManageOrders.aspx" runat="server">Click
                here</a> to Manage Orders.
        </div>
    </div>
</asp:Panel>


