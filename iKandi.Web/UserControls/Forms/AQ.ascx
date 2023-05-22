<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AQ.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.AQ" %>
<link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: verdana;
    }
     #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
    table
    {
        font-family: verdana;
        border-color: gray;
        border-collapse: collapse;
    }
    th
    {
        background: #dddfe4;
        font-weight: normal;
        color: #575759;
        font-family: arial,halvetica;
        font-size: 10px;
        padding: 5px 0px 5px 0px;
        text-transform: capitalize;
        text-align: center;
        border: 1px solid #c6c2c2;
    }
    table td
    {
        font-size: 11px;
        text-align: center;
        border-color: #aaa;
        text-transform: capitalize;
    }
    .per
    {
        color: blue;
    }
    .gray
    {
        color: gray;
    }
    h2
    {
        font-size: 12px;
        font-weight: bold;
        padding: 5px;
        background: #dddfe4;
        color: #575759;
        width: 89.4%;
        text-align: center;
    }
    .row-fir th
    {
        font-weight: bold;
        font-size: 11px;
    }
    table td table td
    {
        border-color: #ddd;
    }
   input,select
    {
        width: 94%;
        padding: 0px;
        height:18px;
    }
    div select option
    {
        padding: 4px 0px;
        width: 94%;
    }
    div input
    {
        width: 94%;
        color: blue;
        padding: 4px 0px;
    }
    .style_number_box_background
    {
        opacity: 0.9;
        background: grey;
        width: 2400px;
    }
    .style_number_box
    {
        padding: 0px !important;
        width: 550px !important;
        border: none;
    }
    .style_number_box table
    {
        border: 1px solid gray;
        padding-bottom: 5px;
    }
    .style_number_box div
    {
        background-color: #39589c;
        color: #fff;
        font-size: 14px;
        font-weight: bold;
        text-align: center;
        text-transform: capitalize;
        width: 100%;
        padding: 5px 0px;
    }
    .style_number_box
    {
        top: 50px !important;
        left: 50% !important;
        position: absolute !important;
    }
    .hover_row
    {
        background-color: #A1DCF2;
    }
    .inner-table
    {
        border-color: #f2f2f2;
        text-align: left;
    }
    .inner-table td
    {
        text-align: left;
        padding: 0px 0px 0px 3px;
    }
    .foo-input, foo-select
    {
        font-size: 9px;
        height: 13px;
    }
    .inner-table td input
    {
        padding: 0px;
    }
    
    .inner-table select, .inner-table select option
    {
        padding: 0px;
        width: 94%;
        font-size: 9px;
    }
    .fab-reg input
    {
        width:18%;
        height:auto;
    }
    input[type="text"]
    {
        height:11px;
    }
</style>

<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<script type="text/javascript">

    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });
    });
  
