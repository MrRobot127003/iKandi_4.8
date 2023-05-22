<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoBudget.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.MoBudget" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link rel="stylesheet" type="text/css" href="../../css/jquery-ui.css" />
  <link rel="stylesheet" type="text/css" href="../../css/datepicker.css" />
  <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
  <script src="../../js/jquery.datePicker.js" type="text/javascript"></script>
  <script src="../../js/WeekDate.js" type="text/javascript"></script>
  <script type="text/javascript" charset="utf-8">
     $(document).ready(function() {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function EndRequestHandler(sender, args) {
          $('.date-pick').datePicker({ selectWeek: true, closeOnSelect: true });
          $('#txtStartDate').bind('dpClosed',
		        function (e, selectedDates) {
		          var d = selectedDates[0];
		          if (d) {
		            d = new Date(d);
		            $('#txtEndDate').dpSetStartDate(d.addDays(1).asString());
		          }
		        }
	        );
		      $('#txtEndDate').bind('dpClosed',
		        function (e, selectedDates) {
		          var d = selectedDates[0];
		          if (d) {
		            d = new Date(d);
		            $('#txtStartDate').dpSetEndDate(d.addDays(-1).asString());
		          }
		        }
	        );
        }
      });
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
      margin: 0px 3px 0;
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
    
    img
    {
        border:0px;
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
    }
    .blue-text
    {
      color:#405D99;
      font-weight:bold;
      text-align:center;
    }
    .blue-text-line
    {
      color:#405D99;
      text-align:center;
    }
    .CalcCost
    {
      color:#405D99;
      font-weight:bold;
      font-size:12px;
    }
    .BudCount
    {
      text-align:center;
    }
    .BudCost
    {
      color:#405D99;
      font-weight:normal;
      font-size:12px;
    }
    .CalcCount
    {
      color:#161622;
      font-weight:bold;
      font-size:12px;
    }
    .CMTCost
    {
      color:#405D99;
      font-weight:bold;
      font-size:12px;
    }
    .op-dept
    {
      font-size:12px; 
      color:#405D99;
      padding-left:5px;       
    }
    .hide-td
    {
        display:none;
    }
  </style>

  <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
  <script type="text/javascript">
    function OpenShadowbox(obj) {
      var sURL = obj.href;
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 768, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      $("#sb-nav-close").css({ "visibility": "hidden" });
      return false;
    }
    function SBClose() { }
  </script>
  <script type="text/javascript">
    function isNumberKey(evt) {
      evt = (evt) ? evt : window.event;
      var charCode = (evt.which) ? evt.which : evt.keyCode;
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
      }
      return true;
    }

    function isNumberKeyWithDecimal(evt, obj) {
      //      debugger;
      var charCode = (evt.which) ? evt.which : event.keyCode
      var value = obj.value;
      var dotcontains = value.indexOf(".") != -1;
      if (dotcontains)
        if (charCode == 46) return false;
      if (charCode == 46) return true;
      if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
      return true;
    }
  </script>
