<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IkandiCommitSales_Admin.aspx.cs"
    MasterPageFile="~/layout/Secure.Master" Inherits="iKandi.Web.Internal.Sales.IkandiCommitSales_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript" src="../../js/facebox.js"></script>
    <script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <style type="text/css">
        .tablegrid
        {
            border-top: thin solid #dddfe4;
        }
        
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: verdana;
        }
        table
        {
            font-family: verdana;
            border-color: gray;
            border-collapse: collapse;
        }
        th
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: arial,halvetica;
            font-size: 10px;
            padding: 5px 0px 5px 0px;
            text-transform: capitalize;
            text-align: center;
        }
        th span
        {
            color: #575759 !important;
        }
        table td
        {
            font-size: 10px;
            text-align: center;
            border-color: #aaa;
            text-transform: capitalize;
        }
        .per
        {
            color: blue;
        }
        .gray
        {
            color: gray;
        }
        h2
        {
            width: 70%;
        }
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        table td table td
        {
            border-color: #ddd;
        }
        input, select
        {
            padding: 0px;
        }
        div select option
        {
            padding: 4px 0px;
            width: 86%;
        }
        div input
        {
            color: blue;
            padding: 4px 0px;
        }
        .style_number_box_background
        {
            opacity: 0.9;
            background: grey;
            width: 2400px;
        }
        .style_number_box
        {
            padding: 0px !important;
            width: 550px !important;
            border: none;
        }
        .style_number_box table
        {
            border: 1px solid gray;
            padding-bottom: 5px;
        }
        .style_number_box div
        {
            background-color: #39589c;
            color: #fff;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-transform: capitalize;
            width: 100%;
            padding: 5px 0px;
        }
        .style_number_box
        {
            top: 50px !important;
            left: 50% !important;
            position: absolute !important;
        }
        .hover_row td
        {
            background-color: #A1DCF2;
        }
        .inner-table
        {
            border-color: #f2f2f2;
            text-align: left;
        }
        .inner-table td
        {
            text-align: left;
            padding: 0px 0px 0px 3px;
        }
        .foo-input, foo-select
        {
            font-size: 9px;
            height: 13px;
        }
        .inner-table td input
        {
            padding: 0px;
        }
        
        .inner-table select, .inner-table select option
        {
            padding: 0px;
            width: 97%;
            font-size: 9px;
            height: 16px;
        }
        .disable, .disableF
        {
            background-image: url('../../images/n_a.png');
            height: 16px;
            width: 20px;
            background-repeat: no-repeat;
            opacity: 0.35;
            border: 1px solid gray !important;
        }
        #Img1
        {
            height: 10px;
        }
        
        /* The Modal (background) */
        .modal
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        
        /* Modal Content */
        .modal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 750px;
            margin-top: 12%;
        }
        
        /* The Close Button */
        .close
        {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        
        .close:hover, .close:focus
        {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
        .submit
        {
            color: Yellow !important;
        }
        input[type="text"], select
        {
            color: Gray !important;
        }
        .item_list TD .ValidationBorder, .item_list TD input[type=text].ValidationBorder, .item_list TD textarea.ValidationBorder
        {
            border: 1px solid #FF0000 !important;
        }
        .FloatRight
        {
            float: right;
        }
    </style>
    <script type="text/javascript">
        //Create a Function for Flaot Value Surendra2 on 02-11-2018.
        function isNumberKeyfloat(evt, val) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            else {
                var len = val.value.length;
                var index = val.value.indexOf('.');

                if (index > 0 && charCode == 46) {
                    return false;
                }
                if (index > 0) {
                    var CharAfterdot = (len + 1) - index;
                    if (CharAfterdot > 3) {
                        return false;
                    }
                }

            }
            return true;
        }
        //Create a Function for int Value Surendra2 on 27-08-2018.
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function chechZero(evt, obj) {
            if (obj == '1') {
                var val = parseInt(evt.value);
                var nextval = $(evt).parent().next().find('input').val();
                if (parseInt(nextval) == 0) {
                    $(evt).parent().next().find('input').val('');
                }
                if (val == 0 && parseInt(nextval) != 0) {
                    alert("Zero is not valid.");
                    evt.value = "";
                    evt.focus();
                    return false;
                }
                else {
                    return true;
                }
            }
            if (obj == '2') {
                var val = parseInt(evt.value);
                var prevVal = $(evt).parent().prev().find('input').val();
                if (parseInt(prevVal) == 0) {
                    $(evt).parent().prev().find('input').val('');
                }
                if (val == 0 && parseInt(prevVal) != 0) {
                    alert("Zero is not valid.");
                    evt.value = "";
                    evt.focus();
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        function showpopup() {
            debugger;
            $("#ctl00_cph_main_content_hdnPopup").val('1');
            $("#ctl00_cph_main_content_divIkandi_Admin").css("display", "block");
        }
        function ShowAlert(Msg) {
            alert(Msg);
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            debugger;
            var valuex = $("#ctl00_cph_main_content_hdnPopup").val();
            if (valuex == "1") {
                $("#ctl00_cph_main_content_divIkandi_Admin").css("display", "block");
            }
            else {
                $("#ctl00_cph_main_content_divIkandi_Admin").css("display", "none");
            }
            return false;
        }

        function validate() {
            var ddlClient = $('#ctl00_cph_main_content_ddl_Client').val();
            var ddlPDept = $('#ctl00_cph_main_content_ddl_ParentDept').val();
            var ddlDept = $('#ctl00_cph_main_content_ddl_Dept').val();

            if (ddlClient == '-1') {
                alert('Please Select Client.')
                $('#ctl00_cph_main_content_ddl_Client').focus();
                return false;
            }
            if (ddlPDept == '-1') {
                alert('Please Select Parent Department.')
                $('#ctl00_cph_main_content_ddl_ParentDept').focus();
                return false;
            }
            if (ddlDept == '-1') {
                alert('Please Select Sub Department.')
                $('#ctl00_cph_main_content_ddl_Dept').focus();
                return false;
            }
            return true;
        }

        function validateControl(ctrl) {
            var count = 0;
            var grdRow = ctrl.parentNode.parentNode;
            var grdControl = grdRow.getElementsByTagName("input");

            //LOOP THROUGH EACH INPUT CONTROL IN THE GRIDVIEW.
            for (var i = 0; i < grdControl.length; i++) {
                if (grdControl[i].type === 'text') {
                    if (grdControl[i].value === "") {
                        grdControl[i].style.borderColor = '#FF0000';
                        count++;
                    }
                    else {
                        grdControl[i].style.borderColor = '';
                        grdControl[i].style.backgroundColor = '';
                    }
                }
            }

            if (count > 0) {
                return false;
            }
        }

    </script>
    <h2 style="width: 100% !important;">
        Ikandi Monthly Sales
    </h2>
    <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="pnlUpdt1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <h4>
                        <span>Add Client Department..</span>
                        <asp:ImageButton ImageUrl="../../App_Themes/ikandi/images/plus.gif" ID="ImgAddClient"
                            ToolTip="Add Client and Department" Style="position: absolute; margin-top: -3px;"
                            runat="server" OnClick="ImgAddClient_Click" />
                        <asp:HiddenField ID="hdnPopup" runat="server" Value="0" />
                    </h4>
                </div>
                <table cellspacing="0" cellpadding="0" style="width: 100%;">
                    <thead>
                        <tr>
                            <th style="border: thin solid gray; width: 120px;" rowspan="2">
                                Client
                            </th>
                            <th style="border: thin solid gray; width: 120px;" rowspan="2">
                                Parent Dept.
                            </th>
                            <th style="border: thin solid gray; width: 120px;" rowspan="2">
                                Dept.
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                April
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                May
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                June
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                Jule
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                August
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                September
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                October
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                November
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                December
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                January
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                February
                            </th>
                            <th style="border: thin solid gray; width: 100px;" colspan="2">
                                March
                            </th>
                            <th style="border: thin solid gray; width: 100px;" rowspan="2">
                                Action
                            </th>
                        </tr>
                        <tr>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Val
                            </th>
                            <th style="border: thin solid gray; width: 50px;">
                                Pcs
                            </th>
                        </tr>
                    </thead>
                </table>
                <asp:GridView ID="grdIkandiCommitSales_Admin" runat="server" AutoGenerateColumns="false"
                    ShowFooter="True" ShowHeader="false" OnRowCancelingEdit="grdIkandiCommitSales_Admin_RowCancelingEdit"
                    OnRowDataBound="grdIkandiCommitSales_Admin_RowDataBound" OnRowEditing="grdIkandiCommitSales_Admin_RowEditing"
                    OnRowUpdating="grdIkandiCommitSales_Admin_RowUpdating" Width="100%" FooterStyle-Font-Bold="true">
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                            </ItemTemplate>
                           <%-- <EditItemTemplate>
                                <asp:DropDownList ID="ddlClient" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnClient" runat="server" Value='<%# Eval("ClientID") %>' />
                            </EditItemTemplate>--%>
                            <ItemStyle Width="99px" />
                            <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text="Total" CssClass="FloatRight"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="lblParentDept" runat="server" Text='<%# Eval("ParentDept") %>'></asp:Label>
                            </ItemTemplate>
                           <%-- <EditItemTemplate>
                                <asp:DropDownList ID="ddlParentDept" runat="server" Width="90%" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlParentDept_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnParentDeptId" runat="server" Value='<%# Eval("PDeptId") %>' />
                            </EditItemTemplate>--%>
                            <ItemStyle Width="100px" />
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="120px">
                            <ItemTemplate>
                                <asp:Label ID="lblDept" runat="server" Text='<%# Eval("Dept") %>'></asp:Label>
                            </ItemTemplate>
                          <%--  <EditItemTemplate>
                                <asp:DropDownList ID="ddlDept" runat="server" Width="90%">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnDeptId" runat="server" Value='<%# Eval("Deptid") %>' />
                            </EditItemTemplate>--%>
                            <ItemStyle Width="100px" />
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal1" runat="server" Style="color: Green;" ToolTip='<%# Eval("Apr_Val", "{0:#,##}")%>' Text='<%# Eval("Apr_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal1" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Apr_Val") %>'></asp:TextBox>
                                     <asp:HiddenField ID="hdnClient" runat="server" Value='<%# Eval("ClientID") %>' />
                                     <asp:HiddenField ID="hdnParentDeptId" runat="server" Value='<%# Eval("PDeptId") %>' />
                                     <asp:HiddenField ID="hdnDeptId" runat="server" Value='<%# Eval("Deptid") %>' />
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal1" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs1" runat="server" ToolTip='<%# Eval("Apr_Psc", "{0:#,##}")%>' Text='<%# Eval("Apr_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs1" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Apr_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs1" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal2" runat="server" Style="color: Green;" ToolTip='<%# Eval("May_Val", "{0:#,##}")%>' Text='<%# Eval("May_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal2" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("May_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal2" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs2" runat="server" ToolTip='<%# Eval("May_Psc", "{0:#,##}")%>' Text='<%# Eval("May_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs2" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("May_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs2" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal3" runat="server" Style="color: Green;" ToolTip='<%# Eval("Jun_Val", "{0:#,##}")%>' Text='<%# Eval("Jun_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal3" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Jun_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal3" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs3" runat="server" ToolTip='<%# Eval("Jun_Psc", "{0:#,##}")%>' Text='<%# Eval("Jun_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs3" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Jun_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs3" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal4" runat="server" Style="color: Green;" ToolTip='<%# Eval("Jul_Val", "{0:#,##}")%>' Text='<%# Eval("Jul_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal4" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Jul_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal4" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs4" runat="server" ToolTip='<%# Eval("Jul_Psc", "{0:#,##}")%>' Text='<%# Eval("Jul_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs4" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Jul_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs4" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal5" runat="server" Style="color: Green;" ToolTip='<%# Eval("Aug_Val", "{0:#,##}")%>' Text='<%# Eval("Aug_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal5" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Aug_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal5" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs5" runat="server" ToolTip='<%# Eval("Aug_Psc", "{0:#,##}")%>' Text='<%# Eval("Aug_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs5" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Aug_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs5" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal6" runat="server" Style="color: Green;" ToolTip='<%# Eval("Sept_Val", "{0:#,##}")%>' Text='<%# Eval("Sept_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal6" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Sept_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal6" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs6" runat="server" ToolTip='<%# Eval("Sept_Psc", "{0:#,##}")%>' Text='<%# Eval("Sept_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs6" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Sept_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs6" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal7" runat="server" Style="color: Green;" ToolTip='<%# Eval("Oct_Val", "{0:#,##}")%>' Text='<%# Eval("Oct_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal7" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Oct_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal7" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs7" runat="server" ToolTip='<%# Eval("Oct_Psc", "{0:#,##}")%>' Text='<%# Eval("Oct_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs7" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Oct_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs7" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal8" runat="server" Style="color: Green;" ToolTip='<%# Eval("Nov_Val", "{0:#,##}")%>' Text='<%# Eval("Nov_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal8" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Nov_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal8" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs8" runat="server" ToolTip='<%# Eval("Nov_Psc", "{0:#,##}")%>' Text='<%# Eval("Nov_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs8" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Nov_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs8" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal9" runat="server" Style="color: Green;" ToolTip='<%# Eval("Dec_Val", "{0:#,##}")%>' Text='<%# Eval("Dec_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal9" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Dec_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal9" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs9" runat="server" ToolTip='<%# Eval("Dec_Psc", "{0:#,##}")%>' Text='<%# Eval("Dec_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs9" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Dec_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs9" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal10" runat="server" Style="color: Green;" ToolTip='<%# Eval("Jan_Val", "{0:#,##}")%>' Text='<%# Eval("Jan_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jan_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal10" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Jan_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal10" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs10" runat="server" ToolTip='<%# Eval("Jan_Psc", "{0:#,##}")%>' Text='<%# Eval("Jan_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jan_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs10" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Jan_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="42px" />
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs10" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal11" runat="server" Style="color: Green;" ToolTip='<%# Eval("Feb_Val", "{0:#,##}")%>' Text='<%# Eval("Feb_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Feb_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal11" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Feb_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal11" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemStyle Width="42px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs11" runat="server" ToolTip='<%# Eval("Feb_Psc", "{0:#,##}")%>' Text='<%# Eval("Feb_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Feb_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs11" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Feb_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs11" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemStyle Width="42px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblVal12" runat="server" Style="color: Green;" ToolTip='<%# Eval("Mar_Val", "{0:#,##}")%>' Text='<%# Eval("Mar_Val").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Mar_Val").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVal12" Width="90%" MaxLength="10" onkeypress="return isNumberKeyfloat(event, this)"
                                    onchange="chechZero(this,1);" runat="server" Text='<%# Eval("Mar_Val") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblFooterVal12" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemStyle Width="42px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lblPcs12" runat="server" ToolTip='<%# Eval("Mar_Psc", "{0:#,##}")%>' Text='<%# Eval("Mar_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Mar_Psc").ToString())/1000).ToString("0.00") + " K" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPcs12" Width="90%" MaxLength="10" onkeypress="return isNumberKey(event)"
                                    onchange="chechZero(this,2);" runat="server" Text='<%# Eval("Mar_Psc") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblFooterPcs12" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemStyle Width="42px" />
                        </asp:TemplateField>
                        <asp:CommandField EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;'
                            HeaderText="Action" ShowEditButton="True" ButtonType="Link" CancelText='&lt;img src="../../images/cancel.jpg" title="Cancel" alt="Cancel" /&gt;'
                            UpdateText='&lt;img src="../../images/update.gif" title="Update" alt="Update" /&gt;'
                            CausesValidation="true">
                            <ItemStyle HorizontalAlign="Center" Width="85px" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Record Found
                    </EmptyDataTemplate>
                </asp:GridView>
                <div id="divIkandi_Admin" runat="server" class="modal">
                    <div class="modal-content">
                        <div>
                            <h3>
                                Add Client And Department
                            </h3>
                        </div>
                        <br />
                        <table cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    Client
                                </td>
                                <td style="width: 140px;">
                                    <asp:DropDownList ID="ddl_Client" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Client_SelectedIndexChanged"
                                        Width="125px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Parent Departmant
                                </td>
                                <td style="width: 140px;">
                                    <asp:DropDownList ID="ddl_ParentDept" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_ParentDept_SelectedIndexChanged"
                                        Width="125px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Department
                                </td>
                                <td style="width: 140px;">
                                    <asp:DropDownList ID="ddl_Dept" runat="server" Width="125px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 80px;">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="submit" ToolTip="Submit"
                                        OnClientClick="return validate();" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div style="width: 10%; vertical-align: top; border: 0px solid #000000;" align="left">
                            <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="submit" ToolTip="Return to Details"
                                OnClick="btnReturn_Click" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
