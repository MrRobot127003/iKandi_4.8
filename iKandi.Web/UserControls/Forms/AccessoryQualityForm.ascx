<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccessoryQualityForm.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.AccessoryQualityForm" %>
 <script type="text/javascript">

     $(function () {
         $(".th").datepicker({ dateFormat: 'dd M y (D)' });
     });
  
  </script> 
<script type="text/javascript">
    var tblUploadPictureClientID = "tblUploadPicture";
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var txtSuppliernameClientID = '<%=txtSupplierName.ClientID %>';
    var GroupDDClientID = '<%=ddlGroup.ClientID%>';
    var SubGroupDDClientID = '<%=ddlSubGroup.ClientID%>';
    var selectedSubGroup;
    var hdnSubGroupClientID = '<%=hiddenSubGroupId.ClientID %>';
    var txtIdentificationClientID = '<%=txtIdentification.ClientID %>';
    var txtTradeNameClientID = '<%=txtTradeName.ClientID %>';
    var jscriptPageVariables = null;
    var prevSubGroup;

    function GetIdBySupplierRef() {
        proxy.invoke("GetIdBySupplierRef", { SupplierRef: ($("#<%=txtSupplierReference.ClientID %>")).val() },
    function(result) {
        if (result > 0) {
            window.location = "/Internal/Fabric/AccessoryQualityEdit.aspx?accessoryqualityid=" + result;
        }
    },

    onPageError, false, false);
    }


    $(function () {
        prevSubGroup = $("#" + hdnSubGroupClientID, "#main_content").val();

        $("input.accessory-suppliername", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestAccessorySupplierName", { dataType: "xml", datakey: "string", max: 100 });
        $("input.accessory-category", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestAccessoryCategory", { dataType: "xml", datakey: "string", max: 100 });


        $("input.accessory-supplierRef", "#main_content").result(function () {

            GetIdBySupplierRef();

        });

        $("input.accessory-supplierRef", "#main_content").change(function () {

            GetIdBySupplierRef();

        });


        $("a[rel=lightbox]").lightBox({

            imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

            imageBtnPrev: '/app_themes/ikandi/images/lightbox-btn-prev.gif',

            imageBtnNext: '/app_themes/ikandi/images/lightbox-btn-next.gif',

            imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

            imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif'

        });

        $("#" + GroupDDClientID, '#main_content').change(function () {
          
            var groupId = $(this).val();
            populateSubGroups($(this).val());
            getIdentification($("#" + GroupDDClientID, '#main_content').val(), $("#" + SubGroupDDClientID, '#main_content').val());
        });

        $("#" + SubGroupDDClientID, '#main_content').change(function () {
            $("#" + hdnSubGroupClientID, "#main_content").val($(this).val());
            selectedSubGroup = $("#" + SubGroupDDClientID).find("option:selected").text();
            setSubGroup();
            if (prevSubGroup != $(this).val()) {
                getIdentification($("#" + GroupDDClientID, '#main_content').val(), $("#" + SubGroupDDClientID, '#main_content').val());
            }
            else if (prevSubGroup == $(this).val()) {
                var defVal = $("#" + txtIdentificationClientID, '#main_content')[0];
                $("#" + txtIdentificationClientID, '#main_content').val(defVal.defaultValue);
            }

        });

        populateSubGroups($("#" + GroupDDClientID, '#main_content').val());


    });


    //function addRow(objRow)
    // {
    //   var rowCount = $("#"+tblUploadPictureClientID + " tr").length;
    //     
    //   var lastRow = $("#"+tblUploadPictureClientID + " tr:last");
    //   
    //   var row = $("#"+tblUploadPictureClientID + " tr:last").clone(true).insertAfter($("#"+tblUploadPictureClientID + " tr:last"));
    //  
    //   var newLastRow = $("#"+tblUploadPictureClientID + " tr:last");



    //    newLastRow.find("input,select,textarea").val("").each(function()
    //   {
    //      
    //      var name = $(this).attr("name"); 
    //      $(this).attr("name",  name.replace(rowCount, (rowCount+1) ) );
    //      var id = $(this).attr("id");   
    //      $(this).attr("id",  id.replace(rowCount, (rowCount+1) ) );
    //      $(this).removeAttr("disabled"); 
    //   
    //   });
    // }

    function populateSubGroups(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, SubGroupDDClientID, "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroup)
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function setSubGroup() {
        selectedSubGroup = $("#" + SubGroupDDClientID, "#main_content").val();
        //$("#" + hdnSubGroupClientID, "#main_content").val(selectedSubGroup);
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function getIdentification(groupId, subGroupId) {
        
        proxy.invoke("GetIdentification", { CategoryID: groupId, SubCategoryID: subGroupId, Type: 2 }, function(result) {
            $("#" + txtIdentificationClientID, '#main_content').val(result);
        }, onPageError, false, false);
    }

    function ValidateTradeName(oSrc, args) {
        var result = IsTradeNameUnique(args.Value);
        args.IsValid = result;
    }

    function IsTradeNameUnique(tradeName) {
        if (($("#<%=txtTradeName.ClientID %>")).val() == '') return true;

        var isValid = true;

        proxy.invoke("GetAccIdByTradeName", { TradeName: ($("#<%=txtTradeName.ClientID %>")).val() },
         function(result) {
             if (result > 0)
                 isValid = false;
         },
         onPageError, false, true);

        return isValid;
    }

    function deleteImg(srcElem, imageId) {
        proxy.invoke("ImageAccessoryDelete", { ImageId: imageId },
         function(result) {
             if (result) {
                 $(srcElem).parent().hide();
             }
             return true;
         },
         onPageError, false, true);
        return false;

    }

 
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style8
    {
        height: 75px;
    }
    .style9
    {
        height: 75px;
        width: 11%;
    }
    .grid_heading {
    color: #fff;
    font-size: 16px;
    background-color: #39589c;
    color: #ffffff !important;
    text-align:center;
    padding:5px 0px;
     text-transform: capitalize;
}
h3
{
 color: #39589c;
 font-size: 12px;
 margin:0px;
 padding:0px;
}
h2
{
 color: #39589c;
 font-size: 14px;
 margin:0px;
 padding:0px;
  text-transform: capitalize;
}
.item_list {
    border-color: #ccc;
}
.item_list th {
    padding-left: 8px !important;
}
.item_list td {
    border-color: #ccc;

}
</style>
<asp:Panel runat="server" ID="pnlAccessoryForm">
    <div class="print-box">
        <div class="form_box">
            <div class="grid_heading">
                <strong>Accessory Quality</strong>
            </div>
        </div>
        <div class="form_box">
            <table width="100%" class="item_list" border="1"  >
                <tr>
                    <td colspan="8" style="text-align: left;">
                       <h3>  Classification </h3>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 12.5%;">
                        Group*
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:DropDownList ID="ddlGroup" runat="server">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="ddlGroup" InitialValue="-1" ErrorMessage="Select Group"></asp:RequiredFieldValidator>
                    </td>
                    <th style="text-align: left; width: 12.5%;">
                        Sub Group*
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:DropDownList ID="ddlSubGroup" runat="server">
                            <asp:ListItem Selected="True" Text="Select.." Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                            ControlToValidate="ddlSubGroup" InitialValue="-1" ErrorMessage="Select Sub Group"></asp:RequiredFieldValidator>--%>
                        <asp:HiddenField runat="server" ID="hiddenSubGroupId" Value="-1" />
                    </td>
                    <th style="text-align: left; width: 12.5%;">
                        Identification
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:TextBox ID="txtIdentification" runat="server" CssClass="do-not-allow-typing"
                            Style="text-align: left"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 12.5%;">
                        Supplier Reference*
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:TextBox ID="txtSupplierReference" runat="server" CssClass="accessory-supplierRef"
                            Style="text-align: left" MaxLength="43"></asp:TextBox>
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfvSupplierReferenc" runat="server" Display="Dynamic"
                                ControlToValidate="txtSupplierReference" ErrorMessage="Supplier Reference is required"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 16.6%;" colspan="2">
                        Trade Name*
                    </th>
                    <td style="text-align: left; width: 16.6%;" colspan="2">
                        <asp:TextBox runat="server" ID="txtTradeName" CssClass="quality-tradename"
                            Style="text-align: left" MaxLength="65"></asp:TextBox>
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfvTradeName" runat="server" Display="Dynamic" ControlToValidate="txtTradeName"
                                ErrorMessage="Trade Name is required"></asp:RequiredFieldValidator>
                            <%-- <asp:CustomValidator runat="server" Display="Dynamic" ID="custom_TradeName" ControlToValidate="txtTradeName"
                                ErrorMessage="Trade Name  already exists in the system" ClientValidationFunction="ValidateTradeName">
                            </asp:CustomValidator>--%>
                        </div>
                    </td>
                    <th style="text-align: left; width: 12.5%;">
                        Price
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:TextBox ID="txtPrice" runat="server" 
                            Style="text-align: left"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 12.5%;">
                         BIPL Registered
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:CheckBox ID="chkBiplRegistered" runat="server" />
                     </td>
                </tr>
            </table>
        </div>
     
        <div class="form_box">
            <table width="100%" class="item_list" border="1" >
                <tr>
                    <td colspan="6" style="text-align: left;">
                        <h3> Client and supplier </h3>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 12.5%;">
                        Buyer
                    </th>
                    <td style="text-align: left; width: 37.5%;">
                        <asp:ListBox runat="server" ID="lstClients" SelectionMode="Multiple" Width="100%">
                        </asp:ListBox>
                    </td>
                    <th style="text-align: left; width: 12.5%;">
                        Origin*
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:DropDownList runat="server" ID="txtorigin">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfv_txtorigin" runat="server" Display="Dynamic" ControlToValidate="txtorigin"
                                InitialValue="-1" ErrorMessage="Select origin"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <th style="text-align: left; width: 12.5%;">
                        Supplier Name*
                    </th>
                    <td style="text-align: left; width: 12.5%;">
                        <asp:TextBox ID="txtSupplierName" runat="server" Class="accessory-suppliername" Style="text-align: left;"
                            MaxLength="43"></asp:TextBox>
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfvSupplierName" runat="server" Display="Dynamic"
                                ControlToValidate="txtSupplierName" ErrorMessage="Supplier Name is required"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
            </table>
        </div>
      
        <div class="form_box">
            <table width="100%" class="item_list" border="1" >
                <tr>
                    <td colspan="6" style="text-align: left;">
                        <h3> Technical Details </h3>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left; width: 16.6%;">
                        Description
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtComposition" MaxLength="43" Style="text-align: left;"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Wastage(%)
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox runat="server" ID="txtWastage" CssClass="numeric-field-without-decimal-places"
                            Style="text-align: left;" MaxLength="3"></asp:TextBox>
                    </td>
                    <th style="text-align: left; width: 16.6%;">
                        Lead time (in days)
                    </th>
                    <td style="text-align: left; width: 16.6%;">
                        <asp:TextBox ID="txtLeadTimeInDays" runat="server" CssClass="numeric-field-without-decimal-places"
                            Style="text-align: left;" MaxLength="4"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
     
    </div>
    <div class="form_box">
        <table width="100%" class="item_list" border="1" >
            <tr>
                <td colspan="6" style="text-align: left;">
                   <h3> Limitations </h3>
                </td>
            </tr>
            <tr>
                <th style="text-align: left; width: 16.6%;">
                    Upload Base Test
                </th>
                <td style="text-align: left; width: 16.6%;">
                    <asp:FileUpload runat="server" ID="fileBaseTest" />
                    <a target="_blank" href="" runat="server" id="basetestfile" visible="false">Link</a>
                    <asp:HiddenField runat="server" ID="hdnUpdateBaseFilePath" />
                </td>
                <th style="text-align: left; width: 16.6%;">
                    Date When Test Conducted
                </th>
                <td style="text-align: left; width: 16.6%;">
                    <asp:TextBox runat="server" ID="txtTestDate" CssClass="date-picker date_style" Style="text-align: left;"></asp:TextBox>
                </td>
                <th style="text-align: left; width: 16.6%;">
                    Minimum Order Quantity (MOQ)
                </th>
                <td style="text-align: left; width: 16.6%;">
                    <asp:TextBox runat="server" ID="txtMOQ" CssClass="numeric-field-with-decimal-places"
                        Style="text-align: left;" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
  
    <div class="form_box">
        <table width="100%" class="item_list" id="tblUploadPicture" border="1" >
            <tr>
                <td colspan="3" style="text-align: left;">
                   <h3> Upload </h3> 
                </td>
            </tr>
            <tr>
                <th style="text-align: left; width: 33.3%;">
                    Upload Pic
                </th>
                <td style="text-align: left; width: 33.3%;">
                    <asp:FileUpload runat="server" ID="fileUploadPicture" class="multi" accept="gif|jpg|bmp|png" />
                </td>
                <td style="text-align: left; width: 33.3%;">
                    <asp:Repeater ID="rptUploadPicture" runat="server">
                        <ItemTemplate>
                            <div style="vertical-align: middle;">
                                <asp:HyperLink ID="hypSample1" runat="server" rel="lightbox" NavigateUrl='<%# ResolveUrl("~/Uploads/Quality/" + (Eval("ImageFile"))) %>'>
                                    <asp:Image runat="server" ID="imgAccessoryQuality" CssClass="lightbox" Width="60px"
                                        Height="60px" ImageUrl='<%# ResolveUrl("~/uploads/Quality/thumb-" + (Eval("ImageFile"))) %>' />
                                </asp:HyperLink>
                                <input type="button" id="btnImageDelete" class="cross" onclick='return deleteImg(this,<%# Eval("id")%>)' />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <%--<tr><td>Fabric Physical sample : please attach on form</td></tr>--%>
        </table>
        <%-- <div align="right">
            <img src="../../App_Themes/ikandi/images/plus.gif" id="btnAddRow" onclick="addRow( this)" />
            Add More &nbsp;
        </div>--%>
    </div>
   
    <div class="form_box">
        <div class="form_small_heading" align="center">
            <h2> Authorised Signatures</h2>
        </div>
        <table width="100%" class="item_list" border="1" >
            <tr>
                <td colspan="3" style="text-align: left;">
                   <h3> Authorised Signatures </h3>
                </td>
            </tr>
            <tr>
                <th style="text-align: left; width: 33.3%;">
                    Date
                </th>
                <td style="text-align: left; width: 33.3%;">
                    <asp:TextBox runat="server" ID="txtApprovalDate" CssClass="th date_style"
                        Style="text-align: left;"></asp:TextBox>
                </td>
                <td style="text-align: left; width: 33.3%;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
   
    <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" Text="Submit" OnClick="btnSubmit_Click" />
        <input type="button" id="btnPrint" class="print da_submit_button" value="Print" onclick="return PrintPDF();" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Accessory Quality have been saved into the system successfully!
            <br />
            <a id="A1" href="../../Internal/Fabric/AccessoryQualityListing.aspx" runat="server">
                Click here </a>to Accessory Quality List.</div>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlError" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Accessory Quality has not been saved due to dublicate Identifaction number or some error occurs into the system while saving data!
            <br />
            <a id="A2" href="../../Internal/Fabric/AccessoryQualityListing.aspx" runat="server">
                Click here </a>to Accessory Quality List.</div>
    </div>
</asp:Panel>