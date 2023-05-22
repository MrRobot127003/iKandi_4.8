<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExportToExcel.ascx.cs"
    Inherits="iKandi.Web.ExportToExcelControl" %>
<script type="text/javascript">

    //    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    //    var proxy = new ServiceProxy(serviceUrl);
    //    var BuyerDDClientID = '<%=ddlClients.ClientID%>';
    //    
    //    var jscriptPageVariables = null;

    //    $(function () {
    //        $("#" + BuyerDDClientID, '#main_content').change(function () {
    //            var clientId = $(this).val();
    //            populateDepartments($(this).val());
    //        });

    //        populateDepartments($("#" + BuyerDDClientID, '#main_content').val());
    //    });

    //    function populateDepartments(clientId, selectedDeptID) {
    //        bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID", { ClientID: clientId }, "Name", "DeptID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError)

    // }

</script>
<script type="text/javascript">

    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
        $(".th1").datepicker({ dateFormat: 'dd/mm/yy' });
        $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });
    });
  
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .header-text-back
    {
        font-size: 15px;
    }
    .tbl_bordr
    {
        border-color:#999;
     }
    .inner_tbl_td input[type="text"]
     {
         width:95% !important;
     }
   
</style>
<div class="print-box">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <h2 class="header-text-back">
                    Export to Excel</h2>
            </td>
        </tr>
        <tr>
            <td class="tbl_bordr">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper item_list" style=" width:99%;margin: 5px auto;">
                            <tr>
                                <td width="80%">
                                    <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                        <tr class="td-sub_headings">
                                            <td width="12%" valign="bottom">
                                                Search Text
                                            </td>
                                            <td width="10%" valign="bottom">
                                                Date Type
                                            </td>
                                            <%--<td width="8%" valign="bottom">Supply Type</td>--%>
                                            <%-- <td width="8%" valign="bottom">Term Type</td>--%>
                                            <td width="10%" valign="bottom">
                                                Year
                                            </td>
                                            <td width="18%" valign="bottom">
                                                Order Type
                                            </td>
                                            <td width="9%" valign="bottom">
                                                Client
                                            </td>
                                            <td width="9%" valign="bottom">
                                                From
                                            </td>
                                            <td width="15%" valign="bottom">
                                                To Date
                                            </td>
                                            <td width="10%" valign="bottom">
                                                buying house
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="inner_tbl_td">
                                                <asp:TextBox ID="txtsearch" class="text_align_left do-not-disable input_in" MaxLength="40"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlDateType" runat="server" CssClass="do-not-disable mo_dropdown_style1 input_in">
                                                    <%-- <asp:ListItem Text="None" Value="-1"></asp:ListItem>--%>
                                                    <asp:ListItem Text="Ex-Factory" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="DC" Value="2"></asp:ListItem>
                                                    <%--<asp:ListItem Text="AWB/BL DATE" Value="3"></asp:ListItem>--%>
                                                    <asp:ListItem Text="Order Date" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Shipmentdate" Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <%--<asp:DropDownList Width="125px" ID="ddlSupplyType" runat="server" CssClass="do-not-disable input_in">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="L" Value="1"></asp:ListItem>
                            <asp:ListItem Text="D" Value="2"></asp:ListItem>
                           
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnSupplyType" Value="-1" />--%>
                                                <asp:DropDownList Width="125px" ID="ddlfinancial" runat="server" CssClass="do-not-disable input_in">
                                                    <asp:ListItem Selected="True" Text="SELECT" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2010 - 11" Value="2010,2011"></asp:ListItem>
                                                    <asp:ListItem Text="2011 - 12" Value="2011,2012"></asp:ListItem>
                                                    <asp:ListItem Text="2012 - 13" Value="2012,2013"></asp:ListItem>
                                                    <asp:ListItem Text="2013 - 14" Value="2013,2014"></asp:ListItem>
                                                    <asp:ListItem Text="2014 - 15" Value="2014,2015"></asp:ListItem>
                                                    <asp:ListItem Text="2015 - 16" Value="2015,2016"></asp:ListItem>
                                                    <asp:ListItem Text="2016 - 17" Value="2016,2017"></asp:ListItem>
                                                    <asp:ListItem Text="2017 - 18" Value="2017,2018"></asp:ListItem>
                                                    <asp:ListItem Text="2018 - 19" Value="2018,2019"></asp:ListItem>
                                                    <asp:ListItem Text="2019 - 20" Value="2019,2020"></asp:ListItem>
                                                    <asp:ListItem Text="2020 - 21" Value="2020,2021"></asp:ListItem>
                                                    <asp:ListItem Text="2021 - 22" Value="2021,2022"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField runat="server" ID="hdnSupplyType" Value="-1" />
                                            </td>
                                            <td class="inner_tbl_td">
                                                <%--<asp:DropDownList Width="125px" ID="ddlTermType" runat="server" CssClass="do-not-disable input_in">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="FOB" Value="1"></asp:ListItem>
                            <asp:ListItem Text="CIF" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnTermType" Value="-1" />--%>
                                                <asp:DropDownList ID="ddlordertype" runat="server" Style="width: 140px!important">
                                                    <asp:ListItem Text="ALL" Value="0" Selected="True">
                            
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="BIPL" Value="1">
                            
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="Kasuka through BIPL" Value="2">
                            
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="Kasuka through IKANDI" Value="3">
                            
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="Value Added Style" Value="4">
                            
                                                    </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:DropDownList Width="125px" ID="ddlClients" runat="server" CssClass="do-not-disable input_in"
                                                    OnSelectedIndexChanged="ddlClients_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="th"></asp:TextBox>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <%-- <asp:DropDownList Width="125px" ID="ddlModeType" runat="server" CssClass="do-not-disable input_in">
                            <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="SEA" Value="1"></asp:ListItem>
                            <asp:ListItem Text="AIR" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnModeType" Value="-1" />--%>
                                                <asp:TextBox runat="server" ID="txtToDate" CssClass="th"></asp:TextBox>
                                            </td>
                                            <td class="inner_tbl_td">
                                                <%--<asp:DropDownList Width="125px" ID="ddlDepartment" runat="server" CssClass="do-not-disable input_in">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hiddenDeptId" Value="-1" />--%>
                                                <asp:DropDownList ID="ddlBH" runat="server" OnSelectedIndexChanged="ddlBH_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <%--<td class="inner_tbl_td">
              <asp:DropDownList Width="125px" ID="ddlPackingType" runat="server" CssClass="do-not-disable input_in">
                            <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="HANGING" Value="1"></asp:ListItem>
                            <asp:ListItem Text="FLAT" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnPackingType" Value="-1" /></td>--%>
                                        </tr>
                                        <tr class="td-sub_headings">
                                            <td width="10%" valign="bottom">
                                                Status
                                            </td>
                                            <td width="10%" valign="bottom">
                                                up to
                                            </td>
                                            <td width="10%" valign="bottom">
                                                Unit
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlStatusMode" runat="server">
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlStatusModeSequence" runat="server" Width="140px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlUnit" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </td> </tr> </table>
    <br />
    <div align="left">
        <asp:Button ID="btnExportToExcel" runat="server" Text="Submit" class="da_submit_button submit"
            OnClick="btnExportToExcel_Click" />
    </div>
</div>
