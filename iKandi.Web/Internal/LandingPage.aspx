<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="iKandi.Web.landing_page"
    MasterPageFile="~/layout/Secure.Master" %>

<asp:Content ContentPlaceHolderID="cph_main_content" runat="server">
    <div>
        Welcome!<br />
        <br />
        You can change your password by <a href="ChangePassword.aspx">clicking here</a>.
        <br /><br />
        <a href="Users/UserListing.aspx">Click here</a> to go to the Users list. 
        <br /><br />
        <a href="Client/ClientListing.aspx">Click here </a> to go to the Clients list.
        <br />
        
    </div>
    <br />
</asp:Content>
