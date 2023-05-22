

$(document).ready(function () {
    debugger;
    $('.lbldate').text($.datepicker.formatDate('dd/mm', new Date()));
    $('.txttodate').change(function () { UpcomingFeeding_Report(); });
    $('input.date-picker', '.container').datepicker({ changeYear: true, yearRange: '1900:2020', dateFormat: 'dd / mm', minDate: 0, buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });

    // $('.date-picker').datepicker();
    Feeding_Report();
    UpcomingFeeding_Report();
    $('.txttodate').val($.datepicker.formatDate('dd/mm', new Date()));

    $('.clssubmit').click(function () {
        InsertFeedingSelection();
    });
    $('.clssubmitUP').click(function () {
        InsertFeedingSelection_UP();
    }); $('.closepopup').click(function () {
        closefeeding();
    });
});

function UpdateManageOrder() {
    //debugger;
    window.opener.UpdatePageForSale();
}
function closefeeding() {
    //debugger;
    window.opener.ClosePageForSale();
    this.parent.window.close();
    return false;
}

function InsertFeedingSelection() {
    debugger;
    var extarget = "";
    var exactual = "";
    var exdelay = "";

    var pcdtarget = "";
    var pcdactual = "";
    var pcddelay = "";

    var accbihtarget = "";
    var accbihactual = "";
    var accbihdelay = "";

    var fabbihtarget = "";
    var fabbihactual = "";
    var fabbihdelay = "";

    var Toptarget = "";
    var Topactual = "";
    var Topdelay = "";

    var Stctarget = "";
    var Stcactual = "";
    var Stcdelay = "";

    var Protarget = "";
    var Proactual = "";
    var Prodelay = "";

    var Apptarget = "";
    var Appactual = "";
    var Appdelay = "";

    if ($('.chbextarget').is(':checked')) {
        extarget = "ExTarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbexactual').is(':checked')) {
            exactual = "ExActual";
        }
        if ($('.chbexdelay').is(':checked')) {
            exdelay = "ExDelay";
        }
    }

    if ($('.chbpcdtarget').is(':checked')) {
        pcdtarget = "Pcdtarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbpcdactual').is(':checked')) {
            pcdactual = "Pcdactual";
        }
        if ($('.chbpcddelay').is(':checked')) {
            pcddelay = "Pcddelay";
        }
    }

    if ($('.chbaccbihtarget').is(':checked')) {
        accbihtarget = "Accbihtarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbaccbihactual').is(':checked')) {
            accbihactual = "AccbihActual";
        }
        if ($('.chbaccbihdelay').is(':checked')) {
            accbihdelay = "AccbihDelay";
        }
    }

    if ($('.chbfabbihtarget').is(':checked')) {
        fabbihtarget = "Fabbihtarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbfabbihactual').is(':checked')) {
            fabbihactual = "Fabbihactual";
        }
        if ($('.chbfabbihdelay').is(':checked')) {
            fabbihdelay = "Fabbihdelay";
        }
    }

    if ($('.chbtoptarget').is(':checked')) {
        Toptarget = "Toptarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbtopactual').is(':checked')) {
            Topactual = "Topactual";
        }
        if ($('.chbtopdelay').is(':checked')) {
            Topdelay = "Topdelay";
        }
    }

    if ($('.chbstctarget').is(':checked')) {
        Stctarget = "Stctarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbstcactual').is(':checked')) {
            Stcactual = "Stcactual";
        }
        if ($('.chbstcdelay').is(':checked')) {
            Stcdelay = "Stcdelay";
        }
    }

    if ($('.chbprotarget').is(':checked')) {
        Protarget = "Protarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbproactual').is(':checked')) {
            Proactual = "Proactual";
        }
        if ($('.chbprodelay').is(':checked')) {
            Prodelay = "Prodelay";
        }
    }

    if ($('.chbapptarget').is(':checked')) {
        Apptarget = "Apptarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbappacttarget').is(':checked')) {
            Appactual = "Appactual";
        }
        if ($('.chbappdeltarget').is(':checked')) {
            Appdelay = "Appdelay";
        }
    }

    // InsertFeedingSelection(string extarget,string exactual,string exdelay)
    proxy.invoke("InsertFeedingSelection", { extarget: extarget, exactual: exactual, exdelay: exdelay, pcdtarget: pcdtarget, pcdactual: pcdactual, pcddelay: pcddelay
    , accbihtarget: accbihtarget, accbihactual: accbihactual, accbihdelay: accbihdelay, fabbihtarget: fabbihtarget, fabbihactual: fabbihactual, fabbihdelay: fabbihdelay,
        Toptarget: Toptarget, Topactual: Topactual, Topdelay: Topdelay, Stctarget: Stctarget, Stcactual: Stcactual, Stcdelay: Stcdelay, Protarget: Protarget, Proactual: Proactual, Prodelay: Prodelay
        , Apptarget: Apptarget, Appactual: Appactual, Appdelay: Appdelay
    },
            function (result) {
                debugger;
                UpdateManageOrder();

            });

}


