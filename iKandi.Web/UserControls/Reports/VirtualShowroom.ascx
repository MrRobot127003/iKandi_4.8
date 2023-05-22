<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VirtualShowroom.ascx.cs"
    Inherits="iKandi.Web.VirtualShowroom" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>

<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/noUiSlider/14.6.4/nouislider.min.css" /> <%--added by Girish--%>

<style type="text/css">
    .selectedTabs
    {
        background: #39589c none repeat scroll 0 0 !important;
        color: #fff !important;
    }
    
    .virtual_showroom_filters h3 a, .virtual_showroom_filters h3 a:visited, .virtual_showroom_filters h3 a:link
    {
        color: #fff;
        font-size: 12px;
        font-weight: bold;
        text-transform: capitalize;
    }
    .grid_heading
    {
        color: #fff;
        font-size: 16px;
        background-color: #39589c;
        color: #ffffff !important;
        text-align: center;
        padding: 5px 0px;
        text-transform: capitalize;
    }
    .go
    {
        width: 23px;
    }
    #accordion h3
    {
        position: relative;
    }
    
    .dropdown_arrow
    {
        border: solid white;
        border-width: 0 3px 3px 0;
        display: inline-block;
        padding: 4px;
        transform: rotate(45deg);
        -webkit-transform: rotate(45deg);
        -o-transform: rotate(45deg);
        -moz-transform: rotate(45deg);
        position: absolute;
        right: 10px;
    }
    .image-fade
    {
        -webkit-transform: rotate(-45deg);
        -webkit-transition-duration: .3s;
        top: 8px;
    }
    /*new work start : girish*/
    #slider
    {
        margin-left: 11px;
        margin-right: 10px;
        margin-top: 2px;
        margin-bottom: 10px;

    }
    #ShippedminValue, #ShippedmaxValue
    {
        display: inline-block;
        margin-left: 10px;
        width: 50px;
        text-align: center;
    }
    .noUi-handle {
      width: 20px;
      height: 20px;
      border-radius: 20%;
      background-color: #2196F3;
      box-shadow: none;
    }
    /*new work end : girish*/
    
</style>

<asp:Panel ID="pnlForm" runat="server" Width="100%">
    <div class="print-box">
        <div class="form_box">
            <div class="grid_heading">
                Virtual Showroom | Showroom Costing
            </div>
        </div>
        <div class="form_box">
            <table class="item_list" width="100%">
                <tr>
                    <th width="6%">
                        Style
                    </th>
                    <td width="14%" style="border-width: thin; border-color: Black; border-right-style: solid;">
                        <asp:TextBox ID="txtSty" runat="server" CssClass="costing" Style="width: 220px"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                    </td>
                    <td width="10%">
                        <asp:Button ID="btnAdd1" runat="server" Text="Add" class="add da_submit_button" OnClick="btnAdd1_Click" />
                    </td>
                    <th width="5%">
                        Currency
                    </th>
                    <td width="10%">
                        <asp:DropDownList ID="ddlCurr" runat="server">
                        </asp:DropDownList>
                    </td>
                    <th width="5%">
                        Markup
                    </th>
                    <td width="10%">
                        <asp:TextBox ID="txtMark" runat="server" MaxLength="2" onKeyPress="return VinCheck(event);"></asp:TextBox>
                    </td>
                    <th width="5%">
                        Commission
                    </th>
                    <td width="10%">
                        <asp:TextBox ID="txtComm" runat="server" MaxLength="2" onKeyPress="return VinCheck(event);"></asp:TextBox>
                    </td>
                    <th width="5%">
                        Version
                    </th>
                    <td width="10%">
                        <asp:TextBox ID="txtVer" runat="server" MaxLength="2" onKeyPress="return VinCheckAN(event);"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblerrormsg" runat="server" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            <br />
        </div>
    </div>
</asp:Panel>

<div id="tabs" class="ResetDiv">
    <ul class="tabs">
        <li>
            <asp:LinkButton runat="server" CssClass="selectedTabs" ID="lnkBtnStyles" Text="Styles"
                OnClick="lnkBtnStyles_Click"></asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton runat="server" ID="lnkBtnPrints" Text="Prints" OnClick="lnkBtnPrints_Click"></asp:LinkButton></li>
    </ul>
