<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuyingHouseForm.ascx.cs"
    Inherits="iKandi.Web.BuyingHouseForm" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .txtFillReq
    {
        position: absolute;
        left: 10px;
        font-size: 10px;
        top: 5px;
    }
    .header-text-back
    {
        position: relative;
        font-size: 15px;
    }
    .da_table_border td:first-child
    {
        border-left-color: #999 !important;
    }
    .da_table_border td:last-child
    {
        border-right-color: #999 !important;
    }
    .da_table_border tr:last-child > td
    {
        border-bottom-color: #999 !important;
    }
</style>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanal1" runat="server">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlForm">
            <div class="print-box">
                <div class="client_form">
                    <h2 class="header-text-back">
                        <span class="txtFillReq">(<span class="da_astrx_mand">*</span> Please fill all required
                            fields)</span> Registration Form - New Buying House
                    </h2>
                    <table width="100%" border="0" align="center" cellpadding="6" cellspacing="0" class="da_table_border">
                        <tr>
                            <td class="td-sub_headings" width="25%">
                                Buying House Name<span class="da_astrx_mand">*</span>:
                            </td>
                            <td class="inner_tbl_td" width="25%">
                                <asp:TextBox ID="txtCompany" CssClass="client-company input_in" runat="server" MaxLength="45"></asp:TextBox>
                                <div class="form_error">
                                    <asp:RequiredFieldValidator ID="rfv_company" runat="server" Display="Dynamic" ControlToValidate="txtCompany"
                                        ErrorMessage=" BUYING HOUSE NAME IS REQUIRED"></asp:RequiredFieldValidator></div>
                            </td>
                            <td class="td-sub_headings" width="25%">
                                Buying House Since:
                            </td>
                            <td class="inner_tbl_td" width="25%">
                                <asp:TextBox runat="server" ID="txtClient" CssClass="date-picker date_style input_in"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-sub_headings" width="25%">
                                Website:
                            </td>
                            <td class="inner_tbl_td" width="25%">
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="input_in" MaxLength="98"></asp:TextBox>
                            </td>
                            <td class="td-sub_headings" width="25%">
                                Address:
                            </td>
                            <td class="inner_tbl_td" width="25%">
                                <asp:TextBox runat="server" CssClass="input_in" ID="txtAddress" MaxLength="198" />
                                <div class="form_error">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-sub_headings" width="25%">
                                Phone:
                            </td>
                            <td class="inner_tbl_td" width="25%">
                                <asp:TextBox runat="server" CssClass="input_in" ID="txtPhone" MaxLength="18" />
                                <div class="form_error">
                                </div>
                            </td>
                            <td class="td-sub_headings" width="25%">
                                Email:
                            </td>
                            <td class="inner_tbl_td" width="25%">
                                <asp:TextBox runat="server" CssClass="input_in" ID="txtEmail" MaxLength="198" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-sub_headings">
                                Buying House Code
                            </td>
                            <td class="inner_tbl_td" width="25%">
                                <asp:TextBox runat="server" CssClass="input_in" ID="txtBHCode" MaxLength="98" />
                            </td>
                            <td class="td-sub_headings">
                                Is Active :
                                <asp:CheckBox ID="CheckIsActive" runat="server" />
                            </td>
                            <td width="25%">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="form_box" style="display: none;">
                <div class="form_small_heading">
                    <b>Internal Assignments</b></div>
                <table cellspacing="15" width="100%">
                    <tr>
                        <td width="20%">
                            Sales:
                        </td>
                        <td width="30%">
                            <asp:DropDownList runat="server" ID="ddlSales" AppendDataBoundItems="true" Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="20%">
                            Designer*:
                        </td>
                        <td width="30%">
                            <asp:DropDownList runat="server" ID="ddlDesign" AppendDataBoundItems="true" Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="form_error">
                                <asp:RequiredFieldValidator ID="rfv_ddlDesign" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="ddlDesign" InitialValue="-1" ErrorMessage="Select design contact"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            A/C Manager*:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Account" AppendDataBoundItems="true" Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="form_error">
                                <asp:RequiredFieldValidator ID="rfv_account" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="ddl_Account" InitialValue="-1" ErrorMessage="Select A/C Manager"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            Technologist:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Techmanager" AppendDataBoundItems="true"
                                Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Shipping Manager*:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Exportmgr" AppendDataBoundItems="true" Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="form_error">
                                <asp:RequiredFieldValidator ID="rfv_exportmgr" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="ddl_Exportmgr" InitialValue="-1" ErrorMessage="Select Export Manager"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            Delivery Manager*:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Delivery" AppendDataBoundItems="true" Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="form_error">
                                <asp:RequiredFieldValidator ID="rfv_Delivery" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="ddl_Delivery" InitialValue="-1" ErrorMessage="Select Client Factory Contact"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Production Merchandiser*:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Fitmerchant" AppendDataBoundItems="true"
                                Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="form_error">
                                <asp:RequiredFieldValidator ID="rfv_Fitmerchant" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="ddl_Fitmerchant" InitialValue="-1" ErrorMessage="Select Production  Merchandiser"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            Sampling Merchant*:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Samplingmerchant" AppendDataBoundItems="true"
                                Width="200">
                                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="form_error">
                                <asp:RequiredFieldValidator ID="rfv_Sampling" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="ddl_Samplingmerchant" InitialValue="-1" ErrorMessage="Select FIT Merchant"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="form_buttom">
                <asp:Button runat="server" ID="btnSubmit" CssClass=" da_submit_button submit" Text="Submit"
                    OnClick="Submit_Click" />
                <input type="button" id="btnPrint" class=" da_submit_button" value="Print" runat="server"
                    onclick="return PrintPDFQueryString('','','','&btn=1');" />
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlMessage" Visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="10" class="da_table_heading_bg_left">
                        &nbsp;
                    </td>
                    <td width="1205" class="da_table_heading_bg">
                        <span class="da_h1">Confirmation</span>
                    </td>
                    <td width="13" class="da_table_heading_bg_right">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="form_box" style="border: solid 1px #dedede;">
                <div class="text-content">
                    Buying House have been saved into the system successfully!
                    <br />
                    <a id="A1" href="~/internal/BuyingHouse/BuyingHouseList.aspx" runat="server">Click here</a>
                    to view Buying House List.</div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
