<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserfrmGarmenttype .ascx.cs" Inherits="iKandi.Web.UserControls.Forms.UserfrmGarmenttype" %>
<link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
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
  /*   .border td{border:1px solid #000000; border-collapse:collapse;}
   .border2 th{background-image:url(../../images/cs_bg.jpg); background-repeat:repeat-x; padding:10px; color:White; text-transform:capitalize;}*/
   .font td {
    border: 1px solid #e4e4e4;
    color: Gray;
    font-size: 11px;
}
.main_tbl_wrapper {
 border-color:#999;
}
</style>

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
        if (document.getElementById('<%=txtgarmenttype.ClientID %>').value == "") {
//            document.getElementById('<%=txtgarmenttype.ClientID %>').style.display = 'block';
//            $('.lbTag').attr("style", "Color:Red");
            //            document.getElementById('<%=txtgarmenttype.ClientID %>').style.fontSize = '11px';
            //jQuery.facebox('Enter Garment Type First');
            ShowHideMessageBox(true, 'Enter garment type first', 'Garment Types ');  
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
        $('.GarmentTypetypeCss').each(function (index, item) {
            if ($(this).val() != "") {
                count1 = 1;
            }
        }, 0);

        if (count1 == 0) {
            //alert("Enter garment Type First .");
            // jQuery.facebox('Enter garment Type First');
            ShowHideMessageBox(true, "Enter garment type first",'Garment Types');
            
               
            
            return false;
        }

//        $('.GarmentDescriptionTypeCss').each(function (index, item) {
//            if ($(this).val() != "") {
//                Count2 = 1;
//            }
//        }, 0);

//        if (Count2 == 0) {
//            alert("Enter Garment Discription First .");
//            return false;
//        }
        else {
            return true;
        }
    }
    
</script>



<table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
    <tr>
      <td class="header-text-back">Garment Type admin</td>
    </tr>
    <tr>
    <td style="font-size:12px; font-weight:normal; color:#0088cc; line-height:30px;  text-align:center; text-transform:none;"> (To add/modify Garment Types) </td>
    
    </tr>
    <tr>
        <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
        <table width="100%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin:0px;">
            <tr class="td-sub_headings border">
                <td width="10%" class="heading-bg">Garment type</td>
                <td width="30%"><input style="text-transform:none; width:200px;" runat="server" maxlength="20"  id="txtgarmenttype" name="" type="text" onkeydown="return BlockingHtml(this,event);"  class="input_in"/></td>
                <td width="10%" class="heading-bg">Description</td>
                <td width="30%">
                    <input style="text-transform:none; width:200px;" runat="server" maxlength="100"  id="txtdiscription" name="" type="text" onkeydown="return BlockingHtml(this,event);"   class="input_in"/>                
                </td>  
                <td align="left" width="20%" style="border-left:none;">
                    <asp:Button ID="btnsubmit" Text="Submit" CssClass="submit" runat="server" OnClientClick="return ValidateControl()" onclick="btnsubmit_Click"  />

                </td>         
              </tr>
              <tr>
                <td style="border:none;">&nbsp;</td>
                <td style="text-transform:capitalize; border:none;">
                    <asp:Label   ID="lblTag" style="display:none; text-transform:capitalize !important;" CssClass="lbTag" ForeColor="Red" runat="server" Text="Enter Garment Type First."></asp:Label>
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
                    <asp:GridView ID="grdGarments"  runat="server" CssClass="font" 
                            AutoGenerateColumns="False" Width="100%" 
                            HeaderStyle-CssClass="border2"
                            HeaderStyle-HorizontalAlign="Center" 
                           HeaderStyle-Font-Size="13px"
                            onrowcancelingedit="grdGarments_RowCancelingEdit" 
                            onrowediting="grdGarments_RowEditing" 
                            onrowupdating="grdGarments_RowUpdating" onrowdatabound="grdGarments_RowDataBound"   
                             onpageindexchanging="grdGarments_PageIndexChanging">
                       <Columns>
                       
                       
                        <asp:TemplateField HeaderText="Garments type" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="25%" >
                            <ItemTemplate>  <div style=" padding-left:10px; text-transform:capitalize;">
                                   <%--<%#Eval("GarmentType")%>--%>
                                    <asp:Label runat="server" ID="lblgarmenttype" Text='<%#Eval("GarmentType")%>' ></asp:Label>
                                    </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="text-align:center; text-transform:capitalize;">
                                 <asp:TextBox ID="txt_GarmentType" Height="40px" style=" text-transform:capitalize;" Width="96%" CssClass="GarmentTypetypeCss" onkeydown="return BlockingHtml(this,event);" ToolTip="Enter  Garment Type"  runat="server" Text='<%#Eval("GarmentType")%>'></asp:TextBox>
                                 <asp:HiddenField ID="hdnGarmentTypeID" runat="server" Value='<%#Eval("GarmentTypeID")%>' /></div>
                             </EditItemTemplate>   
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Font-Bold="false"   HeaderStyle-Width="55%" >
                            <ItemTemplate> <div style="padding-left:10px; text-transform:capitalize; ">
                             <asp:Label runat="server" ID="lblGarmentDescription" style="text-transform:capitalize;"  Text='<%#Eval("GarmentDescription")%>' ></asp:Label>
                                 </div>
                            </ItemTemplate> 
                             <EditItemTemplate><div style="padding-left:10px; "  >
                                 <asp:TextBox ID="txt_GarmentDescription" Width="96%" Height="40px" TextMode="MultiLine" onkeydown="return BlockingHtml(this,event);"  ToolTip="Enter Discription of Garment Type" style=" padding-left:10px; text-transform:capitalize;"   CssClass="GarmentDescriptionTypeCss"  runat="server" Text='<%#Eval("GarmentDescription")%>'></asp:TextBox>
                               
                             </EditItemTemplate> 
                           
                        </asp:TemplateField>
                        


                        <asp:TemplateField HeaderText="Action"  HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%"  >
                          <ItemTemplate><div style="text-align:center; text-transform:capitalize;">
                            <asp:LinkButton ID="lnkEdit" ForeColor="blue" runat="server" CommandName="Edit"><img src="../../images/edit2.png" /></asp:LinkButton> 
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
