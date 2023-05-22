<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRStaffLateComersEmployeeReport.aspx.cs"
    Inherits="iKandi.Web.HRStaffLateComersEmployeeReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: verdana !important;
        }
        table
        {
            font-family: verdana;
            border-color: gray;
            border-collapse: collapse;
        }
        th
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-family: arial,halvetica;
            font-size: 10px;
            padding: 0px 0px;
            text-align: center;
            text-transform: capitalize;
            border-color: #b3aaaa;
        }
        table td
        {
            font-size: 10px;
            text-align: center;
            border-color: #aaa;
            text-transform: capitalize;
            color: gray;
            padding: 0px 0px;
            font-family: arial,halvetica;
        }
        .item_list1 td, .item_list1 th
        {
            padding: 5px 0px !important;
        }
        .item_list1 td
        {
            border-color: #c1bfbf;
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
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            background: #39589C;
            color: #fff;
            width: 845px;
            text-align: center;
            text-transform: capitalize;
            letter-spacing: 1px;
        }
        h3
        {
            font-size: 11px;
            font-weight: bold;
            padding: 5px;
            background: #39589C;
            color: #fff;
            width: 150px;
            text-align: center;
            margin: 0px;
            border-radius: 5px 5px 0px 0px;
            text-transform: capitalize;
            letter-spacing: 1px;
        }
        .row-fir th
        {
            font-weight: bold;
            font-size: 11px;
        }
        table td table td
        {
            border-color: #ddd;
        }
        
        
        .SUPPLY-MANA td input
        {
            width: 35%;
        }
        .imageField
        {
            background-image: url(submit.jpg);
            height: 28px;
            width: 105px;
        }
        .process
        {
            padding: 0px;
            margin: 0px;
        }
        .process li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li input
        {
            width: 10%;
        }
        .supply_type
        {
            padding: 0px;
            margin: 0px;
        }
        .supply_type li
        {
            list-style: none;
            text-align: left;
            border-bottom: 1px solid gray;
            text-transform: capitalize;
        }
        .process li:last-child
        {
            border-bottom: 0px;
        }
        input[type="text"], select
        {
            width: 95% !important;
            color: gray !important;
            text-transform: capitalize !important;
            background-color: White;
        }
        .pad
        {
            text-align: left;
            padding-left: 25px;
        }
        .ths
        {
            background: #3b5998;
            font-weight: normal;
            color: #fff;
            font-family: arial,halvetica;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
        }
        .grds
        {
            margin-left: 20px;
        }
        input[type="file"]
        {
            width: 90%;
            overflow: hidden;
            display: none;
        }
        .show, .hide
        {
            cursor: pointer;
        }
        a.UpdateBtn
        {
            background: url(../../images/update-icon.png) no-repeat left top;
            padding-left: 25px;
        }
        
        a.DeleteBtn
        {
            background: url(../../images/delete-icon.png) no-repeat left top;
            padding-left: 25px;
            padding-top: 3px;
        }
        /* The Modal (background) */
        .modal
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        
        /* Modal Content */
        .modal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 550px;
            margin-top: 12%;
        }
        
        /* The Close Button */
        .close
        {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }
        
        .close:hover, .close:focus
        {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
        .inputborder
        {
            border: 1px solid #cccccc !important;
        }
        .pending_order_heading
        {
            background: #dddfe4;
            width: 488px;
            margin: 0px;
            color: #575759;
            border: 1px solid #999;
            border-bottom: 0px;
            font-weight: 600;
            font-family: arial,halvetica;
            font-size: 10px;
        }
        .backcolorstages
        {
            background: #fdfd96;
        }
        .hidesstages
        {
            display: none;
        }
       .dlaytime
       {
           width:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="counter">
        </div>
        <div style="width: 80%; margin-left: 20px; font-size: 12px;">
            <h4 style="font-size: 12px; font-weight: 500; margin: 5px 0px 0px; font-family: arial,halvetica;">
                Hi Team BIPL,</h4>
            <br />
            <br />
            <a href="#" runat="server" id="aLinkAttandenceSheet" style="text-decoration: none;
                font-family: arial,halvetica; color: Blue">Today Attendance Sheet </a>
        </div>
        <br />
        <table cellpadding="0" cellspacing="0" border="0" style="width: 600px; margin: 10px 0px 0px;
            text-align: center; margin-left: 20px;">
            <tr>
                <td class="pending_order_heading" style="color: #575759; font-family: arial,halvetica;
                    margin: 0px 0px 0px; padding: 3px; width: 581px; max-width: 581px; text-align: center;">
                    Late Comers above 15 minutes monthly average Based on 3 months
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdattlatecommerc" runat="server" AutoGenerateColumns="False" CssClass="grds"
            ShowHeader="true" EmptyDataText="No Record Found!" Width="600px" HeaderStyle-Font-Names="Arial"
            HeaderStyle-HorizontalAlign="Center" OnRowDataBound="grdattlatecommerc_RowDataBound"
            BorderWidth="1" rules="all" HeaderStyle-CssClass="ths">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <Columns>
                <asp:TemplateField Visible="false" HeaderText="Seq.No.">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblseq" Text='<%# Eval("id")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rank">
                    <ItemTemplate>
                        <asp:Label ID="lblRank" ForeColor="#000" Text='<%# Eval("RowNumberRank")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label ID="lblNames" ForeColor="#000" Text='<%# Eval("Names")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation" Text='<%# Eval("DesignationName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" />
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="Avg. Intime Based  in last 6 Month">
                    <ItemTemplate>
                        <asp:Image ID="imhuserimage" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/photo/" + Eval("UserProfilePic").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Name">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartMentName" Text='<%# Eval("DepartMentName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reporting Time">
                    <ItemTemplate>
                        <asp:Label ID="lblIntime" Text='<%# Eval("Intime")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                  In Time
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;min-width:40px">
                                   12 Month
                                </th>
                                <th style="min-width:40px">
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:40px">
                                    <asp:Label ID="lblavg" ForeColor="red" Font-Bold="true" Text='<%# Eval("AvgInTime12")%>' runat="server"></asp:Label>
                                </td>
                                <td style="width:40px">
                                     <asp:Label ID="lblIntimes" Text='<%# Eval("AvgInTime3")%>' runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                    Delay
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;min-width:40px">
                                   12 Month
                                </th>
                                <th style="min-width:40px">
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:40px">
                                   <asp:Label ID="lblIdealAvgIntimes" ForeColor="gray" Font-Bold="false" runat="server"></asp:Label>
                                </td>
                                <td style="width:40px">
                                  <asp:Label ID="lblIdealAvgIntimes_3m" ForeColor="gray" Font-Bold="false" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <%--<h2 style="margin-left: 20px;" class="pending_order_heading">
           
        </h2>--%>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 600px; margin: 10px 0px 0px;
            text-align: center; margin-left: 20px;">
            <tr>
                <td class="pending_order_heading" style="color: #575759; font-family: arial,halvetica;
                    margin: 0px 0px 0px; padding: 3px; width: 581px; max-width: 581px; text-align: center;">
                   Leave takers beyond 10 days in last 3 months
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdleave" runat="server" AutoGenerateColumns="False" CssClass="grds"
            ShowHeader="true" EmptyDataText="No Record Found!" Width="600px" HeaderStyle-Font-Names="Arial"
            HeaderStyle-HorizontalAlign="Center" BorderWidth="1" rules="all" HeaderStyle-CssClass="ths"
            OnRowDataBound="grdleave_RowDataBound">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <Columns>
                 <asp:TemplateField HeaderText="Rank">
                    <ItemTemplate>
                        <asp:Label ID="lblRank" ForeColor="#000" Text='<%# Eval("RowNumberRank")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label ID="lblNames" ForeColor="#000" Text='<%# Eval("Names")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation" Text='<%# Eval("DesignationName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Name">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartMentName" Text='<%# Eval("DepartMentName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="90px" />
                </asp:TemplateField>
                 <asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                   Monthly Leaves 
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;">
                                   12 Month
                                </th>
                                <th>
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:60px">
                                   <asp:Label ID="lblavg" ForeColor="red" Font-Bold="true" Text='<%# Eval("AvgMonthlyInDays12month")%>' runat="server"></asp:Label>
                                </td>
                                <td style="width:60px">
                                    <asp:Label ID="lblavg3" ForeColor="red" Font-Bold="true" Text='<%# Eval("AvgMonthlyInDays3month")%>' runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>

                  <asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                    Total Leaves
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;">
                                   12 Month
                                </th>
                                <th>
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:60px">
                                  <asp:Label ID="lbltotalLeave6Month" runat="server" Text='<%# Eval("TotalLeaveIn12Months")%>'></asp:Label>
                                </td>
                                <td style="width:60px">
                                   <asp:Label ID="lbltotalLeave3Month" runat="server" Text='<%# Eval("TotalLeaveIn3Months")%>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
        <br />
        <table cellpadding="0" cellspacing="0" border="0" style="width: 600px; margin: 10px 0px 0px;
            text-align: center; margin-left: 20px;">
            <tr>
                <td class="pending_order_heading" style="color: #575759; font-family: arial,halvetica;
                    margin: 0px 0px 0px; padding: 3px; width: 581px; max-width: 581px; text-align: center;">
                    Top 10 best performers  in terms of InTime based on last 3 Months
                </td>
            </tr>
        </table>
        <asp:GridView ID="GrvTopPerformers" runat="server" AutoGenerateColumns="False" CssClass="grds"
            ShowHeader="true" EmptyDataText="No Record Found!" Width="600px" HeaderStyle-Font-Names="Arial"
            HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GrvTopPerformers_RowDataBound"
            BorderWidth="1" rules="all" HeaderStyle-CssClass="ths">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <Columns>
                <asp:TemplateField Visible="false" HeaderText="Seq.No.">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblseq" Text='<%# Eval("id")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rank">
                    <ItemTemplate>
                        <asp:Label ID="lblRank" ForeColor="#000" Text='<%# Eval("RowNumberRank")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label ID="lblNames" ForeColor="#000" Text='<%# Eval("Names")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation" Text='<%# Eval("DesignationName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" />
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="Avg. Intime Based  in last 6 Month">
                    <ItemTemplate>
                        <asp:Image ID="imhuserimage" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/photo/" + Eval("UserProfilePic").ToString()) %>' />
                    </ItemTemplate>
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Name">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartMentName" Text='<%# Eval("DepartMentName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="110px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reporting Time">
                    <ItemTemplate>
                        <asp:Label ID="lblIntime" Text='<%# Eval("Intime")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60px" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                  In Time
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;min-width:40px">
                                   12 Month
                                </th>
                                <th style="min-width:40px">
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:40px">
                                    <asp:Label ID="lblavg" ForeColor="black" Font-Bold="true" Text='<%# Eval("AvgInTime12")%>' runat="server"></asp:Label>
                                </td>
                                <td style="width:40px">
                                     <asp:Label ID="lblIntimes" Text='<%# Eval("AvgInTime3")%>' runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                    Delay
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;min-width:40px">
                                   12 Month
                                </th>
                                <th style="min-width:40px">
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:40px">
                                   <asp:Label ID="lblIdealAvgIntimes" ForeColor="gray" Font-Bold="false" runat="server"></asp:Label>
                                </td>
                                <td style="width:40px">
                                  <asp:Label ID="lblIdealAvgIntimes_3m" ForeColor="gray" Font-Bold="false" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
         <table cellpadding="0" cellspacing="0" border="0" style="width: 600px; margin: 10px 0px 0px;
            text-align: center; margin-left: 20px;">
            <tr>
                <td colspan="2" class="pending_order_heading" style="color: #575759; font-family: arial,halvetica;
                    margin: 0px 0px 0px; padding: 3px; width: 581px; max-width: 581px; text-align: center;">
                    BIPL Summary
                </td>
            </tr>
            <tr>
               <td class="pending_order_heading" style="width:300px;border:1px solid #999;border-bottom:0px"> Average Delay in minutes</td>
               <td class="pending_order_heading" style="width:300px;border:1px solid #999;border-bottom:0px"> Monthly Average Leaves</td>
            </tr>
        </table>
       <asp:GridView ID="GrvBIPLSummary" runat="server" AutoGenerateColumns="False" CssClass="grds"
            ShowHeader="true" EmptyDataText="No Record Found!" Width="600px" HeaderStyle-Font-Names="Arial"
            HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GrvBIPLSummary_RowDataBound"
            BorderWidth="1" rules="all" HeaderStyle-CssClass="ths">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <Columns>
             <%--   <asp:TemplateField Visible="false" HeaderText="Seq.No.">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblseq" Text='<%# Eval("id")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="1 Year">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation" ForeColor="#000" Text='<%# Eval("BIPLAvgDelay12Months")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="6 Month">
                    <ItemTemplate>
                        <asp:Label ID="lblNames" ForeColor="#000" Text='<%# Eval("BIPLAvgDelay6Months")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="3 Month">
                    <ItemTemplate>
                        <asp:Label ID="lblRank" ForeColor="#000" Text='<%# Eval("BIPLAvgDelay3Months")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="1 Year">
                    <ItemTemplate>
                        <asp:Label ID="lblIntime" ForeColor="#000" Text='<%# Eval("BIPLAvgMonthlyLeave12Months")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="6 Month">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartMentName" ForeColor="#000" Text='<%# Eval("BIPLAvgMonthlyLeave6Months")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="3 Month">
                    <ItemTemplate>
                        <asp:Label ID="lblDesignation12" ForeColor="#000" Text='<%# Eval("BIPLAvgMonthlyLeave3Months")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>              
              
                
                <%--<asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                  In Time
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;min-width:40px">
                                   6 Month
                                </th>
                                <th style="min-width:40px">
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:40px">
                                    <asp:Label ID="lblavg" ForeColor="red" Font-Bold="true" Text='<%# Eval("AvgInTime")%>' runat="server"></asp:Label>
                                </td>
                                <td style="width:40px">
                                     <asp:Label ID="lblIntimes" Text='<%# Eval("AvgInTime3")%>' runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table class="dlaytime">
                            <tr>
                                <th colspan="2" style="border-bottom:1px solid #999">
                                    Delay
                                </th>
                            </tr>
                            <tr>
                                <th style="border-right:1px solid #999; padding: 0px 0px;min-width:40px">
                                   6 Month
                                </th>
                                <th style="min-width:40px">
                                    3 Month
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table class="dlaytime">
                          
                            <tr>
                                <td  style="border-right:1px solid #999; padding: 6px 0px;width:40px">
                                   <asp:Label ID="lblIdealAvgIntimes" ForeColor="gray" Font-Bold="false" runat="server"></asp:Label>
                                </td>
                                <td style="width:40px">
                                  <asp:Label ID="lblIdealAvgIntimes_3m" ForeColor="gray" Font-Bold="false" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>


        <br />
        <p style="font-size:13px;margin-bottom: 4px;margin-left:20px;"><b style="font-size:14px;">Note:</b> Will be effective from Q3 onwards.(2020 - 21).</p>
        <p style="font-size:13px;margin-bottom: 4px;margin-left:42px;margin-top:4px"><b>Late Coming:</b> Top 10 from the table for the qtr, if avg delay is above 15 mins, will be penalised 20% of their qtr incentive.</p>
        <p style="font-size:13px;margin-top: 4px;margin-left:42px;"><b>Leave Taking:</b> Top 10 from the table for the qtr, if total leaves for qtr is above 15 days, will be penalised 20% of their qtr incentive.</p>
        <br />

        <div style="margin-left: 20px; font-size: 12px;">
            <strong>Thanks & Best Regards </strong>
            <br />
            HR Teams</div>
        <div style='margin-top: 10px; margin-left: 20px;'>
            <img src='http://boutique.in/images/certificate.jpg' /></div>
    </div>
    </form>
</body>
</html>
