<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master"
    EnableEventValidation="false" CodeBehind="ManageOrders.aspx.cs" Inherits="iKandi.Web.ManageOrders" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Lists/ManageOrderBasicInfo.ascx" TagName="ManageOrderBasicInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="server">
    <%-- <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>--%>
    <%--  <script src="../../js/jQuery.print.js" type="text/javascript"></script>--%>
    <%-- <link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />--%>
    <%--    Gajendra Paging--%>
    <style type="text/css">
        #spinnL
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        input[type='image]
        {
            height:auto;
        }
        option
        {
         margin:0px;
         padding:0px;   
         }
</style>
    <script src="../../js/Calender_new.js" type="text/javascript"></script>
    <script src="../../js/Calender_new2.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Gajendra Paging
        function SpinnShow() {
            //debugger;
            $("#spinnL").css("display", "block");
            $('body').scrollTop($('body')[0].scrollHeight);
        }
        $(function () {
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });
            $(".th1").datepicker({ dateFormat: 'dd/mm/yy' });
            $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });
        });
  
    </script>
    <script type="text/javascript">

        var hdntabvalueClientID = '<%=hdntabvalue.ClientID%>';
        var ddlClientsClientID = '<%=ddlClients.ClientID%>';
        var clientSummaryClientID = '<%=clientSummary.ClientID%>';
        var grdPanel1ClientID = '<%=grdPanel1.ClientID%>';
        var ddlDepartmentClientID = '<%=ddlDepartment.ClientID%>';
        var parentDeptID = '<%=ddlParentDeptID.ClientID%>';

        var isExpanded = false;
        var serviceUrl = '<%=ResolveUrl("~/Webservices/iKandiService.asmx/")%>';
        var proxy = new ServiceProxy(serviceUrl);
        var tabval;
        function setvalue() {
            debugger;
            SpinnShow();
            document.getElementById('<%=hdn_btnSearch.ClientID%>').value = "0";
          
        }

        $(function () {
            $("#hrefPrint").click(function () {
                //debugger;
                // Print the DIV.
                alert('abc');
                alert($('.item_list2'));
                $('.item_list2').print();
                return (false);
            });
        });
        function showHide(prmThis) {
            if (isExpanded == false) {

                $("#" + clientSummaryClientID).show();

                isExpanded = true;
                $(prmThis).html("Collapse");
            }
            else {
                $("#" + clientSummaryClientID).hide();
                isExpanded = false;
                $(prmThis).html("View Client Summary");
            }
        }

        function submitForm() {

            var queryString = $('#' + grdPanel1ClientID, '#main_content').serializeNoViewState();

            if (tabval == "Tab1") {

                $.post('ManageOrders.aspx?callback=savebasicinfo', queryString, function (message) {


                    DoForcePostBack();


                    jQuery.facebox('Data has been saved successfully!');

                });

                return false;
            }

            else if (tabval == "Tab3") {
                return true;

            }

            else if (tabval == "Tab4") {

                $.post('ManageOrders.aspx?callback=savecutting', queryString, function (message) {

                    DoForcePostBack();

                    jQuery.facebox('Data has been saved successfully!');


                });
                return false;
            }

            else if (tabval == "Tab5") {

                $.post('ManageOrders.aspx?callback=savestitching', queryString, function (message) {

                    DoForcePostBack();

                    jQuery.facebox('Data has been saved successfully!');


                });

                return false;
            }

            else if (tabval == "Tab10") {

                $.post('ManageOrders.aspx?callback=saveshipmentoffer', queryString, function (message) {

                    DoForcePostBack();

                    jQuery.facebox('Data has been saved successfully!');


                });

                return false;
            }


        }

        function FromMonthChange() {

        }

        function GotofeedingView() {
            //debugger;
            var RadioCheck = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var year = $('#<%= ddlYear.ClientID %> option:selected').val();
            var WeekFrom = '-1';
            var WeekTo = '-1';
            var BH = $('#<%= ddlBH.ClientID %> option:selected').val();
            var Client = $('#<%= ddlClients.ClientID %> option:selected').val();
            var Status = $('#<%= ddlStatusMode.ClientID %> option:selected').val();
            var StatusModeSequence = $('#<%= ddlStatusModeSequence.ClientID %> option:selected').val();
            var UnitId = $('#<%= ddlUnit.ClientID %> option:selected').val();

            //var url = 'Feeding.aspx?Year=' + year + '&FromWeek=' + WeekFrom + '&ToWeek=' + WeekTo + '&BH=' + BH + '&ClientId=' + Client + '&DateType=' + RadioCheck + '&StatusMode=' + Status + '&StatusModeSequence=' + StatusModeSequence + '&UnitId=' + UnitId + '';
            var url = 'Feeding.aspx';
            window.open(url, '_blank', 'height=400,width=1350,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
            return false;




        }

        function GotoSalesView() {
            //debugger;
            var RadioCheck = $('#<%= ddlDateType.ClientID %> option:selected').val();
            if (RadioCheck == undefined) {
                RadioCheck = '2015,2016';
            }
            var year = $('#<%= ddlYear.ClientID %> option:selected').val();
            if (year == undefined) {
                year = '2015,2016';
            }
            var WeekFrom = '-1';
            var WeekTo = '-1';
            var BH = $('#<%= ddlBH.ClientID %> option:selected').val();
            if (BH == undefined) {
                BH = -1;
            }
            var Client = $('#<%= ddlClients.ClientID %> option:selected').val();
            if (Client == undefined) {
                Client = -1;
            }
            var Status = $('#<%= ddlStatusMode.ClientID %> option:selected').val();
            if (Status == undefined) {
                Status = -1;
            }
            var StatusModeSequence = $('#<%= ddlStatusModeSequence.ClientID %> option:selected').val();
            if (StatusModeSequence == undefined) {
                StatusModeSequence = -1;
            }
            var UnitId = $('#<%= ddlUnit.ClientID %> option:selected').val();
            if (UnitId == undefined) {
                UnitId = -1;
            }
            var AMId = $('#<%= Ddlam.ClientID %> option:selected').val();
            if (AMId == undefined) {
                AMId = -1;
            }
            var ParentDeptID = $('#<%= ddlParentDeptID.ClientID %> option:selected').val();
            if (ParentDeptID == undefined) {
                ParentDeptID = -1;
            }

            var DeptID = $('#<%= ddlDepartment.ClientID %> option:selected').val();
            if (DeptID == undefined) {
                DeptID = -1;
            }


            var ddlSalesReport = $("[id*=ddlSalesReport] option:selected").val();

            if (ddlSalesReport == 0) {
                var url = 'MoSalesView.aspx?Year=' + year + '&FromWeek=' + WeekFrom + '&ToWeek=' + WeekTo + '&BH=' + BH + '&ClientId=' + Client + '&DateType=' + RadioCheck + '&StatusMode=' + Status + '&StatusModeSequence=' + StatusModeSequence + '&UnitId=' + UnitId + '&AMId=' + AMId + '&DeptID=' + DeptID + '&ParentDeptID=' + ParentDeptID + '';
            }
            else {
                var url = 'MoSalesViewBudget.aspx?Year=' + year + '&FromWeek=' + WeekFrom + '&ToWeek=' + WeekTo + '&BH=' + BH + '&ClientId=' + Client + '&DateType=' + RadioCheck + '&StatusMode=' + Status + '&StatusModeSequence=' + StatusModeSequence + '&UnitId=' + UnitId + '&AMId=' + AMId + '&DeptID=' + DeptID + '&ParentDeptID=' + ParentDeptID + '';
            }
            window.open(url, '_blank');

            return false;


        }

        function UpdatePageForSale() {
            //debugger;        
            document.getElementById("<%= btnHidden.ClientID %>").click();
        }

        function UpdatePageForSanjeevRemark(DelayOrderDetailIds) {
            //            debugger;
            //            alert(DelayOrderDetailIds);           
            $('#<%= hdnDelayOrderDetailIds.ClientID %>').val(DelayOrderDetailIds);
            document.getElementById("<%= btnHidden.ClientID %>").click();
        }


        function ClosePageForSale() {
            //debugger;
            //alert('hello');
            proxy.invoke("DeleteSession", { session: '1' }, function (result) {

            }, onPageError, false, false);
            return false;
        }


        function PrintManageOrderPDF() {
            debugger;
            SpinnShow();
            $(".print ").hide();


            var PageSize = 100000;
            var PageIndex = 0;

            var SearchText = $('#<%= txtsearch.ClientID %>').val();
            if (SearchText == undefined) {
                SearchText = "";
            }
            var ClientId = $('#<%= ddlClients.ClientID %> option:selected').val();
            if (ClientId == undefined) {
                ClientId = -1;
            }
            var ClientDeptId = $('#<%= ddlDepartment.ClientID %> option:selected').val();
            if (ClientDeptId == undefined) {
                ClientDeptId = -1;
            }
            var ClientParentDeptId = $('#<%= ddlParentDeptID.ClientID %> option:selected').val();
            if (ClientParentDeptId == undefined) {
                ClientParentDeptId = -1;
            }

            var ParentDeptName = $('#<%= ddlParentDeptID.ClientID %> option:selected').text();
            if (ParentDeptName == undefined) {
                ParentDeptName = "All"
            }

            var Year = $('#<%= ddlYear.ClientID %> option:selected').val();
            if (Year == undefined) {
                Year = '2015,2016';
            }
            var UnitId = $('#<%= ddlUnit.ClientID %> option:selected').val();
            if (UnitId == undefined) {
                UnitId = -1;
            }
            var DateType = $('#<%= ddlDateType.ClientID %> option:selected').val();
            if (DateType == undefined) {
                DateType = 1;
            }
            var StatusMode = $('#<%= ddlStatusMode.ClientID %> option:selected').val();
            if (StatusMode == undefined) {
                StatusMode = 0;
            }
            var StatusModeSequence = $('#<%= ddlStatusModeSequence.ClientID %> option:selected').val();
            if (StatusModeSequence == undefined) {
                StatusModeSequence = 18;
            }
            var OrderBy1 = $('#<%= ddlOrder1.ClientID %> option:selected').val();
            if (OrderBy1 == undefined) {
                OrderBy1 = 4;
            }
            var OrderBy2 = $('#<%= ddlOrder2.ClientID %> option:selected').val();
            if (OrderBy2 == undefined) {
                OrderBy2 = 1;
            }
            var OrderBy3 = $('#<%= ddlOrder3.ClientID %> option:selected').val();
            if (OrderBy3 == undefined) {
                OrderBy3 = 2;
            }
            var OrderBy4 = $('#<%= ddlOrder4.ClientID %> option:selected').val();
            if (OrderBy4 == undefined) {
                OrderBy4 = 3;
            }

            //          
            var FromDate = $('#<%= txtfrom.ClientID %>').val();
            if (FromDate == undefined) {
                FromDate = "";
            }
            var ToDate = $('#<%= txtTo.ClientID %>').val();
            if (ToDate == undefined) {
                ToDate = "";
            }
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            if (BuyingHouseId == undefined) {
                BuyingHouseId = 0;
            }
            var desigId = '<%=this.desigId %>';
            var DeptId = '<%=this.DeptId %>';
            var userID = '<%=this.UserId %>';
            var SalesView = 0;
            var SessionId = '<%=this.SessionId %>';
            var BuyingHouseName = $('#<%= ddlBH.ClientID %> option:selected').text();
            if (BuyingHouseName == undefined) {
                BuyingHouseName = 'ALL';
            }
            var StatusName = $('#<%= ddlStatusMode.ClientID %> option:selected').text();
            if (StatusName == undefined) {
                StatusName = 'ALL';
            }
            var StatusSequenceName = $('#<%= ddlStatusModeSequence.ClientID %> option:selected').text();
            if (StatusSequenceName == undefined) {
                StatusSequenceName = 'APPROVED TO EX';
            }
            var UnitName = $('#<%= ddlUnit.ClientID %> option:selected').text();
            if (UnitName == undefined) {
                UnitName = 'ALL';
            }
            var ClientDeptName = $('#<%= ddlDepartment.ClientID %> option:selected').text();
            if (ClientDeptName == undefined) {
                ClientDeptName = 'ALL';
            }
            
           
            var OrderType = $('#<%= ddlordertype.ClientID %> option:selected').val();
            if (OrderType == undefined) {
                OrderType = '-1';
            }
            //added by abhishekm on 27/6/2017
            // debugger;
            var IsUnShipped = 2;
            if ($('#<%= ChkIsUnShipped.ClientID %>').is(':checked') == true) {
                IsUnShipped = 1;
            }
            //alert(IsUnShipped);
            //end
            var TotalCount = 100;
            var AM = $('#<%= Ddlam.ClientID %> option:selected').val();
            if (AM == undefined) {
                AM = 'ALL';
            }
            var OutHouse = $('#<%= ddlOutHouse.ClientID %> option:selected').val();
            if (OutHouse == undefined) {
                OutHouse = 'ALL';
            }



            debugger;
            proxy.invoke("GenerateManageOrderReport", { PageSize: PageSize, PageIndex: PageIndex, SearchText: SearchText, ClientId: ClientId, Year: Year, UnitId: UnitId, DateType: DateType, StatusMode: StatusMode, StatusModeSequence: StatusModeSequence, OrderBy1: OrderBy1, OrderBy2: OrderBy2, OrderBy3: OrderBy3, OrderBy4: OrderBy4, FromDate: FromDate, ToDate: ToDate, BuyingHouseId: BuyingHouseId, desigId: desigId, DeptId: DeptId, UserId: userID, SalesView: SalesView, SessionId: SessionId, BuyingHouseName: BuyingHouseName, StatusName: StatusName, StatusSequenceName: StatusSequenceName, UnitName: UnitName, ClientDeptId: ClientDeptId, ClientDeptName: ClientDeptName, ordertpye: OrderType, IsUnshipped: IsUnShipped, TotalCount: TotalCount, AM: AM, OutHouse: OutHouse, ClientParentDeptId: ClientParentDeptId, ParentDeptName: ParentDeptName }, function (result) {
                //debugger;
                if ($.trim(result) == '')
                    jQuery.facebox("Some error occured on the server, please try again later.");
                else {
                    window.open("/uploads/temp/" + result);
                    $("#spinnL").css("display", "none");
                    $(".print").show();
                }
            });

            return false;
        }
        //Added Abhishek 23/4/2015 for ajax BuyingHouse Bind
        function BindddlBuyingHouse() {
            //alert("dfd");
            debugger;

            $('#<%= ddlDepartment.ClientID %>').empty();
            var ddlDateType = '#<%= ddlDateType.ClientID %>';
            var ddlBH = '#<%= ddlBH.ClientID %>';
            var Ddlam = '#<%= Ddlam.ClientID %>';
            var Ddlamselsected = $('#<%= Ddlam.ClientID %> option:selected').val();
            var ddlClients = '#<%= ddlClients.ClientID %>';
            var ddlDepartment = '#<%= ddlDepartment.ClientID %>';
            var ddlParentDeptID = '#<%= ddlParentDeptID.ClientID %>';
            var ddlYear = '#<%= ddlYear.ClientID %>';
            var UcompanyId = '<%=this.UcompanyId %>';
            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var ddlYear_text = $('#<%= ddlYear.ClientID %> option:selected').text();
            var LogedInUserId = '<%=this.UserId %>';
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
            var IsClient_ = '<%=this.IsClient_ %>';
            var ClientId_ = '<%=this.ClientId %>';
            var IsClientDept_ = '<%=this.IsClientDept_ %>';

            $('#<%= ddlBH.ClientID %>').empty();
            //            $('#<%= ddlBH.ClientID %>').append($("<option></option>").val('-1').html('ALL'));
            proxy.invoke("GetBuyingHouselistById", { UserComapanyId: UcompanyId, ddlDateType: ddlDateTypeSelected_Val, ddlYear: ddlYear_text }, function (result) {

                //debugger;
                // var Result = result.d;
                $.each(result, function (key, value) {
                    //debugger;
                    //$('#<%= ddlBH.ClientID %>').append($('<option></option>').val(this.ID).html(this.CompanyName));

                    $('#<%= ddlBH.ClientID %>').append($("<option></option>").val(value.BuyingHouseID).html(value.CompanyName));

                });

            });
            $('#<%= ddlClients.ClientID %>').empty();
            //            $('#<%= ddlClients.ClientID %>').append($("<option></option>").val('0').html('ALL'));
            proxy.invoke("GetClientDetailslist", { BuyingHouseId: BuyingHouseId, ClientId: ClientId_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, UserID: LogedInUserId, AM: Ddlamselsected }, function (result) {

                $.each(result, function (key, value) {

                    $('#<%= ddlClients.ClientID %>').append($("<option></option>").val(value.ClientID).html(value.CompanyName));

                });

            });
            $('#<%= ddlParentDeptID.ClientID %>').empty();
            $('#<%= ddlDepartment.ClientID %>').empty();
            Clientddlselectedvalue = "-1";
            proxy.invoke("GetDepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: -1, ParentDepartmentID: -1 }, function (result) {

                $.each(result, function (key, value) {
                    $('#<%= ddlDepartment.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));

                });

            });
            proxy.invoke("Get_Parent_DepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: -1 }, function (result) {

                $.each(result, function (key, value) {
                    $('#<%= ddlParentDeptID.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));

                });

            });

            //   $('#<%= Ddlam.ClientID %>').empty();
            proxy.invoke("GetAMlist", { DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text }, function (result) {

                $.each(result, function (key, value) {

                    $('#<%= Ddlam.ClientID %>').append($("<option></option>").val(value.ID).html(value.UserName));

                });

            });


        }
        function BindAccountManagerBind() {
            //alert("dfd");


            $('#<%= ddlDepartment.ClientID %>').empty();
            var ddlDateType = '#<%= ddlDateType.ClientID %>';
            var ddlBH = '#<%= ddlBH.ClientID %>';
            var Ddlam = '#<%= Ddlam.ClientID %>';
            var ddlClients = '#<%= ddlClients.ClientID %>';
            var ddlDepartment = '#<%= ddlDepartment.ClientID %>';
            var ddlYear = '#<%= ddlYear.ClientID %>';
            var UcompanyId = '<%=this.UcompanyId %>';
            var DdlamSelected_Val = $('#<%= Ddlam.ClientID %> option:selected').val();
            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var ddlYear_text = $('#<%= ddlYear.ClientID %> option:selected').text();
            var LogedInUserId = '<%=this.UserId %>';
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
            var IsClient_ = '<%=this.IsClient_ %>';
            var ClientId_ = '<%=this.ClientId %>';
            var IsClientDept_ = '<%=this.IsClientDept_ %>';

            $('#<%= ddlBH.ClientID %>').empty();
            //            $('#<%= ddlBH.ClientID %>').append($("<option></option>").val('-1').html('ALL'));
            proxy.invoke("GetBuyingHouselistById_ForAM", { UserComapanyId: UcompanyId, ddlDateType: ddlDateTypeSelected_Val, ddlYear: ddlYear_text, Ddlam: DdlamSelected_Val }, function (result) {

                //debugger;
                // var Result = result.d;
                $.each(result, function (key, value) {
                    //debugger;
                    //$('#<%= ddlBH.ClientID %>').append($('<option></option>').val(this.ID).html(this.CompanyName));

                    $('#<%= ddlBH.ClientID %>').append($("<option></option>").val(value.BuyingHouseID).html(value.CompanyName));

                });
                $('#<%= hdnBH.ClientID %>').val(-1);


            });
            $('#<%= ddlClients.ClientID %>').empty();
            //            $('#<%= ddlClients.ClientID %>').append($("<option></option>").val('0').html('ALL'));
            proxy.invoke("GetClientDetailslist_ForAM", { BuyingHouseId: BuyingHouseId, ClientId: ClientId_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, UserID: LogedInUserId, Ddlam: DdlamSelected_Val }, function (result) {
                $.each(result, function (key, value) {

                    $('#<%= ddlClients.ClientID %>').append($("<option></option>").val(value.ClientID).html(value.CompanyName));


                });
                $('#<%= hdnClientId.ClientID %>').val(-1);

            });

            $('#<%= ddlParentDeptID.ClientID %>').empty();
            $('#<%= ddlDepartment.ClientID %>').empty();
            Clientddlselectedvalue = "-1";
            proxy.invoke("GetDepartmentDetailslist_ForAM", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, Ddlam: DdlamSelected_Val }, function (result) {

                $.each(result, function (key, value) {
                    $('#<%= ddlParentDeptID.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                    $('#<%= ddlDepartment.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));

                });
                $('#<%= hdnParentDepartment.ClientID %>').val(-1);
                $('#<%= hdnDDLDepartment.ClientID %>').val(-1);
                

            });




        }

        function BindClient() {
            //alert("dfd");
            //debugger;
            var ddlDateType = '#<%= ddlDateType.ClientID %>';
            var Ddlam = '#<%= Ddlam.ClientID %>';
            var ddlBH = '#<%= ddlBH.ClientID %>';
            var ddlClients = '#<%= ddlClients.ClientID %>';
            var ddlDepartment = '#<%= ddlDepartment.ClientID %>';
            var ddlYear = '#<%= ddlYear.ClientID %>';
            var UcompanyId = '<%=this.UcompanyId %>';
            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var DdlamSelected_Val = $('#<%= Ddlam.ClientID %> option:selected').val();
            var ddlYear_text = $('#<%= ddlYear.ClientID %> option:selected').text();
            var LogedInUserId = '<%=this.UserId %>';
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
            var IsClient_ = '<%=this.IsClient_ %>';
            var IsClientDept_ = '<%=this.IsClientDept_ %>';
            var ClientId_ = '<%=this.ClientId %>';
            $('#<%= ddlClients.ClientID %>').empty();

            //            $('#<%= ddlClients.ClientID %>').append($("<option></option>").val('0').html('ALL'));
            proxy.invoke("GetClientDetailslist", { BuyingHouseId: BuyingHouseId, ClientId: ClientId_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, UserID: LogedInUserId, AM: DdlamSelected_Val }, function (result) {
                $.each(result, function (key, value) {

                    $('#<%= ddlClients.ClientID %>').append($("<option></option>").val(value.ClientID).html(value.CompanyName));
                    $('#<%= hdnClientId.ClientID %>').val(-1);
                });

            });

            $('#<%= ddlParentDeptID.ClientID %>').empty();
            Clientddlselectedvalue = "-1";
            $('#<%= ddlDepartment.ClientID %>').empty();
            Clientddlselectedvalue = "-1";

            proxy.invoke("Get_Parent_DepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: DdlamSelected_Val }, function (result) {
                $.each(result, function (key, value) {
                    $('#<%= ddlParentDeptID.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                    $('#<%= ddlDepartment.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                    $('#<%= hdnParentDepartment.ClientID %>').val(-1);
                    $('#<%= hdnDDLDepartment.ClientID %>').val(-1);
                });
            });

            //            $('#<%= ddlDepartment.ClientID %>').empty();
            //            var newOption = $('<option value="-1">-ALL-</option>');
            //            $('#<%= ddlDepartment.ClientID %>').append(newOption);
            //            $('#<%= ddlDepartment.ClientID %>').trigger("chosen:updated");
        }





        function BindDepartmentDDl() {
            //debugger;
            var ddlDateType = '#<%= ddlDateType.ClientID %>';
            var ddlBH = '#<%= ddlBH.ClientID %>';
            var ddlClients = '#<%= ddlClients.ClientID %>';
            var Ddlam = '#<%= Ddlam.ClientID %>';
            var ClientParentddlselectedvalue = $('#<%= ddlParentDeptID.ClientID %> option:selected').val();
            var ddlDepartment = '#<%= ddlDepartment.ClientID %>';
            var ddlYear = '#<%= ddlYear.ClientID %>';
            var UcompanyId = '<%=this.UcompanyId %>';
            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var ddlYear_text = $('#<%= ddlYear.ClientID %> option:selected').text();
            var LogedInUserId = '<%=this.UserId %>';
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            var AMddlselectedvalue = $('#<%= Ddlam.ClientID %> option:selected').val();
            var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
            var IsClient_ = '<%=this.IsClient_ %>';
            var IsClientDept_ = '<%=this.IsClientDept_ %>';
            $('#<%= hdnClientId.ClientID %>').val(Clientddlselectedvalue);

            $('#<%= ddlDepartment.ClientID %>').empty();
            proxy.invoke("GetDepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: AMddlselectedvalue, ParentDepartmentID: ClientParentddlselectedvalue }, function (result) {
                $.each(result, function (key, value) {
                    $('#<%= ddlDepartment.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                    $("#" + ddlDepartmentClientID).val($('#<%= hdnDDLDepartment.ClientID %>').val());
                    $('#<%= hdnDDLDepartment.ClientID %>').val(-1);

                });

            });



        }
        function BindParentDepartmentDDl() {
            debugger;
            var ddlDateType = '#<%= ddlDateType.ClientID %>';
            var ddlBH = '#<%= ddlBH.ClientID %>';
            var ddlClients = '#<%= ddlClients.ClientID %>';
            var Ddlam = '#<%= Ddlam.ClientID %>';
            var ddlParentDeptID = '#<%= ddlParentDeptID.ClientID %>';
            var ddlYear = '#<%= ddlYear.ClientID %>';
            var UcompanyId = '<%=this.UcompanyId %>';
            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var ddlYear_text = $('#<%= ddlYear.ClientID %> option:selected').text();
            var LogedInUserId = '<%=this.UserId %>';
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            var AMddlselectedvalue = $('#<%= Ddlam.ClientID %> option:selected').val();
            var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
            var IsClient_ = '<%=this.IsClient_ %>';
            var IsClientDept_ = '<%=this.IsClientDept_ %>';
            $('#<%= hdnClientId.ClientID %>').val(Clientddlselectedvalue);

            $('#<%= ddlParentDeptID.ClientID %>').empty();
            $('#<%= ddlDepartment.ClientID %>').empty();
            proxy.invoke("Get_Parent_DepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: AMddlselectedvalue }, function (result) {
                $.each(result, function (key, value) {
                    $('#<%= ddlParentDeptID.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                    $('#<%= hdnParentDepartment.ClientID %>').val(-1);
//                    $("#" + parentDeptID).val($('#<%= hdnParentDepartment.ClientID %>').val());
                    //  var abc = $("#" + parentDeptID).val($('#<%= hdnParentDepartment.ClientID %>').val());
                    //                    $('#<%= hdnParentDepartment.ClientID %>').val(-1);

                });

            });


            proxy.invoke("GetDepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: AMddlselectedvalue, ParentDepartmentID: $('#<%= hdnParentDepartment.ClientID %>').val() }, function (result) {
                $.each(result, function (key, value) {

                    $('#<%= ddlDepartment.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                    $('#<%= hdnDDLDepartment.ClientID %>').val(-1);
                    //                    $('#<%= hdnDDLDepartment.ClientID %>').val(-1);
                });

            });



        }

        //END
        function functionNotRest(eval) {
            //debugger;
            var ddl_departid = $('#<%= ddlDepartment.ClientID %> option:selected').val();
            var ddl_departName = $('#<%= ddlDepartment.ClientID %> option:selected').html();
            $('#<%= hdnDDLDepartment.ClientID %>').val(ddl_departid);
            $('#<%= hdnDeprtName.ClientID %>').val(ddl_departName);
        }
        function functionNotRestForParent(eval) {
            //debugger;
            var ddl_Parentdepartid = $('#<%= ddlParentDeptID.ClientID %> option:selected').val();
            var ddl_ParentdepartName = $('#<%= ddlParentDeptID.ClientID %> option:selected').html();
            $('#<%= hdnParentDepartment.ClientID %>').val(ddl_Parentdepartid);
            $('#<%= hdnParentDeprtName.ClientID %>').val(ddl_ParentdepartName);
            BindDepartmentDDl();
        }


        function BindClientFromPage() {
            //alert("dfd");
            //debugger;
            var ddlDateType = '#<%= ddlDateType.ClientID %>';
            var ddlBH = '#<%= ddlBH.ClientID %>';
            var Ddlam = '#<%= Ddlam.ClientID %>';
            var ddlClients = '#<%= ddlClients.ClientID %>';
            var ddlDepartment = '#<%= ddlDepartment.ClientID %>';
            var ddlYear = '#<%= ddlYear.ClientID %>';
            var UcompanyId = '<%=this.UcompanyId %>';
            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var ddlYear_text = $('#<%= ddlYear.ClientID %> option:selected').text();
            var LogedInUserId = '<%=this.UserId %>';
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
            var DdlamSelected_Val = $('#<%= Ddlam.ClientID %> option:selected').val();
            var IsClient_ = '<%=this.IsClient_ %>';
            var IsClientDept_ = '<%=this.IsClientDept_ %>';
            var ClientId_ = '<%=this.ClientId %>';
            $('#<%= ddlClients.ClientID %>').empty();

            proxy.invoke("GetClientDetailslist", { BuyingHouseId: BuyingHouseId, ClientId: ClientId_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, UserID: LogedInUserId, AM: DdlamSelected_Val }, function (result) {
                $.each(result, function (key, value) {
                    //debugger;

                    $('#<%= ddlClients.ClientID %>').append($("<option></option>").val(value.ClientID).html(value.CompanyName));
                });
                $("#" + ddlClientsClientID).val($('#<%= hdnClientId.ClientID %>').val());
                 BindDepartmentDDlFromPage();
                //BindParentDepartmentDDl();
            });

        }

        function removetext(obj) {
            var CID = obj;
            if (CID == 'txtfrom') {
                $('#<%= txtfrom.ClientID %>').val('');
            }
            if (CID == 'txtTo') {
                $('#<%= txtTo.ClientID %>').val('');
            }

        }

        //Added by abhishek on 7/6/2015 for reset 'from' and 'to' date 
        function showDatecancelbutton(obj) {
            var C_ID = obj;
            if (C_ID == 'txtfrom') {

                $('#imgfrom').css('visibility', 'visible');


            }
            if (C_ID == 'txtTo') {

                $('#imgto').css('visibility', 'visible');


            }

        }

        function BindDepartmentDDlFromPage() {
            debugger;
            var ddlDateType = '#<%= ddlDateType.ClientID %>';
            var ddlBH = '#<%= ddlBH.ClientID %>';
            var ddlClients = '#<%= ddlClients.ClientID %>';
            var Ddlam = '#<%= Ddlam.ClientID %>';
            var ddlParentDeptID = '#<%= ddlParentDeptID.ClientID %>';
            var ddlDepartment = '#<%= ddlDepartment.ClientID %>';
            var ddlYear = '#<%= ddlYear.ClientID %>';
            var AMddlselectedvalue = $('#<%= Ddlam.ClientID %> option:selected').val();
            var UcompanyId = '<%=this.UcompanyId %>';
            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
            var ddlYear_text = $('#<%= ddlYear.ClientID %> option:selected').text();
            var LogedInUserId = '<%=this.UserId %>';
            var BuyingHouseId = $('#<%= ddlBH.ClientID %> option:selected').val();
            var Clientddlselectedvalue = $('#<%= ddlClients.ClientID %> option:selected').val();
            var DdlamSelected_Val = $('#<%= Ddlam.ClientID %> option:selected').val();
            var IsClient_ = '<%=this.IsClient_ %>';
            var IsClientDept_ = '<%=this.IsClientDept_ %>';

            $('#<%= ddlParentDeptID.ClientID %>').empty();
            $('#<%= ddlDepartment.ClientID %>').empty();

            proxy.invoke("Get_Parent_DepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: AMddlselectedvalue }, function (result) {
                $.each(result, function (key, value) {
                    //debugger;
                    $('#<%= ddlParentDeptID.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                });
                //debugger;
                $("#" + parentDeptID).val($('#<%= hdnParentDepartment.ClientID %>').val());
            });

            proxy.invoke("GetDepartmentDetailslist", { intID: Clientddlselectedvalue, UserID: LogedInUserId, IsClient: IsClient_, IsClientDept: IsClientDept_, DateType: ddlDateTypeSelected_Val, YearRange: ddlYear_text, AM: AMddlselectedvalue, ParentDepartmentID: $('#<%= hdnParentDepartment.ClientID %>').val() }, function (result) {
                $.each(result, function (key, value) {

                    $('#<%= ddlDepartment.ClientID %>').append($("<option></option>").val(value.DepartmentID).html(value.Name));
                
                    //                    $('#<%= hdnDDLDepartment.ClientID %>').val(-1);
                });
                $("#" + ddlDepartmentClientID).val($('#<%= hdnDDLDepartment.ClientID %>').val());
            });

        }   
        //        $(function () {
        //            var ddlDateTypeSelected_Val = $('#<%= ddlDateType.ClientID %> option:selected').val();
        //            var year = $('#<%= ddlYear.ClientID %> option:selected').val();
        //            var AutoCompleteStr = ddlDateTypeSelected_Val + '-' + year;
        //            //debugger;
        //            $("input[type=text].costing-MO").autocomplete("/Webservices/iKandiService.asmx/SerialNumber",
        //             { dataType: "xml", datakey: "string", max: AutoCompleteStr, "width": "220px" });

        //            $("input[type=text].costing-MO", "#main_content").result(function () {

        //                var p = $(this).val().split('-');
        //                $(this).val(p[0]);

        //            });

        //        });

        
    </script>
    <style type="text/css">
        .radio-but label
        {
            color: #000 !important;
        }
        .radio-but select
        {
            text-transform: none !important;
        }
        .divClientSummaryLink td
        {
            border-style: none !important;
            border-color: transparent !important;
        }
        
        /*--------------------------prabhaker-5-Oct---------*/
        select
        {
            text-transform: capitalize !important;
        }
        /*--------------------------prabhaker-5-Oct---------*/
        .costing-MO
        {
            border: 2px solid #ffdacc;
            height: 10px;
            margin: 2px 0 2px 2px;
            outline: 0;
            padding: 3px 5px;
            width: 183px;
            font-size: 11px;
        }
        .tooltip
        {
            display: none;
            position: absolute;
            border: 1px solid #333;
            background-color: #707070;
            border-radius: 5px;
            padding: 10px;
            color: #fff;
            font-size: 12px Arial;
        }
        .form_box
        {
            margin-bottom: 5px !important;
        }
    </style>
    <%--abhishek 21/4/2016--%>
    <%--<script type="text/javascript">
       $(document).ready(function () {
           // Tooltip only Text
           $('.masterTooltip').hover(function () {
               // Hover over code
               var title = $(this).attr('title');
               $(this).data('tipText', title).removeAttr('title');
               $('<p class="tooltip"></p>')
        .text(title)
        .appendTo('body')
        .fadeIn('slow');
           }, function () {
               // Hover out code
               $(this).attr('title', $(this).data('tipText'));
               $('.tooltip').remove();
           }).mousemove(function (e) {
               var mousex = e.pageX + 20; //Get X coordinates
               var mousey = e.pageY + 10; //Get Y coordinates
               $('.tooltip')
        .css({ top: mousey, left: mousex })
           });
       });
</script>--%>
    <div id="spinnL">
    </div>
    <div class="grid_heading">
    </div>
    <div id="divClientSummaryLink" runat="server" visible="true" class="divClientSummaryLink">
        <table border="0" cellpadding="0" cellspacing="0" style="font-size: 9px ! important;
            padding-bottom: 0px; color: gray; width: 1060px">
            <tr>
                <td style="border: none !important; width: 40px;">
                    <input type="hidden" runat="server" class="do-not-disable" id="hdntabvalue" />
                    <asp:Label ID="lablsearch" Text="Search" runat="server"></asp:Label>
                </td>
                <td style="border: none !important; width: 70px;">
                    <input type="text" id="txtsearch" style="width: 95px ! important; color: #000; padding: 2px 5px;"
                        class="costing-MO do-not-disable" runat="server" maxlength="60" />
                </td>
                <td style="border: none !important; width: 95px;">
                    <asp:DropDownList ID="ddlDateType" runat="server" CssClass="do-not-disable mo_dropdown_style1"
                        onchange="javascript:BindddlBuyingHouse('');" Style="width: 90px!important">
                        <asp:ListItem Text="ExFact." Value="1"></asp:ListItem>
                        <asp:ListItem Text="DC." Value="2"></asp:ListItem>
                        <asp:ListItem Text="OrderDate." Value="3"></asp:ListItem>
                         <asp:ListItem Text="InvoiceDate." Value="4"></asp:ListItem>
                          <asp:ListItem Text="Invoice&DC." Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border: none !important; width: 30px">
                    <asp:Label ID="lblYear" Text="Year" runat="server"></asp:Label>
                </td>
                <td style="border: none !important; width: 80px;">
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="do-not-disable mo_dropdown_style1"
                        Style="width: 70px!important" onchange="javascript:BindddlBuyingHouse('');">
                    </asp:DropDownList>
                </td>
                <td style="border: none !important; width: 30px;">
                    <asp:Label ID="lblfrom" Text="From" runat="server"></asp:Label>
                </td>
                <td style="border: none !important; width: 70px;">
                    <input type="text" id="txtfrom" onchange="showDatecancelbutton('txtfrom');return false"
                        style="width: 70px ! important;" class="th" runat="server" />
                </td>
                <td style="border: none !important; width: 20px;">
                    <input type="image" id="imgfrom" src="../../App_Themes/ikandi/images1/delete1.png"
                        title="clear from Date" onclick="removetext('txtfrom');return false" />
                </td>
                <td style="border: none !important; width: 20px;">
                    <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>
                </td>
                <td style="border: none !important; width: 70px;">
                    <input type="text" id="txtTo" onchange="showDatecancelbutton('txtTo');return false"
                        style="width: 70px ! important;" class="th" runat="server" />
                </td>
                <td style="border: none !important; width: 30px;">
                    <input type="image" id="imgto" src="../../App_Themes/ikandi/images1/delete1.png"
                        title="clear to Date" onclick="removetext('txtTo');return false" />
                </td>
                <td align="left" style="width: 100px; font-size: 11px; text-transform: capitalize;">
                    <a href="javascript:void(0)" id="SalesReport" onclick="GotoSalesView()">View Sales Report</a>
                </td>
                <td style="width: 100px">
                    AM &nbsp;
                    <asp:DropDownList ID="Ddlam" runat="server" onchange="javascript:BindAccountManagerBind('');"
                        CssClass="do-not-disable mo_dropdown_style1" Style="width: 70px !important;"
                        Height="18px" Font-Size="11px">
                    </asp:DropDownList>
                </td>
                <td align="left" style="text-transform: none; color: #000 !important; padding-left: 5px;
                    width: 100px;" class="radio-but">
                    <asp:DropDownList ID="ddlSalesReport" runat="server" Height="18px" Font-Size="11px">
                        <asp:ListItem Text="Without Factory Detail" Value="0"></asp:ListItem>
                        <asp:ListItem Text="With Factory Detail" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left" style="text-transform: none; color: #000 !important; padding-left: 5px;
                    width: 100px; color: gray;">
                    &nbsp;<div style="color: Gray; float: left; width: auto; margin-top: 3px;">
                        Unshipped
                    </div>
                    <asp:CheckBox ID="ChkIsUnShipped" runat="server" Checked="false" />
                </td>
            </tr>
        </table>
    </div>
    <div id="search">
        <asp:HiddenField ID="hdnSelectFilter" runat="server" Value="" />
        <asp:HiddenField ID="hdnSales" Value="0" runat="server" />
        <table border="0" cellpadding="0" cellspacing="0" class='<%=(hdnSelectFilter.Value == "1") ? "hide_me " : ""%>'
            width="1552px">
            <tr>
                <td align="left" colspan="2" style='padding-right: 10px; border: none !important;'>
                    <table width="1300px" cellspacing="0" style="font-size: 9px ! important; padding-bottom: 0px;
                        color: gray;">
                        <tr>
                            <td style="border: none !important; width: 80px;">
                                <asp:Label ID="Label1" runat="server" Text="Order Type"></asp:Label>
                            </td>
                            <td style="border: none !important; width: 100px;">
                                <asp:DropDownList ID="ddlordertype" runat="server" CssClass="do-not-disable mo_dropdown_style1"
                                    Style="width: 100px!important">
                                    <asp:ListItem Text="ALL" Value="-1" Selected="True">
                            
                                    </asp:ListItem>
                                    <asp:ListItem Text="BIPL" Value="1">
                                        
                                    </asp:ListItem>
                                    <%-- Commented by ravi on dated 21 june 2017
                                        <asp:ListItem Text="Kasuka through BIPL" Value="2">
                                       
                                        </asp:ListItem>--%>
                                    <asp:ListItem Text="Kasuka" Value="3">
                            
                                    </asp:ListItem>
                                    <asp:ListItem Text="Value Added Style" Value="4">
                            
                                    </asp:ListItem>
                                    <asp:ListItem Text="Ramms" Value="5">
                            
                                    </asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnordertype" Value="-1" runat="server" />
                            </td>
                            <td style="border: none !important; width: 80px;">
                                <asp:Label ID="lblBuyinghouse" runat="server" Text="B.H"></asp:Label>
                            </td>
                            <td style="border: none !important; width: 110px;">
                                <asp:DropDownList ID="ddlBH" runat="server" CssClass="do-not-disable mo_dropdown_style1"
                                    onchange="javascript:BindClient('');" Style="width: 100px!important">
                                </asp:DropDownList>
                            </td>
                            <td class="style1" style="border: none !important; width: 30px;">
                                <asp:Label ID="lblClient" runat="server" Text="Client"></asp:Label>
                            </td>
                            <td style="border: none !important; width: 115px;">
                                <asp:DropDownList ID="ddlClients" runat="server" onchange="javascript:BindParentDepartmentDDl('');"
                                    CssClass="do-not-disable mo_dropdown_style1" Style="width: 110px!important">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnClientId" Value="-1" runat="server" />
                                <asp:HiddenField ID="hdnBH" Value="-1" runat="server" />
                            </td>
                            <td class="style1" style="border: none !important;">
                                <asp:Label ID="lblDept" runat="server" Text="ParentDept."></asp:Label>
                            </td>
                            <td style="border: none !important; width: 70px;">
                                <asp:DropDownList ID="ddlParentDeptID" runat="server" Style="width: 65px!important"
                                    onchange="javascript:functionNotRestForParent(this);" CssClass="do-not-disable mo_dropdown_style1">
                                    <asp:ListItem Value="-1">All</asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnParentDepartment" Value="-1" runat="server" />
                                <asp:HiddenField ID="hdnParentDeprtName" Value="" runat="server" />
                            </td>
                            <td class="style1" style="border: none !important;">
                                <asp:Label ID="Label2" runat="server" Text="Dept."></asp:Label>
                            </td>
                            <td style="border: none !important; width: 90px;">
                                <asp:DropDownList ID="ddlDepartment" runat="server" Style="width: 85px!important"
                                    onchange="javascript:functionNotRest(this);" CssClass="do-not-disable mo_dropdown_style1">
                                    <asp:ListItem Value="-1">All</asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnDDLDepartment" Value="-1" runat="server" />
                                <asp:HiddenField ID="hdnDeprtName" Value="" runat="server" />
                            </td>
                            <td style="border: none !important; width: 30px;">
                                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                            </td>
                            <td style="border: none !important; width: 150px;">
                                <asp:DropDownList ID="ddlStatusMode" runat="server" CssClass="do-not-disable mo_dropdown_style2"
                                    Style="width: 140px">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnStatusMode" Value="-1" runat="server" />
                                <asp:HiddenField ID="hdnStatusModeTo" Value="-1" runat="server" />
                            </td>
                            <td style="border: none !important; width: 30px;">
                                <asp:Label ID="lblUpto" runat="server" Text="Upto"></asp:Label>
                            </td>
                            <td style="border: none !important; width: 150px;">
                                <asp:DropDownList ID="ddlStatusModeSequence" runat="server" CssClass="do-not-disable mo_dropdown_style2"
                                    Width="140px">
                                </asp:DropDownList>
                            </td>
                            <td style="border: none !important; width: 30px;">
                                <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label>
                            </td>
                            <td style="border: none !important; width: 110px;">
                                <asp:DropDownList ID="ddlUnit" runat="server" CssClass="do-not-disable mo_dropdown_style1"
                                    Style="width: 100px;">
                                </asp:DropDownList>
                            </td>
                            <td style="border: none !important; width: 140px;">
                                Alloc.
                                <asp:DropDownList ID="ddlOutHouse" runat="server" CssClass="do-not-disable mo_dropdown_style1"
                                    Style="width: 55px !important;">
                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="N.D." Value="1"></asp:ListItem>
                                    <asp:ListItem Text="I.H." Value="2"></asp:ListItem>
                                    <asp:ListItem Text="O.H." Value="3"></asp:ListItem>
                                    <asp:ListItem Text="I.H. & O.H." Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="border: 0px !important;">
                                <asp:Button ID="btn_search" OnClientClick="javascript:return setvalue();" OnClick="btn_search_Click"
                                    runat="server" BorderWidth="0" CssClass="go" Text="Search" />
                                <asp:HiddenField ID="hdn_btnSearch" Value="2" runat="server" />
                                <asp:Button ID="btnHidden" Style="display: none;" runat="server" Text="" OnClick="btnHidden_Click" />
                                <asp:HiddenField ID="hdnDelayOrderDetailIds" Value="" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="hide_me" id="clientSummary" runat="server">
    </div>
    <div id="tabs" style="border: none !important;" class="ui-tabs ui-widget ui-corner-all">
        <div style="display: none;">
            <ul class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all">
                <li id="tabMerch" class="tab ui-corner-top ui-state-default" runat="server">
                    <asp:LinkButton ID="lnkBtnTab" runat="server" OnCommand="lnkBtnTab_Click" CommandName="Tab1"
                        Text="Merchandising" CssClass="do-not-disable"></asp:LinkButton></li>
            </ul>
        </div>
        <div id="tabs-1" class="ui-corner-bottom">
            <div id="grdPanel1" runat="server">
                <uc1:ManageOrderBasicInfo ID="mb" runat="server" Visible="false" />
            </div>
            <asp:Button CssClass="submit" ID="btn_Submit" runat="server" OnClick="btn_Submit_Click"
                Visible="false" OnClientClick="return submitForm()" />
        </div>
    </div>
    <div id="links" class="hide_me">
        <div class="form_box item_list">
            <div class="form_heading">
                Links</div>
            <br />
            <a href="/Internal/Sales/Order.aspx" target="OrderForm" title="CLICK TO VIEW ORDER FORM"
                class="hyp">Order Form</a><br />
            <a href="/Internal/Sales/OrderLimitations.aspx" title="CLICK TO VIEW ORDER LIMITATION FORM"
                target="OrderLimitationsForm" class="hyp">Order Limitations Form</a><br />
            <a href="/Internal/Fabric/FabricWorkingSheet.aspx" target="FabricWorkingSheetForm"
                title="CLICK TO VIEW FABRIC WORKING SHEET " class="hyp">Fabric Order Form</a><br />
            <a href="/Internal/Fabric/FabricAccessoriesWorkSheet.aspx" target="FabricAccessoriesWorkSheetForm"
                title="CLICK TO VIEW FABRIC ACCESSORIES WORKING SHEET" class="hyp">Accessory Order
                Form </a>
            <br />
            <a href="/Internal/Fabric/CuttingSheet.aspx" title="CLICK TO VIEW CUTTING SHEET"
                target="CuttingSheetForm" class="hyp">Cutting Order Form</a><br />
            <a href="javascript:void(0)" class="clientView" onclick="closeQuickLayer();showClientDetailsPopup('#CLIENTID#');return false"
                title="CLICK TO VIEW CLIENT DETAIL" target="ClientView" class="hyp">Client Details</a><br />
            <br />
        </div>
    </div>
    <div class="middle" id="quickviewContent" style="display: none;">
        <div class="form_box item_list">
            <div class="form_heading">
                Links</div>
            <br />
            <a href="/Internal/Merchandising/QualityControl.aspx" target="QAForm" title="CLICK TO VIEW QUALITY ASSURANCE FORM"
                class="hyp">Quality Assurance Form</a><br />
            <a href="/Internal/Sales/OrderLimitations.aspx" title="CLICK TO VIEW ORDER LIMITATION FORM"
                target="OrderLimitationsForm" class="hyp">Order Limitations Form</a><br />
            <br />
        </div>
    </div>
    <%-------------------------13/11/2015 Edited by Prabhaker-------------------------%>
    <div style="width: 100%;">
        <div style="float: left; width: 7%;">
            <input type="button" id="Button1" class="print da_submit_button" value="Print" onclick="return PrintManageOrderPDF();" />
        </div>
        <div style="float: left; width: 70%;">
            <table cellspacing="2" style="font-size: 9px ! important; color: Gray;" class='<%=(hdnSelectFilter.Value == "1") ? "hide_me " : "hide_me"%>'>
                <%--29/10/2015 end abhishek --%>
                <tr>
                    <%--<td style="border:none !important;">Sort By:</td>--%>
                    <td style="border: none !important;">
                    </td>
                    <td style="border: none !important;">
                        <asp:Label Visible="true" ID="lblSortedBy" runat="server" CssClass="do-not-disable"
                            Text="Sorted By"></asp:Label>
                    </td>
                    <td style="border: none !important;">
                        <asp:DropDownList ID="ddlOrder1" runat="server" CssClass="do-not-disable mo_dropdown_style1"
                            Visible="true">
                            <asp:ListItem Selected="True" Text="Select...." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                            <asp:ListItem Value="6">OrderDate</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="border: none !important;">
                        <asp:DropDownList runat="server" ID="ddlOrder2" CssClass="do-not-disable mo_dropdown_style1"
                            Visible="true">
                            <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                            <asp:ListItem Value="6">OrderDate</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="border: none !important;">
                        <asp:DropDownList runat="server" ID="ddlOrder3" CssClass="do-not-disable mo_dropdown_style1"
                            Visible="true">
                            <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                            <asp:ListItem Value="6">OrderDate</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="border: none !important;">
                        <asp:DropDownList runat="server" ID="ddlOrder4" CssClass="do-not-disable mo_dropdown_style1"
                            Visible="true">
                            <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                            <asp:ListItem Value="1">Buyer</asp:ListItem>
                            <asp:ListItem Value="2">Style Number</asp:ListItem>
                            <asp:ListItem Value="3">Dept.</asp:ListItem>
                            <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                            <asp:ListItem Value="5">Status</asp:ListItem>
                            <asp:ListItem Value="6">OrderDate</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="border: none !important;">
                    </td>
                    <td style="border: 0px;">
                        <asp:Button ID="btn_Bottom_search" OnClientClick="javascript:return setvalue();"
                            OnClick="btn_search_Click" runat="server" Text="Search" BorderWidth="0" CssClass="go" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <%------------------end-of prabhaker Edited--------------------------------------%>
    <%--  <div>
        <input type="button" id="btnPrint" class="print"  onclick="return PrintManageOrderPDF();" />
        </div>--%>
    <%--  Gajendra Paging--%>
    <script type="text/javascript">
        $(window).load(function () { $("#spinnL").fadeOut("slow"); }); //Gajendra     
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph_head">
    <style type="text/css">
        .style1
        {
            width: 32px;
        }
    </style>
</asp:Content>
