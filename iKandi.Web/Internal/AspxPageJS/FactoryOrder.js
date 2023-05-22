
$(document).ready(function () {
    //alert('page load');
    //context.find("input.style-number")  
    //    $('#' + txtStyleNumberClientID).change(
    //    // onStyleChange();
    //     function () {
    //       //  debugger;
    //        alert('style text change ');
    //    });
    // alert($("#" + hdnOrderIdClientID).val());
    $(".orderavg").live("change", function () {
        avgchange($(this));
    });

    $(".orderprice").live("change", function () {
        orderpricechange($(this));
    });
    $(".orderrate").live("change", function () {
        changeorderaccRate($(this));
    });

    $(".orderqty").live("change", function () {
        changeorderaccqty($(this));
    });
    $(".orderwst").live("change", function () {
        changeorderacccutwastage($(this));
    });
    $(".itemwst").live("change", function () {
        changeorderitemwastage($(this));
    });
    //GetOrderContractDetail($("#" + hdnOrderIdClientID).val());
    GetOrderDetail($("#" + hdnOrderIdClientID).val());

    //  alert('A');
    // GetFabricWorking_data($("#" + hdnOrderIdClientID).val());
    // GetOrderfabricDetail($("#" + hdnOrderIdClientID).val());
    // alert('B');
    context.find("#" + txtStyleNumberClientID).result(function () {
        onStyleChange();
    });

    $(".mode").live("change", function () {
        //        alert('sushil');
        //        debugger;
        //        var abc = $('.tblcontect tr').eq(1).find('.mode').val();
        //        alert(abc);
        onModeChange($(this));
    });

    $(".ddlbuyer").change(function () {

        bindclientmode($(this).val());
        //var abc = $('.tblcontect tr').eq(1).find('.mode').val();
        // alert(abc);
    });
   


   

    /*
    $(".orderavg").change(function () {
    var orderavg = $(this).val();
    var fabavg = $(this).closest('td').find(".fabavg").text();
    $(this).closest('td').find(".avgdiff").text(eval(fabavg - orderavg).toFixed(2));
    var qty = $(this).closest('tr').find(".sqty").text();
    var metrageORD = eval(qty * orderavg);
    var stot = $(".s_totqty").text();
    var faborderqty = $(".fabfinalorder").val();
    var metrageorderqty = (eval(metrageORD) / eval(stot)) * eval(faborderqty);
    $(this).closest('td').find(".fabqty").text(eval(metrageorderqty.toFixed(2)));
    var orderprice = $(this).closest('td').find(".orderprice").val();
    var fabprice = $(this).closest('td').find(".fabprice").text();
    var fabqty = $(this).closest('td').find(".fabqty").text();
    var fabwastage = $(".fabwastage").text();
    var orderwastage = $(".orderwastage").val();
    var calPLfab = eval((fabavg * fabprice) * (1 + fabwastage / 100));
    var calPLorder = eval((orderavg * orderprice) * (1 + orderwastage / 100));
    var calPl = eval(calPLfab - calPLorder) * eval(qty);
    $(this).closest('td').find(".lk").text(eval(calPl.toFixed(2)));
    var budget = orderavg * orderprice * fabqty;
    $(this).closest('tr').find(".budget").text(budget.toFixed(2));
    $(this).closest('tr').find(".totallk").text(caladdqty($(this).closest('tr').find(".lk")));
    });
   
    $(".orderprice").change(function () {
    var orderprice = $(this).val();
    var fabprice = $(this).closest('td').find(".fabprice").text();
    $(this).closest('td').find(".pricediff").text(eval(fabprice - orderprice));
    var fabavg = $(this).closest('td').find(".fabavg").text();
    var orderavg = $(this).closest('td').find(".orderavg").val();
    var qty = $(this).closest('tr').find(".sqty").text();
    var fabwastage = $(".fabwastage").text();
    var orderwastage = $(".orderwastage").val();
    var calPLfab = eval((fabavg * fabprice) * (1 + fabwastage / 100));
    var calPLorder = eval((orderavg * orderprice) * (1 + orderwastage / 100));
    var calPl = eval(calPLfab - calPLorder) * eval(qty);
    $(this).closest('td').find(".lk").text(eval(calPl.toFixed(2)));
    var orderprice = $(this).closest('td').find(".orderprice").val();
    var fabqty = $(this).closest('td').find(".fabqty").text();
    var budget = orderavg * orderprice * fabqty;
    $(this).closest('tr').find(".budget").text(budget.toFixed(2));
    $(this).closest('tr').find(".totallk").text(caladdqty($(this).closest('tr').find(".lk")));
    });
    */
    //onStyleChange();
    $('#' + txtStyleNumberClientID).autocomplete("/Webservices/iKandiService.asmx/SuggestStyleNumber", { dataType: "xml", datakey: "string", max: 100 });

    /*
    1.on style text change get data from costing sheet .
    2.fill contract info based on costing sheet.
    3.fill fabric detail based on costing sheet.
    4.fill accessories detail based on costing sheet.
     
    */
    //    jQuery(document).on('#' + txtStyleNumberClientID, 'change',
    //     function () {
    //         alert('sushil');
    //     });

    function hello() {
        alert('hello');
    }



    function sumofAccProfitLoss() {
        var tds = $('#acccaltable').closest('table').find('td');
        for (var i = 2; i < tds.length - 2; i++) {
            //alert(caladdqty($(Enumerable.From($(accrate).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));
            $(Enumerable.From($('#acccaltable').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.sumprofitloss').text(caladdqty($(Enumerable.From($('#acccaltable').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));

        }
    }

    function Accsessoriescalculation(accrate) {
        $(accrate).closest('tr').find(".totalorderdqty").text(caladdqty($(accrate).closest('tr').find(".orderedqty")));
        $(accrate).closest('tr').find(".totalprofitloss").text(caladdqty($(accrate).closest('tr').find(".profitloss")));
        $(accrate).closest('tr').find(".accbudget").text(CalACCBudget($(accrate).closest('tr').find(".totalorderdqty").text(), $(accrate).closest('tr').find(".orderrate").val()));
        $(".sumtotalprofitloss").text(addqty("totalprofitloss"));
        $(".sumaccbudget").text(addqty("accbudget"));
    }


    function changeorderaccRate(accrate) {

        var accorderprice = $(accrate).val();
        var accssrate = $(accrate).closest('td').find(".accrate").text();
        $(accrate).closest('td').find(".ratediff").text(eval(accssrate - accorderprice).toFixed(2));
        var accqty = $(accrate).closest('tr').find(".accqty").text();
        var accorderqty = $(accrate).closest('tr').find(".orderqty").val();
        var orderwst = $(accrate).closest('tr').find(".orderwst");
        var accwst = $(accrate).closest('tr').find(".accwst");
        var itemwst = $(accrate).closest('tr').find(".itemwst");
        var enterqty = $(accrate).closest('table').find(".s_qty");
        var resultval = $(accrate).closest('tr').find(".profitloss");
        var resultsumval = $(accrate).closest('table').find(".sumprofitloss");
        var tr = $(accrate).closest('tr');
        for (var i = 0; i < resultval.length; i++) {
            //debugger;
            var costingval = CalACCprive(accssrate, accqty, $(accwst[i]).text(), $(itemwst[i]).val());
            var orderval = CalACCprive(accorderprice, accorderqty, $(orderwst[i]).val(), $(itemwst[i]).val());
            $(resultval[i]).text(eval((costingval - orderval) * $(enterqty[i]).text()).toFixed(2));

            //var tds = Enumerable.From($(tr).closest('table').find('td')).Where('x=>x.cellIndex==' + i);
            //alert(caladdqty($(Enumerable.From($(accrate).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));
            // alert(caladdqty($(Enumerable.From($(tr).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));
            // $(tr).closest('table').find('.sumprofitloss').text(caladdqty($(Enumerable.From($(tr).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));
            //$(Enumerable.From($(tr).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.sumprofitloss').text(caladdqty($(Enumerable.From($(tr).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));
        }

        //        var tds = $(accrate).closest('table').find('td');
        //        for (var i = 2; i < tds.length - 2; i++) {
        //            //alert(caladdqty($(Enumerable.From($(accrate).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));
        //            $(Enumerable.From($(tr).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.sumprofitloss').text(caladdqty($(Enumerable.From($(tr).closest('table').find('td').toArray()).Where('x=>x.cellIndex==' + i).ToArray()).find('.profitloss')));


        //        }

        sumofAccProfitLoss();
        Accsessoriescalculation(accrate);

        /*
        $(accrate).closest('tr').find(".totalorderdqty").text(caladdqty($(accrate).closest('tr').find(".orderedqty")));
        $(accrate).closest('tr').find(".totalprofitloss").text(caladdqty($(accrate).closest('tr').find(".profitloss")));
        $(accrate).closest('tr').find(".accbudget").text(CalACCBudget($(accrate).closest('tr').find(".totalorderdqty").text(), $(accrate).closest('tr').find(".orderrate").val()));      
        $(".sumtotalprofitloss").text(addqty("totalprofitloss"));
        $(".sumaccbudget").text(addqty("accbudget"));
        */
    }

    function changeorderaccqty(orderqty) {
        var accorderqty = $(orderqty).val();
        var accssqty = $(orderqty).closest('td').find(".accqty").text();
        $(orderqty).closest('td').find(".qtydiff").text(eval(accssqty - accorderqty).toFixed(2));
        var orderwst = $(orderqty).closest('tr').find(".orderwst");
        var accwst = $(orderqty).closest('tr').find(".accwst").text();
        var itemwst = $(orderqty).closest('tr').find(".itemwst");
        var enterqty = $(orderqty).closest('table').find(".s_qty");
        var resultqty = $(orderqty).closest('tr').find(".orderedqty");
        for (var i = 0; i < resultqty.length; i++) {
            $(resultqty[i]).text((Calcorderdqty(accorderqty, $(orderwst[i]).val(), $(itemwst[i]).val(), $(enterqty[i]).text())));
        }

        sumofAccProfitLoss();
        Accsessoriescalculation(orderqty);
        /*
        $(orderqty).closest('tr').find(".totalorderdqty").text(caladdqty($(orderqty).closest('tr').find(".orderedqty")));
        $(orderqty).closest('tr').find(".totalprofitloss").text(caladdqty($(orderqty).closest('tr').find(".profitloss")));
        $(orderqty).closest('tr').find(".accbudget").text(CalACCBudget($(orderqty).closest('tr').find(".totalorderdqty").text(), $(orderqty).closest('tr').find(".orderrate").val()));  
       
        $(".sumtotalprofitloss").text(addqty("totalprofitloss"));
        $(".sumaccbudget").text(addqty("accbudget"));
        */
    }

    function Calcorderdqty(qty, cutwast, itemwast, itemqty) {

        return eval(qty * (1 + (cutwast / 100) + (itemwast / 100)) * itemqty).toFixed(2);

    }

    function CalACCprive(rate, qty, cutwast, itemwast) {

        return eval(rate * qty * (1 + (cutwast / 100) + (itemwast / 100))).toFixed(2);

    }

    function CalACCBudget(Calcorderdqty, orderprice) {

        return eval(Calcorderdqty * orderprice).toFixed(2);

    }

    function changeorderitemwastage(itemwast) {
        var orderitemwast = $(itemwast).val();
        var ordercuwast = $(itemwast).closest('td').find(".orderwst").val();
        var orderqty = $(itemwast).closest('tr').find(".orderqty").val();
        var index = $(itemwast).closest('td').index();
        var enterqty = $(itemwast).closest('table').find('td').eq(index).find(".s_qty").text();
        var accorderdqty = Calcorderdqty(orderqty, ordercuwast, orderitemwast, enterqty);
        $(itemwast).closest('td').find(".orderedqty").text(eval(accorderdqty).toFixed(2));
        $(itemwast).closest('tr').find(".totalorderdqty").text(caladdqty($(itemwast).closest('tr').find(".orderedqty")));
        $(itemwast).closest('tr').find(".totalprofitloss").text(caladdqty($(itemwast).closest('tr').find(".profitloss")));
        $(itemwast).closest('tr').find(".accbudget").text(CalACCBudget($(itemwast).closest('tr').find(".totalorderdqty").text(), $(itemwast).closest('tr').find(".orderrate").val()));
        sumofAccProfitLoss();

        Accsessoriescalculation(itemwast);
        /*
        $(".sumtotalprofitloss").text(addqty("totalprofitloss"));
        $(".sumaccbudget").text(addqty("accbudget"));
        */
    }

    function changeorderacccutwastage(cuwast) {
        var ordercuwast = $(cuwast).val();
        var costcutwast = $(cuwast).closest('td').find(".accwst").text();
        $(cuwast).closest('td').find(".wstdiff").text(eval(costcutwast - ordercuwast).toFixed(2));
        var itemwast = $(cuwast).closest('td').find(".itemwst").val();
        var orderqty = $(cuwast).closest('tr').find(".orderqty").val();
        var enterqty = $(cuwast).closest('table').find('td').eq(index).find(".s_qty").text();
        var accorderdqty = Calcorderdqty(orderqty, ordercuwast, itemwast, enterqty);
        $(cuwast).closest('td').find(".orderedqty").text(eval(accorderdqty).toFixed(2));
        $(cuwast).closest('tr').find(".totalorderdqty").text(caladdqty($(cuwast).closest('tr').find(".orderedqty")));
        $(cuwast).closest('tr').find(".totalprofitloss").text(caladdqty($(cuwast).closest('tr').find(".profitloss")));
        $(cuwast).closest('tr').find(".accbudget").text(CalACCBudget($(cuwast).closest('tr').find(".totalorderdqty").text(), $(cuwast).closest('tr').find(".orderrate").val()));
        sumofAccProfitLoss();
        Accsessoriescalculation(cuwast);
        /*
        $(".sumtotalprofitloss").text(addqty("totalprofitloss"));
        $(".sumaccbudget").text(addqty("accbudget"));

        */
    }



    function avgchange(clsavg) {

        var orderavg = $(clsavg).val();
        var fabavg = $(clsavg).closest('td').find(".fabavg").text();
        $(clsavg).closest('td').find(".avgdiff").text(eval(fabavg - orderavg).toFixed(2));
        var qty = $(clsavg).closest('tr').find(".sqty").text();
        var metrageORD = eval(qty * orderavg);
        var stot = $(".s_totqty").text();
        var faborderqty = $(".fabfinalorder").val();
        var metrageorderqty = (eval(metrageORD) / eval(stot)) * eval(faborderqty);
        $(clsavg).closest('td').find(".fabqty").text(eval(metrageorderqty.toFixed(2)));
        var orderprice = $(clsavg).closest('td').find(".orderprice").val();
        var fabprice = $(clsavg).closest('td').find(".fabprice").text();
        var fabqty = $(clsavg).closest('td').find(".fabqty").text();
        var fabwastage = $(".fabwastage").text();
        var orderwastage = $(".orderwastage").val();
        var calPLfab = eval((fabavg * fabprice) * (1 + fabwastage / 100));
        var calPLorder = eval((orderavg * orderprice) * (1 + orderwastage / 100));
        var calPl = eval(calPLfab - calPLorder) * eval(qty);
        $(clsavg).closest('td').find(".lk").text(eval(calPl.toFixed(2)));
        var budget = orderavg * orderprice * fabqty;
        $(clsavg).closest('tr').find(".budget").text(budget.toFixed(2));
        $(clsavg).closest('tr').find(".totallk").text(caladdqty($(clsavg).closest('tr').find(".lk")));
        $(".sumprofit").text(addqty("totallk"));
        $(".sumdudget").text(addqty("budget"));
    }

    function orderpricechange(clsprice) {
        var orderprice = clsprice.val();
        var fabprice = clsprice.closest('td').find(".fabprice").text();
        clsprice.closest('td').find(".pricediff").text(eval(fabprice - orderprice));
        var fabavg = clsprice.closest('td').find(".fabavg").text();
        var orderavg = clsprice.closest('td').find(".orderavg").val();
        var qty = clsprice.closest('tr').find(".sqty").text();
        var fabwastage = $(".fabwastage").text();
        var orderwastage = $(".orderwastage").val();
        var calPLfab = eval((fabavg * fabprice) * (1 + fabwastage / 100));
        var calPLorder = eval((orderavg * orderprice) * (1 + orderwastage / 100));
        var calPl = eval(calPLfab - calPLorder) * eval(qty);
        clsprice.closest('td').find(".lk").text(eval(calPl.toFixed(2)));
        var orderprice = clsprice.closest('td').find(".orderprice").val();
        var fabqty = clsprice.closest('td').find(".fabqty").text();
        var budget = orderavg * orderprice * fabqty;
        clsprice.closest('tr').find(".budget").text(budget.toFixed(2));
        clsprice.closest('tr').find(".totallk").text(caladdqty(clsprice.closest('tr').find(".lk")));
        $(".sumprofit").text(addqty("totallk"));
        $(".sumdudget").text(addqty("budget"));
    }

    function addRow() {

        var html = '<tr>' +
                    '<td>Name: <input type="text" id="txtName"></td>' +
                    '<td><input type="button" class="BtnPlus" value="+" /></td>' +
                    '<td><input type="button" class="BtnMinus" value="-" /></td>' +
                    '</tr>'
        $(html).appendTo($(".tblcontect"))
    };
    //$(".BtnPlus").click(addRow);
    function addnewrow() {
        // alert($(this));
    };

    //        $(".BtnPlus").click(
    //        addnewrow
    //        );


    //  $('#' + txtStyleNumberClientID).on("change", onStyleChange());

});

function addRow_new(srcElem) {
    //  alert(srcElem);
    contactRow = $('.tblcontect tr').length;
    var objRow = $(srcElem).parents("tr");
    var objTable = $(objRow).parents("table").attr("id");
    var tableBody = $('.tblcontect > tbody'),
    // we will need to clone the last row, else we will be simply pointing to the same row. By not cloning it, we are simply moving the last row to the last row.
     lastRowClone = $('tr:last-child', tableBody).clone();
    // clear the values in the text field.
    $('input[type=text]', lastRowClone).val('');
    // and finally we append the row after the last row.
   // tableBody.append(lastRowClone);
    $('.tblcontect tr').eq(1).after(lastRowClone);
    lineno = (objRow.find("td:eq(0) .txtline").val());
    Contact = (objRow.find("td:eq(0) .txtcontract").val());
    qty = (objRow.find("td:eq(2) .txtqty").val());
    //alert(lineno);
};

function addACCRow(srcelm) {
    var tableBody = $('.acctable > tbody'),
    // we will need to clone the last row, else we will be simply pointing to the same row. By not cloning it, we are simply moving the last row to the last row.
        lastRowClone = $($('.acctable tr').eq(1), tableBody).clone();
    // and finally we append the row after the last row.
    $('input[type=text]', lastRowClone).val('');
    $('.acctable tr:first').after(lastRowClone)
};


function addfabricrow() {
    // $('#MyTable tr:last').after("<tr><td>new row</td></tr>")
   // debugger;
    //alert('hi');
//    var count = $(".fabtable").find("tr:first td").length;
//    alert(count);
//    var row = $('.fabtable tr:last').after("<tr></tr>");
//    for (var j = 0; j < count; j++) {
//        $('.fabtable tr:last').append("<td>new row</td>")
//        //$('<td></td>').text("text1").appendto(row);
    //    }

    var rowCount = $('.fabtable tr').length;
    if (contactRow > 3) {
        var tableBody = $('.fabtable > tbody'),
        // we will need to clone the last row, else we will be simply pointing to the same row. By not cloning it, we are simply moving the last row to the last row.
        lastRowClone = $($('.fabtable tr').eq(1), tableBody).clone();
        $('input[type=text]', lastRowClone).val('');
        // and finally we append the row after the last row.
        $('.fabtable tr:first').after(lastRowClone)
        // tableBody.append(lastRowClone);
        //alert(lineno);
        }
        var currentrow = $('.fabtable tr').eq(1);
       // alert(currentrow);
        currentrow.find('.s_lineno').text(lineno);
        currentrow.find('.s_contact').text(Contact);
        currentrow.find('.s_qty').text(qty);
        var totqty = parseInt($('.fabtable tr td').find('.s_totqty').text()) + parseInt(qty);
       // alert(totqty);
        $('.fabtable tr td').find('.s_totqty').text(totqty);
    };

    function addFabcolumn_StyleBy(t) {
       // debugger;
        // alert('hello');
        // alert($('#MyTable').html());
        var objRow = $(srcElem).parents("tr");
        var fabcount = 1;
        while (fabcount < t) {
            var count = $(".fabtable").find("tr:first td").length;
           
            if (count < 10) {
                $('.fabtable').find("tr").each(function () {
                    $(this).find('td').eq(count - 3).after($($(this).find('td').eq(count - 3)).clone());
                });
            }
            fabcount ++;
        }
        //  alert('hello2');
    };
    function addFabcolumn(srcElem) {
       // debugger;
        // alert('hello');
        // alert($('#MyTable').html());
        var objRow = $(srcElem).parents("tr");

        var count = $(".fabtable").find("tr:first td").length;
        // alert(count);
        if (count < 8) {
            $('.fabtable').find("tr").each(function () {
                lastRowClone = $($(this).find('td').eq(count-3)).clone();
             $('input[type=text]', lastRowClone).val('');
             $(this).find('td').eq(count - 3).after(lastRowClone);
            });
        }
        //  alert('hello2');
    };
function addAcccolumn() {
   // debugger;
    // alert('hello');
    // alert($('#MyTable').html());
    var count = $(".acctable").find("tr:first td").length;
   
    if (contactRow > 3) {
        // alert(count);
        if (count < 10) {
            $('.acctable').find('tr').each(function () {
                lastRowClone = $($(this).find('td').eq(count - 4)).clone();
                $('input[type=text]', lastRowClone).val('');
                $(this).find('td').eq(count - 4).after(lastRowClone);
            });
        }
    }
    //  alert('hello2');
};
/*
function addFabRow_new(srcElem) {
    alert(srcElem);
    var objRow = $(srcElem).parents("tr");
    var objTable = $(objRow).parents("table").attr("id");
    var tableBody = $('.fabriccontract > tbody'),
    // we will need to clone the last row, else we will be simply pointing to the same row. By not cloning it, we are simply moving the last row to the last row.
     lastRowClone = $('tr:last-child', tableBody).clone();
    // clear the values in the text field.
    $('input[type=text]', lastRowClone).val('');
    // and finally we append the row after the last row.
    tableBody.append(lastRowClone);

};

function addaccRow_new(srcElem) {
    alert(srcElem);
    var objRow = $(srcElem).parents("tr");
    var objTable = $(objRow).parents("table").attr("id");
    var tableBody = $('.accessories > tbody'),
    // we will need to clone the last row, else we will be simply pointing to the same row. By not cloning it, we are simply moving the last row to the last row.
    lastRowClone = $('tr:last-child', tableBody).clone();
    // clear the values in the text field.
    $('input[type=text]', lastRowClone).val('');
    // and finally we append the row after the last row.
    tableBody.append(lastRowClone);
};

*/
function removerow(srcElem) {
  //  alert($(srcElem));
    // e.preventDefault();
    // find out the row that current link resides in, and remove it.
    var row = $(srcElem).parent().parent().parent();
    row.remove();
};

function removeFabrow(srcElem) {
  //  alert($(srcElem));
    // e.preventDefault();
    // find out the row that current link resides in, and remove it.
    var row = $(srcElem).parent().parent().parent();
    row.remove();
};

function savedata(srlelm) {
  //  debugger;
  //  alert('savemethod');
    var styleinfo = [];
    var style = {};
    style.currdate = $('.txtorderdate').text();
    style.styleno = $('.txtstyleno').val();
    style.buyer = $('.ddlbuyer').val();
    style.Dpack = $('.ddlpack').val();
    style.des = $('.txtdes').val();
    style.biplprice = $('.txtbiplprice').val();
    style.totqty = $('.txttotalqty').val();
    style.sno = $('.txtstyleno').val();
    style.dprt = $('.ddldprt').val();
    style.accmgr = $('.txtaccmgr').text();
   // alert(style.toString());

    var contractinfo = [];
    $(".tblcontect tr").each(function () {
        if ($(this).find("td").length > 0) {
            var contract = {};
           // Sea.ID = $(this).closest('tr').attr('id'); // ($(this).find("td:eq(0)").text());
            contract.lineno = ($(this).find("td:eq(0) .txtline").val());
            contract.contract = ($(this).find("td:eq(0) .txtcontract").val());
            contract.qty = ($(this).find("td:eq(2) .txtqty").val());
            contract.mode = ($(this).find("td:eq(3) .mode").val());
            contract.ikandiprice = ($(this).find("td:eq(4) .ikandiprice").val());
            contract.Exfactory = ($(this).find("td:eq(5) .exfactory").text());
            contract.dcdate = ($(this).find("td:eq(5) .dcdate").val());
            contract.Exweek = ($(this).find("td:eq(6) .Exweek").text());
            contract.Dcweek = ($(this).find("td:eq(6) .Dcweek").text());
            contractinfo.push(contract);
        }
    });

    // alert(contractinfo.toString());

    /*
    var eArrSea = [];
    var eArrAir = [];
    var eArrDirect = [];
    */
    /*
    $("#ContentPlaceHolder1_tblsea tr").each(function () {
        if ($(this).find("td").length > 0) {
            var Sea = {};
            Sea.ID = $(this).closest('tr').attr('id'); // ($(this).find("td:eq(0)").text());
            Sea.uptoport = ($(this).find("td:eq(2) .rate").val());
            Sea.seailing = ($(this).find("td:eq(3) .rate").val());
            Sea.clearance = ($(this).find("td:eq(4) .rate").val());
            Sea.process = ($(this).find("td:eq(5) .rate").val());
            Sea.ischecked = 0;
            if ($(this).find("td:eq(7) .ischeck").is(":checked")) {
                Sea.ischecked = 1;
            }
            eArrSea.push(Sea);
        }
    });
    $("#ContentPlaceHolder1_tblair tr").each(function () {
        if ($(this).find("td").length > 0) {
            var Air = {};
            Air.ID = $(this).closest('tr').attr('id'); // ($(this).find("td:eq(0)").text());
            Air.uptoport = ($(this).find("td:eq(2) .rate").val());
            Air.seailing = ($(this).find("td:eq(3) .rate").val());
            Air.clearance = ($(this).find("td:eq(4) .rate").val());
            Air.process = ($(this).find("td:eq(5) .rate").val());
            Air.ischecked = 0;
            if ($(this).find("td:eq(7) .ischeck").is(":checked")) {
                Air.ischecked = 1;
            }
            eArrAir.push(Air);
        }
    });
    $("#ContentPlaceHolder1_tblDirect tr").each(function () {
        if ($(this).find("td").length > 0) {
            var Directmode = {};
            Directmode.uptoport = ($(this).find("td:eq(1) .rate").val());
            Directmode.handover = ($(this).find("td:eq(2) .rate").val());
            Directmode.sailing = ($(this).find("td:eq(3) .rate").val());
            Directmode.ischecked = 0;
            if ($(this).find("td:eq(5) .ischeck").is(":checked")) {
                Directmode.ischecked = 1;
            }
            eArrDirect.push(Directmode);
        }
    });
    var DTO_eArrSea = { 'Sea_DT': eArrSea };
    var DTO_eArrAir = { 'Air_DT': eArrAir };
    var DTO_eArrDirect = { 'Direct_DT': eArrDirect };
    var check = 'off';

    if ($("#" + Ischkcheck).is(":checked")) {
        check = 'on';
    }

    if (AlertMsg('ddl', $("#" + city_ddl).val(), City_m_Res) == false) {
        return false;
    }
    if (AlertMsg('txt', $("#" + destination).val(), Destination_m_Res) == false) {
        return false;
    }
    if (AlertMsg('txt', $("#" + txteffective_date).val(), EffectiveDate_m_Res) == false) {
        return false;
    }
    if (!fncComparedate(txteffective_date, ''))
        return false;
    Add_Method_data(eArrSea, eArrAir, eArrDirect, edit_ID, $("#" + city_ddl).val(), $("#" + destination).val(), check, $("#" + txteffective_date).val());
    $('.add_method').html('Add');
    edit_ID = 0;
    $("#" + destination).val('');
    $("#" + txteffective_date).val('')
    $("#" + Ischkcheck).removeAttr('checked', 'checked');
    $("#" + lbllastupdate).html('');
    $("#" + city_ddl).val(-1).attr('selected', 'selected');
    bindLanded_Sea_Table();
    bindDirectMode_Table();
    */

};

function bindclientmode(clientid) {
    debugger;
    proxy.invoke("GetAllDeliveryModes", { ClientID: clientid },
        function (result) {
            // alert(result);

            if (result.length > 0) {
                 $('.tblcontect tr').eq(1).find('.mode').empty();
                alert(result.length);
                for (var i = 0; i < result.length; i++) {
                    $('.tblcontect tr').eq(1).find('.mode').append($("<option></option>").val(result[i].Id).html(result[i].Code));
                }

            }

        }, null, false, false);
}


function onModeChange(srcElem) {
    //alert;
     alert('onModeChange');

    debugger;
    var objRow = $(srcElem).parents("tr");
    var i = objRow.get(0).rowIndex;
//    if ($(srcElem).val() == -1) {
//        $("#hdnMode" + i).val("");
//    }
    if ($(srcElem).val() != -1) {
        // var ddl = $('#ddlMode' + i, "#main_content");
        //debugger;
        var selectedValue = $(srcElem).val();
        var selectedText = $(srcElem).find("option:selected").text();

        if (i == 1) {
            if (selectedText.indexOf('/H') > -1) {
                $("#" + txtDelInstructionClientID, "#main_content").text("Hanging");
            }
            else if (selectedText.indexOf('/BH') > -1) {
                $("#" + txtDelInstructionClientID, "#main_content").text("Hanging");
            }

            else {

                $("#" + txtDelInstructionClientID, "#main_content").text("Flat");
            }
            proxy.invoke("GetOrderPackingType", { modeValue: $(srcElem).val() },
                        function (result) {
                            alert(result);
                            $('#' + objDDLTypeOfPacking).val(result);
                        });                       
        }


        var oo = selectedText;
        if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(FOB)') > -1) {         

        }

        if (selectedText.indexOf('A/F') > -1) {
            strmode = "AF";
        }

        else if (selectedText.indexOf('A/H') > -1) {
            strmode = "AH";
        }

        else if (selectedText.indexOf('S/F') > -1) {
            strmode = "SF";
        }
        else if (selectedText.indexOf('S/H') > -1) {
            strmode = "SH";
        }
        else if (selectedText.indexOf('S/BH') > -1) {
            strmode = "SH";
        }
        else if (selectedText.indexOf('A/BH') > -1) {
            strmode = "AH";
        }
        //var rowCount = $("#" + tableOrderDetailVar + " tr").filter(":not(.size-table tr)").length - 2;

        var costingId = $("#" + hdnCostingIdClientID).val();

        if (selectedText.indexOf("D") > -1) {
          //  $("#" + txtDeliverToClientID).val($("#" + hdnAddressClientID).val());
            strmode = "FOB";
        }
//         else {
//            $("#" + txtDeliverToClientID, "#main_content").val("iKandi");
//        }

        var tempVar = '';
        if (selectedText.indexOf('FACT') > -1) {
           strmode = "Fact";

        }

        ///////////// first
        //debugger;
      //  $("#hdnMode" + i, "#main_content").val(strmode);
        //debugger;
        //   debugger;

        if ($("#" + hdnOrderIdClientID).val() == -1) {
            //    alert('First' + '-----' + strmode);
            if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(FOB)') > -1) {

                if (CheckFistTime == 'False') {
                    if (confirm('Do you wish to update price.')) {
                        proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: tempVar },
                    function (result) {

                        //    alert('1 : ' + 'mode= ' + strmode + '  costing Id ' + costingId + 'BIPL Value' + +parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        $(srcElem).closest('tr').find('.ikandiprice').val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                    });
                    }
                }
                else {
                    proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: tempVar },
                    function (result) {

                        $(srcElem).closest('tr').find('.ikandiprice').val(parseFloat(result.Costing.iKandiPrice).toFixed(2));
                    });
                }

            }

            else {

                proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: tempVar },
                    function (result) {
                        $(srcElem).closest('tr').find('.ikandiprice').val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                    });

            }



        }

        ///////////// first end 



        //Start second

        else if ($("#" + hdnOrderIdClientID).val() > 0) {

          

            if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(FOB)') > -1) {


                if (confirm('Do you wish to update price.')) {
                    proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: tempVar },
                        function (result) {
                            $(srcElem).closest('tr').find('.ikandiprice').val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        });

                }

            }

            else {

                if (selectedText.indexOf('L') > -1 && selectedText.indexOf('(CIF)') > -1) {
                    var tempvar = 100;
                }

                else {
                    proxy.invoke("GetIkandiPriceByMode", { Mode: strmode, CostingID: costingId, status: tempVar },
                        function (result) {
                            $(srcElem).closest('tr').find('.ikandiprice').val(parseFloat(result.Costing.iKandiPrice).toFixed(2));

                        });
                                        }

            }


        }

        //End second


        if ($("#" + hdnOrderIdClientID).val() == -1) {

            CalculateDeliveryDate(strmode, i, selectedValue, srcElem);

        }

      

        if ($("#" + hdnOrderIdClientID).val() > -1) {
        //debugger;

        proxy.invoke("GetModeDays", { modeValue: selectedValue },
        function (result) {
            calculateExFactoryDate(i, result, srcElem);
            calculateExWeeks(i,srcElem);

        });

        }

       

    }

}

