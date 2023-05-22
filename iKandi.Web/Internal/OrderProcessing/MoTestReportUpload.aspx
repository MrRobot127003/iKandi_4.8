<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoTestReportUpload.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.MoTestReportUpload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
         background-color: #39589c;
         color: #fff;
    font-size: 14px;
    font-weight: bold;
    padding: 5px 0;
     }

    </style>
  <style type="text/css">
 
  </style>
  <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
  <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
  
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
</head>

<body>
<script type="text/javascript">
    //    function ShowBiggerImage(obj) {
    //      document.getElementById("LargeImageContainerDiv").innerHTML = "<img src='" + obj.src + "'+'width=200 height=200' >";
    //    }

    //    function ShowDefaultImage(obj) {
    //      document.getElementById("LargeImageContainerDiv").innerHTML = "";
    //  }
      function UploadFile_IE(TestFileName) {
          alert(TestFileName);
          debugger;
          FileName = TestFileName;
          RptIndex = 1;
//          var x = screen.width / 2 - 700 / 2;
//          var y = screen.height / 2 - 450 / 2;
          document.getElementById('<%= hdnWholeFile.ClientID%>').value = TestFileName;
          $(".btnback").click();
          
//          var url = '../Merchandising/TestReportFileSelection.aspx?index=' + RptIndex + '&FileName=' + FileName + '&Flag=' + 'IE' + '&Flag2=' + 'TestReport';
//          window.open(url, '_blank', 'height=330,width=700,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=no, screenx=' + x + ',screeny=' +y +', addressbar=no, directories=no, titlebar=no');

         

      }

    ////  function SaveFileIE(index, FileName) {
    ////      alert("I'm back" + " " + FileName);
    ////      //$('.hdnFldresolutionTestreport').val(FileName);
    ////      document.getElementById('hdnFldresolutionTestreport').value(FileName);
    ////     // SHowHideFileIE();
    ////  }
    //  function changeFrm(NewSrc) {
    //      debugger;
    //      alert('dd');
    //      var url = '../Merchandising/TestReportFileSelection.aspx?index=' + 1 + '&FileName=' + NewSrc + '&Flag=' + 'IE' + '&Flag2=' + 'TestReport';
    //      document.getElementById('ixx').src = url;
    //  };
  </script>
  
    
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
  <form id="form1" runat="server">
  <div>

  <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
  <input id="hdnFldresolutionTestreport" type="hidden" runat="server" class="hdnFldresolutionTestreport"  />
  
  
                                    
    <table width="98%" cellpadding="0" cellspacing="0" align="center">
     <tr>
     <td colspan="3">
     <div id="divUpload">
        
        <table width="98%" cellpadding="6px" cellspacing="0" class="mid item_list1" align="center">
         <tr>
         <th colspan="2">
         Upload File
         </th>
         </tr>
            <tr>
                <td class="b" width="29%">
                    Browse File:
                </td>
                <td>
                
                    <asp:FileUpload ID="Fldresolution" runat="server" />
                    <asp:HiddenField ID="hdnWholeFile" runat="server" />
                    <asp:HiddenField ID="hdnindex" runat="server" />
                    <asp:HiddenField ID="hdnFlagIE" runat="server" />
                    <asp:HiddenField ID="hdnFlagTestReport" runat="server" />
                    <asp:Button ID="a" style="display: none" CssClass="btnback" runat="server" onclick="a_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnUpload1"  runat="server" Text="Upload" CssClass="upload da_submit_button" OnClick="btnUpload1_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater ID="rptFile" OnItemDataBound="rptFile_ItemDataBound" runat="server">
                                <HeaderTemplate>
                                    <table border="1px black solid" class="item_list" width="100%">
                                        <tr>
                                            <th width="450px" style="text-transform:capitalize;">
                                              Uploaded File
                                         
                                        </tr>
                                        </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                   <div class="img-fll">
                                         <asp:HyperLink ID="imgfile" Target="_blank"   runat="server" ImageUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview"  NavigateUrl='<%# ResolveUrl("~/uploads/Quality/" + (Eval("FilePath"))) %>'>
                                         </asp:HyperLink>
                                         <asp:ImageButton ID="imgRow"  runat="server" ImageUrl="../../images/del-butt.png" 
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
            <tr>
                <td colspan="3" align="center">
                    <%--<asp:Button ID="btnSvaeFile" runat="server" Text="Submit" CssClass="submit" OnClick="btnSvaeFile_Click" />--%>
                    <%--<asp:Button ID="btncancel" runat="server" Text="Cancel" class="cancel da_submit_button" 
                        onclick="btncancel_Click" />--%>
                   <%-- <input type="button" class="cancel da_submit_button" value="Cancel" onclick="javascript:window.parent.Shadowbox.close();" />--%>
                </td>
            </tr>
        </table>
    </div>
     </td>
     </tr>
     <%--============================================--%>
            <tr>
            
            <td colspan="3">
            
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                
                <asp:GridView ID="GrdCutAvg"  AutoGenerateColumns="false" runat="server" ShowHeader="True"
                     CellPadding="0" ShowFooter="false"  HeaderStyle-CssClass="item_list1" 
                        OnRowDataBound="GrdCutAvg_RowDataBound" Width="98%" HorizontalAlign="Center" 
                        OnRowCommand="GrdCutAvg_RowCommand">
                    
                    <Columns>
                    <asp:TemplateField HeaderText="Serial No." >
                            <ItemTemplate>
                                <asp:Label ID="lblserial" Text='<%# Eval("SerialNumber")%>' runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value='<%# Eval("OrderDetailsID")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Center"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblquantity" Text='<%# Eval("Quantity")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="73px" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact no.">
                            <ItemTemplate>
                                <asp:Label ID="lblcontractName" Text='<%# Eval("ContractNumber")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="110px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Task">
                           <ItemTemplate>
                           <asp:HiddenField ID="hdntestcheck" runat="server" Value='<%# Eval("TestReportsCheckBox")%>' />
                               <asp:RadioButtonList ID="rdolistPass_fail" runat="server" RepeatDirection="Horizontal">
                                   <asp:ListItem  Selected="True" Text="Pass" Value="1"></asp:ListItem>
                                   <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                                   <asp:ListItem Text="Waive off Pass" Value="3"></asp:ListItem>
                               </asp:RadioButtonList>
                           </ItemTemplate>
                            <ItemStyle Width="200px" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="File" Visible="false">
                           <ItemTemplate>
                             
                              <asp:HiddenField ID="hdnStylenotestReportPath" runat="server" Value='<%# Eval("StyleTestReports")%>'  />
                              
                              
                              <asp:LinkButton ID="views" CommandName="VIEW" runat="server" Text="View/Browse" CommandArgument='<%#Eval("StyleTestReports") %>' ></asp:LinkButton>
                             
                              
                             
                              
                           </ItemTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Center"/>
                        </asp:TemplateField>                                                                 
                        <asp:TemplateField HeaderText="Is Check">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                            
                        </HeaderTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="Chkischeck" AutoPostBack="true" OnCheckedChanged="Chkischeck_CheckedChanged" runat="server"  />
                            </ItemTemplate>
                            <ItemStyle Width="73px" HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        
                        
                    </Columns>
                    
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            </tr>
          
          
        
      <tr><td>&nbsp;</td></tr>
      <tr>
        <td align="center">
          <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" CssClass="da_submit_button" Text="Submit" />
          <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
        </td>
      </tr>
      <tr><td>&nbsp;</td></tr>
      
    </table>
  </div>
  </form>
</body>
</html>
