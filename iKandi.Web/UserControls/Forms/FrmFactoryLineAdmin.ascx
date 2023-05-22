<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FrmFactoryLineAdmin.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.FrmFactoryLineAdmin" %>
<style type="text/css">
    .style1
    {
        width: 12%;
    }
    
    .style2
    {
        width: 21%;
    }
    
    .style3
    {
        width: 22%;
    }
    
    .font
    {
        font-size: 13px;
    }
    
    .border td
    {
        border: 1px solid #000000;
        border-collapse: collapse;
    }
    
    .border2 th
    {
        background-image: url(../../images/cs_bg.jpg);
        background-repeat: repeat-x;
        padding: 10px;
        color: White;
        text-transform: capitalize;
    }
    
    .submit
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px 0px;
        border: none;
    }
    
    .submit:hover
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px -28px;
    }
    
    .watermark
    {
        color: Gray;
    }
    
    
    
    .header-top-sec
    {
        font-size: 20px;
        text-align: center;
        color: White;
        font-family: verdana;
        font-weight: bold;
        padding: 2px 0px;
        background-color: #405D99;
        text-transform: capitalize;
    }
    
    th
    {
        background-color: #405D99;
        padding: 5px 0px;
        color: #fff;
        text-transform: uppercase !important;
    }
    
    select
    {
        text-transform: uppercase;
    }
    
    img
    {
        border: none;
    }
    
    .border td
    {
        border: none;
    }
    
    .main_tbl_wrapper
    {
        background: #fff;
    }
    
    .inputvalue_textbox
    {
        width: 90% !important;
        text-align: left !important;
        text-transform: capitalize !important;
        font-size: 12px !important;
        font-family: Verdana;
        padding: 2px 0px;
    }
    
    .input-value
    {
        width: 90%;
        text-align: left !important;
        text-transform: capitalize !important;
        font-size: 12px !important;
        font-family: Verdana;
        padding: 2px 0px;
    }
    
    td label
    {
        text-transform: capitalize !important;
        font-size: 12px;
        font-family: Verdana;
    }
    
    .hour-sele select
    {
        width: 90% !important;
        font-size: 12px;
        text-transform: uppercase;
        vertical-align: top;
    }
    
    #rdo_in_active
    {
        width: 20px;
    }
    
    input[type="radio"]
    {
        font-size: 12px !important;
        font-family: Verdana;
    }
    
    .error
    {
        border: 2px solid red;
    }
