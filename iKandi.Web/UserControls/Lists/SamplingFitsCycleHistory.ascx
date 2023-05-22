<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SamplingFitsCycleHistory.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.SamplingFitsCycleHistory" %>
<style type="text/css">
    body {
        font-family: verdana;
        font-size: 10px;
    }
    table {
        font-family: arial, halvetica;
        border-color: gray;
        border-collapse: collapse;
    }
    .item_list TD {
        text-align: center;
        border: 1px solid #b7b4b4;
        padding: 4px 0px !important;
        background-color: none !important;
        text-transform: capitalize;
    }
    .foo-back {
        background: #f5f2f1;
    }
    .gray {
        color: gray;
    }
    input {
        height: 18px;
    }
    .blank-item {
        color: gray;
    }
    select {
        font-size: 11px;
        width: 80%;
        border: 1px solid gray;
    }
    textarea {
        width: 70%;
    }
    .F8 {
        font-size: 10px;
    }
    .pagination table td {
        padding: 5px !important;
    }
    select {
        text-transform: capitalize;
    }
    .cellback td {
        background: #f2f2f2 !important;
    }
    .cellback .white {
        background: white !important;
    }
    .cellback select {
        background: #f2f2f2 !important;
    }
    .CommentStyle {
        text-align: left;
    }
    .show-div {
        background: #fff;
        border-radius: 5px;
        display: none;
    }
    .Hide {
        display: none;
    }
    .chkIsQc input {
        margin: 0px;
        padding: 0px;
    }
    input[type='checkbox'] {
        vertical-align: middle;
        margin: 0px;
        padding: 0px;
    }
    .fll {
        float: left;
        width: 59%;
        height: 19px;
    }
    .flr {
        float: left;
        width: 40%;
    }
    .flln {
        width: 52%;
        float: left;
        text-align: left;
        height: 19px;
        padding: 0px 4px;
    }
    .fllr {
        float: right;
        text-align: center;
        width: 42%;
    }
    .cellback div {
        margin: 0px !important;
    }
    .h19 {
        height: 19px;
    }
    .mar-remove div {
        margin: 0px !important;
    }
    .item_list TD table td {
        border: 0px;
    }
    .item_list TD:first-child {
        border-left-color: #a9a4a4 !important;
    }
    .item_list TD:last-child {
        border-right-color: #a9a4a4 !important;
    }
    .item_list tr:last-child > td {
        border-bottom-color: #d2cfcf !important;
    }
    .item_list TD .innerTable td {
        border: 0px !important;
    }
    .Headertext {
        background: #3a5795;
        padding: 5px 0px;
        color: #fff;
        margin: 0px;
        margin: 0px;
        font-family: Arial;
        font-size: 14px;
        text-align: center;
        width: 640px;
    }
    /*Add css 1-mar*/
    .image_top {
        height: 15px;
        position: relative;
        top: 2px;
        border-radius: 3px;
    }
    .da_submit_button {
        border-radius: 2px;
        height: 24px;
    }
