<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="SlotEntryDetailsByDates.aspx.cs" Inherits="iKandi.Web.Internal.Production.SlotEntryDetailsByDates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script language="javascript" type="text/javascript">
        function pageLoad() {

            $(".ZeroCheck").each(function () {
                if ($(this).text() == '' || $(this).text() == '0') {
                    // debugger;
                    $(this).replaceWith("");
                }
            });

        }
        $(document).ready(function () {
            //debugger;
            $(".ZeroCheck").each(function () {
                if ($(this).text() == '' || $(this).text() == '0') {
                    // debugger;
                    $(this).replaceWith("");
                }
            });

        }
 );        
</script>
<style type="text/css">
.item_list td table td{
border: 1px solid #e8e2e2;
}
</style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdateProgress runat="server" ID="pro" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                  <ProgressTemplate>
                    <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                  </ProgressTemplate>
                </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<asp:DropDownList ID="ddlslotdate" AutoPostBack="true" OnSelectedIndexChanged = "OnSelectedIndexChanged"  runat="server"></asp:DropDownList>
<h2 style="background-color: #405D99;     text-align: center; color: #FFFFFF; font-size: 16px;">Hourly Entry</h2>
    <asp:GridView ID="GrdSlotEntry"  OnDataBound="GrdSlotEntry_DataBound"  OnRowDataBound="GrdSlotEntry_RowDataBound" CssClass="item_list"    runat="server" AutoGenerateColumns="false" ShowHeader="true"  >
    <Columns>
    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px"  FooterStyle-CssClass="DeptstayleFooter">
                <HeaderTemplate>
                Factory
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("FactoryName") %>'></asp:Label><br /> 
                    <asp:HiddenField ID="hdnUnit" Value='<%#Eval("UnitID") %>' runat="server" />                   
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                <HeaderTemplate>
                Line No
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Label ID="lblLineNo" runat="server" Text='<%#Eval("LineNos") %>'></asp:Label>                 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="140px" ItemStyle-Width="140px" FooterStyle-CssClass="DeptstayleFooter" >
                <HeaderTemplate>
                Serial Number<br />
                Contract Number<br />
                Qty<br />
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                        <tr>
                            <td style="height: 20px;">
                                <asp:Label ID="lblserial" runat="server" Text='<%#Eval("SerialNumber") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            
                            <td style="height: 20px;">
                                <asp:HyperLink ID="lnkContractNo" Enabled="false" runat="server" Target="_blank" Text='<%#Eval("ContractNumber") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                                <asp:Label ID="Qty" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
              
                   
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 1<br />
               <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                    <asp:Label ID="slot1ob" CssClass="ZeroCheck" runat="server" ForeColor="Gray" Text='<%#Eval("Slot1OB") %>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> <asp:Label ID="slot1passvalue" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot1Pass") %>'></asp:Label> </td>
                    </tr>
                 <tr>
                   <td>
                   <asp:Label ID="lblslot1AltPieces" CssClass="ZeroCheck" ForeColor="Gray" runat="server" Text='<%#Eval("Slot1Alt") %>'></asp:Label>
                   </td>
                 </tr>
                  </table>  
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 2<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot2ob"  CssClass="ZeroCheck" ForeColor="Gray" runat="server" Text='<%#Eval("Slot2OB") %>'></asp:Label><br />
                 
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                          <asp:Label ID="slot2passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot2Pass") %>'></asp:Label><br />
                
                          </td>
                    </tr>
                 <tr>
                   <td>
                     <asp:Label ID="lblslot2AltPieces"  ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot2Alt") %>'></asp:Label>
            
                   </td>
                 </tr>
                  </table>  
                          </ItemTemplate>
                          <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 3<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot3ob"  CssClass="ZeroCheck" ForeColor="Gray" runat="server" Text='<%#Eval("Slot3OB") %>'></asp:Label><br />
                  
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                        <asp:Label ID="slot3passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot3Pass") %>'></asp:Label><br />
                  
                         </td>
                    </tr>
                 <tr>
                   <td>
                     <asp:Label ID="lblslot3AltPieces" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot3Alt") %>'></asp:Label>
            
                   </td>
                 </tr>
                  </table>  
                          </ItemTemplate>
                          <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 4<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot4ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot4OB") %>'></asp:Label><br />
                 
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                         <asp:Label ID="slot4passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot4Pass") %>'></asp:Label><br />
                  
                         </td>
                    </tr>
                 <tr>
                   <td>
                    <asp:Label ID="lblslot4AltPieces" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot4Alt") %>'></asp:Label>
               
                   </td>
                 </tr>
                  </table>  
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 5<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot5ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot5OB") %>'></asp:Label><br />
                  
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                         <asp:Label ID="slot5passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot5Pass") %>'></asp:Label><br />
                 
                         </td>
                    </tr>
                 <tr>
                   <td>
                      <asp:Label ID="lblslot5AltPieces" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot5Alt") %>'></asp:Label>
           
                   </td>
                 </tr>
                  </table> 
                          </ItemTemplate>
                          <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 6<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                  <asp:Label ID="slot6ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot6OB") %>'></asp:Label><br />
                  
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                          <asp:Label ID="slot6passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot6Pass") %>'></asp:Label><br />
                   
                         </td>
                    </tr>
                 <tr>
                   <td>
                     <asp:Label ID="lblslot6AltPieces" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot6Alt") %>'></asp:Label>
               
                   </td>
                 </tr>
                  </table> 
                     </ItemTemplate>
                     <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 7<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot7ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot7OB") %>'></asp:Label><br />
                 
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                         <asp:Label ID="slot7passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot7Pass") %>'></asp:Label><br />
                  
                         </td>
                    </tr>
                 <tr>
                   <td>
                    <asp:Label ID="lblslot7AltPieces" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot7Alt") %>'></asp:Label>
              
                   </td>
                 </tr>
                  </table> 
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 8<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot8ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot8OB") %>'></asp:Label><br />
                 
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                         <asp:Label ID="slot8passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot8Pass") %>'></asp:Label><br />
                 
                         </td>
                    </tr>
                 <tr>
                   <td>
                    <asp:Label ID="lblslot8AltPieces" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot8Alt") %>'></asp:Label>
            
                   </td>
                 </tr>
                  </table> 
                          </ItemTemplate>
                          <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 9<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot9ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot9OB") %>'></asp:Label><br />
                  
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                         <asp:Label ID="slot9passvalue"  ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot9Pass") %>'></asp:Label><br />
                  
                         </td>
                    </tr>
                 <tr>
                   <td>
                    <asp:Label ID="lblslot9AltPieces"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot9Alt") %>'></asp:Label>
               
                   </td>
                 </tr>
                  </table> 
                     </ItemTemplate>
                     <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 10<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot10ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot10OB") %>'></asp:Label><br />
                  
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                          <asp:Label ID="slot10passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot10Pass") %>'></asp:Label><br />
                 
                         </td>
                    </tr>
                 <tr>
                   <td>
                     <asp:Label ID="lblslot10AltPieces" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot10Alt") %>'></asp:Label>
             
                   </td>
                 </tr>
                  </table> 
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 11<br />
                 <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                  <asp:Label ID="slot11ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot11OB") %>'></asp:Label><br />
                  
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                         <asp:Label ID="slot11passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot11Pass") %>'></asp:Label><br />
                 
                         </td>
                    </tr>
                 <tr>
                   <td>
                    <asp:Label ID="lblslot11AltPieces" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot11Alt") %>'></asp:Label>
              
                   </td>
                 </tr>
                  </table> 
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 12<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.<br />
                Alt  Pcs.</div>
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                   <asp:Label ID="slot12ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot12OB") %>'></asp:Label><br />
                   
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"> 
                        <asp:Label ID="slot12passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot12Pass") %>'></asp:Label><br />
                   
                         </td>
                    </tr>
                 <tr>
                   <td>
                     <asp:Label ID="lblslot12AltPieces" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot12Alt") %>'></asp:Label>
               
                   </td>
                 </tr>
                  </table> 
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
               Finishing Qty
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFinsing" runat="server" Text='<%#Eval("TodayPassPcsFinish") %>'></asp:Label><br />
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                   QC Details
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                        <tr>
                            <td style="height: 20px;">
                                Pass
                                <asp:Label ID="lblpass" runat="server" Text='<%#Eval("Pass") %>'></asp:Label>
                            </td>
                            <td style="height: 20px;">
                                Fail
                                <asp:Label ID="lblfail" runat="server" Text='<%#Eval("Fail") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>

                      |  
                </ItemTemplate>
            </asp:TemplateField>
              
    </Columns>
    </asp:GridView>
    <br />
    <br />
    <h2 style="background-color: #405D99;     text-align: center; color: #FFFFFF; font-size: 16px;">Cluster Entry</h2>
    <asp:GridView ID="grdcluster"   OnDataBound="grdcluster_DataBound"      
            runat="server" AutoGenerateColumns="false" ShowHeader="true" 
            CssClass="item_list" onrowdatabound="grdcluster_RowDataBound"  >
    <Columns>
    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px"  FooterStyle-CssClass="DeptstayleFooter">
                <HeaderTemplate>
                Factory
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("FactoryName") %>'></asp:Label><br />                    
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                <HeaderTemplate>
                Cluster Name
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Label ID="lblclustername" runat="server" Text='<%#Eval("Cluster_Name") %>'></asp:Label>                 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="140px" ItemStyle-Width="140px" FooterStyle-CssClass="DeptstayleFooter">
                <HeaderTemplate>
                Serial Number<br />
                Contract Number<br />
                Qty<br />
                </HeaderTemplate>
                <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 20px;">
                    <asp:Label ID="lblserial" runat="server" Text='<%#Eval("SerialNumber") %>'></asp:Label>
                    </td>
                    </tr>
                     <tr>
                        <td style="height: 20px;">                  
                        <asp:HyperLink ID="lnkContractNo" Enabled="false" runat="server" Target="_blank" Text='<%#Eval("ContractNumber") %>' />
                      </td>
                    </tr>
                     <tr>
                        <td style="height: 20px;">
                    <asp:Label ID="Qty" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                    </td>
                    </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 1<br />
               <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
          
                </HeaderTemplate>
                <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                    <asp:Label ID="slot1ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot1OB") %>'></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <asp:Label ID="slot1passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot1Pass") %>'></asp:Label>
                    </td>
                    </tr>
                   </table>
                   <%-- <asp:Label ID="lblslot1AltPieces" runat="server" Text='<%#Eval("Slot1Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 2<br />
               <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
             
                </HeaderTemplate>
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot2ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot2OB") %>'></asp:Label>
                  
                        </td>
                        </tr>
                        <tr>
                    <td>
                    <asp:Label ID="slot2passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot2Pass") %>'></asp:Label>
                  
                    </td>
                    </tr>
                    </table>
                      <%-- <asp:Label ID="lblslot2AltPieces" runat="server" Text='<%#Eval("Slot2Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 3<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
             
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot3ob"  ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot3OB") %>'></asp:Label>
                    
                        </td>
                        </tr>
                        <tr>
                    <td>
                    <asp:Label ID="slot3passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot3Pass") %>'></asp:Label>
              
                    </td>
                    </tr>
                    </table>
                       <%--   <asp:Label ID="lblslot3AltPieces" runat="server" Text='<%#Eval("Slot3Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 4<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
             
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                        <asp:Label ID="slot4ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot4OB") %>'></asp:Label>
                  
                        </td>
                        </tr>
                        <tr>
                    <td>
                     <asp:Label ID="slot4passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot4Pass") %>'></asp:Label>
                
                    </td>
                    </tr>
                    </table>
                      <%--  <asp:Label ID="lblslot4AltPieces" runat="server" Text='<%#Eval("Slot4Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 5<br />
             <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
             
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                          <asp:Label ID="slot5ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot5OB") %>'></asp:Label>
                  
                        </td>
                        </tr>
                        <tr>
                    <td>
                    <asp:Label ID="slot5passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot5Pass") %>'></asp:Label>
                  
                    </td>
                    </tr>
                    </table>
                      <%-- <asp:Label ID="lblslot5AltPieces" runat="server" Text='<%#Eval("Slot5Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 6<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
              
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                        <asp:Label ID="slot6ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot6OB") %>'></asp:Label>
                  
                        </td>
                        </tr>
                        <tr>
                    <td>
                     <asp:Label ID="slot6passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot6Pass") %>'></asp:Label>
                   
                    </td>
                    </tr>
                    </table>
                       <%--<asp:Label ID="lblslot6AltPieces" runat="server" Text='<%#Eval("Slot6Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 7<br />
               <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
              
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot7ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot7OB") %>'></asp:Label>
                 
                        </td>
                        </tr>
                        <tr>
                    <td>
                     <asp:Label ID="slot7passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot7Pass") %>'></asp:Label>
                  
                    </td>
                    </tr>
                    </table>
                     <%--<asp:Label ID="lblslot7AltPieces" runat="server" Text='<%#Eval("Slot7Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 8<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
              
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot8ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot8OB") %>'></asp:Label>
                 
                        </td>
                        </tr>
                        <tr>
                    <td>
                     <asp:Label ID="slot8passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot8Pass") %>'></asp:Label>
                 
                    </td>
                    </tr>
                    </table>
                      <%-- <asp:Label ID="lblslot8AltPieces" runat="server" Text='<%#Eval("Slot8Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 9<br />
               <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
               
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot9ob" ForeColor="Gray"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot9OB") %>'></asp:Label>
                 
                        </td>
                        </tr>
                        <tr>
                    <td>
                     <asp:Label ID="slot9passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot9Pass") %>'></asp:Label>
                 
                    </td>
                    </tr>
                    </table>
                      <%-- <asp:Label ID="lblslot9AltPieces" runat="server" Text='<%#Eval("Slot9Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 10<br />
               <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
              
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot10ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot10OB") %>'></asp:Label>
                  
                        </td>
                        </tr>
                        <tr>
                    <td>
                    <asp:Label ID="slot10passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot10Pass") %>'></asp:Label>
                 
                    </td>
                    </tr>
                    </table>
                        <%-- <asp:Label ID="lblslot10AltPieces" runat="server" Text='<%#Eval("Slot10Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 11<br />
              <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
                
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot11ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot11OB") %>'></asp:Label>
                  
                        </td>
                        </tr>
                        <tr>
                    <td>
                      <asp:Label ID="slot11passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot11Pass") %>'></asp:Label>
                
                    </td>
                    </tr>
                    </table>
                    <%--  <asp:Label ID="lblslot11AltPieces" runat="server" Text='<%#Eval("Slot11Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px"
                HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                 <HeaderTemplate>
                Slot 12<br />
                <div style="color:#777; font-size:10px"> OB<br />
                Pass Pcs.</div>
                
                </HeaderTemplate>
                <ItemTemplate>
                     <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                         <asp:Label ID="slot12ob" ForeColor="Gray" CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot12OB") %>'></asp:Label>
                  
                        </td>
                        </tr>
                        <tr>
                    <td>
                    <asp:Label ID="slot12passvalue"  CssClass="ZeroCheck" runat="server" Text='<%#Eval("Slot12Pass") %>'></asp:Label>
                  
                    </td>
                    </tr>
                    </table>
                       <%--<asp:Label ID="lblslot12AltPieces" runat="server" Text='<%#Eval("Slot12Alt") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Qc Details
            </HeaderTemplate>
            <HeaderStyle Width="74px" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" rules="all" frame="void" width="100%">
                    <tr>
                        <td style="height: 30px;">
                            Pass <asp:Label ID="lblclusterpasscount" runat="server" Text='<%#Eval("Pass") %>'></asp:Label>
                        </td>
                        <td>
                            Fail <asp:Label ID="lblclusterfailcount" runat="server" Text='<%#Eval("Fail") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
