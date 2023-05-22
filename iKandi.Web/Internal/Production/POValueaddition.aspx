<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POValueaddition.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.POValueaddition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            font-family: sans-serif !important;
            margin: 0px;
            padding: 0px;
            font-size: 11px;
        }
        input[type='text']
        {
            border-radius: 2px;
            border: 1px solid #cccccc;
            text-transform: captilize;
            font-size: 11px;
            width: 90%;
            padding-left: 3px;
        }
        .debitnote-table
        {
            font-family: sans-serif !important;
        }
        .debitnote-table .top_heading
        {
            text-align: center;
            text-transform: capitalize;
            font-size: 25px;
            font-weight: 700;
            padding-top: 11px;
            color: #313131;
        }
        
        .debitnote-table .Srnon
        {
            font-weight: 600;
            font-size: 13px;
        }
        tbody td
        {
            border: 0;
            padding: 3px 3px;
        }
        .address_Company
        {
            color: #767676;
            font-size: 12px;
            line-height: 17px;
        }
        .btnbutton
        {
            background: #1976D2;
            color: #fff;
            border: 1px solid #1976d2;
            padding: 2px 5px;
            border-radius: 3px;
            font-size: 11px;
            cursor: pointer;
        }
        .textcenter
        {
            text-align: center;
        }
        
        input
        {
            font-size: 11px;
        }
        .address_head
        {
            color: #2d2b2b;
            font-size: 12px;
            line-height: 17px;
        }
        ul li
        {
            line-height: 14px;
            color:#757373;
            text-align: justify;
        }
        li
        {
            margin-bottom: 3px;
            padding-right: 10px;
            font-size: 8px;
        }
        input[type="checkbox"]
        {
            position: relative;
            top: 3px;
        }
        textarea
        {
            width: 90%;
            border-radius: 4px;
        }
        td.padding-left
        {
            padding-left: 9px;
        }
        input[type='radio']
        {
            position: relative;
            top: 2px;
        }
        .ViewHistory
        {
            color: Blue;
            font-size: 12px;
            cursor: pointer;
        }
        input[type=text], textarea
        {
            text-transform: capitalize !important;
        }
        .btnClose
        {
            margin-left: 5px;
            font-size: 11px !important;
            color: rgb(255, 255, 255);
            font-weight: normal;
            background: #39589c !important;
            height: 20px;
            line-height: 20px;
            border: none !important;
            border-radius: 2px;
            padding: 3px 8px;
            cursor: pointer;
        }
         .btnClose:hover
        {
          color:Red;
        }
        .btnPrint
        {
             margin-left: 5px;
            font-size: 11px !important;
            color: rgb(255, 255, 255);
            font-weight: normal;
            background: #39589c !important;
            height: 20px;
            line-height: 20px;
            border: none !important;
            border-radius: 2px;
            padding: 3px 8px;
            cursor: pointer;
        }
        .ui-widget-content
        {
            border:0px !important;
            background:#fff !important;
         }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
             .btnhidebutton
            {
                display:none;
             }
             .printLeftP
             {
                 padding:0px 0px 0px 4px !important;
               
             }
        }
         .backColor
         {
                background: #c1c1c1;
                width: 44%;
                padding: 2px 10px;
                border-radius: 2px;
          }
       #divtablecontent{
              position: absolute;
              background-color: white;
              display:none;
              top:23px;
         }
         
       #opentbl:hover + #divtablecontent
       {
           display:block;
           }  
       #divtablecontent table
       {
            border-collapse: collapse;
            box-shadow: 2px 3px 6px 2px #cccc;
            background-color: white;
            width:250px;
            }
            
       #divtablecontent table:after
       {
            content: "";
            position: absolute;
            top: -6px;
            left: 54px;
            width: 0;
            height: 0;
            border-right: 8px solid transparent;
            border-bottom: 8px solid #A5E5FF;
            border-left: 8px solid transparent;

           } 
      #divtablecontent table tr:first-child
      {
            background: #A5E5FF !important;
            border: 1px solid #b9edff;
            border-collapse: collapse;
            font-size: 10px;
            font-weight: 500;
            padding: 3px 3px;
            color: #4a4a4a;
            font-family: Arial;
            text-align: center ;
        
          }
      #divtablecontent table tr:first-child td
      {
          border: 1px solid #b9edff;
          }
      #divtablecontent table tr td
      {
            border: 1px solid #b9edff !important;
            font-size: 9px;
            padding: 3px 3px !important;
            color: #6b6464;
            font-family: Arial;
            text-align: center !important;
            vertical-align: middle !important;
        
          }
    </style>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.datepiker').datepicker({
                minDate: 0,
                dateFormat: 'd M y'
            });
            $('.DisplayNone').hide()
            $(".ViewHistory").click(function () {
                $(".HistoryCon").toggle('slow');
            })
        });

        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57 || iKeyCode == 46))
                return false;
            return true;
        }

        function isNumberKeyfloat(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            return true;
        }

        function KeyPressFalse(evt) {
            return false;
        }

        function ValidateDateofIssue() {
            if ($('#txtDateofIssue').val() == '') {
                alert('Date of Issue cannot blank!');
                $('#txtDateofIssue').focus();
                return false;
            }
        }

        function ValidateAgreedQty() {
            if ($('#txtAgreedQty').val() == '') {
                alert('Agreed Qty. cannot blank!');
                $('#txtAgreedQty').focus();
                return false;
            }
        }
        function funcReloadClosePO() {
            //alert();
            debugger;
            window.parent.location.href = window.parent.location.href;
            self.parent.Shadowbox.close();
        }

        function closeMe() {
            if (self.parent.Shadowbox) {
                self.parent.Shadowbox.close();
            }
            else {

                window.opener = self;
                window.close();
            }
        }


