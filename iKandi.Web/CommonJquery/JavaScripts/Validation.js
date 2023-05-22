// created By  Yatendra
// On 3rd April 2013

//var serviceUrl = '/Webservices/IKandi_New.asmx/';
//var proxy = new ServiceProxy(serviceUrl);


$(document).ready(function () {

    $(".MaxLength").bind("cut copy paste", function (e) { e.preventDefault(); });
    $(".MaxLength").keypress(function () {
        var pieces = $(this).attr('id').split(/[\s_]+/);
        if ($(this).val().length > pieces[pieces.length - 1]) return false;
    });
    function TextboxBlank(controlId, alertMsg) {

    }
   
});
$(document).ready(function () {
    $(".NoHTML").keypress(function (e) {
        var evt = e || window.event;
        var keyPressed = evt.which == 0 ? e.keyCode : evt.which;
        if (keyPressed == 60 || keyPressed == 62) return false;
    });
    $(".MaxLengthOnlyAlphabet").bind("cut copy paste", function (e) { e.preventDefault(); });



    $(".MaxLengthOnlyAlphabet").keypress(function (e) {
        //debugger;
        var evt = e || window.event;
        var keyPressed = evt.which == 0 ? e.keyCode : evt.which;  // .keyCode

        var pieces = $(this).attr('id').split(/[\s_]+/);
        if (keyPressed == 8 || keyPressed == 46 || keyPressed == 39 || keyPressed == 40) return true;
        if ((keyPressed < 65 || keyPressed > 90) && (keyPressed < 97 || keyPressed > 123) && keyPressed != 32) return false;
        if ($(this).val().length > pieces[pieces.length - 1]) return false;

    });




    $(".OnlyNumeric").keypress(function () {
        var charCode = (window.event.which) ? window.event.which : window.event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    });



});


// 
function UncheckBox(chk) {
    $("#" + chk).removeAttr('checked');
}


function SetDropDownList(DDL, Option) {
      $("#" + DDL + " option:contains(" + Option + ")").attr('selected', 'selected');
    // $("#" + DDL + " option[value='-1']").attr('selected', 'selected');
 //  $("#mcatid option[value="2"]").attr('selected', 'selected');
  // $("#" + DDL)[0][0].selected = true;
}

function Blank(TextBox, Label) {
    return $.trim($("#" + TextBox).val()) == "" ? alert($("#" + Label).html() + ' is Mandatory.') : true;
}

function BlankDDL(DDL, Label) {    
    return $("#" + DDL).find('option:selected').val() == "-1" ? alert($("#" + Label).html() + ' is Mandatory.') : true;
}

function Email(TextBox, Label) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; 
    return re.test($("#" + TextBox).val())!=true ? alert($("#" + Label).html() + ' is not valid.') :  true;   
}

function BDayDate(TextBox, Label) {
   
    var Curyy =parseInt(new Date().getFullYear());
    var Curmm =parseInt(new Date().getMonth());
    var Curdd = parseInt(new Date().getDate());    
    var Textyy =parseInt(new Date($("#" + TextBox).val()).getFullYear());
    var Textmm =parseInt(new Date($("#" + TextBox).val()).getMonth());
    var Textdd = parseInt(new Date($("#" + TextBox).val()).getDate());
    if ((Curyy - Textyy) > 99) {        
        alert('Input Correct ' + $("#" + Label).html());//  alert('U r too old');
        return false;
    }

    if ((Curyy - Textyy) < 0) {        
        alert('Input Correct ' + $("#" + Label).html());//     alert('U r select feture year');
        return false;
    }
    if ((Curyy - Textyy) == 0 && (Curmm - Textmm) < 0) {
        
        alert('Input Correct ' + $("#" + Label).html());// alert('U r select feture month');
        return false;
    }
    if ((Curyy - Textyy) == 0 && (Curmm - Textmm) == 0 && (Curdd - Textdd) <= 0) {        
        alert('Input Correct ' + $("#" + Label).html()); //  alert('U r select feture date');
        return false;
    }
    return true;
}

