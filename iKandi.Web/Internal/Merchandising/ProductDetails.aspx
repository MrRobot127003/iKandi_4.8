<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs"
    Inherits="iKandi.Web.Internal.Merchandising.ProductDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../css/bootstrap.css">
    <script src="../../js/GarmentListJquery.js" type="text/javascript"></script>
    <script src="../../js/bootstrapJquery.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/form.js"></script>
    <style>
          body {
          font-family:'open sans',sans-serif;
          background:#fff;
          height:100%;
        }
        .MainImage
        {
            width: 100%;
            margin-top: 10px;
        }
        .MainImage img
        {
            display: block;
            border-radius: 2px;
            padding: 0px 0px;
            width: 100%;
            height: 600px !important;
        }
        
        .SideImage
        {
            text-align: center;
            width: 100%;
            margin: 5px 0px;
            position: relative;
        }
        .SideImage span
        {
            float: left;
            width: 113px;
            margin: 5px 0px;
            cursor: pointer;
            background-color: rgba(0,0,0,0);
            border-radius: 10px;
            text-align: center;
        }
        
        .SideImage span img
        {
            width: 100%;
            margin: 0px 0px;
            height: 144px;
            padding: 3px 2px;
            border-radius: 5px;
            cursor: pointer;
        }
        
        .MainImage img:hover, .SideImage img:hover
        {
            box-shadow: 0 0 6px #ddd;
        }
        .p-l-r-5
        {
            padding: 5px 5px;
        }
        .carousel-control.left
        {
            background-image: unset;
            background-image: unset;
            background-image: unset;
            background-image: unset;
            filter: unset;
            background-repeat: repeat-no;
            height: 36px;
            top: 50%;
           /* background: #5f4e4e;*/
            padding: 0px;
            width: 20px;
                color: gray;
        }
        .carousel-control.right
        {
            background-image: unset;
            background-image: unset;
            background-image: unset;
            background-image: unset;
            filter: unset;
            background-repeat: repeat-no;
            height: 36px;
            top: 50%;
            /*background: #5f4e4e;*/
            padding: 0px;
            width: 20px;
                color: gray;
        }
        .productDescription
        {
            width: 98%;
            margin-top: 5%;
        }
        .productDescription .ProductCategory
        {
            font-size: 15px;
            color: #000;
            margin: 0px 0px;
            font-weight: 600;
        }
        .productDescription p
        {
            font-weight: 500;
            color: #888;
            font-size: 14px;
            line-height: 20px;
            margin-bottom: 3px;
        }
        
        .btnInquiry
        {
            margin: 20px auto;
            text-align: center;
            font-size: 14px;
            font-weight: 700;
            color: #fff;
            letter-spacing: .3px;
            text-transform: capitalize;
            padding: 5px 12px;
            border-radius: 2px;
            cursor: pointer;
            background: #fd7064;
            border: 1px solid #9999;
        }
        .ProductCategory 
        {
                 text-transform: capitalize;
        }
        .btnInquiry:hover
        {
            background: #fc796f;
        }
        .productDescription .social
        {
            margin-bottom: 8px;
        }
        .productDescription .social i
        {
            width: 36px;
            opacity: .9;
            cursor: pointer;
            margin-right: 3px;
            display: inline;
            font-size: 30px;
        }
        
        .productDescription .social i:hover
        {
            opacity: .7;
        }
        .m-t-25
        {
            margin-top: 25px !important;
        }
        .carousel-control i
        {
            position: relative;
            top: 27%;
        }
        .breadCrumbs a
        {
            text-decoration: none;
            color: gray;
            font-size: 14px;
            cursor: default;
        }
        .breadCrumbs i
        {
            font-size: 11px;
            color: gray;
            margin: 0px 5px;
        }
        
        div.social {
         
          margin:-2px auto;
          position: relative;
        }

        .social i {
            cursor: pointer;
            padding: 10px 8px 6px 8px;
            background: #fff;
            border-radius: 50%;
            display: inline-block;
            margin: 0 0 15px;
            color: #aaa;
            transition: .2s;
        }

       .social i:hover {
          color:#666;
        }

       /*.social i:before {
          font-family:fontawesome;
          content:'\f004';
          font-style:normal;
        }*/
          i.press {
          animation: size .4s;
          color:#525050;
        }

     .social span {
          position: absolute;
          top:17px;
          left:0;
          right:0;
          /*visibility: hidden;*/
          transition:.6s;
          z-index:-2;
          font-size:1px;
          color:transparent;
          font-weight:400;
        }

      .social span.press {
        top: 29px;
        font-size: 9px;
        visibility: visible;
        animation: fade 4s;
        z-index: 2222;
        left: 33px;
        }

        .social span.press1 {
        top: 25px;
        font-size: 10px;
        visibility: visible;
        animation: fade 2s;
        z-index: 2222;
        left: 30px;
        }
      @keyframes fade {
          0% {color:#transparent;}
          50% {color:#525050;}
          100% {color:#transparent;}
           from {top: 17px;}
           to {top: -35px;}
        }
        
        .carousel-inner {
    padding: 2px 2px;
    border: 1px solid #fff;
    border-radius: 5px;
} 
@media only screen and (max-width: 750px) and (min-width: 400px)  
{
     .SideImage
        {
          height:130px; 
        }
     }
     @media only screen and (max-width:399px) and (min-width: 300px)  
{
     .SideImage
        {
          height:100px; 
        }
     }
     
      .txtColorBack
         {
               
                color: #524d4d;
                position: absolute;
                top: -13px;
                left: 44px;
                font-weight: 600;
                font-size: 10px;
                background: #bca5a5d1;
                border-radius: 50%;
                width: 18px;
                height: 18px;
                text-align: center;
                padding-top: 2px;
          }  
          #sb-wrapper-inner
          {
              border-radius:15px;
           }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="debitnote-table" style="max-width: 1000px; margin: 5px auto;">
        <div class="container">
            <div class="folderTab clearFix">
                <div class="breadCrumbs">
                    <a href="#">Home</a><i class="fa fa-angle-right" aria-hidden="true"></i> <a href="#"
                        id="ProductName" runat="server"></a><i class="fa fa-angle-right" aria-hidden="true">
                        </i><a href="#" id="ProStyleNo" runat="server"></a>
                </div>
            </div>
            <div class="row">
                <div id="ProductDetail" runat="server">
                </div>
            </div>
        </div>
    </div>
    </form>
    <%-- Email Containner--%>
    <script type="text/javascript">

        function EmailModal(ele) {
            // alert(ele);
            debugger;
            var FabricStyleNo = ele.id;
            var sURL = "ProductEmail.aspx?FabStyle=" + FabricStyleNo;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 280, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;

        }
        function SBClose() { }
       
        var ProDCount = 0;
        function FontAwesomeFun(ele) {
            debugger;
            $(ele).toggleClass('fa fa-heart-o fa fa-heart');
            var ProdedatailStyleid = ele.id;
            $(ele).after('<span class="fa fa-heart press"></span><span class="fa fa-heart press1"></span>').addClass("press press", 1000);
            ProDCountDetail = 1;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/SaveLikeCountProductDetails",
                data: "{ ProdedatailStyleid:'" + ProdedatailStyleid + "', ProDCountDetail:'" + ProDCountDetail + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                debugger;
                $('[likecount="' + ProdedatailStyleid + '"]').removeAttr("onclick");
            }

            function OnErrorCall(response) {

            }
        }

    </script>
</body>
</html>
