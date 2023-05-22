<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyMMR_Summery.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.DailyMMR_Summery" %>

<style type="text/css">
.op-type
{
    font-family: arial;
font-size: 12px !important;
font-weight: bold;
color: #3B5998;
padding-left:2px;
text-transform:uppercase;
}
.rotate{
  color: #000;
    display: block;
    /*Firefox*/
    -moz-transform: rotate(-90deg);
    /*Safari*/
    -webkit-transform: rotate(-90deg);
    /*Opera*/
    -o-transform: rotate(-90deg);-ms-transform: rotate(-90deg);
    /* ie*/
    filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
	color:#405d9a;
	font-weight:bold;
	font-size:15px;
	font-family:arial;
	padding:0px;
}
.back-blue
{
    background:#405d99;    
}
.bot-header
{
    background:#405D99;
    color:#fff;font-size:10px;    
}
.top-header
{
    color:#405D99;
    background:#f6f7f9;
}
.differe-mmr
{
   
    height:30;
}
.differe-mmr span
{
 line-height: 32px;
 font-size:12px;
}
.differe-act
{
    width:100%;
    height:31.98px;
   
}
.differe-act span
{
  line-height: 30px;
 font-size:12px   
}
.disp_non
{
    display:none;
}
   .floatingHeader {
      position: fixed;
      top: -1px;
      visibility: hidden;
    }
</style>

  <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<div>

       <h2  style="background-color:#405D99; color:#FFFFFF; height:30px; font-size:large; width:1500; text-align:center;">Production Budget Vs Actual  </h2>
    