function CalculateDeliveryDate(strmode, i, selectedValue, Elem) {
    debugger;
    var mode = selectedValue;
    proxy.invoke("GetDefaultLeadTime", { mode: mode },
         function (LeadTime) {
             var dd = new Date(ParseDateToSimpleDate($("#" + hdnExpectedDateClientID).val()));
             dd = dd.add(parseInt(LeadTime) * 7).days();
            // $("#txtDC" + i).val(ParseDateToDateWithDay(dd));
             $(Elem).closest('tr').find('.dcdate').val(ParseDateToDateWithDay(dd));
             proxy.invoke("GetModeDays", { modeValue: selectedValue },
                    function (result) {
                        calculateExFactoryDate(i, result, Elem);
                        calculateExWeeks(i, Elem);
                    });
         });

            }

            function calculateExFactoryDate(i, days,Elem,doNotChangeExFacIfSmall) {
                debugger;
                var DCDate = $(Elem).closest('tr').find('.dcdate').val();//  $("#txtDC" + i, "#main_content").val();
                var ExFacDate;
                if (DCDate.length > 0) {
                    var dc_dat = new Date(ParseDateToSimpleDate(DCDate));
                    var ExFacDate = dc_dat.add(-1 * parseInt(days)).days();
                    if (!doNotChangeExFacIfSmall || (doNotChangeExFacIfSmall && ExFacDate > new Date(ParseDateToSimpleDate($("#hdnExFactory" + i, "#main_content").val())))) {
                        ExFacDate = ParseDateToDateWithDay(ExFacDate);
                       // $("#txtExFactory" + i, "#main_content").val(ExFacDate);
                        $(Elem).closest('tr').find('.exdate').val(ExFacDate);
                    }
                    else {
                        ExFacDate = $("#txtExFactory" + i, "#main_content").val($("#hdnExFactory" + i, "#main_content").val());
                        ExFacDate = ParseDateToDateWithDay(ExFacDate);
                    }

                }

            }

            function calculateExWeeks(i, Elem) {
                var msPERDAY = 1000 * 60 * 60 * 24 * 7;
                var dateEx = $(Elem).closest('tr').find('.exdate').val(); // $("#txtExFactory" + i, "#main_content").val();
                var orderDate = $("#" + txtOrderDateClientID, "#main_content").text();
                var DCDate = $(Elem).closest('tr').find('.dcdate').val();// $("#txtDC" + i, "#main_content").val();
                if (DCDate.length > 0) {
                    var or_dat = new Date(ParseDateToSimpleDate(orderDate));
                    var ex_date = new Date(ParseDateToSimpleDate(dateEx));
                    var dc_dat = new Date(ParseDateToSimpleDate(DCDate));
                    dcdate = dc_dat.getTime();
                    ordate = or_dat.getTime();
                    exdate = ex_date.getTime();
                    var diffex = new Date();
                    diffex.setTime(Math.abs(exdate - ordate));
                    timediffex = diffex.getTime();  
                    weeksEx = Math.floor(timediffex / msPERDAY);
                    $(Elem).closest('tr').find('.Exweek').text(weeksEx); // $("#txtWeeksToEx" + i, "#main_content").val(weeksEx);
                    var diffdc = new Date();
                    diffdc.setTime(Math.abs(dcdate - ordate));
                    timediffdc = diffdc.getTime();
                    weeksDc = Math.floor(timediffdc / msPERDAY);
                    $(Elem).closest('tr').find('.Dcweek').text(weeksDc); // $("#txtWeeksToDC" + i, "#main_content").val(weeksDc);
                }

            }



