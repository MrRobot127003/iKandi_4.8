<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MOPermission.ascx.cs" 
    Inherits="iKandi.Web.UserControls.Forms.MOPermission" %>


<script type="text/javascript">



    //////// 

    function GetDesignation(elem) {
        //debugger;
        //var Column = elem.id
        //var Id = Column.substr(14);
        var selected = $("#" + '<%=ddlDept.ClientID%> option:selected');
        var Department = selected.val()

        var method = "GetDesignationByDepartId";
        var append = $("#" + '<%=ddlDesig.ClientID%>');
        $(append).empty();
        $.ajax({
            type: "POST",
            url: serviceUrl + method,
            data: '{"DepartmentId":"' + Department + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //debugger;
                $.each(data.d, function (key, value) {
                    $(append).append($("<option></option>").val(value.Id).html(value.Value));
                });

            },

            error: function (result) {
                //debugger;
                alert("Error");
            }
        });
    }


    function GetColumn() {
        debugger;
        var Section = $("#" + '<%=listSection.ClientID%>').val()
        var col = $("#" + '<%=listColumn.ClientID%>').val()

        var selected = $("#" + '<%=listSection.ClientID%> option:selected');
        var suppliervalues = $("#" + '<%=hdnValuesSection.ClientID%>').val(); //hdnValues_1 
        var svalues = $("#" + '<%=hdnval.ClientID%>').val();
        var Id = selected.val()
        if (suppliervalues == "") {
            //                if (Id != undefined) {
            //debugger;
            $("#" + '<%=hdnValuesSection.ClientID%>').val(Id)

            var method = "GetColumnBySectionId";
            var append = $("#" + '<%=listColumn.ClientID%>');
            //if (col == null) {
            //                    $(append).empty();
            //debugger;
            $(append);
            $.ajax({
                type: "POST",
                url: serviceUrl + method,
                data: '{"SectionID":"' + Section + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    debugger;
                    //                        $.each(data.d, function (key, value) {
                    //                            $(append).append($("<option></option>").val(value.Id).html(value.Value));

                    //                        });
                    var v = svalues.split(',');

                    for (var i = 0; i < data.d.length; i++) {
                        //                            $('#group_1').append('<Div Id=divRW_' + Section + '_' + data.d[i].Id + '><label Id=lableRead_' + Section + '_' + data.d[i].Id + '><input type="checkbox" onclick="javascript:return check(this);" class="Read_' + Section + '" Id=checkboxRead_' + Section + '_' + data.d[i].Id + ' name=checkboxRead_' + Section + '_' + data.d[i].Id + ' />Read</label>&nbsp;&nbsp;<label Id=lableWrite_' + Section + '_' + data.d[i].Id + '><input type="checkbox" onclick="javascript:return check(this);" class="write_' + Section + '" Id=checkboxWrit_' + Section + '_' + data.d[i].Id + ' name=checkboxWrit_' + Section + '_' + data.d[i].Id + ' />write</label>(' + data.d[i].Value + '&nbsp;&nbsp;<input type="hidden" id=hdnSectionColumn_' + Section + ' name=hdnSectionColumn_' + Section + '_' + data.d[i].Id + ' value="' + data.d[i].Value + '" /><label></label>&nbsp;</Div>');
                        $('#group_1').append('<Div Id=divRW_' + Section + '_' + data.d[i].Id + '><label Id=lableRead_' + data.d[i].Id + '><input type="checkbox" class="Read_' + '" Id=checkboxRead_' + data.d[i].Id + ' name=checkboxRead_' + data.d[i].Id + ' />Read</label>&nbsp;&nbsp;<label Id=lableWrite_' + data.d[i].Id + '><input type="checkbox" class="write_' + '" Id=checkboxWrit_' + '_' + data.d[i].Id + ' name=checkboxWrit_' + data.d[i].Id + ' />write</label>(' + data.d[i].Value + '&nbsp;&nbsp;<input type="hidden" id=hdnSectionColumn_' + Section + ' name=hdnSectionColumn_' + data.d[i].Id + ' value="' + data.d[i].Value + '" /><label><input type="hidden" id=hdnSectionColumnName_' + Section + ' name=hdnSectionColumnName_' + data.d[i].Id + ' value="' + data.d[i].Id + '" /></label>&nbsp;</Div>');
                    }
                    // return true;
                },
                error: function (result) {
                    //debugger;
                    alert("Error");
                }
            });
        }
        else {
            //debugger;
            var supplierids = suppliervalues.split(",");

            if (jQuery.inArray(Id + "", supplierids) > -1) {
                alert("Allready Selected");
                return false;
            }
            else {
                $("#" + '<%=hdnValuesSection.ClientID%>').val($("#" + '<%=hdnValuesSection.ClientID%>').val() + "," + Id)
                //$("#hdnValuesColumn1_" + colId).val($("#hdnValuesColumn1_" + colId).val() + "," + Id);

                var method = "GetColumnBySectionId";
                var append = $("#" + '<%=listColumn.ClientID%>');
                //if (col == null) {
                //                    $(append).empty();
                $(append);
                $.ajax({
                    type: "POST",
                    url: serviceUrl + method,
                    data: '{"SectionID":"' + Section + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //debugger;
                        //                            $.each(data.d, function (key, value) {
                        //                                $(append).append($("<option></option>").val(value.Id).html(value.Value));

                        //                            });
                        debugger;
                        for (var i = 0; i < data.d.length; i++) {
                            //                                $('#group_1').append('<Div Id=divRW_' + Section + '_' + data.d[i].Id + '><label Id=lableRead_' + Section + '_' + data.d[i].Id + '><input type="checkbox" onclick="javascript:return check(this);" class="Read_' + Section + '" Id=checkboxRead_' + Section + '_' + data.d[i].Id + ' name=checkboxRead_' + Section + '_' + data.d[i].Id + ' />Read</label>&nbsp;&nbsp;<label Id=lableWrite_' + Section + '_' + data.d[i].Id + '><input type="checkbox" onclick="javascript:return check(this);" class="write_' + Section + '" Id=checkboxWrit_' + Section + '_' + data.d[i].Id + ' name=checkboxWrit_' + Section + '_' + data.d[i].Id + ' />write</label>(' + data.d[i].Value + '&nbsp;&nbsp;<input type="hidden" id=hdnSectionColumn_' + Section + ' name=hdnSectionColumn_' + Section + '_' + data.d[i].Id + ' value="' + data.d[i].Value + '" /><label></label>&nbsp;</Div>');
                            $('#group_1').append('<Div Id=divRW_' + Section + '_' + data.d[i].Id + '><label Id=lableRead_' + data.d[i].Id + '><input type="checkbox" class="Read_' + '" Id=checkboxRead_' + data.d[i].Id + ' name=checkboxRead_' + data.d[i].Id + ' />Read</label>&nbsp;&nbsp;<label Id=lableWrite_' + data.d[i].Id + '><input type="checkbox" class="write_' + '" Id=checkboxWrit_' + '_' + data.d[i].Id + ' name=checkboxWrit_' + data.d[i].Id + ' />write</label>(' + data.d[i].Value + '&nbsp;&nbsp;<input type="hidden" id=hdnSectionColumn_' + Section + ' name=hdnSectionColumn_' + data.d[i].Id + ' value="' + data.d[i].Value + '" /><label><input type="hidden" id=hdnSectionColumnName_' + Section + ' name=hdnSectionColumnName_' + data.d[i].Id + ' value="' + data.d[i].Id + '" /></label>&nbsp;</Div>');
                        }
                        // return true;
                    },

                    error: function (result) {
                        //debugger;
                        alert("Error");
                    }
                });

            }
        }

    }

    function checkboxReadChecked(elem) {
        // debugger;
        var chk = elem.id;
        var Chkid = chk.substr(16);
        var ch = $("#checkboxReadAll_" + Chkid).is(":checked");
        if (ch == true) {
            $(".Read").attr('checked', true)
            $(".write").attr('checked', false)
            $(".chkWrite").attr('checked', false)
        }
        if (ch == false) {
            $(".Read").attr('checked', false)
        }
    }


    function checkboxWriteChecked(elem) {
        //debugger;
        var chk = elem.id;
        var Chkid = chk.substr(14);
        var ch = $("#checkboxwrite_" + Chkid).is(":checked");
        if (ch == true) {
            $(".write").attr('checked', true)
            $(".Read").attr('checked', false)
            $(".chkRead").attr('checked', false)
        }
        if (ch == false) {
            $(".write").attr('checked', false)
        }
    }



    function BindCheckBox(elem) {
        //debugger;
        var chkVal = $("#" + '<%=hdnval.ClientID%>').val();
        var chktext = $("#" + '<%=hdntxt.ClientID%>').val();
        var hdnRead = $("#" + '<%=hdnRead.ClientID%>').val();
        var hdnWrite = $("#" + '<%=hdnWrite.ClientID%>').val();
        var val = chkVal.split(',');
        var txt = chktext.split(',');
        var Read = hdnRead.split(',');
        var write = hdnWrite.split(',');
        for (var i = 0; i < val.length; i++) {
            $('#group_1').append('<Div Id=divRW_' + val[i] + '_' + val[i] + '><label Id=lableRead_' + val[i] + '><input type="checkbox"  onclick="javascript:return checkRead(this);" class="Read_' + val[i] + ' ' + 'Read' + '" Id=checkboxRead_' + val[i] + ' name=checkboxRead_' + val[i] + ' />Read</label>&nbsp;&nbsp;<label Id=lableWrite_' + val[i] + '><input type="checkbox"  onclick="javascript:return checkwrite(this);" class="write_' + val[i] + ' ' + 'write' + '" Id=checkboxWrit_' + val[i] + ' name=checkboxWrit_' + val[i] + ' />write</label>(' + txt[i] + '&nbsp;&nbsp;<input type="hidden" id=hdnSectionColumn_' + val[i] + ' name=hdnSectionColumn_' + val[i] + ' value="' + txt[i] + '" /><label><input type="hidden" id=hdnSectionColumnName_' + val[i] + ' name=hdnSectionColumnName_' + val[i] + ' value="' + val[i] + '" /></label>&nbsp;</Div>');
            //debugger;
            if (hdnRead != "") {
                //                if (Read[i] == "False") {
                //                    $(".Read_" + val[i]).attr('checked', false);
                //                }

                //                else  {
                //                    $(".Read_" + val[i]).attr('checked', true)
                //                }
                //              
                //                if (write[i] == "False") {
                //                    $(".write_" + val[i]).attr('checked', false);
                //                }
                //                else  {
                //                    $(".write_" + val[i]).attr('checked', true);
                //                }
                //                //debugger;
                //                if (i >= Read.length) {
                //                    $(".write_" + val[i]).attr('checked', false);
                //                    $(".Read_" + val[i]).attr('checked', false);
                //                }


            }

        }
        MOControl();
        checkallPermission();

    }

    function MOControl() {
        //debugger;
        var DesigId = document.getElementById("<%= hdnDesig.ClientID %>").value;
        var DeptId = document.getElementById("<%= hdnDept.ClientID %>").value;
        if (DesigId != 1) {
            proxy.invoke("GetMoPermissionList", { DesigId: DesigId, DeptId: DeptId },
            function (objStyleFabricCollection) {
                if (objStyleFabricCollection != null) {
                    if (objStyleFabricCollection.length > 0)
                    // debugger; 
                        SetMOControls(1, objStyleFabricCollection[0].DepartmentId, objStyleFabricCollection[0].DesignationId, objStyleFabricCollection[0].Section, objStyleFabricCollection[0].Column, objStyleFabricCollection[0].Read, objStyleFabricCollection[0].Write);
                    for (var k = 1; k < objStyleFabricCollection.length; k++) {
                        //$("#addRow_newIND").click();
                        SetMOControls(k + 1, objStyleFabricCollection[k].DepartmentId, objStyleFabricCollection[k].DesignationId, objStyleFabricCollection[k].Section, objStyleFabricCollection[k].Column, objStyleFabricCollection[k].Read, objStyleFabricCollection[k].Write);
                    }
                }
            });
        }

    }

    function SetMOControls(id, DepartmentId, DesignationId, Section, Column, Read, Write) {
        //debugger; 
        var chkVal = $("#" + '<%=hdnval.ClientID%>').val();
        var val = chkVal.split(',');
        if (chkVal != 1) {

            if (Read == false) {
                $("#checkboxRead_" + Column).attr('checked', false);
            }

            else {
                $("#checkboxRead_" + Column).attr('checked', true)
            }

            if (Write == false) {
                $("#checkboxWrit_" + Column).attr('checked', false);
            }
            else {
                $("#checkboxWrit_" + Column).attr('checked', true);
            }
        }

    } //


    function checkallPermission() {
        //debugger;
        var hdnPermission = $("#" + '<%=hdnReadWritePermission.ClientID%>').val();
        if (hdnPermission == 1) {
            $(".chkWrite").attr('checked', true)
            $(".chkRead").attr('checked', false)
        }
        if (hdnPermission == 0) {
            $(".chkRead").attr('checked', true)
            $(".chkWrite").attr('checked', false)
        }
    }

    function createCheckBox(elem) {
        //debugger;
        var chkVal = $("#" + '<%=hdnval.ClientID%>').val();
        var chktext = $("#" + '<%=hdntxt.ClientID%>').val();
        var hdnRead = $("#" + '<%=hdnRead.ClientID%>').val();
        var hdnWrite = $("#" + '<%=hdnWrite.ClientID%>').val();
        var val = chkVal.split(',');
        var txt = chktext.split(',');
        //            var Read = hdnRead.split(',');
        //            var write = hdnWrite.split(',');
        for (var i = 0; i < val.length; i++) {
            $('#group_1').append('<Div Id=divRW_' + val[i] + '_' + val[i] + '><label Id=lableRead_' + val[i] + '><input type="checkbox"  onclick="javascript:return checkRead(this);" class="Read_' + val[i] + ' ' + 'Read' + '" Id=checkboxRead_' + val[i] + ' name=checkboxRead_' + val[i] + ' />Read</label>&nbsp;&nbsp;<label Id=lableWrite_' + val[i] + '><input type="checkbox"  onclick="javascript:return checkwrite(this);" class="write_' + val[i] + ' ' + 'write' + '" Id=checkboxWrit_' + val[i] + ' name=checkboxWrit_' + val[i] + ' />write</label>(' + txt[i] + '&nbsp;&nbsp;<input type="hidden" id=hdnSectionColumn_' + val[i] + ' name=hdnSectionColumn_' + val[i] + ' value="' + txt[i] + '" /><label><input type="hidden" id=hdnSectionColumnName_' + val[i] + ' name=hdnSectionColumnName_' + val[i] + ' value="' + val[i] + '" /></label>&nbsp;</Div>');



        }
    }


    function checkRead(elem) {
        //debugger;
        var ColId = elem.id;
        var ColumnId = ColId.substr(13);
        var ischecked = false;
        var chkVal = $("#" + '<%=hdnColumnId.ClientID%>').val();
        var val = chkVal.split(',');
        var Active = $("#checkboxRead_" + ColumnId);
        if (!$(Active).is(':checked')) {

        }
        else {
            $(".write_" + ColumnId).attr('checked', false)

        }
        $(".write_" + ColumnId).attr('checked', false)

        //            debugger;
        //            for (var i = 0; i < val.length; i++) {
        //                if (val[i] == ColumnId) {
        //                    ischecked = true;
        //                }

        //            }
        //            if (ischecked == false) {
        //                alert('Please Select Related Column & Section');
        //                return;
        //            }
    }

    function checkwrite(elem) {
        //debugger;
        var ColId = elem.id;
        var ColumnId = ColId.substr(13);
        var Active = $("#checkboxWrit_" + ColumnId);
        var ReadActive = $("#checkboxRead_" + ColumnId);
        if (!$(Active).is(':checked')) {

        }
        else {
            $(".Read_" + ColumnId).attr('checked', false)

        }
    }

    //        $('.select').live('change', function () {
    //            //debugger;
    //            var id;
    //            var values = $("#" + '<%=hdnColumnId.ClientID%>');
    //            var $container = $("p#inderContainer");
    //            $container.html($(this).find('option:selected').map(function () {
    //                debugger;
    //                id = $(this).val();
    //                return id;
    //                //values.val(id)
    //            }).get().join(", "));
    //            //$("#" + '<%=hdnColumnId.ClientID%>').val($("#" + '<%=hdnColumnId.ClientID%>').val() + ',' + id);
    //            debugger;
    //            if (values == "") {
    //                $("#" + '<%=hdnColumnId.ClientID%>').val(id)
    //            }
    //            else {
    //                //debugger;
    //                var valuesId = values.split(",");

    //                if (jQuery.inArray(id + "", valuesId) > -1) {
    //                    //alert("Allready Selected");
    //                    return false;
    //                }
    //                else {
    //                    $("#" + '<%=hdnColumnId.ClientID%>').val($("#" + '<%=hdnColumnId.ClientID%>').val() + "," + id)
    //                }
    //            }
    //        });

    function CheckValidation() {
        //debugger;
        var ddlDept = $("#" + '<%=ddlDept.ClientID%>').val();
        var ddlDesig = $("#" + '<%=ddlDesig.ClientID%>').val();
        var listSection = $("#" + '<%=listSection.ClientID%>').val();
        var listColumn = $("#" + '<%=listColumn.ClientID%>').val();

        if (ddlDept == -1) {
            alert('Please Select Department Name');
            return false;
        }
        if (ddlDesig == -1) {
            alert('Please Select Department Name');
            return false;
        }
        if (listSection == "") {
            alert('Please Select Section Name');
            return false;
        }
        //        if (ddlOrders == "-1") {
        //            alert('Please Select Order By Name');
        //            return false; 
        //        }

    }

    //        
