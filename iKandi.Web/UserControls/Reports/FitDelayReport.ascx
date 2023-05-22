<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FitDelayReport.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.FitDelayReport" %>
<script type="text/javascript">
    function popWin(stringIds) {
   
       var params = 'width=' + screen.width;
        params += ', height=' + screen.height-40;
        params += ', top=0, left=0';
        params += ', toolbar=yes,menubar=yes,scrollbar=1';
        params += ', directories=yes';
        params += ', location=yes';
        params += ', resizable=yes';
        params += ', scrollbars=yes';
        params += ', status=yes';
        params += ', toolbar=yes';
    
        if (stringIds == 'a')
            window.open("/internal/orderprocessing/manageorders.aspx?winopn=a", "", params);        
        else
            window.open("/internal/orderprocessing/manageorders.aspx?winopn=z", "", params);
        return true;
    
    }

</script>
<style type="text/css">
    .grid_border
    {     
    border: 0px solid white;    
    text-align: center;
    font-family: Trebuchet MS,Tahoma,Verdana,Arial,sans-serif;
    font-size: 12px;
    }
    .cell_border
    {       
     
    border: 1px solid black;    
    text-align: center;
    vertical-align:top;
    width:50%;
    font-family: Trebuchet MS,Tahoma,Verdana,Arial,sans-serif;
    font-size: 12px;
    } 
    
    .tableborder
    {
    border:solid 1px #000;
    border-collapse:collapse;

    }
    .border_right
    {
    border-right:solid 1px #000;
    }
    
.item_list11
{
    width: 100%;
    border-collapse: collapse;
    margin-right: 0px;
    text-transform: uppercase;
    border: 0px solid black;
    font:normal 12px/14px Trebuchet MS,Tahoma,Verdana,Arial,sans-serif;
}

.item_list11 TD
{
    padding: 5px !important;
    background-color: White;
    text-align: center;
     font:normal 14px/16px Trebuchet MS,Tahoma,Verdana,Arial,sans-serif;
}

.item_list11 TH
{   
    background-color:#F9DDF4;
    border-bottom:1px solid black;
    border-top:1px solid black;  
    font:normal 12px/14px Trebuchet MS,Tahoma,Verdana,Arial,sans-serif;   
}

.item_list11 TD input[type=text], .item_list11 TD textarea
{
    color: #0000ff;
    border: 0;
    width: 100%;
    text-align: center;
    vertical-align: middle;
    
}

.item_list11 TD select
{
    width: 100%;
    color: #0000ff;
}
.inner_cell
{
    background-color:#F9DDF4;
    text-align:center;
    }    
    
</style>

<table width="100%" >
<tr>
<td class="cell_border">
<div class="inner_cell"> Fits Pending </div>
<asp:GridView ID="gvDelay" runat="server"        
        CssClass="item_list11"
        AutoGenerateColumns="true"
        onrowdatabound="gvDelay_RowDataBound">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <div style="padding:10px;">No records Found</div>
        </EmptyDataTemplate>
        </asp:GridView>
</td>
<td class="cell_border">
<div class="inner_cell">TOP's Pending At Factory </div>
<asp:GridView ID="gvfactorypending" runat="server"      
     AutoGenerateColumns="true"
     CssClass="item_list11"
     onrowdatabound="gvfactorypending_RowDataBound" EmptyDataRowStyle-BorderStyle="Solid">
     <Columns>     
        </Columns> 
        <EmptyDataTemplate>       
            <div style="padding:10px;">No records Found</div>
        </EmptyDataTemplate>
     </asp:GridView>
</td>
</tr>

</table>