function GetFabricWorking_data(orderid) { 
//alert('sushil');

//debugger;
proxy.invoke("GetFabricWorking_data", { Orderid: orderid },
        function (result) {
           // alert(result);
            if (result.length > 0) {
                $(".fabtable").find("tr:first td").eq(2).find('.fabwidth').text(result.Fabric1InitialWidth);
                $(".fabtable").find("tr:first td").eq(3).find('.fabwidth').text(result.Fabric2InitialWidth);
                $(".fabtable").find("tr:first td").eq(4).find('.fabwidth').text(result.Fabric2InitialWidth);
                $(".fabtable").find("tr:first td").eq(5).find('.fabwidth').text(result.Fabric2InitialWidth);

            }

        }, null, false, false);

       // GetFabricWorking_data($("#" + hdnOrderIdClientID).val());

};




function GetOrderfabricDetail(orderid) {
//alert(orderid);

//debugger;
proxy.invoke("GetOrderDetailByIdOrderForm_s", { Orderid: orderid },
        function (result) {
           // alert('abc');
           // alert(result);
           // alert(result.order.OrderBreakdown.length > 0);
          //  debugger;
 if (result.order.OrderBreakdown.length > 0) {
            $('.tblcontect tr').eq(1).find('.txtline').val(result[0].LineItemNumber);
            $('.tblcontect tr').eq(1).find('.txtcontract').val(result[0].ContractNumber);
            $('.tblcontect tr').eq(1).find('.exdate').val(result[0].ExFactory);
            $('.tblcontect tr').eq(1).find('.txtqty').val(result[0].Quantity);
            $('.tblcontect tr').eq(1).find('.dcdate').val(result[0].DC);
            $('.tblcontect tr').eq(1).find('.ikandiprice').val(result[0].iKandiPrice);
            $('.tblcontect tr').eq(1).find('.Exweek').text(result[0].WeekToEx);
            $('.tblcontect tr').eq(1).find('.Dcweek').text(result[0].WeeksToDC);
            for (var i = 1; i < result.length; i++) {
            //  alert(result[i].Fabric1);
            var tableBody = $('.tblcontect > tbody');
            lastRowClone = $('tr:last-child', tableBody).clone();
            // clear the values in the text field.
            $('input[type=text]', lastRowClone).val('');
            $('.txtline', lastRowClone).val(result[i].LineItemNumber);
            $('.txtcontract', lastRowClone).val(result[i].ContractNumber);
            $('.exdate', lastRowClone).val(result[i].ExFactory);
            $('.txtqty', lastRowClone).val(result[i].Quantity);
            $('.dcdate', lastRowClone).val(result[i].DC);
            $('.ikandiprice', lastRowClone).val(result[i].iKandiPrice);
            $('.Exweek', lastRowClone).text(result[1].WeekToEx);
            $('.Dcweek', lastRowClone).text(result[1].WeeksToDC);

            // and finally we append the row after the last row.
            // tableBody.append(lastRowClone);
            $('.tblcontect tr:last').after(lastRowClone);


            }
            }

          
        }, null, false, false);
};


