<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="FrmWorkingOnRaisedPO.aspx.cs" MaintainScrollPositionOnPostback="true"
    Inherits="iKandi.Web.Internal.Fabric.FrmWorkingOnRaisedPO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
        body
        {
            background: #f9f9fa none repeat scroll 0 0;
            font-family: arial,sans-serif !important;
        }
        
        table
        {
            font-family: arial !important;
            border-color: gray;
            border-collapse: collapse;
        }
        
        
        .HeaderClass td
        {
            background: #dddfe4;
            font-weight: normal;
            color: #575759;
            font-size: 11px;
            padding: 5px 0px;
            border-color: #c6c0c0;
            font-family: arial,sans-serif !important;
            height: 32px;
            border-color: #999;
            border-bottom-color: #999;
            text-transform: capitalize;
        }
        .PurchaseOrder
        {
            width: 1000px !important;
            left: 50% !important;
            transform: translate(-50%, 10px);
        }
        .PendingSummaryTable th
        {
            position: sticky !important;
            top: 55px;
        }
        @media print
        {
            body
            {
                -webkit-print-color-adjust: exact;
            }
        }
        
        .btnrpo
        {
            cursor: pointer;
            background-color: blue;
            color: #fff;
            width: 30px;
            font-size: 9px;
            border-radius: 20px;
            padding: 3px 2px;
            float: right;
            margin: 0 2px;
        }
    </style>
    <style type="text/css">
            body {
      background: #f9f9fa none repeat scroll 0 0;
      font-family:arial, sans-serif !important;
    }

    table {
      font-family: arial,sans-serif !important;
     
                border-color: gray;
      border-collapse: collapse;
        text-transform:capitalize;
    }


    table td {
      font-size: 10px;
      text-align: center;
      border-color: #9999;
      color: gray;
      padding: 2px 0px;
      font-family: arial,sans-serif !important;
      text-transform:capitalize;
    }
  .HeaderClass td
  {
      line-height:15px;
   }
    .per {
      color: blue;
    }

    .gray {
      color: gray;
    }

    h2
       
            .row-fir th {
      font-weight: bold;
      font-size: 11px;
    }

    table td table td {
      border-color: #ddd;
    }

    .SUPPLY-MANA td input {
      width: 35%;
    }

    .imageField {
      background-image: url(submit.jpg);
      height: 28px;
      width: 105px;
    }
    .printableArea {
    width: 8.5cm  !important;
    height:100%  !important;
}
 
  @media print {
      .printButtonHide {
        display: none;
      }
      .headerSticky
      {
         display:none;
      }
      #secure_greyline
      {
          display:none;
      }
      #topcontrols
      {
          display:none;
      }
      body, html, #wrapper {
          width: 100%;
      }
      
  
    }
    
 .da_submit_button{
	background:#3b5998;
    width:auto;
    border:0px;	
	padding:5px 9px;
	cursor:pointer;	
	color:#fff;
	text-decoration:none;
	text-align:center;
	height: 22px;
	font-size:12px;
	/*font-weight:bold;*/
	line-height: 14px;
	cursor:pointer;
	border-radius:2px;
	margin:10px;
	
}
@media  print 
{
    #widthdiv{
   background-color: white;
        height: 100%;
        width: 100%;
        position: fixed;
        top: 0;
        left: 0;
        margin: 0;
        padding: 15px;
        font-size: 14px;
        line-height: 18px;
    }
}
 
    .pad {
      text-align: left;
      padding-left: 25px;
    }

    .ths {
      background: #3b5998;
      font-weight: normal;
      color: #fff;
      font-family: arial,sans-serif !important;
      font-size: 10px;
      padding: 5px 0px;
      text-align: center;
      text-transform: capitalize;
    }

    .backcolorstages {
      background: #fdfd96e0;
    }

    input[type="text"] {
      border-color: White;
      width: 34% !important;
      border: 1px solid #999 !important;
      border-radius: 2px;
      height: 13px;
      color: Blue;
      font-size: 10px !important;
    }
     input[type="text"].inptunoneborder 
     {
      border-color: transparent;
       border: 1px solid transparent !important;
      background: transparent;
      color: Blue;
      font-size: 10px !important;
        outline: -webkit-focus-ring-color auto 0px;
    }
     input[type="text"].inptunoneborder:focus {
      border-color: transparent;
       border: 1px solid transparent !important;
      background: transparent;
      color: Blue;
     outline: -webkit-focus-ring-color auto 0px;
      font-size: 10px !important;
    }
   /* :focus
    {
       outline: -webkit-focus-ring-color auto 0px;
     }*/
    .float_left {
      float: left;
      padding-left: 3px;
    }

    .float_right {
      float: right;
      padding-ight: 3px;
    }

    .color_black {
      color: Black;
    }

    .navbar {
      overflow: hidden;
      background-color: #333;
      position: fixed;
     /* Set the navbar to fixed position */
      top: 0;
     /* Position the navbar at the top of the page */
      width: 308px;
     /* Full width */;
    }

    /* Links inside the navbar */
    .navbar a {
      width: 73px;
      text-decoration: none;
      border: 1px solid #fff;
      display: inline-table;
      height: 30px;
      line-height: 30px;
      color: #fff;
    }

    /* Change background on mouse-over */
    .navbar a:hover {
      background: #ddd;
      color: black;
    }

    .tab {
      overflow: hidden;
      border: 0px solid #ccc;
      background-color: #f1f1f1;
      font-family: arial,sans-serif !important;
    }

    /* Style the buttons inside the tab */
    .tab a {
      background-color: inherit;
      border: none;
      outline: none;
      cursor: pointer;
        /* padding: 14px 16px; */
      transition: 0.3s;
      font-size: 13px;
      border: 1px solid #999;
      width: 72px;
      display: inline-block;
      text-align: center;
      border-top-left-radius: 3px;
      border-top-right-radius: 3px;
      margin-right: 2px;
      font-family: arial,sans-serif !important;
      padding: 3px 2px;
    }

    /* Change background color of buttons on hover */
    .tab a:hover {
      background-color: #ddd;
    }

    /* Create an active/current tablink class */
    .tab a.active {
      background-color: #ccc;
    }

    /* Style the tab content */
    .tabcontent {
      display: none;
      padding: 6px 12px;
      border: 1px solid #ccc;
      border-top: none;
    }

    .activeback {
      background: green !important;
      color: #f8f8f8;
    }

    .navbar tab {
      border: 1px solid #fff;
    }

    .maincontentcontainer {
      width: 1100px;
      margin: 20px 0 0px;
    }

    #data tbody > tr:last-child > td {
      border-bottom: 0 !important;
    }

    .btnrpo {
      cursor: pointer;
      background-color: blue;
      color: #fff;
      width: 30px;
      font-size: 9px;
      border-radius: 20px;
      padding: 3px 2px;
      float: right;
      margin: 0 2px;
    }
    .inptunoneborder
    {
              border: 0px !important;
              background: transparent;
           
     }
     .inptunoneborder:focus
    {
              border: 0px !important;
              background: transparent;
           
     }

    .btnrepo {
      cursor: pointer;
      background-color: #FFA500;
      color: #000;
      width: 30px;
      font-size: 9px;
      border-radius: 20px;
      padding: 3px 2px; 
      float: left;
      margin: 0 2px;
    }

    p:nth-last-child(2) {
      background: red;
    }

    td.process:last-child {
      height: 22px;
    }
     td.process {
      height: 19px;
    }
    .HideRaisebtn {
      display: none !important;
    }

    .divspplier {
      position: absolute;
      top: 50%;
      left: 43%;
      min-height: 200px;
      margin-top: -9em;
      margin-left: -15em;
      border: 1px solid #ccc;
      background-color: #f3f3f3;
    }

      
    .topsupplier {
      border-collapse: collapse;
    }

    .topsupplier th {
      background: #536EA9;
      color: #d4d4d4f8;
      text-align: center;
      border: 1px solid #999;
      font-size: 10px !important;
    }

    .topsupplier td {
      text-align: center;
      border: 1px solid #999;
      font-weight: bold;
      font-size: 10px !important;
    }

    #sb-wrapper-inner {
      border: 5px solid #999;
      border-radius: 5px;
    }
     #sb-wrapper.FourPointCheckLef
     {
         top:0px !important;
         left:150px !important;
  }
        #sb-wrapper-inner.FourPointCheck
        {
            min-height: 640px !important;
            max-height: 780px;
            overflow: auto !important;
             width: 1243px;
        
  
         }
    .highlight {
      background-color: #f7d6dc;
    }

    .plusshow {
      background: url('./../images/plus_icon.gif');
    }

    #sb-wrapper-inner {
      background: #fff;
    }

    input[type='text'] {
      text-align: center;
    }

    td {
      max-width: 100px !important;
      min-width: 100px !important;
    }
    td.ColunWidth {
      min-width: 77px !important;
      max-width: 155px !important;
    }
   td.ColunWidthTotalqty {
      min-width: 130px !important;
      max-width: 130px !important;
    }

    /*.gridviewWidth {
      min-width: 1577px;
      max-width: 1577px;
      border:1px solid #999;
    }*/

    .ColunWidth table td.process {
      min-width: 54px !important;
      max-width: 54px !important;
    }

    .challanTable td.challantd {
      min-width: 80px !important;
      max-width: 80px !important;
    }

    .challanTable td.challanimgtd {
      min-width: 19px !important;
      max-width: 19px !important;

    }
    .gridviewWidth td:first-child
    {
        border-left-color:#999 !important;
     }
    .gridviewWidth tr:first-child td
    {
        border-top:0px !important;
     }
    .gridviewWidth td:last-child
    {
        border-right-color:#999 !important;
     }
  
      .gridviewWidth tr:nth-last-child(1) > td
    {
        border-bottom-color:#999 !important;
     }
     td.TypeWidth
     {
         min-width:70px !important;
         max-width:70px !important;
      }
       td.DateWidth
     {
         min-width:40px !important;
         max-width:40px !important;
      }
     td.PlusWidth
     {
         min-width:40px !important;
         max-width:40px !important;
      }
    td.ChallanWidth
     {
         min-width:66px !important;
         max-width:66px !important;
      }
     td.ChallanWidth td
     {
         min-width:65px !important;
         max-width:65px !important;
      }
      td.TadNameWidth
      {
          min-width:200px !important;
           max-width:200px !important;
          text-align: left;
          padding-left:2px;
          border-left:1px solid !important;
      }
      .challsnDebitBorder table td:last-child
         {
             border-right:0px !important;
          }
        
   .btnSrv {
    cursor: pointer;
    background-color: #122bde;
    color: #f5f5f5 !important;
    width: 20px;
    font-size: 9px;
    border-radius: 20px;
    padding: 1px 2px;
    float: right;
    margin: 0 4px;
}
.btnCancel {
    cursor: pointer;
    background-color: #824007;
    color: #f5f5f5 !important;
    width: 38px;
    font-size: 9px;
    border-radius: 20px;
    padding: 1px 2px;
    float: right;
    margin: 0 2px;
}
.btnClosePo {
    cursor: pointer;
    background-color: #af0c0ce6;
    color: #f5f5f5 !important;
    width: 36px;
    font-size: 9px;
    border-radius: 20px;
    padding: 1px 2px;
    float: right;
    margin: 0 2px;
}
.btnlink
{
    background: #99a91a;
    padding: 3px 5px;
    border-radius: 2px;
      color:#fff;
   
  }
  .btnlinkPe
{
   /* background: #66b534;*/
    padding: 3px 5px;
    border-radius: 2px;
    color:#fff;
    cursor:pointer;
     font-size: 11px;
      text-decoration:none;
   
  }
 .btnlinkRe
{
    background: #c34a66;
    padding: 3px 5px;
    border-radius: 2px;
    color:#fff;
   
  }
   .btnlinkPe a:hover
{
    color:yellow !important;
    text-decoration:underline;
  
  }
 .btnlinkRe a:hover
{
    color:yellow !important;
  
  }
  .btnlink a
  {
       color: #f5f5f5 !important;
   }
   .btnlinkPe a
  {
       color: #f5f5f5 !important;
   }
   .btnlinkRe a
  {
       color: #f5f5f5 !important;
   }
   .btnlink a:hover
  {
       color:yellow !important;
       text-decoration:underline;
   }
  a
  {
      text-decoration:none;
   }
    a:hover
  {
      text-decoration:none;
   }
   .ths th {
    padding: 5px 2px;
}
::-webkit-scrollbar {
    width: 8px;
    height:8px;
}
  
 .table_width
        {
            width: 1587px;
            max-height: 450px;
            min-height: 150px;
            overflow-y:auto;
        }
        .m-t-8
       {
           margin-top:8px;
        }
         .m-t-10
       {
           margin-top:10px ;
        }
        #main_content
        {
          width:1868px;
            
        }
     .headerSticky {
        max-width: 1868px !important;
    }
       @media screen and (min-width: 1366px) {

        #sb-wrapper.FourPointCheckLef{top:0px !important;
                      left:10% !important;
                      }
       }
   @media screen and (max-width: 1366px) {
       /*#main_content
        {
            min-width:1310px;
            max-width: 1360px;
            overflow:auto;
        }*/
        #sb-wrapper.FourPointCheckLef{top:0px !important;
                      left:50px !important;
                      }
        #sb-wrapper-inner.FourPointCheck
        {
            min-height: 600px !important;
            max-height: 700px;
            overflow: auto !important;
             width: 1243px;
        
  
         }
          .m-t-8
       {
           margin-top:0px;
        }
         .m-t-10
       {
           margin-top:4px ;
        }
        }
         .HideRaisebtn
   {
       display:none !important;
       }



 table { border-collapse:collapse }
 
 .table-layout {
    text-align: center;
    border: 1px solid black;
    border-collapse: collapse;
    font-family:"Trebuchet MS";
    margin: 0 auto 0;
}
.table-layout td, .table-layout th {
    border: 1px solid grey;
    padding: 5px 5px 0;
}
.table-layout td {
    text-align: left;
}
.selected {
    color: red;
    background-color: yellow;
}
table tr td[colspan="22"]
 {
     border:0px;
     padding-left: 0px;
      padding-right: 0px;
  }


