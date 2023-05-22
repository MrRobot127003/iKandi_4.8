<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageOrderSAMPopUp.ascx.cs" Inherits="iKandi.Web.ManageOrderSAMPopUp" %>
<script language="javascript" type="text/javascript">

    function validation() {

        //var txtOrderdSam = '<%=txtOrderdSam.ClientID %>';
        var txtOrderdSam = document.getElementById("<%= txtOrderdSam.ClientID %>").value;
        var txtSTCSam = document.getElementById("<%= txtSTCSam.ClientID %>").value;

        if ((parseInt(txtOrderdSam) > 61 || parseInt(txtOrderdSam) < 5)) {
            alert('Please enter a valid sam! value must be between 5 to 60')
            return false;
        }
        if ((parseInt(txtSTCSam) > 61 || parseInt(txtSTCSam) < 5 )) {
            alert('Please enter a valid sam! value must be between 5 to 60')
            return false;
        }

    }
    //    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    //    var proxy = new ServiceProxy(serviceUrl);

    //    var txtOrderSamClientID = '<%=txtOrderdSam.ClientID %>';
    //    var txtSTCSamClientID = '<%=txtSTCSam.ClientID %>';
    //    var hdnclientOrderID = '<%=hdnOrderID.ClientID %>';
    //    var FileUploadOrder = '<%=fleOrderedSam.ClientID %>';
    //    var FileUploadSTC = '<%=flestcSam.ClientID %>';
    //    
    //    var OrderSAM;
    //    var STCSAM;
    //    var orderID;
    //    var OrderPath;
    //    var StcPath;
    //    var OrderFilePath;
    //    var StcFilePath;


    //    $(function () {


    ////        $(".submit").click(function () {
    ////            debugger;
    ////            OrderSAM = $("#" + txtOrderSamClientID).val();
    ////            STCSAM = $("#" + txtSTCSamClientID).val();
    ////            OrderID = $("#" + hdnclientOrderID).val();
    ////            OrderPath = $("#" + FileUploadOrder).val();
    ////            StcPath = $("#" + FileUploadSTC).val();
    ////            OrderFilePath = OrderPath.substr(OrderPath.lastIndexOf("\\") + 1, OrderPath.length);
    ////            StcFilePath = StcPath.substr(OrderPath.lastIndexOf("\\") + 1, StcPath.length);


    ////            proxy.invoke("InsertManageOrderSam", { OrderID: OrderID, OrderSAM: OrderSAM, STCSAM: STCSAM, OrderFilePath: OrderFilePath, StcFilePath: StcFilePath }, function (result) {
    ////                jQuery(document).trigger('close.facebox');
    ////                __doPostBack('ChildWindowPostBack', '');

    ////            }, onPageError, false, false);

    ////        });

    //        $(".cancel").click(function () {
    //            jQuery(document).trigger('close.facebox');
    //        });

    //    });
   
   
   
</script>
<div class="form_box" style="font-family:Verdana,Arial,sans-serif; font-size:11px; text-transform:capitalize;">
    <div class="form_heading">
        SAM Order BreakDown Forms</div>
    <br />
    
    <br />
    
    <br />
     <table width="90%" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td width="20%">Orderd SAM</td>
            <td><asp:TextBox runat="server" ID="txtOrderdSam" CssClass="numeric-field-without-decimal-places" size="15" Text=""></asp:TextBox></td>
            <td>&nbsp;&nbsp;<asp:FileUpload ID="fleOrderedSam" runat="server" Width="150px" />&nbsp;<asp:HyperLink ID="hypOrderView" runat="server"  Target="_blank" style="font-size:9px; color:#0088cc;" Text="View File"></asp:HyperLink></td>
        </tr>
        <tr>
            <td>STC SAM</td>
            <td><asp:TextBox runat="server" ID="txtSTCSam" CssClass="numeric-field-without-decimal-places" size="15"></asp:TextBox></td>
            <td>&nbsp;&nbsp;<asp:FileUpload ID="flestcSam" runat="server" Width="150px" />&nbsp;<asp:HyperLink ID="hypSTCView" runat="server" style="font-size:9px; color:#0088cc;" Target="_blank" Text="View File"></asp:HyperLink></td>
        </tr>
       
       
    </table>
    <br />
</div>
<asp:HiddenField ID="hdnOrderID" runat="server" />
<asp:Button  id="btnsubmit" runat="server" 
    onclick="btnsubmit_Click" CssClass="submit" />

<input type="button" class="cancel" onclick="window.close();" />