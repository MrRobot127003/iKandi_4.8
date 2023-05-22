<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinishingOB.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.FinishingOB" %>
<style type="text/css">
    .bgimg
    {
        background-image: url(../../images/cs_bg.jpg);
        background-repeat: repeat-x;
        width: 100%;
        height: 37px;
        color: White;
        text-transform: capitalize !important;
    }
    
    .tdgrid
    {
        text-transform: capitalize !important;
        text-align: center;
    }
    .fontbold
    {
        font-weight: normal;
    }
    .txtalign
    {
        text-align: left;
    }
    
    
    
    hiddenControl
    {
        visibility: hidden;
    }
    
    .hasborder
    {
        border: 1px solid #FFFFFF;
    }
</style>
<script type="text/javascript">

    function SaveFinishingOBSam(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var ListMachine = $("#<%= grdFinishingOB.ClientID %> select[id*='ct" + ctId + "_chkMachine" + "']").val();
        if (ListMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }

        if (txtOperation == "") {
            alert("Please Enter OPeration");
            elem.value = "";
            return;
        }
        if (OperationId == "") {
            OperationId = 0;
        }
        if (elem.value != "") {
            proxy.invoke("InsertUpdateFinishingOBSam", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                //alert('saved successfully!');
            }, onPageError, false, false);
        }
    }

    function SaveFinishingOB(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdFinishingOB.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
           
            proxy.invoke("InsertFinishing", { OperationVal: OperationVal }, function (result) {
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnFinishing").click();
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
           
        }
        else {
            if (txtOperation == "") {
                alert("Please Enter OPeration");
                return;
            }
            if (Falg == 2) {
                var values = '';
                for (var i = 0; i < elem.options.length; i++) {
                    if (elem.options[i].selected)
                        values += elem.options[i].value + ",";
                }
                var OperationVal = values.replace(/,\s*$/, '');
            }
            else {
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
            if (OperationId == "") {
                OperationId = 0;
            }
            proxy.invoke("InsertUpdateFinishingOB", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                if (result > -1) {
                    //alert('saved successfully!');
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }

        if (Falg == 2) {
            BindFinishingList(elem, OperationId);

        }
    }

    function BindFinishingList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);

        $("#<%= grdFinishingOB.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceFinishing", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdFinishingOB.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }

    function checkLastVal() {
        //debugger;
        var OperatioVal = $('#grdFinishingOB tr:last').find('td:first').text()
        var MachineVal = $('#grdFinishingOB tr:last').find('td:first').text()
        var lastProductId = $("#<%=grdFinishingOB.ClientID %> tr:last").children("td:first").html();

        var rowcount = $("#<%=grdFinishingOB.ClientID %> tr").length;
        if (rowcount < 10) {
            rowcount = '0' + rowcount;
        }
        var Section = $("#<%= grdFinishingOB.ClientID %> input[id*='ctl" + rowcount + "_txtOperation" + "']").val();
        //debugger;
        if (Section == "") {
            alert('Please Enter Opration!')
            return false;
        }
    }



</script>
<div>
    <asp:UpdatePanel ID="UpdatePanelFinishing" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
   
    <table width="100%" class="stitching-head">
        <tr>
            <td>
            <asp:Button ID="btnFinishing" CssClass="btnFinishing" style="display:none;"  runat="server" Text="Button" 
                    onclick="btnFinishing_Click" />
                <asp:GridView ID="grdFinishingOB" runat="server" Width="1507px" AutoGenerateColumns="false"
                    OnRowDataBound="grdFinishingOB_RowDataBound" ShowHeader="true">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                        <HeaderTemplate>
                       
                            <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                       
                        
                        </HeaderTemplate>
                            <ItemTemplate>
                            <asp:TextBox ID="txtOperation" Width="98%" CssClass="Getval" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'  onchange="javascript:return SaveFinishingOB(this,1)" ></asp:TextBox>
                             
                                <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("OperationFinishing") %>' />
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine/Manual">
                        <ItemStyle Width="12%" />
                            <ItemTemplate>
                                
                                    <asp:ListBox ID="chkMachine" runat="server" Width="120" Height="50" TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveFinishingOB(this,2)" >
                                    </asp:ListBox>
                                
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Selected Machine/Manual" >
                       <HeaderStyle />
                            <ItemTemplate>
                                    <asp:ListBox ID="lstMachine" runat="server"  Enabled="false"   Width="120PX" Height="50" TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox" >
                                    </asp:ListBox>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hdnCuttingOB" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server"  Text="Add" OnClick="btnAdd_Click" OnClientClick="javascript:return checkLastVal();"/>
            </td>
        </tr>
    </table>

     </ContentTemplate>
    </asp:UpdatePanel>
</div>