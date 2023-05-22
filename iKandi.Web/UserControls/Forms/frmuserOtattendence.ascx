<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmuserOtattendence.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.frmuserOtattendence" %>
<%@ Register Namespace="AjaxControlToolkit"  Assembly="AjaxControlToolkit" TagPrefix="ajax" %>



<style type="text/css">
    .font
    {
        font-size: 13px;
    }
    .border td
    {
        border: 1px solid #000000;
        border-collapse: collapse;
    }
 
    .submit
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px 0px;
        border: none;
    }
    .submit:hover
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px -28px;
    }
    #tblProductionUnits
    {
        width: 98%;
    }
    .style1
    {
        width: 17px;
    }
    
    .TdPercent {
  
    height: 100%;
    padding: 0px;
    text-align:center;
    font-weight:bold;
    vertical-align:middle;
    line-height:30px;
    
}
  .TdPercent span{
  
    height: 100%;
    padding: 0px;
    text-align:center;
    font-weight:bold !important;
    
}


.thalign {
  vertical-align:top;
  text-align:center; 
 
}

.thalignStaff {
  vertical-align:middle;
  text-align:center; 
   direction:ltr;
 
}

.rotate{
  color: #000;
    display: block;
    /*Firefox*/
    -moz-transform: rotate(-90deg);
    /*Safari*/
    -webkit-transform: rotate(-90deg);
    /*Opera*/
    -o-transform: rotate(-90deg);-ms-transform: rotate(-90deg);
    /* ie*/
    filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
	color:#405d9a;
	font-weight:bold;
	font-size:15px;
	font-family:arial;
	padding:0px;

	

}

.rotate2{
  color: #000;
    display: block;
   
	color:#405d9a;
	font-weight:bold;
	font-size:15px;
	font-family:arial;
	padding:0px;

	

}


