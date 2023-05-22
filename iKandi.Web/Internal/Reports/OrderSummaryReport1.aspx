<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSummaryReport1.aspx.cs" Inherits="iKandi.Web.OrderSummaryReport1" MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="~/UserControls/Reports/OrderSummary.ascx" TagName="OrderSummaryReport"
    TagPrefix="uc1" %>
   <asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
   
    <script type="text/javascript">
    
var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';
var proxy = new ServiceProxy(serviceUrl);
var ddlClientsClientID ='<%=ddlClients.ClientID%>';
var searchText ="";
var FromDate="";
var ToDate ="";
var tab = 1;

$(function() {
$("#"+ddlClientsClientID).val(-1);
 loadGrid1($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
 
  
  $("#refresh").click(function() {
      loadGrid1($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
      loadGrid2($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
      loadGrid3($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
      loadGrid4($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
      loadGrid5($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());  
   });
  
  $("#tabs").tabs({

    select: function(e, ui) {

      var thistab = ui.index+1;
      if(thistab == 1)
      {
      loadGrid1($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
      tab = 1;
      }
      if(thistab == 2)
      {
       loadGrid2($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       tab = 2;
      }
      if(thistab == 3)
      {
      loadGrid3($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       tab = 3;
      }
      if(thistab == 4)
      {
      loadGrid4($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       tab = 4;
      }
      if(thistab == 5)
      {
      loadGrid5($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       tab = 5;
      }
    }

  });
  
   $("#"+ddlClientsClientID).change(function() {
   
   var ClientID = $("#"+ddlClientsClientID).val();
   proxy.invoke("ShowClientSummaryReport", {ClientID:ClientID} ,
    function(result) {
                     
	      $("#client-summary").html(result)
         
         },
         
    onPageError, false, false);
        
   });

});

function loadGrid1(searchText,FromDate,ToDate,ClientID)
 {
  if(ClientID > -1)
    {
    proxy.invoke("GetOrdersBasicInfoReport", {searchText:searchText,FromDate:FromDate,ToDate:ToDate,ClientID:ClientID} ,
    function(result) {
	      $("#grdPanel1").html(result)
         
         },
         
    onPageError, false, false);
    }
    else
   {
    $("#grdPanel1").html('<div class="form_heading">Please Select Client To View The Results</div>');
               
   }
 }

function loadGrid2(searchText,FromDate,ToDate,ClientID)
 {
 if(ClientID > -1)
 {
    proxy.invoke("GetOrdersFabricReport", {searchText:searchText,FromDate:FromDate,ToDate:ToDate,ClientID:ClientID} ,
    function(result) {
            
	      $("#grdPanel2").html(result)
        
         },
         
    onPageError, false, false);
   }
   else
   {
    $("#grdPanel2").html('<div class="form_heading">Please Select Client To View The Results</div>');
               
   }
 }
function loadGrid3(searchText,FromDate,ToDate,ClientID)
 {
  if(ClientID > -1)
 {
    proxy.invoke("GetOrderAccessoriesReport", {searchText:searchText,FromDate:FromDate,ToDate:ToDate,ClientID:ClientID} ,
    function(result) {
                     
	      $("#grdPanel3").html(result)
         
         },
         
    onPageError, false, false);
   }
   else
   {
    $("#grdPanel3").html('<div class="form_heading">Please Select Client To View The Results</div>');
               
   }
 }

function loadGrid4(searchText,FromDate,ToDate,ClientID)
 {
  if(ClientID > -1)
    {
    proxy.invoke("GetOrderCuttingReport", {searchText:searchText,FromDate:FromDate,ToDate:ToDate,ClientID:ClientID} ,
    function(result) {
                     
	      $("#grdPanel4").html(result)
         
         },
         
    onPageError, false, false);
    }
   else
   {
    $("#grdPanel4").html('<div class="form_heading">Please Select Client To View The Results</div>');
               
   }
 }
function loadGrid5(searchText,FromDate,ToDate,ClientID)
 {
 if(ClientID > -1)
    {
    proxy.invoke("GetOrderStichingReport", {searchText:searchText,FromDate:FromDate,ToDate:ToDate,ClientID:ClientID} ,
    function(result) {
                     
	      $("#grdPanel5").html(result)
         
         },
         
    onPageError, false, false);
    }
  else
   {
    $("#grdPanel5").html('<div class="form_heading">Please Select Client To View The Results</div>');
               
   }
 }

  function searchGrid()
  {
       if(tab ==1)
       {
       loadGrid1($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       } 
       
       if(tab==2)
       {
       loadGrid2($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       } 
       
       if(tab==3)
       {
       loadGrid3($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       }
       
       if(tab==4)
       {
       loadGrid4($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       } 
       
       if(tab==5)
       {
       loadGrid5($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
       } 
     
       return false; 
  }

</script>
        
      
   <div class="print-box">
    <div class="grid_heading" cssclass="item_list">
        Manage Orders</div>
    <br />
    <div id="result">
        <a href="#" id="refresh">Refresh</a>
    </div>
    <div id="search">
        <table width="400px" cellspacing="10">
            <tr>
                <td>
                    <asp:HiddenField ID="hdntab" runat="server" />
                    <asp:Label ID="lablsearch" Text="Search Text" runat="server"></asp:Label>
                </td>
                <td>
                    <input type="text" id="txtsearch" />
                </td>
                <td>
                    <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label>
                </td>
                <td>
                    <input type="text" id="txtfrom" class="date-picker" />
                </td>
                <td>
                    <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>
                </td>
                <td>
                    <input type="text" id="txtTo" class="date-picker" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlClients" runat="server">
                    <asp:ListItem  Value="-1" >Select..</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <input type="button" class="search" onclick="searchGrid();return false;" />
                </td>
            </tr>
        </table>
    </div>
     <div class="form_box" id="client-summary">
        </div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Merchandising</a></li>
            <li><a href="#tabs-2">Fabric</a></li>
            <li><a href="#tabs-3">AccesSories</a></li>
            <li><a href="#tabs-4">Cutting</a></li>
            <li><a href="#tabs-5">Stitching</a></li>
        </ul>
        <div id="tabs-1">
            <div class="form_box">
                <div class="form_heading">
                    Basic Info
                </div>
                <div id="grdPanel1">
                <div class="form_heading">Please Select Client To View The Results</div>
                </div>
            </div>
        </div>
        <div id="tabs-2">
            <div class="form_box">
                <div class="form_heading">
                    Fabric
                </div>
                <div id="grdPanel2"><div class="form_heading">Please Select Client To View The 
                    Results</div>
                </div>
             
            </div>
        </div>
        <div id="tabs-3">
            <div class="form_box">
                <div class="form_heading">
                    Accesories
                </div>
                <div id="grdPanel3"><div class="form_heading">Please Select Client To View The 
                    Results</div>
                </div>
            </div>
        </div>
        <div id="tabs-4">
            <div class="form_box">
                <div class="form_heading">
                    Cutting
                </div>
                <div id="grdPanel4"><div class="form_heading">Please Select Client To View The 
                    Results</div>
                </div>
            </div>
        </div>
        <div id="tabs-5">
            <div class="form_box">
                <div class="form_heading">
                    Stitching
                </div>
                <div id="grdPanel5"><div class="form_heading">Please Select Client To View The 
                    Results</div>
                </div>
                
            </div>
        </div>
    </div>
  </div>   
   </asp:Content>