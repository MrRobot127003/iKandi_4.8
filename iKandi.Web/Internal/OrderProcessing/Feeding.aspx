<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feeding.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.Feeding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>--%>
<script src="../../js/jquery-1.4.4.min.js" type="text/javascript"></script>
<script src="../../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
<script src="../AspxPageJS/Feeding.js" type="text/javascript"></script>
<script src="../../js/service.min.js" type="text/javascript"></script>
<script src="../../js/form.js" type="text/javascript"></script>

<script src="../../js/date.js" type="text/javascript"></script>
<script src="../../js/colorpicker.js" type="text/javascript"></script>
<%--<script src="../../js/jquery.datePicker.js" type="text/javascript"></script>--%>
<%--<script src="../../js/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>--%>
<head id="Head1" runat="server">
<title></title>
<style type="text/css">
.ui-datepicker select.ui-datepicker-year { width: 0% !important;}
.ui-datepicker table {width: 100%; font-size: .5em !important; border-collapse: collapse; margin:0 0 .4em; }
.ui-datepicker { padding: .2em .2em 0; }
.ui-widget { font-family: Verdana,Arial,sans-serif/*{ffDefault}*/; font-size: .9em !important; }
.ui-datepicker td span, .ui-datepicker td a { display: block; padding: .2em; text-align: center !important; text-decoration: none; }

