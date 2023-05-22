<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FITsTopsSection.ascx.cs"
    Inherits="iKandi.Web.FITsTopsSection" %>
<div class="form_box">
    <div class="form_heading">
        TOP TRACKING
    </div>
    <div style="padding: 20px;">
        <div class="form_box">
        <asp:GridView ID="grdBasicInfo" runat="server" Width="100%" AutoGenerateColumns="False"  OnRowDataBound="grdBasicInfo_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Order Date" 
                    ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%--//<%# (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("MM/dd/yyyy") %>--%>
                        <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial No." >
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnSerialNumber" runat="server" />
                        <%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LineItemNumber" HeaderText="Line NO."  />
                <asp:BoundField DataField="ContractNumber" HeaderText="Contract NO." />
                <%-- <asp:BoundField DataField="TopSentActual" HeaderText="Top Sent Actual" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="TopSentTarget" HeaderText="Top Sent Target" DataFormatString="{0:MM/dd/yyyy}" />--%>
                <asp:TemplateField HeaderText="Top Sent TGT." 
                    ItemStyle-CssClass=" date_style">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime(Eval("TopSentTarget")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("TopSentTarget"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Top Sent Actual" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                    <asp:HiddenField ID="hdnTopSendActual" runat="server" />
                        <%# (Convert.ToDateTime(Eval("TopSentActual")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("TopSentActual"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Top Approval Actual" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime(Eval("TopActualApproval")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("TopActualApproval"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BIPLComments" HeaderText="Comments (BIPL)" ItemStyle-CssClass="remarks_text remarks_text2 " />
                <asp:BoundField DataField="iKandiComments" HeaderText="Comments(ikandi)" ItemStyle-CssClass="remarks_text remarks_text2" />
            </Columns>
            <EmptyDataTemplate>
            <label>
                No records Found</label></EmptyDataTemplate>
            <HeaderStyle CssClass="item_list" />
            <RowStyle CssClass="item_list" />
        </asp:GridView>
        </div>
    </div>
</div>
