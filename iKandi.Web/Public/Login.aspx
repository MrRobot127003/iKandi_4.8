<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="iKandi.Web.Login" MasterPageFile="~/layout/Public.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">
 <style type="text/css">
@import url('https://fonts.googleapis.com/css2?family=Roboto+Slab:wght@300;400&display=swap');
    #spinnL {
     position: fixed;
     left: 0px;
     top: 0px;
     width: 100%;
     height: 100%;
     z-index: 9999;
     background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #ffffff;
}
 body {
     height: 100%;
     width: 100%;
     overflow-x: hidden;
     font-family: Arial, Helvetica, sans-serif;
     font-size: 16px;
     background-color: #dadadacc;
}
 label {
     margin-bottom: 3px;
}
 .login-img div {
     height: 445px;
     width: 100%;
     background-size: cover;
     background-position: center;
}
 .login-img::before {
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
 .input-group > .custom-file, .input-group > .custom-select, .input-group > .form-control, .input-group > .form-control-plaintext {
     width: 1%;
}
 .logo1 img {
     border-radius: 100%;
     margin: 0 auto;
     display: block;
     box-shadow: 0 4px 8px 0 rgb(45 41 74 / 0%), 0 6px 20px 0 rgb(45 41 74 / 42%);
     margin-top: 11px;
     margin-left: 35px;
     background-color: #c5c5ca;
}
 .logo1 span {
     text-align: center;
     font-size: 26px;
     font-weight: 600;
     color: #555;
     margin-left: 9px;
}
 .row {
     margin-right: 0px;
}
 .login-form {
     margin-top: 10px;
}
 input[type="text"] {
     height: 21px;
     width: 239px;
}
 input[type="password"] {
     height: 20px;
     width: 239px;
}
 .input-group {
     margin-bottom: 4px;
}
 .input-group label {
     width: 100%;
     font-size: 15px;
     color: #555;
}
 .login-form button:hover {
     opacity: 0.7;
}
 .form-select {
     width: 130px;
     color: #555;
     height: 24px;
     border-radius: 5px;
     border-color: #bfb9b9;
     margin-top: 26px;
}
 .forgetPassword {
     color: #555 !important;
     margin-top: 5px;
     cursor: pointer;
     margin-left: 11px !important;
}
 .forgetPassword:hover {
     color: #732c2c !important;
     text-decoration: underline !important;
     font-size: 14px !important;
}
 .btn:hover {
     color: #f5f5f5;
     text-decoration: none;
}
 .submitButton {
     width: 80%;
     background-color: #193062;
     border: none;
     color: white;
     border-radius: 3px;
     cursor: pointer;
}
 .submitButton:hover {
     color: #f5f5f5 !important;
     text-decoration: none !important;
     cursor: pointer !important;
     background-color: #565675 !important;
}
 .ShowShadow {
     border: 1px solid;
     padding: 10px;
     border-radius: 6px;
     margin-left: 108px !important;
     margin-top: 36px !important;
     box-shadow: 4px 8px 10px #0e173c;
}
 .RightSideColor {
     color: #e1e1e1;
     font-family: 'Roboto Slab', serif;
}
 .imgBannerLeftSide {
     height: 429px;
     width: 320px;
     float: left;
     margin: 0px;
     padding: 0px;
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
 #ctl00_boutiquelogo {
     display: none;
}
 #ctl00_cph_main_content_pwd_recovery td {
     text-align: left;
}
 #footer {
     background-color: #193062;
     line-height: 22px;
     height: 22px;
     width: 100%;
     position: absolute;
     bottom: 0;
     left: 0;
     color:#bdbdbd;
}
 .TextboxWidth {
     width: 178px !important;
     border-radius: 3px;
     border: 1px solid #999999;
     background-color: #ffffff !important;
}
 .TextboxWidth:focus {
     box-shadow: 0 4px 8px 0 rgb(10 100 140 / 24%), 0 6px 20px 0 rgb(3 169 244 / 16%);
     background-color: #ffffff !important;
     border: 2px solid #79b579!important;
}
 .DropdownShadow {
     border-radius: 3px;
     border: 1px solid #999999;
}
 .DropdownShadow:focus {
     border-radius: 3px;
}
 .lfr1Cls {
     background: rgba(204, 204, 204, 0);
}
/*new css start*/
 #banner_cor {
     min-height: 100%;
     position: relative;
}
/* add by dinesh */
 .overlay {
     position: absolute;
     bottom: -10px;
     left: 0;
     right: 0;
     background-color: #fff;
     overflow: hidden;
     width: 100%;
     height: 100%;
     cursor:pointer;
     -webkit-transform: scale(0);
     -ms-transform: scale(0);
     transform: scale(0);
     -webkit-transition: .2s ease;
     transition: .2s ease;
     box-sizing: border-box;
     padding: 16px 0;
     line-height: 0px;
     color:gray;
     font-weight: 400;
     letter-spacing: 1px;
     border-radius: 4px;
     font-family: 'Roboto Slab', serif;
}
 .submitButton_wrapper:hover .overlay {
     -webkit-transform: scale(1);
     -ms-transform: scale(1);
     transform: scale(1);
     border:2px solid #2c2946;
     box-sizing:border-box;
}
 input[type="text"]{
     transition:0.3s aese;
     outline:none;
}
 input[type="password"]{
     transition:0.3s aese;
     outline:none;
}
 .DropdownShadow {
     transition:0.3s aese;
     outline:none;
}
 input[type="text"]:focus {
     border: 2px solid #79b579;
}
 input[type="password"]:focus {
     border: 2px solid #79b579;
}
 .DropdownShadow:focus {
     border: 2px solid #79b579;
}
 .center_bodyCentering{
     width: 100%;
     height: 100vh;
     background: linear-gradient( to right, #E1E1E1 0%, #E1E1E1 48.8%, #193062 48.8%, #193062 100% );
}
 .fa-beat {
     animation:fa-beat 5s ease infinite;
}
 @keyframes fa-beat {
     0% {
         transform:scale(1);
    }
     5% {
         transform:scale(1.25);
    }
     20% {
         transform:scale(1);
    }
     30% {
         transform:scale(1);
    }
     35% {
         transform:scale(1.25);
    }
     50% {
         transform:scale(1);
    }
     55% {
         transform:scale(1.25);
    }
     70% {
         transform:scale(1);
    }
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
//            $("#ctl00_cph_main_content_Login1_LoginButton").hover(function () {
//                alert("chk");
//                if ($("#ctl00_cph_main_content_Login1_UserName").val() != "" && $("#ctl00_cph_main_content_Login1_Password").val() != "") {
//                    $("#ctl00_cph_main_content_Login1_LoginButton").click();
//                }
//            });
        });
    </script>

    <script type="text/javascript">
        function SpinnShow() {
            $("#spinnL").css("display", "block");
        }

        var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';
        var proxy = new ServiceProxy(serviceUrl);
        $(document).ready(function () {
            proxy.invoke("DeleteSession", { session: '1' }, function (result) {
            }, onPageError, false, false);
            return false;


        });

    // all jQuery events are executed within the document ready function
