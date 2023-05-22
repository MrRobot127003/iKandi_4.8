<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="PendingSTC.aspx.cs" Inherits="iKandi.Web.PendingSTC" EnableEventValidation="false" %>

<%@ Register src="../../UserControls/Lists/SealersPendingList.ascx" tagname="SealersPendingList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID=cph_main_content runat=server >

 
<script type="text/javascript">

var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';
var proxy = new ServiceProxy(serviceUrl);

$(function()
 {

 });
 

 function onPageError(error)
 {
   alert(error.Message + ' -- ' +error.detail);
 }
 
//  function submitForm()
//  {
//       var queryString = $('#grdPanel').serializeNoViewState();

//       $.post('PendingSTC.aspx?callback=savependingstc', queryString, function(message){
//         
//       jQuery.facebox('Data has been saved successfully!');
//       
//         //TODO: Refresh Grid 
//       }); 
//    
//       return false; 
//  }
  

  
  
 
</script>
<div class="print-box">
<div class="grid_heading" cssclass="item_list">
    PENDING STC FILE</div>
<br />
<div id="grdPanel">
   
    <uc1:SealersPendingList ID="SealersPendingList1" runat="server" />
   
</div>
</div>
<br />
<div>
    <%--<input type="button"  class="save" onclick="submitForm();return false;" />--%>
   
   <%-- <input type="button" id="btnPrint" class="print"  onclick="return PrintPDF();" />--%>
</div>
 

 

</asp:Content>