<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Fitting.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.Fitting" %>
<%@ Register Src="~/UserControls/Forms/InlineTopSection.ascx" TagName="InlineTopSection" TagPrefix="uc1" %>

<%--
      <link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />
<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>--%>

 <script type="text/javascript">

     $(function () {
         $(".th").datepicker({ dateFormat: 'dd M y (D)' });

     });
  
  </script>

        <script type="text/javascript">



            function ValidateFitForm() {
                if ($("#txtIsIkandiUser").val() == "0") return true;
            }

            function IsFileUploaded(source, arguments) {
                //debugger;                
                if ($("#txtIsIkandiUser").val() == "0")
                    arguments.IsValid = true;

                var objFile = $(source).parents("TD").find("input[type=file]");

                if (objFile.val().length == 0)
                    arguments.IsValid = false;
                else
                    arguments.IsValid = true;
            }



            function Fits_CreateNew() {
                //debugger; 

                window.document.body.disabled = false;
                document.getElementById('<%=hdnFitsCreateNew.ClientID%>').value = "1";
                $('#<%= hdnFitsReUse.ClientID %>').val('0');
                $('#<%= hdnFitsNewRef.ClientID %>').val('0');

                $(".btnthisFits").click();
            }

            function Fits_NewRefrence(NewStyleID, NewStyleNumber) {
                //debugger;
                window.document.body.disabled = false;
                $('#<%= hdnFitsNewRef.ClientID %>').val('1');
                $('#<%= hdnFitsReUse.ClientID %>').val('0');
                $('#<%= hdnFitsCreateNew.ClientID %>').val('0');
                $('#<%= hdnFitsStyleId.ClientID %>').val(NewStyleID);
                $('#<%= hdnFitsStyleNumber.ClientID %>').val(NewStyleNumber);
                $(".btnthisFits").click();

            } function Fits_ReUse(ReUseStyleID, ReUseStyleNumber) {
                //debugger;
                window.document.body.disabled = false;
                $('#<%= hdnFitsReUse.ClientID %>').val('1');
                $('#<%= hdnFitsNewRef.ClientID %>').val('0');
                $('#<%= hdnFitsCreateNew.ClientID %>').val('0');
                $('#<%= hdnFitsStyleId.ClientID %>').val(ReUseStyleID);
                $('#<%= hdnFitsStyleNumber.ClientID %>').val(ReUseStyleNumber);
                $(".btnthisFits").click();

            }

            function OpenPopupForFits(StyleCodeVirsion, StyleId, DeptId) {
                //debugger;
                var StyleId = StyleId;
                var StyleNumber = StyleCodeVirsion;
                var ClientId = '<%=this.strClientId %>';
                var DeptId = DeptId;

                var url = '../../Internal/OrderProcessing/FittingPopup.aspx?styleid=' + StyleId + '&stylenumber=' + StyleNumber + '&ClientID=' + ClientId + '&DeptId=' + DeptId + '';
                window.open(url, '_blank', 'height=500,width=1000,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
                return false;
            }

            function validateSave() {       //
                //debugger;
                if (document.getElementById('<%=chkSpecs.ClientID %>').checked == true) {
                    var t1 = Page_ClientValidate("submit");
                    if (!t1) {
                        return false;
                    }
                    return true;
                }
                alert('Please check the Spec Upload checkbox in order to submit the form');
                return false;
            }


            function Checkvalidation(elem) {
                str = elem.value;
                if (str.match(/([\<])([^\>]{1,})*([\>])/i) == null) {
                }
                else {
                    alert("HTML Tag Not Allowed");
                    elem.value = elem.defaultValue;
                    return false;
                }
            }

</script>
 <style type="text/css">
      
       
        .bipl-sec
        {
            border-bottom:0px !Important;
            border-top:0px !important;        
            
        }
        
        .bipl-sec td 
        {
            border-bottom:1px solid #666666;            
        }
        
       
        
    </style>

<div id="dvFitting" runat="server">

   
  <div style="margin:0px; font-size:16px; padding:5px 0px; width:100%;" class="fittingcontainer">
       BASIC INFORMATION: 
            <asp:Label ID="lblFitsBasicInformation" runat="server" Text=""></asp:Label></div>
            <br />
 <div align="left">
                     
                     <div id="dvGvFits" runat="server" class="scroll-field">     
                       
                     <asp:GridView ID="gvFits" runat="server" AutoGenerateColumns="false" CssClass="fixed-header item_list" onrowdatabound="gvFits_RowDataBound" >
    <Columns>

    <asp:TemplateField HeaderText="<label>&nbsp;Serial No.</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Top">
    <ItemTemplate >
    <div style="width:60px !important; float:left;">
        <asp:Label ID="lblCalBIH"  runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
        </div>
    </ItemTemplate>
    <HeaderStyle Width="60px"></HeaderStyle>
    <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<label>&nbsp;Style No.</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Top">
    <ItemTemplate>
    <div style="width:60px !important; float:left; height:20px;">
        <asp:Label ID="lblSDate" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>
    </div>
    </ItemTemplate>
    <HeaderStyle Width="60px"></HeaderStyle>
    <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;Contract No.<br/>&nbsp;&nbsp;&nbsp;Quantity</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Top">
    <ItemTemplate>
     <div style="width:90px !important; float:left; text-align:center;">
        <asp:Label ID="lblContractNumber"  runat="server" Text='<%# Eval("ContractNumber")%>'></asp:Label><br />
        <asp:Label ID="lblQuantity"  runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
        </div>
    </ItemTemplate>
    <HeaderStyle Width="80px"></HeaderStyle>
    <ItemStyle Width="80px" CssClass="newcss2"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fabric</label><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;<br/>Quality/Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Eta"  HeaderStyle-VerticalAlign="Top"  ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
    <ItemTemplate> 
    <div style="width:100%; height:20px; font-weight:bold;">
                B.I.H:&nbsp;&nbsp;<asp:Label ID="lblBIH" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIH")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIH")).ToString("dd MMM (ddd)")%>'></asp:Label>
                </div> 
                <div  style="width:100%;">          
    <table width="100%" cellpadding="0" cellspacing="0">                
        <tr id="tbl1"  runat="server" visible="false">
        <td align="left" style="width:250px !important; float:left;"> 
        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
        <tr>
        <td align="left" style="text-align:left;" id="tdFabric1" runat="server"><asp:Label ID="lblFabric1" runat="server" Text='<%# Eval("Fabric1")%>'></asp:Label></td>
        <td colspan="2" id="tdprint1" runat="server"><asp:Label ID="lblFabric1Percent" runat="server" Text='<%# Eval("FabricPercent1")%>'></asp:Label></td>
        </tr>
        <tr>
        <td style="text-align:left;" id="tdFabric1DetailsRef" runat="server"><asp:Label ID="lblFabric1DetailsRef" runat="server" Text='<%# Eval("Fabric1Details")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricStartETAdate1" runat="server"><asp:Label ID="lblFabricStartETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricEndETAdate1" runat="server"><asp:Label ID="lblFabricEndETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr  id="tbl2"  runat="server" visible="false">
        <td align="left" style="width:250px !important; float:left;">
        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
        <tr>
        <td align="left" id="tdFabric2" runat="server"><asp:Label ID="lblFabric2" runat="server" Text='<%# Eval("Fabric2")%>'></asp:Label></td>
        <td colspan="2" id="tdFabric2Percent" runat="server"><asp:Label ID="lblFabric2Percent" runat="server" Text='<%# Eval("FabricPercent2")%>'></asp:Label></td>
        </tr>
        <tr>
        <td style="text-align:left;" id="tdFabric2DetailsRef" runat="server"><asp:Label ID="lblFabric2DetailsRef" runat="server" Text='<%# Eval("Fabric2Details")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricStartETAdate2" runat="server"><asp:Label ID="lblFabricStartETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricEndETAdate2" runat="server"><asp:Label ID="lblFabricEndETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr  id="tbl3"  runat="server" visible="false">
        <td align="left" style="width:250px !important; float:left;">
        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
        <tr>
        <td align="left" style="text-align: left;" id="tdFabric3" runat="server"><asp:Label ID="lblFabric3" runat="server" Text='<%# Eval("Fabric3")%>'></asp:Label></td>
        <td colspan="2" id="tdFabric3Percent" runat="server"><asp:Label ID="lblFabric3Percent" runat="server" Text='<%# Eval("FabricPercent3")%>'></asp:Label></td>
        </tr>
        <tr>
        <td style="text-align:left;" id="tdFabric3DetailsRef" runat="server"><asp:Label ID="lblFabric3DetailsRef" runat="server" Text='<%# Eval("Fabric3Details")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricStartETAdate3" runat="server"><asp:Label ID="lblFabricStartETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricEndETAdate3" runat="server"><asp:Label ID="lblFabricEndETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr  id="tbl4"  runat="server" visible="false">
        <td align="left" style="width:250px !important; float:left;">
        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
        <tr>
        <td  align="left" style="text-align: left;" id="tdFabric4" runat="server"><asp:Label ID="lblFabric4" runat="server" Text='<%# Eval("Fabric4")%>'></asp:Label></td>
        <td colspan="2" id="tdFabric4Percent" runat="server"><asp:Label ID="lblFabric4Percent" runat="server" Text='<%# Eval("FabricPercent4")%>'></asp:Label></td>
        </tr>
        <tr>
        <td style="text-align:left;" id="tdFabric4DetailsRef" runat="server"><asp:Label ID="lblFabric4DetailsRef" runat="server" Text='<%# Eval("Fabric4Details")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricStartETAdate4" runat="server"><asp:Label ID="lblFabricStartETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        <td style="width: 25%;" id="tdFabricEndETAdate4" runat="server"><asp:Label ID="lblFabricEndETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        </table>  
        </div>                   
    </ItemTemplate>
    <HeaderStyle Width="200px"></HeaderStyle>
    <ItemStyle Width="200px" VerticalAlign="Top"  CssClass="newcss2 marginpadding verttop"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accessories</label><br/><br/>Quality&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In House &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Recd &nbsp;&nbsp;Tot &nbsp;&nbsp; Act Dat/End ETA" ItemStyle-VerticalAlign="Top"  HeaderStyle-VerticalAlign="Top">
        <ItemTemplate>
            <div>
            <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
            <td>
            <asp:Repeater ID="rptFitsAccessories" runat="server" onitemdatabound="rptFitsAccessories_ItemDataBound">
            <ItemTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" class="item_list3">
            <tr>
            <td align="left" style="text-align:left;">
            <div style="width:105px; float:left;" id="divAccessoriesName" runat="server">
            <asp:Label ID="lblAccessories" Width="110" runat="server" Text='<%#Eval("AccessoriesName") %>' style="font-size:8px !important; text-transform:capitalize !important;"></asp:Label>
            </div>
            </td>
            <td>
            <div style="width:20px; float:left;" id="divpercentInHouse" runat="server">
            <asp:Label ID="lblPercentInHouse" runat="server" Text='<%#Eval("percentInHouse") %>' style="font-size:8px !important; text-transform:capitalize !important;"></asp:Label>
            </div>
            </td>

            <td>
            <div style="width:60px; float:left;" id="divQuantityAvail" runat="server">                
            
            <asp:Label ID="txtQuantityAvail"  Width="40" style="color:#000000; background-color:transparent; font-size:8px;" runat="server"  Text='<%#Eval("QuantityAvail") %>'></asp:Label>
            </div>
            </td>

           <%-- <td>
            <div style="width:35px; float:left;">
            <asp:Label ID="lblBIHETAAcc"  Width="60" style="font-size:8px; color:#807F80 !important;" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM(ddd)") %>' ></asp:Label>
            </div>
            </td>--%>

            <td>
            <div style="width:35px; float:left;" id="divRequired" runat="server">
            <asp:Label ID="txtRequired"  Width="40" runat="server" Text='<%#Eval("Required") %>' style="font-size:8px !important;background-color:transparent;" ></asp:Label>
            </div>
            </td>

            <td>
            <div style="width:60px; float:left;" id="divAccesoriesETA" runat="server" class="Accessory">
            <asp:Label ID="lblAccessoriesETA"  Width="60" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM (ddd)")%>' runat="server" style="font-size:8px !important; text-transform:capitalize !important;"></asp:Label>
            <asp:TextBox ID="txtAccessoryWorkingDetailID" CssClass="hide_me txtAccessoryWorkingDetailID" runat="server" Text='<%#Bind("AccessoryWorkingDetailID") %>'></asp:TextBox>
                <asp:HiddenField ID="hdnRemark" Value='<%#Eval("BIHETARemark") %>' runat="server" />
            </div>
            </td>
            </tr>
            </table>
            </ItemTemplate>
                            
            </asp:Repeater>
            </td>
            </tr>
            </table>
            <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value='<%#Eval("OrderDetailID") %>' />
            </div>
        </ItemTemplate>

        <HeaderStyle Width="200px"></HeaderStyle>
    <ItemStyle Width="200px" CssClass="newcss2 marginpadding"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Technical</label><br/><br/>Deliverable&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ETA" ItemStyle-VerticalAlign="Top"  HeaderStyle-VerticalAlign="Top">
            <ItemTemplate>
            <div style="width: 150px; vertical-align:text-top; font-weight:bold; height:30px; text-align:left;">
                            PCD:&nbsp;&nbsp;<asp:Label ID="lblPCD" runat="server" Text='<%# (Convert.ToDateTime(Eval("PCD")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PCD")).ToString("dd MMM (ddd)")%>'></asp:Label>
                            <%--Added By Ashish on 4/3/2015--%>
                            &nbsp;&nbsp;
                            Fits:&nbsp;&nbsp;<asp:Label ID="lblFitsDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("FitsStatusETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FitsStatusETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                            <%--END--%>
                           </div>

            <div style="width: 150px; vertical-align:text-top;">
            <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
            <tr>
            <td style="text-align:left; width:90px;" id="tdstc" runat="server">Stc</td>
            <td id="tdLabel6" runat="server"><asp:Label ID="Label6" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("STCETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("STCETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
            </tr>
            <tr>
            <td style="text-align:left;" id="tdPatternSample" runat="server">Pattern Sample</td>
            <td id="tdPatternETA" runat="server"><asp:Label ID="lblPatternETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
            </tr>
            <tr>
            <td style="text-align:left;" id="tdtop" runat="server">TOP Sent</td>
            <td id="tdTOPETA" runat="server"><asp:Label ID="lblTOPETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
            </tr>
            </table>
            </div>
            </ItemTemplate>
            <HeaderStyle Width="150px"></HeaderStyle>
        <ItemStyle Width="150px" CssClass="newcss2 marginpadding"></ItemStyle>
        </asp:TemplateField>
        <%--abhishek hide production sec 13/1/2016--%>

    <asp:TemplateField Visible="false" HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Production</label><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End ETA" ItemStyle-VerticalAlign="Top"  HeaderStyle-VerticalAlign="Top">
                    
        <ItemTemplate>
        <div style="vertical-align:top; width: 215px; font-weight:bold; height:20px;">
        Ex Fac:&nbsp;&nbsp;<asp:Label ID="lblExFactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("ExFactory")).ToString("dd MMM (ddd)")%>'></asp:Label>
                <%--<asp:TextBox ID="txtOrderId" CssClass="hide_me" runat="server" Text='<%#Bind("OrderID") %>'></asp:TextBox>--%>
                <asp:TextBox ID="txtStyleID" CssClass="hide_me" runat="server" Text='<%#Bind("StyleID") %>'></asp:TextBox>
        </div>

        <div style="vertical-align:top; width: 215px;">
        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                    
        <tr>
        <td style="text-align:left; width: 65px;" id="tdCutReady" runat="server"><asp:Label ID="lvlCutReady" runat="server" Text="Cut Ready"></asp:Label></td>
        <td style="width: 30px;" id="tdCutPercentInhouse" runat="server"><asp:Label ID="lblCutPercentInhouse" runat="server" Text='<%#Eval("CutPercentInhouse") %>'></asp:Label></td>
        <td style="width: 60px;" id="tdCutreadyStartETA" runat="server"><asp:Label ID="lblCutreadyStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        <td style="width: 60px;" id="tdCutreadyENDETA" runat="server"><asp:Label ID="lblCutreadyENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        <tr>
        <td style="text-align:left;" id="tdStitched" runat="server"><asp:Label ID="lblStitched" runat="server" Text="Stitched"></asp:Label></td>
        <td id="tdStitchedPercentInhouse" runat="server" ><asp:Label ID="lblStitchedPercentInhouse" runat="server" Text='<%#Eval("StitchedPercentInhouse") %>'></asp:Label></td>
        <td id="tdStichedStartETA" runat="server"><asp:Label ID="lblStichedStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        <td id="tdStichedENDETA" runat="server"><asp:Label ID="lblStichedENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        <tr>
        <td id="tdVA" runat="server" style="text-align:left;"><asp:Label ID="lvlVA" runat="server" Text="V.A."></asp:Label></td>
        <td id="tdVAPercentInhouse" runat="server"><asp:Label ID="lblVAPercentInhouse" runat="server" Text='<%#Eval("VAPercentInhouse") %>'></asp:Label></td>
        <td id="tdVAStartETA" runat="server"><asp:Label ID="lblVAStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        <td id="tdVAENDETA" runat="server"><asp:Label ID="lblVAENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        <tr>
        <td style="text-align:left;" id="tdlPacked" runat="server"><asp:Label ID="lblPacked" runat="server" Text="Packed"></asp:Label></td>
        <td id="tdPackedPercentInhouse" runat="server"><asp:Label ID="lblPackedPercentInhouse" runat="server" Text='<%#Eval("PackedPercentInhouse") %>'></asp:Label></td>
        <td id="tdPackedETA" runat="server" colspan="2"><asp:Label ID="lblPackedETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PackedETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PackedETA")).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        </table>
        </div>
        </ItemTemplate>
        <HeaderStyle Width="215px"></HeaderStyle>
    <ItemStyle Width="215px" CssClass="newcss2 marginpadding"></ItemStyle>
        </asp:TemplateField>  
        <%--end --%>                  
       
    </Columns>
