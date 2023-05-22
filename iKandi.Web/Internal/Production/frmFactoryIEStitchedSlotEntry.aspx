<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="frmFactoryIEStitchedSlotEntry.aspx.cs" Inherits="iKandi.Web.Internal.Production.frmFactoryIEStitchedSlotEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<script language="javascript" type="text/javascript">


    function reloadWhenFullScreen() {
        // if it is full screen
        if (!window.screenTop && !window.screenY) {
            window.location.reload();
        }

        window.setTimeout(reloadWhenFullScreen, 1000);
    }

    function SaveAndValidateDeptValue() {
        //debugger;
        var gvFactoryIERow = $(".gvFactoryIERow").length;
        var hdnDeptCount = '<%=hdnDeptCount.ClientID %>';
        var ColCount = $("#" + hdnDeptCount).val();
        var RowId = 0;
        var gvId;
        var Exceed = 0;
        for (var row = 1; row <= gvFactoryIERow; row++) {
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;
            var DeptTotalVal = 0;
            for (var DepId = 1; DepId <= ColCount; DepId++) {
                //debugger;
                var LossDeptVal = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='" + gvId + "_Dept" + DepId + "']").val();
                if (LossDeptVal == '')
                    LossDeptVal = 0;
                DeptTotalVal = parseInt(DeptTotalVal) + parseInt(LossDeptVal);
            }
            if (parseInt(DeptTotalVal) < 100) {                
                alert('Total Dept Value can not be less than 100% in row no. ' + row);               
                return false;
            }
        }
    }
    function ValidateDeptValue(obj) {
        var gvFactoryIERow = $(".gvFactoryIERow").length;
        var hdnDeptCount = '<%=hdnDeptCount.ClientID %>';
        var ColCount = $("#" + hdnDeptCount).val();
        var RowId = 0;
        var gvId;
        var Exceed = 0;
        for (var row = 1; row <= gvFactoryIERow; row++) {
            //debugger;
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;
            var DeptTotalVal = 0;
            for (var DepId = 1; DepId <= ColCount; DepId++) {
                //debugger;
                var LossDeptVal = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='" + gvId + "_Dept" + DepId + "']").val();
                if(LossDeptVal == '')
                LossDeptVal = 0;
            DeptTotalVal = parseInt(DeptTotalVal) + parseInt(LossDeptVal);
            }
        if (parseInt(DeptTotalVal) > 100) {
                Exceed = 1;
                alert('Total Dept Value can not be greater than 100%');
                obj.value = '';
                return false;
            }
        }
        if (Exceed == 0) {
            SaveDeptValue(obj);
        }
    }

    function SaveDeptValue(obj) {
        //debugger;
        var hdnProductionUnit = '<%=hdnProductionUnit.ClientID %>';
        var hdnSlotId = '<%=hdnSlotId.ClientID %>';
        var hdnSlotDate = '<%=hdnStartDate.ClientID %>';
        
        var UnitId = $("#" + hdnProductionUnit).val();
        var SlotId = $("#" + hdnSlotId).val();
        var SlotDate = $("#" + hdnSlotDate).val();        
            
        var Ids = obj.id;
        var DepId = Ids.slice(-1);
        var cId = Ids.split("_")[6].substr(3);

        var SlotWiseFactoryId = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='ctl" + cId + "_hdnSlotWiseFactoryID']").val();
        var LossDeptId = $('.hdnDepartmentIdcls' + DepId).val();
        var LossDeptVal = obj.value;
        if (LossDeptVal != '') {
            proxy.invoke("SaveSlotWiseDistributionLoss", { SlotWiseFactoryId: SlotWiseFactoryId, UnitId: UnitId, DeprtmentId: LossDeptId, SlotId: SlotId, LossDepartmentValue: LossDeptVal, SlotDate: SlotDate }, function (result) {
                if (result > 0) {
                    SaveSlotWiseFactoryId(UnitId, SlotId, SlotDate);
                    //alert("Saved successfully");
                }
                else {
                    alert("Not Save");
                }
            }, onPageError, false, false);
        }
    }

    function SaveSlotWiseFactoryId(UnitId, SlotId, SlotDate) {
        //debugger;
        var gvFactoryIERow = $(".gvFactoryIERow").length;
        var RowId = 0;
        var gvId;
        var AllSlotWiseFactoryId = '';
        for (var row = 1; row <= gvFactoryIERow; row++) {
            //debugger;
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;

            var SlotWiseFactoryId = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='" + gvId + "_hdnSlotWiseFactoryID']").val();
            AllSlotWiseFactoryId = AllSlotWiseFactoryId + SlotWiseFactoryId + ',';
        }
        //debugger;
        if (AllSlotWiseFactoryId != '') {
            proxy.invoke("SaveSlotWiseFactoryId_Ref", { SlotWiseFactoryIdAll: AllSlotWiseFactoryId, UnitId: UnitId, SlotId: SlotId, SlotDate: SlotDate }, function (result) {
                if (result > 0) {
                    //alert("Saved successfully");
                }
                else {
                    alert("Not Save");
                }
            }, onPageError, false, false);
        }
    }

    function SaveComments(obj) {
        //debugger;
        var hdnProductionUnit = '<%=hdnProductionUnit.ClientID %>';
        var hdnSlotId = '<%=hdnSlotId.ClientID %>';
        var hdnSlotDate = '<%=hdnStartDate.ClientID %>';

        var UnitId = $("#" + hdnProductionUnit).val();
        var SlotId = $("#" + hdnSlotId).val();
        var SlotDate = $("#" + hdnSlotDate).val();

        var Ids = obj.id;
        var DepId = Ids.slice(-1);
        var cId = Ids.split("_")[6].substr(3);

        var LinePlanningId = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='ctl" + cId + "_hdnLinePlanningId']").val();
        var OrderId = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='ctl" + cId + "_hdnOrderId']").val();
        var OrderDetailId = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='ctl" + cId + "_hdnOrderDetailId']").val();
        var Lineno = $("#<%= gvFactoryIE_StitchedSlot.ClientID %> input[id$='ctl" + cId + "_hdnLineNo']").val();
        var Comment = obj.value;
        if (Comment != '') {
            proxy.invoke("SaveSlot_LinePlanning_FactoryIE", { LinePlanningId: LinePlanningId, UnitId: UnitId, OrderID: OrderId, OrderDetailId: OrderDetailId, Lineno: Lineno, SlotId: SlotId, SlotDate: SlotDate, SlotComment: Comment }, function (result) {
                if (result > 0) {
                    //alert("Saved successfully");
                }
                else {
                    alert("Not Save");
                }
            }, onPageError, false, false);
        }
    }

    function isNumberKey(evt) {
        //debugger;
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        else {
            return true;            
        }
        
    }

