<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookingCalculator.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.BookingCalculator" %> 

<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
<script type="text/javascript">

    $(function () {
        $(".th").datepicker({ dateFormat: 'dd M y (D)' });

    });
  
  </script> 
<script type="text/javascript">

    $(document).ready(function () {
        console.log("ready!");
    });


</script>

<script type="text/javascript">


    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

//    var leadTime;
//    var expectedDate;
//    var deliveryDate;         leadTime = $('input.lead-time', '#BookingCalculator1_txtAFExpectedBookingDate');

//           expectedDate = $('input.expected-booking-date', '#BookingCalculator1_txtAFExpectedBookingDate');
//           deliveryDate = $('input.calculated-delivery-date', '#BookingCalculator1_txtAFExpectedBookingDate');

//    $(function () {
//        debugger;
//        alert('change days');
//        leadTime = $('input.lead-time', '#BookingCalculator1_txtAFExpectedBookingDate');

//        expectedDate = $('input.expected-booking-date', '#BookingCalculator1_txtAFExpectedBookingDate');
//        deliveryDate = $('input.calculated-delivery-date', '#BookingCalculator1_txtAFExpectedBookingDate');

//        //CalculateDeliveryDate();
//                
//               

//        leadTime.keyup();
//    });


           function ChangeDeliveryDate_ByLeadTime(obj, count) {
               //debugger;  
               var ExpectedDate;              
               var DeliveryDate;

               var days = obj.value;
               if (count == 1) {
                   ExpectedDate = $("#BookingCalculator1_txtAFExpectedBookingDate").val();
                   var dd = new Date(ParseDateToSimpleDate(ExpectedDate));
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtAFCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 2) {
                   ExpectedDate = $("#BookingCalculator1_txtAHExpectedBookingDate").val();
                   var dd = new Date(ParseDateToSimpleDate(ExpectedDate));
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtAHCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 3) {
                   ExpectedDate = $("#BookingCalculator1_txtSFExpectedBookingDate").val();
                   var dd = new Date(ParseDateToSimpleDate(ExpectedDate));
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtSFCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 4) {
                   ExpectedDate = $("#BookingCalculator1_txtSHExpectedBookingDate").val();
                   var dd = new Date(ParseDateToSimpleDate(ExpectedDate));
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtSHCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 5) {
                   ExpectedDate = $("#BookingCalculator1_txtFOBExpectedBookingDate").val();
                   var dd = new Date(ParseDateToSimpleDate(ExpectedDate));
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtFOBCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
           }

           function ChangeDeliveryDate_ByExpected(obj, count) {
               //debugger;  
               var ExpectedDate;
               var DeliveryDate;
               var days;
               ExpectedDate = obj.value;
               var dd = new Date(ParseDateToSimpleDate(ExpectedDate));
               if (count == 1) {
                   days = $("#BookingCalculator1_txtAFLeadTime").val();
                   dd = dd.add(days * 7).days();                   
                   $("#BookingCalculator1_txtAFCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 2) {
                   days = $("#BookingCalculator1_txtAHLeadTime").val();
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtAHCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 3) {
                   days = $("#BookingCalculator1_txtSFLeadTime").val();
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtSFCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 4) {
                   days = $("#BookingCalculator1_txtSHLeadTime").val();
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtSHCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
               if (count == 5) {
                   days = $("#BookingCalculator1_txtFOBLeadTime").val();
                   dd = dd.add(days * 7).days();
                   $("#BookingCalculator1_txtFOBCalculatedDeliveryDate").val(ParseDateToDateWithDay(dd));
                   return false;
               }
           }

//    function CalculateDeliveryDate() {
//        debugger;
//        for (var i = 0; i < deliveryDate.length; i++) {
//            var dd = new Date(ParseDateToSimpleDate(expectedDate[i].value));
//            dd = dd.add(leadTime[i].value * 7).days();
//            deliveryDate[i].value = ParseDateToDateWithDay(dd);
//        }
//    }

    function CalculateLeadTime(sender) {
        //debugger;
        var txtLeadTime = sender.parents('div.booking_calculator tr').find('.lead-time');
        var txtExpectedDate = sender.parents('div.booking_calculator tr').find('.expected-booking-date');

        var expectedDate = new Date(ParseDateToSimpleDate(txtExpectedDate.val()));
        var deliveryDate = new Date(ParseDateToSimpleDate(sender.val()));

        if (deliveryDate < expectedDate) {
            sender.val(txtExpectedDate.val());
            txtLeadTime.val(0);
            return;
        }

        var leadTime = Math.round((deliveryDate - expectedDate) / (1000 * 60 * 60 * 24 * 7));
        txtLeadTime.val(leadTime);
    }
   

</script>

<%--<div class="booking_calculator_header" align=center>
    
    <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "LEADTIME / DELIVERY DATE TABLE" : "Booking Calculator"%>
</div>--%>
<div class="booking_calculator">
    <table cellspacing="0" width="100%" style="border-collapse: collapse">
        <tr>
            <th class='<%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "" : "vertical_text" %>'>
                MODE
            </th>
            <th class='<%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "" : "vertical_text" %>'>
                LEAD TIME
            </th>
            <th>
                <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "ALL ORDERS BOOKED IN THE WEEK STARTING" : "Exp. Book DT."%>
            </th>
            <th>
                <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "EX-FACTORY (INCASE OF FOB ACCOUNTS) OR LANDED DELIVERY DATES" : "Calc. Del. DT."%>
                <asp:Label runat="server" ID='lblDeliveryDate' Text='' />
            </th>
        </tr>
        <tr>
            <td class='<%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "form_small_heading_Blue" : "vertical_text form_small_heading_Blue" %>'>
                <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "LANDED AIR / BOXED" : "AF"%>
            </td>
            <td>
                <asp:TextBox CssClass="numeric-field-without-decimal-places lead-time" ID="txtAFLeadTime" onchange="ChangeDeliveryDate_ByLeadTime(this, 1);"
                    runat="server"></asp:TextBox>  
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style expected-booking-date" ID="txtAFExpectedBookingDate" onchange="ChangeDeliveryDate_ByExpected(this, 1);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style calculated-delivery-date" ID="txtAFCalculatedDeliveryDate"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class='<%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "form_small_heading_Blue" : "vertical_text form_small_heading_Blue" %>'>
                <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "LANDED AIR / HANGING" : "AH"%>
            </td>
            <td>
                <asp:TextBox CssClass="numeric-field-without-decimal-places lead-time" ID="txtAHLeadTime" onchange="ChangeDeliveryDate_ByLeadTime(this, 2);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style expected-booking-date" ID="txtAHExpectedBookingDate" onchange="ChangeDeliveryDate_ByExpected(this, 2);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style calculated-delivery-date" ID="txtAHCalculatedDeliveryDate" 
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class='<%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "form_small_heading_Blue" : "vertical_text form_small_heading_Blue" %>'>
                <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "LANDED SEA / BOXED" : "SF"%>
            </td>
            <td>
                <asp:TextBox CssClass="numeric-field-without-decimal-places lead-time" ID="txtSFLeadTime" onchange="ChangeDeliveryDate_ByLeadTime(this, 3);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style expected-booking-date" ID="txtSFExpectedBookingDate" onchange="ChangeDeliveryDate_ByExpected(this, 3);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style calculated-delivery-date" ID="txtSFCalculatedDeliveryDate"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class='<%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "form_small_heading_Blue" : "vertical_text form_small_heading_Blue" %>'>
                <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "LANDED AIR / HANGING" : "SH"%>
            </td>
            <td>
                <asp:TextBox CssClass="numeric-field-without-decimal-places lead-time" ID="txtSHLeadTime" onchange="ChangeDeliveryDate_ByLeadTime(this, 4);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style expected-booking-date" ID="txtSHExpectedBookingDate" onchange="ChangeDeliveryDate_ByExpected(this, 4);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style calculated-delivery-date" ID="txtSHCalculatedDeliveryDate"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class='<%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "form_small_heading_Blue" : "vertical_text form_small_heading_Blue" %>'>
                <%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "FOB SHIPMENTS BOXED OR HANGING" : "FOB"%>
            </td>
            <td>
                <asp:TextBox CssClass="numeric-field-without-decimal-places lead-time" ID="txtFOBLeadTime" onchange="ChangeDeliveryDate_ByLeadTime(this, 5);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style expected-booking-date" ID="txtFOBExpectedBookingDate" onchange="ChangeDeliveryDate_ByExpected(this, 5);"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox CssClass="th  date_style calculated-delivery-date" ID="txtFOBCalculatedDeliveryDate"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
<br />