td.PotalQty
{
     min-width:130px !important;
     max-width:130px !important;
  }
 td.PotalQty .PoQtyTable td.QtyWi
 {
     min-width:40px !important;
     max-width:40px !important;
  }
  td.PotalQty .PoQtyTable td.bottonTD
 {
     min-width:90px !important;
     max-width:90px !important;
  }
  .highlighted
  {
      background:#e5e2e2 !important;
   }
   .Unhighlighted
  {
      background:#fff !important;
   }
    table td:first-child {
      padding-left: 2px;
        border-left: 0px;
    }
  .TadNameWidth
   {
       background:#fff !important;
       border-left: 1px solid #999;
    }
   
    .do-not-disable
      {
          border-radius:2px;
   
      }
      #ctl00_cph_main_content_upnl
      {
          margin-top:3px;
       }
        td.ColunWidthCredit {
      min-width: 30px !important;
      max-width: 40px !important;
    }
     .green {
        background-color: green;
    }
    .btnDebitNote
    { 
        color:blue;
        padding:2px 3px;
        cursor:pointer;
        font-weight:500;
        font-size:10px;
      } .btnDebitNote_Grey
    { 
        color:grey;
        padding:2px 3px;
        cursor:pointer;
        font-weight:500;
        font-size:10px;
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
.my-custom-theme {
	border-radius: 5px; 
	border: 2px solid #000;
	background:red;
	color: #39589c
}
/* Use this next selector to style things like font-size and line-height: */
.my-custom-theme .tooltipster-content {
	font-family: Arial, sans-serif;
	font-size: 14px;
	line-height: 16px;
	padding: 8px 10px;
}
#ctl00_cph_main_content_upnl
{
    width:1650px;
 }
 .secure_center_contentWrapper 
 {
    text-transform: capitalize;
    width: 1650px !important;
    background: #fff;
    z-index: 8;  
 }
 .tooltipster-sidetip .tooltipster-content {
	color: pink;
	line-height: 500px;
	padding: 0px 14px!important;
}
    #spinner { position: fixed;left: 0px;top: 0px;width: 100%;height: 100%;z-index: 9999; background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat opacity:1;}
</style>
</asp:Content>
<asp:Content ID="Content2" onload="updateIndicator()" ContentPlaceHolderID="cph_main_content"
    runat="server">
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <script src="../../js/service.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <link href="../../CommonJquery/ToolTip_plugin/css/tooltipster.bundle.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../../CommonJquery/ToolTip_plugin/js/tooltipster.bundle.min.js" type="text/javascript"></script>
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <link href="../../bipl/css/ikandi.css" rel="stylesheet" type="text/css" />
    <script src="../../CommonJquery/Js/iKandi.js" type="text/javascript"></script>
    <link href="../../css/TopHeaderFixed.css" rel="stylesheet" type="text/css" />
    <script src="../../CommonJquery/Js/jquery.autocomplete_new.js" type="text/javascript"></script>
    <style>
        .tooltipster-box
        {
            border: 1px solid #ffff !important;
        }
        .tooltipster-sidetip.tooltipster-top .tooltipster-arrow-border
        {
            border-top-color: #565656 !important;
        }
        .tooltipster-sidetip.tooltipster-right .tooltipster-box
        {
            margin-left: 50px !important;
            left: -90px !important;
        }
        .tooltipster-sidetip .tooltipster-box
        {
            background: #939393 !important;
            left: -90px !important;
        }
        .RaiseDebitTooltip
        {
            position: relative;
            display: inline-block;
            width: 100%;
        }
        
        .RaiseDebitTooltip .RaiseDebitTooltipText
        {
            visibility: hidden;
            position: absolute;
            top: -42px;
            left: -90px;
            width: auto;
            padding: 5px 8px;
            background: #939393;
            color: #fff;
            z-index: 9;
            font-size: 10px;
            height: auto;
            line-height: 14px;
            border-radius: 3px;
            white-space: pre-line;
            word-wrap: break-word;
            width: 100px;
            text-align: left;
        }
        
        .RaiseDebitTooltip .RaiseDebitTooltipText::after
        {
            content: "";
            position: absolute;
            top: 100%;
            left: 100px;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: #939393 transparent transparent transparent;
        }
        
        .RaiseDebitTooltip:hover .RaiseDebitTooltipText
        {
            visibility: visible;
        }
        
        .SrNumberPopup
        {
            position: relative;
            display: inline-block;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        .SrNumberPopup td span
        {
            color: #575759;
        }
        .SrNumberPopup td
        {
            border: 0px !important;
            text-align: left;
            padding-left: 15px !important;
        }
        .SrNumberPopup th
        {
            background: #39589c;
            border-bottom: 0px;
            color: #fff;
            font-size: 11px;
            padding: 3px 0px;
            border: 0px !important;
            text-align: left;
            padding-left: 15px;
        }
        /* The actual popup */
        .SrNumberPopup .SrNoPopupContent
        {
            visibility: hidden;
            width: 120px;
            background-color: #fff;
            color: #000;
            text-align: center;
            border-radius: 6px;
            padding: 0px 0px 5px;
            position: absolute;
            z-index: 1;
            top: 15px;
            left: 2px;
            margin-left: 20px;
            z-index: 10;
            margin-top: -17px;
            box-shadow: 1px 2px 3px 2px #ccc;
        }
        
        /* Popup arrow */
        .SrNumberPopup .SrNoPopupContent::after
        {
            content: "";
            position: absolute;
            top: 0px;
            left: 2%;
            margin-left: -18px;
            border-width: 9px;
            border-style: solid;
            border-color: transparent #39589c transparent transparent;
        }
        
        
        /* Toggle this class - hide and show the popup */
        .SrNumberPopup .SrNoShow
        {
            visibility: visible;
        }
        td.border_bottom_color
        {
            border-bottom-color: #999 !important;
        }
    </style>
    <script type="text/javascript">


         //        var blurred = false;
         //        window.onblur = function () { blurred = true; };
         //        window.onfocus = function () { blurred && (location.reload()); };

        function PrintWindow()
        {    
            var css = '@page { size: landscape; }',
          head = document.head || document.getElementsByTagName('head')[0],
          style = document.createElement('style');

            style.type = 'text/css';
            style.media = 'print';

            if (style.styleSheet) {
                style.styleSheet.cssText = css;
            } else {
                style.appendChild(document.createTextNode(css));
            }

            head.appendChild(style);

            window.print();
        }

        
         function pageLoad() {
        
       
             //debugger;
            // alert();
            // BottomBorder();


             
             $('.tooltip').tooltipster({
                 contentAsHTML: true,
                 theme: 'my-custom-theme',
                 interactive: true,

             });
            // alert($("#ctl00_cph_main_content_hdnsetfocusid").val());
             //alert($("#ctl00_cph_main_content_hdnsetfocusid").val());
             idplus = "ctl00_cph_main_content_grdraisedpoworking_" + $("#ctl00_cph_main_content_hdnsetfocusid").val() + "_lnkplus";
             idminus = "ctl00_cph_main_content_grdraisedpoworking_" + $("#ctl00_cph_main_content_hdnsetfocusid").val() + "_lnkminus";
             // document.getElementById(idplus).focus();
             // document.getElementById(idminus).focus();

             // $('.ss').addClass('selected');

             //            $("#ctl00_cph_main_content_grdraisedpoworking tr").click(function () {
             //                $(this).addClass('selected').siblings().removeClass('selected');
             //                $(this).find('td:first').siblings().removeClass('selected');
             //                //$(this).find('td:first').html();
             //                alert(value);
             //            });
             $("input[type='text']").each(function () {
                 if ($(this).val() == "0") {
                     $(this).val("");
                 }
             })


             $('span').each(function () {
                 if ($(this).text() == '0') {
                     $(this).text("");
                 }
             });


         }

         function HighlightRow(classname) {
           //  alert(classname);
             $('.' + classname).addClass('selected');
             // $(this).find('td:first').siblings().removeClass('selected');
         }
        
         $(document).keydown(function (e) {
             if (e.which === 123) {
                 return false;
             }
         });


         $(function () {        
       


             $('.tooltip').tooltipster({
                 contentAsHTML: true,interactive: true,theme: 'my-custom-theme'
                
             });
             CreditNote = '<%=this.CreditNote %>';
             if (CreditNote == "") {
                 $('.hises').hide();
             }
             $("input[type='text']").each(function () {
                 if ($(this).val() == "0") {
                     $(this).val("");
                 }
             })
         });
         var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
         var proxy = new ServiceProxy(serviceUrl);
         var urls = "../../Webservices/iKandiService.asmx";
         function showcreditnote(SupplierPO_Id) {
             var sURL = 'FabricCreditNoteList.aspx?SupplierPoId=' + SupplierPO_Id;  

             window.open(sURL);
         }
         function ShowSrvbySupplierID(SupplierPO_Id, Fabtype) {
             //debugger;
             $.ajax({
                 type: "POST",
                 url: "FrmWorkingOnRaisedPO.aspx/StoreSessionValue",
                 data: "{ theValue:'" + SupplierPO_Id + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                 }
             });
             var sURL = 'frmSRV.aspx?PoDetailID=' + SupplierPO_Id + "&Fabtype=" + Fabtype;
             Shadowbox.init({ animate: true, animateFade: true, modal: true });
             Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 850, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             // added Code by Bharat on 15-may-20 
             $("#sb-wrapper").removeClass("FourPointCheckLef")
             $("#sb-wrapper-inner").removeClass("FourPointCheck");
               $('#sb-wrapper').removeClass("PurchaseOrder");
             //End
             return false;
         }
         function ShowSrvbyChallanNo(Challno, Fabtype, SupplierPO_Id) {
             //debugger;
             var sURL = 'frmSRV.aspx?Challan_ID=' + Challno + "&Fabtype=" + Fabtype + "&PoDetailID=" + SupplierPO_Id;
             Shadowbox.init({ animate: true, animateFade: true, modal: true });
             Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 550, width: 900, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             // added Code by Bharat on 15-may-20 
             $("#sb-wrapper").removeClass("FourPointCheckLef")
             $("#sb-wrapper-inner").removeClass("FourPointCheck");
               $('#sb-wrapper').removeClass("PurchaseOrder");
             //End
             return false;
         }
         function ShowDebitnoteScreen(DebitNote_Id, SupplierPoID) {
             $.ajax({
                 type: "POST",
                 url: "FrmWorkingOnRaisedPO.aspx/StoreSessionValue",
                 data: "{ theValue:'" + SupplierPoID + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                 }
             });
             //debugger;
             //            var sURL = 'frmFabricDebitNote.aspx?Debit_Note_ID=' + DebitNote_Id + "&PO_id=" + SupplierPoID;
             var sURL = 'FabricDebitNoteList.aspx?Debit_Note_ID=' + DebitNote_Id + "&SupplierPoId=" + SupplierPoID;
             //            Shadowbox.init({ animate: true, animateFade: true, modal: true });
             //            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             //            return false;

             window.open(sURL);
         }
         function ShowSupplierChallanScreen(sURL) {
             // debugger;
             var h = 610;
             var w = 1040;
             ////            if (Type == 'Dyed' || Type == 'Printed') {
             ////                h = 500;
             ////                w = 550;
             ////            }

             $.ajax({
                 type: "POST",
                 url: "FrmWorkingOnRaisedPO.aspx/StoreSessionValue",
                 data: "{ theValue:'" + SupplierPoID + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                 }
             });
             var sURL = 'FabricSupplierChallanDetails.aspx?Debit_Note_ID=' + DebitNote_Id + "&SupplierPoID=" + SupplierPoID + "&ChallanType=" + "DEBITCHALLAN" + "&ChallanID=" + challanid + "&FabType=" + Type + "&IsNewChallan=" + '';
             Shadowbox.init({ animate: true, animateFade: true, modal: true });
             Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             // added Code by Bharat on 15-may-20 
                 $("#sb-wrapper").removeClass("FourPointCheckLef")
                 $("#sb-wrapper-inner").removeClass("FourPointCheck");
                 $('#sb-wrapper').removeClass("PurchaseOrder");
             //End
             return false;
         }
         function ShowSupplierChallanScreenSend(DebitNote_Id, SupplierPoID, challanid, Type, sendqty) {
             // code added by bharat on 11-june
             //debugger;
             //var h = 670;
             // var w = 1010;

             if (parseInt(challanid)==-1){
             return false;
             }
             var h = 550;
             var w = 550;
             if (Type == 'Dyed' || Type == 'Printed') {
                 h = 550;
                 w = 550;
             }
             if (sendqty=="") {
                sendqty=0;
             }
             //end
             $.ajax({
                 type: "POST",
                 url: "FrmWorkingOnRaisedPO.aspx/StoreSessionValue",
                 data: "{ theValue:'" + SupplierPoID + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                 }
             });
             var sURL = 'FabricSupplierChallanDetails.aspx?Debit_Note_ID=' + DebitNote_Id + "&SupplierPoID=" + SupplierPoID + "&ChallanType=" + "SENDQTYCHALLAN" + "&ChallanID=" + challanid + "&FabType=" + Type + "&SendQty=" + sendqty + "&IsNewChallan=" + '';
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
             Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
              // added Code by Bharat on 15-may-20 
             $("#sb-wrapper").removeClass("FourPointCheckLef")
             $("#sb-wrapper-inner").removeClass("FourPointCheck");
               $('#sb-wrapper').removeClass("PurchaseOrder");
             //End
             return false;
         }

         function ShowSupplierChallanScreenSendNEW(DebitNote_Id, SupplierPoID, challanid, Type, sendqty,CanMakeNewChallan) { 
                                         
            if(CanMakeNewChallan == "NO") {
                alert("New Challan Cannot be made unless Previous Challlan get Cleared.");
                return false;
            }
            else {

                 sendqty = (sendqty == "" ? 0 : sendqty);

                 if(parseInt(sendqty) <= 0) {
                    return false;
                 }

                 var h = 570;
                 var w = 910;

                 if (Type == 'Dyed' || Type == 'Printed' || Type == 'RFD' || Type == 'Embellishment' || Type == 'Embroidery') {
                     h = 550;
                     w = 550;
                 }

                 $.ajax({
                     type: "POST",
                     url: "FrmWorkingOnRaisedPO.aspx/StoreSessionValue",
                     data: "{ theValue:'" + SupplierPoID + "'}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (msg) {
                     }
                 });

                var sURL = 'FabricSupplierChallanDetails.aspx?Debit_Note_ID=' + DebitNote_Id + "&SupplierPoID=" + SupplierPoID + "&ChallanType=" + "SENDQTYCHALLAN" + "&ChallanID=" + challanid + "&FabType=" + Type + "&SendQty=" + sendqty + "&IsNewChallan=" + 'NEWCHALLAN';
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                 Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             
                 $("#sb-wrapper").removeClass("FourPointCheckLef")
                 $("#sb-wrapper-inner").removeClass("FourPointCheck");
                 $('#sb-wrapper').removeClass("PurchaseOrder");
             
                 return false;
             }

         }

         function ShowFOCScreen(SupplierPoID,FocId,Type)
         {          

            var sURL = 'FabricSupplierChallanDetails.aspx?SupplierPoID=' + SupplierPoID + "&FocId=" + FocId + "&ChallanType=" + "FOC_CHALLAN" + "&FabType=" + Type + "&IsNewChallan=" + '' ;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             return false;
         }

         function ShowFOCScreen_New(PO_Status,SupplierPoID,FocId,Type,CanMakeNewChallan)
         {
            
            if(CanMakeNewChallan == "NO")
            {
                alert("New Challan Cannot be made unless Previous Challlan get Cleared.");
                return false;
            }

            else if(PO_Status != "0" )
                return false;
                            
            else{
                var sURL = 'FabricSupplierChallanDetails.aspx?SupplierPoID=' + SupplierPoID + "&FocId=" + FocId + "&ChallanType=" + "FOC_CHALLAN" + "&FabType=" + Type + "&IsNewChallan=" + 'NEWCHALLAN';
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 600, width: 750, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            }             
             return false;
         }



         function SBClose() { }

         //        function CallThisPage(postatus) {
         //            //
         //            alert(postatus)                      
         //           // alert(alert("i called !"));
         //            window.parent.Shadowbox.close();
         //            $('.btnshowsrv').click();
         //        }


         function Alert(msg) {
             alert(msg);
         }
         function AlertMsg(msg) {
             alert(msg);
             return false;
         }
         function toggleplusminus(elem, imagesrc) {
             //HighlightRow(classname);
            
             //            alert(elem);
             var rowid = elem.id.split("_")[5];
             // $("#" + elem.id).focus();
             $("#ctl00_cph_main_content_hdnsetfocusid").val(rowid);
             //alert($("ctl00_cph_main_content_hdnsetfocusid").val());

             //                        if (imagesrc == '../../images/plus_icon.gif') {
             //                            $("#ctl00_cph_main_content_grdraisedpoworking_" + rowid + "_" + "lnkminus").css("display", "block");
             //                            $("#ctl00_cph_main_content_grdraisedpoworking_" + rowid + "_" + "lnkplus").css("display", "none");
             //                            
             //                        }
             //                        else if (imagesrc == '../../App_Themes/ikandi/images/minus_icon.gif') {
             //                            $("#ctl00_cph_main_content_grdraisedpoworking_" + rowid + "_" + "lnkplus").css("display", "block");
             //                            $("#ctl00_cph_main_content_grdraisedpoworking_" + rowid + "_" + "lnkminus").css("display", "none");
             //                        }
             var SupplierPO_Id = document.getElementById("ctl00_cph_main_content_grdraisedpoworking_" + rowid + "_" + "hdnSupplierPO_Id").value;
             $.ajax({
                 type: "POST",
                 url: "FrmWorkingOnRaisedPO.aspx/StoreSessionValue",
                 data: "{ theValue:'" + SupplierPO_Id + "',imgurl:'" + imagesrc + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                     //                    window.location.href = 'default2.aspx';
                 }
             });
             //$('.btnshowsrv').click();
         }


         //        $(document).ready(function () {
         //            $(".test").click(function () {
         //                $("#thedialog").attr('src', $(this).attr("href"));
         //                $("#somediv").dialog({
         //                    width: 900,
         //                    height: 600,
         //                    modal: true,
         //                    close: function () {
         //                        $("#thedialog").attr('src', "about:blank");
         //                    }
         //                });
         //                return false;
         //            });
         //        });
         //        function closeIframe() {
         //            $("#thedialog").attr('src', "about:blank");
         //        }

         function Open(obj) {
             // debugger;
             var sURL = obj.href;

             var queries = {};
             $.each(obj.href.substr(1).split('&'), function (c, q) {
                 var i = q.split('=');
                 queries[i[0].toString()] = i[1].toString();
             });

             $.ajax({
                 type: "POST",
                 url: "FrmWorkingOnRaisedPO.aspx/StoreSessionValue",
                 data: "{ theValue:'" + SupplierPO_Id + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                 }
             });

             Shadowbox.init({ animate: true, animateFade: true, modal: true });
             Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 850, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             $("#sb-nav-close").css({ "visibility": "hidden" });
             // added Code by Bharat on 15-may-20 
             $("#sb-wrapper").removeClass("FourPointCheckLef")
             $("#sb-wrapper-inner").removeClass("FourPointCheck");
               $('#sb-wrapper').removeClass("PurchaseOrder");
             //End
             return false;
         }
         function ShowFourPointCheck(srvid, supplierpoid, orderid, OrderDetailID) {
             //debugger;
             // alert();

             var sURL = 'FabricInspectionFourPointCheck.aspx?SrvID=' + srvid + "&SupplierPoID=" + supplierpoid + "&orderid=" + orderid + "&OrderDetailID=" + OrderDetailID;
             //            var win = window.open(sURL, '_blank');
             //            win.focus();


             Shadowbox.init({ animate: true, animateFade: true, modal: true });
             Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 780, width: 1550, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
             // Added code By Bharat on 15-may-20
             $("#sb-wrapper").addClass("FourPointCheckLef")
             $("#sb-wrapper-inner").addClass("FourPointCheck");
              $('#sb-wrapper').removeClass("PurchaseOrder");
             // End
             return false;

         }
         // code added by bharat on 10-june
         function alertmsg() {
             // alert();
             alert('Generate send challan number first')
             return false;

         }
         function fncCancelPO(elem, flag) {
             //alert(flag);
             if (flag == "Close") {
                 var isYes = confirm("Do you want to Closed PO?");
             }
             else if (flag == "Cancel") {
                 var isYes = confirm("Do you want to Cancel PO?");
             }

             var SupplierPO_Id = elem;
             if (isYes == true) {
                 $("#spinner").fadeIn("slow");    
                 proxy.invoke("Cancel_Close_PO", { SupplierPO_Id: SupplierPO_Id, flag: flag }, 
                 function (result) {
                    $("#spinner").fadeOut("slow"); 
                     if (flag == 'Close') {
                         alert('Closed PO has been saved successfully!');
                         $('#<%=btnSearch.ClientID%>').click();
                     }
                     else if (flag == "Cancel") {
                            if(result.toLowerCase() == "Srv Taken. You cannot Cancel PO.".toLowerCase() ) {
                                alert('Srv Taken. You cannot Cancel PO.!!!');
                            }                            
                            else if (result.toLowerCase() == "PO Cancelled Successfully.".toLowerCase() ) {
                                $("#spinner").fadeIn("slow") ;                          
                                proxy.invoke("SendFabricPoMail", { SupplierPO_Id: SupplierPO_Id }, 
                                function (result) {
                                 $("#spinner").fadeOut("slow") ; 
                                 alert('PO has been Cancelled successfully !!');
                                 $('#<%=btnSearch.ClientID%>').click(); 
                                 }, onPageError, false, false);            
                             }        
                     }
                 }, onPageError, false, false);
             }
             else {
               $("#spinner").fadeOut("slow"); 
             }
         }
         //add code by bharat 
         function pageLoad() {
             $('.tooltip').tooltipster({
                 contentAsHTML: true,
                 interactive: true,
                 theme: 'my-custom-theme'
             });
             CreditNote = '<%=this.CreditNote %>';
             // alert("sss");
             if (CreditNote == "") {
                 $('.hises').hide();
             }
             // add code by bharat on 19-aug
             $('.gridviewWidth tr ').click(function (e) {
                 $('.gridviewWidth tr').removeClass('highlighted');
                 $('.gridviewWidth tr').removeClass('Unhighlighted');
                 $(this).addClass('highlighted');
                 //$(this).find('td:gt(1)').addClass('highlighted');
                 //                var spanCount = $(this).find('td:first').attr('rowspan');
                 //                $(this).nextAll().slice(0, spanCount - 1).addClass('highlighted');
             });

             //end
             $("input[type='text']").each(function () {
                 if ($(this).val() == "0") {
                     $(this).val("");
                 }
             })

             if ($("#ctl00_cph_main_content_hdnsetfocusid").val() != "" && $("#ctl00_cph_main_content_hdnsetfocusid").val() != "") {
                 idplus = "ctl00_cph_main_content_grdraisedpoworking_" + $("#ctl00_cph_main_content_hdnsetfocusid").val() + "_lnkplus";
                 idminus = "ctl00_cph_main_content_grdraisedpoworking_" + $("#ctl00_cph_main_content_hdnsetfocusid").val() + "_lnkminus";
                 $("#idplus").addClass('highlighted');
                 $("#idminus").addClass('highlighted');
                 document.getElementById(idplus).focus();
                 document.getElementById(idminus).focus();
             }

         }
         function callhide() {
             $("#ctl00_cph_main_content_hdnsetfocusid").val("");
             $("#ctl00_cph_main_content_hdnsetfocusid").val("");

             if ($("#ctl00_cph_main_content_ddlstatus").val() == "1" || $("#ctl00_cph_main_content_ddlstatus").val() == "1" || $("#ctl00_cph_main_content_ddlstatus").val() == "1") {
                 $('.btnCancel').hide();
                 $('.btnClosePo').hide();


             }


         }
         function Setback(names) {
            // alert('ss');
             $('.' + names).css("background-color", "blue");


         }

         function ShowpurchasedSupplierFormReraise(Fabtype, FabQualityID, SupplierMasterID, MasterPoID, elem, residualshink, cutwastage, gerigeshrinkage, currentstgae, priviousstage, IsStyleSpecfic, styleid, stage1, stage2, stage3, stage4,PO_Number) {
             if (Fabtype == 'Finished') {
                 Fabtype = 'FINISHING';
             }
             else if (Fabtype == 'Printed') {
                 Fabtype = 'PRINT';
             }
             else if (Fabtype == 'Greige') {
                 Fabtype = 'GRIEGE';
             
             }
             var urls = window.location.href;
//             var sURL = 'FabricPurChasedForm.aspx?FabricQualityID=' + FabQualityID + "&Fabtype=" + Fabtype + "&Potype=" + 'RERAISE' + "&ParentPageUrlWithQuerystring=" + "SuPPLIERVIEW" +
//             "&MasterPoID=" + MasterPoID + "&colorprintdetail=" + elem + "&residual=" + residualshink + "&cutwastage=" + cutwastage + "&gerige=" + gerigeshrinkage
//             + "&currentstage=" + currentstgae + "&previousstage=" + priviousstage + "&isStyleSpecific=" + IsStyleSpecfic + "&styleid=" + styleid + "&Stage1=" + stage1 + "&Stage2=" + stage2 + "&Stage3=" + stage3 + "&Stage4=" + stage4;
             //window.open(sURL);  
             var sURL ="../../Uploads/Fits/POFabric_view"+PO_Number+".HTML";

             Shadowbox.init({ animate: true, animateFade: true, modal: true });
             Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "",height: 1000, width: 1500,flashParams: {allowfullscreen:'false'}, options: { onClose: SBClose} });
             $('#sb-wrapper').addClass("PurchaseOrder");
           
             $("#sb-wrapper").removeClass("FourPointCheckLef")
             $("#sb-wrapper-inner").removeClass("FourPointCheck");
                             
            //$("#sb-wrapper-inner").css("width", "20px");
            // alert("sssss");
              //alert(document.getElementById("ctl00_cph_main_content_grdfabricpurchased").offsetWidth + 'X' + document.getElementById("ctl00_cph_main_content_grdfabricpurchased").offsetHeight);
             //End
             return false;
         }
          function Setwidth(width) {
         
          $("#sb-wrapper").css("width",width+"px");
          var left  = parseInt($("#sb-wrapper").css("left").replace("px",""))+40;
//          alert(left)
          $("#sb-wrapper").css("left",left+"px");
                     
         }
         function SBClose() { }
         function CallThisPage(postatus) {

             var currentUrl = window.location.href;
             var url = new URL(currentUrl);
             url.searchParams.set("postatus", postatus); // setting your param
             var newUrl = url.href;

             
            
             window.parent.Shadowbox.close();
             //this.window.location.reload();
//              $('#ctl00_cph_main_content_ddlstatus').val(postatus).attr("selected", "selected");
             $('#ctl00_cph_main_content_btnSearch').click();
             
             
             //location.href = newUrl;
                  
             //            this.window.location.reload(newUrl);
         }
       
        function showpo(elem) {   
        $(".SrNoPopupContent").css('visibility', 'hidden');  
             var Ids = elem.id;              
            var CId = Ids.split("_")[5]         
//              var popup = document.getElementById("ctl00_cph_main_content_grdraisedpoworking_"+CId+"_grdpo");
//              popup.classList.toggle("SrNoShow");
              $("#ctl00_cph_main_content_grdraisedpoworking_"+CId+"_grdpo").css('visibility', 'visible');  
         }
         function closepop(elem)
                  {
           $(".SrNoPopupContent").css('visibility', 'hidden');
          
         }
         
         $(document).ready(function(){
         // alert();
          BottomBorder();
         });
         function BottomBorder(){
//         alert();
        
             var maxRowColSt = 0;
            var rowSpanColSt = 0;
            $('.PendingSummaryTable td[rowspan].TadNameWidth').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRowColSt) {
                    maxRowColSt = row;
                    rowSpanColSt = 0;
                }
                if ($(this).attr('rowspan') > rowSpanColSt) rowSpanColSt = $(this).attr('rowspan');
            });
            if (maxRowColSt == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpanColSt - 1)) {
                $('.PendingSummaryTable td[rowspan].TadNameWidth').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRowColSt && $(this).attr('rowspan') == rowSpanColSt) $(this).addClass('border_bottom_color');
                });
            }
       }

        //below created by Girish on 2023-04-28
        function pageLoad(sender, args) {

            if($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 1)
            {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Fabric Quality");
            }   
            else if($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 2)
            {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By ColorPrint");
            } 
            else if($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 3)
            {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Supplier");
            } 
            else if($("#ctl00_cph_main_content_ddlSearchOption option:selected").val() == 4)
            {
                $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By PO_Number");
            } 

            var autoCompleteOptions = {
                    dataType: "xml",
                    datakey: "string",
                    max: 100,
                    width: "300px",
                    cacheLength: 0,
                    extraParams: {
                        DropDownType: $("#ctl00_cph_main_content_ddlSearchOption option:selected").val(),
                        POStatus: $("#ctl00_cph_main_content_ddlstatus option:selected").val(),
                        Type:"Fabric"
                    }
                };

                $("input[type=text].Suggestion").autocomplete("/Webservices/iKandiService.asmx/GetAutoPopulateResult", autoCompleteOptions);

                $("#ctl00_cph_main_content_ddlSearchOption").change(function() {

                    autoCompleteOptions.extraParams.DropDownType = $(this).val();

//                    $('#ctl00_cph_main_content_txtsearchkeyswords').val('');         
                
                    if($(this).val() == 1)
                    {
                        $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Fabric Quality");
                    }   
                    else if($(this).val() == 2)
                    {
                        $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By ColorPrint");
                    } 
                    else if($(this).val() == 3)
                    {
                        $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By Supplier");
                    } 
                    else if($(this).val() == 4)
                    {
                        $('#ctl00_cph_main_content_txtsearchkeyswords').attr("placeholder", "Search By PO_Number");
                    }  
                });

                $("#ctl00_cph_main_content_ddlstatus").change(function() {

                    autoCompleteOptions.extraParams.POStatus = $(this).val();   
                                  
                });                 
        }    


    </script>
    <asp:HiddenField ID="hdnsetfocusid" runat="server" />
    <input type="hidden" id="div_position" name="div_position" />
    <div id="somediv" title="this is a dialog" style="display: none;">
        <iframe id="thedialog" width="900" height="600"></iframe>
    </div>
    <asp:ScriptManager ID="srptmng" runat="server" AsyncPostBackTimeout="300">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="upnl"
        DisplayAfter="0">
        <ProgressTemplate>
            <%--<img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />--%>
            <div id="spinner" class="fade-in">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="headerSticky">
        <span id="lnkPendingOrderSuppary" runat="server" style="position: absolute; left: 10px;
            top: 0px;" class="btnlinkPe"><a href="PendingOrderSummary.aspx" target="_blank">Pending
                Order Summary</a></span><span id="lnkSupplierQuotation" runat="server" style="position: absolute;
                    left: 170px; top: 0px;" class="btnlinkPe"><a href="../SupplierQuotationScreen.aspx?SupplyType=1"
                        target="_blank">Supplier Quoted</a></span><span id="lnkRaisePo" runat="server" style="position: absolute;
                            left: 280px; top: 0px;" class="btnlinkPe"><a href="FabricViewAll.aspx" target="_blank">
                                Raise PO</a> </span>Manage Fabric Purchase Order <span style="font-size: 12px;">(SRV,
                                    QC, Debit, Credit, Challan)</span>
    </div>
    <asp:UpdatePanel ID="upnl" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="topcontrols" style="width: 100%; position: sticky; top: 23px; background: #fff;
                z-index: 3; padding: 5px 0px;">
                <asp:DropDownList ID="ddlSearchOption" runat="server" style="padding:3px 0;">
                    <asp:ListItem Value="1">Fabric Quality</asp:ListItem>
                    <asp:ListItem Value="2">Color Print</asp:ListItem>
                    <asp:ListItem Value="3">Supplier Name</asp:ListItem>
                    <asp:ListItem Value="4">PO Number</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtsearchkeyswords" class="Suggestion" 
                    runat="server" Style="width: 300px !important; margin: 0px 0px 1px; padding-left: 4px;
                    text-align: left; text-transform: inherit;"></asp:TextBox>
                status
                <asp:DropDownList onchange="resetquerystring()" ID="ddlstatus" runat="server">
                    <asp:ListItem Value="-1">All</asp:ListItem>
                    <asp:ListItem Selected="True" Value="0">Open</asp:ListItem>
                    <asp:ListItem Value="1">Cancel</asp:ListItem>
                    <asp:ListItem Value="2">Closed</asp:ListItem>
                    <%--<asp:ListItem Value="10" disabled title='this option soon will be enable '>Archive</asp:ListItem>--%>
                    <%--<asp:ListItem Value="5">Cancel & Closed</asp:ListItem>--%>
                </asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" CssClass="go do-not-disable" Text="Search"
                    OnClick="btnSearch_Click" Style="padding: 2px 7px;" />
                <div id="close" style="width: 55px !important; position: relative; display: inline-block;
                    padding: 3px 0px;">
                    <span style="width: 12px; height: 12px; background-color: #ffc9c6; float: left; border-radius: 50%;
                        border: 1px solid gray;"></span>&nbsp;<sapn style="color: gray; position: relative;
                            top: 0px; left: -1px">Close </sapn>
                </div>
                <div id="Cancel" style="width: 65px; display: inline-block; padding: 3px 0px;">
                    <span style="width: 12px; height: 12px; background-color: #fbcba2; float: left; border-radius: 50%;
                        border: 1px solid gray;"></span>&nbsp;
                    <sapn style="color: gray; position: relative; top: 0px; left: -4px">Cancel </sapn>
                </div>
            </div>
            <table cellspacing="0" rules="all" border="1" id="ctl00_cph_main_content_grdraisedpoworking"
                style="border-width: 1px; border-style: solid; border-collapse: collapse; border-bottom: 0px;
                margin-top: 5px; display: none; background-color: White;">
                <tbody>
                    <%-- <tr class="HeaderClass">
                        <td align="center" colspan="21" style="font-size: 12px; font-weight: 500; height: 33px;
                            border-bottom-color: #999;">
                            <span style="position: absolute; left: 10px; top: 27px;" class="btnlink"><a href="PendingOrderSummary.aspx"
                                target="_blank">Pending Order Summary</a></span><span style="position: absolute;
                                    left: 170px; top: 27px;" class="btnlink"><a href="GreigeFabricSupplierGroup.aspx"
                                        target="_blank">Supplier Quoted</a></span><span style="position: absolute; left: 280px;
                                            top: 27px;" class="btnlink"><a href="FabricView.aspx" target="_blank">Raise PO</a>
                                        </span>Working On Raised POs (Entry,QC Control And Debits)
                        </td>
                    </tr>--%>
                    <tr class="HeaderClass">
                        <td align="center" class="TadNameWidth" style="text-align: center; background: #dddfe4 !important;">
                            Fabric Quality, (GSM), C&C, Width,<br />
                            Color/Print
                        </td>
                        <td align="center" class="PlusWidth">
                        </td>
                        <td align="center">
                            Supplier PO
                            <br />
                            (units)
                            <asp:ImageButton ID="imgpsupplierponumberaccnding" Style="display: none;" src="../../App_Themes/ikandi/images/arrow_down.png"
                                OnClick="imgpsupplierponumber_Click" runat="server" CommandName="sort" CommandArgument="acc" />
                            <asp:ImageButton ID="imgpsupplierponumberdecnding" Style="display: none;" src="../../App_Themes/ikandi/images/arrow_down.png"
                                OnClick="imgpsupplierponumber_Click" CommandName="sort" runat="server" CommandArgument="desc" />
                        </td>
                        <td align="center" class="TypeWidth">
                            Type
                        </td>
                        <td align="center">
                            Supplier Name
                        </td>
                        <td align="center" class="DateWidth">
                            Placed On Date
                        </td>
                        <td align="center" class="DateWidth">
                            Cmitd. Start Date
                        </td>
                        <td align="center" class="DateWidth">
                            Cmitd. End Date
                        </td>
                        <td align="center">
                            Send Challan No.
                        </td>
                        <td align="center">
                            Unit (Gate No.)
                        </td>
                        <td align="center" class="ChallanWidth">
                            SRV No.
                        </td>
                        <td align="center" class="ColunWidth">
                            Overall Balance Qty
                            <br>
                            (Based on PO)
                        </td>
                        <td align="center" class="ColunWidthTotalqty">
                            Total PO Qty.
                        </td>
                        <td align="center" class="ColunWidth">
                            Total Qty. Rcvd.
                        </td>
                        <td align="center" class="ColunWidth">
                            Send Qty.
                        </td>
                        <td align="center" class="ColunWidth">
                            SRV Rcvd. Qty.
                        </td>
                        <td align="center" class="ColunWidth">
                            Checked Qty.
                        </td>
                        <td align="center" class="ColunWidth">
                            Pass Qty.
                        </td>
                        <td align="center" class="ColunWidth">
                            On Hold Qty.
                        </td>
                        <td align="center" class="ColunWidth">
                            Fail Qty.
                        </td>
                        <td align="center">
                            Debit Value
                        </td>
                        <td class=" ColunWidthCredit" align="center">
                            credit note
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="widthdiv" runat="server" style="min-width: 1500px;">
                <asp:GridView ID="grdraisedpoworking" AllowSorting="True" runat="server" AutoGenerateColumns="False"
                    ShowHeader="true" ShowHeaderWhenEmpty="True" HeaderStyle-Font-Names="Arial" OnRowCommand="grdraisedpoworking_OnRowCommand"
                    HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" OnRowDataBound="grdraisedpoworking_RowDataBound"
                    HeaderStyle-CssClass="ths" CssClass="gridviewWidth headertopfixed PendingSummaryTable"
                    Style="border-bottom: 0px; width: 100%;">
                    <HeaderStyle CssClass="ths" Font-Names="Arial" HorizontalAlign="Center" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" />
                    <SelectedRowStyle BackColor="#A1DCF2" />
                    <Columns>
                        <asp:TemplateField HeaderText="Fabric Quality (GSM) C&C Width<br /> Color/Print">
                            <ItemStyle HorizontalAlign="Center" CssClass="TadNameWidth" Width="141px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblfab" Text='<%# Eval("TradeNames")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="collapse">
                            <ItemStyle HorizontalAlign="Center" CssClass="PlusWidth" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="margin: 0 auto;">
                                    <tr>
                                        <td style="min-width: 38px !important; border: 0px;">
                                            <asp:LinkButton ID="lnkplus" CommandName="Plus" OnClientClick="toggleplusminus(this,'../../images/plus-w.png')"
                                                CssClass="plusshow" Text="<img title='collapse' src='../../images/plus-w.png'  style='width:15px'/>"
                                                runat="server"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkminus" Style="display: none" CommandName="Minus" OnClientClick="toggleplusminus(this,'../../images/minus.png')"
                                                CssClass="plusshow" Text="<img title='collapse' src='../../images/minus.png' style='width:18px' />"
                                                runat="server"></asp:LinkButton><nobar></nobar>
                                        </td>
                                        <td style="min-width: 30px !important; border: 0px;" runat="server" id="tdnewsrv">
                                            <%--<a onclick='<%# "ShowSrvbySupplierID(" +Eval("SupplierPO_Id") + " );" %>' title="Generate new srv" id="anopensrv" runat="server"
                                            class="test" >
                                            <img src="../../images/edit.png" />
                                        </a>--%>
                                        </td>
                                        <td style="border-right: 0px; position: relative;">
                                            <div class="SrNumberPopup">
                                                <asp:GridView ID="grdpo" ShowHeader="true" runat="server" AutoGenerateColumns="False"
                                                    EmptyDataText="No Record Found!" CssClass="SrNoPopupContent" HeaderStyle-Font-Names="Arial"
                                                    HeaderStyle-HorizontalAlign="Center" BorderWidth="0" rules="all" HeaderStyle-CssClass="ths">
                                                    <SelectedRowStyle BackColor="#A1DCF2" />
                                                    <AlternatingRowStyle BackColor="#dedede" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Serial Number <span style="float: right; right: 5px; position: absolute;"><a onclick="closepop(this)">
                                                                    X</a></span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStyleNumber" Style="text-align: center" Text='<%# Eval("SerialNumber")%>'
                                                                    runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="borderDy" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdnMasterIDPo" runat="server" Value='<%# Eval("MasterPO_Id")%>' />
                                <asp:HiddenField ID="hdnSupplierPO_Id" runat="server" Value='<%# Eval("SupplierPO_Id")%>' />
                                <asp:HiddenField ID="hdndefualtunit" runat="server" Value='<%# Eval("defualtunit")%>' />
                                <asp:HiddenField ID="hdnConvertToUnit" runat="server" Value='<%# Eval("ConvertToUnit")%>' />
                                <asp:HiddenField ID="hdnconversionvalue" runat="server" Value='<%# Eval("ConversionValue")%>' />
                                <asp:HiddenField ID="hdnActualSendQty" runat="server" Value='<%# Eval("ActualSendQty")%>' />
                                <%--<a id="anopensrv" title="" href="javascript:void(0)" onclick='ShowSrvbySupplierID(<%# Eval("SupplierPO_Id") %>)'>
                        <img src="../../images/edit.png" />
                    </a>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier PO <br/> (units)">
                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="margin: 0 auto;">
                                    <tr>
                                        <td style="min-width: 38px !important; border-left: 0px; border: 0px">
                                            <asp:Label ID="lblponumber" ForeColor="blue" Text='<%# (Eval("PO_Number") == DBNull.Value  || (Eval("PO_Number").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PO_Number").ToString().Trim() %>'
                                                runat="server" Style="display: none;"></asp:Label>
                                            <a href="javascript:void(0)" onclick="ShowpurchasedSupplierFormReraise('<%# Eval("FabricTypes") %>','<%# Eval("Fabric_Quality_DetailsID") %>', '<%# Eval("supplier_master_Id") %>', '<%# Eval("MasterPO_Id") %>', '<%# Eval("FabricDetails") %>', '<%# Eval("Residual") %>', '<%# Eval("CuttingWastage") %>', '<%# Eval("GreigedShrinkage") %>', '<%# Eval("CuurentStage") %>', '<%# Eval("PreviousStage") %>', '<%# Eval("IsStyleSpecific") %>', '<%# Eval("StyleID") %>', '<%# Eval("stage1") %>', '<%# Eval("stage2") %>', '<%# Eval("stage3") %>', '<%# Eval("stage4") %>' , '<%# Eval("PO_Number") %>')"
                                                title="view po form">
                                                <%# Eval("PO_Number").ToString() %></a></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="min-width: 30px !important; border: 0px; position: relative">
                                            (<asp:Label ID="lblunits" Font-Bold="true" class="tooltip" runat="server"></asp:Label>)
                                            <asp:Label ID="lblbiplsign" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnIsAuthorizedSignatory" runat="server" Value='<%# Eval("IsAuthorizedSignatory")%>' />
                                            <asp:Label ID="lblsuppliersign" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnIsPartySignature" runat="server" Value='<%# Eval("IsPartySignature")%>' />
                                            <asp:HyperLink ID="hplk" runat="server" ToolTip="View po" Style="cursor: pointer;
                                                position: absolute; right: -20px; top: -10px;" onclick="showpo(this)" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif"
                                                Target="_blank"></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                            <td style="min-width: 30px !important; border: 0px;">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="min-width: 30px !important; border: 0px;position:relative">
                                                
                                            </td>

                                        </tr>--%>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblfabrictype" Text='<%# (Eval("FabricTypes") == DBNull.Value  || (Eval("FabricTypes").ToString().Trim() == string.Empty)) ? string.Empty : Eval("FabricTypes").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdncurrentstage" runat="server" Value='<%# Eval("CuurentStage")%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="TypeWidth" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier Name">
                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblSupplierName" Text='<%# (Eval("SupplierName") == DBNull.Value  || (Eval("SupplierName").ToString().Trim() == string.Empty)) ? string.Empty : Eval("SupplierName").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Placed On Date">
                            <ItemStyle HorizontalAlign="Center" CssClass="DateWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblplacedon" ForeColor="#000" Text='<%# (Eval("PlacedOnDate") == DBNull.Value  || (Eval("PlacedOnDate").ToString().Trim() == string.Empty)) ? string.Empty : Eval("PlacedOnDate").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Cmitd. Start Date">
                            <ItemStyle HorizontalAlign="Center" CssClass="DateWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblcommtdstartdate" ForeColor="#000" Text='<%# (Eval("CommtedStartDate") == DBNull.Value  || (Eval("CommtedStartDate").ToString().Trim() == string.Empty)) ? string.Empty : Eval("CommtedStartDate").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Cmitd. End Date">
                            <ItemStyle HorizontalAlign="Center" CssClass="DateWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblcommtdEnddate" ForeColor="#000" Text='<%# (Eval("CommtedENDDate") == DBNull.Value  || (Eval("CommtedENDDate").ToString().Trim() == string.Empty)) ? string.Empty : Eval("CommtedENDDate").ToString().Trim() %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Send Challan No.">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblsendchallanno" runat="server"></asp:Label>
                                <%--<asp:TextBox ReadOnly="true" ID="txtsendchallanno" runat="server" Style="font-size: 11px;
                                cursor: pointer; color: blue; width: 71% !important;"></asp:TextBox>--%>
                                <%--  <a  style="float:right;vertical-align:middle;"  ID="imgbtnsendchallan" title="Create new send challan number"  runat="server"
                                            class="test" >
                                            <img src="../../images/edit.png" />
                                        </a>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Foc Challan">
                            <ItemStyle HorizontalAlign="left" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblsendfoc" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit (Gate)">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblunitgatenumber" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SRV No.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ChallanWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblchallennumber" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Overall Balance Qty   </br> (Based on) PO">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblbalanceQty" ForeColor="#d59013" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Po Qty.">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" class="PoQtyTable" style="width: 100%">
                                    <tr>
                                        <td class="QtyWi" style="border: 0px; min-width: 30px !important; max-width: 30px !important">
                                            <asp:Label ID="lblTotalpoQty" Text='<%# (Eval("TotalPoQty") == DBNull.Value  || (Eval("TotalPoQty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("TotalPoQty")).ToString("N0") %>'
                                                runat="server" Style="float: left; padding-left: 2px;"></asp:Label>
                                        </td>
                                        <td style="text-align: center; border: 0px; min-width: 30px !important" class="bottonTD">
                                            <a style="font-size: 11px; cursor: pointer; color: blue; <%# "display :" + Eval("HideCancel").ToString() %>;"
                                                class="test btnCancel" title="Cancel" onclick="fncCancelPO(<%# Eval("SupplierPO_Id") %>,'Cancel')">
                                                Cancel</a>
                                            <%--<a style="font-size: 11px; cursor: pointer; <%# "display :" + Eval("HideClose").ToString() %>;
                                                color: blue;" class="test btnClosePo" title="Close" onclick="fncCancelPO(<%# Eval("SupplierPO_Id") %>,'Close')">
                                                Close</a>--%>
                                            <asp:Label ID="lblstats" Text='<%# Eval("postatus")%>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Qty. Rcvd.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbltotalqtyreceived" Text='<%# (Eval("TotalQtyRcvd") == DBNull.Value  || (Eval("TotalQtyRcvd").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("TotalQtyRcvd")).ToString("N0") %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="send Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblsendQty" ForeColor="black" Font-Bold="true" Text='<%# (Eval("SendQty") == DBNull.Value  || (Eval("SendQty").ToString().Trim() == string.Empty)) ? string.Empty : Convert.ToDecimal(Eval("SendQty")).ToString("N0") %>'
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnchallanmeter" runat="server" Value='<%# Eval("ChallanmeterQty")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SRV Qty. Rcvd.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblreceiveqty" Font-Bold="true" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Checked Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblcheckedqty" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pass Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="On Hold Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblOnHoldqty" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fail Qty.">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidth" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblfailqty" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Raise Debit <span style='text-transform: lowercase;'>And</span> SRV">
                            <ItemStyle HorizontalAlign="Center" CssClass="challsnDebitBorder" Width="140px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%--   <asp:Label ID="lbldebitvalue" runat="server"></asp:Label>--%>
                                <%--   <table>
                          <tr runat="server" id="tdsrv">
                          <td >
                             <a onclick='<%# "ShowSrvbySupplierID(" +Eval("SupplierPO_Id") + " );" %>' title="Generate new srv" id="anopensrv" runat="server"
                                            class="test" >
                                            <img src="../../images/edit.png" />
                                   </a>
                          </td>
                          </tr>
                         </table>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Raise credit note">
                            <ItemStyle HorizontalAlign="Center" CssClass="ColunWidthCredit" Width="140px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%--   <asp:Label ID="lbldebitvalue" runat="server"></asp:Label>--%>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
                                    <tr runat="server" id="tdsrv">
                                        <td class="ColunWidthCredit" style="border: 0px;">
                                            <a style="margin-right: 5px; cursor: pointer; <%# "display :" + Eval("IsVisibleCreditNote").ToString() %>;"
                                                onclick='<%# "showcreditnote(" +Eval("SupplierPO_Id") + " );" %>' class="test">
                                                <img src="../../images/edit.png" />
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" class="GSTTAbleEmp" cellspacing="0" style="width: 1649px;
                            border-top: 0px solid !important;">
                            <tr class="ths" align="center" style="font-family: Arial;">
                                <th align="center" scope="col">
                                    Fabric Quality (GSM) C&amp;C Width<br>
                                    Color/Print
                                </th>
                                <th class="ColunWidth" align="center" scope="col">
                                    &nbsp;
                                </th>
                                <th align="center" scope="col">
                                    Supplier PO
                                    <br>
                                    (units)
                                </th>
                                <th align="center" scope="col">
                                    Type
                                </th>
                                <th align="center" scope="col">
                                    Supplier Name
                                </th>
                                <th align="center" scope="col">
                                    Placed On Date
                                </th>
                                <th align="center" scope="col">
                                    Cmitd. Start Date
                                </th>
                                <th align="center" scope="col">
                                    Cmitd. End Date
                                </th>
                                <th align="center" scope="col">
                                    Send Challan No.
                                </th>
                                <th align="center" scope="col">
                                    Unit (Gate)
                                </th>
                                <th align="center" scope="col">
                                    SRV No.
                                </th>
                                <th align="center" scope="col">
                                    Balance Qty.
                                </th>
                                <th align="center" scope="col">
                                    Total Po Qty.
                                </th>
                                <th align="center" scope="col">
                                    Total Qty. Rcvd.
                                </th>
                                <th align="center" scope="col">
                                    send Qty.
                                </th>
                                <th align="center" scope="col">
                                    SRV Qty. Rcvd.
                                </th>
                                <th align="center" scope="col">
                                    Checked Qty.
                                </th>
                                <th align="center" scope="col">
                                    Pass Qty.
                                </th>
                                <th align="center" scope="col">
                                    On Hold Qty.
                                </th>
                                <th align="center" scope="col">
                                    Fail Qty.
                                </th>
                                <th align="center" scope="col">
                                    Raise Debit <span style="text-transform: lowercase;">And</span> SRV
                                </th>
                                <th align="center" scope="col">
                                    Raise credit note
                                </th>
                            </tr>
                            <tr>
                                <td style="text-align: center; border: 1px solid #999" colspan="22">
                                    <img src='../../images/sorry.png' alt='No record found' />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnshow" runat="server" Style="display: none;" CssClass="btnshowsrv"
        OnClick="btnshow_Click" />
    <asp:Button ID="btnPrint" runat="server" OnClientClick="PrintWindow();" Text="Print"
        CssClass="printButtonHide print da_submit_button" />
</asp:Content>
