<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanningMatrix.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.ProductionPlanningMatrix" %>
<style type="text/css">
    body
    {
        font-family:Verdana;
        font-size:10px;
    }
.item_list_matrix th
{
    height:20px;
    background:#cacfd2;
    color:#666 !important;
    text-align:center;
    text-transform:capitalize !important;  
}
.item_list_matrix td span
{
    vertical-align:middle;
    width:90%;  
    font-size:11px;  
}

.item_list_matrix td
{
    text-align:center;
}
.item_listLine th
{ 
    height:15px;
    padding:2px;
    background:#428bca;
    color:#fff;
   
}
.item_listLine td 
{
    text-align:center;
}
.item_listLine td span
{
    vertical-align:middle;
    width:90%;
    text-align:center;
}

.border2 th
{
   text-align: center;
   font-size:10px;
	font-family: arial, halvetica;
	color:#666;
	font-weight:normal;
	padding:0px;
	background:#cacfd2;
}
.Accstyle input
{
    width:40px;
    vertical-align:middle;
    text-align:center;        
}
.Accstyle
{
    height:20px;    
    vertical-align:middle;    
    width:55px; 
         
}
.Accstyle-new
{
     height:20px;    
    vertical-align:middle;    
    width:55px; 
         
}

.Fabtyle
{
    height:20px; 
    vertical-align:middle;       
    width:55px;         
}
.Fabtyle input
{
    width:40px;
    vertical-align:middle;
    text-align:center;        
}
.hiddencol
{
    display:none;
}
.border2 th 
{
    height:56px !important;
}
.borderbottom td
{
    height:28px;
}
.ItemBackGreen
{
    background-color:Green !important;
    color:White !important; 
    
}
.ItemBackRed 
{
    background-color:Red !important;
    color:White; 
    
}

.TotalBackStitch
{
    background-color:Yellow !important;    
     display:block;
     height:20px;     
}
.blue
{
    color:Blue;
}
.rowcolor
{
    background-color:#da9694 !important;color:White;
}
.rowcolor input
{
     background-color:#da9694 !important;color:White;
}
.rowcolor .TotalBackStitch
{
    background-color:#da9694 !important;color:White;
}
.rowcolor .days-back
{
    background-color:#da9694 !important;
    color:black;
}
.days-back
{    
    color:#98a9ca;
}
.rowcolor span
{
 color:White !important;
}
body
{
    margin: 0;
    padding: 0;
    font-family: Arial;
}
.modal
{
    position: fixed;
    z-index: 999;
    height: 100%;
    width: 100%;
    top: 0;
    background-color: Black;
    filter: alpha(opacity=60);
    opacity: 0.6;
    -moz-opacity: 0.8;
}
.center
{
    z-index: 1000;
    margin: 300px auto;
    padding: 10px;
    width: 130px;  
    filter: alpha(opacity=100);
    opacity: 1;
    -moz-opacity: 1;
}
.ItemBackStitch 
{
    background-color:#81DAF5;
}
.rotate{
    display: block; 
    -moz-transform: rotate(-45deg);   /*Safari*/  
    -webkit-transform: rotate(-45deg); /*Opera*/    
    -o-transform: rotate(-45deg);-ms-transform: rotate(-45deg); /* ie*/    
    filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
	padding:0px;
	border:0px;
}

