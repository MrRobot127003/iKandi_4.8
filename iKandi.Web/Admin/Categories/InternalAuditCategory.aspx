<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="InternalAuditCategory.aspx.cs" Inherits="iKandi.Web.Admin.Categories.InternalAuditCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script src="../../js/jquery.datePicker.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        h2 span
        {
            color: #fff;
            background: #39589c;
            text-align: center;
            margin: 3px 0px;
            font-weight: normal;
            font-size: 15px;
        }
        #sb-wrapper-inner
        {
            background: #fff;
            border: 5px solid #999;
            border-radius: 4px;
        }
        #sb-title, #sb-title-inner
        {
            display: none;
        }
        .EmptyRow td
        {
            padding: 0px 0px !important;
        }
        .EmptyRow td table td input[type="text"]
        {
            width: 97%;
        }
        .EmptyRow td table td select
        {
            width: 97%;
        }
        .EmptyRow td[colspan="6"]
        {
            border: 0px;
        }
        select
        {
            visibility: visible !important;
            text-transform: capitalize;
        }
        
        .CommoAdmin_Table tr:last-child > td[colspan="3"]
        {
            border: 0px;
            padding: 0px 0px;
        }
        .CommoAdmin_Table td[colspan="3"] td
        {
            border: 0px;
        }
        .CommoAdmin_Table td[colspan="3"] td span
        {
            color: Blue;
            font-weight: 600;
        }
        .CommoAdmin_Table td[colspan="3"] td a
        {
            color: gray;
            text-decoration: none;
        }
        .CommoAdmin_Table tr:last-child > td[colspan="6"]
        {
            border: 0px;
        }
        .CommoAdmin_Table td[colspan="6"] td
        {
            border: 0px;
        }
        .CommoAdmin_Table td[colspan="6"] td span
        {
            color: Blue;
            font-weight: 600;
        }
        .CommoAdmin_Table td[colspan="6"] td a
        {
            color: gray;
            text-decoration: none;
        }
        input[type="text"]
        {
            margin: 2px 0px;
            text-transform:capitalize !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <h2 style="width: 498px; background: #39589c; border: 1px solid gray; margin: 3px 0px 2px;
            text-align: center;">
            <span>Internal Audit Category Admin</span></h2>
        
                <asp:GridView ID="auditCatg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" Width="500px" DataKeyNames="Id" CssClass="CommoAdmin_Table bottomRow"
                    ShowFooter="true" OnPageIndexChanging="auditCatg_PageIndexChanging" EnableModelValidation="True"
                    OnRowCommand="auditCatg_RowCommand" OnRowCancelingEdit="auditCatg_RowCancelingEdit"
                    OnRowEditing="auditCatg_RowEditing" BorderWidth="0" OnRowUpdating="auditCatg_RowUpdating"
                    OnRowDeleting="auditCatg_RowDeleting" PageSize="15">
                    <RowStyle CssClass="gvRow" />
                    <FooterStyle CssClass="Footer_row_bottom" />
                    <PagerSettings PageButtonCount="5" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("Id") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="37px" CssClass="textCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtInternalAuditCatgName" runat="server" Text='<%# Bind("InternalAuditCatgName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("InternalAuditCatgName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="tbAuditCategoryName" Width="99%" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_Edit" ImageUrl="../../images/edit2.png" Style="position: relative;
                                    top: 2px" ToolTip="Edit" CommandName="Edit" runat="server" />
                                <asp:ImageButton ID="btn_Delete" ImageUrl="~/images/delete-icon.png" ToolTip="Delete"
                                    Style="width: 18px; position: relative; top: 2px" CommandName="Delete" runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btn_Update" ImageUrl="~/images/Save.png" ToolTip="Update" Style="width: 18px;"
                                    CommandName="Update" runat="server" OnClientClick="javascript:return ValiDateFaultData(this, 'Update');" />
                                <asp:ImageButton ID="btn_Cancel" ImageUrl="~/images/Cancel1.jpg" ToolTip="Cancel"
                                    Style="width: 25px;" CommandName="Cancel" runat="server" />
                            </EditItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle CssClass="border_right_color textCenter" />
                            <FooterTemplate>
                                <asp:ImageButton ID="btnadd" runat="server" ImageUrl="~/images/add-butt.png" CommandName="AddRow"
                                    OnClientClick="javascript:return ValiDateFaultData(this, 'Footer');" />
                            </FooterTemplate>
                            <FooterStyle CssClass="textCenter" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" cellspacing="0" class="CommoAdmin_Table" rules="none" border="0"
                            style="width: 100%;">
                            <tr>
                                <th style="width: 30px; border-right: 1px solid #9999 !important">
                                    Sr.No.
                                </th>
                                <th>
                                    Category Name
                                </th>
                                <th>
                                    Action
                                </th>
                            </tr>
                            <tr>
                                <td style="border-right: 1px solid #9999 !important">
                                </td>
                                <td style="border-right: 1px solid #9999 !important">
                                    <asp:TextBox ID="InternalAuditCatgNameEmpty" Width="99%" runat="server"></asp:TextBox>
                                </td>
                                <td class="textCenter">
                                    <asp:ImageButton ID="btnaddEmpty" runat="server" ImageUrl="~/images/add-butt.png"
                                        CommandName="AddRow" OnClientClick="javascript:return ValiDateFaultData(this, 'Empty');" />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                
                <div style="height: 20px">
                </div>
                <div>
                    <h2 style="width: 800px; background: #39589c; margin: 3px 0px 2px; text-align: center;">
                        <span>Internal Audit Category Details</span></h2>
                    <div style="margin-bottom: 2px;">
                        <span class="facolor">Category: </span>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="282px" Height="16px">
                        </asp:DropDownList>
                        <asp:Button ID="btnShowAuditDetails" CssClass="btnGo" runat="server" Text="Go" OnClick="btnShowAuditDetails_Click" />
                    </div>
                    <asp:GridView ID="auditCatgDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BackColor="White" Width="800px" DataKeyNames="CategoryQuesId" CssClass="CommoAdmin_Table bottomRow"
                        ShowFooter="true" EnableModelValidation="True" BorderWidth="0" OnRowDataBound="auditCatgDetails_RowDataBound"
                        OnRowCommand="auditCatgDetails_RowCommand" OnRowDeleting="auditCatgDetails_RowDeleting"
                        OnRowUpdating="auditCatgDetails_RowUpdating" OnRowCancelingEdit="auditCatgDetails_RowCancelingEdit"
                        OnRowEditing="auditCatgDetails_RowEditing" OnPageIndexChanging="auditCatgDetails_PageIndexChanging"
                        PageSize="15">
                        <PagerSettings PageButtonCount="5" />
                        <FooterStyle CssClass="Footer_row_bottom" />
                        <RowStyle CssClass="gvRow2" />
                        <EmptyDataRowStyle CssClass="EmptyRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    <asp:HiddenField ID="hdnCategoryQuesId" runat="server" Value='<%# Bind("CategoryQuesId") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="37px" CssClass="textCenter" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQuestionName" runat="server" Text='<%# Bind("QuestionName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("QuestionName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtQuestionNameFooter" Width="100%" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnDepartmentId" runat="server" Value='<%# Bind("DepartmentId") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDepartmentId" runat="server" Value='<%# Bind("DepartmentId") %>' />
                                    <asp:DropDownList ID="ddlDepartment" runat="server" Enabled="false" Width="100%">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="140px" />
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlDepartmentFooter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmentFooter_OnSelectedIndexChanged">
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlDesignation" Width="95%" runat="server">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnDesignationId" runat="server" Value='<%# Bind("DesignationId") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" Width="100%" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnDesignationId" runat="server" Value='<%# Bind("DesignationId") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlDesignationFooter" Width="100%" runat="server">
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Auditor Name">
                                <ItemTemplate>
                                    <asp:GridView ID="grvAuditor" runat="server" Width="85%" BorderWidth="0" CellPadding="0"
                                        CellSpacing="0" ShowHeader="false" AutoGenerateColumns="False" Style="float: left">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HyperLink ID="lnkAuditor" NavigateUrl='<%# Eval("CategoryQuesId", "Auditors.aspx?CategoryQuesId={0}")%>'
                                        rel="shadowbox;" onclick='return OpenAuditor(this);' Style="cursor: pointer;"
                                        runat="server"><img src="../../images/add-butt.png" title="Add Auditors" style="float: right;width: 15px;" /></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="130px" />
                                <ItemStyle CssClass="textCenter" />
                                <FooterTemplate>
                                </FooterTemplate>
                                <FooterStyle CssClass="textCenter" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btn_Edit" ImageUrl="../../images/edit2.png" ToolTip="Edit" CommandName="Edit"
                                        runat="server" Style="position: relative; top: 2px" />
                                    <asp:ImageButton ID="btn_Delete" ImageUrl="~/images/delete-icon.png" ToolTip="Delete"
                                        Style="width: 18px; position: relative; top: 2px" CommandName="Delete" runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="btn_Update" ImageUrl="~/images/Save.png" ToolTip="Update" Style="width: 18px;"
                                        CommandName="Update" runat="server"  />
                                    <asp:ImageButton ID="btn_Cancel" ImageUrl="~/images/Cancel1.jpg" ToolTip="Cancel"
                                        Style="width: 25px;" CommandName="Cancel" runat="server" />
                                </EditItemTemplate>
                                <HeaderStyle Width="60px" />
                                <ItemStyle CssClass="border_right_color textCenter" />
                                <FooterTemplate>
                                    <asp:ImageButton ID="btnadd" runat="server" ImageUrl="~/images/add-butt.png" CommandName="AddRow"
                                        OnClientClick="javascript:return ValiDateInternalCatgDetails(this, 'Footer');" />
                                </FooterTemplate>
                                <FooterStyle CssClass="textCenter" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="0" cellspacing="0" class="CommoAdmin_Table" rules="none" border="0"
                                style="width: 100%">
                                <tr>
                                    <th style="width: 30px">
                                        Sr.No.
                                    </th>
                                    <th>
                                        Name
                                    </th>
                                    <th>
                                        Department
                                    </th>
                                    <th>
                                        Designation
                                    </th>
                                    <th>
                                        Action
                                    </th>
                                </tr>
                                <tr>
                                    <td style="border-right: 1px solid #9999 !important">
                                    </td>
                                    <td class="textCenter" style="border-right: 1px solid #9999 !important">
                                        <asp:TextBox ID="txtQuestionNameEmpty" Width="96%" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="textCenter" style="width: 210px; border-right: 1px solid #9999 !important">
                                        <asp:DropDownList ID="ddlDepartmentEmpty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmentEmpty_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="textCenter" style="width: 210px; border-right: 1px solid #9999 !important">
                                        <asp:DropDownList ID="ddlDesignationEmpty" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="textCenter">
                                        <asp:ImageButton ID="btnaddEmpty" runat="server" ImageUrl="~/images/add-butt.png"
                                            CommandName="AddRow" OnClientClick="javascript:return ValiDateInternalCatgDetails(this, 'Empty');" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                     </div>
            </ContentTemplate>
        </asp:UpdatePanel>
   
    <script type="text/javascript">

        function ValiDateFaultData(elem, type) {
            debugger;
            var Ids = elem.id;
            var gvId = Ids.split("_")[1];
            var gvIdFooter;
            var GridRow = $(".gvRow").length;

            if (type == 'Empty') {
                var txtCategoryName = $("#ctl00_cph_main_content_auditCatg_ctl01_InternalAuditCatgNameEmpty").val();
                if (txtCategoryName == '') {
                    $("#ctl00_cph_main_content_auditCatg_ctl01_InternalAuditCatgNameEmpty").css({ 'background': '#f5f59f' });
                    alert('Please fill category name!');
                    return false;
                }
            }

            RowId = parseInt(GridRow) + 1;
            if (RowId < 10) {
                gvId = 'ctl0' + RowId;
                if (RowId == 9) {
                    gvIdFooter = 'ctl' + (RowId + 1);
                }
                else {
                    gvIdFooter = 'ctl0' + (RowId + 1);
                }
            }
            else {
                gvId = 'ctl' + RowId;
                gvIdFooter = 'ctl' + (RowId + 1);
            }

            if (type == 'Update') {
                var txtCategoryName = $("#<%= auditCatg.ClientID %> input[id*='" + gvId + "_txtInternalAuditCatgName" + "']").val();
                if (txtCategoryName == '') {
                    $("#<%= auditCatg.ClientID %> input[id*='" + gvId + "_txtInternalAuditCatgName" + "']").css({ 'background': '#f5f59f' });
                    alert('Please fill category name!');
                    return false;
                }
            }

            if (type == 'Footer') {
                var txtCategoryName = $("#<%= auditCatg.ClientID %> input[id*='" + gvIdFooter + "_tbAuditCategoryName" + "']").val();
                if (txtCategoryName == '') {
                    $("#<%= auditCatg.ClientID %> input[id*='" + gvIdFooter + "_tbAuditCategoryName" + "']").css({ 'background': '#f5f59f' });
                    alert('Please fill category name!');
                    return false;
                }
            }
        }


        function ValiDateInternalCatgDetails(elem, type) {
            //  alert();
            debugger;
            var Ids = elem.id;
            var gvId = Ids.split("_")[1];
            var gvIdFooter;
            var GridRow = $(".gvRow2").length;

            if (type == 'Empty') {
                var txtCategoryDetails = $("#ctl00_cph_main_content_auditCatgDetails_ctl01_txtQuestionNameEmpty").val();
                var ddlDept = $("#ctl00_cph_main_content_auditCatgDetails_ctl01_ddlDepartmentEmpty option:selected").text();
                var ddlCatg = $("#ctl00_cph_main_content_auditCatgDetails_ctl01_ddlDesignationEmpty option:selected").text();

                if (txtCategoryDetails == '') {
                    $("#ctl00_cph_main_content_auditCatgDetails_ctl01_txtQuestionNameEmpty").css({ 'background': '#f5f59f' });
                    alert('Please fill category details!');
                    return false;
                }

                if (ddlDept == '--Select--') {
                    $("#ctl00_cph_main_content_auditCatgDetails_ctl01_ddlDepartmentEmpty").css({ 'background': '#f5f59f' });
                    alert('Please select department!');
                    return false;
                }

                if (ddlCatg == '--Select--') {
                    $("#ctl00_cph_main_content_auditCatgDetails_ctl01_ddlDesignationEmpty").css({ 'background': '#f5f59f' });
                    alert('Please select designation!');
                    return false;
                }
            }



            if (type == 'Update') {
                var txtCategoryDetails = $("#<%= auditCatgDetails.ClientID %> input[id*='" + gvId + "_txtQuestionName" + "']").val();
                var ddlDept = $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvId + "_ddlDepartment" + "'] option:selected").text();
                var ddlDesig = $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvId + "_ddlDesignation" + "'] option:selected").text();

                if (txtCategoryDetails == '') {
                    $("#<%= auditCatgDetails.ClientID %> input[id*='" + gvId + "_txtQuestionName" + "']").css({ 'background': '#f5f59f' });
                    alert('Please fill category details!');
                    return false;
                }
                if (ddlDept == '--Select--') {
                    $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvId + "_ddlDepartment" + "']").css({ 'background': '#f5f59f' });
                    alert('Please select department!');
                    return false;
                }
                if (ddlDesig == '--Select--') {
                    $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvId + "_ddlDesignation" + "']").css({ 'background': '#f5f59f' });
                    alert('Please select designation!');
                    return false;
                }
            }

            RowId = parseInt(GridRow) + 1;
            if (RowId < 10) {
                gvId = 'ctl0' + RowId;
                if (RowId == 9) {
                    gvIdFooter = 'ctl' + (RowId + 1);
                }
                else {
                    gvIdFooter = 'ctl0' + (RowId + 1);
                }

            }
            else {
                gvId = 'ctl' + RowId;
                gvIdFooter = 'ctl' + (RowId + 1);
            }

            if (type == 'Footer') {
                var txtCategoryDetails = $("#<%= auditCatgDetails.ClientID %> input[id*='" + gvIdFooter + "_txtQuestionNameFooter" + "']").val();
                var ddlDept = $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvIdFooter + "_ddlDepartmentFooter" + "'] option:selected").text();
                var ddlDesig = $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvIdFooter + "_ddlDesignationFooter" + "'] option:selected").text();
                if (txtCategoryDetails == '') {
                    $("#<%= auditCatgDetails.ClientID %> input[id*='" + gvIdFooter + "_txtQuestionNameFooter" + "']").css({ 'background': '#f5f59f' });
                    alert('Please fill category details!');
                    return false;
                }
                if (ddlDept == '--Select--') {
                    $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvIdFooter + "_ddlDepartmentFooter" + "']").css({ 'background': '#f5f59f' });
                    alert('Please select department!');
                    return false;
                }
                if (ddlDesig == '--Select--') {
                    $("#<%= auditCatgDetails.ClientID %> select[id*='" + gvIdFooter + "_ddlDesignationFooter" + "']").css({ 'background': '#f5f59f' });
                    alert('Please select designation!');
                    return false;
                }
            }

        }


        function OpenAuditor(obj) {
            debugger;
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 250, width: 350, modal: true, animate: true, animateFade: true });
            return false;
        }
        function ReloadPage() {
            $(".btnGo").click();
        }  
    </script>
</asp:Content>
