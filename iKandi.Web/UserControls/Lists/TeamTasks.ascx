<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamTasks.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.TeamTasks" %>

<script type="text/javascript">
    var hfTeamTask = '<%=hfTeamTask.ClientID%>';
    $(function () {
        $('.teamtask').click(function () {
            var show = $(this).next('.teamsubtask').is(":visible");
            if (show)
                $(this).next('.teamsubtask').slideUp('fast');
            $('.teamsubtask').hide();
            if (!show)
                $(this).next('.teamsubtask').slideDown('fast')
        });
    });
    this.tooltipdb = function () {
        /* CONFIG */
        xOffset = 10;
        yOffset = 20;
        // these 2 variable determine popup's distance from the cursor
        // you might want to adjust to get the right result		
        /* END CONFIG */
        $("a.tooltipdb").hover(function (e) {
            this.t = this.title;
            this.title = "";
            $("body").append("<p id='tooltipdb'>" + tooltioSplit(this.t) + "</p>");
            $("#tooltipdb")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px")
			.fadeIn("fast");
        },
	function () {
	    this.title = this.t;
	    $("#tooltipdb").remove();
	});
        $("a.tooltipdb").mousemove(function (e) {
            $("#tooltipdb")
			.css("top", (e.pageY - xOffset) + "px")
			.css("left", (e.pageX + yOffset) + "px");
        });
    };



    // starting the script on page load
    $(document).ready(function () {
        tooltipdb();
    });
</script>
<asp:Repeater ID="rptTeamTask" runat="server" OnItemDataBound="rptTeamTask_ItemDataBound">
    <ItemTemplate>
        <div class="teamtask design">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <img src="../images/bullet2.jpg" alt="" /><asp:Literal ID="Literal2" runat="server"
                            Text='<%#Eval("Dept_Name") %>'></asp:Literal>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="right" style="padding-right: 5px; font-weight: bold;">
                        (<asp:Literal ID="Literal4" runat="server" Text='<%#Eval("Task_Count") %>'></asp:Literal>)
                    </td>
                </tr>
            </table>
        </div>
        <div class="teamsubtask content" align="left" style="float: left;">
            <asp:Repeater ID="rptTeamSubTask" runat="server">
                <ItemTemplate>

                    <table width="100%" border="0" cellspacing="0" cellpadding="0" onclick="JavaScript:GetTeamTask(<%#Eval("TaskId") %>,this)">
                        <tr >
                            <td>
                            <a ID="alittask" runat="server" class="tooltipdb" title='<%#Eval("Description") %>'><%#Eval("Task_Name") %></a>
                                                        <%--<asp:Literal ID="litTask" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>--%>
                                                    </div>
                                <%--<asp:Literal ID="Literal5"  runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>--%>
                                <asp:Label ID="Label1" runat="server" Text='<%#"("+Eval("Task_Designation")+")" %>'
                                    CssClass="designation" Style="padding-left: 10px; width:100%;"></asp:Label>
                            </td> 
                            <td>
                                &nbsp;
                            </td>
                            <td align="right" style="padding-right: 5px; font-weight: bold;">
                                (<asp:Literal ID="Literal6" runat="server" Text='<%#Eval("Task_Count") %>'></asp:Literal>)
                            </td>
                        </tr>
                    </table>


                </ItemTemplate>
                <SeparatorTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img src="../images/seperatorbar.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </SeparatorTemplate>
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>
<asp:HiddenField ID="hfTeamTask" runat="server" Value="0" />
