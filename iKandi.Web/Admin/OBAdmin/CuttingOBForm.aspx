<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="CuttingOBForm.aspx.cs" Inherits="iKandi.Web.Admin.OBAdmin.CuttingOBForm" MaintainScrollPositionOnPostback="true" %>

<%--<%@ Register Src="../../UserControls/Forms/CuttingOB.ascx" TagName="CuttingOB" TagPrefix="uc1" %>--%>
<%--<%@ Register Src="../../UserControls/Forms/FinishingOB.ascx" TagName="FinishingOB"
    TagPrefix="uc2" %>--%>
<%@ Register src="../../UserControls/Forms/Stitching.ascx" tagname="Stitching" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
<style type="text/css">
.head-back
{
    background:#39589C;
    padding:5px 0px; color:#fff; 
    font-weight:bold;
}

.head-back th
{
    font-weight:normal;
}
</style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<asp:ScriptManager ID="ScriptManager1"  runat="server">
            </asp:ScriptManager>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" style="font-weight:bold; font-size:13px;" class="form_heading">
               Operation  Admin
            </td>
        </tr>
        <tr>
    <td style="font-size:12px; font-weight:normal; color:#0088cc; line-height:30px;  text-align:center; text-transform:none;">
    (Operation to be associated with the Machine/Manual and Garment/section wise operation Specific SAM defined for stitching and Finishing)
    </td>
    
    </tr>
        <tr><td>&nbsp;</td></tr>

         <tr>
            <td align="center" style="font-weight:bold;"   class="form_heading">
           Section 
            </td>
        </tr>

     
        <tr>
            <td> &nbsp;
            </td>
        </tr>


       
        <tr>
            <td>
                <uc3:Stitching ID="Stitching1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" class="form_heading" >
               Finishing OB
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <%--<uc2:FinishingOB ID="FinishingOB1" runat="server" />--%>
            </td>
        </tr>
    </table>
</asp:Content>
