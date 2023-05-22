<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stitching.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.Stitching" %>
<style type="text/css">
    .bgimg
    {
        background-image: url(../../images/cs_bg.jpg);
        background-repeat: repeat-x;
        width: 100%;
        height: 37px;
        color: White;
        text-transform: capitalize !important;
    }
    
    .tdgrid
    {
        text-transform: capitalize !important;
        text-align: center;
    }
    .fontbold
    {
        font-weight: normal;
    }
    .txtalign
    {
        text-align: left;
    }
    
    
    
    hiddenControl
    {
        visibility: hidden;
    }
    
    .hasborder
    {
        border: 1px solid #FFFFFF;
    }
    tr th
    {
        font-family: Arial;
    }
    
    #tfheader
    {
        background-color: #c3dfef;
    }
    #tfnewsearch
    {
        float: right;
        padding: 20px;
    }
    .tftextinput
    {
        margin: 0;
        padding: 7px 5px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 14px;
        border: 1px solid #0076a3;
        float: left;
        border-radius: 5px 0px 0px 5px;
        width: 200px;
    }
    .tfbutton
    {
        margin: 0px 0px 0px -4px;
        padding: 3px 15px 5px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 14px;
        outline: none;
        cursor: pointer;
        text-align: center;
        text-decoration: none;
        color: #ffffff;
        border: solid 1px #0076a3;
        border-right: 0px;
        background: #0095cd;
        background: -webkit-gradient(linear, left top, left bottom, from(#00adee), to(#0078a5));
        background: -moz-linear-gradient(top,  #00adee,  #0078a5);
        border-radius: 0px 5px 5px 0px;
        position: absolute;
    }
    .tfbutton:hover
    {
        text-decoration: none;
        background: #007ead;
        background: -webkit-gradient(linear, left top, left bottom, from(#0095cc), to(#00678e));
        background: -moz-linear-gradient(top,  #0095cc,  #00678e);
    }
    /* Fixes submit button height problem in Firefox */
    .tfbutton::-moz-focus-inner
    {
        border: 0;
    }
    .tfclear
    {
        clear: both;
    }
    .select-option
    {
        padding: 4px 0px;
    }
    ::-webkit-input-placeholder
    {
        color: red;
        font-size: 10px !important;
        padding: 7px 5px;
        text-transform: capitalize !important;
    }
    
    :-moz-placeholder
    {
        /* Firefox 18- */
        color: red;
        font-size: 10px !important;
        padding: 7px 5px;
        text-transform: capitalize !important;
    }
    
    ::-moz-placeholder
    {
        /* Firefox 19+ */
        color: red;
        font-size: 10px !important;
        padding: 7px 5px;
        text-transform: capitalize !important;
    }
    
    :-ms-input-placeholder
    {
        color: red;
        font-size: 10px !important;
        padding: 7px 5px;
        text-transform: capitalize !important;
    }
    .secure_center_contentWrapper
    {
        text-transform:capitalize !important;   
    }
    .margintt{margin-top:4px;}
</style>
<script type="text/javascript">


    function SaveStitchingOBSamFront(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingFont.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingFont.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        //debugger;
        var chkMachine = $("#<%= grdStitchingFont.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSam", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {

                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }

    function SaveStitchingOBFront(elem, Falg) {

        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingFont.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingFont.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        //debugger;

        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            //alert(OperationVal);

            proxy.invoke("InsertStichingFont", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnFornt").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }

            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            //debugger;
            proxy.invoke("InsertUpdateStichingOB", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindFrontList(elem, OperationId);

        }

    }

    function BindFrontList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingFont.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceFront", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingFont.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }






    function SaveStichingOBSamBack(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingBack.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingBack.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var chkMachine = $("#<%= grdStitchingBack.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }

        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamBack", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {

                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }

    function SaveStichingOBBack(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingBack.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingBack.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            proxy.invoke("InsertStichingBack", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnBack").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBBack", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindBackList(elem, OperationId);
        }

    }

    function BindBackList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingBack.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceBack", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingBack.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }




    // Stiching coller

    function SaveStichingOBSamcoller(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingcoller.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingcoller.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var chkMachine = $("#<%= grdStitchingcoller.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }

        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamcoller", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }

    function SaveStichingOBcoller(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingcoller.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingcoller.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOperationcoller", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btncoller").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBcoller", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindcollerList(elem, OperationId);

        }

    }

    function BindcollerList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingcoller.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacecoller", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingcoller.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }



    // Stiching sleep

    function SaveStichingOBSamsleep(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingsleep.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingsleep.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var chkMachine = $("#<%= grdStitchingsleep.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }


        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }

        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamsleep", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }

    function SaveStichingOBsleep(elem, Falg) {
        // debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingsleep.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingsleep.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            // alert(OperationVal);
            proxy.invoke("InsertOperationsleep", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnsleep").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false; ;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBsleep", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindsleepList(elem, OperationId);

        }
    }

    function BindsleepList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingsleep.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacesleep", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingsleep.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }



    //------------
    // Stiching neck

    function SaveStichingOBSamneck(elem) {
        // debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingneck.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingneck.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var chkMachine = $("#<%= grdStitchingneck.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamNeck", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }

    function SaveStichingOBneck(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingneck.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingneck.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingneck", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnneck").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBNeck", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindneckList(elem, OperationId);

        }
    }

    function BindneckList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingneck.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceneck", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingneck.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }

    function checkLastValneck() {
        //debugger;
        var OperatioVal = $('#grdStitchingneck tr:last').find('td:first').text()
        var MachineVal = $('#grdStitchingneck tr:last').find('td:first').text()
        var lastProductId = $("#<%=grdStitchingneck.ClientID %> tr:last").children("td:first").html();

        var rowcount = $("#<%=grdStitchingneck.ClientID %> tr").length;
        if (rowcount < 10) {
            rowcount = '0' + rowcount;
        }
        var Section = $("#<%= grdStitchingneck.ClientID %> input[id*='ctl" + rowcount + "_txtOperationneck" + "']").val();

        //debugger;
        if (Section == "") {
            alert('Please Enter Opration!');
            return false;
        }
    }




    // For Stiching Lining


    function SaveLining(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingLining.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingLining.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var ListMachine = $("#<%= grdStitchingLining.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }

        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamLining", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }

    function SaveLiningOP(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingLining.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingLining.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingLining", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnLining").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBLining", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindLiningList(elem, OperationId);

        }
    }

    function BindLiningList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingLining.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceLining", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingLining.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }


    // For Stiching lower

    function SaveStichingOBSamlower(elem) {
        // debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchinglower.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchinglower.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var ListMachine = $("#<%= grdStitchinglower.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }

        proxy.invoke("InsertUpdateStichingOBSamLower", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
            if (result == "3") {
                alert('This Sam is already associate to existance style')
                elem.value = elem.defaultValue;
            }
        }, onPageError, false, false);
    }

    function SaveStichingOBlower(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchinglower.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchinglower.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingLower", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnlower").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBLower", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindlowerList(elem, OperationId);

        }
    }

    function BindlowerList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchinglower.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacelower", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchinglower.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }




    // For Stiching bottom

    function SaveStichingOBSambottom(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingbottom.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingbottom.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var ListMachine = $("#<%= grdStitchingbottom.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }


        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSambottom", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }

    function SaveStichingOBbottom(elem, Falg) {
        // debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingbottom.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingbottom.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingbottm", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnbottom").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBbottom", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('AllReady Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindbottomList(elem, OperationId);

        }
    }

    function BindbottomList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingbottom.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacebottom", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingbottom.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }





    // For Stiching assembly

    function SaveStichingOBSamassembly(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdStitchingassembly.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdStitchingassembly.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var ListMachine = $("#<%= grdStitchingassembly.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamassembly", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveStichingOBassembly(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdStitchingassembly.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdStitchingassembly.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingassembly", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnassembly").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBassembly", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindassemblyList(elem, OperationId);

        }

    }


    function BindassemblyList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdStitchingassembly.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceassembly", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdStitchingassembly.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }




    //END


    // For New Add Stiching assembly

    function SaveStichingOBSamassemblyAdd(elem) {
        debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= GrdStitchingAssemblyAdd.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= GrdStitchingAssemblyAdd.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var ListMachine = $("#<%= GrdStitchingAssemblyAdd.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamassembly", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }






    function SaveStichingOBassemblyAdd(elem, Falg) {
        debugger;

        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);

        var OperationId = $("#<%= GrdStitchingAssemblyAdd.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= GrdStitchingAssemblyAdd.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingassembly", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnassemblyAdd").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBassembly", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindassemblyListAdd(elem, OperationId);

        }

    }


    function BindassemblyListAdd(elem, OperationId) {
        debugger
        var SamVal = elem.value;

        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= GrdStitchingAssemblyAdd.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceassembly", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                //alert(value.Description);
                $("#<%= GrdStitchingAssemblyAdd.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }





    function ClearAllAssemblutxt() {
        //debugger;
        $(".txtblanck").val("");
        $(".lst1").find("option").attr("selected", false);
        $(".lstClear").empty();
        //grdNewAssambly
        $("#<%= GrdStitchingAssemblyAdd.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }

    //END
    // For Stiching Rest Grid

    function SaveStichingOBSamPiping(elem, Flag) {
        // debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];

        var OperationId = $("#<%= grdPiping.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdPiping.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var ListMachine = $("#<%= grdPiping.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }
        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: Flag }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveStichingOBPiping(elem, Falg, gridFlag) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdPiping.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdPiping.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnPiping").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindPipingList(elem, OperationId);

        }
    }

    function BindPipingList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var Flag = 'Piping';
        $("#<%= grdPiping.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: Flag }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdPiping.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }






    //For Upper

    function SaveStichingOBSamUpper(elem, Flag) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];

        var OperationId = $("#<%= grdUppersection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdUppersection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var ListMachine = $("#<%= grdUppersection.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();

        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }


        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: Flag }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveStichingOBUpper(elem, Falg, gridFlag) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdUppersection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdUppersection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnUppersection").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindUpperList(elem, OperationId);

        }
    }

    function BindUpperList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var Flag = 'Upper';
        $("#<%= grdUppersection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: Flag }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdUppersection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }





    //END

    //For Upper Shell

    function SaveStichingOBSamUppershell(elem, Flag) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];

        var OperationId = $("#<%= grdUppershell.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdUppershell.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var ListMachine = $("#<%= grdUppershell.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }

        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: Flag }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveStichingOBUppershell(elem, Falg, gridFlag) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdUppershell.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdUppershell.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnUppershell").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindUppershellList(elem, OperationId);

        }

    }
    function BindUppershellList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var Flag = 'Uppershell';
        $("#<%= grdUppershell.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: Flag }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdUppershell.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }





    //For Lower Shell

    function SaveStichingOBSamLowershell(elem, Flag) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];

        var OperationId = $("#<%= grdLowershell.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdLowershell.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var ListMachine = $("#<%= grdLowershell.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }
        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: Flag }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveStichingOBLowershell(elem, Falg, gridFlag) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdLowershell.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdLowershell.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnLowershell").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    // alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindLowershellList(elem, OperationId);

        }
    }

    function BindLowershellList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var Flag = 'Lowershell';
        $("#<%= grdLowershell.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: Flag }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdLowershell.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }






    //For Shell section

    function SaveStichingOBSamShellsection(elem, Flag) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];

        var OperationId = $("#<%= grdShellsection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdShellsection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var ListMachine = $("#<%= grdShellsection.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: Flag }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveOBShellSection(elem, Falg, gridFlag) {
        //debugger;

        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdShellsection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdShellsection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnShellsection").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindShellsectionList(elem, OperationId);

        }

    }

    function BindShellsectionList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var Flag = 'Shellsection';
        $("#<%= grdShellsection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: Flag }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdShellsection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }




    //For Waist section

    function SaveStichingOBSamWaistSection(elem, Flag) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];

        var OperationId = $("#<%= grdWaistSection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdWaistSection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var ListMachine = $("#<%= grdWaistSection.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: Flag }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveStichingOBWaistSection(elem, Falg, gridFlag) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdWaistSection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdWaistSection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnWaistSection").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');

                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindWaistSectionList(elem, OperationId);

        }
    }

    function BindWaistSectionList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var Flag = 'WaistSection';
        $("#<%= grdWaistSection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: Flag }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdWaistSection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }



    //For Band section

    function SaveStichingOBSamBandsection(elem, Flag) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];

        var OperationId = $("#<%= grdBandsection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdBandsection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var ListMachine = $("#<%= grdBandsection.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: Flag }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }




    function SaveStichingOBBandsection(elem, Falg, gridFlag) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdBandsection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdBandsection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnBandsection").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: gridFlag }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindBandsectionList(elem, OperationId);

        }
    }

    function BindBandsectionList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var Flag = 'Bandsection';
        $("#<%= grdBandsection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: Flag }, function (result) {
            $.each(result, function (key, value) {
                //debugger; 
                $("#<%= grdBandsection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }


    function checkLastValBandsection() {
        //debugger;
        var OperatioVal = $('#grdBandsection tr:last').find('td:first').text()
        var MachineVal = $('#grdBandsection tr:last').find('td:first').text()
        var lastProductId = $("#<%=grdBandsection.ClientID %> tr:last").children("td:first").html();

        var rowcount = $("#<%=grdBandsection.ClientID %> tr").length;
        if (rowcount < 10) {
            rowcount = '0' + rowcount;
        }
        var Section = $("#<%= grdBandsection.ClientID %> input[id*='ctl" + rowcount + "_txtOperationPiping" + "']").val();

        //debugger;
        if (Section == "") {
            alert('Please Enter Opration!')
            return false;
        }
    }


   


</script>
<script type="text/javascript">

    function SaveFinishingOBSam(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var ListMachine = $("#<%= grdFinishingOB.ClientID %> select[id*='ct" + ctId + "_chkMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateFinishingOBSam", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                //alert('saved successfully!');
            }, onPageError, false, false);
        }
    }

    function SaveFinishingOB(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertFinishing", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnFinishing").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateFinishingOB", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindFinishingList(elem, OperationId);

        }
    }

    function BindFinishingList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);

        $("#<%= grdFinishingOB.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceFinishing", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdFinishingOB.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }

    function checkLastVal() {
        //debugger;
        var OperatioVal = $('#grdFinishingOB tr:last').find('td:first').text()
        var MachineVal = $('#grdFinishingOB tr:last').find('td:first').text()
        var lastProductId = $("#<%=grdFinishingOB.ClientID %> tr:last").children("td:first").html();

        var rowcount = $("#<%=grdFinishingOB.ClientID %> tr").length;
        if (rowcount < 10) {
            rowcount = '0' + rowcount;
        }
        var Section = $("#<%= grdFinishingOB.ClientID %> input[id*='ctl" + rowcount + "_txtOperation" + "']").val();
        //debugger;
        if (Section == "") {
            alert('Please Enter Opration!')
            return false;
        }
    }
    //    added by abhishek on 3/9/2015 ------------------------------------------------------------------------------//
    //for neck section
    function Save_necksection_OBFront(elem, Falg) {

        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdnecksection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdnecksection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            //alert(OperationVal);

            proxy.invoke("InsertStichingNeckNew", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnnecksection").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }

            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            //debugger;
            proxy.invoke("InsertUpdateNecksectionOB", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindNeckList(elem, OperationId);

        }

    }
    function BindNeckList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdnecksection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceNeckSection", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdnecksection.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }

    function SaveStichingOBSamNeck_Section(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdnecksection.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdnecksection.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var chkMachine = $("#<%= grdnecksection.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }

        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamNeck_section", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                if (result == "3") {
                    alert('This Sam is already associate to existance style')
                    elem.value = elem.defaultValue;
                }
            }, onPageError, false, false);
        }
    }
    //end neck section 

    //neck faching section ---------------------------------------------------------------------------------------

    function Save_neck_faching_OBFront(elem, Falg) {

        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdneckfaching.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdneckfaching.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        //debugger;

        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            //alert(OperationVal);

            proxy.invoke("InsertStichingNeckfaching", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnneckfaching").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }

            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            //debugger;
            proxy.invoke("InsertUpdateNeckfaching", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindNeckfachingList(elem, OperationId);

        }

    }
    function BindNeckfachingList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdneckfaching.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceNeckfaching", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdneckfaching.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }

    function SaveStichingOBSamNeck_faching(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdneckfaching.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdneckfaching.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var chkMachine = $("#<%= grdneckfaching.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }

        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamNeckfaching", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                //alert('saved successfully!');
            }, onPageError, false, false);
        }
    }




    //front and back section ---------------------------------------------------------------------------------------

    function Save_neck_faching_frontback(elem, Falg) {
        debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);
        var OperationId = $("#<%= grdf_back.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdf_back.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        //debugger;

        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            //alert(OperationVal);

            proxy.invoke("InsertStichingNeckfachingfrontback", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".brnf_back").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }

            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }

            proxy.invoke("InsertUpdateNeckfachingfrontback", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {

                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindNeckfachingListfrontback(elem, OperationId);

        }

    }
    function BindNeckfachingListfrontback(elem, OperationId) {
        debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        $("#<%= grdf_back.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceNeckfachingfrontback", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdf_back.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }

    function SaveStichingOBSamNeck_fachingfrontback(elem) {
        debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdf_back.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdf_back.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();

        var chkMachine = $("#<%= grdf_back.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }

        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamNeckfachingfrontback", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                //alert('saved successfully!');
            }, onPageError, false, false);
        }
    }

    //end front and back section


    function doneTyping(evt, id) {

        var regexTest = /^\d+\.\d{0,2}$/;
        var ok = regexTest.test(evt.value);
        if (!ok) {
            evt.value = '';
            return false;
        }

    }
    //added by abhishek on 24/10/2015

    $(document).ready(function () {
        $('.tftextinput').focus(function () {
           // $('.tftextinput').val("");
        });
    });

    //here make all opration just like assembly opration

    //back-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function ClearbackAddtxt() {

        $(".txtOperationback_Add").val("");
        $(".csslistback").find("option").attr("selected", false);
        $(".csslistback_clear").empty();
        $("#<%= grdBack_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Back_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdBack_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdBack_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationback_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingBack", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnbank_add").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBBack", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            Bindback_add(elem, OperationId);

        }

    }
    function Bindback_add(elem, OperationId) {
        //debugger
        var SamVal = elem.value;

        var ctId = elem.id.split('_')[7].substr(2);
        $("#<%= grdBack_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceBack", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdBack_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBBack_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdBack_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdBack_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationback_Add" + "']").val();

        var ListMachine = $("#<%= grdBack_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamBack", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }

    //bottom---------------------------------------------------------------------------------------------------------------------------------------------------------------------//

    function ClearAllbottomAddtxt() {

        $(".txtbottom_add_blanck").val("");
        $(".bottom_add").find("option").attr("selected", false);
        $(".bottomaddClear").empty();
        $("#<%= grdbottom_add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOBBottom_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdbottom_add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdbottom_add.ClientID %> input[id*='ct" + ctId + "_txtOperationbottom" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingbottm", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnbottom_Add").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBbottom", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            Bindbottom_add(elem, OperationId);

        }

    }
    function Bindbottom_add(elem, OperationId) {
        //debugger
        var SamVal = elem.value;

        var ctId = elem.id.split('_')[7].substr(2);
        $("#<%= grdbottom_add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacebottom", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdbottom_add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBbottom_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdbottom_add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdbottom_add.ClientID %> input[id*='ct" + ctId + "_txtOperationbottom" + "']").val();

        var ListMachine = $("#<%= grdbottom_add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSambottom", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Coller-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function ClearCollerkAddtxt() {

        $(".txtOperationColler_Add").val("");
        $(".csslistColler").find("option").attr("selected", false);
        $(".csslistColler_clear").empty();
        $("#<%= grdColler_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Coller_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdColler_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdColler_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationColler_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOperationcoller", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnColler_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBcoller", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindColler_add(elem, OperationId);

        }

    }
    function BindColler_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        $("#<%= grdColler_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacecoller", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdColler_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBColler_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdColler_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdColler_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationColler_Add" + "']").val();

        var ListMachine = $("#<%= grdColler_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamcoller", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Coller End-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    //Sleep-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearleep() {

        $(".txtOperationSleep_Add").val("");
        $(".csslistSleep").find("option").attr("selected", false);
        $(".csslistSleep_clear").empty();
        $("#<%= grdSleep_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Sleep_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdSleep_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdSleep_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationSleep_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOperationsleep", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnSleep_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBsleep", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindSleep_add(elem, OperationId);

        }

    }
    function BindSleep_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        $("#<%= grdSleep_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacesleep", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdSleep_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }

    function SaveStichingOBSleep_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdSleep_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdSleep_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationSleep_Add" + "']").val();

        var ListMachine = $("#<%= grdSleep_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamsleep", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Sleep End-----------------------------------------------------------------------------------------------------------------------------------------------------------//


    //Neck-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearNeck() {

        $(".txtOperationNeck_Add").val("");
        $(".csslistNeck").find("option").attr("selected", false);
        $(".csslistNeck_clear").empty();
        $("#<%= grdNeck_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Neck_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdNeck_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdNeck_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationNeck_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingneck", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnNeck_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBNeck", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindNeck_add(elem, OperationId);

        }

    }
    function BindNeck_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdNeck_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceneck", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdNeck_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBNeck_Add(elem) {
        debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdNeck_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdNeck_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationNeck_Add" + "']").val();

        var ListMachine = $("#<%= grdNeck_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamNeck", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Neck End-----------------------------------------------------------------------------------------------------------------------------------------------------------//


    //lining-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearlining() {

        $(".txtOperationlining_Add").val("");
        $(".csslistlining").find("option").attr("selected", false);
        $(".csslistlining_clear").empty();
        $("#<%= grdlining_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_lining_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdlining_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdlining_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationlining_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichingLining", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnlining_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBLining", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            Bindlining_add(elem, OperationId);

        }

    }
    function Bindlining_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdlining_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceLining", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdlining_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBlining_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdlining_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdlining_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationlining_Add" + "']").val();

        var ListMachine = $("#<%= grdlining_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamLining", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //lining End-----------------------------------------------------------------------------------------------------------------------------------------------------------//

    //lower-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearlower() {

        $(".txtOperationlower_Add").val("");
        $(".csslistlower").find("option").attr("selected", false);
        $(".csslistlower_clear").empty();
        $("#<%= grdlower_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_lower_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdlower_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdlower_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationlower_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertStichinglower", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnlower_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBlower", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            Bindlower_add(elem, OperationId);

        }

    }
    function Bindlower_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdlower_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpacelower", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdlower_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBlower_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdlower_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdlower_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationlower_Add" + "']").val();

        var ListMachine = $("#<%= grdlower_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamlower", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //lower End-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    //Piping-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearPiping() {

        $(".txtOperationPiping_Add").val("");
        $(".csslistPiping").find("option").attr("selected", false);
        $(".csslistPiping_clear").empty();
        $("#<%= grdPiping_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Piping_Add(elem, Falg) {

        debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdPiping_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdPiping_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationPiping_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'Piping' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnPiping_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'Piping' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindPiping_add(elem, OperationId);

        }

    }
    function BindPiping_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdPiping_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'Piping' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdPiping_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBPiping_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdPiping_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdPiping_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationPiping_Add" + "']").val();

        var ListMachine = $("#<%= grdPiping_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'Piping' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Piping End-----------------------------------------------------------------------------------------------------------------------------------------------------------//



    //Upper-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearUpper() {

        $(".txtOperationUpper_Add").val("");
        $(".csslistUpper").find("option").attr("selected", false);
        $(".csslistUpper_clear").empty();
        $("#<%= grdUpper_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Upper_Add(elem, Falg) {

        debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdUpper_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdUpper_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationUpper_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'Upper' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnUpper_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'Upper' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindUpper_add(elem, OperationId);

        }

    }
    function BindUpper_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdUpper_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'Upper' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdUpper_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBUpper_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdUpper_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdUpper_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationUpper_Add" + "']").val();

        var ListMachine = $("#<%= grdUpper_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'Upper' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Upper End-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    //Uppershell-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearUppershell() {

        $(".txtOperationUppershell_Add").val("");
        $(".csslistUppershell").find("option").attr("selected", false);
        $(".csslistUppershell_clear").empty();
        $("#<%= grdUppershell_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Uppershell_Add(elem, Falg) {

        debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdUppershell_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdUppershell_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationUppershell_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'Uppershell' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnUppershell_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'Uppershell' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindUppershell_add(elem, OperationId);

        }

    }
    function BindUppershell_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdUppershell_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'Uppershell' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdUppershell_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBUppershell_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdUppershell_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdUppershell_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationUppershell_Add" + "']").val();

        var ListMachine = $("#<%= grdUppershell_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'Uppershell' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Uppershell End-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    //Lowershell-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearLowershell() {

        $(".txtOperationLowershell_Add").val("");
        $(".csslistLowershell").find("option").attr("selected", false);
        $(".csslistLowershell_clear").empty();
        $("#<%= grdLowershell_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Lowershell_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdLowershell_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdLowershell_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationLowershell_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'Lowershell' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnLowershell_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'Lowershell' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindLowershell_add(elem, OperationId);

        }

    }
    function BindLowershell_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdLowershell_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'Lowershell' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdLowershell_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBLowershell_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdLowershell_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdLowershell_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationLowershell_Add" + "']").val();

        var ListMachine = $("#<%= grdLowershell_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return; f
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'Lowershell' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Lowershell End-----------------------------------------------------------------------------------------------------------------------------------------------------------//

    //Shellsection-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearShellsection() {

        $(".txtOperationShellsection_Add").val("");
        $(".csslistShellsection").find("option").attr("selected", false);
        $(".csslistShellsection_clear").empty();
        $("#<%= grdShellsection_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Shellsection_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdShellsection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdShellsection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationShellsection_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'Shellsection' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnShellsection_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'Shellsection' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindShellsection_add(elem, OperationId);

        }

    }
    function BindShellsection_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdShellsection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'Shellsection' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdShellsection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBShellsection_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdShellsection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdShellsection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationShellsection_Add" + "']").val();

        var ListMachine = $("#<%= grdShellsection_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'Shellsection' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }

    //Shellsection End-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    //WaistSection-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearWaistSection() {

        $(".txtOperationWaistSection_Add").val("");
        $(".csslistWaistSection").find("option").attr("selected", false);
        $(".csslistWaistSection_clear").empty();
        $("#<%= grdWaistSection_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_WaistSection_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdWaistSection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdWaistSection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationWaistSection_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'WaistSection' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnWaistSection_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'WaistSection' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindWaistSection_add(elem, OperationId);

        }

    }
    function BindWaistSection_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdWaistSection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'WaistSection' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdWaistSection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBWaistSection_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdWaistSection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdWaistSection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationWaistSection_Add" + "']").val();

        var ListMachine = $("#<%= grdWaistSection_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'WaistSection' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //WaistSection End-----------------------------------------------------------------------------------------------------------------------------------------------------------//


    //Bandsection-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearBandsection() {

        $(".txtOperationBandsection_Add").val("");
        $(".csslistBandsection").find("option").attr("selected", false);
        $(".csslistBandsection_clear").empty();
        $("#<%= grdBandsection_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Bandsection_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdBandsection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdBandsection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationBandsection_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'Bandsection' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnBandsection_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'Bandsection' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindBandsection_add(elem, OperationId);

        }

    }
    function BindBandsection_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdBandsection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'Bandsection' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdBandsection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBBandsection_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdBandsection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdBandsection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationBandsection_Add" + "']").val();

        var ListMachine = $("#<%= grdBandsection_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'Bandsection' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Bandsection End-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    //necksection-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearnecksection() {

        $(".txtOperationnecksection_Add").val("");
        $(".csslistnecksection").find("option").attr("selected", false);
        $(".csslistnecksection_clear").empty();
        $("#<%= grdnecksection_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_necksection_Add(elem, Falg) {
        debugger;

        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdnecksection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdnecksection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationnecksection_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'necksection' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnnecksection_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'necksection' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            Bindnecksection_add(elem, OperationId);

        }

    }
    function Bindnecksection_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdnecksection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'necksection' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdnecksection_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBnecksection_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdnecksection_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdnecksection_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationnecksection_Add" + "']").val();

        var ListMachine = $("#<%= grdnecksection_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'necksection' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //necksection End-----------------------------------------------------------------------------------------------------------------------------------------------------------//

    //neckfaching-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearneckfaching() {

        $(".txtOperationneckfaching_Add").val("");
        $(".csslistneckfaching").find("option").attr("selected", false);
        $(".csslistneckfaching_clear").empty();
        $("#<%= grdneckfaching_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_neckfaching_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdneckfaching_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdneckfaching_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationneckfaching_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'neckfaching' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnneckfaching_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'neckfaching' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            Bindneckfaching_add(elem, OperationId);

        }

    }
    function Bindneckfaching_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdneckfaching_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'neckfaching' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdneckfaching_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBneckfaching_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdneckfaching_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdneckfaching_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationneckfaching_Add" + "']").val();

        var ListMachine = $("#<%= grdneckfaching_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'neckfaching' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //neckfaching End-----------------------------------------------------------------------------------------------------------------------------------------------------------//

    //f_back-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearf_back() {

        $(".txtOperationf_back_Add").val("");
        $(".csslistf_back").find("option").attr("selected", false);
        $(".csslistf_back_clear").empty();
        $("#<%= grdf_back_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_f_back_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[8].substr(2);

        var OperationId = $("#<%= grdf_back_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdf_back_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationf_back_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'f_back' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnf_back_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'f_back' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            Bindf_back_add(elem, OperationId);

        }

    }
    function Bindf_back_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[8].substr(2);

        $("#<%= grdf_back_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'f_back' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdf_back_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBf_back_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[8].substr(2);
        var GarmentTypeId = elem.id.split('_')[11];
        var OperationId = $("#<%= grdf_back_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdf_back_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationf_back_Add" + "']").val();

        var ListMachine = $("#<%= grdf_back_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'f_back' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //f_back End-----------------------------------------------------------------------------------------------------------------------------------------------------------//

    //Front-----------------------------------------------------------------------------------------------------------------------------------------------------------//
    function checkClearFront() {

        $(".txtOperationFront_Add").val("");
        $(".csslistFront").find("option").attr("selected", false);
        $(".csslistFront_clear").empty();
        $("#<%= grdFront_Add.ClientID %> input[id*='ctl02" + "_hdnOperationId" + "']").val("");


    }
    function SaveStichingOB_Front_Add(elem, Falg) {


        var OperationId = elem.id;
        var ctId = elem.id.split('_')[7].substr(2);

        var OperationId = $("#<%= grdFront_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();



        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdFront_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationFront_Add" + "']").val();


        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');

            proxy.invoke("InsertOpationStichingAll", { OperationVal: OperationVal, gridFlag: 'Front' }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnFront_adds").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);

        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return false;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            //debugger;
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateStichingOBALL", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg, gridFlag: 'Front' }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {

            BindFront_add(elem, OperationId);

        }

    }
    function BindFront_add(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);

        $("#<%= grdFront_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceStichingAll", { OperationId: OperationId, Flag: 'Front' }, function (result) {
            $.each(result, function (key, value) {

                $("#<%= grdFront_Add.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }
    function SaveStichingOBFront_Add(elem) {

        var SamVal = elem.value;
        var ctId = elem.id.split('_')[7].substr(2);
        var GarmentTypeId = elem.id.split('_')[10];
        var OperationId = $("#<%= grdFront_Add.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdFront_Add.ClientID %> input[id*='ct" + ctId + "_txtOperationFront_Add" + "']").val();

        var ListMachine = $("#<%= grdFront_Add.ClientID %> select[id*='ct" + ctId + "_ListMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return false;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateStichingOBSamAll", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal, Flag: 'Front' }, function (result) {
                // alert('saved successfully!');
            }, onPageError, false, false);
        }
    }
    //Front End-----------------------------------------------------------------------------------------------------------------------------------------------------------//

    //added by abhishek ADD ON feature
    $(function () {
        $('#scrlBotm').click(function () {
            $('html, body').animate({
                scrollTop: $(document).height()
            },
                 1500);
            return false;
        });

        $('#scrlTop').click(function () {
            $('html, body').animate({
                scrollTop: '0px'
            },
                 1500);
            return false;
        });
    });
    $(document).ready(function () {

        var rdolist = $('.rdolist input:checked').val()
        $(".Stopsearching-txt").hide();
        if ($(".CssbtnAddNew").is(":visible") == true || rdolist == 3 || rdolist == 2) {
            $(".topcss").show();
            $(".tftextinput").attr('disabled', false);
            $(".tfbutton").attr('disabled', false);
            $(".Stopsearching-txt").hide();

        }
        else {
            $(".topcss").hide();
            $(".tftextinput").attr('disabled', true);
            $(".tfbutton").attr('disabled', true);
            $(".tftextinput").val("");



            $(function () {
                $(".search-box").hover(function () {
                    $(".Stopsearching-txt").show();

                }, function () {
                    $(".Stopsearching-txt").hide();
                });
            });

        }

    });




    $('form').live("submit", function () {

        // $.showprogress();
        //ShowProgress();


    });

    

</script>
<style type="text/css">
    .stitching-head
    {
        table-layout: fixed;
    }
</style>
<table width="100%" class="stitching-head" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <div style="float: left; width: 220px">
                            <asp:RadioButtonList ID="rbtnlistsection" runat="server" CssClass="rdolist" AutoPostBack="true"
                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnlistsection_SelectedIndexChanged">
                                <asp:ListItem Value="1" Text="Stitching" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Finishing"></asp:ListItem>
                                <asp:ListItem Value="3" Text="All"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="Stopsearching-txt" style="float: left; min-width: 270px; padding: 1px;
                            border: 3px dashed #ccc; background: #eee;">
                            For search go to section list then Search..
                            <%-- <img src="../../App_Themes/ikandi/images/wait1.gif" alt="" />--%>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <%--added by abhishek on 22/10/2015--%>
                    <td>
                        <div style="float: left; width: 220px">
                            &nbsp;
                            <asp:DropDownList ID="ddlStitchSection" runat="server" Visible="false" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlStitchSection_SelectedIndexChanged" CssClass="select-option">
                                <%--<asp:ListItem Value="-1" Text="All Section"></asp:ListItem>--%>
                                <asp:ListItem Value="1" Text="Front Section" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Back Section"></asp:ListItem>
                                <asp:ListItem Value="3" Text="COLLAR Section"></asp:ListItem>
                                <asp:ListItem Value="4" Text="SLEEVE Section"></asp:ListItem>
                                <asp:ListItem Value="5" Text="FRILL Section"></asp:ListItem>
                                <asp:ListItem Value="6" Text="LINING Section"></asp:ListItem>
                                <asp:ListItem Value="7" Text="LOWER Section"></asp:ListItem>
                                <asp:ListItem Value="8" Text="CAMI Section"></asp:ListItem>
                                <asp:ListItem Value="9" Text="ASSEMBLY Section"></asp:ListItem>
                                <asp:ListItem Value="10" Text="PIPING Section"></asp:ListItem>
                                <asp:ListItem Value="11" Text="UPPER Section"></asp:ListItem>
                                <asp:ListItem Value="12" Text="UPPER SHELL & LINING Section"></asp:ListItem>
                                <asp:ListItem Value="13" Text="LOWER SHELL & LINING Section"></asp:ListItem>
                                <asp:ListItem Value="14" Text="SHELL Section"></asp:ListItem>
                                <asp:ListItem Value="15" Text="WAIST Section"></asp:ListItem>
                                <asp:ListItem Value="16" Text="BAND Section"></asp:ListItem>
                                <%--added by abhishek on 3/9/2015--%>
                                <asp:ListItem Value="17" Text="NECK Section"></asp:ListItem>
                                <asp:ListItem Value="18" Text="NECk facing "></asp:ListItem>
                                <asp:ListItem Value="19" Text="FRONT & BACk section"></asp:ListItem>
                                <%--end by abhishk 3/9/2015--%>
                            </asp:DropDownList>
                        </div>
                        <div style="float: left; width: 320px;" class="search-box">
                            <asp:TextBox ID="txtsearch" placeholder="Search by starting name of operation.." runat="server"
                                ToolTip="search by operation only" class="tftextinput" Height='10'></asp:TextBox>
                            <%--<asp:UpdatePanel runat="server" ID="Panel">
                                <ContentTemplate>--%>
                            <%-- <asp:Button runat="server" ID="UpdateButton" OnClick="btngo_Click" Text="Update" />--%>
                            <asp:Button ID="btngo" runat="server" Text="search" class="tfbutton" OnClick="btngo_Click" />
                            <%--</ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btngo" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                            <%--<asp:UpdateProgress runat="server" ID="uproAttandanceList" AssociatedUpdatePanelID="Panel"
                                DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="../../App_Themes/ikandi/images/wait1.gif" alt="" style="position: fixed;
                                        z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                        </div>
                        <%--<div class="loading" align="center">
                            <%--Loading. Please wait.<br />
                            <br />
                            <img src="../../App_Themes/ikandi/images/wait1.gif" alt="" />
                        </div>--%>
                    </td>
                    <%--end by abhishk 22/10/2015--%>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr id="trFront" runat="server">
        <td align="center" class="head-back">
            <asp:Label ID="lblStitching" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <div id="divfront" runat="server">
                <asp:Button ID="btnFront_up_Add" runat="server" CssClass="CssbtnAddNew margintt" Text="Add New"
                    OnClick="btnFront_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnFornt" CssClass="btnFornt" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnFornt_Click"  />
                                    <asp:GridView ID="grdStitchingFont" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingFont_RowDataBound" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchingFont_PageIndexChanging"   ShowHeader="true" HeaderStyle-CssClass="head-back">
                                        <PagerSettings Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="200px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperation" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStitchingOBFront(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Front") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="90" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="listStichingFront" onclick="javascript:return SaveStitchingOBFront(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="tdMachine" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="95%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="tdgrid" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">front section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdnStitchingFontOB" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" OnClientClick="javascript:return checkLastValFont();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivFront_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel36" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnFront_add" CssClass="btnFront_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnFront_add_Click" />
                        <asp:GridView ID="grdFront_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdFront_Add" OnRowDataBound="grdFront_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationFront_Add" Width="98%" runat="server" CssClass="txtOperationFront_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Front_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Front") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistFront" onclick="javascript:return SaveStichingOB_Front_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistFront_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivFrontlist_Add" runat="server" style="margin:10px 0;">
                    <input type="button" name="Add" title="Add New" value="Add" class="da_submit_button" onclick="javascript:return checkClearFront();" />
                    <asp:Button ID="btnAddFront_add_Lists" runat="server" Text="Show List" CssClass="da_submit_button" OnClick="btnAddFront_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trBack" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblStitchingBack" runat="server" Text=""></asp:Label>
                
        </td>
    </tr>
    <tr>
        <td>
            <div id="divBack" runat="server">
                <asp:Button ID="btnbacknew_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnbacknew_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnBack" CssClass="btnBack" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnBack_Click" />
                                    <asp:GridView ID="grdStitchingBack" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingBack_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchingBack_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperation" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBBack(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_back") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBBack(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">Back section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdnStitchingbackOB" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--<asp:Button ID="btnAddStichingBack" runat="server" Visible="false" Text="Add" OnClick="btnAddStichingBack_Click"
                                        OnClientClick="javascript:return checkLastValBack();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivBack_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel23" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnbank_add" CssClass="btnbank_add" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnbank_add_Click" />
                        <asp:GridView ID="grdBack_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdback" OnRowDataBound="grdBack_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationback_Add" Width="98%" runat="server" CssClass="txtOperationback_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Back_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_back") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistback" onclick="javascript:return SaveStichingOB_Back_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="120PX" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistback_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivBacklist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return ClearbackAddtxt();" />
                    <asp:Button ID="btnAddBack_add_List" runat="server" Text="Show List" OnClick="btnAddBack_add_List_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trcoller" runat="server">
        <td align="center" class="head-back">
           
                        <asp:Label ID="lblcoller" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divcoller" runat="server">
                <asp:Button ID="btnColler_up_Add" CssClass="CssbtnAddNew" runat="server" Text="Add New"
                    OnClick="btnColler_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btncoller" CssClass="btncoller" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btncoller_Click" />
                                    <asp:GridView ID="grdStitchingcoller" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingcoller_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchingcoller_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="OPeration">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationcoller" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBcoller(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_coller") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBcoller(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">Coller section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--<asp:Button ID="btnAddStichingcoller" runat="server" Text="Add" Visible="false" OnClick="btnAddStichingcoller_Click"
                                        OnClientClick="javascript:return checkLastValcoller();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivColler_Add" runat="server">
                <asp:UpdatePanel ID="Upd10" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnColler_add" CssClass="btnColler_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnColler_add_Click" />
                        <asp:GridView ID="grdColler_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdColler_Add" OnRowDataBound="grdColler_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationColler_Add" Width="98%" runat="server" CssClass="txtOperationColler_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Coller_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_coller") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistColler" onclick="javascript:return SaveStichingOB_Coller_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="120PX" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistColler_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivCollerlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" id="btnClearColler" value="Add" onclick="javascript:return ClearCollerkAddtxt();" />
                    <asp:Button ID="btnAddColler_add_Lists" runat="server" Text="Show List" OnClick="btnAddColler_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trsleep" runat="server">
        <td align="center" class="head-back">
           
                        <asp:Label ID="lblsleep" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divsleep" runat="server">
                <asp:Button ID="btnsleep_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnsleep_up_Add_Click" />
                <asp:UpdatePanel ID="pannel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnsleep" CssClass="btnsleep" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnsleep_Click" />
                                    <asp:GridView ID="grdStitchingsleep" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingsleep_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchingsleep_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationsleep" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBsleep(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_sleep") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBsleep(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">Sleev section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--<asp:Button ID="btnAddStichingsleep" runat="server" Visible="false" Text="Add" OnClick="btnAddStichingsleep_Click"
                                        OnClientClick="javascript:return checkLastValsleep();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivSleep_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSleep_add" CssClass="btnSleep_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnSleep_add_Click" />
                        <asp:GridView ID="grdSleep_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdSleep_Add" OnRowDataBound="grdSleep_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationSleep_Add" Width="98%" runat="server" CssClass="txtOperationSleep_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Sleep_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_sleep") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistSleep" onclick="javascript:return SaveStichingOB_Sleep_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="120PX" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistSleep_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivSleeplist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearleep();" />
                    <asp:Button ID="btnAddSleep_add_Lists" runat="server" Text="Show List" OnClick="btnAddSleep_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trneck" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblneck" runat="server" Text=""></asp:Label>
                  
        </td>
    </tr>
    <tr>
        <td>
            <div id="divneck" runat="server">
                <asp:Button ID="btnNeck_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnNeck_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnneck" CssClass="btnneck" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnneck_Click" />
                                    <asp:GridView ID="grdStitchingneck" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingneck_RowDataBound" ShowHeader="true"  AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchingneck_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="98%" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationneck" Width="250px" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBneck(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_neck") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBneck(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">neck section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdnStitchingneckOB" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingNeck" runat="server" Text="Add" OnClick="btnAddStichingNeck_Click"
                                        OnClientClick="javascript:return checkLastValneck();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivNeck_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel24" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnNeck_add" CssClass="btnNeck_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnNeck_add_Click" />
                        <asp:GridView ID="grdNeck_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdNeck_Add" OnRowDataBound="grdNeck_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationNeck_Add" Width="98%" runat="server" CssClass="txtOperationNeck_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Neck_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Neck") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistNeck" onclick="javascript:return SaveStichingOB_Neck_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistNeck_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivNecklist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearNeck();" />
                    <asp:Button ID="btnAddNeck_add_Lists" runat="server" Text="Show List" OnClick="btnAddNeck_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trLining" runat="server">
        <td align="center" class="head-back">
           
                        <asp:Label ID="lblLining" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divLining" runat="server">
                <asp:Button ID="btnlining_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnlining_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnLining" CssClass="btnLining" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnLining_Click" />
                                    <asp:GridView ID="grdStitchingLining" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingLining_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchingLining_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationLining" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveLiningOP(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_lining") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveLiningOP(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">lining section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdnStitchingLiningOB" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingLining" runat="server" Text="Add" OnClick="btnAddStichingLining_Click"
                                        OnClientClick="javascript:return checkLastValLining();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="Divlining_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel25" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnlining_add" CssClass="btnlining_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnlining_add_Click" />
                        <asp:GridView ID="grdlining_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdlining_Add" OnRowDataBound="grdlining_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationlining_Add" Width="98%" runat="server" CssClass="txtOperationlining_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_lining_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_lining") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistlining" onclick="javascript:return SaveStichingOB_lining_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="120PX" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistlining_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="Divlininglist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearlining();" />
                    <asp:Button ID="btnAddlining_add_Lists" runat="server" Text="Show List" OnClick="btnAddlining_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trlower" runat="server">
        <td align="center" class="head-back">
           
                        <asp:Label ID="lbllower" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divlower" runat="server">
                <asp:Button ID="btnlower_up_Add" Visible="true" runat="server" CssClass="CssbtnAddNew"
                    Text="Add New" OnClick="btnlower_up_Add_Click" />
                <asp:UpdatePanel ID="pannl44" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnlower" CssClass="btnlower" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnlower_Click" />
                                    <asp:GridView ID="grdStitchinglower" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchinglower_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchinglower_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationlower" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_lower") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBlower(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">lower section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdnStitchinglowerOB" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichinglower" runat="server" Text="Add" OnClick="btnAddStichinglower_Click"
                                        OnClientClick="javascript:return checkLastVallower();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="Divlower_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnlower_add" CssClass="btnlower_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnlower_add_Click" />
                        <asp:GridView ID="grdlower_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdlower_Add" OnRowDataBound="grdlower_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationlower_Add" Width="98%" runat="server" CssClass="txtOperationlower_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_lower_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_lower") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistlower" onclick="javascript:return SaveStichingOB_lower_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="120PX" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistlower_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="Divlowerlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearlower();" />
                    <asp:Button ID="btnAddlower_add_Lists" runat="server" Text="Show List" OnClick="btnAddlower_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trbottom" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblbottom" runat="server" Text=""></asp:Label>
                  
        </td>
    </tr>
    <tr>
        <td>
            <div id="divbottom" runat="server">
                <asp:Button ID="btnbottom_addnew" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnbottom_addnew_Click" />
                <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnbottom" CssClass="btnbottom" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnbottom_Click" />
                                    <asp:GridView ID="grdStitchingbottom" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingbottom_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdStitchingbottom_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationbottom" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBbottom(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_bottom") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBbottom(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <emptydatatemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                       <h3>There are no records available in <strong style="color:Red"> bottom section </strong>.for your search</h3> 
                                                    </td>
                                                </tr>
                                            </table>
                                        </emptydatatemplate>
                                    </asp:GridView>
                                    
                                    <asp:HiddenField ID="hdnStitchingbottomOB" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--<asp:Button ID="btnAddStichingbottom" runat="server" Text="Add" Visible="false" OnClick="btnAddStichingbottom_Click"
                                        OnClientClick="javascript:return checkLastValbottom();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="divbottom_add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel22" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnbottom_add" CssClass="btnbottom_Add" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnbottom_add_Click" />
                        <asp:GridView ID="grdbottom_add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdNewAssambly" OnRowDataBound="grdbottom_add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationbottom" Width="98%" runat="server" CssClass="txtbottom_add_blanck"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOBBottom_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_bottom") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox bottom_add" onclick="javascript:return SaveStichingOBBottom_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox bottomaddClear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="divbottombtn" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return ClearAllbottomAddtxt();" />
                    <asp:Button ID="btnbottom_list" runat="server" Text="Show List" OnClick="btnbottom_list_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr id="trassembly" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblassembly" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divassembly" runat="server">
                <asp:Button ID="btnAssemblyAddnew" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnAssemblyAddnew_Click" />
                <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <%--<asp:Button ID="btnassembly" CssClass="btnassembly" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnassembly_Click" />--%>
                                    <asp:GridView ID="grdStitchingassembly" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdStitchingassembly_RowDataBound" ShowHeader="true" AllowPaging="true"
                                        OnPageIndexChanging="grdStitchingassembly_PageIndexChanging" PageSize="30" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationassembly" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBassembly(this,1)"></asp:TextBox>
                                                    <%--<asp:TextBox ID="txtOperationassembly" Width="150" runat="server" AutoPostBack="true" 
                                    Text='<%#Eval("FactoryWorkSpace") %>'  
                                    ontextchanged="txtOperationassembly_TextChanged" ></asp:TextBox>--%>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_assembly") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBassembly(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">assembly section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingassembly" runat="server" Text="Add" Visible="false"
                                        OnClick="btnAddStichingassembly_Click" OnClientClick="javascript:return checkLastValassembly();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="divStitchingAssemblyAdd" runat="server">
                <asp:UpdatePanel ID="UpdatePanel18" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnassemblyAdd" CssClass="btnassemblyAdd" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnassemblyAdd_Click" />
                        <asp:GridView ID="GrdStitchingAssemblyAdd" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdNewAssambly" OnRowDataBound="GrdStitchingAssemblyAdd_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationassembly" Width="98%" runat="server" CssClass="txtblanck"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOBassemblyAdd(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_assembly") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox lst1" onclick="javascript:return SaveStichingOBassemblyAdd(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox lstClear"></asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="divAddassemblybtn" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return ClearAllAssemblutxt();" />
                    <asp:Button ID="btnAddassemblyList" runat="server" Text="Show List" OnClick="btnAddassemblyList_Click" />
                </div>
            </div>
        </td>
    </tr>
    <%--for Piping--%>
    <tr id="trPiping" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblPiping" runat="server" Text=""></asp:Label>
                  
        </td>
    </tr>
    <tr>
        <td>
            <div id="divPiping" runat="server">
                <asp:Button ID="btnPiping_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnPiping_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnPiping" CssClass="btnPiping" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnPiping_Click" />
                                    <asp:GridView ID="grdPiping" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdPiping_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdPiping_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationPiping" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBPiping(this,1,'Piping')"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Piping") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBPiping(this,2,'Piping')">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">piping section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField4" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--<asp:Button ID="btnAddStichingPiping" runat="server" Text="Add" OnClick="btnAddStichingPiping_Click"
                                        OnClientClick="javascript:return checkLastValPiping();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivPiping_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel26" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnPiping_add" CssClass="btnPiping_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnPiping_add_Click" />
                        <asp:GridView ID="grdPiping_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdPiping_Add" OnRowDataBound="grdPiping_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationPiping_Add" Width="98%" runat="server" CssClass="txtOperationPiping_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Piping_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Piping") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistPiping" onclick="javascript:return SaveStichingOB_Piping_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistPiping_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivPipinglist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearPiping();" />
                    <asp:Button ID="btnAddPiping_add_Lists" runat="server" Text="Show List" OnClick="btnAddPiping_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <%--END--%>
    <%--for Piping--%>
    <tr id="trUpper" runat="server">
        <td align="center" class="head-back">
           
                        <asp:Label ID="lblUpper" runat="server" Text=""></asp:Label>
                  
        </td>
    </tr>
    <tr>
        <td>
            <div id="divUpper" runat="server">
                <asp:Button ID="btnUpper_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnUpper_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel11" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                       <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnUppersection" CssClass="btnUppersection" Style="display: none;"
                                        runat="server" Text="Button" OnClick="btnUppersection_Click" />
                                    <asp:GridView ID="grdUppersection" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdUppersection_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdUppersection_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationPiping" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBUpper(this,1,'Upper')"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Upper") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBUpper(this,2,'Upper')">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">upper section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField5" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingUpper" runat="server" Text="Add" OnClick="btnAddStichingUpper_Click"
                                        OnClientClick="javascript:return checkLastValUpper();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivUpper_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel27" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnUpper_add" CssClass="btnUpper_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnUpper_add_Click" />
                        <asp:GridView ID="grdUpper_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdUpper_Add" OnRowDataBound="grdUpper_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationUpper_Add" Width="98%" runat="server" CssClass="txtOperationUpper_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Upper_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Upper") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistUpper" onclick="javascript:return SaveStichingOB_Upper_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistUpper_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivUpperlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearUpper();" />
                    <asp:Button ID="btnAddUpper_add_Lists" runat="server" Text="Show List" OnClick="btnAddUpper_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <%--END--%>
    <%--for Uppershell--%>
    <tr id="trUppershell" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblUppershell" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divUppershell" runat="server">
                <asp:Button ID="btnUppershell_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnUppershell_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnUppershell" CssClass="btnUppershell" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnUppershell_Click" />
                                    <asp:GridView ID="grdUppershell" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdUppershell_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdUppershell_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="OPeration">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationPiping" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBUppershell(this,1,'Uppershell')"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Uppershell") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBUppershell(this,2,'Uppershell')">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">upper shell section
                                                            </strong>.for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField6" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--  <asp:Button ID="btnAddStichingUppershell" runat="server" Text="Add" OnClick="btnAddStichingUppershell_Click"
                                        OnClientClick="javascript:return checkLastValUppershell();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivUppershell_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel28" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnUppershell_add" CssClass="btnUppershell_adds" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnUppershell_add_Click" />
                        <asp:GridView ID="grdUppershell_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdUppershell_Add" OnRowDataBound="grdUppershell_Add_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationUppershell_Add" Width="98%" runat="server" CssClass="txtOperationUppershell_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Uppershell_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Uppershell") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistUppershell" onclick="javascript:return SaveStichingOB_Uppershell_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistUppershell_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivUppershelllist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearUppershell();" />
                    <asp:Button ID="btnAddUppershell_add_Lists" runat="server" Text="Show List" OnClick="btnAddUppershell_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    
    <%--END--%>
    <%--for Lowershell--%>
    <tr id="trLowershell" runat="server">
        <td align="center" class="head-back">
       
                        <asp:Label ID="lblbLowershell" runat="server" Text=""></asp:Label>
                  
        </td>
    </tr>
    <tr>
        <td>
            <div id="divLowershell" runat="server">
                <asp:Button ID="btnLowershell_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnLowershell_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel13" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnLowershell" CssClass="btnLowershell" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnLowershell_Click" />
                                    <asp:GridView ID="grdLowershell" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdLowershell_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdLowershell_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="98%" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationPiping" Width="250px" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBLowershell(this,1,'Lowershell')"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Lowershell") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBLowershell(this,2,'Lowershell')">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">lower shell section
                                                            </strong>.for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField7" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingLowershell" runat="server" Text="Add" OnClick="btnAddStichingLowershell_Click"
                                        OnClientClick="javascript:return checkLastValLowershell();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivLowershell_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel29" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnLowershell_add" CssClass="btnLowershell_adds" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnLowershell_add_Click" />
                        <asp:GridView ID="grdLowershell_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdLowershell_Add" OnRowDataBound="grdLowershell_Add_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationLowershell_Add" Width="98%" runat="server" CssClass="txtOperationLowershell_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Lowershell_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Lowershell") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistLowershell" onclick="javascript:return SaveStichingOB_Lowershell_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistLowershell_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivLowershelllist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearLowershell();" />
                    <asp:Button ID="btnAddLowershell_add_Lists" runat="server" Text="Show List" OnClick="btnAddLowershell_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
  
    <%--END--%>
    <%--for Shellsection--%>
    <tr id="trShellsection" runat="server">
        <td align="center" class="head-back">
  
                        <asp:Label ID="lblShellsection" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divShellsection" runat="server">
                <asp:Button ID="btnShellsection_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnShellsection_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel14" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td>
                                    <asp:Button ID="btnShellsection" CssClass="btnShellsection" Style="display: none;"
                                        runat="server" Text="Button" OnClick="btnShellsection_Click" />
                                    <asp:GridView ID="grdShellsection" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdShellsection_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdShellsection_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationPiping" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveOBShellSection(this,1,'ShellSection')"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_ShellSection") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveOBShellSection(this,2,'ShellSection')">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">shell section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField8" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingShellsection" runat="server" Text="Add" OnClick="btnAddStichingShellsection_Click"
                                        OnClientClick="javascript:return checkLastValShellSection();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivShellsection_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel30" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnShellsection_add" CssClass="btnShellsection_adds" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnShellsection_add_Click" />
                        <asp:GridView ID="grdShellsection_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdShellsection_Add" OnRowDataBound="grdShellsection_Add_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationShellsection_Add" Width="98%" runat="server" CssClass="txtOperationShellsection_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Shellsection_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Shellsection") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistShellsection" onclick="javascript:return SaveStichingOB_Shellsection_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistShellsection_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivShellsectionlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearShellsection();" />
                    <asp:Button ID="btnAddShellsection_add_Lists" runat="server" Text="Show List" OnClick="btnAddShellsection_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
     
    <%--END--%>
    <%--for Waist section--%>
    <tr id="trWaistSection" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblWaistSection" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divWaistSection" runat="server">
                <asp:Button ID="btnWaistSection_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnWaistSection_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnWaistSection" CssClass="btnWaistSection" Style="display: none;"
                                        runat="server" Text="Button" OnClick="btnWaistSection_Click" />
                                    <asp:GridView ID="grdWaistSection" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdWaistSection_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdWaistSection_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationPiping" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBWaistSection(this,1,'WaistSection')"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_WaistSection") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBWaistSection(this,2,'WaistSection')">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">waist section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField9" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--<asp:Button ID="btnAddStichingWaistSection" runat="server" Text="Add" OnClick="btnAddStichingWaistSection_Click"
                                        OnClientClick="javascript:return checkLastValWaistSection();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivWaistSection_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel31" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnWaistSection_add" CssClass="btnWaistSection_adds" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnWaistSection_add_Click" />
                        <asp:GridView ID="grdWaistSection_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdWaistSection_Add" OnRowDataBound="grdWaistSection_Add_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationWaistSection_Add" Width="98%" runat="server" CssClass="txtOperationWaistSection_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_WaistSection_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_WaistSection") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistWaistSection" onclick="javascript:return SaveStichingOB_WaistSection_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistWaistSection_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivWaistSectionlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearWaistSection();" />
                    <asp:Button ID="btnAddWaistSection_add_Lists" runat="server" Text="Show List" OnClick="btnAddWaistSection_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    
    <%--END--%>
    <%--for Band section--%>
    <tr id="trBandsection" runat="server">
        <td align="center" class="head-back">
          
                        <asp:Label ID="lblBandsection" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divBandsection" runat="server">
                <asp:Button ID="btnBandsection_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnBandsection_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel16" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnBandsection" CssClass="btnBandsection" Style="display: none;"
                                        runat="server" Text="Button" OnClick="btnBandsection_Click" />
                                    <asp:GridView ID="grdBandsection" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdBandsection_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdBandsection_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperationPiping" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveStichingOBBandsection(this,1,'Bandsection')"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_BandSection") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveStichingOBBandsection(this,2,'Bandsection')">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">band section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField10" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%--<asp:Button ID="btnAddStichingBandsection" runat="server" Text="Add" OnClick="btnAddStichingBandsection_Click"
                                        OnClientClick="javascript:return checkLastValBandsection();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="DivBandsection_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel32" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnBandsection_add" CssClass="btnBandsection_adds" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnBandsection_add_Click" />
                        <asp:GridView ID="grdBandsection_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdBandsection_Add" OnRowDataBound="grdBandsection_Add_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationBandsection_Add" Width="98%" runat="server" CssClass="txtOperationBandsection_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_Bandsection_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Bandsection") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistBandsection" onclick="javascript:return SaveStichingOB_Bandsection_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="120PX" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistBandsection_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="DivBandsectionlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearBandsection();" />
                    <asp:Button ID="btnAddBandsection_add_Lists" runat="server" Text="Show List" OnClick="btnAddBandsection_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <%--END--%>
    <%--abhishek 24/10/2015--%>
  
    <tr id="trFinishing" runat="server">
        <td align="center" class="head-back">
           
                        Finishing:
                        <asp:Label ID="lblfinshing" runat="server" Text=""></asp:Label>
                  
        </td>
    </tr>
    <%--end by abhishek on 24/10/2015--%>
    <%-----------------------Finishing------------------------------%>
    <tr>
        <td>
            <div id="divFinishing" runat="server">
                <asp:UpdatePanel ID="UpdatePanel17" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" class="stitching-head" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnFinishing" CssClass="btnFinishing" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnFinishing_Click" />
                                    <asp:GridView ID="grdFinishingOB" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdFinishingOB_RowDataBound" ShowHeader="true" HeaderStyle-CssClass="head-back">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperation" Width="98%" CssClass="Getval" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return SaveFinishingOB(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("OperationFinishing") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="chkMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveFinishingOB(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">finishing section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdnCuttingOB" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Button ID="btnAddFinishing" runat="server" Text="Add" OnClick="btnAddFinishing_Click"
                                        OnClientClick="javascript:return checkLastVal();" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </td>
    </tr>
    <%--added abhishek on 3/9/2015----------------------------------------------------------------------------------------------------------------------------%>
    <%--for neck Section--%>
   
    <tr id="trNecksection" runat="server">
        <td align="center" class="head-back">
           
                        <asp:Label ID="lblnecksection" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="divNnecksection" runat="server">
                <asp:Button ID="btnnecksection_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnnecksection_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel19" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnnecksection" CssClass="btnnecksection" Style="display: none;"
                                        runat="server" Text="Button" OnClick="btnnecksection_Click" />
                                    <asp:GridView ID="grdnecksection" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdnecksection_RowDataBound" ShowHeader="true"  AllowPaging="true" PageSize="30" OnPageIndexChanging="grdnecksection_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperation" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return Save_necksection_OBFront(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_NewNeck") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="listStichingFront" onclick="javascript:return Save_necksection_OBFront(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="tdMachine" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">neck section </strong>
                                                            .for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField11" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingNeckSection" runat="server" Text="Add" OnClick="btnAddStichingNeckSection_Click"
                                        OnClientClick="javascript:return checkLastValNeck_Section_neck();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="Divnecksection_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel33" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnnecksection_add" CssClass="btnnecksection_adds" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnnecksection_add_Click" />
                        <asp:GridView ID="grdnecksection_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdnecksection_Add" OnRowDataBound="grdnecksection_Add_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationnecksection_Add" Width="98%" runat="server" CssClass="txtOperationnecksection_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_necksection_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_NewNeck") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistnecksection" onclick="javascript:return SaveStichingOB_necksection_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistnecksection_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="Divnecksectionlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearnecksection();" />
                    <asp:Button ID="btnAddnecksection_add_Lists" runat="server" Text="Show List" OnClick="btnAddnecksection_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
  
    <%--neck end --%>
    <%--for Neck facing Section--%>
    <tr id="trneckfacing" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblneckfaching" runat="server" Text=""></asp:Label>
                   
        </td>
    </tr>
    <tr>
        <td>
            <div id="Divneckfaching" runat="server">
                <asp:Button ID="btnneckfaching_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnneckfaching_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel20" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                       <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="btnneckfaching" CssClass="btnneckfaching" Style="display: none;"
                                        runat="server" Text="Button" OnClick="btnneckfaching_Click" />
                                    <asp:GridView ID="grdneckfaching" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdneckfaching_RowDataBound" ShowHeader="true"  AllowPaging="true" PageSize="30" OnPageIndexChanging="grdneckfaching_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperation" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return Save_neck_faching_OBFront(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Neckfacing") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="listStichingFront" onclick="javascript:return Save_neck_faching_OBFront(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="tdMachine" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <emptydatatemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                       <h3>There are no records available in <strong style="color:Red"> neck facing section </strong>.for your search</h3> 
                                                    </td>
                                                </tr>
                                            </table>
                                        </emptydatatemplate>
                                    </asp:GridView>
                                    
                                    <asp:HiddenField ID="HiddenField12" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnAddStichingNecFaching" runat="server" Text="Add" OnClick="btnAddStichingNecFaching_Click"
                                        OnClientClick="javascript:return checkLastValNeckfaching();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="Divneckfaching_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel34" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnneckfaching_add" CssClass="btnneckfaching_adds" Style="display: none;"
                            runat="server" Text="Button" OnClick="btnneckfaching_add_Click" />
                        <asp:GridView ID="grdneckfaching_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdneckfaching_Add" OnRowDataBound="grdneckfaching_Add_RowDataBound"
                            ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationneckfaching_Add" Width="98%" runat="server" CssClass="txtOperationneckfaching_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_neckfaching_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Neckfacing") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistneckfaching" onclick="javascript:return SaveStichingOB_neckfaching_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistneckfaching_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="Divneckfachinglist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearneckfaching();" />
                    <asp:Button ID="btnAddneckfaching_add_Lists" runat="server" Text="Show List" OnClick="btnAddneckfaching_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <%--neck faching section here --%>
    <%--    Front & back section--%>
    
    <tr id="trf_back" runat="server">
        <td align="center" class="head-back">
            
                        <asp:Label ID="lblf_back" runat="server" Text=""></asp:Label>
                  
        </td>
    </tr>
    <tr>
        <td>
            <div id="divf_back" runat="server">
                <asp:Button ID="btnf_back_up_Add" runat="server" CssClass="CssbtnAddNew" Text="Add New"
                    OnClick="btnf_back_up_Add_Click" />
                <asp:UpdatePanel ID="UpdatePanel21" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="3" bgcolor="#ffffff">
                            <tr>
                                <td>
                                    <asp:Button ID="brnf_back" CssClass="brnf_back" Style="display: none;" runat="server"
                                        Text="Button" OnClick="brnf_back_Click" />
                                    <asp:GridView ID="grdf_back" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowDataBound="grdf_back_RowDataBound" ShowHeader="true" AllowPaging="true" PageSize="30" OnPageIndexChanging="grdf_back_PageIndexChanging" HeaderStyle-CssClass="head-back">
                                        <PagerSettings 
                                             Position="TopAndBottom" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOperation" Width="98%" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                        onchange="javascript:return Save_neck_faching_frontback(this,1)"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Frontback") %>' />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine/Manual">
                                                <ItemTemplate>
                                                    <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                                        SelectionMode="Multiple" CssClass="listStichingFront" onclick="javascript:return Save_neck_faching_frontback(this,2)">
                                                    </asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="tdMachine" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Selected Machine/Manual">
                                                <HeaderStyle />
                                                <ItemTemplate>
                                                    <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                                        TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox"></asp:ListBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 40px; text-align: center">
                                                        <h3>
                                                            There are no records available in <strong style="color: Red">front & back section
                                                            </strong>.for your search</h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField13" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <asp:Button ID="btnaddf_back" runat="server" Text="Add" OnClick="btnaddf_back_Click"
                                        OnClientClick="javascript:return checkLastValNeckfachingfrontback();" />--%>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="Divf_back_Add" runat="server">
                <asp:UpdatePanel ID="UpdatePanel35" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnf_back_add" CssClass="btnf_back_adds" Style="display: none;" runat="server"
                            Text="Button" OnClick="btnf_back_add_Click" />
                        <asp:GridView ID="grdf_back_Add" runat="server" Width="100%" AutoGenerateColumns="false"
                            CssClass="grdf_back_Add" OnRowDataBound="grdf_back_Add_RowDataBound" ShowHeader="true" BackColor="#ffffff" HeaderStyle-CssClass="head-back">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOperationf_back_Add" Width="98%" runat="server" CssClass="txtOperationf_back_Add"
                                            Text='<%#Eval("FactoryWorkSpace") %>' onchange="javascript:return SaveStichingOB_f_back_Add(this,1)"></asp:TextBox>
                                        <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationstitching_Frontback") %>' />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine/Manual">
                                    <ItemTemplate>
                                        <asp:ListBox ID="ListMachine" runat="server" Width="120" Height="50" TextAlign="Right"
                                            SelectionMode="Multiple" CssClass="checkbox csslistf_back" onclick="javascript:return SaveStichingOB_f_back_Add(this,2)">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selected Machine/Manual">
                                    <HeaderStyle />
                                    <ItemTemplate>
                                        <asp:ListBox ID="lstMachine" runat="server" Enabled="false" Width="98%" Height="50"
                                            TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox csslistf_back_clear">
                                        </asp:ListBox>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="Divf_backlist_Add" runat="server">
                    <input type="button" name="Add" title="Add New" value="Add" onclick="javascript:return checkClearf_back();" />
                    <asp:Button ID="btnAddf_back_add_Lists" runat="server" Text="Show List" OnClick="btnAddf_back_add_Lists_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td align="center">
            <img width="20px" title="Go to top" class="topcss" id="scrlTop" src="../../App_Themes/ikandi/images/arrow_up.png"
                alt="go to top" />
        </td>
        <%--<td>
        <img src="../../App_Themes/ikandi/images/wait1.gif"  class="busy" alt="" style="position: fixed;  
                                        z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </td>--%>
    </tr>
    <%--end Front & back section--%>
    <%--end ---------------------------------------------------------------------------------------------------------------------%>
</table>
