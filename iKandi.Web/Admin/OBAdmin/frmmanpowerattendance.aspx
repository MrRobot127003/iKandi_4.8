<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="frmmanpowerattendance.aspx.cs" Inherits="iKandi.Web.Admin.OBAdmin.frmmanpowerattendance" %>
<%@ Register src="../../UserControls/Forms/Usermanpowerattendence.ascx" tagname="Usermanpowerattendence" tagprefix="uc1" %>
<%@ Register src="../../UserControls/Forms/frmuserOtattendence.ascx" tagname="frmuserOtattendence" tagprefix="uc2" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
   
    
    
    <table width="100%">
    <tr>
    <td>
    <asp:RadioButtonList ID="rbtnAtteType" runat="server" RepeatDirection="Horizontal"  AutoPostBack="true"
            onselectedindexchanged="rbtnAtteType_SelectedIndexChanged">
    <asp:ListItem Text="Normal Working Hour Attendance" Value="1" Selected="True"></asp:ListItem>
    <asp:ListItem Text="OT Attendance" Value="2"></asp:ListItem>
    </asp:RadioButtonList>
    </td>
    </tr>
        <tr>
            <td align="left">
              <uc1:Usermanpowerattendence ID="Usermanpowerattendence1" runat="server" />
            </td>
        </tr>
        <tr>
   <td align="left" >
   <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
              <uc2:frmuserOtattendence ID="frmuserOtattendence1" runat="server" />
            </td>
    
    </tr>
      
             
    </table>
</asp:Content>
