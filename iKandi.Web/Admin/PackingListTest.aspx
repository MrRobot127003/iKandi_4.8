<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackingListTest.aspx.cs" Inherits="iKandi.Web.Admin.PackingListTest" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />  
  <script src="../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
  <script type="text/javascript">
    function OpenPackingListShadowbox(obj) {
      var sURL = obj.href;
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 135, width: 725, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      $("#sb-nav-close").css({ "visibility": "hidden" });
      return false;
    }

    function OpenValueAdditionShadowbox(obj) {
      var sURL = obj.href;
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 1025, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      $("#sb-nav-close").css({ "visibility": "hidden" });
      return false;
    }

    function OpenValueAdditionHistoryShadowbox(obj) {
      var sURL = obj.href;
      Shadowbox.init({ animate: true, animateFade: true, modal: true });
      Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 1120, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
      $("#sb-nav-close").css({ "visibility": "hidden" });
      return false;
    }
    function SBClose() { }
  </script>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <table border="0" cellpadding="0" cellspacing="0" width="700px" align="center" style="padding-top:50px;">
      <tr>
        <td align="center">
          <a rel="shadowbox;width=725;height=135;" href="/Admin/PackingList.aspx?OrderDetailId=9758" onclick="return OpenPackingListShadowbox(this);">Packing List</a>
        </td>
        <td align="center">
          <a rel="shadowbox;width=1025;height=550;" href="/Admin/ValueAddition.aspx?OrderDetailId=8378&UnitId=3" onclick="return OpenValueAdditionShadowbox(this);">Value Addition</a>
        </td>
      </tr>
      <tr>
        <td colspan="2" align="center">
          <a rel="shadowbox;width=1120;height=550;" href="/Admin/ValueAdditionHistory.aspx?OrderDetailId=8378&UnitId=3" onclick="return OpenValueAdditionHistoryShadowbox(this);">Value Addition History</a>
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
