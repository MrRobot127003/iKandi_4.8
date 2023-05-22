<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPlaceAccessories.aspx.cs" Inherits="iKandi.Web.Internal.Sales.OrderPlaceAccessories" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


   
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<style type="text/css">
     .modalAcc
    {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 0;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }
    .modal-content {
        padding: 7px !important;
        border: 1px solid #7a94bb;
        }
#dvSizeRate
    {
    max-width:400px !important;
    margin:0px auto;
    background:#fff;
    
    }
     #dvSizeRate td
    {
     font-size:9px !important;
     text-align:center;
    }
#dvChildAccessories
{
    max-width:100% !important;
    background:#FFF;
    margin:0 auto;
    position:relative;
    }
    
.headerAccessories
{
    width: 100%;
    background: #39589c;
    height: 23px;
    margin-bottom: 5px;
    text-align: center;
    color: #e7e4fb;
    position: fixed;
    z-index: 10000;
    }
    .txtAccessories_New
    {
        width: 137px !important;               
        border-radius: 2px;
        padding-left: 3px;
        font-size:10px !important;
    }
.accessColwidth
  { 
      width:272px;
      font-size:10px;
      position:relative;
      top:1px;
    }
.textborder_New
{
   border: 1px solid #cebdbd !important;
    height: 14px !important;
    border-radius: 2px;
    color:Black !important;
    width:40px !important;
}
.checkboxright_New
{
    position:relative;
    top:1px;
}
.submitdivwidth
{
  width:90%;
  text-align:right;
position:absolute;
bottom:10px;
}
.Adddivwidth
{
width:65%;
text-align:right;
bottom:10px;
}
  /*Access Dilog box*/
    
 .ui-dialog {
    position: absolute;
    padding: .2em;
    width: 400px !important;
    overflow: hidden;
    background: #fff ;
    z-index: 0 !important;
     border:1px solid #999;
}
.ui-dialog-titlebar-close
{
     display:none;
  }
  .ui-draggable .ui-dialog-titlebar {
    cursor: auto;
}
  .ui-dialog .ui-dialog-title {
    float: none;
    margin: .1em 16px .2em 0;
    text-align:center;
}
#dvAccessory
{
    width: auto;
    max-height: 300px !important;
    min-height: 250px !important;
    overflow: auto;
  }
  .accessColwidth input[type="text"]
  {
      margin-bottom:1px;
      height: 15px;
   }
   
.submit{
    background: #13a747 !important;
    padding: 5px 9px;
    color: #fff;
    font-size: 12px;
    border: none !important;
    font-weight: bold;
    cursor: pointer;
}
.submit:hover {
        background: #13a747 !important;
        padding: 5px 9px;
        color: yellow;
        font-size: 12px;
        border: none !important;
        font-weight: bold;
}
.ui-dialog.ui-widget
{
    background:#ffff;
  }
.NoRecord
{
    color:Blue;
    font-size:10px;
 }  
</style>
</head>
<body>

