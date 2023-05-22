<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEmail.aspx.cs" Inherits="iKandi.Web.Internal.Merchandising.ProductEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../css/bootstrap.css">
    <script src="../../js/GarmentListJquery.js" type="text/javascript"></script>
    <script src="../../js/bootstrapJquery.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        .Emailmodal
        {
            display:block;
            position: fixed; 
            z-index: 1;
            padding-top: 0px;
            left: 0;
            top: 0;
            width: 100%; 
            height:auto;
            overflow: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4); 
            border-radius: 15px;
        }
      
        .Emailmodal-content
        {
            background-color: #fefefe;
            margin: auto;
            padding: 0px;
            width: 100%;
            border-radius: 5px;;
        }
        .close
        {
            color:#615d5d;
            float: right;
            font-size: 34px;
            font-weight: bold;
            opacity:.7;
        }
        
        .close:hover, .close:focus
        {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
        input[type='text']
        {
            margin:2px 0px;
         }
        .modal-header {
            padding: 0px 5px;
           border-bottom: 0px solid #e5e5e5;
           /*  background:#39589c;*/
            color:#fff;
                text-align: center;
        }
        .modal-body {
    position: relative;
    padding: 0px 15px;
}
        .input-group
        {
           display: flex;
            position:relative;
         }
        .input-group-text {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: center;
            align-items: center;
            padding: 1.1rem 1.75rem;
            margin-bottom: 0;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            text-align: center;
            white-space: nowrap;
            background-color: #e9ecef;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            z-index: 9;
            position: relative;
            top: 2px;
            left: 3px;
        }
        .ContactIcon {
        padding: 6px 10px !important;
        font-size: 20px !important;
        width: 40px;
        color: #5b5c5d !important;
    }
    .title
    {
        font-size: 22px;
        margin: 0px;
       font-weight: 600;
      }
      .btnleft
      {
          padding: 1px 10px;
          margin-left:3px;
        }
        .m-b-5
        {
            margin-bottom:5px;
         }
         .modal-arrow {
               content: "";
                display: block;
                position: fixed;
                top: -.12%;
                bottom: auto;
                left: 44%;
                width: 0;
                height: 0;
                border-style: solid;
                border-width: 27px 24px 28px 24px;
                border-color: transparent transparent #fff transparent;
        }
        textarea
        {
            font-size:11px;
            border-radius: 3px;
         }
         .modal-header .close {
    margin-top: 0px;
}

.m-b-5
{
    padding-left:3px !important
 }
  .btn-primary
 {
     background:#0c880c !important;
     color:#fff !important;
     }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="myModal" class="Emailmodal">
            <div class="Emailmodal-dialog">
                <div class="Emailmodal-content">
                    <div class="modal-header">
                        <button type="button" class="close" onclick="CloseModal()">
                            &times;</button>
                        <%--    <h4 class="modal-title">
                            Details Send To Email</h4>--%>
                        <div class="modal-arrow" id="left">
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-4 p-b-20" style='margin-top: -15px;'>
                                    <div class="wow fadeInLeft">
                                        <h1 class="title p-b-10" style="padding-bottom: 8px;">
                                            <img src="../../images/teliphone.png" />
                                            Business Enquiry</h1>
                                    </div>
                                </div>
                                <div class="col-md-8 p-b-20">
                                    <%--<div class="wow fadeInLeft">
                                        <h1 class="title p-b-10">
                                            <img src="../../images/teliphone.png" />
                                            Business Inquiries</h1>
                                    </div>--%>
                                    <div class="input-group m-b-5">
                                        <span><b>Style No. </b></span>
                                        <asp:Label ID="lblStyleNo" runat="server"></asp:Label>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text ContactIcon">
                                                <i class="fa fa-user-o"></i>
                                            </div>
                                        </div>
                                        <asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text ContactIcon">
                                                <i class="fa fa-envelope-o"></i>
                                            </div>
                                        </div>
                                        <asp:TextBox ID="txtEmailId" CssClass="form-control" required pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}"
                                            placeholder="Email ID" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text ContactIcon">
                                                <i class="fa fa-phone-square"></i>
                                            </div>
                                        </div>
                                        <asp:TextBox ID="txtPhoneNo" MaxLength="12" onkeypress="javascript:return isNumber(event)"
                                            placeholder="Phone Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group" style="left: 4px; margin: 4px 0px">
                                        <asp:TextBox ID="txtMassage" TextMode="MultiLine" placeholder="Remark" Width="99%"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group" style="text-align: center; margin-top: 7px">
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary btnleft" Text="Submit"
                                            OnClick="btnsubmit_Click" style='background: #b7b7b7;color: #3a3838;border:1px solid #b7b7b7' />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="BodyData" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--   <div class="modal-footer">
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function CloseModal() {
            //   alert();
            self.parent.Shadowbox.close();
        }

        //        function IsEmail(email) {
        //            alert(email);
        //            var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        //            if (!regex.test(email)) {
        //                alert("Enter Email Id!");
        //                return false;
        //            } 
        //        }

        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57 || iKeyCode == 46))
                return false;
            return true;
        }
        //        function funcReloadClosePO() {
        //            alert();
        //            self.parent.Shadowbox.close();
        //        }
    </script>
</body>
</html>
