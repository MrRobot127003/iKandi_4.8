<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="MMR_Reports_DateRange.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.MMR_Reports_DateRange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
<link rel="stylesheet" type="text/css" href="../../css/jquery-ui.css" />

 <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js"></script>--%>
  <script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
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
   
    height:34px;
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
  line-height: 35px;
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
  <script type="text/javascript">
      function OpenShadowbox(obj) {
          var sURL = obj.href;
          Shadowbox.init({ animate: true, animateFade: true, modal: true });
          Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 768, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
          $("#sb-nav-close").css({ "visibility": "hidden" });
          return false;
      }
      function SBClose() { }

      function DateValidation() {
          //debugger;
          var Today = new Date();
          var FromDate = new Date(ParseDateToSimpleDate($(".DateFrom").val()));
          var ToDate = new Date(ParseDateToSimpleDate($(".DateTo").val()));
          if (FromDate > Today) {
              alert('From date can not be greater than today');
              $(".DateFrom").val('');
              return false;
          }
          if (ToDate > Today) {
              alert('To date can not be greater than today');
              $(".DateTo").val('')
              return false;
          }
          if (FromDate > ToDate) {
              alert('To date can not be less than From date');
              $(".DateFrom").val('');
          return false;
      }
      
      }
  </script>

  <!------------------------Add-by Prabhaker--------------------------->
  <script type="text/javascript">
      function UpdateTableHeaders() {
          $(".persist-area").each(function () {

              var el = $(this),
               offset = el.offset(),
               scrollTop = $(window).scrollTop(),
               floatingHeader = $(".floatingHeader", this)

              if ((scrollTop > offset.top) && (scrollTop < offset.top + el.height())) {
                  floatingHeader.css({
                      "visibility": "visible"
                  });
              } else {
                  floatingHeader.css({
                      "visibility": "hidden"
                  });
              };
          });
      }

      // DOM Ready
      $(function () {

          var clonedHeaderRow;

          $(".persist-area").each(function () {
              clonedHeaderRow = $(".persist-header", this);
              clonedHeaderRow
             .before(clonedHeaderRow.clone())
             .css("width", clonedHeaderRow.width())
             .addClass("floatingHeader");

          });

          $(window)
        .scroll(UpdateTableHeaders)
        .trigger("scroll");

      });
  </script>

   <script type="text/javascript">

       $(function () {
           $(".th").datepicker({ dateFormat: 'dd M y (D)' });
           //           $(".th1").datepicker({ dateFormat: 'dd/mm/yy' });
           //           $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });
       });
  
  </script>



  <!--------------------------------end code---------------------------->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="1500px" align="center" style="font-family:Arial;">
      <tr>
        <td style="background-color: #405D99; height:50px;">
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td style="width: 30%; padding-left:25px;">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="th" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" Display="None" ErrorMessage="Please select a Date From." ControlToValidate="txtDateFrom" ValidationGroup="G1" />  
                &nbsp;&nbsp;
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="th" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Please select a Date To." ControlToValidate="txtDateTo" ValidationGroup="G1" />  
                <asp:Button ID="btnCreate" runat="server" OnClientClick="javascript:return DateValidation()"  Text="Search" CssClass="go" OnClick="btnCreate_Click" ValidationGroup="G1" />

                <asp:ValidationSummary ID="vsSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="G1" />
                
              </td>
              <td align="center" style="width: 40%; color: #FFFFFF; font-size: 16px;">
                Weekly MMR Report (<asp:Label ID="lblDate" runat="server" Text=""></asp:Label>)
              </td>
              <td valign="middle" style="width: 30%; padding-left:50px;">
                <div style="border:2px solid #FFFFFF; height:30px; width: 90%; padding-left:0px;">
                  <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="height:100%;">
                    <tr>                    
                      <td align="center" valign="middle" style="width: 50%; color: #FFFFFF; font-size: 16px;">Working Hour</td>
                      <td align="center" valign="middle" style="width: 50%;">
                        <asp:TextBox ID="txtworkingHour" ReadOnly="true" runat="server" Width="50px"></asp:TextBox>
                      </td>
                    </tr>
                  </table>
                </div>
              </td>
               <td style="padding-right: 15px;">
                <a rel="shadowbox;width=780;height=600;" href="/internal/OrderProcessing/MoBudget_Formulas.aspx?show=MMRReportDateRange" onclick="return OpenShadowbox(this);"><img src="../../images/help.png" height="30px" alt="" title="Help!" /></a>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td style="height:5px;"></td>
      </tr>
     
  
      <tr>
        <td style="height:5px;"></td>
      </tr>
       <tr>
        <td>

         <table width="1500px" border="0" cellpadding="0" class="persist-area">
        <thead>
        
        
        
        <tr class="persist-header">
       <th>

          <asp:GridView ID="gvFactoryBudgetSummary" runat="server" 
                AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader"
            RowStyle-CssClass="RangeStyle" Width="1500px" ShowHeader="false" 
                RowStyle-Height="35px" 
                onrowdatabound="gvFactoryBudgetSummary_RowDataBound">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="115px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblHeader" runat="server" Font-Size="12px" Text=''></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="12px" Text='<%#Eval("Column2") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="12px" Text='<%#Eval("Column3") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField> 
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="12px" Text='<%#Eval("Column4") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="12px" Text='<%#Eval("Column5") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </th>
        
        
        
        </tr>

        </thead>

        <tbody>
      <tr>
        <td>
          <asp:updatepanel ID="Updatepanel4" runat="server">
            <ContentTemplate>
             <table border="0" cellpadding="0" cellspacing="0" width="1500px" bgcolor="#ffffff" align="left" style="table-layout:fixed; border:1px solid #666; border-collapse:collapse; border-spacing:0; padding:0px; margin:0px;">
                <tr>
                  <td valign="top" style="width: 115px;">
                    <asp:GridView ID="gvBudgetSummaryStaffDept" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowHeader="false" RowStyle-Height="35px"
                          RowStyle-ForeColor="#7E7E7E" style="border-spacing:0; border-collapse:collapse; height: 100%" >
                      <Columns>                    
                           <asp:BoundField DataField="StaffDept" HeaderText="" ItemStyle-Width="115px" ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="op-type" />
                      </Columns>
                    </asp:GridView>
                  </td>              
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvBudgetSummary1" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="70px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-CssClass="top-header"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;"
                            CellPadding="0" CellSpacing="0" 
                          onrowcreated="gvBudgetSummary1_RowCreated" 
                          onrowdatabound="gvBudgetSummary1_RowDataBound" >
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                         <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                             <tr style="height:35px;"><td align="center" style=" border-bottom:1px solid #666;">
                              </td></tr>
                              
                              <tr style="height:35px;"><td align="center"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                             <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"></td></tr>
                               <tr style="height:35px;"><td align="center"><asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="42px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"></td></tr>
                        
                              <tr><td id="tdTotalManpowerDiff" runat="server" align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                             <tr style="height:35px;"><td align="center"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                              <tr style="height:35px;"><td align="center">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblCostDifferences" runat="server" Font-Size="12px" Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="table-layout:fixed; border-spacing:0; border-collapse:collapse; padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <tr style="height:35px;"><td id="tdTotalCostDiff" runat="server" align="center"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvBudgetSummary2" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="70px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-CssClass="top-header"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"  style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;" 
                          CellPadding="0" CellSpacing="0" 
                           
                          onrowcreated="gvBudgetSummary2_RowCreated" 
                          onrowdatabound="gvBudgetSummary2_RowDataBound">
                       <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                         <FooterTemplate>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;">
                              </td></tr>
                              <tr style="height:35px;"><td align="center"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                             <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666; "></td></tr>
                          
                              <tr style="height:35px;"><td align="center"><asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"></td></tr>
                              
                              <tr style="height:35px;"><td id="tdTotalManpowerDiff" runat="server" align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                             
                              <tr style="height:35px;"><td align="center" ><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                           <FooterTemplate>
                             <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:0px; margin:0px;">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                              <tr style="height:35px;" ><td align="center" style="height:35px; background-color: #E7E7E7;">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server" class="differe-mmr" >
                            <asp:Label ID="lblCostDifferences" runat="server" Font-Size="12px" Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td id="tdTotalCostDiff" runat="server" align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvBudgetSummary3" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="70px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-CssClass="top-header"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"  
                           
                          onrowcreated="gvBudgetSummary3_RowCreated" 
                          onrowdatabound="gvBudgetSummary3_RowDataBound" style=" table-layout:fixed; border-collapse:collapse; border-spacing:0;" CellPadding="0" CellSpacing="0">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                         <FooterTemplate>
                             <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;">
                              </td></tr>
                             
                             <tr style="height:35px;"><td align="center"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"></td></tr>
                              
                              <tr style="height:35px;"><td align="center" ><asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                             <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"></td></tr>
                             
                              <tr style="height:35px;"><td id="tdTotalManpowerDiff" runat="server" align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid gray;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              <tr style="height:35px;"><td align="center"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid gray;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                              <tr style="height:35px;"><td align="center">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblCostDifferences" runat="server" Font-Size="12px" Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid gray;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <tr style="height:35px;"><td id="tdTotalCostDiff" runat="server" align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvBudgetSummary4" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="70px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-CssClass="top-header"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" style=" table-layout:fixed; border-collapse:collapse; border-spacing:0;"
                            CellPadding="0" CellSpacing="0"
                          onrowcreated="gvBudgetSummary4_RowCreated" 
                          onrowdatabound="gvBudgetSummary4_RowDataBound" >
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />                                                
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                         <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666; height:34px;">
                              </td></tr>
                             
                              <tr style="height:35px;"><td align="center" style="height:34px;"><asp:Label ID="lblManPowerTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"></td></tr>
                             
                              <tr style="height:35px;"><td align="center"> <asp:Label ID="lblManPowerTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="32px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvManPowerDiff" runat="server" class="differe-mmr">
                            <asp:Label ID="lblManPowerDifferences" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerDiff") %>'></asp:Label>
                            </div>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"></td></tr>
                              
                              <tr style="height:35px;"><td id="tdTotalManpowerDiff" runat="server" align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalManPowerDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="52px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              <tr style="height:35px;"><td align="center"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="52px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Today</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style= "border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                              <tr style="height:35px;"><td align="center">
                              <asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="52px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff.</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <div id="dvCostDiff" runat="server" class="differe-mmr" >
                            <asp:Label ID="lblCostDifferences" runat="server" Font-Size="12px" Text='<%#Eval("CostDiff") %>'></asp:Label>
                                </div>                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr style="height:35px;"><td align="center" style="border-bottom:1px solid #666;"><asp:Label ID="lblOverHeadCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             <tr style="height:35px;"><td id="tdTotalCostDiff" runat="server" align="center"><asp:Label ID="lblTotalCostDiff" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                </tr>
              </table>
            </ContentTemplate>
          </asp:updatepanel>

          </td>
      </tr>
      </tbody>

         
        
        </table>
        </td>
      </tr>

      <tr>
      <td style="height:20px;">
      </td>
      </tr>
        <tr>
        <td>

          <table width="1500px" border="0" cellpadding="0" class="persist-area">
        <thead>
        
        
        
        <tr class="persist-header">
       <th>
          <asp:GridView ID="gvMMRFactory" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader"
            RowStyle-CssClass="RangeStyle" Width="1500PX" ShowHeader="false" 
                RowStyle-Height="35px" onrowdatabound="gvMMRFactory_RowDataBound">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblHeader" runat="server" Font-Size="12px" Text=''></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="12px" Text='<%#Eval("Column2") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="12px" Text='<%#Eval("Column3") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField> 
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="12px" Text='<%#Eval("Column4") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="12px" Text='<%#Eval("Column5") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>

          </th>

     
      </tr>
     </thead>
     <tbody>
      

      <tr>
        <td>
          <asp:updatepanel ID="Updatepanel3" runat="server">
            <ContentTemplate>
              <table border="0" cellpadding="0" cellspacing="0" width="1500px" align="left" style="table-layout:fixed;" bgcolor="#ffffff">
                <tr>
                  <td valign="top" style="width: 150px;">
                    <asp:GridView ID="gvMMRSummaryStaff" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowHeader="false" RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" style="table-layout:fixed;" cellpadding="0" CellSpacing="0">
                      <Columns>                    
                           <asp:BoundField DataField="StaffDept" HeaderText="" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="op-type" />
                      </Columns>
                    </asp:GridView>
                  </td>              
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvMMRSummary1" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="35px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#575759" style="table-layout:fixed;" cellpadding="0" CellSpacing="0"
                           HeaderStyle-BackColor="#dddfe4" RowStyle-ForeColor="#7E7E7E" 
                          onrowdatabound="gvMMRSummary1_RowDataBound">
                          <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                              
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="13px"  /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="13px"  /></td>
                             
                              </tr>
                              
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                              
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="13px" Font-Bold="true" /></td>                              
                              </tr>
                             
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                              
                              <tr>
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:34px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                 
                       
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvMMRSummary2" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="35px" 
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#575759"
                           HeaderStyle-BackColor="#dddfe4" RowStyle-ForeColor="#7E7E7E" style="table-layout:fixed;" cellpadding="0" CellSpacing="0"
                          onrowdatabound="gvMMRSummary2_RowDataBound">
                     <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="13px"  /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="13px"  /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="13px" Font-Bold="true" /></td>                              
                              </tr>
                             
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                              
                              <tr>
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:34px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                   <asp:GridView ID="gvMMRSummary3"  runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="35px" 
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#575759"
                           HeaderStyle-BackColor="#dddfe4" RowStyle-ForeColor="#7E7E7E" style="table-layout:fixed;" cellpadding="0" CellSpacing="0"
                          onrowdatabound="gvMMRSummary3_RowDataBound">
                     <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="13px"  /></td>
                              
                              </tr>
                              
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="13px"  /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                              
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="13px" Font-Bold="true" /></td>                              
                              </tr>
                              
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                              
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:34px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                   <asp:GridView ID="gvMMRSummary4" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="32px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" RowStyle-Height="0px" RowStyle-CssClass="disp_non" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false"   HeaderStyle-ForeColor="#575759"
                           HeaderStyle-BackColor="#dddfe4" RowStyle-ForeColor="#7E7E7E" style="table-layout:fixed;" cellpadding="0" CellSpacing="0"
                          onrowdatabound="gvMMRSummary4_RowDataBound">
                      <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnAvailMinsActual" runat="server" Value='<%#Eval("AvailMinsActual") %>' /> 
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblBudgetMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineBudget" runat="server" Font-Size="13px"  /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsBudget" runat="server" Font-Size="13px"  /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMBudget" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                             
                            </table>
                            
                          </FooterTemplate>
                          </asp:TemplateField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td align="center" style="height:34px;border-bottom:1px solid #666;"><asp:Label ID="lblActualMMR" runat="server" Font-Size="13px"  /></td>                              
                              </tr>
                            
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineActual" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsActual" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td align="center" style="height:34px;"><asp:Label ID="lblCPAMActual" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Diff</HeaderTemplate>
                          <ItemTemplate>                          
                             
                          </ItemTemplate>
                         <FooterTemplate>
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td id="tdDiff" runat="server" align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblDiff" runat="server" Font-Size="13px" Font-Bold="true" /></td>                              
                              </tr>
                             
                              <tr>
                              <td id="tdProMachineDiff" runat="server" align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblProMachineDiff" runat="server" Font-Size="13px" /></td>
                              
                              </tr>
                             
                              <tr>
                              <td id="tdAvailMinsDiff" runat="server" align="center" style="height:34px; border-bottom:1px solid #666;"><asp:Label ID="lblAvailMinsDiff" runat="server" Font-Size="13px" /></td>
                             
                              </tr>
                             
                              <tr>
                              <td id="tdCPAMDiff" runat="server" align="center" style="height:34px;"><asp:Label ID="lblCPAMDiff" runat="server" Font-Size="13px" /></td>
                           
                              </tr>                            
                              
                            </table>
                            
                          </FooterTemplate>
                        </asp:TemplateField>

                          </Columns>
                    </asp:GridView> 
                  </td>
                </tr>
              </table>
            </ContentTemplate>
          </asp:updatepanel>
        </td>
      </tr>
      </tbody>
      </table>
      </td>
      </tr>

       <tr>
      <td style="height:20px;">
      </td>
      </tr>

      <tr>
        <td>
               <table width="1500px" border="0" cellpadding="0" class="persist-area">
        <thead>
        
        
        
        <tr class="persist-header">
       <th>

          <asp:GridView ID="gvAvailMin" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader"
            RowStyle-CssClass="RangeStyle" Width="1500PX" ShowHeader="false" RowStyle-Height="35px" OnRowDataBound="gvAvailMin_rowDataBound">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="270px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblHeader" runat="server" Font-Size="12px" Text=''></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="283px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="12px" Text='<%#Eval("Column2") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="283px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="12px" Text='<%#Eval("Column3") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField> 
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="283px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="12px" Text='<%#Eval("Column4") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="283px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="12px" Text='<%#Eval("Column5") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </th>
      </tr>
     </thead>
     <tbody>
      <tr>
        <td>
          <asp:updatepanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
              <table border="0" cellpadding="0" cellspacing="0" width="1500px" align="left" style="margin-left:0px; margin-top:-1px;" bgcolor="#ffffff">
                <tr>
                  <td valign="top" style="width: 270px;">
                    <asp:GridView ID="gvWorkerType" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"
                      OnDataBound="gvWorkerType_DataBound" OnRowDataBound="gvWorkerType_RowDataBound" style="table-layout:fixed;" cellpadding="0" CellSpacing="0">
                       <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" ItemStyle-VerticalAlign="Middle">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblStaffDept" runat="server" CssClass="rotate" Font-Size="20px" Text='<%#Eval("StaffDept") %>' ForeColor="#405D99" Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                          
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblWorkerType" runat="server" Text='<%#Eval("WorkerType") %>' ForeColor="#405D99"></asp:Label>
                          </ItemTemplate>
                          <ItemStyle CssClass="op-type" />
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>    
                            
                  <td valign="top" style="width: 283px;">
                    <asp:GridView ID="gvFactoryDetails1" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-Height="32px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvFactoryDetails1_RowDataBound"  OnRowCreated="gvFactoryDetails1_RowCreated" style="table-layout:fixed; border-spacing:0">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />
                            <asp:HiddenField ID="hdnWorkerTypeId" runat="server" Value='<%#Eval("FactoryWorkSpace") %>' />
                            <asp:HiddenField ID="hdnMachineCount" runat="server" Value='<%#Eval("MachineCount") %>' />
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalMonthlyBudgetCount" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate >
                             <div id="dvManPowerActual" style="vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                             </div>    
                                                       
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalManPowerActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td id="tdMonthlyTotalActual" runat="server" align="center" style="height:33px; "><asp:Label ID="lblMonthlyTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalMonthlyCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                             <div id="dvCostActual" style=" vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                            </div>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalCostActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                              
                              <tr><td id="tdTotalMonthlyCostActual" runat="server" align="center" style="height:33px;">
                              <asp:Label ID="lblTotalMonthlyCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 283px;">
                    <asp:GridView ID="gvFactoryDetails2" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-Height="32px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvFactoryDetails2_RowDataBound"  OnRowCreated="gvFactoryDetails2_RowCreated">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />
                            <asp:HiddenField ID="hdnWorkerTypeId" runat="server" Value='<%#Eval("FactoryWorkSpace") %>' />
                            <asp:HiddenField ID="hdnMachineCount" runat="server" Value='<%#Eval("MachineCount") %>' />
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalMonthlyBudgetCount" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                             <div id="dvManPowerActual" style="vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                             </div>                             
                          </ItemTemplate>                          
                            <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalManPowerActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            
                              <tr><td id="tdMonthlyTotalActual" runat="server" align="center" style="height:33px;"><asp:Label ID="lblMonthlyTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             

                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalMonthlyCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <%--<tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblProd_vs_CostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>                        
                            <div id="dvCostActual" style="vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>                            
                            </div>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalCostActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                              
                              <tr><td id="tdTotalMonthlyCostActual" runat="server" align="center" style="height:33px;">
                              <asp:Label ID="lblTotalMonthlyCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             <%-- <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblActualProd_vs_Budget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 
                      
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 283px;">
                    <asp:GridView ID="gvFactoryDetails3" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-Height="32px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvFactoryDetails3_RowDataBound"  OnRowCreated="gvFactoryDetails3_RowCreated">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />
                            <asp:HiddenField ID="hdnWorkerTypeId" runat="server" Value='<%#Eval("FactoryWorkSpace") %>' />
                            <asp:HiddenField ID="hdnMachineCount" runat="server" Value='<%#Eval("MachineCount") %>' />
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                             
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalMonthlyBudgetCount" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             <%-- <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblProd_vs_Budget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <div id="dvManPowerActual" style="vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                             </div>                           
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalManPowerActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                           
                              <tr><td id="tdMonthlyTotalActual" runat="server" align="center" style="height:33px;"><asp:Label ID="lblMonthlyTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <%--<tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblProd_vs_Actual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>

                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                           
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalMonthlyCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>                              
                               <%-- <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblProd_vs_CostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                             <div id="dvCostActual" style="vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>                            
                            </div>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalCostActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                              
                              <tr><td id="tdTotalMonthlyCostActual" runat="server" align="center" style="height:33px;">
                              <asp:Label ID="lblTotalMonthlyCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <%--<tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblActualProd_vs_Budget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>                       
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 283px;">
                    <asp:GridView ID="gvFactoryDetails4" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-Height="32px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvFactoryDetails4_RowDataBound"  OnRowCreated="gvFactoryDetails4_RowCreated">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                          <asp:HiddenField ID="hdnMachineCount" runat="server" Value='<%#Eval("MachineCount") %>' />
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerBudget") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                          
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblTotalMonthlyBudgetCount" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <%--<tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblProd_vs_Budget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                              <div id="dvManPowerActual" style="vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("ManPowerActual") %>'></asp:Label>
                             </div> 
                           
                          </ItemTemplate>
                            <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalManPowerActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalManPowerActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td id="tdMonthlyTotalActual" runat="server" align="center" style="height:33px;"><asp:Label ID="lblMonthlyTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             <%-- <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblProd_vs_Actual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px; "><asp:Label ID="lblTotalMonthlyCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <%--<tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblProd_vs_CostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                           <HeaderStyle CssClass="bot-header" />
                          <ItemTemplate>                        
                                <div id="dvCostActual" style="vertical-align:middle;" runat="server" class="differe-act">
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>                            
                            </div>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td id="tdTotalCostActual" runat="server" align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text=""/></td></tr>
                             
                              <tr><td id="tdTotalMonthlyCostActual" runat="server" align="center" style="height:33px;">
                              <asp:Label ID="lblTotalMonthlyCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              <%--<tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblActualProd_vs_Budget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>--%>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>                      
                      </Columns>
                    </asp:GridView> 
                  </td>
                </tr>
              </table>
            </ContentTemplate>
          </asp:updatepanel>
        </td>
      </tr>
      </tbody>
      </table>
      </td>
      </tr>
      <tr>
      <td style="height:20px;">
      </td>
      </tr>

        <tr>
        <td>
               <table width="1500px" border="0" cellpadding="0" class="persist-area">
        <thead>
        
        
        
        <tr class="persist-header">
       <th>

          <asp:GridView ID="gvFactory" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader"
            RowStyle-CssClass="RangeStyle" Width="1500PX" ShowHeader="false" 
                RowStyle-Height="35px" onrowdatabound="gvFactory_RowDataBound">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblHeader" runat="server" Font-Size="12px" Text=''></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="12px" Text='<%#Eval("Column2") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="12px" Text='<%#Eval("Column3") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField> 
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="12px" Text='<%#Eval("Column4") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="12px" Text='<%#Eval("Column5") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </th>
      </tr>
      </thead>
      <tbody>
      <tr>
        <td>
          <asp:updatepanel ID="Updatepanel2" runat="server">
            <ContentTemplate>
              <table border="0" cellpadding="0" cellspacing="0" width="1500px" align="left" style="margin-left:0px; margin-top:-1px;" bgcolor="#ffffff">
                <tr>
                  <td valign="top" style="width: 180px;">
                    <asp:GridView ID="gvStaffDept" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowHeader="false" RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" ondatabound="gvStaffDept_DataBound">
                      <Columns>
                      <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="lblStaffDept" runat="server" Text='<%#Eval("StaffDept") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="op-type" />
                      </asp:TemplateField>   
                      </Columns>
                    </asp:GridView>
                  </td>              
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvCMTFactory1" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="35px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" 
                           onrowcreated="gvCMTFactory1_RowCreated" 
                          onrowdatabound="gvCMTFactory1_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />   
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' /> 
                            <asp:HiddenField ID="hdnTotalActual" runat="server" Value='<%#Eval("TotalActual") %>' />                          
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Budget") %>'></asp:Label>
                          </ItemTemplate>
                         <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblCMTTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Actual") %>'></asp:Label>
                                                       
                          </ItemTemplate>
                        <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblCMTTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblCMTTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            
                              <tr><td align="center" style="height:33px;">
                              <asp:Label ID="lblCMTTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvCMTFactory2" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="35px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"  
                           onrowcreated="gvCMTFactory2_RowCreated" 
                          onrowdatabound="gvCMTFactory2_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />      
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />  
                            <asp:HiddenField ID="hdnTotalActual" runat="server" Value='<%#Eval("TotalActual") %>' />                       
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Budget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                            
                              <tr><td align="center" style="height:33px;" ><asp:Label ID="lblCMTTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Actual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCount" runat="server" />                          
                          </ItemTemplate>                          
                            <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;" ><asp:Label ID="lblCMTTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblCMTTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                              <tr><td align="center" style="height:33px;">
                              <asp:Label ID="lblCMTTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField> 
                      
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvCMTFactory3" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="35px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"  
                           onrowcreated="gvCMTFactory3_RowCreated" 
                          onrowdatabound="gvCMTFactory3_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />  
                            <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />    
                            <asp:HiddenField ID="hdnTotalActual" runat="server" Value='<%#Eval("TotalActual") %>' />                         
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Budget") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                             
                              <tr><td align="center" style="height:33px;" ><asp:Label ID="lblCMTTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Actual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCount" runat="server" />                           
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;" ><asp:Label ID="lblCMTTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;" ><asp:Label ID="lblCMTTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                            <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             
                              <tr><td align="center" style="height:33px;" >
                              <asp:Label ID="lblCMTTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>                       
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvCMTFactory4" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" FooterStyle-Height="35px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="11px" 
                          HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" 
                           onrowcreated="gvCMTFactory4_RowCreated" 
                          onrowdatabound="gvCMTFactory4_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                          <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                          <asp:HiddenField ID="hdnOverHead" runat="server" Value='<%#Eval("FactoryOverHead") %>' />  
                          <asp:HiddenField ID="hdnTotalActual" runat="server" Value='<%#Eval("TotalActual") %>' /> 
                            <asp:Label ID="lblManPowerBudget" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Budget") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblCMTTotalBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                             </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblManPowerActual" runat="server" Font-Size="12px" Text='<%#Eval("CPAM_Actual") %>'></asp:Label>
                           
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblOverHeadActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td align="center" style="height:33px; "><asp:Label ID="lblCMTTotalActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Budget</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostBudget" runat="server" Font-Size="12px" Text='<%#Eval("CostBudget") %>'></asp:Label>
                          </ItemTemplate>
                            <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;"><asp:Label ID="lblCMTTotalCostBudget" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Actual</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCostActual" runat="server" Font-Size="12px" Text='<%#Eval("CostActual") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                           <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:33px; border-bottom:1px solid gray; border-spacing:0;"><asp:Label ID="lblTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                              
                              <tr><td align="center" style="height:33px;">
                              <asp:Label ID="lblCMTTotalCostActual" runat="server" Font-Size="13px" Font-Bold="true" Text="" /></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>                      
                      </Columns>
                    </asp:GridView> 
                  </td>
                </tr>
              </table>
            </ContentTemplate>
          </asp:updatepanel>
        </td>
      </tr>
      </tbody>
      </table>
      </td>
      </tr>
       

    </table>
  </div>
</asp:Content>
