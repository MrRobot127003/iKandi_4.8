<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SeasonForm.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.SeasonForm" %>



<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style>
  .header-text-back
    {
          padding: 0px 0px !important;
     }
</style>
 <script type="text/javascript">
     function ValidateControl() {

         if (document.getElementById('<%=txtSeasonName.ClientID %>').value.replace(/\s+/g, '') == '') {
             document.getElementById('<%=lblSeasonNameV.ClientID %>').innerHTML = "SEASON NAME.";
             document.getElementById('<%=txtSeasonName.ClientID %>').focus();
             return false;
         }
         //         if (document.getElementById('<%=txtSeasonStartDate.ClientID %>').value.replace(/\s+/g, '') == '') {
         //             document.getElementById('<%=lblSDateV.ClientID %>').innerHTML = "START DATE.";
         //             document.getElementById('<%=txtSeasonStartDate.ClientID %>').focus();
         //             return false;
         //         }
         //         if (document.getElementById('<%=txtSeasonEndDate.ClientID %>').value.replace(/\s+/g, '') == '') {
         //             document.getElementById('<%=lblEDateV.ClientID %>').innerHTML = "END DATE.";
         //             document.getElementById('<%=txtSeasonEndDate.ClientID %>').focus();
         //             return false;
         //         }                
         return true;
     }


     function CheckClientList() {
         var checkboxCollection = document.getElementById('<%=chkAllClient.ClientID %>').getElementsByTagName('input');

         for (var i = 0; i < checkboxCollection.length; i++) {
             if (checkboxCollection[i].type.toString().toLowerCase() == "checkbox") {
                 checkboxCollection[i].checked = document.getElementById('<%=chkSelectAll.ClientID %>').checked;
             }
         }
     }
 </script>
 <style>
     /*updated css by bhrata 2 jan 2019*/
   input[type="checkbox"]
   {
       position:relative;
       top:3px;
    }
 </style>
<h2  class="header-text-back"> Season Form</h2>
    
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UP" runat="server">
<ContentTemplate>
    
    
     <div class="form_box" style="background:#fff;">  
              
        <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin:0px;">
            <tr>
              <td class="td-sub_headings" width="10%"><asp:HiddenField ID="hdnIdStatus" runat="server" Value="0" />
                    <asp:Label ID="lblSeasonName" runat="server" Text="Season Name"></asp:Label> <span class="da_astrx_mand">*</span></td>
              <td class="inner_tbl_td" width="10%"><asp:TextBox Width="130px" ID="txtSeasonName" runat="server"></asp:TextBox>
                 
                  <br />
                  <asp:Label ID="lblSeasonNameV"  ForeColor="Red" runat="server" ></asp:Label>
                 
              </td>
              <td class="td-sub_headings" width="10%"> <asp:Label ID="lblAllClient" runat="server" Text="Clients"></asp:Label> <span class="da_astrx_mand">*</span> <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" onClick="CheckClientList();" /></td>
              <td class="td-sub_headings" width="10%" valign="bottom">
                  <asp:Label ID="lblCleintV" ForeColor="Red" runat="server" ></asp:Label>
                </td>
              <td class="td-sub_headings" width="10%" valign="bottom"> 
               
                 </td>
              <td class="td-sub_headings" width="10%" valign="bottom">
                  &nbsp;</td>
              <td class="td-sub_headings" width="10%" valign="bottom">&nbsp;</td>
              </tr>
            <tr>
              <td class="td-sub_headings"><asp:Label ID="lblSeasonStartDate" runat="server" Text="Season Start Date"></asp:Label> <span class="da_astrx_mand">*</span></td>
              <td class="inner_tbl_td"><asp:TextBox Width="16px" ID="txtSeasonStartDate" Visible="false" 
                      CssClass="date-picker date_style da_input_dafo" runat="server" Height="16px"></asp:TextBox>
                 
                  <asp:DropDownList ID="ddlMonthFrom" runat="server" AutoPostBack="true" 
                      onselectedindexchanged="ddlMonthFrom_SelectedIndexChanged">
                  </asp:DropDownList>
                  <asp:DropDownList ID="ddlDateFrom" runat="server">
                  </asp:DropDownList>
                 
                  <br />
                  <asp:Label ID="lblSDateV"  ForeColor="Red" runat="server" ></asp:Label>
                 
              </td>
              <td class="inner_tbl_td" colspan="5" rowspan="4">
              <asp:CheckBoxList ID="chkAllClient" CellPadding="2" CellSpacing="2" runat="server" >                        
              </asp:CheckBoxList></td>
            </tr>
            <tr>
              <td class="td-sub_headings"> <asp:Label ID="lblSeasonEndDate" runat="server" Text="Season End Date"></asp:Label> <span class="da_astrx_mand">*</span></td>
              <td class="inner_tbl_td"><asp:TextBox Width="16px" ID="txtSeasonEndDate" Visible="false" 
                      CssClass="date-picker date_style da_input_dafo" runat="server" Height="17px"></asp:TextBox>
                 
                  <asp:DropDownList ID="ddlMonthTo" runat="server" AutoPostBack="true" 
                      onselectedindexchanged="ddlMonthTo_SelectedIndexChanged">
                  </asp:DropDownList>
                  <asp:DropDownList ID="ddlDateTo" runat="server">
                  </asp:DropDownList>
                 
                  <br />
                  <asp:Label ID="lblEDateV"  ForeColor="Red" runat="server" ></asp:Label>
                  
              </td>
            </tr>
            <tr>
              <td class="td-sub_headings"> <asp:Label ID="lblIsActivate" Visible="false" runat="server" Text="Is Active"></asp:Label></td>
              <asp:CheckBox ID="chkIsActivate" Visible="false" Checked="true" runat="server" />
            </tr>
           
            </table>
            </div> 
       

</ContentTemplate>
</asp:UpdatePanel>       
       
       
       
<asp:Button ID="btnSubmit" runat="server" CssClass="da_submit_button submit" 
    Text="Submit" OnClientClick="javascript: return ValidateControl()" 
    onclick="btnSubmit_Click"  />    

    
   