</asp:GridView>          
    
           </div>
            </div>
            <%-- <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                <ContentTemplate>--%>
            <div>
               
              
<div class="form_box" id="div1" style="border:0px;" >
<asp:HiddenField ID="hdnFitsCreateNew" Value="0" runat="server" />
                     <asp:HiddenField ID="hdnFitsReUse" Value="0" runat="server" />
                     <asp:HiddenField ID="hdnFitsStyleId" Value="0" runat="server" />    
                     <asp:HiddenField ID="hdnFitsStyleNumber" Value="0" runat="server" />    
                     <asp:HiddenField ID="hdnFitsNewRef" Value="0" runat="server" /> 
                     <asp:HiddenField ID="hdnBIPLAllowed" Value="0" runat="server" />
                     <asp:HiddenField ID="hdnBiplFilenotupload" Value="0" runat="server" />   
            <div id="div2">
        <br />
       
        <div class="form_box container-detail" >
      <table>
        <tr>
            <td width="45%">
                <b style="color:#666;"> IKANDI BUYING SAMPLE SENT DATE: </b> &nbsp; &nbsp; &nbsp;
                 <asp:TextBox ID="txtTrackDate" runat="server" CssClass="th" style="width:130px !important;"></asp:TextBox>
                <asp:Label ID="lblSpecsUploadedDate" runat="server"  style="width:130px;"></asp:Label>
            </td>
          
            <td width="50%">
                <b style="color:#666;"> UPLOAD BLOCK SPECS : </b> &nbsp; &nbsp; &nbsp;  <asp:FileUpload runat="server" ID="fileUploadSpecs" /> <asp:HyperLink ID="hlkViewMeSpecs" runat="server" Visible="false" Target="_blank"
                        Text="View File"></asp:HyperLink>  <asp:CheckBox ID="chkSpecs" runat="server" />
                
                <asp:HiddenField ID="hdnSpecsUploadedDate" runat="server" />
            </td>
          
          
            <td width="5%">
             <asp:Button ID="btnSaveSpecUpload" runat="server" Text="Save" CssClass="save da_submit_button" 
                    onclick="btnSaveSpecUpload_Click"/>
            </td>
            
          
        </tr>
    </table>
