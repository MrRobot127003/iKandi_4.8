<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReport.aspx.cs" MasterPageFile="~/layout/Secure.Master"
    Inherits="iKandi.Web.PrintReport" %>

<%@ Register src="../../UserControls/Lists/Prints.ascx" tagname="Prints" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID="cph_main_content" runat="server">

    <script type="text/javascript">
	$(function() {
		$("#tabs").tabs();
	});
    </script>

    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Prints Bought</a></li>
            <li><a href="#tabs-2">Print Sold</a></li>
            <li><a href="#tabs-3">Prints bought by each Designer</a></li>
            <li><a href="#tabs-4">Prints sold by each Designer</a></li>
            <li><a href="#tabs-5">Prints bought by each Client</a></li>
        </ul>
        <div id="tabs-1">
            <div class="form_box">
                <div class="form_heading">
                    Prints Bought 
                </div>
                <div>
                    <uc1:Prints ID="Prints1" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-2">
                       <div class="form_box">
                <div class="form_heading">
                    Print Sold 
                </div>
                <div>
                 <uc1:Prints ID="Prints2" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-3">
                        <div class="form_box">
                <div class="form_heading">
                    Prints bought by Designers
                </div>
                <div>
                 <uc1:Prints ID="Prints3" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-4">
                        <div class="form_box">
                <div class="form_heading">
                    Prints sold by Designers
                </div>
                <div>
                 <uc1:Prints ID="Prints4" runat="server" />
                </div>
            </div>
        </div>
        <div id="tabs-5">
                       <div class="form_box">
                <div class="form_heading">
                    Prints bought by Clients
                </div>
                <div>
                 <uc1:Prints ID="Prints5" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
