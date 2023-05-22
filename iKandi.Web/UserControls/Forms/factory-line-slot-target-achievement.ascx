<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="factory-line-slot-target-achievement.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.factory_line_slot_target_achievement" %>


<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
      body
      {
          font-family: Arial;
          padding:0px 10px;
      }
    .txt
    {
      color: #7E7E7E;
      text-transform: none;
      font-family: Arial;
    }
.taskdelay td
{
    border-color:Gray;
    font-family: Arial;
}
.taskdelay th
{
    border-color:#bfbfbf;
    font-family: Arial;
}
th
{
    font-size:11px;
}
td
{
    text-align:center;
    border-color: gray
}
.header-right
{
    border-right:1px solid #405D99;
}
.item-right
{
    border-right:1px solid white;
}
  </style>


   <table cellpadding="0" cellspacing="0" border="0" style="width:auto">
      <tr>
      <td style="vertical-align:top; width:100px;">
      <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px; border-right:1px solid white">
      &nbsp;
      </th>
      </tr>
      <tr>
      <td>
      <asp:GridView runat="server" ID="grdFactorytargetActualDate" ShowHeader="true" AutoGenerateColumns="false" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" Width="100%" OnRowDataBound="grdFactorytargetActualDate_RowDataBound">
            <Columns>
            
            <asp:TemplateField HeaderText="Date">
               <ItemTemplate>
                 <asp:Label runat="server" ID="lblFactorytargetActualDate" Text='<%# (Convert.ToDateTime(Eval("AchivementDate")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("AchivementDate")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("AchivementDate")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("AchivementDate")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("AchivementDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("AchivementDate")).ToString("dd MMM") : Convert.ToDateTime(Eval("AchivementDate")).ToString("dd MMM")%>'></asp:Label>
               </ItemTemplate>
               <ItemStyle Height="44px" CssClass="item-right" />
            <HeaderStyle Height="56px" CssClass="header-right" />
            </asp:TemplateField>
            </Columns>
            
            
            </asp:GridView>
      </td>
        </tr>
      </table>
      </td>
      <td style="vertical-align:top;">
      <table cellpadding="0" cellspacing="0" border="0">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px; border-right:1px solid white">
      
      C-45-46
      </th>
      
      </tr>
      <tr>
      <td>
       <asp:GridView runat="server" ID="grdC4546FactorytargetActual" ShowHeader="true" AutoGenerateColumns="false" HeaderStyle-Height="20px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdC4546FactorytargetActual_RowDataBound">
         <Columns>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 1 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine1" Text='<%# Eval("Line1Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 2 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine2" Text='<%# Eval("Line2Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 3 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine3" Text='<%# Eval("Line3Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 4 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine4" Text='<%# Eval("Line4Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 5 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine5" Text='<%# Eval("Line5Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 6 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine6" Text='<%# Eval("Line6Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 7 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine7" Text='<%# Eval("Line7Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 8 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine8" Text='<%# Eval("Line8Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 9 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine9" Text='<%# Eval("Line9Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 10 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine10" Text='<%# Eval("Line10Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 11 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine11" Text='<%# Eval("Line11Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 12 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine12" Text='<%# Eval("Line12Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 13 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine13" Text='<%# Eval("Line13Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 14 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine14" Text='<%# Eval("Line14Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 15 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactoryAchLine15" Text='<%# Eval("Line15Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Total <br />
               Tgt. <br />
Act. <br />
Ach
            </HeaderTemplate>
            <HeaderStyle CssClass="header-right" />
            <ItemTemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
               <tr>
                  <td style="border-bottom:1px solid #ddd">
                  <asp:Label runat="server" ID="lblC4546FactoryTgtTotal" Text='<%# Eval("lineTotalTgt") %>'></asp:Label>
                  </td>
               
               </tr>
            <tr>
                  <td style="border-bottom:1px solid #ddd">
                  <asp:Label runat="server" ID="lblC4546FactoryActTotal" Text='<%# Eval("lineTotalAct") %>'></asp:Label>
                  </td>
               
               </tr>
               <tr>
                  <td>
                  <asp:Label runat="server" ID="lblC4546FactoryAchTotal" Text='<%# Eval("lineTotalAch") %>'></asp:Label>
                  </td>
               
               </tr>
            </table>
            
            
            </ItemTemplate>
            </asp:TemplateField>
         
         </Columns>
      
      </asp:GridView>
      </td>
      
      </tr>
      
      </table>
       
      </td>
      <td style="vertical-align:top;">
          <table cellpadding="0" cellspacing="0" border="0">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px;">
      
      C-47
      </th>
      
      </tr>
      <tr>
      <td>
        <asp:GridView runat="server" ID="grdC47FactorytargetActual" ShowHeader="true" AutoGenerateColumns="false" HeaderStyle-Height="20px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdC47FactorytargetActual_RowDataBound">
         <Columns>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 1 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine1" Text='<%# Eval("Line1Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 2 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine2" Text='<%# Eval("Line2Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 3 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine3" Text='<%# Eval("Line3Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 4 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine4" Text='<%# Eval("Line4Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 5 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine5" Text='<%# Eval("Line5Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 6 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine6" Text='<%# Eval("Line6Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 7 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine7" Text='<%# Eval("Line7Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 8 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine8" Text='<%# Eval("Line8Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 9 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine9" Text='<%# Eval("Line9Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 10 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine10" Text='<%# Eval("Line10Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 11 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine11" Text='<%# Eval("Line11Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 12 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine12" Text='<%# Eval("Line12Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 13 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine13" Text='<%# Eval("Line13Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 14 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine14" Text='<%# Eval("Line14Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 15 <br />
               Ach.
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactoryAchLine15" Text='<%# Eval("Line15Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Total <br />
               Tgt. <br />
