<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Line_Process_Audit_Comment_Decision.aspx.cs"
    Inherits="iKandi.Web.Internal.Qc_Complience.Line_Process_Audit_Comment_Decision1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            background: white;
            color: Gray;
            text-transform:capitalize;
        } 
        .img-fll
     {
         float:left;
         padding:10px !important;
         width:auto !important;
         background:none !important;
         position:relative;
     }
     .img-fll img
     {
         width:100%;
     }
     input[type="radio"]
     {
         position:relative;
         top:1px;
     }
      input[type="checkbox"]
     {
         position:relative;
         top:2px;
     }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 450px; margin: 0px auto;">
        <div style="width: 100%; background: #39589c; color: white; font-size: 13px; text-align: center;
            padding: 4px 0px; font-weight: 500;">
            <asp:Label ID="lblUnitName" runat="server"> </asp:Label>
            &nbsp;  Process Audit comment & Decision
        </div>
       
        <div style="width: 96%; margin-top: 6px;padding: 5px 0px 5px 10px;">
            <asp:Label runat="server" ID="lblProcessName" style="text-transform:capitalize"> </asp:Label>
            <asp:Label runat="server" ID="lblLineNumber" ForeColor="Black"></asp:Label>
            <br />
            <br />
            <div style="display:none" runat="server" id="OuthouseTextshow">
                <asp:TextBox runat="server" ID="txtOutHouseValue" onkeypress="return isNumberKey(event)" MaxLength="4"> </asp:TextBox>
            </div>
          <div runat="server" id="outhhouseCondition">
            <div style="text-align: left; color: black">
                <strong>Remarks</strong>
            </div>
            <div style="margin-bottom: 6px;">
                <asp:TextBox Style="width: 98%; text-transform:capitalize;" runat="server" ID="textareaRemarks" Text="" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div>
                <asp:RadioButtonList runat="server" ID="rdobtnStatus" RepeatDirection="Horizontal"
                    AutoPostBack="true" CellPadding="0" CellSpacing="0" Style="float: left;" OnSelectedIndexChanged="rdobtnStatus_SelectedIndexChanged">
                    <asp:ListItem Text="Pass" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Fail" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Close" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Outhouse" Value="-1" style="display:none;"></asp:ListItem>
                </asp:RadioButtonList>
                <div style="float: right; padding-right: 10px;">
           <%--         <asp:CheckBox runat="server" ID="chkApplyAll" Text="Apply To All" TextAlign="Right"
                        onclick="clickchkbox();" />--%>
                     <asp:CheckBox runat="server" ID="chkApplyAll" Text="Apply To All" TextAlign="Right" />
                    <asp:HiddenField ID="hdnchkapplyall" runat="server" Value="0" />
                </div>
                <div style="clear: both">
                </div>
            </div>
            <br />
            <div style="float:left; width:26%;"> Is Task Closed<input type="checkbox" runat="server" id="chkIsclosed" /></div>
            <div style="width:38%; float:left;">
            <div style="width:100%">
         <asp:RadioButtonList runat="server" ID="RadioButtonActive" RepeatDirection="Horizontal"
                    AutoPostBack="true" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="RadioButtonActive_SelectedIndexChanged">
                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                    <asp:ListItem Text="In Active" Value="0"></asp:ListItem>
                   
                </asp:RadioButtonList>
        </div>
            </div>
            <div style="float:left; width:38%; display:none;"> 

            <asp:HiddenField ID="hdnStylenotestReportPath" runat="server" Value='<%# Eval("StyleTestReports")%>'  />
                    <asp:FileUpload ID="Fldresolution" runat="server" Width="200px" />
                    <asp:HiddenField ID="hdnWholeFile" runat="server" />
                    <asp:HiddenField ID="hdnindex" runat="server" />                

               </div>
            <div style="float:right; width:32%; text-align:right;display:none;">
            <asp:Button ID="btnUpload1"   runat="server" Text="Upload" CssClass="upload da_submit_button" OnClick="btnUpload1_Click" />               
            </div>
            
            </div>
            
            
            
            <div style="float:right">
             <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="go da_submit_button"
                    OnClick="Submit_Click" OnClientClick="return submitme();" />
                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Text="Close"
                    OnClientClick="javascript:closeMe();" />
            </div>
            <div style="clear:both;"></div>
            <br />
            <div style="display:none;">
            <input id="hdnFldresolutionTestreport" type="hidden" runat="server" class="hdnFldresolutionTestreport"  />
               <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater ID="rptFile" runat="server">
                                <HeaderTemplate>
                                <div style="background:#dddfe4;color:#575759"> Uploaded File</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                   <div class="img-fll" id="hideImg" runat="server">
                                         <asp:HyperLink ID="imgfile" Target="_blank"  runat="server" ImageUrl='<%# ResolveUrl("~/uploads/OwnerRes/" + (Eval("FilePath"))) %>'  Width="50px" CssClass="imgupload preview">
                                         </asp:HyperLink>
                                         <asp:ImageButton ID="imgRow" runat="server" ImageUrl="../../images/del-butt.png"
                                                CausesValidation="false" ToolTip="Delete Pic" style="position:absolute; margin-left:-10px; top: 0px; right: 0px;" OnClick="imgRow_Click" />
                                         <asp:HiddenField ID="hdnFilePath" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                                       </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                </FooterTemplate>
                            </asp:Repeater>
                            <div style="clear:both;"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </div>
           
            <div>
                <span style="color: Red;font-size:11px;">Note: Apply to all (check/ uncheck) functionality worked with Close and Pass case Only, Fail Should Fill Individuallly.</span>
            </div>
            <script type="text/javascript">
                function closeMe() {
                    self.parent.Shadowbox.close();
                }
                function submitme() {
                   //debugger;
                    // var chx = document.getElementsByTagName('input');
                    if ($("#chkApplyAll").is(':checked')) {
                        $("#hdnchkapplyall").val("1");
                    }
                    else {
                        $("#hdnchkapplyall").val("0");
                    }
                    

                    if ($("#RadioButtonActive_0").is(':checked')) {
                        var count = $("#rdobtnStatus input[type='radio']:checked").length;
                        if (count < 1) {
                            alert("Please select atleast one option.");
                            return false;
                        }
                        else {
                            if ($("#rdobtnStatus_1").is(':checked')) {
                               // debugger;
                                if ($("#textareaRemarks").val().trim() == "") {
                                    alert("Please enter the remarks.");
                                    $("#textareaRemarks").focus();
                                    $("#textareaRemarks").val('')                                   
                                    return false;
                                }                                
                            }
                            return true; 
                        }
                    }
                  
                }
               
            </script>

            <script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
            <SCRIPT language=Javascript>
                function isNumberKey(evt) {
                    var charCode = (evt.which) ? evt.which : evt.keyCode;
                    if (charCode > 31 && (charCode < 48 || charCode > 57))
                        return false;
                    return true;
                }
   </SCRIPT>
        </div>
    </div>
    </form>
</body>
</html>
