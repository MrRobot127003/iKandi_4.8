<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricOrderPrintComments.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.FabricOrderPrintComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-family: Arial !important;
        }
        .hiddenfield {
            display: none;
        }
        .HeaderClass td {
            background: #dddfe4;
            font-weight: bold;
            color: #575759;
            font-family: arial, halvetica;
            font-size: 9px;
            padding: 0px 0px;
            border-color: #c6c0c0;
            text-transform: capitalize;
            font-family: arial;
        }
        .HeaderClass table {
            width: 100%;
        }
        #grdattendence th {
            color: Gray;
            padding: 2px 2px;
            font-weight: 500;
            font-size: 9px;
            font-family: sans-serif;
        }
        #grdattendence td {
            color: #000 !important;
            padding: 2px 2px;
            font-size: 9px;
            font-family: arial;
            text-align: center;
        }
        #grdattendence td:first-child {
            font-weight: 600;
        }
        
        #grdoption2 th {
            color: Gray;
            padding: 2px 2px;
            font-weight: 500;
            font-size: 11px;
        }
        #grdoption2 td {
            color: #000 !important;
            padding: 2px 2px;
            font-size: 11px;
        }
        #grdoption2 td:first-child {
            font-weight: 600;
        }
        #grdoption3 th {
            color: Gray;
            padding: 2px 2px;
            font-weight: 500;
            font-size: 9px;
        }
        #grdoption3 td {
            color: #000 !important;
            padding: 2px 2px;
            font-size: 9px;
        }
        #grdfabricOrderPrint .HeaderClass td {
            font-size: 10px !important;
            font-family: arial !important;
            color: Gray;
            padding: 1px 2px !important;
            text-transform: capitalize;
            text-align: center;
            border-color: #999;
        }
        #grdfabricOrderPrint td {
            font-size: 10px !important;
            font-family: arial !important;
            color: Gray;
            padding: 1px 2px !important;
            text-transform: capitalize;
            line-height: 14px;
            border-color: #dbd8d8;
        }
        #grdoption3 td:first-child {
            font-weight: 600;
        }
        .toptable td {
            background: #DDDFE4;
            font-size: 12px;
            padding: 5px 4px;
            border-top: 1px solid #999999;
        }
        
        .headercolor {
            font-size: 9px;
            color: #716c6c;
            font-weight: 500;
            width: 200px;
        }
        .textbreak {
            display: block;
        }
        
        #grdaccsize th input {
            width: 95%;
            margin: 2px 0px;
            border: 1px solid #5e5867;
        }
        .headersecol {
            font-size: 10px;
            color: #716c6c;
            min-width: 200px;
        }
        .exfact {
            color: gray;
            font-weight: 600;
        }
        
        
        #grdfabricOrderPrint td textarea {
            border: 0px;
            width: 98% !important;
            margin: 0;
            padding: 0;
            border-width: 0;
            height: 40px !important;
            color: #000 !important;
            text-transform: capitalize;
            font-size: 11px;
            text-align: left !important;
            line-height: 13px;
        }
        .cutavqty {
            color: gray;
            text-transform: lowercase;
            font-weight: 600;
        }
        .printcolortext {
            color: #000;
            font-weight: 600;
        }
        .textcolorqty {
            color: #000;
            font-weight: 600;
        }
        .innertabletdR {
            text-align: left !important;
        }
        .innertabletdL {
            width: 45%;
            text-align: right !important;
        }
        #grdfabricOrderPrint td:first-child {
            border-left-color: #999 !important;
        }
        #grdfabricOrderPrint td:last-child {
            border-right-color: #999 !important;
        }
        #grdfabricOrderPrint tr:nth-last-child(1) > td {
            border-bottom-color: #999 !important;
        }
        
        .ColWidth2 {
            min-width: 65px;
            max-width: 65px;
        }
        
        .ColoPrintW {
            width: 110px;
        }
        .cutAvgW {
            min-width: 50px;
            max-width: 50px;
        }
        .ColWidth1 {
            min-width: 105px;
            max-width: 105px;
        }
        @media print {
            .printButtonHide {
                display: none;
            }
        }
        .headerAccessories {
            background: #39589c !important;
            text-align: center;
            color: White;
            width: 100%;
        }
        #dvContainer {
            margin-left: 7px;
            margin-top: 5px;
        }
    </style>
    <script type="text/javascript">

        function aa() {
            debugger;

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
        function closeTabButtion() {
            // debugger;
            var win = window.open("", "_self");
            win.close();
        }
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="dvContainer">
                <table class="toptable" id="Headerwidth" runat="server" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="headerAccessories">
                            Fabric Details
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; border-left: 1px solid #999999; border-right: 1px solid #999">
                            <span style="color: gray">Sr No: </span><b>
                                <asp:Label ID="lblserialno" Style="padding-right: 10px; color: #000; text-transform: capitalize;" runat="server"></asp:Label></b> <span style="color: gray">Dt Name: </span><b>
                                    <asp:Label ID="lblDepartment" Style="padding-right: 10px; color: #000; text-transform: capitalize;" runat="server"></asp:Label></b> <span style="color: gray">Style No: <b>
                                        <asp:Label ID="lblstylenumber" Style="color: #000; text-transform: capitalize;" runat="server"></asp:Label></b></span> <span style="color: gray; margin-left: 10px;">AM: <b>
                                            <asp:Label ID="lblacname" Style="color: #000; text-transform: capitalize;" runat="server"></asp:Label></b> </span>
                        </td>
                        <%-- <td style="text-align: left; color: gray;">
                         
                        </td>
                        <td style="text-align: right; color: gray; border-right: 1px solid #999999;">--%>
                        <%--  <span title="Close" style="float: right; padding-right: 5px; margin-top: 0px; font-size: 14px;
                cursor: pointer" onclick="closeTabButtion()">x</span>--%>
                    </tr>
                </table>
                <asp:GridView ID="grdfabricOrderPrint" runat="server" CssClass="item_list" ShowHeader="false" AutoGenerateColumns="false" OnRowDataBound="grdfabricOrderPrint_RowDataBound">
                </asp:GridView>
                <br />
                <div style="position: relative; left: .2%; top: 0px;">
                    AVG Checked and Smart Marker Uploaded by Account Manager
                    <asp:CheckBox ID="chkboxAccountMgr" runat="server" Enabled="false" Style="position: relative; cursor: poniter; top: 3px;" />
                    &nbsp; &nbsp; &nbsp; Approved by Fabric Manager
                    <asp:CheckBox ID="chkboxFabricMgr" runat="server" Enabled="false" Style="position: relative; cursor: poniter; top: 3px;" />
                </div>
                <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="margin-left: 10px;">
        <input type="button" id="btnPrint" onclick="aa()" class="print da_submit_button printButtonHide" value="Print" />
    </div>
    </form>
</body>
</html>
