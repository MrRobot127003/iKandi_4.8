<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="OrderProcess.aspx.cs" Inherits="iKandi.Web.Internal.Sales.OrderProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
<style type="text/css">
    .RemoveHide
    {
        display:block;
    }
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">


    <script type="text/javascript" language="javascript">
     var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
     var proxy = new ServiceProxy(serviceUrl);
     var context = $("#main_content");
     var txtStyleNumberClientID = '<%=txtStyleNumber.ClientID%>';
    
     $(function () {
         LoadStyle();
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(LoadStyle);
         MyDatePickerFunction();
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MyDatePickerFunction);
     });

     function LoadStyle() {
         context.find("input.style-number").autocomplete("/Webservices/iKandiService.asmx/SuggestStyleNumber", { dataType: "xml", datakey: "string", max: 100 });

         context.find("#" + txtStyleNumberClientID).result(function () {
             //debugger;            
             $(".btnClsStyle").click();            

         });
     }
     function MyDatePickerFunction() {
         $('.AllocDate').datepicker({ dateFormat: 'dd M y (D)' });
     }

     function showDescriptionPopup() {
         //debugger;
         Description = $('#<%= lblDescription.ClientID %>').html();
         $('#<%= lblDescriptionShow.ClientID %>').html(Description);
         jQuery.facebox(
        $('.show-div').show()
        );
         return;
     }





 </script>



  <div class="form_heading">

                    <strong>Factory Order Form</strong>


 </div>
  <asp:ScriptManager runat="server"></asp:ScriptManager>
   <asp:UpdatePanel UpdateMode="Always" runat="server">
   <ContentTemplate>
 <table cellpadding="0" cellspacing="0" border="1" width="100%" class="item_list">
 <tr>
 <th  style="width: 80px;">
 Order Date
 </th>
 <td width="100px">
 <asp:Label runat="server" ID="lblOrderDate"></asp:Label>
 </td>
  <th style="width: 100px;">
 Style No.
 </th>
 <td width="130px">
     <input type="text" id="txtStyleNumber" style="width: 85% ! important; color:#000; text-align:left; padding: 2px 5px;"
     class="style-number do-not-disable" runat="server" maxlength="20" />    
     <asp:HiddenField ID="hdnStyleId" Value="-1" runat="server" />
      <asp:Button ID="btnStyle" CssClass="btnClsStyle" style="display:none;"  runat="server" Text="" onclick="btnStyle_Click" />
 </td>
  <th style="width:100px;">
 Serial No.
 </th>
 <td width="100px"> 
  <input type="text" id="txtSerialNumber" style="width: 85% ! important; color:#000;  padding: 2px 5px;"
     class="serial-number do-not-disable" runat="server" maxlength="20" />
     <asp:HiddenField ID="hdnOrderId" Value="-1" runat="server" />
 </td>
  <th style="width:100px;">
 Buyer
 </th>
 <td width="100px">
 <asp:Label runat="server" ID="lblBuyer"></asp:Label>
     <asp:HiddenField ID="hdnClientId" Value="-1" runat="server" />
 </td>
  <th style="width:115px;">
 Department
 </th>
 <td width="170px">
 <asp:DropDownList Font-Size="11px" style="text-transform:capitalize;" runat="server" ID="ddlDepartment" Width="95%">
 <asp:ListItem Text="Select" Value="-1"> </asp:ListItem>
 </asp:DropDownList>
 <asp:HiddenField ID="hdnDeptID" Value="-1" runat="server" />
 </td>
  <th>
 Total Qty Order Type
 </th>
 <td>
 <asp:Label runat="server" ID="lblTotQty"></asp:Label> &nbsp;
 <asp:DropDownList runat="server" ID="ddlOrderType" Font-Size="11px" style="text-transform:capitalize;" Width="70%">
                            <asp:ListItem Text="BIPL" Value="1" Selected="True">
                            
                            </asp:ListItem>
                            <asp:ListItem Text="Kasuka through BIPL" Value="2">
                            
                            </asp:ListItem>
                            <asp:ListItem Text="Kasuka through IKANDI" Value="3" >
                            
                            </asp:ListItem>
                             <asp:ListItem Text="Value Added Style" Value="4" >
                            
                            </asp:ListItem>

                            </asp:DropDownList>

 <asp:HiddenField ID="hdnOrderType" Value="-1" runat="server" />
 </td>

 
 </tr>
 <tr>
   <th>
 BIH Target
 </th>
 <td width="100px">
 <asp:Label runat="server" ID="lblBihTgt"></asp:Label>
 </td>
 <th>
 Bulk Appr Tgt
 </th>
 <td>
  <asp:Label runat="server" ID="lblBulkTgtDate"></asp:Label>
 </td>
  <th>
 Initial Appr Tgt
 </th>
 <td>
 <asp:Label runat="server" ID="LblInitialApprTgt"></asp:Label>
 </td>
  <th>
 Account Manager
 </th>
 <td>
 <asp:Label runat="server" ID="lblAccountManager"></asp:Label>
 </td>
 <th style="width:160px;">
 Opt Prod. Time (Day) CMT
 </th>
 <td>
 <asp:Label runat="server" ID="lblProductTime"></asp:Label> / <asp:Label runat="server" ID="lblCmt"></asp:Label> 
 </td>
  
  <th>
 Description
 </th>
 <td>
     <asp:TextBox ID="txtDescription" style="text-align:left !important; height:25px;" TextMode="MultiLine" runat="server"></asp:TextBox>
     <asp:Label ID="lblDescription" style="display:none;" runat="server" Text=""></asp:Label>     
     <div style="height:12px"><img id="imgDescription" visible="false" runat="server" src="../../images/comment.png" style="float:right; padding:1px 5px; cursor:pointer;" onclick="showDescriptionPopup(this)" /></div>
 
 </td>
 
 </tr>
 
 
 </table>

 <div style="width:98%">
   <h2 class="form_heading"> Contract Detail </h2>
    <asp:GridView ID="gvContractDetail" runat="server" CssClass="item_list" AutoGenerateColumns="false" 
         onrowdatabound="gvContractDetail_RowDataBound">
    <Columns>
      <asp:TemplateField HeaderText="Line/Item No. | Contract No." ItemStyle-Width="150">
      <ItemTemplate>
      <asp:TextBox ID="txtLineItemNo" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox>&nbsp;
      <div style="height:90px; width:1px; border-right:1px solid gray; float:left; "> &nbsp;</div>
      
      
      <asp:TextBox ID="txtContractNo" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox>
      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Contract PO Upload" ItemStyle-Width="120">
      <ItemTemplate>

          <div style="float:left; width:80%;"> 
          
          <asp:FileUpload ID="PoUpload1" runat="server" />
          <asp:FileUpload ID="PoUpload2" runat="server" />
          <asp:FileUpload ID="PoUpload3" runat="server" />
          <asp:FileUpload ID="PoUpload4" runat="server" />
          </div>
           <div style="float:right; width:20%; line-height: 12px;">
            <asp:HyperLink ID="hlkPoUpload1" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
        <br />
            <asp:HyperLink ID="hlkPoUpload2" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
      <br />
            <asp:HyperLink ID="hlkPoUpload3" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
       <br />
            <asp:HyperLink ID="hlkPoUpload4" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
        </div>       
      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Qty (Pcs)" ItemStyle-Width="66">
      <ItemTemplate>
     <asp:TextBox ID="txtQuanity" runat="server"></asp:TextBox>
      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Mode" ItemStyle-Width="111">
      <ItemTemplate>
          <asp:DropDownList ID="ddlMode" runat="server">
          </asp:DropDownList>
      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="BIPL Price" ItemStyle-Width="78">
      <ItemTemplate>
      <asp:TextBox ID="txtBiplPrice" runat="server"></asp:TextBox>      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Ikandi Price" ItemStyle-Width="81">
      <ItemTemplate>
      <asp:TextBox ID="txtikandiPrice" runat="server"></asp:TextBox> 
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Pcd" ItemStyle-Width="84">
      <ItemTemplate>
      <asp:TextBox ID="txtPcdDate" runat="server"></asp:TextBox> 
      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Ex Factory [Weeks] (Delivery (DC)[Weeks])" ItemStyle-Width="170">
      <ItemTemplate>
      <asp:TextBox ID="txtExFactory"  CssClass="AllocDate do-not-allow-typing" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox>&nbsp;
      <div style="height:90px; width:1px; border-right:1px solid gray; float:left; "> &nbsp;</div>
     <asp:TextBox ID="txtDCDate" CssClass="AllocDate do-not-allow-typing" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox> 
      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Size" ItemStyle-Width="56">
      <ItemTemplate>
      
      
      </ItemTemplate>
      
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Split/ Merge" ItemStyle-Width="84">
      <ItemTemplate>
      
      
      </ItemTemplate>
      
      </asp:TemplateField>
    
    
    </Columns>
    <EmptyDataTemplate>
    <table width="100%" cellpadding="0" cellspacing="0" border="1">
    <tr>
	    <th style="width:129px">Line/Item No. | Contract No.</th>
        <th style="width:120px;">Contract PO Upload</th>
        <th style="width:66px;">Qty (Pcs)</th>
        <th style="width:111px;">Mode</th>
        <th style="width:78px;">BIPL Price</th>
        <th style="width:81px;">Ikandi Price</th>
        <th style="width:84px;">Pcd</th>
        <th style="width:170px;">Ex Factory [Weeks] (Delivery (DC)[Weeks])</th>
        <th style="width:56px;">Size</th>
        <th style="width:84px;">Split/ Merge</th>
	 </tr>

    <tr>
    <td> <asp:TextBox ID="txtLineItemNoEmpty" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox>&nbsp;
      <div style="height:90px; width:1px; border-right:1px solid gray; float:left; "> &nbsp;</div>
      
      
      <asp:TextBox ID="txtContractNoEmpty" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox>
       </td>
    <td> 
      <div style="float:left; width:80%;"> 
          
          <asp:FileUpload ID="PoUpload1Empty" runat="server" />
          <asp:FileUpload ID="PoUpload2Empty" runat="server" />
          <asp:FileUpload ID="PoUpload3Empty" runat="server" />
          <asp:FileUpload ID="PoUpload4Empty" runat="server" />
          </div>
           <div style="float:right; width:20%; line-height: 12px;">
            <asp:HyperLink ID="hlkPoUpload1Empty" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
        <br />
            <asp:HyperLink ID="hlkPoUpload2Empty" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
      <br />
            <asp:HyperLink ID="hlkPoUpload3Empty" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
       <br />
            <asp:HyperLink ID="hlkPoUpload4Empty" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" /> </asp:HyperLink>
        </div>  
    
     </td>
    <td> 
     <asp:TextBox ID="txtQuanityEmpty" runat="server"></asp:TextBox>
     </td>
    <td> 
    <asp:DropDownList ID="ddlModeEmpty" runat="server">
          </asp:DropDownList>
     </td>
    <td>  
    <asp:TextBox ID="txtBiplPriceEmpty" runat="server"></asp:TextBox>
    </td>
    <td> <asp:TextBox ID="txtikandiPriceEmpty" runat="server"></asp:TextBox> </td>
    <td> <asp:TextBox ID="txtPcdDateEmpty" CssClass="AllocDate do-not-allow-typing" runat="server"></asp:TextBox>  </td>
    <td>  <asp:TextBox ID="txtExFactoryEmpty" CssClass="AllocDate do-not-allow-typing" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox>&nbsp;
      <div style="height:90px; width:1px; border-right:1px solid gray; float:left; "> &nbsp;</div>
     <asp:TextBox ID="txtDCDateEmpty" runat="server" style="float:left; width:48%;margin-top:40px;"></asp:TextBox> </td>
    <td> <asp:HyperLink ID="hlinkEmpty" runat="server">Create</asp:HyperLink> </td>
    <td> </td>
    </tr>
    </table>
    </EmptyDataTemplate>

    </asp:GridView>
    </div>
 

 <div style="width:98%">
