<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmLossDistributionAdmin.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.frmLossDistributionAdmin" %>
<style type="text/css">
    .font
    {
        font-size: 13px;
    }
    .border td
    {
        border: 1px solid #000000;
        border-collapse: collapse;
    }
    .border2 th
    {
        background-image: url(../../images/cs_bg.jpg);
        background-repeat: repeat-x;
        padding: 10px;
        color: White;
        text-transform: capitalize;
    }
    .submit
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px 0px;
        border: none;
    }
    .submit:hover 
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px -28px;
    }
    
    .header-top-sec
    {
        font-size: 15px;
        text-align: center;
        color: #f2f2f2;
        font-family: verdana;
        padding:4px 0px;      
        font-weight: 500;
        text-transform: none;
        background-color: #3a5795;
    }
    .header-field
    {
        background: #dddfe4;
       color:#575759;
       padding:5px 0px;
       text-transform:capitalize;
       font-size:12px;
    }
      .header-field1
    {
        display:none;
    }
    .main_tbl_wrapper
    {
        background: #fff;
    }
    .inputvalue_textbox
    {
        width: 90%;
        text-align: left;
        text-transform: capitalize !important;
        font-size: 12px !important;
        font-family: Verdana;
        padding: 2px 0px;
    }
    .input-value
    {
        width: 90%;
        text-align: left;
        text-transform: capitalize !important;
        font-size: 12px !important;
        font-family: Verdana;
        padding: 2px 0px;
    }
    td label
    {
        text-transform: capitalize !important;
        font-size: 12px;
        font-family: Verdana;
    }
    img
    {
        border: 0px;
    }
    .head-dis th
    {
       background: #3a5795;
       color:#ffffff;
       padding:5px 0px;
       text-transform:capitalize;
       font-size:14px;
    }
      .head-dis td
    {
       
       padding:5px 0px;
       text-transform:capitalize;
       font-size:12px;
    }
    .head-dis td select
    {
        width:90%;
        padding:3px 3px;
    }
    /*updated css by bharat 2 jan 19*/
    td input[type="checkbox"]
    {
        position:relative;
        top:2px;
     }
    td select
    {
      margin-left: 2px;
      width: 98% !important;
     }
    .TableBorder td:first-child
     {
         border-left-color:#999 !important;
      }
      .TableBorder td:last-child
     {
         border-right-color:#999 !important;
      }
    .TableBorder tr:last-child > td
     {
         border-bottom-color:#999 !important;
      }
     /*end*/
