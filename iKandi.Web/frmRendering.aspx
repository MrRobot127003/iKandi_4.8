<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRendering.aspx.cs" Inherits="iKandi.Web.frmRendering" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .MainContainer
        {
            min-height: 500px;
            width: 100%;
        }
        .ContainerWidth
        {
            width: 400px;
            margin: 14% auto;
        }
        .login-box
        {
            box-shadow: 1px 1px 7px #666;
            margin-top: 10%;
            border-radius: 10px;
            height: 300px;
            background: #fff;
            text-align: center;
        }
        .topHeading
        {
            background: #fff;
            padding: 0px;
            height: 50px;
            border-top-right-radius: 10px;
            border-top-left-radius: 10px;
            position: relative;
        }
        .topHeading .topAfter:after
        {
            content: "";
            position: absolute;
            top: 97%;
            left: 45%;
            border-width: 21px;
            border-style: solid;
            border-color: #193062 transparent transparent transparent;
        }
        .LinkSection
        {
            margin: 10px 0px;
            padding: 4px 10px 5px;
            text-align: justify;
            margin-left: 8%;
        }
        .login-box h3
        {
            font-size: 20px;
            color: #6f6767;
            font-weight: 600;
            margin-top: 0px;
            margin-bottom:30px;
        }
        .LegacySection
         {
            margin: 10px 0px;
            padding: 4px 10px 5px;
            text-align: justify;
            margin-left: 8%;
        }
         .LinkSection a
        {
            text-decoration: none;
            font-size: 16px;
            color:#0d82fa
        }
        .LegacySection a
        {
            text-decoration: none;
            font-size: 16px;
            color:#9e8f8f
        }
    </style>
</head>
<body style="background-image: url('images/background-03.jpg')">
    <form id="form1" runat="server">
    <div class="MainContainer">
        <div class="ContainerWidth">
            <div class="login-box">
                <div class="topHeading">
                   <%-- <div class="topAfter">
                    </div>--%>
                </div>
                <h3>
                    Please Click here on below:-</h3>
              
                <div class="LinkSection">
                    <a href="http://192.168.0.106:85/public/login.aspx" target="_blank">Current Web Site(2018 to Present)</a>
               </div>
               <div class="LegacySection">
                    <a href="http://192.168.0.106:83/public/login.aspx" target="_blank">Legacy Web Site(2010 to 2018)</a>
                </div>
           
            </div>
        </div>
    </div>
    </form>
</body>
</html>
