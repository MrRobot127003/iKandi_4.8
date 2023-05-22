<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFactorySpecificLinePlanning.aspx.cs"
    Inherits="iKandi.Web.Admin.AddFactorySpecificLinePlanning" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../App_Themes/ikandi/ikandi1.css" />
    <link rel="stylesheet" type="text/css" href="../../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../css/datepicker.css" />
    <script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
    <script src="../../js/jquery.datePicker.js" type="text/javascript"></script>
    <script src="../../js/WeekDate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#gvNextChangeOverStyleDetail tr').each(function () {
                var r = $(this);
                var txtdate = r.find("input[type=text][id*=txtStartDate]");
                if (txtdate.disabled == true) {
                    $("#gvNextChangeOverStyleDetail").find("input[type=text][id*=txtStartDate]").removeClass("date-pick");
                }
            });
            $('.date-pick').datePicker();
        });
    </script>
    <script type="text/javascript">
        function disableautocompletion(id) {
            var txt = document.getElementById(id);
            txt.setAttribute("autocomplete", "off");
        }

        var ddlText, ddlValue, ddl, lblMesg;
        function CacheItems() {
            ddlText = new Array();
            ddlValue = new Array();
            ddl = document.getElementById("ddlStyleCode");

            for (var i = 0; i < ddl.options.length; i++) {
                ddlText[ddlText.length] = ddl.options[i].text;
                ddlValue[ddlValue.length] = ddl.options[i].value;
            }
        }
        window.onload = CacheItems;

        function FilterItems(value) {
            if (document.getElementById("ddlStyleCode").options[document.getElementById("ddlStyleCode").selectedIndex].text != "-- Select --") {
                //                document.getElementById("lblSam").style.visibility = "hidden";
                //                document.getElementById("lblSamLabel").style.visibility = "hidden";
                //                document.getElementById("lblOB").style.visibility = "hidden";
                //                document.getElementById("lblOBLabel").style.visibility = "hidden";
                document.getElementById("btnSubmit").style.visibility = "hidden";
                document.getElementById("gvNextChangeOverStyleDetail").style.visibility = "hidden";
                document.getElementById("tdMessage").style.visibility = "hidden";
                document.getElementById("trSlot").style.visibility = "hidden";
                document.getElementById("trSubmit").style.visibility = "hidden";
                document.getElementById("lblSlot").style.visibility = "hidden";
            }
            ddl.options.length = 0;
            AddItem("-- Select --", "0");
            for (var i = 0; i < ddlText.length; i++) {

                if (ddlText[i].toLowerCase().indexOf(value) != -1) {
                    if (ddlText[i] != "-- Select --") {

                        AddItem(ddlText[i], ddlValue[i]);
                    }
                }
            }
            if (ddl.options.length == 1) {
                AddItem("No Styles found.", "");
            }
        }

        function AddItem(text, value) {
            var opt = document.createElement("option");
            opt.text = text;
            opt.value = value;
            ddl.options.add(opt);
        }

        function SpinnShow() {
            $("#spinn").css("display", "block");
        }

        function SpinnHide() {
            $("#spinn").fadeOut("slow");
        }
    </script>
    <style type="text/css">
        /* located in demo.css and creates a little calendar icon
     * instead of a text link for "Choose date"
     */
        a.dp-choose-date
        {
            float: left;
            width: 16px;
            height: 16px;
            padding: 0;
            margin: 1px 3px 0;
            display: block;
            text-indent: -2000px;
            overflow: hidden;
            background: url(../../images/calendar_icons.png) no-repeat;
        }
        a.dp-choose-date.dp-disabled
        {
            background-position: 0 -20px;
            cursor: default;
        }
        /* makes the input field shorter once the date picker code
     * has run (to allow space for the calendar icon
     */
        input.dp-applied
        {
            width: 140px;
            float: left;
        }
        .txt
        {
            width: 20px;
            text-align: center;
            color: #7E7E7E;
        }
        #spinn
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
    </style>
