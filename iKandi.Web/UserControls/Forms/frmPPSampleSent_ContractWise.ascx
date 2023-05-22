<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmPPSampleSent_ContractWise.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.frmPPSampleSent_ContractWise" %>
<style type="text/css">
    .date_style_new
    {
        border: 1px solid #000 !important;
    }
    .date_style_new input
    {
        border: 0px !important;
        font-size: 10px !important;
        width: 100% !important;
    }
    .item_list1 th
    {
        color: #fff;
        border: 1px solid #fff;
        padding: 4px;
        font-size: 10px;
    }
    .vertical_text_new
    {
        background: #fff !important;
        border: 1px solid #666 !important;
        padding: 0px !important;
    }
    
    .vertical_header_new, .vertical_text_new
    {
        margin: 0 !important;
        padding-bottom: 10px !important;
        padding-top: 10px !important;
        text-align: center;
        vertical-align: middle;
    }
    
    .date_style_new
    {
        border: 1px solid #000000 !important;
        padding: 0px !important;
        font-size: 11px;
    }
    .top-sent
    {
        border: 1px solid #000000 !important;
    }
    .vertical_text_input
    {
        filter: none !important;
        writing-mode: lr-tb !important;
    }
    .TopSentActual
    {
        border: 1px solid #ccc;
    }
    input[type='Submit']
    {
        height: auto;
    }
</style>
<script type="text/javascript">

    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });


    });


    $(window).load(function () {

        $(".Paisley").removeClass("print");
    });
    
</script>
<script type="text/javascript" language="javascript">


    //    $(document).ready(function () {
    //        
    //        
    //    });


    function SelectApproved(elem) {
        // debugger;

        if ($(elem).is(':checked')) {
            // debugger;
            $('.isApproved').find("input[type=checkbox]").attr('checked', 'checked');
            $('.isReject').find("input[type=checkbox]").attr('checked', false);
            $('.Approved').find("input[type=checkbox]").attr('checked', 'checked');
            $('.Reject').find("input[type=checkbox]").attr('checked', false);
        }
        else {
            // debugger;           
            $('.Approved').find("input[type=checkbox]").attr('checked', false);
        }

    }

    function SelectRejected(elem) {
        // debugger;      


        if ($(elem).is(':checked')) {
            //debugger;           
            $('.isApproved').find("input[type=checkbox]").attr('checked', false);
            $('.isReject').find("input[type=checkbox]").attr('checked', 'checked');

            $('.Reject').find("input[type=checkbox]").attr('checked', 'checked');
            $('.Approved').find("input[type=checkbox]").attr('checked', false);
        }
        else {
            // debugger;           
            $('.Reject').find("input[type=checkbox]").attr('checked', false);
        }
    }

