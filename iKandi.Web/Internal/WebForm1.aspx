<%@ Page Title="" Language="C#" MasterPageFile="~/layout/SimpleSecure.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="iKandi.Web.Internal.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <html xmlns="http://www.w3.org/TR/REC-html40">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
        <meta name="ProgId" content="Excel.Sheet">
        <meta name="Generator" content="Microsoft Excel 15">
        <link rel="File-List" href="QuantityMovement_files/filelist.xml">
        <style id="QuantityMovement_15342_Styles">
<!--table
	{mso-displayed-decimal-separator:"\.";
	mso-displayed-thousand-separator:"\,";}
.xl1515342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl6315342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:top;
	border:.5pt solid windowtext;
	background:#A9D08E;
	mso-pattern:black none;
	white-space:nowrap;}
.xl6415342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#D0CECE;
	mso-pattern:black none;
	white-space:nowrap;}
.xl6515342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:#757171;
	font-size:11.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:top;
	border:.5pt solid windowtext;
	background:#D6DCE4;
	mso-pattern:black none;
	white-space:nowrap;}
.xl6615342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:top;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl6715342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:#757171;
	font-size:11.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#D6DCE4;
	mso-pattern:black none;
	white-space:nowrap;}
.xl6815342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl6915342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:#C65911;
	font-size:11.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl7015342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#C6E0B4;
	mso-pattern:black none;
	white-space:nowrap;}
.xl7115342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:top;
	border:.5pt solid windowtext;
	background:#B4C6E7;
	mso-pattern:black none;
	white-space:normal;}
.xl7215342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:top;
	border:.5pt solid windowtext;
	background:#B4C6E7;
	mso-pattern:black none;
	white-space:nowrap;}
.xl7315342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:top;
	border:.5pt solid windowtext;
	background:#A9D08E;
	mso-pattern:black none;
	white-space:normal;}
.xl7415342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#F2F2F2;
	mso-pattern:black none;
	white-space:nowrap;}
.xl7515342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#FFF2CC;
	mso-pattern:black none;
	white-space:nowrap;}
.xl7615342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#FFE699;
	mso-pattern:black none;
	white-space:nowrap;}
.xl7715342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#FFD966;
	mso-pattern:black none;
	white-space:nowrap;}
.xl7815342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:12.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:"Times New Roman", serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:middle;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl7915342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#D9E1F2;
	mso-pattern:black none;
	white-space:nowrap;}
.xl8015342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:top;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl8115342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:14.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#D9E1F2;
	mso-pattern:black none;
	white-space:nowrap;}
.xl8215342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:#757171;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl8315342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:#757171;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl8415342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:#757171;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl8515342
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:#3A3838;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	background:#F2F2F2;
	mso-pattern:black none;
	white-space:nowrap;}
            .style1
            {
                padding-top: 1px;
                padding-right: 1px;
                padding-left: 1px;
                mso-ignore: padding;
                color: black;
                font-size: 11.0pt;
                font-weight: 400;
                font-style: normal;
                text-decoration: none;
                font-family: Calibri, sans-serif;
                mso-font-charset: 0;
                mso-number-format: General;
                text-align: left;
                vertical-align: top;
                border: .5pt solid windowtext;
                mso-background-source: auto;
                mso-pattern: auto;
                white-space: normal;
                width: 216pt;
            }
-->
</style>
<script type="text/javascript">
    $(document).ready(function () {



        $("input[type=text].auto-fabricname").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricNameByName", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });
        $("input[type=text].auto-fabricname", "#main_content").result(function () { if ($(this).val().length === 1) { $(this).val(''); } });






    });



</script>

    </head>
    <body>
        <!--[if !excel]>&nbsp;&nbsp;<![endif]-->
        <!--The following information was generated by Microsoft Excel's Publish as Web
Page wizard.-->
        <!--If the same item is republished from Excel, all information between the DIV
