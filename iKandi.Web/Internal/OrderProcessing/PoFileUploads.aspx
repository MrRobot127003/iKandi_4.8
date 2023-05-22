<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoFileUploads.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.PoFileUploads" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
    #GrdPoUpload
    {
        text-transform:capitalize;
    }
   #GrdPoUpload input[type="file"]
    {
      margin:2px 0px;
      font-size:11px;
    }
    .AddClass_Table td
    {
        text-align:center;
     }
     .AddClass_Table
     {
         margin-bottom:8px;
     }
    </style>
</head>
<%--<script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>--%>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

<script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
  
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

<script type="text/javascript">
    $("[id*=chkHeader]").live("click", function () {
        var chkHeader = $(this);
        var grid = $(this).closest("table");
        $("input[type=checkbox]", grid).each(function () {
            if (chkHeader.is(":checked")) {
                $(this).attr("checked", "checked");
                $("td", $(this).closest("tr")).addClass("selected");
            } else {
                $(this).removeAttr("checked");
                $("td", $(this).closest("tr")).removeClass("selected");
            }
        });
    });
    $("[id*=chkRow]").live("click", function () {
        var grid = $(this).closest("table");
        var chkHeader = $("[id*=chkHeader]", grid);
        if (!$(this).is(":checked")) {
            $("td", $(this).closest("tr")).removeClass("selected");
            chkHeader.removeAttr("checked");
        } else {
            $("td", $(this).closest("tr")).addClass("selected");
            if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                chkHeader.attr("checked", "checked");
            }
        }
    });

    function CheckBoxValidation() {
        //debugger;
        var valid = false;
        var chkselectcount = 0;
        var gridview = document.getElementById('<%= GrdPoUpload.ClientID %>');
        for (var i = 0; i < gridview.getElementsByTagName("input").length; i++) {
            var node = gridview.getElementsByTagName("input")[i];
            if (node != null && node.type == "checkbox" && node.checked) {
                valid = true;
                chkselectcount = chkselectcount + 1;
            }
        }
        if (chkselectcount == 0) {
            alert("Please select atleast one checkbox");
            return false;
        }
        else { return true; }
    }

</script>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0"
            style="border: 0px; padding: 0px;">
            <tr>
                <td style="border: 0px; padding: 0px;">
                    <asp:GridView ID="GrdPoUpload" AutoGenerateColumns="false" runat="server" ShowHeader="True"
                        CssClass="AddClass_Table" CellPadding="0" ShowFooter="false" HeaderStyle-CssClass="border2">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblserial" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblquantity" Text='<%# Eval("Quantity")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="73px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract no.">
                                <ItemTemplate>
                                    <asp:Label ID="lblcontractName" Text='<%# Eval("ContractNumber")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="145px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Print Details">
                                <ItemTemplate>
                                    <asp:Label ID="lblprintDetails" Text='<%# Eval("PrintDetails")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fabric Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFabricName" Text='<%# Eval("Fabric")%>' runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnOrderDetailsID" Value='<%# Eval("OrderDetailsID")%>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="252px" />
                            </asp:TemplateField>
                            <asp:TemplateField >
                            <HeaderTemplate>
                            File1
                            <br>
                            File2
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:FileUpload ID="Uuploads1" runat="server" ToolTip="Select file 1"  />
                                    <asp:FileUpload ID="Upload2" runat="server" ToolTip="Select file 2"  />
                                    <asp:FileUpload ID="FileUpload3" runat="server" ToolTip="Select file 3"  />
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Check">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"  />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" 
                                        runat="server"  />
                                </ItemTemplate>
                                <ItemStyle Width="73px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px;">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClientClick="javascript:return CheckBoxValidation();" OnClick="btnsubmit_Click"
                        CssClass="button-sumit da_submit_button submit" />
                  <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close" Width="76px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
