<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintForm.ascx.cs" Inherits="iKandi.Web.PrintForm" %>
<asp:Panel runat="server" ID="pnlForm">

   <style type="text/css">
   .td-sub_headings td
   {
       padding:5px 0px 5px 5px;
   }
   /*updated css by bharat 2 jan 19*/
   .item_list td 
   {
       border:1px solid #999999 !important;
   }
    .item_list th
   {
      padding-left:3px !important
   }
    .item_list td input
   {
      width:98% !important;
   }
     .item_list td input[type="submit"]
   {
      width:21% !important;
   }
   td input[type="text"]
   {
       padding-left:3px !important;
    }
     .print_number_box.containersize
     {
            width: 240px !important;
            border: 5px solid #999 !important;
            border-color: #999;
            padding: 0px;
            border-radius: 5px;
            position: absolute;
            z-index: 10000;
            top: 50%;
            left: 40%;
            background: #fff;
            display: none;
     }
     .header-text-back {
        background-color: #405D99;
        color: #FFFFFF;
        padding: 5px 0px;
        font-size: large;
        border-radius: 5px 5px 0px 0px;
        margin: 0px;
        text-align: center;
        text-transform: capitalize;
    }
   
   </style>
    <script type="text/javascript">

        $(function () {
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });

            $(document).keydown(function (e) {
                return (e.which || e.keyCode) != 116;
            });

            
        });
        
  
    </script>
    
    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        var jscriptPageVariables = null;
        var txtPrintNumberClientID = '<%=txtPrintNumber.ClientID %>';
        var txtPrintNumber2ClientID = '<%=txtPrintNumber2.ClientID %>';
        var btnSaveAsClientID = '<%= btnSaveAs.ClientID %>';
        var txtPrintNoClientID = '<%=txtPrintNo.ClientID %>';
        var hdnPrintIDClientID = '<%=hdnPrintID.ClientID %>';
        var txtPrintNo = $('input[type=text].fabric-type');
        var lblPrintDescClientID = '<%=lblPrintDesc.ClientID %>';
        var hdndeptid = '<%=hdndeptid.ClientID %>';
        var hdnsubdept = '<%=hdnsubdept.ClientID %>';
        var DdlParentDp = '<%=ddlDepNameParent.ClientID %>';
        var ddlClient = '<%=ddlClient.ClientID %>';
        var ddlDeptNameSelect = '<%=ddlDeptNameSelect.ClientID %>';
        var txtPrintRefnumberClientId = '<%=txtPrintRefnumber.ClientID %>';
             
        $(function () {
            $("input.print-company", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestPrintCompany", { dataType: "xml", datakey: "string", max: 100 });
            $("input.print-company-ref", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestSuggestPrintCompanyRef", { dataType: "xml", datakey: "string", max: 100 });
            $("input.fabric-quality", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestFabricQuality", { dataType: "xml", datakey: "string", max: 100 });
            $("#" + txtPrintNoClientID).autocomplete("/Webservices/iKandiService.asmx/SuggestAllPrintNumbers", { dataType: "xml", datakey: "string", max: 100 });

            $('#' + lblPrintDescClientID).html($("#" + txtPrintNumberClientID).val() + " " + $("#" + txtPrintNumber2ClientID).val());

            $("#" + txtPrintNoClientID).result(function () {
                var p = $(this).val().split('(');
                $(this).val(p[0]);
            });

            $("#" + txtPrintNumber2ClientID).change(function () {

                var obj = $(this)[0];

                if (obj.defaultValue != $(this).val()) {
                    var printNumber = $("#" + txtPrintNumberClientID, '#main_content').val() + " " + $("#" + txtPrintNumber2ClientID, '#main_content').val();
                    onPrintNumberChange(printNumber);
                }
                else if (obj.defaultValue == $(this).val()) {
                    $("#" + btnSaveAsClientID, '#main_content').hide();
                }
                $('#' + lblPrintDescClientID).html($("#" + txtPrintNumberClientID).val() + " " + $("#" + txtPrintNumber2ClientID).val());
            });


           
        });


        function onPrintNumberChange(printNumber) {
            proxy.invoke("GetPrintDetailByPrintNumber", { PrintNumber: printNumber },
        function (result) {
            var printid;

            if (result != null)
                printid = result.PrintID;


            if (printid != null && parseInt(printid) > 0) {
                window.location = "/Internal/Design/PrintEdit.aspx?printid=" + printid;
                return;
            }

            if (($("#" + hdnPrintIDClientID, '#main_content').val()) == "-1")
                $("#" + btnSaveAsClientID, '#main_content').hide();
            else
                $("#" + btnSaveAsClientID, '#main_content').show();

            $('#' + lblPrintDescClientID).html($("#" + txtPrintNumberClientID).val() + " " + $("#" + txtPrintNumber2ClientID).val());

        });
        }

        function ValidateDep() {

            if (($("#" + DdlParentDp, '#main_content').val()) == "Select") {
                jQuery.facebox("Select Parent Dep.");
                return false;
            }
            if (($("#" + ddlDeptNameSelect, '#main_content').val()) == "Select") {
                jQuery.facebox("Select Sub Dep.");
                return false;
            }
        }
        function SearchPrintNumber() {
            var printNumber = $.trim($("#" + txtPrintNoClientID).val());

            proxy.invoke("GetPrintDetailByPrintNumber", { PrintNumber: printNumber },
        function (result) {
            var printid;

            if (result != null)
                printid = result.PrintID;

            if (printid != null && parseInt(printid) > 0)
                window.location = "/Internal/Design/PrintEdit.aspx?printid=" + printid;
            else
                jQuery.facebox('Print Number is invalid!');
            $('#' + lblPrintDescClientID).html($("#" + txtPrintNumberClientID).val() + " " + $("#" + txtPrintNumber2ClientID).val());

        });
    }

    function BindPrintParentDept(SelectedClientID) {        
        bindDropdown(serviceUrl, "ctl00_cph_main_content_PrintForm1_ddlDepNameParent", "Get_ClientDeptsParent", { ClientId: SelectedClientID, type: 'Parent', ParentDeptID: '-1' }, "DeptName", "ClientDeptid", true, '', onPageError);
        BindPrintSubDept(SelectedClientID);
    }

    function BindPrintSubDept(SelectedClientID) {
        //debugger;
        $("#" + hdnsubdept, '#main_content').val(SelectedClientID);
        var ClientID = $("#" + ddlClient, '#main_content').val();
        var ParentID = $("#" + DdlParentDp, '#main_content').val();
        if (ParentID == 'Select' || ParentID == '') {
            ParentID = -1; 
        }
        bindDropdown(serviceUrl, "ctl00_cph_main_content_PrintForm1_ddlDeptNameSelect", "Get_ClientDeptsParent", { ClientId: ClientID, type: 'SubParent', ParentDeptID: ParentID }, "DeptName", "ClientDeptid", true, '', onPageError);
    }
        function setvalue(val) {
//            debugger;
//            alert(val);
//            $("#" + hdndeptid, '#main_content').val(hdndeptid);
        }
        function getval(sel) {
            $("#" + hdndeptid, '#main_content').val(sel.value);
        }
        
        function CheckPrintAlreadyExists(elem, SrNo) {
            //debugger;           
            var version = $(elem).val();
            var PrintNo = '';
            if (SrNo == 1)
                PrintNo = $("#" + txtPrintNumberClientID, "#main_content").val();
            else
                PrintNo = $("#" + txtPrintRefnumberClientId, "#main_content").val();

            var PrintNumber = $.trim(PrintNo + " " + version);

            proxy.invoke("CheckPrintAlreadyExists", { PrintNumber: PrintNumber, printId: 0 },

        function (result) {
           // alert(result)
            if (result == 'EXISTS') {
                jQuery.facebox("Print no. already exists, Please refresh page and fill again!");
                elem.value = elem.defaultValue;
                return false;
            }
        });
    }

    function ShowPrintNumberBox() {
        //debugger;       
        var PrintNumber = $("#" + txtPrintNumberClientID, "#main_content").val();

        $("#" + txtPrintRefnumberClientId, "#main_content").val(PrintNumber);
        $('.print_number_box').show();
        return false;       
       
    }

    function HidePrintNumberBox() {
        //debugger;       
        $('.print_number_box').hide();
        
    }

    function ValidateVersion() {
        //debugger;
        if ($("#" + '<%=txtPrintVersion.ClientID%>').val() == '') {
            jQuery.facebox("Please fill version!");
            $("#" + '<%=txtPrintVersion.ClientID%>').focus();       
            return false;
        }
    }
    

    </script>
  

       <asp:HiddenField ID="hdndeptid" Value="-1" runat="server" />
       <asp:HiddenField ID="hdnsubdept" Value="-1" runat="server" />
        
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="header-text-back" style="margin-bottom:5px;">
                    <tr>
                        <td width="938" style="text-align:left;padding-left:5px;">
                            <span class="da_h1">Print Purchase Form</span><span class="da_required_field">(<span
                                class="da_astrx_mand">*</span>Please fill all required fields)</span>
                        </td>
                        <td width="274">
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td width="37%" style="font-size: 12px">
                                        Search Print No.
                                    </td>
                                    <td width="49%">
                                        <asp:TextBox runat="server" ID="txtPrintNo" CssClass="do-not-disable input_in"></asp:TextBox>
                                        <asp:HiddenField runat="server" Value="-1" ID="hdnPrintID" />
                                    </td>
                                    <td width="14%">
                                        <asp:Button ID="btnSearchPrintNo" runat="server" Text="Search" class="do-not-disable go da_go_button"
                                            OnClientClick="SearchPrintNumber();return false;" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
          
   
                <div id="tabs" class="ResetDiv">
                    <ul class="tabs">
                        <asp:Repeater ID="rptTab" runat="server" OnItemDataBound="rptTab_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink NavigateUrl='<%# "/Internal/Design/PrintEdit.aspx?printid="+Eval("PrintID") %>'
                                        ID="hlkPrint" runat="server" Text='<%# Eval("PrintNumber")%>'></asp:HyperLink></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>   
    
                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                    <tr class="td-sub_headings">
                                    <td valign="bottom" style="width: 14.66%">
                                        Print Number<span class="da_astrx_mand">*</span>
                                    </td>
                                    <td valign="bottom" style="width: 12.66%">
                                        Print Type<span class="da_astrx_mand">*</span>
                                    </td>
                                      <td valign="bottom" style="width: 11.66%">
                                        Print Category<span class="da_astrx_mand">*</span>
                                    </td>
                                    <td valign="bottom" style="width: 14.66%">
                                        Buyer<span class="da_astrx_mand">*</span>
                                    </td>
                                    <td valign="bottom" style="width: 10.66%">
                                       Par. Department 
                                    </td>
                                    <td valign="bottom" style="width: 15.66%">
                                        Sub. Department 
                                    </td>
                                    <td valign="bottom" style="width: 10.66%">
                                        Designer<span class="da_astrx_mand">*</span>
                                    </td>
                                     <td valign="bottom"  style="width: 17.66%">
                                        Print Description<span class="da_astrx_mand">*</span>
                                    </td>
                                </tr>
                                  <tr style="width: 100%">
                                    <td style="width:200px" class="inner_tbl_td">
                                    
                                            <asp:Label ID="Label1" runat="server" Text="PRD"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtPrintNumber" Width="50px" ReadOnly="True" CssClass="numeric-field-without-decimal-places print_align_left printno"
                                                MaxLength="6"></asp:TextBox>-
                                                <asp:TextBox runat="server" onchange="javascript:return CheckPrintAlreadyExists(this, 1);" ID="txtPrintNumber2" MaxLength="1"
                                                    CssClass="printno" Width="45px"></asp:TextBox>
                                            <div class="form_error da_error_msg">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                    ControlToValidate="ddlPrintType" ErrorMessage="Print Number is reqd."></asp:RequiredFieldValidator></div>
                                               
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:DropDownList ID="ddlPrintType" runat="server" Width="95%" CssClass="input_in">
                                            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                ControlToValidate="ddlPrintType" InitialValue="-1" ErrorMessage="Select Print Type"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                       <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlPrintCategory" 
                                                    runat="server" Width="95%" CssClass="input_in">
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                          </td>
                                            <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlClient" onchange="javascript:BindPrintParentDept(this.value);"
                                                    runat="server" Width="95%" CssClass="input_in">
                                                    <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                                <div class="form_error da_error_msg">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                        ControlToValidate="ddlClient" InitialValue="-1" ErrorMessage="Select Buyer"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                             <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlDepNameParent" onchange="javascript:BindPrintSubDept(this.value);" runat="server" Width="99%" CssClass="input_in">
                                                </asp:DropDownList>                                        
                                            </td>
                                            <td class="inner_tbl_td">
                                                <asp:DropDownList ID="ddlDeptNameSelect" onchange="getval(this);" runat="server" Width="95%" CssClass="input_in">
                                                </asp:DropDownList>                                    
                                            </td>
                                           
                                      
                                    <td class="inner_tbl_td">
                                        <asp:DropDownList ID="ddlDesigner" runat="server" Width="95%" CssClass="input_in">
                                            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                ControlToValidate="ddlDesigner" InitialValue="-1" ErrorMessage="Select Designer"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                       <td class="inner_tbl_td">
                                        <asp:Label ID="lblPrintDesc" runat="server" Text=""></asp:Label><asp:TextBox Width="50%"
                                            runat="server" ID="txtPrintRefNo" CssClass="print_align_left input_in" MaxLength="20"></asp:TextBox>
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                ControlToValidate="txtPrintRefNo" ErrorMessage="Print Description is reqd."></asp:RequiredFieldValidator></div>
                                    </td>
                                </tr>




                                <tr class="td-sub_headings">
                              
                                    <td valign="bottom">
                                        Print Company
                                    </td>
                                    <td valign="bottom">
                                        Print Company Reference
                                    </td>
                                    <td valign="bottom">
                                        Print Cost<span class="da_astrx_mand">*</span>
                                    </td>
                                   <td>
                                        Date Purchased<span class="da_astrx_mand">*</span>
                                    </td>
                                   <td>
                                        Fabric Quality
                                    </td>
                                        <td colspan="3">
                                        Description
                                    </td>
                                   
                             
                                </tr>

                                <tr>
                                
                                    <td class="inner_tbl_td">
                                        <asp:TextBox Width="98%" runat="server" ID="txtPrintCompany" CssClass="print-company print_align_left input_in"
                                            MaxLength="45"></asp:TextBox>
                                    </td>
                                    <td class="inner_tbl_td">
                                        <asp:TextBox runat="server" ID="txtPrintCompanyReference" CssClass="print-company-ref print_align_left input_in"
                                            MaxLength="45" Width="95%"></asp:TextBox>
                                    </td>
                                    <td class="inner_tbl_td">
                                        <nobr>
                                        <asp:DropDownList ID="ddlCurrency" CssClass="input_in" runat="server" Width="70px">
                                            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox runat="server" ID="txtPrintCost" CssClass="numeric-field-with-two-decimal-places print_align_left"
                                            MaxLength="10" Width="45%"></asp:TextBox>
                                            </nobr>
                                        <div class="form_error da_error_msg">
                                            <asp:RequiredFieldValidator ID="rfv_txtPrintCost" runat="server" Display="Dynamic"
                                                ControlToValidate="txtPrintCost" ErrorMessage="Print Cost is required"></asp:RequiredFieldValidator>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfv_ddlCurrency" runat="server" Display="Dynamic"
                                                ControlToValidate="ddlCurrency" InitialValue="-1" ErrorMessage="Select currency"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                 <td valign="top" class="inner_tbl_td">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="th date_style print_align_left input_in"></asp:TextBox>
                                    </td>
                                       <td valign="top" class="inner_tbl_td">
                                        <asp:TextBox runat="server" ID="txtFabricQuality" CssClass="fabric-quality print_align_left input_in"
                                            MaxLength="100"></asp:TextBox>
                                    </td>
                                <td style="text-align:center; vertical-align:top;" class="inner_tbl_td" colspan="3">
                                 <asp:TextBox runat="server" ID="txtDesc" CssClass="print_align_left input_in" Style="text-align: left !important;"
                                            TextMode="MultiLine" Width="95%" Height="36px"></asp:TextBox>
                                </td>
                                  
                                </tr>

                                 <tr class="td-sub_headings">                                  
                                   
                                    <td>
                                        Original Photo
                                    </td>
                                    <td>
                                        Developed Photo
                                    </td>
                                     <td colspan="2">
                                        Testing Section
                                    </td>
                                 </tr>

                                 <tr>                                   
                                 
                                    <td valign="top" class="inner_tbl_td">
                                        <asp:FileUpload runat="server" ID="filePhoto" CssClass="input_in" Style="background: #fff;" />
                                        <div style="text-align:center;">
                                            <asp:Image runat="server" ID="imgPhoto"  style="max-height:100px;" Visible="false" />
                                            <asp:HiddenField runat="server" ID="hdnImagePath" />
                                        </div>
                                    </td>
                                    <td valign="top" class="inner_tbl_td">
                                        <asp:FileUpload runat="server" ID="uploaddevelopedimage" CssClass="input_in" Style="background: #fff;" />
                                        <div style="text-align:center;">
                                            <asp:Image runat="server" ID="imgdeveloped" style="max-height:100px;" Visible="false" />
                                            <asp:HiddenField runat="server" ID="hdndevelopedimage" />
                                        </div>
                                    </td>
                                 <td runat="server" id="tdTesting" colspan="2" style="vertical-align:top;">
                                        <asp:Panel ID="pnlHistory" runat="server">
                                            <asp:GridView ID="grdHistory" runat="server" OnRowDataBound="grdHistory_RowDataBound"
                                                AutoGenerateColumns="false" Width="100%" CssClass="item_list fixed-header">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Testing Dt." ItemStyle-CssClass="date_style" HeaderStyle-Width="130px"
                                                        ItemStyle-Width="130px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTestingDate" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="File" HeaderStyle-Width="40px" ItemStyle-Width="40px">
                                                        <ItemTemplate>
                                                            <asp:HyperLink runat="server" ID="hypPDF" Target="_blank"></asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="65px" ItemStyle-Width="65px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComments" runat="server" Font-Size="8px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlTesting">
                                            <table width="100%" style="vertical-align: top !important;" class="item_list">
                                                <tr>
                                                    <th style="text-align: left !important">
                                                        Testing Date
                                                    </th>
                                                    <td style="text-align: left !important">
                                                        <asp:TextBox ID="txtTestingDate" runat="server" CssClass="th date_style"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th style="text-align: left !important">
                                                        File
                                                    </th>
                                                    <td style="text-align: left !important">
                                                        <asp:FileUpload ID="filePDF" runat="server" accept="pdf" />
                                                        <asp:HiddenField runat="server" ID="hdnFilePath" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th style="text-align: left !important">
                                                        Status
                                                    </th>
                                                    <td style="text-align: left !important">
                                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                                            <asp:ListItem Value="1" Text="Pass" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Fail"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th style="text-align: left !important">
                                                        Comments
                                                    </th>
                                                    <td style="text-align: left !important">
                                                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="98%" Height="30px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: left !important">
                                                        <asp:Button ID="btnTesing" style="display:none;" runat="server" CssClass="submit da_submit_button" Text="Submit"
                                                            OnClick="btnTesing_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                 </tr>
                    </table>

                       
    <br />
    <div class="form_buttom do-not-print">
        <asp:Button ID="btnSubmit" style="display:none;" runat="server" OnClick="btnSubmit_Click" OnClientClick="javascript:return ValidateDep();" class="submit da_submit_button" Text="Submit" />
        

         <asp:Button ID="btnCreateVersion" style="display:none;" runat="server" class="submit da_submit_button" OnClientClick="javascript:return ShowPrintNumberBox()" Text="Create version" />

        <asp:Button runat="server" ID="btnSaveAs" style="display:none;" CssClass="saveAs hide_me" />
        <input type="button" id="btnPrint" value="Print" class="da_submit_button" onclick="return PrintPDF();" />
    </div>
     <div class="print_number_box containersize">
                    <table width="100%" cellpadding="6px" cellspacing="0">
                     <tr>
                            <td align="right" colspan="2" style="width:100%;padding:6px 0px;background:#39589c">
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Print Number:
                            </td>
                            <td >
                                PRD
                                <asp:TextBox runat="server" ID="txtPrintRefnumber" Width="50px" CssClass="print_align_left printno"
                                    MaxLength="6"></asp:TextBox>-
                                    <asp:TextBox runat="server" onchange="javascript:return CheckPrintAlreadyExists(this, 2);" ID="txtPrintVersion" MaxLength="1"
                                        CssClass="printno" Width="45px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">                                
                                <asp:Button ID="btnVersionSave" runat="server" CssClass="save da_submit_button" OnClientClick="javascript:return ValidateVersion()" OnClick="btnVersionSave_Click" Text="Save" />
                                <input type="button" class="cancel da_submit_button" value="Cancel" onclick="HidePrintNumberBox();" />
                            </td>
                        </tr>
                    </table>
                </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="10" class="da_table_heading_bg_left">
                &nbsp;
            </td>
            <td width="1205" class="da_table_heading_bg">
                <span class="da_h1">Confirmation</span>
            </td>
            <td width="13" class="da_table_heading_bg_right">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="form_box">
        <div class="text-content">
            Print have been saved into the system successfully!
            <br />
            <a id="A1" href="~/internal/Design/PrintListing.aspx" runat="server">Click here</a>
            to Prints List.</div>
    </div>
</asp:Panel>
