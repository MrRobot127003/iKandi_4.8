<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="HourlyStitchingReport.aspx.cs" Inherits="iKandi.Web.Internal.Production.HourlyStitchingReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">


<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
  .item_list th
  {
      font-weight:bold;
  }
  .blue
  {
      font-weight:bold; color:#3a5695; text-align:center
  }
  .stic {
    color: #5610c7;
    font-weight: normal;
}

.stic1 {
    color: red;
    font-weight: normal;
}
.blue-per {
    color: blue;
}
.slot
{
    text-align:center !important;
     vertical-align: middle;
     border-collapse:collapse;
}
 .slot td
 {
     background:none !important;
     text-align:center !important;
      vertical-align: middle;
      border-color:#bfbfbf;
 } 
 .item_list th
 {
     padding:0px;
  
 }
 .item_list
 {
     background:#fff;
 }
  .item_list td
 {
     font-size:9px !important;
     font-family:Arial;
     text-align:left;
 }
 .item_list td span
 {
     text-align:center;
 }
 .item_list  th table td
 {
     text-align:center;
 }
 .TGT
 {
      border-bottom:1px solid #000;
 }
 
.TGT th 
{
    height:19px;
   
}
.TGT td
{
    background:none;
      border: 1px solid #bfbfbf;
}
h1, h2, h3, h4, h5, h6
{
    margin:5px 0px;
    padding:0px
}
.bol {
    color: #3a5695;
    font-weight: bold;
    text-align:center !important;
}
.check_box_text
{
    text-align:center !important;
}
.main-table-width
{

     display: -webkit-box;      /* OLD - iOS 6-, Safari 3.1-6 */
  display: -moz-box;         /* OLD - Firefox 19- (buggy but mostly works) */
  display: -ms-flexbox;      /* TWEENER - IE 10 */
  display: -webkit-flex;     /* NEW - Chrome */
   flex-shrink: 0;
}
.fact-name
{
  background:#3a5695; color:#fff; text-align:center; font-family:arial; font-size:16px; padding:2px 0px;  
}
.text-label
{
    display:none;
}
.display-footer
{
    display:block !important;    
}
  </style>
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<script type="text/javascript">
    $(window).load(function () {
        //        $(".StitchTable td").filter(function () {            
        //            return $(this).text() == 0;
        //        }).css("display", "none");

//        $(".StitchTable td span").filter(function () {
//            return $(this).text() == 0;
//        }).css("display", "none");

        $(".StitchTable td span").each(function () {
        
            var el = $(this);
            var value = parseFloat(el.text());
            
            if (value == 0) {
                el
                 .css("display", "none")

            }
        });

        $(".item_list td span").each(function () {

            var el = $(this);
            var value = parseFloat(el.text());

            if (value == 0) {
                el
                 .css("display", "none")

            }
        });

    });




  </script>

  <%-- <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
   <asp:updatepanel ID="Updatepanel1" UpdateMode="Always" runat="server">
    <ContentTemplate>--%>
<table  cellpadding="0" cellspacing="0">
<tr>

<td style="min-width:1300px; width:auto; display:block;" >

<table style="width:auto; table-layout:fixed; min-width:1300px; display:block;" class="main-table-width StitchTable">





<tr>
<td id="Stitching" visible="false" runat="server">
<asp:HiddenField ID="hdnProductionUnit" runat="server" />
    <asp:HiddenField ID="hdnSlotId" runat="server" />    
    <asp:HiddenField ID="hdnStartDate" runat="server" />
    <h2 style="background:#3a5695; color:#fff; text-align:center; font-family:arial; font-size:16px; padding:2px 0px;">STITCHING</h2>
</td></tr> 

<tr><td id="StichFact1"  visible="false" runat="server"><h4 class="fact-name">
    <asp:Label ID="lblStitchUnit1" Visible="false" runat="server" Text="C 47"></asp:Label></h4>
    <br />
    </td></tr>

