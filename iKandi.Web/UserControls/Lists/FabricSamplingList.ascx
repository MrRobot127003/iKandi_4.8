<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricSamplingList.ascx.cs"
    Inherits="iKandi.Web.FabricSamplingList" %>

<script type="text/javascript">

var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
var proxy = new ServiceProxy(serviceUrl);

$(function()
 {
 
    $('.numeric-field-without-decimal-places').keyup(function(e)
    {
        CancelShiftOperation(e);        
    });
    
    $('.numeric-field-without-decimal-places').keydown(function(e)
    {
        e = e || window.event;
        return ValidateNumericFields(e.keyCode, $(this), false);
    });
    
    $('.numeric-field-with-two-decimal-places').keydown(function(e)
    {
        e = e || window.event;
        return ValidateNumericFields(e.keyCode, $(this), true, 2);
    });
    
    
    
   loadGrid();
       
   $("#refresh").click(function() {
        loadGrid();
   });
   
 });
 
 function setupControls()
 {
     $(".fabric-millname").autocomplete( "/Webservices/iKandiService.asmx/SuggestFabricMill", { dataType: "xml", datakey: "string", max: 100 });
     $(".fabric-printnumber").autocomplete( "/Webservices/iKandiService.asmx/SuggestPrintNumber", { dataType: "xml", datakey: "string", max: 100 });
     $('.date-picker').datepicker( {dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif'});
     
     $(".fabric-printnumber").change(function()
     {
        var objRow = $(this).parents("tr");
         
         //Get the  details from database
         
         var printNumber=$(this).val();
         var rowIndex = objRow.get(0).rowIndex;
         
         proxy.invoke("GetSamplingFabricByPrintNumber", {PrintNumber:printNumber} ,
         function(results) {
            
            objRow.find(".fabric-history"  ).hide();

            if(results != null && results.length > 0)
            { 
                objRow.find(".fabric-client").text(( results[0].ClientName == null || results[0].ClientName == 'null') ? "" : results[0].ClientName  );
                objRow.find(".fabric-designer").text(( results[0].DesignerName == null || results[0].DesignerName == 'null') ? "" : results[0].DesignerName  );
                objRow.find(".fabric-samplemerchandiser").text(( results[0].SampleMerchandiserName == null || results[0].SampleMerchandiserName == 'null') ? "" : results[0].SampleMerchandiserName  );
                objRow.find(".fabric-millname").val(( results[0].MillName == null || results[0].MillName == 'null') ? "" : results[0].MillName  );
                objRow.find(".fabric-milldesignnumber").val(( results[0].MillDesignNumber == null || results[0].MillDesignNumber == 'null') ? "" : results[0].MillDesignNumber  );
                objRow.find(".fabric-fabric").text(( results[0].Fabric == null || results[0].Fabric == 'null') ? "" : results[0].Fabric  );                
                objRow.find("#printTypeID" + rowIndex).val( results[0].PrintTypeID  );                
                objRow.find("#printTechnologyID" + rowIndex).val( results[0].PrintTechnologyID  );               
                objRow.find("#printTypeID" + rowIndex).val( results[0].PrintTypeID  ); 
                objRow.find("#quantityOrdered" + rowIndex).val( results[0].QuantityOrdered  ); 
                objRow.find("#quantityReceived" + rowIndex).val( results[0].QuantityReceived  ); 
                objRow.find("#originID" + rowIndex).val( results[0].OriginID  ); 
                objRow.find(".fabric-isnew" + rowIndex).text( results[0].IsNew  ); 
                objRow.find("#numberOfScreens" + rowIndex).val( results[0].NumberOfScreens  ); 
                objRow.find("#costPerScreen" + rowIndex).val( results[0].CostPerScreen  ); 
                objRow.find("#costPerScreen" + rowIndex).val( results[0].CostPerScreen  ); 
                objRow.find("#costCurrencyID" + rowIndex).val( results[0].CostCurrencyID  ); 
                objRow.find("#totalAmount" + rowIndex).text( results[0].TotalAmount  ); 
                objRow.find("#totalAmount" + rowIndex).val( results[0].TotalAmount  ); 
                objRow.find("#remarks" + rowIndex).val( results[0].Remarks  ); 
                objRow.find("#dateOfReceiving" + rowIndex).val( results[0].DateOfReceiving.formatDate()  ); 
                objRow.find("#expectedIssueDate" + rowIndex).val( results[0].ExpectedIssueDate.formatDate()  ); 
                objRow.find("#actualIssueDate" + rowIndex).val( results[0].ActualIssueDate.formatDate()  ); 
                objRow.find("#expectedReceiptDate" + rowIndex).val( results[0].ExpectedReceiptDate.formatDate()  ); 
                objRow.find("#actualReceiptDate" + rowIndex).val( results[0].ActualReceiptDate.formatDate()  ); 
                objRow.find(".fabric-statusissuing").text( results[0].StatusIssuing  ); 
                objRow.find(".fabric-statusreceiving").text( results[0].StatusReceving  ); 
                
                objRow.find(".fabric-history").show();

                
            } 
            else
            {
                proxy.invoke("GetPrintDetailByPrintNumber", {PrintNumber:printNumber} ,
                 function(result) {
                    if(result != null )
                    {
                        objRow.find(".fabric-client").text(( result.ClientName == null || result.ClientName == 'null') ? "" : result.ClientName  );
                        objRow.find(".fabric-designer").text(( result.DesignerName == null || result.DesignerName == 'null') ? "" : result.DesignerName  );
                        objRow.find(".fabric-samplemerchandiser").text(( result.SampleMerchandiserName == null || result.SampleMerchandiserName == 'null') ? "" : result.SampleMerchandiserName  );                        
                    } 
                 },
                 onPageError, false, false);
            }  
         },
         onPageError, false, false);
     });
 }  
 
  function loadGrid()
 {
 
 // TODO: Date issue
 
    proxy.invoke("GetAllSamplingFabric", {SearchText:($("#<%=txtSearch.ClientID%>")).val()} ,
    function(result) {
             
          for(var index in result)
          {
            result[index].DateOfReceiving = result[index].DateOfReceiving.formatDate();
            result[index].ExpectedIssueDate = result[index].ExpectedIssueDate.formatDate();
            result[index].ActualIssueDate = result[index].ActualIssueDate.formatDate();
            result[index].ExpectedReceiptDate = result[index].ExpectedReceiptDate.formatDate();
            result[index].ActualReceiptDate = result[index].ActualReceiptDate.formatDate();
          }             
             
          // attach the template
	      $("#grdPanel").setTemplateElement("templateFabricSampling");
			
          $("#grdPanel").setParam('x', 1);				
			
          // process the template
	      $("#grdPanel").processTemplate(result);

          setupControls();
          
          $("#tblFabrics tr:last").find("input,textarea,select").val("");
          $("#tblFabrics tr:last").find("span").text("");
         },
         
    onPageError, false, false);
 
 }
 

 function onPageError(error)
 {
   alert(error.Message + ' -- ' +error.detail);
 }
 
  function submitForm()
  {
       var queryString = $('#grdPanel').serializeNoViewState();

       $.post('FabricSampling.aspx?callback=savesamplingfabric', queryString, function(message){
         //TODO After save check if there is any error then display 
         
         jQuery.facebox('Data has been saved successfully!');
         
         // Refresh the grid with latest data.
         // TODO: Optimize this to update only to new entries
         loadGrid();         
       }); 
    
       return false; 
  }
  
 function addRow()
 {  
   var rowCount = $("#tblFabrics tr").length - 1; // -1 to avoid the table header row
     
   var lastRow = $("#tblFabrics tr:last");
   
   var row = $("#tblFabrics tr:last").clone(true).insertAfter($("#tblFabrics tr:last"));
  
   var newLastRow = $("#tblFabrics tr:last");
   
   newLastRow.find("input,select,textarea").val("").each(function()
   {
      
      var name = $(this).attr("name"); 
      name = name.replace(/[0-9]*/g, '');
      $(this).attr("name",  name + (rowCount+1)  );
      
      var id = $(this).attr("id");   
      id = id.replace(/[0-9]*/g, '');
      $(this).attr("id",  id + (rowCount+1)  );
   
   });
   
   newLastRow.find("span").text("");
   
   newLastRow.find("input:first").focus();   
 }    
 
 function deleteRow( srcElem)
 {
  var objRow = $(srcElem).parents("tr");
  objRow.hide();  
  
  objRow.find("#courierID"+ (objRow.get(0).rowIndex)).val("0"); // -1 for new, 0 for delete and rest +ve to update the record
 }
 
  function showFabricHistory()
  { 
     var objRow = $(event.srcElement).parents("tr");
  
     var printNumber = objRow.find(".fabric-printnumber").val();

     proxy.invoke("GetPrintFabricHistoryView", {PrintNumber:printNumber} , function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
 
 
</script>
<div class="print-box">
    <div>
    Search:
    <asp:TextBox runat="server" ID="txtSearch" CssClass="do-not-disable"></asp:TextBox>
     <asp:Button ID="btnSearch" runat="server" CssClass="do-not-disable go" Text="Search"  OnClientClick="loadGrid();return false;"   />
    </div>
<div class="grid_heading">
    Fabric Sampling</div>
<br />
<div id="result">
    <a href="#" id="refresh">Refresh</a> <%--<a href="#" onclick="addRow()">Add </a>--%>
</div>
<br />
<div id="grdPanel">
</div>
</div>
<br />
<div>
    <input type="button" class="add" onclick="addRow()" />
    <input type="button" class="submit" value="Submit" onclick="submitForm();return false;" />
 
    <input type="button" id="btnPrint" class="print da_submit_button" value="Print"  onclick="return PrintPDF();" />
</div>
<!-- Template content -->
<textarea id="templateFabricSampling" class="hide_me"> 
	 
		<table cellspacing="0" border=1  rules=all  width="100%" class="item_list" id="tblFabrics">
		
		    <tr>
			<th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_PRINT_DESIGN_NUMBER_LAB_DIPS)? "":"hide_me" %>'>PRINT NUMBER</th><th scope="col" class="vertical_header" >Buyer</th><th scope="col" class="vertical_header">Designer</th><th scope="col" class="vertical_header">Merchant</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_MILL_NAME)? "":"hide_me" %>' >Mill Name</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_MILL_DESIGN_NUMBER)? "vertical_header":"vertical_header hide_me" %>'>Mill Design Number</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FABRIC)? "":"hide_me" %>'>Fabric</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_PRINT_TYPE)? "":"hide_me" %>'>Print Type</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_TECHNIQUE_OF_PRINT)? "":"hide_me" %>'>TECHNIQUE OF PRINT</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_QTY_ORDERED)? "vertical_header":"vertical_header hide_me" %>'>QTY (MTRS.) ORDERED</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_QTY_RECEIVED)? "vertical_header":"vertical_header hide_me" %>'>QTY (MTRS.) RECEIVED</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_ORIGIN)? "vertical_header":"vertical_header hide_me" %>'>Origin</th><th scope="col" class="vertical_header">OLD/NEW</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_NO_OF_COLS_SCREENS)? "vertical_header":"vertical_header hide_me" %>'>NO. OF COLS/ SCREENS</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_COST_PER_SCREENS)? "":"hide_me" %>'>COST PER SCREEN</th><th scope="col">TOTAL AMOUNT</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_REMARKS)? "":"hide_me" %>'>Remarks</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_DATE_OF_RECEIVING)? "vertical_header":"vertical_header hide_me" %>'>DATE OF RECEIVING</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_EXPECTED_ISSUE_DATE)? "vertical_header":"vertical_header hide_me" %>'>EXPECTED ISSUE DATE</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_ACTUAL_ISSUE_DATE)? "vertical_header":"vertical_header hide_me" %>'>ACTUAL ISSUE DATE</th><th scope="col" class="vertical_header">STATUS ISSUING</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_EXPECTED_RECIEPT_DATE)? "vertical_header":"vertical_header hide_me" %>'>EXPECTED RECIEPT DATE</th><th scope="col" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_ACTUAL_RECIEPT_DATE)? "vertical_header":"vertical_header hide_me" %>'>ACTUAL RECIEPT DATE</th><th scope="col" class="vertical_header">STATUS RECEIVING</th>
		   </tr>
		
			{#foreach $T as record}
            
 <tr>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_PRINT_DESIGN_NUMBER_LAB_DIPS)? "":"hide_me" %>'>
            <input type="hidden" value="{$T.record.SamplingFabricID}" id="samplingFabricID{$P.x}" name="samplingFabricID{$P.x}" />
            
            PRD <input type="text" style="width: 80px;" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_PRINT_DESIGN_NUMBER_LAB_DIPS)? "fabric-printnumber":"fabric-printnumber do-not-allow-typing" %>' id="printNumber{$P.x}" name="printNumber{$P.x}" value="{$T.record.PrintNumber}"   />
            
            <img src="/App_Themes/ikandi/images/view_icon.png" border=0 onclick="showFabricHistory()" class="fabric-history {#if $T.record.PrintNumber == null } hide_me {#/if}"   />
        </td>
        <td>
          <span class="fabric-client vertical_text"> {$T.record.ClientName}</span>
        </td>
        <td>
          <span class="fabric-designer vertical_text">{$T.record.DesignerName}</span>
        </td>
        <td>
         <span class="fabric-samplemerchandiser vertical_text"> {$T.record.SamplingMerchandiserName}</span>
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_MILL_NAME)? "":"hide_me" %>'>
            <input type="text" style="width: 150px;"  class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_MILL_NAME)? "fabric-millname":"fabric-millname do-not-allow-typing" %>'  id="millName{$P.x}" name="millName{$P.x}" value="{$T.record.MillName}"   />
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_MILL_DESIGN_NUMBER)? "":"hide_me" %>'>
             <input type="text" style="width: 150px;" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_MILL_DESIGN_NUMBER)? "fabric-milldesignnumber vertical_text_input":"fabric-milldesignnumber vertical_text_input do-not-allow-typing " %>' id="millDesignNumber{$P.x}" name="millDesignNumber{$P.x}" value="{$T.record.MillDesignNumber}"   />
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FABRIC)? "":"hide_me" %>' >
           <input type="text" style="width: 150px;" id="Text1" name="fabric{$P.x}" value="{$T.record.Fabric}" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FABRIC)? "fabric-fabric":"fabric-fabric do-not-allow-typing " %>' />
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_PRINT_TYPE)? "":"hide_me" %>'>
            <select  id="printTypeID{$P.x}" name="printTypeID{$P.x}" <%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_PRINT_TYPE)? "":"disabled" %>>
                <option value="-1" {#if $T.record.PrintTypeID == '-1' } selected {#/if}>Select ...</option>
                <option value="1" {#if $T.record.PrintTypeID == '1' } selected {#/if}>PIGMENT</option>
                <option value="2" {#if $T.record.PrintTypeID == '2' } selected {#/if}>PRUSSIAN</option>
                <option value="3" {#if $T.record.PrintTypeID == '3' } selected {#/if}>DISCHARGE</option>
                <option value="4" {#if $T.record.PrintTypeID == '4' } selected {#/if}>ACID/OVER PRINT</option>
                <option value="5" {#if $T.record.PrintTypeID == '5' } selected {#/if}>OVERDYING</option>
            </select>
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_TECHNIQUE_OF_PRINT)? "":"hide_me" %>'>
            <select  id="printTechnologyID{$P.x}" name="printTechnologyID{$P.x}" <%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_TECHNIQUE_OF_PRINT)? "":"disabled" %>>
                <option value="-1" {#if $T.record.PrintTechnologyID == '-1' } selected {#/if} >Select ...</option>
                <option value="1" {#if $T.record.PrintTechnologyID == '1' } selected {#/if} >FLAT BED </option>
                <option value="2" {#if $T.record.PrintTechnologyID == '2' } selected {#/if} >ROTARY </option>
                <option value="3" {#if $T.record.PrintTechnologyID == '3' } selected {#/if} >TABLE </option>
            </select>
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_QTY_ORDERED)? "":" hide_me" %>'>
              <input type="text" style="width: 50px;" class='numeric-field-without-decimal-places numeric_text <%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_QTY_ORDERED)? "numeric_text":"numeric_text do-not-allow-typing" %>'  id="quantityOrdered{$P.x}" name="quantityOrdered{$P.x}" value="{$T.record.QuantityOrdered}"   />
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_QTY_RECEIVED)? "":" hide_me" %>'>
              <input type="text" style="width: 50px;" class='numeric-field-without-decimal-places  numeric_text <%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_QTY_RECEIVED)? "numeric_text":"numeric_text do-not-allow-typing" %>'  id="quantityReceived{$P.x}" name="quantityReceived{$P.x}" value="{$T.record.QuantityReceived}"   />
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_ORIGIN)? "":" hide_me" %>'>
            <select  id="originID{$P.x}" name="originID{$P.x}"  <%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_ORIGIN)? "":"disabled" %>>
                <option value="-1" {#if $T.record.OriginID == '-1' } selected {#/if}>Select ...</option>
                <option value="1" {#if $T.record.OriginID == '1' } selected {#/if}>INDIAN</option>
                <option value="2" {#if $T.record.OriginID == '2' } selected {#/if}>IMPORTED</option>
                <option value="3" {#if $T.record.OriginID == '3' } selected {#/if}>CHINA</option>
            </select>
        </td>
        <td>
        <span class="fabric-isnew vertical_text">{#if $T.record.IsNew == '1' } New  {#/if} {#if $T.record.IsNew == '0' } Old  {#/if} </span>
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_NO_OF_COLS_SCREENS)? "":" hide_me" %>'>
            <input type="text" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_NO_OF_COLS_SCREENS)?"numeric_text":"numeric_text do-not-allow-typing"%>'  style="width: 50px;" id="numberOfScreens{$P.x}" name="numberOfScreens{$P.x}" value="{$T.record.NumberOfScreens}"   />
        </td>
        <td class="remarks_text" class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_COST_PER_SCREENS)? "":"hide_me" %>'>
           
            <select  id="costCurrencyID{$P.x}" name="costCurrencyID{$P.x}" <%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_COST_PER_SCREENS)? "":"disabled" %>>
                <option value="-1" {#if $T.record.CostCurrencyID == '-1' } selected {#/if}>Select ...</option>
                <option value="1" {#if $T.record.CostCurrencyID == '1' } selected {#/if}>$</option>
                <option value="2" {#if $T.record.CostCurrencyID == '2' } selected {#/if}>£</option>
                <option value="3" {#if $T.record.CostCurrencyID == '3' } selected {#/if}>Rs</option>
            </select>
            <input type="text" class='numeric-field-with-two-decimal-places <%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_COST_PER_SCREENS)?"numeric_text":"numeric_text do-not-allow-typing"%>' style="width: 50px;" id="costPerScreen{$P.x}" name="costPerScreen{$P.x}" value="{$T.record.CostPerScreen}"   />
            
           
        </td>
        <td>
            <span id="totalAmount{$P.x}" class="numeric_text numeric-field-with-two-decimal-places">{$T.record.TotalAmount}</span>
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_REMARKS)? "":"hide_me" %>'>
            <input id="remarks{$P.x}" name="remarks{$P.x}" value="{$T.record.Remarks}" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_REMARKS)? "remarks_text":"remarks_text do-not-allow-typing" %>' />
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_DATE_OF_RECEIVING)? "":"hide_me" %>'>
           <input type="text"  style="width: 150px;"  class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_DATE_OF_RECEIVING)? "date-picker vertical_text_input date_style":" vertical_text_input date_style do-not-allow-typing" %>' id="dateOfReceiving{$P.x}" name="dateOfReceiving{$P.x}" value="{$T.record.DateOfReceiving}"/>
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_EXPECTED_ISSUE_DATE)? "":" hide_me" %>'>
           <input type="text" style="width: 150px;" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_EXPECTED_ISSUE_DATE)? "date-picker vertical_text_input date_style":" vertical_text_input date_style do-not-allow-typing" %>' id="expectedIssueDate{$P.x}" name="expectedIssueDate{$P.x}" value="{$T.record.ExpectedIssueDate}"  />        
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_ACTUAL_ISSUE_DATE)? "":" hide_me" %>'>
           <input type="text" style="width: 150px;" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_ACTUAL_ISSUE_DATE)? "date-picker vertical_text_input date_style":" vertical_text_input date_style do-not-allow-typing" %>' id="actualIssueDate{$P.x}"name="actualIssueDate{$P.x}" value="{$T.record.ActualIssueDate}"   />        
        </td>
        <td>
         <span class="fabric-statusissuing vertical_text"> {$T.record.StatusIssuing}</span>
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_EXPECTED_RECIEPT_DATE)? "":" hide_me" %>'>
            <input type="text" style="width: 150px;" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_FILE_EXPECTED_RECIEPT_DATE)? "date-picker vertical_text_input date_style":" vertical_text_input date_style do-not-allow-typing" %>' id="expectedReceiptDate{$P.x}" name="expectedReceiptDate{$P.x}" value="{$T.record.ExpectedReceiptDate}"   />        
        </td>
        <td class='<%=iKandi.Web.Components.PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_ACTUAL_RECIEPT_DATE )? "":"hide_me" %>'>
            <input type="text" style="width: 150px;" class='<%=iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_SAMPLING_ACTUAL_RECIEPT_DATE)? "date-picker vertical_text_input date_style":" vertical_text_input date_style do-not-allow-typing" %>' id="actualReceiptDate{$P.x}" name="actualReceiptDate{$P.x}" value="{$T.record.ActualReceiptDate}"    />        
        </td>
        <td>
          <span class="fabric-statusreceiving vertical_text"> {$T.record.StatusReceving}</span>
        </td>
    </tr>		
              {#param name=x value=$P.x+1}
			{#/for}
		</table>
	</textarea>
