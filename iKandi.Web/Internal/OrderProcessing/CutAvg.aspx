<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CutAvg.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.CutAvg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
    .pop-form
    {
        font-family:Verdana;
        font-size:12px;   
    }
    #lblmsg
    {
        font-weight:bold;
        font-size:11px;
        line-height:18px;
        color:#cc0000 !important;
        text-align:center !important;
      
       
    }
    .button-sumit
    {
    
    }
    b
    {
        color:#39589c;
    }
    #hlkViewMe img
    {
        height:100px;
        width:100px;
    }
 
    th
    {
     
        font-size: 10px !important;
       
    }
    #cssTable td 
{
    text-align:center; 
    vertical-align:middle;
}
#GrdCutAvg
{
    margin-top:5px;
  }
    </style>
    
   <%-- <script type = "text/javascript" language = "javascript">
        function confirm_proceed() {
            if (confirm("Do You Want To process Cut Avg for All Contract Or only for This Contract.") == true) {

                document.getElementById('<%= txtCutAvg.ClientID %>').value == "hello";
                
            }
        
            
            
            
        }
    </script> --%>
   



</head>

<script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
<%--<script type="text/javascript" src="../../js/facebox.js"></script>
<script type="text/javascript" src="../../js/jquery.jcarousel.js"></script>
<script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>--%>   

<script type="text/javascript" language="javascript">
    


     function confirm_proceed() {
         
//         if (confirm("Do You Want To process Cut Avg for All Contract Or only for This Contract.") == true) {
//             document.getElementById("<%= hidConform.ClientID %>").value = "True";
//             document.getElementById("<%= hdnAll.ClientID %>").value = "1";
             $(".btnback").click(); 

//         }
//         else {
//             document.getElementById("<%= hidConform.ClientID %>").value = "False";
//             document.getElementById("<%= hdnAll.ClientID %>").value = "0";
//             $(".btnback").click();
//         }
             

     }

   
 </script>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 46 || charCode > 57))
                return false;
            return true;
        }
        function isNumberInterger(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 47 || charCode > 57))
                return false;
            return true;
        }
</script>



<script type = "text/javascript">

    function childFunc() {

        var totalpcs = document.getElementById("txtCutAvg").value;
        var id = getParameterByName('id');
        window.close();
        window.opener.OpenFinishigslotEntry(totalpcs, id);
        return true;

    }
    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
    function validatecutavg() 
    {
        var values = document.getElementById("txtCutAvg").value;
        var values1 = document.getElementById("txtWidth").value;
        if (values != "" || values1 != "") 
        {
            if ((parseFloat(values)) <= 0 || (parseFloat(values1)) <= 0) {
                alert("There must be cut avg. and Width")
                return false;
            }
            else {
                return true;
            }
        }
        
    }   
</script>






<body>
    <form id="form1" runat="server">
    <table width="750px" align="center" cellspacing="0" cellpadding="0" class="pop-form"
        style="border: 1px solid #ccc; padding: 5px;">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblDirectRepeat" ForeColor="Red" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="70px">
                <b>CutAvg: <span style="color: Red">&#42; </span></b>
                <asp:TextBox ID="txtCutAvg" runat="server" onkeypress="return isNumberKey(event)"
                    MaxLength="5" Width="30px"></asp:TextBox>
                <asp:HiddenField ID="hidConform" runat="server" />
                <asp:HiddenField ID="hdnAll" runat="server" Value="0" />
            </td>
            <td width="80px">
                <b>Order Avg: </b><strong>
                    <asp:Label ID="lblordavg" runat="server" MaxLength="5"></asp:Label>
                </strong>
            </td>
            <td width="100px">
                <b>Cut Width: <span style="color: Red">&#42; </span></b>
                <asp:TextBox ID="txtWidth" runat="server" onkeypress="return isNumberInterger(event)"
                    MaxLength="2" Width="35px"></asp:TextBox>
                <span style="font-size: 10px">Inch </span>
            </td>
            <td width="90px">
                <asp:FileUpload ID="file1" runat="server" Width="90px" 
                     />
                <asp:Label ID="lblUploadImg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
            </td>
            <td rowspan="3" height="100px" width="100px" align="right">
                <asp:HyperLink ID="hlkViewMe" runat="server" Style="border: 1px solid #ccc;" Visible="false"
                    Target="_blank">
                    <asp:Image ID="img" runat="server" Height="100px" Width="100px" Style="border: 1px solid #ccc;
                        padding: 5px; display: none;" Visible="false" />
                </asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="req" runat="server" ErrorMessage="* is Mandatory !"
                    Style="font-size: 11px;" ControlToValidate="txtCutAvg" ValidationGroup="G1"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqWidth" runat="server" ErrorMessage="* is Mandatory !"
                    Style="font-size: 11px;" ControlToValidate="txtWidth" ValidationGroup="G1"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                <asp:Label ID="lblCatgImg" runat="server" Text="" Font-Italic="True" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="vertical-align: top;">
                <b style="vertical-align: top;">Comment </b>
                <asp:TextBox ID="txt_CommentBox" ToolTip="Enter your comments" Height="70px" Width="80%"
                    runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr >
            <td colspan="6" id="cssTable"> 
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                
                <asp:GridView ID="GrdCutAvg"  AutoGenerateColumns="false" runat="server" ShowHeader="True" CssClass="item_list2"
                     CellPadding="0" ShowFooter="false"  HeaderStyle-CssClass="border2" OnRowDataBound="GrdCutAvg_RowDataBound">
                    
                    <Columns>
                    <asp:TemplateField HeaderText="Serial No.">
                            <ItemTemplate>
                                <asp:Label ID="lblserial" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblquantity" Text='<%# Eval("Quantity")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="73px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contract no.">
                            <ItemTemplate>
                                <asp:Label ID="lblcontractName" Text='<%# Eval("ContractNumber")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="145px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Print Details">
                            <ItemTemplate>
                                <asp:Label ID="lblprintDetails" Text='<%# Eval("PrintDetails")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fabric Name">
                            <ItemTemplate>
                                <asp:Label ID="lblFabricName" Text='<%# Eval("Fabric")%>' runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnOrderDetailsID" Value='<%# Eval("OrderDetailsID")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="252px" />
                        </asp:TemplateField>                                                                      
                        <asp:TemplateField HeaderText="Is Check">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                        </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="Chkischeck" AutoPostBack="true" OnCheckedChanged="Chkischeck_CheckedChanged" runat="server" Checked="true" />
                            </ItemTemplate>
                            <ItemStyle Width="73px" />
                        </asp:TemplateField>
                        
                        
                    </Columns>
                    
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="right">
                <asp:Button ID="btnsubmit" OnClientClick="javascript:return validatecutavg();" runat="server" ValidationGroup="G1" Text="Submit" OnClick="btnsubmit_Click"
                    CssClass="button-sumit da_submit_button submit" />
                <asp:Button ID="btnback" runat="server" CssClass="btnback button-sumit submit" Style="display: none;"
                    Text="Submit" OnClick="btnback_Click" />
            </td>
        </tr>
    </table>
    
     
  
   
    </form>
</body>
</html>
