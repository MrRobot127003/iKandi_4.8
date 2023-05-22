<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master"
    CodeBehind="ChangePassword.aspx.cs" Inherits="iKandi.Web.ChangePassword" %>
            
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="Server">
  <style>
    #text
    {
         width: 500px;
        margin: 0px auto;
        box-shadow: 0px 2px 2px 5px #cfcfcf;
        text-align: center; 
       padding: 3px 30px 30px;
       border-radius: 5px;
        }
        #main_content {
    text-align: center;
    }
   #text input[type="password"]
    {
            height: 25px;
            margin: 5px 0px;
            border: 0px;
            border-bottom: 1px solid #ccc;
            background: #fff;
     }
      #text input[type="password"]:focus
    {
            height: 25px;
            margin: 5px 0px;
            border: 0px;
            border-bottom: 1px solid #ccc;
            background: #fff;
     }
     :focus {
    outline: -webkit-focus-ring-color auto 0px;
}

     table {
   
    width: 80%;
    margin: 0 auto;
}
input:-internal-autofill-selected {
 
    background-color: #fff !important;
    background-image: none !important;
  
}
  </style>
    <div>
        <div id="lnk_title"></div>
        <div id="text">
          <h1>Change Password</h1>

           <asp:ChangePassword ID="ChangePassword1" runat="server" DisplayUserName="false" CancelDestinationPageUrl="~/public/login.aspx"  ContinueDestinationPageUrl="~/public/login.aspx">
            </asp:ChangePassword>

        <div id="holder" style="margin-top: 10px;">
         <asp:LinkButton id="LinkButton1"  Text="Forgot Password!" OnClick="LinkButton_Click" runat="server"/>
        </div>         
      
</asp:Content>
