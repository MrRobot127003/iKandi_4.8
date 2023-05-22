<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeekCapMultipleFileUpload.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.PeekCapMultipleFileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Upload File</title>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-family: "Lucida Sans Unicode";
            font-size: 12px;
        }
        .style_number_box_background
        {
            opacity: 0.9;
            background: grey;
        }
        .style_number_box
        {
            padding: 0px !important;
            width: 550px !important;
            border: none;
            top:0px;
            left:0px;
        }
        .style_number_box table
        {
            
            padding-bottom: 5px;
        }
        .style_number_box div
        {
            background-color: #39589c;
            color: #fff;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-transform: capitalize;
            width: 100%;
            padding: 5px 0px;
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
         background-color: #39589c;
         color: #fff;
    font-size: 14px;
    font-weight: bold;
    padding: 5px 0;
     }
     .upload
     {
         background-image: url(../../App_Themes/ikandi/images/upload.jpg);
      background-repeat: no-repeat;
      width: 105px;
      height: 28px;
     }
        .upload:hover{
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/upload.jpg);
        background-repeat: no-repeat;
        width: 105px;
        background-position: 0px -28px;
    }
    #Fldresolution
    {
     
        	width:60%;
    }
    </style>
</head>
<body>
  
    
    <script type="text/javascript" language="javascript">
        //-------------------edit by prabhaker------------------//

        $(document).ready(function () {
            ShowImagePreview();
        });
        // Configuration of the x and y offsets
        function ShowImagePreview() {
            // xOffset = 50;
            //yOffset = -350;
            $("a.preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:180px !important; width:160px !important;'/>" + c + "</p>");
                $("#preview")
                .css("top", "-10px")
.css("right", "0px")
                // .css("top", (e.pageY - xOffset) + "px")
                //.css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
            },

function () {
    this.title = this.t;
    $("#preview").remove();
});

            $("a.preview").mousemove(function (e) {
                $("#preview")
                .css("top", "-10px")
.css("right", "0px");
                //.css("top", (e.pageY - xOffset) + "px")
                //.css("left", (e.pageX + yOffset) + "px");
            });
        };

        //-------------------end-of-code----------------------//
    </script>
   
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
       
        function CallBackParentPage() {

            window.parent.Shadowbox.close();
            return true;
        }
        function Deletefile(elem) {

            alert(elem.id);
            return false;
        }
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="style_number_box" id="divUpload" style="display: block; z-index:-1;">
        <div>
            Upload File
        </div>
        <table width="100%" cellpadding="6px" class="mid">
            <tr>
                <td class="b" width="20%">
                    Browse File:
                </td>
                <td>
                    <asp:FileUpload ID="Fldresolution" runat="server" />
                    <asp:HiddenField ID="hdnWholeFile" runat="server" />
                    <asp:HiddenField ID="hdnindex" runat="server" />
                    &nbsp;
                    <asp:Button ID="btnUpload" runat="server" Text="" CssClass="upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater ID="rptFile" runat="server">
                                <HeaderTemplate>
                                    <table border="1px black solid" class="item_list" width="100%">
                                        <tr>
                                            <th width="450px">
                                                Documents
                                            </th>
                                         
                                        </tr>
                                        </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                   <div class="img-fll">
                                         <asp:HyperLink ID="imgfile" Target="_blank"  runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                                         </asp:HyperLink>
                                         <asp:ImageButton  ID="imgRow" runat="server" ImageUrl="../../images/del-butt.png"
                                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgRow_Click" />
                                         <asp:HiddenField ID="hdnFilePath" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                                       </div>
                                </ItemTemplate>
                              
                            </asp:Repeater>
                        </ContentTemplate>
                      
                       
                       
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="btnSvaeFile" runat="server" Text="" CssClass="submit" OnClick="btnSvaeFile_Click" />
                    <input type="button" class="cancel" onclick="javascript:window.parent.Shadowbox.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