<%--MMR Budget Report --%>
    <table width="1500" border="0" cellpadding="0" class="persist-area">
        <thead>
        
        <tr class="persist-header">
       <th>
       
           <asp:GridView ID="gvFactoryBudgetSummary" runat="server" 
                AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader"
            RowStyle-CssClass="RangeStyle" Width="100%" ShowHeader="false"
                onrowdatabound="gvFactoryBudgetSummary_RowDataBound">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="115" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblHeader" runat="server" Font-Size="12px" Text=''></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="30" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="12px" Text='<%#Eval("Column2") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="30" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="12px" Text='<%#Eval("Column3") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="30" />
              </asp:TemplateField> 
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="12px" Text='<%#Eval("Column4") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="30" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="12px" Text='<%#Eval("Column5") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="30" />
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
       </th>
        </tr>
        </thead>
        <tbody>        
     
      <tr>
        <td>      
              <table border="0" cellpadding="0" cellspacing="0" width="1500" bgcolor="#ffffff" align="left" style="table-layout:fixed; border:1px solid #666; border-collapse:collapse; border-spacing:0; padding:0px; margin:0px;">
                <tr>
                  <td valign="top" width="115">
                    <asp:GridView ID="gvBudgetSummaryStaffDept" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowHeader="false"
                          RowStyle-ForeColor="#7E7E7E" style="border-spacing:0; border-collapse:collapse; height: 100%">
                      <Columns>                    
                           <asp:BoundField DataField="StaffDept" HeaderText="" ItemStyle-Width="115" ItemStyle-Height="30" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="op-type" />
                      </Columns>
                    </asp:GridView>
                  </td>              
                  <td valign="top" style="width:310;">
                    <asp:GridView ID="gvBudgetSummary1" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="28px" 
                      ShowHeader="true"  HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"  HeaderStyle-CssClass="top-header"
                       RowStyle-ForeColor="#7E7E7E" style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;"                         
                          onrowcreated="gvBudgetSummary1_RowCreated" CellPadding="0" CellSpacing="0" 
                          onrowdatabound="gvBudgetSummary1_RowDataBound" >
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="31" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                         <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr><td align="center" style=" border-bottom:1px solid #666; height:31px;">
                              </td></tr>
                              
                              <tr><td align="center"  style="height:31px;"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" Height="31" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr ><td align="center" style="border-bottom:1px solid #666; height:31px;"></td></tr>
                            
                              <tr><td align="center" style="height:31px;"><asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="12px" Font-Bold="true" Text=""  /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header"  Height="31" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server"  Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:31px;"></td></tr>
                             
                              <tr><td id="tdTotalManpowerDiff" runat="server" align="center" style="height:31px;"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="11px"  Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:31px"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="11px" Font-Bold="true" /></td></tr>
                             
                              <tr><td align="center" style="height:31px;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:31px;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                             
                              <tr><td align="center" style="height:31px;">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblCostDifferences" runat="server"  Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:31px;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            
                              <tr><td id="tdTotalCostDiff" runat="server" align="center" style="background-color: #E7E7E7; height:31px;"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310;">
                    <asp:GridView ID="gvBudgetSummary2" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="28px" 
                      ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"  HeaderStyle-CssClass="top-header"
                      RowStyle-ForeColor="#7E7E7E" style=" table-layout:fixed; padding:0px; margin:0px;" 
                          CellPadding="0" CellSpacing="0"
                          onrowcreated="gvBudgetSummary2_RowCreated" 
                          onrowdatabound="gvBudgetSummary2_RowDataBound">
                       <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                         <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px">
                              </td></tr>
                              
                              <tr><td align="center" style="height:33px"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="11px"  Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px"></td></tr>
                          
                              <tr><td align="center"  style="height:33px;"><asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server"  Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"></td></tr>
                              
                              <tr><td id="tdTotalManpowerDiff" runat="server" align="center" style="height:33px;"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="11px" Font-Bold="true" /></td></tr>
                             
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalCostBudget" runat="server"  Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblCostDifferences" runat="server"  Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td id="tdTotalCostDiff" runat="server" style="height:33px;" align="center"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" width="310">
                    <asp:GridView ID="gvBudgetSummary3" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="28px" 
                      ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"  HeaderStyle-CssClass="top-header"
                       RowStyle-ForeColor="#7E7E7E"                         
                          onrowcreated="gvBudgetSummary3_RowCreated" 
                          onrowdatabound="gvBudgetSummary3_RowDataBound" style=" table-layout:fixed; border-collapse:collapse; border-spacing:0;" CellPadding="0" CellSpacing="0">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                         <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;">
                              </td></tr>
                             
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="11px"  Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server"  Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                          <ItemStyle Width="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"></td></tr>
                             
                              <tr><td id="tdTotalManpowerDiff" runat="server" style="height:33px" align="center"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid gray; height:33px;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="11px" Font-Bold="true" /></td></tr>
                             
                              <tr><td align="center" style="height:33px"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid gray; height:33px;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblCostDifferences" runat="server" Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid gray; height:33px;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td id="tdTotalCostDiff" runat="server" align="center" style="height:33px;"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" width="310">
                    <asp:GridView ID="gvBudgetSummary4" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="28px" 
                      ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" RowStyle-ForeColor="#7E7E7E" 
                          CellPadding="0" CellSpacing="0"
                          onrowcreated="gvBudgetSummary4_RowCreated" 
                          onrowdatabound="gvBudgetSummary4_RowDataBound"  HeaderStyle-CssClass="top-header" style=" table-layout:fixed;" >
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                         <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;">
                              </td></tr>
                             
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"></td></tr>
                             
                              <tr><td align="center"  style="height:33px;"> <asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="31" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server" Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px"></td></tr>
                              
                              <tr><td id="tdTotalManpowerDiff" runat="server" align="center" style="height:33px;"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="11px" Font-Bold="true" /></td></tr>
                             
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style= "border-bottom:1px solid #666; height:33px;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                             
                              <tr><td align="center" style="height:33px">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" Height="30" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server"  class="differe-mmr">
                            <asp:Label ID="lblCostDifferences" runat="server"  Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                          <ItemStyle Height="33" />
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="border-bottom:1px solid #666; height:33px;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                             
                              <tr><td id="tdTotalCostDiff" runat="server" align="center" style="height:33px"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="11px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                </tr>
              </table>
         
        </td>
      </tr>
      </tbody>         
        
    </table>

<%--End MMR Budget Report --%>

