<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QC.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.QC"%>
 <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
 <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style type="text/css">
/*.overlay {position: fixed;left: 0px;top: 0px;width: 100%;height: 100%;z-index: 9999; background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;}*/
    body
    {
        margin: 0px;
        padding: 0px;
        font-family: "Lucida Sans Unicode";
        font-size: 12px;
    }
   .gray {
    color: #7b7777;
}
    .top th
    {
        background-color:#dddfe4 !important;
       color: #575759 !important;
        font-size: 10px !important; 
        font-weight: normal;
        line-height: 15px;
        text-align: left;
        text-transform: capitalize;
        width: 40%;
        padding: 0px 5px;
         border:1px solid #b7b4b4;
    }
    th
    {
        background-color:#dddfe4 !important;
       color: #575759 !important;
        font-size: 10px !important; 
      font-weight: normal;
        line-height: 15px !important;
        text-transform: capitalize !important;
        font-family: verdana;
    }
    .form_heading
    {
        background-color: #39589c;
        color: #fff;
        font-size: 12px;
       
        margin: 0px auto 0px;
        text-align: center;
        padding:1px 0px;
        border-bottom: 0px;
    }
    table td
    {
        padding: 0px 3px;
    }
    .mid th
    {
        background-color:#dddfe4 !important;
       color: #575759 !important;
       
        font-size: 10px !important; 
    
        line-height: 15px;
        text-align: left;
        text-transform: capitalize;
        width: 15%;
        padding: 2px 5px;
    }
    input
    {
        border: 0px;
        text-align: center;
    }
    .blue
    {
        color: blue;
    }
    .input-field
    {
        border: 1px solid #ccc;
        width: 50px;
    }
    .item_list TH {
     background-color:#dddfe4 !important;
       color: #575759 !important;
        font-size: 10px !important;
        padding:1px 4px; 
        
    }
    .style_number_box_background 
    {
        opacity:0.9;
        background:grey;
        width:2289px;
    }
    .style_number_box  
    {
        padding:0px !important;
        width:550px !important;
        border:none;
           
    }
   
    .style_number_box  table
    {
        border:1px solid gray;
        padding-bottom:5px;
    }
    .style_number_box div
    {
        background-color: #39589c;
	color: #fff;
	font-size: 14px;
	font-weight: bold;
	
	text-align: center;
	text-transform: capitalize;
	width: 100%;
	padding: 1px 0px;
    }
    .b
    {
        font-weight:bold;
    }
    #tableFaults1 td {
    padding:0px 3px !important;
}
#tableFaults1 TD select {

    padding: 2px 0px;
}
.item_list  th
{
    height:auto;
}
#sb-wrapper
{
    top:50px !important;
    left:300px !important;
    position:absolute !important;
}
.style_number_box
{
    top:50px !important;
    left:30% !important;
    position:absolute !important;
}
 .style_number_box_Contract
    {
         width:800px !important;
         left:25% !important;
    }
.validation_messagebox
{
    top:7%;
}
.imgupload img
{
    height:20px;
    width:20px;
    vertical-align: middle;
}
select option{
text-transform:capitalize !important;
}
select{
text-transform:capitalize !important;
}
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
     .remove-div
     {
         background:#fff;
     }
       .remove-div th
       {
           width:auto !important;
           text-align:center;
       }
     .remove-div td{
     color: #999;
     font-weight:normal;
     font-size:10px;
     }
     .remove-div div
     {
         background:none;
     }
   
    .Header th
    {
        background-color:#dddfe4 !important;
       color: #575759 !important;
    border: 1px solid gray;
    font-size: 11px !important;
    }
    .presntcorr input
    {
        vertical-align:middle;
        margin:0px;
    }
    .presntcorr
    {
        font-size:11px;
        padding:0px 1px 0px 1px
    }
    .item_list TD {
  
    text-align: left;
   
}
.item_list td:first-child {
    border-left-color:#b7b4b4 !important;
}
.item_list td:last-child {
    border-right-color:#b7b4b4 !important;
}
.item_list tr:last-child > td {
    border-bottom-color:#b7b4b4 !important;
}
.border-color td:first-child {
    border-left-color:#b7b4b4 !important;
}
.border-color td:last-child {
    border-right-color:#b7b4b4 !important;
}
.border-color tr:last-child > td {
    border-bottom-color:#b7b4b4 !important;
}
.border-color td
{
    border: 1px solid #e4dede;
}
.border-color th
{
    border: 1px solid #b7b4b4;
}
.uploadfile { display: none; }
label.choose:before {
  background: none repeat scroll 0 0 #00B7CD;
  border: 0 none;
  color: #FFFFFF;
  cursor: pointer;
  font-family: 'Altis_Book';
  font-size: 15px;
  padding: 3px 15px;
}
label.choose:before {
  content: 'upload 1st 50 pcs';
  padding: 3px 6px;
  position: absolute;
}
.RescanBtn
{
    display:none !important;
}
.checkMar td input[type='checkbox']
{
    position: relative;
    top: -1px;
    left: 2px;
 }
 .chkQAManager
 {
    position: relative;
    top: 3px;
   
  }
  .item_list TD input[type=text], .item_list TD textarea {
  
    width: 96%;
  
}
input[type="radio"]
{
    position:relative;
    top:2px;
 }
</style>


<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>

