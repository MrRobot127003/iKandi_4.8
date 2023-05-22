<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValueAddition.aspx.cs"
    Inherits="iKandi.Web.Admin.ValueAddition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-size: 11px;
            font-family: verdana;
            overflow-x:hidden;
        }
        input[type="text"]
        {
            text-transform: capitalize;
        }
        .txt
        {
            color: #7E7E7E;
            font-family: Arial;
            text-transform: none;
            text-align: center;
        }
        .remove-head
        {
            color: #575759 !important;
            background-color: #dddfe4 !important;
            text-transform: capitalize;
            border: 1px solid #cccccc;
            text-align: center;
            padding: 5px;
            font-weight: normal !important;
            font-size: 12px !important;
        }
        
        .ValuQty
        {
            border-top: 1px solid grey;
            display: inline-block;
            width: 100%;
        }
        .AddClass_Table td
        {
            text-transform: capitalize;
        }
        SELECT
        {
            text-transform: capitalize;
        }
        body
        {
        }
    </style>
</head>
<body bgcolor="#FFFFFF">
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <link href="../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        function ValidateZero(textbox) {
            //alert(textbox.id);
            var ValueAddQty = document.getElementById(textbox.id).value;
            if (parseInt(ValueAddQty) <= 0) {
                alert("Value must be greater than zero");
                document.getElementById(textbox.id).value = "";
                return;
            }
        }


        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function ValidateRow() {
            //debugger;
            var ManPowerExist = 0;
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvRow").length;
            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var ManPower = $("#<%= gvValueAddition.ClientID %> input[id*='" + gvId + "_txtManPower" + "']").val();
                var ValueAddQty = $("#<%= gvValueAddition.ClientID %> input[id*='" + gvId + "_txtValueAddQty" + "']").val();

                if ((ManPower != '') && (ValueAddQty != '')) {
                    ManPowerExist = 1;

                    var ddlQC = $("#<%= gvValueAddition.ClientID %> select[id*='" + gvId + "_ddlQC" + "']");
                    if (ddlQC.val() == '0') {
                        alert("Please Select QC");
                        return false;
                    }
                    var ddlChecker = $("#<%= gvValueAddition.ClientID %> select[id*='" + gvId + "_ddlChecker" + "']");
                    if (ddlChecker.val() == '0') {
                        alert("Please Select Checker");
                        return false;
                    }
                }
            }
            if (ManPowerExist == 0) {
                alert("ManPower and VA Qty can not be Empty!");
                return false;
            }
        }

    </script>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" align="center">
        <tr>
            <td style="background-color: #405D99; color: #FFFFFF; font-size: 15px; padding: 2px 0px; text-align:center;
                font-family: Arial;">
                Unit&nbsp;-&nbsp;
                <asp:Label ID="lblUnit" runat="server"></asp:Label>
                &nbsp; &nbsp; Entry for Value Addition
            </td>
        </tr>
        <tr>
            <td style="padding: 2px 5px; text-align: left;">
                <b>
                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:HiddenField ID="hdnColumnCount" runat="server" />
                <asp:GridView ID="gvValueAddition" runat="server" CellPadding="0" CellSpacing="0"
                    AutoGenerateColumns="false" OnRowDataBound="gvValueAddition_RowDataBound" Width="99.5%"
                    OnDataBound="gvValueAddition_DataBound" ShowHeader="true" CssClass="AddClass_Table">
                    <RowStyle CssClass="gvRow" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="156px">
                            <HeaderTemplate>
                                Status From - To
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFromStatus_ToStatus" runat="server" Text='<%#Eval("FromStatus_ToStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px" HeaderText="VA Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnValueAdditionId" runat="server" Value='<%#Eval("ValueAdditionID") %>' />
                                <asp:Label ID="lblValueAdditionName" runat="server" Text='<%#Eval("ValueAdditionName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" HeaderText="ManPower">
                            <ItemTemplate>
                                <asp:TextBox ID="txtManPower" Text='<%#Eval("ManPower") %>' MaxLength="4" Width="35px"
                                    onkeypress="javascript:return isNumberKey(event)" onchange="ValidateZero(this);"
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" HeaderText="VA Qty.">
                            <ItemTemplate>
                                <asp:TextBox ID="txtValueAddQty" Text="" MaxLength="4" Width="35px" onkeypress="javascript:return isNumberKey(event)"
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px" HeaderText="QC">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlQC" runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnQC" Value='<%#Eval("QCId") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px" HeaderText="Checker">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlChecker" runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnChecker" Value='<%#Eval("CheckerId") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" HeaderText="Is VA Comp.">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsComplete" Checked='<%#Eval("IsComplete") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
                    OnClientClick="javascript:return ValidateRow();" Text="Submit" OnClick="btnSubmit_Click" />
                &nbsp; &nbsp;
                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
                    Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
            </td>
        </tr>
        <tr id="trMessage" runat="server" visible="false">
            <td align="center" style="padding-top: 150px;">
                <asp:Label ID="lblMessage" runat="server" Text="There are no Size Available for this Contrat."
                    Visible="false" Font-Size="20px" Font-Names="Arial" ForeColor="#7E7E7E"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 2px;">
                <iframe id="ifValueAdditionWithHistory" width="100%" height="100%" style="border-color: transparent;"
                    src='../Admin/ValueAdditionWithHistory.aspx?OrderDetailId=<%=OrderDetailId%>&UnitId=<%=UnitId%>'>
                </iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
