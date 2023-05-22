<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricFourPointCheckInspection.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricFourPointCheckInspection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            font-family: Arial;
            font-size: 10px;
        }
        .AddClass_Table
        {
            border-collapse: collapse;
            font-family: Arial;
            width: 100%;
            border: 1px solid #999;
        }
        .AddClass_Table th
        {
            background: #dddfe4;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 10px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial;
            text-align: left;
        }
        .RightSide table
        {
            border-collapse: collapse;
        }
        .RightSide table th
        {
            color: #6b6464;
            font-weight: 500;
            border: 1px solid #d2d2d2;
            padding: 5px 5px;
        }
        .RightSide table td
        {
            border: 1px solid #dbd8d8;
            padding: 5px 5px;
        }
        .minWidthTh
        {
            min-width: 80px;
        }
        .minWidthThSize
        {
            min-width: 120px;
        }
        .AddClass_Table td
        {
            border: 1px solid #dbd8d8;
            font-size: 10px;
            padding: 0px 3px;
            color: #0c0c0c;
            height: 12px;
            font-family: Arial;
            min-width: 80px;
        }
        .AddClass_Table td:first-child
        {
            border-left-color: #999 !important;
        }
        .AddClass_Table td:last-child
        {
            border-right-color: #999 !important;
        }
        
        .AddClass_Table.MarTop th
        {
            text-align: center;
        }
        .AddClass_Table.MarTop td
        {
            text-align: center;
        }
        .ColorBlackBold
        {
            color: #000;
            font-weight: 600;
        }
        .ColorBlue
        {
            color: blue;
        }
        .ColorGray
        {
            color: gray;
        }
        .ColorGrayBold
        {
            color: gray;
            font-weight: 600;
        }
        .ColorRedStrick
        {
            color: red;
            position: relative;
            top: 2px;
        }
        .TopHeader
        {
            width: 100%;
            font-size: 15px;
            color: #fff;
            text-align: center;
            background: #39589C;
            margin-bottom: 5px;
            padding: 3px 0px;
            position: relative;
        }
        .txtControl
        {
            width: 94%;
            margin: 2px 2px;
            font-size: 11px;
        }
        td.minWidth
        {
            min-width: 104px;
        }
        .txtCenter
        {
            text-align: center;
        }
        th.txtCenter
        {
            text-align: center;
        }
        .GrdtxtControl
        {
            width: 85%;
            margin: 2px 2px;
        }
        .MarTop
        {
            margin-top: 5px;
        }
        td.RadioLable
        {
            width: 100px;
        }
        td.RadioLable label
        {
            position: relative;
            top: -3px;
        }
        .facolor
        {
            font-size: 15px;
        }
        .bordertable i
        {
            font-size: 12px;
            margin: 0 2px;
        }
        .editbucolor
        {
            color: green;
        }
        .m-r-5
        {
            margin-right: 5px;
        }
        .TotalRw td
        {
            text-align: center;
            font-size: 13px;
            background: #f1f1f1;
            font-weight: 600;
            padding: 3px 5px;
        }
        ul
        {
            margin: 0px;
            padding: 5px 0px 0px 14px;
        }
        ul li
        {
            padding: 5px 0px 0px 0px;
            color: gray;
        }
        .RightSide input[type="radio"]
        {
            position: relative;
            top: 2px;
        }
        .RightSide
        {
            /* box-shadow: -13px -2px 36px -2px #ccc; */
            box-shadow: 1px 0px 5px 1px #ccc;
            padding: 10px 10px;
            position: relative;
            top: 6px;
            padding-top: 30px;
        }
        input[type="checkbox"]
        {
            position: relative;
            top: 2px;
        }
        .GMCheckbox
        {
            text-align: right;
            padding-right: 10px;
            padding-top: 60px;
            padding-bottom: 0px;
            font-size: 12px;
        }
        .QACheckbox
        {
            text-align: left;
            padding-right: 10px;
            padding-top: 10px;
            font-size: 12px;
            width: 246px;
            float: left;
        }
        .AllChecker
        {
            text-align: center;
            padding-top: 30px;
            clear: both;
        }
        .btnSubmit
        {
            font-size: 12px;
            padding: 5px 10px;
            color: #fff;
            background: green;
            margin-right: 5px;
            border-radius: 2px;
            border: 1px solid green;
        }
        .btnClose
        {
            font-size: 12px;
            padding: 5px 10px;
            color: #fff;
            background: green;
            margin-right: 5px;
            border-radius: 2px;
        }
        .btnPrint
        {
            font-size: 12px;
            padding: 5px 15px;
            color: #fff;
            background: #39589C;
            margin-right: 5px;
            border-radius: 2px;
            border: 1px solid #39589C;
        }
        .RightSide span
        {
            color: #6b6464;
        }
        .GreigeShrnk
        {
            position: absolute;
            left: 5px;
            font-size: 12px;
            top: 5px;
            color: #d8d8d8;
        }
        .ReshShrnk
        {
            position: absolute;
            left: 120px;
            font-size: 12px;
            top: 5px;
            color: #d8d8d8;
        }
        .DisplayBlock
        {
            display: block;
            width: 108px;
        }
        .DisplayBlock .txtRaise
        {
            width: 25px;
            height: 9px;
            text-align: center;
            margin: 2px 2px;
        }
        .DisInlineBlock
        {
            width: 67px;
            display: inline-block;
        }
        .LavContainer
        {
            padding-top: 1px;
        }
        .LavContainer span
        {
            color: #6b6464;
        }
        .LavContainer table
        {
            border-collapse: collapse;
            width: 98%;
        }
        .LavContainer table th
        {
            color: #6b6464;
            font-weight: 500;
            border: 1px solid #d2d2d2;
            padding: 5px 5px;
        }
        .LavContainer table td
        {
            border: 1px solid #d2d2d2;
            padding: 4px 4px;
        }
        .txtWidth
        {
            float: left;
            height: 10px;
            width: 30px;
        }
        #fileToUpload
        {
            width: 84px;
            font-size: 10px;
        }
        select
        {
            font-size: 10px;
        }
        .RightSidedate
        {
            float: right;
            position: relative;
            top: 2px;
        }
        .LavContainer input[type="checkbox"]
        {
            position: relative;
            top: -1px;
        }
        .Passfail
        {
            background: #fff1f1;
        }
        .Passfail label
        {
            position: relative;
            top: -2px;
        }
        input[type="text"]
        {
            font-size: 10px;
            width: 95%;
            text-transform: capitalize;
        }
        .BalckgroundColor
        {
            background: #fff1f1;
        }
        textarea
        {
            text-transform: capitalize;
            font-size: 10px;
        }
        #dvHistory
        {
            width: 98%;
            padding: 6px 0px;
            height: 47px;
            max-height: 47px;
            overflow: auto;
        }
        a
        {
            text-decoration: none;
        }
        .TotalTable
        {
            border: 0px;
            border-collapse: collapse;
        }
        .TotalTable td
        {
            border: 1px solid #d2d2d2;
            border-top: 0px;
            min-width: 90.3px;
            padding: 5px 0px;
            border-bottom-color: #999;
        }
        
        #grv_Accessories_Inspection td input[type='text']
        {
            text-align: center;
            font-size: 10px;
            height: 18px;
            margin: 1px 0px;
        }
        #totalAccInspection td
        {
            text-align: center;
            font-size: 12px;
          
            font-weight: bold;
        }
        label
        {
        position: relative;
        top: -2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div>
        <table class="AddClass_Table Top">
            <tr>
                <th>
                    Fabric
                </th>
                <td>
                    <%--<span class="ColorBlue">14x14 Cotton Twill</span><span class="ColorGary"> (325) 14x14/90x78
                        54"</span>--%>
                        <asp:Label ID="lblfab" runat="server" class="ColorBlue"></asp:Label>
                        <asp:HiddenField ID="hdnCutWidth" runat="server" Value="0" />
                </td>
                <th>
                    Supplier Name
                </th>
                <td>
                    <%--<span>Baweja Texfab Pvt. Ltd.</span>--%>
                    <asp:Label id="lblSupplierName" runat="server" ></asp:Label>
                </td>
                <td rowspan="5">
                    <table class="innertable">
                        <tr>
                            <td colspan="2">
                                Length of defect in fabric, either length or width point allotted
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Up to 3 inches
                            </td>
                            <td>
                                1
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Over to 3 inches up to 6 inches
                            </td>
                            <td>
                                2
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Over to 6 inches up to 9 inches
                            </td>
                            <td>
                                3
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Over 9 inches
                            </td>
                            <td>
                                4
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Hole
                            </td>
                            <td>
                                4
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Patta
                            </td>
                            <td>
                                4
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="width: 96px; display: inline-block;">Points per 100<br>
                                    square yards </span><span style="position: relative; top: -6px; right: 10px">=
                                </span><span style="display: inline-block;"><span>Total points scored in the roll x
                                    3600<br>
                                    <div style="border-top: 1px solid #ccc; margin: 1px 0px">
                                        fabric width in inches x total mtrs inspected</div>
                                </span></span>
                            </td>
                            <td style="width: 24px;">
                                4
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Acceptance criteria 40 points per 100 sq. yards
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <th>
                    Color/Print
                </th>
                <td>
                    <%--<span class="ColorBlackBold">4996 brush stroke-4996</span>--%>
                    <asp:Label ID="Label2" runat="server" ForeColor="#000" Font-Bold="true"></asp:Label>
                </td>
                <th>
                    PO Number (SRV No.)
                </th>
                <td>
                    <%--<span class="ColorBlackBold">BTPLF1 (F- 59)</span>--%>
                    <asp:Label ID="lblPONo" runat="server" ForeColor="#000" Font-Bold="true"></asp:Label> &nbsp;
                              (<asp:Label ID="SRVNo" runat="server" ForeColor="#000" Font-Bold="true"></asp:Label>)
                </td>
            </tr>
            <tr>
                <th rowspan="3">
                    Checker Name
                </th>
                <td>
                    <%--<input type="text" value="Srgrg" class="GrdtxtControl">--%>
                    <asp:Label ID="lblPrintColor" runat="server" ForeColor="#000" Font-Bold="true"></asp:Label>
                </td>
                <th>
                    Date
                </th>
                <td>
                   <%-- <input type="text" value="19 Jan 21 (Tue)" style="width: 80px;" class="GrdtxtControl">--%>
                   <asp:TextBox ID="txtdates" CssClass="th datesfileds" onkeypress="return false;" runat="server"
                                    class="formcontrol"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <%--<input type="text" value="" class="GrdtxtControl">--%>
                    <asp:TextBox ID="txtcheckname2" runat="server" class="formcontrol"></asp:TextBox>
                </td>
                <th>
                    Total Quantity
                </th>
                <td>
                    <%--<span>50</span> <span class="ColorGaryBold">Meter</span>--%>
                    <asp:Label id="lblQty" runat="server" ></asp:Label>
                    <asp:Label ID="lblunitname" Font-Bold="true" ForeColor="Gray" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <%--<input type="text" value="" class="GrdtxtControl">--%>
                    <asp:TextBox ID="txtcheckname3" runat="server" class="formcontrol"></asp:TextBox>
                </td>
                <th>
                    Allocated Unit
                </th>
                <td>
                    <%--<select>
                        <option>C 45-46</option>
                        <option>C 47</option>
                        <option>D 69</option>
                        <option>C 52</option>
                    </select>--%>
                    <asp:DropDownList ID="ddlunitname" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        
        <asp:GridView ID="grdfourpointcheck" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found!"
            HeaderStyle-Font-Names="Arial" HeaderStyle-HorizontalAlign="Center" OnRowCancelingEdit="grdfourpointcheck_RowCancelingEdit"
            OnRowCommand="grdfourpointcheck_RowCommand" OnRowDataBound="grdfourpointcheck_RowDataBound"
            OnRowDeleting="grdfourpointcheck_RowDeleting" OnRowEditing="grdfourpointcheck_RowEditing"
            OnRowUpdating="grdfourpointcheck_RowUpdating" ShowFooter="true" ShowHeader="false"
            Width="1100px" Style="border-top: 0px; border-bottom: 0px;">
            <FooterStyle CssClass="FooterRowTd" />
            <EmptyDataRowStyle CssClass="EmptyRowtd" />
            <Columns>
                <asp:TemplateField HeaderText="S.No.">
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle CssClass="Sr_no border_left_color Sr_width" />
                    <FooterStyle CssClass="border_left_color" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnrowid" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                        <asp:HiddenField ID="hdnSRV_item" runat="server" />
                        <asp:HiddenField ID="hdnSupplierPO_item" runat="server" />
                        <asp:Label ID="lblrollno_item" runat="server" Text='<%# (Eval("RollNumber") == DBNull.Value  || (Eval("RollNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("RollNumber").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="roll_no_30" />
                    <FooterTemplate>
                        <asp:HiddenField ID="hdmrowidauto_foter" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                        <asp:HiddenField ID="hdnSRV_Footer" runat="server" />
                        <asp:HiddenField ID="hdnSupplierPO_Footer" runat="server" />
                        <asp:TextBox ID="txtrollno_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            onchange="Calculatetotals(this,'edit');CalculateActualLength(this,'rolls')" CssClass="noonly"
                            MaxLength="5" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtrollno_Footer" runat="server" Display="None"
                            ValidationGroup="gfoter" ControlToValidate="txtrollno_Footer" ErrorMessage="Enter roll No. value"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="hdmrowidauto" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                        <asp:HiddenField ID="hdnSRV_item" runat="server" />
                        <asp:HiddenField ID="hdnSupplierPO_item" runat="server" />
                        <asp:TextBox ID="txtrollno_Edit" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                            runat="server" onkeypress="return isNumberKey(event)" MaxLength="5" onchange="checkzero(this)"
                            Text='<%# (Eval("RollNumber") == DBNull.Value  || (Eval("RollNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("RollNumber").ToString().Trim() %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtrollno_Edit" runat="server" Display="None"
                            ValidationGroup="gedit" ControlToValidate="txtrollno_Edit" ErrorMessage="Enter roll no. value"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbldeilot_item" runat="server" Text='<%# (Eval("DeitLotNumber") == DBNull.Value  || (Eval("DeitLotNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("DeitLotNumber").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="deilot_name" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdeilot_Edit" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                            runat="server" CssClass="noonly" onkeypress="return isNumberKey(event)" MaxLength="5"
                            onchange="checkzero(this)" Text='<%# (Eval("DeitLotNumber") == DBNull.Value  || (Eval("DeitLotNumber").ToString().Trim() == string.Empty)) ? string.Empty : Eval("DeitLotNumber").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtdeilot_Footer" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                            runat="server" CssClass="noonly" onkeypress="return isNumberKey(event)" MaxLength="5"
                            onchange="checkzero(this)"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--new code start 05 Jan 2021--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblclaimedlength_item" runat="server" Text='<%# (Eval("ClaimedQty") == DBNull.Value  || (Eval("ClaimedQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ClaimedQty").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="actlent_name1" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtclaimedlength_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("ClaimedQty") == DBNull.Value  || (Eval("ClaimedQty").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ClaimedQty").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtclaimedlength_Footer" onchange="Calculatetotals(this,'foter')"
                            runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--new code end 05 Jan 2021--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblactlenght_item" runat="server" Text='<%# (Eval("ActualLength") == DBNull.Value  || (Eval("ActualLength").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ActualLength").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="actlent_Len" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtactlenght_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("ActualLength") == DBNull.Value  || (Eval("ActualLength").ToString().Trim() == string.Empty)) ? string.Empty : Eval("ActualLength").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtactlenght_Footer" onchange="Calculatetotals(this,'foter');CalculateActualLength(this,'actualLength')"
                            runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth_S_item" runat="server" Text='<%# (Eval("Width_S") == DBNull.Value  || (Eval("Width_S").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_S").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_StartMeEnd" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtwidth_S_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Width_S") == DBNull.Value  || (Eval("Width_S").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_S").ToString().Trim() %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtdeilot_Edit" runat="server" Display="None"
                            ValidationGroup="gedit" ControlToValidate="txtwidth_S_Edit" ErrorMessage="Enter Width (s)"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtwidth_S_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtdeilot_Footer" runat="server" Display="None"
                            ValidationGroup="gfoter" ControlToValidate="txtwidth_S_Footer" ErrorMessage="Enter Width (s) value"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth_M_item" runat="server" Text='<%# (Eval("Width_M") == DBNull.Value  || (Eval("Width_M").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_M").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_StartMeEnd" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtwidth_M_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Width_M") == DBNull.Value  || (Eval("Width_M").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_M").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtwidth_M_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="checkzero(this);Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth_E_item" runat="server" Text='<%# (Eval("Width_E") == DBNull.Value  || (Eval("Width_E").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_E").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_StartMeEnd" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtwidth_E_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Width_E") == DBNull.Value  || (Eval("Width_E").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Width_E").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtwidth_E_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="checkzero(this);Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth_weaving1_item" runat="server" Text='<%# (Eval("Weaving_1") == DBNull.Value  || (Eval("Weaving_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_1").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtwidth_weaving1_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_1") == DBNull.Value  || (Eval("Weaving_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_1").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtwidth_weaving1_Footer" runat="server" onchange="Calculatetotals(this,'foter')"
                            onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth_weaving2_item" runat="server" Text='<%# (Eval("Weaving_2") == DBNull.Value  || (Eval("Weaving_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_2").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtwidth_weaving2_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_2") == DBNull.Value  || (Eval("Weaving_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_2").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtwidth_weaving2_Footer" onchange="Calculatetotals(this,'foter')"
                            runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth_weaving3_item" runat="server" Text='<%# (Eval("Weaving_3") == DBNull.Value  || (Eval("Weaving_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_3").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtwidth_weaving3_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_3") == DBNull.Value  || (Eval("Weaving_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_3").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtwidth_weaving3_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblwidth_weaving4_item" runat="server" Text='<%# (Eval("Weaving_4") == DBNull.Value  || (Eval("Weaving_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_4").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtwidth_weaving4_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Weaving_4") == DBNull.Value  || (Eval("Weaving_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Weaving_4").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtwidth_weaving4_Footer" onchange="Calculatetotals(this,'foter')"
                            runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbltotal_item" Text='<%# (Eval("total1") == DBNull.Value  || (Eval("total1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total1").ToString().Trim() %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txttotal_Edit" Enabled="false" runat="server" Text='<%# (Eval("total1") == DBNull.Value  || (Eval("total1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total1").ToString().Trim() %>'
                            Style="background: gainsboro;" CssClass="noonly datesfileds" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txttotal_Footer" Style="background: gainsboro;" Enabled="false"
                            runat="server" CssClass="noonly datesfileds" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblpatta_item" runat="server" Text='<%# (Eval("Patta") == DBNull.Value  || (Eval("Patta").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Patta").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpatta_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Patta") == DBNull.Value  || (Eval("Patta").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Patta").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtpatta_Footer" runat="server" onchange="Calculatetotals(this,'foter')"
                            onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblhole_item" runat="server" Text='<%# (Eval("Hole") == DBNull.Value  || (Eval("Hole").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Hole").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txthole_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("Hole") == DBNull.Value  || (Eval("Hole").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Hole").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txthole_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblTotal2_item" Enabled="false" CssClass="datesfileds" Text='<%# (Eval("total2") == DBNull.Value  || (Eval("total2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total2").ToString().Trim() %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTotal2_Edit" Enabled="false" Text='<%# (Eval("total2") == DBNull.Value  || (Eval("total2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total2").ToString().Trim() %>'
                            runat="server" Style="background: gainsboro;" CssClass="noonly datesfileds" MaxLength="3"
                            onkeypress="return false;"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtTotal2_Footer" Enabled="false" Style="background: gainsboro;"
                            runat="server" CssClass="noonly datesfileds" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblprintdyeingdefacts1_item" runat="server" Text='<%# (Eval("PrintedDefectes_1") == DBNull.Value  || (Eval("PrintedDefectes_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_1").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts1_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_1") == DBNull.Value  || (Eval("PrintedDefectes_1").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_1").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts1_Footer" onchange="Calculatetotals(this,'foter')"
                            runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblprintdyeingdefacts2_item" runat="server" Text='<%# (Eval("PrintedDefectes_2") == DBNull.Value  || (Eval("PrintedDefectes_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_2").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts2_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_2") == DBNull.Value  || (Eval("PrintedDefectes_2").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_2").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts2_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblprintdyeingdefacts3_item" runat="server" Text='<%# (Eval("PrintedDefectes_3") == DBNull.Value  || (Eval("PrintedDefectes_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_3").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts3_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_3") == DBNull.Value  || (Eval("PrintedDefectes_3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_3").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts3_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblprintdyeingdefacts4_item" runat="server" onkeypress="checkzero(this)"
                            Text='<%# (Eval("PrintedDefectes_4") == DBNull.Value  || (Eval("PrintedDefectes_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_4").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts4_Edit" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'edit')" Text='<%# (Eval("PrintedDefectes_4") == DBNull.Value  || (Eval("PrintedDefectes_4").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PrintedDefectes_4").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtprintdyeingdefacts4_Footer" runat="server" onkeypress="return isNumberKey(event)"
                            MaxLength="5" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblTotal3_item" Text='<%# (Eval("total3") == DBNull.Value  || (Eval("total3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total3").ToString().Trim() %>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTotal3_Edit" Enabled="false" Text='<%# (Eval("total3") == DBNull.Value  || (Eval("total3").ToString().Trim() == string.Empty)) ? string.Empty : Eval("total3").ToString().Trim() %>'
                            Style="background: gainsboro;" runat="server" CssClass="noonly" MaxLength="3"
                            onkeypress="return false;"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtTotal3_Footer" Style="background: gainsboro;" runat="server"
                            CssClass="noonly datesfileds" Enabled="false" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblpointTotal_item" CssClass="datesfileds" Enabled="false" Text='<%# (Eval("TotalPoints") == DBNull.Value  || (Eval("TotalPoints").ToString().Trim() == string.Empty)) ? string.Empty : Eval("TotalPoints").ToString().Trim() %>'
                            runat="server" ReadOnly="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="widtd_30" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpointTotal_Edit" Enabled="false" Text='<%# (Eval("TotalPoints") == DBNull.Value  || (Eval("TotalPoints").ToString().Trim() == string.Empty)) ? string.Empty : Eval("TotalPoints").ToString().Trim() %>'
                            Style="background: gainsboro;" runat="server" CssClass="noonly" MaxLength="3"
                            onkeypress="return false;"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtpointTotal_Footer" Style="background: gainsboro;" runat="server"
                            CssClass="noonly datesfileds" Enabled="false" MaxLength="3" onkeypress="return false;"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblweapointyard_item" runat="server" Text='<%# (Eval("WeaPointsPerSquirdYards") == DBNull.Value  || (Eval("WeaPointsPerSquirdYards").ToString().Trim() == string.Empty)) ? string.Empty : Eval("WeaPointsPerSquirdYards").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="totalpoint_63" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtweapointyard_Edit" Enabled="false" Style="background: gainsboro;"
                            runat="server" onkeypress="return false;" MaxLength="5" onchange="Calculatetotals(this,'edit')"
                            Text='<%# (Eval("WeaPointsPerSquirdYards") == DBNull.Value  || (Eval("WeaPointsPerSquirdYards").ToString().Trim() == string.Empty)) ? string.Empty : Eval("WeaPointsPerSquirdYards").ToString().Trim() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtweapointyard_Footer" Enabled="false" Style="background: gainsboro;"
                            onkeypress="return false;" runat="server" MaxLength="5" onchange="Calculatetotals(this,'foter')"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblstatus_item" runat="server" Text='<%# (Eval("Statusstring") == DBNull.Value  || (Eval("Statusstring").ToString().Trim() == string.Empty)) ? string.Empty : Eval("Statusstring").ToString().Trim() %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Status_63" />
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlstatus_Edit" runat="server" SelectedValue='<%# Eval("Status") %>'>
                            <asp:ListItem Value="-1">select</asp:ListItem>
                            <asp:ListItem Value="1">pass</asp:ListItem>
                            <asp:ListItem Value="2">fail</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlstatus_Footer" runat="server">
                            <asp:ListItem Value="-1">select</asp:ListItem>
                            <asp:ListItem Value="1">pass</asp:ListItem>
                            <asp:ListItem Value="2">fail</asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" Text="../../images/edit2.png" alt="edit" CommandName="Edit"
                            runat="server"><img src="../../images/edit2.png" alt="edit" /></asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ForeColor="black"
                            OnClientClick="return confirm('Are you sure you want to delete?')" ToolTip="Delete"
                            Width="20px"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="Actiont_63 border_right_color" />
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnupdate" runat="server" ValidationGroup="gedit" CommandName="Update"
                            Text="Update"><img style="width: 11px;height: 12px;" src="../../App_Themes/ikandi/images/green_tick.gif" /></asp:LinkButton>
                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"><img src="../../images/Cancel1.jpg" style="position: relative;top:2px;width:17px" /></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <div style="text-align: center;" class="iSlnkHide">
                            <asp:LinkButton ForeColor="black" ID="abtnAdd" Text="Add" ValidationGroup="gfoter"
                                CssClass="addbnn" CommandName="Insert" runat="server"><img src="../../images/add-butt.png" alt="edit" /> </asp:LinkButton>
                        </div>
                    </FooterTemplate>
                    <FooterStyle CssClass="border_right_color" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table border="1" class="EmptyTable" cellpadding="0" cellspacing="0" width="100%"
                    style="border-top: 0px; border-bottom: 0px; border-color: #999; border-left: 0;
                    border-right: 0;">
                    <tr style="text-align: center;">
                        <td style="min-width: 31px; border-top: 0px; border-bottom: 0px; border-left: 0px"
                            class="border_left_coor">
                        </td>
                        <td style="min-width: 41px; border-top: 0px; border-bottom: 0px">
                            <asp:HiddenField ID="hdmrowidauto_empty" runat="server" Value="<%#Container.DataItemIndex+1 %>" />
                            <asp:TextBox ID="txtrollno_emptyrow" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtrollno_emptyrow" runat="server" Display="None"
                                ValidationGroup="gempty" ControlToValidate="txtrollno_emptyrow" ErrorMessage="Enter roll No. value"></asp:RequiredFieldValidator>
                        </td>
                        <td style="min-width: 41px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtdeilot_emptyrow" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5" onchange="checkzero(this)"></asp:TextBox>
                        </td>
                        <%--new code start--%>
                        <td style="min-width: 50px; border-top: 0px;">
                            <asp:TextBox ID="txtclaimedlength_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                MaxLength="5" onchange="Calculatetotals(this,'empty')"></asp:TextBox>
                        </td>
                        <%--new code end--%>
                        <td style="min-width: 43px; border-top: 0px;">
                            <asp:TextBox ID="txtactlenght_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                MaxLength="5" onchange="Calculatetotals(this,'empty')"></asp:TextBox>
                        </td>
                        <td style="min-width: 45px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtwithd_s_emptyrow" onchange="Calculatetotals(this,'empty')" runat="server"
                                onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_txtdeilot_emptyrow" runat="server" Display="None"
                                ValidationGroup="gempty" ControlToValidate="txtwithd_s_emptyrow" ErrorMessage="Enter width (s) value"></asp:RequiredFieldValidator>
                        </td>
                        <td style="min-width: 44px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtwithd_M_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                MaxLength="5" onchange="checkzero(this)"></asp:TextBox>
                        </td>
                        <td style="min-width: 44px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtwithd_E_emptyrow" runat="server" onkeypress="return isNumberKey(event)"
                                MaxLength="5" onchange="checkzero(this)"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtweaving_1_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtweaving_2_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtweaving_3_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtweaving_4_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txttotal1_emptyrow" Style="background: gainsboro;" runat="server"
                                CssClass="datesfileds" Enabled="false" MaxLength="5" onchange="checkzero(this)"
                                onkeypress="return false;"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtpatta_emptyrow" onchange="Calculatetotals(this,'empty')" runat="server"
                                onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txthole_emptyrow" onchange="Calculatetotals(this,'empty')" runat="server"
                                onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txttotal2_emptyrow" Style="background: gainsboro;" runat="server"
                                CssClass="datesfileds" Enabled="false" MaxLength="5" onchange="checkzero(this)"
                                onkeypress="return false;"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtprintdyeingdefacts1_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtprintdyeingdefacts2_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtprintdyeingdefacts3_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtprintdyeingdefacts4_emptyrow" onchange="Calculatetotals(this,'empty')"
                                runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txttotal3_emptyrow" Style="background: gainsboro;" runat="server"
                                CssClass="datesfileds" Enabled="false" onkeypress="return false;"></asp:TextBox>
                        </td>
                        <td style="min-width: 50px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txttotalpoint_emptyrow" Enabled="false" Style="background: gainsboro;"
                                CssClass="datesfileds" runat="server" onkeypress="return false;"></asp:TextBox>
                        </td>
                        <td style="min-width: 52px; border-top: 0px; border-bottom: 0px">
                            <asp:TextBox ID="txtweapointyard_emptyrow" Style="background: gainsboro;" onkeypress="return false;"
                                MaxLength="5" onchange="checkzero(this)" runat="server"></asp:TextBox>
                        </td>
                        <td style="min-width: 54px; border-top: 0px; border-bottom: 0px">
                            <asp:DropDownList ID="ddlstatus_emptyrow" runat="server">
                                <asp:ListItem Value="-1">select</asp:ListItem>
                                <asp:ListItem Value="1">pass</asp:ListItem>
                                <asp:ListItem Value="2">fail</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="min-width: 58px; border-top: 0px; border-bottom: 0px; border-right: 0px"
                            class="border_right_coor">
                            <asp:LinkButton ID="addbutton" runat="server" CommandName="addnew" CssClass="iSlnkHide addbnn"
                                ValidationGroup="gempty" ForeColor="black" ToolTip="Insert New Record"> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="gempty"
                    ShowMessageBox="True" ShowSummary="False" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="gedit"
                    ShowMessageBox="True" ShowSummary="False" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="gfoter"
                    ShowMessageBox="True" ShowSummary="False" />
            </EmptyDataTemplate>
        </asp:GridView>
        <div style="width: 100%; margin-top: 5px;">
            <div style="width: 61%; float: left">
                <span style="font-size: 13px;">Comments</span>
                <asp:TextBox ID="txtComments" autocomplete="off" runat="server" Height="20px" TextMode="MultiLine"
                    Width="97%"></asp:TextBox>
                <div id="dvHistory" runat="server">
                </div>
                <div class="LavContainer ">
                    <table>
                        <tr>
                            <th style='width: 40px; text-align: center;'>
                                Report
                            </th>
                            <th style='width: 40px; text-align: center;'>
                                Lab Specimen Count
                            </th>
                            <th style="width: 125px; text-align: center;">
                                Sent To Lab (Date & Time)
                            </th>
                            <th style='width: 125px; text-align: center;'>
                                Received in Lab (Date & Time)
                            </th>
                            <th style='width: 50px; text-align: center;'>
                                Lab Report
                            </th>
                            <th style='width: 84px; text-align: center;'>
                                Final Decision<br>
                                (Fabric Dept.)
                            </th>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span>Internal</span>
                            </td>
                            <td class="BalckgroundColor" style="text-align: center;">
                                <asp:TextBox ID="txtInternalLabSpecimanCount" Style="width: 30px; text-align: center"
                                    autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                            </td>
                            <td style='text-align: left;' class="BalckgroundColor">
                                <asp:CheckBox ID="chkInternalSentToLab" Checked="false" runat="server" />
                                <asp:Label ID="lblInternalSentToLabDate" runat="server"></asp:Label>
                            </td>
                            <td style='text-align: left;'>
                                <asp:CheckBox ID="chkInternalReceivedInLab" Checked="false" runat="server" />
                                <asp:Label ID="lblInternalReceivedIndLabDate" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="hylnkInternalLabReportText" onclick="Callfile('internal')" CssClass="hypavgfile"
                                    runat="server" Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;">
                                    <img id="InternalImage" alt="#" src="../../images/uploadimg.png" style="width: 20px;
                                        height: 18px; position: relative; top: 0px;"><asp:Label ID="lblInternalFileName"
                                            runat="server"></asp:Label>
                                </asp:HyperLink>
                                <asp:FileUpload ID="uploadInternalLabReport" runat="server" Style="display: none;" />
                                <asp:HyperLink ID="hylnkInternalLabReport" runat="server" Target="_blank" Style="cursor: pointer;
                                    float: right"> <img src="../../images/view-icon.png" style="width: 16px;height: 16px; position: relative;top:2px;" /> </asp:HyperLink>
                            </td>
                            <td rowspan="2" class="Passfail">
                                <asp:RadioButton ID="rbtFinalDecisionPass" GroupName="decision" Text="Pass" runat="server" />
                                <asp:RadioButton ID="rbtFinalDecisionFail" GroupName="decision" Text="Fail" runat="server" />
                                <asp:Label ID="lblFinalDecisionDate" runat="server" Style="display: none;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span>External</span>
                            </td>
                            <td style="text-align: center;" class="BalckgroundColor">
                                <asp:TextBox ID="txtExternalLabSpecimanCount" Style="width: 30px; text-align: center"
                                    autocomplete="off" runat="server" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                            </td>
                            <td style='text-align: left;' class="BalckgroundColor">
                                <asp:CheckBox ID="chkExternalSentToLab" Checked="false" runat="server" />
                                <asp:Label ID="lblExternalSentToLabDate" runat="server"></asp:Label>
                            </td>
                            <td style='text-align: left;'>
                                <asp:CheckBox ID="chkExternalReceivedInLab" Checked="false" runat="server" />
                                <asp:Label ID="lblExternalReceivedInLabDate" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:HyperLink ID="hylnkExternalLabReportText" onclick="Callfile('external')" CssClass="hypavgfile"
                                    runat="server" Text="" ForeColor="Blue" Target="_blank" Style="cursor: pointer;">
                                    <img alt="#" src="../../images/uploadimg.png" style="width: 20px; height: 18px; position: relative;
                                        top: 0px;"><asp:Label ID="Label1" runat="server"></asp:Label>
                                </asp:HyperLink>
                                <asp:FileUpload ID="uploadExternalLabReport" runat="server" Style="display: none;" />
                                <asp:HyperLink ID="hylnkExternalLabReport" runat="server" Target="_blank" Style="cursor: pointer;
                                    float: right"> <img src="../../images/view-icon.png"  style="width: 16px;height: 17px; position: relative;top:2px;" /> </asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="QACheckbox">
                    <span style="text-align: right;">
                        <asp:CheckBox ID="chkLabManager" Checked="false" runat="server" />
                        <label for="vehicle1">
                            (Lab Manager)</label>
                    </span>
                </div>
                <div class="QACheckbox">
                    <span style="text-align: right;">
                        <asp:CheckBox ID="chkAccessoriesQA" Checked="false" runat="server" />
                        <label for="vehicle1">
                            (Accessories QA)</label>
                    </span>
                </div>
            </div>
            <div class="RightSide" style="width: 36.7%; float: left;">
                <table>
                    <tr id="FailedQtyId" runat="server">
                        <td style="text-align: center; width: 100px;">
                            <span style="color: #6b6464">Fail Qty.</span>
                            <asp:Label ID="lblTotalFailQty" runat="server"></asp:Label>
                        </td>
                        <td style='text-align: left;'>
                            <span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span>
                                <asp:TextBox ID="txtFailedRaisedDebit" autocomplete="off" runat="server" CssClass="txtRaise"
                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox></span> <span class="DisplayBlock">
                                        <span class="DisInlineBlock">Fail Stock</span>
                                        <asp:TextBox ID="txtFailedStock" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                    </span><span class="DisplayBlock"><span class="DisInlineBlock">Good Stock</span>
                                        <asp:TextBox ID="txtFailedGoodStock" autocomplete="off" runat="server" CssClass="txtRaise"
                                            onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                    </span>
                            <asp:TextBox ID="txtFailedParticular" Rows="3" autocomplete="off" runat="server"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="ExtraQtyId" runat="server">
                        <td style="text-align: center; width: 100px;">
                            <span style="color: #6b6464">Extra Qty.</span>
                            <asp:Label ID="lblInspectExtraQty" runat="server"></asp:Label>
                        </td>
                        <td style='text-align: left;'>
                            <span class="DisplayBlock"><span class="DisInlineBlock">Raise Debit</span>
                                <asp:TextBox ID="txtInspectRaisedDebit" CssClass="txtRaise" autocomplete="off" runat="server"
                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                            </span><span class="DisplayBlock"><span class="DisInlineBlock">Usable Stock</span>
                                <asp:TextBox ID="txtInspectUsableStock" CssClass="txtRaise" autocomplete="off" runat="server"
                                    onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                            </span>
                        </td>
                        <td style='text-align: left;'>
                            <asp:TextBox ID="txtInspectParticular" autocomplete="off" Rows="3" Columns="20" runat="server"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="GMCheckbox">
                    <span style="text-align: right;">
                        <asp:CheckBox ID="chkAccessoriesGM" Checked="false" runat="server" />
                        <label for="AccessoriesGM" style="color: #000">
                            (Accessories GM)</label>
                    </span>
                </div>
            </div>
        </div>
        <div style="text-align: center; padding-top: 40px; clear: both;">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btnSubmit printHideButton" Text="Submit"
                OnClick="btnSubmit_Click" OnClientClick="javascript:return validateRecivedQty();" />
            <input type="button" class="btnSubmit printHideButton" value="Close" onclick="javascript:self.parent.Shadowbox.close();" />
            <asp:Button ID="btnPrint" runat="server" CssClass="btnPrint btnBackColor printHideButton"
                Text="Print" OnClientClick="window.print()" />
        </div>
    </div>
    </form>
</body>
</html>