<table width="40%" cellpadding="0" cellspacing="0" border="1" align="left" style="display:none;" >
<tr>
<th>
Limitation Fabric Comment
 </th>

<th>
Limitation Accessories Comment </th>

</tr>
<tr>
<td>
<textarea  style="height:50px;" rows="6" cols="180"></textarea>
</td>
<td>
<textarea  style="height:50px;" rows="6" cols="180"></textarea>
</td>
</tr>
</table>

 <h2 class="form_heading"> Value Addition </h2>
  <table width="100%" style="display:none;" border="1" cellpadding="0" cellspacing="0" style="margin-bottom:5px;" class="item_list1">
    <tr>
      <th width="119">Process Name</th>
      <th width="84">Rate</th>
      <th width="66">Supplier Name</th>
      <th width="111">Time Needed</th>
      <th width="78">Feeding Per day Qty </th>
      <th width="81">Stage</th>
    </tr>
    <tr>
      <td class="per"> 
        </td>
      <td>&nbsp;<span class="gray">&#8377; 56,00 - &#8377;</span> <span class="per"> 52.00 <span class="gray">(&#8377; 4.00)</span> </span></td>
     
      <td>&nbsp;
        <select class="per" style="width:80%;">
          <option value="-1">Mehta</option>
          <option value="1">Ramesh</option>
      
        </select></td>
      <td class="per">10 Days</td>
      <td class="gray">1500</td>
      <td class="per"><input type="radio" style="width:13px"> Pre-Stitching &nbsp; &nbsp; <input type="radio"  style="width:13px"> Post-Stitching </td>
    </tr>

  </table>

<table width="100%" cellpadding="0" cellspacing="0" border="1" align="right" class="item_list1">
  <tr>
    <th width="88">Front    Image</th>
    <th width="99">Back    Image</th>
    <th width="88">Print    Image</th>
    <th> Comments </th>
    
  </tr>
  <tr>
    <td><asp:Image runat="server"  ID="imgPrint" Height="100px" Width="80px" CssClass="hide_me" />
    </td>
    <td> <asp:Image runat="server" ID="imgStyle" Height="100px" Width="80px" CssClass="hide_me" /></td>
    <td><asp:Image runat="server" ID="imagePrint" Height="100px" Width="80px" CssClass="hide_me" /></td>
    <td><textarea  style="height:80px;" rows="6" cols="180"></textarea></td>

  </tr>
</table>
</div>
 <div  class="show-div">
    <asp:Label runat="server" ID="lblDescriptionShow"></asp:Label>
    </div>

 </ContentTemplate>
    <%-- <triggers>
    <asp:PostBackTrigger ControlID="btnSubmit" />
     </triggers>--%>
    </asp:UpdatePanel>


</asp:Content>
