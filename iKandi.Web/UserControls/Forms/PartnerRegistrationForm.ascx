<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartnerRegistrationForm.ascx.cs" Inherits="iKandi.Web.PartnerRegistrationForm" %>

<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .style2
    {
        background: #f7f7f7;
        border: solid 1px #d7d7d7;
        width: 7%;
        padding: 5px;
    }
    .style3
    {
        width: 7%;
    }
</style>



<script type="text/javascript">
    $(function () {
        $("input.Read", "#main_content").change(function () {
            var PartnerName = $('#<%=txtPartnerName.ClientID %>', "#main_content").val().toLowerCase();
            PartnerName = jQuery.trim(PartnerName);
            var DelevertMode = "";
            var Login;

            if ($('#<%=ddlDeliveryMode.ClientID %>', "#main_content").val() != -1) {
                DelevertMode = $('#<%=ddlDeliveryMode.ClientID %>', "#main_content").find('option').filter(':selected').text().toLowerCase();

            }
            else {
                DelevertMode = "";

            }
            DelevertMode = jQuery.trim(DelevertMode);
            Login = PartnerName + "@" + DelevertMode;
            Login = jQuery.trim(Login);
            var a = $('#<%=txtLogin.ClientID %>', "#main_content").val(Login);

        });
    });
     
    
    </script>


    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    <h2  class="header-text-back">
    Partner Registration Form (<span class="da_astrx_mand">*</span> Please fill all required fields)
    </h2>
    </td>
    </tr>