function Feeding_Report() {
    var res = 0;
    proxy.invoke("GetFeeding_Report", { StyleNumber: 1 },
            function (result) {
                // debugger;
                // alert(result[0].Targetminut);
                // bind minuts
                $('.lblextarmin').text(result[0].Targetminut);
                $('.lblexavlmin').text(result[1].Targetminut);
                if (parseFloat(result[1].Targetminut) > 0) {
                    res = (result[1].Targetminut / result[0].Targetminut) * 100;
                    //alert(res);
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblEx').text((res));
                if (res < 90) {
                    $('.Ex').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.Ex').addClass("Orangeclr");
                }
                else { $('.Ex').addClass("Greenclr"); }
                $('.lblexdelmin').text(result[2].Targetminut);
                $('.lblpcdtarmin').text(result[3].Targetminut);
                $('.lblpcdavlmin').text(result[4].Targetminut);
                if (parseFloat(result[4].Targetminut) > 0) {
                    res = (result[4].Targetminut / result[3].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblPCD').text((res));
                if (res < 90) {
                    $('.PCD').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.PCD').addClass("Orangeclr");
                }
                else { $('.PCD').addClass("Greenclr"); }

                $('.lblpcddelmin').text(result[5].Targetminut);
                $('.lblacctarmin').text(result[6].Targetminut);
                $('.lblaccavlmin').text(result[7].Targetminut);
                if (parseFloat(result[7].Targetminut) > 0) {
                    res = (result[7].Targetminut / result[6].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblBIH').text((res));
                if (res < 90) {
                    $('.BIH').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.BIH').addClass("Orangeclr");
                }
                else { $('.BIH').addClass("Greenclr"); }

                $('.lblaccdelmin').text(result[8].Targetminut);
                $('.lblfabtarmin').text(result[9].Targetminut);
                $('.lblfabavlmin').text(result[10].Targetminut);
                if (parseFloat(result[10].Targetminut) > 0) {
                    res = (result[10].Targetminut / result[9].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblFabBIH').text((res));
                if (res < 90) {
                    $('.FabBIH').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.FabBIH').addClass("Orangeclr");
                }
                else { $('.FabBIH').addClass("Greenclr"); }

                $('.lblfabdelmin').text(result[11].Targetminut);
                $('.lblstctargetmin').text(result[12].Targetminut);
                $('.lblstcactualmin').text(result[13].Targetminut);
                if (parseFloat(result[13].Targetminut) > 0) {
                    res = (result[13].Targetminut / result[12].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblSTC').text((res));
                if (res < 90) {
                    $('.STC').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.STC').addClass("Orangeclr");
                }
                else { $('.STC').addClass("Greenclr"); }

                $('.lblstcdelaymin').text(result[14].Targetminut);
                $('.lbltoptargetmin').text(result[15].Targetminut);
                $('.lbltopactualmin').text(result[16].Targetminut);
                if (parseFloat(result[16].Targetminut) > 0) {
                    res = (result[16].Targetminut / result[15].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblTOP').text((res));
                if (res < 90) {
                    $('.TOP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.TOP').addClass("Orangeclr");
                }
                else { $('.TOP').addClass("Greenclr"); }

                $('.lbltopdelaymin').text(result[17].Targetminut);
                $('.lblprotarmin').text(result[18].Targetminut);
                $('.lblproactmin').text(result[19].Targetminut);
                if (parseFloat(result[19].Targetminut) > 0) {
                    res = (result[19].Targetminut / result[18].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblPRO').text((res));
                if (res < 90) {
                    $('.PRO').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.PRO').addClass("Orangeclr");
                }
                else { $('.PRO').addClass("Greenclr"); }
                $('.lblprodelmin').text(result[20].Targetminut);

                $('.lblapptarmin').text(result[21].Targetminut);
                $('.lblappactmin').text(result[22].Targetminut);
                if (parseFloat(result[22].Targetminut) > 0) {
                    res = (result[22].Targetminut / result[21].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                } else { res = 0; }
                $('.lblAPP').text((res));
                if (res < 90) {
                    $('.APP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.APP').addClass("Orangeclr");
                }
                else { $('.APP').addClass("Greenclr"); }
                $('.lblappdelmin').text(result[23].Targetminut);


                // bind QTY
                $('.lblexqty').text(result[0].TargetQTY);
                $('.lblexactqty').text(result[1].TargetQTY);
                $('.lblexdelqty').text(result[2].TargetQTY);
                $('.lblpcdqty').text(result[3].TargetQTY);
                $('.lblpcdactqty').text(result[4].TargetQTY);
                $('.lblpcddelqty').text(result[5].TargetQTY);
                $('.lblaccqty').text(result[6].TargetQTY);
                $('.lblaccactqty').text(result[7].TargetQTY);
                $('.lblaccdelqty').text(result[8].TargetQTY);
                $('.lblfabqty').text(result[9].TargetQTY);
                $('.lblfabactqty').text(result[10].TargetQTY);
                $('.lblfabdelqty').text(result[11].TargetQTY);


                $('.lblstctargetqty').text(result[12].TargetQTY);
                $('.lblstcactqty').text(result[13].TargetQTY);
                $('.lblstcdelqty').text(result[14].TargetQTY);

                $('.lbltoptargetqty').text(result[15].TargetQTY);
                $('.lbltopactualqty').text(result[16].TargetQTY);
                $('.lbltopdelayqty').text(result[17].TargetQTY);

                $('.lblproqty').text(result[18].TargetQTY);
                $('.lblproactqty').text(result[19].TargetQTY);
                $('.lblprodelqty').text(result[20].TargetQTY);

                $('.lblappqty').text(result[21].TargetQTY);

                $('.lblappactqty').text(result[22].TargetQTY);
                $('.lblappdelqty').text(result[23].TargetQTY);

                // bind REV
                $('.lblexrev').text(result[0].TargetRev);
                $('.lblexactrev').text(result[1].TargetRev);
                $('.lblexdelrev').text(result[2].TargetRev);
                $('.lblpcdrev').text(result[3].TargetRev);
                $('.lblpcdactrev').text(result[4].TargetRev);
                $('.lblpcddelrev').text(result[5].TargetRev);
                $('.lblaccrev').text(result[6].TargetRev);
                $('.lblaccactrev').text(result[7].TargetRev);
                $('.lblaccdelrev').text(result[8].TargetRev);
                $('.lblfabrev').text(result[9].TargetRev);
                $('.lblfabactrev').text(result[10].TargetRev);
                $('.lblfabdelrev').text(result[11].TargetRev);

                $('.lblstctargetrev').text(result[12].TargetRev);
                $('.lblstcactrev').text(result[13].TargetRev);
                $('.lblstcdelrev').text(result[14].TargetRev);

                $('.lbltoptargetrev').text(result[15].TargetRev);
                $('.lbltopactualrev').text(result[16].TargetRev);
                $('.lbltopdelayrev').text(result[17].TargetRev);

                $('.lblprorev').text(result[18].TargetRev);
                $('.lblproactrev').text(result[19].TargetRev);
                $('.lblprodelrev').text(result[20].TargetRev);

                $('.lblapprev').text(result[21].TargetRev);
                $('.lblappactrev').text(result[22].TargetRev);
                $('.lblappdelrev').text(result[23].TargetRev);

            });

}

function UpcomingFeeding_Report() {
    var res = 0.0;
    var Todate = $('.txttodate').val();
    proxy.invoke("GetupcomingFeeding_Report", { todate: Todate },
            function (result) {
                debugger;
                //  alert(result[19].Targetminut);
                // bind minuts
                $('.lblextarminUP').text(result[0].Targetminut);
                $('.lblexavlminUP').text(result[1].Targetminut);

                if (parseFloat(result[1].Targetminut) > 0) {
                    res = (result[1].Targetminut / result[0].Targetminut) * 100;
                    // alert(res);
                    res = parseFloat(res).toFixed(2);
                }
                else { res = 0; }

                $('.lblExUP').text((res));
                if (res < 90) {
                    $('.ExUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.ExUP').addClass("Orangeclr");
                }
                else { $('.ExUP').addClass("Greenclr"); }

                $('.lblpcdtarminUP').text(result[3].Targetminut);
                $('.lblpcdavlminUP').text(result[4].Targetminut);

                if (parseFloat(result[4].Targetminut) > 0) {
                    res = (result[4].Targetminut / result[3].Targetminut) * 100;

                    res = parseFloat(res).toFixed(2);

                }
                else { res = 0; }
                $('.lblpcdUP').text((res));

                if (res < 90) {
                    $('.PCDUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.PCDUP').addClass("Orangeclr");
                }
                else { $('.PCDUP').addClass("Greenclr"); }

                $('.lblacctarminUP').text(result[6].Targetminut);
                $('.lblaccavlminUP').text(result[7].Targetminut);
                if (parseFloat(result[7].Targetminut) > 0) {
                    res = (result[7].Targetminut / result[6].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                }
                else
                { res = 0; }
                $('.lblaccUP').text((res));
                if (res < 90) {
                    $('.BIHUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.BIHUP').addClass("Orangeclr");
                }
                else { $('.BIHUP').addClass("Greenclr"); }
                $('.lblfabtarminUP').text(result[9].Targetminut);
                $('.lblfabavlminUP').text(result[10].Targetminut);
                if (parseFloat(result[10].Targetminut) > 0) {
                    res = (result[10].Targetminut / result[9].Targetminut) * 100;
                    // alert(res);
                    res = parseFloat(res).toFixed(2);
                }
                else { res = 0; }
                $('.lblFabBIHUP').text((res));
                if (res < 90) {
                    $('.FabBIHUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.FabBIHUP').addClass("Orangeclr");
                }
                else { $('.FabBIHUP').addClass("Greenclr"); }

                $('.lblstctargetminUP').text(result[12].Targetminut);
                $('.lblstcactualminUP').text(result[13].Targetminut);
                if (parseFloat(result[13].Targetminut) > 0) {
                    res = (result[13].Targetminut / result[12].Targetminut) * 100;
                    // alert(res);
                    res = parseFloat(res).toFixed(2);
                }
                else { res = 0; }
                $('.lblStcUP').text((res));
                if (res < 90) {
                    $('.StcUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.StcUP').addClass("Orangeclr");
                }
                else { $('.StcUP').addClass("Greenclr"); }

                $('.lbltoptargetminUP').text(result[15].Targetminut);
                $('.lbltopactualminUP').text(result[16].Targetminut);
                // alert(result[16].Targetminut);
                // alert(parseFloat(result[16].Targetminut).toFixed(2));
                if (parseFloat(result[16].Targetminut) > 0) {
                    res = (result[16].Targetminut / result[15].Targetminut) * 100;
                    res = parseFloat(res).toFixed(2);
                }
                else { res = 0; }
                $('.lbltopUP').text((res));
                if (res < 90) {
                    $('.TopUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.TopUP').addClass("Orangeclr");
                }
                else { $('.TopUP').addClass("Greenclr"); }

                $('.lblprotarminUP').text(result[18].Targetminut);
                $('.lblproachminUP').text(result[19].Targetminut);
                if (parseFloat(result[19].Targetminut) > 0) {
                    res = (result[19].Targetminut / result[18].Targetminut) * 100;
                    // alert(res);
                    res = parseFloat(res).toFixed(2);
                }
                else
                { res = 0; }
                $('.lblproUP').text((res));
                if (res < 90) {
                    $('.PROUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.PROUP').addClass("Orangeclr");
                }
                else { $('.PROUP').addClass("Greenclr"); }


                $('.lblapptarminUP').text(result[21].Targetminut);
                $('.lblappactminUP').text(result[22].Targetminut);

                if (parseFloat(result[22].Targetminut) > 0) {
                    res = (result[22].Targetminut / result[21].Targetminut) * 100;
                    // alert(res);
                    res = parseFloat(res).toFixed(2);
                }
                else
                { res = parseFloat(0); }
                $('.lblAPPUP').text((res));

                if (res < 90) {
                    $('.AppUP').addClass("Redclr");
                }
                else if (res < 99) {
                    $('.AppUP').addClass("Orangeclr");
                }
                else { $('.AppUP').addClass("Greenclr"); }


                // bind QTY
                $('.lblexqtyUP').text(result[0].TargetQTY);
                $('.lblexactqtyUP').text(result[1].TargetQTY);
                var qty = 0;
                if (parseFloat(result[1].TargetQTY) > 0) {
                    qty = (result[1].TargetQTY / result[0].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);

                }
                else { qty = 0; }

                $('.lblexachdqtyUP').text((qty));
                $('.lblpcdqtyUP').text(result[3].TargetQTY);
                $('.lblpcdactqtyUP').text(result[4].TargetQTY);
                if (parseFloat(result[4].TargetQTY) > 0) {
                    qty = (result[4].TargetQTY / result[3].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);
                }
                else { qty = 0; }
                $('.lblpcdachdqtyUP').text((qty));

                $('.lblaccqtyUP').text(result[6].TargetQTY);
                $('.lblaccactqtyUP').text(result[7].TargetQTY);

                if (parseFloat(result[7].TargetQTY) > 0) {
                    qty = (result[7].TargetQTY / result[6].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);
                }
                else { qty = 0; }
                $('.lblaccachdqtyUP').text((qty));


                $('.lblfabqtyUP').text(result[9].TargetQTY);
                $('.lblfabactqtyUP').text(result[10].TargetQTY);

                if (parseFloat(result[10].TargetQTY) > 0) {
                    qty = (result[10].TargetQTY / result[9].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);
                }
                else { qty = 0; }
                $('.lblfabachdqtyUP').text((qty));

                $('.lblstctargetqtyUP').text(result[12].TargetQTY);
                $('.lblstcactqtyUP').text(result[13].TargetQTY);

                if (parseFloat(result[13].TargetQTY) > 0) {
                    qty = (result[13].TargetQTY / result[12].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);
                }
                else { qty = 0; }
                $('.lblstcachdqtyUP').text((qty));

                $('.lbltoptargetqtyUP').text(result[15].TargetQTY);
                $('.lbltopactualqtyUP').text(result[16].TargetQTY);

                if (parseFloat(result[16].TargetQTY) > 0) {
                    qty = (result[16].TargetQTY / result[15].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);
                }
                else { qty = 0; }
                $('.lbltopachdqtyUP').text((qty));

                $('.lblproqtyUP').text(result[18].TargetQTY);
                $('.lblproactqtyUP').text(result[19].TargetQTY);

                if (parseFloat(result[19].TargetQTY) > 0) {
                    qty = (result[19].TargetQTY / result[18].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);
                }
                else { qty = 0; }
                $('.lblproachdqtyUP').text((qty));

                $('.lblappqtyUP').text(result[21].TargetQTY);
                $('.lblappactqtyUP').text(result[22].TargetQTY);

                if (parseFloat(result[22].TargetQTY) > 0) {
                    qty = (result[22].TargetQTY / result[21].TargetQTY) * 100;
                    // alert(res);
                    qty = parseFloat(qty).toFixed(2);
                }
                else { qty = 0; }
                $('.lblappachdqtyUP').text((qty));


                // bind REV
                $('.lblexrevUP').text(result[0].TargetRev);
                $('.lblexactrevUP').text(result[1].TargetRev);

                var Rev = 0;
                if (parseFloat(result[1].TargetRev) > 0) {
                    Rev = (result[1].TargetRev / result[0].TargetRev) * 100;
                    // alert(res);

                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lblexachdrevUP').text((Rev));

                $('.lblpcdrevUP').text(result[3].TargetRev);
                $('.lblpcdactrevUP').text(result[4].TargetRev);

                if (parseFloat(result[4].TargetRev) > 0) {
                    Rev = (result[4].TargetRev / result[3].TargetRev) * 100;
                    // alert(res);
                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lblpcdachdrevUP').text((Rev));


                $('.lblaccrevUP').text(result[6].TargetRev);
                $('.lblaccactrevUP').text(result[7].TargetRev);

                if (parseFloat(result[7].TargetRev) > 0) {
                    Rev = (result[7].TargetRev / result[6].TargetRev) * 100;
                    // alert(res);
                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lblaccachdrevUP').text((Rev));

                $('.lblfabrevUP').text(result[9].TargetRev);
                $('.lblfabactrevUP').text(result[10].TargetRev);
                if (parseFloat(result[10].TargetRev) > 0) {
                    Rev = (result[10].TargetRev / result[9].TargetRev) * 100;
                    // alert(res);
                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lblfabachdrevUP').text((Rev));

                $('.lblstctargetrevUP').text(result[12].TargetRev);
                $('.lblstcactrevUP').text(result[13].TargetRev);
                if (parseFloat(result[13].TargetRev) > 0) {
                    Rev = (result[13].TargetRev / result[12].TargetRev) * 100;
                    // alert(res);
                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lblstcachdrevUP').text((Rev));

                $('.lbltoptargetrevUP').text(result[15].TargetRev);
                $('.lbltopactualrevUP').text(result[16].TargetRev);
                if (parseFloat(result[16].TargetRev) > 0) {
                    Rev = (result[16].TargetRev / result[15].TargetRev) * 100;
                    // alert(res);
                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lbltopachdrevUP').text((Rev));

                $('.lblprorevUP').text(result[18].TargetRev);
                $('.lblproactrevUP').text(result[19].TargetRev);
                if (parseFloat(result[19].TargetRev) > 0) {
                    Rev = (result[19].TargetRev / result[18].TargetRev) * 100;
                    // alert(res);
                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lblproachdRevUP').text((Rev));

                $('.lblapprevUP').text(result[21].TargetRev);
                $('.lblappactrevUP').text(result[22].TargetRev);
                if (parseFloat(result[22].TargetRev) > 0) {
                    Rev = (result[22].TargetRev / result[21].TargetRev) * 100;
                    // alert(res);
                    Rev = parseFloat(Rev).toFixed(2);
                }
                else { Rev = 0; }

                $('.lblappachdrevUP').text((Rev));

            });

}

function InsertFeedingSelection_UP() {
    debugger;

    var Todate = $('.txttodate').val();

    var extarget = "";
    var exactual = "";

    var pcdtarget = "";
    var pcdactual = "";

    var accbihtarget = "";
    var accbihactual = "";

    var fabbihtarget = "";
    var fabbihactual = "";

    var Toptarget = "";
    var Topactual = "";

    var Stctarget = "";
    var Stcactual = "";

    var Protarget = "";
    var Proactual = "";

    var Apptarget = "";
    var Appactual = "";


    if ($('.chbextargetUP').is(':checked')) {
        extarget = "ExTarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbexactualUP').is(':checked')) {
            exactual = "ExActual";
        }

    }

    if ($('.chbpcdtargetUP').is(':checked')) {
        pcdtarget = "Pcdtarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbpcdactualUP').is(':checked')) {
            pcdactual = "Pcdactual";
        }

    }

    if ($('.chbaccbihtargetUP').is(':checked')) {
        accbihtarget = "Accbihtarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbaccbihactualUP').is(':checked')) {
            accbihactual = "AccbihActual";
        }

    }

    if ($('.chbfabbihtargetUP').is(':checked')) {
        fabbihtarget = "Fabbihtarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbfabbihactualUP').is(':checked')) {
            fabbihactual = "Fabbihactual";
        }

    }

    if ($('.chbtoptargetUP').is(':checked')) {
        Toptarget = "Toptarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbtopactualUP').is(':checked')) {
            Topactual = "Topactual";
        }

    }

    if ($('.chbstctargetUP').is(':checked')) {
        Stctarget = "Stctarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbstcactualUP').is(':checked')) {
            Stcactual = "Stcactual";
        }

    }

    if ($('.chbprotargetUP').is(':checked')) {
        Protarget = "Protarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbproactualUP').is(':checked')) {
            Proactual = "Proactual";
        }

    }

    if ($('.chbapptargetUP').is(':checked')) {
        Apptarget = "Apptarget";
        // System.Web.HttpContext.Current.Session.SessionID
    }
    else {
        if ($('.chbappacttargetUP').is(':checked')) {
            Appactual = "Appactual";
        }

    }

    // InsertFeedingSelection(string extarget,string exactual,string exdelay)
    proxy.invoke("InsertFeedingSelection_UP", { extarget: extarget, exactual: exactual, pcdtarget: pcdtarget, pcdactual: pcdactual,
        accbihtarget: accbihtarget, accbihactual: accbihactual, fabbihtarget: fabbihtarget, fabbihactual: fabbihactual,
        Toptarget: Toptarget, Topactual: Topactual, Stctarget: Stctarget, Stcactual: Stcactual, Protarget: Protarget, Proactual: Proactual,
        Apptarget: Apptarget, Appactual: Appactual, todate: Todate
    },
            function (result) {
                debugger;
                UpdateManageOrder();

            });


}