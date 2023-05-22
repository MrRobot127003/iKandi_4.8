<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CuttingFormNew.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.CuttingFormNew" %>
<head>
    <link rel="stylesheet" href="style-screen.css" type="text/css" media="screen">
    <link rel="stylesheet" href="style-print.css" type="text/css" media="print">
</head>
<script type="text/javascript">



    var txtTotalMax;
    $(function () {
        // added by yaten
        //$(".loadingimage").hide();
        txtTotalMax = $('span.max-qty', '#main_content');
        var total = 0;
        for (var i = 0; i < txtTotalMax.length; i++) {
            total = parseInt(txtTotalMax[i].innerHTML) + parseInt(total);
        }
    });

    // added by yaten
        function PrintPDFCutting(Url, height, width) {
        //$.showprogress();
        $(".print").hide();
        $(".loadingimage").show();
        var url;
        var ht = parseInt($(document).height()) - 50;
        var wd = parseInt($(document).width()) - 100;
        if (height != '' && height != null) {
            ht = height;
        }
        if (width != '' && width != null) {
            wd = width;
        }

        if (Url == '' || Url == null) {
            url = window.location.pathname;        }

        else {
            url = Url;
        }



        if (url.indexOf('/') != 0)
            url = '/' + url;
        //  debugger;

        //alert(wd + " - " + ht);


        proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {
            if ($.trim(result) == '') {
                //$.hideprogress();
                jQuery.facebox("Some error occured on the server, please try again later.");
            }
            else {
                //$.hideprogress();

                window.open(result);
                $(".loadingimage").hide();
                $(".print").show();
            }
        });

        return false;

    }



    function Refresh() {
        $(".print").show();
        return false;
    }

    $(document).ready(function () {
        $(".tab").click(function () {
            $(this).addClass('activeback').siblings().removeClass('activeback');
        });
    });

    function PrintElem(elem) {
        //debugger;
        $("#secure_greyline").hide();
        $(".tabmain").hide();
        $(".containerwidth").css('width', 1270);

        window.print();
        $("#secure_greyline").show();
        $(".tabmain").show();
        $(".containerwidth").css('width', 1280);
    }        