</style>
<script type="text/javascript">
    var globalelem = "";
    function UpdateLineLineDesignation(elem) {

        globalelem = elem;
        var Ids = elem.id;
        var cId = Ids.split("_")[6].substr(3);
        var CtnNeme = Ids.split("_")[7];
        var ErroSetBackcnt = Ids.split("_")[8];
        var userId = '<%=this.UserId%>';
        var DesignationID = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlDesignationItem" + "']").val();
        var factoryId = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlFactoryItem" + "']").val();
        //var IsAct = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_rbtnIsActiveItem" + "']");
        var Isact = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_rdo_active" + "']");
        var IsinAct = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_rdo_inactive" + "']");
        var Name = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").val();
        var Isfinshing = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_rbtnIsfinshing" + "']");
        var Chk_stiching = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_chk_stitching" + "']");
        var Chk_finishing = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_Chk_Finishing" + "']");
        var Chk_cutting = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_Chk_cutting" + "']");
        var ddlproductionUnit = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlFactoryItem" + "']");
        var Chk_stiching_value;
        var Chk_finsing_value;
        var Chk_cutting_value;

        if (Chk_stiching.is(':checked')) {
            Chk_stiching_value = 1;
        }
        else {
            Chk_stiching_value = 0;
        }

        if (Chk_finishing.is(':checked')) {

            Chk_finsing_value = 1;
        }

        else {

            Chk_finsing_value = 0;
        }

        if (Chk_cutting.is(':checked')) {

            Chk_cutting_value = 1;
        }

        else {

            Chk_cutting_value = 0;
        }

        var IsActive;

        if (Isact.is(':checked')) {

            IsActive = 1;
        }

        if (IsinAct.is(':checked')) {

            IsActive = 0;
        }
        if (CtnNeme != "ddlDesignationItem") {
            if (Name.length == 0) {
                ShowHideMessageBox(true, 'Please enter name', 'Form Line Designation');
                return false;
            }
        }

        if (CtnNeme == "txtNameItem") {

            if (/[a-zA-Z]/.test(Name) == false) {
                alert("Entered name not valid.!");
                $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").css("border-color", "red");
                $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").focus();
                return false;
            }
            else {
                var res = Name.charAt(0);
                if (/[@,.}{"@?;123456789"]/.test(res) == true) {
                    $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").css("border-color", "red");
                    $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").focus();
                    alert("Name should be start with letter.!");
                    return false;
                }
            }
        }

        $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").css("border-color", "");
        var id = parseInt($("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_hdnID" + "']").val());

        if (Chk_stiching_value == 0 && Chk_finsing_value == 0 && Chk_cutting_value == 0) {

            alert("Value not save .! & at least one department association check box should be check.");
            location.reload(); 
            return false;
        }
        if (CtnNeme == "ddlFactoryItem" || CtnNeme == "Chk" || CtnNeme == "chk") {
            if (IsinAct.is(':checked')) {
                alert("please select Active for update record");
                location.reload(); 
                return false;
            }
        }
        if (CtnNeme == "ddlFactoryItem") {
            proxy.invoke("updateSlot", { DesignationID: DesignationID, factoryId: factoryId, IsAct: IsActive, UserId: userId, Names: Name, id: id, stiching: 1, finishing: 0, cutting: 0 }, function (result) {

                DisplayErrorMsg(result, elem);

            }, onPageError, false, false);

        }
        else {
            proxy.invoke("updateSlot", { DesignationID: DesignationID, factoryId: factoryId, IsAct: IsActive, UserId: userId, Names: Name, id: id, stiching: Chk_stiching_value, finishing: Chk_finsing_value, cutting: Chk_cutting_value }, function (result) {

                DisplayErrorMsg(result, elem);

            }, onPageError, false, false);
        }
    }

    var IsShiftDown = false;

    function BlockingHtml(Sender, e) {

        var key = e.which ? e.which : e.keyCode;

        if (key == 16) {

            IsShiftDown = true;

            //CharCounter(Sender, 10);

        }

        else if ((IsShiftDown == true) && ((key == 188) || (key == 190))) {

            return false;

        }

    }



    function onlyAlphabets(e, t) {

        //        try {

        //            if (window.event) {

        //                var charCode = window.event.keyCode;

        //            }

        //            else if (e) {

        //                var charCode = e.which;

        //            }

        //            else { return true; }

        //            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))

        //                return true;

        //            else

        //                ShowHideMessageBox(true, 'Allowing only alphabets', 'Form Loss Distribution');

        //            return false;

        //        }

        //        catch (err) {

        //            alert(err.Description);

        //        }

    }

    function DisplayErrorMsg(Result, elem) {

        // alert(Result);

        var defValue = elem.defaultValue;

        var Ids = elem.id;

        var cId = Ids.split("_")[6].substr(3);

        var CtnNeme = Ids.split("_")[7];





        if (Result == 2) {



            //ShowHideMessageBox(true, 'Record already exists.! Ex.(Line Designation & Name & Factory filed should be unique) ', 'Form Line Designation');

            alert('Record already exists.! Ex.(Line Designation & Name & Factory filed should be unique');

            //                        if (CtnNeme == 'ddlDesignationItem') {

            //                            $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlDesignationItem" + "']").val(defValue);



            //                        }

            window.location.href = "FrmFactoryLineAdmin.aspx";

            //            if (CtnNeme == 'txtNameItem') {

            //              

            //                $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").val(defValue);

            //            }

            //            if (CtnNeme == 'ddlFactoryItem') {

            //                $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlFactoryItem" + "']").val(defValue);



            //            }

            return false;

        }

        else {

            if (CtnNeme == 'ddlDesignationItem') {

                //$("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").val("");

            }

            else {

                alert('Record updated');
            }
        }


        location.reload(true);
    }

    function CallbtnserverSide() {



        $("#<%=btnsearch.ClientID %>")[0].click();

    }





    function myFunc() {


        var elem = globalelem;
        var userId = '<%=this.UserId%>';

        var defValue = elem.defaultValue;
        var Ids = elem.id;
        var cId = Ids.split("_")[6].substr(3);
        var CtnNeme = Ids.split("_")[7];


        var finshing = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_hdnFinshingCheck" + "']").val();
        var cutting = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_hdnCuttingCheck" + "']").val();



        var Chk_finishing = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_Chk_Finishing" + "']");
        var Chk_cutting = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_Chk_cutting" + "']");


        if (cutting == 1) {

            $(Chk_cutting).attr('disabled', true);


        }

        else {

            $(Chk_cutting).attr('disabled', false);
        }

        if (finshing == 1) {

            $(Chk_finishing).attr('disabled', true);

        }

        else {

            $(Chk_finishing).attr('disabled', false);
        }

    }

 

