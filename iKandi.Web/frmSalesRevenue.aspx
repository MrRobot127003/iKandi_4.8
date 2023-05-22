<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSalesRevenue.aspx.cs" Inherits="iKandi.Web.Internal.Sales.frmSalesRevenue" %>

<%@ Register src="UserControls/Reports/rpt_IkandiAdminCommit_Sales.ascx" tagname="rpt_IkandiAdminCommit_Sales" tagprefix="uc1" %>
<%@ Register src="UserControls/Reports/RptIkandiCommit_DC.ascx" tagname="RptIkandiCommit_DC" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    h2 {
	font-size: 12px;
	font-weight: bold;
	padding: 5px;
	background: #39589C;
	color: #fff;
	width: 800px;
	text-align: center;
}
body {
	background: #fff none repeat scroll 0 0;
	font-family: verdana;
	padding-left:10px;
}
table {
	font-family: verdana;
	border-color: gray;
	border-collapse: collapse;
}
th {
	background: #dddfe4;
	font-weight: bold;
	color: #575759;
	font-family: arial, halvetica;
	font-size: 12px;
	padding: 0px 0px;
	border-color: #c6c0c0;
}
table td {
	font-size: 10px;
	text-align: center;
	border-color: #aaa;
	height:20px;
}
.green{color:green}
.HeaderClass td
{
    background: #dddfe4;
	font-weight: bold;
	color: #575759;
	font-family: arial, halvetica;
	font-size: 12px;
	padding: 0px 0px;
	border-color: #c6c0c0;
}
.oldYear
{
    background:#f3f3f3;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;margin-bottom:10px; margin-top:10px; width:100% ">BIPL / Ikandi Level </h2>
<br/>

<table class="revenue_img_table">
    <tr>
        <td> <img id="BIPLSalesChartReport_OnOrderDate" runat="server"></td>
        <td> <img id="BIPLSalesChartReport_OnExfactory" runat="server"></td>
    </tr>
    <tr>
        <td><img id="IkandiSalesChart_OnOrderDate" runat="server"></td>
       <td><img id="IkandiSalesChart_DC" runat="server"></td>
    </tr>
    <tr>
      <td><img id="Month_OrderWise_Img_Chart" runat="server"> </td>
      <td><img id="Month_Delivery_Img_Chart" runat="server"></td>
    </tr>
    <tr>
      <td><img id="Month_Delivery_Img_Chart_DC" runat="server"></td>
       <td></td>
    </tr>
</table>

<br/>
    <div id="Revenue_For_Barchart" runat="server"></div>
    <br />
    <div id="Revenue_For_Barchart_Month" runat="server"></div>
     <br />
    <div id="Revenue_For_Barchart_Month_Delivery" runat="server"></div>
    <br />

    <asp:GridView runat="server" ID="grdGetRevenueForBarchartDepartment" AutoGenerateColumns="false" ShowHeader="false" ShowFooter="false" OnDataBound="grdGetRevenueForBarchartDepartment_OnDataBound" onrowdatabound="grdGetRevenueForBarchartDepartment_RowdataBound">
         <Columns>         
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" style="color:black;font-weight:bold" ID="lblClient" Text='<%# Eval("Client") %>'></asp:Label>
                </ItemTemplate>             
             </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblDept" style="color:blue;font-weight:bold" Text='<%# Eval("Depertment") %>'></asp:Label>
                </ItemTemplate>             
             </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBIplSalesCurr" Text='<%# Eval("CurrentYearBIPLSalesValue_OrderDate") %>' CssClass="green"></asp:Label>
                </ItemTemplate>             
             </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiSalesCurr" Text='<%# Eval("CurrentYearIkandiSalesValue_DC") %>' CssClass="green"></asp:Label>
                </ItemTemplate>  
                           
             </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblUnitSalesCurr" Text='<%# Eval("CurrentYear_Unit_OrderDate") %>'></asp:Label>
                </ItemTemplate> 
             </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBiplDeliveryCurr" Text='<%# Eval("CurrentYearBIPLSalesValue_Delivery_OrderDate") %>' CssClass="green"></asp:Label>
                </ItemTemplate> 
             </asp:TemplateField>  
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryCurr" Text='<%# Eval("CurrentYearIkandiSalesValue_Delivery_DC") %>' CssClass="green"></asp:Label>
                </ItemTemplate> 
             </asp:TemplateField> 
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryUnitCurr" Text='<%# Eval("CurrentYearUnit_ExFactory") %>'></asp:Label>
                </ItemTemplate> 
             </asp:TemplateField> 
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryDcCurr" Text='<%# Eval("CurrentYearUnit_DC") %>'></asp:Label>
                </ItemTemplate> 
             </asp:TemplateField> 

              <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBIplSalesPrev" Text='<%# Eval("PreviousBIPLSalesValue_OrderDate") %>' CssClass="green"></asp:Label>
                </ItemTemplate>   
                <ItemStyle CssClass="oldYear" />          
             </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiSalesPrev" Text='<%# Eval("PreviousIkandiSalesValue_DC") %>' CssClass="green"></asp:Label>
                </ItemTemplate>  
                           <ItemStyle CssClass="oldYear" />
             </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblUnitSalesPrev" Text='<%# Eval("Previous_Unit_OrderDate") %>'></asp:Label>
                </ItemTemplate> 
                <ItemStyle CssClass="oldYear" />
             </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBiplDeliveryPrev" Text='<%# Eval("PreviousBIPLSalesValue_Delivery_OrderDate") %>' CssClass="green"></asp:Label>
                </ItemTemplate> 
                <ItemStyle CssClass="oldYear" />
             </asp:TemplateField>  
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryPrev" Text='<%# Eval("PreviousIkandiSalesValue_Delivery_DC") %>' CssClass="green"></asp:Label>
                </ItemTemplate> 
                <ItemStyle CssClass="oldYear" />
             </asp:TemplateField> 
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryUnitPrev" Text='<%# Eval("PreviousUnit_ExFactory") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="oldYear" /> 
             </asp:TemplateField> 
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryDcPrev" Text='<%# Eval("PreviousUnit_DC") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="oldYear" /> 
             </asp:TemplateField> 


             <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBIplSalesPrevPrev" Text='<%# Eval("PreviousToPreviousBIPLSalesValue_OrderDate") %>' CssClass="green"></asp:Label>
                </ItemTemplate>  
                <ItemStyle CssClass="oldYear" />           
             </asp:TemplateField>--%>
              <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiSalesPrevPrev" Text='<%# Eval("PreviousToPreviousIkandiSalesValue_DC") %>' CssClass="green"></asp:Label>
                </ItemTemplate>  
                           <ItemStyle CssClass="oldYear" />
             </asp:TemplateField>--%>
            <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblUnitSalesPrevPrev" Text='<%# Eval("PreviousToPrevious_Unit_OrderDate") %>'></asp:Label>
                </ItemTemplate> 
                <ItemStyle CssClass="oldYear" />
             </asp:TemplateField>--%>
            <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblBiplDeliveryPrevPrev" Text='<%# Eval("PreviousToPreviousBIPLSalesValue_Delivery_OrderDate") %>' CssClass="green"></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="oldYear" /> 
             </asp:TemplateField>  --%>
             <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryPrevPrev" Text='<%# Eval("PreviousToPreviousIkandiSalesValue_Delivery_DC") %>' CssClass="green"></asp:Label>
                </ItemTemplate> 
                <ItemStyle CssClass="oldYear" />
             </asp:TemplateField> --%>
            <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryUnitPrevPrev" Text='<%# Eval("PreviousToPreviousUnit_ExFactory") %>'></asp:Label>
                </ItemTemplate> 
                <ItemStyle CssClass="oldYear" />
             </asp:TemplateField> --%>
            <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIkandiDeliveryDcPrevPrev" Text='<%# Eval("PreviousToPreviousUnit_DC") %>'></asp:Label>
                </ItemTemplate> 
                <ItemStyle CssClass="oldYear" />
             </asp:TemplateField> --%>
         </Columns> 
    </asp:GridView>
    <br />
<%--     <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;margin-bottom:10px; margin-top:10px; width:1293px ">Ikandi Sales Report</h2>
--%>    <uc1:rpt_IkandiAdminCommit_Sales ID="rpt_IkandiAdminCommit_Sales1" 
        runat="server" />
         <br />
<%--     <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;margin-bottom:10px; margin-top:10px; width:1293px ">Ikandi DC Target Report</h2>
--%>    <uc2:RptIkandiCommit_DC ID="RptIkandiCommit_DC1" 
        runat="server" />
   
    </form>
</body>
</html>