</head>
<body>  
  <form id="form1" runat="server">
  <div>
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:updatepanel ID="upBudget" UpdateMode="Always" runat="server">
      <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="1575px" align="center" style="font-family:Arial;">
          <tr>
            <td style="background-color: #405D99; height:50px;">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                  <td align="center" style="width: 20%;">                
                    <asp:Button ID="btnViewPanel" runat="server" Text="View Budget" OnClick="btnViewPanel_Click" Visible="false" />
                    <asp:Button ID="btnCreatePanel" runat="server" Text="Create Budget" OnClick="btnCreatePanel_Click" ForeColor="#000" />
                  </td>
                  <td align="center" style="width: 50%; color: #FFFFFF; font-size: 22px;">
                    <asp:Label ID="lblMessage" runat="server" Text="Manpower Budget"></asp:Label>
                  </td>
                  <td valign="middle" style="width: 30%; padding-left:50px; padding-right:5px;">
                    <div style="border:2px solid #FFFFFF; height:30px; width: 98%; padding-left:0px;">
                      <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="height:100%;">
                        <tr>
                          <td align="center" valign="middle" style="width: 30%; color: #FFFFFF; font-size: 18px;">Absenteeism</td>
                          <td align="left" valign="middle" style="width: 20%;">
                            <asp:TextBox ID="txtAbsentism" runat="server" Width="50px" MaxLength="5" Text="0.00" Font-Size="14px" ForeColor="#405D99" CssClass="blue-text-line" onkeypress="Javascript:return isNumberKeyWithDecimal(event, this);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAbsentism" runat="server" Display="None" ErrorMessage="Please enter Absentism." ControlToValidate="txtAbsentism" ValidationGroup="Group1" />
                            <asp:RegularExpressionValidator ID="revAbsentism" runat="server" Display="None" ValidationExpression="((\d+)((\.\d{1,2})?))$" ErrorMessage="Please enter valid integer or decimal Absentism with 2 decimal places." ControlToValidate="txtAbsentism" ValidationGroup="Group1" />
                            <asp:CompareValidator ID="cvAbsentism" runat="server" ValueToCompare="100" Display="None" ControlToValidate="txtAbsentism" ErrorMessage="Please enter value less than 100" Operator="LessThan" Type="Double" ValidationGroup="Group1"></asp:CompareValidator>
                          </td>
                          <td align="center" valign="middle" style="width: 30%; color: #FFFFFF; font-size: 18px;">Working Hour</td>
                          <td align="center" valign="middle" style="width: 20%;">
                            <asp:TextBox ID="txtworkingHour" runat="server" Width="50px" Font-Size="14px" ForeColor="#405D99" CssClass="blue-text-line"></asp:TextBox>
                          </td>
                        </tr>
                      </table>
                    </div>
                  </td>
                  <td style="padding-right:10px;">
                    <a rel="shadowbox;width=780;height=600;" href="/internal/OrderProcessing/MoBudget_Formulas.aspx?show=Budget" onclick="return OpenShadowbox(this);"><img src="../../images/help.png" height="30px" alt="" title="Help!" /></a>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td style="height:5px;"></td>
          </tr>
          <tr>
            <td style="background-color:#405D99; height:35px;">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                  <td align="center" style="width:20%; padding-left:20px;">
                    <asp:Panel ID="pnlCreatePanel" runat="server" Visible="false">
                      <asp:TextBox ID="txtStartDate" runat="server" CssClass="date-pick" Width="85px" ForeColor="#405D99"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" Display="None" ErrorMessage="Please select a Start Date." ControlToValidate="txtStartDate" ValidationGroup="G1" />
                      <asp:TextBox ID="txtEndDate" runat="server" Width="85px" CssClass="date-pick" ForeColor="#405D99"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" Display="None" ErrorMessage="Please select a End Date." ControlToValidate="txtEndDate" ValidationGroup="G1" />
                      <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" ValidationGroup="G1" />
                      <asp:ValidationSummary ID="vsSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="G1" />
                    </asp:Panel>
                    <asp:Panel ID="pnlViewPanel" runat="server">
                      <asp:DropDownList ID="ddlViewBudget" runat="server" Width="350px" Height="20px" AutoPostBack="true" OnSelectedIndexChanged="ddlViewBudget_SelectedIndexChanged" ForeColor="#405D99"></asp:DropDownList>  
                    </asp:Panel>
                  </td>
                  <td style="width:50%;"></td>
                  <td align="right" style="width:30%; padding-right:15px;">
                    <asp:Label ID="lblFinalize" runat="server" Text="Budget Finalize" Font-Size="14px" ForeColor="#FFFFFF" Visible="false"></asp:Label>
                    <asp:CheckBox ID="chkFinalize" runat="server" Visible="false" />
                    <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit" Visible="false" OnClick="btnSubmit_Click" ValidationGroup="Group1" />
                    <asp:ValidationSummary ID="vsAbsentism" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Group1" />
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td style="height:5px;"></td>
          </tr>
          <tr>
            <td align="right">
              <asp:GridView ID="gvWorkingHours" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-Height="25px" HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="false"
                HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="25px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvWorkingHours_RowDataBound">
                <Columns>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="175px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblHeader" runat="server" CssClass="op-dept" Text='<%#Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="275px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>Normal Hours (8)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblNormalHours" runat="server" Font-Size="12px" CssClass="blue-text" Font-Bold="true" Text='<%# (Convert.ToInt32(Eval("TotalWeekDays")) == 0) ? "" : Eval("TotalWeekDays") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="275px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>OT1 (<asp:Label ID="lblOT1" runat="server"></asp:Label>)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:TextBox ID="txtOT1" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text" Text='<%# (Convert.ToInt32(Eval("NoOfDays_OT1")) == 0) ? "" : Eval("NoOfDays_OT1") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="75px"></asp:TextBox>
                    </ItemTemplate>
                  </asp:TemplateField> 
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="275px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>OT2 (<asp:Label ID="lblOT2" runat="server"></asp:Label>)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:TextBox ID="txtOT2" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text" Text='<%# (Convert.ToInt32(Eval("NoOfDays_OT2")) == 0) ? "" : Eval("NoOfDays_OT2") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="75px"></asp:TextBox>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="275px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>OT3 (<asp:Label ID="lblOT3" runat="server"></asp:Label>)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:TextBox ID="txtOT3" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text" Text='<%# (Convert.ToInt32(Eval("NoOfDays_OT3")) == 0) ? "" : Eval("NoOfDays_OT3") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="75px"></asp:TextBox>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="275px" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>OT4 (<asp:Label ID="lblOT4" runat="server"></asp:Label>)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:TextBox ID="txtOT4" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text" Text='<%# (Convert.ToInt32(Eval("NoOfDays_OT4")) == 0) ? "" : Eval("NoOfDays_OT4") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="75px"></asp:TextBox>
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
          <tr>
            <td style="height:5px;"></td>
          </tr>
          <tr>
            <td>
              <table border="0" cellpadding="0" cellspacing="0" width="1575px" align="left" style="margin-left:0px; margin-top:-1px;">
                <tr>
                  <td colspan="4">
                    <asp:GridView ID="gvAvailMin" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader" RowStyle-BackColor="#405D99" RowStyle-ForeColor="#FFFFFF"
                      RowStyle-CssClass="RangeStyle" Width="100%" ShowHeader="false" RowStyle-Height="25px" OnRowDataBound="gvAvailMin_rowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#FFFFFF">
                          <ItemTemplate>
                            <asp:Label ID="lblHeader" runat="server" Font-Size="16px" Text=''></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#FFFFFF">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="16px" Text='<%#Eval("Column2") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#FFFFFF">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="16px" Text='<%#Eval("Column3") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#FFFFFF">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="16px" Text='<%#Eval("Column4") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                          <ItemStyle CssClass="hide-td" />
                          <HeaderStyle CssClass="hide-td" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center" ItemStyle-ForeColor="#FFFFFF">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="16px" Text='<%#Eval("Column5") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                    <asp:UpdateProgress runat="server" ID="uproBudget" AssociatedUpdatePanelID="upBudget" DisplayAfter="0">
                      <ProgressTemplate>
                        <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 55%; left: 48%; width: 6%;" />
                      </ProgressTemplate>
                    </asp:UpdateProgress>
                  </td>
                </tr>
                <tr id="trLine_Floor" runat="server" visible="false">
                  <td valign="top" style="width: 310px;height:90px;padding-left: 1px;background-color:#405D99; border-right:1px solid #ffffff;"></td>
                  <td valign="middle" align="center" style="width: 310px;background-color:#405D99; border-right:1px solid #ffffff;">
                    <asp:GridView ID="gvFactoryLine_FloorDetails1" runat="server" AutoGenerateColumns="false" Width="250px" HeaderStyle-Height="25px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
                      HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="25px" RowStyle-ForeColor="#FFFFFF" OnRowDataBound="gvFactoryLine_FloorDetails1_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblMode" runat="server" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" Text='<%#Eval("Mode") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Cutting</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtCutting" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Cutting")) == 0) ? "" : Eval("Cutting") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Stitching</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtStitching" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Stitching")) == 0) ? "" : Eval("Stitching") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Finishing</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtFinishing" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Finishing")) == 0) ? "" : Eval("Finishing") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                  <td valign="middle" align="center" style="width: 310px;background-color:#405D99; border-right:1px solid #ffffff;">
                    <asp:GridView ID="gvFactoryLine_FloorDetails2" runat="server" AutoGenerateColumns="false" Width="250px" HeaderStyle-Height="25px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
                      HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="25px" RowStyle-ForeColor="#FFFFFF" OnRowDataBound="gvFactoryLine_FloorDetails2_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblMode" runat="server" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" Text='<%#Eval("Mode") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Cutting</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtCutting" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Cutting")) == 0) ? "" : Eval("Cutting") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Stitching</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtStitching" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Stitching")) == 0) ? "" : Eval("Stitching") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Finishing</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtFinishing" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Finishing")) == 0) ? "" : Eval("Finishing") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                  <td valign="middle" align="center" style="width: 310px;background-color:#405D99; border-right:1px solid #ffffff;" class="hide-td">
                   <%-- <asp:GridView ID="gvFactoryLine_FloorDetails3" runat="server" AutoGenerateColumns="false" Width="250px" HeaderStyle-Height="25px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
                      HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="25px" RowStyle-ForeColor="#FFFFFF" OnRowDataBound="gvFactoryLine_FloorDetails3_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblMode" runat="server" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" Text='<%#Eval("Mode") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Cutting</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtCutting" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Cutting")) == 0) ? "" : Eval("Cutting") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Stitching</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtStitching" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Stitching")) == 0) ? "" : Eval("Stitching") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Finishing</HeaderTemplate>
                          <ItemTemplate>
                            <asp:TextBox ID="txtFinishing" runat="server" MaxLength="2" Font-Size="12px" CssClass="blue-text-line" Text='<%# (Convert.ToInt32(Eval("Finishing")) == 0) ? "" : Eval("Finishing") %>' onkeypress="Javascript:return isNumberKey(event);"  Width="30px" Height="10px"></asp:TextBox>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>--%>
                  </td>
                  <td valign="middle" align="center" style="width: 310px;background-color:#405D99; border-right:1px solid #ffffff;">
                    <asp:GridView ID="gvFactoryLine_FloorDetails4" runat="server" AutoGenerateColumns="false" Width="250px" HeaderStyle-Height="25px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false"
                      HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99" RowStyle-Height="25px" RowStyle-ForeColor="#FFFFFF" OnRowDataBound="gvFactoryLine_FloorDetails4_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblMode" runat="server" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" Text='<%#Eval("Mode") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Cutting</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCutting" runat="server" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" Text='<%#Eval("Cutting") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Stitching</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblStitching" runat="server" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" Text='<%#Eval("Stitching") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Finishing</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblFinishing" runat="server" ForeColor="#FFFFFF" Font-Size="12px" Font-Bold="true" Text='<%#Eval("Finishing") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                </tr>
                <tr>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvWorkerType" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" RowStyle-Height="30px" RowStyle-ForeColor="#7E7E7E"
                      OnDataBound="gvWorkerType_DataBound" OnRowDataBound="gvWorkerType_RowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblStaffDept" runat="server" CssClass="rotate" Font-Size="22px" Text='<%#Eval("StaffDept") %>' ForeColor="#405D99" Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="230px">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblWorkerType" runat="server"  Text='<%#Eval("WorkerType") %>' CssClass="op-dept"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                    <div id="dvWorkerType" runat="server" visible="false" style="margin-top: 0px;">
                      <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border-left: 1px solid #7E7E7E;border-bottom: 1px solid #7E7E7E;border-right: 1px solid #7E7E7E;">
                        <tr>
                          <td align="center" style="height:36px; font-size:14px;" class="op-dept">Monthly Total</td>
                        </tr>
                        <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                        <tr>
                          <td align="center" style="height:35px; font-size:14px;" class="op-dept">Budget Period Total</td>
                        </tr>
                        <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                        <tr>
                          <td align="center" style="color:#405D99; font-size:15px; height:61px;">Budget Production Cost<br /><span style="color: #017F01;">Vs</span><br />Costed Production Cost</td>
                        </tr>
                      </table>
                    </div>
                  </td>              
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvFactoryDetails1" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-Height="25px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="30px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvFactoryDetails1_RowDataBound" FooterStyle-BackColor="LightGray" OnRowCreated="gvFactoryDetails1_RowCreated">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" Visible="false">
                          <HeaderTemplate>Calc Count</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCalcCount" runat="server"  Text='<%# (Convert.ToInt32(Eval("CalcCount")) == 0) ? "" : Eval("CalcCount") %>' CssClass="CalcCount"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyCalcCount" runat="server" Font-Size="15px" Font-Bold="true" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCalcCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color: #FFFFFF;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="124px" ItemStyle-BackColor="#feff99" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Bud Count</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />
                            <asp:HiddenField ID="hdnWorkerTypeId" runat="server" Value='<%#Eval("FactoryWorkSpace") %>' />
                            <asp:TextBox ID="txtBudCount" runat="server" MaxLength="4" Width="50px" Font-Size="14px" BackColor="#feff99" BorderColor="#feff99" CssClass="BudCount" AutoPostBack="true" OnTextChanged="txtBudCount1_TextChanged" onkeypress="Javascript:return isNumberKey(event);"></asp:TextBox>
                            <asp:HiddenField ID="hdnOldBudCount" runat="server" />
                            <asp:HiddenField ID="hdnValuesToBudCost" runat="server" Value='<%#Eval("ValuesToGetBudCost") %>' />
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblMonthlyTotalBudCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalBudCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color: #feff99;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" Visible="false">
                          <HeaderTemplate>Calc Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCalcCost" runat="server" Font-Size="12px" Text='<%# (Convert.ToInt32(Eval("CalcCost")) == 0) ? "" : Eval("CalcCost") %>' ForeColor="#405D99"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyCalcCost" runat="server" Font-Size="15px" Font-Bold="true" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCalcCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color:#FFFFFF;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="124px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Bud Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblBudCost" CssClass="BudCost" runat="server"  Text='<%# (Convert.ToInt32(Eval("BudCost")) == 0) ? "" : Eval("BudCost") %>'></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyBudCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0.00" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalBudCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr>
                                <td align="center" style="height:60px; background-color:#FFFFFF; color:#000000;">
                                  <asp:Label ID="lblTotalBudPrdCost" runat="server" Font-Size="13px" Font-Bold="true" Text="0" />
                                  <br /><span style="font-size:13px;">V/S</span><br />
                                  <asp:Label ID="lblTotalCostedPrdCost" runat="server" Font-Size="13px" Font-Bold="true" Text="0" />
                                </td>
                              </tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;" >
                    <asp:GridView ID="gvFactoryDetails2" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-Height="25px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="30px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvFactoryDetails2_RowDataBound" FooterStyle-BackColor="LightGray" OnRowCreated="gvFactoryDetails2_RowCreated">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" Visible="false">
                          <HeaderTemplate>Calc Count</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCalcCount" runat="server"  Text='<%# (Convert.ToInt32(Eval("CalcCount")) == 0) ? "" : Eval("CalcCount") %>' CssClass="CalcCount"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyCalcCount" runat="server" Font-Size="15px" Font-Bold="true" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCalcCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color: #FFFFFF;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="124px" ItemStyle-BackColor="#feff99" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Bud Count</HeaderTemplate>
                          <ItemTemplate>
                            <asp:HiddenField ID="hdnRowId" runat="server" Value='<%#Eval("RowId") %>' />
                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Eval("ProductionUnitId") %>' />
                            <asp:HiddenField ID="hdnWorkerTypeId" runat="server" Value='<%#Eval("FactoryWorkSpace") %>' />
                            <asp:TextBox ID="txtBudCount" runat="server" MaxLength="4" Width="50px" Font-Size="14px" BackColor="#feff99" BorderColor="#feff99" CssClass="BudCount" AutoPostBack="true" OnTextChanged="txtBudCount2_TextChanged" onkeypress="Javascript:return isNumberKey(event);"></asp:TextBox>
                            <asp:HiddenField ID="hdnOldBudCount" runat="server" />
                            <asp:HiddenField ID="hdnValuesToBudCost" runat="server" Value='<%#Eval("ValuesToGetBudCost") %>' />
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblMonthlyTotalBudCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalBudCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color: #feff99;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" Visible="false">
                          <HeaderTemplate>Calc Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCalcCost" runat="server" Font-Size="12px" Text='<%# (Convert.ToInt32(Eval("CalcCost")) == 0) ? "" : Eval("CalcCost") %>' ForeColor="#405D99"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyCalcCost" runat="server" Font-Size="15px" Font-Bold="true" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCalcCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color:#FFFFFF;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="124px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Bud Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblBudCost" runat="server" Font-Size="12px" Text='<%# (Convert.ToInt32(Eval("BudCost")) == 0) ? "" : Eval("BudCost") %>' ForeColor="#405D99"></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyBudCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0.00" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalBudCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr>
                                <td align="center" style="height:60px; background-color:#FFFFFF; color:#000000;">
                                  <asp:Label ID="lblTotalBudPrdCost" runat="server" Font-Size="13px" Font-Bold="true" Text="0" />
                                  <br /><span style="font-size:13px;">V/S</span><br />
                                  <asp:Label ID="lblTotalCostedPrdCost" runat="server" Font-Size="13px" Font-Bold="true" Text="0" />
                                </td>
                              </tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                  <td valign="top" style="width: 310px;" class="hide-td">
                    
                  </td>
                  <td valign="top" style="width: 310px;">
                    <asp:GridView ID="gvFactoryDetails4" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true" FooterStyle-Height="25px" FooterStyle-ForeColor="#7E7E7E"
                      ShowHeader="true" HeaderStyle-Height="30px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF" HeaderStyle-BackColor="#405D99"
                      RowStyle-Height="30px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvFactoryDetails4_RowDataBound" FooterStyle-BackColor="LightGray" OnRowCreated="gvFactoryDetails4_RowCreated">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" Visible="false">
                          <HeaderTemplate>Calc Count</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCalcCount" runat="server" CssClass="CalcCount"  Text='<%# (Convert.ToInt32(Eval("CalcCount")) == 0) ? "" : Eval("CalcCount") %>' ></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyCalcCount" runat="server" Font-Size="15px" Font-Bold="true" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCalcCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color: #FFFFFF;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="124px" ItemStyle-BackColor="#feff99" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Bud Count</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblBudCount" runat="server" Font-Size="12px" Text='<%#Eval("BudCount") %>'></asp:Label>
                            <asp:HiddenField ID="hdnValuesToBudCost" runat="server" Value='<%#Eval("ValuesToGetBudCost") %>' />
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblMonthlyTotalBudCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalBudCount" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color: #feff99;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="62px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" Visible="false">
                          <HeaderTemplate>Calc Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCalcCost" runat="server" Font-Size="12px" Text='<%# (Convert.ToInt32(Eval("CalcCost")) == 0) ? "" : Eval("CalcCost") %>' ForeColor="#405D99"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyCalcCost" runat="server" Font-Size="15px" Font-Bold="true" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalCalcCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:60px; background-color:#FFFFFF;"></td></tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="124px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                          <HeaderTemplate>Bud Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblBudCost" runat="server" Font-Size="12px" Text='<%# (Convert.ToInt32(Eval("BudCost")) == 0) ? "" : Eval("BudCost") %>' ForeColor="#405D99"></asp:Label>
                            <asp:HiddenField ID="hdnOldBudCost" runat="server" />
                          </ItemTemplate>
                          <FooterTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td align="center" style="height:35px;"><asp:Label ID="lblTotalMonthlyBudCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0.00" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr><td align="center" style="height:35px; background-color: #E7E7E7;"><asp:Label ID="lblTotalBudCost" runat="server" Font-Size="15px" Font-Bold="true" Text="0" /></td></tr>
                              <tr><td style="height:1px; background-color:#7E7E7E;"></td></tr>
                              <tr>
                                <td align="center" style="height:60px; background-color:#FFFFFF; color:#000000;">
                                  <asp:Label ID="lblTotalBudPrdCost" runat="server" Font-Size="13px" Font-Bold="true" Text="0" />
                                  <br /><span style="font-size:13px;">V/S</span><br />
                                  <asp:Label ID="lblTotalCostedPrdCost" runat="server" Font-Size="13px" Font-Bold="true" Text="0" />
                                </td>
                              </tr>
                            </table>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView> 
                  </td>
                </tr>
                <tr><td colspan="4" style="height:25px;"></td></tr>
                <tr>
                  <td colspan="4">
                    <asp:GridView ID="gvCPAMHeader" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader" RowStyle-BackColor="#405D99" RowStyle-ForeColor="#FFFFFF"
                      Width="100%" ShowHeader="false" RowStyle-Height="25px" OnRowDataBound="gvCPAMHeader_rowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblHeader" runat="server" Font-Size="16px" Text=''></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="16px" Text='<%#Eval("Column2") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="16px" Text='<%#Eval("Column3") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="16px" Text='<%#Eval("Column4") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                          <ItemStyle CssClass="hide-td" />
                          <HeaderStyle CssClass="hide-td" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="16px" Text='<%#Eval("Column5") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                </tr>
                <tr>
                  <td style="width:310px;">
                    <asp:GridView ID="gvStaffDept" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" ShowFooter="true" FooterStyle-Height="25px"
                      RowStyle-Height="25px" RowStyle-ForeColor="#7E7E7E" FooterStyle-ForeColor="#7E7E7E" OnRowDataBound="gvStaffDept_RowDataBound">
                      <Columns>                        
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                          <HeaderTemplate></HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblStaffDept" runat="server" CssClass="op-dept" Text='<%#Eval("StaffDept") %>' ></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <asp:Label ID="lblFooterStaffDept" runat="server" Font-Size="16px" Text='CMT (Total)' Font-Bold="true" ForeColor="#405D99"></asp:Label>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                  <td style="width:310px;">
                    <asp:GridView ID="gvCPAMFactory1" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="true" ShowFooter="true" FooterStyle-Height="25px" HeaderStyle-Height="25px"
                      RowStyle-Height="25px" HeaderStyle-BackColor="#405D99" FooterStyle-ForeColor="#7E7E7E" HeaderStyle-Font-Size="14px" HeaderStyle-ForeColor="#FFFFFF" RowStyle-ForeColor="#7E7E7E"
                      OnRowDataBound="gvCPAMFactory1_RowDataBound" FooterStyle-HorizontalAlign="Center" FooterStyle-Font-Size="16px" FooterStyle-Font-Bold="true">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="110px">
                          <HeaderTemplate>CPAM</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCPAM" runat="server" Font-Size="12px" Text='<%#Eval("CPAM") %>' ForeColor="#405D99"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <asp:Label ID="lblTotalCPAM" runat="server" Font-Size="16px" Font-Bold="true" ForeColor="#405D99"></asp:Label>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Share" HeaderText="% Share" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="14px" ItemStyle-Width="100px" />
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                          <HeaderTemplate>CMT Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCMTCost" runat="server"  Text='<%#Eval("CMTCost") %>' CssClass="CMTCost"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <asp:Label ID="lblTotalCMTCost" runat="server" Font-Size="16px" Font-Bold="true" ForeColor="#405D99"></asp:Label>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                  <td style="width:310px;">
                    <asp:GridView ID="gvCPAMFactory2" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="true" ShowFooter="true" FooterStyle-Height="25px" HeaderStyle-Height="25px"
                      RowStyle-Height="25px" HeaderStyle-BackColor="#405D99" FooterStyle-ForeColor="#7E7E7E" HeaderStyle-Font-Size="14px" HeaderStyle-ForeColor="#FFFFFF" RowStyle-ForeColor="#7E7E7E"
                      OnRowDataBound="gvCPAMFactory2_RowDataBound" FooterStyle-HorizontalAlign="Center" FooterStyle-Font-Size="16px" FooterStyle-Font-Bold="true">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="110px">
                          <HeaderTemplate>CPAM</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCPAM" runat="server" Font-Size="12px" Text='<%#Eval("CPAM") %>' ForeColor="#405D99"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <asp:Label ID="lblTotalCPAM" runat="server" Font-Size="16px" Font-Bold="true" ForeColor="#405D99"></asp:Label>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Share" HeaderText="% Share" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="14px" ItemStyle-Width="100px" />
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                          <HeaderTemplate>CMT Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCMTCost" runat="server" CssClass="CMTCost" Text='<%#Eval("CMTCost") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <asp:Label ID="lblTotalCMTCost" runat="server" Font-Size="16px" Font-Bold="true" ForeColor="#405D99"></asp:Label>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                  <td style="width:310px;" class="hide-td">
                    
                  </td>
                  <td style="width:310px;">
                    <asp:GridView ID="gvCPAMFactory4" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="true" ShowFooter="true" FooterStyle-Height="25px" HeaderStyle-Height="25px"
                      RowStyle-Height="25px" HeaderStyle-BackColor="#405D99" FooterStyle-ForeColor="#7E7E7E" HeaderStyle-Font-Size="14px" HeaderStyle-ForeColor="#FFFFFF" RowStyle-ForeColor="#7E7E7E"
                      OnRowDataBound="gvCPAMFactory4_RowDataBound" FooterStyle-HorizontalAlign="Center" FooterStyle-Font-Size="16px" FooterStyle-Font-Bold="true">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="110px">
                          <HeaderTemplate>CPAM</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCPAM" runat="server" Font-Size="12px" Text='<%#Eval("CPAM") %>' ForeColor="#405D99"></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <asp:Label ID="lblTotalCPAM" runat="server" Font-Size="16px" Font-Bold="true" ForeColor="#405D99"></asp:Label>
                          </FooterTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Share" HeaderText="% Share" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="14px" ItemStyle-Width="100px" />
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                          <HeaderTemplate>CMT Cost</HeaderTemplate>
                          <ItemTemplate>
                            <asp:Label ID="lblCMTCost" runat="server" CssClass="CMTCost" Text='<%#Eval("CMTCost") %>'></asp:Label>
                          </ItemTemplate>
                          <FooterTemplate>
                            <asp:Label ID="lblTotalCMTCost" runat="server" Font-Size="16px" Font-Bold="true" ForeColor="#405D99"></asp:Label>
                          </FooterTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                </tr>
                <tr><td colspan="4" style="height:35px;"></td></tr>
                <tr>
                  <td colspan="4">
                    <asp:GridView ID="gvBudMmr" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="SalesHeader" RowStyle-BackColor="#405D99" RowStyle-ForeColor="#FFFFFF"
                      Width="100%" ShowHeader="false" RowStyle-Height="25px" OnRowDataBound="gvBudMmr_rowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblHeader" runat="server" Font-Size="12px" Text=''></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="16px" Text='<%#Eval("Column2") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="16px" Text='<%#Eval("Column3") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="16px" Text='<%#Eval("Column4") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                          <ItemStyle CssClass="hide-td" />
                          <HeaderStyle CssClass="hide-td" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="16px" Text='<%#Eval("Column5") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                </tr>
                <tr>
                  <td colspan="4">
                    <asp:GridView ID="gvBudgetMMRDetails" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" HeaderStyle-Height="25px"
                      RowStyle-Height="25px" RowStyle-ForeColor="#7E7E7E" OnRowDataBound="gvBudgetMMRDetails_rowDataBound">
                      <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblHeader" runat="server" CssClass="op-dept" Text='<%#Eval("Column1") %>'></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails1" runat="server" Font-Size="12px"  Text='<%#Eval("Column2") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails2" runat="server" Font-Size="12px" Text='<%#Eval("Column3") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails3" runat="server" Font-Size="12px" Text='<%#Eval("Column4") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                          <ItemStyle CssClass="hide-td" />
                          <HeaderStyle CssClass="hide-td" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                            <asp:Label ID="lblUnitDetails4" runat="server" Font-Size="12px" Text='<%#Eval("Column5") %>' Font-Bold="true"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr><td style="height:30px;"></td></tr>
        </table>
      </ContentTemplate>
    </asp:updatepanel>
  </div>
  </form>
</body>
</html>
