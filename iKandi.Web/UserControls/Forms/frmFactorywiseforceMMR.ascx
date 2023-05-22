<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmFactorywiseforceMMR.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.frmFactorywiseforceMMR" %>
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
  
    .select-con
    {
        font-size: 12px;
        line-height: 20px !important;
    }
    .select-con option
    {
        background: #fff;
        font-size: 14px !important;
        font-family: verdana;
        color: #000;
        line-height: 20px !important;
        padding-bottom: 5px;
    }
    #main_content
    {
        text-transform: capitalize !important;
    }
    /*-------------------------9-nov-2015------------------------- */
    .main_tbl_wrapper
    {
        background: #ffffff;
    }
    
    
    .border td
    {
        font-size: 10px !important;
    }
    .heading-bg
    {
        padding: 10px 3px !important;
    }
    .border2 th
    {
        padding: 2px !important;
    }
    .font
    {
        font-size: 12px !important;
    }
    #secure_banner_cor
    {
        background: none !important;
    }
</style>
<link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
<script type="text/javascript">


    var txt_Workertype = '<%=txtWorker.ClientID %>';
    var txt_Workersalary = '<%=txtsalary.ClientID %>';
    var ddl = document.getElementById("<%=DDl_Dept.ClientID%>");

    var RadioMachinecount1 = '<%=rdo_machinecount.ClientID%>';
    var RadioMachinecount2 = '<%=rdo_machinecount2.ClientID%>';

    function formatNumber(num) {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
    }


    function ValidateControl() {
        //        if (document.getElementById('<%=txtWorker.ClientID %>').value == "") {

        //            ShowHideMessageBox(true, "Enter worker type", "Manpower form");
        //            return false;
        //        }
        //        if (document.getElementById('<%=DDl_Dept.ClientID%>').value == "-1") {
        //            ShowHideMessageBox(true, "Select staff department", "Manpower form");

        //            return false;
        //        }
        //        if (document.getElementById('<%=txtsalary.ClientID %>').value == "") {

        //            ShowHideMessageBox(true, "Enter salary ", "Manpower form");
        //            return false;
        //        }






    }

    //    $(function () {
    //        $('#<%=txtsalary.ClientID%>').change(function () {

    //           
    //           
    //          
    //           

    //        });

    //    });
    function onlyNumbers(evt) {//FRO GRIDVIEW SALARY TEXBOX
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }


    function gridValidate() {

        var count1 = 0;
        var Count2 = 0;
        //        var count3 = 0;
        //        var Count4 = 0;
        //        var count5 = 0;
        //        var Count6 = 0;
        $('.WokertypeCss').each(function (index, item) {
            if ($(this).val() != "") {
                count1 = 1;
            }
        }, 0);

        if (count1 == 0) {
            ShowHideMessageBox(true, "Enter worker type", "Manpower form");
            //alert("Enter Worker Type First .");
            return false;
        }

        $('.TxtWorkerTypeCss').each(function (index, item) {
            if ($(this).val() != "") {
                Count2 = 1;
            }
        }, 0);

        if (Count2 == 0) {
            //alert("Enter salary First .");
            ShowHideMessageBox(true, "Enter salary", "Manpower form");
            return false;
        }


        //        $('.OT1css').each(function (index, item) {
        //            if ($(this).val() != "") {
        //                count3 = 1;
        //            }
        //        }, 0);

        //        if (count3 == 0) {
        //            ShowHideMessageBox(true, "Enter OT1", "Manpower form");
        //            //alert("Enter Worker Type First .");
        //            return false;
        //        }


        //        $('.OT2css').each(function (index, item) {
        //            if ($(this).val() != "") {
        //                Count4 = 1;
        //            }
        //        }, 0);

        //        if (Count4 == 0) {
        //            ShowHideMessageBox(true, "Enter OT2", "Manpower form");
        //            //alert("Enter Worker Type First .");
        //            return false;
        //        }


        //        $('.OT3css').each(function (index, item) {
        //            if ($(this).val() != "") {
        //                count5 = 1;
        //            }
        //        }, 0);

        //        if (count5 == 0) {
        //            ShowHideMessageBox(true, "Enter OT3", "Manpower form");
        //            //alert("Enter Worker Type First .");
        //            return false;
        //        }


        //        $('.OT4css').each(function (index, item) {
        //            if ($(this).val() != "") {
        //                count6 = 1;
        //            }
        //        }, 0);

        //        if (count6 == 0) {
        //            ShowHideMessageBox(true, "Enter OT4", "Manpower form");
        //            //alert("Enter Worker Type First .");
        //            return false;
        //        }
        else {
            return true;
        }
    }


    //    function whichButton(event) {
    //        if (event.button == 2)//RIGHT CLICK
    //        {
    //            //alert("Not Allow Right Click!");
    //            ShowHideMessageBox(true, "Not allow right click", "Manpower form");
    //        }

    //    }
    function noCTRL(e) {
        var code = (document.all) ? event.keyCode : e.which;

        var msg = "sorry, copy paste is not allowed.";
        if (parseInt(code) == 17) //CTRL
        {
            //alert(msg);
            ShowHideMessageBox(true, msg, "Manpower form");
            window.event.returnValue = false;
        }
    }
    function isNumberKeyDecimal(evt) {

        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
            return false;

        return true;
    }
    //previnting user from entring html tag
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

    $('#<%=txtsalary.ClientID%>').keyup(function () {

        var myLength = $("#<%=txtsalary.ClientID%>").val().length;
        debugger;
        if (myLength == 1) {
            if ($(this).val() === '0') {
                //alert('0 is not allowed as first character');
                ShowHideMessageBox(true, "salary could not be 0 (zero)", "Manpower form");
                $(this).val('');
            }
        }
    });


    //   factory wise upper
   
