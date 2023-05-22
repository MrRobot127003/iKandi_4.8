<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="CostingSheetNew.aspx.cs" Inherits="iKandi.Web.Internal.Sales.CostingSheetNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        var costingSheetCollection;
        var costingSheetIframeCollection;
        var tabLICollection;

        var txtStyleNumber1;
        var txtStyleNumber2;

        var ddlBuyer;
        var ddlDept;

        var activeTab;
        var activeCostingSheet;
        var hdnActive;
        var isPageLoad;

        $(function () {
            isPageLoad = true;
            $('#<%=rblItem.ClientID %> input').change(function () {
                debugger;
                //alert((this).value);
                if ((this).value == '2') {
                    $('.hideme').show();
                }
                else {
                    $('.hideme').hide();
                    document.getElementById('r1Average').checked = false;
                    document.getElementById('r2CAD').checked = false;
                    document.getElementById('r3OBSheet').checked = false;
                    document.getElementById('r4SAM').checked = false;
                    document.getElementById('r5OB').checked = false;
                    document.getElementById('rd6CMT').checked = false;
                }
            });
            hdnActive = $('#<%= hdnActive.ClientID %>');
            $('.costing-tab-li').click(function () {

                activeTab = $(this);
                ShowCostingSheet(this, $(this).attr('StyleId'), $(this).attr('StyleNumber'));
            });

            $('.secure_center_contentWrapper').css('position', 'static');

            costingSheetIframeCollection = $('.costing-iframe');
            costingSheetCollection = $('.costing-sheet');
            tabLICollection = $('#tabs_costing li');

            if (costingSheetIframeCollection.length > 0) {
                $('.add-style-number').show();
                // window.setTimeout(ClickFirstTab, 1000);
            }
            else {
                $('.add-style-number').hide();
            }

            if (costingSheetCollection.length > 0) {
                $(costingSheetCollection[0]).show();
            }

            if (tabLICollection.length > 0) {
                //updated by bharat
                tabLICollection.css('background', '#39589c');
                $(tabLICollection[0]).css('background', 'green');

                //                $(tabLICollection[0]).css('background', '#39589c');

            }

            sheetLoadingCounter = tabLICollection.length;

            $('.costing-iframe').load(function () {

                var tab = $("#tab-" + $(this).parents("div").attr("id"));

                tab.find("#loading-icon").hide();

                SetActiveTabToFirstTabAfterSave(hdnActive.val());

                if (!isPageLoad) {
                    if (activeCostingSheet != undefined) {
                        //activeCostingSheet.contents().find('.style-table').hide();
                        //activeCostingSheet.contents().find('.costing_form').show();
                    }

                    return;
                }

                isPageLoad = false;
                if (activeCostingSheet == undefined) {
                    activeCostingSheet = $($('.costing-iframe')[0]);
                    // activeCostingSheet.height($(this).contents().find('.costing-sheet-height').text());
                }

                //ClickFirstTab();

                var collection = getQueryString(activeCostingSheet[0].contentWindow.window.location.search);

                var queryString = collection['cid'];

                if (queryString == -1 || queryString == undefined) {
                    var txtStyleNumber = $(this).contents().find('.costing-style');
                    var styleNumber = $(this).attr('StyleNumber');

                    txtStyleNumber.val(styleNumber);

                    var txtStyleNumberView = activeCostingSheet.contents().find('.costing-style-number-view');
                    txtStyleNumberView.val(styleNumber);
                    txtStyleNumberView.focus();
                    txtStyleNumberView.blur();
                }

                var scrollHeight = $(this).contents().find('body').attr('scrollHeight');

                //var scrollHeight = $(this).contents().document.body.find('table').attr('scrollHeight');
                // debugger;
                if (scrollHeight != 0)
                    $(this).height(850);
                // alert(scrollHeight);

            });

            txtStyleNumber1 = $('#<%= txtStyleNumber1.ClientID %>');
            txtStyleNumber2 = $('#<%= txtStyleNumber2.ClientID %>');
            hdnActive = $('#<%= hdnActive.ClientID %>');

            ddlBuyer = $('#<%= ddlBuyer.ClientID%>');
            ddlDept = $('#<%= ddlDept.ClientID%>');

            txtStyleNumber2.keyup(function () {

                var objTextBox = $(this);

                if (objTextBox.val().indexOf('$') > -1) {
                    $("#select_orders").show();
                }
                else {
                    $("#select_orders").hide();
                }
            });

            $('.save-style-number').click(function () {

                //added by abhishek on 23/5/2017
                //debugger;
                var Average_val = 0;
                var CAD_val = 0;
                var OBSheet_val = 0;
                var SAM_val = 0;
                var OB_val = 0;
                var CMT_val = 0;

                if (document.getElementById('r1Average').checked) {
                    //rate_value = document.getElementById('r1Average').value;
                    //alert(rate_value);
                    Average_val = 1;
                }
                if (document.getElementById('r2CAD').checked) {
                    //rate_value = document.getElementById('r2CAD').value;
                    //alert(rate_value);
                    CAD_val = 1;
                }
                if (document.getElementById('r3OBSheet').checked) {
                    //rate_value = document.getElementById('r1Average').value;
                    //alert(rate_value);
                    OBSheet_val = 1;
                }
                if (document.getElementById('r4SAM').checked) {
                    //rate_value = document.getElementById('r1Average').value;
                    //alert(rate_value);
                    SAM_val = 1;
                }
                if (document.getElementById('r5OB').checked) {
                    //rate_value = document.getElementById('r1Average').value;
                    //alert(rate_value);
                    OB_val = 1;
                }
                if (document.getElementById('rd6CMT').checked) {
                    //rate_value = document.getElementById('r1Average').value;
                    //alert(rate_value);
                    CMT_val = 1;
                }

                //debugger;
                var styleNumber = txtStyleNumber1.val() + ' ' + $.trim(txtStyleNumber2.val());
                var selectedItemSample = $('#<%= rblItem.ClientID %> input:checked').val();



                proxy.invoke('GetStyleByNumber', { StyleNumber: styleNumber },
                function (objStyle) {

                    if (null != objStyle && objStyle.StyleID != -1) {
                        //debugger;
                        ShowHideValidationBox(true, 'Style Number already exists.', 'Costing Sheet - Add Style Number');
                    }
                    else {
                        //debugger;
                        var collection = getQueryString(activeCostingSheet[0].contentWindow.window.location.search);
                        var costingId = collection['cid'];

                        var parentStyleNumber = $(activeCostingSheet[0].contentWindow.document).find('.costing-style-number-view').val();

                        var collection1 = getQueryString();
                        var newStyle;
                        if (collection1['sn'] != null && collection1['sn'] != '') {
                            var newStyleCollection = collection1['sn'].split(' ');

                            if (collection1['sn'].indexOf('$') > -1) {
                                newStyle = newStyleCollection[0];
                                newStyle = newStyle + ' ' + $.trim(txtStyleNumber2.val());
                            }
                            else {
                                newStyle = styleNumber;
                            }

                            //newStyle is used to ensure that styledescription thing stays intact in the querystring...
                        }

                        var orderIDs = $("#hdnOrderIDs").val();
                        hdnActive.val(styleNumber);
                        var userID = $("#<%=hdnUserID.ClientID%>").val();
                        if (costingId == -1) {
                            alert('With out save base costing data, version can not be created')
                            return false;
                        }
                        else {
                            proxy.invoke('CloneStyleNumber_New', { parentStyleNumber: parentStyleNumber, styleNumber: styleNumber, clientId: -1, departmentId: -1, costingId: costingId, orderIDs: orderIDs, selectedItemSample: selectedItemSample, avg: Average_val, Cad: CAD_val, obsheet: OBSheet_val, sam: SAM_val, ob: OB_val, cmt: CMT_val, userID: userID },
                    function (success) {

                        //debugger;
                        txtStyleNumber2.val('');
                        ddlBuyer.val('');
                        ddlBuyer.change();

                        if (success) {
                            //debugger;
                            ShowHideMessageBox(true, 'Style Number saved successfully.', 'Costing Sheet - Add Style Number', RefreshPage(newStyle));
                        }
                        else {
                            ShowHideValidationBox(true, 'Some error occured in saving Style Number.', 'Costing Sheet - Add Style Number', HideAddStyleNumberBox);
                        }
                    });
                        }
                    }
                });
            });

            $('.cancel').click(function () {
                HideAddStyleNumberBox();

                txtStyleNumber2.val('');
                ddlBuyer.val('-1');
                ddlBuyer.change();
                hdnActive.val('');
            });

            window.setTimeout(SelectHighlightedTab, 6000);


        });

        function SelectHighlightedTab() {

            var collection = getQueryString();
            var currentTab = activeTab;

            if (collection['sn'] != null && collection['sn'] != '') {
                //activeTab = tabLICollection.find("a:contains('" + collection['sn'].toUpperCase() + "')").parents("LI");

                var styleNumber = $.trim((collection['sn'].replace("+", ' ').replace("+", ' '))).toUpperCase();
                // alert(styleNumber + ' -- ' + collection['sn']);

                styleNumber = styleNumber.replace('$', ' ');
                styleNumber = styleNumber.replace('!', ''); //getStylefromDesc(styleNumber);
                styleNumber = $.trim(styleNumber);
                activeTab = tabLICollection.find("a").filter(function () {
                    return $.trim($(this).text().toUpperCase()) == styleNumber;
                }).parents("LI");

                if (activeTab != null && activeTab.length > 0 && currentTab != activeTab) {
                    activeTab.click();
                    return;
                }
                else {
                    if (activeTab == null)
                        activeTab = $(tabLICollection[0]);
                }
            }

            activeTab.click();
        }

        function SetActiveTabToFirstTabAfterSave(val) {
            // debugger;
            if (val == '') {
                if (activeTab == undefined || activeTab.attr('StyleNumber') == $('.costing-tab-li:first').attr('StyleNumber')) return;

                var newActiveTab = activeTab.clone(true).insertBefore('.costing-tab-li:first');
                activeTab.remove();

                tabLICollection = $('#tabs_costing li');
                ShowCostingSheet(newActiveTab[0], newActiveTab.attr('StyleId'), newActiveTab.attr('StyleNumber'));
            }
            else {
                tabLICollection = $('#tabs_costing li');
                var newActiveTab = tabLICollection.find("a").filter(function () {
                    return $.trim($(this).text().toUpperCase()) == val;
                }).parents("LI");
                ShowCostingSheet(newActiveTab[0], newActiveTab.attr('StyleId'), newActiveTab.attr('StyleNumber'));
            }
        }

        function ClickFirstTab() {


            if (tabLICollection.length > 0) {

                //                var collection = getQueryString();

                //                if (collection['sn'] != null && collection['sn'] != '') {
                //                    activeTab = tabLICollection.find("a:contains('" + collection['sn'].toUpperCase() + "')").parents("LI");

                //                    if (activeTab !=null && activeTab.length > 0) {
                //                        activeTab.click();
                //                        return;
                //                    }
                //                }

                activeTab = $(tabLICollection[0]);
                $(tabLICollection[0]).click();
            }
        }

        function ShowCostingSheet(sender, styleId, styleNumber) {
            //debugger;
            tabLICollection.css('background', '#39589c');
            //            $(sender).css('background', '#39589c');
            $(sender).css('background', 'green');

            $('.costing-sheet').hide();
            $('#' + styleId).show();

            activeCostingSheet = $('#' + styleId).find('.costing-iframe');

            if (activeCostingSheet.length == 1) {
                //debugger;
                //activeCostingSheet.contents().find('.style-table').hide();
                //activeCostingSheet.contents().find('.costing_form').show();

                //activeCostingSheet.height(activeCostingSheet.contents().find('body').attr('scrollHeight'));
                //activeCostingSheet.height(activeCostingSheet.contents().document.body).find('div').attr('scrollHeight'); //Commented BY G2 03-10-2016
                txtStyleNumber = activeCostingSheet.contents().find('.costing-style');
                txtStyleNumber.val(styleNumber);

                // var collection = activeCostingSheet[0].contentWindow.window.getQueryString();
                var collection = getQueryString(activeCostingSheet[0].contentWindow.window.location.search);
                var queryString = collection['cid'];

                if (queryString == -1 || queryString == undefined) {
                    var txtStyleNumberView = activeCostingSheet.contents().find('.costing-style-number-view');
                    txtStyleNumberView.val(styleNumber);
                    txtStyleNumberView.focus();
                    txtStyleNumberView.blur();
                }
            }
        }


        function getStylefromDesc(styleNumber) {

            var sn = $.trim(styleNumber);
            if (styleNumber.indexOf('$') > -1) {
                if (styleNumber != '' && sn.split('$').length == 1 && sn.indexOf('$') > -1) {

                    sn = sn.replace('!', '');

                    if (sn.indexOf(' ') > -1)
                        sn = sn.substring(0, sn.lastIndexOf(' '));

                    return sn;
                }
                else if (styleNumber != '' && sn.split('$').length == 2) {
                    var sn = $.trim(styleNumber);
                    sn = sn.replace('!', '');

                    if (sn.indexOf(' ') > -1)
                        sn = sn.substring(0, sn.lastIndexOf(' '));

                    sn = sn.replace('$', ' ');

                    return sn;

                }
            }
            else {
                if (sn.split(' ').length == 3)
                    sn = sn.substring(0, sn.lastIndexOf(' '));
                return sn;
            }
        }

        function ShowAddStyleNumberBox() {
            debugger

            var collection = getQueryString();
            var styleNumber = (collection['sn'] == undefined) ? '' : collection['sn'];

            if (styleNumber.indexOf('+') > -1) {
                styleNumber = styleNumber.replace('+', ' ');
                //                styleNumber = styleNumber.replace('+', ' ');
                //                styleNumber = styleNumber.replace('+', ' ');
            }

            txtStyleNumber1.val(getStylefromDesc(styleNumber));

            $('.style_number_box_background').show();
            $('.style_number_box').show();
            $('.select_orders').hide();
        }

        function HideAddStyleNumberBox() {
            $('.style_number_box').hide();
            $('.style_number_box_background').hide();
        }

        function PopulateDepartments(sender) {
            var clientId = $(sender).val();
            var ddlDeptId = '<%= ddlDept.ClientID%>';

            bindDropdown(serviceUrl, ddlDeptId, 'GetClientDeptsByClientID', { ClientID: clientId }, 'Name', 'DeptID', false, '', onPageError)
        }

        function RefreshPage(styleNumber) {

            // $('#<%= btnPostBack.ClientID %>').click();
            window.location = "costingSheetNew.aspx?sn=" + styleNumber;
        }

        function onPageError(error) {
            alert(error.Message + ' -- ' + error.detail);
        }

        function LaunchOrdersByStyleVariation() {
            var parentStyleNumber = $(activeCostingSheet[0].contentWindow.document).find('.costing-style-number-view').val();

            proxy.invoke("GetOrdersByStyleVariations", { StyleNumber: parentStyleNumber }, function (result) {
                openQuickLayerFlexible(result);
            }, onPageError, false, false);
        }

        function GetSelectedOrderIDs() {

            var orderIDs = '';
            $("input:checked", "#divOrdersByStyleVariation").each(function (i) {
                if ($(this).is(':checked')) {
                    var objRow = $(this).parents("tr");
                    var orderID = objRow.find(".hdn-orderid").val();

                    if (orderIDs == '')
                        orderIDs = orderID;
                    else
                        orderIDs += "," + orderID;
                }
            });

            $("#hdnOrderIDs").val(orderIDs);
        }


        function checkChar(tBox) {
            var curVal = tBox.value;

        }

        function VinCheck(e) {
            var keynum;
            var keychar;
            var charcheck;
            if (window.event)
                keynum = e.keyCode;
            else if (e.which)
                keynum = e.which;
            keychar = String.fromCharCode(keynum);
            charcheck = /[a-zA-Z0-9]/;
            return charcheck.test(keychar);

        }    
    </script>
    <style>
        #tabs_costing li div:hover
        {
            background: #f9ddf405 !important;
        }
        #main_content #tabs_costing li div :hover
        {
            color: yellow !important;
        }
        #tabs_costing li a
        {
            color: #fff !important;
        }
        #tabs_costing li
        {
            margin-top: 2px;
        }
        #tabs_costing li span
        {
            background: #fff;
            border: 0px;
            top: 0px;
            font-size: 15px;
            height: 14px;
            line-height: 12px;
            padding: 3px 6px 0;
        }
        #tabs_costing li div
        {
            border-right-color: #f5f5f5;
            border-top: 0px;
            border-bottom: 0px;
            border-left: 0px;
        }
        #tabs_costing li div:first-child
        {
            border-left: 1px solid #999999 !important;
        }
        .style_number_box
        {
            border: solid 5px #cbcbce !important;
            border-radius: 3px;
        }
        .style_number_box
        {
            width: 288px;
            padding: 0px 5px;
        }
        .style_number_box input[type='text']
        {
            padding-left: 4px;
        }
        .style_number_box input[type='radio']
        {
            position:relative;
            top:3px;
        }
        .style_number_box .da_submit_button
        {
            position:relative;
            top:-2px;
        }

    </style>
    <div id="tabs_costing">
        <ul style="float: left; width: 80%;">
            <asp:HiddenField ID="hdnIsUcknowledge" runat="server" />
            <asp:Repeater ID="repeaterCostingTabs" runat="server">
                <ItemTemplate>
                    <li class="costing-tab-li" id='<%# "tab-" + Eval("StyleID").ToString() %>' styleid='<%# Eval("StyleID") %>'
                        stylenumber='<%# Eval("StyleNumber") %>'>
                        <div>
                            <a id="costingTab" href="javascript:void(0)">
                                <%# Convert.ToString( Eval("StyleNumber")).ToUpper() %></a>
                            <!-- <img src="/App_Themes/ikandi/images/lightbox-ico-loading.gif" id="loading-icon" height="13px" />-->
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <li id="addButton" runat="server" style="border: 0px !important; background: #fff !important;">
                <span onclick="ShowAddStyleNumberBox()" class="add-style-number" style="cursor: pointer;"
                    title="Click to add new style version">+</span> </li>
        </ul>
    </div>
    <asp:Repeater ID="repeaterCostingSheets" runat="server">
        <ItemTemplate>
            <div id='<%# Eval("StyleID") %>' style="display: none" class="costing-sheet">
                <iframe id="ifCosting" runat="server" 
                src='<%# "TabCostingSheetNew.aspx?cid=" + Convert.ToInt32(Eval("CostingID")) +"&StyleID="+ Convert.ToInt32(Eval("StyleID")) +"&ClientID="+ Convert.ToInt32(Eval("ClientID")) +"&DepartmentID="+ Convert.ToInt32(Eval("DepartmentID")) +"&IsUcknowledge=" + hdnIsUcknowledge.Value  %>'
                    width="100%" class="costing-iframe" frameborder="0"
                    stylenumber='<%# Eval("StyleNumber") %>' style="height:100vh; "></iframe>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="style_number_box_background">
    </div>
    <div class="style_number_box">
        <table width="100%" cellpadding="6px">
            <tr>
                <td colspan="2">
                    <asp:RadioButtonList ID="rblItem" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Without Sample" Selected="True" Value="1"></asp:ListItem>
                        <asp:ListItem Text="With Sample" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Style Number:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="do-not-allow-typing" ID="txtStyleNumber1" Width="95px"
                        MaxLength="4"></asp:TextBox>
                    -
                    <asp:TextBox runat="server" ID="txtStyleNumber2" Width="55px" MaxLength="2" onKeyPress="return VinCheck(event);"
                        onpaste="return false;">
                    </asp:TextBox>
                    <asp:HiddenField ID="hdnActive" runat="server" />
                    <span class="hide_me" id="select_orders"><a href="javascript:void(0)" onclick="LaunchOrdersByStyleVariation();return false;">
                        Select Orders</a>
                        <input type="hidden" id="hdnOrderIDs" value='' />
                    </span>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Buyer:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlBuyer" Width="110px" onchange="PopulateDepartments(this);">
                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp; Dept: &nbsp;
                    <asp:DropDownList runat="server" ID="ddlDept" Width="110px">
                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
                <tr style="display: none" class='hideme'>
                    <td colspan="2" align="center">
                        <%--<asp:CheckBoxList ID="chkwithsample" class="rbl"  runat="server"    
              RepeatDirection="Horizontal">  
                                <asp:ListItem Value="Average">Average</asp:ListItem>  
                                <asp:ListItem Value="CAD">CAD File</asp:ListItem>  
                                <asp:ListItem Value="1">OB Sheet</asp:ListItem>  
                                <asp:ListItem Value="1">SAM</asp:ListItem>  
                                <asp:ListItem Value="1">OB</asp:ListItem>  
                                <asp:ListItem Value="1">CMT</asp:ListItem>  
                                
                            </asp:CheckBoxList>--%>
                        To exclude select from below check box list
                        <div id="rates" class="rbl">
                            <input type="checkbox" id="r1Average" name="rateavg" value="Average">
                            Average
                            <input type="checkbox" id="r2CAD" name="ratecad" value="CAD File">
                            CAD File
                            <input type="checkbox" id="r3OBSheet" name="rateobsheet" value="OB Sheet">
                            OB Sheet
                            <input type="checkbox" id="r4SAM" name="ratesam" value="SAM">
                            SAM
                            <input type="checkbox" id="r5OB" name="rateob" value="OB">
                            OB
                            <input type="checkbox" id="rd6CMT" name="ratecmt" value="CMT">
                            CMT
                        </div>
                    </td>
                </tr>
                <td colspan="2" align="center">
                    <input type="button" class="save save-style-number submit" value="Save" />
                    <input type="button" class="cancel da_submit_button" value="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnPostBack" runat="server" CssClass="hide_me" />
    <asp:HiddenField ID="hdnUserID" runat="server" />
</asp:Content>