</script>
<style type="text/css">
    .cfn td
    {
        border: 1px solid #999999;
        border-collapse: collapse;
        padding-left: 5px !important;
        padding:0px 0px;
        font-family: arial;
    }
    @page { size: landscape; }
    .cfn .cfn_style1
    {
        font-weight: bold;
        width: 258px;
        color: #3b5998;
        text-align: left;
        font-size: 12px;
        padding-left: 5px;
        text-transform: capitalize;
        font-family: arial;
    }
    
    .cfn .cfn_style2
    {
        color: #3b5998;
        width: 462px;
        text-align: center;
        font-size: 12px;
        text-transform: capitalize;
        font-weight: bold;
    }
    
    .cfn .cfn_style3
    {
        height: 39px;
        width: 258px;
        color: #0000ff;
        text-align: left;
        font-size: 12px;
    }
    
    .cfn .cfn_style4
    {
        width: 258px;
        text-align: left;
        font-size: 12px;
        text-transform: capitalize;
        font-weight: bold;
        color: #3b5998;
        padding-left: 5px;
    }
    
    .cfn .cfn_style5
    {
        height: 39px;
        width: 258px;
        color: #0000ff;
        text-align: left;
        font-size: 18px;
        font-family: arial;
    }
    
    .cfn .cfn_style6
    {
        height: 39px;
        width: 258px;
        color: #0000ff;
        text-align: center;
        font-size: 11px;
    }
    
    
    .cfn3
    {
        width: 510px;
        background-color: #ffffff;
       line-height: 15px;
    }
    
    .cfn_footer
    {
        background: #dddfe4 !important;
        border: 1px solid #b7b4b4 !important;
        color: #575759 !important;
        text-align: center;
        font-size: 15px !imporant;
        font-weight: 600;
        text-transform: capitalize;
        font-family: arial;
    }
    
    .cfn_footer td
    {
        padding: 5px 0px;
        width: 258px;
        background: #dddfe4 !important;
        border: 1px solid #b7b4b4 !important;
        color: #575759 !important;
        text-align: center;
        font-size: 18px !imporant;
        font-family: arial;
    }
    
    .borderbottom
    {
        border: 1px solid #999999;
        border-top: none;
        border-right: none;
        border-left: none;
    }
    
    .cfn .cfn_style7
    {
        height: 39px;
        width: 258px;
        color: #0000ff;
        text-align: left;
        font-size: 15px;
    }
    
    .header-bg
    {
    }
    .border2 th
    {
        padding: 10px 0px !important;
        text-align: center;
    }
    .font-18
    {
        font-size: 18px;
    }
    .print-box
    {
        background-color: #ffffff;
    }
    .IsShipped
    {
        background: #efe9e9;
    }
    .IsShipped td
    {
        color: #807F80 !important;
        vertical-align: top;
    }
    .IsShipped td.cfn3
    {
        background-color: #efe9e9 !important;
    }
    .IsShipped span span
    {
        color: #807F80 !important;
    }
    .borderbottom td
    {
        vertical-align: top;
    }
    .border-top
    {
        border-top: 1px solid #999999 !important;
        color: Black;
        height:15px;
        padding-top:7px;
    }
  IsShipped .border-top
    {
        border-top: 1px solid #807F80 !important;
    }
    .borderbottom table tr td, .IsShipped table tr td
    {
        border: 1px ;
    }
    .item_list1 TD
    {
        background-color: #ffffff08;
    }
   .textdecoa
    {
        text-decoration: none;
        color:#f8f8f8;
    }
    .costing-sheet{
        
    display: inline-block;
    background: #03A9F4;
    color: #f8f8f8;
      padding: 2px 10px;
    border-radius: 2px;
    font-family: arial;
        }
        .form_box 
        {  
            border: 0px solid #c3c3c3;
            text-transform: capitalize;
          }
         .main_heading
         {
             font-size: 15px;
            text-align: center;
            background: #e8e8e8;
            line-height: 28px;
            color: #3b5998;
            margin: 7px auto;
            width:1280px;;
            font-family: arial;
           text-transform: capitalize;
           }
           .tabmain
           {
               width:1280px;
               
            }
            .cutting_table th
            {
                    background: #dddfe4;
                    border: 1px solid #b7b4b4;
                    color: #585656 !important;
                    padding: 4px 0px;
                    text-align: center;
                    font-family: arial;
                    font-size: 13px !important;
                    font-weight: 500;
                   text-transform: capitalize;
             }
            .cutting_table th:nth-child(2)
            {
                font-size:11px !important
             }
               .cutting_table th:nth-child(1)
            {
                font-size:11px !important
             }
              .cutting_table td
            {
                   
                    border: 1px solid #b7b4b4;
                    color: #000;
                    padding: 2px 0px;
                    font-family: arial;
                    text-align:center;
                   height: 22px !important;
                  font-size: 11px;
                   text-transform: capitalize;
                   vertical-align: middle;
                   border-bottom: 3px solid #999999;
                
             }
             .min-kam-sekam
             {
                 font-size: 15px;
                font-weight: 600;
                color: #000;
                font-family: arial;
              }
              .min-kam-sekam-total
             {
                 font-size: 15px;
                font-weight: 600;
                color: #000;
                font-family: arial;
              }
              .activeback
              {
                 background:green !important; 
               }
               .print-box
               {
                   width:1280px;
                   margin:0px auto;
                 }
                 .radioheaderwidth
                 {
                     min-width:110px !important;
                    }
                   .cutting_table td input[type="checkbox"]
                    {
                        position:relative;
                        top:2px;
                        }
                        .cfn_footer span
                        {
                            font-size:15px !important;
                            font-weight:600;
                            color:#756767 !important;
                            }
                            .toppadding
                            {
                                height:15px;
                                padding-bottom:10px;
                              }
                              .form_box p
                              {
                                   font-family: arial;
                                   font-size:11px;
                                }
                          @-moz-document url-prefix() {
                                  .cfn_footer {
                                   width:100px !important;
                                  }
                                }
         .containerwidth
         {
             width:1280px;
           }
        .tab
        {
            position:relative;top:3px;
            width:4.5% !important;
         }                                
