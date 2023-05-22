<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Usermanpowerattendence.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.Usermanpowerattendence" %>
<style type="text/css">
    .font
    {
        font-size:13px;
    }
    .border td{border:1px solid #000000; border-collapse:collapse;}
   
    .submit{
    background-color: White;
    background-image: url(../../App_Themes/ikandi/images/submit.jpg);
    background-repeat: no-repeat;
    width: 105px;
    height: 28px;
    background-position: 0px 0px;
    border: none;
}
.submit:hover{
    background-color: White;
    background-image: url(../../App_Themes/ikandi/images/submit.jpg);
    background-repeat: no-repeat;
    width: 105px;
    height: 28px;
    background-position: 0px -28px;
}
    #tblProductionUnits
    {
        width: 98%;
    }
    .style1
    {
        width: 17px;
    }
    .style2
    {
        height: 18px;
    }
    .table-top td
    {
        text-align:center;
        padding:5px 0px;
    }
    .table-top td input
    {
         width:70% !important;
      text-align:center;

    }
    .worker-typ-top
    {
        color:#666;
      font-size:11px;
      font-weight:bold;
      text-transform:capitalize;
      width:25%;
      text-align:left !important;
    }
    
    
    .rotate{
  color: #000;
    display: block;
    /*Firefox*/
    -moz-transform: rotate(-90deg);
    /*Safari*/
    -webkit-transform: rotate(-90deg);
    /*Opera*/
    -o-transform: rotate(-90deg);-ms-transform: rotate(-90deg);
    /* ie*/
    filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
	color:#405d9a;
	font-weight:bold;
	font-size:15px;
	font-family:arial;
	padding:0px;

	

}

.normal{
	color:#405d9a;
	font-weight:bold;
	font-size:15px;
	font-family:arial;
	padding:0px;
}
   .option
  {
      padding:5px 0px !important;
      width:230px !important; 
      font-size:12px;
      font-family:Verdana;    
  }
</style>
<script type="text/javascript">
    var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';
    var proxy = new ServiceProxy(serviceUrl);

    function numbersonly(elem) {
        //debugger;
        //        var unicode = e.charCode ? e.charCode : e.keyCode
        //        if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
        //            if (unicode < 48 || unicode > 57) //if not a number
        //                alert(1);
        //                e.value = "";
        //                return false //disable key press
        //        }
        //        var elemval = elem.value;
        //        if (elemval != 0) {
        //            if (isNaN(parseInt(elemval)) != "") {
        //                //alert('Please Enter Valid No.')
        //                elem.value = "";
        //                return false;
        //            }
        //            else {
        //                return true;
        //            }
        //        }

    }
    function SaveManpowerdetails(elem) {
        //debugger;
        var UnitType = elem.id;
        var UnitId = elem.id.split('_')[9]
        var ctId = elem.id.split('_')[6].substr(2);
        var WorkerCount = elem.value;

        var WorkforceId = $("#<%= grdmanpowerattendence.ClientID %> input[id*='ct" + ctId + "_hdnFactoryWorkSpaceId" + "']").val();
        var hdnIsEdit = $("#" + '<%=hdnIsEdit.ClientID%>').val();
        var hdnEditDate = $("#" + '<%=hdnEditDate.ClientID%>').val();
        var ProductionId = UnitId;
        //var WorkforceId=Operator
        var LogedInUserId = '<%=this.UserId %>';

        var todayDate = new Date();

        var todayMonth = todayDate.getMonth() + 1;

        var todayDay = todayDate.getDate() - 1;


        var todayYear = todayDate.getFullYear();

        //var todayDateText = todayDay + "/" + todayMonth + "/" + todayYear;

        if (hdnIsEdit != "0") {
            var todayDateText = hdnEditDate;
        }
        else {

            var todayDateText = todayYear + "/" + todayDay + "/" + todayMonth;

        }
        if (WorkerCount == "" || WorkerCount == "0") {
            WorkerCount = "0";
//            alert("Please Enter valid Workercount ");
//            elem.value = elem.defaultValue;
//            return;
        }

        if (isNaN(parseInt(WorkerCount))) {
            WorkerCount = "0";
//            elem.value = elem.defaultValue;
//            return false;
        }
        calcSum(elem);
//        else {
//            calcSum(elem);
//        }

        proxy.invoke("InsertUpdateManpowerWorker", { WorkerCount: WorkerCount, ProductionId: ProductionId, WorkforceId: WorkforceId, id: LogedInUserId, catergoryattdence: 1, ot_date: todayDateText, Workinghours: 8 }, function (result) {
            if (result != -1) {
                // alert('saved successfully!');
            }
            else {
                alert("Budget Not Create On this Date");
                elem.value = "";
            }
        }, onPageError, false, false);


        //calcSum(elem)
    }

    function calcSum(elem) {
        //debugger;
        var Ids = elem.id;
        var cId = Ids.split("_")[6].substr(3);
        var LastId = Ids.split("_")[9];

        var row = elem.parentNode.parentNode;
        var rowIndex = row.rowIndex - 1;

        var C47 = $('.Unitcls' + 3 + "_" + rowIndex).val();
        var C4546 = $('.Unitcls' + 11 + "_" + rowIndex).val();
        var B45 = $('.Unitcls' + 12 + "_" + rowIndex).val();

        if (C47 == "") {
            C47 = 0;
        }
        if (C4546 == "") {
            C4546 = 0;
        }
        if (B45 == "") {
            B45 = 0;
        }
        var calc = (parseFloat(C47) + parseFloat(C4546) + parseFloat(B45));


        $('.BIPLcls' + "_" + rowIndex).html(calc);
    }
    
 </script>
 
<table id="tblProductionUnits" runat="server" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="text-align:left;">
                      <asp:HiddenField ID="hdnIsEdit" runat="server" />
                      <asp:HiddenField ID="hdnEditDate" runat="server" />
                        <asp:HiddenField ID="hdnAttandanceDate" runat="server" />
                     <%-- <asp:DropDownList ID="ddl_daliyattendance" runat="server" CssClass="option" style="text-align:left;" Enabled="false">
                      <asp:ListItem Value="1" Selected="True">Normal Working Hr attendance</asp:ListItem>
                      </asp:DropDownList>--%>
                    </td>
                     <td style="text-align:left;" class="style1">
                          
                    </td>
                </tr>
                <tr> 
                   <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
               
                    <td colspan="3" align="left">

                    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="work-head">
       <tr>
       <td>
                      <asp:Label ID="labtext" runat="server" Text=" Total No. of working hours is 8" style="text-align:left;"></asp:Label>  
                    </td>

                    <td>
                      <asp:Label ID="lblcurrentdate" runat="server"></asp:Label>
                    </td>
                    </tr>
                    </table>
                   </td> 

                </tr>
                <tr> 
                   <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    
                     <td align="left" colspan="3" style="background:#fff;">
                       <asp:GridView ID="grdmanpowerattendence" runat="server" CssClass="font table-top"
                         AutoGenerateColumns="False" Width="100%" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
                         HeaderStyle-Font-Size="13px" OnRowDataBound="grdmanpowerattendence_RowDataBound"
                         Style="border-collapse: collapse; border-spacing: 0px;">
                         <Columns>
                           <asp:TemplateField HeaderText="Staff Dept.">
                             <ItemTemplate>
                               <asp:Label ID="lblStaffDept" Width="100" CssClass="rotate" runat="server" Text='<%#Eval("StaffDept") %>'></asp:Label>
                             </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Factory">
                             <ItemTemplate>
                               <asp:Label ID="lblFactory" runat="server" Text='<%#Eval("WorkerType") %>'></asp:Label>
                               <asp:HiddenField ID="hdnFactoryWorkSpaceId" runat="server" Value='<%#Eval("FactoryWorkSpaceId") %>' />
                             </ItemTemplate>
                             <ItemStyle CssClass="worker-typ-top" />
                           </asp:TemplateField>
                         </Columns>
                       </asp:GridView>
                    
                    </td>

                </tr>
               

                <tr>
                <td colspan="4">
                &nbsp;
                </td>
                </tr>
               
            </table>
