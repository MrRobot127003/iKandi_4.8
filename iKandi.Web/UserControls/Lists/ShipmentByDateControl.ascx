<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShipmentByDateControl.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.ShipmentByDateControl" %>
<%--<script type="text/javascript">

    $(document).ready(function () {
        alert("go");
        document.getElementById('<%= grdhoppminspection.ClientID %>').style.display = 'none';
        document.getElementById('<%= grdqadone.ClientID %>').style.display = 'none';
    });
</script>--%>
<script src="../../CommonJquery/Js/form.js" type="text/javascript"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: verdana;
    }
    table
    {
        font-family: arial,halvetica;
        border-color: #aaa;
        border-collapse: collapse;
    }
    th
    {
        background: #39589C;
        color: #98a9ca;
        font-weight: normal;
        font-size: 9px;
        padding: 1px 0px;
        font-family: arial,halvetica;
        border-color: #98a9ca;
        
    }
    
    table td
    {
        font-size: 9px;
        text-align: center;
        border-color: #d3d3d3 !important;
         font-weight: normal;
    }
    .per
    {
        color: blue;
    }
    .gray
    {
        color: gray;
    }
    h2
    {
        font-size: 14px;
        font-weight: bold;
        padding: 0px;
        margin: 0px;
        background: #39589C;
        text-align: center;
        color: #98a9ca;
        font-weight: normal;
        font-family: arial,halvetica;
    }
    .row-fir th
    {
        font-weight: normal;
        font-size: 10px;
    }
    table td table td
    {
        border-color: #aaa;
    }
    .ShipmentPen td
    {
        border: 1px solid #999;
    }
    .ShipmentPen th
    {
        border: 1px solid #999;
        background: #39589C;
    }
    .blue1
    {
        color: #39589C;
    }
    .al-right
    {
        text-align: right;
    }
    .leftalign
    {
        text-align: left;
        vertical-align: top;
    }
    .f-12
    {
        font-size: 12px;
    }
    .f-12 table td
    {
        font-size: 12px;
    }
    .lst-day
    {
        text-align: left;
    }
    #gridshipemtNew tbody > tr:last-child > td
    {
        border-bottom: 0;
    }
    .hide-div-grid
    {
        display: none !important;
        height: 0px !important;
        overflow: hidden;
        max-height: 0px !important;
        mso-hide: all;
        line-height: 0px !important;
    }
    .hide-div-grid tr
    {
        display: none;
        mso-hide: all;
    }
    tr.month td
    {
        background-color: #fff !important;
    }
    
   /* .month td
    {
        border-right: 1px solid #ccc;
        font-size: 8px;
    }
    .month td table td
    {
        border-right: 0px;
    }*/
    .textgray
    {
        color: #999999;
    }
    .displaynonedt
    {
        display: none;
        mso-hide: all;
    }
</style>
<style type="text/css">
    .header1 td
    {
        background: #39589C;
        color: #98a9ca;
        font-weight: normal;
        font-size: 10px;
        padding: 1px 0px;
        font-family: arial,halvetica;
        border-color: #98a9ca;
    }
    .toptableheader th
    {
        background: #39589C;
    }
    .toptableheader{
    border-color:#dad6d6 !important;
    }
     .toptableheader td{
    background: #fff;
    }
    .biplpdstichtotal
    {
         background:#fff;
     }
</style>
<div class="text_div">
    <%--<table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr>
