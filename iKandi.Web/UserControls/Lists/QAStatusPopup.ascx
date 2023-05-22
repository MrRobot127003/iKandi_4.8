<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QAStatusPopup.ascx.cs" Inherits="iKandi.Web.QAStatusPopup" %>


<style>
.text_Style
{ text-align:left;
	}
	.text_Style th
{ text-align:left;
	}
	.no_Style
{ text-align:center;
	}
.item_list1
{
    color: Black;
    background-color: #F9DDF4;
    text-transform: uppercase;
    border: 1px solid black;

    padding: 10px;
    font-weight: normal;
}
.grid tr
{
	  padding: 10px;
	}
	.item_list1 TH
{
    color: Black;
    background-color: #F9DDF4;
    text-transform: uppercase;
    border: 1px solid black;

    padding: 10px;
    font-weight: normal;
}
</style>
<script type="text/javascript">
    function showData(srcElem) {
        
        var srcVal = srcElem.parentNode.all[0].value;
        var srchref = srcElem.parentNode.all[3].value;
        srcElem.href = srchref + "&strDate=" + srcVal;
    }
    function test(src) {
        alert(src);
    }
    function test2() {   
      window.open('', '_self', ''); window.close();      
      window.opener.location.href = window.opener.location;                 
      return false;
    }
 </script>
 <script type="text/javascript">
     window.onload = windowClose;
     function windowClose() {
       //  debugger;
         if (document.getElementById('<%=hdnPageStatus.ClientID %>').value == "1") {
             window.open('', '_self', '');
             window.close();
            // window.opener.location.href = window.opener.location;     
           //  var path = new Array;
            
           //  if (window.opener.location.href.indexOf('?') != -1) {
              //   path = window.opener.location.href.split('?');
              //   window.opener.location.href = path[0] + "?SeaVal=Yes";
           //  }
            // else 
               //  window.opener.location.href = window.opener.location + "?SeaVal=Yes";            
         }

     }      
</script>
 
<div class="form_box">
<div class="form_heading">QA Status</div>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td>
    <asp:GridView ID="grdQAStatus" runat="server" AutoGenerateColumns="false" 
        Width="100%" CssClass="grid fixed-header"  onrowdatabound="grdQAStatus_RowDataBound">
    <Columns>
    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="item_list1" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Left">
    <ItemTemplate>
    <div style="text-align:left">
        <asp:HiddenField ID="hdnStatusID" runat="server" Value='<%# ((Eval("StatusID") != null) ? Eval("StatusID").ToString() : "0" ) %>' />
       <input type="hidden" id="statusID<%# Container.DataItemIndex + 1 %>" name="statusID<%# Container.DataItemIndex + 1 %>"
     value='<%# ((Eval("StatusID") != null) ? Eval("StatusID").ToString() : "0" ) %>' />
        <asp:Label ID="lblStatus" runat="server" Text='<%# (Eval("StatusName").ToString()) %>'></asp:Label>
    </div>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Target Date" HeaderStyle-CssClass="item_list1" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="30%">
    <ItemTemplate>
    <div style="text-align:center">
     <asp:Label ID="lblTarget" runat="server" Text='<%# (Convert.ToDateTime(Eval("TargetDate")).ToString("dd MMM yy (ddd)")) %>'></asp:Label>
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Actual Date" HeaderStyle-CssClass="item_list1" HeaderStyle-HorizontalAlign="Center" >
    <ItemTemplate>
    <div style="text-align:center">
    <asp:TextBox ID="txtActual" runat="server" Width="150"
    Text='<%# (Convert.ToDateTime(Eval("ActualDate")) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("ActualDate")).ToString("dd MMM yy (ddd)"))%>'
     ></asp:TextBox>

   <asp:HiddenField ID="hdnActualDate" runat="server" Value='<%# Eval("ActualDate") %>' />

     <a title="click to see the list of contract having same style"  class='<%= iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.QA_STATUS_MO)? "":"hide_me" %>' target="ManageOrderQA" onclick="showData(this);" href="/Internal/OrderProcessing/ManageOrderQAStatus.aspx?SID=<%# Eval("StatusID") %>&orderdetailid=<%# Eval("OrderDetailID") %>&styleid=<%# Eval("StyleID") %>" >
<%--<asp:Label ID="lblQAStatus" runat="server" Text='View'></asp:Label>--%>
     <%--<img runat="server" id="imgStatus1" title="click to see the list of contract having same style" src="/App_Themes/ikandi/images/view_icon.png"
                        class='<%# ((int)Eval("StatusID") > 31 && Convert.ToDateTime(Eval("ActualDate")) == DateTime.MinValue)? "":"hide_me" %>' border="0" />--%>
    <asp:Image ID="imgStatus" ImageUrl="/App_Themes/ikandi/images/view_icon.png" CssClass='<%# ((int)Eval("StatusID") > 34 && Convert.ToDateTime(Eval("ActualDate")) == DateTime.MinValue)? "":"hide_me" %>' BorderWidth="0" runat="server" /> </a>
<input type="hidden" value='/Internal/OrderProcessing/ManageOrderQAStatus.aspx?SID=<%# Eval("StatusID") %>&orderdetailid=<%# Eval("OrderDetailID") %>&styleid=<%# Eval("StyleID") %>' />
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    </asp:GridView>
</td></tr>
<tr><td>
    &nbsp;
</td></tr>
<tr><td>
    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" />
    <asp:Button ID="Button1" runat="server" CssClass="close"  
        onclick="Button1_Click" ondisposed="Button1_Disposed"/> 
    <asp:HiddenField ID="hdnPageStatus" Value="0" runat="server" />
</td></tr>
</table>
</div>