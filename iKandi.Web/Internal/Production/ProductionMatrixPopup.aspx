<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionMatrixPopup.aspx.cs" Inherits="iKandi.Web.Internal.Production.ProductionMatrixPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    body
    {
        font-family:Verdana;
        font-size:12px;
    }
.item_list th
{
    height:20px;
}
.item_list td span
{
    vertical-align:middle;
    width:90%;
}

.border2 th
{
   text-align: center;
   font-size:11px;
	font-family: arial, halvetica;
	color:#98a9ca;
	font-weight:normal;
	padding:0px;
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
    width:51px;         
}
.Fabtyle
{
    height:20px; 
    vertical-align:middle;       
    width:78px;         
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
    height:20px;
}
.ItemBackGreen
{
    background-color:Green !important;
    color:White !important;
     display:block;
  padding:3PX 0px;
}
.ItemBackRed 
{
    background-color:Red !important;
    color:White;
    display:block;
    padding:3PX 0px;
    
}

.TotalBackStitch
{
    background-color:Yellow !important;    
     display:block;
    padding:3PX 0px;     
}
.blue
{
    color:Blue;
}
.rowcolor
{
    background-color:#da9694 !important;
}
.rowcolor input
{
     background-color:#da9694 !important;
}
.rowcolor .TotalBackStitch
{
    background-color:#da9694 !important;
}
.rowcolor .days-back
{
    background-color:#da9694 !important;
    color:black;
}
.days-back
{
    background:#3a5795; 
    color:#98a9ca;
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
</style>
</head>
<body>

 <script type="text/javascript" src="../../js/service.min.js"></script>
 <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>  
 <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-1.4.4.min.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/facebox.js")%>'></script> 
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/js.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ImageFaceBox.js")%>'></script>   
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/colorpicker.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../../js/fna.js")%>' type="text/javascript"></script>
   <script type="text/javascript" src='<%= Page.ResolveUrl("../../js/date.js")%>'></script>

     <script type="text/javascript">
         $(document).ready(function () {
             $(".ItemBackStitch").parent().css({ "background-color": "#81DAF5" });
         });


         var serviceUrl = '<%= ResolveUrl("../../Webservices/iKandiService.asmx/") %>';
         var proxy = new ServiceProxy(serviceUrl);

        
</script>
    <form id="form1" runat="server">
    <div>
    <table><tr><td>
    <asp:GridView ID="grdProductionMatrix" runat="server" 
                                AutoGenerateColumns="false" cellpadding="0" CssClass="border2" 
                                DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true" 
                                EmptyDataRowStyle-ForeColor="Red" 
                                EmptyDataText="There is no history for this contract." 
                                 RowStyle-Font-Size="12px" 
                                ShowFooter="false" style="width:455px;" Width="100%" 
                                onrowdatabound="grdProductionMatrix_RowDataBound">
                                <RowStyle CssClass="borderbottom" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="100px" 
                                        HeaderText="Cal. Date" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtLinePlanningDate" runat="server" BorderColor="White" 
                                                CssClass="do-not-allow-typing" Style="text-align: center; border:0px;" 
                                                Text='<%# Eval("LinePlanningDate", "{0:dd-MM-yyyy}")%>' Width="95%"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle ForeColor="#aba5a5" />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Act. Cal. Wrk. Hrs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Eval("DayWorkingHrs")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Add Hrs to Adjst" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtHrsAdd" runat="server" 
                                                CssClass="numeric-field-with-decimal-places" onchange="SaveExtraHours(this)" 
                                                style="text-align:center;" Text='<%# Eval("ExtraHours")%>' Width="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Days" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            Day <%# Eval("ProdDay")%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="days-back" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Target Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTargetEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("TargetEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Actual Eff." ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActualEff" runat="server" CssClass="blue" 
                                                Text='<%# Eval("ActualEff")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" 
                                        HeaderText="Day Stitch / Packed" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDayStitch" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="70px" 
                                        HeaderText="Total Stitch / Packed" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" 
                                        ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalDayStitch" runat="server" 
                                                Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
    </td></tr></table>
    </div>
    </form>
</body>
</html>