</div>

<asp:Panel runat="server" ID="pnlStyles">
    <div>
    </div>
    <br />
    <table width="100%">
        <tr>
            <td width="230px" valign="top" class="virtual_showroom_filters">
                <div id="accordion">
                    <div style="font-size: 12px; margin-top: 10px;">
                        Season:
                        <asp:DropDownList ID="ddlseason" runat="server" Style="font-size: 12px; margin-left: 0px;
                            width: 79%; padding: 4px; margin-bottom: 5px;">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   
                    <%--added by Girish: Start--%>
                     <h3>
                        <i class="dropdown_arrow"></i><a href="javascript:void(0)" refid="shippedQty_div" class="filter_open"
                            style="width: 100%; display: block;">Shippy Qty Range</a></h3>

                    <div id="shippedQty_div">
                         <div id="slider">
                         </div>       
                         <div style="width:100%;">               
              
                        <asp:TextBox runat="server" id="ShippedminValue" onKeyDown="return false;" style="width:25%;"></asp:TextBox>
                            To
                        <asp:TextBox runat="server" id="ShippedmaxValue" onKeyDown="return false;" style="width:25%;"></asp:TextBox>
                        </div> 
                        <asp:HiddenField runat="server" ID="hdnShippedMaxValue" Value="1"/>                    
                    </div>
                    <%--added by Girish: End--%>

                    <h3>
                        <i class="dropdown_arrow"></i><a href="javascript:void(0)" refid="f1" class="filter_open"
                            style="width: 100%; display: block;">Buyer</a></h3>
                    <div id="f1">
                        <asp:CheckBoxList runat="server" ID="cbListClients" CssClass="do-not-disable" Width="230px"
                            RepeatColumns="2" RepeatDirection="Vertical">
                        </asp:CheckBoxList>
                    </div>
                    <h3>
                        <i class="dropdown_arrow"></i><a href="javascript:void(0)" refid="f2" class="filter_close"
                            style="width: 100%; display: block;">Department</a></h3>
                    <div id="f2" class="hide_me">
                        <asp:HiddenField runat="server" ID="hiddenDeptId" Value="-1" />
                        <table style="width: 220px" id="cbListDepartments" class="do-not-disable" border="0">
                            <tr class="hide_me">
                                <td>
                                    <input checked type="checkbox" name="cbListDepartmentID" value="-1">
                                    <label for="ctl00_cph_main_content_VirtualShowroom1_cbListDepartments_0">
                                        All</label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <h3>
                        <i class="dropdown_arrow"></i><a href="#" refid="f3" class="filter_open" style="width: 100%;
                            display: block;">Garment Type</a></h3>
                    <div id="f3">
                        <asp:CheckBoxList runat="server" ID="cbListGarmentType" CssClass="do-not-disable"
                            Width="100%" RepeatColumns="2" RepeatDirection="Vertical">
                        </asp:CheckBoxList>
                    </div>
                    <h3>
                        <i class="dropdown_arrow"></i><a href="#" refid="f4" class="filter_open" style="width: 100%;
                            display: block;">Date Field</a></h3>
                    <div id="f4">
                        <div>
                            Is Order Placed:
                            <asp:RadioButtonList ID="rdOrderPlaced" runat="server" CssClass="do-not-disable no_border"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Both" Selected="true" Value="3"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div>
                            <asp:RadioButtonList ID="rdDateType" runat="server" CssClass="do-not-disable no_border"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="Order Date" Selected="true" Value="1"></asp:ListItem>
                                <asp:ListItem Text="DC Date" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div>
                            <span style="font-size: 12px;">Start:&nbsp;</span>
                            <asp:TextBox ID="txtStartDate" CssClass="th" runat="server" Style="padding: 2px;
                                margin-bottom: 5px;"></asp:TextBox>&nbsp;<u><span id="clearstartdate" runat="server"
                                    style="color: Blue" onclick="emptytxtbox(this)" title="txtStartDate">Clear</span></u>
                        </div>
                        <div>
                            <span style="font-size: 12px;">End:&nbsp;&nbsp;</span>
                            <asp:TextBox ID="txtEndDate" CssClass="th" runat="server" Style="padding: 2px; margin-bottom: 5px;"></asp:TextBox>&nbsp;<u><span
                                id="clearenddate" runat="server" style="color: Blue" onclick="emptytxtbox(this)"
                                title="txtEndDate">Clear</span></u>
                        </div>
                    </div>
                    <h3>
                        <i class="dropdown_arrow"></i><a href="#" refid="f5" class="filter_open" style="width: 100%;
                            display: block;">Is Best Seller</a></h3>
                    <div id="f5">
                        <asp:RadioButtonList ID="rdIsBestSeller" runat="server" CssClass="do-not-disable no_border"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="Both" Selected="true" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <h3>
                        <i class="dropdown_arrow"></i><a href="#" refid="f6" class="filter_open" style="width: 100%;
                            display: block;">BIPL Price</a></h3>
                    <div id="f6">
                        <div style="font-size: 12px;">
                            From:
                            <asp:TextBox runat="server" ID="txtBIPLPriceFrom" CssClass="do-not-disable numeric-field-with-two-decimal-places"
                                Style="margin: 5px 0;"></asp:TextBox>
                        </div>
                        <div style="font-size: 12px;">
                            To:&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox runat="server" ID="txtBIPLPriceTo" CssClass="do-not-disable numeric-field-with-two-decimal-places"
                                Style="margin-bottom: 5px;"></asp:TextBox>
                        </div>
                    </div>
                    <h3>
                        <i class="dropdown_arrow"></i><a href="#" refid="f7" class="filter_open" style="width: 100%;
                            display: block;">Trade Name</a></h3>
                    <u><span id="Span1" runat="server" style="color: Blue" onclick="deselecttrad(this)"
                        title="lstTradeNames">DeSelect All</span></u>
                    <div id="f7">
                        <asp:ListBox runat="server" SelectionMode="Multiple" Rows="6" CssClass="do-not-disable"
                            ID="lstTradeNames" Style="width: 100%; margin: 2px 0 5px 0;"></asp:ListBox>
                    </div>
                    <h3>
                        <i class="dropdown_arrow"></i><a href="#" refid="f8" class="filter_open" style="width: 100%;
                            display: block;">Title</a></h3>
                    <div id="f8">
                        <%-- <asp:TextBox Width="200px" Rows="6" runat="server" TextMode="MultiLine" CssClass="text_align_left"
                            ID="txtHeading" Text="BOUTIQUE INTERNATIONAL PVT. LTD. FASHION RANGE PRESENTATION">
                        </asp:TextBox>--%>
                        <asp:DropDownList ID="ddlHeading" runat="server" CssClass="text_align_left" Style="width: 100%;
                            padding: 5px; margin: 5px 0;">
                            <asp:ListItem Value="1" Text="BOUTIQUE INTERNATIONAL"></asp:ListItem>
                            <asp:ListItem Value="2" Text="KANDI Fashion"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div>
                    <asp:CheckBox ID="chkIsMoq" runat="server" Checked="true" Text="Display MOQ" />
                </div>
                <div>
                    <asp:CheckBox ID="chkIsprice" runat="server" Checked="true" Text="Display Price" />
                </div>
                <div>
                    <br />
                    <asp:Button ID="btnGo" runat="server" Text="Go" class="go do-not-disable" OnClick="btnGo_Click" />
                </div>
            </td>
            <td valign="top">
                <asp:DataList ID="dlStyles" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                    CssClass="no_padding virtual_showroom" Width="100%" CellSpacing="10" OnItemDataBound="dlStyles_ItemDataBound">
                    <ItemTemplate>
                        <div style="height: 150px; padding: 10px 0 10px 0;">
                            <a class="thickbox" href='<%# ResolveUrl( "~/uploads/style/" + Eval("StyleFrontImageURL").ToString())  %>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# ResolveUrl( "~/uploads/style/thumb-" + Eval("StyleFrontImageURL").ToString())  %>'
                                    Style="text-align: center" />
                            </a>
                        </div>
                        <div class="remarks_text2 grey_fg" valign="top" style="height: 120px; vertical-align: top;
                            padding-left: 5px;">
                            <%# Eval("Fabric").ToString().Replace("$$", "<br />") %><br />
                        </div>
                        <%--<div><asp:Label Height="100px" ID="lblFabric111" runat="server" class="ccgsm_color" Text='<%# Eval("CCGSM")%>'></asp:Label></div>--%>
                        <div class="" style="height: 20px;">
                            <%# iKandi.Common.Constants.GetCurrencySign(Eval("Currency").ToString()) + Eval("PriceQuoted", "{0:0.00}") %>
                        </div>
                        <div class="grey_fg" style="height: 20px;">
                            MOQ:
                            <%# Eval("Minimums","{0:N0}")%>
                            UNITS</div>
                        <div style="height: 20px;">
                            <asp:CheckBox runat="server" ID="chkCheckBox" class="chk-style" Checked='<%# Convert.ToBoolean( Eval("IsSelected") )%>' />
                            <%# Eval("StyleNumber") %>
                            <asp:HiddenField runat="server" ID="hdnStyleID" Value='<%# Eval("StyleID") %>' />
                            <asp:ImageButton runat="server" ID="btnRemove" ImageUrl="~/App_Themes/ikandi/images/deleteIcon.gif"
                                OnCommand="dlStyles_click1" CommandName="RemoveStyle" CausesValidation="false"
                                Visible="false" CommandArgument='<%# Eval("StyleID") %>' /><%--StyleNumber--%>
                            <asp:HiddenField runat="server" ID="hdnStyleNo" Value='<%# Eval("StyleNumber") %>' />
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <br />
            </td>
        </tr>
    </table>
    <br />
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="30" CurrentPageStringFormat="Page {0} of {1} ({2} records) &amp;nbsp;-&amp;nbsp; "
            DataSourceID="" FirstPageText="&amp;lt;&amp;lt;" LastPageText="&amp;gt;&amp;gt;"
            NextPageText="&amp;gt;" PreviousPageText="&amp;lt;" ShowCurrentPage="True" TotalRecords="0"></cc1:HyperLinkPager>
    </div>
