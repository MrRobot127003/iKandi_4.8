<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="iKandi.Web.Forgot_Password" MasterPageFile="~/layout/Public.Master" %>

<asp:Content ContentPlaceHolderID="cph_main_content" runat="server">
    <style type="text/css">
        input[type=text]
        {
            border: 1px solid #cccccc;
            text-transform: capitalize;
            font-size: 13px;
            width: 253px;
            height: 22px;
            border-radius: 2px;
        }
        td
        {
            padding: 2px 0px;
        }
        
        input[type="submit"]
        {
            background: green;
            color: #fff;
            border: 1px solid green;
            border-radius: 2px;
            cursor: pointer;
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
        
        
        .ShowShadow
        {
            border: 1px solid;
            padding: 10px;
            box-shadow: 5px 10px 8px #888888;
            border-radius: 6px;            
            margin-left: 108px !important;
            margin-top: 36px !important;           
            box-shadow: 4px 8px 10px #0e173c;
        }
        
        #ctl00_boutiquelogo
        {
            display: none;
        }
        
        #ctl00_cph_main_content_pwd_recovery_QuestionContainerID_SubmitButton
        {
            color: White;
            height: 35px;
            border-radius: 3px;
            width: 254px;
            background-color: #2b2b46;
            border: none;
            margin-left: 53px;
            margin-top: 12px;
            float: left;
            font-size: 16px;
        }
        
         #ctl00_cph_main_content_pwd_recovery_QuestionContainerID_SubmitButton:hover
         {
             color: #f5f5f5 !important;
            text-decoration: none !important;
            cursor: pointer !important;
            background-color: #565675 !important;
            /*box-shadow: 5px 10px 8px #563232 !important;*/
         }
        
        
   #footer
        {
    background-color: #193062;
    line-height: 22px;
    height: 22px;
    width: 100%;
    position: absolute;
    bottom: 0;
    left: 0;
    color: #bdbdbd;
            
        }     
   .imgBannerLeftSide::before {
    content: '';
    border: 190px solid #fff;
    position: absolute;
    top: 45px;
    left: 330px;
    border-radius: 0% 30%;
    box-shadow: 0 0px 0px rgb(0 0 0 / 0%), 5px 4px 6px rgb(0 0 0 / 23%);
            }
        
        .logo1 span
        {
            text-align: center;
            font-size: 20px;
            font-weight: 600;
            color: #555;
            margin-left: 9px;
        }
        
        .submitButton:hover
        {
            color: #f5f5f5 !important;
            text-decoration: none !important;
            cursor: pointer !important;
            background-color: #565675 !important;
            /*box-shadow: 5px 10px 8px #563232 !important;*/
        }
        #banner_cor #text
        {
            font-size: 11.9px;
        }
        
        #banner_cor
        {
            min-height:100%;
            position:relative;
        }
 .center_bodyCentering{
    width: 100%;
    height: 100vh;
    background: linear-gradient( to right, #E1E1E1 0%, #E1E1E1 48.8%, #193062 48.8%, #193062 100% );
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
                $("#imgBannerID").attr("src", "../images/loginImages/" + Imgval + ".jpg");
            }

            else {
                var DefaultImg = "login-image.jpg";
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
    <div id="banner_cor" class="ShowShadow" style="width: 740px; background-color: #e1e1e1; border-color: #e1e1e1;">
        <%--<div id="holder">
        </div>--%>
        <div id="imgBanner" class="imgBannerLeftSide">
        <img src="" id="imgBannerID" style=" width:325px;margin-left: 5px;margin-top: 5px;"/>
        </div>
        <div id="lnk_title">
        </div>
        <div id="text" style="margin-top: -452px; margin-left: 320px; width: 380px;">
            <div class="logo1" style="margin-bottom: 53px;">
                <img id="boutiquelogoId" src="../images/loginImages/boutique-logo.png" style="margin: 0 auto;" />                
            </div>
            <span style="margin-left: 39px;font-size:22px; font-weight:600;">Forgot Password</span>
            <div style="margin-left:38px;">
                <%--<span>
                    Forgot Password</span>--%>
                <asp:PasswordRecovery ID="pwd_recovery" runat="server" UserNameTitleText="" OnSendingMail="pwd_recovery_SendingMail"
                    Style="width: 101%;margin-top: 6px;">
                    <UserNameTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0">
                                        <tr>
                                            <td align="center" colspan="2" style="font-size: 15px;">
                                                <span style="">Enter your Email to receive your password.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">
                                                </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" oncopy="return false" onpaste="return false" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="pwd_recovery">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2" style="padding-left: 5px;">
                                                <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="pwd_recovery"
                                                    Style="background-color: #193062; height: 35px; border-radius: 6px; font-size:16px; border: none; width:254px;margin-left: 24px; margin-top:64px;" CssClass="submitButton" />
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
    </div>
</asp:Content>