tags will be replaced.-->
        <!----------------------------->
        <!--START OF OUTPUT FROM EXCEL PUBLISH AS WEB PAGE WIZARD -->
        <!----------------------------->
        <div id="QuantityMovement_15342" align="center" x:publishsource="Excel">
            <table border="0" cellpadding="0" cellspacing="0" width="1246" style='border-collapse: collapse;
                table-layout: fixed; width: 938pt'>
                <col width="89" span="13" style='width: 67pt'>
                <tr height="25" style='height: 18.75pt'>
                    <td colspan="8" height="25" class="xl8115342" width="1246" style='height: 18.75pt;
                        width: 938pt'>
                        Quality Quantity movement from a contract to another
                    </td>
                </tr>
                <tr height="24" style='mso-height-source: userset; height: 18.0pt'>
                    <td height="24" class="xl6515342" style='height: 18.0pt; border-top: none'>
                        Type
                    </td>
                    <td class="xl6615342" style='border-top: none; border-left: none'>
                        <asp:DropDownList ID="DDlType" runat="server">
                            <asp:ListItem Text="Please Select Type" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Fabric" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Accessory" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="xl6515342" style='border-top: none; border-left: none'>
                        Quality Name
                    </td>
                    <td colspan="3" class="style1" 
                        
                        style='border-left-style: none; border-left-color: inherit; border-left-width: medium;'>
                        <asp:TextBox ID="txtFabric" runat="server"  class="auto-fabricname"></asp:TextBox>
                    </td>
                    <td class="xl6515342" style='border-top: none; border-left: none'>
                        Colour Print
                    </td>
                    <td class="xl8015342" width="534" style='border-left: none; width: 402pt'>
                        
                        <asp:TextBox ID="txtColorPrint" runat="server" class="auto-color"></asp:TextBox>
                    </td>
                </tr>
                <tr height="20" style='height: 15.0pt'>
                    <td height="20" class="xl6715342" style='height: 15.0pt; border-top: none'>
                        Select Type
                    </td>
                    <td class="xl6815342" style='border-top: none; border-left: none'>
                        <asp:DropDownList ID="FabricType" runat="server">
                            <asp:ListItem Text="Please Select Type" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="GREIGE" Value="1"></asp:ListItem>
                            <asp:ListItem Text="DYED" Value="2"></asp:ListItem>
                            <asp:ListItem Text="PRINT" Value="3"></asp:ListItem>
                            <asp:ListItem Text="RFD stage1" Value="29"></asp:ListItem>
                            <asp:ListItem Text="RFD stage2" Value="29"></asp:ListItem>
                            <asp:ListItem Text="Finished" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embllishment" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embrodery" Value="31"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="6" class="xl8515342" style='border-left: none'>
                        If Selected Other than Greige or RFD First Stage then colur Print will be Must
                    </td>
                </tr>
                <tr height="20" style='height: 15.0pt'>
                    <td height="20" class="xl6715342" style='height: 15.0pt; border-top: none'>
                        Stages
                    </td>
                    <td class="xl6915342" style='border-top: none; border-left: none'>
                        <asp:DropDownList ID="ddlstagetype1" runat="server">
                            <asp:ListItem Text="Please Select stage1" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="GREIGE" Value="1"></asp:ListItem>
                            <asp:ListItem Text="DYED" Value="2"></asp:ListItem>
                            <asp:ListItem Text="PRINT" Value="3"></asp:ListItem>
                            <asp:ListItem Text="RFD stage1" Value="29"></asp:ListItem>
                            <asp:ListItem Text="RFD stage2" Value="29"></asp:ListItem>
                            <asp:ListItem Text="Finished" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embllishment" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embrodery" Value="31"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="xl6915342" style='border-top: none; border-left: none'>
                        <asp:DropDownList ID="ddlstagetype2" runat="server">
                            <asp:ListItem Text="Please Select stage2" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="GREIGE" Value="1"></asp:ListItem>
                            <asp:ListItem Text="DYED" Value="2"></asp:ListItem>
                            <asp:ListItem Text="PRINT" Value="3"></asp:ListItem>
                            <asp:ListItem Text="RFD stage1" Value="29"></asp:ListItem>
                            <asp:ListItem Text="RFD stage2" Value="29"></asp:ListItem>
                            <asp:ListItem Text="Finished" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embllishment" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embrodery" Value="31"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="xl6915342" style='border-top: none; border-left: none'>
                        <asp:DropDownList ID="ddlstagetype3" runat="server">
                            <asp:ListItem Text="Please Select Stage3" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="GREIGE" Value="1"></asp:ListItem>
                            <asp:ListItem Text="DYED" Value="2"></asp:ListItem>
                            <asp:ListItem Text="PRINT" Value="3"></asp:ListItem>
                            <asp:ListItem Text="RFD stage1" Value="29"></asp:ListItem>
                            <asp:ListItem Text="RFD stage2" Value="29"></asp:ListItem>
                            <asp:ListItem Text="Finished" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embllishment" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Embrodery" Value="31"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="xl6915342" style='border-top: none; border-left: none'>
                        &nbsp;
                    </td>
                    <td colspan="3" class="xl8515342" style='border-left: none'>
                        Must be movement among Same stage selection
                    </td>
                </tr>
                <tr height="20" style='height: 15.0pt'>
                    <td colspan="8" height="20" class="xl8215342" style='border-right: .5pt solid black;
                        height: 15.0pt'>
                        &nbsp;
                    </td>
                </tr>
                <tr height="20" style='height: 15.0pt'>
                    <td colspan="6" height="20" class="xl7915342" style='height: 15.0pt'>
                        From
                    </td>
                    <td  class="xl7915342" colspan="2" style='border-top: none; border-left: none' >
                        To
                    </td>
                 
                </tr>
                <tr height="40" style='height: 30.0pt; width:100%;'>
                <td style=" width:50%; text-align:right" colspan="4">
                    <asp:GridView ID="grdFrom" runat="server" AutoGenerateColumns="false" 
                        Width="50%" onselectedindexchanged="grdFrom_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="SerialNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNumber" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ContractNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblContractNumber" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exfactory">
                                <ItemTemplate>
                                    <asp:Label ID="lblExfactory" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allocated">
                                <ItemTemplate>
                                    <asp:Label ID="lblAllocated" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Available To move">
                                <ItemTemplate>
                                    <asp:Label ID="lblAvailable" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Subtract">
                                <ItemTemplate>
                                   <%-- <asp:Label ID="lblSubtract" runat="server"></asp:Label>--%>
                                   <asp:TextBox ID="txtSubtract" runat ="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td>
                    <td style=" width:50%; text-align: left;" colspan="6">
                    <asp:GridView ID="grdto" runat="server" AutoGenerateColumns="false" Width="50%">
                        <Columns>
                            <asp:TemplateField HeaderText="SerialNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNumber" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ContractNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblContractNumber" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exfactory">
                                <ItemTemplate>
                                    <asp:Label ID="lblExfactory" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allocated">
                                <ItemTemplate>
                                    <asp:Label ID="lblAllocated"  runat="server" />"
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Required Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequireQty" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Required Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequireQty" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Add">
                                <ItemTemplate>
                                   <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>





                    </td>
             
                </tr>
             
                
            </table>
        </div>
        <!----------------------------->
        <!--END OF OUTPUT FROM EXCEL PUBLISH AS WEB PAGE WIZARD-->
        <!----------------------------->
    </body>
    </html>
</asp:Content>
