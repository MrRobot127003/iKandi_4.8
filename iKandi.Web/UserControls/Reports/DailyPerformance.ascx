<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyPerformance.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.DailyPerformance" %>
<style type="text/css">
.op-type
{
    font-family: arial;
font-size: 11px !important;
font-weight: bold;
color: #3B5998;
padding-left:2px;
text-transform:capitalize;
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
    color:White;
    font-weight:600;   
    border-bottom:1px solid #fff;
   
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
    text-transform:capitalize;
    font-weight:normal;
}
.top-header th
{
    font-size:9px !important;
}
.Main-header
{
    background:#405d99; 
    color:White;font-size:15px; 
    text-transform:uppercase;
    font-weight:bold;
    text-align:center;
    border:1px solid white;
    height:30px;
}
.differe-mmr
{
   
    height:30px;
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
    .row-no-tw
    {
        height:100px;
     
    }
    .bord_bott
    {
        border-bottom:1px solid grey;
    }
    .h40
    {
        height:40px;
    }
    .h30
    {
        height:30px
    }
    .h24
    {
        height:24px;
    }
    .grey {
    color: grey;
    font-size:10px;
}
    .persist-area
    {
        font-family:Verdana;
        text-transform:capitalize;
         
    }
     .persist-area span
     {
         font-size:9px;
     }
     .line-height
     {
         line-height:20px;
     }
     
.blue {
    color: blue;
}
.h35
{
    height:34px;
    vertical-align:middle;
    text-align:center;
   
    border-bottom:1px solid #f0f0f0
    
}
.h53
{
    height:52px;
    vertical-align:middle;
    text-align:center;
   border-bottom:1px solid #f0f0f0
}
.header-text-back {
    background-color: #405d99;
    border-radius: 5px 5px 0 0;
    color: #ffffff;
    font-size: large;
    margin: 0;
    padding: 5px 0;
    text-align: center;
    text-transform: capitalize;
}
.bord_botts
{
    border-bottom:1px solid #f0f0f0;
}
</style>

  <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
  
 <%-- <script type="text/javascript">
      $(window).load(function () {
          //        //debugger;
          //alert('hllll');
          $("Table td span").filter(function () {
             
              return $(this).text() == '₹ 0 L';
          }).css("display", "none");

              $("Table td span").filter(function () {
          //              //debugger;
                      return $(this).text() == '(₹ 0 L)';
                  }).css("display", "none");
      });

    $(window).load(function () {

        $(".thisTable td span").each(function () {        
            var el = $(this);
            var value = parseFloat(el.text());
            
            if (value == 0) {
                el
                 .css("display", "none");
            }
        });


     }); 



  </script>--%>

       
       
<%--Daily Performance Report --%>
    <table width="2400" cellspacing="0" border="0" cellpadding="0" class="persist-area" style="font-family:Verdana,Geneva,sans-serif;">
   <tr><td><h2  class="header-text-back" style="width:2400">Production Performance Report  </h2></td></tr>
        <tr><td>
         <table border="0" cellpadding="0" cellspacing="0" width="2400" class="thisTable" bgcolor="#ffffff" align="left" style="table-layout:fixed; border:1px solid #666; border-collapse:collapse; border-spacing:0; padding:0px; margin:0px;">
                <tr>     
                 <td valign="top" width="85">
                  <table cellpadding="0" cellspacing="0" width="100%">
                  <tr><td class="Main-header"></td></tr>
                  <tr><td>
                    <asp:GridView ID="gvPeriod" runat="server" AutoGenerateColumns="false"  RowStyle-HorizontalAlign="Center" RowStyle-Font-Size="11px"
                         ShowHeader="true" HeaderStyle-HorizontalAlign="Center"  Width="100%"
                          RowStyle-ForeColor="#7E7E7E" BorderWidth="1" style="border-spacing:0; border-collapse:collapse; height: 100%">
                      <Columns> 
                      <asp:TemplateField>
                      <HeaderTemplate>
                     Day/ Time Period
                      </HeaderTemplate>
                      <HeaderStyle CssClass="bord_bott" Height="121" />
                      <ItemTemplate>
                          <asp:Label ID="lblPeriodDay" CssClass="grey" style="font-weight:bold;" runat="server" Text='<%#Eval("PeriodDay") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle Height="112" CssClass="bord_bott"  />
                      </asp:TemplateField>                   
                           
                      </Columns>
                    </asp:GridView>
                    </td></tr></table>
                  </td>                   
                  <td valign="top" width="430">
                  <table cellpadding="0" cellspacing="0" width="100%">
                  <tr><td class="Main-header">C 47</td></tr>
                  <tr>
                  <td>
                    <asp:GridView ID="gvDailyPerformance_Unit1" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" 
                      ShowHeader="true" RowStyle-Font-Size="8px" RowStyle-HorizontalAlign="Center"  HeaderStyle-Font-Size="10px" 
                           HeaderStyle-HorizontalAlign="Center"   HeaderStyle-CssClass="top-header" HeaderStyle-Height="120"
                       RowStyle-ForeColor="#7E7E7E" 
                          style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;" 
                          onrowdatabound="gvDailyPerformance_Unit1_RowDataBound">
                      <Columns>
                      <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%"  style="height:120; line-height:20px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20;" align="center" valign="top">Cutting</th></tr>
                      <tr class="row-no-tw">
                      <th align="center" class="back-blue" style="height:100;" valign="top">
                      Qty Actual 
                           <br />
                           Qty Plan<br />
                           Cost Per Pc
                           </th>
                           </tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                   
                   <table cellpadding="0" cellspacing="0" width="100%" FRAME ="VOID" rules="all">
                  
                   <tr>
                   <td class="h35">
                    <asp:Label ID="lblCutQtyActual" ForeColor="black" runat="server" Text='<%#Eval("CuttingQtyActual") %>'></asp:Label> 
                   </td>
                   </tr>
                   <tr>
                   <td class="h35"> 
                   <asp:Label ID="lblCutQtyPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CuttingQtyPlan") %>'></asp:Label>
                   </td>
                   </tr>
                   <tr>
                   <td class="h35" style="border-bottom:none;">
                    <asp:Label ID="lblCutCostPerPc" ForeColor="Black" style="font-weight:bold;" runat="server" Text='<%#Eval("CuttingCostPerPc") %>'></asp:Label>
                   </td>
                   </tr>
                   
                   
                   
                   </table>


                      </ItemTemplate>
                   
                      <ItemStyle Height="110" VerticalAlign="Top" />

                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="150" ItemStyle-Width="150">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="height:120px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="3" align="center" valign="middle">Stitching</th></tr>
                      <tr style="height:30px">
                      <th  width="33.33%"  style=" border-right:1px solid #fff" class="back-blue" align="center" valign="top">Actual</th>
                      <th  width="33.33%"  style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">Target</th>
                      <th  width="33.33%"  class="back-blue" align="center" valign="top">Break Even</th>
                      </tr>
                      <tr style="height:70px" class="line-height">
                      <th style="width:50; border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                      Eff(%) <br /> 
                          Ach(%) <br /> Qty
                       </th>
                       <th style="width:50; border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                       Eff(%) 
                      <br />
                      Ach(%)
                      <br />Qty
                      </th>
                      <th style="width:50;" class="back-blue" align="center" valign="top">
                      Eff(%) 
                              <br />Ach(%)<br />Qty
                              </th>
                              </tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0"  width="100%" class="line-height">
                      <tr>
                      <td align="center" width="33.33%" height="110" style="border-right:1px solid #ccc; vertical-align:top;">
                       <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                      <asp:Label ID="lblStchActualEff" ForeColor="Gray" style="font-weight:bold;" runat="server" Text='<%#Eval("StitchActualEff") %>'></asp:Label>
                        </td>
                          </tr>
                            <tr>
                   <td class="h35">
                          <asp:Label ID="lblStchActualAch" CssClass="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchActualAch") %>'></asp:Label>
                   </td>
                          </tr>
                            <tr>
                   <td class="h35" style="border-bottom:none;" >

                          <asp:Label ID="lblStchActualQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchActualQty") %>'></asp:Label>


                          </td>
                          </tr>
                          </table>
                          </td>
                     
                       
                      
                          <td align="center"  width="33.33%" height="110"  style="border-right:1px solid #ccc;  vertical-align:top;">
                          <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                          <asp:Label ID="lblStchTargetEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetEff") %>'></asp:Label>
                        </td>
                        </tr>
                           <tr>
                   <td class="h35">
                          <asp:Label ID="lblStchTargetAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchTargetAch") %>'></asp:Label>
                        </td>
                        </tr>
                         <tr>
                   <td class="h35" style="border-bottom:none;">
                            <asp:Label ID="lblStchTargetQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetQty") %>'></asp:Label>
                       </td>
                       </tr></table>
                         
                        </td>
                          
                           <td align="center"  width="33.33%"  style="vertical-align:top;">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                         
                           
                           <asp:Label ID="lblStitchBreakEvenEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenEff") %>'></asp:Label>
                         </td>
                         </tr>
                         <tr>
                   <td class="h35">
                           <asp:Label ID="lblStitchBreakEvenAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchBreakEvenAch") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                          <td class="h35" style="border-bottom:none;">
                          
                           <asp:Label ID="lblStitchBreakEvenQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenQty") %>'></asp:Label>
                          </td>
                          
                          
                          </tr>
                          </table>
                          
                      
                          </td></tr>
                      </table>
                      </ItemTemplate>
                      <ItemStyle  Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="height:120px;" FRAME ="VOID" rules="all">
                      <tr><th style="width:100%; height:20px;" align="center" valign="middle">Finishing</th></tr>
                      <tr style="height:30px;"><th style="width:60px;" class="back-blue" align="center" valign="top">Actual</th></tr>
                      <tr style="height:70px;">
                      <th style="width:60px;" class="back-blue" align="center" valign="top">Eff(%) 
                          <br />Ach(%)<br />Cost(PP)<br />Tgt Qty<br />Act Qty</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                    
                      <table cellpadding="0" cellspacing="0" width="0" border="0" style="width:100%; line-height:20px;">
                      <tr>
                
                      <td class="bord_botts" style="text-align:center; height:22px">  <asp:Label ID="lblFinishActualEff" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualEff") %>'></asp:Label></td>
                      </tr>
                      <tr>
                    
                     <td class="bord_botts" style="text-align:center;height:22px"> 
                      <asp:Label ID="lblFinishActualAch" ForeColor="Blue" runat="server" Text='<%#Eval("FinishActualAch") %>'></asp:Label>
                      
                      </td>
                      
                      </tr>
                      <tr>
                      <td class="bord_botts" style="text-align:center;height:22px">
                   
                      <asp:Label ID="lblFinishCost" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualCost") %>'></asp:Label>
                      </td>
                      
                      </tr>
                      <tr>
                   
                     <td class="bord_botts" style="text-align:center;height:22px"> 
                       <asp:Label ID="lblFinishTgtQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishTargetQty") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                   
                    
                      <td style="text-align:center; height:22px;"> 
                          <asp:Label ID="lblFinishActQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualQty") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                        
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="150" ItemStyle-Width="150">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="line-height:20px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="2" align="center" valign="middle">CMT & DHU</th></tr>
                      <tr style="height:100px">
                      <th width="50%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                      CMT Actual 
                          <br />
                          CMT Plan<br />
                          FOB Price PP<br />
                          FOB Stitched</td>
                      <th  width="50%" class="back-blue" align="center" valign="top">
                      CMT % 
                           <br />
                           Profit/Loss
                           <br />
                           BE CMT
                           <br />DHU %
                           </th></tr>
                      
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0" style="width:100%; height:110px">
                      <tr>
                      <td width="50%" style="border-right:1px solid #ccc; vertical-align:top; ">
                      <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height: 110px;">
                      <tr>
                      
                     <td class="bord_botts" style="text-align:center; height:27px"> <asp:Label ID="lblCMTActual" ForeColor="Black" runat="server" Text='<%#Eval("CMTActual") %>'></asp:Label> </td>
                      </tr>
                      <tr>
                   
                   <td class="bord_botts" style="text-align:center; height:27px">
                      <asp:Label ID="lblCMTPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CMTPlan") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                   
                      <td class="bord_botts" style="text-align:center; height:27px">
                       <asp:Label ID="lblFOBPrice" ForeColor="Black" runat="server" Text='<%#Eval("FOBPrice") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                 
                     
                         <td  style="text-align:center; height:29px;">
                          
                            
                          <asp:Label ID="lblFOBStitched" ForeColor="Gray" runat="server" Text='<%#Eval("FOBStitched") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                          </td>

                          <td width="50%" style="vertical-align:top;">
                          <table  cellpadding="0" cellspacing="0" width="100%" border="0" style="line-height:25px;">
                          <tr>
                         
                          <td class="bord_botts" style="text-align:center; height:27px"> <asp:Label ID="lblCMTPercent" ForeColor="Black" runat="server" Text='<%#Eval("CMTPercent") %>'></asp:Label> </td>
                          </tr>
                          <tr>
                        
                        <td class="bord_botts" style="text-align:center; height:27px;"> 
                          <asp:Label ID="lblProfitLoss" runat="server" Text='<%#Eval("ProfitLoss") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                      
                        <td class="bord_botts" style="text-align:center; height:27px"> 
                          <asp:Label ID="lblBECMT" runat="server" ForeColor="Black" style="font-weight:bold;"  Text='<%#Eval("BECMT") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                    
                         <td style="text-align:center; height:29px;"> 
                          
                          <asp:Label ID="lblDHU" runat="server" ForeColor="Black" Text='<%#Eval("DHU_Percent") %>'></asp:Label>
                          </td></tr></table></td>
                          
                       </tr>
                      </table>
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="top" />
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                    </td></tr></table>
                  </td>
                  <td valign="top" width="440">
                    <table cellpadding="0" cellspacing="0" width="100%"><tr><td class="Main-header">C 45-46</td></tr>
                  <tr><td>
                   <asp:GridView ID="gvDailyPerformance_Unit2" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" 
                      ShowHeader="true" RowStyle-Font-Size="8px" RowStyle-HorizontalAlign="Center"  HeaderStyle-Font-Size="10px" 
                           HeaderStyle-HorizontalAlign="Center"   HeaderStyle-CssClass="top-header" HeaderStyle-Height="124px"
                       RowStyle-ForeColor="#7E7E7E"  style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;" 
                          onrowdatabound="gvDailyPerformance_Unit2_RowDataBound" FRAME ="HSIDES" rules="all">
                              <Columns>
                      <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%"  style="height:120px; line-height:20px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" align="center" valign="top">Cutting</th></tr>
                      <tr class="row-no-tw">
                      <th align="center" class="back-blue" style="height:100px;" valign="top">
                      Qty Actual 
                           <br />
                           Qty Plan<br />
                           Cost Per Pc
                           </th>
                           </tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                      <asp:Label ID="lblCutQtyActual" ForeColor="black" runat="server" Text='<%#Eval("CuttingQtyActual") %>'></asp:Label> 
