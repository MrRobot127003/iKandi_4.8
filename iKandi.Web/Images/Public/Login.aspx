<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="iKandi.Web.Login" MasterPageFile="~/layout/Public.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">
<style type ="text/css">
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
        .submit
        {
            color:#fff !important;
            padding: 3px 7px 4px !important;
            font-size: 13px !important;
            border-radius: 2px !important;
        }
        .submit:hover
        {
            cursor:pointer;
            padding: 3px 7px 4px !important;
            font-size: 13px !important;
            border-radius: 2px !important;
            color:Yellow !important;
        }
</style>
 <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
 <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
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
    $(document).ready(function () {

        $("input").bind("keydown", function (event) {
            // track enter key
            var keycode = (event.keyCode ? event.keyCode : (event.which ? event.which : event.charCode));
            if (keycode == 13) { // keycode for enter key
                // force the 'Enter Key' to implicitly click the Update button
                $('.submit').click();
                return false;
            } else {
                return true;
            }
        }); // end of function

    }); // end of document ready

        </script>
        <div id="spinnL"></div>
    <div id="banner_cor">
        <div id="holder">
        </div>
      
        <div id="text">
            <h1>
                User Login</h1>
                
            <asp:Login ID="Login1" runat="server" onloggingin="Login1_LoggingIn" 
                                onloginerror="Login1_LoginError" onloggedin="Login1_LoggedIn" 
                                onauthenticate="Login1_Authenticate"  style="border:1px solid #ccc; padding:10px;">
                <LayoutTemplate> 
                
                    <div id="loginform">
                        <div id="lfr1">
                            Email ID
                            <label>
                                <asp:TextBox ID="UserName" runat="server" size="8" maxlength="50" Width="180px"></asp:TextBox> 

                                <asp:DropDownList runat="server" ID="Domain">
                                    <asp:ListItem Value="1" Text="@ikandi.org.uk"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="@boutique.in" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Client"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Partner"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Supplier"></asp:ListItem>
                                </asp:DropDownList>
                              <%--  <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>--%>
                            </label>
                        </div>
                        <div id="lfr1"> 
                            Password
                            <label>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" size="26" Width="180px"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>--%>
                            </label>
                                <div id="subtext">          
            <%--<a id="A1" href="~/public/forgotpassword.aspx" runat="server">Forgot Password!</a>--%>
            <asp:LinkButton id="LinkButton1"  Text="Forgot Password!" OnClick="LinkButton_Click" runat="server"/>
            </div>
                        </div>
                        <div style="color: Red;">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
                        <div id="lfr2">
                            <label>
                                                 
     <asp:Button ID="LoginButton" CssClass="submit" OnClientClick="SpinnShow();"  runat="server" CommandName="Login" Text="Submit" ValidationGroup="ctl00$Login1" />                                             
                                 
                                
                            </label>
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    
    </div>
    <script type="text/javascript">
        $(window).load(function () { $("#spinnL").fadeOut("slow"); }); //Gajendra     
    </script>
</asp:Content>
