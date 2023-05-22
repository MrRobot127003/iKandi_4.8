<%@ Page Language="C#" Title="Add Process and Mode Cost" MasterPageFile="~/layout/Secure.Master"
    AutoEventWireup="true" CodeBehind="AddProcessAndModeCost.aspx.cs" Inherits="iKandi.Web.Admin.Costing.AddProcessAndModeCost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
        input[type="text"]
        {
            width: 90% !important;
        }
        .imagelink
        {
            background: url(../../images/add-butt.png) no-repeat left top;
            padding-left: 25px;
        }
        .item_list th
        {
            border-color: #999 !important;
        }
          .item_list td
        {
            border-color: #dbd8d8 ;
        }
          table tr:nth-last-child(1)>td {
          border-bottom-color:#999;
        }
    </style>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad() {
            $('.numeric').keypress(function (event) {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
    ((event.which < 48 || event.which > 57) &&
      (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();

                if ((text.indexOf('.') != -1) &&
    (text.substring(text.indexOf('.')).length > 2) &&
    (event.which != 0 && event.which != 8) &&
    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:updatepanel ID="Updatepanel1"  runat="server">
    <ContentTemplate> 
    <div style="width: 395px; margin: 0px auto;">
        <h2 style="width: 100%;border:1px solid gray">
            Process & Mode Cost
        </h2>
        <table cellpadding="0" cellspacing="0" border="0" width="0">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="0">
                        <tr>
                            <td style="width: 118px;">
                                Mode Cost In Pence
                            </td>
                            <td style="width: 50px;">
                                <asp:TextBox ID="TxtModeCostPence" runat="server" 
                                    CssClass="numeric-field-without-decimal-places" MaxLength="6" Text="" 
                                    Width="95%"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px;">
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Add_ModeCostdata">
                       <img src="../../images/add-butt.png" />
                            </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="2%">
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="0" style="margin-bottom: 5px;">
                        <tr>
                            <td style="width: 126px;">
                                Process Cost In Pence
                            </td>
                            <td style="width: 50px;">
                                <asp:TextBox ID="TxtProcessCostPence" runat="server" 
                                    CssClass="numeric-field-without-decimal-places" MaxLength="6" Text="" 
                                    Width="95%"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px;">
                                <asp:LinkButton ID="Submit" runat="server" CommandName="EmptyInsert" 
                                    OnClick="Add_Processdata">
                        <img src="../../images/add-butt.png" />
                            </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="49%" valign="top">
                    <asp:GridView runat="server" ID="grdModeCost" AutoGenerateColumns="false" CssClass="item_list"
                        CellPadding="0" CellSpacing="0" OnRowDataBound="grdModeCost_RowDataBound" OnRowCommand="grdModeCost_OnRowCommand"
                        OnRowUpdating="grdModeCost_RowUpdating" OnRowEditing="grdModeCost_RowEditing"
                        OnRowCancelingEdit="grdModeCost_RowCanceling">
                        <Columns>
                            <asp:TemplateField HeaderText="Seq No." HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField runat="server" ID="hdnModeId" Value='<%# Eval("Id")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField runat="server" ID="hdnModeId" Value='<%# Eval("Id")%>' />
                                </EditItemTemplate>
                                <ItemStyle CssClass="border_left_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mode Cost In Pence">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblModeCost" Text='<%# String.Format("{0:0.##}", Eval("ModeCost"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txtModeCost" Text='<%# String.Format("{0:0.##}", Eval("ModeCost"))%>'
                                        CssClass="numeric"
                                        MaxLength="6"> </asp:TextBox>
                                </EditItemTemplate>
                                <%--  <FooterTemplate>
                         <asp:TextBox runat="server" ID="Foo_txtModeCost" onkeypress="return onlyNumbersWithDot(event)" MaxLength="2"></asp:TextBox>
                      </FooterTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lkUpdate" runat="server" CausesValidation="true" CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel">
                                     <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 3px;" />
                                    </asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle Width="60" CssClass="border_right_color" />
                            </asp:TemplateField>
                            <%--  <asp:CommandField  HeaderText="Action" EditImageUrl="../../images/edit2.png"
                            ShowEditButton="True" ButtonType="Image" UpdateImageUrl="../../images/update.gif"             
                           CancelImageUrl="../../images/del-butt.png" CausesValidation="true">
                    <ItemStyle HorizontalAlign="Center"/> 
                       <HeaderStyle Width="65px" />               
                </asp:CommandField> --%>
                            <%--  <asp:TemplateField HeaderText="Add" HeaderStyle-Width="40px"> 
                              
                       <FooterTemplate>
                         <asp:LinkButton runat="server" ID="Submit"  OnClick="Add_data" CommandName="Insert">
                           <img src="../../images/add-butt.png" />
                        </asp:LinkButton>
                    </FooterTemplate>  
                <ItemStyle Width="40px" />   
              </asp:TemplateField>     --%>
                        </Columns>
                        <%-- <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%"> 
                    <tr>
                       <th style="width:30px;">
                       Seq No.
                       </th>
                       <th>
                       Mode Cost In Pence
                       </th>       
                       <th style="width:40px;"> Action </th>
                       <th> Add </th>
                    </tr>  
                    <tr>
                        <td>
                        &nbsp;
                        </td>
                        <td>
                        <asp:TextBox runat="server" ID="TxtModeCostPence" Text="" Width="95%" onkeypress="return onlyNumbersWithDot(event)" MaxLength="2"></asp:TextBox>
                        </td>
                       <td> &nbsp; </td>
                        <td>
                        <asp:LinkButton  runat="server" ID="Submit"  OnClick="Add_data" CommandName="EmptyInsert">
                        <img src="../../images/add-butt.png" />
                            </asp:LinkButton>
                        </td>
                    </tr>
    
                    </table>
                </EmptyDataTemplate>--%>
                    </asp:GridView>
                </td>
                <td width="2%">
                </td>
                <td width="49%" valign="top">
                    <asp:GridView runat="server" ID="grdProcessCost" AutoGenerateColumns="false" CssClass="item_list"
                        CellPadding="0" CellSpacing="0" OnRowDataBound="grdProcessCost_RowDataBound"
                        OnRowCommand="grdProcessCost_OnRowCommand" OnRowUpdating="grdProcessCost_RowUpdating"
                        OnRowEditing="grdProcessCost_RowEditing" OnRowCancelingEdit="grdProcessCost_RowCanceling">
                        <Columns>
                            <asp:TemplateField HeaderText="Seq No." HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField runat="server" ID="hdnProcessId" Value='<%# Eval("Id")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField runat="server" ID="hdnProcessId" Value='<%# Eval("Id")%>' />
                                    <%# Container.DataItemIndex + 1 %>
                                </EditItemTemplate>
                                <ItemStyle CssClass="border_left_color" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Process Cost In Pence">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblProcessCost" Text='<%# String.Format("{0:0.##}",Eval("ProcessCost"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="txtProcessCost" Text='<%# String.Format("{0:0.##}",Eval("ProcessCost"))%>'
                                        CssClass="numeric" MaxLength="6"> </asp:TextBox>
                                </EditItemTemplate>
                                <%--  <FooterTemplate>
                         <asp:TextBox runat="server" ID="Foo_txtProcessCost" onkeypress="return onlyNumbersWithDot(event)" MaxLength="2"></asp:TextBox>
                      </FooterTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit">
                                    <img src="../../images/edit2.png" alt="Edit" title="Edit" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lkUpdate" runat="server" CausesValidation="true" CommandName="Update">
                                    <img src="../../images/save.png" alt="Update" title="Update" border="0" style="width:18px" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel">
                                     <img src="../../images/cancel1.jpg" alt="Cancel" title="Cancel" border="0" style="width:25px;position: relative; top: 3px;" />
   
                                    </asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle Width="60" CssClass="border_right_color" />
                            </asp:TemplateField>
                            <%--  <asp:CommandField  HeaderText="Action" EditImageUrl="../../images/edit2.png"
                            ShowEditButton="True" ButtonType="Image"  UpdateImageUrl="../../images/update.gif"             
                           CancelImageUrl="../../images/del-butt.png" CausesValidation="true">
                    <ItemStyle HorizontalAlign="Center"/> 
                       <HeaderStyle Width="65px" />               
                </asp:CommandField> --%>
                            <%--  <asp:TemplateField HeaderText="Add" HeaderStyle-Width="40px">         
                <FooterTemplate>
                
                    <asp:LinkButton runat="server" ID="Submit"  OnClick="Add_data" CommandName="Insert">
                       <img src="../../images/add-butt.png" />
                    </asp:LinkButton>
                </FooterTemplate>  
                <ItemStyle Width="40px" />   
              </asp:TemplateField>  --%>
                        </Columns>
                        <%--   <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%"> 
                    <tr>
                       <th style="width:30px;">
                       Seq No.
                       </th>
                       <th>
                       Mode Cost In Pence
                       </th>
                       <th>&nbsp;</th>       
                       <th style="width:40px;"> Action </th>
                       
                    </tr>  
                    <tr>
                        <td>
                        &nbsp;
                        </td>
                        <td>
                        <asp:TextBox runat="server" ID="TxtProcessCostPence" Text="" Width="95%" MaxLength="2"></asp:TextBox>
                        </td>
                    <td> &nbsp;</td>
                        <td>
                        <asp:LinkButton  runat="server" ID="Submit" OnClick="Add_data" CommandName="EmptyInsert">
                        <img src="../../images/add-butt.png" />
                            </asp:LinkButton>
                        </td>
                    </tr>
    
                    </table>
                </EmptyDataTemplate>--%>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
     </ContentTemplate>
      </asp:updatepanel>
</asp:Content>
