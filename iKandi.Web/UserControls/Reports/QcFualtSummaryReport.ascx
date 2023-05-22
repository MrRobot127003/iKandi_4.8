<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QcFualtSummaryReport.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.QcFualtSummaryReport" %>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style type="text/css">
  
    .HeaderClass td
    {
        background: #dddfe4;
        font-weight: bold;
        color: #575759;
        font-family: arial, halvetica;
        height: 20px !important;
        border: 1px solid #999999;
    }
    .HeaderClass2 td
    {
        border-right: 1px solid #999999;
        border-top: 0px solid !important;
        border-bottom: 0px solid #999999;
        border-left: 0px solid #999999;
        font-weight: normal;
        border-spacing: 0px !important;
        color: #575759;
        height: 20px !important;
        background: #dddfe4;
    }
    .AddClass_Table th
    {
        background:#fff;
        padding: 0px;
      }
       .AddClass_Table th table th
       {
            background: #dddfe4;
        }
      .AddClass_Table tr:nth-last-child(2)>td 
       {
           border-bottom-color:#999 !important;
        }
   
</style>
<br />
<asp:GridView ID="grdqcfualtsummary" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdqcfualtsummary_RowDataBound"
    ShowHeader="true" Width="821px" CellPadding="0" CssClass="AddClass_Table grdproc"
    ShowFooter="true" BorderStyle="Solid" BorderWidth="0" BorderColor="#999999" CellSpacing="0"
    Style="border-collapse: collapse;">
    <Columns>
        <asp:TemplateField ShowHeader="false">
            <ItemTemplate>
                &nbsp; &nbsp;
                <asp:Label ID="lblQaProcessId" Text='<%#Eval("ProcessName")%>' runat="server"></asp:Label>
                <asp:HiddenField ID="hdnQaProcessId" runat="server" Value='<%#Eval("ProcessId")%>' />
            </ItemTemplate>
            <ItemStyle Width="200px" ForeColor="#999999" BackColor="#dddfe4" CssClass="border-set firstcolwidth"
                BorderStyle="Solid" BorderColor="#999999" BorderWidth="1" />
            <FooterTemplate>
                <%--Note:- Pressing Standards (Pass)- Pr. St., Ndl Plcy- Ndl. P., SPI & Metal Dt. (Pass)-
                SPI Metal DT., Signed R&D- R&D, L-Man Pc (Pass)- L-Man PC--%>
            </FooterTemplate>
            <HeaderStyle ForeColor="#999999" BackColor="#dddfe4" BorderWidth="0" BorderStyle="None" />
        </asp:TemplateField>
        <%--C47-------------------------------------------------------------------------------------------------%>
        <asp:TemplateField ControlStyle-BorderColor="#999999">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" width="100%"
                    style="border-spacing: 0px !important; border-collapse: collapse; border-top: 0px solid !important;
                    border-bottom: 0px solid !important;">
                    <tr>
                        <th style="width: 80px; height: 20px !important; border-spacing: 0px !important;
                            border-right: 1px solid #999999; color: #575759; border-top: 0px solid !important;
                            border-bottom: 0px solid #999999 !important; border-left: 0px solid #999999;
                            font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterSumC47" Text=""></asp:Label>
                        </th>
                        <th id="thQuaterc47" runat="server" style="width: 60px; height: 20px !important;
                            border-spacing: 0px !important; border-right: 1px solid #999999; color: #575759;
                            border-top: 0px solid !important; border-bottom: 0px solid #999999 !important;
                            border-left: 0px solid #999999; font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterC47" Text=""></asp:Label>
                        </th>
                        <th style="border-spacing: 0px !important; height: 20px !important; width: 60px;
                            font-weight: normal; border-top: 0px solid !important; color: #575759; border-bottom: 0px solid #999999 !important;
                            border-left: 0px solid #999999; padding: 0px !important">
                            <asp:Label runat="server" ID="lblPresentC47Month"></asp:Label>
                        </th>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%"
                    style="border-collapse: collapse;border-color:#9999">
                    <tr>
                        <th id="tdQuarterSum_C47" runat="server" style="height: 20px; width: 80px;border-spacing: 0px !important;
                            border-top: 0px;border-left:0px;border-color:#9999">
                            <asp:Label ID="lblQuarterSum_C47" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="tdQuarter_C47" runat="server" style="height: 20px; width: 60px;border-color:#9999;border-spacing: 0px !important;
                            border-top: 0px">
                            <asp:Label ID="lblQuarter_C47" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="td1monthC47" runat="server" style="height: 20px;border-color:#9999; width: 60px;border-spacing: 0px !important;
                            border-top: 0px;">
                            <asp:Label ID="lbl1monthC47" Font-Bold="false" Font-Size="12px" runat="server"></asp:Label>
                        </th>
                    </tr>
                </table>
            </ItemTemplate>
            <ItemStyle Width="200px" CssClass="center" />
            <HeaderStyle ForeColor="gray" BackColor="#dddfe4" />
        </asp:TemplateField>
        <%--C45 46-------------------------------------------------------------------------------------------------%>
        <asp:TemplateField ControlStyle-BorderColor="#999999">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" width="100%"
                    style="border-spacing: 0px !important; border-collapse: collapse; border-top: 0px solid !important;
                    border-bottom: 0px solid !important;">
                    <tr>
                        <th style="border-spacing: 0px !important; height: 20px !important; width: 79px;
                            border-right: 1px solid #999999; border-top: 0px solid !important; color: #575759;
                            border-bottom: 0px solid #999999 !important; border-left: 0px solid #999999;
                            font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterSumC45" Text=""></asp:Label>
                        </th>
                        <th id="thQuaterc45" runat="server" style="width: 60px; border-spacing: 0px !important;
                            height: 20px !important; border-right: 1px solid #999999; border-top: 0px solid !important;
                            color: #575759; border-bottom: 0px solid #999999 !important; border-left: 0px solid #999999;
                            font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterC45" Text=""></asp:Label>
                            </td>
                        </th>
                        <th style="width: 60px; height: 20px !important; border-spacing: 0px !important;
                            font-weight: normal; border-top: 0px solid !important; color: #575759; border-bottom: 0px solid #999999 !important;
                            border-left: 0px solid #999999; padding: 0px !important">
                            <asp:Label runat="server" ID="lblPresentC45Month"></asp:Label>
                        </th>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%">
                    <tr>
                        <th id="tdQuarterSum_C45" runat="server" style="height: 20px;border-color:#9999; width: 80px;border-spacing: 0px !important;
                            border-top: 0px;border-left:0px">
                            <asp:Label ID="lblQuarterSum_C45" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="tdQuarter_C45" runat="server" style="height: 20px;border-color:#9999; width: 60px;border-spacing: 0px !important;
                            border-top: 0px">
                            <asp:Label ID="lblQuarter_C45" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="td1monthC45" runat="server" style="height: 20px;border-color:#9999; width: 60px;border-spacing: 0px !important;
                            border-top: 0px;">
                            <asp:Label ID="lbl1monthC45" Font-Bold="false" Font-Size="12px" runat="server"></asp:Label>
                        </th>
                    </tr>
                </table>
            </ItemTemplate>
            <ItemStyle Width="200px" CssClass="center" />
            <HeaderStyle ForeColor="#999999" BackColor="#dddfe4" />
        </asp:TemplateField>
        <%--  D169--%>
        <asp:TemplateField ControlStyle-BorderColor="#999999">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" width="100%"
                    style="border-spacing: 0px !important; border-collapse: collapse; border-top: 0px solid !important;
                    border-bottom: 0px solid !important;">
                    <tr>
                        <th id="widthheadercol" style="border-spacing: 0px !important; width: 80px; height: 20px !important;
                            border-right: 1px solid #999999; border-top: 0px solid !important; color: #575759;
                            border-bottom: 0px solid #999999 !important; border-left: 0px solid #999999;
                            font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterSumD169" Text=""></asp:Label>
                        </th>
                        <th id="thQuaterD169" runat="server" style="border-spacing: 0px !important; width: 60px;
                            height: 20px !important; border-right: 1px solid #999999; border-top: 0px solid !important;
                            color: #575759; border-bottom: 0px solid #999999 !important; border-left: 0px solid #999999;
                            font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterD169" Text=""></asp:Label>
                            </td>
                        </th>
                        <th style="height: 20px !important; border-spacing: 0px !important; font-weight: normal;
                            border-top: 0px solid !important; color: #575759; border-bottom: 0px solid #999999 !important;
                            border-left: 0px solid #999999; padding: 0px !important; width: 60px;">
                            <asp:Label runat="server" ID="lblPresentD169Month"></asp:Label>
                        </th>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%">
                    <tr>
                        <th id="tdQuarterSum_D169" runat="server" style="height: 20px;border-color:#9999; width: 80px;border-spacing: 0px !important;
                            border-top: 0px;border-left:0px">
                            <asp:Label ID="lblQuarterSum_D169" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="tdQuarter_D169" runat="server" style="height: 20px;border-color:#9999; width: 60px;border-spacing: 0px !important;
                            border-top: 0px">
                            <asp:Label ID="lblQuarter_D169" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="td1monthD169" runat="server" style="height: 20px;border-color:#9999; width: 60px;border-spacing: 0px !important;
                            border-top: 0px;">
                            <asp:Label ID="lbl1monthD169" Font-Bold="false" Font-Size="12px" runat="server"></asp:Label>
                        </th>
                    </tr>
                </table>
            </ItemTemplate>
            <ItemStyle Width="200px" CssClass="center" />
            <HeaderStyle ForeColor="#999999" BackColor="#dddfe4" />
        </asp:TemplateField>
        <%--BIPL-------------------------------------------------------------------------------------------------%>
        <asp:TemplateField ControlStyle-BorderColor="#999999">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" frame="void" rules="all" width="100%"
                    style="border-spacing: 0px !important; border-collapse: collapse; border-top: 0px solid !important;
                    border-bottom: 0px solid !important;border-right: 0px solid gray !important;">
                    <tr>
                        <th style="width: 80px; height: 20px !important; border-spacing: 0px !important;
                            border-right: 1px solid #999999 !important; border-top: 0px solid !important; color: #575759;
                            border-bottom: 0px solid #999999 !important; border-left: 0px !important;
                            font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterSumBipl" Text=""></asp:Label>
                        </th>
                        <th id="thQuatercBIPL" runat="server" style="width: 65px; height: 20px !important;
                            border-spacing: 0px !important; border-right: 0px solid #999999; border-bottom: 0px;
                            border-top: 0px solid !important; color: #575759; font-weight: normal; padding: 0px !important">
                            <asp:Label runat="server" ID="lblQuaterBipl" Text=""></asp:Label>
                        </th>
                        <th style="width: 65px; height: 20px !important; border-spacing: 0px !important;
                            font-weight: normal; border-top: 0px solid !important; color: #575759; border-bottom: 0px solid #999999 !important;
                            border-left: 0px solid #999999; border-right: 0px solid #585555 !important; padding: 0px !important">
                            <asp:Label runat="server" ID="lblPresentBiplMonth"></asp:Label>
                        </th>
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle  CssClass="hederborderright" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" frame="void" rules="all" width="100%">
                    <tr>
                        <th id="tdQuarterSum_BIPL" runat="server" style="height: 20px;border-color:#9999; width: 80px;border-spacing: 0px !important;
                            border-top: 0px;border-left:0px">
                            <asp:Label ID="lblQuarterSum_BIPL" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="tdQuarter_BIPL" runat="server" style="height: 20px;border-color:#9999; width: 65px;border-spacing: 0px !important;
                            border-top: 0px">
                            <asp:Label ID="lblQuarter_BIPL" Font-Bold="false" runat="server"></asp:Label>
                        </th>
                        <th id="td1monthBIPL" runat="server" style="height: 20px;border-color:#9999; width: 65px;border-spacing: 0px !important;
                            border-top: 0px;">
                            <asp:Label ID="lbl1monthBIPL" Font-Bold="false" Font-Size="12px" runat="server"></asp:Label>
                        </th>
                    </tr>
                </table>
            </ItemTemplate>
            <ItemStyle Width="210px" Font-Bold="true" CssClass="center" />
            <HeaderStyle ForeColor="#999999" BackColor="#dddfe4" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