</script>
<script type="text/javascript">
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var jscriptPageVariables = null;
    var GroupDDClientID = '<%=ddlGroup.ClientID%>';
    var SubGroupDDClientID = '<%=ddlSubGroup.ClientID%>';
    var hdnSubGroupClientID = '<%=hiddenSubGroupId.ClientID %>';
    var gdvAQMaster = '<%= gdvAQMaster.ClientID %>';
    //$('<%=((HiddenField)gdvAQMaster.FooterRow.FindControl("hiddenSubGroupFooterId")).ClientID %>');

    $(function () {

        $("#" + GroupDDClientID, '#main_content').change(function () {
            var groupId = $(this).val();
            populateSubGroups($(this).val());
        });

        $("#" + SubGroupDDClientID, '#main_content').change(function () {
            $("#" + hdnSubGroupClientID, "#main_content").val($(this).val());
            selectedSubGroup = $("#" + SubGroupDDClientID).find("option:selected").text();
            setSubGroup();
        });

        $('.GroupDDFooter').change(function () {
            var groupId = $(this).val();
            populateSubGroupsFooter($(this).val());
        });

        $('.GroupDDGrid').change(function () {
            var groupId = $(this).val();
            populateSubGroupsGrid($(this).val());
        });


        $('.SubGroupDDFooter').change(function () {
            $('#<%=gdvAQMaster.ClientID %>').find('input:hidden[id$="hiddenSubGroupFooterId"]').val($(this).val());

        });

        $('.SubGroupDDGrid').change(function () {
            $('#<%=gdvAQMaster.ClientID %>').find('input:hidden[id$="hiddenSubGroupIdGrid"]').val($(this).val());
        });

        $("input.fabricquality-tradename").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQualityTradeName", { dataType: "xml", datakey: "string", max: 100 });
//        $("input.fabricquality-suppliername").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQualitySupplierReference", { dataType: "xml", datakey: "string", max: 100 });


    });


    function populateSubGroups(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, SubGroupDDClientID, "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroup);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }

    function setSubGroup() {
        selectedSubGroup = $("#" + SubGroupDDClientID, "#main_content").val();
        $("#" + SubGroupDDClientID, '#main_content').val($("#" + hdnSubGroupClientID, "#main_content").val());
    }


    function populateSubGroupsFooter(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, '.SubGroupDDFooter', "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroupFooter);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        // $('.SubGroupDDFooter').val($(hdnFooterSubGroupClientID).val());
    }

    function setSubGroupFooter() {
        selectedSubGroup = $('.SubGroupDDFooter').val();
        // $('.SubGroupDDFooter').val($(hdnFooterSubGroupClientID).val());
    }


    function populateSubGroupsGrid(groupId, selectedSubGroupID) {
        if (groupId > 0)
            bindDropdown(serviceUrl, '.SubGroupDDGrid', "GetSubGroupByGroupID", { CategoryID: groupId }, "CategoryName", "CategoryID", true, (jscriptPageVariables != null) ? jscriptPageVariables.selectedSubGroupID : selectedSubGroupID, onPageError, setSubGroupGrid);
        if (jscriptPageVariables != null && jscriptPageVariables.selectedSubGroupID != null && jscriptPageVariables.selectedSubGroupID != '')
            jscriptPageVariables.selectedSubGroupID = '';
        $('.SubGroupDDGrid').val($(hdnSubGroupClientID).val());
    }

    function setSubGroupGrid() {
        selectedSubGroup = $('.SubGroupDDGrid').val();
        $('.SubGroupDDGrid').val($(hdnSubGroupClientID).val());
    }

    function extractNumber(obj, decimalPlaces, allowNegative) {
        var temp = obj.value;

        // avoid changing things if already formatted correctly
        var reg0Str = '[0-9]*';
        if (decimalPlaces > 0) {
            reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
        } else if (decimalPlaces < 0) {
            reg0Str += '\\.?[0-9]*';
        }
        reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
        reg0Str = reg0Str + '$';
        var reg0 = new RegExp(reg0Str);
        if (reg0.test(temp)) return true;

        // first replace all non numbers
        var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
        var reg1 = new RegExp(reg1Str, 'g');
        temp = temp.replace(reg1, '');

        if (allowNegative) {
            // replace extra negative
            var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
            var reg2 = /-/g;
            temp = temp.replace(reg2, '');
            if (hasNegative) temp = '-' + temp;
        }

        if (decimalPlaces != 0) {
            var reg3 = /\./g;
            var reg3Array = reg3.exec(temp);
            if (reg3Array != null) {
                // keep only first occurrence of .
                //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
                var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
                reg3Right = reg3Right.replace(reg3, '');
                reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
                temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
            }
        }
        obj.value = temp;
    }

</script>
<script type="text/javascript">
    var GrdIndex;
    function UploadFile(index) {
        GrdIndex = index - 1;
        var FileName = $('.hdnFldFilePath').eq(GrdIndex).val();
        var url = '../Merchandising/QCUpload.aspx?index=' + GrdIndex + '&FileName=' + FileName;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 330, width: 700, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
    }

    function SBClose() {
    }

    function SaveFile(index, FileName) {
        $('.hdnFldFilePath').eq(GrdIndex).val(FileName);
    }

    $(function () {
        $("[id*=gdvAQMaster] td").hover(function () {
            $("td", $(this).closest("tr")).addClass("hover_row");
        }, function () {
            $("td", $(this).closest("tr")).removeClass("hover_row");
        });
    });

</script>
<script type="text/javascript">


    function validateAndHighlight() {
        for (var i = 0; i < Page_Validators.length; i++) {
            var val = Page_Validators[i];
            var ctrl = document.getElementById(val.controltovalidate);
            if (ctrl != null && ctrl.style != null) {
                if (!val.isvalid) {
                    ctrl.style.borderColor = '#FF0000';
                    //ctrl.style.backgroundColor = '#fce697';
                }
                else {
                    ctrl.style.borderColor = '';
                    ctrl.style.backgroundColor = '';
                }
            }
        }
    }
</script>

  <script type="text/javascript" language="javascript">
      $(document).ready(function () {
          ShowImagePreview();
      });
      // Configuration of the x and y offsets
      function ShowImagePreview() {
          xOffset = 250;
          yOffset = 100;
          $("a.preview").hover(function (e) {
              this.t = this.title;
              this.title = "";
              var c = (this.t != "") ? "<br/>" + this.t : "";
              $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:400px !important; width:300px !important;'/>" + c + "</p>");
              $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
          },

function () {
    this.title = this.t;
    $("#preview").remove();
});

          $("a.preview").mousemove(function (e) {
              $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
          });
      };

    </script>

<h2>
    Accessory Quality Form
</h2>
    <table cellspacing="0" cellpadding="0" border="1" width="90%">
        <thead>
            <tr>
                <th width="40">
                    Search
                </th>
                <td width="135">
                    <asp:TextBox ID="txtSearch" runat="server" ToolTip="this field for Supplier Reference or Supplier Name or Trade name or Identification number"></asp:TextBox>
                </td>
                <th width="40">
                    Group
                </th>
                <td width="120">
                    <asp:DropDownList ID="ddlGroup" runat="server">
                        <asp:ListItem Selected="True" Text="--All--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <th width="60">
                    Sub Group
                </th>
                <td width="120">
                    <asp:DropDownList ID="ddlSubGroup" runat="server">
                        <asp:ListItem Selected="True" Text="--All--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="hiddenSubGroupId" Value="-1" />
                </td>
                <th width="40">
                    Trade
                </th>
                <td width="120">
                    <asp:TextBox ID="txtTrade" runat="server" CssClass="fabricquality-tradename"></asp:TextBox>
                </td>
                <th width="45">
                    Unit
                </th>
                <td width="45">
                    <asp:DropDownList ID="DDlUnit" runat="server">
                        <asp:ListItem Selected="True" Text="--All--" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Kg" Value="1"> </asp:ListItem>
                        <asp:ListItem Text="Mt" Value="2"> </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <th width="45">
                    Origin
                </th>
                <td width="55">
                    <asp:DropDownList ID="DDlOrigin" runat="server">
                        <asp:ListItem Text="--All--" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                 <th width="60">
                    Accessory Type
                </th>
                <td width="100">
                    <asp:DropDownList ID="ddlAcctype" runat="server">
                        <asp:ListItem Text="--All--" Value="-1"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="Reg Accsessory" Value="1"></asp:ListItem>
                        <asp:ListItem  Text="Un Reg Accsessory" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="HiddenField1" Value="-1" />
                </td>
                <td width="35">
                    <asp:LinkButton ID="lkbGo" runat="server" CausesValidation="false" CssClass="submit" Text="Search" style="float:right" OnClick="lkbGo_Click">
                                        <%--<img src="../../App_Themes/ikandi/images/MO_go.jpg" alt="Search" title="Search"
                                         border="0" />--%>
                    </asp:LinkButton>
                </td>
            </tr>
        </thead>
    </table>
    <div style="height: 10px;">
    </div>
    <asp:GridView ID="gdvAQMaster" runat="server" DataKeyNames="AccessoryMaster_ID" Width="90%"
        ShowFooter="True" OnRowCommand="gdvAQMaster_RowCommand" OnPageIndexChanging="gdvAQMaster_PageIndexChanging"
        AutoGenerateColumns="false" OnRowEditing="gdvAQMaster_RowEditing" OnRowCancelingEdit="gdvAQMaster_RowCancelingEdit"
        OnRowUpdating="gdvAQMaster_RowUpdating" AllowPaging="true" PageSize="10">
        <SelectedRowStyle BackColor="#A1DCF2" />
        <Columns>
            <asp:TemplateField HeaderText="S.No.">
                <ItemStyle HorizontalAlign="Center" Width="5%" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Group" HeaderStyle-Width="20%">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="GroupDDGrid">
                        <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlGroup" runat="server" ErrorMessage="" CssClass="errorMsg"
                        InitialValue="-1" ControlToValidate="ddlGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlFooterGroup" runat="server" CssClass="GroupDDFooter">
                        <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlFooterGroup" runat="server" ErrorMessage=""
                        ValidationGroup="F" CssClass="errorMsg" InitialValue="-1" ControlToValidate="ddlFooterGroup"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("GroupName") %>'></asp:Label>
                    <asp:HiddenField ID="hdnfGroupID" runat="server" Value='<%# Eval("CategoryId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sub Group" HeaderStyle-Width="20%">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSubGroup" runat="server" CssClass="SubGroupDDGrid">
                        <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="hiddenSubGroupIdGrid" Value="-1" />
                    <asp:RequiredFieldValidator ID="rfvSubGroup" runat="server" ErrorMessage="" CssClass="errorMsg"
                        InitialValue="-1" ControlToValidate="ddlSubGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlFooterSubGroup" runat="server" CssClass="SubGroupDDFooter">
                        <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="hiddenSubGroupFooterId" Value="-1" />
                    <asp:RequiredFieldValidator ID="rfvddlFooterSubGroup" runat="server" ErrorMessage=""
                        ValidationGroup="F" CssClass="errorMsg" InitialValue="-1" ControlToValidate="ddlFooterSubGroup"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSubGroup" runat="server" Text='<%# Eval("SubGroupName") %>'></asp:Label>
                    <asp:HiddenField ID="hdnfSubGroup" runat="server" Value='<%# Eval("SubCategoryId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trade Name" HeaderStyle-Width="25%">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTradeName" runat="server" Text='<%# Eval("TradeName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTradeNameE" runat="server" ErrorMessage="" ControlToValidate="txtTradeName"
                        CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtFooterTradeName" runat="Server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTradeName" runat="server" ErrorMessage="" ControlToValidate="txtFooterTradeName"
                        ValidationGroup="F" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTradeName" runat="server" Text='<%# Eval("TradeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit" HeaderStyle-Width="10%">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlUnit" runat="server">
                        <asp:ListItem Text="Kg" Value="1"> </asp:ListItem>
                        <asp:ListItem Text="Mt" Value="2"> </asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlFooterUnit" runat="server">
                        <asp:ListItem Text="Kg" Value="1"> </asp:ListItem>
                        <asp:ListItem Text="Mt" Value="2"> </asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlFooterUnit" runat="server" ErrorMessage=""
                        ValidationGroup="F" CssClass="errorMsg" InitialValue="0" ControlToValidate="ddlFooterUnit"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric Type" HeaderStyle-Width="10%">
            
                <ItemTemplate>
                    <asp:Label ID="lblAccsessorytype" runat="server" Text='<%# Eval("AccessoryType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;'
                ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/cancel.jpg" title="Cancel" alt="Cancel" /&gt;'
                UpdateText='&lt;img src="../../images/update.gif" title="Update" alt="Update" /&gt;'
                CausesValidation="true" HeaderText="Action">
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:LinkButton ID="lkSelect" runat="server" CausesValidation="False" CommandName="Select"
                        Text="Select">
                    </asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert"
                        ValidationGroup="F">
                                        <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                         border="0" />
                    </asp:LinkButton>
                </FooterTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="height: 10px;">
    </div>
    <table cellspacing="0" cellpadding="0" border="1" width="1388">
        <thead>
            <tr>
                <th width="100" rowspan="2">
                    Identification
                </th>
                <th colspan="4">
                    Supplier
                </th>
                <th width="80" rowspan="2">
                    Lead Time in Days
                </th>
                <th colspan="3">
                    Limitaion
                </th>
                <th width="80">
                    Upload
                </th>
                <th width="60" colspan="2">
                    Action
                </th>
            </tr>
            <tr>
                <th width="120">
                    Supplier Name
                </th>
                <th width="100">
                    Originie
                </th>
                <th width="120">
                    Supplier Ref.
                </th>
                <th width="80">
                    Price
                </th>
                <th width="120">
                    Upload Base Test
                </th>
                <th width="100">
                    Test Date
                </th>
                <th width="80">
                    Moq
                </th>
                <th width="80">
                    <%--Upload Pic--%> Acc type
                </th>
                <th width="60">
                    Edit / Delete
                </th>
            </tr>
        </thead>
    </table>
    <asp:GridView ID="gdvAQDetails" runat="server" DataKeyNames="AQMasterID, AccessoryQualityID"
        Width="1388" ShowHeader="false" ShowFooter="True" OnRowCommand="gdvAQDetails_RowCommand"
        OnPageIndexChanging="gdvAQDetails_PageIndexChanging" AutoGenerateColumns="false"
        OnRowCancelingEdit="gdvAQDetails_RowCancelingEdit" OnRowUpdating="gdvAQDetails_RowUpdating"
        CellPadding="0" AllowPaging="true" PageSize="10" OnRowEditing="gdvAQDetails_RowEditing"
        OnRowDeleting="gdvAQDetails_RowDeleting">
        <Columns>
            <asp:TemplateField ItemStyle-Width="100" FooterStyle-Width="100">
                <FooterTemplate>
                    <asp:Label ID="lblIdentificationF" runat="server" ForeColor="DarkBlue"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblIdentification" runat="server" Text='<%# Eval("Identification") %>'
                        ForeColor="DarkBlue"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="120" FooterStyle-Width="120">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSupplierName" runat="server" CssClass="SupplierE">
                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSupplierName" runat="server" ErrorMessage="" InitialValue="-1"
                        ControlToValidate="ddlSupplierName" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlSupplierNameF" runat="server" CssClass="SupplierF requiredF">
                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSupplierNameF" runat="server" ErrorMessage=""
                        InitialValue="-1" ControlToValidate="ddlSupplierNameF" ValidationGroup="FD" CssClass="errorMsg"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSupplierName" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="100" FooterStyle-Width="100">
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="ddlOrigin" CssClass="OriginE">
                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlOrigin" runat="server" ErrorMessage="" CssClass="errorMsg"
                        InitialValue="-1" ControlToValidate="ddlOrigin" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList runat="server" ID="ddlOriginF" CssClass="OriginF requiredF">
                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Indian" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Imported" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlOriginF" runat="server" ErrorMessage="" ValidationGroup="FD"
                        CssClass="errorMsg" InitialValue="-1" ControlToValidate="ddlOriginF" Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblOrigin" runat="server" Text='<%# Eval("Origin")!=DBNull.Value ? ( Convert.ToInt32(Eval("Origin"))== 1 ? "Indian" : "Imported"):""  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="120" FooterStyle-Width="120">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSupplierReference" runat="server" CssClass="fabricquality-suppliername"
                        MaxLength="43" Text='<%# Eval("SupplierReference") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSupplierReferenc" runat="server" Display="Dynamic"
                        ControlToValidate="txtSupplierReference" ErrorMessage=""></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtSupplierReferenceF" MaxLength="15" runat="server" CssClass="fabricquality-suppliername requiredF"
                        ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSupplierReferenceF" runat="server" ErrorMessage=""
                        ControlToValidate="txtSupplierReferenceF" ValidationGroup="FD" CssClass="errorMsg"
                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSupplierReference" runat="server" Text='<%# Eval("SupplierReference") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="80" FooterStyle-Width="80">
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtPrice" ToolTip='<%# Eval("OldPrice") != DBNull.Value ? (Convert.ToDecimal(Eval("OldPrice")) <= 0 ? "" : Eval("OldPrice")) : "" %>' CssClass="numeric-field-with-two-decimal-places"
                        MaxLength="10" Text='<%# Eval("Price") != DBNull.Value ? (Convert.ToDecimal(Eval("Price")) <= 0 ? "" : Eval("Price")) : "" %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="" ControlToValidate="txtPrice"
                        ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>

                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtPriceF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPriceF" runat="server" ErrorMessage="" ControlToValidate="txtPriceF"
                        ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" ToolTip='<%# Eval("OldPrice") != DBNull.Value ? (Convert.ToDecimal(Eval("OldPrice")) <= 0 ? "" : Eval("OldPrice")) : "" %>' Text='<%# Eval("Price") != DBNull.Value ? (Convert.ToDecimal(Eval("Price")) <= 0 ? "" : Eval("Price")) : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="80" FooterStyle-Width="80">
                <EditItemTemplate>
                    <asp:TextBox ID="txtLeadTime" runat="server" onkeyup="extractNumber(this,0,false);"
                        Text='<%# Eval("LeadTime") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLeadTime" runat="server" Display="Dynamic" ControlToValidate="txtLeadTime"
                        ErrorMessage=""></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtLeadTimeF" runat="server" onkeyup="extractNumber(this,0,false);"
                        CssClass="requiredF"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLeadTimeF" runat="server" ErrorMessage="" ControlToValidate="txtLeadTimeF"
                        ValidationGroup="FD" CssClass="errorMsg" Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLeadTime" runat="server" Text='<%# Eval("LeadTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="120" FooterStyle-Width="120">
                <EditItemTemplate>
                    <asp:FileUpload runat="server" ID="fileBaseTest" />
                    <asp:HiddenField runat="server" ID="hdnUpdateBaseFilePath" Value='<%# Eval("UploadBaseTestFile") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload runat="server" ID="fileBaseTestF" style="height:90%" />
                    <asp:HiddenField runat="server" ID="hdnUpdateBaseFilePathF" Value='<%# Eval("UploadBaseTestFile") %>' />
                </FooterTemplate>
                <ItemTemplate>
                <%--<img src='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UploadBaseTestFile"))) %>'  title="View File" height="20px" width="20px" style="float:left; <%# "display :" + Eval("IsTestReportvisible").ToString() %>;  />--%>
                <%--<span class="preview" title="<%# ResolveUrl("~/uploads/Quality/" + (Eval("UploadBaseTestFile"))) %>">
            
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UploadBaseTestFile"))) %>' height="20px" width="20px" style="float:left;" onmouseover="ShowBiggerImage(this);" onmouseout="ShowDefaultImage(this);" Visible='<%# String.IsNullOrEmpty(Eval("UploadBaseTestFile").ToString()) ? false : true %>'/> </span>
                    <a target="_blank" href='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UploadBaseTestFile"))) %>'
                        runat="server" id="basetestfile" Visible='<%# String.IsNullOrEmpty(Eval("UploadBaseTestFile").ToString()) ? false : true %>'>
                        <img src="../../images/view-icon.png" title="View File" />
                    </a>--%>
                    <asp:HyperLink ID="HyperLink1" runat="server" visible='<%# String.IsNullOrEmpty(Eval("UploadBaseTestFile").ToString()) ? false : true %>' class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UploadBaseTestFile"))) %>'
                                        Target="_blank">
                                                 <img width="20px" height="20px" alt="" onclick="javascript:void(0)" border="0px" src='<%# ResolveUrl("~/uploads/Quality/" + (Eval("UploadBaseTestFile"))) %>'/>
                                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="100" FooterStyle-Width="100">
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtTestConductedOn" MaxLength="50" Text='<%# Eval("TestConductedOn") %>'
                        Font-Size="Small" CssClass="th"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtTestConductedOnF" MaxLength="50" CssClass="th"
                        Font-Size="Small"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTestConductedOn" runat="server" Text='<%# Eval("TestConductedOn")!=DBNull.Value? (Convert.ToDateTime(Eval("TestConductedOn"))!= DateTime.MinValue ? (DateTime.Parse(Eval("TestConductedOn").ToString()).ToString("dd MMM yy (ddd) ")) : ""):"" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="80" FooterStyle-Width="80">
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtMOQ" CssClass="numeric-field-with-two-decimal-places"
                        MaxLength="10" Text='<%# Eval("MinimumOrderQuality") != DBNull.Value ? (Convert.ToDecimal(Eval("MinimumOrderQuality")) <= 0 ? "" : Eval("MinimumOrderQuality")) : "" %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtMOQF" MaxLength="10" CssClass="numeric-field-with-two-decimal-places"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblMOQ" runat="server" Text='<%# Eval("MinimumOrderQuality") != DBNull.Value ? (Convert.ToDecimal(Eval("MinimumOrderQuality")) <= 0 ? "" : Eval("MinimumOrderQuality")) : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="80" FooterStyle-Width="80">
                <EditItemTemplate>
                <div style="border-bottom:1px solid #d0cdcd; width:100%; height:12px">
                    <a style="cursor: pointer; color:Blue;" onclick='<%# "UploadFile(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                        id="BrowseFile<%# Container.DataItemIndex + 1 %>" title="CLICK TO UPLOAD FILE">Browse
                    </a>
                    <input id="hdnFldFilePath" type="hidden" runat="server" class="hdnFldFilePath" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />
                     </div>
                     <div>
                    <asp:RadioButton ID="rdoeditAccsessorytypeReg" runat="server" Checked="true" Text="Reg Acc." CssClass="fab-reg" GroupName="rdofabrictypeedit" TextAlign="Left" />
                       
                             <asp:RadioButton ID="rdoeditAccsessorytypeUnReg" runat="server" Text="UnReg Acc." CssClass="fab-reg" GroupName="rdofabrictypeedit" TextAlign="Left" />
                             </div>
                </EditItemTemplate>
                <FooterTemplate>
                <div style="border-bottom:1px solid #d0cdcd; width:100%; height:12px">
                    <a style="cursor: pointer; color:Blue;" onclick='<%# "UploadFile(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                        id="BrowseFile<%# Container.DataItemIndex + 1 %>" title="CLICK TO UPLOAD FILE">Browse
                    </a>
                    <input id="hdnFldFilePathF" type="hidden" runat="server" class="hdnFldFilePath" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />
                    </div>
                    <div>
                    <asp:RadioButton ID="rdoAccsessorytypeReg" runat="server" Checked="true" Text="Reg Acc." CssClass="fab-reg" GroupName="rdofabrictype" TextAlign="Left" />
                       
                             <asp:RadioButton ID="rdoAccsessorytypeUnReg" runat="server" Text="UnReg Acc." CssClass="fab-reg" GroupName="rdofabrictype" TextAlign="Left" />
                             </div>
                </FooterTemplate>
                <ItemTemplate>
                    <a style="cursor: pointer; color:Blue;" onclick='<%# "UploadFile(" + (Container.DataItemIndex + 1).ToString() + ")" %>'
                        id="ViewFile<%# Container.DataItemIndex + 1 %>" title="CLICK TO VIEW FILE">
                        <img src="../../images/view-icon.png" />
                    </a>
                    <input id="hdnFldFilePathI" type="hidden" runat="server" class="hdnFldFilePath" value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' />

                    <asp:Label ID="lblAccsessorytype" runat="server" Text='<%# Eval("AccTypeReg_UnReg") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

           <%-- <asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;'
                ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/cancel.jpg" title="Cancel" alt="Cancel" /&gt;'
                UpdateText='&lt;img src="../../images/update.gif" title="Update" alt="Update" /&gt;'
                CausesValidation="true">
                <ItemStyle HorizontalAlign="Center" Width="30" />
                <FooterStyle HorizontalAlign="Center" Width="30" />
            </asp:CommandField>--%>

            <asp:TemplateField HeaderText="Action" ItemStyle-Width="60" FooterStyle-Width="60">
                <ItemTemplate>
                    <asp:LinkButton ID="lkbEdit" runat="server" CausesValidation="False" CommandName="Edit">
                    <img src="../../images/edit2.png" alt="Edit Record" title="Edit Record" border="0"/></asp:LinkButton>
                    <asp:LinkButton ID="lkbDelete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Are you sure to delete the current record?');"><img src="../../images/delete-icon.png" alt="Delete Record" title="Delete Record" border="0"/></asp:LinkButton>            
                </ItemTemplate>

                <EditItemTemplate>
                 <asp:LinkButton ID="lkbUpdate" runat="server" CausesValidation="true"  CommandName="Update" CssClass="lkbUpdate">
                    <img src="../../images/update.gif" alt="Update Record" title="Update Record" border="0"/>
                  </asp:LinkButton>    
             
                    <asp:LinkButton ID="lkbcancel" runat="server" Text="Cancel" CausesValidation="False" CommandName="Cancel">
                    <%--<img src="../../images/cancel.jpg" alt="Cancel" title="Cancel" border="0"/>--%>
                    </asp:LinkButton>    
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:LinkButton ID="lkbInsert" runat="server" CausesValidation="true" CommandName="Insert"
                      ValidationGroup="FD"  CssClass="btnSubmitDetail">
                                        <img src="../../images/add-butt.png" alt="Add Items" title="Add more"
                                         border="0" />
                    </asp:LinkButton>
                </FooterTemplate>

                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

      

        </Columns>
    </asp:GridView>
<div style="height: 10px;">
</div>
<h2 style="width: 300px; float: left; margin: 0px;">
    Authorized Signatures <span style="font-size: 12px;">(Date) </span>
</h2>
<div style="float: left; padding-top: 4px; padding-right: 4px; padding-left: 4px;
    padding-bottom: 4px; border: 1px solid #aaa; width: 300px; font-size: 12px">
    <asp:TextBox runat="server" ID="txtApprovedOn" MaxLength="20" CssClass="th"></asp:TextBox>
</div>
<p>
    &nbsp;</p>

