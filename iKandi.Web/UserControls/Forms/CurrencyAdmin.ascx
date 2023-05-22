<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrencyAdmin.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.CurrencyAdmin" %>



<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    .style1
    {
        width: 12%;
    }
    .style2
    {
        width: 18%;
    }
    .style3
    {
        width: 18%;
    }
    .font
    {
        font-size:13px;
    }
    .header-text-back
    {
            padding: 3px 0px;
            margin: 0px;
            font-size: 15px;
     }
     .main_tbl_wrapper
     {
         border:0px;
      }
      .tbl_bordr
      {
          border-color:#999;
       }
       #ctl00_cph_main_content_CurrencyAdmin1_UpdatePanel1
       {
            padding: 0px 5px;
        }
        .item_list td
        {
            border-color:#e4e0e0;
         }
        .item_list td:first-child
        {
            border-left-color:#999;
         }
         .item_list td:last-child
        {
            border-right-color:#999;
         }
         .item_list tr:last-child > td
        {
            border-bottom-color:#999;
         }
         td input[type="radio"]
         {
             position:relative;
             top:2px;
          }
          .RadioBorder
          {
              width:100%;
           }
           .item_list td .RadioBorder td
           {
              border:0px;
             }
</style>





<script type="text/javascript">

    function extractNumber(obj, decimalPlaces, allowNegative) {
        var temp = obj.value;

        // avoid changing things if already formatted correctly
        var reg0Str = '[0-9]*';
        if (decimalPlaces > 0) {
            reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
        } else if (decimalPlaces < 0) {
            reg0Str += '\\.?[0-9]*';
        }
        reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
        reg0Str = reg0Str + '$';
        var reg0 = new RegExp(reg0Str);
        if (reg0.test(temp)) return true;

        // first replace all non numbers
        var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
        var reg1 = new RegExp(reg1Str, 'g');
        temp = temp.replace(reg1, '');

        if (allowNegative) {
            // replace extra negative
            var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
            var reg2 = /-/g;
            temp = temp.replace(reg2, '');
            if (hasNegative) temp = '-' + temp;
        }

        if (decimalPlaces != 0) {
            var reg3 = /\./g;
            var reg3Array = reg3.exec(temp);
            if (reg3Array != null) {
                // keep only first occurrence of .
                //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
                var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
                reg3Right = reg3Right.replace(reg3, '');
                reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
                temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
            }
        }

        obj.value = temp;
    }
    function RemoveAlert(obj) {
        $("." + obj).attr("style", "Display:None");
    }
    function valid() {
        if (document.getElementById('<%=txtTag.ClientID %>').value.replace(/\s+/g, '') == "") {
            document.getElementById('<%=lblTag.ClientID %>').style.display = 'block';
            $('.lbTag').attr("style", "Color:Red");
            document.getElementById('<%=lblTag.ClientID %>').style.fontSize = '11px';
            return false;
        }
        if (document.getElementById('<%=txtSym.ClientID %>').value.replace(/\s+/g, '') == "") {
            document.getElementById('<%=lblSym.ClientID %>').style.display = 'block';
            $('.lb').attr("style", "Color:Red");
            document.getElementById('<%=lblSym.ClientID %>').style.fontSize = '11px';
            return false;
        }
        if (document.getElementById('<%=txtCon.ClientID %>').value.replace(/\s+/g, '') == "") {
            document.getElementById('<%=lblCon.ClientID %>').style.display = 'block';
            $('.lbc').attr("style", "Color:Red");
            document.getElementById('<%=lblCon.ClientID %>').style.fontSize = '11px';
            return false;
        }
        if (document.getElementById('<%=txtExpCon.ClientID %>').value.replace(/\s+/g, '') == "") {
            document.getElementById('<%=lblExpCon.ClientID %>').style.display = 'block';
            $('.lbEc').attr("style", "Color:Red");
            document.getElementById('<%=lblExpCon.ClientID %>').style.fontSize = '11px';
            return false;
        }
        //        debugger;
        //        if (document.getElementById('<%=txtCon.ClientID %>').value.replace(/\s+/g, '') != "") {
        //            var temp = parseInt(document.getElementById('<%=txtCon.ClientID %>').value);
        //            if (temp == 0) {
        //                document.getElementById('<%=lblCon.ClientID %>').innerHTML = "Invalid Conversion Rate."
        //            }
        //           
        //            return false;
        //        }







    }

    function IsValidate() {
        //debugger;
        if ($('.conType').val() == "") {
            ShowHideMessageBox(true, "Enter Currency Type.");
            return false;
        }
        if ($('.ConRate').val() == "") {
            ShowHideMessageBox(true, "Enter Costing Conversion.");
            return false;
        }
        if ($('.EConRat').val() == "") {
            ShowHideMessageBox(true, "Enter Export Conversion.");
            return false;
        }

    }


    
