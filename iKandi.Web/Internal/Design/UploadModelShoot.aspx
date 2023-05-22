<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadModelShoot.aspx.cs"
    Inherits="iKandi.Web.Internal.Design.UploadModelShoot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../js/jquery.jcarousel.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='../../js/jquery-1.4.4.min.js'></script>
    <script src="../../js/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="../../CommonJquery/Js/jquery.lightbox-0.5.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
    <%-- <script src="../../js/GarmentListJquery.js" type="text/javascript"></script>--%>
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
            border: 0px;
            background: #333;
            padding: 0px 0px;
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
            height: 21px;
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
        .top_heading
        {
            text-align: center;
            text-transform: capitalize;
            font-size: 16px;
            font-weight: 500;
            padding: 1px 0px;
            color: #fff;
            background: #39589c;
            width: 100%;
            padding-left: 5px !important;
        }
        input[type=text], textarea
        {
            border: 1px solid #cccccc;
            text-transform: unset;
            font-size: 11px;
            margin: 2px 0px;
            padding-left: 3px;
        }
        td
        {
            padding-left: 5px;
            padding: 2px 4px;
        }
        td:first-child
        {
            color: #696565;
            text-align: right;
        }
        .btn-Add
        {
            font-size: 10px;
            padding: 1px 5px;
            cursor: pointer;
            background: #39589c;
            color: #fff;
            border-radius: 3px;
        }
        .btn-Add:hover
        {
            color: yellow;
        }
        .DelBotton
        {
            margin-left: 0px;
            cursor: pointer;
            position: relative;
            top: 4px;
        }
        select
        {
            border:1px solid #cccc;
         }
        .absoluteposition
        {
            /* position: absolute;
            left: 56%;
            top: 0;*/
        }
        .Delimg
        {
            width: 13px;
            position: relative;
            top: -2px;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        var finalval = '';
        $(document).ready(function () {
            // debugger;
            // alert();
            ShowImagePreview();
            setupControls();
        });

        function ShowImagePreview() {
            $("a.preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:180px !important; width:160px !important;'/>" + c + "</p>");
                $("#preview")
                .css("top", "150px")
                .css("right", "200px")
                            .fadeIn("slow");
            },

                function () {
                    this.title = this.t;
                    $("#preview").remove();
                });

            $("a.preview").mousemove(function (e) {
                $("#preview")
                                .css("top", "150px")
                .css("right", "200px");
            });
        };

        function CallBackParentPage() {
            window.parent.Shadowbox.close();
            return true;
        }
        function Deletefile(elem) {
            //alert(elem.id);
            return false;
        }

        function setupControls() {
            debugger;
            //alert('setupControls');
            $('input.MarketingTag').autocomplete("/Webservices/iKandiService.asmx/SuggestMarketingTag", { dataType: "xml", datakey: "string", max: 100, "width": "169px" });

        }
        function CheckRagistertag(ele) {
            // debugger;
            var RegisterTags = ele.value;
            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/Get_Register_MarketingTag",
                data: "{ RegisterTags:'" + RegisterTags + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                if (response.d[0] == 0) {
                    $("#txtTags").val('');
                }

            }

            function OnErrorCall(response) {

                alert('gff');
            }
        }

        function AddTagVal() {
            debugger;

            var inputVal = $("#txtTags").val();
            var checkval = "";
            var FInalVal1 = "";
            var addVal = "<div id='idchec'>" + inputVal + "<span class='DelBotton' onclick='DelTagsFun(this)'> <img src='../../images/Del-new.png' class='Delimg'/></div>";
            $('#AddTagsVal').each(function () {
                checkval = $('#AddTagsVal').text().trim();

                FInalVal = checkval.split(" ");
                for (var i = 0; i < FInalVal.length; i++) {
                    if (FInalVal != "") {
                        if (inputVal == FInalVal[i]) {
                            alert("Found not match!");
                            return;
                        }
                    }
                }
                //                if (checkval != "") {
                if (checkval != inputVal) {
                    FInalVal = checkval.split(" ");
                    for (var i = 0; i < FInalVal.length; i++) {
                        FInalVal1 = FInalVal1 + FInalVal[i] + ',';
                    }
                    if (inputVal != "") {
                        $('#AddTagsVal').append(addVal);
                        FInalVal1 = FInalVal1 + inputVal + ',';
                        $("#txtTags").val('');
                    }
                }
                //                }
                //                if (checkval == "") {
                //                    FInalVal = checkval.split(" ");
                //                    for (var i = 0; i < FInalVal.length; i++) {
                //                        FInalVal1 = FInalVal1 + FInalVal[i] + ',';
                //                    }
                //                    if (inputVal != "") {
                //                        $('#AddTagsVal').append(addVal);
                //                        finalval = finalval + inputVal + ',';
                //                        $("#txtTags").val('');
                //                    }
                //                }
            });
            $('#hdnTags').val(FInalVal1);

        }
        function DelTagsFun(ele) {
            //alert();
            $(ele).parent('div').remove();
            AddTagVal();
        }
  
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnTags" runat="server" />
    <asp:HiddenField ID="hdntag2" runat="server" />
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; margin: 0 auto;padding-bottom: 10px;">
            <tr>
                <td colspan="2" class="top_heading" style="text-align: center; color: #fff">
                    Upload Model Shoot
                </td>
            </tr>
            <tr>
                <td>
                    Title
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" Width="97px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Type of Garment
                </td>
                <td>
                    <asp:DropDownList ID="ddlGarmentType" runat="server" Style='width: 102px;'>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Tags
                </td>
                <td style='position: relative;'>
                    <%--<asp:DropDownList ID="ddlTags" runat="server" Style='width: 102px;'>
                    </asp:DropDownList>--%>
                    <asp:TextBox ID="txtTags" runat="server" CssClass="MarketingTag" onblur="CheckRagistertag(this)"></asp:TextBox>
                    <span class="btn-Add" onclick="AddTagVal()">Add</span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <div id="AddTagsVal" runat="server" class="absoluteposition">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 135px">
                    Fabric Quality
                </td>
                <td>
                    <asp:Label ID="lblFabricQuality" runat="server"></asp:Label>
                    <%--<asp:TextBox ID="txtFabricQlity" runat="server"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td style="width: 135px">
                    Fabric Composition
                </td>
                <td>
                    <%--   <asp:DropDownList ID="ddlCompositon" runat="server" Style='width: 102px;'>
                    </asp:DropDownList>--%>
                    <asp:Label ID="lblFabricComposition" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Collection
                </td>
                <td>
                    <asp:DropDownList ID="ddlCollection" runat="server" Style='width: 102px;'>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    MOQ
                </td>
                <td>
                    <asp:DropDownList ID="ddlMOQ" runat="server" Style='width: 102px;'>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Price
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 115PX;">
                    Short Description
                </td>
                <td>
                    <asp:TextBox ID="txtShortDesc" Width="270px" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Long Description
                </td>
                <td>
                    <asp:TextBox ID="txtLongDesc" Width="270px" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    Upload File
                </td>
                <td>
                    <asp:FileUpload ID="Fldresolution" runat="server" />
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btnupload" OnClick="btnUpload_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="top_heading1" id="showUPFile" runat="server" visible="false">
                    Uploaded File
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater ID="rptFile" runat="server">
                                <ItemTemplate>
                                    <div class="img-fll">
                                        <asp:HyperLink ID="imgfile" Target="_blank" runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Style/" + (Eval("ImageURL"))) %>'
                                            Width="50px" CssClass="imgupload preview" NavigateUrl='<%# ResolveUrl("~/uploads/Style/" + (Eval("ImageURL"))) %>'>
                                        </asp:HyperLink>
                                        <asp:ImageButton ID="imgRow" runat="server" ImageUrl="../../images/del-butt.png"
                                            CausesValidation="false" ToolTip="Delete Pic" Style="position: absolute; margin-left: -10px;
                                            top: 0px; right: 0px;" OnClick="imgRow_Click" />
                                        <asp:HiddenField ID="hdnFilePath" Value='<%#DataBinder.Eval(Container.DataItem, "ImageURL")%>'
                                            runat="server" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Button ID="btnSvaeFile" runat="server" Text="Submit" CssClass="btnsubmit" OnClick="btnSvaeFile_Click" />
                    <input type="button" class="btncancel" value="Cancel" onclick="javascript:window.parent.Shadowbox.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
