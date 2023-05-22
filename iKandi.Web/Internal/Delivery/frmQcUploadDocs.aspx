<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmQcUploadDocs.aspx.cs"
    Inherits="iKandi.Web.Internal.Delivery.frmQcUploadDocs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-family: Arial;
            font-size: 11px;
        }
        
        
        .b
        {
            font-weight: bold;
        }
        #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        .preview IMG
        {
            height: 30px;
            width: 80%;
            float: left;
        }
        .img-fll
        {
            float: left;
            padding: 10px !important;
            width: auto !important;
            background: none !important;
            position: relative;
        }
        #UpdatePanel2
        {
            background: none !important;
        }
        .item_list TH
        {
            background-color: #39589c;
            color: #fff;
            font-size: 14px;
            font-weight: bold;
            padding: 5px 0;
        }
        .img-wrap {
        position: relative;
    float: left;
    padding: 5px;
    cursor: pointer;
    
  
}
.img-wrap .close {
   position: absolute;
    top: -4px;
    right: 0px;
    z-index: 100;
    font-size: 20px;
    color: red;
    
}
.HasError
{
    border:1px solid red !important;
}
.NoError
{
     border:1px solid #FFFFFFF !important;
}
 input[type="file"]
 {
     font-size:10px;
  }
  .QcUPlo_submit_button{
    background: #3b5998;
    width: auto;
    border: 0px;
    padding: 1px 9px;
    cursor: pointer;
    color: #f8f8f8;
    text-decoration: none;
    text-align: center;
    font-size: 12px;
    font-weight: bold;
    margin: 1px;
    border-radius: 2px;
}
 .QcUPlo_submit_button:hover {
    background: #3b5998;
    width: auto;
    border: 0px;
    padding: 1px 9px;
    cursor: pointer;
    color: yellow;
    text-decoration: none;
    text-align: center;
    font-size: 12px;
    font-weight: bold;
    margin: 1px;
    border-radius: 2px;
}
input[type="text"].hasDatepicker
{
    margin-right:2px;
 border-color: #999999 !important;
}

.item_list1 TD {
    border: 1px solid #999999 !important;
}
.da_submit_button
{
    border-radius: 2px;
 }
 .submit{
    border-radius: 2px;
    cursor:pointer;
 }
 .CommoAdmin_Table td {
    padding: 2px 3px !important;

}


.CommoAdmin_Table td input[type="text"] {
    margin: 1px 4px !important;
}




    .ui-datepicker-prev:before {
      content: url('../../images/left_15.png');
      position: absolute;
      top: 1px;
    }

    .ui-datepicker-next:before {
      content: url('../../images/right_15.png');
      position: absolute;
      top: 3px;
      right: 1px;
    }
    .ui-datepicker .ui-datepicker-prev span, .ui-datepicker .ui-datepicker-next span {
    cursor: pointer;
}

.ui-widget-content
{
        display:none;
    }


    </style>
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>    
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
  <script src="../../CommonJquery/JqueryLibrary/form.js" type="text/javascript"></script>
   <script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script> 
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        //-------------------edit by prabhaker------------------//

//        $(document).ready(function () {
//            // debugger;

//            var filepath = $("#hdnFileFirst").val();
//            if (filepath != "") {
//                var arr = filepath.split('.');
//                var fullfilePath = "/uploads/Quality/" + filepath;
//                if (arr[1] == "pdf") {
//                    $(".firstimg").attr("src", "../../images/pdf.png");
//                    $(".firstImagePreview").removeClass("preview");
//                }
//                else {
//                    $(".firstimg").attr("src", fullfilePath);
//                }
//                $(".firstImagePreview").attr("href", fullfilePath);
//            }
//            else {
//                $(".firstImagePreview").hide();
//            }

//            var filepath10pcs = $("#hdnFileFirst10").val();
//            if (filepath10pcs != "") {
//                var fullfilePath10pcs = "/uploads/Quality/" + filepath10pcs;
//                var arr10pcs = filepath10pcs.split('.');
//                if (arr10pcs[1] == "pdf") {
//                    $(".Secondimg").attr("src", "../../images/pdf.png");
//                    $(".SecondImagePreview").removeClass("preview");
//                }
//                else {
//                    $(".Secondimg").attr("src", fullfilePath10pcs);
//                }

