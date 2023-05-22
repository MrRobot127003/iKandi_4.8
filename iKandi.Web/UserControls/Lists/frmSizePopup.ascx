<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmSizePopup.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.frmSizePopup" %>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
<script type="text/javascript">

    function ordersize_popupclose() {
        self.parent.Shadowbox.close();
    }
</script>

<style type="text/css">
   .item_list TD {
  
    text-align: left;
}
.item_list th
{
    background-color: #39589c;
    color:#fff!important;
    text-transform:capitalize;
}
body{text-transform:capitalize !important;}  

    label{font-size:12px !important; color:#ffffff !important;}

    td{border:1px solid #e6e6e6 !important; border-bottom:2px solid #e6e6e6 !important;}

    

    .item_list2{border-collapse: collapse; border: 2px solid #e6e6e6; margin-right: 0px;}

    .item_list2 TD{ padding: 2px !important; background-color: #f9f9fa; border: 1px solid #e6e6e6; text-align: left; vertical-align:top;}

    .item_list2 TH{ color: #98a9ca; font-size:8px; width:100%; line-height:15px; vertical-align:top; background-color:#39589c; text-transform: capitalize; border: 1px solid #e6e6e6; text-align: left; padding: 4px; height:10px; font-weight: normal;}

    .item_list2 TD input[type=text], .item_list1 TD textarea{color: #0000ff; border: 0; width: 100%; text-align: center; vertical-align: middle;}

    .item_list2 TD select{ color: #0000ff;}

    .inner_item_list2 TD input[type=text], .item_list2 TD textarea{ border: 0; width: 100%;}

    .item_list2 a{text-decoration: none; text-transform:capitalize !important;}

    .item_list2 a:hover{ text-decoration: none; text-transform:capitalize !important;}

    span{text-transform:capitalize !important;}

  

    .hidelabel

    {

        display: none;

    }

    .aligntext

    {

        text-align:left;

    }

    .lblDateAlign

    {

        text-align:center;

    }

    hr {

border: 1;

height: 1px;

 

}
.line-format
{
 font-size:8px !important; background:none; margin-top:2px; text-align:left !important; color:#807F80 !important;   
}
.line-format2
{
 font-size:8px !important; background:none !important; margin-top:2px; text-align:left !important;  color:Blue !important;   
}



/*-------------------------add by Prabhaker-5-nov------------------------*/
  
   .floatingHeader {
      position: fixed;
      top: 0px;
      visibility: hidden;
     
      margin:auto; 
      z-index:100000;
      backface-visibility: hidden;
      width:1552px !important;
    }
      .persist-header {
        table-layout:fixed;
        
        }
        
/*------------------------------------------------End-css-5-nov---------------------*/
/*-------------Add by abhishek- 22/2/2016-------------*/
.photoshot input[type='checkbox']:checked
{
    opacity:1 !important;
}
.mo-reallocation-img img
{
    height:20px;
    width:20px;
}
/*-------------end by abhishek- 22/2/2016-------------*/
.production-sec
{
    table-layout:fixed;
}
                
.production-sec td
{
    padding:0px !important;
}

.production-sec td input[type="text"], .item_list1 TD textarea 
{
    width:92%;
}


        .table td
        {
            text-align:center;
        }
.ui-widget {
    font-family: arial,sans-serif;
    font-size: 11px;
}
 .ui-widget input, .ui-widget select, .ui-widget textarea, .ui-widget button {
    font-family: arial,sans-serif;
    font-size: 1em;
}    
</style>


<div class="form_box" id="ordersize_wrapper">
 <div class="form_heading" >Order Sizes <span style="float:right;padding:0 10px;cursor:pointer;" onclick="ordersize_popupclose()">X</span></div>
<asp:ObjectDataSource ID="odsBasicInfo" runat="server" SelectMethod="GetOrderDetailSizes"
    TypeName="iKandi.BLL.OrderController"></asp:ObjectDataSource>
<asp:GridView CssClass="item_list" ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataSourceID="odsBasicInfo">
    <Columns>
        <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" ItemStyle-CssClass="numeric_text" />
        <asp:BoundField DataField="QuantityString" HeaderText="Quantity" SortExpression="Quantity" ItemStyle-CssClass="numeric_text"/>
        <asp:BoundField DataField="RatioPackString" HeaderText="Ratio Pack" SortExpression="RatioPack" ItemStyle-CssClass="numeric_text" />
        <asp:BoundField DataField="RatioString" HeaderText="Ratio" SortExpression="Ratio" ItemStyle-CssClass="numeric_text" />
        <asp:BoundField DataField="SinglesString" HeaderText="Singles" SortExpression="Singles" ItemStyle-CssClass="numeric_text"  />
    </Columns>
</asp:GridView>
</div>