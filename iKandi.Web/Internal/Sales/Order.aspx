<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Order.aspx.cs" Inherits="iKandi.Web.Order" MasterPageFile="~/layout/Secure.Master"  ValidateRequest="false" %>

<%@ Register Src="~/UserControls/Forms/OrderForm.ascx" TagName="OrderForm" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cph_head">

<%--<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>
--%>
  <script type="text/javascript">

      $(function () {
          $(".th").datepicker({ dateFormat: 'dd M y (D)' });
//          $("#txtDC1").datepicker({ dateFormat: 'dd M y (D)' });
//                    $(".th1").datepicker({ dateFormat: 'dd/mm/yy' });
//          //          $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });
      });
  
  </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
   
        <uc1:OrderForm ID="OrderForm1" runat="server" />
  
</asp:Content>