</asp:Panel>

<asp:Panel runat="server" ID="pnlPrints" Visible="false">
    <table width="100%">
        <tr>
            <td width="230px" valign="top" class="virtual_showroom_filters">
                <div id="accordion">
                    <div>
                        Season :
                        <asp:DropDownList ID="ddlSeasonPrint" runat="server">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <h3>
                        <a href="javascript:void(0)" refid="pf1" class="filter_open">Buyer</a></h3>
                    <div id="pf1">
                        <asp:CheckBoxList runat="server" ID="ddlPrintClients" CssClass="do-not-disable" Width="230px"
                            RepeatColumns="2" RepeatDirection="Vertical">
                        </asp:CheckBoxList>
                    </div>
                    <h3>
                        <a href="javascript:void(0)" refid="pf2" class="filter_open">Print Type</a></h3>
                    <div id="pf2">
                        <asp:CheckBoxList runat="server" ID="ddlPrintType" CssClass="do-not-disable" Width="230px"
                            RepeatColumns="2" RepeatDirection="Vertical">
                        </asp:CheckBoxList>
                    </div>
                    <h3>
                        <a href="javascript:void(0)" refid="pf3" class="filter_open">Purchase Date</a></h3>
                    <div id="pf3">
                        <div>
                            Start:
                            <asp:TextBox ID="txtPrintStartDate" Width="90px" CssClass="do-not-disable th" runat="server"></asp:TextBox>&nbsp;<u><span
                                id="psd" runat="server" style="color: Blue" onclick="emptytxtbox(this)" title="txtPrintStartDate">Clear</span></u>
                        </div>
                        <div>
                            End:&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtPrintEndDate" Width="90px" CssClass="do-not-disable th" runat="server"></asp:TextBox>&nbsp;<u><span
                                id="ped" runat="server" style="color: Blue" onclick="emptytxtbox(this)" title="txtPrintEndDate">Clear</span></u>
                        </div>
                    </div>
                    <h3>
                        <a href="javascript:void(0)" refid="pf4" class="filter_open">Status</a></h3>
                    <div id="pf4">
                        <asp:RadioButtonList ID="rdStatus" runat="server" CssClass="do-not-disable no_border"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="Both" Selected="true" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Sold" Value="1"></asp:ListItem>
                            <asp:ListItem Text="UnSold" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div>
                    <br />
                    <asp:Button ID="btnPrintGo" runat="server" OnClick="btnPrintGo_Click" Text="Go" CssClass="do-not-disable go"
                        OnClientClick="javascript:return validatedate();" />
                </div>
            </td>
            <td valign="top" id="dlst">
                <asp:DataList ID="dlPrints" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"
                    CssClass="no_padding virtual_showroom" Width="100%" CellSpacing="10">
                    <ItemTemplate>
                        <div class="" style="height: 200px; padding: 10px 0 10px 0;">
                            <a href='<%# ResolveUrl( "~/uploads/print/" + Eval("ImageUrl").ToString())  %>' class="thickbox">
                                <asp:Image ID="Image1" Height="200px" runat="server" ImageUrl='<%# ResolveUrl( "~/uploads/print/thumb-" + Eval("ImageUrl").ToString())  %>' />
                            </a>
                        </div>
                        <div class="remarks_text2 grey_fg" valign="top" style="height: 100px; vertical-align: top;
                            padding-left: 5px;">
                            <%# Eval("Description")%>
                        </div>
                        <div class="" style="height: 20px;">
                            <%#  Eval("Status")%>
                        </div>
                        <div style="height: 20px;" class="grey_fg">
                            <asp:CheckBox runat="server" ID="chkCheckBox" class="chk-print" Checked='<%# Convert.ToBoolean( Eval("IsSelected") )%>' />
                            PRD
                            <%# Eval("PrintNumber") %>
                            <asp:HiddenField runat="server" ID="hdnPrintID" Value='<%# Eval("PrintID") %>' />
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    <br />
    <div style="margin-top: 5px; text-align: right;">
        <cc1:HyperLinkPager ID="HyperLinkPager2" runat="server" PageSize="30">
        </cc1:HyperLinkPager>
    </div>
