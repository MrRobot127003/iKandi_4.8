<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanCalenderForm.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.ProductionPlanCalenderForm" %>
<style type="text/css">
    .calender
    {
        font-family: verdana;
        width: 770px;
    }
    thead th
    {
        background: #39589C;
        color: #fff;
        font-weight: normal;
        font-size: 11px;
        padding: 5px 0px;
        width: 90px;
        border-color:#999;
    }
    .calender tbody td
    {
        font-size: 11px;
        color: gray;
        vertical-align: middle;
        width: 108px;
        height: 30px;
        text-align: center;
          border-color:#999;
    }
    .leave_back tr td:first-child
    {
        background: #cbcbcb;
        color: black;
        font-weight: bold;
    }
    .hidden { display: none; }
    .leave_back_holy
    {
        background: #cbcbcb;
        color: black;
        font-weight: bold;
    }
    SELECT {
    font-size: 11px;
    text-transform: capitalize !important;
}
</style>
<link href="../../css/CSS.css" rel="stylesheet" type="text/css" />
<link href="../../App_Themes/ikandi/ikandi.css" rel="stylesheet" type="text/css" />
<script src="../../bipl/js/ie6/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="../../CommonJquery/JqueryLibrary/form.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">

    function validate(obj) {
        //alert(obj.value);
        //This will check if the number is valid (it replaces / ignores the commas)
        //        alert(!isNaN(obj.value.replace('.', '')));
        var x = obj.value;
        //alert(!isNaN(x));
        if (!isNaN(x) == false) {
            alert('Only numeric value allowed');
            document.getElementById("<%= txtWorkingDays.ClientID %>").value = '';
           
            
            return false;

        }
        else {
            //            $('#btnWorkingDays').click();
            document.getElementById("<%= btnWorkingDays.ClientID %>").click();
        }
//        alert(!isNaN('45.6'));
//        alert(!isNaN('as.6'));
    }
//    function CallTextChange() {
//        __doPostBack("txtWorkingDays", "txtWorkingDays_Onchanged");
    //    }
   //Prevent enter F5
    window.onload = function () {
        document.onkeydown = function (e) {
            return (e.which || e.keyCode) != 116;
        };
    }


    
