<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StyleCodeDetails.aspx.cs" Inherits="iKandi.Web.Admin.StyleCodeDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/technical-module.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-size:11px;
        }
    h2
    {
        color: #98a9ca !important;
    font-family: Verdana,Arial,sans-serif;
    font-size: 11px;
    padding:10px 0px;
    background-color: #39589c;
    text-transform: capitalize ;
    width:100%;    
    text-align:center;
    }
  
    .item_list th
    {
    background-color: #dddfe4 !important;
    color: #575759 !important;
    font-size: 10px !important;
    font-weight: normal;
    line-height: 15px;
    text-align: left;
    padding: 5px 0px !important;
    height: auto;
    text-transform:capitalize !important;
    }
    .item_list td
    {
        color:Blue;
    }
    .align-left
    {
        text-align:left !important;
    }
    .align-left span
    {
        text-transform:capitalize !important;
    }
    .align-center
    {
         text-align:center !important;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
    <h2>Style Code <asp:Label ID="stylecode" runat="server" ForeColor="white" Font-Bold="true"></asp:Label> Quantity date of <b style="color:white"> 2 Years </b> </h2>
    <br />

        <table cellpadding="0" cellspacing="0" border="1" style="width:400px;" class="item_list">
            <tr>
                <th width="300px">
                    Total quantity on order
                </th>
                <td>
                    <asp:Label ID="lblqtyorder" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Total quantity Shipped
                </th>
                <td>
                    <asp:Label ID="lblshipedqty" runat="server"></asp:Label>
                </td>
            </tr>
         <tr>
         <th colspan="2" style="text-align:center; font-weight:bolder; font-size:13px !important;"> Unshipped Style Code Pending Quantity Details </th>
         </tr>
        </table>        
     
            <asp:GridView ID="gvPending" AutoGenerateColumns="false" CssClass="item_list" 
                runat="server" onrowdatabound="gvPending_RowDataBound" style="min-width:400px; width:auto;">
            <Columns> 
            <%-- Column 0--%>             
                <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px">
                <HeaderTemplate>
                                   
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPendingCol" runat="server" Text='<%# Eval("PendingCol") %>'></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" CssClass="align-left" />                       
                </asp:TemplateField> 

                <%-- Column 1--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr1" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory1" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 2--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr2" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory2" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 3--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr3" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory3" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 4--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr4" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory4" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 5--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr5" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory5" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 6--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr6" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory6" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 7--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr7" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory7" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 8--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr8" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory8" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                <%-- Column 9--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr9" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory9" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                 <%-- Column 10--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr10" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory10" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                 <%-- Column 11--%>
                <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">
                <HeaderTemplate>
                    <asp:Label ID="lblExFactoryHdr11" runat="server" Text=""></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblExFactory11" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField>               

                <%-- Column 15--%>
                 <asp:TemplateField HeaderStyle-Width="100px" HeaderStyle-Font-Bold="true" HeaderText="Total" ItemStyle-Width="100px" HeaderStyle-CssClass="align-center">              
                    <ItemTemplate>
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    </ItemTemplate> 
                    <ItemStyle VerticalAlign="Top" />                       
                </asp:TemplateField> 

                </Columns>
            </asp:GridView>
           
       

    </div>
    </form>
</body>
</html>