<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script> 
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>  
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>   
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
   <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>

     <script type="text/javascript">
         var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
         var proxy = new ServiceProxy(serviceUrl);

         var Item;
         var ItemId;
         $(function () {
             //debugger;
             PopulateAccessories();
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(PopulateAccessories);
         });

         function PopulateAccessories() {
             $("input.AccessInput").autocomplete("/Webservices/iKandiService.asmx/GetAccessoryList_newtubularAutoComp", { dataType: "xml", datakey: "string", max: 100, "width": "150px" });

             $("input.AccessInput").result(function () {
                 //debugger;
                 $(this).removeClass("InvalidAcc");

                 if ($(this).val().includes('Supplier Details')) {
                     $(this).val("");
                     return;
                 }

                 var mys = $(this).val().split('$');
                 var mys2 = mys[1].split('**');

                 $(this).val(mys2[0].trim());
                 var Id = mys2[1].trim();
                 var Unit = mys2[2].trim();
                 Item = $(this);
                 ItemId = $(Item)[0].id.split("_")[1];
                 $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnAccessId" + "']").val(Id);
                 $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnAccessName" + "']").val($(Item).val());

                 if (Id > 0) {
                     //--------------------Funtion for Get Sixze Rate------------------
                     var url = "../../Webservices/iKandiService.asmx";
                     $.ajax({
                         type: "POST",
                         url: url + "/GetSize_Rate",
                         data: "{ search:'" + Id + "'}",
                         contentType: "application/json; charset=utf-8",
                         dataType: "json",
                         success: OnSuccessAccessCall,
                         error: function (response) { alert(response.d); }
                     });
                 }

             });

             function OnSuccessAccessCall(response) {
                 //debugger;
                 var table = "<h3 style='background-color: #4061ab;color: #F8F8F8;border: 1px solid gray;padding:2px; margin: 0px; font-size: 11px;text-align: center;'>Size Rate</h3>";
                 table += "<table style='table-layout:fixed;'  cellpaddig='0' cellspacing='0'class='access_infotable' border='0' width='100%'>";
                 if (response.d != '') {
                     table += "<tr>";
                     var parser = new DOMParser();
                     var xmlDoc = parser.parseFromString(response.d, "text/xml");
                     var xml = $(xmlDoc);
                     var Size = xml.find("Size");
                     var FinishRate = xml.find("FinishRate");
                     var CPP = xml.find("ConvertToPerPcs");
                     var AccessoryQualityId = xml.find("accessory_qualityID");
                     for (var i = 0; i < Size.length; i++) {
                         var Sz = Size[i].innerHTML;
                         table += "<th style='background-color: #d8d1d1d4 !important;color: #000 !important;'>" + Sz
                         table += "</th>";
                     }
                     table += "</tr><tr>";
                     for (var j = 0; j < FinishRate.length; j++) {
                         var SRate = FinishRate[j].innerHTML;
                         var Sze = Size[j].innerHTML;
                         var CP = CPP[j].innerHTML;
                         var SizeId = AccessoryQualityId[j].innerHTML;
                         table += "<td><span id='lblSizeRate' style='cursor:pointer;' class='SizeRate'> " + SRate + "</span>"
                         table += "</td>";
                         table += "<td style='display:none;'><span id='lblSize' class='Size'> " + Sze + "</span>"
                         table += "</td>";
                         table += "<td style='display:none;'><span id='lblCPP' class='CPP'> " + CP + "</span>"
                         table += "</td>";
                         table += "<td style='display:none;'><span id='lblCPP' class='CPP'> " + SizeId + "</span>"
                         table += "</td>";
                     }
                     table += "</tr>";
                 }
                 else {
                     table += "<tr align='center'><td><b><span id='lblDate' style='cursor:pointer;' class='NoRecord'>Click here to select another accessories</span></b></td></tr>";
                 }
                 table += "</table>";
                 $("#dvSizeRate").html(table);
                 $("#dvBaseSizeRate").css("display", "block");

                 $(".SizeRate").click(function () {
                     //debugger;
                     var SizeId = $(this).parent().next().next().next().find("span").html().trim();
                     var size = $(this).parent().next().find("span").html().trim();

                     $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnSizeId" + "']").val(SizeId);
                     $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnAccessSize" + "']").val(size);

                     //var valuetxt = $(Item).val();
                     valuetxt = $(Item).val() + " (" + size + ")";
                     $(Item).val(valuetxt);
                     $("#dvSizeRate").html("");
                     $("#dvBaseSizeRate").css("display", "none");

                     var RowId;
                     var AccessRow = $(".AccessRow").length;

                     for (var row = 0; row < AccessRow; row++) {
                         if (row < 10)
                             RowId = 'ctl0' + row;
                         else
                             RowId = 'ctl' + row;

                         if (ItemId != RowId) {
                             var AccessName = $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + RowId + "_txtAccessName" + "']").val().trim();

                             if (valuetxt == AccessName) {
                                 $(Item).val('');
                                 return false;
                             }
                         }
                     }

                     // $(Item).focus();
                 });
                 $(".NoRecord").click(function () {
                     //debugger;
                     $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnSizeId" + "']").val(-1);
                     $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnAccessSize" + "']").val('');
                     $(Item).val("");
                     $("#dvSizeRate").html("");
                     $("#dvBaseSizeRate").css("display", "none");
                 });
             }
         }

         function checkAccessories(obj) {
             //debugger;
             var Accessries = $(obj).val().split('(');
             Accessries = Accessries[0].trim();
             var Id = $(obj)[0].id.split("_")[1];
             var SizeId = $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + Id + "_hdnSizeId" + "']").val();

             if (Accessries != '') {
                 //debugger;
                 proxy.invoke("CheckAccessories", { searchValue: Accessries },
                function (result) {
                    //debugger;
                    var AccessriesExist = parseInt(result);
                    if (AccessriesExist == 0) {
                        $(obj).val('');
                        return false;
                    }
                });

                 var ItemId;
                 var AccessRow = $(".AccessRow").length;

                 for (var row = 0; row < AccessRow; row++) {
                     if (row < 10)
                         ItemId = 'ctl0' + row;
                     else
                         ItemId = 'ctl' + row;

                     if (Id != ItemId) {
                         var AccessName = $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnAccessName" + "']").val().trim();
                         var AccessSizeId = $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_hdnSizeId" + "']").val();

                         if ((Accessries == AccessName) && (SizeId == AccessSizeId)) {
                             $(obj).val('');
                             return false;
                         }
                     }
                 }

             }
         }

         function ValidateAccessories() {
             //               debugger
             var ItemId;
             var AccessRow = $(".AccessRow").length;

             for (var row = 0; row < AccessRow; row++) {
                 if (row < 10)
                     ItemId = 'ctl0' + row;
                 else
                     ItemId = 'ctl' + row;

                 var AccessName = $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_txtAccessName" + "']").val()
                 if (AccessName == '') {
                     jQuery.facebox('This Accessories field can not be empty.');
                     $("#<%= dlstAccessoriesPopup.ClientID %> input[id*='" + ItemId + "_txtAccessName" + "']").focus();
                     return false;
                 }
             }
         }

         function ConfirmBox() {
             if (confirm("Are you sure you want to delete?"))
                 return true;
             else return false;
         }

         function ConfirmDialog(message) {
             $('<div></div>').appendTo('body')
                .html('<div><h6>' + message + '?</h6></div>')
                .dialog({
                    modal: true, title: 'Delete message', zIndex: 10000, autoOpen: true,
                    width: 'auto', resizable: false,
                    buttons: {
                        Yes: function () {
                            // $(obj).removeAttr('onclick');                                
                            // $(obj).parents('.Parent').remove();

                            $('body').append('<h1>Confirm Dialog Result: <i>Yes</i></h1>');

                            $(this).dialog("close");
                        },
                        No: function () {
                            $('body').append('<h1>Confirm Dialog Result: <i>No</i></h1>');

                            $(this).dialog("close");
                        }
                    },
                    close: function (event, ui) {
                        $(this).remove();
                    }
                });
         };

         function CallParentPage() {
             self.parent.SubmitPage();
             self.parent.Shadowbox.close();

         }

         function closeAccesButtion() {
             //alert();
             self.parent.Shadowbox.close();
         }
