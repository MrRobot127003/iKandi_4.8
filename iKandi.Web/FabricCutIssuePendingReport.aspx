<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricCutIssuePendingReport.aspx.cs" Inherits="iKandi.Web.FabricCutIssuePendingReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/TopHeaderFixed.css" rel="stylesheet" type="text/css" />
    <link href="../../css/CommanTooltip.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-family: arial;
          }
      @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
        }
        .FabricConainer
        {
            width: 800px;
            margin: 0 auto;
        }
        .toptable thead span
        {
            line-height: 20px;
        }
        .header1
        {
            background: #dddfe4;
        }
        .srvtable
        {
            min-width: 1252px;
            width: 100%;
            margin-top: 0px;
            margin-left: 9px;
        }
        .srvtable td
        {
            padding: 0px 0px;
            height: 20px;
            font-family: arial !important;
            font-size:10px;
        }
         .srvtable th table td
        {
            font-family: arial !important;
            font-size:11px;
        }
        .widhcol1
        {
            width: 30px;
        }
        .widhcol2
        {
            min-width: 60px;
            max-width: 60px;
        }
        .widhConQty {
            min-width: 70px;
            max-width: 70px;
        }
        .widhcol4
        {
            min-width: 260px;
             max-width: 260px;
             text-align: left !important;
            padding-left: 3px !important;
        }
        .widhcol3
        {
            width: 40px;
        }
        /*.srvtable th
        {
            padding: 0px 0px;
            text-align: center;
            font-weight: 500;
            background: #dddfe4;
            text-transform: capitalize;
            color: #6b6464;
            font-size:11px;
            font-family:Arial !important;
            height:15px;
            border:1px solid #999;
        }*/
        .srvtable td
        {
            text-align: center;
            border-color: #9999;
        }
        td.process
        {
            border-color: #9999;
            border-bottom: 1px solid #9999;
            height:33px;
            text-align: center !important;
            font-family: arial !important;
        }
        .IssueChallan_width
        {
            min-width: 230px;
            max-width: 230px;
        }
        .da_astrx_mand
        {
            color: Red;
        }
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
        }
        #sb-wrapper-inner {
          border: 5px solid #999;
          border-radius: 5px;
        }
        #sb-wrapper-inner
        {
            background: #fff;
        }
        .StyleContextup
        {
         text-align: center;
          white-space: nowrap;
          vertical-align: middle;
          width: 2em;
        }
        .StyleContextup div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
              color: #405d9a;
            font-weight: bold;
         }
        .SrNoContextup
        {
             text-align: center;
              white-space: nowrap;
              vertical-align: middle;
              width: 2em;
        }
     .SrNoContextup div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
             color: #405d9a;
            font-weight: bold;
        }
        .StyleContextupH
        {
         text-align: center;
          white-space: nowrap;
          vertical-align: middle;
          width: 2em;
        }
        .StyleContextupH div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
         }
        .SrNoContextupH
        {
             text-align: center;
              white-space: nowrap;
              vertical-align: middle;
              width: 2em;
        }
     .SrNoContextupH div
        {
             -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
              -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
            -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
             filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
             -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
             margin-left: -10em;
             margin-right: -10em;
        }
        .Required_width
        {
            min-width: 60px;
            max-width: 60px;
        }
        .topsupplier
        {
            border-collapse: collapse;
        }
        .topsupplier th
        {
            background: #536EA9;
            color: #d4d4d4f8;
            text-align: center;
            border: 1px solid #999;
            font-family: arial !important;
            font-size:11px;
        }
        .topsupplier td
        {
            text-align: center;
            border: 1px solid #999;
            font-weight: bold;
        }
        .divspplier
        {
            position: absolute;
            top: 50%;
            left: 43%; /* width: 30em; */
            min-height: 200px;
            margin-top: -9em;
            margin-left: -15em;
            border: 1px solid #ccc;
            background-color: #f3f3f3;
        }
        .Qa_grid_table td
        {
                border-right: 1px solid #dbd8d8 !important;
                font-size: 9px !important;
                font-family: arial !important;
                text-align: center;
                border-bottom: 1px solid #999;
                border-top: 1px solid #999;
                 font-family: arial !important;
        }
        th.qaheader
        {
            border-right: 1px solid #999 !important;
            padding: 3px 5px !important;
            background: #cecccc;
        }
      .Qa_grid_table td:first-child
      {
           border-left: 1px solid #999 !important
      }
      .Qa_grid_table td:last-child
      {
           border-right: 1px solid #999 !important
      }
     .Qa_grid_table tr:nth-last-child(1) >td
      {
           border-bottom: 1px solid #999 !important
      }
       th.qaheader:first-child
        {
            border-left: 1px solid #999 !important
        }
        .Qa_grid_table th
        {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize; 
            text-align: center;
            font-weight: normal;
            font-size: 12px;
            border-right: 0px;
        }
        .Qa_grid_table
        {
           position: fixed;
            top: 50%;
            left: 82%;
            z-index: 0;
            background: #fff;
            width: 252px;
        }
        .abc  .Qa_grid_table
        {
            border-collapse: collapse;  
          }
        .Qa_grid_table td
        {
            font-size: 11px !important;
            padding: 2px 3px !important;
        }
        /* search box*/
    .searchbox_1{
    background-color: #fffbf8;
    padding:13px;
    width:335px;
    margin: 100px auto;
    -webkit-box-sizing:border-box;
    -moz-box-sizing:border-box;
    }
    .search_1{
    width:250px;
    height:15px;
    padding-left:5px;
    border-radius:2px;
    border:none;
    color:#0F0D0D;;
    font-weight:500;
    font-size: 10px !important;
    text-transform:capitalize !important;
    }
    .innertable
    {
        border-collapse:collapse;
     }
    .innertable td
    {
        border-left:1px solid #999;
        padding: 18px 0px;
        min-width: 50px;
        max-width: 50px;
     }
    .innertable td:first-child
    {
        border-left:0px;
     }
    td table tr:nth-last-child(1) > td.process 
     {
         border-bottom:0px !important;
      }
      td table td.process 
     {
         border-bottom-color:#9999 !important;
      }
     .challanIssuTo td.process
     {
         min-width:50px;
         max-width:50px;
         border-right:1px solid #9999;
      }
      .do-not-disable
      {
          border-radius:2px;
      }
      .abc
      {
     background:#00000069;
     height:100%;
     width:100%;
     position:absolute;
     top:0px;
   }
   .hideHederFabricIss
   {
       display:none;
    }
     .DisplayNoneH
     {
         display:none;
      }
      .widthPaading
      {
          width:100%;
          padding:0px;
       }
       .PaddingLeftRight
       {
           padding-right:5px !important;
        } 
      .srvtable td:first-child
      {
          border-left-color:#999 !important
       }
       .srvtable td:last-child
      {
          border-right-color:#999 !important
       }
      .srvtable tr:nth-last-child(1) > td
      {
          border-bottom-color:#999 !important
       }
       #here_table 
       {
           position:relative;
       }
      .qatableheader
       {
            content: "";
            position: absolute;
            top: 0%;
            right: -7%;
            margin-left: -5px;
            border-width: 9px;
            border-style: solid;
            border-color: transparent transparent transparent #39589c;
        }
        .qatableheader th 
        {
            border:1px solid #999;
         }
         .qatableheader td 
        {
            border:1px solid #dbd8d8;
         }
       /*  ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }*/
        #data
        {
            height:100%;
        }
        .widhcol4 table td
        {
            color:Gray;
         }
         .divspplier {
        position: fixed;
        top: 44%;
        left: 43%;
        /* width: 30em; */
        min-height: 120px;
        margin-top: -9em;
        margin-left: -15em;
        border: 1px solid #ccc;
        background-color: #f3f3f3;
        z-index:2;
            width: 274px;
}
        .DisNone
        {
            display:none;
          }
           [data-title] {
       position: relative;
    }
    [data-title]:hover::after {
       content: attr(data-title);
        position: absolute;
        top: -22px;
        left: 0px;
        padding: 3px 3px;
        background: #403c3c;
        color: #fff;
        z-index: 9;
        font-size: 10px;
        height: auto;
        line-height: 12px;
        border-radius: 3px;
        white-space: pre-line;
        word-wrap: break-word;
        min-width: 100px;
    }
       [data-title]:hover::before {
      content: '';
      position: absolute;
      bottom:2px;
      left: 5px;
      display: inline-block;
      color: #fff;
      border: 8px solid transparent;	
      border-top: 8px solid #403c3c;
    }
    .chkboxTop input[type='radio']
    {
       position: relative;
        top: 3px;
        right: 4px;
     }
     .headerSticky     {       
           width:100%;        padding: 3px 0px;       }
       table th       {         
             top:63px;           padding:0px 0px;        }
        td.StyleContextup        {    
                    border-left:1px solid #999;         }
         input[type="radio"]
         {
                 position: relative;
                 top: 2px;
          }
          .chekboxissuedate
          {
             position: relative;
             top: 4px;
           }
           table td table td.process
           {
               border-bottom:1px solid #999;
            }
            .btnbutton_Com
            {
                background: rgb(19, 167, 71);
                color: #fff;
                border: 1px solid green;
                padding: 2px 8px;
                border-radius: 2px;
                font-size: 11px;
                font-family: Arial;
                cursor: pointer;
             }
             .txtColorTop2
             {
                 position:relative;
                 top:-3px;
              }
              .chkboxTop{margin:7px 0;}
    </style>
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/service.min.js"></script>
    <script type="text/javascript" src="../js/form.js"></script>
    <script src="../js/facebox.js" type="text/javascript"></script>
    <script src="../js/CostRange/ProDuctShadowBox.js" type="text/javascript"></script>
    <link href="../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var url = "../../Webservices/iKandiService.asmx";
        function SBClose() { }
        function ShowSupplierChallanScreenSend(challanid, OrderDetailsID, FabricQualityID, FabricDetails, availableqty) {
            var sURL = '../Internal/Fabric/FabricSupplierChallanDetails.aspx?Debit_Note_ID=' + -1 + "&SupplierPoID=" + 0 + "&ChallanType=" + "INTERNAL" + "&ChallanID=" + challanid + "&FabType=" + '' + "&SendQty=" + 0 + "&IsNewChallan=" + 'Oldchallan' + "&OrderDetailsID=" + OrderDetailsID + "&FabricQualityID=" + FabricQualityID + "&FabricDetails=" + FabricDetails + "&availableqty=" + availableqty;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="PopTableW" style="width: 99%; margin-left: 9px; position: sticky; top: 0px; z-index: 9; background: #fff; padding: 2px 0px;">
        <div class="headerSticky">
            Fabric Production Issue Report
        </div>
        <div class="chkboxTop">
            <asp:TextBox ID="txtsearchkeyswords" Width="21%" Style="text-transform: capitalize;" class="search_1" placeholder="Search Fabric Quality/Style No/Serial No" runat="server" autocomplete="off"></asp:TextBox>
            <asp:RadioButton ID="rbReuest" Checked="true" GroupName="CutIsseRequest" runat="server" /><span>All Request </span>&nbsp;
            <asp:RadioButton ID="rbRequestPending" GroupName="CutIsseRequest" runat="server" /><span>Request Pending </span>&nbsp;
            <asp:RadioButton ID="rbIssueRequest" GroupName="CutIsseRequest" runat="server" /><span>Issue Request </span>&nbsp;
            <asp:RadioButton ID="rbIssueComplete" GroupName="CutIsseRequest" runat="server" /><span>Issue Complete </span>&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="btnbutton_Com do-not-disable" Text="Search" />
        </div>
    </div>
    <div>
        <asp:GridView ID="grdfabric" OnDataBound="grdfabric_DataBound" Width="99%" runat="server" CellPadding="0" ShowHeader="true" BorderWidth="0" CssClass="srvtable" OnRowDataBound="grdfabric_RowDatabound" AutoGenerateColumns="false">
            <RowStyle CssClass="FabricIssuedRow" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div>
                            <asp:Label ID="lblstyle" Text="Style No." runat="server"></asp:Label></div>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="StyleContextupH" Width="30px" />
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="lblstylenumber" Text='<%# Eval("StyleNumber") %>' runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol1 StyleContextup" Height="95px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <HeaderTemplate>
                        <div>
                            <asp:Label ID="lblSrNo" Text="Sr. No." runat="server"></asp:Label></div>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="SrNoContextupH" Width="30px" />
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="lblserial" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label></div>
                    </ItemTemplate>
                    <ItemStyle CssClass="SrNoContextup" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 120px" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="border-bottom: 1px solid #ddd7d7; border-right: 0px;">
                                    Cont. No.
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right: 0px;">
                                    Qty. pcs.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="border-bottom: 1px solid #9999; border-right: 0px;">
                                    <div class="TooltipVal" data-maxlength="10">
                                        <asp:Label ID="lblcontract" Text='<%# Eval("ContractNumber") %>' runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnContactNumber" runat="server" Value='<%# Eval("ContractNumber") %>' />
                                        <asp:HiddenField ID="hdnavailableqty" runat="server" />
                                        <asp:HiddenField ID="hdnfabricqualityid" runat="server" Value='<%# Eval("Fabric_Quality_DetailsID") %>' />
                                        <asp:HiddenField ID="hdnfabricdetails" runat="server" Value='<%# Eval("Fabric_Details") %>' />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right: 0px;">
                                    <asp:Label ID="lblqty" Text='<%# (Eval("Quantity") == DBNull.Value  || (Eval("Quantity").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Quantity")).ToString("N0") %>' runat="server"></asp:Label>
                                    <span style="color: gray; font-weight: 600">pcs.</span>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhConQty" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%;" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="border-right: 0px;">
                                    Cut Wastage %
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnOrderdetailID" runat="server" Value='<%# Eval("OderDetailID") %>' />
                        <asp:Label ID="lblcutwastage" runat="server" Text='<%# Eval("cutwas") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol2" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="border-right: 0px;">
                                    Fabric Details/Color Print/Avg.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblfab" ForeColor="blue" Text='<%# Eval("Fabric")%>' runat="server"></asp:Label>/<asp:Label ID="lblcolordetails" ForeColor="#000" Font-Bold="true" Text='<%# Eval("Fabric_Details")%>' runat="server"></asp:Label>/<asp:Label ID="Label1" Text='<%# Eval("Avgs")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widhcol4" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="border-right: 0px; min-width: 83px;">
                                    Actual Required<br />
                                    <span style='color: gray; font-size: 10px; position: relative; top: 4px;'>Contract * Avg.</span>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblreuiredqty" Text='<%# (Eval("Totalfebreq") == DBNull.Value  || (Eval("Totalfebreq").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Totalfebreq")).ToString("N0") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="border-right: 0px;">
                                    Cut Width
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="border-right: 0px;">
                                    Available qty. to issue
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblavailableqty" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="border-right: 0px;">
                                    Raise Cutting Request Date
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkraisecutting" Enabled="false" Checked='<%#Convert.ToBoolean(Eval("IsCuttingRequest"))%>' runat="server" />
                        <asp:Label ID="lblraisedate" Text='<%# Eval("CuttingRequestDate")%>' CssClass="txtColorTop2" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="border-right: 0px;">
                                    Required Qty.(Include Cut Wastage)
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="lblRequiredQtyIncludeCutWastage" runat="server"></asp:Literal>
                    </ItemTemplate>
                    <ItemStyle CssClass="Required_width" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%; height: 100%;" class="innertable">
                            <tr>
                                <td>
                                    Challan No.
                                </td>
                                <td style="border: 0px;">
                                    Issued Qty.
                                </td>
                                <td style="border-right: 0px;">
                                    Issued On
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="IssueChallan_width" />
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <HeaderTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="border-right: 0px;">
                                    View<br />
                                    Ch. His.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle CssClass="" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="border-right: 0px;">
                                    Issue Complete
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIssuecomplete" Enabled="false" Checked='<%#Convert.ToBoolean(Eval("IsCompleteIssue"))%>' runat="server" />
                        <asp:Label ID="lblIssuecompleteedate" Text='<%# Eval("IssueCompleteDate")%>' CssClass="txtColorTop2" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="border-right: 0px; min-width: 105px">
                                    <%-- Qty. left after issue complete--%>
                                    Stock Moved Qty
                                    <br />
                                    Debit Qty
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle Width="122px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