<tr>
<td>
 <asp:GridView ID="gvHourlyStitchingReport1" RowStyle-Font-Size="9px" HeaderStyle-Font-Bold="false" HeaderStyle-Font-Size="10px" ShowHeader="true" 
        AutoGenerateColumns="false" runat="server" 
        onrowdatabound="gvHourlyStitchingReport1_RowDataBound"  CssClass="item_list">
  <Columns>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Line/Designation
      </HeaderTemplate>
    <ItemTemplate >
    <table cellpadding="0" cellspacing="0" width="100%"><tr>
    <td style="border-bottom:1px solid #bfbfbf; font-size:9px;" class="blue"><%#Eval("LineNumber")%></td>
    <td style=" border-bottom:1px solid #bfbfbf; font-size:9px;" align="center" class="blue"><%#Eval("CompanyName")%></td>
    <td style=" border-bottom:1px solid #bfbfbf; font-size:9px;" align="center" class="blue"><%#Eval("StyleNumber")%></td>
    </tr>
   <tr><td colspan="3">
       <asp:DataList ID="dlstLineDesignation"  Width="100%"  runat="server">
        <ItemTemplate>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-bottom:1px solid #bfbfbf;">
        <tr><td style="border-right:1px solid #bfbfbf; color:#45a5e3;  font-size:9px; font-weight:bold; text-align:left; width:60%;">
           <%#Eval("DesignationName") %></td>
            <td style="width:40%; padding-left:5px;"><%#Eval("Name") %></td>
        </tr>
        </table>
        </ItemTemplate>
        </asp:DataList>
        </td></tr></table>        

    </ItemTemplate>
    </asp:TemplateField>

   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="175px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   SAM, Order Qty <br />
   Quantity Produced <br />
    OB v/s Actual (Plan)
      </HeaderTemplate>
    <ItemTemplate >
     
            <asp:HiddenField ID="hdnStyleId" Value='<%#Eval("StyleID") %>' runat="server" />
            <asp:HiddenField ID="hdnLineNo" Value='<%#Eval("Line_No") %>' runat="server" />
        SAM:<%#Eval("SAM") %>, Order Qty :<%#Eval("OrderQty") %><br />Stitched :&nbsp; <span class="stic"> <%#Eval("StitchedQty") %> </span>
        Balance :&nbsp <span class="stic1"> <%#Eval("UnStitchedQty") %> </span> 
        <br />
         OB W/S : &nbsp; <span class="stic"> <%#Eval("ActualOB") %> </span> <span class="stic1">  (<%#Eval("OB")%>) </span>
          

    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="210px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Day, Target <br />
    Efficiency Summery<br /> DHU
      </HeaderTemplate>
    <ItemTemplate >
       
        <span class="blue-per"> <%#Eval("DayTargetEfficiency") %>   </span>
        <%#Eval("HourlyPcs") %>
       <br/>
        Today Eff (Ach): <span class="blue-per"> <%#Eval("TodayEfficiency") %>
        (<%#Eval("TodayAchievemenet") %>) </span>
       <br /> Style Eff (Ach): <span class="blue-per"> <%#Eval("StyleEfficiency") %>  </span>  
       (&nbsp;<span class="blue-per"> <%#Eval("StyleAchieved") %> </span>) 
       <br />
          Today DHU : 
       <span class="blue-per"> <%#Eval("DHU_Today") %> </span>
        (Avg DHU:<span class="blue-per"> <%#Eval("DHU_Avg")%></span>)
        

    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="265px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Financial
    
      </HeaderTemplate>
    <ItemTemplate >
       Break Even Eff : 
        <span class="blue-per"> <%#Eval("BreakEvenEff") %> % </span> @ Rs. <%#Eval("BreakEvenCost")%>
        
        <br />
         Costed CMT : 
       <span> <%#Eval("CostedCMT") %></span>
       <br />
        CMT Today : 
       <span> <%#Eval("CMT_Today") %></span>
       <br />
        Style CMT : 
       <span> <%#Eval("CMT_Style")%></span> &nbsp;(&nbsp;<span><%#Eval("ProfitLoss")%> </span>L)
      

    </ItemTemplate>
    </asp:TemplateField>
   <%-- Slot 1--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" border="1" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 1</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot1Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
          <table width="100%" class="slot" RULES="ALL" FRAME="VOID">        
        <tr><td align="center" style="width:50%; height:20px;">
        <%#Eval("Slot1Pass") %></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per"> <%#Eval("Slot1Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">OB :
            <span><%#Eval("Slot1OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 2--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 2</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot2Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <%#Eval("Slot2Pass") %></td>
        <td align="center" style="width:50%; height:20px;">      
        <span class="blue-per"> <%#Eval("Slot2Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot2OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 3--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 3</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot3Time" runat="server" Text=""></asp:Label></td></tr>
     <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">          
        <tr><td align="center" style="width:50%; height:20px;">
        <%#Eval("Slot3Pass") %></td>
        <td align="center" style="width:50%; height:20px;">      
         <span class="blue-per"> <%#Eval("Slot3Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot3OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 4--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 4</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot4Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <%#Eval("Slot4Pass") %></td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per">  <%#Eval("Slot4Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot4OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 5--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 5</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot5Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         <table width="100%" class="slot" RULES="ALL" FRAME="VOID">         
        <tr><td align="center" style="width:50%; height:20px;">
        <%#Eval("Slot5Pass") %></td>
        <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot5Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot5OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 6--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 6</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot6Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <span><%#Eval("Slot6Pass") %> </span>
        
        </td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per"> <%#Eval("Slot6Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot6OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 7--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 7</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot7Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot7Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot7Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot7OB") %></span></td>
        </tr> 
        </table>
    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 8--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 8</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot8Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <span> <%#Eval("Slot8Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot8Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot8OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 9--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 9</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot9Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
      <span> <%#Eval("Slot9Pass") %>
      </span> 
      </td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot9Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot9OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 10--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 10</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot10Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot10Pass") %>
       </span>
       </td>
       <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot10Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot10OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 11--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 11</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot11Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot11Pass") %>
       </span> 
       </td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">   <%#Eval("Slot11Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot11OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 12--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 12</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot12Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
        <span><%#Eval("Slot12Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot12Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot12OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 13--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 13</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot13Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot13Pass") %> </span> </td>
       <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot13Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot13OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 
    

      <%-- Slot 14--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 14</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot14Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span><%#Eval("Slot14Pass") %> </span>  </td>
       <td align="center" style="width:50%; height:20px;">
       <span class="blue-per">  <%#Eval("Slot14Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot14OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 15--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
  <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 15</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot15Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
  <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <span> <%#Eval("Slot15Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">  <%#Eval("Slot15Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot15OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 16--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 16</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot16Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot16Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
        <span class="blue-per">  <%#Eval("Slot16Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot16OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 17--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 17</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot17Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">     
        <tr><td align="center" style="width:50%; height:20px;">
      <span> <%#Eval("Slot17Pass") %></span> 
        
        </td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot17Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot17OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 18--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 18</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot18Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot18Pass") %>
       </span> 
       </td>
        <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot18Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot18OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 19--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 19</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot19Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot19Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;"> 
       <span class="blue-per">  <%#Eval("Slot19Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
           <span><%#Eval("Slot19OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 20--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 20</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot20Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot20Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot20Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot20OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 21--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 21</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot21Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot21Pass") %> </span> </td>
       <td align="center" style="width:50%; height:20px;">    
       <span class="blue-per">  <%#Eval("Slot21Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot21OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 22--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 22</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot22Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
 <table width="100%" class="slot" RULES="ALL" FRAME="VOID">     
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot22Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">   <%#Eval("Slot22Alt") %> </span>
        </td></tr>
        <tr> <td align="center"  colspan="2">  OB :
           <span><%#Eval("Slot22OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 23--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 23</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot23Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot23Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot23Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
           <span><%#Eval("Slot23OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 24--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 24</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot24Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate>
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <span> <%#Eval("Slot24Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per"> <%#Eval("Slot24Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot24OB") %></span></td>
        </tr> 
        </table>
    </ItemTemplate>
     </asp:TemplateField>    
    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ItemStyle-CssClass="check_box_text">
   <HeaderTemplate>
   Style fin
   </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox ID="chkMarkAsStyle" Checked='<%# Eval("IsStitched") %>' runat="server" Enabled="false" />
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ItemStyle-CssClass="check_box_text">
 <HeaderTemplate>
   Day fin
   </HeaderTemplate>
    <ItemTemplate>
       <asp:CheckBox ID="chkMarkAsDayClose" Checked='<%# Eval("IsDayClosed") %>' runat="server" Enabled="false" />
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
 <HeaderTemplate>
 COMMENT
 </HeaderTemplate>
    <ItemTemplate>
        <asp:TextBox ID="txtComment" BackColor="White" ReadOnly="true" Text='<%#Eval("SlotDescription") %>' Width="200px" TextMode="MultiLine" runat="server"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
     <%--Comment for hide Profit & Loss section--%>
     <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
         <HeaderTemplate>
         Target Based
         </HeaderTemplate>
            <ItemTemplate>
                 <asp:Repeater ID="rptDepartment_Target" runat="server">
                 <HeaderTemplate>
                <table width="100%" class="TGT" border="1" RULES="ALL" FRAME="VOID" cellpadding="0" cellspacing="0">
        <tr><th style="width:100px;" align="center"></th>
        <th style="width:130px;" colspan="2" align="center">Hour</th>
        <th style="width:130px;" colspan="2" align="center">Today</th>
        <th style="width:130px;" colspan="2" align="center">Style Based</th>
         </tr>      

                 </HeaderTemplate>
        <ItemTemplate>
    
        <tr>
        <td style="width:100px;" align="center"><%#Eval("DepartmentName") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossValue") %></td>
        </tr>      
   
        </ItemTemplate>
       <FooterTemplate>
       </table>
       </FooterTemplate>
        </asp:Repeater>
            </ItemTemplate>
     </asp:TemplateField>

      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
         <HeaderTemplate>
         B.E Based
         </HeaderTemplate>
            <ItemTemplate>
                 <asp:Repeater ID="rptDepartment_BE" runat="server">
                 <HeaderTemplate>
              <table width="100%" class="TGT" border="1" RULES="ALL" FRAME="VOID" cellpadding="0" cellspacing="0">
        <tr><th style="width:100px;" align="center"></th>
        <th style="width:130px;" colspan="2" align="center">Hour</th>
        <th style="width:130px;" colspan="2" align="center">Today</th>
        <th style="width:130px;" colspan="2" align="center">Style Based</th>
         </tr> 
                 </HeaderTemplate>
        <ItemTemplate>
        
        <tr>
         <td style="width:100px;" align="center"><%#Eval("DepartmentName") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossValue") %></td>
        </tr>      
      
        </ItemTemplate>
         <FooterTemplate>
       </table>
       </FooterTemplate>
        </asp:Repeater>
            </ItemTemplate>
     </asp:TemplateField>--%>


    </Columns>
    </asp:GridView>
    <br />
</td>

</tr>

<tr>
<td id="StichFact2"  visible="false" runat="server">
<h4 class="fact-name"><asp:Label ID="lblStitchUnit2" Visible="false" runat="server" Text="C 45-46"></asp:Label></h4>

<br />
</td>
</tr>

<tr>
<td>
 <asp:GridView ID="gvHourlyStitchingReport2" RowStyle-Font-Size="9px" HeaderStyle-Font-Size="10px" ShowHeader="true" 
        AutoGenerateColumns="false" runat="server" 
        onrowdatabound="gvHourlyStitchingReport2_RowDataBound"  CssClass="item_list">
    <Columns>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Line/Designation
      </HeaderTemplate>
    <ItemTemplate >
    <table cellpadding="0" cellspacing="0" width="100%"><tr>
    <td style="border-bottom:1px solid #bfbfbf; font-size:9px;" class="blue"><%#Eval("LineNumber")%></td>
    <td style=" border-bottom:1px solid #bfbfbf; font-size:9px;" align="center" class="blue"><%#Eval("CompanyName")%></td>
    <td style=" border-bottom:1px solid #bfbfbf; font-size:9px;" align="center" class="blue"><%#Eval("StyleNumber")%></td>
    </tr>
   <tr><td colspan="3">
       <asp:DataList ID="dlstLineDesignation" Width="100%"  runat="server">
        <ItemTemplate>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-bottom:1px solid #bfbfbf;">
        <tr><td style="border-right:1px solid #bfbfbf; color:#45a5e3;  font-size:9px; font-weight:bold; text-align:left; width:60%;">
           <%#Eval("DesignationName") %></td>
            <td style="width:40%; padding-left:5px;"><%#Eval("Name") %></td>
        </tr>
        </table>
        </ItemTemplate>
        </asp:DataList>
        </td></tr></table>        

    </ItemTemplate>
    </asp:TemplateField>

   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="175px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   SAM, Order Qty <br />
   Quantity Produced <br />
    OB v/s Actual (Plan)
      </HeaderTemplate>
    <ItemTemplate >
     
            <asp:HiddenField ID="hdnStyleId" Value='<%#Eval("StyleID") %>' runat="server" />
            <asp:HiddenField ID="hdnLineNo" Value='<%#Eval("Line_No") %>' runat="server" />
        SAM: <span> <%#Eval("SAM") %> </span>, Order Qty :<span> <%#Eval("OrderQty") %> </span><br />Stitched :&nbsp; <span class="stic"> <%#Eval("StitchedQty") %> </span>
        Balance :&nbsp <span class="stic1"> <%#Eval("UnStitchedQty") %> </span> 
        <br />
         OB W/S : &nbsp; <span class="stic"> <%#Eval("ActualOB") %> </span> <span class="stic1">  (<%#Eval("OB")%>) </span>
          

    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="210px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Day, Target <br />
    Efficiency Summery<br /> DHU
      </HeaderTemplate>
    <ItemTemplate >
       
        <span class="blue-per"> <%#Eval("DayTargetEfficiency") %>   </span>
       <span> <%#Eval("HourlyPcs") %> </span>
       <br/>
        Today Eff (Ach): <span class="blue-per"> <%#Eval("TodayEfficiency") %>
        (<%#Eval("TodayAchievemenet") %>) </span>
       <br /> Style Eff (Ach): <span class="blue-per"> <%#Eval("StyleEfficiency") %>  </span>  
       (<span class="blue-per">  <%#Eval("StyleAchieved") %> </span>) 
       <br />
          Today DHU : 
       <span class="blue-per"> <%#Eval("DHU_Today") %> </span>
        (Avg DHU:<span class="blue-per"> <%#Eval("DHU_Avg")%></span>)
        

    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="265px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Financial
    
      </HeaderTemplate>
    <ItemTemplate >
       Break Even Eff : 
        <span class="blue-per"> <%#Eval("BreakEvenEff") %> % </span> @ Rs. <span> <%#Eval("BreakEvenCost")%> </span>
        
        <br />
         Costed CMT : 
        <span> <%#Eval("CostedCMT") %></span>
       <br />
        CMT Today : 
        <span> <%#Eval("CMT_Today") %></span>
       <br />
        Style CMT : 
        <span> <%#Eval("CMT_Style")%></span> &nbsp;(&nbsp;<span><%#Eval("ProfitLoss")%> </span>L)
      

    </ItemTemplate>
    </asp:TemplateField>
   <%-- Slot 1--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" border="1" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 1</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot1Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
          <table width="100%" class="slot" RULES="ALL" FRAME="VOID">        
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot1Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per"> <%#Eval("Slot1Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">OB :
           <span> <%#Eval("Slot1OB") %> </span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 2--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 2</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot2Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <span> <%#Eval("Slot2Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
        <span class="blue-per"> <%#Eval("Slot2Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
          <span><%#Eval("Slot2OB") %> </span>  </td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 3--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 3</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot3Time" runat="server" Text=""></asp:Label></td></tr>
     <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">          
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot3Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
         <span class="blue-per"> <%#Eval("Slot3Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot3OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 4--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 4</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot4Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot4Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per">  <%#Eval("Slot4Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot4OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 5--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 5</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot5Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         <table width="100%" class="slot" RULES="ALL" FRAME="VOID">         
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot5Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot5Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot5OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 6--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 6</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot6Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot6Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per"> <%#Eval("Slot6Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot6OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 7--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 7</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot7Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot7Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot7Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot7OB") %></span></td>
        </tr> 
        </table>
    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 8--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 8</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot8Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot8Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot8Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot8OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 9--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 9</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot9Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot9Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot9Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot9OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 10--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 10</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot10Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot10Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot10Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot10OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 11--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 11</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot11Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot11Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">   <%#Eval("Slot11Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot11OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 12--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 12</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot12Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot12Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot12Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot12OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 13--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 13</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot13Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
      <span>  <%#Eval("Slot13Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot13Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot13OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 
    

      <%-- Slot 14--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 14</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot14Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
      <span>  <%#Eval("Slot14Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">
       <span class="blue-per">  <%#Eval("Slot14Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot14OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 15--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
  <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 15</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot15Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
  <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot15Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">  <%#Eval("Slot15Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot15OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 16--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 16</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot16Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot16Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
        <span class="blue-per">  <%#Eval("Slot16Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot16OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 17--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 17</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot17Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">     
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot17Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot17Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot17OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 18--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 18</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot18Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot18Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot18Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot18OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 19--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 19</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot19Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
      <span> <%#Eval("Slot19Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;"> 
       <span class="blue-per">  <%#Eval("Slot19Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
           <span><%#Eval("Slot19OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 20--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 20</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot20Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot20Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot20Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot20OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 21--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 21</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot21Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
      <span>  <%#Eval("Slot21Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">    
       <span class="blue-per">  <%#Eval("Slot21Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot21OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 22--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 22</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot22Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
 <table width="100%" class="slot" RULES="ALL" FRAME="VOID">     
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot22Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">   <%#Eval("Slot22Alt") %> </span>
        </td></tr>
        <tr> <td align="center"  colspan="2">  OB :
           <span><%#Eval("Slot22OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 23--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 23</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot23Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
      <span>  <%#Eval("Slot23Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot23Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
           <span><%#Eval("Slot23OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 24--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 24</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot24Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate>
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot24Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per"> <%#Eval("Slot24Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot24OB") %></span></td>
        </tr> 
        </table>
    </ItemTemplate>
     </asp:TemplateField>    
    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ItemStyle-CssClass="check_box_text">
   <HeaderTemplate>
   Style fin
   </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox ID="chkMarkAsStyle" Checked='<%# Eval("IsStitched") %>' runat="server" Enabled="false" />
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ItemStyle-CssClass="check_box_text">
 <HeaderTemplate>
   Day fin
   </HeaderTemplate>
    <ItemTemplate>
       <asp:CheckBox ID="chkMarkAsDayClose" Checked='<%# Eval("IsDayClosed") %>' runat="server" Enabled="false" />
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
 <HeaderTemplate>
 COMMENT
 </HeaderTemplate>
    <ItemTemplate>
        <asp:TextBox ID="txtComment" BackColor="White" ReadOnly="true" Text='<%#Eval("SlotDescription") %>' Width="200px" TextMode="MultiLine" runat="server"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <%--Comment for hide Profit & Loss section--%>

     <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
         <HeaderTemplate>
         Target Based
         </HeaderTemplate>
            <ItemTemplate>
                 <asp:Repeater ID="rptDepartment_Target" runat="server">
                 <HeaderTemplate>
                <table width="100%" class="TGT" border="1" RULES="ALL" FRAME="VOID" cellpadding="0" cellspacing="0">
        <tr><th style="width:100px;" align="center"></th>
        <th style="width:130px;" colspan="2" align="center">Hour</th>
        <th style="width:130px;" colspan="2" align="center">Today</th>
        <th style="width:130px;" colspan="2" align="center">Style Based</th>
         </tr>      

                 </HeaderTemplate>
        <ItemTemplate>
    
        <tr>
        <td style="width:100px;" align="center"><%#Eval("DepartmentName") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossValue") %></td>
        </tr>      
   
        </ItemTemplate>
       <FooterTemplate>
       </table>
       </FooterTemplate>
        </asp:Repeater>
            </ItemTemplate>
     </asp:TemplateField>

      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
         <HeaderTemplate>
         B.E Based
         </HeaderTemplate>
            <ItemTemplate>
                 <asp:Repeater ID="rptDepartment_BE" runat="server">
                 <HeaderTemplate>
              <table width="100%" class="TGT" border="1" RULES="ALL" FRAME="VOID" cellpadding="0" cellspacing="0">
        <tr><th style="width:100px;" align="center"></th>
        <th style="width:130px;" colspan="2" align="center">Hour</th>
        <th style="width:130px;" colspan="2" align="center">Today</th>
        <th style="width:130px;" colspan="2" align="center">Style Based</th>
         </tr> 
                 </HeaderTemplate>
        <ItemTemplate>
        
        <tr>
         <td style="width:100px;" align="center"><%#Eval("DepartmentName") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossValue") %></td>
        </tr>      
      
        </ItemTemplate>
         <FooterTemplate>
       </table>
       </FooterTemplate>
        </asp:Repeater>
            </ItemTemplate>
     </asp:TemplateField>--%>


    </Columns>
    </asp:GridView>
    <br />
</td>
</tr>

<tr><td id="StichFact3"  visible="false" runat="server">
<h4 class="fact-name"><asp:Label ID="lblStitchUnit3" Visible="false" runat="server" Text="B 45"></asp:Label></h4>
<br />
</td></tr>

<tr>
<td>
 <asp:GridView ID="gvHourlyStitchingReport3" RowStyle-Font-Size="9px" HeaderStyle-Font-Size="10px" ShowHeader="true" 
        AutoGenerateColumns="false" runat="server"  CssClass="item_list"
        onrowdatabound="gvHourlyStitchingReport3_RowDataBound">
  <Columns>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Line/Designation
      </HeaderTemplate>
    <ItemTemplate >
    <table cellpadding="0" cellspacing="0" width="100%"><tr>
    <td style="border-bottom:1px solid #bfbfbf; font-size:9px;" class="blue"><%#Eval("LineNumber")%></td>
    <td style=" border-bottom:1px solid #bfbfbf; font-size:9px;" align="center" class="blue"><%#Eval("CompanyName")%></td>
    <td style=" border-bottom:1px solid #bfbfbf; font-size:9px;" align="center" class="blue"><%#Eval("StyleNumber")%></td>
    </tr>
   <tr><td colspan="3">
       <asp:DataList ID="dlstLineDesignation" Width="100%"  runat="server">
        <ItemTemplate>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-bottom:1px solid #bfbfbf;">
        <tr><td style="border-right:1px solid #bfbfbf; color:#45a5e3;  font-size:9px; font-weight:bold; text-align:left; width:60%;">
           <%#Eval("DesignationName") %></td>
            <td style="width:40%; padding-left:5px;"><%#Eval("Name") %></td>
        </tr>
        </table>
        </ItemTemplate>
        </asp:DataList>
        </td></tr></table>        

    </ItemTemplate>
    </asp:TemplateField>

   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="175px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   SAM, Order Qty <br />
   Quantity Produced <br />
    OB v/s Actual (Plan)
      </HeaderTemplate>
    <ItemTemplate >
     
            <asp:HiddenField ID="hdnStyleId" Value='<%#Eval("StyleID") %>' runat="server" />
            <asp:HiddenField ID="hdnLineNo" Value='<%#Eval("Line_No") %>' runat="server" />
        SAM: <span> <%#Eval("SAM") %> </span>, Order Qty : <span><%#Eval("OrderQty") %> </span> <br />Stitched :&nbsp; <span class="stic"> <%#Eval("StitchedQty") %> </span>
        Balance :&nbsp <span class="stic1"> <%#Eval("UnStitchedQty") %> </span> 
        <br />
         OB W/S : &nbsp; <span class="stic"> <%#Eval("ActualOB") %> </span> (<span class="stic1">  <%#Eval("OB")%> </span>)
          

    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Day, Target <br />
    Efficiency Summery<br /> DHU
      </HeaderTemplate>
    <ItemTemplate >
       
        <span class="blue-per"> <%#Eval("DayTargetEfficiency") %>   </span>
       <span> <%#Eval("HourlyPcs") %> </span>
       <br/>
        Today Eff (Ach): <span class="blue-per"> <%#Eval("TodayEfficiency") %> </span>
        (&nbsp;<span class="blue-per"> <%#Eval("TodayAchievemenet") %> </span>) 
       <br /> Style Eff (Ach): <span class="blue-per"> <%#Eval("StyleEfficiency") %> </span>   
       (&nbsp;<span class="blue-per"> <%#Eval("StyleAchieved") %> </span>) 
       <br />
          Today DHU : 
       <span class="blue-per"> <%#Eval("DHU_Today") %> </span>
        (Avg DHU:<span class="blue-per"> <%#Eval("DHU_Avg")%> </span>)
        

    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="235px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Financial
    
      </HeaderTemplate>
    <ItemTemplate >
       Break Even Eff : 
        <span class="blue-per"> <%#Eval("BreakEvenEff") %> % </span> @ Rs. <%#Eval("BreakEvenCost")%>
        
        <br />
         Costed CMT : 
        <span> <%#Eval("CostedCMT") %></span>
       <br />
        CMT Today : 
        <span> <%#Eval("CMT_Today") %></span>
       <br />
        Style CMT : 
        <span> <%#Eval("CMT_Style")%></span> &nbsp;(&nbsp;<span><%#Eval("ProfitLoss")%> L</span>)
      

    </ItemTemplate>
    </asp:TemplateField>
   <%-- Slot 1--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" border="1" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 1</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot1Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
          <table width="100%" class="slot" RULES="ALL" FRAME="VOID">        
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot1Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per"> <%#Eval("Slot1Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">OB :
           <span> <%#Eval("Slot1OB") %> </span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 2--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 2</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot2Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot2Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
        <span class="blue-per"> <%#Eval("Slot2Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
          <span>  <%#Eval("Slot2OB") %> </span> </td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 3--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 3</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot3Time" runat="server" Text=""></asp:Label></td></tr>
     <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">          
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot3Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">      
         <span class="blue-per"> <%#Eval("Slot3Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot3OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 4--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 4</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot4Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
      <span> <%#Eval("Slot4Pass") %> </span>  </td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per">  <%#Eval("Slot4Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot4OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 5--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 5</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot5Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         <table width="100%" class="slot" RULES="ALL" FRAME="VOID">         
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot5Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot5Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot5OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 6--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 6</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot6Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot6Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per"> <%#Eval("Slot6Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot6OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 7--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 7</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot7Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot7Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot7Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot7OB") %></span></td>
        </tr> 
        </table>
    </ItemTemplate>
    </asp:TemplateField>

     <%-- Slot 8--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 8</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot8Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot8Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot8Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot8OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 9--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 9</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot9Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot9Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot9Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot9OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 10--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 10</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot10Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
      <span>  <%#Eval("Slot10Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot10Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot10OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 11--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 11</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot11Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot11Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">   <%#Eval("Slot11Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot11OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField>

 <%-- Slot 12--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
   <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 12</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot12Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot12Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot12Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot12OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 13--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 13</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot13Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot13Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">      
       <span class="blue-per">  <%#Eval("Slot13Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot13OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 
    

      <%-- Slot 14--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 14</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot14Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot14Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">
       <span class="blue-per">  <%#Eval("Slot14Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot14OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 15--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
  <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 15</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot15Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
  <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot15Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">  <%#Eval("Slot15Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot15OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 16--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 16</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot16Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot16Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
        <span class="blue-per">  <%#Eval("Slot16Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot16OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 17--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 17</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot17Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">     
        <tr><td align="center" style="width:50%; height:20px;">
       <span><%#Eval("Slot17Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot17Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot17OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 18--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 18</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot18Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot18Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
      <span class="blue-per">  <%#Eval("Slot18Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2">  OB :
            <span><%#Eval("Slot18OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 19--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 19</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot19Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot19Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;"> 
       <span class="blue-per">  <%#Eval("Slot19Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2">  OB :
           <span><%#Eval("Slot19OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 20--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 20</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot20Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot20Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot20Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot20OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 21--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 21</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot21Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot21Pass") %> </span> </td>
       <td align="center" style="width:50%; height:20px;">    
       <span class="blue-per">  <%#Eval("Slot21Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot21OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 22--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 22</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot22Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
 <table width="100%" class="slot" RULES="ALL" FRAME="VOID">     
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot22Pass") %> </span></td>
        <td align="center" style="width:50%; height:20px;">      
      <span class="blue-per">   <%#Eval("Slot22Alt") %> </span>
        </td></tr>
        <tr> <td align="center"  colspan="2">  OB :
           <span><%#Eval("Slot22OB") %></span></td>
        </tr> 
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 23--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 23</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot23Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">      
        <tr><td align="center" style="width:50%; height:20px;">
       <span> <%#Eval("Slot23Pass") %> </span></td>
       <td align="center" style="width:50%; height:20px;">     
       <span class="blue-per">  <%#Eval("Slot23Alt") %> </span>
        </td></tr>
       <tr><td align="center"  colspan="2"> OB :
           <span><%#Eval("Slot23OB") %></span></td>
        </tr>  
        </table>

    </ItemTemplate>
     </asp:TemplateField> 

      <%-- Slot 24--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table width="100%" class="slot" RULES="ALL" FRAME="VOID">
      <tr><td align="center" colspan="2">Slot 24</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot24Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:50px;">Pcs</td><td align="center" style="width:50px;">Alt</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate>
       <table width="100%" class="slot" RULES="ALL" FRAME="VOID">       
        <tr><td align="center" style="width:50%; height:20px;">
        <span><%#Eval("Slot24Pass") %> </span> </td>
        <td align="center" style="width:50%; height:20px;">     
        <span class="blue-per"> <%#Eval("Slot24Alt") %> </span>
        </td></tr>
        <tr><td align="center"  colspan="2"> OB :
            <span><%#Eval("Slot24OB") %></span></td>
        </tr> 
        </table>
    </ItemTemplate>
     </asp:TemplateField>    
    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ItemStyle-CssClass="check_box_text">
   <HeaderTemplate>
   Style fin
   </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox ID="chkMarkAsStyle" Checked='<%# Eval("IsStitched") %>' runat="server" Enabled="false" />
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ItemStyle-CssClass="check_box_text">
 <HeaderTemplate>
   Day fin
   </HeaderTemplate>
    <ItemTemplate>
       <asp:CheckBox ID="chkMarkAsDayClose" Checked='<%# Eval("IsDayClosed") %>' runat="server" Enabled="false" />
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
 <HeaderTemplate>
 COMMENT
 </HeaderTemplate>
    <ItemTemplate>
        <asp:TextBox ID="txtComment" BackColor="White" ReadOnly="true" Text='<%#Eval("SlotDescription") %>' Width="200px" TextMode="MultiLine" runat="server"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    <%--Comment for hide Profit & Loss section--%>
      <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
         <HeaderTemplate>
         Target Based
         </HeaderTemplate>
            <ItemTemplate>
                 <asp:Repeater ID="rptDepartment_Target" runat="server">
                 <HeaderTemplate>
                <table width="100%" class="TGT" border="1" RULES="ALL" FRAME="VOID" cellpadding="0" cellspacing="0">
        <tr><th style="width:100px;" align="center"></th>
        <th style="width:130px;" colspan="2" align="center">Hour</th>
        <th style="width:130px;" colspan="2" align="center">Today</th>
        <th style="width:130px;" colspan="2" align="center">Style Based</th>
         </tr>      

                 </HeaderTemplate>
        <ItemTemplate>
    
        <tr>
        <td style="width:100px;" align="center"><%#Eval("DepartmentName") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossValue") %></td>
        </tr>      
   
        </ItemTemplate>
       <FooterTemplate>
       </table>
       </FooterTemplate>
        </asp:Repeater>
            </ItemTemplate>
     </asp:TemplateField>

      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
         <HeaderTemplate>
         B.E Based
         </HeaderTemplate>
            <ItemTemplate>
                 <asp:Repeater ID="rptDepartment_BE" runat="server">
                 <HeaderTemplate>
              <table width="100%" class="TGT" border="1" RULES="ALL" FRAME="VOID" cellpadding="0" cellspacing="0">
        <tr><th style="width:100px;" align="center"></th>
        <th style="width:130px;" colspan="2" align="center">Hour</th>
        <th style="width:130px;" colspan="2" align="center">Today</th>
        <th style="width:130px;" colspan="2" align="center">Style Based</th>
         </tr> 
                 </HeaderTemplate>
        <ItemTemplate>
        
        <tr>
         <td style="width:100px;" align="center"><%#Eval("DepartmentName") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Hourly_LossValue") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Today_LossValue") %></td>
         <td style="width:60px;" align="center" class="change"><%#Eval("Style_LossPercent") %></td>
         <td style="width:60px;" align="center"><%#Eval("Style_LossValue") %></td>
        </tr>      
      
        </ItemTemplate>
         <FooterTemplate>
       </table>
       </FooterTemplate>
        </asp:Repeater>
            </ItemTemplate>
     </asp:TemplateField>--%>


    </Columns>
    </asp:GridView>
</td>
</tr>





</table>






</td>



</tr>

<tr>
<td style="min-width:1000px; width:auto;">




<table style="width:100%; table-layout:fixed;" class="main-table-width">
<tr>
<td id="Finishing" visible="false" runat="server">
    <h2 style="background:#3a5695; color:#fff; text-align:center; font-family:arial; font-size:16px; padding:2px 0px;">FINISHING</h2>
    
</td></tr>

<tr>
<td id="FinishFact1" visible="false" runat="server"><h4 class="fact-name">
    <asp:Label ID="lblFinishUnit1" Visible="false" runat="server" Text="C 47"></asp:Label></h4>
    <br />
    </td></tr>
<tr>

<td>
 <asp:GridView ID="gvHourlyFinishingReport1" ShowFooter="true" FooterStyle-HorizontalAlign="Center" AllowPaging="false" 
        RowStyle-Font-Size="9px" HeaderStyle-Font-Size="10px"  ShowHeader="true" 
        AutoGenerateColumns="false" runat="server"  onrowdatabound="gvHourlyFinishingReport1_RowDataBound" 
        ondatabound="gvHourlyFinishingReport1_DataBound" CssClass="item_list" >
    <Columns>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="175px" ItemStyle-HorizontalAlign="Left" > 
      <HeaderTemplate>
    Designation
      </HeaderTemplate>
    <ItemTemplate >
        <asp:Repeater ID="rptDesignation"  runat="server" >
        <ItemTemplate>
         <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-bottom:1px solid #000;">
        <tr><td style="border-right:1px solid #000; color:#45a5e3;  font-size:9px; font-weight:bold; text-align:left; width:60%;">
           <%#Eval("DesignationName") %></td>
             <td style="width:40%; padding-left:5px;"><%#Eval("Name") %></td>
        </tr>
        </table>
        </ItemTemplate>
        </asp:Repeater>
      

    </ItemTemplate>
      <FooterTemplate>    
          <asp:Label ID="lblfooter1" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="display-footer" />
    </asp:TemplateField>

   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="330px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Efficiency Summery <br />
SAM<br />
OB v/s 
      </HeaderTemplate>
    <ItemTemplate >
      

            <asp:HiddenField ID="hdnStyleId" Value='<%#Eval("StyleID") %>' runat="server" />            
        Target (Actual) Achieved :
    <span class="blue-per"><asp:Label ID="lblTarget" runat="server" Text='<%#Eval("TargetEff") %>'></asp:Label>%&nbsp;
        <asp:Label ID="lblActual" runat="server" Text='<%#Eval("ActualEff") %>'></asp:Label>% &nbsp;
        <asp:Label ID="lblAchieved" runat="server" Text='<%#Eval("ActualAch") %>'></asp:Label>%</span> <br />
   Per pcs cost (Target vs Actual) :
       <b><asp:Label ID="lblTargetCost" Font-Bold="true" runat="server" Text='<%#Eval("TargetPerPieceRate") %>'></asp:Label> &nbsp;Rs. </b>  vs 
       <b> <asp:Label ID="lblActualCost" Font-Bold="true" runat="server" Text='<%#Eval("ActualPerPieceRate") %>'></asp:Label>&nbsp;Rs.</b> <br />
       SAM : <asp:Label ID="lblSAM" runat="server" Text='<%#Eval("FinishingSAM") %>'></asp:Label>       
      
      OB W/S : <asp:Label ID="lblOB" runat="server" CssClass="stic" Text='<%#Eval("OB") %>'></asp:Label>       
            

    </ItemTemplate>
      <FooterTemplate>    
    <asp:Label ID="lblfooter2" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="display-footer" />
    </asp:TemplateField>

    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       Order Qty @FOB Fin/Stitched
 
      </HeaderTemplate>
    <ItemTemplate >
                
        <asp:Label ID="lblClient" CssClass="blue-per" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
        <asp:Label ID="lblStyleNo"  CssClass="blue-per" runat="server" Text='<%#Eval("StyleNumber") %>'></asp:Label>
       <br /> 
        <asp:Label ID="lblOrderQty"  runat="server" Text='<%#Eval("OrderQty") %>'></asp:Label>
       
        @ Rs. <asp:Label ID="lblCostedCMT"  runat="server" Text='<%#Eval("CMT") %>'></asp:Label>
      
      
       <span class="stic"> <asp:Label ID="lblFinishingQty"  runat="server" Text='<%#Eval("FinishingQty") %>'></asp:Label>
        &nbsp;&nbsp;(BAL.&nbsp; <asp:Label ID="lblBalance"  runat="server" Text='<%#Eval("BalanceQty") %>'></asp:Label>)
    
    </span>
    </ItemTemplate>
    <FooterTemplate>
    <b> Total </b>
    
    </FooterTemplate>
    </asp:TemplateField>
   <%-- Slot 1--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" >Slot 1</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot1Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblSlot1Pass" runat="server" Text='<%#Eval("Slot1Pass") %>'></asp:Label></td>
     
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <ItemStyle HorizontalAlign="Center" />
   <FooterTemplate>
   <asp:Label ID="lblSlot1Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 2--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" >Slot 2</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot2Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       
        <asp:Label ID="lblSlot2Pass" runat="server" Text='<%#Eval("Slot2Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot2Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 3--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 3</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot3Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot3Pass" runat="server" Text='<%#Eval("Slot3Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot3Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 4--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 4</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot4Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot4Pass" runat="server" Text='<%#Eval("Slot4Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot4Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 5--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 5</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot5Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
   
        <%#Eval("Slot5Pass") %>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot5Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 6--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 6</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot6Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <%#Eval("Slot6Pass") %>
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot6Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 7--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 7</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot7Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <%#Eval("Slot7Pass") %>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot7Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 8--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 8</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot8Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot8Pass" runat="server" Text='<%#Eval("Slot8Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot8Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
 <%-- Slot 9--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 9</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot9Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot9Pass" runat="server" Text='<%#Eval("Slot9Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>

<asp:Label ID="lblSlot9Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 10--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 10</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot10Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot10Pass" runat="server" Text='<%#Eval("Slot10Pass") %>'></asp:Label>
       

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot10Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 11--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 11</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot11Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot11Pass" runat="server" Text='<%#Eval("Slot11Pass") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
 <asp:Label ID="lblSlot11Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 12--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
  <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 12</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot12Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot12Pass" runat="server" Text='<%#Eval("Slot12Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot12Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 13--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 13</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot13Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot13Pass" runat="server" Text='<%#Eval("Slot13Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot13Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
    

      <%-- Slot 14--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 14</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot14Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot14Pass" runat="server" Text='<%#Eval("Slot14Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot14Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
      <%-- Slot 15--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 15</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot15Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot15Pass" runat="server" Text='<%#Eval("Slot15Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot15Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
      <%-- Slot 16--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 16</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot16Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot16Pass" runat="server" Text='<%#Eval("Slot16Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot16Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 17--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 17</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot17Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
  
        <asp:Label ID="lblSlot17Pass" runat="server" Text='<%#Eval("Slot17Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot17Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 18--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 18</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot18Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot18Pass" runat="server" Text='<%#Eval("Slot18Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
     <asp:Label ID="lblSlot18Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 19--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 19</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot19Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot19Pass" runat="server" Text='<%#Eval("Slot19Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot19Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 20--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 20</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot20Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot20Pass" runat="server" Text='<%#Eval("Slot20Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot20Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 21--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 21</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot21Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot21Pass" runat="server" Text='<%#Eval("Slot21Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot21Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 22--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 22</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot22Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       
        <asp:Label ID="lblSlot22Pass" runat="server" Text='<%#Eval("Slot22Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot22Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 23--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 23</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot23Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot23Pass" runat="server" Text='<%#Eval("Slot23Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot23Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 24--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 24</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot24Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot24Pass" runat="server" Text='<%#Eval("Slot24Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot24Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
   <HeaderTemplate>
   Style finished
   </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox ID="chkMarkAsStyle" Checked='<%# Eval("IsFinished") %>' runat="server" />
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40" ItemStyle-CssClass="check_box_text">
 <HeaderTemplate>
   Day fin
   </HeaderTemplate>
    <ItemTemplate>
       <asp:CheckBox ID="chkMarkAsDayClose" Checked='<%# Eval("IsDayClosed") %>' runat="server" />
    </ItemTemplate>
    </asp:TemplateField>

         


    </Columns>
    </asp:GridView>
    <br />
</td>
</tr>

<tr><td id="FinishFact2"  visible="false" runat="server">
<h4 class="fact-name">
    <asp:Label ID="lblFinishUnit2" Visible="false" runat="server" Text="C 45-46"></asp:Label></h4>
    <br />
    </td></tr>
<tr>

<td>
 <asp:GridView ID="gvHourlyFinishingReport2" ShowFooter="true" FooterStyle-HorizontalAlign="Center" ShowHeader="true" 
        RowStyle-Font-Size="9px" HeaderStyle-Font-Size="10px"  CssClass="item_list"
        AutoGenerateColumns="false" runat="server" 
        onrowdatabound="gvHourlyFinishingReport2_RowDataBound" ondatabound="gvHourlyFinishingReport2_DataBound"
         >
  <Columns>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="175px" ItemStyle-HorizontalAlign="Left" > 
      <HeaderTemplate>
    Designation
      </HeaderTemplate>
    <ItemTemplate >
        <asp:Repeater ID="rptDesignation"  runat="server" >
        <ItemTemplate>
         <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-bottom:1px solid #000;">
        <tr><td style="border-right:1px solid #000; color:#45a5e3;  font-size:9px; font-weight:bold; text-align:left; width:60%;">
           <%#Eval("DesignationName") %></td>
             <td style="width:40%; padding-left:5px;"><%#Eval("Name") %></td>
        </tr>
        </table>
        </ItemTemplate>
        </asp:Repeater>
      

    </ItemTemplate>
    </asp:TemplateField>

   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="330px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Efficiency Summery <br />
SAM<br />
OB v/s 
      </HeaderTemplate>
    <ItemTemplate >
      

            <asp:HiddenField ID="hdnStyleId" Value='<%#Eval("StyleID") %>' runat="server" />            
        Target (Actual) Achieved :
    <span class="blue-per"><asp:Label ID="lblTarget" runat="server" Text='<%#Eval("TargetEff") %>'></asp:Label>%&nbsp;
        <asp:Label ID="lblActual" runat="server" Text='<%#Eval("ActualEff") %>'></asp:Label>% &nbsp;
        <asp:Label ID="lblAchieved" runat="server" Text='<%#Eval("ActualAch") %>'></asp:Label>%</span> <br />
   Per pcs cost (Target vs Actual) :
       <b><asp:Label ID="lblTargetCost" Font-Bold="true" runat="server" Text='<%#Eval("TargetPerPieceRate") %>'></asp:Label> &nbsp;Rs. </b>  vs 
       <b> <asp:Label ID="lblActualCost" Font-Bold="true" runat="server" Text='<%#Eval("ActualPerPieceRate") %>'></asp:Label>&nbsp;Rs.</b> <br />
       SAM : <asp:Label ID="lblSAM" runat="server" Text='<%#Eval("FinishingSAM") %>'></asp:Label>       
      
      OB W/S : <asp:Label ID="lblOB" runat="server" CssClass="stic" Text='<%#Eval("OB") %>'></asp:Label>       
            

    </ItemTemplate>
    </asp:TemplateField>

    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       Order Qty @FOB Fin/Stitched
 
      </HeaderTemplate>
    <ItemTemplate >
                
        <asp:Label ID="lblClient" CssClass="blue-per" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
        <asp:Label ID="lblStyleNo"  CssClass="blue-per" runat="server" Text='<%#Eval("StyleNumber") %>'></asp:Label>
       <br /> 
        <asp:Label ID="lblOrderQty"  runat="server" Text='<%#Eval("OrderQty") %>'></asp:Label>
       
        @ Rs. <asp:Label ID="lblCostedCMT"  runat="server" Text='<%#Eval("CMT") %>'></asp:Label>
      
      
       <span class="stic"> <asp:Label ID="lblFinishingQty"  runat="server" Text='<%#Eval("FinishingQty") %>'></asp:Label>
        &nbsp;&nbsp;(BAL.&nbsp; <asp:Label ID="lblBalance"  runat="server" Text='<%#Eval("BalanceQty") %>'></asp:Label>)
    
    </span>
    </ItemTemplate>
    <FooterTemplate>
    <b> Total </b>
    
    </FooterTemplate>
    </asp:TemplateField>
   <%-- Slot 1--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" >Slot 1</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot1Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblSlot1Pass" runat="server" Text='<%#Eval("Slot1Pass") %>'></asp:Label></td>
     
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <ItemStyle HorizontalAlign="Center" />
   <FooterTemplate>
   <asp:Label ID="lblSlot1Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 2--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" >Slot 2</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot2Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       
        <asp:Label ID="lblSlot2Pass" runat="server" Text='<%#Eval("Slot2Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot2Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 3--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 3</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot3Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot3Pass" runat="server" Text='<%#Eval("Slot3Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot3Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 4--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 4</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot4Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot4Pass" runat="server" Text='<%#Eval("Slot4Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot4Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 5--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 5</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot5Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
   
        <%#Eval("Slot5Pass") %>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot5Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 6--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 6</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot6Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <%#Eval("Slot6Pass") %>
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot6Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 7--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 7</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot7Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <%#Eval("Slot7Pass") %>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot7Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 8--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 8</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot8Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot8Pass" runat="server" Text='<%#Eval("Slot8Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot8Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
 <%-- Slot 9--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 9</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot9Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot9Pass" runat="server" Text='<%#Eval("Slot9Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>

<asp:Label ID="lblSlot9Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 10--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 10</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot10Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot10Pass" runat="server" Text='<%#Eval("Slot10Pass") %>'></asp:Label>
       

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot10Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 11--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 11</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot11Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot11Pass" runat="server" Text='<%#Eval("Slot11Pass") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
 <asp:Label ID="lblSlot11Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 12--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
  <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 12</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot12Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot12Pass" runat="server" Text='<%#Eval("Slot12Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot12Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 13--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 13</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot13Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot13Pass" runat="server" Text='<%#Eval("Slot13Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot13Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
    

      <%-- Slot 14--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 14</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot14Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot14Pass" runat="server" Text='<%#Eval("Slot14Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot14Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
      <%-- Slot 15--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 15</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot15Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot15Pass" runat="server" Text='<%#Eval("Slot15Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot15Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
      <%-- Slot 16--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 16</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot16Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot16Pass" runat="server" Text='<%#Eval("Slot16Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot16Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 17--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 17</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot17Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
  
        <asp:Label ID="lblSlot17Pass" runat="server" Text='<%#Eval("Slot17Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot17Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 18--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 18</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot18Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot18Pass" runat="server" Text='<%#Eval("Slot18Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
     <asp:Label ID="lblSlot18Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 19--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 19</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot19Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot19Pass" runat="server" Text='<%#Eval("Slot19Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot19Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 20--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 20</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot20Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot20Pass" runat="server" Text='<%#Eval("Slot20Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot20Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 21--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 21</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot21Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot21Pass" runat="server" Text='<%#Eval("Slot21Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot21Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 22--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 22</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot22Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       
        <asp:Label ID="lblSlot22Pass" runat="server" Text='<%#Eval("Slot22Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot22Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 23--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 23</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot23Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot23Pass" runat="server" Text='<%#Eval("Slot23Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot23Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 24--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 24</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot24Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot24Pass" runat="server" Text='<%#Eval("Slot24Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot24Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
   <HeaderTemplate>
   Style finished
   </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox ID="chkMarkAsStyle" Checked='<%# Eval("IsFinished") %>' runat="server" />
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40" ItemStyle-CssClass="check_box_text">
 <HeaderTemplate>
   Day fin
   </HeaderTemplate>
    <ItemTemplate>
       <asp:CheckBox ID="chkMarkAsDayClose" Checked='<%# Eval("IsDayClosed") %>' runat="server" />
    </ItemTemplate>
    </asp:TemplateField>

         


    </Columns>
    </asp:GridView>
    <br/>
</td>
</tr>

<tr><td id="FinishFact3"  visible="false" runat="server">
<h4 class="fact-name">
    <asp:Label ID="lblFinishUnit3" Visible="false" runat="server" Text="B 45"></asp:Label></h4>
    <br />
    </td></tr>
<tr>

<td>
 <asp:GridView ID="gvHourlyFinishingReport3" ShowFooter="true" FooterStyle-HorizontalAlign="Center" RowStyle-Font-Size="9px" 
        HeaderStyle-Font-Size="10px" ShowHeader="true" 
        AutoGenerateColumns="false" runat="server" 
        onrowdatabound="gvHourlyFinishingReport3_RowDataBound" CssClass="item_list" ondatabound="gvHourlyFinishingReport3_DataBound"
         >
    <Columns>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="175px" ItemStyle-HorizontalAlign="Left" > 
      <HeaderTemplate>
    Designation
      </HeaderTemplate>
    <ItemTemplate >
        <asp:Repeater ID="rptDesignation"  runat="server" >
        <ItemTemplate>
         <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-bottom:1px solid #000;">
        <tr><td style="border-right:1px solid #000; color:#45a5e3;  font-size:9px; font-weight:bold; text-align:left; width:60%;">
           <%#Eval("DesignationName") %></td>
             <td style="width:40%; padding-left:5px;"><%#Eval("Name") %></td>
        </tr>
        </table>
        </ItemTemplate>
        </asp:Repeater>
      

    </ItemTemplate>
    </asp:TemplateField>

   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="330px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      Efficiency Summery <br />
SAM<br />
OB v/s 
      </HeaderTemplate>
    <ItemTemplate >
      

            <asp:HiddenField ID="hdnStyleId" Value='<%#Eval("StyleID") %>' runat="server" />            
        Target (Actual) Achieved :
    <span class="blue-per"><asp:Label ID="lblTarget" runat="server" Text='<%#Eval("TargetEff") %>'></asp:Label>%&nbsp;
        <asp:Label ID="lblActual" runat="server" Text='<%#Eval("ActualEff") %>'></asp:Label>% &nbsp;
        <asp:Label ID="lblAchieved" runat="server" Text='<%#Eval("ActualAch") %>'></asp:Label>%</span> <br />
   Per pcs cost (Target vs Actual) :
       <b><asp:Label ID="lblTargetCost" Font-Bold="true" runat="server" Text='<%#Eval("TargetPerPieceRate") %>'></asp:Label> &nbsp;Rs. </b>  vs 
       <b> <asp:Label ID="lblActualCost" Font-Bold="true" runat="server" Text='<%#Eval("ActualPerPieceRate") %>'></asp:Label>&nbsp;Rs.</b> <br />
       SAM : <asp:Label ID="lblSAM" runat="server" Text='<%#Eval("FinishingSAM") %>'></asp:Label>       
      
      OB W/S : <asp:Label ID="lblOB" runat="server" CssClass="stic" Text='<%#Eval("OB") %>'></asp:Label>       
            

    </ItemTemplate>
    </asp:TemplateField>

    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       Order Qty @FOB Fin/Stitched
 
      </HeaderTemplate>
    <ItemTemplate >
                
        <asp:Label ID="lblClient" CssClass="blue-per" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
        <asp:Label ID="lblStyleNo"  CssClass="blue-per" runat="server" Text='<%#Eval("StyleNumber") %>'></asp:Label>
       <br /> 
        <asp:Label ID="lblOrderQty"  runat="server" Text='<%#Eval("OrderQty") %>'></asp:Label>
       
        @ Rs. <asp:Label ID="lblCostedCMT"  runat="server" Text='<%#Eval("CMT") %>'></asp:Label>
      
      
       <span class="stic"> <asp:Label ID="lblFinishingQty"  runat="server" Text='<%#Eval("FinishingQty") %>'></asp:Label>
        &nbsp;&nbsp;(BAL.&nbsp; <asp:Label ID="lblBalance"  runat="server" Text='<%#Eval("BalanceQty") %>'></asp:Label>)
    
    </span>
    </ItemTemplate>
    <FooterTemplate>
    <b> Total </b>
    
    </FooterTemplate>
    </asp:TemplateField>
   <%-- Slot 1--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" >Slot 1</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot1Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
         
        <asp:Label ID="lblSlot1Pass" runat="server" Text='<%#Eval("Slot1Pass") %>'></asp:Label></td>
     
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <ItemStyle HorizontalAlign="Center" />
   <FooterTemplate>
   <asp:Label ID="lblSlot1Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 2--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
    <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" >Slot 2</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot2Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       
        <asp:Label ID="lblSlot2Pass" runat="server" Text='<%#Eval("Slot2Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot2Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 3--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 3</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot3Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot3Pass" runat="server" Text='<%#Eval("Slot3Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot3Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 4--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
     <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 4</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot4Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot4Pass" runat="server" Text='<%#Eval("Slot4Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot4Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 5--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 5</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot5Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
   
        <%#Eval("Slot5Pass") %>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot5Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 6--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 6</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot6Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <%#Eval("Slot6Pass") %>
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot6Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 7--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 7</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot7Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <%#Eval("Slot7Pass") %>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot7Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

     <%-- Slot 8--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 8</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot8Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot8Pass" runat="server" Text='<%#Eval("Slot8Pass") %>'></asp:Label>

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot8Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
 <%-- Slot 9--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 9</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot9Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot9Pass" runat="server" Text='<%#Eval("Slot9Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>

<asp:Label ID="lblSlot9Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 10--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 10</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot10Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot10Pass" runat="server" Text='<%#Eval("Slot10Pass") %>'></asp:Label>
       

    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot10Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 11--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 11</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot11Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot11Pass" runat="server" Text='<%#Eval("Slot11Pass") %>'></asp:Label>
    </ItemTemplate>
    <ItemStyle CssClass="slot" />
    <FooterTemplate>
 <asp:Label ID="lblSlot11Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

 <%-- Slot 12--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
  <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 12</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot12Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot12Pass" runat="server" Text='<%#Eval("Slot12Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot12Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 13--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 13</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot13Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
     
        <asp:Label ID="lblSlot13Pass" runat="server" Text='<%#Eval("Slot13Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
   <asp:Label ID="lblSlot13Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
    

      <%-- Slot 14--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 14</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot14Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot14Pass" runat="server" Text='<%#Eval("Slot14Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot14Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
      <%-- Slot 15--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 15</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot15Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot15Pass" runat="server" Text='<%#Eval("Slot15Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot15Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
      <%-- Slot 16--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 16</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot16Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot16Pass" runat="server" Text='<%#Eval("Slot16Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
<asp:Label ID="lblSlot16Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 17--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center">Slot 17</td></tr>
      <tr><td align="center"><asp:Label ID="lblSlot17Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
  
        <asp:Label ID="lblSlot17Pass" runat="server" Text='<%#Eval("Slot17Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot17Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 18--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 18</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot18Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot18Pass" runat="server" Text='<%#Eval("Slot18Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
     <asp:Label ID="lblSlot18Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 19--%>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 19</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot19Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot19Pass" runat="server" Text='<%#Eval("Slot19Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot19Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 20--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
       <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 20</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot20Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot20Pass" runat="server" Text='<%#Eval("Slot20Pass") %>'></asp:Label>
    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot20Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 21--%>
   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 21</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot21Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
        
        <asp:Label ID="lblSlot21Pass" runat="server" Text='<%#Eval("Slot21Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot21Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 22--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 22</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot22Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
       
        <asp:Label ID="lblSlot22Pass" runat="server" Text='<%#Eval("Slot22Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
  <asp:Label ID="lblSlot22Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 23--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
        <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 23</td></tr>
      <tr><td align="center" colspan="2"><asp:Label ID="lblSlot23Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot23Pass" runat="server" Text='<%#Eval("Slot23Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot23Total" runat="server" Text=""></asp:Label>
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>

      <%-- Slot 24--%>
     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left"> 
      <HeaderTemplate>
      <table class="slot" width="100%" border="1" frame="VOID" rules="ALL">
      <tr><td align="center" colspan="2">Slot 24</td></tr>
      <tr><td align="center" ><asp:Label ID="lblSlot24Time" runat="server" Text=""></asp:Label></td></tr>
      <tr><td align="center" style="width:100px;">Pcs</td></tr>
     </table>
      </HeaderTemplate>
    <ItemTemplate >
      
        <asp:Label ID="lblSlot24Pass" runat="server" Text='<%#Eval("Slot24Pass") %>'></asp:Label>

    </ItemTemplate>
     <ItemStyle CssClass="slot" />
    <FooterTemplate>
    <asp:Label ID="lblSlot24Total" runat="server" Text=""></asp:Label>
    
    </FooterTemplate>
    <FooterStyle CssClass="bol" />
    </asp:TemplateField>
    
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
   <HeaderTemplate>
   Style finished
   </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox ID="chkMarkAsStyle" Checked='<%# Eval("IsFinished") %>' runat="server" />
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40" ItemStyle-CssClass="check_box_text">
 <HeaderTemplate>
   Day fin
   </HeaderTemplate>
    <ItemTemplate>
       <asp:CheckBox ID="chkMarkAsDayClose" Checked='<%# Eval("IsDayClosed") %>' runat="server" />
    </ItemTemplate>
    </asp:TemplateField>

         


    </Columns>
    </asp:GridView>
</td>
</tr>
</table>
<%--</ContentTemplate></asp:updatepanel>--%>
</td>

</tr>
    <asp:Button ID="btnSendMail" Visible="false" runat="server" Text="Send via Mail" 
        onclick="btnSendMail_Click" />
</table>

</asp:Content>
