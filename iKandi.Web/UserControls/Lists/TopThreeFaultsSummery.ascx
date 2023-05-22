<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopThreeFaultsSummery.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.TopThreeFaultsSummery" %>
<style type="text/css">

  /*  .item_list th
    {
        font-weight: bold;
        background:#dddfe4 !important;
	    color:#575759 !important;
        font-family: verdana;
        font-size:9px;            
    }
    .item_list_Report th
    {
    font-size:10px;
	font-family: arial, halvetica;
	background:#dddfe4 !important;
	color:#575759 !important;
	font-weight:normal;
    border-color:#999999;
    }*/
    .blue
    {
        font-weight: bold;
        color: #3a5695;
        text-align: center;
    }
    .ROWMERGE table tr td 
    {
        border-bottom:0px !important;
    }
    .stic
    {
        color: #5610c7;
        font-weight: normal;
    }
    .WIPRed{
color:red !important;
font-weight:bold !important;
height:14px;
}
.WIPGreen{
color:green !important;
height:14px;
}
    .stic1
    {
        color: red;
        font-weight: normal;
    }
    .blue-per
    {
        color: blue;
    }
    .slot
    {
        text-align: center !important;
        vertical-align: middle;
        border-collapse: collapse;
    }
    .slot-height td
    {
        height:40px !important;
    }
    .slot td
    { 
       
        text-align: center !important;
        vertical-align: middle;
        border:1px solid #bfbfbf;
    }
      .SlotFinish
    {      
        text-align: center !important;
        vertical-align: middle;
    }
  
    .SlotFinish span
    {
        font-weight:bold;
        font-size:12px;
        color:#fff;
    }
    /*.item_list_Report th
    {
        padding: 0px;
        text-transform:capitalize;
    }*/
    
    .item_list_Report th table td
    {
     font-size:9px;
	background:#dddfe4 !important;
	color:#575759 !important;
	font-weight:normal;
        text-transform:capitalize !important;
        border-color:#999999;
    }
    .item_list_Report
    {
        background: #fff;
    }
      .bol td
    {
        color: #3a5695;
        font-weight: normal;
        text-align: center !important;
       
        padding:5px;
    }
     .bol .bol
     {
         text-align: center !important;
        font-size:12px !important;
     }
      .bol td b
      {
          font-size:10px !important;
          text-transform:uppercase !important;
      }
    .item_list_Report td
    {
        font-size: 9px !important;        
        text-align: left;
        padding:0px !important;
        color:Gray;
    }
 
    
    .item_list_Report td table.slot td
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
    .TGT
    {
        border-bottom: 1px solid #000;
    }
    
    .TGT th
    {
        height: 19px;
    }
    .TGT td
    {
        background: none;
        border: 1px solid #bfbfbf;
    }
    h1, h2, h3, h4, h5, h6
    {
        margin: 5px 0px;
        padding: 0px;
    }
  
    .check_box_text
    {
        text-align: center !important;
    }
 
    .fact-name
    {
        background: #3a5695;
        color: #fff;
        text-align: center;
        font-family: arial;
        font-size: 16px;
        padding: 2px 0px;
    }
       .main-table-width h2
       {
           min-width:1000px;
       }
       .empty-msg 
       {
           font-family: Helvetica;
    font-size: 12px !important;
    line-height:24px;    

    text-transform: capitalize;
    border:1px solid #ccc;
    padding:0px 10px;
   
       }
     
       .repeat-div div
       {
           border-bottom:1px solid #ccc;
            padding:2px;
       }
         .repeat-div div:last-child
       {
           border-bottom:0px;
       }
       .gray
       {
           color:Gray;
       }
       .yellow
       {
           color:Yellow !important;
           font-weight:bold;   
           height:20px;        
           text-align:center;
           
       }
        .yellow span
        {
            font-size:10px !important;
        }
          .yellow span:first-child {
    font-size: 11px !important;
}   
        .yellowFactory .yellow
       {
           background: #fff !important;
           font-weight:normal;
           height: 20px;
           text-align:center;
           
       }
       .yellowFactory .yellow span
        {
            font-size:11px !important;
        }
        
         .yellowfooter
       {
           color:Yellow !important;
           font-weight:normal  !important;
           height: 20px;
           text-align:center;
           
       }
        .yellowfooter span
        {
            font-size:10px !important;
        }
        
      .yellowfooter span:first-child {
          font-size: 11px !important;
        } 
        .yellow-pass
        {
              color:Yellow !important;
           font-weight:normal;
           height: 20px;
           text-align:center;
        }
         .yellow-pass span
        {
            font-size:14px !important;
        }
        .bol
        {
            vertical-align:top;
        }
        .line_td td
        {
            border: 1px solid #bfbfbf;
    text-align: center !important;
    vertical-align: middle;
        }
        .line_td
        {
            border-collapse:collapse;
        } 
        .bol .line_td td
        {
            border: none;
        }
      .bol-new {
    border-right-color: #ffffff !important;   
}
    .bol-new {
    border-right-color: #ffffff !important;   
}
.show-table
{
   /* display:inline-table;*
}
.hide-table
{
  /*  display:none;max-height:0; mso-hide:all; overflow:hidden; font-size:0; line-height: 0*/
}
.actObGreen{
color:green;
}
.actObRed{
color:red;
}
.AgrdOBBlack
{
    color:Black;
}
.AgrdOBBlue
{
    color:Blue;
}
.wipstitched
{
   height:14px; 
}
.gray-light span
{
    color:Gray !important;
}
.wipstitched span span
{
    color:Gray !important;       
}
.wipf
{
    height:14px; 
}
.wipf span span
{
    color:Gray !important;      
}
.yellowFactory .today-stitch{
font-weight:normal;
}
.disp-none
{
    display:none;
}
.align-center
{
        text-align:center !important;
}
.Capetlize
{
    text-transform:lowercase;
    text-align:center !important;
    color:Black !important;
    font-weight:bold !important;
}
</style>


