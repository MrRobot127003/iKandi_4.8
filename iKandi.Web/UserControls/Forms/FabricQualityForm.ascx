<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricQualityForm.ascx.cs"
    Inherits="iKandi.Web.FabricQualityForm" %>
 <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>--%>

<%--<link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />
<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>--%>

  <script type="text/javascript">

      $(function () {
          $(".th").datepicker({ dateFormat: 'dd M y (D)' });
      });
  
  </script>   
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var jscriptPageVariables = null;
    var OriginDDClientID = '<%=ddlOrigin.ClientID %>';
    var txtWidthInchClientID = '<%=txtWidthInch.ClientID %>';
    var txtWidthCmClientID = '<%=txtWidthCm.ClientID %>';
    var txtSupplierReferenceNoClientID = '<%=txtSupplierReference.ClientID %>';
    var GroupDDClientID = '<%=ddlGroup.ClientID%>';
    var SubGroupDDClientID = '<%=ddlSubGroup.ClientID%>';
    var selectedSubGroup;
    var hdnSubGroupClientID = '<%=hiddenSubGroupId.ClientID %>';
    var txtIdentificationClientID = '<%=txtIdentification.ClientID %>';
    var txtTradeNameClientID = '<%=txtTradeName.ClientID %>';
    var prevSubGroup;

    function extractNumber(obj, decimalPlaces, allowNegative) {
        var temp = obj.value;

        // avoid changing things if already formatted correctly
        var reg0Str = '[0-9]*';
        if (decimalPlaces > 0) {
            reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
        } else if (decimalPlaces < 0) {
            reg0Str += '\\.?[0-9]*';
        }
        reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
        reg0Str = reg0Str + '$';
        var reg0 = new RegExp(reg0Str);
        if (reg0.test(temp)) return true;

        // first replace all non numbers
        var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
        var reg1 = new RegExp(reg1Str, 'g');
        temp = temp.replace(reg1, '');

        if (allowNegative) {
            // replace extra negative
            var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
            var reg2 = /-/g;
            temp = temp.replace(reg2, '');
            if (hasNegative) temp = '-' + temp;
        }

        if (decimalPlaces != 0) {
            var reg3 = /\./g;
            var reg3Array = reg3.exec(temp);
            if (reg3Array != null) {
                // keep only first occurrence of .
                //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
                var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
                reg3Right = reg3Right.replace(reg3, '');
                reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
                temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
            }
        }

        obj.value = temp;
    }




    function GetIdBySupplierReference() {
        proxy.invoke("GetIdBySupplierReferenceNo", { SupplierReferenceNo: ($("#<%=txtSupplierReference.ClientID %>")).val() },
    function (result) {
        if (result > 0) {
            window.location = "/Internal/Fabric/FabricQualityEdit.aspx?fabricqualityid=" + result;
        }
    },

    onPageError, false, false);
    }

    $(function () {

        var elementsImported = $('input.elements-imported', '#main_content');
        var elementsIndian = $('input.elements-indian', '#main_content');
        prevSubGroup = $("#" + hdnSubGroupClientID, "#main_content").val();
        ShowHideOrigin($("#" + OriginDDClientID).val(), elementsImported, elementsIndian);

        $("#" + GroupDDClientID, '#main_content').change(function () {
            var groupId = $(this).val();
            populateSubGroups($(this).val());
            getIdentification($("#" + GroupDDClientID, '#main_content').val(), $("#" + SubGroupDDClientID, '#main_content').val());
        });

        $("#" + SubGroupDDClientID, '#main_content').change(function () {
            $("#" + hdnSubGroupClientID, "#main_content").val($(this).val());
            selectedSubGroup = $("#" + SubGroupDDClientID).find("option:selected").text();
            setSubGroup();
            if (prevSubGroup != $(this).val()) {
                getIdentification($("#" + GroupDDClientID, '#main_content').val(), $("#" + SubGroupDDClientID, '#main_content').val());
            }
            else if (prevSubGroup == $(this).val()) {
                var defVal = $("#" + txtIdentificationClientID, '#main_content')[0];
                $("#" + txtIdentificationClientID, '#main_content').val(defVal.defaultValue);
            }

        });

        populateSubGroups($("#" + GroupDDClientID, '#main_content').val());
        //debugger;
        $("input.fabricquality-suppliername", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQualitySupplierReference", { dataType: "xml", datakey: "string", max: 100 });
        //$("input.fabricquality-tradename", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQualityTradeName", { dataType: "xml", datakey: "string", max: 100 });
        $("input.supplier-name", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQualitySupplierName", { dataType: "xml", datakey: "string", max: 100 });



        $('input.WidthInch').change(function () {
            var WidthInInch = parseInt($("#" + txtWidthInchClientID, '#main_content').val()) * 2.54;
            $("#" + txtWidthCmClientID, '#main_content').val(WidthInInch);

        });


        //vikas//        $('input.WidthCm').change(function() {
        //            var WidthInCm = parseInt($("#" + txtWidthCmClientID, '#main_content').val()) * .39;
        //            $("#" + txtWidthInchClientID, '#main_content').val(WidthInCm);
        //vikas//        });

        $("input.fabricquality-suppliername").result(function () {

            GetIdBySupplierReference();
        });

        $("input.fabricquality-suppliername").change(function () {

            GetIdBySupplierReference();
        });

        $("a[rel=lightbox]").lightBox({

            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif',
            showTitle: false

        });

        $('.delete-history').click(function () {
            var objChkDeleteHistory = '<%= chkIsCommentsDeleted.ClientID %>';
            if ($("#" + objChkDeleteHistory).is(':checked')) {
                var message = confirm("ARE YOU SURE, YOU WANT TO DELETE HISTORY?");
                if (message) {
                    $("#" + objChkDeleteHistory).attr('checked', true);
                }
                else {
                    $("#" + objChkDeleteHistory).attr('checked', false);
                }
            }
            else {
                $("#" + objChkDeleteHistory).attr('checked', false);
            }
        });




        $("#" + OriginDDClientID).change(function () {
            ShowHideOrigin($(this).val(), elementsImported, elementsIndian)
        });

        //        $("input.fabricquality-tradename", "#main_content").result(function() {
        //           
        //            GetIdByTradeName();

        //        });

        //        $("input.fabricquality-tradename", "#main_content").change(function() {
        //           
        //            GetIdByTradeName();

        //        });


    });

    function populateSubGroups(groupId, selectedSubGroupID) {
        //debugger;
        if (groupId > 0)
            bindDropdown(serviceUrl, SubGroupDDClientID, "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroup);

        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        //alert($("#" + hdnSubGroupClientID, "#main_content").val());
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function setSubGroup() {

        selectedSubGroup = $("#" + SubGroupDDClientID, "#main_content").val();
        //   alert(selectedSubGroup);
        //   $("#" + hdnSubGroupClientID, "#main_content").val(selectedSubGroup);
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function getIdentification(groupId, subGroupId) {
        // debugger;       
        proxy.invoke("GetIdentification", { CategoryID: groupId, SubCategoryID: subGroupId, Type: 1 },
         function (result) {
             $("#" + txtIdentificationClientID, '#main_content').val(result);
         }, onPageError, false, false);
    }

    function ValidateTradeName(oSrc, args) {
        var result = IsTradeNameUnique(args.Value);
        args.IsValid = result;
    }

    function IsTradeNameUnique(tradeName) {
        if (($("#<%=txtTradeName.ClientID %>")).val() == '') return true;

        var isValid = true;

        proxy.invoke("GetIdByTradeName", { TradeName: ($("#<%=txtTradeName.ClientID %>")).val(),
            SupplierReference: ($("#<%=txtSupplierReference.ClientID %>")).val()
        },
         function (result) {
             if (result > 0)
                 isValid = false;
         },
         onPageError, false, true);

        return isValid;
    }

    function GetIdByTradeName() {
        proxy.invoke("GetIdByTradeName", { TradeName: ($("#<%=txtTradeName.ClientID %>")).val() },
            function (result) {
                if (result > 0) {
                    var trade = $("#<%=txtTradeName.ClientID %>").val();
                    jQuery.facebox('Trade Name: ' + trade + ' already exists. Try again with different Trade Name');
                    $("#<%=txtTradeName.ClientID %>").val('');
                    return false;
                }
            },

        onPageError, false, false);
    }
    function GetIdByTradeNamenew() {

        debugger;
//        alert($("#<%=hdnfabqualityname.ClientID %>").val().trim() + " " + $("#<%=txtTradeName.ClientID %>").val().trim());
        var oldval = $("#<%=hdnfabqualityname.ClientID %>").val().trim();
          var newval = $("#<%=txtTradeName.ClientID %>").val().trim();
          if (oldval.toLowerCase() == newval.toLowerCase()) {
             
          }
          else {
              proxy.invoke("GetIdByTradeName", { TradeName: ($("#<%=txtTradeName.ClientID %>")).val() },
            function (result) {
                if (result > 2) {
                    var trade = $("#<%=txtTradeName.ClientID %>").val();
                    jQuery.facebox('Trade Name: ' + trade + ' already exists. Try again with different Trade Name');
                    $("#<%=txtTradeName.ClientID %>").val(oldval);
                    return false;
                }
            },

        onPageError, false, false);
          }
    }
    function deleteImg(srcElem, imageId) {
        proxy.invoke("ImageDelete", { ImageId: imageId },
         function (result) {
             if (result) {
                 $(srcElem).parent().hide();
             }
             return true;
         },
         onPageError, false, true);
        return false;

    }
    function showHistory(elem) {
        //debugger;
        //Added By Ashish on 12/1/2014

        var FabricQualityID = "";

        FabricQualityID = document.getElementById('<%=hdnQID.ClientID %>').value;
        alert(FabricQualityID);
        var url = 'frmFabricHistory.aspx?FabricQualityID=' + FabricQualityID;
        window.open(url, '_blank', 'height=250,width=500,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
        return false;
    }

    function ShowHideOrigin(origin, elementsImported, elementsIndian) {
        if (origin == 1) { // INDIAN
            for (var i = 0; i < elementsImported.length; i++) {
                if (elementsImported[i] != null) {
                    $("#" + elementsImported[i].id).attr("disabled", "disabled");
                    $("#" + elementsImported[i].id).parent().parent().parent().hide();
                    $("#" + elementsImported[i].id).parent().parent().parent().prev().hide();
                }
            }
            for (var i = 0; i < elementsIndian.length; i++) {
                if (elementsIndian[i] != null) {
                    $("#" + elementsIndian[i].id).removeAttr("disabled");
                    $("#" + elementsIndian[i].id).parent().parent().parent().show();
                    $("#" + elementsIndian[i].id).parent().parent().parent().prev().show();
                }
            }
        }
        else if (origin == 2) { // IMPORTED
            for (var i = 0; i < elementsIndian.length; i++) {
                if (elementsIndian[i] != null) {
                    $("#" + elementsIndian[i].id).attr("disabled", "disabled");
                    $("#" + elementsIndian[i].id).parent().parent().parent().hide();
                    $("#" + elementsIndian[i].id).parent().parent().parent().prev().hide();
                }
            }
            for (var i = 0; i < elementsImported.length; i++) {
                if (elementsImported[i] != null) {
                    $("#" + elementsImported[i].id).removeAttr("disabled");
                    $("#" + elementsImported[i].id).parent().parent().parent().show();
                    $("#" + elementsImported[i].id).parent().parent().parent().prev().show();
                }
            }
        }
    }

</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
h2
{
    color:#39589c;
    text-align:center;
    margin:0px;
    padding:0px;
    font-size:18px;
    font-weight:normal;
}
h3
{
    color:#39589c;
    margin:0px;
    padding:0px;
     font-size:16px;
   font-weight:normal;
}
.form_heading
{
    background:#39589c;
    color:#fff;
    border-bottom:0px;
    padding:5px;
   font-weight:bold;
   text-transform: capitalize;
}
table
{
    border: 1px solid gray;
}
.item_list {
    border: 1px solid #cfcfcf;
}
.item_list th {
    padding-left: 4px !important;
    padding-right: 4px !important;
}
.item_list TD {
    text-align: left;
}
</style>
<asp:Panel runat="server" ID="pnlFabricForm">
    <div class="print-box">
        <div class="form_heading form_box">
            Fabric Quality
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list" border=3 bordercolor="Black" >
                <tr>
                    <td colspan="6" style="text-align: left">
                        <h2>Classification </h2>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 16.6%;">
                        Group*
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:DropDownList ID="ddlGroup" runat="server">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="ddlGroup" ValidationGroup="submit" InitialValue="-1" ErrorMessage="Select Group"></asp:RequiredFieldValidator>
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Sub Group
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:DropDownList ID="ddlSubGroup" runat="server">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hiddenSubGroupId" Value="-1" />
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Trade Name*
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtTradeName" onchange="GetIdByTradeNamenew();" CssClass="fabricquality-tradename"
                            Style="text-align: left" MaxLength="65"></asp:TextBox>
                            <asp:HiddenField ID="hdnfabqualityname" runat="server"  />
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfvTradeName" ValidationGroup="submit" runat="server"
                                Display="Dynamic" ControlToValidate="txtTradeName" ErrorMessage="Trade Name is required"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Identification
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtIdentification" CssClass="do-not-allow-typing" runat="server"
                            Style="text-align: left"></asp:TextBox>
                    </td>
                    <th style="text-align: left">
                        Supplier Reference*
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtSupplierReference" runat="server" CssClass="fabricquality-suppliername"
                            Style="text-align: left" MaxLength="43"></asp:TextBox>
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfvSupplierReferenc" runat="server" Display="Dynamic"
                                ValidationGroup="submit" ControlToValidate="txtSupplierReference" ErrorMessage="Supplier Reference is required"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <th style="text-align: left">
                        BIPL Registered
                    </th>
                    <td style="text-align: left">
                        <asp:CheckBox ID="chkBiplRegistered" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
        
        
        
        
        
        
        
        
            <table class="item_list" width="100%" border="3" bordercolor="Black">
                <tr>
                    <td colspan="4" style="text-align: left">
                        <h2> Client and Supplier </h2>
                    </td>
                </tr>
                <tr>
                    <th rowspan="2" style="text-align: left; width: 25%;">
                        Buyer
                    </th>
                    <td rowspan="2" style="text-align: left; width: 25%;">
                        <asp:ListBox runat="server" ID="lstClients" SelectionMode="Multiple"></asp:ListBox>
                    </td>
                    <th style="text-align: left; width: 25%;">
                        Origin
                    </th>
                    <td style="text-align: left; width: 25%;">
                        <asp:DropDownList runat="server" ID="ddlOrigin">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Supplier Name
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox runat="server" ID="txtSupplierName" CssClass="supplier-name" Style="text-align: left"></asp:TextBox>
                    </td>
                </tr>
            </table>
            
            
            <br />
            
            <table class="item_list" width="100%" border="3" bordercolor="Black">
                <tr>
                    <td colspan="4" style="text-align: left">
                        <h2> Stock Details </h2>
                    </td>
                </tr>
                <tr>
                    <th rowspan="2" style="text-align: left; width: 25%;">
                        Min. Stock Qty.
                    </th>
                    <td rowspan="2" style="text-align: left; width: 25%;">
                        <asp:TextBox ID="txtQty" runat="server" onkeyup="extractNumber(this,0,false);" ></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 25%;">
                        Unit
                    </th>
                    <td style="text-align: left; width: 25%;">
                        <asp:DropDownList runat="server" ID="ddlQtyType">                           
                            <asp:ListItem Text="Mtr" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Kg" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
              
            </table>
            
            
            
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list" border=3 bordercolor="Black">
                <tr>
                    <td colspan="7" style="text-align: left">
                        <h2> Technical Details </h2>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 14.2%;">
                        Count / Construction
                    </th>
                    <td style="text-align: left; width: 14.2%;">
                        <asp:TextBox runat="server" ID="txtCount" MaxLength="48" Style="text-align: left"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 14.2%;">
                        Composition
                    </th>
                    <td style="text-align: left; width: 14.2%;">
                        <asp:TextBox runat="server" ID="txtComposition" MaxLength="98" Style="text-align: left"></asp:TextBox>
                        <%--                      <asp:RequiredFieldValidator ID="rfvComposition" runat="server" ControlToValidate="txtComposition" 
                         ErrorMessage="Compostion is required" Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>--%>
                    </td>
                    <th style="text-align: left; width: 14.2%;">
                        GSM - (Grams Per Sq Meter)
                    </th>
                    <td style="text-align: left; width: 14.2%;">
                        <asp:TextBox runat="server" ID="txtGSM" CssClass="numeric-field-with-two-decimal-places"
                            Style="text-align: left" MaxLength="10"></asp:TextBox>
                    </td>
                    <td style="text-align: left; width: 14.2%;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Width
                    </th>
                    <td style="text-align: left">
                        <asp:TextBox runat="server" Width="60" ID="txtWidthInch" CssClass="WidthInch numeric-field-with-decimal-places "
                            Style="text-align: left" MaxLength="7"></asp:TextBox>
                             <asp:HiddenField ID="hdnWidthInch" runat="server" />
                        (Inch)
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox Width="60" runat="server" ID="txtWidthCm" CssClass="WidthCm numeric-field-with-decimal-places"
                            Style="text-align: left" MaxLength="7"></asp:TextBox>
                        (Centimeter)
                    </td>
                    <th style="text-align: left">
                        Technical Name
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtFabric" MaxLength="43" Style="text-align: left"></asp:TextBox>
                    </td>
                    <th style="text-align: left">
                        Wastage
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtWastage" Style="text-align: left; width: 80%;"
                            CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>%
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list" border=3 bordercolor="Black">
                <tr>
                    <td colspan="6" style="text-align: left">
                       <h2> Limitations </h2>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 16.6%;">
                        Upload Base Test
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:FileUpload runat="server" ID="fileBaseTest" />
                        <a target="_blank" href="" runat="server" id="basetestfile" visible="false">link</a>
                        <asp:HiddenField runat="server" ID="hdnUpdateBaseFilePath" />
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Date When Test Conducted
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtTestDate" CssClass="date-picker date_style" Style="text-align: left"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Minimum Order Quantity (MOQ)
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtMOQ" CssClass="numeric-field-with-decimal-places "
                            Style="text-align: left" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 16.6%;">
                        Comments<br />
                        <nobr>Delete History &nbsp;&nbsp;<asp:CheckBox ID="chkIsCommentsDeleted" runat="server" CssClass="delete-history" /></nobr>
                    </th>
                    <td colspan="5" style="text-align: left;">
                        <asp:TextBox ID="txtComments" Width="100%" CssClass="form_small_heading_yellow" runat="server"
                            Rows="3" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <div style="width: 100%; height: 80px; overflow-y: auto !important;">
                            <asp:Label ID="lblCommentHistory" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list" border=3 bordercolor="Black">
                <tr>
                    <td style="text-align: left" colspan="6">
                       <h2> Lead Time In Days </h2>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 16.6%;">
                        Greige
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtLeadTimeGreige" CssClass="numeric-field-without-decimal-places "
                            Style="text-align: left" MaxLength="6"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Dyed
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtLeadTimeDying" CssClass="numeric-field-without-decimal-places "
                            Style="text-align: left" MaxLength="6"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Printed
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtLeadTimePrinting" CssClass="numeric-field-without-decimal-places "
                            Style="text-align: left" MaxLength="6"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list" border=3 bordercolor="Black">
                <tr>
                    <td colspan="7" style="text-align: left">
                        <h2> Financial (Rs.) </h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="text-align: left">
                        <h3> Imported </h3>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left;">
                        Air
                    </th>
                    <th style="text-align: left; width: 14.2%;">
                        Greige
                    </th>
                    <td style="text-align: left; width: 14.2%;">
                        <nobr>Rs.
                       <asp:TextBox runat="server" ID="txtAirGreigePrice" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-imported"></asp:TextBox>
                   
                       </nobr>
                       <asp:HiddenField ID="hdnAirGreigePrice" runat="server" />
                    </td>
                    <th style="text-align: left; width: 14.2%;">
                        Dyed
                    </th>
                    <td style="text-align: left; width: 14.2%;">
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtAirDyingPrice" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-imported"></asp:TextBox>
                        </nobr>
                         <asp:HiddenField ID="hdnAirDyingPrice" runat="server" />
                    </td>
                    <th style="text-align: left; width: 14.2%;">
                        Printed
                    </th>
                    <td style="text-align: left; width: 14.2%;">
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtAirPrintingPrice" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-imported"></asp:TextBox>
                        </nobr>
                        <asp:HiddenField ID="hdnAirPrintingPrice" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Sea
                    </th>
                    <th style="text-align: left">
                        Greige
                    </th>
                    <td>
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtSeaGreigePrice" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-imported"></asp:TextBox>
                        </nobr>
                         <asp:HiddenField ID="hdnSeaGreigePrice" runat="server" />
                    </td>
                    <th style="text-align: left">
                        Dyed
                    </th>
                    <td>
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtSeaDyingPrice" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-imported"></asp:TextBox>
                        </nobr>
                         <asp:HiddenField ID="hdnSeaDyingPrice" runat="server" />
                    </td>
                    <th style="text-align: left">
                        Printed
                    </th>
                    <td>
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtSeaPrintingPrice" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-imported"></asp:TextBox>
                        </nobr>
                         <asp:HiddenField ID="hdnSeaPrintingPrice" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="text-align: left">
                      <h3>  Indian </h3>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        &nbsp;
                    </th>
                    <th style="text-align: left">
                        Greige
                    </th>
                    <td>
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtGreigeIndian" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-indian"></asp:TextBox>
                        </nobr>
                        <asp:HiddenField ID="hdnGreigeIndian" runat="server" />
                    </td>
                    <th style="text-align: left">
                        Dyed
                    </th>
                    <td>
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtDyedIndian" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-indian"></asp:TextBox>
                        </nobr>
                            <asp:HiddenField ID="hdnDyedIndian" runat="server" />
                    </td>
                    <th style="text-align: left">
                        Printed
                    </th>
                    <td>
                        <nobr>Rs.
                        <asp:TextBox runat="server" ID="txtPrintedIndian" style="text-align: left;width:80%" CssClass="numeric-field-with-two-decimal-places elements-indian"></asp:TextBox>
                        </nobr>
                            <asp:HiddenField ID="hdnPrintedIndian" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list" border=3 bordercolor="Black">
                <tr>
                    <td colspan="3" style="text-align: left">
                       <h2> Upload </h2>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 33.3%;">
                        Upload Pic:
                    </th>
                    <td style="text-align: left; width: 33.3%;">
                        <asp:FileUpload runat="server" ID="fileFabricPic" class="multi" accept="gif|jpg|bmp|png" />
                    </td>
                    <td style="text-align: left; width: 33.3%;">
                        <asp:Repeater ID="rptUploadPicture" runat="server">
                            <ItemTemplate>
                                <div style="vertical-align: middle;" id="divImg" runat="server">
                                    <asp:HyperLink ID="hypSample1" runat="server" rel="lightbox" NavigateUrl='<%# ResolveUrl("~/Uploads/Quality/" + (Eval("ImageFile"))) %>'>
                                        <asp:Image runat="server" ID="imgFabricPic" CssClass="lightbox" Width="60px" Height="60px"
                                            ImageUrl='<%# ResolveUrl("~/uploads/Quality/thumb-" + (Eval("ImageFile"))) %>' />
                                    </asp:HyperLink>
                                    <asp:HiddenField runat="server" ID="hidImgId" Value='<%# Eval("id")%>' />
                                    <input type="button" id="btnImageDelete" class="cross" onclick='return deleteImg(this,<%# Eval("id")%>)' />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form_box">
            <table width="100%" class="item_list" border=3 bordercolor="Black">
                <tr>
                    <td colspan="3" style="text-align: left">
                       <h2> Authorised Signatures </h2>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 33.3%;">
                        Date:
                    </th>
                    <td style="text-align: left; width: 33.3%;">
                        <asp:TextBox runat="server" ID="txtApprovalDate" CssClass="th"
                            Style="text-align: left"></asp:TextBox>
                    </td>
                    <td style="text-align: left; width: 33.3%;">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="hdnQID" runat="server" />
    <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" Text="Submit" ValidationGroup="submit"
            OnClick="btnSubmit_Click" />
        <asp:Button runat="server" ID="btnPrint" CssClass="print da_submit_button" Text="Print" OnClientClick="return PrintPDF(); return false;" />
        <asp:Button runat="server" ID="btnHistory" CssClass="history da_submit_button" Text="History"  OnClientClick="javascript:return showHistory(this);" />
    </div>
    <div>
      -
          
       
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Fabric Quality have been saved into the system successfully!
            <br />
            <a id="A1" href="../../Internal/Fabric/FabricQualityListing.aspx" runat="server">Click
                here </a>to Fabric Quality List.</div>
    </div>
</asp:Panel>
<%--<asp:HiddenField ID="hdnQID" runat="server" />--%>
<asp:Panel runat="server" ID="pnlError" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            This Fabric Quality has not been saved due to dublicate Identification Number or
            Some Error occurs while saving data!
            <br />
            <a id="A2" href="../../Internal/Fabric/FabricQualityListing.aspx" runat="server">Click
                here </a>to Fabric Quality List.</div>
    </div>
</asp:Panel>
