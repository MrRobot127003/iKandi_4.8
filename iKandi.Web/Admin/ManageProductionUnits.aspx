<%@ Page Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="ManageProductionUnits.aspx.cs" Inherits="iKandi.Web.Internal.Merchandising.ManageProductionUnits" %>

<%@ Register Src="../UserControls/Forms/FactorySpecificLineAdminControl.ascx" TagName="FactorySpecificLineAdminControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <link href="../css/technical-module.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .main_tbl_wrapper
        {
            table-layout: fixed;
        }
        input[type=text], textarea
        {
            width: 90%;
        }
        .da_header_heading th
        {
            padding: 8px 2px !important;
            font-weight: normal;
            font-size: 10px;
            background: #405D99;
            color: #fff;
            text-align:center;
        }
        .da_header_heading td
        {
          font-size: 10px;
          min-width:40px;
          padding:2px;
        }
        
        
        .padiing-left0
        {
            padding-left:0!important;
       }
       .bdr_color
       {
        border-right-color: #405D99!important;
        text-align: right!important;
           }
       .addicon
        {
         font-size: 22px;
         font-weight: 600;
         vertical-align: super;
         height:24px;
            } 
      .addicon:hover
        {
         font-size: 22px!important;
         font-weight: 600!important;
         height:24px;
           vertical-align: super;
        }  
     .printicon
     {
        background-image: url(../../images/icons-send-to-printer.png);
        background-position: center;
        width: 30px;
        height: 24px;
        background-repeat: no-repeat;
     }
   .printicon:hover
     {
        background-image: url(../../images/icons-send-to-printer.png);
        background-position: center;
        width: 30px;
        height: 24px;
        background-repeat: no-repeat;
         }    
            
            
        .form_box TD {
          font-size: 10px; 
          color:#545050;
        }
        .header-text-back {
            padding: 3px 0px;
            font-size: 16px;
            display: flex;
            text-align: center;
            width: 100%;
        }
        td[colspan="22"] table td
        {
            border:0px;
         }
        .CS
        {
            width: 80px;
        }
       td select
        {
            width:90%;
         }
        th
         {
             font-weight:500
          }
    </style>
    <script type="text/javascript">
        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        function DeleteProductionUnit(puid) {
            proxy.invoke("DeleteProductionUnit", { productionUnitId: puid },
        function (success) {
            if (success) {
                //debugger;               
                ShowHideMessageBox(true, 'Production Unit deleted successfully.', 'Production Unit', DoForcePostBack);
            }
            else {
                //debugger;
                ShowHideValidationBox(true, 'You can not delete this production unit.', 'Production Unit');
            }
        });
        }
        function GetCapicity(Val) {
            var linenumber = Val;
            var workingdays = '';
            var workinghourse = '';
            var cmt_workingdays = document.getElementById('<%= hdn_cmt_workingdays.ClientID%>');
            var cmt_workinghourse = document.getElementById('<%= hdn_cmt_workinghourse.ClientID%>');
            var capi = document.getElementById('<%= hdn_capicityval.ClientID%>');

            if (cmt_workingdays != null) {
                workingdays = cmt_workingdays.value;
            }
            if (cmt_workinghourse != null) {
                workinghourse = cmt_workinghourse.value;
            }
            var finalresults = linenumber * 26 * workinghourse * 60;

            var finalresult = ((finalresults) / 100000).toFixed(2);
            //        document.getElementById('<%=txtCapacity.ClientID%>').Value = finalresult;
            //document.getElementById("txtCapacity").value = finalresult;
            document.getElementById('<%=txtCapacity.ClientID%>').value = finalresult;
            document.getElementById('<%=hdn_capicityval.ClientID%>').value = finalresult;

        }
        function ValidateControl() {
            //debugger;
            if (Page_ClientValidate())

                if (document.getElementById('<%=txtProductionUnitCode.ClientID %>').value == "") {
                    ShowHideMessageBox(true, "Enter prodution unit code", "Manage production unit");
                    return false;
                }

            if (document.getElementById('<%=txtProductionUnitName.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter prodution unit name", "Manage production unit");
                return false;
            }
            if (document.getElementById('<%=txtNumberOfMachines.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter Number Of machines", "Manage production unit");
                return false;
            }

            if (document.getElementById('<%=txtNumberOfLines.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter Number Of Lines", "Manage production unit");
                return false;
            }

            if (document.getElementById('<%=txtNumberOfFloors.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter Number Of floors", "Manage production unit");
                return false;
            }



            if (document.getElementById('<%=txtAddress.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter Address ", "Manage production unit");
                return false;
            }

            var objDDl = document.getElementById('<%=ddlProductionUnitManager.ClientID%>');
            if (objDDl.options[objDDl.selectedIndex].value == "") {
                ShowHideMessageBox(true, "select Production unit Manager ", "Manage production unit");
                return false;
            }


           
            var objDDl = document.getElementById('<%=ddlclasfication.ClientID%>');
            if (objDDl.options[objDDl.selectedIndex].value == "-1") {
                ShowHideMessageBox(true, "Please select classification", "Manage production unit");
                return false;
            }


            if (document.getElementById('<%=txt_mothlyoverhead.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter monthly overhead ", "Manage production unit");
                return false;
            }
            if (document.getElementById('<%=txt_1.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter Cutting value ", "Manage production unit");
                return false;
            }
            if (document.getElementById('<%=txt_2.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter Stitching value ", "Manage production unit");
                return false;
            }
            if (document.getElementById('<%=txt_3.ClientID %>').value == "") {
                ShowHideMessageBox(true, "Enter Finishing value ", "Manage production unit");
                return false;
            }


            //            var ddlfinshingsup = document.getElementById('<%=ddlfinishingSupervisor.ClientID%>');
            //            if (ddlfinshingsup.options[ddlfinshingsup.selectedIndex].value == "-1") {
            //                alert("Please select Finishing Supervisor");
            //                return false;
            //            }
            //            var ddlfinshingcharge = document.getElementById('<%=ddlFinishingIncharge.ClientID%>');
            //            if (ddlfinshingcharge.options[ddlfinshingcharge.selectedIndex].value == "-1") {
            //                alert("Please select Finishing In charge");
            //                return false;
            //            }
            //            var ddlfinshingqa = document.getElementById('<%=ddlfinishingqa.ClientID%>');
            //            if (ddlfinshingqa.options[ddlfinshingqa.selectedIndex].value == "-1") {
            //                alert("Please select Finishing QA");
            //                return false;
            //            }

            else {

                return true;
            }
        }


        function onlyNos(e, t) {

            try {

                if (window.event) {

                    var charCode = window.event.keyCode;

                }

                else if (e) {

                    var charCode = e.which;

                }

                else { return true; }

                if (charCode > 31 && (charCode < 48 || charCode > 57)) {

                    return false;

                }

                return true;

            }

            catch (err) {

                alert(err.Description);

            }

        }

        function validate(email) {
            //alert();
            if (email.value == "") {
            } else {
                var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
                if (reg.test(email.value) == false) {
                    alert('Invalid Email Address');
                    return false;
                }
            }

            return true;
        }
    
    </script>
  
    <asp:ScriptManager ID="scriptajax" runat="server">
    </asp:ScriptManager>
    <div class="print-box">
        <div class="header-text-back">
           
             <div style="width: 50%;text-align: left;margin-left: 20px;">
                 <span>
                    <asp:TextBox ID="txtSearchKeyWords" runat="server" Style="height: 15px;width:25%" placeholder="Search Production Units"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" 
                    Style="cursor: pointer;background: #13a747 none repeat scroll 0 0 !important;color: #fff;height: 20px;border-radius:2px;border:0;" />
                 </span>
            </div>
            <span> Manage Production Units</span>
            
        </div>
       
        
        <div class="form_box" style="border:0;">
            <asp:HiddenField ID="hdn_cmt_workingdays" runat="server" />
            <asp:HiddenField ID="hdn_cmt_workinghourse" runat="server" />
            <asp:HiddenField ID="hdn_capicityval" runat="server" />
            <asp:HiddenField ID="hdn_finshingcheck" runat="server" Value="0" />
            <asp:HiddenField ID="hdn_cuttingcheck" runat="server" Value="0" />
            <table id="tblProductionUnitDetails" runat="server" visible="false" width="100%"
                border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table width="99%" border="0" align="center" cellspacing="6" cellpadding="0" class="main_tbl_wrapper">
                                    <tr class="td-sub_headings">
                                        <td width="9%" valign="bottom">
                                            Production Unit Code
                                        </td>
                                        <td width="9%" valign="bottom">
                                            Production Unit Name
                                        </td>
                                        <td width="7%" valign="bottom">
                                            No. of Machines
                                        </td>
                                        <td width="7%" valign="bottom">
                                            No. of Lines
                                        </td>
                                        <td width="9%" valign="bottom">
                                            No.of cluster
                                        </td>
                                        <td width="9%" valign="bottom">
                                            No. of Floors
                                        </td>
                                        <td width="9%" valign="bottom">
                                            Capacity(lkm)
                                            </td>
                                     
                                        <%--abhishek 18/8/2015--%>
                                        <td width="7%" valign="bottom">
                                            Finishing Active
                                        </td>
                                        <%--abhishek 14/9/2015--%>
                                        <td width="9%" valign="bottom">
                                            Finishing factory
                                        </td>
                                        <td width="7%" valign="bottom">
                                            Cutting Active
                                        </td>

                                        <td width="9%" valign="bottom">                                        
                                        Is VA Enabled
                                        </td>


                                        <td width="9%" valign="bottom">
                                            Cutting factory
                                        </td>
                                        <%--end abhishek 14/9/2015 --%>
                                        <%--END--%>
                                    </tr>
                                    <tr>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtProductionUnitCode" runat="server" MaxLength="20" CssClass="input_in"
                                                title="Please enter Product Unit Code"></asp:TextBox>
                                        </td>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtProductionUnitName" runat="server" MaxLength="50" CssClass="input_in"
                                                title="Please enter Product Unit Name"></asp:TextBox>
                                        </td>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtNumberOfMachines" MaxLength="5" onchange="GetCapicity(value)"
                                                runat="server" CssClass="numeric-field-without-decimal-places numeric_text input_in"></asp:TextBox>
                                        </td>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtNumberOfLines" runat="server" MaxLength="3" onkeypress="return onlyNos(event,this);"
                                                CssClass="numeric-field-without-decimal-places numeric_text input_in"></asp:TextBox>
                                        </td>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtcluster" runat="server" MaxLength="3" onkeypress="return onlyNos(event,this);"
                                                CssClass="numeric-field-without-decimal-places numeric_text input_in"></asp:TextBox>
                                        </td>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtNumberOfFloors" MaxLength="3" runat="server" onkeypress="return onlyNos(event,this);"
                                                CssClass="numeric-field-without-decimal-places numeric_text input_in"></asp:TextBox>
                                        </td>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtCapacity" ReadOnly="true" runat="server" CssClass="numeric-field-without-decimal-places numeric_text input_in"></asp:TextBox>
                                        </td>
                                        <%--<td class="color-picker" id="tdColorPicker" visible="false" runat="server">
                                    <asp:TextBox ID="txtColorPickerValue" visible="false" runat="server" CssClass="color-picker hide_me input_in"></asp:TextBox>
                                </td>--%>
                                        <td id="td1" runat="server" class="inner_tbl_td">
                                            <asp:CheckBox ID="chk_finishing_act" Text="" runat="server" AutoPostBack="true" OnCheckedChanged="chk_finishing_act_CheckedChanged"
                                                CssClass="chkfinshing_" />
                                        </td>
                                        <td id="tdfinshing" runat="server" class="inner_tbl_td">
                                            <asp:DropDownList ID="ddlfinishing" Enabled="false" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td id="td2" runat="server" class="inner_tbl_td">
                                            <asp:CheckBox ID="chk_cutting_act" Text="" runat="server" AutoPostBack="true" OnCheckedChanged="chk_cutting_act_CheckedChanged" />
                                        </td>
                                         <td  class="inner_tbl_td">
                                            <asp:CheckBox ID="ChkISVaEnabled" Text="" runat="server" AutoPostBack="true" />
                                            
                                        </td>

                                        <td id="tdcutting" runat="server" class="inner_tbl_td">
                                            <asp:DropDownList ID="ddlcutting" Enabled="false" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                    </table>
                                       <table width="99%" border="0" align="center" cellspacing="6" cellpadding="0" class="main_tbl_wrapper">
                                 
                                    <tr class="td-sub_headings">
                                        <td style="width:25%">
                                            Address
                                        </td>
                                        <td width="11%">
                                            Classification
                                        </td>
                                        <td width="17%">
                                            Factory Manager
                                        </td>
                                        <td width="9%">
                                            Cutting Share
                                        </td>
                                        <td width="9%">
                                            Stitching Share
                                        </td>
                                        <td width="9%">
                                            Finishing Share
                                        </td>
                                        <td width="11%">
                                            Client Association
                                        </td>
                                        <td width="5%">
                                            &nbsp;
                                        </td>
                                        <td  width="10%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="inner_tbl_td">
                                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="input_in"
                                                Height="50px" style="resize: vertical;"></asp:TextBox>
                                        </td>
                                        <td valign="top" class="inner_tbl_td" >
                                            

                                             <asp:DropDownList ID="ddlclasfication" runat="server" CssClass="input_in inhouse"
                                                AutoPostBack="true" title="Please select a classification" OnSelectedIndexChanged="ddlclasfication_SelectedIndexChanged">
                                                <%--<asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="In House" Selected="True" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Out House" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td valign="top" class="inner_tbl_td" style="display: none;">
                                            <asp:DropDownList ID="ddlFactoryHead" runat="server" CssClass="input_in" title="Please select a FactoryHead">
                                                <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td valign="top" class="inner_tbl_td">
                                           <asp:DropDownList ID="ddlProductionUnitManager" runat="server" CssClass="input_in"
                                                title="Please select a Production Unit Manager">
                                                <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td valign="top" class="inner_tbl_td">
                                            <asp:TextBox ID="txt_mothlyoverhead" runat="server" MaxLength="7" onpaste="return false;"
                                                onkeypress="return onlyNos(event,this);"></asp:TextBox>
                                        </td>
                                        <td valign="top" class="inner_tbl_td">
                                            
                                                        <asp:TextBox ID="txt_1" runat="server" MaxLength="3" onpaste="return false;" onkeypress="return onlyNos(event,this);"
                                                            Style="width: 75%"></asp:TextBox>
                                                    
                                                        %
                                                   
                                        </td>
                                        <td valign="top" class="inner_tbl_td">
                                           
                                                        <asp:TextBox ID="txt_2" runat="server" MaxLength="3" onpaste="return false;" onkeypress="return onlyNos(event,this);"
                                                            Style="width: 75%"></asp:TextBox>
                                                 
                                                        %
                                                   
                                        </td>
                                        <td valign="top" class="inner_tbl_td">
                                           
                                                        <asp:TextBox ID="txt_3" runat="server" MaxLength="3" onpaste="return false;" onkeypress="return onlyNos(event,this);"
                                                            Style="width: 75%"></asp:TextBox>
                                                   
                                                        %
                                                  
                                        </td>
                                        <td valign="top" class="inner_tbl_td" colspan="2">
                                            <asp:ListBox ID="Listclientname" ToolTip="Press (Shift+End/Home key for select all or go up & down)"
                                                runat="server" AppendDataBoundItems="true" Style="width: 150px" SelectionMode="Multiple"
                                                BackColor="Beige">
                                                <asp:ListItem Selected="True" style="color: Maroon; text-decoration: line-through;"
                                                    Value="0">None</asp:ListItem>
                                            </asp:ListBox>
                                            <span style="font-size: 8px;display: block;margin-top: 5px;">(Shift+End/Home key for all)</span>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                      
                                       
                                    </tr>
                                   
                                    <%--   added on 24/8/2015--%>
                                    <tr class="td-sub_headings" style="display: none;">
                                        <td>
                                            Factory(IE)
                                        </td>
                                        <td>
                                            Writer(IE)
                                        </td>
                                        <td>
                                            <asp:Label ID="lblupload" runat="server" Visible="false" Text="Upload picture"></asp:Label>
                                        </td>
                                        <td>
                                            Finishing Supervisor
                                        </td>
                                        <td>
                                            Finishing In charge
                                        </td>
                                        <td>
                                            Finishing QA
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td valign="top" style="vertical-align: top;" class="inner_tbl_td">
                                            <asp:ListBox ID="listFactoryIE" runat="server" Style="width: 150px" SelectionMode="multiple"
                                                BackColor="Beige" />
                                        </td>
                                        <td valign="top" style="vertical-align: top;" class="inner_tbl_td">
                                            <asp:ListBox ID="listwirterIE" runat="server" Style="width: 150px" SelectionMode="multiple"
                                                BackColor="Beige" />
                                        </td>
                                        <td class="inner_tbl_td" rowspan="4">
                                            <table cellpadding="0" cellspacing="0" width="280px" style="border: 1px solid #666;
                                                margin-bottom: 3px; padding: 5px; table-layout: fixed;">
                                                <tr>
                                                    <td width="30px">
                                                    </td>
                                                    <td width="220px">
                                                    </td>
                                                    <td width="16px">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="0" cellspacing="0" width="280px" style="border: 1px solid #666;
                                                margin-bottom: 3px; padding: 5px; table-layout: fixed;">
                                                <tr>
                                                    <td width="30px">
                                                    </td>
                                                    <td width="220px">
                                                    </td>
                                                    <td width="16px">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="0" cellspacing="0" width="280px" style="border: 1px solid #666;
                                                margin-bottom: 3px; padding: 5px; table-layout: fixed;">
                                                <tr>
                                                    <td width="30px">
                                                    </td>
                                                    <td width="220px">
                                                    </td>
                                                    <td width="16px">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="0" cellspacing="0" width="280px" style="border: 1px solid #666;
                                                padding: 5px; table-layout: fixed;">
                                                <tr>
                                                    <td width="30px">
                                                    </td>
                                                    <td width="220px">
                                                    </td>
                                                    <td width="16px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="inner_tbl_td" valign="top">
                                            <asp:DropDownList ID="ddlfinishingSupervisor" runat="server" CssClass="input_in"
                                                Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="inner_tbl_td" valign="top">
                                            <asp:DropDownList ID="ddlFinishingIncharge" runat="server" CssClass="input_in" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="inner_tbl_td" valign="top">
                                            <asp:DropDownList ID="ddlfinishingqa" runat="server" CssClass="input_in" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            <div id="divUpload" class="uploaddoc" runat="server" visible="false">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="td-sub_headings">
                                                            File 1
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="upload_1" runat="server" CssClass="CS" />
                                                            <asp:HiddenField ID="hdnupload1" runat="server" Value="" />
                                                            <asp:HyperLink ID="hlkViewSnap1" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" style="vertical-align: middle;" /> </asp:HyperLink>
                                                        </td>
                                                        <td class="td-sub_headings">
                                                            File 2
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="upload_2" runat="server" CssClass="CS" />
                                                            <asp:HiddenField ID="hdnupload2" runat="server" Value="" />
                                                            <asp:HyperLink ID="hlkViewSnap2" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" style="vertical-align: middle;" /> </asp:HyperLink>
                                                        </td>
                                                        <td class="td-sub_headings">
                                                            File 3
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="upload_3" runat="server" CssClass="CS" />
                                                            <asp:HiddenField ID="hdnupload3" runat="server" Value="" />
                                                            <asp:HyperLink ID="hlkViewSnap3" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png " style="vertical-align: middle;" /> </asp:HyperLink>
                                                        </td>
                                                        <td class="td-sub_headings">
                                                            Audit file 4
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="upload_4" runat="server" CssClass="CS" />
                                                            <asp:HiddenField ID="hdnupload4" runat="server" Value="" />
                                                            <asp:HyperLink ID="hlkViewSnap4" runat="server" Visible="false" Target="_blank"> <img src="../../images/view-icon.png" style="vertical-align: middle;"/> </asp:HyperLink>
                                                          <asp:Button ID="btn_upload" runat="server" Text="Upload" CssClass="da_submit_button" style="Float:right;margin-right: 10px;" OnClick="btn_upload_Click" />
                                                        </td>
                                                        <td>
                                                         <%--Edit By Prabhaker 15-mar-18--%>
                                                         <span>Email Id</span>
                                                          <asp:TextBox ID="txtemail" runat="server" onblur="validate(this)" style="width:40%"></asp:TextBox>
                                                          
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            <asp:Repeater ID="rptuser" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                                <ItemTemplate>
                                                    <div style="width: auto; display: inline-block; margin-right: 15px;">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr class="td-sub_headings">
                                                                <td>
                                                                    <asp:Label ID="lbldesignation" Text='<%# Bind("name") %>' runat="server"></asp:Label>
                                                                    <asp:HiddenField ID="hdndesignation" runat="server" Value='<%# Bind("id") %>' />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="inner_tbl_td">
                                                                    <asp:DropDownList ID="ddldesignation" runat="server" Width="150px" CssClass="input_in">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                ControlToValidate="ddldesignation" Font-Size="Smaller" InitialValue="-1" ValidationGroup="update"
                                                                ErrorMessage="Please select user first."></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <%-- end 24/8/2015--%>
                                    <tr>
                                        <td height="25" colspan="12">
                                            <asp:Button ID="btnSave" runat="server"
                                                OnClick="btnSave_Click" Text="Save" CssClass="da_submit_button" />
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                                CssClass="da_submit_button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" style="height: 30px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" style="height: 30px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_upload" />
                                <asp:PostBackTrigger ControlID="btnSave" />
                                <asp:PostBackTrigger ControlID="btnCancel" />
                               <%-- <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table visible="false" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:PlaceHolder ID="placeZHolder1" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
               
            </table>
            <table id="tblProductionUnits" runat="server" width="100%" border="0" cellpadding="0"
                cellspacing="0">
                <tr>
                    
                    <td>
                        <asp:GridView ID="gridProductionUnits" runat="server" AutoGenerateColumns="False"
                            CssClass="da_header_heading" Width="100%" AllowPaging="True" OnPageIndexChanging="gridProductionUnits_PageIndexChanging"
                            OnRowEditing="gridProductionUnits_RowEditing" OnRowDeleting="gridProductionUnits_RowDeleting"
                            OnRowDataBound="gridProductionUnits_RowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="Production Unit Code" DataField="FactoryCode" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Production Unit Name" DataField="FactoryName" ItemStyle-Width="8%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-Width="8%" ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="8%"></ItemStyle>
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="Email ID" DataField="EmailId" ItemStyle-Width="7%" ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="7%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="No. Of Floors" DataField="NumberOfFloors" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numeric_text da_table_tr_bg">
                                    <ItemStyle Width="5%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="No. Of Lines" DataField="NumberOfLines" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numeric_text da_table_tr_bg">
                                    <ItemStyle Width="5%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="No. Of Machines" DataField="NumberOfMachines" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numeric_text da_table_tr_bg">
                                    <ItemStyle Width="5%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Capacity (lk)" DataField="Capacity" ItemStyle-Width="8%"
                                    ItemStyle-CssClass="numeric_text da_table_tr_bg">
                                    <ItemStyle Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Factory Manager" DataField="ProductionUnitManagerName"
                                    ItemStyle-Width="8%" ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Factory Head" Visible="false" DataField="QAFactoryHeadName" ItemStyle-Width="4%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Classifi cation" DataField="Classification" ItemStyle-Width="4%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Monthly_O verheads" DataField="Unit_Monthly_Overheads"
                                    ItemStyle-Width="4%" ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Cutting Share" DataField="Cuttingshare" ItemStyle-Width="4%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Stitching Share" DataField="stitchingshar" ItemStyle-Width="4%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="finishing shar" DataField="finishingshar" ItemStyle-Width="4%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Clients" ItemStyle-Width="8%" ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <%--added on 17/8/2015--%>
                                <asp:BoundField HeaderText="Finishing Active" DataField="Finishing_Active" ItemStyle-Width="4%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Cutting Active" DataField="Cutting_Active" ItemStyle-Width="4%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="4%"></ItemStyle>
                                </asp:BoundField>
                                <%--       end 17/8/2015--%>
                                <%--added on 24/8/2015--%>
                                <asp:BoundField HeaderText="Factory IE" Visible="false" DataField="" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Writer IE" Visible="false" DataField="" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>
                                <%--       end 24/8/2015--%>
                                <%--added on 14/9/2015--%>
                                <asp:BoundField HeaderText="Finishing  Factory" DataField="" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="Cutting  Factory" DataField="" ItemStyle-Width="6%" ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>

                                
                                <asp:BoundField HeaderText="Is VA Enabled" DataField="" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField> 


                                <asp:BoundField HeaderText="Finishing Supervisor" Visible="false" DataField="" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Finishing In charge" Visible="false" DataField="" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>

                            
                                <asp:BoundField HeaderText="Finishing QA" DataField="" Visible="false" ItemStyle-Width="6%"
                                    ItemStyle-CssClass="da_table_tr_bg">
                                    <ItemStyle Width="6%"></ItemStyle>
                                </asp:BoundField>


                                <%--   end 14/9/2015    --%>
                              <asp:CommandField HeaderText="Action" EditText='&lt;img src="../../images/edit2.png" title="Edit" alt="Edit" /&gt;' ButtonType="Link" ControlStyle-CssClass="da_edit_delete_link" ShowEditButton="true"
                                    HeaderStyle-CssClass="bdr_color" ItemStyle-CssClass="numeric_text padiing-left0"/>

                              <asp:CommandField HeaderText="" EditText='&lt;img src="../../images/delete-icon.png" title="Edit" alt="Edit" /&gt;' ButtonType="Link" ControlStyle-CssClass="da_edit_delete_link" ShowEditButton="true"
                                    HeaderStyle-CssClass="bdr_color" ItemStyle-CssClass="numeric_text padiing-left0"/>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="padding:8px 2px;">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="+" ToolTip="add"  CssClass="da_submit_button addicon" />
                        <input type="button" id="btnPrint" class="da_submit_button printicon" value="" title="Print" onclick="return PrintPDF();" />
                    </td>
                </tr>
            </table>
        </div>
    </div>   
</asp:Content>
