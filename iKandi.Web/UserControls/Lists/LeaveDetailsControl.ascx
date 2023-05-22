<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveDetailsControl.ascx.cs"
    Inherits="iKandi.Web.LeaveDetailsControl" %>
<div class="form_box">
    <div class="form_heading">
        Holiday Detail
    </div>
    <table class="item_list fixed-header" align="left">
        <tr>
            <th>
                Apply For Holiday
            </th>
            <td align="left">
                <%= LeaveStatus %>
                (<%= LeaveStatus %>)
            </td>
        </tr>
        <tr>
            <th>
                Holiday applied on
            </th>
            <td align="left">
                <%= RequestDate %>
            </td>
        </tr>
        <tr>
            <th>
                No of Days
            </th>
            <td align="left">
                <%= DaysOnLeave %>
            </td>
        </tr>
        <tr>
            <th>
                Holiday from
            </th>
            <td align="left">
                <%= FromSession %>
                of
                <%= FromDate %>
                to
                <%= ToSession %>
                of
                <%= ToDate %>
            </td>
        </tr>
        <tr>
            <th>
                Reason for Holiday
            </th>
            <td align="left">
                <%= Reason %>
            </td>
        </tr>
        <tr>
            <th>
                Contact Details
            </th>
            <td align="left">
                <%= ContactDetails %>
            </td>
        </tr>
        <tr>
            <th>
                Holiday Status
            </th>
            <td align="left">
                <%= LeaveStatus %>
                By
                <%= AppliedTo %>
            </td>
        </tr>
        <tr>
            <th>
                Comments
            </th>
            <td align="left">
                <%= Comment %>
            </td>
        </tr>
    </table>
</div>
