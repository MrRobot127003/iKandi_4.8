<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsLetterMaterialLateC45_46.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.NewsLetterMaterialLateC45_46" %>

<style type="text/css">
     body{
	background:#f9f9fa;
	font-family: Verdana,Arial,sans-serif;
	margin:0px;
	padding:0px;
	font-size:10px;	
}
    
.item_list {
    text-transform: capitalize;
	
	border-collapse:collapse;
	text-align:center;
}
.item_list th {
    color: #575759 !important;
    font-family: Verdana,Arial,sans-serif;
    font-size: 10px;
    background-color: #dddfe4;
    text-transform: capitalize !important;
    border: 1px solid #b7b4b4;
    text-align: center;
    font-weight: normal;
    padding:0px;
}
.item_list th table th {
    border: none !important;
        border-right-width: medium;
        border-right-style: none;
        border-right-color: currentcolor;
    border-right:1px solid #c2b9b9 !important
	
}
.item_list td table td {
    border: 1px solid #ddd;
        border-right-width: 0px;
        border-right-style: none;
        border-right-color: currentcolor;
		border-bottom-style: none;
		color:Gray;
		text-align:left;
	
}

.item_list td {
    overflow: hidden;
    padding: 0px !important;
    border: 1px solid #b7b4b4;
    color:Gray;    
}  
   .empty-msg 
    {
     font-family: Helvetica;
    font-size: 12px !important;
    line-height:24px;    

    text-transform: capitalize;
    border:1px solid #ccc;
    padding:0px 10px;
   
    }
    
.oneday{
	color:red;
}
.twoday{
	color:#ed41ae;
}
.threeday{
	color:#c85719;
}
.black
{
    color:Black;
}
.floatingHeader
    {
        position: fixed;
        top: 26px;
        visibility: hidden;
        margin: auto;
        z-index: 100;
        backface-visibility: hidden;
        width: 1435px !important;
    }
    
    .persist-header
    {
        table-layout: fixed;
    }
    .persist-area
    {
        position: relative;
    }
   
</style>
<script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
<script>

    // add code by bharat
    function UpdateTableHeaders() {
        $(".persist-area").each(function () {
            var el = $(this),
               offset = el.offset(),
               scrollTop = $(window).scrollTop(),
               floatingHeader = $(".floatingHeader", this)
            if ((scrollTop > offset.top) && (scrollTop < offset.top + el.height())) {
                floatingHeader.css({
                    "visibility": "visible"

                });
            } else {
                floatingHeader.css({
                    "visibility": "hidden"
                });
            };
        });
    }

    $(function () {
        var clonedHeaderRow;
        $(".persist-area").each(function () {
            clonedHeaderRow = $(".persist-header", this);
            clonedHeaderRow
             .before(clonedHeaderRow.clone())
             .css("width", clonedHeaderRow.width())
             .addClass("floatingHeader");
        });
        $(window)
        .scroll(UpdateTableHeaders)
        .trigger("scroll");
    });