</asp:Panel>

<asp:Button ID="btnPrint" runat="server" CssClass="print da_submit_button" Text="Print"
    OnClick="btnPrint_Click"></asp:Button>
<asp:HiddenField runat="server" ID="hdnSelectedStyles" />
<asp:HiddenField runat="server" ID="hdnSelectedPrints" />
<asp:HiddenField runat="server" ID="hdnMode" Value="0" />
<asp:HiddenField ID="hdnsearchstylecount" runat="server" Value="0" />

<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var BuyerDDClientID = '<%=cbListClients.ClientID%>';
    var DeptDDClientID = 'cbListDepartments';
    var jscriptPageVariables = null;
    var selectedDept;
    var hdnDeptIdClientID = '<%=hiddenDeptId.ClientID %>';



    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
    });

    $(function () {

        $("#accordion h3 a").click(function () {

            var obj = $("#" + $(this).attr("refId"), "#accordion");

            if (obj.css("display") == 'none') {
                obj.show();

                $(this)[0].className = "filter_open";
            }
            else {
                obj.hide();
                $(this)[0].className = "filter_close";
            }

        });

        $('input:checkbox').checkbox({ cls: 'jquery-safari-checkbox', empty: '/App_themes/ikandi/images/empty.png' });

        $(".chk-style").click(function () {

            var chkbox = $(this).find("input");

            var styleID = $(this).parents("div").find(":hidden").val();

            if (!chkbox.is(':checked')) {

                var objSIDs = $("#" + jscriptPageVariables.hdnSelectedStyleClientID);
                var sIDs = objSIDs.val();

                if (sIDs == '') return;

                sIDs = "," + sIDs + ",";

                if (sIDs.indexOf(styleID) > -1) {

                    sIDs = sIDs.replace(styleID, '');
                    sIDs = sIDs.substring(1);
                    sIDs = sIDs.substring(0, sIDs.length - 1);

                    alert(sIDs);

                    objSIDs.val(sIDs);

                }
            }

        });

        $(".chk-print").click(function () {

            var chkbox = $(this).find("input");

            var printID = $(this).parents("div").find(":hidden").val();

            if (!chkbox.is(':checked')) {

                var objPIDs = $("#" + jscriptPageVariables.hdnSelectedPrintClientID);
                var pIDs = objPIDs.val();

                if (sIDs == '') return;

                pIDs = "," + pIDs + ",";

                if (pIDs.indexOf(printID) > -1) {

                    pIDs = pIDs.replace(printID, '');
                    pIDs = pIDs.substring(1);
                    pIDs = pIDs.substring(0, pIDs.length - 1);

                    alert(pIDs);

                    objPIDs.val(pIDs);

                }
            }

        });


        // populateDepartments($("#" + BuyerDDClientID, '#main_content').val(), $("#" + hdnDeptIdClientID, "#main_content").val());

        OnClientClick(null);
    });

    function populateDepartments(clientIds) {



        if (clientIds == null || clientIds == '') return;

        var objSelectedCheckBox = $("#" + DeptDDClientID + " input:checked");

        var selectedDeptIds = $("#" + hdnDeptIdClientID, "#main_content").val();

        if (selectedDeptIds == "-1")
            selectedDeptIds = "";



        $("#" + hdnDeptIdClientID, "#main_content").val("");

        objSelectedCheckBox.each(function () {

            var id = $(this).attr("mainValue");

            if (id != null && id != "-1") {

                if (selectedDeptIds == '') {
                    selectedDeptIds = id;
                }
                else {
                    selectedDeptIds += "," + id;
                }
            }

        });

        if (selectedDeptIds != "" && selectedDeptIds != "-1")
            $("f2").click();

        selectedDeptIds = "," + selectedDeptIds + ",";

        $("#" + DeptDDClientID).find("tr:gt(0)").remove();



        proxy.invoke("GetClientDeptsByClientIDs", { ClientIDs: clientIds }, function (results) {

            for (var i = 0; i < results.length; i++) {

                var isChecked = false;
                if (selectedDeptIds.indexOf("," + results[i].DeptID + ",") > -1) {

                    isChecked = true;
                }

                addItemsToCheckBoxListControl(results[i].Name, results[i].DeptID, DeptDDClientID, isChecked);

            }

            $('input:checkbox').checkbox({ cls: 'jquery-safari-checkbox', empty: '/App_themes/ikandi/images/empty.png' });

        }, onPageError, false, false);


        // bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientIDs", { ClientIDs: clientIds }, "Name", "DeptID", true, selectedDeptID, onPageError, setDeptName)

    }

    function setDeptName() {
        selectedDept = $("#" + DeptDDClientID, "#main_content").val();

        $("#" + hdnDeptIdClientID, "#main_content").val(selectedDept);
        $("#" + DeptDDClientID, "#main_content").children(":first").text("ALL");

    }

    function OnClientClick(prmThis) {

        var selectedClientIds = "";

        var clientId = '';

        if (prmThis != null) {
            if (prmThis.checked)
                clientId = $(prmThis).parents("span").attr("mainValue");
            else
                selectedClientIds = $(prmThis).parents("span").attr("mainValue");
        }

        var objSelectedCheckBox = $("#" + BuyerDDClientID + " input:checked");

        objSelectedCheckBox.each(function () {

            var id = $(this).parents("span").attr("mainValue");

            if (clientId == '' || clientId != id) {

                if (selectedClientIds == '') {
                    selectedClientIds = id;
                }
                else {
                    selectedClientIds += "," + id;
                }

            }
        });

        populateDepartments(selectedClientIds);
    }
    function emptytxtbox(evntarg) {
        var prntsrt = '<%=txtPrintStartDate.ClientID %>';
        var prntend = '<%=txtPrintEndDate.ClientID %>';
        var stysrt = '<%=txtStartDate.ClientID %>';
        var styend = '<%=txtEndDate.ClientID %>';
        //var r = document.getElementById(txt).value;
        //"clearstartdate""clearenddate"
        if (evntarg.title == "txtPrintEndDate")
            document.getElementById(prntend).value = "";
        if (evntarg.title == "txtPrintStartDate")
            document.getElementById(prntsrt).value = "";
        if (evntarg.title == "txtEndDate")
            document.getElementById(styend).value = "";
        if (evntarg.title == "txtStartDate")
            document.getElementById(stysrt).value = "";
    }
    function messegenotfound(eventval) {
        var hdnsstylecount = '<%=hdnsearchstylecount.ClientID %>';
        var searchstylecount = document.getElementById(hdnsstylecount).value;
        if (searchstylecount == "1") {
            script = "ShowHideMessageBox(true, 'Search pattern not found.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
        }
    }
    function msgforvercheck() {
        // var txtver = '<%=txtSty.ClientID %>';
        //var txtsty = document.getElementById(txtver).value;
        //if(txtsty.Trim().length>=8&&

    }

    function validatedate() {
        var stdate = document.getElementById("<%=txtPrintStartDate.ClientID %>");
        var enddate = document.getElementById("<%=txtPrintEndDate.ClientID %>");
        var retvalue = true;
        if (stdate.value == '' && enddate.value != '') {
            retvalue = false;
            alert('Please Enter Start Date for Searching.');
            stdate.focus();
        }
        else if (stdate.value != '' && enddate.value == '') {
            retvalue = false;
            alert('Please Enter End Date for Searching.');
            enddate.focus();
        }
        return retvalue;
    }

    $(function () {

        $("input[type=text].costing").autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100 });

    });

    function VinCheck(e) {
        var keynum;
        var keychar;
        var charcheck;
        if (window.event) // IE
            keynum = e.keyCode;
        else if (e.which) // Netscape/Firefox/Opera
            keynum = e.which;
        keychar = String.fromCharCode(keynum);
        charcheck = /[0-9]/;
        return charcheck.test(keychar);
    }
    function VinCheckAN(e) {
        var keynum;
        var keychar;
        var charcheck;
        if (window.event) // IE
            keynum = e.keyCode;
        else if (e.which) // Netscape/Firefox/Opera
            keynum = e.which;
        keychar = String.fromCharCode(keynum);
        charcheck = /[a-zA-Z0-9]/;
        return charcheck.test(keychar);
    }

    function deselecttrad(ev) {
        var deselect = document.getElementById('<%=lstTradeNames.ClientID %>')
        deselect.selectedIndex = -1;
    }

    $(document).ready(function () {
        $(".filter_open").click(function () {
            $(".dropdown_arrow").toggleClass("image-fade");
        });
    });
    
