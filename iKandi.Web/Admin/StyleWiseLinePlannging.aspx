<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StyleWiseLinePlannging.aspx.cs" Inherits="iKandi.Web.Admin.StyleWiseLinePlannging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="../App_Themes/ikandi/ikandi1.css" />
    <link rel="stylesheet" type="text/css" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/datepicker.css" />   
    
   
    <style type="text/css">
        a.dp-choose-date
        {
            float: left;
            width: 16px;
            height: 16px;
            padding: 0;
            margin: 1px 3px 0;
            display: block;
            text-indent: -2000px;
            overflow: hidden;
            background: url(../../images/calendar_icons.png) no-repeat;
        }
        a.dp-choose-date.dp-disabled
        {
            background-position: 0 -20px;
            cursor: default;
        }      
        input.dp-applied
        {
            width: 140px;
            float: left;
        }
        .txt
        {
            width: 40px;
            text-align: center;
            color: #7E7E7E;
        }
        #spinn
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        .da_submit_button:hover
        {
            padding:0px;
        } 
        span
        {
            font-size:11px
        }
        input[type="text"], textarea, select
        {
            text-transform:capitalize;
        }
        #rbtnList tr td:first-child input
        {
            margin-left:0px !important;
        }
    </style>
</head>
<body bgcolor="#FFFFFF" style="padding:10px;">


 <script type="text/javascript" src="../js/service.min.js"></script>
 <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>  
 <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-1.4.4.min.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/facebox.js")%>'></script> 
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/js.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/ImageFaceBox.js")%>'></script>   
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("../js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/colorpicker.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("../js/fna.js")%>' type="text/javascript"></script>
   <script type="text/javascript" src='<%= Page.ResolveUrl("../js/date.js")%>'></script>

     <script type="text/javascript">
         var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
         var proxy = new ServiceProxy(serviceUrl);
         
         $(function () {
             MyDatePickerFunction();
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MyDatePickerFunction);
             $('span.number-with-commas', '#main_content').FormatNumberWithCommas();

             initializer();
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initializer);
    
                 
         });
         function initializer() {
             // debugger;//serial numnber will be unit wise
             $("input[type=text].styleCodeSuggest").autocomplete("/Webservices/iKandiService.asmx/SuggestStylesCode", { dataType: "xml", datakey: "string", max: 100 });
             $("input[type=text].styleCodeSuggest").result(function () {
                 $(".btnStyleCode").click(); 
             });
         }

         function pageLoad() {
             $("input[type=text].styleCodeSuggest").autocomplete("/Webservices/iKandiService.asmx/SuggestStylesCode", { dataType: "xml", datakey: "string", max: 100 });
             $("input[type=text].styleCodeSuggest").result(function () {
                 $(".btnStyleCode").click();
             });
         }     
         

         function MyDatePickerFunction() {
             //debugger;        
             var TDate = new Date();
             var CDate = new Date();
             var MDate = CDate.addDays(30);
             $(".date-picker").datepicker({ dateFormat: "dd M y (D)", minDate: TDate, maxDate: MDate }).val();

             var txtStartDate = $('#<%= txtStartDate.ClientID %>');
             if (txtStartDate.disabled == true) {
                 $('#<%= txtStartDate.ClientID %>').removeClass("date-picker");
             }
         }

         function CheckAll(elem) {
              //debugger;   
             if ($(elem).is(':checked')) {
                 var RowId = 0;
                 var gvId;
                 var GridRow = $(".gvRow").length;
                 GridRow = parseInt(GridRow) + 1;
                 for (var row = 1; row <= GridRow; row++) {
                     RowId = parseInt(row) + 1;
                     if (RowId < 10)
                         gvId = 'ctl0' + RowId;
                     else
                         gvId = 'ctl' + RowId;

                     var LineQty = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='" + gvId + "_txtLineQty" + "']").val();
                     var chk = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='" + gvId + "_chk" + "']");
                     if (LineQty != '') {
                         chk.attr("checked", "checked");
                     }
                 }           
             }
             else {                    
                 $('.chkRow').find("input[type=checkbox]").attr('checked', false);
             }

         }

            function BindStyleCode(StylePrefix) {
                //debugger;
                var UnitId = $('#<%= hdnUnitId.ClientID %>').val();
                var LineNumber = $('#<%= hdnLineNo.ClientID %>').val();
                var Status = 'add'

                $('#<%= ddlStyleCode.ClientID %>').empty();
                proxy.invoke("GetStyleCodeDetails", { UnitId: UnitId, LineNo: LineNumber, Status: Status, StylePrefix: StylePrefix }, function (result) {
                    $.each(result, function (key, value) {
                        $('#<%= ddlStyleCode.ClientID %>').append($("<option></option>").val(value.StyleCode).html(value.StyleCode));                     
                    });

                });
            }


         var ddlText, ddlValue, ddl, lblMesg;
         function CacheItems() {
             //debugger;            
             ddlText = new Array();
             ddlValue = new Array();
             ddl = $('#<%= ddlStyleCode.ClientID %>');

             for (var i = 0; i < ddl.options.length; i++) {
                 ddlText[ddlText.length] = ddl.options[i].text;
                 ddlValue[ddlValue.length] = ddl.options[i].value;
             }
         }
         //window.onload = CacheItems;
        
         function FilterItems(value) {
             //debugger;
             $(".btnStyleCode").click();                   

         }
        

         function AddItem(text, value) {
             var opt = document.createElement("option");
             opt.text = text;
             opt.value = value;
             ddl.options.add(opt);
         }         

         function isNumberKey(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode

             if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;


             return true;
         }

        function GetSlotTime(obj) {
            //debugger;
            var SlotId = obj.value;        
             
            if (SlotId != '0') {
                proxy.invoke("GetSlotTime", { SlotId: SlotId },
                        function (result) {
                            if (result != null) {
                                if (result.length > 0) {
                                    //alert(result);                                          
                                    $('#<%= lblStartSlot.ClientID %>').html(result);        
                                }
                            }
                        });
                     }
               }



               function OBchange(obj, type) {
                   //debugger;
                   var OB = obj.value;
                   if (type == 1) {
                       if (OB != '0') {
                           $('#<%= txtStitchOB.ClientID %>').val('');
                           return false;
                       }
                   }
                   if (type == 2) {
                       if (parseInt(OB) == 0) {
                           $('#<%= txtStitchOB.ClientID %>').val('');
                           jQuery.facebox('OB can not be 0!');
                           return false;
                       }
                       if (OB != '') {
                           var x = document.getElementById("<%=ddlStitchOB.ClientID %>");
                           x.selectedIndex = 0;
                           return false;
                       }
                   }
               }

         function ValidateLineQty(obj) {
             //debugger;
             var LineQty = obj.value;
             var cId = obj.id.split("_")[1].substr(3);
             var UnitQty = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='ctl" + cId + "_hdnUnitQty" + "']").val();
             var StitchQty = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='ctl" + cId + "_hdnStitchQty" + "']").val();
             var hdnLineQty = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='ctl" + cId + "_hdnLineQty" + "']").val();
             var hdnTotalLineQty = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='ctl" + cId + "_hdnTotalLineQty" + "']").val();

             if ((LineQty != '') && (UnitQty != '')) {
                 if (parseInt(LineQty) == 0) {
                     obj.value = "";
                     return false;
                 }
                 var ThisLineQty = parseInt(LineQty) - parseInt(hdnLineQty)
                 var TotalLineQty = parseInt(hdnTotalLineQty) + parseInt(ThisLineQty)

                 if (parseInt(TotalLineQty) > parseInt(UnitQty)) {                    
                     jQuery.facebox('Line qty can not be greater than qty to plan!');
                     obj.value = "";
                     return false;
                 }

                 if (StitchQty != '') {
                     if (parseInt(LineQty) < parseInt(StitchQty)) {                      
                         jQuery.facebox('Line qty can not be less than Stitched qty!');
                         obj.value = "";
                         return false;
                     }
                 }
             }
         }


         function CheckUnitQty(cb) {
             //debugger;
             var Ids = cb.id;
             var cId = Ids.split("_")[1].substr(3);
             var LineQty = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='ctl" + cId + "_txtLineQty" + "']").val();
             if (cb.checked) {
                 if ((LineQty == '') || (LineQty == '0')) {                    
                     jQuery.facebox('Line Qty can not be 0 or empty!');
                     $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='ctl" + cId + "_txtLineQty" + "']").focus();
                     return false;
                 }
             }
             else {
                 $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='ctl" + cId + "_txtLineQty" + "']").val('');
             }
         }

         function ValidateData() {
             //debugger;
             $(".submit").css("display", "none");
             var StyleCode = $('#<%= txtStyleCode.ClientID %>').val(); 
             var Sam = '';
             var OB = '';
             var NewOB = '';
             var StyleId = '';

             if (StyleCode == '0') {                
                 jQuery.facebox('Please Select Style Code!');
                 return false;
             }
             var HalfStitch = $('#<%= ChkHalfStitch.ClientID %>')
             if (HalfStitch.is(':checked')) {
                 StyleId = $('#<%= hdnStyleId.ClientID %>').val();
                 Sam = $('#<%= lblStitchSam.ClientID %>').text();
                 OB = $('#<%= lblStitchOB.ClientID %>').text();
                 if (Sam == '') {                   
                     jQuery.facebox('SAM can not be empty!');
                     $(".submit").css("display", "block");
                     return false;
                 }
                 if (OB == '') {
                     $(".submit").css("display", "block");                   
                     jQuery.facebox('OB can not be empty!');
                     return false;
                 }
             }
             else {
                 StyleId = $('#<%= ddlStitchSAM.ClientID %> option:selected').val();
                 if (StyleId == '0') {                    
                     jQuery.facebox('Please Select SAM!');
                     $(".submit").css("display", "block");
                     $('#<%= ddlStitchSAM.ClientID %> option:selected').focus();
                     return false;
                 }
                 OB = $('#<%= ddlStitchOB.ClientID %> option:selected').val();
                 NewOB = $('#<%= txtStitchOB.ClientID %>').val();
                 if (OB == '0') {
                     if ((NewOB == '0') || (NewOB == '')) {                       
                         jQuery.facebox('Please Select or Fill OB!');
                         $(".submit").css("display", "block");
                         $('#<%= ddlStitchOB.ClientID %> option:selected').focus();
                         return false;
                     }
                 }
             }

             var StartDate = $('#<%= txtStartDate.ClientID %>').val();
//             alert($('#ddlFrame option').length);
             if ((StartDate == '') && ($('#ddlFrame option').length > 1)) {                
                 jQuery.facebox('Please Select Frame!');
                 $(".submit").css("display", "block");
                 $('#<%= ddlFrame.ClientID %>').focus();
                 return false;
             }
             var StartSlot = $('#<%= ddlStartSlot.ClientID %> option:selected').val();
             if (StartSlot == '0') {                
                 jQuery.facebox('Please Select Start Slot!');
                 $(".submit").css("display", "block");
                 $('#<%= ddlStartSlot.ClientID %> option:selected').focus();
                 return false;
             }
             //debugger;
             var CanDelete = 0;
             var TotalLineQty = 0;
             var Check = 0;
             var RowId = 0;
             var gvId;
             var GridRow = $(".gvRow").length;
             GridRow = parseInt(GridRow) + 1;
             for (var row = 1; row <= GridRow; row++) {
                 RowId = parseInt(row) + 1;
                 if (RowId < 10)
                     gvId = 'ctl0' + RowId;
                 else
                     gvId = 'ctl' + RowId;

                 var hdnStyleId = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='" + gvId + "_hdnStyleId" + "']").val();
                 var chk = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='" + gvId + "_chk" + "']");

                 if (chk.is(':checked')) {
                     Check = 1;
                     var LineQty = $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='" + gvId + "_txtLineQty" + "']").val();
                     if ((LineQty == '0') || (LineQty == '')) {                         
                         jQuery.facebox('Line Qty can not be 0 or Empty!');
                         $(".submit").css("display", "block");
                         $("#<%= gvNextChangeOverStyleDetail.ClientID %> input[id*='" + gvId + "_txtLineQty" + "']").focus();
                         return false;
                     }
                     TotalLineQty = parseInt(TotalLineQty) + parseInt(LineQty);
                     if (hdnStyleId == StyleId) {
                         CanDelete = 1;
                     }
                 }
             }
             $('#<%= hdnTotalQty.ClientID %>').val(TotalLineQty);
             if (CanDelete == 0) {
                 $(".submit").css("display", "block");
                 jQuery.facebox('Please select atleast one style, which SAM is selected or change the SAM!');
                 return false;
             }
             if (Check == 0) {
                 $(".submit").css("display", "block");
                 jQuery.facebox('Please Select atleast one contract!');
                 return false;
             }
         }

         function CreateNewFrame(FrameId) {
             //debugger;
             alert(FrameId);
             var isYes = confirm("The Frame " + FrameId + " already exist, do you still want to create a new frame!");
             if (isYes == false) {
                 return false;
             }
         }

       
     </script>
       <script type="text/javascript">
           function disableautocompletion(id) {
               var txt = document.getElementById(id);
               txt.setAttribute("autocomplete", "off");
           }

          
          
           
    </script>
    <%--abhishek--%>
    <script type="text/javascript">
