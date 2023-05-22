<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientView.ascx.cs"
    Inherits="iKandi.Web.ClientView" %>
<div style="width: 600px; height: 600px; overflow: auto;">
    <div class="form_box">
        <div class="form_heading_Silver">
            Client Details
        </div>
        <table class="booking_calculator_silver th" border="1" cellspacing="0">
            <tr>
                <th width="49px">
                    COMPANY/BUYING HOUSE:
                </th>
                <td width="100px">
                    <asp:Label ID="lbl_com_name" runat="server"></asp:Label>
                </td>
                <th width="100px">
                    CLIENT SINCE:
                </th>
                <td colspan="3" width="200px">
                    <asp:Label ID="lbl_clnt_snce" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th width="100px">
                    CLIENT WEBSITE:
                </th>
                <td width="200px">
                    <asp:Label ID="lbl_clnt_wbsite" runat="server"></asp:Label>
                </td>
                <th width="100px">
                    ADDRESS:
                </th>
                <td colspan="3" width="200px">
                    <asp:Label ID="lbl_addrs" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th width="100px">
                    PHONE:
                </th>
                <td width="200px">
                    <asp:Label ID="lbl_phn" runat="server"></asp:Label>
                </td>
                <th width="100px">
                    CLIENT CODE:
                </th>
                <td colspan="3" width="200px">
                    <asp:Label ID="lbl_clnt_code" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th width="100px">
                    EMAIL:
                </th>
                <td width="200px">
                    <asp:Label ID="lbl_email" runat="server"></asp:Label>
                </td>
                <th width="100px">
                    AQL STANDARDS:
                </th>
                <td width="49px">
                    <asp:Label ID="lbl_aql_stdrd" runat="server"></asp:Label>
                </td>
                <th width="100px">
                    IS MDA REQUIRED :
                </th>
                <td width="49px">
                    <asp:Label ID="lbl_mda_reqrd" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="form_box">
        <div class="form_heading_Silver">
            FINANCIAL</div>
        <table class="booking_calculator_silver " border="1" cellspacing="0">
            <tr>
                <th width="100px">
                    DISCOUNT % FOR THIS CLIENT:
                </th>
                <td width="200px">
                    <asp:Label ID="lbl_dscount" runat="server"></asp:Label>
                </td>
                <th width="100px">
                    PAYMENT TERMS:
                </th>
                <td width="200px">
                    <asp:Label ID="lbl_paymnt_trms" runat="server"></asp:Label>Days
                </td>
            </tr>
            <tr>
                <th width="100px">
                    OFFICIAL NAME:
                </th>
                <td width="200px">
                    <asp:Label ID="lbl_oficial_name" runat="server"></asp:Label>
                </td>
                <th width="100px">
                    BILLING ADDRESS:
                </th>
                <td width="200px">
                    <asp:Label ID="lbl_bllng_addrs" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="form_box">
        <div class="form_heading_Silver">
            DEPARTMENTS</div>
        <asp:Repeater ID="repeater_department" runat="server">
            <HeaderTemplate>
                <table class="booking_calculator_silver" border="1" cellspacing="0">
            </HeaderTemplate>
            <ItemTemplate>
                <th width="100px">
                    DEPARTMENT:
                </th>
                <td width="100px">
                    <%#Eval("Name") %>
                </td>
                <th width="100px">
                    USERNAME:
                </th>
                <td width="100px">
                    <%#Eval("Username") %>
                </td>
                <th width="30px;">
                    MON:
                </th>
                <td width="10px;">
                    <%#Convert.ToInt32 (Eval("Mon"))==1 ? "Y" : "N" %>
                </td>
                <th width="30px;">
                    TUE:
                </th>
                <td width="10px;">
                    <%#Convert.ToInt32(Eval("Tue"))==1?"Y":"N" %>
                </td>
                <th width="20px;">
                    WED:
                </th>
                <td width="20px;">
                    <%#Convert.ToInt32(Eval("Wed"))==1?"Y":"N" %>
                </td>
                <th width="20px;">
                    THU:
                </th>
                <td width="20px;">
                    <%#Convert.ToInt32(Eval("Thu"))==1?"Y":"N" %>
                </td>
                <th width="20px;">
                    FRI:
                </th>
                <td width="20px;">
                    <%#Convert.ToInt32(Eval("Fri"))==1?"Y":"N" %>
                </td>
                </tr>
                <tr>
                    <th width="100px">
                        SALES:
                    </th>
                    <td width="100px">
                        <%#Eval("SalesManagerNames").ToString().Replace(",",",<br/>")%>
                    </td>
                    <th width="100px">
                        DESIGNER:
                    </th>
                    <td width="100px">
                        <%#Eval("DesignerNames").ToString().Replace(",", ",<br/>")%>
                    </td>
                    <th width="100px" colspan="4">
                        A/C MANAGER:
                    </th>
                    <td width="100px" colspan="6">
                        <%#Eval("AccountManagerNames").ToString().Replace(",", ",<br/>")%>
                    </td>
                </tr>
                <tr>
                    <th width="100px">
                        TECHNOLOGIST:
                    </th>
                    <td width="100px">
                        <%#Eval("TechnologistNames").ToString().Replace(",", ",<br/>")%>
                    </td>
                    <th width="100px">
                        SHIPPING MANAGER:
                    </th>
                    <td width="100px">
                        <%#Eval("ShippingManagerNames").ToString().Replace(",", ",<br/>")%>
                    </td>
                    <th width="100px" colspan="4">
                        DELIVERY MANAGER:
                    </th>
                    <td width="100px" colspan="6">
                        <%#Eval("DeliveryManagerNames").ToString().Replace(",", ",<br/>")%>
                    </td>
                </tr>
                <tr>
                    <th width="100px">
                        Production  Merchandiser:
                    </th>
                    <td width="100px">
                        <%#Eval("FITMerchantNames").ToString().Replace(",", ",<br/>")%>
                    </td>
                    <th width="100px">
                        SAMPLING MERCHANT:
                    </th>
                    <td width="100px">
                        <%#Eval("SamplingMerchantNames").ToString().Replace(",", ",<br/>")%>
                    </td>
                    <th colspan="4">
                        Client Head
                    </th>
                    <td colspan="6">
                        <%# Eval("ClientHeadNames").ToString().Replace(",", "<br/>")%>
                    </td>
                </tr>
                <tr>
                    <td colspan="14">
                        <br />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="form_box">
        <asp:Panel ID="pnlEx" runat="server">
            <div id="divExt" runat="server" class="form_heading_Silver">
                EXTERNAL ASSIGNMENTS</div>
            <asp:Repeater ID="repeater_extrnl_assignment" runat="server">
                <HeaderTemplate>
                    <table class="booking_calculator_silver" border="1" cellspacing="0">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th width="100px">
                            NAME:
                        </th>
                        <td width="100px">
                            <%#Eval("Name") %>
                        </td>
                        <th width="100px">
                            EMAIL:
                        </th>
                        <td width="100px">
                            <%#Eval("Email") %>
                        </td>
                        <th width="100px">
                            PHONE:
                        </th>
                        <td width="100px">
                            <%#Eval("Phone") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
    </div>
</div>
