<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="PendingOrderSummary.aspx.cs" Inherits="iKandi.Web.Internal.Fabric.PendingOrderSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <link href="../../css/CommanTooltip.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <style type="text/css">        
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: arial !important;
        }
        table
        {
            font-family: arial;
            border-color: gray;
            border-collapse: collapse;
        }
        th
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: arial,halvetica;
            font-size: 11px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border-color: #999;
        }
        table td
        {
            font-size: 10px;
            text-align: center;
            border-color: #dbd8d8;
            text-transform: capitalize;
            color: gray;
            padding: 3px 0px;
            font-family: arial;
        }
        .item_list1 td, .item_list1 th
        {
            padding: 5px 0px !important;
        }
        .item_list1 td
        {
            border-color: #c1bfbf;
        }
        
        .per
        {
            color: blue;
        }
        .gray
        {
            color: gray;
        }
        .TextLeft
        {
            text-align: left;
            padding-left: 2px !important;
        }
        h2
        {
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            background: #39589C;
            color: #fff;
            width: 845px;
            text-align: center;
            text-transform: capitalize;
            letter-spacing: 1px;
        }
        
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        table td table td
        {
            border-color: #ddd;
        }
        
        
        .SUPPLY-MANA td input
        {
            width: 35%;
        }
        .imageField
        {
            background-image: url(submit.jpg);
            height: 28px;
            width: 105px;
        }
        .process
        {
            padding: 0px;
            margin: 0px;
        }
        .process li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li input
        {
            width: 10%;
        }
        .supply_type
        {
            padding: 0px;
            margin: 0px;
        }
        .supply_type li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li:last-child
        {
            border-bottom: 0px;
        }
        
        .pad
        {
            text-align: left;
            padding-left: 25px;
        }
        .ths
        {
            background: #3b5998;
            font-weight: normal;
            color: #fff;
            font-family: arial;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
        }
    
        input[type="file"]
        {
            width: 90%;
            overflow: hidden;
            display: none;
        }
        .show, .hide
        {
            cursor: pointer;
        }
        a.UpdateBtn
        {
            background: url(../../images/update-icon.png) no-repeat left top;
            padding-left: 25px;
        }
        
        a.DeleteBtn
        {
            background: url(../../images/delete-icon.png) no-repeat left top;
            padding-left: 25px;
            padding-top: 3px;
        }
        #secure_banner_cor
        {
            height: calc(100vh - 100px);
        }
        /* The Modal (background) */
        .modal
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        
        /* Modal Content */
        .modal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 550px;
            margin-top: 12%;
        }
        
        /* The Close Button */
        .close
        {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        
        .close:hover, .close:focus
        {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
        .inputborder
        {
            border: 1px solid #cccccc !important;
        }
        h2.pending_order_heading
        {
            background: #dddfe4;
            width: 1353px;
            margin: 0px;
            color: #575759;
            border: 1px solid #999;
            border-bottom: 0px;
            font-weight: 600;
            font-family: arial;
            font-size: 13px;
        }
        .backcolorstages
        {
            background: #fdfd96e0 !important;
        }
        .hidesstages
        {
            display: none;
        }
        select
        {
            background: #fdfd96e0;
            color: Blue;
            width: 93% !important;
        }
        select:disabled
        {
            color: Gray;
        }
        .border_none_top_current
        {
            border-bottom: 0px !important;
        }
        .border_none_top_previus
        {
            border-top: 0px !important;
            border-bottom: 0px !important;
        }
        .position_span span
        {
            position: relative;
        }
        .p-l-2
        {
            padding-left: 2px !important;
        }
        .position_span
        {
            border-bottom: 0px;
        }
        .border_hide
        {
            border-bottom: 0px;
        }
        
        .border_hide span
        {
            display: none;
        }
        .border_hide
        {
            border-top: 0px !important;
            border-bottom: 0px !important;
        }
        
        displaynone
        {
            display: none;
        }
        .PrintColortext
        {
            font-weight: 600 !important;
        }
        
        #ctl00_cph_main_content_GrdFabric
        {
            border-top: 0px;
            border-width: 0px !important;
        }
        #ctl00_cph_main_content_GrdFabric tr:nth-child(2) td
        {
            height: 31px;
            padding: 0px 0px;
            border-top: 0px;
        }
        
        
        #ctl00_cph_main_content_GrdFabricHorizontalBar
        {
            height: 5px !important;
        }
        #ctl00_cph_main_content_GrdFabricCopy th
        {
            font-size: 11px !important;
        }
        #ctl00_cph_main_content_GrdFabricPanelHeader
        {   
            max-width:1870px!important;
            background: #fff !important;
        }
        #ctl00_cph_main_content_GrdFabricPanelItem
        {
            background: #fff !important;
        }
        #ctl00_cph_main_content_GrdFabricVerticalRail
        {
            width: 5px !important;
            background: #fff !important;
        }
        #ctl00_cph_main_content_GrdFabricVerticalBar
        {
            width: 5px !important;
            right: 10px !important;
            cursor: pointer;
        }
        .btnSubmit
        {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            height:24px;      
            cursor: pointer;
            background: rgb(19, 167, 71);
            border: none !important;
            border-radius: 0 20px 20px 0;
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
            height:24px;   
        }
        .table_width tr:first-child
        {
            font-size:40px!imporatnt;
            }
        table td:first-child
        {
            border-left-color: #999 !important;
            padding: 8px!important;
            box-sizing: border-box;
        }
        table td:last-child
        {
            border-right-color: #999 !important;
        }
        table tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        
        .border_bottom_color
        {
            border-bottom-color: #999 !important;
        }
        .txtRight
        {
            margin-left: 3px;
        }
        
        
        .ContainerWidth
        {
            margin: 0 auto;
        }
        .headerStickyPe
        {
            color: #fff;
            background: #39589c;
            text-align: center;
            margin: 0px 0px;
            font-weight: normal;
            font-size: 15px;
            width: 100%;
            margin-left: 0px;
        }
        
        @media (min-width: 1601px) and (max-width: 1920px)
        {
        
        }
        @media (min-width: 1367px) and (max-width: 1600px)
        {
        
            .ContainerWidth
            {
                margin: 0 auto;
            }
            .headerStickyPe
            {
                color: #fff;
                background: #39589c;
                text-align: center;
                margin: 0px 0px;
                font-weight: normal;
                font-size: 15px;
                width: 100%;
                clear: both;
                margin-left: 0px;
            }
        
        }
        
        @media screen and (max-width: 1280px)
        {
        
            h2.pending_order_heading
            {
                width: 1244px;
            }
        }
        .Unselected
        {
            text-decoration: line-through;
            color: Gray;
        }
        .FirstColHeader
        {
            width: 240px;
        }
        .FirstCol
        {
            width: 238px;
        }
        .SecontColHeader
        {
            width: 90px;
        }
        .SecontCol
        {
            width: 90px;
        }
        .ThurdColHeader
        {
            width: 140px;
        }
        .ThurdCol
        {
            width: 139px;
        }
        .ThurdColHeaderLine
        {
            width: 100px;
        }
        .ThurdColLine
        {
            width: 99px;
        }
        .QtyColHeader
        {
            width: 60px;
        }
        .QtyCol
        {
            width: 60px;
        }
        .SelectColHeader
        {
            width: 110px;
        }
        .SelectCol
        {
            width: 110px;
        }
        .LastColHeader
        {
            width: 50px;
        }
        .LastCol
        {
            width: 50px;
        }
        .RowBackColor
        {
            background: #e5e2e2;
        }
        
        td[colspan="13"]
        {
            border: 0px;
            padding-left: 0px !important;
        }
        a:link
        {
            text-decoration: none;
        }
        .fade-in
        {
            animation: fadeIn ease 10s;
            -webkit-animation: fadeIn ease 10s;
            -moz-animation: fadeIn ease 10s;
            -o-animation: fadeIn ease 10s;
            -ms-animation: fadeIn ease 10s;
        }
        
        #spinner
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat opacity:1;
        }
        
        

    </style>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var urls = "../../Webservices/iKandiService.asmx";
        function preventInput(evnt) {
            //Checked In IE9,Chrome,FireFox
            if (evnt.which != 9) evnt.preventDefault();
        }
        var nice = 0;
        var eleven = 0;
        var twovel = 0;
        var thirteen = 0;
        var count = 0;
        var showcount = 0;
        var scrollPosition = 0;
        function HideSizeDiv() {
            //            debugger;
            showcount = 0;

            count++;
            if (count == 1) {
                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
                    $(this).find('td:eq(' + 13 + '), th:eq(' + 13 + ')').hide();
                });
            }
            if (count == 2) {
                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
                    $(this).find('td:eq(' + 12 + '), th:eq(' + 12 + ')').hide();
                });
            }
            if (count == 3) {
                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
                    $(this).find('td:eq(' + 11 + '), th:eq(' + 11 + ')').hide();
                });
            }
        }

        function ShowSizeDiv() {
            // debugger;
            var nine = $("#ctl00_cph_main_content_GrdFabric_ctl02_hdnstageCol9").val();
            var eleven = $("#ctl00_cph_main_content_GrdFabric_ctl02_hdnstageCol11").val();
            var twovel = $("#ctl00_cph_main_content_GrdFabric_ctl02_hdnstageCol12").val();
            var thirteen = $("#ctl00_cph_main_content_GrdFabric_ctl02_hdnstageCol13").val();
            //if (parseInt(nine) > 0) {
            showcount++;
            //}
            if (showcount == 1) {
                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
                    $(this).find('td:eq(' + 9 + '), th:eq(' + 9 + ')').show();
                    $('.update').hide();
                });
            }
            //            if (parseInt(eleven) > 0) {
            //                showcount++;
            //            }
            //            if (parseInt(twovel) > 0) {
            //                showcount++;
            //            }
            //            if (parseInt(thirteen) > 0) {
            //                showcount++;
            //            }
            //            if (showcount != 3) {

            //                showcount++;
            //            }
            //            if (showcount == 1) {

            //                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
            //                    $(this).find('td:eq(' + 11 + '), th:eq(' + 11 + ')').show();


            //                });

            //            }
            //            if (showcount == 1) {

            //                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
            //                    $(this).find('td:eq(' + 11 + '), th:eq(' + 11 + ')').show();


            //                });

            //            }
            //           
            //            if (showcount == 2) {
            //                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
            //                    $(this).find('td:eq(' + 12 + '), th:eq(' + 12 + ')').show();
            //                });

            //            }
            //            if (showcount == 3) {
            //                $('#ctl00_cph_main_content_GrdFabric tr').each(function () {
            //                    $(this).find('td:eq(' + 13 + '), th:eq(' + 13 + ')').show();
            //                });
            //            }
            //ManipulateGrid();
        }

        function load_Data(elem, flag) {
            //debugger;
            var selectedval = $(elem).val();
            var Idsn = elem.id.split("_");
            if (flag == "Stage1") {

                if (document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage1").value == "1") {

                    if (document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage2").value == "-1") {
                        alert("Must select second stage");


                    }

                }
                if (selectedval == "10" || selectedval == "-1") {

                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage2").value = -1;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage3").value = -1;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage4").value = -1;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").value = -1;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").value = -1;

                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage2").disabled = true;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage3").disabled = true;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage4").disabled = true;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").disabled = true;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").disabled = true;

                }
                else if (selectedval == "1") {
                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage2").disabled = false;

                }
                UpdatePendingOrder(elem, "Stage1");
            }
            else if (flag == "Stage2") {

                if (selectedval == "-1") {

                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage3").value = -1;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage4").value = -1;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").value = -1;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").value = -1;


                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage3").disabled = true;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage4").disabled = true;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").disabled = true;
                    //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").disabled = true;
                }
                else {

                    //document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage3").disabled = false;
                }
                UpdatePendingOrder(elem, "Stage2");
            }
            //            else if (flag == "Stage3") {

            //                if (selectedval == "-1") {

            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage4").value = -1;
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").value = -1;
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").value = -1;

            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage4").disabled = true;
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").disabled = true;
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").disabled = true;
            //                }
            //                else {
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage4").disabled = false;
            //                }
            //                UpdatePendingOrder(elem, "Stage3");
            //            }
            //            else if (flag == "Stage4") {

            //                if (selectedval == "-1") {
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").value = -1;
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").value = -1;

            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").disabled = true;
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").disabled = true;
            //                }
            //                else {
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage5").disabled = false;

            //                }
            //                UpdatePendingOrder(elem, "Stage4");
            //            }
            //            else if (flag == "Stage5") {

            //                if (selectedval == "-1") {
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").value = -1;
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").disabled = true;
            //                }
            //                else {
            //                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").disabled = false;
            //                }
            //                UpdatePendingOrder(elem, "Stage5");
            //            }
            //            else if (flag == "Stage6") {
            //                document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage6").disabled = false;
            //                UpdatePendingOrder(elem, "Stage6");
            //            }

        }
        $(document).ready(function () {
           // gridviewScroll();
            //ManipulateGrid();

        });
        //        function UpdatePendingOrder(elem, StagesNo) {
        //        debugger
        //            var Idsn = elem.id.split("_");
        //            Selectedval = elem.value;
        //            OrderDetailiD = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnorderdetailid").val();
        //            FabMasterID = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnfabmasterid").val();
        ////            printColor = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_lblcolorprint").html();
        //            FabricPending_Orders_Id = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnFabricPending_Orders_Id").val();
        //            printColor = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnFabricDetails").val();
        //            stage1 = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnstage1").val();
        //            stage2 = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnstage2").val();

        //            si = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_ddlStage1").val();
        //            s2 = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_ddlStage2").val();
        //            if (StagesNo == 'Stage1')
        //                document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage2").style.border = "1px solid red";
        //            }

        //           // if (StagesNo == 'Stage2') {
        //                //               if (confirm("Are you sure want to update ?")) {
        //            $.ajax({
        //                type: 'POST',
        //                contentType: "application/json; charset=utf-8",
        //                url: urls + "/PendingOrderSummaryUpdate",
        //                data: "{ flag:'" + 'UPDATE' + "', StagesCount:'" + 'Stage1' + "', OrderDetailID:'" + OrderDetailiD + "', fabricMasterID:'" + FabMasterID + "', ColorPrin:'" + printColor + "', Stagevalt:'" + si + "', FabricPending_Orders_Id:'" + FabricPending_Orders_Id + "'}",
        //                dataType: 'JSON',
        //                success: OnSuccessCall,
        //                error: OnErrorCall
        //            });
        //            


        //                $('#ctl00_cph_main_content_btnSubmit').click();

        //                function OnSuccessCall(response) {

        //                   
        //                }

        //                function OnErrorCall(response) {
        //                    alert(response.status + " " + response.statusText);
        //                }


        function UpdatePendingOrder(elem, StagesNo) {
            debugger
            var Idsn = elem.id.split("_");
            Selectedval = elem.value;
            OrderDetailiD = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnorderdetailid").val();
            FabMasterID = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnfabmasterid").val();
            //            printColor = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_lblcolorprint").html();
            FabricPending_Orders_Id = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnFabricPending_Orders_Id").val();
            printColor = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnFabricDetails").val();
            stage1 = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnstage1").val();
            stage2 = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_hdnstage2").val();

            si = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_ddlStage1").val();
            s2 = $("#<%= GrdFabric.ClientID %>_" + Idsn[5] + "_ddlStage2").val();
            if (si == "1") {
                if (StagesNo == 'Stage1') {
                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage2").style.border = "1px solid red";
                }
            }
            if (StagesNo == 'Stage2') {
                if (s2 != "-1") {
                    document.getElementById("ctl00_cph_main_content_GrdFabric_" + Idsn[5] + "_ddlStage2").style.border = "";
                }

            }
            if (StagesNo == 'Stage2' || si == "10") {
                $.ajax({
                    type: "POST",
                    url: urls + "/PendingOrderSummaryUpdate",
                    data: "{ flag:'" + 'UPDATE' + "', StagesCount:'" + 'Stage1' + "', OrderDetailID:'" + OrderDetailiD + "', fabricMasterID:'" + FabMasterID + "', ColorPrin:'" + printColor + "', Stagevalt:'" + si + "', FabricPending_Orders_Id:'" + FabricPending_Orders_Id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCall,
                    error: OnErrorCall
                });
                $.ajax({
                    type: "POST",
                    url: urls + "/PendingOrderSummaryUpdate",
                    data: "{ flag:'" + 'UPDATE' + "', StagesCount:'" + 'Stage2' + "', OrderDetailID:'" + OrderDetailiD + "', fabricMasterID:'" + FabMasterID + "', ColorPrin:'" + printColor + "', Stagevalt:'" + s2 + "', FabricPending_Orders_Id:'" + FabricPending_Orders_Id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCall,
                    error: OnErrorCall
                });

                function OnSuccessCall(response) {

                }

                function OnErrorCall(response) {
                    alert(response.status + " " + response.statusText);
                }
            }
        }

        function CheckStage(elem) {
            debugger;
            var Idsn = elem.id.split("_");
            if ($("#" + elem.id).val() == "-1") {

                if (window.confirm("Next stages will be reset")) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }


        //        function pageLoad() {

        //           // alert('1');
        //            $("Unselected").each(function (index) {
        //                alert($(this).text());
        //            });
        //            // added code by bharat 12-may-2020
        //            ManipulateGrid();
        //            //End code bharat
        //        }
        function postIt(param) {
            debugger;
            //            $.post(
            //       "FrmBarrierWastage.aspx"
            //        , function (data) {
            //            // data was returned from the server 

            //        });
            alert("data posted in the background");
        }
        function Func(FabricQualityID, FabType, FabricDetails, CurrentStage, PreviousStage, IsStyleSpecfic, StyleID, stage2, stage3, stage4, orderdetailsID) {
            debugger;
            //            alert(FabricQualityID)
            //            alert(Stage1)
            var sURL = "FrmFabricWastageEntry.aspx?FabricQualityID=" + FabricQualityID + "&FabType=" + FabType + "&FabricDetails=" + FabricDetails + "&CurrentStage=" + CurrentStage + "&PreviousStage=" + PreviousStage + "&IsStyleSpecfic=" + IsStyleSpecfic + "&StyleID=" + StyleID + "&IsExecute=" + "YES" + "&stage1=" + FabType + "&stage2=" + stage2 + "&stage3=" + stage3 + "&stage4=" + stage4 + "&OrderDetailsID=" + orderdetailsID;
            //window.open(sURL);
            // window.open(sURL, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
            window.open(sURL, '_blank', 'height=500,width=1000,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no, _newtab');
        }
    </script>
    <%-- this code added by bharat on 25-june for header fixed--%>
<%--    <script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
        <script src="../../css/gridviewScroll.min.js" type="text/javascript"></script> --%>
    <script>
//        function gridviewScroll() {
//            //alert();
//            var gridWidth = $('#widthdiv').width() + 10;
//            var gridHeight = $('#widthdiv').height() + 10;
//            $('.headertopfixed').gridviewScroll({
//                width: gridWidth,
//                height: gridHeight
//            });
//        }


        //Add code By Bharat On 7-Oct-20 for Row Highlight
        $(document).ready(function () {
            //ManipulateGrid();
            // currentRowColor();
            $("input[type=text].costing-style").autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });

            $("input[type=text].costing-style", "#main_content").result(function () {

                var p = $(this).val().split('-');
                $(this).val(p[0]);

            });

            storeValue('myPageMode', "");

        })
        //End Code
        function pageLoad() {
           // gridviewScroll();
            currentRowColor();

            //            $("input[type=text].costing-style").autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });
            //            $('input.fab', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            //                extraParams:
            //                 {
            //                     stno: "",                   
            //                     ClientID: -999,
            //                     PrintCategory: 0
            //                 }
            $('input.fab', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/AutoComplete_Fabric_Pending_OrderSummary", { dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                 {
                     stno: "",
                     ClientID: -999,
                     PrintCategory: 0
                 }
            });

            $("input[type=text].costing-style", "#main_content").result(function () {

                var p = $(this).val().split('-');
                $(this).val(p[0]);

            });


            if (document.getElementById("ctl00_cph_main_content_hfScrollPosition").value != "") {
                //document.getElementById(document.getElementById("ctl00_cph_main_content_hfScrollPosition").value).focus();
            }

            var xp = 0;
            var ypos = 0;
            var postion = getStoredValue("myPageMode");
            if (postion != "") {
                //debugger;
                var Idsn = postion.split(",");

                xp = Idsn[0];
                ypos = Idsn[1];

            }
            //alert('2');
            debugger;
            var maxRow = 0;
            var rowSpan = 0;
            $('.PendingSummaryTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRow) {
                    maxRow = row;
                    rowSpan = 0;
                }
                if ($(this).attr('rowspan') > rowSpan) rowSpan = $(this).attr('rowspan');
            });
            if (maxRow == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpan - 1)) {
                $('.PendingSummaryTable td[rowspan]').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRow && $(this).attr('rowspan') == rowSpan) $(this).addClass('border_bottom_color');
                });
            }

            var maxRowCol = 0;
            var rowSpanCol = 0;
            $('.PendingSummaryTable td[rowspan].GriegeTableCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRowCol) {
                    maxRowCol = row;
                    rowSpanCol = 0;
                }
                if ($(this).attr('rowspan') > rowSpanCol) rowSpanCol = $(this).attr('rowspan');
            });
            if (maxRowCol == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpanCol - 1)) {
                $('.PendingSummaryTable td[rowspan].GriegeTableCol').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRowCol && $(this).attr('rowspan') == rowSpanCol) $(this).addClass('border_bottom_color');
                });
            }
            var maxRowColSt = 0;
            var rowSpanColSt = 0;
            $('.PendingSummaryTable td[rowspan].GriegeTableSt').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRowColSt) {
                    maxRowColSt = row;
                    rowSpanColSt = 0;
                }
                if ($(this).attr('rowspan') > rowSpanColSt) rowSpanColSt = $(this).attr('rowspan');
            });
            if (maxRowColSt == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpanColSt - 1)) {
                $('.PendingSummaryTable td[rowspan].GriegeTableSt').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRowColSt && $(this).attr('rowspan') == rowSpanColSt) $(this).addClass('border_bottom_color');
                });
            }
            // TooltipFun();
        }


        function printMousePos(event) {
            debugger;

            storeValue('myPageMode', event.clientX + "," + event.clientY);

            UpdateFromStock();

        }

        function storeValue(key, value) {
            if (localStorage) {
                localStorage.setItem(key, value);
            } else {
                $.cookies.set(key, value);
            }
        }

        function getStoredValue(key) {
            if (localStorage) {
                return localStorage.getItem(key);
            } else {
                return $.cookies.get(key);
            }
        }

        function TooltipFun() {
            debugger;
            //  alert();
            var RowId = 0;
            var gvId;
            var GridRow = $("#<%=GrdFabric.ClientID%> tr").length;

            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var ContactNumberMaxVal = $("#ctl00_cph_main_content_GrdFabric_" + gvId + "_hdnContactnumber").val();
                var ContactMaxLen = ContactNumberMaxVal.length;
                // alert(ContactNumberMaxVal);
                if (ContactMaxLen > 28) {
                    $(".TooltipVal span").text(function (index, currentText) {
                        var maxLength = $(this).parent().attr('data-maxlength');
                        // alert(maxLength);
                        if (currentText.length > maxLength) {
                            return currentText.substr(0, maxLength) + "...";
                        } else {
                            return currentText
                        }
                    });

                    $("#ctl00_cph_main_content_GrdFabric_" + gvId + "_lblContractNumber").attr('data-title', ContactNumberMaxVal);

                }
                var LineNumberMaxVal = $("#ctl00_cph_main_content_GrdFabric_" + gvId + "_hdnLineItemNumber").val();
                var LineMaxLen = LineNumberMaxVal.length;
                if (LineMaxLen > 12) {
                    $(".TooltipVal span").text(function (index, currentText) {
                        var maxLength = $(this).parent().attr('data-maxlength');
                        // alert(maxLength);
                        if (currentText.length > maxLength) {
                            return currentText.substr(0, maxLength) + "...";
                        } else {
                            return currentText
                        }
                    });
                    $("#ctl00_cph_main_content_GrdFabric_" + gvId + "_lblLineItemNumber").attr('data-title', LineNumberMaxVal);

                }

                setInterval(function () {
                    //   $("#LoaderOnLoad").hide();
                }, 3000);
            }

        }

        function currentRowColor() {
            $('.PendingSummaryTable tr td').click(function () {
                $('td').removeClass('RowBackColor');
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td').addClass('RowBackColor');
                    parent = $(parent).next();
                }
            });

            $('.PendingSummaryTable tr td').click(function () {
                $('td[rowspan]').removeClass('RowBackColor');
            });

            $('.PendingSummaryTable tr td[rowspan]:first-child').click(function () {
                debugger;
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
            });

            $('.PendingSummaryTable tr td[rowspan]:nth-child(2)').click(function () {
                debugger;
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
                //$('td[rowspan]:nth-child(1)').removeClass('RowBackColor');
                $('td[rowspan="' + rowspanCount + '"]:nth-child(1)').removeClass('RowBackColor');
            });

            $('.PendingSummaryTable tr td[rowspan]:nth-child(3)').click(function () {
                var rowspanCount = $(this).attr('rowspan');
                var parent = $(this).parent();
                for (var i = 1; i <= rowspanCount; i++) {
                    $(parent).find('td[rowspan]').addClass('RowBackColor');
                    parent = $(parent).next();
                }
                $('td[rowspan]:nth-child(1)').removeClass('RowBackColor');
                $('td[rowspan]:nth-child(2)').removeClass('RowBackColor');
            });
        }

        function UpdateFromStock() {
//            alert('Hello Test');
//            var Isselected = $("#ctl00_cph_main_content_GrdFabric_ctl02_chkfinalised").val;
//            alert(Isselected);

            if ($("#ctl00_cph_main_content_GrdFabric_ctl02_chkfinalised").is(":checked")) {
                //                alert($("#ctl00_cph_main_content_GrdFabric_ctl02_chkfinalised").val());
                var isYes = confirm("Do you want to Stock Allocation By Default?");
                if (isYes == true) {
                    $("#ctl00_cph_main_content_GrdFabric_ctl02_hdnAllocateStock").val("1");
                }
                else {
                    $("#ctl00_cph_main_content_GrdFabric_ctl02_hdnAllocateStock").val("0");
                }
                //alert($("#ctl00_cph_main_content_GrdFabric_ctl02_hdnAllocateStock").val());
            }

        }
    </script>



    <%--  end--%>
    <asp:HiddenField ID="hdnxpostion" EnableViewState="true" Value="" runat="server" />
    <asp:HiddenField ID="hdnypostion" Value="" EnableViewState="true" runat="server" />
    <asp:ScriptManager ID="scriptContactdetails" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upnl">
        <ProgressTemplate>
            <%-- <img src="../../App_Themes/ikandi/images1/loading128.gif" alt="" id="LoaderOnLoad" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />--%>
            <div id="spinner" class="fade-in">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <div>
            </div>
            <%--<div style="height:24px;"></div>--%>
            <div id="dvscroll" class="outerDiv ContainerWidth">
                <div class="headerStickyPe">
                    Fabric Pending Order for stage selection</div>
               <fieldset style="margin: 10px 0; padding-top: 10px; width: 350px; border-color: #dddfe4; border-radius:4px;">
                    <div style="display:flex">
                        <%--Fabric Quality name :--%>
                        <asp:TextBox ID="txtfabname" CssClass="fab do-not-disable" Style="outline:none;border-right:none; height:20px; width: 90%; font-size: 11px;"
                            placeholder="Search Fabric Quality/Style No/Serial No" runat="server"></asp:TextBox>

                            <asp:Button ID="btnSearch" CssClass="submit btnSubmit" runat="server" type="search"
                            Text="Search" OnClick="btnSearch_Click" />
                    </div>
                    <%--<div style="float:left;margin-right:10px;">
                        Style number :
                        <asp:TextBox ID="txtstylenumber" CssClass="costing-style do-not-disable" type="search"
                            Style="width: 211px;" runat="server"></asp:TextBox>
                     </div>--%>
              
                    </fieldset>
                    <asp:HiddenField ID="hfScrollPosition" Value="" runat="server" />
               

                <asp:HiddenField ID="hdnclickcount" runat="server" Value="0" />
                <table class="grds  PendingSummaryTable" cellspacing="0" rules="all" border="1" style="border-width: 1px;
                    border-style: solid; width: 1350px; display: none; border-collapse: collapse;
                    margin: 0 auto; margin-left: 0px;">
                    <tbody>
                        <tr class="ths" align="center" style="font-family: Arial;">
                            <th class="p-l-2 FirstColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 201px;">
                                    Fabric Quality (GSM) Width<br>
                                    Color/Print<br>
                                    (Fabric Type) Unit
                                </div>
                            </th>
                            <th class="SecontColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 91px;">
                                    Style Number</div>
                            </th>
                            <th class="ThurdColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 141px;">
                                    Serial No.(Order Date)</div>
                            </th>
                            <th class="ThurdColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 141px;">
                                    line no. (Ex-Factory)</div>
                            </th>
                            <th class="SecontColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 91px;">
                                    Contract Number</div>
                            </th>
                            <th class="QtyColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 61px;">
                                    Order Qty. <span style="color: gray">Pcs.</span></div>
                            </th>
                            <th class="QtyColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 61px;">
                                    Avg.</div>
                            </th>
                            <th class="QtyColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 61px;">
                                    Fabric Qty.</div>
                            </th>
                            <th class="SelectColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 112px;">
                                    Stage 1</div>
                            </th>
                            <th class="SelectColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 112px;">
                                    Stage 2</div>
                            </th>
                            <th class="SelectColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 112px;">
                                    Stage 3</div>
                            </th>
                            <th class="SelectColHeader" align="center" scope="col">
                                <div class="GridCellDiv" style="width: 113px;">
                                    Stage 4</div>
                            </th>
                            <th class="LastColHeader" scope="col">
                                <div class="GridCellDiv" style="width: 52px;">
                                    Finalize</div>
                            </th>
                        </tr>
                    </tbody>
                </table>
                <%-- <table CssClass="grds  PendingSummaryTable">
                
                
                    <tr class="ths" align="center" style="font-family: Arial;">
                        <th class="p-l-2 FirstColHeader" align="center" scope="col">
                            Fabric Quality (GSM) Width<br>
                            Color/Print<br>
                            (Fabric Type)
                        </th>
                        <th class="SecontColHeader" align="center" scope="col">
                            Style Number
                        </th>
                        <th class="ThurdColHeader" align="center" scope="col">
                            Serial No.(Order Date)
                        </th>
                        <th class="ThurdColHeader" align="center" scope="col">
                            line no. (Ex-Factory)
                        </th>
                        <th class="SecontColHeader" align="center" scope="col">
                            Contract Number
                        </th>
                        <th class="QtyColHeader" align="center" scope="col">
                            Order Qty. <span style="color: gray">Pcs.</span>
                        </th>
                        <th class="QtyColHeader" align="center" scope="col">
                            Avg.
                        </th>
                        <th class="QtyColHeader" align="center" scope="col">
                            Fabric Qty.<span style="color: gray"> Mtr.</span>
                        </th>
                        <th class="SelectColHeader" align="center" scope="col">
                            Stage 1
                        </th>
                        <th class="SelectColHeader" align="center" scope="col">
                            Stage 2
                        </th>
                        <th class="SelectColHeader" align="center" scope="col">
                            Stage 3
                        </th>
                        <th class="SelectColHeader" align="center" scope="col">
                            Stage 4
                        </th>
                        <th class="LastColHeader" scope="col">
                            Finalize
                        </th>
                    </tr>
                    </table>--%>
                <div id="widthdiv" class="table_width" style="padding-bottom:40px;">
                    <asp:GridView ID="GrdFabric" runat="server" AutoGenerateColumns="False" CssClass="grds headertopfixed PendingSummaryTable table_width"
                        ShowHeader="true" EmptyDataText="No Record Found!" OnRowCommand="GrdFabric_RowCommand"
                        Width="100%" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                        OnDataBound="GrdFabric_DataBound" OnRowDataBound="GrdFabric_RowDataBound" BorderWidth="1"
                        HeaderStyle-CssClass="ths">
                        <SelectedRowStyle BackColor="#A1DCF2" />
                        <Columns>
                            <asp:TemplateField HeaderText="Fabric Quality (GSM) Width<br> Color/Print<br>(Fabric Type)<br>Unit">
                                <HeaderStyle HorizontalAlign="Center" CssClass="p-l-2 FirstColHeader" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnfab" Value='<%# Eval("finalfab")%>' runat="server" />
                                    <a href='../../Internal/Fabric/FabricViewAll.aspx?TradeName=<%# Eval("TradeName")%>'
                                        target="_blank" title='<%# (Convert.ToInt32(Eval("Stage1")) >0)?"Raise & Revise Po":"Stage Selection Not Done" %>'>
                                        <asp:Label ID="lblFabricQuality" ForeColor="blue" Text='<%# Eval("TradeName")%>'
                                            runat="server"></asp:Label>
                                    </a>
                                    <asp:Label ID="lblgsm" Text='<%# Eval("gsm")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblwidth" ForeColor="gray" Text='<%# Eval("cutwidth")%>' runat="server"></asp:Label><br />
                                    <asp:Label ID="lblcolorprint" CssClass="PrintColortext" Font-Bold="false" Text='<%# Eval("FabricDetails")%>'
                                        runat="server"></asp:Label><br />
                                    (<asp:Label ID="lblfabtype" Text='<%# Eval("FabType")%>' runat="server"></asp:Label>)
                                    <%--added by raghvinder on 25-09-2020 start--%>
                                    <asp:Label ID="lblUnit" CssClass="PrintColortext" ForeColor="Gray" Font-Bold="true"
                                        runat="server" Text='<%# Eval("UnitName") == "" ? "" : Eval("UnitName")%>'></asp:Label>
                                    <%--added by raghvinder on 25-09-2020 end--%>
                                </ItemTemplate>
                                <ItemStyle CssClass="TextLeft GriegeTableCol FirstCol" Height="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Style Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblstylenumber" Text='<%# Eval("StyleNumber")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="GriegeTableSt SecontCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="SecontColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial No.(Order Date)">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNo" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                    <%--<asp:Label ID="lblOrderDate" CssClass="txtRight" Text='<%# (Convert.ToDateTime(Eval("OrderDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM yy (ddd)")%>'--%>
                                    <asp:Label ID="lblOrderDate" CssClass="txtRight" Text='<%# (Convert.ToDateTime(Eval("OrderDate")) == DateTime.MinValue) ? "" : "(" + (Convert.ToDateTime(Eval("OrderDate"))).ToString("dd MMM") + ")" %>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="positionstyle_span ThurdCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="ThurdColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="line no.<br>(Ex-Factory)">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnstageCol9" runat="server" Value='<%# Eval("Colvisbile9")%>' />
                                    <asp:HiddenField ID="hdnstageCol11" runat="server" Value='<%# Eval("Colvisbile11")%>' />
                                    <asp:HiddenField ID="hdnstageCol12" runat="server" Value='<%# Eval("Colvisbile12")%>' />
                                    <asp:HiddenField ID="hdnstageCol13" runat="server" Value='<%# Eval("Colvisbile13")%>' />
                                    <asp:HiddenField ID="hdnFabricPending_Orders_Id" runat="server" Value='<%# Eval("FabricPending_Orders_Id")%>' />
                                    <asp:HiddenField ID="hdnfabmasterid" runat="server" Value='<%# Eval("FabricMaster_Id")%>' />
                                    <asp:HiddenField ID="hdnorderdetailid" runat="server" Value='<%# Eval("OrderDetailsID")%>' />
                                    <asp:HiddenField ID="hdntradecount" runat="server" Value='<%# Eval("TradeCount")%>' />
                                    <asp:HiddenField ID="hdncountstylenumber" runat="server" Value='<%# Eval("TradeCountStyleNumber")%>' />
                                    <asp:HiddenField ID="hdncountserialnumber" runat="server" Value='<%# Eval("TradeCountSerialNumber")%>' />
                                    <asp:HiddenField ID="hdnstage1" runat="server" Value='<%# Eval("Stage1")%>' />
                                    <asp:HiddenField ID="hdnstage2" runat="server" Value='<%# Eval("Stage2")%>' />
                                    <asp:HiddenField ID="hdnstage3" runat="server" Value='<%# Eval("Stage3")%>' />
                                    <asp:HiddenField ID="hdnstage4" runat="server" Value='<%# Eval("Stage4")%>' />
                                    <asp:HiddenField ID="hdnFabricDetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                                    <div class="TooltipVal" data-maxlength='12'>
                                        <asp:Label ID="lblLineItemNumber" ForeColor="gray" Text='<%# Eval("LineItemNumber")%>'
                                            runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnLineItemNumber" runat="server" Value='<%# Eval("LineItemNumber")%>' />
                                    </div>
                                    <asp:HiddenField ID="hdnintialapprovel" runat="server" Value='<%# Eval("IsIntialApproved")%>' />
                                    <asp:HiddenField ID="hdnIsSrvRecived" runat="server" Value='<%# Eval("IsSrvRecived")%>' />
                                    <asp:HiddenField ID="hdnIsSrvRecived2" runat="server" Value='<%# Eval("IsSrvRecived2")%>' />
                                    <asp:HiddenField ID="hdnIsSrvRecived3" runat="server" Value='<%# Eval("IsSrvRecived3")%>' />
                                    <asp:HiddenField ID="hdnIsSrvRecived4" runat="server" Value='<%# Eval("IsSrvRecived4")%>' />
                                    <asp:HiddenField ID="hdnsta" runat="server" Value='<%# Eval("IsSrvRecived2")%>' />
                                    <asp:HiddenField ID="hdnstyleid" runat="server" Value='<%# Eval("styleid")%>' />
                                    <asp:HiddenField ID="hdnorderid" runat="server" Value='<%# Eval("orderid")%>' />
                                    <asp:HiddenField ID="hdnLockFabricPendingStages" runat="server" Value='<%# Eval("LockFabricPendingStages")%>' />
                                    <asp:HiddenField ID="hdns1lock" runat="server" Value='<%# Eval("S1lock")%>' />
                                    <asp:HiddenField ID="hdns2lock" runat="server" Value='<%# Eval("S2lock")%>' />
                                    <asp:HiddenField ID="hdns3lock" runat="server" Value='<%# Eval("S3lock")%>' />
                                    <asp:HiddenField ID="hdns4lock" runat="server" Value='<%# Eval("S4lock")%>' />
                                    <%--<asp:Label ID="lblExFactory" CssClass="txtRight" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>--%>
                                    <asp:Label ID="lblExFactory" CssClass="txtRight" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : "("+ (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM") + ")"%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="ThurdColLine" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="ThurdColHeaderLine" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Number">
                                <ItemTemplate>
                                    <div class="TooltipVal" data-maxlength="28">
                                        <asp:Label ID="lblContractNumber" Text='<%# Eval("ContractNumber")%>' runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnContactnumber" runat="server" Value='<%# Eval("ContractNumber")%>' />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle CssClass="SecontCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="SecontColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Order Qty.">
                                <ItemTemplate>
                                    <asp:Label ID="lblContractQty" Text='<%# Convert.ToString(Eval("ContractQty")) == "0" ? "" : Convert.ToInt32(Eval("ContractQty")).ToString("N0")%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="QtyCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="QtyColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Avg.">
                                <ItemTemplate>
                                    <asp:Label ID="lblFabricAvg" Text='<%# Convert.ToString(Eval("FabricAvg")) == "0" ? "" : Convert.ToString(Eval("FabricAvg")).ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="QtyCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="QtyColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fabric Qty.">
                                <ItemTemplate>
                                    <asp:Label ID="lblFabricQty" Text='<%# Convert.ToString(Eval("FabricQty")) == "0" ? "" : Convert.ToString(Eval("FabricQty")).ToString()%>'
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="QtyCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="QtyColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stage 1">
                                <ItemTemplate>
                                    <%-- <asp:ImageButton ID="imgbtnDel" ToolTip="DELETE THIS CONTRACT" ImageUrl="~/images/delete-icon.png"
                                            
                                            CommandName="DeleteRow" runat="server" />--%>
                                    <asp:DropDownList ID="ddlStage1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                        CommandName="StageChange" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                    <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select SupplierType_Id,	Name,Type from tblSupplierType where type=1 and SupplierType_Id in (1,10)">
                    </asp:SqlDataSource>--%>
                                </ItemTemplate>
                                <ItemStyle CssClass="Stage1 backcolorstages SelectCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="SelectColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stage 2">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlStage2" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                        CommandName="StageChange" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle CssClass="Stage2 backcolorstages SelectCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="SelectColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stage 3">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlStage3" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                        CommandName="StageChange" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle CssClass="Stage2 backcolorstages SelectCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="SelectColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stage 4">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlStage4" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                        CommandName="StageChange" AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle CssClass="Stage2 backcolorstages SelectCol" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="SelectColHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Finalize">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkfinalised" AutoPostBack="true" onclick="printMousePos(event)"
                                        OnCheckedChanged="chkfinalised_CheckedChanged" Checked='<%# Eval("IsFinlaize") %>'
                                        runat="server" />
                                        <asp:HiddenField ID="hdnAllocateStock" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="LastCol" />
                                <HeaderStyle CssClass="LastColHeader" />
                            </asp:TemplateField>
                            <%--  <asp:TemplateField HeaderText="S.no">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>'
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="LastCol" />
                                <HeaderStyle CssClass="LastColHeader" />
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderStyle-CssClass="displaynone" HeaderText="Stage 3">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStage3" DataTextField="Name" SelectedValue='<%# Bind("Stage3") %>'
                        AppendDataBoundItems="true" onchange="javascript:load_Data(this,'Stage3');" DataValueField="SupplierType_Id"
                        DataSourceID="SqlDataSource3" runat="server">
                        <asp:ListItem Text="Select" Value="-1" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select SupplierType_Id,	Name,Type from tblSupplierType where type=1 and SupplierType_Id in (2,3)">
                    </asp:SqlDataSource>
                </ItemTemplate>
                <ItemStyle Width="70px" CssClass="Stage3 backcolorstages" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="displaynone" HeaderText="Stage 4">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStage4" DataTextField="Name" SelectedValue='<%# Bind("Stage4") %>'
                        AppendDataBoundItems="true" onchange="javascript:load_Data(this,'Stage4');" DataValueField="SupplierType_Id"
                        DataSourceID="SqlDataSource4" runat="server">
                        <asp:ListItem Text="Select" Value="-1" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select SupplierType_Id,	Name,Type from tblSupplierType where type=1 and SupplierType_Id in (2,3)">
                    </asp:SqlDataSource>
                </ItemTemplate>
                <ItemStyle Width="70px" CssClass="Stage4 backcolorstages hidesstages" />
                <HeaderStyle CssClass="hidesstages" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="displaynone" HeaderText="Stage 5">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStage5" DataTextField="Name" SelectedValue='<%# Bind("Stage5") %>'
                        AppendDataBoundItems="true" onchange="javascript:load_Data(this,'Stage5');" DataValueField="SupplierType_Id"
                        DataSourceID="SqlDataSource5" runat="server">
                        <asp:ListItem Text="Select" Value="-1" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select SupplierType_Id,	Name,Type from tblSupplierType where type=1 and SupplierType_Id in (2,3)">
                    </asp:SqlDataSource>
                </ItemTemplate>
                <ItemStyle  Width="70px" CssClass="Stage5 backcolorstages hidesstages" />
                <HeaderStyle CssClass="hidesstages" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="displaynone" HeaderText="Stage 6">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStage6" DataTextField="Name" SelectedValue='<%# Bind("Stage6") %>'
                        AppendDataBoundItems="true" onchange="javascript:load_Data(this,'Stage6');" DataValueField="SupplierType_Id"
                        DataSourceID="SqlDataSource6" runat="server">
                        <asp:ListItem Text="Select" Value="-1" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select SupplierType_Id,	Name,Type from tblSupplierType where type=1 and SupplierType_Id in (2,3)">
                    </asp:SqlDataSource>
                </ItemTemplate>
                <ItemStyle Width="70px" CssClass="Stage6 backcolorstages hidesstages" />
                <HeaderStyle CssClass="hidesstages" />
            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="grds headertopfixed PendingSummaryTable" cellspacing="0" rules="all"
                                border="1" style="border-width: 1px; border-style: solid; width: 1321px; border-collapse: collapse;
                                margin: 0 auto; margin-left: 0px;">
                                <tbody>
                                    <tr class="ths" align="center" style="font-family: Arial;" id="ctl00_cph_main_content_GrdFabricHeaderCopy">
                                        <th class="p-l-2 FirstColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 150px;">
                                                Fabric Quality (GSM) Width<br>
                                                Color/Print<br>
                                                (Fabric Type)<br>
                                                Unit</div>
                                        </th>
                                        <th class="SecontColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 92px;">
                                                Style Number</div>
                                        </th>
                                        <th class="ThurdColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 143px;">
                                                Serial No.(Order Date)</div>
                                        </th>
                                        <th class="ThurdColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 143px;">
                                                line no.<br>
                                                (Ex-Factory)</div>
                                        </th>
                                        <th class="SecontColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 92px;">
                                                Contract Number</div>
                                        </th>
                                        <th class="QtyColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 61px;">
                                                Order Qty.</div>
                                        </th>
                                        <th class="QtyColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 62px;">
                                                Avg.</div>
                                        </th>
                                        <th class="QtyColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 62px;">
                                                Fabric Qty.</div>
                                        </th>
                                        <th class="SelectColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 113px;">
                                                Stage 1</div>
                                        </th>
                                        <th class="SelectColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 113px;">
                                                Stage 2</div>
                                        </th>
                                        <th class="SelectColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 113px;">
                                                Stage 3</div>
                                        </th>
                                        <th class="SelectColHeader" align="center" scope="col">
                                            <div class="GridCellDiv" style="width: 113px;">
                                                Stage 4</div>
                                        </th>
                                        <th class="LastColHeader" scope="col">
                                            <div class="GridCellDiv" style="width: 52px;">
                                                Finalize</div>
                                        </th>
                                    </tr>
                                    <td colspan="13" style="border: 1px solid #999; border-top: 0px; text-align: center">
                                        <img src="../../images/sorry.png" />
                                    </td>
                                </tbody>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="do-not-include btnSubmit"
                    OnClick="btnSubmit_Click" Style="margin-left: 2px; display: none; margin-top: 10px;" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
