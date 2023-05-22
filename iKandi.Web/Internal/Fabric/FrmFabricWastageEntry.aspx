<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmFabricWastageEntry.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FrmFabricWastageEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script src="../../js/service.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script src="../../CommonJquery/ToolTip_plugin/js/tooltipster.bundle.min.js" type="text/javascript"></script>
    <link href="../../CommonJquery/ToolTip_plugin/css/tooltipster.bundle.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: arial !important;
        }
        .color_black
        {
            color: Black;
        }
        .gray
        {
            color: gray;
        }
        .HeaderClass td
        {
            background: #dddfe4;
            font-weight: 500;
            color: #575759;
            font-family: arial;
            font-size: 11px;
            padding: 4px 1px;
            border-color: #999;
        }
        /*  th
        {
            position:sticky;
            top:50px;
            z-index:10;
            
         }
        .HeaderClass1 th
        {
            position:sticky;
            top:0px !important;
            z-index:10;
         }*/
        .HeaderClass1 td
        {
            background: #dddfe4;
            font-weight: bold;
            color: #575759;
            font-family: arial;
            font-size: 11px;
            padding: 5px 0px;
            border-color: #999;
        }
        
        .btnbutton
        {
            background: rgb(19, 167, 71);
            color: #fff;
            border: 1px solid green;
            padding: 3px 8px;
            border-radius: 2px;
            font-size: 11px;
            font-family: Arial;
            cursor: pointer;
            margin-top: 10px;
            float: left;
            margin-right: 5px;
            margin-left: 3px;
        }
        .btnbutton:hover
        {
            color: Yellow;
        }
        .btnClose
        {
            background: rgb(19, 167, 71);
            color: #fff;
            border: 1px solid green;
            padding: 3px 8px;
            border-radius: 2px;
            font-size: 11px;
            font-family: Arial;
            cursor: pointer;
            margin-top: 10px;
            width: 40px;
            float: left;
            text-align: center;
        }
        .btnClose:hover
        {
            color: Red;
        }
        .AddClass_Table input[type='text']
        {
            text-align: center !important;
        }
        .AddClass_Table
        {
            /* margin-top: 101px;*/
        }
        .AddClass_Table td
        {
            text-align: center;
            padding: 1px 0px 5px 1px;
            line-height: 14px;
        }
        .minWidthH_Name
        {
            width: 100px;
        }
        .minWidth_Name
        {
            width: 145px;
        }
        .minWidthH_100
        {
            width: 99px;
        }
        .minWidthH_40
        {
            width: 90px;
        }
        .minWidth_100
        {
            width: 130px;
        }
        .minWidth_40
        {
            width: 80px;
        }
        .Stage1_Wastagetextbox
        {
                width:24px!important;
            }
        .border_last_bottom_color
        {
            border-bottom-color: #999 !important;
        }
        .AddClass_Table td input[type="text"]
        {
            width: 50px;
            padding: 0px 0px;
            height: 15px;
            margin: 1px 0px;
            background: transparent;
            border-color: transparent !important;
        }
        
        th.HeaderClass1
        {
            background: #3b5998 !important;
            color: #fff !important;
            font-size: 14px !important;
            font-weight: 500;
        }
        
        .WastagePupopTable
        {
            border-collapse: collapse;   
        }
        .WastagePupopTable th
        {
            background: #dddfe4;
            font-weight: 500;
            color: gray;
            font-family: arial;
            font-size: 11px;
            padding: 4px 2px;
            box-sizing: border-box;
            border-color: #999;
            border: 1px solid #999;
        }
        .CutQtyWidth_Name
        {
            width: 104px;
        }
        .CutQtyWidth_Name1
        {
           width: 110px;
            }
        .CutQtyWidth_Name2
        {
           width: 98px;
           text-align:left;
            }
        .stage1qty
        {
        text-align: left;
        padding-left: 10px;
        box-sizing: border-box;
            }
        .HeaderQtyWidth_40
        {
            width: 80px;
        }
        .HeaderWastWidth_40
        {
            width: 80px;
        }
        .Width_Name
        {
            width: 130px;
            height:30px;
        }
        .WastShrnkWidth_Name
        {
            width: 80px;
        }
        .shadowwidth
        {
            width: 80px;
        }
        #sb-wrapper
        {
            width: 80px !important;
        }
        .HeaderClass1
        {
            position: relative;
             text-align: center;
        }
        .ColorPrintFabQuality
        {
            font-size: 11px;
            color: Blue;
        }
        
        
        .AddClass_Table tr:nth-child(odd)
        {
            background-color: #dedede;
        }
        
        td[rowspan]
        {
            background: #fff;
        }
        
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-track
        {
            box-shadow: inset 0 0 5px grey;
            border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb
        {
            background: #bdbbbb;
            border-radius: 10px;
        }
        ::-webkit-scrollbar-thumb:hover
        {
            background: #969191;
        }
        .WastagePupopTable, #grdwastage
        {
            min-width: 800px;
            
        }
         .stage1cutqty
         {
             padding-left: 5px!important;
             box-sizing: border-box;
         }
         .stage1qty,.stage1cutqty,.border-right_0
         {
             border-right-color:transparent!important;
         }
         
   
   .span_class {
    visibility: hidden;
    width: max-content;
    background-color: #A5E5FF;
    position: absolute;
    top: -72%;
    left: 52%;
    padding: 5px;
    z-index: 999999;
    color: #605f5f;
    border-radius: 4px;
    border: 2px solid gray;
    transition: visible 0.5s ease;
    box-shadow: 0px 2px 3px white;
    transform: translate(-50%, -70%);
       
        }
  .custom_titleclass:hover +  .span_class{
         visibility: visible;
    }
    
  .span_class:after
      {
        content: '';
        position: absolute;
        left: 42%;
        top: 100%;
        width: 0;
        height: 0;
        border-left: 10px solid transparent;
        border-right: 10px solid transparent;
        border-top: 10px solid #A5E5FF;
      }
   .style_fortooltip
       {
       position:relative;
      }
 #divh
 {
            position: sticky;
            -moz-position: sticky;
            -o-position: sticky;
            -webkit -position: sticky;
            top: 0px;
            z-index: 999999;
     }
  .table_css
        {
            border:1px solid gray;
            border-collapse:collapse;
            }  
  .table_css th
        {
            border:1px solid gray;
            padding:3px;
        }
 .table_css tr
        {
            border:1px solid gray;
            padding:3px;
            }  
 .table_css tr td
        {
            border:1px solid gray;
            padding:3px;
            } 
            
    </style>
</head>
<body>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.tooltip').tooltipster({
                contentAsHTML: true,
                interactive: true,
                theme: 'my-custom-theme'
            });
            $(':input').live('focus', function () {
                $(this).attr('autocomplete', 'off');
            });
            $('.number').keypress(function (event) {
                var $this = $(this);
                if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
       ((event.which < 48 || event.which > 57) &&
       (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();
                if ((event.which == 46) && (text.indexOf('.') == -1)) {
                    setTimeout(function () {
                        if ($this.val().substring($this.val().indexOf('.')).length > 3) {
                            $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
                        }
                    }, 1);
                }

                if ((text.indexOf('.') != -1) &&
        (text.substring(text.indexOf('.')).length > 2) &&
        (event.which != 0 && event.which != 8) &&
        ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });

            $('.number').bind("paste", function (e) {
                var text = e.originalEvent.clipboardData.getData('Text');
                if ($.isNumeric(text)) {
                    if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
                        e.preventDefault();
                        $(this).val(text.substring(0, text.indexOf('.') + 3));
                    }
                }
                else {
                    e.preventDefault();
                }
            });

            $('input[type=text]').on("cut copy paste", function (e) {
                e.preventDefault();
            });
            var elmnt = document.getElementById("grdwastage");

            window.parent.Setwidthwastagescreen(parseInt(elmnt.offsetWidth) + 27, parseInt(elmnt.offsetHeight) + 30);

            if ($('#IsOnlyStage1').val() == "Yes") {
                $('.stage1serial').css("min-width", 104);
                $('.stage1qty').css("min-width", 104);
                $('.stage1cutqty').css("min-width", 104);
                $('.stage1cutqtytotal').css("min-width", 104);
                $('.stage1name').css("min-width", 129);
                $('.Shrinkageeee').css("min-width", 80);
                $('.stage2width').css("width", 0);
                $('.stage2width').css("border-right", "1px solid transparent");
                $('.stage1cutwastage').css("min-width", 79);
                $('.stage1requiredqty').css("min-width", 77);
            }
            if ($('#isUptoStage2').val() == "Yes") {
                $('.stage1serial').css("width", 77);
                $('.stage1qty').css("width", 81);
                $('.stage1cutqty').css("width", 82);
                $('.stage1cutqtytotal').css("width", 75);
                $('.stage1name').css("width", 95);
                $('.Shrinkageeee').css("width", 69);
                $('.stage2width1').css("width", 93);
                $('.stage2width').css("width", 0);
                $('.stage2width').css("border-right", "1px solid transparent");
                $('.stage1cutwastage').css("width", 65);
                $('.stage1requiredqty').css("width", 66);
            }



        });
        function CallBackParentPage() {

            window.parent.callparentpage();
            window.parent.Shadowbox.close();
        }
        function CloseCurrentTab() {
            window.close();
        }

        $(document).ready(function () {
            var FabmaxRow = 0;
            var FabrowSpan = 0;
            $('.borderbottom td[rowspan].FabFirstStage1').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > FabmaxRow) {
                    FabmaxRow = row;
                    FabrowSpan = 0;
                }
                if ($(this).attr('rowspan') > FabrowSpan) FabrowSpan = $(this).attr('rowspan');
            });
            if (FabmaxRow == $('.borderbottom tr:last td').parent().parent().children().index($('.borderbottom tr:last td').parent()) - (FabrowSpan - 1)) {
                $('.borderbottom td[rowspan].FabFirstStage1').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == FabmaxRow && $(this).attr('rowspan') == FabrowSpan) $(this).addClass('border_last_bottom_color');
                });
            }

            var FabmaxRow2 = 0;
            var FabrowSpan2 = 0;
            $('.borderbottom td[rowspan].FabFirstStage2').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > FabmaxRow2) {
                    FabmaxRow2 = row;
                    FabrowSpan2 = 0;
                }
                if ($(this).attr('rowspan') > FabrowSpan2) FabrowSpan2 = $(this).attr('rowspan');
            });
            if (FabmaxRow == $('.borderbottom tr:last td').parent().parent().children().index($('.borderbottom tr:last td').parent()) - (FabrowSpan2 - 1)) {
                $('.borderbottom td[rowspan].FabFirstStage2').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == FabmaxRow2 && $(this).attr('rowspan') == FabrowSpan2) $(this).addClass('border_last_bottom_color');
                });
            }

            var FabmaxRow3 = 0;
            var FabrowSpan3 = 0;
            $('.borderbottom td[rowspan].FabFirstStage3').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > FabmaxRow3) {
                    FabmaxRow3 = row;
                    FabrowSpan3 = 0;
                }
                if ($(this).attr('rowspan') > FabrowSpan3) FabrowSpan3 = $(this).attr('rowspan');
            });
            if (FabmaxRow == $('.borderbottom tr:last td').parent().parent().children().index($('.borderbottom tr:last td').parent()) - (FabrowSpan3 - 1)) {
                $('.borderbottom td[rowspan].FabFirstStage3').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == FabmaxRow3 && $(this).attr('rowspan') == FabrowSpan3) $(this).addClass('border_last_bottom_color');
                });
            }
        })

        var input = document.getElementsByClassName("Stage1_Wastagetextbox");

        input.addEventListener("input", function () {
            setInputWidth(input);
        });

        function setInputWidth(input) {


            // Get the width of the text inside the input box
            var width = input.value.length * 8;

            // Set the width of the input box to the width of the text
            input.style.width = width + "px";
        }      
 
       
    </script>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hdndynamicwidht" runat="server" Value="0" />
        <asp:HiddenField ID="IsOnlyStage1" runat="server" Value="0" />
        <asp:HiddenField ID="isUptoStage2" runat="server" Value="0" />
        <asp:HiddenField ID="isUptoStage3" runat="server" Value="0" />
        <div style="position: absolute; top: 50px; display: none;">
            <asp:Label ID="lblFabricQuality" ForeColor="White" CssClass="color_black classfabsave"
                Text='<%# Eval("TradeName")%>' runat="server"></asp:Label>
            <asp:Label ID="lblgsm" CssClass="gray" ForeColor="White" Text='<%# Eval("GSM")%>'
                runat="server"></asp:Label>
            <asp:Label ID="lblcountconstraction" ForeColor="White" CssClass="gray" Text='<%# Eval("CountConstruction").ToString()%>'
                runat="server"></asp:Label>
            <asp:Label ID="lblwidth" CssClass="gray" ForeColor="White" Text='<%# Eval("width").ToString()+"&quot" %>'
                runat="server"></asp:Label>
            <asp:Label ID="lblcolor" CssClass="color_black" Font-Bold="true" ForeColor="White"
                runat="server" Text='<%# Eval("FabricDetails").ToString() %>'></asp:Label>
        </div>
        <div id="divh" runat="server">
        </div>
        <asp:GridView ID="grdwastage" CssClass="AddClass_Table borderbottom" runat="server"
            AutoGenerateColumns="False" ShowHeader="false" HeaderStyle-Font-Names="Arial"
            ShowFooter="true" HeaderStyle-HorizontalAlign="Center" BorderWidth="1" rules="all"
            HeaderStyle-CssClass="ths" OnRowDataBound="grdwastage_RowDataBound" OnDataBound="grdwastage_DataBound">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <RowStyle CssClass="RowCountPri" />
            <FooterStyle Height="33px" BackColor="#efeded" Font-Bold="true" CssClass="ddd" />
            <Columns>
                <asp:TemplateField HeaderText="Serial No.">
                    <ItemStyle CssClass="textLeft FabFirstColP stage1serial" Width="78" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%# Eval("SerialNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contract Qty">
                    <ItemStyle CssClass="textLeft FabFirstColP stage1qty" Width="83" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <FooterStyle BorderColor="transparent" />
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("ContractQty")).ToString("N0")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Average">
                    <ItemStyle CssClass="textLeft FabFirstColP stage1cutqty" Width="82" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <FooterStyle BorderColor="transparent" />
                    <ItemTemplate>
                        <span style="position: relative; top: 2px; color: Gray; float: left;">*</span> <span>
                            <%# (Eval("FabricAvg") == DBNull.Value || (Eval("FabricAvg").ToString().Trim() == string.Empty)) ? string.Empty : Eval("FabricAvg").ToString() %></span>
                        <span style="color: Gray; margin-left: 5px;">=</span>
                    </ItemTemplate>
                    <FooterTemplate>
                        <span class="stage1total" style="color: Gray;">Total</span>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Qty">
                    <ItemStyle CssClass="textLeft FabFirstColP stage1cutqtytotal" Width="78" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblquantity" ForeColor="blue" CssClass="color_black custom_titleclass"
                            Text='<%# (Eval("ContractQty") == DBNull.Value || (Eval("ContractQty").ToString().Trim() == string.Empty)) ? string.Empty : (Convert.ToInt32((Eval("ContractQty"))).ToString("N0"))%>'
                            runat="server"> 
                        </asp:Label>
                        <span class="span_class" runat="server" id="spn_Rev" style=""></span><span style="color: Gray;"
                            runat="server" id="span_UnitName">
                            <%# Eval("UnitName")%></span>
                        <asp:Label ID="lblunitname" ForeColor="Gray" Font-Bold="true" runat="server" Visible="false"></asp:Label>
                        <asp:HiddenField ID="hdnorderdetailsID" runat="server" Value='<%# Eval("OrderDetailsID")%>' />
                        <asp:HiddenField ID="hdnavg" runat="server" Value='<%# Eval("FabricAvg")%>' />
                        <asp:HiddenField ID="hdnFabricQualiltyID" runat="server" Value='<%# Eval("Fabric_Quality_DetailsID")%>' />
                        <asp:HiddenField ID="hdnFabricdetails" runat="server" Value='<%# Eval("FabricDetails")%>' />
                        <asp:HiddenField ID="hdnfourpointpassqty" runat="server" Value='<%# Eval("fpointpassqty")%>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="style_fortooltip" />
                    <FooterTemplate>
                        <asp:Label ID="lblfoterquantitytotal" runat="server"></asp:Label>
                        <asp:Label ID="lblquantity_footer_UnitName" Font-Bold="true" ForeColor="Gray" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage1Name">
                    <ItemStyle CssClass="textLeft FabFirstStage1 stage1name" Width="95" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblstageName1" ForeColor="Gray" CssClass="color_black" Text='<%# Convert.ToString(Eval("StageFirstName")) == "Griege" ? "Greige" : Convert.ToString(Eval("StageFirstName"))%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage1_Shrinkage">
                    <ItemStyle CssClass="textLeft FabFirstColP" Width="80" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtshrinkage1" onpaste="return false;" MaxLength="5" class="tooltip number Stage1_Wastagetextbox"
                            Text='<%# (Eval("Stage1_Shrinkage") == DBNull.Value  || (Eval("Stage1_Shrinkage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("Stage1_Shrinkage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$"></asp:TextBox>
                        <%# (Eval("Stage1_Shrinkage") == DBNull.Value || (Eval("Stage1_Shrinkage").ToString().Trim() == "0")) ? string.Empty : "%" %>
                        <br />
                        <asp:Label ID="lblshrinkage1" runat="server" Visible="false"></asp:Label>
                        <%-- <span style="color: Gray;"><%# (Eval("Stage1_Shrinkage") == DBNull.Value || (Eval("Stage1_Shrinkage").ToString().Trim() == "0")) ? string.Empty :Eval("UnitName")%></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalshrinkagevalue1" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage1_Shrinkage_footer_Percent" runat="server" Text="%" Visible="false"></asp:Label>
                        <br>
                        <asp:Label ID="lblfotertotalshrinkage1" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage1_Shrinkage_footer_UnitName" Font-Bold="true" ForeColor="Gray"
                            runat="server" Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage1_Wastage">
                    <ItemStyle CssClass="textLeft FabFirstColP Shrinkageeee" Width="70" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtwastage1" onpaste="return false;" MaxLength="4" class="tooltip number Stage1_Wastagetextbox"
                            Text='<%# (Eval("Stage1_Wastage") == DBNull.Value  || (Eval("Stage1_Wastage").ToString().Trim() == "0")) ? string.Empty :  Convert.ToString(Eval("Stage1_Wastage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <span style="color: Gray;">
                            <%#  (  (Eval("Stage1_Wastage") == DBNull.Value || Eval("Stage1_Wastage").ToString().Trim() == "0") && (Eval("FabricGriegeMasterValue").ToString().Trim() == "0")
                                  ) ? string.Empty : "%" %>
                          </span>
                        <%-- <span runat="server" id="spn_Stage1Tooltip" ></span>--%>
                        <br />
                        <asp:Label ID="lblwastage1" runat="server" Visible="false"></asp:Label>
                        <%--<span style="color: Gray;"><%# (Eval("Stage1_Wastage") == DBNull.Value || (Eval("Stage1_Wastage").ToString().Trim() == "0")) ? string.Empty : Eval("UnitName")%></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalwastagevalue1" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage1_Wastage_footer_Percent" Font-Bold="true" ForeColor="Gray"
                            runat="server" Text="%" Visible="false"></asp:Label>
                        <br />
                        <asp:Label ID="lblfotertotalwastage1" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage1_Wastage_footer_UnitName" Font-Bold="true" ForeColor="Gray"
                            runat="server" Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage2Name">
                    <ItemStyle CssClass="textLeft FabFirstStage2 stage2width1" Width="95" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblstageName2" ForeColor="Gray" CssClass="color_black" Text='<%# Convert.ToString(Eval("StageSecoundName")) == "" ? "" : Convert.ToString(Eval("StageSecoundName"))%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage2_Shrinkage">
                    <ItemStyle CssClass="textLeft FabFirstColP" Width="69" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtshrinkage2" onpaste="return false;" MaxLength="5" class="tooltip number Stage1_Wastagetextbox"
                            Text='<%# (Eval("Stage2_Shrinkage") == DBNull.Value  || (Eval("Stage2_Shrinkage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("Stage2_Shrinkage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <span style="color: Gray;" runat="server" id="span_shrinkage2_percent">
                            <%# (Eval("Stage2_Shrinkage") == DBNull.Value || (Eval("Stage2_Shrinkage").ToString().Trim() == "0")) ? string.Empty : "%"%></span>
                        <br />
                        <asp:Label ID="lblshrinkage2" runat="server" Visible="false"></asp:Label>
                        <%--<span style="color: Gray;" runat="server" id ="span_shrinkage2_UnitName"><%# (Eval("Stage2_Shrinkage") == DBNull.Value || (Eval("Stage2_Shrinkage").ToString().Trim() == "0")) ? string.Empty : Eval("UnitName")%></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalshrinkagevalue2" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage2_Shrinkage_footer_Percent" Font-Bold="true" ForeColor="Gray"
                            runat="server" Text="%" Visible="false"></asp:Label>
                        <br />
                        <asp:Label ID="lblfotertotalshrinkage2" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage2_Shrinkage_footer_UnitName" Font-Bold="true" ForeColor="Gray"
                            runat="server" Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage2_Wastage">
                    <ItemStyle CssClass="textLeft FabFirstColP" Width="67" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtwastage2" MaxLength="5" onpaste="return false;" class="tooltip number Stage1_Wastagetextbox"
                            Text='<%# (Eval("Stage2_Wastage") == DBNull.Value  || (Eval("Stage2_Wastage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("Stage2_Wastage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <span style="color: Gray;" runat="server" id="span_wastage2_percent">
                            <%# (Eval("Stage2_Wastage") == DBNull.Value || (Eval("Stage2_Wastage").ToString().Trim() == "0")) ? string.Empty : "%" %></span>
                        <br />
                        <asp:Label ID="lblwastage2" runat="server" Visible="false"></asp:Label>
                        <%--<span style="color: Gray;" runat="server" id ="span_wastage2_UnitName"> <%# (Eval("Stage2_Wastage") == DBNull.Value || (Eval("Stage2_Wastage").ToString().Trim() == "0")) ? string.Empty : Eval("UnitName")%></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalwastagevalue2" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage2_Wastage_footer_Percent" Font-Bold="true" ForeColor="Gray"
                            runat="server" Text="%" Visible="false"></asp:Label>
                        <br />
                        <asp:Label ID="lblfotertotalwastage2" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStage2_Wastage_footer_UnitName" Font-Bold="true" ForeColor="Gray"
                            runat="server" Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage3Name">
                    <ItemStyle CssClass="textLeft FabFirstColP stage2width" Width="95" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblstageName3" ForeColor="Gray" CssClass="color_black" Text='<%# Convert.ToString(Eval("StageThirdName")) == "" ? "" : Convert.ToString(Eval("StageThirdName"))%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage3_Shrinkage">
                    <ItemStyle CssClass="textLeft FabFirstStage3" Width="70" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtshrinkage3" MaxLength="5" onpaste="return false;" class="tooltip number Stage1_Wastagetextbox"
                            Text='<%# (Eval("Stage3_Shrinkage") == DBNull.Value  || (Eval("Stage3_Shrinkage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("Stage3_Shrinkage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <span style="color: Gray;" runat="server" id="span_shrinkage3_percent">
                            <%# (Eval("Stage3_Shrinkage") == DBNull.Value || (Eval("Stage3_Shrinkage").ToString().Trim() == "0")) ? string.Empty : "%" %></span>
                        <br />
                        <asp:Label ID="lblshrinkage3" runat="server" Visible="false"></asp:Label>
                        <%--<span style="color: Gray;" runat="server" id ="span_shrinkage3_UnitName"><%# (Eval("Stage3_Shrinkage") == DBNull.Value || (Eval("Stage3_Shrinkage").ToString().Trim() == "0")) ? string.Empty : Eval("UnitName")%></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalshrinkagevalue3" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblshrinkage3_footer_Percent" runat="server" Text="%" Visible="false"></asp:Label>
                        <br />
                        <asp:Label ID="lblfotertotalshrinkage3" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblshrinkage3_footer_UnitName" Font-Bold="true" ForeColor="Gray" runat="server"
                            Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage3_Wastage">
                    <ItemStyle CssClass="textLeft FabFirstColP" Width="67" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtwastage3" onpaste="return false;" MaxLength="5" class="tooltip number"
                            Text='<%# (Eval("Stage3_Wastage") == DBNull.Value  || (Eval("Stage3_Wastage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("Stage3_Wastage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <span style="color: Gray;" runat="server" id="span_wastage3_percent">
                            <%# (Eval("Stage3_Wastage") == DBNull.Value || (Eval("Stage3_Wastage").ToString().Trim() == "0")) ? string.Empty : "%"%></span>
                        <br />
                        <asp:Label ID="lblwastage3" runat="server" Visible="false"></asp:Label>
                        <%--<span style="color: Gray;" runat="server" id ="span_wastage3_UnitName"><%# (Eval("Stage3_Wastage") == DBNull.Value || (Eval("Stage3_Wastage").ToString().Trim() == "0")) ? string.Empty : Eval("UnitName") %></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalWastagevalue3" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblwastage3_footer_Percent" runat="server" Text="%" Visible="false"></asp:Label>
                        <br>
                        <asp:Label ID="lblfotertotalWastage3" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblwastage3_footer_UnitName" Font-Bold="true" ForeColor="Gray" runat="server"
                            Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage4Name">
                    <ItemStyle CssClass="textLeft FabFirstColP" Width="96" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblstageName4" ForeColor="Gray" CssClass="color_black" Text='<%# Convert.ToString(Eval("StageFourthName")) == "" ? "" : Convert.ToString(Eval("StageFourthName"))%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage4_Shrinkage">
                    <ItemStyle CssClass="textLeft FabFirstColP" Width="67" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtshrinkage4" onpaste="return false;" MaxLength="5" class="tooltip number"
                            Text='<%# (Eval("Stage4_Shrinkage") == DBNull.Value  || (Eval("Stage4_Shrinkage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("Stage4_Shrinkage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <span style="color: Gray;" runat="server" id="span_shrinkage4_percent">
                            <%# (Eval("Stage4_Shrinkage") == DBNull.Value || (Eval("Stage4_Shrinkage").ToString().Trim() == "0")) ? string.Empty : "%" %></span>
                        <br />
                        <asp:Label ID="lblshrinkage4" runat="server" Visible="false"></asp:Label>
                        <%--<span style="color: Gray;" runat="server" id ="span_shrinkage4_UnitName"> <%# (Eval("Stage4_Shrinkage") == DBNull.Value || (Eval("Stage4_Shrinkage").ToString().Trim() == "0")) ? string.Empty : Eval("UnitName")%></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalshrinkagevalue4" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblshrinkage4_footer_Percent" runat="server" Text="%" Visible="false"></asp:Label>
                        <br>
                        <asp:Label ID="lblfotertotalshrinkage4" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblshrinkage4_footer_UnitName" Font-Bold="true" ForeColor="Gray" runat="server"
                            Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stage4_Wastage">
                    <ItemStyle CssClass="textLeft FabFirstColP" Width="68" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtwastage4" onpaste="return false;" MaxLength="5" class="tooltip number"
                            Text='<%# (Eval("Stage4_Wastage") == DBNull.Value  || (Eval("Stage4_Wastage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("Stage4_Wastage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <span style="color: Gray;" runat="server" id="span_wastage4_percent">
                            <%# (Eval("Stage4_Wastage") == DBNull.Value || (Eval("Stage4_Wastage").ToString().Trim() == "0")) ? string.Empty : "%"%></span>
                        <br />
                        <asp:Label ID="lblwastage4" runat="server" Visible="false"></asp:Label>
                        <%--<span style="color: Gray;" runat="server" id ="span_wastage4_UnitName"><%# (Eval("Stage4_Wastage") == DBNull.Value || (Eval("Stage4_Wastage").ToString().Trim() == "0")) ? string.Empty : Eval("UnitName")%></span>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalwastagevalue4" runat="server"></asp:Label>
                        <asp:Label ID="lblwastage4_footer_Percent" runat="server" Text="%"></asp:Label>
                        <br>
                        <asp:Label ID="lblfotertotalwastage4" runat="server"></asp:Label>
                        <asp:Label ID="lblwastage4_footer_UnitName" Font-Bold="true" ForeColor="Gray" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CutWastage %">
                    <ItemStyle CssClass="textLeft FabFirstColP stage1cutwastage" Width="67" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%--rajeevS 200223--%>
                        <asp:TextBox ID="lblcutwastage" onpaste="return false;" MaxLength="5" Width="25"
                            class="tooltip number" Text='<%# (Eval("CutWastage") == DBNull.Value  || (Eval("CutWastage").ToString().Trim() == "0")) ? string.Empty : Convert.ToString(Eval("CutWastage")) %>'
                            runat="server" pattern="^\d*(\.\d{0,2})?$" BorderColor="White"></asp:TextBox>
                        <%-- <asp:TextBox CssClass="form_box_border" ID="lblcutwastage" runat="server" Width="30" class="tooltip number Stage1_Wastagetextbox tooltip number Stage1_Wastagetextbox" Text='<%# Eval("CutWastage") %>'>
                        </asp:TextBox>--%>
                        <%--rajeevS 200223--%>
                        <asp:Label ID="lblcutwastage_percentsign" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnCutwastge" runat="server" Value='<%# Eval("CutWastage") %>' />
                        <br />
                        <asp:Label ID="lblvaluecutwastage" runat="server" Visible="false"></asp:Label>
                        <%--<asp:Label style="color: Gray;" runat="server" id="lblcutwastage_unit" Text='<%# Eval("UnitName")%>'></asp:Label> --%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalcutwastagevalue" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblcutwastage_footer_Percent" runat="server" Style="color: Gray; font-weight: bold;"
                            Text="%" Visible="false"></asp:Label>
                        <br />
                        <asp:Label ID="lblfotertotalcutwastage" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblcutwastage_footer_UnitName" runat="server" Style="color: Gray;
                            font-weight: bold;" Visible="false"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Required Qty.">
                    <ItemStyle CssClass="textLeft FabFirstColP stage1requiredqty" Width="68px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblrequiredqty" Font-Bold="true" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnrequiredqtywithoutround" runat="server" />
                        <asp:Label Style="color: Gray;" runat="server" ID="lblrequiredqty_unit" Text='<%# Eval("UnitName")%>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblfotertotalrequiredqty" runat="server"></asp:Label>
                        <asp:Label ID="lblrequiredqty_footer_UnitName" runat="server" Style="color: Gray;
                            font-weight: bold;"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div align="center">
                    <img src='../../images/sorry.png' alt='No record found' class='ImgCenter'>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div style="padding-bottom: 36px">
        <asp:Button ID="btnSubmit" Style="" runat="server" Text="Submit" CssClass="btnbutton"
            Visible="false" OnClientClick="removedDisable()" OnClick="btnsubmit_Click" />
        <div class="btnClose" onclick="javascript:self.parent.Shadowbox.close();">
            Close</div>
        <div style="padding: 6px; text-align: right; position: fixed; right: 0; top: 0%;
            z-index: 999999; color: White; padding-right: 0; margin-right: 15px; display: flex;
            font-size: 11px;">
            Admin suggested Wastage : &nbsp;
            <asp:Label ID='lblSugCutwastage' runat="server" Style="color: Red"></asp:Label>
            &nbsp;% &nbsp; &nbsp; <span>Apply to All&nbsp; </span>
            <asp:CheckBox ID='chkSugCutwastage' runat="server" Style="margin-top: -2px;" onchange="applyCutWastage()" />
        </div>
    </div>
    </form>
</body>
<script type="text/javascript">
    //added by Girish on 2023-04-12 :Start

    var initialCutWastageValues = {};

    $(document).ready(function () {
        if ($.isEmptyObject(initialCutWastageValues)) {
            $("[id$='lblcutwastage']").each(function () {
                var key = this.id;
                var value = $(this).val()
                initialCutWastageValues[key] = value;
            });
        }
    });

    function applyCutWastage() {
        var SuggestedCutWastage = $('#lblSugCutwastage').text();
        if ($('#chkSugCutwastage').is(':checked')) {
            $("[id$='lblcutwastage']").each(function () {
                $(this).val(SuggestedCutWastage);
                $(this).attr('disabled', 'disabled');
            });
        }
        else {
            $("[id$='lblcutwastage']").each(function () {
                $(this).val(initialCutWastageValues[this.id]);
                $(this).removeAttr("disabled");

            });
        }
    }
    function removedDisable() {
        $("[id$='lblcutwastage']").each(function () {
            $(this).removeAttr("disabled");

        });
    }

    //added by Girish on 2023-04-12 :End


</script>
</html>
