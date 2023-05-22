<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmFactoryWiseAdmin.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.frmFactoryWiseAdmin" %>
<style type="text/css">
    .style1
    {
        width: 12%;
    }
    .style2
    {
        width: 21%;
    }
    .style3
    {
        width: 22%;
    }
    .font
    {
        font-size:13px;
    }
</style>

<table width="1250" border="0" align="center" cellpadding="0" cellspacing="0">
  <caption class="caption_headings">Currency Admin</caption>
  
  <tr>
    <td class="tbl_bordr">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
   
      <tr>
        <td colspan="2">
        
          
          <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin:0px;">
            <tr class="td-sub_headings">
              <td valign="bottom" class="style3">Currency Type <asp:Label   ID="lblTag" style="display:none;"
               CssClass="lbTag" ForeColor="Red" runat="server" Text="Enter Currency Tag."></asp:Label></td>
              <td valign="bottom" class="style2">Currency Symbol&nbsp; <asp:Label CssClass="lb" style="display:none;" ForeColor="Red"  ID="lblSym" runat="server" 
                      Text="Enter Currency Symbol."></asp:Label>
                </td>
              <td width="12%" valign="bottom">Costing Conversion<br /> <%--Conversion Rate in INR--%>
                  <asp:Label  ID="lblCon" CssClass="lbc" style="display:none;" runat="server" ForeColor="Red" Text="Enter Costing Conversion."></asp:Label>
                </td>
              <td width="12%" valign="bottom" class="style3">Export Conversion&nbsp;
              <asp:Label  ID="lblExpCon" CssClass="lbEc" style="display:none;" runat="server" ForeColor="Red" Text="Enter Export Conversion."></asp:Label>
              </td>
              <td></td>
            
              </tr>
            <tr>
              <td class="style3"><input style="text-transform:none;" runat="server" onkeypress="javascript:RemoveAlert('lbTag')" id="txtTag" name="" type="text" maxlength="10"   class="input_in"/></td>
              <td class="style2"><input style="text-transform:none;" runat="server" onkeypress="javascript:RemoveAlert('lb')" id="txtSym" name="" type="text" maxlength="3"  class="input_in"/></td>
              <td class="style1"><input style="text-transform:none;" runat="server" onkeypress="javascript:RemoveAlert('lbc')" id="txtCon" onkeyup="extractNumber(this,2,true);"  name="input2"  type="text"   class="input_in"/></td>
              <td class="style1"><input style="text-transform:none;" runat="server" onkeypress="javascript:RemoveAlert('lbEc')" id="txtExpCon" onkeyup="extractNumber(this,2,true);" name="input3"  type="text"   class="input_in" /></td>
              <td>
              <asp:RadioButtonList ID="rbtnIsCosting" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0" Selected="True">Price Quoted BIPL</asp:ListItem>
              <asp:ListItem Value="1">Costing BIPL</asp:ListItem>
              </asp:RadioButtonList>
              </td>
            <%--   <td class="style1" align="left"> <asp:Button ID="btnsubmit" Text="submit" 
                       OnClientClick="javascript:return valid();" CssClass="da_submit_button"   
                       runat="server" onclick="btnsubmit_Click" 
            /> </td>--%>
             
             
              </tr>
           
            <tr  >
              <td height="35" colspan="5" align="left" style="font-size:16px;">
              <TABLE  border="0" cellSpacing="0" cellPadding="2" width="40%">
  <TBODY>

 
     </TBODY>

          
          
          
        </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
 
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="grdCurrency" />
     </Triggers>
     <ContentTemplate>