</td>
</tr>
<tr>
                   <td class="h35">
                          <asp:Label ID="lblCutQtyPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CuttingQtyPlan") %>'></asp:Label>
                  </td>
                  </tr>
                  <tr>
                   <td class="h35" style="border-bottom:none;">
                          <asp:Label ID="lblCutCostPerPc" ForeColor="Black" style="font-weight:bold;" runat="server" Text='<%#Eval("CuttingCostPerPc") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                      </ItemTemplate>

                      <ItemStyle VerticalAlign="Top" Height="110" />
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="150" ItemStyle-Width="150">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="height:120px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="3" align="center" valign="middle">Stitching</th></tr>
                      <tr style="height:30px">
                      <th width="33.33%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">Actual</th>
                      <th  width="33.33%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">Target</th>
                      <th  width="33.33%" class="back-blue" align="center" valign="top">Break Even</th>
                      </tr>
                      <tr style="height:70px"  class="line-height">
                      <th  width="33.33%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                      Eff(%) <br /> 
                          Ach(%) <br /> Qty
                       </th>
                       <th  width="33.33%" style=" border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                       Eff(%) 
                      <br />
                      Ach(%)
                      <br />Qty
                      </th>
                      <th  width="33.33%" class="back-blue" align="center" valign="top">Eff(%) 
                              <br />Ach(%)<br />Qty</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0" width="100%" style="line-height:20px;" height="110">
                      <tr>
                      <td align="center"  width="33.33%" style="border-right:1px solid #ccc; vertical-align:top;">
                       <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                      <tr>
                   <td class="h35">
                      <asp:Label ID="lblStchActualEff" ForeColor="Gray" style="font-weight:bold;" runat="server" Text='<%#Eval("StitchActualEff") %>'></asp:Label>
                   </td>
                   </tr>
                   <tr>
                   <td class="h35">
                   
                    <asp:Label ID="lblStchActualAch" ForeColor="Blue" style="font-weight:bold" runat="server" Text='<%#Eval("StitchActualAch") %>'></asp:Label>
                   </td>
                   
                   </tr>
                   <tr>
                   <td class="h35" style="border-bottom:none;">
                    <asp:Label ID="lblStchActualQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchActualQty") %>'></asp:Label>
                   </td>
                   
                   </tr>
                   </table>
                   
                      
                          </td>
                      
                          <td align="center"  width="33.33%" style="border-right:1px solid #ccc; vertical-align:top;">

                        <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                        <tr>
                        <td class="h35">
                         <asp:Label ID="lblStchTargetEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetEff") %>'></asp:Label>
                        </td>
                       
                        </tr>
                        <tr>
                        <td class="h35">
                        <asp:Label ID="lblStchTargetAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchTargetAch") %>'></asp:Label>
                        </td>
                        
                        </tr>
                        <tr>
                        <td class="h35" style="border-bottom:none;">
                         <asp:Label ID="lblStchTargetQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetQty") %>'></asp:Label>
                        </td>
                        
                        </tr>

                        </table>
                          
                       
                           
                       
                        </td>
                          
                           <td align="center"  width="33.33%" style=" vertical-align:top;">
                           
                          <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                        <tr>
                        <td class="h35">
                        <asp:Label ID="lblStitchBreakEvenEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenEff") %>'></asp:Label>
                        </td>
                        </tr>

                        <tr>
                        <td class="h35">
                         <asp:Label ID="lblStitchBreakEvenAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchBreakEvenAch") %>'></asp:Label>
                        
                        
                        </td>
                        </tr>

                        <tr>
                        <td class="h35" style="border-bottom:0px !important">
                        <asp:Label ID="lblStitchBreakEvenQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenQty") %>'></asp:Label>
                        </td>
                        </tr>
                        </table>
                                           
                          </td></tr>
                      </table>
                      </ItemTemplate>
                  
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" FRAME ="VOID" rules="all">
                      <tr><th width="100%" style="height:20px;" align="center" valign="middle">Finishing</th></tr>
                      <tr style="height:30px;"><th width="100%" class="back-blue" align="center" valign="top">Actual</th></tr>
                      <tr style="height:70px;">
                      <th  class="back-blue" align="center" valign="top">Eff(%) 
                          <br />Ach(%)<br />Cost(PP)<br />Tgt Qty<br />Act Qty</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                  
                      <table cellpadding="0" cellspacing="0" width="0" border="0" style=" width:100%;">
                      <tr>
                     
                     <td class="bord_botts" style="text-align:center; height:22px">  <asp:Label ID="lblFinishActualEff" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualEff") %>'></asp:Label></td>
                      </tr>
                      <tr>
                 
                   <td class="bord_botts" style="text-align:center; height:22px;">
                      <asp:Label ID="lblFinishActualAch" ForeColor="Blue" runat="server" Text='<%#Eval("FinishActualAch") %>'></asp:Label>
                      
                      </td>
                      
                      </tr>
                      <tr>
                    
                <td class="bord_botts" style="text-align:center; height:22px">
                      <asp:Label ID="lblFinishCost" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualCost") %>'></asp:Label>
                      </td>
                      
                      </tr>
                      <tr>
                     
                     <td class="bord_botts" style="text-align:center; height:22px;">
                       <asp:Label ID="lblFinishTgtQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishTargetQty") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                   
                    
                       <td style="text-align:center; height:22px;">
                          <asp:Label ID="lblFinishActQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualQty") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                      
                      </ItemTemplate>
                     <ItemStyle Height="110" VerticalAlign="top" />
                      </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="140" ItemStyle-Width="140">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" style=" line-height:20px;" width="100%" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="2" align="center" valign="middle">CMT & DHU</th></tr>
                      <tr style="height:100px">
                      <th  style="width:50%; border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                      CMT Actual 
                          <br />
                          CMT Plan<br />
                          FOB Price PP<br />
                          FOB Stitched</td>
                      <th  style="width:48%;" class="back-blue" align="center" valign="top">CMT % 
                           <br />Profit/Loss<br />BE CMT<br />DHU %</th></tr>
                      
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0" style="width:100%;">
                      <tr><td style="width:50%; border-right:1px solid #ccc; vertical-align:top;">
                      <table cellpadding="0" cellspacing="0" border="0" style="width:100%; height:110px">
                      <tr>
                     
                      <td class="bord_botts" style="text-align:center; height:27px;"> <asp:Label ID="lblCMTActual" ForeColor="Black" runat="server" Text='<%#Eval("CMTActual") %>'></asp:Label> </td>
                      </tr>
                      <tr>
                     
                     <td class="bord_botts" style="text-align:center; height:27px;"> 
                      <asp:Label ID="lblCMTPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CMTPlan") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                    
                    <td class="bord_botts" style="text-align:center; height:27px;"> 
                       <asp:Label ID="lblFOBPrice" ForeColor="Black" runat="server" Text='<%#Eval("FOBPrice") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                    
                     
                         <td  style="text-align:center; height:29px;"> 
                          
                            
                          <asp:Label ID="lblFOBStitched" ForeColor="Gray" runat="server" Text='<%#Eval("FOBStitched") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                          </td>

                          <td style="width:48%; vertical-align:top;">
                          <table  cellpadding="0" cellspacing="0" width="100%" border="0">
                          <tr>
                         
                          <td class="bord_botts" style="text-align:center; height:27px;"> <asp:Label ID="lblCMTPercent" ForeColor="Black" runat="server" Text='<%#Eval("CMTPercent") %>'></asp:Label> </td>
                          </tr>
                          <tr>
                        
                       <td class="bord_botts" style="text-align:center; height:27px;">
                          <asp:Label ID="lblProfitLoss" runat="server" Text='<%#Eval("ProfitLoss") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                   
                          <td class="bord_botts" style="text-align:center; height:27px;">
                          <asp:Label ID="lblBECMT" runat="server" ForeColor="Black" style="font-weight:bold;"  Text='<%#Eval("BECMT") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                       
                         <td  style="text-align:center; height:29px;">
                          
                          <asp:Label ID="lblDHU" runat="server" ForeColor="Black" Text='<%#Eval("DHU_Percent") %>'></asp:Label>
                          </td></tr></table>
                          
                          </td>
                          
                       </tr>
                      </table>
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                     </td></tr></table>                 
                  </td>
                  <td valign="top" style="width: 440;">
                  <table cellpadding="0" cellspacing="0" width="100%"><tr><td class="Main-header">B 45</td></tr>
                  <tr><td>
                   <asp:GridView ID="gvDailyPerformance_Unit3" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" 
                      ShowHeader="true" RowStyle-Font-Size="8px" RowStyle-HorizontalAlign="Center"  HeaderStyle-Font-Size="10px" 
                           HeaderStyle-HorizontalAlign="Center"   HeaderStyle-CssClass="top-header" HeaderStyle-Height="124px"
                       RowStyle-ForeColor="#7E7E7E"  style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;" 
                          onrowdatabound="gvDailyPerformance_Unit3_RowDataBound">
                          <Columns>
                      <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%"  style="height:120px; line-height:20px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" align="center" valign="top">Cutting</th></tr>
                      <tr class="row-no-tw">
                      <th align="center" class="back-blue" style="height:100px;" valign="top">
                      Qty Actual 
                           <br />
                           Qty Plan<br />
                           Cost Per Pc
                           </th>
                           </tr>
                         </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                      <asp:Label ID="lblCutQtyActual" ForeColor="black" runat="server" Text='<%#Eval("CuttingQtyActual") %>'></asp:Label> 
                    </td>
                    <tr>
                    <td class="h35">
                     <asp:Label ID="lblCutQtyPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CuttingQtyPlan") %>'></asp:Label>
                    
                    </td>
                   
                    </tr>
                    <tr>
                    <td class="h35" style="border-bottom:none;">
                     <asp:Label ID="lblCutCostPerPc" ForeColor="Black" style="font-weight:bold;" runat="server" Text='<%#Eval("CuttingCostPerPc") %>'></asp:Label>
                    </td>
                    </tr>
                  </table>
                         
                  
                          
                          
                     
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                  
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="150" ItemStyle-Width="150">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="height:120px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="3" align="center" valign="middle">Stitching</th></tr>
                      <tr style="height:30px">
                      <th width="33.33%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">Actual</th>
                      <th width="33.33%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">Target</th>
                      <th width="33.33%"  class="back-blue" align="center" valign="top">Break Even</th>
                      </tr>
                      <tr style="height:70px"  class="line-height">
                      <th width="33.33%" style=" border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                      Eff(%) <br /> 
                          Ach(%) <br /> Qty
                       </th>
                       <th width="33.33%" style=" border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                       Eff(%) 
                      <br />
                      Ach(%)
                      <br />Qty
                      </th>
                      <th width="33.33%" class="back-blue" align="center" valign="top">Eff(%) 
                              <br />Ach(%)<br />Qty</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0" style="height:110px;" width="100%" >
                      <tr>
                      <td align="center" width="33.33%" style=" border-right:1px solid #ccc; vertical-align:top">

                      <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">


                      <asp:Label ID="lblStchActualEff" ForeColor="Gray" style="font-weight:bold;" runat="server" Text='<%#Eval("StitchActualEff") %>'></asp:Label>
                         </td>
                         </tr>

                         <tr>
                         <td class="h35">
                         <asp:Label ID="lblStchActualAch" ForeColor="Blue" style="font-weight:bold" runat="server" Text='<%#Eval("StitchActualAch") %>'></asp:Label>
                         </td>
                         </tr>

                         <tr>
                         <td class="h35" style="border-bottom:0px !important">
                          <asp:Label ID="lblStchActualQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchActualQty") %>'></asp:Label>
                         </td>
                         </tr>
                         </table>
                      
                         
                          </td>
                      
                          <td align="center" width="33.33%" style=" border-right:1px solid #ccc; vertical-align:top;">
                          
                       <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                          <asp:Label ID="lblStchTargetEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetEff") %>'></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td class="h35">
                         <asp:Label ID="lblStchTargetAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchTargetAch") %>'></asp:Label>
                        </td>
                        </tr>

                        <tr>
                        <td class="h35" style="border-bottom:0px !important">
                         <asp:Label ID="lblStchTargetQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetQty") %>'></asp:Label>
                        </td>
                        </tr>
                       </table>
                        </td>
                          
                           <td align="center" width="33.33%" style="vertical-align:top;">
                           <table width="100%" cellpadding="0" cellspacing="0" border="0">
                           
                           <tr>
                           <td class="h35">
                            <asp:Label ID="lblStitchBreakEvenEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenEff") %>'></asp:Label>
                           </td>
                           
                           </tr>
                             <tr>
                           <td class="h35">
                            <asp:Label ID="lblStitchBreakEvenAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchBreakEvenAch") %>'></asp:Label>
                           </td>
                           
                           </tr>
                             <tr>
                           <td class="h35" style="border-bottom:none;">
                           <asp:Label ID="lblStitchBreakEvenQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenQty") %>'></asp:Label>
                           </td>
                           
                           </tr>

                           
                           </table>
                       
                        
                      
                          </td></tr>
                      </table>
                      </ItemTemplate>
                      <ItemStyle Height="110" />
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="height:120px;" FRAME ="VOID" rules="all">
                      <tr><th style="width:100%; height:20px;" align="center" valign="middle">Finishing</th></tr>
                      <tr style="height:30px;"><th style="width:60px;" class="back-blue" align="center" valign="top">Actual</th></tr>
                      <tr style="height:70px;">
                      <th class="back-blue" align="center" valign="top">Eff(%) 
                          <br />Ach(%)<br />Cost(PP)<br />Tgt Qty<br />Act Qty</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                     
                      <table cellpadding="0" cellspacing="0" width="0" border="0" style="width:100%; height:110;">
                      <tr>
                      
                      <td class="bord_botts" style="text-align:center; height:22px;"> <asp:Label ID="lblFinishActualEff" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualEff") %>'></asp:Label></td>
                      </tr>
                      <tr>
            
                      <td class="bord_botts" style="text-align:center; height:22px;">
                      <asp:Label ID="lblFinishActualAch" ForeColor="Blue" runat="server" Text='<%#Eval("FinishActualAch") %>'></asp:Label>
                      
                      </td>
                      
                      </tr>
                      <tr>
                 
                   <td class="bord_botts" style="text-align:center; height:22px;">
                      <asp:Label ID="lblFinishCost" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualCost") %>'></asp:Label>
                      </td>
                      
                      </tr>
                      <tr>
                    
                   <td class="bord_botts" style="text-align:center; height:22px;">
                       <asp:Label ID="lblFinishTgtQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishTargetQty") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                    
                    
                       <td  style="text-align:center; height:22px;">
                          <asp:Label ID="lblFinishActQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualQty") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                     
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="140" ItemStyle-Width="140">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" style="height:120px;  line-height:20px;" width="100%" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="2" align="center" valign="middle">CMT & DHU</th></tr>
                      <tr style="height:100px">
                      <th  style="width:50%; border-right:1px solid #fff;" class="back-blue" align="center" valign="top">
                      CMT Actual 
                          <br />
                          CMT Plan<br />
                          FOB Price PP<br />
                          FOB Stitched</td>
                      <th  style="width:50%;" class="back-blue" align="center" valign="top">CMT % 
                           <br />Profit/Loss<br />BE CMT<br />DHU %</th></tr>
                      
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0" style="width:100%; ">
                      <tr>
                      <td style="width:50%; border-right:1px solid #ccc; vertical-align:top">
                      <table cellpadding="0" cellspacing="0" border="0" style=" width:100%; line-height:25px;" height="110">
                      <tr>
                      
                      <td class="bord_botts" style="text-align:center; height:27px;"> <asp:Label ID="lblCMTActual" ForeColor="Black" runat="server" Text='<%#Eval("CMTActual") %>'></asp:Label> </td>
                      </tr>
                      <tr>
                      
                     <td class="bord_botts" style="text-align:center; height:27px;"> 
                      <asp:Label ID="lblCMTPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CMTPlan") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                   
                     <td class="bord_botts" style="text-align:center; height:27px;"> 
                       <asp:Label ID="lblFOBPrice" ForeColor="Black" runat="server" Text='<%#Eval("FOBPrice") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                 
                     
                         <td  style="text-align:center; height:27px;"> 
                          
                            
                          <asp:Label ID="lblFOBStitched" ForeColor="Gray" runat="server" Text='<%#Eval("FOBStitched") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                          </td>

                          <td style="width:49%; vertical-align:top;">
                          <table  cellpadding="0" cellspacing="0" width="100%" border="0">
                          <tr>
                          
                          <td class="bord_botts" style="text-align:center; height:27px;">  <asp:Label ID="lblCMTPercent" ForeColor="Black" runat="server" Text='<%#Eval("CMTPercent") %>'></asp:Label> </td>
                          </tr>
                          <tr>
                     
                          <td class="bord_botts" style="text-align:center; height:27px;"> 
                          <asp:Label ID="lblProfitLoss" runat="server" Text='<%#Eval("ProfitLoss") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                      
                         <td class="bord_botts" style="text-align:center; height:27px;"> 
                          <asp:Label ID="lblBECMT" runat="server" ForeColor="Black" style="font-weight:bold;"  Text='<%#Eval("BECMT") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                     
                          <td style="text-align:center; height:27px;"> 
                          
                          <asp:Label ID="lblDHU" runat="server" ForeColor="Black" Text='<%#Eval("DHU_Percent") %>'></asp:Label>
                          </td></tr></table></td>
                          
                       </tr>
                      </table>
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                    </td></tr></table>
                  </td>
                  <td valign="top" width="430">
                   <table cellpadding="0" cellspacing="0" width="100%"><tr><td class="Main-header">BIPL</td></tr>
                  <tr><td>
                   <asp:GridView ID="gvDailyPerformance_Unit4" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" 
                      ShowHeader="true" RowStyle-Font-Size="8px" RowStyle-HorizontalAlign="Center"  HeaderStyle-Font-Size="10px" 
                           HeaderStyle-HorizontalAlign="Center"   HeaderStyle-CssClass="top-header" HeaderStyle-Height="124px"
                       RowStyle-ForeColor="#7E7E7E" 
                          style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;" 
                          onrowdatabound="gvDailyPerformance_Unit4_RowDataBound" FRAME ="HSIDES" rules="all">
                <Columns>
                      <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%"  style="height:120px; line-height:20px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" align="center" valign="middle">Cutting</th></tr>
                      <tr class="row-no-tw">
                      <th align="center" class="back-blue" style="height:100px;" valign="top">
                      Qty Actual 
                           <br />
                           Qty Plan<br />
                           Cost Per Pc
                           </th>
                           </tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                     <asp:Label ID="lblCutQtyActual" ForeColor="black" runat="server" Text='<%#Eval("CuttingQtyActual") %>'></asp:Label> 
                   </td>
                   </tr>

                   <tr>
                   <td class="h35">
                    <asp:Label ID="lblCutQtyPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CuttingQtyPlan") %>'></asp:Label>
                   </td>
                   
                   </tr>

                   <tr>
                   <td class="h35" style="border-bottom:0px !important">
                    <asp:Label ID="lblCutCostPerPc" ForeColor="Black" style="font-weight:bold;" runat="server" Text='<%#Eval("CuttingCostPerPc") %>'></asp:Label>
                   </td>
                   </tr>
                   </table>
                 
                    
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="150" ItemStyle-Width="150">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="height:120px;" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="3" align="center" valign="middle">Stitching</th></tr>
                      <tr style="height:30px">
                      <th width="33.33%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">Actual</th>
                      <th width="33.33%" style=" border-right:1px solid #fff" class="back-blue" align="center" valign="top">Target</th>
                      <th width="33.33%" class="back-blue" align="center" valign="top">Break Even</th>
                      </tr>
                      <tr style="height:70px" class="line-height">
                      <th width="33.33%" style="border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                      Eff(%) <br /> 
                          Ach(%) <br /> Qty
                       </th>
                       <th width="33.33%" style=" border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                       Eff(%) 
                      <br />
                      Ach(%)
                      <br />Qty
                      </th>
                      <th width="33.33%" class="back-blue" align="center" valign="top">Eff(%) 
                              <br />Ach(%)<br />Qty</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0" height="110" width="100%">
                      <tr>
                      <td align="center" width="33.33%" style=" border-right:1px solid #ccc; vertical-align:top;">
                         <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                    <asp:Label ID="lblStchActualEff" ForeColor="Gray" style="font-weight:bold;" runat="server" Text='<%#Eval("StitchActualEff") %>'></asp:Label>
                   </td>
                   </tr>

                   <tr>
                   <td class="h35">
                   <asp:Label ID="lblStchActualAch" ForeColor="Blue" style="font-weight:bold" runat="server" Text='<%#Eval("StitchActualAch") %>'></asp:Label>
                   </td>
                   </tr>

                   <tr>
                   <td class="h35">
                    <asp:Label ID="lblStchActualQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchActualQty") %>'></asp:Label>
                   </td>
                   </tr>
                   </table>
                    
                         
                        
                          </td>
                      
                          <td align="center" width="33.33%" style="border-right:1px solid #ccc; vertical-align:top;">
                       <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                          <asp:Label ID="lblStchTargetEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetEff") %>'></asp:Label>
                         </td>
                         </tr>
                         <tr>
                         <td class="h35">
                         <asp:Label ID="lblStchTargetAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchTargetAch") %>'></asp:Label>
                         </td>
                         
                         </tr>
                          <tr>
                          <td class="h35">
                          <asp:Label ID="lblStchTargetQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchTargetQty") %>'></asp:Label>
                          </td>
                          
                          </tr>
                          
                      </table>
                          
                         
                        </td>
                          
                             <td align="center" width="33.33%" style=" vertical-align:top;">
                       <table width="100%" cellpadding="0" cellspacing="0" border="0" frame="void" rules="all">
                   <tr>
                   <td class="h35">
                           
                           <asp:Label ID="lblStitchBreakEvenEff" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenEff") %>'></asp:Label>
                         </td>
                         </tr>

                         <tr>
                         <td class="h35">
                          <asp:Label ID="lblStitchBreakEvenAch" ForeColor="Black" style="font-weight:bold" runat="server" Text='<%#Eval("StitchBreakEvenAch") %>'></asp:Label>
                         </td>
                         </tr>
                         <tr>
                         <td class="h35">
                          <asp:Label ID="lblStitchBreakEvenQty" ForeColor="Gray" runat="server" Text='<%#Eval("StitchBreakEvenQty") %>'></asp:Label>
                         </td>
                         </tr>
                         </table>
                         
                        
                          
                         
                      
                          </td></tr>
                      </table>
                      </ItemTemplate>
                      <ItemStyle Height="110" />
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="60" ItemStyle-Width="60">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%" style="height:120px;" FRAME ="VOID" rules="all">
                      <tr><th style="width:100%; height:20px;" align="center" valign="middle">Finishing</th></tr>
                      <tr style="height:30px;"><th style="width:100%;" class="back-blue" align="center" valign="top">Actual</th></tr>
                      <tr style="height:70px;">
                      <th style="width:100%;" class="back-blue" align="center" valign="top">Eff(%) 
                          <br />Ach(%)<br />Cost(PP)<br />Tgt Qty<br />Act Qty</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                     
                      <table cellpadding="0" cellspacing="0" width="0" border="0" style="height:110; width:100%; line-height:20px;">
                      <tr>
                     
                      <td class="bord_botts" style="text-align:center; height:22px;">  <asp:Label ID="lblFinishActualEff" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualEff") %>'></asp:Label></td>
                      </tr>
                      <tr>
                    
                    <td class="bord_botts" style="text-align:center; height:22px;">
                      <asp:Label ID="lblFinishActualAch" ForeColor="Blue" runat="server" Text='<%#Eval("FinishActualAch") %>'></asp:Label>
                      
                      </td>
                      
                      </tr>
                      <tr>
                     
                     <td class="bord_botts" style="text-align:center; height:22px;">
                      <asp:Label ID="lblFinishCost" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualCost") %>'></asp:Label>
                      </td>
                      
                      </tr>
                      <tr>
                     
                  <td class="bord_botts" style="text-align:center; height:22px;">
                       <asp:Label ID="lblFinishTgtQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishTargetQty") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                 
                    <td  style="text-align:center; height:22px;">
                          <asp:Label ID="lblFinishActQty" ForeColor="Black" runat="server" Text='<%#Eval("FinishActualQty") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                         
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="140" ItemStyle-Width="140">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" style="height:120px; line-height: 20px;" width="100%" FRAME ="VOID" rules="all">
                      <tr><th style="height:20px;" colspan="2" align="center" valign="middle">CMT & DHU</th></tr>
                      <tr style="height:100px">
                      <th width="50%" style=" border-right:1px solid #fff" class="back-blue" align="center" valign="top">
                      CMT Actual 
                          <br />
                          CMT Plan<br />
                          FOB Price PP<br />
                          FOB Stitched</td>
                      <th  width="50%" class="back-blue" align="center" valign="top">CMT % 
                           <br />Profit/Loss<br />BE CMT<br />DHU %</th></tr>
                      
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                       <table cellpadding="0" cellspacing="0" style="height:110; width:100%">
                      <tr>
                      <td width="50%" style=" border-right:1px solid #ccc; vertical-align:top;">
                      <table cellpadding="0" cellspacing="0" border="0" height="110px" style=" width:100%; height:110px;">
                      <tr>
                     
                     <td class="bord_botts" style="text-align:center; height:27px;"> <asp:Label ID="lblCMTActual" ForeColor="Black" runat="server" Text='<%#Eval("CMTActual") %>'></asp:Label> </td>
                      </tr>
                      <tr>
                   
                     <td class="bord_botts" style="text-align:center; height:27px;"> 
                      <asp:Label ID="lblCMTPlan" ForeColor="Gray" runat="server" Text='<%#Eval("CMTPlan") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                 
                    <td class="bord_botts" style="text-align:center; height:27px;">
                       <asp:Label ID="lblFOBPrice" ForeColor="Black" runat="server" Text='<%#Eval("FOBPrice") %>'></asp:Label>
                      </td>
                      </tr>
                      <tr>
                   
                     
                         <td style="text-align:center; height:27px;">
                          
                            
                          <asp:Label ID="lblFOBStitched" ForeColor="Gray" runat="server" Text='<%#Eval("FOBStitched") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                          </td>

                          <td width="50%" style="vertical-align:top;">
                          <table  cellpadding="0" cellspacing="0" width="100%" border="0">
                          <tr>
                       
                         <td class="bord_botts" style="text-align:center; height:27px;"> <asp:Label ID="lblCMTPercent" ForeColor="Black" runat="server" Text='<%#Eval("CMTPercent") %>'></asp:Label> </td>
                          </tr>
                          <tr>
                      
                         <td class="bord_botts" style="text-align:center; height:27px;">
                          <asp:Label ID="lblProfitLoss" runat="server" Text='<%#Eval("ProfitLoss") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                      
                       <td class="bord_botts" style="text-align:center; height:27px;">
                          <asp:Label ID="lblBECMT" runat="server" ForeColor="Black" style="font-weight:bold;"  Text='<%#Eval("BECMT") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                      
                          <td style="text-align:center; height:27px;">
                          
                          <asp:Label ID="lblDHU" runat="server" ForeColor="Black" Text='<%#Eval("DHU_Percent") %>'></asp:Label>
                          </td></tr></table></td>
                          
                       </tr>
                      </table>
                      </ItemTemplate>
                      <ItemStyle Height="110" VerticalAlign="Top" />
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                     </td></tr></table>
                  </td>

                   <td valign="top" width="519">
                   <table cellpadding="0" cellspacing="0" width="100%"><tr><td class="Main-header">BIPL Result @Higher Achievements</td></tr>
                  <tr><td>
                    <asp:GridView ID="gvCMTAchievement" runat="server" AutoGenerateColumns="false" 
                          Width="100%" ShowFooter="true" 
                      ShowHeader="true" RowStyle-Font-Size="8px" RowStyle-HorizontalAlign="Center"  HeaderStyle-Font-Size="10px" 
                           HeaderStyle-HorizontalAlign="Center"   HeaderStyle-CssClass="top-header" HeaderStyle-Height="124px"
                       RowStyle-ForeColor="#7E7E7E" 
                          style=" table-layout:fixed; border-collapse:collapse; padding:0px; margin:0px;" 
                          onrowdatabound="gvCMTAchievement_RowDataBound">
                      <Columns>
                      <asp:TemplateField HeaderStyle-Width="170">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" FRAME ="VOID" rules="all" style=" line-height:20px;" width="100%">
                      <tr><th colspan="3" style="height:20px;" align="center">CMT @90% Ach</th></tr>
                      <tr style="height:100px;"><th width="33.33%" height="100px" style=" border-right:1px solid #fff" align="center" class="back-blue">CMT Plan</th>
                      <th width="33.33%" height="100px" style=" border-right:1px solid #fff" align="center" class="back-blue">FOB Price PP (FOB Stitched)</th>
                      <th width="33.33%" height="100px" align="center" class="back-blue">CMT % (Profit / Loss)</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                      <table width="100%" cellpadding="0" cellspacing="0">
                      <tr>
                      <td align="center" height="110" width="33.33%" style="border-right:1px solid #ccc"><asp:Label ID="lblCMTPlan90" runat="server" Text='<%#Eval("CMTPlan_90") %>'></asp:Label></td>
                      <td align="center" height="110" width="33.33%" style=" border-right:1px solid #ccc; vertical-align:top;">
                      <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                      
                      <tr>
                      <td class="h53">
                      <asp:Label ID="lblFOBPrice90" runat="server" Text='<%#Eval("FOBPrice_90") %>'></asp:Label>
                      </td>
                       
                      </tr>
                       <tr>
                      <td class="h53">
                      <asp:Label ID="lblFOBStitch90" runat="server" Text='<%#Eval("FOBStitched_90") %>'></asp:Label>
                      </td>
                      
                      </tr>
                      
                      </table>

                          
                          </td>
                      <td align="center" width="33.33%" style="vertical-align:top;">

                      <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                      
                      <tr>
                      <td class="h53">
                       <asp:Label ID="lblCMTPercent90" runat="server" Text='<%#Eval("CMTPercent_90") %>'></asp:Label>
                      </td>
                      </tr>

                      <tr>
                      <td class="h53">
                       <asp:Label ID="lblProfitLoss_90" runat="server" Text='<%#Eval("ProfitLoss_90") %>'></asp:Label>
                      </td>
                      </tr>
                      </table>
                    
                         
                         
                          </td></tr>

                          

                      </table>
                      </ItemTemplate>
                     <ItemStyle Height="114" />
                      </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="170" ItemStyle-Width="170">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" FRAME ="VOID" rules="all" style=" line-height:20px;" width="100%">
                      <tr><th colspan="3" style="height:20px;" align="center">CMT @95% Ach</th></tr>
                      <tr style="height:100px;"><th width="33.33%" height="100px" style=" border-right:1px solid #fff" align="center" class="back-blue">CMT Plan</th>
                      <th width="33.33%" height="100px" style=" border-right:1px solid #fff" align="center" class="back-blue">FOB Price PP (FOB Stitched)</th>
                      <th width="33.33%" height="100px" align="center" class="back-blue">CMT % (Profit / Loss)</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                      <table cellpadding="0" cellspacing="0" width="100%">
                      <tr>
                      <td align="center" height="110" style=" border-right:1px solid #cccccc" width="33.33%">
                      
                      <asp:Label ID="lblCMTPlan95" runat="server" Text='<%#Eval("CMTPlan_95") %>'></asp:Label></td>
                     <td align="center" width="33.33%" height="110" style=" border-right:1px solid #cccccc; vertical-align:top;">
                      <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                      
                      <tr>
                      <td class="h53">
                      
                      <asp:Label ID="lblFOBPrice95" runat="server" Text='<%#Eval("FOBPrice_95") %>'></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td class="h53">
                         <asp:Label ID="lblFOBStitch95" runat="server" Text='<%#Eval("FOBStitched_95") %>'></asp:Label>
                        </td>
                        </tr>
                        </table>
                         
                          
                          </td>
                        <td align="center" width="33.33%" style=" vertical-align:top;">
                      <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                      
                      <tr>
                      <td class="h53">
                      
                      <asp:Label ID="lblCMTPercent95" runat="server" Text='<%#Eval("CMTPercent_95") %>'></asp:Label>
                          </td>
                          </tr>
                          <tr>
                          <td class="h53">
                           <asp:Label ID="lblProfitLoss_95" runat="server" Text='<%#Eval("ProfitLoss_95") %>'></asp:Label>
                          </td>
                          </tr>
                          </table>
                         </td></tr>
                      </table>
                      </ItemTemplate>
                       <ItemStyle Height="114" />
                      </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="170" ItemStyle-Width="170">
                      <HeaderTemplate>
                      <table cellpadding="0" cellspacing="0" FRAME ="VOID" rules="all" style=" line-height:20px;">
                      <tr><th colspan="3" style="height:20px;" align="center">CMT @100% Ach</th></tr>
                      <tr style="height:100px;"><th width="33.33%" style=" border-right:1px solid #fff " align="center" class="back-blue">CMT Plan</th>
                      <th width="33.33%" style="border-right:1px solid #fff" align="center" class="back-blue">FOB Price PP (FOB Stitched)</th>
                      <th width="33.33%" align="center" class="back-blue">CMT % (Profit / Loss)</th></tr>
                      </table>
                      </HeaderTemplate>
                      <ItemTemplate>
                      <table  cellpadding="0" cellspacing="0" width="100%">
                      <tr>
                      <td align="center" height="110" width="33.33%" style=" border-right:1px solid #cccccc"><asp:Label ID="lblCMTPlan100" runat="server" Text='<%#Eval("CMTPlan_100") %>'></asp:Label></td>
                        <td align="center" height="108" width="33.33%" style=" border-right:1px solid #cccccc; vertical-align:top;">
                      <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                      
                      <tr>
                      <td class="h53">
                      
                      
                      <asp:Label ID="lblFOBPrice100" runat="server" Text='<%#Eval("FOBPrice_100") %>'></asp:Label>
                      
                      </td>
                      </tr>
                      <tr>
                      <td class="h53">
                       <asp:Label ID="lblFOBStitch100" runat="server" Text='<%#Eval("FOBStitched_100") %>'></asp:Label>
                      </td>
                      </tr>
                      </table>
                         </td>
                      <td align="center" height="110" width="33.33%" style="vertical-align:top;">
                      <table width="100%" cellpadding="0" cellspacing="0" frame="void" rules="all">
                      
                      <tr>
                      <td class="h53">
                      
                      <asp:Label ID="lblCMTPercent100" runat="server" Text='<%#Eval("CMTPercent_100") %>'></asp:Label>
                        </td>
                       </tr>
                       <tr>
                       <td class="h53">
                        <asp:Label ID="lblProfitLoss_100" runat="server" Text='<%#Eval("ProfitLoss_100") %>'></asp:Label>
                       </td>
                       </tr>
                       </table>
                         </td></tr>
                      </table>
                      </ItemTemplate>
                       <ItemStyle Height="114" />
                      </asp:TemplateField>

                       
                      </Columns>
                    </asp:GridView>  
                     </td></tr></table>
                  </td>
                </tr>
              </table>
        </td></tr>

        
    </table>