<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Production.aspx.cs" Inherits="iKandi.Web.Production"  MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" %>



<%@ Register src="../../UserControls/Reports/ProductionReport.ascx" tagname="ProductionReport" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    

    
    

    <uc1:ProductionReport ID="ProductionReport1" runat="server" />
    

    
    

    </asp:Content>
