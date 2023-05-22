<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUpdateClientDepAssociation.aspx.cs" Inherits="iKandi.Web.Admin.FrmUpdateClientDepAssociation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/technical-module.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%--<asp:Panel id="divuser" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
            Is Active <asp:CheckBox ID="ChkDeactivate" runat="server" AutoPostBack="true"
            oncheckedchanged="ChkDeactivate_CheckedChanged1"/>
            <asp:GridView ID="grduser"  runat="server" AutoGenerateColumns="false" RowStyle-Height="35px" 
                                                RowStyle-VerticalAlign="Middle" OnRowDataBound="grduser_RowDataBound" 
                                                ShowHeader="true" CssClass="item_list">
             <Columns>
             <asp:TemplateField HeaderText="Client">
             <ItemTemplate>
             <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CompanyName") %>' ></asp:Label>
             <asp:HiddenField ID="hdnClientID" runat="server" Value='<%# Eval("clientID") %>' />
             </ItemTemplate>
             <ItemStyle Width="100px" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Department">
             <ItemTemplate>
             

             <asp:ListBox ID="listDept" ToolTip="Press (Shift+End/Home key for select all or go up & down)"
                                                runat="server" AppendDataBoundItems="true" Style="width:100%" SelectionMode="Multiple">
                                                <%--<asp:ListItem Selected="True" style="color: Maroon; text-decoration: line-through;"
                                                    Value="0">None</asp:ListItem>--%>
                                            </asp:ListBox>

             <asp:HiddenField ID="hdndept" runat="server" />
             </ItemTemplate>
             <ItemStyle Width="150px" />
             
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Designation">
             <ItemTemplate>
             

             <asp:ListBox ID="listdesignation" AutoPostBack="true" ToolTip="Press (Shift+End/Home key for select all or go up & down)"
                                                runat="server" AppendDataBoundItems="true" Style="width:100%" OnSelectedIndexChanged="listdesignation_SelectedIndexChanged" SelectionMode="Multiple">
                                               <%-- <asp:ListItem Selected="True"  style="color: Maroon; text-decoration: line-through;"
                                                    Value="0">None</asp:ListItem>--%>
                                            </asp:ListBox>

             <asp:HiddenField ID="hdndesignation" runat="server" />
             </ItemTemplate>
             <ItemStyle Width="150px" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="User">
             <ItemTemplate>
             

             <asp:ListBox ID="listuser" ToolTip="Press (Shift+End/Home key for select all or go up & down)"
                                                runat="server" AppendDataBoundItems="true" Style="width: 100%" SelectionMode="Multiple">
                                               <%-- <asp:ListItem Selected="True" style="color: Maroon; text-decoration: line-through;"
                                                    Value="0">None</asp:ListItem>--%>
                                            </asp:ListBox>

             <asp:HiddenField ID="hdnuser" runat="server" />
                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="listuser" Display="Dynamic" InitialValue="" runat="server" ErrorMessage="Please select atleast one User"></asp:RequiredFieldValidator>--%>
             </ItemTemplate>
             <ItemStyle Width="400px" />
             </asp:TemplateField>
             </Columns>
          </asp:GridView>
        <%--  </ContentTemplate>--%>
                                           <%--  </asp:UpdatePanel>
            </asp:Panel>--%>
            <asp:Button ID="btnSubmit" runat="server" class="da_submit_button submit" 
                    OnClick="Submit_Click" Text="Submit" /> &nbsp;
                    <asp:Button ID="btnclose" runat="server" class="da_submit_button" 
                    OnClientClick="javascript:window.open('','_self').close();" Text="Close" />
    </div>
    </form>
</body>
</html>
