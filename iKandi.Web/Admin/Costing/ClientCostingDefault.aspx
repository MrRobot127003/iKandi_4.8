<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master"
    CodeBehind="ClientCostingDefault.aspx.cs" Inherits="iKandi.Web.ClientCostingDefault" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_main_content">
    <script type="text/javascript" language="javascript">
        //debugger;
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var gvClientCostingDefaultsClientID = '<%=gvClientCostingDefaults.ClientID %>';

        function ApplicableCoffinBox(elem, HeaderNo) {
            var AchiveValue = $(elem).val();
            var Idsn = elem.id.split("_");
            Ids = parseFloat(Idsn[5].substr(3));
            Ids2 = parseFloat(Idsn[5].substr(2));
            Ids4 = parseFloat(Idsn[5].substr(4));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_ctl02" + "_hdnClientId" + "']").val();
            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();
            alert('ggg')
            functionConfirm("Apply for all Department?", function yes() {
                // alert("Yes");
                // debugger;
                proxy.invoke("UpdateClientCostingValues_ByClient_ApplicableCoffinBox", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                            function (result) {
                                //  alert("Update Successfully.");
                                location.href = location.href;
                            });
                return false;
            },
             function no() {
                 proxy.invoke("UpdateClientCostingValues_ByClient_ApplicableCoffinBox", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                                function (result) {
                                    //alert("Update Successfully.");
                                });
                 return false;
             });

        }
        function UpdateAchievement_ByClient(elem, HeaderNo) {
            debugger;
            //  var isYes = confirm("Do you want to change this value for all department of this client");
            var AchiveValue = $(elem).val();
            var Idsn = elem.id.split("_");
            Ids = parseFloat(Idsn[5].substr(3));
            Ids2 = parseFloat(Idsn[5].substr(2));
            Ids4 = parseFloat(Idsn[5].substr(4));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_ctl02" + "_hdnClientId" + "']").val();
            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();

            //this code added by bharat on 21-june for Confrim box popup
            functionConfirm("Apply for all Department?", function yes() {
                // alert("Yes");
                // debugger;
                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                            function (result) {
                                //  alert("Update Successfully.");
                                location.href = location.href;
                            });
                return false;
            },

              function no() {
                  proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                                function (result) {
                                    //alert("Update Successfully.");
                                });
                  return false;
              });
            //end

            ////            if (isYes == true) {
            ////                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                        function (result) {
            ////                            //debugger; 
            ////                            alert(result);
            ////                            location.href = location.href;
            ////                        });
            ////            }
            ////            else {
            ////                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                        function (result) {
            ////                            alert(result);
            ////                        });
            ////            }
        }


        //----------------Add By Prabhaker-06-Dec-17--------------//

        function UpdateAchievement_ByClient_IsChecked(elem, HeaderNo) {
            //  debugger;
            // var isYes = confirm("Do you want to change this value for all department of this client");
            var AchiveValue = $(elem).val();
            var Idsn = elem.id.split("_");
            Ids = parseFloat(Idsn[5].substr(3));
            Ids2 = parseFloat(Idsn[5].substr(2));
            Ids4 = parseFloat(Idsn[5].substr(4));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_ctl02" + "_hdnClientId" + "']").val();
            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();
            var hdnOhValue = $("#ctl00_cph_main_content_hdnIsOhPercentChecked").val();

            //this code added by bharat on 21-june for Confrim box popup
            functionConfirm("Apply for all Department?", function yes() {
                // alert("Yes");
                // debugger;
                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                            function (result) {
                                //  alert("Update Successfully.");
                                location.href = location.href;
                            });
                return false;
            },

              function no() {
                  proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                                function (result) {
                                    //alert("Update Successfully.");
                                });
                  return false;
              });
            //end

            ////            if (isYes == true) {
            ////                //                        if (hdnOhValue == "0") {
            ////                //                            alert("Is OH % must be selected when OH Cost Value is 0"); 
            ////                //                            location.href = location.href;
            ////                //                        }
            ////                //                        else {
            ////                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                            function (result) {
            ////                                //debugger; 
            ////                                alert(result);
            ////                                location.href = location.href;
            ////                            });
            ////                //                        }
            ////            }
            ////            else {
            ////                //                        if (hdnOhValue == "0") {
            ////                //                            alert("Is OH % must be selected when OH Cost Value is 0");
            ////                //                            location.href = location.href;
            ////                //                        }
            ////                //                        else {
            ////                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                            function (result) {
            ////                                //debugger; 
            ////                                alert(result);
            ////                                location.href = location.href;
            ////                            });
            ////                //                        }
            ////            }
        }



        function UpdateClientCostingValues_ByClient_OverHead(elem, HeaderNo, ClientId, DeptId) {
            // var isYes = confirm("Do you want to change this values for all department of this client");
            Values = $(elem).is(':checked') ? 1 : 0;


            // debugger;
            //this code added by bharat on 21-june for Confrim box popup
            functionConfirm("Apply for all Department?", function yes() {
                if (Values == "0") {
                    var hdnOhValue = $("#ctl00_cph_main_content_hdnOhValue").val();
                    if (hdnOhValue == "0") {
                        alert("First Set Non 0 OH Cost Value then Unselect Is OH % Checkbox");
                        location.href = location.href;
                    }
                    else {
                        proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
                 function (result) {
                     // alert(result);
                     location.href = location.href;
                 });
                    }
                }
                else {
                    proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
                 function (result) {
                     //alert(result);
                     location.href = location.href;
                 });
                }
                return false;
            },

         function no() {
             //  debugger;
             if (Values == "1") {
                 proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
                        function (result) {
                            //alert(result);
                            //location.href = location.href;
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
                     //  alert("First Enter OH Value");
                     // location.href = location.href;
                 }
                 else {
                     proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
                        function (result) {
                            //  alert(result);
                            // location.href = location.href;
                        });
                 }

             }
             return false;
         });

            ////            if (isYes == true) {
            ////                if (Values == "0") {
            ////                    var hdnOhValue = $("#ctl00_cph_main_content_hdnOhValue").val();
            ////                    if (hdnOhValue == "0") {
            ////                        alert("First Set Non 0 OH Cost Value then Unselect Is OH % Checkbox");
            ////                        location.href = location.href;
            ////                    }
            ////                    else {
            ////                        proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
            ////                 function (result) {
            ////                     alert(result);
            ////                     location.href = location.href;
            ////                 });
            ////                    }
            ////                }
            ////                else {
            ////                    proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },
            ////                 function (result) {
            ////                     alert(result);
            ////                     location.href = location.href;
            ////                 });
            ////                }
            ////            }

            ////            else {
            ////                if (Values == "1") {
            ////                    proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
            ////                        function (result) {
            ////                            alert(result);
            ////                            location.href = location.href;
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
            ////                        alert("First Enter OH Value");
            ////                        location.href = location.href;
            ////                    }
            ////                    else {
            ////                        proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },
            ////                        function (result) {
            ////                            alert(result);
            ////                            location.href = location.href;
            ////                        });
            ////                    }

            ////                }
            ////            }
        }



        function UpdateClientCostingValues_ByClient(elem, HeaderNo, ClientId, DeptId) {
            // debugger;

            // var isYes = confirm("Do you want to change this values for all department of this client");

            Values = $(elem).is(':checked') ? 1 : 0;
            //this code added by bharat on 21-june for Confrim box popup

            functionConfirm("Apply for all Department?", function yes() {

                proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },

                        function (result) {
                            //alert(result);
                            //alert('This Quantity has been updated successfully!');
                            location.href = location.href;
                        });
                return false;
            },

          function no() {
              proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },

                        function (result) {
                            // alert(result);
                            // alert('This Quantity has been updated successfully!');
                            //location.href = location.href;
                        });
              return false;
          });
            // end

            ////            if (isYes == true) {

            ////                proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: 0, HeaderNo: HeaderNo, Values: Values },

            ////                        function (result) {
            ////                            alert(result);
            ////                            //alert('This Quantity has been updated successfully!');
            ////                            location.href = location.href;
            ////                        });
            ////            }

            ////            else {
            ////                proxy.invoke("UpdateClientCostingValues_ByClient", { ClientId: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, Values: Values },

            ////                        function (result) {
            ////                            alert(result);
            ////                            // alert('This Quantity has been updated successfully!');
            ////                            location.href = location.href;
            ////                        });
            ////            }
        }

        function UpdateSize_ByClient(elem, HeaderNo) {

            //  var isYes = confirm("Do you want to change this value for all department of this client");
            // debugger;
            var AchiveValue = $(elem).val();
            var Ids = elem.id.split("_");
            var Idsn = elem.id.split("_");
            Ids = parseFloat(Ids[5].substr(3));
            Ids = Ids;
            var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + Ids + ")");
            var ClientId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_ctl02" + "_hdnClientId" + "']").val();
            var DeptId = $("#<%= gvClientCostingDefaults.ClientID %> input[id*='_" + Idsn[5].toString() + "_hdnDeptId" + "']").val();

            //this code added by bharat on 21-june for Confrim box popup
            functionConfirm("Apply for all Department?", function yes() {
                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                        function (result) {
                            //  alert('This has been updated successfully!');
                            window.location.reload();
                        });
                return false;
            },
           function no() {
               proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
                        function (result) {
                            //alert('This has been updated successfully!');
                        });
           });

            //end
            ////            if (isYes == true) {
            ////                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: 0, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
            ////                        function (result) {
            ////                            alert('This has been updated successfully!');
            ////                            window.location.reload();
            ////                        });
            ////            }
            ////            else {
            ////                proxy.invoke("UpdateExpectedByClient", { ClientID: ClientId, DeptId: DeptId, HeaderNo: HeaderNo, ExpectedQuantity: AchiveValue },
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

        function gridviewScroll() {
            var gridWidth = $('#widthdiv').width();
            var gridHeight = $('#widthdiv').height() + 10;

            $('.headertopfixed').gridviewScroll({
                width: gridWidth,
                height: gridHeight,
                freezesize: 2
            });
        }


    </script>
    <!------------------------Add-by Prabhaker--------------------------->
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <style type="text/css">
        .print-box
        {
            width: 100%;
        }
        
        
        .item_list th
        {
            padding: 0px;
            text-transform: none !important;
            min-width:70px;
            max-width:70px;
        }
        .item_list td
        {
            padding: 5px 0px !important;
             min-width:70px;
            max-width:70px;
        }
        td.secondcolwidthheader
        {
            min-width:150px;
             max-width:150px;
         }
         th.secondcolwidthheader
        {
            min-width:150px;
             max-width:150px;
         }
          .item_list td input[type="text"]
        {
            width:82% !important;
        }
        
        .form_box
        {
            width: 1420PX;
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
       .table_width
        {
            width: 1400px;
            max-height: 500px;
            min-height: 150px;
        }
    
        
      /*  #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td:first-child
        {
            width: 90px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwidthheader div.GridCellDiv
        {
            width: 176px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwid_53 div.GridCellDiv
        {
            width: 53px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwid_51 div.GridCellDiv
        {
            width: 50px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwid_50 div.GridCellDiv
        {
            width: 50px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwid_85 div.GridCellDiv
        {
            width: 85px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwid_40 div.GridCellDiv
        {
            width: 40px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwid_check div.GridCellDiv
        {
            width: 40px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsPanelItemContent td.secondcolwid_80 div.GridCellDiv
        {
            width: 80px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsFreeze td:first-child
        {
            width: 90px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsFreeze td:first-child div.GridCellDiv
        {
            width: 90px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsFreeze td + td
        {
            width: 190px !important;
        }
        #ctl00_cph_main_content_gvClientCostingDefaultsFreeze td + td div.GridCellDiv
        {
            width: 190px !important;
        }*/
    @media screen and (max-width: 1360px)
        {
            .table_width
            {
                width: 1300px;
                max-height: 400px;
                min-height: 150px;
            }
            .form_box {
                width: 1300px;
            }
        }
  @media screen and (max-width: 1280px)
        {
            .table_width
            {
                width: 1200px;
                max-height: 400px;
                min-height: 150px;
            }
            .form_box {
                width: 1200px;
            }
        }
        
        /* The Modal (background) */
        .ConfrimModal
        {
             display:none;/* Hidden by default */
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
                display:none;
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
            font-size: 12px;
            /* padding: 3px 5px; */
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
            font-size: 12px;
            /* padding: 3px 5px; */
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
             font-size:13px;
        }
        
    </style>
    <!--------------------------------end code---------------------------->
    <div class="print-box">
        <div class="form_box">
            <div style="color: #f8f8f8; text-align: center; font-weight: bold; font-size: 20px;
                text-transform: capitalize; background: #39589c; height: 28px; margin-bottom: 21px;">
                Client costing defaults
                <div style="color: #39589c; text-align: left; font-weight: bold; font-size: 20px;">
                    <asp:DropDownList ID="ddlClinetfilter" AppendDataBoundItems="true" runat="server"
                        AutoPostBack="true" Style="text-transform: capitalize;" OnSelectedIndexChanged="ddlClinetfilter_SelectedIndexChanged">
                        <asp:ListItem Text="Select" Value="-1" />
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="hdnOhValue" />
                    <asp:HiddenField runat="server" ID="hdnIsOhPercentChecked" />
                </div>
            </div>
            <div id="widthdiv" class="table_width">
                <asp:GridView runat="server" PageSize="50" HeaderStyle-CssClass="column_color text_align_left font_color_blue "
                    RowStyle-CssClass="column_color text_align_left font_color_blue" ID="gvClientCostingDefaults"
                    CssClass="item_list headertopfixed" AutoGenerateColumns="false" OnRowDataBound="gvClientCostingDefaults_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                Client
                            </HeaderTemplate>
                         
                            <ItemTemplate>
                                <asp:Label ID="lblClientName" Style="text-transform: capitalize;" Font-Size="11px"
                                    runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnClientId" Value='<%#Eval("ClientID") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle  CssClass="firstcolwidth" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                Parent (Department)
                            </HeaderTemplate>
                            <HeaderStyle  CssClass="secondcolwidthheader" />
                            <ItemTemplate>
                                <asp:Label ID="lblDeptName" Style="text-transform: capitalize;" Font-Size="11px"
                                    runat="server" Text='<%#Eval("DepartmentName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnDeptId" Value='<%#Eval("DeptId") %>' runat="server" />
                                <asp:HiddenField ID="hdnParentDeptId" Value='<%#Eval("ParentID") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle  CssClass="secondcolwidthheader" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Commision %
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtCommission" MaxLength="6" CssClass="numeric-field-with-decimal-places"
                                    onchange="javascript:return UpdateAchievement_ByClient(this,1)" Text='<%#Eval("COMMISION") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_53" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Conv to
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlConvertTo" Style="text-transform: capitalize;" onchange="javascript:return UpdateAchievement_ByClient(this,2)"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnConvertTo" Value='<%#Eval("CONVERSIONTO") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                Coffin box
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:TextBox ID="txtCOFFINBOX" MaxLength="6" CssClass="numeric-field-with-decimal-places"
                                    onchange="javascript:return UpdateAchievement_ByClient(this,3)" Text='<%#Eval("COFFIN_BOX") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_51" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Hanger loops
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtHANGERLOOPS" onchange="javascript:return UpdateAchievement_ByClient(this,4)"
                                    MaxLength="6" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("HANGERLOOPS") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Lbl / tags
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtLbltags" onchange="javascript:return UpdateAchievement_ByClient(this,5)"
                                    MaxLength="6" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("[LBL/TAGS]") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Is OH %
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <input type="checkbox" runat="server" id="chkIsOverheadChecked" checked='<%#Eval("IsOHPercent") %>' />
                            </ItemTemplate>
                            <ItemStyle  CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                OH Cost Value
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtOverHeadValue" MaxLength="6" CssClass="numeric-field-with-decimal-places"
                                    runat="server" Text='<%#Eval("OHValue") %>' onchange="javascript:return UpdateAchievement_ByClient_IsChecked(this,32)"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                OH Cost %
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <asp:TextBox ID="txtOverHeadCost" onchange="javascript:return UpdateAchievement_ByClient(this,6)"
                                    MaxLength="6" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("OVERHEADCOST") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Profit margin %
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtPROFITMARGIN" onchange="javascript:return UpdateAchievement_ByClient(this,7)"
                                    MaxLength="6" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("PROFITMARGIN") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Test
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtTEST" MaxLength="6" onchange="javascript:return UpdateAchievement_ByClient(this,8)"
                                    CssClass="numeric-field-with-decimal-places" Text='<%#Eval("TEST") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Hangers
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <asp:TextBox ID="txtHANGERS" onchange="javascript:return UpdateAchievement_ByClient(this,9)"
                                    MaxLength="6" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("HANGERS") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%--Design comm %.--%>
                                DBK Counter %
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtDESIGNCOMM" CssClass="numeric-field-with-decimal-places" onchange="javascript:return UpdateAchievement_ByClient(this,10)"
                                    MaxLength="6" Text='<%#Eval("DESIGNCOMM") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <%--added by abhishek 26/10/2015--%>
                        <asp:TemplateField Visible="false">
                            <%--end by abhishek 26/10/2015--%>
                            <HeaderTemplate>
                                Achie vement
                            </HeaderTemplate>
                            <HeaderStyle />
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlACHIEVEMENT" onchange="javascript:return UpdateAchievement_ByClient(this,11)"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnACHIEVEMENT" Value='<%#Eval("ACHIEVEMENT") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_50" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Expected<br /> qty.
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <%--  <asp:TextBox ID="txtEXPECTEDQTY" onchange="javascript:return UpdateAchievement_ByClient(this,12)"
                                    CssClass="numeric-field-without-decimal-places" MaxLength="6" Text='<%#Eval("EXPECTEDQTY") %>'
                                    runat="server" Visible="false"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlWastageRange" AppendDataBoundItems="true" runat="server"
                                    onchange="javascript:return UpdateAchievement_ByClient(this,12)">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnWastageRange" Value='<%#Eval("ExpectedID") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle  CssClass="secondcolwid_85" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%--Frt up to port.
                                Freight & Platform --%>
                                Customs, Doc & Platform
                            </HeaderTemplate>
                            <HeaderStyle />
                            <ItemTemplate>
                                <asp:TextBox ID="txtFRTUptoport" onchange="javascript:return UpdateAchievement_ByClient(this,13)"
                                    CssClass="numeric-field-without-decimal-places" MaxLength="6" Text='<%#Eval("FrightUptoPort") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle  CssClass="secondcolwid_40" />
                        </asp:TemplateField>
                        <%--added by abhishek on 25/2/2016--%>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                Costing waste.%
                            </HeaderTemplate>
                            <HeaderStyle  />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCostingWaste" onchange="javascript:return UpdateAchievement_ByClient(this,18)"
                                    CssClass="numeric-field-without-decimal-places" MaxLength="6" Text='<%#Eval("COSTINGWASTE") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_40" />
                        </asp:TemplateField>
                        <%--end--%>
                        <%--new code 06 feb 2020 start--%>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Is CMT Open
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <%-- <asp:CheckBox ID="chkLAFFOBMode" runat="server" Checked='<%#Eval("IkandiLAFFOBMode") %>' />--%>
                                <input id="chkMinCMTMode" runat="server" checked='<%#Eval("IsCMTOpen") %>'
                                    type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_check" />
                        </asp:TemplateField>

                          <asp:TemplateField>
                            <HeaderTemplate>
                                Min CMT
                            </HeaderTemplate>
                            <HeaderStyle />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCMT" onchange="javascript:return UpdateAchievement_ByClient(this,28)"
                                    MaxLength="3" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("MinCMT") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        
                        <%--new code 06 feb 2020 end--%>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Size Set 1
                            </HeaderTemplate>
                            <HeaderStyle />
                            <ItemTemplate>
                                <asp:DropDownList Width="70" Style="text-transform: capitalize;" ID="ddlSizeSet1"
                                    runat="server" RepeatDirection="Horizontal" onchange="javascript:return UpdateSize_ByClient(this,14)">
                                    <asp:ListItem Value="1">Option1</asp:ListItem>
                                    <asp:ListItem Value="2">Option2</asp:ListItem>
                                    <asp:ListItem Value="3">Option3</asp:ListItem>
                                    <asp:ListItem Value="4">Option4</asp:ListItem>
                                    <asp:ListItem Value="5">Option5</asp:ListItem>
                                    <asp:ListItem Value="6">Option6</asp:ListItem>
                                    <asp:ListItem Value="7">Option7</asp:ListItem>
                                    <asp:ListItem Value="8">Option8</asp:ListItem>
                                    <asp:ListItem Value="9">Option9</asp:ListItem>
                                    <asp:ListItem Value="10">Option10</asp:ListItem>
                                    <asp:ListItem Value="11">Option11</asp:ListItem>
                                    <asp:ListItem Value="12">Option12</asp:ListItem>
                                    <asp:ListItem Value="13">Option13</asp:ListItem>
                                    <asp:ListItem Value="14">Option14</asp:ListItem>
                                    <asp:ListItem Value="15">Option15</asp:ListItem>
                                    <asp:ListItem Value="16">Option16</asp:ListItem>
                                    <asp:ListItem Value="17">Option17</asp:ListItem>
                                    <asp:ListItem Value="18">Option18</asp:ListItem>
 				                    <asp:ListItem Value="19">Option19</asp:ListItem>
                                    <%--<asp:ListItem Value="18">Option18</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnSizeSet1" runat="server" Value='<%#Eval("SizeSet1") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Size Set 2
                            </HeaderTemplate>
                            <HeaderStyle />
                            <ItemTemplate>
                                <asp:DropDownList Width="70" Style="text-transform: capitalize;" ID="ddlSizeSet2"
                                    runat="server" RepeatDirection="Horizontal" onchange="javascript:return UpdateSize_ByClient(this,15)">
                                    <asp:ListItem Value="1">Option1</asp:ListItem>                                    
                                    <asp:ListItem Value="2">Option2</asp:ListItem>
                                    <asp:ListItem Value="3">Option3</asp:ListItem>
                                    <asp:ListItem Value="4">Option4</asp:ListItem>
                                    <asp:ListItem Value="5">Option5</asp:ListItem>
                                    <asp:ListItem Value="6">Option6</asp:ListItem>
                                    <asp:ListItem Value="7">Option7</asp:ListItem>
                                    <asp:ListItem Value="8">Option8</asp:ListItem>
                                    <asp:ListItem Value="9">Option9</asp:ListItem>
                                    <asp:ListItem Value="10">Option10</asp:ListItem>
                                    <asp:ListItem Value="11">Option11</asp:ListItem>
                                    <asp:ListItem Value="12">Option12</asp:ListItem>
                                    <asp:ListItem Value="13">Option13</asp:ListItem>
                                    <asp:ListItem Value="14">Option14</asp:ListItem>
                                    <asp:ListItem Value="15">Option15</asp:ListItem>
                                    <asp:ListItem Value="16">Option16</asp:ListItem>
                                    <asp:ListItem Value="17">Option17</asp:ListItem>
                                    <asp:ListItem Value="18">Option18</asp:ListItem>
 				                    <asp:ListItem Value="19">Option19</asp:ListItem>
                                    <%--<asp:ListItem Value="18">Option18</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnSizeSet2" runat="server" Value='<%#Eval("SizeSet2") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Size Set 3
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:DropDownList Width="70" Style="text-transform: capitalize;" ID="ddlSizeSet3"
                                    runat="server" RepeatDirection="Horizontal" onchange="javascript:return UpdateSize_ByClient(this,16)">
                                    <asp:ListItem Value="1">Option1</asp:ListItem>
                                    <asp:ListItem Value="2">Option2</asp:ListItem>
                                    <asp:ListItem Value="3">Option3</asp:ListItem>
                                    <asp:ListItem Value="4">Option4</asp:ListItem>
                                    <asp:ListItem Value="5">Option5</asp:ListItem>
                                    <asp:ListItem Value="6">Option6</asp:ListItem>
                                    <asp:ListItem Value="7">Option7</asp:ListItem>
                                    <asp:ListItem Value="8">Option8</asp:ListItem>
                                    <asp:ListItem Value="9">Option9</asp:ListItem>
                                    <asp:ListItem Value="10">Option10</asp:ListItem>
                                    <asp:ListItem Value="11">Option11</asp:ListItem>
                                    <asp:ListItem Value="12">Option12</asp:ListItem>
                                    <asp:ListItem Value="13">Option13</asp:ListItem>
                                    <asp:ListItem Value="14">Option14</asp:ListItem>
                                    <asp:ListItem Value="15">Option15</asp:ListItem>
                                    <asp:ListItem Value="16">Option16</asp:ListItem>
                                    <asp:ListItem Value="17">Option17</asp:ListItem>
                                    <asp:ListItem Value="18">Option18</asp:ListItem>
 				                    <asp:ListItem Value="19">Option19</asp:ListItem>
                                    <%-- <asp:ListItem Value="18">Option18</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnSizeSet3" runat="server" Value='<%#Eval("SizeSet3") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Size Set 4
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:DropDownList Width="70" Style="text-transform: capitalize;" ID="ddlSizeSet4"
                                    runat="server" RepeatDirection="Horizontal" onchange="javascript:return UpdateSize_ByClient(this,17)">
                                    <asp:ListItem Value="1">Option1</asp:ListItem>
                                    <asp:ListItem Value="2">Option2</asp:ListItem>
                                    <asp:ListItem Value="3">Option3</asp:ListItem>
                                    <asp:ListItem Value="4">Option4</asp:ListItem>
                                    <asp:ListItem Value="5">Option5</asp:ListItem>
                                    <asp:ListItem Value="6">Option6</asp:ListItem>
                                    <asp:ListItem Value="7">Option7</asp:ListItem>
                                    <asp:ListItem Value="8">Option8</asp:ListItem>
                                    <asp:ListItem Value="9">Option9</asp:ListItem>
                                    <asp:ListItem Value="10">Option10</asp:ListItem>
                                    <asp:ListItem Value="11">Option11</asp:ListItem>
                                    <asp:ListItem Value="12">Option12</asp:ListItem>
                                    <asp:ListItem Value="13">Option13</asp:ListItem>
                                    <asp:ListItem Value="14">Option14</asp:ListItem>
                                    <asp:ListItem Value="15">Option15</asp:ListItem>
                                    <asp:ListItem Value="16">Option16</asp:ListItem>
                                    <asp:ListItem Value="17">Option17</asp:ListItem>
                                    <asp:ListItem Value="18">Option18</asp:ListItem>
 				                    <asp:ListItem Value="19">Option19</asp:ListItem>
                                    <%--<asp:ListItem Value="18">Option18</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnSizeSet4" runat="server" Value='<%#Eval("SizeSet4") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Grading<br /> extra %
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrading" onchange="javascript:return UpdateAchievement_ByClient(this,26)"
                                    MaxLength="3" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("Gradingextra") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                Min OverHead
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:TextBox ID="txtMinOverHead" onchange="javascript:return UpdateAchievement_ByClient(this,27)"
                                    MaxLength="3" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("MinOverHead") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                Max OverHead
                            </HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:TextBox ID="txtMaxOverHead" onchange="javascript:return UpdateAchievement_ByClient(this,29)"
                                    MaxLength="3" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("MaxOverHead") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_80" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Min Profit %
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:TextBox ID="txtProfit" onchange="javascript:return UpdateAchievement_ByClient(this,30)"
                                    MaxLength="3" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("MinProfit") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_40" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                L-A/F (FOB)
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <%-- <asp:CheckBox ID="chkLAFFOBMode" runat="server" Checked='<%#Eval("IkandiLAFFOBMode") %>' />--%>
                                <input id="chkLAFFOBMode" runat="server" checked='<%#Eval("IkandiLAFFOBMode") %>'
                                    type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_check" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                L-A/H (FOB)
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <%--<asp:CheckBox ID="chkLAHFOBMode" runat="server" Checked='<%#Eval("IkandiLAHFOBMode") %>' />--%>
                                <input id="chkLAHFOBMode" runat="server" checked='<%#Eval("IkandiLAHFOBMode") %>'
                                    type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_check" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                L-S/F (FOB)
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <%-- <asp:CheckBox ID="chkLSFFOBMode" runat="server" Checked='<%#Eval("IkandiLSFFOBMode") %>' />--%>
                                <input id="chkLSFFOBMode" runat="server" checked='<%#Eval("IkandiLSFFOBMode") %>'
                                    type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_check" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                L-S/H (FOB)
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <%--<asp:CheckBox ID="chkLSHFOBMode" runat="server" Checked='<%#Eval("IkandiLSHFOBMode") %>' />--%>
                                <input id="chkLSHFOBMode" runat="server" checked='<%#Eval("IkandiLSHFOBMode") %>'
                                    type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_check" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Direct Mode
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <%-- <asp:CheckBox ID="chkdDirectMode" runat="server" Checked='<%#Eval("IkandidDirectMode") %>' />--%>
                                <input id="chkdDirectMode" runat="server" checked='<%#Eval("IkandidDirectMode") %>'
                                    type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_check" />
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <HeaderTemplate>
                                Applicable CoffinBox
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <asp:TextBox ID="txtApplicableCoffinBox" onchange="javascript:return ApplicableCoffinBox(this,34)"
                                    MaxLength="100"  Text='<%#Eval("ApplicableCoffinBox") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_40" />
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <HeaderTemplate>
                                Applicable CoffinBox Value
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:TextBox ID="txtApplicableCoffinBoxValue" onchange="javascript:return UpdateAchievement_ByClient(this,35)"
                                    MaxLength="3" CssClass="numeric-field-with-decimal-places" Text='<%#Eval("ApplicableCoffinBoxValue") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="secondcolwid_40" />
                        </asp:TemplateField>
                        <%-- <asp:TemplateField>
                            <HeaderTemplate>
                                Fab. price Adj.
                            </HeaderTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtFabAdjPrice" MaxLength="6" CssClass="numeric-field-with-decimal-places"
                                    onchange="javascript:return UpdateAchievement_ByClient(this,30)" Text='<%#Eval("Fabric_Adj_Price") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Acc. price Adj.
                            </HeaderTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtAccAdjPrice" MaxLength="6" CssClass="numeric-field-with-decimal-places"
                                    onchange="javascript:return UpdateAchievement_ByClient(this,31)" Text='<%#Eval("Acc_Adj_Price") %>'
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="clear: both;">
            </div>
            <br />
        </div>
        <div style="clear: both;">
        </div>
        <br />
        <asp:Button ID="btnSubmit" Style="display: none" runat="server" CssClass="submit"
            OnClick="btnSubmit_Click" />
    </div>
    <div style="clear: both;">
    </div>
     <!-- code Added by bharat 20-may for Confirm Box modal-->

   <div id="confirm">
        <div class="message">
        </div>
        
        <div class="buttonScetion">
           <span class="OkBoutton">Yes</span>
           <span class="NoBoutton">No</span>
      </div>
    </div>

    <script>
        //code added by bharat on 30-may for confrim box

        function functionConfirm(msg, myYes, myNo) {
            // alert();
            // debugger;
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
</asp:Content>
