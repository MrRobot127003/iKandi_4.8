<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupplierAdmin.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.SupplierAdmin" %>

<script type="text/javascript">

    var cblType = '<%=cblSupplyType.ClientID%>';
    var cblProcess = '<%=cblProcess.ClientID%>';
    var cblFgn = '<%=cblFgN.ClientID%>';
    var GroupNameId = '<%=txtGroupName.ClientID%>';
    var GroupInitId = '<%=txtGroupInit.ClientID%>';
    var SupplierNameId = '<%=txtSupplierName.ClientID%>';
    var SupplierInitId = '<%=txtSupplierInit.ClientID%>';
    var Errlbl = '<%=errlbl.ClientID%>';
    var dupSupplier = 'dupSupplier';
    var hf = '<%=hf.ClientID%>';
    var GroupInitEdit = 'GroupInitEdit';

    var mc = '<%=txtMonthlyCapacity.ClientID%>';
    var slt = '<%=txtSltime.ClientID%>';

    var divProcess = 'divProcess';
    var jscriptPageVariables = null;
    var supplierId = -1;
    var isGroupIniDup = false;
    var isGroupDup = false;
    var isSupplierDup = false;
    var isSupplierDupIni = false;
    var isSubmitClicked = false;
    var showProcess = false;
    jQuery.expr[':'].regex = function (elem, index, match) {
        var matchParams = match[3].split(','),
        validLabels = /^(data|css):/,
        attr = {
            method: matchParams[0].match(validLabels) ?
                        matchParams[0].split(':')[0] : 'attr',
            property: matchParams.shift().replace(validLabels, '')
        },
        regexFlags = 'ig',
        regex = new RegExp(matchParams.join('').replace(/^\s+|\s+$/g, ''), regexFlags);
        return regex.test(jQuery(elem)[attr.method](attr.property));
    }

    function ResetAll() {
        try {
            $("input[type=text]").each(function () {
                $(this).val("");
            });
            $("input[type=checkbox]").each(function () {
                $(this).attr('checked', false);
            });
            $("textarea").each(function () {
                $(this).val("");
            });
            $("#" + Errlbl).html("");
            isGroupIniDup = true;
            isGroupDup = true;
            isSupplierDup = true;
            isSupplierDupIni = true;
            disableAllValidators();
            return false;
        } catch (e) {
        }
        return false;
    }

    function disableAllValidators() {
        if (window.Page_Validators) {
            for (var vI = 0; vI < Page_Validators.length; vI++) {
                var vValidator = Page_Validators[vI];
                vValidator.isvalid = true;
                ValidatorUpdateDisplay(vValidator);
            }
        }
    }

    function deleteRow_new(srcElem) {
        var objRow = $(srcElem).parents("tr");
        var rowindex = objRow.get(0).rowIndex;
        var objTable = objRow.parents("table").attr("id");
        var row = $("#" + objTable).find("tr").filter("tr:eq(" + rowindex + ")");
        var mainRow = row.attr("id").split('_');
        var newval = parseInt($("#hdntotal" + mainRow[1]).val()) - 1;
        $("#hdntotal" + mainRow[1]).val(newval);
        row.remove();
        var val = parseInt($("#" + '<%=hdnaddtr.ClientID%>').val());
        val = val - 1;
        $("#" + '<%=hdnaddtr.ClientID%>').val(val)
    }

    function addRow_new(srcElem) {
        var objRow = $(srcElem).parents("tr");
        var objTable = $(objRow).parents("table").attr("id");
        var val = parseInt($("#" + '<%=hdnaddtr.ClientID%>').val());
        if (val < 5) {
            var row = $("#" + objTable + " tr:last").prev("tr").clone(true).insertAfter($("#" + objTable + " tr:last").prev("tr"));
            var newLastRow = $("#" + objTable + " tr:last").prev("tr");
            var newLastRowId = $("#" + objTable + " tr:last").prev("tr").attr("id");
            //alert(newLastRowId);

            var newLastRowDtl = newLastRowId.split("_");
            var IdNo = parseInt(newLastRowDtl[1]);


            var rowId = newLastRow.attr("id");
            //alert(rowId);
            var mainRow = rowId.split("_");
            //var newRowIndex = mainRow[1];
            mainRow[0] = mainRow[0] + '_';
            newLastRow.attr("id", mainRow[0] + (IdNo + 1));
            var newval = parseInt($("#hdntotal").val()) + 1;
            $("#hdntotal").val(newval);
            newLastRow.attr("id", mainRow[0] + (IdNo + 1));
            newLastRow.attr("id")
            newLastRow.find("input").val("");
            newLastRow.find("input:first").focus();
            newLastRow.find("span").show();
            newLastRow.find("input,textarea,span").val("").each(function () {

                var name = $(this).attr("name");
                var mainName = name.split("_");
                name = mainName[0];
                $(this).attr("name", name + '_' + (IdNo + 1));

                var id = $(this).attr("id");
                var mainId = id.split("_");
                id = mainId[0];
                $(this).attr("id", id + '_' + (IdNo + 1));

            });

            /*newLastRow.show();*/
            //  newLastRow.find("#btnDeleteRow" + newRowIndex + '_' + (IdNo + 1)).show();
            //  newLastRow.find("#btnDeleteRow" + newRowIndex + '_' + (IdNo + 1)).attr("class", "");
            val = val + 1;
            $("#" + '<%=hdnaddtr.ClientID%>').val(val)
        }
    }


    //
    function CheckEmail(srcElem) {

        if ($.trim(srcElem.value) != '') {

            if (validateEmail($.trim(srcElem.value)) == false) {
                alert("Email is not valid");
                srcElem.focus();
            }
        }
    }

    function CheckDuplicateEmail(srcElem) {

        if ($.trim(srcElem.value) != '' && validateEmail($.trim(srcElem.value)) == false)
            return;
        //        var dup = 0;
        //        var count = parseInt($("#hdntotal").val());
        //        //
        //        var flag = false;
        //        for (var i = 1; i <= count; i++) {
        //            if (document.getElementById("txtemail_" + i) == undefined || $.trim($("#txtemail_" + i).val()) == '')
        //                continue;
        //            dup++;
        //            if ($.trim($("#txtemail_" + i).val()).toLowerCase() == $.trim(srcElem.value).toLowerCase() && srcElem.id != ("txtemail_" + i)) {
        //                flag = true;
        //                break;
        //            }
        //        }
        //        if (flag == true) {
        //            alert("Duplicate email found at row : " + dup);
        //            srcElem.focus();
        //        }
    }

    function CheckDuplicatePhone(srcElem) {
        if ($.trim(srcElem.value) != '' && validateEmail($.trim(srcElem.value)) == false)
            return;
        //        var dup = 0;
        //        var count = parseInt($("#hdntotal").val());
        //        //debugger;
        //        var flag = false;
        //        for (var i = 1; i <= count; i++) {
        //            if (document.getElementById("txtphone_" + i) == undefined || $.trim($("#txtphone_" + i).val()) == '')
        //                continue;
        //            dup++;
        //            if ($.trim($("#txtphone_" + i).val()).toLowerCase() == $.trim(srcElem.value).toLowerCase() && srcElem.id != ("txtphone_" + i)) {
        //                flag = true;
        //                break;
        //            }
        //        }
        //        if (flag == true) {
        //            alert("Duplicate phone no. found at row : " + dup);
        //            srcElem.focus();
        //        }
    }

    function CheckDuplicateContacts() {

        var dup = 0;
        var count = parseInt($("#hdntotal").val());
        if (count == 1)
            return;
        var flag = false;
        for (var i = 1; i <= count; i++) {
            if (flag == true)
                break;
            if (document.getElementById("txtcp_" + i) == undefined || $.trim($("#txtcp_" + i).val()) == '')
                continue;
            dup++;
            var name = $("#txtcp_" + i).val();
            var email = $("#txtemail_" + i).val();
            var phone = $("#txtphone_" + i).val();
            for (var j = i + 1; j <= count; j++) {
                if (document.getElementById("txtcp_" + j) == undefined || $.trim($("#txtcp_" + j).val()) == '')
                    continue;
                var name1 = $("#txtcp_" + j).val();
                var email1 = $("#txtemail_" + j).val();
                var phone1 = $("#txtphone_" + j).val();
                if (name == name1 && email == email1 && phone == phone1) {
                    flag = true;
                    break;
                }
            }
        }
        if (flag == true) {
            $("#" + Errlbl).html("Duplicate contact found at row : " + dup);
        }
        return flag;
    }

    function CheckValidation() {

        isSubmitClicked = true;
        if (typeof (Page_ClientValidate) == 'function') {
            Page_ClientValidate();
        }

        if (Page_IsValid) {
            // do something
            // return true;
        }
        else {
            // do something else
            return false;
        }
        //debugger;
        //        if ($("#" + dupSupplier).val() != "0") {
        //            if ($("#" + dupSupplier).val() == "2")
        //                $("#" + Errlbl).html("Supplier already exists");
        //            else if ($("#" + dupSupplier).val() == "3")
        //                $("#" + Errlbl).html("Group Initials already exists");
        //            else if ($("#" + dupSupplier).val() == "4")
        //                $("#" + Errlbl).html("Supplier initials already exists");
        //            else if ($("#" + dupSupplier).val() == "5")
        //                $("#" + Errlbl).html("Group name already exists");
        //            return false;
        //        }
        if (isSupplierDup == true) {
            $("#" + Errlbl).html("Supplier already exists");
            return false;
        }
        if (isGroupIniDup == true) {
            $("#" + Errlbl).html("Group Initials already exists");
            return false;
        }
        if (isGroupDup == true) {
            $("#" + Errlbl).html("Group Name already exists");
            return false;
        }
        //        if (isSupplierDupIni == true) {
        //             $("#" + Errlbl).html("Supplier initials already exists");
        //            return false;
        //        }


        //        if (CheckDuplicateContacts() == true)
        //            return false;
        if ($.trim($("#" + GroupInitId).val()).length != 3) {
            $("#" + Errlbl).html("Group initials format is not valid.");
            return false;
        }
        var re = new RegExp("\\w{3} - \\w{3}");
        if ($("#" + SupplierInitId).val().match(re) == false || $("#" + SupplierInitId).val().match(re) == null) {
            $("#" + Errlbl).html("Supplier initials format is not valid.");
            return false;
        }
        var dup = 0;
        var count = parseInt($("#hdntotal").val());
        //debugger;
        var flag = false;
        for (var i = 1; i <= count; i++) {
            if (document.getElementById("txtcp_" + i) == undefined)
                continue;
            dup++;
            if ($.trim($("#txtcp_" + i).val()) == '') {
                alert("Contact person name is empty at row : " + dup);
                if (document.getElementById("txtcp_" + i) != undefined)
                    document.getElementById("txtcp_" + i).focus();
                return false;
            }
        }
        flag = false;
        //var tempState = "";
        $("input[type=checkbox]:regex(id," + cblType + ")").each(function () {

            var rr = $(this);
            if ($(this).attr("checked") == true) {
                //tempState = $(this).attr("id") != cblType + "_3";
                //tempState = $(this).length;
                flag = true;
            }

        });

        if (flag == false) {
            $("#" + Errlbl).html("Please select supplier type");
            return false;
        }

        if (parseInt($("#" + mc).val()) <= 0) {
            $("#" + Errlbl).html("Monthly capacity must be greater than zero");
            return false;
        }

        if (parseInt($("#" + slt).val()) <= 0) {
            $("#" + Errlbl).html("Supplier lead time must be greater than zero");
            return false;
        }

        flag = false;
        if (CheckTypeProcess() == true) {

            //            $("input[type=checkbox]:regex(id," + cblType + ")").each(function () {
            //                debugger;
            //                if ($(this).attr("checked") == true)
            //                    flag = false;
            //                              }
            //                if ($(this).attr("id") == cblType + "_3") {
            //                    return true;
            //                }

            //            });
            $("input[type=checkbox]:regex(id," + cblProcess + ")(" + cblType + ")").each(function () {
                if ($(this).attr("checked") == true)
                    flag = true;
            });


            if (flag == false) {
                //               
                $("#" + Errlbl).html("Please select process");
                //alert("Please select process");
                return false;
            }
        }



        flag = false;
        $("input[type=checkbox]:regex(id," + cblFgn + ")").each(function () {
            if ($(this).attr("checked") == true)
                flag = true;
        });

        if (flag == false) {
            $("#" + Errlbl).html("Please select fabric group name");
            return false;
        }
        return true;

    }

    function FillContacts(SupplierId) {
        //alert(SupplierId);
        proxy.invoke("GetContactsBySupplierId", { supplierId: SupplierId },
            function (objStyleFabricCollection) {
                if (objStyleFabricCollection != null) {
                    if (objStyleFabricCollection.length > 0)
                        SetContactToControls(1, objStyleFabricCollection[0].Name, objStyleFabricCollection[0].Email, objStyleFabricCollection[0].Phone, objStyleFabricCollection[0].Remarks);
                    for (var k = 1; k < objStyleFabricCollection.length; k++) {
                        $("#btnAddRow1_1").click();
                        SetContactToControls(k + 1, objStyleFabricCollection[k].Name, objStyleFabricCollection[k].Email, objStyleFabricCollection[k].Phone, objStyleFabricCollection[k].Remarks);
                    }
                }
            });
    }

    function SetContactToControls(id, name, email, phone, rem) {
        $("#txtcp_" + id).val(name);
        $("#txtemail_" + id).val(email);
        $("#txtphone_" + id).val(phone);
        $("#txtrem_" + id).val(rem);
    }

    function ShowProcess() {
        $("#" + cblProcess).show();
        $("#" + divProcess).show();
    }

    function HideProcess() {
        $("#" + cblProcess).hide();
        $("#" + divProcess).hide();
    }

    function CheckTypeProcess() {

        var flag = false;
        $("input[type=checkbox]:regex(id," + cblType + ")").each(function () {

            if ($(this).attr("id") != cblType + "_0" & $(this).attr("id") != cblType + "_2") {
                if ($(this).attr("checked") == true)
                    flag = true;

            }

        });
        if (flag == true)
            ShowProcess();
        else
            HideProcess();
        return flag;
        //alert("click");
    }

    $(function () {
        $("#" + GroupInitId).attr('readonly', true);
        $("#" + '<%=txtSupplierInit.ClientID%>').attr('readonly', true);
        $("input[type=checkbox]:regex(id," + cblType + ")").each(function () {
            $(this).change(function () {
                CheckTypeProcess();
            });
        });
        if (jscriptPageVariables != null && jscriptPageVariables.SupplierId != null && jscriptPageVariables.SupplierId != '') {
            alert(jscriptPageVariables.SupplierId);
        }
        $("input.style-groupname", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestGroupName", { dataType: "xml", datakey: "string", max: 100 });
        $("input.style-suppliername", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestSupplierpName", { dataType: "xml", datakey: "string", max: 100 });
    });

    function GetGroupInitials() {
        $("#" + GroupInitId).attr('readonly', false);
        if ($("#" + GroupInitEdit).val() != "0" && $.trim($("#" + GroupInitId).val()) != "")
            return;
        if (supplierId == -1) {
            var group = $.trim($("#" + GroupNameId).val());
            if (group == "" || group.length < 3) {
                $("#" + GroupInitId).val("");
                return;
            }
            $("#" + GroupInitId).val(group.substring(0, 3));
        }
        //CheckDuplicateGroupInit();
        CheckDuplicateSupplier();
    }

    function GetSupplierInitials() {

        var group = $.trim($("#" + GroupInitId).val());
        var supplier = $.trim($("#" + SupplierNameId).val());
        if (group == '' || supplier == '' || group.length < 3 || supplier.length < 3) {
            $("#" + SupplierInitId).val("");
            return;
        }
        var sinit = group + " - " + supplier.substring(0, 3);
        $("#" + SupplierInitId).val(sinit);
        CheckDuplicateSupplierInit();
        CheckDuplicateSupplier();
    }

    function CheckDuplicateSupplier() {
        var group = $.trim($("#" + GroupNameId).val());
        var supplier = $.trim($("#" + SupplierNameId).val());
        isSupplierDup = false;
        $("#" + Errlbl).html("");
        if (group == "" || supplier == "")
            return;
        proxy.invoke("GetDuplicateSupplier", { gName: group, sName: supplier, sid: supplierId },
            function (result) {
                if (parseInt(result) > 0) {
                    $("#" + Errlbl).html("Supplier already exists");
                    isSupplierDup = true;
                }
            });
    }

    function CheckDuplicateGroupName() {
        var group = $.trim($("#" + GroupNameId).val());
        isGroupDup = false;
        $("#" + Errlbl).html("");
        if (group == "")
            return;
        proxy.invoke("GetDuplicateGroupName", { gName: group, sid: supplierId },
            function (result) {
                if (parseInt(result) > 0) {
                    $("#" + Errlbl).html("Group Name already exists");
                    isGroupDup = true;
                }
            });
    }

    function CheckDuplicateGroupInit() {
        GetSupplierInitials();
        var group = $.trim($("#" + GroupInitId).val());
        isGroupIniDup = false;
        $("#" + Errlbl).html("");
        if (group == "")
            return;
        proxy.invoke("GetDuplicateGroupInit", { gName: group, sid: supplierId },
            function (result) {
                if ($.trim(result) != "") {
                    $("#" + Errlbl).html("Group initials already exists for Group Name " + result);
                    isGroupIniDup = true;
                }
            });
    }

    function CheckDuplicateSupplierInit() {

        var group = $.trim($("#" + GroupInitId).val());
        var supplier = $.trim($("#" + SupplierInitId).val());

        isSupplierDupIni = false;
        $("#" + Errlbl).html("");
        if (supplier == "")
            return;
        proxy.invoke("GetDuplicateSupplierInit", { sName: supplier },
            function (result) {
                if (parseInt(result) > 0) {

                    var abc = supplier + result;
                    $("#" + SupplierInitId).val(abc);
                    isSupplierDupIni = true;
                }


            });
    }
    //
    function IsEditable() {

        if ($("#" + GroupInitId).attr('readonly') == false)
            $("#" + GroupInitEdit).val("1");



    }

</script>

 <script type="text/javascript">
     function checkTextAreaMaxLength(textBox, e, length) {

         var mLen = textBox["MaxLength"];
         if (null == mLen)
             mLen = length;

         var maxLength = parseInt(mLen);
         if (!checkSpecialKeys(e)) {
             if (textBox.value.length > maxLength - 1) {
                 if (window.event)//IE
                 {
                     e.returnValue = false;
                     return false;
                 }
                 else//Firefox
                     e.preventDefault();
             }
         }
     }

     function checkSpecialKeys(e) {
         if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 35 && e.keyCode != 36 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
             return false;
         else
             return true;
     }

     function range() {
         //debugger;

         if (!(isEqual(no, 10, 17))) {
             alert("Phone should be min 10 & max 17 characters");

             return false;
         }
         else {
             return true;
         }
     }

     function isEqual(strValue, intLength) {
         var isValidLength;
         var newString = new String(strValue);
         isValidLength = true;

         if (newString.length < intLength)
             isValidLength = false;
         else if (newString.length > intLength)
             isValidLength = false;

         return isValidLength;
     }

     function IsEditsupp() {

         var txtSupInit = document.getElementById('<%=txtSupplierInit.ClientID%>').readOnly = true
         return false;
         return true;
     }

    </script>
    <script type="text/javascript">
        function onpasteEv(sender)
        { setTimeout('restrictTB("' + sender.id + '");', 100); }
        function restrictTB(sender) {
            //TO DO
            return false;
        }
        </script>
  
<style type="text/css">
 
     .TextColor
    {
   
       color:#0088cc;
       text-transform:none;
       font:12px/14px Arial, Helvetica, sans-serif;
     
    }
    .ColorAndAlign
    {
    text-align:left;
    font:bold 14px/14px Arial, Helvetica, sans-serif;
    height:23px;
    background: #324e79;
    text-transform:none;
    color:#FFFFFF;
        width: 194px;
    }
            
    
    .style2
    {
        width: 100%;
    }
            
    
    .style3
    {
        width: 77%;
    }
    .style4
    {
        width: 76%;
    }
</style>

<asp:ScriptManager ID="sm" runat="server">
</asp:ScriptManager>
<asp:Panel runat="server" ID="mainPanel" Visible="true">
    <%--<asp:UpdatePanel ID="upMain" runat="server">
        <ContentTemplate>--%>
            <input type="hidden" value="0" id="dupSupplier" />
            <table width="1200" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <%--  <td width="10" class="ColorAndAlign">
                                    &nbsp;
                                </td>--%>
                                <td width="1205" class="ColorAndAlign">
                                    <span>&nbsp;&nbsp; Supplier Admin</span>
                                </td>
                               <%-- <td width="13" class="ColorAndAlign">
                                    &nbsp;
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tbl_bordr">
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                            <%--<caption class="ColorAndAlign" style="vertical-align:middle;">
                               &nbsp;&nbsp; Basic Details</caption>--%>
                               <tr>
                               <td style="width:190px;" class="ColorAndAlign"> &nbsp;&nbsp; Basic Details </td>
                               <td style="width:250px;"></td>
                               <td style="width:250px;"></td>
                                <td style="width:250px;"></td>
                               </tr>
                            <tr>
                                <td class="style4" colspan="4">
                                    <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                        <tr class="td-sub_headings">
                                            <td width="8%" valign="bottom">
                                                Group Initials
                                            </td>
                                            <td width="29%" valign="bottom">
                                                Group Name
                                            </td>
                                            <td width="24%" valign="bottom">
                                                Supplier Name
                                            </td>
                                            <td width="9%" valign="bottom">
                                                Supplier Initials.
                                            </td>
                                            <td width="30%" valign="bottom">
                                                Address
                                            </td>
                                        </tr>
                                        <tr >
                                            <td class="inner_tbl_td">
                                                <asp:TextBox ID="txtGroupInit" CssClass="TextColor" Width="70px" MaxLength="3" runat="server"
                                                    onblur="JavaScript:CheckDuplicateGroupInit();"/>
                                                    <input type="hidden" value="0" id="GroupInitEdit" />
                                                <%--<asp:RequiredFieldValidator ID="rfvtxtGroupInit" runat="server" Display="Dynamic" CssClass="TextColor"
                                                    EnableClientScript="true" Width="100" ControlToValidate="txtGroupInit" Font-Size="8"
                                                    ValidationGroup="Submit" ErrorMessage="<br />Enter Group Initials"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:TextBox ID="txtGroupName" CssClass="style-groupname TextColor" Width="95%" MaxLength="40" runat="server"
                                                    onblur="JavaScript:GetGroupInitials();CheckDuplicateGroupName();" />
                                                <asp:RequiredFieldValidator ID="rfvtxtGroupName" runat="server" Display="Dynamic"
                                                    EnableClientScript="true" Width="100" ControlToValidate="txtGroupName" Font-Size="8"
                                                    ValidationGroup="Submit" ErrorMessage="<br />Enter Group Name"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:TextBox ID="txtSupplierName" CssClass="style-suppliername TextColor" Width="95%" MaxLength="50"
                                                    runat="server" onblur="JavaScript:GetSupplierInitials();" />
                                                <asp:RequiredFieldValidator ID="rfvtxtSupplierName" runat="server" Display="Dynamic"
                                                    EnableClientScript="true" Width="100" ControlToValidate="txtSupplierName" Font-Size="8"
                                                    ValidationGroup="Submit" ErrorMessage="<br />Enter Supplier Name"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:TextBox ID="txtSupplierInit" CssClass="TextColor" Width="80px" MaxLength="9" 
                                                    runat="server" />
                                                    
                                                <%--<asp:RequiredFieldValidator ID="rfvtxtSupplierInit" runat="server" Display="Dynamic"
                                                    EnableClientScript="true" Width="100" ControlToValidate="txtSupplierInit" Font-Size="8"
                                                    ValidationGroup="Submit" ErrorMessage="<br />Enter Supplier Initials"></asp:RequiredFieldValidator>--%>

                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:TextBox ID="txtSupplierAddress" CssClass="TextColor" Width="90%" runat="server"  MaxLength="100" onkeyDown="return checkTextAreaMaxLength(this,event,'100');" onpaste="javascript:if(this.value.length+window.clipboardData.getData('Text').length>100){event.returnValue = false;};"  TextMode="MultiLine" />
                                                <asp:RequiredFieldValidator ID="rfvtxtSupplierAddress" runat="server" Display="Dynamic"
                                                    EnableClientScript="true" Width="100" ControlToValidate="txtSupplierAddress"
                                                    Font-Size="8" ValidationGroup="Submit" ErrorMessage="<br />Enter Supplier Address"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lbladdr" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <input id="hdntotal" name="hdntotal" type="hidden" value="1" />
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                           <%-- <caption class="ColorAndAlign"  style="vertical-align:middle;">
                               &nbsp;&nbsp; Contact Details</caption>--%>
                               <tr>
                               <td style="width:190px;" class="ColorAndAlign"> &nbsp;&nbsp; Contact Details </td>
                               <td style="width:250px;"></td>
                               <td style="width:250px;"></td>
                                <td style="width:250px;"></td>
                               </tr>
                            <tr>
                                <td width="80%" colspan="4">
                                    <asp:UpdatePanel ID="up" runat="server">
                                        <ContentTemplate>
                                            <table id="tblInner_1" name="tblInner_1" width="100%" border="0" align="center" cellspacing="6"
                                                cellpadding="0" style="margin: 0px;">
                                                <tr class="td-sub_headings">
                                                    <td width="18%" valign="bottom">
                                                        Contact Person
                                                    </td>
                                                    <td width="18%" valign="bottom">
                                                        Email
                                                    </td>
                                                    <td width="18%" valign="bottom">
                                                        Phone No.
                                                    </td>
                                                    <td width="39%" valign="bottom">
                                                        Remarks
                                                    </td>
                                                    <td width="4%" valign="bottom">
                                                        &nbsp;
                                                    </td>
                                                    <td width="3%" valign="bottom">

                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="trInner_1" name="trInner_1">
                                                    <td class="inner_tbl_td">
                                                        <input id="txtcp_1"  name="txtcp_1" type="text" class="TextColor" maxlength="60" />
                                                      <%--<asp:Label ID="lblContactName" runat="server" ForeColor="Red"></asp:Label>--%>
                                                      
                                                        
                                                    </td>
                                                    <td class="inner_tbl_td">
                                                        <input id="txtemail_1" name="txtemail_1" type="text" class="TextColor" maxlength="50"
                                                            onblur="JavaScript:CheckEmail(this);CheckDuplicateEmail(this);" />
                                                    </td>
                                                    <td class="inner_tbl_td">
                                                        <input id="txtphone_1" name="txtphone_1" type="text" onkeypress="return isNumberKey(event);"  maxlength="17" 
                                                            class="TextColor" />
                                                            
                                                          
                                                    </td>
                                                    <td>
                                                        <textarea id="txtrem_1" name="txtrem_1" class="TextColor" style="width: 99%;" onkeypress="if (this.value.length > 100) { return false; }" onpaste="if (this.value.length > 90) { return false; }"></textarea>
                                                    </td>
                                                    <td align="center">
                                                        <span class="da_remove_btn_dafo" name="spn_1" id="spn_1" style="display: none"><a
                                                            href="#" id="btnDeleteRow1_1" onclick="deleteRow_new(this); return false;">Delete</a></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <span class="da_remove_btn_dafo" id="btnAddRow1_1" onclick="addRow_new(this); return false;">
                                                            <a href="#" onclick="return false;">
                                                                <img src="../../images/plus_icon.gif" border="0" />
                                                                Add</a></span>
                                                                
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="hdnaddtr" runat="server" Value="1" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                            <%--<caption class="ColorAndAlign">
                               &nbsp;&nbsp; Supplier &amp; Fabric Details
                            </caption>--%>
                             <tr>
                               <td style="width:185px;" class="ColorAndAlign">&nbsp;&nbsp; Supplier &amp; Fabric Details</td>
                               <td style="width:250px;"></td>
                               <td style="width:250px;"></td>
                                <td style="width:250px;"></td>
                               </tr>
                            
                            <tr>
                                <td class="style2" colspan="4">
                                    <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                        <tr class="td-sub_headings">
                                            <td valign="bottom">
                                                Supply Type
                                            </td>
                                            <td width="10%" valign="bottom">
                                                Monthly Capacity
                                            </td>
                                            <td width="13%" valign="bottom">
                                                Unit
                                            </td>
                                            <td width="10%" valign="bottom">
                                                Payment Terms
                                            </td>
                                            <td width="3%" valign="bottom">
                                                Grade
                                            </td>
                                            <td colspan="3" valign="bottom">
                                                Supplier Lead Time
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TextColor">
                                                <asp:CheckBoxList ID="cblSupplyType" runat="server" CellPadding="0" CellSpacing="6"
                                                    CssClass="TextColors" DataTextField="PoType" DataValueField="Id" RepeatDirection="Horizontal"
                                                    Height="100%" Width="100%" />
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:TextBox ID="txtMonthlyCapacity" CssClass="TextColor" Width="90px" MaxLength="6"
                                                    runat="server" onkeypress="return isNumberKey(event)" />
                                                <asp:RequiredFieldValidator ID="rfvtxtMonthlyCapacity" runat="server" Display="Dynamic" CssClass="TextColor"
                                                    EnableClientScript="true" Width="100" ControlToValidate="txtMonthlyCapacity"
                                                    Font-Size="8" ValidationGroup="Submit" ErrorMessage="<br />Enter Monthly Capacity"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlUnit" runat="server" CssClass="TextColor" runat="server">
                                                    <asp:ListItem Text="Kgs" Value="Kgs" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Mtr" Value="Mtr"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlPaymentTerm" runat="server" CssClass="TextColor" runat="server" DataTextField="DayName" DataValueField="Day">
                                                  
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlPaymentTerm" runat="server" Display="Dynamic"
                                                    EnableClientScript="true" Width="100" ControlToValidate="ddlPaymentTerm" Font-Size="8"
                                                    ValidationGroup="Submit" ErrorMessage="<br />Payment term not selected" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:Label ID="lblGrade" runat="server" CssClass="TextColor" Text="NA" />
                                            </td>
                                            <td colspan="2" class="inner_tbl_td">
                                                <asp:TextBox ID="txtSltime" CssClass="TextColor" Width="80px" MaxLength="3" runat="server"
                                                    onkeypress="return isNumberKey(event)" />
                                                <asp:RequiredFieldValidator ID="rfvtxtSltime" runat="server" Display="Dynamic" EnableClientScript="true"
                                                    Width="100" ControlToValidate="txtSltime" Font-Size="8" ValidationGroup="Submit"
                                                    ErrorMessage="<br />Enter Supplier Lead Time"></asp:RequiredFieldValidator>
                                                <span class="TextColor">Days</span>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="td-sub_headings" style="margin-left: 10px; padding-top: 5px;" id="divProcess">
                                        Process</div>
                                    <asp:CheckBoxList ID="cblProcess" runat="server" CellPadding="0" TextAlign="Right"
                                        CellSpacing="6" CssClass="TextColor" RepeatColumns="10" DataTextField="ProcessName"
                                        DataValueField="Id" RepeatDirection="Horizontal" Height="100%" Width="100%" OnDataBound="cblProcess_DataBound" />
                                    <div class="td-sub_headings" style="margin-left: 10px; padding-top: 5px;">
                                        Fabric Group Name</div>
                                    <asp:CheckBoxList ID="cblFgN" runat="server" CellPadding="0" TextAlign="Right" CellSpacing="6"
                                        CssClass="TextColor" RepeatColumns="10" DataTextField="FabricGroupName" DataValueField="Id"
                                        RepeatDirection="Horizontal" Height="100%" Width="100%" OnDataBound="cblProcess_DataBound" />
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="errlbl" runat="server" />
                    </td>
                </tr>
                <tr>
                <td align="left">
                <table border="0" cellspacing="4" cellpadding="4">
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" Text="Submit" CssClass="da_submit_button" runat="server"
                                OnClick="btnSubmit_Click" ValidationGroup="Submit" OnClientClick="JavaScript:return CheckValidation();" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" Text="Cancel" CssClass="da_submit_button" runat="server"
                                OnClientClick="return ResetAll();" />
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
            </table>
            <div style="margin-left: 195px;">
                
            </div>
            <asp:HiddenField ID="hf" runat="server" />
            <input type="hidden" value="" id="dupId" />
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%></asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
           <%-- <td class="ColorAndAlign">
                &nbsp;
            </td>--%>
            <td width="1205" class="ColorAndAlign">
                <span class="da_h1">&nbsp;Confirmation</span>
            </td>
           <%-- <td class="ColorAndAlign">
                &nbsp;
            </td>--%>
        </tr>
    </table>
    <div class="form_box">
        <div class="text-content">
            Supplier have been saved into the system successfully!
            <br />
            <a id="A1" href="~/internal/Fabric/SupplierAdminList.aspx" runat="server">Click here</a>
            to Supplier List.</div>
    </div>
</asp:Panel>