function AnniDate(TextBoxbday, TextBoxAnni, Label) {
   
    var Bdayyy = parseInt(new Date($("#" + TextBoxbday).val()).getFullYear());
    var Bdaymm = parseInt(new Date($("#" + TextBoxbday).val()).getMonth());
    var Bdaydd = parseInt(new Date($("#" + TextBoxbday).val()).getDate());
    var Anniyy = parseInt(new Date($("#" + TextBoxAnni).val()).getFullYear());
    var Annimm = parseInt(new Date($("#" + TextBoxAnni).val()).getMonth());
    var Annidd = parseInt(new Date($("#" + TextBoxAnni).val()).getDate());
    if ((Bdayyy - Anniyy) > 0) {
        alert('Input Correct 1 ' + $("#" + Label).html()); //alert('anniverary shold before bady year');
        return false;
    }
    if ((Bdaymm - Annimm) > 0 && (Bdayyy - Anniyy) > 0) {
        alert('Input Correct 2 ' + $("#" + Label).html());  //alert('anniverary shold before bady month');
        return false;
    }
    if ((Bdaydd - Annidd) >= 0 && (Bdayyy - Anniyy) > 0 && (Bdaymm - Annimm) > 0) {
        alert('Input Correct 3 ' + $("#" + Label).html()); //  alert('anniverary shold before bady day');
        return false;
    }
    return true; 
}


function ShowAlertMsg(msg) {
    //debugger;
    alert(msg);
    return false;
}


//Description :This function for restrict alpha character,only for numeric code
//Input :e event
//obj:control object
//intsize: before point numeric value length
//deczize after point numeric value length

function check_digit(e, obj, intsize, deczize) {

    
   // debugger;
    var keycode;

    if (window.event) keycode = window.event.keyCode;

    else if (e) keycode = e.which;

    else return true;

    var fieldval = (obj.value);

    var dots = fieldval.split(".").length;

    if (keycode == 46) {

        if (dots > 1) {

            return false;

        }
        else {

            return true;

        }

    }

    if (keycode == 8 || keycode == 9 || keycode == 46 || keycode == 13) // back space, tab, delete, enter
    {

        return true;

    }

    if ((keycode >= 32 && keycode <= 45) || keycode == 47 || (keycode >= 58 && keycode <= 127)) {

        return false;

    }

    if (fieldval == "0" && keycode == 48)

        return false;

    if (fieldval.indexOf(".") != -1) {

        if (keycode == 46)

            return false;

        var splitfield = fieldval.split(".");
       

        if (splitfield[1].length > deczize && keycode != 8 && keycode != 0)

            return false;

        //debugger;

        //if (splitfield[1].length >= deczize )

        // return false;

    }

    else if (fieldval.length >= intsize && keycode != 46) {

        return false;

    }

    else return true;

}
//Description :This function for Trim Value
function trim(str) {
    while (str.substring(0, 1) == ' ') {
        str = str.substring(1, str.length);
    }
    while (str.substring(str.length - 1, str.length) == ' ') {
        str = str.substring(0, str.length - 1);
    }
    return str;

} 

//Description :This function for Compare two date
//Input :obj1 First control date
//obj:obj2 second control date