.hide-button td:nth-child(2)
{
    display:none;
}
.hide-button td:nth-child(3)
{
    display:none;
}
</style>

  <div style="width:97%; margin:0px auto;">
                <div>&nbsp;</div>
                <table class="item_list_matrix" style="width:90%; border: 1px solid #ddd;">
                    <tr>
                        <th width="7.5%">
                            Total Wrk Hrs</th>
                        <td width="7.5%">
                            <asp:Label ID="lblWorkingHrs" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            Line Qty</th>
                        <td width="7.5%">
                            <asp:Label ID="lblLineQty" CssClass="number-with-commas" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            Act. Stitched</th>
                        <td width="7.5%">
                            <asp:Label ID="lblActualStitched" CssClass="number-with-commas" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            SAM</th>
                        <td width="7.5%">
                            <asp:Label ID="lblSAM" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="6%">
                            OB</th>
                        <td width="7.5%">
                            <asp:Label ID="lblOB" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="7.5%">
                            Avail Mins</th>
                        <td width="7.5%">
                            <asp:Label ID="lblAvailMins" runat="server" Text=""></asp:Label>
                        </td>
                        <th width="6%">
                            Line No</th>
                        <td width="7.5%">
                            <asp:Label ID="lblLines" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnExFactory" runat="server" Value="" />
                        </td>
                    </tr>
                </table>

    <table cellpadding="0" cellspacing="0" style="width:auto;">
    <tr>
    <td>
                <asp:GridView ID="grdProductionMatrix" runat="server" 
                    AutoGenerateColumns="false" cellpadding="0" CssClass="border2" 
                    DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true" 
                    EmptyDataRowStyle-ForeColor="Red" 
                    EmptyDataText="There is no Line Plan for this contract." 
                    onrowdatabound="grdProductionMatrix_RowDataBound" RowStyle-Font-Size="10px" 
                    ShowFooter="false" style="width:525px;" Width="100%">
                    <RowStyle CssClass="borderbottom" />
                    <Columns>
                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="55px" 
                            HeaderText="Serial no." ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>                                           
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="115px" 
                            HeaderText="Contract no." ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber")%>'></asp:Label>                                           
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="125px" 
                            HeaderText="Color/Print" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:Label ID="lblColor" runat="server" Text='<%# Eval("FabricDetails")%>'></asp:Label>                                           
                            </ItemTemplate>
                       </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="75px" 
                            HeaderText="Cal. Date" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="80px">
                            <ItemTemplate>
                            <div style="text-align: left; padding-left:10px;" >
                                <asp:Label ID="lblLinePlanningDate" runat="server" BorderColor="White" CssClass="do-not-allow-typing" 
                                    Text='<%# Eval("LinePlanningDate", "{0:dd MMM (ddd)}")%>' Width="95%"></asp:Label>
                                    </div>
                                <asp:HiddenField ID="hdnOrderDetailId" Value='<%# Eval("OrderDetailId")%>' runat="server" />
                                <asp:HiddenField ID="hdnStartSlot" Value='<%# Eval("StartSlot")%>' runat="server" />
                                <asp:HiddenField ID="hdnEndSlot" Value='<%# Eval("EndSlot")%>' runat="server" />
                                <asp:HiddenField ID="hdnEfficiency" Value='<%# Eval("Efficiency")%>' runat="server" />
                                <asp:HiddenField ID="hdnStitching" Value='<%# Eval("Stitching")%>' runat="server" />
                            </ItemTemplate>
                                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="45px" 
                            HeaderText="Act. Cal. Wrk. Hrs" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:Label ID="lblWorkingHrs" runat="server" Text='<%# Eval("WorkingHrs")%>'></asp:Label>
                                           
                            </ItemTemplate>
                            </asp:TemplateField>
                                            
                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="40px" 
                            HeaderText="Day Stitch" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblDayStitch" CssClass="number-with-commas" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                            HeaderText="Total Stitch" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalDayStitch" runat="server" CssClass="number-with-commas"
                                    Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
    </td>
      <td align="left" valign="top">
                            <asp:GridView ID="grdFabricAccess" runat="server" AutoGenerateColumns="false" 
                                cellpadding="0" CssClass="border2" DataFormatString="{0:#,##}" 
                                 EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="" 
                                 RowStyle-Font-Size="10px" 
                                ShowFooter="false" style="max-width:1800px;" 
                                ondatabound="grdFabricAccess_DataBound" 
                                onrowdatabound="grdFabricAccess_RowDataBound">
                                <RowStyle CssClass="borderbottom" />
                                
                                <Columns>
                                </Columns>
                            </asp:GridView>
                        </td>
    </tr>
    </table>
    <div>&nbsp;</div>

    </div>