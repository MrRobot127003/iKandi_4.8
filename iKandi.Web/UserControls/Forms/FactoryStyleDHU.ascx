<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoryStyleDHU.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.FactoryStyleDHU" %>
<style type="text/css">
  body
  {
    font-family: verdana;
    font-size: 11px;
    font-weight: normal;
  }
  

  .top-head th
  {
    background: #3a5695;
    font-size: 14px;
    color: #fff;
    padding: 5px 0px;
  }
  .top-head1 th
  {
    padding: 0px;
    background: #3a5695;
    font-size: 14px;
    color: #fff;
  } 
  
    .Heading
  {
   
    Width: 220;
  }
  .mid-head th
  {
    background: #f6f7f9;
    font-weight: normal;
    font-size: 12px;
    color: gray;
    border-right: 1px solid gray;
    width:100%;
  }
  h2
  {
    margin: 0px;
  }
  .mid-head
  {
    background: #f6f7f9;
    font-weight: normal;
    font-size: 12px;
    padding: 3px 0px;
    height: 30px;
  }
  .mid-head td
  {
      width:100%;
  }
  .middl2 th
  {
    background: #3a5695;
    font-weight: normal;
    font-size: 11px;
    padding: 3px 0px;
    padding: 5px 0px;
    color: #fff;
    height: 70px;
  }
  .middl2 td
  {
    height: 60px;
    width:100%;
  }
  tbody td
  {
    text-align: center;
  }
  .red
  {
    color: red;
  }
  .green
  {
    color: green;
  }
  .blue
  {
    color: blue;
  }
  .tot td
  {
    background: lightgrey;
    border-color: #fff;
  }
  .grey
  {
    color: gray;
  }
  .black
  {
    color: black;
    font-weight: bold;
  }
 
  .green-back
  {
    background: green;
  }
 
  .middl-day td
  {
    height: 62px;
  }
  .middl-day th
  {
    background: #3a5695;
    font-weight: normal;
    font-size: 11px;
    padding: 3px 0px;
    padding: 5px 0px;
    color: #fff;
    height: 70px;
  }
  .middl2
  {
      width:100%;
  }
  .line-width
  {
      width:150;
      display:table-cell;
  }
</style>
<%--<script type="text/javascript">

    $(window).load(function () {

        $(".middl2 td span").each(function () {
            var el = $(this);
            var value = parseFloat(el.text());

            if (value == 0) {
                el
                 .css("display", "none")
            }
        });
    });

  

 </script>--%>
<table width="6000px" cellpadding="0" cellspacing="0" border="0" align="center">
  <tr><td colspan="8" style="color:#FFFFFF; height:35px; font-size: 22px; background-color:#3A5695; text-align:center; font-family:Arial; width:100%;">Factory Performance and Dhu ( By Style Days)</td></tr>
  <tr><td colspan="8" style="height:10px; width:100%;"></td></tr>
  <tr>
    <td width="100px" valign="top">
      <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse; color: Gray; border-color: Gray; font-weight:bold; table-layout:fixed;">
        <tr><td style="height:34px; background-color:#3a5695; border-left:1px solid Gray; border-right:1px solid #FFFFFF; border-bottom:1px solid Gray;">&nbsp;</td></tr>
        <tr><td style="height:32px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">&nbsp;</td></tr>
        <tr><td style="height:102px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">&nbsp;</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 1</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 2</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 3</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 4</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 5</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 6</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 7</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 8</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 9</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 10</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 11</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 12</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 13</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">Day 14</td></tr>
        <tr><td style="height:65px; border-left:1px solid Gray; border-bottom:2px solid Gray; border-right:1px solid Gray;">Day 15</td></tr>
      </table>
    </td>
    