</script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">   
        <ContentTemplate>

          <div id="dvBaseSizeRate" class="modalAcc">
                    <div id="dvSizeRate" class="modal-content">
                    </div>
                    <div style="clear:both"></div>
                </div>
              
                 <div id="dvChildAccessories">
                            <div class="headerAccessories">
                             <span style="position:relative;top:3px;">Accessories Section</span>
                              <span style="float:right; padding:2px 4px; position:relative;top:3px;cursor:pointer" onclick= "closeAccesButtion()" ><%--<img src="../../images/delete.png" />--%>X</span>  
                            </div>
                            <table style="margin:0 auto;top: 30px; position: absolute; left: 18%;">
                            <tr>
                            <td  style="width:180px;">
                             <asp:DataList ID="dlstAccessoriesPopup" 
                                OnItemDataBound="dlstAccessoriesPopup_ItemDataBound" 
                                CssClass="dlstAccessoriesa" RepeatDirection="Vertical" RepeatLayout="Table"  
                                runat="server" ondeletecommand="dlstAccessoriesPopup_DeleteCommand" ItemStyle-CssClass="AccessRow">                                
                                    <ItemTemplate>  
                                     <div class="accessColwidth">
                                         <asp:HiddenField ID="hdnIndex" Value="0" runat="server" />
                                            <asp:HiddenField ID="hdnSeqId" Value='<%# Eval("SeqId") %>' runat="server" />
                                             <asp:HiddenField ID="hdnId" Value='<%# Eval("AccId") %>' runat="server" />
                                            <input type="hidden" id="hdnAccessId" value='<%# Eval("AccessoriesId") %>' runat="server" />
                                            <asp:HiddenField ID="hdnAccessName" Value='<%# Eval("AccessoriesName") %>' runat="server"></asp:HiddenField>
                                            <input type="hidden" id="hdnSizeId" value='<%# Eval("SizeId") %>' runat="server" />
                                          
                                             <asp:HiddenField ID="hdnAccessSize" Value='<%# Eval("Size") %>' runat="server"></asp:HiddenField>                                            
                                            <asp:TextBox ID="txtAccessName" CssClass="txtAccessories_New AccessInput" onblur="checkAccessories(this)" style="float:left;padding-left: 2px; color:Blue;" runat="server"></asp:TextBox>  
                                                 &nbsp;
                                             <span style="float:">
                                             <asp:ImageButton ID="imgbtnDel" ImageUrl="~/images/delete-icon.png" CommandName="Delete" OnClientClick="javascript:return ConfirmBox()" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "SeqId") %>' runat="server" />
                                             </span>
                                             </span> 
                                      </div>
                                    </ItemTemplate> 
                                                                                                
                                    </asp:DataList>
                            </td>
                            <td style="vertical-align: bottom;">
                                     <div class="Adddivwidth">
                                         <asp:ImageButton ID="imgbtnAdd" ImageUrl="~/images/add-butt-white.png" OnClientClick="javascript:return ValidateAccessories()"
                                             runat="server" onclick="imgbtnAdd_Click" />                              
                                     </div> 
                              </td> 
                              <td style="vertical-align: bottom;">
                                    <div>                                         
                                        <asp:Button ID="btnSubmit" CssClass="submit " runat="server" Text="Submit" OnClientClick="javascript:return ValidateAccessories()"
                                            onclick="btnSubmit_Click" />
                                    </div>
                              </td>
                            </tr>
                           </table>
                         </div>
  
   
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


