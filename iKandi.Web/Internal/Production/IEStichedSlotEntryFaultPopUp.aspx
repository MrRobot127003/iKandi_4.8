<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IEStichedSlotEntryFaultPopUp.aspx.cs" Inherits="iKandi.Web.Internal.Production.IEStichedSlotEntryFaultPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link rel="Stylesheet" href="../../App_Themes/ikandi/ikandi.css" />
<link rel="Stylesheet" href="../../App_Themes/ikandi/ikandi1.css" />
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
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
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
        //debugger;
        $("input.NatureOfFaults").autocomplete("/Webservices/iKandiService.asmx/SuggestNatureOfFaults", { dataType: "xml", datakey: "string", max: 100, "width": "220px" });

        $("input.NatureOfFaults", "#main_content").result(function () {

        });

    });
     

    
    function CloseWindowa(flag, ID) {
        //debugger;       
        window.parent.Uncheckbox(flag, ID);
        window.parent.Shadowbox.close();

        return false;
    }

   
</script>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.border2 th {
    font-size: 11px !important;
    padding: 5px 0 !important;
}
.TextField
{
    text-align:center !important;
}
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

   
   <table border="0" style="width:600px; text-align:center;" class="border2" cellpadding="0" cellspacing="0">
   <tr>
   <th width="492px">
   <b style="font-size:14px;">Stitching Alt Sum Fault Entry</b>
   </th>
   <th>
    <b>
    <asp:Label ID="entredsum" ToolTip="Entered qty sum" runat="server">
    </asp:Label></b>
   
   <asp:Label ID="lblaltPcSum" runat="server" style="float:right; padding-right:10px;"></asp:Label> 
   <asp:HiddenField ID="hdnControlId"  Value="0" runat="server" />
       <asp:HiddenField ID="hdnIsDHU" Value="0" runat="server" />
   </th>
   </tr>
   </table>
    
    
  
     <asp:GridView ID="grdQafault"  runat="server" AutoGenerateColumns="False" 
        ShowHeader="true" Width="600px" ShowFooter="True" OnRowDeleting="grdQafault_RowDeleting"
         HeaderStyle-HorizontalAlign="Center" OnRowCommand="grdQafault_RowCommand"
        OnRowDataBound="grdQafault_RowDataBound" BorderWidth="1" rules="all"  CssClass="border2" >
         <RowStyle CssClass="grdQafaultRow" />
        <Columns>
            <asp:TemplateField HeaderText="Nature of fault">
                <ItemTemplate>
                    <asp:TextBox ID="txtFaultname"   style="width:98%;" CssClass="NatureOfFaults" ToolTip="Nature of fault"
                        Text='<%#Eval("FaultName")%>' runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnfaultid" runat="server" Value='<%#Eval("id")%>' />
                    <asp:HiddenField ID="hdnAutoincretment" Value='<%# ((GridViewRow)Container).RowIndex + 1%>' runat="server" />
                   <asp:HiddenField ID="hdnfaultname" Value='<%#Eval("FaultName")%>' runat="server" />

                    
                </ItemTemplate>
                
                <ItemStyle Width="500px" />
                <FooterTemplate>
                    <asp:TextBox ID="txtfoterfaultname"  style="width:98%;" CssClass="NatureOfFaults" ToolTip="Nature of fault"
                        runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnAutoincretmentfoter" Value='<%# ((GridViewRow)Container).RowIndex + 1%>'
                        runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Qnty">
                <ItemTemplate >
                    <asp:TextBox ID="txtQnty"  MaxLength="4" class="TextField numeric-field-without-decimal-places" AutoPostBack="true" OnTextChanged="txtQnty_TextChanged"
                     style="width:98%;" ToolTip="Fault quantity" Text='<%#Eval("FaultsQty")%>' runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnFualtqty" runat="server" Value='<%#Eval("FaultsQty")%>' />
                </ItemTemplate>
                <ItemStyle Width="80px" />
                <FooterStyle Width="80px" />
                <FooterTemplate>
                    <asp:TextBox ID="txtfoterqnty"  class="TextField numeric-field-without-decimal-places" MaxLength="4" style="width:98%;" ToolTip="Fault quantity" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <div style="text-align: center;" class="iSlnkHide">
                        <asp:LinkButton ForeColor="black" Width="50px" ID="lnkDelete" ToolTip="Delete" runat="server" CommandName="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" /> </asp:LinkButton>
                    </div>
                </ItemTemplate>
                <ItemStyle VerticalAlign="top" />
                <FooterTemplate>
                    <div style="text-align: center;" class="iSlnkHide">
                        <asp:LinkButton ForeColor="black" ID="abtnAdd" runat="server" CommandName="Insert" ToolTip="Insert"  style="width:50px;"
                            CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'> <img src="../../images/add-butt.png" /> </asp:LinkButton>
                    </div>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <table border="1" cellpadding="0" cellspacing="0" width="100%" class="border2">
                <tr>
                    <th width="500px">
                        Nature of fault
                    </th>
                    <th width="80px">
                        Qnty
                    </th>
                    <th>
                    Action
                    </th>
                </tr>
                <tr style="text-align: center;">
                    <td>
                        <asp:TextBox ID="txtemptyfaultname" style="width:98%;"  CssClass="NatureOfFaults" ToolTip="Nature of fault"
                            runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtemptyqnty" MaxLength="4" style="width:98%;" ToolTip="Qty" class="TextField numeric-field-without-decimal-places" runat="server"></asp:TextBox>
                    </td>
                    <td width="50px">
                        <asp:LinkButton ForeColor="black" style="width:50px;" ToolTip="Insert New Record" ID="addbutton" runat="server" CssClass="iSlnkHide" CommandName="addnew"> <img src="../../images/add-butt.png" />  </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>

    <div style="float: right; width: auto; margin-top:10px;">
        <asp:Button ID="btnsubmit" runat="server" CssClass="submit" Text="Submit"  OnClick="btnsubmit_Click" />
       
        <asp:Button ID="btnClose" runat="server" class="close do-not-disable da_submit_button" Text="Close" OnClick="btnClose_Click" />
    </div>
   
   </form>
  
   <script type="text/javascript">

    
       function ValidateSubmit() {
           debugger;
          alert('abc');
           var ControlClientId = '<%=hdnControlId.ClientID %>';
           var IsDhuClientId = '<%=hdnIsDHU.ClientID %>';

           var ccid = $("#" + ControlClientId).val();
           var IsDhu = $("#" + IsDhuClientId).val();

           if (IsDhu == '1') {
               alert('IsDhu');
               CloseWindowa('YES', ccid);
               window.parent.Shadowbox.close();
               return false;
           }
           
       }
   </script>
</body>
</html>
