<%@ Page Language="C#" MasterPageFile="~/layout/Public.Master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="iKandi.Web.Register" Title="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_leftbar" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="Server">
    <table>
        <tr>
            <td>
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/default.aspx">
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
                    </WizardSteps>
                </asp:CreateUserWizard>              
            </td>
        </tr>
    </table>
</asp:Content>