</style>
<script type="text/javascript">



    function UpdateLineLineDesignation(elem, Cidnew) {


        var Ids = elem.id;
        var cId = Ids.split("_")[6].substr(3);
        var CtnNeme = Ids.split("_")[7];

        var userId = '<%=this.UserId%>';

        var IsAct;

        var Isacts = $("#<%= grdLossdistribution.ClientID %> input[id*='ctl" + cId + "_rdo_active" + "']");
        var IsinAct = $("#<%= grdLossdistribution.ClientID %> input[id*='ctl" + cId + "_rdo_inactive" + "']");

        if (Isacts.is(':checked')) {

            IsAct = 1;
        }
        if (IsinAct.is(':checked')) {
            IsAct = 0;
        }


        var Dept_Name = $("#<%= grdLossdistribution.ClientID %> select[id*='ctl" + cId + "_ddldepartment" + "']").val();

        var Chk_stiching = $("#<%= grdLossdistribution.ClientID %> input[id*='ctl" + cId + "_chk_stitching" + "']");
        var Chk_finishing = $("#<%= grdLossdistribution.ClientID %> input[id*='ctl" + cId + "_Chk_Finishing" + "']");
        var Chk_cutting = $("#<%= grdLossdistribution.ClientID %> input[id*='ctl" + cId + "_Chk_cutting" + "']");

        var Chk_stiching_value;
        var Chk_finsing_value;
        var Chk_cutting_value;

        // Do stuff assing stiching and finishing cutting value to variable
        if (Chk_stiching.is(':checked')) {



            Chk_stiching_value = 1;
        }
        else {
            Chk_stiching_value = 0;
        }
        if (Chk_finishing.is(':checked')) {



            Chk_finsing_value = 1;
        }
        else {
            Chk_finsing_value = 0;
        }
        if (Chk_cutting.is(':checked')) {



            Chk_cutting_value = 1;
        }
        else {
            Chk_cutting_value = 0;
        }

        var id = parseInt($("#<%= grdLossdistribution.ClientID %> input[id*='ctl" + cId + "_hdnDesignationItem" + "']").val());
        if (Chk_stiching_value == 0 && Chk_finsing_value == 0 && Chk_cutting_value == 0) {

            alert("Value not save .! & at least one department association check box should be check.");
            return false;

        }

        if (Isacts.is(':checked')) {

            $(Chk_stiching).attr('disabled', false);
            $(Chk_finishing).attr('disabled', false);
            $(Chk_cutting).attr('disabled', false);
        }
        if (IsinAct.is(':checked')) {
            $(Chk_stiching).attr('disabled', true);
            $(Chk_finishing).attr('disabled', true);
            $(Chk_cutting).attr('disabled', true);
        }

        proxy.invoke("UpdateLossDesignation", { Dept_name: Dept_Name, Isactive: IsAct, UserId: userId, id: id, stiching: Chk_stiching_value, finishing: Chk_finsing_value, cutting: Chk_cutting_value }, function (result) {
            DisplayErrorMsg(result, elem);

        }, onPageError, false, false);

    }

    var IsShiftDown = false;
    function BlockingHtml(Sender, e) {
        var key = e.which ? e.which : e.keyCode;
        if (key == 16) {
            IsShiftDown = true;
            //CharCounter(Sender, 10);
        }
        else if ((IsShiftDown == true) && ((key == 188) || (key == 190))) {
            return false;
        }
    }



    function ValidateLettersWithSpaceOnly(evt) {

        //      evt = (evt) ? evt : event;
        //      var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
        //    ((evt.which) ? evt.which : 0));
        //      if (charCode > 32 && (charCode < 65 || charCode > 90) &&
        //        (charCode < 97 || charCode > 122)) {
        //          return false;
        //      }
        //      return true;
    }

    function ValidateFullNamePaste(obj) {
        //      var totalCharacterCount = window.clipboardData.getData('Text');
        //      var strValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
        //      var strChar;
        //      var FilteredChars = "";
        //      for (i = 0; i < totalCharacterCount.length; i++) {
        //          strChar = totalCharacterCount.charAt(i);
        //          if (strValidChars.indexOf(strChar) != -1) {
        //              FilteredChars = FilteredChars + strChar;
        //          }
        //      }
        //      obj.value = FilteredChars;
        //      return false;
    }


    //  function DisplayErrorMsg(Result, elem) {

    //     
    //      var defValue = elem.defaultValue;
    //     


    //      var Ids = elem.id;
    //      var cId = Ids.split("_")[6].substr(3);

    //      if (Result == -1) {
    //          $("#<%= grdLossdistribution.ClientID %> input[id*='ctl" + cId + "_txtNameItem" + "']").val(defValue);
    //          ShowHideMessageBox(true, 'department name cannot be chnaged or modifie ', 'Form Loss Distribution');
    //          
    //          return false;
    //      }
    //      else {

    //          ShowHideMessageBox(true, 'Record updated', 'Form Loss Distribution');
    //      }

    //  }


    function DisplayErrorMsg(Result, elem) {

        var defValue = elem.defaultValue;
        var Ids = elem.id;
        var cId = Ids.split("_")[6].substr(3);
        var CtnNeme = Ids.split("_")[7];
        var UpdatePanel1 = '<%=InsertEmployeeUpdatePanel.ClientID%>';

        if (Result == 1) {

            alert('Reacord Updated');

            // $(".btnbottom").click();


        }
        if (Result == 2) {


            alert('Department name already exists');

            window.location.href = "FrmLossDestributionAdmin.aspx";

            return false;
        }


    }

    

