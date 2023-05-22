<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientForm.ascx.cs"
    Inherits="iKandi.Web.ClientForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript">

    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
    });
  
</script>
<style>
    @-moz-document url-prefix() {
      .da_text_area_client
      {
          width:135px !important;
          min-height: 76px;
          max-height: 100px;
          overflow-y: auto;
    }
}

      .da_text_area_client
      {
          width: 210px !important;
          max-width:300px;
          max-height: 100px;
          overflow-y: auto;
    }
      #ctl00_cph_main_content_ClientForm1_LBcountry
      {
          max-height: 100px;
          overflow-y: auto;
          width: 148px;
    }
  .caption_headings
  {
      float:left;
      }
        #secure_banner_cor
     {
         padding:0px 0px;
      } 
      .secure_center_contentWrapper
      {
          width:100%;
       }
       form
       {
           position:relative;
           top:-11px;
        }
        .header-text-back {
    border-radius: 0px 0px 0px 0px !important;
    padding: 0px 0px !important;
}
.header-text-back
{
    position:relative;
 }
 .tbl_bordr
 {
     border-color:#999;
  }
  input[type="text"]
  {
      width:97%;
      }
  .minwidth
  {
      min-width:165px;
      }
  .maxwidth
  {
      max-width: 90px;
      }
