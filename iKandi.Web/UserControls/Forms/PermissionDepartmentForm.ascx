<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermissionDepartmentForm.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.PermissionDepartment" %>
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    $(function () {

        $('.permissionDepartment input').click(function () {

            var objRow = $(this).parents("tr");
            var rowindex = objRow.get(0).rowIndex;
            var departmentID = $('#<%=ddlDepartment.ClientID %>').val();
            var permissionControl = objRow.find(".hidden-PermissionID" + rowindex);
            var applicationModuleID = objRow.find(".hidden-ApplicationModuleID" + rowindex).val();
            var applicationModuleColumnID = objRow.find(".hidden-ApplicationModuleColumnID" + rowindex).val();
            var read;
            var write;
            var readValue = false;
            var writeValue = false;
            var radioButtonIdPrefix = this.id.substring(0, this.id.lastIndexOf("_"));
            restrict = $("#" + radioButtonIdPrefix + "_chkRestrict");
            read = $("#" + radioButtonIdPrefix + "_chkRead");

            if ((event.srcElement != restrict.get(0)) && read.is(':checked') == true) {
                readValue = true;
                writeValue = false;
                restrict.attr({ "checked": true });
            }

            write = $("#" + radioButtonIdPrefix + "_chkWrite");
            if ((event.srcElement != restrict.get(0)) && write.is(':checked') == true) {
                readValue = true;
                writeValue = true;
                restrict.attr({ "checked": true });
            }

            if ((event.srcElement == restrict.get(0)) && restrict.is(':checked') == false) {
                readValue = false;
                writeValue = false;

                read.attr({ "checked": false });
                write.attr({ "checked": false });
            }
            else if ((event.srcElement == restrict.get(0)) && restrict.is(':checked') == true) {
                readValue = true;
                writeValue = false;

                read.attr({ "checked": true });
                write.attr({ "checked": false });
            }

            //alert("rasdvalue final = "+ readValue + " writeValue final =" + writeValue + ' ---' + applicationModuleID );
            proxy.invoke('SavePermission', { permissionId: permissionControl.val(), userId: '-1', designationId: '-1', read: readValue, write: writeValue, applicationModuleId: applicationModuleID, applicationModuleColumnId: -1, departmentId: departmentID },
        function (submit) {
            permissionControl.val(submit);
            //jQuery.facebox('Data has been saved successfully!');   
        }, onPageError, false, false);
        });

        $('.permissionApplicationModuleDepartment input').click(function () {
            var objRow = $(this).parents("tr");
            var rowindex = objRow.get(0).rowIndex;
            var departmentID = $('#<%=ddlDepartment.ClientID %>').val();

            var permissionControl = objRow.find(".hidden-PermissionID" + rowindex);
            var applicationModuleID = objRow.find(".hidden-ApplicationModuleID" + rowindex).val();
            var applicationModuleColumnID = objRow.find(".hidden-ApplicationModuleColumnID" + rowindex).val();
            var read;
            var write;
            var readValue = false;
            var writeValue = false;
            var radiobuttonIdPrefix = this.id.substring(0, this.id.lastIndexOf("_"));
            restrict = $("#" + radiobuttonIdPrefix + "_chkRestrict");

            read = $("#" + radiobuttonIdPrefix + "_chkPermissionRead");

            if ((event.srcElement != restrict.get(0)) && read.is(':checked') == true) {
                readValue = true;
                writeValue = false;
                restrict.attr({ "checked": true });
            }

            write = $("#" + radiobuttonIdPrefix + "_chkPermissionWrite");
            if ((event.srcElement != restrict.get(0)) && write.is(':checked') == true) {
                readValue = true;
                writeValue = true;
                restrict.attr({ "checked": true });
            }

            if ((event.srcElement == restrict.get(0)) && restrict.is(':checked') == false) {
                readValue = false;
                writeValue = false;

                read.attr({ "checked": false });
                write.attr({ "checked": false });
            }
            else if ((event.srcElement == restrict.get(0)) && restrict.is(':checked') == true) {
                readValue = true;
                writeValue = false;

                read.attr({ "checked": true });
                write.attr({ "checked": false });
            }

            //alert("rasdvalue final = "+ readValue + " writeValue final =" + writeValue);

            proxy.invoke('SavePermission', { permissionId: permissionControl.val(), userId: '-1', designationId: '-1', read: readValue, write: writeValue, applicationModuleId: applicationModuleID, applicationModuleColumnId: applicationModuleColumnID, departmentId: departmentID },
        function (submit) {
            permissionControl.val(submit);
            // jQuery.facebox('Data has been saved successfully!');   
        }, onPageError, false, false);
        });
    });


    function onPageError(error) {
        alert(error.Message + ' -- ' + error.detail);
    }


</script>


<div class="print-box">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="da_h1">Permission Department</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
    <div class="form_box">
    
