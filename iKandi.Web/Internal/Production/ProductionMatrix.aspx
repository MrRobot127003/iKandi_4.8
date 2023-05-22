<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionMatrix.aspx.cs" Inherits="iKandi.Web.Internal.Production.ProductionMatrix" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    body
    {
        font-family:Verdana;
        font-size:12px;
    }
.item_list th
{
    height:20px;
    background:#cacfd2;
    color:#666 !important;
}
.item_list td span
{
    vertical-align:middle;
    width:90%;    
}

.item_listLine th
{ 
    height:15px;
    padding:2px;
    background:#428bca;
    color:#fff;
   
}
.item_listLine td 
{
    text-align:center;
}
.item_listLine td span
{
    vertical-align:middle;
    width:90%;
    text-align:center;
}

.border2 th
{
   text-align: center;
   font-size:11px;
	font-family: arial, halvetica;
	color:#666;
	font-weight:normal;
	padding:0px;
	background:#cacfd2;
}
.Accstyle input
{
    width:40px;
    vertical-align:middle;
    text-align:center;        
}
.Accstyle
{
    height:20px;    
    vertical-align:middle;    
    width:55px; 
         
}
.Accstyle-new
{
     height:20px;    
    vertical-align:middle;    
    width:55px; 
         
}

.Fabtyle
{
    height:20px; 
    vertical-align:middle;       
    width:55px;         
}
.Fabtyle input
{
    width:40px;
    vertical-align:middle;
    text-align:center;        
}
.hiddencol
{
    display:none;
}
.border2 th 
{
    height:56px !important;
}
.borderbottom td
{
    height:20px;
}
.ItemBackGreen
{
    background-color:Green !important;
    color:White !important; 
    
}
.ItemBackRed 
{
    background-color:Red !important;
    color:White; 
    
}

.TotalBackStitch
{
    background-color:Yellow !important;    
     display:block;
     height:20px;     
}
.blue
{
    color:Blue;
}
.rowcolor
{
    background-color:#da9694 !important;color:White;
}
.rowcolor input
{
     background-color:#da9694 !important;color:White;
}
.rowcolor .TotalBackStitch
{
    background-color:#da9694 !important;color:White;
}
.rowcolor .days-back
{
    background-color:#da9694 !important;
    color:black;
}
.days-back
{    
    color:#98a9ca;
}
.rowcolor span
{
 color:White !important;
}
body
{
    margin: 0;
    padding: 0;
    font-family: Arial;
}
.modal
{
    position: fixed;
    z-index: 999;
    height: 100%;
    width: 100%;
    top: 0;
    background-color: Black;
    filter: alpha(opacity=60);
    opacity: 0.6;
    -moz-opacity: 0.8;
}
.center
{
    z-index: 1000;
    margin: 300px auto;
    padding: 10px;
    width: 130px;  
    filter: alpha(opacity=100);
    opacity: 1;
    -moz-opacity: 1;
}
.ItemBackStitch 
{
    background-color:#81DAF5;
}
.rotate{
    display: block; /*Firefox*/    
    -moz-transform: rotate(-45deg);   /*Safari*/  
    -webkit-transform: rotate(-45deg); /*Opera*/    
    -o-transform: rotate(-45deg);-ms-transform: rotate(-45deg); /* ie*/    
    filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
	padding:0px;
}

/*.applyNew
{
    background-color: White;
    background-image: url(../../App_Themes/ikandi/images/apply.jpg);
    background-repeat: no-repeat;
    width: 83px;
    height: 28px;
    border: none;
    background-position: 0px 0px;
}
.applyNew:hover
{
    background-color: White;
    background-image: url(../../App_Themes/ikandi/images/apply.jpg);
    background-repeat: no-repeat;
    width: 83px;
    height: 28px;
    border: none;
    background-position: 0px -28px;
}*/
.hide-button td:nth-child(2)
{
    display:none;
}
.hide-button td:nth-child(3)
{
    display:none;
}
</style>

