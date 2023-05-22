<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="ClosedResolutionTask.aspx.cs" Inherits="iKandi.Web.Internal.Reports.ClosedResolutionTask" %>

<%@ Register Src="~/UserControls/Reports/ClosedResolutionTask.ascx" tagname="ClosedResolutionTask" tagprefix="drt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

     <drt:ClosedResolutionTask  ID="ClosedResolutionTask1" runat="server" />
    

</asp:Content>
