<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GarmentTypeAdmin.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.GarmentTypeAdmin" %>
<style type="text/css">
    
    .tr_class
    {
       
        background:#F9ddf4;
        
        font:normal 11px/14px arial;
    }
</style>
<script type="text/javascript">
    $(function () {
        debugger;
        alert('hello');
    });
    function test() {

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
    ShowFooter="true" onrowcommand="GrdCTM_RowCommand" 
    onrowdatabound="GrdCTM_RowDataBound" DataKeyNames="ID" 
    onrowdeleting="GrdCTM_RowDeleting" Width="100%" >
<Columns>  
                    
    <asp:TemplateField HeaderText="Sam">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtsam" runat="server" class="textbox" Text='<%#Eval("sam")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox  onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtsamFooter" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate> 
   </asp:TemplateField>


    <asp:TemplateField Visible="false"   HeaderText="Garment Type " >
         <ItemTemplate>
            <asp:DropDownList ID="ddlgrmtype" Width="120px" runat="server" CssClass="input_in"></asp:DropDownList>
         </ItemTemplate>
         <FooterTemplate>
         <asp:DropDownList ID="ddlgrmtypeFooter" Width="120px" runat="server" CssClass="input_in"></asp:DropDownList>
         </FooterTemplate>
      </asp:TemplateField>  
      
    <asp:TemplateField  Visible="false"  HeaderText="Option">
            <ItemTemplate>
                    <asp:TextBox ID="txtOption"  Text='<%#Eval("Option")%>'  CssClass="input_in" style="text-align:center;" BorderStyle="None" runat="server" class="textbox" ></asp:TextBox>                         
            </ItemTemplate>
            <FooterTemplate>
                   <asp:TextBox ID="txtOptionFooter"  CssClass="input_in" style="text-align:center;" BorderStyle="None" runat="server" ></asp:TextBox>
            </FooterTemplate>                        
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Range (0 to 499)">
            <ItemTemplate>
            <asp:HiddenField ID="txtID" Value='<%#Eval("ID") %>' runat="server" />
              <asp:HiddenField ID="hdnGarmentType" Value='<%#Eval("Garment_Type") %>' runat="server" />
                    <asp:TextBox onpaste="return false" CssClass="input_in"  ID="txt500" style="text-align:center;" BorderStyle="None" runat="server" class="textbox" Text='<%#Eval("Upto_500")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
            <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in" ID="txt500Footer" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" ></asp:TextBox>
            </FooterTemplate>                                    
   </asp:TemplateField>
      
   <asp:TemplateField HeaderText="Range (500 to 1499)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt1500" runat="server" class="textbox" Text='<%#Eval("Upto_1500")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox  onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt1500Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate> 
   </asp:TemplateField>
      
   <asp:TemplateField HeaderText="Range (1500 to 2999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt3000" runat="server" class="textbox" Text='<%#Eval("Upto_3000")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt3000Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>  
      
      
   <asp:TemplateField HeaderText="Range (3000 to 4999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt5000" runat="server" class="textbox" Text='<%#Eval("Upto_5000")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox  onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt5000Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Range (5000 to 9999)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt10000" runat="server" class="textbox" Text='<%#Eval("Upto_10000")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txt10000Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
            </FooterTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Range (9999 and above)">
            <ItemTemplate>
                    <asp:TextBox onpaste="return false" CssClass="input_in" style="text-align:center;" BorderStyle="None" ID="txtabv10000" runat="server" class="textbox" Text='<%#Eval("Above_10000")%>' onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>                         
            </ItemTemplate>
             <FooterTemplate>
                   <asp:TextBox onpaste="return false"  style="text-align:center;" BorderStyle="None" ID="txtabv10000Footer" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);"></asp:TextBox>
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
                      <td>Range (500 to 1499)</td> 
                      <td>Range (1500 to 2999)</td>
                      <td>Range (3000 to 4999)</td>
                      <td>Range (5000 to 9999)</td>
                      <td>Range (9999 and Above)</td>
                      <td>Action</td>
                    </tr> 
                    <tr> 
                     
                      
                      <td><asp:TextBox ID="txtOptionBlank" runat="server" style="text-align:center;" BorderStyle="None"  /></td> 
                      <td><asp:TextBox  ID="txtRange5Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txtRange15Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txtRange30Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txtRange50Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txtRange100Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>
                      <td><asp:TextBox ID="txtAbove100Blank" style="text-align:center;" BorderStyle="None" runat="server" onKeyDown="javascript:return ValidateNumericFields(event.keyCode, $(this), false);" onpaste="return false" /></td>                                             
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
    <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="da_submit_button" OnClientClick="javascript:return test();"
  onclick="btnSave_Click"  />
  </div>
 </ContentTemplate>
 </asp:UpdatePanel>

 