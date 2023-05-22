<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmMachineattachment.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.frmMachineattachment" %>

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
   
.gridview{
    background-color:#fff;
   
   padding:2px;
   margin:2% auto;
   
   
}
.gridview a{
  margin:auto 1%;
    border-radius:50%;
      background-color:#444;
      padding:5px 10px 5px 10px;
      color:#fff;
      text-decoration:none;
      -o-box-shadow:1px 1px 1px #111;
      -moz-box-shadow:1px 1px 1px #111;
      -webkit-box-shadow:1px 1px 1px #111;
      box-shadow:1px 1px 1px #111;
     
}
.gridview a:hover{
    background-color:#1e8d12;
    color:#fff;
}
.gridview span{
    background-color:#ae2676;
    color:#fff;
     -o-box-shadow:1px 1px 1px #111;
      -moz-box-shadow:1px 1px 1px #111;
      -webkit-box-shadow:1px 1px 1px #111;
       box-shadow:1px 1px 1px #111;

    border-radius:50%;
    padding:5px 10px 5px 10px;
}
 
 .chkBoxList tr
{
   height:24px;
}

.chkBoxList td
{
   width:120px; /* or percent value: 25% */
}
.checkboxlist_nowrap tr td label
{
    white-space:nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    font-size:10px;
    display:inline-block;
}


.ddl option
{
    color:#000;
    font-family:Verdana;
    font-size:14px !IMPORTANT;
    line-height:20px;
    width:500PX;
}

.checkbox-list
{
    font-size:10px;
    font-family:arial;
}
.over-flow-box
{
    height:52px!important;
    }
</style>
<link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />

<script type="text/javascript">

    
    function ValidateControl() {

        var atLeast = 1
      
        if (document.getElementById('<%=txt_machineType.ClientID %>').value == "") {
//            document.getElementById('<%=txt_machineType.ClientID %>').style.display = 'block';
//            $('.lbTag').attr("style", "Color:Red");
            //            document.getElementById('<%=txt_machineType.ClientID %>').style.fontSize = '11px';
            //alert("Please Enter Machine Type.");
            ShowHideMessageBox(true, "Enter machine type", "Manpower form");
            return false;
        }
       // var CHK = document.getElementById("<%=chklst_attchment.ClientID%>");

        //var checkbox = CHK.getElementsByTagName("input");

        //var counter = 0;

        //for (var i = 0; i < checkbox.length; i++) {

          //  if (checkbox[i].checked) {

           //     counter++;
           // }

       // }

       // if (atLeast > counter) {

            //alert("Please select atleast " + atLeast + " AttachmentName(s)");
           // ShowHideMessageBox(true, "Please select atleast " + atLeast + " attachmentName(s)", "Manpower form");

           // return false;
       // }

        var ddl = document.getElementById("<%=DDl_ManpowerType.ClientID%>");
       

        if (ddl.selectedIndex == 0) {
            // alert('Please select ManpowerType First ');
            ShowHideMessageBox(true, "select manpower type", "Manpower form");
            return false;
        }


        return true;
    }
//    function onlyAlphabets(evt) {
//        var charCode;
//        if (window.event)
//            charCode = window.event.keyCode;  
//        else
//            charCode = evt.which;  
//        if (charCode == 32) 
//            return true;
//        if (charCode > 31 && charCode < 65) 
//            return false;
//        if (charCode > 90 && charCode < 97) 
//            return false;
//        if (charCode > 122) 
//            return false;
//        return true;
//    }

    function whichButton(event) {
        if (event.button == 2)//RIGHT CLICK
        {
            //alert("Not Allow Right Click!");
            ShowHideMessageBox(true, "Not allow right click", "Manpower form"); 

        }

    }
    function noCTRL(e) {
        var code = (document.all) ? event.keyCode : e.which;

        var msg = "Sorry, this functionality is disabled.";
        if (parseInt(code) == 17) //CTRL
        {
            ShowHideMessageBox(true, msg, "Manpower form");
           // alert(msg);
            window.event.returnValue = false;
        }
    }


    
// for check Checkbox list
    function CheckBoxSelectionValidation() {

        var count1 = 0;
        $('.MachientypeCss').each(function (index, item) {
            if ($(this).val() != "") {
                count1 = 1;
            }
        }, 0);

        if (count1 == 0) {
            //alert("Enter Machien Type First .");
            ShowHideMessageBox(true, "Enter machien type", "Manpower form");
            return false;
        }


        else {
            return true;
        }

    }

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
      
    
</script>

 

