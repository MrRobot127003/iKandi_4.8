<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientCostingDefaultList.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.ClientCostingDefaultList" %>
<script type="text/javascript">
    //var gvClientCostingDefaultsClientID = '<%=gvClientCostingDefaults.ClientID %>';


//    function change(evntSrc) {
//        //debugger;
//        var pairs = evntSrc.id.split("-");
//        pairs[1];
//        var rowCount = $("#" + gvClientCostingDefaultsClientID + " tr").length - 2;
//        var rowCount1 = $("#" + gvClientCostingDefaultsClientID).find("tr").length;
//        if (evntSrc.checked == true) {
//            for (var j = 1; j <= rowCount1 - 1; j++) {
//                var objRow = $("#" + gvClientCostingDefaultsClientID).find("tr").filter("tr:eq(" + j + ")");
//                var i = objRow.get(0).rowIndex - 1;
//                if (i == 0) {
//                    if (pairs[1] == 12) {
//                        var ddlconversion = objRow.find(".CONVERSION").val();
//                    }
//                    if (pairs[1] == 111) {
//                        //debugger;
//                        var ddlAchivement = objRow.find(".ACHIEVE").val();
//                    }

//                    else {
//                        var firsttxtval = objRow.find(".commission" + pairs[1]).val();
//                    }
//                }
//                objRow.find(".commission" + pairs[1]).val(firsttxtval);
//                objRow.find(".CONVERSION").val(ddlconversion);
//                objRow.find(".ACHIEVE").val(ddlAchivement);

//                //ACHIEVEMENT
//            }
//        }
//        evntSrc.checked = false;
//        //setTimeout("evntSrc.checked = false", 1000);
//    }
// 
</script>
 <style type="text/css">
               
       	.left
       	{
       	text-align:left;
    </style>

<div class="print-box">
    <div class="form_box">
        <div class="form_heading">
            Client Costing Defaults
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1"  runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <ContentTemplate>        
            <asp:GridView runat="server" 
                HeaderStyle-CssClass="" 
                RowStyle-CssClass="" 
                ID="gvClientCostingDefaults" CssClass="item_list fixed-header"
                AutoGenerateColumns="false" 
                onrowdatabound="gvClientCostingDefaults_RowDataBound">
                <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                Client
                </HeaderTemplate>               
                <ItemTemplate>
                    <asp:Label ID="lblClientName" Font-Size="11px" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                    <asp:HiddenField ID="hdnClientId" Value='<%#Eval("ClientID") %>' runat="server" />
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                Department
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDeptName"  CssClass="left"  Font-Size="11px" runat="server" Text='<%#Eval("DepartmentName") %>'></asp:Label>
                    <asp:HiddenField ID="hdnDeptId" Value='<%#Eval("DeptId") %>' runat="server" />
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                 <HeaderTemplate>
                COMMISION
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtCommission" Text='<%#Eval("COMMISION") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                   <HeaderTemplate>
                CONVT TO
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlConvertTo" runat="server">                   
                    </asp:DropDownList>
                    <asp:HiddenField ID="hdnConvertTo" Value='<%#Eval("CONVERSIONTO") %>' runat="server" />
                   
                </ItemTemplate>
                </asp:TemplateField>
                   
                 <asp:TemplateField>
                  <HeaderTemplate>
                COFFIN BOX
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtCOFFINBOX" Text='<%#Eval("COFFIN_BOX") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>


                 <asp:TemplateField>
                  <HeaderTemplate>
                HANGER LOOPS
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtHANGERLOOPS" Text='<%#Eval("HANGERLOOPS") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                  <HeaderTemplate>
                LBL/TAGS
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtLbltags" Text='<%#Eval("[LBL/TAGS]") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                  <HeaderTemplate>
                OVERHEAD COST
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:TextBox ID="txtOverHeadCost" Text='<%#Eval("OVERHEADCOST") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                 <HeaderTemplate>
               PROFIT MARGIN
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtPROFITMARGIN" Text='<%#Eval("PROFITMARGIN") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                  <HeaderTemplate>
               TEST
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:TextBox ID="txtTEST" Text='<%#Eval("TEST") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                  <HeaderTemplate>
               HANGERS
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:TextBox ID="txtHANGERS" Text='<%#Eval("HANGERS") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField>
                <HeaderTemplate>
               DESIGN COMM.
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtDESIGNCOMM" Text='<%#Eval("DESIGNCOMM") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField>
                 <HeaderTemplate>
               ACHIEVEMENT
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlACHIEVEMENT" runat="server">                   
                    </asp:DropDownList>
                    <asp:HiddenField ID="hdnACHIEVEMENT" Value='<%#Eval("ACHIEVEMENT") %>' runat="server" />
                </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                <HeaderTemplate>
               EXPECTED QTY.
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtEXPECTEDQTY" Text='<%#Eval("EXPECTEDQTY") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                 </asp:TemplateField>
               
                </Columns>
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
    </div>
    <br />
    <asp:Button ID="btnSubmit" runat="server" CssClass="submit" />
</div>