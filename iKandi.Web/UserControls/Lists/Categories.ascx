<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs"
    Inherits="iKandi.Web.Categories" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
<style type="text/css">
    .paging
    {
        text-transform: capitalize;
        border: 0px solid #dedede;
        padding: 3px;
        font: bold 12px/14px Helvetica,Arial,Verdana,sans-serif;
        color: #bdc3cf;
        text-align: center;
    }
    
    .TextColor
    {
        color: #0088cc;
        text-transform: none;
        font: 12px/14px Arial, Helvetica, sans-serif;
        border: 1px solid #b7b4b4;
    }
    .ColorAndAlign
    {
        text-align: left;
        font: bold 12px/14px Arial, Helvetica, sans-serif;
        background: #dddfe4;
        text-transform: none;
        color: #575759;
        width: 194px;
        border: 1px solid #b7b4b4;
    }
    .ColorAndAlign th
    {
        padding: 8px 0px;
        border: 1px solid #b7b4b4;
    }
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style1
    {
        background: #f7f7f7;
        border: solid 1px #d7d7d7;
        padding: 5px;
        height: 29px;
    }
    
    .TextColor
    {
        color: #000;
        text-transform: none;
        padding: 0px 5px;
        font: 12px/14px Arial, Helvetica, sans-serif;
    }
    
    .ColorAndAlign th
    {
        font-weight: normal;
        text-align: center;
    }
    .item_list th
    {
        height: auto;
    }
    .item_list td
    {
        padding: 5px 3px !important;
    }
</style>
<script type="text/javascript">


    $(function () {

        //        $("input[type=text].categorynameCss", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestCategories", { dataType: "xml", datakey: "string", max: 100 });

        //        var tbCategoryNameId = '<%=tbCategoryName.ClientID %>';
        //        var tbCategoryCodeId = '<%=tbCategoryCode.ClientID %>';

        //        $("#" + tbCategoryNameId).blur(function () {
        //            var categoryCode = $(this).val().slice(0, 1);

        //          

        //            

        //        });

    });





    function CatInValid() {
        //alert("keypress");
        $("#" + '<%=hfCatValid.ClientID%>').val("0");
        $("#" + '<%=btnSubmit.ClientID%>').attr("disabled", true);
    }

    function CheckCatValid() {
        if ($("#" + '<%=hfCatValid.ClientID%>').val() == "0") {
            alert("Category is not valid");
            return false;
        }
        return true;

    }

   

