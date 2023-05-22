<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="FactoryorderA.aspx.cs" Inherits="iKandi.Web.Internal.Sales.FactoryorderA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
body{font-family:Arial; font-size:11px; color:#888888; margin:0 auto; background-color:#f4f4f5;}
.secure_center_contentWrapper{text-transform:capitalize !important; font-family:Arial !important;}
.container .fabricone{width:800px;}
.container .fabrictwo{width:1195px;}
.container .fabricthree{width:1593px;}
.container .fabricfour{width:1990px;}

.container .accessone{width:950px;}
.container .accesstwo{width:1290px;}
.container .accessthree{width:1630px;}
.container .accessfour{width:1970px;}
.container .accessfive{width:2200px;}

.container .dropdown
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:130px;
        }
.container .depart_dropdown
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:100px;
        }
.container .dropdownmt
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:50px;
        }
.container .dropdownsuplrname
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:80px;
        }
.container .textbox
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:127px; color:#2d00ee; text-align:right; padding-right:2px;
        }
.container .textbox2
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:97px; color:#2d00ee; text-align:right; padding-right:2px;
        }
.container .textbox3
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:100px; color:#2d00ee; text-align:center; padding-right:2px;
        }
.container .textbox4
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:60px; color:#2d00ee; text-align:center; padding-right:2px;
        }
.container .textbox5
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:40px; color:#2d00ee; text-align:center; padding-right:2px; font-weight:bold;
        }
.container .textbox6
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:50px; color:#2d00ee; text-align:right; padding-right:2px; font-weight:bold;
        }
.container .textbox7
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:20px; color:#2d00ee; text-align:center; padding-right:2px;
        }
.container .textbox8
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:120px; color:#2d00ee; text-align:center; padding-right:2px;
        }
.container .textbox9
        {
            background:#f4f4f6; border:1px solid #c3c3c3; text-transform:capitalize !important; width:40px; color:#2d00ee; text-align:center; padding-right:2px;
        }
