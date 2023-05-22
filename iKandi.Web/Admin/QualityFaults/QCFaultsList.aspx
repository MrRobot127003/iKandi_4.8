<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QCFaultsList.aspx.cs" Inherits="iKandi.Web.QCFaultsList" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register src="~/UserControls/Forms/QCFaults.ascx" tagname="QCFaults" tagprefix="uc1" %>


<asp:Content ID="Content" ContentPlaceHolderID="cph_main_content" runat="server">
 
      
    <uc1:QCFaults ID="QCFaults1" runat="server" />
 
      
    </asp:Content>