<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricWrokingRemarks.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricWrokingRemarks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style type="text/css">
.label-remarks
{
    font-family:Verdana;
    text-align:justify;
    font-size:11px;
    line-height:20px;
}
</style>
<script type="text/javascript">


    //    function UpdateEtaRemarks(Flag1, Flag2, rem, sRemarks, ids, BIHStart, BIHEnd, StyleID, AccessoryWorkingID) {
    //        //debugger;
    //        proxy.invoke("UpdateEtaRemarks", { Flag1: Flag1, Flag2: Flag2, remarks: rem, Name: sRemarks, ids: ids, SDate: BIHStart, EDate: BIHEnd, StyleId: StyleID, AccessoryWorkingID: AccessoryWorkingID }, function (result) {
    //          
    //            if (result == "0") {
    //                alert("Start Date should be less Or equal End Date Please Check & Try Again !")
    //                // $(".divRemarksMo").html("");
    //                $(".divRemarksMoETA").show();
    //            }
    //            else {
    //                //jQuery.facebox("Remarks have been submitted successfully");
    //                $(".divRemarksMoETA").html("");
    //                $(".divRemarksMoETA").hide();
    //                window.close();
    //                jQuery(document).trigger('close.facebox');
    //                $(".go").click();
    //            }
    //        }, onPageError, false, false);
    //    }




   

</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<body>
    <form id="form1" runat="server">
 
        <div style="width: 100%; float: left;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanelddlQtyApvd_1" runat="server">
                <ContentTemplate>
                    <table width="100%" cellpadding="4" cellspacing="0" bordercolor="#000000" border="1"
                        style="border-collapse: collapse;" class="border2">
                       
                        <tr>
                            <th style="color: White !important; height: 39px; capitalize !important;">
                                <div class="tempClass" style="text-transform: capitalize !important;">
                                    Remarks :
                                </div>
                            </th>
                            <td colspan="3" valign="top">
                                <div style="width: 80%; vertical-align: top; height: 100px; overflow: auto;">
                                    <asp:Label ID="lblShowRemark" runat="server" CssClass="label-remarks" />
                                </div>
                            </td>
                        </tr>
                        <tr class="permission-text-remarks">
                            <th style="color: White !important; height: 31px; text-transform: capitalize !important;
                                background-image: url(../../images/cs_bg4.png); background-repeat: repeat-x;
                                capitalize !important;">
                                Enter Remarks :
                            </th>
                            <td colspan="3" style="vertical-align: top ! important;">
                                <asp:TextBox Columns="80" Rows="5" Height="90" Width="100%" ID="txtremarks" class="text-remarks"
                                    runat="server" TextMode="MultiLine"></asp:TextBox>
                                     <asp:HiddenField ID="hdnName" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hdnFlag1" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hdnFlag2" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hdnstyleid" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hdnOrderID" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                       
                    </table>
                    </div>
                
                    <div style="margin-top:20px;">
                        
                        <asp:Button ID="btnSubmit" class="submit" Text="Submit" runat="server" 
                            onclick="btnSubmit_Click"  />
                        <input type="button" onclick="window.close();" class="close do-not-disable da_submit_button" value="Close" />
                </ContentTemplate>
               
            </asp:UpdatePanel>
        </div>
    
    </form>
</body>
</html>
