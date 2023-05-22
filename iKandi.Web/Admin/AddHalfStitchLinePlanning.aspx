<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHalfStitchLinePlanning.aspx.cs" Inherits="iKandi.Web.Admin.AddHalfStitchLinePlanning" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
  <link rel="stylesheet" type="text/css" href="../App_Themes/ikandi/ikandi1.css" />
  <link rel="stylesheet" type="text/css" href="../../css/jquery-ui.css" />
  <link rel="stylesheet" type="text/css" href="../../css/datepicker.css" />

  <style type="text/css">
    /* located in demo.css and creates a little calendar icon
     * instead of a text link for "Choose date"
     */
    a.dp-choose-date {
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
    a.dp-choose-date.dp-disabled {
	    background-position: 0 -20px;
	    cursor: default;
    }
    /* makes the input field shorter once the date picker code
     * has run (to allow space for the calendar icon
     */
    input.dp-applied {
	    width: 140px;
	    float: left;
    }
    .txt
    {
      width: 20px;
      text-align: center;
      color:#7E7E7E;
    }
      #spinn2
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        .FontSize
        {
            font-size:10px;
        }
  </style>
</head>
<body bgcolor="#FFFFFF">
<script type="text/javascript" src="../js/service.min.js"></script>
 <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>  
 <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-1.4.4.min.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/facebox.js")%>'></script> 
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/js.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/ImageFaceBox.js")%>'></script>   
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/colorpicker.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/fna.js")%>' type="text/javascript"></script>
   <script type="text/javascript" src='<%= Page.ResolveUrl("../js/date.js")%>'></script>


   <script type="text/javascript">
       var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
       var proxy = new ServiceProxy(serviceUrl);

       $(function () {
           //$('.date-pick').datePicker();
           MyDatePickerFunction();
           Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MyDatePickerFunction);
       });

       function SpinnShow() {
           $("#spinn2").css("display", "block");
       }

       function MyDatePickerFunction() {
           //debugger;  
           var TDate = new Date();
           var CDate = new Date();
           var MDate = CDate.addDays(30);
           $(".date-picker").datepicker({ dateFormat: "dd M y (D)", minDate: TDate, maxDate: MDate }).val();

       }

       function ValidateData() {
           var txtStartDate = $('#<%= txtStartDate.ClientID %>');
           if (txtStartDate.val() == '') {
               jQuery.facebox('Start Date can not be empty!');
               return false;
           }
           ddlSlot = $('#<%= ddlSlot.ClientID %> option:selected').val();
           if (ddlSlot == '0') {
               jQuery.facebox('Please Select start slot!');
               return false;
           }
       }

       function isNumberKey(evt) {
           var charCode = (evt.which) ? evt.which : event.keyCode

           if (charCode > 31 && (charCode < 48 || charCode > 57))
               return false;

           return true;
       }

       function ValidateLineQty(obj) {
                  //debugger;
                  var cId = obj.id.split("_")[1].substr(3);
                  var ReplicaQty = obj.value;

                  var hdnfirstLineQty = $("#<%= gvReplica.ClientID %> input[id*='ctl" + cId + "_hdnfirstLineQty" + "']").val();
                  
                  if (parseInt(ReplicaQty) > 0) {

                      if (parseInt(ReplicaQty) > parseInt(hdnfirstLineQty)) {
                          jQuery.facebox('input qty can not be greater than Total Qty');
                          obj.value = '';
                          return false;
                      }
                      var RemainQty = parseInt(hdnfirstLineQty) - parseInt(ReplicaQty);
                      $("#<%= gvReplica.ClientID %> input[id*='ctl" + cId + "_txtFirstLineQty" + "']").val(RemainQty);
                  }
                  else {
                      $("#<%= gvReplica.ClientID %> input[id*='ctl" + cId + "_txtFirstLineQty" + "']").val(hdnfirstLineQty);
                  }
              }


  </script>


  <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div id="spinn2" runat="server"></div>
  <div>
     <asp:UpdatePanel ID="udpnlLinePlan" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
    <table border="0" cellpadding="0" cellspacing="0" width="575px" align="center">
      <tr>
        <td style="padding-top: 20px;">
          <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
              <td colspan="2" align="center" style="height:34px; background-color:#405D99; color:#FFFFFF; font-size:12px; font-weight:bold; text-align:center;  font-family:Verdana;">Add Half Stitch Factory Specific Line Planning</td>
              <td align="right" style="height:30px; background-color:#405D99; text-align:center;"><asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" /></td>
            </tr>           
            <tr>
              <td align="left" style="padding-top:15px; padding-bottom:15px; width:40%; color:#405D99; font-size:11px;  font-family:Verdana;">
                <span style="font-weight:bold;">Factory&nbsp;&nbsp;</span><asp:Label ID="lblFactory" runat="server" ForeColor="#7E7E7E"></asp:Label>
              </td>
              <td align="left" style="padding-top:15px; padding-bottom:15px; width:40%; color:#405D99; font-size:11px;  font-family:Verdana;">
                <span style="font-weight:bold;">Floor&nbsp;&nbsp;</span><asp:Label ID="lblFloorNo" runat="server" ForeColor="#7E7E7E"></asp:Label>
              </td>
              <td align="left" style="padding-top:15px; padding-bottom:15px; padding-right:10px; width:20%; color:#405D99; font-size:11px;  font-family:Verdana;">
                <span id="spanline" runat="server" style="font-weight:bold;">Line&nbsp;&nbsp;</span><asp:Label ID="lblLineNo" runat="server" ForeColor="#7E7E7E"></asp:Label>
              </td>
            </tr>
              <tr><td style="width:600px;" colspan="3">    
                       <div style="float:left; width:250px"> <asp:RadioButtonList ID="rbtnList" AutoPostBack="true"
                               RepeatDirection="Horizontal" runat="server" ForeColor="#7E7E7E" 
                               onselectedindexchanged="rbtnList_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="Sequence Frame" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Parallel Frame"></asp:ListItem>
                        </asp:RadioButtonList> 
                        </div>
                        &nbsp;&nbsp; 
                        <div style="float:left; width:200px; margin-top:5px;">
                        <asp:DropDownList ID="ddlFrame" AutoPostBack="true"  runat="server" 
                                ForeColor="#000000" onselectedindexchanged="ddlFrame_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                        </div>
                        </td></tr> 
              <tr id="trSlot" runat="server">
              <td align="left" style="padding-top:25px; padding-bottom:25px; width:33%; color:#405D99; font-size:11px; font-family:Verdana;">
                <table border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td align="right" style="width:50%;"><span style="font-weight:bold;">Start Date&nbsp;&nbsp;</span></td>
                    <td align="left" style="width:50%;">
                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="date-picker" Width="100px" ForeColor="#000000"></asp:TextBox>                   
                    </td>
                  </tr>
                </table>
              </td>
              <td align="left" colspan="2" style="padding-top:25px; padding-bottom:25px; width:67%; color:#405D99; font-size:11px; font-family:Verdana;">
                <span style="font-weight:bold;">Slot&nbsp;&nbsp;</span><asp:DropDownList ID="ddlSlot" runat="server" Width="100px" Font-Bold="false" ForeColor="#7E7E7E" AutoPostBack="false" OnSelectedIndexChanged="ddlSlot_SelectedIndexChanged"></asp:DropDownList>
                &nbsp;&nbsp;<asp:Label ID="lblSlot" runat="server" ForeColor="#7E7E7E" Font-Size="12px"></asp:Label> 
              </td>
            </tr> 
            <tr>
              <td colspan="3" align="left" style="padding-top:15px; padding-bottom:15px; width:100%; color:#405D99; font-size:11px;  font-family:Verdana;">
                <span style="font-weight:bold;">Copy From FrameNo.&nbsp;&nbsp;</span><asp:DropDownList ID="ddlCopyFrom" runat="server" Width="100px" Font-Bold="false" ForeColor="#7E7E7E" AutoPostBack="true" OnSelectedIndexChanged="ddlCopyFrom_SelectedIndexChanged"></asp:DropDownList>
                &nbsp;&nbsp;
                  <asp:Label ID="lblFullStitchFrame" Visible="false" runat="server" Text="Full Stitch frame"></asp:Label>&nbsp;&nbsp;
                  <asp:DropDownList ID="ddlFullStitchFrame" Visible="false" runat="server">
                  </asp:DropDownList>
                  <asp:Label ID="lblReplica" runat="server" Visible="false" Text="Make a Replica"></asp:Label>
                  <asp:CheckBox ID="chkReplica" Visible="false" AutoPostBack="true"  
                      runat="server" oncheckedchanged="chkReplica_CheckedChanged" />
                  <asp:DropDownList ID="ddlOutHouseFactory" Visible="false" AutoPostBack="true" runat="server" 
                      onselectedindexchanged="ddlOutHouseFactory_SelectedIndexChanged">
                  </asp:DropDownList>
             </td>
            </tr>          
            <tr>
            <td colspan="3">
            <asp:GridView ID="gvReplica" Visible="false" runat="server" AutoGenerateColumns="false"
                                    Width="98%" ShowHeader="true" HeaderStyle-Height="35px" 
                                    HeaderStyle-Font-Size="10px" HeaderStyle-Font-Names="Verdana"
                                    HeaderStyle-HorizontalAlign="Center" 
                    HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#405D99"
                                    HeaderStyle-BackColor="#F0F3F2" RowStyle-Height="35px" RowStyle-HorizontalAlign="Center"
                                    RowStyle-ForeColor="#7E7E7E" 
                    ondatabound="gvReplica_DataBound" onrowdatabound="gvReplica_RowDataBound">
                                    <RowStyle CssClass="gvRow" />                                   
                                    <Columns>    
                                     <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="100px" ItemStyle-VerticalAlign="Middle">                                        
                                        <ItemTemplate> 
                                                                 
                                            <asp:Label ID="lblStyleNo" runat="server" Text='<%# Eval("StyleNumber") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnStyleId" Value='<%# Eval("StyleId") %>' runat="server" />
                                        </ItemTemplate>                                           
                                        </asp:TemplateField>
                                                                            
                                        <asp:TemplateField  HeaderText="Serial No." HeaderStyle-Width="60px" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>                                             
                                               <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber") %>' ForeColor="Black" Font-Bold="true"></asp:Label>
                                               <asp:HiddenField ID="hdnOrderId" Value='<%# Eval("OrderID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contract No." HeaderStyle-Width="80px">
                                            <ItemTemplate>                                              
                                                <asp:Label ID="lblContractNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnOrderDetailId" Value='<%# Eval("OrderDetailsID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                          
                                    
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtFirstLineQty" Width="50px" BorderColor="White" Text='<%# Eval("LineQty") %>' runat="server" Font-Size="11px"></asp:TextBox>
                                                <asp:HiddenField ID="hdnContractQty" Value='<%# Eval("ContractQty") %>' runat="server" />
                                                <asp:HiddenField ID="hdnUnitQty" Value='<%# Eval("UnitQty") %>' runat="server" />
                                                <asp:HiddenField ID="hdnfirstLineQty" Value='<%# Eval("LineQty") %>' runat="server" />
                                            </ItemTemplate>                                           
                                        </asp:TemplateField>

                                        
                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtReplicaLineQty" Text="" onkeypress="return isNumberKey(event)" onblur="javascript:return ValidateLineQty(this)"
                                                 runat="server" Font-Size="11px" Width="45px" MaxLength="5"></asp:TextBox>                                                
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                  
                                    </Columns>
                                </asp:GridView>
            </td>
            </tr>
            <%--<tr><td colspan="3"></td></tr>--%>
            <tr id="trSubmit" runat="server" visible="false">
              <td colspan="3" align="right" style="padding-right:10px; padding-top:10px;">
                <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit" OnClientClick="ValidateData();" OnClick="btnSubmit_Click" />
              </td>
            </tr>
            <tr>
              <td colspan="3" align="right" visible="false" style="height:20px; font-family:Verdana;">
                <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Font-Size="11px"></asp:Label>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
       </ContentTemplate>
              </asp:UpdatePanel>  
  </div>
  </form>
   <script type="text/javascript">
       $(window).load(function () { $("#spinn2").fadeOut("slow"); }); //Gajendra     
    </script>
</body>
</html>
