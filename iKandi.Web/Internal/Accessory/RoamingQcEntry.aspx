<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoamingQcEntry.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.RoamingQcEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style>
        .btnbutton
        {
            margin: 2px 2px;
        }
        .toptable th
        {
            min-width: 70px;
        }
        .toptable.AddClass_Table td
        {
            border: 1px solid #999;
            text-align: center;
           
        }
        .AddClass_Table td
        {
            text-align: center;
        }
        SELECT
        {
            width: 100%;
            margin:2px 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 39%; margin: 10px auto;">
        <table border="0" class="AddClass_Table toptable" style="margin-bottom:10px;">
            <tr>
                <th style='width:150px;'>
                    QC Name
                </th>
               
                <th style='width:80px;'>
                    Unit
                </th>
               
                <th style='width:80px;'>
                    Line Number
                </th>
               
                <th style='width:80px;'>
                    Cluster
                </th>
                <th style='width:60px;'>
                    Action
                </th>
               
            </tr>
            <tr>
             <td>
                    <asp:DropDownList ID="ddlQcName" runat="server">
                    </asp:DropDownList>
                </td>
                 <td>
                    <asp:DropDownList ID="ddlUnitName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectedUnitName">
                    </asp:DropDownList>
                </td>
                 <td>
                    <asp:DropDownList ID="ddlLineNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SlectedLineNo">
                        <asp:ListItem Value='-1'>Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 <td>
                    <asp:DropDownList ID="ddlCluster" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectedCluster">
                        <asp:ListItem Value='-1'>Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 <td>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnbutton" Text="Add" OnClick="btn_Submitval" />
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="grdroamingQcEntry" CssClass="AddClass_Table" Width="89%" runat="server"
                AutoGenerateColumns="false" 
                OnRowDataBound="grdroamingQcEntry_RowDataBound" 
                OnRowCancelingEdit="grdroamingQcEntry_RowCancelingEdit">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Bind("Id") %>' />
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QCName">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnQCId" runat="server" Value='<%# Bind("QCId") %>' />
                            <asp:DropDownList ID="ddlgrdQCName" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <EditItemTemplate>
                           <asp:DropDownList ID="ddlEditQcName" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnUnit" runat="server" Value='<%# Bind("UNITID") %>' />
                            <asp:DropDownList ID="ddlgrdUnit" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                          <EditItemTemplate>
                           <asp:DropDownList ID="ddlEditUnit" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Line No.">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnLineNo" runat="server" Value='<%# Bind("LineNo") %>' />
                            <asp:DropDownList ID="ddlgrdLineNo" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                          <EditItemTemplate>
                           <asp:DropDownList ID="ddlEditLineNo" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cluster">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnCluster" runat="server" Value='<%# Bind("ClusterNo") %>' />
                            <asp:DropDownList ID="ddlgrdCluster" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                          <EditItemTemplate>
                           <asp:DropDownList ID="ddlEditCluster" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        
                          <ItemTemplate>
                                <asp:ImageButton ID="btn_Edit" ImageUrl="../../images/edit2.png" Style="position: relative;
                                    top: 2px" ToolTip="Edit" CommandName="Edit" runat="server" />
                                <asp:ImageButton ID="btn_Delete" ImageUrl="~/images/delete-icon.png" ToolTip="Delete"
                                    Style="width: 18px; position: relative; top: 2px" CommandName="Delete" runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btn_Update" ImageUrl="~/images/Save.png" ToolTip="Update" Style="width: 18px;"
                                    CommandName="Update" runat="server" />
                                <asp:ImageButton ID="btn_Cancel" ImageUrl="~/images/Cancel1.jpg" ToolTip="Cancel"
                                    Style="width: 25px;" CommandName="Cancel" runat="server" />
                            </EditItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