<%--    for 1st Factory--%>
    <td valign="top" style="width:1750px">
    
   
      <asp:DataList ID="dtlist1" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" OnItemDataBound="dtlist1_ItemDataBound" CellPadding="0" CellSpacing="0" Width="100%">
        <ItemTemplate>
          <asp:HiddenField ID="hidUnitid" runat="server" Value='<%# Eval("Value")%>' />

          <table width="100%" cellpadding="0" cellspacing="0" border="0">
          <tr>
          <td style="background: #3a5695; font-size: 16px; margin:0px; color: #fff; height:34px;  text-align: center;  font-family: arial; font-weight:normal;"> 
          
           <asp:Label ID="lbldact" runat="server" Text='<%# Eval("key")%>'></asp:Label>
          </td>
          </tr>
          
          </table>


          <asp:DataList ID="dtlist" runat="server" GridLines="Both" RepeatDirection="Horizontal"  OnItemDataBound="dtlist_ItemDataBound" CellPadding="0" CellSpacing="0" Style="border-collapse: collapse; border-color: Gray; color: Gray; width:100%; table-layout:fixed">
            <ItemTemplate>
              <table cellpadding="0" cellspacing="0" style="vertical-align: top;  width:100%;">
                  <tr class="mid-head">
                    <td>
                      <asp:HiddenField ID="hidline" runat="server" Value='<%# Eval("LInes")%>' />
                      <asp:Label ID="lbllines" runat="server" Text='<%# Eval("lll")%>'></asp:Label>
                    </td>
                    <td style="width:1px; background-color:Gray;"></td>
                    <td style="display:none;">
                      <asp:Label ID="lblavg" runat="server" Visible="false" Text="AVG Factory"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                      <asp:GridView ID="Grdeff" runat="server" AutoGenerateColumns="false" onrowdatabound="Grdeff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField  HeaderStyle-Height="95px" ItemStyle-ForeColor="Gray">

                          <HeaderTemplate>
                          <table width="100%" cellpadding="0" cellspacing="0">
                          <tr>
                          <th style="height:15px; padding:0px;"> LineMan</th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> Avg Eff (Best Eff) </th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> QC </th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> Avg DHU (Best Dhu) </th>
                          </tr>
                          
                          
                          </table>
                          
                          </HeaderTemplate>
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px"> 
                            <asp:Label ID="line" runat="server" Text='<%# Eval("lineMan")%>' ForeColor="gray"  ></asp:Label> 
                            </td>
                            </tr>
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px">
                            <asp:Label ID="lblActual" runat="server" Text='<%# Eval("ACtualAvgEFF")%>'></asp:Label> 
                            <asp:Label ID="lblmaxActual" runat="server" Text='<%# Eval("MaxACtualAvgEFF")%>'
                                ForeColor="blue"> </asp:Label> 
                            </td>
                            
                            </tr>
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px">
                            <asp:Label ID="LblQa" runat="server" Text='<%# Eval("QC")%>' ForeColor="gray"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td style="height:15px;"> 
                            <asp:Label ID="LblActualDth" runat="server" Text='<%# Eval("ACtualAvgDHU")%>'></asp:Label>
                              <asp:Label ID="lblmindth" runat="server" Text='<%# Eval("MinACtualAvgDHU")%>' ForeColor="blue"></asp:Label>
                            </td>
                            </tr>
                            
                            </table>
                          
                        
                          
                            
                            </ItemTemplate>
                            <ItemStyle Width="100%" Height="61" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>
                   <%-- <td valign="top" width="70">
                      <asp:GridView ID="grdFactEff" AutoGenerateColumns="false" runat="server" onrowdatabound="grdFactEff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField HeaderText="Avg Eff<br>Avg DHU" HeaderStyle-Height="95px" HeaderStyle-Width="70" ItemStyle-ForeColor="Gray">
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:31px;"> <asp:Label ID="line" runat="server" Text='<%# Eval("AvGEffline")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                            <td style="height:31px;">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ACtualAvgDHUline")%>'></asp:Label> 
                            </td>
                            </tr>
                            </table>
                              
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="70" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>--%>
                  </tr>
                 <%-- <tr>
               
                  
                  
                  </tr>--%>
              </table>
            </ItemTemplate>

            <ItemStyle VerticalAlign="Top"  Width="150px" />
          </asp:DataList>
        </ItemTemplate>

        <ItemStyle VerticalAlign="Top" Width="100%" />
      </asp:DataList>
      </td>
   <td valign="top" style="width:75px">
   <table width="100%" cellpadding="0" cellspacing="0" >
   <tr>
   <td  style="background: #3a5695;  margin:0px;height:35px; border-right: 1px solid #ffffff; ">
   &nbsp;
   </td>
   </tr>

    <tr>
   <td class="mid-head" style="padding:0px;">