<td width="79%">--%>
    <div style='font-family: arial; font-size: 12px'>
        <div>
            &nbsp; &nbsp;Please <a id="Rell_Outhouse" runat="server" href='' style='color: blue;
                text-decoration: none;'>Click here </a>to access <span style='color: gray'>Outhouse
                    stitch details </span>
        </div>
        <br />
        <div>
            &nbsp; &nbsp;Please <a id="Rell_Outhouse_Emb" runat="server" href='' style='color: blue;
                text-decoration: none;'>Click here </a>to access <span style='color: gray'>Value addition
                    details </span>
        </div>
        <br />
        <%--<div>
            &nbsp; &nbsp;Please <a id="Production_Plan_Details_C47" runat="server" href='' style='color: blue;
                text-decoration: none;'>Click here </a>to access <span style='color: gray'>Production
                    Plan Details of C47</span>
        </div>
        <br />
        <div>
            &nbsp; &nbsp;Please <a id="Production_Plan_Details_C45_46" runat="server" href=''
                style='color: blue; text-decoration: none;'>Click here </a>to access <span style='color: gray'>
                    Production Plan Details of C45-46. </span>
        </div>--%>
    </div>
    <br />
    <table width="100%" cellpadding="0" cellspacing="0" border="1" class="toptableheader"
        style="">
        <tr>
            <th colspan="26">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <th width="80%" style="font-size: 14px;">
                            Monthly Shipment Report
                        </th>
                        <th width="20%" style="text-align: right; font-size: 14px;">
                            <asp:Label ID="lbldates" runat="server"></asp:Label>
                            &nbsp; &nbsp;
                        </th>
                    </tr>
                </table>
            </th>
        </tr>
        <tr>
            <th rowspan="4" width="70">
                Week No.
                <br />
                (Dates)
            </th>
            <th colspan="5">
                C-47
            </th>
            <th colspan="5">
                C-45-46
            </th>
            <%-- New Factory added--%>
            <th colspan="5">
                D-169
            </th>
            <%--END--%>
             <%-- New Factory added--%>
            <%--<th colspan="5">
                C-52
            </th>--%>
            <%--END--%>
            <th colspan="5">
                Bipl
            </th>
        </tr>
        <%-- c47 added--%>
        <tr>
            <th width="50" rowspan="3">
                Cut Qty
            </th>
            <th width="50" rowspan="3">
                Stitch Qty
                <br />
                Stitch Val
            </th>
            <th width="50" rowspan="3">
                Finish Qty
                <br />
                Finish Val
            </th>
            <th width="100">
                Ship Qty / Ship Val (Cr)
            </th>
            <th rowspan="2" width="100">
                Pdng Stitch Qty
                <br />
                Pdng Shipped Qty
                <br />
                (Prv Month Sh Qty)
            </th>
            <%--END--%>
            <%-- c4546 added--%>
            <th width="50" rowspan="3">
                Cut Qty
            </th>
            <th width="50" rowspan="3">
                Stitch Qty
                <br />
                Stitch Val
            </th>
            <th width="50" rowspan="3">
                Finish Qty
                <br />
                Finish Val
            </th>
            <th width="100">
                Ship Qty / Ship Val (Cr)
            </th>
            <th rowspan="2" width="100">
                Pdng Stitch Qty
                <br />
                Pdng Shipped Qty
                <br />
                (Prv Month Sh Qty)
            </th>
            <%--END--%>
            <%-- New Factory added--%>
            <th width="50" rowspan="3">
                Cut Qty
            </th>
            <th width="50" rowspan="3">
                Stitch Qty
                <br />
                Stitch Val
            </th>
            <th width="50" rowspan="3">
                Finish Qty
                <br />
                Finish Val
            </th>
            <th width="100">
                Ship Qty / Ship Val (Cr)
            </th>
            <th rowspan="2" width="100">
                Pdng Stitch Qty
                <br />
                Pdng Shipped Qty
                <br />
                (Prv Month Sh Qty)
            </th>
            <%--END--%>
            <%-- New Factory C52 added--%>
            <%--<th width="50" rowspan="3">
                Cut Qty
            </th>
            <th width="50" rowspan="3">
                Stitch Qty
                <br />
                Stitch Val
            </th>
            <th width="50" rowspan="3">
                Finish Qty
                <br />
                Finish Val
            </th>
            <th width="100">
                Ship Qty / Ship Val (Cr)
            </th>
            <th rowspan="2" width="100">
                Pdng Stitch Qty
                <br />
                Pdng Shipped Qty
                <br />
                (Prv Month Sh Qty)
            </th>--%>
            <%--END--%>
            <%-- BIPL added--%>
            <th width="50" rowspan="3">
                Cut Qty
            </th>
            <th width="50" rowspan="3">
                Stitch Qty
                <br />
                Stitch Val
            </th>
            <th width="50" rowspan="3">
                Finish Qty
                <br />
                Finish Val
            </th>
            <th width="100">
                Ship Qty / Ship Val (Cr)
            </th>
            <th width="100" rowspan="2">
                Pdng Stitch Qty
                <br />
                Pdng Shipped Qty
                <br />
                (Prv Month Sh Qty)
            </th>
            <%--END--%>
        </tr>
        <%--END--%>
        <tr>
            <%-- c47 added--%>
            <th>
                Plty (Lk)/Plty % To Fob
            </th>
            <%--END--%>
            <%-- c4546 added--%>
            <th>
                Plty (Lk)/Plty % To Fob
            </th>
            <%--END--%>
            <%-- New Factory added--%>
            <th>
                Plty (Lk)/Plty % To Fob
            </th>
            <%--END--%>
             <%-- New Factory C52 added--%>
            <%--<th>
                Plty (Lk)/Plty % To Fob
            </th>--%>
            <%--END--%>
            <%-- BIPL added--%>
            <th>
                Plty (Lk)/Plty % To Fob
            </th>
            <%--END--%>
        </tr>
        <tr>
            <%-- c47 added--%>
            <th>
                CTSL % Rescan PCS
            </th>
            <th>
                <%--Pending To Be
            <br />
            Shipped Val (Cr)--%>
                Pdng Shipped Val
                <br />
                (Prv Month Sh Val)
            </th>
            <%--END--%>
            <%-- C4546 added--%>
            <th>
                CTSL % Rescan PCS
            </th>
            <th>
                <%--Pending To Be
            <br />
            Shipped Val (Cr)--%>
                Pdng Shipped Val
                <br />
                (Prv Month Sh Val)
            </th>
            <%--END--%>
            <%-- New Factory added--%>
            <th>
                CTSL % Rescan PCS
            </th>
            <th>
                <%--Pending To Be
            <br />
            Shipped Val (Cr)--%>
                Pdng Shipped Val
                <br />
                (Prv Month Sh Val)
            </th>
            <%--END--%>
             <%-- New Factory c52 added--%>
           <%-- <th>
                CTSL % Rescan PCS
            </th>
            <th>--%>
                <%--Pending To Be
            <br />
            Shipped Val (Cr)--%>
               <%-- Pdng Shipped Val
                <br />
                (Prv Month Sh Val)
            </th>--%>
            <%--END--%>
            <%-- BIPL added--%>
            <th>
                CTSL % Rescan PCS
            </th>
            <th>
                <%--Pending To Be
            <br />
            Shipped Val (Cr)--%>
                Pdng Shipped Val
                <br />
                (Prv Month Sh Val)
            </th>
            <%--END--%>
        </tr>
        <%--END--%>

        <tr>
            <td style="color:gray">
                 <strong>Month Total</strong>
            </td>
            <!-- C-47 Block -->
            <td>
                <asp:Label ID="lblCutQtyTotal_C47" ForeColor="#000" runat="server"></asp:Label>
            </td>
            <td>
                 <asp:Label ID="lblstitchQtyTotal_47"  runat="server"></asp:Label>
                    <br />
                  <asp:Label ID="lblstitchvalTotal_47" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFinishQtyTotal_47" runat="server" ForeColor="#000"></asp:Label>
                    <br />
                <asp:Label ID="lblFinishValTotal_47" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
            </td>
            <td  class="biplpdstichtotal">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedQtyTotal_c47" Font-Size="10px" Font-Bold="true" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedValTotal_c47" Font-Size="10px" ForeColor="green" Font-Bold="true" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPenaltyPendingValTotal_fob_c47" ForeColor="red" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedPendingValTotal_fob_c47" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblCtslTotal_c47" ForeColor="red" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
              <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPndStitchQty_Total_C47" runat="server" ForeColor="#000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedPendingQtyTotal_c47" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblShipedPendingValTotal_c47" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <!-- C-46-45 Block -->
          <td>
                <asp:Label ID="lblCutQtyTotal_C45_46" ForeColor="#000" runat="server"></asp:Label>
            </td>
            <td>
                 <asp:Label ID="lblstitchQtyTotal_C45_46"  runat="server"></asp:Label>
                    <br />
                  <asp:Label ID="lblstitchvalTotal_C45_46" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFinishQtyTotal_C45_46" runat="server" ForeColor="#000"></asp:Label>
                    <br />
                <asp:Label ID="lblFinishValTotal_C45_46" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
            </td>
            <td  class="biplpdstichtotal">  
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedQtyTotal_C45_46" Font-Size="10px" Font-Bold="true" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedValTotal_C45_46" Font-Size="10px" Font-Bold="true" ForeColor="green" runat="server">/ ₹0.9 Cr</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPenaltyPendingValTotal_fob_C45_46" ForeColor="red" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedPendingValTotal_fob_C45_46" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblCtslTotal_C45_46" ForeColor="red" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
              <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPndStitchQty_Total_C45_46" runat="server" ForeColor="#000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedPendingQtyTotal_C45_46" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblShipedPendingValTotal_C45_46" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <!-- D-69 Block -->
            <td>
                <asp:Label ID="lblCutQtyTotal_D69" ForeColor="#000" runat="server"></asp:Label>
            </td>
            <td>
                 <asp:Label ID="lblstitchQtyTotal_D69" runat="server"></asp:Label>
                    <br />
                  <asp:Label ID="lblstitchvalTotal_D69" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFinishQtyTotal_D69" runat="server" ForeColor="#000"></asp:Label>
                    <br />
                <asp:Label ID="lblFinishValTotal_D69" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
            </td>
            <td  class="biplpdstichtotal">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedQtyTotal_D69" Font-Size="10px" Font-Bold="true" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedValTotal_D69" Font-Size="10px" Font-Bold="true" ForeColor="green" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPenaltyPendingValTotal_fob_D69" ForeColor="red" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedPendingValTotal_fob_D69" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblCtslTotal_D69" ForeColor="red" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
              <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPndStitchQty_Total_D69" runat="server" ForeColor="#000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedPendingQtyTotal_D69" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblShipedPendingValTotal_D69" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <!-- C-52 Block -->
            <%--<td>
                <asp:Label ID="lblCutQtyTotal_C52" ForeColor="#000" runat="server"></asp:Label>
            </td>
            <td>
                 <asp:Label ID="lblstitchQtyTotal_C52" runat="server"></asp:Label>
                    <br />
                  <asp:Label ID="lblstitchvalTotal_C52" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFinishQtyTotal_C52" runat="server" ForeColor="#000"></asp:Label>
                    <br />
                <asp:Label ID="lblFinishValTotal_C52" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
            </td>
            <td  class="biplpdstichtotal">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedQtyTotal_C52" Font-Size="10px" Font-Bold="true" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedValTotal_C52" Font-Size="10px" Font-Bold="true" ForeColor="green" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPenaltyPendingValTotal_fob_C52" ForeColor="red" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedPendingValTotal_fob_C52" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblCtslTotal_C52" ForeColor="red" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
              <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPndStitchQty_Total_C52" runat="server" ForeColor="#000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedPendingQtyTotal_C52" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblShipedPendingValTotal_C52" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>--%>
            <!--BIPL Block -->
           <td>
                <asp:Label ID="lblCutQtyTotal_Bipl" ForeColor="#000" runat="server"></asp:Label>
            </td>
            <td>
                 <asp:Label ID="lblstitchQtyTotal_Bipl" runat="server"></asp:Label>
                    <br />
                  <asp:Label ID="lblstitchvalTotal_Bipl" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFinishQtyTotal_Bipl" runat="server" ForeColor="#000">  </asp:Label>
                    <br />
                <asp:Label ID="lblFinishValTotal_Bipl" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
            </td>
            <td  class="biplpdstichtotal">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedQtyTotal_Bipl" Font-Size="10px" Font-Bold="true" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedValTotal_Bipl" Font-Size="10px" Font-Bold="true" ForeColor="green" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPenaltyPendingValTotal_fob_Bipl" ForeColor="red" runat="server"></asp:Label>
                            <asp:Label ID="lblShipedPendingValTotal_fob_Bipl" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblCtslTotal_Bipl" ForeColor="red" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
              <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblPndStitchQty_Total_Bipl" runat="server" ForeColor="#000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa;">
                            <asp:Label ID="lblShipedPendingQtyTotal_Bipl" ForeColor="#000" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lblShipedPendingValTotal_Bipl" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr class="month" style="height: 30px; color: #999;">
            <td style="color: #999; border-bottom: 1px solid #ccc; border-left: 1px solid #ccc;
                font-size: 10px !important;" width="70">
                <strong>Last Day</strong>
            </td>
            <%--C47-------------------------------------------------------------------------------------------------%>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_C47" runat="server"></asp:Label>
            </td>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_C47" ForeColor="#000" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchval_C47" ForeColor="Green" runat="server"></asp:Label>
            </td>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_C47" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinishVal_C47" ForeColor="Green" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_C47" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_C47" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa; color: #000;">
                            <asp:Label ID="lbllastdayPenaltyValue_fob_C47" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_C47" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_C47" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipQty_C47" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_C47" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%--C4546-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastCutQty_C4647" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastStichedQty_C4647" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastStichedVal_C4647" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastFinishQty_C4647" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastFinishVal_C4647" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB;">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayshipQty_C4647" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaysShipVal_C4647" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPenaltyValue_fob_C4647" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdayPendingShipedVal_fob_C4647" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdaysShipCtsl_C4647" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPendingShipedQty_C4647" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdayPendingShipedVal_C4647" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%-- New Factory added--%>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_D169" runat="server"></asp:Label>
            </td>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_D169" ForeColor="#000" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchval_D169" ForeColor="Green" runat="server"></asp:Label>
            </td>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_D169" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinishVal_D169" ForeColor="Green" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_D169" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_D169" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPenaltyValue_fob_D169" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_D169" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_D169" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipQty_D169" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_D169" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
             <%-- New Factory c52 added--%>
            <%--<td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_C52" runat="server"></asp:Label>
            </td>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_C52" ForeColor="#000" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchval_C52" ForeColor="Green" runat="server"></asp:Label>
            </td>
            <td width="50" style="border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_C52" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinishVal_C52" ForeColor="Green" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_C52" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_C52" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPenaltyValue_fob_C52" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_C52" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_C52" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipQty_C52" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_C52" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>--%>
            <%--END--%>
            <%--BIPL-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_BIPL" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdaystitchQty_BIPL" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdaystitchval_BIPL" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblfinishQtylastday_BIPL" runat="server"></asp:Label><br />
                <asp:Label ID="lblfinishvallastday_BIPL" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayShipQty_BIPL" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdayShipVal_BIPL" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lblpendingPenaltyValue_fob_Bipl" runat="server"></asp:Label>
                            <asp:Label ID="lblpendingShipedshipedvalue_fob_Bipl" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                            <asp:Label ID="lbllastdayShipCtsl_BIPL" runat="server" ForeColor="#000"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc; border-right: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F5F2F1;">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lblpendingshipedQtyBipl" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lblpendingShipedshipedvalueBipl" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
        </tr>
        <tr class="month" style="height: 30px; color: #999;">
            <td style="color: #999; border-bottom: 1px solid #ccc; border-left: 1px solid #ccc;
                font-size: 10px !important;" width="70">
                <strong id="spanlastMonthName" runat="server">Last Month</strong>
            </td>
            <%--C47-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_C47_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_C47_month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_C47_month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchQty_C47_month_avg" ForeColor="Black" Font-Bold="true"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayStitchval_C47_month" Font-Bold="true" ForeColor="Green"
                    runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_C47_month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinish_C47_month_avg" runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayFinishval_C47_month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_C47_month" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_C47_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPenalty_fob_C47_month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_C47_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_C47_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px;">
                            <asp:Label ID="lbllastdaypendingShipQty_C47_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_C47_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%--C4546-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastCutQty_C4647_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastCutQty_C4647_month_avg" ForeColor="Black" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastStichedQty_C4647_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastStichedQty_C4647_month_avg" Font-Bold="true" ForeColor="Black"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lbllastStichedval_C4647_month" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastFinishQty_C4647_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastFinishQty_C4647_month_avg" ForeColor="Black" runat="server"
                    Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lbllastFinishval_C4647_month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB;">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayshipQty_C4647_month" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaysShipVal_C4647_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPenalty_fob_C4647_month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdayPendingShipedVal_fob_C4647_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdaysShipCtsl_C4647_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F5F2F1;">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPendingShipedQty_C4647_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdayPendingShipedVal_C4647_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%-- New Factory added--%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_D169_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_D169_month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_D169_month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchQty_D169_month_avg" ForeColor="Black" Font-Bold="true"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayStitchval_D169_month" Font-Bold="true" ForeColor="Green"
                    runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_D169_month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinish_D169_month_avg" runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayFinishval_D169_month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_D169_month" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_D169_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPenalty_fob_D169_month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_D169_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_D169_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px;">
                            <asp:Label ID="lbllastdaypendingShipQty_D169_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_D169_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%-- New Factory C52 added--%>
            <%--<td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_C52_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_C52_month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_C52_month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchQty_C52_month_avg" ForeColor="Black" Font-Bold="true"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayStitchval_C52_month" Font-Bold="true" ForeColor="Green"
                    runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_C52_month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinish_C52_month_avg" runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayFinishval_C52_month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_C52_month" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_C52_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPenalty_fob_C52_month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_C52_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_C52_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px;">
                            <asp:Label ID="lbllastdaypendingShipQty_C52_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_C52_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>--%>
            <%--END--%>
            <%--BIPL-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_BIPL_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_BIPL_month_avg" ForeColor="Black" runat="server"
                    Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdaystitchQty_BIPL_month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdaystitchQty_BIPL_month_avg" Font-Bold="true" ForeColor="Black"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lbllastdaystitchval_BIPL_month" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblfinishQtylastday_BIPL_month" runat="server"></asp:Label><br />
                <asp:Label ID="lblfinishQtylastday_BIPL_month_avg" ForeColor="Black" runat="server"
                    Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblfinishvallastday_BIPL_month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayShipQty_BIPL_month" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdayShipVal_BIPL_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lblpendingPenaltyBipl_fob_month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lblpendingShipedshipedvalueBipl_fob_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdayShipCtsl_BIPL_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc; border-right: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F5F2F1;">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lblpendingshipedQtyBipl_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lblpendingShipedshipedvalueBipl_month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
        </tr>
        <tr class="month" style="height: 30px; color: #999; border-bottom: 1px solid #ccc; border-left: 1px solid #ccc;">
            <td style="color: #999; border-bottom: 1px solid #ccc; border-left: 1px solid #ccc;
                font-size: 10px !important;" width="70">
                <strong id="spanlastMonthNamethree" runat="server">Last 3 M.(M. Avg.)</strong>
            </td>
            <%--C47-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_C47_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_C47_3month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_C47_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchQty_C47_3month_avg" Font-Bold="true" ForeColor="Black"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayStitchval_C47_3month" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_C47_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinish_C47_3month_avg" runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayFinishval_C47_3month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_C47_3month" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_C47_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllast_threeMonth_Penalty_fob_C47_3month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_C47_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_C47_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px">
                            <asp:Label ID="lbllastdaypendingShipQty_C47_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_C47_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%--C4546-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastCutQty_C4647_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastCutQty_C4647_3month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastStichedQty_C4647_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastStichedQty_C4647_3month_avg" Font-Bold="true" ForeColor="Black"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lbllastStichedval_C4647_3month" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastFinishQty_C4647_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastFinishQty_C4647_3month_avg" ForeColor="Black" runat="server"
                    Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lbllastFinishval_C4647_3month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB;">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayshipQty_C4647_3month" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaysShipVal_C4647_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllast_threeMonth_Penalty_fob_C4647_3month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdayPendingShipedVal_fob_C4647_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdaysShipCtsl_C4647_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F5F2F1;">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayPendingShipedQty_C4647_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdayPendingShipedVal_C4647_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%-- New Factory added--%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_D169_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_D169_3month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_D169_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchQty_D169_3month_avg" Font-Bold="true" ForeColor="Black"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayStitchval_D169_3month" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_D169_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinish_D169_3month_avg" runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayFinishval_D169_3month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_D169_3month" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_D169_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllast_threeMonth_Penalty_fob_D169_3month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_D169_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_D169_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px">
                            <asp:Label ID="lbllastdaypendingShipQty_D169_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_D169_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
             <%-- New Factory c52 added--%>
            <%--<td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_C52_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_C52_3month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayStitchQty_C52_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayStitchQty_C52_3month_avg" Font-Bold="true" ForeColor="Black"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayStitchval_C52_3month" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblLastdayFinish_C52_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lblLastdayFinish_C52_3month_avg" runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblLastdayFinishval_C52_3month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="llblLastdayShipQty_C52_3month" runat="server"></asp:Label>
                            <asp:Label ID="llblLastdayShipValue_C52_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllast_threeMonth_Penalty_fob_C52_3month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdaypendingShipvalue_fob_C52_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblLastdayShipCtsl_C52_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px">
                            <asp:Label ID="lbllastdaypendingShipQty_C52_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lbllastdaypendingShipvalue_C52_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>--%>
            <%--END--%>
            <%--BIPL-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdayCutQty_BIPL_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdayCutQty_BIPL_3month_avg" runat="server" Font-Size="8px"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lbllastdaystitchQty_BIPL_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lbllastdaystitchQty_BIPL_3month_avg" Font-Bold="true" ForeColor="Black"
                    runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lbllastdaystitchval_BIPL_3month" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblfinishQtylastday_BIPL_3month" runat="server"></asp:Label><br />
                <asp:Label ID="lblfinishQtylastday_BIPL_3month_avg" runat="server" Font-Size="8px"></asp:Label>
                <br />
                <asp:Label ID="lblfinishvallastday_BIPL_3month" runat="server"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbllastdayShipQty_BIPL_3month" runat="server"></asp:Label>
                            <asp:Label ID="lbllastdayShipVal_BIPL_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lbl_threeMonth_Penalty_Bipl_fob_3month" ForeColor="Red" runat="server"></asp:Label>
                            <asp:Label ID="lblpendingShipedshipedvalueBipl_fob_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lbllastdayShipCtsl_BIPL_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc; border-right: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F5F2F1;">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #bbb; color: #000;">
                            <asp:Label ID="lblpendingshipedQtyBipl_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <asp:Label ID="lblpendingShipedshipedvalueBipl_3month" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
        </tr>
        <tr class="month" style="height: 30px; color: #000; border-bottom: 1px solid #ccc; border-left: 1px solid #ccc;">
            <td style="color: gray; border-bottom: 1px solid #ccc; border-left: 1px solid #ccc;
                font-size: 10px !important;" width="70">
                <strong id="Strong1" runat="server">WIP</strong><br />
                <strong id="Strong2" runat="server">Pndg rscn qty</strong>
            </td>
            <%--C47-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipcutC47_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipcutC47" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipstitchC47_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipstitchC47" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipfinishC47_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblPendingRescanC47_k" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblwipfinishC47" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <%--<asp:Label ID="Label10" runat="server"></asp:Label>  
                        <asp:Label ID="Label11" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <%--<asp:Label ID="Label12" runat="server"></asp:Label>
                        <asp:Label ID="Label13" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <%--<asp:Label ID="Label14"  runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px">
                            <%--<asp:Label ID="Label15" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <%-- <asp:Label ID="Label16" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%--C4546-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipcutC45C46_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipcutC45C46" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipstitchC45C46_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipstitchC45C46" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
                <asp:Label ID="Label21" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipfinishC45C46_K" ForeColor="Black" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblPendingRescanC4546_k" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblwipfinishC45C46" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB;">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <%--<asp:Label ID="Label25"  runat="server"></asp:Label> 
                         <asp:Label ID="Label26" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <%--<asp:Label ID="Label27" runat="server"></asp:Label>
                      <asp:Label ID="Label28" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <%--<asp:Label ID="Label29"  runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F5F2F1;">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #bbb; color: #000;">
                            <%--<asp:Label ID="Label30" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <%--<asp:Label ID="Label31" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
            <%-- New Factory added--%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipcutD169_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipcutD169" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipstitchD169_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipstitchD169" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipfinishD169_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblPendingRescanD169_k" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblwipfinishD169" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <%--<asp:Label ID="Label10" runat="server"></asp:Label>  
                        <asp:Label ID="lbl_169_11" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            <%--<asp:Label ID="Label12" runat="server"></asp:Label>
                        <asp:Label ID="lbl_169_13" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <%--<asp:Label ID="Label14"  runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px">
                            <%--<asp:Label ID="lbl_169_15" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <%-- <asp:Label ID="lbl_169_16" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
                  <%-- New Factory added c52--%>
            <%--<td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipcutC52_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipcutc52" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipstitchC52_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipstitchC52" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipfinishC52_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblPendingRescanC52_k" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblwipfinishC52" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #bbb; color: #000;">
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td style="border-bottom: 1px solid #bbb; color: #000; height: 23px">
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            
                        </td>
                    </tr>
                </table>
            </td>--%>
            <%--END--%>
            <%--BIPL-------------------------------------------------------------------------------------------------%>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipcutbipl_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipcutbipl" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipstitchbipl_K" ForeColor="Black" runat="server"></asp:Label><br />
                <asp:Label ID="lblwipstitchbipl" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
                <asp:Label ID="Label36" runat="server"></asp:Label>
            </td>
            <td width="50" style="color: #000; border-bottom: 1px solid #ccc;">
                <asp:Label ID="lblwipfinishbipl_K" ForeColor="Black" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblPendingRescanBIPL_k" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblwipfinishbipl" runat="server" Font-Size="8px" Style="display: none"></asp:Label>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa; color: #000;">
                            <%--<asp:Label ID="Label40"   runat="server"></asp:Label> 
                         <asp:Label ID="Label41" runat="server"></asp:Label>--%>
                            <asp:Label ID="lblpendingworkingdaymonth" ForeColor="Black" runat="server"></asp:Label>
                            <asp:Label ID="lblpendingworkinghours" ForeColor="Black" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; border-bottom: 1px solid #aaa; color: #000;">
                            <%-- <asp:Label ID="Label42" runat="server"></asp:Label>
                       <asp:Label ID="Label43" runat="server"></asp:Label>--%>
                            <asp:Label ID="lblpeningwkday60" ForeColor="Black" runat="server"></asp:Label>
                            <asp:Label ID="lblpendingworkinghur60" ForeColor="Black" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px; color: #000;">
                            <asp:Label ID="lblunstitchQty60" ForeColor="Black" runat="server"></asp:Label>
                            <asp:Label ID="lblunstitchQtyPerday" ForeColor="Black" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="100" style="border-bottom: 1px solid #ccc; border-right: 1px solid #ccc;">
                <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F5F2F1;">
                    <tr>
                        <td style="height: 23px; border-bottom: 1px solid #aaa; color: #000;">
                            <%-- <asp:Label ID="Label45" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; color: #000;">
                            <%--<asp:Label ID="Label46" runat="server"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <%--END--%>
        </tr>
    </table>
   <%--<asp:GridView ID="gridshipemtNew" Visible="false" AutoGenerateColumns="false" runat="server"
        OnRowDataBound="gridshipemtNew_RowDataBound" ShowHeader="false" Width="100%"
        CellPadding="0" ShowFooter="true" FooterStyle-Height="30px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    &nbsp; &nbsp;
                    <asp:Label ID="lblWeekDayRange" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnweekMax" runat="server" Value='<%#Eval("maxvalue")%>' />
                    <asp:HiddenField ID="hdnweekMin" runat="server" Value='<%#Eval("minvalues")%>' />
                </ItemTemplate>
                <ItemStyle Width="70" ForeColor="Gray" BackColor="#f5f2f1" />
                <FooterTemplate>
                    <strong>Month Total</strong>
                </FooterTemplate>
                <FooterStyle ForeColor="Gray" Width="70" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <%--C47-------------------------------------------------------------------------------------------------
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblutQty_47" ForeColor="Gray" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnQty_47" runat="server" />
                    <asp:HiddenField ID="hdnQtyCutCtsl_C47" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblutQtyTotal_47" ForeColor="Gray" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblstitchQty_47" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdnstitchQty_47" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblstitchQtyTotal_47" ForeColor="Gray" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblstitchvalTotal_47" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFinishQty_47" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdnFinishQty_47" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblFinishQtyTotal_47" runat="server" ForeColor="Gray"></asp:Label>
                    <br />
                    <asp:Label ID="lblFinishValTotal_47" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQty_c47" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedVal_c47" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyTotal_fob_c47" runat="server" ForeColor="Gray"></asp:Label>
                                <asp:Label ID="lblShipedPendingVal_fob_c47" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtsl_c47" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdnShipedQty_47" runat="server" />
                    <asp:HiddenField ID="hdnhipedValQty" runat="server" />
                    <asp:HiddenField ID="hdnCtsl_c47" runat="server" />
                    <asp:HiddenField ID="hdnPenalty_47" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQtyTotal_c47" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedValTotal_c47" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyPendingValTotal_fob_c47" ForeColor="red" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedPendingValTotal_fob_c47" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtslTotal_c47" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPndStitchQty_C47" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedPendingQty_c47" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingVal_c47" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdnPndstitchQty_C47" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnShipedPendingQty_47" runat="server" />
                    <asp:HiddenField ID="hdnShipedPendingVal_47" runat="server" />
                    <asp:HiddenField ID="hdnfobpercentage_47" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #ddd;">
                                <asp:Label ID="lblPndStitchQty_Total_C47" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #ddd;">
                                <asp:Label ID="lblShipedPendingQtyTotal_c47" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingValTotal_c47" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <%--C45 46-------------------------------------------------------------------------------------------------
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblutQty_4546" ForeColor="Gray" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnQty_4546" runat="server" />
                    <asp:HiddenField ID="hdnQtyCutCtsl_4546" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblutQtyTotal_4546" ForeColor="Gray" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblstitchQty_4546" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdnstitchQty_4546" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblstitchQtyTotal_4546" runat="server" ForeColor="Gray"></asp:Label>
                    <br />
                    <asp:Label ID="lblstitchValTotal_4546" Font-Bold="true" runat="server" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFinishQty_4546" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdnFinishQty_4546" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblFinishQtyTotal_4546" runat="server" ForeColor="Gray"></asp:Label>
                    <br />
                    <asp:Label ID="lblFinishValTotal_4546" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQty_4546" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedVal_4546" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyTotal_fob_4546" runat="server" ForeColor="Gray"></asp:Label>
                                <asp:Label ID="lblShipedPendingVal_fob_4546" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtsl_4546" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdShipedQty_4546" runat="server" />
                    <asp:HiddenField ID="hdnShipedVal_4546" runat="server" />
                    <asp:HiddenField ID="hdnctsl_4645" runat="server" />
                    <asp:HiddenField ID="hdnPenalty_4546" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQtyTotal_4546" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedValTotal_4546" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyPendingValTotal_fob_4546" ForeColor="red" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedPendingValTotal_fob_4546" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtslTotal_4546" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F2DCDB" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPndStitchQty_C4546" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedPendingQty_4546" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingVal_4546" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdnPndStitchQty_C4546" runat="server" Value="0" />
                    <asp:HiddenField ID="hdShipedPendingQty_4546" runat="server" />
                    <asp:HiddenField ID="hdnShipedPendingVal_4546" runat="server" />
                    <asp:HiddenField ID="hdnfobpercentage_4546" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPendingStitchQtyTotal_C4546" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedPendingQtyTotal_4546" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingValTotal_4546" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <%-- New Factory added--
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblCutQty_169" ForeColor="Gray" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnQty_169" runat="server" />
                    <asp:HiddenField ID="hdnQtyCutCtsl_169" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblutQtyTotal_169" ForeColor="Gray" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblstitchQty_169" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdnstitchQty_169" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblstitchQtyTotal_169" ForeColor="Gray" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblstitchvalTotal_169" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFinishQty_169" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdnFinishQty_169" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblFinishQtyTotal_169" runat="server" ForeColor="Gray"></asp:Label>
                    <br />
                    <asp:Label ID="lblFinishValTotal_169" runat="server" ForeColor="Green" Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#f5f2f1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQty_d169" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedVal_d169" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyTotal_fob_d169" runat="server" ForeColor="Gray"></asp:Label>
                                <asp:Label ID="lblShipedPendingVal_fob_d169" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtsl_d169" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdnShipedQty_169" runat="server" />
                    <asp:HiddenField ID="hdnhipedValQty_169" runat="server" />
                    <asp:HiddenField ID="hdnCtsl_d169" runat="server" />
                    <asp:HiddenField ID="hdnPenalty_169" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #F2DCDB">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQtyTotal_d169" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedValTotal_d169" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyPendingValTotal_fob_d169" ForeColor="red" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedPendingValTotal_fob_d169" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtslTotal_d169" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPndStitchQty_D169" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedPendingQty_d169" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingVal_d169" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdnPndstitchQty_D169" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnShipedPendingQty_169" runat="server" />
                    <asp:HiddenField ID="hdnShipedPendingVal_169" runat="server" />
                    <asp:HiddenField ID="hdnfobpercentage_169" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPndStitchQty_Total_D169" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedPendingQtyTotal_D169" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingValTotal_D169" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <%--END
            <%--BIPL-------------------------------------------------------------------------------------------------
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblutQty_BIPL" ForeColor="Gray" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdcutqty_BIPL" runat="server" />
                    <asp:HiddenField ID="hdnQtyCutCtsl_BIPL" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblutQtyTotal_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblstitchQty_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdstitchQty_BIPL" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblstitchQtyTotal_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                    <br />
                    <asp:Label ID="lblstitchValTotal_BIPL" runat="server" Font-Bold="true" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblFinishQty_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                    <asp:HiddenField ID="hdFinishQty_BIPL" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <asp:Label ID="lblFinishQtyTotal_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                    <br />
                    <asp:Label ID="lblFinishvalTotal_BIPL" Font-Bold="true" runat="server" ForeColor="Green"
                        Font-Size="8px"></asp:Label>
                </FooterTemplate>
                <FooterStyle Width="50" BackColor="#F5F2F1" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQty_BIPL" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedVal_BIPL" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyTotal_fob_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                                <asp:Label ID="lblShipedPendingVal_fob_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtsl_BIPL" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdShipedQty_BIPL" runat="server" />
                    <asp:HiddenField ID="hdnShipedVal_BIPL" runat="server" />
                    <asp:HiddenField ID="hdnCtsl_BIPL" runat="server" />
                    <asp:HiddenField ID="hdPenalty_BIPL" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedQtyTotal_BIPL" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                                <asp:Label ID="lblShipedValTotal_BIPL" Font-Size="11px" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPenaltyPendingValTotal_fob_BIPL" ForeColor="red" runat="server"></asp:Label><br />
                                <asp:Label ID="lblShipedPendingValTotal_fob_BIPL" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblCtslTotal_BIPL" ForeColor="red" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F2DCDB" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPendingStitchQty_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedPendingQty_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingVal_BIPL" runat="server" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdnPendingStitchQty_BIPL" runat="server" Value="0" />
                    <asp:HiddenField ID="hdShipedPendingQty_BIPL" runat="server" />
                    <asp:HiddenField ID="hdnShipedPendingVal_BIPL" runat="server" />
                    <asp:HiddenField ID="hdnfobpercentage_bipl" runat="server" />
                </ItemTemplate>
                <ItemStyle Width="100" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblPendingStitchQtyTotal_BIPL" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px; border-bottom: 1px solid #aaa;">
                                <asp:Label ID="lblShipedPendingQtyTotal_BIPL" ForeColor="Gray" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px;">
                                <asp:Label ID="lblShipedPendingValTotal_BIPL" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle Width="100" BackColor="#F5F2F1" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
    <table cellpadding="0" cellspacing="0" width="100%" class="month">
      
    </table>
     
    <br />
    <div style="width:520px;float:left;margin-right:5px;margin-bottom:10px;">
        <div id="frmQShipmentPenaltyReport" runat="server">
        </div>
        <br />
        <br />
        <div id="Fabric_WIP" runat="server"></div>
    </div>
    <table style="width:50%;margin-bottom:15px;">
     <tr>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyPenalty" width="640" style="max-width: 640px; display: block;" />
            </td>
           
        </tr>
        </table>
        <%--  add code by bhrat on 31-Oct-19--%>
        <table>
         <tr>
            <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyCutQty" width="640" style="max-width: 640px; display: block;" />
            </td>
             <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyStitchQty" width="640" style="max-width: 640px; display: block;" />
            </td>
             
          </tr>
         <tr>
           <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyFinishedQty" width="640" style="max-width: 640px; display: block;" />
            </td>
             <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyShipQty" width="640" style="max-width: 640px; display: block;" />
            </td>
            
          </tr>
            <tr>
             <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyStitchingValue" width="640" style="max-width: 640px; display: block;" />
            </td>
             <td style="text-align: left; width: 33%">
                <img runat="server" id="BIPLMonthlyCTSL" width="640" style="max-width: 640px; display: block;" />
            </td>
            
          </tr>
        </table>
  <%--  end
    --%>
    <br />
    <%--</td>--%>
    <%--<td width="1%">

