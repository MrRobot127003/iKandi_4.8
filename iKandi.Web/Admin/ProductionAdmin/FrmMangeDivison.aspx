<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="FrmMangeDivison.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.FrmMangeDivison" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

<style type="text/css">
.table-header th
{
    padding:10px 0px;
    background:#3a5795;
    color:#fff;
    text-transform:capitalize;
    font-size:12px;
}
.table-header td
{
    padding:0px 0px;

}
.bottom-line table tr
{
    border-bottom:1px solid #ccc;
}
.bottom-line table  tr:last-child
{
    border-bottom:none;
}

</style>
    <h2  style="background: #3a5795;  margin: 0px auto 5px; padding: 5px 0px; width:815px; text-align:center; color:#fff; text-transform:capitalize;">
        Manage Divison</h2>
    <table border="1" cellpadding="0" border-color="#ccc" cellspacing="0" align="center" width="800" style="table-layout: fixed; border-collapse:collapse;" class="table-header">
        <thead >
            <tr >
                <th  width="100px">
                    Group
                </th>
                <th width="150px">
                    Divison Name
                </th>
                <th width="60px">
                    Is Active
                </th>
                <th width="250px">
                    Buying House
                </th>
                <th width="150px">
                    Domain
                </th>
                <th width="100px">
                    Add / Edit
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td colspan="6">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdMangeDivison" runat="server" ShowHeader="false" CssClass="font" AutoGenerateColumns="False"
                                            Width="100%" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Font-Size="13px"
                                            OnRowUpdating="grdMangeDivison_RowUpdating" onrowediting="grdMangeDivison_RowEditing"
                                            OnRowDataBound="grdMangeDivison_RowDataBound" OnPageIndexChanging="grdMangeDivison_PageIndexChanging" OnRowCancelingEdit="grdMangeDivison_RowCancelingEdit" >
                                            <%-- OnRowCancelingEdit="grdMangeDivison_RowCancelingEdit"
                                                    OnRowUpdating="grdMangeDivison_RowUpdating" OnRowEditing="grdMangeDivison_RowEditing"
                                                    OnRowDataBound="grdMangeDivison_RowDataBound" OnPageIndexChanging="grdMangeDivison_PageIndexChanging">--%>
                                            <Columns>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <div style="text-transform: capitalize; padding-left: 10px; text-align: center;">
                                                            <asp:Label ID="lblGroupName" Text='<%#Eval("GroupName")%>' runat="server"></asp:Label>
                                                            
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" />
                                                    <EditItemTemplate>
                                                        <div style="text-transform: capitalize; text-align: center;">
                                                            <asp:TextBox ID="txtGroupname_edit" Width="90%" Text='<%#Eval("GroupName")%>' runat="server"
                                                                MaxLength="70" ToolTip="Group Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="update"
                                                                runat="server" ControlToValidate="txtGroupname_edit" ErrorMessage="Please enter group name"></asp:RequiredFieldValidator>
                                                                <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("ManageDivisionID")%>' />
                                                        </div>

                                                    </EditItemTemplate>
                                                    <HeaderStyle Font-Bold="False" Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <div style="padding-left: 10px; text-align: center;">
                                                            <asp:Label ID="lblDivsionName" Text='<%#Eval("DivisionName")%>' runat="server"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="150px" />
                                                    <EditItemTemplate>
                                                        <div style="padding-left: 10px; text-align: center;">
                                                            <asp:TextBox ID="txtdvisionName_edit" Text='<%#Eval("DivisionName")%>' runat="server"
                                                                MaxLength="100" ToolTip="Divsion Name"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="update"
                                                                runat="server" ControlToValidate="txtdvisionName_edit" ErrorMessage="Please enter divsion name"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </EditItemTemplate>
                                                    <HeaderStyle Font-Bold="False" Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="false" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <div style="padding-left: 10px;">
                                                            <asp:Label ID="lblIsact" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="60px" />
                                                    <EditItemTemplate>
                                                        <div style="padding-left: 10px;">
                                                            <asp:CheckBox ID="chkIsAct" OnCheckedChanged="chkIsAct_CheckedChanged" AutoPostBack="true" runat="server" />
                                                        </div>
                                                    </EditItemTemplate>
                                                    <HeaderStyle Font-Bold="False" Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="false" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div style="padding-left: 10px; text-align: center;">
                                                            <asp:Label runat="server" ID="lblBuyingHouse" Text=""></asp:Label>
                                                            <asp:HiddenField ID="hdnBuyingHousename" runat="server" Value="" />
                                                            
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="250px" />
                                                    
                                                    <EditItemTemplate>
                                                       
                                                            <asp:CheckBoxList ID="ChklistbuyingHouse" runat="server" Width="100%">
                                                            </asp:CheckBoxList><br />
                                                            
                                                           
                                                       
                                                    </EditItemTemplate>
                                                    <ItemStyle CssClass="bottom-line" />
                                                    <HeaderStyle Font-Bold="False" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="false" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div style="padding-left: 10px; text-align: center;">
                                                            <asp:Label runat="server" ID="lblDomain" Text='<%#Eval("DomainName")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="150px" />
                                                    <EditItemTemplate>
                                                        <div style="padding-left: 10px; text-align: center;">
                                                            <asp:TextBox ID="txtdomain" runat="server" MaxLength="100" Text='<%#Eval("DomainName")%>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="update"
                                                                runat="server" ControlToValidate="txtdomain" ErrorMessage="Please enter Domain name"></asp:RequiredFieldValidator>
                                                                </div>
                                                    </EditItemTemplate>
                                                    <HeaderStyle Font-Bold="False" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="false" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <div style="text-align: center; text-transform: capitalize;">
                                                            <asp:LinkButton ID="lnkEdit" ForeColor="blue" runat="server" ToolTip="Edit Record" CommandName="Edit"><img src="../../App_Themes/ikandi/images1/edit.png" alt="Edit" />
                                                                          
                                                                                
                                                            </asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" />
                                                    <EditItemTemplate>
                                                        <div style="text-align: center; text-transform: capitalize;">
                                                            <asp:LinkButton  ID="lnkUpdate" ForeColor="blue" runat="server" ValidationGroup="update"
                                                                CommandName="Update">Update</asp:LinkButton>
                                                            <asp:LinkButton ID="lnkCancel" ForeColor="blue" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                                        </div>
                                                    </EditItemTemplate>
                                                    <HeaderStyle Font-Bold="False" Width="10%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="border2" Font-Size="13px" HorizontalAlign="Center" />
                                        </asp:GridView>
                                        </td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table id="tblinsert" runat="server" width="100%" cellpadding="0" cellspacing="0" bgcolor="#f2f2f2"
                                            border="1" style="text-align: center; border-collapse:collapse;">
                                            <tr>
                                                <td width="100px">
                                                    <asp:TextBox ID="txtgroupname_insert" autocomplete="off" runat="server" MaxLength="100" Style="width: 90%;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="insert"
                                                        runat="server" ControlToValidate="txtgroupname_insert" ErrorMessage="Please enter group name"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="150px">
                                                    <asp:TextBox ID="txtDivison_insert" autocomplete="off" runat="server" MaxLength="100" Style="width: 90%;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="insert"
                                                        runat="server" ControlToValidate="txtDivison_insert" ErrorMessage="Please enter divison name"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="60px">
                                                    <asp:CheckBox ID="chkIsact_insert" runat="server" Checked="false" AutoPostBack="true"
                                                        OnCheckedChanged="chkIsact_insert_CheckedChanged" />
                                                </td>
                                                <td width="250px" align="left" class="bottom-line">
                                                   
                                                        <asp:CheckBoxList ID="chkBuyingHouselist_insert"  runat="server" Width="100%">
                                                        </asp:CheckBoxList>
                                                    
                                                </td>
                                                <td width="150px">
                                                    <asp:TextBox ID="txtdomain_insert" autocomplete="off" runat="server" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="insert"
                                                        runat="server" ControlToValidate="txtdomain_insert" ErrorMessage="Please enter domain name"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="100px">
                                                    <asp:ImageButton ID="btninsert" ValidationGroup="insert" runat="server" ImageUrl="../../images/add-butt.png"
                                                        AlternateText="Add" OnClick="btninsert_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr> 
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <%--</table>
    </td> </tr> </tbody> </table>--%>
</asp:Content>
