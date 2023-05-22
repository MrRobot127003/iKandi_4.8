<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.ascx.cs" Inherits="iKandi.Web.MyProfile" %>



<asp:Panel runat="server" ID="pnlForm">

<div class="print-box">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="da_h1">My Profile</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
  </table>
        <div class="form_box">
          
            <table border="0" cellspacing="8" cellpadding="2" width="100%">
                <tr>
                    <td width="35%" class="td-sub_headings">
                        First Name<span class="da_astrx_mand">*</span>:
                    </td>
                    <td width="3%" class="inner_tbl_td">
                        <asp:TextBox runat="server" ID="txtFirstName" MaxLength="43" CssClass="da_input_dafo"></asp:TextBox>
                        <div class="form_error da_error_msg">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="txtFirstName" ErrorMessage="First name is required"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td width="1%" >&nbsp;</td>
                    <td width="45%" class="td-sub_headings">
                        Last Name<span class="da_astrx_mand">*</span>:
                    </td>
                    <td width="1%"  class="inner_tbl_td">
                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="43" CssClass="da_input_dafo"></asp:TextBox>
                        <div class="form_error da_error_msg">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtLastName" Display="Dynamic" 
                                ErrorMessage="Last name is required"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td  width="2%">&nbsp;</td>
                    <td class="td-sub_headings" width="30%">Upload Photo: 
                        </td>
                    <td class="inner_tbl_td" width="2%"><asp:FileUpload runat="server" ID="filePhoto" CssClass="da_input_dafo"  />
                       
                        <div>
                            <asp:Image runat="server" ID="imgPhoto" Width="150" Visible="false" />
                        </div></td>
                </tr>
                <tr>
                    <td class="td-sub_headings">
                        Address: 
                    </td>
                    <td class="inner_tbl_td">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="da_input_dafo"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="td-sub_headings">Personal Email:</td>
                    <td  class="inner_tbl_td">
                        <asp:TextBox ID="txtPersonalEmail" runat="server" MaxLength="43" CssClass="da_input_dafo"></asp:TextBox>
                        <div class="da_error_msg">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txtPersonalEmail" Display="Dynamic" 
                                ErrorMessage="Please enter a valid email address" 
                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                    <td >&nbsp;</td>
                    <td >&nbsp;
                        </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="td-sub_headings">
                        Home Phone:
                    </td>
                    <td class="inner_tbl_td">
                        <asp:TextBox runat="server" ID="txtPersonalPhoneCountry" MaxLength="5" size="2" CssClass="da_phone_field"></asp:TextBox>-<asp:TextBox
                            runat="server" ID="txtPersonalPhoneArea" MaxLength="6" size="4" CssClass="da_phone_field"></asp:TextBox>-<asp:TextBox runat="server"
                                ID="txtPersonalPhone" MaxLength="10" size="7" CssClass="da_phone_field"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="td-sub_headings">
                        Mobile:
                    </td>
                    <td  class="inner_tbl_td">
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="18" CssClass="da_input_dafo"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                        </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="td-sub_headings">
                        Birthday:
                    </td>
                    <td class="inner_tbl_td">
                        <asp:TextBox runat="server" ID="txtBirthday" CssClass="date-picker date_style da_input_dafo"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="td-sub_headings">
                        Anniversary:
                    </td>
                    <td  class="inner_tbl_td">
                        <asp:TextBox ID="txtAnniversary" runat="server" 
                            CssClass="date-picker date_style da_input_dafo" ></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                        </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
</div>

    <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" OnClick="Submit_Click" CssClass="da_submit_button"
            Text="Submit" />
        <input type="button" id="btnPrint" value="Print" class="da_submit_button"  onclick="return PrintPDF();" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Profile Saved
        </div>
        <div class="text-content">
            Your profile have been saved into the system successfully!
            <br />
            <a id="A1" runat="server" href="~/Internal/Dashboard_Task.aspx" >Click here</a> to Dashboard.</div>
       
    </div>
</asp:Panel>