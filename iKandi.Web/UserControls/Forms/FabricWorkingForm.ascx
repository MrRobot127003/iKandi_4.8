<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricWorkingForm.ascx.cs"
    Inherits="iKandi.Web.FabricForm" %>
<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var FabricProxy = new ServiceProxy(serviceUrl);


    var txtTotalFabric1;
    var txtTotalFabric2;
    var txtTotalFabric3;
    var txtTotalFabric4;
    var txtAverageFabric1;
    var txtAverageFabric2;
    var txtAverageFabric3;
    var txtAverageFabric4;
    var txtTotalAll;
    var txtTotal;
    var txtTotalGreige;
    var quantity;
    var lblQty;
    var cuttingWastageFabric1;
    var cuttingWastageFabric2;
    var cuttingWastageFabric3;
    var cuttingWastageFabric4;
    var shrinkageWastageFabric1;
    var shrinkageWastageFabric2;
    var shrinkageWastageFabric3;
    var shrinkageWastageFabric4;
    var ddlAvgUnit1ClientID = '<%=ddlAvgUnit1.ClientID %>';
    var ddlAvgUnit2ClientID = '<%=ddlAvgUnit2.ClientID %>';
    var ddlAvgUnit3ClientID = '<%=ddlAvgUnit3.ClientID %>';
    var ddlAvgUnit4ClientID = '<%=ddlAvgUnit4.ClientID %>';

    var hdnPathClientId = '<%=hdnPath.ClientID %>';

    var hdnWastageFabric1 = '<%=hdnWastageFabric1.ClientID %>';
    var hdnWastageFabric2 = '<%=hdnWastageFabric2.ClientID %>';
    var hdnWastageFabric3 = '<%=hdnWastageFabric3.ClientID %>';
    var hdnWastageFabric4 = '<%=hdnWastageFabric4.ClientID %>';

    var txtFinalQtyFabric1;
    var txtFinalQtyFabric2;
    var txtFinalQtyFabric3;
    var txtFinalQtyFabric4;
    var txtFinalFabric1;
    var txtFinalFabric2;
    var txtFinalFabric3;
    var txtFinalFabric4;
    var detailFabric1;
    var detailFabric2;
    var detailFabric3;
    var detailFabric4;
    var isExpanded = false;

     

     function Calc(flag,txtAvgFab, txtTotalFab, txtTotal, txtTotalGreige, txtFinalOrder, txtFinalQty, fabDetails, unit) {
       //debugger;
       var orderedQty = "&nbsp;";
       var FabricQuantity;
        for (var i = 0; i < quantity.length; i++) {

            var total = 0;
            var Roundtotal = 0;
            var avg = txtAvgFab[i].value;

            if (avg == "")
                avg = 0;

           
                   
            Roundtotal = parseFloat(avg) * (parseFloat((quantity[i].innerHTML == '') ? 0 : quantity[i].innerHTML));
            total=Math.round(Roundtotal) //Math.round((Roundtotal / 2) * 100) / 100 //RoundUp(Roundtotal,2);
            txtTotalFab[i].value =total// Math.round(total);
            CalculateQuantity(txtTotalFab, txtTotal, txtTotalGreige);
            if (flag == 1) {
                FabricQuantity = $("[id$='" + i + "_txtFabric1Quantity']");
                AvgUnit = $(".AvgUnit1").val();
            }
            if (flag == 2) {
                FabricQuantity = $("[id$='" + i + "_txtFabric2Quantity']");
                AvgUnit = $(".AvgUnit2").val();
            }
            if (flag == 3) {
                FabricQuantity = $("[id$='" + i + "_txtFabric3Quantity']");
                AvgUnit = $(".AvgUnit3").val();
            }
            if (flag == 4) {
                FabricQuantity = $("[id$='" + i + "_txtFabric4Quantity']");
                AvgUnit = $(".AvgUnit4").val();
            }

            finalQty = Math.round((parseFloat(FabricQuantity.val()) / parseFloat(txtTotalGreige.val())) * parseFloat(txtFinalOrder.val()))

            orderedQty = orderedQty + fabDetails[i].innerText + " order qty " + finalQty + " " + unit + "<br />";

        }
        //$(txtFinalQty.html(" Colorwise order qty breakdown " + "<br />" + orderedQty + "<br />"));
        
    }


     // comment by Ravi for hide wastage admin work
//    function Calc(flag,txtAvgFab, txtTotalFab, txtTotal, txtTotalGreige, txtFinalOrder, txtFinalQty, fabDetails, unit) {
//       //debugger;
//       var orderedQty = "&nbsp;";
//       var FabricQuantity;
//       var AvgUnit;
//        for (var i = 0; i < quantity.length; i++) {

//            var total = 0;
//            var avg = txtAvgFab[i].value;

//            if (avg == "")
//                avg = 0;

//           
//                   
//            total = parseFloat(avg) * (parseFloat((quantity[i].innerHTML == '') ? 0 : quantity[i].innerHTML));
//            txtTotalFab[i].value = Math.round(total);
//            CalculateQuantity(txtTotalFab, txtTotal, txtTotalGreige);
//            //debugger;
//            if (flag == 1) {
//                FabricQuantity = $("[id$='" + i + "_txtFabric1Quantity']");
//                AvgUnit = $(".AvgUnit1").val();
//            }
//            if (flag == 2) {
//                FabricQuantity = $("[id$='" + i + "_txtFabric2Quantity']");
//                AvgUnit = $(".AvgUnit2").val();
//            }
//            if (flag == 3) {
//                FabricQuantity = $("[id$='" + i + "_txtFabric3Quantity']");
//                AvgUnit = $(".AvgUnit3").val();
//            }
//            if (flag == 4) {
//                FabricQuantity = $("[id$='" + i + "_txtFabric4Quantity']");
//                AvgUnit = $(".AvgUnit4").val();
//            }

//            finalQty = Math.round((parseFloat(FabricQuantity.val()) / parseFloat(txtTotalGreige.val())) * parseFloat(txtFinalOrder.val()))

//            orderedQty = orderedQty + fabDetails[i].innerText + " order qty " + finalQty + " " + unit + "<br />";

//        }
//        //debugger;
//        var Quantity = txtTotal.val();

//        FabricProxy.invoke("GetWstgByFabricQuantity", { Quantity: Quantity, AvgUnit: AvgUnit },
//                                                            function (result) {
//                                                                //debugger;
//                                                                if (flag == 1) {
//                                                                    cuttingWastageFabric1.val(result[0]);
//                                                                    $("#" + hdnWastageFabric1).val(result[0]);
//                                                                }
//                                                                if (flag == 2) {
//                                                                    cuttingWastageFabric2.val(result[0]);
//                                                                    $("#" + hdnWastageFabric2).val(result[0]);
//                                                                }
//                                                                if (flag == 3) {
//                                                                    cuttingWastageFabric3.val(result[0]);
//                                                                    $("#" + hdnWastageFabric3).val(result[0]);
//                                                                }
//                                                                if (flag == 4) {
//                                                                    cuttingWastageFabric4.val(result[0]);
//                                                                    $("#" + hdnWastageFabric4).val(result[0]);
//                                                                }


//                                                            },
//                                                            onPageError, false, false);

//        CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));

