<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FITsForm.ascx.cs" Inherits="iKandi.Web.FITsForm" %>
<%@ Register Src="~/UserControls/Forms/FITsTopsSection.ascx" TagName="FITsTopsSection"
    TagPrefix="iKandi" %>


   
  <script type="text/javascript">

      $(function () {
          $(".th").datepicker({ dateFormat: 'dd M y (D)' });
         
      });
  
  </script>


<script type="text/javascript">

    var weekDays = new Array(7);

    $(function () {
        //setter        
        $('.date-selected').datepicker({
            dateFormat: 'dd M y (D)',
            constrainInput: true,
            beforeShowDay: noWeekendsOrHolidays
        });

        weekDays[0] = $("#<%= hdnMon.ClientID %>").val();
        weekDays[1] = $("#<%= hdnTue.ClientID %>").val();
        weekDays[2] = $("#<%= hdnWed.ClientID %>").val();
        weekDays[3] = $("#<%= hdnThu.ClientID %>").val();
        weekDays[4] = $("#<%= hdnFri.ClientID %>").val();
        weekDays[5] = 0;
        weekDays[6] = 0;
    });

    function noWeekendsOrHolidays(date) {
        var noWeekend = jQuery.datepicker.noWeekends(date);
        return noWeekend[0] ? nationalDays(date) : noWeekend;
    }

    /* utility functions */
    function nationalDays(date) {
        for (i = 0; i < weekDays.length; i++) {
            if (weekDays[date.getDay() - 1] == 0) {
                return [false];
            }
        }
        return [true];

    }

    function ValidateFitForm() {
        if ($("#txtIsIkandiUser").val() == "0") return true;


    }

    function IsFileUploaded(source, arguments) {

        if ($("#txtIsIkandiUser").val() == "0")
            arguments.IsValid = true;

        var objFile = $(source).parents("TD").find("input[type=file]");

        if (objFile.val().length == 0)
            arguments.IsValid = false;
        else
            arguments.IsValid = true;
    }

    function validate() {
        //


        if (document.getElementById('<%=chkSpecs.ClientID %>').checked == true) {
            var t1 = Page_ClientValidate("submit");
            if (!t1) {
                return false;
            }
            return true;
        }
        alert('Please check the Spec Upload checkbox in order to submit the form');
        return false;
    }

</script>

<div class="form_box">
      <table>
        <tr>
            <td>
                IKANDI BUYING SAMPLE SENT DATE:
            </td>
            <td>
                <asp:TextBox ID="txtTrackDate" runat="server" CssClass="th date_style"></asp:TextBox>
                <asp:Label ID="lblSpecsUploadedDate" runat="server" ></asp:Label>
            </td>
            <td>
                UPLOAD BLOCK SPECS
            </td>
            <td>
                <asp:FileUpload runat="server" ID="fileUploadSpecs" />
            </td>
            <td>
                <div>
                    <asp:HyperLink ID="hlkViewMeSpecs" runat="server" Visible="false" Target="_blank"
                        Text="View File"></asp:HyperLink>
                </div>
            </td>
            <td>
                <asp:CheckBox ID="chkSpecs" runat="server" />
                
                <asp:HiddenField ID="hdnSpecsUploadedDate" runat="server" />
            </td>
            <td>
             <asp:Button ID="btnSaveSpecUpload" runat="server" Text="save" CssClass="save" OnClick="btnSaveAll_Click"
        Visible="true" />
            </td>
            
          
        </tr>
    </table>
</div>

<div class="form_box">
    <div class="form_heading">
        Basic Information:
        <asp:Label ID="lblDepartMentName" runat="server"></asp:Label>
        <asp:HiddenField ID="hdnDeptId" runat="server" Value="" />
        <asp:HiddenField ID="hdnMon" runat="server" Value="" />
        <asp:HiddenField ID="hdnTue" runat="server" Value="" />
        <asp:HiddenField ID="hdnWed" runat="server" Value="" />
        <asp:HiddenField ID="hdnThu" runat="server" Value="" />
        <asp:HiddenField ID="hdnFri" runat="server" Value="" />
        <input type='hidden' id="txtIsIkandiUser" value='<%# (IsIKandiUser) ? "1" : "0" %>' />
    </div>
    <div class="form_box">
        <asp:GridView ID="grdBasicInfo" runat="server" Width="100%" AutoGenerateColumns="False"
            OnRowDataBound="grdBasicInfo_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Order Date</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOrderDate" CssClass="date_style" runat="server" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).OrderDate) == DateTime.MinValue)? "" : (Eval("ParentOrder") as iKandi.Common.Order).OrderDate.ToString("dd MMM yy (ddd)") %>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Serial No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSerialNumber" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).SerialNumber%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LineItemNumber" HeaderText="Line NO" />
                <asp:BoundField DataField="ContractNumber" HeaderText="Contract" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Description
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# (Eval("ParentOrder") as iKandi.Common.Order).Description%>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-CssClass="numeric_text"
                    DataFormatString="{0:N0}" />
                <asp:BoundField DataField="Fabric1Details" HeaderText="Fabric Details" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Mode
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnMode" runat="server" />
                        <%# Eval("ModeName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ex Factory" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnExFactory" runat="server" />
                        <%# (Convert.ToDateTime(Eval("ExFactory")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DC Date" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime(Eval("DC")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("DC"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PRICE" ItemStyle-CssClass="date_style">
                    <ItemTemplate>
                         <%# iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(Convert.ToInt32((Eval("ParentOrder") as iKandi.Common.Order).Costing.ConvertTo))%>
                         <%#  Convert.ToDouble(Eval("iKandiPrice")).ToString("N2")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Status
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnStatus" runat="server" />
                        <a onclick="showWorkflowHistory2('-1', '<%# Eval("OrderId") %>' , '<%# Eval("OrderDetailId") %>')">
                            <%# Eval("Status") %></a></ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <label>No records Found</label></EmptyDataTemplate>
            <HeaderStyle CssClass="item_list" />
            <RowStyle CssClass="item_list" />
        </asp:GridView>
    </div>