</style>
<link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
<div class="print-box" id="divprint">
    <div class="form_box">
        <div class="tabmain">
            <asp:Repeater ID="repeaterCuttingSheet" OnItemDataBound="repeaterCuttingSheet_ItemDataBound" runat="server">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnorderid" runat="server" Value='<%# Eval("OrderID") %>' />
                    <span id="spanid" runat="server" class="costing-sheet tab"><a id="costingTab" class="textdecoa" href='<%# "CuttingSheet.aspx?orderid=" + Convert.ToInt32(Eval("OrderID")) %>'>
                        <%# Convert.ToString(Eval("SerialNumber")).ToUpper()%></a> </span>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="containerwidth">
            <div class="main_heading">
                <strong>Cutting Form</strong>
            </div>
            <asp:PlaceHolder ID="pnlserialdetail" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0" class="cfn" align="center">
                    <tr>
                        <td class="cfn_style1" class="header-bg">
                            Serial No.
                        </td>
                        <td class="cfn_style5">
                            <asp:Label ID="lblSerial" runat="server" Text="Tes 032"></asp:Label>
                        </td>
                        <td align="center" class="cfn_style2" style="border-left: none; border-right: none;">
                            <asp:Label ID="lblComment" runat="server" Text="Comments"></asp:Label>
                        </td>
                        <td colspan="2" align="center" class="cfn_style2">
                            <asp:Label ID="lblProdctionArea" runat="server" Text="Production Working Area"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cfn_style4" style="border-top: none;">
                            Style Number
                        </td>
                        <td class="cfn_style3" style="border-top: none;">
                            <asp:Label ID="lblStyleNo" runat="server" Text="TP 74061 TP"></asp:Label>
                        </td>
                        <td rowspan="4" style="border-left: none; border-right: none; border-top: none;">
                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/pic1.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Image ID="img2" runat="server" ImageUrl="~/images/pic2.jpg" />
                            <asp:Image ID="img3" runat="server" Visible="false" />
                        </td>
                        <td class="cfn_style4" style="border-top: none;">
                            <asp:Label ID="lblPattern" runat="server" Text="PCD:"></asp:Label>
                        </td>
                        <td class="cfn_style7" style="border-top: none;">
                            <asp:Label ID="lblPCD1" Font-Bold="true" runat="server" Text="5 Mar 14(Tue)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cfn_style4" style="border-top: none;">
                            Buyer
                        </td>
                        <td class="cfn_style5" style="border-top: none;">
                            <asp:Label ID="lblBuyer" runat="server" Text="TESCO:"></asp:Label>
                        </td>
                        <td class="cfn_style4" style="border-top: none;">
                            <asp:Label ID="lblProdFile" runat="server" Text="Pattern Sample and Production File: "></asp:Label>
                        </td>
                        <td class="cfn_style7" style="border-top: none;" align="left">
                            <asp:Label ID="lblProdctionFile" runat="server" Text="7 Mar 14(Thu)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cfn_style4" style="border-top: none;">
                            Department
                        </td>
                        <td class="cfn_style3" style="border-top: none;">
                            <asp:Label ID="lblDepartment" runat="server" Text="Soft"></asp:Label>
                        </td>
                        <td class="cfn_style4" style="border-top: none;">
                            <asp:Label ID="lblStiched" runat="server" Text="Stitched Start Date:"></asp:Label>
                        </td>
                        <td class="cfn_style7" style="border-top: none;">
                            <asp:Label ID="lblStichedDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cfn_style4" style="border-top: none; border-bottom: 1px solid #999999;">
                            Date Of Issue
                        </td>
                        <td class="cfn_style3" style="border-top: none;">
                            <asp:Label ID="lblIssueDate" runat="server" Text="29 oct 14(Wed)"></asp:Label>
                        </td>
                        <td class="cfn_style4" style="border-top: none;">
                            <asp:Label ID="lblOrder" runat="server" Text="Order Quantity:"></asp:Label>
                        </td>
                        <td class="cfn_style7" style="border-top: none;">
                            <asp:Label ID="lblOrderQty" runat="server" Text="5 Mar 14(Tue)"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" class="cutting_table firsttable" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td style="padding-top: 10px !important; border: 0px;" id="td1" runat="server" visible="false">
                            <asp:GridView ID="grdCuttingOption1" runat="server" AutoGenerateColumns="false" ShowFooter="true" Width="100%" OnRowDataBound="grdCuttingOption1_RowDataBound" RowStyle-CssClass="borderbottom" CssClass="cfn2 cutting_table" OnSelectedIndexChanged="grdCuttingOption1_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print/Color (Cut Avg.)" HeaderStyle-Font-Size="9px" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails1" Style="font-size: 11px;" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId1" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric1" Style="font-size: 11px;" runat="server" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

 

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

 

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric1" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

 

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric1" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code <br>Cont no." ItemStyle-CssClass="cfn3" HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="10px">
                                        <ItemTemplate>
                                            <div id="exFactory1" runat="server">
                                                <asp:Label ID="lblexFactory1" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label></div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                        <ItemTemplate>
                                            <div style="color: Black; min-width: 110px; height: 15px" class="toppadding">
                                                MIN (कम से कम)
                                            </div>
                                            <div class="border-top" style="color: Black">
                                                MAX (ज्यादा से ज्यादा)
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal1" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize1" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblMaxSize1" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" runat="server" Font-Size="18px"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize2" runat="server" CssClass="min-kam-sekam"></asp:Label>
                                                <asp:HiddenField ID="hndSize2" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblMaxSize2" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize3" runat="server" CssClass="min-kam-sekam"></asp:Label>
                                                <asp:HiddenField ID="hndSize3" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize3" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize4" runat="server" CssClass="min-kam-sekam"></asp:Label>
                                                <asp:HiddenField ID="hndSize4" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize4" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize5" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize5" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize6" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize6" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize7" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize7" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize8" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize8" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize9" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize9" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize10" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize10" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize11" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize11" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" runat="server" Style="font-size: 15px;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hndSize12" runat="server" />
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize12" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" runat="server" Font-Size="15px"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblMaxSize13" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize14" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxSize15" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblMinTotal1" CssClass="min-kam-sekam-total" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblMaxTotal1" Style="font-size: 11px;" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td2" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttinOption2" runat="server" AutoGenerateColumns="false" ShowFooter="true" Width="100%" OnRowDataBound="grdCuttinOption2_RowDataBound" CssClass="cutting_table">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails2" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId2" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric2" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric2" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric2" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric2" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric2" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric2" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code <br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory2" runat="server">
                                                <asp:Label ID="lblexFactory2" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                        <ItemTemplate>
                                            <div style="min-width: 110px">
                                                MIN (कम से कम)</div>
                                            <div class="border-top" style="color: Black;">
                                                MAX (ज्यादा से ज्यादा)
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal2" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP2MaxSize1" runat="server"></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped2" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" runat="server" Font-Size="18px"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize2" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" runat="server" Font-Size="18px"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize3" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" runat="server" Font-Size="18px"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize4" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize5" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize6" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize7" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize8" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize9" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize10" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize11" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize12" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize13" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP2MaxSize14" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP2MaxSize15" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP2MinTotal1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP2MaxTotal1" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td3" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption3" runat="server" AutoGenerateColumns="false" ShowFooter="true" class="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption3_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails3" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId3" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric3" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric3" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric3" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric3" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric3" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric3" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory3" runat="server">
                                                <asp:Label ID="lblexFactory3" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>" ,Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                        <ItemTemplate>
                                            <div style="min-width: 110px; height: 15px">
                                                MIN (कम से कम)
                                            </div>
                                            <div class="border-top">
                                                MAX (ज्यादा से ज्यादा)
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal3" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize1" runat="server"></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped3" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize2" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize3" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize4" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize5" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize6" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize7" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize8" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize9" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize10" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize11" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize12" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize13" Font-Size="18px" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP3MaxSize13" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP3MaxSize14" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP3MaxSize15" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP3MinTotal1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP3MaxTotal1" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td4" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption4" runat="server" AutoGenerateColumns="false" ShowFooter="true" class="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption4_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails4" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId4" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric4" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric4" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric4" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric4" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric4" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric4" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory4" runat="server">
                                                <asp:Label ID="lblExFactory4" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="min-width: 110px">
                                                MIN (कम से कम)
                                            </div>
                                            <div class="border-top">
                                                MAX (ज्यादा से ज्यादा)
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal4" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize1" runat="server"></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped4" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize2" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize3" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize4" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize5" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize6" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize7" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize8" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize9" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize10" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize11" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize12" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP4MaxSize13" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP4MaxSize14" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP4MaxSize15" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP4MinTotal1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP4MaxTotal1" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td5" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption5" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption5_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails5" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId5" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric5" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric5" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric5" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric5" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric5" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric5" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory5" runat="server">
                                                <asp:Label ID="lblExFactory4" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="color: Black; min-width: 110px">
                                                MIN (कम से कम)
                                            </div>
                                            <div class="border-top" style="color: Black;">
                                                MAX (ज्यादा से ज्यादा)
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal5" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize1" runat="server"></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped5" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize2" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize3" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize4" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize5" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize6" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize7" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize8" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize9" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize10" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize11" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize12" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP5MaxSize13" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP5MaxSize14" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="220px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP5MaxSize15" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP5MinTotal1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP5MaxTotal1" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td6" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption6" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption6_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" HeaderStyle-Width="200">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails6" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId6" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric6" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric6" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric6" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric6" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric6" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric6" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory6" runat="server">
                                                <asp:Label ID="lblExFactory4" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                        <ItemTemplate>
                                            <div style="color: Black; min-width: 110px">
                                                MIN (कम से कम)
                                            </div>
                                            <div class="border-top" style="color: Black;">
                                                MAX (ज्यादा से ज्यादा)
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal6" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize1" runat="server"></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped6" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize2" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize3" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize4" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize5" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize6" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize7" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;
                                                <asp:Label ID="lblOP6MaxSize8" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP6MaxSize9" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP6MaxSize10" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP6MaxSize11" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP6MaxSize12" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                <asp:Label ID="lblOP6MaxSize13" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP6MaxSize14" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP6MaxSize15" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div class="toppadding">
                                                <asp:Label ID="lblOP6MinTotal1" CssClass="min-kam-sekam-total" runat="server"></asp:Label>
                                            </div>
                                            <div class="border-top">
                                                &nbsp;<asp:Label ID="lblOP6MaxTotal1" runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td7" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption7" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption7_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails7" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId7" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric7" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric7" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric7" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric7" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric7" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric7" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory7" runat="server">
                                                <asp:Label ID="lblExFactory7" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal7" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped7" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize2" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize3" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize4" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize5" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize6" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP7MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP7MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7Minsize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP7MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP7MinTotal1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP7MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td8" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption8" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption8_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails8" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId8" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric8" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric8" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric8" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric8" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric8" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric8" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory8" runat="server">
                                                <asp:Label ID="lblExFactory8" Width="100%" Style="font-size: 11px;" runat="server" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal8" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize1" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped8" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize2" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize3" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize4" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize5" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize6" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize7" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize8" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize9" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize10" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize11" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize12" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize13" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP8MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize14" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP8MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8Minsize15" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP8MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP8MinTotal1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP8MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td9" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption9" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption9_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails9" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId9" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric9" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric9" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric9" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric9" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric9" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric9" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no. <br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory9" runat="server">
                                                <asp:Label ID="lblExFactory9" Width="100%" Style="font-size: 11px;" runat="server" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal9" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize1" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped9" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize2" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize3" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize4" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize5" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize6" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize7" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize8" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize9" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize10" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize11" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize12" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize13" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP9MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize14" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP9MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9Minsize15" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP9MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP9MinTotal1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP9MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td10" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption10" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption10_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails10" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId10" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric10" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric10" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric10" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric10" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric10" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric10" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no. <br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory10" runat="server">
                                                <asp:Label ID="lblExFactory10" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black; height: 15px;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal10" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped10" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP10MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP10MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10Minsize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP10MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP10MinTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP10MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td11" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption11" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption11_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails11" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId11" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric11" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric11" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric11" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric11" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric11" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric11" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory11" runat="server">
                                                <asp:Label ID="lblExFactory11" Width="100%" Style="font-size: 11px;" runat="server" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal11" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize1" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped11" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize2" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize3" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize4" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize5" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize6" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize7" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize8" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize9" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize10" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize11" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize12" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize13" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP11MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize14" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP11MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11Minsize15" Font-Size="18px" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP11MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP11MinTotal1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP11MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td12" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption12" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption12_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails12" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId12" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric12" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric12" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric12" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric12" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric12" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric12" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory12" runat="server">
                                                <asp:Label ID="lblExFactory12" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal12" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped12" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="toppadding">
                                                            <asp:Label ID="lblOP12Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="toppadding">
                                                            <asp:Label ID="lblOP12Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="toppadding">
                                                            <asp:Label ID="lblOP12Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="toppadding">
                                                            <asp:Label ID="lblOP12Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="toppadding">
                                                            <asp:Label ID="lblOP12Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP12MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP12MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP12MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="toppadding">
                                                            <asp:Label ID="lblOP12Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP12MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP12MinTotal1" CssClass="min-kam-sekam-total" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP12MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td13" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption13" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption13_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails13" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId13" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric13" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric13" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric13" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric13" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric13" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric13" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory13" runat="server">
                                                <asp:Label ID="lblExFactory13" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal13" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped13" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize2" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize3" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize4" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize5" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize6" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP13MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP13MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP13MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13Minsize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP13MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP13MinTotal1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP13MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td14" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption14" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption14_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails14" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId14" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric14" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric14" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric14" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric14" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric14" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric14" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory14" runat="server">
                                                <asp:Label ID="lblExFactory14" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal14" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped14" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize2" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize3" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize4" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize4" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize5" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize5" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize6" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize6" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize7" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize8" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize9" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize10" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize11" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP14MaxSize12" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP14MaxSize13" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP14MaxSize14" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14Minsize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP14MaxSize15" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP14MinTotal1" Style="font-size: 18px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP14MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td15" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption15" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption15_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails15" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId15" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric15" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric15" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric15" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric15" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric15" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric15" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory15" runat="server">
                                                <asp:Label ID="lblExFactory15" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal15" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize1" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped15" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="15px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize2" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize3" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize4" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize5" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize6" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize7" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize8" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize9" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize10" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize11" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP15MaxSize12" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP15MaxSize13" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP15MaxSize14" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP15MaxSize15" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP15MinTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP15MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td16" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption16" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption16_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails16" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId16" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric16" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric16" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric16" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric15" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric15" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric15" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory16" runat="server">
                                                <asp:Label ID="lblExFactory16" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal16" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize1" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped16" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize2" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize3" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize4" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize5" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize6" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize7" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize8" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize9" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize10" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize11" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP16MaxSize12" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP16MaxSize13" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP16MaxSize14" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP16MaxSize15" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP16MinTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP16MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--     <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px"
                                                                ItemStyle-Width="70px" FooterStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <div style="padding: 0 !important;">
                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblOP16Minsize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="border-top">
                                                                                    &nbsp;<asp:Label ID="lblOP16MaxSize15" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                                <FooterStyle CssClass="cfn_footer" />
                                                            </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td17" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption17" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption17_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails17" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId17" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric17" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric17" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric17" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric15" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric15" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric15" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory16" runat="server">
                                                <asp:Label ID="lblExFactory17" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal17" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize1" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped17" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize2" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize3" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize4" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize5" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize6" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize7" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize8" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize9" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize10" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize11" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP17MaxSize12" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP17MaxSize13" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP17MaxSize14" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP17MaxSize15" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP17MinTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP17MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td18" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption18" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption18_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails18" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId18" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric18" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric18" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric18" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fabric2Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblSecFabric15" runat="server" Text='<%#Eval("Fabric2Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric3Details<br/>(Cut Avg.)" HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblthirdFabric15" runat="server" Text='<%#Eval("Fabric3Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>