//                $(".SecondImagePreview").attr("href", fullfilePath10pcs);
//            }
//            else {
//                $(".SecondImagePreview").hide();
//            }

//            ShowImagePreview();
//        });
//        function ShowImagePreview() {
//            // debugger;
//            $("a.preview").hover(function (e) {
//                this.t = this.title;
//                this.title = "";
//                var c = (this.t != "") ? "<br/>" + this.t : "";
//                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:180px !important; width:160px !important;'/>" + c + "</p>");
//                $("#preview").css("top", "-10px").css("right", "0px").fadeIn("slow");
//            },

//function () {
//    this.title = this.t;
//    $("#preview").remove();
//});

//            $("a.preview").mousemove(function (e) {
//                $("#preview")
//                .css("top", "-10px").css("right", "0px");
//            });
//        };
////        function DeleteImage(elem) {
////            alert(elem);
////        }
//        //-------------------end-of-code----------------------//

//        function DeleteImage(fileName, OrderDetailID, fyletype) {
//            if (confirm("Are you sure want to delete!")) {
//                
//            }
//            else {
//                return false;
//            }

//            var url = "../../Webservices/iKandiService.asmx";
//            $.ajax({
//                type: "POST",
//                url: url + "/UpdateQcFile",
//                data: "{ filename:'" + fileName + "', orderdetailID:'" + OrderDetailID + "', filetype:'" + fyletype + "' }",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: OnSuccessCall,
//                error: OnErrorCall
//            });

//            function OnSuccessCall(response) {
//                alert("Delete Sucessfully");
//                location.reload();
//            }

//            function OnErrorCall(response) {
//                alert(response.status + " " + response.statusText);
//            }
//        }
    </script>
    <script type="text/javascript">

        $(function () {
            // alert('s');
            $(".th").datepicker({ dateFormat: 'dd M y (D)', maxDate: 0 });

//            ValidateForm();
            
        });
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
            ValidateForm();
        });
        function RemoveClass(id) {
           
          
            div = "#" + id;
           
           $(div).css({

               'border': '1px solid black',
//               'color': 'white',
//               'font-size': '32px',
//               'text-align': 'center',
               'display': 'inline-block'
           });

       }
