﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSizeSetEntry_ByMO.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.frmSizeSetEntry_ByMO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        CalculateGrdSizeOption1('OnPageLoad');
        ShowImagePreview();
        var FormType = '<%=this.FormType %>';
        if (FormType == "Cutting") {
            $(".HideAlt").attr("style", "display:none");
            $(".Cutready").attr("style", "display:none");
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
<script type="text/javascript" language="javascript">
    var enteryglobalval = 0;
    var hdn_totoal1;
    var hdn_totoal2;
    var hdn_totoal3;
    var hdn_totoal4;
    var hdn_totoal5;
    var hdn_totoal6;
    var hdn_totoal7;
    var hdn_totoal8;
    var hdn_totoal9;
    var hdn_totoal10;
    var hdn_totoal11;
    var hdn_totoal12;
    var hdn_totoal13;
    var hdn_totoal14;
    var hdn_totoal15;
    var hdn_totoal1alt;
    function CalculateGrdSizeOption1(ctrl) {
        var FormType = '<%=this.FormType %>';

         var IdsArr = '', Ids = '', lastno = '', ctrval = '';
         if (ctrl == 'OnPageLoad') {
             Ids = 'ctl02';
             lastno = '1';
         }
         else {
              IdsArr = ctrl.id.split("_");
              Ids = IdsArr[1];
              ctrval = ctrl.value;
              lastno = IdsArr[2].substr(14);
         }
        var OptionVal = 0;
        if (ctrval == '')
            ctrval = 0;
        var Stich_Finish_msg = "";
        if (FormType == 'Stitching') {
            Stich_Finish_msg = 'Stitch quantity cannot exceed cutready quantity for this size.';
        }
        if (FormType == 'Finishing') {
            Stich_Finish_msg = 'Finish quantity cannot exceed stitch quantity for this size.';
        }
        if (FormType == 'CutReady') {
            Stich_Finish_msg = 'Cut Ready cannot exceed cut quantity for this size.';
        }

        var OredrQty1 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty1']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty1']").html();
        var OredrQty2 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty2']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty2']").html();
        var OredrQty3 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty3']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty3']").html();
        var OredrQty4 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty4']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty4']").html();
        var OredrQty5 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty5']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty5']").html();
        var OredrQty6 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty6']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty6']").html();
        var OredrQty7 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty7']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty7']").html();
        var OredrQty8 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty8']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty8']").html();
        var OredrQty9 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty9']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty9']").html();
        var OredrQty10 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty10']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty10']").html();
        var OredrQty11 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty11']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty11']").html();
        var OredrQty12 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty12']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty12']").html();
        var OredrQty13 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty13']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty13']").html();
        var OredrQty14 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty14']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty14']").html();
        var OredrQty15 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty15']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOredrQty15']").html();

        var ReadyQty1 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty1']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty1']").html();
        var ReadyQty2 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty2']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty2']").html();
        var ReadyQty3 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty3']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty3']").html();
        var ReadyQty4 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty4']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty4']").html();
        var ReadyQty5 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty5']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty5']").html();
        var ReadyQty6 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty6']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty6']").html();
        var ReadyQty7 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty7']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty7']").html();
        var ReadyQty8 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty8']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty8']").html();
        var ReadyQty9 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty9']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty9']").html();
        var ReadyQty10 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty10']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty10']").html();
        var ReadyQty11 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty11']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty11']").html();
        var ReadyQty12 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty12']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty12']").html();
        var ReadyQty13 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty13']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty13']").html();
        var ReadyQty14 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty14']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty14']").html();
        var ReadyQty15 = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty15']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblReadyQty15']").html();

        var EntryVal1 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry1']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry1']").val();
        var EntryVal2 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry2']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry2']").val();
        var EntryVal3 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry3']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry3']").val();
        var EntryVal4 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry4']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry4']").val();
        var EntryVal5 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry5']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry5']").val();
        var EntryVal6 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry6']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry6']").val();
        var EntryVal7 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry7']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry7']").val();
        var EntryVal8 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry8']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry8']").val();
        var EntryVal9 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry9']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry9']").val();
        var EntryVal10 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry10']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry10']").val();
        var EntryVal11 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry11']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry11']").val();
        var EntryVal12 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry12']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry12']").val();
        var EntryVal13 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry13']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry13']").val();
        var EntryVal14 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry14']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry14']").val();
        var EntryVal15 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry15']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry15']").val();
        var OptionAltPcs = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionAltPcs']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionAltPcs']").val();


        hdn_totoal1 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal1']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal1']").val();
        hdn_totoal2 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal2']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal2']").val();
        hdn_totoal3 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal3']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal3']").val();
        hdn_totoal4 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal4']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal4']").val();
        hdn_totoal5 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal5']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal5']").val();
        hdn_totoal6 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal6']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal6']").val();
        hdn_totoal7 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal7']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal7']").val();
        hdn_totoal8 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal8']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal8']").val();
        hdn_totoal9 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal9']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal9']").val();
        hdn_totoal10 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal10']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal10']").val();
        hdn_totoal11 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal11']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal11']").val();
        hdn_totoal12 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal12']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal12']").val();
        hdn_totoal13 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal13']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal13']").val();
        hdn_totoal14 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal14']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal14']").val();
        hdn_totoal15 = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal15']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnOptionTotal15']").val();
        hdn_totoal1alt = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnAltPcs']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnAltPcs']").val();


        var EntryValTotal = parseInt(EntryVal1) + parseInt(EntryVal2) + parseInt(EntryVal3) + parseInt(EntryVal4) + parseInt(EntryVal5) + parseInt(EntryVal6) + parseInt(EntryVal7) + parseInt(EntryVal8) + parseInt(EntryVal9) + parseInt(EntryVal10) + parseInt(EntryVal11) + parseInt(EntryVal12) + parseInt(EntryVal13) + parseInt(EntryVal14) + parseInt(EntryVal15);  //+ parseInt(OptionAltPcs);

        $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblEntryTotal']").html(EntryValTotal);

        //var OptionAltPcsTotal = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_OptionAltPcsTotal']").html() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_OptionAltPcsTotal']").html();

        //var OptionAltPcs = $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionAltPcs']").val() == '' ? 0 : $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionAltPcs']").val();



        //var SumEntryVal1 = 0; var SumEntryVal2 = 0; var SumEntryVal3 = 0; var SumEntryVal4 = 0; var SumEntryVal5 = 0; var SumEntryVal6 = 0; var SumEntryVal7 = 0; var SumEntryVal8 = 0; var SumEntryVal9 = 0; var SumEntryVal10 = 0; var SumEntryVal11 = 0; var SumEntryVal12 = 0; var SumEntryVal13 = 0; var SumEntryVal14 = 0; var SumEntryVal15 = 0;
        var TotalOptionAltPcs = 0;
        var SumOptionTotal1 = 0; var SumOptionTotal2 = 0; var SumOptionTotal3 = 0; var SumOptionTotal4 = 0; var SumOptionTotal5 = 0; var SumOptionTotal6 = 0; var SumOptionTotal7 = 0; var SumOptionTotal8 = 0; var SumOptionTotal9 = 0; var SumOptionTotal10 = 0; var SumOptionTotal11 = 0; var SumOptionTotal12 = 0; var SumOptionTotal13 = 0; var SumOptionTotal14 = 0; var SumOptionTotal15 = 0; var SumOptionAltPcs = 0;
        var SumCutTotal1 = 0; var SumCutTotal2 = 0; var SumCutTotal3 = 0; var SumCutTotal4 = 0; var SumCutTotal5 = 0; var SumCutTotal6 = 0; var SumCutTotal7 = 0; var SumCutTotal8 = 0; var SumCutTotal9 = 0; var SumCutTotal10 = 0; var SumCutTotal11 = 0; var SumCutTotal12 = 0; var SumCutTotal13 = 0; var SumCutTotal14 = 0; var SumCutTotal15 = 0; var SumCutAltPcs = 0;

        //TotalOptionAltPcs = parseInt(hdn_totoal1alt) + parseInt(OptionAltPcs);

        if ((FormType == 'Stitching') || (FormType == 'Finishing') || (FormType == 'CutReady')) {
            if (lastno == '1') {
                if ((parseInt(hdn_totoal1) + parseInt(EntryVal1)) > ReadyQty1) {
                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry1']").val("");
                    return false;
                }
            }

            if (lastno == '2') {
                if ((parseInt(hdn_totoal2) + parseInt(EntryVal2)) > ReadyQty2) {
                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry2']").val("");
                    return false;
                }

            }
            if (lastno == '3') {
                if ((parseInt(hdn_totoal3) + parseInt(EntryVal3)) > ReadyQty3) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry3']").val("");
                    return false;
                }

            }
            if (lastno == '4') {
                if ((parseInt(hdn_totoal4) + parseInt(EntryVal4)) > ReadyQty4) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry4']").val("");
                    return false;
                }

            }
            if (lastno == '5') {
                if ((parseInt(hdn_totoal5) + parseInt(EntryVal5)) > ReadyQty5) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry5']").val("");
                    return false;
                }
            }
            if (lastno == '6') {
                if ((parseInt(hdn_totoal6) + parseInt(EntryVal6)) > ReadyQty6) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry6']").val("");
                    return false;
                }

            }
            if (lastno == '7') {
                if ((parseInt(hdn_totoal7) + parseInt(EntryVal7)) > ReadyQty7) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry7']").val("");
                    return false;
                }

            }

            if (lastno == '8') {
                if ((parseInt(hdn_totoal8) + parseInt(EntryVal8)) > ReadyQty8) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry8']").val("");
                    return false;
                }

            }
            if (lastno == '9') {
                if ((parseInt(hdn_totoal9) + parseInt(EntryVal9)) > ReadyQty9) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry9']").val("");
                    return false;
                }

            }

            if (lastno == '10') {
                if ((parseInt(hdn_totoal10) + parseInt(EntryVal10)) > ReadyQty10) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry10']").val("");
                    return false;
                }

            }
            if (lastno == '11') {
                if ((parseInt(hdn_totoal11) + parseInt(EntryVal11)) > ReadyQty11) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry11']").val("");
                    return false;
                }

            }
            if (lastno == '12') {
                if ((parseInt(hdn_totoal12) + parseInt(EntryVal12)) > ReadyQty12) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry12']").val("");
                    return false;
                }

            }
            if (lastno == '13') {
                if ((parseInt(hdn_totoal13) + parseInt(EntryVal13)) > ReadyQty13) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry13']").val("");
                    return false;
                }

            }
            if (lastno == '14') {
                if ((parseInt(hdn_totoal14) + parseInt(EntryVal14)) > ReadyQty14) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry14']").val("");
                    return false;
                }

            }
            if (lastno == '15') {
                if ((parseInt(hdn_totoal15) + parseInt(EntryVal15)) > ReadyQty15) {

                    alert(Stich_Finish_msg);
                    $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_txtOptionEntry15']").val("");
                    return false;
                }

            }
        }
        SumOptionTotal1 = parseInt(hdn_totoal1) + parseInt(EntryVal1);
        SumOptionTotal2 = parseInt(hdn_totoal2) + parseInt(EntryVal2);
        SumOptionTotal3 = parseInt(hdn_totoal3) + parseInt(EntryVal3);
        SumOptionTotal4 = parseInt(hdn_totoal4) + parseInt(EntryVal4);
        SumOptionTotal5 = parseInt(hdn_totoal5) + parseInt(EntryVal5);
        SumOptionTotal6 = parseInt(hdn_totoal6) + parseInt(EntryVal6);
        SumOptionTotal7 = parseInt(hdn_totoal7) + parseInt(EntryVal7);
        SumOptionTotal8 = parseInt(hdn_totoal8) + parseInt(EntryVal8);
        SumOptionTotal9 = parseInt(hdn_totoal9) + parseInt(EntryVal9);
        SumOptionTotal10 = parseInt(hdn_totoal10) + parseInt(EntryVal10);
        SumOptionTotal11 = parseInt(hdn_totoal11) + parseInt(EntryVal11);
        SumOptionTotal12 = parseInt(hdn_totoal12) + parseInt(EntryVal12);
        SumOptionTotal13 = parseInt(hdn_totoal13) + parseInt(EntryVal13);
        SumOptionTotal14 = parseInt(hdn_totoal14) + parseInt(EntryVal14);
        SumOptionTotal15 = parseInt(hdn_totoal15) + parseInt(EntryVal15);

        SumOptionAltPcs = parseInt(hdn_totoal1alt) + parseInt(OptionAltPcs);
        SumCutTotal1 = isNaN((SumOptionTotal1 / OredrQty1) * 100) == true ? 0 : parseFloat((SumOptionTotal1 / OredrQty1) * 100).toFixed(0);
        SumCutTotal2 = isNaN((SumOptionTotal2 / OredrQty2) * 100) == true ? 0 : parseFloat((SumOptionTotal2 / OredrQty2) * 100).toFixed(0);
        SumCutTotal3 = isNaN((SumOptionTotal3 / OredrQty3) * 100) == true ? 0 : parseFloat((SumOptionTotal3 / OredrQty3) * 100).toFixed(0);
        SumCutTotal4 = isNaN((SumOptionTotal4 / OredrQty4) * 100) == true ? 0 : parseFloat((SumOptionTotal4 / OredrQty4) * 100).toFixed(0);
        SumCutTotal5 = isNaN((SumOptionTotal5 / OredrQty5) * 100) == true ? 0 : parseFloat((SumOptionTotal5 / OredrQty5) * 100).toFixed(0);
        SumCutTotal6 = isNaN((SumOptionTotal6 / OredrQty6) * 100) == true ? 0 : parseFloat((SumOptionTotal6 / OredrQty6) * 100).toFixed(0);
        SumCutTotal7 = isNaN((SumOptionTotal7 / OredrQty7) * 100) == true ? 0 : parseFloat((SumOptionTotal7 / OredrQty7) * 100).toFixed(0);
        SumCutTotal8 = isNaN((SumOptionTotal8 / OredrQty8) * 100) == true ? 0 : parseFloat((SumOptionTotal8 / OredrQty8) * 100).toFixed(0);
        SumCutTotal9 = isNaN((SumOptionTotal9 / OredrQty9) * 100) == true ? 0 : parseFloat((SumOptionTotal9 / OredrQty9) * 100).toFixed(0);
        SumCutTotal10 = isNaN((SumOptionTotal10 / OredrQty10) * 100) == true ? 0 : parseFloat((SumOptionTotal10 / OredrQty10) * 100).toFixed(0);
        SumCutTotal11 = isNaN((SumOptionTotal11 / OredrQty11) * 100) == true ? 0 : parseFloat((SumOptionTotal11 / OredrQty11) * 100).toFixed(0);
        SumCutTotal12 = isNaN((SumOptionTotal12 / OredrQty12) * 100) == true ? 0 : parseFloat((SumOptionTotal12 / OredrQty12) * 100).toFixed(0);
        SumCutTotal13 = isNaN((SumOptionTotal13 / OredrQty13) * 100) == true ? 0 : parseFloat((SumOptionTotal13 / OredrQty13) * 100).toFixed(0);
        SumCutTotal14 = isNaN((SumOptionTotal14 / OredrQty14) * 100) == true ? 0 : parseFloat((SumOptionTotal14 / OredrQty14) * 100).toFixed(0);
        SumCutTotal15 = isNaN((SumOptionTotal15 / OredrQty15) * 100) == true ? 0 : parseFloat((SumOptionTotal15 / OredrQty15) * 100).toFixed(0);
        //SumCutAltPcs = isNaN((OptionAltPcs / OptionAltPcs) * 100) == true ? 0 : parseInt(SumCutAltPcs) + parseInt(OptionAltPcs);


        $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblTotalEntryAlt']").html(SumOptionAltPcs);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnTotalEntryAlt']").val(SumOptionAltPcs);
        //$("#<%= grdSizeOption1.ClientID %> input[id$='" + Ids + "_hdnAltPcs']").val(TotalOptionAltPcs);

        var IdsArr1 = Ids.split("ctl");
        var rowno = IdsArr1[1];
        var gvId = '';
        RowId = parseInt(rowno) + 1;
        if (RowId < 10)
            gvId = 'ctl0' + RowId;
        else
            gvId = 'ctl' + RowId;


        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal1']").html(SumOptionTotal1);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal2']").html(SumOptionTotal2);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal3']").html(SumOptionTotal3);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal4']").html(SumOptionTotal4);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal5']").html(SumOptionTotal5);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal6']").html(SumOptionTotal6);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal7']").html(SumOptionTotal7);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal8']").html(SumOptionTotal8);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal9']").html(SumOptionTotal9);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal10']").html(SumOptionTotal10);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal11']").html(SumOptionTotal11);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal12']").html(SumOptionTotal12);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal13']").html(SumOptionTotal13);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal14']").html(SumOptionTotal14);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotal15']").html(SumOptionTotal15);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotalAltPcs']").html(SumOptionAltPcs);

        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal1']").val(SumOptionTotal1);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal2']").val(SumOptionTotal2);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal3']").val(SumOptionTotal3);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal4']").val(SumOptionTotal4);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal5']").val(SumOptionTotal5);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal6']").val(SumOptionTotal6);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal7']").val(SumOptionTotal7);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal8']").val(SumOptionTotal8);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal9']").val(SumOptionTotal9);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal10']").val(SumOptionTotal10);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal11']").val(SumOptionTotal11);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal12']").val(SumOptionTotal12);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal13']").val(SumOptionTotal13);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal14']").val(SumOptionTotal14);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnGrandTotal15']").val(SumOptionTotal15);


        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut1']").html(SumCutTotal1);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut2']").html(SumCutTotal2);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut3']").html(SumCutTotal3);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut4']").html(SumCutTotal4);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut5']").html(SumCutTotal5);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut6']").html(SumCutTotal6);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut7']").html(SumCutTotal7);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut8']").html(SumCutTotal8);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut9']").html(SumCutTotal9);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut10']").html(SumCutTotal10);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut11']").html(SumCutTotal11);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut12']").html(SumCutTotal12);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut13']").html(SumCutTotal13);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut14']").html(SumCutTotal14);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandCut15']").html(SumCutTotal15);
        //$("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotalCutAltPcs']").html(SumCutAltPcs);

        var OrderQtyTotal = $("#<%= grdSizeOption1.ClientID %> span[id$='" + Ids + "_lblOrderQtyTotal']").html();
        var FinalSumEntryVal = parseInt(EntryVal1) + parseInt(EntryVal2) + parseInt(EntryVal3) + parseInt(EntryVal4) + parseInt(EntryVal5) + parseInt(EntryVal6) + parseInt(EntryVal7) + parseInt(EntryVal8) + parseInt(EntryVal9) + parseInt(EntryVal10) + parseInt(EntryVal11) + parseInt(EntryVal12) + parseInt(EntryVal13) + parseInt(EntryVal14) + parseInt(EntryVal15); //+ parseInt(TotalOptionAltPcs);
        var FinalSumOptionTotal = parseInt(SumOptionTotal1) + parseInt(SumOptionTotal2) + parseInt(SumOptionTotal3) + parseInt(SumOptionTotal4) + parseInt(SumOptionTotal5) + parseInt(SumOptionTotal6) + parseInt(SumOptionTotal7) + parseInt(SumOptionTotal8) + parseInt(SumOptionTotal9) + parseInt(SumOptionTotal10) + parseInt(SumOptionTotal11) + parseInt(SumOptionTotal12) + parseInt(SumOptionTotal13) + parseInt(SumOptionTotal14) + parseInt(SumOptionTotal15);  //+ parseInt(SumOptionAltPcs);
        var FinalSumPassTotal = parseInt(SumOptionTotal1) + parseInt(SumOptionTotal2) + parseInt(SumOptionTotal3) + parseInt(SumOptionTotal4) + parseInt(SumOptionTotal5) + parseInt(SumOptionTotal6) + parseInt(SumOptionTotal7) + parseInt(SumOptionTotal8) + parseInt(SumOptionTotal9) + parseInt(SumOptionTotal10) + parseInt(SumOptionTotal11) + parseInt(SumOptionTotal12) + parseInt(SumOptionTotal13) + parseInt(SumOptionTotal14) + parseInt(SumOptionTotal15);
        var FinalSumCutTotal = parseFloat((FinalSumOptionTotal * 100) / OrderQtyTotal).toFixed(0);

        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblFinalEntryTotal']").html(FinalSumEntryVal);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnFinalEntryTotal']").val(FinalSumEntryVal);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblFinalGrandTotal']").html(FinalSumOptionTotal);
        $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnFinalPassValue']").val(FinalSumPassTotal);
        $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblFinalCutTotal']").html(FinalSumCutTotal + ' %');
        var FinalSumPassEntry = parseInt(FinalSumEntryVal);  //- parseInt(TotalOptionAltPcs)
        $("#<%=hdnTotalEntry.ClientID%>").val(FinalSumPassEntry);
        $("#<%=hdnTotalAlt.ClientID%>").val(OptionAltPcs);

        var Altpercent = ((SumOptionAltPcs / (SumOptionAltPcs + FinalSumOptionTotal)) * 100).toFixed(0);
        if (!isNaN(Altpercent))
            $("#<%= grdSizeOption1.ClientID %> span[id$='" + gvId + "_lblGrandTotalCutAltPcs']").html(Altpercent);

        SubmitButtonEnable();
    }

    function CallParentPage() {
        var grdSizeOption1Row = $(".grdSizeOption1Row").length;
        var RowId = parseInt(grdSizeOption1Row) + 2;
        if (RowId < 10)
            gvId = 'ctl0' + RowId;
        else
            gvId = 'ctl' + RowId;

        var FinalEntryTotal = $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnFinalEntryTotal']").val();
        var TotalEntryAlt = $("#<%= grdSizeOption1.ClientID %> input[id$='" + gvId + "_hdnTotalEntryAlt']").val();

    }

    //abhishek 
    var totalEntrysum = 0;
    var totalAltpcs = 0;
    var elamRef = "";

    function SubmitButtonEnable() {
        var FormType = '<%=this.FormType %>';
        var controlID = '<%=this.ControlID %>';
        var Totalpcs = $("#<%=hdnTotalEntry.ClientID%>").val();
        var Totalaltpcs = $("#<%=hdnTotalAlt.ClientID%>").val();
        Totalpcs = parseInt(Totalpcs);
        Totalaltpcs = parseInt(Totalaltpcs);

        if (FormType == "Cutting") {
            $(".totalvalscss").html("<b>Total Cut Pcs:</b>" + "&nbsp;&nbsp;" + Totalpcs);
            $(".totalAltPcs").html("");
        }
        if (FormType == "Stitching") {
            $(".totalvalscss").html("<b>Total Stitch Pcs:</b>" + "&nbsp;&nbsp;" + Totalpcs);
            $(".totalAltPcs").html("<b>Total Alt / Rej.:</b>" + "&nbsp;&nbsp;" + Totalaltpcs);
        }
        if (FormType == "Finishing") {
            $(".totalvalscss").html("<b>Total Finish Pcs:</b>" + "&nbsp;&nbsp;" + Totalpcs);
            $(".totalAltPcs").html("");
        }
        if (FormType == "CutReady") {
            $(".totalvalscss").html("<b>Total CutReady Pcs:</b>" + "&nbsp;&nbsp;" + Totalpcs);
            $(".totalAltPcs").html("");
        }

        if (FormType == "Stitching") {
            if (Totalpcs <= 0 && Totalaltpcs <= 0) {
            }
            else {
                $(".saveSize").attr("style", "display:inline");
            }
        }
        if (FormType == "Cutting") {

            if (Totalpcs <= 0) {
            }
            else {
                $(".saveSize").attr("style", "display:inline");
            }

        }
        if (FormType == "CutReady") {

            if (Totalpcs <= 0) {
            }
            else {
                $(".saveSize").attr("style", "display:inline");
            }

        }
        if (FormType == "Finishing") {

            if (Totalpcs <= 0) {

            }
            else {
                $(".saveSize").attr("style", "display:inline");
            }

        }

    }


    function CallBackParentPage() {
        SubmitButtonEnable();
        var FormType = '<%=this.FormType %>';
        var controlID = '<%=this.ControlID %>';
        var Totalpcs = $("#<%=hdnTotalEntry.ClientID%>").val();
        var Totalaltpcs = $("#<%=hdnTotalAlt.ClientID%>").val();

        Totalpcs = parseInt(Totalpcs);
        Totalaltpcs = parseInt(Totalaltpcs);

        var Msg = $(".ShowMsg").html();

        if (FormType == "Stitching") {
            if (Totalpcs <= 0 && Totalaltpcs <= 0) {
                alert('Totalpcs or Altpcs could not be zero (0)');
                return false;
            }
            else {
                window.parent.Shadowbox.close();
                return true;
            }
        }
        if (FormType == "Cutting") {

            if (Totalpcs <= 0) {
                alert('Totalpcs could not be zero (0)');
                return false;
            }
            else {
                if (Msg == '') {
                    window.parent.Shadowbox.close();
                    return true;
                }
                else {
                    return false;
                }
            }

        }
        if (FormType == "CutReady") {

            if (Totalpcs <= 0) {
                alert('Totalpcs could not be zero (0)');
                return false;
            }
            else {
                if (Msg == '') {
                    window.parent.Shadowbox.close();
                    return true;
                }
                else {
                    return false;
                }
            }

        }
        if (FormType == "Finishing") {

            if (Totalpcs <= 0) {
                alert('Totalpcs could not be zero (0)');
                return false;
            }
            else {
                window.parent.Shadowbox.close();
                return true;
            }

        }

    }
    
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
        
        
        body
        {
            font-family: Arial;
            font-size: 12px;
            color: #787777;
        }
        .cfn_footer td
        {
            /* background-image: url(../../images/cs_bg2.jpg); */
            width: 258px;
            
            text-align: center;
            font-size: 11px;
            font-family: Verdana;
        }
        .cfn_footer td span
        {
            color: #ffffff !important;
        }
        .cfn_footer tr
        {
            height: 25px;
        }
        
        .borderbottom
        {
            border: 1px solid #000000;
            border-top: none;
            border-right: none;
            border-left: none;
            color: #787777;
        }
        .border2 th
        {
            padding: 5px;
        }
        
        input
        {
            margin-top: 2px;
        }
        form
        {
            padding:0px 15px;
        }
        .cfn_footer td table tr:nth-child(1)		{  background: #3a5795; }
        .cfn_footer td table tr:nth-child(2)		{ background-color:#979292; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:HiddenField ID="hdnOrderId" runat="server" />
                <asp:HiddenField ID="hdnOrderDetailId" runat="server" />
                <asp:HiddenField ID="hdnType" runat="server" />
                <asp:HiddenField ID="hdnStyleId" runat="server" />
                <asp:HiddenField ID="hdnStyleNumber" runat="server" />
                <asp:HiddenField ID="hdnTotalEntry" Value="0" runat="server" />
                <asp:HiddenField ID="hdnTotalAlt" Value="0" runat="server" />
                <asp:HiddenField ID="hdnCutQty" Value="0" runat="server" />
                <asp:HiddenField ID="hdnUnitId" Value="0" runat="server" />
                <asp:Label ID="lblMsg" CssClass="ShowMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <h2 style="background: #3a5795; padding: 5px 0px; margin:0px; color: #fff;">
                   <asp:Label ID="lblHeading" runat="server"></asp:Label> &nbsp; Entry
                </h2>
            </td>
        </tr>
        <tr style="display:none;">
            <td>
                <asp:Label ID="lblTotalOrderQty" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px !important;" id="td1" runat="server" visible="false">
                <asp:GridView ID="grdSizeOption1" runat="server" AutoGenerateColumns="false" FooterStyle-CssClass="cfn_footer"
                    RowStyle-Font-Size="12px" FooterStyle-Font-Size="12px" ShowFooter="true" Width="100%"
                    EmptyDataText="hello" CssClass="border2" RowStyle-CssClass="borderbottom" OnRowDataBound="grdSizeOption1_RowDataBound">
                    <RowStyle CssClass="grdSizeOption1Row" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="375px" ItemStyle-Width="75px">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'
                                    runat="server">
                                    <img style="height:80px !important; width:60px !important;" alt="" border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'/>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" ItemStyle-Width="180px">
                            <ItemStyle CssClass="cfn3" />
                            <ItemTemplate>
                                Serial No.:-
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label><br />
                                Contract:-
                                <asp:Label ID="lblOptionNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label><br />
                                <asp:Label ID="lblFabricDetails" ForeColor="#ABA5A5" runat="server" Text='<%# Eval("FabricDetails") %>'></asp:Label>
                                <asp:HiddenField ID="hdnGvOrderDetailId" Value='<%# Eval("OrderDetailId") %>' runat="server" />
                                <asp:HiddenField ID="hdnQuantity" Value='<%# Eval("Quantity") %>' runat="server" />
                                <asp:HiddenField ID="hdnSizeOption" Value='<%# Eval("SizeOption") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-Width="120px" HeaderStyle-Width="60px"
                            FooterStyle-Width="120px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" style="color: #787777;">
                                    <tr>
                                        <td class="qty-bor">
                                            <asp:Label ID="lblOrderQty" runat="server" Text="Order Qty."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor">
                                            <asp:Label ID="lblReadyQty" runat="server" Text="CutReady Qty."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPcs" runat="server" Text="Cut Pcs."></asp:Label>
                                        </td>
                                    </tr>
                                    <%--  <tr>
                                        <td class="head-in bot-bor">
                                            <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%-- <tr>
                                        <td style="color: Black; font-weight: bold;">
                                            <asp:Label ID="lblOptionEntry" runat="server" Text="Cut Today"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal" runat="server" Text="Cut Total"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblCutPercent" runat="server" Text="Cut %"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblOredrQty1" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty1" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox Width="30px" MaxLength="3" ID="txtOptionEntry1" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal1" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal1" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry1" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal1" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal1" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty2" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty2" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry2" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal2" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal2" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%-- <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry2" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal2" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal2" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty3" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty3" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry3" Width="30px" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" MaxLength="3" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal3" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%--  <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal3" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry3" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal3" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal3" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut3" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty4" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty4" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry4" Width="30px" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" MaxLength="3" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal4" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal4" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%-- <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry4" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal4" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal4" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut4" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblOredrQty5" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty5" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry5" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal5" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal5" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--  <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry5" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal5" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal5" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut5" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty6" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty6" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry6" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal6" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal6" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%-- <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry6" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal6" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal6" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut6" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty7" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty7" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry7" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal7" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal7" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--  <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry7" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal7" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal7" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut7" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty8" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty8" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry8" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal8" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal8" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry8" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal8" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal8" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut8" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty9" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty9" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry9" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal9" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal9" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--  <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry9" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal9" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal9" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut9" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty10" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty10" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry10" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal10" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal10" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry10" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal10" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal10" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut10" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty11" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty11" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry11" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal11" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%--    <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal11" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry11" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal11" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal11" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut11" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty12" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty12" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry12" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal12" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal12" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%-- <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry12" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal12" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal12" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut12" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty13" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty13" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry13" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal13" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal13" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%-- <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry13" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal13" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal13" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut13" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="100px" ItemStyle-Width="60px"
                            FooterStyle-Width="60px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty14" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty14" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry14" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal14" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal14" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--  <tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry14" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal14" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal14" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut14" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="100px" ItemStyle-Width="90px"
                            FooterStyle-Width="90px">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblOredrQty15" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            <asp:Label ID="lblReadyQty15" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionEntry15" Width="30px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnOptionTotal15" Value="0" runat="server" />
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionTotal15" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntry15" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotal15" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnGrandTotal15" Value='0' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandCut15" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="100px" ItemStyle-Width="90px"
                            FooterStyle-Width="90px" HeaderStyle-CssClass ="HideAlt" ItemStyle-CssClass ="HideAlt" FooterStyle-CssClass ="HideAlt">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                            <%--<asp:Label ID="lblOredrQtyAltPcs" Style="font-size: 11px;" runat="server"></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td class="qty-bor" align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtOptionAltPcs" Width="40px" MaxLength="3" onblur="javascript:return CalculateGrdSizeOption1(this)"
                                                CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnAltPcs" Value='<%# Eval("AltPcs") %>' runat="server" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="bot-bor">
                                            &nbsp;
                                            <asp:Label ID="OptionAltPcsTotal" Text='<%# Eval("AltPcs") %>' Style="font-size: 11px;"
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="lblTotalEntryAlt" runat="server"></asp:Label>
                                          
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotalAltPcs" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnTotalEntryAlt" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblGrandTotalCutAltPcs" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="dspnone" ItemStyle-Width="100px"
                            FooterStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" style="vertical-align:top;" class="size-set-total">
                                    <tr>
                                        <td align="center" class="qty-bor">
                                            <asp:Label ID="lblOrderQtyTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Cutready">
                                        <td align="center" style="border-bottom:1px solid gray; height: 15px; padding: 2px 0;">
                                            <asp:Label ID="lblReadyQtyTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="qty-bor">
                                            <asp:Label ID="lblEntryTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="bot-bor">
                                            &nbsp;<asp:Label ID="lblOptionTotal" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <%--  <tr>
                                        <td>
                                            <asp:Label ID="lblFinalEntryTotal" runat="server"></asp:Label>
                                            
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="foot-bor">
                                            &nbsp;<asp:Label ID="lblFinalGrandTotal" Style="font-size: 11px;" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnFinalPassValue" Value="0" runat="server" />
                                            <asp:HiddenField ID="hdnFinalEntryTotal" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="foot-bor">
                                            <asp:Label ID="lblFinalCutTotal" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnFinalCutValue" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                       <b> <asp:Label ID="lblEmptyMsg" runat="server" Text="You can not enter data"></asp:Label></b>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
       
    </table>
    <table width="100%" cellpadding="0" cellspacing="0">
     <tr>
            <td align="center" id="HistoryHeading" runat ="server" visible="false">
                <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; margin:0px;">
                   <asp:Label ID="lblHeadingHistory" runat="server"></asp:Label> &nbsp; History
                </h2>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px !important; width: 300px; vertical-align:top; display:none;">
                <asp:GridView ID="gdvOrderDetailsHistory" runat="server" AutoGenerateColumns="false"
                    FooterStyle-CssClass="cfn_footer" RowStyle-Font-Size="12px" FooterStyle-Font-Size="12px"
                    ShowFooter="false" Width="100%" CssClass="border2" RowStyle-CssClass="borderbottom"
                    HeaderStyle-Height="45px">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="75" ItemStyle-Width="75">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'
                                    runat="server">
                                    <img style="height:65px !important; width:65px !important;" alt=""
                                    border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'/>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                            <ItemStyle CssClass="cfn3" />
                            <ItemTemplate>
                                Serial No.:-
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label><br />
                                Contract:-
                                <asp:Label ID="lblOptionNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label><br />
                                <asp:Label ID="lblFabricDetails" runat="server" Text='<%# Eval("FabricDetails") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td style="padding-top: 10px !important;" id="td2" runat="server" valign="top">
                <asp:GridView ID="gdvSizeHistory" runat="server" AutoGenerateColumns="false" FooterStyle-CssClass="cfn_footer"
                    RowStyle-Font-Size="12px" FooterStyle-Font-Size="12px" ShowFooter="false" Width="100%"
                    HeaderStyle-Height="45px" Style="text-align: center;" CssClass="border2" RowStyle-CssClass="borderbottom"
                    OnRowDataBound="gdvSizeHistory_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="380px" HeaderStyle-Width="380px">
                            <ItemTemplate>
                                <asp:Label ID="lblSlotCreatedDate" runat="server" Text='<%# Eval("SlotDate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty1" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty3" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty4" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty5" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty6" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty7" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty8" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty9" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty10" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty11" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty12" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty13" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty14" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="lblQty15" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblAlt" runat="server" Text="0"></asp:Label>
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="0px" HeaderStyle-Width="0px">
                            <ItemTemplate>
                                <asp:Label ID="lblAltpercent" runat="server" Text="0"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPass" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <b><asp:Label ID="lblEmptyHistoryMsg" runat="server" Text="There is no history records."></asp:Label></b>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>


         <tr>
            <td align="left">
                <asp:Label ID="lblCut" runat="server" Text="" CssClass=""></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lblCutPcs" runat="server" Text="" CssClass="totalCut"></asp:Label>
                <asp:Label ID="lblCutReady" runat="server" Text="" CssClass="" Visible="false"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lblCutReadyPcs" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                <asp:Label ID="lbltot" runat="server" Text="" CssClass="totalvalscss"></asp:Label>
                <asp:Label ID="lbltotAltpcs" runat="server" Text="" CssClass="totalAltPcs"></asp:Label>
            </td>
        </tr>
        <%--end abhishek --%>
        <tr>
            <td align="right" style="padding-right: 3px;">
                <asp:Button ID="btnSubmit" CssClass="saveSize submit" runat="server" Text="" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
         
                <asp:Button ID="btnClose" runat="server"  style="bottom:10px;" CssClass="close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
