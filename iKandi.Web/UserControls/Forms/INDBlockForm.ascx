<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="INDBlockForm.ascx.cs" Inherits="iKandi.Web.INDBlockForm" %>
<asp:Panel runat="server" ID="pnlForm">

    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var jscriptPageVariables = null;
        $(function () {
            $("input.brand-company", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestBrandCompany", { dataType: "xml", datakey: "string", max: 100 });
            $("input.brand-company-ref", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestBrandCompanyRef", { dataType: "xml", datakey: "string", max: 100 });

        });
    </script>

    <div class="print-box">
        <div class="client_form">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
     
        <td width="1205" class="header-text-back"><span class="da_h1">IND Block Form</span><span class="da_required_field">( <span class="da_astrx_mand">*</span> Please fill all required fields)</span></td>
        
      </tr>
    </table>

    </td>
  </tr>
  <tr>
    <td class="tbl_bordr">
    

    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
      <tr>
        <td width="80%">
          
          <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin:0px;">
            <tr class="td-sub_headings">
              <td width="14%" valign="bottom">Block Number <span class="da_astrx_mand">*</span></td>
              <td width="14%" valign="bottom">Brand</td>
              <td width="14%" valign="bottom">Reference</td>
              <td width="14%" valign="bottom">Date Purchased <span class="da_astrx_mand">*</span></td>
              <td width="14%" valign="bottom">Buyer</td>
              <td width="14%" valign="bottom">Designer</td>
              <td width="12%" valign="bottom">Block Cost <span class="da_astrx_mand">*</span></td>
              </tr>
            <tr>
              <td class="inner_tbl_td"><asp:TextBox runat="server" ID="txtBlockNumber" Width="109px" CssClass="input_in" ReadOnly="True" class="numeric-field-without-decimal-places" MaxLength="18"></asp:TextBox>
                            <div class="form_error da_error_msg">
                                <asp:RequiredFieldValidator ID="rfv_txtPrintNumber" runat="server" Display="Dynamic"
                                    ControlToValidate="txtBlockNumber" ErrorMessage="Block Number is required"></asp:RequiredFieldValidator>
                            </div></td>
              <td class="inner_tbl_td"><asp:TextBox runat="server" ID="txtBrand" CssClass="brand-company input_in" MaxLength="48"></asp:TextBox></td>
              <td class="inner_tbl_td"><asp:TextBox runat="server" ID="txtReference" CssClass="brand-company-ref input_in" MaxLength="9"></asp:TextBox></td>
              <td class="inner_tbl_td"><asp:TextBox runat="server" ID="txtDate" CssClass="date-picker date_style input_in"></asp:TextBox></td>
              <td class="inner_tbl_td"> <asp:DropDownList ID="ddlClient" CssClass="input_in" runat="server" Width="145px">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList></td>
              <td class="inner_tbl_td">
                 <asp:DropDownList ID="ddlDesigner" runat="server" CssClass="input_in" Width="145px">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
             </td>
              <td class="inner_tbl_td"><asp:DropDownList ID="ddlCurrency" runat="server" Width="38px">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                             <asp:TextBox runat="server" ID="txtBlockCost" CssClass="numeric-field-with-two-decimal-places" MaxLength="10" Width="60"></asp:TextBox>
                            <div class="form_error da_error_msg">
                                <asp:RequiredFieldValidator ID="rfv_txtBlockCost" runat="server" Display="Dynamic"
                                    ControlToValidate="txtBlockCost" ErrorMessage="Block Cost is required"></asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="rfv_ddlCurrency" runat="server" Display="Dynamic"
                                    ControlToValidate="ddlCurrency" InitialValue="-1" ErrorMessage="Select currency"></asp:RequiredFieldValidator>
                            </div>
        </td>
              </tr>
            <tr class="td-sub_headings">
              <td>Description <span class="da_astrx_mand">*</span></td>
              <td>Upload Photo (s)</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td class="inner_tbl_td" valign="TOP"><asp:TextBox runat="server" ID="txtDesc" CssClass="input_in" TextMode="MultiLine" MaxLength="98"></asp:TextBox></td>
              <td colspan="5" valign="top" class="inner_tbl_td">
              <asp:FileUpload runat="server" ID="filePhoto" CssClass="da_select_type" style="background:#fff;" />
                         
                            <asp:FileUpload runat="server" id="fileAdditionaPhoto1" CssClass="da_select_type" style="background:#fff;" />
                           
                            <asp:FileUpload runat="server" ID="fileAdditionaPhoto2" CssClass="da_select_type" style="background:#fff;" />
                          
                            <div>
                                <asp:Image runat="server" ID="imgPhoto" height="150" Visible="false" />&nbsp;
                                <asp:Image runat="server" ID="imgAdditionalImage1" height="150" Visible="false" />&nbsp;
                                <asp:Image runat="server" ID="imgAdditionalImage2" height="150" Visible="false" />
                                <asp:HiddenField runat="server" ID="hdnImagePath" />
                                 <asp:HiddenField runat="server" ID="hdnAdditionalImagePath1" />
                                 <asp:HiddenField runat="server" ID="hdnAdditionalImagePath2" />
                            </div>    
                
              </td>
              <td>&nbsp;</td>
            </tr>
            </table>
            
        
        </td>
        </tr>
    </table>
    
 
    </td>
  </tr>
</table>
        </div>
        </div><br />
    <div class="form_buttom">
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" class="submit da_submit_button" Text="Submit" />
        <input type="button" id="btnPrint" value="Print" class="da_submit_button" onclick="return PrintPDF();" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="da_h1">Confirmation</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
    <div class="form_box">
        
        <div class="text-content">
            IND Block have been saved into the system successfully!
            <br />
            <a id="A1" href="~/internal/Design/INDBlockListing.aspx" runat="server">Click here</a>
            to IND Block List.</div>
    </div>
</asp:Panel>
