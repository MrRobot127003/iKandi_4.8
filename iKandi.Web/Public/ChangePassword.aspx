<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    MasterPageFile="~/layout/Public.Master" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">


<style type="text/css">
        #spinnL
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        
        
        body
        {
            height: 100%;
            width: 100%;
            overflow-x: hidden;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            background-color: #dadadacc; /* background-image: linear-gradient(to right, #fff 10%, #3a333a 100%);*/
        }
        label
        {
            margin-bottom: 3px;
        }        

        .login-img div
        {
            height: 445px;
            width: 100%;
            background-size: cover;
            background-position: center;
        }
        .login-img::before
        {
            content: '';
            border: 187px solid #fff;
            position: absolute;
            top: 16%;
            left: 337px;
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-right-color: transparent;
            opacity: 1;
        }
        
        
        .logo1 img
        {
            border-radius: 50%;
            margin: 0 auto;
            display: block;
            /*box-shadow: 0 4px 8px 0 rgb(10 100 140 / 24%), 0 6px 20px 0 rgb(3 169 244 / 16%);*/
            box-shadow: 0 4px 8px 0 rgb(45 41 74 / 0%), 0 6px 20px 0 rgb(45 41 74 / 42%);
            margin-top: 11px;
            margin-left: 35px;
            background-color: #c5c5ca;
        }
        .logo1 span
        {
            text-align: center;
            font-size: 26px;
            font-weight: 600;
            color: #555;
            margin-left: 9px;
        }
        .row
        {
            margin-right: 0px;
        }
        .login-form
        {
            margin-top: 10px;
        }
        input[type="text"]
        {
            height: 20px;
            width: 239px;
        }
        input[type="password"]
        {
            height: 20px;
            width: 239px;
        }
        .input-group
        {
            width: 190px;
            margin-bottom: 4px;
        }
        .input-group label
        {
            width: 100%;
            font-size: 15px;
            color: #555;
        }
        
        
        .login-form button:hover
        {
            opacity: 0.7;
        }
        .form-select
        {
            width: 130px;
            color: #555;
            height: 24px;
            border-radius: 5px;
            border-color: #bfb9b9;
            margin-top: 26px;
        }
        .forgetPassword
        {
            color: #555 !important;
            margin-top: 5px;
            cursor: pointer;          
            margin-left: 8px;  
        }
        .forgetPassword:hover
        {
            color: #732c2c !important;
            text-decoration: underline !important;
            font-size:14px !important;
           /* box-shadow: 5px 10px 8px #888888 !important;*/
        }
        .btn:hover
        {
            color: #f5f5f5;
            text-decoration: none;
        }
        
        .ShowShadow
        {
            border: 1px solid;
            padding: 10px;
            box-shadow: 5px 10px 8px #888888;
            border-radius: 6px;            
            margin-left: 108px !important;
            margin-top: 36px !important;
        }
        .RightSideColor
        {
            color:#e1e1e1;
        }
        
        .imgBannerLeftSide
        {
            height: 429px;
            width: 320px;
            float: left;
            margin: 0px;
            padding: 0px;
        }
       
        
        .imgBannerLeftSide::before
        {
        content: '';
        border: 191px solid #fff;
        position: absolute;
        top: 76.3px;
        left: 329px;
        border-top-color: transparent;
        border-bottom-color: transparent;
        border-right-color: transparent;
        opacity: 1;
        }
        
        
        #ctl00_boutiquelogo        
        {
            display:none;
        }
       #ctl00_cph_main_content_pwd_recovery td
       {
           text-align:left;
       }
       #footer
        {
              /*width:776px;
            margin-left: 79px !important;
            margin-top: 16px !important;
            top:150px;*/
             width:100%;
            position:absolute;
            bottom:0;
            left:0;
        }  
        .TextboxWidth
        {
            width:178px !important;
            border-radius: 3px; 
            border: 1px solid #999999;
            background-color:#ffffff !important;      
        }   
        
        .lfr1Cls
        {
            background: rgba(204, 204, 204, 0);
        }        
        
        #ctl00_cph_main_content_ChangePassword1_ChangePasswordContainerID_CurrentPasswordLabel
        {
            
        }
        
        input[type="password"] 
        {
            height: 20px;
            width: 169px;
            margin-left: -4px;
        }        
        
        table
        {
            border-color: #e1e1e1;
        }
        
        #ctl00_cph_main_content_ChangePassword1_ChangePasswordContainerID_CancelPushButton
        {
           width: 86%;
            background-color: #2b2b46;
            border: none;
            color: white;
            border-radius: 3px;
            cursor: pointer;
            height: 35px;
            /* float: left; */
        }
         #ctl00_cph_main_content_ChangePassword1_ChangePasswordContainerID_CancelPushButton:hover
         {
             color: #f5f5f5 !important;
            text-decoration: none !important;
            cursor: pointer !important;
            background-color: #565675 !important;
         }
        
        #ctl00_cph_main_content_ChangePassword1_ChangePasswordContainerID_ChangePasswordPushButton
        {
            width: 86%;
            background-color: #2b2b46;
            border: none;
            color: white;
            border-radius: 3px;
            cursor: pointer;
            height: 35px;
            /* float: left; */
            margin-left: -172px;
            margin-right:10px;
        }
        
        #ctl00_cph_main_content_ChangePassword1_ChangePasswordContainerID_ChangePasswordPushButton:hover
        {
            color: #f5f5f5 !important;
            text-decoration: none !important;
            cursor: pointer !important;
            background-color: #565675 !important;
        }
        
        .LableWidth
        {           
            float:left;
            margin-bottom: 3px;
            margin-left: 5px;
            margin-top: 6px;
        }
        .textWidth
        {
            width:170px;
            margin-left:-5px;            
        }
        .textWidth:focus
        {
            box-shadow: 0 4px 8px 0 rgb(10 100 140 / 24%), 0 6px 20px 0 rgb(3 169 244 / 16%);
            background-color:#ffffff !important; 
            border: 1px solid #999999;
        }
        
        #banner_cor
        {
            min-height:100%;
            position:relative;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            var images = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30];
            var d = new Date();
            var CurrentDate = d.getDate();
            function checkDate(images) {
                return images >= CurrentDate;
            }
            var Imgval = images.find(checkDate);
            if (Imgval == CurrentDate) {
                //$("#imgBanner").css("background-image", "url(../images/loginImages/" + Imgval + ".jpg)");
                //$("#imgBannerID").css("background-image", "url(../images/loginImages/" + Imgval + ".JPG) !important");
                $("#imgBannerID").attr("src", "../images/loginImages/" + Imgval + ".jpg");
                //.attr("src","second.jpg");                

            } else {
                var DefaultImg = "login-image.jpg";
                //$("#imgBanner").css("background-image", "url(../images/loginImages/" + DefaultImg + ")");
                //$("#imgBannerID").css("background-image", "url(../images/loginImages/" + DefaultImg + ") !important");
                $("#imgBannerID").attr("src", "../images/loginImages/" + DefaultImg);
            }
        });

        $(document).ready(function () {
            var images = $('#ctl00_boutiquelogo').attr('src');
            //var images = $('#ctl00_boutiquelogo').text();
            //alert(images);
            //if (images == "../App_Themes/ikandi/images/ikandi.gif") {
            if (images == "../App_Themes/ikandi/images/new-boutique-logo.png") {
                // $('#ctl00_boutiquelogo').attr("style", "margin-left:558px;margin-top:90px;z-index:10;position:absolute;");
                //$('#boutiquelogoId').attr("style", "opacity:0");
                $('#ctl00_boutiquelogo').attr("style", "display:none");
            }
            else {
                $('#ctl00_boutiquelogo').attr("style", "margin-left:558px;margin-top:90px;z-index:10;position:absolute;display:block !important;");
                $('#boutiquelogoId').attr("style", "opacity:0");
            }
        });
    </script>
    <div id="banner_cor" class="ShowShadow" style="width: 700px; background-color:#e1e1e1; border-color: #e1e1e1;height:454px;top:-50px;">
        <%--<div id="holder">
        </div>--%>
        <div id="imgBanner" class="imgBannerLeftSide">
        <img src="" id="imgBannerID" style="height:452px; width:325px;margin-left: 5px;margin-top: 5px;"/>
        </div>
        <div id="text" class="RightSideColor" style="width: 380px;">
        <div class="logo1" style="margin-bottom:-16px;">
                <img id="boutiquelogoId" src="../images/loginImages/boutique-logo.png" style="margin-left: 142px;margin-bottom:24px; margin-top:-4px;" />                
            </div>
            <span style="margin-left: 39px;font-size:24px; font-weight:600;">Change Password</span>
            <%--<h1>
                Change Password</h1>--%>
                
            <asp:ChangePassword ID="ChangePassword1" runat="server" DisplayUserName="false" CancelDestinationPageUrl="~/public/Login.aspx" ChangePasswordFailureText="Password incorrect."
                ContinueDestinationPageUrl="~/public/login.aspx" OnChangedPassword="ChangePassword1_ChangedPassword">
                <ChangePasswordTemplate> 
                 <div id="lfr1" class="lfr1Cls" style="width:331px;background: rgba(204, 204, 204, 0);">
                    <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse; width: 380px;margin-left: 2px;margin-top: 27px;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="5" style="width:380px">
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="CurrentPasswordLabel" runat="server" CssClass="LableWidth" AssociatedControlID="CurrentPassword">Password</asp:Label>
                                        </td>
                                        <td valign="middle">
                                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" CssClass="textWidth"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="NewPasswordLabel" CssClass="LableWidth" runat="server" AssociatedControlID="NewPassword">New Password</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" CssClass="textWidth" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                ErrorMessage="New Password is required." ToolTip="New Password is required."
                                                ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="ConfirmNewPasswordLabel" CssClass="LableWidth" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" CssClass="textWidth" MaxLength="20"></asp:TextBox>
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
                                      <td colspan="2">
                                         <a href="ForgotPassword.aspx" style="text-decoration: none;" target="_blank" Class="forgetPassword">Retrieve Password</a>
                                      </td>
                                    </tr>

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
                                    
                                </table>
                            </td>
                        </tr>
                    </table>
                    </div>
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
