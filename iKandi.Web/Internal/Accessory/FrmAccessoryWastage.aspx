<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="FrmAccessoryWastage.aspx.cs" Inherits="iKandi.Web.Internal.Accessory.FrmAccessoryWastage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
 <style>
        .srvtable
        {
            width: 500px;
            margin: 0 auto;
        }
        .srvtable th
        {
            background: #39589c;
            font-weight: 500;
            font-family: Arial;
            color: #f4f4f4;
            font-size: 12px;
            padding: 5px 2px;
            text-align: center;
            border: 1px solid gray;
        }
        .srvtable td
        {
            font-family: Arial;
            font-size: 10px;
            padding: 5px 5px;
            border: 1px solid #9999;
            color: #000;
        }
        .srvtable td:first-child
        {
            border-left-color: #999 !important;
        }
        .srvtable td:last-child
        {
            border-right-color: #999 !important;
        }
        .srvtable tr:last-child > td
        {
            border-bottom-color: #999 !important;
        }
        .srvtable1 td:first-child
        {
            border-left-color: #999 !important;
        }
        .srvtable1 td:last-child
        {
            border-right-color: #999 !important;
        }
        .srvtable1 tr:last-child > td
        {
            border-bottom-color: #999 !important;
        }
        .srvtable1
        {
            width: 500px;
            margin: 0 auto;
            font-size: 10px;
        }
        .border_bottom_color
        {
           border-bottom-color: #999 !important;  
         }
        a
        {
            text-decoration: none;
        }
        .txtcenter
        {
            text-align: center;
        }
        .txtRight
        {
            text-align: right;
        }
        input[type="text"]
        {
            height: 11px;
            margin: 1px 0px;
        }
         .headerAccessories
        {
            background: #39589c;
            text-align: center;
            color: White;
            width: 100%;
             margin: 0 auto 3px;
        }
    </style>
    <script>
        function ExportPdf() {
            debugger;
            kendo.drawing
    .drawDOM("#ctl00_cph_main_content_UpdatePanel2",
    {
        paperSize: "A4",
        margin: { top: "1cm", bottom: "1cm" },
        scale: 0.8,
        height: 500
    })
        .then(function (group) {
            kendo.drawing.pdf.saveAs(group, "Exported.pdf")
        });
        }
    </script>
    <script src="https://kendo.cdn.telerik.com/2017.2.621/js/jquery.min.js"></script>
    <script src="https://kendo.cdn.telerik.com/2017.2.621/js/jszip.min.js"></script>
    <script src="https://kendo.cdn.telerik.com/2017.2.621/js/kendo.all.min.js"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>--%>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <%-- <script src="http://code.jquery.com/jquery-1.9.1.js"></script>--%>
    <%--<script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>--%>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script type="text/javascript">

        $(document).ready(function (e) {
//            $(".numarics").keypress(function (e) {

//                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
//                    return false;
//                }
            //            });
            $('.numarics').keypress(function (event) {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
                    ((event.which < 48 || event.which > 57) &&
                      (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 2) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });
        });
        function pageLoad() {
//            $(".numarics").keypress(function (e) {

//                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
//                    return false;
//                }
            //            });
            $('.numarics').keypress(function (event) {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
                    ((event.which < 48 || event.which > 57) &&
                      (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 2) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });
            // Add Code By Bharat On 23-12-19
            var maxRow = 0;
            var rowSpan = 0;
            $('table td[rowspan].RowCountLastCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRow) {
                    maxRow = row;
                    rowSpan = 0;
                }
                if ($(this).attr('rowspan') > rowSpan) rowSpan = $(this).attr('rowspan');
            });
            if (maxRow == $('table tr:last td').parent().parent().children().index($('table tr:last td').parent()) - (rowSpan - 1)) {
                $('table td[rowspan].RowCountLastCol').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRow && $(this).attr('rowspan') == rowSpan) $(this).addClass('border_bottom_color');
                });
            }

            var maxRow1 = 0;
            var rowSpan1 = 0;
            $('table td[rowspan].RowCountLast').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRow1) {
                    maxRow1 = row;
                    rowSpan1 = 0;
                }
                if ($(this).attr('rowspan') > rowSpan1) rowSpan1 = $(this).attr('rowspan');
            });
            if (maxRow1 == $('table tr:last td').parent().parent().children().index($('table tr:last td').parent()) - (rowSpan1 - 1)) {
                $('table td[rowspan].RowCountLast').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRow1 && $(this).attr('rowspan') == rowSpan1) $(this).addClass('border_bottom_color');
                });
            }
        }

    </script>
    <asp:ScriptManager ID="scriptajax" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Up1" runat="Server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading128.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">

        <ContentTemplate>
        <div style="width:500px;margin:0 auto">
            <div style="width:100%;clear:both">
              <h2 class="headerAccessories">Debit barrier for Accessory</h2>
            </div>
            <asp:GridView ID="grdAccessory" runat="server" OnDataBound="grdAccessory_DataBound" CellPadding="0"
                ShowHeader="true" CssClass="srvtable" OnRowDataBound="grdAccessory_RowDatabound"
                OnRowCommand="grdAccessory_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Accessory Quality
                        </HeaderTemplate>
                        <HeaderStyle CssClass="StyleContextupH" />
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblaccessoryquality" Text='<%# Eval("TradeName") %>' runat="server"></asp:Label></div>
                        </ItemTemplate>
                        <ItemStyle Width="225" CssClass="RowCountLast" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Quantity
                        </HeaderTemplate>
                        <HeaderStyle CssClass="StyleContextupH" />
                        <ItemTemplate>
                            <div style="color:#4c4b4b">
                                <span style="display: inline-block; width: 100px;">From:
                                    <asp:Label ID="lblfromqtyrange" ForeColor="black" Font-Bold="true" Text='<%# (Eval("From_Qty") == DBNull.Value  || (Eval("From_Qty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("From_Qty")).ToString("N0") %>'
                                        runat="server"></asp:Label>
                                </span>To:
                                <asp:Label ID="lbltoqtyrange" ForeColor="black" Font-Bold="true" Text='<%# (Eval("To_Qty") == DBNull.Value  || (Eval("To_Qty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("To_Qty")).ToString("N0") %>'
                                    runat="server"></asp:Label>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="200" CssClass="" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Greige
                        </HeaderTemplate>
                        <HeaderStyle CssClass="StyleContextupH" />
                        <ItemTemplate>
                            <asp:Label ID="lblSolid" Text='<%# (Eval("Solid_Barrier") == DBNull.Value || (Eval("Solid_Barrier").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Solid_Barrier")).ToString("N0")%>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="30px" CssClass="txtRight" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Process
                        </HeaderTemplate>
                        <HeaderStyle CssClass="StyleContextupH" />
                        <ItemTemplate>
                            <asp:Label ID="lblPrinted" Text='<%# (Eval("Print_Barrier") == DBNull.Value || (Eval("Print_Barrier").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Print_Barrier")).ToString("N0")%>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  Width="30px" CssClass="txtRight" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            select
                        </HeaderTemplate>
                        <HeaderStyle CssClass="StyleContextupH" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnaccessoryqualityid" runat="server" Value='<%# Eval("accessory_qualityID") %>' />
                            <asp:HiddenField ID="hdnAccessoryBarrierWastage" runat="server" Value='<%# Eval("Accesories_Barrier_WastageID") %>' />
                            <asp:LinkButton ID="btnselect" runat="server" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="40px" CssClass="txtcenter RowCountLastCol" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table class="srvtable1" runat="server" id="tbladdnew" cellspacing="0" cellpadding="0"
                rules="all" border="1" style="border-collapse: collapse;border-top:0px;border-top-color:Gray">
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="grdedit" OnRowDeleting="grdedit_RowDeleting" OnDataBound="grdedit_DataBound"
                            runat="server" CellPadding="0" BorderWidth="0" ShowHeader="true" CssClass="srvtable"
                            OnRowDataBound="grdedit_RowDatabound" AutoGenerateColumns="false" 
                            OnRowCommand="grdedit_RowCommand" onrowcancelingedit="grdedit_RowCancelingEdit" 
                            onrowediting="grdedit_RowEditing" onrowupdating="grdedit_RowUpdating">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Accessory Quality
                                    </HeaderTemplate>
                                    <HeaderStyle CssClass="StyleContextupH" />
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="lblaccessoryquality" Text='<%# Eval("TradeName") %>' runat="server"></asp:Label></div>
                                    </ItemTemplate>
                                    <ItemStyle Width="225" CssClass="RowCountLast" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Quantity
                                    </HeaderTemplate>
                                    <HeaderStyle CssClass="StyleContextupH" />
                                    <ItemTemplate>
                                        <div style="width: 100%;color:#4c4b4b">
                                            <asp:HiddenField ID="hdnaccessoryqualityid" runat="server" Value='<%# Eval("accessory_qualityID") %>' />
                                            <asp:HiddenField ID="hdnAccessoryBarrierWastage" runat="server" Value='<%# Eval("Accesories_Barrier_WastageID") %>' />
                                            <span style="display: inline-block; width: 100px;">From:
                                                <asp:Label ID="lblfromqtyrange" ForeColor="black" Font-Bold="true" Text='<%# (Eval("From_Qty") == DBNull.Value  || (Eval("From_Qty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("From_Qty")).ToString("N0") %>'
                                                    runat="server"></asp:Label>
                                            </span>To:
                                            <asp:Label ID="lbltoqtyrange" ForeColor="Black" Font-Bold="true" Text='<%# (Eval("To_Qty") == DBNull.Value  || (Eval("To_Qty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("To_Qty")).ToString("N0") %>'
                                                runat="server"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Width="200" />

                                    <EditItemTemplate>
                                        <asp:HiddenField ID="hdnaccessoryqualityid" runat="server" Value='<%# Eval("accessory_qualityID") %>' />
                                        <asp:HiddenField ID="hdnAccessoryBarrierWastage" runat="server" Value='<%# Eval("Accesories_Barrier_WastageID") %>' />
                                        <div style="width: 100%;color:#4c4b4b">
                                        <span style="display: inline-block; width: 100px;">From:
                                            <asp:TextBox ID="txtfromqtyrange" runat="server" MaxLength="6" CssClass="numarics" Width="58%" Text='<%# (Eval("From_Qty") == DBNull.Value  || (Eval("From_Qty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("From_Qty")).ToString() %>'></asp:TextBox>
                                            </span>To:
                                            <asp:TextBox ID="txttoqtyrange" runat="server" MaxLength="6" Width="27%" CssClass="numarics" Text='<%# (Eval("To_Qty") == DBNull.Value  || (Eval("To_Qty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("To_Qty")).ToString() %>'></asp:TextBox>
                                        </div>
                                    </EditItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Greige
                                    </HeaderTemplate>
                                    <HeaderStyle CssClass="StyleContextupH" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSolid" Text='<%# (Eval("Solid_Barrier") == DBNull.Value || (Eval("Solid_Barrier").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Solid_Barrier")).ToString("N0")%>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSolid" MaxLength="4" CssClass="numarics" runat="server"  Text='<%# (Eval("Solid_Barrier") == DBNull.Value || (Eval("Solid_Barrier").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Solid_Barrier")).ToString("N0")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle  Width="30px" CssClass="txtRight" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Process
                                    </HeaderTemplate>
                                    <HeaderStyle CssClass="StyleContextupH" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrinted" Text='<%# (Eval("Print_Barrier") == DBNull.Value || (Eval("Print_Barrier").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Print_Barrier")).ToString("N0")%>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle  Width="30px" CssClass="txtRight" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPrinted" MaxLength="4" CssClass="numarics" Text='<%# (Eval("Print_Barrier") == DBNull.Value || (Eval("Print_Barrier").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("Print_Barrier")).ToString("N0")%>'
                                            runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Action
                                    </HeaderTemplate>
                                    <HeaderStyle CssClass="StyleContextupH" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btndelete" OnClientClick="return confirm('Are you sure to delete the current record?');"
                                            runat="server" CommandName="delete" Text=""><img src="../../images/del-butt.png" /></asp:LinkButton>
                                        <asp:LinkButton ID="btnEdit" 
                                            runat="server" CommandName="edit" Text=""><img src="../../images/edit2.png" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>                                          
                                        <asp:LinkButton ID="btn_Update" runat="server" CommandName="Update" Text=""><img src="../../images/Save.png" style="width:15px;" /></asp:LinkButton> 
                                        <asp:LinkButton ID="btn_Cancel" runat="server" CommandName="Cancel" Text=""><img src="../../images/Cancel1.png" style="width:19px;" /></asp:LinkButton> 
                                    </EditItemTemplate> 
                                    <ItemStyle Width="42px" CssClass="txtcenter RowCountLastCol" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 213px;border-color: #9999;">
                        
                    </td>
                    <td style="width: 211px;border-color: #9999;color:#4c4b4b">
                        <span style="margin-left: 5px; display: inline-block; width: 100px;">From
                            <asp:TextBox ID="txtfrom" MaxLength="6" CssClass="numarics" Width="58%" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtfrom" ValidationGroup="inserts" runat="server"
                                Display="None" ControlToValidate="txtfrom" ErrorMessage="Enter from value." ForeColor="Red"></asp:RequiredFieldValidator>
                        </span>To
                        <asp:TextBox ID="txtto" MaxLength="6" Width="27%" CssClass="numarics" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtto" ValidationGroup="inserts" runat="server"
                            Display="None" ControlToValidate="txtto" ErrorMessage="Enter to value." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 49px; text-align: center;border-color: #9999;">
                        <div>
                            <asp:TextBox ID="txtsolidval" MaxLength="4" CssClass="numarics" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtsolidval" ValidationGroup="inserts" runat="server"
                                Display="None" ControlToValidate="txtsolidval" ErrorMessage="Enter soild value."
                                ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 56px; text-align: center;border-color: #9999;">
                        <asp:TextBox ID="txtprintqty" MaxLength="4" CssClass="numarics" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtprintqty" ValidationGroup="inserts" runat="server"
                            Display="None" ControlToValidate="txtprintqty" ErrorMessage="Enter print value."
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 56px; text-align: center;border-color: #9999;">
                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="../../images/add-butt.png"
                            ValidationGroup="inserts" Width="14px" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
            <div style="width: 500px; margin: 0 auto; text-align: right">
                <asp:LinkButton ID="btngotolist" runat="server" Text="View list" OnClick="btngotolist_Click"></asp:LinkButton>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="inserts" />
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
