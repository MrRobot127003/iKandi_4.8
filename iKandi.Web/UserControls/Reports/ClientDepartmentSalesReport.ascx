<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientDepartmentSalesReport.ascx.cs"
    Inherits="iKandi.Web.ClientDepartmentSalesReport" %>
<div class="form_box">
    <div class="form_heading">
        Department Wise Qty and Revenue Breakdown
    </div>
    <div>
        <table width="1200px" cellspacing="5">
            <tr>
                <td>
                    Buying House :
                </td>
                <td>
                    <asp:DropDownList Width="125px" ID="ddlBH" runat="server"  AutoPostBack="true"
                        CssClass="do-not-disable" onselectedindexchanged="ddlBH_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                   Select Client :
                </td>
                <td>
                    <asp:DropDownList Width="125px" ID="ddlClients" runat="server" CssClass="do-not-disable">
                    </asp:DropDownList>
                </td>
                <td>
                    Select Year :
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="125px" CssClass="do-not-disable">
                    </asp:DropDownList>
                </td>
                <td>
                    Order Date : &nbsp;
                    <asp:RadioButton ID="rdOrderDate" GroupName="SelectDateDR" runat="server" 
                        CssClass=" do-not-disable" />
                </td>
                <td>
                    Ex-Factory : &nbsp;
                    <asp:RadioButton ID="rdExFactryDate" GroupName="SelectDateDR" runat="server" CssClass="do-not-disable" />
                </td>
                <td>
                    DC Date : &nbsp;
                    <asp:RadioButton ID="rdDCDate" GroupName="SelectDateDR" runat="server" CssClass=" do-not-disable" />
                </td>
                <td>
                    <asp:Button ID="btnGo" runat="server" class="go do-not-disable" OnClick="btnGo_click" />
                </td>
            </tr>
        </table>
    </div>
</div>
<table width="300px" class='<%= (hdnEstimateFactor.Value == "1" )? "hide_me " : "item_list1" %>'>
            <tr > 
             <th>
                    Estimate Factor:
                </th>
                <td >
                    <asp:Label ID="lblEstimateFactor" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnEstimateFactor" runat="server" Value="" />
                </td>
            </tr>
        </table>
<div class="form_box">
    <asp:GridView CssClass=" fixed-header item_list" ID="GridView1" runat="server" AutoGenerateColumns="True"
        OnRowCreated="GridView1_OnRowCreated" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <label>No records Found</label></EmptyDataTemplate>
    </asp:GridView>
</div>
<%-- <table width="300px" cellspacing="" class='<%= (hdnEstimateFactor.Value == "1" )? "hide_me" : "" %>'>
            <tr > 
             <td >
                    Estimate Factor:
                </td>
                <td >
                    <asp:Label ID="lblEstimateFactor" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnEstimateFactor" runat="server" Value="-1" />
                </td>
            </tr>
        </table>--%>