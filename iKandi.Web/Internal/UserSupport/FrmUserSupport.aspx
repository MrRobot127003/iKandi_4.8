<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUserSupport.aspx.cs"
    Inherits="iKandi.Web.Internal.UserSupport.FrmUserSupport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        table th
        {
            font-size: 9px !important;
            padding: 0px !important;
        }
        
        .Qa_grid_table td
        {
            border: 1px solid #cac4c4 !important;
            font-size: 9px !important;
            font-family: arial !important;
        }
        .box
        {
            width: 98%;
            height: 100%;
            background-color: #fff;
            padding: 10px 10px;
            font-family: arial;
            margin: 5% 0;
        }
        th.qaheader
        {
            border: 1px solid #999 !important;
            padding: 3px 5px !important;
            background: #cecccc;
        }
        Qa_grid_table th
        {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize; /* border: 1px solid #b7b4b4 !important; */
            border-bottom: 1px solid #999999 !important;
            border-left: 1px solid #999999 !important;
            text-align: center;
            font-weight: normal;
            font-size: 12px;
            border-right: 0px;
        }
        
        .Qa_grid_table td
        {
            font-size: 11px !important;
            padding: 2px 3px !important;
        }
        
        .tableclass
        {
            background-color: #f3f1f159;
            margin: 0 auto;
            border: 1px solid #9999;
            margin: 0 auto;
            border-spacing: 0;
            width: 700px;
        }
        .tableclass td
        {
            padding: 4px 0px;
            font-size: 11px;
        }
        .tableclass th
        {
            padding: 3px 0px;
            border-top: 1px solid #9999;
        }
        .tableclass h2
        {
            width: 100%;
            font-weight: 500;
            background: #3b5998;
            font-size: 15px;
            font-family: arial;
            position: relative;
            color: White;
            text-align: center;
            margin: 0px;
            padding: 3px 0px;
        }
        .tableclass h3
        {
            width: 98.7%;
            margin: 0px 0px 5px;
            font-weight: 500;
            background: #dededeb3;
            font-size: 12px;
            font-family: arial;
            position: relative;
            color: #6d6b6b;
            padding: 3px 5px;
            text-align: left;
        }
        .padding_0
        {
            padding: 0px 0px !important;
        }
        .left_padding_5
        {
            padding-left: 5px !important;
        }
        .tableclass .submit
        {
            font-size: 11px;
            border-radius: 2px;
            padding: 4px 9px;
        }
        input[type=text]
        {
            height: 14px !important;
            font-size: 10px;
            text-transform: capitalize;
            padding-left: 3px;
        }
        .qtyupdatewidth
        {
            width: 70px;
        }
        .contactorderwidth
        {
            width: 91px;
        }
        .selectwidth
        {
            width: 40px;
            text-align: center;
        }
        .cdwidth
        {
            width: 150px;
        }
        .textcenter
        {
            text-align: center;
        }
        .padding_bottom_10
        {
            padding-bottom: 10px !important;
        }
        .da_submit_button
        {
            border-radius: 2px;
            padding: 4px 9px;
        }
        .da_submit_button:hover
        {
            padding: 4px 9px;
        }
        SELECT {
        height: 19px !important;
        font-size:10px !important
    }
    </style>
