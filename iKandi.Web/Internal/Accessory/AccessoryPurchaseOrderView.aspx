<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryPurchaseOrderView.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryPurchaseOrderView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    function ChangeColorDropDown() {

        $("#ddlAccessUnit").addClass('SelectedColor');
        $("#ddlAccessUnit").find('option').addClass('BackColor');
        $('option:selected').addClass('SelectBackColor');

    }

    function BaseColorDropDown() {
        $("#ddlAccessUnit").removeClass('SelectedColor');
        $('option:selected').removeClass('SelectBackColor');
        $("#ddlAccessUnit").find('option').addClass('BackColor');
    }
    function history_Click() {
        //debugger;
        var SupplierPOId = $("#hdnSupplierPoId").val();
        var hist = "";
        proxy.invoke("GetPOAccesoryHistory", { SupplierPOId: SupplierPOId },
                    function (response) {
                        if (response.length > 0) {
                            $("#divhistory").show();
                            for (var i = 0; i < response.length; i++) {
                                hist += response[i].DetailDescription + "<br>";
                            }
                            $("#Pohistory").html(hist);
                        }


                    });
    }
    function showhistory() {
        $("#divhistory").hide();
    }
    $(document).ready(function () {
        //debugger;
        $('input').attr('readonly', true);

    })
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @media print{@page {size: Portrait;}}
        body
        {
            background: #fff none repeat scroll 0 0;
            font-family: arial !important;
        }
        table
        {
            font-family: arial;
            border-color: #dbd8d8;
            border-collapse: collapse;
             
        } 
        table td {
        height: 15px;
        font-size: 10px;
        text-transform:capitalize;
    }     
     
        .ths {
	    background: #dddfe4;
	    font-weight: normal;
	    color:#575759;
	    font-family:arial;
	    font-size: 10px;
	    padding: 5px 0px;
	    text-align: center;
	    text-transform: capitalize;
	    border:1px solid #c6c0c0;
    }
      .AccessoryTable th
      {
           background: #dddfe4;
           border:1px solid #999;
           padding:5px 0px;
           text-align:center;
           font-weight: 500;
           font-size: 11px; 
           font-family:Arial;
       }
     .AccessoryTable td
      {
         
           border:1px solid #dbd8d8;
           padding:2px 0px;
           text-align:center;
           font-weight: 500;
           font-size: 10px;
           height:20px; 
           font-family:Arial
       }
       .AccessoryTable td:first-child
       {
           border-left-color:#999 !important;
        }
         .AccessoryTable td:last-child
       {
           border-right-color:#999 !important;
        }
        .AccessoryTable tr:nth-last-child(1) > td
       {
           border-bottom-color:#999 !important;
        }
       .AccessoryTable td input[type="text"]
       {
           width:90%;
           font-size:10px;
        }
      input[type="text"]
        {
            font-size:10px !important;
            }
         .purchase_order 
           {
             width:100%;
             border: 1px solid #dbd8d8;
            }
         .purchase_order input
         {
             margin:1px 0px;
             height:15px;
          }
          select
          {
              height: 21px !important;
           }
       .purchase_order thead th
       {
           border:1px solid #dbd8d8;
           padding:2px 0px;
           text-align:center;
           text-align: center;
           font-weight: 600 !important;
           font-size: 11px;
        }
        .purchase_order tbody th
       {
           border:1px solid #999;
           padding: 5px 7px;
            font-weight: 500;
              font-size: 11px;
        }
       .purchase_order tbody td
       {
          
           padding: 0px 5px;
           border-color:#dbd8d8;
        }
       select
       {
           width: 76px;
         }
      
       .supplieretadatetable td input[type="text"]
       {
           width:92%;
           margin:1px 0px;
        }
        .supplieretadatetable td
        {
            text-align:center;
         }
        #ctl00_cph_main_content_grdqtyrange th
        {
            background: #dddfe4;
            padding:2px 2px;
             width: 98px;
             text-align:center;

            }
             ul{
            list-style-type: none;
            margin: 0;
            padding: 0px 2px;
            max-width: 98%;
          }
        li{
                padding: 1px 0px 1px;
                font-size: 11px;
                line-height: 13px;
                color:Gray;
        }
        .receivehis
        {
            float:left;
            margin-right:10px;
            margin-bottom:10px;
         }
          .receivehis th
        {
              background: #dddfe4;
              padding: 2px 2px;
              text-align:center;
              border:1px solid #999;
              font-size:11px;
              font-family:Arial;
               color:#575759;
               font-weight:500;
         }
         .receivehis td
        {
              padding: 2px 2px;
              text-align:center;
              border:1px solid #dbd8d8;
              font-size:10px;
              font-family:Arial;
         }
           .receivehis td:first-child
           {
               border-left:1px solid #999 !important;
            }
        
            .receivehis td:last-child
           {
               border-right:1px solid #999 !important;
            }
            
            .receivehis tr:nth-last-child(1)>td
           {
               border-bottom:1px solid #999 !important;
            }
        
        .lastrow td { text-align:center; }   

    .txtcenter
    {
        text-align:center}
        
       .lastrow tr:nth-last-child(1)>td {
          border-bottom-color:#999 !important;
        } 
        