//    $(document).ready(function () {

//        $("form").bind("keydown", function (event) {
//            // track enter key
//            var keycode = (event.keyCode ? event.keyCode : (event.which ? event.which : event.charCode));
//            if (keycode == 13) { // keycode for enter key
//                // force the 'Enter Key' to implicitly click the Update button
//                $('.submit').click();
//                return false;
//            } else {
//                return true;
//            }
//        }); // end of function
//        $(document).on('keypress', function (e) {
//            if (e.which == 13) {
//                alert('You pressed enter!');
//            }
//        });
//    }); // end of document ready

    </script>
    <div id="spinnL">   </div>
    <div id="banner_cor" class="ShowShadow" style="width: 740px; background-color: #e1e1e1; border-color: #e1e1e1;">
        <%--<div id="holder">
        </div>--%>
        <div id="imgBanner" class="imgBannerLeftSide">
            <img src="" id="imgBannerID" style="width: 325px; margin-left: 5px; margin-top: 5px;background-color:white;" />
        </div>
        <div id="text" class="RightSideColor" style="width: 380px;">
            <div class="logo1">
                <img id="boutiquelogoId" src="../images/loginImages/boutique-logo.png" style="    margin: 0 auto;" />
            </div>
            <span style="margin-left: 39px; font-size: 26px; font-weight: 400;letter-spacing:2px;font-family: 'Roboto Slab', serif;">Login</span>
            <%--<asp:Login runat="server" ID="LoginID" >--%>
            <asp:Login ID="Login1" defaultbutton="LoginButton" runat="server" OnLoggingIn="Login1_LoggingIn"
                OnLoginError="Login1_LoginError" OnLoggedIn="Login1_LoggedIn"
                OnAuthenticate="Login1_Authenticate" Style="border: 0px solid #ccc; padding: 10px; margin-left: 30px; margin-top: 3px;">
                <LayoutTemplate>
                    <div id="loginform">
                        <div id="lfr1" class="lfr1Cls" style="width: 365px; background: rgba(204, 204, 204, 0);">
                            <div style="float: left; margin-right: 15px">
                                <asp:Label ID="Label1" runat="server" Text="User Name" Style="font-size: 13px;"></asp:Label>
                                <div class="input-group">
                                
                                    <i class="fa fa-user fa-beat"></i>
                                    <asp:TextBox ID="UserName" CssClass="TextboxWidth" runat="server" Placeholder="Enter User Name here" Style="border: 1px solid #999999; margin-top: 6px;"></asp:TextBox>
                                </div>
                                 <asp:Label ID="Label2" runat="server" Text="Password" Style="font-size: 13px;"></asp:Label>
                                <div class="input-group">
                                 <i class="fas fa-lock fa-beat"></i>
                                    <asp:TextBox ID="Password" Placeholder="Enter Password here" Style="margin-top: 6px;" CssClass="TextboxWidth" runat="server" TextMode="Password" size="26"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <asp:DropDownList ID="Domain" CssClass="DropdownShadow" runat="server" Style="margin-left: -4px; margin-top: 23px; width: 131px; height: 24px; color: #000000">
                                    <asp:ListItem Value="1" Text="@BH"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="@boutique.in" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Client"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Partner"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Supplier"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div style="margin-top: 48.5px;">
                            <%--<label class="forgetPassword">
                                    Forgot Password</label>--%>
                            <asp:LinkButton ID="LinkButton1" Text="Forgot Password" CssClass="forgetPassword" OnClick="LinkButton_Click" runat="server" Style="margin-left: 11px; text-decoration: none; color: Black;" />
                        </div>

                        <div id="lfr2" style="text-align: center; width: 65%">
                            <label style="position:relative;" class="submitButton_wrapper">
                                <asp:Button ID="LoginButton" CssClass="submitButton" OnClientClick="SpinnShow();" runat="server" CommandName="Login" Text="Login" ValidationGroup="ctl00$Login1"
                                    Style="color: White; width: 230px;padding: 10px 0; margin-top: 26px;position:relative;letter-spacing: 2px;font-family: 'Roboto Slab', serif;box-shadow: 2px 4px 5px gray;" />
                                    <div class="overlay">Login</div>
                            </label>
                        </div>
                        <div style="color: Red; margin-left: 41px;">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </div>

                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </div>


    <script type="text/javascript">
        $(window).load(function () { $("#spinnL").fadeOut("slow"); });

        $(document).ready(function () {
            $(document).keyup(function (e) {
                if (e.keyCode === 13) {
                    $('.submit').click();
                }
            });


        });

    </script>






    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto+Slab:wght@300;400&display=swap" rel="stylesheet">

    <script src="../js/fontawesome.js" type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
</asp:Content>
