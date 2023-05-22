<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkflowHistory.ascx.cs"
    Inherits="iKandi.Web.WorkflowHistory" %>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
 .AddClass_Table th {
  font-size:12px !important;
}
.AddClass_Table td {
    border: 1px solid #dbd8d8; 
    padding: 5px 5px !important;
  
}
.AddClass_Table td.LeftAlign {
  text-align:left;
}
.AddClass_Table
{
    width:99%;
    margin:1px auto;
 }
 .form_heading
 {
    color:#f2f2f2;
    text-transform: capitalize;

  }
.sticky_hesder tbody tr:first-child
{
    position:sticky;
    top:25px;
    }
     </style>
<div class="form_box">
<div class="form_heading" style="position: sticky;top:0;">
        Tracking<asp:Label ID="lblBuyingHouse" Visible="false" runat="server" Text=''></asp:Label>
    </div>
    <asp:GridView ID="grdWorkflowHistory" runat="server"  AutoGenerateColumns="false"
        CssClass="AddClass_Table fixed-header sticky_hesder" 
        OnRowDataBound="grdWorkflowHistory_RowDataBound" 
        ondatabound="grdWorkflowHistory_DataBound">
        <Columns>
            
              <asp:TemplateField HeaderText="" SortExpression="" Visible="false" >
                <ItemTemplate>
                    <asp:Label ID="lblColor" runat="server" Text=''></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Target" SortExpression="">
                <ItemTemplate>
                    <asp:Label ID="lblETA1" runat="server" CssClass="date_style" Text='<%# Eval("ETA", "{0:dd MMM yy (ddd)}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="">
                <ItemTemplate> 
                   <%-- <asp:Label ID="lblStatusMode" runat="server" Text='<%# ((iKandi.Common.TaskMode)Convert.ToInt32( Eval("StatusModeID"))).ToString() %>'></asp:Label>--%>
                       <asp:Label ID="lblStatusMode" runat="server" Text='<%# Eval("ModeName")%>'  ></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="LeftAlign" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action" SortExpression="" ItemStyle-CssClass="font_color_blue">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" CssClass="date_style"  Text='<%# (Convert.ToDateTime(Eval("ActionDate")) == DateTime.MinValue)? "" : Eval("ActionDate", "{0:dd MMM yy (ddd)}") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
          
        </Columns>
        
    </asp:GridView>
</div>

<div>
    <table border="0" cellspacing="3">
        <tr>
            <td colspan="5" style="border:0px !important;padding-left:2px !important">
                   <span style="width:12px;height:12px;background-color:Green;display: inline-block; position: relative; top: 2px;border-radius: 2px;padding-left:2px;"> </span><span  style="display:inline-block;width:53px; padding-left: 3px;"> On Time</span>
                    <span style="width:12px;height:12px;background-color:Red; display: inline-block; position: relative; top: 2px;border-radius: 2px;"> </span><span  style="display:inline-block;width:53px; padding-left: 3px;"> Delayed</span>
                     <span style="width:12px;height:12px;background-color:Yellow; display: inline-block; position: relative; top: 2px;border-radius: 2px;"> </span><span  style="display:inline-block;width:53px; padding-left: 3px;"> Expected</span>
             
            </td>
           <%-- <td> On Time </td>
             <td style="background-color:Red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td> Delayed </td>
             <td style="background-color:Yellow">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td> Expected </td>--%>
            <td  style="border:0px !important;"> 
           <%-- <td>--%> 
                <asp:HiddenField ID="hiddenOrderDetailId" Value="-1" runat="server" /> 
                <span id="spanCancel" runat="server" visible="false">
                <a id="lnkCancel" style="text-decoration:underline; color:Blue; cursor:pointer" onclick="showRemarks(0,'<%= hiddenOrderDetailId.Value %>','Merchant Remarks','MERCHANT_REMARKS','LIABILITY','0')" > Cancel  </a>
                </span>
            </td>
             <td  style="border:0px !important;"> 
          <%-- <td> --%>
              <span id="spanOnHold" runat="server" visible="false" >
               <a id="lnlOnHold" style="text-decoration:underline; color:Blue; cursor:pointer" onclick="showRemarks('<%= hiddenOrderDetailId.Value %>',0,'On Hold Remarks','MerchantNotes','MANAGE_ORDER_FILE','0','0')" > On Hold </a>
               </span>
               <span id="spanUnhold" runat="server" visible="false">
               <a style="text-decoration:underline; color:Blue; cursor:pointer" id="lnkUnhold" onclick="showRemarks('<%= hiddenOrderDetailId.Value %>',0,'Unhold order Remarks','MerchantNotes','MANAGE_ORDER_FILE','1','2')" > Unhold</a>
              </span>
            </td>
        </tr>
    </table>
</div>