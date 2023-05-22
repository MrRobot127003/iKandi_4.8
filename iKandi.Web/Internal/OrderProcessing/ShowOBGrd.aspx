<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOBGrd.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.ShowOBGrd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
<script src="../../js/form.js" type="text/javascript"></script>

<script type="text/javascript" language="javascript">


    function NewCreated(IsCreated) {
        //debugger;

        window.parent.ClosePageNewCreated(IsCreated);
        //        this.parent.window.close();
        //$("#lnkClose").click();
        this.self.parent.Shadowbox.close();

        return false;
    }

     

   



</script>
<style  type="text/css">

.select-opt select 
{
    
    background:#EEEEEE;
    width:100%;

    color:#000;
    font-weight:bold;
    border: 1px solid #aaa;

    display: inline-block;
    height: 28px;
    line-height: 28px;
    padding: 4px;
  

}
.select-box2 select
{
    width:100%; 
    background:lightgray;  
}



</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
    <asp:ScriptManager  ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    <table width="100%" style="background-color:#fff;">
    <tr>
    <td bgcolor="#717171" style="padding:3px 0px; color:#fff; font-weight:bold;font-size:13px;" width="30%" align="center">Operation</td>
    <td width="2%">&nbsp;</td>
    <td bgcolor="#717171" style="padding:3px 0px; color:#fff; font-weight:bold; font-size:13px;"  width="30%" align="center">Machine/Manual</td>
    <td width="2%">&nbsp;</td>
    <td bgcolor="#717171" style="padding:3px 0px; color:#fff; font-weight:bold; font-size:13px;"  width="40%" align="center">Attachment</td>
    <td valign="top" align="right" >
   

    <a id="lnkClose" class="ShadoPopup da_submit_button" rel="shadowbox;width=850;height=750;" onclick="javascript:self.parent.Shadowbox.close();">Close</a>

    </td>
    </tr>
    <tr>
    <td class="select-opt" width="30%" valign="top">
 <asp:UpdatePanel ID="UpdatePannel1" runat="server">
             <ContentTemplate>
    <asp:DropDownList ID="ddlOperation" runat="server" AutoPostBack="true"
            onselectedindexchanged="ddlOperation_SelectedIndexChanged" >
            <asp:ListItem Value="-1">Select Operation</asp:ListItem>
            </asp:DropDownList>
           </ContentTemplate>
           </asp:UpdatePanel>
            </td>
            <td width="2%">&nbsp;</td>
    <td class="select-box2" width="30%">
     <%--<asp:DropDownList ID="ddlmachine" runat="server"></asp:DropDownList>--%>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
    <asp:ListBox ID="lstMachine" runat="server"    Height="100"  AutoPostBack="true"
            onselectedindexchanged="lstMachine_SelectedIndexChanged" ></asp:ListBox>
       </ContentTemplate>
           </asp:UpdatePanel>
            </td>
            <td width="2%">&nbsp;</td>
    <td colspan="2" class="select-box2 " width="30%">
   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>
    <asp:ListBox ID="lstAttechment" runat="server"  Height="100"></asp:ListBox>
  </ContentTemplate>
           </asp:UpdatePanel>
    </td>
    
    </tr>
    <tr>
    <td colspan="6" align="right">
    <asp:Button ID="btnSave" runat="server" Text="Submit"  CssClass="btnABCD submit"  onclick="btnSave_Click" />
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
