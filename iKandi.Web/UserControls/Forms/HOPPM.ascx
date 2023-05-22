<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HOPPM.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.HOPPM" %>
<script type="text/javascript" language="javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);


    $(document).ready(function () {

        //        var hdnEnableFalse = $("#<%=hdnEnableFalse.ClientID%>").val();
        //        alert(hdnEnableFalse);
        //        if (hdnEnableFalse == 1) {
        //            $(".iSlnkHide").addClass("iSEnable");
        //            (".txtReadonly").setAttribute("readonly", "true");
        //        }
        //        else {
        //            removeClass("iSEnable iSEnable").addClass("ShowClass");
        //        }


        // debugger;
        //        $("input[type=text].QaRepresentative").autocomplete("/Webservices/iKandiService.asmx/SuggestUsers", { dataType: "xml", datakey: "string", max: 100 });
        //        $("input[type=text].FactoryRepresentitive").autocomplete("/Webservices/iKandiService.asmx/SuggestUsers", { dataType: "xml", datakey: "string", max: 100 });


        //        $("input[type=text].QaRepresentative", "#main_content").result(function () {
        //            //debugger;
        //            var username = $(this).val();

        //            proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
        //                if (result.UserID > 0) {
        //                    //debugger;
        //                    $("#hdnQaId").val(result.UserID);
        //                    $("#hdnQaName").val(result.FullName);
        //                }
        //                else {
        //                    //debugger;
        //                    var message = 'The User dose not exist.Please enter user full name';
        //                    ShowHideValidationBox(true, message);
        //                    $("#hdnQaId").val("");
        //                    $("#hdnQaName").val("");
        //                }

        //            }, onPageError, false, false);
        //        });




        //        $("input[type=text].FactoryRepresentitive", "#main_content").result(function () {
        //            // debugger;
        //            var username = $(this).val();

        //            proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
        //                if (result.UserID > 0) {
        //                    //debugger;
        //                    $("#hdnFactoryId").val(result.UserID);
        //                    $("#hdnFactoryName").val(result.FullName);
        //                    //alert($("#hdnOwnerName").val());
        //                }
        //                else {
        //                    //debugger;
        //                    var message = 'The User dose not exist.Please enter user full name';
        //                    ShowHideValidationBox(true, message);

        //                    $("#hdnFactoryId").val("");
        //                    $("#hdnFactoryName").val("");
        //                }

        //            }, onPageError, false, false);
        //        });
    });  
    function AddRepresentative(flag) {
        //        //debugger;
        $(".FactoryRepresentitive", "#HoPPM").autocomplete("/Webservices/iKandiService.asmx/SuggestUsers", { dataType: "xml", datakey: "string", max: 100 });
        $(".QaRepresentative", "#HoPPM").autocomplete("/Webservices/iKandiService.asmx/SuggestUsers", { dataType: "xml", datakey: "string", max: 100 });
        $(".MerchandiserRepresentative", "#HoPPM").autocomplete("/Webservices/iKandiService.asmx/SuggestUsers", { dataType: "xml", datakey: "string", max: 100 });

        if (flag == 1) {
            $(".FactoryRepresentitive", "#HoPPM").result(function () {
                debugger;
                var username = $(this).val();
                //alert(username);
                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
                        //debugger;
                        $("#hdnFactoryId").val(result.UserID);
                        $("#hdnFactoryName").val(result.FullName);
                        //alert($("#hdnOwnerName").val());
                    }
                    else {
                        //debugger;
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);

                        $("#hdnFactoryId").val("0");
                        $("#hdnFactoryName").val("");
                    }

                }, onPageError, false, false);
            });
        }

        if (flag == 2) {
            $(".QaRepresentative", "#HoPPM").result(function () {
                //debugger;
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
                        //debugger;
                        $("#hdnQaId").val(result.UserID);
                        $("#hdnQaName").val(result.FullName);
                    }
                    else {
                        //debugger;
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnQaId").val("");
                        $("#hdnQaName").val("");
                    }

                }, onPageError, false, false);
            });
        }


        if (flag == 3) {
            $(".MerchandiserRepresentative", "#HoPPM").result(function () {
                //debugger;
                var username = $(this).val();

                proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                    if (result.UserID > 0) {
                        //debugger;
                        $("#hdnMerchandiserId").val(result.UserID);
                        $("#hdnMerchandiserName").val(result.FullName);
                    }
                    else {
                        //debugger;
                        var message = 'The User dose not exist.Please enter user full name';
                        ShowHideValidationBox(true, message);
                        $("#hdnMerchandiserId").val("0");
                        $("#hdnMerchandiserName").val("");
                    }

                }, onPageError, false, false);
            });
        }
    }

    function HOPPM_CreateNew() {
        //debugger; 
        window.document.body.disabled = false;
        document.getElementById('<%=hdnHoppmCreateNew.ClientID%>').value = "1";
        $('#<%= hdnHoppmNewRef.ClientID %>').val('0');
        $('#<%= hdnHoppmReUse.ClientID %>').val('0');
        $(".btnthisH").click();
    }

    function HOPPM_NewRefrence(NewStyleID, NewStyleNumber) {
        //debugger;
        window.document.body.disabled = false;
        $('#<%= hdnHoppmNewRef.ClientID %>').val('1');
        $('#<%= hdnHoppmReUse.ClientID %>').val('0');
        $('#<%= hdnHoppmCreateNew.ClientID %>').val('0');
        $('#<%= hdnHoppmStyleId.ClientID %>').val(NewStyleID);
        $('#<%= hdnHoppmStyleNumber.ClientID %>').val(NewStyleNumber);
        $(".btnthisH").click();
    }

    function HOPPM_ReUse(ReUseStyleID, ReUseStyleNumber) {
        //debugger;
        window.document.body.disabled = false;
        $('#<%= hdnHoppmReUse.ClientID %>').val('1');
        $('#<%= hdnHoppmNewRef.ClientID %>').val('0');
        $('#<%= hdnHoppmCreateNew.ClientID %>').val('0');
        $('#<%= hdnHoppmStyleId.ClientID %>').val(ReUseStyleID);
        $('#<%= hdnHoppmStyleNumber.ClientID %>').val(ReUseStyleNumber);
        $(".btnthisH").click();
    }



    function OpenPopupForHOPPM(StyleCodeVirsion) {
        //debugger;        
        var StyleId = -1;
        var StyleNumber = StyleCodeVirsion;
        var ClientId = '<%=this.strClientId %>';
        var DeptId = '<%=this.DepartmentId %>';

        var url = '../../Internal/OrderProcessing/HOPPMPopupForNew.aspx?styleid=' + StyleId + '&stylenumber=' + StyleNumber + '&ClientID=' + ClientId + '&DeptId=' + DeptId + '';
        window.open(url, '_blank', 'height=600,width=800,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
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
    //    function ShowLink() {
    //        $(".link").removeClass("Footerhide");
    //        $(".link").addClass("FooterShow link");

    //    }

    //    function ShowLinkAccessories() {
    //        $(".linkAccessories").removeClass("FooterhideAccessories");
    //        $(".linkAccessories").addClass("FooterShowAccessories linkAccessories");

    //    }
    //    function ShowLinkFitting() {

    //        $(".linkFitting").removeClass("FooterhideFitting");
    //        $(".linkFitting").addClass("FooterShowFitting linkFitting");

    //    }
    //    function ShowLinkMaking() {
    //        $(".linkMaking").removeClass("FooterhideMaking");
    //        $(".linkMaking").addClass("FooterShowMaking linkMaking");

    //    }
    //    function ShowLinkImbroidery() {
    //        $(".linkImbroidery").removeClass("FooterhideImbroidery");
    //        $(".linkImbroidery").addClass("FooterShowImbroidery linkImbroidery");

    //    }
    //    function ShowLinkWashing() {
    //        $(".linkWashing").removeClass("FooterhideWashing");
    //        $(".linkWashing").addClass("FooterShowWashing linkWashing");

    //    }
    //    function ShowLinkFinishing() {
    //        $(".linkFinishing").removeClass("FooterhideFinishing");
    //        $(".linkFinishing").addClass("FooterShowFinishing linkFinishing");

    //    }

   

</script>
<style type="text/css">
    .capitalize
    {
        text-transform: capitalize;
    }

    .iSEnable
    {
        display:none;
    }
    
    .ShowClass
    {
        display:block;
    }
</style>


<%--<div id="tab-4" class="lorem">--%>
<%--<style type="text/css">
      
        .Footerhide{display: none}
        .FooterShow{display:inline}
        .FooterhideAccessories{display: none}
        .FooterShowAccessories{display:inline}
        .FooterhideFitting{display: none}
        .FooterShowFitting{display:inline}
        .FooterhideMaking{display: none}
        .FooterShowMaking{display:inline}
        .FooterhideImbroidery{display: none}
        .FooterShowImbroidery{display:inline}
        .FooterhideWashing{display: none}
        .FooterShowWashing{display:inline}
        .FooterhideFinishing{display: none}
        .FooterShowFinishing{display:inline}
       
        
    </style>--%>
<%--</div>--%>
<style type="text/css">
.hide { visibility: hidden; }
.form_heading
{
    text-align: center;
    font-size: 20px;
    margin-top: 5px;
    padding-bottom: 5px;
    /*border-bottom: 7px solid #000000;*/
    color: #000000 !important;
}
 .newcss2{text-transform:capitalize !important; font-size:10px; vertical-align:top;}  
.item_list th{ color: #ffffff !important; font-family:Verdana,Arial,sans-serif; font-size:11px;  text-transform: capitalize !important;  text-align:center; padding: 4px; font-weight: normal;} 
.item_list2 td{font-size:8px; color:Black; font-family:Verdana,Arial,sans-serif; vertical-align:top; border:1px solid #e6e6e6; border-collapse:collapse; text-transform: capitalize !important;}
.item_list3 td{font-size:10px; color:black; font-family:Verdana,Arial,sans-serif; vertical-align:top; border:1px solid #e6e6e6; border-collapse:collapse; text-transform: capitalize !important; margin:0px !important;; padding:2px !important;}
.td td{vertical-align:top;}
.item_list{border: 1px solid #e6e6e6;}
.item_list td{padding:1px 1px 1px 3px!important; vertical-align:top;}
.marginpadding{margin:0px !important; padding:0px !important;}
.verttop{vertical-align:top;}
.fixed-header th{font-size:8px; text-align:left;}
.fixed-header label{font-size:11px; text-align:center;}
.capitalize
{
    background:#fff !important;
}
.hiddencol
    {
        display:none;
    }
    .viscol
    {
        display:block;
    }
</style>
<div id="HoPPM" style="width: 1210px; font-family: Lucida Sans Unicode; font-size: 11px;
    padding: 5px;">
    <div style="margin: 0px 0px 5px; font-size: 16px; width: 100%;" class="fittingcontainer">
        Basic Information:
        <asp:Label ID="lblHoBasicInformation" runat="server" Text=""></asp:Label></div>
    <table width="100%">
        <tr>
            <td>
                <div align="left">
                    <asp:HiddenField ID="hdnHoppmCreateNew" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnHoppmReUse" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnHoppmStyleId" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnHoppmStyleNumber" Value="" runat="server" />
                    <asp:HiddenField ID="hdnHoppmNewRef" Value="0" runat="server" />
                    <asp:Button ID="Button1" Style="display: none;" CssClass="btnthisH" runat="server"
                        Text="Button" OnClick="Button1_Click" />
                        <asp:HiddenField ID="hdnEnableFalse" runat="server" Value="0" />
                        <asp:HiddenField ID="hdnstylenumber" runat="server" />
                        <asp:HiddenField ID="hdnStyleId" runat="server" />
                    <div id="dvGvHoppm" runat="server" visible="false" class="scroll-field" >
                        <asp:GridView ID="gvHOPPM" runat="server" AutoGenerateColumns="false" Visible="false" CssClass="fixed-header item_list"
                            OnRowDataBound="gvHOPPM_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="<label>&nbsp;Serial No.</label>" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 60px !important; float: left;">
                                            <asp:Label ID="lblCalBIH" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                    <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;Style No.</label>" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 60px !important; float: left; height: 20px;">
                                            <asp:Label ID="lblSDate" runat="server" Text='<%# Eval("StyleNumber")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                    <ItemStyle Width="60px" CssClass="newcss2"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;Contract No.<br/>&nbsp;&nbsp;&nbsp;Quantity</label>"
                                    ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 90px !important; float: left; text-align: center;">
                                            <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber")%>'></asp:Label><br />
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px"></HeaderStyle>
                                    <ItemStyle Width="80px" CssClass="newcss2"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fabric</label><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;<br/>Quality/Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Eta"
                                    HeaderStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 100%; height: 20px; font-weight: bold;">
                                            B.I.H:&nbsp;&nbsp;<asp:Label ID="lblBIH" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIH")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIH")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                        </div>
                                        <div style="width: 100%;">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr id="tbl1" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric1" runat="server">
                                                                    <asp:Label ID="lblFabric1" runat="server" Text='<%# Eval("Fabric1")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdprint1" runat="server">
                                                                    <asp:Label ID="lblFabric1Percent" runat="server" Text='<%# Eval("FabricPercent1")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric1DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric1DetailsRef" runat="server" Text='<%# Eval("Fabric1Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate1" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate1" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate1" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl2" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" id="tdFabric2" runat="server">
                                                                    <asp:Label ID="lblFabric2" runat="server" Text='<%# Eval("Fabric2")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric2Percent" runat="server">
                                                                    <asp:Label ID="lblFabric2Percent" runat="server" Text='<%# Eval("FabricPercent2")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric2DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric2DetailsRef" runat="server" Text='<%# Eval("Fabric2Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate2" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate2" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate2" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate2")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate2")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl3" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric3" runat="server">
                                                                    <asp:Label ID="lblFabric3" runat="server" Text='<%# Eval("Fabric3")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric3Percent" runat="server">
                                                                    <asp:Label ID="lblFabric3Percent" runat="server" Text='<%# Eval("FabricPercent3")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric3DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric3DetailsRef" runat="server" Text='<%# Eval("Fabric3Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate3" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate3" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate3" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate3")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate3")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tbl4" runat="server" visible="false">
                                                    <td align="left" style="width: 250px !important; float: left;">
                                                        <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                            <tr>
                                                                <td align="left" style="text-align: left;" id="tdFabric4" runat="server">
                                                                    <asp:Label ID="lblFabric4" runat="server" Text='<%# Eval("Fabric4")%>'></asp:Label>
                                                                </td>
                                                                <td colspan="2" id="tdFabric4Percent" runat="server">
                                                                    <asp:Label ID="lblFabric4Percent" runat="server" Text='<%# Eval("FabricPercent4")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;" id="tdFabric4DetailsRef" runat="server">
                                                                    <asp:Label ID="lblFabric4DetailsRef" runat="server" Text='<%# Eval("Fabric4Details")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricStartETAdate4" runat="server">
                                                                    <asp:Label ID="lblFabricStartETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricStartETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricStartETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 25%;" id="tdFabricEndETAdate4" runat="server">
                                                                    <asp:Label ID="lblFabricEndETAdate4" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricEndETAdate4")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FabricEndETAdate4")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="250px"></HeaderStyle>
                                    <ItemStyle Width="250px" VerticalAlign="Top" CssClass="newcss2 marginpadding verttop">
                                    </ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accessories</label><br/><br/>Quality&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In House &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Recd &nbsp;&nbsp;Tot &nbsp;&nbsp; Act Dat/End ETA"
                                    ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div>
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:Repeater ID="rptHoppmAccessories" runat="server" OnItemDataBound="rptHoppmAccessories_ItemDataBound">
                                                            <ItemTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="0" class="item_list3">
                                                                    <tr>
                                                                        <td align="left" style="text-align: left;">
                                                                            <div style="width: 105px; float: left;" id="divAccessoriesName" runat="server">
                                                                                <asp:Label ID="lblAccessories" Width="110" runat="server" Text='<%#Eval("AccessoriesName") %>'
                                                                                    Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <div style="width: 20px; float: left;" id="divpercentInHouse" runat="server">
                                                                                <asp:Label ID="lblPercentInHouse" runat="server" Text='<%#Eval("percentInHouse") %>'
                                                                                    Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <div style="width: 60px; float: left;" id="divQuantityAvail" runat="server">
                                                                                <asp:Label ID="txtQuantityAvail" Width="40" Style="color: #000000; background-color: transparent;
                                                                                    font-size: 8px;" runat="server" Text='<%#Eval("QuantityAvail") %>'></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <%-- <td>
            <div style="width:35px; float:left;">
            <asp:Label ID="lblBIHETAAcc"  Width="60" style="font-size:8px; color:#807F80 !important;" runat="server" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM(ddd)") %>' ></asp:Label>
            </div>
            </td>--%>
                                                                        <td>
                                                                            <div style="width: 35px; float: left;" id="divRequired" runat="server">
                                                                                <asp:Label ID="txtRequired" Width="40" runat="server" Text='<%#Eval("Required") %>'
                                                                                    Style="font-size: 8px !important; background-color: transparent;"></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <div style="width: 60px; float: left;" id="divAccesoriesETA" runat="server" class="Accessory">
                                                                                <asp:Label ID="lblAccessoriesETA" Width="60" Text='<%# (Convert.ToDateTime(Eval("BIHETAAcc")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("BIHETAAcc")).ToString("dd MMM (ddd)")%>'
                                                                                    runat="server" Style="font-size: 8px !important; text-transform: capitalize !important;"></asp:Label>
                                                                                <asp:TextBox ID="txtAccessoryWorkingDetailID" CssClass="hide_me txtAccessoryWorkingDetailID"
                                                                                    runat="server" Text='<%#Bind("AccessoryWorkingDetailID") %>'></asp:TextBox>
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
                                    <HeaderStyle Width="280px"></HeaderStyle>
                                    <ItemStyle Width="280px" CssClass="newcss2 marginpadding"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Technical</label><br/><br/>Deliverable&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ETA"
                                    ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="width: 150px; vertical-align: text-top; font-weight: bold; height: 30px;
                                            text-align: left;">
                                            PCD:&nbsp;&nbsp;<asp:Label ID="lblPCD" runat="server" Text='<%# (Convert.ToDateTime(Eval("PCD")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PCD")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            <%--Added By Ashish on 4/3/2015--%>
                                            &nbsp;&nbsp; Fits:&nbsp;&nbsp;<asp:Label ID="lblFitsDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("FitsStatusETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("FitsStatusETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            <%--END--%>
                                        </div>
                                        <div style="width: 150px; vertical-align: text-top;">
                                            <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                <tr>
                                                    <td style="text-align: left; width: 90px;" id="tdstc" runat="server">
                                                        Stc
                                                    </td>
                                                    <td id="tdLabel6" runat="server">
                                                        <asp:Label ID="Label6" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("STCETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("STCETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdPatternSample" runat="server">
                                                        Pattern Sample
                                                    </td>
                                                    <td id="tdPatternETA" runat="server">
                                                        <asp:Label ID="lblPatternETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdtop" runat="server">
                                                        TOP Sent
                                                    </td>
                                                    <td id="tdTOPETA" runat="server">
                                                        <asp:Label ID="lblTOPETA" Width="80px" runat="server" Text='<%# (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px"></HeaderStyle>
                                    <ItemStyle Width="150px" CssClass="newcss2 marginpadding"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Production</label><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In House&nbsp;&nbsp;&nbsp;Start ETA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End ETA"
                                    ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <div style="vertical-align: top; width: 215px; font-weight: bold; height: 20px;">
                                            Ex Fac:&nbsp;&nbsp;<asp:Label ID="lblExFactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("ExFactory")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                            <%--<asp:TextBox ID="txtOrderId" CssClass="hide_me" runat="server" Text='<%#Bind("OrderID") %>'></asp:TextBox>--%>
                                            <asp:TextBox ID="txtStyleID" CssClass="hide_me" runat="server" Text='<%#Bind("StyleID") %>'></asp:TextBox>
                                        </div>
                                        <div style="vertical-align: top; width: 215px;">
                                            <table width="100%" cellpadding="0" cellspacing="0" class="item_list2">
                                                <tr>
                                                    <td style="text-align: left; width: 65px;" id="tdCutReady" runat="server">
                                                        <asp:Label ID="lvlCutReady" runat="server" Text="Cut Ready"></asp:Label>
                                                    </td>
                                                    <td style="width: 30px;" id="tdCutPercentInhouse" runat="server">
                                                        <asp:Label ID="lblCutPercentInhouse" runat="server" Text='<%#Eval("CutPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td style="width: 60px;" id="tdCutreadyStartETA" runat="server">
                                                        <asp:Label ID="lblCutreadyStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 60px;" id="tdCutreadyENDETA" runat="server">
                                                        <asp:Label ID="lblCutreadyENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("CutEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("CutEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdStitched" runat="server">
                                                        <asp:Label ID="lblStitched" runat="server" Text="Stitched"></asp:Label>
                                                    </td>
                                                    <td id="tdStitchedPercentInhouse" runat="server">
                                                        <asp:Label ID="lblStitchedPercentInhouse" runat="server" Text='<%#Eval("StitchedPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td id="tdStichedStartETA" runat="server">
                                                        <asp:Label ID="lblStichedStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                    <td id="tdStichedENDETA" runat="server">
                                                        <asp:Label ID="lblStichedENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("StitchedEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("StitchedEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="tdVA" runat="server" style="text-align: left;">
                                                        <asp:Label ID="lvlVA" runat="server" Text="V.A."></asp:Label>
                                                    </td>
                                                    <td id="tdVAPercentInhouse" runat="server">
                                                        <asp:Label ID="lblVAPercentInhouse" runat="server" Text='<%#Eval("VAPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td id="tdVAStartETA" runat="server">
                                                        <asp:Label ID="lblVAStartETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAStartETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAStartETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                    <td id="tdVAENDETA" runat="server">
                                                        <asp:Label ID="lblVAENDETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("VAEndETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("VAEndETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;" id="tdlPacked" runat="server">
                                                        <asp:Label ID="lblPacked" runat="server" Text="Packed"></asp:Label>
                                                    </td>
                                                    <td id="tdPackedPercentInhouse" runat="server">
                                                        <asp:Label ID="lblPackedPercentInhouse" runat="server" Text='<%#Eval("PackedPercentInhouse") %>'></asp:Label>
                                                    </td>
                                                    <td id="tdPackedETA" runat="server" colspan="2">
                                                        <asp:Label ID="lblPackedETA" Width="60px" runat="server" Text='<%# (Convert.ToDateTime(Eval("PackedETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PackedETA")).ToString("dd MMM (ddd)")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle Width="215px"></HeaderStyle>
                                    <ItemStyle Width="215px" CssClass="newcss2 marginpadding"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        

                    </div>

                    <div>
                        <table width="100%">
                        <tr>
                        <td>Client:</td>
                        <td><asp:Label ID="lblClient" runat="server"></asp:Label></td>
                        <td rowspan="4">
                        <asp:Image ID="imgstyle" runat="server" Width="75" Height="120" />
                        </td>
                        </tr>
                         <tr>
                        <td>Style:</td>
                        <td><asp:Label ID="lblStyle" runat="server"></asp:Label></td>
                      
                        </tr>
                         <tr>
                        <td>Serial No.:</td>
                        <td><asp:Label ID="lblSerialNo" runat="server"></asp:Label></td>
                        
                        </tr>
                         <tr>
                        <td>CN no.:</td>
                        <td><asp:Label ID="lblCN" runat="server"></asp:Label></td>
                       
                        </tr>
                        </table>
                        </div>


                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanelStyleCodeVirsion" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Repeater ID="repStyleCodeVirsion" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkn1" runat="server">
                                                <asp:Label ID="lbl" runat="server" Text='<%#Eval("StyleCodeVirsion")%>'></asp:Label>
                                            </asp:LinkButton>
                                            &nbsp;
                                            <asp:ImageButton ID="imgPlus" ImageUrl="../../App_Themes/ikandi/images/plus_icon.gif"
                                                OnClick="imgPlus_Click" runat="server" />
                                            <asp:ImageButton ID="imgMinus" ImageUrl="../../App_Themes/ikandi/images/minus_icon.gif"
                                                Style="display: none;" OnClick="imgMinus_Click" runat="server" />
                                            <asp:HiddenField ID="rephdnStyleid" runat="server" Value='<%#Eval("StyleidVirsion")%>' />
                                            <asp:HiddenField ID="rephdnStylCode" runat="server" Value='<%#Eval("StyleCodeVirsion")%>' />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="ShowGridPopup" runat="server" style="overflow-y: scroll; width: 100%; height: 500px;">
                                        <div class="container-detail">
                                            <h3>
                                                <asp:Label ID="lblFabric" runat="server" Text=""></asp:Label>
                                            </h3>
                                            <asp:GridView ID="GridHOPPMFabeic" Visible="false" runat="server" AutoGenerateColumns="False" Width="95%"
                                                ShowFooter="True" HeaderStyle-CssClass="pras" ShowHeader="false" HeaderStyle-Height="23px"
                                                HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridHOPPMFabeic_RowDataBound"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                            <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fabric Remark" HeaderStyle-Width="1000px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                                        <tr style="text-align: center;">
                                                            <td width="29%">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <div class="container-detail" style="display:none">
                                            <h3>
                                                <asp:Label ID="lblHOPPMAccessories" runat="server" Text=""></asp:Label>
                                            </h3>
                                            <asp:GridView ID="GridHOPPMAccessories" Visible="false" runat="server" AutoGenerateColumns="False"
                                                Width="95%" ShowFooter="True" ShowHeader="false" HeaderStyle-CssClass="pras"
                                                HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                                OnRowDataBound="GridHOPPMAccessories_RowDataBound" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                            <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Accessories Remark" HeaderStyle-Width="1000px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                            <asp:HiddenField runat="server" ID="hdn_RiskAccessoryId" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                        <tr style="text-align: center;">
                                                            <td width="29%" style="background-color: #e6e6e6;">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <!-- R&D Section Implementation -->
                                        <div class="container-detail" style="display:none">
                                            <h3>
                                                <asp:Label ID="lblHOPPMRnD" runat="server" Text=""></asp:Label>
                                            </h3>
                                            <asp:GridView ID="GridHOPPMRnD" Visible="false" runat="server" AutoGenerateColumns="False"
                                                Width="95%" ShowFooter="True" ShowHeader="false" HeaderStyle-CssClass="pras"
                                                HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                                OnRowDataBound="GridHOPPMRnD_RowDataBound" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                            <asp:HiddenField runat="server" ID="hdnRnDId" Value='<%# Eval("RnDId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="R&D Remark" HeaderStyle-Width="1000px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("RnDRemark")%>'></asp:Label>
                                                            <asp:HiddenField runat="server" ID="hdn_RnDId" Value='<%# Eval("RnDId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                        <tr style="text-align: center;">
                                                            <td width="29%" style="background-color: #e6e6e6;">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <%--updated by abhishek on 17/8/2015--%>
                                        <div class="container-detail" style="display: none">
                                        <%--end by abhishek on 17/8/2015--%>
                                            <h3>
                                                <asp:Label ID="lblHOPPMFittingRemark" runat="server" Text=""></asp:Label></h3>
                                            <asp:GridView ID="GridHOPPMFittingRemark" Visible="false" runat="server" AutoGenerateColumns="False"
                                                Width="95%" ShowFooter="True" ShowHeader="false" HeaderStyle-CssClass="pras"
                                                HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                                OnRowDataBound="GridHOPPMFittingRemark_RowDataBound" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fitting Remark" HeaderStyle-Width="1000px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                            <asp:HiddenField runat="server" ID="hdn_RiskFittingId" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                        <tr style="text-align: center;">
                                                            <td width="29%" style="background-color: #e6e6e6;">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <div class="container-detail">
                                            <h3>
                                                <asp:Label ID="lblMaking" runat="server" Text=""></asp:Label></h3>
                                            <asp:GridView ID="GridHOPPMMaking" runat="server" Visible="false" AutoGenerateColumns="False" Width="95%"
                                                ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                                HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridHOPPMMaking_RowDataBound"
                                                GridLines="None" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Making Remark" HeaderStyle-Width="1000px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                            <asp:HiddenField runat="server" ID="hdn_RiskMakingId" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                        <tr style="text-align: center;">
                                                            <td width="29%" style="background-color: #e6e6e6;">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <div class="container-detail">
                                            <h3>
                                                <asp:Label ID="lblHOPPMImbroideryRemark" runat="server" Text=""></asp:Label>
                                            </h3>
                                            <asp:GridView ID="GridHOPPMImbroideryRemark" Visible="false" runat="server" AutoGenerateColumns="False"
                                                Width="95%" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                                HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridHOPPMImbroideryRemark_RowDataBound"
                                                GridLines="None" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Imbroidery Remark" HeaderStyle-Width="1000px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                            <asp:HiddenField runat="server" ID="hdn_ImbroideryRemark" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                        <tr style="text-align: center;">
                                                            <td width="29%" style="background-color: #e6e6e6;">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <div class="container-detail">
                                            <h3>
                                                <asp:Label ID="lblRiskWashing" runat="server" Text=""></asp:Label>
                                            </h3>
                                            <asp:GridView ID="GridRiskWashing" Visible="false" runat="server" AutoGenerateColumns="False" Width="95%"
                                                ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                                HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridRiskWashing_RowDataBound"
                                                GridLines="None" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Washing Remark" HeaderStyle-Width="1000px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                            <asp:HiddenField runat="server" ID="hdn_WashingRemarkRemark" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                        <tr style="text-align: center;">
                                                            <td width="29%" style="background-color: #e6e6e6;">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <div class="container-detail">
                                            <h3>
                                                <asp:Label ID="lblRiskFinishing" runat="server" Text=""></asp:Label></h3>
                                            <asp:GridView ID="GridRiskFinishing" Visible="false" runat="server" AutoGenerateColumns="False" Width="95%"
                                                ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                                HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridRiskFinishing_RowDataBound"
                                                GridLines="None" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="border" HeaderText="SL no.">
                                                        <ItemTemplate>
                                                            <h3>
                                                                <asp:Literal runat="server" ID="ltIndex" Text="-"></asp:Literal>
                                                            </h3>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                                    </asp:TemplateField>
                                                     <%-- updated by abhishek on 17/8/2015--%>
                                                    <asp:TemplateField HeaderText="Finishing/Packing Remark" HeaderStyle-Width="12%">
                                                       <%-- end by abhishek on 17/8/2015--%>
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRemarkEdit" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="98%" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:Label>
                                                            <asp:HiddenField runat="server" ID="hdn_RiskFinishingIdRemark" Value='<%# Eval("RiskFabricId") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="98%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras" style="background-color: #e6e6e6;">
                                                        <tr style="text-align: center;">
                                                            <td width="29%" style="background-color: #e6e6e6;">
                                                                <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtRemarksEmpty" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                    Width="600px" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div> 
                                        <div class="container-detail">
                                        <asp:HyperLink ID="hlkRefViewSnap1" runat="server" Visible="false" Target="_blank" > <img src="../../images/view-icon.png" /> </asp:HyperLink>

                                        <asp:HyperLink ID="hlkRefViewSnap2" runat="server" Visible="false" Target="_blank" > <img src="../../images/view-icon.png" /> </asp:HyperLink>
                                        
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <div align="left" style="width: 100%; padding: 0px;">
               <%-- <asp:Panel ID="PnlRemarks" runat="server" defaultbutton="btnSubmit" xmlns:asp="#unknown">--%>

                    <div class="container-detail">
                        <h3>
                            Fabric
                        </h3>
                        <%--<div class="add_butt"> <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLink()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                        <asp:UpdatePanel ID="UpdatePannel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdHoppmFabricRemark" Visible="false" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ShowFooter="True" OnRowDeleting="grdRiskRemarks_RowDeleting" HeaderStyle-CssClass="pras"
                                    HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                    OnRowCommand="grdHoppmFabricRemark_RowCommand" OnRowDataBound="grdHoppmFabricRemark_RowDataBound"
                                    GridLines="None" CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField >
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" ID="ltIndex" text='<%# Eval("Indexs") %>'></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskFabricId" Value='<%# Eval("RiskFabricId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" CssClass="capitalize" MaxLength="1000"
                                                    TextMode="MultiLine" Height="30" BorderStyle="None" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" >
                                            <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLink()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" 
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="70px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;" 
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" />  </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="container-detail">
                        <h3>
                            Accessories
                        </h3>
                        <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink1" runat="server" onclick="ShowLinkAccessories()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRiskAccessories" Visible="false" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                    HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskAccessories_RowCommand"
                                    OnRowDataBound="grdRiskAccessories_RowDataBound" OnRowDeleting="grdRiskAccessories_RowDeleting"
                                    OnSelectedIndexChanging="grdRiskAccessories_SelectedIndexChanging" GridLines="None"
                                    CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" ID="ltIndex" text='<%# Eval("Indexs") %>'></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFabricId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                            <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkAccessories()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" CssClass="iSlnkHide"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="70px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;" 
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%-- RnD grid Update --%>
                    <div class="container-detail">
                        <h3>
                            R&D
                        </h3>
                        <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink1" runat="server" onclick="ShowLinkAccessories()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRiskRnD" Visible="false" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px"
                                    HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskRnD_RowCommand"
                                    OnRowDataBound="grdRiskRnD_RowDataBound" OnRowDeleting="grdRiskRnD_RowDeleting"
                                    OnSelectedIndexChanging="grdRiskRnD_SelectedIndexChanging" GridLines="None"
                                    CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" ID="ltIndex" text='<%# Eval("Indexs") %>'></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskRnDId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                            <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkAccessories()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" CssClass="iSlnkHide"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="70px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;" 
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <%--updated by abhishek on 17/8/2015--%>
                    <div class="container-detail" style="display:none">
                    <%--end abhishek on 17/8/2015--%>
                        <h3>
                            Fitting
                        </h3>
                        <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink2" runat="server" onclick="ShowLinkFitting()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                        <%--abhishek on 19/8/2015--%>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                            <ContentTemplate>
                                <asp:GridView ID="grdriskFiting" Visible="false" runat="server" AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                    HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdriskFiting_RowCommand"
                                    OnRowDataBound="grdriskFiting_RowDataBound" OnRowDeleting="grdriskFiting_RowDeleting"
                                    GridLines="None" CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" ID="ltIndex" text='<%# Eval("Indexs") %>'></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFabricId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                            <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkFitting()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" runat="server" CommandName="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="95px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;" 
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       <%--end abhishek 19/8/2015--%>
                    </div>
                    <div class="container-detail">
                        <h3>
                            Making
                        </h3>
                        <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink3" runat="server" onclick="ShowLinkMaking()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                        <%--abhishek on 19/8/2015--%>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRiskMaking" runat="server" Visible="false" AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                    HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskMaking_RowCommand"
                                    OnRowDataBound="grdRiskMaking_RowDataBound"  OnRowDeleting="grdRiskMaking_RowDeleting"
                                    GridLines="None" CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" text='<%# Eval("Indexs") %>' ID="ltIndex"></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFabricId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="Black" BorderStyle="None" CssClass="capitalize" 
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="#65676d" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="Black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                            <%-- <HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkMaking()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" >
                                                    <asp:LinkButton ForeColor="black" ID="lnkDelete" Width="50px" runat="server" CommandName="Delete"
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" 
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="70px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;" 
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                                         
                      
                         <%--end abhishek 19/8/2015--%>
                    </div>
                    <div class="container-detail">
                         <%--abhishek--%>
                        <h3>
                            Value addition
                        </h3> 
                        <%-- end--%>
                        <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink4" runat="server" onclick="ShowLinkImbroidery()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                         <%--abhishek on 19/8/2015--%>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRiskImbroidery" runat="server" Visible="false" AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                    HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskImbroidery_RowCommand"
                                    OnRowDataBound="grdRiskImbroidery_RowDataBound" OnRowDeleting="grdRiskImbroidery_RowDeleting"
                                    GridLines="None" CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" ID="ltIndex" text='<%# Eval("Indexs") %>'></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFabricId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                            <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkImbroidery()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="lnkDelete" Width="50px" runat="server" CommandName="Delete"
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" 
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'>  <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="70px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server"  CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                         <%--end abhishek 19/8/2015--%>

                    </div>
                    <div class="container-detail">
                        <h3>
                            Washing
                        </h3>
                        <%--<div class="add_butt"> <asp:HyperLink ID="HyperLink5" runat="server" onclick="ShowLinkWashing()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRiskWashing" runat="server" Visible="false" AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                    HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskWashing_RowCommand"
                                    OnRowDataBound="grdRiskWashing_RowDataBound" OnRowDeleting="grdRiskWashing_RowDeleting"
                                    GridLines="None" CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" ID="ltIndex" text='<%# Eval("Indexs") %>'></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFabricId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                            <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkWashing()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="lnkDelete" runat="server" Width="50px" CommandName="Delete" 
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" 
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'>  <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="70px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="container-detail">
                        <h3>
                       <%-- updated by abhishek on 17/8/2015--%>
                            Finishing/Packing 
                           <%-- end by abhishek on 17/8/2015--%>
                        </h3>
                        <%-- <div class="add_butt"> <asp:HyperLink ID="HyperLink6" runat="server" onclick="ShowLinkFinishing()"><img src="../../images/add-butt.png" /></asp:HyperLink> </div>--%>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRiskFinishing" runat="server" Visible="false" AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" HeaderStyle-CssClass="pras" HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial"
                                    HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdRiskFinishing_RowCommand"
                                    OnRowDataBound="grdRiskFinishing_RowDataBound" OnRowDeleting="grdRiskFinishing_RowDeleting"
                                    GridLines="None" CssClass="fab-row">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <h3>
                                                    <asp:Literal runat="server" ID="ltIndex" text='<%# Eval("Indexs") %>'></asp:Literal>
                                                </h3>
                                                <asp:HiddenField runat="server" ID="hdnRiskId" Value='<%# Eval("RiskFabricId") %>' />
                                                <asp:HiddenField runat="server" ID="hdndataTableId" Value='<%# Eval("dataTableId") %>' />
                                                <asp:HiddenField runat="server" ID="hdnStyleSequence" Value='<%# Eval("SequenceNo") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarkBy" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    Width="70px" runat="server" Text='<%#Eval("RemarksBy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblRemarkByFooter" ForeColor="black" CssClass="capitalize" Width="70px"
                                                    runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1000px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarkEdit" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    TextMode="MultiLine" Height="30" MaxLength="1000" onchange="Checkvalidation(this)"
                                                    Width="1000px" runat="server" Text='<%#Eval("FabricRemark")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="1000px" VerticalAlign="top" />
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtRemarkFooter" ForeColor="black" BorderStyle="None" CssClass="capitalize"
                                                    MaxLength="1000" onchange="Checkvalidation(this)" Width="1000px" runat="server"
                                                    class="textbox" Style="font-size: 11px; border: 1px solid #d4d4d4;"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50px">
                                            <%--<HeaderTemplate>
                                    <asp:HyperLink ID="hyplnk" runat="server" onclick="ShowLinkFinishing()">+</asp:HyperLink>
                                </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="lnkDelete" runat="server" Width="50px" CommandName="Delete"
                                                        OnClientClick="return confirm('Are you sure you want to delete?')"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                            <FooterTemplate>
                                                <div style="text-align: center;" class="iSlnkHide">
                                                    <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" 
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="pras">
                                            <tr style="text-align: center;">
                                                <td width="70px">
                                                    <asp:Label ID="lblSl" runat="server"></asp:Label>
                                                </td>
                                                <td width="1000px">
                                                    <asp:TextBox ID="txtRemarksEmpty" ForeColor="black" Style="font-size: 11px; border: 1px solid #d4d4d4;"
                                                        onchange="Checkvalidation(this)" Width="1000px" runat="server" CssClass="capitalize"
                                                        MaxLength="1000" />
                                                </td>
                                                <td width="50px">
                                                    <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                     <%--</asp:Panel>--%>
                
                <div class="container-detail">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; text-align: left; padding: 5px 0px;">
                        <tr>
                          <td>
                            <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #000;">
                              <tr>
                                <td width="15%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">Factory Representatives</td>
                                <td width="85%">
                                  <div id="dvFactoryRepresentative">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                      <tr>
                                        <td align="center" style="width:15%">
                                          <asp:TextBox ID="txtFactoryRepresentitive" CssClass="FactoryRepresentitive"  onclick="AddRepresentative(1)" runat="server"></asp:TextBox>
                                          <input type="hidden" value='0' id="hdnFactoryId" name="hdnFactoryId" />
                                          <input type="hidden" value='' id="hdnFactoryName" name="hdnFactoryName" />
                                          <asp:HiddenField ID="hdnFactoryRepresentativeId" runat="server" />
                                          <asp:HiddenField ID="hdnFactoryRepresentativeName" runat="server" />
                                          <asp:HiddenField ID="hdnFactoryCounter" runat="server" />
                                        </td>
                                        <td align="center" style="width:15%"><input type="button" style="width: 85px ! important;" runat="server" visible="false" id='btnAddFactory' class="add" onclick="AddFactoryRepresentative()" /></td>
                                        <td align="left" style="width:70%"><div runat="server" id='dvFactoryRepresentativeValues'></div></td>
                                      </tr>
                                    </table>
                                  </div>
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #000;">
                              <tr>
                                <td width="15%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">QA Representatives</td>
                                <td width="85%">
                                  <div id="dvQaRepresentative">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                      <tr>
                                        <td align="center" style="width:15%">
                                          <asp:TextBox ID="txtQaRepresentative" CssClass="QaRepresentative" onclick="AddRepresentative(2)" runat="server"></asp:TextBox>
                                          <input type="hidden" value='0' id="hdnQaId" name="hdnQaId" />
                                          <input type="hidden" value='' id="hdnQaName" name="hdnQaName" />
                                          <asp:HiddenField ID="hdnQaRepresentativeId" runat="server" />
                                          <asp:HiddenField ID="hdnQaRepresentativeName" runat="server" />
                                          <asp:HiddenField ID="hdnCounter" runat="server" />
                                        </td>
                                        <td align="center" style="width:15%"><input type="button" style="width: 85px ! important;" runat="server" visible="false" id='btnAddQa' class="add" onclick="AddQaRepresentative()" /></td>
                                        <td align="left" style="width:70%"><div runat="server" id='dvQaRepresentativeValues'></div></td>
                                      </tr>
                                    </table>
                                  </div>
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #000;">
                              <tr>
                                <td width="15%" bgcolor="#39589c" style="color: #fff; padding: 0px 0px 0px 5px">Merchandiser Representatives</td>
                                <td width="85%">
                                  <div id="dvMerchandiserRepresentative">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                      <tr>
                                        <td align="center" style="width:15%">
                                          <asp:TextBox ID="txtMerchandiserRepresentative" CssClass="MerchandiserRepresentative" onclick="AddRepresentative(3)" runat="server"></asp:TextBox>
                                          <input type="hidden" value='0' id="hdnMerchandiserId" name="hdnMerchandiserId" />
                                          <input type="hidden" value='' id="hdnMerchandiserName" name="hdnMerchandiserName" />
                                          <asp:HiddenField ID="hdnMerchandiserRepresentativeId" runat="server" />
                                          <asp:HiddenField ID="hdnMerchandiserRepresentativeName" runat="server" />
                                          <asp:HiddenField ID="hdnMerchandiserCounter" runat="server" />
                                        </td>
                                        <td align="center" style="width:15%"><input type="button" style="width: 85px ! important;" runat="server" id='btnAddMerchandiser' class="add" onclick="AddMerchandiserRepresentative()" /></td>
                                        <td align="left" style="width:70%"><div runat="server" id='dvMerchandiserRepresentativeValues'></div></td>
                                      </tr>
                                    </table>
                                  </div>
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                       
                        <%------Statr------------%>
                        <%--<tr>
                            <td>
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #000;">
                                    <tr>
                                        <td width="15%" bgcolor="#7e7e7e" style="color: #fff; padding: 0px 0px 0px 5px">
                                            Merchandiser Representatives
                                        </td>
                                        <td width="15%">
                                            <asp:TextBox ID="txtMerchandiserRepresentative" CssClass="MerchandiserRepresentative"
                                                onclick="AddRepresentative(3)" runat="server"></asp:TextBox>
                                            <input type="hidden" value='0' id="hdnMerchantId" name="hdnMerchantId" />
                                            <input type="hidden" value='' id="hdnMerchantName" name="hdnMerchantName" />
                                            <asp:HiddenField ID="hdnMerchandiserId" runat="server" />
                                            <asp:HiddenField ID="hdnMerchandiserName" runat="server" />
                                        </td>
                                        <td width="10%">
                                            <input type="button" style="width: 85px ! important;" runat="server" id='btnaddMerchandiser'
                                                class="add" onclick="addMerchandiser()" />
                                        </td>
                                        <td width="65%">
                                            <asp:Label ID="lblMerchandiserRepresentative" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <%--------END-----------------%>
                        <%------Statr------------%>
                        <tr>
                            <td>
                                <table width="100%" cellpadding="0" style="padding-bottom: 5px; border-bottom: 1px solid #000;">
                                    <tr>
                                    <td>
                                    <asp:Label ID="lblReportCaption" runat="server" Text="R&DReport:"></asp:Label>
                                     
                                    </td>
                                        <td width="15%" style="color: #fff; padding: 0px 0px 0px 5px">
                                      <asp:FileUpload ID="FileSnap1" runat="server" />
                                        </td>
                                        <td width="15%">
                                            <asp:HyperLink ID="hlkViewSnap1" runat="server" Visible="false" Target="_blank" > <img src="../../images/view-icon.png" /> </asp:HyperLink>
                                            <asp:HiddenField ID="hdnSnap1" runat="server" />
                                        </td>
                                        <td>
                                        <asp:Label ID="Label1" runat="server" Text="PPM Attachments:" Width="100"></asp:Label>
                                        
                                        </td>
                                        <td width="15%">
                                       <asp:FileUpload ID="FileSnap2" runat="server" />  
                                        </td>
                                        <td width="20%">
                                          <asp:HyperLink ID="hlkViewSnap2" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
                                          <asp:HiddenField ID="hdnSnap2" runat="server" />
                                        </td>
                                        <td width="35%">
                                        <asp:Button ID="btnFile1Upload" CssClass="submit" runat="server" Text="Submit"  Visible="false"
                                                Style="float: left;" onclick="btnFile1Upload_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--------END-----------------%>

                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%" style="padding: 10px 0px 0px;">
                                 
                                    <tr>
                                        
                                        <td style="width: 20%;">
                                            Attended By GM QA  &nbsp;&nbsp;
                                            <asp:CheckBox ID="chkProdQAMgr" Visible="false" onclick="CheckAllCheckBoxes();"
                                                Checked='<%#Eval("IsQAProdApprovedOn") %>' runat="server" 
                                                oncheckedchanged="chkProdQAMgr_CheckedChanged" />
                                        </td>
                                        <td style="width: 20%;">
                                            Signed Off By AM &nbsp;&nbsp;
                                            <asp:CheckBox ID="chkMM" Visible="false" onclick="CheckAllCheckBoxes();" Checked='<%#Eval("IsMerchandisingManagerApprovedOn") %>'
                                                runat="server" oncheckedchanged="chkMM_CheckedChanged" />
                                        </td>
                                        <td style="width: 20%;">
                                            Is Factory PPM Complete &nbsp;&nbsp;
                                            <asp:CheckBox ID="chkFactoryPPMComplete" Visible="false"  onclick="CheckAllCheckBoxes();" Checked='<%#Eval("IsFactoryPPMComplete") %>'
                                                runat="server" oncheckedchanged="chkFactoryPPMComplete_CheckedChanged" />
                                        </td>
                                        <td style="width: 20%;">
                                            Is HOPPM Complete &nbsp;&nbsp;
                                            <asp:CheckBox ID="chkHOPPMComplete" Visible="false"  CssClass="hoppmcomlete"  Checked='<%#Eval("IsHOPPMComplete") %>' runat="server" />
                                        </td>
                                        <td>
                                          Seam Slippage OK &nbsp;&nbsp; 
                                          <asp:CheckBox ID="chkSeamSlippage" runat="server" /> 
                      
                                        </td>
                                    </tr>
                                    <tr>
                                      
                                        
                                        <td style="color: #267cb2" width="20%">
                                            <asp:Label ID="lblchkProdQAMgr" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="color: #267cb2" width="20%">
                                            <asp:Label ID="lblchkMM" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="color: #267cb2" width="20%">
                                            <asp:Label ID="lblchkFactoryPPMComplete" runat="server" Text=""></asp:Label>
                                        </td>
                                         <td style="color: #267cb2" width="20%">
                                            
                                             <asp:Label ID="lblchkHOPPMComplete" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="color: #267cb2" width="20%">
                                           <asp:Label ID="lblSeamSlippageOn" runat="server" Text=""></asp:Label>
                                             <asp:Button ID="btnCheckbox" Style="display: none;" CssClass="checkboxbutton" runat="server" Text="Button" 
                                                onclick="btnCheckbox_Click" />
                                        </td>
                                       
                                    </tr>
                                  
                                    <tr>
                                    <td colspan="5" >
                                    <asp:Label ID="lblTaskMsg" runat="server" Text="IE Finalize OB W/S SAM task is incomplete" ></asp:Label>
                                   
                                    </td>
                                
                                    </tr>
                                    <tr>
                                    <td colspan="5">  <asp:Label ID="lblButtomMsg" runat="server" ForeColor="Blue" Text="* (This PPM Shall be deemed incomplete unless attended by both Pre Production QA Mgr and Production QA Mgr)"></asp:Label> </td>
                                    </tr>
                                    
                                    <tr>
                                        <td align="left">
                                        
                                            <asp:Button ID="btnSubmit" Visible="false" CssClass="submit" Text="Submit" runat="server" OnClick="btnSubmit_Click"
                                                Style="float: left;" />
                                            <div style="clear: both">
                                            </div>
                                        </td>
                                        <td >
                                        <input type="button" id="Button2" class="print da_submit_button" value="Print"  onclick="return PrintHoppmReportPDF();" />
                                            <%--<asp:Button ID="Button3" CssClass="submit" runat="server" Text="Print"
                                                Style="float: left;" onclick="Button3_Click" />--%>
                                       
                                        </td>
                                        <td colspan="3"> &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                </div>
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">


    function CheckAllCheckBoxes() {
        //debugger;
        //alert('checked');
        var check1 = 0;
        var check2 = 0;
        var check3 = 0;
        var check4 = 0;


        if ($('#<%= chkProdQAMgr.ClientID %>').is(':checked')) {
            check2 = 1;
            //alert('checked 2');
        }
        if ($('#<%= chkMM.ClientID %>').is(':checked')) {
            check3 = 1;
        }
        if ($('#<%= chkFactoryPPMComplete.ClientID %>').is(':checked')) {
            check4 = 1;
        }
        if ((check1 == 1) && (check2 == 1) && (check3 == 1) && (check4 == 1)) {
            //alert('all checked');
            // $(".checkboxbutton").click(); 
        }
    }

    function PrintHoppmReportPDF() {


        var NewRef = $('#<%= hdnHoppmNewRef.ClientID %>').val();
        var ReUse = $('#<%= hdnHoppmReUse.ClientID %>').val();
        var CreateNew = $('#<%= hdnHoppmCreateNew.ClientID %>').val();
        var styleid = $('#<%= hdnStyleId.ClientID %>').val();
        var ReUseStyleId = $('#<%= hdnHoppmStyleId.ClientID %>').val();
        var stylenumber = $('#<%= hdnstylenumber.ClientID %>').val();
        var ClientId = '<%=this.strClientId %>';
        var DeptId = '<%=this.DepartmentId %>';
        //alert(1);
        //debugger;
        //proxy.invoke("GenerateManageOrderReportH", { styleid: styleid, ReUseStyleId: ReUseStyleId, ClientId: ClientId, DeptId: DeptId, CreateNew: CreateNew, NewRef: NewRef, ReUse: ReUse }, function (result) {
        proxy.invoke("GenerateHoppmReport", { stylenumber: stylenumber, styleid: styleid, strClientId: ClientId, DepartmentId: DeptId, CreateNew: CreateNew, NewRef: NewRef, ReUse: ReUse, ReUseStyleId: ReUseStyleId, RemarksType: '' }, function (result) {
            if ($.trim(result) == '')
                jQuery.facebox("Some error occured on the server, please try again later.");
            else {
                window.open("/uploads/temp/" + result);
                $(".loadingimage").hide();
                $(".print").show();
            }
        });

        return false;
    }

    //
    var counter = parseInt($('#<%= hdnCounter.ClientID %>').val());
    function AddQaRepresentative() {
        //    debugger;
        if ($('#<%= txtQaRepresentative.ClientID %>').val() != "") {
            var objIds = '<%=hdnQaRepresentativeId.ClientID%>';
            var objNames = '<%=hdnQaRepresentativeName.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnQaId").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnQaId").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnQaId").val();
                    IdsArr = strIds.split(',');
                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtQaRepresentative.ClientID %>').val('');
                            $("#hdnQaId").val('0');
                            $("#hdnQaName").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnQaName").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnQaName").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnQaName").val();
                }
            }

            $("#" + objIds).val(strIds);
            $("#" + objNames).val(strNames);

            var QaRepresentativeId = $("#hdnQaId").val();
            var QaRepresentativeName = $("#hdnQaName").val();

            if (parseInt(QaRepresentativeId) > 0) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvQaRepresentative' + counter);
                if (counter == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtQaRepresentative.ClientID %>').val() + ' <a onclick="DeleteQaRepresentative(' + counter + ', ' + QaRepresentativeId + ', \'' + QaRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtQaRepresentative.ClientID %>').val() + ' <a onclick="DeleteQaRepresentative(' + counter + ', ' + QaRepresentativeId + ', \'' + QaRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvQaRepresentativeValues.ClientID %>");
            }
            else {
                alert("This Representative does not exist. Please enter a valid Representative.")
            }
            $('#<%= txtQaRepresentative.ClientID %>').val('');
            counter++;
            $("#hdnQaId").val('0');
            $("#hdnQaName").val('');
        }
        else {
            alert("Please enter QA Representative.")
        }
    }

    function DeleteQaRepresentative(counter, QaRepresentativeId, QaRepresentativeName) {
        //    debugger;
        var QaRepresentativeIds = $("#<%=hdnQaRepresentativeId.ClientID%>").val();
        var QaRepresentativeNames = $("#<%=hdnQaRepresentativeName.ClientID%>").val();

        $("#dvQaRepresentative" + counter).remove();
        $("#<%=hdnQaRepresentativeId.ClientID%>").val(QaRepresentativeIds.replace(QaRepresentativeId, ''));
        $("#<%=hdnQaRepresentativeName.ClientID%>").val(QaRepresentativeNames.replace(QaRepresentativeName, ''));

        QaRepresentativeIds = $("#<%=hdnQaRepresentativeId.ClientID%>").val();
        QaRepresentativeIds = (QaRepresentativeIds.replace(',,', ','));

        QaRepresentativeNames = $("#<%=hdnQaRepresentativeName.ClientID%>").val();
        QaRepresentativeNames = (QaRepresentativeNames.replace(',,', ','));

        $("#<%=hdnQaRepresentativeId.ClientID%>").val(QaRepresentativeIds);
        $("#<%=hdnQaRepresentativeName.ClientID%>").val(QaRepresentativeNames);

        var lastCharQaRepresentativeIds = QaRepresentativeIds.substr(QaRepresentativeIds.length - 1);
        var lastCharQaRepresentativeNames = QaRepresentativeNames.substr(QaRepresentativeNames.length - 1);

        if (lastCharQaRepresentativeIds === ",") {
            $("#<%=hdnQaRepresentativeId.ClientID%>").val(QaRepresentativeIds.substring(0, QaRepresentativeIds.length - 1))
        }

        if (lastCharQaRepresentativeNames === ",") {
            $("#<%=hdnQaRepresentativeName.ClientID%>").val(QaRepresentativeNames.substring(0, QaRepresentativeNames.length - 1))
        }
    }

    var Factorycounter = parseInt($('#<%= hdnFactoryCounter.ClientID %>').val());
    function AddFactoryRepresentative() {
        //debugger;
        if (jQuery.trim($('#<%= txtFactoryRepresentitive.ClientID %>').val()) != '') {
            var objIds = '<%=hdnFactoryRepresentativeId.ClientID%>';
            var objNames = '<%=hdnFactoryRepresentativeName.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnFactoryId").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnFactoryId").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnFactoryId").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtFactoryRepresentitive.ClientID %>').val('');
                            $("#hdnFactoryId").val('0');
                            $("#hdnFactoryName").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnFactoryName").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnFactoryName").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnFactoryName").val();
                }
            }
            else {
                if ((strNames) == '') {
                    strIds = 0;
                    strNames = $('#<%= txtFactoryRepresentitive.ClientID %>').val();
                }
                else {
                    strIds = strIds + ',' + 0;
                    strNames = strNames + ',' + $('#<%= txtFactoryRepresentitive.ClientID %>').val();
                }
            }

            var FactoryRepresentativeId = $("#hdnFactoryId").val();
            var FactoryRepresentativeName = $('#<%= txtFactoryRepresentitive.ClientID %>').val();
            if ($("#" + objNames).val().indexOf($('#<%= txtFactoryRepresentitive.ClientID %>').val()) == -1) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvFactoryRepresentative' + Factorycounter);
                if (Factorycounter == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtFactoryRepresentitive.ClientID %>').val() + ' <a onclick="DeleteFactoryRepresentative(' + Factorycounter + ', ' + FactoryRepresentativeId + ', \'' + FactoryRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtFactoryRepresentitive.ClientID %>').val() + ' <a onclick="DeleteFactoryRepresentative(' + Factorycounter + ', ' + FactoryRepresentativeId + ', \'' + FactoryRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvFactoryRepresentativeValues.ClientID %>");

                $("#" + objIds).val(strIds);
                $("#" + objNames).val(strNames);

                $("#hdnFactoryId").val('0');
                $("#hdnFactoryName").val('');
            }
            else {
                alert("This Representative already exist")
            }
            $('#<%= txtFactoryRepresentitive.ClientID %>').val('');
            Factorycounter++;

        }
        else {
            alert("Please enter Factory Representative.")
        }
    }

    function DeleteFactoryRepresentative(Factorycounter, FactoryRepresentativeId, FactoryRepresentativeName) {
        //    debugger;
        var FactoryRepresentativeIds = $("#<%=hdnFactoryRepresentativeId.ClientID%>").val();
        var FactoryRepresentativeNames = $("#<%=hdnFactoryRepresentativeName.ClientID%>").val();

        $("#dvFactoryRepresentative" + Factorycounter).remove();
        $("#<%=hdnFactoryRepresentativeId.ClientID%>").val(FactoryRepresentativeIds.replace(FactoryRepresentativeId, ''));
        $("#<%=hdnFactoryRepresentativeName.ClientID%>").val(FactoryRepresentativeNames.replace(FactoryRepresentativeName, ''));

        FactoryRepresentativeIds = $("#<%=hdnFactoryRepresentativeId.ClientID%>").val();
        FactoryRepresentativeIds = (FactoryRepresentativeIds.replace(',,', ','));

        FactoryRepresentativeNames = $("#<%=hdnFactoryRepresentativeName.ClientID%>").val();
        FactoryRepresentativeNames = (FactoryRepresentativeNames.replace(',,', ','));

        $("#<%=hdnFactoryRepresentativeId.ClientID%>").val(FactoryRepresentativeIds);
        $("#<%=hdnFactoryRepresentativeName.ClientID%>").val(FactoryRepresentativeNames);

        var lastCharFactoryRepresentativeIds = FactoryRepresentativeIds.substr(FactoryRepresentativeIds.length - 1);
        var lastCharFactoryRepresentativeNames = FactoryRepresentativeNames.substr(FactoryRepresentativeNames.length - 1);

        if (lastCharFactoryRepresentativeIds === ",") {
            $("#<%=hdnFactoryRepresentativeId.ClientID%>").val(FactoryRepresentativeIds.substring(0, FactoryRepresentativeIds.length - 1))
        }

        if (lastCharFactoryRepresentativeNames === ",") {
            $("#<%=hdnFactoryRepresentativeName.ClientID%>").val(FactoryRepresentativeNames.substring(0, FactoryRepresentativeNames.length - 1))
        }
    }

    var Merchandisercounter = parseInt($('#<%= hdnMerchandiserCounter.ClientID %>').val());
    function AddMerchandiserRepresentative() {
            //debugger;
        if ($('#<%= txtMerchandiserRepresentative.ClientID %>').val() != "") {
            var objIds = '<%=hdnMerchandiserRepresentativeId.ClientID%>';
            var objNames = '<%=hdnMerchandiserRepresentativeName.ClientID%>';

            var strIds = $("#" + objIds).val();
            var strNames = $("#" + objNames).val();
            var IdsArr = '';
            if ($("#hdnMerchandiserId").val() != 0) {
                if ((strIds) == '') {
                    strIds = $("#hdnMerchandiserId").val();
                }
                else {
                    strIds = strIds + ',' + $("#hdnMerchandiserId").val();
                    IdsArr = strIds.split(',');

                    var tmp = [];
                    for (var i = 0; i < IdsArr.length; i++) {
                        if (tmp.indexOf(IdsArr[i]) == -1) {
                            tmp.push(IdsArr[i]);
                        }
                        else {
                            alert('This Representative already exist');
                            $('#<%= txtMerchandiserRepresentative.ClientID %>').val('');
                            $("#hdnMerchandiserId").val('0');
                            $("#hdnMerchandiserName").val('');
                            return;
                        }
                    }
                }
            }
            if ($("#hdnMerchandiserName").val() != '') {
                if ((strNames) == '') {
                    strNames = $("#hdnMerchandiserName").val();
                }
                else {
                    strNames = strNames + ',' + $("#hdnMerchandiserName").val();
                }
            }

            $("#" + objIds).val(strIds);
            $("#" + objNames).val(strNames);

            var MerchandiserRepresentativeId = $("#hdnMerchandiserId").val();
            var MerchandiserRepresentativeName = $("#hdnMerchandiserName").val();

            if (parseInt(MerchandiserRepresentativeId) > 0) {
                var newTextBoxDiv = $(document.createElement('span')).attr("id", 'dvMerchandiserRepresentative' + Merchandisercounter);
                if (Merchandisercounter == 0) {
                    newTextBoxDiv.append('<span>' + $('#<%= txtMerchandiserRepresentative.ClientID %>').val() + ' <a onclick="DeleteMerchandiserRepresentative(' + Merchandisercounter + ', ' + MerchandiserRepresentativeId + ', \'' + MerchandiserRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                else {
                    newTextBoxDiv.append('<span>,' + $('#<%= txtMerchandiserRepresentative.ClientID %>').val() + ' <a onclick="DeleteMerchandiserRepresentative(' + Merchandisercounter + ', ' + MerchandiserRepresentativeId + ', \'' + MerchandiserRepresentativeName + '\')" class="remove_field"><img src="../../images/delete.png" /></a></span>');
                }
                newTextBoxDiv.appendTo("#<%= dvMerchandiserRepresentativeValues.ClientID %>");
            }
            else {
                alert("This Representative does not exist. Please enter a valid Representative.")
            }
            $('#<%= txtMerchandiserRepresentative.ClientID %>').val('');
            Merchandisercounter++;
            $("#hdnMerchandiserId").val('0');
            $("#hdnMerchandiserName").val('');
        }
        else {
            alert("Please enter Merchandiser Representative.")
        }
    }

    function DeleteMerchandiserRepresentative(Merchandisercounter, MerchandiserRepresentativeId, MerchandiserRepresentativeName) {
            //debugger;
        var MerchandiserRepresentativeIds = $("#<%=hdnMerchandiserRepresentativeId.ClientID%>").val();
        var MerchandiserRepresentativeNames = $("#<%=hdnMerchandiserRepresentativeName.ClientID%>").val();

        $("#dvMerchandiserRepresentative" + Merchandisercounter).remove();
        $("#<%=hdnMerchandiserRepresentativeId.ClientID%>").val(MerchandiserRepresentativeIds.replace(MerchandiserRepresentativeId, ''));
        $("#<%=hdnMerchandiserRepresentativeName.ClientID%>").val(MerchandiserRepresentativeNames.replace(MerchandiserRepresentativeName, ''));

        MerchandiserRepresentativeIds = $("#<%=hdnMerchandiserRepresentativeId.ClientID%>").val();
        MerchandiserRepresentativeIds = (MerchandiserRepresentativeIds.replace(',,', ','));

        MerchandiserRepresentativeNames = $("#<%=hdnMerchandiserRepresentativeName.ClientID%>").val();
        MerchandiserRepresentativeNames = (MerchandiserRepresentativeNames.replace(',,', ','));

        $("#<%=hdnMerchandiserRepresentativeId.ClientID%>").val(MerchandiserRepresentativeIds);
        $("#<%=hdnMerchandiserRepresentativeName.ClientID%>").val(MerchandiserRepresentativeNames);

        var lastCharMerchandiserRepresentativeIds = MerchandiserRepresentativeIds.substr(MerchandiserRepresentativeIds.length - 1);
        var lastCharMerchandiserRepresentativeNames = MerchandiserRepresentativeNames.substr(MerchandiserRepresentativeNames.length - 1);

        if (lastCharMerchandiserRepresentativeIds === ",") {
            $("#<%=hdnMerchandiserRepresentativeId.ClientID%>").val(MerchandiserRepresentativeIds.substring(0, MerchandiserRepresentativeIds.length - 1))
        }

        if (lastCharMerchandiserRepresentativeNames === ",") {
            $("#<%=hdnMerchandiserRepresentativeName.ClientID%>").val(MerchandiserRepresentativeNames.substring(0, MerchandiserRepresentativeNames.length - 1))
        }
    }
</script>