function fncComparedate (obj1, obj2) {
    
    if (obj2 == '') 
    {
        var Curyy = parseInt(new Date().getFullYear());
        var Curmm = parseInt(new Date().getMonth() + 1);
        var Curdd = parseInt(new Date().getDate());
        var Textyy = parseInt(new Date($("#" + obj1).val()).getFullYear());
        var Textdd = parseInt(new Date($("#" + obj1).val()).getMonth() + 1);
        var Textmm = parseInt(new Date($("#" + obj1).val()).getDate());
        if ((Curyy - Textyy) == 0 && (Curmm - Textmm) == 0 && (Curdd - Textdd) >= 0) 
        {
            alert("Input Correct Date"); //  alert('U r select feture date');
            return false;
        }
    }
     if(obj2 != '') {
         var today = new Date();
         var mm = today.getDate();
         var dd = today.getMonth() + 1; //January is 0!

         var yyyy = today.getFullYear();
         if (dd < 10) {
             dd = '0' + dd
         }
         if (mm < 10) {
             mm = '0' + mm
         }
         var today = mm + '/' + dd + '/' + yyyy;
         if (new Date(today) >= new Date(obj2)) {
        alert("Effective Date can'nt less then the current date"); //  alert('U r select feture date');
        return false;
    }
     }

   
    return true;
}
//Description :This function for restict Dot value and Alpha charcter value
//Input :obj1 First control date
//obj:obj2 second control date
function OnlyNumericEntry() {
    //debugger;
    if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue =
false;
    }
}

//Author : Surendra
//Description : Show AlertMsg on client side 
function ShowAlertMsg(msg) {
    //debugger;
    alert(msg);
    return false;
}

//Author : Ashish 
//Description : Show Message According to control
function AlertMsg(id, elem, msg) {
    if (id == 'txt') {
        if (trim(elem) == "") {
            alert(msg);
            return false;
        }
    }
    if (id == 2) {
        if (elem != "") {
            if (elem < 2) {
                alert(msg);
                return false;
            }
        }
    }
    if (id == 3) {
        if (elem != "") {
            if (elem < 3) {
                alert(msg);
                return false;
            }
        }
    }
    if (id == 'ddl') {
        if (elem == "-1" || elem == "0") {
            alert(msg);
            return false;
        }
    }

}

function sushil_AlertMsg(id, elem, msg) {
   
    if (id == 'txt') {
        if (elem == "") {
            alert(msg);
            return false;
        }
    }
  
    if (id == 'ddl') {
        if (elem == "-1") {
            alert(msg);
            return false;
        }
    }
    return true;
}


//Author : Ashish 
//Description : Find Sub String  ShowCode
function ShowSubstring(elem, id) {
    //debugger;
    var code = elem.substring(0, id);
    var FCode = code
    return FCode;
}


//Author : Ashish 
//Description : Validate Email
function ValidEmailId(Email, msg) {
  
    var mailformat = /^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$/;
    var undefined;
    if (Email == "" || Email == undefined) {
        return true;
    }
    else {
        if (Email.match(mailformat)) {
            return true;
        }
        else {
            alert(msg);
            return false;
        }
    }
}

//function ValidEmail(Email, msg) {
//    // debugger;
//    var mailformat = /^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$/;

//    if (Email.match(mailformat)) {
//        return true;
//    }
//    else {
//        alert(msg);
//        return false;
//    }
//}

function CheckEmail(Email,msg) {
    //debugger;
    var mailformat = /^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$/;
    if (Email.value != "") {
        if (Email.value.match(mailformat)) {
            return true;
        }
        else {
            alert(msg);
            return false;
        }
    }
}








function checkfloat(e, field) {
    if (!(((e.keyCode >= 48) && (e.keyCode <= 57)) || (e.keyCode == 46))) {
        alert("Only Digits Are Allowed!");
        e.keyCode = 0;
    }
    if (e.keyCode == 46) {
        var patt1 = new RegExp("\\.");
        var ch = patt1.exec(field);
        if (ch == ".") {
            alert("More then one decimal point not allowed");
            e.keyCode = 0;
        }
    }
}

//Author : Ashish 
//Description :Check Only Numeric Characters Allowed.

function checkIsNum(Num) {
    //debugger;
    var No = Num.value;
    if (No == "") {
        return true;
    }
    if (isNaN(No)) {
        alert('Only Numeric Characters Allowed.');
        Num.focus();
        return false;
    }
}

