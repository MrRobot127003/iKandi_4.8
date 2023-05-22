<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsLetter.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.NewsLetter" %>
<style type="text/css">
.Day
{
text-align:center !important;
    vertical-align: middle;
    border-collapse:collapse;
}
.Day td
{
    background:none !important;
    text-align:center !important;
    vertical-align: middle;
    border-color:#bfbfbf;
} 
 .item_list_Report th
    {
       font-size:10px;
	font-family: arial, halvetica;
	background:#3a5695;
	color:#98a9ca;
	font-weight:normal;

    }
    .item_list_Report th
    {
        padding: 0px;
        text-transform:capitalize;
    }
    
    .item_list_Report th table td
    {
     font-size:9px;
	background:#3a5695;
	color:#98a9ca;
	font-weight:normal;
        text-transform:capitalize !important;
    }
    .item_list_Report
    {
        background: #fff;
    }
    .item_list_Report td
    {
        font-size: 9px !important;        
        text-align: left;
        padding:0px !important;
        color:Gray;
    }
    
    .item_list_Report td table.Day td
    {
        border:1px solid #bfbfbf;
    }
    .item_list_Report td span
    {
        text-align: center;
    }
    .item_list_Report th table td
    {
        text-align: center;
    }
  </style>
<div>

<asp:GridView ID="gvNewsLetterHeader" ShowFooter="true" 
        FooterStyle-HorizontalAlign="Center" AllowPaging="false" 
        RowStyle-Font-Size="9px" HeaderStyle-Font-Size="10px"  ShowHeader="true" 
        AutoGenerateColumns="false" runat="server"  CssClass="item_list_Report" 
        onrowdatabound="gvNewsLetterHeader_RowDataBound" >
    <Columns>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="175px" ItemStyle-HorizontalAlign="Left" > 
      <HeaderTemplate>
    Designation
      </HeaderTemplate>
    <ItemTemplate >
            

    </ItemTemplate>
     
    </asp:TemplateField>

   <%-- Day 1--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName1" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay1" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay1" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle1" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

     <%-- Day 2--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName2" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay2" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay2" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle2" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

     <%-- Day 3--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName3" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay3" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay3" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle3" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

     <%-- Day 4--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName4" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay4" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay4" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle4" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

     <%-- Day 5--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName5" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay5" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay5" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle5" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

     <%-- Day 6--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName6" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay6" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay6" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle6" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

     <%-- Day 7--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName7" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay7" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay7" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle7" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>
     <%-- Day 8--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName8" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay8" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay8" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle8" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

 <%-- Day 9--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName9" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay9" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay9" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle9" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

 <%-- Day 10--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName10" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay10" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay10" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle10" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

 <%-- Day 11--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName11" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay11" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay11" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle11" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

 <%-- Day 12--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName12" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay12" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay12" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle12" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 13--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName13" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay13" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay13" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle13" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>
    

      <%-- Day 14--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName14" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay14" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay14" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle14" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 15--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName15" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay15" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay15" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle15" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 16--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName16" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay16" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay16" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle16" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 17--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName17" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay17" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay17" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle17" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 18--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName18" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay18" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay18" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle18" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 19--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName19" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay19" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay19" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle19" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 20--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName20" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay20" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay20" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle20" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 21--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName21" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay21" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay21" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle21" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 22--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName22" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay22" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay22" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle22" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 23--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName23" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay23" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay23" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle23" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

      <%-- Day 24--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName24" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay24" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay24" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle24" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

    <%-- Day 25--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName25" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay25" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay25" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle25" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

    <%-- Day 26--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName26" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay26" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay26" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle26" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

    <%-- Day 27--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName27" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay27" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay27" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle27" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

    <%-- Day 28--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName28" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay28" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay28" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle28" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

    <%-- Day 29--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName29" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay29" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay29" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle29" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

    <%-- Day 30--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName30" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay30" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay30" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle30" runat="server" Text=""></asp:Label>
     
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

    <%-- Day 31--%>
      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="Day" width="100%" border="1" frame="VOID" rules="ALL">      
      <tr><td align="center" ><asp:Label ID="lblDaysName31" runat="server" Text=""></asp:Label>
      <br /><asp:Label ID="lblSpecialDay31" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;"><asp:Label ID="lblDayDisplay31" runat="server" Text=""></asp:Label></td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblStyle31" runat="server" Text=""></asp:Label>
   
    </ItemTemplate>
    <ItemStyle CssClass="Day" />
    <ItemStyle HorizontalAlign="Center" />
  
    </asp:TemplateField>

            


    </Columns>
    </asp:GridView>
</div>