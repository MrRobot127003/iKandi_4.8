
$(document).ready(function () {

    $("#" + ddlCompany).change(function () {
        $("#" + hdnCompany).val($(this).val()); return false;
    });

    $("#" + ddlDesignation).change(function () {
        $("#" + hdnDesignation).val($(this).val()); return false;
    });

    $(".Cancel").click(function () {
        SetDropDownList(ddlEntityName, "--Select--");
        SetDropDownList(ddlCompany, "--Select--");
        SetDropDownList(ddlDepartment, "--Select--");
        SetDropDownList(ddlDesignation, "--Select--");
        $("#" + hdnUserId).val("0");
        $("#" + txtPersonal).val("");
        $("#" + txtBday).val("");
        $("#" + txtAnniversary).val("");
        $("#" + txtHomePhone).val("");
        $("#" + txtMobile).val("");
        $("#" + txtFirstName_19).val("");
        $("#" + txtLastName_19).val("");
        $("#" + txtEmail).val("");
        $("#" + txtOfficePhone).val("");
        $("#" + txtAddress).val("");
        UncheckBox(chkIsGlobel);
        UncheckBox(chkIsActive);
        $(".Reset").hide();
        $(".Update").hide();
        $(".Submit").show();
        location.reload();
    });
    $("#" + chkIsActiveAdv).change(function () { $("#" + chkInActiveAdv).removeAttr('checked'); });
    $("#" + chkInActiveAdv).change(function () { $("#" + chkIsActiveAdv).removeAttr('checked'); });
    $(".Blank").click(function () {
        if (!BlankDDL(ddlEntityName, lblEntityName))
            return false;
        if (!BlankDDL(ddlCompany, lblCompany))
            return false;
        if (!Blank(txtFirstName_19, lblFirstName))
            return false;
        if (!CharValid(txtFirstName_19, lblFirstName))
            return false;
        if (!Blank(txtLastName_19, lblLastName))
            return false;
        if (!CharValid(txtLastName_19, lblLastName))
            return false;
        if (!Blank(txtEmail, lblEmail))
            return false;
        if (!Email(txtEmail, lblEmail))
            return false;
        if (!BDayDate(txtBday, lblBirthday))
            return false;
        if (!AnniDate(txtBday, txtAnniversary, lblanniver))
            return false;
        if (!BlankDDL(ddlDepartment, lbldepartment))
            return false;
        if (!BlankDDL(ddlDesignation, lbldesignation))
            return false;
        if (!$("#" + chkIsActive).is(':checked'))
            if (!confirm('Do you want to continue with this registration is in InActive Mode.'))
                return false;
        if ($("#" + txtPersonal).val() != "")
            if (!Email(txtPersonal, lblpersnemal))
                return false;
        return true;
    });

});