<table  cellpadding="0" cellspacing="0" width="100%" Class="item_list_Report">
    <tr>
    <th height="20px">
    <span style="font-size:13px;">Top 3 Faults Summary Report</span>
    </th>
    </tr>
                  
                <tr>
                    <td>
                        <asp:GridView ID="gvHourlyStitchingReport" RowStyle-Font-Size="9px" HeaderStyle-Font-Bold="false"
                            HeaderStyle-Font-Size="10px" ShowHeader="true" ShowFooter="true" 
                            AutoGenerateColumns="false" runat="server"
                            OnRowDataBound="gvHourlyStitchingReport_RowDataBound" 
                            CssClass="item_list_Report" style="margin-top:10px; width:100%;" 
                            ondatabound="gvHourlyStitchingReport_DataBound">
                            <Columns>
                             <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="80" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="gray"  ItemStyle-VerticalAlign="Middle">
                                    <HeaderTemplate>
                                        Unit
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                       <h3 style="font-size:12px; padding:0px; margin:0px; text-align:center;"> <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("FactoryName") %>'></asp:Label>
                                       <asp:Label ID="lblUnitTotal" runat="server" Text=""></asp:Label>
                                        </h3>
                                        <asp:HiddenField ID="hdnEmptyMsg" Value='<%#Eval("EmptyMsg") %>' runat="server" />
                                        <asp:HiddenField ID="hdnserialColorCode" runat="server" Value='<%#Eval("ClientColorCode")%>' />                                                                          
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    <h3 class="slot" style="font-size:12px; padding:0px; margin:0px; text-align:center;">BIPL Total</h3>

                                       
                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-Width="95" HeaderStyle-Width="95" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <table cellpadding="0"  cellspacing="0" border="0" width="100%" frame="void" rules="all"  class="line_td">
                                        <tr>
                                        <td style="text-align:center; width:100%; height:15px;">Line</td>
                                                                         
                                        </tr>
                                        <tr>
                                        <td style="text-align:center; width:100%; height:15px; vertical-align:middle;">Day</td>
                                                                    
                                        </tr>
                                        <tr>
                                        <td style="text-align:center; width:100%; height:16px;">
                                        COT
                                        </td>
                                        
                                        </tr>
                                        </table>
                                        
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnStyleId" Value='<%#Eval("StyleID") %>' runat="server" />
                                        <asp:HiddenField ID="hdnLineNo" Value='<%#Eval("Line_No") %>' runat="server" />
                                       <asp:HiddenField ID="hdnOrderId" runat="server" Value='<%#Eval("OrderID")%>' />     
                                        <asp:HiddenField ID="hdnUnitId" Value='<%#Eval("UnitID") %>' runat="server" />
                                        

                                        <table id="tblEmptyMsg" visible="false" runat="server" cellpadding="0" cellspacing="0" width="100%" border="0" rules="ALL" frame="VOID" class="line_td">
                                            <tr>
                                              <td style="color:Red; padding:10px !important; text-align:center; font-size:14px !important; ">
                                                <asp:Label ID="lblEmptyMsg" runat="server" Text='<%#Eval("EmptyMsg")%>'></asp:Label>
                                              </td>
                                             </tr>
                                        </table>
                                        <table  cellpadding="0" cellspacing="0" width="100%" rules="ALL" frame="VOID" border="0" class="line_td">
                                        <tr>
                                        <td style="text-align:center; width:25%; font-weight:bold; color:Black; height:15px;">       
                                                <asp:Label ID="lblLineNumber" runat="server" Text='<%#Eval("LineNumber")%>'></asp:Label>  
                                        </td>
                                                                                                                 
                                        </tr>
                                        <tr>
                                        <td style="text-align:center; width:25%; color:blue; font-weight:bold; height:15px; vertical-align:top;">
                                        <asp:Label ID="lblProdDay" runat="server" Text='<%#Eval("ProdDay")%>'></asp:Label>
                                        </td>
                                                                         
                                        </tr>
                                        <tr>
                                        <td style="height:15px;">
                                       <asp:Label ID="lblCOT" runat="server" Text="" ForeColor="gray"></asp:Label>
                                        </td>
                                      
                                        </tr>
                                        </table>                                    
                                        
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-Width="95" HeaderStyle-Width="95" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                    <table cellpadding="0"  cellspacing="0" border="0" width="100%" frame="void" rules="all"  class="line_td">
                                        <tr>
                                        
                                        <td style="text-align:center; width:100%; height:15px;">Serial No 
                                            
                                        </td>                                     
                                        </tr>
                                        <tr>
                                        
                                        <td style="text-align:center; width:100%;height:15px; vertical-align:middle;">
                                         H S Name 
                                        
                                         </td>                                     
                                        </tr>
                                        <tr>
                                      
                                        <td style="text-align:center; width:100%;height:16px;">
                                        Style No
                                        </td >
                                        </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    <table id="tblLinePlan" runat="server" cellpadding="0" cellspacing="0" width="100%" rules="ALL" frame="VOID" border="0" class="line_td">
                                        <tr>
                                    
                                        <td runat="server" id="tdserialno"  style="text-align:center;  height:15px; vertical-align:top;">
                                        <font  color="black"> <b> <%#Eval("SerialNumber")%> </b></font>
                                        </td>                                                                           
                                        </tr>
                                        <tr>
                                       
                                        <td style="text-align:center;  height:15px; vertical-align:top;">
                                         <font color="black"> <b> <%#Eval("OperationName")%> </b></font>                                                                             
                                         </td>                                    
                                        </tr>
                                        <tr>
                                      
                                        <td style="text-align:center;  height:15px; vertical-align:top;">
                                        <font color="black"> <%#Eval("StyleNumber")%> </font>
                                        </td>
                                        </tr>
                                        </table>       
                                    
                                    </ItemTemplate>
                                    </asp:TemplateField>
                              
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-Width="45" HeaderStyle-Width="45" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                    DHU                                 
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                   <div style="text-align:center"> <asp:Label class="" ID="lblTodayDHU" runat="server" Text=""></asp:Label>  </div>                                                        
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                     <FooterTemplate>
                                    <div style="text-align:center; width:100%;"> <asp:Label  ID="lblTodayDHU_Foo" runat="server" Text="" ForeColor="Red"></asp:Label> </div>                                                  
                                    </FooterTemplate>
                                    <FooterStyle CssClass="bol" VerticalAlign="Top" HorizontalAlign="Center" />
                                </asp:TemplateField>                             

                                 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-Width="85" HeaderStyle-Width="85" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                    
                                             Inspection
                                                                           
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                     <asp:DataList ID="dlstInspection" Width="100%" runat="server">
                                                <ItemTemplate>
                                                       <%#Eval("InspectionDetails")%>                                                           
                                                               
                                          </ItemTemplate>
                                        </asp:DataList>
                                                                      
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top"
                                    ItemStyle-Width="460" HeaderStyle-Width="460" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                     
                                             Top 3 Faults (Checker) % (Qty. Pcs) 
                                                                            
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                     <asp:DataList ID="dlstFaults" Width="100%" runat="server">
                                                <ItemTemplate>
                                               &nbsp; <span style="color:Black;"> <%#Eval("Faults")%> </span> 
                                                           
                                          </ItemTemplate>
                                        </asp:DataList>
                                                                      
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    <asp:DataList ID="dlstFaultsfoter" Width="100%" runat="server">
                                                <ItemTemplate>
                                               &nbsp; <span style="color:Black;"> <%#Eval("Faults")%> </span> 
                                                           
                                          </ItemTemplate>
                                        </asp:DataList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="460" HeaderStyle-Width="460" >
                                <HeaderTemplate>
                                    
                                             Top 3 Faults (Inspection) % (Qty. Pcs)
                                                                           
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datarepeat">
                                            <asp:Repeater runat="server" ID="rptinceptionC47">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="padding-right: 2px; vertical-align: top; width: 10px; text-align: left;">
                                                         &nbsp;   <asp:Label ID="lblRowSeqC47" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                                        </td>
                                                        <td style="text-align: left; padding-right: 2px;">
                                                            <asp:Label ID="lblFaultNameC47" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                                            <asp:Label ID="lblinceptionC47Per" Text='<%#Eval("FaultPerCentage")%>' runat="server"
                                                                ForeColor="red" Font-Bold="true"></asp:Label>
                                                            <span style="color: Gray">(<asp:Label ID="lblinceptionC47Qty" Text='<%#Eval("Occurrence")%>'
                                                                runat="server" ForeColor="gray"></asp:Label>
                                                                Pcs)</span>
                                                        </td>
                                                        <%--  <td style="padding-right: 5px; vertical-align: top; width:20%">
                                         
                                      </td>--%>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                    <FooterTemplate>
                                     <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datarepeat">
                                            <asp:Repeater runat="server" ID="rptinceptionC47foter">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="padding-right: 2px; vertical-align: top; width: 10px; text-align: left;">
                                                          &nbsp;  <asp:Label ID="lblRowSeqC47" Text='<%#Eval("ID")%>' runat="server" ForeColor="black"></asp:Label>.
                                                            
                                                        </td>
                                                        <td style="text-align: left; padding-right: 2px;">
                                                            <asp:Label ID="lblFaultNameC47" Text='<%#Eval("FaultName")%>' runat="server" ForeColor="black"></asp:Label>
                                                            <asp:Label ID="lblinceptionC47Per" Text='<%#Eval("FaultPerCentage")%>' runat="server"
                                                                ForeColor="red" Font-Bold="true"></asp:Label>
                                                            <span style="color: Gray">(<asp:Label ID="lblinceptionC47Qty" Text='<%#Eval("Occurrence")%>'
                                                                runat="server" ForeColor="gray"></asp:Label>
                                                                Pcs)</span>
                                                        </td>
                                                        <%--  <td style="padding-right: 5px; vertical-align: top; width:20%">
                                         
                                      </td>--%>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </FooterTemplate>
                                </asp:TemplateField>                                
                             
                            </Columns>                           
                            
                        </asp:GridView>
                      
                    </td>
                </tr>
                <tr>
                <td id="Stitch1EmptyMsg" class="empty-msg" runat="server" visible="false">
                  <div style="border-bottom:1px dashed #ccc;">  <asp:Label ID="lblStitch1EmptyMsg1" runat="server" Text=""></asp:Label> </div>

                    <asp:Label ID="lblStitch1EmptyMsg2" runat="server" Text=""></asp:Label>
                </td>
                </tr>
             
            </table>
        

    <asp:Button ID="btnSendMail" Visible="false" runat="server" Text="Send via Mail"
        OnClick="btnSendMail_Click" />