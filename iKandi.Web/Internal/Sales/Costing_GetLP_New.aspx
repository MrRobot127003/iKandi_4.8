<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Costing_GetLP_New.aspx.cs"
    Inherits="iKandi.Web.Internal.Sales.Costing_GetLP_New" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style>
        #grdGetLp
        {
            margin:0px auto !important;
        }
       .AddClass_Table{
         width:100%;
        }
        .AddClass_Table td {
            border: 1px solid #dbd8d8; 
            padding: 5px 5px !important;
  
        }
            
    </style>
    

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <asp:GridView ID="grdGetLp" runat="server" AutoGenerateColumns="false" class="AddClass_Table"
            EmptyDataText="No data found." >
            <Columns>
                <asp:TemplateField HeaderText="StyleNumber">
                    <ItemTemplate>
                        <asp:Label ID="lblstylenumber" runat="server" Text='<% #Eval("StyleNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial Number">
                    <ItemTemplate>
                        <asp:Label ID="lblSerialNo" runat="server" Text='<% #Eval("SerialNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contract Number">
                    <ItemTemplate>
                        <asp:Label ID="lblContract" runat="server" Text='<% #Eval("ContractNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<% #Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BIPL Price">
                    <ItemTemplate>
                        <asp:Label ID="lblBIPLPrice" runat="server" Text='<%#  Eval("BIPLPrice") %>' style="font-weight:bold;"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ex Factory">
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <br /> 

         <span id ="header" runat="server"></span>
         <asp:GridView ID="grdGetVersionOrders" runat="server" AutoGenerateColumns="false" class="AddClass_Table"
            EmptyDataText="">
            <Columns>
                <asp:TemplateField HeaderText="StyleNumber">
                    <ItemTemplate>
                        <asp:Label ID="lblstylenumber" runat="server" Text='<% #Eval("StyleNUmber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial Number">
                    <ItemTemplate>
                        <asp:Label ID="lblSerialNo" runat="server" Text='<% #Eval("SerialNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contract Number">
                    <ItemTemplate>
                        <asp:Label ID="lblContract" runat="server" Text='<% #Eval("ContractNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<% #Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BIPL Price">
                    <ItemTemplate>
                        <asp:Label ID="lblBIPLPrice" runat="server" Text='<% #Eval("BIPLPrice") %>' style="font-weight:bold;"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ex Factory">
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory" runat="server" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <br />
        <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
            OnClientClick="javascript:self.parent.Shadowbox.close();" />
            <br />
            <br />
            <br />

            
    </div>
    </form>
</body>
</html>
