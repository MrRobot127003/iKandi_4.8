<%@ Page Title="" Language="C#" MasterPageFile="~/layout/SimpleSecure.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false"  CodeBehind="TabQC.aspx.cs" Inherits="iKandi.Web.Internal.Merchandising.TabQC" %>
<%@ Register Src="~/UserControls/Forms/QC.ascx" TagName="QC"
    TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<%--<script type="text/javascript">
    $(function () {
        $('.costing_form').show();
        $('.style-table').hide();
    });
</script>--%>
    
 <uc1:QC ID="QC" runat="server" />
</asp:Content>
