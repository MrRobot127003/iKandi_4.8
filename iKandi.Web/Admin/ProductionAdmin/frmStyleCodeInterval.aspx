<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/layout/Secure.Master" CodeBehind="frmStyleCodeInterval.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.frmStyleCodeInterval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
  <style type="text/css">
       
        table
        {
            text-transform:capitalize;
        }
        
       
            .item_list th
            {
                padding:5px 0px !important;
            }
    </style>
    <script type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))

                return false;
            return true;
        }
       
        
      

    </script>
    <div style="width:215px; margin:0px auto;">
    <h2 style="width:210px; color:#fff; background:#39589c; text-align:center; margin:5px 0px; padding:1px; font-size:12px;"> Style Code Interval</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server" /> 

    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">

        <ContentTemplate>
      
          
             <asp:GridView ID="grdStyleCodeInterval" ShowHeader="true" AutoGenerateColumns="false"  runat="server" Width="210px"  CellPadding="0" 
             BorderColor="Gray" ShowFooter="true"  OnRowCommand="grdStyleCodeInterval_OnRowCommand" CssClass="item_list1" OnRowDeleting="grdStyleCodeInterval_RowDeleting">
                <Columns>
                    <asp:TemplateField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderText="From">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnRowID" runat="server" Value='<%# Eval("P_Id") %>' />
                            <asp:Label ID="txtfromQty" style="text-align:center;"  MaxLength="7" Text='<%# Eval("FromRange") %>' runat="server"  Width="90%" onkeypress="return isNumberKey(event)"></asp:Label>
                           
                        </ItemTemplate>
                          <FooterTemplate>
                           <asp:TextBox ID="foo_txtfromQty" style="text-align:center;"  MaxLength="7"  runat="server"  Width="90%" onkeypress="return isNumberKey(event)"></asp:TextBox>
                           
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px"  HeaderText="To">
                        <ItemTemplate>
                         <asp:Label ID="txttoQty" style="text-align:center;"  MaxLength="7" Text='<%# Eval("ToRange") %>' runat="server"  Width="90%" onkeypress="return isNumberKey(event)"></asp:Label>
                                                      
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="Foo_txttoQty" style="text-align:center;"  MaxLength="7" runat="server"  Width="90%" onkeypress="return isNumberKey(event)"></asp:TextBox>
                         
                        </FooterTemplate>
                    </asp:TemplateField>
                 
                    <asp:TemplateField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px" HeaderText="Action">
                        <ItemTemplate>
                             <asp:LinkButton runat="server" ID="lnkDelete" CommandName="Delete" CausesValidation="False">
                                <img src="../../images/del-butt.png" />
                            </asp:LinkButton>
                        </ItemTemplate>
                         <FooterTemplate>
                            <asp:LinkButton runat="server" ID="Submit"  OnClick="Add_data" CommandName="Insert">
                               <img src="../../images/add-butt.png" />
                            </asp:LinkButton>
                </FooterTemplate> 
                    </asp:TemplateField>
                </Columns>

                     <EmptyDataTemplate>
                         <table cellpadding="0" cellspacing="0" width="100%"> 
    <tr>
       <th style="width:90px;">
       From
       </th>
       <th style="width:90px;">
       	To
       </th>
      
       <th style="width:40px;"> Action </th>
      
    </tr>  
    <tr>
    <td>
    <asp:TextBox runat="server" ID="txt_Empty_fromQty" Text="" Width="95%" MaxLength="7" onkeypress="return isNumberKey(event)"></asp:TextBox>

    </td>
    <td>
    <asp:TextBox runat="server" ID="txt_Empty_toQty" Text="" Width="95%" MaxLength="7" onkeypress="return isNumberKey(event)"></asp:TextBox>

    </td>
  
    <td>
    <asp:LinkButton  runat="server" ID="Submit"  OnClick="Add_data" CommandName="EmptyInsert">
    <img src="../../images/add-butt.png" />
        </asp:LinkButton>
    </td>
    </tr>
    
    </table>
                      </EmptyDataTemplate>
            </asp:GridView>
         <br />
        <asp:Button runat="server" ID="btnDeleteAll" CssClass="submit" Text="Delete & Recreate Interval"  onclick="DeleteAllData"   OnClientClick="return confirm('Are you sure to delete the current record?');" />     
        </ContentTemplate>
    </asp:UpdatePanel>

    </div>
</asp:Content>
