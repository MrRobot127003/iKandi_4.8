<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    MasterPageFile="~/layout/Public.Master" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">
<style>
 #banner_cor
 {
     border-radius: 15px;
    box-shadow: 2px 2px 2px 2px #ece3ea; 
  }
  input[type="submit"]
  {
      background: green;
    color: #fff;
    border: 1px solid green;
    border-radius: 2px;
    cursor:pointer;
   }
</style>
    <div id="banner_cor">
        <div id="holder">
        </div>
        <div id="text">
            <h1>
                Change Password</h1>
                
            <asp:ChangePassword ID="ChangePassword1" runat="server" DisplayUserName="false" CancelDestinationPageUrl="~/public/Login.aspx" ChangePasswordFailureText="Password incorrect."
                ContinueDestinationPageUrl="~/public/login.aspx" OnChangedPassword="ChangePassword1_ChangedPassword">
                <ChangePasswordTemplate> 
                    <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="5" style="width:450px">
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Password:</asp:Label>
                                        </td>
                                        <td valign="middle">
                                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                ErrorMessage="New Password is required." ToolTip="New Password is required."
                                                ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                                                ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>


                                                   <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="NewPassword"
                                                ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                                ValidationGroup="ChangePassword1" Font-Size="Smaller"></asp:CompareValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                ControlToValidate="NewPassword" ValidationGroup="ChangePassword1" 
                                                ErrorMessage="Password should consist atleast 1 alphabet, 1 Numeric and 1 special charaters between 4 to 20 characters." 
                                                ValidationExpression="(?=^.{4,20}$)(?=(?:.*?\d){1})(?=(?:.*?[a-zA-Z]){1})(?=(?:.*?[!@#$%*()_+^&amp;}{:;?.]){1})(?!.*\s)[0-9a-zA-Z!@#$%*()_+^&amp;]*$" 
                                                Display="Dynamic" Font-Size="Smaller"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ValidationGroup="ChangePassword1"
                                                ControlToCompare="CurrentPassword" ControlToValidate="NewPassword" Display="Dynamic"
                                                ErrorMessage="New Password should be unique from existing Password." 
                                                Font-Size="Smaller" Operator="NotEqual"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                  <%--  <tr>
                                        <td align="center" colspan="2">
                                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                                ValidationGroup="ChangePassword1" Font-Size="Smaller"></asp:CompareValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                ControlToValidate="NewPassword" ValidationGroup="ChangePassword1" 
                                                ErrorMessage="Password should consist atleast 1 alphabet, 1 Numeric and 1 special charaters between 4 to 20 characters." 
                                                ValidationExpression="(?=^.{4,20}$)(?=(?:.*?\d){1})(?=(?:.*?[a-zA-Z]){1})(?=(?:.*?[!@#$%*()_+^&amp;}{:;?.]){1})(?!.*\s)[0-9a-zA-Z!@#$%*()_+^&amp;]*$" 
                                                Display="Dynamic" Font-Size="Smaller"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="ChangePassword1"
                                                ControlToCompare="CurrentPassword" ControlToValidate="NewPassword" Display="Dynamic"
                                                ErrorMessage="New Password should be unique from existing Password." 
                                                Font-Size="Smaller" Operator="NotEqual"></asp:CompareValidator>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                          
                                        </td>
                                        <td>
                                          <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                Text="Change Password" ValidationGroup="ChangePassword1" />
                                            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="Cancel" />
                                              
                                        </td>
                                    </tr>
                                    <tr>
                                     <td align="right">
                                          
                                        </td>
                                      <td>
                                         <a href="ForgotPassword.aspx" style="text-decoration: none;color:blue" target="_blank">Retrieve Password</a>
                                      </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ChangePasswordTemplate>
                <SuccessTemplate>
                    <br />
                    <br />
                    <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;
                        padding-left: 50px;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="5" cellspacing="5">
                                    <tr>
                                        <td align="center" colspan="2">
                                            Change Password Complete
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Your password has been changed!
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                Text="Continue" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </SuccessTemplate>
            </asp:ChangePassword>
        </div>
    </div>
</asp:Content>