</script>

 <script type="text/javascript" language="javascript">
     $(document).ready(function () {
         ShowImagePreview();
     });
     // Configuration of the x and y offsets
     function ShowImagePreview() {
         xOffset = -20;
         yOffset = 40;
         $("a.preview").hover(function (e) {
             this.t = this.title;
             this.title = "";
             var c = (this.t != "") ? "<br/>" + this.t : "";
             $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:350px !important; width:320px !important;'/>" + c + "</p>");
             $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
         },

function () {
    this.title = this.t;
    $("#preview").remove();
});

         $("a.preview").mousemove(function (e) {
             $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
         });
     };

    
    </script>


<style type="text/css">
    #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
table thead th {
	padding:5px 0px;
	font-size:12px;
	font-family: arial;
	background:#3a5695;
	color:#fff;	
	text-transform:capitalize;	
}
.Deptstyle input
    {
        width:40px;
        text-align:left;        
    }
          input[type="text"], textarea {
    border: 1px solid #cccccc;
    text-transform: uppercase;
    font-size: 11px;
    width: 90%;
}
.Deptstyle
     {
         height:72px;
        
         width:97px;
         
     }
     .hiddenfield
     {
         display:none;
     }
     .DeptstayleFooter
     {
         height:20px;
     } 

     .secure_center_contentWrapper {
   font-family: Helvetica !important;
}
.item_list th 
{
    font-family: Helvetica !important;
}
</style>

    
<table  style="min-width:1226px; table-layout:fixed; display:inline-table" cellpadding="0" cellspacing="0">
<tr>
        <td colspan="2">
       <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;">
                    Slot wise Stitch Loss Share
                </h2>
        </td>
        </tr>
        <tr>
        <td colspan="2" style="padding-bottom:5px;">
     <asp:DropDownList ID="ddlSlot" Style="padding: 5px;" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlSlot_SelectedIndexChanged">
                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                </asp:DropDownList>
        </td>
        </tr>
