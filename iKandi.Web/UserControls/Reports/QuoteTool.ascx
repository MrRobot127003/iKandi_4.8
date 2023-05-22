<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuoteTool.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.QuoteTool" %>
<style type="text/css">
    form_table.td, input
    {
        text-align: center !important;
    }
</style>

<script type="text/javascript">
$(function() 
{
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);    
    
    var txtStyleNumber = $('table.form_table input[type=text].style-number');
    txtStyleNumber.autocomplete('/Webservices/iKandiService.asmx/SuggestStylesWithCosting', { dataType: 'xml', datakey: 'string', max: 100 });
    
    $('table.form_table input[type=button].add').click(function()
    {
        if(txtStyleNumber.val() == '')
        {
            ShowHideValidationBox(true, 'Style Number is required.', 'Quote Tool Report');
            return false;            
        }
        
        var modeIdCollection = new Array();
        var chkListModes = $('table.form_table div.chk-list-modes input[type=checkbox].chk-mode:checked');
        
        if(chkListModes.length == 0)
        {
            ShowHideValidationBox(true, 'Atleast one mode must be selected.');
            return false;
        }
        
        chkListModes.each(function()
        {
            modeIdCollection.push($(this).val());
        });
        
        proxy.invoke('SaveQuoteToolInformation', { styleNumber:txtStyleNumber.val(), modeIdCollection:modeIdCollection },
        function(quoteToolData)
        {
            if(quoteToolData == null || quoteToolData == undefined || quoteToolData == '')
            {
                ShowHideValidationBox(true, 'Some error occured in adding Quote Tool information OR Costing is not done for '+txtStyleNumber.val()+ ' style. ', 'Quote Tool Report');
            }
            else
            {
                $('div.quote-tool').html('');
                $('div.quote-tool').html(quoteToolData);
                ShowHideMessageBox(true, 'Quote Tool information added successfully.', 'Quote Tool Report');
            }
        });
    });
    
    $('table.form_table input[type=button].clear').click(function()
    {
        proxy.invoke('DeleteQuoteToolInformation', { },
        function(success)
        {
            if(success)
            {
                $('div.quote-tool').html('');
                ShowHideMessageBox(true, 'Quote Tool information deleted successfully.', 'Quote Tool Report');
            }
            else
            {
                ShowHideValidationBox(true, 'Some error occured in deleting Quote Tool information.', 'Quote Tool Report');
            }
        });
    });
});
</script>

<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Quote Tool Report
        </div>
        <div>
            <table width="100%" class="form_table" bordercolor="#000000" border="1">
                <tr>
                    <td class="form_small_heading_pink" style="width: 10%">
                        Style Number:
                    </td>
                    <td style="text-align: center; color: Blue; width: 20%">
                        <input type="text" class="style-number" style="width: 100%" />
                    </td>
                    <td class="form_small_heading_pink" style="width: 10%">
                        Modes:
                    </td>
                    <td style="width: 25%">
                        <div class="chk-list-modes">
                            <input type="checkbox" value="1" class="chk-mode" />A/F&nbsp;
                            <input type="checkbox" value="2" class="chk-mode" />A/H&nbsp;
                            <input type="checkbox" value="3" class="chk-mode" />S/F&nbsp;
                            <input type="checkbox" value="4" class="chk-mode" />S/H&nbsp;
                            <input type="checkbox" value="5" class="chk-mode" />FOB
                        </div>
                    </td>
                    <td>
                        <input type="button" class="add" />
                        <input type="button" class="clear" />
                        <input type="button" class="print" onclick="return PrintPDF()" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divQuoteTool" runat="server" class="quote-tool">
        </div>
    </div>
</div>