</style>
<div>
    <table class="fixed-header item_list bipl-sec" rules="all" style="border-collapse: collapse; width: 1040px" cellspacing="0" border="1">
        <tbody>
            <tr>
                <th scope="col" style="width: 150px;">
                    Client
                    <br />
                    Department
                </th>
                <th style="width: 100px;">
                    <asp:Label runat="server" ID="lblAMHead" Text="AM"> </asp:Label>
                    <asp:Label runat="server" ID="lblPDMHead" Text="PD Manager"> </asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lblPRDMHead" Text="Prod. Merch."> </asp:Label>
                    <asp:Label runat="server" ID="lblPDHead" Text="PD. Merch"> </asp:Label>
                </th>
                <th scope="col" style="width: 100px;">
                    St. Number
                </th>
                <th scope="col" style="width: 200px;">
                    Fabric 1
                </th>
                <th scope="col" style="width: 100px;">
                    Color/Print
                </th>
                <th scope="col" style="width: 30px;">
                    Thumbnail
                </th>
                <%--  <th scope="col" style="width:180px;"><span style="width:170px;"></span></th>--%>
                <th scope="col" style="width: 120px;">
                    STC Target
                </th>
            </tr>
            <tr>
                <td valign="top">
                    <div style="width: 100%; border-bottom: 1px solid #e5e1e1;" class="h19 gray">
                        <asp:Label ID="lblClient" ForeColor="Gray" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                        <asp:HiddenField ID="hdnClientId" Value='<%# Eval("ClientId") %>' runat="server"></asp:HiddenField>
                    </div>
                    <div style="padding-top: 5px;">
                        <asp:HiddenField ID="hdnClientDeptid" Value='<%# Eval("ClientDeptid") %>' runat="server"></asp:HiddenField>
                        <asp:Label ID="lblDepartment" runat="server" ForeColor="Gray" Text='<%# Eval("DeptName") %>'></asp:Label>
                    </div>
                </td>
                <td valign="top">
                    <div style="border-bottom: 1px solid #e5e1e1;" class="h19">
                        <asp:Label ID="lblAM" runat="server" Text="" ForeColor="Gray"></asp:Label>
                    </div>
                    <asp:Label ID="lblPDM" runat="server" Text="" ForeColor="Gray"></asp:Label>
                </td>
                <td>
                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("Styleid") %>' runat="server" />
                    <asp:HiddenField ID="hdnIsIkandiClient" Value='<%# Eval("IsIkandiClient") %>' runat="server" />
                    <asp:HiddenField ID="hdnFitsType" Value='<%# Eval("FitsType") %>' runat="server" />
                    <asp:HiddenField ID="hdnIsOrderExist" Value='<%# Eval("IsOrderExist") %>' runat="server" />
                    <asp:Label ID="lblStyleNo" runat="server" ForeColor="Black" Font-Bold="true" Text='<%# Eval("StyleNumber") %>'></asp:Label>
                    <asp:Label ID="lblCreation_FitsDate" ForeColor="Gray" runat="server" Text="" Style="display: none;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFabric1" ForeColor="gray" runat="server" Text='<%# Eval("Fabric") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblColorPrint" runat="server" ForeColor="Gray" Text='<%# Eval("FabricDetails") %>'></asp:Label>
                </td>
                <td style="height: 60px; width: 60px;">
                    <asp:Image ID="ImgStyle" Width="98%" Height="98%" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblSTCTargetDate" Font-Bold="true" ForeColor="Black" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <asp:GridView runat="server" ID="gvSamplingFitsCycleHistory" RowStyle-ForeColor="Gray" CssClass="item_list" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="1040px" OnRowDataBound="gvSamplingFitsCycleHistory_RowDataBound">
        <PagerStyle CssClass="pagination" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px">
                <HeaderTemplate>
                    Type<%--<br />
                        Is QC Present- QC Name--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="h19">
                        <asp:Label ID="lblStatus" Font-Bold="true" ForeColor="Black" Font-Size="16px" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                    </div>
                    <%--<div style="width:100%;padding-top:1px; padding-bottom:2px;" class="gray F8 h19">--%>
                    <%--<asp:CheckBox ID="ChkIsQC" runat="server" style="padding:0px; display:none; margin:0px;"></asp:CheckBox>  
                             <asp:HiddenField ID="hdnMasterQCId" Value='<%# Eval("QCMasterId") %>' runat="server"></asp:HiddenField>
                                <asp:Label ID="lblQC" runat="server" Text=""></asp:Label>  --%>
                    <%-- </div>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="mar-remove" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Is QC Present- QC Name">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkIsQC" runat="server" Style="padding: 0px; display: none; margin: 0px;"></asp:CheckBox>
                    <asp:HiddenField ID="hdnMasterQCId" Value='<%# Eval("QCMasterId") %>' runat="server"></asp:HiddenField>
                    <asp:Label ID="lblQC" runat="server" Text=""></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="gray F8" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" Visible="false">
                <HeaderTemplate>
                    AM / PD Manager<br />
                    Prod. Merch. / PD
                </HeaderTemplate>
                <ItemTemplate>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="cellback" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="300px" Visible="false">
                <HeaderTemplate>
                    Fits Comm. For, Req. For<br />
                    Req. Ref. Sample, Upload Comm.
                </HeaderTemplate>
                <ItemTemplate>
                    <div id="dvFits" runat="server">
                        <div style="border-bottom: 1px solid #b7b4b4;" class="h19">
                            <asp:Label ID="lblFitsCommentSent" runat="server" Text=""></asp:Label>&nbsp;
                            <asp:Label ID="lblFitsRequest" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div style="text-align: center; margin-top: 20px;" id="dvSampling" runat="server">
                    </div>
                </ItemTemplate>
                <ItemStyle VerticalAlign="top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="165px" Visible="false">
                <HeaderTemplate>
                    Fit Comm. Act, ETA
                    <br />
                    Sample Sent
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="h19">
                        <asp:Label ID="lblSampleSentDate" Font-Bold="true" ForeColor="Black" runat="server" Text=""></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="65px">
                <HeaderTemplate>
                    Handover Dt.
                    <%--ETA --%>
                    <%--<br />  --%>
                    <%--Act.--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="F8 gray h19" style="width: 100%; border-bottom: 1px solid #b7b4b4; display: none;">
                        <strong>
                            <asp:Label ID="lblHandoverEta" runat="server" Text="" Font-Bold="true"></asp:Label></strong>
                    </div>
                    <%-- <div style="width:100%;" class="gray f8">--%>
                    <div style="width: 20%; float: left; display: none;">
                        <asp:CheckBox ID="ChkHandover" runat="server"></asp:CheckBox>
                    </div>
                    <%--<div class="gray" style="float:left; width:75%;color:green">--%>
                    <span class="F8" style="color: black">
                        <asp:Label ID="lblHandoverActDate" runat="server" Text=""></asp:Label>
                    </span>
                    <%-- </div>--%>
                    <%--<div style="clear:both;"></div>--%>
                    <%-- </div>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="97px">
                <HeaderTemplate>
                    Pattern Rdy Dt.<%--ETA<br />  Act.--%><br />
                    (Remake Count)
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" class="innerTable" cellspacing="0" border="0px" style="width: 99%">
                        <tr>
                            <td style="width: 44px;">
                                <%-- <div style="width: 100%; border-bottom: 1px solid #b7b4b4; display: none;" class="h19">--%>
                                <asp:Label ID="lblPatternEta" runat="server" Style="display: none;" Text=""></asp:Label></span>
                                <%-- </div>--%>
                                <asp:Label ID="lblPatternActDate" runat="server" Text="" ForeColor="Black"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <%--  <div style="width: 20%; float: left; display: none;">--%>
                                <asp:CheckBox ID="ChkPattern" Style="display: none;" runat="server"></asp:CheckBox>
                                <%-- </div>--%>
                                <a onclick="javascript:return CallCadRolePopup('<%# Eval("Status") %>');" class="coutns" href="#">Remake
                                    <%# Eval("RemakeCount") %>
                                </a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" Width="97px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="110px">
                <HeaderTemplate>
                    Sample Sent Dt.
                    <%--ETA--%>,Stc Appr., Fits File
                    <%--<br />--%>
                    <%--Act. , Stc Appr.--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="gray h19">
                        <asp:Label ID="lblSampleEta" runat="server" Text="" Style="display: none;"></asp:Label>
                        <div style="width: 50%; float: left;">
                            <asp:CheckBox ID="ChkSample" runat="server" Style="float: left; padding: 0px 2px; display: none;"></asp:CheckBox>
                            <asp:Label ID="lblSampleActDate" runat="server" Text="" Style="color: black"></asp:Label>
                        </div>
                        <div style="width: 43%; float: right;">
                            <asp:CheckBox ID="chkStcApproved" Visible="false" runat="server" Style="float: left; padding-right: 5px; width: auto;"></asp:CheckBox>
                            <asp:HyperLink ID="hlkSampleUpload" runat="server" Visible="false" Target="_blank" Style="float: left; padding-right: 5px; width: auto;"> <img src="../../images/view-icon.png" class="image_top" /> </asp:HyperLink>
                            &nbsp;
                            <asp:HyperLink ID="hlkSampleUploadNew" runat="server" Visible="false" Target="_blank" Style="float: right; padding-right: 5px; width: auto;"> <img src="../../images/view-icon.png" class="image_top" /> </asp:HyperLink>
                        </div>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="105px">
                <HeaderTemplate>
                    Ref Req., Fits Comm. Upload, Dt.
                    <%--ETA<br />
                      Act--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="h19">
                        <div style="width: 45%; float: right; text-align: left;">
                            <asp:CheckBox ID="ChkRefSample" Enabled="false" runat="server" Style="float: left; padding-right: 5px; width: auto;"></asp:CheckBox>
                            &nbsp;
                            <asp:HyperLink ID="hlkFitsUpload" runat="server" Visible="false" Target="_blank" Style="float: left; padding-right: 5px; width: auto;"> <img src="../../images/view-icon.png" class="image_top" /> </asp:HyperLink>
                            <asp:HyperLink ID="hlkFitsUploadNew" runat="server" Visible="false" Target="_blank" Style="float: right; padding-right: 5px; width: auto;"> <img src="../../images/view-icon.png" class="image_top" /> </asp:HyperLink>
                        </div>
                        <div style="float: left; width: 50%; text-align: center;">
                            <asp:Label ID="lblFitsEta" runat="server" Text="" Style="display: none;"></asp:Label>
                            <asp:Label ID="lblFitsActDate" ForeColor="black" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="cellback" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-Width="90px" HeaderText="Fit Cycle time">
                <HeaderTemplate>
                    Fit Cycle time
                    <br />
                    Days (Week)
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="text-align: center;">
                        <asp:Label ID="lblFitCycleTime" Font-Size="11px" runat="server" Text="" ForeColor="Black"></asp:Label></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="170px" HeaderStyle-Width="170px" HeaderText="Comment">
                <ItemTemplate>
                    <div style="text-align: left;">
                        <asp:Label ID="lblComment" Font-Size="10px" runat="server" Text=""></asp:Label></div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:HyperLink ID="hlnkflow" Visible="false" Target="_blank" CssClass="addClass" runat="server">Go to Sampling Fits Cycle</asp:HyperLink>
    <br />
    <asp:HyperLink ID="hLinkTOPSent" Visible="false" Target="_blank" CssClass="TOPClass" runat="server">Go to TOP Cycle</asp:HyperLink>
    <asp:HiddenField ID="hdnStyleId" runat="server" />
    <asp:HiddenField ID="hdnPPStatus" runat="server" />
    <asp:HiddenField ID="hdnOrderDetailID" runat="server" />
    &nbsp;
    <br />
    <input type="button" id="btnPrint" class="da_submit_button" value="Print" style="height: 24px" onclick="return PrintManageOrderPDF();" />
