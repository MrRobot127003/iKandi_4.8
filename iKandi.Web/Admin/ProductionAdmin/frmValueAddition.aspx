<%@ Page Title="Value Addition" Language="C#" MasterPageFile="~/layout/Secure.Master"
    AutoEventWireup="true" CodeBehind="frmValueAddition.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.frmValueAddition" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script language="javascript" type="text/javascript">


        function Resetstatus(elem) {
            // debugger;                   
            var ctlid = elem.id.split("_")[5];
            var fromstatus = $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid + "_ddlfromstatus").val();
            $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").html("");
            if (fromstatus == "10") {
                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option selected='selected' value='-1'> Select </option>");
                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option value='29'>Inline Cut</option>");

            }
            else {

                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option selected='selected' value='-1'> Select </option>");
                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option value='10'> NEW ORDER </option>");
                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option value='29'>Inline Cut</option>");
                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option value='37'>Cutting</option>");
                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option value='39'>Stitching</option>");
                $("#ctl00_cph_main_content_grdValueAddititon_" + ctlid.toString() + "_ddltostatus").append("<option value='40'>Finishing</option>");
            }
        }
   
   
    </script>
    <%--new code 12 feb 2020 start--%>
    <script type="text/javascript">

        function isNumberKeyfloat(evt, val) {
            //debugger;
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            else {
                var len = val.value.length;
                var index = val.value.indexOf('.');

                if (index > 0 && charCode == 46) {
                    return false;
                }
                if (index > 0) {
                    var CharAfterdot = (len + 1) - index;
                    if (CharAfterdot > 3) {
                        return false;
                    }
                }
            }
            return true;
        }
    </script>
    <%--new code 12 feb 2020 start--%>
    <style>
        a[disabled="disabled"]
        {
            cursor: no-drop;
        }
        a
        {
            cursor: pointer;
        }
        .submit
        {
            cursor: pointer;
        }
        .font.bottomtable td
        {
            border-color: #dbd8d8;
            background: #f9f9f9;
            color: #373737;
        }
        .font.bottomtable
        {
            margin-bottom:30px;
            }
        table.font.bottomtable tr:nth-last-child(1) > td
        {
            border-bottom-color: #999;
        }
        .item_list TD input[type="text"], .item_list TD select {
    border: 1px solid #bdb5b5 !important;
    color: : #373737;
}
    </style>
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper item_list">
                    <tr>
                        <td style="font-size: 20px; text-align: center; color: Black; font-family: Lucida Sans Unicode;
                            height: 40px; text-transform: capitalize; font-weight: bold;">
                            Value Addition Admin
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table width="100%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px;
                                        width: 99.5%; margin-left: 4px;">
                                        <tr class="td-sub_headings border">
                                            <th width="7%">
                                                From status
                                            </th>
                                            <th width="10%" style="background: #fff; border-left: 0px;">
                                                <asp:DropDownList ID="ddldfromstatus" OnSelectedIndexChanged="ddldfromstatus_SelectedIndexChanged"
                                                    AutoPostBack="True" Width="90%" runat="server" BackColor="#F6F1DB">
                                                    <%--<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </th>
                                            <th width="5%" style="border-left: 0px;">
                                                To status
                                            </th>
                                            <th width="10%" style="background: #fff; border-left: 0px;">
                                                <asp:DropDownList ID="ddltostatus" runat="server" Width="90%" BackColor="#F6F1DB"
                                                    ForeColor="#7d6754" CssClass="ddl select-con" Style="line-height: 20px !important;">
                                                    <%--  <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </th>
                                            <th width="5%" style="border-left: 0px;">
                                                VA Name
                                            </th>
                                            <th width="15%" style="background: #fff; border-left: 0px;">
                                                <%--<input style="text-transform: none; width: 100px;" runat="server" id="txtVaname"
                                                    maxlength="100" onpaste="return false;" name="" type="text" class="input_in" />--%>
                                                <asp:TextBox ID="txtVaname" MaxLength="100" Width="96%" runat="server"></asp:TextBox>
                                            </th>
                                            <th width="5%" style="border-left: 0px;">
                                                Is Active
                                            </th>
                                            <th width="5%" style="background: #fff; border-left: 0px;">
                                                <asp:CheckBox ID="chkIsAct" runat="server" Checked="false" />
                                            </th>
                                            <th width="5%" style="border-left: 0px;">
                                                Rate
                                            </th>
                                            <th width="15%" style="background: #fff; border-left: 0px;">
                                                <asp:TextBox ID="txtRateHeader" MaxLength="100" Width="96%" runat="server" onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                                            </th>
                                            <th width="5%" style="padding: 10px; background: #fff; color: White; border-left: 0px;">
                                                <asp:Button ID="btnsubmit" Text="Add" CssClass="submit" runat="server" OnClick="btnsubmit_Click"
                                                    Style="margin-right: 5px;" />
                                                <%-- <asp:Button ID="btnSearch" Text="Search" CssClass="submit" runat="server" 
                                                    OnClick="btnSearch_Click" />--%>
                                            </th>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <%--    <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td style="padding-bottom: 10px;">
                                                            <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;">
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td valign="top">
                                                <!--table2-->
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grdValueAddititon" runat="server" CssClass="font bottomtable" AutoGenerateColumns="False"
                                                                Width="100%" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
                                                                HeaderStyle-Font-Size="13px" OnRowCancelingEdit="grdValueAddititon_RowCancelingEdit"
                                                                OnRowUpdating="grdValueAddititon_RowUpdating" OnRowEditing="grdValueAddititon_RowEditing"
                                                                OnRowDataBound="grdValueAddititon_RowDataBound" OnPageIndexChanging="grdValueAddititon_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Font-Bold="false" HeaderStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize; padding-left: 10px;">
                                                                                <%#Container.DataItemIndex + 1 %>
                                                                                <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("ValueAdditionID")%>' />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="border_left_color" />
                                                                        <HeaderStyle Font-Bold="False" Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="From Status" HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize; padding-left: 10px; text-align: center;">
                                                                                <asp:Label ID="lblfromstatus" Text='<%#Eval("fromstatusName")%>' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <div style="text-transform: capitalize; text-align: center;">
                                                                                <asp:DropDownList ID="ddlfromstatus" onchange="Resetstatus(this);" runat="server"
                                                                                    CssClass="ddl">
                                                                                </asp:DropDownList>
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" Width="20%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To status" HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <div style="padding-left: 10px; text-align: center;">
                                                                                <asp:Label ID="lbltostatus" Text='<%#Eval("tostatusname")%>' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <div style="padding-left: 10px; text-align: center;">
                                                                                <asp:DropDownList ID="ddltostatus" runat="server">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" Width="20%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="VA Name" HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <div style="padding-left: 10px;">
                                                                                <asp:TextBox ID="txtvaname" MaxLength="100" Width="90%" runat="server" Text='<%#Eval("ValueAdditionName")%>'></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <div style="padding-left: 10px;">
                                                                                <asp:TextBox ID="txtvaname_edit" MaxLength="100" Width="90%" runat="server" Text='<%#Eval("ValueAdditionName")%>'></asp:TextBox>
                                                                            </div>
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" Width="20%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Is Active" HeaderStyle-Font-Bold="false" HeaderStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <div style="padding-left: 10px; text-align: center;">
                                                                                <asp:Label runat="server" ID="lblIsact" Text=""></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <div style="padding-left: 10px; text-align: center;">
                                                                                <asp:CheckBox ID="chkIsact" runat="server" />
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <%--new code 10 feb 2020 start--%>
                                                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Font-Bold="false" HeaderStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <div style="padding-left: 10px; text-align: center;">
                                                                                <asp:Label runat="server" ID="lblRate" Text='<%#Eval("RATE")%>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <div style="padding-left: 10px; text-align: center;">
                                                                                <asp:TextBox ID="txtRate" MaxLength="100" Width="90%" runat="server" Text='<%#Eval("RATE")%>'
                                                                                    onkeypress="return isNumberKeyfloat(event, this)"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <%--new code 10 feb 2020 End--%>
                                                                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Font-Bold="false" HeaderStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <div style="text-align: center; text-transform: capitalize;">
                                                                                <asp:LinkButton ID="lnkEdit" ForeColor="blue" runat="server" CommandName="Edit"><img src="../../images/edit2.png" alt="Edit" />
                                                                          
                                                                                
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="border_right_color" />
                                                                        <EditItemTemplate>
                                                                            <div style="text-align: center; text-transform: capitalize;">
                                                                                <asp:LinkButton ID="lnkUpdate" ForeColor="blue" runat="server" CommandName="Update"><img src="../../images/Save.png" title="Update" width="18px" alt="Update"></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkCancel" ForeColor="blue" runat="server" CommandName="Cancel"><img src="../../images/Cancel1.png" title="Cancel" width="25px" alt="Cancel"></asp:LinkButton>
                                                                            </div>
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" Width="10%" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="border2" Font-Size="13px" HorizontalAlign="Center" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <!--end-->
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnsubmit" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
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
</asp:Content>
