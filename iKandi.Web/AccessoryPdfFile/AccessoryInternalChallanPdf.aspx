<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryInternalChallanPdf.aspx.cs" Inherits="iKandi.Web.AccessoryPdfFile.AccessoryInternalChallanPdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Accessory Internal Challan Pdf</title>
    <link href="../../css/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input
        {
            border-radius: 2px;
            border: 1px solid #999;
            padding-left: 3px !important;
        }
        body
        {
            font-family: Arial !important;
        }
        .debitnote-table
        {
            font-family: Arial !important;            
        }
        .debitnote-table .top_heading
        {
            text-transform: capitalize;
            font-size: 15px;
            font-weight: 500;
            padding-top: 2px;
            text-align: center;
            padding-bottom: 3px;
            background: #39589c;
            color: #fff;
            width:100%;
        }
        .debitnote-table .address_head
        {
            font-weight: 500;
            font-size: 11px;
            line-height: 15px;
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
        }
        tbody td.borderbottom
        {
            border-bottom: 1px solid #9999;
            border-left: 1px solid #9999;
            padding: 2px 3px;
            font-size: 11px;
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
        }
        .tablewidth
        {           
            padding: 0px 3px 5px;
            border-bottom: 1px solid #9999;
        }
        .tableto
        {
            width: 80px;
        }
        .bottomborder
        {
            border-bottom: 1px solid #9999;
            padding: 10px 5px;
        }
        .listwidth
        {
            width: 80px;
        }
        tbody td.bordertable
        {
            border-bottom: 1px solid #9999;
            border-left: 1px solid #9999;
            padding: 2px 3px;
            font-size: 11px;
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
            padding: 0px 3px;
        }
        .textaria
        {
            width: 82%;
        }
        .inputfield
        {
            width: 95%;
        }
        .bottomborder1
        {
            border-bottom: 1px solid #9999;
            text-align: center;
        }
        .rightborder
        {
            border-right: 1px solid #9999;
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
            font-size: 11px;
            height: 20px;
            font-weight: 500;
            color: #6b6464;
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
            border-left: 1px solid #9999;
        }
        .borderleft0bottom
        {
            border-bottom: 0px solid #9999;
            color:gray
        }
        .metersr tbody td
        {
            height: 13px;
        }
        .meterQury thead th
        {
            border: 1px solid #999;
            text-align: center;
            font-weight: 500;
        }
        /* .meterQury tbody td
        {
            border:1px solid #9999;
            text-align:center;
        }*/
        .tabletdhei
        {
            height: 16px !important;
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
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
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
        .btnPrint:hover
        {
            color: Yellow !important;
        }
       
      
        .FrstHeader
        {
            width: 23% !important;
        }
        .LasttHeader
        {
            width: 21% !important;
        }        
        .txtEditWidth
        {
            text-align: center;
        }
        td #chkProcess td
        {
            padding: 0px 6px 0px 0px !important;
            color:#000
        }
       
        input[type='text']
        {
            padding-left: 3px;
        }
        .spanHdrColor
        {
            color: Gray;
        }
        #chkProcess input[type="checkbox"]
        {
            position:relative;
            top:2px;
         }
         .RightColumnWidth
         {
             width:75%;
         }
         .LeftColumnWidth
         {
             width:25%;
         }
         .HideArrowAndBorder
        {
            -webkit-appearance: none;
            border:0px;       
        }
    </style>
  
</head>
<body>
    <form id="form1" runat="server">
    <div class="debitnote-table" style="max-width: 100%; margin: 0px auto; border: 0px solid #999;">

                <table cellpadding="0" cellspacing="0" style="max-width: 100%; width: 100%; border: none;
                    border: 1px solid #999999; border-bottom: 0px;">
                    <thead>
                        <tr>
                            <td style="border-bottom: 1px solid #999999;">
                            </td>
                            <td class="top_heading texttranceform bottomborder1" colspan="">
                                Accessory challan
                            </td>
                        </tr>
                    </thead>
                </table>

                <table class="TableWidthCha" style="max-width: 100%; width: 100%; border: none;
                    border: 1px solid #999999; border-top: 0px;border-bottom: 0px; float: left" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td style="vertical-align: top; width: 125px; border-bottom: 1px solid #9999" colspan='2'>
                                <div style="padding: 9px 7px">
                                    <asp:Image ID="boutiqueImg" runat="server" />
                                    <%--<img src="../../images/boutique-logo.png" />--%>
                                
                                <div id="divbipladdress" runat="server" style="padding-top: 5px;margin-top: -63px;margin-left: 130px;"></div>
                                </div>
                            </td>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="LeftColumnWidth">
                             <div class="spanHdrColor">
                                    Challan No:</div>
                            </td>
                            <td class=" texttranceform borderleft0bottom RightColumnWidth" style="height: 13px;">
                                <asp:Label ID="lblChallan" Font-Bold="true" ForeColor="Black" runat="server" Text="" ></asp:Label>
                               
                            </td>
                            <asp:HiddenField ID="hdnChallan" runat="server" />
                            <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" />
                        </tr>
                        <tr id="trPO" runat="server">
                           <td class=" texttranceform borderleft0bottom LeftColumnWidth">
                            <div class="spanHdrColor">
                                    PO No:</div>
                           </td>
                            <td class=" texttranceform borderleft0bottom RightColumnWidth" style="height: 13px;">
                               <asp:Label ID="lblPoNo" runat="server" Text="" ></asp:Label>                                
                            </td>
                        </tr>   
                        <%--rajeev --%>
                          <tr id="tr1" runat="server">
                            <td class=" texttranceform borderleft0bottom">
                                <span runat="server" id="spn_HSNCode"></span>
                            </td>
                            <td class=" texttranceform borderleft0bottom" style="height: 13px;">
                                 <asp:Label ID="lblHSNCode" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <%--rajeevs ---%>                     
                        <tr>   
                        <td>
                          <div class="spanHdrColor LeftColumnWidth">
                                    Date:
                           </div>
                        </td>                      
                          <td class=" texttranceform borderleft0bottom RightColumnWidth">
                               
                                <%--<asp:TextBox ID="txtChallanDate" Width="88px" runat="server" CssClass="do-not-allow-typing PODate"
                                    Style="text-transform: capitalize;border:0px;"></asp:TextBox>--%>
                                <span style=""> <asp:Label ID="lblChallanDate" runat="server" Style="border: 0px;height:12px;" ></asp:Label></span> 
                            </td>
                        </tr>
                        <tr>
                         <td class="borderleft0bottom LeftColumnWidth"> Select: </td>
                            <td class=" texttranceform borderleft0bottom RightColumnWidth" style="height: 18px;padding:3px 0px">
                                <%--<asp:CheckBoxList ID="chkProcess" RepeatDirection="Horizontal" RepeatColumns="4"
                                    runat="server" style="margin-left:2px;">
                                </asp:CheckBoxList>--%>
                                <asp:Label ID="lblCheckedList" runat="server"  style="margin-left: 3px" Text="Cutting"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="borderleft0bottom spanHdrColor LeftColumnWidth" >
                               <span style="font-weight:bold;">To:</span>&nbsp;
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="HideArrowAndBorder">
                                    <asp:ListItem Value="1" Text="External"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Internal"></asp:ListItem>
                                </asp:DropDownList>
                                
                                <asp:HiddenField ID="hdnType" Value="0" runat="server" />
                            </td>
                            <td class="borderleft0bottom RightColumnWidth">
                            <span style="font-weight:bold;;">M/S:</span><span style="color: Red; font-size: 12px;">*</span> &nbsp;
                            <div id="dvUnit" runat="server" style="display:inline-block">
                                 <asp:DropDownList ID="ddlProductionUnit" runat="server">
                                    </asp:DropDownList>
                                </div>
                                 <div id="dvSupplier" class="spanHdrColor" runat="server" style="display:inline-block">                                   
                                        <asp:Label ID="lblSupplierName" ForeColor="Black" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                        <td class="borderleft0bottom spanHdrColor LeftColumnWidth" ></td>
                            <td class='RightColumnWidth'>
                                <div id="dvStyle" runat="server" >
                                    <span class="spanHdrColor" style="display: inline-block; width: 130px">Style No: &nbsp;
                                        <asp:Label ID="lblStyleNo" ForeColor="Black" runat="server"></asp:Label>
                                    </span><span class="spanHdrColor">Serial No: &nbsp;
                                        <asp:Label ID="lblSerialNo" ForeColor="Black" runat="server"></asp:Label>
                                    </span>
                                </div>                               
                            </td>
                        </tr>
                        <tr>
                        <td class='borderleft0bottom LeftColumnWidth' style="display:none;">
                           Accessory (Size)/Color Print:
                        </td>
                            <td class="borderleft0bottom spanHdrColor RightColumnWidth" style="text-align: left; ">
                                <span >
                                    <asp:Label ID="lblAccessoryQuality" style="vertical-align:middle;" ForeColor="Blue" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblSize" style="vertical-align:middle;" ForeColor="Gray" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblcolorprint" style="vertical-align:middle;" Height="15px" Font-Bold="true" ForeColor="Black" Text=""
                                        runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnSize" runat="server" />
                                </span>
                            </td>
                        </tr>
                        <tr>
                         <td class="spanHdrColor LeftColumnWidth" style="padding-bottom:26px;vertical-align: top;padding-top: 5px;" runat="server" id="td_Description" visible="false">Description:</td>
                            <td class="spanHdrColor RightColumnWidth" style="padding-bottom:26px;padding-top: 5px;">
                                 <span >
                                    <%--<asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="98%" runat="server"
                                        Style="margin-top: 1px; text-transform: lowercase;"></asp:TextBox>--%>
                                        <asp:Label ID="lblDescription" Height="25px" runat="server" style="color:Gray"></asp:Label>
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>                  
             
                <table style="max-width: 100%; width: 100%; padding-bottom: 0px; border: none; margin-bottom: 10px;
                    border: 1px solid #999999; border-top: 1px solid #999999" cellspacing="0" cellpadding="0" id="old_table" runat="server" visible="false">
                    <tbody>
                        <tr>
                            <td class="rightborder spanHdrColor">
                                No. of Items:
                                <asp:Label ID="lblTotalUnit" runat="server"></asp:Label>
                            </td>
                            <td class="rightborder spanHdrColor" style="">
                                <%--<asp:TextBox ID="txtTotalUnit" ForeColor="Gray" Font-Bold="true" MaxLength="4" onkeypress="return isNumberKey(event)"
                                    Width="80px" runat="server"></asp:TextBox>--%>
                                    
                                <asp:HiddenField ID="hdnRowCount" Value="0" runat="server" />
                                <span style="color: gray">Rolls/Boxes</span>
                            </td>
                            <td class="rightborder spanHdrColor">
                                Total Qty.
                                <%--<asp:TextBox ID="txtChallanQty" onchange="ChangeChallanQty(this)" onkeypress="return isNumberKey(event)" MaxLength="6"  Width="80px" runat="server"></asp:TextBox>--%>
                                <asp:Label ID="lblChallanQty"  runat="server"></asp:Label>

                                <asp:Label ID="lblUnitName" Style="text-transform: capitalize; color: gray; font-weight: bold;"
                                    runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnTotalPcs" Value="0" runat="server" />                                
                            </td>
                            <td class="rightborder spanHdrColor" style="" id="tdAvailableQty" runat="server">
                                Available Qty.
                                <asp:Label ID="lblAvailableQty" runat="server"></asp:Label>
                                <asp:Label ID="lblAvailableQtyUnit" Style="text-transform: capitalize; color: gray;
                                    font-weight: bold; margin-left:3px" runat="server"></asp:Label>                                   
                                <asp:HiddenField ID="hdnRemainingQty" Value="0" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>

                <%--New Table Start Girish--%>
       
                <asp:GridView ID="GridView1" runat="server"  EnableModelValidation="True"
                    AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#CC9966"
                    BorderStyle="None" BorderWidth="1px" OnDataBound="GridView1_DataBoundEvent">
                    <Columns>

                        <asp:TemplateField HeaderText="AccessoryName">
                            <ItemStyle Width="250px" />
                            <ItemTemplate>
                                <%# Eval("AccessoryName") %>
                                <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" Value='<%# Eval("AccessoryMaster_Id") %>' />  
                            </ItemTemplate>                            
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Size">
                            <ItemStyle Width="80px" />
                            <ItemTemplate>
                                <%# Eval("size")%>
                                <asp:HiddenField ID="hdnSize" runat="server" Value='<%# Eval("size") %>' />
                            </ItemTemplate>                             
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ColorPrint">
                            <ItemStyle Width="80px" ForeColor="#000000" />
                            <ItemTemplate>
                                <%# Eval("Color_Print")%>
                                <asp:HiddenField ID="hdnColorPrint" runat="server" Value='<%# Eval("Color_Print") %>' />
                            </ItemTemplate>                            
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Contract No.">
                            <ItemStyle Width="80px" ForeColor="#000000" />
                            <ItemTemplate>
                                <%# Eval("ContractNumber")%>
                            </ItemTemplate>                            
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Order Qty.">
                            <ItemStyle Width="60px" Font-Bold="true" />
                            <ItemTemplate>                                
                                <%# Convert.ToInt32(Eval("Quantity")).ToString("N0") %>
                                <asp:HiddenField ID="hdnOrderDetailId" runat="server" Value=' <%#  Eval("OrderDetailID") %>' />
                            </ItemTemplate>                             
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Available Qty.">
                            <ItemStyle Width="100px" ForeColor="#000000" />
                            <ItemTemplate>
                                <%# Eval("AvailableQty").ToString() == "0.00" ? "" : Convert.ToDecimal(Eval("AvailableQty")).ToString("#,##.##") + " <span style='color:#808080;'>" + Eval("ShortUnitName").ToString() + "</span>" %>
                                <asp:HiddenField ID="hdnAvailableQty" runat="server" Value=' <%# Eval("AvailableQty").ToString() == "0.00" ? "" : Eval("AvailableQty") %>' />
                            </ItemTemplate>                             
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="No. Of Items">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtNoOfItems" Style="width: 80%" onkeyPress="return isNumberKey(this,event)" onChange="calculateTotal(this.id)" Text='<%# Eval("NoOfItems").ToString() == "0" ? "" : Eval("NoOfItems")  %>' ReadOnly='<%# Eval("ReadOnly") %>'></asp:TextBox>
                            </ItemTemplate>                           
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Issued Qty.">
                            <ItemStyle Width="124px" />
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtQtyToIssue" Style="width: 65%;" onkeyPress="return isNumberKey(this,event)" onChange="return ValidateIssueQty(this,event)" Text='<%# Eval("QtyToIssue").ToString() == "0" ? "" : Convert.ToDecimal(Eval("QtyToIssue")).ToString(".##") %>' ReadOnly='<%# Eval("ReadOnly") %>' MaxLength="12"></asp:TextBox>
                                <span style='color:#808080' id="shortunit" runat="server"><%# Eval("AvailableQty").ToString() == "" ? "" : Eval("ShortUnitName").ToString()%></span>
                            </ItemTemplate>                          
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description">
                            <ItemStyle Width="200" />

                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" Style="width: 98%;border: none;" Text='<%# Eval("Description") %>' ReadOnly ='<%# Eval("ReadOnly") %>'></asp:TextBox>
                            </ItemTemplate>                          
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="#DDDFE4" Font-Bold="True" ForeColor="#808080"  />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                </asp:GridView>
                <br />
                <div style="float:left;width:50%;display:inline-block;" runat="server" id="div_TotalNoOfItems" visible="false"><span style="font-weight:bold;margin-left:53%;" >Total No. Of Items :</span><span id="span_TotalNoOfItems" runat="server"></span></div>
                <div><span style="font-weight:bold;margin-left:5%;" runat="server" id="div_TotalIssuedQty" visible="false">Total Issued Qty :</span><span id="span_Total_Issued_Qty" runat="server"></span></div>               
          
          <%--New Table End Girish--%>

                <table class="MarginTop8" style="max-width: 100%; margin-bottom: 10px; font-size: 12px;
                    width: 100%; margin-top: 5px; border: none; border-top: 0px solid #999;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="" style="padding: 5px 0px 5px 10px; width: 60%;" class="headerbold">
                                Received the goods in good condition
                            </td>
                            <td style="padding: 5px 10px 5px; text-align: right" colspan="">
                                <span class="texttranceform"><b>Boutique International Pvt. Ltd.</b></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="" class="PaddingTop0 headerbold" style="padding-top: 0px; padding-left: 12px;
                                font-size: 11px; color: #6b6464">
                                <div runat="server" id="divChkReceive">
                                    <asp:CheckBox ID="chkrecivegood" runat="server" />
                                    (Receiver's Signature)
                                </div>
                                <div runat="server" id="divSigReceive" visible="false">
                                    <asp:Image ID="imgReceiver" runat="server" Height="40px" Width="130px" />
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
                                    (Authorized Signature)
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