.container .bordertop{border:1px solid #000000; border-top:none;}
.container .borderbottom{border:1px solid #000000; border-bottom:none;}
.container .borderbottomtop{border:1px solid #000000; border-bottom:none; border-top:none;}
.container .borderbotdotted{border-bottom:2px dotted #e6e6e6;}
.container .borleftnon{border-left:none;}
.container .bortoprighleftnon{border-left:none; border-top:none; border-right:none;}
.container .bortoprighbotnon{border-top:none; border-bottom:none; border-right:none;}
.container .bortopleftbotnon{border-top:none; border-bottom:none; border-left:none;}
.container .bortopnon{border-top:none;}
.container .borleftbotnon{border-left:none; border-bottom:none;}
.container .borrightbotnon{border-right:none; border-bottom:none;}
.container .bortopleftnon{border-left:none; border-top:none;}
.container{width:1850px; float:left; padding:10px;}
.container .fontblack{color:#000000; font-size:12px;}
.container .colboltextcentergreen{color:#00a348; text-align:center;}
.container .lightbgcolor{background-color:#f4f4f5;}
.container .bordernon{border:none;}
.container .borderrightnone{border-right:none;}
.container .borderbottomnone{border-bottom:none;}
.container .fontred{color:#ff3300 !important;}
.container .fontgreen{color:#00a348 !important;}
.container .bordertoprightnon{border-top:none;border-right: none;}
.headerblue{background-color:#39589c; height:15px; padding:5px; color:#ffffff; font-size:14px; font-weight:bold;}
.titleheading{width:100%; float:left; font-size:24px; font-weight:bold; color:#000000;} 
.fullwidfloat{width:100%; float:left; padding-top:5px;}
.fullwidfloat_Fabric{width:auto; float:left; padding-top:6px;}
.fullwidfloat_access{width:auto; float:left;}
.halfwidfloat2{width:50%; float:left;}
.basicinfo table{border-collapse:collapse;}
.basicinfo th{background-color:#39589c; height:30px; padding:0px 5px; color:#ffffff; font-size:14px; font-weight:bold;}
.basicinfo td{border:1px solid #e6e6e6; border-collapse:collapse; height:29px;}
.borderright{border-right:1px solid #e6e6e6;}
.picture th{background-color:#f4f4f6; height:30px; padding:0px 5px; color:#ffffff; font-size:14px; font-weight:bold;}
.inputblue{color:#2d00ee;}
.inputdarkgrey{color:#666666;}
.basicinfo2 table{border-collapse:collapse;}
.basicinfo2 td{border:none; border-collapse:collapse; height:29px;}
.fabriccontract table{border-collapse:collapse;}
.fabriccontract th{background-color:#39589c; height:30px; padding:0px 5px; color:#ffffff; font-size:14px; font-weight:bold;}
.fabriccontract td{border:1px solid #e6e6e6; border-collapse:collapse; line-height:20px;}
.fabriccontract .suppliername{color:#2d00ee !important; padding-left:2px;}
.fabriccontract1 .bordercollapse .avgmt{border-right:none; border-top:none; border-bottom: 2px dotted #e6e6e6;}
.fabriccontract1 .bordercollapse .rateborder{border-bottom:2px dotted #e6e6e6;}
.fabriccontract1 .contract3 td{ border-collapse:collapse; height:20px; border:none;}
.click{color:#2d00ee; text-decoration:underline;}
.click:hover{color:#2d00ee; text-decoration:underline;}
.subheading{color:#000000; font-size:12px; font-weight:normal;}
.bordercollapse{border-collapse:collapse;}
.fonttwelve{font-size:12px;}
.fonttwelveblack{font-size:12px; color:#000000;}
.fabriccontract1{width:384px; float:left; border:1px solid #666666;}
.contractname{float:left; padding-left:3px; color:#2d00ee;}
.contract2{font-size:10px; padding-top:2px; padding-left:5px; color:#000000;}
.contractwid{float:right; font-size:10px; padding-top:2px; padding-right:3px;}
.bordercollapse .borbottop{border-bottom:2px dotted #e6e6e6; border-top:none; border-right:none;}
.bordercollapse .borbottopright{border-bottom:2px dotted #e6e6e6; border-top: none; border-left:none; border-right:none;}
.bordercollapse .borbottoplefrigcol{border-bottom:2px dotted #e6e6e6; border-top: none; border-left:none; border-right:none; color:#666666;}
.bordercollapse .borbotleftcol{border-bottom:none; border-left:none; border-right:none; color:#666666;}
.bordercollapse .borbotleftcol2{border-bottom:none; border-left:none; border-right:none; color:#00a348;}
.bordercollapse .borbotrightcol{border-bottom:none; border-left:none; border-right:none; color:#666666;}
.bordercollapse .borbotcol{border-bottom:none; color:#666666;}
.bordercollapse .borbottopleft{border-left: none;border-top: none;}
.bordercollapse .borbotleftnone{border-bottom:none; border-left:none;}
.bordercollapse .borbotlefttopcol{border-bottom:2px dotted #e6e6e6; border-left: none; border-top:none; color:#666666;}
.bordercollapse .borleftbotcol{border-left: none; border-bottom: none; color:#666666;}
.bordercollapse .borbotnone{border-bottom: none; border-left:none;}
.bordercollapse .borbotrightnone{border-bottom: none; border-right:none; border-left:none;}
.borbottop{border-bottom:2px dotted #e6e6e6; border-top:none;}
.borbottopright{border-bottom:2px dotted #e6e6e6; border-top: none;  border-right:none;}
.borbotnone{border-bottom: none;}
.borbottopright{border-bottom:2px dotted #e6e6e6; border-top: none;  border-left:none;}
.borbotleftnone{border-bottom:none; border-left:none;}
.borbottoplefrigcol{border-bottom:2px dotted #e6e6e6; border-top: none; border-left:none; border-right:none; color:#666666;}
.fontsizenine{font-size:9px;}
.borbotleftcol{border-bottom:none; border-left:none; color:#666666;}
.borbotrightcol{border-bottom:none; border-right:none; color:#666666;}
.borbotlefttopcol{border-bottom:2px dotted #e6e6e6; border-left: none; border-top:none; color:#666666;}
.fontnincol{font-size:9px; color:#666666;}
.colfontbold{color:#666666; font-weight:bold;}
.colboltextcenter{color:#666666; font-weight:bold; text-align:center;}
.colboltextcenterunbold{color:#666666; text-align:center;}
.colboltextcentergreen{color:#00a348; text-align:center;}
.colboltextcentergreenbold{color:#00a348; font-weight:bold; text-align:center;}
.option_colboltextcentergreenbold{color:#00a348; font-weight:bold; text-align:right;}
.option_colboltextcenterredbold{color:#ff3300; font-weight:bold; text-align:right;}
.borcol{border-collapse:collapse; color:#666666;}
.borbotcol{border-bottom:none; color:#666666;}
.borleftbotcol{border-left: none; border-bottom: none; color:#666666;}
.borcol .bornonewid{border:none;width: 190px;}
.borcol .colborrigfont{color:#2d00ee; border-right:none; border:none; font-weight:bold;}
.borcol .borleftwid{border:none; border-left:1px solid #e6e6e6;width: 139px;}
.borcol .borrightnone{border-right:none; border-bottom:none;}
.borcol .colborrigleft{color:#2d00ee; border-right:1px solid #e6e6e6; border-left:none; border-bottom:none;}
.borcol .colborrinoneleft{color:#2d00ee; border-right:none; border-left:none; border-bottom:none;}
.borcol .colleftright{color:#2d00ee; border-left:none; border-right:none; border-bottom:none;}
.container .borrightnone{border-right:none;}
.container .bortoprightnone{border-right:none; border-top:none;}
.colborrigleft{color:#2d00ee; border-right:1px solid #e6e6e6; border-left:none;}
.colborrinoneleft{color:#2d00ee; border-right:none; border-left:none;}
.colleftright{color:#2d00ee; border-left:none; border-right:none;}
.colfontelev{color:#666666; font-size:11px;}
.colfontbold{color:#666666; font-size:11px; font-weight:bold;}
.accessories table{border-collapse:collapse;}
.accessories th{background-color:#39589c; height:30px; padding:0px 5px; color:#ffffff; font-size:14px; font-weight:bold;}
.accessories td{border:1px solid #e6e6e6; border-collapse:collapse;}
.accessories .bordernone{border:none;}
.accessories .colborrigfont{color:#2d00ee; border-right:none; border:none; font-weight:bold;}
.accessories .rate{border-right: none; height:37px;}
.cutwst td{border:1px solid #e6e6e6; border-collapse:collapse; height:0px;}
.fullwidfloatoption{width:1340px; float:left; padding-top:10px;}
.option1 table{border-collapse:collapse;}
.option1 td{border:1px solid #e6e6e6; border-collapse:collapse; height:20px;}
.option1 .bordernone{border:none;}
.option1 .borderrightleftnone{border-left:none; border-right:none;}
.option1 .borderleftnone{border-left:none;}
.option1 .borderrightnone{border-right:none;}
.option1 .inputblue{color:#2d00ee;}
.fullwidfloat_Fabric .heading{border-bottom:2px dotted #e6e6e6;border-right: none; height:87px;}
.fullwidfloat_Fabric .lace{width:50%; float:left; text-align:center; vertical-align:middle; padding-top:7px; height:15px;}
.fullwidfloat_Fabric .mt{width:50%; float:left; text-align:center; vertical-align:middle; padding-top:7px;}
.fullwidfloat_Fabric .total{height: 0;border-bottom: none;}
.fullwidfloat_Fabric .cutwstborder{border:1px solid #666666;}
.fullwidfloat_Fabric .cutwstborderrightnone{border:1px solid #666666; border-right:none;}
.fullwidfloat_Fabric .bordertopriglefnon{border-top:none; border-right:none; border-left:none;}
.fullwidfloat_Fabric .bordertopnon{border-top:none;}
.fullwidfloat_Fabric .bordernon{border:none;}
.fullwidfloat_Fabric .qty{height:59px;}
.fullwidfloat_Fabric .paddingzero{padding:0;}
.fullwidfloat_Fabric .heightthirnine{height:39px;}
.fullwidfloat_Fabric .colblue{color:#2d00ee; font-weight:bold;}
.fullwidfloat_Fabric .borleftnon{border-left:none;}
        #btnAddRow
        {
            height: 12px;
        }
    </style>
     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

 <%--<script src="../../CommonJquery/Js/jquery-1.9.0.min.js" type="text/javascript"></script>--%>
<%--  <script src="../../CommonJquery/Js/jquery-1.11.1.min.js" type="text/javascript"></script>--%>
   <%-- <script src="../../CommonJquery/JqueryLibrary/jquery-1.7.2.min.js" type="text/javascript"></script>--%>

    <script src="../AspxPageJS/FactoryOrder.js" type="text/javascript"></script>
    <script src="../../CommonJquery/JqueryLibrary/jquery.linq.min.js" type="text/javascript"></script>
    <script src="../../CommonJquery/JqueryLibrary/linq.min.js" type="text/javascript"></script>
   <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>--%>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<script type="text/javascript" >
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var CheckFistTime = '<%=bChechFirstPage%>'
    var proxy = new ServiceProxy(serviceUrl);
    var BuyerDDClientID = '<%=ddlClient.ClientID%>';
    var DeptDDClientID = '<%=ddlDepartment.ClientID%>';
    var txtIkandiSerialClientID = '<%=txtIkandiSerial.ClientID%>';
    var txtStyleNumberClientID = '<%=txtStyleNumber.ClientID%>';

    var txtTotalQtyClientID = '<%=txtTotalQty.ClientID %>';
    var lblAccMgrClientID = '<%=lblAccntMgr.ClientID %>';
    var tableOrderDetailVar = "tableOrderDetail";
    var ddlModeClientID = "ddlMode";

    var txtDelInstructionClientID = '<%=txtDelInstruction.ClientID %>';
    var hdnCostingIdClientID = '<%=hdnCostingId.ClientID %>';
    var txtOrderDateClientID = '<%=txtOrderDate.ClientID %>';
    var hdnOrderIdClientID = '<%=hdnOrderId.ClientID %>';
    var hdnOrderTypeClientID = '<%=hdnOrderType.ClientID %>';
    var hdnStyleIDClientID = '<%=hdnStyleID.ClientID %>';
    var hdnClientID = '<%=hdnClientID.ClientID %>';
    var hdnOriginalClientID = '<%=hdnOriginalClientID.ClientID %>';
    var hdnOriginalDeptIDClientID = '<%=hdnOriginalDeptID.ClientID %>';
    var hdnDeptID = '<%=hdnDeptID.ClientID %>';
    var hdnNewClientID = '<%=hdnNewClientID.ClientID %>';
    var hdnNewDeptID = '<%=hdnNewDeptID.ClientID %>';
    var hdnhdnOrderSequenceClientID = '<%=hdnOrderSequence.ClientID %>';
    var txtBIPLPriceClientID = '<%=txtBIPLPrice.ClientID %>';
    var hdnSelectedClientClientID = '<%=hdnSelectedClient.ClientID %>';
    var hdnSelectedDeptClientID = '<%=hdnSelectedDept.ClientID %>';
    var hdnExpectedDateClientID = '<%=hdnExpectedDate.ClientID %>';
    var hdnRowCountClientID = '<%=hdnRowCount.ClientID %>';
    var isExpanded = false;

    var objDDLTypeOfPacking = '<%= ddlTypeOfPacking.ClientID %>';
  
    var jscriptPageVariables = null;
    var selectedClient = '';
    var selectedDept = '';
    var txtFabric;
    var color = '';
    var debugCount = 0;
    var context = $("#main_content");

    var lineno = 0;
    var Contact = 0;
    var qty = 0;
    var contactRow = 0;


   
   </script>
   

<script type="text/javascript">
    $(".Repeat").live("click", function () {
        alert('sushil');
        Getrepeatorder($("#" + txtStyleNumberClientID).val());
       
    });

    function Getrepeatorder(styleno) {
        //alert(orderid);

        //debugger;
        proxy.invoke("Getrepeatorder", { Styleno: styleno },
        function (result) {
            // alert('abc');
            // alert(result);
            // alert(result.order.OrderBreakdown.length > 0);
              debugger;
            if (result.length > 0) {
                $('.tblRepeat tr').eq(1).find('.txtline').text(result[0].LineItemNumber);
                $('.tblRepeat tr').eq(1).find('.txtcontract').text(result[0].ContractNumber);
                $('.tblRepeat tr').eq(1).find('.exdate').text(result[0].ExFactory);
                $('.tblRepeat tr').eq(1).find('.txtqty').text(result[0].Quantity);
                $('.tblRepeat tr').eq(1).find('.color').text(result[0].Fabric1Details);
                $('.tblRepeat tr').eq(1).find('.orderdate').text(result[0].CreatedOn);
                $('.tblRepeat tr').eq(1).find('.serialno').text(result[0].LineItemNumber_d);
                $('.tblRepeat tr').eq(1).find('.orderid').text(result[0].OrderID);
                for (var i = 1; i < result.length; i++) {
                    //  alert(result[i].Fabric1);
                    var tableBody = $('.tblRepeat > tbody');
                    lastRowClone = $('tr:last-child', tableBody).clone();
                    // clear the values in the text field.
                    $('input[type=text]', lastRowClone).val('');
                    $('.txtline', lastRowClone).text(result[i].LineItemNumber);
                    $('.txtcontract', lastRowClone).text(result[i].ContractNumber);
                    $('.exdate', lastRowClone).text(result[i].ExFactory);
                    $('.txtqty', lastRowClone).text(result[i].Quantity);
                    $('.color', lastRowClone).text(result[i].Fabric1Details);
                    $('.orderdate', lastRowClone).text(result[i].CreatedOn);
                    $('.serialno', lastRowClone).text(result[1].LineItemNumber_d);
                    $('.orderid', lastRowClone).text(result[1].OrderID); 
                    // and finally we append the row after the last row.
                    // tableBody.append(lastRowClone);
                    $('.tblRepeat tr:last').after(lastRowClone);


                }

                $("#dialog").dialog({
                    title: "jQuery Dialog Popup",
                    buttons: {
                        Close: function () {
                          alert($(this).find('.CkeckRepeat').attr('checked', 'checked'));
                           $(this).dialog('close');
                        }
                    }
                });
                return false;
            }


        }, null, false, false);
    };

</script>
<div id="dialog"  style="width:100%; float:left; height:100%; overflow-y: scroll;display: none;">
    
    
        <table id="tblRepeat" width="100%" cellpadding="10" cellspacing="0"  class="tblRepeat">         
        <tr>
            <td align="center" width="100px" class="fonttwelve fontblack"></td>
            <td align="center" width="60px" class="fonttwelve fontblack">orderid</td>
            <td align="center" width="100px" class="fonttwelve fontblack">PRD / Color</td>
            <td align="center" width="67px" class="fonttwelve fontblack">Order Date</td>
            <td align="center" width="100px" class="fonttwelve fontblack">Serial No</td>
            <td align="center" width="80px" class="fonttwelve fontblack">Line No<br />Contract No </td>
            <td align="center" width="80px" class="fonttwelve fontblack">Qty (Pcs)</td>
            <td align="center" width="60px" class="fonttwelve fontblack"> Ex Factory</td>
            
            
            
        </tr>
        <tr>
            
             <td align="center"><asp:RadioButton ID="RadioButton1" runat="server" class="CkeckRepeat" /> </td>
              <td align="center"><asp:Label ID="Label24" runat="server" class="orderid"></asp:Label></td>
           <td align="center"><asp:Label ID="Label14" runat="server" class="color" ></asp:Label> </td>
             <td align="center" ><asp:Label ID="Label16" runat="server" class="orderdate"></asp:Label></td>
            <td align="center"><asp:Label ID="Label18" runat="server" class="serialno"></asp:Label></td>
           <td align="center" ><asp:Label ID="Label19" runat="server" class="txtline"></asp:Label><br /><asp:Label ID="Label21" runat="server" class="txtcontract"></asp:Label></td>
            <td align="center" ><asp:Label ID="Label22" runat="server" class="txtqty"></asp:Label></td>
            <td align="center"><asp:Label ID="Label23" runat="server" class="exdate"></asp:Label></td>
           
           
        </tr>
        </table>
        

</div>


 <div class="container" style="background-color:#f9f9fa;">
    <!--Start Orderform title css-->
    <div class="titleheading">Order Form<asp:HiddenField ID="hdnExpectedDate" runat="server" Value="" />
     </div>
    <!--End Orderform title css-->
       <div class="fullwidfloat">
       <table width="1505px" cellpadding="5" cellspacing="0" class="basicinfo bordercollapse">
    <tr>
        <td valign="top" style="border:none;">
            <table width="510px" cellpadding="5" cellspacing="0">
            <tr>
                <th align="left" class="style3">Basic Info</th>
                <th align="left" style="background-color: transparent;" colspan="3">&nbsp;</th>
            </tr>
            <tr>
                <td align="left" class="fontblack" style="width:350px;">Order Date</td>
                <td align="right" class="inputdarkgrey" style="width: 240px;"><asp:Label ID="txtOrderDate" runat="server" class="txtorderdate" Text="21 Jun 14 (Wed)"></asp:Label></td>
                <td align="left" class="fontblack" style="width: 200px;">Total Qty</td>
                <td align="right" class="inputdarkgrey" style="width: 150px;"><asp:TextBox ID="txtTotalQty" runat="server" class="textbox2 txttotalqty" ></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" style="height:40px;" class="fontblack">Style Number</td>
                <td align="right"><asp:TextBox ID="txtStyleNumber" runat="server" Text="DR 0CROCHET" class="textbox2 txtstyleno" validate="required:true" ToolTip="Style Number Is Required">
                                              </asp:TextBox></td>
                <td align="left" class="fontblack">Serial Number</td>
                <td align="right" class="inputblue"><asp:TextBox ID="txtIkandiSerial" runat="server"  class="textbox2 txtstyleno"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="left" style="height:40px;" class="fontblack">Buyer</td>
                <td align="right" class="inputblue">
        <asp:DropDownList ID="ddlClient" runat="server" class="inputblue depart_dropdown ddlbuyer" >
       
        <asp:ListItem Value="-1">Select..</asp:ListItem>
        </asp:DropDownList>
                </td>
                <td align="left" class="fontblack">Department</td>
                <td align="right" class="inputblue">
                <asp:DropDownList ID="ddlDepartment" runat="server" class="inputblue depart_dropdown ddldprt">
                <asp:ListItem>Blouses</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
       <td align="left" style="height:40px;" class="fontblack">Delivery Packing</td>
        <td align="right">
            <table width="100%" cellpadding="0" cellspacing="0" class="basicinfo2">
            <tr>
                <td align="left" class="inputdarkgrey"><asp:Label ID="txtDelInstruction" runat="server" Text="Flat"></asp:Label></td>
                <td align="right"><asp:DropDownList Width="100px" runat="server" ID="ddlTypeOfPacking" class="ddlpack dropdown inputblue"></asp:DropDownList></td>
            </tr>
            </table>
        </td>
        <td align="left" class="fontblack" style="width: 553px">Account Manager</td>
        <td align="right" class="inputdarkgrey"><asp:Label ID="lblAccntMgr" runat="server" class="txtaccmgr"  Text=""></asp:Label></td>
        
    </tr>
    <tr>
       <td align="left" style="height:40px;" class="fontblack">Description</td>
        <td align="right" class="inputblue"><asp:TextBox ID="txtDescription" runat="server" Text="" class="textbox2 txtdes"></asp:TextBox></td>
        <td align="left" class="fontblack"><a href="#" class="Repeat" >Repeat</a></td>
        <td align="center"><a href="#" class="click">Click here</a></td>
        
    </tr>
    <tr>
       <td align="left" style="height:40px;" class="fontblack">BIPL Price</td>
        <td align="right" class="inputblue"> <asp:TextBox runat="server" ID="txtBIPLPrice" class="textbox2 txtbiplprice" Style="text-align:right; font-weight: bold;"></asp:TextBox>
</td>
        <td align="left" class="style4">&nbsp;</td>
        <td align="center"><a href="#" class="SaveData" onclick="savedata(this);">Click for Save</a></td>
        
    </tr>
            </table>
        </td>
        <td valign="top" style="border:none;">
        <div style="float:left; width:100%; color:White; line-height:30px; font-weight:bold; font-size:14px;">
            <div style="width:530px; float:left;">
                <div style="width:118px; float:left; background-color:#39589C; padding-left:5px;">Contract Info</div>
            </div>
        </div>
        <div style="width:100%; float:left; height:307px; overflow-y: scroll;">
        <table id="myTable" width="100%" cellpadding="5" cellspacing="0"  class="tblcontect">         
        <tr>
            <td align="center" width="119px" class="fonttwelve fontblack">Line / Item Number<br />Contract Number</td>
            <td align="center" width="120px" class="fonttwelve fontblack">Contract / PO upload</td>
            <td align="center" width="67px" class="fonttwelve fontblack">Qty (Pcs)</td>
            <td align="center" width="151px" class="fonttwelve fontblack">Mode</td>
            <td align="center" width="80px" class="fonttwelve fontblack">IKANDi Price</td>
            <td align="center" width="100px" class="fonttwelve fontblack">Ex Factory<br />Delivery (DC)</td>
            <td align="center" width="135px" class="fonttwelve fontblack">Weeks to EX<br />Weeks to DC</td>
            <td align="center" class="fonttwelve fontblack">&nbsp;</td>
            
        </tr>
        <tr>
            <td align="center" class="style2"><asp:TextBox ID="txtlineno1" runat="server" 
                    Text="" class="textbox3 txtline" ></asp:TextBox><br /><asp:TextBox ID="txtcontractno1" runat="server" Text="" class="textbox3 txtcontract"></asp:TextBox></td>
            <td align="center"><a href="#" class="click">Add</a></td>
            <td align="center" class="inputblue"><asp:TextBox ID="txtqtp1" runat="server" Text="" class="textbox4 txtqty"></asp:TextBox></td>
            <td align="center">
            <asp:DropDownList ID="ddlDeliveryMode" runat="server" class="inputblue dropdown mode">
            <asp:ListItem>D(PORT-F)-S/F(FOB)</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td align="center" class="inputblue"><asp:TextBox ID="txtikandiprice1" runat="server" Text="$16.02" class="textbox4 ikandiprice"></asp:TextBox></td>
            <td align="center" class="inputdarkgrey"><asp:TextBox ID="lblexfactory1" runat="server" Text="" class="textbox3 exfactory exdate"></asp:TextBox><br /><asp:TextBox ID="txtdeliverydc1" runat="server" Text="" class="textbox3 dcdate"></asp:TextBox></td>
            <td align="center"><asp:Label ID="lblweekex1" runat="server" class="Exweek" Text=""></asp:Label><br /><asp:Label ID="lblweekdc1" runat="server" class="Dcweek" Text=""></asp:Label></td>
            <td>
             <div align="right" class="add-more">
                    <img src="../../App_Themes/ikandi/images/plus.gif" id="btnAddRow" class="add-row BtnPlus"
                    onclick="addRow_new(this);addfabricrow();addAcccolumn(); return false;"    /></div>
                   <div align="right" class="add-more">
                    <img src="../../App_Themes/ikandi/images/minus.gif" id="Img1" class="remove-row Btnminus"
                     onclick="removerow(this);removeFabrow(this); return false;"   /></div>

            </td>
        </tr>
        </table>
        </div>
        </td>
       <td valign="top" style="border:none;">
        <table width="100%" cellpadding="0" cellspacing="0" class="picture">
        <tr>
            <th align="left" width="125px" style="background-color: transparent;">&nbsp;</th>
        </tr>
        <tr>
            <td align="center"><img src="images/picture.jpg" /></td>
        </tr>
        <tr>
            <td align="center">IMAGES</td>
        </tr>
        </table>
        </td>
        
    </tr>
   
    </table>
    </div><!--End fullwidfloat BasicInfo css-->
     
    <div class="fullwidfloat_Fabric"> 
   <div style="float:left; width:100%; color:White; line-height:20px; font-weight:bold; font-size:14px;">
    <div style="width:210px; float:left; background-color:#39589C; padding:5px 5px;">Fabric Order Management</div>
    </div>
    <div style="width:1410px; float:left; height:307px; overflow: scroll;">
      <table cellpadding="5" cellspacing="0" class="fabriccontract bordercollapse fabtable fabricone">   
        <tr>
       <td width="100px" align="center" class="subheading">Line/Item No.<br />Contract No.</td>
        <td width="100px" align="center" class="subheading qty" style="border-right:none;">Qty (Pcs)</td>
        <td align="left" valign="top" style="border:1px solid #000000; border-bottom:none; padding:0px; line-height:32px;">
            <div style="float:left; border-bottom:1px solid #E6E6E6; height:25px; width:395px;">
                <div style="width:130px; float:left; padding-left:5px;"><asp:TextBox ID="txtfabric1" runat="server" Text="" class="textbox8 s_fabric1"></asp:TextBox></div>
                <div style="width:170px; float:left; line-height:20px; " class="contract2"><asp:Label ID="lblcc1" runat="server" Text="" class="s_ccgsm"></asp:Label></div>
                <div style="width:55px; float:right; line-height:20px;  text-align:right; padding-right:5px;"  class="contract2">Width: <asp:Label ID="lblwid1" runat="server" Text="" class ="fabwidth"></asp:Label></div>
            </div>
            <div style="float:left;">
                <div style="width:100px; float:left; text-align:center; line-height:45px;" class="subheading">Color/Print</div>
                <div style="width:150px; float:left; border-right:1px solid #E6E6E6; border-left:1px solid #E6E6E6;">
                    <div style="width:150px; float:left; border-bottom: 2px dotted #E6E6E6;">
                        <div style="width:50px; float:left; padding-left:5px;" class="subheading">Avg.</div>
                        <div style="width:90px; float:right; text-align:right; padding-right:5px;"><asp:DropDownList ID="DropDownList2" runat="server" class="inputblue dropdownmt"><asp:ListItem>MT</asp:ListItem></asp:DropDownList></div>
                    </div>
                    <div style="width:150px; float:left;">
                        <div style="width:50px; float:left; padding-left:5px;" class="subheading">Supplier.</div><div style="width:90px; float:left; text-align:right; padding-right:5px;" class="subheading">Mtrg.Ord.</div> 
                    </div>
                </div>
                <div style="width:140px; float:left; text-align:center;">
                    <div style="width:140px; float:left; text-align:center; border-bottom: 2px dotted #E6E6E6; height:32px;" class="subheading">Rate
                    <span align="right" class="add-more"><img src="../../App_Themes/ikandi/images/plus.gif" id="Img3" class="add-row BtnPlus" onclick="addFabcolumn(); return false;" /></span>
                    </div><div style="width:140px; float:left; text-align:center;" class="subheading">Profit/Loss</div></div>
                </div>
        </td>
        <td align="center" width="80px" class="subheading">Total<br />Profit/Loss</td>
        <td align="center" width="80px" class="subheading">Budget</td>
    </tr>
    <tr>
       <td align="center" class="inputdarkgrey"><asp:Label ID="lblline1" runat="server" class="slineno" Text=""></asp:Label><br /><asp:Label ID="lblconno1" runat="server" class="scontact" Text=""></asp:Label></td>
        <td align="center" class="inputdarkgrey" style="height:50px; border-right:none;"><asp:Label ID="lblqty1" runat="server" class="sqty" Text=""></asp:Label></td>
        <td align="center" style="padding:0px; border:1px solid #000000; border-bottom:none; border-top:none;">
            <div style="float:left; border-top:1px solid #E6E6E6;">
                <div style="width:100px; float:left; text-align:center; padding-top:25px;"><asp:TextBox ID="txtclrprnt1" runat="server" Text="fabric" class="textbox4 fabprint"></asp:TextBox></div>
                <div style="width:150px; float:left; border-left:1px solid #E6E6E6; border-right:1px solid #E6E6E6;">
                    <div style="width:150px; float:left;">
                        <div style="width:150px; float:left; border-bottom: 2px dotted #E6E6E6;"><span class="fontsizenine"><asp:Label ID="Label43" runat="server" Text="1.20" class="fabavg" ></asp:Label> </span> - 

<asp:TextBox ID="Label44" runat="server" Text="4.05" class="textbox5 orderavg"  ></asp:TextBox> <span class="fontsizenine">(<asp:Label ID="Label45" runat="server" Text="" class="avgdiff"></asp:Label>)

</span><br /><a href="#" class="click">Upload Smart marker</a></div>
                    </div>
                    <div style="width:140px; float:left; padding-right:5px; padding-left:5px;">
                        <div style="width:80px; float:left; text-align:left;"><asp:DropDownList ID="lblsupname2" runat="server" class="inputblue dropdownsuplrname">
                        <asp:ListItem>Mehta</asp:ListItem>
                        </asp:DropDownList></div><div style="width:60px; float:left; text-align:right;"><asp:Label ID="lblmtrgord2" runat="server" Text="0" class="fabqty"></asp:Label></div> 
                    </div>
                </div>
                <div style="width:140px; float:left; text-align:center;">
                    <div style="width:140px; float:left; text-align:center; border-bottom: 2px dotted #E6E6E6; line-height:41px;"><span class="fontsizenine"><asp:Label ID="Label53" runat="server" 

Text="56.00" class="fabprice"></asp:Label></span> - <asp:TextBox ID="TextBox3" runat="server" Text="59.00" class="textbox5 orderprice"></asp:TextBox> <span class="fontnincol">(<asp:Label 

ID="Label55" runat="server" Text="" class="pricediff"></asp:Label>)</span></div>
                    <div style="width:140px; float:left; text-align:center;"><asp:Label ID="Label56" runat="server" class="fontred lk" Text="1.69"></asp:Label></div>
                </div>
            </div>
        </td>
       
       
        <td align="center" width="80px" class="colboltextcenterunbold"><asp:Label ID="lblfabbudget1" CssClass="colboltextcentergreen totallk" runat="server" Text="16.27"></asp:Label></td>
        <td align="center" width="80px" class="colboltextcenterunbold"><asp:Label ID="Label17" runat="server" class="budget" Text="16.27"></asp:Label></td>
    </tr>
    <tr class="fabtotal">
       <td align="center" class="fonttwelveblack">Total Req.</td>
        <td align="center" class="colfontbold" style="border-right:none;"><asp:Label ID="lbltotreq" runat="server" class="s_totqty" Text="0"></asp:Label></td>
        <td align="center" style="padding:0px; border-left:1px solid #000000; border-right:1px solid #000000;">
            <div style="float:left; line-height:30px;">
                <div style="width:100px; float:left; text-align:center;">Wastage</div>
                <div style="width:150px; float:left; border-left:1px solid #E6E6E6; border-right:1px solid #E6E6E6;">
                    <div style="width:150px; float:left;">
                        <span class="fontsizenine"><asp:Label ID="Label50" runat="server" Text="5" class="fabwastage"></asp:Label></span> - <asp:TextBox ID="TextBox2" runat="server" Text="4" 

class="textbox5 orderwastage"></asp:TextBox> <span class="fontsizenine">(<asp:Label ID="Label52" runat="server" Text="1" class="diffwastage"></asp:Label>)</span>
                    </div>
                </div>
                <div style="width:140px; float:left; text-align:center;">
                    <div style="width:144px; float:left; text-align:center;"><asp:Label ID="Label20" runat="server" class="fontred" Text="1.69 lk"></asp:Label></div>
                </div>
            </div>
        </td>
    
       
        <td align="center" width="80px" rowspan="2"><asp:Label ID="lblfabtotlbudget" CssClass="colboltextcentergreenbold sumprofit" runat="server" Text="16.27"></asp:Label></td>
        <td align="center" width="80px" rowspan="2"><asp:Label ID="Label15" runat="server" CssClass="colboltextcenter sumdudget" Text="16.27"></asp:Label></td>
    </tr>

    <tr>
       <td align="center" style="border:none;">&nbsp;</td>
        <td align="center" style="border:none;">&nbsp;</td>
        <td align="center" style="padding:0px; border-left:1px solid #000000; border-bottom:1px solid #000000; border-right:1px solid #000000;">
            <div style="float:left; line-height:30px;">
                <div style="width:140px; float:left; text-align:center; border-right:none;">Final Fabric Order Placed</div>
                <div style="width:106px; float:left; border-right:1px solid #E6E6E6; text-align:right; padding-top:5px; padding-right:5px;"><asp:TextBox ID="txtfinal1" runat="server" Text="15,650" 

class="textbox6 fabfinalorder"></asp:TextBox></div>
                <div style="width:95px; float:left; text-align:left; padding-left:5px;">Transaction Days</div>
                <div style="width:40px; float:right; text-align:right; padding-top:5px;"><asp:TextBox ID="txttransdays1" runat="server" Text="10" class="textbox7"></asp:TextBox></div>
                </div>
        </td>
        
       
    </tr>

    </table>
    </div>
  </div><!--End fullwidfloat_Fabric css-->

    <div class="fullwidfloatoption">
    <table width="100%" cellpadding="5" cellspacing="0" class="option1">
    <tr>
       <td align="left" width="20px" class="bordernone"><input name="" type="radio" value="" /></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">BIH Start</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihstart" runat="server" Text="1 Aug 14 (Fri)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">BIH End</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihend" runat="server" Text="10 Aug 14 (Sun)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">PCD</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihpcd" runat="server" Text="5 Aug 14 (Tue)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">Ex Factory</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihexfactry" runat="server" Text="21 Aug 14 (Thu)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">Lines</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihlines" runat="server" Text="2"></asp:Label></td>
        <td align="left" width="140px" class="fontblack  borderrightnone">CMT (use 70% Ach.)</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihcmt" runat="server" Text="&#8377; 52.00"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">Profit/Loss</td>
        <td align="right" width="100px" class="option_colboltextcentergreenbold borderleftnone"><asp:Label ID="lblbihproflos" runat="server" Text="&#8377; 1.00 lk"></asp:Label></td>
    </tr>
    </table>
    </div><!--End fullwidfloatoption css-->
    
    <div class="fullwidfloatoption">
    <table width="100%" cellpadding="5" cellspacing="0" class="option1">
    <tr>
       <td align="left" width="20px" class="bordernone"><input name="" type="radio" value="" /></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">BIH Start</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihstar2" runat="server" Text="1 Aug 14 (Fri)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">BIH End</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihend2" runat="server" Text="10 Aug 14 (Sun)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">PCD</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihpcd2" runat="server" Text="5 Aug 14 (Tue)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">Ex Factory</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihexfactry2" runat="server" Text="21 Aug 14 (Thu)"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">Lines</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihlines2" runat="server" Text="2"></asp:Label></td>
        <td align="left" width="140px" class="fontblack  borderrightnone">CMT (use 70% Ach.)</td>
        <td align="right" width="100px" class="colfontelev borderleftnone"><asp:Label ID="lblbihcmt2" runat="server" Text="&#8377; 52.00"></asp:Label></td>
        <td align="left" width="80px" class="fontblack  borderrightnone">Profit/Loss</td>
        <td align="right" width="100px" class="option_colboltextcenterredbold borderleftnone"><asp:Label ID="lblbihproflos2" runat="server" Text="&#8377; 1.00 lk"></asp:Label></td>
    </tr>
    </table>
    </div><!--End fullwidfloatoption css-->
    
    
   
    <div style="float:left; width:100%; margin-top:20px; color:White; height:20px; font-weight:bold; font-size:14px;">
    <div style="width:328px; float:left; background-color:#39589C; padding:5px 5px;">Accessories Order Management</div>
    </div>
    
    <div class="fullwidfloat_access" style="width:1410px; float:left; margin-top:6px; overflow: scroll; height:282px;">
    <table cellpadding="0" id="acccaltable" cellspacing="0" class="accessories bordercollapse acctable accesstwo acccaltable">
    <tr>
        <td align="center" class="subheading heading" style="width:200px;">Item</td>
        <td valign="top" style="width:200px; line-height:49px; border-right: none;">
            <div style="width:100%; float:left; text-align:center;" class="subheading borderbotdotted">Rate</div>
            <div style="width:100%; float:left; text-align:center;" class="subheading">Quantity</div>  
        </td>
        <td valign="top" width="370px" style="border:1px solid #000000; border-bottom:none;">
            <div style="width:100%; float:left; line-height:25px;">
            <div style="width:48%; float:left; text-align:left; padding-left:5px;" class="subheading">Line: <asp:Label ID="Label1" runat="server" class="s_lineno" Text=""></asp:Label></div>
            <div style="width:48%; float:right; text-align:right; padding-right:5px;" class="subheading">Contract No:<asp:Label ID="Label12" runat="server" class="s_contact" Text=""></asp:Label>
            </div>
            </div>

            <div style="width:100%; float:left; border-bottom:1px solid #E6E6E6; line-height:25px;">
            <div style="width:48%; float:left; text-align:left; padding-left:5px;" class="subheading">Qty: <asp:Label ID="Label13" runat="server" class="s_qty" Text=""></asp:Label></div>
            <div style="width:48%; float:right; text-align:right; padding-right:5px;" class="subheading">Clr / prd: <asp:Label ID="Label1a" runat="server" Text="Blue"></asp:Label></div>
            </div>

            <div style="width:100%; float:left; line-height:25px; border-bottom:2px dotted #E6E6E6;">
            <div style="width:48%; float:left; padding-left:5px; border-right:1px solid #E6E6E6; text-align:center;" class="subheading">% Cut Wstg.</div>
            <div style="width:48%; float:right; padding-right:5px; text-align:center;" class="subheading">Qty Ordered</div>
            </div>

            <div style="width:100%; float:left; line-height:25px;">
            <div style="width:48%; float:left; padding-left:5px; border-right:1px solid #E6E6E6; text-align:center;" class="subheading">% Item Wstg.</div>
            <div style="width:48%; float:right; padding-right:5px; text-align:center;" class="subheading">Profit/Loss</div>
            </div>
        </td>
        <td valign="top" style="width:130px; line-height:49px;">
            <div style="width:100%; float:left; text-align:center;" class="subheading borderbotdotted">Total Qty</div>
            <div style="width:100%; float:left; text-align:center;" class="subheading">Total Profit/Loss</div>  
        </td>
        <td style="width:100px;" align="center" class="subheading">Budget</td>
        <td style="width:120px;" align="center" class="subheading">Supplier</td>
    </tr>
    <tr>
        <td align="center" style="height:51px;">
        <div style="width:90px; float:left; padding-top:3px; padding-left:5px; text-align:left;" class="inputblue"><asp:Label ID="lblitem" runat="server" Text="" class="accitem"></asp:Label></div>
        <div style="width:auto; float:right; padding-right:5px; text-align:right;">
        <asp:DropDownList ID="DropDownList1" runat="server" class="inputblue dropdownmt">
                <asp:ListItem>MT</asp:ListItem>
            </asp:DropDownList>
            </div>
        </td>
        <td style="border-right: none;">
            <div style="width:100%; float:left; text-align:center;" class="borderbotdotted"><span class="fontnincol"><asp:Label ID="Label2a" runat="server" Text="" class="accrate"></asp:Label></span> - <span class="colborrigfont"><asp:TextBox ID="TextBox20" runat="server" class="textbox5 orderrate" Text=""></asp:TextBox></span> <span class="fontnincol">(<asp:Label ID="Label3" runat="server" class="ratediff" Text=""></asp:Label>)</span></div>
            <div style="width:100%; float:left; text-align:center;"><span class="fontnincol"><asp:Label ID="Label4" runat="server" Text="" class="accqty"></asp:Label></span> - <span class="colborrigfont"><asp:TextBox ID="TextBox21" runat="server" class="textbox5 orderqty" Text=""></asp:TextBox></span> <span class="fontnincol">(<asp:Label ID="Label5" class="qtydiff" runat="server" Text=""></asp:Label>)</span></div>  
        </td>
        <td valign="top" style="border-left:1px solid #000000; border-right:1px solid #000000;">
         <div style="width:100%; float:left; line-height:25px; border-bottom:2px dotted #E6E6E6;">
            <div style="width:48%; float:left; padding-left:5px; border-right:1px solid #E6E6E6; text-align:center;"><asp:Label ID="Label6" runat="server" class="accwst" Text="5"></asp:Label> - <span class="colborrigfont"><asp:TextBox ID="TextBox22" runat="server" class="textbox5 orderwst" Text=""></asp:TextBox></span> = <asp:Label ID="Label7" runat="server" class="wstdiff" Text=""></asp:Label></div>
            <div style="width:48%; float:left; padding-right:5px; text-align:center;"><asp:Label ID="Label8" runat="server" class="orderedqty" Text=""></asp:Label></div>
            </div>
            <div style="width:100%; float:left; line-height:25px;">
            <div style="width:48%; float:left; padding-left:5px; text-align:center;"><asp:TextBox ID="TextBox23" runat="server" class="textbox9 itemwst" Text=""></asp:TextBox></div>
            <div style="width:48%; float:left; padding-right:5px; text-align:center; border-left:1px solid #E6E6E6;"><asp:Label ID="Label9" CssClass="borbotleftcol2 profitloss" runat="server" Text=""></asp:Label></div>
            </div>
        </td>
        <td valign="top">
        <div style="width:100%; float:left; text-align:center; line-height:25px;" class="colboltextcenter borderbotdotted"><asp:Label ID="lbltotorderdqty" runat="server" class="totalorderdqty" Text=""></asp:Label></div>
        <div style="width:100%; float:left; text-align:center; line-height:25px;" class="borbotleftcol2"><asp:Label ID="Label11" runat="server" class="totalprofitloss" Text=""></asp:Label></div>  
        </td>
        <td align="center"><asp:Label ID="lblaccbudget" class="accbudget" runat="server" Text=""></asp:Label></td>
        <td align="center">
        <asp:DropDownList ID="lblsuplrnme1" runat="server" class="inputblue dropdownsuplrname">
              <asp:ListItem>Mehta</asp:ListItem>
              </asp:DropDownList>

              <span align="right" class="add-more">
                    <img src="../../App_Themes/ikandi/images/plus.gif" id="Img2" class="add-row BtnPlus"
                    onclick="addACCRow(this); return false;"    /></span>
         </td>
    </tr>
   
   <tr class="Acctotal">
        <td align="center" class="fonttwelveblack">
        Total
        </td>
        <td style="border-right: none;">
           &nbsp;
        </td>
        <td valign="top" style="width:250px; border:1px solid #000000; border-top:none;">
            <div style="width:100%; float:left; line-height:25px;">
            <div style="width:48%; float:left; padding-left:5px; text-align:center;">&nbsp;</div>
            <div style="width:48%; float:left; padding-right:5px; text-align:center; border-left:1px solid #E6E6E6;"><asp:Label ID="Label" CssClass="colboltextcentergreenbold sumprofitloss" runat="server" Text=""></asp:Label></div>
            </div>
        </td>
        <td valign="top">
        
        <div style="width:100%; float:left; text-align:center; line-height:25px;" class="borbotleftcol2"><asp:Label ID="Label2" runat="server" class="sumtotalprofitloss" Text=""></asp:Label></div>  
        </td>
        <td align="center" class="colboltextcenter"><asp:Label ID="Label10" runat="server" class="sumaccbudget" Text=""></asp:Label></td>
        <td align="center">&nbsp;</td>
    </tr>
    
    </table>
    </div><!--End fullwidfloat_Fabric css-->


<!--End fullwidfloat_Fabric css-->

</div>
<div>
 <asp:HiddenField ID="hdnOrderId" runat="server" />

                                <asp:HiddenField ID="hdnStyleID" runat="server" />

                                <asp:HiddenField ID="hdnClientID" runat="server" Value="-1" />

                                <asp:HiddenField ID="hdnOrderType" runat="server" Value="1" />

                                <asp:HiddenField ID="hdnOriginalClientID" runat="server" Value="-1" />

                                <asp:HiddenField ID="hdnOriginalDeptID" runat="server" Value="-1" />

                                <asp:HiddenField ID="hdnDeptID" runat="server" Value="-1" />

                                <asp:HiddenField ID="hdnNewClientID" runat="server" Value="-1" />

                                <asp:HiddenField ID="hdnNewDeptID" runat="server" Value="-1" />

                                <asp:HiddenField ID="hdnSelectedClient" runat="server" Value="" />

                                <asp:HiddenField ID="hdnSelectedDept" runat="server" Value="" />

                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />

                                <asp:HiddenField ID="hdnOrderSequence" runat="server" Value="0" />

                                <asp:HiddenField ID="hdnRowCount" runat="server" Value="0" />
                                 <asp:HiddenField runat="server" ID="hdnCostingId" />
</div>
</asp:Content>
