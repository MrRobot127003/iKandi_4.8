<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveInformation.ascx.cs"
    Inherits="iKandi.Web.LeaveInformation" %>
<%@ Import Namespace="iKandi.Common" %>

 <style type="text/css">
        .GrdColor
        {
        	background-color:#0066FF;
            color:White;
            font-family:Arial;
            font-size:px;
        	}
       .UPC
       {
       	text-transform:uppercase;
       	font-size:12px;
       	} 	
       	.cen
       	{
       	text-align:center;
       		}
    </style>

<div class="portlet booking_calculator">
   
    <div class="portlet_content text_uppercase_style booking_calculator">
        <div>
            <asp:GridView ID="gvMyLeaves" runat="server" AutoGenerateColumns="False" CssClass="fixed-header"
                AllowPaging="False"  Caption="My Holidays" Width=100% >
                <Columns>
                    <asp:TemplateField HeaderText="TYPE" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <p>
                                <%# ((LeaveType)Eval("Type")).Name %></p>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STATUS" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White" >
                        <ItemTemplate>
                            <p>
                                <%# Eval("Status")%></p>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duration" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <p>
                                <%# Convert.ToDateTime(Eval("FromDate")).ToString("dd MMM yy")%>
                                <br />
                                To<br />
                                <%# Convert.ToDateTime(Eval("ToDate")).ToString("dd MMM yy")%></p>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="FromDate" HeaderText="FROM DATE" SortExpression="FromDate"
                    DataFormatString="{0:d}" />
                <asp:BoundField DataField="ToDate" HeaderText="TO DATE" SortExpression="ToDate" DataFormatString="{0:d}" />--%>
                </Columns>
                <EmptyDataTemplate>
                    No Pending Holiday Found
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <asp:GridView ID="gvPendingLeaves" runat="server" AutoGenerateColumns="False" Caption="Holidays To Approve"
                CssClass="" AllowPaging="False" Width=100%>
                <Columns>
                    <asp:TemplateField HeaderText="Applied By" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <%# (Eval("Employee") as User).FullName %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STATUS" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <p>
                                <%# Eval("Status")%></p>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duration" ItemStyle-CssClass="date_style" HeaderStyle-BackColor="#0066FF" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <p >
                                <%# Convert.ToDateTime(Eval("FromDate")).ToString("dd MMM yy")%>
                                <br />
                                To<br />
                                <%# Convert.ToDateTime(Eval("ToDate")).ToString("dd MMM yy")%></p>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No Pending Holiday Found
                </EmptyDataTemplate>
            </asp:GridView>
            <div style="font-size:8px">Only 5 pending Holidays are displayed above.</div>
            <asp:HyperLink runat="server" ID="hlMyLeaves" NavigateUrl="~/internal/Leave/LeaveApplication.aspx"
                Visible="true" Text="Apply for Holiday">
            </asp:HyperLink><br />
            <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/internal/Leave/Leaves.aspx"
                Visible="true" Text="Employee Holiday List">
            </asp:HyperLink>&nbsp;
           
        </div>
    </div>
</div>