//        $(document).ready(function () {

//            $("#opentbl").click(function () {
//                $("#divtablecontent").toggle();
//            });
//        });
    </script>

</head>
<body>
    <form id="form1" autocomplete="off" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="debitnote-table" style="max-width: 835px;min-width: 680px; margin: 5px auto;">
                <div runat="server" id="divPO">
                    <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999;"
                        cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td style="width: 130px;">
                                    <div style="max-width: 110px; text-align: center; padding: 5px 0px; position: relative;
                                        margin: 0 auto;">
                                        <img src="../../images/200x50%20bipllog.png" />
                                    </div>
                                </td>
                                <td style="width: 500px;">
                                    <span class="top_heading">Value Addition Purchase Order</span>
                                </td>
                            </tr>
                        </thead>
                    </table>
                    <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999;
                        border-top: 0px; padding-left: 8px; padding-bottom: 5px;" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td>
                                    <span class="address_Company"><b>Boutique International Private Limited</b><br>
                                    </span><span class="address_head">C 45-46 Hosiery Complex, Noida Phase-2<br>
                                        UP-201305(U.P.)</span><b style="color:#545454;">Office:</b><span class="address_head"> +91 120 6797979</span><br />
                                    <span><b style="color:#545454;">TIN NO: </b><span class="address_head">09765708265 </span><b style="color:#545454;">GSTIN:</b> <span
                                        class="address_head">099AAACB4905C1Z5</span></span>
                                </td>
                                <td>
                                    <%-- <asp:HiddenField ID="hdnRiskVASupplierid" runat="server" />--%>
                                </td>
                            </tr>
                        </thead>
                    </table>
                    <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999;
                        padding-left: 0px; padding-top: 5px" cellspacing="0" cellpadding="0">
                        <tbody>
                            <tr>
                                <td style="width: 80px;color:#999" class="padding-left">
                                    Supplier Name
                                </td>
                                <td style="width: 190px">
                                    <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                                </td>
                                <td style="width: 135px;color:#757373;position:relative;">
                                    
                                    <span id="opentbl" style="cursor:pointer;font-weight:600;">Agreed Rate</span>
                                    <div id="divtablecontent" runat="server"> </div>
                                </td>
                                <td style="width: 190px">
                                    <asp:TextBox ID="txtAgreedRate" runat="server" onkeypress="javascript:return isNumberKeyfloat(event)"
                                        MaxLength="9"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-left" style="color:#999">
                                    PO No.
                                </td>
                                <td>
                                    <asp:Label ID="lblPoNumber" runat="server"></asp:Label>
                                </td>
                                <td style="color:#999">
                                    Delivery Starts From (Date)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeliveryStartDate" CssClass="datepiker" style="width:50%" runat="server" onkeypress="javascript:return KeyPressFalse(event)"></asp:TextBox>
                                    <asp:Label ID="lblUserStatrt" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-left" style="color:#999">
                                    Date of Issue
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateofIssue" CssClass="datepiker"  runat="server" onkeypress="javascript:return KeyPressFalse(event)"
                                        onchange="ValidateDateofIssue();"></asp:TextBox>
                                       <asp:HiddenField ID="hdnPOIssuedate" runat="server" />
                                </td>
                                <td style="color:#999">
                                    Delivery Ends From (Date)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeliveryEndDate" CssClass="datepiker"  style="width:50%" runat="server" onkeypress="javascript:return KeyPressFalse(event)"></asp:TextBox>
                                      <asp:Label ID="lblUserEnd" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-left" style="color:#999">
                                    Serial No.
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSerialNumber" Enabled="false" runat="server"></asp:TextBox>
                                    <%--  <asp:Label ID="lblSerialNo" runat="server"></asp:Label>--%>
                                </td>
                                <td style="color:#999">
                                    Actual Ends (Date)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActualEndDate" CssClass="datepiker" runat="server" onkeypress="javascript:return KeyPressFalse(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-left" style="color:#999">
                                    Style No.
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStyleNumber" Enabled="false" runat="server"></asp:TextBox>
                                    <%--<asp:Label ID="lblStyleNumber" runat="server"></asp:Label>--%>
                                </td>
                                <td style="color:#999">
                                    Debit for Late Delivery
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDebitforLateDelivery" runat="server" onkeypress="javascript:return isNumberKeyfloat(event)"
                                        MaxLength="9"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-left" style="color:#999">
                                    SAM
                                </td>
                                <td>
                                    <asp:Label ID="lblSAM" runat="server"></asp:Label>
                                </td>
                                <td style="color:#999">
                                    Debit For Alteration
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDebitforAlteration" CssClass="number-only allow_decimal" runat="server"
                                        onkeypress="javascript:return isNumberKeyfloat(event)" MaxLength="9"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-left" style="color:#999">
                                    Agreed Qty.
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAgreedQty" runat="server" Width="59%" onkeypress="javascript:return isNumber(event)"
                                        onchange="ValidateAgreedQty();" MaxLength="9"></asp:TextBox>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlUnit" runat="server">
                                        <asp:ListItem>pcs</asp:ListItem>
                                        <asp:ListItem>Meter</asp:ListItem>
                                        <asp:ListItem>kg</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="color:#999">
                                    Type of Job
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlJob" runat="server"></asp:DropDownList>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-left" style="color:#999">
                                    Remarks
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtArea" TextMode="MultiLine" Width="96%" runat="server"></asp:TextBox>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 20px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 20px; style="color:#999" font-size: 15px; font-weight: 700;" class="padding-left">
                                    Terms & Conditions
                                </td>
                            </tr>
                            <tr>
                                 <td colspan="4" style="font-size: 9px;">
                                    <ul>
                                        <li>All bills and challans against an order must state our purchase order number.</li>
                                        <li>Vendor must quote prices based on examining the sample in BIPL. Pcs or material cannot
                                            be taken out of premises.</li>
                                        <li>Bulk cutting will only be issued once 2 Pcs have been passed by CQD in presence
                                            of proper report and technician from vendor present. Also PO must be signed for
                                            rate, quantity and delivery by vendor and counter signed by BIPL management.
                                        </li>
                                        <li>All Goods to be delivered in Poly Bags. If any goods found to be delivered without
                                            the poly bags, Company has full right to put damage and rescan charges on to the
                                            supplier. </li>
                                        <li>No invoices/bills will be entertained without PO duly signed by the management
                                            of the company.</li>
                                        <li>Any Pcs stitched outside of agreed premises will be liable for 100% agreed price
                                            discount and discontinuation of further orders.</li>
                                        <li>All bills must be put within 5 days of completion of the style and 8 days prior
                                            to the 30th of every month after which bills will not be accepted. Payment cycle is
                                            10th-15th and 26th-30th of every month. </li>
                                        <li>All Samples, fabric, rejected cutting and accessories should be returned along with
                                            the last lot of delivery of goods. Anything returned after the shipment leaves will
                                            not be accepted and supplier will be liable for the same. </li>
                                        <li>Dates committed on the PO must be adhered for agreed quantity. Every single day delay
                                            will cost ₹1 per piece to the supplier as late delivery charges.</li>
                                            <li>No single piece should be dispatched from the stitching unit without QC report. Any pieces sent without the report will be returned back on suppliers cost. </li>
                                        <li>Factory Manager/BIPL management holds the full right to debit for any alteration
                                            in the pieces.</li>
                                        <li>All goods should be submitted or kept on the checking table of the factory and acknowledged
                                            by the company’s issue/receiving team within working hours only. </li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 15px; padding-bottom: 5px; text-align: right;">
                                    <span style="padding-right: 17px;" class="btnhidebutton"><b>Is Mail Send </b></span>
                                    <br />
                                    <span style="padding-right: 10px;">
                                        <asp:RadioButton ID="rdbYes" runat="server" CssClass="btnhidebutton" GroupName="ScanOnStartupRadio" AutoPostBack="false"
                                            Checked="false" Text="Yes" />
                                        <asp:RadioButton ID="rdbNo" runat="server" CssClass="btnhidebutton" GroupName="ScanOnStartupRadio" AutoPostBack="false"
                                            Checked="true" Text="No" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align:center">
                                    <table border="0" cellpadding="0" cellspacing-"0" style="width:100%">
                                     <tr>
                                       <td style="min-width:200px;padding-left:25px;padding-bottom:0px;" class="printLeftP">
                                          <asp:Label ID="lblVendorName" runat="server"></asp:Label>
                                       </td>
                                       <td style="min-width:200px;padding-left:10px;padding-bottom:0px;" class="printLeftP">
                                        <asp:Label ID="lblManagmentName" runat="server" Text="Samrat Verma" Visible="false"></asp:Label>
                                       </td>
                                        <td style="min-width:200px;padding-left:38px;padding-bottom:0px;" class="printLeftP">
                                         <asp:Label ID="lblGMName" runat="server" Text="Karan Gupta" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                       <td style="min-width:200px">
                                        <asp:CheckBox ID="chkVendorSig" runat="server" CssClass="btnhidebutton" Enabled="false" />
                                         <b>Vendor Signature</b>
                                       </td>
                                       <td style="min-width:200px">
                                         <asp:CheckBox ID="chkBIPLMngtSig" CssClass="btnhidebutton" runat="server" Enabled="false" />
                                        <b>BIPL Management</b>
                                       </td>
                                        <td style="min-width:200px">
                                        <asp:CheckBox ID="chkGMPlanningSig" CssClass="btnhidebutton" runat="server" />
                                        <b>GM Planning/Out House</b>
                                        </td>
                                    </tr>
                                     <tr>
                                       <td style="min-width:200px;padding:5px 0px 0px 31px" class="printLeftP">
                                        <asp:Label ID="lblVendorSigDate" runat="server"></asp:Label>
                                       </td>
                                       <td style="min-width:200px;padding:5px 0px 0px 29px" class="printLeftP">
                                       <asp:Label ID="lblBIPLMgntSigDate" runat="server"></asp:Label>
                                       </td>
                                        <td style="min-width:200px;padding:5px 0px 0px 38px" class="printLeftP">
                                         <asp:Label ID="lblGMPlanningSigDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                 </table>
                                    </span>
                                </td>
                            </tr>
                          
                            <%--<tr>
                                <td colspan="4" style="height: 30px;">
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="4" style="text-align: center; border-bottom: 1px solid #999; margin: 5px 0px;">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnbutton btnhidebutton" OnClick="btnSave_Click"
                                        Text="Submit" />
                                    <span class="btnClose btnhidebutton" onclick="javascript:closeMe();">Close</span>
                                    <span class="btnPrint btnhidebutton" onclick="window.print();return false">
                                        Print</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="margin-top: 5px; width: 100%;" class="btnhidebutton">
                    <span class="ViewHistory">View History</span><br />
                    <span style="display: none;" class="HistoryCon">
                        <div runat="server" id="divHistory">
                        </div>
                    </span>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
