<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveDetails.aspx.cs" Inherits="iKandi.Web.LeaveDetails"  MasterPageFile="~/layout/Secure.Master" %>



<%@ Register src="../../UserControls/Lists/LeaveDetailsControl.ascx" tagname="LeaveDetailsControl" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">

     
 
     

    <uc1:LeaveDetailsControl ID="LeaveDetailsControl1" runat="server" />

     
 
     

</asp:Content>
