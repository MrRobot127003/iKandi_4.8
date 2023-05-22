<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionUser.aspx.cs" Inherits="iKandi.Web.Permission" EnableEventValidation="false" MasterPageFile="~/layout/Secure.Master"%>
<%@ Register Src="~/UserControls/Forms/MOPermissionFormNew.ascx" TagName="Permission" TagPrefix="uc1" %> 

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph_head">
 <link href="../../css/report.css" rel="stylesheet" type="text/css" />
<style>
  SELECT
  {
      margin:2px 0px !important;
  }
   .header-text-back
     {
         font-size: 15px !important;
        text-align: center;
        color: #e7e4fb;
        font-family: verdana;
        font-weight: 500;
        padding: 4px 0px !important;
        background-color: #405D99;
        text-transform: capitalize;
      }
      
      #secure_footer
      {
          display:none;
      }
</style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server" >
     <div style="width:100%;text-align:center;clear:both;margin: 5px 0px;">
       <h2 class="header-text-back">Permission</h2>
      </div>
      <uc1:Permission ID="MOPermission" runat="server" />
 </asp:Content>

    
    