<tr>
    <td class="tbl_bordr">

    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
      <tr>
        <td>
          <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0">
            <tr class="td-sub_headings">
              <td width="14%" valign="bottom">Official Partner Name <span class="da_astrx_mand">*</span></td>
              <td valign="bottom" class="style3">partner Code <span class="da_astrx_mand">*</span></td>
              <td width="14%" valign="bottom">Website</td>
              <td width="5%" valign="bottom">Phone</td>
              <td width="14%" valign="bottom">Email (General)</td>
              <td width="14%" valign="bottom"><asp:Label ID="lblLoginId" runat="server" Text="Login Id " CssClass="td-sub_headings"></asp:Label>
                            <asp:HiddenField ID="hiddenUserId" runat="server"/></td>
              </tr>
            <tr>
              <td class="inner_tbl_td"> 
              <asp:TextBox ID="txtPartnerOfficialName" runat="server" Width="185px" CssClass="input_in" ValidationGroup="submit" MaxLength="50"></asp:TextBox>
                             <div class="form_error">
                                <asp:RequiredFieldValidator ID="rfvPartnerOfficialName" runat="server" 
                                ErrorMessage="Partner Official Name is Required" ControlToValidate="txtPartnerOfficialName" 
                                Display="Dynamic" ValidationGroup="submit" CssClass="da_error_msg" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
              </td>
              <td class="style2"><asp:TextBox ID="txtPartnerName" runat="server" Width="185px" CssClass="input_in" ValidationGroup="submit" MaxLength="50"></asp:TextBox>
                            <div class="form_error da_error_msg">
                                <asp:RequiredFieldValidator ID="rfvPartnerName" runat="server" 
                                ErrorMessage="Partner Code is Required" ControlToValidate="txtPartnerName" 
                                Display="Dynamic" ValidationGroup="submit" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div></td>
              <td class="inner_tbl_td"><asp:TextBox ID="txtWebsite" CssClass="input_in" runat="server" Width="185px" MaxLength="100">
                            </asp:TextBox></td>
              <td class="inner_tbl_td"><asp:TextBox ID="txtPhone" CssClass="input_in" runat="server" Width="150px" MaxLength="50">
                            </asp:TextBox></td>
              <td class="inner_tbl_td"><asp:TextBox ID="txtEmail" CssClass="input_in" runat="server" Width="185px" ValidationGroup="submit" MaxLength="50">
                            </asp:TextBox>
                            <div class="form_error da_error_msg">
                                    <asp:RegularExpressionValidator ID="rxvEmailGeneral" runat="server" 
                                        ErrorMessage="Email address is not in the Correct Formet" 
                                        ValidationGroup="submit" ControlToValidate="txtEmail" Display="Dynamic" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ForeColor="Red" ></asp:RegularExpressionValidator>
                             </div>
                            </td>
              <td class="inner_tbl_td"><asp:TextBox ID="txtLogin" CssClass="input_in" runat="server" Width="185px" ReadOnly="true" ValidationGroup="submit" MaxLength="50"></asp:TextBox>  </td>
              </tr>
            <tr  class="td-sub_headings">
              <td>Client <span class="da_astrx_mand">*</span></td>
              <td class="style3"><asp:Label ID="lblAddress" runat="server" Text="Address " ></asp:Label></td>
              <td><asp:Label ID="lblPartnerType" runat="server" Text="Partner Type" ></asp:Label><span class="da_astrx_mand">*</span></td>
              <td><asp:Label ID="lblDeliveryMode" runat="server" Text="Delivery Mode"></asp:Label><span class="da_astrx_mand">*</span></td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td rowspan="2" class="inner_tbl_td"><asp:ListBox runat="server" ID="lstClients" SelectionMode="Multiple" Width="192px" CssClass="input_in" >
                                </asp:ListBox></td>
              <td valign="top" class="inner_tbl_td"><asp:TextBox ID="txtAddress" runat="server" Width="185px" TextMode="MultiLine" MaxLength="500" CssClass="input_in"></asp:TextBox></td>
              <td class="inner_tbl_td" valign="middle"><asp:DropDownList ID="ddlPartnerType" runat="server" Width="185px" 
                                 AutoPostBack="True" ValidationGroup="submit" 
                                onselectedindexchanged="ddlPartnerType_SelectedIndexChanged" CssClass="input_in">
                                
                                <asp:ListItem Text="Select Partner Type....." Value="-1"></asp:ListItem>
                                    <asp:ListItem Value="1">INDIA_AIR</asp:ListItem>
                                    <asp:ListItem Value="2">INDIA_SEA</asp:ListItem>
                                    <asp:ListItem Value="3">EXTERNAL_AIR</asp:ListItem>
                                    <asp:ListItem Value="4">EXTERNAL_SEA</asp:ListItem>
                                    <asp:ListItem Value="5">HANGING</asp:ListItem>
                            </asp:DropDownList>
                            <div class="form_error da_error_msg">
                                <asp:RequiredFieldValidator ID="rfvPartnerType" runat="server" 
                                ErrorMessage="Selection of Partner Type is necessary" 
                                    ControlToValidate="ddlPartnerType" InitialValue="-1" 
                                ValidationGroup="submit" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div></td>
              <td valign="middle" class="inner_tbl_td"><asp:DropDownList ID="ddlDeliveryMode"  runat="server" Width="150px" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlDeliveryMode_SelectedIndexChanged" ValidationGroup="submit" CssClass="input_in">
                                <asp:ListItem Text="Select Delivery Mode....." Value="-1"></asp:ListItem>
                                <asp:ListItem Value="1">LANDED</asp:ListItem>
                                <asp:ListItem Value="2">FOB</asp:ListItem>
                                
                            </asp:DropDownList>
                           <div class="form_error da_error_msg">
                        <asp:RequiredFieldValidator ID="rfvDeliveryMode" runat="server" 
                            ErrorMessage="Selection of Delivery Mode is necessary" 
                                   ControlToValidate="ddlDeliveryMode" InitialValue="-1" 
                             ValidationGroup="submit" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div></td>
              <td rowspan="2">&nbsp;</td>
              <td rowspan="2">&nbsp;</td>
            </tr>
            <tr>
              <td valign="top"></td>
              <td height="25"></td>
              <td valign="top"></td>
            </tr>
            </table>
                    
        </td>
        </tr>
    </table>
 

    <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" class="main_tbl_wrapper">
        <tr class="td-sub_headings">
            <td width="12%">Name<span class="da_astrx_mand">*</span></td>
            <td width="11%">Email Id<span class="da_astrx_mand">*</span></td>
            <td width="12%">Function<span class="da_astrx_mand">*</span></td>
            <td width="15%">Delete</td>
            <td width="15%" valign="bottom">&nbsp;</td>
            <td width="17%" valign="bottom">&nbsp;</td>
            <td width="17%" valign="bottom">&nbsp;</td>
        </tr>
    <asp:Repeater ID="rptPartner" runat="server" onitemdatabound="rptPartner_ItemDataBound" 
                    onitemcommand="rptPartner_ItemCommand" >
        <ItemTemplate> 
        <tr>
            <td class="inner_tbl_td">
                <asp:HiddenField runat="server" ID="hdnPartnerEmailID"  />
                <asp:TextBox ID="txtName" runat="server" Width="185px" ValidationGroup="submit" MaxLength="50" CssClass="input_in"></asp:TextBox>
                <div class="form_error da_error_msg">
                    <asp:RequiredFieldValidator ID="rfvtxtNmae" runat="server" ErrorMessage="Name Is Required" ControlToValidate="txtName"  
                                ValidationGroup="submit"  ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
            </td>
            <td class="inner_tbl_td">
                  <asp:TextBox ID="txtEmail" runat="server" Width="185px" ValidationGroup="submit" MaxLength="50" CssClass="input_in"></asp:TextBox> 
                  <div class="form_error da_error_msg">
                    <asp:RequiredFieldValidator ID="rfvTextEmail" runat="server" ErrorMessage="Email ID Is Required" ControlToValidate="txtEmail"  
                                ValidationGroup="submit" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form_error da_error_msg">
                                    <asp:RegularExpressionValidator ID="rxvEmail" ForeColor="Red" runat="server" 
                                        ErrorMessage="Email address is not in the Correct Formet" 
                                        ValidationGroup="submit" ControlToValidate="txtEmail" Display="Dynamic" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                             </div>
                            
                   
            </td>
             <td class="inner_tbl_td" valign="middle">
                <asp:DropDownList ID="ddlFunction" runat="server" Width="185px" ValidationGroup="submit" CssClass="input_in" >
                    <asp:ListItem Text="Select Funtion....." Value="-1"></asp:ListItem>
                    <asp:ListItem Value="1">DELIVERY</asp:ListItem>
                    <asp:ListItem Value="2">PROCESSING/DELIVERY</asp:ListItem>
                     <asp:ListItem Value="3">QA</asp:ListItem>           
                </asp:DropDownList>
                <div class="form_error da_error_msg">
                   <asp:RequiredFieldValidator ID="rfvDdlFunction" runat="server" 
                                ErrorMessage="Selection of Function is necessary" ControlToValidate="ddlFunction" InitialValue="-1" 
                                ValidationGroup="submit" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                
            </td>
            <td>
                <asp:CheckBox ID="chkIsDelete" runat="server" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          
              <td width="17%" align="right" valign="bottom"><asp:Button runat="server" ID="btnAddNewRow"  Text="Add more" CssClass="add_more"  CommandName="AddRow" /> </td>
        </tr>
        </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td colspan="4" align="right">
              
            </td>
        </tr>
        </FooterTemplate>
        </asp:Repeater>
    </table> 
</td>
</tr>
</table>
<br />

     <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="da_submit_button submit" 
             onclick="btnSubmit_Click" ValidationGroup="submit"/>
          <input type="button" id="btnPrint" class="da_submit_button" value="Print" onclick="return PrintPDF();" />    
    </div>  
     

   <asp:Panel runat="server" ID="pnlMessage" Visible="false">
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="h1">Confirmation</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
    <div class="form_box">
        
        <div class="text-content">
            Data has been saved into the system successfully!
            <br />
            
            <a id="A1" href="~/Internal/Users/PartnerRegistrationListing.aspx" runat="server">Click here</a> to see Paerners List.
                        
        </div>
        </div>
</asp:Panel>  