@media print {
body {-webkit-print-color-adjust: exact;}
 .printHideButton {
                display: none;
              }
}
 .btnSubmit
        {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: 600;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 23px;
            border: none !important;
            border-radius: 2px;
            margin-left: 5px;
            text-align: center;
        }
        #ValidationSummary1 ul li
        {
            color:Red;
            font-size:11px;
          }
 .clsDivHistory
      {
        background: #dddfe4;
	    font-weight:bold;
	    color:#575759;
	    font-family: sans-serif;
	    font-size: 11px;
	    padding: 5px 0px;
	    text-align: center;
	    text-transform: capitalize;
	    border:1px solid #999;	   
	    border-bottom:0px;
	     max-width: 298px;
	    margin-top:10px;
	    border-bottom:0px;
      }  
        .AuthoriImage
  {
      max-width:170px;
      min-width:100px;
   }
   .AuthoriImage img
  {
     margin-top:5px;
     height: 50px;
   }
   
.btnClose
{
    margin-left: 3px;
    color: rgb(255, 255, 255);
    font-size: 12px !important;
    float: left;
    font-weight: 600;
    width: 52px;
    cursor: pointer;
    background: rgb(19, 167, 71);
    height: 24px;
    line-height: 24px;
    border: none !important;
    border-radius: 2px;
    text-align: center;
    text-transform:capitalize;
}
.btnClose:hover
{
    color: red;
}
#divguidline div
{
   width:99.8% !important; 
   border-color:#999 !important
  }
  input[type="checkbox"]
  {
      position: relative;
      top: 3px;
   }
   input
   {
       text-transform: capitalize !important;
    }
   .AddCuurency::after
   {
        content:"₹ ";
        color: green;
        font-size: 12px;
        padding-left: 4px;
        position: relative;
        top: 1px
     }
   input[readonly] {
    background-color: #ccc;
}
  .modalNew
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
    #Unitpopup
    {
        background: #eae7e7;
        margin: 0 auto;
        width: 286px;
        max-height: 200px;
        height: 112px;
        border-radius: 5px;
    }
    .BodyContect .btnOk
    {
        background: #4CAF50;
        color: #fff;
        border: 1px solid #4CAF50;
        border-radius: 2px;
        cursor: pointer;
        font-size: 12px;
        margin-top:10px;
     }
    .BodyContect .btnCancel
    {
        background: #39589c;
        color: #fff;
        border: 1px solid #39589c;
        border-radius: 2px;
        cursor: pointer;
        font-size: 12px;
    }
    .UnitHeader
    {
        width: 99%;
        padding: 2px;
        background: #1f335d;
        color: #f8f8f8;
        margin: 0px 0px 3px 0px;
        text-align:center;
    }
    .UnitTable td .btnSubmit
    {
        font-weight: bold;
        width: 52px;
        cursor: pointer;
        background: rgb(19, 167, 71);
        height: 21px;
        line-height: 16px;
        border: none !important;
        border-radius: 2px;
        margin-left: 5px;
        text-align: center;
        float:unset;
            margin-top: 5px;
       
     }
     
 /* .UnitTable th
      {
           background: #dddfe4;
           border:1px solid #999;
           padding:5px 0px;
           text-align:center;
           font-weight: 500;
           font-size: 11px; 
           font-family:Arial;
       }*/
     .UnitTable td
      {
          text-align:center;
       }
 .SelectedColor
  {
   background-color:Yellow;
   }
  .BackColor
  {
    background:#fff;
   }
  .BackColor.SelectBackColor
   {
      background-color:Yellow;  
    }
    .ModelPo
        {
            width: 280px;
            margin: -26% auto;
            text-align: center;
            position: relative;
            z-index: 100000;
       
        }
         .ModelPo2
        {
               background: #e6e6e6;
                width: 570px;
                margin: -40% auto;
                text-align: center;
                position: relative;
                z-index: 100000;
                padding: 0px 0px 15px;

        }
       .backcolorpo
        {
                background: #eae7e7;
                width: 100%;
                min-height: 89px;
                padding: 0px 0px;
                /* box-shadow: 0px 0px 1px 3px #c5a0a099; */
                border-radius: 2px;
        }
        .BodyContect h2
        {color:#fff;
            background: #39589c;
            width: 100%;
            padding: 2px 0px;
           font-size: 14px;
        }
        #ui-datepicker-div{
        background: #ff000000 !important;
        border-color: #1b1b1b00 !important;
    }
    #Pohistory
    {
       line-height:20px;
       padding-top: 6px;
     }
     .btnPrint {
    margin-left: 5px;
    font-size: 12px !important;
    color: rgb(255, 255, 255);
    font-weight: 600;
    width: 52px;
    cursor: pointer;
    background: #39589c !important;
    height: 24px;
    line-height: 26px;
    border: none !important;
    border-radius: 2px;
    float: left;
    text-align: center;
    margin-bottom: 2px;
}
 ::-webkit-scrollbar {
            width: 8px;
             height: 8px;
        }
        ::-webkit-scrollbar-thumb {
        background: #999;
        border: 1px solid #ddd7d7;
        border-radius: 10px;
    }
    #sb-wrapper-inner.BorderPopup 
    {
        background:#fff;
     }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 99%; margin: 0 auto">
        <div>
            <table class="purchase_order" style="margin-top: 3px; border-bottom: 0px; border-right-color: #999;
                border-left-color: #999;">
                <thead>
                    <tr>
                        <%--  <th colspan="8" style="color: #fff; background: #39589c;font-weight: normal !important;font-size: 15px;border-color:#999">
                            <span style="float: left;font-size: 12px;padding-left: 5px;margin-top: 3px;"> All <span style="color: Red; font-size: 12px;">*</span> (Asterisk) Mark Field Mandatory</span> <span style="padding-right:20%;">Accessory Purchase Order</span>
                                   <a onclick="history_Click()" id="ShowImgHis" runat="server" visible="false" style="color: Blue;float:right;margin-right:5px;cursor: pointer;" target="_blank">
                               <img src="../../images/history.png" /></a>                       
                          
                        </th>--%>
                    </tr>
                    <tr>
                       <th style="display: flex;text-align: left;align-items: center;border: 0;border-right: 1px solid lightgray;box-sizing: border-box;width: 650px;" class="barder_top_color">
                            <div style="padding: 5px 7px 8px">
                                <img src="../../images/boutique-logo.png">
                            </div>
                            <div id="divbipladdress" runat="server" style="padding-left: 5px;">
                            </div>
                        </th>
                       <th style="text-align: left; border-left: 0px;border-bottom: 0;"  rowspan="2" class="barder_top_color">
                            <span id="Order_text" runat="server" style="font-size:20px;font-weight:500;"></span>
                             <a onclick="history_Click()" id="ShowImgHis" runat="server" visible="false"
                                style="color: Blue; position: absolute; right: 10px; cursor: pointer;" target="_blank">
                                <img src="../../images/history1.png" /></a>
                        </th>
                    </tr>
                </thead>
            </table>
            <table class="purchase_order" style="margin-top: 0px; border-bottom: 0px; border-right-color: #999;
                border-left-color: #999;">
                <tbody>
                    <tr>
                        <td style="padding-left: 7px; border-left-color: #999; width: 46px">
                            PO No:
                        </td>
                        <td>
                            <asp:Label ID="lblPoNo" Width="80px" Style="font-weight: bold; font-size: 13px;"
                                runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnPoNo" runat="server" />
                            <asp:HiddenField ID="hdnSupplierPoId" Value="-1" runat="server" />
                        </td>
                        <td style="text-align: right;">
                            PO Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtPoDate" style="width:75px;color:black;font-weight:600;" CssClass="PODate do-not-allow-typing" runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right;">
                            Supplier<span style="color: red; font-size: 12px;">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSupplierName" runat="server" Width="275px" CssClass="">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnSupplierId" Value="-1" runat="server" />
                        </td>
                        <td style="text-align: right;">
                            ETA Date<span style="color: red; font-size: 12px;">*</span>
                        </td>
                        <td style="border-right-color: #999;">
                            <asp:TextBox ID="txtETADate" style="Width:80px;color:black;font-weight:600;" onkeypress="return false;" CssClass="EtaDate do-not-allow-typing"
                                runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdnEtaDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                    <th colspan="10" style="border-bottom: none; text-align: left;border-left: 1px solid #999;padding:5px;">
                    <span style="font-size: 12px; margin-top: -7px;color:gray">Client Code:</span>
                     <span style="font-weight: bold;font-size: 12px;">
                       <asp:Label ID="lblClientCode" runat="server"></asp:Label>
                    </span>
                    </th>
                    </tr>
                    <%--RajeevS --%>
                    <tr>
                    <th colspan="10" style="border-bottom: none; text-align: left;border-left: 1px solid #999;padding:5px;">
                    <span style="font-size: 12px; margin-top: -7px;color:gray" runat="server" id="spn_HSNCode"></span>
                    <span style="font-weight: bold;font-size: 12px;">
                       <asp:Label ID="lblHSNCode" runat="server"></asp:Label>
                    </span>
                    </th>
                    </tr>
                    <%--RajeevS --%>
                </tbody>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="AccessoryTable" style="width: 100%;">
                <thead>
                    <tr>
                        <th class="ths" rowspan="2">
                            Accessory Quality (Size) Color/Print
                        </th>
                        <th class="ths" rowspan="2">
                            Shrinkage (%)
                        </th>
                        <th class="ths" rowspan="2">
                            Wastage (%)
                        </th>
                        <th class="ths" rowspan="2">
                            Accessory Type
                        </th>
                        <th class="ths" colspan="3">
                            Quantity<span style="color: red; font-size: 12px;">*</span>
                        </th>
                        <th class="ths" colspan="2">
                            Finance<span style="color: red; font-size: 12px;">*</span>
                        </th>
                    </tr>
                    <tr>
                        <th class="ths" style="width: 60px;">
                            Send
                        </th>
                        <th class="ths" style="width: 80px;">
                            Received
                        </th>
                        <th class="ths" style="width: 60px;">
                            Unit
                        </th>
                        <th class="ths" style="width: 60px;">
                            Rate
                        </th>
                        <th class="ths" style="width: 80px;">
                            Total Amount
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text="" runat="server"></asp:Label>
                            <asp:Label ID="lblSize" ForeColor="Gray" Text="" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblcolorprint" ForeColor="Black" Font-Bold="true" Text="" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblShrinkage" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnShrinkage" Value="0" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblWastage" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAccessType" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsentQty" CssClass="numeric-field-without-decimal-places" Style="text-align: center;font-weight:600;"
                                runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdnSendQty" runat="server" />
                            <asp:HiddenField ID="hdnSendBase" runat="server" />
                            <asp:HiddenField ID="hdnSend_CalBase" runat="server" />
                            <asp:HiddenField ID="hdnCancel_SendQty" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceivedqty" CssClass="numeric-field-without-decimal-places"
                                Style="width: 73px !important; text-align: center;font-weight:600;" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdnReceivedBase" runat="server" />
                            <asp:HiddenField ID="hdnReceived_CalBase" runat="server" />
                            <asp:HiddenField ID="hdnReceivedQty" runat="server" />
                            <asp:HiddenField ID="hdnCancel_ReceivedQty" runat="server" />
                        </td>
                        <td style="width: 80px">
                            <asp:DropDownList ID="ddlAccessUnit" runat="server">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnBaseAccessUnitVal" runat="server" />
                            <asp:HiddenField ID="hdnAccessUnitVal" runat="server" />
                            <asp:HiddenField ID="hdnAccessUnitName" runat="server" />
                            <asp:HiddenField ID="hdnUnitChange" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnSrvCount" Value="0" runat="server" />
                        </td>
                        <td>
                         <span style='color: green; font-size: 16px; margin-right: 3px'>₹</span>
                            <asp:TextBox ID="txtRate" Style="width: 35px;text-align: center;color: green;font-size: 13px!important;font-weight: 600;" CssClass="numeric-field-with-decimal-places"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <span id="AddIndianCurrency" runat="server"></span>
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div>
            <div style="border: 1px solid #999; margin: 5px 0px; padding-left: 5px; width: 99.3%;">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="min-width: 330px">
                            <div class="clsDivHistory" style="display: none; margin-left: 10px;" id="dvHeader"
                                runat="server">
                            </div>
                            <asp:GridView ID="grdHistoryQty" CssClass="table receivehis lastrow" runat="server"
                                AutoGenerateColumns="false" Width="300px" OnRowDataBound="grdHistoryQty_RowDataBound"
                                Style="margin-left: 10px; margin-right: 10px;">
                                <Columns>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PORevisedDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PORevisedDate")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_left_color" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Send Quantity" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSendQty" runat="server" Font-Bold="true" Text=""></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO Quantity" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPoQuantity" runat="server" Font-Bold="true" Text=""></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_right_color" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 100%; vertical-align: top; text-align: right; padding-top: 10px;">
                            <asp:GridView ID="grdQtyRange" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!"
                                HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" ShowFooter="false"
                                CssClass="table receivehis lastrow" Width="282px" ShowHeader="true" Style="border-top: 0px;
                                border-bottom: 1px bolid #999; margin-right: 10px; float: right" OnRowDataBound="grdQtyRange_RowDataBound">
                                <RowStyle CssClass="gvQtyRangeRow" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHdrFromQty" runat="server" Text=""></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromQty" Font-Bold="true" Text='<%# Eval("FromQty")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHdrToQty" runat="server" Text=""></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                            <asp:HiddenField ID="hdnSupplierPO_ETA_Id" runat="server" Value='<%# Eval("SupplierPO_ETA_Id")%>' />
                                            <asp:HiddenField ID="hdnRowNumber" runat="server" Value='<%# Eval("RowNumber")%>' />
                                            <asp:Label ID="lbltoqty" Font-Bold="true" runat="server" Text='<%# Eval("ToQty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            ETA Dates
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldates" Text='<%# (Convert.ToDateTime(Eval("POETADate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("POETADate")).ToString("dd MMM yy (ddd)")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 50%; border: 1px solid #d6cccc; padding: 5px 0px;margin-bottom: 5px;">
                <ul style="list-style-type: none; margin: 0; padding: 0px 2px;">
                    <li>
                        <ul style="list-style-type: none; margin: 0; padding: 0px 2px;display:flex;">
                            <li style="border-bottom: 0px solid #999999;padding: 2px 0px 2px;color: #6b6464;margin: -2px 10px 0 0;"><span>Remarks :-</span> </li>
                            <li>
                                <asp:Label ID="lblRemarksAcc" runat="server"></asp:Label>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>

            <div id="divguidline" runat="server">
            </div>
                <div style="width: 100%;border: 1px solid darkgray;display: flex;margin: 10px 0;padding: 10px 0;">
                     <div style="width: 33%;display: flex;text-align: center;flex-direction: column;align-items: center;">
                         <b>Boutique International Pvt. Ltd.</b>
                            <div class="AuthoriImage" id="divAuthorizedSig" runat="server" visible="false" style="display: flex;flex-direction: column;align-items: center;">
                                <asp:Image ID="imgAuthorizedSignatory" class="disabledCheckboxes" runat="server" />
                                <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                                <asp:Label ID="lblAuthorizedDate" runat="server"></asp:Label>
                            </div>
                          <div style="width: 33%;display: flex;text-align: center;flex-direction: column;align-items: center;"> 
                            <div id="divAuthorizedSigchk" runat="server">
                                <asp:CheckBox ID="chkAuthorizedSignatory" runat="server" Style="position: relative;
                                    top: 2px; margin-left: -5px;" />
                                (Authorized Signature)
                            </div>
                        </div>
                        </div>
                     <div style="width: 33%;display: flex;text-align: center;flex-direction: column;align-items: center;margin-left:auto;">
                            <b>Accepted by</b>
                            <div class="AuthoriImage" id="divPartySig" runat="server" visible="false" style="display: flex;flex-direction: column;align-items: center;">
                                <asp:Image ID="imgpartysingature" runat="server" />
                                <br />
                                <asp:Label ID="lblPartyName" runat="server" Style="line-height: 20px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblPartyDate" runat="server"></asp:Label>
                            </div>
                            <div id="divPartySigchk" runat="server">
                                <asp:CheckBox ID="chkpartysignature" runat="server" Style="position: relative; top: 2px;" />
                                (Party Signature)
                            </div>
                        </div>
            </div>
            <div class="btnClose printHideButton" onclick="javascript:self.parent.Shadowbox.close();">
                Close</div>
            <div class="btnPrint printHideButton" onclick="window.print();return false">
                Print</div>
        </div>
    </div>
    <div class="ModelPo" id="dvUnit" style="display: none">
        <div class="backcolorpo">
            <div class="BodyContect">
                <h2>
                    Convert Unit Ratio</h2>
                <div style="width: 150px; display: initial">
                    <span style="margin-right: 5px;">From </span>
                    <asp:Label ID="lblPreviousUnit" ForeColor="Gray" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtPreviousUnitVal" ReadOnly="true" Style="text-align: center;"
                        Width="40px" runat="server" Text="1"></asp:TextBox>
                    <span style="margin-right: 5px;">To </span>
                    <asp:Label ID="lblCurrentUnit" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtUnitValue" Style="text-align: center;" onkeypress="return isNumberWithDecimal(event,this)"
                        MaxLength="5" Width="40px" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnConversionVal" Value="0" runat="server" />
                </div>
                <div style="width: 100%">
                </div>
                <input id="btnUnit" type="button" class="btnOk" value="Ok" />
                <input id="btnUnitCancel" class="btnCancel printHideButton" type="button" value="Cancel" />
            </div>
        </div>
    </div>
    <div class="ModelPo2" id="divhistory" style="display: none">
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <th style='background: #39589c !important; padding: 3px 5px; color: #fff !important;
                    text-align: center'>
                    History<span style='float: right; cursor: pointer; color: #fff' onclick="showhistory()"
                        titel='Close'>X</span>
                </th>
            </tr>
            <tr>
                <td style="width: 50%; text-align: left; padding: 0px 10px;">
                    <div id="Pohistory">
                    </div>
                    <%--  <asp:Label ID="lblh" style="text-align:left;line-height: 15px;color:#737272; font-size: 11px;" runat="server"></asp:Label>--%>
                </td>
            </tr>
        </table>
    </div>
    <div id="PoWaterMark" runat="server" visible="false" class="cancel_wrapper" style="background-image: url('http://boutique.in/images/cancel-img.png');
        background-position: center; background-repeat: no-repeat; position: absolute;
        top: 20%; left: 0%; transform: translate(-50%, -50%); z-index: 99; width: 100%;
        height: 300px; opacity: 0.2; transform: rotate(-20deg);">
    </div>
    </form>
</body>
</html>