</script>




<!------------------------Add-by Prabhaker--------------------------->
<script type="text/javascript">
    function UpdateTableHeaders() {
        $(".persist-area").each(function () {
            var el = $(this),
               offset = el.offset(),
               scrollTop = $(window).scrollTop(),
               floatingHeader = $(".floatingHeader", this)
            if ((scrollTop > offset.top) && (scrollTop < offset.top + el.height())) {
                floatingHeader.css({
                    "visibility": "visible"
                });
            }
            else {
                floatingHeader.css({
                    "visibility": "hidden"
                });
            };
        });
    }
    // DOM Ready
    $(function () {
        var clonedHeaderRow;
        $(".persist-area").each(function () {
            clonedHeaderRow = $(".persist-header", this);
            clonedHeaderRow
             .before(clonedHeaderRow.clone())
             .css("width", clonedHeaderRow.width())
             .addClass("floatingHeader");
        });
        $(window)
        .scroll(UpdateTableHeaders)
        .trigger("scroll");
    });
    function CalculatePercent() {

        var Result;
        var Q = document.getElementById('<%=txtQnty.ClientID%>').value;
        var P = document.getElementById('<%=txtPercentage.ClientID%>').value;
        Q = Q == '' ? 0 : Q;
        P = P == '' ? 0 : P;
        if (Q == 0 && P == 0) {
            return;
        }
        else {
            // debugger;//masurement value round-off as per QA diss
            if (Q != 0 && P != 0) {
                //                Result = Math.round(parseFloat(Q * P / 100));
                Result = (Q * P / 100).toFixed(2);
                document.getElementById('<%=txtmeasurement.ClientID%>').value = Result;
            }
            else {
                document.getElementById('<%=txtmeasurement.ClientID%>').value = '';
            }

        }
    }
    function TestOnTextChange() {
        debugger;

        var CmtworkingDays = document.getElementById('<%=hdn_cmt_workingdays.ClientID%>').value;
        var otcount = document.getElementById('<%=txtsalary.ClientID%>').value;

        var ot;

        if (otcount != '') {
            //            ot = ((otcount/24.33/8) * 1.1).toFixed(0);

            //ot = (Math.round(Math.round(otcount / 24.33 / 8) * 1.1)).toFixed(0);
            ot = (Math.round(Math.round(otcount / CmtworkingDays / 8) * 1.1)).toFixed(0);
            document.getElementById('<%=txtOT1.ClientID%>').value = ot;
            document.getElementById('<%=txtOT2.ClientID%>').value = ot;
            document.getElementById('<%=txtOT3.ClientID%>').value = ot;
            document.getElementById('<%=txtOT4.ClientID%>').value = ot;
        }


    }
    function pageLoad() {
        $('input').attr('autocomplete', 'off');
        //alert("aaa");
        $('.number').keypress(function (event) {
            var $this = $(this);
            if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
       ((event.which < 48 || event.which > 57) &&
       (event.which != 0 && event.which != 8))) {
                event.preventDefault();
            }

            var text = $(this).val();
            if ((event.which == 46) && (text.indexOf('.') == -1)) {
                setTimeout(function () {
                    if ($this.val().substring($this.val().indexOf('.')).length > 3) {
                        $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
                    }
                }, 1);
            }

            if ((text.indexOf('.') != -1) &&
        (text.substring(text.indexOf('.')).length > 2) &&
        (event.which != 0 && event.which != 8) &&
        ($(this)[0].selectionStart >= text.length - 2)) {
                event.preventDefault();
            }
        });

        $('.number').bind("paste", function (e) {
            var text = e.originalEvent.clipboardData.getData('Text');
            if ($.isNumeric(text)) {
                if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
                    e.preventDefault();
                    $(this).val(text.substring(0, text.indexOf('.') + 3));
                }
            }
            else {
                e.preventDefault();
            }
        });
       
    }
