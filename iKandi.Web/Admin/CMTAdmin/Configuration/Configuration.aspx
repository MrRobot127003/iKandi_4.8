<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="iKandi.Web.Configuration" MasterPageFile="~/layout/Secure.Master"  ValidateRequest="false" %>

<%@ Register Src="~/UserControls/Configuration/ConfigurationUserControl.ascx"  TagName="ConfigurationUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">
    <table width="100%" align="center" class="item_list">
        <tr>
            <td>
                <div class="headingtext">
                    <h2 style="margin:0px; padding:0px"> <asp:Label ID="lblHeading" Text="Configuration" runat="server" /></h2>
                </div>
            </td>
        </tr>
        <tr>
            <td class="content_middle" width="100%">
                <uc1:ConfigurationUserControl ID="ConfigurationUserControl1"  runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