</script>


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
               <td class="style1" align="left"> <asp:Button ID="btnsubmit" Text="Submit" 
                       OnClientClick="javascript:return valid();" CssClass="da_submit_button submit" /> </td>
             
             
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

        <h2  class="header-text-back"> Currency Admin</h2>
      
    </td>
  </tr>
  <tr>
    <td valign="top">
         
    <!--table2-->
 <table width="100%" border="0" cellspacing="0" cellpadding="2" >
                  
                    <tr >
                    <td align="left" style="padding: 4px 0px;">
                    <asp:GridView ID="grdCurrency" runat="server" CssClass="font item_list" 
                            AutoGenerateColumns="False" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" 
                           HeaderStyle-Font-Size="13px"
                            onrowcancelingedit="grdCurrency_RowCancelingEdit" 
                            onrowediting="grdCurrency_RowEditing" 
                            onrowupdating="grdCurrency_RowUpdating" onrowdatabound="grdCurrency_RowDataBound" 
                          >
                       <Columns>
                       
                       
                        <asp:TemplateField HeaderText="Currency Type" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="15%" >
                            <ItemTemplate>  <div style="text-align:center; ">
                                   <%#Eval("CurrencyType")%>
                                    </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="text-align:center; ">
                                 <asp:TextBox ID="txtCurrencyType" style="text-align:center;" CssClass="conType"  runat="server" Text='<%#Eval("CurrencyType")%>'></asp:TextBox>
                                 <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("Id") %>' /></div>
                             </EditItemTemplate>   
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Currency Symbol" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="15%" >
                            <ItemTemplate> <div style="text-align:center; ">
                             <asp:Label runat="server" ID="txtCurrencySymbol" Text='<%#Eval("CurrencySymbol")%>' ></asp:Label>
                                 </div>
                            </ItemTemplate> 
                           
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Costing Conversion"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="15%" >
                            <ItemTemplate> <div style="text-align:center; "> 
                           
                                 <%#Eval("ConversionRate")%></div>
                            </ItemTemplate> 
                         <EditItemTemplate><div style="text-align:center; ">
                                 <asp:TextBox ID="txtConversionRate" style="text-align:center;" CssClass="ConRate"  runat="server" Text='<%#Eval("ConversionRate")%>'></asp:TextBox></div>
                             </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Export Conversion"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="15%" >
                            <ItemTemplate> <div style="text-align:center; "> 
                           
                                 <%#Eval("ExportConversionRate")%></div>
                            </ItemTemplate> 
                         <EditItemTemplate><div style="text-align:center; ">
                                 <asp:TextBox ID="txtExportConversionRate" style="text-align:center;" CssClass="EConRat"  runat="server" Text='<%#Eval("ExportConversionRate")%>'></asp:TextBox></div>
                             </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=""  HeaderStyle-Font-Bold="false" HeaderStyle-Width="25%" >
                            <ItemTemplate> <div style="text-align:center; "> 
                           <asp:RadioButtonList ID="rbtnPriceQuoted1" CssClass="RadioBorder" RepeatDirection="Horizontal" runat="server" >
                               <asp:ListItem Value="0">Price Quoted BIPL</asp:ListItem>
                               <asp:ListItem Value="1">Costing BIPL</asp:ListItem>
                               </asp:RadioButtonList>
                                <%-- <%#Eval("ExportConversionRate")%></div>--%>
                               <asp:HiddenField ID="hdnPriceQuoted" runat="server" Value='<%#Eval("PriceQuoted") %>' />
                            </ItemTemplate> 
                         <EditItemTemplate><div style="text-align:center; ">
                               <asp:RadioButtonList ID="rbtnPriceQuotedEdit" RepeatDirection="Horizontal" runat="server" CssClass="Price" >
                               <asp:ListItem Value="0">Price Quoted BIPL</asp:ListItem>
                               <asp:ListItem Value="1">Costing BIPL</asp:ListItem>
                               </asp:RadioButtonList>
                               <asp:HiddenField ID="hdnPriceQuotedEdit" runat="server" Value='<%#Eval("PriceQuoted") %>' />
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
                    
                    
                    
                    </asp:GridView>
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