</head>
<body bgcolor="#FFFFFF">
    <form id="form1" runat="server">
    <div id="spinn" runat="server">
    </div>
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td style="padding-top: 5px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: #405D99; color: #FFFFFF; font-size: 12px;
                                font-weight: bold; text-align: center; font-family:Verdana">
                                Next Change Over Style Detail
                            </td>
                            <td align="right" style="text-align: right; height: 34px; background-color: #405D99;
                                color: #FFFFFF; font-size: 14px; font-weight: bold; text-transform: uppercase;
                                font-family:Verdana;">
                                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                            </td>
                        </tr>
                        <tr>
                           <td align="left" style="padding-top: 5px; padding-left: 10px; padding-bottom: 5px; width: 40%; color: #405D99;
                                font-size: 12px; font-weight: bold; font-family:Verdana;">
                                <asp:Label ID="lblStyleNoLabel" runat="server" Text="Style Code."></asp:Label>&nbsp;&nbsp;
                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="2" onkeyup="FilterItems(this.value)"
                                    onfocus="disableautocompletion(this.id)" CssClass="txt"></asp:TextBox>
                                <asp:DropDownList ID="ddlStyleCode" runat="server" Width="150px" Font-Bold="false"
                                    ForeColor="#7E7E7E" AutoPostBack="true" OnSelectedIndexChanged="ddlStyleCode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="padding-top: 5px; padding-bottom: 5px; color: #405D99; font-size: 11px;
                                 font-family:Verdana;">
                                <span style="font-weight: bold;">Factory&nbsp;&nbsp;</span><asp:Label ID="lblFactory"
                                    runat="server" ForeColor="#7E7E7E"></asp:Label>                                   
                            </td>                    
                            <td align="right" style="padding-top: 5px; padding-bottom: 5px; padding-right: 10px;
                                color: #405D99; font-size: 11px;  font-family:Verdana;">
                                <span style="font-weight: bold;">Line&nbsp;&nbsp;</span><asp:Label ID="lblLineNo"
                                    runat="server" ForeColor="#7E7E7E"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display:none;">
                           <td align="left" style="padding-top: 5px; padding-bottom: 5px; width: 30%; color: #405D99;
                                font-size: 12px; font-weight: bold; font-family:Verdana;">
                             
                            </td>
                            <td align="left" style="padding-top: 5px; padding-bottom: 5px; width: 35%; color: #405D99;
                                padding-left: 30px; font-weight: bold; font-size: 11px; font-family:Verdana;">
                                <asp:Label ID="lblSamLabel" runat="server" Text="Stitch Sam" Visible="false"></asp:Label>&nbsp;&nbsp;<asp:Label
                                    ID="lblSam" runat="server" ForeColor="#7E7E7E" Font-Bold="false" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblFinishSamLabel" runat="server" Text="Finish Sam" Visible="false"></asp:Label>&nbsp;&nbsp;<asp:Label
                                    ID="lblFinishSam" runat="server" ForeColor="#7E7E7E" Font-Bold="false" Visible="false"></asp:Label>
                            </td>
                            <td align="right" style="padding-top: 5px; padding-bottom: 5px; padding-right: 10px;
                                width: 35%; color: #405D99; padding-left: 10px; font-weight: bold; font-size: 11px;
                                font-family:Verdana;">
                                <asp:Label ID="lblOBLabel" runat="server" Text="Stitch OB W/S" Visible="false"></asp:Label>&nbsp;&nbsp;<asp:Label
                                    ID="lblOB" runat="server" ForeColor="#7E7E7E" Font-Bold="false" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblFinishOBLabel" runat="server" Text="Finish OB W/S" Visible="false"></asp:Label>&nbsp;&nbsp;<asp:Label
                                    ID="lblFinishOB" runat="server" ForeColor="#7E7E7E" Font-Bold="false" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" style="padding-top: 5px; text-transform: none; font-family:Verdana;">
                                <asp:GridView ID="gvNextChangeOverStyleDetail" runat="server" AutoGenerateColumns="false"
                                    Width="98%" ShowHeader="true" HeaderStyle-Height="35px" 
                                    HeaderStyle-Font-Size="10px" HeaderStyle-Font-Names="Verdana"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#405D99"
                                    HeaderStyle-BackColor="#F0F3F2" RowStyle-Height="35px" RowStyle-HorizontalAlign="Center"
                                    RowStyle-ForeColor="#7E7E7E" FooterStyle-ForeColor="#7E7E7E" ShowFooter="true"
                                    Visible="false" FooterStyle-HorizontalAlign="Center" OnRowDataBound="gvNextChangeOverStyleDetail_RowDataBound"
                                    OnRowCreated="gvNextChangeOverStyleDetail_RowCreated" 
                                    onrowcommand="gvNextChangeOverStyleDetail_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                        Style No.
                                        </HeaderTemplate>
                                        <HeaderStyle Width="115px" />
                                        <ItemTemplate>
                                        <asp:DropDownList ID="ddlStyleNo" runat="server" Width="110px" ForeColor="#7E7E7E"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlStyleNo_SelectedIndexChanged" style="text-transform:capitalize;"
                                                    >
                                                </asp:DropDownList>
                                        </ItemTemplate>                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Serial No." HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlSerialNo" runat="server" Width="75px" ForeColor="#7E7E7E"
                                                    AutoPostBack="true" style="text-transform:capitalize;" OnSelectedIndexChanged="ddlSerialNo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnfldCheckStartDate" runat="server" Value='<%# Eval("CheckStartDate") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contract No." HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlContract" runat="server" Width="75px" ForeColor="#7E7E7E"
                                                    AutoPostBack="true" style="text-transform:capitalize;" OnSelectedIndexChanged="ddlContract_SelectedIndexChanged"
                                                    Enabled="false">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Ex Fact Date" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExFactoryDate" runat="server" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField  HeaderText="Start Date" HeaderStyle-Width="105px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIsStitching" Value='<%# Eval("IsStitching") %>' runat="server" />
                                                <asp:TextBox ID="txtStartDate" runat="server" Width="75px" ForeColor="#7E7E7E" Font-Size="11px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                           

                                        <asp:TemplateField HeaderText="Slot" HeaderStyle-Width="105px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlSlot" runat="server" Width="100px" Font-Bold="false" ForeColor="#7E7E7E"
                                                    Enabled="false" style="text-transform:capitalize;">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>   
                                        
                                        <asp:TemplateField  HeaderText="End Date" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndDate" runat="server" ForeColor="#7E7E7E" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                  
                                    
                                        <asp:TemplateField HeaderText="Contract Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContractQty" runat="server" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalContractQty" runat="server" Font-Size="11px" Font-Bold="true"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Unit Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitQty" runat="server" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalUnitQty" runat="server" Font-Size="11px" Font-Bold="true"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Line Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLineQty" runat="server" Font-Size="11px" Width="45px" MaxLength="5"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField>
                                         <HeaderTemplate>
                                         Stch SAM <br />
                                         OB W/S
                                         </HeaderTemplate>
                                         <HeaderStyle Width="60px" />
                                            <ItemTemplate>
                                                <asp:label ID="lblStitchSam" runat="server" Font-Size="11px" Width="45px" MaxLength="5"></asp:label>
                                                <br />
                                                <asp:label ID="lblstOB" runat="server" Font-Size="11px" Width="45px" MaxLength="5"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField>
                                         <HeaderTemplate>
                                         Fin SAM <br />
                                         OB W/S
                                         </HeaderTemplate>
                                         <HeaderStyle Width="60px" />
                                            <ItemTemplate>
                                                <asp:label ID="lblFinishSam" runat="server" Font-Size="11px" Width="45px" MaxLength="5"></asp:label>
                                                <br />
                                                <asp:label ID="lblFinOB" runat="server" Font-Size="11px" Width="45px" MaxLength="5"></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                         <HeaderTemplate>
                                        	Dbl Ob stch <br />
                                         Dbl Ob Fnsh 
                                         </HeaderTemplate>
                                         <HeaderStyle Width="85px" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDblOBStitch" runat="server" />
                                                <br />
                                                <asp:CheckBox ID="chkDblOBFinish" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="Delete" ImageUrl="../images/del-butt.png" runat="server" />
                                        </ItemTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="../images/add-butt.png" OnClick="btnAdd_Click" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:CommandField ShowDeleteButton="True" ButtonType="Image" ItemStyle-HorizontalAlign="Center"
                                            DeleteImageUrl="../images/del-butt.png" />--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                       
                        <tr>
                            <td style="height: 5px;">
                            </td>
                        </tr>
                        <tr id="trSubmit" runat="server" visible="false">
                            <td colspan="3" align="right">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit" Visible="false"
                                    ValidationGroup="Group1" OnClientClick="SpinnShow();" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td id="tdMessage" runat="server" colspan="3" align="right" visible="false" style="height: 20px;
                                font-family:Verdana;">
                                <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        $(window).load(function () { $("#spinn").fadeOut("slow"); }); //Gajendra     
    </script>
</body>
</html>