function getorderAccDetail(orderid) {
    proxy.invoke("GetOrderAccDetail", { Orderid: orderid },
        function (result) {
            // alert(result);
          //  debugger;
            if (result.length > 0) {
                //alert(result[0].Quantity);
                $('.acctable tr').eq(1).find('.accitem').text(result[0].AccItem);
                $('.acctable tr').eq(1).find('.accrate').text(result[0].Rate);
                $('.acctable tr').eq(1).find('.accqty').text(result[0].Quantity);
                for (var i = 1; i < result.length; i++) {

                    var tableBodyfab = $('.acctable > tbody');
                    lastRowClone = $($('.acctable tr').eq(1), tableBodyfab).clone();
                    // $('input[type=text]', lastRowClone).val('');
                    $('.accitem', lastRowClone).text(result[i].AccItem);
                    $('.accrate', lastRowClone).text(result[i].Rate);
                    $('.accqty', lastRowClone).text(result[i].Quantity);
                    $('.acctable .Acctotal').before(lastRowClone);

                }
            }
        }, null, false, false);
}

function GetOrderDetail(orderid) {
    proxy.invoke("GetOrderByIdOrderForm", { OrderID: orderid },
        function (result) {
            // alert(result);
            $(".txtorderdate").text(result.OrderDate);
            $(".txttotalqty").val(result.TotalQuantity);
            $(".txtstyleno").val(result.Style.StyleNumber);
            $(".txtserialno").val(result.SerialNumber);
            $(".txtaccmgr").text(result.AccountManagerName);
            $(".txtdes").val(result.Description);
            $(".txtbiplprice").val(result.BiplPrice);

            $("#" + hdnCostingIdClientID, "#main_content").val(result.Costing.CostingID);

            var breackdown = result.OrderBreakdown;
            //alert(breackdown.length);
            GetOrderContractDetail_order(breackdown);
        }, null, false, false);
       // GetOrderContractDetail(orderid);
    }
     