</script>
<table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" style="table-layout: fixed;">
    <tr>
        <td>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                <tr>
                    <td class="header-Line Designation Admin">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px;">
                            <tr class="td-sub_headings border">
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td style="padding-top: 5px; width: 200px;">
                                                        <asp:TextBox ID="txtserach" ToolTip="Search Filed" ForeColor="Gray" runat="server"
                                                            Height="26px" Width="200px" placeholder="search keyword ( Line Designation , Name)..."></asp:TextBox>
                                                    </td>
                                                    <td align="left" style="padding-top: 5px;">
                                                        <asp:ImageButton OnClick="btnsearch_Click" runat="server" ID="btnsearch" ToolTip="search criteria"
                                                            ImageUrl="../../App_Themes/ikandi/images/view_icon.png" Style="border: 1px solid #ccc;
                                                            border-left: 0px; padding: 6px;" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" style="padding-right: 300px;">
                                                        <input type="radio" runat="server" id="rdo_ALL" value="-1" onchange="CallbtnserverSide()" />ALL
                                                        <input type="radio" runat="server" id="rdo_Active" value="1" onchange="CallbtnserverSide()" />Active
                                                        <input type="radio" runat="server" id="rdo_in_active" value="0" onchange="CallbtnserverSide()" />In
                                                        Active
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="padding-bottom: 10px;">
                                                <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;">
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <!--table2-->
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td align="left">
                                                <asp:UpdatePanel ID="InsertEmployeeUpdatePanel" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdslot" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            ShowFooter="true" HeaderStyle-Height="30px" HeaderStyle-HorizontalAlign="Center"
                                                            OnRowDataBound="grdslot_RowDataBound" OnRowCommand="grdslot_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderText="Line Designation"
                                                                    ItemStyle-CssClass=" hour-sele" FooterStyle-CssClass="hour-sele">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ID="ddlDesignationItem" AutoPostBack="true" runat="server" onchange="UpdateLineLineDesignation(this)">
                                                                            </asp:DropDownList>
                                                                            <asp:HiddenField runat="server" ID="hdnID" Value='<%#Eval("ID") %>' />
                                                                            <asp:HiddenField runat="server" ID="hdnDesignationItem" Value='<%#Eval("LineDesignationID") %>' />
                                                                            <asp:HiddenField runat="server" ID="hdn_cutting_act" Value='<%#Eval("Cutting_Active") %>' />
                                                                            <asp:HiddenField runat="server" ID="hdn_finishing_act" Value='<%#Eval("Finishing_Active") %>' />
                                                                            <asp:HiddenField runat="server" ID="hdnCuttingCheck" />
                                                                            <asp:HiddenField runat="server" ID="hdnFinshingCheck" />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ID="ddlDesignationFooter" runat="server">
                                                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">LineMan</asp:ListItem>
                                                                                <asp:ListItem Value="2">Assistant LineMan</asp:ListItem>
                                                                                <asp:ListItem Value="3">Floor Incharge</asp:ListItem>
                                                                                <asp:ListItem Value="4">Floor QA</asp:ListItem>
                                                                                <asp:ListItem Value="5">Floor QC</asp:ListItem>
                                                                                <asp:ListItem Value="6">IEWriter</asp:ListItem>
                                                                                <asp:ListItem Value="7">IEFactory</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:TextBox ID="txtNameItem" MaxLength="50" onkeypress="return onlyAlphabets(event,this);"
                                                                                Style="text-align: center;" CssClass="inputvalue_textbox" onKeyDown="return BlockingHtml(this,event);"
                                                                                onchange="UpdateLineLineDesignation(this)" Text='<%#Eval("LineDesignationName") %>'
                                                                                Width="80px" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:TextBox ID="txtNameFooter" MaxLength="50" onkeypress="return onlyAlphabets(event,this);"
                                                                                CssClass="input-value" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="Is Active" HeaderStyle-Width="20%"
                                                                    ItemStyle-Width="20%">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center; text-transform: capitalize;">
                                                                            <input type="radio" runat="server" id="rdo_active" value="1" onchange="UpdateLineLineDesignation(this)" />Active
                                                                            <input type="radio" runat="server" id="rdo_inactive" value="0" onchange="UpdateLineLineDesignation(this)" />InActive
                                                                            <%-- <asp:RadioButton ID="rbtnActive" Text="Active" runat="server" CssClass="Active" onclick="IsActive(this)" />

                                      <asp:RadioButton ID="rbtnInActive" Text="InActive"  runat="server" CssClass="InActive" onclick="IsInActive(this)" />--%>
                                                                            <asp:HiddenField runat="server" ID="hdnIsActive" Value='<%#Eval("IsActive") %>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center; width: 150px; margin: 0px auto; text-transform: capitalize;">
                                                                            <asp:RadioButtonList ID="rbtnIsActiveFooter" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-CssClass="border hour-sele" FooterStyle-CssClass="hour-sele"
                                                                    HeaderStyle-Width="14%" ItemStyle-Width="14%" HeaderText="Production Unit">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ID="ddlFactoryItem" OnSelectedIndexChanged="ddlFactoryItem_SelectedIndexChanged"
                                                                                AutoPostBack="true" onchange="UpdateLineLineDesignation(this)" runat="server">
                                                                            </asp:DropDownList>
                                                                            <asp:HiddenField runat="server" ID="hdnFactoryItem" Value='<%#Eval("UnitID") %>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ID="ddlFactoryFooter" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlFactoryFooter_SelectedIndexChanged">
                                                                                <asp:ListItem Selected="True" Value="-1">SELECT</asp:ListItem>
                                                                                <asp:ListItem Value="3">C 47</asp:ListItem>
                                                                                <asp:ListItem Value="11">C 45-46</asp:ListItem>
                                                                                <asp:ListItem Value="12">B 45</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="Associated With" HeaderStyle-Width="20%"
                                                                    ItemStyle-Width="25%">
                                                                    <ItemTemplate>
                                                                        <div class="checklist" style="text-align: center; text-transform: capitalize;">
                                                                            <%---------------------------------------------------------chnaged by abhishek--%>
                                                                            <input id="chk_stitching" runat="server" onchange="UpdateLineLineDesignation(this);"
                                                                                type="checkbox" checked="checked" />Stitching
                                                                            <input id="Chk_Finishing" runat="server" onchange="UpdateLineLineDesignation(this);"
                                                                                type="checkbox" />Finishing
                                                                            <input id="Chk_cutting" runat="server" onchange="UpdateLineLineDesignation(this);"
                                                                                type="checkbox" />Cutting
                                                                            <%-- <asp:RadioButton ID="rbtnActive" Text="Active" runat="server" CssClass="Active" onclick="IsActive(this)" />

                                      <asp:RadioButton ID="rbtnInActive" Text="InActive"  runat="server" CssClass="InActive" onclick="IsInActive(this)" />--%>
                                                                            <asp:HiddenField runat="server" ID="hdnstiching" Value='<%#Eval("stitching") %>' />
                                                                            <asp:HiddenField runat="server" ID="hdnfinshing" Value='<%#Eval("Finishing") %>' />
                                                                            <asp:HiddenField runat="server" ID="hdncutting" Value='<%#Eval("Cutting") %>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center; text-transform: capitalize;">
                                                                            <%--<asp:RadioButtonList ID="rbtnIsfinshing_footer" Width="100%" runat="server" RepeatColumns="3"

                                        TextAlign="right" RepeatLayout="Table" RepeatDirection="Vertical">

                                        <asp:ListItem Value="1" Text="stiching"></asp:ListItem>

                                        <asp:ListItem Value="2" Text="finshing"></asp:ListItem>

                                        <asp:ListItem Value="3" Text="cutting"></asp:ListItem>

                                      </asp:RadioButtonList>--%>
                                                                            <asp:CheckBox ID="chk_footer_stitching" runat="server" Checked="true" />
                                                                            Stitching
                                                                            <asp:CheckBox ID="Chk_footer_Finishing" runat="server" />
                                                                            Finishing
                                                                            <asp:CheckBox ID="Chk_footer_cutting" runat="server" />
                                                                            Cutting
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="6%">
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:LinkButton ID="abtnAdd" runat="server" CommandName="Insert" CssClass="link"
                                                                                Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png"  /></asp:LinkButton>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <ControlStyle Width="20%"></ControlStyle>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <FooterStyle CssClass="border" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <thead>
                                                                        <tr style="text-align: center;">
                                                                            <th width="20%">
                                                                                Line Designation
                                                                            </th>
                                                                            <th width="20%">
                                                                                Name
                                                                            </th>
                                                                            <th width="20%">
                                                                                Is Active
                                                                            </th>
                                                                            <th width="14%">
                                                                                Production Unit
                                                                            </th>
                                                                            <th width="20%">
                                                                                Asociated With
                                                                            </th>
                                                                            <th width="10%">
                                                                                &nbsp;
                                                                            </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr style="text-align: center;">
                                                                            <td align="center">
                                                                                <asp:DropDownList ID="ddlDesignationEmpty" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNameEmpty" onkeypress="return onlyAlphabets(event,this);" onKeyDown="return BlockingHtml(this,event);"
                                                                                    Style="text-align: center;" runat="server" MaxLength="50" />
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:RadioButtonList ID="rbtnIsActiveItemEmpty" Width="100" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Selected="True" Value="1" Text="Active"></asp:ListItem>
                                                                                    <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlFactoryEmpty" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="center">
                                                                                <%--<asp:RadioButtonList ID="rbtnIsfinshing_add" Width="150" runat="server" RepeatDirection="Horizontal">

                                        <asp:ListItem Value="1" Text="stiching_add"></asp:ListItem>

                                        <asp:ListItem Value="2" Text="finshing_add"></asp:ListItem>

                                        <asp:ListItem Value="3" Text="cutting_add"></asp:ListItem>

                                      </asp:RadioButtonList>--%>
                                                                                <input id="chk_stitching_empty" runat="server" type="checkbox" checked="checked" />Stitching
                                                                                <input id="Chk_Finishing_empty" runat="server" type="checkbox" />Finshing
                                                                                <input id="Chk_cutting_empty" runat="server" type="checkbox" />Cutting
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="addbutton" runat="server" CommandName="addnew" CssClass="link"
                                                                                    Text="Add" OnClientClick="" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                Record Not Found
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle Height="23px" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <%-- <Triggers>

                            <asp:AsyncPostBackTrigger ControlID="abtnAdd" EventName="Click" />

                            </Triggers>--%>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                    <!--end-->
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
