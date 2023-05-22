<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGarmentProductList.aspx.cs"
    Inherits="iKandi.Web.Internal.Merchandising.frmGarmentProductList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../../css/bootstrap.css">
    <script src="../../js/GarmentListJquery.js" type="text/javascript"></script>
    <script src="../../js/bootstrapJquery.js" type="text/javascript"></script>
    <script src="../../js/JScriptPagination.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="../../css/StyleRange.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <style type="text/css">
        body {
          font-family:'open sans',sans-serif;
          background:#fff;
          height:100%;
        }
        .debitnote-table
        {
            font-family: sans-serif !important;
            width: 98%;
        }
        .debitnote-table .top_heading
        {
               text-align: center;
                text-transform: capitalize;
                font-size: 16px;
                font-weight: 600;
                padding: 3px 0px;
                color: #393636;
                background: #c7c4c4;
                display: inline-block;
                width: 100%;
        }
        .btnSearch
        {
            padding: 0px 7px;
            margin-left: 5px;
            background: green;
            color: #fff;
            font-size: 13px;
            border: 1px solid green;
            border-radius: 2px;
        }
        .SearchProduct
        {
            margin: 10px 5px;
        }
        .Departmenthead
        {
            font-size: 13px;
            font-weight: 500;
            padding: 3px 0px;
            color: #000;
            position: relative;
            text-align: center;
            top: 2%;
            display: block;
            background-color: #e2e2e2;
            font-family: sans-serif !important;
        }
        .DeparmentDiv
        {
            width: 100%;
            position: relative;
            padding-left: 3px;
            top: -15px;
            max-height: 85px;
            overflow: auto;
        }
        .top-10
        {
            margin-top:-10px !important;
         }
        .FabricDiv
        {
            margin-top: -15px;
            padding-left: 3px;
            max-height: 85px;
            overflow: auto;
        }
            .FabricDiv td label
            {
               font-size:11px;
              font-family:sans-serif !important;
              position: relative;
              top: -2px;
             }
        .DeparmentDiv span
        {
            width: auto;
            height: auto;
            border-radius: 3px;
            margin: 5px 5px;
            font-size: 14px;
        }
        .DeparmentDiv td label
        {
              font-size:11px;
              font-family:sans-serif !important;
              position: relative;
              top: -2px;
         }
        .ProductListImages
        {
             height: 420px;
              margin: -5px 5px 3px;
            padding: 0px 0px;
          /* box-shadow: 1px 4px 7px 1px #e8dddd;*/
        }
        .Productcard
        {
            margin: auto;
            font-family: arial;
            max-width: 100%;
            padding: 5px 7px;
        }
        .Productcardimage
        {
               width: 100%;
                padding: 0px 0px;
                height: 320px;
                box-shadow: 3px 4px 11px 1px rgba(0, 0, 0, 0.2);
                margin-bottom: 13px;
                text-align: center;
                cursor: pointer;
                transition: 0.3s;
                overflow: hidden;
                border-radius: 3px;
               
        }
        .Productcardimage img
        {
            width: 100%;
            transition: transform 1s, filter 1.5s ease-in-out;
            transform-origin: center center;
            filter: brightness(100%);
            height: 100%;
        }
         .Productcardimage:hover img
        {
            filter: brightness(100%);
           transform: scale(1.3);
        }
        .ProducTitle
        {
            color: #000;
            font-size: 17px;
        }
       
        .Producttext
        {
            width: 82%;
            float: left;
        }
        .Productcard .Producttext p
        {
            color: Gray;
            font-size: 12px;
        }
        .Productcard .ProductLike
        {
           
            positon: relative;
            
        }
        .Productcard .ProductLike i
        {
            font-size: 25px;
        }
       /* .Productcard .ProductLike i:hover
        {
            color: green;
        }
        .Productcard .ProductLike i:focus
        {
            color: green;
        }*/
        .p-l-0
        {
            padding-left: 0px;
        }
        
        @media (min-width: 992px)
        {
            .col-md-3
            {
                width: 24%;
            }
        }
        input[type='checkbox']
        {
            position: relative;
            top: 1px;
            margin-right: 3px;
        }
        
        #pagingControls ul
        {
            display: inline;
            padding-left: 0.5em;
        }
        #pagingControls li
        {
            display: inline;
            padding: 0 0.5em;
            color: #337ab7;
            font-weight: 700;
        }
        #pagingControls li a
        {
            color: #58626b;
            font-weight: 700;
        }
        label
        {
            font-weight: 500;
             font-family: sans-serif !important;
             margin-bottom: 2px;
        }
        .fa-heart-o
        {
            cursor:pointer;
         }
         .fa-heart
         {
              
            cursor:auto;
         }
         
         div.ProductLike {
          height:40px;
          margin:0 auto;
          position: relative;
        }

        i {
            cursor: pointer;
            padding: 10px 8px 6px 8px;
            background: #fff;
            border-radius: 50%;
            display: inline-block;
            margin: 0 0 15px;
            color: #aaa;
            transition: .2s;
        }

        i:hover {
          color:#666;
        }
        /*.fa-heart:before {
            content: "\f08a";
        }*/
        i:before {
          font-family:fontawesome;
          content:'\f004';
          font-style:normal;
        }
          i.press {
          animation: size .4s;
          color:#525050;
        }

    span {
          position: absolute;
          top:17px;
          left:0;
          right:0;
          /*visibility: hidden; */
          transition:.6s;
          z-index:-2;
          font-size:1px;
          color:transparent;
          font-weight:400;
        }

       span.press {
        top: 29px;
        font-size: 9px;
        visibility: visible;
        animation: fade 2s;
        z-index: 2222;
        left: 13px;
        }

        span.press1 {
        top: 25px;
        font-size: 10px;
        visibility: visible;
        animation: fade 3s;
        z-index: 2222;
        left: 10px;
        }
      @keyframes fade {
          0% {color:#transparent;}
          50% {color:#525050;}
          100% {color:#transparent;}
           from {top: 17px;}
           to {top: -35px;}
        }
         

        @keyframes size {
         /* 0% {padding:10px 12px 8px;}
          50% {padding:14px 16px 12px;}
          100% {padding:10px 12px 8px;}*/
        }
         .txtColorBack
         {
               
                color: #524d4d;
                position: absolute;
                top: -1px;
                left: 31px;
                font-weight: 600;
                font-size: 10px;
                background: #bca5a5d1;
                border-radius: 50%;
                width: 18px;
                height: 18px;
                text-align: center;
                padding-top: 2px;
          }  
          input[type=text]{
            border: 1px solid #cccccc;
            text-transform: capitalize !important;
            font-size: 11px;
            padding-left: 2px;
            border-radius: 2px;
        }
      .maxwidthLength
      {
          white-space: nowrap; 
          width: 190px; 
          overflow: hidden;
          text-overflow: ellipsis; 
        }
     [data-title] {
       position: relative;
     }

     [data-title]:hover::after {
           content: attr(data-title);
            position: absolute;
            top: 18px;
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
            width: 235px;
        }
       [data-title]:hover::before {
          content: '';
          position: absolute;
          bottom:4px;
          left: 5px;
          display: inline-block;
          color: #fff;
          border: 8px solid transparent;	
          border-bottom: 8px solid #403c3c;
        }
        span.GarmentFabric
        {
            background: #80808000;
            padding: 2px 7px;
            border: 1px solid #dcd9d9;
            margin: 0px 2px 0px;
            border-radius: 10px;
            font-size: 11px;
            position: unset;
            color: #7d7979;
         }
        
        @media (min-width: 1367px) {
  .debitnote-table {
    width: 1580px !important;
  }
}
.pad-right
{
    padding-right: 0px !important;
 }
 
 span.MinRangeC
 {
    position: relative;
    font-size: 12px;
    color: Black;
    top: -2px;
     
  }
   span.MaxRangeC
 {
        position: relative;
        font-size: 12px;
        color: Black;
        float: right;
        top: -31px;
     
  }
  span.PriceEnquiry
  {
      font-size: 12px;
      color: Black;
      position: relative;
      top: 0;
   }
   span.sectprice
   {
        font-size: 12px;
      color: Black;
      position: relative;
      top: 0;
       
       }
       .PriceEnquiry {
      position: relative;
      display: inline-block;
      cursor:pointer;
    }

.PriceEnquiry .PriceEnquiryHover {
    visibility: hidden;
    width: 180px;
    background-color: #494747;
    color: #f0dcdc;
    text-align: center;
    border-radius: 6px;
    padding: 3px 10px 3px;
    position: absolute;
    z-index: 1;
    top: -109%;
    left: 75%;
    margin-left: -60px;
    font-size: 11px;
}

.PriceEnquiry .PriceEnquiryHover::after {
    Content: "";
    position: absolute;
    top: 97%;
    left: 31%;
    margin-left: -8px;
    border-width: 7px;
    border-style: solid;
    border-color: #494747 transparent transparent transparent;
}

.PriceEnquiry:hover .PriceEnquiryHover {
  visibility: visible;
}
#sb-wrapper-inner
{
    border-radius:20px;
 }
 .PositionRelative
 {
     position:relative;
  }
  #spinner
        {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #33333354;
        }
         ::-webkit-scrollbar {
    background: #dbd6d6;
    width: 4px;
   cursor:pointer;height:4px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="debitnote-table" style="width: 1336px; margin: 5px auto;">
        <asp:ScriptManager ID="scriptmanager1" runat="server">
        </asp:ScriptManager>
        <div>
            <%-- <img src="../../App_Themes/ikandi/images1/loading128.gif" />--%>
            <asp:UpdatePanel ID="updatepnl" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hdnMinVal" runat="server" />
                    <asp:HiddenField ID="hdnMaxVal" runat="server" />
                    <asp:HiddenField ID="hdnMaxOneVal" runat="server" />
                    <asp:HiddenField ID="hdnMinValone" runat="server" />
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="top_heading">
                                    Our Designs</div>
                                <asp:HiddenField ID="hdnLikeCount" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3" style='padding-left: 10px; margin-top: -7px;'>
                                <div class="SearchProduct">
                                    <asp:TextBox ID="txtSearchProduct" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnSearch" CssClass="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                            <div class="col-md-9">
                                <div id="GarmentTextShow" runat="server" style='position: relative; padding: 5px 0px 2px;'>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 col-sm-12 pad-right">
                                <span class="Departmenthead">Type of Garment</span><br>
                                <div class="DeparmentDiv">
                                    <asp:CheckBoxList runat="server" AutoPostBack="true" ID="cbListDepartment" RepeatColumns="1"
                                        RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </div>
                                <div style="clear: both">
                                </div>
                                <span class="Departmenthead top-10">Tags</span><br>
                                <div class="FabricDiv">
                                    <asp:CheckBoxList runat="server" ID="chkTagsName" AutoPostBack="true" RepeatColumns="1"
                                        RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </div>
                                <br>
                                <div style="clear: both">
                                </div>
                                <span class="Departmenthead top-10">Fabric Composition</span><br>
                                <div class="FabricDiv">
                                    <asp:CheckBoxList runat="server" ID="chkComposition" AutoPostBack="true" CssClass="maxwidthLength"
                                        RepeatColumns="1" RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </div>
                                <br>
                                <div style="clear: both">
                                </div>
                                <span class="Departmenthead top-10">Fabric Quality</span><br>
                                <div class="FabricDiv">
                                    <asp:CheckBoxList runat="server" ID="cbFabricList" AutoPostBack="true" RepeatColumns="1"
                                        RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </div>
                                <br />
                                <div style="clear: both">
                                </div>
                                <span class="Departmenthead top-10">Collection</span><br>
                                <div class="FabricDiv">
                                    <asp:CheckBoxList runat="server" ID="chkCollection" AutoPostBack="true" RepeatColumns="1"
                                        RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </div>
                                <br>
                                <div style="clear: both">
                                </div>
                                <span class="Departmenthead top-10">MOQ</span><br>
                                <div class="FabricDiv">
                                    <asp:CheckBoxList runat="server" ID="chkMoq" AutoPostBack="true" RepeatColumns="1"
                                        RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </div>
                                <br>
                                <div style="clear: both">
                                </div>
                                <div class="col-md-12" style="margin-bottom: 20px; padding-left: 5px;">
                                    <div class="col-md-12" style="padding-left: 0px; margin-bottom: 5px;">
                                        <span class="sectprice" style="color: #5e5c5c; font-size: 11px">Change Currency:
                                        </span>
                                        <asp:DropDownList ID="ddlCurrencyConvert" runat="server" Font-Size="12px" onchange=""
                                            OnSelectedIndexChanged="SelectCurrencyCha" AutoPostBack="false">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-12" style="padding-left: 0px; margin-bottom: 5px;">
                                        <span class="sectprice" style="color: #5e5c5c; font-size: 11px">Price Range Selected:
                                        </span>
                                        <br />
                                        <asp:Label ID="lblMinMaxSelctedPrice" CssClass="sectprice" ForeColor="#000" runat="server"></asp:Label>
                                        <asp:Label ID="lblMaxSelctedPrice" CssClass="sectprice" ForeColor="#000" runat="server"></asp:Label>
                                    </div>
                                    <asp:Label ID="lblminRun" CssClass="MinRangeC" runat="server"></asp:Label>
                                    <asp:Label ID="lblMinRange" CssClass="MinRangeC" runat="server"></asp:Label>
                                    <div id="slider-range" style='margin-right: 15px;'>
                                    </div>
                                    <asp:HiddenField ID="hdnCurrency" runat="server" />
                                    <%-- <asp:Label ID="lblMaxCu" CssClass="MinRangeC" runat="server"></asp:Label>--%>
                                    <asp:Label ID="lblMaxRange" CssClass="MaxRangeC" runat="server" Style="padding-left: 0px;"></asp:Label>
                                </div>
                                <div class="col-md-12" style="height: 20px;">
                                </div>
                            </div>
                            <div class="col-md-10 col-sm-12 PositionRelative">
                                <div id="ProductList" runat="server">
                                </div>
                                <div id="spinner">
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="pagingControls">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script src="../../js/CostRange/ProDuctShadowBox.js" type="text/javascript"></script>
    <script src="../../js/CostRange/range%20jQuery.js" type="text/javascript"></script>
    <script src="../../js/CostRange/sliderRange.js" type="text/javascript"></script>
    <script type="text/javascript">


        var maxval = "";
        var minval = "";
        var hdnMin = "";
        var hdnMax = "";
        var abcmin = "";
        var abcmax = "";
        var oneMin = "";
        var oneMax = "";
        var CurrencySym = "";
        var SelectedPrice = "";
        var CurrencyMinVlau = "";
        var pager = "";
        var CurrencyMaxVlau = "";
        var addoneVal;


        $(document).ready(function () {
            $("#btnSearch").click();
            costRangfun();

            $(window).load(function () { $("#spinner").fadeOut("slow"); });
        });
        function currentFunPath(ele) {
            var ImgId = ele.id;
            var strVal = ImgId.split("_");
            var ImgIdV = strVal[0];
            var CurrencyVal = strVal[1];

            window.open('ProductDetails.aspx?CommonString=' + ImgIdV + '&CurrencyString=' + CurrencyVal);
        }

        var ProDCount = 0;
        function FontAwesomeFun(ele) {
            debugger;
            $(ele).toggleClass('fa fa-heart-o fa fa-heart');
            var ProdStyleid = ele.id;
            $(ele).after('<span class="fa fa-heart press"></span><span class="fa fa-heart press1"></span>').addClass("press press", 1000);
            ProDCount = 1;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/SaveLikeCountProduct",
                data: "{ ProdStyleid:'" + ProdStyleid + "', ProDCount:'" + ProDCount + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                $('[likecount="' + ProdStyleid + '"]').removeAttr("onclick");
            }

            function OnErrorCall(response) {
            }
        }



        function pageLoad() {
            pager = new Imtech.Pager();
            //pager.paragraphsPerPage = 8;
            pager.pagingContainer = $('#ProductList');
            pager.paragraphs = $('div.ProductPagination', pager.pagingContainer);
            pager.showPage(1);

            costRangfun();

            if (oneMin != "") {
                callback();
            }
            $('#ddlCurrencyConvert').change(function () {
                $("#btnSearch").click();
            });
            $("#spinner").fadeOut("slow");
        }


        function costRangfun() {
            var dropVal = $('#ddlCurrencyConvert').val();
            if (dropVal == 3) {
                addoneVal = 5;
            }
            else {
                addoneVal = 5;
            }

            minval = $("#hdnMinVal").val();
            maxval = $("#hdnMaxVal").val();
            CurrencySym = $("#hdnCurrency").val();

            $("#lblMinRange").text(CurrencySym + " " + minval);
            $("#lblMaxRange").text(CurrencySym + " " + maxval);

            oneMin = $("#hdnMinValone").val();
            oneMax = $("#hdnMaxOneVal").val();
            $("#slider-range").slider({
                range: true,
                min: 0,
                step: addoneVal,
                max: oneMax,
                values: [oneMin, maxval],
                slide: function (event, ui) {
                    $("#hdnMinValone").val(ui.values[0]);
                    $("#hdnMaxVal").val(ui.values[1]);
                    abcFun();
                }

            });
        }

        function abcFun() {
            abcmin = $("#hdnMinValone").val();
            abcmax = $("#hdnMaxVal").val();
            minval = $("#hdnMinVal").val();
            oneMax = $("#hdnMaxOneVal").val();

            CurrencySym = $("#hdnCurrency").val();
            var dropVal = $('#ddlCurrencyConvert').val();

            if (abcmin > minval) {
                $("#lblMinRange").text(CurrencySym + " " + abcmin);
            }
            else {
                if (abcmin > 0) {
                    $("#lblMinRange").text(CurrencySym + " " + abcmin);
                } else {
                    $("#lblMinRange").text(CurrencySym + " " + minval);
                }
            }
            if (oneMax > abcmax) {
                $('#lblMinMaxSelctedPrice').text(CurrencySym + " " + minval + " - " + CurrencySym + " " + abcmax);
            }
            if (abcmin == "0") {
                $("#hdnMinValone").val(minval);
            }
            $("#lblMaxRange").text(CurrencySym + " " + abcmax);
            if (abcmin > 0) {
                if (abcmin == "") {
                    $('#lblMinMaxSelctedPrice').text(CurrencySym + " " + minval + " - " + CurrencySym + " " + abcmax);
                }
                else {
                    $('#lblMinMaxSelctedPrice').text(CurrencySym + " " + abcmin + " - " + CurrencySym + " " + abcmax);
                }
            } else {
                $('#lblMinMaxSelctedPrice').text(CurrencySym + " " + minval + " - " + CurrencySym + " " + abcmax);
            }

            $("#btnSearch").click();
            $("#spinner").fadeIn("slow")
        }

        function callback() {
            var dropVal = $('#ddlCurrencyConvert').val();
            if (dropVal == 3) {
                addoneVal = 5;
            }
            else {
                addoneVal = 5;
            }
            minval = $("#hdnMinVal").val();
            maxval = $("#hdnMaxVal").val();
            CurrencySym = $("#hdnCurrency").val();
            $("#lblMinRange").text(CurrencySym + " " + minval);
            $("#lblMaxRange").text(CurrencySym + " " + maxval);

            oneMin = $("#hdnMinValone").val();
            oneMax = $("#hdnMaxOneVal").val();
            $("#slider-range").slider({
                range: true,
                min: 0,
                step: addoneVal,
                max: oneMax,
                values: [oneMin, maxval],
                slide: function (event, ui) {
                    $("#hdnMinValone").val(ui.values[0]);
                    $("#hdnMaxVal").val(ui.values[1]);
                    abcFun();
                }

            });
            abcmin = $("#hdnMinValone").val();
            abcmax = $("#hdnMaxVal").val();
            if (abcmin > minval) {
                $("#lblMinRange").text(CurrencySym + " " + abcmin);
            }
            else {
                if (abcmin > 0) {
                    $("#lblMinRange").text(CurrencySym + " " + abcmin);
                } else {
                    $("#lblMinRange").text(CurrencySym + " " + minval);
                }
            }
            $("#lblMaxRange").text(CurrencySym + " " + abcmax);

            minval = $("#hdnMinVal").val();
            maxval = $("#hdnMaxVal").val();
            if (abcmin == "") {
                $('#lblMinMaxSelctedPrice').text(CurrencySym + " " + minval + " - " + CurrencySym + " " + abcmax);
            } else {
                $('#lblMinMaxSelctedPrice').text(CurrencySym + " " + abcmin + " - " + CurrencySym + " " + abcmax);
            }
            $("#spinner").fadeOut("slow")
        }

        function PriceEnquiryFun(ele) {
            var Styleid = ele.id;
            var sURL = "ProductEmail.aspx?FabStyle=" + Styleid;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 280, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }
        function SBClose() { }
        $('#ddlCurrencyConvert').change(function () {
            // alert($(this).val())
            $("#btnSearch").click();

        })


    </script>
</body>
</html>
