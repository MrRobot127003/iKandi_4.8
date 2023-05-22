<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZipRateForm.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.ZipRateForm" %>
<%@ OutputCache Duration="60" VaryByParam="Id" VaryByControl="txtSize" %>
<asp:Panel runat="server" ID="pnlForm">
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    
<h2  class="header-text-back"> 
Zip Rate  Form ( <span class="da_astrx_mand">*</span> Please fill all required fields)</h2>
    </td>
  </tr>
  <tr>
    <td class="tbl_bordr">
  
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
  
      <tr>
        <td width="80%">
          
          <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin:0px;">
            <tr class="td-sub_headings">
              <td width="14%" valign="bottom">Detail<span class="da_astrx_mand">*</span></td>
              <td width="14%" valign="bottom">Type <span class="da_astrx_mand">*</span></td>
              <td width="14%" valign="bottom">Size <span class="da_astrx_mand">*</span></td>
              <td width="14%" valign="bottom">Rate <span class="da_astrx_mand">*</span></td>
              <td width="14%" valign="bottom">&nbsp;</td>
              </tr>
            <tr>
              <td class="inner_tbl_td"><asp:TextBox ID="txtDetail" runat="server"  CssClass="input_in" ValidationGroup="submit" MaxLength="42"></asp:TextBox>
                    <div class="form_error da_error_msg">
                        <asp:RequiredFieldValidator ID="rfvDetail" runat="server" 
                            ErrorMessage="Detail is Required" ControlToValidate="txtDetail" 
                            Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div></td>
              <td class="inner_tbl_td"> <asp:DropDownList ID="ddlType" runat="server"  CssClass="input_in" >
                        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                     </asp:DropDownList>
                     <div class="form_error da_error_msg">
                        <asp:RequiredFieldValidator ID="rfvType" runat="server" 
                            ErrorMessage="Selection of Type is necessary" ControlToValidate="ddlType" InitialValue="-1" 
                             ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div></td>
              <td class="inner_tbl_td"><asp:TextBox ID="txtSize" runat="server"  ValidationGroup="submit" CssClass="numeric-field-without-decimal-places input_in" MaxLength="8"></asp:TextBox>
                     <div class="form_error da_error_msg">
                        <asp:RequiredFieldValidator ID="rfvSize" runat="server" 
                            ErrorMessage="Size is Required" ControlToValidate="txtSize" 
                            Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form_error da_error_msg">
                         <asp:CompareValidator ID="cvSize" runat="server" 
                             ErrorMessage="Enter a valid Size" ControlToValidate="txtSize" 
                             Operator="DataTypeCheck" Type="Integer" ValidationGroup="submit"></asp:CompareValidator>
                    </div></td>
              <td class="inner_tbl_td"><asp:TextBox ID="txtRate" runat="server"  ValidationGroup="submit" CssClass="numeric-field-with-two-decimal-places input_in" MaxLength="8"></asp:TextBox>
                     <div class="form_error da_error_msg">
                        <asp:RequiredFieldValidator ID="rfvRate" runat="server" 
                            ErrorMessage="Rate is Required" ControlToValidate="txtRate" 
                            Display="Dynamic" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form_error da_error_msg">
                         <asp:CompareValidator ID="cvRate" runat="server" 
                             ErrorMessage="Enter a valid Rate" ControlToValidate="txtRate" 
                             Operator="DataTypeCheck" Type="Double" ValidationGroup="submit"></asp:CompareValidator>
                    </div>
             </td>
              <td>&nbsp;</td>
              </tr>
            </table>
            
        
        </td>
        </tr>
    </table>

<div class="form_buttom" style="padding:4px;">
    <asp:Button ID="btnSubmit" runat="server" ValidationGroup="submit" Text="Submit" CssClass="da_submit_button submit" onclick="btnSubmit_Click" />
     <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="da_submit_button" onclick="btnCancel_Click" />
      <input type="button" id="btnPrint" class="da_submit_button" value="Print"  onclick="return PrintPDF();" />
    </div> 


    </td>
  </tr>
</table>

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
            Zip Rate have been saved into the system successfully!
            <br />
            <a id="A1" href="~/Admin/ZipRate/ZipRateListing.aspx" runat="server">Click here</a> to see Zip Rate List.
            
        </div>
</asp:Panel>