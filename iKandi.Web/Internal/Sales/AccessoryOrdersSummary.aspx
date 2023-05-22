<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryOrdersSummary.aspx.cs"
    Inherits="iKandi.Web.Internal.Sales.AccessoryOrdersSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <style type="text/css">
        .AddClass_Table
        {
            margin-left: 0px;
            margin-top: 47px;
            border-collapse: separate;
            width:100%
        }
        
        .AddClass_Table th
        {
            padding: 0px 3px;
            background-color: #DDDFE4;
            height: 20px;
            font-size: 10px;
            text-transform: capitalize;
            position: sticky;
            top: 47px;
            border-right: 1px solid #999;
            border-left: 0px;
        }
        .AddClass_Table td
        {
            padding: 0px 0px;
            text-align: center;
            font-size: 10px;
            border-left: 0px;
        }
        .FloatLeft
        {
            float: left;
        }
        .FloatRight
        {
            float: right;
        }
        .CellWidth
        {
            min-width: 150px;
        }
        .CellWidthH
        {
            min-width: 100px;
            max-width: 100px;
        }
        .CellWidthH1
        {
            min-width: 100px;
            max-width: 100px;
        }
        .CellWidth1
        {
            min-width: 101px;
            max-width: 101px; /* min-width: 107px;
            max-width: 107px;
            position: fixed;
            left: 5px;*/
        }
        .CellWidth2
        {
            min-width: 100px;
            max-width: 100px; /* min-width: 120px;
                max-width: 120px;
                position: fixed;
                left: 100px;*/
        }
        .CellWidth3
        {
            min-width: 141px;
            max-width: 141px;
        }
        .txtCenter
        {
            text-align: center;
            padding: 0px 0px !important;
            line-height: 17px;
        }
        th.TopHeader
        {
            background: #39589c !important;
            color: White;
            padding: 3px 0px;
            font-size: 14px;
        }
        th .Inner_Table th
        {
            border: 0px;
            height: 16px;
        }
        .Inner_Table
        {
            width: 100%;
            border-collapse: separate;
        }
        td .Inner_Table td
        {
            border: 0px;
            height: 54px;
            border: 0px;
            word-break: break-all;
        }
        .Inner_Table .CellWidth
        {
            min-width: 80px;
            max-width: 80px;
        }
        
        .TooltipShrnkWat
        {
            position: relative;
            display: inline-block;
        }
        
        .TooltipShrnkWat .TooltipContent
        {
            visibility: hidden;
            width: 80px;
            background-color: #555;
            color: #fff;
            text-align: center;
            border-radius: 6px;
            padding: 5px 0;
            position: absolute;
            z-index: 1;
            top: -23px;
            left: -37px;
        }
        .TooltipShrnkWat .TooltipContent::after
        {
            content: "";
            position: absolute;
            top: 100%;
            left: 50%;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: #555 transparent transparent transparent;
        }
        
        .TooltipShrnkWat:hover .TooltipContent
        {
            visibility: visible;
        }
        
        
        .headerAccessories
        {
            background: #39589c !important;
            text-align: center;
            color: White;
        }
        .toptable td
        {
            background: #DDDFE4;
            font-size: 11px;
            padding: 1px 4px;
            border: 1px solid #dbd8d;
            border-bottom: 0px;
        }
        .toptable
        {
            margin-left: 0px;
            border: 0px;
            margin-top: 0px;
        }
        
        .txtAvg
        {
            width: 30px;
            border-radius: 2px;
        }
        .dropdownUnit
        {
            width: 52px;
        }
        .btnSubmit
        {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .ModelPo2
        {
            background: #fff;
            width: 100%;
            position: fixed;
            z-index: 100000;
            min-height: 200px;
            line-height: 21px;
            text-align: left;
            top: 5%;
            left: 0%;
            transform: translate(0%, 4%);
        }
        .maxWidthHist
        {
            max-height: 250px;
            overflow-y: auto;
            border-bottom: 1px solid lightgray;
        }
        #Pohistory
        {
            line-height: 20px;
            padding-top: 6px;
        }
        #Pohistory ul
        {
            margin-bottom: 0;
        }
        ul
        {
            list-style: none;
            margin-left: 0;
            padding-left: 1.2em;
            text-indent: -1.2em;
            margin-top: 0px;
        }
        
        li:before
        {
            content: "•";
            display: block;
            float: left;
            font-size: 14px;
            margin-right: 13px;
            margin-top: 0px;
            color: gray;
        }
        #divhistory h2
        {
            margin-left: 0px !important;
        }
        .FooterTable
        {
            width: 100%;
            border: 0px;
        }
        .FooterTable td
        {
            border: 1px solid #9999;
            border-bottom: 0px;
            border-left: 0px;
            height: 23px;
            color: #000;
            font-weight: 600;
            font-size: 12px;
        }
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-track
        {
            box-shadow: inset 0 0 5px grey;
            border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb
        {
            background: #bdbbbb;
            border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb:hover
        {
            background: #969191;
        }
        th.FirstHeaderth
        {
            position: sticky;
            left: 0px;
            z-index: 11;
        }
        th.FirstHeaderth2
        {
            position: sticky;
            left: 107px;
            z-index: 11;
        }
        .Inner_TableFixed
        {
            width: 100%;
        }
        .Inner_TableFixed td
        {
            height: 55px !important;
            border: 0px;
        }
        td.TableFixedtd
        {
            padding: 0px 0px;
            position: sticky;
            left: 0px;
            z-index: 8;
            background: #fff;
        }
        td.TableFixedtd
        {
            position: sticky;
            left: 0px;
            z-index: 10;
            background: #fff;
        }
        td.FirstHeadertd2
        {
            position: sticky;
            left: 107px;
            z-index: 10;
            background: #fff;
        }
        .Inner_TableFixed tr:last-child > td
        {
            border-bottom-color: #999 !important;
            word-break: break-all;
        }
        .Inner_TableFixed td:last-child
        {
            border-right-color: #999 !important;
        }
        td.LeftPositonFix
        {
            position: sticky;
            left: 0px;
            z-index: 9;
        }
        table.Inner_TableContent
        {
            width: 100%;
        }
        table.Inner_TableContent td
        {
            height: 27px !important;
        }
        
        /*.AddClass_Table td:nth-child(odd)
        {
            background-color: #f2f2f2;
        }*/
    </style>
    <script src="../../js/service.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var IsBind = 0;
        var serviceUrl = "../../Webservices/iKandiService.asmx/";
        var proxy = new ServiceProxy(serviceUrl);

        function calculateAvgUnit(elem, AccWorkingDetailId, flag) {

            // alert();          
            var ControlValue = $(elem).val();
            var OrderID = document.getElementById("hdnOrderID").value;
            var CreatedBy = parseInt(document.getElementById("hdnUserId").value);

            //var AccWorkingDetailId = elem.id.split("_")[5];

            if ((ControlValue == "") || (ControlValue == "0")) {
                alert("Average can not be blank or zero!");
                elem.value = elem.defaultValue;
                return false;
            }
            else {
                if (flag == 1) {
                    var Avg = parseFloat(ControlValue);

                    proxy.invoke("Save_Accessory_Average", { Type: 'AVG', Avg: Avg, Unit: 0, OrderID: OrderID, AccWorkingDetailId: AccWorkingDetailId, CheckValue: false, CreatedBy: CreatedBy }, function (result) {
                        if (result > 1 || result > -1) {
                            if ($("#hdnIsNeedToBypassForIETeam").val() == "1") {
                                location.reload();
                            }
                            //location.reload();
                        }
                    }, onPageError, false, false);
                }

                if (flag == 2) {
                    var Unit = parseInt(ControlValue);
                    proxy.invoke("Save_Accessory_Average", { Type: 'UNIT', Avg: 0, Unit: Unit, OrderID: OrderID, AccWorkingDetailId: AccWorkingDetailId, CheckValue: false, CreatedBy: CreatedBy }, function (result) {
                        if (result > 1 || result > -1) {
                            //location.reload();
                        }
                    }, onPageError, false, false);
                }
            }
        }
        //added by raghvinder on 23-10-2020 end

        function aa() {


            var css = '@page { size: landscape; }',
    head = document.head || document.getElementsByTagName('head')[0],
    style = document.createElement('style');

            style.type = 'text/css';
            style.media = 'print';

            if (style.styleSheet) {
                style.styleSheet.cssText = css;
            } else {
                style.appendChild(document.createTextNode(css));
            }

            head.appendChild(style);

            window.print();
        }

        function isNumberKey(evt, obj) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function pageLoad() {
            $('.FloatValue').keypress(function (event) {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
                    ((event.which < 48 || event.which > 57) &&
                      (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 2) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });
            DynamicHeightWidth();
        }

        function closeAccesButtion(IsUpdatedBYIETeam) {
            // this code added by bharat on 26-june-2019
            var tabVal = document.getElementById('hdnorderTabClose').value;
            if (tabVal == 3) {
                var win = window.open("", "_self");
                win.close();
            }
            else {
                self.parent.Shadowbox.close();
            }
            // end
        }

        function ShowHistory() {


            var OrderID = $("#hdnOrderID").val();
            var hist = "";
            proxy.invoke("GetOrderAccesoryHistory", { OrderId: OrderID },
                    function (response) {
                        if (response.length > 0) {
                            $("#divhistory").show();
                            for (var i = 0; i < response.length; i++) {
                                hist += '<ul><li>' + response[i].DetailDescription + '</li></ul>';
                            }
                            $("#Pohistory").html(hist);
                        }


                    });
        }
        function showhistoryhide() {
            $("#divhistory").hide();
        }

        function BindDropDownList() {

            var OrderId = $("#hdnOrderID").val();
            var strAcc = $("#hdnAccessDetailId").val().split(',');
            var strUnit = $("#hdnUnitId").val().split(',');
            var IsCutting = $("#hdnIsCutting").val();
            var IsAvgReadOnly = $("#hdnIsReadOnly").val();

            var IsNeedToBypassForIETeam = $("#hdnIsNeedToBypassForIETeam").val();


            for (var i = 0; i < strAcc.length; i++) {
                var AccessoryWorkingDetailId = strAcc[i];
                var SelectUnit = strUnit[i];
                var iCount = i + 1;
                BindUnit(OrderId, AccessoryWorkingDetailId, SelectUnit, iCount);

                if (IsAvgReadOnly == "1" && IsNeedToBypassForIETeam == "0") {
                    $("#AccessoryAvg" + iCount).attr("readonly", "true");
                }
                if (IsCutting == "1" && IsNeedToBypassForIETeam == "0") {
                    $("#AccessoryAvg" + iCount).attr("disabled", "disabled");
                    $("#ddlUnit" + iCount).attr("disabled", "disabled");
                }
                if (IsNeedToBypassForIETeam === "1") {
                    $("#ddlUnit" + iCount).attr("disabled", "disabled");
                }
            }

        }

        function BindUnit(orderid, AccessoryWorkingDetailId, SelectUnit, iCount) {
            proxy.invoke("Get_AccessoryDDL_ForOrder", { OrderId: orderid, AccessoryWorkingDetailId: AccessoryWorkingDetailId }, function (result) {
                $.each(result, function (key, value) {

                    $("#ddlUnit" + iCount).append($("<option></option>").val(value.GroupUnitID).html(value.UnitName));

                });

                $("#ddlUnit" + iCount + " option[value=" + SelectUnit + "]").attr('selected', 'selected');

            });


        }
        function DynamicHeightWidth() {

            //                var elmnt = document.getElementById("AddClass_Table");

            var elmnt = document.getElementsByClassName("AddClass_Table");
            window.parent.AccessoryDetailsScreen(parseInt(elmnt.offsetWidth) + 27, parseInt(elmnt.offsetHeight) + 30);


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <div>
        <asp:HiddenField ID="hdnorderTabClose" runat="server" />
        <asp:HiddenField ID="hdnOrderID" runat="server" />
        <asp:HiddenField ID="hdnUserId" runat="server" />
        <asp:HiddenField ID="hdnAccessDetailId" runat="server" />
        <asp:HiddenField ID="hdnUnitId" runat="server" />
        <asp:HiddenField ID="hdnIsCutting" Value="0" runat="server" />        
        <asp:HiddenField ID="hdnIsReadOnly" Value="0" runat="server" />

        <asp:HiddenField ID="hdnIsNeedToBypassForIETeam" Value="0" runat="server" />
        

        <table id="tblHeader" runat="server" class="toptable tableWith" cellpadding="0" cellspacing="0"
            border="0" style="width: 100%; position: fixed; top: 0px; z-index: 15;">
            <tr>
                <td class="headerAccessories">
                    <span style="position: relative; top: 3px;">Accessories Details</span>
                    <div style="width: 50px; float: right; padding-right: 3px">
                        <a onclick="ShowHistory()" id="ShowImgHis" runat="server" visible="false" style="color: White;
                            float: left; margin-right: 5px; cursor: pointer;" target="_blank">
                            <img src="../../images/history.png" /></a> <span style="float: right; padding: 1px 6px 1px 5px;
                                position: relative; top: 0px; font-size: 15px; cursor: pointer;" onclick="closeAccesButtion()">
                                X</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; color: gray; border-left: 1px solid #999999; border-top: 1px solid #999;
                    border-bottom: 0px; padding: 5px 5px 6px;">
                    <span style="color: gray">Serial Number: </span>
                    <asp:Label ID="lblserialno" Style="padding-right: 24px; color: #000; font-weight: 600"
                        runat="server"></asp:Label>
                    <span style="color: gray">Style Number:
                        <asp:Label ID="lblstylenumber" Style="color: #000; font-weight: 600" runat="server"></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    AM:
                    <asp:Label ID="lblacname" Style="color: #000; font-weight: 600" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnAccessSummary" Value="" runat="server" />
    </div>
    <div id="dvAccessorySummary" runat="server">
    </div>
    <div style="margin: 10px 0 10px 10px;">
        Avg. Checked and Smart Marker Uploaded by Account Manager.
        <asp:CheckBox ID="chkboxAccountMgr" runat="server" Enabled="true" Style="position: relative;
            cursor: poniter; top: 3px;" />
        <span style="color: red; font-size: 11px; margin-left: 5px; display: none" id="messageHide"
            runat="server">All avg. are not filled!</span>
    </div>
    <div style="margin: 10px 0 10px 10px; display: flex;">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="do-not-include btnSubmit submitbtn printButtonHide"
            OnClick="btnSubmit_Click" />
        <input type="button" id="btnPrint" style="display: none" onclick="aa()" class="print da_submit_button printButtonHide"
            value="Print" />
    </div>
    <div class="ModelPo2" id="divhistory" runat="server" style="display: none">
        <h2 style='background: #39589c !important; width: 100% !important; font-size: 15px;
            margin: 0px 0px; color: #fff !important; margin-left: 3px; font-weight: 500;
            text-align: center'>
            History<span style='float: right; margin-right: 8px; cursor: pointer; color: #fff'
                titel='Close' onclick="showhistoryhide();">X</span>
        </h2>
        <div class="maxWidthHist">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="width: 50%; text-align: left; padding: 0px 10px 22px; line-height: 21px;
                        font-size: 10px">
                        <div id="Pohistory">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
