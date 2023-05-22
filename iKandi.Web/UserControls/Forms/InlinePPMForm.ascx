<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InlinePPMForm.ascx.cs"
    Inherits="iKandi.Web.InlinePPMForm" %>

<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    $(function () {
        $(".loadingimage").hide();
        $(".owner", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestUsers", { dataType: "xml", datakey: "string", max: 100 });

        $("input.owner", "#main_content").result(function () {

            var username = $(this).val();

            proxy.invoke("GetUserInfornationByName", { UserName: username }, function (result) {
                if (result.UserID > 0) {
                    $("#hdnOwnerId").val(result.UserID);
                    $("#hdnOwnerName").val(result.FullName);
                    //alert($("#hdnOwnerName").val());
                }
                else {
                    var message = 'The User dose not exist.Please enter user full name';
                    ShowHideValidationBox(true, message);

                    $("#hdnOwnerId").val("");
                    $("#hdnOwnerName").val("");
                }

            }, onPageError, false, false);
        });

    });

    function addOwner() {
        //debugger;

        if (jQuery.trim($("#txtOwner").val()) == '')
            return;
        var objIds = '<%=hdnOwnerIds.ClientID%>';
        var objNames = '<%=hdnOwnerNames.ClientID%>';
        var objLableName = '<%=lblOwnerName.ClientID%>';
        var strIds = $("#" + objIds).val();
        var strNames = $("#" + objNames).val();

        if ((strIds) == '') {
            strIds = $("#hdnOwnerId").val();
        }
        else {
            strIds = strIds + ',' + $("#hdnOwnerId").val();
        }
        if ((strNames) == '') {
            strNames = $("#hdnOwnerName").val();
        }
        else {
            strNames = strNames + ', ' + $("#hdnOwnerName").val();
        }
        $("#" + objIds).val(strIds);
        $("#" + objNames).val(strNames);
        $("#" + objLableName).text($("#" + objNames).val());

        // alert("Ids" + $("#" + objIds).val() + "Name " + $("#" +objNames).val());
    }


    function deleteImg(srcElem, imageId) {
        proxy.invoke("deleteInlinePPMFile", { ID: imageId },
         function (result) {
             if (result) {
                 $(srcElem).parent().hide();
             }
             return true;
         },
         onPageError, false, true);
        return false;
    }

    function CheckClientType() {
        var IsIkandiClient;
        IsIkandiClient = document.getElementById('<%=hdnIsIkandiClient.ClientID %>');
        var BIPLCheckBox = document.getElementById('<%=chkIsMeetingComplete.ClientID %>');
        var BHCheckBox = document.getElementById('<%=ChkBHMeetingComplete.ClientID %>');
        if (IsIkandiClient.value == '1') {
            if (BIPLCheckBox.checked == true) {
                BHCheckBox.checked = true;
            }
            else {
                BHCheckBox.checked = false;
            }
        }
    }



    function PrintPDFPPM(Url, height, width) {
        //$.showprogress();
        $(".loadingimage").show();
        $(".print").hide();
        var url;
        var ht = parseInt($(document).height()) - 130;
        var wd = parseInt($(document).width()) - 100;

        if (height != '' && height != null) {
            ht = height;
        }
        if (width != '' && width != null) {
            wd = width;
        }

        if (Url == '' || Url == null) {
            url = window.location.pathname;
        }
        else {
            url = Url;
        }

        if (url.indexOf('/') != 0)
            url = '/' + url;
        //   debugger;
        //alert(wd + " - " + ht);
        proxy.invoke("GeneratePDF", { Url: url + window.location.querystring, Width: wd, Height: ht }, function (result) {

            if ($.trim(result) == '') {
                //$.hideprogress();
                jQuery.facebox("Some error occured on the server, please try again later.");
            }
            else {
                //$.hideprogress();
                window.open(result);
                $(".loadingimage").hide();
                $(".print").show();
            }
        });

        return false;
    }

    function ValidatePPM() {
       
        var SAM = '';
        var OB = '';
        var OBFile=''
        var BHCheckBox;
        var CheckOBFile = 0;

        SAM = document.getElementById('<%=txtSAM.ClientID %>').value;
        OB = document.getElementById('<%=txtOB.ClientID %>').value;
        if (document.getElementById('<%=uploadSAM.ClientID %>').value == "") {
            if (document.getElementById('<%=hdnCheckFile.ClientID %>').value == "0") {
                CheckOBFile = "1";
            }
        }
        else {
            CheckOBFile = "0"

        }

        OBFile = document.getElementById('<%=uploadSAM.ClientID %>').value;
     

        BHCheckBox = document.getElementById('<%=ChkBHMeetingComplete.ClientID %>');

        if (BHCheckBox.checked == true) {
            if ((SAM == '') || (OB == '') || (CheckOBFile == '1')) {
                alert('PLEASE FILL PROD SAM AND PROD OB AND OB FILE');
                return false;
            }
            else {
                return true;
            }
        }

    }

   
    
</script>

<asp:Panel runat="server" ID="pnlForm">
    <div class="print-box">
        <div class="client_form">
            <div class="form_box">
                <div class="form_heading">
                    Pre Production and TOP
                </div>
                <div>
                    <table width="100%" class="item_list" bordercolor="#000000" border="1">
                        <tr>
                            <th width="13%" class="text_align_left">
                                Buyer
                            </th>
                            <td width="20%" class="text_align_left font_color_blue">
                                <asp:Label runat="server" ID="lblBuyer"></asp:Label>
                            </td>
                            <th width="15%" class="text_align_left ">
                                Style Number
                            </th>
                            <td width="20%" class="text_align_left font_color_blue">
                                <asp:Label runat="server" ID="lblStyleNumber"></asp:Label>
                            </td>
                            <th width="8%" class="text_align_left">
                                Prod SAM 
                            </th>
                            <td width="7%" class="text_align_left font_color_blue">
                                <asp:TextBox ID="txtSAM" MaxLength="3" Width="100px" CssClass="font_color_blue numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                                                            

<asp:HyperLink ID="hlnkViewSAM" ToolTip="VIEW SAM FILE" ImageUrl="~/App_Themes/ikandi/images/info.jpg" runat="server"  style="font-size:10px;" Target="_blank" Text=""></asp:HyperLink>
                             </td>
                             <th width="7%" class="text_align_left" rowspan="2">
                               OB File
                            </th>
                            <td width="10%" class="text_align_left font_color_blue" rowspan="2">
                                <asp:FileUpload Width="200px" ID="uploadSAM" runat="server" />   
                             </td>

                        </tr>
                        <tr>
                            <th class="text_align_left">
                                Serial No.
                            </th>
                            <td width="20%" class="text_align_left font_color_blue">
                                <asp:Label runat="server" ID="lbliKandiSerial"></asp:Label>
                            </td>
                            <th class="text_align_left">
                                Qty
                            </th>
                            <td class="text_align_left font_color_blue">
                                <asp:Label runat="server" ID="lblQty"></asp:Label>
                            </td>
                            <th class="text_align_left">
                                PROD OB
                            </th>
                            <td class="text_align_left font_color_blue">
                                  <asp:TextBox ID="txtOB" Width="100px" MaxLength="3" CssClass="font_color_blue numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                             <%--   <asp:FileUpload Width="200px" ID="uploadOB" runat="server" />                                

                    <asp:HyperLink ID="hlkViewOB" ToolTip="VIEW OB FILE" ImageUrl="~/App_Themes/ikandi/images/info.jpg" runat="server"  style="font-size:10px;" Target="_blank" Text=""></asp:HyperLink> --%>
                         </td>
                        
                        </tr>
                        <tr>
                            <th class="text_align_left">
                                Fabric/Color
                            </th>
                            <td class="text_align_left font_color_blue">
                                <div>
                                    <asp:Label runat="server" ID="lblFabricAndColor"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="Label2" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="lblApproval1" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="lblFabricAndColor2"></asp:Label><br />
                                </div>
                                <div>
                                    <asp:Label runat="server" ID="Label3" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="lblApproval2" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="lblFabricAndColor3"></asp:Label><br />
                                </div>
                                <div>
                                    <asp:Label runat="server" ID="Label4" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="lblApproval3" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="lblFabricAndColor4"></asp:Label><br />
                                </div>
                                <div>
                                    <asp:Label runat="server" ID="Label5" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                                <div>
                                    <asp:Label runat="server" ID="lblApproval4" ForeColor="Black" Font-Size="Smaller"></asp:Label></div>
                            </td>
                            <th class="text_align_left">
                                Ex Factory
                            </th>
                            <td class="text_align_left font_color_blue">
                                <asp:Label runat="server" ID="lblExFactory" CssClass="date_style"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th class="text_align_left">
                                Unit
                            </th>
                            <td class="text_align_left font_color_blue">
                                <asp:Label runat="server" ID="lblUnit"></asp:Label>
                            </td>
                            <th class="text_align_left">
                                Date Held - BIPL / BH</th>
                            <td class="text_align_left font_color_blue">
                                <asp:Label runat="server" ID="lblDateHeld" CssClass="date_style"></asp:Label>
                                &nbsp;/&nbsp;
                                <asp:Label ID="lblDateHeldBH" runat="server" CssClass="date_style"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <table class="form_table" width="100%" border="1">
                <tr>
                    <th colspan="2" align="center" style="width: 50% ! important;" class="ppmeting_font_style">
                        Stitching
                    </th>
                    <th align="center" colspan="2" style="width: 50% ! important;" class="ppmeting_font_style">
                        Image
                    </th>
                </tr>
                <tr>
                    <td colspan="2" class="">
                        <asp:TextBox runat="server" CssClass="font_color_blue" Width="99%" TextMode="MultiLine"
                            ID="txtStitchingComments"></asp:TextBox>
                    </td>
                    <td rowspan="5" colspan="2" align="center">
                        <asp:Image runat="server" Height="150px" Visible="false" ID="imgFront" />
                        <asp:Image ID="imgBack" runat="server" Height="150px" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <th colspan="2" align="center" class="ppmeting_font_style">
                        Wash Care
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox CssClass="font_color_blue" runat="server" TextMode="MultiLine" Width="99%"
                            ID="txtWashcareComments"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" align="center" class="ppmeting_font_style">
                        Embroidery
                    </th>
                </tr>
                <tr>
                    <td width="20%">
                        Machine
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" Width="99%" ID="txtEMBMachineComments"
                            MaxLength="999" CssClass="font_color_blue"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Hand
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" Width="99%" ID="txtEmbHandComments"
                            MaxLength="999" CssClass="font_color_blue"></asp:TextBox>
                    </td>
                    <th colspan="2" align="center" class="ppmeting_font_style">
                        PPM REMARKS/CORRECTIONS/INSTRUCTIONS
                    </th>
                </tr>
                <tr>
                    <th align="center" colspan="2" class="ppmeting_font_style">
                        Trims
                    </th>
                    <td colspan="2" runat="server" id="rowPPMRemarks" valign="top">
                        <div runat="server" id="divPrevPPMRemarks" style="font-size: 14px ! important; overflow: auto;
                            height: 400px ! important;">
                        </div>
                        <asp:TextBox runat="server" CssClass="font_color_blue" TextMode="MultiLine" Width="99%"
                            Rows="5" ID="txtPPMRemarksCorrections"></asp:TextBox>
                        <div>
                            Upload File :
                            <asp:FileUpload ID="uploadFile" runat="server" CssClass="multi" />
                        </div>
                        <div>
                            <asp:Repeater ID="rptUploadFile" runat="server">
                                <ItemTemplate>
                                    <div>
                                        <asp:HyperLink ID="hypFile" Target="_blank" runat="server" rel="lightbox" NavigateUrl='<%# ResolveUrl("~/Uploads/InlinePPM.Docs/" + (Eval("File"))) %>'> <%# Eval("File") %> </asp:HyperLink>&nbsp; <a id="imgDelete" href="javascript:void(0)" onclick='deleteImg(this,<%# Eval("id")%>)'>
                                            x</a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
                <asp:Repeater runat="server" ID="rptTrims">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("AccessoryName") %>
                                <asp:HiddenField runat="server" ID="hdnAccessoryID" Value='<%# Eval("Id") %>' />
                            </td>
                            <td>
                                <asp:TextBox Width="95%" runat="server" ID="
                                txtAccessoryComments" CssClass="font_color_blue"
                                    Text='<%# Eval("TrimsComments") %>' MaxLength="3990"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <th colspan="2" align="center" class="ppmeting_font_style">
                        Lining
                    </th>
                    <th colspan="2" align="center" class="ppmeting_font_style">
                        Packing
                    </th>
                </tr>
                <tr>
                    <td>
                        Fusing
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFusing" Width="95%" CssClass="font_color_blue"
                            MaxLength="999"></asp:TextBox>
                    </td>
                    <td style="width: 20% ! important;">
                        Tags
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTags" Width="95%" CssClass="date_style font_color_blue"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Interlining
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtInterlining" Width="95%" CssClass="font_color_blue"
                            MaxLength="999"></asp:TextBox>
                    </td>
                    <td>
                        Spare Buttons
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="font_color_blue" Width="95%" ID="txtSpaceButtons"
                            MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Pocket Lining
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPocketLining" Width="95%" CssClass="font_color_blue"
                            MaxLength="999"></asp:TextBox>
                    </td>
                    <td>
                        Card Board
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtCardBoard"
                            MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Shoulder Pad
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtShoulderPad" Width="95%" CssClass="font_color_blue"
                            MaxLength="999"></asp:TextBox>
                    </td>
                    <td>
                        W/O CARD BOARD
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="font_color_blue" Width="95%" ID="txtWOCardBoard"
                            MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" align="center" class="ppmeting_font_style">
                        Finishing
                    </th>
                    <td>
                        P.P. POLYTHENE L.D.
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtPolytheneComments"
                            MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        D/C
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtFinishingDC"
                            MaxLength="999"></asp:TextBox>
                    </td>
                    <td>
                        TISSUE
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtTissue"
                            MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Wash
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtFinishingWash"
                            MaxLength="999"></asp:TextBox>
                    </td>
                    <td>
                        FOAM
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtFOAM" MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Crinckle
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" ID="txtFinishingCrinckle" MaxLength="999"></asp:TextBox>
                    </td>
                    <td>
                        HANGER PACK
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtHanger"
                            MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        BOX SIZE
                    </td>
                    <td>
                        <asp:TextBox runat="server" Width="95%" CssClass="font_color_blue" ID="txtBoxSize"
                            MaxLength="999"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <table class="form_table" width="100%" border="1">
                <tr>
                    <td colspan="5" align="center">
                        MEETING ATTENDED BY
                    </td>
                </tr>
                <tr>
                    <th style="width: 14%">
                        Enter Name
                    </th>
                    <th style="width: 10%">
                    </th>
                    <th>
                        Name
                    </th>
                    <th style="width: 9%">
                        OTHER ATTENDED NAME
                    </th>
                    <th style="width: 2%">
                         Is FACTORY PPM Complete
                    </th>
                    <th style="width: 5%">
                        HO PPM
                    </th>
                    <th style="width: 2%">
                        HO PPM Complete
                    </th>
                </tr>
                <tr>
                    <td colspan="1">
                        <input class="owner" id="txtOwner" name="txtOwner" />
                        <input type="hidden" value='0' id="hdnOwnerId" name="hdnOwnerId" />
                        <input type="hidden" value='' id="hdnOwnerName" name="hdnOwnerName" />
                    </td>
                    <td>
                        <input type="button" style="width: 95px ! important;" id='btnAdd' class="add" onclick="addOwner()" />
                    </td>
                    <td>
                        <asp:Label ID="lblOwnerName" CssClass="meeting-attendent-name" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnOwnerIds" runat="server" Value="" />
                        <asp:HiddenField ID="hdnOwnerNames" runat="server" Value="" />
                    </td>
                    <td colspan="1" style="width: 10%">
                        <asp:TextBox ID="txtMeetingAttendedOtherUser" runat="server" TextMode="MultiLine"
                            Rows="3" cols="35" MaxLength="550"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:HiddenField ID="hdnIsIkandiClient" runat="server" />
                        <asp:CheckBox runat="server" ID="chkIsMeetingComplete" onClick="CheckClientType();"/>
                        <asp:DropDownList runat="server" ID="DropDownList1" Width="100%" Visible="false">
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                         <asp:TextBox runat="server" ID="txtBhPlannedMeeting" CssClass="date-picker date_style"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:CheckBox runat="server" ID="ChkBHMeetingComplete"  onClick="CheckClientType();"/>
                    </td>
                </tr>
            </table>
            <div class="form_box do-not-print">
                <br />
                <div class="form_heading">
                    TOP SECTION
                </div>
                <div>
                    <asp:GridView runat="server" ID="grdOrderDetails" CssClass="item_list1" AutoGenerateColumns="false"
                        Width="100%" OnRowDataBound="grdOrderDetails_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No." HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass="vertical_text">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnSerial" runat="server" />
                                    <asp:Label ID="Label4" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="vertical_text" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnUnit" runat="server" />
                                    <asp:Label ID="Label5" runat="server" Text='<%# (Eval("Unit") as iKandi.Common.ProductionUnit).FactoryName  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Line Item #" HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass="vertical_text">
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="hdnOrderContractID" Value='<%# Eval("OrderDetailID") %>' />
                                    <asp:Label ID="LabelLineNumber" runat="server" Text='<%# Eval("LineItemNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="vertical_text" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract #" HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass="vertical_text">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="vertical_text" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass="vertical_text">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartnmentName" runat="server" Text=' <%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.Name %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="vertical_text" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fabric/Details" SortExpression="Fabric1" HeaderStyle-Width="100px"
                                ItemStyle-Width="200px" ItemStyle-CssClass="vertical_top">
                                <ItemTemplate>
                                    <div class="">
                                        <span>
                                            <div>
                                            <nobr>
                                             <span runat="server" id="fabric1name" style="color:Blue"><%# Eval("Fabric1")%></span>
                                             <label class="<%#(Eval("Fabric1Details").ToString().Trim() == "" ) ? "hide_me": "" %>">: <%# Eval("Fabric1Details")%></label>
                                             <label  class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                                (
                                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F5BulkStatus%>
                                                 )
                                                </label>
                                                <label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent == 0 ) ? "hide_me": "" %>">
                                                (
                                                  <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric1Percent %>%
                                                 )
                                                </label>
                                                </nobr>
                                                </div>
                                                <div>
                                               <asp:Label ID="lblFabric11" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM1") %>' Width="72px"></asp:Label>  
                                               </div>
                                        <div>
                                            <nobr>
                                                <span runat="server" id="fabric2name" style="color:Blue"><%# Eval("Fabric2")%></span>
                    
                                            <label class="<%#(Eval("Fabric2Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                         : <%# Eval("Fabric2Details")%></label>
                       
                                        <label  class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                          (
                                             <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F6BulkStatus%>
                                            )
                                         </label> 
                                         <label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent == 0 ) ? "hide_me": "" %>">
                                            (
                                            <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric2Percent %>%
                                             )
                                        </label>
                                        </nobr>
                                        </div>
                                         <div>
                                         <asp:Label ID="lblFabric12" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM2")%>'></asp:Label>  
                                        
                                            <nobr>
                                         <span runat="server" id="fabric3name" style="color:Blue">
                                             <%# Eval("Fabric3")%>
                                         </span>
                    
                                        <label class="<%#(Eval("Fabric3Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                     : <%# Eval("Fabric3Details")%></label>
                       
                                    <label class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                        (
                                         <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F7BulkStatus%>
                                         )
                                    </label>
                                    <label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent == 0 ) ? "hide_me": "" %>">
                                        (
                                         <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric3Percent %>%
                                          )
                                    </label>
                                    </nobr>
                                    </div>
                                     <div>
                                     <asp:Label ID="lblFabric13" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM3")%>'></asp:Label>  
                                     </div>
                                     <div>
                                            <nobr>
                                    <span runat="server" id="fabric4name" style="color:Blue">
                                        <%# Eval("Fabric4")%>
                                    </span>
                    
                                <label class="<%#(Eval("Fabric4Details").ToString().Trim() == "" ) ? "hide_me": "" %>">
                                 : <%# Eval("Fabric4Details")%></label>
                       
                                <label  class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus.ToString().Trim() == "" ) ? "hide_me": "fabric_small_font fabricApprovalColor" %>">
                                    (
                                  <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricApprovalDetails.F8BulkStatus%>
                                     )
                                 </label>
                                <label style="color:Blue" class="<%#((Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent == 0 ) ? "hide_me": "" %>">
                                 (
                                    <%# (Eval("ParentOrder") as iKandi.Common.Order).FabricInhouseHistory.Fabric4Percent %>%
                                    )
                                </label>
                                </nobr>
                                </div>
                                
                                <div>
                                <asp:Label ID="lblFabric14" runat="server" ForeColor="Black" Font-Size="Smaller" Text='<%# Eval("CCGSM4")%>'></asp:Label>  
                                </div> 
                               </span>
                              </div>
                               
                                </ItemTemplate>
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inline Cut Dt." HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass="vertical_text date_style">
                                <ItemTemplate>
                                    <asp:Label ID="Label31" runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).Style.InLineCutDate) == DateTime.MinValue) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).Style.InLineCutDate.ToString("dd MMM yy (ddd)")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="vertical_text date_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Top Sent TGT." HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass=" date_style">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtTopSentTarget" Text='<%#(Convert.ToDateTime(Eval("TopSentTarget")) == DateTime.MinValue)? "" : Eval("TopSentTarget", "{0:dd MMM yy (ddd)}")     %>'
                                        CssClass="date-picker date_style vertical_text_input"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass=" date_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Top Sent ACT." HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass="date_style">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtTopSentActual" Text='<%# (Convert.ToDateTime(Eval("TopSentActual")) == DateTime.MinValue)? "" : Eval("TopSentActual", "{0:dd MMM yy (ddd)}")   %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdnFabTab" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnDetTab" runat="server" Value='<%# (Eval("DetailClass")) %>' />
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="date_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rdApproved" runat="server" GroupName="status" Text="Approved"
                                        Checked='<%# ((iKandi.Common.TopStatusType)Convert.ToInt32(Eval("TopStatus")) == iKandi.Common.TopStatusType.APPROVED) ? true : false  %>' />
                                    <asp:RadioButton ID="rdRejected" runat="server" GroupName="status" Text="Rejected"
                                        Checked='<%# ((iKandi.Common.TopStatusType)Convert.ToInt32(Eval("TopStatus")) == iKandi.Common.TopStatusType.REJECTED) ? true : false %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Top ACT. Appvl." HeaderStyle-CssClass="vertical_header"
                                ItemStyle-CssClass="date_style">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtTopActualApproval" Text='<%# (Convert.ToDateTime(Eval("TopActualApproval")) == DateTime.MinValue)? "" : Eval("TopActualApproval", "{0:dd MMM yy (ddd)}")  %>'
                                        CssClass="date-picker date_style vertical_text_input"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="date_style" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MDA #" HeaderStyle-CssClass="vertical_header" ItemStyle-CssClass="vertical_text">
                                <ItemTemplate>
                                    <asp:Label runat="server" CssClass="vertical_style_input" ID="lblMDA" Text='<%# Eval("MDA") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="vertical_header" />
                                <ItemStyle CssClass="vertical_text" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIPL Upload" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <a target="_blank" href='<%# ResolveUrl("~/uploads/InlinePPM.Docs/" + Eval("BIPLUploadFile").ToString()) %>'
                                        class="<%# (Eval("BIPLUploadFile") == null || string.IsNullOrEmpty(Eval("BIPLUploadFile").ToString()) ) ? "hide_me": "" %>">
                                        View File </a>
                                    <asp:FileUpload CssClass="inline_ppm_uplode_style" Width="100px" runat="server" ID="fileBIPLUpload" />
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIPL Comments">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="5" cols="20" CssClass="remarks_text remarks_text2"
                                        runat="server" ID="txtBIPLComments" Text='<%# Bind("BIPLComments") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Upload" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <a target="_blank" href='<%# ResolveUrl("~/uploads/InlinePPM.Docs/" + Eval("iKandiUploadFile").ToString()) %>'
                                        class="<%# (Eval("iKandiUploadFile") == null || string.IsNullOrEmpty(Eval("iKandiUploadFile").ToString()) ) ? "hide_me": "" %>">
                                        View File </a>
                                    <asp:FileUpload runat="server" Width="100px" CssClass="inline_ppm_uplode_style" ID="fileiKandiUpload" />
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="5" cols="20" CssClass="remarks_text remarks_text2"
                                        runat="server" ID="txtiKandiComments" Text='<%# Bind("iKandiComments") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <br />
            </div>
        </div>
    </div>
    <div class="form_buttom">
        <asp:Image ID="LoadImg" Style="position: fixed; z-index: 52111; top: 20%; left: 50%;
        width: 5%;" CssClass="loadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading7.gif"
        runat="server" />
        <asp:Button ID="btnSubmit" OnClientClick="javascript:return ValidatePPM();" CssClass="submit" runat="server" OnClick="btnSubmit_Click"
            Text="" />
        <input type="button" id="btnPrint" class="print" onclick="return PrintPDFPPM();" />
        <asp:HiddenField ID="hdnCheckFile" Value="0" runat="server" />
        
         <%--<input type="button" id="btnrefresh" value="refresh" onclick="window.location.reload(true);" />--%>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            PPM, TOP, SAM, OB & CMT have been updated into the system successfully!
            <br />
        </div>
    </div>
</asp:Panel>
