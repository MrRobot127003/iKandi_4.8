<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechPackUpload.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.TechPackUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-family: "Lucida Sans Unicode";
            font-size: 12px;
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
            height:50px;
            width:50px;
        }
     .img-fll
     {
         float:left;
         padding:10px !important;
         width:auto !important;
         background:none !important;
         position:relative;
     }
     #UpdatePanel2
     {
         background:none !important;
     }
     .item_list TH 
     {
         background-color:  #39589c;
         color: #fff;
    font-size: 14px;
    font-weight: bold;
    padding: 5px 0;
     }
     .pdf img
     {
         height:40px;
         }
      input[type="file"]
      {
          font-size: 11px;
       }
       .submit
       {
           cursor:pointer;
         }
    </style>
 
  
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>  
    
    <script type="text/javascript" language="javascript">
        //-------------------edit by prabhaker------------------//

        $(document).ready(function () {
//            $(".imgupload").each(function () {
//                debugger;
//                var filepath = $(this).siblings('input[type=hidden]').val();
//                var fullfilePath = "../../uploads/Quality/" + filepath;
//                var arr = filepath.split('.');
//                if (arr[1] == "pdf") {
//                    $(this).find("img").attr("src", "../../images/pdf.png");
//                    $(this).removeClass("preview imgupload").addClass("pdf");
//                }
//            });
            ShowImagePreview();            
        });
        // Configuration of the x and y offsets
        function ShowImagePreview() {
            // xOffset = 50;
            //yOffset = -350;
            $("a.preview").hover(function (e) {
                //this.t = this.title;
                this.t = ""
                this.title = "";
               // alert(this.t);
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:180px !important; width:160px !important;'/>" + c + "</p>");
                $("#preview")
                .css("top", "-10px").css("right", "0px")
                // .css("top", (e.pageY - xOffset) + "px")
                //.css("left", (e.pageX + yOffset) + "px")
                 .fadeIn("slow");
            },

            function () {
                this.title = this.t;
                $("#preview").remove();
            });
            $("a.preview").mousemove(function (e) {
                $("#preview").css("top", "-10px").css("right", "0px");
                //.css("top", (e.pageY - xOffset) + "px")
                //.css("left", (e.pageX + yOffset) + "px");
            });
        };

        //-------------------end-of-code----------------------//
    </script>

    <script type="text/javascript">

        function UploadFile_IE(TestFileName) {
            //alert(TestFileName);
           //debugger;
            FileName = TestFileName;
            RptIndex = 1;
            document.getElementById('Fldresolution').value = TestFileName;
            $(".btnback").click();
        }


        $(document).ready(function () {
           // debugger;
            if ($('input[type=hidden]').val() == " ") {
               // alert($('input[type=hidden]').val());
                $(this).closest('div').hide();
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
  

  <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
  <input id="hdnFldresolutionTestreport" type="hidden" runat="server" class="hdnFldresolutionTestreport"  />
                   
    <table width="100%" cellpadding="0" cellspacing="0" align="center">
     <tr>
     <td>
     
        
        <table width="100%" cellpadding="0px" cellspacing="0" class="mid item_list1" align="center">
         <tr>
         <th colspan="2" style="color:#fff !important;background-color:  #39589c !important;">
         Upload File
         </th>
         </tr>
            <tr>
                <td width="29%">
                    Browse File:
                </td>
                <td style="padding:2px 0px;">
                   <asp:HiddenField ID="hdnStylenotestReportPath" runat="server" Value='<%# Eval("StyleTestReports")%>'  />
                    <asp:FileUpload ID="Fldresolution" runat="server" Width="200px" />
                    <asp:HiddenField ID="hdnWholeFile" runat="server" />
                    <asp:HiddenField ID="hdnindex" runat="server" />
                    <asp:HiddenField ID="hdnFlagIE" runat="server" />
                    <asp:HiddenField ID="hdnFlagTestReport" runat="server" />
                    <asp:Button ID="a" style="display: none" CssClass="btnback" runat="server" onclick="a_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnUpload1"   runat="server" Text="Upload" CssClass="upload da_submit_button" OnClick="btnUpload1_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border:0px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater ID="rptFile" runat="server" OnItemDataBound="outerFunction">
                                <HeaderTemplate>
                                    <table border="1px black solid" class="item_list" width="100%" style="margin-top:5px;">
                                        <tr>
                                            <th width="450px" style="text-transform:capitalize;color:#fff !important;background-color:  #39589c !important;">
                                              Uploaded File
                                         
                                        </tr>
                                        </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                   <div class="img-fll" id="hideImg" runat="server">
                                         <asp:HyperLink ID="imgfile" Target="_blank" ToolTip='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Style/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Style/" + (Eval("FilePath"))) %>'>
                                         </asp:HyperLink>
                                         
                                         <asp:ImageButton ID="imgRow" runat="server" ImageUrl="../../images/del-butt.png"
                                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgRow_Click" />
                                         <asp:HiddenField ID="hdnFilePath" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                                       </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            
        </table>
    
     </td>
     </tr>
     <%--============================================--%>
       
          
          
     
      <tr>
        <td align="center" style="padding:10px 0px;">        
          <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" CssClass="submit" Text="Submit" />
          <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"  OnClientClick="javascript:self.parent.Shadowbox.close();" />
          
        </td>
      </tr>
      <tr><td>&nbsp;</td></tr>
      
    </table>
  
    </form>
</body>
</html>