Avg Factory
   </td>
   </tr>

    <tr>
   <td>
  <asp:GridView ID="grdFactEff" AutoGenerateColumns="false" runat="server" onrowdatabound="grdFactEff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField HeaderText="Avg Eff<br>Avg DHU" HeaderStyle-Height="95px" HeaderStyle-Width="70" ItemStyle-ForeColor="Gray">
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:31px;"> <asp:Label ID="line" runat="server" Text='<%# Eval("AvGEffline")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                            <td style="height:31px;">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ACtualAvgDHUline")%>'></asp:Label> 
                            </td>
                            </tr>
                            </table>
                              
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="70" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
   </td>
   </tr>
   
   </table>

                     
                    </td>
                    
   
  <%--   End for 1st Factory--%>


  <%--    for 2st Factory--%> 


  <td valign="top" style="width:1750px">
    
   
      <asp:DataList ID="DataList2" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" OnItemDataBound="dtlist1_ItemDataBound" CellPadding="0" CellSpacing="0" Width="100%">
        <ItemTemplate>
          <asp:HiddenField ID="hidUnitid" runat="server" Value='<%# Eval("Value")%>' />

          <table width="100%" cellpadding="0" cellspacing="0" border="0">
          <tr>
          <td style="background: #3a5695; font-size: 16px; margin:0px; color: #fff; height:34px;  text-align: center;  font-family: arial; font-weight:normal;"> 
          
           <asp:Label ID="lbldact" runat="server" Text='<%# Eval("key")%>'></asp:Label>
          </td>
          </tr>
          
          </table>


          <asp:DataList ID="dtlist" runat="server" GridLines="Both" RepeatDirection="Horizontal"  OnItemDataBound="dtlist_ItemDataBound" CellPadding="0" CellSpacing="0" Style="border-collapse: collapse; border-color: Gray; color: Gray; width:100%; table-layout:fixed">
            <ItemTemplate>
              <table cellpadding="0" cellspacing="0" style="vertical-align: top;  width:100%;"">
                  <tr class="mid-head">
                    <td>
                      <asp:HiddenField ID="hidline" runat="server" Value='<%# Eval("LInes")%>' />
                      <asp:Label ID="lbllines" runat="server" Text='<%# Eval("lll")%>'></asp:Label>
                    </td>
                    <td style="width:1px; background-color:Gray;"></td>
                    <td style="display:none;">
                      <asp:Label ID="lblavg" runat="server" Visible="false" Text="AVG Factory"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                      <asp:GridView ID="Grdeff" runat="server" AutoGenerateColumns="false" onrowdatabound="Grdeff_RowDataBound" CssClass="middl2" >
                        <Columns>
                          <asp:TemplateField  HeaderStyle-Height="95px" ItemStyle-ForeColor="Gray">

                          <HeaderTemplate>
                          <table width="100%" cellpadding="0" cellspacing="0">
                          <tr>
                          <th style="height:15px; padding:0px;"> LineMan</th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> Avg Eff (Best Eff) </th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> QC </th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> Avg DHU (Best Dhu) </th>
                          </tr>
                          
                          
                          </table>
                          
                          </HeaderTemplate>
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px"> 
                            <asp:Label ID="line" runat="server" Text='<%# Eval("lineMan")%>' ForeColor="gray"  ></asp:Label> 
                            </td>
                            </tr>
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px">
                            <asp:Label ID="lblActual" runat="server" Text='<%# Eval("ACtualAvgEFF")%>'></asp:Label> 
                            <asp:Label ID="lblmaxActual" runat="server" Text='<%# Eval("MaxACtualAvgEFF")%>'
                                ForeColor="blue"> </asp:Label> 
                            </td>
                            
                            </tr>
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px">
                            <asp:Label ID="LblQa" runat="server" Text='<%# Eval("QC")%>' ForeColor="gray"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td style="height:15px;"> 
                            <asp:Label ID="LblActualDth" runat="server" Text='<%# Eval("ACtualAvgDHU")%>'></asp:Label>
                              <asp:Label ID="lblmindth" runat="server" Text='<%# Eval("MinACtualAvgDHU")%>' ForeColor="blue"></asp:Label>
                            </td>
                            </tr>
                            
                            </table>
                          
                        
                          
                            
                            </ItemTemplate>
                            <ItemStyle Width="100%" Height="61" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>
                   <%-- <td valign="top" width="70">
                      <asp:GridView ID="grdFactEff" AutoGenerateColumns="false" runat="server" onrowdatabound="grdFactEff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField HeaderText="Avg Eff<br>Avg DHU" HeaderStyle-Height="95px" HeaderStyle-Width="70" ItemStyle-ForeColor="Gray">
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:31px;"> <asp:Label ID="line" runat="server" Text='<%# Eval("AvGEffline")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                            <td style="height:31px;">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ACtualAvgDHUline")%>'></asp:Label> 
                            </td>
                            </tr>
                            </table>
                              
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="70" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>--%>
                  </tr>
                 <%-- <tr>
               
                  
                  
                  </tr>--%>
              </table>
            </ItemTemplate>

            <ItemStyle VerticalAlign="Top" Width="150px"  />
          </asp:DataList>
        </ItemTemplate>

        <ItemStyle VerticalAlign="Top" Width="100%" />
      </asp:DataList>
      </td>
   <td valign="top" style="width:75px">



    <table width="100%" cellpadding="0" cellspacing="0">
   <tr>
   <td  style="background: #3a5695;  margin:0px;height:35px; border-right: 1px solid #ffffff; ">
   &nbsp;
   </td>
   </tr>

    <tr>
   <td class="mid-head" style="padding:0px;">