</script>





<table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" >
    <tr>
        <td>
        <asp:HiddenField ID="hdn_cmt_workingdays" runat="server" Value="0" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                bgcolor="#ffffff" style="padding:0px 10px; margin-bottom: 40px;">
                <tr>
                    <td class="main-heading">
                    
                        Factory Work Force Admin
                    </td>
                </tr>
                <tr> 
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0"> 
                            <tr>
                                <td style="font-size: 12px; font-weight: normal; color: #3b5998; line-height: 30px;
                                    text-align: left; text-transform: none; width:32%">
                                    All <span  style="color: Red;font-size: 12px;">*</span> (asterisk) mark field mendatory
                                </td>
                                
                                <td style="font-size: 12px; font-weight: normal; color: #0088cc; line-height: 30px;
                                    text-align: left; text-transform: none;width:68%">
                                    (Factory man power details (department, salary, Ob/Non-OB, OT)
                                </td>
                            </tr>
                        </table>
                    </td>
        
                   
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px; border:1px solid #ccc;">
                                    <tr class="td-sub_headings border">
                                        <td class="heading-bg" width="60px">
                                            Worker type <span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="60px">
                                            <input style="text-transform: none;  width: 100px;" maxlength="50" runat="server" title="Enter type of worker name"
                                                id="txtWorker" name="" onkeydown="return BlockingHtml(this,event);" type="text"
                                                class="input_in" />
                                        </td>
                                        <td class="heading-bg" width="60px">
                                            Department <span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="90px">
                                            <asp:DropDownList ID="DDl_Dept" ToolTip="Select worker department" runat="server"
                                                Width="90%" BackColor="#F6F1DB" AutoPostBack="true" ForeColor="#7d6754" CssClass="ddl select-con"
                                                Style="line-height: 20px !important;" OnSelectedIndexChanged="DDl_Dept_SelectedIndexChanged">
                                                <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                <asp:ListItem Value="0">Stitching</asp:ListItem>
                                                <asp:ListItem Value="1">Finishing</asp:ListItem>
                                                <asp:ListItem Value="2">Cutting</asp:ListItem>
                                                <asp:ListItem Value="3">Misc</asp:ListItem>
                                                <asp:ListItem Value="4">XNY</asp:ListItem>
                                                <asp:ListItem Value="5">Accessory</asp:ListItem>
                                                <asp:ListItem Value="6">R&D</asp:ListItem>
                                                <asp:ListItem Value="7">Fabric</asp:ListItem>

                                            </asp:DropDownList>
                                        </td>
                                        <td class="heading-bg" colspan="2" width="80px">
                                            Category & % Garment <span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td colspan="3" width="160px">
                                            <div style="float: left; width: 40%">
                                                <asp:DropDownList ID="ddlcatogary" title="Select Worker catogary" runat="server"
                                                    Width="90%" BackColor="#F6F1DB" ForeColor="#7d6754" CssClass="ddl select-con"
                                                    Style="line-height: 20px !important;" OnSelectedIndexChanged="ddlcatogary_SelectedIndexChanged"
                                                    AutoPostBack="true">
                        <%-- <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                        <%--<asp:ListItem Value="1" Text="">Factory Based</asp:ListItem>
                           <asp:ListItem Value="2" Text="">Line Based</asp:ListItem>
                           <asp:ListItem Value="3" Text="">Floor Based</asp:ListItem>
                           <asp:ListItem Value="4" Text="">Pcs Per hour based</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Divpercentage" visible="false" runat="server" style="float: left; width: 55%;
                                                font-size: 9px;">
                                                Qnty<span style="color: red; font-size: 12px;">*</span><input style="text-transform: none; width: 30px;" title="Enter Quantity value"
                                                    runat="server" onchange="javascript:CalculatePercent();" id="txtQnty" maxlength="4"
                                                    onkeypress="return onlyNumbers(event);" onpaste="return false;" name="" type="text"
                                                    class="input_in" />
                                                <span style="color: red; font-size: 12px;">*</span><input style="text-transform: none; width: 30px;" runat="server" title="Enter percent value"
                                                    onchange="javascript:CalculatePercent();" id="txtPercentage" maxlength="4" onkeypress="return onlyNumbers(event);"
                                                    onpaste="return false;" name="" type="text" class="input_in" />%
                                            </div>
                                            
                                             
                                            <div style="clear: both;">
                                            </div>
                                        </td>

                                           <td class="heading-bg" width="50px">
                                            Measurement<span style="color: red; font-size: 12px;">*</span>
                                        </td>

                                        <td width="40px">
                                        <input style="text-transform: none; float: right; width: 40px;" runat="server" title="(Quntity * Percent/ 100)"
                                                id="txtmeasurement" maxlength="4" onkeypress="return onlyNumbers(event);" onpaste="return false;"
                                                name="" type="text" class="input_in" />
                                        
                                        </td>
                                        <td class="heading-bg" width="50px">
                                            Salary<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="50px">
                                            <input style="text-transform: none; width: 50px;" onchange="javascript:TestOnTextChange()" runat="server" id="txtsalary" maxlength="6"
                                                onkeypress="return onlyNumbers(event);" onpaste="return false;" name="" type="text"
                                                class="input_in" />
                                        </td>
                                        <td class="heading-bg" width="100px">
                                            Part of machine count<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="90px">
                                            <asp:RadioButton ID="rdo_machinecount" runat="server" Text="YES" GroupName="ma" />
                                            <asp:RadioButton ID="rdo_machinecount2" runat="server" Text="NO" GroupName="ma" />
                                        </td>
                                       
                                    </tr>
                                    <tr>


                                     <td class="heading-bg" width="60px">
                                            OB based<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="60px">
                                            <asp:RadioButton ID="obnased1" runat="server" Text="Yes" GroupName="mmr" />
                                            <asp:RadioButton ID="obnased2" runat="server" Text="No" GroupName="mmr" />
                                        </td>

                                        <td class="heading-bg" width="60px">
                                            IsStatus<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="60px">
                                            <asp:RadioButton ID="rdo_IsStatus1" runat="server" Text="Yes" GroupName="isstatus" />
                                            <asp:RadioButton ID="rdo_IsStatus2" runat="server" Text="No" GroupName="isstatus" />
                                        </td>

                                        <%--<td width="60px" class="heading-bg">
                                            Permanent<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="60px">
                                            <asp:RadioButton ID="rdo_isstaff1" ToolTip="Staff based worker" runat="server" Text="Yes" GroupName="m" />
                                            <asp:RadioButton ID="rdo_isstaff2" ToolTip="variable based worker" runat="server" Text="No" GroupName="m" />
                                        </td>--%>
                                        <%--ot1--%>
                                        <td width="60px" class="heading-bg">
                                            OT.1<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="60px">
                                            <input style="text-transform: none; width: 50px;" readonly="readonly" runat="server" id="txtOT1" maxlength="5"
                                                onkeypress="return onlyNumbers(event);" onpaste="return false;" name="" type="text"
                                                class="input_in" />
                                        </td>
                                        <%--ot2--%>
                                        <td width="50px" class="heading-bg">
                                            OT.2<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="60px">
                                            <input style="text-transform: none; width: 50px;" readonly="readonly" runat="server" id="txtOT2" maxlength="5"
                                                onkeypress="return onlyNumbers(event);" onpaste="return false;" name="" type="text"
                                                class="input_in" />
                                        </td>
                                        <%--ot3--%>
                                        <td width="40px" class="heading-bg">
                                            OT.3<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="50px">
                                            <input style="text-transform: none; width: 50px;" readonly="readonly" runat="server" id="txtOT3" maxlength="5"
                                                onkeypress="return onlyNumbers(event);" onpaste="return false;" name="" type="text"
                                                class="input_in" />
                                        </td>
                                        <%--ot3--%>
                                        <td width="40px" class="heading-bg">
                                            OT.4<span style="color: red; font-size: 12px;">*</span>
                                        </td>
                                        <td width="50px">
                                            <input style="text-transform: none; width: 50px;" runat="server" readonly="readonly" id="txtOT4" maxlength="5"
                                                onkeypress="return onlyNumbers(event);" onpaste="return false;" name="" type="text"
                                                class="input_in" />
                                        </td>
                                        <td width="50px" class="heading-bg">
                                            Description
                                        </td>
                                        <td width="60px">
                                            <asp:TextBox ID="txt_discription" MaxLength="50" runat="server" onkeydown="return BlockingHtml(this,event);"
                                                Style="text-transform: none; width: 50px;"></asp:TextBox>
                                        </td>
                                        <td align="left" width="60px" style="border-left: none;">
                                            <asp:Button ID="btnsubmit" Text="Submit" CssClass="submit" runat="server" OnClientClick="return ValidateControl()"
                                                OnClick="btnsubmit_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <td style="padding-bottom: 10px;">
                                                <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;">
                                                </span>
                                            </td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <!--table2-->
                                           
                                            
                                            <asp:GridView ID="grdCurrency" runat="server" CssClass="font" AutoGenerateColumns="False"
                                                Width="100%" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Font-Size="13px" OnRowCancelingEdit="grdCurrency_RowCancelingEdit"
                                                OnRowEditing="grdCurrency_RowEditing" OnRowUpdating="grdCurrency_RowUpdating"
                                                OnRowDataBound="grdCurrency_RowDataBound" OnPageIndexChanging="grdCurrency_PageIndexChanging"
                                                BorderWidth="0">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Worker Type" HeaderStyle-Font-Bold="false" HeaderStyle-Width="150PX">
                                                        <ItemTemplate>
                                                            <div style="text-transform: capitalize;">
                                                                <%#Eval("WorkerType")%>
                                                               
                                                            </div>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div style="text-transform: capitalize;">
                                                                <asp:TextBox ID="txtWorkerType" Style="text-transform: capitalize;" CssClass="WokertypeCss"
                                                                    runat="server" onkeydown="return BlockingHtml(this,event);" Text='<%#Eval("WorkerType")%>'></asp:TextBox>
                                                                <asp:HiddenField ID="hdnworkerType" runat="server" Value='<%#Eval("FactoryWorkSpace")%>' />
                                                                
                                                            </div>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Department" HeaderStyle-Font-Bold="false" HeaderStyle-Width="70PX">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" Text='<%#Eval("StaffDept")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList AutoPostBack="true" ID="ddl_Depart" runat="server" CssClass="ddl"
                                                                Style="width: 90%" OnSelectedIndexChanged="ddl_Depart_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="70px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category & % Garment" HeaderStyle-Font-Bold="false"
                                                        HeaderStyle-Width="230PX">
                                                        <ItemTemplate>
                                                            <div style="text-transform: capitalize;">
                                                                <div style="text-transform: capitalize; width: 50%; float: left;">
                                                                    <asp:Label ID="lblcatogary" Text='<%#Eval("Category")%>' runat="server"></asp:Label>
                                                                </div>
                                                                <div id="divgrd" runat="server" style="width: 50%; float: left;">
                                                                    <div style="float: left;">
                                                                        Qty:
                                                                    </div>
                                                                    <div style="width: 40px; border: 1px solid #ccc; float: left;">
                                                                        <asp:Label ID="lblqntygrd" Text='<%#Eval("Qty")%>' runat="server">                                 
                                       
                                                                        </asp:Label>
                                                                    </div>
                                                                    <div style="min-width: 40px; border: 1px solid #ccc; float: left;">
                                                                        <asp:Label ID="lblpercent" Text='<%#Eval("Percents")%>' runat="server"></asp:Label>
                                                                        %
                                                                    </div>
                                                                    <div style="clear: both;">
                                                                    </div>
                                                                </div>
                                                                <div style="clear: both;">
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div style="text-transform: capitalize; width: 50%; float: left;">
                                                                <asp:DropDownList ID="ddl_Departgrd" runat="server" CssClass="ddl" AutoPostBack="true"
                                                                    Style="width: 130px; text-transform: capitalize;" OnSelectedIndexChanged="ddl_Departgrd_SelectedIndexChanged">
                                                                   <%-- <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                           <asp:ListItem Value="1" Text="">Factory Based</asp:ListItem>
                                           <asp:ListItem Value="2" Text="">Line Based</asp:ListItem>
                                           <asp:ListItem Value="3" Text="">Floor Based</asp:ListItem>
                                           <asp:ListItem Value="4" Text="">Pcs Per hour based</asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div id="diveditgrd" runat="server" style="width: 50%; float: left;">
                                                                Qnty<asp:TextBox ID="txtqntygrd" AutoPostBack="true" Width="30px" MaxLength="4" onkeypress="return onlyNumbers(event);"
                                                                    onpaste="return false;" class="input_in" Text='<%#Eval("Qty")%>' runat="server"
                                                                    OnTextChanged="txtqntygrd_TextChanged"></asp:TextBox>
                                                                %<asp:TextBox ID="txtpercnetgrd" AutoPostBack="true" Width="30px" MaxLength="4" onkeypress="return onlyNumbers(event);"
                                                                    onpaste="return false;" class="input_in" Text='<%#Eval("Percents")%>' runat="server"
                                                                    OnTextChanged="txtpercnetgrd_TextChanged"></asp:TextBox>
                                                                
                                                            </div>
                                                            <div style="clear: both;">
                                                            </div>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="230px" />
                                                    </asp:TemplateField>

                                                    <%--new code starts 12 may 2020--%>
                                                    <asp:TemplateField HeaderText="IsStatus" HeaderStyle-Font-Bold="false" HeaderStyle-Width="80PX">
                                                        <ItemTemplate>
                                                            <div style="text-transform: capitalize;">
                                                                <asp:Label ID="lblIsStatus" Text='<%# Convert.ToBoolean(Eval("IsStatus"))==true?"Yes":"No"%>' runat="server"></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <EditItemTemplate >
                                                            <asp:RadioButton ID="rdo_isStatus1" Text="Yes" Checked="false" runat="server" GroupName="m2" />
                                                            <asp:RadioButton ID="rdo_isStatus2"  Text="No" Checked="false" runat="server" GroupName="m2" />
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <%--new code ends 12 may 2020--%>
                                                    <asp:TemplateField HeaderText="Measure ment" HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                        <ItemTemplate>
                                                            <div style="text-transform: capitalize;">
                                                                <asp:Label ID="lblMeasurement" Text='<%#Eval("Measurement")%>' runat="server"></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div style="text-transform: capitalize;">
                                                                <asp:TextBox ID="txtMeasurementgrd" CssClass="number" MaxLength="4" 
                                                                    onpaste="return false;" Width="40px" Text='<%#Eval("Measurement")%>' runat="server"></asp:TextBox>
                                                                   
                                                            </div>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Salary (Rs)" HeaderStyle-Font-Bold="false" HeaderStyle-Width="65PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="txtCurrencySymbol" Text='<%# Eval("Salary", "{0:#,##}")%>'></asp:Label>
                                                            <%--    <%# Eval("Salary", "{0:0.00}")%>--%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtSalary" MaxLength="6" Style="text-align: center; width: 60px" AutoPostBack="true" onkeypress="return onlyNumbers(this);"
                                                                onpaste="return false;" OnTextChanged="txtSalary_TextChanged" CssClass="TxtWorkerTypeCss" runat="server" Text='<%#Eval("Salary")%>'></asp:TextBox>
                                                            <%--  <asp:HiddenField ID="hdnId" runat="server"  Value='<%#Eval("WorkerType_ID") %>' /></div>--%>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="65px" />
                                                    </asp:TemplateField>
                                                    <%--abhi--%>
                                                    <asp:TemplateField HeaderText="hourly Salary (Rs)" HeaderStyle-Font-Bold="false"
                                                        HeaderStyle-Width="60PX">
                                                        <%-- end--%>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_hourly" ToolTip="Per hrs salary=(SALARY/24.33/8)"
                                                                Text='<%#Eval("hourly_sal")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_hourly" Style="text-align: center; width: 55px" ToolTip="Per hrs salary=(SALARY/24.33/8)"
                                                                ReadOnly="true" runat="server" Text='<%#Eval("hourly_sal")%>'></asp:TextBox>
                                                            <%--  <asp:HiddenField ID="hdnId" runat="server"  Value='<%#Eval("WorkerType_ID") %>' /></div>--%>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OT.1" HeaderStyle-Font-Bold="false" HeaderStyle-Width="40PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_OT1" Text='<%#Eval("OT1")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_OT1" Style="text-align: center; width: 90%" MaxLength="5" runat="server" onpaste="return false;"
                                                                CssClass=".OT1css" Text='<%#Eval("OT1")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OT.2" HeaderStyle-Font-Bold="false" HeaderStyle-Width="40PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_OT2" Text='<%#Eval("OT2")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_OT2" Style="text-align: center; width: 90%" MaxLength="5" runat="server" onpaste="return false;"
                                                                CssClass=".OT2css" Text='<%#Eval("OT2")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OT.3" HeaderStyle-Font-Bold="false" HeaderStyle-Width="40PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_OT3" Text='<%#Eval("OT3")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_OT3" MaxLength="5" Style="text-align: center; width: 90%" runat="server" onpaste="return false;"
                                                                CssClass=".OT3css" Text='<%#Eval("OT3")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OT.4" HeaderStyle-Font-Bold="false" HeaderStyle-Width="40PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_OT4" Text='<%#Eval("OT4")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_OT4" MaxLength="5" Style="text-align: center; width: 90%" runat="server" onpaste="return false;"
                                                                CssClass=".OT4css" Text='<%#Eval("OT4")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permanent" Visible="false" HeaderStyle-Font-Bold="false" HeaderStyle-Width="80PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_staff" Text='<%#Eval("IsFactoryStaff") %>'></asp:Label>
                                                            <%-- <asp:HiddenField ID="hdn_Part_Of_MMR" runat="server"  Value='<%#Eval("OBbased") %>' />--%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:RadioButton ID="rdo_isstaff1" Text="Yes" Checked="false" runat="server" GroupName="m2" />
                                                            <asp:RadioButton ID="rdo_isstaff2"  Text="No" Checked="true" runat="server" GroupName="m2" />
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Part Of Machine Count" HeaderStyle-Font-Bold="false"
                                                        HeaderStyle-Width="80PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_MachineCount" Text='<%#Eval("PartOfMachineCount") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdn_Machine_count" runat="server" Value='<%#Eval("PartOfMachineCount") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:RadioButton ID="rdo_machine_count1" Checked="false" Text="YES" runat="server"
                                                                GroupName="m1" />
                                                            <asp:RadioButton ID="rdo_machine_count2" Text="NO" Checked="false" runat="server"
                                                                GroupName="m1" />
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <HeaderStyle Font-Bold="False" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OB based" HeaderStyle-Font-Bold="false" HeaderStyle-Width="170PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_obsed" Text='<%#Eval("OBbased") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdn_Part_Of_MMR" runat="server" Value='<%#Eval("OBbased") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div style="padding-left: 10px;">
                                                                <asp:RadioButton ID="rdo_obased1" Text="OB Based" Checked="false" runat="server"
                                                                    GroupName="m3" />
                                                                <asp:RadioButton ID="rdo_obased2" Text="Non OB based" Checked="false" runat="server"
                                                                    GroupName="m3" />
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="170px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Font-Bold="false" HeaderStyle-Width="130PX">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbl_Discription" Text='<%#Eval("Discription")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txt_discription" MaxLength="50" runat="server" Style="width: 90%;" onkeydown="return BlockingHtml(this,event);"
                                                                Text='<%#Eval("Discription")%>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="130px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Font-Bold="false" HeaderStyle-Width="60PX">
                                                        <ItemTemplate>
                                                            <div style="text-align: center; text-transform: capitalize;">
                                                                <asp:LinkButton ID="lnkEdit" ForeColor="blue" runat="server" CommandName="Edit"><img src="../../images/edit2.png" /></asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div style="text-align: center; text-transform: capitalize;">
                                                                <asp:LinkButton ID="lnkUpdate" ForeColor="blue" runat="server" OnClientClick="javascript:return gridValidate();"
                                                                    CommandName="Update"><img src="../../images/update.jpg" /></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkCancel" ForeColor="blue" runat="server" CommandName="Cancel"><img src="../../images/del-butt.png" /></asp:LinkButton>
                                                            </div>
                                                        </EditItemTemplate>
                                                        <HeaderStyle Font-Bold="False" Width="60px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="border2" Font-Size="13px" HorizontalAlign="Center" />
                                            </asp:GridView>
                                           
                                            <!--end-->
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnsubmit" EventName="Click" />
                                <%-- <asp:AsyncPostBackTrigger ControlID="grdCurrency"  EventName="RowUpdating"/>--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