Act. <br />
Ach.
            </HeaderTemplate>
            <HeaderStyle CssClass="header-right" />
            <ItemTemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
               <tr>
                  <td style="border-bottom:1px solid #dddddd">
                  <asp:Label runat="server" ID="lblC47FactoryTgtTotal" Text='<%# Eval("lineTotalTgt") %>'></asp:Label>
                  </td>
               
               </tr>
            <tr>
                  <td style="border-bottom:1px solid #dddddd">
                  <asp:Label runat="server" ID="lblC47FactoryActTotal" Text='<%# Eval("lineTotalAct") %>'></asp:Label>
                  </td>
               
               </tr>
               <tr>
                  <td>
                  <asp:Label runat="server" ID="lblC47FactoryAchTotal" Text='<%# Eval("lineTotalAch") %>'></asp:Label>
                  </td>
               
               </tr>
            </table>
            
            
            </ItemTemplate>
            </asp:TemplateField>
         
         </Columns>
      
      </asp:GridView>
      </td>
      </tr>
      </table>
      </td>
      <td style="vertical-align:top; width:70px;">
      <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px; border-left:1px solid white">
      
     BIPL
      </th>
      
      </tr>
      <tr>
      <td>
      <asp:GridView runat="server" ID="grdFactorytargetActualBipl" ShowHeader="true" AutoGenerateColumns="false" Width="100%"  HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdFactorytargetActualBipl_RowDataBound">
      <Columns>
         <asp:TemplateField>
           <HeaderTemplate>
             
           Tgt. <br />
