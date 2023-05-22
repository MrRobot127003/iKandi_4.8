<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierQuotationScreen.aspx.cs"
    Inherits="iKandi.Web.Internal.SupplierQuotationScreen" %>

<%@ Register Src="~/UserControls/Forms/FabricSupplierQuotation.ascx" TagName="FabricQuotationForm"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Forms/AccessorySupplierQuotation.ascx" TagName="AccessoryQuotationForm"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Forms/StyleSpecificSupplierQuotation.ascx" TagName="StyleSpecificSupplierQuotation"
    TagPrefix="uc4" %>
<%--<%@ Register src="../UserControls/Forms/TopNavigation.ascx" tagname="TopNavigation" tagprefix="uc3" %>--%>
<%--<%@ Register src="../GameAbhishek.ascx" tagname="GameAbhishek" tagprefix="uc3" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boutique International Pvt. Ltd.</title>
    <link href="../App_Themes/ikandi/ikandi.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/ikandi/ikandi1.css" rel="stylesheet" type="text/css" />
    <meta http-equiv='cache-control' content='no-cache'>
    <meta http-equiv='expires' content='0'>
    <meta http-equiv='pragma' content='no-cache'>
</head>
<body>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <%-- <script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>--%>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <style type="text/css">
        #spinnL
        {
            position: fixed;
            left: 40x;
            top: 0px;
            width: 20%;
            height: 20%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        .clsDivQuotationHdr
        {
            background: #dddfe4;
            font-weight: bold;
            color: #575759;
            font-family: arial;
            font-size: 11px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            border: 1px solid #999;
            width: 998px;
            border-bottom: 0px;
        }
        .tabQuotation
        {
                overflow: hidden;
                border: 0px solid #ccc;
                background-color: #f9f8f8;
                padding-left: 10px;
                width: 100%;
                min-width:1200px;
                box-sizing: border-box;
                float: left;
                position: fixed;
                top: 92px;
                padding-top: 5px;;
        }
        .tabQuotation a
        {
            background-color: inherit;
            border: none;
            outline: none;
            cursor: pointer; /* padding: 14px 16px; */
            transition: 0.3s;
            font-size: 13px;
            border: 1px solid #999;
            width: 72px;
            text-align: center;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
            margin-right: 2px;
            font-family: sans-serif !important;
            padding: 3px 2px;
            border-bottom: 0px;
            float: left;
        }
        .tabQuotation a:hover
        {
            background-color: #ddd;
        }
        
        
        /* Create an active/current tablink class */
        
        .tabQuotation a.active
        {
            background-color: #ccc;
        }
        .tab1Fabric
        {
            cursor: pointer;
        }
        .tab1Accessory
        {
            cursor: pointer;
        }
        .Active
        {
            background: #0c73bb !important;
            color: #fff;
        }
        .maincontentcontainer
        {
            margin: 0px 0px 0px 6px !important;
        }

        h2
        {
            font-size: 15px;
            font-weight: 500;
            padding: 3px 0px;
            background: #39589c;
            color: #fff;
            width: 1154px;
            text-align: center;
            text-transform: capitalize;
            letter-spacing: 1px;
            
            font-family: Arial;
            margin: 3px 0px !important;
        }

        
        .tableStyle tr:last-child(1) > td
        {
            border-bottom: 0px;
        }
        .activeback
        {
            background: green !important;
            color: #fff;
        }
        .go
        {
            border-radius: 2px;
        }
        
        #spinner
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        .overlay
        {    position: fixed;
            top: 0%;
            left: 0%;
            background-color: white;
          
            width: 100%;
            height: 100%;
           
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=80)";
             z-index: 9999;
              background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat;
        }
        .backColor
        {
            background:#fff;
         }
         
          table {
        font-family: arial;
        border-color: gray;
        border-collapse: separate !important;
        border-spacing: 0;
    }
      table td:first-child {
          padding-left:2px;
          
        }
    .modal-content table tr:first-child {
          background-color:#dddfe4;
        }
   .modal-content table tr:first-child td {
          border-color:#8d8d8d;
          border:1px solid #8d8d8d; 
        }
       
        table td{
            border-top: 1px solid  #dbd8d8;
            border-right:  1px solid  #dbd8d8;
             font-size: 10px;
            text-align: center;
            text-transform: capitalize;
            color: gray;
            border-color: #dedede;
        }
  
        table .HeaderClass1 td {
            position: sticky;
            background-color: #dddfe4;
            border: 1px solid #999;
            border-bottom:  0px;
            position: -webkit-sticky; 
            position: sticky;
            font-size: 10px;
            text-align: center;
            font-weight: 500;
            height:21px;
            color: #575759;
            top:148px;
            display:none
        }
        table .HeaderClass td
        {
            position: sticky;
            background-color: #dddfe4;
            border-top: 1px solid #999;
            border-bottom:  1px solid #999;
            border-right: 1px solid #999;
            position: -webkit-sticky;
            font-size: 10px;
            text-align: center;
            font-weight: 500;
            color: #575759;
            top:148px;  
        }
        table .HeaderClass td:first-child
        {
             border-left: 1px solid #999; 
         }
        
          table th
        {
           position: sticky;
            background-color: #dddfe4;
            border-top: 1px solid #999;
            border-bottom:  1px solid #999;
            border-right: 1px solid #999;
            position: -webkit-sticky;
            font-size: 10px;
            padding: 5px 0px;
            text-align: center;
            font-weight: 500;
            color: #575759;
            top:170px;  
        }
        
        table tr:last-child > td
       {
          border-bottom-color: #999;
        }
       table td .InnerTable tr:last-child > td
       {
          border-top:0px solid #dedede;
          border-right-color:#dedede;
        }
        table td .InnerTable tr:first-child > td
       {
          border-top:0px solid #dedede;
          border-right-color:#dedede;
        }
         table td .InnerTable td
       {
           border:0px;
           border-top:0px;
           border-bottom:0px;
        }
         table td.FabFirstLeftbor
        {
            border-left-color: #dedede;
            line-height: 12px;
        }
        .FabFirstCol a,span
        {
            margin-right:10px;
            }
        .InnerTable td
        {
            height: 24px;
         }
         td.borderLeftBottom
         {
             border:0px;
             border-left:1px solid #999;
             border-bottom:1px solid #999;
          }
           td.borderBottom
         {
            border:0px;
             border-bottom:1px solid #999;
          }
           td.borderRightBottom
         {
             border:0px;
             border-right:1px solid #999;
             border-bottom:1px solid #999;
          }
            .border_last_bottom_color
            {
                border-bottom-color: #999 !important;
                 border-bottom: 1px solid #999 !important;
            }
            .innertablePo
            {
                border: 1px solid #dfdfdf;
                width: 100%;
            }
            .innertablePo td
            {
                min-width: 47px;
                max-width: 47px;
                height: 15px;
            }
            .innertablePo td:last-child
            {
                min-width: 50px;
                max-width: 50px;
                height: 15px;
            }
             .fade-in {
  animation: fadeIn ease 10s;
  -webkit-animation: fadeIn ease 10s;
  -moz-animation: fadeIn ease 10s;
  -o-animation: fadeIn ease 10s;
  -ms-animation: fadeIn ease 10s;
}
@keyframes fadeIn {
  0% {
     opacity:0.5;
  }
  100% {
    opacity:0.5;
  }
}

