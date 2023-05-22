<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="FactorySpecificLinePlanning.aspx.cs" Inherits="iKandi.Web.Admin.FactorySpecificLinePlanning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        function OpenShadowbox(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 1000, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function OpenHalfStitchShadowbox(obj) {
            //debugger;
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }

        function DeleteFrame(FrameNo) {
            //alert(FrameNo);
            var isYes = confirm("Do you want to Delete this frame!");
            if (isYes == true) {
                proxy.invoke("DeleteLinePlanFrame", { LinePlanFrameId: FrameNo }, function (result) {
                    if (result > 1 || result > -1) {

                        window.location.reload();

                    }
                }, onPageError, false, false);
            }
        }

        function SBClose() { }

          
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".Show-block").click(function () {
                // debugger; .addClass( "myClass yourClass" );
                $(this).parent(".show-hide").siblings(".table-wrap").show();
                $(this).siblings(".hide-block").show();
                $(this).parent(".show-hide").siblings(".border-top1").addClass("border-top");
                $(this).hide();
            });
            $(".hide-block").click(function () {
                // debugger;
                $(this).parent(".show-hide").siblings(".table-wrap").hide();
                $(this).siblings(".Show-block").show();
                $(this).parent(".show-hide").siblings(".border-top1").removeClass("border-top");
                $(this).hide();
            });
        });
    </script>
    <script type="text/javascript" language="javascript">
        //-------------------edit by prabhaker------------------//

        $(document).ready(function () {
            ShowImagePreview();
            HideZero();
        });
        // Configuration of the x and y offsets
        function ShowImagePreview() {
            xOffset = 350;
            yOffset = -350;
            $("a.preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.t + "' alt='Image preview' style='height:200px !important; width:200px !important;'/>&nbsp;</p>");
                $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
            },

function () {
    this.title = this.t;
    $("#preview").remove();
});

            $("a.preview").mousemove(function (e) {
                $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
            });
        };

        //-------------------end-of-code----------------------//

    </script>
    <style type="text/css">
        input[type=radio]
        {
            vertical-align: middle;
        }
        img
        {
            vertical-align: middle;
        }
        .slot
        {
            border-color: #b9b4b4;
            border-collapse: collapse;
        }
        .slot th
        {
            background-color: #F0F3F2;
            color: #405D99;
            font-size: 11px;
            text-transform: none;
            font-faimly: Lucida Sans Unicode;
            text-align: center;
            border-color: #b9b4b4;
        }
        .slot td
        {
            color: #7E7E7E;
            font-size: 11px;
            text-transform: uppercase;
            font-faimly: Lucida Sans Unicode;
            text-align: center;
            width: 80px;
        }
        
        .table-wrap
        {
            width: 521px;
            max-height: 109px;
            overflow: auto;
            z-index: 1;
            overflow-x: hidden;
        }
        .header-class
        {
            color: White;
            background-color: #405D99;
            font-size: 13px;
            font-weight: bold;
            height: 35px;
        }
        .border-top
        {
            border-top: none;
        }
        .border-top td
        {
            border-top: 0px;
        }
        .border-bottom
        {
            border-bottom-color: #F0F3F2;
            border-bottom: 1px solid #f0f3f2 !important;
        }
        
        
        #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        ::-webkit-scrollbar
        {
            width: 8px;
            height: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="text-transform: none;">
        <tr>
            <td colspan="2" align="left" style="height: 30px; background-color: #405D99; color: #FFFFFF;
                font-weight: bold; font-size: 15px;font-weight:500; padding-left: 500px; font-family: Lucida Sans Unicode;
                text-transform: none;">
                Factory Specific Line Planning
            </td>
        </tr>
        <tr>
            <td style="height: 10px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 15px; width: 130PX;">
                <asp:DropDownList ID="ddlFactory" runat="server" Style="text-transform: capitalize;"
                    AutoPostBack="true" Width="75px" Height="25px" Font-Size="15px" Font-Bold="false" OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" width="auto" class="slot" border="1">
                    <tr>
                        <th>
                            Slot 1
                        </th>
                        <th>
                            Slot 2
                        </th>
                        <th>
                            Slot 3
                        </th>
                        <th>
                            Slot 4
                        </th>
                        <th>
                            Slot 5
                        </th>
                        <th>
                            Slot 6
                        </th>
                        <th>
                            Slot 7
                        </th>
                        <th>
                            Slot 8
                        </th>
                        <th>
                            Slot 9
                        </th>
                        <th>
                            Slot 10
                        </th>
                        <th>
                            Slot 11
                        </th>
                        <th>
                            Slot 12
                        </th>
                    </tr>
                    <tr>
                        <td>
                            09:00-10:00
                        </td>
                        <td>
                            10:00-11:00
                        </td>
                        <td>
                            11:00-12:00
                        </td>
                        <td>
                            12:00-13:00
                        </td>
                        <td>
                            13:30-14:30
                        </td>
                        <td>
                            14:30-15:30
                        </td>
                        <td>
                            15:30-16:30
                        </td>
                        <td>
                            16:30-17:30
                        </td>
                        <td>
                            17:45-18:45
                        </td>
                        <td>
                            18:45-19:45
                        </td>
                        <td>
                            19:45-21:00
                        </td>
                        <td>
                            21:30-22:30
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:UpdatePanel ID="Updatepanel1" UpdateMode="Always" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvFactorySpecificLinePlanning" runat="server" AutoGenerateColumns="false"
                            ShowHeader="false" HeaderStyle-Height="35px" HeaderStyle-Font-Size="13px" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                            RowStyle-Height="35px" RowStyle-HorizontalAlign="Center" RowStyle-ForeColor="#7E7E7E"
                            OnRowCreated="gvFactorySpecificLinePlanning_RowCreated" OnDataBound="gvFactorySpecificLinePlanning_DataBound"
                            OnRowDataBound="gvFactorySpecificLinePlanning_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Factory" ItemStyle-VerticalAlign="Top" Visible="false">
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="80px" align="center">
                                            <tr>
                                                <td align="center" style="padding-top: 50px;">
                                                    <%--  <asp:HiddenField ID="hdnFactoryId" runat="server" Value='<%#Eval("UnitID") %>' />
                          <asp:Label ID="lblFactory" runat="server" Text='<%#Eval("FactoryName") %>' ForeColor="#405D99" Font-Size="14px" Font-Bold="true" Font-Names="Arial"></asp:Label>
                                                    --%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Floor" ItemStyle-VerticalAlign="Top" Visible="false">
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="80px" align="center">
                                            <tr>
                                                <td align="center" style="padding-top: 50px;">
                                                    <asp:Label ID="lblFloor" runat="server" Text='<%#Eval("FloorNo") %>' ForeColor="#405D99"
                                                        Font-Size="14px" Font-Names="Arial"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ShowHeader="false">
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="150px" align="center">
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hdnFactoryId" runat="server" Value='<%#Eval("UnitID") %>' />
                                                    &nbsp; &nbsp;
                                                    <asp:Label ID="lblFactory" runat="server" Text='<%#Eval("FactoryName") %>' ForeColor="#7e7e7e"
                                                        Font-Bold="true" Font-Names="Arial"></asp:Label>
                                                    &nbsp; &nbsp;
                                                    <asp:Label ID="lblLine" runat="server" Text='<%#Eval("LineNo") %>' ForeColor="#000000"
                                                        Font-Bold="true" Font-Names="Arial" Font-Size="13px"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%#Convert.ToBoolean(Eval("IsClosed")) == false ? "<a rel='shadowbox;width=600;height=600;' href='/Admin/StyleWiseLinePlannging.aspx?UnitId=" + Eval("UnitID") + "&UnitName=" + Eval("FactoryName") + "&FloorNo=" + Eval("FloorNo") + "&LineNo=" + Eval("[LineNo]") + "&status=add&ProductionUnit=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&Enabled=" + Convert.ToString(Request.QueryString["Enabled"]) + "' onclick='return OpenShadowbox(this);'><img src='../images/full-stitch-add-butt.png' /></a>" : "&nbsp;"%>
                                                    <%#Convert.ToBoolean(Eval("IsClosed")) == false ? "<a rel='shadowbox;width=600;height=600;' href='/Admin/AddHalfStitchLinePlanning.aspx?UnitId=" + Eval("UnitID") + "&UnitName=" + Eval("FactoryName") + "&FloorNo=" + Eval("FloorNo") + "&LineNo=" + Eval("[LineNo]") + "&ProductionUnit=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&Enabled=" + Convert.ToString(Request.QueryString["Enabled"]) + "' onclick='return OpenHalfStitchShadowbox(this);'><img src='../images/half-stiched-add-button.png' /></a>" : "&nbsp;"%>
                                                    <div id="dman" runat="server" style="float: right;">
                                                        <b>Max MP:</b>
                                                        <asp:Label ID="lblmanpower" ToolTip="Manpower" runat="server" Text='<%#Eval("ManPower") %>'
                                                            ForeColor="#7E7E7E" Font-Bold="true" Font-Names="Arial"></asp:Label></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="text-transform: none;">
                                                    <%-- <asp:GridView ID="gvDesignation" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" RowStyle-Height="25px" RowStyle-HorizontalAlign="Center"
                            RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvDesignation_RowDataBound">
                            <Columns>
                              <asp:TemplateField ItemStyle-Width="100%" ItemStyle-BorderColor="#FFFFFF">
                                <ItemTemplate>
                                  <table border="0" cellpadding="0" cellspacing="0" width="95%" align="center">
                                    <tr>
                                      <td align="left" style="width:30%; text-transform:none;">
                                        <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("UnitID") %>' />
                                        <asp:HiddenField ID="hdnFloorNo" runat="server" Value='<%#Eval("FloorNo") %>' />
                                        <asp:HiddenField ID="hdnLineNo" runat="server" Value='<%#Eval("NoOfLines") %>' />
                                        <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>' Font-Size="12px" ForeColor="#7E7E7E" Font-Names="Arial"></asp:Label>
                                      </td>
                                      <td align="right" style="width:70%;"><asp:DropDownList ID="ddlDesignation" runat="server" ForeColor="#7E7E7E" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                  </table>
                                </ItemTemplate>
                              </asp:TemplateField> 
                            </Columns>
                          </asp:GridView>--%>
                                                    <asp:GridView ID="gvDesignation" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="false" RowStyle-Height="25px" RowStyle-HorizontalAlign="Center" RowStyle-ForeColor="#7E7E7E"
                                                        OnRowDataBound="gvDesignation_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="100%" ItemStyle-BorderColor="#FFFFFF">
                                                                <ItemTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="95%" align="center">
                                                                        <tr>
                                                                            <td align="left" style="width: 30%; text-transform: none;">
                                                                                <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("UnitID") %>' />
                                                                                <asp:HiddenField ID="hdnFloorNo" runat="server" Value='<%#Eval("FloorNo") %>' />
                                                                                <asp:HiddenField ID="hdnLineNo" runat="server" Value='<%#Eval("NoOfLines") %>' />
                                                                                <asp:HiddenField ID="hdnLineDesignationId" runat="server" Value='<%#Eval("LineDesignationId") %>' />
                                                                                <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>' Font-Size="12px"
                                                                                    ForeColor="#7E7E7E" Font-Names="Arial"></asp:Label>
                                                                            </td>
                                                                            <td align="right" style="width: 70%;">
                                                                                <asp:DropDownList ID="ddlDesignation" runat="server" ForeColor="#7E7E7E" Width="90%"
                                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" Visible="false">
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="250px" align="center">
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 650px; text-align: center;">
                                            <tr>
                                                <td align="left">
                                                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left; font-size: 25px; font-family: Arial; color: Gray;
                height: 15px; padding-top: 25px; padding-left: 525px;">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 10px;">
            </td>
        </tr>
    </table>
</asp:Content>
