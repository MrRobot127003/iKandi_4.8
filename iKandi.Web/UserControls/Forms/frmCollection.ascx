<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmCollection.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.frmCollection" %>
<div style="width: 400px;" class="floatLeft">
    <h4 style="background: #3a5795;font-weight:500; padding: 2px 0px;font-size:14px; color: #fff; text-align: center; margin-bottom: 0;">
                    Collection Admin
                </h4>
                <div style="max-width: 100%;">
                    <span> 
                       <asp:TextBox ID="txtSearch" runat="server" autocomplete="off" Width="158px" style='text-transform: unset;padding-left:3px'></asp:TextBox>
                       &nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" onclick="btnSearch_Click"
                          />                         
                      </span>
                </div>
                <table class="AddClass_Table" cellspacing="0" cellpadding="0" border="0" style="width: 100%;
                    margin-bottom: 5px;">
                    <tr>
                        <th>
                          Collection Name
                        </th>                       
                        <th style="width: 60px;">
                            Is Active
                        </th>
                        <th style="width: 60px;">
                            Action
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txCollectionName" runat="server" autocomplete="off"></asp:TextBox>                             
                        </td>
                        
                        <td>
                            <asp:CheckBox ID="cbIsActive" runat="server" />
                        </td>
                        <td style="width: 40px">
                            <asp:ImageButton ID="btnAdd_Marketing" runat="server" 
                                ImageUrl="~/images/add-butt.png"  onclick="btnAdd_Marketing_Click"/>
                                
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grdCollectionAdmin" runat="server" 
            AutoGenerateColumns="false" CssClass="AddClass_Table" Width="400px" 
            BorderWidth="0" onrowcancelingedit="grdCollectionAdmin_RowCancelingEdit" 
            onrowediting="grdCollectionAdmin_RowEditing" 
            onrowupdating="grdCollectionAdmin_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="Collection Name">
                            <ItemTemplate>
                                <asp:Label ID="txCollectionName" runat="server" Text='<%# Bind("CollectionName") %>' ></asp:Label>
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("Id") %>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txCollectionName" runat="server" Text='<%# Bind("CollectionName") %>'></asp:TextBox>                                
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%# Bind("Id") %>'/>
                            </EditItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Is Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbIsActive" runat="server" Enabled="false" Checked='<%# Bind("IsActive") %>' /> 
                            </ItemTemplate>
                             <EditItemTemplate>
                                <asp:CheckBox ID="cbIsActive" runat="server" Checked='<%# Bind("IsActive") %>' />
                            </EditItemTemplate>
                              <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_Edit" ImageUrl="../../images/edit2.png" Style="position: relative;
                                    top: 2px" ToolTip="Edit" CommandName="Edit" runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btn_Update" ImageUrl="~/images/Save.png" ToolTip="Update" Style="width: 18px;"
                                    CommandName="Update" runat="server" />
                                <asp:ImageButton ID="btn_Cancel" ImageUrl="~/images/Cancel1.jpg" ToolTip="Cancel"
                                    Style="width: 25px;" CommandName="Cancel" runat="server" />
                            </EditItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle CssClass="border_right_color textCenter" />
                            <FooterTemplate>
                                <asp:ImageButton ID="btn_add" runat="server" ImageUrl="~/images/add-butt.png" CommandName="AddRow"
                                     />
                            </FooterTemplate>
                            <FooterStyle CssClass="textCenter" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