</div>
        <div class="form_heading container-detail" id="div3">
        <asp:Button ID="Button1" runat="server" Style="display: none;" CssClass="btnthisFits" Text="Button" onclick="Button1_Click" />
            <strong>Fits Tracking Stc Target</strong> <span style="font-size: 15px; text-align: right !important;
                color: Black !important; text-transform:uppercase;">(
                <asp:Label ID="lblStc" runat="server" ForeColor="Black"></asp:Label>
                ) </span>
        </div>
        <br />
        <div style="padding-left: 20px;">
          <asp:HiddenField ID="hdnFitsDeptId" runat="server" Value="" />
        <asp:HiddenField ID="hdnMon" runat="server" Value="" />
        <asp:HiddenField ID="hdnTue" runat="server" Value="" />
        <asp:HiddenField ID="hdnWed" runat="server" Value="" />
        <asp:HiddenField ID="hdnThu" runat="server" Value="" />
        <asp:HiddenField ID="hdnFri" runat="server" Value="" />
        <input type='hidden' id="txtIsIkandiUser" value='<%# (IsIKandiUser) ? "1" : "0" %>' />
        <asp:HiddenField ID="hdnIsBiplUser" Value="0" runat="server" />
        
        </div>
        <div class="container-detail">
        <table width="100%" class="form_table" style="border:0px">
        <tr>
        <td width="100%" align="left" style="border:0px;">
         <table cellpadding="0" cellspacing="0" border="0px" style="border:0px">
        <tr><td width="50%" style="font-weight:bold; font-size:14px;" align="center">Buying House</td>
        <td width="50%" style="font-weight:bold; font-size:14px;" align="center">Bipl</td></tr>
        <tr><td colspan="2" width="100%" align="left" style="border:none;">
            <asp:GridView ID="gvBuyingHouse" AutoGenerateColumns="false" 
                CssClass="fixed-header item_list bipl-sec" runat="server" 
                onrowdatabound="gvBuyingHouse_RowDataBound">
              <Columns>

            <asp:TemplateField HeaderText="<label>Fits Comments Sent For</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="136">
            <ItemTemplate >
            
                  <asp:DropDownList ID="ddlFitsComments" runat="server" Enabled="false" style="background:#fff; width:80%; text-align:center;">
                                                    <asp:ListItem Text="FIT 1"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 2"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 3"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 4"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 5"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 1"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 2"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 3"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 1"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 2"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 3"></asp:ListItem>
                                                    <asp:ListItem Text="REF SAMPLE"></asp:ListItem>
                                                    <asp:ListItem Text="SIZE SET"></asp:ListItem>
                                                    <asp:ListItem Text="COUNTER"></asp:ListItem>
                                                </asp:DropDownList>
            
            </ItemTemplate>            
            </asp:TemplateField>  

             <asp:TemplateField HeaderText="<label>Next Planned Fit Date</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="123">
            <ItemTemplate >            
                 <asp:TextBox ID="txtNextPlannedFitDate" runat="server" CssClass="th date_style" style="width:80% !important; border:none !important;"></asp:TextBox>            
            </ItemTemplate>            
            </asp:TemplateField>

              <asp:TemplateField HeaderText="<label>Request</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="130">
            <ItemTemplate >            
                <asp:DropDownList ID="ddlRequest" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRequest_SelectedIndexChanged" style="background:#fff; width:80%; text-align:center;">
                                                    <asp:ListItem Text="FIT 1"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 2"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 3"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 4"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 5"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 1"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 2"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 3"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 1"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 2"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 3"></asp:ListItem>
                                                    <asp:ListItem Text="REF SAMPLE"></asp:ListItem>
                                                    <asp:ListItem Text="STC"></asp:ListItem>
                                                    <asp:ListItem Text="SIZE SET"></asp:ListItem>
                                                    <asp:ListItem Text="COUNTER"></asp:ListItem>
                                                    
                                                </asp:DropDownList>          
            </ItemTemplate>            
            </asp:TemplateField>

             <asp:TemplateField HeaderText="<label>Request Reference Sample</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="115">
            <ItemTemplate >            
                 <asp:CheckBox ID="chkBoxReferenceSample" runat="server" Enabled="false" />         
            </ItemTemplate>            
            </asp:TemplateField>

            <asp:TemplateField HeaderText="<label>Upload File</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="103">
            <ItemTemplate >            
                 <asp:FileUpload runat="server" Width="80px" ID="fileIkandiUpload"  style="float:left;" />
                 <div style="float:right; width:20px;">
                                                    <asp:HyperLink ID="hlkViewMe" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
                                                </div>
                                                <div style="clear:both;"></div>
                                                <div style=" width:80px;">
                                                    <asp:CustomValidator ID="cvIkandiFileUpload" ValidationGroup="submit" runat="server" ClientValidationFunction="IsFileUploaded" ControlToValidate="ddlRequest" Display="Dynamic" ErrorMessage="File upload is required"></asp:CustomValidator>

                                              
                                                </div>
                                                
                                                
            </ItemTemplate>            
            </asp:TemplateField>
               
             <asp:TemplateField HeaderText="" HeaderStyle-BackColor="white" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="12" HeaderStyle-BorderWidth="0">
            <ItemTemplate>            
             
            </ItemTemplate>  
            <ItemStyle CssClass="blank-item" />          
            </asp:TemplateField>

             <asp:TemplateField HeaderText="<label>Fit Planning For</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="89">
            <ItemTemplate >            
                 <asp:Label ID="lblFitPlanningFor" runat="server"></asp:Label>            
            </ItemTemplate>            
            </asp:TemplateField>
         

              <asp:TemplateField HeaderText="<label>Sample Sent on</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="136">
            <ItemTemplate >            
                <asp:CheckBox ID="chkBoxAcknowledge" runat="server" Width="18%" style="display:inline !important;" />
                  <asp:TextBox ID="txtAckDate" CssClass="th date_style" runat="server" style="width:80% !important; float:right"></asp:TextBox>
                  <div style="clear:both"></div>       
            </ItemTemplate>            
            </asp:TemplateField>

             <asp:TemplateField HeaderText="<label>Planned Dispatch Date</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="129">
            <ItemTemplate >
                <asp:TextBox ID="txtPlannedDispatchDate" runat="server" CssClass="th" style="width:90% !important; border:none !important;"></asp:TextBox>
            </ItemTemplate>            
            </asp:TemplateField>

            <asp:TemplateField HeaderText="<label>Suggested Fit Date</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="115">
            <ItemTemplate >            
                <asp:TextBox ID="txtSuggestedFitDate" runat="server" CssClass="th" style="width:90% !important; border:none !important;"></asp:TextBox>
            </ItemTemplate>            
            </asp:TemplateField>

              <asp:TemplateField HeaderText="<label>Upload File</label>" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" HeaderStyle-Width="103">
            <ItemTemplate >            
                <asp:FileUpload runat="server" Width="80px" ID="fileBiplUpload" style="float:left;" />
                 <div style="float:right; width:20px;">
                                                    <asp:HyperLink ID="hlkViewMeBipl" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
                                                </div>
                                                
                                                <div style="clear:both"></div>
                                                <div style=" width:80px;">
                                                    <asp:Label ID="lblValidateFileUpload" ForeColor="Red" runat="server" Text=""></asp:Label>                                                 

                                              
                                                </div>
                                                
                                           
            </ItemTemplate>            
            </asp:TemplateField>

            </Columns>
            </asp:GridView>
             </td></tr>
            </table>
        </td>
        </tr></table>
        </div>

     
    </div>
    </div>

    <asp:Panel ID="pnlStcHide" runat="server" Width="100%">
    <div class="container-detail">
    <table width="100%" class="form_table" border="0" style="border:0px;">
        <caption>
            <h3 style="font-size:12px; text-align:left; width:100%;">
                STC SECTION
            </h3>
            <tr>
                <td width="20%">
                    STC Approved
                    <asp:CheckBox ID="chkBoxStcApproved" runat="server" />
                </td>
                <td width="7%">
                    Comments
                </td>
                <td valign="middle" width="38%">
                    <asp:TextBox ID="txtComments" runat="server" Height="50PX" TextMode="MultiLine" 
                        Width="300px"></asp:TextBox>
                </td>
                <td width="25%">
                    Graded Specs
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td align="left" width="5%">
                    <asp:HyperLink ID="hlkViewMe" runat="server" Target="_blank" Visible="false"> <img src="../../images/view-icon.png" style=" margin-top:5px;" /> </asp:HyperLink>
                </td>
            </tr>
        </caption>
    </table>

    </div>
   
     <div>
     
            
         
                
                <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="0">
                <tr><td>
                 <asp:Repeater ID="repStyleCodeVirsion" runat="server"                      
                       >
                <ItemTemplate>
               
                 <asp:LinkButton ID="lkn1" runat="server">
                           <asp:Label ID="lbl" runat="server" Text='<%#Eval("StyleCodeVirsion")%>'></asp:Label> </asp:LinkButton> &nbsp;
                                               
                        <asp:ImageButton ID="imgPlus" ImageUrl="../../App_Themes/ikandi/images/plus_icon.gif" OnClick="imgPlus_Click" runat="server" />
                        <asp:ImageButton ID="imgMinus" ImageUrl="../../App_Themes/ikandi/images/minus_icon.gif" style="display:none;" OnClick="imgMinus_Click" runat="server" />
                <asp:HiddenField ID="rephdnStyleid" runat="server" Value='<%#Eval("StyleidVirsion")%>' />
                <asp:HiddenField ID="rephdnStylCode" runat="server" Value='<%#Eval("StyleCodeVirsion")%>' />
                <asp:HiddenField ID="hdnDeptId" runat="server" Value='<%#Eval("DepartmentID")%>' />

                 
                </ItemTemplate>
                </asp:Repeater>             
               </td>
               </tr>
               <tr>
               <td>
               <div id="ShowGridPopup" runat="server" style="overflow-y:scroll; width:100%; height:500px;">
                 <div class="container-detail">
          
       <h3>
                    <asp:Label ID="lblHOPPMFittingRemark" runat="server" Text=""></asp:Label>
                   
           </h3>
          
          <asp:GridView ID="GridHOPPMFittingRemark" runat="server" 
                AutoGenerateColumns="False" Width="98%"
        ShowFooter="True" 
        HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" 
                onrowdatabound="GridHOPPMFittingRemark_RowDataBound" GridLines="None" ShowHeader="false"  >
                
        <Columns>

       
          <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
          
                                <ItemTemplate>
                                    <h3> <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal> </h3>
                                    <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFabricId") %>' />                                   
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Width="30px" />
                            </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Remark">
        <ItemTemplate>
                                   
        <asp:Label ID="txtRemarkEdit" ForeColor="#65676d" Style="text-align: left;" BorderStyle="None"
              Width="100%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>           
        </ItemTemplate>
        <ItemStyle Width="95%" />    
        </asp:TemplateField>
     
                           
        </Columns>
       <%-- <EmptyDataTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
        
        <tr style="text-align: center;">
        <td width="29%" style="background-color: #e6e6e6;">
            <asp:Label ID="lblSl" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="txtRemarksEmpty" ForeColor="#65676d" Style="text-align: center;" BorderStyle="None"
                Width="600px" runat="server" />
        </td>
      
        </tr>
        </table>
        </EmptyDataTemplate>--%>
        </asp:GridView>  
            
        </div>
          <div class="container-detail">
          
       <h3>
        <asp:Label ID="lblRiskFittingRemark" runat="server" Text=""></asp:Label>
       </h3>
        <asp:GridView ID="GridRiskFittingRemark" runat="server" AutoGenerateColumns="False" Width="98%"
        ShowFooter="True" 
        HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
        HeaderStyle-HorizontalAlign="Center" 
                onrowdatabound="GridRiskFittingRemark_RowDataBound" GridLines="None" ShowHeader="false" >
        <Columns>
         <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
        <ItemTemplate>
        <h3> <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal> </h3>
        <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFittingId") %>' />
        
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="12%">
        <ItemTemplate>
                                  
        <asp:Label ID="txtRemarkEdit" ForeColor="#65676d" Style="text-align: left;" BorderStyle="None"
            Width="100%" runat="server" Text='<%#Eval("FittingRemark")%>'></asp:Label>
            <asp:HiddenField runat="server" ID="hdn_RiskAccessoryId" Value='<%# Eval("RiskFittingId") %>' />
        </ItemTemplate>
             <ItemStyle Width="95%" />                  
       
                                
        </asp:TemplateField>
      
                           
        </Columns>
     <%--   <EmptyDataTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
        
        <tr style="text-align: center;">
        <td width="29%" style="background-color: #e6e6e6;">
            <asp:Label ID="lblSl" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="txtRemarksEmpty" ForeColor="#65676d" Style="text-align: center;" BorderStyle="None"
                Width="600px" runat="server" />
        </td>
       
        </tr>
        </table>
        </EmptyDataTemplate>--%>
        </asp:GridView>
       </div>
        
            
        </table>
            </div>
            
        </div>
               
               
               
               </td>
               </tr>
               </table>
               