<table cellspacing="3" width="100%" class="style1">
    <tr>
        <td align="right" class="style2">
            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="input_in" Width="265px" 
                AutoPostBack=true Style="margin-left: 0px" 
                onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                <asp:ListItem Text="Select Department....." Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdUserPermissions" runat="server" AutoGenerateColumns="False"
                DataSourceID="odsPermission" CssClass="da_header_heading" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Application Module" SortExpression="ApplicationModuleName"  ItemStyle-CssClass="text_align_left  da_table_tr_bg" >
                        <ItemTemplate>
                           <asp:Label ID="lblApplicationModuleName" runat="server" Text='<%# Bind("ApplicationModuleName") %>'></asp:Label>
                            <input type="hidden" class="hidden-ApplicationModuleID<%# Container.DataItemIndex + 1 %>" value='<%#Eval("ApplicationModuleID") %>' />
                            <input type="hidden" class="hidden-PermissionID<%# Container.DataItemIndex + 1 %>" value='<%#Eval("PermissionId") %>' />
                         
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="File Type" SortExpression="PageType" ItemStyle-CssClass="da_table_tr_bg">
                        <ItemTemplate>
                            <asp:Label ID="lblFileType" runat="server" Text='<%# Bind("PageType") %>'></asp:Label>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phase" SortExpression="ApplicationModuleName" ItemStyle-CssClass="da_table_tr_bg">
                        <ItemTemplate>
                            <asp:Label ID="lblPhaseNmae" runat="server" Text='<%# Bind("PhaseName") %>'></asp:Label>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SubPhase" SortExpression="ApplicationModuleName" ItemStyle-CssClass="da_table_tr_bg">
                        <ItemTemplate>
                            <asp:Label ID="lblSubPhaseName" runat="server" Text='<%# Bind("SubPhaseName") %>'></asp:Label>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Read" SortExpression="Read" ControlStyle-Width="25%">
                        <ItemTemplate>
                            <%--<asp:CheckBox ID="chkRead" runat="server" Checked='<%# Bind("Read") %>' CssClass="permissionDepartment" />--%>
                            <asp:RadioButton ID="chkRead" GroupName="applicationModule" runat="server" Checked='<%# Bind("Read") %>' CssClass="permissionDepartment" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Read/Write" SortExpression="Write" ControlStyle-Width="25%">
                        <ItemTemplate>
                            <%--<asp:CheckBox ID="chkWrite" runat="server" Checked='<%# Bind("Write") %>' CssClass="permissionDepartment" />--%>
                            <asp:RadioButton ID="chkWrite" GroupName="applicationModule" runat="server" Checked='<%# Bind("Write") %>' CssClass="permissionDepartment" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Restrict" SortExpression="Write" ControlStyle-Width="25%">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRestrict" runat="server" Checked='<%# Convert.ToBoolean( Eval("Write")) || Convert.ToBoolean( Eval("Read"))  %>' CssClass="permissionDepartment" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <EmptyDataTemplate><label>No Record Found</label></EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsPermission" runat="server" SelectMethod="GetPermissionByDepartment"
                TypeName="iKandi.BLL.PermissionController" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlDepartment" Name="DepartmentID" PropertyName="SelectedValue"
                        Type="Int32" DefaultValue="-1" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:DropDownList ID="ddlApplicationModuleName" runat="server" CssClass="input_in" Width="265px" 
                AutoPostBack="true" Style="margin-left: 0px" >
                <asp:ListItem Text="Select Application Module....." Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdApplicationModulePermission" runat="server" AutoGenerateColumns="False"
                DataSourceID="odsColumnPermission" CssClass="da_header_heading" Width="100%">
                
                <EmptyDataTemplate><label>No Record Found</label></EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Application Module Column " SortExpression="ApplicationModuleColumnName" ControlStyle-Width="500px" ItemStyle-CssClass="text_align_left da_table_tr_bg">
                        <ItemTemplate>
                             <asp:Label ID="lblApplicationModuleColumn" runat="server" Text='<%# Bind("ApplicationModuleColumnName") %>'></asp:Label>
                            <input type="hidden"  class="hidden-ApplicationModuleColumnID<%# Container.DataItemIndex + 1 %>" Value='<%#Eval("ApplicationModuleColumnID") %>' />
                            <input type="hidden" class="hidden-PermissionID<%# Container.DataItemIndex + 1 %>" value='<%#Eval("PermissionId") %>' />
                            <input type="hidden" class="hidden-ApplicationModuleID<%# Container.DataItemIndex + 1 %>" value='<%#Eval("ApplicationModuleID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Read" SortExpression="Read" ControlStyle-Width="25%">
                        <ItemTemplate>
                            <%--<asp:CheckBox ID="chkPermissionRead" runat="server" Checked='<%# Bind("Read") %>' CssClass="permissionApplicationModuleDepartment" />--%>
                            <asp:RadioButton ID="chkPermissionRead" GroupName="applicationModuleColumn" runat="server" Checked='<%# Bind("Read") %>' CssClass="permissionApplicationModuleDepartment" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Read/Write" SortExpression="Write" ControlStyle-Width="25%">
                        <ItemTemplate>
                            <%--<asp:CheckBox ID="chkPermissionWrite" runat="server" Checked='<%# Bind("Write") %>'  CssClass="permissionApplicationModuleDepartment"/>--%>
                            <asp:RadioButton ID="chkPermissionWrite" GroupName="applicationModuleColumn" runat="server" Checked='<%# Bind("Write") %>'  CssClass="permissionApplicationModuleDepartment"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Restrict" SortExpression="Write" ControlStyle-Width="25%">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRestrict" runat="server" Checked='<%# Convert.ToBoolean( Eval("Write")) || Convert.ToBoolean( Eval("Read"))  %>' CssClass="permissionApplicationModuleDepartment" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                
            </asp:GridView>
            <asp:ObjectDataSource ID="odsColumnPermission" runat="server" 
                TypeName="iKandi.BLL.PermissionController" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetColumnPermissionByDepartment" >
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlDepartment" DefaultValue="-1" Name="DepartmentID" 
                        PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="ddlApplicationModuleName" DefaultValue="-1" 
                        Name="ApplicationModuleID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
         </td>
        </tr>
            
    </table>
    </div>
    </div>
    
 <div class="form_buttom">
       <input type="button" id="btnPrint" runat="server" value="Print" class="da_submit_button"  onclick="return PrintPDFQueryString('','','','&btn=1');" />
</div>