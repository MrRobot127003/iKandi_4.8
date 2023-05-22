<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CostingFormNew.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.CostingFormNew" %>
<style type="text/css">
    body
    {
        background: #f9f9fa none repeat scroll 0 0;
        font-family: verdana;
    }
    table
    { 
        font-family: verdana;
        border-color: gray;
        border-collapse: collapse;
    }
    th
    {
        background: #dddfe4 !important; 
        color: #575759 !important;
        font-family: arial,halvetica !important;
        font-size: 10px !important;
        font-weight: normal !important;
        padding: 5px 0px !important;
    }
    table td
    {
        font-size: 10px;
        text-align: center;
        border-color: #aaa;
    }
    .per
    {
        color: blue;
        width:70%;
    }
  
    .chkwidth input
    {
        width: 15px !important;
        position:relative;
        top:2px;
    }
    
    .per-new
    {
        color: seagreen;
        font-size: 11px;
    }
    .gray
    {
        color: gray !important;
    }
    h2
    {
        background: #39589C;
        font-size: 14px;
        font-weight: normal;
        height: 24PX;
        margin: 5px 0px;
        width: 84%;
        text-align: center;
        color: white;
        font-weight: bold;
    }
    .row-fir th
    {
        font-weight: bold;
        font-size: 11px;
    }
    table td table td
    {
        border-color: #ddd;
    }
    .blue1
    {
        color: gray;
    }
    h3
    {
        font-size: 12px;
        padding: 0px;
        margin: 0px;
        font-weight: normal;
        color: #575759;
    }
    input
    {
        width: 79%;
        text-align: center;
    }
    .file
    {
        width: 126px;
        text-align: center;
    }
    .financial
    {
        vertical-align: top;
    }
    .financial td
    {
        padding: 4px;
        text-align: left;
    }
    .alin
    {
        text-align: left;
        padding: 3px 1px;
    }  
    .alin
    {
        text-align: left;
        padding: 3px 1px;
    }
    #tabs_costing
    {
        position: relative;
        text-transform: uppercase;
        z-index: 9999999;
    }
    
    #tabs_costing ul
    {
        list-style: outside none none;
        margin: 0;
        padding: 0;
    }
    #tabs_costing li
    {
        display: inline;
        float: left;
        position: relative;
    }
    #tabs_costing li div
    {
        border: 1px solid #292929;
        display: block;
        float: left;
        height: 14px;
        padding: 3px 18px 0;
        vertical-align: middle;
    }
    #tabs_costing li span
    {
        border: 1px solid #292929;
        color: #282828;
        display: block;
        float: left;
        font-family: Arial;
        font-size: 10px;
        font-weight: bold;
        height: 14px;
        padding: 3px 10px 0;
        vertical-align: middle;
    }
    #tabs_costing li a
    {
        color: #282828;
        font-family: Arial;
        font-size: 10px;
        font-weight: bold;
        height: 14px;
        text-decoration: none;
        vertical-align: super;
    }
    .compare-style
    {
        list-style: none;
        text-align: left;
        margin: 0px;
        padding: 0px;
    }
    .compare-style li
    {
        float: left;
        width: auto;
        font-size: 12px;
    }
    .compare-style li input
    {
        width: auto;
    }
    .file-upload
    {
        width: 20px;
        height: 20px;
        margin-right: 100px;
        opacity: 0;
        filter: alpha(opacity=0); /* IE 5-7 */
    }
    .select-wrapper
    {
        background: url(../8-jul-16/browse-file.png) no-repeat;
        background-size: cover;
        display: block;
        position: relative;
        width: 25px;
        height: 25px;
    }
    .width
    {
        color: gray;
    }
    .width1
    {
        font-size: 12px;
        color: #000;
    }
    .green-light
    {
        color: #699c00;
    }
    .light-gray
    {
        color: #939393;
    }
    .style20
    {
    font-size: 10px;
    width: 70px;
    margin: 5px auto;
    }
    .style21
    {
        font-size: 10px;
        display: none;
    }
    
    .costing-print-table
    {
        vertical-align: top !important;
    }
    .do-not-allow-typing
    {
        border: none !important;
        background-color: #f2f2f2 !important;
    }
     .NoBorder
    {
        border: none !important;
        background-color: #f2f2f2 !important;
    }
    .text_align_right
    {
        text-align: right;
        padding-right: 2px;
    }
    .textbox-as-label
    {
        border: none !important;
        background-color: #f2f2f2 ;
    }
    .InvalidAcc
    {
        background-color: Yellow !important;
    }
    .per-new
    {
        color: seagreen;
        font-size: 11px;
    }
    .view-image img
    {
        vertical-align: middle;
        width:12px;
    }
    .content
    {
        /* overflow-x: hidden !important;
        overflow-y: hidden !important; */
    }
    .content .body
    {
        width: 700px;
        height: 500px;
    }
    #facebox
    {
        top: 20% !important;
        left: 30% !important;
        /*top: 30px !important;
        left: 400px !important;*/
    }
     #facebox .body .content
    {
        overflow: hidden auto !important;
    }
     #facebox .form_heading
    {
       color:#fff !important;
    }
     #facebox  table
    {
        width:100% !important;
        font-size:11px !important;
     }
     #facebox .body {
    padding: 0px;
  
     }
       #facebox  table td span
       {
            font-size:11px !important;
         }
      .divReportAllOrdersPopup {
            overflow: auto;
            max-height: 500px;
        }
        #dvBIPLOrderPrice td
        {
            text-transform:capitalize !important;
          }
    .penny
    {
        text-transform: uppercase;
    }
    .lightbg1 input[type="text"]
    {
        width: 94% !important;
        font-size: 10px !important;
    }
    .ikandi_price
    {
        font-size: 11px !important;
    }
    input[type="checkbox"], input[type="submit"], select
    {
        cursor: pointer;
    }
    input[type="text"], select
    {
        background-color: #f2f2f2;
        border-color: #dddfe4;
       
    }
    input[type="text"], textarea
    {
        text-transform: capitalize !important;
    }
    input[type="radio" ]
    {
        width: auto !important;
    }
    .form_box
    {
        text-transform: capitalize !important;
        border:none;
    }
    .form_heading
    {
        text-align: center;
        font-size: 16px;
        /*margin-top: 5px;*/
        padding-bottom: 5px;
       /* border-bottom: 7px solid #1687d5;*/
        color: #1687d5;
    }
    .shoamt input
    {
        width: 20px !important;
        vertical-align: middle;
    }
    .changed_value
    {
        color: Red;
        text-align: center;
        width: 100%;
        font-size: 9px;
        text-transform: lowercase;
    }
    .tooltip
    {
        position: relative;
        display: inline-block;
       
    }    
    .tooltip .tooltiptext
    {
        visibility: hidden;
        width: 50px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        bottom: 125%;
        left: 50%;
        margin-left: -30px;
        border: 1px solid #999;
        transition: opacity 0.3s;
         display:block;
    }
    
    .tooltip .tooltiptext::after
    {
        content: "";
        position: absolute;
        top: 100%;
        left: 50%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: #999 transparent transparent transparent;
    }
    
    .tooltip:hover .tooltiptext
    {
        visibility: visible;
        opacity: 1;
    }  
   
   /* tool tip for Rate calculation formula */
      .tooltipRate {
        position: relative;
        display: inline-block;
    }

        .tooltipRate .tooltiptextRate {
            visibility: hidden;
            position: absolute;
            z-index: 90;            
            left: 30px;                  
            min-width: 400px;
            min-height: 150px;
            line-height: 12px;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            border-radius: 10px;
            box-shadow: 20px 17px 20px 7px #555;                          
            background-color: #555;
            color: white;
            text-align: justify;
            padding: 5px 5px;      
                    
           
        }

           /* .tooltipRate .tooltiptextRate::after {
                content: "";
                position: absolute;
                top: 0px;
                left: -16px;
                margin-left: -5px;
                border-width: 11px;
                border-style: solid;
                border-color: transparent #A5E5FF transparent transparent;
            }*/

        .tooltipRate:hover .tooltiptextRate {
            visibility: visible;
              opacity: 1;
        }
        
        
    .tooltip .tooltiptextAccessory
    {
        visibility: hidden;
        width: 40px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 0px 0px;
        position: absolute;
        z-index: 1;
        bottom: 36%;
        left: 50%;
        margin-left: -23px;
        border: 1px solid #999;
        transition: opacity 0.3s;
    }
    
    .tooltip .tooltiptextAccessory::after
    {
        content: "";
        position: absolute;
        top: 100%;
        left: 50%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: #999 transparent transparent transparent;
    }
    
    .tooltip:hover .tooltiptextAccessory
    {
        visibility: visible;
        opacity: 1;
    }
    .tooltip .tooltiptextFabricavrage
    {
        visibility: hidden;
        width: 40px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        bottom: -183%;
        left: 85%;
        margin-left: -30px;
        transition: opacity 0.3s;
        border: 1px solid #999;
    }
    
    .tooltip .tooltiptextFabricavrage::after
    {
        content: "";
        position: absolute;
        top: -50%;
        right: 45%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent transparent #999 transparent;
    }
    
    .tooltip:hover .tooltiptextFabricavrage
    {
        visibility: visible;
        opacity: 1;
    }
    .tooltip .tooltiptextFabric
    {
        visibility: hidden;
        width: 120px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        bottom: 40%;
        left: 50%;
        margin-left: 10px;
        transition: opacity 0.3s;
        border: 1px solid #999;
    }
    
    .tooltip .tooltiptextFabric::after
    {
        content: "";
        position: absolute;
        top: 40%;
        right: 100%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent #999 transparent transparent;
    }
    
    .tooltip:hover .tooltiptextFabric
    {
        visibility: visible;
        opacity: 1;
    }
    .tooltip .tooltiptextRightShort
    {
        visibility: hidden;
        width: 40px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        bottom: 40%;
        left: 50%;
        margin-left: 10px;
        transition: opacity 0.3s;
        border: 1px solid #999;
    }
    
    .tooltip .tooltiptextRightShort::after
    {
        content: "";
        position: absolute;
        top: 40%;
        right: 100%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent #999 transparent transparent;
    }
    
    .tooltip:hover .tooltiptextRightShort
    {
        visibility: visible;
        opacity: 1;
    }
    .tooltip .tooltiptextF
    {
        visibility: hidden;
        width: 40px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        bottom: -20%;
        left: 50%;
        margin-left: -65px;
        transition: opacity 0.3s;
        border: 1px solid #999;
    }
    .tooltip .tooltiptextF::after
    {
        content: "";
        position: absolute;
        top: 35%;
        right: -23%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent transparent transparent #999;
    }    
    .tooltip:hover .tooltiptextF
    {
        visibility: visible;
        opacity: 1;
    }
    .changed_valueNew
    {
        color: Red;
        text-align: center;
        width: 100%;
        font-size: 9px;
        text-transform: lowercase;
        height: 10px;
        width: 10px;
        border-radius: 50%;
        background-color: #f9d110;
        display: inline-block;
      
    }
    .Valtooltip
    {
       position: relative;
      display: inline-block;
      
     }
     .Valtooltip:hover .AvlueAddtextFabricavrage
    {
        visibility: visible;
        opacity: 1;
    }
    .Valtooltip .AvlueAddtextFabricavrage
    {
        visibility: hidden;
        width: 170px;
        background-color: yellow;
        color: red;
        text-align: center;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        bottom: 123%;
        left: 53%;
        margin-left: -40px;
        transition: opacity 0.3s;
        border: 1px solid #999;
    }
    .Valtooltip .AvlueAddtextFabricavrage::after
    {
        content: "";
        position: absolute;
        top: 100%;
         left: 35%;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: #999 transparent transparent transparent;
    }
     
   .changed_ValueAdd
    {
        color: Red;
        text-align: center;
        width: 100%;
        font-size: 9px;
        text-transform: lowercase;
        height: 10px;
        width: 10px;
        border-radius: 50%;
        background-color: #f9d110;
        display: inline-block;
        margin: 1px 0px;
    }
    
    .DeleteFabrictooltip
    {
       position: relative;
      display: inline-block;
      
     }
     .DeleteFabrictooltip:hover .DeleteFabricName
    {
        visibility: visible;
        opacity: 1;
    }
    .DeleteFabrictooltip .DeleteFabricName
    {
        visibility: hidden;
        width: 328px;
        background-color: yellow;
        color: red;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        top: 123%;
        left: 53%;
        margin-left: -65px;
        transition: opacity 0.3s;
        border: 1px solid #999;
    }
    .DeleteFabrictooltip .DeleteFabricName::before
    {
        content: "";
        position: absolute;
        top: -11px;
        left: 64px;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color:  transparent transparent #999 transparent;
    }
     
   .Change_DeleteFabricName
    {
        color: Red;
        text-align: left;
        width: 100%;
        font-size: 9px;
        text-transform: lowercase;
        height: 10px;
        width: 10px;
        border-radius: 50%;
        background-color: #f9d110;
        display: inline-block;
        margin: 1px 0px;
    }
    
    .DeleteAccessorytooltip
    {
       position: relative;
      display: inline-block;
      
     }
     .DeleteAccessorytooltip:hover .DeleteAccessoryName
    {
        visibility: visible;
        opacity: 1;
    }
    .DeleteAccessorytooltip .DeleteAccessoryName
    {
        visibility: hidden;
        width: 280px;
        background-color: yellow;
        color: red;
        border-radius: 6px;
        padding: 5px 5px;
        position: absolute;
        z-index: 1;
        top: 123%;
        left: 53%;
        margin-left: -65px;
        transition: opacity 0.3s;
        border: 1px solid #999;
    }
    .DeleteAccessorytooltip .DeleteAccessoryName::before
    {
         content: "";
        position: absolute;
        top: -11px;
        left: 64px;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color:  transparent transparent #999 transparent;
    }
     
   .Change_DeleteAccessoryName
    {
       color: Red;
        text-align: left;
        width: 100%;
        font-size: 9px;
        text-transform: lowercase;
        height: 10px;
        width: 10px;
        border-radius: 50%;
        background-color: #f9d110;
        display: inline-block;
        margin: 1px 0px;
    }
    .Registered{background-color:green;}
   
    .ac_results li
    {
        margin: 0px;
        cursor: default;
        display: block;
        padding: 0px;
        font: menu;
        font-size: 11px;
        overflow: hidden;
        text-align: left;
        cursor: pointer;
    }
    .ac_results ul > li:first-child
    {
        pointer-events: none;
        position: sticky;
        width: 100%;
        margin: 1px 0px -1px;
        top:0; 
        background: #39589c;
         color: #fff;
    }
     .ac_results ul > li:first-child > .fabricheader > td
    {
      color:White; 
    }
    .ac_results ul > li:first-child td
    {
        pointer-events: none;
        background: #4061ab;
        color: #f8f8f8 !important;
        text-align:center;
    }
    .ac_results ul li table td
    {
        text-align:left;
        }
    .ac_results ul:nth-child(2)
    {
        background: black;
    }
    iframe
    {
        background: #ffffff;
        padding: 0px 0px;
    }
    #sb-wrapper
    {
        top: 60px !important;
    }
  .fabri_listtable td
    {
        text-align: center;
    }
    .fabri_listtable td:first-child
    {
       
        text-align: left;
        padding-left: 3px;
    }
  .boldness{

font-weight: bold;

}
/*  div.ac_results 
      {
    width: 50%!important;
    min-width: 400px;
    } */

    .fabricheader td
    {
      
        background: #4061ab;
        color: #f8f8f8;
        text-align: center;
        padding: 2px 0px;
    }
    .fabricheader td:first-child
    {
        border-left: 1px solid #999999;
    }
    .fabricheader td:last-child
    {
        border-right: 1px solid #999999;
    }
    .fabri_listtable td:first-child
    {
        border-left: 1px solid #999999;
    }
    .fabri_listtable td:last-child
    {
        border-right: 1px solid #999999;
    }
    .access_infotable th
    {
        border-bottom: 1px solid #999999;
        border-right: 1px solid #999999;
        text-align: center;
    }
    .access_infotable th:first-child
    {
        border-left: 1px solid #999999;
    }
    .access_infotable td
    {
        border-bottom: 1px solid #999999;
        border-right: 1px solid #999999;
        text-align: center;
    }
    .access_infotable td:first-child
    {
        border-left: 1px solid #999999;
    }
    .access_infotable th
    {
        border-bottom:1px solid #999999;  
        border-right:1px solid #999999; 
        text-align: center;
        padding: 2px 2px !important;
    }
    .access_infotable th:first-child
    {

        border-left:1px solid #999999; 
       
    }
    .access_infotable td
    {
        border-bottom:1px solid #999999;  
        border-right:1px solid #999999; 
        text-align: center;
    }
    .access_infotable td:first-child
    {

        border-left:1px solid #999999; 
       
    }
    .ac_odd table td
    {
        border-color: #e1e1e1 !important;
    }
    .ac_even table td
    {
        border-color: #e1e1e1 !important;
    }
    table
    {
        border-color: #e1e1e1 !important;
    }
    .modal-content {
    padding: 7px !important;
    border: 1px solid #7a94bb;
    }
    
    #dvSizeRate
    {
        min-width: 50% !important;
    }
    input[type="radio"]
    {
        position:relative;
        top:2px;
    }          
    nobr
    {
        text-transform: capitalize !important;
    }
    input
    {
        text-transform: capitalize !important;
    }
        
    h2 
    {
        background: #cccfd6;
        color: #211d1dc4;
        font-family:Arial;
        line-height: 24px;
    }
    table 
    {
        font-family: verdana;
        border-color: #f1f1f1;
        border-collapse: collapse;
    }
    th
    {
       border-color: #a79d9d;
    }
    .textfont
    {
        font-size:15px !important;
        height:20px !important;
    }
    @-moz-document url-prefix() {
    table {
    border-color: #cec2c2
    }
    }
    #grdGetLp td
    {
        color:Gray !important;
        border-color:Gray !important;
    }
    ##grdGetLp
    {
        width:97%;
    }
    .modal-content2 
    {
        padding:0px 0px 13px 0px !important;
    }
    .da_submit_button 
    {
    font-size:12px !important;
    } 
    .da_submit_button:hover 
    {
    font-size:12px !important;
    } 
    .InputHight
    {
        height:18px !important;
     }
  /* #sb-wrapper
   {
       top:20% !important;
       left:40% !important;
   }*/   
  .validation_messagebox
  {
    border: 5px solid #999 !important;
    border-radius: 5px;
    padding: 0px;
    }
   .validation_messagebox table tr:first-child
   {
        background: #39589c;
        color: #fff;
        height: 20px;            
    }
    .validation_messagebox .header-text
    {
        font-size:12px !important;
    }
    .validation_messagebox .message-button-box
    {
    padding-right:5px !important;
    }        
    .border_right_color
    {
        border-right-color: #999 !important;
    }
    .someCssClass
    {
        background-color:#bfbfbf !important;
        }
    .ClientChangeCss
    {
        background-color:#ff9999 !important;
        }
</style>
<style type="text/css">
    @import url("https://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css");
    
    .Rupees
    {
        position: relative;
        color: #aaa;
        font-size: 16px;
        color: #999;
        font-size: 12px;
    }
    .Rupees1
    {
        position: relative;
        color: #aaa;
        font-size: 16px;
        color: #999;
        font-size: 12px;
    }
    .Rupees input
    {
        border: none;
        padding-left: 10%;
        text-align: left;
        width: 50%;
        outline: none;
    }
    
    .Rupees1 input
    {
        border: none;
        padding-left: 19%;
        text-align: left;
        width: 50% !important;
    }
    
    /*upadeted code by bharat 1-feb*/
    .Rupees .fa-rupee
    {
        position: absolute;
        top: 3px;
        left: 8%;
        font-size: 13px;
    }
    .Rupees1 .fa-rupee
    {
        position: absolute;
        top: 3px;
        left: 8%;
        font-size: 13px;
    }
    .toptobottom
    {
        position: relative;
        top: 8px;
    }
    .fontsize2
    {
        font-size: 13px !important;
    }
    
    .prosessamount
    {
        position: relative;
        top: 5px;
    }
    #ctl00_cph_main_content_CostingFormNew1_grdLandedCosting
    {
        border: 0px !important;
    }
    
    
    /* The Modal (background) */
    .modal2
    {
        display: none;
        position: absolute;
        z-index: 1;
        left: 40%;
        top: 40%;
    }
    
    /* Modal Content */
    .modal-content2
    {
        background-color: #fefefe;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 340px; /*margin-top: 12%;*/
        position: absolute;
        top: 35%;
        left: 50%;
        transform: translate(-50%, -50%) !important;
    }
    
    /* The Close Button */
    .close2
    {
        color: #aaaaaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }
    .close:hover2, .close:focus2
    {
        color: #000;
        text-decoration: none;
        cursor: pointer;
    }
    /* The Modal (background) */
    .AccTooltipRelative
    {
        position: relative;
    }
    .modal
    {
        display: none; /* Hidden by default */
        position: absolute; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 25%;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */ /* background-color: rgb(0,0,0); /* Fallback color */ /* background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }
    .modal-content
    {
        background-color: #fefefe;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: auto;
        left: 0;
        position: absolute;
    }
    .close
    {
        color: #aaaaaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }
    .close:hover, .close:focus
    {
        color: #000;
        text-decoration: none;
        cursor: pointer;
    }
    .submit
    {
        color: Yellow !important;
    }
    .border_right_0
    {
        border-right: 0px;
    }
    .border_left_0
    {
        border-left: 0px;
    }
    #sb-wrapper-inner
    {
        border: 5px solid #999;
    }
    #divConfirmBoxDetails
    {
        border: 5px solid #999;
        border-radius: 5px;
        line-height: 19px;
    }
    .m-r-5
    {
        margin-right: 5px;
    }
    /*Tooltip Css*/
    [data-title]
    {
        position: relative;
        font-weight: normal;
    }
    [data-title]:hover::before
    {
        content: attr(data-title);
        position: absolute;
        max-width: 225px;
        bottom: -26px;
        display: inline-block;
        padding: 3px 6px;
        border-radius: 2px;
        background: #aaa7a7;
        color: #000;
        font-size: 12px;
        left: 0;
        font-family: sans-serif;
        white-space: nowrap;
        font-weight: normal;
        text-align: center;
        z-index: 10000;
        min-width: 56px;
        border: 1px solid gray;
    }
    [data-title]:hover::after
    {
        content: '';
        position: absolute;
        bottom: -6px;
        left: 0;
        display: inline-block;
        color: #fff;
        border: 5px solid transparent;
        border-bottom: 7px solid #aaa7a7;
        z-index: 10000;
    }
    .addRupeesym:after
    {
        content: " ₹";
        color: Green;
    }
    li .RagisterFab
    {
        background: #cdcbcb !important;
    }
    .Unregistered
    {
        background: #cdcbcb !important;
    }
    .MaxWidth
    {
        max-width: 1400px;
        overflow-y: auto;
    }
    
    a.HistoryAnchor:hover
    {
        text-decoration: underline;
        cursor: pointer;
    }
    
    
    .ModelPo2 h2
    {
        margin-left: 0px !important;
    }
    
    .ModelPo2
    {
        background: #fff;
        position: absolute;
        width: 607px;
        border: 5px solid gray;
        left: 50%;
        top: 50%;
        transform: translate(-50%, -50%);
        z-index: 999;
        max-height: 300px;
        overflow: auto;
    }
    .HideButton
    {
        display: none;
    }
    .ShowButton
    {
        display: block;
    }
    input[type="text"].FabQualityInputHeight
    {
        height: 18px !important;
    }
    
    .rsicon::before
    {
        content: "₹";
        font-size: 15px;
        font-weight: 600;
        color: Green;
        font-family: "Font Awesome 5 free";
        position: absolute;
        top: 1px;
    }
    .rsicon1::before
    {
        content: "₹";
        font-size: 15px;
        font-weight: 500;
        color: Green;
        font-family: "Font Awesome 5 free";
        position: absolute;
        top: -1px;
        margin-left: 1px;
    }
    .input-container
    {
        --input-height: 40px;
        --input-pad: 16px;
        display: flex;
        position: relative;
        padding-top: var(--label-gap);
        border: none;
    }
    .input
    {
        width: 100%;
        border: 1px solid #6D98BA;
        padding: 0 var(--input-pad);
        height: var(--input-height);
    }
    .input::placeholder
    {
        color: transparent;
    }
    .input:focus + .input-label, .input:not(:placeholder-shown) + .input-label
    {
        color: #000;
        font-size: 14px;
        transform: scale(0.75) translateY(calc(var(--input-height) * -1));
    }
    .input-label
    {
        position: absolute;
        top: var(--label-gap);
        left: var(--input-pad);
        transform-origin: left top;
        transition: transform 0.26s cubic-bezier(0.14, 0.62, 0.43, 1.08);
        height: var(--input-height);
        line-height: var(--input-height);
        color: #124559;
        font-size: 16px;
        pointer-events: none;
        letter-spacing: 0.3px;
    }
    .onlypercent_sign
    {
        position: relative;
    }
    .outline_none
    {
        outline: none;
    }
    .onlypercent_sign .penny
    {
        margin-left: -5px;
    }
    .text_align_left
    {
        text-align: left;
    }
    .inactive
    {
        background-color:#adadad;
    }
</style>
<script src="../../js/combined_jquery_scripts4.js" type="text/javascript"></script>
<script type="text/javascript" src="../../js/ui.draggable.js"></script>
<script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
<script src="../../CommonJquery/Js/jquery.autocomplete_new.js" type="text/javascript"></script>
<link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

    var ExpectedQtyChange = "false";
    //var WCFServiceurl = "http://localhost:53379/KandiRestService.svc/"; //Need to update for online. that is by default on asp .net developement server can be also used for local machine, After started the service.
    var WCFServiceurl = "http://localhost:120/KandiRestService.svc/"; //Need to update for online. That is hosted on local machine IIS.
    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);
    var jscriptPageVariables = null;

    var txtAccessoriesPrice;

    var txtAccessoriesQuantity;
    var txtAccessoriesRate;
    //var txtAccessoriesAmount;


    var txtAmount;
    var txtWaste;
    var txtTotal;
    var txtTotalAvgWstg;
    var txtTotalABC;
    var txtAvarage;

    var finalCost;
    var finalcommision;
    var finalCostCTC;
    var finalTotal;

    var onUnitCtcInFc;
    var percentageProfit;

    var printHtml;
    var printIdsFilledAtLoad = false;

    var fobIKandi;
    var fobMargin;

    var modeDeliveryTime;
    var expectedDate;
    var deliveryDate;

    var zipDetails;

    var grandTotalAF;
    var grandTotalAH;
    var grandTotalSF;
    var grandTotalSH;
    var grandTotalDC;

    var grandTotalFOB;
    var fobBoutiquePrice;
    var txtFabricType;
    var txtCostingFabric;
    var ddlCostingBuyer;
    var imgFab;
    var currChange;
    var lblTotalP;
    var ddlFabricType;

    var fobAgreedPrice;
    var fobChkLandedCosting;

    var txtWidthClientID1 = '<%=txtWidth1.ClientID%>';
    var txtWasteClientID1 = '<%=txtWaste1.ClientID%>';
    var txtFabricTypeClientID1 = '<%=txtFabricType1.ClientID%>';
    var txtRateClientID1 = '<%=txtRate1.ClientID%>';

    var txtWidthClientID2 = '<%=txtWidth2.ClientID%>';
    var txtWasteClientID2 = '<%=txtWaste2.ClientID%>';
    var txtFabricTypeClientID2 = '<%=txtFabricType2.ClientID%>';
    var txtRateClientID2 = '<%=txtRate2.ClientID%>';

    var txtWidthClientID3 = '<%=txtWidth3.ClientID%>';
    var txtWasteClientID3 = '<%=txtWaste3.ClientID%>';
    var txtFabricTypeClientID3 = '<%=txtFabricType3.ClientID%>';
    var txtRateClientID3 = '<%=txtRate3.ClientID%>';

    var txtWidthClientID4 = '<%=txtWidth4.ClientID%>';
    var txtWasteClientID4 = '<%=txtWaste4.ClientID%>';
    var txtFabricTypeClientID4 = '<%=txtFabricType4.ClientID%>';
    var txtRateClientID4 = '<%=txtRate4.ClientID%>';

    var txtWidthClientID5 = '<%=txtWidth5.ClientID%>';
    var txtWasteClientID5 = '<%=txtWaste5.ClientID%>';
    var txtFabricTypeClientID5 = '<%=txtFabricType5.ClientID%>';
    var txtRateClientID5 = '<%=txtRate5.ClientID%>';

    var txtWidthClientID6 = '<%=txtWidth6.ClientID%>';
    var txtWasteClientID6 = '<%=txtWaste6.ClientID%>';
    var txtFabricTypeClientID6 = '<%=txtFabricType6.ClientID%>';
    var txtRateClientID6 = '<%=txtRate6.ClientID%>';

    var txtWidthClientID7 = '<%=txtWidth7.ClientID%>';
    var txtWasteClientID7 = '<%=txtWaste7.ClientID%>';
    var txtFabricTypeClientID7 = '<%=txtFabricType7.ClientID%>';
    var txtRateClientID7 = '<%=txtRate7.ClientID%>';

    var txtWidthClientID8 = '<%=txtWidth8.ClientID%>';
    var txtWasteClientID8 = '<%=txtWaste8.ClientID%>';
    var txtFabricTypeClientID8 = '<%=txtFabricType8.ClientID%>';
    var txtRateClientID8 = '<%=txtRate8.ClientID%>';

    var hidFab1DetailsClientID = '<%=hidFab1Details.ClientID%>';
    var hidFab2DetailsClientID = '<%=hidFab2Details.ClientID%>';
    var hidFab3DetailsClientID = '<%=hidFab3Details.ClientID%>';
    var hidFab4DetailsClientID = '<%=hidFab4Details.ClientID%>';
    var hidFab5DetailsClientID = '<%=hidFab5Details.ClientID%>';
    var hidFab6DetailsClientID = '<%=hidFab6Details.ClientID%>';
    var hidFab7DetailsClientID = '<%=hidFab7Details.ClientID%>';
    var hidFab8DetailsClientID = '<%=hidFab8Details.ClientID%>';

    var txtFabricClientID1 = '<%=txtFabric1.ClientID%>';
    var txtFabricClientID2 = '<%=txtFabric2.ClientID%>';
    var txtFabricClientID3 = '<%=txtFabric3.ClientID%>';
    var txtFabricClientID4 = '<%=txtFabric4.ClientID%>';
    var txtFabricClientID5 = '<%=txtFabric5.ClientID%>';
    var txtFabricClientID6 = '<%=txtFabric6.ClientID%>';
    var txtFabricClientID7 = '<%=txtFabric7.ClientID%>';
    var txtFabricClientID8 = '<%=txtFabric8.ClientID%>';

    var BuyerDDClientID = '<%=ddlBuyer.ClientID%>';
    var hdnuseridClientID = '<%=hdnuserid.ClientID %>';
    var DeptDDClientID = '<%=ddlDept.ClientID%>';
    var hdnDeptIdClientID = '<%=hdnDeptId.ClientID%>';
    var ParentDeptDDClientID = '<%=ddlParentDept.ClientID%>';
    var hdnParentDeptIdClientID = '<%=hdnParentDeptId.ClientID%>';


    var hiddenRadioModeClientID1 = '<%=hiddenRadioMode1.ClientID %>';
    var lblOriginClientID1 = '<%=lblOrigin1.ClientID %>';
    var hiddenRadioModeClientID2 = '<%=hiddenRadioMode2.ClientID %>';
    var lblOriginClientID2 = '<%=lblOrigin2.ClientID %>';
    var hiddenRadioModeClientID3 = '<%=hiddenRadioMode3.ClientID %>';
    var lblOriginClientID3 = '<%=lblOrigin3.ClientID %>';
    var hiddenRadioModeClientID4 = '<%=hiddenRadioMode4.ClientID %>';
    var lblOriginClientID4 = '<%=lblOrigin4.ClientID %>';

    var hiddenRadioModeClientID5 = '<%=hiddenRadioMode5.ClientID %>';
    var lblOriginClientID5 = '<%=lblOrigin5.ClientID %>';
    var hiddenRadioModeClientID6 = '<%=hiddenRadioMode6.ClientID %>';
    var lblOriginClientID6 = '<%=lblOrigin6.ClientID %>';
    var hiddenRadioModeClientID7 = '<%=hiddenRadioMode7.ClientID %>';
    var lblOriginClientID7 = '<%=lblOrigin7.ClientID %>';
    var hiddenRadioModeClientID8 = '<%=hiddenRadioMode8.ClientID %>';
    var lblOriginClientID8 = '<%=lblOrigin8.ClientID %>';

    var PageStyleId = '<%=this.StyleID %>';
    var radiomode1;
    var radiomode2;
    var radiomode3;
    var radiomode4;
    var radiomode5;
    var radiomode6;
    var radiomode7;
    var radiomode8;

    var fabType1;
    var fabType2;
    var fabType3;
    var fabType4;
    var fabType5;
    var fabType6;
    var fabType7;
    var fabType8;

    var Suplier1 = '';
    var Suplier2 = '';
    var Suplier3 = '';
    var Suplier4 = '';
    var Suplier5 = '';
    var Suplier6 = '';
    var Suplier7 = '';
    var Suplier8 = '';

    var trade1;
    var trade2;
    var trade3;
    var trade4;
    var trade5;
    var trade6;
    var trade7;
    var trade8;

    var exqty;
    var ddlCostingDept;
    var ddlCostingParentDept;
    var isExpandedFabric = true;
    var isExpandedCMT = true;
    var isExpandedAccessory = true;
    var isExpandedProcess = true;
    var isExpandedFinancial = true;
    var isExpandedBiplOther = true;
    var isExpandedLandedCosting = true;
    var isExpandedDirectCosting = true;
    var isExpandedIkandiOther = true;
    var DefaultAccessory = 0;
    var RegisterFabricName;
    var RegisterFabricName1
    var fabricTyle;
    //added by shubhendu
    //  alert("test");

    function ValidateisNaN(obj) {

        if (isNaN(obj.value)) {
            obj.value = "";
        }
    }

    $(".numberonly").keypress(function (e) {

        var charCode = (e.which) ? e.which : event.keyCode

        if (String.fromCharCode(charCode).match(/[^0-9]/g))

            event.preventDefault();

    });
    //    jQuery.fn.ForceNumericOnly =
    //function()
    //{
    //    return this.each(function()
    //    {
    //        $(this).keydown(function(e)
    //        {
    //            var key = e.charCode || e.keyCode || 0;
    //            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
    //            // home, end, period, and numpad decimal
    //            return (
    //                key == 8 || 
    //                key == 9 ||
    //                key == 13 ||
    //                key == 46 ||
    //                key == 110 ||
    //                key == 190 ||
    //                (key >= 35 && key <= 40) ||
    //                (key >= 48 && key <= 57) ||
    //                (key >= 96 && key <= 105));
    //        });
    //  $("#ctl00_cph_main_content_CostingFormNew1_txtGVW").ForceNumericOnly();
    // $("txtGCW").ForceNumericOnly();
    // $("ctl00_cph_main_content_CostingFormNew1_gvdProcessDetails_ctl02_lblTotalAmount").ForceNumericOnly(); 

    function BiplHistoryShowHideFabric(prmThis) {

        if (isExpandedFabric == false) {
            $(".Ulbiplhistoryfabric").show();
            isExpandedFabric = true;
            $(prmThis).html("- Hide Fabric");
        }
        else {
            $(".Ulbiplhistoryfabric").hide();
            isExpandedFabric = false;
            $(prmThis).html("+ Show Fabric");
        }
    }
    function BiplHistoryShowHideCMT(prmThis) {
        if (isExpandedCMT == false) {
            $(".UlbiplhistoryCMT").show();
            isExpandedCMT = true;
            $(prmThis).html("- Hide CMT");
        }
        else {
            $(".UlbiplhistoryCMT").hide();
            isExpandedCMT = false;
            $(prmThis).html("+ Show CMT");
        }
    }
    function BiplHistoryShowHideAccessory(prmThis) {
        if (isExpandedAccessory == false) {
            $(".Ulbiplhistoryaccessory").show();
            isExpandedAccessory = true;
            $(prmThis).html("- Hide Accessory");
        }
        else {
            $(".Ulbiplhistoryaccessory").hide();
            isExpandedAccessory = false;
            $(prmThis).html("+ Show Accessory");
        }
    }
    function BiplHistoryShowHideProcess(prmThis) {
        if (isExpandedProcess == false) {
            $(".Ulbiplhistoryprocess").show();
            isExpandedProcess = true;
            $(prmThis).html("- Hide Process");
        }
        else {
            $(".Ulbiplhistoryprocess").hide();
            isExpandedProcess = false;
            $(prmThis).html("+ Show Process");
        }
    }
    function BiplHistoryShowHideFinencial(prmThis) {
        if (isExpandedFinancial == false) {
            $(".Ulbiplhistoryfinancial").show();
            isExpandedFinancial = true;
            $(prmThis).html("- Hide Financial");
        }
        else {
            $(".Ulbiplhistoryfinancial").hide();
            isExpandedFinancial = false;
            $(prmThis).html("+ Show Financial");
        }
    }
    function BiplHistoryShowHideOther(prmThis) {
        if (isExpandedBiplOther == false) {
            $(".Ulbiplhistoryother").show();
            isExpandedBiplOther = true;
            $(prmThis).html("- Hide Other");
        }
        else {
            $(".Ulbiplhistoryother").hide();
            isExpandedBiplOther = false;
            $(prmThis).html("+ Show Other");
        }
    }
    function IkandiHistoryShowHideLanded(prmThis) {
        if (isExpandedLandedCosting == false) {
            $(".Ulikandihistorylanded").show();
            isExpandedLandedCosting = true;
            $(prmThis).html("- Hide Landed");
        }
        else {
            $(".Ulikandihistorylanded").hide();
            isExpandedLandedCosting = false;
            $(prmThis).html("+ Show Landed");
        }
    }
    function IkandiHistoryShowHideDirect(prmThis) {
        if (isExpandedDirectCosting == false) {
            $(".Ulikandihistorydirect").show();
            isExpandedDirectCosting = true;
            $(prmThis).html("- Hide Direct");
        }
        else {
            $(".Ulikandihistorydirect").hide();
            isExpandedDirectCosting = false;
            $(prmThis).html("+ Show Direct");
        }
    }
    function IkandiHistoryShowHideOther(prmThis) {
        if (isExpandedIkandiOther == false) {
            $(".Ulikandihistoryother").show();
            isExpandedIkandiOther = true;
            $(prmThis).html("- Hide Other");
        }
        else {
            $(".Ulikandihistoryother").hide();
            isExpandedIkandiOther = false;
            $(prmThis).html("+ Show Other");
        }
    }

    function CheckAgreementFromPage() {
        var chkagreeClientID = '<%=chkTooltip.ClientID %>';
        $("#" + chkagreeClientID, "#main_content").attr('checked', 'checked');
        $(".tooltiptextF").attr("style", "visibility:visible !important");
        $(".tooltiptext").attr("style", "visibility:visible !important");
        $(".tooltiptextFabricavrage").attr("style", "visibility:visible !important");
        $(".tooltiptextFabric").attr("style", "visibility:visible !important");
        $(".tooltiptextRightShort").attr("style", "visibility:visible !important");
        $(".tooltiptextAccessory").attr("style", "visibility:visible !important");
        $(".AvlueAddtextFabricavrage").attr("style", "visibility:visible !important");
        $(".DeleteFabricName").attr("style", "visibility:visible !important");
        $(".DeleteAccessoryName").attr("style", "visibility:visible !important");
    }


    $("[id*=chkTooltip]").live("click", function () {

        var chkbox = $(this);
        if (chkbox.is(":checked")) {
            $(".tooltiptextF").attr("style", "visibility:visible !important");
            $(".tooltiptext").attr("style", "visibility:visible !important");
            $(".tooltiptextFabricavrage").attr("style", "visibility:visible !important");
            $(".tooltiptextFabric").attr("style", "visibility:visible !important");
            $(".tooltiptextRightShort").attr("style", "visibility:visible !important");
            $(".tooltiptextAccessory").attr("style", "visibility:visible !important");
            $(".AvlueAddtextFabricavrage").attr("style", "visibility:visible !important");
            $(".DeleteFabricName").attr("style", "visibility:visible !important");
            $(".DeleteAccessoryName").attr("style", "visibility:visible !important");
        }
        else {
            $(".tooltiptextF").removeAttr("style");
            $(".tooltiptext").removeAttr("style");
            $(".tooltiptextFabric").removeAttr("style");
            $(".tooltiptextFabricavrage").removeAttr("style");
            $(".tooltiptextRightShort").removeAttr("style");
            $(".tooltiptextAccessory").removeAttr("style");
            $(".AvlueAddtextFabricavrage").removeAttr("style");
            $(".DeleteFabricName").removeAttr("style");
            $(".DeleteAccessoryName").removeAttr("style");
        }
    });


    $(function () {

        //Added code Bharat on 18-Dec-20txtFabric1
        var GrdDeleteRowCount = $("#ctl00_cph_main_content_CostingFormNew1_hdnDeleteButtonCount").val();
        // var GrdtxtFabric1 = $("#ctl00_cph_main_content_CostingFormNew1_txtFabric1").val();
        // alert(GrdtxtFabric1);
        var i;
        for (i = 1; i < GrdDeleteRowCount; i++) {
            $("#ctl00_cph_main_content_CostingFormNew1_tr_fab" + i).find('.FabricDeleteButton a').addClass("HideButton");
        }
        //        var AccCountDel = $("#ctl00_cph_main_content_CostingFormNew1_hdnAccDeleteButtonCount").val();
        //        var j;
        //        var RowId = 0;
        //        var gvId;
        //        for (j = 1; j < AccCountDel; j++) {
        //            RowId = parseInt(j) + 1;
        //            if (RowId < 10)
        //                gvId = 'ctl0' + RowId;
        //            else
        //                gvId = 'ctl' + RowId;
        //          var abc=  $("#ctl00_cph_main_content_CostingFormNew1_gdvAccessory_" + gvId + "_imgBtndelete").addClass("HideButton");
        //      }

        //      var ProCountDel = $("#ctl00_cph_main_content_CostingFormNew1_hndProDeleteButton").val();
        //      var k;
        //      var RowId = 0;
        //      var gvId;
        //      for (k = 1; k < ProCountDel; k++) {
        //          RowId = parseInt(j) + 1;
        //          if (RowId < 10)
        //              gvId = 'ctl0' + RowId;
        //          else
        //              gvId = 'ctl' + RowId;

        //          var abc = $("#ctl00_cph_main_content_CostingFormNew1_gvdProcessDetails_" + gvId + "_ProcessimgBtndelete").addClass("HideButton");
        //      }

        //End
        //abhishek 9/12/2020
        $('input[type=text]').each(function () {
            var attr = $(this).attr('title');
            if (typeof attr !== typeof undefined && attr !== false) {
                $(this).attr('title', $(this).val());
            }
        })
        $('span').each(function () {
            var attr = $(this).attr('title');
            if (typeof attr !== typeof undefined && attr !== false) {
                $(this).attr('title', $(this).val());
            }

        })
        //END abhishek
        //           $('#<%=gdvAccessory.ClientID%>').find('input:text[id$="txtItems"]').each(function () {
        //            $(this).attr('title', $(this).val());

        //        });

        ShowHideFabric();
        ShowHideLandedCosting();
        var hdnbuyerClientID = '<%=hdnbuyer.ClientID%>';
        txtCostingFabric = $('input[type=text].costing-fabric');

        //txtAccessoriesAmount = $('input[type=text].costing-accessories-amount');
        txtAccessoriesPrice = $('input[type=text].costing-accessories-price');

        txtAccessoriesQuantity = $('.costing-accessories-quantity');
        txtAccessoriesRate = $('.costing-accessories-rate');

        SetDecimalPlacesForDecimalFields();
        $('input[type=text].numeric-field-with-one-decimal-places').blur(function () { SetDecimalPlacesForDecimalFields($(this), 1); });
        $('input[type=text].numeric-field-with-two-decimal-places').blur(function () { SetDecimalPlacesForDecimalFields($(this), 2); });
        $('input[type=text].numeric-field-with-three-decimal-places').blur(function () { SetDecimalPlacesForDecimalFields($(this), 3); });


        txtAmount = $('input[type=text].costing-amount');
        txtWaste = $('input[type=text].costing-waste');
        txtTotal = $('input[type=text].costing-totalFabric');

        txtAvarage = $('input[type=text].costing-average');
        txtTotalAvgWstg = $('input[type=text].total-Avg-wst'); // $('.total-Avg-wst');
        txtTotalABC = $('input[type=text].costing-total-abc');
        finalCost = $('.costing-final-cost');

        finalCostCTC = $('input[type=text].costing-final-cost-ctc');
        finalTotal = $('input[type=text].costing-final-total');
        onUnitCtcInFc = $('input[type=text].costing-on-unit-ctc');
        finalcommision = $('input[type=text].costing-on-unit-commission');

        percentageProfit = $('input[type=text].costing-percentage-profit');

        exqty = $('.exqty');
        currChange = $('.currChange');
        printHtml = $('table.costing-print-table tbody tr').html();

        fobIKandi = $('input[type=text].costing-landed-costing-fob-ikandi');
        fobMargin = $('input[type=text].costing-landed-costing-fob-margin');

        modeDeliveryTime = $('input[type=text].costing-landed-costing-mode-delivery-time');
        expectedDate = $('input[type=text].costing-landed-costing-expected-date');
        deliveryDate = $('input[type=text].costing-landed-costing-delivery-date');

        zipDetails = $('.costing-accessories-zip');

        grandTotalAF = $('input[type=text].costing-landed-costing-grand-total1');
        grandTotalAH = $('input[type=text].costing-landed-costing-grand-total2');
        grandTotalSF = $('input[type=text].costing-landed-costing-grand-total3');
        grandTotalSH = $('input[type=text].costing-landed-costing-grand-total4');
        grandTotalDC = $('input[type=text].costing-landed-costing-grand-total5');

        grandTotalFOB = $('input[type=text].costing-landed-costing-grand-total-fob');
        fobBoutiquePrice = $('input[type=text].costing-fob-boutique-price');
        txtFabricType = $('input[type=text].fabric-type');

        fobAgreedPrice = $('input[type=text].clsAgreedPrice');
        fobChkLandedCosting = $('.chkClsLandedCosting input[type=checkbox]');

        txtFabric1Type = $('input[type=text].fabric1-type');
        ddlCostingBuyer = $('select.costing-buyer');
        ddlCostingDept = $('select.costing-department');
        ddlCostingParentDept = $('select.costing-Parentdepartment');
        imgFab = $('.imgFab');

        radiomode1 = $('.radio_mode1');
        radiomode2 = $('.radio_mode2');
        radiomode3 = $('.radio_mode3');
        radiomode4 = $('.radio_mode4');
        radiomode5 = $('.radio_mode5');
        radiomode6 = $('.radio_mode6');
        radiomode7 = $('.radio_mode7');
        radiomode8 = $('.radio_mode8');

        lblTotalP = $(".tablefab").find('.costing-totalPrice');
        ddlFabricType = $('select .costing-ddlFabricType');

        var changedValueTD = $('span.changed_value').closest('td');

        for (var i = 0; i < changedValueTD.length; i++) {
            for (var j = 0; j < $(changedValueTD[i]).children().length; j++) {
                if ($($(changedValueTD[i]).children()[j]).css('color').toLowerCase() == 'blue') {
                    $(changedValueTD[i]).css('text-align', 'center');
                    break;
                }
            }
        }

        // Add to make the cell in yellow color   
        $("span.changed_value").each(function () {
            var parentTD = $(this).closest("td");
            //parentTD.css({ 'background-color': 'yellow !important' });
            parentTD.addClass("costing_highlight_yellow");
            //parentTD.find("input,label,div").css({ 'background-color': 'yellow !important' });
            parentTD.find("input,label,div").addClass("costing_highlight_yellow");
        });

        if ($("#" + hiddenRadioModeClientID1).val() == "0") {
            if (radiomode1.length > 0)
                radiomode1[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID1).val() == "1") {
            if (radiomode1.length > 0)
                radiomode1[0].checked = true;
        }

        if ($("#" + hiddenRadioModeClientID2).val() == "0") {
            if (radiomode2.length > 0)
                radiomode2[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID2).val() == "1") {
            if (radiomode2.length > 0)
                radiomode2[0].checked = true;
        }

        if ($("#" + hiddenRadioModeClientID3).val() == "0") {
            if (radiomode3.length > 0)
                radiomode3[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID3).val() == "1") {
            if (radiomode3.length > 0)
                radiomode3[0].checked = true;
        }

        if ($("#" + hiddenRadioModeClientID4).val() == "0") {
            if (radiomode4.length > 0)
                radiomode4[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID4).val() == "1") {
            if (radiomode4.length > 0)
                radiomode4[0].checked = true;
        }
        if ($("#" + hiddenRadioModeClientID5).val() == "0") {
            if (radiomode5.length > 0)
                radiomode5[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID5).val() == "1") {
            if (radiomode5.length > 0)
                radiomode5[0].checked = true;
        }
        if ($("#" + hiddenRadioModeClientID6).val() == "0") {
            if (radiomode6.length > 0)
                radiomode6[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID6).val() == "1") {
            if (radiomode6.length > 0)
                radiomode6[0].checked = true;
        }
        if ($("#" + hiddenRadioModeClientID7).val() == "0") {
            if (radiomode7.length > 0)
                radiomode7[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID7).val() == "1") {
            if (radiomode7.length > 0)
                radiomode7[0].checked = true;
        }
        if ($("#" + hiddenRadioModeClientID8).val() == "0") {
            if (radiomode8.length > 0)
                radiomode8[1].checked = true;
        }
        else if ($("#" + hiddenRadioModeClientID8).val() == "1") {
            if (radiomode8.length > 0)
                radiomode8[0].checked = true;
        }

        $("input[name='radioMode1']").click(function () {

            trade1 = $("#" + txtFabricClientID1).val().split('{');
            if (trade1 != '')
                Suplier1 = trade1[1].replace('}', "").trim();

            var yt = $(".afab").val();
            var ss = $("#" + hidFab1DetailsClientID).val();
            if ($("input[name='radioMode1']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID1).val("0");
            }
            else if ($("input[name='radioMode1']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID1).val("1");
            }
            //GetFabricQualityData(trade1[0], $(".afab").val(), $("#" + hiddenRadioModeClientID1).val(), 1, false, $('.fab_Type1 option:selected').val(), Suplier1);
        });

        $("input[name='radioMode2']").click(function () {

            trade2 = $("#" + txtFabricClientID2).val().split('{');
            if (trade2 != '')
                Suplier2 = trade2[1].replace('}', "").trim();

            if ($("input[name='radioMode2']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID2).val("0");
            }
            else if ($("input[name='radioMode2']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID2).val("1");
            }
            //GetFabricQualityData(trade2[0], $(".b").val(), $("#" + hiddenRadioModeClientID2).val(), 2, false, $('.fab_Type2 option:selected').val(), Suplier2);
        });

        $("input[name='radioMode3']").click(function () {
            trade3 = $("#" + txtFabricClientID3).val().split('{');
            if (trade3 != '')
                Suplier3 = trade3[1].replace('}', "").trim();


            if ($("input[name='radioMode3']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID3).val("0");
            }
            else if ($("input[name='radioMode3']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID3).val("1");
            }
            //GetFabricQualityData(trade3[0], $(".c").val(), $("#" + hiddenRadioModeClientID3).val(), 3, false, $('.fab_Type3 option:selected').val(), Suplier3);
        });

        $("input[name='radioMode4']").click(function () {


            trade4 = $("#" + txtFabricClientID4).val().split('{');
            if (trade4 != '')
                Suplier4 = trade4[1].replace('}', "").trim();


            if ($("input[name='radioMode4']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID4).val("0");
            }
            else if ($("input[name='radioMode4']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID4).val("1");
            }
            //GetFabricQualityData(trade4[0], $(".d").val(), $("#" + hiddenRadioModeClientID4).val(), 4, false, $('.fab_Type4 option:selected').val(), Suplier4);
        });

        $("input[name='radioMode5']").click(function () {


            trade5 = $("#" + txtFabricClientID5).val().split('{');
            if (trade5 != '')
                Suplier5 = trade5[1].replace('}', "").trim();


            if ($("input[name='radioMode5']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID5).val("0");
            }
            else if ($("input[name='radioMode5']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID5).val("1");
            }
            //GetFabricQualityData(trade5[0], $(".d").val(), $("#" + hiddenRadioModeClientID5).val(), 5, false, $('.fab_Type5 option:selected').val(), Suplier5);
        });

        $("input[name='radioMode6']").click(function () {


            trade6 = $("#" + txtFabricClientID6).val().split('{');
            if (trade6 != '')
                Suplier6 = trade6[1].replace('}', "").trim();


            if ($("input[name='radioMode6']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID6).val("0");
            }
            else if ($("input[name='radioMode6']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID6).val("1");
            }
            //GetFabricQualityData(trade6[0], $(".d").val(), $("#" + hiddenRadioModeClientID6).val(), 6, false, $('.fab_Type6 option:selected').val(), Suplier6);
        });

        $("input[name='radioMode7']").click(function () {


            trade7 = $("#" + txtFabricClientID7).val().split('{');
            if (trade7 != '')
                Suplier7 = trade7[1].replace('}', "").trim();


            if ($("input[name='radioMode7']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID7).val("0");
            }
            else if ($("input[name='radioMode7']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID7).val("1");
            }
            //GetFabricQualityData(trade7[0], $(".d").val(), $("#" + hiddenRadioModeClientID7).val(), 7, false, $('.fab_Type7 option:selected').val(), Suplier7);
        });

        $("input[name='radioMode8']").click(function () {


            trade8 = $("#" + txtFabricClientID8).val().split('{');
            if (trade8 != '')
                Suplier8 = trade8[1].replace('}', "").trim();


            if ($("input[name='radioMode8']:checked").val() == '0') {
                $("#" + hiddenRadioModeClientID8).val("0");
            }
            else if ($("input[name='radioMode8']:checked").val() == '1') {
                $("#" + hiddenRadioModeClientID8).val("1");
            }
            //GetFabricQualityData(trade8[0], $(".d").val(), $("#" + hiddenRadioModeClientID8).val(), 8, false, $('.fab_Type8 option:selected').val(), Suplier8);
        });


        if ($("#" + BuyerDDClientID, '#main_content').val() != '' && $("#" + BuyerDDClientID, '#main_content').val() != null && $("#" + BuyerDDClientID, '#main_content').val() > 0) {
            //
            populateParentDepartments($("#" + BuyerDDClientID, '#main_content').val(), -1, -1, 'Parent');
            populateDepartments($("#" + BuyerDDClientID, '#main_content').val(), -1, $('#<%= ddlParentDept.ClientID %> option:selected').val(), 'SubParent');
        }
        if ($("#" + hdnDeptIdClientID, '#main_content').val() != '' && $("#" + hdnDeptIdClientID, '#main_content').val() != null && $("#" + hdnDeptIdClientID, '#main_content').val() > 0) {
            $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
        }

        $("#" + BuyerDDClientID, '#main_content').change(function () {
            var clientId = $(this).val();
            if (clientId == '' || clientId == undefined || clientId == null) { clientId = '0'; }
            populateParentDepartments($(this).val(), -1, -1, 'Parent');
            populateDepartments($(this).val(), -1, $('#<%= ddlParentDept.ClientID %> option:selected').val(), 'SubParent');

        });

        ddlCostingParentDept.change(function () {
            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var ParentDeptId = $(this).val();
            populateDepartments(ClientId, -1, ParentDeptId, 'SubParent');
            $(this).val(ParentDeptId);
            $("#" + hdnParentDeptIdClientID, "#main_content").val(ParentDeptId);
        });

        $("#" + DeptDDClientID, '#main_content').change(function () {

            $("#" + hdnDeptIdClientID, "#main_content").val($("#" + DeptDDClientID, '#main_content').val());
            setDeptName();

            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var ParentDeptId = $('#<%= ddlParentDept.ClientID %> option:selected').val();
            var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();




            proxy.invoke("GetClientCostingBy_New", { ClientId: ClientId, DeptId: DeptId, StyleNumber: "", ExpectedQty: "-1" }, function (result) {

                if ($("#" + txtFabricClientID1).val() != '') {
                    document.getElementById('<%=txtWaste1.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID2).val() != '') {
                    document.getElementById('<%=txtWaste2.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID3).val() != '') {
                    document.getElementById('<%=txtWaste3.ClientID %>').value = result[0].CostingWaste;
                }
                if ($("#" + txtFabricClientID4).val() != '') {
                    document.getElementById('<%=txtWaste4.ClientID %>').value = result[0].CostingWaste;
                }
                //GetUnitQtyByClientDept(ClientId, DeptId);             
                CostingDeptChange();
            });

            $(".clsBtnUpdateAccessGrd").click();

            // 
            //            var styleId = $('input[type=text].costing-style-id').val();
            //            var CostingId = $("#ctl00_cph_main_content_CostingFormNew1_hdnCosting").val();

            //            //$('#ctl00_cph_main_content_CostingFormNew1_gdvAccessory').remove();

            //            var row = $("[id*=gdvAccessory] tr:last-child").clone(true);
            //            $("[id*=gdvAccessory] tr").not($("[id*=gdvAccessory] tr:first-child")).remove();

            //            proxy.invoke("GetAccessoryBy_Client_Dept_Change", { ClientId: ClientId, DeptId: DeptId, StyleId: styleId, CostingId: CostingId }, function (result) {
            //                if (result.length > 0) {
            //                    // // 
            //                    for (var i = 0; i < result.length; i++) {
            //                        // // 
            //                        //alert(result[i].Item);

            //                        //$(".items", row).html(result[i].Item.text());

            //                        row.find("[id*=lblSeq]").text(result[i].SequenceNumber);
            //                        row.find("[id*=txtItems]").val(result[i].Item);
            //                        row.find("[id*=hdnAccessoryQualityID]").val(result[i].AccessoryQualityID);
            //                        row.find("[id*=hdnDisableAcc]").val(result[i].Disabled_ACC);
            //                        row.find("[id*=hdnIsDefaultAccessory]").val(result[i].IsDefaultAccessory);
            //                        row.find("[id*=hdnAccClientId]").val(result[i].ClientId);
            //                        row.find("[id*=hdnAccParentDeptId]").val(result[i].ParentDepartmentId);
            //                        row.find("[id*=hdnAccDeptId]").val(result[i].DepartmentId);
            //                        row.find("[id*=txtUnitQty]").val(result[i].Quantity);
            //                        row.find("[id*=lblUnit]").val(result[i].Unit);
            //                        row.find("[id*=hdnID]").val(result[i].AccessoryQualityID);
            //                        row.find("[id*=lblTotalQuantity]").val(result[i].TotalQuantity);
            //                        row.find("[id*=txtRate]").val(result[i].Rate);
            //                        row.find("[id*=lblWastage]").val(result[i].Wastage);
            //                        row.find("[id*=lblTotalPriceAcc]").val(result[i].TotalPrice);

            //                        row.find("[id*=txtItems]").attr('title', result[i].Item);

            //                        if (i < (parseInt(result.length) - 1)) {
            //                            row.find("[id*=imgBtndelete]").addClass("HideButton");
            //                        }
            //                        else {
            //                            row.find("[id*=imgBtndelete]").addClass("ShowButton");
            //                        }
            //                        //$("td", row).eq(0).html(result[i].SequenceNumber);                      

            //                        $('#ctl00_cph_main_content_CostingFormNew1_gdvAccessory').append(row);
            //                        row = $("[id*=gdvAccessory] tr:last-child").clone(true);

            //                    }

            //                    CostingDeptChange();
            //                }

            //            });

        });


        $("input.fabric1", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        //  // 
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType1.ClientID %>').value.replace(/^\s+|\s+$/g, '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type1 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });
        //  // 

        $("input.fabric1", '#main_content').result(function () {

            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }
            var Str = $(this).val();

            var mys = $(this).val().split('$');
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var id = $(this);
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            // alert(JSON.stringify(mys2));
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];

            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];
            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice1]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type1 option:selected').val();

            $(".lay_file1").attr("style", "display:block");
            fabric1(GSM, CountConstruction);

            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth1]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth1]").val(CostWidth);
            }
            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate1]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate1]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate1]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
            $(".tr-fab").find("[id$=lblWidthCM1]").html(parseFloat(Math.round(CostWidth * 2.54).toFixed(2)));

            $(".tr-fab").find("[id$=hdnFabricID1]").val(Fabric_Quality_Supplier_Specific);
            //            alert(DyedRate);
            //            alert(PrintRate);
            //            alert(DigitalPrintRate);
            $(".tr-fab").find("[id$=hdnDyedRate1]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate1]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate1]").val(DigitalPrintRate);
            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $("#ctl00_cph_main_content_CostingFormNew1_txtFabric1").css("background-color", "#ffffaa");
                    $("#ctl00_cph_main_content_CostingFormNew1_txtFabric1").css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $("#ctl00_cph_main_content_CostingFormNew1_txtFabric1").css("background-color", "#bfbfbf");
                    $("#ctl00_cph_main_content_CostingFormNew1_txtFabric1").css("color", "#FF0000");
                }
            });


        });

        $("input.fabric2", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType2.ClientID %>').value.replace(/^\s+|\s+$/g, '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type2 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });


        $("input.fabric2", '#main_content').result(function () {

            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }



            var id = $(this);
            var Str = $(this).val();
            var mys = $(this).val().split('$');
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            //            alert(mys2[0].trim());
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];
            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];

            //   alert(Fabric_Quality_Supplier_Specific);
            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice2]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type2 option:selected').val();

            $(".lay_file2").attr("style", "display:block");
            fabric2(GSM, CountConstruction);

            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth2]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth2]").val(CostWidth);
            }

            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate2]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate2]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate2]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

            $(".tr-fab").find("[id$=lblWidthCM2]").html(parseFloat(Math.round(CostWidth * 2.54).toFixed(2)));
            $(".tr-fab").find("[id$=hdnFabricID2]").val(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnDyedRate2]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate2]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate2]").val(DigitalPrintRate);

            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $(id).css("background-color", "#ffffaa");
                    $(id).css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $(id).css("background-color", "#bfbfbf");
                    $(id).css("color", "#FF0000");

                }
            });

        });
        $("input.fabric3", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType3.ClientID %>').value.replace(/^\s+|\s+$/g, '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type3 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });
        $("input.fabric3", '#main_content').result(function () {
            //  // 
            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }
            var id = $(this);
            var Str = $(this).val();
            var mys = $(this).val().split('$');
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            //alert(mys2[0].trim());
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];
            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];

            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice3]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type3 option:selected').val();

            $(".lay_file3").attr("style", "display:block");
            fabric3(GSM, CountConstruction);

            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth3]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth3]").val(CostWidth);
            }

            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate3]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate3]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate3]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

            $(".tr-fab").find("[id$=lblWidthCM3]").html(parseFloat(Math.round(CostWidth * 2.54).toFixed(2)));
            //            alert(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnFabricID3]").val(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnDyedRate3]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate3]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate3]").val(DigitalPrintRate);

            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $(id).css("background-color", "#ffffaa");
                    $(id).css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $(id).css("background-color", "#bfbfbf");
                    $(id).css("color", "#FF0000");

                }
            });
        });
        $("input.fabric4", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType4.ClientID %>').value.replace(/^\s+|\s+$/g, '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type4 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });
        $("input.fabric4", '#main_content').result(function () {
            // 
            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }
            var id = $(this);
            var Str = $(this).val();
            //alert(Str);
            var mys = $(this).val().split('$');
            //   alert(mys);
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            //alert(mys2[0].trim());
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];
            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];

            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice4]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type4 option:selected').val();

            $(".lay_file4").attr("style", "display:block");
            fabric4(GSM, CountConstruction);


            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth4]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth4]").val(CostWidth);
            }
            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate4]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate4]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate4]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
            //alert("check");
            // 
            $(".tr-fab").find("[id$=lblWidthCM4]").html(parseFloat(Math.round(CostWidth * 2.54).toFixed(2)));
            $(".tr-fab").find("[id$=hdnFabricID4]").val(Fabric_Quality_Supplier_Specific);
            //alert(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnDyedRate4]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate4]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate4]").val(DigitalPrintRate);

            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $(id).css("background-color", "#ffffaa");
                    $(id).css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $(id).css("background-color", "#bfbfbf");
                    $(id).css("color", "#FF0000");
                }
            });
        });

        $("input.fabric5", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType5.ClientID %>').value.replace(/^\s+|\s+$/g, '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type5 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });
        $("input.fabric5", '#main_content').result(function () {

            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }
            var id = $(this);
            var Str = $(this).val();
            var mys = $(this).val().split('$');
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            //alert(mys2[0].trim());
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];
            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];

            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice5]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type5 option:selected').val();

            $(".lay_file5").attr("style", "display:block");
            fabric5(GSM, CountConstruction);

            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth5]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth5]").val(CostWidth);
            }
            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate5]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate5]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate5]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

            $(".tr-fab").find("[id$=lblWidthCM5]").html(parseFloat(Math.round(CostWidth * 2.54).toFixed(2)));
            $(".tr-fab").find("[id$=hdnFabricID5]").val(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnDyedRate5]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate5]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate5]").val(DigitalPrintRate);

            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $(id).css("background-color", "#ffffaa");
                    $(id).css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $(id).css("background-color", "#bfbfbf");
                    $(id).css("color", "#FF0000");
                }
            });
        });

        $("input.fabric6", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType6.ClientID %>').value.replace(/^\s+|\s+$/g, '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type6 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });
        $("input.fabric6", '#main_content').result(function () {

            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }
            var id = $(this);
            var Str = $(this).val();
            var mys = $(this).val().split('$');
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            //alert(mys2[0].trim());
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];
            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];

            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice6]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type6 option:selected').val();

            $(".lay_file6").attr("style", "display:block");
            fabric6(GSM, CountConstruction);


            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth6]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth6]").val(CostWidth);
            }
            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate6]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate6]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate6]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

            $(".tr-fab").find("[id$=lblWidthCM6]").html(parseFloat(Math.round(CostWidth * 2.54).toFixed(2)));
            $(".tr-fab").find("[id$=hdnFabricID6]").val(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnDyedRate6]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate6]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate6]").val(DigitalPrintRate);

            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $(id).css("background-color", "#ffffaa");
                    $(id).css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $(id).css("background-color", "#bfbfbf");
                    $(id).css("color", "#FF0000");
                }
            });
        });

        $("input.fabric7", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType7.ClientID %>').value.replace(/^\s+|\s+$/g, '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type7 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });
        $("input.fabric7", '#main_content').result(function () {

            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }
            var id = $(this);
            var Str = $(this).val();
            var mys = $(this).val().split('$');
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            //alert(mys2[0].trim());
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];
            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];

            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice7]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type7 option:selected').val();

            $(".lay_file7").attr("style", "display:block");
            fabric7(GSM, CountConstruction);


            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth7]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth7]").val(CostWidth);
            }
            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate7]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate7]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate7]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
            $(".tr-fab").find("[id$=lblWidthCM7]").html(parseFloat(CostWidth * 2.54).toFixed(2));
            $(".tr-fab").find("[id$=hdnFabricID7]").val(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnDyedRate7]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate7]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate7]").val(DigitalPrintRate);

            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $(id).css("background-color", "#ffffaa");
                    $(id).css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $(id).css("background-color", "#bfbfbf");
                    $(id).css("color", "#FF0000");
                }
            });
        });

        $("input.fabric8", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/G2_new", {
            dataType: "xml", datakey: "string", max: 100, "width": "490px",
            extraParams:
                {
                    Print_Details: function () {
                        $(this).flushCache();
                        return PageStyleId + '##' + document.getElementById('<%=txtFabricType8.ClientID %>').value.replace('39681##', '');
                    },
                    PrintCategory: function () {
                        $(this).flushCache();
                        return printdetail = $('.fab_Type8 option:selected').val();
                    },
                    StyleId: $('input[type=text].costing-style-id').val()
                }
        });
        $("input.fabric8", '#main_content').result(function () {

            if ($(this).val().includes('Grg Rate(In)')) {
                $(this).val("");
                return;
            }
            var id = $(this);
            var Str = $(this).val();
            var mys = $(this).val().split('$');
            if (!mys[1]) {
                $(this).val("");
                return;
            }
            var mys2 = mys[1].split('**');
            $(this).val(mys2[0].trim());
            //alert(mys2[0].trim());
            var GSM = mys2[1];
            var CountConstruction = mys2[2];
            var CostWidth = mys2[3];
            var DyedRate = mys2[4];
            var PrintRate = mys2[5];
            var DigitalPrintRate = mys2[6];
            var mysf2 = mys2[7].split('<');
            var Fabric_Quality_Supplier_Specific = mysf2[0];

            //===============

            var objhlkQuality = $(".tr-fab").find("[id$=lblTotalPrice8]");
            var row = objhlkQuality.closest('tr');
            var td = objhlkQuality.closest('td');

            var ddlFabricType = $('.fab_Type8 option:selected').val();

            $(".lay_file8").attr("style", "display:block");
            fabric8(GSM, CountConstruction);


            // condition writen for ERN Only by Sanjeev on 09/02/2022
            if ($('#<%= ddlBuyer.ClientID %> option:selected').val() == "50") {
                $(".tr-fab").find("[id$=txtWidth8]").val(parseInt(CostWidth) + 1);
            }
            else {
                $(".tr-fab").find("[id$=txtWidth8]").val(CostWidth);
            }
            if (ddlFabricType == 0) {
                $(".tr-fab").find("[id$=txtRate8]").val(DyedRate);
            }
            if (ddlFabricType == 1) {
                $(".tr-fab").find("[id$=txtRate8]").val(PrintRate);
            }
            if (ddlFabricType == 2) {
                $(".tr-fab").find("[id$=txtRate8]").val(DigitalPrintRate);
            }
            //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
            $(".tr-fab").find("[id$=lblWidthCM8]").html(parseFloat(CostWidth * 2.54).toFixed(2));
            $(".tr-fab").find("[id$=hdnFabricID8]").val(Fabric_Quality_Supplier_Specific);
            $(".tr-fab").find("[id$=hdnDyedRate8]").val(DyedRate);
            $(".tr-fab").find("[id$=hdnPrintRate8]").val(PrintRate);
            $(".tr-fab").find("[id$=hdnDigitalPrintRate8]").val(DigitalPrintRate);

            CalculateCostingAmount(objhlkQuality);
            var RegisterFabricName = mys2[0];
            proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

                if (result[0].Acc == '1') {
                    $(id).css("background-color", "#ffffaa");
                    $(id).css("color", "#0000FF");
                }
                else if (result[0].Acc == '0') {
                    $(id).css("background-color", "#bfbfbf");
                    $(id).css("color", "#FF0000");
                }
            });
        });

        txtCostingFabric.blur(function () {
            //
            var txtWaste = this.id.replace('txtFabric', 'txtWaste'); var ClientId = 0; var Print_Details = '';
            txtWaste = $('#' + txtWaste)
            if ($(this).val() == '') {
                txtWaste.val(0);
            }
            else {
                if (txtWaste.val() == 0 || txtWaste.val() == '')
                    $(DeptDDClientID + 'option:selected').val();

                if ($("#" + hdnbuyerClientID).val() != 0)
                    ClientId = $("#" + hdnbuyerClientID).val();
                else
                    ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
                var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
                proxy.invoke("GetClientCostingBy_New", { ClientId: ClientId, DeptId: DeptId, StyleNumber: "", ExpectedQty: "-1" }, function (result) {
                    txtWaste.val(result[0].CostingWaste);
                });
            }
            txtWaste.keyup();
        });

        var penny = $("input[type=text].costing-landed-costing-penny");
        var percent = $("input[type=text].costing-landed-costing-percent");
        for (var i = 0; i < percent.length; i++) {
            var objCell = ($(percent[i]).closest('td'));
            AddRemoveSymbol(objCell, percent[i].value, '%', true);
        }

        penny.keyup(function (e) {//GC        
            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = $(this).closest("td");
            AddRemoveSymbol(objCell, $(this).val(), symbol, false, true);
        });

        percent.keyup(function (e) {//GC
            var objCell = $(this).closest("td");
            AddRemoveSymbol(objCell, $(this).val(), '%', false);
        });

        var inches = $("input[type=text].costing-landed-costing-inches");
        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

        for (var i = 0; i < inches.length; i++) {
            var objCell = ($(inches[i]).closest('div.inches'));
            AddRemoveSymbol(objCell, inches[i].value, '"', true);
        }

        for (var i = 0; i < penny.length; i++) {
            var objCell = ($(penny[i]).closest('td'));
            AddRemoveSymbol(objCell, penny[i].value, symbol, true, true);
        }

        inches.keyup(function (e) {//GC
            var objCell = $(this).closest("td");
            AddRemoveSymbol(objCell, $(this).val(), '"', false);
        });

        //GC Start
        $('#<%= txtTargetFOBPrice.ClientID %>').keyup(function (e) {
            // alert('txtTargetFOBPrice Key up ' + $(this).val());
            CalculateFOBBoutiqueValue($(this).val());
        });

        fobMargin.keyup(function (e) {
            // alert($('fobMargin Key up ' + '#<%= txtTargetFOBPrice.ClientID %>').val());
            CalculateFOBIkandiValue(this, $('#<%= txtTargetFOBPrice.ClientID %>').val());
        });
        function CalculateFOBIkandiValue(evnt, txtValue) {

            var fobmarginvalue = $(evnt).val();
            var row = $(evnt).closest('td');
            var fobikandivalue = row.prev().prev().prev().prev().prev().prev().find("input[type=text]");
            var value = row.prev().prev().prev().prev().prev().prev().find("input[type=text]").val();
            if (fobmarginvalue == 1 || isNaN(fobmarginvalue) || fobmarginvalue == "")
                fobikandivalue.val(0);
            else
                fobikandivalue.val((Math.round(txtValue / (1 - (fobmarginvalue / 100)) * 1000) / 1000).toFixed(2));
        }
        modeDeliveryTime.keyup(function (e) {
            CalculateDeliveryDate();
        });

        expectedDate.change(function (e) {
            expectedDate.val($(this).val());
            CalculateDeliveryDate();
        });

        deliveryDate.change(function (e) {
            CalculateLeadTime($(this));
        });

        //key up event surendra on 20-09-2018.
        grandTotalAF.keyup(function (e) {

            var evnt = $(this);
            var row = $(this).closest('tr');
            var txtGrandTotal = row.find('input:text[id$="txtGrandTotal"]');

            txtGrandTotal.val(GetGrandTotal(this));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtGrandTotal.closest("td");
            AddRemoveSymbol(objCell, txtGrandTotal.val(), symbol, true, true);
        });

        grandTotalAH.keyup(function (e) {

            var evnt = $(this);
            var row = $(this).closest('tr');
            var txtGrandTotal = row.find('input:text[id$="txtGrandTotal"]');

            txtGrandTotal.val(GetGrandTotalDC(this));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtGrandTotal.closest("td");
            AddRemoveSymbol(objCell, txtGrandTotal.val(), symbol, true, true);
        });

        $('select.costing-landed-costing-grand-total1').change(function (e) {

            var evnt = $(this);
            var row = $(this).closest('tr');
            var txtGrandTotal = row.find('input:text[id$="txtGrandTotal"]');

            txtGrandTotal.val(GetGrandTotal(this));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtGrandTotal.closest("td");
            AddRemoveSymbol(objCell, txtGrandTotal.val(), symbol, true, true);
        });
        CalculateCostingTotal(0);

        txtAmount.keyup(function (e) {
            //alert('txtAmount.keyup');
            DoKeyUpOperation(this, e, 'costing');
        });

        $(".costing-average").keyup(function (e) {
            CalculateCostingAmount(this);
        });

        $(".costing-rate").keyup(function (e) {
            CalculateCostingAmount(this);
        });

        txtWaste.change(function (e) {
            DoKeyUpOperation(this, e, 'costing');
        });

        $('#<%= ddlConvTo.ClientID %>').change(function () {
            //
            //  // 
            //    alert();
            // txtPriceAgreed 
            var currency = $('#ctl00_cph_main_content_CostingFormNew1_txtPriceQuoted').closest('td').find('span.penny').text();
            var Lpcurrency = $('#ctl00_cph_main_content_CostingFormNew1_txtLastPrice').closest('td').find('span.penny').text();
            $('input[type=text].costing-landed-costing-penny').closest('td').find('span.penny').text($(this).find('option:selected').text());
            if (Lpcurrency != "") {
                $('input[type=text].costing-landed-costing-penny.LpCurrency').closest('td').find('span.penny').text(Lpcurrency);
                $('input[type=text].costing-landed-costing-penny.PriceQuoteCurrency').closest('td').find('span.penny').text(Lpcurrency);
            } else {
                $('input[type=text].costing-landed-costing-penny.LpCurrency').closest('td').find('span.penny').text(currency);
                $('input[type=text].costing-landed-costing-penny.PriceQuoteCurrency').closest('td').find('span.penny').text(currency);
            }
            //  alert(currency);
        });

        txtTotalABC.change(function (e) {//GC
            // alert('txtTotalABC.change');
            //
            var total = 0;
            for (var i = 0; i < txtTotalABC.length; i++) {
                if (isNaN(txtTotalABC[i].value))
                    txtTotalABC[i].value = 0;

                total = total + +txtTotalABC[i].value;

            }
            var txtTotal = $('#<%= txtTotalABC.ClientID %>');
            //txtTotal.val((Math.round(total * 100) / 100).toFixed(2));
            txtTotal.val(Math.round(total));
            txtTotal.change();
        });

        finalCost.change(function () {//GC


            if (finalCost[1].value == "")
                finalCost[1].value = "0";
            if (finalCost[2].value == "")
                finalCost[2].value = "0";
            var txtInitCtcInInr = $('#<%= txtInitCtcInInr.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var Commission = parseFloat(txtDesingCommission.val());
            //txtInitCtcInInr.val(((1 + finalCost[1].value / 100 + finalCost[2].value / 100) * finalCost[0].value).toFixed(2)); 
            //var txtInitCtcInInrTxt = (parseFloat(finalCost[0].value) + parseFloat(finalCost[1].value) + parseFloat(finalCost[2].value)) / (1 - (parseFloat(finalCost[3].value + parseFloat(Commission)) / 100));
            var txtInitCtcInInrTxt = (parseFloat(finalCost[0].value) + parseFloat(finalCost[1].value) + parseFloat(finalCost[2].value)) / (1 - ((parseFloat(finalCost[3].value / 100) + (parseFloat(Commission) / 100))));

            txtInitCtcInInr.val((Math.round(txtInitCtcInInrTxt * 1000) / 1000).toFixed(2));
            //
            txtInitCtcInInr.change();
        });

        finalcommision.change(function () {//GC
            //

            if (finalCost[1].value == "")
                finalCost[1].value = "0";
            if (finalCost[2].value == "")
                finalCost[2].value = "0";
            var txtInitCtcInInr = $('#<%= txtInitCtcInInr.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');

            var Commission = parseFloat(txtDesingCommission.val());
            //txtInitCtcInInr.val(((1 + finalCost[1].value / 100 + finalCost[2].value / 100) * finalCost[0].value).toFixed(2));
            var txtInitCtcInInrTxt = (parseFloat(finalCost[0].value) + parseFloat(finalCost[1].value) + parseFloat(finalCost[2].value)) / (1 - ((parseFloat(finalCost[3].value / 100) + (parseFloat(Commission) / 100))));

            txtInitCtcInInr.val((Math.round(txtInitCtcInInrTxt * 1000) / 1000).toFixed(2));
            //
            txtInitCtcInInr.change();
        });


        finalCostCTC.change(function () {//GC

            $('#<%= hdnConvRate.ClientID %>').val(finalCostCTC[0].value);

            var txtUnitCtcInForeignCurr = $('#<%= txtUnitCtcInForeignCurr.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var Commission = parseFloat(txtDesingCommission.val());
            var unitCtcInFC = 0;

            if (finalCostCTC[1].value != 0)
                unitCtcInFC = (finalCostCTC[0].value / finalCostCTC[1].value);
            unitCtcInFC = (Math.round(unitCtcInFC * 1000) / 1000).toFixed(2);
            txtUnitCtcInForeignCurr.val(unitCtcInFC);
            txtUnitCtcInForeignCurr.change();
        });

        finalTotal.change(function () {//GC

            var txtTotal = $('#<%= txtTotal.ClientID %>');
            var txtTotalABC = $('#<%= txtTotalABC.ClientID %>');
            var txtFrtUptoFinalDest = $('#<%= txtFrtUptoFinalDest.ClientID %>');
            // var txtFrtUptoPort = '';
            var txtOverHead = $('#<%= txtOverHead.ClientID %>');
            var txtDesingCommission = $('#<%= txtDesingCommission.ClientID %>');
            var txtMarkupOnUnitCtc = $('#<%= txtMarkupOnUnitCtc.ClientID %>');
            var txtComm = $('#<%= txtComm.ClientID %>');

            var txtGCW = $('#<%= txtGCW.ClientID %>');
            var txtGVW = $('#<%= txtGVW.ClientID %>');

            var txtConvRate = $('#<%= txtConvRate.ClientID %>');
            var txtPercentProfit = '';
            var txtPriceAgreed = $('#<%= txtPriceAgreed.ClientID %>');
            var txtPriceQuoted = $('#<%= txtPriceQuoted.ClientID %>');
            var PriceAgreed = 0;
            //add by bhrarat 29-may
            var Quotedvalue = $(".IsChangeValue option:selected").val();
            if (txtPriceAgreed.val() == '') {
                PriceAgreed = txtPriceQuoted.val();

            }
            else {
                PriceAgreed = txtPriceAgreed.val();

            }
            //dinesh for value=0 display none
            //            if (txtGCW.val() == '0') {
            //                GCW = txtGCW.val('');

            //            }
            //            else {
            //                GCW = txtGCW.val();
            //            }

            if (txtGVW.val() == '') {
                GVW = txtGVW.val(0);
            }
            else {
                GVW = txtGVW.val();
            }

            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();

            var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

            var ExpectedQty = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();

            var StyleNumber = $('.costing-style-number-view').val();

            proxy.invoke("GetClientCostingBy_New", { ClientId: ClientId, DeptId: DeptId, StyleNumber: StyleNumber, ExpectedQty: ExpectedQty }, function (result) {
                if (result != null && result.length > 0) {

                    var IsOldOverHead = result[0].IsOldOverHead;

                    var OverHeadPercentValue = result[0].OHValue_ForPercent;

                    var OverHeadPercent = result[0].OHPercent;

                    var txtTotalLeft = parseFloat(txtTotalABC.val()) + parseFloat(txtFrtUptoFinalDest.val());

                    var txtMarkupOnUnitCtcc = 0;
                    if ($('#ctl00_cph_main_content_CostingFormNew1_txtMarkupOnUnitCtc').val() == "" || $('#ctl00_cph_main_content_CostingFormNew1_txtMarkupOnUnitCtc').val() == "." || $('#ctl00_cph_main_content_CostingFormNew1_txtMarkupOnUnitCtc').val() == "0.") {
                        txtMarkupOnUnitCtcc = 0;
                    }
                    else {
                        txtMarkupOnUnitCtcc = $('#ctl00_cph_main_content_CostingFormNew1_txtMarkupOnUnitCtc').val();
                    }

                    var txtCommm = 0;
                    if ($('#ctl00_cph_main_content_CostingFormNew1_txtComm').val() == "" || $('#ctl00_cph_main_content_CostingFormNew1_txtComm').val() == "." || $('#ctl00_cph_main_content_CostingFormNew1_txtComm').val() == "0.") {
                        txtCommm = 0;
                    }
                    else {
                        txtCommm = $('#ctl00_cph_main_content_CostingFormNew1_txtComm').val();
                    }

                    var GVWW = 0;
                    if ($('#ctl00_cph_main_content_CostingFormNew1_txtGVW').val() == "" || $('#ctl00_cph_main_content_CostingFormNew1_txtGVW').val() == "." || $('#ctl00_cph_main_content_CostingFormNew1_txtGVW').val() == "0.") {
                        GVWW = 0;
                    }
                    else {
                        GVWW = $('#ctl00_cph_main_content_CostingFormNew1_txtGVW').val();
                    }

                    var txtTotalRight = txtTotalRight = 1 - (parseFloat(txtCommm) / 100) - (parseFloat(txtMarkupOnUnitCtcc) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(txtOverHead.val()) / 100) - (parseFloat(txtGCW.val()) / 100) - (parseFloat(GVWW) / 100);
                    var txtTotalRight2 = txtTotalRight2 = 1 - (parseFloat(txtCommm) / 100) - (parseFloat(txtMarkupOnUnitCtcc) / 100) - (parseFloat(txtDesingCommission.val()) / 100) - (parseFloat(txtGCW.val()) / 100) - (parseFloat(GVWW) / 100);
                    var txtTotalTxt = 0;



                    if (IsOldOverHead.toString() == "true" && ExpectedQtyChange == "false") {
                        if (OverHeadPercent == 1) {
                            txtTotalTxt = (parseFloat(txtTotalLeft) / parseFloat(txtTotalRight)) / parseFloat(txtConvRate.val());
                            percentsign.innerHTML = "%";
                        }
                        else {
                            txtTotalTxt = ((parseFloat(txtTotalLeft) / parseFloat(txtTotalRight2)) + OverHeadPercentValue) / parseFloat(txtConvRate.val());
                        }
                        txtTotal.val((Math.round(txtTotalTxt * 100) / 100).toFixed(2));

                    }

                    else {
                        txtTotalTxt = ((parseFloat(txtTotalLeft) / parseFloat(txtTotalRight2)) + OverHeadPercentValue) / parseFloat(txtConvRate.val());
                        txtTotal.val((Math.round(txtTotalTxt * 100) / 100).toFixed(2));
                    }


                    var objCell = txtTotal.closest("td");
                    var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                    AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
                }
            });
        });


        $('.costing-price-quoted').change(function (e) {//GC page load W %

            var txtFOBBoutique = $('#<%= txtFOBBoutique.ClientID %>');
            txtFOBBoutique.val($(this).val());

            var objCell = (txtFOBBoutique.closest('td'));
            AddRemoveSymbol(objCell, txtFOBBoutique.val(), symbol, true, true);

            var txtTargetFOBPrice = $('#<%= txtTargetFOBPrice.ClientID %>');

            //if(txtTargetFOBPrice.val() == '')
            //{
            txtTargetFOBPrice.val($(this).val());
            txtTargetFOBPrice.keyup();

            objCell = (txtTargetFOBPrice.closest('td'));
            AddRemoveSymbol(objCell, txtTargetFOBPrice.val(), symbol, true, true);
            //}

        });

        CalculateFOBBoutiqueValue($('#<%= txtTargetFOBPrice.ClientID %>').val());
        CalculateDeliveryDate();

        $('#<%= txtTargetFOBPrice.ClientID %>').keyup();
        $('.costing-price-quoted').change();

        $(".fab_Type1").change(function (e) {


            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate1]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate1]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate1]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('.costing-print-table').addClass('hide_me');
            $(this).closest('tr').find('input[type=text].fabric-type').val('');
            FabricPrintSugg1();
            //            FabricPrintSugg2();
            //            FabricPrintSugg3();
            //            FabricPrintSugg4();
            //            FabricPrintSugg5();
            //            FabricPrintSugg6();
            //            FabricPrintSugg7();
            //            FabricPrintSugg8();
            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        $(".fab_Type2").change(function (e) {

            // alert("check");
            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate2]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate2]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate2]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('.costing-print-table').addClass('hide_me');
            $(this).closest('tr').find('input[type=text].fabric-type').val('');
            // FabricPrintSugg1();
            FabricPrintSugg2();
            //            FabricPrintSugg3();
            //            FabricPrintSugg4();
            //            FabricPrintSugg5();
            //            FabricPrintSugg6();
            //            FabricPrintSugg7();
            //            FabricPrintSugg8();
            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        $(".fab_Type3").change(function (e) {

            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate3]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate3]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate3]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('input[type=text].fabric-type').val('');
            //            FabricPrintSugg1();
            //            FabricPrintSugg2();
            FabricPrintSugg3();
            //            FabricPrintSugg4();
            //            FabricPrintSugg5();
            //            FabricPrintSugg6();
            //            FabricPrintSugg7();
            //            FabricPrintSugg8();
            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        $(".fab_Type4").change(function (e) {

            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate4]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate4]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate4]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('.costing-print-table').addClass('hide_me');
            $(this).closest('tr').find('input[type=text].fabric-type').val('');

            FabricPrintSugg4();

            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        $(".fab_Type5").change(function (e) {

            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate5]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate5]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate5]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('.costing-print-table').addClass('hide_me');
            $(this).closest('tr').find('input[type=text].fabric-type').val('');

            FabricPrintSugg5();

            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        $(".fab_Type6").change(function (e) {

            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate6]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate6]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate6]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('.costing-print-table').addClass('hide_me');
            $(this).closest('tr').find('input[type=text].fabric-type').val('');

            FabricPrintSugg6();
            //            FabricPrintSugg7();
            //            FabricPrintSugg8();
            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        $(".fab_Type7").change(function (e) {

            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate7]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate7]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate7]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('.costing-print-table').addClass('hide_me');
            $(this).closest('tr').find('input[type=text].fabric-type').val('');

            FabricPrintSugg7();
            FabricPrintSugg8();
            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        $(".fab_Type8").change(function (e) {

            var suplier = ''; var trade; var index;
            var fabType = $(this).closest('tr').find('.costing-ddlFabricType option:selected').val();
            var DyedRate = $(this).closest('tr').find("[id$=hdnDyedRate8]").val();
            var PrintRate = $(this).closest('tr').find("[id$=hdnPrintRate8]").val();
            var DigitalPrintRate = $(this).closest('tr').find("[id$=hdnDigitalPrintRate8]").val();
            var objhlkQuality = $(this).closest('tr').find('input[type=text].costing-fabric');
            var fabric_Suplier = $(this).closest('tr').find('input[type=text].costing-fabric').val();
            var txtrate = $(this).closest('tr').find('input.costing-rate');

            $(this).closest('tr').find('.costing-print-table').addClass('hide_me');
            $(this).closest('tr').find('input[type=text].fabric-type').val('');

            FabricPrintSugg8();
            if (fabric_Suplier != '') {
                if (fabType == 0) {
                    txtrate.val(DyedRate);
                }
                if (fabType == 1) {
                    txtrate.val(PrintRate);
                }
                if (fabType == 2) {
                    txtrate.val(DigitalPrintRate);
                }
                CalculateCostingAmount(objhlkQuality);
            }
        });

        //        $('.costing-style-number-view').blur(function () {//GC
        //            GetCostingData();
        //        });

        function parseBetween(beginString, endString, originalString) {
            var beginIndex = originalString.indexOf(beginString);
            if (beginIndex === -1) {
                return null;
            }
            var beginStringLength = beginString.length;
            var substringBeginIndex = beginIndex + beginStringLength;
            var substringEndIndex = originalString.indexOf(endString, substringBeginIndex);
            if (substringEndIndex === -1) {
                return null;
            }
            return originalString.substring(substringBeginIndex, substringEndIndex);
        }

        function CostingDeptChange() { //GC NTU



            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
            var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

            proxy.invoke("GetClientCostingBy_New", { ClientId: ClientId, DeptId: DeptId, StyleNumber: "", ExpectedQty: "-1" }, function (result) {
                $('#<%= txtComm.ClientID %>').val(result[0].CommisionPercent);
                $('.converto').val(result[0].ConvertTo)

                $('#<%= hdnConvertTo.ClientID %>').val(result[0].ConvertTo);
                $('#<%= txtMarkupOnUnitCtc.ClientID %>').val(result[0].MarkupOnUnitCTC);
                $('#<%= txtOverHead.ClientID %>').val(result[0].OverHead);

                $('#<%= txtFrtUptoFinalDest.ClientID %>').val(result[0].FrieghtUptoPort);
                $('#<%= txtDesingCommission.ClientID %>').val(result[0].DesignCommission);
                //$('txtFrtUptoPort').val(result[0].FrieghtUptoPort);
                $('#<%= hdnAch.ClientID %>').val(result[0].Achivement);
                //$('#<%= txtExpectedQuant.ClientID %>').val(result[0].ExpectedQty);
                $('#<%= ddlExpectedQty.ClientID %> option[value=' + result[0].ExpectedQty + ']').attr('selected', 'selected');
                $('#<%= hdnAch.ClientID %>').val(result[0].Achivement);
                $('#<%=gdvAccessory.ClientID%>').find('input:text[id$="txtItems"]').each(function () {
                    var id = $(this).val();
                    var td = $("td", $(this).closest("tr"));

                    if (id == "Coffin Box") {
                        $("[id$=txtUnitQty]", td).val(1);
                        $("[id$=txtRate]", td).val(result[0].CoffinBox);
                    }
                    else if (id == "Lbls,Tgs,Pcg & Ins.") {
                        $("[id$=txtUnitQty]", td).val(1);
                        $("[id$=txtRate]", td).val(result[0].LBL_TAGS);
                    }
                    else if (id == "Test") {
                        $("[id$=txtUnitQty]", td).val(1);
                        $("[id$=txtRate]", td).val(result[0].TEST);
                    }
                    else if (id == "Hangers") {
                        $("[id$=txtUnitQty]", td).val(1);
                        $("[id$=txtRate]", td).val(result[0].Hangers);
                    }
                    else if (id == "Hanger Loops") {
                        $("[id$=txtUnitQty]", td).val(1);
                        $("[id$=txtRate]", td).val(result[0].HANGER_LOOPS);
                    }
                });
                //
                GetCMTValue();
                CalculateAccessoriesTotal(null);
                GetNewConversion();
                TotalProcessAmount();
                ClientCurrency();
            });
        }


    });                                                                                                                                                                                                           //Ready Function Closed

    function CalculateCM(srcElem) {
        //  // 
        var thisval = srcElem.value;
        var PreviousVal = srcElem.defaultValue;
        var widthno = srcElem.id.split('txtWidth');
        var clacVal = Math.round(parseFloat(thisval * 2.54).toFixed(2));
        $(".tr-fab").find("[id$=lblWidthCM" + widthno[1] + "]").html(clacVal);

        var UserID = parseInt($("#" + hdnuseridClientID).val());
        if (UserID == "5") {
            if (thisval != "") {
                if (PreviousVal != thisval) {
                    SaveIkandiHide();
                }
            }
        }
    }
    function CheckFabricName(srcElem, FabricType) {

        var l;
        var s = 0;

        var FabricArray = new Array();
        var TempId = srcElem.id;
        var thisId = srcElem.id.split('_')[5];
        var lastid = thisId.slice(-1);
        var n = TempId.split('txtFabricType');
        var RegisterPrint = srcElem.value;
        var GrdRowCount = $("tr.rowCount").length;
        fabricTyle = RegisterPrint;
        var fabtype = '';
        var fabricname = '';

        var PreviousVal = srcElem.defaultValue;

        if (FabricType == lastid) {
            //  // 
            var objhlkQuality = $("#ctl00_cph_main_content_CostingFormNew1_lblTotalPrice" + lastid);
            RegisterFabricName1 = $("#ctl00_cph_main_content_CostingFormNew1_txtFabric" + lastid).val();
            var fabricname = RegisterFabricName1;
            var fabtype = $("#ctl00_cph_main_content_CostingFormNew1_DDLFabricType" + lastid).val();
            //                fabricname = document.getElementById('<%=txtFabric1.ClientID%>').value;

            if (fabtype == 0) {
                if (RegisterPrint == "--Linked to Style--") {
                    srcElem.value = '';
                    return;
                }
            }
            if (fabtype == 1 || fabtype == 2) {

                if (RegisterPrint != "") {
                    proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
                        if (result[0].Acc == '0') {
                            srcElem.value = '';
                            return;
                        }
                    });
                }

                proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
                    // document.getElementById('<%=txtRate1.ClientID%>').value = result[0].Acc;
                    document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtRate" + lastid).value = result[0].Acc;
                    CalculateCostingAmount(objhlkQuality);
                });
            }
            //  // 
            //                var ValueAdditionId = $('#ctl00_cph_main_content_CostingFormNew1_ddlValueAddition' + lastid + '_1')[0].selectedIndex;
            //                if (ValueAdditionId < 0) {

            //                    $('#ctl00_cph_main_content_CostingFormNew1_ddlValueAddition' + lastid + '_1').append($("<option></option>").val('-1').html('Select'));
            //                    $('#ctl00_cph_main_content_CostingFormNew1_ddlValueAddition' + lastid + '_2').append($("<option></option>").val('-1').html('Select'));

            //                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
            //                        $.each(result, function (key, value) {
            //                            //  // 
            //                            $('#ctl00_cph_main_content_CostingFormNew1_ddlValueAddition' + lastid + '_1').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
            //                            $('#ctl00_cph_main_content_CostingFormNew1_ddlValueAddition' + lastid + '_2').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

            //                        });

            //                    });
            //                }
        }

        if (FabricType == 1) {
            // this code commented by bharat on 13-Oct-2020
            //            var fabtype1 = $('.fab_Type1 option:selected').val()
            //             fabtype = fabtype1;
            //             fabricname = document.getElementById('<%=txtFabric1.ClientID%>').value;
            //           
            //             if (fabtype1 == 1 || fabtype1 == 2) {

            //                if (RegisterPrint != "") {
            //                    proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            //                        if (result[0].Acc == '0') {

            //                          document.getElementById('<%=txtFabricType1.ClientID%>').value = "";
            //                            return;
            //                        }
            //                    });
            //                }
            //               // // // 
            //                proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                    document.getElementById('<%=txtRate1.ClientID%>').value = result[0].Acc;
            //                    CalculateCostingAmount(objhlkQuality1);
            //                });
            //            }
            //  // 
            var ValueAdditionId = $('#<%= ddlValueAddition1_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {

                $('#<%= ddlValueAddition1_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition1_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition1_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition1_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });

                });
            }

        }
        if (FabricType == 2) {
            // this code commented by bharat on 13-Oct-2020

            //            var fabtype2 = $('.fab_Type2 option:selected').val()
            //             fabtype = fabtype2;
            //             fabricname = document.getElementById('<%=txtFabric2.ClientID%>').value;
            //          
            //            if (fabtype2 == 1 || fabtype2 == 2) {
            //                if (RegisterPrint != "") {

            //                    proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {

            //                        if (result[0].Acc == '0') {

            //                           document.getElementById('<%=txtFabricType2.ClientID%>').value = "";
            //                            return;
            //                        }
            //                    });
            //                }
            //                proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                    document.getElementById('<%=txtRate2.ClientID%>').value = result[0].Acc;

            //                    CalculateCostingAmount(objhlkQuality2);
            //                });
            //            }
            var ValueAdditionId = $('#<%= ddlValueAddition2_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {
                $('#<%= ddlValueAddition2_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition2_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition2_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition2_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });
                });
            }
        }
        if (FabricType == 3) {
            // this code commented by bharat on 13-Oct-2020
            //             var fabtype3 = $('.fab_Type3 option:selected').val()
            //              fabtype = fabtype3;
            //              fabricname = document.getElementById('<%=txtFabric3.ClientID%>').value;
            //           
            //             if (fabtype3 == 1 || fabtype3 == 2) {
            //                 if (RegisterPrint != "") {
            //                     proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            //                         if (result[0].Acc == '0') {

            //                            document.getElementById('<%=txtFabricType3.ClientID%>').value = "";
            //                             return;
            //                         }
            //                     });
            //                 }
            //                 proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                     document.getElementById('<%=txtRate3.ClientID%>').value = result[0].Acc;
            //                     CalculateCostingAmount(objhlkQuality3);
            //                 });
            //             }
            var ValueAdditionId = $('#<%= ddlValueAddition3_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {
                $('#<%= ddlValueAddition3_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition3_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition3_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition3_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });
                });
            }
        }
        if (FabricType == 4) {
            // this code commented by bharat on 13-Oct-2020
            //            var fabtype4 = $('.fab_Type4 option:selected').val()
            //             fabtype = fabtype4;
            //             fabricname = document.getElementById('<%=txtFabric4.ClientID%>').value;

            //         
            //            if (fabtype4 == 1 || fabtype4 == 2) {
            //                if (RegisterPrint.toString() != "") {
            //                    proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            //                        if (result[0].Acc == '0') {
            //                            document.getElementById('<%=txtFabricType4.ClientID%>').value = "";
            //                            return;
            //                        }
            //                    });
            //                }
            //                proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                    document.getElementById('<%=txtRate4.ClientID%>').value = result[0].Acc;
            //                    CalculateCostingAmount(objhlkQuality4);
            //                });
            //            }
            var ValueAdditionId = $('#<%= ddlValueAddition4_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {
                $('#<%= ddlValueAddition4_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition4_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition4_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition4_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });
                });
            }
        }
        if (FabricType == 5) {
            // this code commented by bharat on 13-Oct-2020
            //             var fabtype5 = $('.fab_Type5 option:selected').val()
            //             fabtype = fabtype5;
            //              fabricname = document.getElementById('<%=txtFabric5.ClientID%>').value;
            //         
            //             
            //             if (fabtype5 == 1 || fabtype5 == 2) {
            //                 proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            //                     if (result[0].Acc == '0') {
            //                         document.getElementById('<%=txtFabricType5.ClientID%>').value = "";
            //                         return;
            //                     }
            //                     
            //                 });
            //             }
            //             proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                 document.getElementById('<%=txtRate5.ClientID%>').value = result[0].Acc;
            //                 CalculateCostingAmount(objhlkQuality5);
            //             });

            var ValueAdditionId = $('#<%= ddlValueAddition5_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {
                $('#<%= ddlValueAddition5_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition5_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition5_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition5_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });
                });
            }
        }
        if (FabricType == 6) {
            // this code commented by bharat on 13-Oct-2020
            //             var fabtype6 = $('.fab_Type6 option:selected').val()
            //             fabtype = fabtype6;
            //              fabricname = document.getElementById('<%=txtFabric6.ClientID%>').value;
            //            
            //             if (fabtype6 == 1 || fabtype6 == 2) {
            //                 proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            //                     if (result[0].Acc == '0') {
            //                       document.getElementById('<%=txtFabricType6.ClientID%>').value = "";
            //                         return;
            //                     }
            //                     
            //                 });
            //             }

            //             proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                 document.getElementById('<%=txtRate6.ClientID%>').value = result[0].Acc;
            //                 CalculateCostingAmount(objhlkQuality6);
            //             });

            var ValueAdditionId = $('#<%= ddlValueAddition6_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {
                $('#<%= ddlValueAddition6_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition6_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition6_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition6_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });
                });
            }
        }
        if (FabricType == 7) {
            // this code commented by bharat on 13-Oct-2020
            //             var fabtype7 = $('.fab_Type7 option:selected').val()
            //             fabtype = fabtype7;
            //              fabricname = document.getElementById('<%=txtFabric7.ClientID%>').value;
            //            
            //             if (fabtype7 == 1 || fabtype7 == 2) {
            //                 proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            //                     if (result[0].Acc == '0') {
            //                         //document.getElementById('<%=txtFabricType7.ClientID%>').value = "";
            //                         return;
            //                     }
            //                     else {
            //                        
            //                     }
            //                 });
            //             }

            //             proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                 document.getElementById('<%=txtRate7.ClientID%>').value = result[0].Acc;
            //                 CalculateCostingAmount(objhlkQuality7);
            //             });

            var ValueAdditionId = $('#<%= ddlValueAddition7_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {
                $('#<%= ddlValueAddition7_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition7_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition7_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition7_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });
                });
            }
        }
        if (FabricType == 8) {
            // this code commented by bharat on 13-Oct-2020
            //             var fabtype8 = $('.fab_Type8 option:selected').val()
            //             fabtype = fabtype8;
            //              fabricname = document.getElementById('<%=txtFabric8.ClientID%>').value;
            //          
            //             if (fabtype8 == 1 || fabtype8 == 2) {
            //                 proxy.invoke("Get_Register_Print", { RegisterPrint: RegisterPrint }, function (result) {
            //                     if (result[0].Acc == '0') {
            //                         document.getElementById('<%=txtFabricType8.ClientID%>').value = "";
            //                         return;
            //                     }
            //                     
            //                 });
            //             }


            //             proxy.invoke("Get_Final_Rate_From_PO", { fabricname: fabricname, fabtype: fabtype, RegisterPrint: RegisterPrint }, function (result) {
            //                 document.getElementById('<%=txtRate8.ClientID%>').value = result[0].Acc;
            //                 CalculateCostingAmount(objhlkQuality8);
            //             });

            var ValueAdditionId = $('#<%= ddlValueAddition8_1.ClientID %>')[0].selectedIndex;
            if (ValueAdditionId < 0) {
                $('#<%= ddlValueAddition8_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                $('#<%= ddlValueAddition8_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                    $.each(result, function (key, value) {
                        //  // 
                        $('#<%= ddlValueAddition8_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                        $('#<%= ddlValueAddition8_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                    });
                });
            }
        }
        //  // 
        //   for (var k = 1; k <= GrdRowCount; k++) {
        //            if (i == 1) {
        //                if (document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtFabric" + k) != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtFabric" + k).value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = k }
        //                    else {
        //                        var fabricname = document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtFabric" + k).value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type' + k + 'option:selected').val();
        //                        var print = document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtFabric" + k).value.replace(/^\s+|\s+$/g, '');

        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                       
        //                    }
        // }
        //  }
        //            else if (i == 2) {
        //                if (document.getElementById('<%=txtFabric2.ClientID%>') != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById('<%=txtFabric2.ClientID%>').value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = i }
        //                    else {
        //                        var fabricname = document.getElementById('<%=txtFabric2.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type2 option:selected').val();
        //                        var print = document.getElementById('<%=txtFabricType2.ClientID%>').value.replace(/^\s+|\s+$/g, '');

        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                       
        //                    }
        //                }
        //            }
        //            else if (i == 3) {
        //                if (document.getElementById('<%=txtFabric3.ClientID%>') != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById('<%=txtFabric3.ClientID%>').value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = i }
        //                    else {
        //                        var fabricname = document.getElementById('<%=txtFabric3.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type3 option:selected').val();
        //                        var print = document.getElementById('<%=txtFabricType3.ClientID%>').value.replace(/^\s+|\s+$/g, '');

        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                       
        //                    }
        //                }
        //            }
        //            else if (i == 4) {
        //                if (document.getElementById('<%=txtFabric4.ClientID%>') != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById('<%=txtFabric4.ClientID%>').value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = i }
        //                    else {
        //                        var fabricname = document.getElementById('<%=txtFabric4.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type4 option:selected').val();
        //                        var print = document.getElementById('<%=txtFabricType4.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                        
        //                    }
        //                }
        //            }
        //            else if (i == 5) {
        //                if (document.getElementById('<%=txtFabric5.ClientID%>') != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById('<%=txtFabric5.ClientID%>').value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = i }
        //                    else {
        //                        var fabricname = document.getElementById('<%=txtFabric5.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type5 option:selected').val();
        //                        var print = document.getElementById('<%=txtFabricType5.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                       
        //                    }
        //                }
        //            }
        //            else if (i == 6) {
        //                if (document.getElementById('<%=txtFabric6.ClientID%>') != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById('<%=txtFabric6.ClientID%>').value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = i }
        //                    else {
        //                        var fabricname = document.getElementById('<%=txtFabric6.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type6 option:selected').val();
        //                        var print = document.getElementById('<%=txtFabricType6.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                        
        //                    }
        //                }
        //            }
        //            else if (i == 7) {
        //                if (document.getElementById('<%=txtFabric7.ClientID%>') != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById('<%=txtFabric7.ClientID%>').value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = i }
        //                    else {
        //                        var fabricname = document.getElementById('<%=txtFabric7.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type7 option:selected').val();
        //                        var print = document.getElementById('<%=txtFabricType7.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                       
        //                    }
        //                }
        //            }
        //            else if (i == 8) {
        //                if (document.getElementById('<%=txtFabric8.ClientID%>') != undefined) {
        //                    var s = s + 1;
        //                    l = FabricArray.length;
        //                    if (document.getElementById('<%=txtFabric8.ClientID%>').value.replace(/^\s+|\s+$/g, '') == "")
        //                    { FabricArray[l] = i }
        //                    else {
        //                        var fabricname = document.getElementById('<%=txtFabric8.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        var fabtype = $('.fab_Type8 option:selected').val();
        //                        var print = document.getElementById('<%=txtFabricType8.ClientID%>').value.replace(/^\s+|\s+$/g, '');
        //                        FabricArray[l] = (fabricname + '---' + fabtype + '---' + print).toLowerCase();
        //                        
        //                    }
        //                }
        //            }
        //        }
        //        //  FabricArray.sort();

        for (var k = 1; k <= GrdRowCount; k++) {

            var fabrictypename = $("#ctl00_cph_main_content_CostingFormNew1_txtFabricType" + k).val();

            if (fabrictypename != "") {

                if (lastid != k) {

                    if (fabrictypename == fabricTyle) {
                        var RegisterFabrname = $("#ctl00_cph_main_content_CostingFormNew1_txtFabric" + k).val();
                        if (RegisterFabrname == RegisterFabricName1) {
                            alert('Duplicate Fabric & Color Found. ');
                            srcElem.value = "";
                            document.getElementById(TempId).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtRate" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtWidth" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_lblWidthCM" + lastid).innerHTML = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnFabricID" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnDyedRate" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnPrintRate" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnDigitalPrintRate" + lastid).value = "";
                            //                            $(".tr-fab").find("[id$=txtRate" + n[1] + "]").val("");
                            //                            $(".tr-fab").find("[id$=txtWidth" + n[1] + "]").val("");
                            //                            $(".tr-fab").find("[id$=lblWidthCM" + n[1] + "]").html("");
                            //                            $(".tr-fab").find("[id$=hdnFabricID" + n[1] + "]").val("");
                            //                            $(".tr-fab").find("[id$=hdnDyedRate" + n[1] + "]").val("");
                            //                            $(".tr-fab").find("[id$=hdnPrintRate" + n[1] + "]").val("");
                            //                            $(".tr-fab").find("[id$=hdnDigitalPrintRate" + n[1] + "]").val("");
                            $(".lay_file" + lastid + "").attr("style", "display:none");
                            $('table #costing_print_table' + lastid).addClass('hide_me');


                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_txtFabric' + lastid).value = "";

                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_COUNTCON' + lastid).innerHTML = "";

                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_GSML' + lastid).innerHTML = "";
                            $('.fab_Type' + lastid + 'option[value=2]').attr('selected', 'selected');
                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_txtFabric' + lastid).focus();

                        }
                    }
                }
            }

            //            if (FabricArray[ww - 1] == FabricArray[ww]) {
            //                // // 
            //                var fields = FabricArray[ww - 1].split('---0---');
            //             
            //                var AnoFields = FabricArray[ww].split('---0---');
            //              
            //                //this code updated by bharat 22-may
            //                var FabName = fields[0];
            //                var FabColor = fields[2];
            //                var AnoColor = AnoFields[2];

            //                if (FabColor == AnoColor) {
            //                    alert('Duplicate Fabric & Color Found. ');
            //                    document.getElementById(TempId).value = "";
            //                    $(".tr-fab").find("[id$=txtRate" + n[1] + "]").val("");
            //                    $(".tr-fab").find("[id$=txtWidth" + n[1] + "]").val("");
            //                    $(".tr-fab").find("[id$=lblWidthCM" + n[1] + "]").html("");
            //                    $(".tr-fab").find("[id$=hdnFabricID" + n[1] + "]").val("");
            //                    $(".tr-fab").find("[id$=hdnDyedRate" + n[1] + "]").val("");
            //                    $(".tr-fab").find("[id$=hdnPrintRate" + n[1] + "]").val("");
            //                    $(".tr-fab").find("[id$=hdnDigitalPrintRate" + n[1] + "]").val("");
            //                    $(".lay_file" + n[1] + "").attr("style", "display:none");
            //                    $('table #costing_print_table' + n[1]).addClass('hide_me');

            //                    if (n[1] == 1) {
            //                        document.getElementById('<%=txtFabric1.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML.ClientID%>').innerHTML = "";
            //                        $('.fab_Type1 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric1.ClientID%>').focus();
            //                    }
            //                    else if (n[1] == 2) {
            //                        document.getElementById('<%=txtFabric2.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML2.ClientID%>').innerHTML = "";
            //                        $('.fab_Type2 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric2.ClientID%>').focus();
            //                    }
            //                    else if (n[1] == 3) {
            //                        document.getElementById('<%=txtFabric3.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML3.ClientID%>').innerHTML = "";
            //                        $('.fab_Type3 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric3.ClientID%>').focus();
            //                    }
            //                    else if (n[1] == 4) {
            //                        document.getElementById('<%=txtFabric4.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML4.ClientID%>').innerHTML = "";
            //                        $('.fab_Type4 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric4.ClientID%>').focus();
            //                    }
            //                    else if (n[1] == 5) {
            //                        document.getElementById('<%=txtFabric5.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML5.ClientID%>').innerHTML = "";
            //                        $('.fab_Type5 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric5.ClientID%>').focus();
            //                    }
            //                    else if (n[1] == 6) {
            //                        document.getElementById('<%=txtFabric6.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML6.ClientID%>').innerHTML = "";
            //                        $('.fab_Type6 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric6.ClientID%>').focus();
            //                    }
            //                    else if (n[1] == 7) {
            //                        document.getElementById('<%=txtFabric7.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML7.ClientID%>').innerHTML = "";
            //                        $('.fab_Type7 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric7.ClientID%>').focus();
            //                    }
            //                    else if (n[1] == 8) {
            //                        document.getElementById('<%=txtFabric8.ClientID%>').value = "";
            //                        document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML = "";
            //                        document.getElementById('<%=GSML8.ClientID%>').innerHTML = "";
            //                        $('.fab_Type8 option[value=2]').attr('selected', 'selected');
            //                        document.getElementById('<%=txtFabric8.ClientID%>').focus();
            //                    }
            //                    break;
            //                }
            //            }
        }
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        if (UserID == "5") {
            if (RegisterPrint != "") {
                if (RegisterPrint.length > 4) {
                    if (PreviousVal != RegisterPrint) {
                        SaveIkandiHide();
                    }
                }
            }
        }
    }

    function ChangeValueAddition(srcElem) {
        //  // 
        var TempId = srcElem.id;
        var Id = TempId.split('ddlValueAddition')[1];
        var Seqno = Id.split("_")[0];
        var type = Id.split("_")[1];
        var ValueAdditionId = srcElem.value;

        if (Id == '1_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId1_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId1_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric1, Please Select another");
                $('#<%= ddlValueAddition1_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '1_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId1_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId1_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric1, Please Select another");
                $('#<%= ddlValueAddition1_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '2_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId2_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId2_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric2, Please Select another");
                $('#<%= ddlValueAddition2_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '2_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId2_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId2_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric2, Please Select another");
                $('#<%= ddlValueAddition2_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '3_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId3_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId3_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric3, Please Select another");
                $('#<%= ddlValueAddition3_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '3_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId3_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId3_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric3, Please Select another");
                $('#<%= ddlValueAddition3_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '4_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId4_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId4_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric4, Please Select another");
                $('#<%= ddlValueAddition4_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '4_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId4_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId4_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric4, Please Select another");
                $('#<%= ddlValueAddition4_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '5_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId5_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId5_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric5, Please Select another");
                $('#<%= ddlValueAddition5_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '5_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId5_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId5_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric5, Please Select another");
                $('#<%= ddlValueAddition5_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '6_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId6_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId6_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric6, Please Select another");
                $('#<%= ddlValueAddition6_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '6_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId6_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId6_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric6, Please Select another");
                $('#<%= ddlValueAddition6_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '7_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId7_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId7_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric7, Please Select another");
                $('#<%= ddlValueAddition7_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '7_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId7_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId7_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric7, Please Select another");
                $('#<%= ddlValueAddition7_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '8_1') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId8_1.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId8_2.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric8, Please Select another");
                $('#<%= ddlValueAddition8_1.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }
        if (Id == '8_2') {
            var ValueAdditionIdOld = $('#<%= hdnValueAdditionId8_2.ClientID %>').val();
            var ValueAdditionIdDuplicate = $('#<%= hdnValueAdditionId8_1.ClientID %>').val();

            if ((ValueAdditionIdDuplicate > 0) && (ValueAdditionId == ValueAdditionIdDuplicate)) {
                alert("This ValueAddition is already used for fabric8, Please Select another");
                $('#<%= ddlValueAddition8_2.ClientID %>').val(ValueAdditionIdOld);
                return false;
            }
        }

        var WastageId = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();
        var styleId = $('input[type=text].costing-style-id').val();

        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: Seqno, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: type }, function (result) {
            //  // 
            //Fabric 1             

            if (Id == '1_1') {
                $('#<%= hdnValueAdditionId1_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage1_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage1_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency1_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate1_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate1_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency1_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '1_2') {
                $('#<%= hdnValueAdditionId1_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage1_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage1_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency1_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate1_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate1_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency1_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            //Fabric 2           
            if (Id == '2_1') {
                $('#<%= hdnValueAdditionId2_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage2_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage2_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency2_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate2_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate2_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency2_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '2_2') {
                $('#<%= hdnValueAdditionId2_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage2_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage2_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency2_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate2_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate2_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency2_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            //Fabric 3           
            if (Id == '3_1') {
                $('#<%= hdnValueAdditionId3_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage3_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage3_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency3_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate3_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate3_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency3_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '3_2') {
                $('#<%= hdnValueAdditionId3_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage3_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage3_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency3_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate3_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate3_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency3_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            //Fabric 4           
            if (Id == '4_1') {
                $('#<%= hdnValueAdditionId4_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage4_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage4_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency4_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate4_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate4_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency4_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '4_2') {
                $('#<%= hdnValueAdditionId4_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage4_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage4_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency4_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate4_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate4_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency4_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            //Fabric 5           
            if (Id == '5_1') {
                $('#<%= hdnValueAdditionId5_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage5_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage5_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency5_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate5_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate5_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency5_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '5_2') {
                $('#<%= hdnValueAdditionId5_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage5_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage5_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency5_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate5_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate5_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency5_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            //Fabric 6           
            if (Id == '6_1') {
                $('#<%= hdnValueAdditionId6_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage6_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage6_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency6_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate6_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate6_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency6_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '6_2') {
                $('#<%= hdnValueAdditionId6_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage6_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage6_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency6_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate6_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate6_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency6_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            //Fabric 7           
            if (Id == '7_1') {
                $('#<%= hdnValueAdditionId7_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage7_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage7_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency7_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate7_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate7_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency7_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '7_2') {
                $('#<%= hdnValueAdditionId7_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage7_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage7_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency7_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate7_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate7_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency7_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            //Fabric 8           
            if (Id == '8_1') {
                $('#<%= hdnValueAdditionId8_1.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage8_1.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage8_1.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency8_1.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate8_1.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate8_1.ClientID %>').val('');
                    $('#<%= lblVaCurrency8_1.ClientID %>').removeClass("addRupeesym");
                }
            }
            if (Id == '8_2') {
                $('#<%= hdnValueAdditionId8_2.ClientID %>').val(ValueAdditionId);
                if (parseFloat(result.VA_Wastage) > 0) {
                    $('#<%= txtVAWastage8_2.ClientID %>').val(result.VA_Wastage + " %");
                }
                else {
                    $('#<%= txtVAWastage8_2.ClientID %>').val('');
                }
                if (parseFloat(result.VA_Rate) > 0) {
                    $('#<%= lblVaCurrency8_2.ClientID %>').addClass("addRupeesym");
                    $('#<%= txtVARate8_2.ClientID %>').val(result.VA_Rate);
                }
                else {
                    $('#<%= txtVARate8_2.ClientID %>').val('');
                    $('#<%= lblVaCurrency8_2.ClientID %>').removeClass("addRupeesym");
                }
            }
            CalculateCostingTotal(0);
        });

    }

    function ChangeValueAdditionOnRange() {
        //  // 
        var WastageId = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();
        var styleId = $('input[type=text].costing-style-id').val();
        var ValueAdditionId = -1;


        for (var i = 1; i <= 8; i++) {
            if (i == 1) {
                if (document.getElementById('<%=txtFabric1.ClientID%>') != undefined) {
                    // Fabric 1 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition1_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 1, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {
                            //  // 
                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage1_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage1_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }

                    ValueAdditionId = $('#<%= ddlValueAddition1_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 1, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage1_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage1_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
            else if (i == 2) {

                if (document.getElementById('<%=txtFabric2.ClientID%>') != undefined) {
                    // Fabric 2 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition2_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 2, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage2_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage2_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                    ValueAdditionId = $('#<%= ddlValueAddition2_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 2, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage2_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage2_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
            else if (i == 3) {
                if (document.getElementById('<%=txtFabric3.ClientID%>') != undefined) {
                    // Fabric 3 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition3_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 3, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage3_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage3_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                    ValueAdditionId = $('#<%= ddlValueAddition3_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 3, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage3_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage3_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
            else if (i == 4) {
                if (document.getElementById('<%=txtFabric4.ClientID%>') != undefined) {
                    // Fabric 4 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition4_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 4, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage4_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage4_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                    ValueAdditionId = $('#<%= ddlValueAddition4_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 4, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage4_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage4_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
            else if (i == 5) {
                if (document.getElementById('<%=txtFabric5.ClientID%>') != undefined) {
                    // Fabric 5 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition5_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 5, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage5_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage5_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                    ValueAdditionId = $('#<%= ddlValueAddition5_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 5, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage5_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage5_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
            else if (i == 6) {
                if (document.getElementById('<%=txtFabric6.ClientID%>') != undefined) {
                    // Fabric 6 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition6_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 6, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage6_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage6_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                    ValueAdditionId = $('#<%= ddlValueAddition6_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 6, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage6_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage6_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
            else if (i == 7) {
                if (document.getElementById('<%=txtFabric7.ClientID%>') != undefined) {
                    // Fabric 7 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition7_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 7, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage7_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage7_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                    ValueAdditionId = $('#<%= ddlValueAddition7_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 7, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage7_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage7_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
            else if (i == 8) {
                if (document.getElementById('<%=txtFabric8.ClientID%>') != undefined) {
                    // Fabric 8 Exist
                    ValueAdditionId = $('#<%= ddlValueAddition8_1.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 8, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 1 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage8_1.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage8_1.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                    ValueAdditionId = $('#<%= ddlValueAddition8_2.ClientID %> option:selected').val();
                    if (ValueAdditionId > 0) {
                        proxy.invoke("Get_Wastage_Rate_For_Costing", { StyleId: styleId, SequenceNo: 8, ValueAdditionId: ValueAdditionId, WastageId: WastageId, type: 2 }, function (result) {

                            if (parseFloat(result.VA_Wastage) > 0) {
                                $('#<%= txtVAWastage8_2.ClientID %>').val(result.VA_Wastage + " %");
                            }
                            else {
                                $('#<%= txtVAWastage8_2.ClientID %>').val('');
                            }
                            CalculateCostingTotal(0);
                        });
                    }
                }
            }
        }

    }

    function CalculateValueAddition(srcElem, flag) {
        //  // 
        var Value = srcElem.value;
        if (Value == '0') {
            srcElem.value = '';
            //return false;
        }
        var TempId = srcElem.id;
        var Id;
        if (flag == 'Rate') {
            Id = TempId.split('txtVARate')[1];
        }
        var Seqno = Id.split("_")[0];
        var type = Id.split("_")[1];

        var ValueAddition = '';

        if ((Seqno == 1) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition1_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency1_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency1_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 1) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition1_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency1_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency1_2.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 2) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition2_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency2_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency2_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 2) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition2_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency2_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency2_2.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 3) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition3_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency3_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency3_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 3) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition3_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency3_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency3_2.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 4) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition4_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency4_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency4_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 4) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition4_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency4_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency4_2.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 5) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition5_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency5_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency5_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 5) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition5_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency5_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency5_2.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 6) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition6_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency6_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency6_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 6) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition6_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency6_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency6_2.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 7) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition7_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency7_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency7_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 7) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition7_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency7_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency7_2.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 8) && (type == 1)) {
            ValueAddition = $('#<%= ddlValueAddition8_1.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency8_1.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency8_1.ClientID %>').removeClass("addRupeesym");
        }
        else if ((Seqno == 8) && (type == 2)) {
            ValueAddition = $('#<%= ddlValueAddition8_2.ClientID %> option:selected').val();
            if (parseFloat(Value) > 0)
                $('#<%= lblVaCurrency8_2.ClientID %>').addClass("addRupeesym");
            else
                $('#<%= lblVaCurrency8_2.ClientID %>').removeClass("addRupeesym");
        }

        if (ValueAddition == '-1') {
            alert('Please Select Value Addition');
            srcElem.value = '';
            return false;
        }
        CalculateCostingTotal(0);

    }


    function Check_Registered_FabricName(srcElem, Type) {


        var RegisterFabricName = srcElem.value;
        var thisId = srcElem.id.split('_')[5];
        // alert(thisId);
        // alert(srcElem.id);
        var lastid = thisId.slice(-1);
        var GrdRowCount = $("tr.rowCount").length - 1;
        var PreviousVal = srcElem.defaultValue;

        proxy.invoke("Get_RegisterFabric", { RegisterFabricName: RegisterFabricName }, function (result) {

            if (result[0].Acc == '0') {
                $("#" + srcElem.id).css("background-color", "#bfbfbf !important");
                $("#" + srcElem.id).css("color", "#FF0000 !important");

                //                if (Type == 1) {
                //                    document.getElementById('<%=txtFabric1.ClientID%>').value = "";
                //                }
                //                if (Type == 2) {
                //                    document.getElementById('<%=txtFabric2.ClientID%>').value = "";

                //                }
                //                if (Type == 3) {
                //                    document.getElementById('<%=txtFabric3.ClientID%>').value = "";
                //                }
                //                if (Type == 4) {
                //                    document.getElementById('<%=txtFabric4.ClientID%>').value = "";
                //                }
                //                if (Type == 5) {
                //                    document.getElementById('<%=txtFabric5.ClientID%>').value = "";
                //                }
                //                if (Type == 6) {
                //                    document.getElementById('<%=txtFabric6.ClientID%>').value = "";
                //                }
                //                if (Type == 7) {
                //                    document.getElementById('<%=txtFabric7.ClientID%>').value = "";
                //                }
                //                if (Type == 8) {
                //                    document.getElementById('<%=txtFabric8.ClientID%>').value = "";
                //                }
                //                $("#" + thisId).css("background-color", "#bfbfbf !important");
                // return;
            }
            else if (result[0].Acc == 1) {
                //alert("Refistered");
                $("#" + srcElem.id).css("background-color", "#ffffaa !important");
                $("#" + srcElem.id).css("color", "#0000FF !important");
                //                $("#" + thisId).css("background-color", "#ffffaa !important");
                //                Registered

            }
            //  // 
            // fill 1 Value addition
            if (Type == 1) {
                var ValueAdditionId = $('#<%= ddlValueAddition1_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition1_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition1_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition1_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition1_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }
            // fill 2 Value addition
            if (Type == 2) {
                var ValueAdditionId = $('#<%= ddlValueAddition2_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition2_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition2_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition2_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition2_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }
            // fill 3 Value addition
            if (Type == 3) {
                var ValueAdditionId = $('#<%= ddlValueAddition3_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition3_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition3_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition3_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition3_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }
            // fill 4 Value addition
            if (Type == 4) {
                var ValueAdditionId = $('#<%= ddlValueAddition4_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition4_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition4_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition4_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition4_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }
            // fill 5 Value addition
            if (Type == 5) {
                var ValueAdditionId = $('#<%= ddlValueAddition5_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition5_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition5_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition5_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition5_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }
            // fill 6 Value addition
            if (Type == 6) {
                var ValueAdditionId = $('#<%= ddlValueAddition6_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition6_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition6_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition6_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition6_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }
            // fill 7 Value addition
            if (Type == 7) {
                var ValueAdditionId = $('#<%= ddlValueAddition7_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition7_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition7_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition7_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition7_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }
            // fill 8 Value addition
            if (Type == 8) {
                var ValueAdditionId = $('#<%= ddlValueAddition8_1.ClientID %>')[0].selectedIndex;
                if (ValueAdditionId < 0) {
                    $('#<%= ddlValueAddition8_1.ClientID %>').append($("<option></option>").val('-1').html('Select'));
                    $('#<%= ddlValueAddition8_2.ClientID %>').append($("<option></option>").val('-1').html('Select'));

                    proxy.invoke("GetValueAdditionDDL", { ValueAdditionId: 0 }, function (result) {
                        $.each(result, function (key, value) {
                            //  // 
                            $('#<%= ddlValueAddition8_1.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));
                            $('#<%= ddlValueAddition8_2.ClientID %>').append($("<option></option>").val(value.ValueAdditionID).html(value.ValueAdditionName));

                        });

                    });
                }
            }

        });
        // // // 

        var fabrictyCheck;
        if (lastid == Type) {
            fabrictyCheck = $("#ctl00_cph_main_content_CostingFormNew1_txtFabricType" + lastid).val();
        }

        for (var k = 1; k <= GrdRowCount; k++) {

            var RegisterFabrname = $("#ctl00_cph_main_content_CostingFormNew1_txtFabric" + k).val();
            if (RegisterFabricName != "") {

                if (lastid != k) {
                    if (RegisterFabrname.toLowerCase() == RegisterFabricName.toLowerCase()) {
                        var fabrictypename = $("#ctl00_cph_main_content_CostingFormNew1_txtFabricType" + k).val();
                        if (fabrictypename.toLowerCase() == fabrictyCheck.toLowerCase()) {
                            alert('Duplicate Fabric & Color Found. ');
                            srcElem.value = "";

                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtRate" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_txtWidth" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_lblWidthCM" + lastid).innerText = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnFabricID" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnDyedRate" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnPrintRate" + lastid).value = "";
                            document.getElementById("ctl00_cph_main_content_CostingFormNew1_hdnDigitalPrintRate" + lastid).value = "";

                            $(".lay_file" + lastid + "").attr("style", "display:none");
                            $('table #costing_print_table' + lastid).addClass('hide_me');


                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_txtFabricType' + lastid).value = "";

                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_COUNTCON' + lastid).innerHTML = "";

                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_GSML' + lastid).innerText = "";
                            $('.fab_Type' + lastid + 'option[value=2]').attr('selected', 'selected');
                            document.getElementById('ctl00_cph_main_content_CostingFormNew1_txtFabric' + lastid).focus();

                        }
                    }

                    var Fablen = RegisterFabrname.length;
                    if (Fablen > 40) {
                        // document.getElementById('ctl00_cph_main_content_CostingFormNew1_txtFabric' + k).css("height:","50px");
                        $("#ctl00_cph_main_content_CostingFormNew1_txtFabric" + k).addClass("InputHight");
                    }

                }

                // document.getElementById('ctl00_cph_main_content_CostingFormNew1_txtFabric' + k).focus();
                //document.getElementById('ctl00_cph_main_content_CostingFormNew1_txtFabric' + k).focusout();
            }
        }
        //  // 
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        if (UserID == "5") {
            if (RegisterFabricName != "") {
                if (RegisterFabricName.length > 4) {
                    if (PreviousVal != RegisterFabricName) {
                        SaveIkandiHide();
                    }
                }
            }
        }
    }

    function PopulateAccessory() {
        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var ParentDeptId = $('#<%= ddlParentDept.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();




        $("input.items", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/GetAccessoryList_newtubularAutoComp", { dataType: "xml", datakey: "string", max: 100, "width": "150px",
            extraParams:
                {
                    StyleId: $('input[type=text].costing-style-id').val(),
                    ClientId: ClientId,
                    ParentDeptId: ParentDeptId,
                    DeptId: DeptId
                }
        });

    }


    function CheckAccessoryName(srcElem) {

        var l;
        var i = 1;
        var s = 0;
        var AccessoryArray = new Array();
        var TempId = srcElem.id;
        var id = TempId.split('txtItems');
        var RegisterAccName = srcElem.value;
        var thisId = srcElem.id.split('_')[6];
        var RowId = 0;
        var gvId;
        var GridRow = $(".gvRow").length;
        var AccessId

        proxy.invoke("Get_RegisterAcc", { RegisterAccName: RegisterAccName }, function (result) {

            if (result[0].Acc == '0') {


                //                var accessoryval = $("#" + srcElem.id).val();
                //                if (accessoryval != "") {
                //                    $("#" + srcElem.id).css("background-color", "#bfbfbf");
                //                }
            }
            //            else if (result[0].Acc == '1') {
            //                if (accessoryval != "") {
            //                    $("#" + srcElem.id).css("background-color", "#ffffaa"); 

            //                }

            //            }

        });

        //add code by bharat on23-Sep-20
        for (var row = 1; row <= GridRow - 1; row++) {
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;

            var itemval = $("#<%= gdvAccessory.ClientID %> input[id*='" + gvId + "_txtItems" + "']").val();
            if (thisId != gvId) {
                //  // 


                if (itemval.toLowerCase().trim() == RegisterAccName.toLowerCase().trim()) {
                    srcElem.value = '';
                    alert('Duplicate Accessories Found. ');
                    document.getElementById(TempId).value = "";
                    document.getElementById(id[0] + "txtUnitQty").value = "";
                    document.getElementById(id[0] + "txtRate").value = "";
                    document.getElementById(id[0] + "lblTotalAmount").value = "";
                    break;

                }
            }
        }
        // Added code by Bharat on 23-oct-2020
        //  // 
        var previousval = srcElem.defaultValue;
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        if (UserID == "5") {
            if (RegisterAccName.length > 4) {
                if (previousval.toLowerCase().trim() != RegisterAccName.toLowerCase().trim()) {
                    SaveIkandiHide();
                }
            }
        }

    }

    function CheckProcessName(srcElem) {
        var l;
        var i = 1;
        var s = 0;
        var ProcessArray = new Array();
        var TempId = srcElem.id;
        var id = TempId.split('txtPItems');
        var RegisterProcessName = srcElem.value;
        proxy.invoke("Get_RegisterProcess_Name", { RegisterProcessName: RegisterProcessName }, function (result) {
            if (result[0].Acc == '0') {

                document.getElementById(TempId).value = "";
                return;
            }
        });
        $('#<%=gvdProcessDetails.ClientID%>').find('input:text[id$="txtPItems"]').each(function () {
            var idv = $(this).val();
            l = ProcessArray.length;
            if (idv == 0 || idv == '') {
                ProcessArray[l] = i
            }
            else {
                ProcessArray[l] = idv.toLowerCase();
            }
            i = i + 1;
        });

        ProcessArray.sort();
        for (var ww = 1; ww < i; ww++) {
            if (ProcessArray[ww - 1] == ProcessArray[ww]) {
                alert('Duplicate Process Item Found. ');
                document.getElementById(TempId).value = "";
                document.getElementById(id[0] + "txtFromStatus").value = "";
                document.getElementById(id[0] + "txtToStatus").value = "";
                document.getElementById(id[0] + "lblTotalAmount").value = "";
                break;
            }
        }
    }

    function IsMultiple(styleId) { //GC

        var styleId = $('input[type=text].costing-style-id').val();
        proxy.invoke('GetStyleFabricsByStyleId_New', { styleId: styleId },
                    function (objStyleFabricCollection) {

                        for (var k = 0; k <= objStyleFabricCollection.length; k++) {
                            if (k < txtCostingFabric.length) {
                                if (k > 0) {
                                    AddFabric(1);
                                }

                                //added by raghvinder on 18-09-2020 start
                                $(txtCostingFabric[k]).val(objStyleFabricCollection[k].FabricName);

                                var fabricQualityID = objStyleFabricCollection[k].FabricQualityId;
                                if (fabricQualityID >= 20000) {
                                    $(txtCostingFabric[k]).addClass('someCssClass');
                                    $(txtCostingFabric[k]).css("color", "#FF0000");
                                } //added by raghvinder on 18-09-2020 end


                                // this code added by bharat on 22 may 2019
                                var fremark = "";
                                fremark = objStyleFabricCollection[k].Remarks;

                                if (fremark != '') {
                                    $(txtCostingFabric[k]).parent().attr('data-title', fremark);
                                }
                                //end
                                $(txtCostingFabric[k]).blur();
                                if (objStyleFabricCollection[k].IsPrintMultiple == 'Y') {
                                    $(imgFab[k]).attr("style", "display:block");
                                }
                                else $(imgFab[k]).attr("style", "display:none");

                                $(txtFabricType[k]).val(objStyleFabricCollection[k].SpecialFabricDetails);
                                var s2 = objStyleFabricCollection[k].SpecialFabricDetails;

                                var s1;
                                if (k == 0) {

                                    //$(".lay_file1").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        s1 = tt[1];
                                        document.getElementById('fab1hdn').value = s1;
                                        document.getElementById('fab2hdn').value = s1;
                                        var ee = NewPrintGet(s1, 1);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric1(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type1 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth1]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate1]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate1]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate1]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate1]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate1]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate1]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
                                        $(".tr-fab").find("[id$=lblWidthCM1]").html(parseFloat(Math.round(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));

                                        $(".tr-fab").find("[id$=hdnFabricID1]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate1]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate1]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate1]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file1").attr("style", "display:block");
                                        chk(s2, 1);
                                        //GetFabricQualityData(trade1[0], $("#" + hidFab1DetailsClientID).val(), $("#" + hiddenRadioModeClientID1).val(), 1, true, $('.fab_Type1 option:selected').val(), Suplier1);
                                        //GetFabricQualityData($("#" + txtFabricClientID1).val(), " ", $("#" + hiddenRadioModeClientID1).val(), 1);
                                        $("#" + hidFab1DetailsClientID).val("#");
                                        $(".afab").val("#");
                                    }
                                    else {
                                        document.getElementById('fab1hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab2hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        var ww = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 1);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric1(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}
                                        $('.fab_Type1 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth1]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate1]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate1]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate1]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate1]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate1]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate1]").val(objStyleFabricCollection[k].DigitalPrintRate);

                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
                                        $(".tr-fab").find("[id$=lblWidthCM1]").html(parseFloat(Math.round(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));

                                        $(".tr-fab").find("[id$=hdnFabricID1]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate1]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate1]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate1]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file1").attr("style", "display:block");
                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {
                                               // 
                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       //document.getElementById('lblprd11').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade1[0], $("#" + hidFab1DetailsClientID).val(), $("#" + hiddenRadioModeClientID1).val(), 1, true, $('.fab_Type1 option:selected').val(), Suplier1);
                                                       //GetFabricQualityData($("#" + txtFabricClientID1).val(), "#", $("#" + hiddenRadioModeClientID1).val(), 1);
                                                       $("#" + hidFab1DetailsClientID).val("#");
                                                       $(".afab").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd11').innerHTML = "";
                                                       //GetFabricQualityData(trade1[0], $("#" + hidFab1DetailsClientID).val(), $("#" + hiddenRadioModeClientID1).val(), 1, true, $('.fab_Type1 option:selected').val(), Suplier1);
                                                       //GetFabricQualityData($("#" + txtFabricClientID1).val(), "COL", $("#" + hiddenRadioModeClientID1).val(), 1);
                                                       $("#" + hidFab1DetailsClientID).val("COL");
                                                       $(".afab").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }

                                if (k == 1) {
                                    // // // 
                                    //$(".lay_file2").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab22hdn').value = s1;
                                        document.getElementById('fab22hdn2').value = s1;

                                        var qq = NewPrintGet(s1, 2);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric2(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML2.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}
                                        $('.fab_Type2 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth2]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate2]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate2]").val(objStyleFabricCollection[k].DyedRate);

                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate2]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate2]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate2]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate2]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM2]").html(parseFloat(Math.round(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID2]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate2]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate2]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate2]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file2").attr("style", "display:block");
                                        chk2(s2, 2);
                                        //GetFabricQualityData($("#" + txtFabricClientID2).val(), "#", $("#" + hiddenRadioModeClientID2).val(), 2);
                                        //GetFabricQualityData(trade2[0], $("#" + hidFab2DetailsClientID).val(), $("#" + hiddenRadioModeClientID2).val(), 2, true, $('.fab_Type2 option:selected').val(), Suplier2);
                                        $("#" + hidFab2DetailsClientID).val("#");
                                        $(".b").val("#");
                                    }
                                    else {
                                        // 
                                        document.getElementById('fab22hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab22hdn2').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 2);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric2(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML2.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type2 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth2]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate2]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate2]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate2]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate2]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate2]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate2]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM2]").html(Math.round(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID2]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate2]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate2]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate2]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file2").attr("style", "display:block");
                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd22').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade2[0], $("#" + hidFab2DetailsClientID).val(), $("#" + hiddenRadioModeClientID2).val(), 2, true, $('.fab_Type2 option:selected').val(), Suplier2);
                                                       //GetFabricQualityData($("#" + txtFabricClientID2).val(), "#", $("#" + hiddenRadioModeClientID2).val(), 2);
                                                       $("#" + hidFab2DetailsClientID).val("#");
                                                       $(".b").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       ;
                                                       document.getElementById('lblprd22').innerHTML = "";
                                                       //GetFabricQualityData(trade2[0], $("#" + hidFab2DetailsClientID).val(), $("#" + hiddenRadioModeClientID2).val(), 2, true, $('.fab_Type2 option:selected').val(), Suplier2);
                                                       //GetFabricQualityData($("#" + txtFabricClientID2).val(), "COL", $("#" + hiddenRadioModeClientID2).val(), 2);
                                                       $("#" + hidFab2DetailsClientID).val("COL");
                                                       $(".b").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k==1

                                if (k == 2) {
                                    //
                                    //$(".lay_file3").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab33hdn').value = s1;
                                        document.getElementById('fab33hdn3').value = s1;
                                        var qq = NewPrintGet(s1, 3);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric3(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML3.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type3 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth3]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate3]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate3]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate3]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate3]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate3]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate3]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM3]").html(parseFloat(Math.round(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));

                                        $(".tr-fab").find("[id$=hdnFabricID3]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate3]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate3]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate3]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file3").attr("style", "display:block");
                                        chk3(s2, 3);
                                        //GetFabricQualityData(trade3[0], $("#" + hidFab3DetailsClientID).val(), $("#" + hiddenRadioModeClientID3).val(), 3, true, $('.fab_Type3 option:selected').val(), Suplier3);
                                        //GetFabricQualityData($("#" + txtFabricClientID3).val(), "#", $("#" + hiddenRadioModeClientID3).val(), 3);
                                        $("#" + hidFab3DetailsClientID).val("#"); $(".c").val("#");
                                    }
                                    else {

                                        document.getElementById('fab33hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab33hdn3').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 3);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric3(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML3.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type3 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth3]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate3]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate3]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate3]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate3]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate3]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate3]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM3]").html(Math.round(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));

                                        $(".tr-fab").find("[id$=hdnFabricID3]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate3]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate3]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate3]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file3").attr("style", "display:block");
                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd33').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade3[0], $("#" + hidFab3DetailsClientID).val(), $("#" + hiddenRadioModeClientID3).val(), 3, true, $('.fab_Type3 option:selected').val(), Suplier3);
                                                       //GetFabricQualityData($("#" + txtFabricClientID3).val(), "#", $("#" + hiddenRadioModeClientID3).val(), 3);
                                                       $("#" + hidFab3DetailsClientID).val("#"); $(".c").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd33').innerHTML = "";
                                                       //GetFabricQualityData(trade3[0], $("#" + hidFab3DetailsClientID).val(), $("#" + hiddenRadioModeClientID3).val(), 3, true, $('.fab_Type3 option:selected').val(), Suplier3);
                                                       //GetFabricQualityData($("#" + txtFabricClientID3).val(), "COL", $("#" + hiddenRadioModeClientID3).val(), 3);
                                                       $("#" + hidFab3DetailsClientID).val("COL"); $(".c").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k==2


                                if (k == 3) {
                                    //
                                    //$(".lay_file4").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab44hdn').value = s1;
                                        document.getElementById('fab44hdn4').value = s1;

                                        var qq = NewPrintGet(s1, 4);

                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric4(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML4.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type4 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth4]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate4]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate4]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate4]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate4]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate4]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate4]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM4]").html(Math.round(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID4]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate4]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate4]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate4]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file4").attr("style", "display:block");
                                        chk4(s2, 4);
                                        //GetFabricQualityData(trade4[0], $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true, $('.fab_Type4 option:selected').val(), Suplier4);
                                        //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                        $("#" + hidFab4DetailsClientID).val("#"); $(".d").val("#");

                                    }
                                    else {

                                        document.getElementById('fab44hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab44hdn4').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 4);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric4(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML4.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type4 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth4]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate4]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate4]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate4]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate4]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate4]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate4]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM4]").html(parseFloat(Math.round(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID4]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate4]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate4]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate4]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file4").attr("style", "display:block");

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd44').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade4[0], $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true, $('.fab_Type4 option:selected').val(), Suplier4);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab4DetailsClientID).val("#"); $(".d").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd44').innerHTML = "";
                                                       //GetFabricQualityData(trade4[0], $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true, $('.fab_Type4 option:selected').val(), Suplier4);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab4DetailsClientID).val("COL"); $(".d").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }

                                //end k=3
                                if (k == 4) {
                                    //
                                    //$(".lay_file4").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab55hdn').value = s1;
                                        document.getElementById('fab55hdn5').value = s1;

                                        var qq = NewPrintGet(s1, 5);

                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric5(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML5.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type5 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth5]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate5]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate5]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate5]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate5]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate5]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate5]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM5]").html(Math.round(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID5]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate5]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate5]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate5]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file5").attr("style", "display:block");
                                        chk5(s2, 5);
                                        //GetFabricQualityData(trade4[0], $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true, $('.fab_Type4 option:selected').val(), Suplier4);
                                        //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                        $("#" + hidFab5DetailsClientID).val("#"); $(".d").val("#");

                                    }
                                    else {

                                        document.getElementById('fab55hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab55hdn5').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 5);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric5(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML5.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type5 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth5]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate5]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate5]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate5]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate5]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate5]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate5]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM5]").html(parseFloat(Math.round(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID5]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate5]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate5]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate5]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file5").attr("style", "display:block");

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd55').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade5[0], $("#" + hidFab5DetailsClientID).val(), $("#" + hiddenRadioModeClientID5).val(), 5, true, $('.fab_Type5 option:selected').val(), Suplier5);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab5DetailsClientID).val("#"); $(".d").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd55').innerHTML = "";
                                                       //GetFabricQualityData(trade5[0], $("#" + hidFab5DetailsClientID).val(), $("#" + hiddenRadioModeClientID5).val(), 5, true, $('.fab_Type5 option:selected').val(), Suplier5);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab5DetailsClientID).val("COL"); $(".d").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k=4
                                if (k == 5) {
                                    //
                                    //$(".lay_file4").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab66hdn').value = s1;
                                        document.getElementById('fab66hdn6').value = s1;

                                        var qq = NewPrintGet(s1, 6);

                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric6(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML6.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type6 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth6]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate6]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate6]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate6]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate6]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate6]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate6]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM6]").html(parseFloat(Math.round(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID6]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate6]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate6]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate6]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file6").attr("style", "display:block");
                                        chk6(s2, 6);
                                        //GetFabricQualityData(trade4[0], $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true, $('.fab_Type4 option:selected').val(), Suplier4);
                                        //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                        $("#" + hidFab6DetailsClientID).val("#"); $(".d").val("#");

                                    }
                                    else {

                                        document.getElementById('fab66hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab66hdn6').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 6);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric6(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML6.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type6 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth6]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate6]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate6]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate6]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate6]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate6]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate6]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);

                                        $(".tr-fab").find("[id$=lblWidthCM6]").html(Math.round(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2)));
                                        $(".tr-fab").find("[id$=hdnFabricID6]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate6]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate6]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate6]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file6").attr("style", "display:block");

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd66').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade6[0], $("#" + hidFab6DetailsClientID).val(), $("#" + hiddenRadioModeClientID6).val(), 6, true, $('.fab_Type6 option:selected').val(), Suplier6);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab6DetailsClientID).val("#"); $(".d").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd66').innerHTML = "";
                                                       //GetFabricQualityData(trade6[0], $("#" + hidFab6DetailsClientID).val(), $("#" + hiddenRadioModeClientID6).val(), 6, true, $('.fab_Type6 option:selected').val(), Suplier6);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab6DetailsClientID).val("COL"); $(".d").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k=5
                                if (k == 6) {
                                    //
                                    //$(".lay_file4").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab77hdn').value = s1;
                                        document.getElementById('fab77hdn7').value = s1;

                                        var qq = NewPrintGet(s1, 4);

                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric7(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML7.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type7 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth7]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate7]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate7]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate7]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate7]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate7]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate7]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
                                        $(".tr-fab").find("[id$=lblWidthCM7]").html(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2));
                                        $(".tr-fab").find("[id$=hdnFabricID7]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate7]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate7]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate7]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file7").attr("style", "display:block");
                                        chk7(s2, 7);
                                        //GetFabricQualityData(trade4[0], $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true, $('.fab_Type4 option:selected').val(), Suplier4);
                                        //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                        $("#" + hidFab7DetailsClientID).val("#"); $(".d").val("#");

                                    }
                                    else {

                                        document.getElementById('fab77hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab77hdn7').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 7);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric7(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML7.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type7 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth7]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate7]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate7]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate7]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate7]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate7]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate7]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
                                        $(".tr-fab").find("[id$=lblWidthCM7]").html(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2));
                                        $(".tr-fab").find("[id$=hdnFabricID7]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate7]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate7]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate7]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file7").attr("style", "display:block");

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd77').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade7[0], $("#" + hidFab7DetailsClientID).val(), $("#" + hiddenRadioModeClientID7).val(), 7, true, $('.fab_Type7 option:selected').val(), Suplier7);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab7DetailsClientID).val("#"); $(".d").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd44').innerHTML = "";
                                                       //GetFabricQualityData(trade7[0], $("#" + hidFab7DetailsClientID).val(), $("#" + hiddenRadioModeClientID7).val(), 7, true, $('.fab_Type7 option:selected').val(), Suplier7);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab7DetailsClientID).val("COL"); $(".d").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k=6
                                if (k == 7) {
                                    //
                                    //$(".lay_file4").attr("style", "display:block");
                                    var pos = s2.indexOf(' --- ');
                                    if (pos > 0) {
                                        var tt = new Array();
                                        tt = s2.split(' --- ');
                                        //  newprt = tt.split('(');
                                        s1 = tt[1];
                                        document.getElementById('fab88hdn').value = s1;
                                        document.getElementById('fab88hdn8').value = s1;

                                        var qq = NewPrintGet(s1, 4);

                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric8(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML8.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type8 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth8]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate8]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate8]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate8]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate8]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate8]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate8]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
                                        $(".tr-fab").find("[id$=lblWidthCM8]").html(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2));
                                        $(".tr-fab").find("[id$=hdnFabricID8]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate8]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate8]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate8]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file8").attr("style", "display:block");
                                        chk8(s2, 8);
                                        //GetFabricQualityData(trade4[0], $("#" + hidFab4DetailsClientID).val(), $("#" + hiddenRadioModeClientID4).val(), 4, true, $('.fab_Type4 option:selected').val(), Suplier4);
                                        //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                        $("#" + hidFab8DetailsClientID).val("#"); $(".d").val("#");

                                    }
                                    else {

                                        document.getElementById('fab88hdn').value = objStyleFabricCollection[k].SpecialFabricDetails;
                                        document.getElementById('fab88hdn8').value = objStyleFabricCollection[k].SpecialFabricDetails;

                                        var ws = NewPrintGet(objStyleFabricCollection[k].SpecialFabricDetails, 8);
                                        var Countcon = objStyleFabricCollection[k].CountConstruct;
                                        var GSM1 = objStyleFabricCollection[k].GSM;
                                        fabric8(GSM1, Countcon);
                                        //if (Countcon != '') {
                                        //    document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML = Countcon + "&nbsp;";
                                        //}
                                        //if (GSM1 > 0) {
                                        //    document.getElementById('<%=GSML8.ClientID%>').innerHTML = "(" + GSM1 + ")";
                                        //}

                                        $('.fab_Type8 option[value=' + objStyleFabricCollection[k].FabricType + ']').attr('selected', 'selected');

                                        $(".tr-fab").find("[id$=txtWidth8]").val(objStyleFabricCollection[k].CostWidth);
                                        if (objStyleFabricCollection[k].FabricType == 0) {
                                            if (objStyleFabricCollection[k].DyedRate == "0")
                                                $(".tr-fab").find("[id$=txtRate8]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate8]").val(objStyleFabricCollection[k].DyedRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 1) {
                                            if (objStyleFabricCollection[k].PrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate8]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate8]").val(objStyleFabricCollection[k].PrintRate);
                                        }
                                        if (objStyleFabricCollection[k].FabricType == 2) {
                                            if (objStyleFabricCollection[k].DigitalPrintRate == "0")
                                                $(".tr-fab").find("[id$=txtRate8]").val("");
                                            else
                                                $(".tr-fab").find("[id$=txtRate8]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        }
                                        //$(".tr-fab").find("[id$=lblRS1]").val(result.ResidualShrinkageDyedAir);
                                        $(".tr-fab").find("[id$=lblWidthCM8]").html(parseFloat(objStyleFabricCollection[k].CostWidth * 2.54).toFixed(2));
                                        $(".tr-fab").find("[id$=hdnFabricID8]").val(objStyleFabricCollection[k].FabricQualityId);
                                        $(".tr-fab").find("[id$=hdnDyedRate8]").val(objStyleFabricCollection[k].DyedRate);
                                        $(".tr-fab").find("[id$=hdnPrintRate8]").val(objStyleFabricCollection[k].PrintRate);
                                        $(".tr-fab").find("[id$=hdnDigitalPrintRate8]").val(objStyleFabricCollection[k].DigitalPrintRate);
                                        $(".lay_file8").attr("style", "display:block");

                                        var pno = objStyleFabricCollection[k].SpecialFabricDetails;
                                        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: pno },
                                           function (result) {

                                               if (result == null || result == '')
                                                   return;
                                               else {
                                                   if (result.CountConstruction == "Y") {
                                                       document.getElementById('lblprd88').innerHTML = "PRD: ";
                                                       //GetFabricQualityData(trade8[0], $("#" + hidFab8DetailsClientID).val(), $("#" + hiddenRadioModeClientID8).val(), 8, true, $('.fab_Type8 option:selected').val(), Suplier8);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "#", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab8DetailsClientID).val("#"); $(".d").val("#");
                                                   }
                                                   if (result.CountConstruction == "N") {
                                                       document.getElementById('lblprd88').innerHTML = "";
                                                       //GetFabricQualityData(trade8[0], $("#" + hidFab8DetailsClientID).val(), $("#" + hiddenRadioModeClientID8).val(), 8, true, $('.fab_Type8 option:selected').val(), Suplier8);
                                                       //GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                                       $("#" + hidFab8DetailsClientID).val("COL"); $(".d").val("COL");
                                                   }
                                               }
                                           });
                                    }

                                }
                                //end k=7

                                if (objStyleFabricCollection[k].PrintID != null && objStyleFabricCollection[k].PrintID != '') {

                                    $(txtFabricType[k]).blur();
                                    if ($(txtFabricType[k]).attr("class").indexOf('one') > -1) {
                                        $('input.onehide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    else if ($(txtFabricType[k]).attr("class").indexOf('two') > -1) {
                                        $('input.twohide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    else if ($(txtFabricType[k]).attr("class").indexOf('three') > -1) {
                                        $('input.threehide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    else if ($(txtFabricType[k]).attr("class").indexOf('fourth') > -1) {
                                        $('input.fourthhide').val(objStyleFabricCollection[k].PrintNumber);
                                    }
                                    var objCell = $(txtFabricType[k]).closest("td");
                                    // AddRemoveSymbol(objCell, objStyleFabricCollection[k].PrintNumber, "PRD: ", false, true);//yaten 6dec
                                    AddRemoveSymbol(objCell, objStyleFabricCollection[k].PrintNumber, "", false, true);
                                }
                                else {
                                    $(txtFabricType[k]).val(objStyleFabricCollection[k].SpecialFabricDetails);
                                }

                                var j = k + 1;
                            }
                        }
                    });
    }


    function GetCostingData() { //GC

        var SingleVersion = 0;
        var txtStyleNumber = $('.costing-style-number-view');
        var objRow = txtStyleNumber.closest("tr");

        // Added check to resolve issue
        if (txtStyleNumber.val().length < 8)
            return;

        if (txtStyleNumber.val() != objRow.find(".costing-style-number").val()) {
            var isGetMultiple;

            var collection = getQueryString();
            if (collection['cid'] == undefined)
                isGetMultiple = 1;
            else
                isGetMultiple = 0;

            var sn = $.trim(txtStyleNumber.val());

            //    sn = sn.substring(0,  sn.lastIndexOf(' '));
            //if(sn.split(' ').length == 3)
            // // // 
            //Get the Costing details from database
            proxy.invoke("GetCostingByStyleNumber_New", { styleNumber: sn, isGetMultiple: isGetMultiple, SingleVersion: SingleVersion },
              function (objCostingCollection) {

                  var collection = getQueryString();
                  // // // 
                  if (objCostingCollection.length == 0 && (collection['cid'] == undefined || collection['cid'] > 0)) {
                      ShowHideValidationBox(true, 'No Costing Sheet exists for you.', 'Costing Sheet');
                      return;
                  }

                  if (objCostingCollection != null && objCostingCollection.length > 0
                && collection['sn'] == undefined && window.location.href.toLowerCase().search('tabcosting') == -1) {
                      window.location = 'CostingSheetNew.aspx?sn=' + sn + "&SingleVersion=0";
                      return;
                  }

                  if (objCostingCollection != null && objCostingCollection.length == 1) {
                      var costing = objCostingCollection[0];

                      objRow.find("select.costing-buyer").val((costing.ClientID == null || costing.ClientID == 'null') ? "" : costing.ClientID);
                      objRow.find("select.costing-department").val((costing.DepartmentID == null || costing.DepartmentID == 'null') ? "" : costing.DepartmentID);

                      if (costing.ClientID != '' && costing.ClientID != null && costing.ClientID > 0) {
                          populateParentDepartments(costing.ClientID, -1, -1, 'Parent');
                          populateDepartments(costing.ClientID, -1, costing.ParentDepartmentID, 'SubParent');
                      }

                      if (costing.DepartmentID != '' && costing.DepartmentID != null && costing.DepartmentID > 0) {
                          $("#" + hdnDeptIdClientID, "#main_content").val(costing.DepartmentID);
                          $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
                      }
                      if (costing.ParentDepartmentID != '' && costing.ParentDepartmentID != null && costing.ParentDepartmentID > 0) {
                          $("#" + hdnParentDeptIdClientID, "#main_content").val(costing.ParentDepartmentID);
                          $("#" + ParentDeptDDClientID, '#main_content').val($("#" + hdnParentDeptIdClientID, "#main_content").val());
                      }
                      objRow.find(".costing-style-number").val((costing.StyleNumber == null || costing.StyleNumber == 'null') ? "" : costing.StyleNumber);
                      objRow.find(".costing-style-id").val((costing.StyleID == null || costing.StyleID == 'null') ? "" : costing.StyleID);
                      objRow.find(".buying-house-id").val((costing.IsIkandiClient == null || costing.IsIkandiClient == 'null') ? "0" : costing.IsIkandiClient);

                      objRow.find(".costing-order-id").val((costing.OrderId == null || costing.OrderId == 'null') ? "" : costing.OrderId);
                      objRow.find(".costing-current-status-id").val((costing.CurrentStatusID == null || costing.CurrentStatusID == 'null') ? "" : costing.CurrentStatusID);

                      if (costing.OrderId == -1 && costing.CurrentStatusID != 6)
                          $('#tdDeleteStyleAndCostingSheet').show();
                      else
                          $('#tdDeleteStyleAndCostingSheet').hide();

                      if (costing.SampleImageURL1 != '' && costing.SampleImageURL1 != null) {

                          $('#<%= imgSampleImageUrl1.ClientID %>').attr('src', '/Uploads/Style/' + costing.SampleImageURL1);
                          //$('#<%= imgSampleImageUrl1.ClientID %>').width(250);
                          $('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll_Costing(' + costing.StyleID + ',-1,-1)');
                      }
                      else {
                          $('#<%= imgSampleImageUrl1.ClientID %>').attr('src', '/App_Themes/ikandi/images/preview.png');
                          //$('#<%= imgSampleImageUrl1.ClientID %>').height(150);
                      }

                      $('#<%= anchorQuantity.ClientID %>').text(costing.AllQuantity);



                      proxy.invoke('GetCurrencySumbol_New', { enumCurrencyValue: costing.TargetPriceCurrency },
                         function (currencySymbol) {

                             var ee = costing.TargetPriceCurrency;
                             if (costing.TargetPrice == '0') {
                                 $('.costing-target-price').html(currencySymbol);
                             }
                             else {
                                 $('.costing-target-price').html(currencySymbol + ' ' + costing.TargetPrice);
                             }

                         });


                      $('.costing-designer').html(costing.DesignerName);

                      SetClientDiscount(costing.Discount); //NTA

                      if (costing.StyleID != null && costing.StyleID != 'null') {

                          IsMultiple(costing.StyleID);
                      }

                      //Disable the agreed price textbox if Current Status ID < Sample Received

                      if (costing.CurrentStatusID < 3) {
                          $('.costing-price-quoted').keydown(function () { return false; });
                      }

                      proxy.invoke('GetStatusModeNameAndColor_New', { currentStatusId: costing.CurrentStatusID },
                      function (statusModeAndColor) {
                          $('#anchorWorkFlowHistory')[0].onclick = function () { showWorkflowHistory2(costing.StyleID, -1, -1); }
                          $('#<%= lblStatus.ClientID %>').text(statusModeAndColor[0]);
                          $('#<%= tdStatus.ClientID %>').css('background-color', statusModeAndColor[1]);
                      }, onPageError, false, false);

                      $('.counter-complete').text(costing.CounterComplete ? 'Counter Complete' : 'Counter Pending');
                      $('.counter-complete').css('background', costing.CounterComplete ? 'Green' : 'Red');

                      txtStyleNumber.focus(function () { this.blur(); return false; });
                      var txtTotal = $('#<%= txtTotalABC.ClientID %>');
                      txtTotal.change();
                  }
                  else {
                      var collection = window.parent.getQueryString();
                      if (collection['sn'] == undefined) {
                          objRow.find("select.costing-buyer").val('');
                          objRow.find(".buying-house-id").val('0');
                          objRow.find(".costing-style-number").val('');
                          objRow.find(".costing-style-id").val('');
                          objRow.find(".costing-order-id").val('');
                          objRow.find(".costing-current-status-id").val('');
                      }
                  }
              },
        onPageError, false, false);
        }
    }

    function NewPrintGet(PrintNumberNow, rowno) {
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: PrintNumberNow },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(PrintNumberNow, rowno);
                             }
                             if (result.CountConstruction == "N") {
                                 //  RemovePrintRow(s1);
                             }
                         }
                     });

    }
    function showStylePhotoWithOutScroll_Costing(styleID, orderID, orderDetailID) {

        proxy.invoke("GetStylePhotosView_New", { StyleID: styleID, OrderID: orderID, OrderDetailID: orderDetailID }, function (result) {
            // jQuery.ImageFaceBox(result);
            jQuery.facebox(result);
            //
            //$("#facebox").find(".content").css("max-height", "500px");
            //$("#facebox").find(".content").css("max-width", "700px");
        }, onPageError, false, false);
    }

    function SetClientDiscount(discount) {
        var txtDiscount = $('.costing-landed-costing-discount');
        txtDiscount.val(discount);

        var objCell = txtDiscount.closest("td");
        AddRemoveSymbol(objCell, discount, '%', true);

        txtDiscount.keyup();
    }
    function SBClose() { }
    function OpenTechfiles(obj) {
        //
        var Styleid = '<%=this.StyleID %>';

        //var sURL = obj.href;
        var sURL = '../../Internal/OrderProcessing/TechPackUpload.aspx?Styleid=' + Styleid;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });

        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;
    }
    function OpenGetLP(obj) {
        var Styleid = '<%=this.StyleID %>';

        var sURL = '../../Internal/Sales/Costing_GetLP_New.aspx?Styleid=' + Styleid;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });

        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;
    }
    function OpenPairingCosting(obj) {
        var Styleid = '<%=this.StyleID %>';

        var collection = getQueryString();
        var costingId = collection['cid'];
        var sURL = '../../Internal/Sales/CostingPaired.aspx?Styleid=' + Styleid + '&costingid=' + costingId;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });

        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 300, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;

    }

    function GetGrandTotal(evnt) {//GC

        var total = 0;
        var fobBiplPrice = $(evnt).closest('tr').find('input[type=text].costing-fob-boutique-price');
        var sourceObject = $(evnt).closest('tr').find('input[type=text].costing-landed-costing-grand-total1:not(.exclude)');
        var sourceObject1 = $(evnt).closest('tr').find('input[type=text].exclude');
        if (sourceObject.length == 5 && sourceObject1.length == 2) {
            var modeid = sourceObject1[0].id;
            var processid = sourceObject1[1].id;
            var mode = $("#" + modeid).val();  //$("#" + modeid + 'option:selected').text();
            var process = $("#" + processid).val();
            if (mode === '' || mode === '.')
                mode = "0";
            if (process === '' || mode === '.')
                process = "0";
            total = +fobBiplPrice[0].value + +parseFloat(mode);
            total = total * (1 + +sourceObject[0].value / 100);
            total = total + +sourceObject[1].value + +sourceObject[2].value + +parseFloat(process);
            total = total / (1 - (+sourceObject[3].value / 100));
            total = +total / (1 - (+sourceObject[4].value / 100));
        }

        return ((Math.round(total * 1000) / 1000).toFixed(2));
    }
    function GetGrandTotalDC(evnt) {//GC

        var total = 0;
        var fobBiplPrice = $(evnt).closest('tr').find('input[type=text].costing-fob-boutique-price');
        var sourceObject = $(evnt).closest('tr').find('input[type=text].costing-landed-costing-grand-total2');
        if (sourceObject.length == 3) {
            total = +fobBiplPrice[0].value + +sourceObject[0].value;
            total = total / (1 - (+sourceObject[1].value / 100));
            total = +total / (1 - (+sourceObject[2].value / 100));
        }

        return ((Math.round(total * 1000) / 1000).toFixed(2));
    }

    function populateParentDepartments(clientId, selectedDeptID, ParentDeptId, type) {
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        bindDropdown(serviceUrl, ParentDeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", true, (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
            jscriptPageVariables.selectedDeptID = '';

        if ($("#" + hdnParentDeptIdClientID, '#main_content').val() != '' && $("#" + hdnParentDeptIdClientID, '#main_content').val() != null && $("#" + hdnParentDeptIdClientID, '#main_content').val() > 0) {
            $("#" + ParentDeptDDClientID, '#main_content').val($("#" + hdnParentDeptIdClientID, "#main_content").val());
        }
    }


    function populateDepartments(clientId, selectedDeptID, ParentDeptId, type) {
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", true, (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null) ? jscriptPageVariables.selectedDeptID : selectedDeptID, onPageError, setDeptName)

        if (jscriptPageVariables != null && jscriptPageVariables.selectedDeptID != null && jscriptPageVariables.selectedDeptID != '')
            jscriptPageVariables.selectedDeptID = '';

        if ($("#" + hdnDeptIdClientID, '#main_content').val() != '' && $("#" + hdnDeptIdClientID, '#main_content').val() != null && $("#" + hdnDeptIdClientID, '#main_content').val() > 0) {
            $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
        }
    }

    function setDeptName() {
        if ($("#" + hdnDeptIdClientID, '#main_content').val() != '' && $("#" + hdnDeptIdClientID, '#main_content').val() != null && $("#" + hdnDeptIdClientID, '#main_content').val() > 0) {
            $("#" + DeptDDClientID, '#main_content').val($("#" + hdnDeptIdClientID, "#main_content").val());
        }
        if ($("#" + hdnParentDeptIdClientID, '#main_content').val() != '' && $("#" + hdnParentDeptIdClientID, '#main_content').val() != null && $("#" + hdnParentDeptIdClientID, '#main_content').val() > 0) {
            $("#" + ParentDeptDDClientID, '#main_content').val($("#" + hdnParentDeptIdClientID, "#main_content").val());
        }
    }

    function fabric1(GSM1, Countcon) {

        if (Countcon != '') {
            document.getElementById('<%=COUNTCON.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON.ClientID%>').value = Countcon;
        }
        if (GSM1 > 0) {
            document.getElementById('<%=GSML.ClientID%>').innerHTML = "(" + GSM1 + ")";
            document.getElementById('<%=hdnGSML.ClientID%>').value = GSM1;
        }
    }
    function fabric2(GSM2, Countcon) {

        if (Countcon != '') {
            document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON2.ClientID%>').value = Countcon;
        }
        if (GSM2 > 0) {
            document.getElementById('<%=GSML2.ClientID%>').innerHTML = "(" + GSM2 + ")";
            document.getElementById('<%=hdnGSML2.ClientID%>').value = GSM2;
        }
    }
    function fabric3(GSM3, Countcon) {
        if (Countcon != '') {
            document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON3.ClientID%>').value = Countcon;
        }
        if (GSM3 > 0) {
            document.getElementById('<%=GSML3.ClientID%>').innerHTML = "(" + GSM3 + ")";
            document.getElementById('<%=hdnGSML3.ClientID%>').value = GSM3;
        }
    }
    function fabric4(GSM4, Countcon) {
        if (Countcon != '') {
            document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON4.ClientID%>').value = Countcon;
        }
        if (GSM4 > 0) {
            document.getElementById('<%=GSML4.ClientID%>').innerHTML = "(" + GSM4 + ")";
            document.getElementById('<%=hdnGSML4.ClientID%>').value = GSM4;
        }
    }
    function fabric5(GSM5, Countcon) {
        if (Countcon != '') {
            document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON5.ClientID%>').value = Countcon;
        }
        if (GSM5 > 0) {
            document.getElementById('<%=GSML5.ClientID%>').innerHTML = "(" + GSM5 + ")";
            document.getElementById('<%=hdnGSML5.ClientID%>').value = GSM5;
        }
    }
    function fabric6(GSM6, Countcon) {
        if (Countcon != '') {
            document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON6.ClientID%>').value = Countcon;
        }
        if (GSM6 > 0) {
            document.getElementById('<%=GSML6.ClientID%>').innerHTML = "(" + GSM6 + ")";
            document.getElementById('<%=hdnGSML6.ClientID%>').value = GSM6;
        }
    }
    function fabric7(GSM7, Countcon) {
        if (Countcon != '') {
            document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON7.ClientID%>').value = Countcon;
        }
        if (GSM7 > 0) {
            document.getElementById('<%=GSML7.ClientID%>').innerHTML = "(" + GSM7 + ")";
            document.getElementById('<%=hdnGSML7.ClientID%>').value = GSM7;
        }
    }
    function fabric8(GSM8, Countcon) {
        if (Countcon != '') {
            document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML = Countcon + "&nbsp;";
            document.getElementById('<%=hdnCOUNTCON8.ClientID%>').value = Countcon;
        }
        if (GSM8 > 0) {
            document.getElementById('<%=GSML8.ClientID%>').innerHTML = "(" + GSM8 + ")";
            document.getElementById('<%=hdnGSML8.ClientID%>').value = GSM8;
        }
    }

    function CalculateCostingAmount(sender) {
        var average = $(sender).closest('tr').find('input.costing-average').val();
        var rate = $(sender).closest('tr').find('input.costing-rate').val();

        if (average == '')
            average = 0;

        if (rate == '')
            rate = 0;

        var VAWastage1 = $(sender).closest('tr').find('input.VAWastage1').val();
        var VAWastage2 = $(sender).closest('tr').find('input.VAWastage2').val();

        if (VAWastage1 == '')
            VAWastage1 = 0;

        if (VAWastage2 == '')
            VAWastage2 = 0;

        var VARate1 = $(sender).closest('tr').find('input.Rate1').val();
        var VARate2 = $(sender).closest('tr').find('input.Rate2').val();

        if (VARate1 == '')
            VARate1 = 0;

        if (VARate2 == '')
            VARate2 = 0;

        var amount = ((((parseFloat(average) * 100) / (100 - parseFloat(VAWastage1))) * 100) / (100 - parseFloat(VAWastage2))) * (parseFloat(rate) + parseFloat(VARate1) + parseFloat(VARate2)).toFixed(2);

        //var amount = +average * +rate;

        var txtAmount = $(sender).closest('tr').find('input[type=text].costing-amount');
        txtAmount.val((Math.round(amount * 1000) / 1000).toFixed(2));
        txtAmount.keyup();
    }

    function DoKeyUpOperation(control, e, context) {//GC

        var txtId;
        var seqNum = control.id.substr(control.id.length - 2);

        if (isNaN(seqNum)) {
            seqNum = control.id.substr(control.id.length - 1)
            txtId = control.id.substr(0, control.id.length - 1);
        }
        else {
            txtId = control.id.substr(0, control.id.length - 2);
        }

        if (e.keyCode == 38) {
            txtId = txtId + (seqNum - 1);
        }
        else if (e.keyCode == 40) {
            txtId = txtId + (+seqNum + 1);
        }
        else {
            switch (context) {
                case 'costing':
                    CalculateCostingTotal(seqNum);
                    break;

                case 'accessories':
                    CalculateAccessoriesTotal(control);
                    break;
            }
        }

        if (null != $('#' + txtId))
            $('#' + txtId).focus();
    }

    function CalculateCostingTotal(seqNum) {
        var total = 0; var X = 0; var Y = 0; var TotalPrice = 0;
        var Quantity = document.getElementById('<%=txtExpectedQuant.ClientID%>').value;
        var ConvRate = $('#<%= hdnConvRate.ClientID %>').val();
        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

        if (seqNum == 0) {
            var Average1 = document.getElementById('<%=txtAverage1.ClientID%>').value;
            var Waste1 = document.getElementById('<%=txtWaste1.ClientID%>').value;
            var Rate1 = document.getElementById('<%=txtRate1.ClientID%>').value;
            var RS1 = $(".tablefab").find("[id$=lblRS1]").val();
            var lblFabric1 = $(".tablefab").find("[id$=lblTotalfabric1]");
            var lblTotalPrice1 = $(".tablefab").find("[id$=lblTotalPrice1]");

            var VAWastage1_1 = $('#<%= txtVAWastage1_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVAWastage1_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage1_2 = $('#<%= txtVAWastage1_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVAWastage1_2.ClientID %>').val().split('%')[0].trim();

            var VARate1_1 = $('#<%= txtVARate1_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate1_1.ClientID %>').val();
            var VARate1_2 = $('#<%= txtVARate1_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate1_2.ClientID %>').val();

            var amount1 = 0;

            if ((Average1 != '') && (Rate1 != '')) {

                amount1 = ((((parseFloat(Average1) * 100) / (100 - parseFloat(VAWastage1_1))) * 100) / (100 - parseFloat(VAWastage1_2))) * (parseFloat(Rate1) + parseFloat(VARate1_1) + parseFloat(VARate1_2)).toFixed(2);

                $('#<%= txtAmount1.ClientID %>').val(amount1);

                X = parseFloat(amount1).toFixed(2);
                Y = parseFloat(Average1).toFixed(2);

                txtTotal[0].value = X;
                lblFabric1.html(((Y * Quantity) / 1000).toFixed(2)); //K


                lblTotalPrice1.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average1);
                txtTotalAvgWstg[0].value = Math.round(TotalAvgWstg);

            }

            var Average2 = document.getElementById('<%=txtAverage2.ClientID%>').value;
            var Waste2 = document.getElementById('<%=txtWaste2.ClientID%>').value;
            var Rate2 = document.getElementById('<%=txtRate2.ClientID%>').value;
            var RS2 = $(".tablefab").find("[id$=lblRS2]").val();
            var lblFabric2 = $(".tablefab").find("[id$=lblTotalfabric2]");
            var lblTotalPrice2 = $(".tablefab").find("[id$=lblTotalPrice2]");

            var VAWastage2_1 = $('#<%= txtVAWastage2_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVAWastage2_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage2_2 = $('#<%= txtVAWastage2_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVAWastage2_2.ClientID %>').val().split('%')[0].trim();

            var VARate2_1 = $('#<%= txtVARate2_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate2_1.ClientID %>').val();
            var VARate2_2 = $('#<%= txtVARate2_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate2_2.ClientID %>').val();

            var amount2 = 0;

            if ((Average2 != '') && (Rate2 != '')) {

                amount2 = ((((parseFloat(Average2) * 100) / (100 - parseFloat(VAWastage2_1))) * 100) / (100 - parseFloat(VAWastage2_2))) * (parseFloat(Rate2) + parseFloat(VARate2_1) + parseFloat(VARate2_2)).toFixed(2);

                $('#<%= txtAmount2.ClientID %>').val(amount2);

                X = parseFloat(amount2).toFixed(2);
                Y = parseFloat(Average2).toFixed(2);

                txtTotal[1].value = X;
                lblFabric2.html(((Y * Quantity) / 1000).toFixed(2)); //K

                lblTotalPrice2.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average2);
                txtTotalAvgWstg[1].value = Math.round(TotalAvgWstg);

            }

            var Average3 = document.getElementById('<%=txtAverage3.ClientID%>').value;
            var Waste3 = document.getElementById('<%=txtWaste3.ClientID%>').value;
            var Rate3 = document.getElementById('<%=txtRate3.ClientID%>').value;
            var RS3 = $(".tablefab").find("[id$=lblRS3]").val();
            var lblFabric3 = $(".tablefab").find("[id$=lblTotalfabric3]");
            var lblTotalPrice3 = $(".tablefab").find("[id$=lblTotalPrice3]");

            var VAWastage3_1 = $('#<%= txtVAWastage3_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVAWastage3_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage3_2 = $('#<%= txtVAWastage3_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVAWastage3_2.ClientID %>').val().split('%')[0].trim();

            var VARate3_1 = $('#<%= txtVARate3_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate3_1.ClientID %>').val();
            var VARate3_2 = $('#<%= txtVARate3_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate3_2.ClientID %>').val();

            var amount3 = 0;

            if ((Average3 != '') && (Rate3 != '')) {

                amount3 = ((((parseFloat(Average3) * 100) / (100 - parseFloat(VAWastage3_1))) * 100) / (100 - parseFloat(VAWastage3_2))) * (parseFloat(Rate3) + parseFloat(VARate3_1) + parseFloat(VARate3_2)).toFixed(2);

                $('#<%= txtAmount3.ClientID %>').val(amount3);

                X = parseFloat(amount3).toFixed(2);
                Y = parseFloat(Average3).toFixed(2);

                txtTotal[2].value = X;
                lblFabric3.html(((Y * Quantity) / 1000).toFixed(2)); //K
                //lblTotalPrice3.val(((X * Quantity) / 100000).toFixed(2)); //L
                lblTotalPrice3.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average3);
                txtTotalAvgWstg[2].value = Math.round(TotalAvgWstg);

            }

            var Average4 = document.getElementById('<%=txtAverage4.ClientID%>').value;
            var Waste4 = document.getElementById('<%=txtWaste4.ClientID%>').value;
            var Rate4 = document.getElementById('<%=txtRate4.ClientID%>').value;
            var RS4 = $(".tablefab").find("[id$=lblRS4]").val();
            var lblFabric4 = $(".tablefab").find("[id$=lblTotalfabric4]");
            var lblTotalPrice4 = $(".tablefab").find("[id$=lblTotalPrice4]");

            var VAWastage4_1 = $('#<%= txtVAWastage4_1.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage4_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage4_2 = $('#<%= txtVAWastage4_2.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage4_2.ClientID %>').val().split('%')[0].trim();

            var VARate4_1 = $('#<%= txtVARate4_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate4_1.ClientID%>').val();
            var VARate4_2 = $('#<%= txtVARate4_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate4_2.ClientID%>').val();

            if ((Average4 != '') && (Rate4 != '')) {

                var amount4 = ((((parseFloat(Average4) * 100) / (100 - parseFloat(VAWastage4_1))) * 100) / (100 - parseFloat(VAWastage4_2))) * (parseFloat(Rate4) + parseFloat(VARate4_1) + parseFloat(VARate4_2)).toFixed(2);

                $('#<%= txtAmount4.ClientID %>').val(amount4);

                X = parseFloat(amount4).toFixed(2);
                Y = parseFloat(Average4).toFixed(2);

                txtTotal[3].value = X;
                lblFabric4.html(((Y * Quantity) / 1000).toFixed(2)); //K
                //lblTotalPrice4.val(((X * Quantity) / 100000).toFixed(2)); //L
                lblTotalPrice4.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average4);
                txtTotalAvgWstg[3].value = Math.round(TotalAvgWstg);
            }

            var Average5 = document.getElementById('<%=txtAverage5.ClientID%>').value;
            var Waste5 = document.getElementById('<%=txtWaste5.ClientID%>').value;
            var Rate5 = document.getElementById('<%=txtRate5.ClientID%>').value;
            var RS5 = $(".tablefab").find("[id$=lblRS5]").val();
            var lblFabric5 = $(".tablefab").find("[id$=lblTotalfabric5]");
            var lblTotalPrice5 = $(".tablefab").find("[id$=lblTotalPrice5]");

            var VAWastage5_1 = $('#<%= txtVAWastage5_1.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage5_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage5_2 = $('#<%= txtVAWastage5_2.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage5_2.ClientID %>').val().split('%')[0].trim();

            var VARate5_1 = $('#<%= txtVARate5_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate5_1.ClientID%>').val();
            var VARate5_2 = $('#<%= txtVARate5_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate5_2.ClientID%>').val();

            if ((Average5 != '') && (Rate5 != '')) {

                var amount5 = ((((parseFloat(Average5) * 100) / (100 - parseFloat(VAWastage5_1))) * 100) / (100 - parseFloat(VAWastage5_2))) * (parseFloat(Rate5) + parseFloat(VARate5_1) + parseFloat(VARate5_2)).toFixed(2);
                $('#<%= txtAmount5.ClientID %>').val(amount5);

                X = parseFloat(amount5).toFixed(2);
                Y = parseFloat(Average5).toFixed(2);

                txtTotal[4].value = X;
                lblFabric5.html(((Y * Quantity) / 1000).toFixed(2)); //K
                //lblTotalPrice4.val(((X * Quantity) / 100000).toFixed(2)); //L
                lblTotalPrice5.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average5);
                txtTotalAvgWstg[4].value = Math.round(TotalAvgWstg);
            }

            var Average6 = document.getElementById('<%=txtAverage6.ClientID%>').value;
            var Waste6 = document.getElementById('<%=txtWaste6.ClientID%>').value;
            var Rate6 = document.getElementById('<%=txtRate6.ClientID%>').value;
            var RS6 = $(".tablefab").find("[id$=lblRS6]").val();
            var lblFabric6 = $(".tablefab").find("[id$=lblTotalfabric6]");
            var lblTotalPrice6 = $(".tablefab").find("[id$=lblTotalPrice6]");

            var VAWastage6_1 = $('#<%= txtVAWastage6_1.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage6_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage6_2 = $('#<%= txtVAWastage6_2.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage6_2.ClientID %>').val().split('%')[0].trim();

            var VARate6_1 = $('#<%= txtVARate6_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate6_1.ClientID%>').val();
            var VARate6_2 = $('#<%= txtVARate6_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate6_2.ClientID%>').val();

            if ((Average6 != '') && (Rate6 != '')) {

                var amount6 = ((((parseFloat(Average6) * 100) / (100 - parseFloat(VAWastage6_1))) * 100) / (100 - parseFloat(VAWastage6_2))) * (parseFloat(Rate6) + parseFloat(VARate6_1) + parseFloat(VARate6_2)).toFixed(2);
                $('#<%= txtAmount6.ClientID %>').val(amount6);

                X = parseFloat(amount6).toFixed(2);
                Y = parseFloat(Average6).toFixed(2);

                txtTotal[5].value = X;
                lblFabric6.html(((Y * Quantity) / 1000).toFixed(2));
                lblTotalPrice6.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average6);
                txtTotalAvgWstg[5].value = Math.round(TotalAvgWstg);
            }

            var Average7 = document.getElementById('<%=txtAverage7.ClientID%>').value;
            var Waste7 = document.getElementById('<%=txtWaste7.ClientID%>').value;
            var Rate7 = document.getElementById('<%=txtRate7.ClientID%>').value;
            var RS7 = $(".tablefab").find("[id$=lblRS7]").val();
            var lblFabric7 = $(".tablefab").find("[id$=lblTotalfabric7]");
            var lblTotalPrice7 = $(".tablefab").find("[id$=lblTotalPrice7]");

            var VAWastage7_1 = $('#<%= txtVAWastage7_1.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage7_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage7_2 = $('#<%= txtVAWastage7_2.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage7_2.ClientID %>').val().split('%')[0].trim();

            var VARate7_1 = $('#<%= txtVARate7_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate7_1.ClientID%>').val();
            var VARate7_2 = $('#<%= txtVARate7_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate7_2.ClientID%>').val();


            if ((Average7 != '') && (Rate7 != '')) {

                var amount7 = ((((parseFloat(Average7) * 100) / (100 - parseFloat(VAWastage7_1))) * 100) / (100 - parseFloat(VAWastage7_2))) * (parseFloat(Rate7) + parseFloat(VARate7_1) + parseFloat(VARate7_2)).toFixed(2);
                $('#<%= txtAmount7.ClientID %>').val(amount7);

                X = parseFloat(amount7).toFixed(2);
                Y = parseFloat(Average7).toFixed(2);

                txtTotal[6].value = X;
                lblFabric7.html(((Y * Quantity) / 1000).toFixed(2));
                lblTotalPrice7.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average7);
                txtTotalAvgWstg[6].value = Math.round(TotalAvgWstg);
            }

            var Average8 = document.getElementById('<%=txtAverage8.ClientID%>').value;
            var Waste8 = document.getElementById('<%=txtWaste8.ClientID%>').value;
            var Rate8 = document.getElementById('<%=txtRate8.ClientID%>').value;
            var RS8 = $(".tablefab").find("[id$=lblRS8]").val();
            var lblFabric8 = $(".tablefab").find("[id$=lblTotalfabric8]");
            var lblTotalPrice8 = $(".tablefab").find("[id$=lblTotalPrice8]");

            var VAWastage8_1 = $('#<%= txtVAWastage8_1.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage8_1.ClientID %>').val().split('%')[0].trim();
            var VAWastage8_2 = $('#<%= txtVAWastage8_2.ClientID %>').val() == '' ? 0 : $('#<%=txtVAWastage8_2.ClientID %>').val().split('%')[0].trim();

            var VARate8_1 = $('#<%= txtVARate8_1.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate8_1.ClientID%>').val();
            var VARate8_2 = $('#<%= txtVARate8_2.ClientID %>').val() == '' ? 0 : $('#<%= txtVARate8_2.ClientID%>').val();

            if ((Average8 != '') && (Rate8 != '')) {

                var amount8 = ((((parseFloat(Average8) * 100) / (100 - parseFloat(VAWastage8_1))) * 100) / (100 - parseFloat(VAWastage8_2))) * (parseFloat(Rate8) + parseFloat(VARate8_1) + parseFloat(VARate8_2)).toFixed(2);
                $('#<%= txtAmount8.ClientID %>').val(amount8);

                X = parseFloat(amount8).toFixed(2);
                Y = parseFloat(Average8).toFixed(2);

                txtTotal[7].value = X;
                lblFabric8.html(((Y * Quantity) / 1000).toFixed(2));
                lblTotalPrice8.val(Math.round(parseFloat(X).toFixed(2)));

                var TotalAvgWstg = parseFloat(Quantity * Average8);
                txtTotalAvgWstg[7].value = Math.round(TotalAvgWstg);
            }
        }

        if (seqNum > 0) {
            var seqN = seqNum;
            seqNum--;

            var RS = $(".tablefab").find("[id$=lblRS" + seqN + "]").val();
            var lblFabric = $(".tablefab").find("[id$=lblTotalfabric" + seqN + "]");
            var lblTotalPrice = $(".tablefab").find("[id$=lblTotalPrice" + seqN + "]");

            if (isNaN(txtAvarage[seqNum].value))
                txtAvarage[seqNum].value = 0;

            if (isNaN(txtAmount[seqNum].value))
                txtAmount[seqNum].value = 0;

            var txtWasteValue = txtWaste[seqNum].value;

            if (txtWasteValue == -1)
                txtTotal[seqNum].value = 0;
            else {

                X = parseFloat(txtAmount[seqNum].value).toFixed(2);
                Y = parseFloat(txtAvarage[seqNum].value).toFixed(2);

                txtTotal[seqNum].value = X;
                lblFabric.html(((Y * Quantity) / 1000).toFixed(2)); //K
                //lblTotalPrice.val(((X * Quantity) / 100000).toFixed(2)); //L
                lblTotalPrice.val(Math.round(parseFloat(X).toFixed(2)));

                //txtTotal[seqNum].value = (Math.round((txtAmount[seqNum].value * (1 + txtWasteValue / 100)) * 1000) / 1000).toFixed(2);
            }

            var TotalAvgWstg = parseFloat(Quantity * txtAvarage[seqNum].value);
            txtTotalAvgWstg[seqNum].value = Math.round(TotalAvgWstg);
        }

        for (var i = 0; i < txtTotal.length; i++) {
            total = total + +txtTotal[i].value;
        }

        for (var i = 0; i < lblTotalP.length; i++) {
            TotalPrice = TotalPrice + +lblTotalP[i].value;
        }


        var Average1 = document.getElementById('<%=txtAverage1.ClientID%>').value;
        var Waste1 = document.getElementById('<%=txtWaste1.ClientID%>').value;
        if ((Average1 != '') && (Waste1 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average1);
            $('#<%= txtTotalAvgWstg1.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average2 = document.getElementById('<%=txtAverage2.ClientID%>').value;
        var Waste2 = document.getElementById('<%=txtWaste2.ClientID%>').value;
        if ((Average2 != '') && (Waste2 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average2);
            $('#<%= txtTotalAvgWstg2.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average3 = document.getElementById('<%=txtAverage3.ClientID%>').value;
        var Waste3 = document.getElementById('<%=txtWaste3.ClientID%>').value;
        if ((Average3 != '') && (Waste3 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average3);
            $('#<%= txtTotalAvgWstg3.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average4 = document.getElementById('<%=txtAverage4.ClientID%>').value;
        var Waste4 = document.getElementById('<%=txtWaste4.ClientID%>').value;
        if ((Average4 != '') && (Waste4 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average4);
            $('#<%= txtTotalAvgWstg4.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average5 = document.getElementById('<%=txtAverage5.ClientID%>').value;
        var Waste5 = document.getElementById('<%=txtWaste5.ClientID%>').value;
        if ((Average5 != '') && (Waste5 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average5);
            $('#<%= txtTotalAvgWstg5.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average6 = document.getElementById('<%=txtAverage6.ClientID%>').value;
        var Waste6 = document.getElementById('<%=txtWaste6.ClientID%>').value;
        if ((Average6 != '') && (Waste6 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average6);
            $('#<%= txtTotalAvgWstg6.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average7 = document.getElementById('<%=txtAverage7.ClientID%>').value;
        var Waste7 = document.getElementById('<%=txtWaste7.ClientID%>').value;
        if ((Average7 != '') && (Waste7 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average7);
            $('#<%= txtTotalAvgWstg7.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var Average8 = document.getElementById('<%=txtAverage8.ClientID%>').value;
        var Waste8 = document.getElementById('<%=txtWaste8.ClientID%>').value;
        if ((Average8 != '') && (Waste8 != '')) {

            var TotalAvgWstg = parseFloat(Quantity * Average8);
            $('#<%= txtTotalAvgWstg8.ClientID %>').val(Math.round(TotalAvgWstg));

        }

        var txtTotalA = $('#<%= txtTotalA.ClientID %>');
        if (Math.round((Math.round(total * 100) / 100).toFixed(2)) > 0) {
            txtTotalA.val(Math.round((Math.round(total * 100) / 100).toFixed(2)));
        }
        else {
            txtTotalA.val("");
        }

        txtTotalA.change();

        var lblTotalPrice = $('#<%= lblTotalPrice.ClientID %>');
        lblTotalPrice.val((Math.round(TotalPrice * 100) / 100).toFixed(2));
        ClientCurrency();
        var FabConvTotalAmount = ((txtTotalA.val() / ConvRate) * 100 / 100).toFixed(2);
        $("[id$=lblCCFabricTotal]").html("(" + symbol + FabConvTotalAmount + ")");

    }

    function AddRemoveSymbol(objCell, txtValue, symbol, isPageLoad, addInFront) {
        if (txtValue == '' || txtValue == null) {
            objCell.find('span.penny').remove();
        }
        else if ((txtValue.length >= 1 || isPageLoad)) {
            objCell.find('span.penny').remove();

            if (objCell.find('.fabric-type').length == 0) {

                if (addInFront)
                    $('<span class="penny">' + symbol + '</span>').insertBefore($(objCell.find('input')[0]));
                else
                    $('<span class="penny">' + symbol + '</span>').insertAfter($(objCell.find('input')[0]));
            }
            else if (objCell.find('.fabric-type').length > 0) {

                if (addInFront)
                    $('<span class="penny">' + symbol + '</span>').insertBefore($(objCell.find('.fabric-type')));
                else
                    $('<span class="penny">' + symbol + '</span>').insertAfter($(objCell.find('input')[0]));
            }
        }
        if (objCell.find('.costing-totalFabric').length > 0) {

            objCell.find('span.penny').remove();
        }
    }

    //Start GC
    function CalculateFOBBoutiqueValue(txtValue) {
        //  // 
        fobBoutiquePrice.val(txtValue);
        if ((txtValue != '') && (txtValue != 0)) {
            fobAgreedPrice.removeAttr('disabled');
            fobChkLandedCosting.removeAttr('disabled');
        }
        else {
            fobAgreedPrice.attr('disabled', true);
            fobChkLandedCosting.attr('disabled', true);
        }

        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

        var objCell = fobBoutiquePrice.closest("td");
        //AddRemoveSymbol(objCell, fobBoutiquePrice.val(), symbol, true, true);
        $('#<%=grdLandedCosting.ClientID%>').find('input:text[id$="txtMargin"]').each(function () {
            var fobmarginvalue = $(this).val();
            var row = $(this).closest('td');
            var fobikandivalue = row.prev().prev().prev().prev().prev().prev().find("input[type=text]");
            if (fobmarginvalue == 1 || isNaN(fobmarginvalue) || fobmarginvalue == "")
                fobikandivalue.val(0);
            else
                fobikandivalue.val((Math.round(txtValue / (1 - (fobmarginvalue / 100)) * 1000) / 1000).toFixed(2));


            var evnt = $(this);
            var row = $(this).closest('tr');
            var txtGrandTotal = row.find('input:text[id$="txtGrandTotal"]');

            txtGrandTotal.val(GetGrandTotal(this));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtGrandTotal.closest("td");
            AddRemoveSymbol(objCell, txtGrandTotal.val(), symbol, true, true);
        });

        $('#<%=grdDirectCosting.ClientID%>').find('input:text[id$="txtMargin"]').each(function () {
            var evnt = $(this);
            var row = $(this).closest('tr');
            var txtGrandTotal = row.find('input:text[id$="txtGrandTotal"]');

            txtGrandTotal.val(GetGrandTotalDC(this));

            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
            var objCell = txtGrandTotal.closest("td");
            AddRemoveSymbol(objCell, txtGrandTotal.val(), symbol, true, true);
        });

        objCell = fobIKandi.closest("td");
        //AddRemoveSymbol(objCell, fobIKandi.val(), symbol, true, true);
    }

    function CalculateDeliveryDate() {
        for (var i = 0; i < deliveryDate.length; i++) {
            var dd = new Date(ParseDateToSimpleDate(expectedDate[i].value));
            dd = dd.add(modeDeliveryTime[i].value * 7).days();
            deliveryDate[i].value = ParseDateToDateWithDay(dd);
        }
    }

    function CalculateLeadTime(sender) {
        var txtLeadTime = sender.closest('tr').find('input[type=text].costing-landed-costing-mode-delivery-time');
        var txtExpectedDate = sender.closest('tr').find('input[type=text].costing-landed-costing-expected-date');

        var expectedDate = new Date(ParseDateToSimpleDate(txtExpectedDate.val()));
        var deliveryDate = new Date(ParseDateToSimpleDate(sender.val()));

        if (deliveryDate < expectedDate) {
            sender.val(txtExpectedDate.val());
            txtLeadTime.val(0);
            return;
        }

        var leadTime = Math.round((deliveryDate - expectedDate) / (1000 * 60 * 60 * 24 * 7));
        txtLeadTime.val(leadTime);
    }
    //End GC

    $(function () {
        LoadFabricFrom_Style(1);
        FabricPrintSugg1();
        FabricPrintSugg2();
        FabricPrintSugg3();
        FabricPrintSugg4();
        FabricPrintSugg5();
        FabricPrintSugg6();
        FabricPrintSugg7();
        FabricPrintSugg8();
    });

    function FabricPrintSugg1() {

        $('input.fab_prt1', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", {
            dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                {
                    stno: function () {
                        return PageStyleId + '##' + document.getElementById('<%=txtFabric1.ClientID %>').value;
                    },
                    ClientID: function () {
                        $(this).flushCache();
                        return $("#" + BuyerDDClientID).val();
                    },
                    PrintCategory: $('.fab_Type1 option:selected').val()
                }
        });

        $('input.fab_prt1', '#main_content').result(function () {
            if ($(this).val().includes('[')) {
                var p = $(this).val().split('[');
                var prno = p[1];
                var tt = prno.split(' --- ');
                var PrintName = p[0] + ' --- ' + tt[1];
                $(this).val(PrintName);
            }
            chk($(this).val(), 1);
        });
    }
    function chk(prt, rowno) {

        var temp = 0;
        var newprt = new Array();
        var s1;
        var pos = prt.indexOf(' --- ');
        if (pos > 0) {
            var tt = new Array();
            tt = prt.split(' --- ');

            s1 = tt[1];
        }
        else {
            newprt = prt.split('[');
            s1 = newprt[0];
            temp = temp + 1;

        }
        document.getElementById('fab1hdn').value = s1;
        var r3 = document.getElementById('fab2hdn').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1 },
                     function (result) {
                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1, rowno); RemovePrintRow(r3);
                                 if (prt.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd11').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd11').innerHTML = "";


                                 if (s1.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1.split(' ');
                                     //GetFabricQualityData($("#" + txtFabricClientID1).val(), " ", $("#" + hiddenRadioModeClientID1).val(), 1);

                                 }
                                 //else
                                 //GetFabricQualityData($("#" + txtFabricClientID1).val(), " ", $("#" + hiddenRadioModeClientID1).val(), 1);
                                 $("#" + hidFab1DetailsClientID).val("#"); $(".afab").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3);
                                 document.getElementById('lblprd11').innerHTML = "";
                                 //GetFabricQualityData($("#" + txtFabricClientID1).val(), "COL", $("#" + hiddenRadioModeClientID1).val(), 1);
                                 $("#" + hidFab1DetailsClientID).val("COL"); $(".afab").val("COL");
                             }
                         }
                     });
        document.getElementById('fab2hdn').value = s1;
    }
    $(document).ready(function () {
        var ee = $("input.fab_prt1").val();
        if (ee == undefined)
            return;
        if (ee == "")
            return;
        if (ee == "") {
            $("input.fab_prt1").val("");
        }
        else {
            var s1;
            var pos = ee.indexOf(' --- ');
            if (pos > 0) {
                var tt = new Array();
                tt = ee.split(' --- ');
                s1 = tt[1];
                NewPrintGetOnLoad(s1, 1);
            }
            else {
                s1 = ee;
                NewPrintGetOnLoad(s1, 1);
            }

            document.getElementById('fab1hdn').value = s1;
            document.getElementById('fab2hdn').value = s1;
        }
    }
 );
    //2nd Print

    function FabricPrintSugg2() {
        $('input.fab_prt2', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric2.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     },
                     PrintCategory: $('.fab_Type2 option:selected').val()
                 }
        });
        $('input.fab_prt2', '#main_content').result(function () {
            //  // // 

            var p = $(this).val().split('[');
            var prno = p[1];
            var tt = prno.split(' --- ');
            var PrintName = p[0] + ' --- ' + tt[1];
            var FabtypeVal = PrintName;

            $(this).val(PrintName);
            chk2($(this).val(), 2);

        });
    }

    function chk2(prtf2, rowno) {

        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('[');
            s1f2 = newprtf2[0];
        }
        document.getElementById('fab22hdn').value = s1f2;
        var r3f2 = document.getElementById('fab22hdn2').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {

                                 AddNewPrintRow(s1f2, rowno);
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd22').innerHTML = "PRD: ";
                                 }
                                 else {
                                     document.getElementById('lblprd22').innerHTML = "";
                                 }
                                 if (s1f2.indexOf(' ') != "-1") {
                                     //$(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     //GetFabricQualityData($("#" + txtFabricClientID2).val(), " ", $("#" + hiddenRadioModeClientID2).val(), 2);

                                 }
                                 //else
                                 //GetFabricQualityData($("#" + txtFabricClientID2).val(), " ", $("#" + hiddenRadioModeClientID2).val(), 2);
                                 $("#" + hidFab2DetailsClientID).val("#"); $(".b").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2); ; document.getElementById('lblprd22').innerHTML = "";
                                 // GetFabricQualityData($("#" + txtFabricClientID2).val(), "COL", $("#" + hiddenRadioModeClientID2).val(), 2);
                                 $("#" + hidFab2DetailsClientID).val("COL"); $(".b").val("COL");
                             }
                         }
                     });
        document.getElementById('fab22hdn2').value = s1f2;
    }
    $(document).ready(function () {

        var eeff2 = $("input.fab_prt2").val();

        if (eeff2 == undefined)
            return;
        if (eeff2 == "")
            return;
        if (eeff2 == "") {
            $("input.fab_prt2").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 2);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 2);
            }
            document.getElementById('fab22hdn').value = s1ff2;
            document.getElementById('fab22hdn2').value = s1ff2;
        }
    }
 );


    //3rd Print 
    function FabricPrintSugg3() {
        $('input.fab_prt3', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric3.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     },
                     PrintCategory: $('.fab_Type3 option:selected').val()
                 }
        });
        $('input.fab_prt3', '#main_content').result(function () {
            var p = $(this).val().split('[');
            var prno = p[1];
            var tt = prno.split(' --- ');
            var PrintName = p[0] + ' --- ' + tt[1];
            //alert(PrintName);
            $(this).val(PrintName);
            chk3($(this).val(), 3);
        });
    }

    function chk3(prtf2, rowno) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('[');
            s1f2 = newprtf2[0];
        }
        document.getElementById('fab33hdn').value = s1f2;
        var r3f2 = document.getElementById('fab33hdn3').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1f2 },
                     function (result) {
                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {



                                 AddNewPrintRow(s1f2, rowno);
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd33').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd33').innerHTML = "";
                                 if (s1f2.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     //GetFabricQualityData($("#" + txtFabricClientID3).val(), " ", $("#" + hiddenRadioModeClientID3).val(), 3);

                                 }
                                 //else
                                 //GetFabricQualityData($("#" + txtFabricClientID3).val(), " ", $("#" + hiddenRadioModeClientID3).val(), 3);
                                 $("#" + hidFab3DetailsClientID).val("#"); $(".c").val("#");
                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2);
                                 document.getElementById('lblprd33').innerHTML = "";
                                 //GetFabricQualityData($("#" + txtFabricClientID3).val(), "COL", $("#" + hiddenRadioModeClientID3).val(), 3);
                                 $("#" + hidFab3DetailsClientID).val("COL"); $(".c").val("COL");
                             }
                         }
                     });
        document.getElementById('fab33hdn3').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt3").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == "")
            return;
        if (eeff2 == "") {
            $("input.fab_prt3").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 3);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 3);
            }
            document.getElementById('fab33hdn').value = s1ff2;
            document.getElementById('fab33hdn3').value = s1ff2;
        }
    }
 );

    //4th Print 
    function FabricPrintSugg4() {
        $('input.fab_prt4', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric4.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     },
                     PrintCategory: $('.fab_Type4 option:selected').val()
                 }
        });
        $('input.fab_prt4', '#main_content').result(function () {
            var p = $(this).val().split('[');
            var prno = p[1];
            var tt = prno.split(' --- ');
            var PrintName = p[0] + ' --- ' + tt[1];
            $(this).val(PrintName);
            chk4($(this).val(), 4);
        });
    }

    function chk4(prtf2, rowno) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('[');
            s1f2 = newprtf2[0];

        }

        document.getElementById('fab44hdn').value = s1f2;
        var r3f2 = document.getElementById('fab44hdn4').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1f2, rowno);
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd44').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd44').innerHTML = "";


                                 if (s1f2.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     //GetFabricQualityData($("#" + txtFabricClientID4).val(), " ", $("#" + hiddenRadioModeClientID4).val(), 4);

                                 }
                                 else
                                 //GetFabricQualityData($("#" + txtFabricClientID4).val(), " ", $("#" + hiddenRadioModeClientID4).val(), 4);
                                     $("#" + hidFab4DetailsClientID).val("#"); $(".d").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2);
                                 document.getElementById('lblprd44').innerHTML = "";
                                 //GetFabricQualityData($("#" + txtFabricClientID4).val(), "COL", $("#" + hiddenRadioModeClientID4).val(), 4);
                                 $("#" + hidFab4DetailsClientID).val("COL"); $(".d").val("COL");
                             }
                         }
                     });
        document.getElementById('fab44hdn4').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt4").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == "")
            return;
        if (eeff2 == "") {
            $("input.fab_prt4").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 4);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 4);
            }
            document.getElementById('fab44hdn').value = s1ff2;
            document.getElementById('fab44hdn4').value = s1ff2;
        }
    }

 );

    //5th Print 
    function FabricPrintSugg5() {
        $('input.fab_prt5', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric5.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     },
                     PrintCategory: $('.fab_Type5 option:selected').val()
                 }
        });
        $('input.fab_prt5', '#main_content').result(function () {
            var p = $(this).val().split('[');
            var prno = p[1];
            var tt = prno.split(' --- ');
            var PrintName = p[0] + ' --- ' + tt[1];
            $(this).val(PrintName);
            chk5($(this).val(), 5);
        });
    }

    function chk5(prtf2, rowno) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('[');
            s1f2 = newprtf2[0];

        }

        document.getElementById('fab55hdn').value = s1f2;
        var r3f2 = document.getElementById('fab55hdn5').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1f2, rowno);
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd55').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd55').innerHTML = "";


                                 if (s1f2.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     //GetFabricQualityData($("#" + txtFabricClientID5).val(), " ", $("#" + hiddenRadioModeClientID5).val(), 5);

                                 }
                                 else
                                 // GetFabricQualityData($("#" + txtFabricClientID5).val(), " ", $("#" + hiddenRadioModeClientID5).val(), 5);
                                     $("#" + hidFab5DetailsClientID).val("#"); $(".d").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2);
                                 document.getElementById('lblprd55').innerHTML = "";
                                 // GetFabricQualityData($("#" + txtFabricClientID5).val(), "COL", $("#" + hiddenRadioModeClientID5).val(), 5);
                                 $("#" + hidFab5DetailsClientID).val("COL"); $(".d").val("COL");
                             }
                         }
                     });
        document.getElementById('fab55hdn5').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt5").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == "")
            return;
        if (eeff2 == "") {
            $("input.fab_prt5").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 5);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 5);
            }
            document.getElementById('fab55hdn').value = s1ff2;
            document.getElementById('fab55hdn5').value = s1ff2;
        }
    }

 );

    //6th Print 
    function FabricPrintSugg6() {
        $('input.fab_prt6', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric6.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     },
                     PrintCategory: $('.fab_Type6 option:selected').val()
                 }
        });
        $('input.fab_prt6', '#main_content').result(function () {
            var p = $(this).val().split('[');
            var prno = p[1];
            var tt = prno.split(' --- ');
            var PrintName = p[0] + ' --- ' + tt[1];
            $(this).val(PrintName);
            chk6($(this).val(), 6);
        });
    }

    function chk6(prtf2, rowno) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('[');
            s1f2 = newprtf2[0];

        }

        document.getElementById('fab66hdn').value = s1f2;
        var r3f2 = document.getElementById('fab66hdn6').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1f2, rowno);
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd66').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd66').innerHTML = "";


                                 if (s1f2.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     //GetFabricQualityData($("#" + txtFabricClientID6).val(), " ", $("#" + hiddenRadioModeClientID6).val(), 6);

                                 }
                                 else
                                 //GetFabricQualityData($("#" + txtFabricClientID6).val(), " ", $("#" + hiddenRadioModeClientID6).val(), 6);
                                     $("#" + hidFab6DetailsClientID).val("#"); $(".d").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2);
                                 document.getElementById('lblprd66').innerHTML = "";
                                 // GetFabricQualityData($("#" + txtFabricClientID6).val(), "COL", $("#" + hiddenRadioModeClientID6).val(), 6);
                                 $("#" + hidFab6DetailsClientID).val("COL"); $(".d").val("COL");
                             }
                         }
                     });
        document.getElementById('fab66hdn6').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt6").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == "")
            return;
        if (eeff2 == "") {
            $("input.fab_prt6").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 6);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 6);
            }
            document.getElementById('fab66hdn').value = s1ff2;
            document.getElementById('fab66hdn6').value = s1ff2;
        }
    }

 );

    //7th Print 
    function FabricPrintSugg7() {
        $('input.fab_prt7', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric7.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     },
                     PrintCategory: $('.fab_Type7 option:selected').val()
                 }
        });
        $('input.fab_prt7', '#main_content').result(function () {
            var p = $(this).val().split('[');
            var prno = p[1];
            var tt = prno.split(' --- ');
            var PrintName = p[0] + ' --- ' + tt[1];
            $(this).val(PrintName);
            chk7($(this).val(), 7);
        });
    }

    function chk7(prtf2, rowno) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('[');
            s1f2 = newprtf2[0];

        }

        document.getElementById('fab77hdn').value = s1f2;
        var r3f2 = document.getElementById('fab77hdn7').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1f2, rowno);
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd77').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd77').innerHTML = "";


                                 if (s1f2.indexOf(' ') != "-1") {
                                     //  $(".hidden-details").val(" ");
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');
                                     //GetFabricQualityData($("#" + txtFabricClientID7).val(), " ", $("#" + hiddenRadioModeClientID7).val(), 7);

                                 }
                                 else
                                 // GetFabricQualityData($("#" + txtFabricClientID7).val(), " ", $("#" + hiddenRadioModeClientID7).val(), 7);
                                     $("#" + hidFab7DetailsClientID).val("#"); $(".d").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2);
                                 document.getElementById('lblprd77').innerHTML = "";
                                 // GetFabricQualityData($("#" + txtFabricClientID7).val(), "COL", $("#" + hiddenRadioModeClientID7).val(), 7);
                                 $("#" + hidFab7DetailsClientID).val("COL"); $(".d").val("COL");
                             }
                         }
                     });
        document.getElementById('fab77hdn7').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt7").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == "")
            return;
        if (eeff2 == "") {
            $("input.fab_prt7").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 7);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 7);
            }
            document.getElementById('fab77hdn').value = s1ff2;
            document.getElementById('fab77hdn7').value = s1ff2;
        }
    }

 );

    //8th Print 
    function FabricPrintSugg8() {
        $('input.fab_prt8', '#main_content').autocomplete1("/Webservices/iKandiService.asmx/SuggestPrintNumbers_ForMultiplePrints_New", { dataType: "xml", datakey: "string", max: 100, "width": "400",
            extraParams:
                 {
                     stno: function () {
                         return PageStyleId + '##' + document.getElementById('<%=txtFabric8.ClientID %>').value;
                     },
                     ClientID: function () {
                         $(this).flushCache();
                         return $("#" + BuyerDDClientID).val();
                     },
                     PrintCategory: $('.fab_Type8 option:selected').val()
                 }
        });
        $('input.fab_prt8', '#main_content').result(function () {
            var p = $(this).val().split('[');
            var prno = p[1];
            var tt = prno.split(' --- ');
            var PrintName = p[0] + ' --- ' + tt[1];
            $(this).val(PrintName);
            chk8($(this).val(), 8);
        });
    }

    function chk8(prtf2, rowno) {
        var newprt = new Array();
        var s1f2;
        var posf2 = prtf2.indexOf(' --- ');
        if (posf2 > 0) {
            var ttf2 = new Array();
            ttf2 = prtf2.split(' --- ');
            s1f2 = ttf2[1];
        }
        else {
            newprtf2 = prtf2.split('[');
            s1f2 = newprtf2[0];

        }

        document.getElementById('fab88hdn').value = s1f2;
        var r3f2 = document.getElementById('fab88hdn8').value;
        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrint_New", { PrintNumber: s1f2 },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(s1f2, rowno);
                                 RemovePrintRow(r3f2);
                                 if (prtf2.indexOf(' --- ') == "-1") {
                                     document.getElementById('lblprd88').innerHTML = "PRD: ";
                                 }
                                 else
                                     document.getElementById('lblprd88').innerHTML = "";


                                 if (s1f2.indexOf(' ') != "-1") {
                                     var temp2 = new Array();
                                     temp2 = s1f2.split(' ');

                                 }
                                 else
                                     $("#" + hidFab8DetailsClientID).val("#"); $(".d").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 RemovePrintRow(r3f2);
                                 document.getElementById('lblprd88').innerHTML = "";
                                 $("#" + hidFab8DetailsClientID).val("COL"); $(".d").val("COL");
                             }
                         }
                     });
        document.getElementById('fab88hdn8').value = s1f2;
    }
    $(document).ready(function () {
        var eeff2 = $("input.fab_prt8").val();
        if (eeff2 == undefined)
            return;
        if (eeff2 == "")
            return;
        if (eeff2 == "") {
            $("input.fab_prt8").val("");
        }
        else {
            var s1ff2;
            var posff2 = eeff2.indexOf(' --- ');
            if (posff2 > 0) {
                var ttff2 = new Array();
                ttff2 = eeff2.split(' --- ');
                s1ff2 = ttff2[1];
                NewPrintGetOnLoad(s1ff2, 8);
            }
            else {
                s1ff2 = eeff2;
                NewPrintGetOnLoad(s1ff2, 8);
            }
            document.getElementById('fab88hdn').value = s1ff2;
            document.getElementById('fab88hdn8').value = s1ff2;
        }
    }

 );

    function NewPrintGetOnLoad(PrintNumberNow, rowno) {

        proxy.invoke("GetFabricQualityDetailsByTradeNameForPrintOnLoad_New", { PrintNumber: PrintNumberNow },
                     function (result) {

                         if (result == null || result == '')
                             return;
                         else {
                             if (result.CountConstruction == "Y") {
                                 AddNewPrintRow(PrintNumberNow, rowno);
                                 $("input.fab_prt" + rowno).val(result.TradeName);
                                 if (rowno == "2") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd22').innerHTML = "PRD: ";
                                 }

                                 if (rowno == "3") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd33').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "4") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd44').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "5") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd55').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "6") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd66').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "7") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd77').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "8") {
                                     if (result.Composition == "N")
                                         document.getElementById('lblprd88').innerHTML = "PRD: ";
                                 }
                                 if (rowno == "1")
                                     $(".afab").val("#");
                                 if (rowno == "2")
                                     $(".b").val("#");
                                 if (rowno == "3")
                                     $(".c").val("#");
                                 if (rowno == "4")
                                     $(".d").val("#");
                                 if (rowno == "5")
                                     $(".e").val("#");
                                 if (rowno == "6")
                                     $(".f").val("#");
                                 if (rowno == "7")
                                     $(".g").val("#");
                                 if (rowno == "8")
                                     $(".h").val("#");

                             }
                             if (result.CountConstruction == "N") {
                                 if (rowno == "3")
                                     document.getElementById('lblprd33').innerHTML = "";
                                 if (rowno == "4")
                                     document.getElementById('lblprd44').innerHTML = "";
                                 if (rowno == "1")
                                     $(".afab").val("COL");
                                 if (rowno == "2")
                                     $(".b").val("COL");
                                 if (rowno == "3")
                                     $(".c").val("COL");
                                 if (rowno == "4")
                                     $(".d").val("COL");
                             }
                         }
                     });
    }


    function onPageError(error) {

        alert(error.Message + ' -- ' + error.detail);
    }

    function AddNewPrintRow(printNumber, rowno) {

        if (printNumber != '') {
            $('table #costing_print_table' + rowno).removeClass('hide_me');

        }
        var isPrint = 0;
        // below is comented by sanjeev 
        //        if (printNumber.indexOf(' ') > -1) {
        //            var Fab1Det = printNumber.split(' ');
        //            if ((Fab1Det.length == 1 && isNumeric(Fab1Det[0])) || (Fab1Det.length == 2 && Fab1Det[1].length <= 2))
        //                if (Fab1Det[0] != '' && Fab1Det[0] != null) {
        //                    if (isNumeric(Fab1Det[0])) {
        //                        isPrint = 1;
        //                    }
        //                }
        //        }
        //        else
        //            if (isNumeric(printNumber)) {
        //                isPrint = 1;
        //            }
        var printNew = printNumber.replace(" ", "");
        isPrint = 1;
        if (isPrint == 1) {
            proxy.invoke("GetPrintImageUrlByPrintNumber_New", { PrintNumber: printNumber },
                function (printImageUrl) {

                    if (printImageUrl != null && printImageUrl != 'INVALID') {

                        var isReturn = false;

                        var newPrintTD = $('table #costing_print_table' + rowno + ' tbody tr').find('td:last');
                        newPrintTD.attr('className', 'prd-' + printNew);
                        newPrintTD.attr('class', 'prd-' + printNew);

                        newPrintTD.find('.costing-print' + rowno).val(printNumber);
                        var root = location.protocol + '//' + location.host;
                        newPrintTD.find('.box' + rowno).attr('href', root + '/Uploads/Print/' + printImageUrl);
                        newPrintTD.find('.costing-print-image' + rowno).attr('src', root + '/Uploads/Print/thumb-' + printImageUrl);
                        newPrintTD.show();

                    }
                    else {
                    }
                }, onPageError, false, false);
        }
    }


    function DeleteFabric(fab) {


        var GrdRowCount = $("tr.rowCount").length;
        if (confirm('Are you sure you want to delete this fabric?')) {

            var fablength = $('#tbodyFab .tr-fab:visible').length;


            if (fablength <= 6) {

                $('#AddFebricbutton').find('img').show(500);

            }
            var countRowDel = fab - 1;
            if (countRowDel < fab) {
                $("#ctl00_cph_main_content_CostingFormNew1_tr_fab" + countRowDel).find('.FabricDeleteButton a').removeClass("HideButton");
            }


            var delFeb = document.getElementById('<%=hdnDeleteFabric.ClientID %>').value;
            if (delFeb == "") {
                var specialFabricDetails = "";
                var febricName = $(".tr-fab").find("[id$=txtFabric" + fab + "]").val();
                $(".tr-fab").find("[id$=txtFabric" + fab + "]").css("background-color", "");
                var febricTypeName = $(".tr-fab").find("[id$=txtFabricType" + fab + "]").val();
                var fabtype = $('.fab_Type' + fab + ' option:selected').val();
                if (febricTypeName.includes(' --- ')) {
                    var x = febricTypeName.split(' --- ');
                    specialFabricDetails = x[1];
                }
                else {
                    specialFabricDetails = febricTypeName;
                }
                var Codeval = febricName + "@#$:~#@" + fabtype + "@#$:~#@" + specialFabricDetails;
                delFeb = Codeval;
            }
            else {
                var specialFabricDetails = "";
                var febricName = $(".tr-fab").find("[id$=txtFabric" + fab + "]").val();
                $(".tr-fab").find("[id$=txtFabric" + fab + "]").css("background-color", "");
                var febricTypeName = $(".tr-fab").find("[id$=txtFabricType" + fab + "]").val();
                var fabtype = $('.fab_Type' + fab + ' option:selected').val();
                if (febricTypeName.includes(' --- ')) {
                    var x = febricTypeName.split(' --- ');
                    specialFabricDetails = x[1];
                }
                else {
                    specialFabricDetails = febricTypeName;
                }
                var Codeval = febricName + "@#$:~#@" + fabtype + "@#$:~#@" + specialFabricDetails;
                delFeb = delFeb + "!!!!!" + Codeval;
            }
            document.getElementById('<%=hdnDeleteFabric.ClientID %>').value = delFeb;
            if (fablength == 1) {
                ShowHideValidationBox(true, 'At Least one fabric is required.', 'Costing Sheet');
                return;
            }
            ResetFabric(fab);
            if (fab == 1)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab1').hide(500);
            if (fab == 2)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab2').hide(500);
            if (fab == 3)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab3').hide(500);
            if (fab == 4)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab4').hide(500);
            if (fab == 5)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab5').hide(500);
            if (fab == 6)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab6').hide(500);
            if (fab == 7)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab7').hide(500);
            if (fab == 8)
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab8').hide(500);
        }
    }
    function AddFabric(fab) {

        var fablength = $('a.HideButton').length;
        var countRowDel = fablength + 1;
        if (countRowDel > fablength) {
            $("#ctl00_cph_main_content_CostingFormNew1_tr_fab" + countRowDel).find('.FabricDeleteButton a').addClass("HideButton");
        }

        var fablength = $('#tbodyFab .tr-fab:visible').length;
        var fabric = $(".tr-fab").find("[id$=txtFabric" + fab + "]").val();
        if (fabric != "") {
            if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab1').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab1').show(500);
                FabricPrintSugg1();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab2').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab2').show(500);
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab2').attr("color", "");
                FabricPrintSugg2();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab3').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab3').show(500);
                FabricPrintSugg3();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab4').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab4').show(500);
                FabricPrintSugg4();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab5').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab5').show(500);
                FabricPrintSugg5();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab6').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab6').show(500);
                FabricPrintSugg6();
                //  $('#AddFebricbutton').find('img').hide(500); // shubhendu added on 08-11-2021
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab7').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab7').show(500);
                FabricPrintSugg7();
                // $('#AddFebricbutton').find('img').hide(500); 
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab8').is(':visible')) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab8').show(500);
                FabricPrintSugg8();

            }

        }
        if (fablength >= 5) {// change by  shubhendu  on 08-11-2021 from 7 to 4
            $('#AddFebricbutton').find('img').hide(500);   // add code by bharat feb-6
            //ShowHideValidationBox(true, 'Sorry! you cannot add more than Eight fabrics.', 'Costing Sheet');
            //return;
            //alert("hide");
        }
    }
    function LoadFabricFrom_Style(fab) {

        //alert("chk");
        var fablength = $('#tbodyFab .tr-fab:visible').length;
        var fabric = $(".tr-fab").find("[id$=txtFabric" + fablength + "]").val();
        if (fabric != "") {
            if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab1').is(':visible') && fablength >= 1) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab1').show(500);
                FabricPrintSugg1();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab2').is(':visible') && fablength >= 2) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab2').show(500);
                FabricPrintSugg2();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab3').is(':visible') && fablength >= 3) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab3').show(500);
                FabricPrintSugg3();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab4').is(':visible') && fablength >= 4) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab4').show(500);
                FabricPrintSugg4();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab5').is(':visible') && fablength >= 5) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab5').show(500);
                FabricPrintSugg5();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab6').is(':visible') && fablength >= 6) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab6').show(500);
                FabricPrintSugg6();
            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab7').is(':visible') && fablength >= 7) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab7').show(500);
                FabricPrintSugg7();

            }
            else if (!$('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab8').is(':visible') && fablength == 8) {
                $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab8').show(500);
                FabricPrintSugg8();
            }


        }

        if (fablength >= 6) {

            $('#AddFebricbutton').find('img').hide();

        }
    }

    function ResetFabric(srno) {
        //

        $('input.fabric' + srno).val("");
        $('.GSML' + srno).html("");
        $('.COUNTCON' + srno).html("");
        $('.fab_Type' + srno).val('2');
        $('input.fab_prt' + srno).val('');
        $('.div_show' + srno).addClass('hide_me');
        $('.ShowHideFile' + srno).attr("style", "display:none");
        $('table #costing_print_table' + srno).addClass('hide_me');

        if (srno == 1) {
            $("#" + hiddenRadioModeClientID1).val("1");
            $("#" + lblOriginClientID1).html("");
            $("#" + txtWidthClientID1).val("");
            radiomode1[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric1]").html("");
            $(".tablefab").find("[id$=lblTotalPrice1]").val("");
            $(".tablefab").find("[id$=lblRS1]").val("");
            $('#<%= txtAmount1.ClientID %>').val(0);
            document.getElementById('<%=txtAverage1.ClientID%>').value = '';
            document.getElementById('<%=txtWaste1.ClientID %>').value = '';
            document.getElementById('<%=txtRate1.ClientID%>').value = '';
            document.getElementById('<%=txtTotal1.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM1]").html('');
            $(".tr-fab").find("[id$=hdnFabricID1]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate1]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate1]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate1]").val('0');
        }
        else if (srno == 2) {
            $("#" + hiddenRadioModeClientID2).val("1");
            $("#" + lblOriginClientID2).html("");
            $("#" + txtWidthClientID2).val("");
            radiomode2[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric2]").html("");
            $(".tablefab").find("[id$=lblTotalPrice2]").val("");
            $(".tablefab").find("[id$=lblRS2]").val("");
            $('#<%= txtAmount2.ClientID %>').val(0);
            document.getElementById('<%=txtAverage2.ClientID%>').value = '';
            document.getElementById('<%=txtWaste2.ClientID %>').value = '';
            document.getElementById('<%=txtRate2.ClientID%>').value = '';
            document.getElementById('<%=txtTotal2.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM2]").html('');
            $(".tr-fab").find("[id$=hdnFabricID2]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate2]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate2]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate2]").val('0');
        }
        else if (srno == 3) {
            $("#" + hiddenRadioModeClientID3).val("1");
            $("#" + lblOriginClientID3).html("");
            $("#" + txtWidthClientID3).val("");
            radiomode3[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric3]").html("");
            $(".tablefab").find("[id$=lblTotalPrice3]").val("");
            $(".tablefab").find("[id$=lblRS3]").val("");
            $('#<%= txtAmount3.ClientID %>').val(0);
            document.getElementById('<%=txtAverage3.ClientID%>').value = '';
            document.getElementById('<%=txtWaste3.ClientID %>').value = '';
            document.getElementById('<%=txtRate3.ClientID%>').value = '';
            document.getElementById('<%=txtTotal3.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM3]").html('');
            $(".tr-fab").find("[id$=hdnFabricID3]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate3]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate3]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate3]").val('0');
        }
        else if (srno == 4) {
            $("#" + hiddenRadioModeClientID4).val("1");
            $("#" + lblOriginClientID4).html("");
            $("#" + txtWidthClientID4).val("");
            radiomode4[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric4]").html("");
            $(".tablefab").find("[id$=lblTotalPrice4]").val("");
            $(".tablefab").find("[id$=lblRS4]").val("");
            $('#<%= txtAmount4.ClientID %>').val(0);
            document.getElementById('<%=txtAverage4.ClientID%>').value = '';
            document.getElementById('<%=txtWaste4.ClientID %>').value = '';
            document.getElementById('<%=txtRate4.ClientID%>').value = '';
            document.getElementById('<%=txtTotal4.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM4]").html('');
            $(".tr-fab").find("[id$=hdnFabricID4]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate4]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate4]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate4]").val('0');
        }
        else if (srno == 5) {
            $("#" + hiddenRadioModeClientID5).val("1");
            $("#" + lblOriginClientID5).html("");
            $("#" + txtWidthClientID5).val("");
            radiomode5[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric5]").html("");
            $(".tablefab").find("[id$=lblTotalPrice5]").val("");
            $(".tablefab").find("[id$=lblRS5]").val("");
            $('#<%= txtAmount5.ClientID %>').val(0);
            document.getElementById('<%=txtAverage5.ClientID%>').value = '';
            document.getElementById('<%=txtWaste5.ClientID %>').value = '';
            document.getElementById('<%=txtRate5.ClientID%>').value = '';
            document.getElementById('<%=txtTotal5.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM5]").html('');
            $(".tr-fab").find("[id$=hdnFabricID5]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate5]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate5]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate5]").val('0');
        }
        else if (srno == 6) {
            $("#" + hiddenRadioModeClientID6).val("1");
            $("#" + lblOriginClientID6).html("");
            $("#" + txtWidthClientID6).val("");
            radiomode6[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric6]").html("");
            $(".tablefab").find("[id$=lblTotalPrice6]").val("");
            $(".tablefab").find("[id$=lblRS6]").val("");
            $('#<%= txtAmount6.ClientID %>').val(0);
            document.getElementById('<%=txtAverage6.ClientID%>').value = '';
            document.getElementById('<%=txtWaste6.ClientID %>').value = '';
            document.getElementById('<%=txtRate6.ClientID%>').value = '';
            document.getElementById('<%=txtTotal6.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM6]").html('');
            $(".tr-fab").find("[id$=hdnFabricID6]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate6]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate6]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate6]").val('0');
        }
        else if (srno == 7) {
            $("#" + hiddenRadioModeClientID7).val("1");
            $("#" + lblOriginClientID7).html("");
            $("#" + txtWidthClientID7).val("");
            radiomode7[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric7]").html("");
            $(".tablefab").find("[id$=lblTotalPrice7]").val("");
            $(".tablefab").find("[id$=lblRS7]").val("");
            $('#<%= txtAmount7.ClientID %>').val(0);
            document.getElementById('<%=txtAverage7.ClientID%>').value = '';
            document.getElementById('<%=txtWaste7.ClientID %>').value = '';
            document.getElementById('<%=txtRate7.ClientID%>').value = '';
            document.getElementById('<%=txtTotal7.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM7]").html('');
            $(".tr-fab").find("[id$=hdnFabricID7]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate7]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate7]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate7]").val('0');
        }
        else if (srno == 8) {
            $("#" + hiddenRadioModeClientID8).val("1");
            $("#" + lblOriginClientID8).html("");
            $("#" + txtWidthClientID8).val("");
            radiomode8[0].checked = true;
            $(".tablefab").find("[id$=lblTotalfabric8]").html("");
            $(".tablefab").find("[id$=lblTotalPrice8]").val("");
            $(".tablefab").find("[id$=lblRS8]").val("");
            $('#<%= txtAmount8.ClientID %>').val(0);
            document.getElementById('<%=txtAverage8.ClientID%>').value = '';
            document.getElementById('<%=txtWaste8.ClientID %>').value = '';
            document.getElementById('<%=txtRate8.ClientID%>').value = '';
            document.getElementById('<%=txtTotal8.ClientID%>').value = '';

            $(".tr-fab").find("[id$=lblWidthCM8]").html('');
            $(".tr-fab").find("[id$=hdnFabricID8]").val('0');
            $(".tr-fab").find("[id$=hdnDyedRate8]").val('0');
            $(".tr-fab").find("[id$=hdnPrintRate8]").val('0');
            $(".tr-fab").find("[id$=hdnDigitalPrintRate8]").val('0');
        }
        CalculateCostingTotal(srno);
    }
    function ShowHideFabric() {
        if ($("input.fabric2").val() == '' || $("input.fabric2").val() == null) {
            $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab2').hide();
        }
        if ($("input.fabric3").val() == '' || $("input.fabric3").val() == null) {
            $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab3').hide();
        }
        if ($("input.fabric4").val() == '' || $("input.fabric4").val() == null) {
            $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab4').hide();
        }
        if ($("input.fabric5").val() == '' || $("input.fabric5").val() == null) {
            $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab5').hide();
        }
        if ($("input.fabric6").val() == '' || $("input.fabric6").val() == null) {
            $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab6').hide();
        }
        if ($("input.fabric7").val() == '' || $("input.fabric7").val() == null) {
            $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab7').hide();
        }
        if ($("input.fabric8").val() == '' || $("input.fabric8").val() == null) {
            $('#tbodyFab #ctl00_cph_main_content_CostingFormNew1_tr_fab8').hide();
        }
    }


    //Accessary Part

    $(document).ready(function () {
        CalculateAccessoriesTotal(null);
        TotalAccessoriesAmount();
        TotalProcessAmount();
        CalculateChargesTotal();

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);
        PageLoad();

        $("[id$=txtChargesValue1]").keyup(function (e) {
            var ConvRate = $('#<%= hdnConvRate.ClientID %>').val();
            var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

            var TotalB = $("[id$=txtChargesValue1]").val();
            var TotalBAmount = (TotalB * 100 / 100).toFixed(2);
            $("[id$=lblTotalAmountB]").val(Math.round(TotalBAmount));

            var ConvTotalBAmount = ((TotalBAmount / ConvRate) * 100 / 100).toFixed(2);
            $("[id$=lblCCChargesValue1]").html("(" + symbol + ConvTotalBAmount + ")");
            $("[id$=lblCCTotalAmountB]").html("(" + symbol + ConvTotalBAmount + ")");

            TotalProcessAmount();
        });

    });
    function InitializeRequest(sender, args) { }
    function EndRequest(sender, args) { PageLoad(); }


    var Item;
    function PageLoad() {
        var AccCountDel = $("#ctl00_cph_main_content_CostingFormNew1_hdnAccDeleteButtonCount").val();
        var j;
        var RowId = 0;
        var gvId;
        for (j = 1; j < AccCountDel; j++) {
            RowId = parseInt(j) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;
            $("#ctl00_cph_main_content_CostingFormNew1_gdvAccessory_" + gvId + "_imgBtndelete").addClass("HideButton");
        }

        var ProCountDel = $("#ctl00_cph_main_content_CostingFormNew1_hndProDeleteButton").val();
        var k;
        var RowIdp = 0;
        var gvIdp;
        for (k = 1; k < ProCountDel; k++) {
            RowIdp = parseInt(k) + 1;
            if (RowIdp < 10)
                gvIdp = 'ctl0' + RowIdp;
            else
                gvIdp = 'ctl' + RowIdp;

            var abc = $("#ctl00_cph_main_content_CostingFormNew1_gvdProcessDetails_" + gvIdp + "_ProcessimgBtndelete").addClass("HideButton");
        }
        //====================Accessory Parts===================
        $('.costing-style-number-view').blur(function () {
            GetCostingData();
        });

        $('.do-not-allow-typing').attr("readonly", "readonly");

        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var ParentDeptId = $('#<%= ddlParentDept.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

        $("input.items", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/GetAccessoryList_newtubularAutoComp", { dataType: "xml", datakey: "string", max: 100, "width": "150px",
            extraParams:
                {
                    StyleId: $('input[type=text].costing-style-id').val(),
                    ClientId: ClientId,
                    ParentDeptId: ParentDeptId,
                    DeptId: DeptId
                }
        });

        $("input.items", '#main_content').result(function () {

            $(this).removeClass("InvalidAcc");

            if ($(this).val().includes('Supplier Details')) {
                $(this).val("");
                return;
            }
            var mys = $(this).val().split('$');
            var mys2 = mys[1].split('**');
            var AccIds = $(this)[0].id.split("_")[6];
            var AccClientId = mys2[2].trim();
            var AccParentDeptId = mys2[3].trim();
            var AccDeptId = mys2[4].trim();
            DefaultAccessory = mys2[5].trim();

            $("#<%= gdvAccessory.ClientID %> input[id*='" + AccIds + "_hdnAccClientId" + "']").val(AccClientId);
            $("#<%= gdvAccessory.ClientID %> input[id*='" + AccIds + "_hdnAccParentDeptId" + "']").val(AccParentDeptId);
            $("#<%= gdvAccessory.ClientID %> input[id*='" + AccIds + "_hdnAccDeptId" + "']").val(AccDeptId);
            $("#<%= gdvAccessory.ClientID %> input[id*='" + AccIds + "_hdnIsDefaultAccessory" + "']").val(DefaultAccessory);

            $(this).val(mys2[0].trim());
            var Id = mys2[1].trim();

            Item = $(this);

            var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();

            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/GetSize_Rate",
                data: "{search: '" + Id + "', ClientId:'" + ClientId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: function (response) { alert(response.d); }
            });

        });

        function OnSuccessCall(response) {


            var table = "<h3 style='background-color: #4061ab;color: #F8F8F8;border: 1px solid gray;padding:2px;'>Size Rate</h3>";
            table += "<table style='table-layout:fixed;'  cellpaddig='0' cellspacing='0'class='access_infotable' border='0' width='100%'>";
            if (response.d != '') {
                table += "<tr>";
                var parser = new DOMParser();
                var xmlDoc = parser.parseFromString(response.d, "text/xml");
                var xml = $(xmlDoc);
                var Size = xml.find("Size");
                var FinishRate = xml.find("FinishRate");
                var UnitName = xml.find("UnitName");
                var CPP = xml.find("ConvertToPerPcs");
                var AccessoryQualityId = xml.find("accessory_qualityID");
                for (var i = 0; i < Size.length; i++) {
                    var Sz = Size[i].innerHTML;
                    if (i == 0) {
                        table += "<th style='background-color: #d8d1d1d4 !important;color: #716f6f !important;font-size: 13px !important; width:100px;'>Size </th>";
                    }
                    table += "<th style='background-color: #d8d1d1d4 !important;color: #000 !important;'>" + Sz + "</th>";
                }
                table += "</tr><tr>";
                for (var j = 0; j < FinishRate.length; j++) {
                    var SRate = FinishRate[j].innerHTML;
                    var Sze = Size[j].innerHTML;
                    var UName = UnitName[j].innerHTML;
                    var CP = CPP[j].innerHTML;
                    var AccessId = AccessoryQualityId[j].innerHTML;
                    if (j == 0) {
                        table += "<td style='color: #716f6f !important;font-size: 13px !important;'>Rate</td>"
                    }
                    table += "<td><span>₹&nbsp;</span> <span id='lblSizeRate' style='cursor:pointer;' class='SizeRate'>" + SRate + "</span></td>"
                    table += "<td style='display:none;'><span id='lblSize' class='Size'>" + Sze + "</span></td>"
                    table += "<td style='display:none;'><span id='lblCPP' class='CPP'>" + CP + "</span></td>"
                    table += "<td style='display:none;'><span id='lblCPP' class='CPP'>" + AccessId + "</span></td>"
                }
                table += "</tr>";
            }
            else {
                table += "<tr align='center'><td><b><span id='lblDate' style='cursor:pointer;' class='NoRecord'>No Result For the Criteria</span></b></td></tr>";
            }
            table += "</table>";
            $("#dvSizeRate").html(table);
            $("#dvBaseSizeRate").css("display", "block");


            $('#<%= btnSave.ClientID %>').attr('disabled', true);
            $('#<%= btnSaveConfirm.ClientID %>').attr('disabled', true);
            $('#<%= btnSaveIkandi.ClientID %>').attr('disabled', true);
            $('#<%= btnAgree.ClientID %>').attr('disabled', true);
            $(".SizeRate").click(function () {

                var Rate = $(this).html();
                var size = $(this).parent().next().find("span").html();
                var ConvertPerPeice = $(this).parent().next().next().find("span").html();
                var AccessoryQualityId = $(this).parent().next().next().next().find("span").html();
                var ExactRate = parseFloat(Rate) / parseFloat(ConvertPerPeice);
                var td = $("td", Item.closest("tr"));
                $("[id$=txtRate]", td).val(parseFloat(ExactRate).toFixed(2));
                $("[id$=txtUnitQty]", td).val("1.00");
                $("[id$=hdnID]", td).val(AccessoryQualityId);
                var valuetxt = $(Item).val();

                var RegisterAccName = valuetxt;


                //Added by shubhendu 18/1/2022
                proxy.invoke("Get_RegisterAcc", { RegisterAccName: RegisterAccName }, function (result) {

                    if (result[0].Acc == '0') {
                        //alert("unreg");

                        var accessoryval = $(Item).val();
                        if (accessoryval != "") {
                            $(Item).css("background-color", "#bfbfbf");
                            $(Item).css("color", "#FF0000");
                        }
                    }
                    else if (result[0].Acc == '1') {
                        if (accessoryval != "") {
                            $(Item).css("background-color", "#ffffaa");
                            $(Item).css("color", "#0000FF");

                        }

                    }

                });

                valuetxt += " (" + size + ")"

                $(Item).val(valuetxt);
                CalculateAccessoriesTotal(Item);
                $("#dvSizeRate").html("");
                $("#dvBaseSizeRate").css("display", "none");
                $(Item).focus();

                $('#<%= btnSave.ClientID %>').attr('disabled', false);
                $('#<%= btnSaveConfirm.ClientID %>').attr('disabled', false);
                $('#<%= btnSaveIkandi.ClientID %>').attr('disabled', false);
                $('#<%= btnAgree.ClientID %>').attr('disabled', false);
            });
            $(".NoRecord").click(function () {

                var td = $("td", Item.closest("tr"));
                $("[id$=txtRate]", td).val("");
                $("[id$=txtUnitQty]", td).val("");
                $("[id$=hdnID]", td).val("");
                $(Item).val("");
                CalculateAccessoriesTotal(Item);
                $("#dvSizeRate").html("");
                $("#dvBaseSizeRate").css("display", "none");
            });
        }


        $('#<%=gdvAccessory.ClientID%>').find('input:hidden[id$="hdnID"]').each(function () {
            // 
            var id = $(this).val();
            var td = $("td", $(this).closest("tr"));

        });

        $(".costing-accessories-unitqty").keyup(function (e) {
            CalculateAccessoriesTotal(this);
        });

        $(".costing-accessories-rate").keyup(function (e) {
            CalculateAccessoriesTotal(this);
        });

        $(".costing-accessories-wastage").keyup(function (e) {
            CalculateAccessoriesTotal(this);
        });

        //====================Process Parts===================


        $("input.process-items", '#main_content').autocomplete1("/Webservices/iKandiService.asmx/GetProcessList", { dataType: "xml", datakey: "string", max: 100, "width": "300px" });
        $("input.process-items", '#main_content').result(function () {
            // // 
            var ProcessItem = $(this);
            var ProsName = $(this).val().trim();
            var exactval = ProsName.split(' --- ');
            var ProcessName = exactval[1].trim();
            var lastIndex = exactval[0].trim().lastIndexOf('(');
            // var x = exactval[0].split('('); 
            // $(this).val(x[0].trim());
            // Above is comented and below is updated by sanjeev  on 27/08/2021 due to "()" in process name
            var x = exactval[0].trim().substr(0, lastIndex).trim();
            $(this).val(x);
            GetProcessDataByName(ProcessName, ProcessItem, TotalProcessAmount);

        });

        $(".costing-process-amount").keyup(function (e) {
            TotalProcessAmount();
        });

        //====================End of Process Parts===================     
    }
    //==================Accessaries Part=============================
    function GetUnitQtyByClientDept(ClientId, DeptId) {
        proxy.invoke("GetCostingUnitQtyBy_Client_Dept", { ClientId: ClientId, DeptId: DeptId }, function (result) {

            $('#<%=gdvAccessory.ClientID%>').find('input:hidden[id$="hdnID"]').each(function () {
                //
                var id = $(this).val();
                if (id == 15001)
                    $(this).parent().find('[id$=txtUnitQty]').val(result[0].UnitQty);
                else if (id == 15002)
                    $(this).parent().find('[id$=txtUnitQty]').val(result[1].UnitQty);
                else if (id == 15003)
                    $(this).parent().find('[id$=txtUnitQty]').val(result[2].UnitQty);
                else if (id == 15004)
                    $(this).parent().find('[id$=txtUnitQty]').val(result[3].UnitQty);
                else if (id == 15005)
                    $(this).parent().find('[id$=txtUnitQty]').val(result[4].UnitQty);
            });
        });
    }

    function GetAccessoryQualityDataByTradeName(tradeName, suplier, Item) {

        if ($.trim(tradeName) == '' || $.trim(suplier) == '')
            return;
        proxy.invoke("GetAccessoryQualityDataByTradeName", { TradeName: tradeName, Suplier: suplier },
                     function (result) {

                         if (result == null || result == '')
                             return;

                         var td = $("td", Item.closest("tr"));

                         $("[id$=txtRate]", td).val(result.Rate);
                         $("[id$=lblWastage]", td).val(result.Wastage);
                         $("[id$=lblUnit]", td).val(result.Unit);
                         $("[id$=hdnID]", td).val(result.AccessoryID);
                         CalculateAccessoriesTotal(Item);

                     });
    }

    function CalculateAccessoriesTotal(Sender) {

        var TotalAmount = 0, Rate = 0, Quantity = 0, Wastage = 0, TotalPrice = 0, TotalQuantity = 0;
        var totalPriceB = 0, totalAmountB = 0;
        var ExpectedQuantity = document.getElementById('<%=txtExpectedQuant.ClientID%>').value;
        var ConvRate = $('#<%= hdnConvRate.ClientID %>').val();
        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

        if (Sender != null) {
            var td = $("td", Sender.closest("tr"));
            Rate = $("[id$=txtRate]", td).val();
            Wastage = $("[id$=lblWastage]", td).val();
            Quantity = $("[id$=txtUnitQty]", td).val();

            if (isNaN(Rate)) Rate = 0; if (isNaN(Quantity)) Quantity = 0; if (isNaN(Wastage)) Wastage = 0;

            TotalAmount = ((Rate * Quantity) + (Rate * Quantity * Wastage) / 100).toFixed(1);
            var decPart = (TotalAmount + "").split(".")[1];
            if (typeof (decPart) != "undefined") {


                if (decPart > 0 && decPart < 6) {

                    TotalAmount = parseFloat(TotalAmount) - parseFloat("0." + decPart) + parseFloat(0.5);

                }
                else if (decPart > 5 && decPart <= 9) {

                    TotalAmount = parseFloat(TotalAmount) - parseFloat("0." + decPart) + parseFloat(1.0);
                }
            }

            TotalPrice = ((TotalAmount * ExpectedQuantity) / 1000).toFixed(2);
            TotalQuantity = ((Quantity * ExpectedQuantity) / 1000).toFixed(2);


            $("[id$=lblTotalAmount]", td).val(TotalAmount);
            $("[id$=lblTotalPriceAcc]", td).val(TotalPrice);
            $("[id$=lblTotalQuantity]", td).val(TotalQuantity);


            var AccConvRate = ((Rate / ConvRate) * 100 / 100).toFixed(2);
            $("[id$=lblCCAccRate]", td).html("(" + symbol + AccConvRate + ")");

            var AccConvTotalAmount = ((TotalAmount / ConvRate) * 100 / 100).toFixed(2);
            $("[id$=lblCCTotalAmount]", td).html("(" + symbol + AccConvTotalAmount + ")");

        }

        else {
            $('#<%=gdvAccessory.ClientID%>').find('input:hidden[id$="hdnID"]').each(function () {
                var td1 = $("td", $(this).closest("tr"));
                Rate = $("[id$=txtRate]", td1).val();
                Wastage = $("[id$=lblWastage]", td1).val();
                Quantity = $("[id$=txtUnitQty]", td1).val();

                if (isNaN(Rate)) Rate = 0; if (isNaN(Quantity)) Quantity = 0; if (isNaN(Wastage)) Wastage = 0;
                TotalAmount = ((Rate * Quantity) + (Rate * Quantity * Wastage) / 100).toFixed(1);

                var decPart = (TotalAmount + "").split(".")[1];
                if (typeof (decPart) != "undefined") {


                    if (decPart > 0 && decPart < 6) {

                        TotalAmount = parseFloat(TotalAmount) - parseFloat("0." + decPart) + parseFloat(0.5);

                    }
                    else if (decPart > 5 && decPart <= 9) {

                        TotalAmount = parseFloat(TotalAmount) - parseFloat("0." + decPart) + parseFloat(1.0);
                    }
                }

                TotalPrice = ((TotalAmount * ExpectedQuantity) / 1000).toFixed(2);
                TotalQuantity = ((Quantity * ExpectedQuantity) / 1000).toFixed(2);

                $("[id$=lblTotalAmount]", td1).val(TotalAmount);
                $("[id$=lblTotalPriceAcc]", td1).val(TotalPrice);
                $("[id$=lblTotalQuantity]", td1).val(TotalQuantity);

                var AccConvRate = ((Rate / ConvRate) * 100 / 100).toFixed(2);
                $("[id$=lblCCAccRate]", td1).html("(" + symbol + AccConvRate + ")");

                var AccConvTotalAmount = ((TotalAmount / ConvRate) * 100 / 100).toFixed(2);
                $("[id$=lblCCTotalAmount]", td1).html("(" + symbol + AccConvTotalAmount + ")");

            });
        }
        TotalAccessoriesAmount();
    }

    function TotalAccessoriesAmount() {
        var ConvRate = $('#<%= hdnConvRate.ClientID %>').val();
        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
        var totalPriceB = 0, totalAmountB = 0; TotalAmount_New = 0;
        $('#<%=gdvAccessory.ClientID%>').find('input:hidden[id$="hdnID"]').each(function () {
            var td1 = $("td", $(this).closest("tr"));
            var lblTotalPriceAcc = $("[id$=lblTotalPriceAcc]", td1);
            var lblTotalAmount = $("[id$=lblTotalAmount]", td1);
            if (isNaN(lblTotalPriceAcc.val()) || lblTotalPriceAcc.val() == 0) {
                lblTotalPriceAcc.val(0);
            }

            if (isNaN(lblTotalAmount.val()) || lblTotalAmount.val() == 0) {
                lblTotalAmount.val("");
                TotalAmount_New = "0";
            }
            else {
                TotalAmount_New = lblTotalAmount.val();
            }



            totalPriceB = parseFloat(totalPriceB) + parseFloat(lblTotalPriceAcc.val());
            totalAmountB = parseFloat(totalAmountB) + parseFloat(TotalAmount_New);
        });
        var txtTotalPriceB = $('[id$=lblTotalPriceC]');
        txtTotalPriceB.val(totalPriceB.toFixed(2));

        var txtTotalAmountB = $('[id$=lblTotalAmountC]');
        txtTotalAmountB.val(Math.ceil(totalAmountB.toFixed(2)));
        txtTotalAmountB.change();

        if (parseFloat(totalAmountB) > 0) {
            var AccConvTotalAmount = ((totalAmountB / ConvRate) * 100 / 100).toFixed(2);
            $("[id$=lblCCTotalC]").html("(" + symbol + AccConvTotalAmount + ")");
        }
    }

    function TotalAccessoriesAmountFromServer(totalAmountB, totalPriceB) {

        var txtTotalPriceB = $('[id$=lblTotalPriceC]');
        txtTotalPriceB.val(totalPriceB.toFixed(2));

        var txtTotalAmountB = $('[id$=lblTotalAmountC]');
        txtTotalAmountB.val(totalAmountB.toFixed(2));
        txtTotalAmountB.change();

    }
    //==================End OF Accessaries =====================================
    //==================Process ================================================

    function GetProcessDataByName(ProcessName, ProcessItem, callbackFn) {

        if ($.trim(ProcessName) == '' || $.trim(ProcessName) == null)
            return;
        var Quantity = $('#<%= ddlExpectedQty.ClientID %> option:selected').val();
        if (Quantity == '')
            Quantity = 0;
        proxy.invoke("GetProcessDataByName", { Name: ProcessName, ExpectedQty: Quantity },
                             function (result) { //UnComment it If you want to use web Service instead of WCF Rest Service.

                                 //        var url = WCFServiceurl + "GetProcessDataByProcessNameWCF?Name=" + ProcessName + "&ExpectedQty=" + Quantity;
                                 //        $.get(url, function (result, status) {


                                 if (result == null || result == '')
                                     return;
                                 var txtGVW = $('[id$=txtGVW]'); var TotalGVW = 0;
                                 var td = $("td", ProcessItem.closest("tr"));

                                 $("[id$=hdnValueAdditionID]", td).val(result.ValueAdditionID);
                                 $("[id$=txtFromStatus]", td).val(result.FromStatus);
                                 $("[id$=txtToStatus]", td).val(result.ToStatus);
                                 $("[id$=hdnCostingVAWastage]", td).val(result.CostingVAWastage);

                                 $("[id$=txtRate]", td).val(result.Rate);
                                 $("[id$=txtWastage]", td).val(result.Wastage);
                                 $("[id$=lblTotalAmount]", td).val(result.Amount);
                                 callbackFn();
                             });


    }

    function TotalProcessAmount() {

        var lblTotalAmountVal = 0;
        var totalAmountD = 0;
        var ConvRate = $('#<%= hdnConvRate.ClientID %>').val();
        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

        $('#<%=gvdProcessDetails.ClientID%>').find('input:hidden[id$="hdnValueAdditionID"]').each(function () {
            var td = $("td", $(this).closest("tr"));
            var txtRateVal = 0;
            var txtWastageVal = 0;
            var lblTotalAmount = $("[id$=lblTotalAmount]", td);
            var txtWastage = $("[id$=txtWastage]", td);
            var txtRate = $("[id$=txtRate]", td);

            if (isNaN(txtWastage.val()) || txtWastage.val() == 0) txtWastageVal = 0; else txtWastageVal = txtWastage.val();

            if (isNaN(txtRate.val()) || txtRate.val() == 0) txtRateVal = 0; else txtRateVal = txtRate.val();

            // need to do sanjeev
            if (isNaN(txtRateVal) || txtRateVal == 0)
                lblTotalAmountVal = 0;
            else
                lblTotalAmountVal = ((parseFloat(txtRateVal) * 100) / (100 - parseFloat(txtWastageVal))); // lblTotalAmount.val();


            lblTotalAmount.val(Math.ceil(parseFloat(lblTotalAmountVal).toFixed(2)));

            totalAmountD = parseFloat(totalAmountD) + parseFloat(lblTotalAmount.val());


            var ProcessConvTotalAmount = ((lblTotalAmount.val() / ConvRate) * 100 / 100).toFixed(2);
            $("[id$=lblAccCCTotalAmount]", td).html("(" + symbol + ProcessConvTotalAmount + ")");

        });

        var lblTotalAmountD = $('[id$=lblTotalAmountD]');
        if (Math.ceil(totalAmountD.toFixed(2)) > 0) {
            lblTotalAmountD.val(Math.ceil(totalAmountD.toFixed(2)));
        }
        else {
            lblTotalAmountD.val("");
        }

        lblTotalAmountD.change();

        var ProcessConvTotalAmountD = ((lblTotalAmountD.val() / ConvRate) * 100 / 100).toFixed(2);
        $("[id$=lblCCTotalD]").html("(" + symbol + ProcessConvTotalAmountD + ")");

    }

    function TotalProcessAmountFromServer(TotalAmount, TotalCostingVAWastage) {
        var lblTotalAmountD = $('[id$=lblTotalAmountD]');
        var txtGVW = $('[id$=txtGVW]');
        lblTotalAmountD.val(TotalAmount.toFixed(2));
        lblTotalAmountD.change();
        txtGVW.val(TotalCostingVAWastage.toFixed(2));
    }


    function isNumberKey(evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 45 || charCode > 57)) {
            return false;
        }
        return true;
    }


    function isNumberKeyfloat(evt, val) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
            return false;
        else {
            var len = val.value.length;
            var index = val.value.indexOf('.');

            if (index >= 0 && charCode == 46) {
                return false;
            }

            if (index > 0) {
                var CharAfterdot = (len) - (index);
                if (CharAfterdot > 3) {
                    return false;
                }
            }
            if (index == 0) {
                var CharAfterdot = (len) - index;
                if (CharAfterdot > 3) {
                    return false;
                }
            }

        }

        return true;
    }


    function GetCMTValue() {

        var styleId = $('input[type=text].costing-style-id').val();
        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        var Quantity = document.getElementById('<%=ddlExpectedQty.ClientID%>').value;
        var y = $('#<%= ddlExpectedQty.ClientID %> option:selected').text();
        var x = y.split('-');

        $('#<%= hdnddlExpectedQty.ClientID %>').val($('#<%= ddlExpectedQty.ClientID %> option:selected').val());
        var SAM = document.getElementById('<%=txtChargesValue11.ClientID%>').value;
        var OB = document.getElementById('<%=txtOB.ClientID%>').value;
        var Achvement = document.getElementById('<%=hdnAch.ClientID%>').value;

        var ConvRate = $('#<%= hdnConvRate.ClientID %>').val();
        var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

        if (Quantity == '') {
            Quantity = 0;
        }
        if (SAM == '') {
            SAM = 0;
        }
        if (SAM == 'Manual') {
            SAM = 0;
        }
        if (SAM == 'NaN') {
            SAM = 0;
        }
        if (OB == '') {
            OB = 0;
        }
        if (Achvement == '') {
            Achvement = 0;
        }

        proxy.invoke("GetCMT_Value_New", { SAM: SAM, OB_WS: OB, Achivement: Achvement, ClientId: ClientId, DeptId: DeptId, StyleId: styleId, Quantity: Quantity },
                function (result) {
                    cmtvalueRollback(result[0]);
                    var OBVal = result[1];
                    var Overhead = result[3];

                    $('#ctl00_cph_main_content_CostingFormNew1_txtOverHead').val(Overhead);

                    ExpectedQtyChange = "true";


                    var LineNo = parseInt(OBVal) / parseInt(OB);
                    $('#<%= hdnOBCount.ClientID %>').val(LineNo);
                    var TotalMade = result[2];
                    var AmountB = (result[0] * 100 / 100).toFixed(2);
                    //                    $('#<%= txtChargesValue1.ClientID %>').val(Math.round(AmountB)); //commented by Girish on 2023-05-02
                    $('#<%= txtGCW.ClientID %>').val(TotalMade);
                    $('#<%= lblTotalAmountB.ClientID %>').val(Math.round(AmountB));


                    CalculateCostingTotal(0);
                    CalculateAccessoriesTotal(null);


                    var ConvChargesValue1 = ((AmountB / ConvRate) * 100 / 100).toFixed(2);
                    $("[id$=lblCCChargesValue1]").html("(" + symbol + ConvChargesValue1 + ")");
                    $("[id$=lblCCTotalAmountB]").html("(" + symbol + ConvChargesValue1 + ")");

                    ChangeValueAdditionOnRange();

                },
        onPageError, false, false);



    }
    //============================End of CMT===================================================
    //===============================Financial Part============================================

    $(document).ready(function () {
        CurrencyConverter();
    });

    function CurrencyChange() {
        var txtConvRate = $('#<%= txtConvRate.ClientID %>');
        var txtInitCtcInInr = parseInt(currChange[1].value);
        var ddlCurrency = currChange[0];
        var ddlCurr = parseInt(currChange[0].value);
        var priceQuoted = currChange[2];
        var priceAgreed = currChange[3];
        var txtTotal = $('#<%= txtTotal.ClientID %>');
        $('#<%= hdnConvertTo.ClientID %>').val(ddlCurr);

        var gp_from = 'USD';
        var gp_to = 'INR';
        var gp_amount = 1.0;
        if (ddlCurr == 1) gp_from = 'USD'; else if (ddlCurr == 2) gp_from = 'GBP'; else if (ddlCurr == 3) gp_from = 'INR';
        else if (ddlCurr == 4) gp_from = 'EUR'; else if (ddlCurr == 5) gp_from = 'SEK'; else if (ddlCurr == 6) gp_from = 'AUD';

        var StyleNumber = $('#ctl00_cph_main_content_CostingFormNew1_txtIkandiStyle').val();

        proxy.invoke("GetCurrencyConversion", { currencyID: ddlCurr, StyleNumber: StyleNumber },
            function (result) {

                // below code is uncomented by sanjeev on 31/08/2021 due to issue in conversion of amount acording currency rate
                txtConvRate.val(result);
                var CurrentConversionRate = txtConvRate.val();
                $('#<%= hdnConvRate.ClientID %>').val(result);
                $('#<%= hdnConvernew.ClientID %>').val(result);
                $('#<%= hdnCostingConversionRate.ClientID %>').val(result);

                var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();

                var objCell = txtTotal.closest("td");
                AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);

                txtConvRate.change();
            },
                       onPageError, false, false);

    }

    function CurrencyConvetor(amount, from, to) {

        var txtConvRate = $('#<%= txtConvRate.ClientID %>');
        var txtTotal = $('#<%= txtTotal.ClientID %>');
        var result = '';
        var ConvertedVal = '';
        var url = "https://www.google.com/finance/converter?a=" + amount + "&from=" + from + "&to=" + to;
        $.ajaxSetup({ async: false });
        $.get(url,
        function (data) {
            var startPos = data.search('<div id=currency_converter_result>');
            var endPos = data.search('<input type=submit value="Convert">');
            //
            if (startPos > 0) {
                result = data.substring(startPos, endPos);
                result = result.replace('<div id=currency_converter_result>', '');
                result = result.replace('<span class=bld>', '');
                result = result.replace('</span>', '');

                if (result.toString().includes('not')) {
                    ConvertedVal = 1.0;

                    // below code is uncomented by sanjeev on 31/08/2021 due to issue in conversion of amount acording currency rate
                    txtConvRate.val(ConvertedVal.toFixed(2));
                    $('#<%= hdnConvRate.ClientID %>').val(ConvertedVal.toFixed(2));
                    $('#<%= hdnConvernew.ClientID %>').val(ConvertedVal.toFixed(2));
                    txtConvRate.change();
                    var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                    var objCell = txtTotal.closest("td");
                    AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
                }
                else {
                    result = result.split(" ");
                    ConvertedVal = parseFloat(result[3]).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];

                    // below code is uncomented by sanjeev on 31/08/2021 due to issue in conversion of amount acording currency rate
                    txtConvRate.val(ConvertedVal);
                    $('#<%= hdnConvRate.ClientID %>').val(ConvertedVal);
                    $('#<%= hdnConvernew.ClientID %>').val(ConvertedVal);
                    txtConvRate.change();
                    var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                    var objCell = txtTotal.closest("td");
                    AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
                }



            }
        })
    }

    function GetNewConversion() {
        //
        var txtConvRate = $('#<%= txtConvRate.ClientID %>');
        var txtTotal = $('#<%= txtTotal.ClientID %>');
        var convertto = $('#<%= hdnConvertTo.ClientID %>').val();

        proxy.invoke("GetCurrencyConversion_New", { currencyID: convertto },
            function (result) {
                // below code is uncomented by sanjeev on 31/08/2021 due to issue in conversion of amount acording currency rate
                txtConvRate.val(result);
                $('#<%= hdnConvRate.ClientID %>').val(result);
                txtConvRate.change();
                var symbol = $('#<%= ddlConvTo.ClientID %> option:selected').text();
                var objCell = txtTotal.closest("td");
                AddRemoveSymbol(objCell, txtTotal.val(), symbol, true, true);
            },
    onPageError, false, false);
    }

    function cmtvalueRollback(CMT) {

        var ClientId = $('#<%= ddlBuyer.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();

        //        $('#<%= txtChargesValue1.ClientID %>').val(CMT); //Commented by Girish on 2023-05-02    
        CalculateChargesTotal();
        CalculateCostingTotal(0);

        proxy.invoke("GetClientCostingBy_New", { ClientId: ClientId, DeptId: DeptId, StyleNumber: "", ExpectedQty: "-1" },
                                                            function (result) {
                                                               
                                                                $('#<%= hdnMinCMT.ClientID %>').val(result[0].MinCMT);
                                                                if (result[0].MinCMT > CMT) {
                                                                    $('#<%= txtChargesValue1.ClientID %>').val(result[0].MinCMT); //added by Girish on 2023-05-02          
                                                                    $('#<%= txtChargesValue1.ClientID %>').attr('defaultValue', result[0].MinCMT);    //added by Girish on 2023-05-02                                                           
                                                                    CalculateChargesTotal();
                                                                    CalculateCostingTotal(0);
                                                                }
                                                                else {
                                                                    $('#<%= txtChargesValue1.ClientID %>').val(CMT); //added by Girish on 2023-05-02
                                                                    $('#<%= txtChargesValue1.ClientID %>').attr('defaultValue', CMT); //added by Girish on 2023-05-02                                                               
                                                                    CalculateChargesTotal();
                                                                    CalculateCostingTotal(0);
                                                                }

                                                            },
                                             onPageError, false, false);

    }

    function CurrencyConverter() {
        var txtConvRate = $('#<%= txtConvRate.ClientID %>');
        var ddlCurr = parseInt(currChange[0].value);
        var gp_from = 'USD';
        var gp_to = 'INR';
        var gp_amount = 1.0;
        if (ddlCurr == 1) gp_from = 'USD'; else if (ddlCurr == 2) gp_from = 'GBP'; else if (ddlCurr == 3) gp_from = 'INR';
        else if (ddlCurr == 4) gp_from = 'EUR'; else if (ddlCurr == 5) gp_from = 'SEK'; else if (ddlCurr == 6) gp_from = 'AUD';


        $.getJSON("http://www.geoplugin.net/currency_converter.gp?jsoncallback=?", { from: gp_from, to: gp_to, amount: gp_amount },
	      	 function (result) {
	      	     if (txtConvRate.val() == '')
	      	         txtConvRate.val(result.to.amount);
	      	     $('#<%= hdnConvRate.ClientID %>').val(result.to.amount);
	      	 });

    }

    function showStylePhotoWithOutScroll_Costing(styleID, orderID, orderDetailID) {
        proxy.invoke("GetStylePhotosView_New", { StyleID: styleID, OrderID: orderID, OrderDetailID: orderDetailID }, function (result) {
            jQuery.facebox(result);
        }, onPageError, false, false);
    }

    function CalculateChargesTotal() {

        var total = 0;
        var txtChargesValue = $('#<%= txtChargesValue1.ClientID %>');
        for (var i = 0; i < txtChargesValue.length; i++) {
            if (isNaN(txtChargesValue[i].value))
                txtChargesValue[i].value = 0;
            total = total + +txtChargesValue[i].value;
        }

        var txtTotalB = $('#<%= lblTotalAmountB.ClientID %>');
        txtTotalB.val(total);
        txtTotalB.change();
    }

    function SetDecimalPlacesForDecimalFields(sender, decimalPlaces) {
        var value = 0;
        if (sender == undefined) {
            $('input[type=text].numeric-field-with-two-decimal-places').each(function () {
                if ($(this).val() != '') {
                    value = +$(this).val();
                    $(this).val((Math.round(value * 1000) / 1000).toFixed(2));
                }
            });

            $('input[type=text].numeric-field-with-three-decimal-places').each(function () {
                if ($(this).val() != '') {
                    value = +$(this).val();
                    //  // 
                    var str1 = "";
                    var lastDigit = "";

                    lastDigit = value.toString().split(".")[1];
                    if (lastDigit != undefined) {
                        var Vallength = lastDigit.length;
                        if (Vallength == 3) {
                            $(this).val((Math.round(value * 1000) / 1000).toFixed(3));
                        }
                        else {
                            $(this).val((Math.round(value * 1000) / 1000).toFixed(2));
                        }
                    }
                    else {
                        $(this).val((Math.round(value * 1000) / 1000).toFixed(2));
                    }
                }
            });
            $('input[type=text].numeric-field-with-one-decimal-places').each(function () {
                if ($(this).val() != '') {
                    value = +$(this).val();
                    $(this).val((Math.round(value * 1000) / 1000).toFixed(1));
                }
            });

        }
        else {
            if (sender.val() != '') {
                value = +sender.val();
                sender.val(value.toFixed(decimalPlaces));

                $('input[type=text].costing-landed-costing-penny').closest('td').find('span.penny').text($('#ctl00_cph_main_content_CostingFormNew1_ddlConvTo option:selected').text());
            }
        }
    }

    var i = 0;


    function IsPriceQuoteBlank() {
        if (parseFloat($('#ctl00_cph_main_content_CostingFormNew1_hdnIsPricequoted').val()) > 0 && ($('#ctl00_cph_main_content_CostingFormNew1_txtPriceQuoted').val() == "" || $('#ctl00_cph_main_content_CostingFormNew1_txtPriceQuoted').val() == "0.00")) {
            alert("Price Quote Need To have Some Value Before Saving.Previosuly It Was : " + parseFloat($('#ctl00_cph_main_content_CostingFormNew1_hdnIsPricequoted').val()).toFixed(2) + "");
            return false;
        }
    }
    function SAM() {

        if (parseFloat($('#ctl00_cph_main_content_CostingFormNew1_hdnIsPricequoted').val()) > 0 && ($('#ctl00_cph_main_content_CostingFormNew1_txtPriceQuoted').val() == "" || $('#ctl00_cph_main_content_CostingFormNew1_txtPriceQuoted').val() == "0.00")) {
            alert("Price Quote Need To have Some Value Before Saving.Previosuly It Was : " + parseFloat($('#ctl00_cph_main_content_CostingFormNew1_hdnIsPricequoted').val()).toFixed(2) + "");
            return false;
        }
        $("input[readonly='readonly'].ac_input").removeAttr('disabled');

        $('#<%= btnSave.ClientID %>').hide();
        var txtSam = $('#<%= txtChargesValue11.ClientID %>').val();
        var txtOB = $('#<%= txtOB.ClientID %>').val();
        var ParentDeptId = $('#<%= ddlParentDept.ClientID %> option:selected').val();
        var DeptId = $('#<%= ddlDept.ClientID %> option:selected').val();
        var ConvRate = $('#<%= txtConvRate.ClientID %>').val();
        var hdnConvRate = $('#<%= hdnConvRate.ClientID %>');
        var txtPriceQuoted = $('#<%= txtPriceQuoted.ClientID %>').val();
        var ddlCurr = parseInt(currChange[0].value);


        var fromVariance = $('#<%= hdnfromvari.ClientID %>').val();
        var toVariance = $('#<%= hdntovari.ClientID %>').val();

        var IsPriceQouted = $('#<%= hdnIsPricequoted.ClientID %>').val();

        var hdnConvRate1 = $('#<%= hdnConvernew.ClientID %>').val();
        var MinValue = ((parseFloat(hdnConvRate1) - fromVariance) * 100 / 100).toFixed(2);
        var MaxValue = ((parseFloat(hdnConvRate1) - toVariance) * 100 / 100).toFixed(2);

        if (ParentDeptId == -1) {
            ShowHideValidationBox(true, 'Please Select Parent Department.', 'Costing Sheet');
            $('select.costing-Parentdepartment').focus();
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }

        if (DeptId == -1) {
            ShowHideValidationBox(true, 'Please Select Department.', 'Costing Sheet');
            $('select.costing-department').focus();
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }
        //Fabric Section==============

        if ($(".lay_file1").css('display') == 'block') {
            if ($(".lay_file1").val() == "") {
                if ($(".view_lay1").css('display') == 'none') {
                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric1]").val().trim() + ' ' + document.getElementById('<%=COUNTCON.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth1]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth1]").val()) == "0") {

                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric1]").val().trim() + ' ' + document.getElementById('<%=COUNTCON.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage1]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage1]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric1]").val().trim() + ' ' + document.getElementById('<%=COUNTCON.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate1]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate1]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric1]").val().trim() + ' ' + document.getElementById('<%=COUNTCON.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric1]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric1]").val().trim() + ' ' + document.getElementById('<%=COUNTCON.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType1]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for ' + $(".tr-fab").find("[id$=txtFabric1]").val().trim() + ' ' + document.getElementById('<%=COUNTCON.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric1]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

        }
        if ($(".lay_file2").css('display') == 'block') {
            if ($(".lay_file2").val() == "") {
                if ($(".view_lay2").css('display') == 'none') {

                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric2]").val().trim() + ' ' + document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth2]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth2]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric2]").val().trim() + ' ' + document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage2]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage2]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric2]").val().trim() + ' ' + document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate2]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate2]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric2]").val().trim() + ' ' + document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric2]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric2]").val().trim() + ' ' + document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType2]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for ' + $(".tr-fab").find("[id$=txtFabric2]").val().trim() + ' ' + document.getElementById('<%=COUNTCON2.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

            if ($(".tr-fab").find("[id$=txtFabric2]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        }
        if ($(".lay_file3").css('display') == 'block') {
            if ($(".lay_file3").val() == "") {
                if ($(".view_lay3").css('display') == 'none') {

                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric3]").val().trim() + ' ' + document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth3]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth3]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric3]").val().trim() + ' ' + document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage3]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage3]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric3]").val().trim() + ' ' + document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate3]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate3]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric3]").val().trim() + ' ' + document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric3]").val().trim() == "") {
                //alert('TEST')
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric3]").val().trim() + ' ' + document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType3]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for ' + $(".tr-fab").find("[id$=txtFabric3]").val().trim() + ' ' + document.getElementById('<%=COUNTCON3.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

            if ($(".tr-fab").find("[id$=txtFabric3]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        }
        if ($(".lay_file4").css('display') == 'block') {
            if ($(".lay_file4").val() == "") {
                if ($(".view_lay4").css('display') == 'none') {

                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric4]").val().trim() + ' ' + document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth4]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth4]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric4]").val().trim() + ' ' + document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage4]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage4]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric4]").val().trim() + ' ' + document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate4]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate4]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric4]").val().trim() + ' ' + document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric4]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric4]").val().trim() + ' ' + document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType4]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for ' + $(".tr-fab").find("[id$=txtFabric4]").val().trim() + ' ' + document.getElementById('<%=COUNTCON4.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

            if ($(".tr-fab").find("[id$=txtFabric4]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        }
        if ($(".lay_file5").css('display') == 'block') {
            if ($(".lay_file5").val() == "") {
                if ($(".view_lay5").css('display') == 'none') {

                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric5]").val().trim() + ' ' + document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth5]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth5]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric5]").val().trim() + ' ' + document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage5]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage5]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric5]").val().trim() + ' ' + document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate5]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate5]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric5]").val().trim() + ' ' + document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric5]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric5]").val().trim() + ' ' + document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType5]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for ' + $(".tr-fab").find("[id$=txtFabric5]").val().trim() + ' ' + document.getElementById('<%=COUNTCON5.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

            if ($(".tr-fab").find("[id$=txtFabric5]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        }
        if ($(".lay_file6").css('display') == 'block') {
            if ($(".lay_file6").val() == "") {
                if ($(".view_lay6").css('display') == 'none') {
                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric6]").val().trim() + ' ' + document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth6]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth6]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric6]").val().trim() + ' ' + document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage6]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage6]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric6]").val().trim() + ' ' + document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate6]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate6]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric6]").val().trim() + ' ' + document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric6]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric6]").val().trim() + ' ' + document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType6]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for' + $(".tr-fab").find("[id$=txtFabric6]").val().trim() + ' ' + document.getElementById('<%=COUNTCON6.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

            if ($(".tr-fab").find("[id$=txtFabric6]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        }
        if ($(".lay_file7").css('display') == 'block') {
            if ($(".lay_file7").val() == "") {
                if ($(".view_lay7").css('display') == 'none') {
                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric7]").val().trim() + ' ' + document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth7]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth7]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric7]").val().trim() + ' ' + document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage7]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage7]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric7]").val().trim() + ' ' + document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate7]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate7]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric7]").val().trim() + ' ' + document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric7]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric7]").val().trim() + ' ' + document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType7]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for ' + $(".tr-fab").find("[id$=txtFabric7]").val().trim() + ' ' + document.getElementById('<%=COUNTCON7.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

            if ($(".tr-fab").find("[id$=txtFabric7]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        }
        if ($(".lay_file8").css('display') == 'block') {
            if ($(".lay_file8").val() == "") {
                if ($(".view_lay8").css('display') == 'none') {
                    ShowHideValidationBox(true, 'Please upload a file for ' + $(".tr-fab").find("[id$=txtFabric8]").val().trim() + ' ' + document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                    $('#<%= btnSave.ClientID %>').show();
                    return false;
                }
            }
            if ($(".tr-fab").find("[id$=txtWidth8]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtWidth8]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill width for ' + $(".tr-fab").find("[id$=txtFabric8]").val().trim() + ' ' + document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtAverage8]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtAverage8]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Average for ' + $(".tr-fab").find("[id$=txtFabric8]").val().trim() + ' ' + document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtRate8]").val() == "" || parseFloat($(".tr-fab").find("[id$=txtRate8]").val()) == "0") {
                ShowHideValidationBox(true, 'Please fill Rate for ' + $(".tr-fab").find("[id$=txtFabric8]").val().trim() + ' ' + document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabric8]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill fabric for ' + $(".tr-fab").find("[id$=txtFabric8]").val().trim() + ' ' + document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            if ($(".tr-fab").find("[id$=txtFabricType8]").val().trim() == "") {
                ShowHideValidationBox(true, 'Please fill print/solid for ' + $(".tr-fab").find("[id$=txtFabric8]").val().trim() + ' ' + document.getElementById('<%=COUNTCON8.ClientID%>').innerHTML.replace("&nbsp;", ""), 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }

            if ($(".tr-fab").find("[id$=txtFabric8]").val().trim() == "TBD") {
                ShowHideValidationBox(true, 'Please fill registered fabric instead of TBD.', 'Costing Sheet');
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        }

        //Accessory Section==============
        var breakOut = false;
        var tbd = false;
        $('#<%=gdvAccessory.ClientID%>').find('input:text[id$="txtItems"]').each(function () {
            var id = $(this).val();
            if (id == 0 || id == '') {
                breakOut = true;
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        });
        $('#<%=gdvAccessory.ClientID%>').find('input:text[id$="txtItems"]').each(function () {
            var id = $(this).val();
            if (id == 'TBD(2)') {
                tbd = true;
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
        });
        if (breakOut) {
            ShowHideValidationBox(true, 'Please enter the accessory in accessories item.', 'Costing Sheet');
            breakOut = false;
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }
        if (tbd) {
            ShowHideValidationBox(true, 'Please fill registered accessories instead of TBD.', 'Costing Sheet');
            tbd = false;
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }


        //Process Section==============
        var breakOut2 = false;
        var breakOut21 = false;
        $('#<%=gvdProcessDetails.ClientID%>').find('input:text[id$="txtPItems"]').each(function () {
            var id = $(this).val();
            if (id == 0 || id == '') {
                breakOut2 = true;
                $('#<%= btnSave.ClientID %>').show();
                return false;
            }
            else {
                var clieintid = $(this)[0].id;
                var valueId = clieintid.split('txtPItems');
                var value = document.getElementById(valueId[0] + "lblTotalAmount").value;
                if (value == 0 || value == '') {
                    breakOut21 = true;
                }
            }
        });
        if (breakOut21) {
            ShowHideValidationBox(true, 'Please enter the Rate in Process item.', 'Costing Sheet');
            breakOut21 = false;
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }
        if (breakOut2) {
            ShowHideValidationBox(true, 'Please enter the Process in Process item.', 'Costing Sheet');
            breakOut2 = false;
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }

        //SAM Section==============
        if (txtSam == '') {
            ShowHideValidationBox(true, 'SAM should not be blank.', 'Costing Sheet');
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }
        if (txtOB == '') {
            ShowHideValidationBox(true, 'OB should not be blank.', 'Costing Sheet');
            $('#<%= btnSave.ClientID %>').show();
            return false;
        }
        var RowId = 0;
        var gvId;
        var GridRow = $(".gvRow").length;
        for (var row = 1; row <= GridRow - 1; row++) {
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;

            var itemval = $("#<%= gdvAccessory.ClientID %> input[id*='" + gvId + "_txtItems" + "']").val();
        }

    }


    function ShowHideLandedCosting() {

    }

    function showHistory(prmThis, divID) {
        var collection = getQueryString();
        var costingId = collection['cid'];
        if (divID == "divBIPLHistory") {
            proxy.invoke("ShowBiplHistoryPopup", { CostingId: costingId, type: 1 }, function (result) {
                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulbiplhistoryfabric").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulbiplhistoryfabric").append(reslt);

                });

            }, onPageError, false, false);
            proxy.invoke("ShowBiplHistoryPopup", { CostingId: costingId, type: 2 }, function (result) {
                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".UlbiplhistoryCMT").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".UlbiplhistoryCMT").append(reslt);

                });

            }, onPageError, false, false);
            proxy.invoke("ShowBiplHistoryPopup", { CostingId: costingId, type: 3 }, function (result) {
                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulbiplhistoryaccessory").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulbiplhistoryaccessory").append(reslt);

                });

            }, onPageError, false, false);
            proxy.invoke("ShowBiplHistoryPopup", { CostingId: costingId, type: 4 }, function (result) {
                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulbiplhistoryprocess").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulbiplhistoryprocess").append(reslt);

                });

            }, onPageError, false, false);
            proxy.invoke("ShowBiplHistoryPopup", { CostingId: costingId, type: 5 }, function (result) {
                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulbiplhistoryfinancial").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulbiplhistoryfinancial").append(reslt);

                });

            }, onPageError, false, false);
            proxy.invoke("ShowBiplHistoryPopup", { CostingId: costingId, type: 1119 }, function (result) {
                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulbiplhistoryother").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulbiplhistoryother").append(reslt);

                });

            }, onPageError, false, false);

            jQuery.facebox($("#divBIPLHistory").html());
        }
        if (divID == "diviKandiHistory") {
            proxy.invoke("ShowIkandiHistoryPopup", { CostingId: costingId, type: 6 }, function (result) {

                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulikandihistorylanded").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulikandihistorylanded").append(reslt);

                });
            }, onPageError, false, false);
            proxy.invoke("ShowIkandiHistoryPopup", { CostingId: costingId, type: 7 }, function (result) {

                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulikandihistorydirect").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulikandihistorydirect").append(reslt);

                });
            }, onPageError, false, false);
            proxy.invoke("ShowIkandiHistoryPopup", { CostingId: costingId, type: 1118 }, function (result) {

                parser = new DOMParser();
                var xmlDoc = parser.parseFromString(result, "text/xml");
                var xml = $(xmlDoc);
                var HistoryDetails = xml.find("Table");
                $(".Ulikandihistoryother").html("");
                HistoryDetails.each(function () {
                    var details = $(this);
                    var value = details.find("DetailDescription").text();
                    var reslt = "<li>" + value + "</li>";
                    $(".Ulikandihistoryother").append(reslt);

                });
            }, onPageError, false, false);

            jQuery.facebox($("#diviKandiHistory").html());
        }

    }


    function closeCostConfirmationPopup() {
        $("#divCostConfirmation").hide();

    }

    function openCostConfirmationPopup() {
        $("#divCostConfirmation").show();
        return false;
    }
    function showAllOrdersOnStyle() {

        var StyleNumber = '<%= txtIkandiStyle.Text %>';
        proxy.invoke("GetAllOrdersOnStyle", { StyleNumber: StyleNumber, OrderIDList: '', AllOrders: true },

    function (result) {
        result = '<div class="divReportAllOrdersPopup">' + result + "</div>";
        jQuery.facebox(result);
    },
    onPageError, false, false);
    }


    function DeleteStyleAndCostingSheet() {

        if (confirm("Are you sure to delete the current Style variation?")) {
            var styleId = $('input[type=text].costing-style-id').val();
            var collection = getQueryString();
            var costingId = collection['cid'];

            if (styleId != undefined && styleId != null && styleId != '' && styleId > 0 && costingId != undefined && costingId != null && costingId != '') {
                proxy.invoke('DeleteStyleAndCostingSheet', { styleId: styleId, costingId: costingId },
                function (success) {
                    if (success) {
                        ShowHideMessageBox(true, 'Style variation deleted successfully.', 'Costing Sheet - Delete Style Variation', RefreshParentPage);
                    }
                    else {
                        ShowHideValidationBox(true, 'Some error occured in deleting Style Variation.', 'Costing Sheet - Delete Style Variation');
                    }
                });
            }
        }
        else {
            return false;
        }
    }

    function RefreshParentPage() {
        window.parent.window.location = window.parent.window.location.href;
    }

    function RemovePrintRow(previousPrintNumber) {
        var printNew = previousPrintNumber.replace(" ", "");
        var txtPrintId = $('.prd-' + printNew + ' input.costing-print');
        if (txtPrintId.length == 1) {
            $('.prd-' + printNew).remove();
        }
    }

    function EnableAgree() {
        $('#<%= btnAgree.ClientID %>').attr('disabled', false);
    }

    function showBIPLOrderPrice(StyleId) {
        proxy.invoke("GetBIPLOrderPriceDetails", { StyleId: StyleId },
                        function (result) {
                            result = '<div class="divReportAllOrdersPopup">' + result + "</div>";
                            jQuery.facebox(result);
                        },
                        onPageError, false, false);
    }
    function showIkandiBIPLOrderPrice(StyleId) {
        proxy.invoke("GetIkandiOrderPriceDetails", { StyleId: StyleId },
                function (result) {
                    result = '<div class="divReportAllOrdersPopup">' + result + "</div>";
                    jQuery.facebox(result);
                },
                onPageError, false, false);
    }

    function ClientCurrency() {

        var Symbol = 'Rs';
        var convertto = $('#<%= hdnConvertTo.ClientID %>').val();
        var ConvRate = $('#<%= hdnConvRate.ClientID %>').val();
        if (convertto == 1) Symbol = '$'; else if (convertto == 2) Symbol = '£'; else if (convertto == 3) Symbol = 'Rs';
        else if (convertto == 4) Symbol = '€'; else if (convertto == 5) Symbol = 'se'; else if (convertto == 6) Symbol = 'A$';
        var Fabrate1 = $('#<%=txtRate1.ClientID %>').val(); var Fabrate2 = $('#<%=txtRate2.ClientID %>').val(); var Fabrate3 = $('#<%=txtRate3.ClientID %>').val(); var Fabrate4 = $('#<%=txtRate4.ClientID %>').val(); var Fabrate5 = $('#<%=txtRate5.ClientID %>').val(); var Fabrate6 = $('#<%=txtRate6.ClientID %>').val(); var Fabrate7 = $('#<%=txtRate7.ClientID %>').val(); var Fabrate8 = $('#<%=txtRate8.ClientID %>').val();
        if (isNaN(Fabrate1)) Fabrate1 = 0; if (isNaN(Fabrate2)) Fabrate2 = 0; if (isNaN(Fabrate3)) Fabrate3 = 0; if (isNaN(Fabrate4)) Fabrate4 = 0; if (isNaN(Fabrate5)) Fabrate5 = 0; if (isNaN(Fabrate6)) Fabrate6 = 0; if (isNaN(Fabrate7)) Fabrate7 = 0; if (isNaN(Fabrate8)) Fabrate8 = 0;

        var FabTotal1 = $('#<%=txtTotal1.ClientID %>').val(); var FabTotal2 = $('#<%=txtTotal2.ClientID %>').val(); var FabTotal3 = $('#<%=txtTotal3.ClientID %>').val(); var FabTotal4 = $('#<%=txtTotal4.ClientID %>').val(); var FabTotal5 = $('#<%=txtTotal5.ClientID %>').val(); var FabTotal6 = $('#<%=txtTotal6.ClientID %>').val(); var FabTotal7 = $('#<%=txtTotal7.ClientID %>').val(); var FabTotal8 = $('#<%=txtTotal8.ClientID %>').val();
        if (isNaN(FabTotal1)) FabTotal1 = 0; if (isNaN(FabTotal2)) FabTotal2 = 0; if (isNaN(FabTotal3)) FabTotal3 = 0; if (isNaN(FabTotal4)) FabTotal4 = 0; if (isNaN(FabTotal5)) FabTotal5 = 0; if (isNaN(FabTotal6)) FabTotal6 = 0; if (isNaN(FabTotal7)) FabTotal7 = 0; if (isNaN(FabTotal8)) FabTotal8 = 0;

        var FabConvRate1 = ((Fabrate1 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate1.ClientID %>').html("(" + Symbol + FabConvRate1 + ")");

        var FabConvRate2 = ((Fabrate2 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate2.ClientID %>').html("(" + Symbol + FabConvRate2 + ")");

        var FabConvRate3 = ((Fabrate3 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate3.ClientID %>').html("(" + Symbol + FabConvRate3 + ")");

        var FabConvRate4 = ((Fabrate4 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate4.ClientID %>').html("(" + Symbol + FabConvRate4 + ")");

        var FabConvRate5 = ((Fabrate5 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate5.ClientID %>').html("(" + Symbol + FabConvRate5 + ")");

        var FabConvRate6 = ((Fabrate6 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate6.ClientID %>').html("(" + Symbol + FabConvRate6 + ")");

        var FabConvRate7 = ((Fabrate7 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate7.ClientID %>').html("(" + Symbol + FabConvRate7 + ")");

        var FabConvRate8 = ((Fabrate8 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricRate8.ClientID %>').html("(" + Symbol + FabConvRate8 + ")");

        var FabConvTotal1 = ((FabTotal1 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricTotal1.ClientID %>').html("(" + Symbol + FabConvTotal1 + ")");

        var FabConvTotal2 = ((FabTotal2 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricTotal2.ClientID %>').html("(" + Symbol + FabConvTotal2 + ")");

        var FabConvTotal3 = ((FabTotal3 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%= lblCCFabricTotal3.ClientID %>').html("(" + Symbol + FabConvTotal3 + ")");

        var FabConvTotal4 = ((FabTotal4 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%=lblCCFabricTotal4.ClientID %>').html("(" + Symbol + FabConvTotal4 + ")");

        var FabConvTotal5 = ((FabTotal5 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%=lblCCFabricTotal5.ClientID %>').html("(" + Symbol + FabConvTotal5 + ")");

        var FabConvTotal6 = ((FabTotal6 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%=lblCCFabricTotal6.ClientID %>').html("(" + Symbol + FabConvTotal6 + ")");

        var FabConvTotal7 = ((FabTotal7 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%=lblCCFabricTotal7.ClientID %>').html("(" + Symbol + FabConvTotal7 + ")");

        var FabConvTotal8 = ((FabTotal8 / ConvRate) * 100 / 100).toFixed(2);
        $('#<%=lblCCFabricTotal8.ClientID %>').html("(" + Symbol + FabConvTotal8 + ")");

        var TotalB = $("[id$=txtChargesValue1]").val();
        var TotalBAmount = (TotalB * 100 / 100).toFixed(2)

        var ConvTotalBAmount = ((TotalBAmount / ConvRate) * 100 / 100).toFixed(2);
        $("[id$=lblCCChargesValue1]").html("(" + Symbol + ConvTotalBAmount + ")");
        $("[id$=lblCCTotalAmountB]").html("(" + Symbol + ConvTotalBAmount + ")");
    }
    $(function () {
        ClientCurrency();
        var tt = $('.shoamt').is(':checked');
        if ($('.shoamt').is(':checked'))
            $('.ShowHideCC').attr("style", "display: ");
        else
            $('.ShowHideCC').attr("style", "display:none");

        $(".shoamt input[type=checkbox]").change(function () {
            if ($(this).is(':checked'))
                $('.ShowHideCC').attr("style", "display: ");
            else
                $('.ShowHideCC').attr("style", "display:none");
        });


    })


    $(function () {
        //Maps your button click event to the File Upload click event
        $("#upfile1").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile1").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile2").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile3").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile4").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile5").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile6").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile7").click(function () {
            $(this).siblings("input").trigger('click');
        });
        $("#LayFile8").click(function () {
            $(this).siblings("input").trigger('click');
        });
    });

    function checkMinCmt(evt) {
        var defaultCMT = parseFloat($('#<%= hdnMinCMT.ClientID %>').val());
        var val = parseFloat(evt.value);
        if (val < defaultCMT || Number.isNaN(val)) {
            ShowHideValidationBox(true, "CMT value should not be less than default value. " + defaultCMT);
            evt.value = evt.defaultValue;
            $("[id$=lblTotalAmountB]").val(Math.round(evt.value));
            evt.focus();
            return false;
        }
        else {
            return true;
        }
    }

    function chechZero(evt) {
        var val = parseFloat(evt.value);
        if (val == 0) {
            ShowHideValidationBox(true, "Zero is not valid.");
            evt.value = "";
            evt.focus();
            return false;
        }
        else if (isNaN($('#' + evt.id).val())) {
            ShowHideValidationBox(true, "Entered digit is not valid.");
            evt.value = "";
            evt.focus();
            return false;
        }
        else {

            var previousval = evt.defaultValue;
            var UserID = parseInt($("#" + hdnuseridClientID).val());

            if (UserID == "5") {
                if (previousval != val) {
                    SaveIkandiHide();
                }
            }

            return true;
        }
    }

    function closedivConfirmBox() {
        $(".modal2").removeAttr('style');
    }

    function pageLoad() {
        var RowId = 0;
        var gvId;
        var GridRow = $(".gvRow").length;
        AssRemark = "";
        var fablength = $('#tbodyFab .tr-fab:visible').length; //add by shubhendu 8-11-21
        var txtStyleNumber = $('.costing-style-number-view');
        proxy.invoke("GetIsCheckOrderConfirmed", { StyleNumber: txtStyleNumber.val() }, function (result) {
            var IsFabricDel = result[0].IsOrderConfirmed;
            var IsPlushide = result[0].IsCutting;

            if (IsFabricDel != 0) {
                $('.FabricDeleteButton').find('a').addClass('FabricDeleteButtonHide');
                $('.FabricDeleteButtonHide').hide();
                $('.AccessoryDeleteButton').find('input[type="image"]').addClass('AccessoryDeleteButtonHide');
                $('.AccessoryDeleteButtonHide').hide();
            }
            if (IsPlushide != 0) {
                $('#AddFebricbutton').find('img').addClass('FabricPlusButtonHide');
                $('.FabricPlusButtonHide').hide();
                $('#AssoriesPlus').find('input[type="image"]').addClass('AccessoryPlusButtonHide');
                $('.AccessoryPlusButtonHide').hide();
            }
            else if (fablength >= 6) {// add by shubhendu 8-11-21 to hide plus button changed 10-12-2021

                $('#AddFebricbutton').find('img').addClass('FabricPlusButtonHide');
                $('.FabricPlusButtonHide').hide();


            }

        });

        //Price Quoted selected option
        $('select.IsChangeQuo').change(function () {

            $('.IsChangeQuo').addClass('IsChangeValue');
        });
        //end

    }
    function OpenUnRagiFabFun() {
        var sURL = '../../Internal/Fabric/UnRagisterFabricQuality.aspx';
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 620, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;
    }
    function OpenUnRagiAccessFun() {
        var sURL = '../../Internal/Accessory/UnRagisterAccessories.aspx';

        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 280, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

        return false;
    }

    $(document).ready(function () {
        $("input[readonly='readonly'].ac_input").click(function () {
            $("input[readonly='readonly'].ac_input").attr('disabled', 'disabled');
        })
    })


    function ConversionRateValidation(elem) {

        var Uid = $("#ctl00_cph_main_content_CostingFormNew1_hdnuserid").val();

        if (Uid != 5 && Uid != 646) {
            var Rate = elem.value;

            var Pre_Rate = parseFloat($("#ctl00_cph_main_content_CostingFormNew1_hdnCostingConversionRate").val());


            var max_Rate = Pre_Rate + 2;
            var min_Rate = Pre_Rate - 2;

            if (parseFloat(Rate) <= parseFloat(max_Rate) && parseFloat(Rate) >= parseFloat(min_Rate)) {
                $("#ctl00_cph_main_content_CostingFormNew1_txtConvRate").val(Rate.toString());
            }
            else {
                if (parseFloat(Pre_Rate) != parseFloat(Rate)) {
                    alert('Conversion Rate must be from Minimum ' + min_Rate.toString() + ' to Maximum ' + max_Rate.toString());
                }
                $("#ctl00_cph_main_content_CostingFormNew1_txtConvRate").val(Pre_Rate.toString());
                var TotalRate = $("#ctl00_cph_main_content_CostingFormNew1_txtTotal").val();
                if (isNaN(TotalRate)) {
                    $("#ctl00_cph_main_content_CostingFormNew1_txtTotal").val('');
                }
            }
        }
    }

    function ChangeRate(ele) {
        var currentAvg = ele.value;

        if (isNaN($('#' + ele.id).val())) {
            ShowHideValidationBox(true, "Entered digit is not valid.");
            $("#" + ele.id).val('');
            return false;
        }
        else if ($('#' + ele.id).val() == "0") {
            ShowHideValidationBox(true, "Zero digit is not valid.");
            $("#" + ele.id).val('');
            return false;
        }

        var previousval = ele.defaultValue;
        var UserID = parseInt($("#" + hdnuseridClientID).val());
        if (UserID == "5") {
            if (previousval != currentAvg) {
                SaveIkandiHide();
            }
        }

        if (ele.id == "ctl00_cph_main_content_CostingFormNew1_txtPriceQuoted") {
            if (previousval != currentAvg) {
                $("#ctl00_cph_main_content_CostingFormNew1_btnUpdatePrice").attr('title', 'Price Quoted Changed please save first.');
                $("#ctl00_cph_main_content_CostingFormNew1_btnUpdatePrice").attr('disabled', 'disabled');
            }
        }
    }
    function SaveIkandiHide() {

        $("#ctl00_cph_main_content_CostingFormNew1_hdnOpenCosting").val(1);
    }

    function showOldhistory(flag, elem, type) {

        if (elem.id != "") {
            var CostingId = $("#ctl00_cph_main_content_CostingFormNew1_hdnCosting").val();

            if (type == 1) {
                $("#Header_History_Comment").text('History');
            }
            else {
                $("#Header_History_Comment").text('Comments');
            }
            if (parseInt(CostingId) > 0) {
                proxy.invoke("Get_Costing_Old_History", { CostingId: CostingId },
                    function (result) {

                        var History = result;
                        var vDesc = '';
                        $(History).each(function () {
                            if (type == 1) {
                                vDesc = vDesc + this.History;

                            }
                            else {
                                vDesc = vDesc + this.Comments;

                            }
                        });
                        $("#ctl00_cph_main_content_CostingFormNew1_lblh").html(vDesc);
                    });
            }

        }

        $(".ModelPo2").css("display", flag);

    }

    function showhistoryhide(flag, elem) {

        $(".ModelPo2").css("display", flag);
    }

    $(document).ready(function () {

        var elem = "#ctl00_cph_main_content_CostingFormNew1_divhistory";
        $(document).keydown(function (e) {
            if (e.keyCode === 27) {
                $(elem).hide();
            }
        });
    });

    $(document).ready(function () {
        $("#<%=grdLandedCosting.ClientID%> tbody").addClass('CostingTableBody');

        $("#<%=grdDirectCosting.ClientID%> tbody").addClass('CostingTableBody');

        var $inputsRupees = $('.Rupees');

        $inputsRupees.find('input:.per-new').keypress(function (e) {
            if (e.which && e.charCode) {
                var c = String.fromCharCode(e.keyCode | e.charCode);
                resizeRupeesForText.call($(this), $(this).val() + c);
            }
        });


        $inputsRupees.find('input:.per-new').keyup(function (e) {
            if (e.keyCode === 8 || e.keyCode === 46) {
                resizeRupeesForText.call($(this), $(this).val());
            }
        });


        $inputsRupees.find('input:.per-new').each(function () {
            setTimeout(function () { }, 5000);

            $(this).parent().find('lable').text($(this).val());
            resizeRupeesForText.call($(this), $(this).val())
        });



        function resizeRupeesForText(text) {
            var $this = $(this);
            var $lable = $this.parent().find('lable');
            $lable.text(text);
            var $inputSize = $lable.width();
            if ($inputSize == 0 || $inputSize == 8) {
                $inputSize = 40;
            }
            else {
                $inputSize = $inputSize + 2;
            }

            $this.css("width", $inputSize);
        }

        $(document).ready(function () {
            var width = $(".grdDirectCostingTr .grdDirectCostingTd:first-child,.grdLandedCostingTr .grdLandedCostingTd:first-child").width();

            if (width > 100) {
                $(".grdDirectCostingTr .grdDirectCostingTd:first-child,.grdDirectCostingTh:first-child,.grdLandedCostingTr .grdLandedCostingTd:first-child,.CostingTableBody .grdLandedCostingTh:first-child").css("height", "20px");
            }
            else {
                $(".grdDirectCostingTr .grdDirectCostingTd:first-child").css("height", "auto");
            }
        });

        //        var $inputsGray = $('.gray');

        //        // Resize based on text if text.length > 0
        //        // Otherwise resize based on the placeholder
        //        function resizeGrayForText(text) {
        //            var $this = $(this);
        //            if (!text.trim()) {
        //                text = '';
        //            }
        //            var $lable = $(this).parent().find('lable');
        //            $lable.text(text);
        //            var $inputSize = $lable.width();
        //            $this.css("width", $inputSize);
        //        }

        //        $inputsGray.find('input').keypress(function (e) {
        //            if (e.which && e.charCode) {
        //                var c = String.fromCharCode(e.keyCode | e.charCode);
        //                var $this = $(this);
        //                resizeGrayForText.call($this, $this.val() + c);
        //            }
        //        });

        //        // Backspace event only fires for keyup
        //        $inputsGray.find('input').keyup(function (e) {
        //            if (e.keyCode === 8 || e.keyCode === 46) {
        //                resizeGrayForText.call($(this), $(this).val());
        //            }
        //        });

        //        $inputsGray.find('input').each(function () {
        //            var $this = $(this);
        //            $this.parent().find('lable').text($this.val());
        //            resizeGrayForText.call($this, $this.val())
        //        });
    });
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="costing_form hide_me1" runat="server" id="BIPLCosting" style="background-color: #f2f2f2;
    width: 100%; min-width: 1300px; max-width: 1880px; margin: 0 auto;">
    <div>
        <div id="divBIPL">
            <div style="clear: both;">
            </div>
            <div>
                <asp:HiddenField ID="hdnOpenCosting" runat="server" Value="0" />
                <asp:HiddenField ID="hdnCosting" runat="server" Value="0" />
                <%--added by raghvinder on 09-12-2020--%>
                <h2 style="width: 100%; background: #39589c;">
                    <div style="float: left; font-size: 10px; font-weight: normal; text-align: left;
                        visibility: hidden;">
                        <%-- <input type="checkbox" checked style="width: 20px;" id="chkShowHideCC">--%>
                        <asp:CheckBox ID="chkShowHideCC" Checked="false" runat="server" CssClass="shoamt" />
                        Show Amt. Client Currency
                    </div>
                    <div style="position: absolute; left: 44%; text-align: right; color: #fff">
                        <asp:CheckBox ID="chkTooltip" runat="server" ToolTip="All was view" Visible="false"
                            CssClass="chkwidth" />
                        Boutique Costing Sheet
                    </div>
                    <div style="position: absolute; left: 62%">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Font-Size="Small"></asp:Label>
                    </div>
                    <div style="color: #000; float: right; width: auto; padding: 0px 5px; font-weight: normal;">
                        <div style="float: left; text-align: right; padding-top: 3px;">
                            <span style="color: Blue; text-transform: capitalize; cursor: pointer;" title="UnRegister Fabric"
                                onclick="OpenUnRagiFabFun()">
                                <img src="../../images/urf.png" /></span> <span style="color: Blue; text-transform: capitalize;
                                    cursor: pointer;" title="UnRegister Accessory" onclick="OpenUnRagiAccessFun()">
                                    <img src="../../images/ura.png" /></span>
                        </div>
                        <div style="float: left; padding: 3px; margin-right: 10px; text-align: right; font-size: 10px;
                            font-weight: normal; margin-top: -1px;">
                            <strong style="padding-right: 3px; color: #fff">Status</strong>
                        </div>
                        <%-- <div style="background: #E49C9D; color: black; float: left; width: auto; padding: 3px;">
                    BIPL Agreement
                </div>--%>
                        <div runat="server" id="tdStatus" style="color: black; float: left; width: auto;
                            padding: 0px 7px;" class="status">
                            <asp:HiddenField ID="hiddenStyleId" Value="-1" runat="server" />
                            <a id="anchorWorkFlowHistory" href="javascript:void(0)" title="CLICK TO VIEW TRACKING POPUP"
                                onclick="showWorkflowHistory2(<%= hiddenStyleId.Value %>, -1, -1)" style="font-size: smaller;
                                text-decoration: none; color: #000;">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </a>
                        </div>
                        <div id="tdCounterComplete" runat="server" style="font-size: smaller; color: White;
                            display: none; float: left; width: auto; padding: 3px;" class="counter-complete">
                        </div>
                        <%-- <div style="background: #99CC00; color: black; float: left; width: auto; padding: 3px;">
                    Counter Complete
                </div>--%>
                        <%-- <div style="color: white; float: right; width: auto; margin-top: 4px;">
                    Delete
                </div>--%>
                        <div style="color: #ffffff; float: right; width: auto; margin-top: 4px; background-color: #39589C;
                            padding: 0px 7px; position: relative; top: -4px;" id="tdDeleteStyleAndCostingSheet"
                            class='<%= txtOrderId.Text == "-1" ? "form_small_heading_pink" : "hide_me" %>'>
                            <a href="javascript:DeleteStyleAndCostingSheet()" title="Delete Style Variation"
                                style="text-decoration: none; font-size: smaller; color: #f5f5f5;">Delete</a>
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                </h2>
                <div style="clear: both;">
                </div>
                <div style="clear: both;">
                </div>
                <table style="margin-top: -10px; clear: both;" cellpadding="5" cellspacing="0" id="tblCostingDetails"
                    runat="server">
                    <%-- <tr>
                    <td colspan="2">
                        <asp:Label ID="lblsuccess" style="font-size:Small;font-weight:bold;display:none;" runat="server"></asp:Label> 
                    </td>
                </tr> --%>
                    <tr>
                        <td width="70%" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" border="1" style="box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);">
                                <thead>
                                    <tr>
                                        <th width="100px">
                                            Style No.
                                        </th>
                                        <th width="120px">
                                            Garment Type
                                        </th>
                                        <th width="100px">
                                            Buyer
                                        </th>
                                        <th width="110px">
                                            Parent Dept.
                                        </th>
                                        <th width="80px">
                                            Dept.
                                        </th>
                                        <th width="50px">
                                            Booked
                                        </th>
                                        <th width="50px">
                                            Expec. Qty.
                                        </th>
                                        <th width="60px" style="display: none;">
                                            Target Price
                                        </th>
                                        <th width="50px">
                                            Weight (Gms)
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="height: 20px;">
                                            <input id="hdnFabchk" class="afab" value="COL" type="hidden" />
                                            <input id="hdnFabchk2" class="b" value="COL" type="hidden" />
                                            <input id="hdnFabchk3" class="c" value="COL" type="hidden" />
                                            <input id="hdnFabchk4" class="d" value="COL" type="hidden" />
                                            <asp:HiddenField Value="" runat="server" ID="hdnConIds" />
                                            <asp:TextBox runat="server" ID="txtIkandiStyle" ReadOnly="true" Width="96%" CssClass="costing-style-number-view bluebgcolor NoBorder"></asp:TextBox>
                                            <asp:Label ID="hdnBuyingHouse" CssClass="buying-house-id hide_me" runat="server"
                                                Text="Label"></asp:Label>
                                        </td>
                                        <td class="gray">
                                            <asp:Label ID="lblGarmetType" CssClass="exqty" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBuyer" runat="server" CssClass="costing-buyer per" Width="95%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnIsOrderConfirmed" runat="server" Value="0" />
                                            <asp:HiddenField ID="hdnbuyer" runat="server" Value="0" />
                                        </td>
                                        <td>
                                            <div>
                                                <asp:DropDownList runat="server" ID="ddlParentDept" CssClass="costing-Parentdepartment per"
                                                    Width="95%">
                                                    <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <asp:HiddenField runat="server" ID="hdnParentDeptId" Value="0" />
                                        </td>
                                        <td>
                                            <div>
                                                <asp:DropDownList runat="server" ID="ddlDept" CssClass="costing-department per" Width="95%">
                                                    <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <asp:HiddenField runat="server" ID="hdnDeptId" Value="0" />
                                            <asp:HiddenField ID="hdnuserid" runat="server" Value="0" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="hypBooked" Text="Booked" ForeColor="Blue" Style="cursor: pointer;"></asp:Label>
                                            <asp:HiddenField runat="server" ID="hdStyleCOdeValue" />
                                            <asp:TextBox runat="server" ID="txtQuantity" CssClass="numeric-field-without-decimal-places per"
                                                Text="" Style="display: none"></asp:TextBox>
                                            <a id="anchorQuantity" runat="server" href="javascript:void(0)" visible="false" onclick="showAllOrdersOnStyle()"
                                                style="text-decoration: none; color: Blue; font-size: 14px; font-size: smaller;">
                                            </a>
                                        </td>
                                        <td>
                                            <asp:HiddenField runat="server" ID="hdnManualValue" />
                                            <asp:TextBox ID="txtExpectedQuant" onchange="javascript:return GetCMTValue();" CssClass="numeric-field-without-decimal-places"
                                                runat="server" Style="font-size: 11px !important; color: #000000 !important;
                                                font-weight: bold; width: 70px; height: 15px; display: none;"></asp:TextBox>
                                            <asp:DropDownList ID="ddlExpectedQty" onchange="javascript:return GetCMTValue();"
                                                CssClass="exqty" runat="server">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="hdnddlExpectedQty" />
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:Label ID="lbltargetprice" runat="server" class="costing-target-price numeric-field-with-two-decimal-places lightbg1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtWeight" CssClass="numeric-field-without-decimal-places per"
                                                onchange="chechZero(this);" MaxLength="4" title="Please enter Weight"></asp:TextBox>
                                            <div id="hiddenValues" style="display: none">
                                                <asp:TextBox ID="txtStyleNumber" runat="server" CssClass="costing-style-number" Style="font-size: smaller;"></asp:TextBox>
                                                <asp:TextBox ID="txtStyleId" runat="server" CssClass="costing-style-id" Style="font-size: smaller;"></asp:TextBox>
                                                <asp:TextBox ID="txtOrderId" runat="server" CssClass="costing-order-id" Style="font-size: smaller;"></asp:TextBox>
                                                <asp:TextBox ID="txtCurrentStatusID" runat="server" CssClass="costing-current-status-id"
                                                    Style="font-size: smaller;"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <%-- Fabric Quality--%>
                            <asp:HiddenField ID="hdnDeleteFabric" runat="server" />
                            <asp:HiddenField ID="hdnDeleteButtonCount" runat="server" />
                            <table width="100%" cellpadding="0" cellspacing="0" border="1" class="tablefab" style="box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);">
                                <thead>
                                    <tr>
                                        <th colspan="12">
                                            <h3>
                                                Fabric Details
                                            </h3>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th width="4%">
                                            Type
                                        </th>
                                        <th width="20%">
                                            Fabric Quality<br />
                                            Count Construction (GSM)<br />
                                            Print/Solid
                                        </th>
                                        <th width="13%">
                                            Value Addition
                                            <br />
                                            Wastage Rate
                                        </th>
                                        <th width="12%">
                                            Print image
                                        </th>
                                        <th width="10%">
                                            Upload File
                                        </th>
                                        <th width="7%">
                                            Width
                                        </th>
                                        <th width="7%">
                                            <%--<div style="border-bottom: 1px solid gray">--%>
                                            Avg LPlan
                                            <%-- </div>
                                        <div>
                                            (Total Fabric)</div>--%>
                                        </th>
                                        <th width="7%" style="display: none;">
                                            Grading<br />
                                            Extra
                                        </th>
                                        <th width="7%" style="display: none;">
                                            Residual Shrinkage %
                                        </th>
                                        <th style="width: 8%">
                                            Rate
                                        </th>
                                        <th width="9%" style="display: none;">
                                            Tot Metrage
                                        </th>
                                        <th style="width: 10%">
                                            Tot Amount
                                        </th>
                                        <th width="4%">
                                            Action
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="tbodyFab">
                                    <%-- Fabric 1--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab1" style="display: none;">
                                        <td class="border_left_color">
                                            <asp:DropDownList runat="server" ID="ddlPrintType1" class="lightbg1 alin" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType1" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin per" style="width: 100%;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric1" runat="server" Style='height: 12px' BorderStyle="None"
                                                            CssClass="costing-fabric fabric1 per alin boldness" onblur="Check_Registered_FabricName(this,'1')"
                                                            Width="98%"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID1" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric1" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON" runat="server" CssClass="alin COUNTCON1" Text=""></asp:Label>
                                                    <asp:Label ID="GSML" runat="server" CssClass="alin GSML1" Text=""></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate1" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate1" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate1" runat="server" Value="0" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType1" class="lightbg1 fab_Type1 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl1" CssClass="lblone" runat="server" Text=""></asp:Label>
                                                <label id="lblprd11" class="a">
                                                </label>
                                                <input id="txtFabricType1" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'1')"
                                                    class="alin one fabric1-type fabric-type blue_center_text fab_prt1 style18 txtFabricVal1"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType1" runat="server" CssClass=""></asp:Label>
                                                <input id="fab1hdn" value="gajendra" type="hidden" />
                                                <input id="fab2hdn" value="gajendra" type="hidden" />
                                                <asp:TextBox ID="hdn1" runat="server" Style="display: none;" BorderStyle="None" Width="135px"
                                                    CssClass="onehide"></asp:TextBox>
                                                <asp:TextBox ID="hdn1Prev" runat="server" Style="display: none;" BorderStyle="None"
                                                    Width="150px" CssClass="oneprev"></asp:TextBox>
                                                <nobr>
                                            <input type="hidden" id="hidFab1Details" class="hidden-details" value="COL" runat="server" />
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition1_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition1_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId1_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage1_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency1_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate1_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblValueAddition1_2" runat="server"></asp:Label></div>
                                            <asp:DropDownList ID="ddlValueAddition1_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId1_2" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage1_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency1_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate1_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <asp:Label ID="lblOrigin1" runat="server" CssClass="hid_origin1" Visible="false"></asp:Label>&nbsp;
                                            <div style="display: none;" class="div_show hide_me div_show1" id="divRadioMode1">
                                                <input type="radio" name="radioMode1" value="1" class="radio_mode1 radio_mode" checked="checked"
                                                    style="font-size: 8px; width: 12px; height: 12px" title="A" />A
                                                <input type="radio" name="radioMode1" value="0" class="radio_mode1 radio_mode" style="font-size: 8px;
                                                    width: 12px; height: 12px" title="S" />S
                                                <asp:HiddenField runat="server" ID="hiddenRadioMode1" Value="1" />
                                            </div>
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table1" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px; text-align: center;">
                                                            <a title="Print Image" class="thickbox box1 " href="/App_Themes/ikandi/images/preview.png">
                                                                <img id="imgPrint1" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                    width: 38px;" class="costing-print-image1" title="Click to view enlarged image" /></a>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId1" runat="server"
                                                                    CssClass="costing-print1 do-not-allow-typing lightbg1" BorderStyle="None" Width="35px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="2" height="15px" style="color: #575759;">
                                                        <a href="#" id="LayFile1" style="display: none;">Browse</a>
                                                        <asp:FileUpload ID="LayFile1" CssClass="lay_file1 style20 ShowHideFile1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst1" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile1"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay1" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay1 ShowHideFile1"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 10px; height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblcad1" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile1"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad1" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile1"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" style="border-right: 0px">
                                                        <asp:Label ID="lblmarker1" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile1"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc1" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile1"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth1" Width="25px" Font-Size="14px" BorderStyle="None"
                                                    onblur="CalculateCM(this);" MaxLength="6" Style="text-align: center; outline: none;
                                                    color: Black;" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth1" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM1" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage1" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage1" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric1" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste1" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste1" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="lblRS1" runat="server" Text="0" CssClass="per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important; position: relative;
                                                top: 8px;">
                                                <asp:TextBox runat="server" ID="txtRate1" Font-Size="14px" onblur="ChangeRate(this);"
                                                    Width="32px" ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);"
                                                    MaxLength="6" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new "></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate1" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate1" runat="server" CssClass="ShowHideCC gray"></asp:Label>
                                            </div>
                                        </td>
                                        <td class="hide_me lightbg1" rowspan="2" align="center">
                                            <asp:TextBox runat="server" ID="txtAmount1" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount1" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal1" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal1" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal1" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg1" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: gray;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice1" Width="50px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false" Style="text-align: justify; padding-left: 0;"></asp:TextBox>
                                            <asp:Label ID="lblTPrice1" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(1);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%-- Fabric 2--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab2" style="display: none;">
                                        <td class="border_left_color">
                                            <asp:DropDownList runat="server" ID="ddlPrintType2" class="lightbg1 alin" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType2" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin " style="width: 232px;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric2" MaxLength="60" runat="server" onblur="Check_Registered_FabricName(this,'2')"
                                                            Width="210px" BorderStyle="None" CssClass="costing-fabric alin fabric2 per boldness"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID2" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric2" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON2" runat="server" CssClass="alin COUNTCON2"></asp:Label>
                                                    <asp:Label ID="GSML2" runat="server" CssClass="alin GSML2"></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON2" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML2" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate2" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate2" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate2" Value="0" runat="server" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType2" class="lightbg1 fab_Type2 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl2" Visible="false" CssClass="lblTwo" runat="server" Text=""></asp:Label>
                                                <label id="lblprd22" class="a">
                                                </label>
                                                <input id="txtFabricType2" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'2');"
                                                    class="alin one fabric-type blue_center_text darkbg1 fab_prt2 txtFabricVal2"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType2" runat="server" CssClass=""></asp:Label>
                                                <input id="fab22hdn" value="yaten" type="hidden" />
                                                <input id="fab22hdn2" value="yaten" type="hidden" />
                                                <asp:TextBox ID="hdn2" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                                    CssClass="twohide"></asp:TextBox>
                                                <asp:TextBox ID="hdn2Prev" runat="server" BorderStyle="None" Style="display: none;"
                                                    Width="150px" CssClass="twoprev"></asp:TextBox>
                                                <br />
                                                <nobr>
                                            <input type="hidden" id="hidFab2Details" class="hidden-details" value="COL" runat="server" />
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition2_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition2_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId2_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage2_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency2_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate2_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblValueAddition2_2" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition2_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId2_2" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage2_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency2_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate2_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <nobr>
                                <asp:Label ID="lblOrigin2" runat="server" CssClass="hid_origin2"></asp:Label>&nbsp;
                              
                                </nobr>
                                            <div class=" div_show hide_me div_show2" id="divRadioMode2">
                                                <nobr>
                                <input type="radio" name="radioMode2" value="1" class="radio_mode2 radio_mode" title="A"  checked="checked" style="font-size:8px;width:12px;height:12px"/>A
                                <input type="radio" name="radioMode2" value="0" class="radio_mode2 radio_mode" title="S"  style="font-size:8px;width:12px;height:12px"/>S
                                </nobr>
                                                <asp:HiddenField runat="server" ID="hiddenRadioMode2" Value="1" />
                                            </div>
                                            <br />
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table2" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px">
                                                            <div>
                                                                <a title="Print Image" class="thickbox box2" href="/App_Themes/ikandi/images/preview.png">
                                                                    <img id="imgPrint2" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                        width: 38px;" class="costing-print-image2" title="Click to view enlarged image" /></a>
                                                            </div>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId2" runat="server"
                                                                    CssClass="costing-print2 do-not-allow-typing lightbg1" BorderStyle="None" Width="35px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="2" height="15px" style="color: #575759;">
                                                        <a href="#" id="LayFile2" style="display: none;">Browse</a>
                                                        <asp:FileUpload ID="LayFile2" CssClass="lay_file2 style20 ShowHideFile2" runat="server"
                                                            Style="display: none;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst2" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile2"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay2" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay2 ShowHideFile2"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 10px; height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblcad2" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile2"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad2" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile2"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" style="border-right: 0px">
                                                        <asp:Label ID="lblmarker2" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile2"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc2" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile2"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth2" Width="25px" Font-Size="14px" onblur="CalculateCM(this);"
                                                    MaxLength="6" Style="text-align: center; outline: none; color: Black;" BorderStyle="None"
                                                    CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth2" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM2" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage2" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage2" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric2" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste2" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste2" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="lblRS2" runat="server" Text="0" CssClass=" per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important">
                                                <asp:TextBox runat="server" ID="txtRate2" Font-Size="14px" Width="34px" onblur="ChangeRate(this);"
                                                    ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);" MaxLength="6"
                                                    BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new"></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate2" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate2" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                        </td>
                                        <td class="hide_me lightbg1" align="center">
                                            <asp:TextBox runat="server" ID="txtAmount2" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount2" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal2" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal2" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal2" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg2" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice2" Width="40px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false" Style="text-align: justify; padding-left: 0;"></asp:TextBox>
                                            <asp:Label ID="lblTPrice2" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(2);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%-- Fabric 3--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab3" style="display: none;">
                                        <td class="border_left_color">
                                            <asp:DropDownList runat="server" ID="ddlPrintType3" class="lightbg1" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType3" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin per" style="width: 232px;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric3" MaxLength="60" runat="server" onblur="Check_Registered_FabricName(this,'3')"
                                                            Width="210px" BorderStyle="None" CssClass="costing-fabric fabric3 per alin boldness"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID3" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric3" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON3" runat="server" CssClass="alin COUNTCON3"></asp:Label>
                                                    <asp:Label ID="GSML3" runat="server" CssClass="alin GSML3"></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON3" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML3" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate3" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate3" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate3" Value="0" runat="server" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType3" class="lightbg1 fab_Type3 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl3" CssClass="lblThree" Visible="false" runat="server" Text=""></asp:Label>
                                                <label id="lblprd33" class="a">
                                                </label>
                                                <input id="txtFabricType3" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'3')"
                                                    class="alin one fabric-type blue_center_text darkbg1 fab_prt3 txtFabricVal3"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType3" runat="server" CssClass=""></asp:Label>
                                                <input id="fab33hdn" value="yaten" type="hidden" />
                                                <input id="fab33hdn3" value="yaten" type="hidden" />
                                                <asp:TextBox ID="hdn3" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                                    CssClass="threehide"></asp:TextBox>
                                                <asp:TextBox ID="hdn3Prev" runat="server" BorderStyle="None" Style="display: none;"
                                                    Width="150px" CssClass="threeprev"></asp:TextBox>
                                                <br />
                                                <nobr>
                                            <input type="hidden" id="hidFab3Details" class="hidden-details" value="COL" runat="server" />
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition3_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition3_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId3_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage3_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency3_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate3_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblValueAddition3_2" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition3_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId3_2" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage3_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency3_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate3_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <nobr>
                                <asp:Label ID="lblOrigin3" runat="server" CssClass="hid_origin3"></asp:Label>&nbsp;
                              

                                        <div style="" class=" div_show hide_me div_show3" id="divRadioMode3">
                                        <nobr>
                                        <input type="radio" name="radioMode3" value="1" class="radio_mode3 radio_mode"  checked="checked"
                                            style="font-size: 8px; width: 12px; height: 12px" title="A" />A
                                        <input type="radio" name="radioMode3" value="0" class="radio_mode3 radio_mode"  style="font-size: 8px;
                                            width: 12px; height: 12px" title="S"/>S
                                    </nobr>
                                        <asp:HiddenField runat="server" ID="hiddenRadioMode3" Value="1" />
                                    </div>
                                    <br />
                                </nobr>
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table3" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px">
                                                            <div>
                                                                <a title="Print Image" class="thickbox box3" href="/App_Themes/ikandi/images/preview.png">
                                                                    <img id="imgPrint3" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                        width: 38px;" class="costing-print-image3" title="Click to view enlarged image" /></a>
                                                            </div>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId3" runat="server"
                                                                    CssClass="costing-print3 do-not-allow-typing lightbg1" BorderStyle="None" Width="40px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="15px" colspan="2" style="color: #575759;">
                                                        <a href="#" id="LayFile3" style="display: none;">Browse</a>
                                                        <asp:FileUpload ID="LayFile3" CssClass="lay_file3 style20 ShowHideFile3" runat="server"
                                                            Style="display: none;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst3" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile3"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay3" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay3 ShowHideFile3"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px;">
                                                        <asp:Label ID="lblcad3" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile3"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad3" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile3"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblmarker3" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile3"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc3" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile3"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth3" Width="25px" Font-Size="14px" BorderStyle="None"
                                                    onblur="CalculateCM(this);" MaxLength="6" Style="text-align: center; outline: none;
                                                    color: Black;" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth3" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM3" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage3" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage3" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric3" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste3" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste3" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="lblRS3" runat="server" Text="0" CssClass="per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important">
                                                <asp:TextBox runat="server" ID="txtRate3" Font-Size="14px" Width="34px" onblur="ChangeRate(this);"
                                                    ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);" MaxLength="6"
                                                    BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new"></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate3" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate3" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                        </td>
                                        <td class="hide_me lightbg1">
                                            <asp:TextBox runat="server" ID="txtAmount3" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount3" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal3" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal3" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal3" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg3" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice3" Width="40px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false" Style="text-align: left;"></asp:TextBox>
                                            <asp:Label ID="lblTPrice3" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(3);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%-- Fabric 4--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab4" style="display: none;">
                                        <td class="border_left_color">
                                            <asp:DropDownList runat="server" ID="ddlPrintType4" class="lightbg1" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType4" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin per" style="width: 232px;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric4" MaxLength="60" runat="server" onblur="Check_Registered_FabricName(this,'4')"
                                                            Width="210px" BorderStyle="None" CssClass="costing-fabric fabric4 per alin boldness"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID4" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric4" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON4" runat="server" CssClass="alin COUNTCON4"></asp:Label>
                                                    <asp:Label ID="GSML4" runat="server" CssClass="alin GSML4"></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON4" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML4" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate4" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate4" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate4" Value="0" runat="server" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType4" class="lightbg1 fab_Type4 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl4" CssClass="lblFourth" Visible="false" runat="server" Text=""></asp:Label>
                                                <label id="lblprd44" class="a">
                                                </label>
                                                <input id="txtFabricType4" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'4')"
                                                    class="alin one fabric-type blue_center_text darkbg1 fab_prt4 txtFabricVal4"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType4" runat="server" CssClass=""></asp:Label>
                                                <input id="fab44hdn" value="yaten" type="hidden" />
                                                <input id="fab44hdn4" value="yaten" type="hidden" />
                                                <asp:TextBox ID="hdn4" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                                    CssClass="fourthhide"></asp:TextBox>
                                                <asp:TextBox ID="hdn4Prev" runat="server" BorderStyle="None" Style="display: none;"
                                                    Width="150px" CssClass="fourthprev"></asp:TextBox>
                                                <br />
                                                <nobr>
                                            <input type="hidden" id="hidFab4Details" class="hidden-details" value="COL" runat="server" />
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition4_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition4_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId4_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage4_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency4_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate4_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:DropDownList ID="ddlValueAddition4_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId4_2" Value="-1" runat="server" />
                                            <br />
                                            <div>
                                                <asp:Label ID="lblValueAddition4_2" runat="server"></asp:Label>
                                            </div>
                                            <asp:TextBox ID="txtVAWastage4_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency4_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate4_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <nobr>
                                <asp:Label ID="lblOrigin4" runat="server" CssClass="hid_origin4"></asp:Label>&nbsp;
                              

                                        <div class=" div_show hide_me div_show4" id="divRadioMode4">
                                        <nobr>
                                <input type="radio" name="radioMode4" value="1" class="radio_mode4 radio_mode" title="A"   checked="checked" style="font-size:8px;width:12px;height:12px" />A
                                <input type="radio" name="radioMode4" value="0" class="radio_mode4 radio_mode" title="S"   style="font-size:8px;width:12px;height:12px" />S
                                </nobr>
                                        <asp:HiddenField runat="server" ID="hiddenRadioMode4" Value="1" />
                                    </div>
                                    <br />
                                </nobr>
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table4" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px">
                                                            <div>
                                                                <a title="Print Image" class="thickbox box4" href="/App_Themes/ikandi/images/preview.png">
                                                                    <img id="imgPrint4" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                        width: 38px;" class="costing-print-image4" title="Click to view enlarged image" /></a>
                                                            </div>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId4" runat="server"
                                                                    CssClass="costing-print4 do-not-allow-typing lightbg1" BorderStyle="None" Width="40px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="15px" colspan="2">
                                                        <a href="#" id="LayFile4" style="display: none;">Browse </a>
                                                        <asp:FileUpload ID="LayFile4" CssClass="lay_file4 style20 ShowHideFile4" runat="server"
                                                            Style="display: none;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst4" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile4"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay4" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay4 ShowHideFile4"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblcad4" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile4"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad4" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile4"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblmarker4" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile4"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc4" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile4"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth4" Width="25px" Font-Size="14px" BorderStyle="None"
                                                    onblur="CalculateCM(this);" MaxLength="6" Style="text-align: center; outline: none;
                                                    color: Black;" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing  lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth4" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM4" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage4" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage4" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric4" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste4" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste4" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="lblRS4" runat="server" Text="0" CssClass="per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important">
                                                <asp:TextBox runat="server" ID="txtRate4" Font-Size="14px" Width="34px" onblur="ChangeRate(this);"
                                                    ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);" MaxLength="6"
                                                    BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new"></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate4" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate4" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                        </td>
                                        <td class="hide_me lightbg1">
                                            <asp:TextBox runat="server" ID="txtAmount4" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount4" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal4" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal4" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal4" runat="server" CssClass="ShowHideCC gray"></asp:Label>
                                            </div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg4" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee" style="margin-left: 10px;"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice4" Width="50px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false" Style="text-align: left;"></asp:TextBox>
                                            <asp:Label ID="lblTPrice4" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(4);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%-- Fabric 5--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab5" style="display: none;">
                                        <td class="border_left_color">
                                            <asp:DropDownList runat="server" ID="ddlPrintType5" class="lightbg1 alin" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType5" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin per" style="width: 232px;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric5" MaxLength="60" runat="server" onblur="Check_Registered_FabricName(this,'5')"
                                                            Width="210px" BorderStyle="None" CssClass="costing-fabric fabric5 per alin boldness"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID5" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric5" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON5" runat="server" CssClass="alin COUNTCON5" Text=""></asp:Label>
                                                    <asp:Label ID="GSML5" runat="server" CssClass="alin GSML5" Text=""></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON5" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML5" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate5" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate5" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate5" runat="server" Value="0" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType5" class="lightbg1 fab_Type5 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl5" CssClass="lblone" runat="server" Text=""></asp:Label>
                                                <label id="lblprd55" class="a">
                                                </label>
                                                <input id="txtFabricType5" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'5')"
                                                    class="alin one fabric-type blue_center_text fab_prt5 style18 txtFabricVal5"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType5" runat="server" CssClass=""></asp:Label>
                                                <input id="fab55hdn" value="gajendra" type="hidden" />
                                                <input id="fab55hdn5" value="gajendra" type="hidden" />
                                                <asp:TextBox ID="hdn5" runat="server" Style="display: none;" BorderStyle="None" Width="135px"
                                                    CssClass="onehide"></asp:TextBox>
                                                <asp:TextBox ID="hdn5Prev" runat="server" Style="display: none;" BorderStyle="None"
                                                    Width="150px" CssClass="oneprev"></asp:TextBox>
                                                <br />
                                                <nobr>
                                            <div style="float:left;">                                     
                                                <input type="hidden" id="hidFab5Details" class="hidden-details" value="COL" runat="server" />
                                            </div>
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition5_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition5_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId5_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage5_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency5_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate5_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:DropDownList ID="ddlValueAddition5_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId5_2" Value="-1" runat="server" />
                                            <br />
                                            <div>
                                                <asp:Label ID="lblValueAddition5_2" runat="server"></asp:Label>
                                            </div>
                                            <asp:TextBox ID="txtVAWastage5_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency5_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate5_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <asp:Label ID="lblOrigin5" runat="server" CssClass="hid_origin5" Visible="false"></asp:Label>&nbsp;
                                            <div style="display: none;" class="div_show hide_me div_show5" id="divRadioMode5">
                                                <input type="radio" name="radioMode5" value="1" class="radio_mode5 radio_mode" checked="checked"
                                                    style="font-size: 8px; width: 12px; height: 12px" title="A" />A
                                                <input type="radio" name="radioMode5" value="0" class="radio_mode5 radio_mode" style="font-size: 8px;
                                                    width: 12px; height: 12px" title="S" />S
                                                <asp:HiddenField runat="server" ID="hiddenRadioMode5" Value="1" />
                                            </div>
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px; text-align: center;">
                                                            <a title="Print Image" class="thickbox box5 " href="/App_Themes/ikandi/images/preview.png">
                                                                <img id="imgPrint5" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                    width: 38px;" class="costing-print-image5" title="Click to view enlarged image" /></a>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId5" runat="server"
                                                                    CssClass="costing-print5 do-not-allow-typing lightbg1" BorderStyle="None" Width="35px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="2" height="15px">
                                                        <a href="#" id="LayFile5" style="display: none;">Browse</a>
                                                        <asp:FileUpload ID="LayFile5" CssClass="lay_file5 style20 ShowHideFile5" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst5" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile5"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay5" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay5 ShowHideFile5"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 10px; height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblcad5" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile5"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad5" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile5"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" style="border-right: 0px">
                                                        <asp:Label ID="lblmarker5" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile5"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc5" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile5"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth5" Width="25px" Font-Size="14px" BorderStyle="None"
                                                    onblur="CalculateCM(this);" MaxLength="6" Style="text-align: center; outline: none;
                                                    color: Black;" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing  lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth5" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM5" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage5" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage5" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric5" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste5" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste5" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="lblRS5" runat="server" Text="0" CssClass="per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important">
                                                <asp:TextBox runat="server" ID="txtRate5" Font-Size="14px" Width="34px" onblur="ChangeRate(this);"
                                                    ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);" MaxLength="6"
                                                    BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new"></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate5" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate5" runat="server" CssClass="ShowHideCC gray"></asp:Label>
                                            </div>
                                        </td>
                                        <td class="hide_me lightbg1" rowspan="2" align="center">
                                            <asp:TextBox runat="server" ID="txtAmount5" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount5" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal5" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal5" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal5" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg5" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee" style="margin-left: 10px;"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice5" Width="50px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false" Style="text-align: left;"></asp:TextBox>
                                            <asp:Label ID="lblTPrice5" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(5);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%-- Fabric 6--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab6" style="display: none;">
                                        <td class="border_left_color">
                                            <asp:DropDownList runat="server" ID="ddlPrintType6" class="lightbg1 alin" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType6" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin " style="width: 232px;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric6" MaxLength="60" runat="server" onblur="Check_Registered_FabricName(this,'6')"
                                                            Width="210px" BorderStyle="None" CssClass="costing-fabric alin fabric6 per boldness"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID6" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric6" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON6" runat="server" CssClass="alin COUNTCON6"></asp:Label>
                                                    <asp:Label ID="GSML6" runat="server" CssClass="alin GSML6"></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON6" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML6" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate6" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate6" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate6" Value="0" runat="server" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType6" class="lightbg1 fab_Type6 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl6" Visible="false" CssClass="lblTwo" runat="server" Text=""></asp:Label>
                                                <label id="lblprd66" class="a">
                                                </label>
                                                <input id="txtFabricType6" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'6')"
                                                    class="alin one fabric-type blue_center_text darkbg1 fab_prt6 txtFabricVal6"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType6" runat="server" CssClass=""></asp:Label>
                                                <input id="fab66hdn" value="yaten" type="hidden" />
                                                <input id="fab66hdn6" value="yaten" type="hidden" />
                                                <asp:TextBox ID="hdn6" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                                    CssClass="twohide"></asp:TextBox>
                                                <asp:TextBox ID="hdn6Prev" runat="server" BorderStyle="None" Style="display: none;"
                                                    Width="150px" CssClass="twoprev"></asp:TextBox>
                                                <br />
                                                <nobr>
                                                <input type="hidden" id="hidFab6Details" class="hidden-details" value="COL" runat="server" />
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition6_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition6_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId6_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage6_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency6_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate6_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblValueAddition6_2" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition6_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 70%">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId6_2" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage6_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency6_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate6_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <nobr>
                                <asp:Label ID="lblOrigin6" runat="server" CssClass="hid_origin6"></asp:Label>&nbsp;                               
                                </nobr>
                                            <div class=" div_show hide_me div_show6" id="divRadioMode6">
                                                <nobr>
                                <input type="radio" name="radioMode6" value="1" class="radio_mode6 radio_mode" title="A"  checked="checked" style="font-size:8px;width:12px;height:12px"/>A
                                <input type="radio" name="radioMode6" value="0" class="radio_mode6 radio_mode" title="S"  style="font-size:8px;width:12px;height:12px"/>S
                                </nobr>
                                                <asp:HiddenField runat="server" ID="hiddenRadioMode6" Value="1" />
                                            </div>
                                            <br />
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table6" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px">
                                                            <div>
                                                                <a title="Print Image" class="thickbox box6" href="/App_Themes/ikandi/images/preview.png">
                                                                    <img id="imgPrint6" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                        width: 38px;" class="costing-print-image6" title="Click to view enlarged image" /></a>
                                                            </div>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId6" runat="server"
                                                                    CssClass="costing-print6 do-not-allow-typing lightbg1" BorderStyle="None" Width="35px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="2" height="15px">
                                                        <a href="#" id="LayFile6" style="display: none;">Browse</a>
                                                        <asp:FileUpload ID="LayFile6" CssClass="lay_file6 style20 ShowHideFile6" runat="server"
                                                            Style="display: none;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst6" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile6"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay6" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay6 ShowHideFile6"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; padding-left: 10px; height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblcad6" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile6"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad6" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile6"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" style="border-right: 0px">
                                                        <asp:Label ID="lblmarker6" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile6"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc6" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile6"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth6" Width="25px" Font-Size="14px" onblur="CalculateCM(this);"
                                                    MaxLength="6" Style="text-align: center; outline: none; color: Black;" BorderStyle="None"
                                                    CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth6" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM6" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage6" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage6" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric6" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste6" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste6" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="lblRS6" runat="server" Text="0" CssClass=" per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important">
                                                <asp:TextBox runat="server" ID="txtRate6" Font-Size="14px" Width="34px" onblur="ChangeRate(this);"
                                                    ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);" MaxLength="6"
                                                    BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new"></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate6" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate6" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                        </td>
                                        <td class="hide_me lightbg1" align="center">
                                            <asp:TextBox runat="server" ID="txtAmount6" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount6" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal6" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal6" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal6" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg6" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee" style="margin-left: 10px;"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice6" Width="50px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false" Style="text-align: left"></asp:TextBox>
                                            <asp:Label ID="lblTPrice6" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(6);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%-- Fabric 7--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab7" style="display: none;">
                                        <td class="border_left_color FabricDeleteButton">
                                            <asp:DropDownList runat="server" ID="ddlPrintType7" class="lightbg1" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType7" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin per" style="width: 232px;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric7" MaxLength="60" onblur="Check_Registered_FabricName(this,'7')"
                                                            runat="server" Width="210px" BorderStyle="None" CssClass="costing-fabric fabric7 per alin boldness"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID7" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric7" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON7" runat="server" CssClass="alin COUNTCON7"></asp:Label>
                                                    <asp:Label ID="GSML7" runat="server" CssClass="alin GSML7"></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON7" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML7" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate7" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate7" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate7" Value="0" runat="server" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType7" class="lightbg1 fab_Type7 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl7" CssClass="lblThree" Visible="false" runat="server" Text=""></asp:Label>
                                                <label id="lblprd77" class="a">
                                                </label>
                                                <input id="txtFabricType7" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'7')"
                                                    class="alin one fabric-type blue_center_text darkbg1 fab_prt7 txtFabricVal7"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType7" runat="server" CssClass=""></asp:Label>
                                                <input id="fab77hdn" value="yaten" type="hidden" />
                                                <input id="fab77hdn7" value="yaten" type="hidden" />
                                                <asp:TextBox ID="hdn7" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                                    CssClass="threehide"></asp:TextBox>
                                                <asp:TextBox ID="hdn7Prev" runat="server" BorderStyle="None" Style="display: none;"
                                                    Width="150px" CssClass="threeprev"></asp:TextBox>
                                                <br />
                                                <nobr>
                                             <input type="hidden" id="hidFab7Details" class="hidden-details" value="COL" runat="server" />
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition7_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition7_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 80px">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId7_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage7_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency7_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate7_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblValueAddition7_2" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition7_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 80px">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId7_2" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage7_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency7_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate7_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <nobr>
                                <asp:Label ID="lblOrigin7" runat="server" CssClass="hid_origin7"></asp:Label>&nbsp;                             

                                        <div style="" class=" div_show hide_me div_show7" id="divRadioMode7">
                                        <nobr>
                                        <input type="radio" name="radioMode7" value="1" class="radio_mode7 radio_mode"  checked="checked"
                                            style="font-size: 8px; width: 12px; height: 12px" title="A" />A
                                        <input type="radio" name="radioMode7" value="0" class="radio_mode7 radio_mode"  style="font-size: 8px;
                                            width: 12px; height: 12px" title="S"/>S
                                    </nobr>
                                        <asp:HiddenField runat="server" ID="hiddenRadioMode7" Value="1" />
                                    </div>
                                    <br />
                                </nobr>
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table7" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px">
                                                            <div>
                                                                <a title="Print Image" class="thickbox box7" href="/App_Themes/ikandi/images/preview.png">
                                                                    <img id="imgPrint7" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                        width: 38px;" class="costing-print-image7" title="Click to view enlarged image" /></a>
                                                            </div>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId7" runat="server"
                                                                    CssClass="costing-print7 do-not-allow-typing lightbg1" BorderStyle="None" Width="40px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="15px" colspan="2">
                                                        <a href="#" id="LayFile7" style="display: none;">Browse</a>
                                                        <asp:FileUpload ID="LayFile7" CssClass="lay_file7 style20 ShowHideFile7" runat="server"
                                                            Style="display: none;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst7" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile7"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay7" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay7 ShowHideFile7"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblcad7" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile7"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad7" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile7"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblmarker7" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile7"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc7" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile7"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth7" Width="25px" Font-Size="14px" BorderStyle="None"
                                                    onblur="CalculateCM(this);" MaxLength="6" Style="text-align: center; outline: none;
                                                    color: Black;" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth7" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM7" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage7" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage7" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric7" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste7" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste7" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="lblRS7" runat="server" Text="0" CssClass="per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important">
                                                <asp:TextBox runat="server" ID="txtRate7" Font-Size="14px" Width="34px" onblur="ChangeRate(this);"
                                                    ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);" MaxLength="6"
                                                    BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new"></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate7" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate7" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                        </td>
                                        <td class="hide_me lightbg1">
                                            <asp:TextBox runat="server" ID="txtAmount7" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount7" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal7" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal7" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal7" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg7" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice7" Width="40px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false"></asp:TextBox>
                                            <asp:Label ID="lblTPrice7" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(7);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%-- Fabric 8--%>
                                    <tr runat="server" class="tr-fab rowCount" id="tr_fab8" style="display: none;">
                                        <td class="border_left_color">
                                            <asp:DropDownList runat="server" ID="ddlPrintType8" class="lightbg1" BorderStyle="None">
                                                <%--<asp:ListItem Text="..." Value="-1" Selected="True"></asp:ListItem>--%>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="O" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPrintType8" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <div>
                                                <div class="alin per" style="width: 232px;">
                                                    <span class="FabricRemark">
                                                        <asp:TextBox ID="txtFabric8" MaxLength="60" onblur="Check_Registered_FabricName(this,'8')"
                                                            runat="server" Width="210px" BorderStyle="None" CssClass="costing-fabric fabric8 per alin boldness"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnFabricID8" runat="server" Value="0" />
                                                    <asp:Label ID="lblFabric8" runat="server"></asp:Label>
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Label ID="COUNTCON8" runat="server" CssClass="alin COUNTCON8"></asp:Label>
                                                    <asp:Label ID="GSML8" runat="server" CssClass="alin GSML8"></asp:Label>
                                                    <asp:HiddenField ID="hdnCOUNTCON8" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnGSML8" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <br />
                                            <div style="vertical-align: bottom; text-align: left;" class="td_no_padding">
                                                <asp:HiddenField ID="hdnDyedRate8" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnPrintRate8" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnDigitalPrintRate8" Value="0" runat="server" />
                                                <asp:DropDownList runat="server" ID="DDLFabricType8" class="lightbg1 fab_Type8 costing-ddlFabricType"
                                                    BorderStyle="None">
                                                    <asp:ListItem Text="Dyed" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Screen Print" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Digital Print" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lbl8" CssClass="lblFourth" Visible="false" runat="server" Text=""></asp:Label>
                                                <label id="lblprd88" class="a">
                                                </label>
                                                <input id="txtFabricType8" style="text-align: left; margin: 5px 0px; height: 18px;
                                                    color: black; border: none; width: 215px;" runat="server" onblur="CheckFabricName(this,'8')"
                                                    class="alin one fabric-type blue_center_text darkbg1 fab_prt8 txtFabricVal8"
                                                    type="text" />
                                                <asp:Label ID="lblFabricType8" runat="server" CssClass=""></asp:Label>
                                                <input id="fab88hdn" value="yaten" type="hidden" />
                                                <input id="fab88hdn8" value="yaten" type="hidden" />
                                                <asp:TextBox ID="hdn8" runat="server" BorderStyle="None" Style="display: none;" Width="150px"
                                                    CssClass="fourthhide"></asp:TextBox>
                                                <asp:TextBox ID="hdn8Prev" runat="server" BorderStyle="None" Style="display: none;"
                                                    Width="150px" CssClass="fourthprev"></asp:TextBox>
                                                <br />
                                                <nobr>
                                             <input type="hidden" id="hidFab8Details" class="hidden-details" value="COL" runat="server" />
                                            </nobr>
                                            </div>
                                        </td>
                                        <td style="width: 125px;">
                                            <div>
                                                <asp:Label ID="lblValueAddition8_1" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition8_1" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 80px">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId8_1" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage8_1" CssClass="do-not-allow-typing VAWastage1" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency8_1" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate8_1" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate1" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblValueAddition8_2" runat="server"></asp:Label>
                                            </div>
                                            <asp:DropDownList ID="ddlValueAddition8_2" onchange="ChangeValueAddition(this);"
                                                runat="server" Style="width: 80px">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnValueAdditionId8_2" Value="-1" runat="server" />
                                            <br />
                                            <asp:TextBox ID="txtVAWastage8_2" CssClass="do-not-allow-typing VAWastage2" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                            <asp:Label ID="lblVaCurrency8_2" runat="server" Text=""></asp:Label>
                                            <asp:TextBox ID="txtVARate8_2" onblur="javascript:return CalculateValueAddition(this, 'Rate')"
                                                CssClass="numeric-field-with-decimal-places Rate2" BorderStyle="None" runat="server"
                                                Style="width: 30px"></asp:TextBox>
                                        </td>
                                        <td class="gray" valign="top">
                                            <nobr>
                                <asp:Label ID="lblOrigin8" runat="server" CssClass="hid_origin4"></asp:Label>&nbsp;
                              

                                        <div class=" div_show hide_me div_show8" id="divRadioMode8">
                                        <nobr>
                                <input type="radio" name="radioMode8" value="1" class="radio_mode8 radio_mode" title="A"   checked="checked" style="font-size:8px;width:12px;height:12px" />A
                                <input type="radio" name="radioMode8" value="0" class="radio_mode8 radio_mode" title="S"   style="font-size:8px;width:12px;height:12px" />S
                                </nobr>
                                        <asp:HiddenField runat="server" ID="hiddenRadioMode8" Value="1" />
                                    </div>
                                    <br />
                                </nobr>
                                            <div>
                                                <table class="costing-print-table hide_me" id="costing_print_table8" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 2px 0px 0px 0px">
                                                            <div>
                                                                <a title="Print Image" class="thickbox box8" href="/App_Themes/ikandi/images/preview.png">
                                                                    <img id="imgPrint8" src="../../App_Themes/ikandi/images/preview.png" style="height: 38px;
                                                                        width: 38px;" class="costing-print-image8" title="Click to view enlarged image" /></a>
                                                            </div>
                                                            <div style="display: none;">
                                                                <span style='font-size: 10px;'>&nbsp;<asp:TextBox ID="txtPrintId8" runat="server"
                                                                    CssClass="costing-print8 do-not-allow-typing lightbg1" BorderStyle="None" Width="40px"
                                                                    Style="text-align: left"></asp:TextBox>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" rules="all" frame="void" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="15px" colspan="2">
                                                        <a href="#" id="LayFile8" style="display: none;">Browse </a>
                                                        <asp:FileUpload ID="LayFile8" CssClass="lay_file8 style20 ShowHideFile8" runat="server"
                                                            Style="display: none;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15px" width="60px" style="border-right: 0px">
                                                        <asp:Label ID="lblcst8" runat="server" Text="CAD" Style="display: none;" class="gray ShowHideFile8"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="viewolay8" ToolTip="VIEW LAY FILE" runat="server" CssClass="style21 view_lay8 ShowHideFile8"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblcad8" runat="server" Text=" Cut CAD" Style="font-size: 8px; display: none;"
                                                            CssClass="gray ShowHideFile8"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewCad8" ToolTip="VIEW Cut CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile8"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 15px; border-right: 0px">
                                                        <asp:Label ID="lblmarker8" runat="server" Text="Ord CAD" Style="display: none;" CssClass="gray ShowHideFile8"> </asp:Label>
                                                    </td>
                                                    <td style="border-left: 0px">
                                                        <asp:HyperLink ID="ViewStc8" ToolTip="VIEW Ord CAD" runat="server" CssClass="style21 view_lay1 ShowHideFile8"
                                                            Target="_blank" ImageUrl="~/App_Themes/ikandi/images/info.jpg" Text=""></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div class="inches">
                                                <asp:TextBox runat="server" ID="txtWidth8" Width="25px" Font-Size="14px" BorderStyle="None"
                                                    onblur="CalculateCM(this);" MaxLength="6" Style="text-align: center; outline: none;
                                                    color: Black;" CssClass="numeric-field-with-decimal-places costing-landed-costing-inches do-not-allow-typing lightbg1"></asp:TextBox>
                                                <asp:Label ID="lblWidth8" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblWidthCM8" runat="server" Text=""></asp:Label>
                                            cm
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:TextBox runat="server" ID="txtAverage8" Width="55px" Font-Size="Large" BorderStyle="None"
                                                onblur="ChangeRate(this);" onkeypress="return isNumberKeyfloat(event, this);"
                                                MaxLength="6" Style="text-align: center; color: blue; height: 30px;" CssClass="numeric-field-with-three-decimal-places costing-average lightbg1 per textfont boldness"></asp:TextBox><br />
                                            <asp:Label ID="lblAverage8" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalfabric8" runat="server" Style="display: none;"></asp:Label><%--k--%>
                                        </td>
                                        <td class="per" style="display: none;">
                                            <asp:TextBox ID="txtWaste8" runat="server" Width="20px" Font-Size="11px" BorderStyle="None"
                                                Style="pointer-events: none;" CssClass="per costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <div>
                                                <asp:Label ID="lblWaste8" Style="color: black;" runat="server"></asp:Label></div>
                                        </td>
                                        <td style="display: none;">
                                            <asp:TextBox ID="lblRS8" runat="server" Text="0" CssClass="per do-not-allow-typing"></asp:TextBox>
                                        </td>
                                        <td>
                                            <div class="Rupees toptobottom rsicon" style="color: Green !important">
                                                <asp:TextBox runat="server" ID="txtRate8" Font-Size="14px" Width="34px" onblur="ChangeRate(this);"
                                                    ForeColor="Green" onkeypress="return isNumberKeyfloat(event, this);" MaxLength="6"
                                                    BorderStyle="None" CssClass="numeric-field-without-decimal-places costing-rate lightbg1 per-new"></asp:TextBox>
                                                <lable style="display: none"></lable>
                                                <asp:Label ID="lblRate8" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricRate8" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                        </td>
                                        <td class="hide_me lightbg1">
                                            <asp:TextBox runat="server" ID="txtAmount8" Width="30px" BorderStyle="None" CssClass="costing-amount numeric-field-without-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                            <asp:Label ID="lblAmount8" runat="server"></asp:Label>
                                        </td>
                                        <td class="gray" style="display: none;">
                                            <asp:TextBox runat="server" ID="txtTotal8" Width="55px" BorderStyle="None" Font-Size="14px"
                                                Style="color: black;" CssClass="costing-totalFabric do-not-allow-typing lightbg1 text_align_right"></asp:TextBox>
                                            <asp:Label ID="lblTotal8" runat="server"></asp:Label>
                                            <div style="height: 15px;">
                                                <asp:Label ID="lblCCFabricTotal8" runat="server" CssClass="ShowHideCC gray"></asp:Label>
                                            </div>
                                            <div style="padding-top: 4px;">
                                                <asp:TextBox ID="txtTotalAvgWstg8" runat="server" Width="60px" Font-Size="14px" BorderStyle="None"
                                                    CssClass="total-Avg-wst costing-landed-costing-percent lightbg1" Style="color: black;
                                                    display: none; text-align: center;"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="gray fontsize2">
                                            <span class="fa fa-rupee"></span>
                                            <asp:TextBox runat="server" ID="lblTotalPrice8" Width="40px" CssClass="do-not-allow-typing costing-totalPrice fontsize2"
                                                Enabled="false"></asp:TextBox>
                                            <asp:Label ID="lblTPrice8" runat="server"></asp:Label>
                                        </td>
                                        <td class="border_right_color FabricDeleteButton">
                                            <a style="cursor: pointer;" onclick="DeleteFabric(8);">
                                                <img src="../../App_Themes/ikandi/images/deleteIcon.gif" width="10px" alt="Delete Fabric"
                                                    title="Delete Fabric" />
                                            </a>
                                        </td>
                                    </tr>
                                    <%--Total--%>
                                    <tr>
                                        <td colspan="8" style="text-align: right; padding: 10px 0;" class="border_left_color">
                                            <div>
                                                <span style="text-align: right; padding: 5px 20px 5px 0px; font-size: 11px; font-weight: bold;
                                                    color: gray;">Total (A)</span>
                                            </div>
                                        </td>
                                        <td class="fontsize2">
                                            <div style="color: gray">
                                                <strong style=""><span class="fa fa-rupee" style="margin-top: 2px;"></span>
                                                    <asp:TextBox runat="server" ID="txtTotalA" Font-Size="13px" BorderStyle="None" Enabled="false"
                                                        Width="50px" CssClass="costing-total-abc do-not-allow-typing lightbg1 gray fontsize2"
                                                        Style="color: gray !Important; font-weight: bold !important; color: #808080;
                                                        text-align: left;"></asp:TextBox></strong>
                                                <asp:Label ID="lblTotalA" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 15px; display: none;">
                                                <asp:Label ID="lblCCFabricTotal" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                        </td>
                                        <td style="display: none;">
                                            <strong>
                                                <asp:TextBox runat="server" ID="lblTotalPrice" Font-Size="11px" BorderStyle="None"
                                                    CssClass="text_align_right  do-not-allow-typing lightbg1 gray" Style="color: Black !Important;"></asp:TextBox>L</strong>
                                        </td>
                                        <td id="AddFebricbutton" class="border_right_color">
                                            <%--<img src="../../images/add-butt.png" alt="Add Fabric" style="cursor: pointer;" onclick="AddFabric(1);"
                                            title="Add Fabric" border="0" />--%>
                                            <img src="../../App_Themes/ikandi/images/plus.gif" style="cursor: pointer; width: 10px"
                                                alt="Add Fabric" onclick="AddFabric(1);" title="Add Fabric" border="0" /><br />
                                            <asp:Label ID="lblFabricTooltip" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--End FQ--%>
                            <%-- Accessary Quality--%>
                            <br />
                            <table cellpadding="0" cellspacing="0" width="100%" style="position: relative">
                                <tr>
                                    <td style="width: 48%; vertical-align: top;">
                                        <asp:UpdatePanel ID="UpdPnlAccessary" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:HiddenField runat="server" ID="hdnCostingConversionRate" />
                                                <asp:HiddenField ID="hdnDeleteAccessory" runat="server" />
                                                <table width="100%" cellpadding="0" cellspacing="0" border="1" style="border-bottom: none;">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="9" style="border-bottom: none;">
                                                                <h3>
                                                                    Accessory Details (Size) &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    <div class="tooltipRate">
                                                                        <img id="imgtooltip" src="../../images/viewicon.png" runat="server" style="width: 20px"
                                                                            alt="eye icon" />
                                                                        <span class="tooltiptextRate">
                                                                            <h4 style="font-size: 1.2em">
                                                                                Default Guideline:</h4>
                                                                            <h4>
                                                                                Factor1:</h4>
                                                                            <p style="padding-left: 30px;">
                                                                                Check Latest PO Type</p>
                                                                            <p style="padding-left: 30px;">
                                                                                if Finish</p>
                                                                            <p style="padding-left: 60px;">
                                                                                (Max rate of latest 3 PO of finish type</p>
                                                                            <p style="padding-left: 60px;">
                                                                                + apply Max wastage of latest 3 PO applicable</p>
                                                                            <p style="padding-left: 60px;">
                                                                                + Barrier % as applicable)</p>
                                                                            <p style="padding-left: 30px;">
                                                                                Else</p>
                                                                            <p style="padding-left: 60px;">
                                                                                ((Max Latest 3 greige PO Rate + Max latest 3 Process Po rate)</p>
                                                                            <p style="padding-left: 60px;">
                                                                                + apply Max Shrinkage and wastage of latest 3 PO applicable</p>
                                                                            <p style="padding-left: 60px;">
                                                                                + Barrier % as Applicable)</p>
                                                                            <h4>
                                                                                Factor2:</h4>
                                                                            <p style="padding-left: 30px;">
                                                                                Latest Costing Rate for the quality</p>
                                                                            <p style="padding-left: 30px;">
                                                                                We will show the Max of Factor1 vsFactor2 in Rate Accordingly</p>
                                                                        </span>
                                                                    </div>
                                                                    <%-- <div style="color: #575759; float: right; width: auto; padding: 0px 15px; font-size: 11px;">
                                                                <asp:LinkButton ID="lnkAddAccessary" runat="server" Style="color: #575759; text-decoration: none;"
                                                                    ToolTip="Add new item" OnClick="lnkAddAccessary_Click">Add Accessories</asp:LinkButton>
                                                            </div>--%>
                                                                    <h3>
                                                                    </h3>
                                                                    <h3>
                                                                    </h3>
                                                                </h3>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                                <div id="dvBaseSizeRate" class="modal">
                                                    <div id="dvSizeRate" class="modal-content">
                                                    </div>
                                                </div>
                                                <asp:Button ID="btnUpdateAccessoryGrd" CssClass="clsBtnUpdateAccessGrd" runat="server"
                                                    Style="display: none;" Text="Button" OnClick="btnUpdateAccessoryGrd_Click" />
                                                <asp:HiddenField ID="hdnAccDeleteButtonCount" runat="server" />
                                                <asp:GridView ID="gdvAccessory" runat="server" DataKeyNames="AccessoryId" Width="100%"
                                                    GridLines="None" CellPadding="0" ShowFooter="false" AutoGenerateColumns="false"
                                                    ShowHeader="true" Border="1" Style="border-collapse: collapse; border-bottom: #ddd;"
                                                    OnRowDataBound="gdvAccessory_RowDataBound">
                                                    <RowStyle CssClass="gvRow" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr. No." HeaderStyle-Width="8%">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="gray" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSeq" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Item" HeaderStyle-Width="52%" ItemStyle-CssClass="AccTooltipRelative">
                                                            <ItemTemplate>
                                                                <span class="AssRemark">
                                                                    <asp:TextBox ID="txtItems" runat="server" Text='<%# Eval("Item") %>' CssClass="textbox-as-label per text_align_left items "
                                                                        MaxLength="60" onblur="CheckAccessoryName(this)" onclick="PopulateAccessory()"
                                                                        Width="98%"></asp:TextBox></span>
                                                                <asp:HiddenField ID="hdnRemak" runat="server" Value='<%# Eval("remarks") %>' />
                                                                <asp:HiddenField ID="hdnAccessoryQualityID" runat="server" Value='<%# Eval("AccessoryQualityID") %>' />
                                                                <asp:HiddenField ID="hdnDisableAcc" Value='<%# Eval("Disabled_ACC") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnIsDefaultAccessory" Value='<%# Eval("IsDefaultAccessory") %>'
                                                                    runat="server" />
                                                                <asp:HiddenField ID="hdnAccClientId" Value='<%# Eval("ClientId") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnAccParentDeptId" Value='<%# Eval("ParentDepartmentId") %>'
                                                                    runat="server" />
                                                                <asp:HiddenField ID="hdnAccDeptId" Value='<%# Eval("DepartmentId") %>' runat="server" />
                                                                <asp:Label ID="lblItems" Style="float: left;" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Qty. Unit">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtUnitQty" runat="server" Text='<%# Eval("Quantity") != "" ? (Convert.ToDecimal(Eval("Quantity")) <= 0 ? "" : Eval("Quantity")) : "" %>'
                                                                    MaxLength="6" onkeypress="return isNumberKeyfloat(event, this);" onchange="chechZero(this);"
                                                                    Style="text-align: center;" CssClass="textbox-as-label per text_align_right costing-accessories-unitqty"></asp:TextBox>
                                                                <asp:Label ID="lblUnitQty" runat="server"></asp:Label>
                                                                <asp:TextBox ID="lblUnit" runat="server" Text='<%# Eval("Unit")%>' Style="" Visible="false"
                                                                    CssClass="per do-not-allow-typing text_align_left"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("AccessoryQualityID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="lblTotalQuantity" runat="server" Text='<%# Eval("TotalQuantity")%>'
                                                                    CssClass="numeric-field-with-two-decimal-places textbox-as-label do-not-allow-typing text_align_right"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-CssClass="text_align_left" HeaderText="Rate" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <div class="Rupees1 rsicon1" style="color: Green !important;">
                                                                    <!--updated code bharat 1-feb-->
                                                                    <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("Rate")!= "" ? Convert.ToDecimal(Eval("Rate")) <= 0 ? "" : Math.Round(Convert.ToDecimal(Eval("Rate")),2).ToString() : "" %>'
                                                                        MaxLength="5" onblur="ChangeRate(this)" onkeypress="return isNumberKeyfloat(event, this);"
                                                                        Style="width: 70% !important; text-align: left !important; margin-left: 2px"
                                                                        CssClass="textbox-as-label per-new costing-accessories-rate"></asp:TextBox>
                                                                    <lable style="display: none"></lable>
                                                                </div>
                                                                <asp:Label ID="lblRate" runat="server"></asp:Label>
                                                                <asp:Label ID="lblCCAccRate" runat="server" CssClass="ShowHideCC gray AccRate" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="lblWastage" runat="server" Text='<%# Eval("Wastage") != "" ? (Convert.ToDecimal(Eval("Wastage")) <= 0 ? "" : Eval("Wastage")) : "" %>'
                                                                    CssClass="per textbox-as-label costing-accessories-wastage"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-CssClass="text_align_left" HeaderText="Tot Amt." HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <div class="gray">
                                                                    &nbsp;<span class="fa fa-rupee" style="font-size: 10px;"></span>
                                                                    <asp:TextBox ID="lblTotalAmount" onblur="ChangeRate(this)" runat="server" Text='<%# Eval("Amount") != "" ? Convert.ToDecimal(Eval("Amount")) <= 0 ? "" : Convert.ToDecimal(Eval("Amount")).ToString() : "" %>'
                                                                        Style="width: 65% !important; text-align: left;" onkeypress="return isNumberKeyfloat(event, this);"
                                                                        CssClass="do-not-allow-typing gray numeric-field-with-decimal-places costing-accessories-amount text_align_right"></asp:TextBox>
                                                                </div>
                                                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                <asp:Label ID="lblCCTotalAmount" runat="server" CssClass="ShowHideCC gray AccTotalAmount"
                                                                    Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="lblTotalPriceAcc" runat="server" Text='<%# Eval("TotalPrice") != "" ? (Convert.ToDecimal(Eval("TotalPrice")) <= 0 ? "" : Eval("TotalPrice")) : "" %>'
                                                                    CssClass="do-not-allow-typing costing-accessories-price gray text_align_right"></asp:TextBox>
                                                                <span class="gray">k</span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Act" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="AccessoryDeleteButton">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtndelete" runat="server" ToolTip="Delete Accessory" ImageUrl="../../App_Themes/ikandi/images/deleteIcon.gif"
                                                                    Width="10px" OnClientClick="return confirm('Are you sure to delete the current record?');"
                                                                    CausesValidation="false" OnClick="imgBtndelete_Click" border="0" Style="margin: 0 auto;" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="LinkButton1" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <table width="100%" cellpadding="0" cellspacing="0" border="1" style="border-top: 0px;
                                            border-collapse: collapse;">
                                            <tr style="border-bottom: 1px solid #999999;">
                                                <td style="text-align: right; padding: 7px 0; width: 78.5%;">
                                                    <span style="text-align: right; padding: 5px 10px 5px 0px; font-size: 11px; font-weight: bold;
                                                        color: gray;">Total (C)</span>
                                                </td>
                                                <td style="text-align: left; font-weight: bold; width: 9.8%;">
                                                    <div style="color: gray">
                                                        &nbsp;<span class="fa fa-rupee" style="font-size: 11px"></span>
                                                        <asp:TextBox ID="lblTotalAmountC" runat="server" disabled Text="" CssClass="do-not-allow-typing text_align_left costing-total-abc boldness"
                                                            Style="width: 65% !important; font-weight: bold; color: #808080"> </asp:TextBox>
                                                        <asp:Label ID="lblCCTotalC" runat="server" CssClass="ShowHideCC gray"></asp:Label>
                                                    </div>
                                                    <asp:Label ID="lblTotalC" runat="server"></asp:Label>
                                                    <asp:TextBox ID="lblTotalPriceC" runat="server" Text="" CssClass="do-not-allow-typing text_align_right"
                                                        Style="display: none;"> </asp:TextBox>
                                                </td>
                                                <td id="AssoriesPlus" style="width: 5%;">
                                                    <asp:ImageButton ID="LinkButton1" runat="server" Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/plus.gif"
                                                        Width="10px" Height="10px" ToolTip="Add Accessories" OnClick="lnkAddAccessary_Click">
                                                    </asp:ImageButton><br />
                                                    <asp:Label ID="lblAccessoryTooltip" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 1%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 50%; vertical-align: top;">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="100%" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="1" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th colspan="4">
                                                                    <h3>
                                                                        CMT Details</h3>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <th width="105">
                                                                    OB File
                                                                </th>
                                                                <th width="45" style="">
                                                                    <asp:HyperLink ID="hlinkSAM" ToolTip="VIEW OB SHEET" Visible="true" runat="server"
                                                                        CssClass="" Target="_blank" Text="SAM" Font-Bold="true" Style="color: blue !important;
                                                                        text-decoration: none;"></asp:HyperLink>
                                                                </th>
                                                                <th width="45">
                                                                    OB W/S
                                                                </th>
                                                                <th width="40">
                                                                    CMT
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td width="105">
                                                                    <a href="#" id="upfile1" style="cursor: pointer">Browse </a>
                                                                    <asp:FileUpload ID="uploadob" runat="server" Style="font-size: 10px; width: 71px;
                                                                        display: none;" />
                                                                    <asp:HyperLink ID="hypviewObfile" Visible="false" Style="cursor: pointer; vertical-align: top;"
                                                                        runat="server" Width="12" ToolTip="View OB file" CssClass="view-image" Target="_blank"
                                                                        ImageUrl="~/images/view-icon.png" Text=""></asp:HyperLink>
                                                                </td>
                                                                <td width="40">
                                                                    <asp:TextBox ID="txtChargesValue11" onchange="GetCMTValue(); chechZero(this);" runat="server"
                                                                        MaxLength="4" onkeypress="return isNumberKeyfloat(event, this);" class="numeric-field-with-one-decimal-places darkbg1"
                                                                        RegularExpression="^[0-9.\-]+$" Text="" Font-Bold="true" Height="16px" Style="border: 1px solid #c3c3c3;
                                                                        background: #fefefe; margin-bottom: 0px; border-radius: 3px;"></asp:TextBox>
                                                                    <asp:Label ID="lblChargesValue11" runat="server"></asp:Label>
                                                                </td>
                                                                <td width="40">
                                                                    <asp:TextBox ID="txtOB" onchange="GetCMTValue(); chechZero(this);" runat="server"
                                                                        Height="16px" MaxLength="3" class="numeric-field-without-decimal-places darkbg1"
                                                                        Text="" Style="font-weight: bold; border: 1px solid #c3c3c3; color: #000; background: #fefefe;
                                                                        border-radius: 3px;"></asp:TextBox>
                                                                    <asp:Label ID="lblOB" runat="server"></asp:Label>
                                                                </td>
                                                                <td width="40" class="text_align_left">
                                                                    <div class="gray prosessamount">
                                                                        &nbsp;<span class="fa fa-rupee" style="font-size: 10px;"></span>
                                                                        <asp:TextBox runat="server" CssClass="costing-charges-value numeric-field-without-decimal-places lightbg1"
                                                                            onchange="checkMinCmt(this); chechZero(this);" ID="txtChargesValue1" Width="40px"
                                                                            ForeColor="black" BorderStyle="None" Style="text-align: center; font-weight: bold;"
                                                                            MaxLength="5"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label ID="lblChargesValue1" runat="server"></asp:Label>
                                                                    &nbsp;<asp:Label ID="lblCCChargesValue1" runat="server" CssClass="ShowHideCC gray"></asp:Label>
                                                                    <asp:HiddenField ID="hdnAch" runat="server" />
                                                                    <asp:HiddenField ID="hdnMinCMT" runat="server" />
                                                                    <asp:HiddenField ID="hdnOBCount" Value="0" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="text-align: right; height: 27px; padding-right: 5px; font-size: 11px;
                                                                    font-weight: bold; color: gray;">
                                                                    Total (B)
                                                                </td>
                                                                <td style="text-align: left; height: 16px; font-weight: bold;">
                                                                    <div class="prosessamount gray" style="top: 0;">
                                                                        &nbsp;<span class="fa fa-rupee" style="font-size: 11px;"></span>
                                                                        <asp:TextBox ID="lblTotalAmountB" disabled runat="server" Text="" CssClass="do-not-allow-typing costing-total-abc text_align_left boldness"
                                                                            Style="width: 40px; text-align: center !important; font-weight: bold !important;
                                                                            color: #808080"> </asp:TextBox>
                                                                        &nbsp;<asp:Label ID="lblCCTotalAmountB" runat="server" CssClass="ShowHideCC gray"></asp:Label></div>
                                                                    <asp:Label ID="lblTotalB" Style="float: right;" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="margin: 20px 0;">
                                            <tr>
                                                <td width="100%" style="margin: 10px 0;">
                                                    <a class="sample-image">
                                                        <img id="imgSampleImageUrl1" runat="server" src="../../App_Themes/ikandi/images/preview.png"
                                                            style="max-width: 100%; max-height: 150px; height: 150px;" />
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:UpdatePanel ID="UpdPnlProcess" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:HiddenField ID="hdnDeleteProcess" runat="server" />
                                                <table width="100%" cellpadding="0" cellspacing="0" border="1" style="border-bottom: none;">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="6" style="border-bottom: none;">
                                                                <h3>
                                                                    Process Details
                                                                </h3>
                                                                <%--<div style="color: #575759; float: right; width: auto; padding: 0px 15px; font-size: 11px;">
                                                                <asp:LinkButton ID="lnkAddProcess" runat="server" Style="color: #575759; text-decoration: none;"
                                                                    ToolTip="Add new item" OnClick="lnkAddProcess_Click">Add Process</asp:LinkButton>
                                                            </div>--%>
                                                            </th>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <th width="7%">
                                                                Sr. No.
                                                            </th>
                                                            <th width="27%">
                                                                Item
                                                            </th>
                                                            <th width="19%">
                                                                From status
                                                            </th>
                                                            <th width="19%">
                                                                To status
                                                            </th>
                                                            <th width="21%">
                                                                Amount
                                                            </th>
                                                            <th width="7%">
                                                                Action
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                                <asp:HiddenField ID="hndProDeleteButton" runat="server" />
                                                <asp:GridView ID="gvdProcessDetails" runat="server" DataKeyNames="ProcessCostingId"
                                                    Width="100%" GridLines="None" CellPadding="0" ShowFooter="false" AutoGenerateColumns="false"
                                                    ShowHeader="true" Border="1" Style="border-collapse: collapse; border-bottom: #ddd;
                                                    border-top: 0px !important;">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr. No.">
                                                            <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="gray" />
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="27%" HeaderText="Item">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtPItems" runat="server" ToolTip='<%# Eval("Item") %>' Text='<%# Eval("Item") %>'
                                                                    onblur="CheckProcessName(this)" CssClass="textbox-as-label alin per process-items"
                                                                    Width="80%"></asp:TextBox>
                                                                <asp:Label ID="lblPItems" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnValueAdditionID" runat="server" Value='<%# Eval("ValueAdditionID") %>' />
                                                                <asp:HiddenField ID="hdnCostingVAWastage" runat="server" Value='<%# Eval("CostingVAWastage") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="From <br />status">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFromStatus" runat="server" Text='<%# Eval("FromStatus")%>' CssClass=" gray do-not-allow-typing text_align_left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="To <br />status">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtToStatus" runat="server" Text='<%# Eval("ToStatus")%>' CssClass=" gray do-not-allow-typing text_align_left"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Rate">
                                                            <ItemTemplate>
                                                                <div class="Rupees" style="color: Green !important;">
                                                                    <span class="fa fa-rupee" style="top: 20% !important; font-size: 10px; left: 20% !important;"
                                                                        title=""></span>
                                                                    <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("Rate") != "" ? (Convert.ToDecimal(Eval("Rate")) <= 0 ? "" : Eval("Rate")) : "" %>'
                                                                        onblur="ChangeRate(this)" Style="text-align: center !important;" MaxLength="8"
                                                                        onkeypress="return isNumberKeyfloat(event, this);" CssClass="  costing-process-amount  text_align_left numeric-field-with-decimal-places"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="8%" HeaderText="Wast<br />age %">
                                                            <ItemTemplate>
                                                                <div class="Rupees" style="color: Green !important;">
                                                                    <asp:TextBox ID="txtWastage" runat="server" Text='<%# Eval("Wastage") != "" ? (Convert.ToDecimal(Eval("Wastage")) <= 0 ? "" : Eval("Wastage")) : "" %>'
                                                                        onblur="ChangeRate(this)" Style="text-align: center !important;" onkeypress="return isNumberKeyfloat(event, this);"
                                                                        CssClass="  costing-process-amount  text_align_left numeric-field-with-decimal-places"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="12%" ItemStyle-CssClass="text_align_left" HeaderText="Amount">
                                                            <ItemTemplate>
                                                                <div class="gray prosessamount" style="padding-left: 8px;">
                                                                    <span class="fa fa-rupee" style="font-size: 10px;"></span>
                                                                    <asp:TextBox ID="lblTotalAmount" Style="width: 60% !important; text-align: left"
                                                                        runat="server" Text='<%# Eval("Amount") != "" ? Convert.ToDecimal(Eval("Amount")) <= 0 ? "": Eval("Amount"):"" %>'
                                                                        CssClass="gray text_align_left textbox-as-label do-not-allow-typing"></asp:TextBox>
                                                                </div>
                                                                <asp:Label ID="lblTAmount" runat="server" CssClass="numeric-field-with-decimal-places"></asp:Label>
                                                                &nbsp;<asp:Label ID="lblAccCCTotalAmount" runat="server" CssClass="ShowHideCC gray"
                                                                    Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="5%" FooterStyle-Width="5%" HeaderText="Action">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ProcessimgBtndelete" runat="server" ToolTip="Delete Process"
                                                                    ImageUrl="../../App_Themes/ikandi/images/deleteIcon.gif" Width="10px" OnClientClick="return confirm('Are you sure to delete the current record?');"
                                                                    OnClick="ProcessimgBtndelete_Click" CausesValidation="false" border="0" /><br />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ImageButton1" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <table width="100%" cellpadding="0" cellspacing="0" border="1" style="border-top: 0px;
                                            border-collapse: collapse;">
                                            <tr style="border-bottom: 1px solid #999999;">
                                                <td width="80%" style="text-align: right; padding: 7px 5px;">
                                                    <span style="font-size: 11px; font-weight: bold; color: gray;">Total (D)</span>
                                                </td>
                                                <td width="13.5%" style="height: 16px; font-weight: bold;">
                                                    <span class="fa fa-rupee" style="font-size: 11px; color: gray"></span>
                                                    <asp:TextBox ID="lblTotalAmountD" runat="server" disabled Text="" CssClass="do-not-allow-typing text_align_right costing-total-abc boldness"
                                                        Style="width: 50px; font-weight: bold; text-align: left; color: #808080"> </asp:TextBox>
                                                    <asp:Label ID="lblTotalD" runat="server"></asp:Label>
                                                    <asp:Label ID="lblCCTotalD" runat="server" CssClass="ShowHideCC gray"></asp:Label>
                                                </td>
                                                <td width="5.5%">
                                                    <asp:ImageButton ID="ImageButton1" runat="server" Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/plus.gif"
                                                        Width="10px" Height="10px" ToolTip="Add Process" OnClick="lnkAddProcess_Click">
                                                    </asp:ImageButton><br />
                                                    <asp:Label ID="lblProcessTooltip" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:UpdatePanel ID="UpdtpnlSave" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div id="divConfirmBox" runat="server" class="modal2">
                                                    <div id="divConfirmBoxDetails" class="modal-content2">
                                                        <div style="background: #39589c; color: #fff; margin-bottom: 5px; height: 20px">
                                                            <span style="float: right; padding-right: 5px;"><a href="javascript:void(0)" style="cursor: pointer;
                                                                float: right; width: auto; color: #fff; text-decoration: none;" onclick="closedivConfirmBox();">
                                                                <span style="font-weight: bold;">X</span></a> </span>
                                                        </div>
                                                        <div style="margin-bottom: 8px;">
                                                            <span style="font-size: 13px; font-weight: 600">Do you want to still.</span></div>
                                                        <%--<asp:Button ID="btnOpenCosting" runat="server" CssClass="do-not-print da_submit_button" Text="Open Agreement" OnClick="btnOpenCosting_Click" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnAcceptClose" runat="server" CssClass="do-not-print da_submit_button" Text="Accept and Close Agreement" OnClick="btnAcceptClose_Click" />--%>
                                                    </div>
                                                </div>
                                                <table border="0" width="100%" cellpadding="5" cellspacing="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="100%" valign="top" style="text-align: left; padding-top: 7px; padding-left: 0px;">
                                                                <asp:HiddenField ID="hdnSave" Value="0" runat="server"></asp:HiddenField>
                                                                <asp:HiddenField ID="hdnClientCostingSave" Value="0" runat="server"></asp:HiddenField>
                                                                <asp:Button ID="btnSave" runat="server" OnClientClick="javascript:return SAM();"
                                                                    OnClick="btnSave_Click" CssClass="do-not-print da_submit_button m-r-5" Text="Save" />
                                                                <asp:Button ID="btnSaveConfirm" runat="server" OnClientClick="javascript:return SAM();"
                                                                    OnClick="btnSaveConfirm_Click" CssClass="do-not-print da_submit_button m-r-5"
                                                                    Text="Save" />
                                                                <asp:Button ID="btnOpenCosting" runat="server" CssClass="do-not-print da_submit_button"
                                                                    Text="Save and Open Agreement" OnClientClick="javascript:return IsPriceQuoteBlank();"
                                                                    OnClick="btnOpenCosting_Click" />
                                                                <asp:Button ID="btnAcceptClose" runat="server" CssClass="do-not-print da_submit_button"
                                                                    Text="Accept and Close Agreement" OnClientClick="javascript:return IsPriceQuoteBlank();"
                                                                    OnClick="btnAcceptClose_Click" />
                                                                <%--&nbsp;--%>
                                                                <%-- <asp:Button runat="server" ID="btnExportToExcel" CssClass="exporttoexcel" OnClick="btnExportToExcel_Click"
                                        OnClientClick="JavaScript:return ExportToExcel()" Visible="true" />--%>
                                                                <%-- <asp:Button runat="server" ID="btnBIPLPrint" class="print do-not-print" OnClientClick="return PrintPDF();return false;" />
                                    &nbsp;--%>
                                                                <asp:Button ID="btnCostConfirmation" Visible="false" runat="server" OnClientClick="return confirm('Are you sure you want to send request to confirm the price?')"
                                                                    OnClick="btnCostConfirmation_Click" CssClass="da_submit_button m-r-5" Text="Request Cost Confirmation" />
                                                                <asp:Button ID="btnAcknowledgment" Style="display: none;" runat="server" CssClass="ucknowledgment_confirmation do-not-print m-r-5"
                                                                    OnClick="btnAcknowledgment_Click" />
                                                                <asp:Button ID="btnAgree" runat="server" OnClick="btnAgree_Click" Text="Accept and Close Agreement"
                                                                    CssClass="agree da_submit_button m-r-5" />
                                                                <asp:Button ID="btnDisagree" runat="server" OnClick="btnDisagree_Click" Text="Disagree"
                                                                    CssClass="disagree da_submit_button m-r-5" Visible="false" />
                                                                <asp:Button ID="btnUpdatePrice" Visible="false" runat="server" OnClientClick="return confirm('Are you sure you want to update the price on orders?')"
                                                                    OnClick="btnBIPLUpdatePrice_Click" CssClass="do-not-print da_submit_button m-r-5"
                                                                    Text="Update Order Price" />
                                                                <asp:Button runat="server" ID="btnBIPLHistory" CssClass="do-not-print da_submit_button m-r-5"
                                                                    Text="History" OnClientClick="showHistory( this, 'divBIPLHistory'); return false;" />
                                                                <br />
                                                                <br />
                                                                <asp:Label CssClass="button_style" runat="server" ID="lblCostConfirmationRequestText"
                                                                    Visible="false "></asp:Label>
                                                                <asp:Label ID="LblCostingMsg" runat="server" Font-Size="small" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnOpenCosting" />
                                                <asp:PostBackTrigger ControlID="btnAcceptClose" />
                                                <asp:PostBackTrigger ControlID="btnSave" />
                                                <asp:PostBackTrigger ControlID="btnUpdatePrice" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <%--End AQ--%>
                        </td>
                        <td valign="top" width="30%">
                            <%-- Second TD--%>
                            <!------------------top-section---------->
                            <div style="width: 100%;">
                                <!----- Financial Section---->
                                <div style="width: 100%">
                                    <table width="100%" cellpadding="0" cellspacing="0" border="1" class="financial">
                                        <thead>
                                            <tr>
                                                <th colspan="2">
                                                    <h3 style="margin: 4px 0px">
                                                        Financial
                                                    </h3>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td width="55%" class="gray">
                                                    A+B+C+D
                                                </td>
                                                <td width="40%" class="gray">
                                                    <span class="fa fa-rupee" style="color: green"></span>
                                                    <asp:TextBox runat="server" ID="txtTotalABC" Width="50px" disabled BorderStyle="None"
                                                        CssClass="costing-final-cost do-not-allow-typing lightbg1" Style="color: Black;
                                                        text-align: left;"></asp:TextBox>
                                                    <asp:Label ID="lblTotalABC" Style="float: left;" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    <%--Freight & Platform--%>
                                                    Customs, Doc & Platform
                                                </td>
                                                <td class="gray">
                                                    <span class="fa fa-rupee" style="color: green;"></span>
                                                    <asp:TextBox runat="server" ID="txtFrtUptoFinalDest" MaxLength="2" Width="30px" BorderStyle="None"
                                                        CssClass="costing-final-cost text_align_right do-not-allow-typing" Style="text-align: left;"></asp:TextBox>
                                                    <asp:Label ID="lblFrtUptoFinalDest" Style="float: left;" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    Gmt. Cut Wastage & Other Samples
                                                </td>
                                                <td class="per onlypercent_sign">
                                                    <asp:TextBox runat="server" ID="txtGCW" Width="25px" MaxLength="3" onblur="ChangeRate(this)"
                                                        onKeyDown="return false" BorderStyle="None" CssClass="costing-final-cost numeric-field-with-decimal-places costing-landed-costing-percent per outline_none"></asp:TextBox>
                                                    <asp:Label ID="lblGCW" Style="float: left;" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    Gmt. VA Wastage
                                                </td>
                                                <td class="per onlypercent_sign">
                                                    <asp:TextBox runat="server" ID="txtGVW" Width="25px" onblur="ChangeRate(this)" MaxLength="3"
                                                        BorderStyle="None" CssClass="costing-final-cost costing-landed-costing-percent per outline_none"></asp:TextBox>
                                                    <asp:Label ID="lblGVW" Style="float: left;" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    Overhead
                                                </td>
                                                <td class="per">
                                                    <%--<asp:TextBox ID="txtOverHead" runat="server" MaxLength="2" Width="25px" BorderStyle="None"
                                                        CssClass="costing-final-cost do-not-allow-typing"></asp:TextBox>--%>
                                                    <span class="fa fa-rupee" style="color: green" title=""></span>
                                                    <asp:TextBox ID="txtOverHead" runat="server" MaxLength="2" Width="25px" BorderStyle="None"
                                                        CssClass="costing-final-cost do-not-allow-typing text_align_left"></asp:TextBox>
                                                    <span id="percentsign"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="tdDC" runat="server" style="display: none" class="gray">
                                                    D.C
                                                </td>
                                                <td style="display: none" class="per" id="tdDCValue" runat="server">
                                                    <asp:TextBox ID="txtDesingCommission" Style="color: black;" runat="server" Text="0.00"
                                                        Width="60px" BorderStyle="None" CssClass="numeric-field-with-two-decimal-places costing-on-unit-commission costing-landed-costing-percent text_align_right per"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    <asp:TextBox runat="server" ID="txtUnitCtcInForeignCurr" onblur="ChangeRate(this)"
                                                        BorderStyle="None" CssClass="costing-final-total costing-on-unit-ctc do-not-allow-typing lightbg1"
                                                        Style="display: none;"></asp:TextBox>
                                                    Profit
                                                </td>
                                                <td bgcolor="#99CC00">
                                                    <asp:TextBox runat="server" ID="txtMarkupOnUnitCtc" MaxLength="5" Width="22px" BorderStyle="None"
                                                        CssClass="form_small_heading_green costing-final-total numeric-field-with-decimal-places costing-landed-costing-percent boldness"
                                                        Style="text-align: center; color: black; background: #99CC00 !important"></asp:TextBox>
                                                    <asp:Label ID="lblMarkupOnUnitCtc" Style="float: left;" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    Commission
                                                </td>
                                                <td class="per">
                                                    <asp:TextBox runat="server" ID="txtComm" onblur="ChangeRate(this)" MaxLength="2"
                                                        Style="color: black;" Width="22px" BorderStyle="None" CssClass="costing-final-total costing-on-unit-ctc numeric-field-with-decimal-places costing-landed-costing-percent lightbg1 per"></asp:TextBox>
                                                    <asp:Label ID="lblComm" Style="float: left;" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    Currency(Conv.Rate)
                                                </td>
                                                <td style="padding-left: 1px;">
                                                    <asp:DropDownList ID="ddlConvTo" runat="server" Width="40px" CssClass="currChange IsChangeQuo converto lightbg1"
                                                        onChange="CurrencyChange()" Style="color: black; cursor: pointer;">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnConvertTo" Value="-1" runat="server" />
                                                    &nbsp;<span class="gray"> <span class="fa fa-rupee" style="color: green"></span>
                                                        <%--<asp:TextBox runat="server" ID="txtConvRate" Width="30px" BorderStyle="None" CssClass="costing-final-cost-ctc do-not-allow-typing"
                                                        Style="text-align: left; font-weight: bold;"></asp:TextBox></span>--%>
                                                        <asp:TextBox runat="server" ID="txtConvRate" Width="30px" BorderStyle="None" CssClass="costing-final-cost-ctc numeric-field-without-decimal-places gray"
                                                            onblur="ConversionRateValidation(this)" Style="text-align: left; font-weight: bold;"></asp:TextBox></span>
                                                    <asp:HiddenField runat="server" ID="hdnConvRate" />
                                                    <asp:HiddenField runat="server" ID="hdnConvernew" />
                                                    <asp:HiddenField runat="server" ID="hdnfromvari" Value="0" />
                                                    <asp:HiddenField runat="server" ID="hdntovari" Value="0" />
                                                    <asp:HiddenField runat="server" ID="hdnIsPricequoted" Value="0" />
                                                    <asp:Label ID="lblConvRate" Style="float: left; margin-left: 20px;" runat="server"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtInitCtcInInr" Width="41px" MaxLength="5" BorderStyle="None"
                                                        Style="display: none;" class="costing-final-cost-ctc do-not-allow-typing currChange lightbg1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    Calculated Price
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtTotal" disabled Width="70%" BorderStyle="None"
                                                        CssClass="do-not-allow-typing text_align_right gray" Style="text-align: left;
                                                        color: #000000; font-weight: bold; margin-left: 3px;"></asp:TextBox>
                                                    <asp:Label ID="lblTotal" Style="float: left;" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    Price Quoted
                                                </td>
                                                <td bgcolor="#ffffaa" style="color: red">
                                                    <asp:TextBox ID="txtPriceQuoted" onblur="ChangeRate(this)" runat="server" MaxLength="5"
                                                        BorderStyle="None" Width="70%" Style="text-align: left; margin-left: 3px; background: #ffffaa !important;
                                                        color: red; font-weight: 600" CssClass='<%# (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.COSTING_PRICE_QUOTED))
                                              ? "form_small_heading_yellow costing-price-quoted AddClsssCha red_center_text costing-landed-costing-penny costing-on-unit-ctc PriceQuoteCurrency numeric-field-with-two-decimal-places" : "form_small_heading_yellow costing-price-quoted red_center_text costing-landed-costing-penny PriceQuoteCurrency costing-on-unit-ctc numeric-field-with-two-decimal-places do-not-allow-typing currChange" %>'></asp:TextBox>
                                                    <asp:HiddenField ID="hdnPriceQuoted" Value="0" runat="server" />
                                                    <asp:Label ID="lblPriceQuoted" Style="float: left;" runat="server" Height="16px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="gray">
                                                    <a rel="shadowbox;" href="javascript:void(0)" onclick='return OpenGetLP(this);' style="cursor: pointer;
                                                        float: left; width: auto; text-decoration: none;">Last Order Price </a>
                                                </td>
                                                <td bgcolor="#99CC00">
                                                    <span runat="server" id="CurrencySymbol" class="" title=""></span>
                                                    <asp:TextBox runat="server" ID="txtPriceAgreed" Width="70%" BorderStyle="None" ReadOnly
                                                        Style="text-align: left; color: Black !important; margin-left: 3px; background-color: #99CC00 !important"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trLP" runat="server" visible="false">
                                                <td class="gray">
                                                    <a rel="shadowbox;" href="javascript:void(0)" onclick='return OpenGetLP(this);' style="cursor: pointer;
                                                        float: left; width: auto; text-decoration: none;">
                                                        <asp:Label ID="Label1" runat="server" ToolTip="Last Price" Style="color: blue;" Text="LP"></asp:Label>
                                                    </a>
                                                </td>
                                                <td bgcolor="#99cc006e">
                                                    <asp:TextBox runat="server" ID="txtLastPrice" Width="70%" BorderStyle="None" CssClass="form_small_heading_green LpCurrency costing-landed-costing-penny costing-on-unit-ctc costing-percentage-profit do-not-allow-typing CurrencySymbol  numeric-field-with-two-decimal-places"
                                                        Style="text-align: left; color: Black !important; margin-left: 3px; background-color: transparent !important"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <!------End--->
                            </div>
                            <br />
                            <div id="divIKandi" runat="server">
                                <style>
                                    .grdLandedCostingTr
                                    {
                                        display: block;
                                        float: left;
                                        min-width: 90px;
                                        width: 100%;
                                    }
                                    
                                    .grdLandedCostingTh
                                    {
                                        width: 88px;
                                        height: 12px;
                                        text-align: left;
                                        padding-left: 5px;
                                        background-color: #dddfe4 !important;
                                        color: #747474 !important;
                                        border-color: #ede6e6;
                                        font-size: 9px;
                                    }
                                    
                                    .grdLandedCostingTr .grdLandedCostingTd:first-child
                                    {
                                        border-bottom: 0;
                                        border-right: 0;
                                        border-top: 2px solid gray;
                                    }
                                    .grdDirectCostingTr .grdDirectCostingTd:first-child
                                    {
                                        border-bottom: 0;
                                        border-right: 0;
                                    }
                                    
                                    
                                    .grdLandedCostingTh, .grdLandedCostingTd
                                    {
                                        display: block;
                                        padding: 5px 0px !important;
                                        font-size: 9px;
                                        height: 12px;
                                    }
                                    
                                    
                                    .grdDirectCostingTr
                                    {
                                        display: block;
                                        float: left;
                                        min-width: 108px;
                                        width: 100%;
                                    }
                                    .grdDirectCostingTr:first-child
                                    {
                                        max-width: 88px;
                                    }
                                    .grdDirectCostingTh
                                    {
                                        width: 106px;
                                        height: 10px;
                                        text-align: left;
                                        padding-left: 5px;
                                        background-color: #dddfe4 !important;
                                        color: #747474 !important;
                                        border-color: #ede6e6;
                                        font-size: 9px;
                                    }
                                    .grdDirectCostingTh:first-child
                                    {
                                        border-top: 0;
                                    }
                                    .grdDirectCostingTd
                                    {
                                        height: 10px;
                                        font-size: 9px;
                                    }
                                    .grdDirectCostingTh, .grdDirectCostingTd
                                    {
                                        display: block;
                                        padding: 5px 0px !important;
                                    }
                                    
                                    .grdLandedCostingTd select
                                    {
                                        width: 80%;
                                        text-align: center;
                                        font-size: 9px;
                                    }
                                    .grdLandedCostingTd input
                                    {
                                        margin-left: 0px;
                                        text-align: center;
                                        font-size: 9px;
                                        margin-top: 0px;
                                    }
                                    .grdDirectCostingTd input
                                    {
                                        margin-top: 0px;
                                        font-size: 9px;
                                    }
                                    
                                    .CostingTableBody
                                    {
                                        display: flex;
                                    }
                                    .landedCosting_wrapper
                                    {
                                        max-width: 542px;
                                        overflow-x: scroll;
                                        position: relative;
                                    }
                                    .landedCosting_wrapper::-webkit-scrollbar-track
                                    {
                                        -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.1);
                                        border-radius: 10px;
                                        height: 7px;
                                    }
                                    
                                    .landedCosting_wrapper::-webkit-scrollbar
                                    {
                                        height: 7px;
                                        background-color: #39589c;
                                        border-radius: 10px;
                                    }
                                    .landedCosting_wrapper::-webkit-scrollbar-thumb
                                    {
                                        background-color: #dddfe4;
                                    }
                                    .landedCosting_wrapper::-webkit-scrollbar-thumb:hover
                                    {
                                        border-radius: 10px;
                                        background-color: #99cc00;
                                        background-image: -webkit-linear-gradient(top, #99cc00 0%,#39589c 100%,);
                                    }
                                    .CostingTableBody .grdLandedCostingTr:first-child
                                    {
                                        position: sticky;
                                        left: 0;
                                        max-width: 85px;
                                    }
                                    .CostingTableBody .grdLandedCostingTr:last-child, .CostingTableBody .grdDirectCostingTr:last-child
                                    {
                                        border-right: 1px solid #cdcdcd;
                                    }
                                    .CostingTableBody .grdDirectCostingTr:first-child
                                    {
                                        position: sticky;
                                        left: 0;
                                    }
                                    .costing-iframe
                                    {
                                        height: 100vh !important;
                                    }
                                </style>
                                <div class="form_box" style="border-color: #999 !important; margin-bottom: 7px;">
                                    <asp:HiddenField ID="hdnIS_AF" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnIS_AH" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnIS_SF" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnIS_SH" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnIS_DC" runat="server" Value="0" />
                                    <h3 style="background: #dddfe4  none repeat scroll 0 0; color: #575759; font-family: arial,halvetica;
                                        font-size: 13px; font-weight: bold; width: 97.7%; text-align: center; padding: 5px;
                                        border: 1px solid #bbbaba; border-bottom: 0;">
                                        B.H Costing Sheet
                                    </h3>
                                    <!-- direct costing sheet-->
                                    <table style="width: 99.9%;">
                                        <thead>
                                            <tr>
                                                <th colspan="9" style="border: 1px solid #b1b1b1; border-bottom: 0; padding: 0!important;">
                                                    <h4 style="background: #dddfe4  none repeat scroll 0 0; color: #575759; font-family: arial,halvetica;
                                                        font-size: 13px; font-weight: bold; width: 100%; text-align: center; padding: 3px;
                                                        margin: 0; box-sizing: border-box;">
                                                        Direct Costing
                                                    </h4>
                                                </th>
                                            </tr>
                                        </thead>
                                    </table>
                                    <div class="landedCosting_wrapper">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);
                                            color: Gray;">
                                            <tbody id="tbodyDirectCosting">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdDirectCosting" runat="server" Width="100%" ClientIDMode="Static"
                                                            GridLines="None" CellPadding="0" ShowFooter="false" AutoGenerateColumns="false"
                                                            ShowHeader="true" Border="1" Style="border-collapse: collapse; border-bottom: #ddd;
                                                            border-color: #f3ebeb; border-left: 0px; border-right: 0px;">
                                                            <RowStyle CssClass="grdDirectCostingTr" />
                                                            <HeaderStyle CssClass="grdDirectCostingTr" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Mode" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="#b9b1b1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMode" runat="server" CssClass="lightbluebgcolor" Text='<%# Eval("Code") %>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnModeId" runat="server" Value='<%# Eval("ModeId") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;BIPL Price">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtFobBoutique" BorderStyle="None" Width="30px" Text='<%# Eval("FOBDelhi") %>'
                                                                            CssClass="costing-landed-costing-penny costing-fob-boutique-price do-not-allow-typing lightbg1"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Haulage Charge">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtHaulage" MaxLength="5" Text='<%# Eval("HaulageCharges") %>'
                                                                            BorderStyle="None" Width="30px" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total2 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Margin">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" MaxLength="5" ID="txtMargin" Width="30px" Text='<%# Eval("FOBMargin") %>'
                                                                            BorderStyle="None" CssClass="per numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-fob-margin costing-landed-costing-grand-total2 lightbg1"
                                                                            Style="margin-left: 15px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Disc.">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtDiscount" Text='<%# Eval("Discount") %>' BorderStyle="None"
                                                                            MaxLength="5" Width="30px" CssClass="per numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total2 costing-landed-costing-discount lightbg1"
                                                                            Style="margin-left: 12px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Calc. Total" ItemStyle-BackColor="#f9ddf4">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtGrandTotal" Text='<%# Eval("GrandTotal") %>' BorderStyle="None"
                                                                            CssClass="do-not-allow-typing costing-landed-costing-penny" Style="background-color: #F9DDF4 !important;
                                                                            width: 30px; text-align: left; margin-left: 4px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Quoted" ItemStyle-BackColor="#ffffaa">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtQuotedPrice" Text='<%# Eval("QuotedPrice") %>'
                                                                            MaxLength="5" BorderStyle="None" Width="30px" CssClass="form_small_heading_yellow numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"
                                                                            Style="background-color: #ffffaa; padding-left: 5px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Agreed" ItemStyle-BackColor="#99cc00">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtAgreedPrice" Text='<%# Eval("AgreedPrice") %>'
                                                                            MaxLength="5" BorderStyle="None" CssClass="form_small_heading_green numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"
                                                                            Style="background-color: #99cc00 !important; width: 30px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="ckhDirectCosting" TextAlign="Left" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdDirectCostingTh" />
                                                                    <ItemStyle CssClass="grdDirectCostingTd" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- direct costing sheet end-->
                                    <br />
                                    <h4 style="background: #dddfe4  none repeat scroll 0 0; color: #575759; font-family: arial,halvetica;
                                        font-size: 13px; font-weight: bold; width: 97.7%; text-align: center; padding: 3px;
                                        margin: 0; border: 1px solid #bbbaba; border-bottom: 0;">
                                        Landed Costing
                                    </h4>
                                    <table width="100%" cellspacing="0px" border-color="gray" border="0" class="form_table"
                                        style="display: none;">
                                        <tr>
                                            <th width="10%">
                                                Boutique Price:
                                            </th>
                                            <td width="15%" style="color: Black;">
                                                <asp:TextBox ID="txtFOBBoutique" runat="server" Width="30px" Style="text-align: left;
                                                    border: 1px solid gray; margin-left: 3px" CssClass="numeric-field-with-two-decimal-places costing-landed-costing-penny"></asp:TextBox>
                                            </td>
                                            <th width="20%">
                                                Target Boutique Price:
                                            </th>
                                            <td width="15%" style="color: Black;">
                                                <asp:TextBox ID="txtTargetFOBPrice" runat="server" Width="50%" Style="text-align: left;
                                                    border: 1px solid gray; margin-left: 3px" CssClass="costing-landed-costing-grand-total1 costing-landed-costing-grand-total2 costing-landed-costing-grand-total3 costing-landed-costing-grand-total4 costing-landed-costing-grand-total5 costing-landed-costing-grand-total-fob numeric-field-with-two-decimal-places costing-landed-costing-penny"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="landedCosting_wrapper">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%);
                                            color: Gray;">
                                            <tbody id="tbodyLandedCosting">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdLandedCosting" runat="server" Width="99%" ClientIDMode="Static"
                                                            GridLines="None" CellPadding="0" ShowFooter="false" AutoGenerateColumns="false"
                                                            ShowHeader="true" Border="1" Style="border-collapse: collapse; border-bottom: #ddd;
                                                            border-color: gray;" OnRowDataBound="grdLandedCosting_RowDataBound">
                                                            <RowStyle CssClass="grdLandedCostingTr" />
                                                            <HeaderStyle CssClass="grdLandedCostingTr" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Mode" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Gray">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMode" runat="server" CssClass="lightbluebgcolor" Text='<%# Eval("Code") %>'></asp:Label>
                                                                        <asp:HiddenField ID="hdnModeId" runat="server" Value='<%# Eval("ModeId") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;BIPL Price">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtFobBoutique" BorderStyle="None" Width="30px" Text='<%# Eval("FOBBoutique") %>'
                                                                            CssClass="costing-landed-costing-penny costing-fob-boutique-price do-not-allow-typing lightbg1"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;BH Price">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtFobIkandi" BorderStyle="None" Width="30px" Text='<%# Eval("FOBIkandi") %>'
                                                                            CssClass="costing-landed-costing-penny costing-landed-costing-fob-ikandi numeric-field-with-two-decimal-places do-not-allow-typing lightbg1"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Mode Cost">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcur" runat="server" Visible="false" Style="margin-left: 19px;"></asp:Label>
                                                                        <%--<asp:DropDownList ID="ddlModeCost" runat="server" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"
                                                                            BorderStyle="None" Width="50px">
                                                                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                                        </asp:DropDownList>--%>
                                                                        <asp:TextBox ID="txtModeCost" Text='<%# Eval("ModeCost") %>' runat="server" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1 exclude"
                                                                            BorderStyle="None" Width="30px" onchange="ValidateisNaN(this);">                                                                           
                                                                        </asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Duty">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtDuty" MaxLength="5" Text='<%# Eval("Duty") %>'
                                                                            BorderStyle="None" Width="30px" CssClass="per numeric-field-without-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total1 lightbg1"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Handling">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" MaxLength="5" ID="txtHandling" Text='<%# Eval("Handling") %>'
                                                                            BorderStyle="None" Width="30px" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Delivery">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" MaxLength="5" ID="txtDelivery" Text='<%# Eval("Delivery") %>'
                                                                            BorderStyle="None" Width="30px" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Process">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblprocesscurr" Visible="false" runat="server" Style="margin-left: 20px;"></asp:Label>
                                                                        <%-- <asp:DropDownList ID="ddlProcessCost" runat="server" CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1"
                                                                            BorderStyle="None" Width="50px">
                                                                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                                        </asp:DropDownList>--%>
                                                                        <asp:TextBox ID="txtProcessCost" runat="server" Text='<%# Eval("ProcessCost") %>'
                                                                            CssClass="costing-landed-costing-penny costing-landed-costing-grand-total1 numeric-field-with-two-decimal-places lightbg1 exclude"
                                                                            BorderStyle="None" onchange="ValidateisNaN(this);" Width="30px">                                                                            
                                                                        </asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Margin">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtMargin" MaxLength="5" Text='<%# Eval("Margin") %>'
                                                                            BorderStyle="None" Width="30px" CssClass="per numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-fob-margin costing-landed-costing-grand-total1 lightbg1"
                                                                            Style="margin-left: 15px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Disc.">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtDiscount" MaxLength="5" Text='<%# Eval("Discount") %>'
                                                                            BorderStyle="None" Width="30px" CssClass="per numeric-field-with-two-decimal-places costing-landed-costing-percent costing-landed-costing-grand-total1 costing-landed-costing-discount lightbg1"
                                                                            Style="margin-left: 12px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Calc. Total" ItemStyle-BackColor="#f9ddf4">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtGrandTotal" Text='<%# Eval("GrandTotal") %>' BorderStyle="None"
                                                                            CssClass="do-not-allow-typing costing-landed-costing-penny" Style="background-color: #F9DDF4 !important;
                                                                            width: 30px; text-align: left; margin-left: 4px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Quoted" ItemStyle-BackColor="#ffffaa">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtQuotedPrice" Text='<%# Eval("QuotedPrice") %>'
                                                                            MaxLength="5" Width="30px" BorderStyle="None" CssClass="form_small_heading_yellow numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price"
                                                                            Style="background-color: #ffffaa; padding-left: 5px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Agreed" ItemStyle-BackColor="#99cc00">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtAgreedPrice" Text='<%# Eval("AgreedPrice") %>'
                                                                            MaxLength="5" BorderStyle="None" CssClass="form_small_heading_green numeric-field-with-two-decimal-places costing-landed-costing-penny ikandi_price clsAgreedPrice"
                                                                            Style="background-color: #99cc00 !important; margin-left: 2px; width: 30px;"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Action">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="ckhLandedCosting" CssClass="chkClsLandedCosting"
                                                                            TextAlign="Left" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="border_right_0 grdLandedCostingTh" />
                                                                    <ItemStyle CssClass="border_right_color grdLandedCostingTd" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <table border="0" width="100%" style="margin-top: 10px;">
                                        <tbody>
                                            <tr>
                                                <td style="text-align: left; padding-left: 0px;">
                                                    <asp:Button ID="btnSaveIkandi" runat="server" OnClick="btnSaveIkandi_Click" OnClientClick="javascript:return SAM();"
                                                        CssClass="da_submit_button do-not-print m-r-5" ValidationTarget="costing_form"
                                                        Text="Save" />
                                                    <asp:Button Text="PRICING MO" Visible="false" ID="hyPricing" CssClass="hyPricing m-r-5"
                                                        runat="server" />
                                                    <asp:Button ID="btnCostConfirmed" runat="server" OnClientClick="return openCostConfirmationPopup()"
                                                        CssClass="do-not-print da_submit_button m-r-5" Text="Cost Confirmed" />
                                                    <asp:Button ID="btniKandiUpdatePrice" runat="server" OnClick="btniKandiUpdatePriceUpdatePrice_Click"
                                                        CssClass="do-not-print btniKandiUpdatePrice da_submit_button m-r-5" Text="Update Order Price" />
                                                    <asp:Button runat="server" ID="btniKandiHistory" CssClass="da_submit_button m-r-5"
                                                        Text="History" OnClientClick="showHistory( this, 'diviKandiHistory'); return false;" />
                                                    <%--&nbsp;
                                        <input type="button" id="btnPrint" class="print do-not-print do-not-disabled" onclick="return PrintPDF();" />--%>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!----------- comment box----------->
                            <div style="box-shadow: 0 3px 6px rgb(0 0 0 / 16%), 0 3px 6px rgb(0 0 0 / 23%); margin: 10px 0;">
                                <table width="100%" cellpadding="0" cellspacing="0" border="1">
                                    <tr>
                                        <td>
                                            <span class="gray"><strong>Overall Comments</strong><a rel="shadowbox;" href="javascript:void(0)"
                                                onclick='return OpenTechfiles(this);' style="cursor: pointer; float: right; width: auto;">
                                                <asp:Label ID="lbltechFile" runat="server" ToolTip="T Pack file" Style="color: blue;"
                                                    Text="T-Pack"></asp:Label></a><br />
                                                <div class="gray" style="font-size: 10px; font-weight: normal; text-align: left;
                                                    padding: 5px 0px 3px 2px; vertical-align: bottom">
                                                    This cost is only valid for core styles versions on sizes 4-18. For larger sizes
                                                    the prices will be higher.</div>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="gray" style="font-size: 10px; font-weight: normal; height: 140px; text-align: left;
                                            padding: 4px; vertical-align: top;">
                                            <asp:Label ID="lblOverallCommentsHistory" Style="font-size: 10px; font-family: Verdana;"
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-container">
                                            <asp:TextBox runat="server" ID="txtOverallComments" TextMode="MultiLine" placeholder="Comments...."
                                                Rows="3" CssClass="form_small_heading_yellow input" Style="color: black; border-style: None;
                                                width: 99%; color: Blue; border-style: None; width: 98%; background: linear-gradient(165deg, #76b852, #8dc26f14);
                                                height: 49px; font-size: 14px; outline: none; resize: none;"></asp:TextBox>
                                            <label for="username" class="input-label">
                                                Comments....</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="text-align: left; position: relative;">
                                <a rel="shadowbox;" href="javascript:void(0)" onclick='return OpenPairingCosting(this);'
                                    style="cursor: pointer; width: auto; text-decoration: none;">
                                    <asp:Label ID="lblPairedCosting" Style="text-transform: capitalize" runat="server"
                                        Font-Bold="true"></asp:Label>
                                </a><a id="lnkHistory" style="font-size: 10px; color: Blue; font-weight: 600; margin-left: 20px;
                                    text-decoration: none" visible="false" class="HistoryAnchor" runat="server" onclick="showOldhistory('block',this,1)"
                                    target="_blank">Old History</a> <a id="lnkComment" style="font-size: 10px; color: Blue;
                                        font-weight: 600; margin-left: 20px; text-decoration: none" visible="false" class="HistoryAnchor"
                                        runat="server" onclick="showOldhistory('block',this,2)" target="_blank">Old Comment</a>
                                <asp:Label ID="lblHistory" Style="display: none" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="diviKandiHistory" class="hide_me">
        <div style="height: 300px !important; width: 600px; overflow: auto; border: 0px solid gray;
            padding: 0px; margin-bottom: 15px;">
            <div class="form_heading">
                History</div>
            <br />
            <div style="overflow: hidden auto">
                <table width="100%" cellpadding="6px">
                    <tr>
                        <td style="width: 100%; text-align: left; padding: 2px;">
                            <asp:Label ID="lbliKandiHistory" Visible="false" runat="server"></asp:Label>
                            <a href="javascript:void(0)" onclick="IkandiHistoryShowHideLanded(this)">- Hide Landed</a><br />
                            <ul class="Ulikandihistorylanded" style="line-height: 20px;">
                            </ul>
                            <a href="javascript:void(0)" onclick="IkandiHistoryShowHideDirect(this)">- Hide Direct</a><br />
                            <ul class="Ulikandihistorydirect" style="line-height: 20px;">
                            </ul>
                            <a href="javascript:void(0)" onclick="IkandiHistoryShowHideOther(this)">- Hide Other</a><br />
                            <ul class="Ulikandihistoryother" style="line-height: 20px;">
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divBIPLHistory" class="hide_me">
        <div style="height: 300px !important; width: 600px; overflow: auto; border: 0px solid gray;
            padding: 0px; margin-bottom: 15px;">
            <div class="form_heading">
                History</div>
            <br />
            <div>
                <table width="100%" cellpadding="6px">
                    <tr>
                        <td style="width: 100%; text-align: left; padding: 2px;">
                            <asp:Label ID="lblBIPLHistory" Visible="false" runat="server"></asp:Label>
                            <a href="javascript:void(0)" onclick="BiplHistoryShowHideFabric(this)">- Hide Fabric</a><br />
                            <ul class="Ulbiplhistoryfabric" style="line-height: 20px;">
                            </ul>
                            <a href="javascript:void(0)" onclick="BiplHistoryShowHideCMT(this)">- Hide CMT</a><br />
                            <ul class="UlbiplhistoryCMT" style="line-height: 20px;">
                            </ul>
                            <a href="javascript:void(0)" onclick="BiplHistoryShowHideAccessory(this)">- Hide Accessory</a><br />
                            <ul class="Ulbiplhistoryaccessory" style="line-height: 20px;">
                            </ul>
                            <a href="javascript:void(0)" onclick="BiplHistoryShowHideProcess(this)">- Hide Process</a><br />
                            <ul class="Ulbiplhistoryprocess" style="line-height: 20px;">
                            </ul>
                            <a href="javascript:void(0)" onclick="BiplHistoryShowHideFinencial(this)">- Hide Financial</a><br />
                            <ul class="Ulbiplhistoryfinancial" style="line-height: 20px;">
                            </ul>
                            <a href="javascript:void(0)" onclick="BiplHistoryShowHideOther(this)">- Hide Other</a><br />
                            <ul class="Ulbiplhistoryother" style="line-height: 20px;">
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divCommentsHistory" class="divCommentsHistory">
        <div class="form_box" style="height: 190px !important; width: 582px; overflow: auto">
            <div class="form_heading">
                Overall Comments History</div>
            <br />
            <div>
                <div runat="server" id="hdnComments">
                </div>
            </div>
        </div>
    </div>
    <div id="divCostConfirmation" class="divCostConfirmation">
        <div class="form_box">
            <div class="form_heading">
                Cost Confirmation</div>
            <br />
            <table width="90%" style="height: 180px ! important; overflow: auto;" cellpadding="6px">
                <tr>
                    <td style="width: 30%; vertical-align: top;">
                        Action
                    </td>
                    <td style="width: 70%; vertical-align: top">
                        <asp:RadioButton runat="server" ID="rdAccept" Text="Accept" Checked="true" GroupName="CostConfirmation" />
                        <asp:RadioButton ID="rdDecline" GroupName="CostConfirmation" runat="server" Text="Decline" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        Comments :
                    </td>
                    <td style="vertical-align: top;">
                        <asp:TextBox Width="100%" Rows="5" TextMode="MultiLine" runat="server" ID="txtCostConfirmationComments"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div align="center">
                <asp:Button runat="server" ID="btnCostConfirmationPopup" class="submit" OnClick="btnCostConfirmed_Click" />
                <input type="button" class="close do-not-disable" onclick="closeCostConfirmationPopup()" />
            </div>
        </div>
    </div>
    <%--added by raghvinder on 09-12-2020 start--%>
    <div class="ModelPo2" id="divhistory" runat="server" style="display: none">
        <h2 style='background: #39589c !important; width: 100% !important; font-size: 15px;
            margin: 0px 0px; color: #fff !important; margin-left: 3px; font-weight: 500;
            text-align: center'>
            <span id="Header_History_Comment">History</span><span style='float: right; margin-right: 8px;
                cursor: pointer; color: #fff' title='Close' onclick="showhistoryhide('none','');">X</span>
        </h2>
        <div class="maxWidthHist">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="width: 50%; text-align: left; padding: 0px 10px 22px; line-height: 21px;
                        font-size: 10px">
                        <asp:Label ID="lblh" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%--added by raghvinder on 09-12-2020 end--%>
    <asp:HiddenField ID="hfexcelval" Visible="true" runat="server" />
    <div id="divhfexcelval" visible="false" />
    <asp:Literal ID="lit" runat="server" />
    <table id="temptable" border="1" visible="false">
    </table>
    <asp:Label ID="hiddenCostingSheetHeight" runat="server" CssClass="costing-sheet-height hide_me" />
</div>
<script type="text/javascript">
    $("#<%=hypBooked.ClientID%>").click(function () {
        //
        var stylecode = $("#<%=hdStyleCOdeValue.ClientID%>").val();
        var url = '../Production/ProductionPlanningMatrix.aspx?OrderDetailId=-1' + '&StyleCode=' + stylecode;
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 400, width: 540, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
        return false;
    });
</script>
<div id="PendingCostingMsg" runat="server" visible="false">
    <br />
    <br />
    BIPL Costing is pending for this style.
</div>
