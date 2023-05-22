<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadManagerTailor.aspx.cs" Inherits="iKandi.Web.CadManagerTailor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
	font-size:12px;
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

input{
	width:90%;	
	padding:0px;
}
div input{
	width:80%;
	padding:0px;
	color:blue;	
}
</style>
  <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h2 style="width:400px; margin:10px auto;">Last Day Tailor Load </h2>
<table cellspacing="0" cellpadding="0" width="400" border="1" align="center" runat="server" id="TailorTable">
<tr>
 <th width="93">Tailor On Role</th>
 <th width="93">Tailor Present</th>
 <th width="93">Sample Sent</th>  
   <th width="93">Sample Made Count</th>
    <th width="93">Previus Day Count</th>
</tr>
  <tr>
    <td class="per">
    <asp:TextBox runat="server" ID="txtTailorRole" MaxLength="4" style="border:1px solid white;"  CssClass="TailorLoad" required></asp:TextBox>
  
    
    </td>
    <td align="right" class="gray"><asp:TextBox runat="server" ID="txtTailorPresent" MaxLength="4"  CssClass="TailorLoad" required></asp:TextBox></td>
    <td align="right" class="gray"><asp:label ID="lblSampleSent" runat="server"></asp:label></td>
    <td align="right" class="gray"><asp:TextBox runat="server" ID="txtMadeCount" MaxLength="4"  CssClass="TailorLoad" required></asp:TextBox></td>  
    <td>
    <asp:label ID="lblPreviousDayCount" runat="server"></asp:label>
    </td>  
  </tr>
 
</table> 

 <br />
<table cellspacing="0" cellpadding="0" width="400" border="1" align="center" runat="server" id="CadTable">
<tr>
 <th width="93">Cad Master Name</th>
 <th width="93">Status</th>
 <th width="93">Remark Count</th>  
  
</tr>
  <tr>
    <td class="per">
    <asp:Label runat="server" ID="lblMasterName"></asp:Label>
  
    </td>
    <td align="right" class="gray"><asp:label ID="lblSampleStatus" runat="server"></asp:label></td>
    <td align="right" class="gray"><asp:TextBox runat="server" ID="txtRemarkCount"  MaxLength="4"   required></asp:TextBox></td>
       
  </tr>
 
</table> 

<div style="width:400px; margin:10px auto;"><asp:Button Text="Submit" CssClass="submit" runat="server" ID="Submit" onclick="Submit_Click" style="width:auto" />
<%--&nbsp;&nbsp;<input type="button" class="cancel" onclick="javascript:window.parent.Shadowbox.close();" />--%>
</div>
  
<script type="text/javascript">
    (function ($) {
        $('.TailorLoad').keyup(function (e) {
            debugger;
            this.value = this.value.replace(/[^0-9\.]/g, '');
            if (/^0/.test(this.value)) {
                this.value = this.value.replace(/^0/, "");

            }

        });

        $(".TailorLoad").keydown(function (event) {
            // Allow only backspace and delete
            if (event.keyCode == 46 || event.keyCode == 8) {
                // let it happen, don't do anything
            }
            else {
                // Ensure that it is a number and stop the keypress
                 if ((event.keyCode > 95) && (event.keyCode < 106)) {
                    return true;
                } else
                if (event.keyCode < 48 || event.keyCode > 57) {
                    event.preventDefault();
                }
                

            }
        });
    })(jQuery);
        </script>
   
   
    </form>
       
</body>
</html>
