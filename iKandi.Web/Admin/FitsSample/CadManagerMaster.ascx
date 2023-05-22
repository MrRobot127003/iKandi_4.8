<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CadManagerMaster.ascx.cs" Inherits="iKandi.Web.Admin.FitsSample.CadManagerMaster" %>


    <style type="text/css">
body {
    background: #f9f9fa none repeat scroll 0 0;
    font-family: verdana;

   
}
table{
	font-family:verdana;	
	border-color:gray;
	border-collapse:collapse;
}
 th{
	background:#dddfe4;
border: 1px solid #b7b4b4;
	font-weight:normal;
	 color:#575759;
    font-family: arial,halvetica;
    font-size: 10px;
	padding:5px 0px;	
}
table td{
	
	text-align:center;
	border-color:#aaa;
}
.per{
	color:blue;
	
}
.gray{
	color:gray;
	
}
h2{
	font-size:12px;
	font-weight:bold;
	padding:5px;	
	background:#39589C;
	color:#fff;
	text-align:center;
}

input[type="text"]{
	width:90%;	
	padding:0px;
}
div input[type="text"]{
	width:80%;
	padding:0px;
	color:blue;	
}
</style>

<script type="text/javascript">

    function isNumberKey(evt) {
      evt = (evt) ? evt : window.event;
      var charCode = (evt.which) ? evt.which : evt.keyCode;
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
      }
      return true;
    }
</script>

 
    <h2 style="width:400px; margin:10px auto;">Remake Counts <asp:Label style="text-align:right; float:right;" ID="lblCountoverall" runat="server"></asp:Label></h2>
    
<table cellspacing="0" cellpadding="0" width="400" border="1" align="center" runat="server" id="TailorTable">
<tr>
 <th width="93">Tailor On Role</th>
 <th width="93">Tailor Present</th>
 <th width="93">Sample Sent</th>  
   <th width="93">Sample Made Count</th>
</tr>
  <tr>
    <td class="per">
    <asp:TextBox runat="server" ID="txtTailorRole" MaxLength="4" style="border:1px solid white;"  CssClass="TailorLoad" ></asp:TextBox>
  
    
    </td>
    <td align="right" class="gray"><asp:TextBox runat="server" ID="txtTailorPresent" MaxLength="4"  CssClass="TailorLoad" ></asp:TextBox></td>
    <td align="right" class="gray"><asp:label ID="lblSampleSent" runat="server"></asp:label></td>
    <td align="right" class="gray"><asp:TextBox runat="server" ID="txtMadeCount" MaxLength="4"  CssClass="TailorLoad" ></asp:TextBox></td>    
  </tr>
 
</table> 

 <br />
<table cellspacing="0" cellpadding="0" width="400" border="1" align="center" runat="server" id="CadTable">
<tr>
 <th width="93">Cad Master Name</th>
 <th width="93">Status</th>
 <th width="93">Remake Count</th>  
 <th width="93">Remake</th> 
  
</tr>
  <tr>
    <td class="per">
    <asp:Label runat="server" ID="lblMasterName"></asp:Label>
  
    </td>
    <td align="right" class="gray"><asp:label ID="lblSampleStatus" runat="server"></asp:label></td>
    <td align="right" class="gray"><asp:TextBox runat="server" ID="txtRemarkCount" MaxLength="2" onkeypress="Javascript:return isNumberKey(event);" ></asp:TextBox></td>
      <td align="right" class="gray"><asp:Label ID="lblperiviouscount" runat="server"></asp:Label></td> 
  </tr>
 
</table> 

<div style="width:400px; margin:10px auto;">
<asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
                Width="86px" OnClientClick="javascript:closeMe();" />&nbsp;&nbsp;&nbsp
<asp:Button ID="btnsub" CssClass="submit" Text="submit"  CausesValidation="False" runat="server"   
     onclick="btnsub_Click"  />&nbsp;&nbsp;
     <%--<input type="button" class="da_submit_button" value="Cancel" onclick="javascript:window.parent.Shadowbox.close();" />--%>
     </div>
     <script type="text/javascript">
         function closeMe() {
            self.parent.Shadowbox.close();
            //window.opener = self;
            //window.close();
        }
</script>
        

   
   

       