function floatValidation(e, control) {
    //debugger;
    if (e.keyCode == 46) {
        var patt1 = new RegExp("\\.");
        var ch = patt1.exec(control.value);
        if (ch == ".") {
            e.keyCode = 0;
        }
    }
    else if ((e.keyCode >= 48 && e.keyCode <= 57) || e.keyCode == 8)//Numbers or BackSpace
    {
        if (control.value.indexOf('.') != -1)//. Exisist in TextBox 
        {
            var pointIndex = control.value.indexOf('.');
            var beforePoint = control.value.substring(0, pointIndex);
            var afterPoint = control.value.substring(pointIndex + 1);
            var iCaretPos = 0;
            if (document.selection) {
                if (control.type == 'text') // textbox
                {
                    var selectionRange = document.selection.createRange();
                    selectionRange.moveStart('character', -control.value.length);
                    iCaretPos = selectionRange.text.length;
                }
            }
            if (iCaretPos > pointIndex && afterPoint.length >= 2) {
                e.keyCode = 0;
            }
            else if (iCaretPos <= pointIndex && beforePoint.length >= 3) {
                e.keyCode = 0;
            }
        }
        else//. Not Exisist in TextBox
        {
            if (control.value.length >= 3) {
                e.keyCode = 0;
            }
        }
    }
    else {
        e.keyCode = 0;
    }
}

function setCaretPosition(ctrl, pos) {
    if (ctrl.setSelectionRange) {
        ctrl.focus();
        ctrl.setSelectionRange(pos, pos);
    }
    else if (ctrl.createTextRange) {
        var range = ctrl.createTextRange();
        range.collapse(true);
        range.moveEnd('character', pos);
        range.moveStart('character', pos);
        range.select();
    }
}

//Author : Ashish 
//Description : Confirm Massage According to Control And Massage
function confirmMsg(Name, ctrl, Msg) {
    //debugger; 
    //IsMode
    if (ctrl = 'chk') {
        if (!$(Name).is(':checked')) {
            if (!confirm(Msg))
                return false;

            return true;
        }
    }
}

//Author : Ashish 
//Description : Define Max Length for Text Box

function Maxlenght(e, obj) {
    var fieldval = (obj.value);
    if (fieldval.length > e)
        return false;
    else
        return true;
}

//Author : Ashish 
//Description : Validate Numeric Copy Paste

function PreventCharPast(elem) {
    //debugger;
    var value = elem.value;
    if (value == undefined) {
        var regs = /^\d*[0-9](\.\d*[0-9])?$/;
        if (value != "") {
            if (regs.exec(elem)) {
                return true;
            }
            else {
                alert('Enter Only Numeric Value')
                elem.value = "";
                return false;

            }
        }
    }
    else {
        //var regs = /^\d*[0-9](\.\d*[0-9])?$/;
        var regs = /^(-)?\d+(\.\d\d)?$/;
        if (value != "") {
            if (regs.exec(value)) {
                return true;
            }
            else {
                alert('Enter Only Numeric Value')
                elem.value = "";
                return false;

            }
        }
    }
      
}

//Author : Ashish 
//Description : Validate Character Copy Paste

function PreventNumericPast(elem) {
    //debugger;
    var value = elem.value;
    var regs = /^[A-Za-z]+$/;
    if (value != "") {
        if (regs.exec(value)) {
            return true;
        }
        else {
            alert('Enter Only Character Value')
            elem.value = "";
            return false;

        }
    }
}

//Author :Santosh Kumar Singh
//Description :  Validation Character Only.

function CharValid(TextBox,lblMsg) {
    var Text = $.trim($("#" + TextBox).val())
    var re = /^[A-Za-z]+$/;
    if (Text != "") {
        if (!re.test(Text)) {
            alert($("#" + lblMsg).html() +" "+ "Enter Only Character Value");
        }
        else {
            return true;
        }
    }


}

