<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyTasks.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.MyTasks" %>
<script type="text/javascript">
    var hfMyTask = '<%=hfMyTask.ClientID%>';
</script>
<asp:Repeater ID="rptMyTask" runat="server">
    <ItemTemplate>
        <div class="design2" onclick="JavaScript:GetMyTask(<%#Eval("TaskId") %>)">
            <div style="float: left" align="left">
                <asp:Literal ID="litTask" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>
            </div>
            <div style="float: right; padding-right: 5px;" align="right">
                (<asp:Literal ID="Literal1" runat="server" Text='<%#Eval("Task_Count") %>'></asp:Literal>)
            </div>
        </div>
    </ItemTemplate>
    <SeparatorTemplate>
        <img src="../images/seperatorbar2.gif" alt="" width="98%" />
    </SeparatorTemplate>
</asp:Repeater>
<asp:HiddenField ID="hfMyTask" runat="server" Value="0" />
