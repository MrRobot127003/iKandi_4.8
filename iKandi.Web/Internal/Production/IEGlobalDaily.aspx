<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IEGlobalDaily.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.IEGlobalDaily" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../../js/jquery.jcarousel.js" type="text/javascript"></script>
    <script src="../../js/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style>
        .AddCuurency::after
        {
            content: "₹";
            color: green;
            font-size: 12px;
            position: relative;
            top: 1px;
        }
    </style>
    <script type="text/javascript">
        function validateFloatKeyPress(el, evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            var number = el.value.split('.');
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            //just one dot
            if (number.length > 1 && charCode == 46) {
                return false;
            }
            //get the carat position
            var caratPos = getSelectionStart(el);
            var dotPos = el.value.indexOf(".");
            if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
                return false;
            }
            return true;
        }


        function getSelectionStart(o) {
            if (o.createTextRange) {
                var r = document.selection.createRange().duplicate()
                r.moveEnd('character', o.value.length)
                if (r.text == '') return o.value.length
                return o.value.lastIndexOf(r.text)
            } else return o.selectionStart
        }
        function ValidateEmpty() {
            debugger;
            if (($('#txtCutRate_C45_46').val() == "" || $('#txtCutRate_C45_46').val() == ".")
            || ($('#txtFinishingRate_C45_46').val() == "" || $('#txtFinishingRate_C45_46').val() == ".")
            || ($('#txtStitching_C45_46').val() == "" || $('#txtStitching_C45_46').val() == ".")
            || ($('#txtAchievement_C45_46').val() == "" || $('#txtAchievement_C45_46').val() == ".")

            || ($('#txtCutRate_C47').val() == "" || $('#txtCutRate_C47').val() == ".")
            || ($('#txtFinishingRate_C47').val() == "" || $('#txtFinishingRate_C47').val() == ".")
            || ($('#txtStitching_C47').val() == "" || $('#txtStitching_C47').val() == ".")
            || ($('#txtAchievement_C47').val() == "" || $('#txtAchievement_C47').val() == ".")

            || ($('#txtCutRate_D169').val() == "" || $('#txtCutRate_D169').val() == ".")
            || ($('#txtFinishingRate_D169').val() == "" || $('#txtFinishingRate_D169').val() == ".")
            || ($('#txtStitching_D169').val() == "" || $('#txtStitching_D169').val() == ".")
            || ($('#txtAchievement_D169').val() == "" || $('#txtAchievement_D169').val() == ".")

            || ($('#txtCutRate_BIPL').val() == "" || $('#txtCutRate_BIPL').val() == ".")
            || ($('#txtFinishingRate_BIPL').val() == "" || $('#txtFinishingRate_BIPL').val() == ".")
            || ($('#txtStitching_BIPL').val() == "" || $('#txtStitching_BIPL').val() == ".")
            || ($('#txtAchievement_BIPL').val() == "" || $('#txtAchievement_BIPL').val() == ".")

            || ($('#txtCutQty_C45_46').val() == "" || $('#txtCutQty_C45_46').val() == ".")
            || ($('#txtFinishedQty_C45_46').val() == "" || $('#txtFinishedQty_C45_46').val() == ".")
            || ($('#txtStitchedQty_C45_46').val() == "" || $('#txtStitchedQty_C45_46').val() == ".")

            || ($('#txtCutQty_C47').val() == "" || $('#txtCutQty_C47').val() == ".")
            || ($('#txtFinishedQty_C47').val() == "" || $('#txtFinishedQty_C47').val() == ".")
            || ($('#txtStitchedQty_C47').val() == "" || $('#txtStitchedQty_C47').val() == ".")

            || ($('#txtCutQty_D169').val() == "" || $('#txtCutQty_D169').val() == ".")
            || ($('#txtFinishedQty_D169').val() == "" || $('#txtFinishedQty_D169').val() == ".")
            || ($('#txtStitchedQty_D169').val() == "" || $('#txtStitchedQty_D169').val() == ".")

            || ($('#txtCutQty').val() == "" || $('#txtCutQty').val() == ".")
            || ($('#txtFinishedQty').val() == "" || $('#txtFinishedQty').val() == ".")
            || ($('#txtStitchedQty').val() == "" || $('#txtStitchedQty').val() == ".")
            ) {
                alert("Please Fill All Entry!");
                return false;
            }
            //            if(($('#txtCutRate_C47').val() == "" || $('#txtCutRate_C47').val() == ".")
            //            && ($('#txtFinishingRate_C47').val() == "" || $('#txtFinishingRate_C47').val() == ".")
            //            && ($('#txtStitching_C47').val() == "" || $('#txtStitching_C47').val() == ".")){
            //                alert("Enter atleast one rate");
            //                return false;
            //            }

            //            if(($('#txtCutRate_D169').val() == "" || $('#txtCutRate_D169').val() == ".")
            //            && ($('#txtFinishingRate_D169').val() == "" || $('#txtFinishingRate_D169').val() == ".")
            //            && ($('#txtStitching_D169').val() == "" || $('#txtStitching_D169').val() == ".")){
            //              alert("Enter atleast one rate");
            //                return false;
            //            }

            //            if(($('#txtCutRate_BIPL').val() == "" || $('#txtCutRate_BIPL').val() == ".")
            //            && ($('#txtFinishingRate_BIPL').val() == "" || $('#txtFinishingRate_BIPL').val() == ".")
            //            && ($('#txtStitching_BIPL').val() == "" || $('#txtStitching_BIPL').val() == ".")){
            //             alert("Enter atleast one rate");
            //                return false;
            //            }
            if ((parseFloat($('#txtCutRate_C45_46').val()) == 0.00) || (parseFloat($('#txtFinishingRate_C45_46').val()) == 0.00) || (parseFloat($('#txtStitching_C45_46').val()) == 0.00) || (parseFloat($('#txtAchievement_C45_46').val()) == 0.00)
            || (parseFloat($('#txtCutQty_C45_46').val()) == 0.00) || (parseFloat($('#txtFinishedQty_C45_46').val()) == 0.00) || (parseFloat($('#txtStitchedQty_C45_46').val()) == 0.00)
            || (parseFloat($('#txtCutQty_C47').val()) == 0.00) || (parseFloat($('#txtFinishedQty_C47').val()) == 0.00) || (parseFloat($('#txtStitchedQty_C47').val()) == 0.00)
            || (parseFloat($('#txtCutQty_D169').val()) == 0.00) || (parseFloat($('#txtFinishedQty_D169').val()) == 0.00) || (parseFloat($('#txtStitchedQty_D169').val()) == 0.00)
            || (parseFloat($('#txtCutQty').val()) == 0.00) || (parseFloat($('#txtFinishedQty').val()) == 0.00) || (parseFloat($('#txtStitchedQty').val()) == 0.00)
            || (parseFloat($('#txtCutRate_C47').val()) == 0.00) || (parseFloat($('#txtFinishingRate_C47').val()) == 0.00) || (parseFloat($('#txtStitching_C47').val()) == 0.00) || (parseFloat($('#txtAchievement_C47').val()) == 0.00)
            || (parseFloat($('#txtCutRate_D169').val()) == 0.00) || (parseFloat($('#txtFinishingRate_D169').val()) == 0.00) || (parseFloat($('#txtStitching_D169').val()) == 0.00) || (parseFloat($('#txtAchievement_D169').val()) == 0.00)
            || (parseFloat($('#txtCutRate_BIPL').val()) == 0.00) || (parseFloat($('#txtFinishingRate_BIPL').val()) == 0.00) || (parseFloat($('#txtStitching_BIPL').val()) == 0.00) || (parseFloat($('#txtAchievement_BIPL').val()) == 0.00)
            ) {
                alert("Value cannot Zero!");

                if (parseFloat($('#txtCutQty_C45_46').val()) == 0.00) {
                    $('#txtCutQty_C45_46').val("");
                }
                if (parseFloat($('#txtFinishedQty_C45_46').val()) == 0.00) {
                    $('#txtFinishedQty_C45_46').val("");
                }
                if (parseFloat($('#txtStitchedQty_C45_46').val()) == 0.00) {
                    $('#txtStitchedQty_C45_46').val("");
                }
                if (parseFloat($('#txtCutQty_C47').val()) == 0.00) {
                    $('#txtCutQty_C47').val("");
                }
                if (parseFloat($('#txtFinishedQty_C47').val()) == 0.00) {
                    $('#txtFinishedQty_C47').val("");
                }
                if (parseFloat($('#txtStitchedQty_C47').val()) == 0.00) {
                    $('#txtStitchedQty_C47').val("");
                }
                if (parseFloat($('#txtCutQty_D169').val()) == 0.00) {
                    $('#txtCutQty_D169').val("");
                }
                if (parseFloat($('#txtFinishedQty_D169').val()) == 0.00) {
                    $('#txtFinishedQty_D169').val("");
                }
                if (parseFloat($('#txtStitchedQty_D169').val()) == 0.00) {
                    $('#txtStitchedQty_D169').val("");
                }
                if (parseFloat($('#txtCutQty').val()) == 0.00) {
                    $('#txtCutQty').val("");
                }
                if (parseFloat($('#txtFinishedQty').val()) == 0.00) {
                    $('#txtFinishedQty').val("");
                }
                if (parseFloat($('#txtStitchedQty').val()) == 0.00) {
                    $('#txtStitchedQty').val("");
                }

                if (parseFloat($('#txtCutRate_C45_46').val()) == 0.00) {
                    $('#txtCutRate_C45_46').val("");
                }
                if (parseFloat($('#txtFinishingRate_C45_46').val()) == 0.00) {
                    $('#txtFinishingRate_C45_46').val("");
                }
                if (parseFloat($('#txtStitching_C45_46').val()) == 0.00) {
                    $('#txtStitching_C45_46').val("");
                }
                if (parseFloat($('#txtAchievement_C45_46').val()) == 0.00) {
                    $('#txtAchievement_C45_46').val("");
                }

                if (parseFloat($('#txtCutRate_C47').val()) == 0.00) {
                    $('#txtCutRate_C47').val("");
                }
                if (parseFloat($('#txtFinishingRate_C47').val()) == 0.00) {
                    $('#txtFinishingRate_C47').val("");
                }
                if (parseFloat($('#txtStitching_C47').val()) == 0.00) {
                    $('#txtStitching_C47').val("");
                }
                if (parseFloat($('#txtAchievement_C47').val()) == 0.00) {
                    $('#txtAchievement_C47').val("");
                }

                if (parseFloat($('#txtCutRate_D169').val()) == 0.00) {
                    $('#txtCutRate_D169').val("");
                }
                if (parseFloat($('#txtFinishingRate_D169').val()) == 0.00) {
                    $('#txtFinishingRate_D169').val("");
                }
                if (parseFloat($('#txtStitching_D169').val()) == 0.00) {
                    $('#txtStitching_D169').val("");
                }
                if (parseFloat($('#txtAchievement_D169').val()) == 0.00) {
                    $('#txtAchievement_D169').val("");
                }

                if (parseFloat($('#txtCutRate_BIPL').val()) == 0.00) {
                    $('#txtCutRate_BIPL').val("");
                }
                if (parseFloat($('#txtFinishingRate_BIPL').val()) == 0.00) {
                    $('#txtFinishingRate_BIPL').val("");
                }
                if (parseFloat($('#txtStitching_BIPL').val()) == 0.00) {
                    $('#txtStitching_BIPL').val("");
                }
                if (parseFloat($('#txtAchievement_BIPL').val()) == 0.00) {
                    $('#txtAchievement_BIPL').val("");
                }
                return false;
            }

            if (parseFloat($('#txtCutQty_C45_46').val()) ==".") {
                $('#txtCutQty_C45_46').val("");
            }
            if (parseFloat($('#txtFinishedQty_C45_46').val()) ==".") {
                $('#txtFinishedQty_C45_46').val("");
            }
            if (parseFloat($('#txtStitchedQty_C45_46').val()) ==".") {
                $('#txtStitchedQty_C45_46').val("");
            }
            if (parseFloat($('#txtCutQty_C47').val()) ==".") {
                $('#txtCutQty_C47').val("");
            }
            if (parseFloat($('#txtFinishedQty_C47').val()) ==".") {
                $('#txtFinishedQty_C47').val("");
            }
            if (parseFloat($('#txtStitchedQty_C47').val()) ==".") {
                $('#txtStitchedQty_C47').val("");
            }
            if (parseFloat($('#txtCutQty_D169').val()) ==".") {
                $('#txtCutQty_D169').val("");
            }
            if (parseFloat($('#txtFinishedQty_D169').val()) ==".") {
                $('#txtFinishedQty_D169').val("");
            }
            if (parseFloat($('#txtStitchedQty_D169').val()) ==".") {
                $('#txtStitchedQty_D169').val("");
            }
            if (parseFloat($('#txtCutQty').val()) ==".") {
                $('#txtCutQty').val("");
            }
            if (parseFloat($('#txtFinishedQty').val()) ==".") {
                $('#txtFinishedQty').val("");
            }
            if (parseFloat($('#txtStitchedQty').val()) ==".") {
                $('#txtStitchedQty').val("");
            }

            if ($('#txtCutRate_C45_46').val() == ".") {
                $('#txtCutRate_C45_46').val("");
            }
            if ($('#txtFinishingRate_C45_46').val() == ".") {
                $('#txtFinishingRate_C45_46').val("");
            }
            if ($('#txtStitching_C45_46').val() == ".") {
                $('#txtStitching_C45_46').val("");
            }
            if ($('#txtAchievement_C45_46').val() == ".") {
                $('#txtAchievement_C45_46').val("");
            }

            if ($('#txtCutRate_C47').val() == ".") {
                $('#txtCutRate_C47').val("");
            }
            if ($('#txtFinishingRate_C47').val() == ".") {
                $('#txtFinishingRate_C47').val("");
            }
            if ($('#txtStitching_C47').val() == ".") {
                $('#txtStitching_C47').val("");
            }
            if ($('#txtAchievement_C47').val() == ".") {
                $('#txtAchievement_C47').val("");
            }

            if ($('#txtCutRate_D169').val() == ".") {
                $('#txtCutRate_D169').val("");
            }
            if ($('#txtFinishingRate_D169').val() == ".") {
                $('#txtFinishingRate_D169').val("");
            }
            if ($('#txtStitching_D169').val() == ".") {
                $('#txtStitching_D169').val("");
            }
            if ($('#txtAchievement_C47').val() == ".") {
                $('#txtAchievement_C47').val("");
            }

            if ($('#txtCutRate_BIPL').val() == ".") {
                $('#txtCutRate_BIPL').val("");
            }
            if ($('#txtFinishingRate_BIPL').val() == ".") {
                $('#txtFinishingRate_BIPL').val("");
            }
            if ($('#txtStitching_BIPL').val() == ".") {
                $('#txtStitching_BIPL').val("");
            }
            if ($('#txtAchievement_BIPL').val() == ".") {
                $('#txtAchievement_BIPL').val("");
            }
        }


        function SavedSuccessfully() {
            // debugger;
            alert('Saved Successfully.');
            self.parent.Shadowbox.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-top: 5px; width: 450px; margin: 0px auto 0px">
                <table style="margin: 10px auto 0px" class="AddClass_Table">
                    <tr>
                        <th colspan="6">
                            Global Daily IE
                        </th>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <th>
                            C 45-46
                        </th>
                        <th>
                            C 47
                        </th>
                        <th>
                            D 169
                        </th>
                        <th>
                            BIPL
                        </th>
                    </tr>

                    <tr>
                        <th style="width: 100px; text-align: right">
                            Cut Quantity
                        </th>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutQty_C45_46" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutQty_C47" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutQty_D169" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                    
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutQty" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <th style="width: 100px; text-align: right">
                            Cut Rate (<span class="AddCuurency"></span>)
                        </th>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutRate_C45_46" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutRate_C47" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutRate_D169" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                      
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtCutRate_BIPL" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th style="width: 100px; text-align: right">
                            Finished Quantity
                        </th>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtFinishedQty_C45_46" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtFinishedQty_C47" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtFinishedQty_D169" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                     
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtFinishedQty" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 100px; text-align: right">
                            Finishing Rate (<span class="AddCuurency"></span>)
                        </th>
                        <td>
                            <asp:TextBox ID="txtFinishingRate_C45_46" MaxLength="6" Width="95%" runat="server"
                                onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFinishingRate_C47" MaxLength="6" Width="95%" runat="server" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFinishingRate_D169" MaxLength="6" Width="95%" runat="server"
                                onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                     
                        <td>
                            <asp:TextBox ID="txtFinishingRate_BIPL" MaxLength="6" Width="95%" runat="server"
                                onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th style="width: 100px; text-align: right">
                            Stitched Quantity
                        </th>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtStitchedQty_C45_46" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtStitchedQty_C47" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtStitchedQty_D169" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                    
                        <td style="width: 80px;">
                            <asp:TextBox ID="txtStitchedQty" runat="server" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th style="width: 125px; text-align: right">
                            Stitching Efficiency (<span>%</span>)
                        </th>
                        <td>
                            <asp:TextBox ID="txtStitching_C45_46" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStitching_C47" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStitching_D169" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                     
                        <td>
                            <asp:TextBox ID="txtStitching_BIPL" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 125px; text-align: right">
                            Achievement (<span>%</span>)
                        </th>
                        <td>
                            <asp:TextBox ID="txtAchievement_C45_46" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAchievement_C47" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAchievement_D169" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                   
                        <td>
                            <asp:TextBox ID="txtAchievement_BIPL" MaxLength="6" Width="95%" onkeypress="return validateFloatKeyPress(this,event);"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 5px">
                <asp:CheckBox ID="chkTaskClose" Text="IsTaskClosed" runat="server" />&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnbutton_Com" Text="Submit"
                         OnClick="btnSubmit_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