<tr>
<td style="width:1140px;">
 <table cellpadding="0" style="width:100%;" cellspacing="0" border="1" style="border-collapse: collapse; text-align: center;" class="border2" >
<thead>
<tr>
<th colspan="6" align="center" style="padding:1px;"> 
    <asp:Label ID="lblFactory" runat="server" Text="" style="font-size:16px;"></asp:Label> 
    <asp:HiddenField ID="hdnProductionUnit" runat="server" />
    <asp:HiddenField ID="hdnSlotId" runat="server" />
    <asp:HiddenField ID="hdnStartDate" runat="server" />
    <asp:HiddenField ID="hdnDeptCount"  Value="0" runat="server" />
    <input type ="hidden" name ="__EVENTTARGET" value =""/>
<input type ="hidden" name ="__EVENTARGUMENT" value =""/>
</th>
<th colspan="3"> 
    <asp:Label ID="lblSlot" runat="server" Text=""></asp:Label> </th>
   <th align="center" rowspan="2"  style="width:62px">
                                Mark as Stitched
                            </th>
                            <th align="center" rowspan="2" style="width:62px" >
                                Day Closed
                            </th>
                              <th rowspan="2" style="width:150px; border-right:1px solid #fff;" align="center">
                                Comments
                            </th>

</tr>
 <tr>
                            <th style="width:75px" align="center">
                                Thumbnail
                            </th>
                            <th align="center" style="width:100px;">
                                Location
                                <br />
                                Supervisor
                            </th>
                            <th align="center"  style="width:220px;">
                                Serial No. (Client) 
                                <br />
                               Style No. / Contract No. 
                                <br />
                                Print Color
                            </th>
                            <th align="center"  style="width:50px;">
                                OB W/S SAM
                            </th>
                            <th align="center"  style="width:100px;">
                                Day Target Eff. <br />
                                Hourly Target
                            </th>
                            <th  style="width:80px;" align="center">                               
                                Ex. Fact. Date
                                <br />
                                 PCD Date
                                
                            </th>
                            <th align="center"  style="width:70px;">
                                Act.
                                <br />
                                OB W/S
                            </th>
                            <th align="center"  style="width:70px;">
                                Pass
                            </th>
                            <th align="center"  style="width:70px;">
                                Alt / Rej.
                            </th>
                        </tr>
</thead>

</table>
</td>
<td>
<div id="dvDept" runat="server">
</div>
</td>
</tr>
<tr style="vertical-align:top;">

