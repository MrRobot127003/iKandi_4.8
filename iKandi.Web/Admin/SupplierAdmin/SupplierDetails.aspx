<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="SupplierDetails.aspx.cs" Inherits="iKandi.Web.Admin.SupplierAdmin.SupplierDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src="../../js/form.js"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: verdana !important;
        }  
         .item_list TD .AddClassSup_Table
         {
             width:100%;
          }
           .item_list th .AddClassSup_Table th
        {
            border: 0px;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
        }
      .item_list th.SupllierTD
        {
            padding:0px !important;
         }
         .item_list th .AddClassSup_Table th:first-child 
        {
                border-left: 0px;
                border-top: 0px;
                border-bottom: 0px;
                width:125px;
                height:31px;
                border-right:1px solid #999 !important;
         }
         .item_list th .AddClassSup_Table th:last-child 
        {
                border-right: 0px;
                border-top: 0px;
                width:125px;
                border-bottom: 0px;
         }
       .item_list TD .AddClassSup_Table td
        {
            border: 1px solid #dbd8d8;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
            border-bottom: 0px;
        } 
      .item_list TD .AddClassSup_Table tr:first-child>td
      {
         border-top: 0px;  
       
       } 
      .item_list TD .AddClassSup_Table td:first-child
      {
         border-left: 0px;  
         width:125px;
       }   
        .item_list TD .AddClassSup_Table td:last-child
      {
          width:125px;
         border-right: 0px;  
       } 
          .item_list TD .AddClassSup_Table tr:last-child>td
      {
         border-bottom: 0px;  
       } 
       .item_list td.SupllierTD
       {
           padding:0px !important;
        }   
        table
        {
            font-family: verdana;
            border-color: gray;
            border-collapse: collapse;
        }        
        th
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: arial, halvetica;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border-color:#8e8c8c !important;
        }
      
        table td
        {
            font-size: 11px;
            text-align: center;
            border-color: #dbd8d8;
            text-transform: capitalize;
            color: gray;
        }
       
        td
        {
            border-color: #dbd8d8;
        }        
        .per
        {
            color: blue;
        }        
        .gray
        {
            color: gray;
        }        
        h2
        {
            width: 800px;
        }        
        h3
        {
            width: 300px;
            border-radius: 5px 5px 0px 0px;
        }        
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }        
        table td table td
        {
            border-color: #dbd8d8;
        }        
        .SUPPLY-MANA td input
        {
            width: 14%;
        }
        .item_list.SUPPLY-MANA td
        {
            padding:2px 0px !important;
        }        
        .imageField
        {
            background-image: url(submit.jpg);
            height: 28px;
            width: 105px;
        }        
        .process
        {
            padding: 0px;
            margin: 0px;
            -webkit-column-count: 3;
            -moz-column-count: 3;
            column-count: 3;
        }        
        .process li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid #dbd8d8;
            text-transform: capitalize;
        }        
        .process li input
        {
            width: 10%;
        }        
        .supply_type
        {
            padding: 0px;
            margin: 0px;
        }        
        .supply_type li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid #d0caca;
            text-transform: capitalize;
        }        
        .process li:last-child
        {
            border-bottom: 0px;
        }        
        input[type="text"], select
        {
            width: 95% !important;
            color: gray !important;
            border: 1px solid #dbd8d8 !important;
        }        
        .pad
        {
            text-align: left;
            padding-left: 25px;
        }        
        .ths
        {
            background: #3b5998;
            font-weight: normal;
            color: #fff;
            font-family: arial, halvetica;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
        }        
        .align_left
        {
            text-align: left !important;
        }
        .item_list TD
        {
            background: inherit;
        }
        label
        {
            position: relative;
            top: -2px;
        }      
        span.check
        {
            position: relative;
            top: 0px;
        }
        input[type="checkbox"]
        {
            cursor: pointer;
        }
        .submit
        {
            cursor:pointer;
        }
        .upladtable
        {
                border: 1px solid #999;
                margin-top: 10px;
                margin-bottom: 10px;
        }
       select[disabled='disabled']
       {
           background:#e4dfdf;
           cursor: no-drop;
        }
         table tr:nth-last-child(1)>td {
          border-bottom-color:#999;
        }
        @-moz-document url-prefix() {
        .fireboxcs {
           min-height:unset !important;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            debugger;
            InitialCodeGenrate();
       
            if ($('#ctl00_cph_main_content_ddlgrouptype').val() == '1') {

                $('#ctl00_cph_main_content_ddlDeliveryType').attr('disabled', false);
            }


        });   

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);


        $(function () {
            //debugger;
            var chks = $("#ctl00_cph_main_content_grdcontactDetails input[type=checkbox]");
            chks.on("change", function () {

                if (this.checked) { //console.log(this.checked);
                    var me = this;
                    chks.each(function (i) { //console.log(me.id);
                        if (me.id !== this.id) { //console.log(i.id);
                            $(this).prop("checked", false);
                        }
                    });
                }
            });
        });
        function InitialCodeGenrate() {
            debugger;
            var Code = '';
            var hdnsupplierInitinal = '<%=hdnsupplierInitinal.ClientID %>';
            var txtgroupcode = '<%=txtgroupcode.ClientID %>';
            var txtsuppliarIntial = '<%=txtsuppliarIntial.ClientID %>';
            var ddlgrouptypeClient = '<%=ddlgrouptype.ClientID %>';
            var SupplierType = $("#" + ddlgrouptypeClient, '#main_content').val();
            //var hdnsupplierInitinalco = $("#" + hdnsupplierInitinal).val();
            var SupplierMasterId = $("#" + '<%=hdnSupplieMasterID.ClientID %>', '#main_content').val();
            if (SupplierMasterId > 0) {
                return false;
            }

            var SuplierIntialCode = $("#" + txtgroupcode).val().split(' ');
            var arrayLength = SuplierIntialCode.length;

            if (arrayLength == 1) {
                if (SuplierIntialCode[0].substr(0, 2)!="&")
                Code = SuplierIntialCode[0].substr(0, 2);
            } else {
                for (var i = 0; i < arrayLength; i++) {
                    if (SuplierIntialCode[i].substr(0, 1)!="&")
                    Code += SuplierIntialCode[i].substr(0, 1);
                }
            }
            var SupplierName = $("#" + txtgroupcode).val();
            proxy.invoke("GetSupplierCode", { Flag: 8, SupplierName: Code, Type: SupplierType },
            function (result) {
                //debugger;
                if (result == '') {
                    $("#" + txtsuppliarIntial).val(Code.toUpperCase());
                    $("#" + hdnsupplierInitinal).val(Code.toUpperCase());
                }
                else {
                    $("#" + txtsuppliarIntial).val(result.toUpperCase());
                    $("#" + hdnsupplierInitinal).val(result.toUpperCase());
                }
            });
        }

        function showalert(str) {
            alert(str);
            return;
        }

        function myFunction() {
            alert("Saved successfully.");
        }

        function DisableButton() {
            document.getElementById("<%=btnsubmit.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;

        function ValidateDuplicateContact() {

            var SiplitIds = elem.id.split("_");
            var rowid = SiplitIds[1];

            var totalRows = $("#<%=grdcontactDetails.ClientID %> tr").length;

            if (parseInt(SizeCount) > 0) {
                for (var i = 0; i <= parseInt(SizeCount); i++) {
                    var Finalprice = 0;
                    var txtprice = $("#" + "grdsizedynamic_" + rowid + "_textBoxprice_" + i).val();
                    if (txtprice == "") {
                        txtprice = parseFloat(txtprice);
                    }
                    var shrinkPer = ((((parseFloat(txtprice) * parseFloat(Shrinkage)) / parseFloat(100))) + parseFloat(txtprice));
                    var Totalwastageper = (parseFloat(txtprice) + ((parseFloat(shrinkPer) * parseFloat(Wastage)) / parseFloat(100)));
                    var FinalPrice = Math.round(Totalwastageper);
                    if (FinalPrice > 0) {
                        $("#" + "grdsizedynamic_" + rowid + "_textBoxFinalprice_" + i).val(FinalPrice);
                    } else {
                        $("#" + "grdsizedynamic_" + rowid + "_textBoxFinalprice_" + i).val("");
                    }
                }
            }

        }

        function chkSelection(obj, FieldName, rowType) {
            //debugger;
            //alert(obj.id);
            if (FieldName == 'Email') {
                validateEmail(obj);
            }
            var currListValue = obj.value;
            var arrSelect = new Array();
            arrSelectperson = document.getElementsByClassName('SuppCheckperson');
            arrSelectemail = document.getElementsByClassName('SuppCheckemail');

            var rowid = obj.id.split("_")[5];
            var id = obj.id.split("_")[6];

            var EmanilContact = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemail").value;
            var Name = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactperson").value;
            var chkCtr = 0;
            var rowids = ""

            for (var i = 0; i < arrSelectperson.length - 1; i++) {
                var rowids = arrSelectperson.item(i).id.split("_")[5];
                var EmanilContactloop = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowids + "_" + "txtemail").value;
                var Nameloop = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowids + "_" + "txtcontactperson").value;

                if ((Nameloop.toLowerCase().trim() == Nameloop.toLowerCase().trim()) && (EmanilContactloop.toLowerCase().trim() == EmanilContact.toLowerCase().trim())) {
                    chkCtr = chkCtr + 1;
                    if (chkCtr > 1) {

                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowids + "_" + "txtemail").value = "";
                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowids + "_" + "txtcontactperson").value = "";
                    }
                }

                if (chkCtr > 1) {
                    alert('Duplicate Contact Person and Email not allowed.!');
                }
            }
        }

        function ValidateRow(obj, rowType) {
            debugger;
            if (rowType == 'Empty') {
                var rowid = obj.id.split("_")[5];

                var ContactPerson = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactpersonEmpty").value;
                var Email = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailEnpty").value;
                if (ContactPerson == '') {
                    alert('Contact Person field can not be empty!');
                    document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactpersonEmpty").focus();
                    return false;
                }
                if (Email == '') {
                    alert('Email field can not be empty!');
                    document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailEnpty").focus();
                    return false;
                }
            }
        }

        function isNumberKeyfloat(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            return true;
        }

        function ClientCheck() {
            debugger;
            if ($('#ctl00_cph_main_content_txtGstNo').val() == '') {
                alert("Please Enter GST No. as it is Mandatory.");
                return false;
            }
            else if ($('#ctl00_cph_main_content_grdcontactDetails input:checked').length < 1) {
                alert("Invalid. Please select a checkbox to continue as client login.");
                return false;
            }
            else if ($('#ctl00_cph_main_content_ddlDeliveryType').val() == '0' && $('#ctl00_cph_main_content_ddlgrouptype').val() !='2' ) {
                alert("Please Select Delivery Type.");
                return false;
            }

            else {
                if ($('#ctl00_cph_main_content_txtsuppliarIntial').is(':disabled')) {
                    debugger;
                    $('#ctl00_cph_main_content_txtsuppliarIntial').attr('disabled', false);
                   
                 }
            }
        }

        function ValidateContractDetails(obj, type) {
            debugger;
            if ($(obj).is(':checked')) {
                if (type == 'Empty') {
                    var rowid = obj.id.split("_")[5];
                    var ContractPerson = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactpersonEmpty").value;
                    if (ContractPerson == '') {
                        alert("Please enter Contract Person name.");
                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactpersonEmpty").focus();
                        $(obj).removeAttr("checked");
                        return false;
                    }
                    var Email = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailEnpty").value;
                    if (Email == '') {
                        alert("Please enter Email.");
                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailEnpty").focus();
                        $(obj).removeAttr("checked");
                        return false;
                    }
                }
                if (type == 'Row') {
                    var rowid = obj.id.split("_")[5];
                    var ContractPerson = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactperson").value;
                    if (ContractPerson == '') {
                        alert("Please enter Contract Person name.");
                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactperson").focus();
                        $(obj).removeAttr("checked");
                        return false;
                    }
                    var Email = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemail").value;
                    if (Email == '') {
                        alert("Please enter Email.");
                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemail").focus();
                        $(obj).removeAttr("checked");
                        return false;
                    }
                }
                if (type == 'Footer') {
                    var rowid = obj.id.split("_")[5];
                    var ContractPerson = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactpersonFooter").value;
                    if (ContractPerson == '') {
                        alert("Please enter Contract Person name.");
                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtcontactpersonFooter").focus();
                        $(obj).removeAttr("checked");
                        return false;
                    }
                    var Email = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailfoter").value;
                    if (Email == '') {
                        alert("Please enter Email.");
                        document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailfoter").focus();
                        $(obj).removeAttr("checked");
                        return false;
                    }
                }
            }
        }

        function onlyAlphabets(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
                return false;
            return true;
        }

        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false) {
                alert('Invalid Email Address');
                emailField.value = "";
                return false;
            }
        }
        $(document).ready(function () {
            //  alert();
            $('.grdvatable td[rowspan]:last').each(function () {
                $(this).addClass('border_bottom_color');
            });
        });


        //Added code By Bharat on 25-Aug
        function SupplerInitialCodeValidate() {
              debugger;
            var txtsuppliarIntial = '<%=txtsuppliarIntial.ClientID %>';
            var SuplierIntialCode = $("#" + txtsuppliarIntial).val();
            var arrayLength = SuplierIntialCode.length;
            var SupplierCode = SuplierIntialCode;
            var hdnsupplierInitinal = '<%=hdnsupplierInitinal.ClientID %>';
            var hdnval = $("#" + hdnsupplierInitinal).val();
            var SupplierId = $("#ctl00_cph_main_content_hdnSupplieMasterID").val();
            var Flag = 1;
            proxy.invoke("SupplierCodeValidate", { Flag: Flag, SupplierCode: SupplierCode, SupplierId: SupplierId },
            function (result) {
                //debugger;
                if (result == '') {
                    alert(Succuss);
                }
                else {
                    alert('Duplicate Supplier Code');
                    $("#" + txtsuppliarIntial).val('')
                    $("#" + txtsuppliarIntial).val(hdnval)
                }
            });

        }
        function SupplerEmailValidateFun(obj, RowType) {
            debugger;
            var rowid = obj.id.split("_")[5];

            if (RowType == 'Empty') {
                var SupplierEmail = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailEnpty").value;
                var grdsupId = 0;
            }
            if (RowType == "Footer") {
                var SupplierEmail = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailfoter").value;
                var grdsupId = $("#" + "ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "hdnAutoincretmentfoter").val();
            }
            if (RowType == "Email") {
                var SupplierEmail = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemail").value;
                var grdsupId = $("#" + "ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "hdnsupid").val();
                var hdnContactEmail = $("#" + "ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "hdnContactEmail").val();
            }
            var Flag = 2;
            proxy.invoke("SupplierEmailValidate", { Flag: Flag, SupplierEmail: SupplierEmail, grdsupId: grdsupId },
            function (result) {
                debugger;
                if (result == '') {
                    // alert(Succuss);
                }
                else {
                    alert('Duplicate Email');
                    if (RowType == 'Empty') {
                        var SupplierEmail = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailEnpty").value = "";
                    }
                    if (RowType == "Footer") {
                        var SupplierEmail = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemailfoter").value = "";
                    }
                    if (RowType == "Email") {
                        var SupplierEmail = document.getElementById("ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemail").value = "";
                        $("#" + "ctl00_cph_main_content_grdcontactDetails_" + rowid + "_" + "txtemail").val(hdnContactEmail);
                    }

                }
            });

        }
        //End
    </script>
    <asp:HiddenField ID="hdnSupplierName" runat="server" Value="" />
    <asp:HiddenField ID="hdnSupplierEmail" runat="server" Value="" />
    <span style="color: #fff; text-align: left; font-size: 11px; position: absolute; top: 3px; left: 10px;">All<span style="color: red">*</span> mark field mandatory </span>
    <h2 style="border: 1px solid gray">
        Supplier Admin</h2>
    <asp:PlaceHolder ID="pnledit" runat="server">
        <h3>
            Basic Details</h3>
        <table cellspacing="0" cellpadding="0" style="width: 800px; border-color: #999; border-left: 0px; border-right: 0px; border-bottom: 0px;" border="1" class="item_list">
            <tr>
                <th>
                    Type
                </th>
                <th>
                    <span style="color: Red; text-align: left; font-size: 12px;">*</span>Supplier Name
                </th>
                <th>
                    <span style="color: Red; text-align: left; font-size: 12px;">*</span>Supplier Initials
                </th>
                <th>
                    <span style="color: Red; text-align: left; font-size: 12px;">*</span>GST No.
                </th>
                <th>
                    Address
                </th>
                <th>
                    Payment terms days
                </th>
                <th>
                    Grade
                </th>
                <th>
                    <span style="color: Red; text-align: left; font-size: 12px;">*</span>Delivery Type
                </th>
            </tr>
            <tr>
                <td style="width: 80px" class="border_left_color">
                    <asp:DropDownList ID="ddlgrouptype" AutoPostBack="true" OnSelectedIndexChanged="ddlgrouptype_SelectedIndexChanged" runat="server">
                        <asp:ListItem Value="2">Accessories</asp:ListItem>
                        <asp:ListItem Value="1">Fabrics</asp:ListItem>
                        <asp:ListItem Value="3">Value Addition</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hdnSupplieMasterID" Value="0" runat="server" />
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtgroupcode" MaxLength="50" autocomplete="off" onblur="javascript:InitialCodeGenrate();" Style="text-transform: capitalize;" runat="server" OnTextChanged="txtgroupcode_TextChanged1"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="None" ID="rqdgroupcode" ValidationGroup="submits" runat="server" ControlToValidate="txtgroupcode" ErrorMessage="Enter supplier name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 50px">
                    <asp:TextBox ID="txtsuppliarIntial" autocomplete="off" onblur="javascript:SupplerInitialCodeValidate();" onpaste="return false;" Style="text-transform: uppercase;" runat="server" disabled ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rdqsuppliarIntial" ValidationGroup="submits" runat="server" Display="None" ControlToValidate="txtsuppliarIntial" ErrorMessage="Enter supplier Initials details" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hdnsupplierInitinal" runat="server" />
                </td>
                <td style="width: 150px">
                    <asp:TextBox ID="txtGstNo" MaxLength="350" autocomplete="off" runat="server"></asp:TextBox>
                </td>
                <td style="width: 150px">
                    <asp:TextBox ID="txtaddress" MaxLength="350" autocomplete="off" runat="server"></asp:TextBox>
                </td>
                <td style="width: 50px">
                    <asp:TextBox ID="txtpaymentdays" onkeypress="return isNumberKeyfloat(event)" autocomplete="off" MaxLength="3" runat="server"></asp:TextBox>
                </td>
                <td style="width: 50px" class="border_right_color">
                    <asp:TextBox ID="txtgrade" autocomplete="off" MaxLength="2" runat="server"></asp:TextBox>
                </td>
                <td style="width: 80px;" class="border_left_color">
                    <asp:DropDownList ID="ddlDeliveryType" runat="server" Enabled="False" >
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">Landed</asp:ListItem>
                        <asp:ListItem Value="2">Ex-Mill</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <h3 style="margin-top: 10px;">
            Contact Details</h3>
        <asp:GridView ID="grdcontactDetails" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="800px" ShowFooter="True" OnRowDeleting="grdcontactDetails_RowDeleting" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdcontactDetails_RowCommand" OnRowDataBound="grdcontactDetails_RowDataBound" CssClass="item_list" rules="all" HeaderStyle-CssClass="ths">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <span style="color: Red; text-align: left; font-size: 12px;">*</span>Contact Person
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtcontactperson" onchange="chkSelection(this,'','Row')" onkeypress="return onlyAlphabets(event);" CssClass="SuppCheckperson" autocomplete="off" MaxLength="50" ToolTip="Person contact" Style="text-transform: capitalize;" Text='<%#Eval("ContactPerson")%>' runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hdsupplier_Details_Id" runat="server" />
                        <asp:HiddenField ID="hdnAutoincretment" Value='<%# ((GridViewRow)Container).RowIndex + 1%>' runat="server" />
                        <asp:HiddenField ID="hdnsupid" Value='<%#Eval("supplier_Details_Id")%>' runat="server" />
                        <asp:RequiredFieldValidator ID="rqdcontactperson" ValidationGroup="submits" runat="server" Display="None" ControlToValidate="txtcontactperson" ErrorMessage="Enter person contact." ForeColor="Red"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                    <ItemStyle Width="100px" CssClass="border_left_color" />
                    <FooterTemplate>
                        <asp:TextBox ID="txtcontactpersonFooter" CssClass="SuppCheckperson" onkeypress="return onlyAlphabets(event);" autocomplete="off" MaxLength="50" Style="text-transform: capitalize;" ToolTip="Persone contact" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hdnAutoincretmentfoter" Value='<%# ((GridViewRow)Container).RowIndex + 1%>' runat="server" />
                    </FooterTemplate>
                    <FooterStyle CssClass="border_left_color" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <span style="color: Red; text-align: left; font-size: 12px;">*</span>Email
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtemail" onchange="chkSelection(this,'Email','Rows')" MaxLength="50" CssClass="SuppCheckemail" autocomplete="off" onblur="javascript:SupplerEmailValidateFun(this,'Email');" Width="" Style="text-transform: capitalize;" ToolTip="Email" Text='<%#Eval("Email")%>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqdemail" ValidationGroup="submits" runat="server" Display="None" ControlToValidate="txtemail" ErrorMessage="Enter email." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="hdnContactEmail" Value='<%#Eval("Email")%>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                    <FooterTemplate>
                        <asp:TextBox ID="txtemailfoter" CssClass="SuppCheckemail" onchange="javascript:return validateEmail(this)" autocomplete="off" Style="text-transform: capitalize;" onblur="javascript:SupplerEmailValidateFun(this,'Footer');" ToolTip="Email" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone No.">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPhoneNo" autocomplete="off" ToolTip="Phone no" MaxLength="15" onkeypress="return isNumberKeyfloat(event)" Text='<%#Eval("PhoneNo")%>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="100px" VerticalAlign="top" />
                    <FooterTemplate>
                        <asp:TextBox ID="txtPhoneNoFooter" autocomplete="off" MaxLength="12" ToolTip="Phone no" onkeypress="return isNumberKeyfloat(event)" runat="server" class="numeric-field-without-decimal-places"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRemarks" autocomplete="off" ToolTip="Reamrks" Style="text-transform: capitalize;" Text='<%#Eval("Remarks")%>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="250px" VerticalAlign="top" />
                    <FooterTemplate>
                        <asp:TextBox ID="txtRemarksFooter" autocomplete="off" ToolTip="Reamrks" Style="text-transform: capitalize;" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Use as Login">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkUserloginItem" onclick="ValidateContractDetails(this, 'Row')" Checked='<%# Convert.ToBoolean(Eval("IsUserLogin").ToString() == "" ? "false" : Eval("IsUserLogin").ToString()) %>' class="check" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="100px" VerticalAlign="top" />
                    <FooterTemplate>
                        <asp:CheckBox ID="chkUserlogfoter" onclick="ValidateContractDetails(this, 'Footer')"  class="check" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HiddenField ID="IsActive" runat="server" />
                        <%-- <asp:DropDownList runat="server" ID="IsActive" />--%>
                        <div style="text-align: center;" class="iSlnkHide">
                            <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="50px" VerticalAlign="top" CssClass="border_right_color" />
                    <FooterTemplate>
                        <div style="text-align: center;" class="iSlnkHide">
                            <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                        </div>
                    </FooterTemplate>
                    <FooterStyle CssClass="border_right_color" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table border="1" cellpadding="0" cellspacing="0" width="100%" class="item_list" style="border-color: #999; border-left: 0px; border-right: 0; border-bottom: 0px;">
                    <tr>
                        <th width="100px">
                            <span style="color: Red; text-align: left; font-size: 12px;">*</span>Contact Person
                        </th>
                        <th width="150px">
                            <span style="color: Red; text-align: left; font-size: 12px;">*</span>Email
                        </th>
                        <th width="100px">
                            Phone No.
                        </th>
                        <th width="250px">
                            Remarks
                        </th>
                        <th width="1px">
                            Use as Login
                        </th>
                        <th width="1px">
                            Action
                        </th>
                    </tr>
                    <tr style="text-align: center;">
                        <td class="border_left_color ">
                            <asp:TextBox ID="txtcontactpersonEmpty" autocomplete="off" MaxLength="50" Style="text-transform: capitalize;" onkeypress="return onlyAlphabets(event);" ToolTip="Persone contact" CssClass="numeric" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtemailEnpty" autocomplete="off" ToolTip="Email" Style="text-transform: capitalize;" onchange="javascript:return validateEmail(this)" onblur="javascript:SupplerEmailValidateFun(this,'Empty');" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtphonenoEmpty" autocomplete="off" MaxLength="15" onkeypress="return isNumberKeyfloat(event)" ToolTip="Phone no" CssClass="numeric" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarksEnpty" autocomplete="off" Style="text-transform: capitalize;" ToolTip="Remarks" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkUserLoginEmpty" onclick="ValidateContractDetails(this, 'Empty')" class="check" runat="server" />
                        </td>
                        <td width="50px" class="border_right_color">
                            <asp:LinkButton ForeColor="black" ToolTip="Insert New Record" ID="addbutton" runat="server" OnClientClick="javascript:return ValidateRow(this, 'Empty')" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <div class="fabricdiv" runat="server" id="divtypes" style="margin-top: 10px;">
            <h3>
                <span runat="server" id="spanSupplyType" style="color: Red; text-align: left; font-size: 12px;">*</span>Supplier &amp;
                <asp:Label ID="lblsuppliercatagory" runat="server"></asp:Label>
                Details</h3>
            <table cellspacing="0" cellpadding="0" style="width: 90%; border-color: #999; border-left: 0px; border-right: 0px; border-bottom: 0px;" border="1" class="SUPPLY-MANA item_list">
                <tr>
                    <th width="150px">
                        Supply Type
                    </th>
                    <th width="200px">
                        <span runat="server" id="span1" style="color: Red; text-align: left; font-size: 12px;">*</span><asp:Label ID="lblsuppliercatagory2" runat="server"></asp:Label>
                        category
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="top" class="border_left_color">
                        <ul class="supply_type">
                            <asp:Repeater ID="RepeaterSupplierType" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <asp:CheckBox ID="chkSupplierType" runat="server" />
                                        <asp:Label ID="lblvanameSupplierType" Text='<%#Eval("Name")%>' runat="server" Style="position: relative; top: -2px"></asp:Label>
                                        <asp:HiddenField ID="hdnVaidSupplierType" runat="server" Value='<%#Eval("SupplierType_Id")%>' />
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </td>
                    <td class="border_right_color">
                        <ul class="process">
                            <asp:Repeater ID="RepeaterVA" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <asp:CheckBox ID="chkVa" runat="server" Enabled='<%# Eval("ChkEnable")%>' />
                                        <asp:Label ID="lblvaname" Text='<%#Eval("Name")%>' runat="server" Style="position: relative; top: -2px"></asp:Label>
                                        <asp:HiddenField ID="hdnVaid" runat="server" Value='<%#Eval("id")%>' />
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
        <div class="vacdiv" runat="server" id="divVA">
            <h3 style="width: 391px;">
                <span style="color: Red; text-align: left; font-size: 12px;">*</span>Value Addition Details</h3>
            <asp:GridView ID="grdva" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="90%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdva_RowDataBound" OnDataBound="grdva_DataBound" CssClass="item_list grdvatable">
                <Columns>
                    <asp:TemplateField HeaderText="From-To Status">
                        <ItemTemplate>
                            <asp:Label ID="lblstatusname" Text='<%#Eval("StatusName")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="border_left_color" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VA Name">
                        <ItemStyle CssClass="pad" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkva" runat="server" />
                            <asp:Label ID="lblvaname" Text='<%#Eval("ValueAddtionName")%>' runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnvaid" runat="server" Value='<%#Eval("Valid")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="align_left border_right_color" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <table style="width: 800px" class="upladtable">
            <tbody>
                <tr>
                    <td style="min-width: 100px; text-align: left; padding-left: 5px;">
                        <span><b>Digital Signature:</b> </span>
                    </td>
                    <td style="min-width: 100px; text-align: left">
                        <span style="position: relative; top: 6px;">
                            <asp:FileUpload ID="SignatureUpload" Font-Size="10px" Style="max-width: 130px;" runat="server" />
                            <asp:HiddenField ID="hdnSignatureUpload" Value="" runat="server" />
                        </span>
                        <br />
                        <span style="position: relative; top: 6px;">
                            <asp:RegularExpressionValidator ID="rexp" runat="server" ControlToValidate="SignatureUpload" ValidationGroup="submits" ErrorMessage="Only .gif, .jpg, .png file allow" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Bb][Mm][Pp])|.*\.([pP][nN][gG])|.*\.([tT][iI][iI][fF])$)"></asp:RegularExpressionValidator></span>
                    </td>
                    <td style="width: 400px; text-align: left">
                        <asp:Image ID="imgSignature" runat="server" CssClass="fireboxcs" ImageAlign="Middle" Style="min-width: 98px; max-width: 150px; min-height: 25px; max-height: 50px" />
                    </td>
                    <td style="width: 80px; text-align: right;">
                        <p style="margin: 0;">
                            <br />
                            <asp:Button ID="btnsubmit" runat="server" ValidationGroup="submits" Text="Submit" OnClientClick="javascript:return ClientCheck();" CssClass="submit" OnClick="btnsubmit_Click" />
                            <%-- <asp:Button ID="btnAdd" runat="server" CssClass="da_submit_button" Style="margin-left: 10px;line-height:14px"
                Text="ADD" OnClick="btnAdd_Click"></asp:Button>--%>
                            <br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="submits" />
                        </p>
                    </td>
                </tr>
            </tbody>
        </table>
        <div style="clear: both">
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="pnllist" runat="server">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <asp:CheckBoxList ID="chklist" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Fabric</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">Accessoires</asp:ListItem>
                        <asp:ListItem Selected="True" Value="3">VA</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td width="70px">
                    Search
                </td>
                <td>
                    <asp:TextBox ID="txtsearchinput" Width="70%" runat="server"></asp:TextBox>
                </td>
                <td width="80px">
                    <asp:DropDownList ID="DdlsearchIsActive" runat="server">
                        <asp:ListItem Value="-1">All</asp:ListItem>
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">In Active</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Style="margin-left: 10px;" CssClass="go" Text="Go" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <div style="font-size: 12px; margin-top: 10px; min-height: 228px; min-width: 1340px">
            <asp:GridView ID="grdEditView" runat="server" CellPadding="0" CellSpacing="0" AutoGenerateColumns="False" ShowHeader="true" Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdEditView_RowCommand" OnRowDataBound="grdEditView_RowDataBound" CssClass="item_list lastrow">
                <Columns>
                    <asp:TemplateField HeaderText="Type" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label ID="lblType" Text='<%#Eval("type")%>' runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnMasterID" runat="server" Value='<%#Eval("supplier_master_Id")%>' />
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                        <ItemStyle CssClass="border_left_color" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier Name" HeaderStyle-Width="180px">
                        <ItemTemplate>
                            <asp:Label ID="lblsupplierName" Text='<%#Eval("SupplierName")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DeliveryType" HeaderStyle-Width="40px">
                        <ItemTemplate>
                            <asp:Label ID="lblDeliveryType" Text='<%#Eval("DeliveryType")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier Initials" HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <asp:Label ID="lblSuppllerInitials" Text='<%#Eval("SupplierIntial")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" HeaderStyle-Width="300px">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" Text='<%#Eval("Address")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supply Type" HeaderStyle-Width="90px">
                        <ItemTemplate>
                            <asp:Label ID="lblSupplyType" Text='<%#Eval("SupplyType")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payment terms" HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <asp:Label ID="lblPaymenttearms" Text='<%#Eval("PaymentTerms")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade" HeaderStyle-Width="40px">
                        <ItemTemplate>
                            <asp:Label ID="lblGrade" Text='<%#Eval("Fabric_Grade")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="160px">
                        <ItemTemplate>
                            <asp:Label ID="lblProcess" Text='<%#Eval("Process")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="250px">
                        <ItemTemplate>
                            <asp:Label ID="lblfromtostatus" runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="VA Name" HeaderStyle-Width="130px">
                        <ItemTemplate>
                            <asp:Label ID="lblvaname" runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>--%>
                    <%--added by raghvinder on 15 Jan 2021 start--%>
                    <asp:TemplateField HeaderText="GST No." HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <asp:Label ID="lblGstNo" Text='<%#Eval("GstNo")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <%--added by raghvinder on 15 Jan 2021 end--%>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="30px">
                        <ItemTemplate>
                            <div style="text-align: center;" class="iSlnkHide">
                                <asp:LinkButton ForeColor="black" Width="25px" ID="lnkDelete" runat="server" CommandArgument='<%#Eval("supplier_master_Id")%>' CommandName="View"> <img src="../../images/edit2.png" /> </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active" HeaderStyle-Width="70px">
                        <ItemTemplate>
                            <asp:DropDownList ID="DdlIsActive" runat="server" OnSelectedIndexChanged="DdlIsActive_Change" AutoPostBack="true">
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">In Active</asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField runat="server" ID="hdnIsActive" Value='<%# Bind("IsActive") %>' />
                            <div style="text-align: center; display: none;">
                                <asp:LinkButton ForeColor="black" Width="50px" ID="lnkdele" runat="server" CommandArgument='<%#Eval("supplier_master_Id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="80px" CssClass="border_right_color" />
                        <HeaderStyle CssClass="ths" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No Record Found.</EmptyDataTemplate>
            </asp:GridView>
        </div>
    </asp:PlaceHolder>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
