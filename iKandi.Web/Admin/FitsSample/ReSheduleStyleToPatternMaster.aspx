<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="ReSheduleStyleToPatternMaster.aspx.cs" Inherits="iKandi.Web.Internal.Design.SampleAllocToPatternMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <style type="text/css">
        body
        {
            font-size:11px;
        }
.date_style_new
{
    border:1px solid #000 !important;
    
}
.date_style_new input
{
    border:0px !important;
    font-size:10px !important;
    width:100% !important;   
}

.vertical_text_new
{
    background:#fff !important;    
    border:1px solid #666 !important;
    padding:0px !important;    
}

.vertical_header_new, .vertical_text_new
{
    margin: 0 !important;
    padding-bottom: 10px !important;
    padding-top: 10px !important;
    text-align: center;
    vertical-align: middle;
}

.date_style_new
{
    
     border: 1px solid #000000 !important;
     padding:0px !important;
     font-size:11px;
}
.top-sent
{    
    border: 1px solid #000000 !important;
}
.vertical_text_input
{
    filter:none !important;
    writing-mode:lr-tb !important;
}
.TopSentActual{
border:1px solid #ccc;
}

.pagination table td
{    
    padding:5px !important;  
}

.pagination table td span
{
    color:Green;    
    font-weight:bold;
    font-size:12px !important;
}
.item_list1 th
{
    
    text-transform:capitalize;
    font-family: Verdana, Arial, sans-serif;
    font-size:9px;
}
.item_list1 td
{
    padding:0px !important;
}
table {
    font-family: arial, halvetica;
    border-collapse: collapse;
}
input[type="text"], textarea {
    border: 1px solid #cccccc;
    text-transform: Capitalize;
    font-size: 11px;
    height: 15px;
    font-family: Verdana, Sans-Serif , Aparajita;
    color: #666;
}
#image_wrap
{
   max-height:400px !important;
}
#image_wrap img
{
   max-height:390px !important;
}
.Barrier TD
{
  background:#fbe6df !important;  
}


.Barrier TD input
{
  background:#fbe6df !important;  
}
</style>
<script type="text/javascript">
    $(function () {
        MyDatePickerFunction();
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MyDatePickerFunction);

        PatternStyle();
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(PatternStyle);

    });

    function MyDatePickerFunction() {
        $('.AllocDate').datepicker({ dateFormat: 'dd M y (D)' });
    }

    function PatternStyle() {
        $("input[type=text].Pattern-style").autocomplete("/Webservices/iKandiService.asmx/SuggestStylesForPattern", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });
    }
    //added by abhishek
    var ddlClient = '<%=ddlClientNameSelect.ClientID %>';
    function BindPrintParentDept(SelectedClientID) {
        debugger;
        if (SelectedClientID == 'Select' || SelectedClientID == '') {
            SelectedClientID = -1;
        }
        //bindDropdown(serviceUrl, "ctl00_cph_main_content_ddlDeptParent", "Get_ClientDeptsParent", { ClientId: SelectedClientID, type: 'Parent', ParentDeptID: '-1' }, "DeptName", "ClientDeptid", true, '', onPageError);     
    }
    function BindPrintChildDept(ParentSelectedVal) {       
        var ClientID = $("#" + ddlClient, '#main_content').val();
        if (ParentSelectedVal == 'Select' || ParentSelectedVal == '') {
            ParentSelectedVal = -1;
        }
        if (ClientID == 'Select' || ClientID == '') {
            ClientID = -1;
        }
        //bindDropdown(serviceUrl, "ctl00_cph_main_content_ddlDeptNameSelect", "Get_ClientDeptsParent", { ClientId: ClientID, type: 'SubParent', ParentDeptID: ParentSelectedVal }, "DeptName", "ClientDeptid", true, '', onPageError);       
    }
    //END
    function removetext(obj) {
        var CID = obj;
        if (CID == 'txtfrom') {
            $('#<%= txtfrom.ClientID %>').val('');
        }
        if (CID == 'txtTo') {
            $('#<%= txtTo.ClientID %>').val('');
        }

    }

    function showDatecancelbutton(obj) {
        var C_ID = obj;
        if (C_ID == 'txtfrom') {
            $('#imgfrom').css('visibility', 'visible');
        }
        if (C_ID == 'txtTo') {
            $('#imgto').css('visibility', 'visible');
        }
    }
    function TriggerClick() {
        debugger;
        $('#' + '<%=ddlClientNameSelect.ClientID %>').click();
    }