.thaligntable {
  vertical-align:top;
  text-align:center; 
 
}

    .TopTh{background-repeat:repeat-x; height:50%; height:37px; font-size:12px; border-color:Gray; color:White; text-transform:capitalize !important; font-weight:bold; font-family:Arial;background: #dddfe4;color: #575759;}
    
     
    .Manpowerlabel
    {
       width:80px;
     display: inline-block;
     vertical-align:top;
    text-align:center; 
    }
  .work-head
  {
      background:#f2f2f2;
      border:1px solid #666 !important;
      padding:5px;
      font-family:Verdana;
      font-weight:bold;
      font-size:10px;
      
  } 
  select, option 
  {
      padding:5px 0px !important;
      width:133px !important; 
      font-size:11px;
      font-family:Verdana;    
  }
  .worker-typ
  {
      
   
      text-transform:capitalize;
      width:10%;
     
  }
  
  .ot-inp
  {
      text-align:center !important;
      vertical-align:middle;
  }
  .ot-inp input
  {
      width:70% !important;
      text-align:center;
      
  }
  .work-ty
  {
      width:5% !important;
      
  }
  work-ty1
  {
      width:10% !important;
  }
  .op-text
  {
      color:#000;
      font-weight:normal;
  }
  .worker-typ span
  {
      padding:5px 0px;
  }
  .botto-head
  {
      font-weight:normal;
      font-size:9px;
      padding:5px 0px;
      text-align:center;
      background: #dddfe4;
      color: #575759;
  }
  .go-butt
  {
      background:#F3F3F3;
      border-radius:3px;
      padding:3px 6px; 
      font-weight:bold; 
      cursor:pointer; 
  }
     .op-type span
{
    font-family: arial;
font-size: 12px !important;
font-weight: bold;
color: #3B5998;
padding-left:2px;
table-layout:fixed;
}
.date 
{
    padding:5px;
}
</style>
  <script src="../../js/jquery.datePicker.js" type="text/javascript"></script>
  <script type="text/javascript">

      $(function () {

          $(".th").datepicker({ dateFormat: 'dd-mm-yy' });
      });
  
  </script>


<script type="text/javascript">
    var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';
    var proxy = new ServiceProxy(serviceUrl);
    var gvId;
    var FlagCheck;

    $(function () {
        MyDatePickerFunction();
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MyDatePickerFunction);


    });

    function MyDatePickerFunction() {
        //debugger;        
        var TDate = new Date();
        var TodayDate = TDate.toString("dd-MM-yyyy");
        var YDate = TDate.addDays(-2);

        var CDate = new Date();
        var MDate = CDate.addDays(0);
        $(".date").datepicker({ dateFormat: "dd-mm-yy", minDate: YDate, maxDate: MDate }).val()
    }

    function SaveOT_Manpowerdetails(elem, Flag) {
        //debugger;
        var WorkerCount = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        gvId = ctId;
        var UnitId;
        var WorkforceId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryWorkSpaceId']").val();

        if (Flag == 1) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId1']").val();
        }
        if (Flag == 2) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId2']").val();
        }
        if (Flag == 3) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId3']").val();
        }

        FlagCheck = Flag;
        var WorkForceName = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblFactory1']").html()

        var ProductionId = UnitId;

        var LogedInUserId = $('#' + '<%=hdnLoginUserId.ClientID %>').val();

        var txtDate = $('#' + '<%=txtDate1.ClientID %>').val();

        //        var TDate = new Date();
        //        var TodayDate = TDate.toString("dd-MM-yyyy");
        //        var YDate = TDate.addDays(-1);
        //        var Yesterday = YDate.toString("dd-MM-yyyy");
        //        var txtDate = $('#' + '<%=txtDate1.ClientID %>').val();
        //        var tDate = txtDate.toString("yyyy/MM/dd");        


        var OTId = $('#<%= ddl_Ot.ClientID %> option:selected').val();



        if (OTId == "-1") {
            alert("Value not save please select OT first ");
            return;
        }
        if (WorkerCount == "" || WorkerCount == "0") {
            elem.value = elem.defaultValue;
            return;
        }

        if (isNaN(parseInt(WorkerCount))) {
            elem.value = elem.defaultValue;
            return false;
        }
        calcConsume(ctId, Flag);
        var url = '../../Internal/OrderProcessing/AttandanceOT_Popup.aspx?ProductionUnit=' + ProductionId + '&WorkforceId=' + WorkforceId + '&OTType=' + OTId + '&NormalCount=' + WorkerCount + '&AttandenceDate=' + txtDate;
        var popupWindow = window.open(url, '_blank', 'height=300,width=360,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');

    }


    function calcConsume(ctId, Flag) {
        //debugger;
        //var ctId = elem.id.split('_')[6].substr(2);
        var UnitId;

        if (Flag == 1) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId1']").val();
            Budget = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblBudget1']");
            Consummed = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblConsummed1']");

        }
        if (Flag == 2) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId2']").val();
            Budget = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblBudget2']");
            Consummed = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblConsummed2']");
        }
        if (Flag == 3) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId3']").val();

            Budget = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblBudget3']");
            Consummed = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblConsummed3']");
        }
        // debugger;
        var WorkforceId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryWorkSpaceId']").val()
        var txtDate = $('#' + '<%=txtDate1.ClientID %>').val();
        //var OTDate = Date.parse(txtDate);
        //OTDate = OTDate.toString('yyyy-MM-dd')
        var OTId = $('#<%= ddl_Ot.ClientID %> option:selected').val();

        var Budget1 = 0;
        var Budget2 = 0;
        var Budget3 = 0;
        var Consume1 = 0;
        var Consume2 = 0;
        var Consume3 = 0;
        var ManPower1 = 0;
        var ManPower2 = 0;
        var ManPower3 = 0;

        var ManPower1 = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblManPower2']").val();
        var ManPower2 = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblManPower3']").val();
        var ManPower3 = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblManPower4']").val();


        proxy.invoke("calcBudget", { WorkforceId: WorkforceId, ProductionUnit: UnitId, OTDate: txtDate, OTs: OTId }, function (result) {
            //debugger;
            if (result.length > 0) {
                //debugger;
                if (Flag == 1) {
                    //debugger;
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget1']").html(result[0].val1);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed1']").html('(' + result[0].val2 + ')');
                    Budget2 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget2']").html();
                    Budget3 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget3']").html();
                    Consume2 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed2']").html();
                    Consume3 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed3']").html();

                    if (Budget2 == "") {
                        Budget2 = 0;
                    }
                    if (Budget3 == "") {
                        Budget3 = 0;
                    }
                    if (Consume2 == "") {
                        Consume2 = 0;
                    }
                    else {
                        var cc = Consume2.split("(");
                        cc = cc[1].split(")");
                        Consume2 = cc[0];
                    }
                    if (Consume3 == "") {
                        Consume3 = 0;
                    }
                    else {
                        var cc = Consume3.split("(");
                        cc = cc[1].split(")");
                        Consume3 = cc[0];
                    }

                    if (ManPower1 == "") {
                        ManPower1 = 0;
                    }
                    if (ManPower2 == "") {
                        ManPower2 = 0;
                    }
                    if (ManPower3 == "") {
                        ManPower3 = 0;
                    }

                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html(parseInt(ManPower1) + parseInt(ManPower2) + parseInt(ManPower3));
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html(parseInt(result[0].val1) + parseInt(Budget2) + parseInt(Budget3));
                    var consumeval = parseInt(result[0].val2) + parseInt(Consume2) + parseInt(Consume3);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('(' + consumeval + ')');

                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget1']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget1']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed1']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed1']").html('')
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('');
                    }
                }
                if (Flag == 2) {
                    //debugger;
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget2']").html(result[0].val1);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed2']").html('(' + result[0].val2 + ')');
                    Budget1 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget1']").html();
                    Budget3 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget3']").html();
                    Consume1 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed1']").html();
                    Consummed3 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed3']").html();

                    if (Budget1 == "") {
                        Budget1 = 0;
                    }
                    if (Budget3 == "") {
                        Budget3 = 0;
                    }
                    if (Consume1 == "") {
                        Consume1 = 0;
                    }
                    else {
                        var cc = Consume1.split("(");
                        cc = cc[1].split(")");
                        Consume1 = cc[0];
                    }
                    if (Consume3 == "") {
                        Consume3 = 0;
                    }
                    else {
                        var cc = Consummed3.split("(");
                        cc = cc[1].split(")");
                        Consummed3 = cc[0];
                    }
                    if (ManPower1 == "") {
                        ManPower1 = 0;
                    }
                    if (ManPower2 == "") {
                        ManPower2 = 0;
                    }
                    if (ManPower3 == "") {
                        ManPower3 = 0;
                    }

                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html(parseInt(ManPower1) + parseInt(ManPower2) + parseInt(ManPower3));
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html(parseInt(Budget1) + parseInt(result[0].val1) + parseInt(Budget3));
                    var consumeval = parseInt(result[0].val2) + parseInt(Consume1) + parseInt(Consume3);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('(' + consumeval + ')');

                    //$("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('(' + parseInt(Consume1) + parseInt(result[0].val2) + parseInt(Consume3) + ')');
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget2']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget2']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed2']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed2']").html('')
                    }

                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('');
                    }
                }
                if (Flag == 3) {
                    //debugger;
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget3']").html(result[0].val1);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed3']").html('(' + result[0].val2 + ')');
                    Budget1 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget1']").html();
                    Budget2 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget2']").html();
                    Consume1 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed1']").html();
                    Consume2 = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed2']").html();
                    if (Budget1 == "") {
                        Budget1 = 0;
                    }
                    if (Budget2 == "") {
                        Budget2 = 0;
                    }
                    if (Consume1 == "") {
                        Consume1 = 0;
                    }
                    else {
                        var cc = Consume1.split("(");
                        cc = cc[1].split(")");
                        Consume1 = cc[0];
                    }
                    if (Consume2 == "") {
                        Consume2 = 0;
                    }
                    else {
                        var cc = Consume2.split("(");
                        cc = cc[1].split(")");
                        Consume2 = cc[0];
                    }

                    if (ManPower1 == "") {
                        ManPower1 = 0;
                    }
                    if (ManPower2 == "") {
                        ManPower2 = 0;
                    }
                    if (ManPower3 == "") {
                        ManPower3 = 0;
                    }
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html(parseInt(ManPower1) + parseInt(ManPower2) + parseInt(ManPower3));
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html(parseInt(Budget1) + parseInt(Budget2) + parseInt(result[0].val1));
                    var consumeval = parseInt(result[0].val2) + parseInt(Consume1) + parseInt(Consume2);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('(' + consumeval + ')');

                    //$("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('(' + parseInt(Consume1) + parseInt(Consume2) + parseInt(result[0].val2) + ')');
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget3']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget3']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed3']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed3']").html('')
                    }

                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblManPower5']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblBudget4']").html('');
                    }
                    if ($("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html() == 0) {
                        $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblConsummed4']").html('');
                    }
                }
            }
        }, onPageError, false, false);

    }


    function IsNumber(elem) {
        var WorkerCount = elem.value;
        if (isNaN(parseInt(WorkerCount))) {
            elem.value = elem.defaultValue;
            return false;
        }


    }

    function pageLoad() {
        //debugger;
        if (document.getElementById("<%=HiddenField1.ClientID%>").value != "") { document.getElementById("<%=txtDate1.ClientID%>").value = document.getElementById("<%=HiddenField1.ClientID%>").value; }
    }


    function clientChanged(sender, args) {
        document.getElementById("<%=HiddenField1.ClientID%>").value = sender._selectedDate.format(sender._format);
    }



    function SetDate() {
        //debugger;
        var WorkingDate = $('#' + '<%=txtDate1.ClientID %>').val();
        var HourDate = Date.parseExact(WorkingDate, "dd-MM-yyyy")
        //var selecteddate = HourDate.toString("dd/MMM/yyyy(dd)");
        var selecteddate = HourDate.toString("dd MMM yy (ddd)");
        $('#' + '<%=lblMAinDay.ClientID %>').html(selecteddate);

    }
    //    abhishek 26/8/2015 for retain ot dropdown selected value
    function GetValue() {
        //debugger;
        var ot_value = $('#<%= ddl_Ot.ClientID %> option:selected').val();
        $('#<%= hdnSelectedValue.ClientID %>').val(ot_value);
        $('#<%= ddl_Ot.ClientID %> option:selected').val(ot_value);

    }

    //    end abhishek

    function CallManCount_Values() {
        //debugger;
        var ctId = gvId;
        var Flag = FlagCheck;
        var UnitId;
        if (Flag == 1) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId1']").val();
        }
        if (Flag == 2) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId2']").val();
        }
        if (Flag == 3) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId3']").val();
        }

        var WorkforceId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryWorkSpaceId']").val();

        var ProductionId = UnitId;

        var LogedInUserId = $('#' + '<%=hdnLoginUserId.ClientID %>').val();

        var TDate = new Date();
        var TodayDate = TDate.toString("dd-MM-yyyy");
        var YDate = TDate.addDays(-1);
        var Yesterday = YDate.toString("dd-MM-yyyy");
        var txtDate = $('#' + '<%=txtDate1.ClientID %>').val();
        //var tDate = txtDate.toString("yyyy/MM/dd");
        //var Workinghours = $('#' + '<%=txtWorkinghours.ClientID %>').val();


        var OTId = $('#<%= ddl_Ot.ClientID %> option:selected').val();

        proxy.invoke("Get_DailyManpowerAttandence", { ProductionUnit: UnitId, WorkforceId: WorkforceId, OTDate: txtDate, OTs: OTId }, function (result) {
            //debugger;
            if (result.length > 0) {
                var ManCount = result[0].val1;
                var Hours = result[0].val2;
                if (UnitId == 3) {
                    $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblManPower2']").val(ManCount);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblHours1']").html('(' + Hours.toFixed(2) + ')');
                }
                if (UnitId == 11) {
                    $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblManPower3']").val(ManCount);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblHours2']").html('(' + Hours.toFixed(2) + ')');
                }
                if (UnitId == 12) {
                    $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_lblManPower4']").val(ManCount);
                    $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblHours3']").html('(' + Hours.toFixed(2) + ')');
                }

                calcConsume(ctId, Flag);
            }
        }, onPageError, false, false);
    }

    function Check_WorkCount_Attandance(elem, Flag) {
        //debugger;
        var WorkerCount = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        gvId = ctId;
        var UnitId;
        var WorkforceId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryWorkSpaceId']").val();

        if (Flag == 1) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId1']").val();
        }
        if (Flag == 2) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId2']").val();
        }
        if (Flag == 3) {
            UnitId = $("#<%= grdotAtte.ClientID %> input[id$='" + ctId + "_hdnFactoryUnitId3']").val();
        }

        FlagCheck = Flag;
        var WorkForceName = $("#<%= grdotAtte.ClientID %> span[id$='" + ctId + "_lblFactory1']").html();

        var ProductionId = UnitId;

        var txtDate = $('#' + '<%=txtDate1.ClientID %>').val();

        var OTId = $('#<%= ddl_Ot.ClientID %> option:selected').val();



        if (OTId == "-1") {
            alert("Value not save please select OT first ");
            return;
        }
        if (WorkerCount == "" || WorkerCount == "0") {
            alert("Please Enter valid Workercount ");
            elem.value = elem.defaultValue;
            return;
        }

        if (isNaN(parseInt(WorkerCount))) {
            elem.value = elem.defaultValue;
            return false;
        }

        //debugger;
        proxy.invoke("Check_WorkCount_Attandance", { ProductionUnit: UnitId, WorkforceId: WorkforceId, OTDate: txtDate, OTs: OTId, WorkerCount: WorkerCount }, function (result) {
            var Icount = parseInt(result);
            if (Icount != -1 && Icount != 0) {
                //debugger;                
                //calcConsume(ctId, Flag);
                var url = '../../Internal/OrderProcessing/AttandanceOT_Popup.aspx?ProductionUnit=' + ProductionId + '&WorkforceId=' + WorkforceId + '&OTType=' + OTId + '&NormalCount=' + WorkerCount + '&AttandenceDate=' + txtDate;
                var popupWindow = window.open(url, '_blank', 'height=300,width=360,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
            }
            else {

                alert("OT Is Not Allowed Without Daily Attendence Or OT Attendence Count Can't Greater than Normal Count ");
                elem.value = elem.defaultValue;
            }

        }, onPageError, false, false);



    }