</script>

<%--added by Girish : Start--%>
<script src="https://cdnjs.cloudflare.com/ajax/libs/noUiSlider/14.6.4/nouislider.min.js"></script>

<script type="text/javascript">

    var slider = document.getElementById('slider');
    var minVal = document.getElementById('<%=ShippedminValue.ClientID %>');
    var maxVal = document.getElementById('<%=ShippedmaxValue.ClientID %>');

    noUiSlider.create(slider, {
        start: [1, 1],
        connect: true,
        step: 1,
        range: {
            'min': 1,
            'max': parseInt($('#' + '<%=hdnShippedMaxValue.ClientID %>').val())
        }
    });

    slider.noUiSlider.on('update', function (values, handle) {
        if (handle === 0) {
            minVal.value = parseInt(values[handle]) == "1" ? "MIN" : parseInt(values[handle]);
        }
        if (handle === 1) {
            maxVal.value = parseInt(values[handle]) == "1" ? "MAX" : parseInt(values[handle]);
        }
    });

    minVal.addEventListener('change', function () {
        slider.noUiSlider.set([this.value, null]);
    });

    maxVal.addEventListener('change', function () {
        slider.noUiSlider.set([null, this.value]);
    });

    minVal.addEventListener('input', function () {
        var val = parseInt(this.value);
        var max = parseInt(maxVal.value);
        if (val > max) {
            this.value = max;
        }
        slider.noUiSlider.set([this.value, null]);
    });

    maxVal.addEventListener('input', function () {
        var val = parseInt(this.value);
        var min = parseInt(minVal.value);
        if (val < min) {
            this.value = min;
        }
        slider.noUiSlider.set([null, this.value]);
    });

</script>
<%--added by Girish : End--%>
