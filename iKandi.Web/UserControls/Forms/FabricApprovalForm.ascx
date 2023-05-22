<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricApprovalForm.ascx.cs"
    Inherits="iKandi.Web.FabricApprovalForm" %>

<script type="text/javascript">

var ddlApprovalStatusLabDipClientID = '<%=ddlApprovalStatusLabDip.ClientID %>';
var chkBoxSameAsOriginalLabDipClientID = '<%=chkBoxSameAsOriginalLabDip.ClientID %>';
var ddlApprovalStatusBulkClientID = '<%=ddlApprovalStatusBulk.ClientID %>';


$(function() {
    $(".loadingimage").hide();
     var elements = $('input.elementsToOperateOn, select.elementsToOperateOn, textarea.elementsToOperateOn','#main_content');
     var elementsEnabled = $('input.elementsToEnable, select.elementsToEnable, textarea.elementsToEnable','#main_content');
     
     $('#trBulkActual','#main_content').hide();

     $("#"+chkBoxSameAsOriginalLabDipClientID,'#main_content').click(function(){
       var checked = this.checked;
       for(var i = 0; i < elements.length; i++)
        {  
          if(checked==true)
            {
             $("#"+elements[i].id).attr('disabled', true);
             var currentDate = new Date();
             var dt1 = ParseDateToDateWithDay(currentDate);
             $('#<%=lblLabDipApprovalActual.ClientID %>','#main_content').html(dt1);
             $('#<%=lblLabDip.ClientID %>','#main_content').removeClass("hide_me");
             $('#trLabDipActual','#main_content').show(); 
             
            }
            else
            {
             $("#"+elements[i].id).removeAttr('disabled');
             $('#<%=lblLabDipApprovalActual.ClientID %>','#main_content').html("");
             $('#<%=lblLabDip.ClientID %>','#main_content').addClass("hide_me");
             $('#trLabDipActual','#main_content').hide();
            }
        }
         if(checked==true)
         {
           $('#<%=txtSentDateBulk.ClientID %>','#main_content').val("");
           for(var i = 0; i < elementsEnabled.length; i++)
            {  
                 $("#"+elementsEnabled[i].id).removeAttr('disabled');
            }
         }
        else
         {
           $('#<%=txtSentDateBulk.ClientID %>','#main_content').val(ParseDateToDateWithDay(new Date()));
           for(var i = 0; i < elementsEnabled.length; i++)
            {  
                 $("#"+elementsEnabled[i].id).attr('disabled', true);
            }
         }
       
     });

    
//    $("#"+ddlApprovalStatusLabDipClientID).change(function(){
//       var index =  this.selectedIndex;
//       if(( this.options[index].value)==3)
//       {
////           $('#<%=txtSentDateLabDip.ClientID %>').val("");
////           $('#<%=txtDhlNumberLabDip.ClientID %>').val("");
////           $('#<%=txtRemarksLabDip.ClientID %>').val("");
//           for(var i = 0; i < elementsEnabled.length; i++)
//            {  
//              $("#"+elementsEnabled[i].id).attr('disabled', true);
//            }
//       }
//       else if((this.options[index].value)==2)
//       {
//           for(var i = 0; i < elementsEnabled.length; i++)
//            {  
//              $("#"+elementsEnabled[i].id).removeAttr('disabled');
//            }
//       }
//       else if((this.options[index].value)==1)
//       {
//          for(var i = 0; i < elementsEnabled.length; i++)
//            {  
//              $("#"+elementsEnabled[i].id).attr('disabled', true);
//            }        
//       }
//       
//     });
     
     $("#"+ddlApprovalStatusBulkClientID).change(function(){
       var index =  this.selectedIndex;
       if(( this.options[index].value)==3)
       {
           
       }
       else if((this.options[index].value)==2)
       {
           var currentDate = new Date();
           var dt1 = ParseDateToDateWithDay(currentDate);
           $('#<%=lblBulkApprovalActual.ClientID %>','#main_content').html(dt1);
           $('#trBulkActual','#main_content').show();
       }
       
     });

});





function PrintPDFApp(Url, height, width) {  
    $(".loadingimage").show();
    $(".print").hide();
    var url;
    var ht = parseInt($(document).height()) - 130;
    var wd = parseInt($(document).width()) - 100;


    if (height != '' && height != null) {

        ht = height;

    }

    if (width != '' && width != null) {

        wd = width;

    }


    if (Url == '' || Url == null) {

        url = window.location.pathname;

    }

    else {

        url = Url;

    }


    if (url.indexOf('/') != 0)

        url = '/' + url;    
    proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {


        if ($.trim(result) == '') {

            //$.hideprogress();

            jQuery.facebox("Some error occured on the server, please try again later.");

        }

        else {
            //$.hideprogress();
            
            
            window.open(result);
            $(".loadingimage").hide();
            $(".print").show();
        }

    });


    return false;

}










