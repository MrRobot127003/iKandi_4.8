<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="OrderPlace.aspx.cs" Inherits="iKandi.Web.Internal.Sales.OrderPlace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../css/datepicker.css" />
    <style type="text/css">
        .item_list1
        {
            border-collapse: collapse;
            margin-right: 0px;
        }
         .gvDetailSection
         {
              border:1px solid #999;
          }
          
         .item_list1.gvDetailSection th
         {
            padding: 0px 0px !important;
          }
     .item_list1.gvDetailSection .gvborder_top
      {
            border-top: 0px !important;
            padding: 4px !important;
            border-bottom: 0px !important;
            border-right: 0px !important;
       }
       
       .item_list1.gvDetailSection .gvborder_left
       {
           border-left:0px !important;
         }
       .item_list1.gvDetailSection .gvborder_righttd
       {
           border-left:0px !important;
         }
        .item_list1.gvDetailSection .gvborder_bottom
      {
          padding: 4px !important;
            
            border-bottom: 0px !important;
            border-right: 0px !important;
            
       }
      .item_list1.gvDetailSection .gvborder_top_left
      {
            border-bottom: 0px !important;
            border-right: 0px !important;
       }
       
       .item_list1.gvDetailSection td select
       {
               position: relative;
                top: -1px;
           }
       .item_list1.gvDetailSection td 
       {
           padding:0px 0px !important;
        }
         .item_list1.gvDetailSection td table.basicsectiotable td
       {
           padding:3px 2px 0px !important;
            border-top: 0px !important;
            border-left: 0px !important;
            border-color: #eae4e4 !important;
        }
        .item_list1 .BorderColor td
        {
             border-color: #eae4e4 !important;
         }
        
     .item_list1.gvDetailSection .fabric_seiction_border td
        {
             border-left:0px !important;
             border-top:0px !important;
         } 
       .item_list1.gvDetailSection .gvborder_righttd
        {
             border-right:0px !important
         }  
        .item_list1.gvDetailSection .gvborder_righttd_left
        {
             border-right:0px !important;
             border-left:0px !important;
               border-bottom: 0px !important;
         }    
        .item_list1 th
        {
            font-size: 11px;
            padding: 3px !important;
        }       
        
        item_list1 TH
        {
            color: #575759;
            background-color: #dddfe4;
            text-transform: capitalize; /* border: 1px solid #b7b4b4 !important; */
            border-bottom: 1px solid #999999 !important;
            border-left: 1px solid #999999 !important;
            text-align: center;
            padding: 4px;
            font-weight: normal;
            font-size: 12px;
            font-family: verdana;
            border-right: 0px;
        }
        
        .item_list1 td
        {
            font-size: 10px !important;
            padding: 2px 0px !important;
            margin-left: 240px;
            text-align: left;
        }
        .item_list1
        {
            font-size: 10px !important;
        }
        .item_list1 TD select
        {
            width: 92%;
        }
        .item_list1 TD.textboxwidth input[type=text]
        {
            width: 97% !important;
        }
        .item_list1 TD input[type=text]
        {
             width: 98%;
         }
        .duplicate
        {
            background-color: yellow;
        }
        
        .tab
        {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
        }
        
        td [type="checkbox"]
        {
            position: relative;
            top: 4px;
        }
        
        .checkboxright
        {
            float: right;
            position: relative;
            top: 0px !imporant;
        }
        .checkboxright [type="checkbox"]
        {
            position: relative;
            top: 0px !important;
        }
        /* Style the buttons that are used to open the tab content */
        .tab button
        {
            background-color: inherit;
            float: left;
            border: none;
            outline: none;
            cursor: pointer;
            padding: 14px 16px;
            transition: 0.3s;
        }
        .fabric_input_width
        {
            padding-left: 3px;
            width: 95% !important;
        }
        .fabric_span_width
        {
            padding-left: 3px;
        }
        
        /* Change background color of buttons on hover */
        .tab button:hover
        {
            background-color: #ddd;
        }
        
        /* Create an active/current tablink class */
        .tab button.active
        {
            background-color: #ccc;
        }
        
        /* Style the tab content */
        .tabcontent
        {
            display: none;
            padding: 6px 11px;
            border: 1px solid #ccc;
            border-top: none;
        }
        #ctl00_cph_main_content_gvDetailSection
        {
            width: 100% !important;
            border-bottom: 1px solid #999999 !important;
            border-right: 1px solid #999999 !important; /* updated css by bharat 21-jan-19*/
            margin-bottom: 10px;
        }
        .basicsectiotable table td
        {
            border-right: 0px !important;
            border-top: 0px !important;
            padding: 3px !important;
        }
        .basicsectiotable table th
        {
            border-right: 0px !important;
            border-top: 0px !important;
            padding: 3px !important;
        }
        
        .tablebackground th
        {
            background: #dddfe4;
            border-right: 0px !important;
            border-top: 0px !important;
            padding: 3px !important;
            font-size: 10px !important;
        }
        .inputleft
        {
            width: 95px;
            float: left;
        }
       
        td input[type="text"]
        {
            font-size: 10px;
        }
        .OpenDialog
        {
            width: 200px;
            border: 4px solid #999;
            background-color: #FFFFFF;
            padding: 0px 0px 5px;
            position: fixed;
            top: 40%;
            left: 40%;
            z-index: 9999999;
            display: none;
            border-radius:5px;
        }
        .lblhover
        {
            border: 1px solid #999999;
            background: yellow;
            width: 10px !important;
            height: 10px;
            border-radius: 50%;
            position: relative;
         
        }
        
        .rightspan
        {
            width: 50%;
            margin-left: 20px;
        }
        .leftspan
        {
            width: 80px;
            float: left;
        }
        .textcenter
        {
            width: 100px;
            text-align: center;
            padding: 2px 0px;
        }
        .modalNew
        {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        .access_infotable th
        {
            border-bottom: 1px solid #999999;
            border-right: 1px solid #999999;
            text-align: center;
            padding: 2px 2px !important;
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
            background: #f8f8f8;
        }
        .access_infotable td:first-child
        {
            border-left: 1px solid #999999;
        }
        
        .modal-content
        {
            padding: 7px !important;
            border: 1px solid #7a94bb;
        }
        #dvSizeRate
        {
            max-width: 400px !important;
            margin: 0px auto;
        }
        
        .lblhover .tooltiptext_L
        {
            visibility: hidden;
            width: 250px;
            background-color: yellow;
            color: red;
            text-align: center;
            border-radius: 6px;
            padding: 5px 5px;
            position: absolute;
            z-index: 1;
            bottom: 101%;
            left: 0%;
            margin-left: -120px;
            border: 1px solid black;
            transition: opacity 0.3s;
            margin-top: 0px;
            height: 4px;
            line-height: 5px;
            margin-top: -10px;
        }
        .lblhover .tooltiptext_L::after
        {
            content: "";
            position: absolute;
            top: 100%;
            right: 50%;
            margin-left: -1px;
            border-width: 5px;
            border-style: solid;
            border-color: #000 transparent transparent;
        }
        .lblhover .fabric_detail
        {
            visibility: hidden;
             width: 208px;
            background-color: yellow;
            color: red;
            text-align: center;
            border-radius: 6px;
            padding: 5px 5px;
            position: absolute;
            z-index: 1;
            right: 2px;
            left: 109%;
            top: -2px;
            border: 1px solid black;
            transition: opacity 0.3s;
            height: 4px;
            line-height: 5px;
            margin-left: 3px;;
        }
        .lblhover .fabric_detail::after
        {
                content: "";
                position: absolute;
                right: 100%;
                top: 15%;
                /* margin-right: 0px; */
                border-width: 5px;
                border-style: solid;
                border-color: transparent #000 transparent transparent;
        }
        
         .lblhover .Accessory_detail
        {
            visibility: hidden;
             width: 100px;
            background-color: yellow;
            color: red;
            text-align: center;
            border-radius: 6px;
            padding: 5px 5px;
            position: absolute;
            z-index: 1;
            right: 2px;
            left: 109%;
            top: -2px;
            border: 1px solid black;
            transition: opacity 0.3s;
            height: 4px;
            line-height: 5px;
            margin-left: 3px;;
        }
        .lblhover .Accessory_detail::after
        {
                content: "";
                position: absolute;
                right: 100%;
                top: 15%;
                /* margin-right: 0px; */
                border-width: 5px;
                border-style: solid;
                border-color: transparent #000 transparent transparent;
        }
        
        .lblhover .tooltiptext_M
        {
            visibility: hidden;
            width: 100px;
            background-color: yellow;
            color: red;
            text-align: center;
            border-radius: 6px;
            padding: 5px 5px;
            position: absolute;
            z-index: 1;
            right: 2px;
            left: 109%;
            top: -2px;
            border: 1px solid black;
            transition: opacity 0.3s;
            height: 4px;
            line-height: 5px;
            margin-left: 3px;;
        }
        
        .lblhover .tooltiptext_M::after
        {
            content: "";
            position: absolute;
            right: 100%;
            top: 15%;
            /* margin-right: 0px; */
            border-width: 5px;
            border-style: solid;
            border-color: transparent #000 transparent transparent;
        }
        
        .lblhover .tooltiptext_S
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
            top: 101%;
            left: 50%;
            margin-left: -26px;
            border: 1px solid black;
            transition: opacity 0.3s;
            margin-top: 0px;
            height: 4px;
            line-height: 5px;
            margin-top: -7px;
        }
        .lblhover .tooltiptext_S::after
        {
            content: "";
            position: absolute;
            bottom: 100%;
            right: 50%;
            margin-left: -1px;
            border-width: 5px;
            border-style: solid;
            border-color: transparent transparent #000;
        }
        
        
        .lblhover .tooltiptext_Day
        {
            visibility: hidden;
            width: 20px;
            background-color: yellow;
            color: red;
            text-align: center;
            border-radius: 6px;
            padding: 5px 5px;
            position: absolute;
            z-index: 1;
            top: 101%;
            left: 50%;
            margin-left: -11px;
            border: 1px solid black;
            transition: opacity 0.3s;
            margin-top: 0px;
            height: 4px;
            line-height: 5px;
            margin-top: -7px;
        }
        .lblhover .tooltiptext_Day::after
        {
            content: "";
            position: absolute;
            bottom: 100%;
            right: 50%;
            margin-left: -1px;
            border-width: 5px;
            border-style: solid;
            border-color: transparent transparent #000;
        }
       
.descriptionfont{text-transform: capitalize !important;}
        .lblhover:hover .tooltiptext_L
        {
            visibility: visible;
            opacity: 1;
        }
        .lblhover:hover .fabric_detail
        {
            visibility: visible;
            opacity: 1;
        }
        .lblhover:hover .Accessory_detail
        {
            visibility: visible;
            opacity: 1;
        }
        .lblhover:hover .tooltiptext_M
        {
            visibility: visible;
            opacity: 1;
        }
        .lblhover:hover .tooltiptext_S
        {
            visibility: visible;
            opacity: 1;
        }
        .lblhover:hover .tooltiptext_Day
        {
            visibility: visible;
            opacity: 1;
        }
        .Pointer
        {
            cursor: pointer;
        }
        .AgreedBackGround
        {
            background-color: Yellow;
            color: Black;
        }
        .clsFabric
        {
            height: 23px;
            width: 300px;
            text-align: left !important;
        }
        .textborder
        {
            border: 1px solid #cebdbd !important;
            height: 12px !important;
            border-radius: 2px;
            color: Black !important;
            width: 40px !important;
        }
        .AccessoriesClass
        {
            vertical-align: top;
            height: 95px;
        }
      /*  td.AccessoriesClass.BorderColor
        {
            border-bottom-color: #00adef !important;
           
         }*/
        .item_list1 td.BorderColor
        {
            border-right-color: #eae4e4 !important;
            
         }
         .item_list1 td.BorderColor
        {
           border-bottom: 2px solid #b7b4b4  !important
            
         }
        .item_list1 td.BorderColorlast
         {
            border-right-color: #999 !important;
            
         }
        .dlstAccessoriesa td
        {
            padding: 0px 0px !important;
        }
        .accessColwidth
        {
            width: 272px;
            font-size: 10px;
            position: relative;
            top: 1px;
        }
        input[type="checkbox"]
        {
            cursor:pointer;
         }
         
        .txtAccessories
        {
            width: 170px !important;
            color: Blue;
            text-align: left !important;
            border: 1px solid #cebdbd !important;
           height: 12px !important;
        }
        .txtAccessoriesRow
        {
            width: 165px !important;
            color: Blue;
            text-align: left !important;
            height: 12px !important;
        }
        .InvalidAcc
        {
            background-color: Yellow !important;
        }
        
        #UpladFilepopup
        {
            background: #fff;
            margin: 0 auto;
            width: 286px;
            max-height: 200px;
            height: 112px;
            border: 5px solid #999;
            border-radius: 5px;
        }
        .UploadFileHeader
        {
            width: 99%;
            padding: 2px;
            background: #39589C;
            color: #f8f8f8;
            margin: 0px 0px 3px 0px;
            text-align:center;
        }
        .uploadfiletable
        {
            margin:0 auto;
        }
       /* table.uploadfiletable td
        {
           padding-left: 3px !important;;
        }*/
         .uploadfiletable input[type="file"]
        {
            float:left;
        }
        .uploadfiletable input[type="submit"]
        {
            background: #13a747;
            color: #fff;
            border: 1px solid #13a747;
            padding: 2px 4px;
            border-radius: 2px;
            font-size: 11px;
            margin: 2px 0px;
            cursor: pointer;
        }
        .fileupladcur
        {
            cursor: pointer;
                
            }
            .fileupladcur img
        {
            width:20px;
            height:20px;
            }
            #SplitPopup
            {
            width: 450px;
            margin: 0 auto;
            background: #fff;
            padding: 0px 0px;
            border: 5px solid #999;
            border-radius: 5px;
            }
            textarea
            {
                font-size:11px !important;
                width:92% !important;
            }
        .bottomtable-border-0 table td
        {
            border:0px !important
        }
            
        .ui-dialog.ui-widget
            {
                background:#ffff;
                border: 5px solid #999999;
                }
            .ui-dialog .ui-dialog-content {
            overflow: inherit !important;
               
        }
        /*iframe
        {
               
            height: 340px;
            max-height: 380px;
            overflow: auto;
            border-top: 0px;
             
            }*/
            .ui-draggable .ui-dialog-titlebar {
            cursor: auto;
            text-align:center;
        }
        .ui-dialog-titlebar.ui-widget-header a
        {
            display:none; 
        }
        .toprel_2{
        position: relative;
        top: 2px;
        }
        #sb-wrapper-inner
        {
            background:#fff; 
            border:5px solid #999;
            border-radius:5px;
        }
        select
        {
        visibility:visible !important;
        }
        .lblhovermargin
        {
            margin-right:2px;
            top:3px;
        }
        .spin
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        } 
        ::-webkit-scrollbar {
        width: 8px;
        height: 5px;
        cursor:pointer;
    }    
     .Historytable
     {
           
            border: 1px solid #999;
            border-collapse: collapse;
            height:184px;
      } 
 .Historytable th
     {
                background: #f7f7f7;
                border: 1px solid #999;
                width: 172px;
                border-collapse: collapse;
                padding: 3px 5px;
                font-weight: 500;
                color:#615d5d ;
                text-align: left;
      } 
     
      .tabcom
      {
         width: 90px;
        display: table-cell;
        border-top-left-radius: 5px;
        border-top-right-radius: 5px;
        background: #f7f7f7;
        height: 18px;
        border: 1px solid #999;
        text-align: center;
        line-height: 25px;
        border-bottom: 1px solid #efefef;
        cursor: pointer;
        }
       .clsActive
       {
               background: #60638b;
              color: #fff;
               font-size: 11px;
            font-weight: 600 !important;
        }
        .clsActiveth {
              background: #b9b8b8 !important;
            color: #fff !important;
            font-size: 11px;
            font-weight: 600 !important;
        }
        .historyth
        {
            cursor:pointer;
        }  
        .CommentHeight1
        {
            vertical-align:top;
            max-height: 153px;
            overflow: auto;
            height: 150px;
            float: left;
             width: 99%;
         } 
         .CommentHeight2
        {            
            max-height: 110px;
            overflow: auto;
            min-height: 110px;
            float: left;
            width: 99%;
         }  
         .NoRecord
         {
             color:Blue;
             font-size:10px;
             }  
    .pageloadcomment
    {
        display:none;
    }   
   .ok
   {
       height:20px;
    }
    
   /*ImagePopup css*/ 
    .Imgshow{
        z-index: 999;
        display: none;
    }
    .Imgshow .overlay{
        width: 100%;
        height: 100%;
        background: rgba(0,0,0,.66);
        position: absolute;
        top: 0;
        left: 0;
    }
    .Imgshow .img-show{
        width: 716px;
        height: 400px;
        background: #FFF;
        position: absolute;
        top: 45%;
        left: 50%;
        transform: translate(-50%,-50%);
        overflow: hidden;
        border: 5px solid #999;
        padding: 5px;
        border-radius: 5px;
    }
    .img-show  span{
        position: absolute;
        top: 0px;
        right: 0px;
        z-index: 99;
        cursor: pointer;
        width: 100%;
        background: #39589c;
        text-align: right;
        padding-right: 5px;
        color:#fff;
    }
  
    .img-show  .imgcontainer{
        margin-top: 20px;
        width: 99%;
        height: 95%;
        margin: 20px auto 0;
    }
    .img-show  .imgcontainer img{
        width: 100%;
        height: 100%;
    }
     .da_submit_button{
	font-size:12px;
	height: 22px;
	line-height: 13px;
	
}
    .da_submit_button:hover{
	font-size:12px;
	height: 22px;
	line-height: 13px;
	
}
     
     .tablewidth
     {
          width:100%; 
         }
     .style_number_box.containersize
     {
            width: 289px !important;
            border:5px solid #999 !important; 
            border-color:#999;
            padding: 0px;
            border-radius:5px;
     }
     ::-webkit-scrollbar-thumb {
    background: #b8b4b4  !important;
    border: 1px solid #b8b4b4  !important;
    border-radius: 10px;
}
  ::-webkit-scrollbar-thumb:hover {
    background: #999 !important;
    border: 1px solid #999 !important;
    border-radius: 10px;
}
.item_list1.gvDetailSection td table.basicsectiotable td table.baricesection td
{
    padding:0px 2px 5px !important;
    border-top: 0px !important;
    border-right: 1px solid #eae4e4 !important;
    border-color: #eae4e4 !important; 
  }
  
 .FabricQualitybgColor
 {
     background-color:#bfbfbf !important;
 } 
   
 @-moz-document url-prefix() {
   .accessColwidth
        {
            width: 205px;
        }
}
.item_list1.paddingLeft td
{
    padding-left:1px !important;
 }

/*.ui-datepicker-prev span,
.ui-datepicker-next span {
  background-image: none !important;
}*/



 /*.ui-widget-content .ui-icon {
    background-image: url("../../images/add.png")      
    !important;}
    .ui-widget-header .ui-icon {
    background-image: url("../../images/add.png")   
    !important;}*/
    