// add sushil  
function CloneDiv_Cat(id, name, hValues, clonediv, tdlist) {
    //debugger;

    var ctrl = $(clonediv).clone();
    ctrl.attr("id", "divanc" + id);
    //ctrl.find("a").attr("onclick", "JavaScript:RemoveSupplier(this.id,"+id+");return false;");
    ctrl.find("a").attr("id", "anc_" + id);
    ctrl.find("img").attr("id", "ancimg" + id);
    ctrl.find("label").html(name);
    ctrl.css("display", "");
    ctrl.find("a").click(function () {
        //debugger;
        var id = $(this).attr("id").split("_")[1];
        var suppliervalues = $("#" + hValues).val();
        var supplierids = suppliervalues.split(",");
        var index = jQuery.inArray(id, supplierids);

        var Cat_Id = $("#" + CatId);

        var catID_val = Cat_Id.val();
        var check_remove = '0';
        //debugger;

        if (clonediv == '#Unitclonediv') {
            proxy.invoke("CheckUnit_InAccessories", { Check_ID: id, CatID: catID_val }, function (result) {
                if ((result) == "1") {
                    alert("Unit already use");
                    return;
                }
                else {
                    //debugger;
                    // alert("remove");
                    supplierids.splice(index, 1);
                    $("#" + hValues).val(supplierids.join(","));
                    //$(this).closest('.unt').remove();
                    $("#divanc" + id).remove();
                }

            }, onPageError, false, false);
        }


        else if (clonediv == '#Unitclonediv1') {
            proxy.invoke("CheckSize_InAccessories", { Check_ID: id, CatID: catID_val }, function (result) {
                if ((result) == "1") {
                    alert("Size already use");
                    return;
                }
                else {
                    //alert("remove");
                    supplierids.splice(index, 1);
                    $("#" + hValues).val(supplierids.join(","));
                    //$(this).closest("div").remove();
                    $("#divanc" + id).remove();
                }

            }, onPageError, false, false);
        }

        else {
            supplierids.splice(index, 1);
            $("#" + hValues).val(supplierids.join(","));
            $(this).closest("div").remove();
        }
        return false;
        debugger;
    }
        );              //debugger;
    $(tdlist).append(ctrl);

}


function Addvalue_Cat(elem, name, tName, c1, c2, hValues, hNames, hId, clonediv, tdlist) {
    //debugger; 

    if (name == "") {
        alert("Invalid Value");
        return false;
    }

    if (elem == 'Yes') {
        proxy.invoke("InsertValue", { TableName: tName, col2: c2, name: name }, function (result) {
            //debugger;

        },
      onPageError, false, true);
        //debugger;
    }
    proxy.invoke("GetIdByName", { TableName: tName, Col1: c1, col2: c2, ColId: "", Values: name, Feild: "one" }, function (result) {
        if ((result) == "" || result == null) {
            alert("Invalid Value");
            return;
        }
        //debugger;
        var Tagvalues = $("#" + hValues).val();
        var id = result[0];
        if (Tagvalues == "") {
            $("#" + hValues).val(id);
            CloneDiv_Cat(id, name, hValues, clonediv, tdlist);
        }
        else {
            //debugger;
            var Tagids = Tagvalues.split(",");

            if (jQuery.inArray(id + "", Tagids) > -1) {
                alert("Duplicate Value");
                return false;
            }
            else {
                //debugger;
                $("#" + hValues).val($("#" + hValues).val() + "," + id);

                CloneDiv_Cat(id, name, hValues, clonediv, tdlist);
            }

        }

    }, onPageError, false, false);

};