</script>


    <h2 style="text-align:center; background:#39589C !important; color:#fff; min-width:1340px">
        Reschedule Style To Pattern Master
    </h2>
  
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="update1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
      <asp:UpdatePanel ID="update1" UpdateMode="Always" runat="server">
      <ContentTemplate>
    <div style="max-width: 1900px;">
   
      <table border="0" cellpadding="0" cellspacing="0" style="font-size: 9px ! important; padding-bottom:0px; color:gray; width:900px;margin-left: 5px;">
    <tr>
    <td width="65px"><asp:Label ID="lablsearch" Text="Style" runat="server"></asp:Label> </td>
                                <td style="border:none !important; width:125px;">

                                <input type="hidden" runat="server" class="do-not-disable" id="hdntabvalue" />                                    
                                    
                                    <input type="text" id="txtsearch"
                                        style="width: 85% ! important; color:#000;  padding: 2px 5px;"
                                        class="Pattern-style do-not-disable" runat="server" maxlength="20" />
                                  
                                </td>  
                               
                                  <td width="35px"> <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label> </td>
                                <td style="border:none !important; width: 125px;">
                               
                                    <input type="text" id="txtfrom"   onchange="showDatecancelbutton('txtfrom');return false"  style="width: 75% ! important;" class="AllocDate do-not-allow-typing"
                                        runat="server" />
                                        <input type="image" id="imgfrom" src="../../App_Themes/ikandi/images1/delete1.png" title="clear from Date" onclick="removetext('txtfrom');return false" />
                                </td>
                              
                              <td align="center" width="35px"> <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label> </td>
                                <td style="border:none !important;width: 125px;">
                                 
                                
                                    <input type="text" id="txtTo" onchange="showDatecancelbutton('txtTo');return false"  style="width: 75% ! important;" class="AllocDate do-not-allow-typing"
                                        runat="server" />
                                         <input type="image" id="imgto" src="../../App_Themes/ikandi/images1/delete1.png" title="clear from Date" onclick="removetext('txtTo');return false" />
                                </td> 
                                <td width="35px"><input type="text" style="width:30px; background:#fbe6df" /></td>
                                <td width="125px">
                                <asp:CheckBox ID="chkCrossBarrier" runat="server"></asp:CheckBox>&nbsp; Cross Barriers Days
                                </td> 
                         <td align="center"> &nbsp;</td>
      
    </tr>
    <tr>
    <td colspan="10"> &nbsp;</td>
    </tr>
    <tr>
    <td>Master Name</td>
     <td>
    <asp:DropDownList runat="server" ID="ddlMasterNameSelect" Width="90%">
    <asp:ListItem Text="Select" Value="Select"></asp:ListItem></asp:DropDownList>
    </td>
  <td>Client</td>
    <td>
      <%--onselectedindexchanged="ddlClientNameSelect_SelectedIndexChanged"--%>
    <asp:DropDownList runat="server" ID="ddlClientNameSelect" onselectedindexchanged="ddlClientNameSelect_SelectedIndexChanged" AutoPostBack="true"  Width="90%">
            <%--<asp:ListItem Text="Select" Value="Select"></asp:ListItem>--%>
            </asp:DropDownList>
    </td>
    <td>Par.Dept. </td>
     <td>
     <%--onchange="javascript:BindPrintChildDept(this.value);"--%>
   <asp:DropDownList runat="server"  ID="ddlDeptParent" onselectedindexchanged="ddlDeptParent_SelectedIndexChanged" AutoPostBack="true"  Width="90%">
    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
    </asp:DropDownList>
    </td>
    <td>Sub.Dept. </td>
     <td>
   <asp:DropDownList runat="server" ID="ddlDeptNameSelect" Width="90%">
    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
    </asp:DropDownList>
    </td>
  <td>Type</td>
     <td>
     <asp:DropDownList runat="server" ID="ddlTypeNameSelect" Width="90%">
     <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
     </asp:DropDownList>
    </td>
   
           <td align="center">
     <asp:Button ID="btnSearch" CssClass="submit" runat="server" Text="Search" 
                   onclick="btnSearch_Click" />
    </td> 
    </tr>
    
  </table>
    
    <br />
        <asp:GridView runat="server" ID="gvSampleAllocPatterMaster" RowStyle-ForeColor="Gray"
            CssClass="item_list1" AutoGenerateColumns="false" AllowPaging="true" PageSize="20"
            Width="100%" style="table-layout: fixed"  
            onrowdatabound="gvSampleAllocPatterMaster_RowDataBound" 
            onpageindexchanging="gvSampleAllocPatterMaster_PageIndexChanging" 
            onrowcommand="gvSampleAllocPatterMaster_RowCommand">
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="6"             
              FirstPageText="First" LastPageText="Last" />
           <PagerStyle CssClass="pagination"/>

            <columns>
                <asp:TemplateField HeaderText="Master" HeaderStyle-Width="120px" ItemStyle-Width="120px">
                        <ItemTemplate>
                        <asp:HiddenField ID="hdnCadMasterID" Value='<%# Eval("CADMasterRoleID") %>' runat="server" />
                            <asp:DropDownList ID="ddlMaster" ForeColor="Black" Width="80%" OnSelectedIndexChanged="ddlMaster_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>                        
                        <HeaderStyle Width="120px" />
                        <ItemStyle Width="120px" />
                  </asp:TemplateField>  

                   <asp:TemplateField HeaderStyle-Width="230px" ItemStyle-Width="150px">
                   <HeaderTemplate>StyleNo.(Creation Date/Fits Comment Date)<br />
                   Fabric 1<br />
                   Color/Print
                   </HeaderTemplate>
                        <ItemTemplate>                          
                            <asp:HiddenField ID="hdnStyleId" Value='<%# Eval("Styleid") %>' runat="server" />
                           <div style="height:19px; border-bottom:1px solid gray;">
                           <asp:Label ID="lblStyleNo" runat="server" Font-Bold="true" ForeColor="Black" Text='<%# Eval("StyleNumber") %>'></asp:Label>
                            <asp:Label ID="lblCreation_FitsDate" runat="server" Text=""></asp:Label></div>
                            <div style="height:19px; border-bottom:1px solid gray;">
                                <asp:Label ID="lblFabric1" runat="server" Text='<%# Eval("Fabric") %>'></asp:Label></div>

                                <asp:Label ID="lblColorPrint" runat="server" Text='<%# Eval("FabricDetails") %>'></asp:Label>
                        </ItemTemplate> 
                        <HeaderStyle Width="230px" />
                        <ItemStyle VerticalAlign="Top" />                       
                  </asp:TemplateField>   

                   <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px" HeaderText="Thumbnail">
                        <ItemTemplate>
                            <a border="0" title="CLICK TO VIEW ENLARGED IMAGE" href='javascript:void(0)' onclick='showStylePhotoWithOutScroll(<%#Eval("StyleID") %>,-1,-1)'>
                        <img height="55px" width="90%" border="0" align="center" src='<%# ResolveUrl("~/Uploads/Style/thumb-" + Eval("SketchURL").ToString()) %>'
                            visible='<%# (Eval("SketchURL") == null || string.IsNullOrEmpty(Eval("SketchURL").ToString()) ) ? false: true %>' />
                    </a>
                        </ItemTemplate>                        
                        <HeaderStyle Width="60px" />
                        <ItemStyle Width="60px" />
                  </asp:TemplateField> 
                  
                   <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px">
                   <HeaderTemplate>
                   Type<br /> AM / PD Manager<br /> Prod. Merch. / PD
                   </HeaderTemplate>
                        <ItemTemplate>
                            <div style="height:19px; border-bottom:1px solid gray;">
                            <asp:Label ID="lblStatus" Font-Bold="true" ForeColor="Black" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </div>
                            <div style="height:19px; border-bottom:1px solid gray;">
                            <asp:Label ID="lblAM" runat="server" Text=""></asp:Label>
                            </div>
                            <asp:Label ID="lblPDM" runat="server" Text=""></asp:Label>
                        </ItemTemplate> 
                        <HeaderStyle Width="100px" />
                        <ItemStyle VerticalAlign="Top" />                       
                  </asp:TemplateField> 

                   <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px">
                   <HeaderTemplate>
                   Client/Sub.Dept (Par.Dept)
                   <br />
                   Stc Target Date<br />
                   Allocation Date
                   </HeaderTemplate>
                        <ItemTemplate> 
                            <div style="height:19px; border-bottom:1px solid gray;">
                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label> /
                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DeptName") %>'></asp:Label>
                            </div>
                            <div style="height:19px; border-bottom:1px solid gray;">
                                <asp:Label ID="lblSTCTargetDate" Font-Bold="true" ForeColor="Black" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="text-align:center">
                                <asp:TextBox ID="txtAllocationDate" CssClass="AllocDate do-not-allow-typing" runat="server" Text=""
                                 style="width:80% !important; color:blue; pointer-events : none;"></asp:TextBox>                                    
                                </div>
                        </ItemTemplate>
                        <HeaderStyle Width="150px" />
                        <ItemStyle VerticalAlign="Top" />                        
                  </asp:TemplateField>   
                       
                 <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-Width="90px">
                   <HeaderTemplate>Hand Over ETA<br />
                   Pattern ETA<br />
                   Sample Sent ETA
                   </HeaderTemplate>
                        <ItemTemplate> 
                            <div style="height:19px; border-bottom:1px solid gray;">
                            <asp:Label ID="lblHandOverEta" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="height:19px; border-bottom:1px solid gray;">
                            <asp:Label ID="lblPatternETA" runat="server" Text=""></asp:Label></div>
                            <asp:Label ID="lblSampleSentEta" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="90px" />
                        <ItemStyle VerticalAlign="Top" />                        
                  </asp:TemplateField>  

                   <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-Width="10px">
                        <ItemTemplate>
                            <asp:Label ID="lblSequence" runat="server" Text=""></asp:Label>
                        </ItemTemplate>                        
                        <HeaderStyle Width="10px" />
                        <ItemStyle Width="10px" />
                  </asp:TemplateField> 

                  <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-Width="60px" HeaderText="Re-Sequence">
                        <ItemTemplate>                          
                            <asp:ImageButton ID="ImgbtnTop" CommandName="Up" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ImageUrl="~/images/top-png-icon.png" runat="server" />
                            <asp:ImageButton ID="ImgbtnBottom" CommandName="Down" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ImageUrl="~/images/bottom-png-icon.png" runat="server" />

                        </ItemTemplate>                        
                        <HeaderStyle Width="60px" />
                        <ItemStyle Width="60px" />
                  </asp:TemplateField> 

           </columns>
            <RowStyle ForeColor="Gray" />
        </asp:GridView>
    </div>
    <br />
    <div class="form_buttom" style="float: left;">
        <asp:Button ID="btnTopSubmit" CssClass="submit" runat="server" Text="Submit" 
            onclick="btnTopSubmit_Click"  />
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>

 
  
       

</asp:Content>
