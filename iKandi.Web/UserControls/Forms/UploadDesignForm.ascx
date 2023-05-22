<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadDesignForm.ascx.cs"
    Inherits="iKandi.Web.UploadDesignForm" %>
<asp:Panel runat="server" ID="pnlForm">
   

    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        var txtStyleNoClientID = '<%=txtStyleNo.ClientID %>';
        var hdnStyleIDClientID = '<%=hdnStyleID.ClientID %>';

        $(function () {
            $("#" + txtStyleNoClientID, "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100 });


            $("a[rel=lightbox]").lightBox({


//                imageLoading: '/app_themes/ikandi/images/lightbox-ico-loading.gif',

                imageBtnPrev: '/app_themes/ikandi/images/lightbox-btn-prev.gif',

                imageBtnNext: '/app_themes/ikandi/images/lightbox-btn-next.gif',

                imageBtnClose: '/app_themes/ikandi/images/lightbox-btn-close.gif',

                imageBlank: '/app_themes/ikandi/images/lightbox-blank.gif'

            });

        });


        function SearchStyleNumber() {
            var styleNumber = $.trim($("#" + txtStyleNoClientID, "#main_content").val());

            proxy.invoke("GetStyleByNumber_Courier", { StyleNumber: styleNumber },
        function (result) {
            var styleid;

            if (result != null)
                styleid = result.StyleID;

            if (styleid != null && parseInt(styleid) > 0)
                window.location = "/Internal/Design/UploadDesign.aspx?styleid=" + styleid;
            else
                jQuery.facebox('Style Number is invalid!');

        });
        }

        function deleteImg(srcElem, imageId) {
            proxy.invoke("DeleteStyleReferenceBlockById", { BlockId: imageId },
         function (result) {
             if (result) {
                 $(srcElem).parent().hide();
             }
             return true;
         },
         onPageError, false, true);
            return false;
        }

        function deleteStyleImg(srcElem, type) {
            proxy.invoke("UpdateUrl", { StyleId: $("#" + hdnStyleIDClientID, "#main_content").val(), Type: type },
         function (result) {
             if (result) {
                 $(srcElem).parent().hide();
             }
             return true;
         },
         onPageError, false, true);
            return false;
        }
    

    </script>
    <style type="text/css">
    .caption_headings {
    background:#39589c;
    border-radius:5px 5px 0px 0px;
    text-align:center;
   
}
.print-box
{

background:#fff;   
}
#lightbox-container-image-box
{
    border:5px solid #999;
    border-radius:5px;
    height:650px !important;
 }
 #lightbox-container-image img
 {
    width:100%;
     max-height:616px;
     
   }
 #lightbox-container-image-data-box
 {
     position: absolute;
    left: 17.4%;
    bottom: 6px;
  }
 #lightbox-container-image 
 {
     padding:0px !important
   }
   .inner_tbl_td
   {
       vertical-align: top;

    }
     
  /*  .AllReq
      {
       top:10px !important;   
       }
         .rightSideSearch
       {
          top:5px !important;     
       }
    @media screen and (max-width: 1366px) {
      .AllReq
      {
       top:26px !important;   
       }
       .rightSideSearch
       {
          top:24px !important;     
       }
    }*/
    </style>
   
    <div class="print-box">
        <div class="client_form">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td>

  <h2 style="background:#39589c; margin:0px; padding:3px 10px; font-weight:500; color:#fff;clear:both; text-transform:capitalize;border:1px solid gray;position:relative;">
       <div class="AllReq" style="left:0; position: absolute;top:10px;font-weight:500;"> <span class="da_required_field">(<span class="da_astrx_mand">*</span>Please fill all required fields) </span></div>
       Style Image Upload Form
      <div class="rightSideSearch" style="float:right; width:auto;position: absolute;top: 5px;right:10px">
      <span style="float:left; width:100px; font-size:12px;position:relative;top:4px;font-weight:500;font: normal 13px/16px Arial,Verdana,sans-serif;"> Search Style No. </span>
       <span  style="float:left; width:150px"><asp:TextBox runat="server" ID="txtStyleNo" Width="88%" CssClass="do-not-disable input_in"></asp:TextBox>
                    <asp:HiddenField runat="server" Value="-1" ID="hdnStyleID" /> </span> 
                
          <span  style="float:left; width:50px"> <asp:Button ID="btnSearchStyleNo" runat="server" Text="Search" class="do-not-disable go da_go_button" OnClientClick="SearchStyleNumber();return false;" /> </span>
      </div>

      <div style="clear:both"></div>
      </h2>
            </td>
       
      </tr>
  
  
  <tr>
    <td class="tbl_bordr">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
    <caption class="caption_headings">Style Info</caption>
      <tr>
        <td width="80%">
          
          <table width="100%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin:0px;">
            <tr class="td-sub_headings">
              <td width="14%" valign="bottom">Style Number </td>
              <td width="14%" valign="bottom">Buyer</td>
              <td width="14%" valign="bottom">&nbsp;</td>
              <td width="14%" valign="bottom">&nbsp;</td>
              <td width="14%" valign="bottom">&nbsp;</td>
              <td width="14%" valign="bottom">&nbsp;</td>
              <td width="14%" valign="bottom">&nbsp;</td>
              </tr>
            <tr>
              <td class="inner_tbl_td"><asp:Label runat="server" ID="lblStyle" CssClass="input_in"></asp:Label></td>
              <td class="inner_tbl_td"><asp:Label ID="lblBuyer" runat="server" CssClass="input_in"></asp:Label></td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            </table>
             </td>
        </tr>
    </table>
            
            
     <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper">
    <caption class="caption_headings">
    Upload Style Pics
    </caption>
      <tr>
        <td>
          
          <table width="98%" border="0" align="center" cellspacing="6" cellpadding="0" style="margin:0px;">
            <tr class="td-sub_headings">
              <td valign="bottom">Style Front </td>
              <td valign="bottom">Style Back</td>
              <td valign="bottom">Style Additional</td>
              <td valign="bottom">Style Embellishment</td>
              <td valign="bottom">Style Mocks</td>
              <td valign="bottom">Style CAD</td>
              <td valign="bottom">Style Machine Embellishment</td>
              </tr>
            <tr>
              <td class="inner_tbl_td"><asp:FileUpload ID="uploadImage1" runat="server" Width="145"  />
              <div style="vertical-align: middle;">
                                <asp:HyperLink ID="hypSample1" runat="server" rel="lightbox">
                                    <asp:Image ID="Img1" CssClass="lightbox" runat="server" Width="20px" Height="20px"
                                        border="0 " ImageUrl="~/App_Themes/ikandi/images/icon.jpg" align="left" Visible="false" /></asp:HyperLink>
                                &nbsp;
                                <input runat="server" type="button" id="Button1" class="cross" onclick='return deleteStyleImg(this,1)'
                                    visible="false" />
                            </div>
              </td>
              <td class="inner_tbl_td"><asp:FileUpload ID="uploadImage2" runat="server" Width="145"  />
              <div style="vertical-align: middle;">
                                <asp:HyperLink ID="hypSample2" Visible="false" runat="server" rel="lightbox">
                                    <asp:Image ID="Img2" CssClass="lightbox" runat="server" Width="20px" Height="20px"
                                        border="0 " align="left" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" Visible="false" /></asp:HyperLink>
                                &nbsp;
                                <input runat="server" type="button" id="Button2" class="cross" onclick='return deleteStyleImg(this,2)'
                                    visible="false" />
                            </div>
              </td>
              <td class="inner_tbl_td"><asp:FileUpload ID="uploadImage3" runat="server" Width="145"  />
              <div style="vertical-align: middle;">
                                <asp:HyperLink ID="hypSample3" Visible="false" runat="server" rel="lightbox">
                                    <asp:Image ID="Img3" CssClass="lightbox" runat="server" Width="20px" Height="20px"
                                        border="0 " align="left" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" Visible="false" /></asp:HyperLink>
                                &nbsp;
                                <input runat="server" type="button" id="Button3" class="cross" onclick='return deleteStyleImg(this,3)'
                                    visible="false" />
                            </div>
              </td>
              <td class="inner_tbl_td"><asp:HiddenField ID="hdnEmblesshment" runat="server" Value="-1" />
                            <asp:FileUpload ID="uplodeEmblesshment" runat="server" CssClass="multi"  Width="145" />
                            <asp:Repeater ID="rptUploadEmbellishment" runat="server">
                                <ItemTemplate>
                                    <div style="vertical-align: middle;">
                                        <asp:HyperLink ID="hypEmbellishment"  runat="server" rel="lightbox" NavigateUrl='<%# ResolveUrl("~/Uploads/Style/" + (Eval("ImagePath"))) %>'>
                                            <asp:Image runat="server" ID="imgEmbellishment" CssClass="lightbox" Width="20px"
                                                Height="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" />
                                        </asp:HyperLink>
                                        <input type="button" id="btnImageDelete" class="cross" onclick='return deleteImg(this,<%# Eval("id")%>)' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            </td>
              <td class="inner_tbl_td"><asp:HiddenField ID="hdnMocks" runat="server" Value="-1" />
                            <asp:FileUpload ID="uplodeMocks" runat="server" CssClass="multi"  Width="145" />
                            <asp:Repeater ID="rptUploadMocks" runat="server">
                                <ItemTemplate>
                                    <div style="vertical-align: middle;">
                                        <asp:HyperLink ID="hypMocks" runat="server" rel="lightbox" NavigateUrl='<%# ResolveUrl("~/Uploads/Style/" + (Eval("ImagePath"))) %>'>
                                            <asp:Image runat="server" ID="imgMock" CssClass="lightbox" Width="20px" Height="20px"
                                                ImageUrl="~/App_Themes/ikandi/images/icon.jpg" />
                                        </asp:HyperLink>
                                        <input type="button" id="btnImageDelete" class="cross" onclick='return deleteImg(this,<%# Eval("id")%>)' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            </td>
              <td class="inner_tbl_td"> <asp:HiddenField ID="hdnCad" runat="server" Value="-1" />
                            <asp:FileUpload ID="uplodeCad" runat="server" CssClass="multi"  Width="145"  />
                            <asp:Repeater ID="rptUploadCad" runat="server">
                                <ItemTemplate>
                                    <div style="vertical-align: middle;">
                                        <asp:HyperLink ID="hypCad" runat="server" rel="lightbox" NavigateUrl='<%# ResolveUrl("~/Uploads/Style/" + (Eval("ImagePath"))) %>'>
                                            <asp:Image runat="server" ID="imgCad" CssClass="lightbox" Width="20px" Height="20px"
                                                ImageUrl="~/App_Themes/ikandi/images/icon.jpg" />
                                        </asp:HyperLink>
                                        <input type="button" id="btnImageDelete" class="cross" onclick='return deleteImg(this,<%# Eval("id")%>)' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            </td>
              <td class="inner_tbl_td"><asp:HiddenField ID="hdnStyleMCEmbellishment" runat="server" Value="-1" />
                            <asp:FileUpload ID="uploadStyleMCEmbellishment" runat="server" CssClass="multi" Width="145"  />
                             <asp:Repeater ID="rptUploadMCEmbellishment" runat="server">
                                <ItemTemplate>
                                    <div style="vertical-align: middle;">
                                        <asp:HyperLink ID="hypMCEmbellishment" runat="server" rel="lightbox" NavigateUrl='<%# ResolveUrl("~/Uploads/Style/" + (Eval("ImagePath"))) %>'>
                                            <asp:Image runat="server" ID="imgMCEmbellishment" CssClass="lightbox" Width="20px"
                                                Height="20px" ImageUrl="~/App_Themes/ikandi/images/icon.jpg" />
                                        </asp:HyperLink>
                                        <input type="button" id="btnImageDelete" class="cross" onclick='return deleteImg(this,<%# Eval("id")%>)' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            </td>
            </tr>
            </table>
           </td>
           </tr>
           </table>
    
    </td>
  </tr>
</table>
  <div>
            <asp:Image runat="server" ID="Image1" Width="150" Visible="False" />
            <asp:Image runat="server" ID="Image2" Width="150" Visible="False" />
            <asp:Image runat="server" ID="Image3" Width="150" Visible="False" />
        </div>
</div>
</div><br />
    <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" CssClass="submit da_submit_button do-not-print" Text="Submit" />
    <input type="button" id="btnPrint" class="da_submit_button do-not-print" value="Print" onclick="return PrintPDF();" />
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">

      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
         
            <td width="1205">
             <h2 style="width: 100%;background: #39589c;text-align:center;position: relative;font-size:15px; margin: 0px 0px;padding: 2px 0px">
                   Confirmation
            </h2>
                
            </td>
          
        </tr>
    </table> 
    <div class="form_box">
        <div class="text-content" style="text-transform: capitalize;">
            Designs uploaded into the system successfully!
            <br />
            <a id="A1" href="~/internal/Dashboard_Task.aspx" runat="server">Click here</a> to Dashboard.</div>
    </div>
</asp:Panel>
