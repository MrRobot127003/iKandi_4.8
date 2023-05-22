<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InlineTopSection.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.InlineTopSection" %>

<style type="text/css">
.date_style_new
{
  
    
}
.date_style_new input
{
    border:0px !important;
    font-size:10px !important;
    width:90% !important;   
}

.vertical_text_new 
{
    background:#fff !important;
    padding:0px !important;
    
}

.vertical_header_new , .vertical_text_new
{
  margin: 0 !important;
    padding-bottom: 10px !important;
    padding-top: 10px !important;
    text-align: center;
    vertical-align: middle;
      
}

.date_style_new
{
   
     padding:0px !important;
     font-size:11px;
}
.top-sent
{
    
} 
.vertical_text_input
{
    filter:none !important;
    writing-mode:lr-tb !important;
}
.TopSentActual{
border:1px solid #ccc;
}
input[type='Submit']
{
    height:auto;
}
textarea
{
    width:90% !important

 }
 .InlineInnerTable
 {
     width:100%;
  }
 .InlineInnerTable td
 {
    padding: 0px 5px;
    border-left: 0px;
    border-right: 0px;
    text-align: left;
    line-height: 15px;

  }
  .AddClass_Table td input[type='file']
    {
        height:16px !important
    }
  .AddClass_Table td
  {
    padding-bottom: 5px !important;
    padding-top: 5px !important;   
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

<div class="container-detail do-not-print" style="border:0px;padding:0px 0px">
<div id="dvTopSection" runat="server">
    <h3 style="width: 100%; min-width: 1340px !important; background:#39589c; color:white; text-align:center; font-size:14px; padding:2px 0px;">
        TOP SECTION
    </h3>
</div>
        <asp:GridView runat="server" ID="grdOrderDetails" CssClass="AddClass_Table" AutoGenerateColumns="false"
            onrowdatabound="grdOrderDetails_RowDataBound" style="table-layout: fixed;width:100%;">
            <columns>
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
                                <HeaderStyle CssClass="vertical_header_new" Width="90" />
                                <ItemStyle CssClass="vertical_text_new" Width="90" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <HeaderTemplate>
                            Contract # (Quantity)
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label><br /><br />
                                    (<asp:Label ID="lblQuanitiy" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>)
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header_new" Width="105" />
                                <ItemStyle CssClass="vertical_text_new" Width="105" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartnmentName" runat="server" Text=' <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header_new" Width="80px" />
                                <ItemStyle CssClass="vertical_text_new" Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1" 
                                 ItemStyle-CssClass="vertical_text_new">
                                <ItemTemplate>
                                   <table border="0" cellpadding="0" cellspacing="0" class="InlineInnerTable">
                                      <tr id="Fab1" runat="server">
                                        <td style="border-top:0px;">
                                            <asp:Label runat="server" ID="fabric1name" style="color:gray" Text='<%# Eval("Fabric1") %>' ></asp:Label>
                                             <asp:Label ID="lblFabric11" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM1") %>' Width="72px"></asp:Label><br />
                                            <label id="lblFabDetails1" class="<%#(Eval("Fabric1Details").ToString().Trim() == "" ) ? "hide_me": "" %>"> <%# Eval("Fabric1Details")%></label>
                                            <label style="color:gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent == 0 ) ? "hide_me": "" %>"> (<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>%) </label>
                                         </td>
                                      </tr>
                                       <tr  id="Fab2" runat="server">
                                         <td style="border-bottom:0px;">
                                                <asp:Label runat="server" ID="fabric2name" style="color:gray" Text='<%# Eval("Fabric2") %>' ></asp:Label>
                                                 <asp:Label ID="lblFabric12" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM2")%>'></asp:Label>  <br />
                                               <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" ) ? "hide_me": "" %>">  <%# Eval("Fabric2Details")%></label>
                                               <label style="color:gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent == 0 ) ? "hide_me": "" %>">(<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>%)</label>
                                          </td>
                                      </tr>
                                       <tr id="Fab3" runat="server">
                                        <td style="border-bottom:0px;">
                                             <asp:Label  runat="server" ID="fabric3name" style="color:gray" Text='<%# Eval("Fabric3")%>'></asp:Label>
                                             <asp:Label ID="lblFabric13" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM3")%>'></asp:Label>  <br />
                                            <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" ) ? "hide_me": "" %>">  <%# Eval("Fabric3Details")%></label>
                                             <label style="color:gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent == 0 ) ? "hide_me": "" %>">(<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>%)</label>
                                        </td>
                                      </tr>
                                       <tr id="Fab4" runat="server">
                                        <td style="border-bottom:0px;">
                                              <asp:Label  runat="server" ID="fabric4name" style="color:gray" Text='<%# Eval("Fabric4")%>'></asp:Label>
                                             <asp:Label ID="lblFabric14" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM4")%>'></asp:Label><br /> 
                                             <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" ) ? "hide_me": "" %>">  <%# Eval("Fabric4Details")%></label>
                                             <label style="color:gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent == 0 ) ? "hide_me": "" %>">(<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>% ) </label>
                                          </td>
                                      </tr>
                                      <tr id="Fab5" runat="server">
                                          <td style="border-bottom:0px;">
                                                <asp:Label  runat="server" ID="fabric5name" style="color:gray" Text='<%# Eval("Fabric5")%>'></asp:Label>
                                                <asp:Label ID="lblFabric15" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM5")%>'></asp:Label>  <br/>
                                               <label class="<%#(Eval("Fabric5Details").ToString().Trim() == "" ) ? "hide_me": "" %>">  <%# Eval("Fabric5Details")%></label>
                                               <label style="color:gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric5Percent == 0 ) ? "hide_me": "" %>">(<%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric5Percent %>%)</label>
                                          </td>
                                      </tr>
                                       <tr id="Fab6" runat="server">
                                          <td style="border-bottom:0px;">
                                               <asp:Label  runat="server" ID="fabric6name" style="color:gray" Text='<%# Eval("Fabric6")%>'></asp:Label>
                                               <asp:Label ID="lblFabric16" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM6")%>'></asp:Label>  <br />
                                              <label class="<%#(Eval("Fabric6Details").ToString().Trim() == "" ) ? "hide_me": "" %>">  <%# Eval("Fabric6Details")%></label>
                                               <label style="color:gray" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric6Percent == 0 ) ? "hide_me": "" %>">
                                                 (
                                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric6Percent %>%
                                                    )
                                                </label>
                                          </td>
                                      </tr>
                                   </table>
                               
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
                            <asp:TemplateField HeaderText="Top Sent TGT.">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtTopSentTarget"  Text='<%#(Convert.ToDateTime(Eval("TopSentTarget")) == DateTime.MinValue)? "" : Eval("TopSentTarget", "{0:dd MMM yy (ddd)}")     %>'
                                        ></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header_new top-sent" Width="95px" />
                                <ItemStyle CssClass="date_style_new" Width="95px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Top Sent ACT." >
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtTopSentActual" style="border: 1px solid #999 !important;width:90% !important;"   Text='<%# (Convert.ToDateTime(Eval("TopSentActual")) == DateTime.MinValue)? "" : Eval("TopSentActual", "{0:dd MMM yy (ddd)}")   %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnFabTab" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnDetTab" runat="server" Value='<%# (Eval("DetailClass")) %>' />
                                </ItemTemplate>
                                <HeaderStyle  Width="100px" />
                                <ItemStyle CssClass="date_style_new" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                            <HeaderTemplate>
                                <asp:CheckBox ID="HeaderApproved" Text="Approved" CssClass="isApproved" OnClick="javascript:SelectApproved(this)" runat="server" /></br>
                                <asp:CheckBox ID="HeaderRejected" Text="Rejected" OnClick="javascript:SelectRejected(this)" CssClass="isReject" runat="server" />
                              
                            </HeaderTemplate>
                            <HeaderStyle Width="90px" />
                                <ItemTemplate>
                                    <div style="text-align:left;">
                                        <asp:CheckBox ID="chkApproved" Text="Approved" CssClass="Approved" Checked='<%# ((iKandi.Common.TopStatusType)Convert.ToInt32(Eval("TopStatus")) == iKandi.Common.TopStatusType.APPROVED) ? true : false  %>' runat="server" />
                                  
                                        </div>
                                        <div style="text-align:left;">  
                                        <asp:CheckBox ID="chkRejected" Text="Rejected" CssClass="Reject" Checked='<%# ((iKandi.Common.TopStatusType)Convert.ToInt32(Eval("TopStatus")) == iKandi.Common.TopStatusType.REJECTED) ? true : false  %>' runat="server" /> 
                                      
                                        </div>
 
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Top ACT. Appvl/Rej.">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtTopActualApproval" style="border: 1px solid #999 !important;width:90% !important;" CssClass="th date_style_new " Text='<%# (Convert.ToDateTime(Eval("TopActualApproval")) == DateTime.MinValue)? "" : Eval("TopActualApproval", "{0:dd MMM yy (ddd)}")  %>'></asp:TextBox>
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
                                    <asp:FileUpload CssClass="inline_ppm_uplode_style" Width="60px"  style="Font-Size:9PX;" runat="server" ID="fileBIPLUpload" />
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIPL Comments">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="5" cols="20" style="width:95%; margin:0PX AUTO;" CssClass="remarks_text remarks_text2"
                                        runat="server" ID="txtBIPLComments" Text='<%# Bind("BIPLComments") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                                <HeaderStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Upload" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <a target="_blank" href='<%# ResolveUrl("~/uploads/InlinePPM.Docs/" + Eval("iKandiUploadFile").ToString()) %>'
                                        class="<%# (Eval("iKandiUploadFile") == null || string.IsNullOrEmpty(Eval("iKandiUploadFile").ToString()) ) ? "hide_me": "" %>">
                                        View File </a>
                                    <asp:FileUpload runat="server" Width="60px" style="Font-Size:9PX;" CssClass="inline_ppm_uplode_style" ID="fileiKandiUpload" />
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                                <HeaderStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="5" cols="20" CssClass="remarks_text remarks_text2"
                                        runat="server" ID="txtiKandiComments" Text='<%# Bind("iKandiComments") %>'></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                        </columns>
        </asp:GridView>

 
    <div class="form_buttom" style="float: left;margin-top:7px;">
        <asp:Button ID="btnTopSubmit" CssClass="submit" runat="server" Text="Submit" onclick="btnTopSubmit_Click" />
    </div>
    <div style="clear: both">
    </div>
            </div>
     <%--       <link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />
<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>--%>

