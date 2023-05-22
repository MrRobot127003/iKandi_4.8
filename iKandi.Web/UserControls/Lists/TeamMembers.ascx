<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamMembers.ascx.cs"
    Inherits="iKandi.Web.TeamMembers" %>
    
<script type="text/javascript" >

var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
var proxy = new ServiceProxy(serviceUrl);

 function showUserInformation(userId)
  { 
     proxy.invoke("GetUserInformationView", {UserID:userId} , function(result)
     {
        jQuery.facebox(result); 
     },  onPageError, false, false);
  }
  
   function onPageError(error)
 {
   alert(error.Message + ' -- ' +error.detail);
 }

</script>    
   <div > 
<asp:Repeater ID="rptTeamMembers" runat="server" DataSourceID="odsUsers">
    <ItemTemplate>
        <div>
            <a href="javascript:void(0)" onclick='showUserInformation(<%# Eval("UserID") %>)'><b>
                <%# Eval("FullName") %></b></a>
        </div>
        <div>
            <%# iKandi.Common.Constants.GetDesignationName( Convert.ToInt32( Eval("DesignationID"))) %>
        </div>
        <br />
    </ItemTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="odsUsers" runat="server" SelectMethod="GetTeamMembers"
    TypeName="iKandi.BLL.UserController" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="UserID" Type="Int32" DefaultValue="-1" />
    </SelectParameters>
</asp:ObjectDataSource>

</div>
 

