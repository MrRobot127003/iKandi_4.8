<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSalesRevenueAdmin.aspx.cs"
    Inherits="iKandi.Web.Internal.Sales.frmSalesRevenueAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>    
    <link href="../../CommonJquery/ToolTip_plugin/css/tooltipster.bundle.min.css" rel="stylesheet"
        type="text/css" />
    
    <script src="../../CommonJquery/ToolTip_plugin/js/tooltipster.bundle.min.js" type="text/javascript"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <style type="text/css">
        body
        {
            font-size: 11px;
            font-family: Arial;
        }
        
        .table-wrap
        {
            width: 500px;
            max-height: 109px;
            overflow: auto;
            z-index: 1;
            overflow-x: hidden;
        }
        td
        {
            vertical-align: middle;
         }
        table.AddClass_Table
        {
            margin: auto;
            text-transform: capitalize;
        }
        td.Header1
        {
          border: 1px solid #999;
            padding: 3px 5px;
            font-weight: 500 !important;
        }
        #grdbiplExportRevenue td:nth-last-child(2)
        {
            display: none;
        }
        #grdbiplExportRevenue td:nth-last-child(1)
        {
            display: none;
        }
        .AddClass_Table td:nth-last-child(3)
        {
            border-right-color: #999 !important;
        }
    </style>
    <script type="text/javascript">

        function Exit() {
            var x = confirm('Are You sure want to exit:');
            if (x) window.close();
        }

        function isNumberKey(key) {
            //getting key code of pressed key
        var keycode = (key.which) ? key.which : key.keyCode;

        if (keycode == 46) return false;
            //comparing pressed keycodes
            if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
                return false;
            }
            else {
                var parts = key.srcElement.value.split('.');
                if (parts.length > 1 && keycode == 46)
                    return false;
                return true;
            }
            AddColGroup();
        }

        function AddColGroup() {

            var COLGROUP = document.createElement("COLGROUP");
            var COL1 = document.createElement("COL");
            var COL2 = document.createElement("COL");
            var COL3 = document.createElement("COL");

            COL1.setAttribute("width", "25%");
            COL2.setAttribute("width", "25%");
            COL3.setAttribute("width", "25%");

            COLGROUP.appendChild(COL1);
            COLGROUP.appendChild(COL2);
            COLGROUP.appendChild(COL3);

            document.getElementById('grdbiplExportRevenue').appendChild(COLGROUP);
        }

      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnorderdeta" runat="server" Value="0" />
    <%--<asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="Updatepanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="Updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>--%>
    <table border="0" class="AddClass_Table" cellpadding="0" cellspacing="0" style="width: 35%;
        margin-bottom: 5px;" align="center">
        <tr>
            <td style="padding: 3px 0px; background-color: #405D99; color: #FFFFFF; font-weight: 500;
                font-size: 14px; text-transform: none; text-align: center;">
                Bipl Export Entry
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="35%" class="AddClass_Table" style="margin: auto;">
        <colgroup>
            <col width="25%">
            <col width="25%">
            <col width="25%">
        </colgroup>
        <tr>
            <th align="center" rowspan="2" style="border: thin solid gray;">
                Financial Year
            </th>
            <th align="center" colspan="2" style="border: thin solid gray;">
                BIPL Export
            </th>
            <!--<td align="center" colspan="2" style="border: thin solid gray;width: 99px;">
                Ikandi Delivery
            </td>-->
        </tr>
        <tr>
            <th align="center" style="border: thin solid gray; width: 306px;">
                Value <span style="color:Gray;font-size:10px">(₹)</span>
            </th>
            <th align="center" style="border: thin solid gray; width: 306px;">
                Pcs
            </th>
            <!-- <td align="center" style="border: thin solid gray;width: 306px;">
                Value Cr.
            </td>
            <td align="center" style="border: thin solid gray;width: 155px;">
                Pcs. (Lacks)
            </td>-->
        </tr>
    </table>
    <asp:GridView ID="grdbiplExportRevenue" runat="server" AutoGenerateColumns="false"
        ShowHeader="false" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false"
        HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-HorizontalAlign="Center"
        ShowFooter="false" Width="35%" CssClass="AddClass_Table" OnRowDataBound="grdbiplExportRevenue_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Financial Year" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnP_ID" Value='<%#Eval("P_Id") %>' runat="server" />
                    <asp:Label ID="lblfinyear" runat="server" Text='<%#Eval("FinancialYear") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="25%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delayed Days" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:TextBox ID="txtbiplexportvalCR" Text='<%# (Convert.ToString(Eval("BIPLExportValues")) == ""||Convert.ToString(Eval("BIPLExportValues")) == "0") ? "" : Convert.ToDouble(Eval("BIPLExportValues")).ToString("N0")%>'
                        runat="server" CssClass="black maskedExt" onkeypress="return isNumberKey(event);"
                        Style="text-align: center; height: 15px; text-align: center; font: bold" MaxLength="15"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="25%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delayed Days" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:TextBox ID="txtbiplexportvalLK" Text='<%# (Convert.ToString(Eval("BIPLExportPCS")) == ""||Convert.ToString(Eval("BIPLExportPCS")) == "0") ? "" : Convert.ToDouble(Eval("BIPLExportPCS")).ToString("N0")%>'
                        runat="server" CssClass="black maskedExt" onkeypress="return isNumberKey(event);"
                        Style="text-align: center; height: 15px; text-align: center; font: bold" MaxLength="15"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="25%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delayed Days" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:TextBox ID="txtIKANDIexportvalCR" Text='<%# (Convert.ToString(Eval("IkandiExportValues")) == ""||Convert.ToString(Eval("IkandiExportValues")) == "0") ? "" : Convert.ToDouble(Eval("IkandiExportValues")).ToString("N0")%>'
                        runat="server" CssClass="black maskedExt" onkeypress="return isNumberKey(event);"
                        Style="text-align: center; height: 15px; text-align: center; font: bold" MaxLength="15"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="25%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delayed Days" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:TextBox ID="txtIKANDIexportvalLK" Text='<%# (Convert.ToString(Eval("IkandiExportPCS")) == ""||Convert.ToString(Eval("IkandiExportPCS")) == "0") ? "" : Convert.ToDouble(Eval("IkandiExportPCS")).ToString("N0")%>'
                        runat="server" CssClass="black maskedExt" onkeypress="return isNumberKey(event);"
                        Style="text-align: center; height: 15px; text-align: center; font: bold" MaxLength="15"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="25%" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <%--<div style="margin: 8px auto; text-align: center">
        <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
            Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
            Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
    </div>--%>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--new grid start--%>
    <table border="0" class="AddClass_Table" cellpadding="0" cellspacing="0" style="width: 20%;
        margin-bottom: 5px;" align="center">
        <tr>
            <td style="padding: 3px 0px; background-color: #405D99; color: #FFFFFF; font-weight: 500;
                font-size: 14px; text-transform: none; text-align: center;">
                Monthly Actual CMT
                <asp:DropDownList ID="ddlFinancialYear" AutoPostBack="true" runat="server" Width="30%" OnSelectedIndexChanged="ddlFinancialYear_SelectedIndexChanged" style="float: right;margin-right: 2px;">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdMonthlyActualCMT" runat="server" AutoGenerateColumns="false"
        ShowHeader="false" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false"
        HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-HorizontalAlign="Center"
        ShowFooter="false" Width="20%" CssClass="AddClass_Table" OnRowDataBound="grdMonthlyActualCMT_RowDataBound"
        OnRowCreated="grdMonthlyActualCMT_RowCreated">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%--<asp:HiddenField ID="hdnFinancialID" Value='<%#Eval("FinancialCMT_Id") %>' runat="server" />--%>
                    <asp:HiddenField ID="hdnFinancialID" Value='<%# Eval("FinancialCMT_Id") %>' runat="server" />
                    <asp:HiddenField ID="hdnMonthNumber" Value='<%# Eval("Month_Number") %>' runat="server" />
                    <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("Month_Number") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtActualCMT" Text='<%# (Convert.ToString(Eval("ActualCMT")) == ""||Convert.ToString(Eval("ActualCMT")) == "0") ? "" : Convert.ToDouble(Eval("ActualCMT")).ToString("N0")%>'
                        runat="server" onkeypress="return isNumberKey(event);" style="text-align:center" autocomplete="off"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <%--<div style="margin: 8px auto; text-align: center">
        <asp:Button ID="btnSubmitCmt" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
            Text="Submit" OnClick="btnSubmitCmt_Click" />
        <asp:Button ID="btnCloseCmt" title="Close this popup !" runat="server" CssClass="da_submit_button"
            Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
    </div>--%>
    <div style="margin: 8px auto; text-align: center">
        <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
            Text="Submit" OnClick="btnSubmit_Click" />
        <%--<asp:button id="btnclose" title="close this popup !" runat="server" cssclass="da_submit_button"
            text="close" onclientclick="javascript: open(location, '_self').close();" /> --%>       
           <%-- <asp:button id="btnclose" title="close this popup !" runat="server" cssclass="da_submit_button"
            text="Close" onclientclick="javascript: window.close();" />  --%>
            <button type="button" class="da_submit_button" onclick="javascript:window.open('','_self').close();""> Close</button>

           
            
    </div>
    <%--new grud end--%>
    </form>
</body>
</html>