//        $(txtFinalQty.html(" Colorwise order qty breakdown " + "<br />" + orderedQty + "<br />"));
//        
//    }
// End comment by Ravi for hide wastage admin work
    var globalSeq=0;
    function ChangeFabricAvg(obj, Seq) {
    globalSeq=Seq;
        //debugger;
        var FabricAverageCut = obj.value;
        var CostingAvg = '';
        var OrderId = <%=Request.Params["OrderID"] %>;
        if (FabricAverageCut != '') {
        //debugger;
        FabricProxy.invoke("GetCostingAvg", { OrderId: OrderId, SeqNo: Seq },
                                                            function (result) {
                                                                //debugger;                                                                
                                                                    CostingAvg = result[0];                                                            
        

                if(CostingAvg != "0")
                {
                //debugger;
                    if (parseFloat(FabricAverageCut) > parseFloat(CostingAvg)) {
                        alert('This Avg Value can not be greater than Costing Avg ' + CostingAvg + '');
                        obj.value = CostingAvg;
                        //return false;
                                }
                  }                            
            //debugger;
            if(Seq == 1)
            {
            Calc(1, txtAverageFabric1,txtTotalFabric1, $('input.total1', '#main_content'), $('input.totalGreige1', '#main_content'), $('.fabric-final1', '#main_content'), $('.final-qty-fabric1', '#main_content'), $('.details-fabric1', '#main_content'), $("#" + '<%=lblUnit1.ClientID %>').html());
            }
            if(Seq == 2)
            {
            Calc(2,txtAverageFabric2, txtTotalFabric2, $('input.total2', '#main_content'), $('input.totalGreige2', '#main_content'), $('.fabric-final2', '#main_content'),$('.final-qty-fabric2', '#main_content'), $('.details-fabric2', '#main_content'), $("#" + '<%=lblUnit2.ClientID %>').html());
            }
            if(Seq == 3)
            {
            Calc(3,txtAverageFabric3, txtTotalFabric3, $('input.total3', '#main_content'), $('input.totalGreige3', '#main_content'), $('.fabric-final3', '#main_content'),$('.final-qty-fabric3', '#main_content'), $('.details-fabric3', '#main_content'), $("#" + '<%=lblUnit3.ClientID %>').html());
            }
            if(Seq == 4)
            {
            Calc(4,txtAverageFabric4, txtTotalFabric4, $('input.total4', '#main_content'), $('input.totalGreige4', '#main_content'), $('.fabric-final4', '#main_content'),$('.final-qty-fabric4', '#main_content'),  $('.details-fabric4', '#main_content'), $("#" + '<%=lblUnit4.ClientID %>').html());
            }

             },
                                                            onPageError, false, false);
           } 

        }
       


    $(function () {
    //debugger;
        $(".loadingimage").hide();
        lblQty = $("[id$='_lblQuantity']").html();

        detailFabric1 = $('span.details-fabric1', '#main_content');
        detailFabric2 = $('span.details-fabric2', '#main_content');
        detailFabric3 = $('span.details-fabric3', '#main_content');
        detailFabric4 = $('span.details-fabric4', '#main_content');

        txtFinalFabric1 = $('.fabric-final1', '#main_content');
        txtFinalFabric2 = $('.fabric-final2', '#main_content');
        txtFinalFabric3 = $('.fabric-final3', '#main_content');
        txtFinalFabric4 = $('.fabric-final4', '#main_content');

        total1 = $('.total1', '#main_content');
        total2 = $('.total2', '#main_content');
        total3 = $('.total3', '#main_content');
        total4 = $('.total4', '#main_content');

        txtFinalQtyFabric1 = $('.final-qty-fabric1', '#main_content');
        txtFinalQtyFabric2 = $('.final-qty-fabric2', '#main_content');
        txtFinalQtyFabric3 = $('.final-qty-fabric3', '#main_content');
        txtFinalQtyFabric4 = $('.final-qty-fabric4', '#main_content');

        txtTotalFabric1 = $('input.totalQtyFabric1', '#main_content');
        txtTotalFabric2 = $('input.totalQtyFabric2', '#main_content');
        txtTotalFabric3 = $('input.totalQtyFabric3', '#main_content');
        txtTotalFabric4 = $('input.totalQtyFabric4', '#main_content');

       
        txtAverageFabric1 = $('input.averageFabric1', '#main_content');
        txtAverageFabric2 = $('input.averageFabric2', '#main_content');
        txtAverageFabric3 = $('input.averageFabric3', '#main_content');
        txtAverageFabric4 = $('input.averageFabric4', '#main_content');

        cuttingWastageFabric1 = $('input.cutting-wastage-fabric1', '#main_content');
        cuttingWastageFabric2 = $('input.cutting-wastage-fabric2', '#main_content');
        cuttingWastageFabric3 = $('input.cutting-wastage-fabric3', '#main_content');
        cuttingWastageFabric4 = $('input.cutting-wastage-fabric4', '#main_content');

        shrinkageWastageFabric1 = $('input.shrinkage-wastage-fabric1', '#main_content');
        shrinkageWastageFabric2 = $('input.shrinkage-wastage-fabric2', '#main_content');
        shrinkageWastageFabric3 = $('input.shrinkage-wastage-fabric3', '#main_content');
        shrinkageWastageFabric4 = $('input.shrinkage-wastage-fabric4', '#main_content');

        if (cuttingWastageFabric1.val() == '')
            cuttingWastageFabric1.val(0);

        if (cuttingWastageFabric2.val() == '')
            cuttingWastageFabric2.val(0);

        if (cuttingWastageFabric3.val() == '')
            cuttingWastageFabric3.val(0);

        if (cuttingWastageFabric4.val() == '')
            cuttingWastageFabric4.val(0);

        if (shrinkageWastageFabric1.val() == '')
            shrinkageWastageFabric1.val(0);

        if (shrinkageWastageFabric2.val() == '')
            shrinkageWastageFabric2.val(0);

        if (shrinkageWastageFabric3.val() == '')
            shrinkageWastageFabric3.val(0);

        if (shrinkageWastageFabric4.val() == '')
            shrinkageWastageFabric4.val(0);

        if (txtTotalFabric1.val() == '')
            txtTotalFabric1.val(0);

        if (txtTotalFabric2.val() == '')
            txtTotalFabric2.val(0);

        if (txtTotalFabric3.val() == '')
            txtTotalFabric3.val(0);

        if (txtTotalFabric4.val() == '')
            txtTotalFabric4.val(0);

        if (txtAverageFabric1.val() == '')
            txtAverageFabric1.val(0);

        if (txtAverageFabric2.val() == '')
            txtAverageFabric2.val(0);

        if (txtAverageFabric3.val() == '')
            txtAverageFabric3.val(0);

        if (txtAverageFabric4.val() == '')
            txtAverageFabric4.val(0);

        if (!($("[id$='_lblFabric1']").html())) {
            $('input.averageFabric1', '#main_content').each(function ()
            { $('input.averageFabric1', '#main_content').hide(); });
        }

        if (!($("[id$='_lblFabric2']").html())) {
            $('input.averageFabric2', '#main_content').each(function ()
            { $('input.averageFabric2', '#main_content').hide(); });
        }

        if (!($("[id$='_lblFabric3']").html())) {
            $('input.averageFabric3', '#main_content').each(function ()
            { $('input.averageFabric3', '#main_content').hide(); });
        }

        if (!($("[id$='_lblFabric4']").html())) {
            $('input.averageFabric4', '#main_content').each(function ()
            { $('input.averageFabric4', '#main_content').hide(); });
        }


        quantity = $('span.quantity-for-calculation', '#main_content');
        //debugger;


        for (var i = 1; i <= 4; i++) {
            var totalQtyFabric = $('.totalQtyFabric' + i);
            txtTotal = $('.total' + i);

            txtTotalGreige = $('.totalGreige' + i);
            CalculateQuantity(totalQtyFabric, txtTotal, txtTotalGreige);

            //Added By Ashish on 2/1/2014
            calculateFabricAvg(totalQtyFabric,i);

            OrdAverage=$('.FabricOrdAverage' + i);
            CalculateOrdAvgQuantity(totalQtyFabric,OrdAverage,i);
           //END

        }
        CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        CalculateFinalQuantity(1, $('.fabric-final1', '#main_content'), $('.total1', '#main_content'), $('.final-qty-fabric1', '#main_content'), $('.totalQtyFabric1', '#main_content'), $('.details-fabric1', '#main_content'), $("#" + '<%=lblUnit1.ClientID %>').html());
        CalculateFinalQuantity(2, $('.fabric-final2', '#main_content'), $('.total2', '#main_content'), $('.final-qty-fabric2', '#main_content'), $('.totalQtyFabric2', '#main_content'), $('.details-fabric2', '#main_content'), $("#" + '<%=lblUnit2.ClientID %>').html());
        CalculateFinalQuantity(3, $('.fabric-final3', '#main_content'), $('.total3', '#main_content'), $('.final-qty-fabric3', '#main_content'), $('.totalQtyFabric3', '#main_content'), $('.details-fabric3', '#main_content'), $("#" + '<%=lblUnit3.ClientID %>').html());
        CalculateFinalQuantity(4, $('.fabric-final4', '#main_content'), $('.total4', '#main_content'), $('.final-qty-fabric4', '#main_content'), $('.totalQtyFabric4', '#main_content'), $('.details-fabric4', '#main_content'), $("#" + '<%=lblUnit4.ClientID %>').html());
        //debugger;
        // comment by Ravi for hide wastage admin work

//        var AvgUnit1 = $(".AvgUnit1").val();
//        var AvgUnit2 = $(".AvgUnit2").val();
//        var AvgUnit3 = $(".AvgUnit3").val();
//        var AvgUnit4 = $(".AvgUnit4").val();

//        var Quantity1 = $(".total1").val();
//        var Quantity2 = $(".total2").val();
//        var Quantity3 = $(".total3").val();
//        var Quantity4 = $(".total4").val();

//        FabricProxy.invoke("GetAllWstgByFabricQuantity", { Quantity1: Quantity1, Quantity2: Quantity2, Quantity3: Quantity3, Quantity4: Quantity4, AvgUnit1: AvgUnit1, AvgUnit2: AvgUnit2, AvgUnit3: AvgUnit3, AvgUnit4: AvgUnit4 },
//                                                            function (result) {
//                                                                //debugger;
//                                                                $("#" + hdnWastageFabric1).val(result[0]);
//                                                                $("#" + hdnWastageFabric2).val(result[1]);
//                                                                $("#" + hdnWastageFabric3).val(result[2]);
//                                                                $("#" + hdnWastageFabric4).val(result[3]);
//                                                            },
//                                                            onPageError, false, false);



// End comment by Ravi for hide wastage admin work

        $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content').change(function () {
            //debugger;
            // comment by Ravi for hide wastage admin work
//            var Wastage = $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content');
//            Wastage = parseFloat(Wastage.val());
//            var hdnWastage = parseFloat($("#" + hdnWastageFabric1).val());
//            if (hdnWastage != 0) {
//                if (Wastage > hdnWastage) {
//                    alert('This Wastage value can not be greater than Admin value ' + hdnWastage + ' ');
//                    $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content').val(hdnWastage);
//                }
//            }
// End comment by Ravi for hide wastage admin work
            //debugger;
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content').change(function () {
            //debugger;
              // comment by Ravi for hide wastage admin work
//            var Wastage = $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content');
//            Wastage = parseFloat(Wastage.val());
//            var hdnWastage = parseFloat($("#" + hdnWastageFabric2).val());
//            if (hdnWastage != 0) {
//                if (Wastage > hdnWastage) {
//                    alert('This Wastage value can not be greater than Admin value ' + hdnWastage + ' ');
//                    $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content').val(hdnWastage);
//                }
//            }
            //debugger;
            // End comment by Ravi for hide wastage admin work
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content').change(function () {
          // comment by Ravi for hide wastage admin work
//            var Wastage = $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content');
//            Wastage = parseFloat(Wastage.val());
//            var hdnWastage = parseFloat($("#" + hdnWastageFabric3).val());
//            if (hdnWastage != 0) {
//                if (Wastage > hdnWastage) {
//                    alert('This Wastage value can not be greater than Admin value ' + hdnWastage + ' ');
//                    $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content').val(hdnWastage);
//                }
//            }
// End comment by Ravi for hide wastage admin work
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content').change(function () {
         // comment by Ravi for hide wastage admin work
//            var Wastage = $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content');
//            Wastage = parseFloat(Wastage.val());
//            var hdnWastage = parseFloat($("#" + hdnWastageFabric4).val());
//            if (hdnWastage != 0) {
//                if (Wastage > hdnWastage) {
//                    alert('This Wastage value can not be greater than Admin value ' + hdnWastage + ' ');
//                    $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content').val(hdnWastage);
//                }
//            }
// End comment by Ravi for hide wastage admin work
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content').change(function () {
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content').change(function () {
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content').change(function () {
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content').change(function () {
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });


        $("#" + ddlAvgUnit1ClientID).change(function () {
            //debugger;
            var index = this.selectedIndex;
            if ((this.options[index].value) == 1) {
                $("[id$='_lblUnit1']", "#main_content").html("KG");
            }
            else if ((this.options[index].value) == 2) {
                $("[id$='_lblUnit1']", "#main_content").html("MTRS");
            }
            var AvgUnit = $(".AvgUnit1").val();
            var Quantity = $(".total1").val();

            FabricProxy.invoke("GetWstgByFabricQuantity", { Quantity: Quantity, AvgUnit: AvgUnit },
                                                            function (result) {
                                                                //debugger;
                                                                cuttingWastageFabric1.val(result[0]);
                                                                $("#" + hdnWastageFabric1).val(result[0]);
                                                            },
                                                            onPageError, false, false);
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $("#" + ddlAvgUnit2ClientID).change(function () {
            var index = this.selectedIndex;
            if ((this.options[index].value) == 1) {
                $("[id$='_lblUnit2']", "#main_content").html("KG");
            }
            else if ((this.options[index].value) == 2) {
                $("[id$='_lblUnit2']", "#main_content").html("MTRS");
            }

            var AvgUnit = $(".AvgUnit2").val();
            var Quantity = $(".total2").val();

            FabricProxy.invoke("GetWstgByFabricQuantity", { Quantity: Quantity, AvgUnit: AvgUnit },
                                                            function (result) {
                                                                //debugger;
                                                                cuttingWastageFabric2.val(result[0]);
                                                                $("#" + hdnWastageFabric2).val(result[0]);
                                                            },
                                                            onPageError, false, false);
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $("#" + ddlAvgUnit3ClientID).change(function () {
            var index = this.selectedIndex;
            if ((this.options[index].value) == 1) {
                $("[id$='_lblUnit3']", "#main_content").html("KG");
            }
            else if ((this.options[index].value) == 2) {
                $("[id$='_lblUnit3']", "#main_content").html("MTRS");
            }

            var AvgUnit = $(".AvgUnit3").val();
            var Quantity = $(".total3").val();

            FabricProxy.invoke("GetWstgByFabricQuantity", { Quantity: Quantity, AvgUnit: AvgUnit },
                                                            function (result) {
                                                                //debugger;
                                                                cuttingWastageFabric3.val(result[0]);
                                                                $("#" + hdnWastageFabric3).val(result[0]);
                                                            },
                                                            onPageError, false, false);
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $("#" + ddlAvgUnit4ClientID).change(function () {
            var index = this.selectedIndex;
            if ((this.options[index].value) == 1) {
                $("[id$='_lblUnit4']", "#main_content").html("KG");
            }
            else if ((this.options[index].value) == 2) {
                $("[id$='_lblUnit4']", "#main_content").html("MTRS");
            }

            var AvgUnit = $(".AvgUnit4").val();
            var Quantity = $(".total4").val();

            FabricProxy.invoke("GetWstgByFabricQuantity", { Quantity: Quantity, AvgUnit: AvgUnit },
                                                            function (result) {
                                                                //debugger;
                                                                cuttingWastageFabric4.val(result[0]);
                                                                $("#" + hdnWastageFabric4).val(result[0]);
                                                            },
                                                            onPageError, false, false);
            CalculateCuttingPer($('#<%=txtTotalFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalFabric4.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric1.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric2.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric3.ClientID %>', '#main_content'), $('#<%=txtCuttingWastageFabric4.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric1.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric2.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric3.ClientID %>', '#main_content'), $('#<%=txtShrinkageFabric4.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric1.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric2.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric3.ClientID %>', '#main_content'), $('#<%=txtTotalRequirementGreigeFabric4.ClientID %>', '#main_content'));
        });

        $('.fabric-final1').change(function (e) {
            // debugger;
            CalculateFinalQuantity(1, $('.fabric-final1', '#main_content'), $('.total1', '#main_content'), $('.final-qty-fabric1', '#main_content'), $('.totalQtyFabric1', '#main_content'), $('.details-fabric1', '#main_content'), $("#" + '<%=lblUnit1.ClientID %>').html());
        });

        $('.fabric-final2').change(function (e) {
            CalculateFinalQuantity(2, $('.fabric-final2', '#main_content'), $('.total2', '#main_content'), $('.final-qty-fabric2', '#main_content'), $('.totalQtyFabric2', '#main_content'), $('.details-fabric2', '#main_content'), $("#" + '<%=lblUnit2.ClientID %>').html());
        });

        $('.fabric-final3').change(function (e) {
            CalculateFinalQuantity(3, $('.fabric-final3', '#main_content'), $('.total3', '#main_content'), $('.final-qty-fabric3', '#main_content'), $('.totalQtyFabric3', '#main_content'), $('.details-fabric3', '#main_content'), $("#" + '<%=lblUnit3.ClientID %>').html());
        });

        $('.fabric-final4').change(function (e) {
            CalculateFinalQuantity(4, $('.fabric-final4', '#main_content'), $('.total4', '#main_content'), $('.final-qty-fabric4', '#main_content'), $('.totalQtyFabric4', '#main_content'), $('.details-fabric4', '#main_content'), $("#" + '<%=lblUnit4.ClientID %>').html());
        });

   $('.myClass1').val("");
  $('.myClass2').val("");
  $('.myClass3').val("");
  $('.myClass4').val("");

   $('.OrdMyClass1').val("");
  $('.OrdMyClass2').val("");
  $('.OrdMyClass3').val("");
  $('.OrdMyClass4').val("");

  $('.myClassTotal').val("");

    });

    function CalculateCuttingPer(txtTotFab1, txtTotFab2, txtTotFab3, txtTotFab4, txtCuttingWastage1, txtCuttingWastage2, txtCuttingWastage3, txtCuttingWastage4, txtShrinkage1, txtShrinkage2, txtShrinkage3, txtShrinkage4, txtGreigeFab1, txtGreigeFab2, txtGreigeFab3, txtGreigeFab4) {
        //debugger;

        var perWastage1 = (parseFloat(txtTotFab1.val())) * (parseFloat(txtCuttingWastage1.val())) * (1 / 100);

        var perShrinkage1 = (parseFloat(txtTotFab1.val())) * (parseFloat(txtShrinkage1.val())) * (1 / 100);

        var perWastage2 = (parseFloat(txtTotFab2.val())) * (parseFloat(txtCuttingWastage2.val())) * (1 / 100);
        var perShrinkage2 = (parseFloat(txtTotFab2.val())) * (parseFloat(txtShrinkage2.val())) * (1 / 100);

        var perWastage3 = (parseFloat(txtTotFab3.val())) * (parseFloat(txtCuttingWastage3.val())) * (1 / 100);
        var perShrinkage3 = (parseFloat(txtTotFab3.val())) * (parseFloat(txtShrinkage3.val())) * (1 / 100);

        var perWastage4 = (parseFloat(txtTotFab4.val())) * (parseFloat(txtCuttingWastage4.val())) * (1 / 100);
        var perShrinkage4 = (parseFloat(txtTotFab4.val())) * (parseFloat(txtShrinkage4.val())) * (1 / 100);
      

        txtGreigeFab1.val(Math.round((parseFloat(txtTotFab1.val())) + perWastage1 + perShrinkage1));

        txtGreigeFab2.val(Math.round((parseFloat(txtTotFab2.val())) + perWastage2 + perShrinkage2));

        txtGreigeFab3.val(Math.round((parseFloat(txtTotFab3.val())) + perWastage3 + perShrinkage3));

        txtGreigeFab4.val(Math.round((parseFloat(txtTotFab4.val())) + perWastage4 + perShrinkage4));

    }

    function CalculateQuantity(txt, txtTotal, txtTotalGreige) {
        var total = 0;
       
        

      
        for (var i = 0; i < txt.length; i++) {

            var lblQty =  $("[id$='"+i+"_lblQuantity']").html();
            
            if (txt[i].value == '' || isNaN(txt[i].value))
                txt[i].value = 0;

            total = total + parseFloat(txt[i].value);
          

        } 
//         added abhishek on 4/5/2016
         var sum=0;
       if(globalSeq==1)
       {
       sum=parseFloat(cuttingWastageFabric1.val())+parseFloat(shrinkageWastageFabric1.val());

       }
         if(globalSeq==2)
       {
      sum=parseFloat(cuttingWastageFabric2.val())+parseFloat(shrinkageWastageFabric2.val());

       }
        if(globalSeq==3)
       {
      sum=parseFloat(cuttingWastageFabric3.val())+parseFloat(shrinkageWastageFabric3.val());

       }
        if(globalSeq==4)
       {
      sum=parseFloat(cuttingWastageFabric4.val())+parseFloat(shrinkageWastageFabric4.val());

       }

      // alert(sum);
        total = Math.round(total);

        total_gerieg=total+Math.round(total*sum/100);

        txtTotal.val(total);
        txtTotalGreige.val(total_gerieg);

        txtTotal.change();
        txtTotalGreige.change();      

    }
    //end 

  //Added By Ashish on 5/1/2014
    function RoundUp(value, places) {
        var multiplier = Math.pow(10, places);

        return (Math.round(value * multiplier) / multiplier);
    }
    //END

    //Added By Ashish on 2/1/2014
    function calculateFabricAvg(txt,flag)
    {
      //debugger; //FabricOrdAverage1
      var lblQty =0;
      var lblfabricAvg=0;
      var fabricAvg=0;
      var finalAvgQty;
      var AvgQty=0;
      for (var i = 0; i < txt.length; i++) {

      lblQty =  $("[id$='"+i+"_lblQuantity']").html()
      lblfabricAvg =$("[id$='"+i+"_lblFabric"+flag+"Average']").html(); 
      if(lblfabricAvg!== null)
      {
      fabricAvg =$("[id$='"+i+"_txtFabric"+flag+"Average']").val();
      }
      else{
      fabricAvg =$("[id$='"+i+"_lblFabric"+flag+"Average']").html();
      }
     //debugger;

      if(fabricAvg===null)
      {
      fabricAvg=0;
      }

      AvgQty=(parseFloat(lblQty)*parseFloat(fabricAvg));
      finalAvgQty=Math.round(AvgQty); //Math.round((AvgQty / 2) * 100) / 100 //RoundUp(AvgQty,2)

     // finalAvgQty=RoundUp(AvgQty,2)
      if(finalAvgQty!=0){
      $("[id$='"+i+"_txtFabric"+flag+"OrdAverage']").val(parseInt(finalAvgQty));
      }
      else{
      //$("[id$='"+i+"_txtFabric"+flag+"OrdAverage']").val('');
      if(flag==1)
        {
          // $("[id$='"+i+"_txtFabric1OrdAverage']").addClass('myClass1');
           $("[id$='"+i+"_txtFabric"+flag+"OrdAverage']").addClass('myClass1')

        }
         if(flag==2)
        {
            $("[id$='"+i+"_txtFabric"+flag+"OrdAverage']").addClass('myClass2');
           // $('.myClass2').val("");
        }
         if(flag==3)
        {
            $("[id$='"+i+"_txtFabric"+flag+"OrdAverage']").addClass('myClass3');
            //$('.myClass3').val("");
        }
         if(flag==4)
        {
            $("[id$='"+i+"_txtFabric"+flag+"OrdAverage']").addClass('myClass4');
           // $('.myClass4').val("");
        }


       }
       
      }
  
  }

//  END
//Added By Ashish on 5/1/2014
      function CalculateOrdAvgQuantity(txt,Average,flag) {
        var total = 0;
        //debugger; // FabricOrdAverage1
        for (var i = 0; i < txt.length; i++) {
       
        if (Average[i].value == '' || isNaN(Average[i].value))
            Average[i].value=0;

            total=total+parseFloat(Average[i].value);
            }

            var wastage=$('.cutting-wastage-fabric'+flag).val();
            var shrinkage=$('.shrinkage-wastage-fabric'+flag).val();

            var Wastagepercnt=(parseFloat(total) * (parseFloat(wastage) + parseFloat(shrinkage)) /100);
            var totalWastage=parseFloat(total)+parseFloat(Wastagepercnt);         
            //debugger;
            if(total!=0)
            {
            $('.totalOrdAvg' + flag).val(parseFloat(Math.round(total)));
            $('.totalGreigeOrder' + flag).val(parseFloat(Math.round(totalWastage)));
            }
           else{
          $('.totalOrdAvg' + flag).val('');
            $('.totalGreigeOrder' + flag).val('');

            if(flag==1)
                 {
                    $('#<%=lblTotalFabricOrdAvg1.ClientID %>', '#main_content').html("");
                    $('#<%=lblTotalFabric1.ClientID %>', '#main_content').html("");
                 }
                 if(flag==2)
                 {
                    $('#<%=lblTotalFabricOrdAvg2.ClientID %>', '#main_content').html("");
                    $('#<%=lblTotalFabric2.ClientID %>', '#main_content').html("");
                 }
                 if(flag==3)
                 {
                    $('#<%=lblTotalFabricOrdAvg3.ClientID %>', '#main_content').html("");
                    $('#<%=lblTotalFabric3.ClientID %>', '#main_content').html("");
                 }

                 if(flag==4)
                 {
                    $('#<%=lblTotalFabricOrdAvg4.ClientID %>', '#main_content').html("");
                    $('#<%=lblTotalFabric4.ClientID %>', '#main_content').html("");
                    }

           }

    }

//END



    function CalculateFinalQuantity(flag,txtFinalOrder,total, txtFinalQty, txtTotalfab, fabDetails, unit) {
        //debugger;
        if ($.trim(txtFinalOrder.val()) == '' || parseFloat(txtFinalOrder.val()) == 0)
            return;
             
        var totalQty = 0;
        for (var i = 0; i < quantity.length; i++) {
            totalQty = totalQty + parseInt(quantity[i].innerText);
        }

        var orderedQty = "&nbsp;";
        var FabricQuantity
        for (var i = 0; i < quantity.length; i++) {
            //debugger;
            var finalQty = 0;
//            finalQty = parseFloat(quantity[i].innerText) * parseFloat(txtFinalOrder.val());

            //            finalQty = Math.round(parseFloat(finalQty) / totalQty);  txtFabric1Quantity
            //debugger
            if (flag == 1) {
                FabricQuantity = $("[id$='" + i + "_txtFabric1Quantity']");
            }
            if (flag == 2) {
                FabricQuantity = $("[id$='" + i + "_txtFabric2Quantity']");
            }
            if (flag == 3) {
                FabricQuantity = $("[id$='" + i + "_txtFabric3Quantity']");
            }
            if (flag == 4) {
                FabricQuantity = $("[id$='" + i + "_txtFabric4Quantity']");
            }

            finalQty = Math.round((parseFloat(FabricQuantity.val()) / parseFloat(total.val())) * parseFloat(txtFinalOrder.val()))

            orderedQty = orderedQty + fabDetails[i].innerText + " order qty " + finalQty + " " + unit + "<br />";


           

        }
        $(txtFinalQty.html(" Colorwise order qty breakdown " + "<br />" + orderedQty + "<br />"));


    }
    function ReceiveServerData(rValue) {
        alert(rValue);
        // document.getElementById("ResultsSpan").innerHTML = rValue;

    }

    function test() {
        var product = "abc";
        CallServer(product, "");
    }
    function PrintPDF3(Url, height, width) {
        //debugger;
        $(".loadingimage").show();
        var url;
        var ht = parseInt($(document).height()) - 130;
        var wd = parseInt($(document).width()) - 100;

        if (height != '' && height != null) {
            ht = height;
        }
        if (width != '' && width != null) {
            wd = width;
        }

        if (Url == '' || Url == null) {
            url = window.location.pathname;
        }
        else {
            url = Url;
        }

        if (url.indexOf('/') != 0)
            url = '/' + url;



        proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {
            if ($.trim(result) == '') {

                jQuery.facebox("Some error occured on the server, please try again later.");
                $(".print").show();
            }
            else {
                window.open(result);
                $(".loadingimage").hide();
                $(".print").show();

//                $(".loadingimage").hide();
//                $("#" + hdnPathClientId).val(result);
//                   window.open(result);
            }
        });

        return false;
    }
    function showHide(prmThis) {
        if (isExpanded == false) {

            $("#divHistory").show();

            isExpanded = true;
            $(prmThis).html("Collapse");
        }
        else {
            $("#divHistory").hide();
            isExpanded = false;
            $(prmThis).html("View History");
        }
    }
    
    function UploadComentsFabricWorking(OrderID,FabricDetails,Flag,username) {

        
            var url = 'FabricWrokingRemarks.aspx?OrderID=' + OrderID + '&FabricDetails=' + FabricDetails + '&Flag=' + Flag+ '&username=' + username;
            window.open(url, '_blank', 'height=525,width=1300,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        }
       
    //----------------------------1-jul-16------------abhishek
    function showRemarksFabricWorking(Id1, Id2, Remarks, Type, ApplicationModuleName, Permission, IsHold, styleId) {     
    $(".divRemarks").show();

    if ((Permission == 1) && (IsHold == 0)) {
        $(".permission-text-remarks").hide();
        $("#btnSubmit").hide();
    }
    else {
        $(".permission-text-remarks").show();
        $("#btnSubmit").show();
    }

    // $(".divRemarks").show();
    $(".label-remarks", "#divRemarks").html("");
    if ($(".label-remarks", "#divRemarks")[0] != undefined) {
        $(".label-remarks", "#divRemarks")[0].innerHTML = "";

    }

    //Added By Ashish on 16/10/2014 for Show Remarks of MO
    //debugger;
    if (ApplicationModuleName == "MANAGE_ORDER_FILE") {
        var MoRemark = Remarks.replace("!<@#", "'");
        var arrStr = MoRemark.split('$$');
        if (arrStr.length > 1) {
            for (var i = 0; i < arrStr.length; i++) {
                if (i == 0) {
                    $(".label-remarks", "#divRemarks").html(arrStr[i]);
                }
                else {
                    $(".label-remarks", "#divRemarks").html($(".label-remarks", "#divRemarks").html() + "</br>" + arrStr[i]);
                }
            }
        }
        else {
            $(".label-remarks", "#divRemarks").html(Remarks);
        }

    }
    else {
        $(".label-remarks", "#divRemarks").html(Remarks);
    }
    //END


    $(".label-remarks", "#divRemarks").html(Remarks);
    if (Type == 'MERCHANT_REMARKS' && ApplicationModuleName == 'LIABILITY') {
        $(".liabilityRaise").attr("style", "display:block");
    }
    else {
        $(".liabilityRaise").attr("style", "display:none");
    }

    $("#hdnId").val(Id1);
    $("#hdnId2").val(Id2);
    $("#hdntype").val(Type);
    $("#hdnApplicationModuleName").val(ApplicationModuleName);
    debugger;
    if (IsHold == "1" || IsHold == "2") {
        $("#hdnIsHold").val(IsHold);
    }
    else {
        $("#hdnIsHold").val('-1')
    }
}

function saveRemarks() {   
    var id1 = $("#hdnId").val();
    var id2 = $("#hdnId2").val();
    var type = $("#hdntype").val();
    var isHold = $("#hdnIsHold").val();
    var applicationModuleName = $("#hdnApplicationModuleName").val();
    var remarks;
    var remark = $(".text-remarks", "#divRemarks").val();
    var lia1 = $(".lia1", "#divRemarks");
    var lia2 = $(".lia2", "#divRemarks");
    var liability = 0;
    if (lia1.attr("checked") == true)
        liability = parseInt(lia1.val());
    else if (lia2.attr("checked") == true) {
        liability = parseInt(lia2.val());
    }
    else {
        if (type == 'MERCHANT_REMARKS') {
            alert("Please select one of the two options");
            return;
        }
    }
    if (remark.indexOf("'") > -1) {
        while (remark.indexOf("'") > -1) {
            remark = remark.replace(/'/g, '');
        }
    }
    if (remark.indexOf('"') > -1) {
        while (remark.indexOf('"') > -1) {
            remark = remark.replace(/"/g, '');
        }
    }    
    remarks = $.trim(remark)
    var oldRemarks = $(".label-remarks", "#divRemarks").html();
    var date = new Date();

   
        if(remarks != "")
        {
        proxy.invoke("UpdateRemarks", { Id1: id1, Id2: id2, Remarks: remarks, Type: type, ApplicationModuleName: applicationModuleName }, function () {

            $(".divRemarks").hide();
           
             jQuery.facebox("Remarks have been submitted successfully");              
                   $(".go").click();         
        }, onPageError, false, false);              
        if (isHold == "1")
        {        
            changeStatusToOnHold(id1, remarks);
            }
        else if (isHold == "2")
        {
            changeStatusToPrevious(id1, remarks);
            }
    }
    else
    {
     $(".divRemarks").hide();
    }
 
}


function closeRemarks() {

    $(".text-remarks", "#divRemarks").val("");
    $(".divRemarks").hide();
    $("#hdnIsHold").val('-1');
}
function ParseDateToDateWithDay(dateObject) {

    dateObject = dateObject.toString('dd MMM yy (ddd)');
    return dateObject;
}
    
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .drop-dwn td
    {
        text-align: left;
    }
    .drop-dwn td select
    {
        text-transform: capitalize;
    }
    .item_list th
    {
        padding-left: 2px !important;
    }
    .form_heading
    {
        color: #000 !important;
    }
    .center_bodyCentering
    {
        font-size: 10px !important;
    }
    .my-readmore-css-class
    {
        white-space: nowrap;
    }
    .blue-text
    {
        font-size: 12PX;
    }
    .center_bodyCentering
    {
        font-size: 12px !important;
    }
    
    .item_list TD input[type="text"], .item_list TD textarea
    {
        vertical-align: bottom;
        width: 94%;
        font-size: 11px;
        padding-right: 2px !important;
        padding-left: 2px;
    }
    input[type="text"]
    {
        margin-bottom: 2px;
        width: 98%;
        height: 15px !important;
        border-radius: 2px;
    }
    input[type='checkbox']
    {
      position: relative;
      top: 3px;
    }
</style>
<asp:Panel runat="server" ID="pnlForm">
    <div class="order_form">
        <div class="print-box">
            <div class="form_box">
                <table width="100%" class="item_list" bordercolor="#999" border="1">
                    <tr>
                        <td colspan="4" style="text-align: center" class="form_heading">
                            Fabric Order Form
                        </td>
                        <td colspan="2" class="form_heading">
                            <span class="fabric_date">Creation Date
                                <asp:Label ID="lblCreationDate" runat="server" CssClass="date_style"></asp:Label></span>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: left" width="15%">
                            SERIAL NO.
                        </th>
                        <td align="center" style="vertical-align: middle; text-align: left" width="18%">
                            <asp:Label ID="lblSerial" runat="server" CssClass="fabric_center  blue-text"></asp:Label>
                        </td>
                        <th style="text-align: left" width="15%">
                            BULK IN HOUSE TARGET
                        </th>
                        <td style="text-align: left" width="18%">
                            <asp:Label ID="lblBulkETA" runat="server" CssClass="date_style blue-text"></asp:Label>
                        </td>
                        <th style="text-align: left" width="15%">
                            Order Date
                        </th>
                        <td style="text-align: left" width="18%">
                            <asp:Label ID="lblOrderDate" runat="server" CssClass="date_style blue-text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: left">
                            Buyer
                        </th>
                        <td style="text-align: left">
                            <asp:Label ID="lblBuyer" runat="server" CssClass="blue-text"></asp:Label>
                        </td>
                        <th style="text-align: left">
                            BULK APPROVAL TARGET
                        </th>
                        <td style="text-align: left">
                            <asp:Label ID="lblBulkApproval" runat="server" CssClass="date_style blue-text"></asp:Label>
                        </td>
                        <th style="text-align: left">
                            Quantity
                        </th>
                        <td style="text-align: left">
                            <asp:Label ID="lblTotalQuantity" runat="server" CssClass="numeric-field-with-decimal-places blue-text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: left">
                            Style Number
                        </th>
                        <td style="text-align: left">
                            <asp:Label ID="lblStyleNumber" runat="server" CssClass="blue-text"></asp:Label>
                        </td>
                        <th style="text-align: left">
                            L.D/S.O APPROVAL TARGET
                        </th>
                        <td style="text-align: left">
                            <asp:Label ID="lblLabDipApproval" runat="server" CssClass="date_style blue-text"></asp:Label>
                        </td>
                        <th style="text-align: left">
                            Description
                        </th>
                        <td style="text-align: left">
                            <asp:Label ID="lblDescription" runat="server" CssClass="blue-text"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" class="item_list" bordercolor="#999" border="1">
                    <tr>
                        <td colspan="16" class="form_heading" style="text-align: center">
                            Merchandising DEPARTMENT
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 200px">
                            Fabric
                        </th>
                        <th>
                            Initial Width
                        </th>
                        <th>
                            Usable Width
                        </th>
                        <td colspan="3" rowspan="5">
                            SWATCH TO BE PHYSICALLY AFFIXED
                        </td>
                        <td colspan="3" rowspan="5">
                            SWATCH TO BE PHYSICALLY AFFIXED
                        </td>
                        <td colspan="3" rowspan="5">
                            SWATCH TO BE PHYSICALLY AFFIXED
                        </td>
                        <td colspan="3" rowspan="5">
                            SWATCH TO BE PHYSICALLY AFFIXED
                        </td>
                        <th style="width: 175px">
                            Merchandising Remarks
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFabric1" runat="server" CssClass="blue-text"></asp:Label>
                            <asp:Label Height="40px" ID="lblFabric111" runat="server" class="ccgsm_color"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric1InitialWidth" runat="server" CssClass="do-not-allow-typing"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric1UsableWidth" runat="server" CssClass="numeric-field-with-decimal-places"></asp:TextBox>
                        </td>
                        <td rowspan="5">
                            <asp:TextBox TextMode="MultiLine" Rows="6" ID="txtFabricRemarks" Style="width: 98%;"
                                runat="server" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC_REMARKS)? "":"do-not-allow-typing" %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFabric2" runat="server" CssClass="blue-text"></asp:Label>
                            <div>
                                <asp:Label Height="40px" ID="lblFabric112" runat="server" class="ccgsm_color"></asp:Label></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric2InitialWidth" runat="server" CssClass="do-not-allow-typing"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric2UsableWidth" runat="server" CssClass="numeric-field-with-decimal-places"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFabric3" runat="server" CssClass="blue-text"></asp:Label>
                            <div>
                                <asp:Label Height="40px" ID="lblFabric113" runat="server" class="ccgsm_color"></asp:Label></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric3InitialWidth" runat="server" CssClass="do-not-allow-typing"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric3UsableWidth" runat="server" CssClass="numeric-field-with-decimal-places"></asp:TextBox>
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="2" Width="100%"
                                Visible="false" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_ALL_REMARKS)? "":"do-not-allow-typing" %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFabric4" runat="server" CssClass="blue-text"></asp:Label>
                            <div>
                                <asp:Label Height="40px" ID="lblFabric114" runat="server" class="ccgsm_color"></asp:Label></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric4InitialWidth" runat="server" CssClass="do-not-allow-typing"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFabric4UsableWidth" runat="server" CssClass="numeric-field-with-decimal-places"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th rowspan="2">
                            LINE/ITEM NUMBER
                        </th>
                        <th rowspan="2">
                            CONTRACT NUMBER
                        </th>
                        <th rowspan="2">
                            QTY
                        </th>
                        <%--added by abhishek on 21/12/2015--%>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <td colspan="3" style="text-align: left; font-size: 12px; padding: 0px; vertical-align: top;">
                            <div id="DivFabricSection_1" runat="server">
                                <asp:Label ID="lblFab1ColPrd" runat="server"></asp:Label>
                                <span style="width: 90px;">
                                    <br />
                                    <asp:FileUpload ID="Fabric1Upload" Width="90px" runat="server" /></span> <span style="float: right;">
                                        <asp:HyperLink ID="viewolay1" ToolTip="VIEW Smart Marker" runat="server" Target="_blank"
                                            ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                    </span><span style="clear: both;"></span>
                                <br />
                                <asp:HyperLink ID="hlnViewComments_1" runat="server" Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif"
                                    ToolTip="View Fabric1 Working Remarks" Target="_blank"></asp:HyperLink>
                                <%--<br />
                                        <asp:CheckBox ID="chkREFReceived_1" runat="server" Text="Clr/Prnt Ref Revd" />&nbsp;<asp:Label
                                            ID="lblrefupdateddate_1" runat="server" Text="" Style="font-size: 9px; color:blue;"></asp:Label>--%>
                                <%--<asp:CheckBox ID="chkQualityApproved_1" runat="server" Text="Fabric QTY Aprd" />--%>
                                <%--  <table width="100%" cellpadding="0" cellspacing="0"  class="drop-dwn">
                                            <tr>
                                                <td class="my-readmore-css-class">
                                                    Fabric Qlty Aprd <asp:Label ID="lblQualityupdatedate_1" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlQtyApvd_1" AutoPostBack="true" runat="server" Enabled="true"
                                                                Style="width: 70px" 
                                                                onselectedindexchanged="ddlQtyApvd_1_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                       <%-- <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_1" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    initial Aprd <asp:Label ID="lblinitialupdatedate_1" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanelddlinitial_1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlinitial_1" AutoPostBack="true" runat="server" Enabled="false" 
                                                                Style="width: 70px" onselectedindexchanged="ddlinitial_1_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlinitial_1" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Bulk Aprd <asp:Label ID="lblBulkupdatedate_1" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlbulkApvd_1" runat="server" AutoPostBack="true" 
                                                                Enabled="false"  Style="width: 70px" 
                                                                onselectedindexchanged="ddlbulkApvd_1_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                            </asp:DropDownList>
                                                      
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_1" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            </td>
                                            </tr>
                                        </table>--%>
                            </div>
                        </td>
                        <td colspan="3" style="text-align: left; font-size: 12px; padding: 0px; vertical-align: top;">
                            <div id="DivFabricSection_2" runat="server">
                                <asp:Label ID="lblFab2ColPrd" runat="server"></asp:Label>
                                <br />
                                <asp:FileUpload ID="Fabric2Upload" Width="90px" runat="server" />
                                <span style="float: right;">
                                    <asp:HyperLink ID="viewolay2" ToolTip="VIEW Smart Marker" runat="server" Target="_blank"
                                        ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                </span>
                                <br />
                                <asp:HyperLink ID="hlnViewComments_2" runat="server" ToolTip="View Fabric2 Working Remarks"
                                    Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif"
                                    Target="_blank"></asp:HyperLink>
                                <%--<br />
                                        
                                        <asp:CheckBox ID="chkREFReceived_2" runat="server" Text="Clr/Prnt Ref Revd" />&nbsp;<asp:Label
                                            ID="lblrefupdateddate_2" runat="server" Text="" Style="font-size: 9px; color:blue;"></asp:Label>--%>
                                <%--<asp:CheckBox ID="chkQualityApproved_2" runat="server" />--%>
                                <%--  <table width="100%" cellpadding="0" cellspacing="0"  class="drop-dwn">
                                            <tr>
                                                <td class="my-readmore-css-class">
                                                    Fabric Qnty Aprd<asp:Label ID="lblQualityupdatedate_2" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_2" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddlQtyApvd_2" AutoPostBack="true" runat="server" Enabled="true" 
                                                        Style="width: 70px" onselectedindexchanged="ddlQtyApvd_2_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_2" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    initial Aprd <asp:Label ID="lblinitialupdatedate_2" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                  <asp:UpdatePanel ID="UpdatePanelddlinitial_2" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddlinitial_2" AutoPostBack="true" runat="server" Enabled="false" 
                                                        Style="width: 70px" onselectedindexchanged="ddlinitial_2_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlinitial_2" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Bulk Aprd <asp:Label ID="lblBulkupdatedate_2" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddlbulkApvd_2" runat="server" AutoPostBack="true" Enabled="false" 
                                                                Style="width: 70px" onselectedindexchanged="ddlbulkApvd_2_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                     </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_2" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                             <tr>
                                            <td>
                                            </td>
                                            </tr>
                                        </table>--%>
                            </div>
                        </td>
                        <td colspan="3" style="text-align: left; font-size: 12px; padding: 0px; vertical-align: top;">
                            <div id="DivFabricSection_3" runat="server">
                                <asp:Label ID="lblFab3ColPrd" runat="server"></asp:Label>
                                <br />
                                <asp:FileUpload ID="Fabric3Upload" Width="90px" runat="server" />
                                <span style="float: right;">
                                    <asp:HyperLink ID="viewolay3" ToolTip="VIEW Smart Marker" runat="server" Target="_blank"
                                        ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                </span>
                                <br />
                                <asp:HyperLink ID="hlnViewComments_3" runat="server" ToolTip="View Fabric3 Working Remarks"
                                    Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif"
                                    Target="_blank"></asp:HyperLink>
                                <%--<asp:CheckBox ID="chkREFReceived_3" runat="server" Text="Clr/Prnt Ref Revd" />&nbsp;<asp:Label
                                            ID="lblrefupdateddate_3" runat="server" Text="" Style="font-size: 9px; color:blue;"></asp:Label>
                                        <br />--%>
                                <%--<table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">
                                            <tr>
                                                <td class="my-readmore-css-class">
                                                    Fabric Qnty Aprd<asp:Label ID="lblQualityupdatedate_3" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_3" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddlQtyApvd_3" AutoPostBack="true" runat="server" Enabled="true" 
                                                        Style="width: 70px" onselectedindexchanged="ddlQtyApvd_3_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                     </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_3" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    initial Aprd <asp:Label ID="lblinitialupdatedate_3" runat="server" Text="" Style="font-size: 9px; "></asp:Label>
                                                </td>
                                                <td> 
                                                    <asp:UpdatePanel ID="UpdatePanelddlinitial_3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlinitial_3" runat="server" AutoPostBack="true" Enabled="false" Style="width: 70px"
                                                                OnSelectedIndexChanged="ddlinitial_3_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlinitial_3" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Bulk Aprd <asp:Label ID="lblBulkupdatedate_3" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddlbulkApvd_3" runat="server" AutoPostBack="true" Enabled="false" 
                                                                Style="width: 70px" onselectedindexchanged="ddlbulkApvd_3_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                     </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlinitial_3" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            </td>
                                            </tr>
                                        </table>--%>
                            </div>
                        </td>
                        <td colspan="3" style="text-align: left; font-size: 12px; padding: 0px; vertical-align: top;">
                            <div id="DivFabricSection_4" runat="server">
                                <asp:Label ID="lblFab4ColPrd" runat="server"></asp:Label>
                                <br />
                                <asp:FileUpload ID="Fabric4Upload" Width="90px" runat="server" />
                                <span style="float: right;">
                                    <asp:HyperLink ID="viewolay4" ToolTip="VIEW Smart Marker" runat="server" Target="_blank"
                                        ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                </span>
                                <br />
                                <asp:HyperLink ID="hlnViewComments_4" runat="server" ToolTip="View Fabric4 Working Remarks"
                                    Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif"
                                    Target="_blank"></asp:HyperLink>
                                <%-- <asp:CheckBox ID="chkREFReceived_4" runat="server" Text="Clr/Prnt Ref Revd" />&nbsp;<asp:Label
                                            ID="lblrefupdateddate_4" runat="server" Text="" Style="font-size: 9px; color:blue;"></asp:Label>
                                        <br />--%>
                                <%-- <asp:CheckBox ID="chkQualityApproved_4" runat="server" Text="Fabric QTY Aprd" />--%>
                                <%-- <table width="100%" cellpadding="0" cellspacing="0" class="drop-dwn">
                                            <tr>
                                                <td class="my-readmore-css-class">
                                                    Fabric Qnty Aprd<asp:Label ID="lblQualityupdatedate_4" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_4" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlQtyApvd_4" AutoPostBack="true" runat="server" Enabled="true" Style="width: 70px"
                                                                OnSelectedIndexChanged="ddlQtyApvd_4_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlQtyApvd_4" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    initial Aprd <asp:Label ID="lblinitialupdatedate_4" runat="server" Text="" Style="font-size: 9px;"></asp:Label>
                                                </td>
                                                <td>
                                                <asp:UpdatePanel ID="UpdatePanelddlinitial_4" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddlinitial_4" AutoPostBack="true" runat="server" Enabled="false" 
                                                        Style="width: 70px" onselectedindexchanged="ddlinitial_4_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlinitial_4" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Bulk Aprd <asp:Label ID="lblBulkupdatedate_4" runat="server" Text="" Style="font-size: 9px; "></asp:Label>
                                                </td>
                                                <td>
                                                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddlbulkApvd_4" runat="server" AutoPostBack="true" Enabled="false" 
                                                                Style="width: 70px" onselectedindexchanged="ddlbulkApvd_4_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Sent for approval</asp:ListItem>
                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlbulkApvd_4" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            </td>
                                            </tr>
                                        </table>--%>
                            </div>
                        </td>
                        <%--end by abhishek on 21/12/2015--%>
                    </tr>
                    <tr>
                        <th>
                            CLR/PRD
                        </th>
                        <th>
                            Marker AVG
                            <asp:DropDownList Width="50px" ID="ddlAvgUnit1" runat="server" CssClass='<%#iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_UNIT_OF_AVERAGE)? "font_size_ten AvgUnit1":"font_size_ten AvgUnit1 disable-dropdown" %>'>
                                <asp:ListItem Selected="False" Text="..." Value="-1"></asp:ListItem>
                                <asp:ListItem Selected="False" Text="KG" Value="1"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="MTR" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </th>
                        <th style="width: 100px">
                            QTY
                        </th>
                        <th>
                            CLR/PRD
                        </th>
                        <th>
                            Marker AVG
                            <asp:DropDownList Width="50px" ID="ddlAvgUnit2" runat="server" CssClass='<%#iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_UNIT_OF_AVERAGE)? "font_size_ten AvgUnit2":"font_size_ten AvgUnit2 disable-dropdown" %>'>
                                <asp:ListItem Selected="False" Text="..." Value="-1"></asp:ListItem>
                                <asp:ListItem Selected="False" Text="KG" Value="1"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="MTR" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </th>
                        <th style="width: 100px">
                            QTY
                        </th>
                        <th>
                            CLR/PRD
                        </th>
                        <th>
                            Marker AVG
                            <asp:DropDownList Width="50px" ID="ddlAvgUnit3" runat="server" CssClass='<%#iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_UNIT_OF_AVERAGE)? "font_size_ten AvgUnit3":"font_size_ten AvgUnit3 disable-dropdown" %>'>
                                <asp:ListItem Selected="False" Text="..." Value="-1"></asp:ListItem>
                                <asp:ListItem Selected="False" Text="KG" Value="1"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="MTR" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </th>
                        <th style="width: 100px">
                            QTY
                        </th>
                        <th>
                            CLR/PRD
                        </th>
                        <th class="font_size_ten">
                            Marker AVG
                            <asp:DropDownList Width="50px" ID="ddlAvgUnit4" runat="server" CssClass='<%#iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_UNIT_OF_AVERAGE)? "font_size_ten AvgUnit4":"font_size_ten AvgUnit4 disable-dropdown" %>'>
                                <asp:ListItem Selected="False" Text="..." Value="-1"></asp:ListItem>
                                <asp:ListItem Selected="False" Text="KG" Value="1"></asp:ListItem>
                                <asp:ListItem Selected="True" Text="MTR" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </th>
                        <th style="width: 100px">
                            QTY
                        </th>
                        <th>
                            Remarks
                        </th>
                    </tr>
                    <asp:Repeater ID="repeaterOrderBreakdown" runat="server" OnItemDataBound="repeaterOrderBreakdown_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblLineItemNumber" Text='<%# DataBinder.Eval(Container.DataItem,"LineItemNumber")%>'
                                        CssClass="blue-text"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblContractNumber" Text='<%# DataBinder.Eval(Container.DataItem,"ContractNumber")%>'
                                        CssClass="blue-text"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Quantity")%>'
                                        CssClass="quantity-for-calculation numeric-field-with-decimal-places blue-text"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric1Details")%>'
                                        CssClass="blue-text details-fabric1"></asp:Label>
                                </td>
                                <td align="left" style="text-align: left !important;">
                                    <%--Added By Ashish for Font Bold on 5/1/2014--%>
                                    <asp:Label ID="lblFabricAvgName1" runat="server" Text="O :"></asp:Label>
                                    <asp:TextBox ID="txtFabric1Average" Style="text-align: left;" Width="50%" onchange="javascript:ChangeFabricAvg(this,1);"
                                        Font-Bold="true" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric1STCAverage")%>'
                                        CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC1_AVG)? "averageFabric1 numeric-field-with-three-decimal-places":"averageFabric1 do-not-allow-typing" %>'></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lblOrderName1" runat="server"></asp:Label>
                                    <%--END--%>
                                    <asp:Label runat="server" ID="lblFabric1Average" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric1AvgHistory")%>'
                                        CssClass="blue-text lblFabricAverage1"></asp:Label>
                                    <asp:HiddenField ID="hdnIsCutAvg1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsCutAvg1")%>' />
                                    <asp:HiddenField ID="hdnIsAckAvg1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsAckAvg1")%>' />
                                </td>
                                <td>
                                    <%--Added By Ashish on 2/1/2014--%>
                                    <asp:TextBox ID="txtFabric1OrdAverage" runat="server" Font-Bold="true" Text="" CssClass="FabricOrdAverage1 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                    <%--END--%>
                                    <asp:TextBox ID="txtFabric1Quantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric1Quantity")%>'
                                        CssClass="totalQtyFabric1 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                    <%--<asp:HiddenField ID="hdnOrderQty1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"Fabric1Quantity")%>' /> --%>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label2" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric2Details")%>'
                                        CssClass="blue-text details-fabric2"></asp:Label>
                                </td>
                                <td align="left" style="text-align: left !important;">
                                    <%--Added By Ashish for Font Bold on 5/1/2014--%>
                                    <asp:Label ID="lblFabricAvgName2" runat="server" Text="O :"></asp:Label>
                                    <asp:TextBox ID="txtFabric2Average" Style="text-align: left;" Width="50%" onchange="javascript:ChangeFabricAvg(this,2);"
                                        Font-Bold="true" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric2STCAverage")%>'
                                        CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC2_AVG)? "averageFabric2 numeric-field-with-three-decimal-places":"averageFabric2 do-not-allow-typing" %>'></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lblOrderName2" runat="server"></asp:Label>
                                    <%--END--%>
                                    <asp:Label runat="server" ID="lblFabric2Average" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric2AvgHistory")%>'
                                        CssClass="blue-text lblFabricAverage2"></asp:Label>
                                    <asp:HiddenField ID="hdnIsCutAvg2" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsCutAvg2")%>' />
                                    <asp:HiddenField ID="hdnIsAckAvg2" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsAckAvg2")%>' />
                                </td>
                                <td>
                                    <%--Added By Ashish on 2/1/2014--%>
                                    <asp:TextBox ID="txtFabric2OrdAverage" runat="server" Font-Bold="true" Text="" CssClass="FabricOrdAverage2 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                    <%--END--%>
                                    <asp:TextBox ID="txtFabric2Quantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric2Quantity")%>'
                                        CssClass="totalQtyFabric2 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label3" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric3Details")%>'
                                        CssClass="blue-text details-fabric3"></asp:Label>
                                </td>
                                <td align="left" style="text-align: left !important;">
                                    <%--Added By Ashish for Font Bold on 5/1/2014--%>
                                    <asp:Label ID="lblFabricAvgName3" runat="server" Text="O :"></asp:Label>
                                    <asp:TextBox ID="txtFabric3Average" Style="text-align: left;" Width="50%" onchange="javascript:ChangeFabricAvg(this,3);"
                                        Font-Bold="true" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric3STCAverage")%>'
                                        CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC3_AVG)? "averageFabric3 numeric-field-with-three-decimal-places":"averageFabric3 do-not-allow-typing" %>'></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lblOrderName3" runat="server"></asp:Label>
                                    <%--END--%>
                                    <asp:Label runat="server" ID="lblFabric3Average" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric3AvgHistory")%>'
                                        CssClass="blue-text lblFabricAverage3"></asp:Label>
                                    <asp:HiddenField ID="hdnIsCutAvg3" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsCutAvg3")%>' />
                                    <asp:HiddenField ID="hdnIsAckAvg3" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsAckAvg3")%>' />
                                </td>
                                <td>
                                    <%--Added By Ashish on 2/1/2014--%>
                                    <asp:TextBox ID="txtFabric3OrdAverage" runat="server" Text="" Font-Bold="true" CssClass="FabricOrdAverage3 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                    <%--END--%>
                                    <asp:TextBox ID="txtFabric3Quantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric3Quantity")%>'
                                        CssClass="totalQtyFabric3 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label4" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric4Details")%>'
                                        CssClass="blue-text details-fabric4"></asp:Label>
                                </td>
                                <td align="left" style="text-align: left !important;">
                                    <%--Added By Ashish for Font Bold on 5/1/2014--%>
                                    <asp:Label ID="lblFabricAvgName4" runat="server" Text="O :"></asp:Label>
                                    <asp:TextBox ID="txtFabric4Average" Style="text-align: left;" Width="50%" onchange="javascript:ChangeFabricAvg(this,4);"
                                        Font-Bold="true" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric4STCAverage")%>'
                                        CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC4_AVG)? "averageFabric4 numeric-field-with-three-decimal-places":"averageFabric4 do-not-allow-typing" %>'></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lblOrderName4" runat="server"></asp:Label>
                                    <%--END--%>
                                    <asp:Label runat="server" ID="lblFabric4Average" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric4AvgHistory")%>'
                                        CssClass="blue-text lblFabricAverage4"></asp:Label>
                                    <asp:HiddenField ID="hdnIsCutAvg4" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsCutAvg4")%>' />
                                    <asp:HiddenField ID="hdnIsAckAvg4" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"IsAckAvg4")%>' />
                                </td>
                                <td>
                                    <%--Added By Ashish on 2/1/2014--%>
                                    <asp:TextBox ID="txtFabric4OrdAverage" runat="server" Text="" Font-Bold="true" CssClass="FabricOrdAverage4 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                    <%--END--%>
                                    <asp:TextBox ID="txtFabric4Quantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fabric4Quantity")%>'
                                        CssClass="totalQtyFabric4 do-not-allow-typing numeric-field-without-decimal-places"></asp:TextBox>
                                    <asp:HiddenField ID="hiddenOrderDetailID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"OrderDetailID") %>' />
                                </td>
                                <td class="remarks_text remarks_text2">
                                    <%#(Eval("Remarks").ToString().IndexOf("$$") > -1) ? Eval("Remarks").ToString().Substring(Eval("Remarks").ToString().LastIndexOf("$$") + 2) : Eval("Remarks").ToString()%>
                                    <br />
                                    <img alt="Remarks" title="CLICK TO SEE REMARKS HISTORY" src="/App_Themes/ikandi/images/remark.gif"
                                        border="0" onclick="showRemarksFabricWorking('<%# Eval("OrderDetailID") %>',0,'<%# (Eval("Remarks").ToString().IndexOf("$$") > -1) ? Eval("Remarks").ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  : Eval("Remarks").ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;")  %>','MANAGE_ORDERS_FILE_FABRIC_FABRIC_REMARKS','MANAGE_ORDER_FILE','<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.MANAGE_ORDERS_FILE_FABRIC_FABRIC_REMARKS)? 1 : 0 %>',0,0)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <th colspan="3">
                            <span class="fabric_headings">TOTAL FABRIC REQUIRED</span>
                        </th>
                        <td style="text-align: right; border-right: #F9DDF4 !important;" colspan="2">
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:Label ID="lblTotalFabricOrdAvg1" runat="server" Text="Cut Req :"></asp:Label>
                            <asp:TextBox ID="txtTotalFabricOrdAvg1" runat="server" Font-Bold="true" CssClass="totalOrdAvg1 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblTotalFabric1" runat="server" Text="Ord Pcd :"></asp:Label>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalFabric1" runat="server" CssClass="total1 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                        </td>
                        <td style="text-align: left; border-left: #F9DDF4 !important;">
                            <asp:Label ID="lblUnit1" runat="server" Text="MTRS" Width="50%"></asp:Label>
                        </td>
                        <td style="text-align: right; border-right: #F9DDF4 !important;" colspan="2">
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:Label ID="lblTotalFabricOrdAvg2" runat="server" Text="Cut Req :"></asp:Label>
                            <asp:TextBox ID="txtTotalFabricOrdAvg2" runat="server" Font-Bold="true" CssClass="totalOrdAvg2 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblTotalFabric2" runat="server" Text="Ord Pcd :"></asp:Label>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalFabric2" runat="server" CssClass="total2 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                        </td>
                        <td style="text-align: left; border-left: #F9DDF4 !important;">
                            <asp:Label ID="lblUnit2" runat="server" Text="MTRS" Width="50%"></asp:Label>
                        </td>
                        <td style="text-align: right; border-right: #F9DDF4 !important;" colspan="2">
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:Label ID="lblTotalFabricOrdAvg3" runat="server" Text="Cut Req :"></asp:Label>
                            <asp:TextBox ID="txtTotalFabricOrdAvg3" runat="server" Font-Bold="true" CssClass="totalOrdAvg3 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblTotalFabric3" runat="server" Text="Ord Pcd :"></asp:Label>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalFabric3" runat="server" CssClass="total3 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                        </td>
                        <td style="text-align: left; border-left: #F9DDF4 !important;">
                            <asp:Label ID="lblUnit3" runat="server" Text="MTRS" Width="50%"></asp:Label>
                        </td>
                        <td style="text-align: right; border-right: #F9DDF4 !important;" colspan="2">
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:Label ID="lblTotalFabricOrdAvg4" runat="server" Text="Cut Req :"></asp:Label>
                            <asp:TextBox ID="txtTotalFabricOrdAvg4" runat="server" Font-Bold="true" CssClass="totalOrdAvg4 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblTotalFabric4" runat="server" Text="Ord Pcd :"></asp:Label>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalFabric4" runat="server" CssClass="total4 numeric-field-with-decimal-places rightAlign"
                                Width="40%" Height="18px" BackColor="#B3E8FF" Style="text-align: center !important"
                                BorderWidth="0px"></asp:TextBox>
                        </td>
                        <td style="text-align: left; border-left: #F9DDF4 !important;">
                            <asp:Label ID="lblUnit4" runat="server" Text="MTRS" Width="50%"></asp:Label>
                        </td>
                        <td>
                            <asp:HyperLink runat="server" Target="OrderLimitationsForm" Text="Order Limitation"
                                ID="lnkOrderLimitation"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="16" class="form_heading" style="text-align: center">
                            FABRIC DEPARTMENT
                        </td>
                    </tr>
                    <tr>
                        <th colspan="3" style="text-align: left">
                            <span style="text-align: left">ADD: CUTTING WASTAGE (%)</span>
                        </th>
                        <td rowspan="4" colspan="2" class="CalculatedColumns">
                            <asp:TextBox ID="txtRemarksFabric1" runat="server" Text="Remarks" Height="120px"
                                TextMode="MultiLine" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC1_REMARKS)? "hide_me CalculatedColumns":"do-not-allow-typing hide_me" %>'></asp:TextBox>
                            <asp:Label ID="lblOrderedFabric1" runat="server" Height="100%" Width="100%" Font-Size="10px"
                                Text="Colorwise order qty breakdown" CssClass="final-qty-fabric1 CalculatedColumns"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCuttingWastageFabric1" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC1_WASTAGE)? "cutting-wastage-fabric1 numeric-field-without-decimal-places rightAlign":"cutting-wastage-fabric1 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                            <asp:HiddenField ID="hdnWastageFabric1" runat="server" Value="0" />
                        </td>
                        <td rowspan="4" colspan="2" class="CalculatedColumns">
                            <asp:TextBox ID="txtRemarksFabric2" runat="server" Text="Remarks" Height="120px"
                                TextMode="MultiLine" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC2_REMARKS)? "hide_me":"do-not-allow-typing hide_me" %>'></asp:TextBox>
                            <asp:Label ID="lblOrderedFabric2" runat="server" Text="Colorwise order qty breakdown"
                                Font-Size="10px" CssClass="final-qty-fabric2 CalculatedColumns"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCuttingWastageFabric2" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC2_WASTAGE)? "cutting-wastage-fabric2 numeric-field-without-decimal-places rightAlign":"cutting-wastage-fabric2 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                            <asp:HiddenField ID="hdnWastageFabric2" runat="server" Value="0" />
                        </td>
                        <td rowspan="4" colspan="2" class="CalculatedColumns">
                            <asp:TextBox ID="txtRemarksFabric3" runat="server" Text="Remarks" Height="120px"
                                TextMode="MultiLine" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC3_REMARKS)? "hide_me":"do-not-allow-typing hide_me" %>'></asp:TextBox>
                            <asp:Label ID="lblOrderedFabric3" runat="server" Text="Colorwise order qty breakdown"
                                Font-Size="10px" CssClass="final-qty-fabric3 CalculatedColumns"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCuttingWastageFabric3" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC3_WASTAGE)? "cutting-wastage-fabric3 numeric-field-without-decimal-places rightAlign":"cutting-wastage-fabric3 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                            <asp:HiddenField ID="hdnWastageFabric3" runat="server" Value="0" />
                        </td>
                        <td rowspan="4" colspan="2" class="CalculatedColumns">
                            <asp:TextBox ID="txtRemarksFabric4" runat="server" Text="Remarks" Height="120px"
                                TextMode="MultiLine" CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC4_REMARKS)? "hide_me":"do-not-allow-typing hide_me" %>'></asp:TextBox>
                            <asp:Label ID="lblOrderedFabric4" runat="server" Text="Colorwise order qty breakdown"
                                Font-Size="10px" CssClass="final-qty-fabric4 CalculatedColumns"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCuttingWastageFabric4" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC4_WASTAGE)? "cutting-wastage-fabric4 numeric-field-without-decimal-places rightAlign":"cutting-wastage-fabric4 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                            <asp:HiddenField ID="hdnWastageFabric4" runat="server" Value="0" />
                        </td>
                        <th>
                            <span>IMAGE</span>
                        </th>
                    </tr>
                    <tr>
                        <th colspan="3" style="text-align: left">
                            <span style="text-align: left">ADD: SHRINKAGE (%)</span>
                        </th>
                        <td>
                            <asp:TextBox ID="txtShrinkageFabric1" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC1_SHRINKAGE)? "shrinkage-wastage-fabric1 numeric-field-without-decimal-places rightAlign":"shrinkage-wastage-fabric1 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                        </td>
                        <td>
                            <asp:TextBox ID="txtShrinkageFabric2" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC2_SHRINKAGE)? "shrinkage-wastage-fabric2 numeric-field-without-decimal-places rightAlign":"shrinkage-wastage-fabric2 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                        </td>
                        <td>
                            <asp:TextBox ID="txtShrinkageFabric3" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC3_SHRINKAGE)? "shrinkage-wastage-fabric3 numeric-field-without-decimal-places rightAlign":"shrinkage-wastage-fabric3 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                        </td>
                        <td>
                            <asp:TextBox ID="txtShrinkageFabric4" Font-Size="12px" runat="server" Width="30%"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC4_SHRINKAGE)? "shrinkage-wastage-fabric4 numeric-field-without-decimal-places rightAlign":"shrinkage-wastage-fabric4 numeric-field-without-decimal-places do-not-allow-typing rightAlign" %>'></asp:TextBox>%
                        </td>
                        <td rowspan="3">
                            <asp:HiddenField ID="hiddenStyleID" runat="server" Value="-1" />
                            <a title="CLICK TO VIEW ENLARGED IMAGE" href="javascript:void(0)" onclick='showStylePhotoWithOutScroll(<%= hiddenStyleID.Value %>, <%=Request.Params["OrderID"] %>, -1)'>
                                <asp:Image Height="80px" title="CLICK TO VIEW ENLARGED IMAGE" runat="server" ID="imgFront"
                                    border="0px" /></a>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="3" style="text-align: left">
                            <span style="text-align: left">TOTAL REQUIREMENT - GREIGE</span>
                        </th>
                        <td>
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeOrder1" Font-Bold="true" Font-Size="12px"
                                CssClass="totalGreigeOrder1 do-not-allow-typing" runat="server"></asp:TextBox>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeFabric1" Font-Size="12px" CssClass="totalGreige1 do-not-allow-typing"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeOrder2" Font-Bold="true" Font-Size="12px"
                                CssClass="totalGreigeOrder2 do-not-allow-typing" runat="server"></asp:TextBox>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeFabric2" Font-Size="12px" CssClass="totalGreige2 do-not-allow-typing"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeOrder3" Font-Bold="true" Font-Size="12px"
                                CssClass="totalGreigeOrder3 do-not-allow-typing" runat="server"></asp:TextBox>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeFabric3" Font-Size="12px" CssClass="totalGreige3 do-not-allow-typing"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <%--Added By Ashish on 5/1/2014--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeOrder4" Font-Bold="true" Font-Size="12px"
                                CssClass="totalGreigeOrder4 do-not-allow-typing" runat="server"></asp:TextBox>
                            <%--END--%>
                            <asp:TextBox ID="txtTotalRequirementGreigeFabric4" Font-Size="12px" CssClass="totalGreige4 do-not-allow-typing"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="3" style="text-align: left">
                            <span style="text-align: left">FINAL FABRIC ORDER PLACED</span>
                        </th>
                        <td class="CalculatedColumns">
                            <asp:TextBox ID="txtFinalFabricOrderPlacedFabric1" Font-Size="12px" runat="server"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC1_FINAL_ORDER)? "numeric-field-with-decimal-places fabric-final1 CalculatedColumns":"numeric-field-with-decimal-places do-not-allow-typing fabric-final1 CalculatedColumns" %>'></asp:TextBox>
                        </td>
                        <td class="CalculatedColumns">
                            <asp:TextBox ID="txtFinalFabricOrderPlacedFabric2" Font-Size="12px" runat="server"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC2_FINAL_ORDER)? "numeric-field-with-decimal-places fabric-final2 CalculatedColumns":"numeric-field-with-decimal-places do-not-allow-typing fabric-final2 CalculatedColumns" %>'></asp:TextBox>
                        </td>
                        <td class="CalculatedColumns">
                            <asp:TextBox ID="txtFinalFabricOrderPlacedFabric3" Font-Size="12px" runat="server"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC3_FINAL_ORDER)? "numeric-field-with-decimal-places fabric-final3 CalculatedColumns":"numeric-field-with-decimal-places do-not-allow-typing fabric-final3 CalculatedColumns" %>'></asp:TextBox>
                        </td>
                        <td class="CalculatedColumns">
                            <asp:TextBox ID="txtFinalFabricOrderPlacedFabric4" Font-Size="12px" runat="server"
                                CssClass='<%# iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_WORKING_FORM_FABRIC4_FINAL_ORDER)? "numeric-field-with-decimal-places fabric-final4 CalculatedColumns":"numeric-field-with-decimal-places do-not-allow-typing fabric-final4 CalculatedColumns" %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="16">
                            SIGNATURES
                        </th>
                    </tr>
                    <tr>
                        <asp:CheckBox Visible="false" ID="chkboxAvgChecked" runat="server" CssClass="hide_me" />
                        <td colspan="6">
                            AVG CHECKED AND SMART MARKER UPLOADED BY ACCOUNT MANAGER
                            <asp:CheckBox ID="chkboxAccountMgr" runat="server" />
                        </td>
                        <td colspan="6" align="center">
                            <span style="float: left;">SMART MARKER AVG CHECKED BY FABRIC MANAGER </span><span
                                style="float: left; width: 20px;">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkboxFabricManager" runat="server" style="position:relative;top:-4px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </td>
                        <td colspan="4">
                            CUT AVG IMPACT KNOWLEDGE
                            <asp:CheckBox ID="chkUcknowledgment" Enabled="false" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <a href="javascript:void(0)" onclick="showHide( this)">View History</a><br />
            <br />
            <div id="divHistory" style="height: 300px ! important; overflow: auto;" class="hide_me">
                <div class="form_box">
                    <div class="form_heading">
                        History</div>
                    <br />
                    <div>
                        <table width="100%" cellpadding="6px">
                            <tr>
                                <td style="width: 100%;">
                                    <asp:Label ID="lblHistory" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="form_buttom">
            <asp:HiddenField runat="server" ID="hdnPath" Value="" />
                       
            <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit"
                CssClass="submit validate-form" />

            <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_click" CssClass="go hide_me" />

            <asp:Button runat="server" ID="btnPrint" CssClass="print da_submit_button" Text="Print"
                OnClientClick="window.print(); return false;" />          
        </div>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Fabric Order information have been saved into the system successfully!
            <br />
            <a id="A1" href="~\Internal\OrderProcessing\ManageOrders.aspx" runat="server">Click
                here</a> to Manage Orders.
        </div>
    </div>
</asp:Panel>
