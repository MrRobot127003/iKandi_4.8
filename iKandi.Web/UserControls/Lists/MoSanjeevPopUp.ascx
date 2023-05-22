<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoSanjeevPopUp.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.MoSanjeevPopUp" %>



<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />

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

    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>

    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>

    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>

    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>

    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>

    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>

 

<script type="text/javascript">



    var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';

    var proxy = new ServiceProxy(serviceUrl);





    function CheckAll(cbId) {

        var chk = document.getElementById(cbId).checked;

        var cbsId = cbId.substring(0, cbId.indexOf('01_CheckHeader'));

        $("input[type=checkbox]:regex(id," + cbsId + ")").each(function () {

            if (this.id != cbId) {

                $(this).attr('checked', chk);

            }

        });

    }

//    function CheckValidation(cbId) {
//        debugger;
//        if (document.getElementById(cbId).checked) {
//            debugger;            
//            var cId = cbId.split("_")[3].substr(3);
//        }
//        else {
//        }
//    }



    function UpdateMoShipping(DelayOrderDetailIds) {
//        debugger;
        var ids = "";

        var IsPCdateChange = 0;


        ids = $("#" + '<%=gdnOrderID.ClientID%>').val();
        //alert(ids);

        var rem = $("#" + '<%=txtremarks.ClientID%>').val();

        var exfactory = $("#" + '<%=txtExFactory.ClientID%>').val();



        if (ids.length < 1) {

            alert('Please select the contract to replicate shipping remarks and exfactory date');
            return;
        }

//        if (exfactory != '') {

//            var r = confirm("Do You Want To change PCD date also!");

//            if (r == true) {

//                IsPCdateChange = 1;
//            }
//        }
        //isBackSlashKey();
        UpdateMoSanjeevRemark(ids, rem, exfactory, IsPCdateChange, DelayOrderDetailIds);
    }





    function UpdateMoSanjeevRemark(ids, rem, exfactory, isPCdateChange, DelayOrderDetailIds) {
//        alert(DelayOrderDetailIds);
//        debugger;
        proxy.invoke("UpdateRemarksSanjeev", { Remarks: rem, Ids: ids, ExFactoryDate: exfactory, IsPcDateChanged: isPCdateChange }, function () {
//            debugger;
//            alert('Remarks have been submitted successfully');
            //window.opener.UpdatePageForSanjeevRemark(DelayOrderDetailIds);
            this.parent.window.close();

        }, onPageError, false, false);

    }



    $(document).ready(function () {

        $('input.date-picker1', '#mcontent').datepicker({ changeYear: true, yearRange: '1900:2020', dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' }).focus(function () { this.blur(); return false; });

    });





    function isTilde(keyCode) {

        //debugger;

        if (keyCode == 192)

            return false;

    }



    function closeMoRemarks() {

        //debugger;
        this.parent.window.close();
        return false;

    }



    

</script>

 <style>
   #MoSanjeevpopup1_gv tr td:first-child
   {
       color:#0000ee;  
    }
 
      #MoSanjeevpopup1_gv tr td:nth-last-child(8)
   {
       color:#0000ee !important;  
    }
 </style>

<style type="text/css">

.ui-widget-content{border:1px solid white !important; background:white !important;}

.ui-datepicker .ui-widget .ui-widget-content .ui-helper-clearfix .ui-corner-all{font-size:12px !important;}

#ui-datepicker-div{font-size:12px !important;}
.form_heading{text-align: center !important;   font-size: 12px !important;    margin-top: 0px !important;    padding-bottom: 0px !important;    border-bottom: 7px solid #000000 !important;    color: #E91677 !important;}

    #btnSubmit
    {
        width: 87px;
    }
    .item_list1 td {
 
    text-transform: capitalize;
}
.blue-text {
    float: left;
}
</style>

<div class="form_box" id="mcontent" style="padding:2px;"> 
      <asp:HiddenField id="gdnOrderID" runat="server" /> 
    <div id="frmHed" class="form_heading" style="color:#fff !important;border-bottom: 0px solid !important; height: 20px !important; text-transform: capitalize; line-height: 20px !important">Remarks</div>

    <table width="100%" cellpadding="1px" cellspacing="0" style="text-transform: capitalize;" class="item_list1">
    <tr>
        <th width="15%">
            <div class="tempClass" style="padding-left:5px;">Style Number :</div>
        </th>
        <td width="220px">
            <div style="width: 100%; overflow: auto  ! important; padding-left:5px;"><asp:Label ID="lblStyleNumber" runat="server" CssClass="label-remarks blue-text" /></div>
        </td>
        <th  width="35%" style="display:none">
            <div class="tempClass" style="padding-left:5px;">Ex Factory Date :</div>
        </th>
        <td width="5%" align="center" style="display:none">
            <div><asp:TextBox ID="txtExFactory" runat="server" style="text-transform:capitalize !important;" CssClass="date-picker1 do-not-disable blue-text"/></div>
        </td>
    </tr>

    <tr>
        <th>
            <div class="tempClass" style="padding-left:5px;">Remarks :</div>
        </th>
        <td valign="top" colspan="3" style="border-bottom: none;">
           <div style="width: 100%; overflow: auto  ! important; padding-left:5px;"><asp:Label ID="lblShowRemark" style="text-transform:capitalize !important;" runat="server" CssClass="label-remarks" /></div>
        </td>
    </tr>

    <tr class="permission-text-remarks">
        <th>Enter Remarks :</th>
        <td colspan="3" style="border:none;">
        <table width="100%" cellpadding="0px" cellspacing="0">
        <tr>
            <td width="73%" style="border-right: none;">&nbsp;<asp:TextBox Columns="80" Rows="5" ID="txtremarks" style="width:98%; height:20px;text-align:left;" onkeydown = "return isTilde(event.keyCode);" class="text-remarks" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td style="border-right: none;" align="right">
            
            
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="submit" onclick="btnSubmit_Click1" />
            </td>
            <td style="border-left: none; text-align:center; padding-right:5px;"><input type="button" onclick="JavaScript:closeMoRemarks()" class="smallclose do-not-disable da_submit_button" value="Close" /></td>
        </tr>
        </table>
        </td>
        
    </tr>
    </table>

    <br />

    <div style="width: 99%; vertical-align: top; overflow: auto; border:0px solid #999999; font-size:11px;" align="center">

       <%-- <fieldset style="margin: 0px; padding: 0px; border: none; width: 95%;">--%>

            <asp:HiddenField ID="hfexFactoryDate" runat="server" />
              
                 

       
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" 
            CssClass="mosan fixed-header item_list1" Width="100%" OnRowDataBound="gv_rowdatabound" >

                <Columns>

                    <asp:BoundField DataField="SerialNumber" HeaderText="Serial No." />

                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                    <asp:BoundField DataField="ContractNumber" HeaderText="Contract No." />

                    <asp:BoundField DataField="Fabric1Detail" HeaderText="Print/Color" />

                    <asp:TemplateField HeaderText="ExFactory">

                        <ItemTemplate>

                            <label style='<%# " width : 140px ! important; font-size:11px; line-height:12px; height:12px; background-color :" + Eval("ExFactoryColor").ToString() %>' class="blue-text"><%# Eval("ExFactoryInString")%></label>

                          

                            <label style="font-size:9px;" ><%# (Eval("PlannedExInString").ToString() == "" ? "" : string.Format("({0})",Eval("PlannedExInString")))%></label>
                            <asp:HiddenField id="hdnexfactDate" runat="server" Value='<%# Eval("ExFactoryInString")%>'/>
                            

                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PCD date">

                        <ItemTemplate>
                            <asp:Label ID="lblPcdDate" runat="server" Text='<%# Eval("PcdDate")%>'></asp:Label>     
                           
                            <asp:HiddenField id="hdnpcdDates" runat="server" Value='<%# Eval("PcdDate")%>'/>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DC Date">

                        <ItemTemplate>

                            <%# Eval("DCInString")%>
                             <asp:HiddenField id="hdnDcdate" runat="server" Value='<%# Eval("DCInString")%>'/>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField DataField="ModeName" HeaderText="Mode" />

                    <asp:TemplateField Visible="true">

                        <HeaderTemplate>

                            <asp:CheckBox ID="CheckHeader" OnClick="JavaScript:CheckAll(this.id);" runat="server" />

                        </HeaderTemplate>

                        <ItemTemplate>

                            <asp:HiddenField ID="hf" runat="server" Value='<%#Bind("OrderId") %>' />

                            <asp:CheckBox ID="cb"  runat="server"  />
                                  
                        </ItemTemplate>

                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
           
       <%-- </fieldset>--%>

    </div>

    <br />

    <div>

       

    </div>

</div>

 

 