</script>
    <div style="text-align: center; padding: 5px 0px; background-color: #405D99; color: #FFFFFF;
        font-weight: bold; font-size: 14px; text-transform: capitalize; font-family: Verdana;
        width: 1435px; margin: 0px auto 17px; position: relative">
        <div style="text-align: center; padding: 5px 0px; background-color: #405D99; color: #FFFFFF;
            font-weight: bold; font-size: 14px; text-transform: capitalize; font-family: Verdana;
            width: 1435px; position: fixed; top: 0; z-index: 1000;">
            <span style="font-weight: bold;">Material Late (C 45-46)</span>
        </div>
    </div>
    <asp:GridView ID="gvMaterialShort" Width="1435px" AutoGenerateColumns="false" 
        CssClass="item_list persist-area" runat="server"         
        onrowdatabound="gvMaterialShort_RowDataBound" style="margin:0px auto;">
    <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
    Style Code<br />    
    Line No. <br />
    frame<br />
    Serial No.
    </HeaderTemplate>
    <HeaderStyle Width="60px" />
    <ItemTemplate>
     <table style="border:0px;" width="100%" cellspacing="0" cellpadding="0" frame="void" rules="all">
        <tbody><tr>
          <td style="margin-top:5px; text-align:center;">
     <asp:Label runat="server" ID="lblStyleCode" CssClass="black" Text='<%# Eval("StyleCode") %>'></asp:Label> 
     </td>
          </tr>
        <tr>
          <td>
     <asp:Label runat="server"  CssClass="black" ID="lblLineNo" Text='<%# Eval("LineNo") %>'></asp:Label>
     </td>
          </tr>
        <tr>
          <td>
     <asp:Label runat="server"  CssClass="black" ID="lblFrame" Text='<%# Eval("LinePlanFrameId") %>'></asp:Label>
      </td>
          </tr>
        <tr>
          <td>
     <asp:Label runat="server" CssClass="black"  ID="lblSerialNumber" Text=""></asp:Label>
      </td>
          </tr>
          </tbody>
        </table>
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    </asp:TemplateField>


    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
    <HeaderTemplate>
    St. ExFact Dt.<br />
    Lst. ExFact Dt. </br>
    Frame St. Dt. <br />
    Frame End Dt.
    </HeaderTemplate>
    <HeaderStyle Width="80px" />
    <ItemTemplate>
    <table style="border:0px;" width="100%" cellspacing="0" cellpadding="0" frame="void" rules="all">
        <tbody><tr>
          <td style="margin-top:5px; text-align:center;">
          <asp:Label runat="server" ID="lblExFactStDate"  CssClass="black" Text='<%# (Convert.ToDateTime(Eval("MinExFactory")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("MinExFactory"))).ToString("dd MMM (ddd)")%>' ></asp:Label> <br />
         </td>
          </tr>
        <tr>
          <td style="text-align:center;">
           <asp:Label runat="server" ID="lblExFactEndDate"  CssClass="black" Text='<%# (Convert.ToDateTime(Eval("MaxExFactory")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("MaxExFactory"))).ToString("dd MMM (ddd)")%>'></asp:Label>
    
           </td>
          </tr>
        <tr>
          <td style="text-align:center;">
          <asp:Label runat="server" ID="lblFrameStDate" Text='<%# (Convert.ToDateTime(Eval("FrameStartDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("FrameStartDate"))).ToString("dd MMM (ddd)")%>'></asp:Label>
    
           </td>
          </tr>
        <tr>
          <td style="text-align:center;">
           <asp:Label runat="server" ID="lblFrameEndDate" Text='<%# (Convert.ToDateTime(Eval("FrameEndDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("FrameEndDate"))).ToString("dd MMM (ddd)")%>'></asp:Label>
  
          
           </td>
          </tr>
      </tbody></table>

      </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    </asp:TemplateField>


    <asp:TemplateField>
    <HeaderTemplate>
   Fabric
     <br />

     <br />

     <table style="border:0px;margin-top: 20px; margin-bottom:5px;" width="100%" cellspacing="0" cellpadding="0" border="1">
      <tbody><tr>
        <th style="width:150px">Fabric Qlty </th>
        <th style="width:120px">Colour</th>
        <th style="width:60px">Serial No.</th>
        <th style="width:75px">Contract No.</th>
        <th style="width:75px;">Short Date </th>
        <th style="width:75px;">Start Eta </th>
        <th style="width:75px;border-right: 0px !important;">End Eta </th>
      </tr>
      
      </tbody></table>

    </HeaderTemplate>
    <HeaderStyle Width="630px" />
    <ItemTemplate>
     <table cellpadding="0" cellspacing="0" rules="all" frame="void" width="100%">
        <asp:Repeater ID="rptFabric" OnItemDataBound="rptFabric_ItemDataBound" runat="server">
        <ItemTemplate>      
        <tr>
         <td style="width:150px; margin-top:5px;padding-left:5px !important;"><asp:Label ID="lblFabric" runat="server" Text='<%# Eval("FabricName") %>'></asp:Label></td>
            <td style="width:120px;"><asp:Label ID="lblFabColor" runat="server" Text='<%# Eval("FabricColor") %>'></asp:Label></td>
            <td style="width:60px; text-align:center;"><asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label></td>
            <td style="width:75px; text-align:center;"><asp:Label ID="lblContractNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label></td>
            <td style="width:75px; text-align:center;">
            <asp:Label ID="lblFabShortDate" Font-Size="9px" runat="server" Text='<%# (Convert.ToDateTime(Eval("FabricShortDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("FabricShortDate"))).ToString("dd MMM (ddd)")%>'></asp:Label>
            <asp:HiddenField runat="server" ID="hdnFabricShortDate" Value='<%# Eval("FabricShortDate") %>' />           
            
            </td>
            <td style="width:75px; text-align:center;"><asp:Label ID="lblFabStartEta"  runat="server" Font-Size="9px" Text='<%# (Convert.ToDateTime(Eval("FabricStartEta")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("FabricStartEta"))).ToString("dd MMM (ddd)")%>'></asp:Label></td>
            <td style="width:75px; text-align:center;"><asp:Label ID="lblFabEndEta" runat="server" Font-Size="9px" Text='<%# (Convert.ToDateTime(Eval("FabricEndEta")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("FabricEndEta"))).ToString("dd MMM (ddd)")%>'></asp:Label></td>
        </tr>
        
    </ItemTemplate>    
    </asp:Repeater> 
          </table>  
    </ItemTemplate>
 
     <ItemStyle VerticalAlign="Top" />
    </asp:TemplateField>
   
    <asp:TemplateField>
    <HeaderTemplate>
     Accessories
     <br />

     <br />

    <table style="border:0px;margin-top: 20px; margin-bottom:5px;" width="100%" cellspacing="0" cellpadding="0" border="1">
      <tbody><tr>
        <th style="width:130px">Acc. Qlty </th>
        <th style="width:60px">Serial No.</th>      
        <th style="width:75px">Contract No.</th>
        <th style="width:75px;">Short Date </th>
        <th style="width:75px;border-right: 0px !important;">ETA</th>
      </tr>
      
      </tbody></table>

    </HeaderTemplate>
    <HeaderStyle Width="415px" />
    <ItemTemplate>
     <table cellpadding="0" cellspacing="0" rules="all" frame="void" width="100%">
     <asp:Repeater ID="rptAccess" runat="server"  OnItemDataBound="rptAcc_ItemDataBound">
        <ItemTemplate>   
        <tr>
            <td style="width:130px; margin-top:5px; padding-left:5px !important;"><asp:Label ID="lblAccQty" runat="server" Text='<%# Eval("AccessName") %>'></asp:Label></td> 
            <td style="width:60px; text-align:center;"><asp:Label ID="lblAccSerialNo" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label></td> 
              <td style="width:75px; text-align:center;"><asp:Label ID="lblAccContractNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label></td>              
            <td style="width:75px; text-align:center;">
            <asp:Label ID="lblAccShortDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("AccessShortDate")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("AccessShortDate"))).ToString("dd MMM (ddd)")%>'></asp:Label>
            <asp:HiddenField runat="server" ID="hdnAccShortDate" Value='<%# Eval("AccessShortDate") %>' />
            </td>
            <td style="width:75px; text-align:center;"><asp:Label ID="lblAccEta" runat="server" Font-Size="9px" Text='<%# (Convert.ToDateTime(Eval("AccessEta")) == Convert.ToDateTime("1/1/0001")) ? "" : (Convert.ToDateTime(Eval("AccessEta"))).ToString("dd MMM (ddd)")%>'></asp:Label></td>
                
        </tr>
    
     </ItemTemplate>
    </asp:Repeater> 
     </table>
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    </asp:TemplateField>
    <asp:TemplateField>
    <HeaderTemplate>
    Others
     <br />

     <br />

  <table style="border:0px;margin-top: 20px; margin-bottom:5px;" width="100%" cellspacing="0" cellpadding="0" border="1">
      <tbody><tr>
        <th style="width:60px;">Serial No.</th>
        <th style="width:100px;">Status/ Wip</th>
        <th style="width:80px;border-right: 0px !important;">Eta/ CWIP(Pcs) </th>
      </tr>
      
      </tbody></table>

    </HeaderTemplate>
    <HeaderStyle Width="250px" />
    <ItemTemplate>
    <div style="overflow-x:hidden; max-height:200px;">
     <table cellpadding="0" cellspacing="0" rules="all" frame="void" width="100%">
        <asp:Repeater ID="rptStatus" OnItemDataBound="rptStatus_ItemDataBound" runat="server">
        <ItemTemplate>      
        <tr>
        <td style="width:60px; margin-top:5px;  padding-left:5px !important;"><asp:Label ID="lblSerialNumber" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label></td>
        <td style="width:100px; margin-top:5px; text-align:center;"><asp:Label ID="lblStaus" runat="server" Text='<%# Eval("status") %>'></asp:Label></td>
         <td style="width:80px; text-align:center;"><asp:Label ID="lblStausEta" Font-Size="9px" CssClass="oneday" runat="server" Text=""></asp:Label></td>
            
        </tr>        
    </ItemTemplate>    
    </asp:Repeater> 
          </table> 
          </div>
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    </asp:TemplateField>
    </Columns>
     <HeaderStyle CssClass="persist-header" />
    </asp:GridView>
    <br />
    <br />
