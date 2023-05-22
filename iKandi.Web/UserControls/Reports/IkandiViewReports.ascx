<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IkandiViewReports.ascx.cs" Inherits="iKandi.Web.IkandiViewReports" %>
<script type="text/javascript">
var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
var proxy = new ServiceProxy(serviceUrl);
var searchText ="";
var FromDate="";
var ToDate ="";
var tab = 1;
var ddlClientsClientID ='<%=ddlClients.ClientID %>';
$(function() {
$("#"+ddlClientsClientID).val(-1);
 $("#refresh").click(function() {
        
   });
  $("#tabs").tabs({

    select: function(e, ui) {

      var thistab = ui.index+1;
      if(thistab == 1)
      {
        if($("#"+ddlClientsClientID).val()>-1)
        {
            loadGrid1($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
        }
       tab = 1;
      }
      if(thistab == 2)
      {
        if($("#"+ddlClientsClientID).val()>-1)
        {
            loadGrid2($("#txtsearch").val(),$("#txtfrom").val(),$("#txtTo").val(),$("#"+ddlClientsClientID).val());
        }
       tab = 2;
      }
    }

  });

});


 function loadGrid1(searchText,FromDate,ToDate,ClientID)
 {
    proxy.invoke("GetiKandiViewReportFinancials", {searchText:searchText,FromDate:FromDate,ToDate:ToDate,ClientID:ClientID} ,
    function(result) {
                     
	      $("#grdPanel1").html(result)
         
         },
         
    onPageError, false, false);
 }
 
 function loadGrid2(searchText,FromDate,ToDate,ClientID)
 {
    proxy.invoke("GetiKandiViewReportTechnicals", {searchText:searchText,FromDate:FromDate,ToDate:ToDate,ClientID:ClientID} ,
    function(result) {
                     
	      $("#grdPanel2").html(result)
         
         },
         
    onPageError, false, false);
 }
 
 function onPageError(error)
 {
   alert(error.Message + ' -- ' +error.detail);
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
     
       return false; 
  }
</script>


<div class="print-box">
<div class="grid_heading" cssclass="item_list">
    iKandi View Reports</div>
    <br />
 <div id="result">
    <a href="#" id="refresh">Refresh</a>
</div>
<div id="search">
    <table width="400px" cellspacing="10">
        <tr>
            <td width="30px">
                Search Text
            </td>
            <td>
                <input type="text" id="txtsearch" />
            </td>
            <td>
                From
            </td>
            <td>
                <input type="text" id="txtfrom" class="date-picker date_style" />
            </td>
            <td>
                To
            </td>
            <td>
                <input type="text" id="txtTo" class="date-picker date_style" />
            </td>
            <td>
                <asp:DropDownList ID="ddlClients" runat="server">
                    <asp:ListItem Value="-1">Select..</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <input type="button" class="search" onclick="searchGrid();return false;" />
            </td>
        </tr>
    </table>
    </div>
    
    <div id="tabs">
      <ul>
        <li><a href="#tabs-1">Financials</a></li>
        <li><a href="#tabs-2">Technical</a></li>
    </ul>
    <div id="tabs-1">
     <div class="form_box">
            <div class="form_heading">
                Financials
            </div>
            <div id="grdPanel1"><div class="form_heading">Please Select Client To View The Results</div>
            </div>
          <%--  <input type="button" class="submit" />--%>
        </div>
    </div>
    <div id="tabs-2">
        <div class="form_box">
            <div class="form_heading">
                Technical
            </div>
            <div id="grdPanel2"><div class="form_heading">Please Select Client To View The Results</div>
            </div>
           <%-- <input type="button" class="submit" />--%>
        </div>
    </div>
</div>
</div>
<%-- <input type="button" id="btnPrint" class="print" onclick="return PrintPDF();" />--%>
