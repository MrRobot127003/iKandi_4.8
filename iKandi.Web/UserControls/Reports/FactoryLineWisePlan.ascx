<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoryLineWisePlan.ascx.cs" Inherits="iKandi.Web.FactoryLineWisePlan" %>
<div class="form_heading">
            Factory Line Wise Plan 
        </div>
        <div>
            <table width="850px" cellspacing="10">
                <tr>
                    <td>
                    <nobr>
                        <asp:Label ID="lablsearch" Text="Search Text" runat="server"></asp:Label>
                        </nobr>
                    </td>
                    <td>
                        <asp:TextBox id="txtsearch" class="do-not-disable" MaxLength="40" runat=server Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        ExFactory
                    </td>
                    <td>
                        <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat=server id="txtfrom" class="date-picker do-not-disable"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat=server id="txtTo" class="date-picker do-not-disable"></asp:TextBox>
                    </td>                    
                    <td>
                         <asp:DropDownList ID="ddlUnit" runat="server" CssClass="do-not-disable">
                          <asp:ListItem Selected=True Text="Select.." Value="-1"></asp:ListItem>
                         </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat=server class="go do-not-disable" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>

<asp:HiddenField ID="hdnCount" runat="server" />
<asp:HiddenField ID="hdnRows" runat="server" />
<asp:GridView CssClass="item_list1  fixed-header" ID="GridFactoryLine" runat="server"
    AutoGenerateColumns="False" OnRowDataBound="GridFactoryLine_RowDataBound"
    AllowPaging="true" PageSize="10"  OnPageIndexChanging="GridFactoryLine_PageIndexChanging" OnRowCreated="GridFactoryLine_RowCreated">
    <Columns>

    </Columns>
</asp:GridView>
