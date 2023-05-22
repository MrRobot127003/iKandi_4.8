<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryOrdersSummaryOld.aspx.cs"
    Inherits="iKandi.Web.Internal.Sales.AccessoryOrdersSummaryOld" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .hiddenfield
        {
            display: none;
        }
        #grdattendence th
        {
            color: Gray;
            padding: 2px 2px;
            font-weight: 500;
            font-size: 11px;
        }
        #grdattendence td
        {
            color: #000 !important;
            padding: 2px 2px;
            font-size: 11px;
            min-width:50px;
            max-width:50px;
            border: 1px solid #dbd8d;
        }
        #grdattendence td:first-child
        {
            font-weight: 600;
            min-width:150px;
            max-width:150px;
            border-left-color:#999 !important;
        }
        #grdattendence td:last-child
        {
            min-width:70px;
            max-width:70px;
            border-right-color:#999 !important;
        }
        #grdattendence tr:nth-last-child(1)>td
        {
             border-bottom-color:#999 !important;
         }
        #grdoption2 
        {
             margin-top: 5px;;
        }
        
        #grdoption2 th
        {
            color: Gray;
            padding: 2px 2px;
            font-weight: 500;
            font-size: 11px;
            border:1px solid #999;
        }
        
        #grdoption2 td
        {
            color: #000 !important;
            padding: 2px 2px;
            font-size: 11px;
            border:1px solid #dbd8d;
            min-width:50px;
            max-width:50px;
        }
        #grdoption2 td:first-child
        {
            font-weight: 600;
            min-width:150px;
            max-width:150px;
            border-left-color:#999 !important;
        }
        #grdoption2 td:last-child
        {
            min-width:70px;
            max-width:70px;
            border-right-color:#999 !important;
        }
        #grdoption2 tr:nth-last-child(1)
        {
             border-bottom-color:#999 !important;
         }
         #grdoption3 
        {
             margin-top: 5px;;
        }
        
        #grdoption3 th
        {
            color: Gray;
            padding: 2px 2px;
            font-weight: 500;
            font-size: 11px;
             border:1px solid #999;
        }
        #grdoption3 td
        {
            color: #000 !important;
            padding: 2px 2px;
            font-size: 11px;
             border:1px solid #dbd8d;
             min-width:50px;
            max-width:50px;
        }
        #grdoption3 td:first-child
        {
            font-weight: 600;
            min-width:150px;
            max-width:150px;
            border-left-color:#999 !important;
        }
        #grdoption3 td:last-child
        {
            min-width:70px;
            max-width:70px;
            border-right-color:#999 !important;
        }
        #grdoption3 tr:nth-last-child(1)
        {
             border-bottom-color:#999 !important;
         }
         #grdoption4 
        {
             margin-top: 5px;
        }
        
        #grdoption4 th
        {
            color: Gray;
            padding: 2px 2px;
            font-weight: 500;
            font-size: 11px;
             border:1px solid #999;
        }
        #grdoption4 td
        {
            color: #000 !important;
            padding: 2px 2px;
            font-size: 11px;
             border:1px solid #dbd8d;
             min-width:50px;
            max-width:50px;
        }
        #grdoption4 td:first-child
        {
            font-weight: 600;
             min-width:150px;
            max-width:150px;
            border-left-color:#999 !important;
        }
         #grdoption4 td:last-child
        {
            min-width:70px;
            max-width:70px;
            border-right-color:#999 !important;
        }
        #grdoption4 tr:nth-last-child(1)
        {
             border-bottom-color:#999 !important;
         }
        .toptable td
        {
            background: #DDDFE4;
            font-size: 11px;
            padding: 2px 4px;
            border: 1px solid #dbd8d;
           border-bottom:0px;
        }
          .toptable
          {
              margin-left:5px;
              border:0px;
              margin-top:3px;
          }
          .tableWith
          {
               width:1110px !important;
           }
           .tableWithTask
          {
               width:1265px !important;
           }
        .headercolor
        {
            font-size: 11px;
            color: #716c6c;
            font-weight: 500;
            width: 150px;
        }
        .headerCont
        {
             width:160px !important;
             font-weight: 500;
             color: #716c6c;
         }
          .headerQty
        {
            width:100px !important;
             font-weight: 500;
             color: #716c6c;
         }
        .textbreak
        {
            display: block;
        }
        
        #grdaccsize th input
        {
            width: 95%;
            margin: 2px 0px;
            border: 0px solid #5e5867;
            background: #dddfe4;
        }
        .headersecol
        {
            font-size: 11px;
            color: #716c6c;
           width: 150px;
        }
        .fontweightbold
        {
            font-weight: 600;
        }
        .floatleft
        {
            float: left;
        }
        #grdaccsize td
        {
            font-size: 11px;
            padding: 0px 0px;
        }
        #grdaccsize td:first-child
        {
            height: 18px;
            padding: 0px 4px;
        }
       
        .colorblack
        {
            color: #000;
            font-weight: 500;
        }
        #grdaccsize th span
        {
                position: absolute;
                top: 0px;
                left: 50%;
                transform: translate(-50%);
                width: 99%;
        }
        #grdaccsize th input[type="text"]
        {
            position: absolute;
            bottom: 2px;
            left: 8%;
            transform: translate(-14%);
            width: 27%;
        }
        .topalingcen
        {
            position: relative;
            top: -3px;
        }
       /* .topalingshrin
        {
            position: relative;
            top: 3px;
        }*/
        .headerAccessories
        {
            background: #39589c !important;
            text-align: center;
            color: White;
        }
         #grdattendence 
        {
            border:1px solid #999;
            border-top: 0px;

         }
        #grdattendence th
        {
            border-top: 0px;

         }
          #grdattendence td
        {
            border:1px solid #cac9c999;
         }
         
          #grdaccsize 
        {
            border:1px solid #999;
            margin-top:5px;
           
         }
         #grdaccsize th
        {          
            position: relative;
            height: 46px;
          
         }
      hr
      {
          border: 1px solid #ebe2e299;
       }
          #grdaccsize td
        {
            border:1px solid #cac9c999;
            min-width:85px;
            padding: 2px 0px;
          }
         #grdaccsize td:first-child
        {
           border-left-color:#999 !important;
          }
           #grdaccsize td:last-child
        {
           border-right-color:#999 !important;
          }
         #grdaccsize tr:nth-last-child(1)>td
        {
           border-bottom-color:#999 !important;
          }
          .viewporthome .headerAccessories
          {
              position:fixed;
              
           }
            ::-webkit-scrollbar {
          width: 8px;
          height: 8px;
        }
        ::-webkit-scrollbar-track {
          box-shadow: inset 0 0 5px grey; 
          border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb {
          background: #bdbbbb; 
          border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb:hover {
          background: #969191; 
        }
        @media print {
      .printButtonHide {
        display: none;
      }
    }
    #grdaccsize th select{
        position: absolute;
        bottom: 3px;
        right: -15%;
        transform: translate(-40%);
        width: 43%;
    }
     #spinnL
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        .btnSubmit
        {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
        }
        .da_submit_button {
            height: 24px;
            line-height: 16px;
            margin-left:3px;
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
        }
      .ModelPo2
       {
            background: #f0f0f0;
            width: 650px;
            position: absolute;
            z-index: 100000;
            min-height: 200px;
            line-height: 21px;
            text-align: left;
            top: 28%;
            left: 25%;
        }
         .maxWidthHist
        {
            max-height: 300px;
            overflow-y: auto;
        }
       #Pohistory
    {
       line-height:20px;
       padding-top: 6px;
     }
    #divhistory h2
    {
        margin-left: 0px !important;
    }
  #widthdiv
   {
        width:1115px;
       
       margin-left:5px;
       float: left;
    }
   #grdaccsizeCopy .headercolor
    {
        position:relative;
        height:62px;
        border:1px solid #999;
     }
    #grdaccsizeCopy th input[type="text"]
    {
        position:absolute;
        left:24px;
        width:25px;
        bottom:0px;
     }
    span.LineBreak::before
    {
       content: "";
     }
    #grdaccsizeCopy th select
    {
        position:absolute;
        bottom:0px;
        right:2px;
     }
    #grdaccsizeCopy th select::before
    {
        content: "Read";
     }
     .ContentWidth
     {
         width:152px !important;
      }
    #grdaccsizeHeaderCopy .headerCont
     {
         width:126px !important;
         border:1px solid #999;
     } 
      #grdaccsizeHeaderCopy .headerQty
     {
         border:1px solid #999;
         width: 102px !important;
     } 
    .headercolor .GridCellDiv
    {
        width:147px !important;
     }
     .ContentWidth .GridCellDiv
     {
         width:150px !important;
      }
      .QtyWidth
      {
          width:101px !important;
       }
      .QtyWidth .GridCellDiv
      {
          width:92px !important;
       }
        .ContWidth 
       {
              width:128px !important;
              border-left-color: #999;
              height:24px !important;
        }
        #grdaccsizeFreeze tr:last-child >td.ContWidth 
        {
             height:20px !important;
         }
         #grdaccsize tr:last-child >td.ContWidth 
        {
             height:22px !important;
         }
        .ContWidth .GridCellDiv
       {
              width:127px !important;
        }
      /*#grdaccsizeCopy
      {
          margin-bottom:0px !important;
       }
       #grdaccsizeFreeze
       {
           width:100% !important;
       }*/
       #grdaccsizeHorizontalBar
       {   
        height: 6px !important;
       }
       #grdaccsizeHeaderCopy .headercolor span
       {
         position: relative;
         top: -4px  
        }
         #grdaccsizeHeaderCopy .headercolor span.UnitSpan
       {
         position: relative;
         top: 14px  
        }
       #grdaccsizeHeaderCopy .headercolor span.AvgSpan
       {
         position: relative;
         top: 14px;
         left:-51px;
        }
       
         #grdaccsizeHeaderCopy .headercolor span.ShrnkSpan
       {
         position: relative;
         top: 7px;
         left:-19px;
        }
         #grdaccsizeHeaderCopy .headercolor span.WastSpan
       {
         position: relative;
         top: 7px;
         left:13px;
        }
       .gridleft
       {
           float:left;
        }
        #grdaccsizeHorizontalRail {
            height: 6px !important;
        }
        #grdaccsizePanelItem
        {
            background: #fff !important; 
         }
         #grdaccsizeVerticalBar {   
          width: 6px !important;
       }
       #grdaccsizeVerticalRail{   
          width: 6px !important;
       }
       .topalingshrin
       {
           dispaly:none;
        }
        .topalingshrin
        {
            display:none;
         }
    </style>
    <script type="text/javascript">

        var serviceUrl = "../../Webservices/iKandiService.asmx";
        var proxy = new ServiceProxy(serviceUrl);

        function calculateAvgUnit(elem) {
            //debugger;            
            var ControlValue = elem.value;
            var OrderID = document.getElementById("hdnOrderID").value;
            var CreatedBy = parseInt(document.getElementById("hdnUserId").value);
            var RowID = elem.id.split("_")[4];
            var AccWorkingDetailId = elem.id.split("_")[5];

            if ((ControlValue == "") || (ControlValue == "0")) {
                alert("Average can not be blank or zero!");
                elem.value = elem.defaultValue;
                return false;
            }
            else {
                if (RowID == 'TextBox') {
                    var Avg = parseFloat(ControlValue);
                    proxy.invoke("Save_Accessory_Average", { Type: 'AVG', Avg: Avg, Unit: 0, OrderID: OrderID, AccWorkingDetailId: AccWorkingDetailId, CheckValue: false, CreatedBy: CreatedBy }, function (result) {
                        if (result > 1 || result > -1) {
                            //location.reload();
                        }
                    }, onPageError, false, false);
                }

                if (RowID == 'DropDown') {
                    var Unit = parseInt(ControlValue);
                    proxy.invoke("Save_Accessory_Average", { Type: 'UNIT', Avg: 0, Unit: Unit, OrderID: OrderID, AccWorkingDetailId: AccWorkingDetailId, CheckValue: false, CreatedBy: CreatedBy }, function (result) {
                        if (result > 1 || result > -1) {
                            //location.reload();
                        }
                    }, onPageError, false, false);
                }
            }
        }
        //added by raghvinder on 23-10-2020 end

        function aa() {


            var css = '@page { size: landscape; }',
    head = document.head || document.getElementsByTagName('head')[0],
    style = document.createElement('style');

            style.type = 'text/css';
            style.media = 'print';

            if (style.styleSheet) {
                style.styleSheet.cssText = css;
            } else {
                style.appendChild(document.createTextNode(css));
            }

            head.appendChild(style);

            window.print();
        }

        function isNumberKey(evt, obj) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function pageLoad() {
            $('.FloatValue').keypress(function (event) {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
                    ((event.which < 48 || event.which > 57) &&
                      (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 2) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });
        }

        function closeAccesButtion() {
            // this code added by bharat on 26-june-2019
            var tabVal = document.getElementById('hdnorderTabClose').value;
            if (tabVal == 3) {
                var win = window.open("", "_self");
                win.close();
            }
            else {
                self.parent.Shadowbox.close();
            }
            // end
        }

        function ShowHistory() {
            //debugger;

            var OrderID = $("#hdnOrderID").val();
            var hist = "";
            proxy.invoke("GetOrderAccesoryHistory", { OrderId: OrderID },
                    function (response) {
                        //debugger;
                        if (response.length > 0) {
                            $("#divhistory").show();
                            for (var i = 0; i < response.length; i++) {
                                hist += '<li>' + response[i].DetailDescription + '</li><br>';
                            }
                            $("#Pohistory").html(hist);
                        }


                    });
        }
        function showhistoryhide() {
            $("#divhistory").hide();
        }
     
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>--%>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <%-- <script src="http://code.jquery.com/jquery-1.9.1.js"></script>--%>
    <%--<script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>--%>
    <script type="text/javascript" src="../../js/form.js"></script>
    <div id="spinnL">
    </div>
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading128.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>    
                        <asp:HiddenField ID="hdnorderTabClose" runat="server" />
                        <asp:HiddenField ID="hdnOrderID" runat="server" />
                        <asp:HiddenField ID="hdnUserId" runat="server" />                     
                 
                <table id="tblHeader" runat="server" class="toptable tableWith" cellpadding="0" cellspacing="0" border="0" style="width:1115px !important;">
                    <tr>
                      <td class="headerAccessories">    
                         <span style="position: relative; top: 3px;">Accessories Details</span>
                         <div style="width:50px;float:right;">
                           <a onclick="ShowHistory()"
                                        id="ShowImgHis" runat="server" visible="false" style="color: White; float: left;
                                        margin-right: 5px; cursor: pointer;" target="_blank">
                                        <img src="../../images/history.png" /></a>
                              <span style="float: right;padding: 1px 6px 1px 5px; position: relative; top: 0px;font-size:15px; cursor: pointer;" onclick="closeAccesButtion()"> X</span>
                         </div>
                      </td>
                    </tr>
                    <tr>
                     <td style="text-align: left; color: gray; border-left: 1px solid #999999; border-top: 1px solid #999;
                            border-bottom: 0px">
                             <span style="color: gray">Serial Number: </span>
                            <asp:Label ID="lblserialno" Style="padding-right: 24px; color: #000; font-weight: 600"
                                runat="server"></asp:Label>
                            <span style="color: gray">Style Number:
                                <asp:Label ID="lblstylenumber" Style="color: #000; font-weight: 600" runat="server"></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;
                            Account Manager:
                            <asp:Label ID="lblacname" Style="color: #000; font-weight: 600" runat="server"></asp:Label>
                        </td>
                      
                       
                    </tr>
                </table>
            </div>
            <div id="widthdiv" runat="server">    
                <asp:GridView ID="grdaccsize" runat="server" Style=" margin-bottom: 0px;margin-top:0px;" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
                    OnRowDataBound="grdaccsize_RowDataBound" CssClass="headertopfixed" RowStyle-ForeColor="#7E7E7E" HorizontalAlign="Center">
                    <RowStyle CssClass="grdAccRow" />
                </asp:GridView>

                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="margin-left:4px;clear:both">
        AVG Checked and Smart Marker Uploaded by Account Manager
        <asp:CheckBox ID="chkboxAccountMgr" runat="server" Enabled="true" 
            Style="position: relative; cursor: poniter; top: 3px;" /><span style="color: red;
                font-size: 11px; margin-left: 5px; display: none" id="messageHide" runat="server">All
                avg. are not filled!</span>
    </div>
   
     <div class="ModelPo2" id="divhistory" runat="server" style="display: none">
        <h2 style='background: #39589c !important; width: 100% !important; font-size: 15px;
            margin: 0px 0px; color: #fff !important; margin-left: 3px; font-weight: 500;
            text-align: center'>
            History<span style='float: right; margin-right: 8px; cursor: pointer; color: #fff'
                titel='Close' onclick="showhistoryhide();">X</span>
        </h2>
        <div class="maxWidthHist">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="width: 50%; text-align: left; padding: 0px 10px 22px; line-height: 21px;
                        font-size: 10px">
                         <div id="Pohistory"></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
   
    <div style="min-width: 1100px; max-width: 1100px; margin: 3px auto 4px;margin-left: 4px; clear: both;">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                        CssClass="do-not-include btnSubmit submitbtn printButtonHide" 
            onclick="btnSubmit_Click" />

        <input type="button" id="btnPrint" style="display:none" onclick="aa()" class="print da_submit_button printButtonHide"
            value="Print" />
    </div>
      <script type="text/javascript">
          $(window).load(function () { $("#spinnL").fadeOut("slow"); }); //Gajendra     
    </script>
    </form>
      <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/facebox.js"></script>
    <script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
     <%-- this code added by bharat on 25-june for header fixed--%>
    <script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../../css/gridviewScroll.min.js" type="text/javascript"></script>
    <script>
        //        var serviceUrl = "../../Webservices/iKandiService.asmx";
        //        var proxy = new ServiceProxy(serviceUrl);

        function gridviewScroll() {
            var gridWidth = $('#widthdiv').width() +5;
            var gridHeight = $('#widthdiv').height() + 0;
            $('.headertopfixed').gridviewScroll({
                width: gridWidth,
                height: gridHeight,
                freezesize: 2
            });
        }
        $(document).ready(function () {

            //alert();
            gridviewScroll();
        })
    </script>
</body>
</html>