</script>

<asp:ScriptManager ID="ScriptManager" runat="server" ></asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel" runat="server">
<Triggers>
<asp:PostBackTrigger ControlID="listSection" />
</Triggers>
<ContentTemplate>
<div>


    <%--<table width="100%">
    <tr class="td-sub_headings">
                                    <td width="6%" align="center" valign="bottom" class="border border-rightbottom-none">
                                        <asp:Label ID="lblSize"  Text="Department" runat="server"></asp:Label>&nbsp;*
                                    </td>
                                    <td width="8%" valign="bottom" class="border border-rightbottom-none" align="center">
                                        <asp:Label ID="lblSupplier" Text="Designation*" runat="server"></asp:Label>
                                    </td>
                                    <td style="width:2%;" align="left" valign="bottom" class="border border-rightbottom-none" colspan="1">
                                        <asp:Label ID="Label3" Text="Section" runat="server"></asp:Label>&nbsp;* &nbsp;
                                    </td>
                                     <td style="width:32%;" align="right" valign="bottom" class="border border-rightbottom-none" colspan="1">
                                        <asp:Label ID="Label2" Text="" runat="server"></asp:Label>
                                    </td>
                                     <td width="10%" align="left" valign="bottom" class="border border-rightbottom-none" colspan="1">
                                      <div style="float:left; padding-right:45px;"><asp:Label ID="lblOrder" Text="Order By" runat="server"></asp:Label>&nbsp;* &nbsp;</div>
                                      <div style="float:left; padding-left:10px;"></div>
                                    </td>
                                    <td width="30%" valign="bottom" align="left" class="border border-rightbottom-none">
                                        <asp:Label ID="Label1" runat="server" Text="Column*"></asp:Label>
                                    </td>
                                    <td width="2%" valign="bottom" align="center" class="border border-rightbottom-none">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                <td align="center" valign="top">
                               <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true" CssClass="input_in" Width="100px"
                                        
                                        onselectedindexchanged="ddlDept_SelectedIndexChanged"></asp:DropDownList>

                                </td>
                                <td align="center" valign="top">
                                <asp:DropDownList ID="ddlDesig" runat="server" CssClass="input_in" Width="120px">
                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td style="width:2%;" valign="top">
                                <asp:ListBox ID="listSection" runat="server" SelectionMode="Multiple" Visible="true" AutoPostBack="true" onselectedindexchanged="listSection_SelectedIndexChanged" Rows="8"></asp:ListBox>
                                <asp:CheckBoxList ID="chkSection" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  Visible="false"
                                        onselectedindexchanged="chkSection_SelectedIndexChanged"></asp:CheckBoxList>
                                <asp:HiddenField ID="hdnValuesSection" runat="server" />
                                <asp:HiddenField ID="hdnval" runat="server" />
                                <asp:HiddenField ID="hdntxt" runat="server" />
                                </td>
                              <td style="width: 25%; border: 1;" valign="top">
                                        <label>
                                            <input type="checkbox" id="checkboxReadAll_1" class="chkRead" name="checkboxReadAll_1"  onclick="javascript:return checkboxReadChecked(this);" />Read &nbsp;&nbsp;(Applicable To All Column)</label>&nbsp;
                                        <label>
                                            <input type="checkbox" id="checkboxwrite_1" class="chkWrite" name="checkboxwrite_1" onclick="javascript:return checkboxWriteChecked(this);" />Write&nbsp;&nbsp;(Applicable To All Column)</label>
                                        
                                    </td>
                                     <td align="left" valign="top" id="Td1" name="group_1" type="td" style="width: 18%;
                                        border: 1;">
                                        <div style="float:left; padding-right:5px;"><asp:DropDownList ID="ddlOrders" runat="server" CssClass="input_in" Width="90px">
                                             <asp:ListItem Selected="True" Text="Select...." Value="-1"></asp:ListItem>
                                             <asp:ListItem Value="1">Buyer</asp:ListItem>
                                             <asp:ListItem Value="2">Style Number</asp:ListItem>
                                             <asp:ListItem Value="3">Department</asp:ListItem>
                                             <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                                             <asp:ListItem Value="5">Status</asp:ListItem>
                                             <asp:ListItem Value="6">Order Date</asp:ListItem>
                                         </asp:DropDownList></div>
                                         <div>
                                         <asp:CheckBox ID="chkSalesView" runat="server" Text="Sales View" />
                                         </div>
                                <td align="left" valign="top" id="group_1" name="group_1" type="td" style="width: 4%;
                                        border: 1;">
                               
                                <asp:ListBox ID="listColumn" runat="server" SelectionMode="Multiple" CssClass="select" Visible="false"
                                        
                                        AutoPostBack="false"></asp:ListBox>
                                 

                                   <asp:HiddenField ID="hdnReadWritePermission" runat="server" />
                                    <asp:HiddenField ID="hdnRead" runat="server" />
                                    <asp:HiddenField ID="hdnWrite" runat="server" />
                                     <asp:HiddenField ID="hdnColumnId" runat="server" />
                                    </td>
                                <td align="left" valign="top" id="group_1" name="group_1" type="td" style="width: 2%;
                                        border: 1;" >
                                </tr>
                                <tr>
                                <td colspan="6">
                                
                                  <asp:Button ID="btnSubmit" Text="Submit" CssClass="da_submit_button" OnClientClick="javascript:return CheckValidation();"
                                     runat="server" 
                                    onclick="btnSubmit_Click"  />
                                </td>
                                </tr>
                                <tr>
                               
                                <td colspan="6">
                               
                               <asp:HiddenField ID="hdnDesig" runat="server" />
                               <asp:HiddenField ID="hdnDept" runat="server" />
                                </td >
                                    
                                </tr>
    </table>--%>
   
      <table width="100%">
    <tr class="td-sub_headings">
                                    <td width="9%" align="center" valign="bottom" class="border border-rightbottom-none">
                                        <asp:Label ID="lblSize"  Text="Department" runat="server"></asp:Label>&nbsp;*
                                    </td>
                                    <td width="8%" valign="bottom" class="border border-rightbottom-none" align="center">
                                        <asp:Label ID="lblSupplier" Text="Designation*" runat="server"></asp:Label>
                                    </td>
                                    <td style="width:8%;" align="left" valign="bottom" class="border border-rightbottom-none" colspan="1">
                                        <asp:Label ID="Label3" Text="Section" runat="server"></asp:Label>&nbsp;* &nbsp;
                                    </td>
                                     <td style="width:32%;" align="right" valign="bottom" class="border border-rightbottom-none" colspan="1">
                                        <asp:Label ID="Label2" Text="" runat="server"></asp:Label>
                                    </td>
                                     <%--<td width="8%" align="left" valign="bottom" class="border border-rightbottom-none" colspan="1">
                                   <asp:Label ID="lblOrder" Text="Order By" runat="server"></asp:Label>&nbsp;* &nbsp;
                                    </td>--%>
                                    <td width="30%" valign="bottom" align="left" class="border border-rightbottom-none">
                                        <asp:Label ID="Label1" runat="server" Text="Column*"></asp:Label>
                                    </td>
                                    <td width="2%" valign="bottom" align="center" class="border border-rightbottom-none">
                                        &nbsp;</td>
                                </tr>
    <tr>
    <td colspan="6">
    <table width="100%">
   <tr>
    <td width="60%" align="center" valign="top" class="border border-rightbottom-none">
   <table width="100%">
   <tr>
   <td align="left" valign="top">
   <div style="float:left; width:100px;">
   <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true" Width="100px" CssClass="input_in"
   onselectedindexchanged="ddlDept_SelectedIndexChanged"></asp:DropDownList>