</head>
<body>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
 
    <script type="text/javascript">
        $(document).ready(function () {
            $('.th').datepicker({ format: "yyyy/mm/dd" });
        });
       
    </script>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var OrderdetailIDs = '<%=txtorderdetailid.ClientID %>';
        var createdate = '<%=txtcreatedate.ClientID %>';
        var urls = "../../Webservices/iKandiService.asmx";
        var proxy = new ServiceProxy(serviceUrl);
        $(function () {


            $("input.SerialNo").autocomplete("/Webservices/iKandiService.asmx/SerialNumberOnly", { dataType: "xml", datakey: "string", max: 100 });
        });
        function Check(filed) {
            if ($("#txtSerialNo").val() != "") {

                if (confirm('Are you sure you want to ' + filed + ' ?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                alert("Please enter serial number");
                return false;
            }
        }
        function close_window() {
            // debugger;
            if (confirm("Close Window?")) {
                window.open('', '_parent', '');
                window.close();
            }
        }

        function updateDelayday() {
            //            debugger;
            selected = $('#<%= ddltaskstatus.ClientID %> option:selected').val();
            if (selected != "-1") {
                proxy.invoke("UpdatedealydayCountTask", { StatusMode_id: selected }, function (result) {
                    //                    debugger;
                    //                    alert(result);
                    if (result) {
                        alert('Updated successfully');
                    }
                });

            }
        }
        function UpdateQaStatus(QcID, elem) {
            //            debugger;
            if (confirm("Are you sure want to open Qc sheet ?")) {
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/UpdateQCSheetStatus",
                    data: "{ flag:'" + 'UPDATEQC' + "', QCID:'" + QcID + "'}",
                    dataType: 'JSON',
                    success: OnSuccessCall,
                    error: OnErrorCall
                });
                return false;

            }
            else {
                elem.value = elem.defaultValue;
            }
            function OnSuccessCall(response) {

                alert("Saved Sucessfully");
                $('#here_table').hide();
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }
        function load_Data() {

            QAsheetType = $('#<%= ddlQAsheetSatus.ClientID %> option:selected').val();
            OrderdetailID = $("#" + OrderdetailIDs).val();
            createdateval = $("#" + createdate).val();

            if (QAsheetType != -1 && OrderdetailID != "" && createdateval != "") {
                $('#here_table').html("");
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: urls + "/UpdateSupportIssue",
                    data: "{ Flag:'" + 'GETQASHEETDATA' + "', OrderdetailID:'" + OrderdetailID + "', createdon:'" + createdateval + "', QAtype:'" + QAsheetType + "'}",
                    dataType: 'JSON',
                    success: function (response) {

                        $('#here_table').append('<table cellspacing="0" class="ss qatableheader" cellpedding="0">');
                        $('#here_table').append("<tr><th class='qaheader contactorderwidth'>ContractNumber </th><th class='qaheader contactorderwidth'>OrderdetailID </th><th class='qaheader qtyupdatewidth'> UpdatedOn </th><th class='qaheader cdwidth'>CQDname </th><th class='qaheader qtyupdatewidth'>Quantity </th><th class='qaheader contactorderwidth'>SerialNumber</th><th class='qaheader selectwidth'>Select</th></tr>")
                        for (var i = 0; i < response.d.length; i++) {

                            $('#here_table').append("<tr><td class='textcenter'>" + response.d[i].Contarctnumber + "</td><td class='textcenter'>" + response.d[i].OrderDetailID + "</td><td class='textcenter'>" + response.d[i].Updatedon + "</td><td>" +
                                 response.d[i].CQDname + "</td><td class='textcenter'>" + response.d[i].Qty + "</td><td class='textcenter'>" + response.d[i].SerialNumber + "</td><td class='textcenter'>" + '<input type="checkbox" id="Actio" onchange=UpdateQaStatus(' + response.d[i].QCID + ',' + 'this' + ') name="Actio" />' + "</td></tr>");

                        };
                        $('#here_table').append('</table>');
                        //                        alert(response.d.length);
                        //                        debugger;
                        if (response.d.length > 0) {


                        }
                        else {
                            $('#here_table').html("");
                        }

                    },
                    error: function () {

                        $('#here_table').html("");
                        alert("Error");
                    }
                });
                return false;

            };
        }
        function CloseFuntion() {
            debugger;
            window.close();
        }
    </script>
    <form id="form1" runat="server">
    <div class="box">
        <table cellpadding="0" cellspacing="0" class="tableclass">
            <tr>
                <th colspan="4" class="padding_0">
                    <h2 style="">
                        Support Concern
                    </h2>
                </th>
            </tr>
            <tr>
                <th colspan="4" class="padding_0">
                    <h3>
                        OB, Risk, Hoppm & Fits Cycle Support
                    </h3>
                </th>
            </tr>
            <tr>
                <td colspan="4" class="left_padding_5">
                    Serial Number:
                    <asp:TextBox runat="server" ID="txtSerialNo" placeholder="Serial No." Style="width: 91px;
                        height: 14px; font-weight: bold;" CssClass="do-not-disable SerialNo" MaxLength="16"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="left_padding_5 padding_bottom_10">
                    <asp:Button ID="btnOB" runat="server" class="a" Text="OB Open" OnClientClick="return Check('open OB')"
                        CssClass="submit" OnClick="btnOB_Click" CommandArgument="OB" />
                </td>
                <td class="padding_bottom_10">
                    <asp:Button ID="btnrisk" runat="server" class="a" Text="Risk Open" OnClientClick="return Check('open risk')"
                        CssClass="submit" OnClick="btnrisk_Click" CommandArgument="RISK" />
                </td>
                <td class="padding_bottom_10">
                    <asp:Button ID="btnhoppm" runat="server" class="a" Text="Hoppm Open" OnClientClick="return Check('open Hoppm')"
                        CssClass="submit" OnClick="btnhoppm_Click" CommandArgument="HOPPM" />
                </td>
                <td class="padding_bottom_10">
                    <asp:Button ID="btnremovefitcycle" class="a" runat="server" OnClientClick="return Check('remove fitcycle')"
                        Text="Fits Cycle Open" CssClass="submit" OnClick="btnremovefitcycle_Click" CommandArgument="FITCYCLE" />
                    <%-- OnClientClick="javascript:return confirm('Are you sure you want to Fits Cycle Open ?');"--%>
                </td>
            </tr>
            <tr>
                <th colspan="4" class="padding_0">
                    <h3>
                        Pending Delay Support
                    </h3>
                </th>
            </tr>
            <tr>
                <td class="left_padding_5 padding_bottom_10">
                    <asp:DropDownList ID="ddltaskstatus" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="status_modename" DataValueField="status_modeid" AppendDataBoundItems="true">
                        <asp:ListItem Text="Please select" Value="-1" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select status_modename,status_modeid from admin_targetdate"></asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ValidationGroup="task"
                        ControlToValidate="ddltaskstatus" InitialValue="-1" runat="server" ErrorMessage="Value Required!"></asp:RequiredFieldValidator>
                </td>
                <td class="padding_bottom_10">
                    <asp:Button ID="btnpendingdelay" OnClientClick="updateDelayday();" runat="server"
                        Text="Submit" CssClass="submit" ValidationGroup="task" CommandArgument="PENDINGDELAY" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <th colspan="4" class="padding_0">
                    <h3>
                        QA Support
                    </h3>
                </th>
            </tr>
            <tr>
                <td class="left_padding_5 padding_bottom_10">
                    OrderDetailID:
                    <asp:TextBox ID="txtorderdetailid" onchange="javascript:load_Data();" Style="width: 91px;
                        height: 21px; font-weight: bold;" MaxLength="7" runat="server" placeholder="OrderDetailid"></asp:TextBox>
                </td>
                <td class="padding_bottom_10">
                    QA Sheet Status:
                    <asp:DropDownList ID="ddlQAsheetSatus" DataTextField="Description" AppendDataBoundItems="true"
                        onchange="javascript:load_Data();" DataValueField="InspectionID" DataSourceID="SqlDataSource2"
                        runat="server">
                        <asp:ListItem Text="Please select" Value="-1" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select InspectionID,Description from tblMasterInspection where InspectionID not in (2)">
                    </asp:SqlDataSource>
                </td>
                <td class="padding_bottom_10">
                    Createddate:
                    <asp:TextBox ID="txtcreatedate" onchange="javascript:load_Data();" CssClass="th"
                        Style="width: 91px; height: 21px; font-weight: bold;" MaxLength="7" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <th colspan="4" class="padding_0">
                    <h3 style="text-align:center">
                        Fabric/Accesories Support
                    </h3>
                </th>
            </tr>
             <tr>
                <th colspan="4" class="padding_0">
                    <h3>
                       Cancelation after SRV Receive
                    </h3>
                </th>
            </tr>
  <tr>
                <td class="left_padding_5 padding_bottom_10">
                  <span style="display:inline-block;width:100px;">Fabric PO No:</span>
                    <asp:TextBox ID="TextBox1"  Style="width: 91px;
                        height: 21px; font-weight: bold;" MaxLength="7" runat="server" placeholder="Fabric PO No."></asp:TextBox>
                </td>
                <td class="padding_bottom_10">
                    Status:
                    <asp:DropDownList ID="DropDownList1" 
                        runat="server">
                        <asp:ListItem Text="Cancel" Value="1" />
                      <%--  <asp:ListItem Text="Close" Value="2" />--%>
                    </asp:DropDownList>
                  
                </td>
                <td class="padding_bottom_10">
                   
                    <asp:Button ID="btnClost" Text="Submit" CssClass="submit" OnClick="btnClost_Click"
                         runat="server" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="left_padding_5 padding_bottom_10">
                  <span style="display:inline-block;width:100px;">Accessories PO No:</span>  
                    <asp:TextBox ID="txtAcc"  Style="width: 91px;
                        height: 21px; font-weight: bold;" MaxLength="7" runat="server" placeholder="Accesories PO No."></asp:TextBox>
                </td>
                <td class="padding_bottom_10">
                    Status:
                    <asp:DropDownList ID="ddlAcc" 
                        runat="server">
                        <asp:ListItem Text="Cancel" Value="1" />
                      <%--  <asp:ListItem Text="Close" Value="2" />--%>
                    </asp:DropDownList>
                  
                </td>
                <td class="padding_bottom_10">
                   
                    <asp:Button ID="btn_Acc" Text="Submit" CssClass="submit" OnClick="btnAcc_Close_Click"
                         runat="server" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="5" class="left_padding_5">
                    <div id="here_table" class="Qa_grid_table">
                    </div>
                </td>
            </tr>
            
          <%--  <tr>
                <td colspan="4" class="left_padding_5 textcenter">
                    <div style="width: 100%; margin: 10px auto;">
                     <span class="da_submit_button" onclick="CloseFuntion()">Close</span>
                       
                    </div>
                </td>
            </tr>--%>
        </table>
    </div>
    </form>
</body>
</html>
