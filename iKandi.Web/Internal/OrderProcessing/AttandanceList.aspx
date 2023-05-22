<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttandanceList.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.AttandanceList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link rel="stylesheet" type="text/css" href="../../css/jquery-ui.css" />
  <link rel="stylesheet" type="text/css" href="../../css/datepicker.css" />
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js"></script>
  <script src="../../js/jquery.datePicker.js" type="text/javascript"></script>
  <script src="../../js/WeekDate.js" type="text/javascript"></script>
  <script type="text/javascript">
    $(document).ready(function() {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function EndRequestHandler(sender, args) {
          if ($("#hdnStartDate").val() != '' && $("#hdnEndDate").val() != '') {
            $('.date-pick').datePicker({ startDate: $("#hdnStartDate").val(), endDate: $("#hdnEndDate").val() });
          }
        }

    });
  </script>
  <script type="text/javascript">
    function BindEvents() {
      $(document).ready(function () {
        var TableWidth = 3635;
        var ColumnWidth = 186;
        if ($('#ddlBudgetPeriod option:selected').text() != "-- Select Budget --") {
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $("#tblMain").css("width", "100%");
          return;
        }

        if ($("#hdnHideColumnC47OT3").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".C47OT3").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".C47OT3").show();
        }
        if ($("#hdnHideColumnC47OT4").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".C47OT4").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".C47OT4").show();
        }

        if ($("#hdnHideColumnC45_46OT3").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".C45_46OT3").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".C45_46OT3").show();
        }
        if ($("#hdnHideColumnC45_46OT4").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".C45_46OT4").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".C45_46OT4").show();
        }

        if ($("#hdnHideColumnB45OT3").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".B45OT3").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".B45OT3").show();
        }
        if ($("#hdnHideColumnB45OT4").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".B45OT4").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".B45OT4").show();
        }

        if ($("#hdnHideColumnBIPLOT3").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".BIPLOT3").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".BIPLOT3").show();
        }
        if ($("#hdnHideColumnBIPLOT4").val() == "false") {
          TableWidth = TableWidth - ColumnWidth;
          $(".BIPLOT4").hide();
          $("#tblMain").css("width", "" + TableWidth + "px");
        }
        else {
          $(".BIPLOT4").show();
        }
      });
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
      margin: 5px 3px 0;
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
    
    .rotate
    {
      display: block; /*Firefox*/
     
      -moz-transform: rotate(-90deg); /*Safari*/
      -webkit-transform: rotate(-90deg); /*Opera*/
      -o-transform: rotate(-90deg);
      -ms-transform: rotate(-90deg);
  
      color: #405d9a;
      font-weight: bold;
      font-size: 15px;
      font-family: arial;
      padding: 0px;
      overflow: hidden;
      font-family: ‘Trebuchet MS’, Helvetica, sans-serif;
      line-height:40px;
      margin-top:150px;
    }
    .op-type a
    {
      font-family: arial;
      font-size: 12px !important;
      font-weight: bold;
      color: #3B5998;
      padding-left:2px;

    }
  </style>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <asp:ScriptManager ID="smAttandanceList" runat="server"></asp:ScriptManager>
    <asp:updatepanel ID="upAttandanceList" runat="server">
      <ContentTemplate>
        <script type="text/javascript">
          Sys.Application.add_load(BindEvents);
        </script>
        <table id="tblMain" border="0" cellpadding="0" cellspacing="0" align="center" style="font-family:Arial; font-size:13px;">
          <tr>
            <td>
              <table border="0" cellpadding="0" cellspacing="0" width="100%" align="left">
                <tr>
                  <td align="left" style="padding-left:25px; height:40px; background-color:#405D99; color:#FFFFFF;">
                    <span style="font-weight:bold;">Budget Period&nbsp;</span>
                    <asp:DropDownList ID="ddlBudgetPeriod" runat="server" Width="350px" Height="20px" ForeColor="#7E7E7E" AutoPostBack="true" OnSelectedIndexChanged="ddlBudgetPeriod_SelectedIndexChanged"></asp:DropDownList>
                    <span style="font-weight:normal; font-size:22px; padding-left:250px;">Attandance List</span>
                  </td>
                </tr>
                <tr><td style="height:5px;"></td></tr>
                <tr>
                  <td align="left" style="padding-left:25px; height:40px; background-color:#dddfe4 !important; color:#575759;">
                    <table border="0" cellpadding="0" cellspacing="0" width="950px" align="left">
                      <tr>
                        <td align="left" style="width:8%;"><span style="font-weight:bold;">Date From&nbsp;</span></td>
                        <td align="left" style="width:15%;">
                          <asp:TextBox ID="txtStartDate" runat="server" CssClass="date-pick" Width="100px" Height="20px" ForeColor="#7E7E7E" Font-Size="12px" AutoPostBack="true" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                          <asp:HiddenField ID="hdnStartDate" runat="server" />
                        </td>
                        <td align="left" style="width:2%;"><span style="font-weight:bold;">To&nbsp;</span></td>
                        <td align="left" style="width:15%;">
                          <asp:TextBox ID="txtEndDate" runat="server" Width="100px" Height="20px" ForeColor="#7E7E7E" Font-Size="12px" CssClass="date-pick" AutoPostBack="true" OnTextChanged="txtEndDate_TextChanged"></asp:TextBox>
                          <asp:HiddenField ID="hdnEndDate" runat="server" />
                        </td>
                        <td align="left" style="width:28%; padding-left:25px;">
                          <span style="font-weight:bold;">Department&nbsp;</span>
                          <asp:DropDownList ID="ddlDept" runat="server" Width="125px" Height="24px" ForeColor="#7E7E7E" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                        </td>
                        <td align="left" style="width:32%;">
                          <span style="font-weight:bold;">Worker Type&nbsp;</span>
                          <asp:DropDownList ID="ddlWorkerType" runat="server" Width="175px" Height="24px" ForeColor="#7E7E7E" AutoPostBack="true" OnSelectedIndexChanged="ddlWorkerType_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                        </td>
                      </tr>
                    </table>
                  </td>
                  <td></td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td align="left" style="height:35px;">
              <asp:HiddenField ID="hdnHideColumnC47OT3" runat="server" />
              <asp:HiddenField ID="hdnHideColumnC47OT4" runat="server" />
              <asp:HiddenField ID="hdnHideColumnC45_46OT3" runat="server" />
              <asp:HiddenField ID="hdnHideColumnC45_46OT4" runat="server" />
              <asp:HiddenField ID="hdnHideColumnB45OT3" runat="server" />
              <asp:HiddenField ID="hdnHideColumnB45OT4" runat="server" />
              <asp:HiddenField ID="hdnHideColumnBIPLOT3" runat="server" />
              <asp:HiddenField ID="hdnHideColumnBIPLOT4" runat="server" />
              <asp:UpdateProgress runat="server" ID="uproAttandanceList" AssociatedUpdatePanelID="upAttandanceList" DisplayAfter="0">
                <ProgressTemplate>
                  <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                </ProgressTemplate>
              </asp:UpdateProgress>
            </td>
          </tr>
          <tr>
            <td>
              <asp:GridView ID="gvAttandanceList" runat="server" AutoGenerateColumns="false" FooterStyle-Height="35px" FooterStyle-ForeColor="#7E7E7E" ShowHeader="true" HeaderStyle-Height="35px"
                HeaderStyle-Font-Size="11px" HeaderStyle-Font-Bold="false" RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E" OnRowCreated="gvAttandanceList_RowCreated"
                onrowdatabound="gvAttandanceList_RowDataBound" OnDataBound="gvAttandanceList_DataBound">
                <Columns>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="105px" HeaderStyle-ForeColor="#575759">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblAttandenceDate" runat="server" CssClass="rotate" Font-Size="20px" Text='<%#Eval("AttandenceDate") %>' ForeColor="#405D99" Font-Bold="true"></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-Width="200px" HeaderStyle-ForeColor="#7E7E7E" ItemStyle-CssClass="op-type">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:HyperLink ID="hlEdit" runat="server" Text='<%#Eval("WorkerType") %>' Enabled="false" NavigateUrl='<%# "~/Admin/OBAdmin/frmmanpowerattendance.aspx?Date=" + Eval("AttandenceDate") + "&FactoryWorkId=" +  Eval("FactoryWorkSpace") + "&OTs="+1 + "&Edit="+1 %>' />
                     <asp:HiddenField ID="hdnAttandenceDate" runat="server" Value='<%#Eval("AttandenceDate") %>' />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="ManPower_NormalHours_C_47" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="ManPower_OT1_C_47" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="TotalBudget_OT1_C_47" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT2_C_47" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="TotalBudget_OT2_C_47" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT3_C_47" ItemStyle-CssClass="C47OT3" HeaderStyle-CssClass="C47OT3" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT3_C_47" ItemStyle-CssClass="C47OT3" HeaderStyle-CssClass="C47OT3" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT4_C_47" ItemStyle-CssClass="C47OT4" HeaderStyle-CssClass="C47OT4" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT4_C_47" ItemStyle-CssClass="C47OT4" HeaderStyle-CssClass="C47OT4" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_NormalHours_C_45_46" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="ManPower_OT1_C_45_46" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="TotalBudget_OT1_C_45_46" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4"  />
                  <asp:BoundField DataField="ManPower_OT2_C_45_46" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="TotalBudget_OT2_C_45_46" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4"  />
                  <asp:BoundField DataField="ManPower_OT3_C_45_46" ItemStyle-CssClass="C45_46OT3" HeaderStyle-CssClass="C45_46OT3" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="TotalBudget_OT3_C_45_46" ItemStyle-CssClass="C45_46OT3" HeaderStyle-CssClass="C45_46OT3" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4"  />
                  <asp:BoundField DataField="ManPower_OT4_C_45_46" ItemStyle-CssClass="C45_46OT4" HeaderStyle-CssClass="C45_46OT4" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="TotalBudget_OT4_C_45_46" ItemStyle-CssClass="C45_46OT4" HeaderStyle-CssClass="C45_46OT4" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4"  />
                  <asp:BoundField DataField="ManPower_NormalHours_B_45" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="ManPower_OT1_B_45" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF"  />
                  <asp:BoundField DataField="TotalBudget_OT1_B_45" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT2_B_45" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT2_B_45" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT3_B_45" ItemStyle-CssClass="B45OT3" HeaderStyle-CssClass="B45OT3" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT3_B_45" ItemStyle-CssClass="B45OT3" HeaderStyle-CssClass="B45OT3" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT4_B_45" ItemStyle-CssClass="B45OT4" HeaderStyle-CssClass="B45OT4" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT4_B_45" ItemStyle-CssClass="B45OT4" HeaderStyle-CssClass="B45OT4" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_NormalHours" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="ManPower_OT1" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT1" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT2" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT2" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT3" ItemStyle-CssClass="BIPLOT3" HeaderStyle-CssClass="BIPLOT3" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT3" ItemStyle-CssClass="BIPLOT3" HeaderStyle-CssClass="BIPLOT3" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                  <asp:BoundField DataField="ManPower_OT4" ItemStyle-CssClass="BIPLOT4" HeaderStyle-CssClass="BIPLOT4" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#7E7E7E" HeaderStyle-BackColor="#FFFFFF" />
                  <asp:BoundField DataField="TotalBudget_OT4" ItemStyle-CssClass="BIPLOT4" HeaderStyle-CssClass="BIPLOT4" HeaderText="Budget (Consumed)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="#575759" HeaderStyle-BackColor="#dddfe4" />
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </ContentTemplate>
    </asp:updatepanel>
  </div>
  </form>
</body>
</html>
