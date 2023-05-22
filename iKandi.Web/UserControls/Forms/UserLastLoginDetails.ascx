<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLastLoginDetails.ascx.cs" Inherits="iKandi.Web.UserLastLoginDetails" %>
                <div class="portlet">
                    <div class="portlet_header">
                        Last Login
                    </div>
                    <div class="portlet_content">
                        Date: <asp:Label runat=server ID=lblDate></asp:Label><br />
                        Time: <asp:Label runat=server ID=lblTime></asp:Label>
                    </div>
                </div>