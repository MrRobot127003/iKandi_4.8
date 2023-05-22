<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryPurchaseOrderPdf.aspx.cs"
    Inherits="iKandi.Web.AccessoryPurchaseOrderPdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @media print{@page {size: landscape}}
        
         .preview-window {
            width: 100%;
          }
        
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
            font-size: 11px !important;
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
	    margin-top:10px;
	    max-width: 298px;	    
	    border-bottom:0px;
      }  
        .AuthoriImage
  {
      max-width:150px;
      min-width:100px;
   }
   .AuthoriImage img
  {
    margin-top: 5px;
    height: 50px;
   }
   
.btnClose
{
    margin-left: 3px;
    color: rgb(255, 255, 255);
    font-size: 11px !important;
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
   border-color:#999 !important;
   font-size: 11px;
   color: gray;
  }
#divguidline div ul li
{
    font-size:9px!important;
    font-family: arial !important;
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
        font-size: 11px;
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
        font-size: 11px;
        margin-top:10px;
     }
    .BodyContect .btnCancel
    {
        background: #39589c;
        color: #fff;
        border: 1px solid #39589c;
        border-radius: 2px;
        cursor: pointer;
        font-size: 11px;
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
        z-index:9999 !important;
    }
    #Pohistory
    {
       line-height:20px;
       padding-top: 6px;
     }
     .btnPrint {
    margin-left: 5px;
    font-size: 11px !important;
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
    <div style="width: 100%; margin: 0 auto">
        <div>
            <table class="purchase_order" style="margin-top: 3px; border-bottom: 0px; border-right-color: #999; border-left-color: #999;font-size:8px!important;">
                <thead>
                    <tr>
                   <th style="display: flex;text-align: left;align-items: center;border: 0;border-right: 1px solid lightgray;padding-right: 17px;box-sizing: border-box;font-size:8px!important;" class="barder_top_color">
                                    <div style="padding: 5px 7px 8px; float:left;">
                                        <asp:Image ID="boutiqueImg" runat="server" width="100"/>
                                    </div>
                                    <div id="divbipladdress" runat="server" style="padding-left: 5px;font-size:8px!important;">
                                    </div>
                                </th>
                        <th style="text-align: left; border-left: 0px;border-bottom: 0;padding-left:5px;"  rowspan="2" class="barder_top_color">
                           <span id="Order_text" runat="server" style="font-size:12px;"></span> 
                             <a onclick="history_Click()" id="ShowImgHis" runat="server" visible="false" style="color: Blue;font-size:20px; position: absolute; right: 10px; cursor: pointer;" target="_blank">
                                <img src="../../images/history1.png" />
                            </a>
                        </th>
                    </tr>
                </thead>
            </table>
            <table class="purchase_order" style="margin-top: 0px; border-bottom: 0px; border-right-color: #999;
                border-left-color: #999; font-size:11px;">
                <tbody>
                    <tr>
                        <td style="padding-left: 7px; border-left-color: #999; color: #6b6464;font-size:8px!important;">
                            PO No:
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblPoNo" Style="font-weight: bold;" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: right; color: #6b6464;font-size:8px!important;">
                            PO Date:
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblPoDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="text-align: right; color: #6b6464;font-size:8px!important;">
                            Supplier:
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblSupplierName" runat="server" Text="" style="font-size:8px!important;color:Gray;"></asp:Label>
                            <asp:Label ID="lblSupplierDetail" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="text-align: right; color: #6b6464;font-size:8px!important;">
                            ETA Date:
                        </td>
                        <td style="border-right-color: #999; font-size:8px!important;">
                            <asp:Label ID="lblETADate" runat="server" Text="" style="font-size:8px!important;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="8" style="border-left-color: #999; border-top-color: #dbd8d8; text-align: left;
                            border-right-color: #999; border-bottom: 0px; color: #6b6464;">
                            <span style="font-size:8px!important; margin-top: -7px;color:Gray;">Client Code:</span>
                             <span style="font-weight: bold;font-size:8px!important;">
                                <asp:Label ID="lblClientCode" runat="server"></asp:Label></span>
                        </th>
                    </tr>
                    <tr>
                        <th colspan="8" style="border-left-color: #999; border-top-color: #dbd8d8; text-align: left;
                            border-right-color: #999; border-bottom: 0px; color: #6b6464;">
                            <span style="font-size:8px!important; margin-top: -7px;color:Gray;" runat="server" id="spn_HSNCode"></span>
                             <span style="font-weight: bold;font-size:8px!important;">
                                <asp:Label ID="lblHSNCode" runat="server"></asp:Label></span>
                        </th>
                    </tr>
                </tbody>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="AccessoryTable" style="width: 100%;">
                <thead>
                    <tr>
                        <th class="ths" rowspan="2" style="font-size:8px!important;">
                            Accessory Quality (Size) Color/Print
                        </th>
                        <th class="ths" rowspan="2" style="min-width:50px;font-size:8px!important;">
                            Shrnkg
                        </th>
                        <th class="ths" rowspan="2" style="min-width:50px;font-size:8px!important;">
                            Wstg
                        </th>
                        <th class="ths" rowspan="2" style="min-width:90px;font-size:8px!important;">
                            Accessory Type
                        </th>
                        <th class="ths" colspan="3">
                            Quantity<span style="color: red; font-size: 8px;">*</span>
                        </th>
                        <th class="ths" colspan="2">
                            Finance<span style="color: red; font-size: 8px;">*</span>
                        </th>
                    </tr>
                    <tr>
                        <th class="ths" style="width: 60px;font-size:8px!important;">
                            Send
                        </th>
                        <th class="ths" style="width: 80px;font-size:8px!important;">
                            Receivable
                        </th>
                        <th class="ths" style="width: 60px;font-size:8px!important;">
                            Unit
                        </th>
                        <th class="ths" style="width: 60px;font-size:8px!important;">
                            Rate
                        </th>
                        <th class="ths" style="width: 80px;font-size:8px!important;">
                            Total Amount
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblAccessoryQuality" ForeColor="blue" Text="" runat="server"></asp:Label>
                            <asp:Label ID="lblSize" ForeColor="Gray" Text="" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblcolorprint" ForeColor="Black" Font-Bold="true" Text="" runat="server"></asp:Label>
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblShrinkage" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnShrinkage" Value="0" runat="server" />
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblWastage" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblAccessType" runat="server"></asp:Label>
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblSendQty" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnSendQty" runat="server" />
                        </td>
                        <td style="font-size:8px!important;">
                            <asp:Label ID="lblReceivedqty" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnReceivedQty" runat="server" />
                        </td>
                        <td style="width: 80px">
                            <div id="dvAccessUnit" runat="server">
                                <asp:Label ID="lblAccessUnit" runat="server" Text="Label"></asp:Label>
                            </div>
                        </td>
                        <td style="font-size:8px!important;">
                        <span style="color: green; font-size: 8px;margin-right: 3px">₹</span>
                            <asp:Label ID="lblRate" runat="server" Text="Label" style="font-size:8px;color: green;"></asp:Label>
                        </td>
                        <td style="font-size:8px!important;">
                            <span id="AddIndianCurrency" runat="server"></span>
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div>
            <div style=" padding-left: 5px; width: 99%; margin-top: 5px;
                margin-bottom: 5px;">
                <table cellpadding="0" cellspacing="0" width="99%">
                    <tr>
                        <td style="min-width: 330px; vertical-align: top;">
                            <div class="clsDivHistory" style="display: none; margin-left: 10px;border-bottom:0;" id="dvHeader"
                                runat="server">
                            </div>
                            <asp:GridView ID="grdHistoryQty" CssClass="table receivehis lastrow" runat="server"
                                AutoGenerateColumns="false" Width="300px" OnRowDataBound="grdHistoryQty_RowDataBound"
                                Style="margin-left: 10px; margin-right: 10px;border:0;font-size:8px!important;">
                                <Columns>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# (Convert.ToDateTime(Eval("PORevisedDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PORevisedDate")).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_left_color" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Send Quantity" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSendQty" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO Quantity" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPoQuantity" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="txtcenter border_right_color" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 100%; vertical-align: top; text-align: right; padding-right: 10px;
                            padding-top: 10px;">
                            <asp:GridView ID="grdQtyRange" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!"
                                HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" ShowFooter="false"
                                CssClass="table receivehis lastrow" Width="282px" ShowHeader="true" Style="border-top: 0px;
                                border-bottom: 1px bolid #999; margin-right: 10px;font-size:8px!important; float: right" OnRowDataBound="grdQtyRange_RowDataBound">
                                <RowStyle CssClass="gvQtyRangeRow" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblHdrFromQty" runat="server" Text=""></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromQty" Text='<%# Eval("FromQty")%>' runat="server"></asp:Label>
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
                                            <asp:Label ID="lbltoqty" runat="server" Text='<%# Eval("ToQty")%>'></asp:Label>

                                             <asp:Label ID="lblAccessUnit1" runat="server"></asp:Label>
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
            <label style="font-weight: normal !important;font-size:8px!important;color:Gray;"> Remarks:</label>
            <asp:Label ID="lblRemarks" runat="server" Style="font-weight: normal !important;font-size: 10px;color:Gray;"></asp:Label>
            <div id="divguidline" runat="server"> </div>

            <div style="width: 100%;display: flex;margin: 10px 0;padding: 10px 0;">

                 <div style="width: 50%;display: flex;text-align: center;flex-direction: column;align-items: center;float:left;font-size:8px!important;">
                      <b style="width:100%;text-align:center;margin-right: 50px;">Boutique International Pvt. Ltd.</b>
                        <div class="AuthoriImage" id="divAuthorizedSig" runat="server" visible="false" style="padding-left: 7px;font-size: 10px;">
                            <asp:Image ID="imgAuthorizedSignatory" class="disabledCheckboxes" runat="server" Height="40" /><br />
                            <asp:Label ID="lblAuthorizedName" runat="server" Style="margin-bottom:8px;"></asp:Label><br />
                            <asp:Label ID="lblAuthorizedDate" runat="server"></asp:Label>
                        </div>
                        <div id="divAuthorizedSigchk" runat="server">
                            <asp:CheckBox ID="chkAuthorizedSignatory" runat="server" />
                            (Authorized Signature)
                        </div>
                    </div>
                     <div style="width: 40%;display: flex;text-align: center;flex-direction: column;align-items: center;float:right;font-size: 12px;">
                      
                        <div class="AuthoriImage" id="divPartySig" runat="server" visible="false" style="display: flex;flex-direction: column;align-items: center;font-size:8px!important;">
                          <b> Accepted by</b>
                            <asp:Image ID="imgpartysingature" ImageUrl="~/Uploads/Photo/NotSign.jpg" runat="server" height="40" />
                            <asp:Label ID="lblPartyName" runat="server" style="line-height: 10px;"></asp:Label>
                            <asp:Label ID="lblPartyDate" runat="server"></asp:Label>
                        </div>
                        <div id="divPartySigchk" runat="server">
                            <asp:CheckBox ID="chkpartysignature" runat="server" Style="font-size:8px!important;" Height="40" />
                            (Party Signature)
                        </div>
                    </div>
            </div>





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
    <div id="PoWaterMark" runat="server" visible="false" class="cancel_wrapper" style="background-image: url('http://boutique.in/images/cancel-img.png');
        background-position: center; background-repeat: no-repeat; position: absolute;
        top: 20%; left: 0%; transform: translate(-50%, -50%); z-index: 99; width: 100%;
        height: 300px; opacity: 0.2; transform: rotate(-20deg);">
    </div>
    </form>
</body>
</html>