</script>
<div class="print-box">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel runat="server" ID="pnlForm">
        <table width="900px" border="0" cellspacing="0" cellpadding="0" style="margin:0 auto;">
            <tr>
                <%-- <td width="10" class="da_table_heading_bg_left">&nbsp;</td>--%>
                <td width="1205" class="header-text-back" style="border-radius:0px 0px;font-size:15px;padding:1px 0px;">
                    Manage Categories
                </td>
                <%--<td width="13" class="da_table_heading_bg_right">&nbsp;</td>--%>
            </tr>
            <tr>
                <%-- <td width="10" class="da_table_heading_bg_left">&nbsp;</td>--%>
                <td width="1205" style="border-radius:0px 0px;font-size:15px;padding:1px 0px;">

                </td>
                <%--<td width="13" class="da_table_heading_bg_right">&nbsp;</td>--%>
            </tr>
        </table>
    
        <table border="0" cellspacing="0" cellpadding="0" style="margin:0 auto; width: 900px;"
            class="item_list">
            <tr class="td-sub_headings">
                <th width="15%" valign="bottom">
                    Type
                </th>
                <th width="25%" valign="bottom">
                    Group name
                </th>
                <th width="27%" valign="bottom">
                    Sub group name
                </th>
                <th width="30%" valign="bottom">
                    &nbsp;
                </th>
            </tr>
            <tr>
                <td class="inner_tbl_td">
                    <asp:DropDownList ID="ddlTypes" runat="server" CssClass="do-not-disable TextColor"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlTypes_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="inner_tbl_td">
                    <asp:DropDownList ID="ddlParentCategories" runat="server" CssClass="do-not-disable input_in"
                        ForeColor="Highlight">
                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="inner_tbl_td">
                    <asp:TextBox ID="tbCategoryNames" runat="server" style="width:90% !important;" CssClass="do-not-disable TextColor">
                    </asp:TextBox>
                </td>
                <td class="inner_tbl_td">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="da_go_button go" OnClick="btnSearch_Click" />
                    &nbsp;
                    <asp:Button ID="btnadd" runat="server" Text="Add" class="da_go_button" OnClick="btnadd_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="addpnl" runat="server">
            <table width="900px" border="0" cellspacing="0" cellpadding="0" style="margin: 0 auto;">
                <tr>
                    <%--<td width="10" class="ColorAndAlign">&nbsp;</td>--%>
                    <td class="ColorAndAlign" style="padding: 5px">
                        <span><b>&nbsp;New Category</b><b style="font-size: 10px">(<span class="da_astrx_mand">*</span>
                            Please fill all required fields)</b></span>
                    </td>
                    <%-- <td width="13" class="ColorAndAlign">&nbsp;</td>--%>
                </tr>
            </table>
            <asp:HiddenField Value="1" runat="server" ID="hfCatValid" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Panel ID="pnlmain" runat="server">
                        <table width="900px" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px auto;">
                            <tr class="td-sub_headings">
                                <td width="17%" valign="bottom">
                                    Group Name <span class="da_astrx_mand">*</span>
                                </td>
                                <td width="7%" valign="bottom">
                                    Group Code<span class="da_astrx_mand">*</span>
                                </td>
                                <td width="8%" valign="bottom">
                                    Group name Type
                                </td>
                                <td width="7%" valign="bottom" id="tdwastageMeg" visible="false" runat="server">
                                    Wastage<span class="da_astrx_mand">*</span>
                                </td>
                                <td width="18%" valign="bottom">
                                    Parent group name
                                </td>
                                <td width="6%" valign="bottom">
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:TextBox ID="tbCategoryName" AutoPostBack="True" CssClass="categorynameCss" runat="server"
                                        MaxLength="50" onpaste="return false;" Width="90%" OnTextChanged="tbCategoryName_TextChanged"></asp:TextBox>
                                </td>
                                <td class="style1">
                                    <asp:TextBox ID="tbCategoryCode" CssClass="TextColor" runat="server" MaxLength="3"></asp:TextBox>
                                </td>
                                <td class="style1">
                                    <asp:DropDownList ID="ddlCategoryType" CssClass="TextColor" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCategoryType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="style1" id="tdwastagetextbox" visible="false" runat="server">
                                    <asp:TextBox ID="txtwastage" MaxLength="2" runat="server" onkeypress='return event.charCode >= 48 && event.charCode <= 57'
                                        CssClass="input_in"></asp:TextBox>
                                </td>
                                <td class="style1">
                                    <asp:DropDownList ID="ddlParentCategory" CssClass="input_in TextColor" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td class="style1">
                                    <%--<asp:DropDownList ID="ddlweeks" runat="server" CssClass="TextColor">
                                                    </asp:DropDownList>--%>
                                    <%--<asp:TextBox ID="txtWeeks" runat="server" CssClass="input_in"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <%--<Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbCategoryName" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlCategoryType" EventName="SelectedIndexChanged" />

                                    </Triggers>--%>
            </asp:UpdatePanel>
            <div class="form_buttom" style="margin:0 auto; width:900px">
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="da_submit_button submit"
                    OnClick="Submit_Click" OnClientClick="JavaScript:return CheckCatValid();" />
                <input type="button" id="Button1" value="Print" class="da_submit_button" onclick="return PrintPDF();" />
            </div>
        </asp:Panel>
        <%--<div class="grid_heading">
        Categories
    </div>--%>
        <br />
        <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" Width="900px"
            HeaderStyle-CssClass="ColorAndAlign" DataSourceID="ObjectDataSource1" AllowPaging="true"
            PageSize="10" DataKeyNames="CategoryID" OnPageIndexChanged="gvCategories_PageIndexChanged"
            BackColor="White" style="margin: 0 auto;">
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
            <Columns>
                <asp:BoundField DataField="CategoryName" HeaderText="Group Name" ItemStyle-CssClass="TextColor"
                    SortExpression="CategoryName" />
                <asp:BoundField DataField="CategoryCode" ItemStyle-CssClass="TextColor" HeaderText="Group Code"
                    SortExpression="CategoryCode" />
                <asp:TemplateField HeaderText="Type" ItemStyle-CssClass="TextColor">
                    <ItemTemplate>
                        <p>
                            <%#(iKandi.Common.CategoryType)DataBinder.Eval(Container.DataItem, "Type")%>
                        </p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Parent group name" ItemStyle-CssClass="TextColor">
                    <ItemTemplate>
                        <p>
                            <%#DataBinder.Eval(Container.DataItem, "Parent.CategoryName")%></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Wastage" ItemStyle-CssClass="TextColor">
                    <ItemTemplate>
                        <p>
                            <%#DataBinder.Eval(Container.DataItem, "wastage_")%>
                        </p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" ItemStyle-VerticalAlign="Top" NavigateUrl='<%# Eval("categoryid", "~/Admin/categories/CategoryListing.aspx?categoryid={0}") %>'
                            Text="" ItemStyle-CssClass="da_edit_delete_link" ImageUrl="../../images/edit2.png">
            
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No Record Found
            </EmptyDataTemplate>
        </asp:GridView>
        <div style="margin-top: 5px; text-align: right;">
            <cc1:HyperLinkPager ID="HyperLinkPager1" runat="server" PageSize="10">
            </cc1:HyperLinkPager>
        </div>
        <div>
            <asp:Button ID="btnPrint" Visible="false" Text="Print" CssClass="da_submit_button"
                runat="server" />
        </div>
    </asp:Panel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCategories"
        TypeName="iKandi.BLL.AdminController" StartRowIndexParameterName="startIndex"
        EnablePaging="true" MaximumRowsParameterName="pageSize" SelectCountMethod="GetAllCategoriesCount">
        <SelectParameters>
            <asp:Parameter Name="startIndex" Type="Int32" />
            <asp:Parameter Name="pageSize" Type="Int32" />
            <asp:SessionParameter Name="searchCriteria" SessionField="CategorySearchCriteria"
                Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Panel runat="server" ID="pnlError" Visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10" class="da_table_heading_bg_left">
                    &nbsp;
                </td>
                <td width="1205" class="da_table_heading_bg">
                    <span class="da_h1">Confirmation</span>
                </td>
                <td width="13" class="da_table_heading_bg_right">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div class="form_box">
            <div class="text-content">
                Category has not been saved due to dublicate code or some error occurs into system
                while saving data!
                <br />
                <a id="A2" href="~/Admin/Categories/CategoryListing.aspx" runat="server">Click here</a>
                to Category List.</div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlMessage" Visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <%-- <td width="10" class="da_table_heading_bg_left">&nbsp;</td>--%>
                <td width="1205" class="ColorAndAlign">
                    <span class="da_h1">&nbsp; Confirmation</span>
                </td>
                <%--<td width="13" class="da_table_heading_bg_right">&nbsp;</td>--%>
            </tr>
        </table>
        <div class="form_box">
            <div class="text-content">
                Category have been saved into the system successfully!
                <br />
                <a id="A1" href="~/Admin/Categories/CategoryListing.aspx" runat="server">Click here</a>
                to Category List.</div>
        </div>
    </asp:Panel>
</div>
