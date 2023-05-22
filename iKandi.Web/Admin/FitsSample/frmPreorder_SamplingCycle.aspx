<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="frmPreorder_SamplingCycle.aspx.cs" Inherits="iKandi.Web.Admin.FitsSample.frmPreorder_SamplingCycle" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi.css" />
    <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi1.css" />
    <script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <style type="text/css">
        body
        {
            font-family: verdana;
            font-size: 10px;
        }
        table
        {
            font-family: arial, halvetica;
            border-color: gray;
            border-collapse: collapse;
        }
        .item_list1 th
        {
            font-size: 10px !important;
        }
        .item_list TD
        {
            text-align: center;
            border: 1px solid #b7b4b4;
            padding: 4px 0px !important;
            background-color: none !important;
            text-transform: capitalize;
        }
          .item_list TD a.ImagesWidth img
          {
              width:90% !important;
          }
        
        .foo-back
        {
            background: #f5f2f1;
        }
        .gray
        {
            color: gray;
        }
        input
        {
            height: 18px;
        }
        .blank-item
        {
            color: gray;
        }
        select
        {
            font-size: 11px;
            width: 80%;
            border: 1px solid gray;
        }
        textarea
        {
            width: 70%;
        }
        .F8
        {
            font-size: 10px;
        }
        .pagination table td
        {
            padding: 5px !important;
        }
        .pagination table td span
        {
            color: Green;
            font-weight: bold;
            font-size: 12px !important;
        }
        select
        {
            text-transform: capitalize;
        }
        .cellback td
        {
            background: #f2f2f2 !important;
        }
        .cellback .white
        {
            background: white !important;
        }
        .cellback select
        {
            background: #f2f2f2 !important;
        }
        .CommentStyle
        {
            text-align: left;
        }
        .show-div
        {
            background: #fff;
            border-radius: 5px;
            display: none;
        }
        .Hide
        {
            display: none;
        }
        .chkIsQc input
        {
            margin: 0px;
            padding: 0px;
        }
        input[type='checkbox']
        {
            vertical-align: middle;
        }
        .item_list th
        {
            font-size: 10px !important;
        }
         .item_list td.padding_0
        {
            padding:0px !important;
         } .item_list td.cellback
        {
            padding:0px !important;
         }
        .item_list td .innertable
        {
            border:0px;
            height:100%;
         }
          .item_list td .innertable td
        {
            border:0px;
            background: transparent !important;
            height:24px;
         }
         .border_bottom_1
         {
             border-bottom:1px solid #b1b1b1 !important;
         }
           .item_list td .innertable td input[type="radio"]
           {
              margin: 0px 2px 0px 0px;
            }
            .item_list td .innertable td label
           {
              position:relative;
              top:-4px;
            }
            .item_list TD:first-child
            {
                    border-left-color: #a9a4a4 !important;
            }
            .item_list TD:last-child
            {
                    border-right-color: #a9a4a4 !important;
            }
            .item_list tr:last-child > td
            {
                    border-bottom-color: #d2cfcf !important;
            }
            .submit
            {
                cursor:pointer;
              }
    </style>
    <script type="text/javascript">
        $(function () {
            // debugger;



            //                jQuery(".cadmasterpopup input[type=checkbox]").click(function () {
            //                    if ($(this).is(':checked')) {
            //                        //alert(this.checked);
            //                        var ddlFits = $("[id*=ddlFits]");
            //                        var styleid = $('#<%= hdnStyleId.ClientID %>').val();
            //                        var flagvalue = 2;
            //                        var Status = ddlFits.find("option:selected").text();
            //                        proxy.invoke("GetcadMaster", { styleid: styleid, flagvalue: flagvalue, Status: Status }, function (result) {
            //                            jQuery.facebox(result);
            //                        }, onPageError, false, false);

            //                    }
            //                    else {
            //                        this.removeAttr("checked");
            //                    }
            //                });

            //            });

            jQuery(".cadmasterpopup input[type=checkbox]").click(function () {
                if ($(this).is(':checked')) {
                    //alert(this.checked);
                    var ddlFits = $("[id*=ddlFits]");
                    var styleid = $('#<%= hdnStyleId.ClientID %>').val();
                    var flagvalue = 2;
                    var Status = ddlFits.find("option:selected").text();
                    //var Status=ctl00_cph_main_content_gvSamplingFitsCycleflow_ctl02_hdnStatus
                    var Status = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='ctl02_hdnStatus" + "']").val();

                    var url = 'frmCadRoleAdmin.aspx?styleid=' + styleid + '&flagvalue=' + flagvalue + '&Status=' + Status;
                    Shadowbox.init({ animate: true, animateFade: true, modal: true });
                    Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 190, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                    // var win = window.open(url);
                    // win.focus();

                }
                else {
                    $(this).removeAttr("checked");
                }

            });
        });
        function SBClose() {
            //  debugger;

        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript" language="javascript">

        $(function () {
            //alert('abc');
            PatternStyle();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(PatternStyle);

            CheckOrderProcess();
        });


        function PatternStyle() {
            $("input[type=text].Pattern-style").autocomplete("/Webservices/iKandiService.asmx/SuggestStylesForPattern", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });
        }


        function CheckOrderProcess() {
            //debugger;           
            var styleId = $('#<%= hdnStyleId.ClientID %>').val();
            var ClientId = -1;
            var DeptId = -1;
            var whichtab = 5;
            if (styleId != -1) {
                proxy.invoke("CheckOrderProcess", { Styleid: styleId, ClientId: ClientId, DeptID: DeptId, Whichtab: whichtab },
            function (result) {
                if (result.length > 0) {
                    //debugger;                   
                    var url = 'FitsReUsePopup.aspx?styleid=' + styleId;
                    //alert(url);
                    var popupWindow = window.open(url, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
                    window.document.body.disabled = true;
                }

            }, null, false, false);
            }
        }


        function Fits_CreateNew() {
            //        debugger;
            //        alert('create new');
            window.document.body.disabled = false;
            document.getElementById('<%=hdnFitsCreateNew.ClientID%>').value = "1";
            $('#<%= hdnFitsReUse.ClientID %>').val('0');
            $('#<%= hdnFitsNewRef.ClientID %>').val('0');

            $(".btnthisFits").click();
        }

        function Fits_NewRefrence(NewStyleID, NewStyleNumber) {
            //debugger;
            //alert('New Refrence');
            window.document.body.disabled = false;
            $('#<%= hdnFitsNewRef.ClientID %>').val('1');
            $('#<%= hdnFitsReUse.ClientID %>').val('0');
            $('#<%= hdnFitsCreateNew.ClientID %>').val('0');
            $('#<%= hdnReUseStyleId.ClientID %>').val(NewStyleID);
            $('#<%= hdnReUseStyleNumber.ClientID %>').val(NewStyleNumber);
            $(".btnthisFits").click();
        }

        function Fits_ReUse(ReUseStyleID, ReUseStyleNumber) {
            //        debugger;
            //        alert('ReUse');
            window.document.body.disabled = false;
            $('#<%= hdnFitsReUse.ClientID %>').val('1');
            $('#<%= hdnFitsNewRef.ClientID %>').val('0');
            $('#<%= hdnFitsCreateNew.ClientID %>').val('0');
            $('#<%= hdnReUseStyleId.ClientID %>').val(ReUseStyleID);
            $('#<%= hdnReUseStyleNumber.ClientID %>').val(ReUseStyleNumber);
            $(".btnthisFits").click();

        }

        function showCommentPopup(obj) {
            //debugger;
            var Ids = obj.id;
            var cId = Ids.split("_")[5].substr(3);
            var Comment = $("#<%= gvSamplingFitsCycleflow.ClientID %> span[id*='ctl" + cId + "_lblComment" + "']").html();
            $('#<%= lblCommentShow.ClientID %>').html(Comment);
            jQuery.facebox(
        $('.show-div').show()
        );
            return;
        }

        function ShowSamplingFitsHistory(obj) {
            //debugger;
            var Ids = obj.id;
            var cId = Ids.split("_")[5].substr(3);
            var StyleId = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='ctl" + cId + "_hdngvStyleId" + "']").val();
            if (StyleId != -1) {
                proxy.invoke("GetSamplingHistory_PreOrder", { StyleId: StyleId},
            function (result) {
                jQuery.facebox(result);

            }, null, false, false);
            }

            return false;
        }
        function ValidateSubmit() {
            //debugger;
            var ReUseStyleID = $('#<%= hdnReUseStyleId.ClientID %>').val();
            var RowId = 0;
            var gvId;
            var GridRow = $(".gvRow").length;

            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var ChkHandover = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='" + gvId + "_ChkHandover" + "']");
                var ChkPattern = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='" + gvId + "_ChkPattern" + "']");
                var ChkSample = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='" + gvId + "_ChkSample" + "']");
                var ChkIsQC = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='" + gvId + "_ChkIsQC" + "']");
                var ddlQC = $("#<%= gvSamplingFitsCycleflow.ClientID %> select[id*='" + gvId + "_ddlQC" + "']");
               // var chkStcApproved = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='" + gvId + "_chkStcApproved" + "']");

                var Status = $("#<%= gvSamplingFitsCycleflow.ClientID %> span[id*='" + gvId + "_lblStatus" + "']");
                var SampleUpload = $("#<%= gvSamplingFitsCycleflow.ClientID %> input[id*='" + gvId + "_SampleUpload" + "']");
                var txtComment = $("#<%= gvSamplingFitsCycleflow.ClientID %> textarea[id*='" + gvId + "_txtComment" + "']");

                if (ReUseStyleID == "-1") {

//                    if (txtComment.val() == '') {

                        if ((ChkHandover.is(':enabled')) && (!ChkHandover.is(':checked'))) {
                            jQuery.facebox('Please check Handover');
                            ChkHandover.focus();
                            return false;
                        }
//                        if ((ChkPattern.is(':enabled')) && (!ChkPattern.is(':checked'))) {
//                            jQuery.facebox('Please check Pattern Ready');
//                            ChkPattern.focus();
//                            return false;
//                        }
                        if ((ChkSample.is(':enabled')) && (!ChkSample.is(':checked'))) {
                            jQuery.facebox('Please check Sample Sent');
                            ChkSample.focus();
                            return false;
                        }
                        if ((ChkIsQC.is(':enabled')) && (ChkIsQC.is(':checked')) && (ddlQC.val() == 'Select')) {
                            jQuery.facebox('Please Select QC Name');
                            ddlQC.focus();
                            return false;
                        }
                        if ((ChkSample.is(':enabled')) && (ChkSample.is(':checked')) && (!ChkIsQC.is(':checked'))) {
                            jQuery.facebox('Please check QC');
                            ChkIsQC.focus();
                            return false;
                        }
//                        if ((chkStcApproved.is(':enabled')) && (!chkStcApproved.is(':checked')) && (Status.text() == 'STC')) {
//                            jQuery.facebox('Please check Stc Approve');
//                            chkStcApproved.focus();
//                            return false;
//                        }
                        if ((ChkSample.is(':enabled')) && (ChkSample.is(':checked')) && (SampleUpload.val() == '') && (Status.text() != 'Sampling')) {
                            jQuery.facebox('Please upload Sample');
                            SampleUpload.focus();
                            return false;
                        }

//                    }
                }

            }
        }

    

    </script>
    <div>
        <h2 style="width: 100%; min-width: 1300px !important; background: #39589c; color: white;
            text-align: center; font-size: 14px; padding: 2px;">
            Sampling/Fit-cycle Flow</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
            <ContentTemplate>
                <div style="width: 100%; overflow-x: auto;">
                    <div>
                        <asp:HiddenField ID="hdnStyleId" Value="-1" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hdnFitsCreateNew" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnFitsReUse" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnReUseStyleId" Value="-1" runat="server" />
                        <asp:HiddenField ID="hdnReUseStyleNumber" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnFitsNewRef" Value="0" runat="server" />
                        <asp:Button ID="btnFitsReuse" runat="server" Style="display: none;" CssClass="btnthisFits"
                            Text="Button" OnClick="btnFitsReuse_Click" />
                    </div>
                    <table id="tblSearch" runat="server" border="0" cellpadding="0" cellspacing="0" style="display: none;
                        font-size: 9px ! important; padding-bottom: 0px; color: gray; width: 943px">
                        <tr>
                            <td align="center" width="65px">
                                <asp:Label ID="lablsearch" Text="Style" runat="server"></asp:Label>
                            </td>
                            <td style="border: none !important; width: 125px;">
                                <input type="hidden" runat="server" class="do-not-disable" id="hdntabvalue" />
                                <input type="text" id="txtsearch" style="width: 85% ! important; color: #000; padding: 2px 5px;"
                                    class="Pattern-style do-not-disable" runat="server" maxlength="20" />
                            </td>
                            <td>
                                Client
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlClientNameSelect" AutoPostBack="true" Width="90%"
                                    OnSelectedIndexChanged="ddlClientNameSelect_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Pare.Dept.
                            </td>
                            <td>
                                <asp:DropDownList runat="server"   OnSelectedIndexChanged="ddlparentDept_SelectedIndexChanged" AutoPostBack="true" ID="ddlparentDept" Width="125px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Sub.Dept.
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlDeptNameSelect" Width="125px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Type
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlTypeNameSelect" Width="90%">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSearch" CssClass="submit" runat="server" Text="Search" OnClick="btnSearch_Click"
                                    Height="26px" />
                            </td>
                        </tr>
                    </table>
                  
                    <asp:GridView runat="server" ID="gvSamplingFitsCycleflow" RowStyle-ForeColor="Gray"
                        CssClass="item_list" AutoGenerateColumns="false" AllowPaging="true" PageSize="20"
                        Width="99%" OnRowCommand="gvSamplingFitsCycleflow_RowCommand" OnRowDataBound="gvSamplingFitsCycleflow_RowDataBound"
                        OnPageIndexChanging="gvSamplingFitsCycleflow_PageIndexChanging">
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="6" FirstPageText="First"
                            LastPageText="Last" />
                        <PagerStyle CssClass="pagination" />
                        <RowStyle CssClass="gvRow" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="240px" ItemStyle-Width="200px">
                                <HeaderTemplate>
                                    St. Number<br />
                                    Fabric 1<br />
                                    Color/Print
                                    <br />
                                    <!--Stc Target-->
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdngvStyleId" Value='<%# Eval("Styleid") %>' runat="server" />
                                    <asp:HiddenField ID="hdnIsIkandiClient" Value='<%# Eval("IsIkandiClient") %>' runat="server" />
                                    <asp:HiddenField ID="hdnFitsType" Value='<%# Eval("FitsType") %>' runat="server" />
                                    <asp:HiddenField ID="hdnIsOrderExist" Value='<%# Eval("IsOrderExist") %>' runat="server" />
                                    <asp:HiddenField ID="hdnIsCostingWithPattern" Value='<%# Eval("IsCostingWithPattern") %>'
                                        runat="server" />
                                    <div style="min-height: 23px; border-bottom: 1px solid #b1b1b1;">
                                        <div style="padding-top: 4px">
                                            <div style="float: left; padding-left: 4px;">
                                                <asp:ImageButton ID="ImgbtnHistory" Width="12px" Height="12px" OnClientClick="javascript:return ShowSamplingFitsHistory(this)"
                                                    ImageUrl="~/images/icon.jpg" runat="server"></asp:ImageButton></div>
                                            <asp:Label ID="lblStyleNo" runat="server" Font-Bold="true" ForeColor="Black" Text='<%# Eval("StyleNumber") %>'></asp:Label>
                                            <asp:Label ID="lblCreation_FitsDate" runat="server" Text="" Style="display: none;"></asp:Label></div>
                                    </div>
                                    <div style="min-height: 23px; border-bottom: 1px solid #b1b1b1;padding: 2px 0px;">
                                        <div style="padding-top: 4px">
                                            <asp:Label ID="lblFabric1" runat="server" Text='<%# Eval("Fabric") %>'></asp:Label></div>
                                    </div>
                                    <div style="min-height: 23px; border-bottom: 1px solid #b1b1b1;padding: 2px 0px;">
                                        <div style="padding-top: 4px">
                                            <asp:Label ID="lblColorPrint" runat="server" Text='<%# Eval("FabricDetails") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <div style="padding-top: 4px">
                                        <asp:Label ID="lblSTCTargetDate" Font-Bold="true" ForeColor="black" runat="server"
                                            Text=""></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Width="240px" />
                                <ItemStyle VerticalAlign="Top" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-Width="80px" HeaderText="Thumbnail">
                                <ItemTemplate>
                                    <a border="0" title="CLICK TO VIEW ENLARGED IMAGE" class="ImagesWidth" href='javascript:void(0)' onclick='showStylePhotoWithOutScroll(<%#Eval("StyleID") %>,-1,-1)'>
                                        <img height="70px" width="90%" border="0" align="center" src='<%# ResolveUrl("~/Uploads/Style/thumb-" + Eval("SketchURL").ToString()) %>'
                                            visible='<%# (Eval("SketchURL") == null || string.IsNullOrEmpty(Eval("SketchURL").ToString()) ) ? false: true %>' />
                                    </a>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                                <ItemStyle Width="80px" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                <HeaderTemplate>
                                    Type<br />
                                    <asp:Label runat="server" ID="lblAMHead" Text="AM"> </asp:Label>
                                    <asp:Label runat="server" ID="lblPDMHead" Text="PD Manager"> </asp:Label>
                                    <br />
                                    <asp:Label runat="server" ID="lblPRDMHead" Text="Prod. Merch."> </asp:Label>
                                    <asp:Label runat="server" ID="lblPDHead" Text="PD. Merch."> </asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="innertable">
                                     <tr>
                                        <td class="border_bottom_1">
                                         <asp:Label ID="lblStatus" Font-Bold="true" ForeColor="Black" runat="server" Text=""></asp:Label>
                                            <asp:HiddenField ID="hdnStatus" Value='<%# Eval("Status") %>' runat="server"></asp:HiddenField>
                                        </td>
                                    </tr>
                                    <tr>
                                         <td class="border_bottom_1">
                                          <asp:Label ID="lblAM" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                         <td>
                                         <asp:Label ID="lblPDM" runat="server" Text=""></asp:Label>
                                        </td>
                                     </tr>
                                  </table>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle VerticalAlign="Top" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                <HeaderTemplate>
                                    Client
                                    <br />
                                    Department
                                    <br />
                                    Sample Sent Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="innertable">
                                     <tr>
                                       <td class="gray border_bottom_1">
                                          <asp:Label ID="lblClient" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>                                            
                                           
                                            <asp:HiddenField ID="hdnClientId" Value='<%# Eval("ClientId") %>' runat="server">
                                            </asp:HiddenField>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td class="gray border_bottom_1">
                                           <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DeptName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnClientDeptid" Value='<%# Eval("ClientDeptid") %>' runat="server">
                                            </asp:HiddenField>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td class="F8 gray">
                                            <asp:Label ID="lblSampleSentDate" Font-Bold="true" ForeColor="gray" runat="server"
                                                Text=""></asp:Label>
                                       </td>
                                     </tr>
                                  </table>
                                </ItemTemplate>
                                <HeaderStyle Width="200px" />
                                <ItemStyle VerticalAlign="Top" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                <HeaderTemplate>
                                    Sampling Comm. For, Req. For<br />
                                    Req. Ref. Sample, Upload Comm.<br />
                                    ETA / Act Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <div id="dvFits" runat="server">
                                       <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="innertable">
                                         <tr>
                                           <td class="border_bottom_1">
                                            <asp:Label ID="lblFits" runat="server" Visible="false" Text=""></asp:Label>
                                            <asp:HiddenField ID="hdnFits" runat="server" />
                                            <asp:DropDownList ID="ddlFits" ForeColor="Black" Width="95px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlFits_SelectedIndexChanged" runat="server">
                                                <asp:ListItem Text="Sampling 1"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 2"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 3"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 4"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 5"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 6"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 7"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 8"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 9"></asp:ListItem>
                                                <asp:ListItem Text="Sampling 10"></asp:ListItem>
                                                <%--<asp:ListItem Text="Fit 5"></asp:ListItem>
                                                <asp:ListItem Text="Pp Sample 1"></asp:ListItem>
                                                <asp:ListItem Text="Pp Sample 2"></asp:ListItem>
                                                <asp:ListItem Text="Pp Sample 3"></asp:ListItem>
                                                <asp:ListItem Text="Sealer 1"></asp:ListItem>
                                                <asp:ListItem Text="Sealer 2"></asp:ListItem>
                                                <asp:ListItem Text="Sealer 3"></asp:ListItem>
                                                <asp:ListItem Text="Ref Sample"></asp:ListItem>
                                                <asp:ListItem Text="Size Set"></asp:ListItem>
                                                <asp:ListItem Text="Counter"></asp:ListItem>
                                                <asp:ListItem Text="Stc"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                           </td>
                                            </tr>
                                    <tr>
                                           <td class="border_bottom_1">
                                             <div class="gray">
                                                <asp:FileUpload ID="fitsUpload_New" runat="server" Width="55%" Font-Size="9px"></asp:FileUpload>
                                                 <asp:HyperLink ID="hlkFitsUpload_New" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
                                            </div>
                                           </td>
                                            </tr>
                                    <tr>
                                           <td>
                                               <div style="float: left; width: 50%; text-align: right;">
                                                    <asp:Label ID="lblFitsEta" runat="server" Text="" CssClass="F8"></asp:Label>
                                                 </div>
                                                <div style="float: right; width: 49%; text-align: left;">
                                                    <asp:Label ID="lblFitsActDate" runat="server" Text="" CssClass="F8"></asp:Label>
                                                </div>
                                           </td>
                                         </tr>
                                      </table>
                                      
                                      
                                          <%--  <div style="width: 15%; float: left;">
                                                <asp:CheckBox ID="ChkRefSample" Enabled="false" runat="server"></asp:CheckBox></div>--%>
                                        <%--    <div class="gray" style="float: left; width: 60%; margin-top: 4px;">
                                                <asp:FileUpload ID="fitsUpload" Width="98%" Font-Size="9px" runat="server"></asp:FileUpload></div>--%>
                                            <%--<div style="float: right; width: 20px; margin-top: 2px;">
                                                <asp:HyperLink ID="hlkFitsUpload" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>--%>
                                           
                                        
                                    </div>
                                    <div style="text-align: center; margin-top: 20px;" id="dvSampling" runat="server">
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Width="200px" />
                                <ItemStyle VerticalAlign="top" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="90px">
                                <HeaderTemplate>
                                    Handover ETA 
                                    <br> </br> Act. Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                      <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="innertable">
                                         <tr>
                                           <td class="border_bottom_1">
                                               <asp:Label ID="lblHandoverEta" runat="server" Text="" Font-Bold="true"></asp:Label>
                                           </td>
                                            </tr>
                                    <tr>
                                           <td class="border_bottom_1">
                                            <asp:CheckBox ID="ChkHandover" runat="server" style="float: left;"></asp:CheckBox>
                                             <asp:Label ID="lblHandoverActDate" runat="server" style="position:relative;top:4px;" Text=""></asp:Label>
                                           </td>
                                            </tr>
                                    <tr>
                                           <td>
                                               <div class="gray F8" style="color: green;">
                                                <asp:HiddenField ID="hdnHandoverActDate" runat="server"></asp:HiddenField>
                                                <asp:RadioButtonList ID="rblHandoversection" Visible="false" SelectedValue='<%# Eval("PDDecesion") %>' runat="server">
                                                <asp:ListItem Value ="0" Selected ="True">Finalize With Sample</asp:ListItem>
                                                <asp:ListItem Value ="1">Finalize With Out Sample</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                           </td>
                                         </tr>
                                      </table>
                                </ItemTemplate>
                                <HeaderStyle Width="90px" />
                                <ItemStyle VerticalAlign="Top" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Width="90px">
                                <HeaderTemplate>
                                    Pattern Rdy ETA 
                                    <br> </br> Act. Date
                                </HeaderTemplate>
                                <ItemTemplate>
                                 <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="innertable">
                                     <tr>
                                       <td class="border_bottom_1">
                                            <asp:Label ID="lblPatternEta" Font-Bold="true" runat="server" Text=""></asp:Label>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td class="border_bottom_1">
                                           <asp:CheckBox ID="ChkPattern" CssClass="cadmasterpopup" runat="server" style="float: left;"></asp:CheckBox>
                                            <div class="gray" style=" width: 95%; color: green;">
                                            <span class="gray F8" style="position: relative;top:5px;" >
                                                <asp:Label ID="lblPatternActDate" Font-Size="11px" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hdnPatternActDate" runat="server"></asp:HiddenField>
                                                 <asp:HiddenField ID="hdnStateSelection" runat="server"></asp:HiddenField>
                                            
                                        </div>
                                       </td>
                                        </tr>
                                  <%--  <tr>
                                       <td>
                                         
                                       </td>
                                     </tr>--%>
                                  </table>
                                 
                                </ItemTemplate>
                                <HeaderStyle Width="90px" />
                                <ItemStyle VerticalAlign="Top" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-Width="150px">
                                <HeaderTemplate>
                                    Sample Sent ETA 
                                    <br> </br> Act. Date 
                                    <br> </br>Is QC Present- QC Name
                                    <br />
                                  Upload <!-- Fits--> File.  <!--  Stc Appr.-->
                                </HeaderTemplate>
                                <ItemTemplate>
                                 <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="innertable">
                                     <tr>
                                       <td class="border_bottom_1">
                                        <asp:Label ID="lblSampleEta" runat="server" Text=""></asp:Label>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td class="border_bottom_1">
                                         <asp:CheckBox ID="ChkSample" runat="server" style="float: left;"></asp:CheckBox>
                                          <asp:Label ID="lblSampleActDate" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hdnSampleActDate" runat="server"></asp:HiddenField>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td class="border_bottom_1">
                                           <asp:CheckBox ID="ChkIsQC" runat="server" OnCheckedChanged="ChkIsQC_CheckedChanged"
                                            AutoPostBack="true" CssClass="chkIsQc" style="float: left;padding-left:5px;"></asp:CheckBox>
                                            <asp:HiddenField ID="hdnMasterQCId" Value='<%# Eval("QCMasterId") %>' runat="server">
                                            </asp:HiddenField>
                                            <asp:DropDownList ID="ddlQC" ForeColor="Black" Width="70%" runat="server" Style="padding: 1px">
                                            </asp:DropDownList>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td class="border_bottom_1" style="text-align:left;">
                                           <asp:FileUpload ID="SampleUpload" Width="65%" runat="server" Font-Size="9px" style="padding-left:5px;">
                                            </asp:FileUpload>

                                             <asp:HyperLink ID="hlkSampleUpload" runat="server" Width="15%" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" style="position:relative;top:3px;" /> </asp:HyperLink>
                                            <asp:CheckBox ID="chkStcApproved"  Width="15%" Visible="false" runat="server" style="display:none;" ></asp:CheckBox>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td style="text-align:left;">
                                        <asp:FileUpload ID="SampleUpload_New" Width="60%" runat="server" Font-Size="9px"
                                            Style="padding-left: 5px;"></asp:FileUpload>
                                            <asp:HyperLink ID="hlkSampleUpload_New" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
                                       </td>
                                     </tr>
                                  </table>
                                </ItemTemplate>
                                <HeaderStyle Width="150px" />
                                <ItemStyle VerticalAlign="Top" CssClass="padding_0" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="140px" HeaderStyle-Width="140px" HeaderText="Comment" >
                                <ItemTemplate>
                                 <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="innertable">
                                     <tr>
                                       <td class="">
                                          <asp:TextBox ID="txtComment" Width="135px" Height="66px" TextMode="MultiLine" Style="text-align: left !important"
                                            runat="server"></asp:TextBox>
                                       </td>
                                        </tr>
                                    <tr>
                                       <td class="">
                                           <img id="imgComment" visible="false" runat="server" src="../../images/comment.png"
                                            style="float: right; padding: 1px 5px; cursor: pointer;" onclick="showCommentPopup(this)" />
                                       </td>
                                        </tr>
                                    <tr>
                                       <td>
                                         <asp:Label ID="lblComment" Style="display: none;" runat="server" Text=""></asp:Label>
                                       </td>
                                     </tr>
                                  </table>
                                </ItemTemplate>
                                <HeaderStyle Width="140px" />
                                <ItemStyle Width="140px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div class="form_buttom" style="float: left;">
                    <asp:Button ID="btnSubmit" CssClass="submit" OnClientClick="javascript:return ValidateSubmit()"
                        Height="26px" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
        
        <div class="show-div">
            <asp:Label runat="server" ID="lblCommentShow"></asp:Label>
        </div>
        <div style="clear: both;">
        </div>
        </br>
      
    </div>
</asp:Content>