// sushil this function recreate as name GetOrderContractDetail_order 
/*
function GetOrderContractDetail(orderid) {

    proxy.invoke("GetOrderDetailByIdOrderForm_s", { Orderid: orderid },
        function (result) {
            // alert(result);
           // debugger;
            if (result.length > 0) {
                $('.tblcontect tr').eq(1).find('.txtline').val(result[0].LineItemNumber);
                $('.tblcontect tr').eq(1).find('.txtcontract').val(result[0].ContractNumber);
                $('.tblcontect tr').eq(1).find('.exdate').val(result[0].ExFactory);
                $('.tblcontect tr').eq(1).find('.txtqty').val(result[0].Quantity);
                $('.tblcontect tr').eq(1).find('.dcdate').val(result[0].DC);
                $('.tblcontect tr').eq(1).find('.ikandiprice').val(result[0].iKandiPrice);
                $('.tblcontect tr').eq(1).find('.Exweek').text(result[0].WeekToEx);
                $('.tblcontect tr').eq(1).find('.Dcweek').text(result[0].WeeksToDC);
                var fabcount = 0;
                // alert(result[0].Fabric3.length);
                if (result[0].Fabric1.length > 0)
                { fabcount = fabcount + 1; }
                if (result[0].Fabric2.length > 0)
                { fabcount = fabcount + 1; }
                if (result[0].Fabric3.length > 0)
                { fabcount = fabcount + 1; }
                if (result[0].Fabric4.length > 0)
                { fabcount = fabcount + 1; }
                // alert(fabcount );
                if (fabcount > 0) {
                    var i = 1;
                    while (i < fabcount) {
                        var count = $(".fabtable").find("tr:first td").length;
                        if (count < 10) {
                            $('.fabtable').find("tr").each(function () {
                                $(this).find('td').eq(count - 3).after($($(this).find('td').eq(count - 3)).clone());
                            });
                        }
                        i++;
                    }
                }

                $(".fabtable").find("tr:first td").eq(2).find('.s_fabric1').val(result[0].Fabric1);
                $(".fabtable").find("tr:first td").eq(3).find('.s_fabric1').val(result[0].Fabric2);
                $(".fabtable").find("tr:first td").eq(4).find('.s_fabric1').val(result[0].Fabric3);
                $(".fabtable").find("tr:first td").eq(5).find('.s_fabric1').val(result[0].Fabric4);
                $(".fabtable").find("tr:first td").eq(2).find('.s_ccgsm').text(result[0].CCGSM1);
                $(".fabtable").find("tr:first td").eq(3).find('.s_ccgsm').text(result[0].CCGSM2);
                $(".fabtable").find("tr:first td").eq(4).find('.s_ccgsm').text(result[0].CCGSM3);
                $(".fabtable").find("tr:first td").eq(5).find('.s_ccgsm').text(result[0].CCGSM4);
                $('.fabtable tr').eq(1).find("td").eq(2).find('.fabprint').val(result[0].Fabric1Details);
                $('.fabtable tr').eq(1).find("td").eq(3).find('.fabprint').val(result[0].Fabric2Details);
                $('.fabtable tr').eq(1).find("td").eq(4).find('.fabprint').val(result[0].Fabric3Details);
                $('.fabtable tr').eq(1).find("td").eq(5).find('.fabprint').val(result[0].Fabric4Details);
                $('.fabtable tr').eq(1).find("td").eq(2).find('.fabqty').text(result[0].Fabric1Quantity);
                $('.fabtable tr').eq(1).find("td").eq(3).find('.fabqty').text(result[0].Fabric2Quantity);
                $('.fabtable tr').eq(1).find("td").eq(4).find('.fabqty').text(result[0].Fabric3Quantity);
                $('.fabtable tr').eq(1).find("td").eq(5).find('.fabqty').text(result[0].Fabric4Quantity);
                $('.fabtable tr').eq(1).find("td").eq(2).find('.fabavg').text(result[0].Fabric1Average);
                $('.fabtable tr').eq(1).find("td").eq(3).find('.fabavg').text(result[0].Fabric2Average);
                $('.fabtable tr').eq(1).find("td").eq(4).find('.fabavg').text(result[0].Fabric3Average);
                $('.fabtable tr').eq(1).find("td").eq(5).find('.fabavg').text(result[0].Fabric4Average);
                $('.fabtable tr').eq(1).find('.slineno').text(result[0].LineItemNumber);
                $('.fabtable tr').eq(1).find('.scontact').text(result[0].ContractNumber);
                $('.fabtable tr').eq(1).find('.sqty').text(result[0].Quantity);

                $(".acctable").find("tr:first td").eq(2).find('.s_lineno').text(result[0].LineItemNumber);
                $(".acctable").find("tr:first td").eq(2).find('.s_contact').text(result[0].ContractNumber);
                $(".acctable").find("tr:first td").eq(2).find('.s_qty').text(result[0].Quantity);


                for (var i = 1; i < result.length; i++) {
                    //  alert(result[i].Fabric1);
                    var tableBody = $('.tblcontect > tbody');
                    lastRowClone = $('tr:last-child', tableBody).clone();
                    // clear the values in the text field.
                    $('input[type=text]', lastRowClone).val('');
                    $('.txtline', lastRowClone).val(result[i].LineItemNumber);
                    $('.txtcontract', lastRowClone).val(result[i].ContractNumber);
                    $('.exdate', lastRowClone).val(result[i].ExFactory);
                    $('.txtqty', lastRowClone).val(result[i].Quantity);
                    $('.dcdate', lastRowClone).val(result[i].DC);
                    $('.ikandiprice', lastRowClone).val(result[i].iKandiPrice);
                    $('.Exweek', lastRowClone).text(result[i].WeekToEx);
                    $('.Dcweek', lastRowClone).text(result[i].WeeksToDC);
                    // and finally we append the row after the last row.
                    // tableBody.append(lastRowClone);
                    $('.tblcontect tr:last').after(lastRowClone);
                    var tableBodyfab = $('.fabtable > tbody');
                    lastRowClone = $($('.fabtable tr').eq(1), tableBodyfab).clone();
                    // $('input[type=text]', lastRowClone).val('');
                    $('.slineno', lastRowClone).text(result[i].LineItemNumber);
                    $('.scontact', lastRowClone).text(result[i].ContractNumber);
                    $('.sqty', lastRowClone).text(result[i].Quantity);
                    $('.fabprice', lastRowClone).text(result[i].iKandiPrice);

                    $('.fabtable .fabtotal').before(lastRowClone);
                    $('.fabtable tr').eq(i + 1).find("td").eq(2).find('.fabprint').val(result[i].Fabric1Details);
                    $('.fabtable tr').eq(i + 1).find("td").eq(3).find('.fabprint').val(result[i].Fabric2Details);
                    $('.fabtable tr').eq(i + 1).find("td").eq(4).find('.fabprint').val(result[i].Fabric3Details);
                    $('.fabtable tr').eq(i + 1).find("td").eq(5).find('.fabprint').val(result[i].Fabric4Details);
                    $('.fabtable tr').eq(i + 1).find("td").eq(2).find('.fabqty').text(result[i].Fabric1Quantity);
                    $('.fabtable tr').eq(i + 1).find("td").eq(3).find('.fabqty').text(result[i].Fabric2Quantity);
                    $('.fabtable tr').eq(i + 1).find("td").eq(4).find('.fabqty').text(result[i].Fabric3Quantity);
                    $('.fabtable tr').eq(i + 1).find("td").eq(5).find('.fabqty').text(result[i].Fabric4Quantity);
                    $('.fabtable tr').eq(i + 1).find("td").eq(2).find('.fabavg').text(result[i].Fabric1Average);
                    $('.fabtable tr').eq(i + 1).find("td").eq(3).find('.fabavg').text(result[i].Fabric2Average);
                    $('.fabtable tr').eq(i + 1).find("td").eq(4).find('.fabavg').text(result[i].Fabric3Average);
                    $('.fabtable tr').eq(i + 1).find("td").eq(5).find('.fabavg').text(result[i].Fabric4Average);
                    $('.fabtable tr').eq(i + 1).find("td").find(".totallk").text(caladdqty($('.fabtable tr').eq(i + 1).find(".lk")));
                    $('.fabtable tr').eq(i + 1).find("td").find(".avgdiff").text(getdiff($('.fabtable tr').eq(i + 1).find(".avg"), $('.fabtable tr').eq(i + 1).find(".orderavg")));
                    $('.fabtable tr').eq(i + 1).find("td").find(".pricediff").text(getdiff($('.fabtable tr').eq(i + 1).find(".fabprice"), $('.fabtable tr').eq(i + 1).find(".orderprice")));
                             

                    var count = $(".acctable").find("tr:first td").length;
                    $('.acctable').find('tr').each(function () {
                        lastRowClone = $($(this).find('td').eq(count - 4)).clone();
                        $('.s_lineno', lastRowClone).text(result[i].LineItemNumber);
                        $('.s_contact', lastRowClone).text(result[i].ContractNumber);
                        $('.s_qty', lastRowClone).text(result[i].Quantity);
                       // $('.s_qty', lastRowClone).text(result[i].LineItemNumber);
                        $(this).find('td').eq(count - 4).after(lastRowClone);
                    });

                }
                $(".s_totqty").text(addqty("sqty"));
                $(".sumprofit").text(addqty("totallk"));
                $(".sumdudget").text(addqty("budget"));
               getorderAccDetail(orderid);
            }          

        }, null, false, false);

   };
   */
   // comment by sushil 
   function GetOrderContractDetail_order(result) {
       if (result.length > 0) {
           $('.tblcontect tr').eq(1).find('.txtline').val(result[0].LineItemNumber);
           $('.tblcontect tr').eq(1).find('.txtcontract').val(result[0].ContractNumber);
           $('.tblcontect tr').eq(1).find('.exdate').val(result[0].ExFactory);
           $('.tblcontect tr').eq(1).find('.txtqty').val(result[0].Quantity);
           $('.tblcontect tr').eq(1).find('.dcdate').val(result[0].DC);
           $('.tblcontect tr').eq(1).find('.ikandiprice').val(result[0].iKandiPrice);
           $('.tblcontect tr').eq(1).find('.Exweek').text(result[0].WeekToEx);
           $('.tblcontect tr').eq(1).find('.Dcweek').text(result[0].WeeksToDC);
           var fabcount = 0;
           // alert(result[0].Fabric3.length);
           if (result[0].Fabric1.length > 0)
           { fabcount = fabcount + 1; }
           if (result[0].Fabric2.length > 0)
           { fabcount = fabcount + 1; }
           if (result[0].Fabric3.length > 0)
           { fabcount = fabcount + 1; }
           if (result[0].Fabric4.length > 0)
           { fabcount = fabcount + 1; }
           // alert(fabcount );
           if (fabcount > 0) {
               var i = 1;
               while (i < fabcount) {
                   var count = $(".fabtable").find("tr:first td").length;
                   if (count < 10) {
                       $('.fabtable').find("tr").each(function () {
                           $(this).find('td').eq(count - 3).after($($(this).find('td').eq(count - 3)).clone());
                       });
                   }
                   i++;
               }
           }

           $(".fabtable").find("tr:first td").eq(2).find('.s_fabric1').val(result[0].Fabric1);
           $(".fabtable").find("tr:first td").eq(3).find('.s_fabric1').val(result[0].Fabric2);
           $(".fabtable").find("tr:first td").eq(4).find('.s_fabric1').val(result[0].Fabric3);
           $(".fabtable").find("tr:first td").eq(5).find('.s_fabric1').val(result[0].Fabric4);
           $(".fabtable").find("tr:first td").eq(2).find('.s_ccgsm').text(result[0].CCGSM1);
           $(".fabtable").find("tr:first td").eq(3).find('.s_ccgsm').text(result[0].CCGSM2);
           $(".fabtable").find("tr:first td").eq(4).find('.s_ccgsm').text(result[0].CCGSM3);
           $(".fabtable").find("tr:first td").eq(5).find('.s_ccgsm').text(result[0].CCGSM4);
           $('.fabtable tr').eq(1).find("td").eq(2).find('.fabprint').val(result[0].Fabric1Details);
           $('.fabtable tr').eq(1).find("td").eq(3).find('.fabprint').val(result[0].Fabric2Details);
           $('.fabtable tr').eq(1).find("td").eq(4).find('.fabprint').val(result[0].Fabric3Details);
           $('.fabtable tr').eq(1).find("td").eq(5).find('.fabprint').val(result[0].Fabric4Details);
           $('.fabtable tr').eq(1).find("td").eq(2).find('.fabqty').text(result[0].Fabric1Quantity);
           $('.fabtable tr').eq(1).find("td").eq(3).find('.fabqty').text(result[0].Fabric2Quantity);
           $('.fabtable tr').eq(1).find("td").eq(4).find('.fabqty').text(result[0].Fabric3Quantity);
           $('.fabtable tr').eq(1).find("td").eq(5).find('.fabqty').text(result[0].Fabric4Quantity);
           $('.fabtable tr').eq(1).find("td").eq(2).find('.fabavg').text(result[0].Fabric1Average);
           $('.fabtable tr').eq(1).find("td").eq(3).find('.fabavg').text(result[0].Fabric2Average);
           $('.fabtable tr').eq(1).find("td").eq(4).find('.fabavg').text(result[0].Fabric3Average);
           $('.fabtable tr').eq(1).find("td").eq(5).find('.fabavg').text(result[0].Fabric4Average);
           $('.fabtable tr').eq(1).find('.slineno').text(result[0].LineItemNumber);
           $('.fabtable tr').eq(1).find('.scontact').text(result[0].ContractNumber);
           $('.fabtable tr').eq(1).find('.sqty').text(result[0].Quantity);

           $(".acctable").find("tr:first td").eq(2).find('.s_lineno').text(result[0].LineItemNumber);
           $(".acctable").find("tr:first td").eq(2).find('.s_contact').text(result[0].ContractNumber);
           $(".acctable").find("tr:first td").eq(2).find('.s_qty').text(result[0].Quantity);


           for (var i = 1; i < result.length; i++) {
               //  alert(result[i].Fabric1);
               var tableBody = $('.tblcontect > tbody');
               lastRowClone = $('tr:last-child', tableBody).clone();
               // clear the values in the text field.
               $('input[type=text]', lastRowClone).val('');
               $('.txtline', lastRowClone).val(result[i].LineItemNumber);
               $('.txtcontract', lastRowClone).val(result[i].ContractNumber);
               $('.exdate', lastRowClone).val(result[i].ExFactory);
               $('.txtqty', lastRowClone).val(result[i].Quantity);
               $('.dcdate', lastRowClone).val(result[i].DC);
               $('.ikandiprice', lastRowClone).val(result[i].iKandiPrice);
               $('.Exweek', lastRowClone).text(result[i].WeekToEx);
               $('.Dcweek', lastRowClone).text(result[i].WeeksToDC);
               // and finally we append the row after the last row.
               // tableBody.append(lastRowClone);
               $('.tblcontect tr:last').after(lastRowClone);
               var tableBodyfab = $('.fabtable > tbody');
               lastRowClone = $($('.fabtable tr').eq(1), tableBodyfab).clone();
               // $('input[type=text]', lastRowClone).val('');
               $('.slineno', lastRowClone).text(result[i].LineItemNumber);
               $('.scontact', lastRowClone).text(result[i].ContractNumber);
               $('.sqty', lastRowClone).text(result[i].Quantity);
               $('.fabprice', lastRowClone).text(result[i].iKandiPrice);

               $('.fabtable .fabtotal').before(lastRowClone);
               $('.fabtable tr').eq(i + 1).find("td").eq(2).find('.fabprint').val(result[i].Fabric1Details);
               $('.fabtable tr').eq(i + 1).find("td").eq(3).find('.fabprint').val(result[i].Fabric2Details);
               $('.fabtable tr').eq(i + 1).find("td").eq(4).find('.fabprint').val(result[i].Fabric3Details);
               $('.fabtable tr').eq(i + 1).find("td").eq(5).find('.fabprint').val(result[i].Fabric4Details);
               $('.fabtable tr').eq(i + 1).find("td").eq(2).find('.fabqty').text(result[i].Fabric1Quantity);
               $('.fabtable tr').eq(i + 1).find("td").eq(3).find('.fabqty').text(result[i].Fabric2Quantity);
               $('.fabtable tr').eq(i + 1).find("td").eq(4).find('.fabqty').text(result[i].Fabric3Quantity);
               $('.fabtable tr').eq(i + 1).find("td").eq(5).find('.fabqty').text(result[i].Fabric4Quantity);
               $('.fabtable tr').eq(i + 1).find("td").eq(2).find('.fabavg').text(result[i].Fabric1Average);
               $('.fabtable tr').eq(i + 1).find("td").eq(3).find('.fabavg').text(result[i].Fabric2Average);
               $('.fabtable tr').eq(i + 1).find("td").eq(4).find('.fabavg').text(result[i].Fabric3Average);
               $('.fabtable tr').eq(i + 1).find("td").eq(5).find('.fabavg').text(result[i].Fabric4Average);
               $('.fabtable tr').eq(i + 1).find("td").find(".totallk").text(caladdqty($('.fabtable tr').eq(i + 1).find(".lk")));
               $('.fabtable tr').eq(i + 1).find("td").find(".avgdiff").text(getdiff($('.fabtable tr').eq(i + 1).find(".avg"), $('.fabtable tr').eq(i + 1).find(".orderavg")));
               $('.fabtable tr').eq(i + 1).find("td").find(".pricediff").text(getdiff($('.fabtable tr').eq(i + 1).find(".fabprice"), $('.fabtable tr').eq(i + 1).find(".orderprice")));


               var count = $(".acctable").find("tr:first td").length;
               $('.acctable').find('tr').each(function () {
                   lastRowClone = $($(this).find('td').eq(count - 4)).clone();
                   $('.s_lineno', lastRowClone).text(result[i].LineItemNumber);
                   $('.s_contact', lastRowClone).text(result[i].ContractNumber);
                   $('.s_qty', lastRowClone).text(result[i].Quantity);
                   // $('.s_qty', lastRowClone).text(result[i].LineItemNumber);
                   $(this).find('td').eq(count - 4).after(lastRowClone);
               });

           }
           $(".s_totqty").text(addqty("sqty"));
           $(".sumprofit").text(addqty("totallk"));
           $(".sumdudget").text(addqty("budget"));
           getorderAccDetail($("#" + hdnOrderIdClientID).val());
       } 
   };



