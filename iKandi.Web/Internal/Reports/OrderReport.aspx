<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderReport.aspx.cs" Inherits="iKandi.Web.OrderReport"
    MasterPageFile="~/layout/Secure.Master" %>

<%@ Register Src="../../UserControls/Lists/Prints.ascx" TagName="Prints" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="cph_main_content" runat="server">

    <script type="text/javascript">
    
	$(function() {
		$("#tabs").tabs();
	});
	
    </script>

    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Basic Info</a></li>
            <li><a href="#tabs-2">Fabric</a></li>
            <li><a href="#tabs-3">Accesories</a></li>
            <li><a href="#tabs-4">Cutting</a></li>
            <li><a href="#tabs-5">Stitching</a></li>
        </ul>
        <div id="tabs-1">
            <div class="form_box">
                <div class="form_heading">
                    Basic Info
                </div>
                <div>
                    <uc1:Prints ID="Prints1" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-2">
            <div class="form_box">
                <div class="form_heading">
                    Fabric
                </div>
                <div>
                    <uc1:Prints ID="Prints2" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-3">
            <div class="form_box">
                <div class="form_heading">
                    Accesories
                </div>
                <div>
                    <uc1:Prints ID="Prints3" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-4">
            <div class="form_box">
                <div class="form_heading">
                    Cutting
                </div>
                <div>
                    <uc1:Prints ID="Prints4" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-5">
            <div class="form_box">
                <div class="form_heading">
                    Stitching
                </div>
                <div>
                    <uc1:Prints ID="Prints5" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
