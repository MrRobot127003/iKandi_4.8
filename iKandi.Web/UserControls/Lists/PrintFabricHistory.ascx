<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintFabricHistory.ascx.cs" Inherits="iKandi.Web.PrintFabricHistory" %>
<style>
    .Black
    {
       color:Black;
    }
    .Blue
    {
       color:Blue;
    }
</style>
<script type="text/javascript">
//    $(function() {
//        $("td.style-fabric2", "#main_content").each(function() {
//            var data = $(this).text();

//            if (data == null || data == '')
//                return;
//            alert(data);
//            var fabriArr1;
//            var dataArr = data.split(",");
//            alert("dataArr[0]" + dataArr[0]);
//            alert("dataArr[1]" + dataArr[1]);
//            var html = '';
//            for (i = 0; i < dataArr.length; i++) {
//                var fabriArr = dataArr[i].split("##");
//                alert("fabriArr[0]" + fabriArr[0]);
//                alert("fabriArr[1]" + fabriArr[1]);
//                html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><br/>" + fabriArr[1] + "</div>";
//                alert("html" + html); 
//            }
//            $(this).html(html);

//        });

//    });

</script>

<div  class="form_box">
<div class="form_heading" >
    Fabric Type Details</div>
<br />
<asp:GridView ID="grdFabricHistory" runat="server" AutoGenerateColumns="False" 
    CssClass="item_list " Width=100%  OnRowDataBound="grdFabricHistory_RowDataBound" Visible="false"
    BorderWidth=1px >
    <Columns>

        <asp:TemplateField HeaderText="PRINT #" 
            SortExpression="PrintNumber">
            <ItemTemplate>
                PRD <asp:Label ID="Label2" runat="server" Text='<%# Bind("PrintNumber") %>'></asp:Label>
            </ItemTemplate>
          
        </asp:TemplateField>
        <asp:BoundField DataField="ClientName" HeaderText="Client" 
            SortExpression="ClientName" Visible=false />
        <asp:BoundField DataField="DesignerName" HeaderText="Designer" 
            SortExpression="DesignerName" Visible=false />
            <asp:BoundField DataField="PrintRefNo" HeaderText="Print Reference #" 
            SortExpression="PrintRefNo"  />
        <asp:BoundField DataField="SamplingMerchandiserName" 
            HeaderText="Merchant" 
            SortExpression="SamplingMerchandiserName" Visible=false />            
        <asp:BoundField DataField="MillName" HeaderText="Mill" 
            SortExpression="MillName" />
        <asp:BoundField DataField="MillDesignNumber" HeaderText="Mill Design Number" 
            SortExpression="MillDesignNumber" />
        <asp:BoundField DataField="Fabric" HeaderText="Fabric" 
            SortExpression="Fabric" ItemStyle-CssClass="style-fabric2"/>
        <asp:TemplateField HeaderText="Print Type" SortExpression="PrintType">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%#  (iKandi.Common.PrintType)Convert.ToInt32( Eval("PrintTypeID")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TECHNIQUE OF PRINT" 
            SortExpression="PrintTechnology">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%#  (iKandi.Common.PrintTechnology)Convert.ToInt32( Eval("PrintTechnologyID")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField DataField="QuantityOrdered" HeaderText="QTY (MTRS.) ORDERED" 
            SortExpression="QuantityOrdered" ItemStyle-CssClass="numeric_text" />
        <asp:BoundField DataField="QuantityReceived" HeaderText="QTY (MTRS.) RECEIVED" 
            SortExpression="QuantityReceived"  ItemStyle-CssClass="numeric_text"/>
        <asp:TemplateField HeaderText="Origin" SortExpression="Origin">
            <ItemTemplate>
               <asp:Label ID="Label1" runat="server" Text='<%#  (iKandi.Common.Origin)Convert.ToInt32( Eval("OriginID")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="NumberOfScreens" HeaderText="NO. OF COLS/ SCREENS" 
            SortExpression="NumberOfScreens" />
        <asp:TemplateField HeaderText="EXPTD. RECIEPT DT." >
            <ItemTemplate>
                <asp:Label runat=server CssClass="date_style"
                    Text='<%# (Convert.ToDateTime(Eval("ExpectedReceiptDate")) == DateTime.MinValue)? "" : Eval("ExpectedReceiptDate", "{0:dd MMM yy (ddd)}")     %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ACT. RECIEPT DT." 
            >
            <ItemTemplate>
                <asp:Label runat=server  CssClass="date_style"
                    Text='<%# (Convert.ToDateTime(Eval("ActualReceiptDate")) == DateTime.MinValue)? "" : Eval("ActualReceiptDate", "{0:dd MMM yy (ddd)}")  %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STATUS RECEIVING" ItemStyle-VerticalAlign=Middle  >
            <ItemTemplate>
                <div  >
                    <%# Eval("StatusReceving")%></div>
            </ItemTemplate>
        </asp:TemplateField>  
              

    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odsPrintFabricHistory" runat="server" 
    SelectMethod="GetSamplingFabricByPrintNumber" 
    TypeName="iKandi.BLL.FabricController">
    <SelectParameters>
        <asp:Parameter Name="PrintNumber" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:GridView runat="server" ID="grdSolid" AutoGenerateColumns="False" Width="100%" ShowHeader="false"
CssClass="item_list " > 
<Columns>
 <asp:TemplateField HeaderText="Dyed/ Print/ Digital Print"     >
                               <ItemTemplate>                               
                                      <%#Eval("des")%>
                               </ItemTemplate>                                         
                          </asp:TemplateField> 
</Columns>
</asp:GridView>
</div>