</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
  .grid_heading {
    color: #fff;
    font-size: 16px;
    background-color: #39589c;
    color: #ffffff !important;
    text-align:center;
    padding:5px 0px;
     text-transform: capitalize;
}
h2
{
 color: #39589c;
 font-size: 12px;
 margin:0px;
 padding:0px;
  text-transform: capitalize;
}
.item_list {

    border-color:#ccc;
}
.item_list td {

    border-color:#ccc;
}
.item_list TD input[type="text"], .item_list TD textarea 
{
    text-align:left;
}
.item_list th {
    padding-left: 8px !important;
}
   
</style>
<asp:Panel runat="server" ID="pnlForm">
    <div class="print-box">
        <div class="form_box">
            <div class="grid_heading">
                <asp:Label runat="server" ID="lblApprovalHeading"></asp:Label><br />
                <asp:Label runat="server" ID="lblApprovalHeadingCCGSM" Font-Size="Smaller" ForeColor="Black"></asp:Label>
            </div>
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td width="100%" align="center">
                        <asp:GridView CssClass="item_list" ID="GridView1" runat="server" AutoGenerateColumns="False"
                            OnRowDataBound="GridView1_RowDataBound" 
                            >
                            <Columns>
                                <asp:TemplateField HeaderText="Order Date" ItemStyle-CssClass="date_style">
                                    <ItemTemplate>
                                        <span>
                                            <%--<%# ((Eval("ParentOrder") as iKandi.Common.Order).OrderDate).ToString("dd MMM yy (ddd)")%>--%>
                                            <%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd) ")%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Serial No.">
                                    <ItemTemplate>
                                        <span>
                                            <asp:HiddenField ID="hdnSerial" runat="server" />
                                            <%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dept.">
                                    <ItemTemplate>
                                        <span>
                                            <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.DepartmentName%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Style No.">
                                    <ItemTemplate>
                                        <span>
                                            <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"
                                    ItemStyle-CssClass="numeric_text" DataFormatString="{0:N0}" />
                                <asp:BoundField DataField="Fabric1Quantity" HeaderText="Fabric Ordered" SortExpression="Fabric1Quantity"
                                    DataFormatString="{0:N0}" />
                                <asp:TemplateField HeaderText="L.D/S.O Approval Target" ItemStyle-CssClass="date_style">
                                    <ItemTemplate>
                                        <span>
                                            <%# (Convert.ToDateTime((Eval("LabDipTarget"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("LabDipTarget"))).ToString("dd MMM yy (ddd)"))%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bulk Approval Target" ItemStyle-CssClass="date_style">
                                    <ItemTemplate>
                                        <span>
                                            <%# (Convert.ToDateTime((Eval("BulkApprovalTarget"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("BulkApprovalTarget"))).ToString("dd MMM yy (ddd)"))%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bulk In House Target" ItemStyle-CssClass="date_style">
                                    <ItemTemplate>
                                        <span>
                                            <%# (Convert.ToDateTime((Eval("BulkTarget"))) == DateTime.MinValue) ? "" : (Convert.ToDateTime((Eval("BulkTarget"))).ToString("dd MMM yy (ddd)"))%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table width="100%" border="1px" class="item_list">
                <tr>
                    <td colspan="3" width="100%" align="center">
                        <div class="form_small_heading">
                           <h2>Lab Dip/Strike Off Approval target
                            <asp:Label ID="lblLabDipApprovalTarget" runat="server" CssClass="date_style"></asp:Label></h2> 
                            <asp:HiddenField ID="hidApprovalId" Value="-1" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" width="45%">
                        Same as original sample. Proceed to BULK.
                        <asp:CheckBox ID="chkBoxSameAsOriginalLabDip" runat="server" />
                    </th>
                    <td width="55%" rowspan="5" valign="top">
                        <asp:Repeater ID="repeaterLabDipHistory" runat="server" OnItemDataBound="repLabDip_ItemDataBound">
                            <HeaderTemplate>
                                <table width="100%" class="history_table item_list">
                                    <tr>
                                        <th colspan="4" align="center">
                                            History
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                            Action Date
                                        </th>
                                        <th>
                                            AWB
                                        </th>
                                        <th>
                                            Status
                                        </th>
                                        <th>
                                            Remarks
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="date_style">
                                        <%# (Convert.ToDateTime(Eval("SentDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("SentDate"))).ToString("dd MMM yy (ddd)")%>
                                    </td>
                                    <td>
                                        <%# Eval("DHLNumber")%>
                                    </td>
                                    <td class="numeric_text" id="cell" runat="server">
                                        <asp:Label ID="lblStatusLabDip" Text='<%# (Convert.ToInt32(Eval("Status")) ==1) ? "SENT FOR APPROVAL" : ((iKandi.Common.FabricApprovalStatus)Convert.ToInt32(Eval("Status"))).ToString()%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td class="remarks_text">
                                        <%# Eval("Remarks")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr id="trLabDipActual" class="hide_me">
                    <th style="text-align:left" width="15%">
                        <asp:Label ID="lblLabDip" runat="server" Text="Lab Dip/Strike Off Approval actual"
                            CssClass="hide_me"></asp:Label>
                    </th>
                    <td width="30%">
                        <asp:Label ID="lblLabDipApprovalActual" runat="server" CssClass="date_style blue-text"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th style="text-align:left" width="15%">
                        <asp:Label ID="lblLabDipActionDate" runat="server" Text="Action Date"></asp:Label>
                    </th>
                    <td width="30%">
                        <asp:TextBox ID="txtSentDateLabDip" runat="server" CssClass="date-picker elementsToOperateOn date_style blue-text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="text-align:left">
                        AWB
                    </th>
                    <td>
                        <asp:TextBox ID="txtDhlNumberLabDip" CssClass="elementsToOperateOn blue-text" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="text-align:left">
                        Status
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlApprovalStatusLabDip" runat="server" CssClass="elementsToOperateOn blue-text">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th style="text-align:left">
                        Remarks
                    </th>
                    <td>
                        <asp:TextBox ID="txtRemarksLabDip" runat="server" TextMode="MultiLine" CssClass="elementsToOperateOn blue-text"
                            MaxLength="4999" Width="99.8%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table width="100%" border="1px" class="item_list">    
                <tr>
                    <td colspan="3" width="100%" align="center">
                        <div class="form_small_heading">
                            <h2>Bulk Approval target
                             <asp:Label ID="lblBulkApprovalTarget" runat="server" CssClass="date_style"></asp:Label> </h2>
                             <asp:Label runat="server" Text="(this section will be activated once above section is cleared off)" ForeColor="Black" Font-Size="9px" Font-Bold="true"></asp:Label>
                        </div>
                    </td>
                </tr>
                
                <tr id="trBulkActual" class="hide_me">
                    <th width="15%" style="text-align:left">
                        <asp:Label ID="lblBulk" runat="server" Text="Bulk Approval actual"></asp:Label>
                    </th>
                    <td width="30%">
                        <asp:Label ID="lblBulkApprovalActual" runat="server" CssClass="blue-text"></asp:Label>
                    </td>
                   
                </tr>
                <tr>
                    <th style="text-align:left" width="15%">
                    <asp:Label ID="lblBulkActionDate" runat="server" Text="Action Date"></asp:Label>
                    </th>
                    <td width="30%">
                        <asp:TextBox ID="txtSentDateBulk" runat="server" CssClass="date-picker elementsToEnable date_style blue-text"></asp:TextBox>
                    </td>
                     <td width="55%" rowspan="4" valign="top">
                        <asp:Repeater ID="repeaterBulkHistory" runat="server" OnItemDataBound="repBulk_ItemDataBound">
                            <HeaderTemplate>
                                <table width="100%" class="history_table item_list">
                                    <tr>
                                        <th colspan="4" align="center">
                                            History
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                            Action Date
                                        </th>
                                        <th>
                                            AWB
                                        </th>
                                        <th>
                                            Status
                                        </th>
                                        <th>
                                            Remarks
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="date_style">
                                        <%--<%# Eval("SentDate")%>--%>
                                        <%# (Convert.ToDateTime(Eval("SentDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("SentDate")) ).ToString("dd MMM yy (ddd)" )%>
                                    </td>
                                    <td>
                                        <%# Eval("DHLNumber")%>
                                    </td>
                                    <td class="numeric_text" id="cellBulk" runat="server">
                                        <asp:Label ID="lblStatusBulk" Text='<%# (Convert.ToInt32(Eval("Status")) ==1) ? "SENT FOR APPROVAL" : ((iKandi.Common.FabricApprovalStatus)Convert.ToInt32(Eval("Status"))).ToString() %>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td class="remarks_text">
                                        <%# Eval("Remarks")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <th style="text-align:left">
                        AWB
                    </th>
                    <td>
                        <asp:TextBox ID="txtDhlNumberBulk" runat="server" CssClass="elementsToEnable blue-text" MaxLength="43"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="text-align:left">
                        Status
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlApprovalStatusBulk" runat="server" CssClass="elementsToEnable blue-text">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th style="text-align:left">
                        Remarks
                    </th>
                    <td>
                        <asp:TextBox ID="txtRemarksBulk" runat="server" TextMode="MultiLine" CssClass="elementsToEnable blue-text"
                            MaxLength="4999" Width="99.8%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
    <div>
     <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
        runat="server" meta:resourcekey="LoadImgResource1" />
        <asp:Button ID="btnSubmit" runat="server" CssClass="submit" Text="Submit" OnClick="btnSubmit_Click" />

        <asp:Button ID="btnPrint" runat="server" CssClass="print da_submit_button" Text="Print" 
             OnClientClick="return PrintPDFApp();" />
       
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Fabric Approval information have been saved into the system successfully!
            <br />
            <a id="A2" href="~/Internal/OrderProcessing/ManageOrders.aspx" runat="server">Click
                here</a> to Manage Orders.
        </div>
    </div>
</asp:Panel>
