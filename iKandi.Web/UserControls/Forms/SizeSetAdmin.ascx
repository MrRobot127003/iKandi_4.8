<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SizeSetAdmin.ascx.cs" Inherits="iKandi.Web.UserControls.Forms.SizeSetAdmin" %>

<script type="text/javascript">


    function deleteRow_new(srcElem) {
        //debugger;
        var objRow = $(srcElem).parents("tr");
        var rowindex = objRow.get(0).rowIndex;
        var objTable = objRow.parents("table").attr("id");
        var row = $("#" + objTable).find("tr").filter("tr:eq(" + rowindex + ")");
        var mainRow = row.attr("id").split('_');
        var newval = parseInt($("#hdntotal" + mainRow[1]).val()) - 1;
        $("#hdntotal" + mainRow[1]).val(newval);
        row.remove();
        var val = parseInt($("#" + '<%=hdnaddtr.ClientID%>').val());
        val = val - 1;
        $("#" + '<%=hdnaddtr.ClientID%>').val(val)
    }

    function addRow_new(srcElem) {
        //debugger;
        var objRow = $(srcElem).parents("tr");
        var objTable = $(objRow).parents("table").attr("id");
        var val = parseInt($("#" + '<%=hdnaddtr.ClientID%>').val());
        if (val < 25) {
            var row = $("#" + objTable + " tr:last").prev("tr").clone(true).insertAfter($("#" + objTable + " tr:last").prev("tr"));
            var newLastRow = $("#" + objTable + " tr:last").prev("tr");
            var newLastRowId = $("#" + objTable + " tr:last").prev("tr").attr("id");
            //alert(newLastRowId);

            var newLastRowDtl = newLastRowId.split("_");
            var IdNo = parseInt(newLastRowDtl[1]);


            var rowId = newLastRow.attr("id");
            //alert(rowId);
            var mainRow = rowId.split("_");
            //var newRowIndex = mainRow[1];
            mainRow[0] = mainRow[0] + '_';
            newLastRow.attr("id", mainRow[0] + (IdNo + 1));
            var newval = parseInt($("#hdntotal").val()) + 1;
            $("#hdntotal").val(newval);
            newLastRow.attr("id", mainRow[0] + (IdNo + 1));
            newLastRow.attr("id")
            newLastRow.find("input").val("");
            newLastRow.find("input:first").focus();
            newLastRow.find("span").show();
            newLastRow.find("input,textarea,span").val("").each(function () {

                var name = $(this).attr("name");
                var mainName = name.split("_");
                name = mainName[0];
                $(this).attr("name", name + '_' + (IdNo + 1));

                var id = $(this).attr("id");
                var mainId = id.split("_");
                id = mainId[0];
                $(this).attr("id", id + '_' + (IdNo + 1));

            });
            // debugger
            newLastRow.find("label, label,label").each(function () {
                //debugger;
                var name = $(this).attr("name");
                if (name != null) {

                    var mainName1 = name.split("_");
                    name = mainName1[0];
                    $(this).attr("name", name + '_' + (IdNo + 1));

                    var id = $(this).attr("id");
                    var mainId = id.split("_");
                    id = mainId[0];
                    $(this).attr("id", id + '_' + (IdNo + 1));
                    //$("#Tagclonediv_" + 2).html('');
                    $(this).html("Option" + " " + (IdNo + 1))
                }

            });

            val = val + 1;
            $("#" + '<%=hdnaddtr.ClientID%>').val(val)
        }
    }





    function FillSize(SupplierId) {
        //debugger;

        proxy.invoke("GetSizeSetAdmin", {},
            function (objStyleFabricCollection) {
                if (objStyleFabricCollection != null) {
                    //debugger;
                    if (objStyleFabricCollection.length > 0)
                    //debugger;

                        var sizes = objStyleFabricCollection[0].Sizes.split(',');
                    SetContactToControls(1, sizes[0], sizes[1], sizes[2], sizes[3], sizes[4], sizes[5], sizes[6], sizes[7], sizes[8], sizes[9], sizes[10], sizes[11], sizes[12], sizes[13], sizes[14]);
                    for (var k = 1; k < objStyleFabricCollection.length; k++) {
                        $("#btnAddRow1_1").click();

                        var sizes = objStyleFabricCollection[k].Sizes.split(',');
                        // debugger;
                        SetContactToControls(k + 1, sizes[0], sizes[1], sizes[2], sizes[3], sizes[4], sizes[5], sizes[6], sizes[7], sizes[8], sizes[9], sizes[10], sizes[11], sizes[12], sizes[13], sizes[14]);

                    }
                }
            });
    }

    function SetContactToControls(id, Size0, Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11, Size12, Size13, Size14) {
        //debugger;

        $("#txtSize1_" + id).val(Size0);
        $("#txtSize2_" + id).val(Size1);
        $("#txtSize3_" + id).val(Size2);
        $("#txtSize4_" + id).val(Size3);
        $("#txtSize5_" + id).val(Size4);
        $("#txtSize6_" + id).val(Size5);
        $("#txtSize7_" + id).val(Size6);
        $("#txtSize8_" + id).val(Size7);
        $("#txtSize9_" + id).val(Size8);
        $("#txtSize10_" + id).val(Size9);
        $("#txtSize11_" + id).val(Size10);
        $("#txtSize12_" + id).val(Size11);
        $("#txtSize13_" + id).val(Size12);
        $("#txtSize14_" + id).val(Size13);
        $("#txtSize15_" + id).val(Size14);

    }



    