</div>
<br />
<div id="divpattern" runat="server">
    <h1 class="Headertext" style="margin-bottom: 5px;">
        Ref/Production pattern after STC(Before 20% pcs. cut)</h1>
    <asp:GridView runat="server" ID="grdsamplebefore" RowStyle-ForeColor="Gray" CssClass="item_list" AutoGenerateColumns="false" Enabled="false" AllowPaging="true" Width="640px" OnRowDataBound="grdsamplebefore_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="10px" HeaderText="Request pattern/sample">
                <ItemTemplate>
                    <asp:Label ID="lblReuestSample" runat="server" Text='<%# Eval("ReqSample") %>'></asp:Label>
                    <asp:HiddenField ID="hdnrequestsample" runat="server" Value='<%# Eval("ReqSample") %>' />
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" CssClass="mar-remove" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="HandOver Actual Date">
                <ItemTemplate>
                    <asp:Label ID="lblHandOverDate" Text='<%# Eval("HandOverActualDate") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="gray F8" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Pattern Ready Actual Date">
                <ItemTemplate>
                    <asp:Label ID="lblPatternReady" Text='<%# Eval("PatternReadyActualDate") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="gray F8" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Sample Sent Actual Date">
                <ItemTemplate>
                    <asp:Label ID="lblSampleSent" Text='<%# Eval("SampleSentActualDate") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="gray F8" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:HyperLink ID="hyplnkEditRequestSample" Target="_blank" CssClass="ReuestSample" runat="server">Go to Request sample Fits Cycle</asp:HyperLink>
    <asp:Button ID="btnsubmit" Text="Submit" Visible="false" runat="server" CssClass="submit" OnClick="btnsubmit_Click" />
