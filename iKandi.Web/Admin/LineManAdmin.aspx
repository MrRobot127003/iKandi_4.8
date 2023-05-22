<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineManAdmin.aspx.cs" Inherits="iKandi.Web.Admin.LineManAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <style type="text/css">
        .AddClass_Table
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
        }
        .AddClass_Table th
        {
            background: #e4e2e2;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }
        .AddClass_Table td
        {
            border: 1px solid #dbd8d8;
            font-size: 11px;
            padding: 0px 3px;
            color: #0c0c0c;
            height: 12px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }
        .AddClass_Table td:first-child
        {
            border-left-color: #999 !important;
        }
        .AddClass_Table td:last-child
        {
            border-right-color: #999 !important;
        }
        .AddClass_Table tr:last-child > td
        {
            border-bottom-color: #999 !important;
        }
        .AddClass_Table td input[type="text"]
        {
            width: 90%;
            height: 12px;
            font-size: 11px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
            padding-left: 2px;
            margin: 2px 0px;
            text-transform: capitalize;
            text-align: center;
        }
        .AddClass_Table td textarea
        {
            font-size: 11px;
            font-family: Arial, Helvetica, sans-serif;
            margin: 1px 0px;
            width: 95%;
            text-transform: capitalize;
        }
      
        .facolor
        {
            font-size: 14px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 500px; margin: 0 auto;">
            <h4 style="background: #3a5795; padding: 2px 0px;font-size:14px; color: #fff; text-align: center; margin-bottom: 0;">
                    LineMan Admin
                </h4>
                <div style="max-width: 100%;">
                    <span> 
                       <asp:TextBox ID="txtSearch" runat="server" autocomplete="off" Width="158px"></asp:TextBox>
                       &nbsp;
                       <asp:DropDownList ID="ddlLineManTypeSearch" runat="server">                               
                            </asp:DropDownList>&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" BackColor="Green" 
                        onclick="btnSearch_Click" />
                      </span>
                </div>
                <table class="AddClass_Table" cellspacing="0" cellpadding="0" border="0" style="width: 100%;
                    margin-bottom: 5px;">
                    <tr>
                        <th>
                          LineMan Name
                        </th>
                        <th>
                           LineMan Type
                        </th>
                        <th style="width: 70px;">
                            Is Active
                        </th>
                        <th>
                            Action
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLineManName" runat="server" autocomplete="off" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLineManType" runat="server">                               
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbIsActive" runat="server" />
                        </td>
                        <td style="width: 40px">
                            <asp:ImageButton ID="btnAdd_Empty" runat="server" ImageUrl="~/images/add-butt.png"
                                OnClick="btnAdd_Empty_Click"/>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grdLineManAdmin" runat="server" AutoGenerateColumns="false" CssClass="AddClass_Table"
                    OnRowCancelingEdit="grdLineManAdmin_RowCancelingEdit" OnRowEditing="grdLineManAdmin_RowEditing"
                    BorderWidth="0" OnRowUpdating="grdLineManAdmin_RowUpdating" OnRowDataBound="grdLineManAdmin_RowDataBound" Width="500px">
                    <Columns>
                        <asp:TemplateField HeaderText="LineMan Name">
                            <ItemTemplate>
                                <asp:Label ID="txtLineManName" runat="server" Text='<%# Bind("LineManName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("LineManId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LineMan Type">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlLineManType" runat="server" Enabled="false">                                   
                                </asp:DropDownList>
                                 <asp:HiddenField ID="hdnLineManType" runat="server" Value='<%# Bind("LineManType") %>' /> 
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlLineManType" runat="server">
                                   <asp:ListItem>LineMan</asp:ListItem>
                                   <asp:ListItem>Floor Incharge</asp:ListItem>
                                </asp:DropDownList>  
                                  <asp:HiddenField ID="hdnLineManType" runat="server" Value='<%# Bind("LineManType") %>' /> 
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbIsActive" runat="server" Enabled="false" Checked='<%# Bind("IsActive") %>' /> 
                            </ItemTemplate>
                             <EditItemTemplate>
                                <asp:CheckBox ID="cbIsActive" runat="server" Checked='<%# Bind("IsActive") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_Edit" ImageUrl="../../images/edit2.png" Style="position: relative;
                                    top: 2px" ToolTip="Edit" CommandName="Edit" runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btn_Update" ImageUrl="~/images/Save.png" ToolTip="Update" Style="width: 18px;"
                                    CommandName="Update" runat="server" />
                                <asp:ImageButton ID="btn_Cancel" ImageUrl="~/images/Cancel1.jpg" ToolTip="Cancel"
                                    Style="width: 25px;" CommandName="Cancel" runat="server" />
                            </EditItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle CssClass="border_right_color textCenter" />
                            <FooterTemplate>
                                <asp:ImageButton ID="btn_add" runat="server" ImageUrl="~/images/add-butt.png" CommandName="AddRow"
                                     />
                            </FooterTemplate>
                            <FooterStyle CssClass="textCenter" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
