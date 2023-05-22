<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPageWise.aspx.cs"
    Inherits="iKandi.Web.CustomerPageWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:20px;margin-top:10px">
        PageSize:
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
            <asp:ListItem Text="10" Value="10" />
            <asp:ListItem Text="25" Value="25" />
            <asp:ListItem Text="50" Value="50" />
        </asp:DropDownList>
        <hr />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="CustomerId" DataField="CustomerId" />
                <asp:BoundField HeaderText="ContactName" DataField="ContactName" />
                <asp:BoundField HeaderText="CompanyName" DataField="CompanyName" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Repeater ID="rptPager" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                    Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
