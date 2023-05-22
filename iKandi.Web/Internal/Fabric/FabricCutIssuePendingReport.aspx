<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricCutIssuePendingReport.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricCutIssuePendingReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            max-width: 1280px;
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
         border-bottom-color:#999 !important;
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
         ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }
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
     .headerSticky
     {
         width:1280px;
        padding: 3px 0px;
       }
       table th
       {
           top:49px;
           padding:0px 0px;
        }
        td.StyleContextup
        {
            border-left:1px solid #999;
         }
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
    </style>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="PopTableW" style="width: 1280px; margin-left: 9px; position: sticky; top: 0px;
            z-index: 9; margin-top: 2px;">
            <asp:HiddenField ID="hdnstaockqty" runat="server" />
            <asp:HiddenField ID="hdnfabricdetails" runat="server" />
            <asp:HiddenField ID="hdnfabricqtyid" runat="server" />
            <asp:HiddenField ID="hdnorderdetailsID" runat="server" />
        
            <div class="headerSticky">
                Fabric Cutting Issue 
               <%-- <span style="float: right; padding-right: 5px; margin-top: 0px;
                    font-size: 14px; cursor: pointer" onclick="closeFabCutIssButtion()">x</span>--%>
                    
                    </div>
            <div style="width: 100%; background: #fff; padding-bottom: 4px;">
                <asp:TextBox ID="txtsearchkeyswords" Width="21%" class="search_1" placeholder="Search Fabric Quality/Style No/Serial No"
                    runat="server"></asp:TextBox>
                <asp:Label ID="lbltotalrequest" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label
                    ID="lblpending" runat="server"></asp:Label>
                <asp:RadioButton ID="rbReuest" GroupName="CutIsseRequest" runat="server" />
                <span>All Request </span>
                <asp:RadioButton ID="rbRequestPending" GroupName="CutIsseRequest" runat="server" />
                <span>Request Pending </span>
                <asp:RadioButton ID="rbIssueRequest" GroupName="CutIsseRequest" runat="server" />
                <span>Issue Request </span>
                <asp:RadioButton ID="rbIssueComplete" GroupName="CutIsseRequest" runat="server" /><span>
                    Issue Complete </span>
                <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
                    OnClick="btnSearch_Click" Style="padding: 2px 7px;margin-left: 8px;" />
                <asp:HiddenField ID="hdnheaderID" runat="server" />
            </div>
        </div>
        <div style="position: relative;" class="table_width">
            <asp:GridView ID="grdfabric" OnDataBound="grdfabric_DataBound" runat="server" CellPadding="0"
                ShowHeader="true" BorderWidth="0" CssClass="srvtable" OnRowDataBound="grdfabric_RowDatabound"
                AutoGenerateColumns="false">
                <RowStyle CssClass="FabricIssuedRow" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <div>
                                <asp:Label ID="lblstyle" Text="Style No." runat="server"></asp:Label></div>
                        </HeaderTemplate>
                        <HeaderStyle CssClass="StyleContextupH" Width="25px" />
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
                        <HeaderStyle CssClass="SrNoContextupH" Width="25px" />
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblserial" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label></div>
                        </ItemTemplate>
                        <ItemStyle CssClass="SrNoContextup" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table style="width: 100%;" cellspacing="0" cellpadding="0">
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
                                        </div>
                                    </td>
                                </tr>
                                <%-- <tr>
                            <td style="border-bottom: 1px solid #ddd7d7;">
                               <asp:TextBox ID="txtcutwastage" Width="92%" onchange="UpdateWastage(this);" CssClass="allownumericwithdecimal"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>--%>
                                <tr>
                                    <td style="border-right: 0px;">
                                        <asp:Label ID="lblqty" Text='<%# (Eval("Quantity") == DBNull.Value  || (Eval("Quantity").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Quantity")).ToString("N0") %>'
                                            runat="server"></asp:Label>
                                        <span style="color: gray;font-weight:600">pcs.</span>
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
                                        Cut Wastage
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnOrderdetailID" runat="server" Value='<%# Eval("OderDetailID") %>' />
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="border-bottom: 1px solid #ddd7d7;">
                                    </td>
                                </tr>
                            </table>
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
                        </ItemTemplate>
                        <ItemStyle CssClass="widhcol4" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td style="border-right: 0px;min-width: 83px;">
                                        Actual Required<br /> <span style='color:gray;font-size:10px;position: relative;top:4px;'>Contract * Avg.</span>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle CssClass="Required_width" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td style="border-right: 0px;">
                                        Width
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
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
                                    <td  style="border-right: 0px;">
                                       
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
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td style="border-right: 0px;">
                                       <%-- Qty. left after issue complete--%>
                                       Stock Moved Qty Debit Qty
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
    </div>
    </form>
    <script type="text/javascript">

        $(document).ready(function () {
            debugger;
            var RowId = 0;
            var gvId;
            var GridRow = $(".FabricIssuedRow").length;

            for (var row = 1; row <= GridRow; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;


                var ContactNumberMaxVal = $("#grdfabric_" + gvId + "_hdnContactNumber").val();
                var ContactMaxLen = ContactNumberMaxVal.length;
                // alert(ContactNumberMaxVal);
                if (ContactMaxLen > 10) {
                    $(".TooltipVal span").text(function (index, currentText) {
                        var maxLength = $(this).parent().attr('data-maxlength');
                        // alert(maxLength);
                        if (currentText.length > maxLength) {
                            return currentText.substr(0, maxLength) + "...";
                        } else {
                            return currentText
                        }
                    });

                    $("#grdfabric_" + gvId + "_lblcontract").attr('data-title', ContactNumberMaxVal);

                }
            }
        });
    </script>
</body>
</html>
