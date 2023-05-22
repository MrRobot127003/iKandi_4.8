<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskMapping.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.TaskMapping" %>





<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Task Management Admin</title>
<link href="ikandi.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    
    .ColorAndAlign
{
    text-align:center;
    font:bold 12px/14px Arial, Helvetica, sans-serif;
    background-image:
    background-image:url(images1/order_form_top.gif) repeat-x;
    
    text-transform:none;
    }
</style>

<script type="text/javascript">
    function msg() {
        alert('Entered Successfully.');
        return true;
    }
</script>


</head>

<body>


<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>



<asp:UpdatePanel ID="UP" runat="server">
<ContentTemplate>
<table width="1150" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td class="da_table_heading_bg"><span class="h1">Task Management Admin</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>

    </td>
  </tr>
  <tr>
    <td>
<table width="99%" border="0" cellspacing="0" cellpadding="2" class="da_table_border">
                  <tr>
                    <td height="25" valign="middle" class="td-sub_headings">
                    <table width="100%" border="0" cellspacing="0" cellpadding="4" class="da_table_border">
                      <tr>
                        <td width="4%">Department</td>
                        <td width="13%">
                         
                        <asp:DropDownList class="input_in" AutoPostBack="true" Width="135px" runat="server" AppendDataBoundItems="true" 
                                ID="ddlDept" onselectedindexchanged="ddlDept_SelectedIndexChanged">
                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>    
                        
                                         </td>
                        <td width="3%"><asp:Button ID="btnGO" runat="server" Text="Search" 
                                class="go da_go_button" onclick="btnGO_Click" /></td>
                        <td>&nbsp;</td>
                      </tr>
                    </table>
                    
                    
                    </td>
                  </tr>
                  <tr>
                    <td valign="bottom" class="td-sub_headings">&nbsp;</td>
        </tr>
                 <asp:GridView ID="grdTask" runat="server" AutoGenerateColumns="false"  HeaderStyle-CssClass="yateng"  
                      onrowdatabound="grdTask_RowDataBound">
                   
                    <Columns>
                       
                       
                        <asp:TemplateField HeaderText="Task Name" HeaderStyle-Font-Bold="true"   HeaderStyle-Width="25%" >
                            <ItemTemplate>  <div style="text-align:center; ">
                             <asp:HiddenField runat="server" Value='<%#Eval("Task_Name") %>' ID="hdnTaskNameForUpdate" />
                                 <asp:TextBox ID="txtTaskName" Width="275px" MaxLength="40" style="text-align:center; border:none; "  runat="server" Text='<%#Eval("Task_Name")%>'></asp:TextBox>
                                 <asp:HiddenField runat="server" Value='<%#Eval("Task_Mode_Id") %>' ID="hdnTaskId" />
                                 <asp:HiddenField runat="server" Value='<%#Eval("designationId") %>' ID="hdnTaskWiseDesgId" />
                                 <asp:HiddenField runat="server" Value='<%#Eval("TableId") %>' ID="hdnTableId" />
                                    </div>
                            </ItemTemplate>                               
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Purpose" HeaderStyle-Font-Bold="true"   HeaderStyle-Width="25%" >

                            <ItemTemplate>
                                 <div style="text-align:center; ">
                                   <asp:HiddenField runat="server" Value='<%#Eval("Purpose") %>' ID="hdnPurposeForUpdate" />
                              <asp:TextBox runat="server" ID="txtPurpose" MaxLength="180" style="border:none;" Text='<%#Eval("Purpose")%>' TextMode="MultiLine" Width="250px" Height="50px"></asp:TextBox>
                                 </div>
                            </ItemTemplate> 
                           
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Assigened Designation"  HeaderStyle-Font-Bold="true" HeaderStyle-Width="25%" >
                            <ItemTemplate> <div style="text-align:center; "> 
                                <asp:DropDownList ID="lstDesg" AutoPostBack="true" AppendDataBoundItems="true" 
                                 OnSelectedIndexChanged="lstDesg_SelectedIndexChanged" runat="server">
                                
                                 </asp:DropDownList>
                                 <asp:HiddenField Value='<%#Eval("DEsignationId")%>' runat="server" ID="hdnAssDes" />
                               </div>
                            </ItemTemplate> 
                         
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Line Managers"  HeaderStyle-Font-Bold="true" HeaderStyle-Width="25%"  >
                          <ItemTemplate><div style= "text-align:center;">
                              <asp:ListBox ID="lstLineMgr" Width="200px" SelectionMode="Multiple"  runat="server" ></asp:ListBox>
                               <asp:HiddenField Value="0" runat="server" ID="hdnListedItemForUpdate" />
                   </div>  </ItemTemplate>
                  
                                                
                      </asp:TemplateField>      
                        
                    </Columns>

                 </asp:GridView>
                  
                  <tr>
                    <td height="36" align="center" valign="bottom" class="td-sub_headings"><table align="left" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="55"><asp:Button runat="server" ID="btnSbmt" Text="Submit" 
                                CssClass="da_submit_button" OnClientClick="javascript:return msg();" onclick="btnSbmt_Click" />  </td><td>
                              <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                  class="da_submit_button"  onclick="btnCancel_Click" /></td>
                      </tr>
                    </table></td>
                  </tr>
      </table>

    </td>
  </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>


</body>

</html>


