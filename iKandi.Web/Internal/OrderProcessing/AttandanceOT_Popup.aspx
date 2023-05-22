<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttandanceOT_Popup.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.AttandanceOT_Popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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

 <script type="text/javascript" language="javascript">
     function ValidateEmptyField_Submit(ctrl, type) {
         //debugger;
         var IdsArr = ctrl.id.split("_");
         var Ids = IdsArr[1];

         var TotalCount = $(".TotalCount").val();
         var OTDefault = $(".OTDefault").val();

         if (type == 'Empty') {
             var Mancount = $(".EmptyManCount").val();

             if ((Mancount == '') || (Mancount == 0)) {
                 $(".EmptyManCount").val('');
                 alert('Please fill Mancount');
                 return false;
             }
             else if (parseInt(Mancount) > parseInt(TotalCount))
             {
                 alert('This value can not greater than TotalCount');
                 $(".EmptyManCount").val('');
                 return false;
             }
             var Hours = $(".EmptyHours").val();
             if ((Hours == '') || (Hours == 0)) {
                 alert('Please fill Hours');
                 $(".EmptyHours").val('');
                 return false;
             }
             else if (parseFloat(Hours) > parseFloat(OTDefault)) {
                 alert('This value can not greater than OT Default');
                 $(".EmptyHours").val('');
                 return false;
             }
         }
         if (type == 'Item') {

             var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val();

             if ((Mancount == '') || (Mancount == 0)) {
                 alert('Please fill Mancount');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val('');
                 return false;
             }
             else if (parseInt(Mancount) > parseInt(TotalCount)) {
                 alert('This value can not greater than TotalCount');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val('');
                 return false;
             }
             var Hours = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtHours']").val();

             if ((Hours == '') || (Hours == 0)) {
                 alert('Please fill Hours');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtHours']").val('');
                 return false;
             }
             else if (parseFloat(Hours) > parseFloat(OTDefault)) {
                 alert('This value can not greater than OT Default');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtHours']").val('');
                 return false;
             }
             var gvAttandanceRow = $(".gvAttandanceRow").length;
             var TotalManCount = 0;
             var gvId = 0;
             for (var row = 1; row <= gvAttandanceRow; row++) {
                 gvId = parseInt(row) + 1;
                 var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + gvId + "_txtManCount']").val();
                 TotalManCount = parseInt(TotalManCount) + parseInt(Mancount);
             }            

             if (parseInt(TotalManCount) > parseInt(TotalCount)) {
                 alert('Invalid');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val('');
                 return false;
             }

         }
         if (type == 'Footer') {
             //debugger;
             var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val();
             if ((Mancount == '') || (Mancount == 0)) {
                 alert('Please fill Mancount');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val('');
                 return false;
             }
             else if (parseInt(Mancount) > parseInt(TotalCount)) {
                 alert('This value can not greater than TotalCount');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val('');
                 return false;
             }
             var Hours = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterHours']").val();
             if ((Hours == '') || (Hours == 0)) {
                 alert('Please fill Hours');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterHours']").val('');
                 return false;
             }
             else if (parseFloat(Hours) > parseFloat(OTDefault)) {
                 alert('This value can not greater than OT Default');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterHours']").val('');
                 return false;
             }
             var gvAttandanceRow = $(".gvAttandanceRow").length;
             var TotalManCount = 0;
             var gvId = 0;
             for (var row = 1; row <= gvAttandanceRow; row++) {
                 gvId = parseInt(row) + 1;
                 var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + gvId + "_txtManCount']").val();
                 TotalManCount = parseInt(TotalManCount) + parseInt(Mancount);
             }
             var FooterManCount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val();
             TotalManCount = parseInt(TotalManCount) + parseInt(FooterManCount);

             if (parseInt(TotalManCount) > parseInt(TotalCount)) {
                 alert('Invalid');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val('');
                 return false;
             }
         }

     }

     function ValidateEmptyField(ctrl, type, flag) {
         //debugger;
         var IdsArr = ctrl.id.split("_");
         var Ids = IdsArr[1];

         var TotalCount = $(".TotalCount").val();
         var OTDefault = $(".OTDefault").val();

         if (type == 'Empty') {
             if (flag == 'Count') {
                 var Mancount = $(".EmptyManCount").val();

                 if ((Mancount == '') || (Mancount == 0)) {
                     alert('Please fill Mancount');
                     $(".EmptyManCount").val('');
                     return false;
                 }
                 else if (parseInt(Mancount) > parseInt(TotalCount)) {
                     alert('This value can not greater than TotalCount');
                     $(".EmptyManCount").val('');
                     return false;
                 }
             }
             if (flag == 'Hours') {
                 var Hours = $(".EmptyHours").val();
                 if ((Hours == '') || (Hours == 0)) {
                     alert('Please fill Hours');
                     $(".EmptyHours").val('');
                     return false;
                 }
                 else if (parseFloat(Hours) > parseFloat(OTDefault)) {
                     alert('This value can not greater than OT Default');
                     $(".EmptyHours").val('');
                     return false;
                 }
             }
         }
         if (type == 'Item') {
             if (flag == 'Count') {
                 var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val();

                 if ((Mancount == '') || (Mancount == 0)) {
                     alert('Please fill Mancount');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val('');
                     return false;
                 }
                 else if (parseInt(Mancount) > parseInt(TotalCount)) {
                     alert('This value can not greater than TotalCount');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val('');
                     return false;
                 }
             }
             if (flag == 'Hours') {
                 var Hours = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtHours']").val();

                 if ((Hours == '') || (Hours == 0)) {
                     alert('Please fill Hours');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtHours']").val('');
                     return false;
                 }
                 else if (parseFloat(Hours) > parseFloat(OTDefault)) {
                     alert('This value can not greater than OT Default');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtHours']").val('');
                     return false;
                 }
             }
             var gvAttandanceRow = $(".gvAttandanceRow").length;
             var TotalManCount = 0;
             var gvId = 0;
             for (var row = 1; row <= gvAttandanceRow; row++) {
                 gvId = parseInt(row) + 1;
                 var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + gvId + "_txtManCount']").val();
                 TotalManCount = parseInt(TotalManCount) + parseInt(Mancount);
             }

             if (parseInt(TotalManCount) > parseInt(TotalCount)) {
                 alert('Invalid');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtManCount']").val('');
                 return false;
             }

         }
         if (type == 'Footer') {
             //debugger;
             if (flag == 'Count') {
                 var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val();
                 if ((Mancount == '') || (Mancount == 0)) {
                     alert('Please fill Mancount');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val('');
                     return false;
                 }
                 else if (parseInt(Mancount) > parseInt(TotalCount)) {
                     alert('This value can not greater than TotalCount');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val('');
                     return false;
                 }
             }
             if (flag == 'Hours') {
                 var Hours = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterHours']").val();
                 if ((Hours == '') || (Hours == 0)) {
                     alert('Please fill Hours');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterHours']").val('');
                     return false;
                 }
                 else if (parseFloat(Hours) > parseFloat(OTDefault)) {
                     alert('This value can not greater than OT Default');
                     $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterHours']").val('');
                     return false;
                 }
             }
             var gvAttandanceRow = $(".gvAttandanceRow").length;
             var TotalManCount = 0;
             var gvId = 0;
             for (var row = 1; row <= gvAttandanceRow; row++) {
                 gvId = parseInt(row) + 1;
                 var Mancount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + gvId + "_txtManCount']").val();
                 TotalManCount = parseInt(TotalManCount) + parseInt(Mancount);
             }
             var FooterManCount = $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val();
             TotalManCount = parseInt(TotalManCount) + parseInt(FooterManCount);

             if (parseInt(TotalManCount) > parseInt(TotalCount)) {
                 alert('Invalid');
                 $("#<%= gvAttandanceOT.ClientID %> input[id$='" + Ids + "_txtFooterManCount']").val('');
                 return false;
             }
         }

     }
     

     function ClosethisWindow() {
         //debugger;
         window.close();
         window.opener.CallManCount_Values();
     }

    </script>
    <style type="text/css">
    .pop-tab th
    {
        background:#395897;
        color:#fff;
        font-size:12px;
        
    }
    .pop-tab td
    {
        
        text-align:center;
    }
    .pop-tab td input
    {
        text-align:center;
        width:70%;   
        
    }
    b
    {
        color:#395897;
        font-family:Arial;
        font-size:12px;
    }
    span
    {
        font-size:12px;
        font-family:Verdana;
    }
    .submit_butt
    {
        background:#f2f2f2;
        border:1px solid #000;
        padding:2px ;
        font-weight:bold;
        cursor:pointer;margin-top:6px;        
    }
    .submit_butt:hover
    {
        background:pink;
    }
 
   
    
    </style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
    <div style="border:1px solid #666;padding:5px;width:330px;">
    <table width="330px" cellpadding="0" cellspacing="0" align="center">
    <tr><td colspan="3">
        <asp:HiddenField ID="hdnProductionUnit" runat="server" />
        <asp:HiddenField ID="hdnWorkforceId" runat="server" />
        <asp:HiddenField ID="hdnOTType" runat="server" />
        <asp:HiddenField ID="hdnAttandenceDate" runat="server" />
    <b>Designation : </b>
        <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label>  &nbsp; 
    </td>
    </tr>
    <tr>
    <td colspan="3"> &nbsp;</td>
    
    </tr>
    <tr>
    <td>
    <b>OT Type : </b> 
        <asp:Label ID="lblOTtype" runat="server" Text=""></asp:Label> &nbsp; &nbsp; 
    </td>
    <td>
    <b>Total Count : </b> 
         <asp:TextBox Width="30" ID="txtTotalCount" ReadOnly="true" CssClass="TotalCount" runat="server" style="border:1px solid #fff;"></asp:TextBox> 
    </td>
     <td>
    <b>OT Default : </b> 
        <asp:TextBox Width="30" ID="txtOTDefault" ReadOnly="true" CssClass="OTDefault" runat="server" style="border:1px solid #fff;"></asp:TextBox>
    </td>
    
    
    </tr>
    <tr>
    <td colspan="3"> &nbsp;</td>
    
    </tr>

    </table>
    <table width="300px" cellpadding="0" cellspacing="0" class="pop-tab" align="left" border="0">
    <tr><td>
        <asp:GridView ID="gvAttandanceOT" Width="100%" ShowFooter="true" RowStyle-Width="100"  
            AutoGenerateColumns="false" runat="server" 
            onrowcommand="gvAttandanceOT_RowCommand">
            <RowStyle CssClass="gvAttandanceRow" />
        <Columns>
        <asp:TemplateField  HeaderText="Count">
        <ItemTemplate>
            <asp:HiddenField ID="hdnAttandanceOTId" Value='<%#Eval("AttandanceOTId") %>' runat="server" />
            <asp:TextBox ID="txtManCount" onchange="javascript:return ValidateEmptyField(this,'Item','Count')" MaxLength="3" CssClass="numeric-field-without-decimal-places" Text='<%#Eval("OT_Count") %>' runat="server"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtFooterManCount" onchange="javascript:return ValidateEmptyField(this,'Footer','Count')" MaxLength="3" CssClass="numeric-field-without-decimal-places" runat="server"></asp:TextBox>
        </FooterTemplate>        
        </asp:TemplateField>  

         <asp:TemplateField HeaderText="Hours">
        <ItemTemplate>
            <asp:TextBox ID="txtHours" MaxLength="4" onchange="javascript:return ValidateEmptyField(this,'Item','Hours')" CssClass="numeric-field-with-two-decimal-places" Text='<%#Eval("OT_Hours") %>' runat="server"></asp:TextBox>
        </ItemTemplate>
        <FooterTemplate>
            <asp:TextBox ID="txtFooterHours" onchange="javascript:return ValidateEmptyField(this,'Footer','Hours')" MaxLength="4" CssClass="numeric-field-with-two-decimal-places" runat="server"></asp:TextBox>
        </FooterTemplate>        
        </asp:TemplateField> 
         <asp:TemplateField ItemStyle-Width="50">
            <ItemTemplate>
                <asp:LinkButton ID="lnkRemove" CausesValidation="false" OnClientClick="javascript:return ValidateEmptyField_Submit(this,'Item')"
                    CssClass="LinkButton" CommandName="Remove" runat="server">Del</asp:LinkButton>
            </ItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lnkAdd" CausesValidation="false" OnClientClick="javascript:return ValidateEmptyField_Submit(this,'Footer')"
                    CssClass="LinkButton" CommandName="Add" runat="server">Add</asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>      
        </Columns>
        <EmptyDataTemplate>
        <table width="300px" cellpadding="0" cellspacing="0" border="1" class="pop-tab" style="padding:0px;">
        <tr><th>Count</th><th>Hours</th> <th>&nbsp;</th></tr>
        <tr><td>
            <asp:TextBox ID="txtEmptyManCount" onchange="javascript:return ValidateEmptyField(this,'Empty','Count')" MaxLength="3" CssClass="EmptyManCount numeric-field-without-decimal-places" runat="server"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtEmptyHours" onchange="javascript:return ValidateEmptyField(this,'Empty','Hours')" MaxLength="4" CssClass="EmptyHours numeric-field-with-two-decimal-places" runat="server"></asp:TextBox></td>
                 <td>
                    <asp:LinkButton ID="lnkAddEmpty" CssClass="LinkButton " CausesValidation="false" OnClientClick="javascript:return ValidateEmptyField_Submit(this,'Empty')"
                        CommandName="Add_Empty" runat="server">Add</asp:LinkButton>
                </td>
                </tr>
        </table>
        </EmptyDataTemplate>
        </asp:GridView>
    </td></tr>
    
    </table>
     <div style="clear:both;"></div>
    <table width="300px" cellpadding="0" cellspacing="0">
    
    <tr>
    <td align="right">
        <asp:Button ID="btnSubmit" runat="server" CssClass="submit_butt" Text="SUBMIT" 
            onclick="btnSubmit_Click" /></td></tr>
    
    </table>
    <div style="clear:both;"></div>
    </div>
    </form>
</body>
</html>
