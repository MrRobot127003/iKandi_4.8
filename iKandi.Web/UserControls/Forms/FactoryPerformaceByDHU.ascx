<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoryPerformaceByDHU.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.FactoryPerformaceByDHU" %>
<style type="text/css">
  .middl2 th
  {
    background: #3a5695 none repeat scroll 0 0;
    color: #fff;
    font-size: 12px;
    font-weight: normal;
    padding: 5px 0;
  }
</style>
<script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>

<%--<script type="text/javascript">
$(window).load(function () {
 $("span").each(function () {        
            var el = $(this);
            var value = parseFloat(el.text());
            
            if (value == 0) {
                el
                 .css("display", "none")
            }
        });
    });
        </script>--%>
 <table width="2500" border="0" cellpadding="0">
  <tr><td colspan="2" style="color:#FFFFFF; height:35px; font-size: 22px; background-color:#3A5695; text-align:center; font-family:Arial;">Factory Performance and Dhu ( By Year Days)</td></tr>
  <tr><td colspan="2" style="height:10px;"></td></tr>
  <tr>
    <td width="180" valign="top">
      <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse; color: Gray; border-color: Gray;">
        <tr><td style="height:49px; background-color:#3A5695; border-left:1px solid Gray; border-right:1px solid #FFFFFF; border-bottom:1px solid Gray;">&nbsp;</td></tr>
        <tr><td style="height:40px; border-left:1px solid Gray; border-bottom:1px solid Gray; border-right:1px solid Gray;">&nbsp;</td></tr>
        <tr><td style="height:78px; border:1px solid Gray;">&nbsp;</td></tr>
        <tr><td style="height:62px; border:1px solid Gray;"><strong>Last 7 Days</strong></td></tr>
        <tr><td style="height:62px; border:1px solid Gray;"><strong>1 Month</strong></td></tr>
        <tr><td style="height:62px; border:1px solid Gray;"><strong>3 Month</strong></td></tr>
        <tr><td style="height:62px; border:1px solid Gray;"><strong>6 Month </strong></td></tr>
        <tr><td style="height:62px; border:1px solid Gray;"><strong>1 Year </strong></td></tr>
      </table>
    </td>
    <td width="2200" valign="top">
      <table width="2200" cellpadding="0" cellspacing="0" style="vertical-align: top;">
        <tr>
          <td  valign="top" width="700">
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse; border-color: Gray;">
              <tr><td style="height:50px; color:#FFFFFF; background-color:#3A5695; border-right:1px solid #FFFFFF; font-size: 16px; text-align:center;">C 45-46</td></tr>
              <tr>
                <td style="height:35">
                  <asp:DataList ID="listline" runat="server" GridLines="Both" RepeatDirection="Horizontal" Width="100%" Height="35" Style="border-collapse: collapse; border-color: Gray; color: Gray;">
                    <ItemTemplate>
                      <asp:Label ID="lbllines" runat="server" Text='<%# Eval("Lines")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50" Height="35px" />
                  </asp:DataList>
                </td>
              </tr>
              <tr>
                <td style="height:78px; background-color:#3A5695; color:#FFFFFF; text-align: center;">
                  <asp:DataList ID="datalist5" runat="server" GridLines="Both" RepeatDirection="Horizontal" Width="100%" Height="78" Style="border-collapse: collapse; border-color: #FFFFFF; color: #FFFFFF;">
                    <ItemTemplate>
                      <span style="font-size: 10px; color: #fff; padding: 5px; text-align: center; font-family: arial;">
                        <asp:Label ID="lbldact" runat="server" Text="Avg Eff<br/>Avg Ach<br/>Avg DHU"></asp:Label>
                      </span>
                    </ItemTemplate>
                    <ItemStyle Height="78px"  />
                  </asp:DataList>
                </td>
              </tr>
              <tr>
                <td>
                  <asp:DataList ID="Datalistreport" runat="server" GridLines="Both" 
                        RepeatDirection="Horizontal" Width="100%"  
                        Style="border-collapse: collapse; border-color: Gray; color: Gray;" 
                        onitemdatabound="Datalistreport_ItemDataBound">
                    <ItemTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td style="border-bottom:1px solid #f0f0f0; height:21px;">
                    <asp:Label ID="lblAvg" runat="server" Text='<%# Eval("AVGEFF")%>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td style="border-bottom:1px solid #f0f0f0; height:21px;">
                    <asp:Label ID="lblAch" runat="server" Text='<%# Eval("AVGACH")%>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <asp:Label ID="lblDhu" runat="server" Text='<%# Eval("AVGDHU")%>'></asp:Label>
                    </td>
                    </tr>
                    </table>
                  
                    </ItemTemplate>
                    <ItemStyle Width="50" HorizontalAlign="Center" Height="60px" VerticalAlign="Top" />
                  </asp:DataList>
                </td>
              </tr>
            </table>
          </td>
          <td valign="top" width="700">
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse; border-color: Gray;">
              <tr><td style="height:50px; color:#FFFFFF; background-color:#3A5695; border-right:1px solid #FFFFFF; font-size: 16px; text-align:center;">C 47</td></tr>
              <tr>
                <td style="height:35px;">
                  <asp:DataList ID="Datalistline1" runat="server" GridLines="Both" RepeatDirection="Horizontal" Width="100%"  Style="border-collapse: collapse; border-color: Gray; color: Gray;">
                    <ItemTemplate>
                      <asp:Label ID="lbllines" runat="server" Text='<%# Eval("Lines")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50" Height="35px" />
                  </asp:DataList>
                </td>
              </tr>
              <tr>
                <td style="height:78px; background-color:#3A5695; color:#FFFFFF; text-align: center;">
                  <asp:DataList ID="datalist" runat="server" GridLines="Both" RepeatDirection="Horizontal" Width="100%"  Style="border-collapse: collapse; border-color: #FFFFFF; color: #FFFFFF;">
                    <ItemTemplate>
                      <span style="font-size: 10px; color: #fff; padding: 5px; text-align: center; font-family: arial;">
                        <asp:Label ID="lbldact" runat="server" Text="Avg Eff<br/>Avg Ach<br/>Avg DHU"></asp:Label>
                      </span>
                    </ItemTemplate>
                    <ItemStyle Height="78px" />
                  </asp:DataList>
                </td>
              </tr>
              <tr>
                <td>
                  <asp:DataList ID="Datalist2" runat="server" GridLines="Both" 
                        RepeatDirection="Horizontal" Width="100%" Height="100%" 
                        Style="border-collapse: collapse; border-color: Gray; color: Gray;" 
                        onitemdatabound="Datalist2_ItemDataBound">
                    <ItemTemplate>

                    
                     <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td style="border-bottom:1px solid #f0f0f0; height:21px;">
                    <asp:Label ID="lblAvg" runat="server" Text='<%# Eval("AVGEFF")%>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td style="border-bottom:1px solid #f0f0f0; height:21px;">
                    <asp:Label ID="lblAch" runat="server" Text='<%# Eval("AVGACH")%>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <asp:Label ID="lblDhu" runat="server" Text='<%# Eval("AVGDHU")%>'></asp:Label>
                    </td>
                    </tr>
                    </table>
                     
                    </ItemTemplate>
                    <ItemStyle Width="50" HorizontalAlign="Center" Height="60px" VerticalAlign="Top" />
                  </asp:DataList>
                </td>
              </tr>
            </table>
          </td>
          <td valign="top" width="700">
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse; border-color: Gray;">
              <tr><td style="height:50px; color:#FFFFFF; background-color:#3A5695; border-right:1px solid #FFFFFF; font-size: 16px; text-align:center;">B 45</td></tr>
              <tr>
                <td style="height:35px; border-right:1px solid Gray;">
                  <asp:DataList ID="DataList3" runat="server" GridLines="Both" RepeatDirection="Horizontal" Width="100%" Height="100%" Style="border-collapse: collapse; border-color: Gray; color: Gray;">
                    <ItemTemplate>
                      <asp:Label ID="lbllines" runat="server" Text='<%# Eval("Lines")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50" Height="35" />
                  </asp:DataList>
                </td>
              </tr>
              <tr>
                <td style="height:78px; background-color:#3A5695; color:#FFFFFF; text-align: center;">
                  <asp:DataList ID="datalist1" runat="server" GridLines="Both" RepeatDirection="Horizontal" Width="100%"  Style="border-collapse: collapse; border-color: #FFFFFF; color: #FFFFFF;">
                    <ItemTemplate>
                      <span style="font-size: 10px; color: #fff; padding: 5px; text-align: center; font-family: arial;">
                        <asp:Label ID="lbldact" runat="server" Text="Avg Eff<br/>Avg Ach<br/>Avg DHU"></asp:Label>
                      </span>
                    </ItemTemplate>
                    <ItemStyle Height="78px" />
                  </asp:DataList>
                </td>
              </tr>
              <tr>
                <td>
                  <asp:DataList ID="Datalist3fact" runat="server" GridLines="Both" 
                        RepeatDirection="Horizontal" Width="100%"  
                        Style="border-collapse: collapse; border-color: Gray; color: Gray;" 
                        onitemdatabound="Datalist3fact_ItemDataBound">
                    <ItemTemplate>

                     <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td style="border-bottom:1px solid #f0f0f0; height:21px;">
                    <asp:Label ID="lblAvg" runat="server" Text='<%# Eval("AVGEFF")%>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                     <td style="border-bottom:1px solid #f0f0f0; height:21px;">
                     <asp:Label ID="lblAch" runat="server" Text='<%# Eval("AVGACH")%>'></asp:Label>
                     </td>
                    </tr>
                    <tr>
                    <td>
                     <asp:Label ID="lblDhu" runat="server" Text='<%# Eval("AVGDHU")%>'></asp:Label>
                    </td>
                    </tr>
                    </table>
                    
                    </ItemTemplate>
                    <ItemStyle Width="50" HorizontalAlign="Center" Height="60px" VerticalAlign="Top"/>
                  </asp:DataList>
                </td>
              </tr>
            </table>
          </td>
          <td width="100" style="max-width:150;" valign="top">
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse; border-color: Gray;">
              <tr><td style="height:50px; color:#FFFFFF; background-color:#3A5695; border-right:1px solid Gray; border-bottom:1px solid Gray; font-size: 16px; text-align:center;">BIPL</td></tr>
              <tr><td style="height:39px; border:1px solid Gray;">&nbsp;</td></tr>
              <tr><td style="height:79px; background-color:#3A5695; color:#FFFFFF;">Best AVG ACHV<br />Avg DHU</td></tr>
              <tr class="mid-head">
                <td>
                  <asp:DataList ID="Datalist4" runat="server" GridLines="Both" Width="100%" 
                        Height="100%" 
                        Style="border-collapse: collapse; border-color: Gray; color: Gray;" 
                        onitemdatabound="Datalist4_ItemDataBound">
                    <ItemTemplate>
                       <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td style="border-bottom:1px solid #f0f0f0; height:31px;">
                    <asp:Label ID="lblAvg" runat="server" Text='<%# Eval("AVGEFF")%>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <asp:Label ID="lblDhu" runat="server" Text='<%# Eval("AVGDHU")%>'></asp:Label>
                    </td>
                    </tr>
                    </table>
                 
                    </ItemTemplate>
                    <ItemStyle Height="60px" HorizontalAlign="Center" VerticalAlign="Top" />
                  </asp:DataList>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  <tr><td colspan="2" style="height:25px;"></td></tr>
</table>