</script>

    <table cellpadding="0" cellspacing="0" border="1" align="center" style="border-collapse: collapse;"
        class="calender">
        
        <thead>
            <tr>
                <th colspan="7" align="left">
                  <div style="float:left; width:35%">  &nbsp;
                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                        <asp:ListItem Text="January" Value="1"></asp:ListItem>
                        <asp:ListItem Text="February" Value="2"></asp:ListItem>
                        <asp:ListItem Text="March" Value="3"></asp:ListItem>
                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                        <asp:ListItem Text="May" Value="5"></asp:ListItem>
                        <asp:ListItem Text="June" Value="6"></asp:ListItem>
                        <asp:ListItem Text="July" Value="7"></asp:ListItem>
                        <asp:ListItem Text="August" Value="8"></asp:ListItem>
                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                        <asp:ListItem Text="October" Value="10"></asp:ListItem>
                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                        <asp:ListItem Text="December" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" onselectedindexchanged="ddlyear_SelectedIndexChanged">
                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                          <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                          <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                          <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                          <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                           <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                           <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                           <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                           <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                    </asp:DropDownList>
                      

                    </div>
                  <div style="float:left; width:43%; text-align:center;"> <strong >Production Calendar</strong>   </div>
                  <div style="float:right; width:22%; text-align:center;">
                  Default Working Hrs
                    <asp:textbox ID="txtWorkingDays" onblur="validate(this)" AutoPostBack="true" MaxLength="5"
                          runat="server"  Width="30px" ></asp:textbox>
                         <asp:Button ID ="btnWorkingDays" runat="server" 
                          onclick="btnWorkingDays_Click"  CssClass="hidden"/>
                  </div>
                  <div style="clear:both;"></div>
                </th>
            </tr>
            <tr>
                <th>
                    Sun
                </th>
                <th>
                    Mon
                </th>
                <th>
                    Tue
                </th>
                <th>
                    Wed
                </th>
                <th>
                    Thu
                </th>
                <th>
                    Fri
                </th>
                <th>
                    Sat
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td colspan="7">
                    <asp:GridView ID="grdproductionCalender" AutoGenerateColumns="false" runat="server"
                        OnRowDataBound="grdproductionCalender_RowDataBound" CssClass="leave_back" OnRowCommand="grdproductionCalender_RowCommand"
                        ShowHeader="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="hylnksunday" style="cursor:grab" runat="server" Font-Bold="true" Text='<%#Eval("Sunday")%>'></asp:HyperLink>
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("CalenderID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hylnkMonday" Target="_blank" runat="server" commandname="OpenPopUp" Text='<%#Eval("Monday")%>'></asp:HyperLink>--%>
                                    <asp:LinkButton ID="lnkpopupMonday" style="cursor:grab" runat="server" CommandName="OpenPopUpMonday"
                                        Text='<%#Eval("Monday")%>'></asp:LinkButton>
                                    <asp:Label ID="lblworkinghoursMonday" runat="server" Text='<%#Eval("WorkingHousr")%>'
                                        Visible="false" Style="float: right;"></asp:Label>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Label ID="lbleventMonday" runat="server" Text='<%#Eval("EventDiscription")%>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hdnIdMonday" runat="server" Value='<%#Eval("CalenderID")%>' />
                                    <asp:HiddenField ID="hdnIseventMonday" runat="server" Value='<%#Eval("IsEvent")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hylnktuesday" runat="server" commandname="OpenPopUp" Text='<%#Eval("Tuesday")%>'></asp:HyperLink>--%>
                                    <asp:LinkButton ID="lnkpopuptuesday" style="cursor:grab" runat="server" CommandName="OpenPopUptuesday"
                                        Text='<%#Eval("Tuesday")%>'></asp:LinkButton>
                                    <asp:Label ID="lblworkinghourstuesday" runat="server" Text='<%#Eval("WorkingHousr")%>'
                                        Visible="false" Style="float: right;"></asp:Label>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Label ID="lbleventtuesday" runat="server" commandname="OpenPopUp" Text='<%#Eval("EventDiscription")%>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hdnIdtuesday" runat="server" Value='<%#Eval("CalenderID")%>' />
                                     <asp:HiddenField ID="hdnIseventtuesday" runat="server" Value='<%#Eval("IsEvent")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hylnkwednesday" Target="_blank" commandname="OpenPopUp" runat="server" Text='<%#Eval("Wednesday")%>'></asp:HyperLink>--%>
                                    <asp:LinkButton ID="lnkpopupwednesday" style="cursor:grab" runat="server" CommandName="OpenPopUpwednesday"
                                        Text='<%#Eval("Wednesday")%>'></asp:LinkButton>
                                    <asp:Label ID="lblworkinghourkwednesdays" runat="server" Text='<%#Eval("WorkingHousr")%>'
                                        Visible="false" Style="float: right;"></asp:Label>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Label ID="lbleventkwednesday" runat="server" Text='<%#Eval("EventDiscription")%>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hdnIdkwednesday" runat="server" Value='<%#Eval("CalenderID")%>' />
                                     <asp:HiddenField ID="hdnIseventwednes" runat="server" Value='<%#Eval("IsEvent")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hylnkthursday" runat="server" commandname="OpenPopUp" Text='<%#Eval("Thursday")%>'></asp:HyperLink>--%>
                                    <asp:LinkButton ID="lnkpopupthursday" style="cursor:grab" runat="server" CommandName="OpenPopUpthursday"
                                        Text='<%#Eval("Thursday")%>'></asp:LinkButton>
                                    <asp:Label ID="lblworkinghoursthursday" runat="server" Text='<%#Eval("WorkingHousr")%>'
                                        Visible="false" Style="float: right;"></asp:Label>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Label ID="lbleventthursday" runat="server" Text='<%#Eval("EventDiscription")%>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hdnIdthursday" runat="server" Value='<%#Eval("CalenderID")%>' />
                                     <asp:HiddenField ID="hdnIseventthursday" runat="server" Value='<%#Eval("IsEvent")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hylnkfriday" runat="server" commandname="OpenPopUp" Text='<%#Eval("Friday")%>'></asp:HyperLink>--%>
                                    <asp:LinkButton ID="lnkpopupfriday" style="cursor:grab" runat="server" CommandName="OpenPopUpfriday"
                                        Text='<%#Eval("Friday")%>'></asp:LinkButton>
                                    <asp:Label ID="lblworkinghoursfriday" runat="server" Text='<%#Eval("WorkingHousr")%>'
                                        Visible="false" Style="float: right;"></asp:Label>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Label ID="lbleventfriday" runat="server" commandname="OpenPopUp" Text='<%#Eval("EventDiscription")%>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hdnIdfriday" runat="server" Value='<%#Eval("CalenderID")%>' />
                                     <asp:HiddenField ID="hdnIseventfriday" runat="server" Value='<%#Eval("IsEvent")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hylnkseturday" runat="server" commandname="OpenPopUp" Text='<%#Eval("Seterday")%>'></asp:HyperLink>--%>
                                    <asp:LinkButton ID="lnkpopupseturday" style="cursor:grab" runat="server" CommandName="OpenPopUpseturday"
                                        Text='<%#Eval("Seterday")%>'></asp:LinkButton>
                                    <asp:Label ID="lblworkinghoursseturday" runat="server" Text='<%#Eval("WorkingHousr")%>'
                                        Visible="false" Style="float: right;"></asp:Label>
                                    <div style="clear: both">
                                    </div>
                                    <asp:Label ID="lbleventseturday" runat="server" Text='<%#Eval("EventDiscription")%>'
                                        Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hdnIdseturday" runat="server" Value='<%#Eval("CalenderID")%>' />
                                     <asp:HiddenField ID="hdnIseventsat" runat="server" Value='<%#Eval("IsEvent")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <div id="DivSetevent" runat="server" visible="false" style="width: 370px; margin: 0px auto;
        border: 1px solid gray; padding: 10px; font-family: Verdana; font-size: 12px;
        line-height: 30px;">
        <table style="width: 100%" cellpadding="0" cellspacing="0" align="center">
            <tr>
                <td>
                    <asp:Label ID="lbldate" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdncalederid" runat="server" Value="0" />
                    <asp:HiddenField ID="hdndayno" runat="server" Value="0" />
                </td>
            </tr>
            <tr>
                <td>
                    Enable Event:
                </td>
                <td>
                    <asp:CheckBox ID="chkenableEvent" runat="server"  ToolTip="Enable event"
                         />
                </td>
            </tr>
            <tr>
                <td>
                    Working Hours:
                </td>
                <td>
                    <asp:TextBox ID="txtworkinghours" CssClass="allownumericwithdecimal" MaxLength="2"
                        AutoCompleteType="None" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td>
                    Event Discription:
                </td>
                <td>
                    <asp:TextBox ID="txtdiscription"  ToolTip="Enter event name" MaxLength="40" AutoCompleteType="None"
                         TextMode="MultiLine"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnsubmit" runat="server" text="Submit" CssClass="submit" OnClick="btnsubmit_Click" />
                    <asp:Button ID="btnclose" runat="server" text="Close" CssClass="da_submit_button" OnClick="btnclose_Click" />
                </td>
            </tr>
        </table>
    </div>
  