//       function pageLoad() {
//           ValidateForm();
//       }
       function ValidateForm() {
//           debugger;
           
           var hdnFilePath1 = $("#rptFile1_ctl00_hdnFilePath1").val();
//           debugger;
           if (hdnFilePath1 == undefined) {
               hdnFilePath1 = "";
           }
           var txtFirstPcs = $("#txtFirstPcs").val();
           var ddlFirstPcs = $("#ddlFirstPcs").val();

           var hdnFilePath10 = $("#rtpFile10_ctl00_hdnFilePath10").val();
           var txtFirst10Pcs = $("#txtFirst10Pcs").val();
           var ddlFirst10Pcs = $("#ddlFirst10Pcs").val();

          
               if (hdnFilePath1 != "" || txtFirstPcs != "" || ddlFirstPcs != "-1") {
                   if (hdnFilePath1 == "") {
                       $("#FileUpldFirst").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });                     
                       alert("Upload at least one file!")
                       return false;
                   }
                   else {
                       $("#FileUpldFirst").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (txtFirstPcs == "") {
                       $("#txtFirstPcs").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });                    
                       alert("Select Date!");
                       return false;
                   }
                   else {
                       $("#txtFirstPcs").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (ddlFirstPcs == "-1") {
                       $("#ddlFirstPcs").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Pass/Fail!");
                       return false;

                   }
                   else {
                       $("#ddlFirstPcs").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
               }
               var hdnFilePath10 = $("#rtpFile10_ctl00_hdnFilePath10").val();
               if (hdnFilePath10 == undefined) {
                   hdnFilePath10 = "";
               }
               var txtFirst10Pcs = $("#txtFirst10Pcs").val();
               var ddlFirst10Pcs = $("#ddlFirst10Pcs").val();


               if (hdnFilePath10 != "" || txtFirst10Pcs != "" || ddlFirst10Pcs != "-1") {
                   if (hdnFilePath10 == "") {
                       $("#FileUpldFirst10").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Upload at least one file!")
                       return false;
                   }
                   else {
                       $("#FileUpldFirst10").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (txtFirst10Pcs == "") {
                       $("#txtFirst10Pcs").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Date!");
                       return false;
                   }
                   else {
                       $("#txtFirst10Pcs").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (ddlFirst10Pcs == "-1") {
                       $("#ddlFirst10Pcs").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Pass/Fail!");
                       return false;

                   }
                   else {
                       $("#ddlFirst10Pcs").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
               }

               var hdnFilePath50 = $("#rtpFile50_ctl00_hdnFilePath50").val();
               if (hdnFilePath50 == undefined) {
                   hdnFilePath50 = "";
               }
               var txtFirst50Pcs = $("#txtFirst50Pcs").val();
               var ddlFirst50Pcs = $("#ddlFirst50Pcs").val();


               if (hdnFilePath50 != "" || txtFirst50Pcs != "" || ddlFirst50Pcs != "-1") {
                   if (hdnFilePath50 == "") {
                       $("#FileUpldFirst50").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Upload at least one file!")
                       return false;
                   }
                   else {
                       $("#FileUpldFirst50").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (txtFirst50Pcs == "") {
                       $("#txtFirst50Pcs").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Date!");
                       return false;
                   }
                   else {
                       $("#txtFirst50Pcs").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (ddlFirst50Pcs == "-1") {
                       $("#ddlFirst50Pcs").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Pass/Fail!");
                       return false;

                   }
                   else {
                       $("#ddlFirst50Pcs").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
               }

               var hdnFilePathInline = $("#rtpFileInline_ctl00_hdnFilePathInline").val();
               if (hdnFilePathInline == undefined) {
                   hdnFilePathInline = "";
               }
               var txtcqddateInline = $("#txtcqddateInline").val();
               var ddlpassfailinline = $("#ddlpassfailinline").val();
               if (hdnFilePathInline != "" || txtcqddateInline != "" || ddlpassfailinline != "-1") {
                   if (hdnFilePathInline == "") {
                       $("#FileUpldInline").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Upload at least one file!")
                       return false;
                   }
                   else {
                       $("#FileUpldInline").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (txtcqddateInline == "") {
                       $("#txtcqddateInline").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Date!");
                       return false;
                   }
                   else {
                       $("#txtcqddateInline").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (ddlpassfailinline == "-1") {
                       $("#ddlpassfailinline").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Pass/Fail!");
                       return false;

                   }
                   else {
                       $("#ddlpassfailinline").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
               }

               var hdnFilePathMidline = $("#rtpFileMidline_ctl00_hdnFilePathMidline").val();
               if (hdnFilePathMidline == undefined) {
                   hdnFilePathMidline = "";
               }
               var txtMidline = $("#txtMidline").val();
               var ddlpassfailmidline = $("#ddlpassfailmidline").val();
               if (hdnFilePathMidline != "" || txtMidline != "" || ddlpassfailmidline != "-1") {
                   if (hdnFilePathMidline == "") {
                       $("#FileUpldMidline").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Upload at least one file!")
                       return false;
                   }
                   else {
                       $("#FileUpldMidline").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (txtMidline == "") {
                       $("#txtMidline").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Date!");
                       return false;
                   }
                   else {
                       $("#txtMidline").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (ddlpassfailmidline == "-1") {
                       $("#ddlpassfailmidline").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Pass/Fail!");
                       return false;

                   }
                   else {
                       $("#ddlpassfailmidline").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
               }
               var hdnFilePathFinal = $("#rtpFileFinal_ctl00_hdnFilePathFinal").val();
               if (hdnFilePathFinal == undefined) {
                   hdnFilePathFinal = "";
               }
               var txtcqddatefinal = $("#txtcqddatefinal").val();
               var ddlpassfailfinal = $("#ddlpassfailfinal").val();
               if (hdnFilePathFinal != "" || txtcqddatefinal != "" || ddlpassfailfinal != "-1") {
                   if (hdnFilePathFinal == "") {
                       $("#FileUpldFinal").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Upload at least one file!")
                       return false;
                   }
                   else {
                       $("#FileUpldFinal").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (txtcqddatefinal == "") {
                       $("#txtcqddatefinal").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Date!");
                       return false;
                   }
                   else {
                       $("#txtcqddatefinal").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
                   if (ddlpassfailfinal == "-1") {
                       $("#ddlpassfailfinal").css({
                           'border': '1px solid Red',
                           'display': 'inline-block'
                       });
                       alert("Select Pass/Fail!");
                       return false;

                   }
                   else {
                       $("#ddlpassfailfinal").css({
                           'border': '1px solid black',
                           'display': 'inline-block'
                       });
                   }
               }              
       }
       

</script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <br />
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
  
   
    <table style="width: 100%;position: relative;top:-12px; margin: 0px auto;" cellpadding="0" cellspacing="0" class="CommoAdmin_Table"
        align="center">
        <tr>
            <th colspan="4" style="background: #39589c;color:#fff">
              QA Report/Upload File
            </th>
        </tr>
        <tr>
            <td style="text-align: left; width: 130px">
                <span style="color: Gray">First Pcs. </span>
            </td>           
            <td style="text-align: left; padding: 0px 2px; width: 250px">
                <asp:FileUpload ID="FileUpldFirst" Width="100px" runat="server" />              
                <asp:HiddenField ID="hdnFileFirst" runat="server" />&nbsp;&nbsp;
                <asp:Button ID="btnUploadFirst"   runat="server" Text="Upload" 
                    CssClass="upload da_submit_button QcUPlo_submit_button" onclick="btnUploadFirst_Click" />
            </td>
            <td style="width: 500px">
               <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server"><ContentTemplate>
                <asp:Repeater ID="rptFile1" OnItemDataBound="rptFile1_ItemDataBound" runat="server">
                    <ItemTemplate>

                     <div class="img-fll" id="hideImg" runat="server">
                            <asp:HyperLink ID="imgfile1" Target="_blank" ToolTip='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                            </asp:HyperLink>
                                         
                            <asp:ImageButton ID="imgDelete1" runat="server" ImageUrl="../../images/del-butt.png"
                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgDelete1_Click" />
                            <asp:HiddenField ID="hdnFilePath1" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                         </div>                      
                       
                    </ItemTemplate>
                </asp:Repeater>
                 </ContentTemplate>
    </asp:UpdatePanel>
            </td>
            <td style="width:220px;padding: 1px 2px;">
          
              <asp:TextBox ID="txtFirstPcs" onchange="RemoveClass(this.id)" CssClass="th"  Width="100px" style="float:left; border:1px solid black;text-transform: lowercase;" runat="server"></asp:TextBox> 
           <asp:DropDownList ID="ddlFirstPcs" onchange="RemoveClass(this.id)"  Width="80px" style="float:left" runat="server">
            <asp:ListItem Text="Selct" Value="-1">Select</asp:ListItem>
             <asp:ListItem Text="Pass" Value="1">Pass</asp:ListItem>
             <asp:ListItem Text="Fail" Value="2">Fail</asp:ListItem>
           </asp:DropDownList>
           
            </td>
        </tr>
        <%--First 10--%>
        <tr>
            <td style="text-align: left;">
                <span style="color: Gray">First 10 Pcs. </span>
            </td>
            
            <td style="text-align: left; padding: 0px 2px;">
                <asp:FileUpload ID="FileUpldFirst10" Width="100px" runat="server" />              
                <asp:HiddenField ID="hdnFileFirst10" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="btnUpload10"   runat="server" Text="Upload" 
                    CssClass="upload da_submit_button QcUPlo_submit_button" onclick="btnUpload10_Click" />
            </td>
            <td>             
                 
                <asp:Repeater ID="rtpFile10" OnItemDataBound="rtpFile10_ItemDataBound" runat="server">
                    <ItemTemplate>                     
                       <div class="img-fll" id="hideImg" runat="server">
                            <asp:HyperLink ID="imgfile10" Target="_blank" ToolTip='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                            </asp:HyperLink>
                                         
                            <asp:ImageButton ID="imgDelete10" runat="server" ImageUrl="../../images/del-butt.png"
                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgDelete10_Click" />
                            <asp:HiddenField ID="hdnFilePath10" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                         </div>   
                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td style="padding: 1px 2px;">
             <asp:TextBox ID="txtFirst10Pcs" onchange="RemoveClass(this.id)" CssClass="th"  Width="100px" style="float:left; border:1px solid black;text-transform: lowercase;" runat="server"></asp:TextBox> 
           <asp:DropDownList ID="ddlFirst10Pcs" onchange="RemoveClass(this.id)" Width="80px" style="float:left" runat="server">
            <asp:ListItem Text="Selct" Value="-1">Select</asp:ListItem>
             <asp:ListItem Text="Pass" Value="1">Pass</asp:ListItem>
             <asp:ListItem Text="Fail" Value="2">Fail</asp:ListItem>
           </asp:DropDownList>
            </td>
        </tr>
         <%--First 50--%>
         <tr>
            <td style="text-align: left;">
                <span style="color: Gray">First 50 Pcs. </span>
            </td>
            
             <td style="text-align: left; padding: 0px 2px;">
                <asp:FileUpload ID="FileUpldFirst50" Width="100px"  runat="server" />              
                <asp:HiddenField ID="hdnFileFirst50" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="btnUpload50"   runat="server" Text="Upload" 
                    CssClass="upload da_submit_button QcUPlo_submit_button" onclick="btnUpload50_Click" />
            </td>
            <td>             
                 
                <asp:Repeater ID="rtpFile50" OnItemDataBound="rtpFile50_ItemDataBound" runat="server">
                    <ItemTemplate>                     
                    <div class="img-fll" id="hideImg" runat="server">
                            <asp:HyperLink ID="imgfile50" Target="_blank" ToolTip='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                            </asp:HyperLink>
                                         
                            <asp:ImageButton ID="imgDelete50" runat="server" ImageUrl="../../images/del-butt.png"
                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgDelete50_Click" />
                            <asp:HiddenField ID="hdnFilePath50" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                         </div>   
                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td style="padding: 1px 2px;">
            <asp:TextBox ID="txtFirst50Pcs" onchange="RemoveClass(this.id)" CssClass="th"  Width="100px" style="float:left; border:1px solid black;text-transform: lowercase;" runat="server"></asp:TextBox> 
           <asp:DropDownList ID="ddlFirst50Pcs" onchange="RemoveClass(this.id)" Width="80px" style="float:left" runat="server">
            <asp:ListItem Text="Selct" Value="-1">Select</asp:ListItem>
             <asp:ListItem Text="Pass" Value="1">Pass</asp:ListItem>
             <asp:ListItem Text="Fail" Value="2">Fail</asp:ListItem>
           </asp:DropDownList>
            </td>
        </tr>

         <%--Buying house Inline--%>
        <tr>
            <td style="text-align: left;">
                <span style="color: Gray">Buying house Inline</span>
            </td>
            
             <td style="text-align: left; padding: 0px 2px;">
                <asp:FileUpload ID="FileUpldInline" Width="100px" runat="server" />              
                <asp:HiddenField ID="hdnFileInline" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="btnUploadInline"   runat="server" Text="Upload" 
                    CssClass="upload da_submit_button QcUPlo_submit_button" onclick="btnUploadInline_Click" />
            </td>
            <td>             
                 
                <asp:Repeater ID="rtpFileInline" OnItemDataBound="rtpFileInline_ItemDataBound" runat="server">
                    <ItemTemplate>  
                     <div class="img-fll" id="hideImg" runat="server">
                            <asp:HyperLink ID="imgfileInline" Target="_blank" ToolTip='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                            </asp:HyperLink>
                                         
                            <asp:ImageButton ID="imgDeleteInline" runat="server" ImageUrl="../../images/del-butt.png"
                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgDeleteInline_Click" />
                            <asp:HiddenField ID="hdnFilePathInline" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                         </div>                    

                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td style="padding: 1px 2px;">
             <asp:TextBox ID="txtcqddateInline" onchange="RemoveClass(this.id)" CssClass="th" Width="100px" style="float:left; border:1px solid black;text-transform: lowercase;" runat="server"></asp:TextBox> 
           <asp:DropDownList ID="ddlpassfailinline" onchange="RemoveClass(this.id)" Width="80px" style="float:left" runat="server">
            <asp:ListItem Text="Selct" Value="-1">Select</asp:ListItem>
             <asp:ListItem Text="Pass" Value="1">Pass</asp:ListItem>
             <asp:ListItem Text="Fail" Value="2">Fail</asp:ListItem>
           </asp:DropDownList>
            </td>
        </tr>

         <%--Buying house Midline--%>
        <tr>
            <td style="text-align: left;">
                <span style="color: Gray">Buying house Midline</span>
            </td>
            
             <td style="text-align: left; padding: 0px 2px;">
                <asp:FileUpload ID="FileUpldMidline" Width="100px" runat="server" />              
                <asp:HiddenField ID="hdnFileMidline" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="btnUploadMidline"   runat="server" Text="Upload" 
                    CssClass="upload da_submit_button QcUPlo_submit_button" onclick="btnUploadMidline_Click" />
            </td>
            <td>             
                 
                <asp:Repeater ID="rtpFileMidline" OnItemDataBound="rtpFileMidline_ItemDataBound" runat="server">
                    <ItemTemplate>                     
                        <div class="img-fll" id="hideImg" runat="server">
                            <asp:HyperLink ID="imgfileMidline" Target="_blank" ToolTip='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                            </asp:HyperLink>
                                         
                            <asp:ImageButton ID="imgDeleteMidline" runat="server" ImageUrl="../../images/del-butt.png"
                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgDeleteMidline_Click" />
                            <asp:HiddenField ID="hdnFilePathMidline" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                         </div>   
                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td style="padding: 1px 2px;">
           <asp:TextBox ID="txtMidline" onchange="RemoveClass(this.id)" CssClass="th" Width="100px" onkeypress="return false;"  style="float:left; border:1px solid black;text-transform: lowercase;" runat="server"></asp:TextBox> 
           <asp:DropDownList ID="ddlpassfailmidline" onchange="RemoveClass(this.id)" Width="80px" style="float:left" runat="server">
           <asp:ListItem Text="Selct" Value="-1">Select</asp:ListItem>
            <asp:ListItem Text="Pass" Value="1">Pass</asp:ListItem>
             <asp:ListItem Text="Fail" Value="2">Fail</asp:ListItem>
           </asp:DropDownList>
            </td>
        </tr>

          <%--Buying house Final--%>
        <tr>
            <td style="text-align: left;">
                <span style="color: Gray">Buying house Final</span>
            </td>
            
             <td style="text-align: left; padding: 0px 2px; width: 25%">
                <asp:FileUpload ID="FileUpldFinal" Width="100px" runat="server" />              
                <asp:HiddenField ID="hdnFileFinal" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="btnUploadFinal"   runat="server" Text="Upload" 
                    CssClass="upload da_submit_button QcUPlo_submit_button" onclick="btnUploadFinal_Click" />
            </td>
            <td>             
                 
                <asp:Repeater ID="rtpFileFinal" OnItemDataBound="rtpFileFinal_ItemDataBound" runat="server">
                    <ItemTemplate>                     
                        <div class="img-fll" id="hideImg" runat="server">
                            <asp:HyperLink ID="imgfileFinal" Target="_blank" ToolTip='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                            </asp:HyperLink>
                                         
                            <asp:ImageButton ID="imgDeleteFinal" runat="server" ImageUrl="../../images/del-butt.png"
                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgDeleteFinal_Click" />
                            <asp:HiddenField ID="hdnFilePathFinal" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                         </div>   
                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td style="padding: 1px 2px;">
              <asp:TextBox ID="txtcqddatefinal" onchange="RemoveClass(this.id)" CssClass="th"  Width="100px" style="float:left; border:1px solid black;text-transform: lowercase;" runat="server"></asp:TextBox> 
           <asp:DropDownList ID="ddlpassfailfinal" onchange="RemoveClass(this.id)" Width="80px" style="float:left" runat="server">
            <asp:ListItem Text="Selct" Value="-1">Select</asp:ListItem>
             <asp:ListItem Text="Pass" Value="1">Pass</asp:ListItem>
             <asp:ListItem Text="Fail" Value="2">Fail</asp:ListItem>
           </asp:DropDownList>
            </td>
        </tr>
    </table>
 
    <div style="margin: 5px auto; text-align: center; width: 95%;">
        <asp:Button ID="btnSubmit"  OnClientClick="return ValidateForm();" runat="server" OnClick="btnSubmit_Click" CssClass="submit"
            Text="Submit" />
        <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
            Width="65px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
    </div>
    
    </form>
</body>
</html>
