<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="clientHomePage.ascx.cs"
    Inherits="iKandi.Web.clientHomePage" %>
    
    <%@ Register Src="../Forms/BookingCalculator.ascx" TagName="BookingCalculator"
    TagPrefix="uc1" %>
    
    <script type="text/javascript">

        function ShowBookingCalculator() 
        {
            $("#bookingCalculatorContainer").show(); 
        }

    </script>
    <table width="100%" cellspacing="0" cellpadding="0">
    <tr><td colspan="2">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                 <tr>
                    <td width="10" class="da_table_heading_bg_left"></td>
                    <td class="da_table_heading_bg"><span class="da_h1">WELCOME TO THE IKANDI EXTRANET</span></td>
                    <td class="da_table_heading_bg" style="text-align:right;"><a href="javascript:void(0)" onclick="ShowBookingCalculator()">
                    Booking Calculator</a></td>
                    <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
                 </tr>
    </table>
    </td></tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr><td colspan="2" style="text-align:center;"><a href="ClientDepartmentOrder.aspx">PLEASE CLICK HERE TO VIEW CRITICAL PATH ON EXISTING ORDERS</a></td></tr>
    <tr><td colspan="2">&nbsp;</td></tr>
<tr>
        <td>
            <table width="99%" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
             <caption class="caption_headings">IKANDI CONTACT DETAILS</caption>
               <tr><td>
             <asp:GridView Width="100%" ID="grdIkandi" runat="server" AutoGenerateColumns="false" CssClass=" fixed-header item_list1" >
             <Columns>
             <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation">
            </asp:BoundField>
             <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
            </asp:BoundField>
             <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
            </asp:BoundField>
             <asp:BoundField DataField="Contact" HeaderText="Contact Number" SortExpression="Contact">
            </asp:BoundField>
             </Columns>
            </asp:GridView>
            </td></tr>
            </table>
        </td>
    </tr>
<tr><td>&nbsp;</td></tr>
<tr>
        <td>
            <table width="99%" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
                <caption class="caption_headings">FACTORY CONTACT DETAILS</caption>
                <tr><td>
            <asp:GridView Width="100%" ID="grdBipl" runat="server" AutoGenerateColumns="false" CssClass=" fixed-header item_list1" >
             <Columns>
             <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation">
            </asp:BoundField>
             <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
            </asp:BoundField>
             <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
            </asp:BoundField>
             <asp:BoundField DataField="Contact" HeaderText="Contact Number" SortExpression="Contact">
            </asp:BoundField>
             </Columns>
            </asp:GridView>
                </td></tr>
            </table>
        </td>
    </tr>
 </table>
 <div class="divRemarks" id='bookingCalculatorContainer'>
        <div class="form_box">
            <uc1:BookingCalculator ID="BookingCalculator1" runat="server" />
            <div align=center>
                 <input type="button" class="close do-not-disable" onclick="closeRemarks()" />
            </div>
        </div>
    </div>