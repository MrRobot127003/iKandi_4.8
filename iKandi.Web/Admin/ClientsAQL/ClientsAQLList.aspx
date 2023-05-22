<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientsAQLList.aspx.cs" Inherits="iKandi.Web.ClientsAQLList" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="~/UserControls/Forms/ClientsAQL.ascx" tagname="ClientsAQL" tagprefix="uc1" %>


<asp:Content ID="Content" ContentPlaceHolderID="cph_main_content" runat="server">
 
      
    <uc1:ClientsAQL ID="ClientsAQL1" runat="server" />
 
      
    </asp:Content>