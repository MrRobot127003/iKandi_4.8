<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testPoFor.aspx.cs" Inherits="iKandi.Web.testPoFor" %>

<%--<%@ Register src="UserControls/Forms/OBPermission_New.ascx" tagname="OBPermission_New" tagprefix="uc1" %>--%>
<%@ Register src="UserControls/Reports/QcFualtSummaryReport.ascx" tagname="QcFualtSummaryReport" tagprefix="uc1" %>
<%--<%@ Register Src="UserControls/Reports/rpt_IkandiAdminCommit_Sales.ascx" TagName="rpt_IkandiAdminCommit_Salesrepart"
    TagPrefix="uc1" %>--%>
<%--<%@ Register src="UserControls/Reports/Reallocation_OutHouse_Emb.ascx" tagname="Reallocation_OutHouse_Emb" tagprefix="uc1" %>
<%@ Register src="UserControls/Reports/Reallocation_OutHouse.ascx" tagname="Reallocation_OutHouse" tagprefix="uc2" %>--%>
<%--<%@ Register src="UserControls/Lists/PairingCosting.ascx" tagname="PairingCosting" tagprefix="uc1" %>--%>
<%--<%@ Register src="UserControls/Reports/frmQcLineManSummeryReport.ascx" tagname="frmQcLineManSummeryReport" tagprefix="uc1" %>--%>
<%--<%@ Register src="UserControls/Reports/frmPoUploadPendingBreakDown.ascx" tagname="frmPoUploadPendingBreakDown" tagprefix="uc1" %>--%>
<%--<%@ Register src="UserControls/Reports/frmComplianceQAuditReport.ascx" tagname="frmComplianceQAuditReport" tagprefix="uc1" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <%-- <uc1:frmComplianceQAuditReport ID="frmComplianceQAuditReport1" 
        runat="server" />--%>
    <%--<uc1:frmPoUploadPendingBreakDown ID="frmPoUploadPendingBreakDown1" 
        runat="server" />--%>
    <%--<uc1:frmQcLineManSummeryReport ID="frmQcLineManSummeryReport1" runat="server" />--%>
    <%--<uc1:PairingCosting ID="PairingCosting1" runat="server" />--%>
    <%--   <uc1:Reallocation_OutHouse_Emb ID="Reallocation_OutHouse_Emb1" runat="server" />
    <uc2:Reallocation_OutHouse ID="Reallocation_OutHouse1" runat="server" />--%>
     <uc1:QcFualtSummaryReport ID="QcFualtSummaryReport1" runat="server" />
    <%-- <uc1:QcFualtSummaryReport ID="QCFualtSummaryReport" runat="server" />--%>
    <%--<uc1:rpt_IkandiAdminCommit_Salesrepart ID="rpt_IkandiAdminCommit_Sales1" runat="server" />--%>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="400px">
                    <tr style="width: 200px">
                        <td>
                            Enter search term:<asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged"
                                AutoPostBack="true" Font-Size="20px" Font-Bold="true" Width="283px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="width: 200px">
                        <td>
                            <asp:GridView ID="grdinproduction" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false"
                                runat="server" ShowFooter="false" ShowHeader="false" Width="400px" CellPadding="0"
                                BorderWidth="1" HorizontalAlign="Center">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="imhuserimage" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/photo/" + Eval("UserProfilePic").ToString()) %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" Height="50px" CssClass="split-para" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" Text='<%# Eval("FirstName")%>' runat="server" ForeColor="black"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" Height="50px" CssClass="split-para" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <span style="font-size: 12px; color: Red;">Record not available</span></EmptyDataTemplate>
                                <EmptyDataRowStyle Height="60px" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