</script>
<div style="width: 310px; margin: 0 auto;">
    <div runat="server">
        <h3 style="width: 304px; background: #39589c; color: white; text-align: center; font-size: 14px;
            padding: 2px;">
            PP Sample History
        </h3>
    </div>
    <asp:GridView runat="server" ID="GridView_History" CssClass="item_list1" AutoGenerateColumns="false"
        Style="table-layout: fixed">
        <Columns>
            <asp:TemplateField HeaderText="PP Sample.">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("PPSampleStatus") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new" Width="80px" />
                <ItemStyle CssClass="vertical_text_new" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sample sent Date">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# (Convert.ToDateTime(Eval("TopSentActual")) == DateTime.MinValue)? "" : Eval("TopSentActual", "{0:dd MMM yy (ddd)}")   %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Current Status">
                <ItemTemplate>
                    <asp:Label ID="LabelLineNumber" runat="server" Text='<%# Eval("MDA") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new" Width="100px" />
                <ItemStyle CssClass="vertical_text_new" Width="100px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div class="container-detail do-not-print" style="margin: 0 auto; border: 0px; width: 1560px;">
    <div id="dvTopSection" runat="server">
        <h3 style="width: 99.8%; background: #39589c; color: white; text-align: center; font-size: 14px;
            padding: 2px;">
            PP Sample Sent
        </h3>
    </div>
    <asp:GridView runat="server" ID="grdOrderDetails" CssClass="item_list1" AutoGenerateColumns="false"
        OnRowDataBound="grdOrderDetails_RowDataBound" Style="table-layout: fixed">
        <Columns>
            <asp:TemplateField HeaderText="Serial No.">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnSerial" runat="server" />
                    <asp:HiddenField ID="hdnOrderId" Value='<%# Eval("OrderID") %>' runat="server" />
                    <asp:Label ID="Label4" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new" Width="50px" />
                <ItemStyle CssClass="vertical_text_new" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:Label ID="Label5" runat="server" Text='<%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryName  %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="60px" />
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line Item #">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hdnOrderContractID" Value='<%# Eval("OrderDetailID") %>' />
                    <asp:HiddenField runat="server" ID="hdnInlinePPMID" Value='<%# Eval("InlinePPMId") %>' />
                    <asp:Label ID="LabelLineNumber" runat="server" Text='<%# Eval("LineItemNumber") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new" Width="80px" />
                <ItemStyle CssClass="vertical_text_new" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Contract # (Quantity)
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label><br />
                    <br />
                    (<asp:Label ID="lblQuanitiy" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>)
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new" Width="80px" />
                <ItemStyle CssClass="vertical_text_new" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="lblDepartnmentName" runat="server" Text=' <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new" Width="80px" />
                <ItemStyle CssClass="vertical_text_new" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1" ItemStyle-CssClass="vertical_text_new">
                <ItemTemplate>
                    <div class="">
                        <span style="font-size: 9px; line-height: 15px">
                            <div>
                                <span runat="server" id="fabric1name" style="color: gray">
                                    <%# Eval("Fabric1")%></span>
                                <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                    :
                                    <%# Eval("Fabric1Details")%></label>
                                <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus%>
                                    )
                                </label>
                                <label style="color: gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent == 0 ) ? "hide_me": "" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>%
                                    )
                                </label>
                            </div>
                            <div>
                                <asp:Label ID="lblFabric11" runat="server" ForeColor="Black" Font-Size="Smaller"
                                    Text='<%# Eval("CCGSM1") %>' Width="72px"></asp:Label>
                            </div>
                            <div>
                                <span runat="server" id="fabric2name" style="color: gray">
                                    <%# Eval("Fabric2")%></span>
                                <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                    :
                                    <%# Eval("Fabric2Details")%></label>
                                <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus%>
                                    )
                                </label>
                                <label style="color: gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent == 0 ) ? "hide_me": "" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>%
                                    )
                                </label>
                            </div>
                            <div>
                                <asp:Label ID="lblFabric12" runat="server" ForeColor="Black" Font-Size="Smaller"
                                    Text='<%# Eval("CCGSM2")%>'></asp:Label>
                                <span runat="server" id="fabric3name" style="color: gray">
                                    <%# Eval("Fabric3")%>
                                </span>
                                <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                    :
                                    <%# Eval("Fabric3Details")%></label>
                                <br />
                                <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus%>
                                    )
                                </label>
                                <label style="color: gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent == 0 ) ? "hide_me": "" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>%
                                    )
                                </label>
                            </div>
                            <div>
                                <asp:Label ID="lblFabric13" runat="server" ForeColor="Black" Font-Size="Smaller"
                                    Text='<%# Eval("CCGSM3")%>'></asp:Label>
                            </div>
                            <div>
                                <span runat="server" id="fabric4name" style="color: gray">
                                    <%# Eval("Fabric4")%>
                                </span>
                                <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                    :
                                    <%# Eval("Fabric4Details")%></label>
                                <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus%>
                                    )
                                </label>
                                <br />
                                <label style="color: gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent == 0 ) ? "hide_me": "" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>%
                                    )
                                </label>
                            </div>
                            <div>
                                <asp:Label ID="lblFabric14" runat="server" ForeColor="Black" Font-Size="Smaller"
                                    Text='<%# Eval("CCGSM4")%>'></asp:Label>
                            </div>
                             <div>
                                <span runat="server" id="Span1" style="color: gray">
                                    <%# Eval("Fabric5")%>
                                </span>
                                <label class="<%#(Eval("Fabric5Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                    :
                                    <%# Eval("Fabric5Details")%></label>
                                <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F9BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F9BulkStatus%>
                                    )
                                </label>
                                <br />
                                <label style="color: gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric5Percent == 0 ) ? "hide_me": "" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric5Percent %>%
                                    )
                                </label>
                            </div>
                            <div>
                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Size="Smaller"
                                    Text='<%# Eval("CCGSM5")%>'></asp:Label>
                            </div>
                             <div>
                                <span runat="server" id="Span2" style="color: gray">
                                    <%# Eval("Fabric6")%>
                                </span>
                                <label class="<%#(Eval("Fabric6Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                    :
                                    <%# Eval("Fabric6Details")%></label>
                                <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F10BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F10BulkStatus%>
                                    )
                                </label>
                                <br />
                                <label style="color: gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric6Percent == 0 ) ? "hide_me": "" %>">
                                    (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric6Percent %>%
                                    )
                                </label>
                            </div>
                            <div>
                                <asp:Label ID="Label2" runat="server" ForeColor="Black" Font-Size="Smaller"
                                    Text='<%# Eval("CCGSM6")%>'></asp:Label>
                            </div>
                        </span>
                    </div>
                </ItemTemplate>
                <HeaderStyle Width="250px" />
                <ItemStyle Width="250px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Inline Cut Dt.">
                <ItemTemplate>
                    <asp:Label ID="Label31" runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).Style.InLineCutDate) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).Style.InLineCutDate.ToString("dd MMM yy (ddd)")  %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new top-sent" Width="95px" />
                <ItemStyle CssClass="vertical_text_new date_style_new" Width="95px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PP Sample TGT.">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtTopSentTarget" Text='<%#(Convert.ToDateTime(Eval("TopSentTarget")) == DateTime.MinValue)? "" : Eval("TopSentTarget", "{0:dd MMM yy (ddd)}")     %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new top-sent" Width="95px" />
                <ItemStyle CssClass="date_style_new" Width="95px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PP Sample ACT.">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtTopSentActual" Style="border: 1px solid #000 !important;
                        width: 90% !important;" Text='<%# (Convert.ToDateTime(Eval("TopSentActual")) == DateTime.MinValue)? "" : Eval("TopSentActual", "{0:dd MMM yy (ddd)}")   %>'></asp:TextBox>
                    <asp:HiddenField ID="hdnFabTab" runat="server" Value="" />
                    <asp:HiddenField ID="hdnDetTab" runat="server" Value='<%# (Eval("DetailClass")) %>' />
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <ItemStyle CssClass="date_style_new" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <HeaderTemplate>
                    <asp:CheckBox ID="HeaderApproved" Text="Approved" CssClass="isApproved" OnClick="javascript:SelectApproved(this)"
                        runat="server" /></br>
                    <asp:CheckBox ID="HeaderRejected" Text="Rejected" OnClick="javascript:SelectRejected(this)"
                        CssClass="isReject" runat="server" />
                </HeaderTemplate>
                <HeaderStyle Width="90px" />
                <ItemTemplate>
                    <div style="text-align: left;">
                        <asp:CheckBox ID="chkApproved" Text="Approved" CssClass="Approved" Checked='<%# ((iKandi.Common.TopStatusType)Convert.ToInt32(Eval("TopStatus")) == iKandi.Common.TopStatusType.APPROVED) ? true : false  %>'
                            runat="server" />
                    </div>
                    <div style="text-align: left;">
                        <asp:CheckBox ID="chkRejected" Text="Rejected" CssClass="Reject" Checked='<%# ((iKandi.Common.TopStatusType)Convert.ToInt32(Eval("TopStatus")) == iKandi.Common.TopStatusType.REJECTED) ? true : false  %>'
                            runat="server" />
                    </div>
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cycle">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlPattern" ForeColor="Black" Width="95px" runat="server">
                        <asp:ListItem Text="PP Sample 1"></asp:ListItem>
                        <asp:ListItem Text="PP Sample 2"></asp:ListItem>
                        <asp:ListItem Text="PP Sample 3"></asp:ListItem>
                        <asp:ListItem Text="PP Sample 4"></asp:ListItem>
                        <asp:ListItem Text="PP Sample Done"></asp:ListItem>
                    </asp:DropDownList>
                     <asp:HiddenField ID="hdnPPSample" runat="server" />
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new top-sent" Width="100px" />
                <ItemStyle CssClass="date_style_new" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MDA #">
                <ItemTemplate>
                    <asp:Label runat="server" CssClass="vertical_style_input" ID="lblMDA" Text='<%# Eval("MDA") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="vertical_header_new" Width="100px" />
                <ItemStyle CssClass="vertical_text_new" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BIPL Upload">
                <ItemTemplate>
                    <a target="_blank" href='<%# ResolveUrl("~/uploads/InlinePPM.Docs/" + Eval("BIPLUploadFile").ToString()) %>'
                        class="<%# (Eval("BIPLUploadFile") == null || string.IsNullOrEmpty(Eval("BIPLUploadFile").ToString()) ) ? "hide_me": "" %>">
                        View File </a>
                    <br />
                    <asp:FileUpload CssClass="inline_ppm_uplode_style" Width="60px" Style="font-size: 9PX;"
                        runat="server" ID="fileBIPLUpload" />
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BIPL Comments">
                <ItemTemplate>
                    <asp:TextBox TextMode="MultiLine" Rows="5" cols="20" Style="width: 95%; margin: 0PX AUTO;"
                        CssClass="remarks_text remarks_text2" runat="server" ID="txtBIPLComments" Text='<%# Bind("BIPLComments") %>'></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="80px" />
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Upload" ItemStyle-Width="100px">
                <ItemTemplate>
                    <a target="_blank" href='<%# ResolveUrl("~/uploads/InlinePPM.Docs/" + Eval("iKandiUploadFile").ToString()) %>'
                        class="<%# (Eval("iKandiUploadFile") == null || string.IsNullOrEmpty(Eval("iKandiUploadFile").ToString()) ) ? "hide_me": "" %>">
                        View File </a>
                    <asp:FileUpload runat="server" Width="60px" Style="font-size: 9PX;" CssClass="inline_ppm_uplode_style"
                        ID="fileiKandiUpload" />
                </ItemTemplate>
                <ItemStyle Width="90px" />
                <HeaderStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox TextMode="MultiLine" Rows="5" cols="20" CssClass="remarks_text remarks_text2"
                        runat="server" ID="txtiKandiComments" Width="96%" Text='<%# Bind("iKandiComments") %>'></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="100px" />
                <HeaderStyle Width="100px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <div class="form_buttom" style="float: left;">
        <asp:Button ID="btnTopSubmit" CssClass="submit" runat="server" Text="Submit" OnClick="btnTopSubmit_Click" />
    </div>
    <div style="clear: both">
    </div>
</div>