</head>
<body>
 <script type="text/javascript" src="../../js/service.min.js"></script>
 <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>  
 <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/facebox.js")%>'></script> 
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/js.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ImageFaceBox.js")%>'></script>   
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/colorpicker.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/fna.js")%>' type="text/javascript"></script>
   <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/date.js")%>'></script>


   <script type="text/javascript">
   
       var serviceUrl = '<%= ResolveUrl("../../Webservices/iKandiService.asmx/") %>';
       var proxy = new ServiceProxy(serviceUrl);

       $(function () {          
           $('span.number-with-commas').FormatNumberWithCommas();
       });

       var grdProductionMatrix_Line1_ClientID = '<%=grdProductionMatrix_Line1.ClientID %>';
       var grdProductionMatrix_Line2_ClientID = '<%=grdProductionMatrix_Line2.ClientID %>';
       var grdProductionMatrix_Line3_ClientID = '<%=grdProductionMatrix_Line3.ClientID %>';
       var grdProductionMatrix_Line4_ClientID = '<%=grdProductionMatrix_Line4.ClientID %>';

       // Add Extra Hrs from Header in 1st grid
       function OnChangeExtraHoursLine1(obj) {
           //debugger;
           var ExtraHrsHdr = obj.value;
           var CurrentDate = new Date((new Date()).setHours(0, 0, 0, 0));

           var rowCount = $("#" + grdProductionMatrix_Line1_ClientID).find("tr").length;
           for (var row = 1; row <= rowCount; row++) {
               //debugger;
               var objRow = $("#" + grdProductionMatrix_Line1_ClientID).find("tr").filter("tr:eq(" + row + ")");
               var ProdDate = objRow.find("input[type=hidden]:regex(id,hdnLinePlanningDate)").val(); 
               var SelectedDate = new Date(new Date(ProdDate).setHours(0, 0, 0, 0));               
               if (CurrentDate <= SelectedDate) {
               objRow.find(".clsddlHrsAdd1").val(ExtraHrsHdr);
               }
           }
   }

   // Add Extra Hrs from Header in 2nd grid
   function OnChangeExtraHoursLine2(obj) {
       //debugger;
       var ExtraHrsHdr = obj.value;
       var CurrentDate = new Date((new Date()).setHours(0, 0, 0, 0));

       var rowCount = $("#" + grdProductionMatrix_Line2_ClientID).find("tr").length;
       for (var row = 1; row <= rowCount; row++) {
           //debugger;
           var objRow = $("#" + grdProductionMatrix_Line2_ClientID).find("tr").filter("tr:eq(" + row + ")");
           var ProdDate = objRow.find("input[type=hidden]:regex(id,hdnLinePlanningDate)").val();
           var SelectedDate = new Date(new Date(ProdDate).setHours(0, 0, 0, 0));
           if (CurrentDate <= SelectedDate) {
               objRow.find(".clsddlHrsAdd2").val(ExtraHrsHdr);
           }
       }
   }
   // Add Extra Hrs from Header in 3rd grid
   function OnChangeExtraHoursLine3(obj) {
       //debugger;
       var ExtraHrsHdr = obj.value;
       var CurrentDate = new Date((new Date()).setHours(0, 0, 0, 0));

       var rowCount = $("#" + grdProductionMatrix_Line3_ClientID).find("tr").length;
       for (var row = 1; row <= rowCount; row++) {          
           var objRow = $("#" + grdProductionMatrix_Line3_ClientID).find("tr").filter("tr:eq(" + row + ")");
           var ProdDate = objRow.find("input[type=hidden]:regex(id,hdnLinePlanningDate)").val();
           var SelectedDate = new Date(new Date(ProdDate).setHours(0, 0, 0, 0));
           if (CurrentDate <= SelectedDate) {
               objRow.find(".clsddlHrsAdd3").val(ExtraHrsHdr);
           }
       }
   }
   // Add Extra Hrs from Header in 4th grid
   function OnChangeExtraHoursLine4(obj) {
       //debugger;
       var ExtraHrsHdr = obj.value;
       var CurrentDate = new Date((new Date()).setHours(0, 0, 0, 0));

       var rowCount = $("#" + grdProductionMatrix_Line4_ClientID).find("tr").length;
       for (var row = 1; row <= rowCount; row++) {          
           var objRow = $("#" + grdProductionMatrix_Line4_ClientID).find("tr").filter("tr:eq(" + row + ")");
           var ProdDate = objRow.find("input[type=hidden]:regex(id,hdnLinePlanningDate)").val();
           var SelectedDate = new Date(new Date(ProdDate).setHours(0, 0, 0, 0));
           if (CurrentDate <= SelectedDate) {
               objRow.find(".clsddlHrsAdd4").val(ExtraHrsHdr);
           }
       }
   }

           
           function ValidateExtraHrs(obj)
           {
               var ExtrHrs = obj.value;
               if(parseInt(ExtrHrs) == 0)
               {
               alert('Extra hrs can not be 0');
               obj.value = '';
               return false;
               }
           }           
         
           // First
           function ChangerBtnEff1()           
            {
               //debugger;
               var list = document.getElementById("rbtnEff1"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               var txtCustomizeEff = '<%=txtCustomEff1.ClientID %>';
               var txtCustProdDay = '<%=txtCustProdDay1.ClientID %>';
               if (inputs[0].checked) {
                   $("#" + txtCustomizeEff).attr('disabled',true);;
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[1].checked) {
                   $("#" + txtCustomizeEff).attr("disabled", true);
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[2].checked) {
                   $("#" + txtCustomizeEff).attr("disabled",  false);
                   $("#" + txtCustProdDay).attr("disabled", false);
               }
           }

           function ValidatePeakCapecity1() {     
           //debugger;                          
               var list = document.getElementById("rbtnEff1"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               if (inputs[2].checked) {
                   var txtCustomizeEff = '<%=txtCustomEff1.ClientID %>';
                   var txtCustProdDay = '<%=txtCustProdDay1.ClientID %>';
                   var CustomizeEff = $("#" + txtCustomizeEff).val();
                   var CustProdDay = $("#" + txtCustProdDay).val();
                   if ((CustomizeEff == '') || (CustProdDay == '')) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
                   if ((parseInt(CustomizeEff) == 0) || (parseInt(CustProdDay) == 0)) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
               }
               //SaveExtraHoursLine1();
           }

           // Save line 1        


//           function SaveExtraHoursLine1() {
//               //debugger;
//               //alert('save extra');
//               var hdnOrderDetailId = '<%=hdnOrderDetailId.ClientID %>';
//               var OrderDetailID = $("#" + hdnOrderDetailId).val();
//               var CurrentDate = new Date((new Date()).setHours(0, 0, 0, 0))

//               var grdLine1Row = $(".Line1Row").length;               
//               var RowId = 0;
//               var cId = 0;
//               for (var row = 1; row <= grdLine1Row; row++) {
//                   RowId = parseInt(row) + 1;
//                   if (parseInt(RowId) < 10)
//                       cId = '0' + RowId
//                   else
//                       cId = RowId;
//                   var Stitching = $("#<%= grdProductionMatrix_Line1.ClientID %> input[id*='ctl" + cId + "_hdnStitching" + "']").val();
//                   if (Stitching == 0) {
//                       var ProdDate = $("#<%= grdProductionMatrix_Line1.ClientID %> input[id*='ctl" + cId + "_hdnLinePlanningDate" + "']").val();
//                       var SelectedDate = new Date(new Date(ProdDate).setHours(0, 0, 0, 0));
//                       if (CurrentDate <= SelectedDate) {
//                           var LineNo = $("#<%= grdProductionMatrix_Line1.ClientID %> input[id*='ctl" + cId + "_hdnLineNo" + "']").val();
//                           var UnitId = $("#<%= grdProductionMatrix_Line1.ClientID %> input[id*='ctl" + cId + "_hdnUnitId" + "']").val();
//                           var ExtrHrs = $("#<%= grdProductionMatrix_Line1.ClientID %> input[id*='ctl" + cId + "_txtHrsAdd" + "']").val();
//                           if (ExtrHrs == '')
//                               ExtrHrs = 0;

//                           proxy.invoke("SaveProduction_ExtraHrs", { OrderDetailId: OrderDetailID, ProdDate: ProdDate, ExtraHrs: ExtrHrs, LineNo: LineNo, UnitId: UnitId }, function (result) {
//                               if (result > 0) {
//                                   // $(".refresh").click();
//                               }
//                           }, onPageError, false, false);
//                       }
//                   }
//               }

//           }


           // Second
           function ChangerBtnEff2() {
               //debugger;
               var list = document.getElementById("rbtnEff2"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               var txtCustomizeEff = '<%=txtCustomEff2.ClientID %>';
               var txtCustProdDay = '<%=txtCustProdDay2.ClientID %>';
               if (inputs[0].checked) {
                   $("#" + txtCustomizeEff).attr('disabled', true); ;
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[1].checked) {
                   $("#" + txtCustomizeEff).attr("disabled", true);
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[2].checked) {
                   $("#" + txtCustomizeEff).attr("disabled", false);
                   $("#" + txtCustProdDay).attr("disabled", false);
               }
           }

           function ValidatePeakCapecity2() {
               //debugger;
               var list = document.getElementById("rbtnEff2"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               if (inputs[2].checked) {
                   var txtCustomizeEff = '<%=txtCustomEff2.ClientID %>';
                   var txtCustProdDay = '<%=txtCustProdDay2.ClientID %>';
                   var CustomizeEff = $("#" + txtCustomizeEff).val();
                   var CustProdDay = $("#" + txtCustProdDay).val();
                   if ((CustomizeEff == '') || (CustProdDay == '')) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
                   if ((parseInt(CustomizeEff) == 0) || (parseInt(CustProdDay) == 0)) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
               }
               //SaveExtraHoursLine2()
           }

           // Third
           function ChangerBtnEff3() {
               //debugger;
               var list = document.getElementById("rbtnEff3"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               var txtCustomizeEff = '<%=txtCustomEff3.ClientID %>';
               var txtCustProdDay = '<%=txtCustProdDay3.ClientID %>';
               if (inputs[0].checked) {
                   $("#" + txtCustomizeEff).attr('disabled', true);
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[1].checked) {
                   $("#" + txtCustomizeEff).attr("disabled", true);
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[2].checked) {
                   $("#" + txtCustomizeEff).attr("disabled", false);
                   $("#" + txtCustProdDay).attr("disabled", false);
               }
           }

           function ValidatePeakCapecity3() {
               //debugger;
               var list = document.getElementById("rbtnEff3"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               if (inputs[2].checked) {
                   var txtCustomizeEff = '<%=txtCustomEff3.ClientID %>';
                   var txtCustProdDay = '<%=txtCustProdDay3.ClientID %>';
                   var CustomizeEff = $("#" + txtCustomizeEff).val();
                   var CustProdDay = $("#" + txtCustProdDay).val();
                   if ((CustomizeEff == '') || (CustProdDay == '')) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
                   if ((parseInt(CustomizeEff) == 0) || (parseInt(CustProdDay) == 0)) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
               }
               //SaveExtraHoursLine3()
           }

           // Fourth
           function ChangerBtnEff4() {
               //debugger;
               var list = document.getElementById("rbtnEff4"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               var txtCustomizeEff = '<%=txtCustomEff4.ClientID %>';
               var txtCustProdDay = '<%=txtCustProdDay4.ClientID %>';
               if (inputs[0].checked) {
                   $("#" + txtCustomizeEff).attr('disabled', true); ;
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[1].checked) {
                   $("#" + txtCustomizeEff).attr("disabled", true);
                   $("#" + txtCustProdDay).attr("disabled", true);
               }
               if (inputs[2].checked) {
                   $("#" + txtCustomizeEff).attr("disabled", false);
                   $("#" + txtCustProdDay).attr("disabled", false);
               }
           }

           function ValidatePeakCapecity4() {
               //debugger;
               var list = document.getElementById("rbtnEff4"); //Client ID of the radiolist
               var inputs = list.getElementsByTagName("input");
               if (inputs[2].checked) {
                   var txtCustomizeEff = '<%=txtCustomEff4.ClientID %>';
                   var txtCustProdDay = '<%=txtCustProdDay4.ClientID %>';
                   var CustomizeEff = $("#" + txtCustomizeEff).val();
                   var CustProdDay = $("#" + txtCustProdDay).val();
                   if ((CustomizeEff == '') || (CustProdDay == '')) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
                   if ((parseInt(CustomizeEff) == 0) || (parseInt(CustProdDay) == 0)) {
                       alert('CustomizeEff or CustProdDay cannot be 0 or empty');
                       return false;
                   }
               }
               //SaveExtraHoursLine4()
           }

           function CloseWindow() {
               alert('Session has been expired!');
               self.parent.Shadowbox.close();                    
           }

</script>
    <form id="form1" runat="server">   
  <div>
  
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal">
        <div class="center">
            <img alt="" src="../../images/loading36.gif" />
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>
    <asp:updatepanel ID="Updatepanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate> 
    <div style="width:97%; margin:0px auto;">
    <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; width:100%; text-align: center;
                    margin-bottom: 10px;">
                <div style="float:left; margin-left:15px; font-size:12px;"><asp:Label ID="lblSerialNo" runat="server" Text=""></asp:Label></div> 
                   Production Planning     <div style="float:right; margin-right:15px; font-size:12px;"> ExFactory : <asp:Label ID="lblExFactory" runat="server" Text="Label"></asp:Label> </div>
                <asp:HiddenField ID="hdnOrderDetailId" Value="-1" runat="server" />   
                <h2>
                </h2>
                <table class="item_list" style="width:100%; border: 1px solid #ddd;">
                    <tr>
                        <th width="7.5%">
                            Total Working Hrs</th>
                        <td width="7.5%">
                            <asp:Label ID="lblWorkingHrs" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            Order Qty</th>
                        <td width="7.5%">
                            <asp:Label ID="lblOrderQty" CssClass="number-with-commas" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            Actual Stitched</th>
                        <td width="7.5%">
                            <asp:Label ID="lblActualStitched" CssClass="number-with-commas" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            SAM</th>
                        <td width="7.5%">
                            <asp:Label ID="lblSAM" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="6%">
                            OB</th>
                        <td width="7.5%">
                            <asp:Label ID="lblOB" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            Avail Mins</th>
                        <td width="7.5%">
                            <asp:Label ID="lblAvailMins" CssClass="number-with-commas" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="6%">
                            Lines</th>
                        <td width="7.5%">
                            <asp:Label ID="lblLines" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnExFactory" runat="server" Value="" />
                        </td>
                    </tr>
                </table>
                <br />
                <div>
               <asp:Label ID="lblExFactoryOld" ForeColor="Red" Font-Size="12px" Font-Bold="true" runat="server" Text=""></asp:Label>
               </div>
                <table align="left" cellpadding="0" cellspacing="0" style="max-width:1600px;">
                    <tr>
                        <td style="color: gray; font-weight: bold;  width:345px;" valign="top">
                            <table border="1" class="item_list" 
                                style="width:345px; table-layout:fixed; border-collapse:collapse; border-bottom:0PX !IMPORTANT">
                                <tr>
                                    <td style="width:260px; border-bottom:0PX !important">
                                    Half Stitch <asp:CheckBox ID="chkHalfStitch" Enabled="false" runat="server"></asp:CheckBox>
                                    </td>
                                    <th style="width:80px; color:#98a9ca;">
                                        Rqd Qty (k)
                                    </th>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <div ID="dvFabricAccFinal" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="color: gray; font-weight: bold;  width:345px;" valign="top">
                            <table border="1" class="item_list" style="width:345px; table-layout:fixed;">   
                              <tr>
                                    <td style="width:260px">
                                    </td>
                                    <th style="width:80px; color:#98a9ca;">
                                        <span>ETA</span></th>
                                </tr>                        
                                <tr>
                                    <td style="width:260px">
                                    </td>
                                    <th style="width:80px; color:#98a9ca;">
                                        <span>In House (k)</span></th>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <th>
                                       <span>Average</span> </th>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <div ID="dvFabricAcc" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:GridView ID="grdProductionMatrix" runat="server" 
                                AutoGenerateColumns="false" cellpadding="0" CssClass="border2" 
                                DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="There is no Line Plan for this contract." 
                                onrowdatabound="grdProductionMatrix_RowDataBound" RowStyle-Font-Size="12px" 
                                ShowFooter="false" style="width:345px;" Width="100%">
                                <RowStyle CssClass="borderbottom" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="90px" 
                                        HeaderText="Cal. Date" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="90px">
                                        <ItemTemplate>
                                        <div style="text-align: left; padding-left:10px;" >
                                            <asp:Label ID="lblLinePlanningDate" runat="server" BorderColor="White" 
                                                CssClass="do-not-allow-typing" 
                                                Text='<%# Eval("LinePlanningDate", "{0:dd MMM (ddd)}")%>' Width="95%"></asp:Label>
                                                </div>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Act. Cal. Wrk. Hrs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                        <asp:Label ID="lblWorkingHrs" runat="server" Text='<%# Eval("WorkingHrs")%>'></asp:Label>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Add Hrs to Adjst" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                        <asp:Label ID="lblExtraHrs" runat="server" Text='<%# Eval("ExtraHrs")%>'></asp:Label>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>          
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Day Stitch" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDayStitch" CssClass="number-with-commas" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="70px" 
                                        HeaderText="Total Stitch" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalDayStitch" runat="server" CssClass="number-with-commas"
                                                Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                                       
                        </td>
                        <td align="left" valign="top">
                            <asp:GridView ID="grdFabricAccess" runat="server" AutoGenerateColumns="false" 
                                cellpadding="0" CssClass="border2" DataFormatString="{0:#,##}" 
                                DataKeyNames="TotalDayStitch" EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="" 
                                onrowdatabound="grdFabricAccess_RowDataBound" RowStyle-Font-Size="12px" 
                                ShowFooter="false" style="max-width:1800px;">
                                <RowStyle CssClass="borderbottom" />
                                
                                <Columns>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-left:20px; color:red;">
                        <asp:Button ID="btnRefresh" runat="server" CssClass="refresh" 
                                onclick="btnRefresh_Click" style="display:none;" Text="" />
                            <asp:Label ID="lblShowExtrahrs" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="2" style="padding-top:5px;">
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td valign="top">
                        <table id="tblLine1" runat="server" style="display:none;"  cellpadding="0" cellspacing="0">
                       <tr><td><table class="item_listLine" style="width:100%; border: 1px solid #000;" cellpadding="0" cellspacing="0">
                       <tr>
                       <td colspan="4">
                       <table cellpadding="0" cellspacing="0" style="width:100%;">
                       <tr>
                         <th style="width:33%" align="left">
                       Unit:&nbsp;&nbsp;<asp:Label ID="lblUnit1" runat="server" Text=""></asp:Label>
                       </th>                       
                       <th style="width:33%;" align="center">
                       <asp:Label ID="lblOperationName1" runat="server" Text=""></asp:Label>
                       </th>
                       <th style="width:33%;" align="right">St End:&nbsp;&nbsp;<asp:Label ID="lblSlot1" runat="server" Text=""></asp:Label></th>
                       </tr>
                       </table>
                       </td>
                     
                       </tr>
                       <tr>
                            <th width="25%" align="left">
                            Line No: &nbsp;&nbsp;&nbsp; <asp:Label ID="lblLineNo1" runat="server" Text=""></asp:Label> 
                            </th>                       
                        <th width="25%" align="center">
                            Line Qty:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineQty1" runat="server" Text=""></asp:Label></th>                          
                        <th width="25%" align="center">
                            Line SAM:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineSAM1" runat="server" Text=""></asp:Label></th>                        
                        <th width="25%" align="right">
                            Line OB: &nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineOB1" runat="server" Text=""></asp:Label></th>                      
                        </tr></table>
                        </td></tr>
                        <tr><td>
                             <asp:GridView ID="grdProductionMatrix_Line1" runat="server" 
                                AutoGenerateColumns="false" cellpadding="0" CssClass="border2" 
                                DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="There is no history for this contract." 
                                 RowStyle-Font-Size="12px" 
                                ShowFooter="false" style="width:455px;" Width="100%" onrowdatabound="grdProductionMatrix_Line1_RowDataBound">
                                <RowStyle CssClass="borderbottom Line1Row" />
                                <Columns>
                                   <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="90px" 
                                        HeaderText="Cal. Date" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="100px">
                                        <ItemTemplate>
                                         <div style="text-align: left; padding-left:10px;" >
                                            <asp:Label ID="lblLinePlanningDate" runat="server" BorderColor="White" CssClass="do-not-allow-typing" 
                                                Text='<%# Eval("LinePlanningDate", "{0:dd MMM (ddd)}")%>' Width="95%"></asp:Label>                                              
                                                <asp:HiddenField ID="hdnLinePlanningId" Value='<%# Eval("[LinePlanningId]")%>' runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnUnitId" Value='<%# Eval("[UnitId]")%>' runat="server"></asp:HiddenField>   
                                                <asp:HiddenField ID="hdnStitching" Value='<%# Eval("[Stitching]")%>' runat="server"></asp:HiddenField> 
                                                <asp:HiddenField ID="hdnLinePlanningDate" Value='<%# Eval("LinePlanningDate", "{0:MM/dd/yyyy}")%>' runat="server"></asp:HiddenField>                                               
                                                </div>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Act. Cal. Wrk. Hrs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Eval("DayWorkingHrs")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="60px" 
                                         ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                         <asp:DropDownList ID="ddlHrsAddHdr" onchange="OnChangeExtraHoursLine1(this)"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>       
                                        </HeaderTemplate>
                                        <ItemTemplate>                                        
                                                <asp:DropDownList ID="ddlHrsAdd" CssClass="clsddlHrsAdd1"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>                                                
                                                
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Days" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            Day <%# Eval("ProdDay")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Target Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTargetEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("TargetEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Actual Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("ActualEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Day Stitch" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDayStitch" CssClass="number-with-commas" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="70px" 
                                        HeaderText="Total Stitch" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalDayStitch" runat="server" CssClass="number-with-commas" 
                                                Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </td></tr>
                            <tr>
                        <td id="tdPeakEff1" style="display:none;" runat="server">
                            <table cellpadding="0" cellspacing="0" style="border:1px solid gray; width:455px">
                                <tr>
                                    <td colspan="8">
                                    <asp:HiddenField ID="hdnLine1" runat="server"></asp:HiddenField>
                                    <asp:HiddenField ID="hdnLinePlanningId1" runat="server"></asp:HiddenField>                                   
                                    <asp:HiddenField ID="hdnUnit1" runat="server"></asp:HiddenField>
                                        <asp:RadioButtonList ID="rbtnEff1" onchange="ChangerBtnEff1()" runat="server"                                              
                                            RepeatDirection="Horizontal" CssClass="hide-button">
                                            <asp:ListItem Selected="True" Text="Default Eff" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Peak Eff" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customize Peak Eff" Value="2" ></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:5px;">
                                        Peak Eff.</td>
                                    <td>
                                        <asp:TextBox ID="txtPeakEff1" runat="server" 
                                            CssClass="do-not-allow-typing" Enabled="false" Width="40px"></asp:TextBox>                                          
                                    </td>
                                    <td>
                                        Prod Day</td>
                                    <td>
                                        <asp:TextBox ID="txtProdDay1" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Peak Cap.</td>
                                    <td>  
                                     <asp:TextBox ID="txtPeakcap1" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>     
                                    </td>
                                    <td>
                                       Peak OB</td>
                                    <td>   
                                    <asp:TextBox ID="txtPeakOB1" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>

                                    </tr>   
                                    <tr>
                                    <td colspan="8" style="height:3px;">                                    
                                    </td>
                                    </tr>                                 
                                    <tr style="margin-top:10px;">
                                    <td style="padding-left:5px; display:none;">
                                        Custom.Eff.</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustomEff1" runat="server" 
                                            CssClass="numeric-field-without-decimal-places" MaxLength="3" Width="40px"></asp:TextBox>
                                    </td>
                                    <td colspan="2" style="display:none;">
                                        Custom.Prod Day</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustProdDay1" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right"  colspan="8"> 
                                        <asp:Button ID="btnSubmit1" runat="server" class="applyNew da_submit_button" 
                                            OnClientClick="javascript:return ValidatePeakCapecity1();" Text="Apply" 
                                            onclick="btnSubmit1_Click" />
                                    </td>
                                    </tr>                               
                            </table>
                        </td>
                    </tr></table>
                            </td>
                             <td> &nbsp; </td>
                            <td valign="top">
                           <table id="tblLine2" runat="server" style="display:none;" cellpadding="0" cellspacing="0">
                            <tr><td><table class="item_listLine" style="width:100%; border: 1px solid #000;" cellpadding="0" cellspacing="0">
                       <tr>                      
                       <td colspan="4">
                       <table cellpadding="0" cellspacing="0" style="width:100%;">
                       <tr>
                         <th style="width:33%" align="left">
                       Unit:&nbsp;&nbsp;<asp:Label ID="lblUnit2" runat="server" Text=""></asp:Label>
                       </th>                       
                       <th style="width:33%;" align="center">
                       <asp:Label ID="lblOperationName2" runat="server" Text=""></asp:Label>
                       </th>
                       <th style="width:33%;" align="right">St End:&nbsp;&nbsp;<asp:Label ID="lblSlot2" runat="server" Text=""></asp:Label></th>
                       </tr>
                       </table>
                       </td>
                       </tr>
                       <tr>
                            <th width="25%" align="left">
                            Line No: &nbsp;&nbsp;&nbsp; <asp:Label ID="lblLineNo2" runat="server" Text=""></asp:Label> 
                            </th>                       
                        <th width="25%">
                            Line Qty:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineQty2" runat="server" Text=""></asp:Label></th>                          
                        <th width="25%">
                            Line SAM:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineSAM2" runat="server" Text=""></asp:Label></th>                        
                        <th width="25%" align="right">
                            Line OB: &nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineOB2" runat="server" Text=""></asp:Label></th>                      
                        </tr></table>
                        </td></tr>
                        <tr><td valign="top">
                             <asp:GridView ID="grdProductionMatrix_Line2" runat="server" 
                                AutoGenerateColumns="false" cellpadding="0" CssClass="border2" 
                                DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="There is no history for this contract." 
                                 RowStyle-Font-Size="12px" 
                                ShowFooter="false" style="width:455px;" Width="100%" onrowdatabound="grdProductionMatrix_Line2_RowDataBound" 
                                >
                                <RowStyle CssClass="borderbottom Line2Row" />
                                <Columns>
                                   <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="90px" 
                                        HeaderText="Cal. Date" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="100px">
                                        <ItemTemplate>
                                         <div style="text-align: left; padding-left:10px;" >
                                            <asp:Label ID="lblLinePlanningDate" runat="server" BorderColor="White" CssClass="do-not-allow-typing"  
                                                Text='<%# Eval("LinePlanningDate", "{0:dd MMM (ddd)}")%>' Width="95%"></asp:Label>
                                                <asp:HiddenField ID="hdnLinePlanningId" Value='<%# Eval("[LinePlanningId]")%>' runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnUnitId" Value='<%# Eval("[UnitId]")%>' runat="server"></asp:HiddenField>   
                                                <asp:HiddenField ID="hdnStitching" Value='<%# Eval("[Stitching]")%>' runat="server"></asp:HiddenField> 
                                                <asp:HiddenField ID="hdnLinePlanningDate" Value='<%# Eval("LinePlanningDate", "{0:MM/dd/yyyy}")%>' runat="server"></asp:HiddenField>                                             
                                                </div>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Act. Cal. Wrk. Hrs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Eval("DayWorkingHrs")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="60px" 
                                         ItemStyle-HorizontalAlign="Center">
                                         <HeaderTemplate>
                                         <asp:DropDownList ID="ddlHrsAddHdr" onchange="OnChangeExtraHoursLine2(this)"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>       
                                        </HeaderTemplate>
                                        <ItemTemplate>                                           
                                             <asp:DropDownList ID="ddlHrsAdd" CssClass="clsddlHrsAdd2"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>     
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Days" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            Day <%# Eval("ProdDay")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Target Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTargetEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("TargetEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Actual Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("ActualEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Day Stitch" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDayStitch" CssClass="number-with-commas" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="70px" 
                                        HeaderText="Total Stitch" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalDayStitch" runat="server" CssClass="number-with-commas"
                                                Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </td></tr>
                            <tr>
                        <td id="tdPeakEff2" style="display:none;" runat="server">
                            <table cellpadding="0" cellspacing="0" style="border:1px solid gray; width:455px">
                                <tr>
                                    <td colspan="8">
                                    <asp:HiddenField ID="hdnLine2" runat="server"></asp:HiddenField>
                                     <asp:HiddenField ID="hdnLinePlanningId2" runat="server"></asp:HiddenField>          
                                    <asp:HiddenField ID="hdnUnit2" runat="server"></asp:HiddenField>
                                        <asp:RadioButtonList ID="rbtnEff2" onchange="ChangerBtnEff2()" runat="server"                                              
                                            RepeatDirection="Horizontal" CssClass="hide-button">
                                            <asp:ListItem Selected="True" Text="Default Eff" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Peak Eff" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customize Peak Eff" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:5px;">
                                        Peak Eff.</td>
                                    <td>
                                        <asp:TextBox ID="txtPeakEff2" runat="server" 
                                            CssClass="do-not-allow-typing" Enabled="false" Width="40px"></asp:TextBox>                                          
                                    </td>
                                    <td>
                                        Prod Day</td>
                                    <td>
                                        <asp:TextBox ID="txtProdDay2" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Peak Cap.</td>
                                    <td>  
                                     <asp:TextBox ID="txtPeakcap2" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>     
                                    </td>
                                    <td>
                                       Peak OB</td>
                                    <td>   
                                    <asp:TextBox ID="txtPeakOB2" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>
                                    </tr>
                                     <tr>
                                    <td colspan="8" style="height:3px;">                                    
                                    </td>
                                    </tr> 
                                    <tr>
                                    <td style="padding-left:5px; display:none;">
                                        Custom.Eff.</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustomEff2" runat="server" 
                                            CssClass="numeric-field-without-decimal-places" MaxLength="3" Width="40px"></asp:TextBox>
                                    </td>
                                    <td colspan="2" style="display:none;">
                                        Custom.Prod Day</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustProdDay2" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                                    </td>
                                    <td align="right"  colspan="8"> 
                                        <asp:Button ID="btnSubmit2" runat="server" class="applyNew da_submit_button" 
                                            OnClientClick="javascript:return ValidatePeakCapecity2();" Text="Apply" 
                                            onclick="btnSubmit2_Click" />
                                    </td>
                                     </tr>                                
                            </table>
                        </td>
                        </tr></table>
                            </td>
                            <td> &nbsp; </td>
                            <td valign="top">
                            <table id="tblLine3" runat="server" style="display:none;" cellpadding="0" cellspacing="0">
                            <tr><td><table class="item_listLine" style="width:100%; border: 1px solid #000;" cellpadding="0" cellspacing="0">
                       <tr>                    
                       <td colspan="4">
                       <table cellpadding="0" cellspacing="0" style="width:100%;">
                       <tr>
                         <th style="width:33%" align="left">
                       Unit:&nbsp;&nbsp;<asp:Label ID="lblUnit3" runat="server" Text=""></asp:Label>
                       </th>                       
                       <th style="width:33%;" align="center">
                       <asp:Label ID="lblOperationName3" runat="server" Text=""></asp:Label>
                       </th>
                       <th style="width:33%;" align="right">St End:&nbsp;&nbsp;<asp:Label ID="lblSlot3" runat="server" Text=""></asp:Label></th>
                       </tr>
                       </table>
                       </td>
                       </tr>
                       <tr>
                            <th width="25%" align="left">
                            Line No: &nbsp;&nbsp;&nbsp; <asp:Label ID="lblLineNo3" runat="server" Text=""></asp:Label> 
                            </th>                       
                        <th width="25%">
                            Line Qty:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineQty3" runat="server" Text=""></asp:Label></th>                          
                        <th width="25%">
                            Line SAM:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineSAM3" runat="server" Text=""></asp:Label></th>                        
                        <th width="25%" align="right">
                            Line OB: &nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineOB3" runat="server" Text=""></asp:Label></th>                      
                        </tr></table>
                        </td></tr>
                            <tr><td valign="top">
                             <asp:GridView ID="grdProductionMatrix_Line3" runat="server" 
                                AutoGenerateColumns="false" cellpadding="0" CssClass="border2" 
                                DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="There is no history for this contract." 
                                 RowStyle-Font-Size="12px" 
                                ShowFooter="false" style="width:455px;" Width="100%" onrowdatabound="grdProductionMatrix_Line3_RowDataBound"  
                                >
                                <RowStyle CssClass="borderbottom Line3Row" />
                                <Columns>
                                   <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="90px" 
                                        HeaderText="Cal. Date" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="100px">
                                        <ItemTemplate>
                                         <div style="text-align: left; padding-left:10px;" >
                                            <asp:Label ID="lblLinePlanningDate" runat="server" BorderColor="White" 
                                                CssClass="do-not-allow-typing" Text='<%# Eval("LinePlanningDate", "{0:dd MMM (ddd)}")%>' Width="95%"></asp:Label>
                                                <asp:HiddenField ID="hdnLinePlanningId" Value='<%# Eval("[LinePlanningId]")%>' runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnUnitId" Value='<%# Eval("[UnitId]")%>' runat="server"></asp:HiddenField>       
                                                <asp:HiddenField ID="hdnStitching" Value='<%# Eval("[Stitching]")%>' runat="server"></asp:HiddenField> 
                                                <asp:HiddenField ID="hdnLinePlanningDate" Value='<%# Eval("LinePlanningDate", "{0:MM/dd/yyyy}")%>' runat="server"></asp:HiddenField>                                         
                                                </div>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Act. Cal. Wrk. Hrs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Eval("DayWorkingHrs")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="60px" 
                                         ItemStyle-HorizontalAlign="Center">
                                         <HeaderTemplate>
                                         <asp:DropDownList ID="ddlHrsAddHdr" onchange="OnChangeExtraHoursLine3(this)"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>       
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                             <asp:DropDownList ID="ddlHrsAdd" CssClass="clsddlHrsAdd3"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>     
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Days" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            Day <%# Eval("ProdDay")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Target Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTargetEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("TargetEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Actual Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("ActualEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Day Stitch" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDayStitch" CssClass="number-with-commas" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="70px" 
                                        HeaderText="Total Stitch" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalDayStitch" runat="server" CssClass="number-with-commas" 
                                                Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                           </td></tr>
                            <tr>
                        <td id="tdPeakEff3" style="display:none;" runat="server">
                            <table cellpadding="0" cellspacing="0" style="border:1px solid gray; width:455px">
                                <tr>
                                    <td colspan="5">
                                    <asp:HiddenField ID="hdnLine3" runat="server"></asp:HiddenField>
                                    <asp:HiddenField ID="hdnLinePlanningId3" runat="server"></asp:HiddenField>          
                                    <asp:HiddenField ID="hdnUnit3" runat="server"></asp:HiddenField>
                                        <asp:RadioButtonList ID="rbtnEff3" onchange="ChangerBtnEff3()" runat="server"                                              
                                            RepeatDirection="Horizontal" CssClass="hide-button">
                                            <asp:ListItem Selected="True" Text="Default Eff" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Peak Eff" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customize Peak Eff" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                   <td style="padding-left:5px;">
                                        Peak Eff.</td>
                                    <td>
                                        <asp:TextBox ID="txtPeakEff3" runat="server" 
                                            CssClass="do-not-allow-typing" Enabled="false" Width="40px"></asp:TextBox>                                          
                                    </td>
                                    <td>
                                        Prod Day</td>
                                    <td>
                                        <asp:TextBox ID="txtProdDay3" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Peak Cap.</td>
                                    <td>  
                                     <asp:TextBox ID="txtPeakcap3" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>     
                                    </td>
                                    <td>
                                       Peak OB</td>
                                    <td>   
                                    <asp:TextBox ID="txtPeakOB3" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>
                                    </tr>
                                     <tr>
                                    <td colspan="8" style="height:3px;">                                    
                                    </td>
                                    </tr> 
                                    <tr>
                                    <td style="padding-left:5px; display:none;">
                                        Custom.Eff.</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustomEff3" runat="server" 
                                            CssClass="numeric-field-without-decimal-places" MaxLength="3" Width="40px"></asp:TextBox>
                                    </td>
                                    <td colspan="2" style="display:none;">
                                        Custom.Prod Day</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustProdDay3" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                                    </td>
                                    <td align="right"  colspan="8"> 
                                        <asp:Button ID="btnSubmit3" runat="server" class="applyNew da_submit_button" 
                                            OnClientClick="javascript:return ValidatePeakCapecity3();" Text="Apply" 
                                            onclick="btnSubmit3_Click" />
                                    </td>
                                     </tr>                                
                            </table>
                        </td>
                        </tr></table>
                            </td>
                             <td> &nbsp; </td>
                            <td valign="top">
                            <table id="tblLine4" runat="server" style="display:none;" cellpadding="0" cellspacing="0">
                            <tr><td><table class="item_listLine" style="width:100%; border: 1px solid #000;" cellpadding="0" cellspacing="0">
                       <tr>                     
                       <td colspan="4">
                       <table cellpadding="0" cellspacing="0" style="width:100%;">
                       <tr>
                         <th style="width:33%" align="left">
                       Unit:&nbsp;&nbsp;<asp:Label ID="lblUnit4" runat="server" Text=""></asp:Label>
                       </th>                       
                       <th style="width:33%;" align="center">
                       <asp:Label ID="lblOperationName4" runat="server" Text=""></asp:Label>
                       </th>
                       <th style="width:33%;" align="right">St End:&nbsp;&nbsp;<asp:Label ID="lblSlot4" runat="server" Text=""></asp:Label></th>
                       </tr>
                       </table>
                       </td>
                       </tr>
                       <tr>
                            <th width="25%" align="left">
                            Line No: &nbsp;&nbsp;&nbsp; <asp:Label ID="lblLineNo4" runat="server" Text=""></asp:Label> 
                            </th>                       
                        <th width="25%">
                            Line Qty:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineQty4" runat="server" Text=""></asp:Label></th>                          
                        <th width="25%">
                            Line SAM:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineSAM4" runat="server" Text=""></asp:Label></th>                        
                        <th width="25%" align="right">
                            Line OB: &nbsp;&nbsp;&nbsp;<asp:Label ID="lblLineOB4" runat="server" Text=""></asp:Label></th>                      
                        </tr></table>
                        </td></tr>       
                            <tr><td valign="top">
                             <asp:GridView ID="grdProductionMatrix_Line4" runat="server" 
                                AutoGenerateColumns="false" cellpadding="0" CssClass="border2" 
                                DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="There is no history for this contract." 
                                 RowStyle-Font-Size="12px" 
                                ShowFooter="false" style="width:455px;" Width="100%" onrowdatabound="grdProductionMatrix_Line4_RowDataBound" 
                                >
                                <RowStyle CssClass="borderbottom Line4Row" />
                                <Columns>
                                   <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="90px" 
                                        HeaderText="Cal. Date" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="100px">
                                        <ItemTemplate>
                                         <div style="text-align: left; padding-left:10px;" >
                                            <asp:Label ID="lblLinePlanningDate" runat="server" BorderColor="White" CssClass="do-not-allow-typing" 
                                                Text='<%# Eval("LinePlanningDate", "{0:dd MMM (ddd)}")%>' Width="95%"></asp:Label>
                                                <asp:HiddenField ID="hdnLinePlanningId" Value='<%# Eval("[LinePlanningId]")%>' runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnUnitId" Value='<%# Eval("[UnitId]")%>' runat="server"></asp:HiddenField>   
                                                <asp:HiddenField ID="hdnStitching" Value='<%# Eval("[Stitching]")%>' runat="server"></asp:HiddenField> 
                                                <asp:HiddenField ID="hdnLinePlanningDate" Value='<%# Eval("LinePlanningDate", "{0:MM/dd/yyyy}")%>' runat="server"></asp:HiddenField>                                            
                                                </div>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Act. Cal. Wrk. Hrs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Eval("DayWorkingHrs")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="60px" 
                                         ItemStyle-HorizontalAlign="Center">
                                          <HeaderTemplate>
                                         <asp:DropDownList ID="ddlHrsAddHdr" onchange="OnChangeExtraHoursLine4(this)"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>       
                                        </HeaderTemplate>
                                        <ItemTemplate>                                           
                                             <asp:DropDownList ID="ddlHrsAdd" CssClass="clsddlHrsAdd4"  Width="90%" runat="server">
                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="3.25" Value="3.25"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                </asp:DropDownList>     
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Days" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            Day <%# Eval("ProdDay")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="days-back" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Target Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTargetEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("TargetEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Actual Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("ActualEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Day Stitch" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDayStitch" CssClass="number-with-commas" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="70px" 
                                        HeaderText="Total Stitch" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalDayStitch" runat="server" CssClass="number-with-commas" 
                                                Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                           </td></tr>
                            <tr>
                        <td id="tdPeakEff4" style="display:none;" runat="server">
                            <table cellpadding="0" cellspacing="0" style="border:1px solid gray; width:455px">
                                <tr>
                                    <td colspan="5">
                                    <asp:HiddenField ID="hdnLine4" runat="server"></asp:HiddenField>
                                    <asp:HiddenField ID="hdnUnit4" runat="server"></asp:HiddenField>
                                     <asp:HiddenField ID="hdnLinePlanningId4" runat="server"></asp:HiddenField>
                                        <asp:RadioButtonList ID="rbtnEff4" onchange="ChangerBtnEff4()" runat="server"                                              
                                            RepeatDirection="Horizontal" CssClass="hide-button">
                                            <asp:ListItem Selected="True" Text="Default Eff" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Peak Eff" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customize Peak Eff" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:5px;">
                                        Peak Eff.</td>
                                    <td>
                                        <asp:TextBox ID="txtPeakEff4" runat="server" 
                                            CssClass="do-not-allow-typing" Enabled="false" Width="40px"></asp:TextBox>                                          
                                    </td>
                                    <td>
                                        Prod Day</td>
                                    <td>
                                        <asp:TextBox ID="txtProdDay4" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Peak Cap.</td>
                                    <td>  
                                     <asp:TextBox ID="txtPeakcap4" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>     
                                    </td>
                                    <td>
                                       Peak OB</td>
                                    <td>   
                                    <asp:TextBox ID="txtPeakOB4" runat="server" CssClass="do-not-allow-typing" 
                                            Enabled="false" Width="40px"></asp:TextBox>
                                    </td>
                                    </tr>
                                     <tr>
                                    <td colspan="8" style="height:3px;">                                    
                                    </td>
                                    </tr> 
                                    <tr>
                                    <td style="padding-left:5px; display:none;">
                                        Custom.Eff.</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustomEff4" runat="server" 
                                            CssClass="numeric-field-without-decimal-places" MaxLength="3" Width="40px"></asp:TextBox>
                                    </td>
                                    <td colspan="2" style="display:none;">
                                        Custom.Prod Day</td>
                                    <td style="display:none;">
                                        <asp:TextBox ID="txtCustProdDay4" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                                    </td>
                                    <td align="right"  colspan="8"> 
                                        <asp:Button ID="btnSubmit4" runat="server" class="applyNew da_submit_button" 
                                            OnClientClick="javascript:return ValidatePeakCapecity4();" Text="Apply" 
                                            onclick="btnSubmit4_Click" />
                                    </td>
                                     </tr>                                
                            </table>
                        </td>
                        </tr></table>
                            </td>
                            </tr>
                            
                            </table>
                            </td>
                    </tr>
                    <tr><td colspan="2"> &nbsp;</td></tr>
                    </table>
                    <table width="97%" cellpadding="0" cellspacing="0">      
                    <tr>
                        <td style="padding-bottom: 5px;">
                         <div style="float:left; width:auto; margin-left:5px;">   <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" 
                                OnClientClick="javascript:self.parent.Shadowbox.close();" Width="86px" Text="Close" /></div>
                         <div style="float:right; width:auto; margin-right:5px;">   <asp:Button ID="btnClose2" runat="server" CssClass="close da_submit_button" 
                                OnClientClick="javascript:self.parent.Shadowbox.close();" Width="86px" Text="Close" /></div>
                        </td>
                    </tr>
                </table>              
 
    </div> 
     </ContentTemplate>
      <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRefresh" EventName="Click" />
                </Triggers>
  </asp:updatepanel>
  
</div>
    </form>
</body>
</html>
