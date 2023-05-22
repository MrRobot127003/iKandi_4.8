<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Test.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.Test" %>

 <style type="text/css">
        .NoPadding
        {
            padding-top: 0px  !important;
            padding-bottom: 0px  !important;
        }
      #Test1_grdattendence td
      {
          padding:0px;
          height: 30px;
      }
     
      #Test1_grdattendenceHeaderCopy th
      {
          padding:0px;
          border-color: #b9b0b0;
border-collapse: collapse;
font-weight:normal;
      }
      #Test1_grdattendenceFreeze td
      {
          padding:0px;
           height: 30px;
      }
      #Test1_grdattendenceWrapper
      {
          margin:0px auto;
      }
        
        #preview
        {
           /* position: absolute;*/
           position:fixed;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
                       
        }
        
        .item_list2 TD 
        {
            padding:0px;
            background:none;
        }
        .fullwidthTd
        {
            border-right:none;
        }
        .fullwidthTd div
        {
             width:202px !important;
        }
        #Test1_grdattendence tr td table tr td
        {
            text-align:center;   
        }
       
        .norightborder
        {
            border-right:none; }
   .main-heading
    {
     font-size:18px;
     border-bottom:1px solid #d6d6d6;
     padding-bottom:10PX;
     margin-bottom:10PX;
	 font-family:lucida sans unicode !important;   
    }
     .ver-main-conte
    {
        font-size:13px;
        font-weight:400;
        font-style:normal;
        line-height:20px; 
        color:#333;
		font-family:lucida sans unicode !important;  
         
    } 
    span.nobr { white-space: nowrap; }  
    .gtext {
    color: red;
    title: Late coming;
    
}
.font-10
{
    font-size:10px;
}
.font-10 > div
{
    width:80px !important;
}

.disp-none
{
    display:none;
}
    .rotate
        {
            color: #000;
            display: block; /*Firefox*/
            -moz-transform: rotate(-90deg); /*Safari*/
            -webkit-transform: rotate(-90deg); /*Opera*/
            -o-transform: rotate(-90deg);
            -ms-transform: rotate(-90deg); /* ie*/
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            color: #405d9a;
            font-weight: bold;
            
            font-family: arial;
           
        }
        .rotate2
        {
            color: #000;
            display: block;
            color: #405d9a;
            font-weight: bold;
            
            font-family: arial;
            padding: 0px;
        }
        span.tooltip {
      position: absolute;
      width: 128px;
      height: 48px;
      line-height: 48px;
      padding: 0px 16px 0px 8px;
      font-size: 22px;
      text-align: center;
      color: rgb(255, 255, 255);
      background: rgb(96, 172, 57);
      border: 0px 0px 0px 0px none none none none rgb(255, 255, 255) rgb(70, 126, 42) rgb(255, 255, 255) rgb(255, 255, 255);
      border-radius: 0px 3.2px 3.2px 0px;
      text-shadow: rgba(0, 0, 0, 0.6) 1px 1px 1px;
      box-shadow: rgb(85, 153, 51) -4px 0px 4px 0px inset;
}

span.tooltip:after {
      content: "";
      position: absolute;
      width: 0;
      height: 0;
      border-width: 24px;
      border-style: solid;
      border-color: transparent #60AC39 transparent transparent;
      top: 0px;
      left: -48px;
}
.bgpartial

{
    background-color:#f0f3c9;
    }
    body {
    font-size: 12px;
    font-family: verdana;
    margin: 0px;
    padding: 0px;
}

.w-50
{
    width:50px;
}
.w-50 div
{
    width:100% !important;
}
.w-30
{
    width:30px;
}
.w-30 div
{
    width:100% !important;
}
.w-100
{
    width:100px;
}
.w-100 div{width:100% !important;}
.w-90
{
    width:90px;
}
.w-90 div{ width:100% !important;}
.w-80
{
    width:80px;
}


.w-80 div{ width:100% !important;}
    </style>
