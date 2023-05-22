<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HolidayForm.ascx.cs" Inherits="iKandi.Web.HolidayForm" %>

<asp:Panel ID="pnlForm" runat="server">
   <div class="form_box">
        <div class="form_heading">
            Holiday Form <span class="form_small_text">(* Please fill all required fields)</span>
        </div>
        <div>
            <table cellspacing="15" width="100%">
                <tr>
                    <td>
                        Day:
                    </td>
                    <td colspan="2">
                    <asp:TextBox ID="tbDay" runat="server" MaxLength ="30"></asp:TextBox>
                    </td>                   
                </tr>
                <tr>
                    <td width="20%">
                        Month:
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="tbMonth" CssClass="" runat="server" MaxLength="30"></asp:TextBox>
                        <div class="form_error">
                            
                        </div>
                    </td>
                  
                </tr>
                <tr>
                    <td width="20%">
                        Year:
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="tbYear" CssClass="" runat="server" MaxLength="45"></asp:TextBox>
                        <div class="form_error">
                           
                        </div>
                    </td>
                  </tr>
                <tr>
                    <td>
                        Title:
                    </td>
                    <td width="30%">
                     <asp:TextBox ID="tbTitle" CssClass="" runat="server" MaxLength="45"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:
                    </td>
                    <td width="30%" >
                        <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Height="100px" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Company_Id:
                    </td>
                    <td width="30%">
                        <asp:DropDownList ID="ddlCompany_Id" runat="server">
                        <%--<asp:ListItem Text="select all" Value =-1></asp:ListItem>--%>
                        <asp:ListItem Text="BIPL" Value=2></asp:ListItem>
                        <asp:ListItem Text="iKandi" Value =1></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" OnClick="Submit_Click" />
    </div>
</asp:Panel>