.container{width:1960px; margin:0 auto; font-family:Verdana, Arial, Helvetica, sans-serif; font-size:12px;}
.box{float:left; background-color:#3759a1; line-height:20px; color:#FFFFFF;}
.feeding{width:100%; float:left; text-align:center; line-height:20px; font-weight:bold;}
.fabric{width:110px; float:left; font-size:10px; line-height:15px;}
.borderrightcollapse{border-right:1px solid #000000; border-collapse: collapse;}
.borderrightnone{border-right:none;}
.target{font-weight:bold; color:#909090; border-right:none; height:20px;}
.div1{width:230px; float:left; font-size:10px; line-height:15px;}
.Redclr{background-color:#ff3300; font-size:11px; border-right:none;}
.Greenclr{background-color:#00ff71; font-size:11px; border-right:none;}

.backgroundborderight{background-color:#dfdfdd; border-right:1px solid #cccccc;}
.bordercollapseright{border-collapse: collapse; border-right:none;}
.clrbackgroundbrdr{color:Red; background-color:#f9f9fb; border-right:1px solid #cccccc;}
.clrbackground{color:Red; background-color:#f9f9fb;}
.clrbackgroundbrdrleft{color:Red; background-color:#f9f9fb; border-left:1px solid #cccccc;}
.brdrcollrighleft{border-collapse:collapse; border-right:none; border-left:1px solid #cccccc;}
.clrfontbrdright{color:#909090; font-size:11px; border-right:none;}
.clrfontele{color:#909090; font-size:11px;}
.clrfont{color:#000000; font-size:9px;}
.borderleftright{border-left:1px solid #cccccc; border-right:1px solid #cccccc;}
.backgroundbrdrleftright{background-color:#dfdfdd; border-left:1px solid #cccccc; border-right:1px solid #cccccc;}
.clrbackgroundbrdrleftright{color:Red; background-color:#f9f9fb; border-left:1px solid #cccccc; border-right:1px solid #cccccc;}
.backgroundclr{background-color:#ececec;}
.brdrleft{border-left:1px solid #cccccc;}
.brdrcollleft{border-collapse:collapse; border-left:1px solid #cccccc;}
.Orangeclr{background-color:#fd9903; font-size:11px; border-right:none;}
</style>
</head>
<body onload="Feeding_Report()">
 <script type="text/javascript" >
     var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
     var isload = false;
     //debugger;
     //     window.onload = function () { // code supposed to run once DOM is loaded
     //         alert("onload event is fired");
     //       };



     function CheckAll() {
         //debugger;
         /*
         var check = 'false';
         var frm = document.forms[0];
         for (i = 0; i < frm.elements.length; i++) {

         if (frm.elements[i].type == "checkbox") {
         if (frm.elements[i].checked) {
         check = 'true';
         }
         }
         }
         if (check == 'false') {
         alert('Please Select at least one');
         return false;
         }
         */
     }

     //     $('input.date-picker', '.container').datepicker({ changeYear: true, yearRange: '1900:202', dateFormat: 'dd/mm y', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });

     function UpdateManageOrder() {
         //debugger;
         window.opener.UpdatePageForSale();
     }
    </script>
<form id="form1" class="form1" runat="server">
<div class="container">
       <div class="box">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="110px">&nbsp;</td>
        <td width="460px" align="center" colspan="2">Fabric</td>
        <td width="230px" align="center">Accessories</td>
        <td width="460px" align="center" colspan="2">Fits</td>
        <td width="230px" align="center">QA</td>
        <td width="460px" align="center" colspan="2">Production</td>
      </tr>
    </table>
       </div>
       <div class="feeding">Feeding Achievements As On <asp:Label ID="lbldate" class="lbldate" runat="server" ></asp:Label></div>
    <div class="fabric">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="borderrightcollapse">
       <tr>
       <td width="20%" height="32px" class="borderrightnone">&nbsp;</td>
         </tr>
    <tr>
       <td width="25%" height="30px" class="borderrightnone">&nbsp;</td>
         </tr>
    <tr>
       <td width="35%" class="target">Target</td>
         </tr>
    <tr>
       <td width="20%" class="target">Actual</td>
         </tr>
    <tr>
       <td width="20%" class="target">Delay</td>
         </tr>
       </table>
       </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="APP" style="border-left:1px solid #ffffff;">Initial Approval<br /><span style="font-size:9px;">(<asp:Label ID="Label114" class="lblAPP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-left:1px solid #ffffff; border-right:1px solid #cccccc;">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright"><input type="checkbox"  class="chbapptarget" name="checkMeOut" id="Checkbox19"  />
        <asp:Label ID="Label55" class="lblapptarmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label56" class="lblappqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft" height="20px"><asp:Label ID="Label57" class="lblapprev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright"><input type="checkbox"  class="chbappacttarget" name="checkMeOut" id="Checkbox20"  />
        <asp:Label ID="Label58" class="lblappactmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label59" class="lblappactqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft" height="20px"><asp:Label ID="Label60" class="lblappactrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright"><input type="checkbox"  class="chbappdeltarget" name="checkMeOut" id="Checkbox21"  />
        <asp:Label ID="Label61" class="lblappdelmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label62" class="lblappdelqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft" height="20px"><asp:Label ID="Label63" class="lblappdelrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="brdrcollrighleft">
       <tr>
       <td align="center" colspan="3" height="32px" class="FabBIH">BIH<br /><span class="clrfont">(<asp:Label ID="Label82" class="lblFabBIH" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="20px" class="borderleftright">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbfabbihtarget" name="checkMeOut" id="chbfabbihtarget"  />
        <asp:Label ID="Label46" class="lblfabtarmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label47" class="lblfabqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label48" class="lblfabrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbfabbihactual" name="checkMeOut" id="chbfabbihactual"  />
        <asp:Label ID="Label49" class="lblfabavlmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label50" class="lblfabactqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label51" class="lblfabactrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbfabbihdelay" name="checkMeOut" id="chbfabbihdelay"  />
        <asp:Label ID="Label52" class="lblfabdelmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label53" class="lblfabdelqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label54" class="lblfabdelrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" style="border-collapse:collapse; border-right:none;">
       <tr>
       <td align="center" colspan="3" height="32px" class="BIH"  style="border-left:1px solid #ffffff;">BIH<br /><span class="clrfont">(<asp:Label ID="Label77" class="lblBIH" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbaccbihtarget" name="checkMeOut" id="chbaccbihtarget"  />
        <asp:Label ID="Label37" class="lblacctarmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label38" class="lblaccqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label39" class="lblaccrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbaccbihactual" name="checkMeOut" id="chbaccbihactual"  />
        <asp:Label ID="Label40" class="lblaccavlmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label41" class="lblaccactqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label42" class="lblaccactrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbaccbihdelay" name="checkMeOut" id="chbaccbihdelay"  />
        <asp:Label ID="Label43" class="lblaccdelmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label44" class="lblaccdelqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label45" class="lblaccdelrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="STC"  style="border-left:1px solid #ffffff;">STC<br /><span style="font-size:9px;">(<asp:Label ID="Label111" class="lblSTC" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbstctarget" name="checkMeOut" id="Checkbox10"  />
        <asp:Label ID="Label28" class="lblstctargetmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label29" class="lblstctargetqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label30" class="lblstctargetrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbstcactual" name="checkMeOut" id="Checkbox11"  />
        <asp:Label ID="Label31" class="lblstcactualmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label32" class="lblstcactqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label33" class="lblstcactrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbstcdelay" name="checkMeOut" id="Checkbox12"  />
        <asp:Label ID="Label34" class="lblstcdelaymin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label35" class="lblstcdelqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label36" class="lblstcdelrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="brdrcollrighleft">
       <tr>
       <td align="center" colspan="3" height="32px" class="PRO">Production HandOver<br /><span class="clrfont">(<asp:Label ID="Label112" class="lblPRO" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="20px" class="borderleftright">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbprotarget" name="checkMeOut" id="Checkbox7"  />
        <asp:Label ID="Label19" class="lblprotarmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label20" class="lblproqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label21" class="lblprorev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbproactual" name="checkMeOut" id="Checkbox8"  />
        <asp:Label ID="Label22" class="lblproactmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label23" class="lblproactqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label24" class="lblproactrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbprodelay" name="checkMeOut" id="Checkbox9"  />
        <asp:Label ID="Label25" class="lblprodelmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label26" class="lblprodelqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label27" class="lblprodelrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="TOP"  style="border-left:1px solid #ffffff;">TOP<br /><span class="clrfont">(<asp:Label ID="Label110" class="lblTOP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbtoptarget" name="checkMeOut" id="Checkbox4"  />
        <asp:Label ID="Label10" class="lbltoptargetmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label11" class="lbltoptargetqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label12" class="lbltoptargetrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbtopactual" name="checkMeOut" id="Checkbox5"  />
        <asp:Label ID="Label13" class="lbltopactualmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label14" class="lbltopactualqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label15" class="lbltopactualrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbtopdelay" name="checkMeOut" id="Checkbox6"  />
        <asp:Label ID="Label16" class="lbltopdelaymin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label17" class="lbltopdelayqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label18" class="lbltopdelayrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="PCD"  style="border-left:1px solid #ffffff;">PCD<br /><span style="font-size:9px;">(<asp:Label ID="Label75" class="lblPCD" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="35%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="20%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="20%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
      <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
         <input type="checkbox"  class="chbpcdtarget" name="checkMeOut" id="chbpcdtarget"  />
        <asp:Label ID="Label1" class="lblpcdtarmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label2" class="lblpcdqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label3" class="lblpcdrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbpcdactual" name="checkMeOut" id="chbpcdactual"  />
        <asp:Label ID="Label4" class="lblpcdavlmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label5" class="lblpcdactqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label6" class="lblpcdactrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbpcddelay" name="checkMeOut" id="chbpcddelay"  />

        <asp:Label ID="Label7" class="lblpcddelmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label8" class="lblpcddelqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label9" class="lblpcddelrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="brdrcollleft">
       <tr>
       <td align="center" colspan="3" height="32px" class="Ex">Ex Factory<br /><span class="clrfont">(<asp:Label ID="Label73" class="lblEx" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="20px" class="borderleftright">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbextarget" name="checkMeOut" id="chbextarget"  />
        <asp:Label ID="lblextarmin" class="lblextarmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="lblexqty" class="lblexqty" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="lblexrev" class="lblexrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbexactual" name="checkMeOut" id="chbexactual"  />
        <asp:Label ID="lblexavlmin" class="lblexavlmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="lblexactqty" class="lblexactqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="lblexactrev" class="lblexactrev" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="clrbackgroundbrdrleftright" height="20px">
        <input type="checkbox" value="1" class="chbexdelay" name="checkMeOut" id="Checkbox36"  />
        <asp:Label ID="lblexdelmin" class="lblexdelmin" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="lblexdelqty" class="lblexdelqty" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="lblexdelrev" class="lblexdelrev" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>

    <div style="float:left; width:350px; padding-right:14px; padding-top:20px;"><span class="clssubmit" style="width: 100%; background-color: #3759A1; padding: 3px; border: 1px solid #000000; text-align: center; color: white; cursor:pointer;">SUBMIT</span></div>
        
</div>
   

    <div class="container">
       
       <div class="feeding"> 
        Upcoming Feeding Achievements Between&nbsp; <asp:Label ID="lbldatefrom" class="lbldate" runat="server" ></asp:Label> TO 
       &nbsp; <asp:Label ID="Label102"  runat="server" CssClass="lbldateto date-picker" ></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="date-picker txttodate"></asp:TextBox>
        
        </div>
    <div class="fabric">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="borderrightcollapse">
       <tr>
       <td width="25%" height="32px" class="borderrightnone">&nbsp;</td>
         </tr>
    <tr>
       <td width="25%" height="30px" class="borderrightnone">&nbsp;</td>
         </tr>
    <tr>
       <td width="50%" class="target">Upcoming Target</td>
         </tr>
    <tr>
       <td width="50%" class="target">UpcomingAchived</td>
         </tr>
    <tr>
       <td width="40%" class="target">% Achived</td>
         </tr>
       </table>
       </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="AppUP" style="border-left:1px solid #ffffff;">Initial Approval<br /><span style="font-size:9px;">(<asp:Label ID="Label115" class="lblAPPUP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright"><input type="checkbox"  class="chbapptargetUP" name="checkMeOut" id="Checkbox22"  />
        <asp:Label ID="Label64" class="lblapptarminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label65" class="lblappqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft" height="20px"><asp:Label ID="Label66" class="lblapprevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright"><input type="checkbox"  class="chbappacttargetUP" name="checkMeOut" id="Checkbox23"  />
        <asp:Label ID="Label67" class="lblappactminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label68" class="lblappactqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft" height="20px"><asp:Label ID="Label69" class="lblappactrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="Label70" class="lblAPPUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label71" class="lblappachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft" height="20px"><asp:Label ID="Label72" class="lblappachdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="brdrcollrighleft">
       <tr>
       <td align="center" colspan="3" height="32px" class="FabBIHUP">BIH<br /><span class="clrfont">(<asp:Label ID="Label83" class="lblfabBIHUP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="20px" class="borderleftright">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbfabbihtarget" name="checkMeOut" id="Checkbox2"  />
        <asp:Label ID="lblfabtarminUP" class="lblfabtarminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="lblfabqtyUP" class="lblfabqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="lblfabrevUP" class="lblfabrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbfabbihactual" name="checkMeOut" id="Checkbox3"  />
        <asp:Label ID="lblfabavlminUP" class="lblfabavlminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="lblfabactqtyUP" class="lblfabactqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="lblfabactrevUP" class="lblfabactrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="Label79" class="lblfabBIHUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label80" class="lblfabachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label81" class="lblfabachdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" style="border-collapse:collapse; border-right:none;">
       <tr>
       <td align="center" colspan="3" height="32px" class="BIHUP" style="border-left:1px solid #ffffff;">BIH<br /><span class="clrfont">(<asp:Label ID="Label78" class="lblaccUP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbaccbihtargetUP" name="checkMeOut" id="chbaccbihtargetUP"  />
        <asp:Label ID="lblacctarminUP" class="lblacctarminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="lblaccqtyUP" class="lblaccqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="lblaccrevUP" class="lblaccrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbaccbihactual" name="checkMeOut" id="Checkbox1"  />
        <asp:Label ID="lblaccavlminUP" class="lblaccavlminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="lblaccactqtyUP" class="lblaccactqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="lblaccactrevUP" class="lblaccactrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="Label88" class="lblaccUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label89" class="lblaccachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label90" class="lblaccachdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="StcUP" style="border-left:1px solid #ffffff;">STC<br /><span style="font-size:9px;">(<asp:Label ID="Label109" class="lblstcUP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
     <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbstctargetUP" name="checkMeOut" id="Checkbox13"  />
        <asp:Label ID="Label84" class="lblstctargetminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label85" class="lblstctargetqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label86" class="lblstctargetrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbstcactualUP" name="checkMeOut" id="Checkbox14"  />
        <asp:Label ID="Label87" class="lblstcactualminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label91" class="lblstcactqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label92" class="lblstcactrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="Label93" class="lblstcUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label94" class="lblstcachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label95" class="lblstcachdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="brdrcollrighleft">
       <tr>
       <td align="center" colspan="3" height="32px" class="PROUP">Production HandOver<br /><span class="clrfont">(<asp:Label ID="Label113" class="lblproUP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="20px" class="borderleftright">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbprotargetUP" name="checkMeOut" id="Checkbox15"  />
        <asp:Label ID="Label100" class="lblprotarminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label101" class="lblproqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label211" class="lblprorevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbproactualUP" name="checkMeOut" id="Checkbox18"  />
        <asp:Label ID="Label22a" class="lblproachminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label231" class="lblproactqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label241" class="lblproactrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="Label25a" class="lblproUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label261" class="lblproachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label271" class="lblproachdRevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>
    <div class="div1" style="border-right: 1px solid black;">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="TopUP" style="border-left:1px solid #ffffff;">TOP<br /><span class="clrfont">(<asp:Label ID="Label108" class="lbltopUP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
   <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbtoptargetUP" name="checkMeOut" id="Checkbox16"  />
        <asp:Label ID="Label96" class="lbltoptargetminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="Label97" class="lbltoptargetqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="Label98" class="lbltoptargetrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbtopactualUP" name="checkMeOut" id="Checkbox17"  />
        <asp:Label ID="Label99" class="lbltopactualminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="Label103" class="lbltopactualqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="Label104" class="lbltopactualrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="Label105" class="lbltopUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label106" class="lbltopachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label107" class="lbltopachdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="bordercollapseright">
       <tr>
       <td align="center" colspan="3" height="32px" class="PCDUP" style="border-left:1px solid #ffffff;">PCD<br /><span style="font-size:9px;">(<asp:Label ID="Label76" class="lblpcdUP" runat="server" Text="0"></asp:Label>  % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="30px" style="border-right:1px solid #cccccc; border-left:1px solid #ffffff; ">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
      <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbpcdtargetUP" name="checkMeOut" id="chbpcdtargetUP"  />
        <asp:Label ID="lblpcdtarminUP" class="lblpcdtarminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="lblpcdqtyUP" class="lblpcdqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="lblpcdrevUP" class="lblpcdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px"><input type="checkbox"  class="chbpcdactualUP" name="checkMeOut" id="chbpcdactualUP"  />
        <asp:Label ID="lblpcdavlminUP" class="lblpcdavlminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="lblpcdactqtyUP" class="lblpcdactqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="lblpcdactrevUP" class="lblpcdactrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="Label7b" class="lblpcdUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="Label8b" class="lblpcdachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="Label9b" class="lblpcdachdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>

    </div>
    <div class="div1">
    <table width="100%" border="1" cellspacing="0" cellpadding="0" class="brdrcollleft">
       <tr>
       <td align="center" colspan="3" height="32px" class="ExUP">Ex Factory<br /><span class="clrfont">(<asp:Label ID="Label74" class="lblexUP" runat="server" Text="0"></asp:Label> % Achieved)</span></td>
       </tr>
    <tr>
       <td width="40%" align="center" height="20px" class="borderleftright">Minutes<br /><span style="font-size:8px;">(Lakh)</span></td>
        <td width="35%" align="center">Qty<br /><span style="font-size:8px;">(K)</span></td>
        <td width="15%"align="center" class="brdrleft">Revenue<br /><span style="font-size:8px;">(CR)</span></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbextargetUP" name="checkMeOut" id="chbextargetUP"  />
        <asp:Label ID="lblextarminUP" class="lblextarminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr">
            <asp:Label ID="lblexqtyUP" class="lblexqtyUP" runat="server" Text="0"></asp:Label>
             </td>
        <td align="center" class="brdrleft"><asp:Label ID="lblexrevUP" class="lblexrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="left" class="backgroundbrdrleftright" height="20px">
        <input type="checkbox"  class="chbexactualUP" name="checkMeOut" id="chbexactualUP"  />
        <asp:Label ID="lblexavlminUP" class="lblexavlminUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="backgroundclr"><asp:Label ID="lblexactqtyUP" class="lblexactqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="brdrleft"><asp:Label ID="lblexactrevUP" class="lblexactrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
    <tr>
       <td align="center" class="clrbackgroundbrdrleftright" height="20px">
        <asp:Label ID="lblexdelminb" class="lblexUP" runat="server" Text="0"></asp:Label>
        </td>
        <td align="center" class="clrbackground"><asp:Label ID="lblexdelqtyb" class="lblexachdqtyUP" runat="server" Text="0"></asp:Label></td>
        <td align="center" class="clrbackgroundbrdrleft"><asp:Label ID="lblexdelrevb" class="lblexachdrevUP" runat="server" Text="0"></asp:Label></td>
       </tr>
       </table>
    </div>

    <div style="float:left; width:360px; padding-top:20px;">
     <span class="clssubmitUP" style="width: 100%; background-color: #3759A1; padding: 3px; border: 1px solid #000000; text-align: center; color: white; cursor:pointer;">SUBMIT</span>
       <span class="closepopup" style="width: 100%; background-color: #3759A1; padding: 3px; border: 1px solid #000000; text-align: center; color: white; margin-left:10px; cursor:pointer;">ClOSE </span>
    
    </div>
   
</div>
    
    </form>
</body>
</html>




