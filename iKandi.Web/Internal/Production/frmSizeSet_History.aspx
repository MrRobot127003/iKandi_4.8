<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSizeSet_History.aspx.cs" Inherits="iKandi.Web.Internal.Production.frmSizeSet_History" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .item_list td
    {
        font-family:Verdana;
        color:#787777;
    }
    form
    {
        padding:0px 15px;
    }
      .cfn3 h2
        {
            font-family:Arial;
            font-size:18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 
     <table width="100%"  cellpadding="0" cellspacing="0" style="vertical-align:top;">
            <tr>
                <td align="center">
                    <asp:HiddenField ID="hdnOrderId" runat="server" />
                    <asp:HiddenField ID="hdnOrderDetailId" runat="server" />
                    <asp:HiddenField ID="hdnType" runat="server" />
                    <asp:HiddenField ID="hdnStyleId" runat="server" />
                    <asp:HiddenField ID="hdnStyleNumber" runat="server" />
                    <asp:HiddenField ID="hdnTotalEntry" runat="server" />
                    <asp:HiddenField ID="hdnTotalAlt" runat="server" />
                    <asp:HiddenField ID="hdnCutQty" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnUnitId" Value="0" runat="server" />
                    <asp:Label ID="lblMsg" CssClass="ShowMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="cfn3">
                <td  align="center">
                    <h2 style="background: #3a5795; padding: 5px 0px; color: #fff;">
       <asp:Label ID="lblHeading" runat="server"></asp:Label> &nbsp; History
                    </h2>
                </td>
            </tr>
            </table>
  
 
    
    <table width="100%" cellpadding="0" cellspacing="0">
    <tr>
     <td style="padding-top: 10px !important;" valign="top" >
                    <asp:GridView ID="gdvOrderDetailsHistory" runat="server" AutoGenerateColumns="false" FooterStyle-CssClass="cfn_footer"
                        RowStyle-Font-Size="12px" FooterStyle-Font-Size="12px" ShowFooter="false" Width="100%"
                         CssClass="item_list" RowStyle-CssClass="borderbottom">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="14px"
                                HeaderStyle-Width="75" ItemStyle-Width="75">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" class="preview" NavigateUrl='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'
                                        runat="server">
                                    <img style="height:65px !important; width:65px !important;" alt=""
                                    border="0px" src='<%# ResolveUrl("~/uploads/style/thumb-" + Eval("SampleImageURL1")) %>'/>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="14px"
                                 ItemStyle-Width="250px">
                                <ItemStyle CssClass="cfn3" />
                                <ItemTemplate>
                                    Serial No.:-
                                    <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label><br />
                                    Contract:-
                                    <asp:Label ID="lblOptionNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label><br />
                                    <asp:Label ID="lblFabricDetails" ForeColor="#aba5a5" runat="server" Text='<%# Eval("FabricDetails") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>

                    <td  style="padding-top: 10px !important;" id="td2" runat="server" valign="top">
                    <asp:GridView ID="gdvSizeHistory" runat="server" AutoGenerateColumns="false" FooterStyle-CssClass="cfn_footer"
                        RowStyle-Font-Size="12px" FooterStyle-Font-Size="12px" ShowFooter="false" Width="100%"
                         CssClass="item_list" RowStyle-CssClass="borderbottom" RowStyle-HorizontalAlign="Center"
                        onrowdatabound="gdvSizeHistory_RowDataBound" >
                        <Columns>
                          
                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                   <asp:Label ID="lblSlotCreatedDate" runat="server" Text='<%# Eval("SlotDate") %>'></asp:Label>
                                </ItemTemplate>
                                  <HeaderTemplate>
                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty1" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty2" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty3" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty4" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty5" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty6" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty7" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty8" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty9" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty10" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty11" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty12" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty13" runat="server" ></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty14" runat="server" ></asp:Label>
                                </ItemTemplate>
                                                         
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty15" runat="server" ></asp:Label>
                                </ItemTemplate>
                                                         
                            </asp:TemplateField>
                             
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblAlt" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>                                                        
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblAltpercent" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>                                                         
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                   <asp:Label ID="lblTotalPass" runat="server" ></asp:Label>
                                </ItemTemplate>
                                                         
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                           <asp:Label ID="lblEmptyHistoryMsg" runat="server" Text="There is no history records."></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
    </tr>
    <tr>
    <td colspan="2"> &nbsp; </td>
    </tr>
    <tr>
            <td colspan="2" align="right" style="padding-right: 5px;">
               <asp:Button ID="btnClose" runat="server" CssClass="close" Width="86px" OnClientClick="javascript:window.parent.Shadowbox.close();" />
            </td>
        </tr>
    </table>    
    </form>
</body>
</html>
