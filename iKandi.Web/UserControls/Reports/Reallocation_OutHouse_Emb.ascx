<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reallocation_OutHouse_Emb.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.Reallocation_OutHouse_Emb" %>
<style type="text/css">
    body
    {
        font-family: Verdana;
        font-size: 12px;
    }
    .EmbOutHouse
    {
        border-collapse: collapse;
    }
    .EmbOutHouse th
    {
        background: #b0c4de;
        font-size: 11px;
        font-weight: bold;
        padding: 5px 2px;
        font-family: Arial;
    }
    .EmbOutHouse td
    {
        text-align: center;
        text-transform: capitalize;
        font-family: Arial;
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
    .align-right-text
    {
        text-align: right !important;
        padding-right: 10px;
    }
    .pad-zero
    {
        padding: 0px !important;
    }
    
    
   .floatingHeader
    {
        position: fixed;
        top: 0px;
        visibility: hidden;
        margin: auto;
        z-index: 100;
        backface-visibility: hidden;
        width: 1180px !important;
     
    }
    
    .persist-header
    {
        table-layout: fixed;
    }
    .persist-area
    {
        position:relative;
     }
      
</style>
<script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    //-------------------edit by prabhaker------------------//

    $(document).ready(function () {
        ShowImagePreview();
    });
    function ShowImagePreview() {

        $("a.preview").hover(function (e) {
            // debugger;
            var imgsrc = $(this).children("img").attr('src');
            this.title = imgsrc;
            this.t = this.title;
            this.title = "";
            // var c = (this.t != "") ? "<br/>" + this.t : "";
            $("body").append("<p id='preview'><img src='" + this.t + "' alt='Image preview' style='height:200px !important; width:200px !important;'/>&nbsp;</p>");
            $("#preview")
            .css("top", (e.pageY) + "px")
            .css("left", (e.pageX) + "px")
            .fadeIn("slow");
        },

        function () {
            this.title = this.t;
            $("#preview").remove();
        });

                $("a.preview").mousemove(function (e) {
                    $("#preview")
        .css("top", (e.pageY - xOffset) + "px")
        .css("left", (e.pageX + yOffset) + "px");
                });
            };

            //-------------------end-of-code----------------------//

            // add code by bharat
            function UpdateTableHeaders() {
                $(".persist-area").each(function () {
                    var el = $(this),
               offset = el.offset(),
               scrollTop = $(window).scrollTop(),
               floatingHeader = $(".floatingHeader", this)
                    if ((scrollTop > offset.top) && (scrollTop < offset.top + el.height())) {
                        floatingHeader.css({
                            "visibility": "visible"

                        });
                    } else {
                        floatingHeader.css({
                            "visibility": "hidden"
                        });
                    };
                });
            }

            $(function () {
                var clonedHeaderRow;
                $(".persist-area").each(function () {
                    clonedHeaderRow = $(".persist-header", this);
                    clonedHeaderRow
             .before(clonedHeaderRow.clone())
             .css("width", clonedHeaderRow.width())
             .addClass("floatingHeader");
                });
                $(window)
        .scroll(UpdateTableHeaders)
        .trigger("scroll");
            });

</script>
<asp:GridView runat="server" ID="frmReallocation_OutHouse_Emb" CssClass="EmbOutHouse persist-area"
    AutoGenerateColumns="false" HorizontalAlign="Center" OnRowDataBound="frmReallocation_OutHouse_Emb_RowDataBound"
    Width="1180px" ShowFooter="true">
    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                Image
            </HeaderTemplate>
            <HeaderStyle Width="60px" />
            <ItemTemplate>
                <a href="#" title="" class="preview">
                    <img id="imgStyle" runat="server" style="height: 60px !important; width: 60px !important;" />
                </a>
                <asp:HiddenField runat="server" ID="hdnImgStyle" Value='<%#Eval("StyleImage")%>' />
            </ItemTemplate>
            <FooterTemplate>
                Total
            </FooterTemplate>
            <FooterStyle BackColor="#b0c4de" Font-Bold="true" HorizontalAlign="Right" CssClass="align-right-text" />
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Unit
            </HeaderTemplate>
            <HeaderStyle Width="99px" />
            <ItemTemplate>
                <asp:Label ID="LblUnit" runat="server" Text='<% # Eval("Name") %>' Font-Bold="true"></asp:Label>
                <asp:HiddenField ID="hdnBgColor" runat="server" Value='<% # Eval("BgColorRed") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Type
            </HeaderTemplate>
            <HeaderStyle Width="100px" />
            <ItemTemplate>
                <asp:Label ID="LblType" runat="server" Text='<% # Eval("Type") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Fabricator
            </HeaderTemplate>
            <HeaderStyle Width="116px" />
            <ItemTemplate>
                <asp:Label ID="LblFabricator" runat="server" Text='<% # Eval("Fabricator") %>' Font-Bold="true"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <span style="color: #0070c0">Serial No.</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            Style No.
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle Width="120px" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 30px; vertical-align: middle;">
                            <asp:Label ID="LblSerailNo" runat="server" ForeColor="#0070c0" Text='<% # Eval("SerialNumber") %>'
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 29px; vertical-align: middle;">
                            <asp:Label ID="LblStyleNo" runat="server" Text='<% # Eval("StyleNumber") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <%-- <asp:TemplateField>
            <HeaderTemplate>
           
            </HeaderTemplate>
            <HeaderStyle Width="120px" />
       <ItemTemplate>
      
       </ItemTemplate>
       </asp:TemplateField>--%>
        <asp:TemplateField>
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            Contract No.
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            PO Number
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle Width="120px" CssClass="pad-zero" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 30px; vertical-align: middle;">
                            <asp:Label ID="LineContractNumber" runat="server" Text='<% # Eval("ContractNumber") %>'
                                ForeColor="Gray" Font-Size="10px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 29px; vertical-align: middle;">
                            <asp:Label ID="LineItemNumber" runat="server" Text='<% # Eval("LineItemNumber") %>'
                                ForeColor="Gray" Font-Size="10px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            Fabric
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            Color
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle Width="120px" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 30px; vertical-align: middle;">
                            <asp:Label ID="lblFabric1" runat="server" Text='<% # Eval("Fabric1") %>' ForeColor="Gray"
                                Font-Size="10px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 29px; vertical-align: middle;">
                            <asp:Label ID="LblColor" runat="server" Text='<% # Eval("Fabric1Details") %>' ForeColor="Gray"
                                Font-Size="10px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Order Qty
            </HeaderTemplate>
            <HeaderStyle Width="70px" />
            <ItemTemplate>
                <asp:Label ID="lblPOQty" runat="server" Text='<%# string.Format("{0:#,#}", Eval("POQuantity").ToString() == "0" ? "" : Eval("POQuantity")) %>'
                    Font-Bold="true"></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFoo_POQty" runat="server" Text="" Font-Bold="true"></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            VA Recvd Tdy
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            VA Recvd Total
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle Width="86px" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 30px; vertical-align: middle;">
                            <asp:Label ID="LblrcvdVaTdyQty" runat="server" Text='<%# string.Format("{0:#,#}", Eval("PerdayValueAddedQty").ToString() == "0" ? "" : Eval("PerdayValueAddedQty")) %>'
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 29px; vertical-align: middle;">
                            <asp:Label ID="lblValueAddedQty" runat="server" Text='<%# string.Format("{0:#,#}", Eval("ValueAddedQty").ToString() == "0" ? "" : Eval("ValueAddedQty")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <asp:Label ID="lblFoo_rcvdVaTdyQty" runat="server" Text="" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <asp:Label ID="lblFoo_ValueAddedQty" runat="server" Text="" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <span style="color: #0070c0">VA St. Date</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <span style="color: #0070c0">VA End Date</span>
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle Width="99px" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <asp:Label ID="LblValueAdditionSt" runat="server" ForeColor="#0070c0" Text='<% # Eval("ValueAdditionStartDate" ,"{0:dd MMM (ddd)}") %>'
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <asp:Label ID="LblValueAdditionEnd" runat="server" ForeColor="#0070c0" Text='<% # Eval("ValueAdditionEndDate" ,"{0:dd MMM (ddd)}") %>'
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                Pcs/day
            </HeaderTemplate>
            <HeaderStyle Width="68px" />
            <ItemTemplate>
                <asp:Label ID="LblPcsday" runat="server" Text='<%# string.Format("{0:#,#}", Eval("PcsPerday").ToString() == "0" ? "" : Eval("PcsPerday")) %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFoo_Pcsday" runat="server" Text="" Font-Bold="true"></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            Ex. Date
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            Committed End Date
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <HeaderStyle Width="97px" />
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="1" width="100%" rules="all" frame="void">
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <asp:Label ID="lblExDate" runat="server" Text='<% # Eval("ExFactory","{0:dd MMM (ddd)}") %>'
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; vertical-align: middle;">
                            <asp:Label ID="lblCommitDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Committed_EndDate")) == Convert.ToDateTime("1/1/1900") ? "" : Convert.ToDateTime(Eval("Committed_EndDate")).ToString("dd MMM (ddd)") %>'
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
      <HeaderStyle CssClass="persist-header" />
</asp:GridView>
<div style="width: 1170px; margin: 0px auto;">
    <b>Note<sup style="color: red">*</sup>:-</b> If Out House Stitched End Date > (Ex
    Factory Date-3 Days) than Background would Be <span style="color: red">Red</span>
    else <span style="color: Green">Green.</span></div>