<table  width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper" style="font-family:Lucida Sans Unicode;width:1570px;">
    <tr>
      <td class="main-heading">Machine, attachment and  Manpower Admin</td>
    </tr>
    <tr>
    <td style="font-size:12px; font-weight:normal; color:#0088cc; line-height:30px;  text-align:center; text-transform:none;"> (Association of  machines with attachments and manpower type) </td>
    
    </tr>
    <tr>
        <td>
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1"  runat="server" >
 
     <ContentTemplate>
     <table width="100%">
     <tr>
     <td>
     <table border="0" align="left" cellspacing="0" cellpadding="3" width="100%" style="margin:0px;">
            <tr class="td-sub_headings border">
                <td width="10%" class="heading-bg">Machine Type</td>
                <td class="style1" width="30%"><input style="text-transform:none; width:200px;"  runat="server"  id="txt_machineType"  onmousedown="whichButton(event)"   onkeydown="return BlockingHtml(this,event);" name="" type="text"  class="input_in"/></td>

                <td width="10%" class="heading-bg">Manpower Type</td>
                <td width="30%">
                 
                    <asp:DropDownList ID="DDl_ManpowerType" runat="server" Width="90%" BackColor="#F6F1DB" ForeColor="#000000"  CssClass="ddl">
                          
                     </asp:DropDownList>
                </td> 
           
                <td align="left" width="20%" style="border-left:none;">
                    <asp:Button ID="btnsubmit" CssClass="submit" Text="Submit" runat="server" OnClientClick="return ValidateControl()" onclick="btnsubmit_Click"  />

               </td>         
              </tr>
              </table>
     </td>
     </tr>
     <tr>
     <td>
     <table border="0" align="left" cellspacing="0" cellpadding="3" style="margin:0px; width:100%;">
              <tr class="td-sub_headings border">
              
               <td width="12%"  class="heading-bg">Attachment Name</td>
               <td align="left"  style="table-layout:fixed;text-align:left; width:90%">              
             
                    <div class="over-flow-box">
              
               <asp:CheckBoxList ID="chklst_attchment"   CssClass="checkboxlist_nowrap" RepeatColumns="8" RepeatLayout="Table" TextAlign="Right" RepeatDirection="Horizontal"  runat="server" Width="100%">
                
                  </asp:CheckBoxList> 
                  </div>    
               </td>
              </tr>
    </table>
     </td>
     </tr>
  

     <tr>
     <td>
     <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
<%--      <tr>
            <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" >
            <tr><td>&nbsp;</td></tr>
            <tr>
              <td style="padding:10px 0px 10px 10px; color:#fff; font-weight:bold;" bgcolor="#717171"><span class="da_h1"  style="font-size:20px; text-align:left; color:Black; font-family:Lucida Sans Unicode;"></span>Machine Attachment</td> 
                <td>&nbsp;</td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            </table>
            </td>
        </tr>--%>
        <tr>
        <td valign="top">
        <!--table2-->
        <table width="100%" border="0" cellspacing="0" cellpadding="2" style="margin-bottom:30px;">
                   
                    <tr  >
                    <td align="left" >
                    <asp:GridView ID="grdMachinetype" runat="server" CssClass="font" Width="100%"  AutoGenerateColumns="false"
                           
                            HeaderStyle-CssClass="border2"
                            HeaderStyle-HorizontalAlign="Center" 
                           HeaderStyle-Font-Size="13px"
                            onrowcancelingedit="grdMachinetype_RowCancelingEdit" 
                            onrowediting="grdMachinetype_RowEditing" 
                            onrowupdating="grdMachinetype_RowUpdating" 
                            onrowdatabound="grdMachinetype_RowDataBound"  
                            onpageindexchanging="grdMachinetype_PageIndexChanging1">
                            <Columns>
                            
                             <asp:TemplateField HeaderText="Machine type" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="15%" >
                            <ItemTemplate>  <div style="padding-left:10px;  text-transform:capitalize;">
                                  
                                  <asp:Label runat="server" ID="lbl_machinetype" Text='<%#Eval("MachineType")%>' ></asp:Label>
                                   
                                    </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="padding-left:10px; text-transform:capitalize;">
                                 <asp:TextBox ID="txt_gmachinetype" Width="96%" style="text-align:center; text-transform:capitalize;"  CssClass="MachientypeCss"   onmousedown="whichButton(event)"   onkeydown="return BlockingHtml(this,event);" runat="server" Text='<%#Eval("MachineType")%>'></asp:TextBox>
                                 <asp:HiddenField ID="hdnFiled1" runat="server" Value='<%#Eval("MachineAttachment")%>' /></div>
                                 <%--<asp:RequiredFieldValidator ID="rfvPrice" ControlToValidate="txt_gmachinetype" runat="server" Display="Dynamic" ErrorMessage="Please Enter Machine type" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                             </EditItemTemplate>   
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Manpower" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="15%" >
                            <ItemTemplate  > <div style="padding-left:10px;  text-transform:capitalize;">
                            <asp:Label runat="server" ID="lbl_gmanpoertype" Text='<%#Eval("WorkerType")%>' ></asp:Label>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="padding-left:10px;  text-transform:capitalize;">
                                
                                  <asp:DropDownList ID="ddl_gmanpower"  runat="server"></asp:DropDownList>
                               
                             </EditItemTemplate> 
                           
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Attachment" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="45%" >
                            <ItemTemplate> <div style="padding-left:10px;  text-transform:capitalize;">
                            <asp:Label runat="server"  ID="lbl_Machinattachment" Text='<%#Eval("AttchmentName")%>' ></asp:Label>
                            <asp:HiddenField ID="hdnFiled2" runat="server" Value='<%#Eval("Att_Id")%>' /></div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="padding-left:10px;  text-transform:capitalize;">
                                
                                  <asp:CheckBoxList id="g_checkboxlist"  OnSelectedIndexChanged="g_checkboxlist_SelectedIndexChanged" CssClass="checkbox-list" runat="server"  RepeatDirection="Horizontal" RepeatColumns="6" ></asp:CheckBoxList>
                               
                             </EditItemTemplate> 
                           
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Action"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="10%"  >
                          <ItemTemplate><div style="text-align:center; text-transform:capitalize;">
                            <asp:LinkButton ID="lnkEdit" ForeColor="blue" runat="server" CommandName="Edit"><img src="../../images/edit2.png" /></asp:LinkButton> 
                            </div>  </ItemTemplate>
                     <EditItemTemplate><div style="text-align:center; text-transform:capitalize;">
                        <asp:LinkButton ID="lnkUpdate" ForeColor="blue" runat="server" OnClientClick="javascript:return CheckBoxSelectionValidation();"  CommandName="Update">Update</asp:LinkButton> 
                        <asp:LinkButton ID="lnkCancel" ForeColor="blue" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
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