</ContentTemplate>
    </asp:UpdatePanel>  
        </div>

        <div class="container-detail">   
        <h3 style="font-size:12px">  BH Comments(Sealers Pending) </h3>

      <%--  <div class="add_butt"> <asp:HyperLink ID="HyperLink4" runat="server" onclick="ShowLinkBH()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>

    <table width="100%">
     
        <tr style="display:none;">
            <td>
                <asp:TextBox ID="txtCommentsIkandi" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCommentsBIPL" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td colspan="2">
         <div align="left" style="width: 100%; padding: 0px;">
         
        
                   <asp:UpdatePanel ID="UpdatePannelBhRemarks"  UpdateMode="Conditional" runat="server">
 
                    <ContentTemplate> 

                    <asp:GridView ID="grdFitsBhRemarks" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowFooter="True" OnRowDeleting="grdFitsBhRemarks_RowDeleting"
                        HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                        HeaderStyle-HorizontalAlign="Center"
                        OnRowCommand="grdFitsBhRemarks_RowCommand"
                        OnRowDataBound="grdFitsBhRemarks_RowDataBound" GridLines="None" CssClass="fab-row">
                        <Columns>
                            <asp:TemplateField  HeaderStyle-Width="25px">
                                <ItemTemplate>
                                    <h3> <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal> </h3>
                                    <asp:Label ID="lblFitsBHId" style="display:none;" runat="server" Text='<%# Eval("BHId") %>'></asp:Label>
                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                     <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="125px">
                                <ItemTemplate>
                                  
                                    <asp:Label ID="lblRemarkEdit" ForeColor="#65676d" BorderStyle="None" CssClass="capitalize"
                                        Width="125px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                </ItemTemplate>
                               <ItemStyle Width="125px" VerticalAlign="Top" />
                                <FooterTemplate>
                                    <asp:Label ID="lblRemarkFooter"  ForeColor="#65676d" BorderStyle="None" CssClass="capitalize"
                                        Width="125px" runat="server"></asp:Label>
                                </FooterTemplate>
                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                <ItemTemplate>
                                  
                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="#65676d" BorderStyle="None" CssClass="capitalize" TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                        Width="1000px" runat="server" Text='<%#Eval("BHRemark")%>'></asp:TextBox>
                                </ItemTemplate>
                               <ItemStyle Width="1000px" VerticalAlign="Top" />
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRemarkFooter"  ForeColor="#65676d" BorderStyle="None" CssClass="capitalize" MaxLength="1000" onchange="Checkvalidation(this)"
                                        Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkBH()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                       <asp:LinkButton ForeColor="black" ID="lnkDelete"  runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?')" ><img src="../../images/del-butt.png" /> </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                              <ItemStyle Width="50px" />
                                <FooterTemplate>
                                    <div style="text-align: center;">
                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                            CssClass="Footerhide link" Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                    </div>
                                </FooterTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                        <EmptyDataTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                
                                <tr style="text-align: center;">
                                    <td width="125px">
                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                    </td>
                                    <td width="1000px">
                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="#65676d" Style="font-size:11px;  border:1px solid #d4d4d4;" onchange="Checkvalidation(this)"
                                            Width="1000px" runat="server" CssClass="capitalize" MaxLength="1000" />
                                    </td>
                                    <td width="50px">
                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                            CssClass="Footerhide link" Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>

                    </ContentTemplate>
                 </asp:UpdatePanel>
         </div>
        </td>
        </tr>
        </table>

        </div>
        <br />

         <div class="container-detail">   
        <h3 style="font-size:12px">  BIPL Comments(Sealers Pending) </h3>

     <%--   <div class="add_butt"> <asp:HyperLink ID="HyperLink1" runat="server" onclick="ShowLinkBIPL()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>




        <table width="100%" cellpadding="0" cellspacing="0">
       


        <tr>
        <td>
         <div align="left" style=" width: 100%; padding: 0px;">
         
         
                   <asp:UpdatePanel ID="UpdatePanelBIPLRemark" UpdateMode="Conditional" runat="server">
 
                    <ContentTemplate>
                    <asp:GridView ID="grdFitsBIPLRemark" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowFooter="True"  OnRowDeleting="grdFitsBIPLRemark_RowDeleting"
                        HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                        HeaderStyle-HorizontalAlign="Center" 
                        OnRowCommand="grdFitsBIPLRemark_RowCommand"
                        OnRowDataBound="grdFitsBIPLRemark_RowDataBound" GridLines="None" CssClass="fab-row">
                        <Columns>
                            <asp:TemplateField  HeaderStyle-Width="25px">
                                <ItemTemplate>
                                    <h3 style="padding:0px;"> <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal> </h3>
                                    <asp:Label ID="lblFitsBIPLId" style="display:none;" runat="server" Text='<%# Eval("BIPLRemarkId") %>'></asp:Label> 
                                    <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                     <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="125px">
                                <ItemTemplate>
                                  
                                    <asp:Label ID="lblRemarkEdit" ForeColor="#65676d" BorderStyle="None" CssClass="capitalize"
                                        Width="125px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                </ItemTemplate>
                               <ItemStyle Width="125px"  VerticalAlign="Top" />
                                <FooterTemplate>
                                    <asp:Label ID="lblRemarkFooter"  ForeColor="#65676d" BorderStyle="None" CssClass="capitalize"
                                        Width="125px" runat="server"></asp:Label>
                                </FooterTemplate>
                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                <ItemTemplate>
                                  
                                    <asp:TextBox ID="txtRemarkEdit" ForeColor="#65676d"  BorderStyle="None" CssClass="capitalize" TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                        Width="1000px" runat="server" Text='<%#Eval("BIPLRemark")%>'></asp:TextBox>
                                </ItemTemplate>
                               <ItemStyle Width="1000px" VerticalAlign="Top" />
                                <FooterTemplate>
                                    <asp:TextBox ID="txtRemarkFooter" ForeColor="#65676d" BorderStyle="None" CssClass="capitalize" MaxLength="1000" onchange="Checkvalidation(this)"
                                        Width="1000px" runat="server" class="textbox"></asp:TextBox>
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                               <%-- <HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkBIPL()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                       <asp:LinkButton ForeColor="black" ID="lnkDelete"  runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?')" ><img src="../../images/del-butt.png" /> </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                              <ItemStyle Width="50px" />
                                <FooterTemplate>
                                    <div style="text-align: center;">
                                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                            CssClass="FooterhideBIPL linkBIPL" Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                    </div>
                                </FooterTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                        <EmptyDataTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                
                                <tr style="text-align: center;">
                                    <td width="125px">
                                        <asp:Label ID="lblSl" runat="server"></asp:Label>
                                    </td>
                                    <td width="1000px">
                                        <asp:TextBox ID="txtRemarksEmpty" ForeColor="#65676d" Style="font-size:11px; border:1px solid #d4d4d4;" onchange="Checkvalidation(this)"
                                            Width="1000px" runat="server" CssClass="capitalize" MaxLength="1000" />
                                    </td>
                                    <td width="50px">
                                        <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                            CssClass="FooterhideBIPL linkBIPL" Text="Add"><img src="../../images/add-butt.png" /></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    </ContentTemplate>
                 </asp:UpdatePanel>
         </div>
        </td>
        </tr>
    </table>

    </div>
    <br />
</asp:Panel>
<div style="float:left; text-align:left">
    <asp:Button ID="btnSaveAll" runat="server" Text="Submit" ValidationGroup="submit" CssClass="submit"
        OnClientClick="javascript:return validateSave();" 
        Visible="true" onclick="btnSaveAll_Click" />  
        &nbsp; &nbsp; <asp:Button runat="server" ID="btnPrint"  cssclass="print da_submit_button" Text="Print"  OnClientClick="javascript:window.print();"/> 
</div>

 
</div>
<%-- </ContentTemplate>
                </asp:UpdatePanel>--%>

<div style="clear:both;"></div>
<br />
<div>
 <uc1:InlineTopSection ID="InlineTopSection1" runat="server" />
</div>

<div style="clear:both;">&nbsp;</div>


			</div>