<table width="1250" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td class="da_table_heading_bg"><span class="da_h1">Currency Admin</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td valign="top">
         
    <!--table2-->
 <table width="100%" border="0" cellspacing="0" cellpadding="2" >
                  
                    <tr >
                    <td align="left">
                  <%--  <asp:GridView ID="grdCurrency" runat="server" CssClass="font" 
                            AutoGenerateColumns="False" Width="100%" 
                            HeaderStyle-BackColor="#bdc3cf" 
                            
                            HeaderStyle-HorizontalAlign="Center" 
                           HeaderStyle-Font-Size="13px"
                            onrowcancelingedit="grdCurrency_RowCancelingEdit" 
                            onrowediting="grdCurrency_RowEditing" 
                            onrowupdating="grdCurrency_RowUpdating" onrowdatabound="grdCurrency_RowDataBound" 
                          >
                       <Columns>
                       
                       
                        <asp:TemplateField HeaderText="Currency Type" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="15%" >
                            <ItemTemplate>  <div style="text-align:center; ">
                                  <%-- <%#Eval("CurrencyType")%>--%>
                                    </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="text-align:center; ">
                               <%--  <asp:TextBox ID="txtCurrencyType" style="text-align:center;" CssClass="conType"  runat="server" Text='<%#Eval("CurrencyType")%>'></asp:TextBox>--%>
                             <%--    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("Id") %>' /></div>--%>
                             </EditItemTemplate>   
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Currency Symbol" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="15%" >
                            <ItemTemplate> <div style="text-align:center; ">
                            <%-- <asp:Label runat="server" ID="txtCurrencySymbol" Text='<%#Eval("CurrencySymbol")%>' ></asp:Label>--%>
                                 </div>
                            </ItemTemplate> 
                           
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Costing Conversion"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="15%" >
                            <ItemTemplate> <div style="text-align:center; "> 
                           
                               <%--  <%#Eval("ConversionRate")%></div>--%>
                            </ItemTemplate> 
                         <EditItemTemplate><div style="text-align:center; ">
                              <%--   <asp:TextBox ID="txtConversionRate" style="text-align:center;" CssClass="ConRate"  runat="server" Text='<%#Eval("ConversionRate")%>'></asp:TextBox></div>--%>
                             </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Export Conversion"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="15%" >
                            <ItemTemplate> <div style="text-align:center; "> 
                           
                              <%--   <%#Eval("ExportConversionRate")%></div>--%>
                            </ItemTemplate> 
                         <EditItemTemplate><div style="text-align:center; ">
                               <%--  <asp:TextBox ID="txtExportConversionRate" style="text-align:center;" CssClass="EConRat"  runat="server" Text='<%#Eval("ExportConversionRate")%>'></asp:TextBox></div>--%>
                             </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=""  HeaderStyle-Font-Bold="false" HeaderStyle-Width="25%" >
                            <ItemTemplate> <div style="text-align:center; "> 
                           <asp:RadioButtonList ID="rbtnPriceQuoted1" RepeatDirection="Horizontal" runat="server" >
                               <asp:ListItem Value="0">Price Quoted BIPL</asp:ListItem>
                               <asp:ListItem Value="1">Costing BIPL</asp:ListItem>
                               </asp:RadioButtonList>
                                <%-- <%#Eval("ExportConversionRate")%></div>--%>
                              <%-- <asp:HiddenField ID="hdnPriceQuoted" runat="server" Value='<%#Eval("PriceQuoted") %>' />--%>
                            </ItemTemplate> 
                         <EditItemTemplate><div style="text-align:center; ">
                               <asp:RadioButtonList ID="rbtnPriceQuotedEdit" RepeatDirection="Horizontal" runat="server" CssClass="Price" >
                               <asp:ListItem Value="0">Price Quoted BIPL</asp:ListItem>
                               <asp:ListItem Value="1">Costing BIPL</asp:ListItem>
                               </asp:RadioButtonList>
                           <%--    <asp:HiddenField ID="hdnPriceQuotedEdit" runat="server" Value='<%#Eval("PriceQuoted") %>' />--%>
                             </EditItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Action"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%"  >
                          <ItemTemplate><div style="text-align:center;">
                            <asp:LinkButton ID="lnkEdit" ForeColor="black" runat="server" CommandName="Edit">Edit</asp:LinkButton>                    
                   </div>  </ItemTemplate>
                     <EditItemTemplate><div style="text-align:center;">
                        <asp:LinkButton ID="lnkUpdate" ForeColor="black" runat="server" CommandName="Update" OnClientClick="javascript:return IsValidate();">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkCancel" ForeColor="black" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                     </div></EditItemTemplate>
                                                
                      </asp:TemplateField>      
                        
                    </Columns>
                    
                    
                    
                    </asp:GridView>--%>
                    </td>                    
              </tr>
                 
            </table>
      
<!--end--> 

</td>
  </tr>
</table> 
    </ContentTemplate>
    </asp:UpdatePanel>
    </td>
    
  </tr>
  
</table>
</td>
</tr>
</table>