</div>
<div class="form_box" id="div1">
    <div id="div2">
        <br />
        <div class="form_heading" id="div3">
            <strong>FITS TRACKING STC Target</strong> <span style="font-size: 15px; text-align: right !important;
                color: Black !important;">(
                <asp:Label ID="lblStc" runat="server" ForeColor="Black"></asp:Label>
                ) </span>
        </div>
        <br />
        <div style="padding-left: 20px;">
        </div>
        <asp:Repeater ID="rptFitSection" runat="server" OnItemDataBound="rptFitSection_ItemDataBound">
            <ItemTemplate>
                <div style="padding: 0px 20px 0px 20px;">
                    <div class="form_box">
                        <table width="100%"">
                            <tr>
                                <td style="width: 50%;">
                                    <table width="100%" style="line-height: 20px;">
                                        <tr>
                                            <th colspan="2" align="center">
                                                Buying House
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                FITS COMMENTS SENT FOR
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlFitsComments" runat="server" Enabled="false">
                                                    <asp:ListItem Text="FIT 1"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 2"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 3"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 4"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 5"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 1"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 2"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 3"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 1"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 2"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 3"></asp:ListItem>
                                                    <asp:ListItem Text="REF SAMPLE"></asp:ListItem>
                                                    <asp:ListItem Text="SIZE SET"></asp:ListItem>
                                                    <asp:ListItem Text="COUNTER"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Next Planned FIT Date
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNextPlannedFitDate" runat="server" CssClass="date_style date-selected"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Request
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRequest" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRequest_SelectedIndexChanged">
                                                    <asp:ListItem Text="FIT 1"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 2"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 3"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 4"></asp:ListItem>
                                                    <asp:ListItem Text="FIT 5"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 1"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 2"></asp:ListItem>
                                                    <asp:ListItem Text="PP SAMPLE 3"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 1"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 2"></asp:ListItem>
                                                    <asp:ListItem Text="SEALER 3"></asp:ListItem>
                                                    <asp:ListItem Text="REF SAMPLE"></asp:ListItem>
                                                    <asp:ListItem Text="STC"></asp:ListItem>
                                                    <asp:ListItem Text="SIZE SET"></asp:ListItem>
                                                    <asp:ListItem Text="COUNTER"></asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Request Reference Sample
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkBoxReferenceSample" runat="server" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Upload File
                                            </td>
                                            <td>
                                                <asp:FileUpload runat="server" ID="fileIkandiUpload"  />
                                                <div>
                                                <asp:CustomValidator runat="server" ID="cviKandiFileUpload" ValidationGroup="submit" ErrorMessage="File upload is required" Display=Dynamic
                                                 ControlToValidate="ddlRequest" ClientValidationFunction="IsFileUploaded">                                                
                                                </asp:CustomValidator>
                                                </div>
                                                <div>
                                                    <asp:HyperLink ID="hlkViewMe" runat="server" Visible="false" Target="_blank" Text="View File"></asp:HyperLink>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table width="100%" style="line-height: 20px;">
                                        <tr>
                                            <th align="center">
                                                BIPL
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                FIT PLANNING FOR
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFitPlanningFor" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Sample Sent On
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkBoxAcknowledge" runat="server" />
                                                <asp:TextBox ID="txtAckDate" CssClass="th date_style" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Planned Dispatch Date
                                            </td>
                                            <td>
                                                <asp:Label ID="txtPlannedDispatchDate" runat="server" CssClass="date_style"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Suggested FIT Date
                                            </td>
                                            <td id="rowBipl" runat="server">
                                                <asp:TextBox ID="txtSuggestedFitDate" runat="server" CssClass="date_style do-not-allow-typing"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Upload File
                                            </td>
                                            <td>
                                                <asp:FileUpload runat="server" ID="fileBiplUpload" />
                                                <div>
                                                    <asp:HyperLink ID="hlkViewMeBipl" runat="server" Visible="false" Target="_blank"
                                                        Text="View File"></asp:HyperLink>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<asp:Panel ID="pnlStcHide" runat="server" Width="100%">
    <table width="100%" class="form_table">
        <tr>
            <th colspan="3">
                STC SECTION
            </th>
        </tr>
        <tr>
            <td>
                STC Approved
            </td>
            <td>
                <asp:CheckBox ID="chkBoxStcApproved" runat="server" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Comments
            </td>
            <td>
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Graded Specs
            </td>
            <td>
                <asp:FileUpload runat="server" ID="FileUpload1" />
                <div>
                    <asp:HyperLink ID="hlkViewMe" runat="server" Visible="false" Target="_blank" Text="View File"></asp:HyperLink>
                </div>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%" class="form_table">
        <tr class="item_list">
            <th>
                BH Comments(Sealers Pending)
            </th>
            <th>
                BIPL Comments(Sealers Pending)
            </th>
        </tr>
        <tr class="item_list">
            <td>
                <asp:TextBox ID="txtCommentsIkandi" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCommentsBIPL" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
</asp:Panel>
<div>
    <asp:Button ID="btnSaveAll" runat="server" Text="save" CssClass="save" OnClientClick="javascript:return validate();" ValidationGroup="submit" OnClick="btnSaveAll_Click"
        Visible="true" />
</div>
<br />
<iKandi:FITsTopsSection ID="ucFITsTopsSection" runat="server" />
<br />
