<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FrmUserAttachment.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.FrmUserAttachment" %>
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
    .border td{border:1px solid #000000; border-collapse:collapse;}
    .border2 th{background-image:url(../../images/cs_bg.jpg); background-repeat:repeat-x; padding:10px; color:White; text-transform:capitalize;}
    
</style>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

    var IsShiftDown = false;
    function BlockingHtml(Sender, e) {
        var key = e.which ? e.which : e.keyCode;
        if (key == 16) {
            IsShiftDown = true;
            //CharCounter(Sender, 10);
        }
        else if ((IsShiftDown == true) && ((key == 188) || (key == 190))) {
            return false;
        }
    }

    function ValidateControl() {
        if (document.getElementById('<%=txtattachment1.ClientID %>').value == "") {
            ShowHideMessageBox(true, "Enter attchment name", "Machine Attachment Admin");
            return false;
        }




    }


    function IsValidate() {//for girdcheck
        //debugger;

        var txt_AttName = $(".UserAttchCss");
        //var txt_names = $(".CssName");




        if (txt_AttName.val() == "") {
            ShowHideMessageBox(true, "Enter attchment name", "Machine Attachment Admin");
            return false;
        }

        else
        { return true; }



    }
    function onlyAlphabets(evt) {
        var charCode;
        if (window.event)
            charCode = window.event.keyCode;  //for IE
        else
            charCode = evt.which;  //for firefox
        if (charCode == 32) //for &lt;space&gt; symbol
            return true;
        if (charCode > 31 && charCode < 65) //for characters before 'A' in ASCII Table
            return false;
        if (charCode > 90 && charCode < 97) //for characters between 'Z' and 'a' in ASCII Table
            return false;
        if (charCode > 122) //for characters beyond 'z' in ASCII Table
            return false;
        return true;
    }
    
</script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


          
 
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <caption  style="font-size:20px; text-align:center; color:#3b5998; font-family:Lucida Sans Unicode; height:40px; text-transform:capitalize; font-weight:bold;">Machine Attachment Admin</caption>
  <tr>
    <td style="font-size:12px; font-weight:normal; color:#0088cc; line-height:20px; text-transform:capitalize;" align="center"> (To add/modify machine  attachments in Technical Module which is used in Machine/Manpower Attachment admin and OB Sheet technical form)</td>
    
    </tr>

  
  <tr>
    <td class="tbl_bordr">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper" style="border:0px !important;">
   
      <tr>
        <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 
     <ContentTemplate>
          
          <table width="100%" border="0" align="center" cellspacing="0" cellpadding="0" style="margin:0px;" class="item_list">
            <tr class="td-sub_headings border" style="padding:3px 0px;">
              <th class="style3" style=" width:10%">Attachment Name<asp:Label   ID="lblTag" style="display:none;"
               CssClass="lbTag" ForeColor="Red" runat="server" Text="Enter Attachment  First."></asp:Label></th>
               <td class="style3" style="padding:3px; width="30%"><input style="text-transform:none; width:200px;" runat="server" maxlength="50"   id="txtattachment1" name="" type="text" onkeydown="return BlockingHtml(this,event);"  class="input_in"/></td>
         
                <th width="10%">Description
                 <asp:Label   ID="Label1" style="display:none;"
               CssClass="lb2" ForeColor="Red" runat="server" Text="Enter Discription."></asp:Label>
                </th>
                 <td class="style2" style="padding:3px; width="30%"><input style="text-transform:none;width:200px;" runat="server"  id="txtDiscription1" maxlength="100"   name="" type="text" onkeydown="return BlockingHtml(this,event);"   class="input_in"/></td>
            
              <td class="style1" align="center" width="20%"> 
              <asp:Button ID="btnsubmit"  CssClass="submit" Text="Submit" runat="server" OnClientClick="return ValidateControl()" onclick="btnsubmit_Click"  />
              
              </td>
            
              </tr>
      
           
           
        <tr>
            <td colspan="6">
             <asp:Label  ID="lblExpCon" CssClass="lb" style="display:none;" runat="server" ForeColor="Red" Text="Enter Name"></asp:Label>
              </td>
        </tr>
        
    </table>
    
 
 


<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
         <!---  <td width="10" class="da_table_heading_bg_left">&nbsp;</td>  ---->
        <td><span class="da_h1" style="font-size:20px; text-align:left; color:Black; font-family:Lucida Sans Unicode;"></span></td>
         <!--- <td width="13" class="da_table_heading_bg_right">&nbsp;</td> ----->
      </tr>
      <tr><td>&nbsp;</td></tr>
    </table>
    </td>
  </tr>
  <tr>
    <td valign="top">
         
    <!--table2-->
    

 <table width="100%" border="0" cellspacing="0" cellpadding="2" >
                  
                    <tr >
                    <td align="left">
                    <asp:GridView ID="grdCurrency" AllowPaging="false" runat="server" CssClass="font" 
                            AutoGenerateColumns="False" Width="100%" 
                           HeaderStyle-CssClass="border2"                            
                            HeaderStyle-HorizontalAlign="Center" 
                           HeaderStyle-Font-Size="13px"
                            onrowcancelingedit="grdCurrency_RowCancelingEdit" 
                            onrowediting="grdCurrency_RowEditing" 
                            onrowupdating="grdCurrency_RowUpdating" 
                            onrowdatabound="grdCurrency_RowDataBound" 
                            onpageindexchanging="grdCurrency_PageIndexChanging" >
                       <Columns>
                       
                       
                        <asp:TemplateField HeaderText="Attachment " HeaderStyle-Font-Bold="false"   HeaderStyle-Width="25%" >
                            <ItemTemplate>  <div style=" padding-left:10px; text-transform:capitalize;">
                                  <asp:Label runat="server" ID="lblattchment" Text='<%#Eval("AttachmentName")%>' ></asp:Label>
                                    </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style=" padding-left:10px; text-transform:capitalize;">
                                 <asp:TextBox ID="txtatt" style=" padding-left:10px; text-transform:capitalize;" Height="40px" Width="96%" CssClass="UserAttchCss"  runat="server" onkeydown="return BlockingHtml(this,event);" Text='<%#Eval("AttachmentName")%>'></asp:TextBox>
                                 <asp:HiddenField ID="hdnattchemntID" runat="server" Value='<%#Eval("AttachmentID") %>' /></div>
                             </EditItemTemplate>   
                        </asp:TemplateField>
                        
                        
                   
                   
                        <asp:TemplateField HeaderText="Description"  HeaderStyle-Font-Bold="false"   HeaderStyle-Width="55%" >
                            <ItemTemplate> <div style=" padding-left:10px; text-transform:capitalize;">
                             <asp:Label runat="server" ID="lblDiscription" Text='<%#Eval("AttachmentDescription")%>' ></asp:Label>
                                 </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style=" padding-left:10px; text-transform:capitalize;">
                                 <asp:TextBox ID="txtDiscription" style=" padding-left:10px; text-transform:capitalize;" width="96%" Height="40px"  CssClass="UserAttchDesc" onkeydown="return BlockingHtml(this,event);"  runat="server" Text='<%#Eval("AttachmentDescription")%>'></asp:TextBox>
                              
                             </EditItemTemplate> 
                           
                        </asp:TemplateField>
                        


                        <asp:TemplateField HeaderText="Action"   HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%"  >
                          <ItemTemplate><div style="text-align:center;">
                            <asp:LinkButton ID="lnkEdit" ForeColor="blue" runat="server" CommandName="Edit">Edit</asp:LinkButton> 
                            </div>  </ItemTemplate>
                     <EditItemTemplate><div style="text-align:center;">
                        <asp:LinkButton ID="lnkUpdate" ForeColor="blue" runat="server" OnClientClick="javascript:return IsValidate();"  CommandName="Update">Update</asp:LinkButton> 
                        <asp:LinkButton ID="lnkCancel" ForeColor="blue" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                     </div></EditItemTemplate>
                                                
                      </asp:TemplateField>      
                        
                    </Columns>
                    
                   <emptydatarowstyle backcolor="LightBlue"
                   forecolor="Red"/>

                   <emptydatatemplate>

              
            N/A  

        </emptydatatemplate>
                    
                    </asp:GridView>
                    </td>                    
              </tr>
                 
            </table>
      
<!--end--> 

</td>
  </tr>
</table> 
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnsubmit" EventName="Click" />
     </Triggers>
     
    </asp:UpdatePanel>
    </td>
    
  </tr>
  
</table>
</td>
</tr>
</table>
