<%@ Page Language="C#" Title="Unit Admin" MasterPageFile="~/layout/Secure.Master"
    AutoEventWireup="true" CodeBehind="UnitAdmin.aspx.cs" Inherits="iKandi.Web.Admin.Categories.UnitAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
        span
        {
            font-size: 11px !important;
            font-family: Verdana;
        }
        .go
        {
            cursor: pointer;
        }
        .item_list th
        {
            border-color: #999 !important;
        }
        .item_list2 td
        {
            border-color: #dbd8d8;
        }  .item_list td
        {
            border-color: #dbd8d8;
        }
        .item_list2 th
        {
            border-color: #999 !important;
        }
        select
        {
            cursor: pointer;
        }
        .item_list
        {
            margin-top:2px;
        }
         table tr:nth-last-child(1)>td {
          border-bottom-color:#999;
        }
        
    </style>
    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div style="width: 500px; margin: 0px auto;">
                <h2 style="width: 99.8%; border: 1px solid gray">
                    Unit Admin
                </h2>
                <table cellpadding="0" cellspacing="0" width="350px" border="0" class="item_list2">
                    <tr>
                        <th>
                            Unit
                        </th>
                        <th style="background-color:#fff">
                            <asp:DropDownList runat="server" ID="ddlAdminUnit" Width="90%" OnSelectedIndexChanged="ddlAdminUnit_SelectedIndexChanged" style="height:20px">
                                <asp:ListItem Selected="True" Value="-1" Text="Select Unit"></asp:ListItem>
                            </asp:DropDownList>
                        </th>
                        <th style="background-color:#fff">
                            <asp:Button ID="btnGoProcess" runat="server" OnClick="btn_Go" CssClass="go" Text="Go" />
                        </th>
                    </tr>
                </table>
                <asp:GridView runat="server" ID="grdUnitAdmin" Width="100%" CellPadding="0" CellSpacing="0"
                    AutoGenerateColumns="false" ShowFooter="true" ShowHeader="false" OnRowDataBound="grdUnitAdmin_RowDataBound"
                    OnRowCommand="grdUnitAdmin_OnRowCommand" OnRowUpdating="grdUnitAdmin_RowUpdating"
                    OnRowEditing="grdUnitAdmin_RowEditing" OnRowCancelingEdit="grdUnitAdmin_RowCanceling"
                    CssClass="item_list" onrowcreated="grdUnitAdmin_RowCreated">
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Unit">--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblUnitName" Text='<%# Eval("UnitName")%>'></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnGroupUnitId" Value='<%# Eval("GroupUnitID")%>' />
                            </ItemTemplate>
                            <HeaderStyle Width="90px" />
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="Edit_UnitName" MaxLength="20" Width="95%" Text='<%# Eval("UnitName")%>'></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hdnGroupUnitId" Value='<%# Eval("GroupUnitID")%>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox runat="server" ID="Foo_UnitName" MaxLength="20" Width="95%"></asp:TextBox>
                            </FooterTemplate>
                             <FooterStyle CssClass="border_left_color" />
                            <ItemStyle CssClass="border_left_color" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Convert to Per Pcs">--%>
                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblConvertPerPcs" Text='<%# Eval("ConvertToPerPcs").ToString()=="0" ? "" : Eval("ConvertToPerPcs")%>'></asp:Label>
                                
                            </ItemTemplate>
                            <HeaderStyle Width="90px" />
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="Edit_ConvertPerPcs" Width="95%" Text='<%# Eval("ConvertToPerPcs").ToString()=="0" ? "" : Eval("ConvertToPerPcs")%>'
                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox runat="server" ID="Foo_ConvertPerPcs" Width="95%" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <%--added by raghvinder on 23-09-2020 start--%>
                        <asp:TemplateField HeaderStyle-Width="90px">                            
                            <ItemTemplate> 
                                <asp:CheckBox ID="chkFabric" runat="server" Enabled="false" Value='<%# Eval("IsFabric") %>' />                                
                               <asp:HiddenField runat="server" ID="hdnIsFabric" Value='<%# Eval("IsFabric") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>                               
                                <asp:CheckBox ID="chkEditFabric" runat="server"  Value='<%# Eval("IsFabric") %>' />                                
                                <asp:HiddenField runat="server" ID="hdnIsFabricEdit" Value='<%# Eval("IsFabric") %>' />
                            </EditItemTemplate> 
                            <FooterTemplate>
                                <asp:CheckBox ID="chkFooFabric" runat="server" Value='<%# Eval("IsFabric") %>' />
                            </FooterTemplate>
                             <FooterStyle CssClass="border_left_color" />                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="90px">                            
                            <ItemTemplate>                                 
                                <asp:CheckBox ID="chkAccessory" runat="server" Enabled="false" Value='<%# Eval("IsAccessory") %>' /> 
                                <asp:HiddenField runat="server" ID="hdnIsAccessory" Value='<%# Eval("IsAccessory") %>' />                              
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkEditAccessory" runat="server" Value='<%# Eval("IsAccessory") %>' />
                                <asp:HiddenField runat="server" ID="hdnIsAccessoryEdit" Value='<%# Eval("IsAccessory") %>' />
                            </EditItemTemplate>                            
                            <FooterTemplate>
                                <asp:CheckBox ID="chkFooAccessory" runat="server" Value='<%# Eval("IsAccessory") %>' />
                            </FooterTemplate>
                             <FooterStyle CssClass="border_left_color" /> 
                        </asp:TemplateField>
                        <%--added by raghvinder on 23-09-2020 end--%>

                        <asp:TemplateField HeaderStyle-Width="90px">
                            <%--<HeaderTemplate>
                                Is Active
                            </HeaderTemplate>--%>
                            <ItemTemplate>
                               <%--<asp:DropDownList runat="server" ID="ddlIsActive" Width="80%" Enabled="false">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="In Active"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:Label ID="lblActiveDective" runat="server" Text="" ></asp:Label>
                               <asp:HiddenField runat="server" ID="hdnIsActive" Value='<%# Eval("ACTIVE") %>' />
                               <asp:HiddenField runat="server" ID="hdnUnit" Value='<%# Eval("Unit") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlIsActive" Width="80%" Enabled="true" style="height: 19px;">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="In Active"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField runat="server" ID="hdnIsActiveEdit" Value='<%# Eval("ACTIVE") %>' />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList runat="server" ID="ddlFooIsActive" Width="80%" Enabled="true" style="height: 19px;">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="In Active"></asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                             <FooterStyle CssClass="border_left_color" />
                        </asp:TemplateField>
                         <asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;'
                        HeaderText="Action" ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/Cancel1.jpg" width="25px" title="Cancel" alt="Cancel" /&gt;'
                        UpdateText='&lt;img src="../../images/Save.png" title="Update" width="18px" alt="Update" /&gt;' 
                        CausesValidation="true">
                          <ItemStyle HorizontalAlign="Center" />
                         <HeaderStyle Width="65px" />
                      </asp:CommandField>
                       <%-- <asp:CommandField HeaderText="Action" EditImageUrl="../../images/edit2.png" ShowEditButton="True"
                            ButtonType="Image" CancelImageUrl="../../images/Cancel1.jpg" UpdateImageUrl="../../images/Save.png"
                            CausesValidation="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="65px" />
                        </asp:CommandField>--%>
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:LinkButton runat="server" ID="Submit" CommandName="Insert">
                       <img src="../../images/add-butt.png" />
                                </asp:LinkButton>
                            </FooterTemplate>
                            <FooterStyle CssClass="border_right_color" />
                            <ItemStyle Width="40px" CssClass="border_right_color"  />
                        </asp:TemplateField>
                      
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <th style="width: 90px;">
                                    Unit
                                </th>
                                <th style="width: 90px;">
                                    Convert Per Pcs
                                </th>
                                <%--added by raghvinder on 23-09-2020 start--%>
                                <th style="width: 90px;">
                                    IsFabric
                                </th>
                                <th style="width: 90px;">
                                    IsAccessory
                                </th>
                                <%--added by raghvinder on 23-09-2020 end--%>
                                <th style="width: 90px;">
                                    Active
                                </th>
                                <th style="width: 40px;">
                                    Action
                                </th>
                                <th>
                                    &nbsp;
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtUnitAdmin" Text="" Width="95%" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtConvertPerPcs" Text="" Width="95%" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                </td>
                                <%--added by raghvinder on 23-09-2020 start--%>
                                <td>
                                   <asp:CheckBox ID="chkFabric" runat="server"  />
                                </td>
                                <td>
                                   <asp:CheckBox ID="chkAccessory" runat="server"  />
                                </th>
                                <%--added by raghvinder on 23-09-2020 end--%>
                                <td>
                                <asp:DropDownList runat="server" ID="ddlIsActive" Width="80%" Enabled="true" style="height: 19px;">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="In Active"></asp:ListItem>
                                </asp:DropDownList>
                                    <%--&nbsp;--%>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="Submit" CommandName="EmptyInsert">
    <img src="../../images/add-butt.png" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