function CloneDiv(id, name, hValues, clonediv, tdlist) {
//    debugger;

    var ctrl = $(clonediv).clone();
    ctrl.attr("id", "divanc" + id);
    //ctrl.find("a").attr("onclick", "JavaScript:RemoveSupplier(this.id,"+id+");return false;");
    ctrl.find("a").attr("id", "anc_" + id);
    ctrl.find("img").attr("id", "ancimg" + id);
    ctrl.find("label").html(name);
    ctrl.css("display", "");
    ctrl.find("a").click(function () {
       debugger;
        var id = $(this).attr("id").split("_")[1];
        var suppliervalues = $("#" + hValues).val();
        var supplierids = suppliervalues.split(",");
        var index = jQuery.inArray(id, supplierids);
       debugger;

        if (clonediv == '#Unitclonediv') {
            proxy.invoke("CheckUnit_InAccessories", { Check_ID: id }, function (result) {
                if ((result) == "1") {
                    alert("Invalid Value");
                    return;
                }
                else {
                    supplierids.splice(index, 1);
                    $("#" + hValues).val(supplierids.join(","));
                    $(this).closest("div").remove();
                }
            }, onPageError, false, false);
        }


        else if (clonediv == '#Unitclonediv1') {
            proxy.invoke("CheckSize_InAccessories", { Check_ID: id }, function (result) {
                if ((result) == "1") {
                    alert("Invalid Value");
                    return;
                }
                else {
                    supplierids.splice(index, 1);
                    $("#" + hValues).val(supplierids.join(","));
                    $(this).closest("div").remove();
                }
            }, onPageError, false, false);
        }
        else {
            supplierids.splice(index, 1);
            $("#" + hValues).val(supplierids.join(","));
            $(this).closest("div").remove();
        }
        //changes 

        return false;
       debugger;
    }
        );       //debugger;
    $(tdlist).append(ctrl);

}


function Addvalue(elem, name, tName, c1, c2, hValues, hNames, hId, clonediv, tdlist) {
   //debugger; 
   
    if (name == "") {
        alert("Invalid Value");
        return false;
    }

    if (elem == 'Yes') {
        proxy.invoke("InsertValue", { TableName: tName, col2: c2, name: name }, function (result) {
            //debugger;

        },
      onPageError, false, true);
        //debugger;
    }
    proxy.invoke("GetIdByName", { TableName: tName, Col1: c1, col2: c2, ColId: "", Values: name, Feild: "one" }, function (result) {
        if ((result) == "" || result == null) {
            alert("Invalid Value");
            return;
        }
        //debugger;
        var Tagvalues = $("#" + hValues).val();
        var id = result[0];
        if (Tagvalues == "") {
            $("#" + hValues).val(id);
            CloneDiv(id, name, hValues, clonediv, tdlist);
        }
        else {
            //debugger;
            var Tagids = Tagvalues.split(",");

            if (jQuery.inArray(id + "", Tagids) > -1) {
                alert("Duplicate Value");
                return false;
            }
            else {
                //debugger;
                $("#" + hValues).val($("#" + hValues).val() + "," + id);

                CloneDiv(id, name, hValues, clonediv, tdlist);
            }

        }

    }, onPageError, false, false);

};




function RemoveSupplier(srcElem, id) {
    //debugger;
    try {
        //debugger;
        var Tagvalues = $("#" + hValues).val();
        var Tagids = Tagvalues.split(",");
        var index = jQuery.inArray(id, Tagids);

        Tagids.splice(index - 1, 1);
       //debugger;

       $("#" + hValues).val(Tagids.join(","));
        $("#" + srcElem).closest("div").remove();
    } catch (e) {
        alert(e);
    }
}

// Author Ravi

function numbersonly(e) {
    debugger;
    var unicode = e.charCode ? e.charCode : e.keyCode
    if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
        if (unicode < 48 || unicode > 57) //if not a number
            return false //disable key press
    }
}
//function ShowSuppliers() {
//   debugger;

//    var sid = $("#" + hId).val();
//    if (sid == "")
//        return;
//    var sids = sid.split(",");
//    var snames = $.trim($("#" + hNames).val()).split(',');
//    for (var i = 0; i < sids.length; i++) {
//        CloneDiv(sids[i], snames[i], clonediv, tdlist);
//    }
//}

//function decimalPlace() {
//$(".2decimalPlace").keypress
//(
//function (event) {

//    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
//        event.preventDefault();
//    }
//}
//);
//}