<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var lblQtyChecked;
    var lblSize;

    $(function () {
        //  debugger;
        calcQtyChecked();
        getStatus(true);
        ShowHideInspection();
        //ChangeProcess(1);
        var ChkWithOutNature = $(".clsChkWithOutNature input:checked").length;
        if (parseInt(ChkWithOutNature) > 0) {
            var objhdnRadioStatus = $('.hidden_status');
            $(".clsDivrptFault").hide();
            //$('input[id$=rbtnPass]').attr('checked', 'checked');
            //$('#ctl00_cph_main_content_QC_lblStatus').text('PASS');
            //$('.tdstatus').css('backgroundColor', '#01cc01');
            // alert("3");
            //objhdnRadioStatus.val("1");
            //ChangeStatus('Pass')
        }
        else {
            initializer();
        }
        var IsOpenAllContractsPopUp = $('#<%=hdnIsOpenAllContractsPopUp.ClientID %>').val();
        if (IsOpenAllContractsPopUp == "1") {
            ShowQCAllContracts();
        }
        var chkCQD = $('input[name="ctl00$cph_main_content$QC$chkCQD_QAManager"]:checked').length > 0;
        if (chkCQD) {
            document.getElementById("ctl00_cph_main_content_QC_chkCQD_QAManager").disabled = true;
        }
    });

    var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
    prmInstance.add_endRequest(function () {
        //you need to re-bind your jquery events here
        initializer();
    });

    function initializer() {
        // debugger;
        $("input.NatureOfFaults", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestNatureOfFaults", { dataType: "xml", datakey: "string", max: 100 });
        $("input.NatureOfFaults", "#main_content").result(function () {
            //debugger;
            var This = $(this);
            var Faults = $(this).val();
            var FaultId = $(this).attr('id');
            OnNatureOfFaultsChange(Faults, FaultId, This);
            HideZero();
            SHowHideFile();
            SHowHideFileIE();
        });

        $("input.Faultname", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestNatureOfFaults", { dataType: "xml", datakey: "string", max: 100 });
        $("input.Faultname", "#main_content").result(function () {
            //debugger;
            var This = $(this);
            var Faults = $(this).val();
            var FaultId = $(this).attr('id');
            //OnFaultNameChange(Faults, FaultId, This);           
        });


    }

    function OnNatureOfFaultsChange(Faults, FaultId, This) {
        //debugger;
        var Ids = FaultId.split('_')[6];
        proxy.invoke("GetNatureOfFaultsValues", { NatureOfFaults: Faults },
                        function (result) {
                            //debugger;
                            $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_hdnNatureOfFaults').val(result);

                            var NatureOfFaultValue = $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_hdnNatureOfFaults').val();
                            NatureOfFaultValue = NatureOfFaultValue.substring(NatureOfFaultValue.indexOf("-") + 1);

                            if (NatureOfFaultValue == 1) {
                                $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_lblClassification').html("Critical");
                                $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_hdnClassificationId').val(1);
                                This.closest('td').next('td').css('backgroundColor', '#ff3300');
                            }
                            else if (NatureOfFaultValue == 2) {
                                $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_lblClassification').html("Major");
                                $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_hdnClassificationId').val(2);
                                This.closest('td').next('td').css('backgroundColor', '#fd9903');
                            }
                            else if (NatureOfFaultValue == 3) {
                                $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_lblClassification').html("Minor");
                                $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_hdnClassificationId').val(3);
                                This.closest('td').next('td').css('backgroundColor', '#FFFF00');
                            }
                            else {
                                $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_lblClassification').html("");
                                This.closest('td').next('td').css('backgroundColor', '#FFFFFF');
                            }

                        });
    }

    function OnFaultNameChange(Faults, FaultId, This) {
        //debugger;
        var Ids = FaultId.split('_')[6];
        proxy.invoke("GetNatureOfFaultsValues", { NatureOfFaults: Faults },
                        function (result) {
                            //debugger;
                            $('#ctl00_cph_main_content_QC_rptFault_' + Ids + '_hdnNatureOfFaults').val(result);

                        });
    }


    function ShowHideInspection() {
        //  debugger;
        var InspectionType = '<%=this.InspectionID %>';
        var rdoPass = $('input[id$=rbtnPass]').attr('checked'); //$('input[name="radioStatus"][value="1"]').attr('checked');
        var chkCQD = $('input[name="ctl00$cph_main_content$QC$chkCQD_QAManager"]:checked').length > 0;
        var chkDMM = $('input[name="ctl00$cph_main_content$QC$chk_DMM"]:checked').length > 0;
        var chkBH = $('input[name="ctl00$cph_main_content$QC$chk_BuyingHouse"]:checked').length > 0;
        var chkBHF = $('input[name="ctl00$cph_main_content$QC$chk_BuyingHouseFactory"]:checked').length > 0;
        var chkBHIC = $('input[name="ctl00$cph_main_content$QC$chk_BuyingHouseIC"]:checked').length > 0;
        if (InspectionType == "4") {
            $(".HideOnline").attr("style", "display:none");
            $(".fullwidth").attr("style", "width:100%");
            $(".DMMHide").attr("style", "display:none");
            $(".SOHide").attr("style", "display:none");
            $(".HideSCQ").attr("style", "display:none");
            $(".BHHide").attr("style", "display:none");
            $(".BHFHide").attr("style", "display:none");
            if (chkCQD) {
                $('input[type="text"],.FabricCHK input[type="checkbox"], select,input[type="image"] ,input[type="radio"],input[type="file"], textarea[id*=ctl00_cph_main_content_QC_txtComments],textarea[id*=ctl00_cph_main_content_QC_txtCommentsBy_DMM]').attr("disabled", "disabled");
            }
            //$("#ctl00_cph_main_content_QC_lblUpload50Pcs").hide();
        }
        else if (InspectionType == "1" || InspectionType == "-10") {
            $(".SOHide").attr("style", "display:none");
            //$(".HideAQL").attr("style", "display:none");
            $(".fullwidth").attr("style", "width:56%");
            $(".HideFinalAudit").attr("style", "display:none");
            $(".BHFHide").attr("style", "display:none");
            if (chkCQD && chkDMM && rdoPass) {
                $('input[type="text"], select,input[type="image"] ,input[type="radio"],input[type="file"], textarea[id*=ctl00_cph_main_content_QC_txtComments],textarea[id*=ctl00_cph_main_content_QC_txtCommentsBy_DMM]').attr("disabled", "disabled");
            }
            if (chkCQD && chkDMM && rdoPass && !chkBH) {
                $('input[name="ctl00$cph_main_content$QC$chk_BuyingHouse"], input[name="ctl00$cph_main_content$QC$fldBuyingHouse"],input[name="ctl00$cph_main_content$QC$RBH"],input[name="ctl00$cph_main_content$QC$txtBHQC"]').attr("disabled", "");
            }
        }
        else if (InspectionType == "2") {
            $(".DMMHide").attr("style", "display:none");
            $(".SOHide").attr("style", "display:none");
            $(".fullwidth").attr("style", "width:56%");
            //  $(".HideAQL").attr("style", "display:none");
            $(".HideFinalAudit").attr("style", "display:none");
            $(".BHFHide").attr("style", "display:none");
            if (chkCQD && rdoPass) {
                $('input[type="text"], select,input[type="image"] ,input[type="radio"],input[type="file"], textarea[id*=ctl00_cph_main_content_QC_txtComments],textarea[id*=ctl00_cph_main_content_QC_txtCommentsBy_DMM]').attr("disabled", "disabled");
            }
            if (chkCQD && rdoPass && !chkBH) {
                $('input[name="ctl00$cph_main_content$QC$chk_BuyingHouse"], input[name="ctl00$cph_main_content$QC$fldBuyingHouse"],input[name="ctl00$cph_main_content$QC$RBH"],input[name="ctl00$cph_main_content$QC$txtBHQC"]').attr("disabled", "");
            }
            //$("#ctl00_cph_main_content_QC_lblUpload50Pcs").hide();
        }
        else if (InspectionType == "3") {
            $(".DMMHide").attr("style", "display:none");
            $(".HideSCQ").attr("style", "display:none");
            $(".BHHide").attr("style", "display:none");
            $(".fullwidth").attr("style", "width:56%");
            if (chkCQD && rdoPass) {
                $('input[type="text"], select,input[type="image"] ,input[type="radio"],input[type="file"], textarea[id*=ctl00_cph_main_content_QC_txtComments],textarea[id*=ctl00_cph_main_content_QC_txtCommentsBy_DMM]').attr("disabled", "disabled");
            }
            if (chkCQD && rdoPass && !chkBHF) {
                $('input[name="ctl00$cph_main_content$QC$fldBuyingHouseFactory"],input[name="ctl00$cph_main_content$QC$RBHF"],input[name="ctl00$cph_main_content$QC$txtBHFQC"]').attr("disabled", "");
            }
            if (chkCQD && rdoPass && !chkBHIC) {
                $('input[name="ctl00$cph_main_content$QC$fldBuyingHouseIC"]').attr("disabled", "");
            }
            //$("#ctl00_cph_main_content_QC_lblUpload50Pcs").hide();
        }

        if (jQuery.trim($('#ctl00_cph_main_content_QC_txtBHQC').val()).length == 0) {
            $('#ctl00_cph_main_content_QC_txtBHQC').attr("placeholder", "Enter BH QC Name");
        }
        var isdis = $('#ctl00_cph_main_content_QC_txtBHQC').is(':disabled');
        if (isdis) {
            $("#ctl00_cph_main_content_QC_txtBHQC").attr("placeholder", "");
        }

        if (jQuery.trim($('#ctl00_cph_main_content_QC_txtBHFQC').val()).length == 0) {
            $('#ctl00_cph_main_content_QC_txtBHFQC').attr("placeholder", "Enter BH QC Name");
        }
        var isdisF = $('#ctl00_cph_main_content_QC_txtBHFQC').is(':disabled');
        if (isdisF) {
            $("#ctl00_cph_main_content_QC_txtBHFQC").attr("placeholder", "");
        }


        SHowHideFile();
        SHowHideFileIE();
    }

    function SHowHideFile() {
        for (var Row = 1; Row <= $('#tableFaults1 tr').length - 1; Row++) {

            var RowId; if (Row <= 9) { RowId = '0' + Row; } else { RowId = Row; }
            var TFilePath = $('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_hdnFldresolution');
            var ViewFile = $('#ViewFile' + Row);
            var BrowseFile = $('#BrowseFile' + Row);
            if (TFilePath.val() != "") {
                $(BrowseFile).hide();
                $(ViewFile).show();
            }
            else {
                $(ViewFile).hide();
                $(BrowseFile).show();
            }
        }
    }

    function calcQtyChecked() {
        //  debugger;
        lblSize = $('.calc_size');
        var lblQty = $('.calc_qty');
        lblQtyChecked = $('.calc_qty_checked');
        var totalQty = $('.shipping-qty');
        var samplesChecked = $('.samples-chkd').val();
        if (samplesChecked == '')
            samplesChecked = 0;
        var sampleQty = $('.sample-qty');
        for (var i = 0; i < lblSize.length; i++) {
            if (isNaN(parseInt(samplesChecked)))
                samplesChecked = 0;

            if (parseInt(samplesChecked) > 0)
                lblQtyChecked[i].innerHTML = Math.round((lblQty[i].innerHTML) * ((parseInt(samplesChecked)) / (parseInt(totalQty.text()))));


            if (parseInt(samplesChecked) <= 0)
                if (!isNaN(sampleQty.text()) && parseInt(sampleQty.text()) > 0)
                    lblQtyChecked[i].innerHTML = Math.round((lblQty[i].innerHTML) * ((parseInt(sampleQty.text())) / (parseInt(totalQty.text()))));

        }

        //---------------Add-By-Prabhaker 07-Dec-17------------------------//
        //debugger;
        var MajorAllowedData = $('#ctl00_cph_main_content_QC_hdnMajorAllowed').val();
        var MinorAllowedData = $('#ctl00_cph_main_content_QC_hdnMinorAllowed').val();
        var MajorAct = $('.majorActualLabel').html();
        var MinorAct = $('.MinorActualLabel').html();
        if (parseInt(samplesChecked) > 0) {
            var Major = Math.round((MajorAllowedData * (parseInt(samplesChecked)) / (parseInt(sampleQty.text()))));
            var Minor = Math.round((MinorAllowedData * (parseInt(samplesChecked)) / (parseInt(sampleQty.text()))));
            if (Major > 0) {
                $('.lblMajor').html(Major);
                $('.lblMinor').html(Minor);
            }
            else {
                $('.lblMajor').html(1);
                $('.lblMinor').html(1);
            }
            if (MajorAct > 0 || MinorAct > 0) {
                FaultsSummary();
            }
        }

        if (parseInt(samplesChecked) <= 0) {
            $('.lblMajor').html(MajorAllowedData);
            $('.lblMinor').html(MinorAllowedData);

        }

        //------------------End Of Code----------------------------------//
    }

    function ChangeStatus(src) {
        // debugger;
        var InspectionType = '<%=this.InspectionID %>';
        lblStatus = $('#ctl00_cph_main_content_QC_lblStatus');
        var objHdnStatus = $('.hidden_status');

        if (src == 'Pass') {
            objHdnStatus.val("1");
            (lblStatus.text("PASS"));
            ($('.tdstatus').css('backgroundColor', '#01cc01'));
            if (InspectionType == 3) {
                $(".clstblQAFaults").show();
                document.getElementById("ctl00_cph_main_content_QC_chkCQD_QAManager").disabled = true;
                document.getElementById("ctl00_cph_main_content_QC_txtShippedQty").disabled = false;
                var Pending = $('#<%=lblPending.ClientID%>').html();
                if (Pending != '') {
                    if (Pending == 0) {
                        document.getElementById("ctl00_cph_main_content_QC_chkCQD_QAManager").disabled = false;
                    }
                }
            }
            else {
                document.getElementById("ctl00_cph_main_content_QC_chkCQD_QAManager").disabled = false;
            }
        }
        else if (src == 'Fail') {
            objHdnStatus.val("2");
            (lblStatus.text("FAIL"));
            ($('.tdstatus').css('backgroundColor', '#FF0000'));
            document.getElementById("ctl00_cph_main_content_QC_chkCQD_QAManager").disabled = false;
            document.getElementById("ctl00_cph_main_content_QC_txtShippedQty").disabled = true;
            $(".clstblQAFaults").hide();
        }
        else {
            objHdnStatus.val("0");
            (lblStatus.text(""));
            ($('.tdstatus').css('backgroundColor', '#ffffff'));

        }


    }
    function getStatus(isLoad) {
         debugger;
        //        alert(isLoad);
        var objCriticalActual;
        var objMajorActual;
        var objMinorActual;
        var criticalAllowed = 0;
        var majorAllowed = 0;
        var minorAllowed = 0;
        var lblStatus;

        majorAllowed = $('#<%=lblMajorAllowed.ClientID%>').html();

        criticalAllowed = $('#<%=lblCriticalAllowed.ClientID%>').html();
        minorAllowed = $('#<%=lblMinorAllowed.ClientID%>').html();

        objMajorActual = $('#<%=lblMajorActual.ClientID%>').html();
        objCriticalActual = $('#<%=lblCriticalActual.ClientID%>').html();
        objMinorActual = $('#<%=lblMinorActual.ClientID%>').html();

        objMajorActualC = $('#<%=lblMajorActual.ClientID%>');
        objCriticalActualC = $('#<%=lblCriticalActual.ClientID%>');
        objMinorActualC = $('#<%=lblMinorActual.ClientID%>');

        lblStatus = $('#<%=lblStatus.ClientID%>');
        var objHdnStatus = $('#<%=hiddenStatus.ClientID%>');
        var objhdnRadioStatus = $('.hidden_status');

        if (isLoad) {
            //FaultsSummary();
            if (objHdnStatus.val() != undefined && objHdnStatus.val() != null && objHdnStatus.val() != '') {
                //debugger;
                lblStatus.val(objHdnStatus.val());
                var radio_status = $('.radio_status');
               // alert(objHdnStatus.val());
                if (objHdnStatus.val() == "PASS") {
                    // alert(objHdnStatus.val());
                    objhdnRadioStatus.val("1");
                    if (radio_status.length > 0)
                        $('#ctl00_cph_main_content_QC_rbtnPass').attr('checked', 'checked');
                    //  radio_status[0].checked = true;
                    $('.status').html("PASS");
                    ($('.tdstatus').css('backgroundColor', '#01cc01'));
                    //alert("6");
                }
                else if (objHdnStatus.val() == "FAIL") {
                    objhdnRadioStatus.val("2");
                    if (radio_status.length > 0)
                    // radio_status[1].checked = true;
                      
                        $('#ctl00_cph_main_content_QC_rbtnFail').attr('checked', 'checked');
                    $('.status').html("FAIL");
                    ($('.tdstatus').css('backgroundColor', '#FF0000'));
                    // alert("7");
                    document.getElementById("ctl00_cph_main_content_QC_chkCQD_QAManager").disabled = false;
                    $(".clstblQAFaults").hide();
                }
                else {
                    objhdnRadioStatus.val("");
                    (lblStatus.val(""));
                    radio_status[0].checked = false;
                    radio_status[1].checked = false;
                    ($('.tdstatus').css('backgroundColor', '#ffffff'));
                }

            }
        }
        else {

            if (((parseInt(objMajorActual)) == 0) &&
                ((parseInt(objMinorActual)) == 0) &&
                ((parseInt(objCriticalActual)) == 0)
              ) {
                var radio_status = $('.radio_status');

                (lblStatus.val(""));
                radio_status[0].checked = false;
                radio_status[1].checked = false;
                ($('.tdstatus').css('backgroundColor', '#ffffff'));
            }
            else {
                var radio_status = $('.radio_status');
                radio_status[0].checked = false;
                radio_status[1].checked = false;
                if (isNaN(parseInt(objMajorActual)))
                    (objMajorActualC.val(0));
                if (isNaN(parseInt(objMinorActual)))
                    (objMinorActualC.val(0));
                if (isNaN(parseInt(objCriticalActual)))
                    (objCriticalActualC.val(0));

                if (isNaN(parseInt(majorAllowed)))
                    majorAllowed = 0;
                if (isNaN(parseInt(minorAllowed)))
                    minorAllowed = 0;
                if (isNaN(parseInt(criticalAllowed)))
                    criticalAllowed = 0;


                if ((parseInt(majorAllowed) > parseInt(objMajorActual)) &&
	                (parseInt(minorAllowed) > parseInt(objMinorActual)) &&
	                (parseInt(criticalAllowed) > parseInt(objCriticalActual))
                  ) {

                    (lblStatus.val("PASS"));
                    objhdnRadioStatus.val("1");
                    ($('.tdstatus').css('backgroundColor', '#01cc01'));
                }
                else if ((parseInt(majorAllowed) < parseInt(objMajorActual)) ||
	                (parseInt(minorAllowed) < parseInt(objMinorActual)) ||
	                (parseInt(criticalAllowed) < parseInt(objCriticalActual))
                  ) {

                    (lblStatus.val("FAIL"));
                    objhdnRadioStatus.val("2");
                    ($('.tdstatus').css('backgroundColor', '#FF0000'));
                }
                else {
                    (lblStatus.val(""));
                    objhdnRadioStatus.val("0");
                    radio_status[0].checked = false;
                    radio_status[1].checked = false;
                    ($('.tdstatus').css('backgroundColor', 'ffffff'));
                }
            }
        }
    }
    $(document).ready(function () {
        // chkMainLabel
        $('.chkMainLabel input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkMainLabetest = $(".chkMainLabel input:checked").length;
                if (parseInt(chkMainLabetest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        // chkSizeLabel
        $('.chkSizeLabel input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkSizeLabeltest = $(".chkSizeLabel input:checked").length;
                if (parseInt(chkSizeLabeltest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        //chkWashCare
        $('.chkWashCare input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkWashCaretest = $(".chkWashCare input:checked").length;
                if (parseInt(chkWashCaretest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        //chkPriceTicket
        $('.chkPriceTicket input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkPriceTickettest = $(".chkPriceTicket input:checked").length;
                if (parseInt(chkPriceTickettest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        // chkPolybagSticker
        $('.chkPolybagSticker input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkPolybagStickertest = $(".chkPolybagSticker input:checked").length;
                if (parseInt(chkPolybagStickertest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        //chkCartonQuality
        $('.chkCartonQuality input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkCartonQualitytest = $(".chkCartonQuality input:checked").length;
                if (parseInt(chkCartonQualitytest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        //chkCartonStickerstest
        $('.chkCartonStickers input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkCartonStickerstest = $(".chkCartonStickers input:checked").length;
                if (parseInt(chkCartonStickerstest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        //chkPolybagQuality
        $('.chkPolybagQuality input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkPolybagQualitytest = $(".chkPolybagQuality input:checked").length;
                if (parseInt(chkPolybagQualitytest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });

        // chkHangers
        $('.chkHangers input[type="checkbox"]').click(function (e) {
            if (this.checked) {
                var chkHangerstest = $(".chkHangers input:checked").length;
                if (parseInt(chkHangerstest) > 1) {
                    $(e.target).attr('checked', false);
                }
                else {
                    CheckMissingItem();
                }
            }
            else {
                CheckMissingItem();
            }
        });
    });

    function Validate() {
        //debugger;
        var InspectionType = '<%=this.InspectionID %>';
        //--------------------------------Edit-by-prabhaker------------------------//
        var x = $(window.parent).width();
        var y = $(window.parent).height();
        var a = x;
        var b = y;
        //$("#aspnetForm").css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css('overflow', 'hidden');
        $("body", window.parent.document).css('position', 'fixed');
        $("body", window.parent.document).css('top', '0px');
        //---------------------------------End-of code---------------------------------//       
        var listLineMan = document.getElementById('<%=listLineMan.ClientID %>');

        var LineManSelect = 0;

        for (var i = 0; i < listLineMan.length; i++) {

            if (listLineMan.options[i].selected) {
                LineManSelect = 1;
            }
        }
        if (LineManSelect == 0) {
            alert('Please select Lineman!');
            document.getElementById('<%=listLineMan.ClientID %>').focus();
            return false;
        }

        var listQcName = document.getElementById('<%=listQcName.ClientID %>');

        var QcSelect = 0;

        for (var i = 0; i < listQcName.length; i++) {

            if (listQcName.options[i].selected) {
                QcSelect = 1;
            }
        }
        if (QcSelect == 0) {
            alert('Please select QC!');
            document.getElementById('<%=listQcName.ClientID %>').focus();
            return false;
        }

        //debugger;
        var TotalOccurrence = 0;
        var OverallPcsStitched = $('#<%=hiddenOverallPcsStitched.ClientID %>').val();
        if (InspectionType == "3") {
            if (parseInt(OverallPcsStitched) <= 0) {
                alert('Total Stitched Qty cannot 0 or Empty!');
                return false;
            }
        }
        var ChkWithOutNature = $(".clsChkWithOutNature input:checked").length;
        if (parseInt(ChkWithOutNature) <= 0) {

            for (var Row = 1; Row <= $('#tableFaults1 tr').length - 1; Row++) {

                var RowId; if (Row <= 9) { RowId = '0' + Row; } else { RowId = Row; }
                var txtOccurrence = $('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_txtOccurrence');
                if (txtOccurrence.val() == "") {
                    txtOccurrence.val("0");
                }
                if ($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_txtNatureOfFaults').val() == '') {
                    ShowHideValidationBox(true, 'Please enter Nature of faults!');
                    return false;
                }

                if (($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_ddlNatureOfFaults').val() != -10) && (parseInt(txtOccurrence.val()) <= 0)) {
                    ShowHideValidationBox(true, 'Please enter the fault occurrence.', 'Quality Control Sheet');
                    return false;
                }
            }
        }
        // Process Radio check
        var grid = document.getElementById('<%= gvProcess.ClientID %>');
        var RadioStatusCheck = 0;
        var List = grid.getElementsByTagName("input");

        for (i = 0; i < List.length; i++) {
            //debugger;             
            if (List[i].type == "radio") {
                if (List[i].checked) {
                    //debugger;
                    RadioStatusCheck = parseInt(RadioStatusCheck) + 1;
                }
            }
        }
        if (parseInt(RadioStatusCheck) < 6) {
            ShowHideValidationBox(true, 'This is mandatory to select pass or fail from all the processes!');
            return false;
        }
        // End Process Radio

        var rdoPass = $('input[id$=rbtnPass]').attr('checked'); //$('input[name="radioStatus"][value="1"]').attr('checked');
        var rdoFail = $('input[id$=rbtnFail]').attr('checked'); //$('input[name="radioStatus"][value="2"]').attr('checked');          


        if (InspectionType != "4") {
            //debugger;
            if (!rdoPass && !rdoFail) {
                ShowHideValidationBox(true, 'Please check pass or fail status.', 'Quality Control Sheet');
                return false;
            }

            var chkMainLabel = $(".chkMainLabel input:checked").length > 0;
            if (!chkMainLabel) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Main Label.', 'Quality Control Sheet');
                return false;
            }
            var chkSizeLabel = $(".chkSizeLabel input:checked").length > 0;
            if (!chkSizeLabel) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Size Label.', 'Quality Control Sheet');
                return false;
            }
            var chkWashCare = $(".chkWashCare input:checked").length > 0;
            if (!chkWashCare) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from WashCare.', 'Quality Control Sheet');
                return false;
            }
            var chkPriceTicket = $(".chkPriceTicket input:checked").length > 0;
            if (!chkPriceTicket) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Price Ticket.', 'Quality Control Sheet');
                return false;
            }
            var chkPolybagSticker = $(".chkPolybagSticker input:checked").length > 0;
            if (!chkPolybagSticker) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Polybag Sticker.', 'Quality Control Sheet');
                return false;
            }
            var chkCartonQuality = $(".chkCartonQuality input:checked").length > 0;
            if (!chkCartonQuality) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Carton Quality.', 'Quality Control Sheet');
                return false;
            }
            var chkCartonStickers = $(".chkCartonStickers input:checked").length > 0;
            if (!chkCartonStickers) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Carton Stickers.', 'Quality Control Sheet');
                return false;
            }
            var chkPolybagQuality = $(".chkPolybagQuality input:checked").length > 0;
            if (!chkPolybagQuality) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Polybag Quality and Dimensions.', 'Quality Control Sheet');
                return false;
            }
            var chkHangers = $(".chkHangers input:checked").length > 0;
            if (!chkHangers) {
                ShowHideValidationBox(true, 'Please check at least one checkbox from Hangers.', 'Quality Control Sheet');
                return false;
            }

        }

        //------ Added By Ravi kumar on 2/1/2017 -----------------
        var chkAction = 0;
        var chkGMQA = $(".chkGMQA input:checked").length;
        if (parseInt(chkGMQA) > 0) {
            chkAction = 1
        }
        var chkCQD = $(".chkCQD input:checked").length;
        if (parseInt(chkCQD) > 0) {
            chkAction = 1
        }
        var chkFactManager = $(".chkFactManager input:checked").length;
        if (parseInt(chkFactManager) > 0) {
            chkAction = 1
        }
        var chkProdIncharge = $(".chkProdIncharge input:checked").length;
        if (parseInt(chkProdIncharge) > 0) {
            chkAction = 1
        }
        var chkQC = $(".chkQC input:checked").length;
        if (parseInt(chkQC) > 0) {
            chkAction = 1
        }
        var chkFinIncharge = $(".chkFinIncharge input:checked").length;
        if (parseInt(chkFinIncharge) > 0) {
            chkAction = 1
        }
        var chkFinSupervisor = $(".chkFinSupervisor input:checked").length;
        if (parseInt(chkFinSupervisor) > 0) {
            chkAction = 1
        }
        var chkLineMan = $(".chkLineMan input:checked").length;
        if (parseInt(chkLineMan) > 0) {
            chkAction = 1
        }
        var chkAsstLineMan = $(".chkAsstLineMan input:checked").length;
        if (parseInt(chkAsstLineMan) > 0) {
            chkAction = 1
        }
        var chkChecker = $(".chkChecker input:checked").length;
        if (parseInt(chkChecker) > 0) {
            chkAction = 1
        }
        var chkPressMan = $(".chkPressMan input:checked").length;
        if (parseInt(chkPressMan) > 0) {
            chkAction = 1
        }
        var chkOthers = $(".chkOthers input:checked").length;
        if (parseInt(chkOthers) > 0) {
            chkAction = 1
        }

        if (parseInt(chkAction) == 0) {
            ShowHideValidationBox(true, 'Please select at least one person present from Corrective Action Plan.', 'Quality Control Sheet');
            //alert('Please select at least one person present from Corrective Action Plan');
            return false;
        }

        //debugger;
        if (InFaultcount() == false) {
            return false;
        }


        //Add By Prabhaker on 31-aug-18
        var Productivityrowcount = $('#ctl00_cph_main_content_QC_lblProductivityrowcount').html();
        if (Productivityrowcount != "0") {
            if (InspectionType == "4") {
                var checkboxchecked = "1"
               // var len = 0;
                $(".checkRescan input").each(function () {
                        if ($(this).is(':checked')) {
                            checkboxchecked = "0";
                        }                   
                });

                if (checkboxchecked == "0") {
                    //debugger;
                    var isYes = confirm("Are You Sure That You Have Selected All The Concern Dates?");
                    if (isYes == false) {
                     return false;            
                    }
                }
                else {
                    alert("Please select atleast one Packing Date!");
                    return false;
                }
            }
            //End Of Code

        }
    }

    //--------------------------------Edit-by-prabhaker------------------------//
    $(this).find('.lblmsg1')
    {
        $("body", window.parent.document).css('overflow', 'scroll');
        $("body", window.parent.document).css('position', 'relative');
        //$("body", window.parent.document).css('bottom', '0px');
    }
    $(".ok").click(function () {
        $("body", window.parent.document).css('overflow', 'scroll');
        $("body", window.parent.document).css('position', 'relative');


    });


    //---------------------------------End-of code---------------------------------//



    function DDLChange(ddl) {
        if ((ddl.value) == 4) {
            $('#<%=txtOtherProcessingInstruction.ClientID %>').removeAttr('disabled');
        }
        else {
            $('#<%=txtOtherProcessingInstruction.ClientID %>').attr('disabled', 'disabled');
        }
    }

    function OnFaultChange(src) {
        //debugger;
        var ClassificationId = "";
        ClassificationId = src.id.replace("ddlNatureOfFaults", "");
        ClassificationId = ClassificationId + "lblClassification";

        var tdClassificationId = "";
        tdClassificationId = src.id.replace("ddlNatureOfFaults", "");
        tdClassificationId = tdClassificationId + "tdClassification";

        var NatureOfFaultValue = src.options[src.selectedIndex].value;
        NatureOfFaultValue = NatureOfFaultValue.substring(NatureOfFaultValue.indexOf("-") + 1);

        if (NatureOfFaultValue == 1) {
            $('#' + ClassificationId).text("Critical");
            $('#' + tdClassificationId).css('backgroundColor', '#ff3300');
        }
        else if (NatureOfFaultValue == 2) {
            $('#' + ClassificationId).text("Major");
            $('#' + tdClassificationId).css('backgroundColor', '#fd9903');
        }
        else if (NatureOfFaultValue == 3) {
            $('#' + ClassificationId).text("Minor");
            $('#' + tdClassificationId).css('backgroundColor', '#FFFF00');
        }
        else {
            $('#' + ClassificationId).text("");
            $('#' + tdClassificationId).css('backgroundColor', '#FFFFFF');
        }

        OnFaultCountChange();
    }

    function FaultsSummary(TotalCriticalOccurrence, TotalMajorOccurrence, TotalMinorOccurrence) {
        // debugger;
        $('#ctl00_cph_main_content_QC_lblCriticalActual').text(TotalCriticalOccurrence);
        $('#ctl00_cph_main_content_QC_lblMajorActual').text(TotalMajorOccurrence);
        $('#ctl00_cph_main_content_QC_lblMinorActual').text(TotalMinorOccurrence);

        if (TotalCriticalOccurrence != 0 || TotalMajorOccurrence != 0 || TotalMinorOccurrence != 0) {
            if (
            parseInt($('#ctl00_cph_main_content_QC_lblCriticalAllowed').text()) < parseInt($('#ctl00_cph_main_content_QC_lblCriticalActual').text())
            || parseInt($('#ctl00_cph_main_content_QC_lblMajorAllowed').text()) < parseInt($('#ctl00_cph_main_content_QC_lblMajorActual').text())
            || parseInt($('#ctl00_cph_main_content_QC_lblMinorAllowed').text()) < parseInt($('#ctl00_cph_main_content_QC_lblMinorActual').text())
            ) {
                //$('input[name="radioStatus"][value="2"]').attr('checked', true);
             
                $('input[id$=rbtnFail]').attr('checked', 'checked');
                $('#ctl00_cph_main_content_QC_lblStatus').text('FAIL');
                $('.tdstatus').css('backgroundColor', '#FF0000');
            }
            else {
                //$('input[name="radioStatus"][value="1"]').attr('checked', true);
                $('input[id$=rbtnPass]').attr('checked', 'checked');
                $('#ctl00_cph_main_content_QC_lblStatus').text('PASS');
                $('.tdstatus').css('backgroundColor', '#01cc01');
            }
        }
        else {
            //$('input[name="radioStatus"][value="1"]').attr('checked', false);
            // $('input[name="radioStatus"][value="2"]').attr('checked', false);
            $('input[id$=rbtnPass]').attr('checked', false);
          
            $('input[id$=rbtnFail]').attr('checked', false);
            $('#ctl00_cph_main_content_QC_lblStatus').text('');
            $('.tdstatus').css('backgroundColor', '#fff');
        }
        HideZero();
        SHowHideFile();
        SHowHideFileIE();
    }

    function ResultFail() {
        //$('input[name="radioStatus"][value="2"]').attr('checked', true);
       
        $('input[id$=rbtnFail]').attr('checked', 'checked');
        $('#ctl00_cph_main_content_QC_lblStatus').text('FAIL');
        $('.tdstatus').css('backgroundColor', '#FF0000');
    }

    function ResultPass() {
        //$('input[name="radioStatus"][value="1"]').attr('checked', true);
        $('input[id$=rbtnPass]').attr('checked', 'checked');
        $('#ctl00_cph_main_content_QC_lblStatus').text('PASS');
        $('.tdstatus').css('backgroundColor', '#01cc01');
    }

    function OnFaultCountChange(elem) {
        ChangeProcess(elem);
    }

    function OnFaultCountChangeReturn(elem) {
        //debugger;
        var Status = 0;
        if (numbersonly(elem) == true) {
            var TotalCriticalOccurrence = 0;
            var TotalMajorOccurrence = 0;
            var TotalMinorOccurrence = 0;
            var objhdnRadioStatus = $('.hidden_status');
            for (var Row = 1; Row <= $('#tableFaults1 tr').length - 1; Row++) {

                var RowId; if (Row <= 9) { RowId = '0' + Row; } else { RowId = Row; }
                if ($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_txtOccurrence').val() == "") {
                    $('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_txtOccurrence').val("0");
                }

                if ($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_lblClassification').text().trim() == "Critical") {
                    TotalCriticalOccurrence = TotalCriticalOccurrence + parseInt($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_txtOccurrence').val());
                }

                if ($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_lblClassification').text().trim() == "Major") {
                    TotalMajorOccurrence = TotalMajorOccurrence + parseInt($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_txtOccurrence').val());
                }

                if ($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_lblClassification').text().trim() == "Minor") {
                    TotalMinorOccurrence = TotalMinorOccurrence + parseInt($('#ctl00_cph_main_content_QC_rptFault_ctl' + RowId + '_txtOccurrence').val());
                }
            }
            $('#ctl00_cph_main_content_QC_lblCriticalActual').text(TotalCriticalOccurrence);
            $('#ctl00_cph_main_content_QC_lblMajorActual').text(TotalMajorOccurrence);
            $('#ctl00_cph_main_content_QC_lblMinorActual').text(TotalMinorOccurrence);

            if (TotalCriticalOccurrence != 0 || TotalMajorOccurrence != 0 || TotalMinorOccurrence != 0) {
                if (
            parseInt($('#ctl00_cph_main_content_QC_lblCriticalAllowed').text()) < parseInt($('#ctl00_cph_main_content_QC_lblCriticalActual').text())
            || parseInt($('#ctl00_cph_main_content_QC_lblMajorAllowed').text()) < parseInt($('#ctl00_cph_main_content_QC_lblMajorActual').text())
            || parseInt($('#ctl00_cph_main_content_QC_lblMinorAllowed').text()) < parseInt($('#ctl00_cph_main_content_QC_lblMinorActual').text())
            ) {
                    //                        $('input[id$=rbtnFail]').attr('checked', 'checked');
                    //                        $('#ctl00_cph_main_content_QC_lblStatus').text('FAIL');
                    //                        $('.tdstatus').css('backgroundColor', '#FF0000');
                    //                        objhdnRadioStatus.val("2");
                    //                        ChangeStatus('Fail')
                    Status = 2;
                }
                else {
                    //                        $('input[id$=rbtnPass]').attr('checked', 'checked');
                    //                        $('#ctl00_cph_main_content_QC_lblStatus').text('PASS');
                    //                        $('.tdstatus').css('backgroundColor', '#01cc01');
                    //                        objhdnRadioStatus.val("1");
                    //                        ChangeStatus('Pass')
                    Status = 1;
                }
            }
            else {
                //                    $('input[id$=rbtnFail]').attr('checked', false);
                //                    $('input[id$=rbtnPass]').attr('checked', false);
                //                    $('#ctl00_cph_main_content_QC_lblStatus').text('');
                //                    $('.tdstatus').css('backgroundColor', '#fff');
                //                    objhdnRadioStatus.val("0");
                Status = 0;
            }
            HideZero();
        }
        return Status;
    }

    function HideZero() {
        $(".HideZero td span").each(function () {

            var el = $(this);
            var value = parseInt(el.text());

            if (value == 0) {
                el.css("display", "none");
            }
            else {
                el.css("display", "block");
            }
        });
    }

    //Add By Prabhaker 27-feb-18

    $(document).ready(function () {
        // debugger;

        var filepath = $("#ctl00_cph_main_content_QC_hdnIMgPath").val();
        if (filepath != "") {
            var arr = filepath.split('.');
            var fullfilePath = "../../uploads/Quality/" + filepath;
            if (arr[1] == "pdf") {
                $(".firstimg").attr("src", "../../images/pdf.png");
            }
            else {
                $(".firstimg").attr("src", fullfilePath);
            }
            $(".firstImagePreview").attr("href", fullfilePath);
        }
        else {
            $(".firstImagePreview").hide();
        }

    });


    //End Of Code



</script>
<script type="text/javascript">
    var RptIndex;
    function ShowAddRemarks(index) {
        RptIndex = index - 1;
        var hdnFaultResolution = $('.hdnFaultResolution').eq(RptIndex)
        $('#<%=txtRemarks.ClientID%>').val(hdnFaultResolution.val());
        $('#divRemarks_background').show();
        $('#divRemarks').show();

        window.scrollTo(0, 0);
        var x = $(window.parent).width();
        var y = $(window.parent).height();
        var a = x;
        var b = y;

        $("body", window.parent.document).css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css('overflow', 'hidden');
        $("body", window.parent.document).css('position', 'fixed');
        $("body", window.parent.document).css('top', '0px');
    }

    function HideRemarks() {
        $('#divRemarks').hide();
        $('#divRemarks_background').hide();

        $("body", window.parent.document).css('overflow', 'scroll');
        $("body", window.parent.document).css('position', 'relative');
        $("body", window.parent.document).css('top', '0px');
    }

    function Cancel() {
        HideRemarks();
        //hdnActive.val('');
    }

    function SaveRemarks() {
        //debugger;
        var txtRemarks = $('#<%=txtRemarks.ClientID%>').val();
        $('.hdnFaultResolution').eq(RptIndex).val(txtRemarks);
        $('.lblFaultResolution').eq(RptIndex).text(txtRemarks);
        //var hdnFaultResolution = $('.hdnFaultResolution').eq(RptIndex).val();
        HideRemarks();
    }

    function UploadFile(index) {
        RptIndex = index - 1;
        var FileName = $('.hdnFldresolution').eq(RptIndex).val();
        var url = '../Merchandising/QCUpload.aspx?index=' + RptIndex + '&FileName=' + FileName;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 330, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        window.scrollTo(0, 0);
        var x = $(window.parent).width();
        var y = $(window.parent).height();
        var a = x;
        var b = y;
        // $("body", window.parent.document).css({ overflow: hidden });

        $("#sb-container").css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css('overflow', 'hidden');
        $("body", window.parent.document).css('position', 'fixed');
        $("body", window.parent.document).css('top', '0px');
    }
    //abhishek 6/1/2017====================================================//
    function UploadFile_IE() {
        RptIndex = 1;
        var FileName = $('.hdnFldresolutionIE').val();
        var url = '../Merchandising/QCUpload.aspx?index=' + RptIndex + '&FileName=' + FileName + '&Flag=' + 'IE';
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 330, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        window.scrollTo(0, 0);
        var x = $(window.parent).width();
        var y = $(window.parent).height();
        var a = x;
        var b = y;
        // $("body", window.parent.document).css({ overflow: hidden });

        $("#sb-container").css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css('overflow', 'hidden');
        $("body", window.parent.document).css('position', 'fixed');
        $("body", window.parent.document).css('top', '0px');
    }
    function SaveFileIE(index, FileName) {
        $('.hdnFldresolutionIE').val(FileName);
        SHowHideFileIE();
    }
    function SHowHideFileIE() {

        //debugger;

        var TFilePath = $('.hdnFldresolutionIE').val();
        //            var ViewFile = $('#ViewFile' + 1);
        //            var BrowseFile = $('#BrowseFile' + 1);
        ViewFile = $('.ViewFileIE');
        BrowseFile = $('.BrowseFileIE');
        if (TFilePath != "") {
            $(BrowseFile).hide();
            $(ViewFile).show();
        }
        else {
            $(ViewFile).hide();
            $(BrowseFile).show();
        }

    }
    //end by abhishek=====================================================//
    function SBClose() {
        $("body", window.parent.document).css('overflow', 'scroll');
        $("body", window.parent.document).css('position', 'relative');
        $("body", window.parent.document).css('top', '0px');

    }


    function SaveFile(index, FileName) {
        $('.hdnFldresolution').eq(index).val(FileName);
        //alert($('.hdnFldresolution').eq(index).val());
        SHowHideFile();
    }

    function PrintQualityControl(Url, height, width) {
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
                ShowHideValidationBox(true, 'Some error occured on the server, please try again later.', 'Quality Control Sheet');

            }
            else {

                window.open(result);

                $(".print").show();
            }

        });
        return false;
    }

    function openShipedPopu(OrderDetailsID, OrderID, Qty) {

        window.open("/Internal/OrderProcessing/MOShippedPopup.aspx?OrderDetailID=" + OrderDetailsID + "&OrderId=" + OrderID + "&Qty=" + Qty + "&Flag=" + "QCOpen", "popup_id", "directories=0,status=0,toolbars=no,menubar=no,location=no,scrollbars=no,resizable=0,width=1000,height=400");
        return false;


    }
    function showPopup(Type) {
        var url = '../../Admin/ClientsAQL/AQL_WithoutMasterPage.aspx?AQLNO=' + $('#<%=lblAql.ClientID%>').html();

        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 400, width: 1000, overflow: "hidden", modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
    }

    function ShowQCAllContracts() {
        //debugger;
        $('#divAllContracts_background').show();
        $('#divAllContracts').show();
        var hdnISCQDQA = $('#<%=hdnISCQDQA.ClientID %>').val();
        var CountNotdisabled = 0;
        $('#<%=hdnIsOpenAllContractsPopUp.ClientID %>').val("0");
        var CountNotdisabled = $("input[name$=chkContract]").not(':disabled').length;
        if (hdnISCQDQA == '1') {
            if (parseInt(CountNotdisabled) > 0) {
                $('#btnSaveAllContracts').show();
                $('#<%=lblallcontractsdone.ClientID %>').hide();
            }
            else {
                $('#btnSaveAllContracts').hide();
                $('#<%=lblallcontractsdone.ClientID %>').show();
            }
        }
        else {
            $('#btnSaveAllContracts').hide();
            $('#<%=lblallcontractsdone.ClientID %>').hide();
        }
        window.scrollTo(0, 0);
        var x = $(window.parent).width();
        var y = $(window.parent).height();
        var a = x;
        var b = y;

        $("body", window.parent.document).css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css('overflow', 'hidden');
        $("body", window.parent.document).css('position', 'fixed');
        $("body", window.parent.document).css('top', '0px');
    }
    function ShowRescan_Details() {
        //debugger;
        $('#divAllContracts_background_Rescan').show();
        $('#divAllContracts_Rescan').show();       
        window.scrollTo(0, 0);
        var x = $(window.parent).width();
        var y = $(window.parent).height();
        var a = x;
        var b = y;

        $("body", window.parent.document).css({ width: a + 'px', height: b + 'px' });
        $("body", window.parent.document).css('overflow', 'hidden');
        $("body", window.parent.document).css('position', 'fixed');
        $("body", window.parent.document).css('top', '0px');
    }
    function HideQCAllContracts() {
        $('#divAllContracts_background').hide();
        $('#divAllContracts').hide();

        $("body", window.parent.document).css('overflow', 'scroll');
        $("body", window.parent.document).css('position', 'relative');
        $("body", window.parent.document).css('top', '0px');
    }
    function HideQCAllContracts_Rescan() {
        $('#divAllContracts_background_Rescan').hide();
        $('#divAllContracts_Rescan').hide();

        $("body", window.parent.document).css('overflow', 'scroll');
        $("body", window.parent.document).css('position', 'relative');
        $("body", window.parent.document).css('top', '0px');
    }
    function SaveAllContractsData() {
        //debugger;
        var OrderDetailID = '0';
        var IsTaskDone = false;
        var InLineFromPopUp = '<%=this.InspectionID %>';
        if (parseInt(InLineFromPopUp) == 1)
            InLineFromPopUp = 1;
        else
            InLineFromPopUp = 10;
        $("input[name$=chkContract]").each(function () {
           // debugger;
            OrderDetailID = $(this).next($('input[name$=hdnODID]')).val();
            if (OrderDetailID !== undefined) {
                var RefOrderDetailID = '<%=this.OrderDetailID %>';
                var InspectionID = '<%=this.InspectionID %>';
                var Status = $('#<%=hdnRadioStatus.ClientID %>').val();
                var QualityControlId = $('#<%=hiddenQualityControlID.ClientID %>').val();
                IsTaskDone = $(this).is(':checked');
                if ($(this).is(':checked')) {
                    $.ajax({
                        type: "POST",
                        url: serviceUrl + "CreateQCContractsProxy",
                        data: "{OrderDetailID: '" + OrderDetailID + "', InspectionID:'" + InspectionID + "', IsTaskDone:'" + IsTaskDone + "', RefOrderDetailID:'" + RefOrderDetailID + "' , InLineFromPopUp:'" + InLineFromPopUp + "', Status:'" + Status + "', QualityControlId: '" + QualityControlId + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                       success: OnSuccessCall
                       // error: OnErrorCall
                    });
                    }
                    function OnSuccessCall(response) {
                    //ShowHideMessageBox(true, 'Quality Inspection saved successfully.', 'Quality Sheet - Close Quality Inspection Task', HideQCAllContracts)
                    $(".ContactSubmit").click();
                
                }
            }
        });
        alert("Data Saved Successfully.");
       // $(".ContactSubmit").click();
    }

    //Add BY Prabhaker On 31-aug-18
     function SaveAllContractsData_Rescan() {
       var IsDoOnline = false;
       var InspectionID = -1;
       //debugger; //active-tab
       OrderDetailID = $('#<%=hdnOrderDetailID.ClientID %>').val();
       var QualityControlId = $('#<%=hiddenQualityControlID.ClientID %>').val(); 
   
       $(".checkRescan input").each(function () {          
           if (OrderDetailID != undefined) {
             IsDoOnline = $(this).is(':checked');
               var RescanDate = $(this).closest('tr').find('td span.PackingDate').html();
//               if ($(this).is(':checked')) {
                  // debugger;
                   $.ajax({
                       type: "POST",
                       url: serviceUrl + "CreateQCContractsProxy_Rescan",
                       data: "{OrderDetailID: '" + OrderDetailID + "', RescanDate:'" + RescanDate + "', QualityControlId:'" + QualityControlId + "',  IsTaskDone:'" + IsDoOnline + "'}",
                       contentType: "application/json; charset=utf-8",
                       dataType: "json"
                      // success: OnSuccessCall
                   });
//               }
//               function OnSuccessCall(response) {
//                   ShowHideMessageBox(true, 'Data saved successfully.', 'Save Productivity Date', HideQCAllContracts_Rescan);
//               }  
           }          
       });
       alert("Data Saved Successfully.");
       $(".close-this").click();
     }
    //ENd Of code


    function ChangeShippedQty(obj) {
        //debugger;

        var grdQafaultClientId = $('#<%=grdQafault.ClientID%>');

        var ShippedQty = obj.value;
        var CutQty = $('#<%=txtcutqty.ClientID%>').val();
        if (CutQty == '')
            CutQty = 0;
        var ctsl = Math.round((parseFloat(CutQty) - parseFloat(ShippedQty)) / parseFloat(CutQty) * 100, 1);
        $('#<%=lblCtsl.ClientID%>').html(ctsl + ' %');
        var Pending = parseInt(CutQty) - parseInt(ShippedQty);
        $('#<%=lblPending.ClientID%>').html(Pending);

        if (Pending > 0) {
            $('#<%=lblPending.ClientID%>').css('color', 'red');
        }
        else {
            $('#<%=lblPending.ClientID%>').css('color', 'green');
        }
        if (CutQty <= ShippedQty) {
            grdQafaultClientId.attr("style", "display:none");
        }
        else {
            grdQafaultClientId.attr("style", "display:block");
        }
        $(".hdnShiped").click();

    }

    function CalculateCtsl(obj, type) {
        //debugger;
        var Qty = obj.value;
        if (isNumeric(Qty)) {
            if ((Qty != '') && (Qty != '0')) {
                var Ids = obj.id;
                var cId = Ids.split("_")[6].substr(3);

                var CutQty = $('#<%=txtcutqty.ClientID%>').val();
                var BP_CR = $('#<%=hdnBP_CR.ClientID%>').val();

                var ShipValue = ''
                if ((BP_CR != 0) && (BP_CR != '')) {
                    ShipValue = Math.round((parseFloat(Qty) * parseFloat(BP_CR)) / 1000, 0);
                    ShipValue = ShipValue + " k";
                }

                var ctsl = Math.round(parseFloat(Qty) / parseFloat(CutQty) * 100, 1);

                if (type == 'Empty') {
                    $("#<%= grdQafault.ClientID %> span[id$='" + cId + "_lblCtslEmpty']").html(ctsl + " %");
                    $("#<%= grdQafault.ClientID %> span[id$='" + cId + "_lblValueEmpty']").html(ShipValue);
                }
                if (type == 'Item') {
                    $("#<%= grdQafault.ClientID %> span[id$='" + cId + "_lblCtsl']").html(ctsl + " %");
                    $("#<%= grdQafault.ClientID %> span[id$='" + cId + "_lblValue']").html(ShipValue);
                    $(".clsbtnHdnQnty").click();
                }
                if (type == 'Footer') {
                    $("#<%= grdQafault.ClientID %> span[id$='" + cId + "_lblCtslFooter']").html(ctsl + " %");
                    $("#<%= grdQafault.ClientID %> span[id$='" + cId + "_lblValueFooter']").html(ShipValue);
                }
            }

            else {
                obj.value = '';
            }
        }
        else {
            obj.value = '';
        }
    }

    function ValidateFault(obj, type) {
        //debugger;
        var Qty = obj.value;
        var Ids = obj.id;
        var cId = Ids.split("_")[6].substr(3);
        var FaultName = '';
        var rowCount = $(".grdQafaultRow").length;
        var RowFaultName = '';

        if (type == 'Empty') {
            FaultName = $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtemptyfaultname']").val();
            if (FaultName == '') {
                alert('Nature of fault can not be Empty!');
                $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtemptyfaultname']").focus();
                return false;
            }
            var Qty = $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtemptyqnty']").val();
            if (Qty == '') {
                alert('Quantity can not be Empty!');
                $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtemptyqnty']").focus();
                return false;
            }

            for (var row = 1; row <= rowCount; row++) {
                //debugger;
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;
                RowFaultName = $("#<%= grdQafault.ClientID %> input[id$='" + gvId + "_txtFaultname']").val();

                if (RowFaultName == FaultName) {
                    alert('Nature of fault is duplicate!');
                    $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtemptyfaultname']").val('')
                    return false;
                }
            }
        }

        if (type == 'Footer') {
            FaultName = $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtfoterfaultname']").val();
            if (FaultName == '') {
                alert('Nature of fault can not be Empty!');
                $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtfoterfaultname']").focus();
                return false;
            }
            var Qty = $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtfoterqnty']").val();
            if (Qty == '') {
                alert('Quantity can not be Empty!');
                $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtfoterqnty']").focus();
                return false;
            }

            for (var row = 1; row <= rowCount; row++) {
                //debugger;
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;
                RowFaultName = $("#<%= grdQafault.ClientID %> input[id$='" + gvId + "_txtFaultname']").val();

                if (RowFaultName == FaultName) {
                    alert('Nature of fault is duplicate!');
                    $("#<%= grdQafault.ClientID %> input[id$='" + cId + "_txtfoterfaultname']").val('');
                    return false;
                }
            }
        }


    }

    function numbersonly(elem) {
        //debugger;

        var value = elem.value;
        if (value != "") {
            if (value == undefined) {
                var regs = /^\d*[0-9](\d*[0-9])?$/;
                if (value != "") {
                    if (regs.exec(elem)) {
                        return true;
                    }
                    else {
                        //
                        alert('Enter Only Numeric Value!')
                        elem.value = elem.defaultValue;
                        //elem.value = "";
                        return false;

                    }
                }
            }
            else {
                var regs = /^(-)?\d+(\d\d)?$/;
                if (value != "") {
                    if (regs.exec(value)) {
                        return true;
                    }
                    else {
                        alert('Enter Only Numeric Value!')
                        elem.value = elem.defaultValue;
                        //elem.value = "";
                        return false;

                    }
                }
            }
        }
        else {
            return true;

        }

    }

    function CheckWithOutNature(obj) {
        //debugger;
        var objhdnRadioStatus = $('.hidden_status');
        if (obj.checked) {
            $(".clsDivrptFault").hide();
            $('input[id$=rbtnPass]').attr('checked', 'checked');
            $('#ctl00_cph_main_content_QC_lblStatus').text('PASS');
            $('.tdstatus').css('backgroundColor', '#01cc01');
            objhdnRadioStatus.val("1");
            ChangeStatus('Pass')
            $('input[id$=rbtnPass]').attr('disabled', 'disabled');
            $('input[id$=rbtnFail]').attr('disabled', 'disabled');
        }
        else {
            $(".clsDivrptFault").show();
            
            $('input[id$=rbtnFail]').attr('checked', false);
            $('input[id$=rbtnPass]').attr('checked', false);
            $('#ctl00_cph_main_content_QC_lblStatus').text('');
            $('.tdstatus').css('backgroundColor', '#fff');
            objhdnRadioStatus.val("0");
            $('input[id$=rbtnPass]').attr('disabled', false);
            $('input[id$=rbtnFail]').attr('disabled', false);
        }
    }

    function ChangeProcess(elem) {
        debugger;       
        var grid = document.getElementById('<%= gvProcess.ClientID %>');
        var IsFail = 0;
        var List = grid.getElementsByTagName("input");
        for (i = 0; i < List.length; i++) {
            if (List[i].type == "radio" && List[i].value == "rbtnProcessFail") {
                if (List[i].checked) {
                    //debugger;
                    IsFail = 1;
                }
            }
        }
        var objhdnRadioStatus = $('.hidden_status');
        if (IsFail == 1) {
           
            $('input[id$=rbtnFail]').attr('checked', 'checked');
            $('#ctl00_cph_main_content_QC_lblStatus').text('FAIL');
            $('.tdstatus').css('backgroundColor', '#FF0000');
            objhdnRadioStatus.val("2");
            ChangeStatus('Fail')
        }
        else {
            var IsMissing = 0;
            IsMissing = CheckIsMissing();
            if (IsMissing == 1) {
           
                $('input[id$=rbtnFail]').attr('checked', 'checked');
                $('#ctl00_cph_main_content_QC_lblStatus').text('FAIL');
                $('.tdstatus').css('backgroundColor', '#FF0000');
                objhdnRadioStatus.val("2");
                ChangeStatus('Fail')
            }
            else {
                var ChkWithOutNature = $(".clsChkWithOutNature input:checked").length;
                if (parseInt(ChkWithOutNature) > 0) {
                    $(".clsDivrptFault").hide();
                    $('input[id$=rbtnPass]').attr('checked', 'checked');
                    $('#ctl00_cph_main_content_QC_lblStatus').text('PASS');
                    $('.tdstatus').css('backgroundColor', '#01cc01');
                    objhdnRadioStatus.val("1");
                    ChangeStatus('Pass')

                }
                else {
                    var Status = OnFaultCountChangeReturn(elem);
                    if (Status == 2) {
                        $('input[id$=rbtnFail]').attr('checked', 'checked');
                        $('#ctl00_cph_main_content_QC_lblStatus').text('FAIL');
                        $('.tdstatus').css('backgroundColor', '#FF0000');
                        objhdnRadioStatus.val("2");
                        ChangeStatus('Fail')
                    }
                    if (Status == 1) {
                        $('input[id$=rbtnPass]').attr('checked', 'checked');
                        $('#ctl00_cph_main_content_QC_lblStatus').text('PASS');
                        $('.tdstatus').css('backgroundColor', '#01cc01');
                        objhdnRadioStatus.val("1");
                        ChangeStatus('Pass')
                    }
                    if (Status == 0) {
                        $('input[id$=rbtnFail]').attr('checked', false);
                        $('input[id$=rbtnPass]').attr('checked', false);
                        $('#ctl00_cph_main_content_QC_lblStatus').text('');
                        $('.tdstatus').css('backgroundColor', '#fff');
                        objhdnRadioStatus.val("0");
                    }
                }
            }
        }

    }
    function CheckMissingItem() {
        var IsMissing = 0;
        var objhdnRadioStatus = $('.hidden_status');
        IsMissing = CheckIsMissing();
        if (IsMissing == 1) {
            $('input[id$=rbtnFail]').attr('checked', 'checked');
            $('#ctl00_cph_main_content_QC_lblStatus').text('FAIL');
            $('.tdstatus').css('backgroundColor', '#FF0000');
            objhdnRadioStatus.val("2");
            ChangeStatus('Fail')
        }
        else {
            ChangeProcess(1);
        }

    }

    function CheckIsMissing() {
        //debugger;
        var IsMissing = 0;
        var chkMainLabel = $('input[id$=chkMainLabel1]').attr('checked');
        if (chkMainLabel) {
            IsMissing = 1;
        }
        var chkSizeLabel = $('input[id$=chkSizeLabel1]').attr('checked');
        if (chkSizeLabel) {
            IsMissing = 1;
        }
        var chkWashCare = $('input[id$=chkWashCare1]').attr('checked');
        if (chkWashCare) {
            IsMissing = 1;
        }
        var chkPriceTicket = $('input[id$=chkPriceTicket1]').attr('checked');
        if (chkPriceTicket) {
            IsMissing = 1;
        }
        var chkPolybagSticker = $('input[id$=chkPolybagSticker1]').attr('checked');
        if (chkPolybagSticker) {
            IsMissing = 1;
        }
        var chkCartonStickers = $('input[id$=chkCartonStickers1]').attr('checked');
        if (chkCartonStickers) {
            IsMissing = 1;
        }
        var chkPolybagQuality = $('input[id$=chkPolybagQuality1]').attr('checked');
        if (chkPolybagQuality) {
            IsMissing = 1;
        }
        var chkHangers = $('input[id$=chkHangers1]').attr('checked');
        if (chkHangers) {
            IsMissing = 1;
        }
        return IsMissing;
    }

</script>

   <script type="text/javascript">
       $(document).ready(function () {
           $(".show").click(function () {
               $(".show").hide();
               $(".hide").show();
               $(".hidecontent").show();
           });
           $(".hide").click(function () {
               $(".hide").hide();
               $(".show").show();
               $(".hidecontent").hide();
           });

           $(".show1").click(function () {
               //debugger;
               $(".show1").hide();
               $(".hide1").show();
               $(".hidecontent1").show();
           });
           $(".hide1").click(function () {
               $(".hide1").hide();
               $(".show1").show();
               $(".hidecontent1").hide();
           });
           
       });
       function InFaultcount() {
           //debugger;
           var misscount = $('#ctl00_cph_main_content_QC_txtmissfaultcount').val();
           var faultoccurred = $('#ctl00_cph_main_content_QC_txtfalutoccu').val();

           if (misscount == "" || faultoccurred == "") {
               alert("Fill Missed Fault Detail!");
               return false;
           }

           

           if (misscount == "") {
               misscount = 0;

           }
           if (faultoccurred == "") {
               faultoccurred = 0;

           }  //commented by abhishek 
//           if (misscount == 0) {
//               alert("Fill missed fault count!");
//               return false;
//           }

//           if (faultoccurred == 0) {
//               alert("Fill total fault occurred!");
//               return false;
//           }
                      

           if (misscount != 0 && faultoccurred != 0) {
               if (parseInt(misscount) > parseInt(faultoccurred)) {
                   alert("Missed fault count cannot be greater than total fault occurred!");
                   $('#ctl00_cph_main_content_QC_txtmissfaultcount').val("");
                   return false;
               }
           }
           else {

               if (faultoccurred == 0 || misscount == 0) {
                   //                  $('#ctl00_cph_main_content_QC_txtmissfaultcount').val("");
                   //                  $('#ctl00_cph_main_content_QC_txtfalutoccu').val("");
                   return true;
               }
           }

       }
   </script>
 
 <script type="text/javascript" language="javascript">
     //-------------------edit by prabhaker------------------//  
     $(document).ready(function () {
         ShowImagePreview();
         HideZero();         
         
     });
     // Configuration of the x and y offsets
     function ShowImagePreview() {
         xOffset = 30;
         yOffset = 10;
         $("a.preview").hover(function (e) {
             this.t = this.title;
             this.title = "";
             var c = (this.t != "") ? "<br/>" + this.t : "";
             $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:150px !important; width:120px !important;'/>" + c + "</p>");
             $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX - yOffset) + "px")
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

     //-------------------end-of-code----------------------//

    </script>
 
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<div style="width: 100%;">
    <div class="form_heading">
     
     Quality Assurance Form &nbsp; (<asp:Label ID="lblInspectionName" runat="server"></asp:Label>) &nbsp; <asp:Label ID="lblTarget" runat="server" Visible="false" style="float:right; margin-right:20px"></asp:Label> 

    </div>
    
     <asp:Label ID="lblmsg1" CssClass="lblmsg1" Text ="Information saved successfully." runat="server" Visible="false" style="padding:5px; color:Green; text-align:center; font-weight:bold;"></asp:Label>

    <table cellpadding="0" cellspacing="0" border="0" style="margin-top:2px; margin-bottom:2px; width: 100%;" class="top">
        <tr>
            <td width="30%" style="vertical-align:top;padding-left: 1px;" rowspan="4">
                <p style="font-size: 10px; background-color:#dddfe4;border:1px solid #b7b4b4; color: #575759; text-align: center;
                    padding: 2px 10px; margin: 0px;">
                     Basic Information
                </p>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;color:Gray;"
                    class="top border-color">
                    <tr>
                        <th width="35%" style="display:none;">
                            Client
                        </th>
                        <td width="35%" style="display:none;">
                            <asp:Label ID="lblClient" runat="server"></asp:Label>
                        </td>
                          <th style="border-top:0px">
                            Serial No.
                        </th>
                        <td style="border-top:0px">
                            <asp:Label ID="lblIkandiSerial" runat="server" style="color:Black; font-weight:bold;"></asp:Label>
                        </td>
                        <td rowspan="5" align="center" style="width: 30%">
                            <asp:Image ID="imgSampleImageURL1" runat="server" style="border-width:0px;width: 60%;height: 84PX;" />
                        </td>
                    </tr>
                   
                    <tr>
                        <th>
                            Style No.
                        </th>
                        <td>
                            <asp:Label ID="lblStyleNumber" runat="server" style="color:Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Contract No.
                        </th>
                        <td>
                            <asp:Label ID="lblContractNumber" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Line Item No.
                        </th>
                        <td>
                            <asp:Label ID="lblLineItemNumber" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                           Order Qty.
                        </th>
                        <td>
                            <asp:Label ID="lblTotalQty" CssClass="shipping-qty" style="color:Black; font-weight:bold;" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <th>
                            Status
                        </th>
                        <td>
                            <asp:Label ID="lblStatus1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <th >
                            Stitching qty (%)
                        </th>
                        <td >
                            <asp:Label ID="lblStitch" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <th>
                            Finishing %
                        </th>
                        <td>
                            <asp:Label ID="lblPack" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Main Fabric
                        </th>
                        <td colspan="2">
                            <span>
                                <asp:Label ID="lblMainFabric" runat="server" style="color:Black"></asp:Label></span><br>
                            <asp:Label ID="lblccgsm" runat="server" style="color:Black; display:none;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Colour <div style="float:right;border-left: 1px solid #b7b4b4;padding: 0px 5px;"> Unit</div>
                        </th>
                        <td colspan="2">
                                <asp:Label ID="lblColour" runat="server" style="color:Black; font-weight:bold;"></asp:Label>
                                <div style="float:right;border-left: 1px solid #b7b4b4;padding: 0px 5px;">
                               <%--  <asp:Label ID="lblUnit" runat="server"></asp:Label>--%>
                               <asp:DropDownList ID="ddlUnitID" runat="server"></asp:DropDownList>
                                    <asp:HiddenField ID="hdnUnitId" Value="-1" runat="server" />
                                </div>
                        </td>
                    </tr>
                   
                     <tr>
                     <th>
                        <asp:Label ID="lblFactoryMgrName" runat="server"></asp:Label>
                     </th>
                     <td colspan="2">
                      <asp:Label ID="lblFactoryMgr" runat="server" style="vertical-align:top;"></asp:Label>
                     </td>
                   </tr>
                    <tr>
                        <th>
                        <asp:Label ID="lblChecker" runat="server"></asp:Label>                            
                        </th>
                        <td colspan="2" style="padding: 0px 0px;">
                       
                          <asp:ListBox ID="listLineMan" SelectionMode="Multiple" runat="server" Width="120px" Height="60px">
                            </asp:ListBox>  
                            <asp:ListBox ID="listQcName" SelectionMode="Multiple" runat="server" Width="120px" Height="60px">
                            </asp:ListBox>
                            
                        </td>
                    </tr>
                    
                </table>

                 <asp:UpdatePanel ID="UpdPnlchkWithNature" runat="server" UpdateMode="Conditional">
    <ContentTemplate>  
                <p style="font-size: 11px; color: #000;
                    text-align: left; margin: 10px 5px 0px; font-weight:bold;" class="presntcorr"> 
                   No Faults Present
                <asp:CheckBox runat="server" onclick="CheckWithOutNature(this)" CssClass="clsChkWithOutNature" ID="chkWithOutNature" /> &nbsp; &nbsp; &nbsp; &nbsp; 
                <asp:HyperLink ID="hypRescanDetails" runat="server" Visible="false" onclick="return ShowRescan_Details();" style="color:Blue; cursor:pointer;" ToolTip="Click to view all Rescan Contract">Select productivity date</asp:HyperLink> 
                  
  <%--<asp:Labe ///l runat="server" ID="lblUpload50Pcs">--%>
   &nbsp; 
   <%--Upload 1<sup>st</sup> 50pcs Report &nbsp; <asp:FileUpload runat="server" ID="file50PcsUpload" Width="90px" />--%>

  <%--<asp:HiddenField runat="server" ID="hdnIMgPath" />--%>
   <%--<label for="myFile"  onclick="$('.uploadfile').click();" runat="server" id="UploadfiftyReport" >Browse</label>   --%>
<%--   <asp:Repeater ID="file250PcsUpload" OnItemDataBound="file250PcsUpload_ItemDataBound" runat="server" runat="server">
                    <ItemTemplate>
                        
                                         <asp:HiddenField ID="hdnfile2" runat="server" Value='<%# (Eval("file50PcsUpload"))%>' />
                        <asp:HyperLink class="firstimg2" Height="30px" Style="vertical-align: middle" ID="imgfile"
                            Target="_blank" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("file50PcsUpload"))) %>' CssClass="imgupload preview"
                            NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("file50PcsUpload"))) %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
  <a href="" id="hrefimgfile50PcsUpload" style="display:none" runat="server" class="firstImagePreview"> <img  runat="server" ID="imgfile50PcsUpload" class="firstimg" style="height:25px; width:25px; vertical-align:middle;display:none;"/></a>
   </asp:Label>--%>
                </p>
                 </ContentTemplate>
  </asp:UpdatePanel>
   
            </td>
            <td width="2%" rowspan="4">
                &nbsp;
            </td>
            <td width="30%" valign="top">
                <div style="background-color:#dddfe4; color: #575759;border:1px solid #b7b4b4; padding: 2px 10px; margin-bottom:2px;">
                    <asp:HiddenField ID="hiddenQualityControlID" runat="server" />
                    <asp:HiddenField ID="hdnOrderId" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnOrderDetailID" runat="server" Value="0" />
                    <asp:HiddenField ID="hiddenStyleId" runat="server" />
                    <asp:HiddenField ID="hiddenOverallPcsStitched" runat="server" />

                    <asp:HiddenField ID="hdnstylenumber" runat="server" />
                    <asp:HiddenField ID="hdnClientID" runat="server" />
                    <asp:HiddenField ID="hdnDeptId" runat="server" />
                    <asp:HiddenField ID="hdnExFactory" runat="server" />
                   <asp:HiddenField ID="hdnIsOpenAllContractsPopUp" Value="0" runat="server" />
                   
                   <asp:HiddenField ID="hdnContractsCount" Value="0" runat="server" />
                   <asp:HiddenField ID="hdnISCQDQA" Value="0" runat="server" />
                   <asp:Label runat="server" id="lblProductivityrowcount" style="display:none;"></asp:Label>
                    
                    <div style="float: left; width: 50%;position:relative;left:-6px; color:gray;">
                        <a style="color:gray;" id="A1" target="inlineppm" href="/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=<%= hiddenStyleId.Value %>&stylenumber=<%= hdnstylenumber.Value %>&FitsStyle=<%= hdnstylenumber.Value %>&ClientID=<%= hdnClientID.Value %>&DeptId=<%= hdnDeptId.Value %>&showHOPPMFORM=Yes">
                            Click Here </a>To Hoppm Form

                           
                    </div>
                    <p style="font-size: 12px; float: left; width: 50%; font-weight: bold; text-align: left;
                        margin: 0px;">
                        <asp:Label ID="lblInspectionType" runat="server"></asp:Label>
                    </p>
                    <div style="clear: both;">
                    </div>
                </div>
                <table width="100%" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse;">
                    <tr>
                        <th>
                            PPM Remarks 

                             
    <img  src="../../App_Themes/ikandi/images/plus.gif" class="show" style="float:right;"  /> 
   
    <img src="../../App_Themes/ikandi/images/minus_icon.gif" class="hide" style="display:none;float:right;" /> 
                        </th>
                    </tr>
                    <tr class="hidecontent" style="display:none;">
                        <td>
                            <div style="padding: 10px; line-height: 20px; max-height: 220px; height: 220px; min-height: 220px;
                                overflow-y: scroll; vertical-align: top">
                                <asp:Label ID="lblPpmRemarks" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2%">
                &nbsp;
            </td>
            <td width="30%" valign="top">
                <div style="background-color:#dddfe4;border:1px solid #b7b4b4; color: #575759; padding: 2px 10px; margin-bottom:2px;">
                    <div style="float: left; width: 50%;position:relative;left:-6px; color:gray;">
                        <a style="color:gray;" id="A2" target="inlineppm" href="/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=<%= hiddenStyleId.Value %>&stylenumber=<%= hdnstylenumber.Value %>&FitsStyle=<%= hdnstylenumber.Value %>&ClientID=<%= hdnClientID.Value %>&DeptId=<%= hdnDeptId.Value %>&OrderId=<%= hdnOrderId.Value %>&showRiskFORM=Yes">
                            Click Here </a>To Risk Form
                    </div>
                    <p style="font-size: 12px; float: left; width: 50%; font-weight: bold; text-align: left;
                        margin: 0px;">
                        <asp:Label ID="lblInspectionType2" runat="server"></asp:Label></p>
                    <div style="clear: both;">
                    </div>
                </div>
                <table width="100%" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse;">
                    <tr>
                        <th>
                            Risk Remarks
                     <img  src="../../App_Themes/ikandi/images/plus.gif" class="show1" style="float:right;"  /> 
   
    <img src="../../App_Themes/ikandi/images/minus_icon.gif" class="hide1" style="display:none;float:right;" /> 
                        </th>
                    </tr>
                    <tr class="hidecontent1" style="display:none;">
                        <td>
                            <div style="padding: 10px; line-height: 20px; max-height: 220px; height: 220px; min-height: 220px;
                                overflow-y: scroll; vertical-align: top">
                                <asp:Label ID="lblReskRemarks" runat="server"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
        <td colspan="3" style="padding:0px;">
   <table cellpadding="0" cellspacing="0" border="0" align="center"
        class="top" width="100%" style="margin:2px 0px;">
        <tr>
            <td width="30%" valign="top">
                <p style="font-size: 10px; background-color:#dddfe4;border:1px solid #b7b4b4; color: #575759; text-align: center;
                    padding: 2px 10px; margin: 0px;" class="HideFinalAudit">
                    <asp:Label ID="lblInspectionName1" runat="server"></asp:Label>&nbsp;
                     Audit
                </p>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;"
                    class="top border-color">
                    <tr class="HideFinalAudit">
                        <th width="65%" style="border-top:0px;">
                            Date Conducted
                        </th>
                        <td width="35%" style="border-top:0px;">
                            <asp:Label ID="lblDateConducted" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <th width="65%">
                            Qty.
                        </th>
                        <td width="35%">
                            <asp:Label style="display:none;" ID="lblQtyFinal" runat="server" > </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th width="65%">
                            AQL Sample Qty.
                        </th>
                        <td width="35%">
                            <asp:Label ID="lblSampleQty" runat="server" CssClass="sample-qty"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th width="65%">
                            Actual Samples Checked
                        </th>
                        <td width="35%">
                            <asp:TextBox ID="txtActualSamplesChecked" runat="server" onchange="calcQtyChecked()" MaxLength ="4"
                                class="numeric-field-without-decimal-places samples-chkd" Style="border: 1px solid #fff;color:Blue !important;
                                width: 98%; text-align: left; font-weight:bold;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="HideFinalAudit">
                        <th width="65%">
                            QA
                        </th>
                        <td width="35%">
                            <asp:Label ID="lblQA" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2%">
                &nbsp;
            </td>
            <td width="62%" valign="top" >
                <p style="font-size: 10px; background-color:#dddfe4;border:1px solid #b7b4b4; color: #575759; padding: 2px 10px;
                    text-align: center; margin: 0px;" class="HideFinalAudit">
                    Quality Assurance To Perform Size Matrix
                </p>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse; color:Gray;"
                    class="mid border-color HideFinalAudit">
                    <tr>
                        <th style="width:110px;border-top:0px;">
                            Sizes
                        </th>
                        <asp:Repeater ID="repeaterSizes" runat="server" OnItemDataBound="repeaterSizesItemDataBound">
                            <ItemTemplate>
                                <td>
                                    <div>
                                        <label id="lblSize" class='calc_size'>
                                            <%# Eval("Size")%></label>
                                    </div>
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblEmptyCell" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tr>
                    <tr>
                        <th style="width:110px;">
                            Total Qty. in Stock
                        </th>
                        <asp:Repeater ID="repeaterQtyStock" runat="server" OnItemDataBound="repeaterQtyItemDataBound">
                            <ItemTemplate>
                                <td>
                                    <label id="lblQty" class='calc_qty'>
                                        <%# Eval("Quantity")%></label>
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblEmptyCell" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tr>
                    <tr>
                        <th style="width:110px;">
                            Quantity Checked
                        </th>
                        <asp:Repeater ID="repeaterQtyChecked" runat="server" OnItemDataBound="repeaterQtyCheckedItemDataBound">
                            <ItemTemplate>
                                <td>
                                    <label id="lblQtyChecked" class="calc_qty_checked" style="color:Black;">
                                    </label>
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblEmptyCell" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tr>
                </table>
              
                
            </td>
        </tr>
    </table>
        </td>
        </tr>
         <tr>
        <td colspan="3">
            <table width="100%" class="item_list HideOnline border-color" bordercolor="#000000" border="1" >
                    <tr>
                        <th colspan="2" align="center" style="padding-left:5px !important">
                            Processing Instructions
                        </th>
                    </tr>
                    <tr>
                        <td width="50%" style="padding: 3px !important;">
                            <asp:DropDownList ID="ddlProcessingInstructions" runat="server" style="padding: 2px 0px; color:Black" onchange="javascript: return DDLChange( this);">
                                <asp:ListItem Value="-1" Text="Select.." Selected="True"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Unpacked and Hang" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Steam Tunnel" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Hand Press" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Other" Selected="False"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="50%">
                            <div>
                                <asp:TextBox ID="txtOtherProcessingInstruction" runat="server"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
            </table>
        </td>
        </tr>
         <tr>
        <td colspan="3">
          <asp:UpdatePanel ID="UpdPnlAQL" runat="server" UpdateMode="Always">
                         <ContentTemplate>       
              <table cellpadding="0" cellspacing="0" border="1" align="center" style="border-collapse: collapse; position: relative;top:0px" width="100%" class=" item_list HideZero border-color"> <%--HideOnline--%>
                            <tbody>
                            <tr>
                              <th colspan="2" class="HideAQL" style="width:100px; text-align:center;">
                                    Faults Summary
                                </th>
                               <%-- <th class="HideSCQ" style="text-align:center; width:100px;">
                                    Sample Checked Qty.
                                </th>--%>
                              
                                <th style="width:50px; text-align:center;">
                                    Maj Allwd
                                </th>
                                <th style="width:50px; text-align:center;">
                                    Maj Act 
                                </th>
                                <th style="width:50px; text-align:center;"> 
                                    Min Allwd 
                                </th>
                                <th style="width:50px; text-align:center;">
                                    Min Act
                                </th>
                                <th style="width:50px; text-align:center;">
                                    Crit Allwd
                                </th>
                                <th style="width:50px; text-align:center;">
                                    Crit Act
                                </th>
                                <th colspan="2" style="width:135px; text-align:center;">
                                    Status
                                </th>
                            </tr>
                            <tr style="font-weight:bold;">
                                <th class="HideAQL"  style="background-color: #e0e0e0 !important; text-align:center; color: #39589c !important; border: 1px solid #b7b4b4; font-weight:bold; width:50px;">
                                   AQL
                                  
                                     <asp:Label ID="lblAql" Text="" runat="server"></asp:Label>    
                                     <asp:Label ID="lblLastAQL" Text="" runat="server"></asp:Label>    
                                </th>
                               
                                <th class="HideAQL"  style="background-color: #e0e0e0 !important;text-align:center; color: #39589c !important; border: 1px solid #b7b4b4; width:50px;">
                                  <img alt= "View Aql" src="../../App_Themes/ikandi/images/table.gif" id="Img3" align="center" onclick="showPopup(this);return false;" style="height:18px;cursor:pointer" />
                                </th>
                                
                              <%--   <td class="HideSCQ" style="text-align:center;">
                                    <asp:Label ID="lblSCQ" Text="" runat="server"></asp:Label>    
                                </td>--%>

                                <td style="font-size:12px; text-align:center;">
                           
                                    <asp:Label ID="lblMajorAllowed" Text="" runat="server" ForeColor="Gray" Font-Bold="false" CssClass="lblMajor"></asp:Label>  
                                   <asp:HiddenField runat="server" ID="hdnMajorAllowed" />
                                </td>
                                 <td style="font-size:12px; text-align:center;">
                                    <asp:Label  id="lblMajorActual" runat="server" CssClass="blue majorActualLabel"></asp:Label>    
                                </td>
                                <td style="font-size:12px; text-align:center;">
                              
                                    <asp:Label id="lblMinorAllowed" runat="server" ForeColor="Gray" Font-Bold="false" CssClass="lblMinor"></asp:Label> 
                                   <asp:HiddenField runat="server" ID="hdnMinorAllowed" />
                                </td>
                                <td style="font-size:12px; text-align:center;">
                                    <asp:Label id="lblMinorActual" runat="server" CssClass="blue MinorActualLabel" ></asp:Label>    
                                    
                                </td>
                                <td style="font-size:12px; text-align:center;">
                                    <asp:Label ID="lblCriticalAllowed" Text="0" runat="server" ForeColor="Gray" Font-Bold="false"></asp:Label>   
                                </td>
                                <td style="font-size:12px; text-align:center;">
                                    <asp:Label id="lblCriticalActual" runat="server" CssClass="blue"></asp:Label> 
                                </td>
                                 <td id="tdStatus" runat="server" class="tdstatus" style="width:55px;text-align:center">                                  
                                     <asp:Label ID="lblStatus" runat="server" ForeColor="black"  CssClass="status"></asp:Label>
                                     <asp:HiddenField ID="hiddenStatus" runat="server" />
                                </td>
                              <td style="text-align:left; width:80px;">     
                              <asp:RadioButton ID="rbtnPass" GroupName="A" onclick="ChangeStatus('Pass')" Text="Pass"  runat="server"></asp:RadioButton>                       
                              
                               <asp:RadioButton ID="rbtnFail" GroupName="A" onclick="ChangeStatus('Fail')" Text="Fail"  runat="server"></asp:RadioButton>   

                                  <div style="display:none;"> <input type="radio" onclick="ChangeStatus(this)" name="radioStatus" 
                                        value="1"  {#if '<%# Eval("Status")%>'=='Pass'} checked="checked" {#else} checked="checked"  {#/if} class="radio_status"  />Pass
                                    <br />
                                    <input type="radio" onclick="ChangeStatus(this)" name="radioStatus"
                                        value="2" {#if '<%# Eval("Status")%>'=='Fail'} checked="checked" {#else} checked="checked"  {#/if} class="radio_status" />Fail
                                        </div> 
                                     <input type="hidden" id="hdnRadioStatus" runat="server" class="hidden_status" value="0" />
                                       
                                </td>
                            </tr>
                         
                        </tbody></table>
                         </ContentTemplate>
  </asp:UpdatePanel>
        </td>
        </tr>
    </table>
    
    <div id="DivrptFault" runat="server" class="clsDivrptFault" >
  <asp:UpdatePanel ID="UpdPnlfaults" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:Repeater ID="rptFault" runat="server" OnItemDataBound="rptFault_ItemDataBound">
        <HeaderTemplate>
          <table border="1px black solid" id="tableFaults1" class="item_list border-color" style="width:99.8%;margin-left:1px;" width="99.5%">
            <tr>
               <th width="300px">Nature of Fault<input type="hidden" id="hdnHeader" value="-1" /></th>
              <th width="100px">Classification </th>
              <th width="50px">Pcs.</th>              
              <th width="50px">Upload</th>
              <th width="200px">Details</th>
              <th width="200px">Corrective Action Plan</th>
              <th width="10px">&nbsp;</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
      
          <tr>
           <td>
              <asp:HiddenField ID="hdnID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
              <div>
              <asp:TextBox ID="txtNatureOfFaults" style="text-align:left; padding-left:5px; font-size:10px; font-weight:bold; background:#fff;" CssClass="NatureOfFaults" Text='<%#DataBinder.Eval(Container.DataItem, "Fault")%>'  Width="97%" runat="server"></asp:TextBox>
              <input id="hdnNatureOfFaults" type="hidden" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "FaultValue")%>' class="clshdnNatureOfFaults" />
              </div>
              <div style="display:none;">
              <asp:DropDownList Width="300px" ID="ddlNatureOfFaults" runat="server" onchange="OnFaultChange(this)" CssClass="validtaeValue">
              </asp:DropDownList></div>
            </td>
            <td id="tdClassification" runat="server" style="background-color: white;">
              <asp:HiddenField ID="hdnClassificationId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "FaultType")%>' />
              <asp:Label ID="lblClassification" runat="server"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtOccurrence" runat="server" class="numeric-field-without-decimal-places" MaxLength="3" Font-Bold="true"
                onchange="OnFaultCountChange(this)" Text='<%#DataBinder.Eval(Container.DataItem, "Occurrence")%>'></asp:TextBox>
              <asp:HiddenField ID="hdnOccurrence" runat="server" Value="1" />
            </td>
            <td style="display:none;">
              <asp:DropDownList ID="ddlUser" runat="server">
              </asp:DropDownList>
            </td>
            <td style="text-align:center;">            
            
                  <a  style="cursor:pointer;" onclick='<%# "UploadFile(" + (Container.ItemIndex + 1).ToString() + ")" %>'  id ="ViewFile<%# Container.ItemIndex + 1 %>" title="CLICK TO VIEW FILE"> 
                      <img src="../../images/view-icon.png" /> </a>

                 <a style="cursor:pointer;" onclick='<%# "UploadFile(" + (Container.ItemIndex + 1).ToString() + ")" %>'  id ="BrowseFile<%# Container.ItemIndex + 1 %>" title="CLICK TO UPLOAD FILE">Browse </a>

              <input id="hdnFldresolution" type="hidden" runat="server" class="hdnFldresolution" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />
            </td>
            <td style="height:15px; font-size:11px;">
          <asp:TextBox ID="txtFaultDetails" Font-Size="11px"  Text ='<%#DataBinder.Eval(Container.DataItem, "FaultDetails")%>' TextMode="MultiLine" runat="server" style="height:25px;text-align:left !important;text-transform: initial; color:Black;"></asp:TextBox>
                
            </td>
            <td style="text-align:left; font-size:11px; height:15px;">            
                <asp:TextBox ID="txtCorrectiveActionPlan" Font-Size="11px" Text ='<%#DataBinder.Eval(Container.DataItem, "CorrectiveActionPlan")%>' TextMode="MultiLine" runat="server" style="height:22px; text-align:left !important;text-transform: initial; color:Black;"></asp:TextBox>
            </td>
            <td>
             <asp:ImageButton ID="imgBtndelete" runat="server" ToolTip="Delete Fault" ImageUrl="../../images/del-butt.png"
                CausesValidation="false" Style="text-align: right; float:right;" OnClick="imgBtndelete_Click" />
            </td>
          </tr>
         
        </ItemTemplate>
       <FooterTemplate>
       </table>
       </FooterTemplate>
      </asp:Repeater>
      <div style="height: 3px;">
      </div>
      <div align="right">
        <asp:ImageButton ID="imgBtnadd" runat="server" ImageUrl="~/App_Themes/ikandi/images/plus.gif" Width="10px" CausesValidation="false" OnClick="imgBtnadd_Click" ToolTip="Add more Fault"/>Add More &nbsp;
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  </div>
    
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
    <tr>
        <td width="56%" style="height: 185px;" valign="top" class="fullwidth">
            <asp:UpdatePanel ID="UpdPnlgvProcess" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:GridView ID="gvProcess" runat="server" AutoGenerateColumns="False" ShowHeader="true"
                        Width="100%" RowStyle-Font-Size="11px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                        rules="all" HeaderStyle-CssClass="Header" Style="border-collapse: collapse; border-bottom: 0px;"
                        class="border-color" OnRowDataBound="gvProcess_RowDataBound">
                        <RowStyle CssClass="gvProcessRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Process" ItemStyle-Width="355px">
                                <ItemTemplate>
                                    <asp:Label ID="lblProcess" runat="server" Style="width: 95%; text-align: left; color: #575555;"
                                        Text='<%#Eval("ProcessName")%>'></asp:Label>
                                    <asp:HiddenField ID="hdnProcessId" runat="server" Value='<%#Eval("ProcessId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" ItemStyle-Width="95px">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbtnProcessPass" onclick="ChangeProcess(1)" runat="server" Text="Pass"
                                        Style="color: black" GroupName="Process" />&nbsp;
                                    <asp:RadioButton ID="rbtnProcessFail" onclick="ChangeProcess(1)" runat="server" Text="Fail"
                                        GroupName="Process" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Corrective Action Plan">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtActionPlan" BorderStyle="None" Text='<%#Eval("ProcessActivePlan")%>'
                                        Style="width: 95%; text-align: left; color: Black;" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="mminline" runat="server">
            <table cellspacing="0"   rules="all" class="border-color" border="1" style="width:350px; margin-top:10px; border-collapse:collapse;border-collapse: collapse; border-bottom: 0px;">
            <tr >
            <th colspan="4"> Missed Fault detail</th>
            </tr>
            <tr>
            <td style="width:115px;">Missed fault count</td> <td style="width:60px; padding-right:5px;"><asp:TextBox ID="txtmissfaultcount" width="95%" runat="server" autocomplete="off"  class="numeric-field-without-decimal-places"></asp:TextBox></td>
            <td style="width:115px;">Total fault occurred </td> <td style="width:60px; padding-right:5px;"><asp:TextBox ID="txtfalutoccu" width="90%" style="margin:1px 0px"  runat="server" autocomplete="off"  class="numeric-field-without-decimal-places"></asp:TextBox></td>
            </tr>
            </table>
            <%--<asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="txtmissfaultcount" controltocompare="txtfalutoccu" operator="LessThan" type="Integer" errormessage="The first number should be smaller than the second number!" /><br />--%>
            </div>
        </td>
        
    <td width="1%" class="HideOnline"> 
    &nbsp;
    </td>
    <td width="47%" valign="top" class="HideOnline">
    
              <table width="100%" class="item_list FabricCHK border-color" bordercolor="#000000" border="1" style="margin-bottom:5px;" >
               <tbody>
                    <tr>
                 <th colspan="10">
                                       Check from Production File Submitted By the Merchandising Department and Confirm Below Correctness 
                                    </th>
                                </tr>
                                <tr>
                                    <th colspan="10">
                                        Item To Check
                                    </th>
                                </tr>
                                <tr>
                                    <td style="width:100px;">
                                        Item
                                    </td>
                                    <td style="width:50px;">
                                        Main Label
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </td>
                                    <td style="width:50px;">
                                        Size Label
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                    </td>
                                    <td style="width:50px;">
                                        Washcare
                                        <asp:HiddenField ID="HiddenField3" runat="server" />
                                    </td>
                                    <td style="width:50px;">
                                        Price Ticket
                                        <asp:HiddenField ID="HiddenField4" runat="server" />
                                    </td>
                                    <td style="width:50px;">
                                        Polybag Sticker
                                        <asp:HiddenField ID="HiddenField5" runat="server" />
                                    </td>
                                    <td style="width:70px;">
                                        Carton Qlty/ Dim. and No Exc. Pkg 
                                        <asp:HiddenField ID="HiddenField6" runat="server" />
                                    </td>
                                    <td style="width:50px;">
                                        Carton Stickers
                                        <asp:HiddenField ID="HiddenField7" runat="server" />
                                    </td>
                                    <td style="width:50px;">
                                        Polybag Qlty and Dim. 
                                        <asp:HiddenField ID="HiddenField8" runat="server" />
                                    </td>
                                    <td style="width:50px;">
                                        Hangers
                                        <asp:HiddenField ID="HiddenField9" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color:Gray;">
                                        Missing
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMainLabel1"  runat="server" CssClass="chkMainLabel"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSizeLabel1"  runat="server" CssClass="chkSizeLabel"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkWashCare1"  runat="server" CssClass="chkWashCare"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPriceTicket1"  runat="server" CssClass="chkPriceTicket"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagSticker1"  runat="server" CssClass="chkPolybagSticker"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonQuality1"  runat="server" CssClass="chkCartonQuality"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonStickers1"  runat="server" CssClass="chkCartonStickers"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagQuality1"  runat="server" CssClass="chkPolybagQuality"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkHangers1"  runat="server" CssClass="chkHangers"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color:Gray;">
                                        Not Required
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMainLabel2" runat="server" CssClass="chkMainLabel"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSizeLabel2" runat="server" CssClass="chkSizeLabel"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkWashCare2" runat="server" CssClass="chkWashCare"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPriceTicket2" runat="server" CssClass="chkPriceTicket"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagSticker2" runat="server" CssClass="chkPolybagSticker"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonQuality2" runat="server" CssClass="chkCartonQuality"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonStickers2" runat="server" CssClass="chkCartonStickers"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagQuality2" runat="server" CssClass="chkPolybagQuality"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkHangers2" runat="server" CssClass="chkHangers"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color:Gray;">
                                        Present
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkMainLabel3" runat="server" CssClass="chkMainLabel"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkSizeLabel3" runat="server" CssClass="chkSizeLabel"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkWashCare3" runat="server" CssClass="chkWashCare"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPriceTicket3" runat="server" CssClass="chkPriceTicket"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagSticker3" runat="server" CssClass="chkPolybagSticker"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonQuality3" runat="server" CssClass="chkCartonQuality"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCartonStickers3" runat="server" CssClass="chkCartonStickers"/>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkPolybagQuality3" runat="server" CssClass="chkPolybagQuality" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkHangers3" runat="server" CssClass="chkHangers"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10" style="font-size:10px; color:Gray;">
                                        Make Sure All The Barcodes And Numbers On Any Of The Items Cross Tally. Shipment
                                        Cannot Leave If Any Of The Side Items Are Faulty. If Any Items Are Non Applicable
                                        Delete Them.
                                    </td>
                                </tr>
                        
                            </tbody>
                        </table>

    </td>
    </tr>
    
    
    </table>
   
                


             <%-- <div class="form_box">--%>
        
       <%-- </div>--%>

              <table style="width:99.8%;margin-top:5px;border-color: #b6b1b1;margin-left:1px;" class="item_list checkMar" bordercolor="#000000" border="1">
                <tbody>
                    <tr>
                        <th  align="center" width="50%">
                            Overall Comments<span style="color:red">*</span>
                            <asp:HiddenField ID="HiddenField10" runat="server" Value="0" />
                        </th>
                     <th style="width:50%;">
                         <asp:Label ID="lblPenaltyDesc" runat="server" Text=""></asp:Label>               
                  
                        </th>
                    </tr>
                    <tr>
                        <td  align="center">
                            <asp:HiddenField ID="hdnComment" runat="server" Value="" />
                            <asp:Label ID="lblLastComment" runat="server" Font-Size="10px"></asp:Label>
                        </td>
                       <td rowspan="3" valign="top">
                               <asp:UpdatePanel ID="UpdPnlQafault" runat="server" UpdateMode="Always">
                         <ContentTemplate>
                           <table id="tblQAFaults" class="clstblQAFaults" style="display:none;" runat="server" width="98%" cellpadding="0" cellspacing="0" align="center">
                           <tbody><tr>
                              <td>
                              Cut Qty:  <asp:TextBox ID="txtcutqty" runat="server" Style="background-color: #F9F9FA; text-transform: capitalize;
                        background: none; border: 1px solid #d6d7d8; color: #000; margin-right: 5px; height:12px;"
                        Enabled="false" Width="60px"></asp:TextBox>
                              </td>
                               <td>
                              Shipped Qty:  <asp:TextBox ID="txtShippedQty" Font-Bold="true" onblur="ChangeShippedQty(this)" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" runat="server" MaxLength="7" Width="50px" Style="background-color: #F9F9FA; text-transform: capitalize;
                        background: none; border: 1px solid #d6d7d8; color: #000; margin-right: 5px;height:12px;" Height="16px"></asp:TextBox>
                                   <asp:Button ID="btnHdnShiped" CssClass="hdnShiped" style="display:none;"  runat="server" 
                                       Text="Button" onclick="btnHdnShiped_Click"/>
                              </td>
                               <td style="display:none;">                              
                                  <asp:Label ID="lblShipValue" runat="server" Text=""></asp:Label>                           
                              </td>

                              <td>
                              Ctsl:  &nbsp;
                                  <asp:Label ID="lblCtsl" runat="server" Text=""></asp:Label>
                                  <asp:HiddenField ID="hdnBP_CR" Value="0" runat="server"></asp:HiddenField>
                              </td>
                               <td>
                              Pending: 
                                  <asp:Label ID="lblPending" runat="server" Text=""></asp:Label>
                              </td>

                           </tr>
                           <tr>
                           <td colspan="4">
                      
                              
                           <asp:GridView ID="grdQafault" runat="server" AutoGenerateColumns="False"
                            ShowHeader="true" Width="98%" ShowFooter="True" OnRowDeleting="grdQafault_RowDeleting"
                            HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdQafault_RowCommand"
                            OnRowDataBound="grdQafault_RowDataBound" rules="all" HeaderStyle-CssClass="Header" style="border-collapse:collapse; border-bottom:0px;" class="border-color">                            
                             <RowStyle CssClass="grdQafaultRow" />
                            <Columns>                            
                                <asp:TemplateField HeaderText="Nature of fault">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFaultname"  style="width:95%; text-align:left;" CssClass="Faultname" ToolTip="Nature of fault"
                                            Text='<%#Eval("fault")%>' runat="server"></asp:TextBox>
                                        <asp:HiddenField ID="hdnfaultid" runat="server" Value='<%#Eval("ID")%>' />
                                        <asp:HiddenField ID="hdnAutoincretment" Value='<%# ((GridViewRow)Container).RowIndex + 1%>' runat="server" />
                    
                                    </ItemTemplate>
                
                                    <ItemStyle Width="50%" />
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtfoterfaultname" style="width:95%; text-align:left;" CssClass="Faultname" ToolTip="Nature of fault"
                                            runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hdnfaultid_footer" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnAutoincretmentfoter" Value='<%# ((GridViewRow)Container).RowIndex + 1%>'
                                            runat="server" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qnty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQnty" MaxLength="4" class="numeric-field-without-decimal-places" onblur="CalculateCtsl(this,'Item')" style="width:95%;" ToolTip="qty" Text='<%#Eval("UnshippedQty")%>' runat="server"></asp:TextBox>
                                        <asp:Button ID="btnHdnQnty" CssClass="clsbtnHdnQnty" style="display:none;"  runat="server" 
                                       Text="Button" onclick="btnHdnQnty_Click"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" />
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtfoterqnty" MaxLength="4" class="numeric-field-without-decimal-places" style="width:95%;" onblur="CalculateCtsl(this,'Footer')"  ToolTip="Email" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblValueFooter" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ctsl">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCtsl" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblCtslFooter" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div style="text-align: center;" class="iSlnkHide">
                                            <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" VerticalAlign="top" />
                                    <FooterTemplate>
                                        <div style="text-align: center;" class="iSlnkHide">
                                            <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" OnClientClick="javascript:return ValidateFault(this,'Footer')" style="width:50px;"
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                        </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table border="1" cellpadding="0" cellspacing="0" width="100%" style="border-collapse:collapse; border-bottom:0px;">
                                    <tr class="Header">
                                        <th width="50%">
                                            Nature of fault
                                        </th>
                                        <th width="13%">
                                            Qnty
                                        </th>
                                        <th width="13%">
                                            Value
                                        </th>
                                        <th width="13%">
                                            Ctsl
                                        </th>
                                        <th width="10%">
                                        Action
                                        </th>
                                    </tr>
                                    <tr style="text-align: center;">
                                        <td style="width:50%;">
                                            <asp:TextBox ID="txtemptyfaultname" style="width:95%; text-align:left;"  CssClass="Faultname" ToolTip="Nature of fault"
                                                runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnfaultid_Empty" runat="server" Value="0" />
                                        </td>
                                        <td style="width:13%;">
                                            <asp:TextBox ID="txtemptyqnty" MaxLength="4" style="width:95%;" onblur="CalculateCtsl(this,'Empty')" ToolTip="Qty" class="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="width:13%;">
                                            <asp:Label ID="lblValueEmpty" style="width:95%;" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="width:13%;">
                                            <asp:Label ID="lblCtslEmpty" style="width:95%;" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="10%">
                                            <asp:LinkButton ForeColor="black" style="width:95%;" ToolTip="Insert New Record" ID="addbutton" OnClientClick="javascript:return ValidateFault(this,'Empty')" runat="server"
                                                CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" />  </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                           
                        </asp:GridView>
                     
                           </td>
                           </tr>
                             <tr>
                           <td colspan="5">
                             <table id="tblTotal" runat="server" style="display:none;" border="1" cellpadding="0" cellspacing="0" width="98%" class="border-color">                                    
                                    <tr style="text-align: center;">
                                        <td align="center" style="width:50%;">
                                         <b> Total</b>
                                        </td>
                                        <td style="width:13%;">
                                            <b><asp:Label ID="lblFooterTotalQty" style="width:95%;" runat="server" Text="0"></asp:Label></b>
                                        </td>
                                        <td style="width:13%;">
                                           <b><asp:Label ID="lblFooterTotalValue" style="width:95%;" runat="server" Text=""></asp:Label></b>
                                        </td>
                                        <td style="width:13%;">
                                            
                                        </td>
                                        <td width="10%">
                                            
                                        </td>
                                    </tr>
                                </table>

                           </td>
                           </tr>
                           </tbody></table>
                              </ContentTemplate>
                         </asp:UpdatePanel>
                        </td>

                    </tr>
                    <tr>
                        <td >
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="15px"
                                Width="100%"></asp:TextBox>
                        </td>
                        <td class="DMMHide" style="display:none;">  <asp:TextBox ID="txtCommentsBy_DMM" runat="server" TextMode="MultiLine" Height="100px"
                                Width="100%"></asp:TextBox>
                                </td>
                    </tr>
                    <tr>
                    <td style="text-align:left; color:Gray;" class="presntcorr">
                    <div style="background:#98A9FA; color:White; text-align:center;"> People present for corrective action  </div>
                  <asp:CheckBox Text="GMQA" CssClass="chkGMQA" style="padding-left:3px;" runat="server" ID="chkGMQA" TextAlign="Left"  /> 
                   &nbsp; <asp:CheckBox Text="CQD" CssClass="chkCQD" runat="server" ID="chkCQD" TextAlign="Left" />
                   &nbsp; <asp:CheckBox Text="Fac. Mgr." CssClass="chkFactManager" runat="server" ID="chkFactoryManager" TextAlign="Left"/>
                   &nbsp; <asp:CheckBox Text="Prod. Inc." CssClass="chkProdIncharge" runat="server" ID="chkProdIncharge" TextAlign="Left" />
                   &nbsp; <asp:CheckBox Text="QC" runat="server" CssClass="chkQC" ID="chkQC" TextAlign="Left" />
                   &nbsp; <asp:CheckBox Text="Fin. Inc." CssClass="chkFinIncharge" runat="server" ID="chkFinishIncharge" TextAlign="Left"/>                   
                
                   &nbsp; <asp:CheckBox Text="Fin. Sup." CssClass="chkFinSupervisor" runat="server" ID="chkFinishSuperwisor" TextAlign="Left"/>
                   &nbsp; <asp:CheckBox Text="L. M." CssClass="chkLineMan" runat="server" ID="ckhLineMan" TextAlign="Left"/>
                    &nbsp; <asp:CheckBox Text="Ass. L. M." CssClass="chkAsstLineMan" runat="server" ID="chkAsstLineMan" TextAlign="Left"/>
                     &nbsp; <asp:CheckBox Text="Chkr" CssClass="chkChecker" runat="server" ID="chkChecker" TextAlign="Left"/>
                      &nbsp; <asp:CheckBox Text="Prs Man" CssClass="chkPressMan" runat="server" ID="chkPressMan" TextAlign="Left"/>
                      &nbsp; <asp:CheckBox Text="Others" CssClass="chkOthers" runat="server" ID="chkOthers" TextAlign="Left"/>
                      <br />

                        
                            <asp:TextBox ID="txtAdditional" runat="server" TextMode="MultiLine" Height="20px" style="border-top:1px solid #d2caca; text-align:left !important; text-transform:initial;"
                                Width="99.5%"></asp:TextBox>
                        
                    </td>
                    </tr>
                   
                </tbody>
            </table>
           
              <table class="border-color" border="1"  width="99.8%" style="margin-top:3px;margin-left:1px; border-collapse:collapse; table-layout: fixed;" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                    
                        <th width="120px">
                            CQD/QA Manager 
                            <asp:Label ID="lblusernameText" runat="server"></asp:Label>
                            </th>
                        <td style="border-top-color:#999 !important">
                            <asp:UpdatePanel ID="UpdPnlCQD_QAManager" runat="server" UpdateMode="Always">
                         <ContentTemplate>
                            <asp:CheckBox ID="chkCQD_QAManager" class="chkQAManager" runat="server" />
                             (<asp:Label ID="lblCQD_QAManagerDate" runat="server" CssClass="date_style"></asp:Label>
                             <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>) &nbsp;&nbsp;
                            <asp:HyperLink ID="hplContractList" runat="server" onclick="return ShowQCAllContracts();" style="color:Blue; cursor:pointer;" ToolTip="Click to view all Contracts">Contracts List</asp:HyperLink> &nbsp; &nbsp; &nbsp; &nbsp;
                          <%--  <a href="javascript:void(0)" runat="server" id="lnkopenShipedPopoup"  title="Open shiped qnty popup" visible="false" style="text-decoration:none;"> --%>
                            <asp:label ID="lblpenalty" runat="server" Visible="false" ></asp:label> 
                            </a>
                               </ContentTemplate>
                         </asp:UpdatePanel>
                        </td>
                       
                        <th width="120px" class="BHHide">
                            Buying House  </th>
                        <td class="BHHide">

                              <asp:CheckBox ID="chk_BuyingHouse" class="chkQAManager" runat="server" />
                             (<asp:Label ID="lblBuyingHouseDate"  runat="server" CssClass="date_style"></asp:Label>) &nbsp;
                            <asp:FileUpload ID="fldBuyingHouse" runat="server" Width="150px"/>&nbsp;
                            <asp:HyperLink ID="hplBuyingHouse" Target="_blank"  runat="server" Width="25px" CssClass="imgupload preview" Visible="false"></asp:HyperLink>&nbsp;
                            <asp:RadioButton ID="RBBHPass" runat="server" Text="Pass" GroupName="RBH"/>&nbsp;
                            <asp:RadioButton ID="RBBHFail" runat="server" Text="Fail" GroupName="RBH" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:TextBox ID="txtBHQC" runat="server" MaxLength="50"  CssClass="plh"></asp:TextBox>
                        </td>

                        <th width="120px" class="BHFHide">
                            Buying House Factory  </th>
                        <td class="BHFHide">

                            <asp:CheckBox ID="chk_BuyingHouseFactory" class="chkQAManager" runat="server" />
                             (<asp:Label ID="lblBuyingHouseFactoryDate" runat="server" CssClass="date_style"></asp:Label>) &nbsp;&nbsp;
                              <asp:FileUpload ID="fldBuyingHouseFactory" runat="server" Width="150px"/> &nbsp;&nbsp;
                              <asp:HyperLink ID="hplBuyingHouseFactory" Target="_blank"  runat="server" Width="25px" CssClass="imgupload preview" Visible="false"></asp:HyperLink>
                             <asp:RadioButton ID="RBBHFPass" runat="server" Text="Pass" GroupName="RBHF"/>&nbsp;
                            <asp:RadioButton ID="RBBHFFail" runat="server" Text="Fail" GroupName="RBHF" />&nbsp;&nbsp;
                           <asp:TextBox ID="txtBHFQC" runat="server" MaxLength="50" Width="130px"  CssClass="plh"></asp:TextBox>
                        </td>

                        <th width="120px" class="BHFHide">
                            Buying House IC </th>
                        <td class="BHFHide">

                            <asp:CheckBox ID="chk_BuyingHouseIC" class="chkQAManager" runat="server" />
                             (<asp:Label ID="lblBuyingHouseICDate" runat="server" CssClass="date_style"></asp:Label>) &nbsp;&nbsp;
                              <asp:FileUpload ID="fldBuyingHouseIC" runat="server" Width="150px" Visible="false"/>  &nbsp;&nbsp;
                              <asp:HyperLink ID="hplBuyingHouseIC" Target="_blank"  runat="server" Width="25px" CssClass="imgupload preview" Visible="false"></asp:HyperLink>
                              <%--abhishek 6/1/2016--%>
                        
                            <a style="cursor: pointer;" onclick="UploadFile_IE();"
                                id="ViewFile1" class="ViewFileIE" title="CLICK TO VIEW FILE">
                                <img src="../../images/view-icon.png" />
                            </a><a style="cursor: pointer; color:Blue;" class="BrowseFileIE" onclick="UploadFile_IE();"
                                id="BrowseFile1"  title="CLICK TO UPLOAD FILE">Browse
                            </a>
                            <input id="hdnFldresolutionIE" type="hidden" runat="server" class="hdnFldresolutionIE" />
                                <%--value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>'--%> 
                               
                        
                        <%--end--%>
                        </td>
                        
                        <th width="120px" class="SOHide" style="display:none">
                           Shipping Officer</th>
                        <td class="SOHide" style="display:none">

                            <asp:CheckBox ID="chk_ShippingOfficer" runat="server" />
                             (<asp:Label ID="lblShippingOfficerDate" runat="server" CssClass="date_style"></asp:Label>)
                        </td>

                       <th style="width:9%; display:none;" class="DMMHide">
                           DMM</th>
                        <td class="DMMHide" style="width:32%; display:none;">

                            <asp:CheckBox ID="chk_DMM" runat="server" />
                             (<asp:Label ID="lblDMMDate" runat="server" CssClass="date_style"></asp:Label>)
                             (I have checked report for Visuals,Major flaws and Packaging)
                        </td>

                    </tr>
                   
                </tbody>
            </table>
          
             <div style="height:7px;"></div>
<div>

<div style="float: left;position: relative;left: -13px;">
<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="submit" OnClientClick="javascript: return Validate();" />
<asp:Button ID="btnBuyingHouse" runat="server"  CssClass="submit" Text="Submit" onclick="btnBuyingHouse_Click" Visible="false"/>
    &nbsp; &nbsp;
    <input type="button" id="btnPrint" class="print da_submit_button" value="Print" onclick="return PrintQualityControl('','',1960);" />








</div>
<div style="float:left; margin-left:0px; margin-top:3px;">
    <asp:Label runat="server" ID="lbllineplanPending" Visible="false" style="padding:5px; color:Red; font-weight:bold; font-size:12px; font-family:Verdana;"> Line Planning is Pending</asp:Label>


<asp:Label Visible="false" ID="lblmsg" runat="server" Text="Inspection type is done and locked. You may add another instance using (+) Button." style=" border: 1px solid #a8a1a1;padding: 2px 5px;color: Red;font-weight: bold;"></asp:Label> 
</div>
<div style="clear:both"></div>

</div>
  
</div>

    <div class="style_number_box_background" id="divRemarks_background">
    </div>
    <div class="style_number_box" id="divRemarks">
    <div>
     Remarks
    </div>
        <table width="100%" cellpadding="6px" class="mid">               
            <tr>
                <td class="b" valign="top" style="width:20%;">
                    Enter Remarks:
                </td>
                <td >
                  <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="70px"
                                Width="95%"></asp:TextBox>   
                </td>
            </tr>
           
            <tr>
                <td colspan="2" align="center">
                    <input type="button" class="save da_submit_button" value="Save"  onclick="javascript: return SaveRemarks();"/>
                    <input type="button" class="cancel da_submit_button" value="Cancel" onclick="javascript: return Cancel();"/>
                </td>
            </tr>
        </table>
    </div>


    <div class="style_number_box_background" id="divComments_background">
    </div>
    <div class="style_number_box" id="divComments">
    <div>
     OVERALL COMMENTS
    </div>
        <table width="100%" cellpadding="6px" class="mid">    
            <tr>
                <%--<td class="b" width="23%" valign="top">
                    Comment History :
                </td>--%>
                 <td >
                     <asp:Label ID="lblOverralComments" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td  align="right">
                    <input type="button" class="cancel da_submit_button" value="Cancel" onclick="javascript: return CancelComments();"/>
                </td>
            </tr>
        </table>
    </div>

    <div class="style_number_box_background" id="divAllContracts_background">
    </div>
    <div class="style_number_box  style_number_box_Contract" id="divAllContracts">
        <div style="font-weight:500;">
           All other applicable contracts need to be done
        </div>
     <div style="max-height:500px; overflow:auto;background: #fff;">
        <table width="100%"  cellpadding="0" cellpadding="0" class="mid">    
            <tr>
                
                   
                <td  valign="top" style="width:95%;padding:0px 0px;" class="remove-div">
                <asp:GridView ID="grdAllContracts" CssClass="AddClass_Table" cellpadding="0" runat="server" OnRowDataBound="grdAllContracts_RowDataBound"  AutoGenerateColumns="false" Width="100%">
              
      <Columns>
         
          <asp:TemplateField HeaderText="Serial No." HeaderStyle-Width="70px">
            <ItemTemplate>
             <%#Eval("SerialNumber")%>
            </ItemTemplate>           
          </asp:TemplateField> 
           <asp:TemplateField HeaderText="Contract No." HeaderStyle-Width="130px">
            <ItemTemplate>
             <%#Eval("ContractNumber")%>
            </ItemTemplate>           
          </asp:TemplateField>   
           <asp:TemplateField HeaderText="Line No." HeaderStyle-Width="100px">
            <ItemTemplate>
             <%#Eval("LineItemNumber")%>               
            </ItemTemplate>           
          </asp:TemplateField>    
           <asp:TemplateField HeaderText="Colour" HeaderStyle-Width="100px">
            <ItemTemplate>
             <%#Eval("Fabric1Details")%>               
            </ItemTemplate>           
          </asp:TemplateField>    
           <asp:TemplateField HeaderText="Fabrics" HeaderStyle-Width="250px">
            <ItemTemplate>
             <%#Eval("Fabric1")%>               
            </ItemTemplate>           
          </asp:TemplateField>    
           <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="70px">
            <ItemTemplate>
             <%#Eval("Quantity")%>               
            </ItemTemplate>           
          </asp:TemplateField>    

           <asp:TemplateField HeaderText="Unit" HeaderStyle-Width="50px">
            <ItemTemplate>
             <%#Eval("UnitName")%>               
            </ItemTemplate>           
          </asp:TemplateField>   

           <asp:TemplateField HeaderText="Select" HeaderStyle-Width="20">
            <ItemTemplate>
                <asp:CheckBox  ID="chkContract" runat="server"  Checked='<%#Eval("IsTaskNeedToDone")%>'/>
                <asp:HiddenField ID="hdnODID" runat="server" value='<%#Eval("OrderdetailID")%>'/>
                <asp:HiddenField ID="hdnLatestStatus" runat="server" value='<%#Eval("LatestStatus")%>'/>  
                <asp:HiddenField ID="hdnTaskDone" runat="server" value='<%#Eval("IsTaskDone")%>'/>            
            </ItemTemplate>           
          </asp:TemplateField>         
         </Columns>         
         </asp:GridView>
                  
            </td> 
            </tr>
           
           
            <tr>
                <td align="center">

                    <div style="vertical-align:middle; float:left; margin-top: 5px; width:auto; background:none !important;">
                    <asp:Label ID="lblallcontractsdone" runat="server" Text="There is no any task pending." style="border:1px solid #000; padding:5px; color:Red;font-size: 11px; font-weight:bold;"></asp:Label>
                    </div>
                    <div style="background:none !important;"> &nbsp;
                   <input type="button" id="btnSaveAllContracts" class="save da_submit_button" value="Save"  onclick="javascript: return SaveAllContractsData();"/>
                    <input type="button" class="cancel da_submit_button" value="Cancel" onclick="javascript: return HideQCAllContracts();"/>
                    <asp:Button ID="btnContactSubmit" CssClass="ContactSubmit" style="display:none;"  runat="server" 
                                       Text="Button" onclick="btnContactSubmit_Click"/>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </div>
    <div class="style_number_box_background" id="divAllContracts_background_Rescan">
    </div>
    <div class="style_number_box" id="divAllContracts_Rescan">
    <div>
     Select Packing Dates.
    </div>
        <table width="100%" cellpadding="6px" class="mid">    
            <tr>
               
                  
                <td  valign="top" style="width:95%;padding:0px 0px" class="remove-div">
                <asp:GridView ID="grdAllContracts_Rescan" runat="server"  CssClass="AddClass_Table" AutoGenerateColumns="false" Width="100%" OnRowDataBound="grdAllContracts_Rescan_Rowdatabound">
              
      <Columns>
         
          <asp:TemplateField HeaderText="Packing Date." ItemStyle-Width="15%" HeaderStyle-Width="15%">
            <ItemTemplate>
            <asp:Label runat="server" ID="lblDatePacked" Text='<%# Eval("PackingDate") %>'></asp:Label>
            <asp:Label runat="server" ID="lblsavedate" style="display:none;" CssClass="PackingDate" Text='<%# Eval("PackingDate") %>'></asp:Label>
            </ItemTemplate>           
          </asp:TemplateField>  
           <asp:TemplateField HeaderText="Select" ItemStyle-Width="10%" HeaderStyle-Width="12%">
            <ItemTemplate>
                <asp:CheckBox  ID="chkRescan" CssClass="checkRescan" runat="server"/>
                <%-- <asp:CheckBox  ID="CheckBox1" runat="server"  Checked='<%#Eval("IsPacking")%>'/>--%>
                <asp:HiddenField ID="chkIsPacking" runat="server" value='<%#Eval("QualityControleid")%>'/>
             <%--    <asp:HiddenField ID="hdnQualityControlID" runat="server" value='<%#Eval("QualityControlID")%>'/>--%>
               

            </ItemTemplate>           
          </asp:TemplateField>         
         </Columns>         
         </asp:GridView>
                  
            </td> 
           
            </tr>
           
            <tr>
                <td align="center">
                    <div style="background:none !important;"> &nbsp;
                   <input type="button" id="btnSaveAllContracts_Rescan" runat="server" class="submit" value="Save"  onclick="javascript: return SaveAllContractsData_Rescan();"/>
                        
                    <input type="button" class="cancel da_submit_button close-this" value="Cancel" onclick="javascript: return HideQCAllContracts_Rescan();"/>                
                    </div>
                </td>
            </tr>
        </table>
    </div>
