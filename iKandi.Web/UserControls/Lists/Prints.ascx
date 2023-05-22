<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Prints.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.Prints" %>
<%@ Register Assembly="iKandi.Web" Namespace="iKandi.Components.UI" TagPrefix="cc1" %>
<script type="text/javascript">
    $(function () {
        BindControls();
    });


</script>
<script type="text/javascript">
    function BindDepartmentDDl() {
        var ddlClients = '#<%= ddlClients.ClientID %>';
        var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
        $('#<%= ddlPrintDepartment.ClientID %>').empty();
        $('#<%= hdnClientId.ClientID %>').val(Clientddlselectedvalue);
        proxy.invoke("GetAllPrintDeptlist", { ClientId: Clientddlselectedvalue }, function (result) {
            $.each(result, function (key, value) {
                $('#<%= ddlPrintDepartment.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                $('#<%= hdnDDLDepartment.ClientID %>').val(-1);
            });

        });

    }
    function BindDepartmentValue() {
        var ClientddlDeptSelectedValue = $('#<%= ddlPrintDepartment.ClientID %> option:selected').val();
        $('#<%= hdnDDLDepartment.ClientID %>').val(ClientddlDeptSelectedValue);
    }
 
</script>
<style>
    .item_list TD a.thickbox img
    {
        border: 0px;
        width: 90%;
    }
    input[type="text"].inpuwidthSer
    {
        width: 10%;
    }
    @media screen and (max-width: 1366px)
    {
        input[type="text"].inpuwidthSer
        {
            margin-bottom: 5px;
            width: 36%;
        }
    }
</style>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress runat="server" ID="updatePrint" AssociatedUpdatePanelID="UpdatePanal1"
    DisplayAfter="0">
    <ProgressTemplate>
        <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
            z-index: 52111; top: 40%; left: 45%; width: 6%;" />
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanal1" runat="server">
    <ContentTemplate>
        <div class="print-box">
            <div class="form_heading">
                Prints
            </div>
            <br />
            <div>
                Buying House:
                <asp:DropDownList runat="server" ID="ddlBuyingHouse" Width="9%" CssClass="do-not-disable"
                    OnSelectedIndexChanged="ddlBuyingHouse_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="-1" Text="ALL"></asp:ListItem>
                </asp:DropDownList>
                Client:
                <asp:DropDownList runat="server" ID="ddlClients" Width="9%" CssClass="do-not-disable"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlClients_SelectedIndexChanged">
                    <asp:ListItem Value="-1" Text="ALL"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField runat="server" ID="hdnClientId" Value="-1" />
                Search:
                <asp:TextBox runat="server" ID="txtSearch" CssClass="do-not-disable inpuwidthSer"></asp:TextBox>
                Print Type:
                <asp:DropDownList ID="ddlPrintType" runat="server" Width="10%">
                    <asp:ListItem Text="ALL" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                Print Category:
                <asp:DropDownList ID="ddlPrintCategory" runat="server" Width="70px">
                    <asp:ListItem Text="ALL" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                </asp:DropDownList>
                Parent Department
                <asp:DropDownList runat="server" ID="ddlDepts" CssClass="do-not-disable" Style="width: 8%;"
                    OnSelectedIndexChanged="ddlDepts_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                Sub Department:
                <asp:DropDownList ID="ddlPrintDepartment" runat="server" Width="8%" onchange="javascript:BindDepartmentValue('');">
                    <asp:ListItem Text="ALL" Value="-1"></asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField runat="server" ID="hdnDDLDepartment" Value="-1" />
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                    CssClass="go" />
            </div>
            <br />
            <asp:GridView ID="grdPrint" runat="server" AutoGenerateColumns="False" CssClass="item_list fixed-header"
                EmptyDataRowStyle-HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound"
                AllowPaging="True" OnPageIndexChanging="grdPrint_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="PrintID" HeaderText="PrintID" SortExpression="PrintID"
                        Visible="false" />
                    <asp:TemplateField HeaderText="Date" SortExpression="DatePurchased" ItemStyle-CssClass=" date_style">
                        <ItemTemplate>
                            <%# (Convert.ToDateTime(Eval("DatePurchased")) == DateTime.MinValue) ? "" : Eval("DatePurchased", "{0:dd MMM yy (ddd)}")%>
                        </ItemTemplate>
                        <ItemStyle CssClass=" date_style" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Print Number" SortExpression="PrintNumber">
                        <ItemTemplate>
                            PRD
                            <%# Eval("PrintNumber")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PrintRefNo" HeaderText="Print Description" SortExpression="PrintRefNo" />
                    <asp:BoundField DataField="PrintType" HeaderText="Print Type" SortExpression="PrintType" />
                    <asp:BoundField DataField="PrintCategoryName" HeaderText="Print Category" SortExpression="PrintCategoryName" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="DesignerName" HeaderText="Designer" SortExpression="DesignerName" />
                    <asp:BoundField DataField="ClientName" HeaderText="Buyer" SortExpression="ClientName" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" SortExpression="deptname" />
                    <asp:BoundField DataField="PrintCompany" HeaderText="Print Company" SortExpression="PrintCompany" />
                    <asp:TemplateField HeaderText="Fabric Quality" SortExpression="PrintCompanyReference">
                        <ItemTemplate>
                            <%# Eval("FabricQuality")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Print Cost" SortExpression="PrintCost" ItemStyle-CssClass="numeric_text">
                        <ItemTemplate>
                            <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text='<%# (Convert.ToDouble(Eval("PrintCost"))).ToString("N2") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="numeric_text" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Original Image" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a title="CLICK TO VIEW ENLARGED IMAGE" href='<%# ResolveUrl("~/uploads/print/" + Eval("ImageUrl").ToString()) %>'
                                class="thickbox <%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? "hide_me": "" %>">
                                <img height="75px" border="0" src='<%# ResolveUrl("~/uploads/print/thumb-" + Eval("ImageUrl").ToString()) %>'
                                    visible='<%# (Eval("ImageUrl") == null || string.IsNullOrEmpty(Eval("ImageUrl").ToString()) ) ? false: true %>' />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="85px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Developed Image" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a title="CLICK TO VIEW ENLARGED IMAGE" href='<%# ResolveUrl("~/uploads/print/" + Eval("DevelopedImageUrl").ToString()) %>'
                                class="thickbox <%# (Eval("DevelopedImageUrl") == null || string.IsNullOrEmpty(Eval("DevelopedImageUrl").ToString()) ) ? "hide_me": "" %>">
                                <img height="75px" border="0" src='<%# ResolveUrl("~/uploads/print/thumb-" + Eval("DevelopedImageUrl").ToString()) %>'
                                    visible='<%# (Eval("DevelopedImageUrl") == null || string.IsNullOrEmpty(Eval("DevelopedImageUrl").ToString()) ) ? false: true %>' />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="85px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblstatus" runat="server" Text='<%#  Eval("Status")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="PrintID" DataNavigateUrlFormatString="~/internal/design/PrintEdit.aspx?printid={0}"
                        Text="Edit" />
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <asp:Label ID="lbl_RecordNotFound" Text="No records found." runat="server" Font-Size="Larger"
                        ForeColor="#E91677"></asp:Label>
                </EmptyDataTemplate>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
            </asp:GridView>
            <br />
            <div>
                <asp:Button ID="Button1" runat="server" Text="Add" CssClass="add da_submit_button"
                    PostBackUrl="~/internal/Design/PrintEdit.aspx"></asp:Button>
            </div>
    </ContentTemplate>
</asp:UpdatePanel>