<%--MMR Summery Report --%>
         <table width="1500" border="0" cellpadding="0" class="persist-area">
        <thead>              
        
        <tr class="persist-header">
       <th>

          <asp:GridView ID="gvMMRFactory" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader"
            RowStyle-CssClass="RangeStyle" Width="100%" ShowHeader="false" 
                 onrowdatabound="gvMMRFactory_RowDataBound" style="table-layout:fixed;">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblHeader" runat="server" Font-Size="12px" Text=''></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="31" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="12px" Text='<%#Eval("Column2") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="31" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="12px" Text='<%#Eval("Column3") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="31" />
              </asp:TemplateField> 
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="12px" Text='<%#Eval("Column4") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="31" />
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="12px" Text='<%#Eval("Column5") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Height="31" />
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </th>
      </tr> 
      </thead>
      <tbody>     
      <tr>
        <td>
       
              <table border="0" cellpadding="0" cellspacing="0" width="100%" align="left" style="margin-left:0px; margin-top:-1px; table-layout:fixed;" bgcolor="#ffffff">
                <tr>
                  <td valign="top" style="width: 150px;">
                    <asp:GridView ID="gvMMRSummaryStaff" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowHeader="false"
                          RowStyle-ForeColor="#7E7E7E" >
                      <Columns>                    
                           <asp:BoundField DataField="StaffDept" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150" ItemStyle-Height="28" ItemStyle-CssClass="op-type"   />
                      </Columns>
                      
                    </asp:GridView>
                  </td>              
                  <td valign="top" width="310">
                    <asp:GridView ID="gvMMRSummary1" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="30px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non"  HeaderStyle-Height="30px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#FFFFFF"
                           HeaderStyle-BackColor="#405D99" RowStyle-ForeColor="#7E7E7E"
                          onrowdatabound="gvMMRSummary1_RowDataBound" style="table-layout:fixed;" cellpadding="0" CellSpacing="0">
                          <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                  
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="11px"  /></td>
                              
                              </tr>
                              
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="11px"  /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                             
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                      
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                            
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                            
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                     
                         <FooterTemplate>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="11px" Font-Bold="true" /></td>                              
                              </tr>
                             
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:30px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                 
                       
                    </asp:GridView> 
                  </td>
                  <td valign="top" width="310">
                    <asp:GridView ID="gvMMRSummary2" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="30px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non" HeaderStyle-Height="30px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#FFFFFF"
                           HeaderStyle-BackColor="#405D99" RowStyle-ForeColor="#7E7E7E"
                          onrowdatabound="gvMMRSummary2_RowDataBound" style="table-layout:fixed;" cellpadding="0" CellSpacing="0">
                     <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                      
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="11px"  /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="11px"  /></td>
                             
                              </tr>
                             
                              <tr >
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="11px" Font-Bold="true" /></td>                              
                              </tr>
                             
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:30px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" width="310">
                    <asp:GridView ID="gvMMRSummary3"  runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="30px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non" HeaderStyle-Height="30px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#FFFFFF"
                           HeaderStyle-BackColor="#405D99" RowStyle-ForeColor="#7E7E7E" 
                          onrowdatabound="gvMMRSummary3_RowDataBound" style="table-layout:fixed;" cellpadding="0" CellSpacing="0">
                     <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="11px"  /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="11px"  /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                             
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="11px" Font-Bold="true" /></td>                              
                              </tr>
                              
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                              
                              <tr>
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:30px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" width="310">
                    <asp:GridView ID="gvMMRSummary4" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="30px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non" HeaderStyle-Height="30px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#FFFFFF"
                           HeaderStyle-BackColor="#405D99" RowStyle-ForeColor="#7E7E7E" 
                          onrowdatabound="gvMMRSummary4_RowDataBound" style="table-layout:fixed;" cellpadding="0" CellSpacing="0">
                      <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="11px"  /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="11px"  /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                             
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="11px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                             
                              <tr >
                              <td align="center" style="height:30px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:30px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Extra</HeaderTemplate>
                          <HeaderStyle Height="30" />
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="11px" Font-Bold="true" /></td>                              
                              </tr>
                             
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="11px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:30px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="11px" /></td>
                             
                              </tr>
                             
                              <tr >
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:30px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="11px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                    </asp:GridView> 
                  </td>
                </tr>
              </table>
          
        </td>
      </tr>
       </tbody>

         
        
        </table>

        <%--End MMR Summery Report --%>
</div>
