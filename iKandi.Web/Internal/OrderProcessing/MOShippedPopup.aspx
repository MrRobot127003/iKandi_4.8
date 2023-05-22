<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOShippedPopup.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.MOStitchPopup" %>
<%@ Register Src="~/UserControls/Lists/MoShippedPopup.ascx" TagName="MoStitchPopup1" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    #MoStitchPopup1_tblBusiness input[type="checkbox"]
         {
            position: relative;
            top: 3px;
          }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:0px auto; width:700px;">
    <uc1:MoStitchPopup1 ID="MoStitchPopup1" runat="server" />

    </div>
    </form>
</body>
</html>
