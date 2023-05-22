<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSalesOHRevenue.aspx.cs"
    Inherits="iKandi.Web.frmSalesOHRevenue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        .AddClass_Table
        {
            border: 1px solid #999;
            border-collapse: collapse;
            font-family: Arial, Helvetica, sans-serif;
            width: 470px;
            margin-left: 20px;
        }
        
        .AddClass_Table td
        {
            border: 1px solid #dbd8d8;
            font-size: 11px;
            padding: 3px 3px;
            color: #0c0c0c;
            height: 12px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            height: 17px;
        }
        .txtCenter
        {
            text-align: center !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-bottom: 25px; margin-top: 20px; margin-left: 20px; line-height: 20px;">
        <%--    <span style="font-size: 12px; font-weight: 500; margin: 5px 0px 0px;">Hi All,</span><br />
     <span style="padding-left:15px;"> Please find Financial Figure of sales.</span> --%>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="up_OHRevenue" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" style="margin: 0 auto;">
                <tbody>
                    <tr>
                      <%--  <td style="vertical-align: top;">
                            <asp:GridView ID="grdSalesOHRevenue" runat="server" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                                ShowHeader="false" CssClass="AddClass_Table" ShowFooter="true" OnRowCreated="grdSalesOHRevenue_RowCreated"
                                OnRowDataBound="grdSalesOHRevenue_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonth" Text='<%#Eval("Month_Name") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalMonth" runat="server" Text="Total"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="60px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="60px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            
                                            <asp:Label ID="lblExFactRevCurrent" Text='<%#Eval("Exfactory_Revenue_Current") %>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalExFactRevCurrent" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="105px" BackColor="#cffaf9" />
                                        <ItemStyle Width="105px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                          
                                            <asp:Label ID="lblMatRevCurrent" ForeColor="green" Text='<%#Eval("MaterialCost_Revenue_Current") %>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalMatRevCurrent" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="105px" BackColor="#cffaf9" />
                                        <ItemStyle Width="105px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMatPerFob" runat="server" ForeColor="Blue" Text='<%#Eval("MatirialPercOnFOB") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalMatPerFob" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" BackColor="#cffaf9" />
                                        <ItemStyle CssClass='txtCenter' />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                          
                                            <asp:Label ID="lblCMTCostRevCurrent" ForeColor="green" Text='<%#Eval("CMTCost_Revenue_Current") %>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalCMTCostRevCurrent" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="105px" BackColor="#cffaf9" />
                                        <ItemStyle Width="105px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCMTPerFob" runat="server" ForeColor="Blue" Text='<%#Eval("CMTPercOnFOB") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalCMTPerFob" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" BackColor="#cffaf9" />
                                        <ItemStyle CssClass='txtCenter' />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                          
                                            <asp:Label ID="lblOverHeadRevCurrent" ForeColor="green" Text='<%#Eval("OverHead_Revenue_Current") %>'
                                                runat="server"></asp:Label>
                                        
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalOverHeadRevCurrent" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" BackColor="#cffaf9" />
                                        <ItemStyle Width="105px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOverHeadPerFob" ForeColor="Blue" runat="server" Text='<%#Eval("OHPercOnFOB") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalOverHeadPerFob" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" BackColor="#cffaf9" />
                                        <ItemStyle CssClass='txtCenter' />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <label style="color: Red">
                                        NO RECORD FOUND</label></EmptyDataTemplate>
                            </asp:GridView>
                        </td>--%>

                        <td>
                            <%--added by raghvinder on 05-10-2020 start--%>
                            <asp:GridView ID="grdCMT" runat="server" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                                ShowHeader="false" Width="900px" CssClass="AddClass_Table" ShowFooter="true"
                                OnRowCreated="grdCMT_RowCreated" OnRowDataBound="grdCMT_RowDataBound">
                                <Columns>
                                <%--1 Ex Month--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonth" Text='<%#Eval("Month_Name") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalMonth" runat="server" Text="Total"></asp:Label></b>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="txtCenter" Width="60px" />
                                        <FooterStyle CssClass="txtCenter" Width="60px" BackColor="#cffaf9" />
                                    </asp:TemplateField>
                                    <%--2 Stitch Quantity --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStichedQty" Text='<%#Eval("StitchQty") %>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnStitchedQty" runat="server" Value='<%# Eval("StitchQty_WithoutRound") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalStichedQty" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="60px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="60px" />
                                    </asp:TemplateField>
                                    <%--3 Stitch FOB --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStichedfob" Text='<%# Math.Round(Convert.ToDecimal(Eval("StitchedFOB "))/10000000,1) %>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnStichedfob" runat="server" Value='<%# Eval("StitchedFOB") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalStichedfob" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="60px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="60px" />
                                    </asp:TemplateField>
                                    <%--4 Stitch Per pcs FOB --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostedCMT" ForeColor="black" Text='<%#Eval("PerPcsFOBStitch") %>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnCostedCMT" runat="server" Value='<%# Eval("PerPcsFOBStitch") %>' />
                                            <%--<asp:Label ID="lblMatCost" ForeColor="green"  Text="" runat="server"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalCostedCMT" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="70px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="70px" />
                                    </asp:TemplateField>
                                    <%--5 Material Costed --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialCostedCMT" ForeColor="black" Text='<%#Eval("MaterialCost_Revenue_Current") %>' runat="server"></asp:Label>
                                             <asp:HiddenField ID="hdnMaterialCostedCMT" runat="server" Value='<%# Eval("MaterialCost_Revenue_Current") %>' />
                                            <%--<asp:Label ID="lblMatInhouse" ForeColor="green"  Text="" runat="server"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblMaterialCostedCMTTotal" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="65px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialActualCMT" ForeColor="black" Text='<%#Eval("ActualMaterialCost") %>' runat="server"></asp:Label>
                                             <asp:HiddenField ID="hdnMaterialActualCMT" runat="server" Value='<%# Eval("ActualMaterialCost") %>' />
                                            <%--<asp:Label ID="lblMatInhouse" ForeColor="green"  Text="" runat="server"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblMaterialActualCMTTotal" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="65px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="65px" />
                                    </asp:TemplateField>
                                    <%--6 Material Actual --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialDifferenceCMT" Text='<%# Eval("Material_Profit_CMT") %>' ForeColor="black" runat="server"></asp:Label>
                                               <asp:HiddenField ID="hdnMaterialDifferenceCMT" runat="server" Value='<%# Eval("Material_Profit_CMT") %>' />
                                            <%--<asp:Label ID="lblMatInhouse" ForeColor="green"  Text="" runat="server"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblMaterialDifferenceCMTTotal" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="110px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="110px" />
                                    </asp:TemplateField>
                                    <%--new column added start--%>
                                    <%--CMT -- %>
                                    <%--6 Costed --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNewCostedCMT" Text='<%#Eval("CMTCost_Revenue_Current") %>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnNewCostedCMT" runat="server" Value='<%# Eval("CMTCost_Revenue_Current") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblNewCostedCMTTotal" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="75px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="75px" />
                                    </asp:TemplateField>
                                    <%--8 CMT Costed --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNewActualCMT" Text='<%# Eval("Finance_CMT") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblNewActualCMTTotal" runat="server"></asp:Label>
                                            </b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="70px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="70px" />
                                    </asp:TemplateField>
                                  <%--9 CMT Actual --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNewProfitCMT" Text='<%# Eval("Profit_CMT") %>' runat="server"></asp:Label>
                                             <asp:HiddenField ID="hdnNewProfitCMT" runat="server" Value='<%# Eval("Profit_CMT") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblNewProfitCMTTotal" runat="server"></asp:Label>
                                            </b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="70px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="70px" />
                                    </asp:TemplateField>



                                    <%--10 CMT Profit --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPPCostedCMT" Text='<%# Eval("Costed_PerPcs") %>' runat="server"></asp:Label>
                                             <asp:HiddenField ID="hdnPPCostedCMT" runat="server" Value='<%# Eval("Costed_PerPcs") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblPPCostedCMTTotal" runat="server"></asp:Label>
                                            </b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="70px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="70px" />
                                    </asp:TemplateField>
                                    <%--11 Per pcs CMT Costed --%>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPPActualCMT" Text='<%# Eval("Actual_PerPcs") %>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnPPActualCMT" runat="server" Value='<%# Eval("Actual_PerPcs") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblPPActualCMTTotal" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="75px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="75px" />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField>--%>
                                    <%--12 Per pcs CMT Actual --%>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPPProfitCMT" Text='<%# Eval("Profit_PerPcs") %>' runat="server"></asp:Label>
                                             <asp:HiddenField ID="hdnPPProfitCMT" runat="server" Value='<%# Eval("Profit_PerPcs") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblPPProfitCMTTotal" runat="server"></asp:Label>
                                            </b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="70px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="70px" />
                                    </asp:TemplateField>
                                    <%--13 Per pcs CMT Profit --%>                                    
                                    <%--14 Monthaly wt SAM --%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonthlyWeightedSAM" Text='<%# Math.Round(Convert.ToDecimal(Eval("MonthlyWeightedSAM")),0) %>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnTotalOrderQty" runat="server" Value='<%#Eval("TotalOrderQty") %>' />
                                            <asp:HiddenField ID="hdnSAMMultipliedByOrderQty" runat="server" Value='<%#Eval("SAMMultipliedByOrderQty") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalWeightedSAM" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="70px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="70px" />
                                    </asp:TemplateField>
                                    <%--new column added end--%>
                                </Columns>
                                <EmptyDataTemplate>
                                    <label style="color: Red">
                                        NO RECORD FOUND</label></EmptyDataTemplate>
                            </asp:GridView>
                        </td>

                        <td style="vertical-align: top;">
                            <%--added by raghvinder on 05-10-2020 start--%>
                            <asp:GridView ID="grdSales" runat="server" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
                                ShowHeader="false" Width="300px" CssClass="AddClass_Table" ShowFooter="true"
                                OnRowCreated="grdSales_RowCreated" OnRowDataBound="grdSales_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonth" Text='<%#Eval("Month_Name") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalMonth" runat="server" Text="Total"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="60px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="60px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMatCost" ForeColor="black" Text='<%#Eval("MaterialCost_Revenue_Current") %>'
                                                runat="server"></asp:Label>
                                            <%--<asp:Label ID="lblMatCost" ForeColor="green"  Text="" runat="server"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalMatCost" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="80px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMatInhouse" ForeColor="black" Text='<%#Eval("MaterialCostInHouse_Revenue_Current") %>'
                                                runat="server"></asp:Label>
                                            <%--<asp:Label ID="lblMatInhouse" ForeColor="green"  Text="" runat="server"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalMatInhouse" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="80px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="80px" />
                                    </asp:TemplateField>
                                    <%--     <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:Label ID="lblInhouse" ForeColor="black" Text='<%#Eval("MonthlyWeightedSAM") %>' runat="server"></asp:Label>
                            <asp:Label ID="lblInhouse" ForeColor="green"  Text="" runat="server"></asp:Label>
                        </ItemTemplate>

                    <asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblInhouse" ForeColor="black" Text='<%#Eval("InHousePercent") %>'
                                                runat="server"></asp:Label>
                                            <%--<asp:Label ID="lblInhouse" ForeColor="green"  Text="" runat="server"></asp:Label>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>
                                                <asp:Label ID="lblTotalInhouse" runat="server"></asp:Label></b>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="txtCenter" Width="90px" BackColor="#cffaf9" />
                                        <ItemStyle CssClass="txtCenter" Width="90px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <label style="color: Red">
                                        NO RECORD FOUND</label></EmptyDataTemplate>
                            </asp:GridView>
                        </td>

                        
                    </tr>
                </tbody>
            </table>
            <%--added by raghvinder on 05-10-2020 end--%>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <table cellpadding="0" cellspacing="0" style="margin: 0 auto;">
        <tbody>
            <tr>
                <td>
                    <img id="Img3" runat="server" src="http://boutique.in:81/pic/BIPLEXFACTCOST.png"
                        width="640" style="max-width: 640px; display: block;" />
                </td>
                <td>
                    <img id="Img4" runat="server" src="http://boutique.in:81/pic/BIPCHARTMATERIALCOST.png"
                        width="640" style="max-width: 640px; display: block;" />
                </td>
            </tr>
            <tr>
                <td>
                    <img id="Img2" runat="server" src="http://boutique.in:81/pic/BIPLCMTCOST.png" width="640"
                        style="max-width: 640px; display: block;" />
                </td>
                <td>
                    <img id="Img1" runat="server" src="http://boutique.in:81/pic/BIPLCHARTOHPROFITCOST.png"
                        width="640" style="max-width: 640px; display: block;" />
                </td>
            </tr>
            <tr>
                <td>
                    <img id="Img5" runat="server" src="http://boutique.in:81/pic/ActualPerPcpng.png"
                        width="640" style="max-width: 640px; display: block;" />
                </td>
                <td>
                    &nbsp
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <br />
    <div style="width: 65%; margin: 0 auto;font-size: 12px;">
        <strong>Thanks & Best Regards </strong>
        <br />
        BIPL Admin
    </div>
    <div style='width: 65%; margin: 10px auto;'>
        <img src='http://boutique.in/images/certificate.jpg' />
    </div>
</body>
</html>
