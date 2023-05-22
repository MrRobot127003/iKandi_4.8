    <%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="WastageAdmin.aspx.cs" Inherits="iKandi.Web.Admin.ProductionAdmin.WastageAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <style type="text/css">
        .remove-head th
        {
            display: none;
        }
        .va-wastage
        {
            width: 80px;
            height: 30px;
        }
        table
        {
            text-transform: capitalize;
        }
        .remove-head
        {
            border-left: 0px;
            border-top: 0px;
        }
        .remove-head td
        {
            padding: 5.25px 0px;
            min-width: 55px;
            max-width: 55px;
            border-left: 0px;
           border-color: #c7c7c799;
        }
        .remove-head tr:first-child > td
        {
            border-top: 0px;
        }
        .remove-head-first
        {
            border-top: 0px;
        }
        .remove-head-first tr:first-child > td
        {
            border-top: 0px;
        }
        .remove-head-first td
        {
            padding: 5px 0px;
            border-color: #c7c7c799;
        }
        .remove-head-first td:first-child
        {
            border-left-color: #999 !important;
        }
        .remove-head td:first-child
        {
            border-left-color: #999 !important;
        }
        
        .remove-head td input
        {
            width: 70% !important;
        }
        /** comment by bharat on 12-june**/
        /*  .remove-head-first
        {
            table-layout: fixed;
        }*/
        .boldCell
        {
            width: 45px;
        }
        .item_list th
        {
            padding: 5px !important;
        }
        a.imagelinkDelete
        {
            background: url(../../images/delete-icon.png) no-repeat left top;
            padding-left: 16px;
        }
        a.imagelinkAdd
        {
            background: url(../../images/add-butt.png) no-repeat left top;
            padding-left: 16px;
        }
        .Textalign
        {
            text-align: center;
        }
        .item_list th
        {
            padding: 5px 0px !important;
        }
        .QtyWidth
        {
            min-width: 150px !important;
            max-width: 150px !important;
        }
        .WastageWidth
        {
            min-width: 60px !important;
            max-width: 60px !important;
        }
        .QtyFooter
        {
            min-width: 150px !important;
            max-width: 150px !important;
            border-left: 1px solid #999 !important;
             border-bottom-color:#999 !important;
        }
        .WastegeFooter
        {
            min-width: 60px !important;
            max-width: 60px !important;
            border-top: 0px;
            border-bottom-color:#999 !important;
        }
        .VaueNameFooter
        {
            min-width: 55px !important;
            max-width: 55px !important;
            border-top: 0px;
            border-bottom-color:#999 !important;
        }
        .maxWidthOver
        {
            max-width:100%;
            overflow-x:auto;
         }
         ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }
        @media screen and (max-width: 1366px) {
          .maxWidthOver
            {
                max-width:1360px;
                overflow-x:auto;
             }
        }
    </style>
    <script type="text/javascript">

        function SubmitPage() {
            $(".btnSubmit").click();
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function isNumberKeyWithdecimal(event) {
            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        }

        function UpdateVaWastage(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }



            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'VAWASTAGE' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }
        function UpdateVaWastageCutting(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }
            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'CUTTINGVAWASTAGE' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }


        function UpdateVaWastageOdering(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }
            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'OrderingVAWASTAGE' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }

        function confirmation() {
            if (confirm("Are you sure you want to delete?"))
                return true;
            else return false;
        }

        function UpdateCutCMT(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }
            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'CutCMT' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }
       
        function UpdateStitchCMT(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }
            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'StitchCMT' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }

        function UpdateFinishCMT(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }
            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'FinishCMT' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }

        function UpdateCMTOH(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }
            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'CMTOH' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }


        function UpdateAcc_Fabric_Wastage(elem, VaID, WastageID) {
            debugger;
            var Flag;
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }
            if (VaID == 5) {
                Flag = 'AccessoryWastage';
            }
            if (VaID == 6) {
                Flag = 'FabricWastage';
            }

            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: Flag }, function (result) {
                if (result > 0) {
//                    if (VaID == 5) {
//                        alert('Accessory wastage updated!');
//                    }
//                    if (VaID == 6) {
//                        alert('Fabric wastage updated!');
//                    }
                    //                    alert('Qty. updated.');
                    // elem.value = elem.defaultValue;
                }
                else {
                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }

        function UpdateLeadTime(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }

            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'LeadTime' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }

        function UpdateOverHead(elem, VaID, WastageID) {
            var Values = elem.value;
            if (Values == '') {
                alert("Please enter value ");
                elem.value = elem.defaultValue;
                return;
            }

            proxy.invoke("UpdateWastageValue", { VaID: VaID, WastageID: WastageID, Values: Values, Flag: 'OverHead' }, function (result) {
                if (result > 0) {
                }
                else {

                    alert('Some Error Occured, Please try Again.');
                }
            }, onPageError, false, false);
        }
    </script>
    <h2 style="width: 100%; color: #fff; background: #39589c; text-align: center; margin: 5px 0px;
        padding: 2px 5px;clear:both">
        Wastage Admin
    </h2>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="maxWidthOver">
    <asp:Label ID="lbld" runat="server"></asp:Label>
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: auto;" cellpadding="0" cellspacing="0" border="0" runat="server"
                id="tblMain">
                <tr>
                    <td valign="top" style="width: 310px;">
                        <asp:GridView ID="grdWastgaeStatic" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false"
                            OnRowDataBound="grdWastgaeStatic_RowDataBound" runat="server" Width="100%" ShowHeader="false"
                            CellPadding="0" CssClass="remove-head-first" BorderColor="Gray">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnRowID" runat="server" Value='<%# Eval("Wastage_Id") %>' />
                                        <asp:TextBox ID="txtfromQty" Style="text-align: center;" ReadOnly="true" MaxLength="6"
                                            Text='<%# Eval("FromRange") %>' runat="server" CssClass="numeric-field-without-decimal-places"
                                            Width="50px"></asp:TextBox>
                                        -
                                        <asp:TextBox ID="txttoQty" Style="text-align: center;" ReadOnly="true" MaxLength="6"
                                            Text='<%# Eval("ToRange") %>' runat="server" CssClass="numeric-field-without-decimal-places"
                                            Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="QtyWidth" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtcuttingWastage" Style="text-align: center;" MaxLength="5" Text='<%# (Eval("CuttingWastage") != null) ? Eval("CuttingWastage").ToString() : ( (Eval("CuttingWastage") != null) ? Eval("CuttingWastage")  : "" ) %>'
                                            runat="server" CssClass="numeric-field-with-decimal-places" Width="45px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOrderingWastage"  Text='<%# (Eval("OrderingWastage") != null) ? Eval("OrderingWastage").ToString() : ( (Eval("OrderingWastage") != null) ? Eval("OrderingWastage")  : "" ) %>' Style="text-align: center;" MaxLength="5" runat="server"
                                            CssClass="numeric-field-with-decimal-places" Width="45px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>
                                






                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                                                            
                                        <asp:TextBox ID="txtCutCMT" Style="text-align: center;" MaxLength="5" Text='<%# Eval("CutCMT").ToString() == ""  ? "" :  Math.Round(Convert.ToDouble(Eval("CutCMT")),1).ToString() %>'
                                            runat="server" CssClass="numeric-field-with-decimal-places" Width="45px"></asp:TextBox>    
                                            
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        
                                        <asp:TextBox ID="txtStitchCMT" Style="text-align: center;" MaxLength="5" Text='<%# Eval("StitchCMT").ToString() == ""  ? "" :  Math.Round(Convert.ToDouble(Eval("StitchCMT")),1).ToString() %>'
                                            runat="server" CssClass="numeric-field-with-decimal-places" Width="45px"></asp:TextBox>    
                                            
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        
                                        <asp:TextBox ID="txtFinishCMT" Style="text-align: center;" MaxLength="5" Text='<%# Eval("FinishCMT").ToString() == ""  ? "" :  Math.Round(Convert.ToDouble(Eval("FinishCMT")),1).ToString() %>'
                                            runat="server" CssClass="numeric-field-with-decimal-places" Width="45px"></asp:TextBox>    
                                            
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        
                                        <asp:TextBox ID="txtCMTOH" Style="text-align: center;" MaxLength="5" Text='<%# Eval("CMTOH").ToString() == ""  ? "" :  Math.Round(Convert.ToDouble(Eval("CMTOH")),1).ToString() %>'
                                            runat="server" CssClass="numeric-field-with-decimal-places" Width="45px"></asp:TextBox>    
                                            
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>





                                
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtoverhead" Style="text-align: center;" MaxLength="3" Text='<%# (Eval("Overhead") != null) ? Eval("Overhead").ToString() : ( (Eval("Overhead") != null) ? Eval("Overhead")  : "" ) %>'
                                            runat="server" CssClass="numeric-field-without-decimal-places" Width="45px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>


                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtleadtimeday" Style="text-align: center;" MaxLength="2" Text='<%# (Eval("LeadTimeDay") != null) ? Eval("LeadTimeDay").ToString() : ( (Eval("LeadTimeDay") != null) ? Eval("LeadTimeDay")  : "" ) %>'
                                            runat="server" CssClass="numeric-field-without-decimal-places" Width="45px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="WastageWidth" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hdnCountColoumn" runat="server" Value="0" />
                    </td>
                    <td valign="top">
                        <asp:GridView ID="grdVadynamic" ShowHeader="false" BorderColor="Gray" AutoGenerateColumns="false"
                            runat="server" OnRowDataBound="grdVadynamic_RowDataBound" CssClass="remove-head"
                            CellPadding="0">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2">
                        <asp:GridView ID="grdFoter" ShowHeader="false" AutoGenerateColumns="false" runat="server"
                            BorderColor="Gray" OnRowDataBound="grdFoter_RowDataBound" CssClass="remove-head"
                            CellPadding="0">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnSubmit" runat="server" CssClass="btnSubmit" Visible="false" OnClick="btnSubmit_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
