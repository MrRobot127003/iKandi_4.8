<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CutIssuePendingReport.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.CutIssuePendingReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Boutique International Pvt. ltd.</title>
       <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
        <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="../../js/service.min.js"></script>
        <script type="text/javascript" src="../../js/jquery.autocomplete.js"></script>
     
        <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
      
        <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
        <script type="text/javascript" src="../../js/form.js"></script>
        <link href="../../css/report.css" rel="stylesheet" type="text/css" />
        <link href="../../css/report.css" rel="stylesheet" type="text/css" />
        <link href="../../css/CommanTooltip.css" rel="stylesheet" type="text/css" />
        <link href="../../css/TopHeaderFixed.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-family:Arial;
         }
         table th 
         {
             top:60px;
         }
        td.ContactNoCol
        {
            padding: 0px !important;
            text-align: center;
            max-width:80px;
        }
        th.ContactNoCol
        {
            padding: 0px !important;
            text-align: center;
        }
        .innertable
        {
            border-collapse: collapse;
        }
        .innertable td
        {
            border-left: 1px solid #999;
            padding: 2px 0px;
            min-width: 50px;
            max-width: 50px;
            text-align: center;
        }
        .innertable td:first-child
        {
            border-left: 0px;
        }
        td.StyleContextup
        {
            border-left:1px solid #999;
        }
        td.challanCol
        {
            padding: 0px 0px !important;
        }
        th.challanCol
        {
            padding: 0px 0px !important;
            height: 15px;
        }
        .border_last_bottom_color
        {
            border-bottom-color: #999 !important;
        }
        .AddClass_Table td
        {
            font-size: 10px;
        }
        td[rowspan]
        {
            font-size: 10px;
            height:auto;
        }
        
        .search_1 {
            font-size: 10px !important;;
            padding-left:4px;
        }
         #sb-body
        {
            background: #fff;
        }
        #sb-wrapper-inner
        {
            border: 5px solid #999;
            border-radius: 3px;
        }
        .ChallanTableInner td
        {
            border-collapse: collapse;
            border-left:0px;
         }
          .ChallanTableInner 
        {
            border-collapse: collapse;
         }
         .AddClass_Table td .ChallanTableInner tr:nth-child(1)>td
         {
             border-bottom:0px !important;
             border-top: 0px;
          }
       .StyleContextup
        {
         text-align: center;
          white-space: nowrap;
          vertical-align: middle;
          width: 2em;
        }
        .StyleContextup div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
              color: #405d9a;
            font-weight: bold;
         }
       .SrNoContextup
        {
             text-align: center;
              white-space: nowrap;
              vertical-align: middle;
              width: 2em;
        }
     .SrNoContextup div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
             color: #405d9a;
            font-weight: bold;
        }
        
        .StyleContextupH
        {
         text-align: center;
          white-space: nowrap;
          vertical-align: middle;
          width: 2em;
          padding:20px 0px !important;
        }
        .StyleContextupH div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
             
         }
        .SrNoContextupH
        {
             text-align: center;
              white-space: nowrap;
              vertical-align: middle;
              width: 2em;               
        }
     .SrNoContextupH div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
         
        }
         
      
        .table_width
        {
        margin-left:10px;
        }
    .search_1 {
        height:20px;
        border-radius: 2px;
    }
    .chkboxTop input[type='radio']
    {
       position: relative;
        top: 3px;
        right: 4px;
     }
      .chkboxTop {
         width: 100%;
         padding-top: 0px;
         height: 27px;
         margin-left:0px;
         background:#fff;        
         padding: 5px 0;
      }
      .headerSticky
      {
          width: 100%; 
          margin: 2px auto 0px;
          font-weight: 500;
          padding: 3px 0px;
       }
       td[colspan="11"]
       {
           border:0px !important;
        }
        .qatableheader {
    content: "";
    position: absolute;
    top: 0%;
    right: -7%;
    margin-left: -5px;
    border-width: 8px;
    border-style: solid;
    border-color: transparent transparent transparent #39589c;
   }
   td.TxtRight
   {
      text-align:right;
      padding-right:5px !important; 
    }
    </style>

    <script type="text/javascript">

        function SBClose() { }

        // debugger;