<asp:TemplateField HeaderText="Fabric4Details<br/>(Cut Avg.)" ItemStyle-CssClass="borderbottom"  HeaderStyle-Font-Size="9px">

<ItemTemplate>

<asp:Label ID="lblfourthFabric15" runat="server" Text='<%#Eval("Fabric4Details")%>' ></asp:Label>

 

</ItemTemplate>

<FooterTemplate>

 

</FooterTemplate>

<FooterStyle CssClass="cfn_footer" Font-Size="18px" Height="52px" />

</asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory16" runat="server">
                                                <asp:Label ID="lblExFactory18" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal18" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize1" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped18" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="18px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize2" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize3" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize4" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize5" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize6" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize7" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize8" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize9" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize10" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize11" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP18MaxSize12" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP18MaxSize13" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP18MaxSize14" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP18MaxSize15" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP18MinTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP18MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px"
                                                                ItemStyle-Width="70px" FooterStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <div style="padding: 0 !important;">
                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblOP18Minsize16" Style="font-size: 18px;" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="border-top">
                                                                                    &nbsp;<asp:Label ID="lblOP18MaxSize16" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblTotalSize15" Style="font-size: 18px;" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                                <FooterStyle CssClass="cfn_footer" />
                                                            </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="td19" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption19" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption19_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails19" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId19" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric19" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric19" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric19" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory16" runat="server">
                                                <asp:Label ID="lblExFactory19" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal19" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize1" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped19" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="19px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize2" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize3" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize4" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize5" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize6" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize7" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize8" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize9" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize10" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize11" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP19MaxSize12" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP19MaxSize13" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP19MaxSize14" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP19MaxSize15" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP19MinTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP19MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>

                    <tr id="td20" runat="server" visible="false">
                        <td style="padding-top: 10px !important; border: 0px;">
                            <asp:GridView ID="grdCuttingOption20" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="cutting_table" RowStyle-CssClass="borderbottom" Width="100%" OnRowDataBound="grdCuttingOption20_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fabric Name <br/> Print Description (Cut Avg.)" HeaderStyle-Font-Size="9px" ItemStyle-CssClass="borderbottom" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFabDetails20" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric1Details")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnOdId20" runat="server" Value='<%#Eval("OrderDetailId") %>' />
                                            <asp:Label ID="lblSecFabric20" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric2Details")%>'></asp:Label>
                                            <asp:Label ID="lblthirdFabric20" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric3Details")%>'></asp:Label>
                                            <asp:Label ID="lblfourthFabric20" runat="server" Style="font-size: 11px;" Text='<%#Eval("Fabric4Details")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EX F DT.<br/> Line no.<br>Country Code<br> Cont no." HeaderStyle-Font-Size="9px" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-CssClass="cfn3">
                                        <ItemTemplate>
                                            <div id="exFactory16" runat="server">
                                                <asp:Label ID="lblExFactory20" Width="100%" Style="font-size: 11px;" runat="server" Text='<%# String.Format("{0} {1} {2} {3}", Eval("ExFactory"), Eval("LineItemNumber"), "<b>("+Eval("CountryCode")+")</b>", Eval("ContractNumber")) %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ratios" ItemStyle-Width="100px" HeaderStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="min-width: 110px !important;">
                                                    <tr>
                                                        <td style="color: Black;">
                                                            MIN (कम से कम)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top" style="color: Black;">
                                                            MAX (ज्यादा से ज्यादा)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblContractSizeTotal20" runat="server" Text="Total"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize1" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize1" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:HiddenField ID="hdnIsshipped20" runat="server" Value="" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize1" Font-Size="19px" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize2" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize2" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize2" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize3" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize3" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize3" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize4" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize4" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize4" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize5" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize5" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize5" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize6" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize6" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize6" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize7" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize7" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize7" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize8" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize8" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize8" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize9" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize9" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize9" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize10" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize10" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize10" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize11" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize11" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize11" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize12" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;
                                                            <asp:Label ID="lblOP20MaxSize12" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize12" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize13" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP20MaxSize13" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize13" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize14" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP20MaxSize14" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize14" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" HeaderStyle-Font-Size="15px" HeaderStyle-Width="70px" ItemStyle-Width="70px" FooterStyle-Width="70px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20Minsize15" CssClass="min-kam-sekam" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP20MaxSize15" Style="font-size: 11px;" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSize15" Style="font-size: 19px;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-Width="100px" ItemStyle-Width="100px" FooterStyle-Width="100px">
                                        <ItemTemplate>
                                            <div style="padding: 0 !important;">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblOP20MinTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="border-top">
                                                            &nbsp;<asp:Label ID="lblOP20MaxTotal1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="cfn_footer" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <%-- <tr>
                    <td>--%>
                    <!--

                        <div style="width: 30%; float: left">

                            Fabric Head

                            <asp:CheckBox ID="chkboxFabricHead" runat="server"  />

                            <asp:HiddenField ID="hiddenFab" runat=server />

                        </div>

                        <div style="width: 20%; float: right">

                            Production Head

                            <asp:CheckBox ID="chkboxProductionHead" runat="server"  />

                            <asp:HiddenField ID="hiddenProd" runat=server />

                        </div>

                        -->
                    <%--   </td>
                </tr>--%>
                    <%-- <tr>
                    <td style="text-align: left; padding-left: 5px !important">
                        n.b.: after sealing if the avg. changes upon verification with the cad system the
                        account merchant needs to get this corrected with the fabric department where both
                        confirm the change and resultant reduction or increase in fabric order on email
                        addressed to the management and the account merchants. the cutting sheet should
                        then be handed over to the production head with his signature.
                    </td>--%>
                    <%-- <td colspan="4">

                       <asp:Label ID="lblFabric1" Visible="false" runat="server"></asp:Label>

                        <asp:Label ID="lblFabric2" Visible="false" runat="server"></asp:Label>

                         <asp:Label ID="lblFabric3" Visible="false" runat="server"></asp:Label>

                          <asp:Label ID="lblFabric4" Visible="false" runat="server"></asp:Label>

                               <asp:Label ID="lblCutAvg1" Visible="false" runat="server"></asp:Label>

                        <asp:Label ID="lblCutAvg2" Visible="false" runat="server"></asp:Label>

                         <asp:Label ID="lblCutAvg3" Visible="false" runat="server"></asp:Label>

                          <asp:Label ID="lblCutAvg4" Visible="false" runat="server"></asp:Label>

                    </td>--%>
                    <%--</tr>--%>
                    </tbody>
                </table>
                <div style="width: 40%; text-align: left; padding-left: 5px !important; font-size: 11px;">
                    Account Manager
                    <asp:CheckBox ID="chkboxMerchant" runat="server" />
                    <asp:HiddenField ID="hiddenAccount" runat="server" />
                </div>
                <div>
                    <p>
                        n.b.: after sealing if the avg. changes upon verification with the cad system the account merchant needs to get this corrected with the fabric department where both confirm the change and resultant reduction or increase in fabric order on email addressed to the management and the account merchants. the cutting sheet should then be handed over to the production head with his signature.
                    </p>
                </div>
        </div>
    </div>
</div>
<div style="width: 1280px; margin: 0 auto;">
    <%-- <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
        runat="server" />--%>
    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" CssClass="submit" />
    <input type="button" id="btnPrint" class="print da_submit_button" value="Print" onclick="PrintElem(this)" />
    </asp:PlaceHolder>
</div>
