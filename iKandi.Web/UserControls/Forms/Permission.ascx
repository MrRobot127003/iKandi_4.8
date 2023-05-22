<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Permission.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.Permission" %>
<%@ Register Src="~/UserControls/Forms/PermissionUserForm.ascx" TagName="PermissionUser" TagPrefix="ucUser" %>
<%@ Register Src="~/UserControls/Forms/PermissionDesignationForm.ascx" TagName="PermissionDesignation" TagPrefix="ucDesignation" %>
<%@ Register Src="~/UserControls/Forms/PermissionDepartmentForm.ascx" TagName="PermissionDepartment" TagPrefix="ucDepartment" %>

<table cellspacing="15" width="100%">
    <tr>
        <td>
            <ucUser:PermissionUser ID="PermissionUserControl" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <ucDesignation:PermissionDesignation ID="PermissionDesignationControl" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <ucDepartment:PermissionDepartment ID="PermissionDepartmentControl" runat="server" />
        </td>
    </tr>

</table>
orm