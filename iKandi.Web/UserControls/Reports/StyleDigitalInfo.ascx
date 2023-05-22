<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StyleDigitalInfo.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.StyleDigitalInfo" %>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <caption class="caption_headings">Style Digital Information</caption>
  <tr>
    <td class="tbl_bordr">
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
   
      <tr>
        <td>
        
          
          <table width="100%" border="0" align="center" cellspacing="5" cellpadding="0" style="margin:0px;">
            <tr class="td-sub_headings">
              <td valign="bottom" style="width:20%">Buying House <asp:Label   ID="lblTag" style="display:none;"
               CssClass="lbTag" ForeColor="Red" runat="server" Text="Select BuyingHouse"></asp:Label></td>
              <td valign="bottom" style="width:20%">Client&nbsp; <asp:Label CssClass="lb" style="display:none;" ForeColor="Red"  ID="lblSym" runat="server" 
                      Text="Select Client"></asp:Label>
                </td>
                <td valign="bottom" style="width:40%">Date Range <asp:Label  ID="lblCon" CssClass="lbc" style="display:none;" runat="server" ForeColor="Red" Text="Invalid Date Range"></asp:Label>
                </td>
              
              </tr>
            <tr>
              <td>
                <asp:DropDownList ID="ddlBuyingHouse" runat="server" Width="100%"  AutoPostBack="true"
                      OnSelectedIndexChanged="ddlBuyingHouse_SelectedIndexChanged"></asp:DropDownList>
              </td>
              <td>
                <asp:ListBox ID="ddlClient" runat="server" Width="100%" SelectionMode="Multiple"></asp:ListBox>
              </td>
              <td>
                <asp:RadioButton ID="rdoExfactory" runat="server" Text="Order Date" GroupName="DateType" Checked="true"/>
                <asp:RadioButton ID="rdoDC" runat="server" Text="DC" GroupName="DateType" />
                &nbsp;<asp:Label ID="lblfrom" Text="From :" runat="server"></asp:Label> 
                <asp:TextBox id="txtFrom" runat="server" CssClass="date_style date-picker"></asp:TextBox>
                <asp:Label ID="Label1" Text="To :" runat="server"></asp:Label> 
                <asp:TextBox id="txtTo" runat="server" CssClass="date_style date-picker"></asp:TextBox>
              </td>
               <td> 
                   <asp:Button ID="btnsubmit" Text="Generate PDF" 
                       CssClass="da_submit_button"   
                       runat="server" Width="169px" onclick="btnsubmit_Click"/> 
                       </td>
              </tr>
           
  
</table>
        </td>
    </tr>
</table>
</td>
</tr>
</table>
