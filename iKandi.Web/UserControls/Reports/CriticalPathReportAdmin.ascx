<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CriticalPathReportAdmin.ascx.cs"
 Inherits="iKandi.Web.UserControls.Reports.CriticalPathReportAdmin" %>
 
 <script type="text/javascript">

     var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
     var proxy = new ServiceProxy(serviceUrl);

     $(function () {

         $('input.Client-All', '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestRegisteredClient", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });
         $('input.Client-All', '#main_content').result(function () {

             var f = $(this).val().split('[');
             $(this).val(f[0]);

             proxy.invoke("SuggestClientSIds", { StyleNumber: f[0] },
                     function (result) {

                         if (result == null || result == '')
                             return;
                     });
         });


         //     $('input.Client-All', '#main_content').autocomplete("/Webservices/iKandiService.asmx/SuggestRegisteredTradeNames", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });
         //              $('input.Client-All', '#main_content').result(function() {              
         //                    var f = $(this).val().split('[');                                
         //                     $(this).val(f[0]);
         //              })


     });


        
        
        
        
     
</script>
<script type="text/javascript">


    function selectAll(invoker) {

        alert('hai');

    }  

</script>



<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UP" runat="server">
<ContentTemplate>
    
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="8" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1055" class="da_table_heading_bg"><span class="da_h1">Critical Path Report Admin</span></td>
        <td width="156" class="da_table_heading_bg">      
   <table width="100%" border="0" cellspacing="0" cellpadding="2">
           <tr>
              <td width="90%"><asp:DropDownList ID="ddnClient" class="input_in" runat="server" onselectedindexchanged="ddnClient_SelectedIndexChanged">
                 </asp:DropDownList> </td>
               <td width="5%"> <asp:Button ID="btn_go" runat="server" Text="Search" CssClass="da_go_button go" onclick="btn_go_Click"/></td>
           </tr>
     </table> 
        </td>
        <td width="9" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
           <table width="100%" cellpadding="0" cellspacing="0" border="0" >                                       
                <tr>
                <td>  
               <asp:GridView ID="grdCriticalPath" runat="server" AutoGenerateColumns="False" 
                     onrowdatabound="grdCriticalPath_RowDataBound" Height="90%" Width="100%" CssClass="da_header_heading">
                 <Columns>
                  <asp:TemplateField HeaderText="Heading" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="da_table_tr_bg" >
                               <ItemTemplate>
                               <div style="padding-right: 12px;">
                                      <%#Eval("fieldheading")%>
                                      </div>
                               </ItemTemplate>                                         

<ControlStyle ></ControlStyle>

                              <ItemStyle HorizontalAlign="Left"></ItemStyle>
                          </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Field Name" HeaderStyle-Width="40%" ItemStyle-CssClass="da_table_tr_bg"  ItemStyle-HorizontalAlign="Left"  >
                               <ItemTemplate>
                               <div style="padding-right: 12px;">
                                      <%#Eval("FieldName")%>
                                      </div>
                               </ItemTemplate>                                         

<ControlStyle></ControlStyle>

                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                          </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Head Id" Visible="false" >
                               <ItemTemplate>
                                      <%#Eval("headid")%>
                               </ItemTemplate>                                         
                          </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Id" Visible="false" >
                               <ItemTemplate>
                                
                                      <%#Eval("Id")%>
                               </ItemTemplate>                                         
                          </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Is Permitted" HeaderStyle-Width="20%"  ItemStyle-HorizontalAlign="Center" >
                               <ItemTemplate>
                                   <asp:CheckBox ID="chkid" runat="server" AutoPostBack="true" OnCheckedChanged="chkid_CheckChange" Checked='<%# Convert.ToBoolean(Eval("IsChecked")) %>' />
                               </ItemTemplate>                                         

<ControlStyle ></ControlStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                          </asp:TemplateField>  
                                                   
                 </Columns>
                       
                 </asp:GridView>
                <br />
                
       </td>
                </tr>
                <tr><td>               
                 <asp:Button ID="btn_save" CssClass="da_submit_button" Text="Save"  runat="server" onclick="btn_save_Click" />
                </td></tr>
           </table>

</ContentTemplate>
</asp:UpdatePanel>