</script>

<div style="width:950px; text-align:center;">

<table width="100%">
<tr>
<td>
<input id="hdntotal" name="hdntotal" type="hidden" value="1" />
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper" >
                    <tr>
                        <td>
                            <table id="tblInner_1" name="tblInner_1" width="100%" border="0" align="center" cellspacing="0" cellpadding="0" style="margin:0px;">
                                <tr class="td-sub_headings">
                                            <td width="18%" valign="bottom" align="center" class="border border-right-none">
                                               
                                            </td>
                                            <td width="10%" valign="bottom" align="center" class="border border-right-none">
                                                
                                            </td>
                                            <td width="10%" valign="bottom" align="center" class="border border-right-none">
                                              
                                            </td>
                                            <td width="10%" valign="bottom" align="center" class="border border-right-none">
                                                
                                            </td>
                                            <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                            <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                            <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                           <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                        <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                                 <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                                 <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                                 <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                                 <td width="10%" valign="bottom" 
                                                class="border border-toprightbottom-none">&nbsp;</td>
                                        </tr>
                                <tr id="trInner_1" name="trInner_1">
                                            <td class="inner_tbl_td border border-topright-none" align="center">
                                               <%-- <input id="Option_1" name="Option_1" type="text" class="inputvalue_textbox textbox_inputbox3"  maxlength="60" style="text-transform: none; width:40px;" />--%>
                                                <label id="Option_1" name="Option_1">Option 1</label>
                                            </td>
                                            <td class="inner_tbl_td border border-topright-none" align="center">
                                                <input id="txtSize1_1" name="txtSize1_1" type="text" class="inputvalue_textbox textbox_inputbox3" maxlength="50"
                                                    style="text-transform: none; width:40px;" />
                                            </td>
                                            <td class="inner_tbl_td border border-topright-none" align="center">
                                                <input id="txtSize2_1" name="txtSize2_1" type="text" style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize3_1" name="txtSize3_1" type="text" style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize4_1" name="txtSize4_1" type="text" style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize5_1" name="txtSize5_1" type="text" style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize6_1" name="txtSize6_1" type="text" style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize7_1" name="txtSize7_1" type="text"  style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                             <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize8_1" name="txtSize8_1" type="text"  style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize9_1" name="txtSize9_1" type="text"   style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize10_1" name="txtSize10_1" type="text"   style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize11_1" name="txtSize11_1" type="text"  style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize12_1" name="txtSize12_1" type="text"  style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>

                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize13_1" name="txtSize13_1" type="text"   style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>

                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize14_1" name="txtSize14_1" type="text"   style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>


                                            <td align="center" class="inner_tbl_td border border-topright-none">
                                                <input id="txtSize15_1" name="txtSize15_1" type="text"  style="text-transform: none; width:40px;"
                                                    class="inputvalue_textbox textbox_inputbox3" />
                                            </td>
                                            
                                            <td align="center" class="border border-toprightbottom-none" style="visibility:hidden;">
                                                <span class="da_remove_btn_dafo" name="spn_1" id="spn_1"  style="display:none;"><a href="#" class="link" id="btnDeleteRow1_1" onclick="deleteRow_new(this); return false;">Delete</a></span>
                                            </td>
                                        </tr>
                                <tr>
                                            <td colspan="116" align="right">
                                                <span class="da_remove_btn_dafo btnAdd" id="btnAddRow1_1" onclick="addRow_new(this); return false;">
                                                    <a href="#" onclick="return false;"><img src="../../App_Themes/ikandi/images/plus_icon.gif" border="0" />&nbsp;<span class="link">Add</span></a></span></td>
                                           
                                            <td align="right">
                                                &nbsp;
                                            </td>                                           
                                        </tr>
                              <asp:HiddenField ID="hdnaddtr" runat="server" Value="1" />
                            </table>
                        </td>
                    </tr>
                    <tr>
                    <td align="left">
                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                    </td>
                    </tr>
           

<tr>
<td>
<asp:GridView ID="grdSizeSet" Width="100%" runat="server" 
        AutoGenerateColumns="false" onrowdatabound="grdSizeSet_RowDataBound" 
        onrowediting="grdSizeSet_RowEditing">
<Columns>
<asp:TemplateField HeaderText="Option">
<ItemTemplate>
<asp:Label ID="lblOption" Width="30%" runat="server" Text='<%#Eval("SizeOption") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Size">
<ItemTemplate>
<asp:Label ID="lblSize" runat="server" Text='<%#Eval("Size") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Action">
<ItemTemplate>
<%--<asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="link" OnClientClick="javascript:return FillSize();">Edit</asp:LinkButton>--%>
<a id="lnkEdit1" onclick="javascript:return FillSize();">Edit</a>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

<%--<asp:Button ID="btnView" runat="server" Text="View" OnClientClick="javascript:return FillSize();"  />--%>

</td>
</tr>
</table>
</td>
</tr>
</table>

</div>