#image_wrap
{
    max-width:100%;
 }
 #image_wrap img
{
    max-width:100%;
 }
 
 
      @media  screen and (max-width: 1440px) {
       .tablewidth
             {
                 width:1440px;
                 overflow:auto;
                margin-bottom: 10px;
                } 
    }
     @media  screen and (max-width: 1366px) {
       .tablewidth
             {
                 width:1296px;
                 overflow:auto;
                 margin-bottom: 10px;
                }
              #secure_greyline {
                width: 102% !important;
            }
           body
           {
              
                 overflow-x:scroll;
             }
    }
     @media  screen and (max-width: 1360px) {
       .tablewidth
             {
                 width:1296px;
                 overflow:auto;
                 margin-bottom: 10px;
                }
              #secure_greyline {
                width: 102% !important;
            }
           body
           {
              
                 overflow-x:scroll;
             }
    }
    @media  screen and (max-width: 1280px) {
       .tablewidth
             {
                 width:1280px;
                 overflow:auto;
                 margin-bottom: 10px;
                }  
    }
    
    .Bold_Black{font-Weight:bold !important;color:black !important;}
    .bold{ font-weight:bold;}
        
        .abc
        {
             overflow: hidden;
            text-overflow: ellipsis;
         }         
       #rptDivOldHistory
       {
         
           overflow: auto;
           min-height:178px;
           max-height: 178px;
       }
       #rptDivOldComment
       {
            overflow: auto;
           min-height:178px;
           max-height: 178px;
        } 
        #rptDivOldHistory span
        {
        font-size:11px;
        }
        #rptDivOldComment span
        {
        font-size:11px;
        }
        [data-title] {
   position: relative;
 }

 [data-title]:hover::after {
       content: attr(data-title);
        position: absolute;
        top: 15px;
        left: 0px;
        width: auto;
        padding: 5px 8px;
        background: #403c3c;
        color: #fff;
        z-index: 9;
        font-size: 10px;
        height: auto;
        line-height: 12px;
        border-radius: 3px;
        white-space: pre-line;
        word-wrap: break-word;
        width: 243px;
    }
   [data-title]:hover::before {
      content: '';
      position: absolute;
      bottom:-8px;
      left: 5px;
      display: inline-block;
      color: #fff;
      border: 8px solid transparent;	
      border-bottom: 8px solid #403c3c;
    }
    </style>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <script type="text/javascript" language="javascript">

        var txtStyleNumberClientID = '<%=txtStyleNumber.ClientID%>';
        var hdnStyleIDClientID = '<%=hdnStyleID.ClientID %>';
        var BuyerDDClientID = '<%=ddlClient.ClientID%>';
        var ParentDeptDDClientID = '<%=ddlParentDept.ClientID%>';
        var DeptDDClientID = '<%=ddlDepartment.ClientID%>';
        var txtSerialNoClientID = '<%=txtSerialNo.ClientID%>';
        var txtDescriptionClientID = '<%=txtDescription.ClientID%>';
        var hdnRepeatOrderClientID = '<%=hdnRepeatOrder.ClientID %>';
        var imgFrontClientID = '<%=imgFront.ClientID %>';
        var imgBackClientID = '<%=imgBack.ClientID %>';
        var imagePrintClientID = '<%=imagePrint.ClientID %>';
        var hdnuseridClientID = '<%=hdnuserid.ClientID %>';
        var hdnClientIdClientID = '<%=hdnClientId.ClientID %>';
        var hdnParentDeptNameClientID = '<%=hdnParentDeptName.ClientID %>';
        var hdnParentDeptIdClientID = '<%=hdnParentDeptId.ClientID %>';
        var hdnDeptNameClientID = '<%=hdnDeptName.ClientID %>';
        var hdnDeptIdClientID = '<%=hdnDeptId.ClientID %>';
        var lblRuppesClientID = '<%=lblRuppes.ClientID %>';
        var txtAccntMgrClientID = '<%=txtAccntMgr.ClientID %>';
        var hdnOrderIdClientID = '<%=hdnOrderId.ClientID %>';

        var txtStyleNumber1ClientID = '<%=txtStyleNumber1.ClientID%>';
        var txtStyleNumber2ClientId = '<%=txtStyleNumber2.ClientID%>';
        var hdnParentStyleNumberClientId = '<%=hdnParentStyleNumber.ClientID %>';
        var txtTotalQtyClientId = '<%=txtTotalQty.ClientID %>';
        var lblTotQtyUnitClientId = '<%=lblTotQtyUnit.ClientID %>';
        var hdnConversionRateClientID = '<%=hdnConversionRate.ClientID %>';
        var txtTotalOrderValueClientId = '<%=txtTotalOrderValue.ClientID %>';
        var hdnIsIkandiClientID = '<%=hdnIsIkandiClient.ClientID %>';
        var hdnExpectedDateClientID = '<%=hdnExpectedDate.ClientID %>';
        var hdnCostingIdClientID = '<%=hdnCostingId.ClientID %>';
        var hdnCurrencySignClientId = '<%=hdnCurrencySign.ClientID %>';
        var lblOrderDateClientId = '<%=lblOrderDate.ClientID %>';
        var hdnIsEmptyRowClientId = '<%=hdnIsEmptyRow.ClientID %>';
        var AccessSubmitClientId = '<%=IsAccessSubmit.ClientID %>';
        var hdnFileUploadClientId = '<%=hdnFileUpload.ClientID %>';
        var hdnRepeatWithChangesClientID = '<%=hdnRepeatWithChanges.ClientID %>';
        var hdnParentStyleIDClientID = '<%=hdnParentStyleID.ClientID %>';

        var Accesstype = '';
        var Item = '';
        var ItemId = 0;
        var CommentFlag = 0;

        //new code start


        function showhistoryhide(flag, elem) {
            $("#divOldHistory").css("display", flag);
        }
        $(function () {
            LoadStyle();
            PopulateOnPageLoad();
            openContent('obj', 'dvHistory', 1);

        });

        function PopulateOnPageLoad() {
            $('.DCDate').datepicker({ dateFormat: 'dd M y (D)' });

            $(".DC").change(function () {
                onDCChange(this);

            });

            var clientId = $("#" + BuyerDDClientID, "#main_content").val();

            $("input[type=text].DyedRow").autocomplete1("/Webservices/iKandiService.asmx/GetAllPrintNumber", {
                dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                {
                    ClientId: clientId,
                    PrintCategory: 0
                }
            });


            $("input[type=text].ScreenPrntRow").autocomplete1("/Webservices/iKandiService.asmx/GetAllPrintNumber", {
                dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                {
                    ClientId: clientId,
                    PrintCategory: 1
                }
            });

            $("input[type=text].DigitalPrntRow").autocomplete1("/Webservices/iKandiService.asmx/GetAllPrintNumber", {
                dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                    {
                        ClientId: clientId,
                        PrintCategory: 2
                    }
            });

        }


        function SpinnShow() {
            $("#spinnL").addClass("spin");
            $('body').scrollTop($('body')[0].scrollHeight);
        }
        function SpinnHide() {
            $("#spinnL").removeClass("spin");
        }

        function SubmitPage() {
            $("#" + AccessSubmitClientId, "#main_content").val(1);
            $('.submitbtn').click();
        }
        function UploadFile(obj, type) {
            if (type == 'Empty') {
                $("#" + hdnFileUploadClientId, "#main_content").val(0);
            }
            else {
                var Ids = obj.id;
                var rowno = Ids.split("_")[5].substr(3);
                rowno = parseInt(rowno) - 1
                $("#" + hdnFileUploadClientId, "#main_content").val(rowno);
            }

            $("#dvFileUpload").css("display", "block");
        }


        function LoadStyle() {
            $(".CheckOrder").attr("style", "display:none");

            $("input[type=text].style-number").autocomplete("/Webservices/iKandiService.asmx/SuggestStyleNumberForOrderPlace", { dataType: "xml", datakey: "string", max: 100 });
            $("input[type=text].style-number").result(function () {
                onStyleChange();
            });

            $('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll(' + $("#" + hdnStyleIDClientID, "#main_content").val() + ',-1,-1)');
        }

        function onStyleChange() {
            var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();
            var orderId = $("#" + hdnOrderIdClientID).val();
            if (parseInt(orderId) > -1) {
                proxy.invoke("StyleExistForThisClient", { OrderId: orderId, StyleNumber: styleNumber },
            function (result) {
                var StyleExist = parseInt(result);
                if (StyleExist == 0) {
                    jQuery.facebox('This Style not belong to this Client! choose another one.');
                    $("#" + txtStyleNumberClientID, "#main_content").val('');
                    return false;
                }
            });
            }

            proxy.invoke("GetOrderInfoByStyleNumber", { StyleNumber: styleNumber },
            function (result) {

                var styleid = result.StyleID;

                if (orderId == -1) {
                    //      alert("alert test")
                    var IsRepeatedOrder = result.IsRepeat;
                    if (IsRepeatedOrder != 'false') {
                        $("#" + hdnRepeatOrderClientID, "#main_content").val(1);
                        $(".CheckOrder").attr("style", "display:block");
                    }
                }
                $("#" + txtDescriptionClientID, "#main_content").val(result.Description);
                $("#" + hdnStyleIDClientID, "#main_content").val(styleid);
                $('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll(' + $("#" + hdnStyleIDClientID, "#main_content").val() + ',-1,-1)');


                if (result.Style.SampleImageURL1 != "") {
                    $("#" + imgFrontClientID, "#main_content").attr("src", "/Uploads/Style/thumb-" + result.Style.SampleImageURL1);
                    $("#" + imgFrontClientID, "#main_content").show();
                }

                else if (result.Style.SampleImageURL1 == "" && $("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {
                    $("#" + imgFrontClientID, "#main_content").attr("src", "");
                    $("#" + imgFrontClientID, "#main_content").attr("style", "display:none;");
                    $("#" + imgFrontClientID, "#main_content").attr("class", "hide_me");
                }

                if (result.Style.SampleImageURL2 != "") {
                    $("#" + imgBackClientID, "#main_content").attr("src", "/Uploads/style/thumb-" + result.Style.SampleImageURL2);
                    $("#" + imgBackClientID, "#main_content").show();
                }
                else if (result.Style.SampleImageURL2 == "" && $("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {
                    $("#" + imgBackClientID, "#main_content").attr("src", "");
                    $("#" + imgBackClientID, "#main_content").attr("style", "display:none;");
                    $("#" + imgBackClientID, "#main_content").attr("class", "hide_me");
                }
                if (result.Print.ImageUrl != "") {
                    $("#" + imagePrintClientID, "#main_content").attr("src", "/Uploads/Print/" + result.Print.ImageUrl);
                    $("#" + imagePrintClientID, "#main_content").show();
                }
                else if (result.Print.ImageUrl == "" && $("#" + txtStyleNumberClientID, "#main_content").val() != document.getElementById(txtStyleNumberClientID).defaultValue) {
                    $("#" + imagePrintClientID, "#main_content").attr("src", "");
                    $("#" + imagePrintClientID, "#main_content").attr("style", "display:none;");
                    $("#" + imagePrintClientID, "#main_content").attr("class", "hide_me");
                }

                $("#" + hdnClientIdClientID, "#main_content").val(result.ClientID);
                $("#" + BuyerDDClientID, "#main_content").val(result.ClientID);
                $("#" + txtAccntMgrClientID, "#main_content").val(result.AccountManagerName)

                if (orderId == -1) {
                    if (result.ClientID > 0) {
                        proxy.invoke("GetNewSerialNumber", { clientId: result.ClientID },
                    function (SerialNumber) {
                        $("#" + txtSerialNoClientID, "#main_content").val(SerialNumber);
                    });
                    }
                }

                if (result.ConversionRate == 0) {
                    $("#" + hdnConversionRateClientID, "#main_content").val(1);
                }
                else {
                    $("#" + hdnConversionRateClientID, "#main_content").val(result.ConversionRate);
                }
                $("#" + hdnIsIkandiClientID, "#main_content").val(result.IsIkandiClient);
                $("#" + hdnCostingIdClientID, "#main_content").val(result.Costing.CostingID);
                $("#" + hdnCurrencySignClientId, "#main_content").val(result.Costing.CurrencySign);

                populateParentDepartments(result.ClientID, result.ParentDepartmentID, result.ParentDepartmentID, 'Parent');
                populateDepartments(result.ClientID, result.DepartmentID, result.ParentDepartmentID, 'SubParent');

                $("#" + txtTotalQtyClientId, "#main_content").val('');
                $("#" + lblTotQtyUnitClientId, "#main_content").html("");
                $("#" + lblRuppesClientID, "#main_content").html("");
                $("#" + txtTotalOrderValueClientId, "#main_content").val('');



                if (orderId == -1) {
                    var gvId = "ctl01";
                    $("#" + hdnIsEmptyRowClientId, "#main_content").val(1);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtQty_Empty" + "']").val('');
                    $("#<%= gvDetailSection.ClientID %> span[id*='" + gvId + "_lblQtyPcs_Empty" + "']").text('');
                    $("#<%= gvDetailSection.ClientID %> span[id*='" + gvId + "_lblSymblBIPLPrice_Empty" + "']").text(result.Costing.CurrencySign);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtBIPLPrice_Empty" + "']").val(parseFloat(result.Costing.AgreedPrice).toFixed(2));
                    $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlMode_Empty" + "']").empty();
                    $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlCountryCode_Empty" + "']").empty();
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtDelivery_Empty" + "']").val('');
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtikandiPrice_Empty" + "']").val('');
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtDC_Empty" + "']").val('');
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnDC_Empty" + "']").val('');
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtExFactory_Empty" + "']").val('');
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtExFactoryWeek_Empty" + "']").val('');
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtDCWeek_Empty" + "']").val('');

                    //$("#<%= gvDetailSection.ClientID %> span[id*='" + gvId + "_FileUpload_Empty" + "']").css("display", "");

                    if (result.IsIkandiClient == false) {
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtikandiPrice_Empty" + "']").val('N/A');
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtikandiPrice_Empty" + "']").attr('readonly', 'true');
                    }
                }
                //
                populateModes(result.IsIkandiClient, result.Costing.CostingID, result.ClientID, result.DepartmentID, orderId);
                //
                PopulateCountryCode(result.ClientID, orderId);
                //
                //------------------------------------------------ Fabric Section --------------------------------------------
                var FabricCount = result.ContractFabric.length;
                var tr = $("#<%=gvDetailSection.ClientID%> tr");

                var gvId = "ctl01";
                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnFabricCount" + "']").val(FabricCount);
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric1").css("display", "none");
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric2").css("display", "none");
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric3").css("display", "none");
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric4").css("display", "none");
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric5").css("display", "none");
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric6").css("display", "none");
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric7").css("display", "none");
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric8").css("display", "none");
                var fn = 1;
                for (var FabNo = 0; FabNo < FabricCount; FabNo++) {
                    //
                    var gvId = "ctl01";
                    $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdFabric" + fn).css("display", "");
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnFabric" + fn + "']").val(result.ContractFabric[FabNo].FabricId);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtFabric" + fn + "']").val(result.ContractFabric[FabNo].FabricName);
                    $("#<%= gvDetailSection.ClientID %> span[id*='" + gvId + "_lblCountCnstr" + fn + "']").text(result.ContractFabric[FabNo].CountConstruct);
                    if (result.ContractFabric[FabNo].GSM == '0') {
                        $("#<%= gvDetailSection.ClientID %> span[id*='" + gvId + "_lblGSM" + fn + "']").text('');
                    }
                    else {
                        $("#<%= gvDetailSection.ClientID %> span[id*='" + gvId + "_lblGSM" + fn + "']").text(result.ContractFabric[FabNo].GSM);
                    }
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnCountCnstr" + fn + "']").val(result.ContractFabric[FabNo].CountConstruct);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnGSM" + fn + "']").val(result.ContractFabric[FabNo].GSM);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnFabriQualityId" + fn + "']").val(result.ContractFabric[FabNo].fabric_qualityID);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnFabricType" + fn + "']").val(result.ContractFabric[FabNo].FabTypeId);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtFabricType" + fn + "']").val(result.ContractFabric[FabNo].FabType);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtFabricDetail" + fn + "']").val(result.ContractFabric[FabNo].FabricDetail);

                    //added by raghvinder on 21-09-2020 start
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnFabricQualityDetailsID" + fn + "']").val(result.ContractFabric[FabNo].fabric_qualityID);
                    if (result.ContractFabric[FabNo].fabric_qualityID >= 20000) {
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtFabric" + fn + "']").addClass('FabricQualitybgColor');
                    }
                    //added by raghvinder on 21-09-2020 end

                    if (result.ContractFabric[FabNo].FabTypeId == '0') {
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtFabricDetail" + fn + "']").addClass('DyedPrintEmpty');

                        PopulateDyedPrintEmpty(result.ContractFabric[FabNo].FabricDetail, result.ContractFabric[FabNo].FabTypeId, result.ClientID);
                    }

                    else if (result.ContractFabric[FabNo].FabTypeId == '1') {
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtFabricDetail" + fn + "']").addClass('ScreenPrintEmpty');

                        PopulateScreenPrintEmpty(result.ContractFabric[FabNo].FabricDetail, result.ContractFabric[FabNo].FabTypeId, result.ClientID);
                    }
                    else if (result.ContractFabric[FabNo].FabTypeId == '2') {
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtFabricDetail" + fn + "']").addClass('DigitalPrintEmpty');

                        PopulateDigitalPrintEmpty(result.ContractFabric[FabNo].FabricDetail, result.ContractFabric[FabNo].FabTypeId, result.ClientID);
                    }

                    fn = parseInt(fn) + 1;
                }
                //------------------------------------------------ End Fabric Section --------------------------------------------

                //------------------------------------------------ Accessories Section --------------------------------------------
                var AccessCount = result.ContractAccessories.length;

                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessCount" + "']").val(AccessCount);
                var inrNo = 1;
                while (inrNo <= 16) {
                    $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdAccess" + inrNo).css("display", "none");
                    inrNo = inrNo + 1;
                }
                //shubhendu
                var fn = 1;
                //  alert("Check");
                for (var AccessNo = 0; AccessNo < AccessCount; AccessNo++) {
                    var gvId = "ctl01";

                    $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdAccess" + fn).css("display", "");
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessId_" + fn + "']").val(result.ContractAccessories[AccessNo].AccessoriesId);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessName_" + fn + "']").val(result.ContractAccessories[AccessNo].AccessoriesName);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessSizeId_" + fn + "']").val(result.ContractAccessories[AccessNo].SizeId);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessSize_" + fn + "']").val(result.ContractAccessories[AccessNo].Size);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnIsDefaultAccess_" + fn + "']").val(result.ContractAccessories[AccessNo].IsDefaultAccessory);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtAccessVal_" + fn + "']").val(result.ContractAccessories[AccessNo].ColorPrint);

                    var Accessories = result.ContractAccessories[AccessNo].AccessoriesName;

                    if (result.ContractAccessories[AccessNo].Size != '')
                        Accessories = Accessories + ' (' + result.ContractAccessories[AccessNo].Size + ')';
                    else
                        Accessories = Accessories;

                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtAccessName_" + fn + "']").val(Accessories);
                    $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtAccessName_" + fn + "']").attr('title', Accessories);

                    //added by raghvinder on 21-09-2020 start                    
                    if (result.ContractAccessories[AccessNo].AccessoriesId >= 40000) {
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtAccessName_" + fn + "']").addClass('FabricQualitybgColor');
                    }
                    //added by raghvinder on 21-09-2020 end

                    fn = parseInt(fn) + 1;
                }
                Accesstype = 'Empty';
                //PopulateAccessories();
                //------------------------------------------------ End Accessories Section --------------------------------------------

            });
        }

        function PopulateDyedPrintEmpty(SearchVal, Fabtype, clientId) {

            $("input[type=text].DyedPrintEmpty").autocomplete1("/Webservices/iKandiService.asmx/GetAllPrintNumber", {
                dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                {
                    searchValue: SearchVal,
                    ClientId: clientId,
                    PrintCategory: 0
                }
            });
        }

        function PopulateScreenPrintEmpty(SearchVal, Fabtype, clientId) {

            $("input[type=text].ScreenPrintEmpty").autocomplete1("/Webservices/iKandiService.asmx/GetAllPrintNumber", {
                dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                {
                    searchValue: SearchVal,
                    ClientId: clientId,
                    PrintCategory: 1
                }
            });
        }
        function PopulateDigitalPrintEmpty(SearchVal, Fabtype, clientId) {

            $("input[type=text].DigitalPrintEmpty").autocomplete1("/Webservices/iKandiService.asmx/GetAllPrintNumber", {
                dataType: "xml", datakey: "string", max: 100, "width": "400",
                extraParams:
                {
                    searchValue: SearchVal,
                    ClientId: clientId,
                    PrintCategory: 2
                }
            });
        }



        function checkAccessories(obj) {

            var Accessries = $(obj).val().split('(');
            Accessries = Accessries[0].trim();
            ItemId = $(obj)[0].id.split("_")[7];
            var gvId = "ctl01";

            var SizeId = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessSizeId_" + ItemId + "']").val();

            if (Accessries != '') {
                //
                proxy.invoke("CheckAccessories", { searchValue: Accessries },
                function (result) {
                    //
                    var AccessriesExist = parseInt(result);
                    if (AccessriesExist == 0) {
                        $(obj).val('');
                        return false;
                    }
                });

                var AccessCount = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessCount" + "']").val();

                for (var AccessNo = 1; AccessNo <= AccessCount; AccessNo++) {
                    if (AccessNo != ItemId) {

                        var AccessName = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessName_" + AccessNo + "']").val();
                        var AccessSizeId = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessSizeId_" + AccessNo + "']").val();

                        if ((Accessries == AccessName) && (SizeId == AccessSizeId)) {
                            $(obj).val('');
                            return false;
                        }

                    }
                }
            }
        }

        function AddAccessories(type) {

            if (type == 'Empty') {
                var gvId = "ctl01";
                var AccessCount = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessCount" + "']").val();
                AccessCount = parseInt(AccessCount) + 1;
                $("#<%= gvDetailSection.ClientID %>_" + gvId + "_tdAccess" + AccessCount).css("display", "");
                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessId_" + AccessCount + "']").val(-1);
                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessName_" + AccessCount + "']").val('');
                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessSizeId_" + AccessCount + "']").val(-1);
                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessSize_" + AccessCount + "']").val('');
                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtAccessName_" + AccessCount + "']").val('');

                $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnAccessCount" + "']").val(AccessCount);
                return false;
            }
            else if (type == 'Row') {

                var orderId = $("#" + hdnOrderIdClientID).val();
                var url = '../../Internal/Sales/OrderPlaceAccessories.aspx?orderid=' + orderId;
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: url, type: "iframe", player: "iframe", title: "", height: 350, width: 400, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                return false;
            }
        }

        function SBClose() { }

        function ChangeParentDept(elem) {

            var clientId = $("#" + BuyerDDClientID, "#main_content").val();
            var ParentDeptId = $(elem).val();
            populateDepartments(clientId, -1, ParentDeptId, 'SubParent');
            setParentDeptName();
        }

        function ChangeDept(elem) {

            var clientId = $("#" + BuyerDDClientID, "#main_content").val();
            var DeptId = $(elem).val();
            var DeptName = $("#" + DeptDDClientID, "#main_content").find("option:selected").text();
            $("#" + hdnDeptNameClientID, "#main_content").val(DeptName);
            $("#" + hdnDeptIdClientID, "#main_content").val(DeptId);
        }

        function populateParentDepartments(clientId, selectedDeptID, ParentDeptId, type) {

            var UserID = parseInt($("#" + hdnuseridClientID).val());
            bindDropdown(serviceUrl, ParentDeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", false, ParentDeptId, onPageError, setParentDeptName)

            var ParentDeptName = $("#" + ParentDeptDDClientID, "#main_content").find("option:selected").text();
            var ParentDeptId = $("#" + ParentDeptDDClientID, "#main_content").val();
            $("#" + hdnParentDeptNameClientID, "#main_content").val(ParentDeptName);
            $("#" + hdnParentDeptIdClientID, "#main_content").val(ParentDeptId);
            $("#" + ParentDeptDDClientID, "#main_content").attr('disabled', 'disabled');
        }

        function populateDepartments(clientId, selectedDeptID, ParentDeptId, type) {

            var UserID = parseInt($("#" + hdnuseridClientID).val());
            bindDropdown(serviceUrl, DeptDDClientID, "GetClientDeptsByClientID_ForDesignForm", { ClientID: clientId, UserID: UserID, ParentDeptId: ParentDeptId, type: type }, "Name", "DeptID", false, selectedDeptID, onPageError, setDeptName)
            var DeptName = $("#" + DeptDDClientID, "#main_content").find("option:selected").text();
            var DeptId = $("#" + DeptDDClientID, "#main_content").val();
            $("#" + hdnDeptNameClientID, "#main_content").val(DeptName);
            $("#" + hdnDeptIdClientID, "#main_content").val(DeptId);
            $("#" + DeptDDClientID, "#main_content").attr('disabled', 'disabled');
        }

        function ShowAddStyleNumberBox(chk) {

            if (chk.checked) {
                var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();
                var BaseStyleNumber = getStylefromDesc(styleNumber);
                $("#" + txtStyleNumber1ClientID, "#main_content").val(BaseStyleNumber);
                $('.style_number_box').show();
            }
            else {
                $("#" + txtStyleNumberClientID, "#main_content").val('');
                onStyleChange();
            }
        }

        function HideAddStyleNumberBox() {

            $('.style_number_box').hide();
            var checkbox = $('#chkRepeatOrder');
            checkbox.attr('checked', false);
            $("#" + hdnRepeatWithChangesClientID, "#main_content").val(0);
        }

        function getStylefromDesc(styleNumber) {
            var sn = $.trim(styleNumber);
            if (styleNumber.indexOf('$') > -1) {
                if (styleNumber != '' && sn.split('$').length == 1 && sn.indexOf('$') > -1) {
                    sn = sn.replace('!', '');
                    if (sn.indexOf(' ') > -1)
                        sn = sn.substring(0, sn.lastIndexOf(' '));
                    return sn;
                }
                else if (styleNumber != '' && sn.split('$').length == 2) {
                    var sn = $.trim(styleNumber);
                    sn = sn.replace('!', '');
                    if (sn.indexOf(' ') > -1)
                        sn = sn.substring(0, sn.lastIndexOf(' '));
                    sn = sn.replace('$', ' ');
                    return sn;
                }
            }
            else {
                if (sn.split(' ').length == 3)
                    sn = sn.substring(0, sn.lastIndexOf(' '));
                return sn;
            }
        }

        function SaveNewStyleNumber() {

            var styleNumber = $("#" + txtStyleNumber1ClientID, "#main_content").val() + ' ' + $("#" + txtStyleNumber2ClientId, "#main_content").val();
            proxy.invoke('GetStyleByNumber', { StyleNumber: styleNumber },
            function (objStyle) {

                if (null != objStyle && objStyle.StyleID != -1) {
                    ShowHideValidationBox(true, 'Style Number already exists.', 'Costing Sheet - Add Style Number');
                }
                else {
                    $("#" + hdnParentStyleNumberClientId, "#main_content").val($("#" + txtStyleNumberClientID, "#main_content").val());
                    $("#" + txtStyleNumberClientID, "#main_content").val(styleNumber);
                    var ParentStyleId = $("#" + hdnStyleIDClientID, "#main_content").val();
                    $("#" + hdnParentStyleIDClientID, "#main_content").val(ParentStyleId);
                    $("#" + hdnRepeatWithChangesClientID, "#main_content").val(1);
                    $('.style_number_box').hide();
                }
            });
        }

        function populateModes(IsikandiClient, CostingId, ClientId, DepartmentID, orderId) {

            if (ClientId > 0) {
                if (orderId == -1) {
                    $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlMode_Empty" + "']").append($("<option></option>").val('-1').html('Select...'));
                }
                proxy.invoke("Get_modes_For_OrderPlace", { IsikandiClient: IsikandiClient, CostingId: CostingId, ClientId: ClientId, DepartmentID: DepartmentID, OrderDetailId: -1 }, function (result) {
                    $.each(result, function (key, value) {

                        if (orderId == -1) {
                            if (value.EnableMode == false) {
                                $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlMode_Empty" + "']").append($("<option disabled='disabled'></option>").val(value.ModeId).html(value.ModeCode));
                            }
                            else {
                                $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlMode_Empty" + "']").append($("<option></option>").val(value.ModeId).html(value.ModeCode));
                            }

                        }
                    });

                });
            }
        }

        function PopulateCountryCode(ClientId, orderId) {

            if (ClientId > 0) {
                proxy.invoke("GetClientCountryCode", { ClientId: ClientId }, function (result) {
                    $.each(result, function (key, value) {
                        //
                        if (orderId == -1) {
                            $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlCountryCode_Empty" + "']").append($("<option></option>").val(value.CountryId).html(value.CountryCode));
                        }
                    });

                });
            }
        }

        function setParentDeptName() {

            var ParentDeptName = $("#" + ParentDeptDDClientID, "#main_content").find("option:selected").text();
            var ParentDeptId = $("#" + ParentDeptDDClientID, "#main_content").val();
            $("#" + hdnParentDeptNameClientID, "#main_content").val(ParentDeptName);
            $("#" + hdnParentDeptIdClientID, "#main_content").val(ParentDeptId);
        }

        function setDeptName() {

            var DeptName = $("#" + DeptDDClientID, "#main_content").find("option:selected").text();
            var DeptId = $("#" + DeptDDClientID, "#main_content").val();
            $("#" + hdnDeptNameClientID, "#main_content").val(DeptName);
            $("#" + hdnDeptIdClientID, "#main_content").val(DeptId);
        }

        function UpdateQuantity_WithPrice(elem, type) {


            var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();
            if (styleNumber == '') {
                jQuery.facebox("Please add Style first");
                $(elem).val('');
                $("#" + txtStyleNumberClientID, "#main_content").focus();
                return false;
            }
            var TotalQty = 0;
            var Qtytext = '';
            var Qty = 0;
            var TotalPrice = 0;
            var OrderValue = '';

            if (type == 'Empty') {

                var gvId = "01";

                var BiplPrice = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice_Empty" + "']").val();

                //                if (parseInt(BiplPrice) > 99) {// Commente by shubhendu
                //                    jQuery.facebox('Bipl price can not be more than 99');
                //                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice_Empty" + "']").val('');
                //                    return false;
                //                }

                Qty = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty_Empty" + "']").val();

                if (parseInt(Qty) > 0) {
                    $("#<%= gvDetailSection.ClientID %> span[id*='ctl" + gvId + "_lblQtyPcs_Empty" + "']").text('Pcs');

                    if (BiplPrice != '') {
                        TotalPrice = parseFloat(Qty) * parseFloat(BiplPrice)
                    }
                }
                else {
                    $("#<%= gvDetailSection.ClientID %> span[id*='ctl" + gvId + "_lblQtyPcs_Empty" + "']").text('');
                }

                TotalQty = Qty;
            }

            else if (type == 'Row') {

                var RowId = 0;
                var gvId;
                var GridRow = $(".gvRow").length;

                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var BiplPrice = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtBIPLPrice" + "']").val();
                    //                    if (parseInt(BiplPrice) > 99) {// commented by shubhendu
                    //                        jQuery.facebox('Bipl price can not be more than 99');
                    //                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtBIPLPrice" + "']").val('');
                    //                        return false;
                    //                    }

                    Qty = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtQty" + "']").val();
                    if (Qty == '')
                        Qty = 0;

                    if (parseInt(Qty) > 0) {
                        $("#<%= gvDetailSection.ClientID %> span[id*='" + gvId + "_lblQtyPcs" + "']").text('Pcs');

                        if (BiplPrice != '') {
                            TotalPrice = parseFloat(TotalPrice) + parseFloat(Qty) * parseFloat(BiplPrice)
                        }
                    }
                    TotalQty = parseInt(TotalQty) + parseInt(Qty);
                }
            }

            if (parseInt(TotalQty) > 0) {

                Qtytext = CommaSeprated(TotalQty);

                var ConversionRate = $("#" + hdnConversionRateClientID, "#main_content").val();

                var FinalPrice = parseFloat(ConversionRate) * parseFloat(TotalPrice);

                //updated on 2023-03-14
                if (parseFloat(FinalPrice) >= 100000) {
                    OrderValue = "(" + (parseFloat(FinalPrice) / 100000).toFixed(1).replace(/\.?0+$/, '') + " L)";
                }
                else {
                    OrderValue = "(" + (parseFloat(FinalPrice) / 100000).toFixed(1).replace(/\.?0+$/, '') + ")";
                }
                //updated on 2023-03-14

            }

            $("#" + lblRuppesClientID, "#main_content").html("&#8377;");
            $("#" + txtTotalOrderValueClientId, "#main_content").val(OrderValue);

            $("#" + txtTotalQtyClientId, "#main_content").val(Qtytext);
            $("#" + lblTotQtyUnitClientId, "#main_content").html("Pcs.");

        }

        function ValidateiKandiPrice(obj, type) {

            if (type == 'Empty') {
                var gvId = "01";

                var ikandiPrice = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtikandiPrice_Empty" + "']").val();

                if (parseInt(ikandiPrice) > 99) {
                    jQuery.facebox('ikandi price can not be more than 99');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtikandiPrice_Empty" + "']").val('');
                    return false;
                }
            }
            if (type == 'Row') {
                var gvId = obj.id.split("_")[5].substr(3);

                var ikandiPrice = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtikandiPrice" + "']").val();

                if (parseInt(ikandiPrice) > 99) {
                    jQuery.facebox('ikandi price can not be more than 99');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtikandiPrice" + "']").val('');
                    return false;
                }
            }
        }

        function onModeChange(srcElem, type) {

            var Ids = srcElem.id;
            var gvId = Ids.split("_")[5].substr(3);
            var mValue = $(srcElem).val();

            if (mValue != -1) {
                $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnMode" + "']").val(mValue);
                CalculateDeliveryDate(mValue, gvId, type, 1);
            }
        }


        function onDCChange(srcElem) {
            var Ids = srcElem.id;
            var gvId = Ids.split("_")[5].substr(3);

            var mode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode" + "']").find("option:selected").val();
            var CountryCode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlCountryCode" + "']").find("option:selected").text();

            var type = 'Row';

            proxy.invoke("GetLeadTime_Days_ByMode", { ModeID: mode, CountryCode: CountryCode },
                 function (result) {

                     var ActualExDC = result[0].ActualExDC;
                     var LeadTime = result[0].LeadTime;
                     if ((parseInt(ActualExDC) > 0) && (parseInt(LeadTime) > 0)) {

                         calculateExFactoryDate(ActualExDC, gvId, '', type);
                     }
                     else {
                         jQuery.facebox('Lead time or DC days not available for this Country! Please Select another Code');
                     }

                 });
        }


        function onCountryCodeChange(elem, type) {

            var Ids = elem.id;
            var gvId = Ids.split("_")[5].substr(3);
            var ModeId = -1;
            if (type == 'Empty') {
                ModeId = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode_Empty" + "']").find("option:selected").val();
            }
            if (type == 'Row') {
                ModeId = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode" + "']").find("option:selected").val();
            }

            CalculateDeliveryDate(ModeId, gvId, type, 0);
        }


        function CalculateDeliveryDate(mode, gvid, type, IsModeChange) {

            var CountryCode = '';
            var CountryCodeId = -1;
            var PrevLeadTime = 0;
            var OrderDetailId = -1;
            var IsSplit = 0;

            if (type == 'Empty') {
                CountryCode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlCountryCode_Empty" + "']").find("option:selected").text();
                CountryCodeId = $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlCountryCode_Empty" + "']").find("option:selected").val();

            }
            if (type == 'Row') {
                CountryCode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvid + "_ddlCountryCode" + "']").find("option:selected").text();
                CountryCodeId = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvid + "_ddlCountryCode" + "']").find("option:selected").val();
                PrevLeadTime = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnLeadTime" + "']").val();
                OrderDetailId = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnOrderDetailid" + "']").val();
                IsSplit = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnIsSplit" + "']").val();
            }

            var IsIkandiClient = $("#" + hdnIsIkandiClientID, "#main_content").val();
            var CostingID = $("#" + hdnCostingIdClientID, "#main_content").val();

            var ClientId = $("#" + BuyerDDClientID, "#main_content").find("option:selected").val();
            var DepartmentID = $("#" + DeptDDClientID, "#main_content").find("option:selected").val();

            if (ClientId > 0) {
                proxy.invoke("Get_ModeDetails_ByModeId", { IsikandiClient: IsIkandiClient, CostingId: CostingID, ClientId: ClientId, DepartmentID: DepartmentID, ModeId: mode }, function (result) {

                    if (type == 'Empty') {

                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDelivery_Empty" + "']").val(result.PackingType);
                        $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvid + "_ddlDelivery_Empty" + "']").val(result.OrderPackingType);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnAmberRangeStart_Empty" + "']").val(result.AmberRangeStart);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnAmberRangeEnd_Empty" + "']").val(result.AmberRangeEnd);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnGreenRangeStart_Empty" + "']").val(result.GreenRangeStart);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnGreenRangeEnd_Empty" + "']").val(result.GreenRangeEnd);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnRedRangeStart_Empty" + "']").val(result.RedRangeStart);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnRedRangeEnd_Empty" + "']").val(result.RedRangeEnd);

                        if (IsIkandiClient == 'true') {
                            var CurrencySign = $("#" + hdnCurrencySignClientId, "#main_content").val();
                            $("#<%= gvDetailSection.ClientID %> span[id*='ctl" + gvid + "_lblSymblikandiPrice_Empty" + "']").text(CurrencySign);
                            $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtikandiPrice_Empty" + "']").val(result.BiplPrice.toFixed(2));
                        }
                        else {
                            $("#<%= gvDetailSection.ClientID %> span[id*=ctl'" + gvid + "_lblSymblikandiPrice_Empty" + "']").text('');
                            $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtikandiPrice_Empty" + "']").val('');
                        }
                    }
                    else if (type == 'Row') {

                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDelivery" + "']").val(result.PackingType);
                        $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvid + "_ddlDelivery" + "']").val(result.OrderPackingType);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnAmberRangeStart" + "']").val(result.AmberRangeStart);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnAmberRangeEnd" + "']").val(result.AmberRangeEnd);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnGreenRangeStart" + "']").val(result.GreenRangeStart);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnGreenRangeEnd" + "']").val(result.GreenRangeEnd);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnRedRangeStart" + "']").val(result.RedRangeStart);
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnRedRangeEnd" + "']").val(result.RedRangeEnd);

                        if (IsIkandiClient == "true") {
                            var CurrencySign = $("#" + hdnCurrencySignClientId, "#main_content").val();
                            $("#<%= gvDetailSection.ClientID %> span[id*='ctl" + gvid + "_lblSymblikandiPrice" + "']").text(CurrencySign);
                            if (parseInt(result.BiplPrice) > 0) {
                                $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtikandiPrice" + "']").val(result.BiplPrice.toFixed(2));
                            }
                            else
                                $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtikandiPrice" + "']").val('');
                        }
                        else {
                            $("#<%= gvDetailSection.ClientID %> span[id*=ctl'" + gvid + "_lblSymblikandiPrice" + "']").text('');
                            $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtikandiPrice" + "']").val('');
                        }
                    }

                });
            }

            proxy.invoke("GetLeadTime_Days_ByMode", { ModeID: mode, CountryCode: CountryCode },
                 function (result) {

                     var ActualExDC = result[0].ActualExDC;
                     var LeadTime = result[0].LeadTime;

                     if ((parseInt(ActualExDC) > 0) && (parseInt(LeadTime) > 0)) {
                         if ((type == 'Row') && (parseInt(PrevLeadTime) > 0)) {
                             if (parseInt(LeadTime) == parseInt(PrevLeadTime)) {
                                 $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnCountry_CodeId" + "']").val(CountryCodeId);
                                 $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnCountryCode" + "']").val(CountryCode);


                                 //                                $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnMode" + "']").val(mode);
                                 $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnLeadTime" + "']").val(LeadTime);

                                 $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnCountry_CodeId" + "']").val(CountryCodeId);
                                 $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnCountryCode" + "']").val(CountryCode);

                                 return false;
                             }
                         }
                         var orderId = $("#" + hdnOrderIdClientID).val();

                         var LeadTimeDiff = parseInt(LeadTime) - parseInt(PrevLeadTime);

                         if ((type == 'Empty') || (parseInt(orderId) == -1)) {
                             var dd = new Date(ParseDateToSimpleDate($("#" + hdnExpectedDateClientID).val()));
                             dd = dd.add(parseInt(LeadTime) * 7).days();
                             calculateExFactoryDate(ActualExDC, gvid, dd, type);
                         }
                         else {
                             if ((parseInt(OrderDetailId) > 0) && (IsModeChange == 0)) {

                                 var DC_date = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnDC" + "']").val();
                                 var dd = new Date(ParseDateToSimpleDate(DC_date));
                                 var dd = dd.add(parseInt(LeadTimeDiff) * 7).days();

                                 calculateExFactoryDate(ActualExDC, gvid, dd, type);
                             }
                             else {
                                 if ((parseInt(OrderDetailId) <= 0) && (IsModeChange == 0)) {
                                     var DC_date = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnDC" + "']").val();
                                     var dd = new Date(ParseDateToSimpleDate(DC_date));
                                     var dd = dd.add(parseInt(LeadTimeDiff) * 7).days();

                                     calculateExFactoryDate(ActualExDC, gvid, dd, type);
                                 }
                                 else {
                                     var dd = '';
                                     calculateExFactoryDate(ActualExDC, gvid, dd, type);
                                 }
                             }
                         }
                         //
                         if (type == 'Empty') {
                             $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnMode_Empty" + "']").val(mode);
                             $("#<%= gvDetailSection.ClientID %> input[id*='ctl01_hdnCountryCodeId_Empty" + "']").val(CountryCodeId);
                         }
                         else if (type == 'Row') {
                             //$("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnMode" + "']").val(mode);
                             $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnLeadTime" + "']").val(LeadTime);

                             $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnCountry_CodeId" + "']").val(CountryCodeId);
                             $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnCountryCode" + "']").val(CountryCode);
                         }

                     }
                     else {

                         jQuery.facebox('Lead time or DC days not available for this Country! Please Select another Code');

                         if (type == 'Empty') {
                             var PrevCountryCodeId = $("#<%= gvDetailSection.ClientID %> input[id*='ctl01_hdnCountryCodeId_Empty" + "']").val();
                             $("#<%= gvDetailSection.ClientID %> select[id*='ctl01_ddlCountryCode_Empty" + "']").val(PrevCountryCodeId);
                         }
                         if (type == 'Row') {
                             var PrevCountryCodeId = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnCountry_CodeId" + "']").val();
                             $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvid + "_ddlCountryCode" + "']").val(PrevCountryCodeId);
                         }
                         return;
                     }

                 });


        }

        function calculateExFactoryDate(days, gvid, dd, type) {

            var DCDate = '';
            if (dd != '') {
                DCDate = ParseDateToDateWithDay(dd);
            }
            else {
                if (type == 'Empty') {
                    DCDate = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDC_Empty" + "']").val();
                }
                else if (type == 'Row') {
                    DCDate = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDC" + "']").val();
                }
            }
            var ExFacDate;
            if (DCDate.length > 0) {
                var dc_dat = new Date(ParseDateToSimpleDate(DCDate));

                var ExFacDate = dc_dat;
                ExFacDate = ExFacDate.add(-1 * parseInt(days)).days();

                var DCDate_new = new Date(ParseDateToSimpleDate(DCDate));

                if (ExFacDate >= DCDate_new) {
                    if (!confirm('ExFactory is Greater than DC date, Do you wish to continue!')) {
                        return false;
                    }
                }

                var orderDate = $("#" + lblOrderDateClientId, "#main_content").text();
                var order_date = new Date(ParseDateToSimpleDate(orderDate));

                if (order_date >= ExFacDate) {
                    jQuery.facebox('ExFactory date can not be less than order date');

                    if (type == 'Empty') {
                        var modeid = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnMode_Empty" + "']").val();
                        $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode_Empty" + "']").val(modeid);
                    }
                    else if (type == 'Row') {
                        var modeid = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnMode" + "']").val();
                        $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvid + "_ddlMode" + "']").val(modeid);
                    }
                    return false;
                }
                ExFacDate = ParseDateToDateWithDay(ExFacDate);
                if (type == 'Empty') {
                    if (dd != '') {
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDC_Empty" + "']").val(ParseDateToDateWithDay(dd));
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnDC_Empty" + "']").val(ParseDateToDateWithDay(dd));
                    }
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtExFactory_Empty" + "']").val(ExFacDate);
                }
                else if (type == 'Row') {
                    if (dd != '') {
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDC" + "']").val(ParseDateToDateWithDay(dd));
                        $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnDC" + "']").val(ParseDateToDateWithDay(dd));
                    }
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtExFactory" + "']").val(ExFacDate);

                }

                // Calculate Exfactory and DC week
                var msPERDAY = 1000 * 60 * 60 * 24 * 7;

                var ex_date = new Date(ParseDateToSimpleDate(ExFacDate));

                var dcdate = DCDate_new.getTime();

                var ordate = order_date.getTime();

                var exdate = ex_date.getTime();

                var diffex = new Date();

                diffex.setTime(Math.abs(exdate - ordate));

                var timediffex = diffex.getTime();

                var weeksEx = Math.round(timediffex / msPERDAY);

                var diffdc = new Date();

                diffdc.setTime(Math.abs(dcdate - ordate));

                var timediffdc = diffdc.getTime();

                var weeksDc = Math.round(timediffdc / msPERDAY);
                var weeksEx_ = "";
                var weeksDc_ = "";
                if (parseInt(weeksEx) > 0)
                    weeksEx_ = "(" + weeksEx + ")";

                if (parseInt(weeksDc) > 0)
                    weeksDc_ = "(" + weeksDc + ")";

                if (type == 'Empty') {
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtExFactoryWeek_Empty" + "']").val(weeksEx_);
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDCWeek_Empty" + "']").val(weeksDc_);

                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnExFactoryWeek_Empty" + "']").val(weeksEx);
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnDCWeek_Empty" + "']").val(weeksDc);
                }
                else if (type == 'Row') {
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtExFactoryWeek" + "']").val(weeksEx_);
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_txtDCWeek" + "']").val(weeksDc_);

                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnExFactoryWeek" + "']").val(weeksEx);
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvid + "_hdnDCWeek" + "']").val(weeksDc);
                }

                GenerateExFactoryColor(exdate, dcdate, type, gvid)

            }
        }

        function GenerateExFactoryColor(exdate, dcdate, type, gvId) {

            var start = Math.floor(exdate / (3600 * 24 * 1000)); //days as integer from..
            var end = Math.floor(dcdate / (3600 * 24 * 1000)); //days as integer from..
            var days = end - start;
            var AmberRangeStart = 0;
            var AmberRangeEnd = 0;
            var GreenRangeStart = 0;
            var GreenRangeEnd = 0;
            var RedRangeStart = 0;
            var RedRangeEnd = 0;
            var colorCode = '';

            if (type == 'Empty') {
                AmberRangeStart = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnAmberRangeStart_Empty" + "']").val();
                AmberRangeEnd = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnAmberRangeEnd_Empty" + "']").val();
                GreenRangeStart = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnGreenRangeStart_Empty" + "']").val();
                GreenRangeEnd = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnGreenRangeEnd_Empty" + "']").val();
                RedRangeStart = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnRedRangeStart_Empty" + "']").val();
                RedRangeEnd = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnRedRangeEnd_Empty" + "']").val();
            }
            else if (type == 'Row') {
                AmberRangeStart = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnAmberRangeStart" + "']").val();
                AmberRangeEnd = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnAmberRangeEnd" + "']").val();
                GreenRangeStart = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnGreenRangeStart" + "']").val();
                GreenRangeEnd = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnGreenRangeEnd" + "']").val();
                RedRangeStart = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnRedRangeStart" + "']").val();
                RedRangeEnd = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnRedRangeEnd" + "']").val();
            }
            if (days >= RedRangeStart && days <= RedRangeEnd)
                colorCode = "#ff3300";
            else if (days <= AmberRangeEnd && days >= AmberRangeStart)
                colorCode = "#fd9903";
            else if (days <= GreenRangeEnd && days >= GreenRangeStart)
                colorCode = "#00FF70";
            else
                colorCode = "#fd9903";

            if (type == 'Empty') {
                var gId = "ctl01";
                $("#<%= gvDetailSection.ClientID %>_" + gId + "_tdExFactory_Empty").css("background-color", colorCode);
                $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnExFactoryColor_Empty" + "']").val(colorCode);
            }
            else if (type == 'Row') {
                $("#<%= gvDetailSection.ClientID %>_ctl" + gvId + "_tdExFactory").css("background-color", colorCode);
                $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnExFactoryColor" + "']").val(colorCode);
            }
        }

        function ValidateContractDetails(elem, type) {
            var Ids = elem.id;
            var gvId = Ids.split("_")[5].substr(3);

            if (type == 'Empty') {

                var Quantity = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty_Empty" + "']").val();
                if (Quantity == '')
                    Quantity = 0;
                if (parseInt(Quantity) == 0) {
                    jQuery.facebox('Please fill Quantity');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty_Empty" + "']").focus();
                    return false;
                }
                var Mode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode_Empty" + "']").val();
                if (Mode == '-1') {
                    jQuery.facebox('Please select mode');
                    $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode_Empty" + "']").focus();
                    return false;
                }
                var CountryCode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlCountryCode_Empty" + "']").val();
                if (CountryCode == '-1') {
                    jQuery.facebox('Please select Country Code');
                    $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlCountryCode_Empty" + "']").focus();
                    return false;
                }
                var BiplPrice = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice_Empty" + "']").val();
                if (BiplPrice == '')
                    BiplPrice = 0;
                if (parseInt(BiplPrice) == 0) {
                    jQuery.facebox('Please BiplPrice can not be empty');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice_Empty" + "']").focus();
                    return false;
                }
            }
            else if (type == 'Row') {
                var Quantity = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty" + "']").val();
                if (Quantity == '')
                    Quantity = 0;
                if (parseInt(Quantity) == 0) {
                    jQuery.facebox('Please fill Quantity');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty" + "']").focus();
                    return false;
                }
                var Mode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode" + "']").val();
                if (Mode == '-1') {
                    jQuery.facebox('Please select mode');
                    $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode" + "']").focus();
                    return false;
                }
                var BiplPrice = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice" + "']").val();
                if (BiplPrice == '')
                    BiplPrice = 0;
                if (parseInt(BiplPrice) == 0) {
                    jQuery.facebox('Please BiplPrice can not be empty');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice" + "']").focus();
                    return false;
                }
            }
            else if (type == 'DeleteRow') {
                var isYes = confirm("Do you want to delete this contract");
                if (isYes == false) {
                    return false;
                }
            }
        }

        function ValidateSubmit(type) {

            var styleNumber = $("#" + txtStyleNumberClientID, "#main_content").val();
            if (styleNumber == '') {
                jQuery.facebox('Please fill Style number');
                $("#" + txtStyleNumberClientID, "#main_content").focus();
                return false;
            }
            var Client = $("#" + BuyerDDClientID, "#main_content").find("option:selected").text();
            if (Client == 'Select..') {
                jQuery.facebox('Please select Buyer');
                $("#" + BuyerDDClientID, "#main_content").focus();
                return false;
            }
            var ParentDept = $("#" + ParentDeptDDClientID, "#main_content").find("option:selected").text();
            if (ParentDept == 'Select..') {
                jQuery.facebox('Please select Parent Department');
                $("#" + ParentDeptDDClientID, "#main_content").focus();
                return false;
            }
            var Dept = $("#" + DeptDDClientID, "#main_content").find("option:selected").text();
            if (Dept == 'Select..') {
                jQuery.facebox('Please select department');
                $("#" + DeptDDClientID, "#main_content").focus();
                return false;
            }

            var IshdnEmpty = $("#" + hdnIsEmptyRowClientId, "#main_content").val();
            if (IshdnEmpty == '1') {
                var gvId = "01";
                var Quantity = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty_Empty" + "']").val();
                if (Quantity == '')
                    Quantity = 0;
                if (parseInt(Quantity) == 0) {
                    jQuery.facebox('Please fill Quantity');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty_Empty" + "']").focus();
                    return false;
                }
                var Mode = $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode_Empty" + "']").val();
                if (Mode == '-1') {
                    jQuery.facebox('Please select mode');
                    $("#<%= gvDetailSection.ClientID %> select[id*='ctl" + gvId + "_ddlMode_Empty" + "']").focus();
                    return false;
                }

                var BiplPrice = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice_Empty" + "']").val();
                if (BiplPrice == '')
                    BiplPrice = 0;
                if (parseInt(BiplPrice) == 0) {
                    jQuery.facebox('BiplPrice can not be empty');
                    $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtBIPLPrice_Empty" + "']").focus();
                    return false;
                }
            }
            else {
                // Basic Section validation
                var RowId = 0;
                var gvId;
                var GridRow = $(".gvRow").length;

                for (var row = 1; row <= GridRow; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var Qty = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtQty" + "']").val();
                    if (Qty == '')
                        Qty = 0;

                    if (parseInt(Qty) == 0) {
                        jQuery.facebox('Please fill Quantity');
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtQty" + "']").focus();
                        return false;
                    }
                    var Mode = $("#<%= gvDetailSection.ClientID %> select[id*='" + gvId + "_ddlMode" + "']").val();
                    if (Mode == '-1') {
                        jQuery.facebox('Please select mode');
                        $("#<%= gvDetailSection.ClientID %> select[id*='" + gvId + "_ddlMode" + "']").focus();
                        return false;
                    }
                    var BiplPrice = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtBIPLPrice" + "']").val();
                    if (BiplPrice == '')
                        BiplPrice = 0;
                    if (parseInt(BiplPrice) == 0) {
                        jQuery.facebox('BiplPrice can not be empty');
                        $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_txtBIPLPrice" + "']").focus();
                        return false;
                    }
                    // Fabric Section validation
                    //
                    var FabId = '';
                    var FabRow = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric td").length;

                    for (var Count = 0; Count < FabRow; Count++) {
                        FabId = 'ctl0' + Count;

                        var FabricDetail = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + FabId + "_txtFabricDetail").val();
                        if (FabricDetail == '') {
                            jQuery.facebox('Fabric color/Print can not be empty');
                            $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + FabId + "_txtFabricDetail").focus();
                            return false;
                        }
                    }

                    // Accessory Section validation
                    //
                    var AccessId = '';
                    var AccessRow = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstAccessories td").length;

                    for (var Count = 0; Count < AccessRow; Count++) {
                        AccessId = 'ctl0' + Count;

                        var AccessDetail = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstAccessories_" + AccessId + "_txtAccessVal_").val();
                        if (AccessDetail == '') {
                            jQuery.facebox('Accessory color/Print can not be empty');
                            $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstAccessories_" + AccessId + "_txtAccessVal_").focus();
                            return false;
                        }
                    }
                }
            }


            if (type == 1) {
                $('.submitbtn').css("display", "none");
            }
            SpinnShow();
        }

        function OpenForikandi() {
            //
            var orderId = '<%=this.OrderID %>';
            proxy.invoke("OpenOrderForikandi", { OrderId: orderId, IsClose: 0 },
            function (result) {
                $('.OpenDialog').hide();
            });
            SpinnHide();
            return false;
        }

        function OpenForikandiBox() {
            $('.OpenDialog').show();
        }

        function HideOpenForikandiBox() {

            var orderId = '<%=this.OrderID %>';
            proxy.invoke("OpenOrderForikandi", { OrderId: orderId, IsClose: 1 },
            function (result) {
                $('.OpenDialog').hide();
            });
            SpinnHide();
            return false;
        }

        function DownloadFile(sPath) {
            window.open(sPath, '_blank');
            return false;
        }

        function CheckAgreementFromPage() {
            var chkagreeClientID = '<%=chkagree.ClientID %>';
            $("#" + chkagreeClientID, "#main_content").attr('checked', 'checked');
            $(".tooltiptext_L").attr("style", "visibility:visible !important");
            $(".tooltiptext_M").attr("style", "visibility:visible !important");
            $(".tooltiptext_S").attr("style", "visibility:visible !important");
            $(".tooltiptext_Day").attr("style", "visibility:visible !important");
            $(".fabric_detail").attr("style", "visibility:visible !important");
            $(".Accessory_detail").attr("style", "visibility:visible !important");
        }

        function CheckAgreement(elem) {

            if (elem.checked) {
                $(".tooltiptext_L").attr("style", "visibility:visible !important");
                $(".tooltiptext_M").attr("style", "visibility:visible !important");
                $(".tooltiptext_S").attr("style", "visibility:visible !important");
                $(".tooltiptext_Day").attr("style", "visibility:visible !important");
                $(".fabric_detail").attr("style", "visibility:visible !important");
                $(".Accessory_detail").attr("style", "visibility:visible !important");
            }
            else {
                $(".tooltiptext_L").removeAttr("style");
                $(".tooltiptext_M").removeAttr("style");
                $(".tooltiptext_S").removeAttr("style");
                $(".tooltiptext_Day").removeAttr("style");
                $(".fabric_detail").removeAttr("style");
                $(".Accessory_detail").removeAttr("style");
            }
        }
        function closeAccesButtion() {
            $("#dvFileUpload").hide();
        }

        function splitOrder(obj) {

            var Ids = obj.id;
            var gvId = Ids.split("_")[5].substr(3);
            var LineNo = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtLineNo" + "']").val();
            var ContractNo = $("#<%= gvDetailSection.ClientID %> textarea:input[id*='ctl" + gvId + "_txtContractNo" + "']").val();
            var Quantity = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty" + "']").val();
            var OrderDetailId = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnOrderDetailid" + "']").val();

            var lblLineNo = '<%=lblLineNo.ClientID %>';
            var lblContractNo = '<%=lblContractNo.ClientID %>';
            var txtTotalSplitQty = '<%=txtTotalSplitQty.ClientID %>';
            var hdnTotalSplitQty = '<%=hdnTotalSplitQty.ClientID %>';
            var hdnOrderDetailId = '<%=hdnOrderDetailId_Split.ClientID %>';

            $("#" + lblLineNo, "#main_content").html(LineNo);
            $("#" + lblContractNo, "#main_content").html(ContractNo);
            $("#" + txtTotalSplitQty, "#main_content").val(CommaSeprated(Quantity));
            $("#" + hdnTotalSplitQty, "#main_content").val(Quantity);
            $("#" + hdnOrderDetailId, "#main_content").val(OrderDetailId);

            var txtSplitRemainingQty = '<%=txtSplitRemainingQty.ClientID %>';
            var hdnSplitRemainingQty = '<%=hdnSplitRemainingQty.ClientID %>';
            $("#" + txtSplitRemainingQty, "#main_content").val(CommaSeprated(Quantity));
            $("#" + hdnSplitRemainingQty, "#main_content").val(Quantity);

            $("#dvSplit").css("display", "block");
        }
        function validateSplitNo() {
            var txtSplitNo = '<%=txtSplitNo.ClientID %>';
            var lblSplitMsg = '<%=lblSplitMsg.ClientID %>';
            var txtTotalSplitQty = '<%=txtTotalSplitQty.ClientID %>';

            if ($("#" + txtTotalSplitQty, "#main_content").val() == '') {
                $("#" + lblSplitMsg, "#main_content").html('Total Qty can not be Empty');
                return false;
            }
            else if ($("#" + txtSplitNo, "#main_content").val() == '') {
                $("#" + lblSplitMsg, "#main_content").html('Please Enter No. Of Splits');
                //return false;
            }
            else if (parseInt($("#" + txtSplitNo, "#main_content").val()) <= 1) {
                $("#" + lblSplitMsg, "#main_content").html('Please Enter minimum 2');
                return false;
            }
            else {
                $("#" + lblSplitMsg, "#main_content").html('');
                return true;
            }
        }

        function validateAllSplit() {

            var hdnTotalSplitQty = '<%=hdnTotalSplitQty.ClientID %>';
            var TotalQty = $("#" + hdnTotalSplitQty, "#main_content").val();

            var lblSplitMsg = '<%=lblSplitMsg.ClientID %>';

            var txtSplitNo = '<%=txtSplitNo.ClientID %>';

            var Quantity = 0;

            var rptRows = $("#" + txtSplitNo, "#main_content").val();
            var gvId = '';
            for (var row = 0; row < rptRows; row++) {
                if (row < 10)
                    gvId = 'ctl0' + row;
                else
                    gvId = 'ctl' + row;

                var SplitQty = document.getElementById("ctl00_cph_main_content_rptSplit_" + gvId + "_" + "txtSplitQty").value;
                if ((SplitQty == '') || (SplitQty == '0')) {
                    $("#" + lblSplitMsg, "#main_content").html('Split Qty can not be Empty or zero');
                    return false;
                }
                else {
                    Quantity = Quantity + parseInt(SplitQty);
                }
            }
            if (Quantity < TotalQty) {
                $("#" + lblSplitMsg, "#main_content").html('Split Qty can not be less than Total Qty');
                return false;
            }
            else if (Quantity > TotalQty) {
                $("#" + lblSplitMsg, "#main_content").html('Split Qty can not be greater than Total Qty');
                return false;
            }
        }

        function BalanceSplitQty(obj) {

            var txtSplitRemainingQty = '<%=txtSplitRemainingQty.ClientID %>';
            var hdnSplitRemainingQty = '<%=hdnSplitRemainingQty.ClientID %>';
            var hdnTotalSplitQty = '<%=hdnTotalSplitQty.ClientID %>';
            var txtSplitNo = '<%=txtSplitNo.ClientID %>';
            var lblSplitMsg = '<%=lblSplitMsg.ClientID %>';

            var TotalQty = $("#" + hdnTotalSplitQty, "#main_content").val();
            var Quantity = 0;

            var rptRows = $("#" + txtSplitNo, "#main_content").val();
            var gvId = '';
            for (var row = 0; row < rptRows; row++) {
                if (row < 10)
                    gvId = 'ctl0' + row;
                else
                    gvId = 'ctl' + row;

                var SplitQty = document.getElementById("ctl00_cph_main_content_rptSplit_" + gvId + "_" + "txtSplitQty").value;
                if (SplitQty != '') {
                    Quantity = Quantity + parseInt(SplitQty);
                }
                else {
                    document.getElementById("ctl00_cph_main_content_rptSplit_" + gvId + "_" + "txtSplitQty").value = '';
                }
            }
            var remainQty = parseInt(TotalQty) - parseInt(Quantity);
            if (remainQty == 0) {
                $("#" + txtSplitRemainingQty, "#main_content").val("");
            }
            else {
                $("#" + txtSplitRemainingQty, "#main_content").val(CommaSeprated(remainQty));
            }
            $("#" + hdnSplitRemainingQty, "#main_content").val(remainQty);
            $("#" + lblSplitMsg, "#main_content").html('');


        }

        function SpiltContactClose() {
            $("#dvSplit").hide();
        }

        function ShowSizeSet(obj) {

            var Ids = obj.id;
            var gvId = Ids.split("_")[5].substr(3);
            var clientId = $("#" + BuyerDDClientID, "#main_content").val();
            var DeptId = $("#" + DeptDDClientID, "#main_content").val();
            var LineNo = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtLineNo" + "']").val();
            var ContractNo = $("#<%= gvDetailSection.ClientID %> textarea:input[id*='ctl" + gvId + "_txtContractNo" + "']").val();
            var Quantity = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_txtQty" + "']").val();
            var OrderDetailId = $("#<%= gvDetailSection.ClientID %> input[id*='ctl" + gvId + "_hdnOrderDetailid" + "']").val();

            var urls = '../../Internal/Sales/OrderPlaceSizeSet.aspx?OrderDetailId=' + OrderDetailId + '&Quantity=' + Quantity + '&ContractNumber=' + ContractNo + '&LineNumber=' + LineNo + '&ClientId=' + clientId + '&DeptId=' + DeptId;

            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: urls, type: "iframe", player: "iframe", title: "", height: 250, width: 820, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;

        }
        function ShowFabric() {

            var orderId = $("#" + hdnOrderIdClientID).val();
            if (parseInt(orderId) > -1) {
                var FabricUrl = "../../Internal/Fabric/FabricCutOrderAvg.aspx?orderid=" + orderId;
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: FabricUrl, type: "iframe", player: "iframe", title: "", height: 310, width: 685, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            }
            return false;
        }
        function Setwidthwastagescreen(width, Height) {
            //  alert(width); 

            //  if (width <= 1221) {
            //    $("#sb-wrapper").css("width", parseInt(width) - 5 + "px");
            // }
            if (width == 712) {
                $("#sb-wrapper").css("width", parseInt(width) - 2 + "px");
                $("#sb-wrapper").css("left", "325px");
            }
            if (Height <= 400) {
                $("#sb-wrapper-inner").css("height", parseInt(Height) + 100 + "px");
            }

        }
        function ShowAccess() {

            var orderTabId = 2; // code added by bharat on 26-june for new tab close
            var orderId = $("#" + hdnOrderIdClientID).val();
            if (parseInt(orderId) > -1) {
                var AccessoriesUrl = "../../Internal/Sales/AccessoryOrdersSummary.aspx?orderid=" + orderId + '&OrderTab=' + orderTabId;
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: AccessoriesUrl, type: "iframe", player: "iframe", title: "", height: 350, width: 970, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            }

            return false;
        }
        function AccessoryDetailsScreen(width, Height) {
            if (width <= 1221) {
                $("#sb-wrapper").css("width", parseInt(width) - 5 + "px");
            }
            if (width <= 712) {
                $("#sb-wrapper").css("left", "250px");
            }
            if (Height <= 400) {
                $("#sb-wrapper-inner").css("height", parseInt(Height) + 100 + "px");
            }
        }

        function numbersonly(elem) {

            var value = elem.value;
            if (value != "") {
                if (value == undefined) {
                    var regs = /^\d*[0-9](\d*[0-9])?$/;
                    if (value != "") {
                        if (regs.exec(elem) && elem.srcElement.value.split('.').length > 1) {
                            return true;
                        }
                        else {
                            //elem.value = elem.defaultValue;
                            elem.value = "";
                            return false;
                        }
                    }
                }
                else {
                    //var regs = /^\d*[0-9](\.\d*[0-9])?$/;
                    var regs = /^(-)?\d+(\d\d)?$/;
                    if (value != "") {
                        if (regs.exec(value) && elem.srcElement.value.split('.').length > 1) {
                            return true;
                        }
                        else {
                            // elem.value = elem.defaultValue;
                            elem.value = "";
                            return false;
                        }
                    }
                }
            }

        }

        function openContent(obj, divname, IsGlobal) {

            if (IsGlobal == 0) {
                $(obj).addClass("clsActive");
                $(".tabcom").not(obj).removeClass("clsActive");
            }
            var orderId = $("#" + hdnOrderIdClientID).val();
            var SerialNumber = $("#" + txtSerialNoClientID, "#main_content").val();

            if (divname == 'dvHistory') {
                $('#ctl00_cph_main_content_dvHistory').css("display", "");
                $('#ctl00_cph_main_content_dvComment').css("display", "none");
                $('#ctl00_cph_main_content_dvOldHistory').css("display", "none");
                $('#ctl00_cph_main_content_dvOldComment').css("display", "none");
                $(".CommentShowhide").hide();

                $(".historyth").not(this).parent().removeClass("clsActiveth");
                var hlnkAll_HistoryClientId = '<%=hlnkAll_History.ClientID %>';

                $("#" + hlnkAll_HistoryClientId, "#main_content").parent().addClass("clsActiveth");
                var typeflag = 0;

                if (parseInt(orderId) > -1) {
                    proxy.invoke("Get_Order_History", { OrderId: orderId, Typeflag: typeflag },
                    function (result) {
                        var History = result;
                        var vDesc = '';
                        $(History).each(function () {
                            if (this.DetailDescription.toString() != "") {
                                vDesc = vDesc + '<li>' + this.DetailDescription + '</li>';
                            }
                        });
                        $(".HistoryDescription").html(vDesc);
                    });
                }
            }
            else if (divname == 'dvComment') {

                $('#ctl00_cph_main_content_dvHistory').css("display", "none");
                $('#ctl00_cph_main_content_dvComment').css("display", "");
                $('#ctl00_cph_main_content_dvOldHistory').css("display", "none");
                $('#ctl00_cph_main_content_dvOldComment').css("display", "none");
                $(".CommentShowhide").hide();

                $("#rptDivComment").removeClass("CommentHeight2");
                $("#rptDivComment").addClass("CommentHeight1");

                $(".historyth").not(this).parent().removeClass("clsActiveth");

                var hlnkAll_CommentClientId = '<%=hlnkAll_Comment.ClientID %>';
                $("#" + hlnkAll_CommentClientId, "#main_content").parent().addClass("clsActiveth");

                var typeflag = 0;
                if (parseInt(orderId) > -1) {
                    proxy.invoke("Get_Order_Comment", { OrderId: orderId, SerialNo: SerialNumber, Typeflag: typeflag },
                    function (result) {

                        var Comment = result;
                        var vDesc = '';
                        $(Comment).each(function () {
                            if (this.DetailDescription.toString() != '') {


                                vDesc = vDesc + '<li>' + this.DetailDescription + '</li>';
                            }

                        });
                        $(".CommentDescription").html(vDesc);
                    });
                }

            }

            //new code add
            else if (divname == 'dvOldComment') {

                $('#ctl00_cph_main_content_dvHistory').css("display", "none");
                $('#ctl00_cph_main_content_dvComment').css("display", "none");
                $('#ctl00_cph_main_content_dvOldHistory').css("display", "none");
                $('#ctl00_cph_main_content_dvOldComment').css("display", "");
                $(".CommentShowhide").hide();
                //$(".OldCommentShowhide").hide();

                $("#rptDivComment").removeClass("CommentHeight2");
                $("#rptDivComment").addClass("CommentHeight1");


                $(".historyth").not(this).parent().removeClass("clsActiveth");

                var hlnkAll_CommentClientId = '<%=hlnkAll_OldComment.ClientID %>';
                $("#" + hlnkAll_CommentClientId, "#main_content").parent().addClass("clsActiveth");
                var typeflag = 11;
                var Type = 0;
                if (parseInt(orderId) > -1) {
                    proxy.invoke("Get_Old_Order_History", { OrderId: orderId, Typeflag: typeflag, Type: Type },
                    function (result) {

                        var Comment = result;
                        var vDesc = '';
                        $(Comment).each(function () {

                            if (this.Comments.toString() != '') {

                                vDesc = vDesc + '<li>' + this.Comments + '</li>';
                            }
                        });
                        $(".OldCommentDescription").html(vDesc);
                    });
                }

            }

            else if (divname == 'dvOldHistory') {

                $('#ctl00_cph_main_content_dvHistory').css("display", "none");
                $('#ctl00_cph_main_content_dvComment').css("display", "none");
                $('#ctl00_cph_main_content_dvOldHistory').css("display", "");
                $('#ctl00_cph_main_content_dvOldComment').css("display", "none");
                $(".CommentShowhide").hide();


                $("#rptDivComment").removeClass("CommentHeight2");
                $("#rptDivComment").addClass("CommentHeight1");

                $(".historyth").not(this).parent().removeClass("clsActiveth");

                var hlnkAll_HistoryClientId = '<%=hlnkAll_OldHistory.ClientID %>';
                $("#" + hlnkAll_HistoryClientId, "#main_content").parent().addClass("clsActiveth");
                var typeflag = 11;
                var Type = 1;
                if (parseInt(orderId) > -1) {
                    proxy.invoke("Get_Old_Order_History", { OrderId: orderId, Typeflag: typeflag, Type: Type },
                    function (result) {

                        var Comment = result;
                        var vDesc = '';
                        $(Comment).each(function () {
                            //                          vDesc = vDesc + '<li>' + this.History + '</li>';

                            if (Comment.toString() != "") {
                                vDesc = vDesc + this.History;
                            }
                        });
                        $(".OldHistoryDescription").html(vDesc);
                    });
                }

            }
            //new code end
        }


        //new code start 08-12-2020
        function ShowOldHistory(obj, typeflag) {

            $(obj).parent().addClass("clsActiveth");
            $(".historyth").not(obj).parent().removeClass("clsActiveth");

            var orderId = $("#" + hdnOrderIdClientID).val();
            var typeflag = typeflag;
            var Type = 1;
            if (parseInt(orderId) > -1) {
                proxy.invoke("Get_Old_Order_History", { OrderId: orderId, Typeflag: typeflag, Type: Type },
                    function (result) {
                        //
                        var History = result;
                        var vDesc = '';
                        $(History).each(function () {
                            //vDesc = vDesc + '<li>' + this.History + '</li>';
                            vDesc = vDesc + this.History;
                        });
                        $(".OldHistoryDescription").html(vDesc);

                    });
            }
        }
        function ShowOldComment(obj, typeflag) {

            $(obj).parent().addClass("clsActiveth");
            $(".historyth").not(obj).parent().removeClass("clsActiveth");

            var orderId = $("#" + hdnOrderIdClientID).val();
            if (typeflag == 0) {
                $(".OldCommentShowhide").hide();

                $("#rptDivComment").removeClass("CommentHeight2");
                $("#rptDivComment").addClass("CommentHeight1");
            }
            else {
                $(".OldCommentShowhide").show();
                $("#rptDivComment").removeClass("CommentHeight1");
                $("#rptDivComment").addClass("CommentHeight2");
            }
            var typeflag = typeflag;
            var Type = 0;
            if (parseInt(orderId) > -1) {
                //
                proxy.invoke("Get_Old_Order_History", { OrderId: orderId, Typeflag: typeflag, Type: Type },
                    function (result) {
                        var Comment = result;
                        var vDesc = '';
                        $(Comment).each(function () {
                            //vDesc = vDesc + '<li>' + this.Comments + '</li>';
                            if (this.DetailDescription != '') {
                                vDesc = vDesc + '<li>' + this.Comments + '</li>';
                            }
                        });
                        $(".OldCommentDescription").html(vDesc);
                    });
            }
        }


        //new code end 08-12-2020

        function ShowHistory(obj, typeflag) {
            $(obj).parent().addClass("clsActiveth");
            $(".historyth").not(obj).parent().removeClass("clsActiveth");

            var orderId = $("#" + hdnOrderIdClientID).val();
            var typeflag = typeflag;

            if (parseInt(orderId) > -1) {
                proxy.invoke("Get_Order_History", { OrderId: orderId, Typeflag: typeflag },
                    function (result) {
                        //
                        var History = result;
                        var vDesc = '';
                        $(History).each(function () {
                            if (this.DetailDescription.toString() != "") {
                                vDesc = vDesc + '<li>' + this.DetailDescription + '</li>';
                            }
                        });
                        $(".HistoryDescription").html(vDesc);
                    });
            }
        }


        function AddComment() {

            var orderId = $("#" + hdnOrderIdClientID).val();
            var SerialNumber = $("#" + txtSerialNoClientID, "#main_content").val();
            var typeflag = CommentFlag;
            var CommentClientId = '<%=txtComment.ClientID %>';
            var Comment = $("#" + CommentClientId).val();
            if (Comment == '') {
                jQuery.facebox('Please Enter Comment');
                return false;
            }
            //            if (parseInt(orderId) > -1) {
            proxy.invoke("Create_Order_Comment", { OrderId: orderId, SerialNo: SerialNumber, TypeFlag: typeflag, Comment: Comment },
                    function (success) {
                        //
                        proxy.invoke("Get_Order_Comment", { OrderId: orderId, SerialNo: SerialNumber, Typeflag: typeflag },
                            function (result) {
                                //
                                var Comment = result;
                                var vDesc = '';
                                $(Comment).each(function () {
                                    if (this.DetailDescription.toString() != "") {
                                        vDesc = vDesc + '<li>' + this.DetailDescription + '</li>';
                                    }
                                });
                                $(".CommentDescription").html(vDesc);
                            });

                        $("#" + CommentClientId).val('');
                    });
            //}
            return false;
        }

        function ShowComment(obj, typeflag) {

            $(obj).parent().addClass("clsActiveth");
            $(".historyth").not(obj).parent().removeClass("clsActiveth");

            var SerialNumber = $("#" + txtSerialNoClientID, "#main_content").val();
            var orderId = $("#" + hdnOrderIdClientID).val();
            if (typeflag == 0) {
                $(".CommentShowhide").hide();
                $("#rptDivComment").removeClass("CommentHeight2");
                $("#rptDivComment").addClass("CommentHeight1");
            }
            else {
                $(".CommentShowhide").show();
                $("#rptDivComment").removeClass("CommentHeight1");
                $("#rptDivComment").addClass("CommentHeight2");
            }
            CommentFlag = typeflag;

            //if (parseInt(orderId) > -1) {
            //
            proxy.invoke("Get_Order_Comment", { OrderId: orderId, SerialNo: SerialNumber, Typeflag: typeflag },
                    function (result) {
                        var Comment = result;
                        var vDesc = '';
                        $(Comment).each(function () {
                            if (this.DetailDescription.toString() != "") {
                                vDesc = vDesc + '<li>' + this.DetailDescription + '</li>';
                            }
                        });
                        $(".CommentDescription").html(vDesc);
                    });
            // }
        }

        function blockSpecialChar(e) {

            var k = e.keyCode;
            return ((k > 64 && k < 91) || (k >= 91 && k < 123) || k == 8 || (k >= 47 && k <= 57) || k == 40 || k == 41 || k == 45 || k == 32);
        }

        function alphaOnly(evt) {

            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                  ((evt.which) ? evt.which : 0));

            if (charCode == 47) {
                return true;
            }
            if (charCode > 32 && (charCode < 65 || charCode > 90) &&
                  (charCode < 97 || charCode > 122)) {
                return false;
            }
            return true;
        }

        function allowAlphaNumericSpace(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                  ((evt.which) ? evt.which : 0));

            if (//!(code == 32) && // space
                !(code > 47 && code < 58) && // numeric (0-9)
                !(code > 64 && code < 91) && // upper alpha (A-Z)
                !(code > 96 && code < 123)) { // lower alpha (a-z)
                e.preventDefault();
            }
        }



        function ValidateFabricColorPrint(obj) {
         
            var MaxCha = $(obj).val().length;
            var FabricColor = $(obj).val();

            if (FabricColor == '') {
                jQuery.facebox('Please Enter Fabric color/print');
                return false;
            }

            if (FabricColor.toUpperCase() == 'TBC') {
                jQuery.facebox('Please Enter TBD instead of TBC!');
                $(obj).val('');
                return false;
            }


            if (MaxCha > 30) {
                $(obj).attr('title', FabricColor);
            }

            if (MaxCha > 2) {

                var gvId = $(obj)[0].id.split("_")[5];
                var thisId = $(obj)[0].id.split("_")[7];

                var thisFabriQualityId = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + thisId + "_hdnFabriQualityId").val();
                var thisFabricType = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + thisId + "_txtFabricType").val();
                var thisFabricDetail = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + thisId + "_txtFabricDetail").val();

                var RowId = 0;
                var ListId;
                var FabRow = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric td").length;
                for (var row = 0; row < FabRow; row++) {
                    RowId = parseInt(row);
                    ListId = 'ctl0' + RowId;
                    if (thisId != ListId) {
                        var FabriQualityId = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + ListId + "_hdnFabriQualityId").val();
                        var FabricType = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + ListId + "_txtFabricType").val();
                        var FabricDetail = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + ListId + "_txtFabricDetail").val();

                        if ((thisFabriQualityId == FabriQualityId) && (thisFabricType == FabricType) && (thisFabricDetail == FabricDetail)) {
                            jQuery.facebox('Color_Print Cannot be duplicate in same quality.');
                            $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstFabric_" + thisId + "_txtFabricDetail").val('');
                            return;
                        }
                    }
                }
            }
        }

        function ValidateAccessoryColor(obj, type) {

            var AccessoryColor = $(obj).val();

            if (AccessoryColor == '') {
                jQuery.facebox('Please Enter Accessory color');
                return false;
            }

            if (AccessoryColor.toUpperCase() == 'TBC') {
                jQuery.facebox('Please Enter TBD instead of TBC!');
                $(obj).val('');
                return false;
            }
            //            if (AccessoryColor.toUpperCase() == "GREEN" || AccessoryColor.toUpperCase() == "BLUE" || AccessoryColor.toUpperCase() == "PINK" || AccessoryColor.toUpperCase() == "RED" || AccessoryColor.toUpperCase() == "YELLOW") {
            //                $(obj).removeAttr("title");
            //                $(obj).attr("title", AccessoryColor);
            //            }
            //            else {
            //                alert("Please Enter Valid Colour name");
            //            }

            //            if (type == 'Empty') {              

            //                var gvId = $(obj)[0].id.split("_")[5];
            //                var thisId = $(obj)[0].id.split("_")[7];

            //                var IsDefault = $("#<%= gvDetailSection.ClientID %> input[id*='" + gvId + "_hdnIsDefaultAccess_" + thisId + "']").val();
            //                if ((IsDefault == '0') && (AccessoryColor.toUpperCase() == 'N/A')){
            //                    jQuery.facebox('Please use TBD if color is not available!');
            //                    $(obj).val('');
            //                    return false;
            //                }
            //            }
            //            else {
            //                var gvId = $(obj)[0].id.split("_")[5];
            //                var thisId = $(obj)[0].id.split("_")[7];

            //                var IsDefault = $("#ctl00_cph_main_content_gvDetailSection_" + gvId + "_dlstAccessories_" + thisId + "_hdnIsDefaultAccess").val();
            //                if ((IsDefault == '0') && (AccessoryColor.toUpperCase() == 'N/A')) {
            //                    jQuery.facebox('Please use TBD if color is not available!');
            //                    $(obj).val('');
            //                    return false;
            //                }
            //            }


            return false;
        }
        function CommaSeprated(num) {
            return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
        }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="pnl1" UpdateMode="Always" runat="server">
        <ContentTemplate>
            <div id="spinnL">
            </div>
            <asp:Panel runat="server" ID="pnlForm">
                <div style="width: 100%; margin: 0 auto; margin-bottom: 10px;">
                    <h2 style="background: #39589C; position: relative; font-family: Calibri, sans-serif;
                        text-align: center; color: #e7e4fb; font-size: 15px; margin: 5px 0px 5px; padding: 4px;
                        width: 99%; border: 1px solid Gray">
                        <span style="position: absolute; left: 5px; font-size: 12px !important">Order Date:
                            &nbsp;
                            <asp:Label ID="lblOrderDate" runat="server" Text=""></asp:Label></span>
                        <asp:CheckBox ID="chkagree" Visible="false" onclick="CheckAgreement(this);" runat="server"
                            Style="position: absolute; left: 45.5%;" />
                        &nbsp;&nbsp; <span style="position: absolute; left: 47.6%;">Order Form</span>
                    </h2>
                    <table class="item_list1 paddingLeft" border="1" cellpadding="0" cellspacing="0"
                        style="width: 99.7%">
                        <tbody>
                            <tr>
                                <th style="text-align: left; width: 10%">
                                    Style Number<span class="da_astrx_mand">*</span>
                                </th>
                                <td style="width: 12%" class="textboxwidth">
                                    <asp:TextBox runat="server" ID="txtStyleNumber" Style="text-align: left; font-size: 12px;
                                        font-weight: bold;" Width="100%" validate="required:true" ToolTip="Style Number Is Required"
                                        CssClass="style-number  Bold_Black"></asp:TextBox>
                                    <asp:HiddenField ID="hdnStyleNumber" runat="server" />
                                    <asp:HiddenField ID="hdnStyleID" runat="server" />
                                    <asp:HiddenField ID="hdnParentStyleID" runat="server" />
                                    <asp:HiddenField ID="hdnParentStyleNumber" runat="server" />
                                    <asp:HiddenField ID="hdnOldStyleId" runat="server" />
                                </td>
                                <td colspan="2" style="text-align: left; width: 15%">
                                    <div class="style20 CheckOrder">
                                        Repeat with changes &nbsp;&nbsp;
                                        <input id="chkRepeatOrder" onclick="ShowAddStyleNumberBox(this)" type="checkbox" />
                                        <asp:HiddenField ID="hdnRepeatOrder" Value="0" runat="server" />
                                        <asp:HiddenField ID="hdnRepeatWithChanges" Value="0" runat="server" />
                                        <asp:HiddenField ID="hdnuserid" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnStatusModeSequence" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnOrderType" runat="server" Value="1" />
                                        <asp:HiddenField ID="hdnIsIkandiUser" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnIsIkandiClient" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnExpectedDate" runat="server" Value="" />
                                        <asp:HiddenField ID="hdnCostingId" runat="server" Value="" />
                                        <asp:HiddenField ID="hdnCurrencySign" runat="server" Value="" />
                                        <asp:HiddenField ID="hdnIsEmptyRow" runat="server" Value="0" />
                                        <asp:HiddenField ID="IsAccessSubmit" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnFileUpload" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnSplittedContractCount" Value="0" runat="server" />
                                    </div>
                                </td>
                                <th style="width: 17%; text-align: center">
                                    Front
                                </th>
                                <th style="width: 17%; text-align: center">
                                    Back
                                </th>
                                <th style="width: 17%; text-align: center">
                                    Print
                                </th>
                            </tr>
                            <tr>
                                <th style="text-align: left">
                                    Serial Number<span class="da_astrx_mand">*</span>
                                </th>
                                <td class="textboxwidth">
                                    <asp:TextBox runat="server" ID="txtSerialNo" ToolTip="Serial No. Is Required" MaxLength="10"
                                        Width="100px" Style="text-align: left; font-size: 12px; outline: none; font-weight: bold;"
                                        CssClass="do-not-allow-typing"></asp:TextBox>
                                    <asp:HiddenField ID="hdnOrderId" Value="-1" runat="server" />
                                </td>
                                <th style="text-align: left; width: 7%">
                                    Buyer<span class="da_astrx_mand">*</span>
                                </th>
                                <td style="width: 9%">
                                    <asp:DropDownList ID="ddlClient" Enabled="false" runat="server" Width="99%" Style="text-align: left;
                                        font-size: 12px;">
                                        <asp:ListItem Value="-1">Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnClientId" runat="server" Value="-1" />
                                    <div class="form_error">
                                        <asp:RequiredFieldValidator ID="rfv_ddlClient" InitialValue="-1" ValidationGroup="orderValidation"
                                            runat="server" Display="Dynamic" ControlToValidate="ddlClient" CssClass="rfv"
                                            ErrorMessage="Buyer is required"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td rowspan="6" style="text-align: center">
                                    <a class="sample-image" border="0" title="CLICK TO VIEW ENLARGED IMAGE">
                                        <asp:Image runat="server" ID="imgFront" CssClass="hide_me" />
                                    </a>
                                </td>
                                <td rowspan="6" style="text-align: center">
                                    <a class="sample-image" border="0" title="CLICK TO VIEW ENLARGED IMAGE">
                                        <asp:Image runat="server" ID="imgBack" CssClass="hide_me" />
                                    </a>
                                </td>
                                <td rowspan="6" style="text-align: center">
                                    <div id="divPrintImages" runat="server" style="width: 100px;">
                                        <a class="print-image" border="0" title="CLICK TO VIEW ENLARGED IMAGE">
                                            <asp:Image runat="server" ID="imagePrint" CssClass="hide_me" />
                                        </a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th style="text-align: left">
                                    Parent Department
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlParentDept" ToolTip="Parent Department Is Required" runat="server"
                                        CssClass="required" Width="99%" Style="text-align: left; font-size: 12px;" readonly="true"
                                        onchange="ChangeParentDept(this)">
                                        <asp:ListItem Value="-1">Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnParentDeptName" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnParentDeptId" runat="server" Value="-1" />
                                    <asp:Label ID="lblAgrmntParentDept" Width="20px" runat="server" Text=""></asp:Label>
                                </td>
                                <th style="text-align: left">
                                    Department
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" ToolTip="Department Is Required" runat="server"
                                        onchange="ChangeDept(this)" Width="99%" Style="text-align: left; font-size: 12px;"
                                        readonly="true" CssClass="required">
                                        <asp:ListItem Value="-1">Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnDeptName" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnDeptId" runat="server" Value="-1" />
                                    <asp:Label ID="lblAgrmntDept" Width="20px" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th style="text-align: left">
                                    Description
                                </th>
                                <td style="text-align: left;" colspan="3">
                                    <asp:TextBox runat="server" ID="txtDescription" Width="98%" Style="font-size: 10px;
                                        color: Gray; text-transform: lowercase !important; text-align: left; padding-left: 5px;"></asp:TextBox>
                                    <div style="text-align: center;">
                                        <asp:Label ID="lblAgrmntDescription" Width="20px" runat="server" Text=""></asp:Label></div>
                                </td>
                            </tr>
                            <tr>
                                <th style="text-align: left">
                                    Total Order(Qty) Value .
                                </th>
                                <td style="text-align: left; padding-left: 5px !important; position: relative;">
                                    <asp:TextBox ID="txtTotalQty" runat="server" Text="" CssClass="do-not-allow-typing resizewidth"
                                        Style="font-size: 11px; color: Blue; font-weight: bold; text-align: left; display: inline;
                                        min-width: 24px; max-width: 45px; outline: none;"></asp:TextBox>
                                    <asp:Label ID="lblTotQtyUnit" Style="color: gray; font-weight: 600; font-size: 11px;
                                        position: relative; top: 2px;" runat="server" Text=""></asp:Label>
                                    <span style="position: relative;">
                                        <asp:Label ID="lblRuppes" runat="server" Text="" Visible="false" Style="font-size: 12px;
                                            font-weight: 600; color: gray; position: absolute; left: 13px; top: 0px;">₹</asp:Label>
                                        <asp:TextBox ID="txtTotalOrderValue" CssClass="do-not-allow-typing" Style="font-size: 11px;
                                            color: Gray; width: 58px; text-align: left; margin-left: 20px; outline: none;"
                                            runat="server" Text="">
                                        </asp:TextBox>&nbsp;&nbsp;
                                        <asp:HiddenField ID="hdnConversionRate" runat="server" Value="0" />
                                    </span>
                                </td>
                                <th style="text-align: left">
                                    Order Type
                                </th>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlordrType" CssClass="required">
                                        <asp:ListItem Text="BIPL" Value="1" Selected="True">                            
                                        </asp:ListItem>
                                        <asp:ListItem Text="Kasuka" Value="3">                            
                                        </asp:ListItem>
                                        <asp:ListItem Text="Value Added Style" Value="4">                            
                                        </asp:ListItem>
                                        <asp:ListItem Text="Gratitude exports" Value="5">                            
                                        </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblAgrmntOrderType" Width="20px" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th style="text-align: left">
                                    Account Manager
                                </th>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtAccntMgr" runat="server" CssClass="do-not-allow-typing" Style="text-align: left;
                                        width: 90%; padding-left: 5px; font-size: 12px; color: Gray; outline: none;"></asp:TextBox>
                                    <br />
                                    <asp:HyperLink ID="hypBiplPrice" runat="server" Target="costing form">
                                        <asp:Label ID="lblBiplPriceComments" runat="server" Style="font-size: 10px; padding-left: 5px;"></asp:Label>
                                    </asp:HyperLink>
                                </td>
                                <th style="text-align: left">
                                    Delivery Type
                                </th>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlDeliverType">
                                        <asp:ListItem Text="Export Order BH" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Local Order" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Cut to Pack Order" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Export Order Buyer" Value="4" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="dvBaseSizeRate" class="modalNew">
                    <div id="dvSizeRate" class="modal-content">
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <div style="width: 100%; margin: 0 auto;">
                    <h2 style="background: #39589C; font-family: Calibri, sans-serif; color: #e7e4fb;
                        font-size: 14px; margin: 5px 0px 5px; padding: 4px 0px 4px 9px; width: 99%; text-align: center;
                        border: 1px solid Gray">
                        Contract Details</h2>
                </div>
                <div style="max-width: 99.7%;" class="tablewidth">
                    <asp:GridView ID="gvDetailSection" Width="100%" RowStyle-ForeColor="Gray" CssClass="item_list1 gvDetailSection"
                        border="0" CellSpacing="0" CellPadding="0" AutoGenerateColumns="false" runat="server"
                        OnRowCommand="gvDetailSection_RowCommand" OnRowDataBound="gvDetailSection_RowDataBound">
                        <RowStyle CssClass="gvRow" />
                        <EmptyDataTemplate>
                            <table border="0" width="max-width: 99.2%;overflow:auto;" frame="void" cellpadding="0"
                                cellspacing="0" style="border-top: 0px !important">
                                <tr>
                                    <td class="" style="min-width: 330px; vertical-align: top; border-top: 0px !important;
                                        border-left: 0px !important; padding-top: 0px !important; border-bottom: 0px !important;">
                                        <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                            border-left: 0px !important; border-bottom: 0px !important;">
                                            <tr>
                                                <th style="font-size: 10px; border-left: 0px !important;" class="gvborder_top gvborder_left">
                                                    Line/Item No.
                                                </th>
                                                <th style="font-size: 10px" class="gvborder_top">
                                                    Qty.
                                                </th>
                                                <th style="font-size: 10px" class="gvborder_top gvborder_right">
                                                    Mode
                                                </th>
                                            </tr>
                                            <tr>
                                                <th style="font-size: 10px; border-left: 0px !important; padding: 2px 0px !important"
                                                    class="gvborder_top_left gvborder_left">
                                                    Contract No.
                                                </th>
                                                <th style="font-size: 10px" class="gvborder_top_left">
                                                    BIPL Price
                                                </th>
                                                <th style="font-size: 10px" class="gvborder_top_left">
                                                    ExFactory (wk)
                                                </th>
                                            </tr>
                                            <tr>
                                                <th style="font-size: 10px; border-left: 0px !important; padding: 2px 0px !important"
                                                    class="gvborder_top_left gvborder_left">
                                                    Country Code
                                                </th>
                                                <th style="font-size: 10px" class="gvborder_top_left">
                                                    Buyer Price
                                                </th>
                                                <th style="font-size: 10px" class="gvborder_top_left">
                                                    DC (wk)
                                                </th>
                                            </tr>
                                            <tr>
                                                <th class=" gvborder_left" style="padding: 2px 0px !important; border-left: 0px !important;
                                                    border-right: 0px !important">
                                                    Po Upload
                                                </th>
                                                <th colspan="2" style="padding: 2px 0px !important; border-right: 0px !important">
                                                    Delivery Instruction
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%">
                                                    <asp:TextBox ID="txtLineNo_Empty" onkeypress="javascript:return blockSpecialChar(event)"
                                                        MaxLength="45" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="width: 80px; text-align: left;">
                                                    <span style="color: Red; width: 12px; height: 12px; font-size: 13px">*</span>
                                                    <asp:Label ID="lblQtyPcs_Empty" Width="17px" ForeColor="gray" Font-Bold="true" runat="server"
                                                        Text=""></asp:Label>
                                                    <asp:TextBox ID="txtQty_Empty" Width="45px" MaxLength="5" CssClass="numeric-field-without-decimal-places"
                                                        Style="text-align: left" onblur="UpdateQuantity_WithPrice(this, 'Empty')" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="gvborder_righttd">
                                                    <span style="color: Red; width: 12px; height: 12px; font-size: 13px">*</span>
                                                    <asp:DropDownList ID="ddlMode_Empty" CssClass="required" onchange="onModeChange(this, 'Empty')"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnMode_Empty" Value="-1" runat="server" />
                                                    <asp:HiddenField ID="hdnAmberRangeStart_Empty" Value="-1" runat="server" />
                                                    <asp:HiddenField ID="hdnAmberRangeEnd_Empty" Value="-1" runat="server" />
                                                    <asp:HiddenField ID="hdnGreenRangeStart_Empty" Value="-1" runat="server" />
                                                    <asp:HiddenField ID="hdnGreenRangeEnd_Empty" Value="-1" runat="server" />
                                                    <asp:HiddenField ID="hdnRedRangeStart_Empty" Value="-1" runat="server" />
                                                    <asp:HiddenField ID="hdnRedRangeEnd_Empty" Value="-1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%">
                                                    <asp:TextBox ID="txtContractNo_Empty" TextMode="MultiLine" MaxLength="45" Height="26px"
                                                        onkeypress="javascript:return blockSpecialChar(event)" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lblSymblBIPLPrice_Empty" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="txtBIPLPrice_Empty" onblur="UpdateQuantity_WithPrice(this, 'Empty')"
                                                        CssClass="numeric-field-with-decimal-place" Style="text-align: left; color: gr"
                                                        MaxLength="5" Width="50px" runat="server"></asp:TextBox>
                                                </td>
                                                <td id="tdExFactory_Empty" runat="server" class="gvborder_righttd">
                                                    <asp:HiddenField ID="hdnExFactoryColor_Empty" Value="" runat="server" />
                                                    <span class="inputleft">
                                                        <asp:TextBox ID="txtExFactory_Empty" Style="background: transparent;" CssClass="do-not-allow-typing"
                                                            runat="server"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnExFactory_Empty" runat="server" />
                                                    <asp:TextBox ID="txtExFactoryWeek_Empty" Style="background: transparent;" Width="40px"
                                                        CssClass="do-not-allow-typing" runat="server" ForeColor="Black" Text=""></asp:TextBox>
                                                </td>
                                                <asp:HiddenField ID="hdnExFactoryWeek_Empty" Value="0" runat="server" />
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; text-align: center; vertical-align: top;">
                                                    <asp:DropDownList ID="ddlCountryCode_Empty" CssClass="required" onchange="onCountryCodeChange(this, 'Empty')"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnCountryCodeId_Empty" Value="-1" runat="server" />
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lblSymblikandiPrice_Empty" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="txtikandiPrice_Empty" CssClass="numeric-field-with-decimal-place"
                                                        onblur="ValidateiKandiPrice(this, 'Empty')" Style="text-align: left;" MaxLength="5"
                                                        Width="50px" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="gvborder_righttd">
                                                    <span class="inputleft">
                                                        <asp:TextBox ID="txtDC_Empty" CssClass="DC DCDate do-not-allow-typing" runat="server"></asp:TextBox></span>
                                                    <asp:HiddenField ID="hdnDC_Empty" runat="server" />
                                                    <asp:TextBox ID="txtDCWeek_Empty" Width="40px" CssClass="do-not-allow-typing" runat="server"
                                                        ForeColor="Black" Text=""></asp:TextBox>
                                                </td>
                                                <asp:HiddenField ID="hdnDCWeek_Empty" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnLeadTime_Empty" Value="0" runat="server" />
                                            </tr>
                                            <tr>
                                                <td style="border-bottom: 0px !important; text-align: center">
                                                    <span id="FileUpload1_Empty" runat="server" style="display: none;" class="fileupladcur"
                                                        onclick="UploadFile(this, 'Empty')">
                                                        <img src="../../images/uploadimg.png" /></span>
                                                    <asp:HiddenField ID="hdnPoUpload1_Empty" Value="" runat="server" />
                                                    <span id="FileUpload2_Empty" runat="server" style="display: none;" class="fileupladcur"
                                                        onclick="UploadFile(this, 'Empty')">
                                                        <img src="../../images/uploadimg.png" /></span>
                                                    <asp:HiddenField ID="hdnPoUpload2_Empty" Value="" runat="server" />
                                                </td>
                                                <td style="border-bottom: 0px !important; text-align: center">
                                                    <asp:TextBox ID="txtDelivery_Empty" CssClass="do-not-allow-typing" Width="95%" runat="server"></asp:TextBox>
                                                </td>
                                                <td colspan="" class="gvborder_righttd" style="border-bottom: 0px !important; text-align: center;
                                                    padding-bottom: 8px !important;">
                                                    <asp:DropDownList ID="ddlDelivery_Empty" CssClass="required" Width="115px" runat="server">
                                                        <asp:ListItem Text="BDCM" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="COFFIN BOX" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="HANGER" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="vertical-align: top; border-top: 0px !important; padding-top: 0px !important;
                                        width: 600px;" class="gvborder_righttd_left BorderColor">
                                        <asp:HiddenField ID="hdnFabricCount" Value="0" runat="server" />
                                        <table width="100%" class="basicsectiotable" cellpadding="0" border="0" cellspacing="0"
                                            style="overflow: auto; border-right: 0px !important; border-left: 0px !important;
                                            border-bottom: 0px !important;">
                                            <tr>
                                                <th style="font-size: 13px; height: 72px; border-right: 0px !important; border-left: 0px !important;
                                                    border-top: 0px !important;">
                                                    Fabric Section
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="height: 70px; border-bottom: 0px !important; border-right: 0px !important;
                                                    border-left: 0px !important; padding-top: 0px !important;">
                                                    <div style="max-width: 600px; height: 92px; overflow-x: auto;">
                                                        <table width="100%" class="baricesection" style="border-bottom: 0px;" cellpadding="0"
                                                            cellspacing="0">
                                                            <tr>
                                                                <%--Fabric1--%>
                                                                <td id="tdFabric1" style="display: none; border-left: 0px !important;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric1" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric1" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left; font-weight: bold;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr1" runat="server" CssClass="alin COUNTCON1" Text=""></asp:Label>
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM1" runat="server" CssClass="alin GSML1" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr1" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM1" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId1" Value="0" runat="server" />
                                                                    </div>
                                                                    <br />
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType1" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType1" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail1" runat="server" disabled="disabled" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <%--Fabric2--%>
                                                                <td id="tdFabric2" style="display: none; vertical-align: top;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric2" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric2" CssClass="do-not-allow-typing fabric_input_width" MaxLength="60"
                                                                            runat="server" disabled="disabled" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr2" runat="server" CssClass="alin COUNTCON2" Text=""></asp:Label>
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM2" runat="server" CssClass="alin GSML3" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr2" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM2" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId2" Value="0" runat="server" />
                                                                    </div>
                                                                    <br />
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType2" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType2" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" disabled="disabled" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail2" runat="server" disabled="disabled" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <%--Fabric3--%>
                                                                <td id="tdFabric3" style="display: none;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric3" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric3" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            MaxLength="60" runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr3" runat="server" CssClass="alin COUNTCON3" Text=""></asp:Label>
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM3" runat="server" CssClass="alin GSML3" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr3" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM3" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId3" Value="0" runat="server" />
                                                                    </div>
                                                                    <br />
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType3" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType3" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail3" disabled="disabled" runat="server" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <%--Fabric4--%>
                                                                <td id="tdFabric4" style="display: none;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric4" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric4" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            MaxLength="60" runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr4" runat="server" CssClass="alin COUNTCON4" Text=""></asp:Label>
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM4" runat="server" CssClass="alin GSML4" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr4" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM4" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId4" Value="0" runat="server" />
                                                                    </div>
                                                                    <br />
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType4" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType4" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail4" disabled="disabled" runat="server" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <%--Fabric5--%>
                                                                <td id="tdFabric5" style="display: none;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric5" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric5" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            MaxLength="60" runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr5" runat="server" CssClass="alin COUNTCON5" Text=""></asp:Label>
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM5" runat="server" CssClass="alin GSML5" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr5" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM5" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId5" Value="0" runat="server" />
                                                                    </div>
                                                                    <br />
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType5" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType5" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail5" disabled="disabled" runat="server" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <%--Fabric6--%>
                                                                <td id="tdFabric6" style="display: none;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric6" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric6" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            MaxLength="60" runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr6" runat="server" CssClass="alin COUNTCON6" Text=""></asp:Label>
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM6" runat="server" CssClass="alin GSML6" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr6" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM6" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId6" Value="0" runat="server" />
                                                                    </div>
                                                                    <br />
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType6" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType6" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail6" disabled="disabled" runat="server" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <%--Fabric7--%>
                                                                <td id="tdFabric7" style="display: none;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric7" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric7" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            MaxLength="60" runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr7" runat="server" CssClass="alin COUNTCON7" Text=""></asp:Label>&nbsp;
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM7" runat="server" CssClass="alin GSML7" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr7" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM7" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId7" Value="0" runat="server" />
                                                                    </div>
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType7" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType7" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail7" disabled="disabled" runat="server" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <%--Fabric8--%>
                                                                <td id="tdFabric8" style="display: none;" runat="server">
                                                                    <div class="clsFabric">
                                                                        <asp:HiddenField ID="hdnFabric8" Value="-1" runat="server" />
                                                                        <asp:TextBox ID="txtFabric8" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            MaxLength="60" runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                    </div>
                                                                    <div style="width: 300px;" class="fabric_span_width">
                                                                        <asp:Label ID="lblCountCnstr8" runat="server" CssClass="alin COUNTCON8" Text=""></asp:Label>&nbsp;
                                                                        | &nbsp;
                                                                        <asp:Label ID="lblGSM8" runat="server" CssClass="alin GSML8" Text=""></asp:Label>
                                                                        <asp:HiddenField ID="hdnCountCnstr8" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnGSM8" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="hdnFabriQualityId8" Value="0" runat="server" />
                                                                    </div>
                                                                    <div style="width: 300px;">
                                                                        <asp:HiddenField ID="hdnFabricType8" runat="server" Value="0" />
                                                                        <asp:TextBox ID="txtFabricType8" disabled="disabled" CssClass="do-not-allow-typing fabric_input_width"
                                                                            runat="server" BorderStyle="None" Style="text-align: left;"></asp:TextBox>
                                                                        <asp:TextBox ID="txtFabricDetail8" disabled="disabled" runat="server" BorderStyle="None"
                                                                            CssClass="fabric_input_width" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                                            color: black;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 500px; vertical-align: top; border-top: 0px !important; padding-top: 0px !important;
                                        border-bottom: 0px !important; border-right: 0px !important;">
                                        <asp:HiddenField ID="hdnAccessCount" Value="0" runat="server" />
                                        <table width="500px" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                            border-left: 0px !important; border-bottom: 0px !important;">
                                            <tr>
                                                <th style="font-size: 13px; height: 72px; border-left: 0px !important; border-right: 0px !important;
                                                    border-top: 0px !important">
                                                    <span style="padding-left: 100px">Accessories Section </span>
                                                    <%--  <span title="ADD ACCESSORIES" style="float: right;cursor:pointer; position: relative; top: 0%;
                                                        right: 5px" >
                                                    <img src="../../images/plus-3.png"  style="width: 12px;" onclick="AddAccessories('Empty')" />
                                                       
                                                    </span>--%>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="height: 90px; border: 0px !important; padding-top: 0px !important;" class="BorderColor">
                                                    <div style="max-width: 500px; height: 95px; overflow-x: auto; overflow-y: hidden;">
                                                        <table class="Accesstablewidth" style="border-bottom: 0px; border-collapse: collapse;"
                                                            cellpadding="0" cellspacing="0">
                                                            <%--1st row--%>
                                                            <tr>
                                                                <td id="tdAccess1" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important; border-left: 0px !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_1" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_1" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_1" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_1" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_1" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_1" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_1" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM1" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess5" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_5" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_5" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_5" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_5" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_5" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_5" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_5" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM5" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess9" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_9" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_9" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_9" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_9" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_9" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_9" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_9" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM9" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess13" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_13" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_13" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_13" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_13" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_13" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_13" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_13" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM13" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess17" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_17" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_17" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_17" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_17" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_17" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_17" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_17" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM17" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess21" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_21" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_21" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_21" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_21" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_21" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_21" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_21" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM21" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess25" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_25" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_25" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_25" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_25" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_25" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_25" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_25" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM25" ToolTip="IDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <%--2nd row--%>
                                                            <tr>
                                                                <td id="tdAccess2" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    padding: 0px 2px 0px 4px !important; display: none; min-width: 200px; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_2" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_2" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_2" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_2" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_2" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_2" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_2" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM2" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess6" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_6" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_6" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_6" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_6" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_6" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_6" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_6" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM6" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess10" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_10" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_10" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_10" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_10" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_10" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_10" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_10" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM10" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess14" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_14" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_14" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_14" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_14" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_14" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_14" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_14" disabled="disabled"
                                                                            ToolTip="Color" onblur="ValidateAccessoryColor(this, 'Empty')" CssClass='textborder'
                                                                            Style="width: 60px !important;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM14" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess18" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_18" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_18" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_18" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_18" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_18" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_18" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_18" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM18" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess22" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_22" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_22" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_22" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_22" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_22" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_22" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_22" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM22" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess26" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_26" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_26" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_26" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_26" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_26" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_26" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_26" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM26" ToolTip="IDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <%--3rd row--%>
                                                            <tr>
                                                                <td id="tdAccess3" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    padding: 0px 2px 0px 4px !important; display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_3" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_3" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_3" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_3" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_3" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_3" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_3" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM3" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess7" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_7" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_7" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_7" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_7" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_7" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_7" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_7" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM7" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess11" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_11" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_11" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_11" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_11" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_11" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_11" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_11" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM11" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess15" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_15" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_15" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_15" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_15" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_15" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_15" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;
                                                                            <asp:TextBox ID="txtAccessVal_15" disabled="disabled" ToolTip="Color" Width="60px"
                                                                                MaxLength="15" CssClass='textborder' Style="width: 60px !important;" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                                onblur="ValidateAccessoryColor(this, 'Empty')" runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM15" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess19" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_19" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_19" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_19" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_19" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_19" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_19" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_19" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" MaxLength="15"
                                                                            ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server" Style="width: 60px !important;"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM19" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess23" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_23" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_23" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_23" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_23" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_23" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_23" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_23" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM23" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess27" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_27" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_27" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_27" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_27" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_27" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_27" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_27" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM27" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <%--4th row--%>
                                                            <tr>
                                                                <td id="tdAccess4" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    padding: 0px 2px 0px 4px !important; display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_4" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_4" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_4" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_4" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_4" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_4" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_4" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM4" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess8" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_8" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_8" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_8" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_8" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_8" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_8" CssClass="txtAccessories do-not-allow-typing" runat="server"
                                                                            disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_8" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM8" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess12" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none; border-right: 1px solid #eae4e4 !important;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_12" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_12" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_12" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_12" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_12" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_12" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_12" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM12" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess16" runat="server" style='text-align: left; padding: 0px 2px 0px 4px;
                                                                    display: none;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_16" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_16" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_16" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_16" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_16" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_16" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_16" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM16" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAccess20" runat="server" style='text-align: left; padding: 0px 2px 0px 4px !important;
                                                                    display: none;'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_20" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_20" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_20" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_20" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_20" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_20" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server" disabled="disabled"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_20" disabled="disabled"
                                                                            CssClass='textborder' onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM20" ToolTip="IDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess24" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_24" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_24" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_24" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_24" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_24" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_24" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_24" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM24" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                                <td id="tdAcess28" runat="server" style='text-align: left; border-left: 0px !important;
                                                                    display: none'>
                                                                    <div class="accessColwidth">
                                                                        <input type="hidden" id="hdnAccessId_28" class="hdnAccess" runat="server" />
                                                                        <asp:HiddenField ID="hdnAccessName_28" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSizeId_28" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnAccessSize_28" runat="server"></asp:HiddenField>
                                                                        <asp:HiddenField ID="hdnIsDefaultAccess_28" runat="server"></asp:HiddenField>
                                                                        <asp:TextBox ID="txtAccessName_28" CssClass="txtAccessories do-not-allow-typing"
                                                                            runat="server"></asp:TextBox>
                                                                        <span style="float: right">&nbsp;<asp:TextBox ID="txtAccessVal_28" CssClass='textborder'
                                                                            onblur="ValidateAccessoryColor(this, 'Empty')" Style="width: 60px !important;"
                                                                            MaxLength="15" ToolTip="Color" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                                            runat="server"></asp:TextBox>&nbsp;
                                                                            <asp:CheckBox ID="chkDTM28" ToolTip="IsDTM" CssClass='checkboxright' runat="server" />
                                                                        </span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <%-- 5th row--%>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="BorderColor" style="width: 50px; vertical-align: top; border-top: 0px !important;
                                        padding-top: 0px !important; border-bottom: 0px !important; border-right: 0px !important;">
                                        <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                            border-left: 0px !important; border-bottom: 0px !important;">
                                            <tr>
                                                <th style="font-size: 13px; height: 72px; border-left: 0px !important; border-right: 0px !important;
                                                    border-top: 0px !important;">
                                                    Size
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="height: 90px; border: 0px !important">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="BorderColorlast BorderColor" style="width: 30px; vertical-align: top;
                                        padding-top: 0px !important; border-top: 0px !important; border-bottom: 0px !important;
                                        border-right: 0px !important;">
                                        <table width="100%" class="basicsectiotable BorderColorlast" cellpadding="0" cellspacing="0"
                                            style="border-right: 0px !important; border-left: 0px !important; border-bottom: 0px !important;">
                                            <tr>
                                                <th style="font-size: 13px; height: 72px; border-left: 0px !important; border-right: 0px !important;
                                                    border-top: 0px !important; border-right: 0px !important;">
                                                    &nbsp;
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="height: 90px; border: 0px !important">
                                                    <asp:ImageButton ID="imgbtn_Empty" Style="display: none;" ImageUrl="~/images/add-butt-white.png"
                                                        OnClientClick="javascript:return ValidateContractDetails(this, 'Empty')" CommandName="AddEmpty"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <%--Basic section--%>
                            <asp:TemplateField HeaderStyle-Width="330px" ItemStyle-Width="330px" ItemStyle-CssClass="BorderColor">
                                <HeaderTemplate>
                                    <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                        border-left: 0px !important; border-bottom: 0px !important;">
                                        <tr>
                                            <th style="font-size: 10px; min-width: 79px; border-left: 0px !important" class="gvborder_top gvborder_left">
                                                Line/Item No.
                                            </th>
                                            <th style="font-size: 10px; min-width: 76px" class="gvborder_top ">
                                                Qty.
                                            </th>
                                            <th style="font-size: 10px; min-width: 102px" class="gvborder_top gvborder_right">
                                                Mode
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="font-size: 10px; border-left: 0px !important" class="gvborder_top_left gvborder_left">
                                                Contract No.
                                            </th>
                                            <th style="font-size: 10px; padding: 3px 0px !important;" class="gvborder_top_left">
                                                BIPL Price
                                            </th>
                                            <th style="font-size: 10px" class="gvborder_top_left">
                                                ExFactory (wk)
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="font-size: 10px; border-left: 0px !important" class="gvborder_top_left gvborder_left">
                                                Country Code
                                            </th>
                                            <th style="font-size: 10px; padding: 3px 0px !important;" class="gvborder_top_left">
                                                Buyer Price
                                            </th>
                                            <th style="font-size: 10px" class="gvborder_top_left ">
                                                DC (wk)
                                            </th>
                                        </tr>
                                        <tr>
                                            <th class="gvborder_top_left gvborder_left" style="border-left: 0px !important">
                                                Po Upload
                                            </th>
                                            <th colspan="2" class="gvborder_right gvborder_bottom">
                                                Delivery Instruction
                                            </th>
                                        </tr>
                                        <tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                        border-left: 0px !important; border-bottom: 0px !important;">
                                        <tr>
                                            <td style="min-width: 95px" class="gvborder_left">
                                                <asp:TextBox ID="txtLineNo" Width="98px" Style="height: 12px; position: relative;
                                                    top: -1px; color: Black !important" MaxLength="45" onkeypress="javascript:return blockSpecialChar(event)"
                                                    runat="server"></asp:TextBox>
                                                <asp:Label ID="lblLineNo_agree" Width="20px" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hdnLineNo_agree" Value="" runat="server" />
                                            </td>
                                            <td style="min-width: 90px; text-align: left; padding-right: 2px !important; position: relative">
                                                <asp:Label ID="lblQty_agree" Width="20px" runat="server" Text="" Visible="false"></asp:Label>
                                                <span style="color: Red; position: absolute; font-size: 13px; top: 2px; left: 19px;">
                                                    *</span>
                                                <asp:Label ID="lblQtyPcs" ForeColor="gray" Font-Bold="true" runat="server" Text=""
                                                    Style="font-weight: bold !important; font-size: 9px;"></asp:Label>
                                                <asp:TextBox ID="txtQty" Width="40px" MaxLength="5" CssClass="numeric-field-without-decimal-places"
                                                    Style="text-align: left; height: 12px; position: relative; top: -1px; font-weight: bold;"
                                                    onblur="UpdateQuantity_WithPrice(this, 'Row')" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnQty_agree" Value="0" runat="server" />
                                            </td>
                                            <td style="min-width: 120px;" class="gvborder_righttd">
                                                <span style="color: Red; width: 12px; height: 12px; font-size: 13px;">*</span>
                                                <asp:DropDownList ID="ddlMode" CssClass="required" onchange="onModeChange(this,'Row')"
                                                    runat="server" Style="color: Black;">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnMode" Value="-1" runat="server" />
                                                <asp:Label ID="lblMode_agree" Width="20px" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hdnAgreementMode" Value="" runat="server" />
                                                <asp:HiddenField ID="hdnAmberRangeStart" Value='<%# Eval("AmberRangeStart") %>' runat="server" />
                                                <asp:HiddenField ID="hdnAmberRangeEnd" Value='<%# Eval("AmberRangeEnd") %>' runat="server" />
                                                <asp:HiddenField ID="hdnGreenRangeStart" Value='<%# Eval("GreenRangeStart") %>' runat="server" />
                                                <asp:HiddenField ID="hdnGreenRangeEnd" Value='<%# Eval("GreenRangeEnd") %>' runat="server" />
                                                <asp:HiddenField ID="hdnRedRangeStart" Value='<%# Eval("RedRangeStart") %>' runat="server" />
                                                <asp:HiddenField ID="hdnRedRangeEnd" Value='<%# Eval("RedRangeEnd") %>' runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="min-width: 30%" class="gvborder_left">
                                                <asp:TextBox ID="txtContractNo" TextMode="MultiLine" MaxLength="45" Height="26px"
                                                    Width="95%" onkeypress="javascript:return blockSpecialChar(event)" runat="server"
                                                    Style="color: Black !important;"></asp:TextBox>
                                                <asp:HiddenField ID="hdnOrderDetailid" Value="-1" runat="server" />
                                                <asp:HiddenField ID="hdnIndex" Value="-1" runat="server" />
                                                <asp:Label ID="lblContactNo_agree" Width="20px" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hdnContactNo_agree" Value="-1" runat="server" />
                                                <asp:HiddenField ID="hdnOrderDetailid_Ref" Value="-1" runat="server" />
                                            </td>
                                            <td style="text-align: left; padding-right: 2px !important;">
                                                <asp:Label ID="lblBiplPrice_agree" Width="20px" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblSymblBIPLPrice" runat="server" ForeColor="green" Text=""></asp:Label>
                                                <asp:TextBox ID="txtBIPLPrice" onblur="UpdateQuantity_WithPrice(this, 'Row')" CssClass="numeric-field-with-two-decimal-places"
                                                    Style="text-align: left; height: 13px; color: #006400; font-weight: bold;" MaxLength="5"
                                                    Width="46px" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnBiplPrice_agree" Value="-1" runat="server" />
                                                </span>
                                            </td>
                                            <td id="tdExFactory" runat="server" class="gvborder_righttd">
                                                <asp:HiddenField ID="hdnExFactoryColor" Value="" runat="server" />
                                                <span style="float: left;">
                                                    <asp:TextBox ID="txtExFactory" Style="background: transparent; font-weight: bold;"
                                                        CssClass="do-not-allow-typing" Width="105px" runat="server"></asp:TextBox></span>
                                                <asp:HiddenField ID="hdnExFactory" runat="server" />
                                                <asp:TextBox ID="txtExFactoryWeek" Style="background: transparent;" Width="23px"
                                                    CssClass="do-not-allow-typing" runat="server" ForeColor="Black" Text=""></asp:TextBox>
                                                <span class="leftspan">
                                                    <asp:Label ID="lblExFactory_agree" Width="20px" runat="server" Text=""></asp:Label></span>
                                                <asp:HiddenField ID="hdnExFactory_agree" Value="-1" runat="server" />
                                                <asp:HiddenField ID="hdnExFactoryWeek_agree" Value="-1" runat="server" />
                                            </td>
                                            <asp:HiddenField ID="hdnExFactoryWeek" Value="0" runat="server" />
                                        </tr>
                                        <tr>
                                            <td class="gvborder_left" style="width: 30%; text-align: center; border-bottom: 1px solid #9999 !important;
                                                padding: 4px 0px !important;">
                                                <asp:DropDownList ID="ddlCountryCode" CssClass="required" onchange="onCountryCodeChange(this, 'Row')"
                                                    runat="server">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnCountry_CodeId" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnCountryCode" Value="" runat="server" />
                                                <asp:HiddenField ID="hdnCountryCode_agree" Value="" runat="server" />
                                                <asp:Label ID="lblCountryCode_agree" Width="20px" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="text-align: left; padding-right: 2px !important;">
                                                <asp:Label ID="lblikandiPrice_agree" Width="20px" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblSymblikandiPrice" runat="server" ForeColor="blue" Text=""></asp:Label>
                                                <asp:TextBox ID="txtikandiPrice" CssClass="numeric-field-with-two-decimal-places"
                                                    Style="text-align: left; color: Gray; font-weight: bold; height: 12px" MaxLength="5"
                                                    Width="40px" onblur="ValidateiKandiPrice(this, 'Row')" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hdnikandiPrice_agree" Value="-1" runat="server" />
                                            </td>
                                            <td class="gvborder_righttd">
                                                <span style="float: left;">
                                                    <asp:TextBox ID="txtDC" CssClass="DC DCDate do-not-allow-typing" Style="color: Black;
                                                        font-weight: bold; padding-left: 5px;" Width="100px" runat="server"></asp:TextBox></span>
                                                <asp:HiddenField ID="hdnDC" runat="server" />
                                                <asp:TextBox ID="txtDCWeek" CssClass="do-not-allow-typing" Width="23px" runat="server"
                                                    ForeColor="Black" Text=""></asp:TextBox>
                                                <asp:HiddenField ID="hdnDCWeek" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnLeadTime" Value='<%# Eval("LeadTime") %>' runat="server" />
                                                <span class="leftspan">
                                                    <asp:Label ID="lblDC_agree" Width="20px" runat="server" Text=""></asp:Label></span>
                                                <span class="rightspan">
                                                    <asp:Label ID="lblDCWeek_agree" Width="20px" runat="server" Text=""></asp:Label>
                                                </span>
                                                <asp:HiddenField ID="hdnDC_agree" Value="-1" runat="server" />
                                                <asp:HiddenField ID="hdnDCWeek_agree" Value="-1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="gvborder_left" style="width: 30%; text-align: center; border-bottom: 0px !important;
                                                padding: 0px 0px !important;">
                                                <span style="display: inline-block; width: 16px; position: relative; top: 3px" id="FileUpload1"
                                                    runat="server" class="fileupladcur" title="UPLOAD FILES" onclick="UploadFile(this, 'Row')">
                                                    <img alt="#" src="../../images/uploadimg.png" style="width: 21px;" /></span>
                                                <asp:HyperLink ID="hlkPoUpload1" runat="server" Visible="false" Target="_blank" Style="padding-left: 5px;
                                                    display: inline-block; width: 30px">
                                                 <img src="../../images/view-icon.png" style="width:15px; height:15px;"/> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnPoUpload1" Value="" runat="server" />
                                                <asp:HiddenField ID="hdnPoUpload1_agree" Value="" runat="server" />
                                                <asp:HyperLink ID="hlkPoUpload2" runat="server" Visible="false" Target="_blank">
                                                 <img src="../../images/view-icon.png" style="width:15px; height:15px;" /> </asp:HyperLink>
                                                <asp:HiddenField ID="hdnPoUpload2" Value="" runat="server" />
                                                <br />
                                                <span class="textcenter">
                                                    <asp:Label ID="lblPoUpload2_agree" Width="20px" runat="server" Text=""></asp:Label></span>
                                                <span class="textcenter">
                                                    <asp:Label ID="lblPoUpload1_agree" Width="20px" runat="server" Text=""></asp:Label>
                                                </span>
                                                <asp:HiddenField ID="hdnPoUpload2_agree" Value="" runat="server" />
                                            </td>
                                            <td colspan="" class="gvborder_left" style="border-bottom: 0px !important; text-align: left;">
                                                <asp:Label ID="lblDeliver_agree" Width="20px" runat="server" Text=""></asp:Label>
                                                <asp:TextBox ID="txtDelivery" CssClass="do-not-allow-typing" Width="65px" runat="server"
                                                    Style="color: Gray;"></asp:TextBox>
                                                <asp:HiddenField ID="hdnDeliver_agree" Value="-1" runat="server" />
                                            </td>
                                            <td style="border-bottom: 0px !important; padding-left: 4px;" class="gvborder_righttd">
                                                <asp:DropDownList ID="ddlDelivery" CssClass="required" Width="114px" runat="server">
                                                    <asp:ListItem Text="BDCM" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="COFFIN BOX" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="HANGER" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:Label ID="lblddlDelivery_agree" runat="server" Text="" Width="20px"></asp:Label>
                                                    <asp:HiddenField ID="hdnddlDelivery_agree" Value="-1" runat="server" />
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <HeaderStyle Width="320px" />
                                <ItemStyle VerticalAlign="Top" />
                            </asp:TemplateField>
                            <%--Fabric section--%>
                            <asp:TemplateField HeaderStyle-Width="500px" ItemStyle-CssClass="BorderColor">
                                <HeaderTemplate>
                                    <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                        border-left: 0px !important; border-bottom: 0px !important;">
                                        <tr>
                                            <th style="font-size: 13px; height: 72px; border: 0px solid #999999 !important; position: relative">
                                                <span style="position: absolute; left: 43%;">Fabric Section</span><span id="FabricDetailsLink"
                                                    title="Fabric Details" runat="server" style="float: right; position: relative;
                                                    top: -36%; padding-right: 5px !important" onclick="ShowFabric()"><a style="font-size: 10px;
                                                        cursor: pointer">Fabric Details</a> </span>
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="width: 500px; overflow-x: auto; height: 117px; display: flex;">
                                        <asp:DataList ID="dlstFabric" OnItemDataBound="dlstFabric_ItemDataBound" RepeatDirection="Horizontal"
                                            runat="server" CssClass="fabric_seiction_border" ItemStyle-CssClass="dlstFabricCount"
                                            Style="width: 1200px;">
                                            <ItemTemplate>
                                                <div class="clsFabric">
                                                    <asp:HiddenField ID="hdnFabric" Value='<%# Eval("FabricId") %>' runat="server" />
                                                    <asp:TextBox ID="txtFabric" CssClass="do-not-allow-typing fabric fabric_input_width  bold"
                                                        Text='<%# Eval("FabricName") %>' runat="server" disabled="disabled" Style="text-align: left!important;
                                                        color: Blue;"></asp:TextBox>
                                                    <%--added by raghvinder on 21-09-2020 start--%>
                                                    <asp:HiddenField ID="hdnFabricQualityDetailsID" runat="server" Value='<%# Eval("fabric_qualityID") %>' />
                                                    <%--added by raghvinder on 21-09-2020 end--%>
                                                </div>
                                                <div style="width: 300px;" class="fabric_span_width">
                                                    <asp:Label ID="lblCountCnstr" runat="server" CssClass="alin COUNTCON8" Text='<%# Eval("CountConstruct") %>'></asp:Label>
                                                    | &nbsp;
                                                    <asp:Label ID="lblGSM" runat="server" CssClass="alin GSML8" Text='<%# Eval("GSM") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCountCnstr" Value='<%# Eval("CountConstruct") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnGSM" Value='<%# Eval("GSM") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnFabriQualityId" Value='<%# Eval("fabric_qualityID") %>' runat="server" />
                                                </div>
                                                <div style="width: 300px;">
                                                    <input type="hidden" runat="server" class="fabrictype" id="hdnFabricType" value='<%# Eval("FabTypeId") %>' />
                                                    <asp:TextBox ID="txtFabricType" Text='<%# Eval("FabType") %>' CssClass="do-not-allow-typing fabric_input_width"
                                                        runat="server" disabled="disabled" BorderStyle="None" Style="text-align: left;
                                                        color: #696969; background-color: White;"></asp:TextBox>
                                                </div>
                                                <div style="width: 300px;">
                                                    <asp:TextBox ID="txtFabricDetail" Text='<%# Eval("FabricDetail") %>' CssClass="fabric_input_width"
                                                        runat="server" BorderStyle="None" onblur="ValidateFabricColorPrint(this)" Style="text-align: left;
                                                        color: black; background-color: White; outline: 0;"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnFabricDetail_d" Value='<%# Eval("FabricDetail_d") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnstage1" Value='<% #Eval("Stage1")%>' runat="server" />
                                                    <asp:HiddenField ID="hdnstage2" Value='<% #Eval("Stage2")%>' runat="server" />
                                                    <asp:HiddenField ID="hdnstage3" Value='<% #Eval("Stage3")%>' runat="server" />
                                                    <asp:HiddenField ID="hdnstage4" Value='<% #Eval("Stage4")%>' runat="server" />
                                                    <asp:HiddenField ID="hdnCanChangeColorPrint" Value='<% #Eval("CanChangeColorPrint")%>' runat="server" />

                                                    <asp:Label ID="lblFabricDetail_agree" Width="10px" runat="server" Text=""></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" />
                            </asp:TemplateField>
                            <%--Accessories section--%>
                            <asp:TemplateField ItemStyle-Width="500px" ItemStyle-CssClass="AccessoriesClass BorderColor"
                                HeaderStyle-Width="500px">
                                <HeaderTemplate>
                                    <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                        border-left: 0px !important; border-bottom: 0px !important; position: relative">
                                        <tr>
                                            <th style="font-size: 13px; height: 72px; border: 0px solid #999999 !important" class="colorred">
                                                <span style="position: absolute; left: 40%;">Accessories Section </span><span id="AccessoryDetailLink"
                                                    runat="server" title="Accessories Details" style="float: right; position: relative;
                                                    top: -30%; padding-right: 5px !important" onclick="ShowAccess()"><a style="font-size: 10px;
                                                        cursor: pointer;">Accessories Details</a> </span>
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="max-width: 550px; overflow-x: auto; overflow-y: hidden; height: 117px;">
                                        <asp:DataList ID="dlstAccessories" CssClass="dlstAccessoriesa fabric_seiction_border"
                                            OnItemDataBound="dlstAccessories_ItemDataBound" RepeatDirection="Vertical" RepeatLayout="Table"
                                            runat="server">
                                            <ItemTemplate>
                                                <div class="accessColwidth">
                                                    <input type="hidden" id="hdnAccessId_" value='<%# Eval("AccessoriesId") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnAccessName_" Value='<%# Eval("AccessoriesName") %>' runat="server">
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="hdnAccessSizeId_" Value='<%# Eval("SizeId") %>' runat="server">
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="hdnAccessSize_" Value='<%# Eval("Size") %>' runat="server">
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="hdnIsDefaultAccess" Value='<%# Eval("IsDefaultAccessory") %>'
                                                        runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnAfterOrderConfirmation" Value='<%# Eval("AfterOrderConfirmation") %>'
                                                        runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnIsAnyAccessoryAdded" Value='<%# Eval("IsAnyAccessoryAdded") %>'
                                                        runat="server"></asp:HiddenField>
                                                    <asp:TextBox ID="txtAccessName_" disabled="disabled" CssClass="txtAccessoriesRow do-not-allow-typing"
                                                        Style="float: left; padding-left: 2px; background-color: White;" runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnAccessoriesId" runat="server" Value='<%# Eval("AccessoriesId") %>' />
                                                    <span style="float: right">
                                                        <asp:HiddenField ID="hdnAccessColorPrint_d" Value='<%# Eval("ColorPrint_d") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnIsDTM_d" Value='<%# Eval("IsDtm_d") %>' runat="server" />
                                                        <asp:HiddenField ID="HdnISSrvReceived" runat="server" Value='<%# Eval("ISSrvReceived") %>' />
                                                        <asp:Label ID="lblAccessDetail_agree" Width="10px" runat="server" Text=""></asp:Label>
                                                        <asp:TextBox ID="txtAccessVal_" CssClass="textborder" ToolTip="Color" Text='<%# Eval("ColorPrint") %>'
                                                            Style="border: 1px solid #cebdbd !important; border-radius: 2px; width: 60px !important;
                                                            height: 12px;" MaxLength="15" onkeypress="javascript:return allowAlphaNumericSpace(event)"
                                                            onblur="ValidateAccessoryColor(this, 'Row')" runat="server"></asp:TextBox>&nbsp;
                                                        <asp:CheckBox ID="chkDTM" CssClass="checkboxright" ToolTip="IsDTM" Checked='<%# Eval("IsDTM") %>'
                                                            runat="server" Style="position: relative; top: -2px;" />
                                                    </span>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--Size section--%>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="30px" ItemStyle-CssClass="BorderColor">
                                <HeaderTemplate>
                                    <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                        border-left: 0px !important; border-bottom: 0px !important;">
                                        <tr>
                                            <th style="font-size: 13px; min-width: 58px; height: 72px; border: 0px solid #999999 !important">
                                                Size
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:HyperLink ID="hlnkSize" ToolTip="SIZE SET POPUP" Text="" Style="cursor: pointer;"
                                            onclick="ShowSizeSet(this)" runat="server"></asp:HyperLink>
                                        <asp:HiddenField ID="hdnSizeQty" Value='<%# Eval("SizeQty") %>' runat="server" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--Action section--%>
                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-CssClass="BorderColorlast BorderColor">
                                <HeaderTemplate>
                                    <table width="100%" class="basicsectiotable" cellpadding="0" cellspacing="0" style="border-right: 0px !important;
                                        border-left: 0px !important; border-bottom: 0px !important;">
                                        <tr>
                                            <th style="font-size: 13px; min-width: 42px; height: 72px; border: 0px solid #999999 !important">
                                                &nbsp;
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:HiddenField ID="hdnIsSplit" Value="-1" runat="server" />
                                        <asp:HiddenField ID="hdnIsSplited" Value="-1" runat="server" />
                                        <img title="SPLIT THIS CONTRACT" style="cursor: pointer" src="/App_Themes/ikandi/images/split.jpg"
                                            id="imgSplit" runat="server" onclick="splitOrder(this)" />
                                        <br />
                                        <br />
                                        <asp:ImageButton ID="imgbtnDel" ToolTip="DELETE THIS CONTRACT" ImageUrl="~/images/delete-icon.png"
                                            OnClientClick="javascript:return ValidateContractDetails(this, 'DeleteRow')"
                                            CommandName="DeleteRow" runat="server" />
                                        <br />
                                        <br />
                                        <asp:ImageButton ID="imgbtnAdd" ToolTip="ADD THE CONTRACT" Visible="false" ImageUrl="~/images/add-butt-white.png"
                                            OnClientClick="javascript:return ValidateContractDetails(this, 'Row')" CommandName="AddRow"
                                            runat="server" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="clear: both;">
                </div>
                <div style="width: 98%; margin: 0 auto;">
                    <div id="divHistory" runat="server" class="tabcom clsActive" onclick="openContent(this, 'dvHistory', 0)">
                        History
                    </div>
                    <div id="divComment" runat="server" class="tabcom" onclick="openContent(this, 'dvComment', 0)">
                        Comments
                    </div>
                    <div id="divOldHistory" visible="false" runat="server" class="tabcom" onclick="openContent(this, 'dvOldHistory', 0)">
                        Old History
                    </div>
                    <div id="divOldComment" visible="false" runat="server" class="tabcom" onclick="openContent(this, 'dvOldComment', 0)">
                        Old Comments
                    </div>
                    <%--Showing Hitory        --%>
                    <div style="width: 100%;" id="dvHistory" runat="server">
                        <table style="width: 100%" class="Historytable">
                            <tr>
                                <th class="clsActiveth">
                                    <asp:HyperLink ID="hlnkAll_History" CssClass="historyth" onclick="ShowHistory(this, 0)"
                                        runat="server" Style="cursor: pointer;">All (Exclude Size Set)</asp:HyperLink>
                                </th>
                                <td rowspan="8" valign="top" style="color: Gray; font-size: 12px; padding-left: 10px;">
                                    <div id="rptDivHistory" style="height: 160px; overflow: auto">
                                        <span class="HistoryDescription"></span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkOrderHeader_History" CssClass="historyth" onclick="ShowHistory(this, 1)"
                                        runat="server" Style="cursor: pointer;">Order Header</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkExFactory_History" CssClass="historyth" onclick="ShowHistory(this, 2)"
                                        runat="server" Style="cursor: pointer;">Ex-Factory/DC</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkPrice_History" CssClass="historyth" onclick="ShowHistory(this, 3)"
                                        runat="server" Style="cursor: pointer;">Price & Finance</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkFabric_History" CssClass="historyth" onclick="ShowHistory(this, 4)"
                                        runat="server" Style="cursor: pointer;">Fabric</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkAccessories_History" CssClass="historyth" onclick="ShowHistory(this, 5)"
                                        runat="server" Style="cursor: pointer;">Accessories</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkSizeSet_History" CssClass="historyth" onclick="ShowHistory(this, 7)"
                                        runat="server" Style="cursor: pointer;">Size Set</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkOther_History" CssClass="historyth" onclick="ShowHistory(this, 6)"
                                        runat="server" Style="cursor: pointer;">Other</asp:HyperLink>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <%--Showing Comments        --%>
                    <div style="width: 100%; display: none;" id="dvComment" runat="server">
                        <table style="width: 100%" class="Historytable">
                            <tr>
                                <th class="clsActiveth">
                                    <asp:HyperLink ID="hlnkAll_Comment" CssClass="historyth" runat="server" onclick="ShowComment(this, 0)"
                                        Style="cursor: pointer;">All</asp:HyperLink>
                                </th>
                                <td rowspan="7" style="color: Gray; font-size: 12px; padding-left: 10px;" valign="top">
                                    <div class="CommentShowhide" style="float: left; width: 100%;">
                                        <asp:TextBox ID="txtComment" TextMode="MultiLine" Height="50px" runat="server" Width="80%"
                                            Style="text-transform: initial;"></asp:TextBox></div>
                                    <div class="CommentShowhide" style="float: right; padding-right: 10px; margin-top: -20px;">
                                        <asp:ImageButton ID="btnAdd" OnClientClick="javascript:return AddComment()" runat="server"
                                            ImageUrl="~/images/add.png" /></div>
                                    <div id="rptDivComment">
                                        <span style="width: 100%" class="CommentDescription"></span>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkOrderHeader_Comment" CssClass="historyth" onclick="ShowComment(this, 1)"
                                        runat="server" Style="cursor: pointer;">Order Header</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkExFactory_Comment" CssClass="historyth" onclick="ShowComment(this, 2)"
                                        runat="server" Style="cursor: pointer;">Ex-Factory/DC</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkPrice_Comment" CssClass="historyth" onclick="ShowComment(this, 3)"
                                        runat="server" Style="cursor: pointer;">Price & Finance</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkFabric_Comment" CssClass="historyth" onclick="ShowComment(this, 4)"
                                        runat="server" Style="cursor: pointer;">Fabric</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkAccessories_Comment" CssClass="historyth" onclick="ShowComment(this, 5)"
                                        runat="server" Style="cursor: pointer;">Accessories</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnkOther_Comment" CssClass="historyth" onclick="ShowComment(this, 6)"
                                        runat="server" Style="cursor: pointer;">Other</asp:HyperLink>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <%--old History--%>
                    <div style="width: 100%; display: none;" id="dvOldHistory" runat="server">
                        <table style="width: 100%" class="Historytable">
                            <tr>
                                <%--<th class="clsActiveth">
                                    <asp:HyperLink ID="hlnkAll_OldHistory" CssClass="historyth" onclick="ShowOldHistory(this, 99)"
                                        runat="server" Style="cursor: pointer;">All</asp:HyperLink>
                                </th>--%>
                                <th>
                                    <asp:HyperLink ID="hlnkAll_OldHistory" CssClass="historyth" onclick="ShowOldHistory(this, 11)"
                                        runat="server" Style="cursor: pointer;">Order</asp:HyperLink>
                                </th>
                                <td rowspan="3" valign="top" style="color: Gray; font-size: 12px; padding-left: 10px;">
                                    <div id="rptDivOldHistory">
                                        <span class="OldHistoryDescription"></span>
                                    </div>
                                </td>
                            </tr>
                            <%--<tr>
                                <th>
                                    <asp:HyperLink ID="hlnOrderHistory" CssClass="historyth" onclick="ShowOldHistory(this, 11)"
                                        runat="server" Style="cursor: pointer;">Order</asp:HyperLink>
                                </th>
                            </tr>--%>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnAccessoryHistory" CssClass="historyth" onclick="ShowOldHistory(this, 12)"
                                        runat="server" Style="cursor: pointer;">Accessory</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnFabricHistory" CssClass="historyth" onclick="ShowOldHistory(this, 13)"
                                        runat="server" Style="cursor: pointer;">Fabric</asp:HyperLink>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <%--old Comments--%>
                    <div style="width: 100%; display: none;" id="dvOldComment" runat="server">
                        <table style="width: 100%" class="Historytable">
                            <tr>
                                <%--<th class="clsActiveth">
                                    <asp:HyperLink ID="hlnkAll_OldComment" CssClass="historyth" runat="server" onclick="ShowOldComment(this, 99)"
                                        Style="cursor: pointer;">All</asp:HyperLink>
                                </th>--%>
                                <th>
                                    <asp:HyperLink ID="hlnkAll_OldComment" CssClass="historyth" onclick="ShowOldComment(this, 11)"
                                        runat="server" Style="cursor: pointer;">Order</asp:HyperLink>
                                </th>
                                <td rowspan="3" style="color: Gray; font-size: 12px; padding-left: 10px;" valign="top">
                                    <div class="OldCommentShowhide" style="float: left; width: 100%;">
                                        <%--<asp:TextBox ID="txtOldComment" TextMode="MultiLine" Height="50px" runat="server" Width="80%"
                                            Style="text-transform: initial;"></asp:TextBox></div> --%>
                                        <div id="rptDivOldComment">
                                            <span style="width: 100%" class="OldCommentDescription"></span>
                                        </div>
                                </td>
                            </tr>
                            <%--<tr>
                                <th>
                                    <asp:HyperLink ID="hlnOrderComment" CssClass="historyth" onclick="ShowOldComment(this, 11)"
                                        runat="server" Style="cursor: pointer;">Order</asp:HyperLink>
                                </th>
                            </tr>--%>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnAccessoryComment" CssClass="historyth" onclick="ShowOldComment(this, 12)"
                                        runat="server" Style="cursor: pointer;">Accessory</asp:HyperLink>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:HyperLink ID="hlnFabricComment" CssClass="historyth" onclick="ShowOldComment(this, 13)"
                                        runat="server" Style="cursor: pointer;">Fabric</asp:HyperLink>
                                </th>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="width: 98%; margin: 0 auto;" class="bottomtable-border-0">
                    <table width="100%" cellpadding="5" cellspacing="0">
                        <tr>
                            <td style="width: 25%;">
                                <asp:CheckBox ID="chkBiplManager" Enabled="false" TextAlign="Left" CssClass="checkboxtop"
                                    Text="Order Accepted By Top Management" runat="server" /><br />
                                <asp:Label ID="lblbiplManageron" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 25%;">
                                <asp:CheckBox ID="chkAcountManager" Enabled="false" CssClass="checkboxtop" TextAlign="Left"
                                    Text="Order Accepted By Account Manager" runat="server" /><br />
                                <asp:Label ID="lblAcountManageron" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 25%;">
                                <asp:CheckBox ID="chkFabricManager" Enabled="false" CssClass="checkboxtop" TextAlign="Left"
                                    Text="Fabric Manager" runat="server" /><br />
                                <asp:Label ID="lblFabricManageron" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 25%;">
                                <asp:CheckBox ID="chkAccessManager" Enabled="false" TextAlign="Left" CssClass="checkboxtop"
                                    Text="Accessories Manager" runat="server" /><br />
                                <asp:Label ID="lblAccessManageron" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 30px;">
                                &nbsp;
                                <asp:Label ID="lblMsgUnRegister" Style="color: Red;" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 98%; margin: 5px auto;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="do-not-include submit submitbtn"
                        OnClientClick="javascript:return ValidateSubmit(1);" ValidationGroup="orderValidation"
                        OnClick="btnSubmit_Click" />
                    <input type="button" id="btnPrint" class="print do-not-include doNotPressAgain da_submit_button"
                        value="Print" onclick="javascript:window.print();" style="line-height: 18px;
                        height: 21px" />
                    <asp:HiddenField runat="server" ID="hdnPath" Value="" />
                    <asp:Button ID="btnsentProposal" runat="server" Visible="false" Text="Send Proposal"
                        OnClientClick="return ValidateSubmit(2); " ValidationGroup="orderValidation"
                        CssClass="do-not-include submit" OnClick="btnsentProposal_Click" />
                    <asp:Button ID="btnAgree" runat="server" Visible="false" Text="Agree " OnClientClick="return ValidateSubmit(3);"
                        CssClass="do-not-include da_submit_button" ValidationGroup="orderValidation"
                        OnClick="btnAgree_Click" />
                </div>
                <div class="style_number_box containersize">
                    <table width="100%" cellpadding="6px" cellspacing="0">
                        <tr>
                            <td colspan="2" style="background: #39589c; width: 100%; padding: 6px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 12px;">
                                Style Number:
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" CssClass="do-not-allow-typing" ID="txtStyleNumber1" Width="90px"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtStyleNumber2" Width="60px" MaxLength="2" onKeyPress="return VinCheck(event);"
                                    onpaste="return false;">
                                </asp:TextBox>
                                <asp:HiddenField ID="hdnActive" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right" style="padding: 26px 10px;">
                                <input type="button" class="save da_submit_button" value="Save" onclick="SaveNewStyleNumber();" />
                                <input type="button" class="cancel da_submit_button" value="Cancel" onclick="HideAddStyleNumberBox();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlMessage" Visible="false" CssClass="do-not-include">
                <div class="form_box">
                    <div class="form_heading" style="color: #fff">
                        Confirmation
                    </div>
                    <div class="text-content" style="text-transform: initial">
                        Order Have Been Saved into the System Successfully!
                    </div>
                </div>
                <div class="OpenDialog">
                    <table width="100%" cellpadding="6px" cellspacing="0">
                        <tr>
                            <td style="background: #39589c; padding: 7px 0px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; text-transform: initial" class="text-content">
                                Do You Want to Open This Task
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <input type="button" class="save da_submit_button" value="Open" onclick="javascript:return OpenForikandi();" />
                                <input type="button" class="cancel da_submit_button" value="Close" onclick="HideOpenForikandiBox();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="dvFileUpload" class="modalNew">
        <div id="UpladFilepopup">
            <div class="UploadFileHeader">
                <span>Upload File</span> <span style="float: right; padding: 0px 3px; cursor: pointer;"
                    onclick="closeAccesButtion();">X</span>
            </div>
            <asp:UpdatePanel ID="pnl2" runat="server">
                <ContentTemplate>
                    <table cellpadding="0" width="250px" cellspacing="0" class="uploadfiletable">
                        <tr>
                            <td style="padding: 5px;">
                                <asp:FileUpload ID="PoUpload1" Width="150px" Font-Size="10px" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 5px;">
                                <asp:FileUpload ID="PoUpload2" Width="150px" Font-Size="10px" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="float: right;">
                                <asp:Button ID="btnUpload" runat="server" Text="Upload this" OnClick="btnUpload_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <%-- image popup--%>
    <div class="Imgshow">
        <div class="overlay">
        </div>
        <div class="img-show">
            <span>X</span>
            <div class="imgcontainer">
                <img src="">
            </div>
        </div>
    </div>
    <%--    end--%>
    <div id="dvSplit" class="modalNew">
        <div id="SplitPopup">
            <div class="UploadFileHeader">
                <span>Split Contract</span> <span style="float: right; padding: 0px 3px; cursor: pointer;"
                    onclick="SpiltContactClose();">X</span>
                <%-- <img src="../../images/delete.png" /></span>--%>
            </div>
            <div style="padding: 5px 5px;">
                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <th style="background-color: #F9DDF4; text-align: center; padding: 2px; color: Blue;">
                            Line Number:
                        </th>
                        <th style="background-color: #F9DDF4; text-align: center; padding: 2px; color: Blue;">
                            Contract Number
                        </th>
                        <th style="background-color: #F9DDF4; text-align: center; padding: 2px; color: Blue;">
                            Total Qty
                        </th>
                        <th style="background-color: #F9DDF4; text-align: center; padding: 2px; color: Blue;">
                            Balance
                        </th>
                    </tr>
                    <tr>
                        <td style="text-align: center; padding: 2px; color: #686767;">
                            <asp:Label ID="lblLineNo" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="text-align: center; padding: 2px; color: #686767;">
                            <asp:Label ID="lblContractNo" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="text-align: center; padding: 2px; color: #686767;">
                            <asp:TextBox ID="txtTotalSplitQty" Style="border: none;" Width="40px" MaxLength="8"
                                CssClass="do-not-allow-typing" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdnTotalSplitQty" Value="0" runat="server" />
                        </td>
                        <td style="text-align: center; padding: 2px; color: #686767;">
                            <asp:TextBox ID="txtSplitRemainingQty" Style="border: none;" Width="40px" MaxLength="8"
                                CssClass="do-not-allow-typing" Text="0" runat="server"></asp:TextBox>
                            <span style="color: Blue;">Pcs.</span>
                            <asp:HiddenField ID="hdnSplitRemainingQty" Value="0" runat="server" />
                        </td>
                    </tr>
                    <asp:HiddenField ID="hdnOrderDetailId_Split" Value="-1" runat="server" />
                </table>
            </div>
            <asp:UpdatePanel ID="pnl3" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <table cellpadding="0" width="450px" cellspacing="0" class="uploadfiletable" style="padding: 5px 5px;">
                        <tr>
                            <td style="">
                                Enter No. Of Splits: &nbsp;<asp:TextBox ID="txtSplitNo" Width="100px" MaxLength="2"
                                    CssClass="numeric-field-without-decimal-places" onkeyup="numbersonly(this)" runat="server"></asp:TextBox>
                                &nbsp;&nbsp; <span style="display: inline-block; width: 102px;">
                                    <asp:Button ID="btnSplitOk" runat="server" Text="OK" CssClass="ok da_submit_button"
                                        OnClientClick="javascript:return validateSplitNo()" OnClick="btnSplitOk_Click" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="overflow: auto; height: 200px; vertical-align: top">
                                <div style="overflow: auto; height: 200px;">
                                    <asp:Repeater ID="rptSplit" runat="server" OnItemDataBound="rptSplit_ItemDataBound">
                                        <ItemTemplate>
                                            <div style="width: auto; margin-right: 15px; margin: 1px 0px">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 112px; text-align: right;">
                                                            <asp:Label ID="lblSplit" runat="server" Text=""></asp:Label>
                                                            <asp:HiddenField ID="hdnSplitNo" Value='<%# Eval("SplitNo") %>' runat="server" />
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSplitQty" Width="100px" onblur="BalanceSplitQty(this)" MaxLength="6"
                                                                CssClass="numeric-field-without-decimal-places" onkeyup="numbersonly(this)" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="float: left; height: 20px;">
                                <asp:Label ID="lblSplitMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:DropDownList Visible="false" ID="ddlSplitType" runat="server">
                                    <asp:ListItem Text="Ascending" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Descending" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSubmitSplit" runat="server" Visible="false" Text="Submit" CssClass="save da_submit_button"
                                    OnClientClick="javascript:return validateAllSplit()" OnClick="btnSubmitSplit_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