@-moz-keyframes fadeIn {
  0% {
   opacity:0.5;
  }
  100% {
   opacity:0.5;
  }
}

@-webkit-keyframes fadeIn {
  0% {
   opacity:0.5;
  }
  100% {
opacity:0.5;
  }
}

@-o-keyframes fadeIn {
  0% {
    opacity:0.5;
  }
  100% {
opacity:0.5;
  }
}

@-ms-keyframes fadeIn {
  0% {
   opacity:0.5;
  }
  100% {
opacity:0.5;
}
       #spinner { position: fixed;left: 0px;top: 0px;width: 100%;height: 100%;z-index: 9999; background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat opacity:1;}
       
   .Acceptbutton {    
           background: #408fd7;
    border: solid 1px #045198;
    cursor: pointer;
    padding: 2px;
    font: bold 12px/12px Verdana , Helvetica, sans-serif;
    color: #fff;
    text-decoration: none;
    text-align: center;
   }
    </style>
    <script type="text/javascript">

        //        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        //        var proxy = new ServiceProxy(serviceUrl);

        var hdnSupplyTypeClientId = '<%=hdnSupplyType.ClientID %>';
        var hdnUserIdClientId = '<%=hdnUserId.ClientID %>';

        function SpinnShow() {
            //debugger;
            $("#spinnL").css("display", "block");
            $('body').scrollTop($('body')[0].scrollHeight);
        }

        function ShowHideSupplier(type) {
            debugger;

            var UserId = $("#" + hdnUserIdClientId).val();

            //if(parseInt(UserId) <= 0) {

            if (type == 'Fabric') {
                //                $("#dvFabricQuotation").show();
                //                $("#dvAccessoryQuotation").hide();
                //                $("#dvfabricstylequatation").hide();

                //                $(".tabFabricCls").addClass('Active');
                //                $(".tabAccessoryCls").removeClass('Active');
                //                $(".tabFabricStyleCls").removeClass('Active');
                //                $(".tab1Dayed").removeClass('activeback');

                $("#" + hdnSupplyTypeClientId).val(1);

                $(".clsbtnRefresh").click();
                //window.location.reload();

            }
            else if (type == 'FabricStyle') {

                //                $("#StyleSpecificSupplierQuotation1_grddayedstyle").show();
                //                $(".tab1Dayed").addClass('activeback');
                //                $("#dvfabricstylequatation").show();
                //                $("#dvFabricQuotation").hide();
                //                $("#dvAccessoryQuotation").hide();
                //                $("#StyleSpecificSupplierQuotation1_grddayedstyle").show();
                //                $(".tabFabricStyleCls").addClass('Active');
                //                $(".tabFabricCls").removeClass('Active');
                //                $(".tabAccessoryCls").removeClass('Active');

                $("#" + hdnSupplyTypeClientId).val(2);
                $(".clsbtnRefresh").click();
            }
            else if (type == 'Accessory') {
                $("#dvAccessoryQuotation").show();
                $("#dvFabricQuotation").hide();
                $("#dvfabricstylequatation").hide();

                $(".tabAccessoryCls").addClass('Active');
                $(".tabFabricCls").removeClass('Active');
                $(".tabFabricStyleCls").removeClass('Active');
                $("#" + hdnSupplyTypeClientId).val(3);
                $(".clsbtnRefresh").click();
            }
            //            }

        }

        //        $(document).ready(function () {
        //            debugger;
        //            alert('<%=Session["tabs"] %>');
        //            ShowHideSupplierAfter('<%=Session["tabs"] %>');
        //        });

        function pageLoad() {
            $(".clsbtnRefresh").click();

        }
    </script>
    <form id="form1" runat="server" style="padding-bottom: 50px;">
    <%-- <iframe id="frmMaodalPopup" runat="server" src="~/UserControls/Forms/TopNavigation.ascx" width="700px" height="400px" scrolling="no"></iframe>--%>
    <div>
        <asp:Panel ID="pnlDynamicControl" runat="server">
        </asp:Panel>
    </div>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <%-- <uc3:TopNavigation ID="TopNavigation1" runat="server" />--%>
    <br />
    <asp:UpdateProgress DynamicLayout="true" runat="server" ID="updateProgressQuotation"
        AssociatedUpdatePanelID="UpdatePanelQuotation">
        <ProgressTemplate>
            <div id="spinner" class="fade-in">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanelQuotation" runat="server">
        <ContentTemplate>
            <div style="position: fixed; top: 0px; width: 100%; background: #fff; height: 88px;">
                <div id="header" style="float: left; width: 200px; padding-left: 15px; margin-top: 5px;">
                    <asp:Image ID="boutiquelogo" runat="server" Height="48px" Width="164px" />
                </div>
                <div class="centerdiv" style="float: left; width: 70%; margin-top: 20px; text-align: center">
                    <asp:Label ID="lblusername" CssClass="UsernameColor" runat="server"></asp:Label>
                </div>
                <div style="clear: both">
                </div>
                <div runat="server" id="divlog" style="position: absolute; top: 15px; right: 15px;">
                    <a href="/internal/Logout.aspx" class="topmenu2border" style="text-transform: capitalize !important;">
                        <img src="../Uploads/Photo/log%20_out.png" title="Log Out" alt="Log Out" style="width: 30px" />
                    </a>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <h2 style="position: fixed; top: 67px; width: 100%;">
                    Supplier Quotation</h2>
            </div>
            <div style="clear: both; margin-top: 105px;">
            </div>
            <div class="backColor">
                <div class="tabQuotation">
                    <a runat="server" id="tabFabric" class="tabFabricCls" onclick="ShowHideSupplier('Fabric');">
                        Fabric</a> <a style="width: 125px;" runat="server" id="tabFabricStyle" class="tabFabricStyleCls"
                            onclick="ShowHideSupplier('FabricStyle');">Fabric Style Specific </a><a runat="server"
                                id="tabAccessory" class="tabAccessoryCls" onclick="ShowHideSupplier('Accessory');">
                                Accessory</a>
                    <asp:HiddenField ID="hdnSupplyType" Value="1" runat="server" />
                    <asp:HiddenField ID="hdnUserId" Value="-1" runat="server" />
                </div>
            </div>
            <div style="clear: both;">
            </div>
            <div style="width: 99%; min-width: 1200px; padding-bottom: 6px; border-bottom: none;
                border-right: none;">
                <div id="dvFabricQuotation" runat="server" style="display: none; margin: 0;">
                    <uc1:FabricQuotationForm ID="FabricQuotationForm1" runat="server" />
                </div>
                <div id="dvfabricstylequatation" runat="server" style="display: none;">
                    <uc4:StyleSpecificSupplierQuotation ID="StyleSpecificSupplierQuotation1" runat="server" />
                </div>
                <div id="dvAccessoryQuotation" runat="server" style="display: none;">
                    <uc2:AccessoryQuotationForm ID="AccessoryQuotationForm1" runat="server" />
                </div>
            </div>
            <asp:Button ID="btnRefresh" runat="server" CssClass="clsbtnRefresh go do-not-disable"
                Style="display: none; margin-top: 15px; position: absolute; right: 1%;" Text="Reload Data"
                OnClick="btnRefresh_Click" />
            <%--   <asp:Button ID="btnreload" runat="server" CssClass="go do-not-disable" Style="margin-left: 169px;
                margin-top: 5px" Text="Reload Data" OnClick="btnRefresh_Click" />--%>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRefresh" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
