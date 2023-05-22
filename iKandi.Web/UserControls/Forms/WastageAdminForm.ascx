<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WastageAdminForm.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.WastageAdminForm" %>
<script type="text/javascript">

    function saveProcess() {
        debugger;
        var temp = document.getElementById('<%=chkAllClient.ClientID %>');
    }

    function test() {
        return true;
    }
    //txtShrink,txtWash
    function CheckValid(ctrl) {
        var cb = $("#" + ctrl.id).closest("tr").find("[id$='_chkcheck']");
        if (cb.attr('checked') == false) {
            alert("Please select check box");
            return false;
        }
        var wash = $.trim($("#" + ctrl.id).closest("tr").find("[id$='_txtWash']").val());
        var shrink = $.trim($("#" + ctrl.id).closest("tr").find("[id$='_txtShrink']").val());
        if ((shrink == "" || parseInt(shrink) == 0) && (wash == "" || parseInt(wash) == 0)) {
            if (confirm("Are you sure shrinkage and washing entry zero value?") == true)
                return true;
            return false;
        }
        return true;
    }
   
</script>
<asp:ScriptManager ID="sm" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UP" runat="server">
    <ContentTemplate>
        <table width="856" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table width="100%" border="0" align="center" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10" class="da_table_heading_bg_left">
                                &nbsp;
                            </td>
                            <td width="1205" class="da_table_heading_bg">
                                <span class="da_h1" style="text-align: left;">Wastage Admin</span>
                            </td>
                            <td width="13" class="da_table_heading_bg_right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="tbl_bordr">
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                        <tr>
                            <td>
                                <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                    <tr class="td-sub_headings">
                                        <td width="22%" valign="bottom">
                                            Process
                                        </td>
                                        <td valign="bottom">
                                            &nbsp;
                                        </td>
                                        <td width="7%" valign="bottom">
                                            &nbsp;
                                        </td>
                                        <td width="13%" valign="bottom">
                                            &nbsp;
                                        </td>
                                        <td valign="bottom">
                                            &nbsp;
                                        </td>
                                        <td valign="bottom">
                                            &nbsp;
                                        </td>
                                        <td width="8%" valign="bottom">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="inner_tbl_td">
                                            <%--<asp:TextBox ID="txtProcess" style="text-transform:none;" ForeColor="blue"  runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlProcess" runat="server" Style="text-transform: none;" ForeColor="blue">
                                                <asp:ListItem Value="0">Select Process</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="17%">
                                            <asp:Label ID="lblProcess" ForeColor="Red" runat="server"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                        <td width="17%">
                                            &nbsp;
                                        </td>
                                        <td width="16%">
                                            &nbsp;
                                        </td>
                                        <td width="8%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin: 0px;">
                                    <tr class="td-sub_headings">
                                        <td valign="bottom">
                                            Fabric Group Name
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" class="inner_tbl_td td-sub_headings">
                                            <asp:CheckBoxList ID="chkAllClient" Width="100%" runat="server">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btnAdd" runat="server" CssClass="da_submit_button" OnClientClick="javascript:return test();"
                                                Text="Add" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                    <tr style="text-align: center;">
                                        <td>
                                            <asp:GridView ID="grdGroup" Width="100%" runat="server" AutoGenerateColumns="False"
                                                OnRowEditing="grdGroup_RowEditing" OnRowDeleting="grdGroup_RowDeleting" HeaderStyle-BackColor="#bdc3cf"
                                                HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                                OnRowUpdating="grdGroup_RowUpdating" OnRowCancelingEdit="grdGroup_RowCancelingEdit"
                                                OnRowDataBound="grdGroup_RowDataBound" OnRowCommand="grdGroup_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S. No.">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("Id") %>' />
                                                            <asp:Label ID="txtSNo" ForeColor="blue" Style="text-align: center;" runat="server"
                                                                Text='<%# Eval("SNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fabric Group Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrp" ForeColor="blue" Style="text-align: center; text-transform: none;"
                                                                runat="server" Text='<%# Eval("GroupName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="txtGroupName" ForeColor="blue" Style="text-align: center; text-transform: none;"
                                                                Width="80px" runat="server" Text='<%#Eval("GroupName")%>'></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Process">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblprc" ForeColor="blue" Style="text-align: center; text-transform: none;"
                                                                runat="server" Text='<%# Eval("Process") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="txtProcess" ForeColor="blue" Style="text-align: center; text-transform: none;"
                                                                Width="80px" runat="server" Text='<%#Eval("Process")%>'></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Shrinkage (%)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsrnkg" ForeColor="blue" Style="text-align: center; text-transform: none;"
                                                                runat="server" Text='<%# Eval("Shrinkage") %>' Visible='<%#Convert.ToInt32(Eval("IsUpdate"))==1?true:false%>'></asp:Label>
                                                                <asp:TextBox ID="txtShrink" ForeColor="blue" Style="text-align: center; text-transform: none;" MaxLength="5" onkeypress="JavaScript:return floatValidation(event,this)"
                                                                runat="server" Text='<%# Eval("Shrinkage") %>' Visible='<%#Convert.ToInt32(Eval("IsUpdate"))==0?true:false%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtShrinkage" EnableViewState="true" ForeColor="blue" Style="text-align: center;
                                                                text-transform: none;" Width="80px" runat="server" Text='<%#Eval("Shrinkage")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Washing (%)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblwng" ForeColor="blue" Style="text-align: center; text-transform: none;"
                                                                runat="server" Text='<%# Eval("Washing") %>' Visible='<%#Convert.ToInt32(Eval("IsUpdate"))==1?true:false%>'></asp:Label>
                                                                <asp:TextBox ID="txtWash" ForeColor="blue" Style="text-align: center; text-transform: none;" MaxLength="5" onkeypress="JavaScript:return floatValidation(event,this)"
                                                                runat="server" Text='<%# Eval("Washing") %>' Visible='<%#Convert.ToInt32(Eval("IsUpdate"))==0?true:false%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtWashing" EnableViewState="true" ForeColor="blue" Style="text-align: center;
                                                                text-transform: none;" Width="80px" runat="server" Text='<%#Eval("Washing")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkcheck" runat="server" Checked='<%#Convert.ToInt32(Eval("IsUpdate"))==1?true:false%>' Enabled='<%#Convert.ToInt32(Eval("IsUpdate"))==0?true:false%>' />
                                                            <asp:HiddenField ID="IsUpdate" runat="server" Value='<%# Eval("IsUpdate") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ForeColor="black" ID="lnkAdd" runat="server" CommandName="Add" Visible='<%#Convert.ToInt32(Eval("IsUpdate"))==0?true:false%>' OnClientClick="JavaScript:return CheckValid(this);">Add</asp:LinkButton>
                                                            <asp:LinkButton ForeColor="black" ID="lnkEdit" runat="server" CommandName="Edit" Visible='<%#Convert.ToInt32(Eval("IsUpdate"))==0?false:true%>'>Edit</asp:LinkButton>
                                                            <asp:LinkButton ForeColor="black" ID="lnkDelete" runat="server" OnClientClick="return confirm('Really delete this item?');"
                                                                CommandName="Delete">Delete</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ForeColor="black" ID="lnkUpdate" runat="server" CommandName="Update">Update</asp:LinkButton>
                                                            <asp:LinkButton ForeColor="black" ID="lnkCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table width="100%" border="0" cellspacing="0" cellpadding="2" class="da_table_border">
                                    <caption class="caption_headings_da">
                                        Cutting Section</caption>
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="grdCutting" runat="server" AutoGenerateColumns="False" Width="80%"
                                                ShowFooter="True" OnRowCommand="grdCutting_RowCommand" OnRowDataBound="grdCutting_RowDataBound"
                                                OnRowEditing="grdCutting_RowEditing" OnRowDeleting="grdCutting_RowDeleting" HeaderStyle-BackColor="#bdc3cf"
                                                HeaderStyle-Height="23px" HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center"
                                                OnRowCancelingEdit="grdCutting_RowCancelingEdit" OnRowUpdating="grdCutting_RowUpdating">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Qty. Range" HeaderStyle-Width="29%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="TextBox1" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="80px" runat="server" Text='<%#Eval("Minsize")%>'></asp:Label>
                                                            -
                                                            <asp:Label ID="TextBox2" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="80px" runat="server" Text='<%#Eval("Maxsize")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtQtyRangeFrom" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="80px" runat="server" Text='<%#Eval("Minsize")%>' MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                            -
                                                            <asp:TextBox ID="txtQtyRangeTo" ForeColor="blue" Style="text-align: center;" BorderStyle="None"
                                                                Width="80px" runat="server" Text='<%#Eval("Maxsize")%>' MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                            <asp:HiddenField ID="hdnIDCutting" runat="server" Value='<%#Eval("Wastage_admin_id") %>' />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtQtyRangeFromFooter" Style="text-align: center;" ForeColor="blue"
                                                                BorderStyle="None" Width="80px" runat="server" class="textbox" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                            -
                                                            <asp:TextBox ID="txtQtyRangeToFooter" Style="text-align: center;" ForeColor="blue"
                                                                BorderStyle="None" Width="80px" runat="server" class="textbox" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qty. Units" Visible="false" HeaderStyle-Width="29%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlUnit" Width="140px" runat="server">
                                                                <asp:ListItem Text="Mtr" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlUnitFooter" Width="140px" runat="server">
                                                                <asp:ListItem Text="Mtr" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cutting Wastage (%)">
                                                        <ItemTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:HiddenField ID="hdnIDCutting23" runat="server" Value='<%#Eval("Wastage_admin_id") %>' />
                                                                <asp:Label ID="lblCuttingWastage" Style="text-align: center;" ForeColor="blue" BorderStyle="None"
                                                                    Width="80px" runat="server" Text='<%#Eval("Cutting_percent")%>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:TextBox ID="txtCuttingWastage" Style="text-align: center;" ForeColor="blue"
                                                                    BorderStyle="None" Width="80px" runat="server" Text='<%#Eval("Cutting_percent")%>'></asp:TextBox>
                                                            </div>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:TextBox ID="txtCuttingWastageFooter" Style="text-align: center;" ForeColor="blue"
                                                                    BorderStyle="None" Width="80px" runat="server" class="textbox"></asp:TextBox>
                                                            </div>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:LinkButton ForeColor="black" ID="lnkEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                                                                <asp:LinkButton ForeColor="black" ID="lnkDelete" runat="server" OnClientClick="return confirm('Really delete this item?');"
                                                                    CommandName="Delete">Delete</asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:LinkButton ForeColor="black" ID="lnkUpdate" runat="server" CommandName="Update">Update</asp:LinkButton>
                                                                <asp:LinkButton ForeColor="black" ID="lnkCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton></div>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert"
                                                                    Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'></asp:LinkButton>
                                                            </div>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr style="text-align: center; font-family: Arial;" class="da_table_td">
                                                            <td width="29%">
                                                                Qty. Range
                                                            </td>
                                                            <td>
                                                                Cutting Wastage (%)
                                                            </td>
                                                            <td>
                                                                Action
                                                            </td>
                                                        </tr>
                                                        <tr style="text-align: center;">
                                                            <td>
                                                                <asp:TextBox ID="txtQtyRangeFromEmpty" ForeColor="blue" Style="text-align: center;"
                                                                    BorderStyle="None" Width="80px" runat="server" MaxLength="5" onkeypress="JavaScript:return floatValidation(event,this)" />
                                                                -
                                                                <asp:TextBox Style="text-align: center;" ForeColor="blue" BorderStyle="None" ID="txtQtyRangeTOEmpty"
                                                                    Width="80px" runat="server" MaxLength="5" onkeypress="JavaScript:return floatValidation(event,this)" />
                                                            </td>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCuttingWastageEmpty" Style="text-align: center;" ForeColor="blue"
                                                                    BorderStyle="None" runat="server" MaxLength="5" onkeypress="JavaScript:return floatValidation(event,this)" />
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ForeColor="black" ID="addbutton" runat="server" CommandName="addnew"
                                                                    Text="Add" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table align="left" border="0" cellspacing="4" cellpadding="2">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
