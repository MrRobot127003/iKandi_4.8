<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricPurChaseLliabilityPopUp.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricPurChaseLliabilityPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.form.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <style>
        .buttonSaveDiv
        {
            width: 967px;
            margin: 0 auto;
            margin-top: 5px;
        }
        
        .btnSubmit
        {
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 20px;
            line-height: 20px;
            border: none !important;
            border-radius: 2px;
        }
        .FbaricPurtable
        {
            width: 967px;
            margin: 0 auto;
            margin-top: 5px;
            border-collapse: collapse;
        }
        .FbaricPurtable td
        {
            border: 1px solid #dbd8d8;
            border-collapse: collapse;
            padding: 3px 5px;
            font-family: Arial;
            font-size: 10px;
        }
        .FbaricPurtable th
        {
            border: 1px solid #999;
            border-collapse: collapse;
            padding: 3px 5px;
            font-weight: 500;
            background: #dddfe4;
            color: #575759;
            font-family: Arial;
            font-size: 10px;
        }
        .commonwidth
        {
            width: 45px;
        }
        .countandWidth
        {
            width: 150px;
        }
        .countandWidth1
        {
            width: 120px;
        }
        .FabricName
        {
            width: 180px;
        }
        .txtCenter
        {
            text-align: center;
        }
        .FbaricPurtable td:first-child
        {
            border-left-color:#999 !important;
        }
        .FbaricPurtable td:last-child
        {
            border-right-color:#999 !important;
        }
        .FbaricPurtable tr:nth-last-child(1)>td
        {
            border-bottom-color:#999 !important;
        }
        .FbaricPurtable.topTable td
        {
            width:25%;
         }
    </style>
    <script language="javascript" type="text/javascript">
        function CloseWindow() {
            debugger;
            window.location = "../Dashboard_Task.aspx";
        }

      
    </script>
</head>
<body style="">
    <form id="form1" style="zoom:50p%" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <table border="0" class="FbaricPurtable topTable" cellpadding="0" cellspacing="0">
                 <tr>
                   <th colspan="8" style="color: #fff; background: #39589c;font-weight: normal !important;font-size: 14px;border-color:#999">
                     <span>Fabric Liability Form</span>
                   </th>
                 </tr>
              </table>
                <table border="0" class="FbaricPurtable topTable" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="border-top-color:#999 !important">
                            <span style="color: #635f5f">PO Number:</span>
                            <asp:Label ID="lblponumber" runat="server"></asp:Label>
                        </td>
                        <td style="border-top-color:#999 !important">
                            <span style="color: #635f5f">PO Date:</span>
                            <asp:Label ID="lblpodate" runat="server"></asp:Label>
                        </td>
                        <td style="border-top-color:#999 !important">
                            <span style="color: #635f5f">ETA Date:</span>
                            <asp:Label ID="lbletadate" runat="server"></asp:Label>
                        </td>
                        <td style="border-top-color:#999 !important">
                            <span style="color: #635f5f">Supplier Name:</span>
                            <asp:Label ID="lblsuppliername" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table border="0" class="FbaricPurtable" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="FabricName">
                            Fabric Name
                        </th>
                        <th class="countandWidth1">
                            Count & Construction
                        </th>
                        <th class="commonwidth">
                            Type
                        </th>
                        <th class="commonwidth" style="min-width:65px;">
                            Width (GSM)
                        </th>
                        <th class="commonwidth">
                            G.Sh. %
                        </th>
                        <th class="commonwidth">
                            R.Sh. %
                        </th>
                        <th class="commonwidth">
                            Cut.W. %
                        </th>
                        <th class="countandWidth">
                            Color Print
                        </th>
                        <th class="commonwidth" id="PoQtyhead" runat="server" visible="false">
                            PO Qty.
                        </th>
                       
                         <th class="commonwidth" id="PoSendQtyhead" runat="server">
                            Send Qty.
                        </th>
                         <th class="commonwidth">
                            SRV Qty.
                        </th>
                        <th class="commonwidth">
                            Received
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblfabricName" ForeColor="blue" runat="server"></asp:Label>
                        </td>
                        <td class="txtCenter">
                            <asp:Label ID="lblcountcounstruction" runat="server"></asp:Label>
                        </td>
                        <td class="txtCenter">
                            <asp:Label ID="lbltypes" runat="server"></asp:Label>
                        </td>
                        <td class="txtCenter">
                            <asp:Label ID="lblwidthgsm" runat="server"></asp:Label>"&nbsp;&nbsp;&nbsp;&nbsp;(<asp:Label
                                ID="lblgsm" runat="server"></asp:Label>)
                        </td>
                        <td class="txtCenter">
                            <asp:Label ID="lblgerigeshrinkage" runat="server"></asp:Label>
                        </td>
                        <td class="txtCenter">
                            <asp:Label ID="lblresidualshrinkage" runat="server"></asp:Label>
                        </td>
                        <td class="txtCenter">
                            <asp:Label ID="lblcutwitdh" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblprintdeatil" Font-Bold="true" runat="server"></asp:Label>
                        </td>
                         <td class="txtCenter" id="PoQty" runat="server" visible="false">
                            <asp:Label ID="lblqty" runat="server"></asp:Label>
                            
                        </td>
                        <td id="SendQty" class="txtCenter" runat="server">
                            <asp:Label ID="lblsendqty" Font-Bold="true" runat="server"></asp:Label>
                        </td>
                        <td class="txtCenter" >
                            <asp:Label ID="lblsrvqty" Font-Bold="true" runat="server"></asp:Label>
                           <asp:HiddenField ID="hdnsrvqty" runat="server"/>
                        </td>
                       
                        <td>
                            <asp:TextBox ID="txtlibilityqty" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                MaxLength="6" runat="server" Style="width: 90%; text-align: center"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </div>
                <div class="form_buttom buttonSaveDiv">
                    <asp:Button ID="btnSubmit" OnClick="btn_btnSubmit" runat="server" CssClass="btnSubmit"
                        Text="Save" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
