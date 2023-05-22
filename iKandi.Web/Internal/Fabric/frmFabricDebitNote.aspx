<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFabricDebitNote.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.frmFabricDebitNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <style>
        .FabricCreaditNote
        {
            max-width: 100%;
            margin: 0 auto;
            font-family: Arial;
        }
        .top_heading
        {
            text-transform: capitalize;
            font-size: 16px;
            font-weight: 500;
            padding-top: 3px;
            text-align: center;
            padding-bottom: 2px;
            background: #39589c;
            color: #fff;
        }
        .address_head
        {
            font-weight: 500;
            font-size: 11px;
            line-height: 15px;
        }
        .border_right
        {
            border-right: 1px solid #999;
        }
        .border_left
        {
            border-left: 1px solid #999;
        }
        .headerbold
        {
            background: #e4e2e2;
            text-align: center;
            border-right: 1px solid #999999;
        }
        .gridtable td
        {
            border-bottom: 1px solid #dbd8d8;
        }
        .txtwdth
        {
            width: 69%;
        }
        .txtbillwidth
        {
            width: 45%;
        }
        input
        {
            font-size: 10px !important;
        }
        .txtdatewidth
        {
            width: 54%;
        }
        .inputfildwidth
        {
            width: 95% !important;
        }
        
        .grdviewtable th
        {
            background: #e4e2e2;
            text-align: center;
            font-weight: 500;
            font-size: 11px !important;
             color:#6b6464;
        }
        .grdviewtable td
        {
            text-align: center;
            font-size: 11px !important;
        }
        .emptytable th
        {
            background: #e4e2e2;
            text-align: center;
        }
        .emptytable td
        {
            text-align: center;
        }
        .grdviewtable
        {
            border-top: 0px;
            max-width: 100%;
            min-width:100%;
        }
        .grdviewtable th
        {
            border-top: 0px;
            border-color: #999;
            color:#6b6464;
            
        }
        .btnClose
        {
            margin-left: 10px;
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnClose:hover
        {
            color: red;
        }
        .btnSubmit
        {
            margin-left: 10px;
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
        }
        .btnPrint
        {
            margin-left: 10px;
            font-size: 12px !important;
            float: left;
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: #39589c !important;
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        .footerClass td
        {
            border-bottom-color: #999;
        }
        .footerClass td:first-child
        {
            border-left-color: #999;
        }
        .footerClass td:last-child
        {
            border-right-color: #999;
        }
        a
        {
            text-decoration: none;
        }
        .bottomtable td
        {
            font-size: 11px;
        }
        input[type='text']
        {
            font-size: 11px !important;
            padding-left: 2px;
            border-radius: 2px;
            font-family: Arial;
        }
        .txtEditWidth
        {
            width:97% !important;
            text-align:left;
         }
          .txtEditWidth2
        {
            width: 88% !important;
            text-align: center;
         }
         .TaskFabricTable
         {
             width:800px !important;
             margin-top: 5px;
          }
        /*
       code added by bharat on 21-june
       Click Print button the hide botton
         
       */
        @media print
        {
              body
            {
                -webkit-print-color-adjust: exact;
            }
            .printHideButton
            {
                display: none;
            }
        }
        
        .indianCurr::after {
          content: "₹";
          color: green;
        }
               /* .indianCurr
        {
            background: url(../../images/inr_symbol.png) no-repeat left top;
            padding-left: 12px;
            position: relative;
            top: 2px;
            color: green;
         }*/
        /** End */
        input[type=text], textarea {
    border: 1px solid #cccccc;
    text-transform:capitalize;
    font-size: 11px;
   
    </style>
    <script>
        $(document).ready(function () {
            //            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            //            function EndRequestHandler(sender, args) {
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            //            }



            $(".debnumericval").keypress(function (e) {
                //alert();
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });

        });
        function isNumberKey(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        function isNumberKeydec(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function numbersonly(elem) {
            //debugger;
            var value = elem.value;
            if (value != "") {
                if (value == undefined) {
                    var regs = /^\d*[0-9](\d*[0-9])?$/;
                    if (value != "") {
                        if (regs.exec(elem) && elem.srcElement.value.split('.').length > 1) {
                            return true;
                        }
                        else {
                            //elem.value = elem.defaultValue;
                            elem.value = "";
                            return false;
                        }
                    }
                }
                else {
                    //var regs = /^\d*[0-9](\.\d*[0-9])?$/;
                    var regs = /^(-)?\d+(\d\d)?$/;
                    if (value != "") {
                        if (regs.exec(value) && elem.srcElement.value.split('.').length > 1) {
                            return true;
                        }
                        else {
                            // elem.value = elem.defaultValue;
                            elem.value = "";
                            return false;
                        }
                    }
                }
            }

        }
        function Debitnote_Validation() {
            //alert();
            var DebitNo = $('[id*=txtDebitNoteNumber]').val();
            var debitagaistbill = $('[id*=txtAgainstBillNo]').val();
            var ReturnChallan = $('[id*=txtReturnChallan]').val();

            if (DebitNo == "") {
                alert("Please Enter Debit Number");
                return false;
            }

            if (debitagaistbill == "") {
                alert("Please Enter Against Your Bill Number");
                return false;
            }

            //            if (ReturnChallan == "") {
            //                alert("Please Enter Returned Challan Number");
            //                return false;
            //
            debugger;

            var totalRows = $('[id*=hdnrowcount]').val();

            if (totalRows < 2) {
                alert("Please Enter at least one debit note amount");
                return false;
            }
        }
        function callparentpage() {
            //            debugger;
            window.parent.CallThisPage();
        }
        function CallSupplierChallanForm(SupplierPoID) {
            //alert("ss");

            window.top.location.replace("FabricSupplierChallanDetails.aspx?SupplierPoID=" + SupplierPoID);
        }
        // code added by bharat on 17-july
        function pageLoad() {
            var hdnDebiNOtID = $('[id*=hdnDebitnotid]').val();
          //  alert(hdnDebiNOtID);
            if (hdnDebiNOtID == 0) {
                $('.FabricCreaditNote').addClass('TaskFabricTable');
           }
        }
        function CloseFun() {
            var hdnDebiNOtID = $('[id*=hdnDebitnotid]').val();
            if (hdnDebiNOtID == 0) {
                window.open('', '_parent', '');
                window.close();
            }
            else {
                self.parent.Shadowbox.close();
            }
        }
        //end
    </script>
</head>
<body>
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <%-- <script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>--%>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <form id="form1" runat="server" autocomplete="off">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div class="FabricCreaditNote">
            <asp:HiddenField ID="hdnrowcount" runat="server" />
              <asp:HiddenField ID="hdnDebitnotid" runat="server" />
                <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-bottom: 0px solid #999999"
                    cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="3" class="top_heading">
                                Fabric Debit Note
                            </td>
                        </tr>
                        <tr>
                           <td style="vertical-align:top;width:125px;">
                              <div style="padding:9px 7px">
                                    <img src="../../images/boutique-logo.png"/>
                              </div>
                            </td>
                            <td style="width: 400px; text-align: center;border-left:0px">
                               <%-- <span class="address_head">H.O. C-45-46 Hosiery Complex Phase-II Extn. NOIDA-201305 (U.P)</span><br />
                                <span class="address_head">Tel. +911206797979, Fax:- 6797999, E-mail-boutique@boutique.in</span>--%>
                                <div id="divbipladdress" runat="server" ></div>
                            </td>
                            <td style="width: 150px; font-size: 11px;">
                                <span style="color:#6b6464;">Debit Number:</span>
                                <asp:TextBox ID="txtDebitNoteNumber" Enabled="false" onkeyup="numbersonly(this)"
                                    Style="width: 85px;" runat="server" Text='<%# Eval("DebitNoteNumber") %>'></asp:TextBox>
                                <span id="errmsg"></span>
                            </td>
                        </tr>
                        <%--<tr>
                    <td colspan="3" style="padding-bottom: 15px;">
                    </td>
                </tr>--%>
                    </thead>
                </table>
                <table class="gridtable" style="max-width: 100%; width: 100%; border: 1px solid #999999;
                    border-bottom: 0px solid #999999; border-top-color: #dbd8d8;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                            <td style="width: 200px; font-size: 12px; padding: 5px; border-top-color: #dbd8d8">
                                <span style="padding-bottom: 10px;color:#6b6464;">M/S:</span>
                                <asp:Label ID="lblSupllierName" Text='<%# Eval("DebitSupplierName") %>' runat="server"></asp:Label>
                            </td>
                            <td style="width: 98px; font-size: 11px; border-right: 1px solid #dbd8d8; border-top-color: #dbd8d8">
                              <span style='color:#6b6464;'> Date: </span> 
                                <asp:TextBox ID="txtDate" runat="server" onkeypress="return false;" CssClass="th style-eta date_style txtwdth"
                                    Text='<%# Eval("DebitChallanDate") %>'></asp:TextBox>
                            </td>
                            <td style="width: 140px; font-size: 11px; padding-left: 5px; border-top-color: #dbd8d8">
                                <span style='color:#6b6464;'>Against Bill No.</span>
                                <asp:TextBox ID="txtAgainstBillNo" style="text-transform:uppercase;" CssClass="txtbillwidth" Text='<%# Eval("DebitAgaistBillNo") %>'
                                    runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 130px; font-size: 11px; border-top-color: #dbd8d8">
                                <span style='color:#6b6464;'>PO Bill Date: </span>
                                <asp:TextBox ID="txtPodate" runat="server" CssClass="th txtdatewidth"></asp:TextBox>
                                <%--<asp:Label ID="lblPodate" runat="server" Text='<%# Eval("debitPodate") %>' CssClass="txtdatewidth"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding: 5px 5px; font-size: 11px; border-bottom-color: #999">
                                We have Debited your account as per details given below:-
                            </td>
                        </tr>
                    </thead>
                </table>
                <asp:GridView ID="grdFabricdabitnote" runat="server" CssClass="grdviewtable" AutoGenerateColumns="false"
                    OnRowDataBound="grdFabricdabitnote_RowDataBound" OnRowCommand="grdFabricdabitnote_OnRowCommand"
                    OnRowDeleting="grdFabricdabitnote_RowDeleting" ShowFooter="true" OnRowEditing="grdFabricdabitnote_RowEditing"
                    OnRowUpdating="grdFabricdabitnote_RowUpdating" OnRowCancelingEdit="grdFabricdabitnot_RowCancelingEdit">
                    <FooterStyle CssClass="footerClass" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                <asp:HiddenField ID="hdnDebitnote" runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                <asp:HiddenField ID="hdnDebitnote" runat="server" />
                            </EditItemTemplate>
                            <ItemStyle Width="50" CssClass="border_left" />
                            <HeaderStyle Width="44" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Particulars">
                            <ItemTemplate>
                                <asp:Label ID="lblFabricDebitParticur" style="text-transform:capitalize;" runat="server" Text='<%# Eval("Particulers") %>'></asp:Label>
                                <asp:HiddenField ID="Id" runat="server" Value='<%# Eval("DebitNote_Particulers_Id") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditParticulars" CssClass="txtEditWidth" runat="server" Text='<%# Eval("Particulers") %>'></asp:TextBox>
                                <asp:HiddenField ID="Id" runat="server" Value='<%# Eval("DebitNote_Particulers_Id") %>' />
                                <asp:RequiredFieldValidator ID="rfvParticularEdit" runat="server" Display="None"
                                    ValidationGroup="Edit" ControlToValidate="txtEditParticulars" ErrorMessage="Enter Debit Particular"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="fo_txtFbaricDebitParticular" Width="97%" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvParticularEdit" runat="server" Display="None"
                                    ValidationGroup="Foter" ControlToValidate="fo_txtFbaricDebitParticular" ErrorMessage="Enter Debit Particular"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemStyle Width="550" />
                            <FooterStyle Width="550" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblDebitQty" style="text-transform:capitalize;"  runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                <asp:Label ID="lblunits" style="text-transform:capitalize;color:Gray;font-weight:600"  runat="server" ></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditQty" MaxLength="8" CssClass="txtEditWidth2" onkeypress="return isNumberKey(event)"
                                    Text='<%# Eval("Quantity") %>' runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQtyEdit" runat="server" Display="None" ValidationGroup="Edit"
                                    ControlToValidate="txtEditQty" ErrorMessage="Enter Particular Qty"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="fo_txtFbaricDebitQty"  CssClass="txtEditWidth2" MaxLength="8" onkeypress="return isNumberKey(event)"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQtyFooter" runat="server" Display="None" ValidationGroup="Foter"
                                    ControlToValidate="fo_txtFbaricDebitQty" ErrorMessage="Enter Qty"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemStyle Width="70" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate">
                            <ItemTemplate>
                              <span class="indianCurr"></span>
                                <asp:Label ID="lblDebitRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditRate" MaxLength="5" CssClass="txtEditWidth2" onkeypress="return isNumberKeydec(event)"
                                    runat="server" Text='<%# Eval("Rate") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRateEdit" runat="server" Display="None" ValidationGroup="Edit"
                                    ControlToValidate="txtEditRate" ErrorMessage="Enter Qty Rate"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="fo_txtFabricDebitRate"  CssClass="txtEditWidth2" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvParticularfoter" runat="server" Display="None"
                                    ValidationGroup="Foter" ControlToValidate="fo_txtFabricDebitRate" ErrorMessage="Enter Qty Rate"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <FooterStyle Width="50" />
                            <ItemStyle Width="50" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                            <span class="indianCurr"></span>
                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Eval("TotalAmt") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                               <div id="indianCurrS" runat="server"></div>
                                <asp:Label ID="FolblTotalAmount" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" />
                                </asp:LinkButton>
                                <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lkUpdate" runat="server" ValidationGroup="Edit" CausesValidation="true"
                                    CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px;" />
                                </asp:LinkButton>
                                <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel">
                                     <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 3px;"/>
                                </asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="Submit" OnClick="btn_AddDebitNote" ValidationGroup="Foter"
                                    CommandName="Insert">
                                  <img src="../../images/add-butt.png" />
                                </asp:LinkButton>
                            </FooterTemplate>
                            <ItemStyle Width="100" CssClass="border_right" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" class="emptytable" cellspacing="0" width="100%" style="width: 983px;
                            border-top: 0px solid !important; border-color: #999">
                            <tr>
                                <th style="width: 50px; border-right: 1px solid #999">
                                    S No.
                                </th>
                                <th style="width: 350px; border-right: 1px solid #999">
                                    Particulars
                                </th>
                                <th style="width: 100px; border-right: 1px solid #999">
                                    Quantity
                                </th>
                                <th style="width: 100px; border-right: 1px solid #999">
                                    Rate
                                </th>
                                <th style="width: 100px; border-right: 1px solid #999">
                                    Amount
                                </th>
                                <th style="width: 100px;">
                                    Action
                                </th>
                            </tr>
                            <tr>
                                <td style="border-right: 1px solid #999">
                                    &nbsp;
                                </td>
                                <td style="border-right: 1px solid #999">
                                    <asp:TextBox runat="server" ID="txtFbaricDebitParticular" CssClass="inputPartidwidth"
                                        Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvParticular" runat="server" Display="None" ValidationGroup="Empty"
                                        ControlToValidate="txtFbaricDebitParticular" ErrorMessage="Enter Debit Particular"></asp:RequiredFieldValidator>
                                </td>
                                <td style="border-right: 1px solid #999">
                                    <asp:TextBox runat="server" ID="txtDebitQty" MaxLength="8" onkeypress="return isNumberKey(event)"
                                        Width="80" CssClass="inputfildwidth" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                                        ValidationGroup="Empty" ControlToValidate="txtDebitQty" ErrorMessage="Enter Debit Qty"></asp:RequiredFieldValidator>
                                </td>
                                <td style="border-right: 1px solid #999">
                                    <asp:TextBox runat="server" ID="txtDebitRate" MaxLength="5" onkeypress="return isNumberKeydec(event)"
                                        Width="80" CssClass="inputfildwidth" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                                        ValidationGroup="Empty" ControlToValidate="txtDebitRate" ErrorMessage="Enter Quantity Rate"></asp:RequiredFieldValidator>
                                </td>
                                <td style="border-right: 1px solid #999">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="Submit" OnClick="btn_AddDebitNote" ValidationGroup="Empty"
                                        CommandName="EmptyInsert">
                            <img src="../../images/add-butt.png" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                       
                    </EmptyDataTemplate>
                </asp:GridView>
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Empty"
                            ShowMessageBox="true" ShowSummary="false" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Foter"
                            ShowMessageBox="true" ShowSummary="false" />
                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="Edit"
                            ShowMessageBox="true" ShowSummary="false" /> 
                            <div style="max-width: 100%; border-left:1px solid #999;border-right:1px solid #999; height:15px;"></div>
                <div class="bottomtable">
                    <table style="max-width: 100%; width: 100%; border: 1px solid #999999; border-collapse: collapse;
                       ">
                        <tbody>
                            <tr>
                                <td style="width: 137px; border-bottom: 1px solid #999999;padding-left: 5px;">
                                    Returned Challan No. <span></span>
                                </td>
                                <td style="border-right: 1px solid #999999; width: 118px; border-bottom: 1px solid #999999">
                                    <asp:TextBox ID="txtReturnChallan" Width="90%" Enabled="false" runat="server" Text='<%# Eval("DebitChallanReturnNo") %>'></asp:TextBox>
                                </td>
                                <td style="width: 32px; border-bottom: 1px solid #999999;padding-left: 2px;">
                                    Date:
                                </td>
                                <td style="border-right: 1px solid #999999; width: 100px; border-bottom: 1px solid #999999">
                                    <asp:TextBox ID="txtreturndate" Enabled="false" Width="96%" runat="server" CssClass="th style-eta date_style"
                                        Text='<%# Eval("FDebitChallanReturnDate") %>'></asp:TextBox>
                                </td>
                                <td style="width: 50px; border-bottom: 1px solid #999999;padding-left: 2px;">
                                    Rupees:
                                </td>
                                <td style="width: 390px; border-bottom: 1px solid #999999; font-size: 11px">
                                    <asp:Label ID="lblRupees" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table style="max-width: 100%; width: 100%; border: none" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td colspan="5" style="float: right; padding-right: 8px; padding-top: 15px; color: #000;
                                    font-size: 12px;">
                                    Boutique International Pvt. Ltd.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="text-align: center; padding-top: 5px;">
                                    <%-- <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClientClick="JavaScript:return Debitnote_Validation()"
                                        OnClick="btnDebitNoteSave" />--%>
                                    <div class="form_buttom" style="float: left;">
                                        <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" OnClientClick="JavaScript:return Debitnote_Validation()"
                                            runat="server" Text="Save" OnClick="btnDebitNoteSave" />
                                    </div>
                                      <div class="btnClose printHideButton" id="Closesbox" onclick="CloseFun()">
                                        Close</div>
                                  <%--  <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                        Close</div>--%>
                                    <div class="btnPrint printHideButton" onclick="window.print();return false">
                                        Print</div>
                                </td>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
