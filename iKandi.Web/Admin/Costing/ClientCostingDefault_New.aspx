
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master"
    CodeBehind="ClientCostingDefault_New.aspx.cs" Inherits="iKandi.Web.ClientCostingDefault_New" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_main_content">
    <script type="text/javascript" language="javascript">
        //debugger;
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var gvClientCostingDefaultsClientID = '<%=gvClientCostingDefaults.ClientID %>';
        function UpdateAchievement_ByClient(elem, HeaderNo) {
            //debugger;

            //  var isYes = confirm("Apply for all Department?");

            var AchiveValue = $(elem).val();
            if (AchiveValue == "")
                AchiveValue = 0;
            var Idsn = elem.id.split("_");
            Ids = parseFloat(Idsn[5].substr(3));
            Ids2 = parseFloat(Idsn[5].substr(2));
            Ids4 = parseFloat(Idsn[5].substr(4));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnClientId" + "']").val();

            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();
            //this code added by bharat on 30-may for Confrim box popup
            functionConfirm("Apply for all Department?", function yes() {
                //  alert("Yes");
                 debugger;
                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                            function (result) {
                                //  alert("Update Successfully.");
                                location.href = location.href;
                            });
                return false;
            },

              function no() {
                  proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                                function (result) {
                                    //alert("Update Successfully.");
                                });
                  return false;
              });
            //end
            ////            if (isYes == true) {
            ////                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                        function (result) {
            ////                            //  alert("Update Successfully.");
            ////                            location.href = location.href;
            ////                        });
            ////            }
            ////            else {
            ////                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                        function (result) {
            ////                            //alert("Update Successfully.");
            ////                        });
            ////            }
        }





        //----------------Add By Prabhaker-06-Dec-17--------------//


        function UpdateMode_ByClient_IsChecked(elem, HeaderName) {
            debugger;
            // var isYes = confirm("Apply for all Department?");
            var AchiveValue = 0;
            //var HeaderName = $(elem).siblings().val();
            //var HeaderName = $(elem).parent().parent().find("input[type=hidden]").val();
            //            alert(HeaderName);
            // alert($(elem).siblings().val());
            var flag = 1;
            //alert(HeaderName);
            var Idsn = elem.id.split("_");
            // alert(Idsn[5].substr(4));
            Ids = parseFloat(Idsn[5].substr(3));
            Ids2 = parseFloat(Idsn[5].substr(2));
            Ids4 = parseFloat(Idsn[5].substr(4));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnClientId" + "']").val();
            //alert(ClientId);
            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();

            if (elem.checked) {
                AchiveValue = 1;
            }
            else {
                AchiveValue = 0;
            }
            //var hdnOhValue = $(elem).val();
            // codee added by bharat on 30-may
            functionConfirm("Apply for all Department?", function yes() {

                proxy.invoke("UpdateClientCostingMode_ByClient_New", { ClientId: ClientId, DeptId: 0, HeaderName: HeaderName, AchiveValue: AchiveValue },
                            function (result) {
                                debugger; 
                                //alert("Update Successfully");
                                location.href = location.href;
                            });
                return false;
            },

              function no() {
                  proxy.invoke("UpdateClientCostingMode_ByClient_New", { ClientId: ClientId, DeptId: DeptId, HeaderName: HeaderName, AchiveValue: AchiveValue },
                            function (result) {
                                debugger; 
                                // alert("Update Successfully");
                            });
                  return false;
              });

            //end

            ////            if (isYes == true) {
            ////                proxy.invoke("UpdateClientCostingMode_ByClient_New", { ClientId: ClientId, DeptId: 0, HeaderName: HeaderName, AchiveValue: AchiveValue },
            ////                            function (result) {
            ////                                //debugger; 
            ////                                //alert("Update Successfully");
            ////                                location.href = location.href;
            ////                            });
            ////            }
            ////            else {

            ////                proxy.invoke("UpdateClientCostingMode_ByClient_New", { ClientId: ClientId, DeptId: DeptId, HeaderName: HeaderName, AchiveValue: AchiveValue },
            ////                            function (result) {
            ////                                //debugger; 
            ////                                // alert("Update Successfully");
            ////                            });
            ////            }

        }




        function UpdateAchievement_ByClient_IsChecked(elem, HeaderNo) {
            debugger;
            //var isYes = confirm("Apply for all Department?");
            var AchiveValue = $(elem).val();
            if (AchiveValue == "")
                AchiveValue = 0;
            var Idsn = elem.id.split("_");
            Ids = parseFloat(Idsn[5].substr(3));
            Ids2 = parseFloat(Idsn[5].substr(2));
            Ids4 = parseFloat(Idsn[5].substr(4));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnClientId" + "']").val();
            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();
            var hdnOhValue = $("#ctl00_cph_main_content_hdnIsOhPercentChecked").val();

            //this code added by bharat updated OH Cost Value

            functionConfirm("Apply for all Department?", function yes() {

                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                            function (result) {
                                //debugger; 
                                //  alert("Update Successfully");
                                location.href = location.href;
                            });
                return false;
            },

              function no() {
                  proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                            function (result) {
                                //debugger; 
                                //  alert("Update Successfully");
                                // location.href = location.href;
                            });
                  return false;
              });

            ////            if (isYes == true) {
            ////                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                            function (result) {
            ////                                //debugger; 
            ////                                //  alert("Update Successfully");
            ////                                location.href = location.href;
            ////                            });
            ////            }
            ////            else {

            ////                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                            function (result) {
            ////                                //debugger; 
            ////                                //  alert("Update Successfully");
            ////                                location.href = location.href;
            ////                            });
            ////            }
        }



        function UpdateClientCostingValues_ByClient_OverHead(elem, HeaderNo, ClientId, DeptId) {
            //debugger;
            //var isYes = confirm("Apply for all Department?");
            Values = $(elem).is(':checked') ? 1 : 0;

            //this code added by bharat on 30-may for Confrim box popup
            functionConfirm("Apply for all Department?", function yes() {
                if (Values == "0") {
                    var hdnOhValue = $("#ctl00_cph_main_content_hdnOhValue").val();
                    if (hdnOhValue == "0") {
                        alert("First Set Non 0 OH Cost Value then Unselect Is OH % Checkbox");
                        //                        location.href = location.href;
                    }
                    else {
                        proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
                 function (result) {
                     // alert("Update Successfully");
                     location.href = location.href;
                 });
                    }
                }
                else {
                    proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
                 function (result) {
                     // alert("Update Successfully");
                     location.href = location.href;
                 });
                }
                return false;
            },

             function no() {
                 if (Values == "1") {
                     proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
                        function (result) {
                            //alert("Update Successfully");
                            //                            location.href = location.href;
                        });
                 }
                 else {
                     var Idsn = elem.id.split("_");
                     Ids = parseFloat(Idsn[5].substr(3));
                     Ids2 = parseFloat(Idsn[5].substr(2));
                     Ids4 = parseFloat(Idsn[5].substr(4));
                     Ids = Ids;
                     if (Ids <= 9) { Ids = "0" + Ids; } else { Ids = Ids; }
                     var txtOverheadValue = $("#ctl00_cph_main_content_gvClientCostingDefaults_ctl" + Ids + "_txtOverHeadValue").val();
                     if (txtOverheadValue == "") {
                         // alert("First Enter OH Value");
                         //                        location.href = location.href;
                     }
                     else {
                         proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
                        function (result) {
                            // alert("Update Successfully");
                            //                            location.href = location.href;
                        });
                     }

                 }
                 return false;
             });

            //end


            ////            if (isYes == true) {
            ////                if (Values == "0") {
            ////                    var hdnOhValue = $("#ctl00_cph_main_content_hdnOhValue").val();
            ////                    if (hdnOhValue == "0") {
            ////                        alert("First Set Non 0 OH Cost Value then Unselect Is OH % Checkbox");
            ////                        //                        location.href = location.href;
            ////                    }
            ////                    else {
            ////                        proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
            ////                 function (result) {
            ////                     // alert("Update Successfully");
            ////                     location.href = location.href;
            ////                 });
            ////                    }
            ////                }
            ////                else {
            ////                    proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
            ////                 function (result) {
            ////                     // alert("Update Successfully");
            ////                     //                     location.href = location.href;
            ////                 });
            ////                }
            ////            }

            ////            else {
            ////                if (Values == "1") {
            ////                    proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
            ////                        function (result) {
            ////                            //alert("Update Successfully");
            ////                            //                            location.href = location.href;
            ////                        });
            ////                }
            ////                else {
            ////                    var Idsn = elem.id.split("_");
            ////                    Ids = parseFloat(Idsn[5].substr(3));
            ////                    Ids2 = parseFloat(Idsn[5].substr(2));
            ////                    Ids4 = parseFloat(Idsn[5].substr(4));
            ////                    Ids = Ids;
            ////                    if (Ids <= 9) { Ids = "0" + Ids; } else { Ids = Ids; }
            ////                    var txtOverheadValue = $("#ctl00_cph_main_content_gvClientCostingDefaults_ctl" + Ids + "_txtOverHeadValue").val();
            ////                    if (txtOverheadValue == "") {
            ////                        // alert("First Enter OH Value");
            ////                        //                        location.href = location.href;
            ////                    }
            ////                    else {
            ////                        proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
            ////                        function (result) {
            ////                            // alert("Update Successfully");
            ////                            //                            location.href = location.href;
            ////                        });
            ////                    }

            ////                }
            ////            }
        }



        function UpdateClientCostingValues_ByClient(elem, HeaderNo, ClientId, DeptId) {

            //debugger;

            var isYes = confirm("Apply for all Department?");

            Values = $(elem).is(':checked') ? 1 : 0;

            if (isYes == true) {

                proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },

                        function (result) {
                            alert(result);
                            //alert('This Quantity has been updated successfully!');
                            location.href = location.href;
                        });
            }

            else {
                proxy.invoke("UpdateClientCostingValues_ByClient_New", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },

                        function (result) {
                            alert(result);
                            // alert('This Quantity has been updated successfully!');
                            location.href = location.href;
                        });
            }
        }

        function UpdateSize_ByClient(elem, HeaderNo) {

            //var isYes = confirm("Apply for all Department?");
            // debugger;
            var AchiveValue = $(elem).val();
            if (AchiveValue == "")
                AchiveValue = 0;
            var Ids = elem.id.split("_");
            var Idsn = elem.id.split("_");
            Ids = parseFloat(Ids[5].substr(3));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnClientId" + "']").val();
            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();

            functionConfirm("Apply for all Department?", function yes() {
                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                        function (result) {
                            // alert('This has been updated successfully!');
                            window.location.reload();
                        });
                return false;
            },

              function no() {
                  proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                        function (result) {
                            // alert('This has been updated successfully!');
                        });
                  return false;
              });


            ////            if (isYes == true) {
            ////                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                        function (result) {
            ////                            alert('This has been updated successfully!');
            ////                            window.location.reload();
            ////                        });
            ////            }
            ////            else {
            ////                proxy.invoke("UpdateExpectedByClient_New", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                        function (result) {
            ////                            alert('This has been updated successfully!');
            ////                        });
            ////            }
        }
        $(document).ready(function () {
            gridviewScroll();
            //alert();
        });

    </script>
    <script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../../css/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        /* add by dinesh page scrolls to the top */

        $(document).ready(function () {
            $('#widthdiv').scroll(function () {
                if ($(this).scrollTop() > 250) {
                    $('#scrolltop_btn').css("right", "50px");
                } else {
                    $('#scrolltop_btn').css("right", "-50px");
                }
            });
        });

        function scrollToTop() {
            $('#widthdiv').animate({ scrollTop: 0 }, 800);
        }

        /* end */






        function gridviewScroll() {
            var gridWidth = $('#widthdiv').width();
            var gridHeight = $('#widthdiv').height() + 10;

            $('.headertopfixed').gridviewScroll({
                width: gridWidth,
                height: gridHeight,
                freezesize: 2
                // headerrowcount: 2
            });
        }

        //code added by bharat on 30-may for confrim box

        function functionConfirm(msg, myYes, myNo) {
            var confirmBox = $("#confirm");
            confirmBox.find(".message").text(msg);
            confirmBox.find(".OkBoutton,.NoBoutton").unbind().click(function () {
                confirmBox.hide();
            });
            confirmBox.find(".OkBoutton").click(myYes);
            confirmBox.find(".NoBoutton").click(myNo);
            confirmBox.show();
            return false;
        }
    </script>
    <!------------------------Add-by Prabhaker--------------------------->
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <style type="text/css">
        #secure_banner_cor, #main_content
        {
            background: none !important;
        }
        
        
        .item_list th
        {
            padding: 0px;
            text-transform: none !important;
            border-color: #999 !important;
            font-weight: 500 !important;
            color: #000 !important;
        }
        .item_list td
        {
            padding: 5px !important;
            border-color: #dbd8d8;
        }
        
        .form_box
        {
            width: 100%;
            padding-bottom: 15px;
        }
        
        .print-box
        {
            background-color: #fff;
        }
        .HiddenCol
        {
            display: none;
        }
        option
        {
            text-transform: capitalize !important;
        }
        input
        {
            width: 90%;
        }
        .HeaderStyle1
        {
            background: #FFEDED !important;
            font-weight: bold !important;
            color: #705a5a !important;
        }
        .HeaderStyle2
        {
            background: #dddfe4 !important;
            font-weight: bold !important;
            color: #705a5a !important;
        }
        .HeaderStyle3
        {
            background: #dddfe4 !important;
            font-weight: bold !important;
            color: #705a5a !important;
        }
        .table_width
        {
            width: 100%;
            max-height: 800px;
            min-height: 150px;
        }
        .MinClientHeader
        {
            min-width: 100px;
            max-width: 100px;
            background-color:#ecececd6 !important
        }
        .MinClientStyle
        {
            min-width: 90px;
            max-width: 90px;
        }
        .ParentDepHeader
        {
            min-width: 141px;
            max-width: 141px;
            background-color:#ecececd6 !important
        }
        .ParentDepStyle
        {
            min-width: 131px;
            max-width: 131px;
        }
        .HeaderStyComComm
        {
            min-width: 65px;
            max-width: 65px;
        }
        .minwidthCommComm
        {
            min-width: 55px;
            max-width: 55px;
        }
        .ComHear
        {
            min-width:54px !important;
            max-width:54px !important;
        }
        .Code_50
        {
            min-width: 44px;
            max-width: 44px;
        }
        .minwidthComm
        {
            min-width: 50px;
            max-width: 50px;
        }
        .HeaderStyCom
        {
            min-width: 60px;
            max-width: 60px;
        }
        
        .HeaderStyComExQty
        {
            min-width: 100px;
            max-width: 100px;
        }
        .minwidthCommExQty
        {
            min-width: 100px;
            max-width: 100px;
        }
        .HeaderStyComSelect
        {
            min-width: 90px;
            max-width: 90px;
        }
        .minwidthCommSelect
        {
            min-width: 70px;
            max-width: 70px;
        }
        
        
        #ctl00_cph_main_content_gvClientCostingDefaults
        {
            border-top: 0px;
        }
        #ctl00_cph_main_content_gvClientCostingDefaults tr:first-child
        {
            position: sticky;
            background-color: white;
            top: -1px;
            z-index:10;
            }
            
      .MinClientStyle,.MinClientHeader
      {
          position:sticky;
          background-color: #FAF8FC!important;
          left:0;
          z-index:1;
          
          }
     .ParentDepStyle,.ParentDepHeader 
     {
          position:sticky;
          background-color: #FAF8FC!important;
          left:100px;
          z-index:1;

           
         }         
        #ctl00_cph_main_content_gvClientCostingDefaults tr:nth-child(2) > td
        {
            border-top: 0px;
        }
        
        #ctl00_cph_main_content_gvClientCostingDefaultsHeaderCopy th .GridCellDiv
        {
            position: relative;
            left: 5%;
        }
        @media screen and (max-width: 1360px)
        {
            .table_width
            {
                width: 1300px;
                max-height: 400px;
                min-height: 150px;
                padding-left: 2px;
            }
            .form_box
            {
                width: 1335px;
            }
        }
        .print-box
        {
            width: 100%;
        }
        @media screen and (max-width: 1280px)
        {
            .table_width
            {
                width: 1200px;
                max-height: 400px;
                min-height: 150px;
                padding-left: 2px;
            }
            .form_box
            {
                width: 1210px;
            }
        }
        .Buyinghousediv
        {
            width: 19px;
            height: 11px;
            background: #d9dbdf;
            position: relative;
            top: 3px;
            display: inline-block;
            border: 1px solid #d9dbdf;
             border-radius: 65px;
        }
        .bipldiv
        {
            width: 19px;
            height: 11px;
            background: #ffeded;
            position: relative;
            top: 3px;
            display: inline-block;
            border: 1px solid #ffeded;
            border-radius: 65px;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsHeaderCopy th:nth-child(1)
        {
            background: #ecececd6 !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsHeaderCopy th:nth-child(2)
        {
            background: #ecececd6 !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsFreeze tr:nth-child(2) > td
        {
            border-top: 0px;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsFreeze
        {
            border-top: 0px;
        }
        .HeaderStyle3 div.GridCellDiv
        {
            font-size: 9px;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsFreeze td
        {
            border-color: #999 !important;
        }
        tr#ctl00_cph_main_content_gvClientCostingDefaultsHeaderCopy th:not(:nth-child(1)).GridCellDiv
        {
            color: Red;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsCopyFreeze
        {
            border-bottom: 0px;
        }
        /*scrollbar css*/
        #ctl00_cph_main_content_gvClientCostingDefaultsHorizontalBar
        {
            height: 6px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsVerticalBar
        {
            width: 6px !important;
        }
        
        /* The Modal (background) */
        .ConfrimModal
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
        
        #confirm
        {
            background-color: #fefefe;
            display: none;
            position: absolute;
            left: 35%;
            padding: 6px 8px 8px;
            box-sizing: border-box;
            text-align: center;
            margin: auto;
            padding: 12px 20px 5px;
            width: 23%;
            border: 5px solid #999;
            border-radius: 5px;
            z-index: 100;
            top: 20%;
            height: 100px;
        }
        .buttonScetion
        {
            text-align: right;
        }
        #confirm .buttonScetion .OkBoutton
        {
            background: #168f4c;
            color: #fff;
            font-size: 12px; /* padding: 3px 5px; */
            border-radius: 2px;
            cursor: pointer;
            width: 45px;
            display: inline-block;
            text-align: center;
            height: 21px;
            line-height: 21px;
        }
        #confirm .buttonScetion .NoBoutton
        {
            background: #bf0d0d;
            color: #fff;
            font-size: 12px; /* padding: 3px 5px; */
            border-radius: 2px;
            cursor: pointer;
            width: 45px;
            display: inline-block;
            text-align: center;
            height: 21px;
            line-height: 21px;
        }
        #confirm .message
        {
            text-align: center;
            margin-bottom: 30px;
            font-size: 13px;
        }
        
.item_list TD input[type=text] {
    width: 92%;
}

      #scrolltop_btn
      {
        width: 40px;
        height: 40px;
        background-color: #3e539cf5;
        z-index: 9999999;
        position: fixed;
        bottom: 70px;
        right: -50px;
        color: white;
        font-size: 30px;
        text-align: center;
        border-radius: 50%;
        transition:.5s ease;
        box-shadow: 1px 1px 3px gray;
        -webkit-animation: uparrow 0.6s infinite alternate ease-in-out;
             }
             
        @-webkit-keyframes uparrow {
          0% { -webkit-transform: translateY(0); }
          100% { -webkit-transform: translateY(-0.4em); }
        }
    </style>
    <!--------------------------------end code---------------------------->
    <div class="print-box">
        <div class="form_box">
            <h2 style="border: 1px solid gray; margin: 0px 0px; text-transform: capitalize;">
                Client costing defaults</h2>
            <table>
                <tr>
                    <td style="width: 140px;">
                        <asp:DropDownList ID="ddlClinetfilter" AppendDataBoundItems="true" runat="server"
                            AutoPostBack="true" Style="text-transform: capitalize;" OnSelectedIndexChanged="ddlClinetfilter_SelectedIndexChanged">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnOhValue" />
                        <asp:HiddenField runat="server" ID="hdnIsOhPercentChecked" />
                    </td>
                    <td style="width: 57px;">
                        <b>Bipl</b> <span class="bipldiv"></span>
                    </td>
                    <td style="text-transform: capitalize;">
                        <b>Buying House</b> <span class="Buyinghousediv"></span>
                    </td>
                </tr>
            </table>
         
            <div id="widthdiv" class="table_width" style="margin-left: 2px;margin-top:0px; overflow:scroll;max-height:83vh;">
                <asp:GridView ID="gvClientCostingDefaults" runat="server" CssClass="item_list"
                    HorizontalAlign="Center" AutoGenerateColumns="false" OnRowDataBound="gvClientCostingDefaults_RowDataBound">
                </asp:GridView>
            </div>
            <%--<asp:Button ID="btnSubmit" Style="display: none" runat="server" CssClass="submit"
            OnClick="btnSubmit_Click" />--%>
        </div>
    </div>
     <div id="scrolltop_btn" onclick="scrollToTop()">&#x2191;</div>
    <!-- code Added by bharat 20-may for Confirm Box modal-->
    <div id="confirm">
        <div class="message">
        </div>
        <div class="buttonScetion">
            <span class="OkBoutton">Yes</span> <span class="NoBoutton">No</span>
        </div>
    </div>
</asp:Content>