</script>




<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager> --%>
     
<div>
<asp:updatepanel id="UpdatePanel1"  UpdateMode="Always" runat="server">
<contenttemplate>


<asp:HiddenField ID="hdnLoginUserId" runat="server" Value="0" />
<%--abhishek 26/8/2015--%>
<asp:HiddenField ID="hdnSelectedValue" runat="server" Value="-1" /> 








    <table cellspacing="0" cellpadding="0" width="100%" style="table-layout:fixed;">
     
    <tr>


    <td>
    
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="15%"> <b> Date : </b>&nbsp;
<asp:TextBox ID="txtDate1" runat="server" CssClass="th" OnTextChanged="txtDate1_TextChanged1" Enabled="false"></asp:TextBox> </td>
        <td width="13%">
   
   
   <%--  <asp:ImageButton ID="imgbtnCalendar" runat="server" ImageUrl="~/App_Themes/ikandi/images/calendar.gif" style="width:16px; vertical-align:middle"/>--%>
                       
<%--<ajax:calendarextender ID="CalendarExtender2"  Format="dd-MM-yyyy" EnableViewState="true" OnClientDateSelectionChanged="clientChanged"  TargetControlID="txtDate1" PopupButtonID="imgbtnCalendar" PopupPosition="BottomRight"   runat="server" />--%>