<td colspan="2">

 <asp:GridView ID="gvFactoryIE_StitchedSlot" style="min-width:1226px; width:100%; table-layout:fixed; " ShowHeader="false" AutoGenerateColumns="false" cssclass="border2 slot-table" 
                    runat="server" ShowFooter="true" FooterStyle-CssClass="DeptstayleFooter" OnRowDataBound="gvFactoryIE_StitchedSlot_RowDataBound" BackColor="White">
                    <RowStyle CssClass="gvFactoryIERow" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="14px"
                            HeaderStyle-Width="75px" ItemStyle-Width="75px" FooterStyle-CssClass="DeptstayleFooter">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" target="_blank" class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'
                                    runat="server">
                                 <img width="65px" height="65px" alt="" onclick="javascript:void(0)" border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'/>
                                </asp:HyperLink>
                            </ItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnSlotWiseFactoryID" Value='<%# Eval("SlotWiseFactoryID") %>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnLinePlanningId" Value='<%# Eval("LinePlanningID") %>' runat="server" />
                                <asp:HiddenField ID="hdnLineNo" Value='<%# Eval("Line_No") %>' runat="server" />
                                <asp:Label ID="lblLine"  runat="server" Text='<%# Eval("LineNumber") %>'></asp:Label></br>
                                <asp:Label ID="lblIEName"  runat="server" Text='<%# Eval("LineDesignationName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle  BorderStyle="None" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="220px">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNumber" style="font-weight:bold;" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label>&nbsp;(<%# Eval("CompanyName")%>) 
                                 <br> 
                                
                                <asp:Label ID="lblStyleNumber" style="color:Blue;" runat="server" Text='<%# Eval("StyleNumber") %>'></asp:Label> &nbsp;/&nbsp;
                                
                                
                                <span style="color:Gray;"> <%# Eval("ContractNumber") %></span>
                              
                                 </br>
                                <span style="color:Gray;"> <%# Eval("FabricDetails")%>   </span>
                                <asp:HiddenField ID="hdnStyleId" Value='<%# Eval("StyleID") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderId" Value='<%# Eval("OrderID") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderDetailId" Value='<%# Eval("OrderDetailsID") %>' runat="server" />
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblOB"  runat="server" Text='<%# Eval("OB") %>'></asp:Label><br />
                                <asp:Label ID="lblSAM"  runat="server" Text='<%# Eval("SAM") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lblDayEff" Width="100px" runat="server" Text='<%# Eval("DayTargetEfficiency") %>'></asp:Label>
                                <asp:Label ID="lblHourlyTarget" Width="100px" runat="server" Text='<%# Eval("HourlyPcs") %>'></asp:Label>
                                <asp:HiddenField ID="hdnDays" Value='<%# Eval("DaysCount") %>' runat="server" />
                                <asp:HiddenField ID="hdnEfficiency" Value='<%# Eval("Efficiency") %>' runat="server" />
                                <asp:HiddenField ID="hdnPcs" Value='<%# Eval("Pcs") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField ItemStyle-Width="80px">
                            <ItemTemplate>
                               <span style="color:Gray">  <%# Eval("ExFactory")%>
                               <br />
                               <%# Eval("PCDDate")%> </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-Width="70px">
                            <ItemTemplate>
                                <asp:TextBox Width="40px"  ID="txlActualOB" ReadOnly="true" Text='<%# Eval("SlotOB") == "DBNull.Value" ? Convert.ToString(Eval("Prev_SlotOB")) : Convert.ToString(Eval("SlotOB"))%>'
                                    MaxLength="3" CssClass="numeric-field-without-decimal-places" runat="server" style="border:1px solid #fff; text-align:center;"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblActualOBFooter" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-Width="70px">
                            <ItemTemplate>
                                <asp:TextBox Width="40px" ID="txtSlotPass" ReadOnly="true" Text='<%# Eval("SlotPass") %>'
                               MaxLength="3" CssClass="numeric-field-without-decimal-places" runat="server" style="border:1px solid #fff;text-align:center;"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSlotPassFooter" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" ItemStyle-Width="70px" >
                            <ItemTemplate>
                                <asp:TextBox Width="40px" ID="txtSlotAlt" ReadOnly="true" Text='<%# Eval("SlotAlt") %>'
                                    MaxLength="3" CssClass="numeric-field-without-decimal-places" runat="server" style="border:1px solid #fff;text-align:center;"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSlotAltFooter" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                      
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkMarkAsStyle" Enabled="false" Checked='<%# Eval("IsStitched") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkMarkAsDayClose" Enabled="false" Checked='<%# Eval("IsDayClosed") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox ID="txtComment" onblur="javascript:SaveComments(this);"  CssClass="Comment" Text='<%# Eval("SlotDescription") %>' runat="server" TextMode="MultiLine" Height="100%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>   

</td>

</tr>
<tr>
        <td colspan="2">
        &nbsp;
        </td>
        </tr>
<tr>
<td align="right" style="padding-right: 5px;" colspan="2">
    <asp:Button ID="btnSubmit" runat="server" class="submit" 
        OnClientClick="javascript:return SaveAndValidateDeptValue();" Text="Submit" onclick="btnSubmit_Click" />
    
</td>
</tr>
</table>


</asp:Content>