//        function OpenChallan(OrderDetailId, AccessoryMaster_Id, Color_Print, Size, Challan_Id, AvailableQty) {
//            //  alert();
//            if ((AvailableQty == undefined) || (AvailableQty == ''))
//                AvailableQty = '0'

//            var sURL = 'AccessoryInternalChallan.aspx?OrderDetailId=' + OrderDetailId + '&AccessoryMasterId=' + AccessoryMaster_Id + '&ColorPrint=' + Color_Print + '&Size=' + Size + '&ChallanId=' + Challan_Id + '&AvailableQty=' + AvailableQty;
//            Shadowbox.init({ animate: true, animateFade: true, modal: true });
//            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
//            return false;
//        }

        function OpenChallan(ChallanNumber, flagOption, SerialNumber) {

            if (flagOption.toLowerCase() == "SignaturePending".toLowerCase())
                var sURL = 'AccessoryInternalChallan.aspx?Flag=' + 'OpenChallan' + '&flagOption=' + flagOption + '&SerialNumber=' + SerialNumber + '&ChallanNumber=' + ChallanNumber + '&ChallanType=' + 'INTERNAL_CHALLAN';
            else
                var sURL = 'AccessoryInternalChallan.aspx?Flag=' + 'GetChallanDetails' + '&SerialNumber=' + SerialNumber + '&ChallanNumber=' + ChallanNumber + '&ChallanType=' + 'INTERNAL_CHALLAN';

            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", width: 1150, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }


        

        $(document).ready(function () {
            //debugger;
            var RowId = 0;
            var gvId;
            var GridRow = $(".FabricIssuedRow").length;

            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;


                var ContactNumberMaxVal = $("#grdAccessory_" + gvId + "_hdnContactNumber").val();
                var ContactMaxLen = ContactNumberMaxVal.length;
                // alert(ContactNumberMaxVal);
                if (ContactMaxLen > 10) {
                    $(".TooltipVal span").text(function (index, currentText) {
                        var maxLength = $(this).parent().attr('data-maxlength');
                        // alert(maxLength);
                        if (currentText.length > maxLength) {
                            return currentText.substr(0, maxLength) + "...";
                        } else {
                            return currentText
                        }
                    });

                    $("#grdAccessory_" + gvId + "_lblContactNo").attr('data-title', ContactNumberMaxVal);

                }
            }
        });

       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="PopTableW"  style="width:99%; margin-left: 9px;position: sticky;top:0px;z-index:9">
      <%--  <h2 style="width: 100%; margin: 2px auto 0px; font-weight: 500; background: #3b5998;color: White; text-align: center; padding: 3px 0px 2px; font-size: 14px;"></h2>--%>
         <div class="headerSticky"> Accessory Production Issue Report</div>
     <div class="chkboxTop">
        <asp:TextBox ID="txtsearchkeyswords" Width="21%" style="text-transform: capitalize;" class="search_1" placeholder="Search Accessory Quality/Style No/Serial No" runat="server" autocomplete="off"></asp:TextBox>
               
         <asp:RadioButton  ID="rbReuest" Checked="true" GroupName="CutIsseRequest" runat="server" /><span>All Request </span>&nbsp;
        <asp:RadioButton  ID="rbRequestPending" GroupName="CutIsseRequest" runat="server" /><span>Request Pending </span>&nbsp;
        <asp:RadioButton  ID="rbIssueRequest" GroupName="CutIsseRequest" runat="server" /><span>Issue Request </span>&nbsp;
        <asp:RadioButton  ID="rbIssueComplete" GroupName="CutIsseRequest" runat="server" /><span>Issue Complete </span>&nbsp;&nbsp;

         <asp:Button ID="btnSearch" runat="server" CssClass="btnbutton_Com do-not-disable" Text="Search" Style="padding: 2px 7px;margin-right:30px" onclick="btnSearch_Click" />
    </div>
        </div>
    <div style="position: relative;" class="table_width">
        <asp:GridView ID="grdAccessory" CssClass="GrdGriegeTable" runat="server"
            CellPadding="0" ShowHeader="true" BorderWidth="0" AutoGenerateColumns="false" Width="99%"
            OnRowDataBound="grdAccessory_RowDatabound" OnDataBound="grdAccessory_DataBound">
             <RowStyle CssClass="FabricIssuedRow" />
            <Columns>
                <asp:TemplateField HeaderText="<div>Style No.</div>">
                    <ItemTemplate>
                        <div>
                         <asp:Label ID="lblStyleNumber" Text='<%# Eval("StyleNumber") %>' runat="server"></asp:Label>   
                         </div>                           
                        <asp:HiddenField ID="hdnOrderDetailId" runat="server" Value='<%# Eval("OrderDetailId") %>' />
                        <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMasterId") %>' />
                       <asp:HiddenField ID="hdnSupplyType" runat="server" Value='<%# Eval("SupplyType") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol1 StyleContextup" Height="95px" />
                    <HeaderStyle CssClass="StyleContextupH" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<div>Sr. No.</div>">
                    <ItemTemplate>
                        <div>    
                            <asp:Label ID="lblSerial" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label>
                            </div>
                    </ItemTemplate>
                     <ItemStyle Width="20px" CssClass="SrNoContextup" />
                     <HeaderStyle CssClass="SrNoContextupH" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="">
                    <HeaderTemplate>
                        <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td style="border-bottom: 1px solid #ddd7d7; border-top: 0px; border-right: 0px;
                                    border-left: 0px;color:#6b6464">
                                    Contract No.
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 0px;color:#6b6464">
                                    Quantity
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                            <tr>
                                <td style="border-bottom: 1px solid #9999; height: 18px; border-left: 0px; border-right: 0px;
                                    border-top: 0px">
                                     <div class="TooltipVal" data-maxlength="10">
                                        <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnContactNumber" runat="server" Value='<%# Eval("ContractNumber") %>' />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 0px; height: 18px;">
                                    <asp:Label ID="Quantity" Text='<%# (Eval("ContractQty") == DBNull.Value  || (Eval("ContractQty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("ContractQty")).ToString("N0") %>'
                                        runat="server"></asp:Label>
                                    <span style="color: gray;font-weight:600">Pcs.</span>
                                </td>
                            </tr>                            
                        </table>
                    </ItemTemplate>
                    <ItemStyle Width="80px" CssClass="ContactNoCol" />
                    <HeaderStyle CssClass="ContactNoCol" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Accessory Detail (Size)/Color Print<br>Average">
                    <ItemTemplate>
                        <asp:Label ID="lblAccessoriesDetail" runat="server" ForeColor="blue" Text='<%# Eval("TradName") %>'></asp:Label>
                        <asp:Label ID="lblSize" runat="server" ForeColor="gray" Text='<%# Eval("Size") %>'></asp:Label><span>/</span><asp:Label ID="lblColorPrint" ForeColor="black" Font-Bold="true" runat="server" Text='<%#Eval("Color_Print") %>'></asp:Label><span>/</span><asp:Label ID="lblAverage" ForeColor="black" Font-Bold="true" runat="server" Text='<%#Eval("AccessoryAvg") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="200px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Actual Required <span style='color:gray;font-size:10px;position: relative;top:4px;'>Contract * Avg.</span>">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalAccessoriesRequired" runat="server" Text='<%# Eval("totalRequired") %>'></asp:Label>
                        <asp:Label ID="Unit1" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# " " + Eval("GarmentUnitName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60px" HorizontalAlign="center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Available Qty. To Issue">
                    <ItemTemplate>
                        <asp:Label ID="lblAvailableQtyToIssue" runat="server" Text='<%# Eval("AvailableQtyToIssued") %>'></asp:Label>
                          <asp:Label ID="Unit2" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# " " + Eval("GarmentUnitName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60px" HorizontalAlign="center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Raise Request">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="border: 0px">
                                    <asp:CheckBox ID="cbIssueRequest" runat="server" Enabled="false" onchange="UpdateRaiseIssueReq(this)" />
                                </td>
                                <td style="border: 0px; text-align: center;">
                                    <asp:HiddenField ID="hdnIssueRequest" runat="server" Value='<%# Eval("IsIssueRequest") %>' />
                                    <asp:Label ID="lblRequestDate" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle Width="65px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Required Qty.</br> (Include Wastage)">
                    <ItemTemplate>
                        <asp:Label ID="lblRequiredQty" runat="server" Text='<%# Eval("RequiredQty") %>'></asp:Label>
                          <asp:Label ID="Unit3" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# " " + Eval("GarmentUnitName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="70px" HorizontalAlign="center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%; height: 100%;" class="innertable">
                            <tr>
                                <td style="border: 0px; border-right: 1px solid #999;color:#6b6464">
                                    Challan No.
                                </td>
                                <td style="border: 0px;border-right: 1px solid #999;color:#6b6464">
                                    Issued Qty
                                </td>
                                <td style="border: 0px;color:#6b6464">
                                    Issued On
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="challanCol" />
                    <ItemTemplate>                    
                        <div id="dvChallanDetails" runat="server" class="clsChallan_Table">
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="180px" />
                </asp:TemplateField>    
                 
                <asp:TemplateField HeaderText="Issue Complete">
                    <ItemTemplate>     

                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td style="border: 0px; text-align: left;">
                                    <asp:CheckBox ID="cbIssueComplete" runat="server" Enabled="false" onchange="UpdateRaiseIssueReq(this)" />
                                </td>
                                <td style="border: 0px; text-align: center;">
                                    <asp:Label ID="lblIssueCompleteDate" runat="server" style="position:relative;" Text=""></asp:Label>
                                   <asp:HiddenField ID="hdnIssueComplete" runat="server" Value='<%# Eval("IsCompleteIssue") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle Width="60px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Stock Moved Qty.<br />Debit Qty.">
                    <ItemTemplate>
                        <asp:Label ID="lblStockQty" runat="server" Text=""></asp:Label>
                        
                         <asp:Label ID="lblDebitQty" runat="server" Text=""></asp:Label>                                                  
                    </ItemTemplate>
                    <ItemStyle Width="105px" CssClass="TxtRight" HorizontalAlign="right" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="GrdGriegeTable" cellspacing="0" cellpadding="0" rules="all" border="0" id="grdAccessory" style="border-width:0px;width:1136px;border-collapse:collapse;">
                  <tr>
			        <th class="StyleContextupH" scope="col"><div>Style No.</div></th>
                    <th class="SrNoContextupH" scope="col"><div>Sr. No.</div></th>
                    <th class="ContactNoCol" scope="col">
                                <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0">
                                    <tbody><tr>
                                        <td style="border-bottom: 1px solid #ddd7d7; border-top: 0px; border-right: 0px;
                                            border-left: 0px;color:#6b6464">
                                            Contract No.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 0px;color:#6b6464">
                                            Quantity
                                        </td>
                                    </tr>
                                </tbody></table>
                            </th>
                    <th scope="col">Accessory Detail (Size)/Color Print<br />Average</th>
                    <th scope="col">Actual Required </br><span style="color:gray;font-size:10px;position: relative;top:4px;">Contract * Avg.</span></th>
                    <th scope="col">Available Qty. To Issue</th>
                    <th scope="col">Raise Request</th>
                    <th scope="col">Required Qty.(Include Wastage)</th>
                    <th class="challanCol" scope="col">
                        <table style="width: 100%; height: 100%;" class="innertable">
                            <tbody><tr>
                                <td style="border: 0px; border-right: 1px solid #999;;color:#6b6464">
                                    Challan No.
                                </td>
                                <td style="border: 0px;;color:#6b6464">
                                    Total Issued
                                </td>
                            </tr>
                        </tbody></table>
                    </th>
                    <th scope="col">Issue Complete</th>
                    <th scope="col">Stock Moved <br />Debit Qty.
                    </th>
		        </tr>
                <tr>
                   <td colspan="11" style="border: 1px solid #999 !important;text-align:center;border-top: 0px !important;">
                       <img src="../../images/sorry.png" />
                   </td>
                </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    </div>
    </form>
</body>
</html>