<asp:HiddenField ID="HiddenField1" runat="server" />

<b> OTs : </b> &nbsp;
<%--abhishek on 26/8/2015--%>
 <asp:DropDownList ID="ddl_Ot" runat="server" 
                              style="text-align:left;" 
                            onselectedindexchanged="ddl_Ot_SelectedIndexChanged">
                     <asp:ListItem Value="-1" Selected="True"> Select OT</asp:ListItem>
                     <asp:ListItem Value="2" >OT1</asp:ListItem>
                      <asp:ListItem Value="3" >OT2</asp:ListItem>
                       <asp:ListItem Value="4" >OT3</asp:ListItem>
                        <asp:ListItem Value="5" >OT4</asp:ListItem>
                      
                      </asp:DropDownList>
      <%-- end --%>
    </td>


        <td width="65%"  align="left">
            <asp:Button ID="btnGo" OnClientClick="GetValue();" runat="server" Text="Search" onclick="btnGo_Click" CssClass="go-butt go" />
    
    </td>
    
    </tr>
    
    </table>
    
    </td>


    </tr>
     <tr>
            <td>
               &nbsp; 
            </td>
        </tr>
    <tr>
     <td> 
     <div id="divHead" runat="server">
       <table width="1230px" cellpadding="0" cellspacing="0" border="0" class="work-head">
       <tr>
       <td width="18%" style="display:none;">
   
    
   <asp:Label ID="Label12" runat="server" Text=" Total No Of Working Hours Is:" ></asp:Label>
   <asp:TextBox ID="txtWorkinghours" runat="server" onchange="IsNumber(this)" Width="40" MaxLength="2" CssClass="op-text"></asp:TextBox>
    </td>

    <td style="width:17%;">
    
    <asp:Label ID="lblBudgetCaption" runat="server" Text="Total Budget:" ></asp:Label>
    <asp:Label ID="lblGlobTotalBudget" runat="server" CssClass="op-text"></asp:Label>
    <asp:Label ID="lblGlobTotalBudgetCMT" runat="server" CssClass="op-text"></asp:Label>
    </td>
   
    <td style="width:20%;">
    <asp:Label ID="lblConsummedCaption" runat="server" Text="Total Consummed:"></asp:Label>
    <asp:Label ID="lblBudgetConsummed" runat="server" CssClass="op-text"></asp:Label>
    <asp:Label ID="lblGlobTotalConsummedCMT" runat="server" CssClass="op-text"></asp:Label>
    </td>
  
    <td style="width:18%;">
    
    <asp:Label ID="lblPerDayBudgetCaption" runat="server" Text="per Day Budget:"></asp:Label>
    <asp:Label ID="lblPerDayBudget" runat="server" CssClass="op-text"></asp:Label>
    <asp:Label ID="lblPerDayBudgetCMT" runat="server" CssClass="op-text"></asp:Label>
    </td>
    
    <td style="width:25%;">
    <asp:Label ID="lblPerDayCaption" runat="server" Text="Avg. Per Day Consummed:"></asp:Label>
    <asp:Label ID="lblPerDayConsummed" runat="server" CssClass="op-text"></asp:Label>
    <asp:Label ID="lblPerDayConsummedCMT" runat="server" CssClass="op-text"></asp:Label>
    
    </td>
 
    <td style="width:9%;"><asp:Label ID="lblMAinDay" runat="server"></asp:Label></td>
       
       </tr>
       
       
       </table>
     </div>
      </td>
    
    
    </tr>




        <tr>
            <td>
               &nbsp; 
            </td>
        </tr>
         <tr>
                <td>
                
                </td>

                </tr>

                <tr>
                <td>
                <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                  <ProgressTemplate>
                    <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                  </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:GridView ID="grdotAtte" runat="server" AutoGenerateColumns="false"  OnRowCreated="grdotAtte_RowCreated1" CellPadding="0" CellSpacing="0" 
                onrowdatabound="grdotAtte_RowDataBound" HeaderStyle-ForeColor="#39589C" CssClass="persist-area"  Width="1230px" style="background:#fff; table-layout:fixed;">
                <Columns>
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thalignStaff">
                <ItemTemplate>
                <asp:Label ID="lblStaffDept" runat="server" CssClass="rotate"  Text='<%#Eval("StaffDept") %>'></asp:Label>
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Middle" Width="130px" />
                
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="thalign" HeaderStyle-Width="250px">
                <ItemTemplate>
                <asp:Label ID="lblFactory1" runat="server" Width="250px" Text='<%#Eval("WorkerType") %>'></asp:Label>
                
                <asp:HiddenField ID="hdnFactoryWorkSpaceId" runat="server" Value='<%#Eval("FactoryWorkSpaceId") %>' />
                
                
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Top"  CssClass="worker-typ op-type" Width="250px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" ItemStyle-Width="80px" HeaderStyle-CssClass="thalign work-ty">
                <ItemTemplate>
           <asp:TextBox ID="lblManPower2" runat="server" MaxLength="4" style="width:30px !important"
                onchange="javascript:return Check_WorkCount_Attandance(this,1)" onclick="javascript:return SaveOT_Manpowerdetails(this,1)"></asp:TextBox>
               
                
                <asp:Label ID="lblHours1" runat="server" MaxLength="4" Text="0" Width="40"></asp:Label>
               
                <asp:HiddenField ID="hdnFactoryUnitId1" runat="server" Value="3" />
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Top"  CssClass="ot-inp" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" HeaderStyle-CssClass="thaligntable work-ty1">
                <ItemTemplate>
                <asp:Label ID="lblBudget1" runat="server"></asp:Label><asp:Label ID="lblConsummed1" runat="server"></asp:Label>
                <%--  <div style="width:100%;" class="TdPercent">
                <div style="float:left; width:50%; height:32px; border-right:0px solid #666; padding:0px;" class="TdPercent">  <asp:Label ID="lblBudget1" runat="server"></asp:Label></div>
                <div style="float:left; width:49%; padding:0px;" class="TdPercent"> <asp:Label ID="lblConsummed1" runat="server"></asp:Label> </div>
                <div style="clear:both;"></div>--%>
                <%--<table>
                <tr>
                <td align="left"></td>
                </tr>
                </table>--%>
                </div>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="ot-inp" Width="125px"  />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" ItemStyle-Width="85px" HeaderStyle-CssClass="thalign work-ty">
                <ItemTemplate>
               <asp:TextBox ID="lblManPower3" onchange="javascript:return Check_WorkCount_Attandance(this,2)" runat="server" MaxLength="4" style="width:30px !important" onclick="javascript:return SaveOT_Manpowerdetails(this,2)" ></asp:TextBox>
              
                <asp:Label ID="lblHours2" runat="server" MaxLength="4" Text="0" Width="45"></asp:Label>
              
               <asp:HiddenField ID="hdnFactoryUnitId2" runat="server" Value="11" />
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top"  CssClass="ot-inp" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" HeaderStyle-CssClass="thaligntable work-ty1">
                <ItemTemplate>
                <asp:Label ID="lblBudget2" runat="server" Height="100%" ></asp:Label><asp:Label ID="lblConsummed2" runat="server" Height="100%" ></asp:Label>
               <%-- <div style="width:100%;" class="TdPercent">
                <div style="float:left; width:50%; height:32px; border-right:0px solid #666; padding:0px;" class="TdPercent"><asp:Label ID="lblBudget2" runat="server" Height="100%" ></asp:Label>(<asp:Label ID="lblConsummed2" runat="server" Height="100%" ></asp:Label>)</div>
                <div style="float:left; width:49%; padding:0px;" class="TdPercent"><asp:Label ID="lblConsummed2" runat="server" Height="100%" ></asp:Label></div>
                <div style="clear:both;"></div>--%>
                </div>
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Top"  CssClass="ot-inp"  Width="125px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" ItemStyle-Width="85px" HeaderStyle-CssClass="thalign work-ty">
                <ItemTemplate>
                <asp:TextBox ID="lblManPower4" onchange="javascript:return Check_WorkCount_Attandance(this,3)" runat="server" MaxLength="4" style="width:30px !important" onclick="javascript:return SaveOT_Manpowerdetails(this,3)"></asp:TextBox>
               
                <asp:Label ID="lblHours3" runat="server" MaxLength="4" Text="0" Width="45"></asp:Label>
              
                <asp:HiddenField ID="hdnFactoryUnitId3" runat="server" Value="12" />
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Top"  CssClass="ot-inp" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" HeaderStyle-CssClass="thaligntable work-ty1">
                <ItemTemplate>
                <asp:Label ID="lblBudget3" runat="server" Height="100%" ></asp:Label><asp:Label ID="lblConsummed3" runat="server" Height="100%" ></asp:Label>
                <%--<div style="width:100%;" class="TdPercent">
                <div style="float:left; width:50%; height:32px; border-right:0px solid #666; padding:0px;" class="TdPercent"><asp:Label ID="lblBudget3" runat="server" Height="100%" ></asp:Label>(<asp:Label ID="lblConsummed3" runat="server" Height="100%" ></asp:Label>)</div>
                <div style="float:left; width:49%; padding:0px;" class="TdPercent"><asp:Label ID="lblConsummed3" runat="server" Height="100%" ></asp:Label></div>
                <div style="clear:both;"></div>--%>
                </div>
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Top" CssClass="ot-inp"  Width="125px"   />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" ItemStyle-Width="85px" HeaderStyle-CssClass="thalign work-ty">
                <ItemTemplate>
                <asp:Label ID="lblManPower5" runat="server" ></asp:Label>             
                
              
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Top" CssClass="ot-inp"  />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Header1" HeaderStyle-CssClass="thaligntable work-ty1">
                <ItemTemplate>
                <asp:Label ID="lblBudget4" runat="server" Height="100%" ></asp:Label><asp:Label ID="lblConsummed4" runat="server" Height="100%" ></asp:Label>
                <%--<div style="width:100%;" class="TdPercent">
                <div style="float:left; width:50%; height:32px; border-right:0px solid #666; padding:0px;" class="TdPercent"><asp:Label ID="lblBudget4" runat="server" Height="100%" ></asp:Label>(<asp:Label ID="lblConsummed4" runat="server" Height="100%" ></asp:Label>)</div>
                <div style="float:left; width:49%; padding:0px;" class="TdPercent"><asp:Label ID="lblConsummed4" runat="server" Height="100%" ></asp:Label></div>
                <div style="clear:both;"></div>--%>
                </div>
                </ItemTemplate>
                 <ItemStyle VerticalAlign="Top" CssClass="ot-inp"  Width="125px" />
                </asp:TemplateField>
                
                </Columns>
     <%--<HeaderStyle CssClass="GridviewScrollHeader" /> 
    <RowStyle CssClass="GridviewScrollItem" /> 
    <PagerStyle CssClass="GridviewScrollPager" />--%>
                </asp:GridView>
                </td>
                </tr>
    </table>

     </contenttemplate>
     </asp:updatepanel>
</div>
