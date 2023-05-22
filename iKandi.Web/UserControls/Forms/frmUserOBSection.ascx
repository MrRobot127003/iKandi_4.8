<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmUserOBSection.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.frmUserOBSection" %>
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
    
   
</style>
<script type="text/javascript">

 

    function ValidateControl() {
        if (document.getElementById('<%=txtSection.ClientID %>').value == "") {
//            document.getElementById('<%=txtSection.ClientID %>').style.display = 'block';
//            $('.lbTag').attr("style", "Color:Red");
            //            document.getElementById('<%=txtSection.ClientID %>').style.fontSize = '11px';
            ShowHideMessageBox(true, 'Enter section name', 'Cutting Ob form');
            return false;
        }
        //        if (document.getElementById('<%=txtdiscription.ClientID %>').value == "") {//for validate Discription
        //            document.getElementById('<%=txtdiscription.ClientID %>').style.display = 'block';
        //            $('.lb').attr("style", "Color:Red");
        //            document.getElementById('<%=txtdiscription.ClientID %>').style.fontSize = '11px';
        //            return false;
        //        }


    }

    //    function onlyNumbers(evt) {//FRO GRIDVIEW SALARY TEXBOX
    //        var e = event || evt; // for trans-browser compatibility
    //        var charCode = e.which || e.keyCode;
    //        if (charCode > 31 && (charCode < 48 || charCode > 57))
    //            return false;
    //        return true;
    //    }


    function gridValidate() {

        var count1 = 0;
        var Count2 = 0;
        $('.OBSectionIDTypetypeCss').each(function (index, item) {
            if ($(this).val() != "") {
                count1 = 1;
            }
        }, 0);

        if (count1 == 0) {
            //alert("Enter Section Details First .");
            ShowHideMessageBox(true, 'Enter section name', 'Cutting Ob form');
            return false;
        }
        else {
            return true;
        }

//        $('.GarmentDescriptionTypeCss').each(function (index, item) {//for discription
//            if ($(this).val() != "") {
//                Count2 = 1;
//            }
//        }, 0);

//        if (Count2 == 0) {
//            alert("Enter Section Discription First .");
//            return false;
//        }
//        else {
//            return true;
//        }
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

<table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
    <tr>
      <td style="font-size:20px; text-align:center; color:#405D99; font-family:Lucida Sans Unicode; height:40px; font-weight:bold; text-transform:capitalize;">Stitching Section admin</td>
    </tr>
    
<tr>
<td style="FONT-SIZE: 12px; TEXT-TRANSFORM: capitalize; FONT-WEIGHT: normal; COLOR: #0088cc; LINE-HEIGHT: 20px" align="center">(Add/modify  Stitching sections)</td>
</tr>
    <tr>
    <td style="font-size:10px; font-weight:normal; color:#0088cc; line-height:20px;" align="center"> </td>
    
    </tr>
    <tr>
        <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
        <table width="100%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin:0px;">
            <tr class="td-sub_headings border2">
                <th width="10%" style="padding:10px;">Section Name</th>
                <td width="30%" style="border:1px solid gray"><input style="text-transform:none; width:200px;" runat="server" onkeydown="return BlockingHtml(this,event);"   id="txtSection" name="" maxlength="50" type="text"  class="input_in"/></th>
                <th width="10%" style="padding:10px;">Description</td>
                <td width="30%" style="border:1px solid gray">
                    <input style="text-transform:none; width:200px;" runat="server"  id="txtdiscription" onkeydown="return BlockingHtml(this,event);" maxlength="100" name="" type="text"   class="input_in" />                
                </td>  
                <td align="left" width="20%" style="border-left:none; border:1px solid gray">
                    <asp:Button ID="btnsubmit" Text="Submit" CssClass="submit" runat="server" OnClientClick="return ValidateControl()" onclick="btnsubmit_Click"  />

                </td>         
              </tr>
              <tr>
                <td style="border:none;">&nbsp;</td>
                <td style="text-transform:capitalize; border:none;">
                    <asp:Label   ID="lblTag" style="display:none; text-transform:capitalize !important;" CssClass="lbTag" ForeColor="Red" runat="server" Text="Enter Section Detail First."></asp:Label>
                </td>
                <td  style="border:none;">&nbsp;</td>
                <td style="text-transform:capitalize; border:none;"><asp:Label CssClass="lb" style="display:none; text-transform:capitalize;" ForeColor="Red"  ID="lblSym" runat="server" Text="Enter Discription Details."></asp:Label></td>
                <td  style="border:none;">&nbsp;</td>
              </tr>
    </table>    
   
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-bottom:10px;"><span class="da_h1"  style="font-size:20px; text-align:left; color:Black; font-family:Lucida Sans Unicode;"></span></td>
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
                    <asp:GridView ID="grdOb"  runat="server" CssClass="font" 
                            AutoGenerateColumns="False" Width="100%" 
                            HeaderStyle-CssClass="border2"
                            HeaderStyle-HorizontalAlign="Center" 
                           HeaderStyle-Font-Size="13px"
                            onrowcancelingedit="grdOb_RowCancelingEdit" 
                            onrowediting="grdOb_RowEditing" 
                            onrowupdating="grdOb_RowUpdating" 
                            onrowdatabound="grdOb_RowDataBound" 
                            onpageindexchanging="grdOb_PageIndexChanging" 
                            onselectedindexchanging="grdOb_SelectedIndexChanging">
                       <Columns>
                       
                       
                        <asp:TemplateField HeaderText="Section Name" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="25%" >
                            <ItemTemplate>  <div style=" padding-left:10px; text-transform:capitalize;">
                                   <%--<%#Eval("GarmentType")%>--%>
                                    <asp:Label runat="server" ID="lblgarmenttype" style="text-transform:capitalize;"  ToolTip="Enter  OBSection details Type" Text='<%#Eval("Section")%>' ></asp:Label>
                                    </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="text-transform:capitalize;">
                                 <asp:TextBox ID="txt_OBSection" Width="96%" style="text-transform:capitalize;"  CssClass="OBSectionIDTypetypeCss" onkeydown="return BlockingHtml(this,event);"  ToolTip="Edit the OBSection details "  runat="server" Text='<%#Eval("Section")%>'></asp:TextBox>
                                 <asp:HiddenField ID="hdnOBSectionID"  runat="server" Value='<%#Eval("OBSectionID")%>' /></div>
                             </EditItemTemplate>   
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="55%" >
                            <ItemTemplate> 
                             <asp:Label runat="server" ID="lblSectionDescription"  style="text-transform:capitalize; padding:0px 10px;"  ToolTip="Enter  of Description Type" Text='<%#Eval("SectionDescription")%>' ></asp:Label>
                                 
                            </ItemTemplate> 
                             <EditItemTemplate>
                                 <asp:TextBox ID="txt_SectionDescription"  Width="96%" TextMode="MultiLine"  Height="40px" ToolTip="Edit the Description " onkeydown="return BlockingHtml(this,event);" style="text-transform:capitalize; padding:0px 10px;"    CssClass="GarmentDescriptionTypeCss"  runat="server" Text='<%#Eval("SectionDescription")%>'></asp:TextBox>
                               
                             </EditItemTemplate> 
                           
                        </asp:TemplateField>
                        


                        <asp:TemplateField HeaderText="Action"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%"  >
                          <ItemTemplate><div style="text-align:center; text-transform:capitalize;">
                            <asp:LinkButton ID="lnkEdit" ForeColor="blue" runat="server" CommandName="Edit">Edit</asp:LinkButton> 
                            </div>  </ItemTemplate>
                     <EditItemTemplate><div style="text-align:center; text-transform:capitalize;">
                        <asp:LinkButton ID="lnkUpdate" ForeColor="blue" runat="server" OnClientClick="javascript:return gridValidate();"  CommandName="Update">Update</asp:LinkButton> 
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