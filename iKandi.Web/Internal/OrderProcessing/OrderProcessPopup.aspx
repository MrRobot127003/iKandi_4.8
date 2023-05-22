<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderProcessPopup.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.OrderProcessPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>

    <script src="../../js/jquery.fancybox.js" type="text/javascript"></script>
    <link href="../../js/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    

    <script type="text/javascript">

        //$(function () {
    //this.parent.parent.window.de
   // });

    // For Shadow box
//                function GotoNew() {
//                    //debugger;
//                    var iTab = $('#<%= hdnTab.ClientID %>').val();
//                    if (iTab == 1) {
//                        window.parent.RiskAnalysis_CreateNew();
//                    }
//                    if (iTab == 2) {
//                        window.parent.Fits_CreateNew();
//                    }
//                    if (iTab == 3) {
//                        window.parent.OB_CreateNew();
//                    }
//                    if (iTab == 4) {
//                        window.parent.HOPPM_CreateNew();
//                    }
//                    //this.parent.window.close();
//                    window.location.href = $(location).attr('href');
//                    return false;
//                }

//                function NewWithRefrence(NewStyleID, NewStyleNumber) {
//                    //debugger;
//                    var iTab = $('#<%= hdnTab.ClientID %>').val();
//                    if (iTab == 1) {
//                        window.parent.RiskAnalysis_NewRefrence(NewStyleID, NewStyleNumber);
//                    }
//                    if (iTab == 2) {
//                        window.parent.Fits_NewRefrence(NewStyleID, NewStyleNumber);
//                    }
//                    if (iTab == 3) {
//                        window.parent.OB_ReUse(NewStyleID, NewStyleNumber);

//                    }
//                    if (iTab == 4) {
//                        window.parent.HOPPM_NewRefrence(NewStyleID, NewStyleNumber);
//                    }
//                    this.self.parent.Shadowbox.close();
//                    return false;
//                }

//                function ReUse(ReUseStyleID, ReUseStyleNumber) {
//                    //debugger;
//                    var iTab = $('#<%= hdnTab.ClientID %>').val();
//                    if (iTab == 1) {
//                        window.parent.RiskAnalysis_ReUse(ReUseStyleID, ReUseStyleNumber);
//                    }
//                    if (iTab == 2) {
//                        window.parent.Fits_ReUse(ReUseStyleID, ReUseStyleNumber);
//                    }
//                    if (iTab == 3) {
//                        window.parent.OB_ReUse(ReUseStyleID, ReUseStyleNumber);
//                        
//                    }
//                    if (iTab == 4) {
//                        window.parent.HOPPM_ReUse(ReUseStyleID, ReUseStyleNumber);
//                    }
//                    this.self.parent.Shadowbox.close();
//                    return false;
//                }


        function GotoNew() {
            //debugger;
            var iTab = $('#<%= hdnTab.ClientID %>').val();
            if (iTab == 1) {
                window.opener.RiskAnalysis_CreateNew();
            }
            if (iTab == 2) {
                window.opener.Fits_CreateNew();
            }
            if (iTab == 3) {
                window.opener.OB_CreateNew();
            }
            if (iTab == 4) {
                window.opener.HOPPM_CreateNew();
            }
            this.parent.window.close();
            //window.location.href = $(location).attr('href');
            return false;
        }

        function NewWithRefrence(NewStyleID, NewStyleNumber) {
            //debugger;
            var iTab = $('#<%= hdnTab.ClientID %>').val();
            if (iTab == 1) {
                window.opener.RiskAnalysis_NewRefrence(NewStyleID, NewStyleNumber);
            }
            if (iTab == 2) {
                window.opener.Fits_NewRefrence(NewStyleID, NewStyleNumber);
            }
            if (iTab == 3) {
                window.opener.OB_NewRefrence(NewStyleID, NewStyleNumber);

            }
            if (iTab == 4) {
                window.opener.HOPPM_NewRefrence(NewStyleID, NewStyleNumber);
            }
            this.parent.window.close();
            return false;
        }

        function ReUse(ReUseStyleID, ReUseStyleNumber) {
            //debugger;
            var iTab = $('#<%= hdnTab.ClientID %>').val();
            if (iTab == 1) {
                window.opener.RiskAnalysis_ReUse(ReUseStyleID, ReUseStyleNumber);
            }
            if (iTab == 2) {
                window.opener.Fits_ReUse(ReUseStyleID, ReUseStyleNumber);
            }
            if (iTab == 3) {
                window.opener.OB_ReUse(ReUseStyleID, ReUseStyleNumber);

            }
            if (iTab == 4) {
                window.opener.HOPPM_ReUse(ReUseStyleID, ReUseStyleNumber);
            }
            this.parent.window.close();
            return false;
        }


                


    </script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
        *{
  background: #ffffff;
}

.btn:hover {
  background: #3cb0fd;
  background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
  background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
  background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
  background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
  background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
  text-decoration: none;
}

SELECT {

    text-transform: capitalize;
}
a
{
    text-decoration:none;
}
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <a id="frame" href="#">
    <div>
    <table width="100%">
    <div style="background:#39589c; color:#fff; text-align:center; margin:0px; font-weight:bold; font-size:16px; padding:5px;"> Create New / Create New with Refrence / Re-Use 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <%--<asp:LinkButton ID="lnkClose1" runat="server" ToolTip="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" Font-Size="15px" CausesValidation="false"><img src="../../images/del-butt.png" /></asp:LinkButton>--%>

    </div>
           
     <tr>
     <td>
             <table width="95%" border="0" cellpadding="0" cellspacing="0" align="center">
             <tr>

    <td><asp:HiddenField ID="hdnTab" Value="0" runat="server" />        
        <asp:Button ID="btnCreateNew" CssClass="btn" OnClientClick="javascript:return GotoNew();" runat="server" Text="Create New" />  
         /   
         <asp:DropDownList CssClass="ddlStyle" ID="ddlNewWithRefrence" 
            AutoPostBack="true" runat="server" style="font-family: verdana; font-size: 13px; color: #262626; background:#efefef; width:214px;" onselectedindexchanged="ddlNewWithRefrence_SelectedIndexChanged">
            <asp:ListItem Value="0" Text="Create New with Refrence"></asp:ListItem>
                </asp:DropDownList> /

                <asp:DropDownList CssClass="ddlStyle" ID="ddlReUse" AutoPostBack="true" runat="server" style="font-family: verdana; width:215px; font-size: 13px; color: #262626; background:#efefef" onselectedindexchanged="ddlReUse_SelectedIndexChanged">
                <asp:ListItem Value="0" Text="Re-Use"></asp:ListItem>
                </asp:DropDownList>
        </td>        
           
           
           
    </tr>
    </table>
    </td>
    </tr>
    </table>
    </div>
    </a>
    </form>
</body>
</html>