</style>
<script src="../../js/combined_jquery_scripts4.js" type="text/javascript"></script>
<script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
<script type="text/javascript">

    var jscriptPageVariables = null;
    var tblClientDepartmentClientID = "tblClientDepartments";
    var tblClientContactsClientID = "tblClientContacts";
    var txtCompanyNameClientID = '<%=txtCompany.ClientID%>';

    var exqty;
    var context = $("#main_content");
    $(function () {
        var txtClientSinceID = '<%=txtClient.ClientID%>';
        $("#" + txtClientSinceID).attr("class", "input_in date_style");
    });

    function SBClose() { }
    function OpenDepartmentSheet() {
        var ClientID = '<%=this.ClientID %>';
        var sURL = '../../Internal/Client/Create_Department.aspx?ClientID=' + ClientID;

        window.open(sURL, '_blank', 'height=500,width=600,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
//        Shadowbox.init({ animate: true, animateFade: true, modal: true });
//        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;
    }

    function tovalidate() {
        //debugger;
        //if (Page_ClientValidate())
        //var ddSales = $("#" + ddSales1ClientID);
        ////var t1 = Page_ClientValidate("Submit");
        //// var t2 = Page_ClientValidate("Add");
        ////  var count = 0;

        if (Page_IsValid) {
            //do some stuff

            var penny = $(".sales");

            context.find(".userName").each(function () {
                var tr = $(this).parents("tr");
                var value = $("#" + tr.find("input.deptName").attr("id")).val();
                if (value == null || value == "") {
                    alert("Please enter the department name.");
                    return false;
                }
            });
            return true;
        }
        else {
            return false;
        }

        ////        if (!t1) {
        ////            count = 1;
        ////            //alert("Please enter department/buying house name");
        ////            return false;
        ////        }

        ////        if (!t2) {
        ////            count = 1;
        ////            //alert("Please enter user/department name");
        ////            return false;
        ////        }

        ////        if (t2) {
        ////            var penny = $(".sales");

        ////            context.find(".userName").each(function () {
        ////                var tr = $(this).parents("tr");
        ////                var value = $("#" + tr.find("input.deptName").attr("id")).val();
        ////                if (value == null || value == "") {
        ////                    alert("Please enter the department name.");
        ////                    return false;
        ////                }
        ////            });
        ////            //comented by abhishek on 13/5/2016 for remove validation for associating user for every depertment..

        ////            //            for (var i = 0; i < penny.length; i++) {  
        ////            //                if ($(penny[i]).val() == null || $(penny[i]).val() == "") {
        ////            //                    alert("Please select atleast one user from each designations for every departments.");
        ////            //                    return false;
        ////            //                }                 
        ////            //            }
        ////        }
        ////        if (count == 1)
        ////        { return false; }
        ////        else {
        ////            return true;
        ////        }
    }

    function getName(elem) {

        var comp = $("#" + txtCompanyNameClientID).val();
        comp = comp.replace(' ', '_');
        if ($(elem).attr("class") == "client-company input_in") {
            context.find(".userName").each(function () {
                var tr = $(this).parents("tr");
                var value = $("#" + tr.find("input.deptName").attr("id")).val();
                value = value.replace(' ', '_');
                $(this).val(value + "@" + comp);
            });
        }
        else {
            var tr = $(elem).parents("tr");
            var value = $("#" + tr.find("input.deptName").attr("id")).val();
            value = value.replace(' ', '_');
            var id = tr.find("input.userName").attr("id");
            $("#" + id).val(value + "@" + comp);
        }
    }
    //Check box validation Added by gajendra 26-11-2015
    function ValidateCheckBox(sender, args) {
        if (document.getElementById("<%=chkMDA.ClientID %>").checked == true) {
            args.IsValid = true;
        } else {
            args.IsValid = false;
        }
    }
    function Reload() {
        //window.opener.location.href = window.opener.location.href;
        //window.opener.location.reload();
        //window.close();
        window.parent.window.location = window.parent.window.location.href;
    }
    $(document).ready(function () {
        var clientid = $('input[id$=hdnfldClientID]').val();
        if (clientid == -1) {
            $("#secure_greyline").css({ "display": "none" });
            $("#btnClose").css({ "display": "block" });
        }
        else {
            $("#secure_greyline").css({ "display": "block" });
            $("#btnClose").css({ "display": "none" });
        }
    });

    //    function OpenColorPicker() {  

    //        var url = '../../Admin/frmColourPicker.aspx';
    //        window.open(url, '_blank', 'height=1000,width=1000,status=yes,toolbar=no,menubar=yes,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');



    //    }

    $(document).ready(function () {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);
        PageLoad();
    });
    function InitializeRequest(sender, args) { }
    function EndRequest(sender, args) { PageLoad(); }


    function PageLoad() {
      
        $('.color-picker', '#main_content').ColorPicker(
        {

            onShow: function (colpkr) {
                //debugger;

                $(colpkr).fadeIn(300);
                return false;
            },
            onHide: function (colpkr) {
                $(colpkr).fadeOut(300);
                return false;
            },
            onChange: function (hsb, hex, rgb) {
                $(this).css('backgroundColor', '#' + hex);
            },
            onSubmit: function (hsb, hex, rgb, el) {
                $(el).css('backgroundColor', '#' + hex);

                var colorPickerValue = $(el).find('input.color-picker-value');

                if (colorPickerValue.length == 1) {
                    //                    var gg = colorPickerValue.val('#' + hex);
                    //                    alert(gg);

                    colorPickerValue.val('#' + hex);
                }


                $(el).ColorPickerHide();

            }

        });
    }
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<asp:Panel runat="server" ID="pnlForm">
    <asp:HiddenField ID="hdncolor" Value='0' runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="print-box client_form">
                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 15px;">
                    <tr>
                        <td>
                            <h2 class="header-text-back">
                              <span style="position:absolute;left:10px;font-size: 11px;top:5px;">(<span class="da_astrx_mand">*</span> Please fill all required
                                fields)</span>  Registration Form 
                              </h2>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbl_bordr">
                            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                                <caption class="caption_headings">
                                    New Client</caption>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                            <tr class="td-sub_headings">
                                                <td valign="bottom">
                                                    Division Name <span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom">
                                                    Buying House <span class="da_astrx_mand">*</span>
                                                </td>
                                                <div id="divCopyFrom1" runat="server">
                                                    <td valign="bottom">
                                                        Refer Client<span class="da_astrx_mand">*</span>
                                                    </td>
                                                </div>
                                                <td valign="bottom">
                                                    Company Name <span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom">
                                                    Client Website
                                                </td>
                                                <td valign="bottom">
                                                    Phone
                                                </td>
                                                <td valign="bottom">
                                                    Email
                                                </td>
                                                <td valign="bottom">
                                                    Client Since
                                                </td>
                                                <td valign="bottom">
                                                    Address
                                                </td>
                                                <td valign="bottom">
                                                    Client Code<span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom">
                                                    AQL<span class="da_astrx_mand">*</span>
                                                </td>
                                                <td valign="bottom" width="50">
                                                    Is MDA Required?
                                                </td>
                                                <td valign="bottom" width="50">
                                                    Client Default Colour
                                                </td>
                                                <td valign="bottom" width="50">
                                                    Is PP Sample Required
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inner_tbl_td">
                                                    <asp:HiddenField ID="hdnfldClientID" runat="server" />
                                                    <asp:DropDownList ID="ddlDivisionName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisionName_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ControlToValidate="ddlDivisionName" ID="RequiredFieldValidator23"
                                                        ValidationGroup="Add" ErrorMessage="Please select Division Name" InitialValue="0"
                                                        runat="server" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlBuyingHouse" runat="server">
                                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblBuyingHouse" runat="server" Visible="false" Text=""></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" ValidationGroup="Add"
                                                        runat="server" ErrorMessage="Please select Buying House" ControlToValidate="ddlBuyingHouse"
                                                        MinimumValue="1" MaximumValue="999"></asp:RangeValidator>
                                                </td>
                                                <div id="divCopyFrom2" runat="server">
                                                    <td class="inner_tbl_td">
                                                        <asp:DropDownList ID="ddlCopyFrom" runat="server">
                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ControlToValidate="ddlCopyFrom" ID="RequiredFieldValidator320"
                                                            ValidationGroup="Add" ErrorMessage="Please select refer client" InitialValue="-2"
                                                            runat="server" Display="Dynamic">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </div>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" ID="txtCompany" onblur="javascript:getName(this);" MaxLength="30"
                                                        CssClass="client-company input_in maxwidth"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                        ValidationGroup="Add" EnableClientScript="true" ControlToValidate="txtCompany"
                                                        ErrorMessage="Please enter name"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="input_in" MaxLength="30"></asp:TextBox>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" ID="txtPhone" CssClass="numeric_text input_in" MaxLength="13"/>
                                                    <div class="form_error" style="display: none">
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="30" CssClass="input_in minwidth" />
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" ID="txtClient" CssClass="do-not-allow-typing th" Width="100"></asp:TextBox>
                                                    <%--  <cc1:CalendarExtender ID="CalendarExtender1" Format="dd MMM yy (ddd)" TargetControlID="txtClient" runat="server">
                                                </cc1:CalendarExtender>--%>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" CssClass="input_in"
                                                        MaxLength="198" />
                                                    <div class="form_error" style="display: none">
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" CssClass="input_in" ID="txtCode" MaxLength="3" Width="50" />
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                            ValidationGroup="Add" EnableClientScript="true" ControlToValidate="txtCode" ErrorMessage="Please enter Client Code"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList ID="ddlAQLStandards" CssClass="input_in" runat="server" Width="50px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ControlToValidate="ddlAQLStandards" ID="RequiredFieldValidator33"
                                                        ValidationGroup="Add" CssClass="errormesg" ErrorMessage="Please select Aql" InitialValue="0"
                                                        runat="server" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkMDA" />
                                                    <%-- <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please check MDA Required"
                                                        ValidationGroup="Add" EnableClientScript="true" ClientValidationFunction="ValidateCheckBox"></asp:CustomValidator><br />--%>
                                                </td>
                                                <%-- <td class="color-picker" id="tdColorPicker" runat="server">--%>
                                                <%--<asp:TextBox ID="txtColorPickerValue"  runat="server" CssClass="color-picker-value input_in"></asp:TextBox>--%>
                                                <%-- <input type="button"  onclick="OpenColorPicker();" value="PickColor"/>
                                                </td>--%>
                                                <td class="color-picker" id="tdColorPicker" runat="server">
                                                    <asp:TextBox ID="txtColorPickerValue" runat="server" CssClass=" color-picker-value hide_me  input_in"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkPPSample" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!--Internal Assignments-->
                            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                                style="display: none;">
                                <caption class="caption_headings">
                                    Internal Assignments</caption>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" align="Top" cellspacing="6" cellpadding="0" style="margin: 0px;"
                                            id="Table1">
                                            <tr class="td-sub_headings">
                                                <td>
                                                    Sales
                                                </td>
                                                <td>
                                                    Account Manager <span class="da_astrx_mand">*</span>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDesign1" CssClass="design" runat="server" Text="Designer"></asp:Label><span
                                                        class="da_astrx_mand">*</span>
                                                </td>
                                                <td class="tech">
                                                    <asp:Label ID="lblTech1" Text="Technologist" CssClass="tech" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    Shipping Manager <span class="da_astrx_mand">*</span>
                                                </td>
                                                <td>
                                                    Delivery Manager <span class="da_astrx_mand">*</span>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFitMer1" Text="Production  Merchandiser" CssClass="fitMer" runat="server"></asp:Label><span
                                                        class="da_astrx_mand">*</span>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSamplingMer1" CssClass="sampMer" runat="server" Text="Sampling Merchant"></asp:Label><span
                                                        class="da_astrx_mand">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList runat="server" ID="ddlSales" AppendDataBoundItems="true" Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList runat="server" ID="ddl_Account" OnSelectedIndexChanged="ddlAcc_SelectedIndexChanged"
                                                        AppendDataBoundItems="true" Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_account" Enabled="false" runat="server" Display="Dynamic"
                                                            ControlToValidate="ddl_Account" InitialValue="-1" ErrorMessage="Select A/C Manager"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td design">
                                                    <asp:DropDownList runat="server" ID="ddlDesign" CssClass="design" AppendDataBoundItems="true"
                                                        Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_ddlDesign" Enabled="false" runat="server" Display="Dynamic"
                                                            ControlToValidate="ddlDesign" InitialValue="-1" ErrorMessage="Select design contact"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList runat="server" ID="ddl_Techmanager" CssClass="tech" AppendDataBoundItems="true"
                                                        Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList runat="server" ID="ddl_Exportmgr" AppendDataBoundItems="true" Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_exportmgr" Enabled="false" runat="server" Display="Dynamic"
                                                            ControlToValidate="ddl_Exportmgr" InitialValue="-1" ErrorMessage="Select Export Manager"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList runat="server" ID="ddl_Delivery" AppendDataBoundItems="true" Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_Delivery" Enabled="false" runat="server" Display="Dynamic"
                                                            ControlToValidate="ddl_Delivery" InitialValue="-1" ErrorMessage="Select Client Factory Contact"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList runat="server" ID="ddl_Fitmerchant" AppendDataBoundItems="true"
                                                        Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_Fitmerchant" Enabled="false" runat="server" Display="Dynamic"
                                                            ControlToValidate="ddl_Fitmerchant" InitialValue="-1" ErrorMessage="Select Production  Merchandiser"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:DropDownList runat="server" ID="ddl_Samplingmerchant" AppendDataBoundItems="true"
                                                        Width="200">
                                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <div class="form_error">
                                                        <asp:RequiredFieldValidator ID="rfv_Sampling" Enabled="false" runat="server" Display="Dynamic"
                                                            ControlToValidate="ddl_Samplingmerchant" InitialValue="-1" ErrorMessage="Select Production  Merchandiser"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!--end-->
                            <!--Financial-->
                            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                                <caption class="caption_headings">
                                    Financial
                                </caption>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                            <tr class="td-sub_headings">
                                                <td width="7%" valign="bottom">
                                                    Discount % for this Client <span class="da_astrx_mand">*</span>
                                                </td>
                                                <td width="7%" valign="bottom">
                                                    Payment Terms <span class="da_astrx_mand">*</span>
                                                </td>
                                                <td width="7%" valign="bottom">
                                                    Official Name
                                                </td>
                                                <td width="12%" valign="bottom">
                                                    Billing Address
                                                </td>
                                                <td width="13%" valign="bottom">
                                                    &nbsp; 4 Point Check Accept Range
                                                </td>
                                                <td width="12%" valign="bottom">
                                                Destination Country Code
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inner_tbl_td">
                                                    <table width="100%" border="0" cellspacing="2" cellpadding="0">
                                                        <tr>
                                                            <td width="94%">
                                                                <asp:TextBox runat="server" ID="txt_Discount" CssClass="input_in numeric-field-with-two-decimal-places"
                                                                    MaxLength="2"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                                    ValidationGroup="Add" EnableClientScript="true" ControlToValidate="txt_Discount"
                                                                    ErrorMessage="Please enter Discount % for this Client"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td width="6%" class="da_special_char">
                                                                %
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <table width="100%" border="0" cellspacing="2" cellpadding="0">
                                                        <tr>
                                                            <td width="82%">
                                                                <asp:TextBox runat="server" ID="txt_Payment" CssClass="input_in numeric-field-without-decimal-places"
                                                                    MaxLength="3"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                                    ValidationGroup="Add" EnableClientScript="true" ControlToValidate="txt_Payment"
                                                                    ErrorMessage="Please enter Payment Terms"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td width="18%" class="da_special_char">
                                                                &nbsp;Days
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" ID="txtOfficialName" CssClass="input_in" MaxLength="30"></asp:TextBox>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    <asp:TextBox runat="server" ID="txtBillingAddess" TextMode="MultiLine" Width="100%" Height="42" Rows="4" cols="300"></asp:TextBox>
                                                </td>
                                                <td class="inner_tbl_td">
                                                    &nbsp;
                                                    <asp:DropDownList ID="ddlfpc" runat="server">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                 <asp:ListBox ID="LBcountry" runat="server" SelectionMode="Multiple">
                                                                                                    </asp:ListBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!--end-->
                            <div class="form_box" style="border: none; position:relative;top:-21px;" id="divDept" runat="server">
                                <div id="divDepartments">
                                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                                        id="tblClientDepartments">
                                        <caption class="caption_headings">
                                            Department Association</caption><span style="position: relative;top: 27px;left: 200px;"> &nbsp;&nbsp;&nbsp;<a rel="shadowbox;" href="javascript:void(0)" onclick="return OpenDepartmentSheet();" style="cursor: pointer; width: auto;text-transform: capitalize !important;">Create Department</a></span>
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                            <ItemTemplate>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                                                <tr class="td-sub_headings">
                                                                    <td valign="bottom" width="12%">
                                                                        Parent Department <span class="da_astrx_mand">*</span>
                                                                    </td>
                                                                    <td valign="bottom" width="12%">
                                                                        Department <span class="da_astrx_mand">*</span>
                                                                    </td>
                                                                    <td valign="bottom" width="12%">
                                                                        Username
                                                                    </td>
                                                                    <td valign="bottom" width="12%">
                                                                        Fit Days
                                                                    </td>
                                                                    <td valign="bottom">
                                                                    </td>
                                                                    <td valign="bottom">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td valign="bottom">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td valign="bottom">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td valign="bottom">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="inner_tbl_td">
                                                                        <asp:DropDownList ID="ddlPDept" runat="server">
                                                                            <asp:ListItem Selected="True" Text="Select" Value="-1"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvddlUnit1" runat="server" CssClass="errorMsg"
                                                                            InitialValue="-1" ControlToValidate="ddlPDept" Display="Dynamic" ValidationGroup="Add"
                                                                            EnableClientScript="true" ErrorMessage="Please select Parent Dept. Name"></asp:RequiredFieldValidator>
                                                                        <asp:HiddenField ID="hdnParendDeptId" Value='<%# Bind("ParentID") %>' runat="server" />                                                                       
                                                                    </td>
                                                                    <td class="inner_tbl_td">
                                                                        <asp:TextBox ID="txtDept1" onblur="javascript:getName(this);" CssClass="input_in deptName Dept"
                                                                            Text='<%# Bind("DepartmentName") %>' MaxLength="30" runat="server"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdnDeptID" Value='<%# Bind("ID") %>' runat="server" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                            ControlToValidate="txtDept1" Font-Size="Smaller" EnableClientScript="true" ValidationGroup="Add"
                                                                            ErrorMessage="Please enter Dept. Name"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                                                            ControlToValidate="txtDept1" Font-Size="Smaller" EnableClientScript="true" ValidationGroup="Add"
                                                                            ValidationExpression="[0-9a-zA-Z \.\(\)\{\}\[\]\-'_]{2,}" runat="server" ErrorMessage="Min of two char are reqd."></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td class="inner_tbl_td">
                                                                        <asp:TextBox ID="txtUsername1" Width="120px" Enabled="false" CssClass="input_in userName do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtUsername1" Font-Size="Smaller" EnableClientScript="true" ValidationGroup="Add" ErrorMessage="Please enter User Name"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td class="inner_tbl_td" style="display: none">
                                                                        <%-- <asp:TextBox ID="txtPassword1" Visible="false" CssClass="input_in" Text='<%# Bind("Password") %>'
                                                                    runat="server"></asp:TextBox>--%>
                                                                    </td>
                                                                    <td colspan="3" class="inner_tbl_td" width="15%">
                                                                        <table width="99%" border="0" align="center" cellspacing="2" cellpadding="0">
                                                                            <tr>
                                                                                <td class="td-sub_headings">
                                                                                    Mon
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdnMon" Value='<%# Bind("Mon") %>' runat="server" />
                                                                                    <asp:CheckBox ID="chkMon" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="false"
                                                                                        runat="server" />
                                                                                </td>
                                                                                <td class="td-sub_headings">
                                                                                    Tue
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdnTue" Value='<%# Bind("Tue") %>' runat="server" />
                                                                                    <asp:CheckBox ID="chkTue" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="false"
                                                                                        runat="server" />
                                                                                </td>
                                                                                <td class="td-sub_headings">
                                                                                    Wed
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdnWed" Value='<%# Bind("Wed") %>' runat="server" />
                                                                                    <asp:CheckBox ID="chkWed" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="false"
                                                                                        runat="server" />
                                                                                </td>
                                                                                <td class="td-sub_headings">
                                                                                    Thu
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdnThu" Value='<%# Bind("Thu") %>' runat="server" />
                                                                                    <asp:CheckBox ID="chkThu" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="false"
                                                                                        runat="server" />
                                                                                </td>
                                                                                <td class="td-sub_headings">
                                                                                    Fri
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdnFri" Value='<%# Bind("Fri") %>' runat="server" />
                                                                                    <asp:CheckBox ID="chkFri" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="false"
                                                                                        runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="right">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="right">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td class="hide_me">
                                                                                    <span class="da_remove_btn_dafo"><a href="#">
                                                                                        <img src="images1/plus_icon.gif" border="0" title="add more" />
                                                                                        Add more</a></span>
                                                                                </td>
                                                                                <td>
                                                                                    <span class="da_remove_btn_dafo">
                                                                                        <asp:ImageButton ID="imgRemove" OnClick="imgRemove_Click" runat="server" ImageUrl="~/App_Themes/ikandi/images/minus_icon.gif" />&nbsp;Remove
                                                                                        <asp:HiddenField ID="hdnDelete" Value='<%# Bind("Remove") %>' runat="server" />
                                                                                    </span>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="12" style="border-bottom: 1px solid #ccc; padding-bottom: 6px;">
                                                                        <%--<asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                            <ContentTemplate>--%>
                                                                        <asp:Repeater ID="rptListBox" runat="server">
                                                                            <ItemTemplate>
                                                                                <div style="display: inline-block;">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <%# (Container.ItemIndex + 8) % 8 == 0 ? "<tr>" : string.Empty%>
                                                                                            <td>
                                                                                                <div>
                                                                                                    <asp:Label ID="lblss" runat="server" Text='<%# Eval("Name") %>' Style="text-transform: capitalize !important"></asp:Label>
                                                                                                    <span class="da_astrx_mand">*</span>
                                                                                                    <asp:HiddenField ID="hdnfldDeginationID" runat="server" Value='<%# Bind("DesignationID") %>' />
                                                                                                </div>
                                                                                                <div>
                                                                                                    <asp:ListBox ID="LBdesignation" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client sales">
                                                                                                    </asp:ListBox>
                                                                                                    <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="0"
                                                                                                        ValidationGroup="Submit" ControlToValidate="LBdesignation" ErrorMessage="Please select atleast one user."></asp:RequiredFieldValidator>-->
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%# (Container.ItemIndex + 8) % 8 == 7 ? "</tr>" : string.Empty%>
                                                                                    </table>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                        <%--  </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                                        <%--<table cellpadding="1" cellspacing="5" width="100%">
                                                                            <tr class="td-sub_headings">
                                                                                <td>
                                                                                    Sales<span class="da_astrx_mand">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    Account Manager
                                                                                </td>
                                                                                <td runat="server" id="tdDes" class="design">
                                                                                    <asp:Label ID="lblDesign1" CssClass="design" runat="server" Text="Designer "></asp:Label><span
                                                                                        class="da_astrx_mand">*</span>
                                                                                </td>
                                                                                <td runat="server" id="tdTech" class="tech">
                                                                                    <asp:Label ID="lblTech1" Text="Technologist " CssClass="tech" runat="server"></asp:Label>
                                                                                    <span class="da_astrx_mand">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    Shipping Manager <span class="da_astrx_mand">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    Delivery Manager <span class="da_astrx_mand">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblFitMer1" Text="FIT Merchant " CssClass="fitMer" runat="server"></asp:Label>
                                                                                    <span class="da_astrx_mand">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSamplingMer1" CssClass="sampMer" runat="server" Text="Sampling Merchant "></asp:Label><span
                                                                                        class="da_astrx_mand">*</span>
                                                                                </td>
                                                                                <td>
                                                                                    Client QA Head <span class="da_astrx_mand">*</span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="inner_tbl_td">
                                                                                    <asp:ListBox ID="ddSales1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client sales">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td">
                                                                                    <asp:ListBox ID="ddAccountManager1" runat="server" AutoPostBack="false" SelectionMode="Multiple"
                                                                                        CssClass="da_text_area_client"></asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td design" runat="server" id="tdDes1">
                                                                                    <asp:ListBox ID="ddDesigner1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td tech" runat="server" id="tdTech1">
                                                                                    <asp:ListBox ID="ddTechnologist1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td">
                                                                                    <asp:ListBox ID="ddShippingManager1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td">
                                                                                    <asp:ListBox ID="ddDeliveryManager1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td">
                                                                                    <asp:ListBox ID="ddFITMerchant1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td">
                                                                                    <asp:ListBox ID="ddSamplingMerchant1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                                <td class="inner_tbl_td">
                                                                                    <asp:ListBox ID="ddClientHead1" runat="server" SelectionMode="Multiple" CssClass="da_text_area_client">
                                                                                    </asp:ListBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                                <div align="right">
                                    <asp:ImageButton ID="imgAddDept" ValidationGroup="Add" CausesValidation="true" runat="server"
                                        ImageUrl="../../App_Themes/ikandi/images/plus_icon.gif" OnClick="imgAddDept_Click" />
                                    <span class="da_remove_btn_dafo">Add More &nbsp;</span>
                                </div>
                            </div>
                            &nbsp;
                            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                                style="margin-top: 0px;">
                                <caption class="caption_headings">
                                    External Assignments
                                </caption>
                                <tr>
                                    <td>
                                        <div class="form_box" style="border: none;">
                                            <div id="divContacts">
                                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="6" id="tblClientContacts">
                                                    <asp:Repeater ID="Repeater2" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
                                                        <ItemTemplate>
                                                            <asp:Panel ID="Panel2" runat="server">
                                                                <tr class="td-sub_headings">
                                                                    <td width="10%" style="padding: 0 0 0 5px" valign="bottom">
                                                                        &nbsp;Name
                                                                    </td>
                                                                    <td width="10%" style="padding: 0 0 0 5px" valign="bottom">
                                                                        &nbsp;Email
                                                                    </td>
                                                                    <td width="10%" style="padding: 0 0 0 5px" valign="bottom">
                                                                        &nbsp;Phone
                                                                    </td>
                                                                    <td width="30%" valign="bottom">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td colspan="3" valign="bottom">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="inner_tbl_td">
                                                                        <asp:TextBox ID="txtName1" Text='<%# Bind("Name") %>' runat="server"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdnContactID1" Value='<%# Bind("ContactID") %>' runat="server" />
                                                                    </td>
                                                                    <td class="inner_tbl_td">
                                                                        <asp:TextBox ID="txtEmail1" Text='<%# Bind("Email") %>' MaxLength="30" runat="server"
                                                                            CssClass=" emailName"></asp:TextBox>
                                                                    </td>
                                                                    <td class="inner_tbl_td">
                                                                        <asp:TextBox ID="txtPhone1" Text='<%# Bind("Phone") %>' MaxLength="42" runat="server"
                                                                            CssClass=""></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td width="24%">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td width="7%" valign="bottom">
                                                                        <span class="da_remove_btn_dafo"></span>
                                                                    </td>
                                                                    <td width="6%" valign="bottom">
                                                                        <span class="da_remove_btn_dafo" style="text-align: right;">
                                                                            <asp:ImageButton ID="imgRemove" OnClick="imgRemoveExt_Click" runat="server" ImageUrl="~/App_Themes/ikandi/images/minus_icon.gif" />&nbsp;Remove
                                                                            <asp:HiddenField ID="hdnDelete" Value='<%# Bind("Remove") %>' runat="server" />
                                                                        </span><span class="da_remove_btn_dafo add-more">
                                                                    </td>
                                                                </tr>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </div>
                                            <div align="right" class="add-more">
                                                <asp:ImageButton ID="imgAddExt" runat="server" ImageUrl="../../App_Themes/ikandi/images/plus_icon.gif"
                                                    OnClick="imgAddExt_Click" />
                                                <span class="da_remove_btn_dafo">Add More &nbsp;</span>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="form_buttom">
                <table border="0" cellspacing="4" cellpadding="4">
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="btnSubmit" CssClass="da_submit_button submit" CausesValidation="true"
                                ValidationGroup="Submit" OnClientClick="return tovalidate();" Text="Submit" OnClick="Submit_Click" />
                        </td>
                        <td>
                            <input type="button" id="btnPrint" runat="server" value="Print" class="da_submit_button "
                                onclick="return PrintPDFQueryString('','','','&btn=1');" />
                        </td>
                        <td>
                            <input id="btnClose" type="button" value="Close" class="da_submit_button" onclick="Reload();" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:PostBackTrigger ControlID="ddlDivisionName" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="10" class="da_table_heading_bg_left">
                &nbsp;
            </td>
            <td width="1205" class="da_table_heading_bg">
                <span class="da_h1">Confirmation</span>
            </td>
            <td width="13" class="da_table_heading_bg_right">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="form_box">
        <div class="text-content">
            Client have been saved into the system successfully!
            <br />
            <a id="A1" href="~/internal/Client/ClientListing.aspx" runat="server">Click here</a>
            to Client List.</div>
    </div>
</asp:Panel>
