<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="QC.aspx.cs" Inherits="iKandi.Web.Internal.Merchandising.QC"  EnableEventValidation="false" ValidateRequest = "false"%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    var QCSheetCollection;
    var QCSheetIframeCollection;
    var tabLICollection;

    var activeTab;
    var activeQCSheet; 
    var hdnActive;
    var isPageLoad;

    $(function () {
        //debugger;
    
        var y = $(window.parent).height();
        // var a = x;
        var b = y - 120;
        $(".iframe-height").css({ height: b + 'px' });


        isPageLoad = true;
        hdnActive = $('#<%= hdnActive.ClientID %>');
        var ddlInspection = $('#<%=ddlInspection.ClientID %>');
        var ddlContract = $('#<%=ddlContract.ClientID %>');
       
        $('.QC-tab-li').click(function () {

            activeTab = $(this);
            ShowQCSheet(this, $(this).attr('qualityid'), $(this).attr('InspectionID'));
        });

        var hdnISOpenPopUp = $('#<%= hdnISOpenPopUp.ClientID %>');
        if (hdnISOpenPopUp.val() == "True")
            ShowPageLoadQCBox();

        QCSheetIframeCollection = $('.qc-iframe');
        QCSheetCollection = $('.qc-sheet');
        tabLICollection = $('#ctl00_cph_main_content_tabs_qc li');

        if (QCSheetIframeCollection.length > 0) {
            $('.add-qc-contract').show();
            // window.setTimeout(ClickFirstTab, 1000);
        }
        else {
            $('.add-qc-contract').hide();
        }

        if (QCSheetCollection.length > 0) {
            $(QCSheetCollection[0]).show();
        }

        if (tabLICollection.length > 0)
        // $(tabLICollection[0]).css('background', '#39589c');
            $(tabLICollection[0]).addClass('active-tab');


        sheetLoadingCounter = tabLICollection.length;

        $('.qc-iframe').load(function () {

            var tab = $("#tab-" + $(this).parents("div").attr("id"));

            //tab.find("#loading-icon").hide();

            SetActiveTabToFirstTabAfterSave(hdnActive.val());

            if (!isPageLoad) {
                if (activeQCSheet != undefined) {
                    //activeQCSheet.contents().find('.style-table').hide();
                    //activeQCSheet.contents().find('.costing_form').show();
                }

                return;
            }

            isPageLoad = false;

            //            if (activeQCSheet == undefined) {
            //                activeQCSheet = $($('.qc-iframe')[0]);
            //                activeQCSheet.height($(this).contents().find('.qc-sheet-height').text());
            //            }

            //ClickFirstTab();

            //            var qc_collection = getQueryString(activeQCSheet[0].contentWindow.window.location.search);

            //            var queryString = qc_collection['cid'];

            //            if (queryString == -1 || queryString == undefined) {
            //                var txtStyleNumber = $(this).contents().find('.costing-style');
            //                var styleNumber = $(this).attr('StyleNumber');

            //                txtStyleNumber.val(styleNumber);

            //                var txtStyleNumberView = activeQCSheet.contents().find('.costing-style-number-view');
            //                txtStyleNumberView.val(styleNumber);
            //                txtStyleNumberView.focus();
            //                txtStyleNumberView.blur();
            //            }

            // var scrollHeight = $(this).contents().find('body').attr('scrollHeight') + 120;

            //if (scrollHeight != 0)
            // $(this).height(scrollHeight);


        });

        ///removed



        $('.save-q-c').click(function () {

            var OrderDetailID = '<%=this.OrderDetailID %>';
            var None = "Any";
            var RefOrderDetailID = ddlContract.val();
            var InspectionID = ddlInspection.val();

            if (InspectionID == 0) {
                ShowHideValidationBox(true, 'Please select Inspection Type.', 'Quality Control Sheet');
                return false;
            }

            if (RefOrderDetailID == 0) {
                ShowHideValidationBox(true, 'Please select reference Contract Number.', 'Quality Control Sheet');
                return false;
            }

            if (RefOrderDetailID == -10) {
                RefOrderDetailID = '<%=this.OrderDetailID %>';
                None = "None";
            }

            $.ajax({
                type: "POST",
                url: serviceUrl + "CreateQualityProxy",
                data: "{OrderDetailID: '" + OrderDetailID + "', InspectionID:'" + InspectionID + "', None:'" + None + "', RefOrderDetailID:'" + RefOrderDetailID + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                if (response.d == '-98')
                    ShowHideValidationBox(true, 'Task not created for this Inspection.', 'Quality Sheet - Add Quality Inspection', HideAddQCBox);

                else if (response.d == '-99')
                    ShowHideValidationBox(true, 'You have no permission to create new sheet.', 'Quality Sheet - Add Quality Inspection', HideAddQCBox);

                else if (response.d == '-100')
                    ShowHideValidationBox(true, 'You can not create new sheet without complete previous sheet, OR If you have passed the sheet.', 'Quality Sheet - Add Quality Inspection', HideAddQCBox);
                else
                    ShowHideMessageBox(true, 'Quality Inspection saved successfully.', 'Quality Sheet - Add Quality Inspection', RefreshPage());
            }

            function OnErrorCall(response) {
                ShowHideValidationBox(true, 'Some error occured in saving Quality Inspection.', 'Quality Sheet - Add Quality Inspection', HideAddQCBox);
            }

        });
    });


    function Cancel() {
        var ddlInspection = $('#<%=ddlInspection.ClientID %>');
        var ddlContract = $('#<%=ddlContract.ClientID %>');
        HideAddQCBox();

        ddlInspection.val("0");
        ddlContract.val("0");
        hdnActive.val('');
    }

        //window.setTimeout(SelectHighlightedTab, 6000);


   // });

    function SelectHighlightedTab() {
        var qc_collection = getQueryString();
        var currentTab = activeTab;

        if (qc_collection['sn'] != null && qc_collection['sn'] != '') {
            //activeTab = tabLICollection.find("a:contains('" + qc_collection['sn'].toUpperCase() + "')").parents("LI");

            var styleNumber = $.trim((qc_collection['sn'].replace("+", ' ').replace("+", ' '))).toUpperCase();
            // alert(styleNumber + ' -- ' + qc_collection['sn']);

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

        if (val == '') {
            if (activeTab == undefined || activeTab.attr('StyleNumber') == $('.QC-tab-li:first').attr('StyleNumber')) return;

            var newActiveTab = activeTab.clone(true).insertBefore('.QC-tab-li:first');
            activeTab.remove();

            tabLICollection = $('#ctl00_cph_main_content_tabs_qc li');
            ShowQCSheet(newActiveTab[0], newActiveTab.attr('qualityid'), newActiveTab.attr('InspectionID'));
        }
        else {
            tabLICollection = $('#ctl00_cph_main_content_tabs_qc li');
            var newActiveTab = tabLICollection.find("a").filter(function () {
                return $.trim($(this).text().toUpperCase()) == val;
            }).parents("LI");
            ShowQCSheet(newActiveTab[0], newActiveTab.attr('qualityid'), newActiveTab.attr('InspectionID'));
        }
    }

    function ClickFirstTab() {

        if (tabLICollection.length > 0) {
            activeTab = $(tabLICollection[0]);
            $(tabLICollection[0]).click();
        }
    }

    function ShowQCSheet(sender, qualityid, InspectionID) {     
        tabLICollection.removeClass('active-tab');
        $(sender).addClass('active-tab');
       

        $('.qc-sheet').hide();
        $('#' + qualityid).show();

        activeQCSheet = $('#' + qualityid).find('.qc-iframe');

        if (activeQCSheet.length == 1) {

             activeQCSheet.height(activeQCSheet.contents().find('body').attr('scrollHeight'));        

        }
        
    }


    function ShowAddQCBox() {
        //debugger;
        var qc_collection = getQueryString();
       // var qc_collection=  'DR 200IND9063';
        var InspectionID = (qc_collection['InspectionID'] == undefined) ? '' : qc_collection['InspectionID'];


        var ddlInspection = $('#<%=ddlInspection.ClientID %>');
        var ddlContract = $('#<%=ddlContract.ClientID %>');

        ddlInspection.val("0");
        ddlContract.val("0");

        $('.style_number_box_background').show();
        $('.style_number_box').show();
    }

    function ShowPageLoadQCBox() {
        //debugger;
        var qc_collection = getQueryString();
        var InspectionID = (qc_collection['InspectionQId'] == undefined) ? '' : qc_collection['InspectionQId'];
        var ddlInspection = $('#<%=ddlInspection.ClientID %>');
        var ddlContract = $('#<%=ddlContract.ClientID %>');
        var InspectionName = $('#<%= hdnInspectionName.ClientID %>').val();
        ddlInspection.val(InspectionID);
        BindContractDDl();
        //ddlContract.val("0");

        $('.style_number_box_background').show();
        $('.style_number_box').show();
        $('.cancel').hide();
        ShowHideMessageBox(true, 'Please create ' + InspectionName + ' Quality Inspection.', 'Quality Sheet - Create Quality Inspection');
    }

    function HideAddQCBox() {
        $('.style_number_box').hide();
        $('.style_number_box_background').hide();
    }


    function RefreshPage() {

        //window.location = "QC.aspx?sn=" + styleNumber;
        window.setTimeout(location.reload(true), 5000);  
    }

    function onPageError(error) {
        alert(error.Message + ' -- ' + error.detail);
    }

    function BindContractDDl() {
       // debugger;
        var OrderIdval = $('#<%= hdnOrderID.ClientID %>').val();
        var InspectionIDval = $('#<%=ddlInspection.ClientID %> option:selected').val();
        $('#<%= ddlContract.ClientID %>').empty();
        proxy.invoke("GetContractBYOrder", { OrderId: OrderIdval, InspectionID: InspectionIDval }, function (result) {

            $.each(result, function (key, value) {
                $('#<%= ddlContract.ClientID %>').append($("<option></option>").val(value.OrderDetailID).html(value.ContractNumber));

            });
        });
    }


    // add tab with active class//


    $(document).ready(function () {
        $(".tabs-menu li").click(function (event) {
            event.preventDefault();
            $(this).addClass("active");
            $(this).siblings().removeClass("active");
            var tab = $(this).attr("href");
            $(".qc-sheet").not(tab).css("display", "none");
            $(tab).fadeIn();
        });
    });

    </script>

    <style type="text/css">
        .style_number_box_background 
        {
            opacity:0.9;
            background:grey;
        }
        .style_number_box  
        {
            padding:0px !important;
            width:500px !important;
            border:none;
           
        }
        .style_number_box select
        {
            height:20px;
         }
         .style_number_box  table
         {
             border:1px solid gray;
             padding-bottom:5px;
         }
    .style_number_box div
    {
    background-color: #39589c;
	color: #fff;
	font-size: 14px;
	font-weight: bold;
	
	text-align: center;
	text-transform: capitalize;
	width: 100%;
	padding: 2px 0px;
	font-weight:500;
    }
    .b
    {
        font-weight:bold;
    }
    .da_submit_button
    {
          line-height: 14px !important;
          border-radius: 2px;
     }
     #ctl00_cph_main_content_tabs_qc ul
     {
         list-style:none;
         padding:0px;
         margin:0px;
     }
     #ctl00_cph_main_content_tabs_qc ul li:last-child
     {
         border-radius:0px 5px 0px 0px !important;
     }
      #ctl00_cph_main_content_tabs_qc ul li:first-child
      {

          border-radius: 5px 0px 0px 0px;
     }

    #ctl00_cph_main_content_tabs_qc li 
    {
    
    padding: 2px 5px;
       float: left;
       margin:-1px 0px;
       border:1px solid #ccc;
}
 #ctl00_cph_main_content_tabs_qc li  div
    {
    border: 0px;
      
        
    }
    
    #ctl00_cph_main_content_tabs_qc li span {

    padding: 6.5px 11px; 
    vertical-align: top;
    margin-top:-6.3px;
   
}


#ctl00_cph_main_content_tabs_qc li div a
{
    text-decoration:none;
     
}


.tabGreen li.active-tab 
{    
    border:none !important;
    font-weight:bold; 
    background:green; 
    color:#ffff00;  
    
}
.tabGreen li
{
   background:green;    
}
.tabGreen li div a
{
 color: #ffffff;   
}
.tabGreen li.active-tab div a 
{
    font-weight:bold;   
    color:yellow !important;  
}
.tabRed li.active-tab 
{
    border:none !important;
    font-weight:bold; 
    background:red; 
    color:#ffff00;  
}
.tabRed li
{
   background:red;    
}
.tabRed li div a
{
 color: #ffffff;   
}
.tabRed li.active-tab div a 
{
    font-weight:bold;   
    color:yellow !important;  
}
.tabGray li.active-tab 
{
    border:none !important;
    font-weight:bold; 
    background:gray; 
    color:#ffff00;  
}
.tabGray li.active-tab div a 
{
    font-weight:bold;   
    color:yellow !important;  
}
.tabGray li
{
   background:gray;    
}
.tabGray li div a
{
 color: #ffffff;   
}
#secure_greyline
{
    margin-top:2px !important;
    margin-bottom:5px !important;
}
    </style>
    <div>
        <asp:HiddenField ID="hdnOrderID" runat="server" />
        <asp:HiddenField ID="hdnISOpenPopUp" runat="server" Value="False"/>
        <asp:HiddenField ID="hdnInspectionName" runat="server" Value=" "/>
    </div>

<div id="tabs_qc" runat="server">
        <ul class="tabs-menu">
      
            <asp:Repeater ID="repeaterQCTabs" runat="server" 
                onitemdatabound="repeaterQCTabs_ItemDataBound">            
                <ItemTemplate>
                <div id="dvTab" runat="server">
                    <li class="QC-tab-li" id='<%# "tab-" + Eval("qualityid").ToString() %>' qualityid='<%# Eval("qualityid") %>'
                        InspectionID='<%#Eval("InspectionID")%>' StatusName='<%# Eval("FaultStatusNAME") %>'> 
                        <div>
                            <a id="QCTab" runat="server" href="javascript:void(0)">
                            </a>                          
                        </div>
                    </li></div>
                </ItemTemplate>
            </asp:Repeater>
              <asp:HiddenField ID="hdnIsUcknowledge" runat="server" />
            <li id="addButton" runat="server"><span onclick="ShowAddQCBox()" class="add-qc-contract" style="cursor:pointer; color:#000" title="Add New Quality Inspection">
                +</span> </li>
        </ul>
    </div>
    <asp:Repeater ID="repeaterQC" runat="server">
        <ItemTemplate>
            <div id='<%# Eval("qualityid") %>' style="display: none" class="qc-sheet">
                <iframe id="ifCosting" runat="server" src='<%# "TabQC.aspx?orderDetailID=" + Convert.ToInt32(Eval("orderDetailID")) +"&QualityControlID="+ Convert.ToInt32(Eval("qualityid")) + "&InspectionID="+ Eval("InspectionId")%>'
                    width="100%" class="qc-iframe iframe-height" frameborder="1" scrolling="YES" 
                    InspectionID='<%#Eval("InspectionID")%>'></iframe>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="style_number_box_background">
    </div>
    <div class="style_number_box">
    <div>
     Select QA  Inspection Reference
    </div>
        <table width="100%" cellpadding="6px" class="mid">    
            <tr>
                <td colspan="2">
                    Style No. :&nbsp; <span class="gray_labels"> <asp:Literal ID="ltrlStyleNo" runat="server"></asp:Literal> </span> &nbsp; &nbsp; 
                    Serial No. :&nbsp; <span class="gray_labels"> <asp:Literal ID="ltrlSerialNo" runat="server"></asp:Literal> </span>  <asp:HiddenField ID="hdnActive" runat="server" />      &nbsp;&nbsp;
                    Contract No. :&nbsp; <span class="gray_labels"> <asp:Literal ID="ltrlContractNo" runat="server"></asp:Literal> </span>
                </td>
              
            </tr>
            <tr>
                <td width="30%">
                    Inspection Type:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlInspection" Width="43.3%" onchange="javascript:BindContractDDl();">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>
                    Reference Contract No.:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlContract" Width="43.3%" >
                     <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input type="button" class="save save-q-c da_submit_button" value="Save" />
                    <input type="button" class="cancel da_submit_button" value="Cancel" onclick="javascript: return Cancel();"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
