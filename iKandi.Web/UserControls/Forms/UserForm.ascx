<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserForm.ascx.cs" Inherits="iKandi.Web.UserForm" %>
<%--<link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />--%>
<%--<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>--%>
<script type="text/javascript">

    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });

    });
  
</script>
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    var companyDDClientID = '<%=ddlCompany.ClientID %>';
    var managerDDClientID = '<%=ddlManagers.ClientID %>';
    var designationDDClientID = '<%=ddlDesignation.ClientID %>';
    var groupDDClientID = '<%=ddlPrimaryGroup.ClientID %>';
    var additionalDDClientID = '<%=ddlAdditionalGroups.ClientID %>';
    var designerCodeDD = '<%=ddlDesignerCode.ClientID %>';
    var emailDomainLabel = '<%=lblEmailDomain.ClientID %>';
    var emailDomainConfirmationLabel = '<%=lblConfirmationEmailDomain.ClientID %>';
    var phoneCountryClientID = '<%=txtPhoneCountry.ClientID %>';
    var phoneAreaClientID = '<%=txtPhoneArea.ClientID %>';
    var grdsq = '<%=grdattendence.ClientID %>';

    var jscriptPageVariables = null;

    $(function () {

        var UserID = '<%=this.UserID %>';

        if (UserID == -1) {
            $('.minuss').hide();
            $('.pluss').hide();
        }
        $("#" + companyDDClientID, "#main_content").change(function () {

            onCompanyChange();

        });

        $("#" + groupDDClientID, "#main_content").change(function () {

            var selectedValue = this.options[this.selectedIndex].value;

            if (selectedValue == '-1') {
                //                populateDepartments('-1');
                populateDesignations('-1');
                populateManagers('-1');

                return false;
            }

            populateDesignations(selectedValue);

        });

        $("#" + designationDDClientID, "#main_content").change(function () {

            var selectedValue = this.options[this.selectedIndex].value;

            if (selectedValue == '-1') {

                populateManagers('-1');

                return false;
            }


            populateManagers(selectedValue);


            //}, onPageError, false, true);

            //populateManagers(selectedValue); commented abhi

            // TODO - Use the enum
            if (this.options[this.selectedIndex].value == '6' || this.options[this.selectedIndex].value == '5') {
                $("#" + designerCodeDD, "#main_content").show();
            }
            else {
                $("#" + designerCodeDD, "#main_content").hide();
            }


        });

        // Populate fields on load
        if (window.location.search.indexOf("userid=") > -1)
            onCompanyChange();

    });

    function onCompanyChange() {

        //debugger;
        var selectedValue = '<%=this.CompanyID %>';
        if (selectedValue == 0) {
            selectedValue = $("#" + companyDDClientID, "#main_content").val();
        }
        if (selectedValue == '-1') {
            populateDepartments(selectedValue);
            populateDesignations('-1');
            populateManagers('-1');

            return false;
        }

        populateDepartments(selectedValue);


        populateAdditionalDepartments(selectedValue);

        if (parseInt(selectedValue) == 1) // TODO: use enum
        {


            $("#" + emailDomainLabel, "#main_content").text("@ikandi.org.uk");
            $("#" + emailDomainConfirmationLabel, "#main_content").text("@ikandi.org.uk");
            $("#" + phoneCountryClientID, "#main_content").val("44");
            $("#" + phoneAreaClientID, "#main_content").val("207");
        }
        //        if (parseInt(selectedValue) == 3) // TODO: use enum
        //        {
        //            $("#" + emailDomainLabel, "#main_content").text("@ikandi.org.uk");
        //            $("#" + emailDomainConfirmationLabel, "#main_content").text("@ikandi.org.uk");
        //            $("#" + phoneCountryClientID, "#main_content").val("44");
        //            $("#" + phoneAreaClientID, "#main_content").val("207");


        //        }
        if (parseInt(selectedValue) == 2) // TODO: use enum
        {
            $("#" + emailDomainLabel, "#main_content").text("@boutique.in");
            $("#" + emailDomainConfirmationLabel, "#main_content").text("@boutique.in");
            $("#" + phoneCountryClientID, "#main_content").val("91");
            $("#" + phoneAreaClientID, "#main_content").val("120");


        }

    }

    function populateDepartments(companyId) {

        bindDropdown(serviceUrl, groupDDClientID, "GetDepartments", { CompanyID: companyId }, "Name", "DepartmentID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedPrimayGroupID : '', onPageError)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedPrimayGroupID != null && jscriptPageVariables.selectedPrimayGroupID != '') {
            populateDesignations(jscriptPageVariables.selectedPrimayGroupID)
            jscriptPageVariables.selectedPrimayGroupID = '';
        }
    }

    function populateAdditionalDepartments(companyId) {

        bindDropdown(serviceUrl, additionalDDClientID, "GetDepartments", { CompanyID: companyId }, "Name", "DepartmentID", false, (jscriptPageVariables != null) ? jscriptPageVariables.selectedAdditionalGroupID : '', onPageError)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedAdditionalGroupID != null && jscriptPageVariables.selectedAdditionalGroupID != '')
            jscriptPageVariables.selectedAdditionalGroupID = '';
    }

    function populateDesignations(groupId) {

        bindDropdown(serviceUrl, designationDDClientID, "GetDesignations", { DepartmentID: groupId }, "Name", "DesignationID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDesignationID : '', onPageError, onDesignationBind)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedDesignationID != null && jscriptPageVariables.selectedDesignationID != '') {
            populateManagers(jscriptPageVariables.selectedDesignationID)
            jscriptPageVariables.selectedDesignationID = '';
        }
    }


    function onDesignationBind() {
        // TODO - Use the enum
        if ($("#" + designationDDClientID, "#main_content").val() == '6' || $("#" + designationDDClientID).val() == '5') {
            $("#" + designerCodeDD, "#main_content").show();
        }
        else {
            $("#" + designerCodeDD, "#main_content").hide();
        }

        //TODO - User Enum, Enable addtional groups to all Manager
        //        if ($("#" + designationDDClientID, "#main_content").find("option:selected").text() == 'Manager') {
        //            $("#addGrpLabel", "#main_content").show();
        //            $("#addGrpInput", "#main_content").show();
        //        }
        //        else {
        //            $("#addGrpLabel", "#main_content").hide();
        //            $("#addGrpInput", "#main_content").hide();
        //        }
    }

    function populateManagers(designationId) {

        bindDropdown(serviceUrl, managerDDClientID, "GetManagers", { DesignationID: designationId }, "FullName", "UserID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedManagerID : '', onPageError)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedManagerID != null && jscriptPageVariables.selectedManagerID != '')
            jscriptPageVariables.selectedManagerID = '';
    }



    function ValidateEmail(oSrc, args) {
        var result = IsEmailUnique(args.Value);
        args.IsValid = result;
    }

    function IsEmailUnique(email) {
        if (window.location.search.indexOf("userid=") > -1)
            return true;

        var selectedValue = $("#" + companyDDClientID, "#main_content").val();

        if (selectedValue == '-1') return true;

        if (parseInt(selectedValue) == 1) // TODO: use enum abhishek 18/1/2015
        {

            email = email + "@boutique.in";
        }
        if (parseInt(selectedValue) == 2) // TODO: use enum 000 abhishek 18/1/2015
        {
            email = email + "@xny.in";

        }
        if (parseInt(selectedValue) == 3) // TODO: use enum 000 abhishek 18/1/2015
        {
            email = email + "@ikandi.org.uk";

        }


        var isValid = true;

        proxy.invoke("IsUsernameAndEmailUnique", { email: email },
         function (result) {
             isValid = result;
         },
         onPageError, false, true);

        return isValid;
    }

    function onPageError(error) {
        alert(error.Message + ' -- ' + error.detail);
    }


    // Show Create Department Popup
    //    function ShowCreateDepartmentPopUp() {
    //        var compId = $("#" + companyDDClientID, "#main_content").val();
    //        if (compId == "0" || compId == "-1")
    //            return false;
    //        proxy.invoke("ShowDepartmentPopUp", { compId: compId }, function (result) {
    //            jQuery.facebox(result);

    //        }, onPageError, false, false);
    //    }


    // Show Create Designation Popup
    //    function ShowCreateDesignationPopUp() {
    //        var deptId = $("#" + groupDDClientID, "#main_content").val();
    //        if (deptId == "0" || deptId == "-1")
    //            return false;
    //        proxy.invoke("ShowDesignationPopUp", { deptId: deptId }, function (result) {
    //            jQuery.facebox(result);

    //        }, onPageError, false, false);
    //    }

</script>
<script type="text/javascript" src="../../js/facebox.js"></script>
<script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    function ShowGridOnChange() {
        //        debugger;
        //        
        // alert('ddd');<a href="../../Admin/FrmUpdateClientDepAssociation.aspx">../../Admin/FrmUpdateClientDepAssociation.aspx</a>
        //            var sURL = '../../Admin/FrmUpdateClientDepAssociation.aspx';
        //            Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        //            return false;
        var UserID = '<%=this.UserID %>';

        var url = '../../Admin/FrmUpdateClientDepAssociation.aspx?UserID=' + UserID;
        window.open(url, '_blank', 'height=400,width=900,status=yes,toolbar=no,menubar=yes,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');


        //            var url = '../../Admin/FrmUpdateClientDepAssociation.aspx?UserID=' + UserID;
        //            Shadowbox.init({ animate: true, animateFade: true, modal: true });
        //            Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 390, width: 1323, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        //        } else {
        //           
        //        }
    }
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
    function ValidateSeq(elem) {
        if (elem.value == "") {
            alert("Order sequence cannot be empty!");
            elem.value = elem.defaultValue;
            return;
        }
        var valuesseq = elem.value;
        var RowId = 0;
        var gvId;
        var GridRow = $(".gvRow").length;
        for (var row = 1; row <= GridRow; row++) {
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;

            var id = grdsq;
            var ExistsVal = document.getElementById(grdsq + "_" + gvId + "_lblseq").innerHTML;
            if (ExistsVal == valuesseq) {
                alert("Order sequence already exists!");
                elem.value = elem.defaultValue;
            }

        }
    }
    function Showhidegrd(flag) {
        if (flag == 'plus') {
            document.getElementById(grdsq).style.display = 'block';
            $('.pluss').hide();
            $('.minuss').show();
        }
        if (flag == 'minus') {
            document.getElementById(grdsq).style.display = 'none';
            $('.minuss').hide();
            $('.pluss').show();
        }
    }
    //abhishek..
    function ToggleValidator(chk) {
        $("<%=txtCardno.ClientID%>").val("Street");
        debugger;
        var valName = document.getElementById("<%=RequiredFieldValidator12.ClientID%>");
        ValidatorEnable(valName, chk.checked);
        if (chk.checked == false) {

            $("<%=txtCardno.ClientID%>").val("Street");
        }
    }
    function IsValidEmpCardNo(elem) {
        var UserID = '<%=this.UserID %>';
        var empcardno = elem.value.trim();
        //        alert(empcardno);

        var isValid = true;

        proxy.invoke("IsValidEmpCardNo", { userID: UserID, EmpCardNo: empcardno },
         function (result) {
             //             debugger;
             //             alert(result[0].IsValidEmpCardNo)
             if (result[0].IsValidEmpCardNo == 'DUPLICATE') {
                 alert('employe card no. ' + empcardno + ' already exists');
                 elem.value = elem.defaultValue;
             }
         },
         onPageError, false, true);
    }
</script>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .da_submit_button1
    {
        background-image: url("../../images/add-butt.png") !important;
        width: 20px;
        border-bottom-style: none;
        background-repeat: no-repeat;
    }
    select.input_in
    {
        font-size: 13px;
        color: #676767;
        padding: 2px !important;
        border: 1px solid #AAA;
        width: 144px;
    }
    .view-manage
    {
        float: right;
        color: White;
        font-size: 12px;
        font-weight: normal;
        padding-right: 10px;
    }
    .head-back
    {
        background: #39589C !important;
        position: relative;
        font-family: sans-serif;
        text-align: center;
        color: #e7e4fb !important;
        font-size: 15px;
        padding: 4px;
        font-weight: 500 !important;
        margin:0px;
    }
   .AddClass_Table td
    {
        padding:5px 5px;
     }
     td.inner_tbl_td
     {
         background:#fff;
      }  
      .AddClass_Table td[colspan="4"] td
     {
         border:0px;
      }
      .AddClass_Table td[colspan="4"] td >label
      {
          position:relative;
          top:-2px;
       }
       .AddClass_Table td[colspan="4"] td > input[type="checkbox"]
       {
           margin:0px 5px;
        }
        .GlobalCheck input[type="checkbox"]
        {
            margin:0px;
            position:relative;
            top:5px;
         }
</style>
<link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
<asp:Panel runat="server" ID="pnlForm">
    <div style="width: 1200px; margin: 0px auto;">
        <h2 class="head-back">
            <div style="float: left; width: 13%;font-size: 10px;">
                <span class="da_astrx_mand">*</span>(Please fill all
                required fields)
            </div>
             Registration Form - New User
            <asp:HyperLink class="view-manage" ID="hyl1" runat="server" NavigateUrl="~/Admin/ManageDesignation.aspx"
                Target="_blank" ToolTip="Go to manage divison admin">View  manage divison</asp:HyperLink>
            <div style="clear: both">
            </div>
           </h2>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:HyperLink ID="hylp" runat="server" Text="Active/Deactivate" Style="color: Blue;
                            cursor: pointer;" ToolTip="set active deactivate" onclick="javascript:ShowGridOnChange();"></asp:HyperLink>
                        <!--table-1-->
                        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
                        <%--<asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                        <table align="center" border="0" class="AddClass_Table" cellpadding="0" cellspacing="0" style="margin: 0px;
                            height: 70px;" width="1200px">
                            <tr class="td-sub_headings">
                                <td style="width: 25%">
                                    <span>Choose Division<span class="da_astrx_mand">*</span>  </span>
                                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="input_in">
                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="IKANDI" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="BIPL" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="form_error da_error_msg">
                                        <asp:RequiredFieldValidator ID="rfv_ddlCompany" runat="server" ControlToValidate="ddlCompany"
                                            Display="Dynamic" ErrorMessage="Select your company" InitialValue="-1"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td style="width: 25%">
                                    <span>Pr. Group (Dept.)<span class="da_astrx_mand">*</span> </span>
                                    <asp:DropDownList ID="ddlPrimaryGroup" runat="server" AppendDataBoundItems="true"
                                        CssClass="input_in" Width="144px">
                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <div class="form_error da_error_msg">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlPrimaryGroup"
                                            Display="Dynamic" ErrorMessage="Select your primary group" InitialValue="-1"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td style="width: 25%" valign="middle">
                                    <span>Designation<span class="da_astrx_mand">*</span> </span>&nbsp; &nbsp;
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="input_in" Width="144px">
                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:ListBox ID="ddlDesignerCode" runat="server" SelectionMode="Multiple" Style="vertical-align: middle;">
                                    </asp:ListBox>
                                    &nbsp;
                                    <div class="form_error da_error_msg">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDesignation"
                                            Display="Dynamic" ErrorMessage="Designation is required" InitialValue="-1"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td style="width: 25%;border-right-color: #999 !important;">
                                    <span>line Manager<span class="da_astrx_mand"></span></span>&nbsp; &nbsp;
                                    <asp:DropDownList ID="ddlManagers" runat="server" AppendDataBoundItems="true" CssClass="input_in"
                                        Width="145">
                                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hfprevManagerId" runat="server" Value="0" />
                                    <div class="form_error da_error_msg">
                                        <asp:RequiredFieldValidator ID="rfv_ddlManagers" runat="server" ControlToValidate="ddlManagers"
                                            Display="Dynamic" Enabled="false" ErrorMessage="Select your manager" InitialValue="-1"
                                            Visible="false"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td style="visibility: collapse"  class="hide_me">
                                    <span id="addGrpLabel" class="hide_me">Additional Groups </span><span id="addGrpInput"
                                        class="hide_me">
                                        <asp:ListBox ID="ddlAdditionalGroups" runat="server" CssClass="input_in" Rows="2"
                                            SelectionMode="Multiple" Width="145"></asp:ListBox>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div style="float: left; width: 100px; padding-top: 7px;">
                                        <b style="color: black;">Weekly Off<span style="color: Red">*</span></b></div>
                                    <div style="float: left;">
                                        <asp:CheckBoxList ID="chkhoilday" RepeatDirection="Horizontal" runat="server">
                                            <asp:ListItem Value="1" Text="Sunday" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Monday"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Tuesday"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Wednesday"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Thursday"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Friday"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Saturday"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                        <!--table-1 end-->
                        <!--table-2-->
                        <h2 class="head-back" style="margin-top:5px;">
                            Registration
                        </h2>
                        <table border="0" cellpadding="0" class="AddClass_Table" cellspacing="0" style="border: 1px solid #f3f3f3;"
                            width="100%">
                            <tbody>
                                <tr>
                                    <td class="td-sub_headings" width="10%">
                                        First Name<span class="da_astrx_mand">*</span>:
                                    </td>
                                    <td class="inner_tbl_td" width="18%">
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="input_in" MaxLength="42" />
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                                                Display="Dynamic" ErrorMessage="First name is required"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td class="td-sub_headings" width="14%">
                                        Last Name<span class="da_astrx_mand">*</span>:
                                    </td>
                                    <td class="inner_tbl_td" width="23%">
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="input_in" MaxLength="42" />
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                                                Display="Dynamic" ErrorMessage="Last name is required"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td class="td-sub_headings" width="14%">
                                        Office Phone No.
                                    </td>
                                    <td class="inner_tbl_td" width="21%">
                                        <asp:TextBox ID="txtPhoneCountry" runat="server" MaxLength="2" onkeypress="return isNumberKey(event)"
                                            size="2" />
                                        -<asp:TextBox ID="txtPhoneArea" runat="server" MaxLength="6" onkeypress="return isNumberKey(event)"
                                            size="4" />
                                        -<asp:TextBox ID="txtPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                            size="7" />
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                        ControlToValidate="txtPhoneCountry" ErrorMessage="Enter Country code"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                        ControlToValidate="txtPhoneArea" ErrorMessage="Enter area code"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                        ControlToValidate="txtPhone" ErrorMessage="Enter valid phone number"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-sub_headings">
                                        E-mail<span class="da_astrx_mand">* </span>
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input_in" MaxLength="25" size="8" />
                                        <asp:Label ID="lblEmailDomain" runat="server"></asp:Label>
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                                Display="Dynamic" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="custom_validate_email" runat="server" ClientValidationFunction="ValidateEmail"
                                                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email already exists in the system">
                                            </asp:CustomValidator>
                                        </div>
                                    </td>
                                    <td class="td-sub_headings">
                                        Confirm E-mail<span class="da_astrx_mand">* </span>
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="input_in" MaxLength="25"
                                            size="8" />
                                        <asp:Label ID="lblConfirmationEmailDomain" runat="server"></asp:Label>
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmEmail"
                                                Display="Dynamic" ErrorMessage="Confirm email is required"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="RequiredFieldValidator41" runat="server" ControlToCompare="txtEmail"
                                                ControlToValidate="txtConfirmEmail" Display="Dynamic" ErrorMessage="Confirmation email does not match with Email"></asp:CompareValidator>
                                        </div>
                                    </td>
                                    <td class="td-sub_headings">
                                        Global Access
                                       
                                        <%-- Deactivate  User--%>
                                    </td>
                                    <td class="inner_tbl_td GlobalCheck">
                                        <asp:CheckBox ID="chkGlobal" runat="server" /><br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-sub_headings" width="12%">
                                        Address
                                        <%--<span class="da_astrx_mand">*</span>:--%>
                                    </td>
                                    <td class="inner_tbl_td" width="16%">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="input_in" MaxLength="190" />
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                                        ControlToValidate="txtAddress" ErrorMessage="Enter address"></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td class="td-sub_headings" width="14%">
                                        Personal Email
                                    </td>
                                    <td class="inner_tbl_td" valign="middle" width="23%">
                                        <asp:TextBox ID="txtPersonalEmail" runat="server" CssClass="input_in" MaxLength="25" />
                                        <div class="da_error_msg">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPersonalEmail"
                                                Display="Dynamic" ErrorMessage="Please enter a valid email address" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </div>
                                    </td>
                                    <td class="td-sub_headings" width="14%">
                                        Birth Date
                                    </td>
                                    <td class="inner_tbl_td" width="21%">
                                        <asp:TextBox ID="txtBirthday" runat="server" CssClass="th"> </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-sub_headings">
                                        Anniversery
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:TextBox ID="txtAnniversary" runat="server" CssClass="th"></asp:TextBox>
                                    </td>
                                    <td class="td-sub_headings">
                                        Mobile No.
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="input_in" MaxLength="10" onkeypress="return isNumberKey(event)" />
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" Display="Dynamic"
                                        ControlToValidate="txtMobile" ErrorMessage="Enter mobile no."></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator88" runat="server"
                                            ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Enter valid mobile no"
                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td rowspan="2" style="background: #f2f2f2; border: 1px solid #ccc; color: #ccc;
                                        text-align: center;">
                                        <div style="height: auto; width: auto;">
                                            <asp:Image ID="imgPhoto" runat="server" Visible="false" Width="40" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-sub_headings">
                                        Home Phone No.
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:TextBox ID="txtPersonalPhoneCountry" runat="server" MaxLength="2" onkeypress="return isNumberKey(event)"
                                            size="2" />
                                        -<asp:TextBox ID="txtPersonalPhoneArea" runat="server" MaxLength="6" onkeypress="return isNumberKey(event)"
                                            size="4" />
                                        -<asp:TextBox ID="txtPersonalPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                            size="7" />
                                    </td>
                                    <td class="td-sub_headings">
                                        Upload Photo
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:FileUpload ID="filePhoto" runat="server" CssClass="input_in" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-sub_headings">
                                        <b style="color: black;">Emp.Card No.<span style="color: Red">*</span></b>
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCardno"
                                            Display="Dynamic" ErrorMessage="Enter card no."></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator Display ="Dynamic" ControlToValidate = "txtCardno" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{5,5}$" runat="server" ErrorMessage="Enter valid card no."></asp:RegularExpressionValidator>--%>
                                        <asp:TextBox ID="txtCardno" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                            onchange="IsValidEmpCardNo(this);" runat="server" oncopy="return false" onpaste="return false"
                                            oncut="return false" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td class="td-sub_headings">
                                        Upload Signature
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:FileUpload ID="fileSig" runat="server" CssClass="input_in" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td style=" border: 1px solid #ccc; color: #ccc; text-align: center;">
                                        <div style="height: auto; width: auto;">
                                            <asp:Image ID="imgSignature" runat="server" Visible="false" Width="100" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-sub_headings">
                                        Is Staff
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:CheckBox ID="chkisstaff" onclick="ToggleValidator(this);" runat="server" />
                                    </td>
                                    <td class="td-sub_headings">
                                        In Time
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:DropDownList ID="ddlhh" runat="server">
                                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                            <asp:ListItem Text="09" Selected="True" Value="09"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlmm" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="td-sub_headings">
                                        Sequence
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtordersqe"
                                            Display="Dynamic" ErrorMessage="Enter sequence"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtordersqe" onchange="ValidateSeq(this);" onkeypress="return isNumberKey(event)"
                                            MaxLength="3" runat="server"></asp:TextBox>&nbsp;&nbsp;<a href="#" class="pluss"
                                                title="Show all sequence" onclick="Showhidegrd('plus')"><img src="../../App_Themes/ikandi/images/plus_icon.gif"
                                                    border="0" /></a> <a href="#" class="minuss" title="Hide all sequence" onclick="Showhidegrd('minus')"
                                                        style="display: none">
                                                        <img src="../../App_Themes/ikandi/images/minus_icon.gif" border="0" /></a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:GridView ID="grdattendence" Style="display: none;" runat="server" AutoGenerateColumns="false"
                            RowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True" RowStyle-CssClass="GvGrid"
                            CellPadding="1" Width="200px" EmptyDataText="" RowStyle-ForeColor="#7E7E7E" CssClass="item_list2"
                            HorizontalAlign="Center">
                            <RowStyle CssClass="gvRow" />
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="middle">
                                    <HeaderTemplate>
                                        Name
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnuserid" runat="server" Value='<%#Eval("UserID") %>' />
                                        <asp:Label ID="lblusername" Style="text-transform: capitalize" CssClass="gray rotate"
                                            Text='<%#Eval("name") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" BackColor="#fff6fa" Font-Bold="true" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>
                                        Sequence
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblseq" CssClass="gray" Text='<%#Eval("OrderSeq") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" BackColor="#fff6fa" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <!--table-2 end-->
                        <!--table-3-->
                        <%--<caption class="caption_headings">Allocation</caption>--%>
                        <!--table-3 end-->
                        <!--table-4-->
                        <!--table-4 end-->
                    </td>
                </tr>
            </table>
           
            <%-- <asp:Panel id="divuser" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
            <%--Is Active <asp:CheckBox ID="ChkDeactivate" class="chkisac" onchange="javascript:ShowGridOnChange();" runat="server"/>--%>
            <div class="form_buttom" style="margin-top:5px;">
                <asp:Button ID="btnSubmit" runat="server" class="da_submit_button submit" OnClick="Submit_Click"
                    Text="Submit" />
                <input type="button" id="btnPrint" value="Print" class="da_submit_button" onclick="return PrintPDF();" />
            </div>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
            <h2>
            </h2>
        </h2>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="10" class="da_table_heading_bg_left">
                &nbsp;
            </td>
            <td width="1205" class="da_table_heading_bg">
                <span class="da_h1">Registration Confirmation </span>
            </td>
            <td width="13" class="da_table_heading_bg_right">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="form_box">
        <div class="text-content">
            User have been saved into the system successfully!
            <br />
            <a id="A1" href="~/internal/users/UserListing.aspx" runat="server">Click here</a>
            to Users List.</div>
        <div>
</asp:Panel>