<script type="text/javascript">
    $(document).ready(function () {
        $('.tooltip').tooltipster();
        ShowImagePreview();

        gridviewScroll();
        var TableWidth = $(window).width() - 20;

        $('.inform-table').css("width", TableWidth);
    });
    function ShowImagePreview() {
        // debugger;
        xOffset = 100;
        yOffset = -450;
        $("td.preview").hover(function (e) {
            this.t = this.title;
            this.title = "";
            var c = (this.t != "") ? "<br/>" + this.t : "";
            $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:450px !important; width:320px !important;'/>" + c + "</p>");
            $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
        },

function () {
    this.title = this.t;
    $("#preview").remove();
});

        $("td.preview").mousemove(function (e) {
            $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
        });
    };
    </script>
 


    <script type="text/javascript">
        function gridviewScroll() {
            // debugger;
            var gridWidth = $(window).width() - 5;
            var gridHeight = $(window).height() - 40;

            // var gridFreezesize = 0;


            $('#Test1_grdattendence').gridviewScroll({
                width: gridWidth,
                height: gridHeight,
                freezesize: 12

            });
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            ShowImagePreview();
        });
        function ShowImagePreview() {
            debugger;
            xOffset = 200;
            yOffset = 0;
            $("td.previewNew .preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                //                alert(this.src);
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.src + "' alt='Image preview' style='height:350px !important; width:320px !important;'/>" + c + "</p>");
                $("#preview")
                //            .css("top", (e.pageY - xOffset) + "px")
                //            .css("left", (e.pageX + yOffset) + "px")
          .css("top", "30%")
            .css("left", "27%")
                //            .css("right", "2%")
                //             .css("bottom", "2%")
                //.css("bottom", (e.pageX - 100) + "px")
            .fadeIn("slow");
            },

function () {
    this.title = this.t;
    $("#preview").remove();
});

            $("td.preview .preview").mousemove(function (e) {
                $("#preview")
                //.css("top", (e.pageY - xOffset) + "px")
                //.css("left", (e.pageX + yOffset) + "px");
             .css("top", "50%")
            .css("left", "50%");
            });
        };
    </script>





<script src="http://www.boutique.in/js/gridviewScroll.min.js" type="text/javascript"></script>

<link href="http://www.boutique.in/css/GridviewScroll.css" rel="stylesheet" type="text/css" />


 
 

        <div>
        <span class="min-date-value"></span>
        
    
                <%--<div style="padding: 3px 0px; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                    font-size: 16px; text-transform: none;text-align: center;">
                    STAFF ATTENDANCE SHEET
                </div>--%>
                <div style="margin:0px auto;padding: 3px 0px; background-color: #405D99; color: #FFFFFF;text-transform: none; text-align:center;" class="inform-table">
                 Staff Attendance Sheet</div>
            
       <table cellpadding="0" cellspacing="0" style="border-collapse:collapse;margin: 2px 10px;" border="0">
        <tbody><tr>
        
            <td style="padding:0px 5px">
              <div style="width:15px; height:15px; background-color: rgb(255, 255, 0); float:left; border-radius:50%; border:1px solid gray;">&nbsp;</div>&nbsp; 
               WO <sapn style="color:gray"> (Weekly Off) </sapn>
            </td>
            <td style="padding:0px 5px">
                <div style="width:15px; height:15px; background-color:rgb(221, 223, 228); float:left; border-radius:50%; border:1px solid gray;">&nbsp;</div>&nbsp; 
               OD <sapn style="color:gray"> (On Out Door Duty) </sapn> 
            </td>
           
            <td style="padding:0px 5px">
                 <div style="width:15px; height:15px; background-color:#80e5a6; float:left; border-radius:50%; border:1px solid gray;">&nbsp;</div>&nbsp; 
              Planned Leave <sapn style="color:gray"> (Pre Informed Leave) </sapn> 
            </td>
            <td style="padding:0px 5px">
              <div style="width:15px; height:15px; background-color:#54C4EC; float:left; border-radius:50%; border:1px solid gray;">&nbsp;</div>&nbsp; 
               UnPlanned Leave <sapn style="color:gray"> (Random Leave Informed Same Day) </sapn> 

            </td>
      
            <td style="padding:0px 5px">
                <div style="width:15px; height:15px; background-color:#FFD27D; float:left; border-radius:50%; border:1px solid gray;">&nbsp;</div>&nbsp; 
               Unauthorized Absent <sapn style="color:gray"> (Leave Without Information) </sapn> 
            </td>       
       
        </tr>
    </tbody></table>
        <span runat="server" id="lblDtColumnCount" class="totColumnCount" style="display: none;">
        </span>
        <asp:GridView ID="grdattendence" runat="server" AutoGenerateColumns="false"
            RowStyle-HorizontalAlign="Center" OnRowDataBound="grdattendence_RowDataBound"
            RowStyle-ForeColor="#7E7E7E" CssClass="" HorizontalAlign="Center" OnDataBound="grdattendence_DataBound" style="margin:0px auto;">
        </asp:GridView>
    </div>