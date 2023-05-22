<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoShippedPopup.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.MoStitchPopup" %>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<link rel="Stylesheet" href="../../App_Themes/ikandi/ikandi.css" />
<link rel="Stylesheet" href="../../App_Themes/ikandi/ikandi1.css" />
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
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
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
<script type="text/javascript">
    function CloseWindow() {
        //debugger;
        window.opener.WriteShipmentCaption();
        this.parent.window.close();
        return false;
    }
    $(function () {
        //debugger;
        $("input[type=text].NatureOfFaults").autocomplete("/Webservices/iKandiService.asmx/SuggestNatureOfFaults", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });

        $("input[type=text].NatureOfFaults", "#main_content").result(function () {

//            var p = $(this).val().split('-');
//            $(this).val(p[0]);

        });

    });
    $(document).ready(function () {



        $('input.date-picker').datepicker({ changeYear: true, yearRange: '1982:2030', dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });
        $('.accept_only_decimal_values').keypress(function (event) {
            return isNumber(event, this);
        });
        $('input:checkbox').change(function () {
            $('.EmptyZero').trigger('blur');
        });
        $('.EmptyZero').blur(function () {
            var txtvalue = $(this);
      
            var ExpressAiringToUK = 0; var CIFAir = 0; var FiftyPercentCIFAir = 0; var AirToMumbai = 0; var InspectionFailandTransport = 0; var BP_CR = 0; var ShippedQty = 0; var ShippedValue = 0; var TotalPenalty = 0
            var CalorderDiscount = 0;

            var txtExpressAiringToUK = $('#<%=txtExpressAiringToUK.ClientID%>');
            var txtCIFAir = $('#<%=txtCIFAir.ClientID%>');
            var txtFiftyPercentCIFAir = $('#<%=txtFiftyPercentCIFAir.ClientID%>');
            var txtAirToMumbai = $('#<%=txtAirToMumbai.ClientID%>');
            var txtInspectionFailandTransport = $('#<%=txtInspectionFailandTransport.ClientID%>');
            var hdnBP_CR = $('#<%=hdnBP_CR.ClientID%>');
            var txtShippedQty = $('#<%=txtStitchQty.ClientID%>');
            debugger;
            var txtShippedValue = $('#<%=txtShippedValue.ClientID%>');
            var txtTotalPenalty = $('#<%=txtTotalPenalty.ClientID%>');
            var txtorderDiscount = $('#<%=txtorderDiscount.ClientID%>');


            if (parseFloat(txtExpressAiringToUK.val()) > 0) {
                ExpressAiringToUK = txtExpressAiringToUK.val();
            }
            if (parseFloat(txtCIFAir.val()) > 0) {
                CIFAir = txtCIFAir.val();
            }
            if (parseFloat(txtFiftyPercentCIFAir.val()) > 0) {
                FiftyPercentCIFAir = txtFiftyPercentCIFAir.val();
            }
            if (parseFloat(txtAirToMumbai.val()) > 0) {
                AirToMumbai = txtAirToMumbai.val();
            }
            if (parseFloat(txtInspectionFailandTransport.val()) > 0) {
                InspectionFailandTransport = txtInspectionFailandTransport.val();
            }

            debugger;
            if (parseFloat(hdnBP_CR.val()) > 0) {
                BP_CR = hdnBP_CR.val();
            }

            if (txtShippedQty.val() == '')
                ShippedQty = 1
            else
                ShippedQty = txtShippedQty.val();

            if (txtorderDiscount.val() == '')
                CalorderDiscount = 0
            else
                CalorderDiscount = parseFloat(txtorderDiscount.val());

            //            if (parseFloat(txtorderDiscount.val()) > 0) {
            //                CalorderDiscount = txtorderDiscount.val();
            //            }
            // debugger;
            $('#<%=txtTotalPenalty.ClientID%>').val(parseFloat(ExpressAiringToUK) + parseFloat(CIFAir) + parseFloat(FiftyPercentCIFAir) + parseFloat(AirToMumbai) + parseFloat(InspectionFailandTransport));
            $('#<%=txtShippedValue.ClientID%>').val((parseFloat(BP_CR) * parseFloat(ShippedQty)).toFixed(0));

            //            var a = Math.round((parseFloat(BP_CR) * parseFloat(ShippedQty) * 100) / 100);

            if (parseFloat(txtShippedValue.val()) > 0) {
                ShippedValue = txtShippedValue.val();
                var GetDiscount = 0;

                if (parseFloat(ShippedValue) > 0) {

                    if ($('#<%=chkDiscount.ClientID%>').is(':checked')) {


                        GetDiscount = ((parseFloat(ShippedValue) / 100) * parseFloat(CalorderDiscount)).toFixed(2);
                        ShippedValue = (parseFloat(ShippedValue) - parseFloat(GetDiscount));

                        //                        GetDiscount = Math.round(((parseFloat(ShippedValue) / 100) * (parseFloat(CalorderDiscount)) * 100) / 100); 
                        //                        ShippedValue = (parseFloat(ShippedValue) - parseFloat(GetDiscount));

                        //var a = Math.round(((parseFloat(ShippedValue) / 100) *(parseFloat(CalorderDiscount)) * 100) / 100); 
                    }
                    else {
                        GetDiscount = (parseFloat(ShippedValue) - (parseFloat(CalorderDiscount) * ShippedQty)).toFixed(2);
                        ShippedValue = GetDiscount;

                        //                        GetDiscount = Math.round(parseFloat(ShippedValue) - parseFloat(CalorderDiscount));
                        //                        ShippedValue = GetDiscount;
                    }
                    $('#<%=txtShippedValue.ClientID%>').val(ShippedValue);
                }

            }
            if (parseFloat(txtTotalPenalty.val()) > 0) {
                TotalPenalty = txtTotalPenalty.val();
            }
            if (parseFloat(ShippedValue) > 0 && parseFloat(TotalPenalty) > 0) {
                $('#<%=txtPenaltyPercentAge.ClientID%>').val(((parseFloat(TotalPenalty) / parseFloat(ShippedValue)) * 100).toFixed(2));

            }
            else
                $('#<%=txtPenaltyPercentAge.ClientID%>').val(0);
            $('#<%=hdnTotalPenalty.ClientID%>').val(TotalPenalty);
            $('#<%=hdnShippedValue.ClientID%>').val(ShippedValue);
            $('#<%=hdnPenaltyPercentAge.ClientID%>').val($('#<%=txtPenaltyPercentAge.ClientID%>').val());



        });

    })
    // THE SCRIPT THAT CHECKS IF THE KEY PRESSED IS A NUMERIC OR DECIMAL VALUE.
    function isNumber(evt, element) {
        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
            (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
            (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
            (charCode < 48 || charCode > 57))
            return false;
        return true;
    }



    function SaveFile(index, FileName) {


        $('#<%=hdnFileName.ClientID%>').val(FileName);
    }

  
     
</script>
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<script src="../../js/combined_jquery_scripts4.js" type="text/javascript"></script>

<script type="text/javascript">
    function FileUpload() {
        var FileUploadName = '<%=this.FileUploadName %>';
        var OrderDetailsId = '<%=this.OrderDetailID_s %>';

        var url = '../../Admin/ProductionAdmin/ShipedQntyFileUpload.aspx?OrderDetailsId=' + OrderDetailsId + '&FileName=' + FileUploadName;


        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 500, width: 900, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //return false;
    }
    function SBClose() { }
    function ValidateUnit() {
        debugger;
        if ($("#MoStitchPopup1_ddlShipingUnit").val() == -"1") {
            alert("Please select shipped unit!")
            return false;
        }
        if ($("#MoStitchPopup1_txtShippedValue").val() == "" || $("#MoStitchPopup1_txtShippedValue").val() == "0") {
            alert("Shipped Value is Zero.Please Check.")
            return false;
        }
    }

</script>
<link rel="Stylesheet" href="../../css/technical-module.css" />
<style type="text/css">
    .border2 th
    {
        padding: 5px !important;
    }
    .form_box table td
    {
        padding: 3px;
        text-align:center;
    }
    .form_box
    {
        border: none !important;
    }
    .submit
    {
        margin-left: 15PX;
    }
    .ui-widget-content
    {
        border: 0px !important;
    }
    th
    {
        font-weight: normal !important;
       
        font-family: arial,halvetica !important;
        font-size: 10px !important;
    }
    .main-heading
    {
        color: #3b5998 !important;
        font-family: Lucida Sans Unicode;
        font-size: 16px !important;
        font-weight: normal !important;
        height: 26px;
        text-align: center;
        text-transform: capitalize;
    }
    .Error
    {
        float:right;
    vertical-align: bottom;
    padding-left: 10px;
    color: rgb(181, 1, 40);
    font-size: 12px;
    font-family: Verdana, Tahoma, Arial;
    font-weight: bold;}
  input[type=text], textarea {
    padding-left: 3px !important;
    font-size: 11px !important;
}

.ui-widget-content {
   
 background: transparent !important;
   
}
.btnCancel
{
     margin-left: 5px;
    font-size: 12px !important;
    color: rgb(255, 255, 255);
    font-weight: bold;
    width: 52px;
    cursor: pointer;
    background: #39589c !important;
    height: 21px;
    line-height: 19px;
    border: none !important;
    border-radius: 2px
 }
 .btnupload
 {
         cursor: pointer;
    background: #036503bd;
    color: #fff;
    padding: 4px 5px;
    font-size: 10px;
    border-radius: 2px;
  }
 
</style>
<div class="form_box" style="font-family: Verdana,Arial,sans-serif; font-size: 11px;
    width: 700px; text-transform: capitalize;">
    <h2 class="main-heading" style="margin: 0px; padding: 0px; color:#fff !important">
        Shipping Detail
    </h2>
    <table width="700px" cellpadding="0" cellspacing="0" border="1" style="border-top:0;border-bottom:0;">
        <tr>
            <td style="text-align: left">
                <asp:HiddenField ID="hdnFileName" runat="server" />
                Shipped Qty.<span style="color: Red;">*</span><span>
                    <asp:TextBox ID="txtStitchQty" EnableViewState="true"  CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" runat="server" MaxLength="7" Width="50px" style="margin-right:5px;"></asp:TextBox>
                </span>Shipped Date <span>
                    <asp:TextBox ID="txtISShippedDate" runat="server" Style="background-color: #F9F9FA;
                        text-transform: capitalize; background: none; border: 1px solid #d6d7d8; color: #000;
                        margin-right: 5px;" CssClass="date-picker" Visible="false" Enabled="false" Width="100px"></asp:TextBox>
                </span>Cut Qty. <span>
                    <asp:TextBox ID="txtcutqty" runat="server" Style="background-color: #F9F9FA; text-transform: capitalize;
                        background: none; border: 1px solid #d6d7d8; color: #000; margin-right: 3px;"
                        Enabled="false" Width="55px"></asp:TextBox>
                </span>&nbsp; Contract Qty. <span>
                    <asp:TextBox runat="server" ID="txtContractQty" Enabled="false" CssClass="numeric-field-without-decimal-places"
                        MaxLength="10" size="15" Text="" Width="50px"></asp:TextBox>
                </span>
            </td>
            <td style="text-align: right;padding-right: 0px;">
                <a rel="shadowbox" onclick='return FileUpload();' class="btnupload" style="cursor: pointer;"><b><asp:Label ID="lblFileUpload" runat="server" Text="Upload File"></asp:Label>
                    </b></a>
            </td>
        </tr>
    </table>
    <table runat="server" id="tblBusiness" width="700px" cellpadding="0" cellspacing="0" border="0" class="AddClass_Table" align="center" style="border-color: #ccc;">
        <thead>
            <tr>
                
                
                <th colspan="9" class="main-heading">
                
                    <strong style="margin-left: 88px;font-weight: normal;">Penalty </strong> <asp:DropDownList style="float:right;" ID="ddlShipingUnit" runat="server">
                    <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                    <asp:ListItem  Value="3">C 47</asp:ListItem>
                    <asp:ListItem  Value="11">C 45-46</asp:ListItem>
                    <asp:ListItem  Value="96">D 169</asp:ListItem>
                    <%-- <asp:ListItem  Value="120">C 52</asp:ListItem>--%>
                    </asp:DropDownList><span style="float:right;font-size:13px;margin-right: 10px;"> Shipped Unit<span style="color: Red;;">*</span></span>
                   <%-- <asp:RequiredFieldValidator CssClass="Error" InitialValue="-1" Display="None" ErrorMessage="Please select shipped unit!" runat="server" ID="ReqValidator" ValidationGroup="validationgroup" ControlToValidate="ddlShipingUnit" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                       ShowSummary="False" ValidationGroup="validationgroup" />--%>
                </th>
            </tr>
            <tr class="">
                <th width="70px">
                    Express Airing To UK
                </th>
                <th width="70px">
                    CIF Air
                </th>
                <th width="70px">
                    50% CIF Air
                </th>
                <th width="70px">
                    Air To Mumbai
                </th>
                <th>
                    Inspection Fail & Transport
                </th>
                <th width="70px">
                    Total Penalty
                </th>
                <th width="120px">
                    Order Claims Per Pcs in INR
                </th>
                <th width="85px">
                    Shipped Value INR
                </th>
                <th width="70px">
                    Penalty Percentage  To shipped value
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:TextBox ID="txtExpressAiringToUK" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" runat="server" Width="90%" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCIFAir" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" Text="" Width="90%" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFiftyPercentCIFAir" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" Text="" Width="90%" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtAirToMumbai" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" runat="server" Width="90%" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtInspectionFailandTransport" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" Text="" Width="90%" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTotalPenalty" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" Text="" Width="90%" MaxLength="10" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtorderDiscount" CssClass="numeric-field-with-two-decimal-places EmptyZero"
                        size="15" Text="" Width="45px" MaxLength="5"></asp:TextBox>
                    <asp:CheckBox ID="chkDiscount" runat="server" Text="Is %" CssClass="EmptyZero" />
                </td>
                <td>
                    <asp:TextBox ID="txtShippedValue" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" runat="server" Width="90%" MaxLength="10" ReadOnly="true" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPenaltyPercentAge" CssClass="numeric-field-without-decimal-places EmptyZero"
                        size="15" Text="" Width="90%" MaxLength="10" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>

    <asp:HiddenField ID="hdnOrderDetailID" runat="server" />
    <asp:HiddenField ID="hdnShippedDate" runat="server" />
    <asp:HiddenField ID="hdnBP_CR" runat="server" />
    <asp:HiddenField ID="hdnTotalPenalty" runat="server" />
    <asp:HiddenField ID="hdnShippedValue" runat="server" />
    <asp:HiddenField ID="hdnPenaltyPercentAge" runat="server" />
    <asp:GridView ID="grdQafault" Visible="false" runat="server" AutoGenerateColumns="False"
        ShowHeader="true" Width="700px" ShowFooter="True" OnRowDeleting="grdQafault_RowDeleting"
        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdQafault_RowCommand"
        OnRowDataBound="grdQafault_RowDataBound" BorderWidth="1" BorderColor="#999" CssClass="AddClass_Table" rules="all" HeaderStyle-CssClass="border2" >
        <Columns>
            <asp:TemplateField HeaderText="Nature of fault" HeaderStyle-Font-Size="12px">
                <ItemTemplate>
                    <asp:TextBox ID="txtFaultname" CssClass="NatureOfFaults" ToolTip="Nature of fault"
                        Text='<%#Eval("fault")%>' runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnfaultid" runat="server" Value='<%#Eval("ID")%>' />
                    <asp:HiddenField ID="hdnAutoincretment" Value='<%# ((GridViewRow)Container).RowIndex + 1%>' runat="server" />

                    
                </ItemTemplate>
                
                <ItemStyle Width="100px" />
                <FooterTemplate>
                    <asp:TextBox ID="txtfoterfaultname"  CssClass="NatureOfFaults" ToolTip="Nature of fault"
                        runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnAutoincretmentfoter" Value='<%# ((GridViewRow)Container).RowIndex + 1%>'
                        runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty." HeaderStyle-Font-Size="12px">
                <ItemTemplate>
                    <asp:TextBox ID="txtQnty" MaxLength="4" class="numeric-field-without-decimal-places" ToolTip="qty" Text='<%#Eval("UnshippedQty")%>' runat="server"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="60px" />
                <FooterTemplate>
                    <asp:TextBox ID="txtfoterqnty" MaxLength="4"  ToolTip="Email" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" HeaderStyle-Font-Size="12px">
                <ItemTemplate>
                    <div style="text-align: center;" class="iSlnkHide">
                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="50px" VerticalAlign="top" />
                <FooterTemplate>
                    <div style="text-align: center;" class="iSlnkHide">
                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"  style="width:50px;"
                            CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                    </div>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <table border="0" cellpadding="0" class="AddClass_Table" cellspacing="0" width="100%">
                <tr class="border2">
                    <th width="100px">
                        Nature of fault
                    </th>
                    <th width="150px">
                        Qty.
                    </th>
                    <th>
                    Action
                    </th>
                </tr>
                <tr style="text-align: center;">
                    <td>
                        <asp:TextBox ID="txtemptyfaultname" style="width:300px;"  CssClass="NatureOfFaults" ToolTip="Nature of fault"
                            runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtemptyqnty" MaxLength="4" style="width:50px;" ToolTip="Qty" class="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                    </td>
                    <td width="50px">
                        <asp:LinkButton ForeColor="black" style="width:50px;" ToolTip="Insert New Record" ID="addbutton" runat="server"
                            CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" />  </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>

    <div style="float: right; width: auto;margin-top:10px;">
        <asp:Button ID="btnsubmit" runat="server" CssClass="btnbutton" Text="Submit" ValidationGroup="validationgroup" OnClientClick="return ValidateUnit();" OnClick="btnsubmit_Click" />
        <input type="button" class="btnCancel" value="Cancel" onclick="window.close();" />
    </div>
</div>
