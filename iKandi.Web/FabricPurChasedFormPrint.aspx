<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricPurChasedFormPrint.aspx.cs"
    Inherits="iKandi.Web.FabricPurChasedFormPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       /* @media print{@page {size: landscape}}*/
        body
        {
            background: #fff none repeat scroll 0 0;
            font-family: arial !important;
        }
        table
        {
            font-family: arial;
            border-color: #b7b7b7;
            border-collapse: collapse;
            text-transform: capitalize;
        }        
         table td
        {
           height:15px;
            font-size: 10px;
          
        }
        .lastrow tbody .HeaderClass td
        {
            background-color:#dddfe4!important;
            border: 1px solid #bfbfbf;
            color:Gray;
            }
    .purchase_order {
            width: 950px;
            border: 1px solid #dbd8d8;
        }
 .txtcenter{
        text-align:center;
        }
 @media print {  @page { margin: 0; }
  body {-webkit-print-color-adjust: exact; margin: 1.6cm;}
 .printHideButton { display: none; }
      .HeaderClass td
        {
            background: #dddfe4;
	        font-weight: normal;
	        color: #575759;
	        font-family: arial;
	        font-size: 11px;
	        padding: 0px 0px;
	        border-color: #999;
	        font-family: arial !important;
        }
      
         .purchase_order 
           {
             width:950px;
             border: 1px solid #dbd8d8;
            }
         .purchase_order input
         {
             margin:1px 0px;
          }
          input[type="text"]
          {
                margin: 2px 1px;
                font-size:10px !important;
                font-family:Arial !important;
                height:15px;
           }
       .purchase_order thead th
       {
           border:1px solid #dbd8d8;
           padding:5px 0px;
           text-align:center;
           text-align: center;
           font-weight: 600 !important;
           font-size: 12px;
        }
        .purchase_order tbody th
       {
           border:1px solid #999;
           padding: 5px 7px;
            font-weight: 500;
        }
       .purchase_order tbody td
       {
          
           padding: 0px 5px;
           border-color:#dbd8d8;
        }
       select
       {
           width: 90px;
           height:19px;
         }
      
       .supplieretadatetable td input[type="text"]
       {
           width:92%;
           margin:1px 0px;
            font-size:10px !important;
            font-family:Arial !important;
        }
        .supplieretadatetable td
        {
            text-align:center;
         }
        #grdqtyrange th
        {
            background: #dddfe4;
            padding:2px 2px;
             width: 98px;
             text-align:center;
             border-color:#999;
             color:#575759;
            }
             ul{
            list-style-type: none;
            margin: 0;
            padding: 0px 2px;
            max-width: 98%;
          }
        li{
                padding: 1px 0px 1px;
                font-size: 10px;
                line-height: 13px;
                color:Gray;
                font-family:arial;
                text-transform:capitalize;
        }
        .backgroundcolorclass
        {
            background-color:#dddfe4;
        }
        .receivehis
        {
            float:left;
            margin-right:10px;
            
         }
          .receivehis td
        {
            border:1px solid #999;
            
         }
          .receivehis th
        {
              background-color: #dddfe4!important;
              padding: 2px 2px;
              text-align:center;
              border: 1px solid darkgray;
              color:#575759;
         }
        .receivehis td:first-child
        {
            border-left-color:#999 !important
        }
        
        .lastrow td { text-align:center; }   


        
       .lastrow tr:nth-last-child(1)>td {
          border-bottom-color:#999 !important;
        } 
        


        a.tooltips
        {
            position: relative;
            display: inline;
        }
        
        a.tooltips span
        {
            position: absolute;
            width: 350px;
            color: #FFFFFF;
            background: #000000;
            height: 30px;
            line-height: 30px;
            text-align: center;
            visibility: hidden;
            border-radius: 6px;
        }
        
        a.tooltips span:after
        {
            content: '';
            position: absolute;
            top: 100%;
            left: 35%;
            margin-left: -8px;
            width: 0;
            height: 0;
            border-top: 8px solid #000000;
            border-right: 8px solid transparent;
            border-left: 8px solid transparent;
        }
        
        a:hover.tooltips span
        {
            visibility: visible;
            opacity: 0.8;
            bottom: 30px;
            left: 50%;
            margin-left: -140px;
            z-index: 999;
        }
        #sb-wrapper-inner
        {
            border: 5px solid #999;
            border-radius: 4px;
        }
        #divguidline div
        {
            width:816px !important;
            border-color: #999 !important;
            padding-top: 5px !important;
        }
        .btnClose
        {
            margin-left: 10px;
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: 600;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px !important;
            line-height: 24px !important;
            border: none !important;
            border-radius: 2px;
            text-align: center;
            text-transform: capitalize;
             font-family: arial !important;
        }
        .btnClose:hover
        {
            color: red;
        }
        .btnSubmit
        {

            font-size: 12px !important;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px !important;
            line-height: 24px !important;
            border: none !important;
            border-radius: 2px;
            margin-left: 5px;
            text-align: center;
            text-transform: capitalize;
             font-family: arial !important;
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
        }
        .footerCotent #btnok
        {
            background: green;
            color: #fff;
            cursor: pointer;
            padding: 1px 7px;
            border: 1px solid green;
            border-radius: 2px;
            font-size: 11px;
            position: relative;
            transition: .5s ease;
            top: 8px;
            left: 157px;
            right: 0px;
        }
        .footerCotent #Btncancel
        {
            background: red;
            color: #fff;
            cursor: pointer;
            padding: 1px 7px;
            border: 1px solid red;
            border-radius: 2px;
            font-size: 11px;
            position: relative;
            top: 8px;
            left: 4px;
            right: 0px;
            float: right;
        }
        .footerCotent
        {
            height: auto;
            width: 94%;
            margin: 5px auto;
            text-align: right;
            padding-right: 5px;
        }
        .btnPrint
        {
            margin-left: 10px;
            font-size: 12px !important;
            float: left;
            color: rgb(255, 255, 255);
            font-weight: 500;
            width: 52px;
            cursor: pointer;
            background: #39589c !important;
            height: 24px !important;
            line-height: 24px !important;
            border: none !important;
            border-radius: 2px;
            text-align: center;
            text-transform: capitalize;
             font-family: arial !important;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        #secure_footer
        {
            display: none;
        }
        #secure_banner_cor
        {
            padding: 0px !important;
        }
        #main_content
        {
            width: 100% !important;
        }
        #secure_center_contentWrapper
        {
            width: 99.5% !important;
        }
        input[readonly]
        {
           /* background: #CCC;*/
            color: #8e8e8e;
            border: 1px solid #666;
            font-family:Arial;
            font-size:10px !important;
        }
        .displaynoneSup th:last-child
        {
            display: none;
        }
        .displaynoneSup td:last-child
        {
            display: none;
        }
        .AuthoriImage
        {
            max-width: 150px;
            min-width: 100px;
            max-height: 46px;
            position: relative;
            top: -5px;
            right: 2%;
        }
        .AuthoriImage img
        {
            width: 80%;
            height: 29px;
        }
        .center_bodyCentering
        {
            overflow-x: hidden;
        }
        .border_right_color
        {
            border-right-color: #999 !important;
        }
        #grdqtyrange
        {
            text-align: center;
        }
        #grdqtyrange td:first-child
        {
            border-left-color: #999 !important;
        }
        #grdqtyrange td:last-child
        {
            border-right-color: #999 !important;
        }
        #grdqtyrange tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        .colwidthG
        {
            min-width: 40px;
            max-width: 40px;
            height: 29px; 
            border:none;     
        }
        .colwidthC
        {
            min-width: 40px;
            max-width: 40px;
            height: 29px;
        }
        td.colwidthG
        {
        border-right: 1px solid #999;
        border-right: 0px;
        border-top: none;
        border-bottom: none;
        }
        .colwidthinnr
        {
            min-width: 40px;
            max-width: 40px;
            height: 29px;
        }
        
        td.colwidthinnr
        {
            border-right: 1px solid #dbd8d8;
        }
        .tdpadding0
        {
            padding: 0px !important;
        }
        input[type="checkbox"]
        {
            position: relative;
            top: 2px;
        }
        .AuthorizedSignatorydate
        {
            float: right;
            right: 35%;
            position: relative;
        }
        .AuthorizedSignatorydate1
        {
            <%--float: left;--%>
            position: relative;
           <%-- left: 46%;--%>
        }
        .PositionRight
        {
            right: 11% !important;
        }
        .RightCheckBox input[type="checkbox"]
        {
            right: 5px;
        }
        .center
        {
            margin: auto;
            width: 90%;
            border: 3px solid #73AD21;
            padding: 10px;
            margin-top: -416px;
            background: #39589c;
        }
        .ModelPo
        {
            background: #fff;
            width: 300px;
            margin: -32% auto;
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
                width: 285px;
                min-height: 89px;
                padding: 0px 0px;
                position:fixed;
                /* box-shadow: 0px 0px 1px 3px #c5a0a099; */
                border-radius: 2px;
                top: calc(50% - 50px/2);
                left: calc(40% - 50px/2)
        }
        .BodyContect h2
        {color:#fff;
            background: #39589c;
            width: 100%;
            padding: 8px 0px;
        }
        
        .backcolorpo .btnOk
        {
            background: #4CAF50;
            color: #fff;
            border: 1px solid #4CAF50;
            border-radius: 2px;
            cursor: pointer;
            font-size: 12px;
         }
         .backcolorpo .btnCancel
        {
            background: #39589c;
            color: #fff;
            border: 1px solid #39589c;
            border-radius: 2px;
            cursor: pointer;
            font-size: 12px;
        }

        .BodyContect
        {
            margin-bottom:10px;
         }
       .etadate{
          font-size:11px !important;
          width:80% !important;
        }
        .tableCenter td input
        {
            text-align: center;
        }
        .tableCenter td
        {
            text-align: center;
            border:1px solid #9999;
        }
        .boldness{font-weight:bold;}
        .color_black{ color:Black !important}
        
        .tableCenter td:last-child
        {
          border-right-color:#999;  
        }
        .tableCenter tr:last-child > td
        {
          border-bottom-color:#999;  
        }
        <style>
    /* tr:nth-child(even) */
    tr.even { background-color: #F4F4F8; }
    /* tr:nth-child(odd) */
    tr.odd { background-color: #EFF1F1; }
  @media screen and (max-width:1066px)
    {
        .ModelPo2
        {
           margin: -50% auto;
        }
    }
    
    .HistoryUl {

    position: relative;
    left: -1px;
    margin: 0px;
}
.imgviewhi
{max-height: 18px;
    max-width: 33px;
    vertical-align: bottom;
    }
    #divbipladdress span
    {
        font-size:11px !important;
      }
HistoryUl ::marker {content: "•"; color: red;
  display: inline-block; width: 1em;
  margin-left: -1em}
.LiCircel
{
    width: 7px;
    height: 7px;
    border-radius: 50px;
    background: gray;
    display: inline-block;
     margin-right: 3px;
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
    #sb-wrapper-inner
    {
        background:#fff;
     }
     .center_bodyCentering
     {
         background:#fff !important;
      }


      .hideresidual
      {
           display:none;
          
          
          }
          
.border_class
{
    border: 1px solid darkgray;
    }

</style>
</head>
<body>
    <form id="form1" runat="server">
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script> 
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/form.js"></script>

    <asp:HiddenField ID="hdintialsuppliercode" runat="server" />
    <asp:HiddenField ID="hdnstorepodate" runat="server" />
    <asp:HiddenField ID="hdnstoresupplierid" runat="server" />
    <asp:HiddenField ID="hdnstoreetadate" runat="server" />
    <asp:HiddenField ID="hdnstoresendqty" runat="server" />
    <asp:HiddenField ID="hdnstorereceivedqty" runat="server" />
    <asp:HiddenField ID="hdncurrentstage" runat="server" />
    <asp:HiddenField ID="hdnstoreunitsid" runat="server" />
    <asp:HiddenField ID="hdnstorerate" runat="server" />
    <asp:HiddenField ID="hdnstoretotalamount" runat="server" />
    <asp:HiddenField ID="hdntxtdates" runat="server" />
    <asp:HiddenField ID="hdntoqty" runat="server" />
    <asp:HiddenField ID="hdnconversionvalue" runat="server" />
    <asp:HiddenField ID="hdnminsrv" runat="server" />
    <asp:HiddenField ID="hdnconverttounit" runat="server" />
    <asp:Label ID="lblgerigeshrinkage" runat="server" Style="display: none;"></asp:Label>
    <asp:Label ID="lblresidualshrinkage" runat="server" Style="display: none;"></asp:Label>
    <table class="purchase_order" style="margin-top: 5px; border-right-color: #999; border-left-color: #999;">
        <thead>
            <tr style="display: none;">
                <th colspan="8" style="color: #fff; padding: 1px 0px; background: #39589c; font-weight: normal !important;
                    font-size: 15px; border-color: #999">
                    <span style="float: left; font-size: 12px; padding-left: 5px;">All <span style="color: Red;
                        font-size: 12px;">*</span> (asterisk) mark field mandatory</span> <span style="padding-right: 20%;">
                            Purchase Order</span>
                    <%--   <a onclick="showhistory('block')" id="lnkhistoryshow" style="color: Blue;float:right;margin-right:5px;cursor: pointer;" target="_blank">
                               <img src="../../images/history.png" /></a>--%>
                </th>
            </tr>
            <tr>
                <th style="display: flex;text-align: left;align-items: center;border: 0;border-right: 1px solid lightgray;padding-right: 17px;box-sizing: border-box;width: fit-content;" class="barder_top_color">
                     <span style="padding: 0px 7px 5px; width:150px;float:left;">
                        <asp:Image ID="imgboutique" runat="server" />
                    </span>
                    <div id="divbipladdress" runat="server" style="padding-left: 10px;padding-top:10px;line-height:20px;font-size:11px;"> </div>
                </th>
              <th style="border-left: 0px; text-align: left;padding-left:10px; border-right-color: #999; font-size: 24px; position: relative; font-weight: 400 !important; border-bottom: 0px">
                    <span id="Order_text" runat="server" style="margin-right: 10px;"></span>
                </th>
            </tr>
        </thead>
    </table>
    <table class="purchase_order" style="margin-top: 0px;border-right-color: #999;border-left-color: #999;border-bottom: 0px;">
        <tbody>
            <tr style="border-right:1px solid #999;border-bottom:1px solid #999;">
                <td style="padding:5px 0 5px 7px;border-left-color: #999; width: 40px;">
                    PO No:
                </td>
                <td style="border-right: 1px solid darkgray;">
                    <asp:Label ID="lblPoNo" Style="font-weight: bold; font-size: 13px;" runat="server"></asp:Label>
                </td>
                <td style="text-align: right; width: 50px;">
                    PO Date:
                </td>
                <td style="width: 100px;border-right:1px solid #999;">
                    <asp:Label ID="txtPoDate" Style="width: 75px;color:Black;font-weight:bold;" CssClass="datesfileds" onchange="Resetetagrd()"
                        runat="server"></asp:Label>
                </td>
        
                <td style="text-align: right;">
                    Supplier:
                </td>
                <td style="border-right: 1px solid darkgray;">
                    <asp:DropDownList ID="ddlSupplierName" Width="280px" Style="margin: 2px 0px; height: 18px;
                        display: none;" CssClass="spchange storedata" onchange="javascript:GetSupplierChange(); Resetetagrd()"
                        AppendDataBoundItems="true" runat="server">
                        <asp:ListItem Text="Select" Value="-1" />
                    </asp:DropDownList>
                    <asp:Label ID="lblsupplier" runat="server"></asp:Label>
                </td>
                <td style="text-align: right; width: 50px;">
                    ETA Date:
                </td>
                <td style="border-right:1px solid #999; width: 120px">
                    <asp:Label ID="txtETADate" Style="width: 94%;color:Black;font-weight:bold;" onkeypress="return false;" CssClass="th2 datesfileds storedata"
                        runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <th colspan="10" style="border-bottom: none; text-align: left;border-left: 1px solid #999;border-right: 1px solid #999;padding:5px;">
                    <span style="font-size: 12px; margin-top: -7px;color:gray">Client Code:</span>
                     <span style="font-weight: bold;font-size: 12px;">
                        <asp:Label ID="lblClintCode" runat="server"></asp:Label></span>
                </th>
            </tr>
            <tr>
                <th colspan="10" style="border-bottom: none; text-align: left;border-left: 1px solid #999;border-right: 1px solid #999;padding:5px;">
                    <span style="font-size: 12px; margin-top: -7px;color:gray" runat="server" id="spn_HSNCode">HSN Code:</span>
                     <span style="font-weight: bold;font-size: 12px;">
                        <asp:Label ID="lblHSNCode" runat="server"></asp:Label></span>
                </th>
            </tr>
        </tbody>
    </table>
    <asp:GridView ID="grdfabricpurchased" ShowHeader="false" runat="server" AutoGenerateColumns="False"
        EmptyDataText="No Record Found!" Width="950px" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" BorderWidth="1" rules="all" OnRowDataBound="grdfabricpurchased_RowDataBound"
        HeaderStyle-CssClass="ths" CssClass="lastrow">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <Columns>
            <asp:TemplateField HeaderText="Fabric Quality">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnremainingQty" runat="server" Value='<%# Eval("PendingQtyToOrder")%>' />
                            <asp:HiddenField ID="hdnfabricQuality" runat="server" Value='<%# Eval("Fabric_QualityID")%>' />
                            <asp:HiddenField ID="hdnSupplierMasterID" runat="server" Value='<%# Eval("supplier_master_Id")%>' />
                            <asp:Label ID="lblFabricQuality" ForeColor="Blue" Font-Bold="true" Text='<%# Eval("TradeName")%>' runat="server"></asp:Label>
                           <%-- <asp:Label ID="lblgsm" ForeColor="Gray" Text='<%# Eval("GSM")%>' runat="server" CssClass=" color_black boldness"></asp:Label>--%>
                           <%-- <asp:Label ID="lblcountconstraction" ForeColor="Gray" Text='<%# Eval("CountConstruction").ToString()%>' runat="server"></asp:Label>--%>
                           <%-- <asp:Label ID="lblwidth" ForeColor="Gray" CssClass=" color_black boldness" Text='<%# Eval("width").ToString()+"&quot in" %>' runat="server"></asp:Label>--%><br />
                          <%--  <asp:Label ID="lblcolorprint" Font-Bold="true" Text='<%# Eval("FabricDetails")%>' runat="server"></asp:Label>--%>
                        </ItemTemplate>
                        <ItemStyle CssClass="border_left_color" Width="160px" HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="C&C">
                        <ItemTemplate>
                            <asp:Label ID="lblcountconstraction" ForeColor="Gray" Text='<%# Eval("CountConstruction").ToString()%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="GSM">
                        <ItemTemplate>
                            <asp:Label ID="lblgsm" ForeColor="Gray" Text='<%# Eval("GSM")%>' runat="server" CssClass=" color_black boldness"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Width">
                        <ItemTemplate>
                            <asp:Label ID="lblwidth" ForeColor="Gray" CssClass=" color_black boldness" Text='<%# Eval("width").ToString()+"&quot in" %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="ColorPrint">
                        <ItemTemplate>
                             <asp:Label ID="lblcolorprint" Font-Bold="true" Text='<%# Eval("FabricDetails")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:Label ID="Label1" Style="display: none;" runat="server"></asp:Label>&nbsp;&nbsp;<nobar>
                         <asp:Label ID="lblGreige" Text='<%# (Eval("Greige_Sh") == DBNull.Value  || (Eval("Greige_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Greige_Sh").ToString().Trim() %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="tdpadding0" Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <%--<asp:Label ID="lblcolorprint" Font-Bold="true" Text='<%# Eval("FabricDetails")%>' runat="server"></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle Width="120px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlsupplytype" Style="display: none" DataTextField="Name" CssClass="storedata"
                        AppendDataBoundItems="true" DataValueField="SupplierType_Id" DataSourceID="SqlDataSource1"
                        runat="server">
                        <asp:ListItem Text="Select" Value="-1" />
                    </asp:DropDownList>
                    <asp:Label ID="lblprocesstype" runat="server"></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select SupplierType_Id,	case when Name='Griege' then 'Greige' else Name end Name ,Type from tblSupplierType where type in (1,4) and SupplierType_Id in (1,2,3,10,27,28,29,30,31)">
                    </asp:SqlDataSource>
                </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnResidualshrnk" runat="server" Value='<%# (Eval("Greige_Sh") == DBNull.Value  || (Eval("Greige_Sh").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Greige_Sh").ToString().Trim() %>' />
                    <asp:HiddenField ID="hdnSendQtyValidate" runat="server" />
                    <asp:HiddenField ID="hdngerigeshrnk" runat="server" />
                    <asp:HiddenField runat="server" ID="hdnsendqty" />
                    <%--   <a runat="server" id="ansendtooltip" class="tooltips">--%>
                    <asp:Label ID="txtsendQty" onchange="return CheckSendQty(this);" MaxLength="8" onkeypress="return isNumberKey(event)"
                        Style="width: 70px !important; text-align: center;" runat="server" CssClass="storedata"></asp:Label>
                    <%--  <span id="spanmsgsendqty" runat="server"></span>--%>
                    <asp:HiddenField ID="hdnavailablesendqty" runat="server" Value='<%# (Eval("PendingQtyToOrder") != null) ? Eval("PendingQtyToOrder").ToString() : ((Eval("PendingQtyToOrder") != null) ? Eval("PendingQtyToOrder") : "")%>' />
                    <%-- </a>--%>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnreceivedqty" Value='<%# (Eval("QtyToOrder") == DBNull.Value  || (Eval("QtyToOrder").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("QtyToOrder")).ToString("N0") %>' />
                    <%--<a runat="server" id="anreceivetooltip" class="tooltips">--%>
                    <asp:Label ID="txtreceivedqty" class="classfabsave storedata" onkeypress="return isNumberKey(event)"
                        onchange="javascript:ValidateMinReceiveQty(this); GetSupplierRateChange();  Resetetagrd();"
                        Style="width: 70px !important; text-align: center;font-weight:bold;" runat="server" Text='<%# (Eval("QtyToOrder") == DBNull.Value  || (Eval("QtyToOrder").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("QtyToOrder")).ToString("N0") %>'></asp:Label>
                    <%--  <span id="spanmsgsendqtys" runat="server"></span></a>--%>
                </ItemTemplate>
                <ItemStyle Width="70px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <%--<asp:DropDownList ID="ddlunits" SelectedValue='<%# Eval("GarmentUnit") %>' DataTextField="UnitName"
                        AppendDataBoundItems="true" DataValueField="GroupUnitID" DataSourceID="SqlDataSource2"
                        runat="server">
                        <asp:ListItem Text="All" Value="-1" />
                    </asp:DropDownList>--%>
                    <%--  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ connectionStrings:LocalMySqlServer %>"
                        SelectCommand="select GroupUnitID,UnitName from tblGroupUnit where ACTIVE=1 and GroupUnitID in (1,4)">
                    </asp:SqlDataSource>--%>
                    <asp:DropDownList ID="ddlunits" Style="display: none" Enabled="false" onchange="javascript:ConversionValueChange('UNITCHANGE');"
                        CssClass="storedata" SelectedValue='<%# Eval("ConvertTounit") %>' runat="server">
                        <%--  <asp:ListItem Text="All" Value="-1" />--%>
                        <asp:ListItem id="rMeter" Text="Mtr" Value="1" />
                        <asp:ListItem id="ryard" Text="yard" Value="4" />
                        <asp:ListItem id="rkg" Text="kg" Value="3" />
                    </asp:DropDownList>
                    <asp:Label ID="lblunit" runat="server" Font-Bold="true"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdndefualtorderunit" Value='<%# (Eval("GarmentUnit") == DBNull.Value  || (Eval("GarmentUnit").ToString().Trim() == string.Empty)) ? -1 : Eval("GarmentUnit") %>' />
                    <asp:HiddenField runat="server" ID="hdnConvertTounit" Value='<%# (Eval("ConvertTounit") == DBNull.Value  || (Eval("ConvertTounit").ToString().Trim() == string.Empty)) ? -1 : Eval("ConvertTounit") %>' />
                    <asp:HiddenField runat="server" ID="hdnsaveconversionvalue" Value='<%# (Eval("ConversionValue") == DBNull.Value  || (Eval("ConvertTounit").ToString().Trim() == string.Empty)) ? 1 : Eval("ConversionValue") %>' />
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnrateSupplierQuotedRate" Value='<%# (Eval("SupplierQuotedRate") == DBNull.Value  || (Eval("SupplierQuotedRate").ToString().Trim() == string.Empty)) ? string.Empty : Eval("SupplierQuotedRate").ToString().Trim() %>' />
                    <span style='color: green; font-size: 13px;margin-right: 3px'>₹</span>
                    <asp:Label ID="txtrateSupplierQuotedRate" onchange="javascript:GetSupplierRateChange();"
                            onkeypress="return validateFloatKeyPress(this,event);" CssClass="storedata" Style="width: 49px !important;text-align: center;color: green;font-size: 13px!important;font-weight: 600;" runat="server" Text='<%# (Eval("SupplierQuotedRate") == DBNull.Value  || (Eval("SupplierQuotedRate").ToString().Trim() == string.Empty)) ? string.Empty : Eval("SupplierQuotedRate").ToString().Trim() %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <span style="color: green; font-size: 12px; float: none; position: relative; margin-right: 3px;top:1px;">₹</span>
                    <asp:Label ID="lbltotalAmount" runat="server" Font-Size="11px"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" CssClass="border_right_color" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="border: 1px solid #999; border: 1px solid #999; margin: 10px 0px 0px; padding: 1px 0px 5px;width:950px;">
        <table style="width: 100%">
            <tr>
                <th class="hisclass" style="width: 200px; text-align: center; color: #575759">
                    <span class="hisclass" style="font-size: 12px; font-weight: 500;">History of Revise
                        Purchase Order</span>
                </th>
                <th style="text-align: right; padding-bottom: 10px; width: 60%;padding-right: 10px;font-size: 12px;color: dimgray;">
                        <asp:RadioButtonList ID="rdybtnListRateType" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem Text="Landed" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Ex Mill" Value="2"></asp:ListItem>
                        
                        </asp:RadioButtonList> 
                        
                        </th>
                        
            </tr>
            <tr>
                <td style="vertical-align: top; padding-left: 10px; padding-bottom: 5px;">
                    <asp:GridView ID="grdReceiveQtyHistory" Style="width: 357px; float: right" CssClass="table receivehis lastrow "
                        runat="server" AutoGenerateColumns="false" OnRowDataBound="grdReceiveQtyHistory_RowDataBound" ShowHeader="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px" HeaderStyle-BackColor="#dddfe4" >
                                <ItemTemplate>
                                    <asp:Label ID="lbldate" runat="server" Text='<%# Eval("PORevisedDates")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BorderColor="darkgray"></HeaderStyle>
                                <ItemStyle  HorizontalAlign="Center" CssClass="txtcenter border_left_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Quantity" ItemStyle-Width="100px" HeaderStyle-BackColor="#dddfe4">
                                <ItemTemplate>
                                    <asp:Label ID="lblsign" Style="font-size: 16px; font-weight: 900; position: relative;
                                        top: 1px;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("CheckQty")) %>'
                                        Text='<%# Eval("POQuantitybysign")%>'></asp:Label>
                                    <asp:Label ID="lblpoqty" runat="server" Font-Bold="true" Text='<%# Eval("POQuantity")%>'></asp:Label>&nbsp;
                                    <asp:Label ID="lnluntis" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# Eval("unitsname")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="txtcenter border_right_color" />
                                 <HeaderStyle BorderColor="darkgray"></HeaderStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="grdhistorysend" CssClass="table receivehis lastrow" runat="server"
                        AutoGenerateColumns="false" Width="300px" OnRowDataBound="grdhistorysend_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="100px" HeaderStyle-BackColor="#dddfe4" HeaderStyle-ForeColor="gray">
                                <ItemTemplate>
                                    <asp:Label ID="lbldate" runat="server" Text='<%# Eval("PORevisedDates")%>' CssClass="text_center"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtcenter border_left_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Send Quantity" ItemStyle-Width="100px" HeaderStyle-BackColor="#dddfe4" HeaderStyle-ForeColor="gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblsign" Style="font-size: 16px; font-weight: 900; position: relative;
                                        top: 1px;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("SendCheckQty")) %>'
                                        Text='<%# Eval("SendQuantitybysign")%>' CssClass="text_center"></asp:Label>
                                    <asp:Label ID="lblpoqty" runat="server" Text='<%# (Eval("SendQty") == DBNull.Value  || (Eval("SendQty").ToString().Trim() == "0")) ? string.Empty : Eval("SendQty").ToString().Trim() %>'></asp:Label>&nbsp;
                                    <asp:Label ID="lnluntis" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# Eval("unitsname")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtcenter" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Quantity" ItemStyle-Width="100px" HeaderStyle-BackColor="#dddfe4" HeaderStyle-ForeColor="gray">
                                <ItemTemplate>
                                    <asp:Label ID="lblsignr" Style="font-size: 16px; font-weight: 900; position: relative;
                                        top: 1px;" runat="server" ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("CheckQty")) %>'
                                        Text='<%# Eval("POQuantitybysign")%>' CssClass="text_center"></asp:Label>
                                            <asp:Label ID="lblpoqtyre" runat="server" Font-Bold="true" Text='<%# Eval("POQuantity")%>'></asp:Label>&nbsp;
                                            <asp:Label ID="lnluntisre" class="" ForeColor="Gray" Font-Bold="true" runat="server" Text='<%# Eval("unitsname")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtcenter border_right_color" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="vertical-align: top;">
                    <asp:GridView ID="grdqtyrange" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!"
                        HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" ShowFooter="false"
                        OnRowUpdating="grdqtyrange_RowUpdating" OnRowCancelingEdit="grdqtyrange_RowCancelingEdit"
                        OnRowCommand="grdqtyrange_RowCommand" OnRowEditing="grdqtyrange_RowEditing" OnRowDataBound="grdqtyrange_RowDataBound"
                        OnRowDeleting="grdqtyrange_RowDeleting" CssClass="supplieretadatetable table receivehis lastrow"
                        Width="349px" ShowHeader="true" Style="border-top: 0px; border-bottom: 1px bolid #999;
                        display: none">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    From Qty.
                                    <%--<span style="color:gray">(Mtr.)</span>--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblfromqty" Text='<%# Eval("FromQty")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txteditfromqty" Text='<%# Eval("FromQty")%>' runat="server" onkeypress="return isNumberKey(event)"
                                        ReadOnly="true" MaxLength="5" onchange="checkzero(this)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txtFromqty_Edit" runat="server" Display="None"
                                        ValidationGroup="gedit" ControlToValidate="txteditfromqty" ErrorMessage="Enter from qty"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    To Qty.
                                    <%--<span style="color:gray">(Mtr.)</span>--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnrownumber" runat="server" Value='<%# Eval("Row_Number")%>' />
                                    <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                    <asp:HiddenField ID="hdnSupplierPO_ETA_Id" runat="server" Value='<%# Eval("SupplierPO_ETA_Id")%>' />
                                    <asp:Label ID="lbltoqty" runat="server" Text='<%# Eval("ToQty")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="hdnrownumber" runat="server" Value='<%# Eval("Row_Number")%>' />
                                    <asp:HiddenField ID="hdnsupplierpoid" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                    <asp:HiddenField ID="hdnSupplierPO_ETA_Id" runat="server" Value='<%# Eval("SupplierPO_ETA_Id")%>' />
                                    <asp:TextBox ID="txtedittoqty" Text='<%# Eval("ToQty")%>' CssClass="storedata" runat="server"
                                        onkeypress="return isNumberKey(event)" MaxLength="5" onchange="CheckToQty(this)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txttoqty_Edit" runat="server" Display="None"
                                        ValidationGroup="gedit" ControlToValidate="txtedittoqty" ErrorMessage="Enter to qty."></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    ETA dates
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbldates" Text='<%# Eval("POETADate")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtdates" CssClass="th datesfileds storedata" Text='<%# Eval("POETADate")%>'
                                        runat="server" onkeypress="return isNumberKey(event)" MaxLength="5" onchange="CheckEtadates(this)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txtETA_Edit" runat="server" Display="None" ValidationGroup="gedit"
                                        ControlToValidate="txtdates" ErrorMessage="select dates"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Action
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" Text="../../images/edit2.png" alt="edit" CommandName="Edit"
                                        runat="server" OnClientClick="setbackviewstate()"><img src="../../images/edit2.png" alt="edit" /></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ForeColor="black"
                                        ToolTip="Delete" Width="20px"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle CssClass="Actiont_63 border_right_color" />
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnupdate" runat="server" ValidationGroup="gedit" CommandName="Update"
                                        Text="Update"><img src="../../App_Themes/ikandi/images/green_tick.gif" /></asp:LinkButton>
                                    <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"><img src="../../images/Cancel1.jpg" style="position: relative;top:2px;width:17px" /></asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvqtyrange" Style="display: none" CssClass="table receivehis lastrow"
                        runat="server" DataFormatString="{0:c}" OnRowDataBound="gvqtyrange_RowDataBound"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="From" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <%# Eval("FromQty")%>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtcenter border_left_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <%# Eval("ToQty")%>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtcenter" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ETA Date" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <%# Eval("POETADate")%>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtcenter border_left border_right_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="100px">
                                <ItemTemplate>
                                </ItemTemplate>
                                <ItemStyle CssClass="txtcenter border_right_color" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <%--<table border="1" cellpadding="0" class="supplieretadatetable" cellspacing="0" style="margin-top:-13px; display:block; border-top:0px;">
    <tr>
        <td style="width: 102px">         
            <asp:TextBox ID="txtqtyfrom" class="noonly" runat="server"  Text="" />
        </td>
        <td style="width: 102px">       
            <asp:TextBox ID="txtqtyto" class="noonly" runat="server"  Text="" />
        </td>
        <td style="width: 102px">        
            <asp:TextBox ID="txtetadateSupplier" CssClass="th datesfileds" runat="server" Text="" />
        </td>
        <td style="width: 100px;display:none">        
            <input type="image" id="dele" onclick="DeleteRow();return false;" />
        </td>
        <td style="width: 102px">      
           
                <img src="../../images/add-butt.png" id="btnAdd"  />
           
        </td>
    </tr>
</table>--%>
                    <div id="divrange" runat="server">
                    </div>
                    <table border="1" class="receivehis tableCenter table receivehis lastrow" cellpadding="0"
                        cellspacing="0" style="margin-top: -13px; width: 352px; float: right; margin-right: 5px;
                        display: none;">
                        <thead>
                            <tr>
                                <th style="width: 91px;">
                                    From
                                    <asp:Label ID="lblunitto" runat="server"></asp:Label>
                                </th>
                                <th style="width: 91px;">
                                    To
                                    <asp:Label ID="lblunitfrom" runat="server"></asp:Label>
                                </th>
                                <th style="width: 149px;">
                                    Date
                                </th>
                                <th style="width: 90px;">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody id="tblbreakedown">
                            <tr id="trbreaek0" runat="server" style="">
                                <td style="width: 91px; border: 1px solid #999;font-weight:bold;">
                                    <asp:Label ID="lblfromqty0" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty0" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 91px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty0" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty0" onchange="checkqtys(this,0)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 149px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate0" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate0" onchange="CheckEtadates2(0)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit0" onclick="Edit('EDIT',0)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate0" onclick="Edit('UPDATE',0)" alt="UPDATE" src="../../images/update-new.png"
                                        style="display: none; cursor: pointer;" />
                                    <img id="editcancel0" onclick="Edit('CANCELEDIT',0)" alt="CANCELEDIT" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; cursor: pointer; display: none" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                            <tr id="trbreaek1" runat="server" style="display: none">
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lblfromqty1" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty1" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty1" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty1" onchange="checkqtys(this,1)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 150px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate1" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate1" onchange="CheckEtadates2(1)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit1" onclick="Edit('EDIT',1)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate1" onclick="Edit('UPDATE',1)" alt="UPDATE" src="../../images/update-new.png"
                                        style="display: none" />
                                    <img id="editcancel1" onclick="Edit('CANCELEDIT',1)" alt="CANCELEDIT" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; display: none" />
                                    <img id="editdelete1" onclick="Edit('DELETE',1)" alt="DELETE" src="../../images/del-butt.png" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                            <tr id="trbreaek2" runat="server" style="display: none">
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lblfromqty2" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty2" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty2" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty2" onchange="checkqtys(this,2)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 150px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate2" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate2" onchange="CheckEtadates2(2)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit2" onclick="Edit('EDIT',2)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate2" onclick="Edit('UPDATE',2)" src="../../images/update-new.png"
                                        style="display: none" />
                                    <img id="editcancel2" onclick="Edit('CANCELEDIT',2)" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; display: none" />
                                    <img id="editdelete2" onclick="Edit('DELETE',2)" src="../../images/del-butt.png" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                            <tr id="trbreaek3" runat="server" style="display: none">
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lblfromqty3" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty3" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty3" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty3" onchange="checkqtys(this,3)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 150px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate3" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate3" onchange="CheckEtadates2(3)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit3" onclick="Edit('EDIT',3)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate3" onclick="Edit('UPDATE',3)" src="../../images/update-new.png"
                                        style="display: none" />
                                    <img id="editcancel3" onclick="Edit('CANCELEDIT',3)" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; display: none" />
                                    <img id="editdelete3" onclick="Edit('DELETE',3)" src="../../images/del-butt.png" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                            <tr id="trbreaek4" runat="server" style="display: none">
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lblfromqty4" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty4" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty4" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty4" onchange="checkqtys(this,4)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 150px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate4" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate4" onchange="CheckEtadates2(4)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit4" onclick="Edit('EDIT',4)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate4" onclick="Edit('UPDATE',4)" src="../../images/update-new.png"
                                        style="display: none" />
                                    <img id="editcancel4" onclick="Edit('CANCELEDIT',4)" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; display: none" />
                                    <img id="editdelete4" onclick="Edit('DELETE',4)" src="../../images/del-butt.png" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                            <tr id="trbreaek5" runat="server" style="display: none">
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lblfromqty5" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty5" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty5" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty5" onchange="checkqtys(this,5)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 150px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate5" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate5" onchange="CheckEtadates2(5)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit5" onclick="Edit('EDIT',5)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate5" onclick="Edit('UPDATE',5)" src="../../images/update-new.png"
                                        style="display: none" />
                                    <img id="editcancel5" onclick="Edit('CANCELEDIT',5)" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; display: none" />
                                    <img id="editdelete5" onclick="Edit('DELETE',5)" src="../../images/del-butt.png" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                            <tr id="trbreaek6" runat="server" style="display: none">
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lblfromqty6" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty6" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty6" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty6" onchange="checkqtys(this,6)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 150px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate6" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate6" onchange="CheckEtadates2(6)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit6" onclick="Edit('EDIT',6)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate6" onclick="Edit('UPDATE',6)" src="../../images/update-new.png"
                                        style="display: none" />
                                    <img id="editcancel6" onclick="Edit('CANCELEDIT',6)" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; display: none" />
                                    <img id="editdelete6" onclick="Edit('DELETE',6)" src="../../images/del-butt.png" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                            <tr id="trbreaek7" runat="server" style="display: none">
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lblfromqty7" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtfromqty7" ReadOnly="true" class="noonly" runat="server" Style="display: none"
                                        Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <asp:Label ID="lbltoqty7" runat="server"></asp:Label>
                                    <asp:TextBox ID="txttoqty7" onchange="checkqtys(this,7)" class="noonly" Style="display: none"
                                        runat="server" Text="" />
                                </td>
                                <td style="width: 150px; border: 1px solid #999">
                                    <asp:Label ID="lbletabreakedate7" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtetabreakedate7" onchange="CheckEtadates2(7)" CssClass="etadate datesfileds"
                                        Style="display: none" runat="server" Text="" />
                                </td>
                                <td style="width: 90px; border: 1px solid #999">
                                    <img id="edit7" onclick="Edit('EDIT',7)" src="../../images/edit2.png" style="" alt="edit" />
                                    <img id="editupdate7" onclick="Edit('UPDATE',7)" src="../../images/update-new.png"
                                        style="display: none" />
                                    <img id="editcancel7" onclick="Edit('CANCELEDIT',7)" src="../../images/Cancel1.png"
                                        style="position: relative; top: 2px; width: 22px; display: none" />
                                    <img id="editdelete7" onclick="Edit('DELETE',7)" src="../../images/del-butt.png" />
                                </td>
                                <td style="width: 90px; display: none">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <label style="font-weight: normal !important;font-size:11px;margin: 10px 0px;display:inline-block;"> Remarks:</label>
    <asp:Label ID="lblRemarks" runat="server" Style="font-weight: normal !important;font-size:11px;"></asp:Label>

    <div id="divguidline" runat="server" style="width:950px;"></div>

    <div style="padding:15px 10px;box-sizing:border-box;font-size: 10px;width: 952px;border: 1px solid #d7d7d7;border-top:0;">


            <div style="text-align: center;width: 35%;display:inline-block;float:left;">
                 <b style="color:black">Boutique International Pvt. Ltd.</b>
                <div class="AuthoriImage">
                    <asp:Image ID="imgAuthorizedSignatory" class="disabledCheckboxes" runat="server" style="max-width: 150px;max-height: 50px;border: 1px solid gray!important;padding: 5px;margin: 10px 0px;" /><br />
                    <asp:Label ID="lblAuthorizedName" runat="server"></asp:Label><br />
                    <asp:Label ID="lblAuthorizedSignatorydate" CssClass="AuthorizedSignatorydate" runat="server"></asp:Label>
                </div>
                <asp:CheckBox ID="chkAuthorizedSignatory" runat="server" />
                <span style="display: inherit;" runat="server" id="spanAuthorizedSig">(Authorized Signature)</span>
            </div>
            
             
            <div style="text-align: center; width: 35%;display:inline-block;float:right;">
                    <b style="color:black"> Accepted by</b>
                        <div class="AuthoriImage">
                            <asp:Image ID="imgpartysingature" runat="server"  style="max-width: 150px;max-height: 50px;border: 1px solid gray!important;padding: 5px;margin: 10px 0px;"/>
                            <asp:Label ID="lblPartyName" runat="server" CssClass="AuthorizedSignatorydate1" style="display: inherit;"></asp:Label>
                            <asp:Label ID="lblimgpartysingature" CssClass="AuthorizedSignatorydate1" runat="server"></asp:Label>
                        </div>
                        <asp:CheckBox ID="chkpartysignature" runat="server" CssClass="RightCheckBox" />
                        <span id="PositonRightM" runat="server">(Party Signature)</span>
            </div>

            <div style="clear:both;"></div>

    </div>





    <div class="btnClose printHideButton" style="background: #13a747 none repeat scroll 0 0 !important;border: medium none !important;color: #fff;font-size: 12px;margin: 10px;font-weight: bold;padding: 3px 5px;cursor: pointer; border-radius: 4px;width: 60px;text-align: center;letter-spacing: 1px;display: flow-root;" onclick="javascript:self.parent.Shadowbox.close();"> Close</div>
    <div id="PoWaterMark" runat="server" visible="false" class="cancel_wrapper" style="background-image: url('http://boutique.in/images/cancel-img.png'); background-position: center; background-repeat: no-repeat; position: absolute; top: 20%; left: 0%; transform: translate(-50%, -50%); z-index: 99; width: 100%;height: 300px; opacity: 0.2; transform: rotate(-20deg);">
    </div>
    </form>
</body>
</html>
