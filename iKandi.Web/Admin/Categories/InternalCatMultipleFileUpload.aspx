<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalCatMultipleFileUpload.aspx.cs"
    Inherits="iKandi.Web.Admin.Categories.InternalCatMultipleFileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../js/jquery.jcarousel.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            ShowImagePreview();
        });

        function ShowImagePreview() {
            $("a.preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:180px !important; width:160px !important;'/>" + c + "</p>");
                $("#preview")
                .css("top", "-10px")
.css("right", "0px")
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
            });
        };

        function CallBackParentPage() {
            debugger;
            window.parent.Shadowbox.close();
            return true;
        }
        function Deletefile(elem) {

            alert(elem.id);
            return false;
        }

    </script>
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
            width: 100% !important;
            border: none;
            top: 0px;
            left: 0;
            height: 274px;
            overflow: auto;
        }
        .style_number_box table
        {
            padding-bottom: 5px;
            margin: 3px 0px;
        }
        .style_number_box div
        {
            background-color: #39589c;
            color: #fff;
            font-size: 15px;
            font-weight: 500;
            text-align: center;
            text-transform: capitalize;
            width: 100%;
            padding: 2px 0px;
            margin-bottom: 5px;
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
            padding: 5px 0px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        .preview IMG
        {
            height: 50px;
            width: 50px;
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
        .btnupload
        {
            width: 69px;
            height: 25px;
            line-height: 18px;
            background: #39589c;
            text-align: center;
            color: #fff;
            border: 1px solid #999;
            cursor: pointer;
            border-radius: 2px;
        }
        .btnupload:hover
        {
            color: yellow;
        }
        #Fldresolution
        {
            width: 60%;
        }
        .btncancel
        {
            line-height: 18px;
            background: #39589c;
            text-align: center;
            color: #fff;
            border: 1px solid #999;
            border-radius: 2px;
            cursor: pointer;
        }
        .btnsubmit
        {
            line-height: 18px;
            background: #13a747;
            text-align: center;
            color: #fff;
            border: 1px solid #999;
            border-radius: 2px;
            cursor: pointer;
        }
        .btnsubmit:hover
        {
            line-height: 18px;
            background: #13a747;
            text-align: center;
            color: yellow;
            border: 1px solid #999;
            border-radius: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="style_number_box" id="divUpload" style="display: block; z-index: -1;">
        <div>
            Upload File
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="mid">
            <tr>
                <td class="b" style="width: 20%; padding-left: 5px;">
                    Browse File:
                </td>
                <td>
                    <asp:FileUpload ID="Fldresolution" runat="server" />
                    <asp:HiddenField ID="hdnWholeFile" runat="server" />
                    <asp:HiddenField ID="hdnindex" runat="server" />
                    &nbsp;
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btnupload" OnClick="btnUpload_Click" />
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
                                            <th style="color: #fff !important; width: 100%; font-weight: 500; padding: 2px 0px;
                                                text-transform: capitalize;">
                                                Documents
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="img-fll">
                                        <asp:HyperLink ID="imgfile" Target="_blank" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("ImagePath"))) %>'
                                            Width="50px" CssClass="imgupload preview" NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("ImagePath"))) %>'>
                                        </asp:HyperLink>
                                        <asp:ImageButton ID="imgRow" runat="server" ImageUrl="../../images/del-butt.png"
                                            CausesValidation="false" ToolTip="Delete Pic" Style="position: absolute; margin-left: -10px;
                                            top: 0px; right: 0px;" OnClick="imgRow_Click" />
                                        <asp:HiddenField ID="hdnFilePath" Value='<%#DataBinder.Eval(Container.DataItem, "ImagePath")%>'
                                            runat="server" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="btnSvaeFile" runat="server" Text="Submit" CssClass="btnsubmit" OnClick="btnSvaeFile_Click" />
                    <input type="button" class="btncancel" value="Cancel" onclick="javascript:window.parent.Shadowbox.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