</div>
<script type="text/javascript">
    $(document).ready(function () {
        //debugger;
        var StyleId = $('#<%= hdnStyleId.ClientID %>').val();
        var OrderDetailID = $('#<%= hdnOrderDetailID.ClientID %>').val();
        var PPStatus = $('#<%= hdnPPStatus.ClientID %>').val();
        if (PPStatus == 1) {
            $(".addClass").attr("href", "../../Admin/FitsSample/frmPPSampleSent.aspx?OrderDetailID=" + OrderDetailID);
            $(".TOPClass").attr("href", "../../Admin/FitsSample/SamplingFitsCycleFlow.aspx?StyleId=" + StyleId);
            return false;
        }
        else {
            $(".addClass").attr("href", "../../Admin/FitsSample/SamplingFitsCycleFlow.aspx?StyleId=" + StyleId);
            $(".ReuestSample").attr("href", "../../Admin/FitsSample/SamplingFitsCyclePopUp.aspx?StyleId=" + StyleId);
            return false;
        }
    });
    function Call() {
        debugger;
        //PageMethods.MyMethod("Paul Hayman");
        $("#ctl01_btnsubmit").click()
    }
    function CallCadRolePopup(status) {
        debugger;
        var IsTopMangemnt = '<%=this.TopDesignation %>';
        var UserId = '<%=this.UserId %>';
        //alert(status);
        if (IsTopMangemnt == "1" || UserId == "688") {
            var StyleId = $('#<%= hdnStyleId.ClientID %>').val();
            var url = '../../Admin/FitsSample/frmCadRoleAdmin.aspx?styleid=' + StyleId + '&flagvalue=' + 2 + '&Status=' + status;
            window.open(url, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=500,left=500,width=500,height=300");
        }
    }
</script>