Avg Factory
   </td>
   </tr>

    <tr>
   <td width="70">

                      <asp:GridView ID="GrdEff2" AutoGenerateColumns="false" runat="server" onrowdatabound="grdFactEff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField HeaderText="Avg Eff<br>Avg DHU" HeaderStyle-Height="95px" HeaderStyle-Width="70" ItemStyle-ForeColor="Gray">
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:31px;"> <asp:Label ID="line" runat="server" Text='<%# Eval("AvGEffline")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                            <td style="height:31px;">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ACtualAvgDHUline")%>'></asp:Label> 
                            </td>
                            </tr>
                            </table>
                              
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="100%" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>
                    </tr>
                    </table>
                    </td>





    <%--   End for 2st Factory--%>


    <%--    for 3st Factory--%> 
    <td valign="top" style="width:1750px;">
    
   
      <asp:DataList ID="DataList3" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" OnItemDataBound="dtlist1_ItemDataBound" CellPadding="0" CellSpacing="0" Width="100%" >
        <ItemTemplate>
          <asp:HiddenField ID="hidUnitid" runat="server" Value='<%# Eval("Value")%>' />

          <table width="100%" cellpadding="0" cellspacing="0" border="0">
          <tr>
          <td style="background: #3a5695; font-size: 16px; margin:0px; color: #fff; height:34px;  text-align: center;font-family: arial; font-weight:normal;"> 
          
           <asp:Label ID="lbldact" runat="server" Text='<%# Eval("key")%>'></asp:Label>
          </td>
          </tr>
          
          </table>


          <asp:DataList ID="dtlist" runat="server" GridLines="Both" RepeatDirection="Horizontal"  OnItemDataBound="dtlist_ItemDataBound" CellPadding="0" CellSpacing="0" Style="border-collapse: collapse; border-color: Gray; color: Gray; width:100%; table-layout:fixed">
            <ItemTemplate>
              <table cellpadding="0" cellspacing="0" style="vertical-align: top;  width:100%;"">
                  <tr class="mid-head">
                    <td>
                      <asp:HiddenField ID="hidline" runat="server" Value='<%# Eval("LInes")%>' />
                      <asp:Label ID="lbllines" runat="server" Text='<%# Eval("lll")%>'></asp:Label>
                    </td>
                    <td style="width:1px; background-color:Gray;"></td>
                    <td style="display:none;">
                      <asp:Label ID="lblavg" runat="server" Visible="false" Text="AVG Factory"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                      <asp:GridView ID="Grdeff" runat="server" AutoGenerateColumns="false" onrowdatabound="Grdeff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField  HeaderStyle-Height="95px" ItemStyle-ForeColor="Gray">

                          <HeaderTemplate>
                          <table width="100%" cellpadding="0" cellspacing="0">
                          <tr>
                          <th style="height:15px; padding:0px;"> LineMan</th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> Avg Eff (Best Eff) </th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> QC </th>
                          </tr>
                          <tr>
                          <th style="height:15px; padding:0px;"> Avg DHU (Best Dhu) </th>
                          </tr>
                          
                          
                          </table>
                          
                          </HeaderTemplate>
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px"> 
                            <asp:Label ID="line" runat="server" Text='<%# Eval("lineMan")%>' ForeColor="gray"  ></asp:Label> 
                            </td>
                            </tr>
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px">
                            <asp:Label ID="lblActual" runat="server" Text='<%# Eval("ACtualAvgEFF")%>'></asp:Label> 
                            <asp:Label ID="lblmaxActual" runat="server" Text='<%# Eval("MaxACtualAvgEFF")%>'
                                ForeColor="blue"> </asp:Label> 
                            </td>
                            
                            </tr>
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:15px">
                            <asp:Label ID="LblQa" runat="server" Text='<%# Eval("QC")%>' ForeColor="gray"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td style="height:15px;"> 
                            <asp:Label ID="LblActualDth" runat="server" Text='<%# Eval("ACtualAvgDHU")%>'></asp:Label>
                              <asp:Label ID="lblmindth" runat="server" Text='<%# Eval("MinACtualAvgDHU")%>' ForeColor="blue"></asp:Label>
                            </td>
                            </tr>
                            
                            </table>
                          
                        
                          
                            
                            </ItemTemplate>
                            <ItemStyle Width="100%" Height="61" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>
                   <%-- <td valign="top" width="70">
                      <asp:GridView ID="grdFactEff" AutoGenerateColumns="false" runat="server" onrowdatabound="grdFactEff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField HeaderText="Avg Eff<br>Avg DHU" HeaderStyle-Height="95px" HeaderStyle-Width="70" ItemStyle-ForeColor="Gray">
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:31px;"> <asp:Label ID="line" runat="server" Text='<%# Eval("AvGEffline")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                            <td style="height:31px;">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ACtualAvgDHUline")%>'></asp:Label> 
                            </td>
                            </tr>
                            </table>
                              
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="70" />
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>--%>
                  </tr>
                 <%-- <tr>
               
                  
                  
                  </tr>--%>
              </table>
            </ItemTemplate>

            <ItemStyle VerticalAlign="Top" Width="150px" />
          </asp:DataList>
        </ItemTemplate>

        <ItemStyle VerticalAlign="Top" Width="100%" />
      </asp:DataList>
      </td>
   <td valign="top" style="width:75px">
     <table width="100%" cellpadding="0" cellspacing="0">
   <tr>
   <td  style="background: #3a5695;  margin:0px;height:35px; border-right: 1px solid #ffffff; ">
   &nbsp;
   </td>
   </tr>

    <tr>
   <td class="mid-head" style="padding:0px;">
