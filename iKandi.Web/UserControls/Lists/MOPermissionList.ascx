<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MOPermissionList.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.MOPermissionList" %>

<%--<style>
  SELECT
  {
      margin:2px 0px !important;
  }
   .header-text-back
     {
         font-size: 15px;
        text-align: center;
        color: #e7e4fb;
        font-family: verdana;
        font-weight: 500;
        padding: 4px 0px;
        background-color: #405D99;
        text-transform: capitalize;
      }
</style>--%>
 <link href="../../css/report.css" rel="stylesheet" type="text/css" />
 <%--<div style="width:100%;text-align:center;clear:both;">
   <h2 class="header-text-back">Permission</h2>
  </div>--%>
<table width="100%">
<tr>
<td></td>
<td></td>
</tr>
<tr>
<td align="center">
<%--<h2 class="header-text-back"> Mo Premission</h2>--%>
<asp:GridView AutoGenerateColumns="false" CssClass="AddClass_Table" ID="GridView1" runat="server"  
        Width="50%" onrowdatabound="GridView1_RowDataBound" >
                                <Columns>
                                <asp:TemplateField HeaderText="SL No">
                               <ItemTemplate>
                               <asp:Label runat="server" ID="ltIndex"  Text="-"></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnDepartmentID" Value='<%# Eval("DepartmentID") %>' />
                               </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                               <ItemTemplate>
                               <asp:Label ID="lblDepart" runat="server" Text='<%#Eval("DepartmentName") %>'></asp:Label>
                               </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation">
                               <ItemTemplate>
                               <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("DesignationName") %>'></asp:Label>
                               </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                               <ItemTemplate>
                              <%--<asp:LinkButton ID="lnkbtnEdit" runat="server" CommandArgument='<%#Eval("DepartmentID") %>'
                               CausesValidation="false" Font-Underline="True">Edit</asp:LinkButton>--%> 
                               <asp:HyperLink ID="hypEdit" runat="server" Text="Edit" NavigateUrl='<%# "~/Admin/Permission/MOPermissionForm.aspx?DesignationID=" + Eval("DesignationID") + "&DepartmentId=" + Eval("DepartmentID").ToString()%>'></asp:HyperLink>
                               <asp:HiddenField ID="hdnDesigId" runat="server" Value='<%#Eval("DesignationID")%>' />
                               </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                 </asp:GridView>
</td>
<td></td>
</tr>
</table>

