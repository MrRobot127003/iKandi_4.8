<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QAStatus.aspx.cs" MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.QAStatus" %>

<%@ Register src="~/UserControls/Lists/QAStatusPopup.ascx" tagname="QAStatusPopup" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

    <div>
    
        <uc1:QAStatusPopup ID="QAStatusPopup1" runat="server" />
    
    </div>
</asp:Content>
