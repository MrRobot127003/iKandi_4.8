<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricExternalChallanPdf.aspx.cs"
    Inherits="iKandi.Web.FabricPdfFile.FabricExternalChallanPdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <div id="spinner">
    </div>
    <style>
        body
        {
            font-family: sans-serif !important;
            margin: 0px;
            padding: 0px;
            font-size: 11px;
            color: #040404;
        }
        input
        {
            border-radius: 2px;
            border: 1px solid #999;
            padding-left: 3px;
        }
        input[type="text"]
        {
            padding-left: 3px;
            height: 15px;
            font-size: 10px;
            text-transform: capitalize !important;
        }
        .debitnote-table
        {
            font-family: Arial !important;
        }
        .debitnote-table .top_heading
        {
            text-transform: capitalize;
            font-size: 16px;
            font-weight: 500;
            padding-top: 3px;
            text-align: center;
            padding-bottom: 2px;
            background: #39589c;
            color: #fff;
        }
        .debitnote-table .address_head
        {
            font-weight: 500;
            font-size: 10px;
            line-height: 15px;
            padding-left: 0px;
        }
        .debitnote-table .Srnon
        {
            font-weight: 600;
            font-size: 18px;
        }
        tbody td
        {
            padding: 3px 3px;
            font-size: 11px; /* text-transform: uppercase; */
            border-color: #dbd8d8;
            color: #040404;
        }
        .DyedPrintDivWidth
        {
            overflow: hidden;
        }
        .DyedPrintDivWidth tbody td
        {
            border: 0px !important;
        }
        tbody td.borderbottom
        {
            padding: 0px 3px;
            font-size: 11px; /* text-transform: uppercase; */
            width: 150px;
            border-collapse: collapse;
        }
        .formcontrol
        {
            width: 98%;
        }
        .formcontrol2
        {
            width: 99%;
        }
        .headerbold
        {
            font-weight: 600;
        }
        
        .texttranceform
        {
            /* text-transform: uppercase; */
        }
        
        ul
        {
            margin: 0;
            padding: 0px 0px;
            max-width: 100%;
            list-style-type: none;
        }
        li
        {
            float: left;
            line-height: 16px;
            padding: 0px;
            color: #040404;
        }
        .tablewidth
        {
            width: 350px;
            padding: 0px 3px 5px;
            border-bottom: 1px solid #dbd8d8;
        }
        .tableto
        {
            width: 80px;
        }
        .bottomborder
        {
            border-bottom: 1px solid #dbd8d8;
            padding: 10px 5px;
        }
        .listwidth
        {
            min-width: 80px;
        }
        tbody td.bordertable
        {
            border-bottom: 1px solid #dbd8d8;
            border-left: 1px solid #dbd8d8;
            padding: 2px 3px;
            font-size: 11px; /* text-transform: capitalize; */
            border-collapse: collapse;
            text-align: center;
        }
        .metercol
        {
            width: 50px;
        }
        .cmcoloum
        {
            width: 40px;
        }
        .checkboxtop
        {
            position: relative;
            top: 2px;
        }
        input
        {
            padding: 0px 0px;
        }
        .textaria
        {
            width: 74%;
        }
        .inputfield
        {
            width: 95%;
        }
        .bottomborder1
        {
            text-align: center;
        }
        .rightborder
        {
            border-right: 1px solid #dbd8d8;
        }
        .btnbutton
        {
            background: #1976D2;
            color: #fff;
            border: 1px solid #1976d2;
            padding: 4px;
            border-radius: 3px;
        }
        .headerbacground
        {
            background: #e4e2e2;
            color: #6b6464;
        }
        .facolor
        {
            cursor: pointer;
            color: #000;
        }
        .p-r-5
        {
            padding-right: 5px;
        }
        .textcenter
        {
            text-align: center;
            font-size: 11px;
        }
        .removebucolor
        {
            color: red;
            cursor: pointer;
        }
        .editbucolor
        {
            color: green;
            cursor: pointer;
        }
        .txtcenter
        {
            text-align: center;
        }
        select
        {
            font-size: 11px;
        }
        input
        {
            font-size: 11px;
        }
        .borderleft
        {
            border-left: 1px solid #dbd8d8;
        }
        
        .metersr tbody td
        {
            height: 13px;
            border-color: #dbd8d8;
        }
        .tabletdhei
        {
            height: 16px !important;
        }
        .borderhightlight
        {
            border: 1px solid red !important;
        }
        
        
        .metersr tbody td:nth-last-child(2)
        {
            color: gray !important;
        }
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
        }
        
        .borderhightlight1
        {
            position: relative;
            display: inline-block;
            border-bottom: 1px dotted black;
        }
        
        .borderhightlight1 .messagetooltop
        {
            width: 120px;
            background-color: black;
            color: #fff;
            text-align: center;
            border-radius: 6px;
            padding: 5px 0;
            position: absolute;
            z-index: 1;
            top: 0%;
            right: 0%;
            margin-left: -60px;
        }
        table#tblisdayed
        {
            border: 0px;
            border-collapse: collapse;
        }
        #tblisdayed td
        {
            border: 1px solid #999 !important;
            border-left-color: #9999;
            border-right-color: #9999 !important;
        }
        .borderhightlight1 .messagetooltop::after
        {
            content: " ";
            position: absolute;
            top: 100%; /* At the bottom of the tooltip */
            right: 50%;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: black transparent transparent transparent;
        }
        .supplieretadatetable td input[type="text"]
        {
            width: 92%;
            margin: 1px 0px;
            padding-left: 3px;
            color: #040404;
            text-transform: capitalize !important;
            font-size: 11px;
        }
        
        .supplieretadatetable th
        {
            padding: 3px 3px;
            border: 1px solid #999;
        }
        .supplieretadatetable td
        {
            text-align: center;
            padding: 1px 3px;
            border: 1px solid #dbd8d8;
        }
        th
        {
            font-weight: normal;
            font-size: 11px;
            font-family: Arial;
            background: #dddfe4;
            border-color: #999;
        }
        #grdmaster th
        {
            background: #dddfe4;
            padding: 2px 2px;
            width: 98px;
            text-align: center;
            border-color: #999;
        }
        .CloneRow
        {
            padding: 0px 3px !important; /*border-color: #999 !important;*/
        }
        .gridClass td
        {
            /* padding: 0px 3px !important;*/
        }
        .gridClass
        {
            margin-top: -13px;
        }
        .btnClose
        {
            margin-left: 10px;
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .btnClose:hover
        {
            color: red;
        }
        .btnSubmit
        {
            margin-left: 10px;
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
        .btnSubmit:hover
        {
            color: Yellow !important;
        }
        .btnPrint
        {
            margin-left: 10px;
            font-size: 12px !important;
            float: left;
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: #39589c !important;
            height: 24px;
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .supplieretadatetable
        {
            border-collapse: collapse;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        input[type='checkbox']
        {
            position: relative;
            top: 2px;
            margin: 1px 0px 0px 4px;
        }
        .border_left_color
        {
            border-left-color: #999 !important;
        }
        .border_right_color
        {
            border-right-color: #999 !important;
        }
        #grdmaster tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        /* Code added by bharat on 11-june*/
        #secure_footer
        {
            display: none;
        }
        .DyedPrintDivWidth
        {
            /*max-width: 545px !important;*/
            width: 100%;
            max-width: 100% !important;
        }
        .DyedPrintTableWidth .textaria
        {
            width: 75%;
        }
        .DyedPrintTableWidth .formcontrol
        {
            width: 34%;
            height: 16px !important;
            font-size: 10px;
        }
        .DyedPrintTableWidth .padding_top10
        {
            padding-top: 10px;
        }
        #divsend
        {
            position: relative;
            padding-left: 1px;
            border: 1px solid #999;
            padding: 4px 0px;
            border-left: solid 1px #999;
            border-right: solid 1px #999;
        }
        .DyedPrintTableWidth
        {
            width: 100% !important;
            border: 0px !important;
            margin-bottom: 0px !important;
        }
        .DyedPrintTableWidth .ToLeft
        {
            padding-left: 8% !important;
        }
        
        .DyedPrintTableWidth .DesLeft
        {
            padding-left: 24% !important;
            position: relative;
            top: -12px;
        }
        .DyedPrintTableWidth .FabricColorPrint
        {
            float: left;
            padding-left: 4.5% !important;
        }
        /* .DyedPrintTableWidth .inputtextwidth
        {
            width: 129% !important;
        }*/
        .DyedPrintTableWidth .bottom_border
        {
            border-bottom: 1px solid #999;
        }
        .widthCollCha
        {
            width: 20% !important;
        }
        .Paading5
        {
            padding-top: 5px !important;
        }
        .Margin_top8
        {
            margin-top: 0px !important;
        }
        .Paading_top0
        {
            padding-top: 0px !important;
        }
        .DiveBordernone
        {
            border-right: 0px !important;
            border-bottom: 0px !important;
        }
        .toppadding10.Paading5
        {
            padding-left: 33%;
        }
        .CloneRow.txtcenter.border_left_color
        {
            height: 17px;
        }
        #GridView1 td.CloneRow:first-child
        {
            border-left-color: #999 !important;
            height: 21px;
        }
        #GridView1 th
        {
            height: 19px;
        }
        #GridView1 td.CloneRow:last-child
        {
            border-right-color: #999 !important;
        }
        #GridView1 tr:nth-last-child(1) > td
        {
            border-bottom-color: #999 !important;
        }
        .MainTableWidth
        {
            /* width: 41.6% !important;*/
            width: 41.6% !important;
        }
        .MasterTableWidth
        {
            min-width: 250px !important;
            max-width: 250px !important;
        }
        .TableHeight
        {
            height: 411px !important;
        }
        
        .TableHeight .FabricColorPrint
        {
            width: 1% !important;
        }
        .MainTableWidth .ToLeft
        {
            padding-left: 21% !important;
        }
        .MainTableWidth .MSLeft
        {
            padding-left: 20% !important;
        }
        .MainTableWidth .DesLeft
        {
            padding-left: 26% !important;
        }
        .MainTableWidth .inputtextwidth
        {
            width: 225px !important;
        }
        .ChallanNoWi
        {
            width: 29% !important;
        }
        .formcontrol4
        {
            width: 61%;
        }
        .NoTotalTable td
        {
            border: 0px !important;
        }
        
        /*.internalTable{
            height:411px !important;
        }*/
        .interButtonP
        {
            padding-top: 4px !important;
        }
        .PaddingTopPa0
        {
            padding-top: 2px !important;
        }
        .interTablewi #trchallantype .interwi
        {
            width: 37% important;
        }
        .bottom_border_color_h
        {
            border-bottom-color: #999 !important;
        }
        .interTablewi
        {
            height: 393px !important;
        }
        .interTablbeHei
        {
            height: 369px !important;
        }
        .MSWidthI
        {
            width: 70px !important;
        }
        @media screen and (max-width: 1366px)
        {
            .TableHeight
            {
                height: 427px !important;
            }
            .DyedPrintTableWidth .MSLeft
            {
                padding-left: 1% !important;
            }
        
        }
        .TableHeight .MainTableWidth
        {
            height: 403px !important;
        }
        
        /*end*/
        /*
       code added by bharat on 21-june
       Click Print button the hide botton
         
       */
        @media print
        {
            .printHideButton
            {
                display: none;
            }
        }
        textarea
        {
            text-transform: capitalize !important;
        }
        td.input-validation-error
        {
            border: 1px solid #ff0000 !important;
            background-color: #ffeeee;
        }
        /** End */
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-thumb
        {
            background: #999;
            border: 1px solid #ddd7d7;
            border-radius: 10px;
        }
        .RemoveStyle
        {
            color: Gray;
        }
    </style>
    <title>Fabric Challan PDF</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnchkReceiver" runat="server" Value="0" />
    <asp:HiddenField ID="hdnchkAuthorized" runat="server" Value="0" />
    <asp:HiddenField ID="hdntotalmeter" runat="server" Value="0" />
    <asp:HiddenField ID="hdnsendtotalrening" runat="server" Value="0" />
    <asp:HiddenField ID="hdnmaxcount" runat="server" />
    <asp:HiddenField ID="hdnmaxavailbleqty" runat="server" />
    <div class="debitnote-table" style="max-width: 99.9%; margin-left: 5px; margin-right: 5px;">
        <div class="DiveBorder" style="border-right: 1px solid #999; border-left: 1px solid #999;
            border-bottom: 1px solid #999; height: 308px; max-height: 430px;">
            <table style="max-width: 100%; width: 100%; border: none; border: 1px solid #999;
                border-bottom: 0px;" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <td class="top_heading texttranceform bottomborder1" colspan="">
                            <span id="ChallanPageHeading" runat="server"></span>
                        </td>
                    </tr>
                </thead>
            </table>
            <table id="ChallanTable" style="max-width: 100%; height: 272px; max-height: 380px;
                width: 100%; margin-bottom: 15px; border-top: 0px; border-bottom: 0px; float: left"
                cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <td style="vertical-align: top; width: 125px; border-bottom: 1px solid #9999" class="bottom_border">
                            <div style="padding: 9px 7px">
                                <%--<img src="../../images/boutique-logo.png" />--%>
                                <asp:Image ID="boutiqueImg" runat="server" />
                            </div>
                        </td>
                        <%--<td class=" texttranceform tablewidth bottom_border">
                                    <span class="address_head">C-45-46 Hosiery Complex Phase-II Extn. Noida-201305 (U.P)</span><br />
                                    <span class="address_head">Gstin:- 09aaacb4905c1z5 </span>
                                    <br>
                                    <span class="address_head">Phone No:- +911206797979 </span>
                                    <br>
                                    <span class="address_head texttranceform">Fax:- 120-6797999</span><br>
                                    <span class="address_head texttranceform">E-mail:- boutique@boutique.in</span><br>
                                </td>--%>
                        <td style="width: 834px; text-align: left; border-left: 0px; border-bottom: 1px solid #9999"
                            rowspan="2" class="barder_top_color">
                            <div id="divbipladdress" runat="server">
                            </div>
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class=" texttranceform borderleft0bottom challanColWidth padding_top10" style="color: gray">
                            Challan No.
                        </td>
                        <td class="borderbottom padding_top10">
                            <%--<asp:TextBox ID="txtchallanno" Style="background: #fff; width: 40%; border: 0px;
                                        font-weight: 600; font-size: 11px; color: #000;" class="formcontrol" runat="server"
                                        Enabled="false"></asp:TextBox>--%>
                            <asp:Label ID="lblchallanno" class="formcontrol" Style="background: #fff; width: 40%;
                                border: 0px; font-weight: 600; font-size: 11px; color: #000;" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="hideInternalPo">
                        <td class=" texttranceform borderleft0bottom challanColWidth" style="color: gray">
                            PO No.
                        </td>
                        <td class="borderbottom">
                            <asp:Label ID="txtponumber" class="formcontrol" Style="margin: 2px;" runat="server"
                                Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class=" texttranceform borderleft0bottom challanColWidth" style="color: gray">
                            Date:
                        </td>
                        <td class="borderbottom ">
                            <%--<asp:TextBox ID="txtpodate" class="formcontrol th datesfileds" runat="server" Style="height: 13px;
                                        background: #fff; width: 80px; border: 0px"></asp:TextBox>--%>
                            <asp:Label ID="lblpodate" class="formcontrol" Style="height: 13px; background: #fff;
                                width: 80px; border: 0px" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="texttranceform borderleft0bottom rpterror" style="padding-left: 3px; color: gray;
                            padding-top: 6px; vertical-align: baseline;">
                            Select:
                        </td>
                        <td class="texttranceform borderleft0bottom rpterror" colspan="" style="padding-left: 0px">
                            <ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <li class="listwidth">
                                            <asp:CheckBox Class="chkoption" ID="chkprocess" runat="server" />
                                            <asp:Label ID="lblfabricoprationType" Text='<%#Eval("ProcessName")%>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnChallan_Process_Admin_Id" runat="server" Value='<%#Eval("Challan_Process_Admin_Id")%>' />
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <asp:Label ID="lblCheckedList" runat="server" Height="25px" Style="width: 90%; margin-left: 3px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; color: gray" class="borderleft0bottom">
                            <span style="display: inline-flex">To: <span class="ToLeft" style="padding-left: 15%">
                                <asp:DropDownList ID="ddlext" Enabled="false" Style="width: 70px" runat="server">
                                    <asp:ListItem Value="0">Internal</asp:ListItem>
                                    <asp:ListItem Value="1">External</asp:ListItem>
                                </asp:DropDownList>
                            </span></span>
                        </td>
                        <td class="borderleft0bottom" style='color: gray'>
                            M/S: <span class="MSLeft" style="padding-left: 0px">
                                <asp:DropDownList Style="width: 115px;" ID="ddlsuppliername" class="msinternal" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="lblsuppliername" Visible="false" runat="server"></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span id="suppliergstno" style="padding-bottom: 10px; color: gray">GST No:</span>
                        </td>
                        <td>
                            <span>
                                <asp:Label ID="lblgstno" Text="" runat="server"></asp:Label></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span id="supplieraddress" style="padding-bottom: 10px; color: gray">Address:</span>
                        </td>
                        <td>
                            <span>
                                <asp:Label ID="lbladdress" Text="" runat="server"></asp:Label></span>
                        </td>
                    </tr>

                    <tr id="trchallantype" runat="server">
                        <td class="borderbottom interwi">
                            <span style="color: gray; width: 123px; display: inline-block;">Style No.
                                <asp:Label ID="txtstylenumber" runat="server" Enabled="false" class="formcontrol"
                                    Style="background: #fff; color: #000"></asp:Label>
                            </span>
                        </td>
                        <td class="borderbottom" style="width: 85px;">
                            <span style="color: gray">Serial. No.</span> <span>
                                <asp:Label ID="txtserialnumber" runat="server" Enabled="false" class="formcontrol"
                                    Style="width: 106px; background: #fff;"></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="bottomborder1" style="padding-left: 1px;">
                            <span style="float: left; padding-left: 2px; color: gray">Fabric Quality/ColorPrint</span><asp:TextBox
                                ID="txtcolorprint" runat="server" Visible="false" Enabled="false" class="formcontrol inputtextwidth"
                                Style="width: 275%; background: #fff; display: none;"></asp:TextBox>
                            <span id="lblcolorprintdetails" runat="server" style="padding-left: 5.3%; float: left">
                            </span>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                        <asp:Label ID="lblHSNcodeLabel" runat="server"  Text="HSN Code" class="formcontrol inputtextwidth"></asp:Label>
                        </td>
                        <td>
                         <asp:Label ID="lblHSNCode1" runat="server" Text="" class="formcontrol inputtextwidth"></asp:Label>                          
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span class="RemoveStyle">Description</span> <span class="DesLeft" style="padding-left: 10.3%;
                                position: absolute;">
                                <%--<asp:TextBox ID="txtdiscription" runat="server" TextMode="MultiLine" class="textaria" style = "margin-left: 224px;"></asp:TextBox>--%>
                                <asp:Label ID="lblDescription" Height="25px" runat="server" Style="color: Gray;"></asp:Label>
                            </span>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table runat="server" id="tblmeterentry" border="0" style="max-width: 100%; height: 347px;
                width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="classchallan">
                        <%--<table border="0" cellpadding="0" class="supplieretadatetable " cellspacing="0" style="border-top: 0px;
                                    max-width: 348px; min-width: 335px;">
                                    <tr>
                                        <th>
                                            Sr. No.
                                        </th>
                                        <th>
                                            <asp:Label ID="lblunitname" runat="server"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="lblunitshortname" Text="Centimeter" runat="server"></asp:Label>
                                        </th>
                                        <th>
                                            Action
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="width: 36px" class="border_left_color addBottom bottom_border_color_h">
                                        </td>
                                        <td style="width: 42px" class="addBottom bottom_border_color_h">
                                            <asp:TextBox ID="txtmeter" MaxLength="7" Width="100%" onchange="javascript:updatecm(this)"
                                                class="noonly" runat="server" Text="" />
                                        </td>
                                        <td style="width: 63px" class="addBottom bottom_border_color_h">
                                            <asp:TextBox ID="txtcm" Style="background: transparent !important; border: none !important;
                                                outline: none !important; padding: 0px 0px 0px 0px !important;" Enabled="false"
                                                Width="100%" class="noonly" runat="server" />
                                            <asp:HiddenField ID="hdncm" runat="server" />
                                        </td>
                                        <td style="width: 100px; display: none" class="addBottom bottom_border_color_h">
                                            <input type="image" id="dele" o />
                                        </td>
                                        <td style="width: 41px" class="border_right_color addBottom bottom_border_color_h">
                                            <asp:ImageButton ID="ImgBtnadd"  ImageUrl="../../images/add-butt.png"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>--%>
                        <br />
                        <asp:GridView ID="grdmaster" CssClass="table gridClass" runat="server" ShowHeader="false"
                            Style="min-width: 335px; max-width: 335px">
                            <RowStyle CssClass="grdmasterRow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblserial" runat="server" Text='<%#Eval("SrNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtcenter border_left_color" Width="44px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meter">
                                    <ItemTemplate>
                                        <%# Eval("Meter")%>
                                        <asp:HiddenField ID="hdnmtr" runat="server" Value='<%#Eval("Meter")%>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtcenter" Width="50" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CM">
                                    <ItemTemplate>
                                        <%# Eval("CM")%>
                                        <asp:HiddenField ID="hdncentimtr" runat="server" Value='<%#Eval("CM")%>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtcenter" Width="76" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td valign="top">
                        <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="false"
                            Width="239px">
                            <RowStyle CssClass="MasterRow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblserial" runat="server" Text='<%#Eval("SrNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtcenter border_left_color" Width="37px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meter">
                                    <ItemTemplate>
                                        <%# Eval("Meter")%>
                                        <asp:HiddenField ID="hdnmtr" runat="server" Value='<%#Eval("Meter")%>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtcenter" Width="40" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CM">
                                    <ItemTemplate>
                                        <%# Eval("CM")%>
                                        <asp:HiddenField ID="hdncentimtr" runat="server" Value='<%#Eval("CM")%>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="txtcenter" Width="64" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <table runat="server" class="NoTotalTable" visible="false" id="tblisdayed" style="max-width: 100%;
            width: 100%; float: left; padding-bottom: 0px; border: none; margin-bottom: 10px;
            margin-top: -1px;" cellspacing="0" cellpadding="0">
            <tbody>
                <tr>
                    <td class="rightborder" style="width: 13%; padding-left: 5px; color: gray">
                        No. of Items
                    </td>
                    <td class="rightborder thanvalue" style="width: 10%;">
                        <%--<asp:TextBox ID="txtthanvalue" runat="server" Style="width: 50px; height: 17px;"
                                    MaxLength="5" class="noonly formcontrol numeric-field-without-decimal-places"></asp:TextBox>--%>
                        <asp:Label ID="txtthanvalue" Style="font-size: 10px; cursor: pointer; color: blue;
                            width: 7% !important; height: 16px; text-align: center;" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlthanunitsvalue" Enabled="false" CssClass="thanunist" Style="display: none;"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="rightborder" style="width: 15%">
                        <asp:Label ID="lbldebitnochallacaption" ForeColor="Gray" Text="Quantity Unit" runat="server"></asp:Label>
                    </td>
                    <td class="rightborder" style="width: 20%">
                        <%--<asp:TextBox ID="txtqtytotal" MaxLength="8" AutoPostBack="true" 
                                    runat="server" Style="background: #fff; width: 59px;" class="formcontrol noonly"></asp:TextBox>--%>
                        <asp:Label ID="txtqtytotal" Style="background: #fff; width: 59px;" runat="server"></asp:Label>
                        <b>
                            <asp:Label ID="lblinternalconverttounit" ForeColor="gray" Visible="false" runat="server"></asp:Label></b>
                        <%--<b>
                                    <asp:Label ID="lblinternaldefualtremaningqty" ForeColor="gray" Visible="false" runat="server"></asp:Label></b>--%>
                        <%--<asp:Label ID="lblinternaldefualtunit" Visible="false" ForeColor="gray" runat="server"></asp:Label>--%>
                        <b>
                    </td>
                    <td class="rightborder" id="tdRightBorder" runat="server" style="width: 33%">
                        <asp:Label ID="lblavailbledebittext" Visible="false" ForeColor="Gray" runat="server"
                            Text="Available Qty: "></asp:Label><asp:Label Visible="false" ID="lblavailableqtydebitchallan"
                                runat="server"></asp:Label>
                        <b>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblavailabelqtyunitname" ForeColor="gray" Visible="false"
                            runat="server"></asp:Label></b>
                        <asp:HiddenField ID="hdndebitavailebaleqty" runat="server" Value="0" />
                        <b>&nbsp;&nbsp;&nbsp;<asp:Label Visible="false" ID="lbldebitdefualtqty" runat="server"></asp:Label>
                            <asp:Label ID="lbldebitdefualtunitstaticinfo" ForeColor="gray" Visible="false" runat="server"></asp:Label></b>
                    </td>
                </tr>
            </tbody>
        </table>
        <div id="divsend" visible="false" runat="server" style="border-top: 0px;">
            <span style="padding-left: 2px; color: gray" id="sendqtyy" runat="server"></span>
            <%--<asp:TextBox ID="txtsendqtyforinfo" runat="server" MaxLength="6" Style="font-size: 10px;
                        cursor: pointer; color: blue; width: 7% !important; height: 16px; text-align: center;"
                        class="anyNumber" title="Send Qty"> </asp:TextBox>--%>
            <asp:Label ID="txtsendqtyforinfo" Style="font-size: 10px; cursor: pointer; color: blue;
                width: 7% !important; height: 16px; text-align: center;" runat="server"></asp:Label>
            <b>
                <asp:Label ID="lblconverttounit" ForeColor="gray" runat="server"></asp:Label></b>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lbldefualtremaningqty" ForeColor="gray"
                runat="server"></asp:Label>
            <b>
                <asp:Label ID="lbldefualtunit" ForeColor="gray" runat="server"></asp:Label></b>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblsendreaming" runat="server"></asp:Label>
            <asp:HiddenField ID="hdndefaultunit" runat="server" />
            <asp:HiddenField ID="hdnconverttounit" runat="server" />
            <asp:HiddenField ID="hdnconversionvalue" runat="server" />
            <asp:HiddenField ID="hdnoldqty" runat="server" />
            <b><span style="margin-left: 8px;">
                <asp:Label ID="lbldefualtunitstaticinfo" ForeColor="gray" runat="server"></asp:Label>
                <asp:Label ID="lbldefualtinitinfo" ForeColor="gray" runat="server"></asp:Label></span>
            </b>
        </div>
        <table class="MarginTop8" style="max-width: 100%; font-size: 12px; width: 100%; margin-left: 1px;
            margin-top: 5px; border: none; border-top: 0px solid #999;" cellspacing="0" cellpadding="0">
            <thead>
                <tr>
                    <td colspan="" style="padding: 5px 0px 5px 10px; width: 59%;" class="headerbold">
                        Received the goods in good condition
                    </td>
                    <td style="padding: 5px 10px 5px; text-align: right" colspan="">
                        <span class="texttranceform"><b>Boutique International Pvt. Ltd.</b></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="" class="PaddingTop0 headerbold" style="padding-top: 0px; padding-left: 5px;
                        font-size: 11px; color: #6b6464">
                        <div runat="server" id="divChkReceive">
                            <asp:CheckBox ID="chkrecivegood" runat="server" />
                            Receiver's Signature
                        </div>
                        <div runat="server" id="divSigReceive" visible="false">
                            <asp:Image ID="imgReceiver" runat="server" Height="40px" Width="125px" />
                            <br />
                            <asp:Label ID="lblReceiverName" runat="server" Style="line-height: 20px;"></asp:Label>
                            <br />
                            <asp:Label ID="lblReceivedOnDate" runat="server"></asp:Label>
                        </div>
                    </td>
                    <td class="PaddingTop0 headerbold signauth" style="float: right; padding-top: 0px;
                        padding-right: 15px; font-size: 11px; color: #6b6464">
                        <div runat="server" id="divChkAuthorized">
                            <asp:CheckBox ID="chkAuthorised" runat="server" />
                            Authorized Signature
                        </div>
                        <div runat="server" id="divSigAuthorized" visible="false">
                            <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="110px" />
                            <br />
                            <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                            <br />
                            <asp:Label ID="lblAuthorizedOnDate" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
            </thead>
        </table>
    </div>
    </form>
</body>
</html>
