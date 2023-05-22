


$(document).ready(function () {


    // $(".Update").addClass('noneShow');


    //    $(".basicsearch").focusin(function () {
    //        $("#" + btngo).focus();
    //    });


    $(".Reset").hide();

    if ($("#" + hdnAlert).val() != "") {
       // alert('1' + '--' + $("#" + hdnDepId).val());

        $(".Blank").hide();
        $(".Update").show();
        $(".Reset").hide();

        if ($("#" + hdnDepId).val() == "0") {
            $(".Update").hide();
            $("#" + btnSubmit).show();
            $(".Reset").hide();
        }

    }

    if ($("#" + txtName_19).val() == "") {
       // alert('2')
        $(".Update").hide();
        $("#" + btnSubmit).show();
        $(".Reset").hide();
    }

    $(".Cancel").click(function () {
        //  
        $(".Blank").show();
        $("#" + btnUpdate).hide();
        $("#" + hdnDepName).val("");
        $("#" + hdnDes).val("");
        $("#" + hdnEntityId).val("Not found");
        $("#" + hdnDepId).val("0");
        $("#" + txtName_19).val("");
        $("#" + txtDescription_99).val("");
        $("#" + hdnIsActive).val("");
        SetDropDownList(ddlEntityName, "--Select--");

        $("#" + chkIsActive).removeAttr('checked');
        $(".Reset").hide();
        $(".Update").hide();
        location.reload();
        return false;
        //return navigator.appName == "Netscape" ? true : false;

    });
    $(".Reset").click(function () {

        $("#" + txtName_19).val($("#" + hdnDepName).val()); $("#" + txtDescription_99).val($("#" + hdnDes).val());
        $("#" + ddlEntityName + " option:contains(" + $("#" + hdnEntityId).val() + ")").attr('selected', 'selected');
        $("#" + hdnIsActive).val() == "True" ? $("#" + chkIsActive).attr('checked', 'checked') : $("#" + chkIsActive).removeAttr('checked');
        return false;
    });

    $(".lnkEdit").click(function () {
        $(".Blank").hide();
        $(".Update").show();
        $(".Reset").show();
        $("#" + hdnDepName).val($(this).closest("tr").find("[class^='lblcls ']").html());
        $("#" + hdnDes).val($(this).closest("tr").find("[class^='lblClsDes ']").text());

        $("#" + hdnEntityId).val($(this).closest("tr").find("[class^='lblClsEntity ']").html());
        $("#" + hdnDepId).val($(this).closest("tr").find("[name$='hdnDepId']").val());
        $("#" + txtName_19).val($(this).closest("tr").find("[class^='lblcls ']").html());
        $("#" + txtDescription_99).val($(this).closest("tr").find("[class^='lblClsDes ']").text());
        $("#" + hdnIsActive).val($(this).closest("tr").find("[class^='IsActive ']").html());
        $(this).closest("tr").find("[class^='IsActive ']").html() == "Yes" ? $("#" + chkIsActive).attr('checked', 'checked') : $("#" + chkIsActive).removeAttr('checked');
        $("#" + ddlEntityName + " option:contains(" + $(this).closest("tr").find("[class^='lblClsEntity ']").html() + ")").attr('selected', 'selected');
        return false;
    });



    $(".Blank").click(function () {
        if (!Blank(txtName_19, lblDepName))
            return false;
        if (!BlankDDL(ddlEntityName, lblEntityName))
            return false;
        if (!$("#" + chkIsActive).is(':checked'))
            if (!confirm('Do you want to continue with this registration is in DeActive Mode.'))
                return false;
        // $("#" + btnSubmit).removeClass('noneShow');
        return true;
    });
    $(".suppliertoggle").click(function () {
        if ($("#supplier").text() == "(+)") {
            $("#supplier").html("(-)");
            $("#" + hdnIsPostBack).val("1");
            $(".entityliststyle6").removeClass('noneShow');
        }
        else {
            $(".suppliertoggle").html("(+)");
            $(".entityliststyle6").addClass('noneShow');
            SetDropDownList(ddlEntityNameAdv, '--Select--');
            //UncheckBox(chkIsActiveAdv);
            //UncheckBox(chkInActiveAdv);
        }
    });
    if ($("#" + hdnIsPostBack).val() == "0") {
        $("#supplier").text("(+)");
        $(".entityliststyle6").addClass('noneShow');
    }
    else
        $("#supplier").text("(-)");



});

