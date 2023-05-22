<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auditors.aspx.cs" Inherits="iKandi.Web.Admin.Categories.Auditors" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../../js/jquery.jcarousel.js" type="text/javascript"></script>
    <script src="../../js/jquery.autocomplete.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-family: "Lucida Sans Unicode";
            font-size: 12px;
        }
        
        .btncancel
        {
            line-height: 18px;
            background: #39589c;
            text-align: center;
            color: #fff;
            border: 1px solid #999;
            border-radius: 2px;
            cursor: pointer;
        }
        
        .btnsubmit
        {
            line-height: 18px;
            background: #13a747;
            text-align: center;
            color: #fff;
            border: 1px solid #999;
            border-radius: 2px;
            cursor: pointer;
            margin-left: 10%;
        }
        
        .btnsubmit:hover
        {
            line-height: 18px;
            background: #13a747;
            text-align: center;
            border: 1px solid #999;
            border-radius: 2px;
        }
        .AuditoresTable
        {
            border: 1px solid #999;
            width: 145px;
            margin: 0 auto;
        }
        .AuditoresTable td
        {
            border: 1px solid #999;
            padding-left: 2px;
            font-size: 11px;
        }
        .textCenter
        {
            text-align: center;
        }
        h2
        {
            background: #39589c;
            text-align: center;
            padding: 0px 0px;
            border: 1px solid #999;
            border-radius: 2px;
            width: 99.5%;
            text-align: center;
            margin: 0px;
            color: #fff;
            font-weight: 500;
            font-size: 15px;
        }
      .EmptyRow td[colspan="2"]
      {
          border:0px;
       }
        input[type="radio"]
        {
            position: relative;
            top: 2px;
        }
        .AutoUser
        {
            text-transform: capitalize !important;
        }
        div.ac_results {
            padding: 5px;
            border: 1px solid #dccbcb !important;
            border: 1px solid #dccbcb;
            width: 219px !important;
        }
    </style>
    <script type="text/javascript">
        function CallBackParentPage() {
            window.parent.ReloadPage();
            window.parent.Shadowbox.close();
            return true;
        }
        $(document).ready(function () {
            $(".AutoUser").autocomplete("/Webservices/iKandiService.asmx/SuggestAuditors", { dataType: "xml", datakey: "string", max: 100 });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; margin: 0px auto; font-size: 11px;">
        <h2>
            Add Auditors</h2>
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        <div style="width: 80%; margin: 5px auto">
        
            <asp:GridView ID="grdAuditor" runat="server" AutoGenerateColumns="False" ShowHeader="false"
                ShowFooter="true" Width="100%" BorderWidth="0" CssClass="AuditoresTable" OnRowDeleting="grdAuditor_RowDeleting"
                OnRowCommand="grdAuditor_RowCommand">
                <EmptyDataRowStyle CssClass="EmptyRow" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblName" Text='<%# Bind("Name") %>' runat="server" />
                            <asp:HiddenField ID="hdnUserID" runat="server" Value='<%# Bind("Id") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAuditor" Width="98%" CssClass="AutoUser" runat="server" onpaste="return false;"></asp:TextBox>
                        </FooterTemplate>
                        <ItemStyle CssClass="textCenter" />
                    </asp:TemplateField>
                </Columns>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btn_Delete" ImageUrl="~/images/delete-icon.png" ToolTip="Delete"
                                Style="width: 15px;" CommandName="Delete" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                        <div style="text-align:center">
                            <asp:ImageButton ID="btnAdd" ImageUrl="~/images/add-butt.png" ToolTip="Add" CommandName="AddRow"
                                CssClass="btnadd" runat="server" />
                                </div>
                        </FooterTemplate>
                        <ItemStyle Width="37px" CssClass="textCenter" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtAuditorEmpty" Width="98%" CssClass="AutoUser" runat="server"
                                    onpaste="return false;"></asp:TextBox>
                            </td>
                            <td style="text-align: center;border-left:0px;">
                                 <asp:ImageButton ID="btnAdd" ImageUrl="~/images/add-butt.png" ToolTip="Add" CommandName="AddRow"
                                CssClass="btnadd" runat="server" style="margin:1px 0px 2px;" />
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        
      <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
        <span style="margin-left: 27px;">
            <asp:RadioButton ID="rbtAllDetailsForSameCatg" runat="server" Text="All Options/Questions of the Category"
                Checked="true" GroupName="g" /><br />
        </span><span style="margin-left: 27px;">
            <asp:RadioButton ID="rbtAllCatsAllDetails" runat="server" Text="All Options/Questions of All the Categories"
                GroupName="g" />
        </span>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnsubmit" OnClick="btnSave_Click" />
        <input type="button" class="btncancel" value="Cancel" onclick="javascript:window.parent.Shadowbox.close();" />

    </div>

    </form>
</body>
</html>