function getdiff(itemA, itemB) {
    //alert(itemA.text());
   // alert(eval(itemB.val()));
   
    return ((itemA.text()) - (eval(itemB.val())));
}
function addqty(cls) {
   // debugger;
    var itemA = $("." + cls);
   // alert(itemA);
  //  alert(itemA.length);
    var lg = itemA.length;

    var sum = 0;
    for (var i = 0; i < lg; i++) {
        // alert(itemA[i].innerText);
        var itemval = 0;
        if (itemA[i].innerText != "") {
            itemval =  eval(itemA[i].innerText);
        }
        sum = sum + itemval;
    }
    return sum.toFixed(2);
}
function caladdqty(itemA) {
    debugger;
    var lg = itemA.length;
        var sum = 0;
    for (var i = 0; i < lg; i++) {
        //  alert(itemA[i].innerText);
        sum = sum + eval(itemA[i].innerText ? itemA[i].innerText : 0);
    }
    return sum.toFixed(2);


}



function onStyleChange() {
   // debugger;

    var count = $(".fabtable").find("tr:first td").length;
    //alert(count);
    while (count > 5) {
        $('.fabtable').find("tr").each(function () {
            $(this).find('td').eq(3).remove();
        });
        count = $(".fabtable").find("tr:first td").length;
    }


    var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();
    proxy.invoke("GetInfoByStyleNumber", { StyleNumber: styleNumber },
        function (result) {
          //  debugger;
            //alert("fb");
            var styleid = result.Style.StyleID;
            // alert(result.Costing.ClientID);
            // alert(result.Costing.AgreedPrice);
            var currencySign = result.Costing.CurrencySign;
            $(".currency-sign").text(currencySign);
            $("#" + hdnStyleIDClientID, "#main_content").val(styleid);
            $("#" + txtBIPLPriceClientID, "#main_content").val(parseFloat(result.Costing.AgreedPrice).toFixed(2));
            $("#" + BuyerDDClientID, "#main_content").val(result.Costing.ClientID);
            // alert(result.OrderDetail);
            var fabcount = 0;
            if (result.OrderDetail.Fabric1 != null)
            { fabcount = fabcount + 1; }
            if (result.OrderDetail.Fabric2 != null)
            { fabcount = fabcount + 1; }
            if (result.OrderDetail.Fabric3 != null)
            { fabcount = fabcount + 1; }
            if (result.OrderDetail.Fabric4 != null)
            { fabcount = fabcount + 1; }

            // alert('sushil');
            // alert(fabcount);
            if (fabcount > 0) {
                var i = 1;
                while (i < fabcount) {
                    var count = $(".fabtable").find("tr:first td").length;
                    // alert(count);
                    if (count < 10) {
                        $('.fabtable').find("tr").each(function () {
                            $(this).find('td').eq(count - 3).after($($(this).find('td').eq(count - 3)).clone());

                        });
                    }

                    i++;
                }
//                var r = 2;
//                while (2 < fabcount + 1) {
//                    $(".fabtable").find("tr:first td").eq(r).find('.s_fabric1').val(result.OrderDetail.Fabric1);
//                    r++;
//                }

            }



             $(".fabtable").find("tr:first td").eq(2).find('.s_fabric1').val(result.OrderDetail.Fabric1);
             $(".fabtable").find("tr:first td").eq(3).find('.s_fabric1').val(result.OrderDetail.Fabric2);
             $(".fabtable").find("tr:first td").eq(4).find('.s_fabric1').val(result.OrderDetail.Fabric3);
             $(".fabtable").find("tr:first td").eq(5).find('.s_fabric1').val(result.OrderDetail.Fabric4);

            //            $('.fabtable tr td').find('.s_fabric1').val(result.OrderDetail.Fabric1);
            //            $('.fabtable tr td').find('.s_fabric2').val(result.OrderDetail.Fabric2);
            //            $('.fabtable tr td').find('.s_fabric3').val(result.OrderDetail.Fabric3);
            //            $('.fabtable tr td').find('.s_fabric4').val(result.OrderDetail.Fabric4);


            //$('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll(' + $("#" + hdnStyleIDClientID, "#main_content").val() + ',-1,-1)');
            if ($("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {
               // debugger;
                $("#" + hdnCostingIdClientID, "#main_content").val(result.Costing.CostingID);
                if (result.Costing.DepartmentID > 0) {
                    populateDepartments(result.Costing.ClientID, result.Costing.DepartmentID);
                    $("#" + DeptDDClientID, "#main_content").val(result.Costing.DepartmentID);
                }
                else {

                    populateDepartments(result.Costing.ClientID, '');
                }
                $("#" + hdnClientID, "#main_content").val(result.Costing.ClientID);
                setClientName();
                // if ($("#" + hdnOrderIdClientID, "#main_content").val() == -1) {
                if (result.Costing.ClientID > 0) {
                    proxy.invoke("GetNewSerialNumber", { clientId: result.Costing.ClientID },
                        function (SerialNumber) {
                            $("#" + txtIkandiSerialClientID, "#main_content").val(SerialNumber);

                        });

                }

                // }

            }
            else if ($("#" + txtStyleNumberClientID, "#main_content").val() == document.getElementById(txtStyleNumberClientID).defaultValue) {

              //  debugger;
                $("#" + hdnCostingIdClientID, "#main_content").val(result.Costing.CostingID);
                if (result.Costing.DepartmentID > 0) {
                    populateDepartments(result.Costing.ClientID, result.Costing.DepartmentID);
                    $("#" + DeptDDClientID, "#main_content").val(result.Costing.DepartmentID);
                }
                else {

                    populateDepartments(result.Costing.ClientID, '');
                }
                $("#" + hdnClientID, "#main_content").val(result.Costing.ClientID);
                setClientName();
                // if ($("#" + hdnOrderIdClientID, "#main_content").val() == -1) {
                if (result.Costing.ClientID > 0) {
                    proxy.invoke("GetNewSerialNumber", { clientId: result.Costing.ClientID },
                        function (SerialNumber) {
                            $("#" + txtIkandiSerialClientID, "#main_content").val(SerialNumber);

                        });

                }
                /*
                $("#" + txtIkandiSerialClientID, "#main_content").val(document.getElementById(txtIkandiSerialClientID).defaultValue);
                $("#" + BuyerDDClientID, "#main_content").val($("#" + hdnOriginalClientID, "#main_content").val());
                $("#" + hdnClientID, "#main_content").val($("#" + BuyerDDClientID, "#main_content").val());
                populateDepartments($("#" + BuyerDDClientID, "#main_content").val(), $("#" + hdnOriginalDeptIDClientID, "#main_content").val());
                $("#" + DeptDDClientID).val($("#" + hdnOriginalDeptIDClientID, "#main_content").val());
                setClientName();
                */
            }
        }, null, false, false);
    var s2 = $("#" + txtStyleNumberClientID, "#main_content").val();    
//    $("input.print-number", "#main_content").autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrintsStyleNumber", { dataType: "xml", datakey: "string", max: 100, "width": "300px",

//        extraParams: {

//            stno: function () {

//                // return s2;

//                return $("#" + txtStyleNumberClientID, "#main_content").val();

//            },

//            ClientID: function () {

//                $(this).flushCache();

//                return $("#" + BuyerDDClientID).val();

//            }

//        }

//    });



}


function populateDepartments(clientId, selectedDeptID) {
    bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID", { ClientID: clientId }, "Name", "DeptID", false, (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)
    if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
            jscriptPageVariables.selectedDeptID = '';
}


function populateAccMgr(departmentId) {
    proxy.invoke("GetClientAccMgrByClientID", { DepartmentId: departmentId },

            function (result) {
                var accMgr = "";
                for (var i = 0; i < result.length; i++) {
                    if (i == 0)
                        accMgr = result[i].FullName;
                    if (i > 0)
                        accMgr = accMgr + ", " + result[i].FullName;
                }
                $("#" + lblAccMgrClientID, "#main_content").text(accMgr);
            });

}

function setClientName() {
    selectedClient = $("#" + BuyerDDClientID, "#main_content").find("option:selected").text();
    $("#" + hdnSelectedClientClientID, "#main_content").val(selectedClient);
}

function setDeptName() {
    selectedDept = $("#" + DeptDDClientID, "#main_content").find("option:selected").text();
    $("#" + hdnSelectedDeptClientID, "#main_content").val(selectedDept);
    populateAccMgr($("#" + DeptDDClientID).find("option:selected").val());
}


function populateAccMgr(departmentId) {
    proxy.invoke("GetClientAccMgrByClientID", { DepartmentId: departmentId },
            function (result) {
                var accMgr = "";

                for (var i = 0; i < result.length; i++) {

                    if (i == 0)

                        accMgr = result[i].FullName;

                    if (i > 0)

                        accMgr = accMgr + ", " + result[i].FullName;

                }

                $("#" + lblAccMgrClientID, "#main_content").text(accMgr);

            });
}
