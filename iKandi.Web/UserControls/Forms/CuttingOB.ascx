<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CuttingOB.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.CuttingOB" %>
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
    .tdgrid
    {
        width:4%;
    }
    .tdgrid input
    {
        width:45px !important;
    }
    .tdPeration
    {
        width:19.4%;    
        
    }
    .tdPeration input
    {
        width:98% !important;
    }
    .tdMachine
    {
        width:8.6%;
    }
    .stitching-head th
    {
        font-size:9px !important;
        font-weight:normal !important;
        
    }
    .fixed {
    /* this make our menu fixed top */    
    z-index: 9999;    
    position: fixed;    
    left: 0;    
    top: 0;    
    width: 1503px;
  }
  select
  {
      text-transform:capitalize !important;
      
  }
  

</style>
<script type="text/javascript">



    function SaveCuttingOBSam(elem) {
        //debugger;
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        var GarmentTypeId = elem.id.split('_')[9];
        var OperationId = $("#<%= grdCuttingOB.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var txtOperation = $("#<%= grdCuttingOB.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var chkMachine = $("#<%= grdCuttingOB.ClientID %> select[id*='ct" + ctId + "_chkMachine" + "']").val();

        if (txtOperation == "") {
            elem.value = "";
            alert("Please Enter OPeration ");
            return;
        }
        if (OperationId == "") {
            OperationId = 0;

        }
        if (chkMachine == null) {
            alert("Please Select Machine ");
            elem.value = "";
            return;
        }
        //
        if (elem.value != "") {
            proxy.invoke("InsertUpdateCuttingOBSam", { OperationId: OperationId, GarmentTypeId: GarmentTypeId, SamVal: SamVal }, function (result) {
                //alert('saved successfully!');
            }, onPageError, false, false);
        }
    }

    function SaveCuttingOB(elem, Falg) {
        //debugger;
        var OperationId = elem.id;
        var ctId = elem.id.split('_')[6].substr(2);
        var OperationId = $("#<%= grdCuttingOB.ClientID %> input[id*='ct" + ctId + "_hdnOperationId" + "']").val();
        var Falg = parseInt(Falg);
        var txtOperation = $("#<%= grdCuttingOB.ClientID %> input[id*='ct" + ctId + "_txtOperation" + "']").val();
        var hdncheckoperation = $("#<%= hdncheckoperation.ClientID %>")
        var hdncheckMachine = $("#<%= hdncheckMachine.ClientID %>")
        if (OperationId == "" && Falg == 1) {
            OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            //hdncheckMachine.val(1);
            
            proxy.invoke("InsertOperation", { OperationVal: OperationVal }, function (result) {
                //debugger;
                if (result > -1) {
                    alert('saved successfully!');
                    $(".btnCutting").click();
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
                //hdncheckMachine.va(1);
            }
            else {
                //debugger;
                OperationVal = txtOperation.replace(/ \s+|\s+$/g, ' ');
            }
           
            if (OperationId == "") {
                OperationId = 0;
            }

            proxy.invoke("InsertUpdateCuttingOB", { OperationId: OperationId, OperationVal: OperationVal, Flag: Falg }, function (result) {
                //debugger;
                if (result > -1) {
                   // alert('saved successfully!');
                   
                }
                else {
                    alert('All Ready Exists');
                }
            }, onPageError, false, false);
        }
        if (Falg == 2) {
            BindCuttingList(elem, OperationId);

        }
        
    }

    function BindCuttingList(elem, OperationId) {
        var SamVal = elem.value;
        var ctId = elem.id.split('_')[6].substr(2);
        $("#<%= grdCuttingOB.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").empty();
        proxy.invoke("GetFactoryWorkSpaceOB", { OperationId: OperationId }, function (result) {
            $.each(result, function (key, value) {
                //debugger;
                $("#<%= grdCuttingOB.ClientID %> select[id*='ct" + ctId + "_lstMachine" + "']").append($("<option></option>").html(value.Description));
            });

        });

    }


    function checkLastVal() {
        //debugger;
        var OperatioVal = $('#grdCuttingOB tr:last').find('td:first').text()
        var MachineVal = $('#grdCuttingOB tr:last').find('td:first').text()
        var lastProductId = $("#<%=grdCuttingOB.ClientID %> tr:last").children("td:first").html();

        var rowcount = $("#<%=grdCuttingOB.ClientID %> tr").length;
        if (rowcount < 10) {
            rowcount = '0' + rowcount;
        }
        var Section = $("#<%= grdCuttingOB.ClientID %> input[id*='ctl" + rowcount + "_txtOperation" + "']").val();
        //debugger;
        //alert(Section);
        if (Section == "") {
            alert('Please Enter Opration!')
            return false;
        }
    }
    
</script>
<%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script> 
<script type="text/javascript">
    $(function () {
        var stickyRibbonTop = $('.freeze-header').offset().top;
        $(window).scroll(function () {
            if ($(window).scrollTop() > stickyRibbonTop) {
                $('.freeze-header').css({ position: 'fixed', top: '0px' });
            } else {
                $('.freeze-header').css({ position: 'static', top: '0px' });
            }
        });
    }); 
</script>--%> 
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanelCutting" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
   
    <table width="100%" class="stitching-head">

   <%-- <tr>
       <td>
            <table width="1507px" cellpadding="0" cellspacing="0" style="text-align:center" border-collapse="collapse" style="border-color:grey !important; border:1px thin;" class="freeze-header">
               <tr>
                   <th class="tdPeration" style=" border-right:1px solid grey;"> OPeration </th>
                    <th class="tdMachine" style=" border-right:1px solid grey;"> Machine/Manual </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> HEADWEAR6 (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> TOPSS (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> SKIRTS (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> SKIRTS (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> DRESSES (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> DRESSES (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> JUMP SUIT (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> SWIMWEAR (SAM)	</th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> TOPS (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> Headwear (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> Outerwear (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> gg (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> njk (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> ghfh (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> Trouser (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> Kids suit (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> dfdfa (SAM) </th>
                    <th class="tdgrid" style=" border-right:1px solid grey;"> ?hghgh/ (SAM) </th>
                    <th class="tdgrid"> &nbsp; </th>
               
               
               </tr>
            
            
            </table>
       
       
       </td>
    
    
    </tr>--%>
        <tr>
            <td>
             <asp:Button ID="btnCutting" CssClass="btnCutting" style="display:none;"  runat="server" Text="Button" 
                    onclick="btnCutting_Click" />
                    <asp:HiddenField ID="hdnCutting" runat="server" Value="0" />
                <asp:GridView ID="grdCuttingOB" runat="server" Width="1507px" AutoGenerateColumns="false"
                    OnRowDataBound="grdCuttingOB_RowDataBound" ShowHeader="true">
                    <Columns>
                        <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" Width="250px" runat="server" Text="OPeration"></asp:Label>
                        </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtOperation" Width="98%" CssClass="Getval" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'  onchange="javascript:return SaveCuttingOB(this,1)" ></asp:TextBox>
                                                            

                                <asp:HiddenField ID="hdnOperationId" runat="server" Value='<%#Eval("Operationcutting") %>' />
                            </ItemTemplate>
                            <ItemStyle />
                            <HeaderStyle />
                            
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Machine/Manual" >
                       <HeaderStyle />
                            <ItemTemplate>
                                
                                    <asp:ListBox ID="chkMachine" runat="server" Width="120PX" Height="50" TextAlign="Right" SelectionMode="Multiple" CssClass="checkbox" onclick="javascript:return SaveCuttingOB(this,2)" >
                                    </asp:ListBox>
                                <asp:HiddenField ID="hdnMachine" runat="server" />
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
                <asp:HiddenField ID="hdncheckoperation" runat="server" />
                <asp:HiddenField ID="hdncheckMachine" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  OnClientClick="javascript:return checkLastVal();" />
                
            </td>
        </tr>
    </table>

     </ContentTemplate>
    </asp:UpdatePanel>
</div>
