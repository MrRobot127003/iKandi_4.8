<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CMTAdmin.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.CMTAdmin" %>

<style type="text/css">
    
    .tr_class
    {
       
        background:#F9ddf4;
        
        font:normal 11px/14px arial;
    }
</style>
<script type="text/javascript">
    function test() {
        return true;
        var ss = document.getElementById('<%=txtDefaultValue.ClientID %>').value;
        if (ss == '0') {
            alert('Enter Default Value greater than 0');
            return false;
        }
        else if (ss == '') {
            alert('Enter Default Value');
            return false;
        }
        else
            return true;
    }
</script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanal1" runat="server">
<ContentTemplate>
<div style="width: 100%; vertical-align:top;" class="print-box">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="da_h1">Cut make Thread Admin</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
 <div class="form_box" style="text-transform:none;">
         
<asp:GridView ID="GrdCTM" runat="server" AutoGenerateColumns="False" 
    ShowFooter="true" 
    DataKeyNames="ID" 
    Width="100%" onrowcommand="GrdCTM_RowCommand" 
         onrowdeleting="GrdCTM_RowDeleting" >
<Columns>  
                    
    <asp:TemplateField HeaderText="SAM">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtsam" runat="server" class="textbox" Text='<%#Eval("SAM")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox  onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtsamFooter" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate> 
   </asp:TemplateField>


   
   <asp:TemplateField HeaderText="Range (0 to 499)">
            <ItemTemplate>
            <asp:HiddenField ID="ID" Value='<%#Eval("ID") %>' runat="server" />             
                    <asp:TextBox onpaste="return false" CssClass="input_in"  ID="txt499" style="text-align:center;" BorderStyle="None" runat="server" class="textbox" Text='<%#Eval("C_0_499")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
            <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in" ID="txt499Footer" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" ></asp:TextBox>
            </FooterTemplate>                                    
   </asp:TemplateField>
      
   <asp:TemplateField HeaderText="Range (500 to 999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt999" runat="server" class="textbox" Text='<%#Eval("C_500_999")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox  onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt999Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate> 
   </asp:TemplateField>
                  
   <asp:TemplateField HeaderText="Range (1000 to 1999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt1999" runat="server" class="textbox" Text='<%#Eval("C_1000_1999")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox  onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt1999Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>
   

   <asp:TemplateField HeaderText="Range (2000 to 2999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt2999" runat="server" class="textbox" Text='<%#Eval("C_2000_2999")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt2999Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>


   <asp:TemplateField HeaderText="Range (3000 to 4999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtabv4999" runat="server" class="textbox" Text='<%#Eval("C_3000_4999")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in"  style="text-align:center;" BorderStyle="None" ID="txtabv4999Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>



     <asp:TemplateField HeaderText="Range (5000 to 9999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtabv9999" runat="server" class="textbox" Text='<%#Eval("C_5000_9999")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in"  style="text-align:center;" BorderStyle="None" ID="txtabv9999Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>



       <asp:TemplateField HeaderText="Range (10,000 to 14,999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtabv14999" runat="server" class="textbox" Text='<%#Eval("C_10000_14999")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in"  style="text-align:center;" BorderStyle="None" ID="txtabv14999Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>

    <asp:TemplateField HeaderText="Range (15,000 to 19,999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtabv19999" runat="server" class="textbox" Text='<%#Eval("C_15000_19999")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in"  style="text-align:center;" BorderStyle="None" ID="txtabv19999Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>

   <asp:TemplateField HeaderText="Range (20,000 to Above)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtabvAbove" runat="server" class="textbox" Text='<%#Eval("C_Above_20000")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in"  style="text-align:center;" BorderStyle="None" ID="txtabvAboveFooter" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>





    <asp:TemplateField HeaderText="Action" >                     
                     <FooterTemplate>
                        <asp:LinkButton ID="btnAdd" CssClass="da_edit_delete_link" runat="server" CommandName="Insert" Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ></asp:LinkButton>
                     </FooterTemplate>
                     <ItemTemplate>                        
                         <asp:LinkButton ID="lnkDelete" CssClass="da_edit_delete_link" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                     </ItemTemplate>                                                                      
    </asp:TemplateField>
</Columns>
<HeaderStyle Font-Names="Arial" CssClass="da_table_td" />
 <EmptyDataTemplate> 
                  <table border="0" cellpadding="0" cellspacing="0" width="100%"> 
                    <tr>                      
                      <td>SAM</td>                                           
                      <td>Range (0 to 499)</td>
                      <td>Range (500 to 999)</td>                       
                      <td>Range (1000 to 1999)</td>                                           
                      <td>Range (2000 to 2999)</td>
                      <td>Range (3000 to 4999)</td>                       
                      <td>Range (5000 to 9999)</td>
                      <td>Range (10,000 to 14,999)</td>
                      <td>Range (15,000 to 19,999)</td>
                      <td>Range (20,000 to Above)</td>
                      <td>Action</td>
                    </tr> 
                    <tr> 
                      <td><asp:TextBox ID="txtSAMBlank" runat="server" style="text-align:center;" BorderStyle="None" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"  /></td> 
                      <td><asp:TextBox  ID="txt499Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txt999Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txt1999Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txt2999Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txt4999Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txt9999Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>                                             
                      <td><asp:TextBox ID="txt14999Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txt19999Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txtAboveBlank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>                                             
                      <td><asp:LinkButton ID="addLinkButton" runat="server" CommandName="addnew" Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' /></td>  
                    </tr> 
                  </table> 
                </EmptyDataTemplate> 




</asp:GridView>
           <br />
           <br />
<table>
   <tr>
   <td style="background-color:#F9ddf4;">Default Value &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
   <td>&nbsp;&nbsp;&nbsp;</td>
   <td><asp:TextBox ID="txtDefaultValue" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" runat="server"></asp:TextBox> </td>
   </tr>
</table>

     </div>
  </div>
  <br />
   <div class="form_buttom">
    <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="da_submit_button" 
           OnClientClick="javascript:return test();" onclick="btnSave_Click"
   />
  </div>
 </ContentTemplate>
 </asp:UpdatePanel>