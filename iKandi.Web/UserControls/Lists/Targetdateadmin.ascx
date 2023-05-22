﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Targetdateadmin.ascx.cs"
    Inherits="iKandi.Web.UserControls.Lists.Targetdateadmin" %>

<script type="text/javascript">
    function test() {
        alert('wait');
        return true;
    
    }
</script>


<div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10" class="da_table_heading_bg_left">&nbsp;</td>
        <td width="1205" class="da_table_heading_bg"><span class="da_h1">Target Date Admin</span></td>
        <td width="13" class="da_table_heading_bg_right">&nbsp;</td>
      </tr>
    </table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<center>

    <asp:GridView ID="gv_trgadmin" runat="server" AutoGenerateColumns="False" CssClass="da_header_heading"
        OnRowDataBound="gv_trgadmin_RowDataBound" Width="100%">
        <Columns>
        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="da_table_tr_bg">
            <ItemTemplate >
                <div  style="text-align:left">
                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("status_modename") %>' ></asp:Label></div>
                 <asp:HiddenField ID="hdnStatusId" runat="server" Value='<%#Eval("status_modeid") %>' />
                 <asp:HiddenField ID="hdnSequence" runat="server" Value='<%#Eval("Sequence") %>' />
                 <asp:HiddenField ID="hdnCalMode" runat="server" Value='<%#Eval("calender_mode") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
            <asp:BoundField DataField="Type" HeaderText="Type" Visible="false">
                <ItemStyle Font-Size="12px" ForeColor="Blue" Wrap="True" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="From" HeaderStyle-Width="250px">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("id") %>' />
                    <asp:HiddenField ID="hdnval" runat="server" Value='<%#Eval("from_date") %>' />
                    <asp:DropDownList ID="ddlfrom" runat="server" DataTextField="mode" 
                        DataValueField="id" AutoPostBack="True" 
                        onselectedindexchanged="ddlfrom_SelectedIndexChanged" CssClass="input_in">
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle Width="250px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Days">
                <ItemTemplate>
                    <%--<input id="txtdays<%# Container.DataItemIndex + 1 %>" name="txtdays<%# Container.DataItemIndex + 1 %>"
                        type="text" value='<%# Eval("Days") %>' class="numeric-field-without-decimal-places-negative" onchange="simulation(this)" maxlength="3" class="txt" />                         --%>
                    <asp:TextBox ID="txtdays" runat="server" Text='<%# Eval("Days") %>' 
                        AutoPostBack="True" CssClass="input_in" ontextchanged="txtdays_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Mode">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlmode" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlmode_SelectedIndexChanged" CssClass="input_in">
                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Calender"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Bipl"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Ikandi"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Simulation As Per Today" >
                <ItemTemplate>
                    <asp:TextBox ID="lblSimDate" CssClass="input_in" runat="server" ReadOnly="true"></asp:TextBox> 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </center>
    <br />
    <span class="da_note_text"><b>Note:</b><span class="da_astrx_mand">*</span> Clicking on "Update Active" button will change the target dates of all active orders(i.e upto Delivered) whereas "Update All" will change the Target Dates of all orders (including Invoiced).
    <br />For simulation purpose<br />
    EX-FACTORY TARGET WILL BE ORDERDATE + 90 DAYS &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; DC TARGET DATE WILL BE EX-FACTORY + 17 DAYS
    <br />
    <br /> </span>      
    
     <asp:Button ID="save" runat="server" Text="Save"  OnClick="save_Click" CssClass="da_save_update_active" /> &nbsp;&nbsp;
     <asp:Button ID="Button1" runat="server" Text="Update Active" OnClick="update_Click" CssClass="da_save_update_active"/> &nbsp;&nbsp;
     <asp:Button ID="saveAll" runat="server" Text="Update All" OnClick="updateAll_Click" CssClass="da_save_update_active"/>
    
     
</ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="save" />
    <asp:PostBackTrigger ControlID="Button1" />
    <asp:PostBackTrigger ControlID="saveAll" />
    </Triggers>
</asp:UpdatePanel>





</div> 


