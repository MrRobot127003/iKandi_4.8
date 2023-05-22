<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffAttandenceFutureLeavePopup.aspx.cs"
    Inherits="iKandi.Web.Internal.Leave.StaffAttandenceFutureLeavePopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   

    <style>
        .HeaderWidth
        {
            width: 100%;
        }
        .commanWidth
        {
            width: 250px;
            float: left;
            margin: 5px 0px;
        }
        .commanWidth input[type="text"]
        {
            width: 100px;
        }
        .dateWidth
        {
            width: 100%;
            margin: 5px 0px;
        }
        .myTextarea
        {
            display: block;
            width: 100%;
            height: 25px;
            text-transform: capitalize;
           text-align: left;
           color: #545050;
           font-family:Verdana;
        }
        .asterisk_input::after {
content: " *";
    color: #e32;
    position: absolute;
    margin: -3px 14px 35px 2px;
    font-size: medium;
    padding: 6px 26px 16px 0; }
    
    .decoratedErrorField
    {
      
        border: 2px solid red !important;
    }
    
    </style>
    
</head>
<body>
 <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
  
      <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
  

    <form id="form1" runat="server">

   
    
    <script type="text/javascript">

        $(document).ready(function () {
//            $(".th2").datepicker({ dateFormat: 'dd/mm/yyyy' });

        });


        $(function () {
//            $('#input-field-id').bind('keypress', function (e) {
//                e.stopPropagation();
//            });
            $(':input').live('focus', function () {
                $(this).attr('autocomplete', 'off');
            });
            var leavedate = $("#txtto_current").val();
            if ($("#txtto_current").val() == "") {
                leavedate = $("#txttodaydate").val();
            }

            $("input[type=text], textarea,Select").blur(function () {
                $(this).removeAttr('class', 'decoratedErrorField');
            });
//            $("Select").blur(function () {
//                $(this).removeAttr('class', 'decoratedErrorField');
//            });

           // alert($("#txtto_current").val())
            $('#txtattendencedate').datepicker({
                dateFormat: "dd M y (D)",
                minDate: new Date(leavedate),

                onSelect: function () {
                    var date = new Date();
                    $("#txtfrom_future").val("");
                    $("#txtto_future").val("");
                    $(".lvfrom").datepicker({
                        dateFormat: "dd M y (D)",
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 1,
                        autoclose: true,
                        inline: true

                    });
                    $("#txtfrom_future").datepicker("option", "minDate", new Date($("#txtattendencedate").val()));
                }

            });
            $('#txtfrom_future').datepicker({
                dateFormat: "dd M y (D)",
                minDate: new Date($("#txtattendencedate").val()),

                onSelect: function () {
                    var date = new Date();
                    $("#txtto_future").val("");
                    $("#txtto_future").datepicker({
                        dateFormat: "dd M y (D)",
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 1,
                        autoclose: true,
                        inline: true

                    });
                    $("#txtto_future").datepicker("option", "minDate", new Date($("#txtfrom_future").val()));
                    $("#btncall").click();
                }
            });


            $('#txtto_future').datepicker({                
                onSelect: function () {
                    var date = new Date();                                                    
                    $("#btncall").click();
                }
            });

        });
        function noSunday(date) {
            return [date.getDay() != 0, ''];
        }
        function SBClose() { }
        function validatePage() {
//            if ($("#txtattendencedate").val() == "") {
//                $("#txtattendencedate").attr('class', 'decoratedErrorField');
//                alert("Select attendance date");
//                
//                return false;
//            }
             if ($("#ddlstatus").val() == "-1") {
                $("#ddlstatus").attr('class', 'decoratedErrorField');
                alert("Select status");
                return false;
            }
            else if ($("#txtfrom_future").val() == "") {
                $("#txtfrom_future").attr('class', 'decoratedErrorField');
                alert("Select future from date");
                return false;
            }
            else if ($("#txtto_future").val() == "") {
                $("#txtto_future").attr('class', 'decoratedErrorField');
                alert("Select future to date");
                return false;
            }
            else if ($("#txtremarks_future").val() == "") {
                $("#txtremarks_future").attr('class', 'decoratedErrorField');
                alert("Enter remark");
                return false;
            }
        }
        function CallbackMain() {
            alert("Page submit successfully");         
            window.parent.Shadowbox.close();
        }
        function callback() {
            debugger;
            $("#btncall").click();

        }
    </script>
    <div>
    
        <div class="HeaderWidth">
            <h2>
                Future Plan Leave
            </h2>
             All <span style="color: Red; font-size: 12px;">*</span> (asterisk) mark field mandatory
        </div>
       
        <div class="commanWidth">
            Employee Name:
            <asp:Label ID="lblempname" runat="server"></asp:Label>
        </div>
        <div class="commanWidth">
            Dept. Name:
            <asp:Label ID="lbldeptname" runat="server"></asp:Label>
        </div>
        <div class="commanWidth">
            Designation. Name:
            <asp:Label ID="lbldesignationname" runat="server"></asp:Label>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <div style="display:none"  class="dateWidth">
                current running leave : From
                <asp:TextBox ID="txtfrom_current" runat="server" ReadOnly="true"></asp:TextBox>
                To:
                <asp:TextBox ID="txtto_current" runat="server"  ReadOnly="true"></asp:TextBox>

                Today Date: <asp:TextBox ID="txttodaydate" runat="server"  ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div style="display:none" class="commanWidth">
            Attendance Date :<asp:TextBox ID="txtattendencedate" onkeypress="return false;" ReadOnly="true" autocomplete="off"
                title="Choose attendance date" CssClass="attth cc" runat="server"></asp:TextBox>
                <span class="asterisk_input">  </span> 
        </div>
        <div class="commanWidth">
            status:<asp:DropDownList ID="ddlstatus" runat="server">
            </asp:DropDownList>
            <span class="asterisk_input">  </span> 
        </div>
        <div style="clear: both">
        </div>
        <div class="commanWidth">
            From:
            <asp:TextBox ID="txtfrom_future"   runat="server" onchange="callback()" CssClass="lvfrom cc"></asp:TextBox>
            <span class="asterisk_input">  </span> 
        </div>
        <div class="commanWidth">
            To:
            <asp:TextBox ID="txtto_future" runat="server" onchange="callback()" CssClass="lvto cc" ReadOnly="true"></asp:TextBox>
            <span class="asterisk_input">  </span> 
        </div>
        <div class="commanWidth">
            Remarks:
           <asp:TextBox ID="txtremarks_future" autocomplete="off" TextMode="MultiLine" runat="server" CssClass="myTextarea"></asp:TextBox>
           <span class="asterisk_input">  </span> 
        </div>
        
        <div style="clear: both">
        </div>
    </div>
     <div style="clear: both">
        </div>
    <div style="margin: 10px auto; text-align: center">
        <asp:Button ID="btnSubmit" runat="server" OnClientClick="return validatePage()" OnClick="btnSubmit_Click" title="Save record !" CssClass="do-not-include submit tooltip btnsave"
            Text="Submit" />
           <asp:Button ID="btncall" runat="server" OnClick="btncall_Click" style="display:none"
            Text="Submit" />
        <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
            Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
    </div>
    </form>
</body>
</html>