</script>
<table width="600px" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
    <tr>
        <td align="center">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />

            <h2 class="header-top-sec" >    Department Admin For Loss Distribution </h2>
         
             
                                    <!--table2-->
                                   
                                                <asp:UpdatePanel ID="InsertEmployeeUpdatePanel" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdLossdistribution" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" ShowFooter="true" HeaderStyle-HorizontalAlign="Center"
                                                            OnRowDataBound="grdLossdistribution_RowDataBound" CssClass="TableBorder" OnRowCommand="grdLossdistribution_RowCommand" onselectedindexchanged="rbtnIsActiveItem_SelectedIndexChanged" RowStyle-CssClass="head-dis" FooterStyle-CssClass="head-dis">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Department Name" HeaderStyle-CssClass="header-field">
                                                                    <ItemTemplate>
                                                                        <%--<asp:TextBox ID="txtNameItem" onpaste="return false;" CssClass="inputvalue_textbox"
                                                                            onKeyDown="return BlockingHtml(this,event);" onchange="UpdateLineLineDesignation(this)"
                                                                            Text='<%#Eval("DepartmentName") %>' MaxLength="50" runat="server"></asp:TextBox>--%>
                                                                            <asp:DropDownList ID="ddldepartment" runat="server" onchange="UpdateLineLineDesignation(this)"></asp:DropDownList>
                                                                        <asp:HiddenField runat="server" ID="hdnDesignationItem" Value='<%#Eval("DepartmentLoss_DistriID") %>' />
                                                                        <asp:HiddenField runat="server" ID="hdndepratmentId" Value='<%#Eval("DepartmentID") %>' />
                                                                        
                                                                       

                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <%--<asp:TextBox ID="txtNameFooter" CssClass="input-value" onkeypress="return ValidateLettersWithSpaceOnly(event);"
                                                                            onpaste="return false;" onKeyDown="return BlockingHtml(this,event);" MaxLength="50"
                                                                            runat="server"></asp:TextBox>--%>
                                                                            <asp:DropDownList ID="ddldepartmentfoter" runat="server" AppendDataBoundItems="true">
                                                                            <asp:ListItem Selected="true" Value="-1" >
                                                                            Select.
                                                                            </asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField   HeaderText="IsActive" HeaderStyle-CssClass="header-field1" FooterStyle-CssClass="header-field1"  ItemStyle-CssClass="header-field1">
                                                                    <ItemTemplate >
                                                                        <%--<asp:RadioButtonList ID="rbtnIsActiveItem" AutoPostBack="true" OnSelectedIndexChanged="rbtnIsActiveItem_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                                            <asp:ListItem Value="0" Selected="True" Text="Inactive"></asp:ListItem>
                                                                        </asp:RadioButtonList>--%>
                                                                         <input type="radio" style="display:none;"   runat="server" id="rdo_active" value="1" onchange="UpdateLineLineDesignation(this)" />
                                                                         <input type="radio" style="display:none;" runat="server" id="rdo_inactive" value="0" onchange="UpdateLineLineDesignation(this)" />
                                                                        <asp:HiddenField runat="server" ID="hdnIsActive" Value='<%#Eval("IsActive") %>' />
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:RadioButtonList ID="rbtnIsActiveFooter" Width="150" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="1" style="display:none;" Selected="True" Text="Active"></asp:ListItem>
                                                                                <asp:ListItem  Value="0" style="display:none;" Text="Inactive"></asp:ListItem>
                                                                            </asp:RadioButtonList>


                                                                            
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField  HeaderText="Department Association" HeaderStyle-CssClass="header-field">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center;">
                                                                            <%--<asp:CheckBox ID="chk_stitching" runat="server"  onclick="UpdateLineLineDesignation(this); return false;"   /> Stitching--%>
                                                                            <input id="chk_stitching" runat="server" onchange="UpdateLineLineDesignation(this);"
                                                                                type="checkbox" checked="checked" />Stitching
                                                                            <asp:HiddenField runat="server" ID="hnd_Stitching" Value='<%#Eval("stitching") %>' />
                                                                            <%--<asp:CheckBox ID="Chk_Finishing" runat="server" onclick="UpdateLineLineDesignation(this); return false;" /> Finishing--%>
                                                                            <input id="Chk_Finishing" runat="server" onchange="UpdateLineLineDesignation(this);"
                                                                                type="checkbox" />
                                                                            Finishing
                                                                            <asp:HiddenField runat="server" ID="hdn_finishing" Value='<%#Eval("Finishing") %>' />
                                                                            <%--<asp:CheckBox ID="Chk_cutting" runat="server" onclick="UpdateLineLineDesignation(this); return false;" /> Cutting--%>
                                                                            <input id="Chk_cutting" runat="server" onchange="UpdateLineLineDesignation(this);"
                                                                                type="checkbox" />
                                                                            Cutting
                                                                            <asp:HiddenField runat="server" ID="hdn_cutting" Value='<%#Eval("Cutting") %>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:CheckBox ID="chk_footer_stitching" runat="server" Checked="true" />
                                                                            Stitching
                                                                            <asp:CheckBox ID="Chk_footer_Finishing" runat="server" />
                                                                            Finishing
                                                                            <asp:CheckBox ID="Chk_footer_cutting" runat="server" />
                                                                            Cutting
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="6%" HeaderStyle-CssClass="header-field">
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:LinkButton ToolTip="Add Record" ID="abtnAdd" runat="server" CommandName="Insert"
                                                                                CssClass="link" Text="" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'><img src="../../images/add-butt.png" /></asp:LinkButton>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <ControlStyle Width="20%"></ControlStyle>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <FooterStyle CssClass="border" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                 <thead class="head-dis">
                                                                    <tr style="text-align: center;">
                                                                   
                                                                        <th>
                                                                            Department name
                                                                        </th>
                                                                        <th>
                                                                            Is Active
                                                                        </th>
                                                                        <th>
                                                                        &nbsp;
                                                                        </th>
                                                                        
                                                                    </tr>
                                                                    </thead>
                                                                    <tbody class="head-dis">
                                                                    <tr style="text-align: center;">
                                                                        <td>
                                                                            <%--<asp:TextBox ID="txtNameEmpty" onkeypress="return ValidateLettersWithSpaceOnly(event);"
                                                                                onpaste="return false;" Style="text-align: center;" runat="server" MaxLength="50" />--%>

                                                                                <asp:DropDownList ID="ddldepartmentempty" runat="server" AppendDataBoundItems="true">
                                                                                <asp:ListItem Selected="True" Value="-1">Select.</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                
                                                                        </td>
                                                                        <td align="center" style="display:none;">
                                                                            <asp:RadioButtonList ID="rbtnIsActiveItemEmpty"   Width="100" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="1" Selected="True"  Text="Active"></asp:ListItem>
                                                                                <asp:ListItem Value="0"  Text="InActive"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:CheckBox ID="chk_add_stitching" runat="server" />
                                                                            Stitching
                                                                            <asp:CheckBox ID="Chk_add_Finishing" runat="server" />
                                                                            Finishing
                                                                            <asp:CheckBox ID="chk_footer_cutting" runat="server" />
                                                                            Cutting
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ID="addbutton" runat="server" CommandName="addnew" CssClass="link"
                                                                                Text="" OnClientClick=""><img src="../../images/add-butt.png" /> </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Record Not Found
                                                                        </td>
                                                                        <td colspan="2"> &nbsp; </td>
                                                                    </tr>

                                                                    </tbody>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle Height="23px" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <%-- <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="abtnAdd" EventName="Click" />
                          </Triggers>--%>
                                                </asp:UpdatePanel>
                                                
                                          
                                    <!--end-->
                            
               
            <asp:Button ID="btnbottom" CssClass="btnbottom" Style="display: none;" runat="server"
                                        Text="Button" OnClick="btnbottom_Click" />
        </td>
    </tr>
</table>