Act.<br />
Ach.
           </HeaderTemplate>
           <HeaderStyle Height="56px" />
         <ItemTemplate>
         <table cellpadding="0" cellspacing="0" width="100%" border="0">
         <tr>
         <td style="border-bottom:1px solid #dddddd">
         <asp:Label runat="server" ID="lblFactorytargetActualBiplTgt" Text='<%# Eval("lineTotalTgt") %>'></asp:Label>
         </td>
         </tr>
          <tr>
         <td style="border-bottom:1px solid #dddddd">
          <asp:Label runat="server" ID="lblFactorytargetActualBiplAct" Text='<%# Eval("lineTotalAct") %>'></asp:Label>
         </td>
         </tr>
          <tr>
         <td>
         <asp:Label runat="server" ID="lblFactorytargetActualBiplAch" Text='<%# Eval("lineTotalAch") %>'></asp:Label>
         </td>
         </tr>
            
        </table>
         
         </ItemTemplate>
         </asp:TemplateField>
      </Columns>

      </asp:GridView>

      </td>
      </tr>
      </table>
      
      </td>
      </tr>

   </table>
   <br />

    <table cellpadding="0" cellspacing="0" border="0" style="width:auto">
      <tr>
      <td style="vertical-align:top; width:150px;">
      <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px; border-right:1px solid white">
      &nbsp;
      </th>
      </tr>
      <tr>
      <td>
      <asp:GridView runat="server" ID="grdFactorytargetSlot" ShowHeader="true" AutoGenerateColumns="false" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" Width="100%" OnRowDataBound="grdFactorytargetSlot_RowDataBound">
            <Columns>
            
            <asp:TemplateField HeaderStyle-Width="33%">
               <ItemTemplate>           
                S <asp:Label runat="server" ID="lblFactorytargetSlotNo" Text='<%# Eval("slotNo") %>'></asp:Label>      
                </ItemTemplate>
            
            <HeaderStyle Height="20px" CssClass="header-right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="67%">
               <ItemTemplate>           
                Month <asp:Label runat="server" ID="lblNoOfMonth" Text='<%# Eval("No_Of_Months") %>'></asp:Label>      
                </ItemTemplate>
              
            <HeaderStyle Height="17px" CssClass="header-right" />
            </asp:TemplateField>
            </Columns>
            
            
            </asp:GridView>
      </td>
        </tr>
      </table>
      </td>
      <td style="vertical-align:top;">
      <table cellpadding="0" cellspacing="0" border="0">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px; border-right:1px solid white">
      
      C-45-46
      </th>
      
      </tr>
      <tr>
      <td>
       <asp:GridView runat="server" ID="grdC4546FactorytargetActualSlot" ShowHeader="true" AutoGenerateColumns="false" HeaderStyle-Height="20px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdC4546FactorytargetActualSlot_RowDataBound">
         <Columns>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 1 
              
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine1" Text='<%# Eval("Line1Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 2 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine2" Text='<%# Eval("Line2Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 3 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine3" Text='<%# Eval("Line3Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 4
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine4" Text='<%# Eval("Line4Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 5 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine5" Text='<%# Eval("Line5Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 6 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine6" Text='<%# Eval("Line6Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 7 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine7" Text='<%# Eval("Line7Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 8 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine8" Text='<%# Eval("Line8Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 9 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine9" Text='<%# Eval("Line9Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 10
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine10" Text='<%# Eval("Line10Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 11
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine11" Text='<%# Eval("Line11Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 12 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine12" Text='<%# Eval("Line12Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 13
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine13" Text='<%# Eval("Line13Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 14 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine14" Text='<%# Eval("Line14Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 15 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC4546FactorySlotAchLine15" Text='<%# Eval("Line15Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Total
            </HeaderTemplate>
            <HeaderStyle CssClass="header-right" />
            <ItemTemplate>
           
                  <asp:Label runat="server" ID="lblC4546FactorySlotAchTotal" Text='<%# Eval("lineTotalAch") %>'></asp:Label>
                 
            
            </ItemTemplate>
            </asp:TemplateField>
         
         </Columns>
      
      </asp:GridView>
      </td>
      
      </tr>
      
      </table>
       
      </td>
      <td style="vertical-align:top;">
          <table cellpadding="0" cellspacing="0" border="0">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px;">
      
      C-47
      </th>
      
      </tr>
      <tr>
      <td>
        <asp:GridView runat="server" ID="grdC47FactorytargetActualSlot" ShowHeader="true" AutoGenerateColumns="false" HeaderStyle-Height="20px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdC47FactorytargetActualSlot_RowDataBound">
         <Columns>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 1
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine1" Text='<%# Eval("Line1Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 2
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine2" Text='<%# Eval("Line2Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 3 
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine3" Text='<%# Eval("Line3Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 4
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine4" Text='<%# Eval("Line4Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 5
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine5" Text='<%# Eval("Line5Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 6
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine6" Text='<%# Eval("Line6Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 7
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine7" Text='<%# Eval("Line7Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 8
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine8" Text='<%# Eval("Line8Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 9
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine9" Text='<%# Eval("Line9Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 10
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine10" Text='<%# Eval("Line10Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 11
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine11" Text='<%# Eval("Line11Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 12
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine12" Text='<%# Eval("Line12Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 13
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine13" Text='<%# Eval("Line13Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 14
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine14" Text='<%# Eval("Line14Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Line 15
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblC47FactorySlotAchLine15" Text='<%# Eval("Line15Ach") %>'></asp:Label>
            
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="70px">
            <HeaderTemplate>
               Total
            </HeaderTemplate>
            <HeaderStyle CssClass="header-right" />
            <ItemTemplate>
           
                  <asp:Label runat="server" ID="lblC47FactorySlotAchTotal" Text='<%# Eval("lineTotalAch") %>'></asp:Label>
                 
            </ItemTemplate>
            </asp:TemplateField>
         
         </Columns>
      
      </asp:GridView>
      </td>
      </tr>
      </table>
      </td>
      <td style="vertical-align:top; width:70px;">
      <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
      <tr>
      <th style="color:White;background-color:#405D99;font-size:12px;font-weight:normal;height:20px; border-left:1px solid white">
      
     BIPL
      </th>
      
      </tr>
      <tr>
      <td>
      <asp:GridView runat="server" ID="grdFactorytargetActualBiplSlot" ShowHeader="true" AutoGenerateColumns="false" Width="100%"  HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
            HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdFactorytargetActualBiplSlot_RowDataBound">
      <Columns>
         <asp:TemplateField>
           <HeaderTemplate>
             
           
           </HeaderTemplate>
           <HeaderStyle Height="20px" />
         <ItemTemplate>
    
         <asp:Label runat="server" ID="lblFactorytargetActualBiplAchSlot" Text='<%# Eval("lineTotalAch") %>'></asp:Label>
         
         </ItemTemplate>
         </asp:TemplateField>
      </Columns>

      </asp:GridView>

      </td>
      </tr>
      </table>
      
      </td>
      </tr>

   </table>
  
