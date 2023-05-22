<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SeasonList.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.SeasonList" %>

<script type="text/javascript">
   
  
  
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" /> 
<style>
   .item_list th {
    min-width: 150px;
}
 .item_list th:nth-child(5) {
    min-width: 50px;
}
td span
{
    display:inherit !important;
    width:99% !important;
 }
  .item_list td:nth-child(4) {
    text-align: left;
    padding-left: 5px !important;
}
.header-text-back
{
      padding: 0px 0px !important;
 }
</style>
<h2 class="header-text-back"> Season List </h2>
  <div style="text-align:center;">
  
      <asp:GridView ID="grdAllSeason" runat="server" AutoGenerateColumns="False" Width="100%" 
          CssClass="item_list  da_header_heading" 
          onrowdatabound="grdAllSeason_RowDataBound">
      <Columns>
                  
                   <asp:BoundField DataField="SeasonName" HeaderText="Season Name" />
                   <asp:BoundField DataField="SeasonStartDate" HeaderText="Season Start Date" />
                   <asp:BoundField DataField="SeasonEndDate" HeaderText="Season End Date" />
                 
                     <asp:TemplateField HeaderText="IsActive" Visible="false" >
                               <ItemTemplate>
                               <asp:HiddenField ID="hdnID" runat="server" Value='<%#Eval("Id") %>' />
                               <div style="text-align:left;">
                                  <asp:CheckBox ID="IsActiveClient" Checked='<%# Convert.ToBoolean(Eval("IsActive")) %>' Enabled="false" runat="server" />
                                   
                                </div>
                               </ItemTemplate>                                         
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Clients" ControlStyle-Width="200px" HeaderStyle-Font-Size="Larger" >
                               <ItemTemplate>
                               
                               
                                  <asp:Label ID="lbl" runat="server" ></asp:Label>
                                 
                               
                               </ItemTemplate>                                         
                   </asp:TemplateField>
                  
                    <asp:HyperLinkField  DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~/internal/client/seasonform.aspx?cid={0}"
                Text="Edit" ItemStyle-CssClass="da_edit_delete_link" />                                                                     
      </Columns>
        <EmptyDataTemplate> 
                  <table border="0"  cellpadding="0" cellspacing="0"> 
                    <tr> 
                    <div style="text-align:center;">
                      <td>Season Not Found.</td>
                     </div>
                    </tr>                     
                  </table> 
                </EmptyDataTemplate> 
      
      </asp:GridView>
  
  </div>
  
  