</td>--%>
    <%--<td width="20%" style="vertical-align:top;">--%>
    <br />
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td style="width: 46%; vertical-align: top;">
                <table cellspacing="0" cellpadding="0" border="1" style="width: 100%; display: none;">
                    <tr>
                        <th style="font-size: 14px;" colspan="9">
                            Shipment Planning (Sun to Sat)
                        </th>
                    </tr>
                    <tr>
                        <th rowspan="2" style="width: 250px">
                            Exfactory Weeks
                        </th>
                        <th colspan="2">
                            ASO
                        </th>
                        <th colspan="2">
                            ERN
                        </th>
                        <th colspan="2">
                            Other
                        </th>
                        <th colspan="2">
                            BIPL
                        </th>
                    </tr>
                    <tr>
                        <th style="width: 80px;">
                            Qty
                        </th>
                        <th style="width: 80px;">
                            Val
                        </th>
                        <th style="width: 80px;">
                            Qty
                        </th>
                        <th style="width: 80px;">
                            Val
                        </th>
                        <th style="width: 80px;">
                            Qty
                        </th>
                        <th style="width: 80px;">
                            Val
                        </th>
                        <th style="width: 80px;">
                            Qty
                        </th>
                        <th style="width: 80px;">
                            Val
                        </th>
                    </tr>
                </table>
                <h2>
                    Shipment Planning (Sun to Sat)
                </h2>
                <asp:GridView ID="grdupcmoming" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdupcmoming_RowDataBound"
                    ShowHeader="false" ShowFooter="true" Width="100%" CellPadding="0">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Ex Factory
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%--<asp:Label ID="lblExfac" runat="server" ForeColor="gray" Text='<%# (Convert.ToDateTime(Eval("ExfactDate")) == Convert.ToDateTime("01-01-0001") || Convert.ToDateTime(Eval("ExfactDate")) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(Eval("ExfactDate")) == Convert.ToDateTime("01-01-1900")) ? (Convert.ToDateTime(Eval("ExfactDate")) == Convert.ToDateTime("01-01-1900") || Convert.ToDateTime(Eval("ExfactDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("ExfactDate")).ToString("dd MMM") : Convert.ToDateTime(Eval("ExfactDate")).ToString("dd MMM")%>'></asp:Label>--%>
                                <asp:Label ID="lblExfac" runat="server" ForeColor="#000" Text='<%#Eval("WeekDetail")%>'></asp:Label>
                                <%--  <asp:HiddenField ID="hdnexfactdate" runat="server" Value='<%#Eval("ExfactDate")%>' />--%>
                                <%--   <asp:HiddenField ID="hdnclinetid" runat="server" Value='<%#Eval("ClientID")%>' />--%>
                            </ItemTemplate>
                            <ItemStyle Width="250px" />
                            <FooterTemplate>
                                <b style="font-size: 11px; color: gray">Grand Total</b>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                Client Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblClinetName" runat="server" ForeColor="gray"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                Asos Order Qty
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQty" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <FooterTemplate>
                                <asp:Label ID="lblgrandOrederQty" Font-Bold="true" Font-Size="11px" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Aso Order Qty
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblASOOrderQty" Text='<%#Eval("Assos_ContractQty_Sea")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblASOgrandOrederQty" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Aso Value
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblASObiplprice" Text='<%#Eval("Assos_ShipedValue_Sea")%>' ForeColor="Green"
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblASOgrandOrederVal" Font-Bold="true" ForeColor="Green" Font-Size="11px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Aso Order Qty
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblASOOrderQtyAir" Text='<%#Eval("Assos_ContractQty_Air")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblASOgrandOrederQtyAir" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Aso Value
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblASObiplpriceAir" Text='<%#Eval("Assos_ShipedValue_Air")%>' ForeColor="Green"
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblASOgrandOrederValAir" Font-Bold="true" ForeColor="Green" Font-Size="11px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                ERN Order Qty
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblERNOrderQty" Text='<%#Eval("ERN_ContractQty")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblERNgrandOrederQty" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                ERN Value
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblERNbiplprice" Text='<%#Eval("ERN_ShipedValue")%>' ForeColor="Green"
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblERNgrandOrederVal" ForeColor="Green" Font-Bold="true" Font-Size="10px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Other Order Qty
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOther_ContractQty" Text='<%#Eval("Other_ContractQty")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblOthergrandOrederQty" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Other Value
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOther_ShipedValue" Text='<%#Eval("Other_ShipedValue")%>' ForeColor="Green"
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblOthergrandOrederVal" ForeColor="Green" Font-Bold="true" Font-Size="10px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                TOTAL Order Qty
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTotalOrderQty" Text='<%#Eval("BIPL_ContractQty")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblTotalgrandOrederQty" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                TOTAL Value
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTotalbiplprice" Text='<%#Eval("BIPL_ShipedValue")%>' ForeColor="Green"
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <FooterTemplate>
                                <asp:Label ID="lblTotalgrandOrederVal" ForeColor="Green" Font-Bold="true" Font-Size="11px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                BIPL Price
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblbiplprice" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <FooterTemplate>
                                <asp:Label runat="server" Font-Bold="true" Font-Size="10px" ID="lblgrandbiplprice"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width: 1%">
                &nbsp;
            </td>
            <td style="width: 54%; vertical-align: top;">
                <h2>
                    Style Code Planning
                </h2>
                <asp:GridView ID="grdStyleCodePlaning" OnRowDataBound="grdStyleCodePlaning_RowDataBound"
                    ShowHeader="false" runat="server" Width="100%" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblqtyFromRange" Text='<%# Eval("F_T_Range")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblStyleCodeCount" Text='<%# Eval("StyleCodeCount")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" Text='<%# Eval("Quantity")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblCurrentMonth_TotalQtyPlanned" Text='<%# Eval("CurrentMonth_TotalQtyPlanned")%>'
                                    ToolTip='<%# Eval("CurrentMonth_TotalQtyPlannedTooltip", "{0:#,##}") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblCurrentMonth_TotalStyleCodePlanned" Text='<%# Eval("CurrentMonth_TotalStyleCodePlanned")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblCurrentMonth_TotalQtyUnPlanned" Text='<%# Eval("CurrentMonth_TotalQtyUnPlanned")%>'
                                    ToolTip='<%# Eval("CurrentMonth_TotalQtyUnPlannedTooltip", "{0:#,##}") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblCurrentMonth_TotalStyleCodeUnPlanned" Text='<%# Eval("CurrentMonth_TotalStyleCodeUnPlanned")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextMonth_TotalQtyPlanned" Text='<%# Eval("NextMonth_TotalQtyPlanned")%>'
                                    ToolTip='<%# Eval("NextMonth_TotalQtyPlannedTooltip", "{0:#,##}") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextMonth_TotalStyleCodePlanned" Text='<%# Eval("NextMonth_TotalStyleCodePlanned")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextMonth_TotalQtyUnPlanned" Text='<%# Eval("NextMonth_TotalQtyUnPlanned")%>'
                                    ToolTip='<%# Eval("NextMonth_TotalQtyUnPlannedTooltip", "{0:#,##}") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextMonth_TotalStyleCodeUnPlanned" Text='<%# Eval("NextMonth_TotalStyleCodeUnPlanned")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextToNextMonth_TotalQtyPlanned" Text='<%# Eval("NextToNextMonth_TotalQtyPlanned")%>'
                                    ToolTip='<%# Eval("NextToNextMonth_TotalQtyPlannedTooltip", "{0:#,##}") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextToNextMonth_TotalStyleCodePlanned" Text='<%# Eval("NextToNextMonth_TotalStyleCodePlanned")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextToNextMonth_TotalQtyUnPlanned" Text='<%# Eval("NextToNextMonth_TotalQtyUnPlanned")%>'
                                    ToolTip='<%# Eval("NextToNextMonth_TotalQtyUnPlannedTooltip", "{0:#,##}") %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblNextToNextMonth_TotalStyleCodeUnPlanned" Text='<%# Eval("NextToNextMonth_TotalStyleCodeUnPlanned")%>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <h2>
        Daily Shipment Report
        <asp:Label ID="lbldate" runat="server"></asp:Label>
    </h2>
    <asp:GridView ID="grdshipmentBydate" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdshipmentBydate_RowDataBound"
        ShowHeader="true" Width="100%" CellPadding="0" ShowFooter="true" FooterStyle-Height="30px">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    Factory
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFactoryName" runat="server" Text='<%#Eval("factory")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="61" />
                <FooterTemplate>
                    <strong>Total &nbsp; &nbsp;</strong>
                </FooterTemplate>
                <FooterStyle CssClass="al-right " ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Serial No<br />
                    Style No (Color)<br />
                    Contract No<br />
                    Line No
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; height: 12px; font-weight: bold;">
                                <asp:Label ID="lblserialNo" runat="server" Style="font-size: 12px;" Text='<%#Eval("SerialNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; height: 12px;">
                                <asp:Label ID="lblstyleNo" runat="server" Text='<%#Eval("StyleNumber")%>'></asp:Label>
                                (<asp:Label ID="Label1" runat="server" Text='<%#Eval("Fabric1Details")%>'></asp:Label>)
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; height: 12px;">
                                <asp:Label ID="lblContactNo" ForeColor="Gray" runat="server" Text='<%#Eval("ContractNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLineitemNo" ForeColor="Gray" runat="server" Text='<%#Eval("LineItemNumber")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="86" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Total Contract Qty.
                    <br />
                    Total Cut Qty.
                    <br />
                    Total Stitch
                    <br />
                    Total Shipped Qty.
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; height: 12px;">
                                <asp:Label ID="lbltotalcontractqty" Style="color: Gray;" runat="server" Text='<%#Eval("ContractQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; height: 12px;">
                                <asp:Label ID="lbltotalcutqty" runat="server" Style="color: Black;" Text='<%#Eval("cutQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; height: 12px;">
                                <asp:Label ID="lbltotalstich" runat="server" Style="color: Gray;" Text='<%#Eval("stichQty")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: Gray">
                                <asp:Label ID="lblTotalShippedQty" ForeColor="Black" Font-Bold="true" runat="server"
                                    Text='<%#Eval("shippedqty")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="67" VerticalAlign="Top" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; color: Gray; height: 12px;">
                                <strong id="sptotalcontract" runat="server"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; color: Black; height: 12px;">
                                <strong id="sptotcalcut" runat="server"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #aaa; color: Gray; height: 12px;">
                                <strong id="spTotalStitch" runat="server"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong id="spTotalShippedQty" forecolor="Black" font-bold="true" runat="server">
                                </strong>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle BackColor="#F1E9E9" VerticalAlign="Top" CssClass="f-12" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    CTSL % Rescan PCS
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCTSL" runat="server" Text='<%#Eval("ctsl")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="53" />
                <FooterStyle />
                <FooterTemplate>
                    <%-- <strong id="CTSL" runat="server" ></strong>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: bottom;">
                        <tr>
                            <td style="height: 48px; color: #98a9ca; border-bottom: 1px solid #98a9ca" colspan="4">
                                CTSL Detail
                            </td>
                        </tr>
                        <tr>
                            <td width="60%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                                Fault Name
                            </td>
                            <td width="10%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                                Qty
                            </td>
                            <td width="15%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                                Value
                            </td>
                            <td width="15%" style="text-align: center; color: #98a9ca;">
                                CTSL%
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="OrderDeatilID" Value='<%#Eval("OrderDetailID")%>' runat="server" />
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <asp:Repeater runat="server" ID="rptctsldetails" OnItemDataBound="rptctsldetails_OnItemDataBound">
                            <ItemTemplate>
                                <tr style="border-bottom: 1px solid #aaa;">
                                    <td width="60%" style="text-align: left; border-right: 1px solid #aaa;">
                                        <asp:Label ID="lblctsldetaild" Text='<%#Eval("fault")%>' runat="server"></asp:Label>
                                    </td>
                                    <td width="10%" style="text-align: center; border-right: 1px solid #aaa;">
                                        <asp:Label ID="lblctslqnty" Text='<%#Eval("UnshippedQty")%>' ForeColor="black" runat="server"></asp:Label>
                                    </td>
                                    <td width="15%" style="text-align: center; border-right: 1px solid #aaa;">
                                        <asp:Label ID="lblvalue" Text='<%#Eval("ctslvale")%>' ForeColor="black" runat="server"></asp:Label>
                                    </td>
                                    <td width="15%" style="text-align: center;">
                                        <asp:Label ID="lblctsl" Text='<%#Eval("ctsl")%>' ForeColor="red" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tdrp" runat="server">
                            <td style="text-align: right; padding-right: 5px; color: Gray;">
                                <b>Total </b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label ID="lblqntysum" ForeColor="black" runat="server"></asp:Label>
                                </b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label ID="lblvaluetotal" runat="server"></asp:Label></b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label ID="lblctslsum" ForeColor="red" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="210" VerticalAlign="Top" />
                <FooterTemplate>
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td style="text-align: right; border-right: 1px solid #ddd; height: 60px; padding-right: 5px;"
                                width="60%">
                                <asp:Label ID="ts" ForeColor="gray" Font-Bold="true" Font-Size="11px" runat="server"
                                    Text="Grand Total"></asp:Label>
                            </td>
                            <td style="text-align: center; border-right: 1px solid #ddd; height: 60px; font-size: 11px;"
                                width="10%">
                                <strong id="spctslqntySum" runat="server"></strong>
                            </td>
                            <td style="text-align: center; border-right: 1px solid #ddd; height: 60px; font-size: 11px;"
                                width="15%">
                                <strong id="spvalue" runat="server"></strong>
                            </td>
                            <td style="text-align: center; color: red; font-size: 11px;" width="15%">
                                <strong id="CTSL" runat="server"></strong>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle CssClass="al-right f-12" BackColor="#F1E9E9" />
            </asp:TemplateField>
            <%-- <asp:TemplateField>
            <HeaderTemplate>
                Price
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HiddenField ID="hdnCurrenyTag" runat="server" Value='<%#Eval("ConvertTo")%>' />
                <asp:Label ID="lblPrice" ForeColor="Gray" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="30" />
        </asp:TemplateField>--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    Shipped Value (lacs)<br />
                    <br />
                    Price
                </HeaderTemplate>
                <ItemTemplate>
                    <b>
                        <asp:Label ID="lblShippedValue" runat="server" Text='<%#Eval("ShipedValue")%>' Font-Size="12px"></asp:Label></b><br />
                    <br />
                    <asp:Label ID="lblPrice" ForeColor="Gray" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                    <asp:HiddenField ID="hdnCurrenyTag" runat="server" Value='<%#Eval("ConvertTo")%>' />
                </ItemTemplate>
                <ItemStyle Width="50" />
                <FooterTemplate>
                    <strong id="spShippedValue" runat="server"></strong>
                </FooterTemplate>
                <FooterStyle Font-Size="14px" />
            </asp:TemplateField>
            <%--  <asp:TemplateField Visible="false">
            <HeaderTemplate>
                Expss airing<br />
                CIF Air<br />
                50% CIF Air<br />
                Air to Mum<br />
                Inspn Fail &amp; Trpt
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <asp:Label ID="lblExpressAirline" runat="server" Text='<%#Eval("ExpressAirline")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <asp:Label ID="lblCIFAir" runat="server" Text='<%#Eval("CIFAir")%>'></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <asp:Label ID="lbl50CIF" runat="server" Text='<%#Eval("FiftyPercentCIFAir")%>'></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <asp:Label ID="lblAirToMumbai" runat="server" Text='<%#Eval("AirToMumbai")%>'></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <asp:Label ID="lblInspectionFailandTransport" runat="server" Text='<%#Eval("InspectionFailandTransport")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <ItemStyle Width="80" />
            <FooterTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <strong id="spExpressAirline" runat="server"></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <strong id="spCIF" runat="server"></strong>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <strong id="sp50CIF" runat="server"></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <strong id="sptotalAirToMumbai" runat="server"></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #ddd; height: 12px;">
                            <strong id="spInspection" runat="server"></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            <FooterStyle CssClass="f-12" />
        </asp:TemplateField>--%>
            <%-- <asp:TemplateField>
        <HeaderTemplate>
          CIF Air
        </HeaderTemplate>
            <ItemTemplate>
                
            </ItemTemplate>
            <ItemStyle Width="56" />
            
        </asp:TemplateField>--%>
            <%--<asp:TemplateField>
           <HeaderTemplate>
           50% CIF Air
        </HeaderTemplate>
            <ItemTemplate>
                
            </ItemTemplate>
            <ItemStyle Width="55" />
        </asp:TemplateField>--%>
            <%--<asp:TemplateField>
        <HeaderTemplate>
           Air to Mumbai
        </HeaderTemplate>
            <ItemTemplate>
                
            </ItemTemplate>
            <ItemStyle Width="56" />
        </asp:TemplateField>--%>
            <%-- <asp:TemplateField>
        <HeaderTemplate>
           Inspection Fail &amp; Transport
        </HeaderTemplate>
            <ItemTemplate>
                
            </ItemTemplate>
            <ItemStyle Width="73" />
            <FooterTemplate>
            
            </FooterTemplate>
        </asp:TemplateField>--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    Total Penalty<br />
                    Penalty %
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lblTotalPenalty" runat="server" Text='<%#Eval("TotalPenalty")%>'></asp:Label><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <asp:Label ID="lblPenaltyPercentAge" class="per" runat="server" Text='<%#Eval("PenaltyPercentAge")%>'></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="51" BackColor="#F1E9E9" VerticalAlign="Top" />
                <FooterTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <strong id="spTotalPenalty" runat="server"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: 1px solid #ddd; height: 12px;">
                                <strong id="spPenalty" runat="server" class="per"></strong>
                                <br />
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
                <FooterStyle BackColor="#F1E9E9" VerticalAlign="Top" CssClass="f-12" />
            </asp:TemplateField>
            <%-- <asp:TemplateField>
         <HeaderTemplate>
           Penalty %
        </HeaderTemplate>
            <ItemTemplate>
                
            </ItemTemplate>
            <ItemStyle Width="59"  />
            <FooterTemplate>
            
            </FooterTemplate>
        </asp:TemplateField>--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: bottom;">
                        <tr>
                            <td style="height: 48px; color: #98a9ca; border-bottom: 1px solid #98a9ca" colspan="5">
                                Performance
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                                Pass
                            </td>
                            <td width="20%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                                Fail
                            </td>
                            <td width="20%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                                TGT Eff.
                            </td>
                            <td width="20%" style="text-align: center; border-right: 1px solid #98a9ca; color: #98a9ca;">
                                Act. Eff.
                            </td>
                            <td width="20%" style="text-align: center; color: #98a9ca;">
                                ACH.
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--    <div>
                    <asp:Label ID="lblinlineinspectiondate_Name_username" Style="padding: 11px" runat="server"></asp:Label></div>--%>
                    <%-- <div>
                    <asp:Label ID="lblMidinspectiondateand_Name_username" Style="padding: 11px" runat="server" ></asp:Label></div>--%>
                    <%--        <div>
                    <asp:Label ID="lblFinalinspectiondate_Name_username" Style="padding: 11px" runat="server"></asp:Label></div>--%>
                    <%--<div>
                    <asp:Label ID="lblFinalBIHinspectiondate_Name_username" Style="padding: 11px" runat="server"></asp:Label></div>--%>
                    <%-- <asp:Label ID="lblinlineinspectiondate_Name" Visible="false" runat="server"></asp:Label>--%>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: bottom;">
                        <tr>
                            <td width="20%" style="text-align: center; border-right: 1px solid #ddd; border-bottom: 1px solid #ddd;">
                                <asp:Label ID="lblpass" Style="padding: 11px" runat="server"></asp:Label>
                            </td>
                            <td width="20%" style="text-align: center; border-right: 1px solid #ddd; border-bottom: 1px solid #ddd;">
                                <asp:Label ID="lblfail" Style="padding: 11px" runat="server"></asp:Label>
                            </td>
                            <td width="20%" style="text-align: center; border-right: 1px solid #ddd; border-bottom: 1px solid #ddd;">
                                <asp:Label ID="lbltargeteffi" Style="padding: 11px" runat="server"></asp:Label>
                            </td>
                            <td width="20%" style="text-align: center; border-right: 1px solid #ddd; border-bottom: 1px solid #ddd;">
                                <asp:Label ID="lblactualeiff" ForeColor="Black" Style="padding: 11px" runat="server"></asp:Label>
                            </td>
                            <td runat="server" id="tdach" width="20%" style="text-align: center; border-bottom: 1px solid #ddd;">
                                <asp:Label ID="lblach" Style="padding: 11px" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="97" CssClass="leftalign" ForeColor="Gray" />
                <FooterTemplate>
                    <strong id="sppenaltypercentage" visible="false" runat="server" class="per"></strong>
                </FooterTemplate>
                <FooterStyle CssClass="f-12" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    Mid Inspection
                    <br />
                    Name<br />
                    Date
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblMidinspectiondateand_Name" Visible="false" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="91" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    Final Inspection<br />
                    Name<br />
                    Date
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFinalinspectiondate_Name" Visible="false" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="96" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    Final BH inspection<br />
                    Name<br />
                    Date
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFinalBIHinspectiondate_Name" Visible="false" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="73" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Invoice No.<br />
                    Ex fact<br />
                    DC Date<br />
                    Ship mode
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%#Eval("InvoiceNumber")%>'></asp:Label><br />
                    <asp:Label ID="lblexfactdate" Style="color: Black; font-weight: bold;" runat="server"
                        Text='<%#Eval("ExfactDate")%>'></asp:Label><br />
                    <asp:Label ID="lbldcdate" Style="color: Gray;" runat="server" Text='<%#Eval("DcDate")%>'></asp:Label><br />
                    <asp:Label ID="lblmodeName" Style="color: Gray;" runat="server" Text='<%#Eval("ModeName")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="88" ForeColor="Gray" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <HeaderTemplate>
                    Ex fact
                </HeaderTemplate>
                <ItemTemplate>
                    <%--<asp:Label ID="lblexfactdate" Style="color:Gray; font-weight: bold;" runat="server"
                    Text='<%#Eval("ExfactDate")%>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle Width="67" />
                <FooterTemplate>
                    <%--<strong id="Strong8" runat="server"></strong>--%>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h2>
    </h2>
    <br />
    <asp:Label ID="lblplanning" runat="server"></asp:Label>
    <br />
    <br />
