<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="iKandi.Web.Forgot_Password" MasterPageFile="~/layout/Public.Master" %>

<asp:Content ContentPlaceHolderID="cph_main_content" runat="server">
<style>
input[type=text]{
   border: 1px solid #cccccc;
   text-transform: capitalize;
    font-size: 11px;
    width: 253px;
    height: 22px;
    border-radius: 2px;
}
td
{
    padding:2px 0px
 }
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
        <div id="lnk_title">
            </div>
        <div id="text">
            <h1>
                Forgot Password</h1>
            <asp:PasswordRecovery ID="pwd_recovery"  runat="server" UserNameTitleText=""  
                onsendingmail="pwd_recovery_SendingMail" >
                <UserNameTemplate >
                    <table border="0" cellpadding="1" cellspacing="0" 
                        style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2" style="font-size: 16px;">
                                            Enter your Email to receive your password.</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" oncopy="return false" onpaste="return false"  runat="server"></asp:TextBox> 
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                ToolTip="User Name is required." ValidationGroup="pwd_recovery">*</asp:RequiredFieldValidator>

                                               
                                        </td>
                                      
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" style="padding-left:5px;">
                                          <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" 
                                                ValidationGroup="pwd_recovery"    />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </UserNameTemplate>
                
            </asp:PasswordRecovery>
        </div>
    </div>
</asp:Content>
