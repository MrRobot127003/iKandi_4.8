<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnRagisterAccessories.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.UnRagisterAccessories" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
<%--    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>--%>
    <script src="../../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.form.js" type="text/javascript"></script>
    <script src="../../js/jquery.autocomplete.js" type="text/javascript"></script>
    <style>
       .CommoAdmin_Table
       {
           width:100%;
           margin-top:5px;
          
         }
         .HideClass
         {
             display:none;
          }
         .CommoAdmin_Table td input[type="text"] {
        width: 95%;
        text-transform:capitalize
    }
     
   input[type="text"] {
       
        text-transform:capitalize;
        border-radius:3px;
    }
    .classAdd
    {
        cursor:pointer;
      }
      .txtCenter
      {
          text-align:center;
        }
        .headertext
       {
             background: #39589c;
            margin: 0px;
            padding: 3px 10px;
            color: #fff;
            text-transform: capitalize;
            border-radius: 1px 1px 0px 0px;
            display: block;
            text-align:center
         }
         .btnbutton
         {
             margin-top:0px;
         }
    </style>
    <script type="text/javascript">

        var idjs = 0;


        $(document).ready(function () {
            addtableload();
            $("input[type=text].NatureOfFaults").autocomplete("../../Webservices/iKandiService.asmx/UnregisterdAcc", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });
            $("input[type=text].NatureOfFaults").result(function () {
                debugger;
                var AccessoriesName = $("#txtAccessoriesName").val();
                if (AccessoriesName != "") {
                    AccessoryName();
                    //  alert();
                }
                
            });


        })


        function addtableload() {
            var BindTable1 = '<td>' +
                '<input type="text" id="AccessoriesSize_' + idjs + '" autocomplete="off" class="AccessoriesSize" maxlength="4" onkeypress="return blockSpecialChar(event)" /></td>' +
                '<td><input type="text" id="AccessoriesRate_' + idjs + '" autocomplete="off" class="AccessoriesRate" onkeypress="myFunction(this)" /></td>' +
                '<td class="txtCenter"><span id="btnSubmit" ' + idjs + '" onclick="AddTableRow()"><img src="../../images/add-butt.png" /></span></td>'

            $('#BindTable').append(BindTable1);
        }

        function AccessoryName() {
          //  debugger;
            var AccessoriesName = $("#txtAccessoriesName").val();

            if (AccessoriesName != "") {

                var url = "../../Webservices/iKandiService.asmx";
                $.ajax({
                    type: "POST",
                    url: url + "/Get_UnRagisterAccessories",
                    data: "{ Tradename:'" + AccessoriesName + "'}",
                    //  data: datavalue,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCall,
                    error: OnErrorCall
                });

                function OnSuccessCall(response) {
                 //   debugger;
                    var trHTML = ''
                    if (response.d != '') {
                       // debugger;
                        var parser = new DOMParser();
                        var xmlDoc = parser.parseFromString(response.d, "text/xml");
                        var xml = $(xmlDoc);
                        var Size = xml.find("Size");
                        if (Size.length > 0) {
                            $("#BindTable").hide();
                        }
                        else {
                            $('#maintable').empty();
                        }
                        var FinishRate = xml.find("FinishedRate");
                        idjs = FinishRate.length;
                            for (var j = 0; j < FinishRate.length; j++) {
                                var UnAccRate = FinishRate[j].innerHTML;
                                var UnRaSizeAcc = Size[j].innerHTML;
                                trHTML += '<tr class="data-contact-person">';
                                trHTML += '<td><input type="text" id="AccessoriesSize_' + j + '" value="' + UnRaSizeAcc + '" class="AccessoriesSize" readonly /></td>';
                                trHTML += '<td><input type="text" id="AccessoriesRate_' + j + '" class="AccessoriesRate" value="' + UnAccRate + '" readonly /></td>';
                                trHTML += '<td></td>';
                                trHTML += "</tr>";

                            }
                            trHTML += '<tr class="data-contact-person">';
                            trHTML += '<td><input type="text" id="AccessoriesSize_' + idjs + '" class="AccessoriesSize" autocomplete="off" maxlength="4" onblur="ValidateSaze(this)" onkeypress="return blockSpecialChar(event)" /></td>';
                            trHTML += '<td><input type="text" id="AccessoriesRate_' + idjs + '" class="AccessoriesRate" autocomplete="off" onkeypress="myFunction(this)" /></td>';
                            trHTML += '<td class="txtCenter"><span id="btnSubmit' + idjs + '" onclick="AddTableRow()"><img src="../../images/add-butt.png" /></span></td>';
                            trHTML += '</tr>';
                            $('#GetAccessoriry').empty();
                            $('#GetAccessoriry').append(trHTML);
                         
                    }
                        else {
                       
                    }


                }
                function OnErrorCall(response) {
                    alert('fail');
                }

            }
            else {
               location.reload(true);
               
            }
        }
        function AddTableRow() {
          // debugger;
            var btnid = 0;
            var AccessoriesName = $("#txtAccessoriesName").val();
            if (AccessoriesName == "") {
                alert("Accessories Name can not blank");
                return false;
            }
            var rowCount = $('.data-contact-person').length;
            btnid = rowCount - 1;
            var AccssesoriesSize;
            var AccssesoriesRate;

             AccssesoriesSize = $("#AccessoriesSize_" + btnid).val();
             AccssesoriesRate = $("#AccessoriesRate_" + btnid).val();
         
            if (AccssesoriesSize == "") {
                alert("Accessories Size can not blank");
                return false;
            }
            if (AccssesoriesRate == "") {
                alert("Accessories Rate can not blank");
                return false;
            }

            $('#btnSubmit' + btnid).hide();

          for (var i = 0; i <= rowCount-2; i++) {
              $('#btnSubmit' + btnid).hide();
          }
           
            var contactdiv = '<tr class="data-contact-person">' +
                '<td><input type="text" id="AccessoriesSize_' + rowCount + '" autocomplete="off" class="AccessoriesSize" maxlength="4" onkeypress="return blockSpecialChar(event)" onblur="ValidateSaze(this)" /></td>' +
                '<td><input type="text" id="AccessoriesRate_' + rowCount + '" autocomplete="off" class="AccessoriesRate" onkeypress="myFunction(this)" /></td>' +
                '<td class="txtCenter"><span  id="btnAdd' + rowCount + '" onclick="AddTableRow()"><img src="../../images/add-butt.png" /></span>' +
                '</tr>';
            $('#maintable').append(contactdiv);
            $("#btnAdd" + btnid).addClass('HideClass');
        }
        function myFunction(e) {
            if ((event.which != 46 || e.value.indexOf('.') != -1) &&
            ((event.which < 48 || event.which > 57) &&
              (event.which != 0 && event.which != 8))) {
                event.preventDefault();
            }
            var t = e.value;
            e.value = (t.indexOf(".") >= 0) ? (t.substr(0, t.indexOf(".")) + t.substr(t.indexOf("."), 2)) : t;
        }
        function blockSpecialChar(ele) {
            var k = ele.keyCode;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || (k >= 48 && k <= 57));

        }
        function Save_Data() {
           debugger;
            var AccessoriesName = $("#txtAccessoriesName").val();
            var rowCount = $('.data-contact-person').length;

            var obj = {}
            var xmlRequest = '<table>'
            var count = 0
            var AccessoriesSize, AccessoriesRate;
            for (var i = 0; i <= rowCount-1; i++) {
           
                AccessoriesSize = $("#AccessoriesSize_" + i).val();
                AccessoriesRate = $("#AccessoriesRate_" + i).val();
             
                xmlRequest += '<Size>' + AccessoriesSize + '</Size>'
                xmlRequest += '<FinishedRate>' + AccessoriesRate + '</FinishedRate>'

            }
         
             xmlRequest += '</table>'
            obj.AccessoriesName = AccessoriesName;
            obj.AccessoryRateSize = xmlRequest.toString();
            var data = JSON.stringify(obj);
            var url = "../../Webservices/iKandiService.asmx";

            $.ajax({
                type: "POST",
                url: url + "/Save_UnRagisterAccessories",
//                data: "{ Tradename:'" + Tradename + "', AccessoriesSize:'" + AccessoriesSize + "', AccessoriesRate:'" + AccessoriesRate + "' }",
                data: data,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });
            function OnSuccessCall(response) {
                location.reload(true);
            }

            function OnErrorCall(response) {
                alert('fail');
            }
        }
      
          function ValidateSaze(ele) {
              var findtablerow = $('tr.data-contact-person').length-1;
              var currentAccSize = ele.value;
              var thisId = ele.id.split('_')[1];
           //   debugger;
            for (var i = 0; i <= findtablerow-1; i++) {
                var AccessoriesSize = $("#AccessoriesSize_" + i).val();
                if (thisId != i) {
                    if (AccessoriesSize.toLowerCase() == currentAccSize.toLowerCase()) {
                        alert('Size Can not duplicate!');
                        ele.value = "";
                        return false;
                    }
                }
            }
        }
        function closeAccesButtion() {
            self.parent.Shadowbox.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="headertext">
        <span>UnRegister Accessories Entry Form</span>
      <span style="float: right; padding-right: 5px; margin-top: 0px; font-size: 14px;
                cursor: pointer" onclick="closeAccesButtion()">x</span>
    </div>
    <div style="margin:5px auto;text-align:center">
       <asp:TextBox ID="txtAccessoriesName" CssClass="NatureOfFaults" placeholder="Accessories Name" onblur=" AccessoryName()" runat="server"></asp:TextBox>
     <table cellpadding="0" cellspacing="0" class="CommoAdmin_Table" id="tableRowCount">
       <tr>
        
           <th>Size</th>
           <th>Rate</th>
           <th class="" style="width:16px"></th>
        
       </tr>
       <tbody id="GetAccessoriry"></tbody>
       <tfoot id="maintable">
        <tr id="BindTable" class="data-contact-person"></tr>
       </tfoot>
     </table>
     <p></p>
      <button type="button" id="btnSaveData" class="btn btn-xs btn-primary btnbutton HideRow" onclick="Save_Data()">Submit</button>  
    </div>
    </form>
</body>
</html>