</div>


   </td>
   <td valign="top" align="right">
   <asp:DropDownList ID="ddlDesig" runat="server" CssClass="input_in">
                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList>
   </td>
   <td valign="top" align="left">
   <asp:ListBox ID="listSection" runat="server" SelectionMode="Multiple" Visible="true" AutoPostBack="true" onselectedindexchanged="listSection_SelectedIndexChanged" Rows="5"></asp:ListBox>
                                <asp:CheckBoxList ID="chkSection" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  Visible="false"
                                        onselectedindexchanged="chkSection_SelectedIndexChanged"></asp:CheckBoxList>
                                <asp:HiddenField ID="hdnValuesSection" runat="server" />
                                <asp:HiddenField ID="hdnval" runat="server" />
                                <asp:HiddenField ID="hdntxt" runat="server" />
   </td>
   <td valign="top" colspan="4">
   <label>
                                            <input type="checkbox" id="checkboxReadAll_1" class="chkRead" name="checkboxReadAll_1"  onclick="javascript:return checkboxReadChecked(this);" />Read &nbsp;&nbsp;(Applicable To All Column)</label>&nbsp;
                                        <label>
                                            <input type="checkbox" id="checkboxwrite_1" class="chkWrite" name="checkboxwrite_1" onclick="javascript:return checkboxWriteChecked(this);" />Write&nbsp;&nbsp;(Applicable To All Column)</label>
                                        
   </td>
   </tr>
   <tr>
   <td align="left" colspan="7">
   
   <asp:Label ID="lblFilter" runat="server" Text="Filter" Font-Bold="true" Width="50"></asp:Label>
   </td>
   
   </tr>
      <tr>
   <td align="left" style="width:10%";>
  Sort By
   </td>
   <td style="width:10%";>
   <asp:DropDownList ID="ddlOrder1" runat="server" CssClass="do-not-disable mo_dropdown_style1 input_in" Visible="true" >
                                        <asp:ListItem  Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Buyer</asp:ListItem>
                                        <asp:ListItem Value="2">Style Number</asp:ListItem>
                                        <asp:ListItem Value="3">Dept.</asp:ListItem>
                                        <asp:ListItem Value="4" Selected="True">Ex-Factory</asp:ListItem>
                                        <asp:ListItem Value="5">Status</asp:ListItem>
                                        <asp:ListItem Value="6">Order Date</asp:ListItem>
                                    </asp:DropDownList>
   </td>
    <td style="width:10%";>
    <asp:DropDownList runat="server" ID="ddlOrder2" CssClass="do-not-disable mo_dropdown_style1 input_in" Visible="true" Width="150px">
                                        <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1" Selected="True">Buyer</asp:ListItem>
                                        <asp:ListItem Value="2">Style Number</asp:ListItem>
                                        <asp:ListItem Value="3">Dept.</asp:ListItem>
                                        <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                                        <asp:ListItem Value="5">Status</asp:ListItem>
                                        <asp:ListItem Value="6">Order Date</asp:ListItem>
                                    </asp:DropDownList>
    </td>
     <td style="width:10%";>
     <asp:DropDownList runat="server" ID="ddlOrder3" CssClass="do-not-disable mo_dropdown_style1 input_in" Visible="true">
                                        <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Buyer</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">Style Number</asp:ListItem>
                                        <asp:ListItem Value="3">Dept.</asp:ListItem>
                                        <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                                        <asp:ListItem Value="5">Status</asp:ListItem>
                                        <asp:ListItem Value="6">Order Date</asp:ListItem>
                                    </asp:DropDownList>
     </td>
      <td style="width:10%";>
      <asp:DropDownList runat="server" ID="ddlOrder4" CssClass="do-not-disable mo_dropdown_style1 input_in" Visible="true" >
                                        <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Buyer</asp:ListItem>
                                        <asp:ListItem Value="2">Style Number</asp:ListItem>
                                        <asp:ListItem Value="3" Selected="True">Dept.</asp:ListItem>
                                        <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                                        <asp:ListItem Value="5">Status</asp:ListItem>
                                        <asp:ListItem Value="6">Order Date</asp:ListItem>
                                    </asp:DropDownList>
      </td>
       <td style="width:10%";>
       <asp:DropDownList ID="ddlOrder5" runat="server" CssClass="do-not-disable mo_dropdown_style1 input_in" Visible="true" >
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Buyer</asp:ListItem>
                                        <asp:ListItem Value="2">Style Number</asp:ListItem>
                                        <asp:ListItem Value="3" >Dept.</asp:ListItem>
                                        <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                                        <asp:ListItem Value="5" Selected="True">Status</asp:ListItem>
                                       <asp:ListItem Value="6">Order Date</asp:ListItem>

                                    </asp:DropDownList>
       </td>

       <td style="width:30%"; align="left">
       <asp:DropDownList ID="ddlOrder6" runat="server" CssClass="do-not-disable mo_dropdown_style1 input_in" Visible="true" >
                                        <asp:ListItem Text="Select...." Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Select ....." Value="-1"></asp:ListItem>
                                        <asp:ListItem Value="1">Buyer</asp:ListItem>
                                        <asp:ListItem Value="2">Style Number</asp:ListItem>
                                        <asp:ListItem Value="3" >Dept.</asp:ListItem>
                                        <asp:ListItem Value="4">Ex-Factory</asp:ListItem>
                                        <asp:ListItem Value="5">Status</asp:ListItem>
                                       <asp:ListItem Value="6"  Selected="True">Order Date</asp:ListItem>

                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <asp:CheckBox ID="chkSalesView" runat="server" Text="Sales View" />
       </td>

   </tr>
   <tr>
   <td colspan="7" align="left">
   
   </td>
   </tr>
  
   </table>
  </td>
 <td align="left" valign="top" id="group_1" name="group_1" type="td" style="width: 8%;
                                        border: 1;">
 <asp:ListBox ID="listColumn" runat="server" SelectionMode="Multiple" CssClass="select" Visible="false"
                                        
                                        AutoPostBack="false"></asp:ListBox>
                                 

                                   <asp:HiddenField ID="hdnReadWritePermission" runat="server" />
                                    <asp:HiddenField ID="hdnRead" runat="server" />
                                    <asp:HiddenField ID="hdnWrite" runat="server" />
                                     <asp:HiddenField ID="hdnColumnId" runat="server" />

    </td>
    </tr>
     <tr>
    <td width="60%" align="left" valign="bottom" class="border border-rightbottom-none">
    <asp:Button ID="btnSubmit" Text="Submit" CssClass="da_submit_button" OnClientClick="javascript:return CheckValidation();"
                                     runat="server" 
                                    onclick="btnSubmit_Click"  />

                                    <asp:HiddenField ID="hdnDesig" runat="server" />
                               <asp:HiddenField ID="hdnDept" runat="server" />
  </td>
 <td width="40%" valign="bottom" class="border border-rightbottom-none" align="center" >
    </td>
    </tr>

   </table>
    </td>
    </tr>
    </table>
   
                                             
</div>
 </ContentTemplate>
</asp:UpdatePanel>

