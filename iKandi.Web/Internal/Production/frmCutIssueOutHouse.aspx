<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCutIssueOutHouse.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.frmCutIssueOutHouse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/service.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <link href="../../CommonJquery/ToolTip_plugin/css/tooltipster.bundle.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../../CommonJquery/ToolTip_plugin/js/tooltipster.bundle.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".th").datepicker({ dateFormat: 'dd-mm-yy' });
        });
        function pageLoad() {
            $(".th").datepicker({ dateFormat: 'dd-mm-yy' });

        }


       
    </script>
    <style type="text/css">
    .center-table table
    {
        margin:0px auto;
    }
    input type["text"] {text-transform:capitalize; width:100%}
    td {text-transform:capitalize}
    </style>
</head>


<body>
    <form id="form1" runat="server" class="center-table">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <table border="0" class="item_list2" cellpadding="0" cellspacing="0" style="width: 90%"
                    align="center">
                    <tr>
                        <td style="padding: 2px 0px; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                            font-size: 12px; text-transform: none;">
                            Cut Issue Entry&nbsp;&nbsp;
                        <asp:Label ID="lblFactoryName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <table border="0" class="item_list2" cellpadding="0" cellspacing="0" style="width: 90%"
                    align="center">
                    <tr>
                        <th style="width: 33%">
                           Date 
                        </th>
                        <th style="width: 33%">
                           Cut Issue Qty 
                        </th>
                        <th style="width: 33%">
                            Challan No.
                        </th>
                    </tr>
                    <tr>
                        <td>
                        <asp:TextBox ID="txtdate" onkeypress="return false;" runat="server" Style="height: 15px; text-align: center"
                                Font-Bold="true" class="th black"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hdnDateCHange" Value="0" />
                        </td>
                        <td style="width: 15%">
                        <asp:TextBox ID="txtCutIssueQty" Text="" Style="text-align: center;"
                                class="gray" onkeypress='return event.charCode >= 48 && event.charCode <= 57' MaxLength="5" runat="server"
                                Width="90%"></asp:TextBox>
                            
                        </td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtChallNo"  Text="" class="gray" Style="text-align: center"
                                MaxLength="10" runat="server" Width="90%"></asp:TextBox>
                        </td>
                    </tr>


                      
                   

                </table>
                <br />
                
                            <asp:GridView ID="grdFabricInhouse" runat="server" AutoGenerateColumns="false"
                                RowStyle-HorizontalAlign="Center" 
                                Width="90%" RowStyle-ForeColor="#7E7E7E" CssClass="item_list2">
                                <Columns>
                                 <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                 <HeaderTemplate> Date</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" style="text-transform:capitalize" CssClass="gray" Text='<%#Eval("CutIssueDate") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate>  Cut Issue Qty.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" CssClass="gray" Text='<%#Eval("CutIssue") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate> Challan No.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblchallno" CssClass="gray" Text='<%#Eval("ChalanNo") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                    <HeaderTemplate> OutHouse Unit</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblchallno" CssClass="gray" Text='<%#Eval("FactoryName") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="25%" />
                                    </asp:TemplateField>
                                   
                                </Columns>
                            </asp:GridView>
                        
                <br />
                <div style="margin: 10px auto; text-align: center">
                    <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
                        Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
                        Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                </div>
              
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