Avg Factory
   </td>
   </tr>

    <tr>
   <td width="100">
                   
                    
                      <asp:GridView ID="grdeff3" AutoGenerateColumns="false" runat="server" onrowdatabound="grdFactEff_RowDataBound" CssClass="middl2">
                        <Columns>
                          <asp:TemplateField HeaderText="Avg Eff<br>Avg DHU" HeaderStyle-Height="95px" ItemStyle-ForeColor="Gray">
                            <ItemTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                            <td style="border-bottom:1px solid #dfdfdf; height:31px;"> <asp:Label ID="line" runat="server" Text='<%# Eval("AvGEffline")%>'></asp:Label>  </td>
                            </tr>
                            <tr>
                            <td style="height:31px;">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ACtualAvgDHUline")%>'></asp:Label> 
                            </td>
                            </tr>
                            </table>
                              
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top"/>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </td>
                    </tr>
                    </table>
                    </td>


    <%--   End for 3st Factory--%>
   
    <td valign="top" style="border-bottom:1px solid Gray; width:300px">

    <table cellpadding="0" cellspacing="0" width="100%"> 
    <tr>
    <td style="background: #3a5695; font-size: 16px; color: #fff;  text-align: center;  height:34px; margin:0px; border-right: 1px solid #FFFFFF; font-family: arial; font-weight:normal;">
    
    BIPL
    </td>
    
    </tr>
    
    </table>
     
      <asp:GridView ID="grdFactEffBIPL" AutoGenerateColumns="false" runat="server" CssClass="middl2 middle-last" onrowdatabound="grdFactEffBIPL_RowDataBound" style="table-layout:fixed">
        <Columns>
          <asp:TemplateField HeaderText="Avg Eff<br>Avg DHU" ItemStyle-ForeColor="Gray"  HeaderStyle-Width="75" ControlStyle-Width="100%" HeaderStyle-Height="115px" HeaderStyle-BackColor="#3a5695" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#ffffff">
            <ItemTemplate>
              <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                  <td style="border-bottom:1px solid #dfdfdf; height:31px;">
                    <asp:Label ID="line" runat="server" Text='<%# Eval("AVFEFFBIPL")%>'></asp:Label>
                </td>

                <tr>
                <td style="height:31px;">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AVGDHUBIPL")%>'></asp:Label>
                </td>
                </tr>
                    
                 
                </tr>
              </table>
            </ItemTemplate>
            <ItemStyle VerticalAlign="Top" Width="65" Height="60px" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Best Avg Eff<br>BEST Avg DHU" ItemStyle-ForeColor="Gray" HeaderStyle-Width="75"  HeaderStyle-Height="115px" HeaderStyle-BackColor="#3a5695" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#ffffff">
            <ItemTemplate>
              <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                  <td style="border-bottom:1px solid #dfdfdf; height:31px;">
                    <asp:Label ID="lineName" runat="server" Text='<%# Eval("Line")%>'></asp:Label>
                    <asp:Label ID="linemenname" runat="server" Text='<%# Eval("LineMen")%>'></asp:Label>
                    <asp:Label ID="linemaxAvg" runat="server" Text='<%# Eval("BIPLmaxAVG")%>'> </asp:Label>
                  </td>
                  </tr>
                  <tr>
                  <td style="height:31px;"> 
                  
                  
                    <asp:Label ID="lblFactory" runat="server" Text='<%# Eval("UNITMANE")%>'></asp:Label>
                    <asp:Label ID="lblmaxDHU" runat="server" Text='<%# Eval("BIPLmaxDHU")%>'></asp:Label>
                 </td>
                  </tr>
              
              </table>
            </ItemTemplate>
            <ItemStyle VerticalAlign="Top" Width="95" Height="60px" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Best Day Avg Eff<br>BEST DAY Avg DHU" ItemStyle-ForeColor="Gray" HeaderStyle-Width="75"  HeaderStyle-Height="125px" HeaderStyle-BackColor="#3a5695" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#ffffff">
            <ItemTemplate>
              <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                  <td style="border-bottom:1px solid #dfdfdf; height:31px;">
                    <asp:Label ID="lblbestAvg" runat="server" Text='<%# Eval("BestAVGAFBIPL")%>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td style="height:31px;">
               
                    <asp:Label ID="lblbestDhu" runat="server" Text='<%# Eval("BESTDHUBIPL")%>'></asp:Label>
                    </td>
                </tr>
              </table>
            </ItemTemplate>
            <ItemStyle VerticalAlign="Top" Width="65" Height="60px" />
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </td>
  </tr>
</table>