//        $(function () {
//            initializer();
//        });
//        var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
//        prmInstance.add_endRequest(function () {
//            
//            initializer();
//        });

//        function initializer() {
//            // debugger;//serial numnber will be unit wise
//            jQuery("input.styleCodeSuggest", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestStylesCode", { dataType: "xml", datakey: "string", max: 100 });
//            jQuery("input.styleCodeSuggest", "#main_content").result(function () {

//            });
//        };
    </script>
    <%--end--%>

    <form id="form1" runat="server">
  
    <div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
   <asp:UpdatePanel ID="udpnlLinePlan" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
    <div style="text-align: center; padding:5px 0px; background-color: #405D99;
                                color: #FFFFFF; font-weight: bold; text-transform:capitalize;
                                font-family:Verdana; width:100%;">
      <div style="float:left; margin-left:10px; width:auto;">
      <span style="font-weight: bold;">Factory&nbsp;&nbsp;</span><asp:Label ID="lblFactory"
                                    runat="server" ForeColor="#cec8c8"></asp:Label>  

                              &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  <span style="font-weight: bold;">
                                  <asp:Label ID="lblFrame" runat="server" Text=""></asp:Label>&nbsp;&nbsp;</span><asp:Label ID="lblFrameNo" runat="server" ForeColor="#cec8c8"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span id="linetextspan" runat="server" style="font-weight: bold;">Line&nbsp;&nbsp;</span><asp:Label ID="lblLineNo"
                                    runat="server" ForeColor="#cec8c8"></asp:Label>
          <asp:HiddenField ID="hdnUnitId" runat="server" />
          <asp:HiddenField ID="hdnLineNo" runat="server" />
      </div>
                                Planning Detail
                            
                            <div style="float:right; margin-right:10px; width:auto;">
                                <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" style="padding:0px;" Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                          </div> 
                          <div style="clear:both;"></div>
    </div>
      
       <div style="text-transform:capitalize;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">    
                    <tr><td style="width:600px;" colspan="8">    
                       <div style="float:left; width:250px"> <asp:RadioButtonList ID="rbtnList" RepeatDirection="Horizontal" AutoPostBack="true" runat="server" ForeColor="#7E7E7E" 
                            onselectedindexchanged="rbtnList_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="Sequence Frame" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Parallel Frame"></asp:ListItem>
                        </asp:RadioButtonList> 
                        </div>
                        &nbsp;&nbsp; 
                        <div style="float:left; width:200px; margin-top:5px;">
                        <asp:DropDownList ID="ddlFrame"  runat="server" AutoPostBack="true"  
                                onselectedindexchanged="ddlFrame_SelectedIndexChanged" ForeColor="#000000">
                        </asp:DropDownList>
                        
                        </div>
                        </td></tr>  
                        <tr> <td style="line-height:5px">&nbsp;</td></tr> 
                        <tr>
                        
                        
                           <td align="left" style="font-size: 11px; width:70px; font-family:Verdana;">
                                <asp:Label ID="lblStylecode" runat="server" Text="Style Code" ForeColor="#7E7E7E"></asp:Label>&nbsp;                              
                            </td>
                            <td align="left" style="font-size: 11px; width: 120px; font-family: Verdana;">
                                <asp:TextBox ID="txtSearch" style="display:none;"  runat="server" MaxLength="5" onkeyup="FilterItems(this.value)"
                                    onfocus="disableautocompletion(this.id)" CssClass="txt" ForeColor="#000000" ></asp:TextBox>
                                <asp:DropDownList ID="ddlStyleCode" Style="display: none;" OnSelectedIndexChanged="ddlStyleCode_SelectedIndexChanged"
                                    AutoPostBack="true" runat="server" Width="120px" Font-Bold="false" ForeColor="#000000">
                                </asp:DropDownList>
                                <asp:TextBox runat="server" onchange="javascript:Callbtn();" Width="85px" CssClass="styleCodeSuggest" ID="txtStyleCode" ForeColor="#000000" Font-Bold="true"></asp:TextBox>

                                <asp:Button ID="btnStyleCode" CssClass="btnStyleCode" Style="display: none;" runat="server"
                                    Text="Button" OnClick="btnStyleCode_Click" />
                            </td>
                                  
                        
                         <td style="text-align:right;font-size: 11px;  font-family:Verdana; width: 50px;">
                               <span style="color:#7e7e7e">SAM&nbsp;&nbsp;</span>
                            </td>
                           <td align="left" style="width: 170px; font-size: 11px; font-weight: bold; font-family:Verdana;">    

                                <asp:Label ID="lblStitchSam" Font-Bold="false" Visible="false" runat="server" Text="" ForeColor="#000000"></asp:Label>
                               <asp:HiddenField ID="hdnStyleId" Value="0" runat="server" />

                                <asp:DropDownList ID="ddlStitchSAM" runat="server" Width="150px" ForeColor="#000000">
                                <asp:ListItem Text="Select" Value="0" ></asp:ListItem> </asp:DropDownList>
                                
                             </td>
                             <td align="left" style="width: 60px;
                                font-size: 11px; font-family:Verdana;text-align:center;">
                                 <asp:Label ID="lblws_OB" Visible="false" runat="server" Text="OB W/S" ForeColor="#7E7E7E"></asp:Label>
                              <%-- <span style="">OB W/S &nbsp;&nbsp;</span>--%>
                               </td>
                               <td align="left" style="font-size: 11px; font-family:Verdana; width:165px">

                               <asp:Label ID="lblStitchOB" Font-Bold="false" Visible="false" runat="server" Text=""></asp:Label>

                                <asp:DropDownList ID="ddlStitchOB" onchange="javascript:OBchange(this,1)" Width="70px" runat="server" ForeColor="#000000">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem></asp:DropDownList> 
                                 <asp:Label ID="lblSingleOB" runat="server" Visible="false" Text="Plan OB:"></asp:Label>
                                <asp:Label ID="lblOr" runat="server" Text="Or"></asp:Label>
                                
                                <asp:TextBox ID="txtStitchOB" placeholder="Enter OB" MaxLength="3" onblur="javascript:OBchange(this,2)" onkeypress="return isNumberKey(event)"  Width="50px" runat="server" ForeColor="#000000"></asp:TextBox>  
                              
                            </td>
                          <td align="left"><asp:CheckBox ID="ChkHalfStitch" Enabled="false" runat="server" 
                                     Text="Half Stitch" AutoPostBack="false" TextAlign="Left" ForeColor="#7E7E7E"
                            oncheckedchanged="ChkHalfStitch_CheckedChanged" />
                            </td>
                             <td style="padding-right:30px;" align="right"><asp:CheckBox ID="chkFrameComplete" runat="server" Visible="false"
                                     Text="Frame Complete" AutoPostBack="true" TextAlign="Left" 
                                    ForeColor="#7E7E7E" oncheckedchanged="chkFrameComplete_CheckedChanged"
                             />
                            </td>
                        </tr>
                     
                     </table>
                     <br />                    

                      <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                         <td align="left" style="font-size: 11px; font-family:Verdana;width: 70px;">
                         <span style="color:#7e7e7e;">Start Date</span>
                        </td>
                        <td align="left" style="font-size: 11px; font-weight: bold; font-family:Verdana; width:105px">
                                <asp:TextBox runat="server" ID="txtStartDate" CssClass="date-picker do-not-allow-typing" Width="100px" ForeColor="#000000"></asp:TextBox>
                                </td>

                       <td align="left" style="font-size: 11px; font-family:Verdana; width:200px;">
                         <span style="color:#7e7e7e">Slot&nbsp;&nbsp;</span>
                     
                        <asp:DropDownList ID="ddlStartSlot" Width="60px" onchange="javascript:GetSlotTime(this)" runat="server" ForeColor="#000000">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>

                                </asp:DropDownList>     
                            <asp:Label ID="lblStartSlot" style="font-weight:normal;" runat="server" Text="" ForeColor="#000000"></asp:Label>                          
                                </td>
                                 <td align="center" style="font-size: 11px; font-family:Verdana; width:60px">
                         <span style="color:#7e7e7e">End Date&nbsp;&nbsp;</span>
                        </td>
                        <td align="left" style="width: 100px;font-size: 11px; font-weight: bold; font-family:Verdana; width:105px">
                                <asp:TextBox runat="server" ID="txtEndDate" ReadOnly="true" CssClass="do-not-allow-typing" Width="100px" ForeColor="#000000"></asp:TextBox>                           
                                </td>
                                 <td  align="left" style="width: 200px;
                                font-size: 11px; font-family:Verdana;">
                         <span style="color:#7e7e7e">Slot</span>&nbsp;
                         <asp:TextBox ID="txtEndSlot" ReadOnly="true" style="text-align:center;" CssClass="do-not-allow-typing" Width="50px" runat="server" ForeColor="#000000"></asp:TextBox>

                           <asp:Label ID="lblEndSlotTime" runat="server" style="font-weight:normal;" Text="" ForeColor="#000000"></asp:Label>
                                     <asp:HiddenField ID="hdnTotalQty" Value="0" runat="server" />
                                </td>
                        </tr>
                        </table>

                        </div>
                          <div style="text-align:center;">
              <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="udpnlLinePlan">
            <ProgressTemplate>
                <div class="modal">
                    <div class="center" style="removed:absolute; z-index:1; removed 50%;removed 50%;">
                        <img alt="" src="../images/loading36.gif" />
                    </div>
                </div>
            </ProgressTemplate>
            </asp:UpdateProgress></div>
                        <div id="dvExsitFrame" style="display:none; text-align:center;" runat="server">
                         <br />
                            <asp:Label ID="lblMsgExistFrame" Font-Size="13px" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                        <br />                      
                       
                                <asp:GridView ID="gvNextChangeOverStyleDetail" runat="server" AutoGenerateColumns="false"
                                    Width="98%" ShowHeader="true" HeaderStyle-Height="35px" 
                                    HeaderStyle-Font-Size="10px" HeaderStyle-Font-Names="Verdana"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#405D99"
                                    HeaderStyle-BackColor="#F0F3F2" RowStyle-Height="35px" RowStyle-HorizontalAlign="Center"
                                    RowStyle-ForeColor="#7E7E7E"                                     
                                    onrowdatabound="gvNextChangeOverStyleDetail_RowDataBound" 
                                    ondatabound="gvNextChangeOverStyleDetail_DataBound">
                                    <RowStyle CssClass="gvRow" />                                   
                                    <Columns>
                                        <asp:TemplateField HeaderText="Style No." HeaderStyle-Width="100px" ItemStyle-VerticalAlign="Middle">                                        
                                        <ItemTemplate>                                                                  
                                            <asp:Label ID="lblStyleNo" runat="server" Text='<%# Eval("StyleNumber") %>'></asp:Label>                                           
                                        </ItemTemplate>                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Serial No." HeaderStyle-Width="60px" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>                                             
                                               <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber") %>' ForeColor="Black" Font-Bold="true"></asp:Label>
                                               <asp:HiddenField ID="hdnOrderId" Value='<%# Eval("OrderID") %>' runat="server" />
                                                <asp:HiddenField ID="hdnStyleId" Value='<%# Eval("StyleId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contract No." HeaderStyle-Width="80px">
                                            <ItemTemplate>                                              
                                                <asp:Label ID="lblContractNo" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnOrderDetailId" Value='<%# Eval("OrderDetailsID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="Fit Status" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFitStatus" Text='<%# Eval("FitsStatus") %>' runat="server" Font-Size="7px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>        

                                        <asp:TemplateField HeaderText="Ex Fact Date" HeaderStyle-Width="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExFactoryDate" Text='<%# (Convert.ToDateTime(Eval("ExFactory")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ExFactory"))).ToString("dd MMM (ddd)")%>' runat="server" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>    

                                          

                                        <asp:TemplateField HeaderText="Contract Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContractQty" Text="" runat="server" Font-Size="11px"></asp:Label>
                                                <asp:HiddenField ID="hdnContractQty" Value='<%# Eval("ContractQty") %>' runat="server" />
                                            </ItemTemplate>
                                          
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Unit Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitQty" Text="" runat="server" Font-Size="11px"></asp:Label>
                                                <asp:HiddenField ID="hdnUnitQty" Value='<%# Eval("UnitQty") %>' runat="server" />
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                          <asp:TemplateField  HeaderText="Qty To Plan" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQtyPlan" Text="" runat="server" Font-Size="11px"></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Line Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLineQty" Text='<%# Eval("LineQty") %>' onkeypress="return isNumberKey(event)" onblur="javascript:return ValidateLineQty(this)"
                                                 runat="server" Font-Size="11px" Width="45px" MaxLength="5"></asp:TextBox>
                                                 
                                                 <asp:HiddenField ID="hdnLineQty" Value='<%# Eval("LineQty") %>' runat="server" /> 
                                                 <asp:HiddenField ID="hdnTotalLineQty" Value='<%# Eval("TotalLineQty") %>' runat="server" /> 
                                                 <asp:HiddenField ID="hdnRemainLineQty" Value='<%# Eval("RemainLineQty") %>' runat="server" /> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Stitched Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStitchQty" Text="" runat="server" Font-Size="11px"></asp:Label>
                                                <asp:HiddenField ID="hdnStitchQty" Value='<%# Eval("StichedQty") %>' runat="server" />
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                          
                                          <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                         <HeaderTemplate>
                                             <asp:CheckBox ID="chkHeaderId" CssClass="chkHeader" OnClick="javascript:CheckAll(this)" runat="server" />
                                         </HeaderTemplate>
                                         <HeaderStyle Width="30px" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" CssClass="chkRow" onclick="javascript:return CheckUnitQty(this)" runat="server" />
                                                <asp:HiddenField ID="hdnLinePlanId" Value='<%# Eval("LinePlanningID") %>' runat="server" /> 
                                                <asp:HiddenField ID="hdnLineNo" Value='<%# Eval("LineNumber") %>' runat="server" />
                                                <asp:HiddenField ID="hdnIsStitching" Value='<%# Eval("IsStitching") %>' runat="server" />                                              
                                            </ItemTemplate>
                                        </asp:TemplateField>                                       
                                  
                                    </Columns>
                                </asp:GridView>
                           
                       <br />
                        <table border="0" cellpadding="0" cellspacing="0" style="padding-right:15px;" width="100%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnSubmit"  runat="server" CssClass="submit" Text="Submit" style="display:none;"
                                     OnClientClick="javascript:return ValidateData();" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td id="tdMessage" runat="server" align="right" visible="false" style="height: 20px;
                                font-family:Verdana;">
                                <asp:Label ID="lblValidationMessage" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                            </td>
                        </tr>
                    </table>

              </ContentTemplate>
              </asp:UpdatePanel>  
            

            
    </div>
    </form>
</body>
</html>
